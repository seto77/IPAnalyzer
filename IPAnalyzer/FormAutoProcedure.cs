#region using
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Crystallography;
using System.Text;
using System.Collections.Generic;
using System.Threading;
using System.Collections.Concurrent; // 261111Cl 追加
using System.Diagnostics; // 261111Cl 追加
using System.Threading.Tasks; // 261111Cl 追加
#endregion

namespace IPAnalyzer;

public partial class FormAutoProcedure : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
{
    #region フィールド、プロパティ
    public FormMain formMain;

    private string targetFolder = "";

    public string[] Macros
    {
        set
        {
            comboBoxMacro.Items.Clear();
            if (value != null)
                comboBoxMacro.Items.AddRange(value); //260712Cl foreach+Add を一括 AddRange に
        }
    }
    #endregion

    #region コンストラクト、ロード、クローズ
    public FormAutoProcedure()
    {
        InitializeComponent();
        HelpPage = "3-tools"; //260604Cl 追加
    }
    private void FormAutoProcedure_Load(object sender, EventArgs e)
    {
        checkedListBoxAuto.SetItemChecked(0, false);
        checkedListBoxAuto.SetItemChecked(1, false);
        checkedListBoxAuto.SetItemChecked(2, false);
        checkedListBoxAuto.SetItemChecked(3, true);
        checkedListBoxAuto.SetItemChecked(4, false);
    }

    private void FormAutoProcedure_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.toolStripButtonAutoProcedure.Checked = false;
    }
    #endregion

    #region その他イベント
    private void checkedListBoxAuto_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index == 4)
            comboBoxMacro.Enabled = e.NewValue == CheckState.Checked;
    }
    #endregion

    #region 一連の操作を実行する. FormMainから呼ばれる
    public void ExecuteAutoProcedure()
    {
        if (formMain.FormFindParameter.Visible) return;

        //自動輝度調整
        if (checkedListBoxAuto.GetItemChecked(0))
            formMain.buttonAutoLevel_Click(new object(), new EventArgs());
        Application.DoEvents();

        //FindCenter
        if (checkedListBoxAuto.GetItemChecked(1))
            for (int i = 0; i < 2; i++)
                formMain.toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
        Application.DoEvents();

        //MaskSpots
        if (checkedListBoxAuto.GetItemChecked(2))
            formMain.toolStripSplitButtonMaskSpots_ButtonClick(new object(), new EventArgs());
        Application.DoEvents();

        //GetProfile
        if (checkedListBoxAuto.GetItemChecked(3))
            formMain.toolStripSplitButtonGetProfileButtonClick(new object(), new EventArgs());

        //Execute Macro
        if (checkedListBoxAuto.GetItemChecked(4))
        {
            if (comboBoxMacro.Text != "")
                formMain.FormMacro.RunMacroName(comboBoxMacro.Text);
        }
        Application.DoEvents();
    }
    #endregion

    #region ファイル更新監視
    // 261111Cl 変更: BackgroundWorker による 100 ms ごとの全ファイル列挙 (サブフォルダ込み) をやめ、FileSystemWatcher を主にして、
    //   取りこぼしの保険に低頻度のポーリング (5 秒。監視を作れないフォルダでは 1 秒) を残した。旧の問題:
    //   - ワーカーから UI (チェックボックス・テキストボックス・NumericBox) を読んでいた → 開始時に UI スレッドで WatchSettings に取得する
    //   - UI スレッドの while (IsBusy) { CancelAsync(); Sleep(100); } は、完了通知が UI に Post されるため抜けられずハングしうる
    //     → CancellationToken で止め、UI スレッドでは待たない
    // backgroundWorker (Designer の部品) は残すが使わない (DoWork / RunWorkerCompleted のハンドラは Designer が配線しているので残す)

    /// <summary>261111Cl 追加: 監視の開始時に UI から取得する条件 (監視中は UI を読まない)</summary>
    private readonly record struct WatchSettings(bool NumberMatching, int Divisor, int Remainder, bool Equal, bool NotEqual, bool KeywordEnabled, string Keyword);

    private CancellationTokenSource watchCts = null; // 261111Cl 追加: 実行中の監視を止めるためのもの (UI スレッドだけで読み書きする)

    /// <summary>261111Cl 追加: 監視を実行し、終わるまで (await で) 見届ける。UI スレッドから呼ぶ</summary>
    private async Task RunWatchAsync(string folder, WatchSettings settings, CancellationTokenSource cts)
    {
        try
        {
            await Task.Run(() => WatchFolderAsync(folder, settings, cts.Token));
        }
        catch (OperationCanceledException) when (cts.IsCancellationRequested) { }
        catch (Exception ex)
        {
            // 旧の RunWorkerCompleted と同じく、監視が異常終了したらチェックを外す (別の監視が始まっていれば触らない)
            Debug.WriteLine($"AutoProcedure watch: {ex}");
            if (watchCts == cts)
                checkBoxAutoLoad.Checked = false;
        }
        finally
        {
            if (watchCts == cts)
                watchCts = null;
            cts.Dispose();
        }
    }

    /// <summary>261111Cl 追加: フォルダ (サブフォルダ込み) に新しく現れたファイルを読み込む。ワーカースレッドで動き、UI は読まない</summary>
    private async Task WatchFolderAsync(string folder, WatchSettings settings, CancellationToken token)
    {
        // FileSystemWatcher からの通知 (スレッドプールで来る)。(パス, 消えたか)。known (既知のファイル) はこのループだけが触る
        var events = new ConcurrentQueue<(string path, bool removed)>();
        int rescanRequested = 0;
        using var signal = new SemaphoreSlim(0);
        void wake() { try { signal.Release(); } catch (ObjectDisposedException) { } catch (SemaphoreFullException) { } }

        FileSystemWatcher watcher = null;
        try
        {
            try
            {
                watcher = new FileSystemWatcher(folder)
                {
                    IncludeSubdirectories = true,
                    NotifyFilter = NotifyFilters.FileName | NotifyFilters.DirectoryName,
                    InternalBufferSize = 64 * 1024,
                };
                watcher.Created += (_, ev) =>
                {
                    if (Directory.Exists(ev.FullPath)) Interlocked.Exchange(ref rescanRequested, 1); // フォルダごと置かれたときは中のファイルの通知が来ないので一覧し直す
                    else events.Enqueue((ev.FullPath, false));
                    wake();
                };
                watcher.Renamed += (_, ev) =>
                {
                    events.Enqueue((ev.OldFullPath, true));
                    if (Directory.Exists(ev.FullPath)) Interlocked.Exchange(ref rescanRequested, 1);
                    else events.Enqueue((ev.FullPath, false));
                    wake();
                };
                watcher.Deleted += (_, ev) => { events.Enqueue((ev.FullPath, true)); wake(); };
                // 通知のあふれ・ネットワークの切断など。取りこぼしたかもしれないので一覧し直す
                watcher.Error += (_, ev) => { Debug.WriteLine($"AutoProcedure watcher error: {ev.GetException()}"); Interlocked.Exchange(ref rescanRequested, 1); wake(); };
                watcher.EnableRaisingEvents = true;
            }
            catch (Exception ex)
            {
                // 監視を作れないフォルダ (一部のネットワークドライブなど) はポーリングだけで動く
                Debug.WriteLine($"AutoProcedure: FileSystemWatcher unavailable for {folder}: {ex.Message}");
                watcher?.Dispose();
                watcher = null;
            }

            // 開始時点のファイルは読み込まない (旧と同じ)。通知と一覧でパスの大文字小文字が食い違っても二重に読まないよう、大文字小文字を区別しない
            var known = new HashSet<string>(Directory.GetFiles(folder, "*", SearchOption.AllDirectories), StringComparer.OrdinalIgnoreCase);
            var pollInterval = TimeSpan.FromSeconds(watcher != null ? 5 : 1);
            var sincePoll = Stopwatch.StartNew();

            while (true)
            {
                token.ThrowIfCancellationRequested();
                try
                {
                    // 新しいファイルを集める (通知の順、続いて一覧の順)
                    var targets = new List<string>();
                    var targetSet = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    while (events.TryDequeue(out var ev))
                    {
                        if (ev.removed)
                        {
                            known.Remove(ev.path);
                            if (targetSet.Remove(ev.path))
                                targets.RemoveAll(p => string.Equals(p, ev.path, StringComparison.OrdinalIgnoreCase));
                        }
                        else if (!known.Contains(ev.path) && targetSet.Add(ev.path)) targets.Add(ev.path);
                    }
                    string[] listing = null;
                    if (Interlocked.Exchange(ref rescanRequested, 0) == 1 || sincePoll.Elapsed >= pollInterval)
                    {
                        listing = Directory.GetFiles(folder, "*", SearchOption.AllDirectories);
                        sincePoll.Restart();
                        foreach (var f in listing)
                            if (!known.Contains(f) && targetSet.Add(f))
                                targets.Add(f);
                    }

                    foreach (var f in targets)
                    {
                        token.ThrowIfCancellationRequested();
                        try { await LoadNewFileAsync(f, settings, token); }
                        catch (OperationCanceledException) when (token.IsCancellationRequested) { throw; }
                        catch (Exception ex) { Debug.WriteLine($"AutoProcedure load {f}: {ex}"); } // 1 つの失敗で他のファイルを止めない
                        known.Add(f); // 旧と同じく、新しいファイルは (読めたかどうかによらず) 1 回だけ扱う
                    }

                    // 一覧をとったときは、旧の FileList = temp と同じく既知のファイルを一覧で置き換える (消えたファイルを忘れる)
                    if (listing != null)
                    {
                        known = new HashSet<string>(listing, StringComparer.OrdinalIgnoreCase);
                        known.UnionWith(targets);
                    }

                    // 監視が止まっていたら (エラーの後など) 付け直しを試みる
                    if (watcher != null && !watcher.EnableRaisingEvents)
                        try { watcher.EnableRaisingEvents = true; } catch (Exception ex) { Debug.WriteLine($"AutoProcedure: re-enable watcher failed: {ex.Message}"); }
                }
                catch (OperationCanceledException) when (token.IsCancellationRequested) { throw; }
                //旧と同じく、監視ループの例外は記録して 1 秒後にやり直す
                catch (Exception ex) { Debug.WriteLine($"AutoProcedure watch loop: {ex}"); await Task.Delay(1000, token); }

                // 次の通知か、次のポーリングの時刻まで待つ
                var wait = pollInterval - sincePoll.Elapsed;
                await signal.WaitAsync(wait > TimeSpan.Zero ? wait : TimeSpan.Zero, token);
            }
        }
        finally
        {
            watcher?.Dispose();
        }
    }

    /// <summary>261111Cl 追加: 新しいファイル 1 つを、書き込みが終わるのを待ってから条件を確かめて読み込む (旧の DoWork の中身と同じ手順)</summary>
    private async Task LoadNewFileAsync(string f, WatchSettings settings, CancellationToken token)
    {
        for (int i = 0; i < 1000 && Miscellaneous.isFileExistsAndLocked(f); i++)
            await Task.Delay(50, token);

        if (Miscellaneous.isFileExistsAndLocked(f) || !ImageIO.IsReadable(Path.GetExtension(f)))
            return;

        var filename = Path.GetFileNameWithoutExtension(f);
        if (settings.NumberMatching)//ナンバーマッチングの場合
        {
            //260529Cl ファイル名末尾の連続した数字を取り出して判定する
            int start = filename.Length;
            while (start > 0 && filename[start - 1] >= '0' && filename[start - 1] <= '9')
                start--;

            //数字が一致するかどうか (数字を取得できない・除数が0の場合は不一致とみなす)
            bool matched = int.TryParse(filename.AsSpan(start), out int num)
                && settings.Divisor != 0
                && num % settings.Divisor == settings.Remainder;

            //等号: 一致したら正解 / 不等号: 不一致なら正解。正解でなければ読み込まない
            if ((settings.Equal && !matched) || (settings.NotEqual && matched))
                return;
        }
        if (settings.KeywordEnabled && !filename.Contains(settings.Keyword))
            return;

        //260529Cl 読み込み前にファイルサイズの変動が無くなるまで待機する
        long fileSize = -1, current;
        while ((current = new FileInfo(f).Length) != fileSize)
        {
            fileSize = current;
            await Task.Delay(50, token);
        }

        token.ThrowIfCancellationRequested();
        formMain.ReadImage(f); // 別スレッドから呼ばれると、ReadImage の中で UI スレッドへ Invoke される
    }

    //string[] FileList = []; // 261111Cl コメントアウト: 旧の監視ループ (下) でだけ使っていた
    /// <summary>261111Cl: 使わなくなった (Designer が配線しているので残す)。旧の中身はコメントで保存</summary>
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
    #region 261111Cl 変更前 (BackgroundWorker の監視ループ)
    /*
        FileList = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
        while (!backgroundWorker.CancellationPending)
        {
            try
            {
                var temp = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
                if (temp.Length != FileList.Length)
                {
                    var known = new HashSet<string>(FileList); //260712Cl 線形探索を O(1) 化 (比較子は既定=Ordinal のまま。挙動不変)
                    //foreach (var f in temp.Where(e => !FileList.Contains(e))) //260712Cl HashSet 化前のコード
                    foreach (var f in temp.Where(x => !known.Contains(x)))
                    {
                        for(int i=0; i<1000 && Miscellaneous.isFileExistsAndLocked(f) && !backgroundWorker.CancellationPending; i++)
                            Thread.Sleep(50);

                        if (!Miscellaneous.isFileExistsAndLocked(f) && !backgroundWorker.CancellationPending && ImageIO.IsReadable(Path.GetExtension(f)))
                        {
                            var flag = true;
                            var filename = Path.GetFileNameWithoutExtension(f);
                            if (checkBoxNumberMatching.Checked)//ナンバーマッチングの場合
                            {
                                //260529Cl ファイル名末尾の連続した数字を取り出して判定する
                                var numStr = new List<char>();
                                for (int i = filename.Length - 1; i >= 0; i--)
                                {
                                    if (filename[i] >= '0' && filename[i] <= '9')
                                        numStr.Add(filename[i]);
                                    else
                                        break;
                                }
                                numStr.Reverse();

                                //数字が一致するかどうか (数字を取得できない・除数が0の場合は不一致とみなす)
                                bool matched = int.TryParse(new string([.. numStr]), out int num)
                                    && numericBoxDivisor.ValueInteger != 0
                                    && num % numericBoxDivisor.ValueInteger == numericBoxRemainder.ValueInteger;

                                //等号: 一致したら正解 / 不等号: 不一致なら正解。正解でなければ flag を false にする
                                if ((radioButtonEqual.Checked && !matched) || (radioButtonNotEqual.Checked && matched))
                                    flag = false;
                            }
                            if (flag && checkBoxKeywords.Checked)
                            {
                                if (!filename.Contains(textBoxKeyword.Text))
                                    flag = false;
                            }

                            //260529Cl 読み込み前にファイルサイズの変動が無くなるまで待機する
                            if (flag)
                            {
                                long fileSize = -1, current;
                                while ((current = new FileInfo(f).Length) != fileSize && !backgroundWorker.CancellationPending)
                                {
                                    fileSize = current;
                                    Thread.Sleep(50);
                                }
                            }

                            if (flag && !backgroundWorker.CancellationPending)
                                formMain.ReadImage(f);

                        }
                    }

                    if (backgroundWorker.CancellationPending)
                        return;

                    FileList = temp;
                }
            }

            //260712Cl 監視ループの堅牢性のため全例外は従来どおり吸収+リトライするが、無言の握りつぶしをやめ最低限記録する
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"AutoProcedure watch loop: {ex}"); Thread.Sleep(1000); }
            Thread.Sleep(100);
        }
    */
    #endregion
    }

    private void buttonSetDirectory_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            textBoxDiectory.Text = folderBrowserDialog1.SelectedPath;
    }

    private void checkBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxAutoLoad.Checked)
        {
            targetFolder = textBoxDiectory.Text;
            if (targetFolder.Length == 0 || !Directory.Exists(targetFolder))
            {
                MessageBox.Show(Crystallography.Localization.Loc(en: "Set the appropriate directories to be monitored.", ja: "監視するディレクトリを正しく設定してください。", de: "Bitte legen Sie die zu überwachenden Verzeichnisse korrekt fest.", fr: "Définissez les répertoires appropriés à surveiller.", es: "Defina los directorios adecuados que se van a supervisar.", pt: "Defina os diretórios apropriados a serem monitorados.", it: "Imposta le cartelle appropriate da monitorare.", ru: "Задайте подходящие каталоги для наблюдения.", zhHans: "请设置要监视的合适目录。", zhHant: "請設定要監控的適當資料夾。", ko: "모니터링할 적절한 디렉터리를 설정하세요.")); // 260625Cl Loc化
                checkBoxAutoLoad.Checked = false;
                return;
            }
            //FileList = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
            //
            //while (backgroundWorker.IsBusy)
            //{
            //    backgroundWorker.CancelAsync();
            //    Thread.Sleep(100);
            //}
            //backgroundWorker.RunWorkerAsync();
            // 261111Cl 変更: 前の監視が残っていれば止めるだけで、終わるのを UI スレッドで待たない (旧の while(IsBusy) はハングしうる)。
            //   UI の値はここで取得して監視に渡す (監視中に条件を変えても、次に監視を開始するまで反映されない)
            watchCts?.Cancel();
            var cts = new CancellationTokenSource();
            watchCts = cts;
            var settings = new WatchSettings(checkBoxNumberMatching.Checked, numericBoxDivisor.ValueInteger, numericBoxRemainder.ValueInteger,
                radioButtonEqual.Checked, radioButtonNotEqual.Checked, checkBoxKeywords.Checked, textBoxKeyword.Text);
            _ = RunWatchAsync(targetFolder, settings, cts);
        }
        else
            //backgroundWorker.CancelAsync();
            watchCts?.Cancel(); // 261111Cl 変更
    }
    #endregion

    /// <summary>261111Cl: backgroundWorker を使わなくなったので呼ばれない (Designer が配線しているので残す)。異常終了時にチェックを外す処理は RunWatchAsync へ</summary>
    private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
        checkBoxAutoLoad.Checked = false;
    }
}