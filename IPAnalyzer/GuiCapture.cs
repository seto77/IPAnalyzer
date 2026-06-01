using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace IPAnalyzer;

/// <summary>
/// 260601Cl 追加: GUI 統一性監査・マニュアル用に IPAnalyzer の全フォームを構築して PNG 一括保存する開発者向けツール。
/// ReciPro/GuiCapture.cs を IPAnalyzer 用に移植 (OpenGL 関連を除去し、フォーム注入・代表状態を IPAnalyzer に合わせた)。
/// 起動: <c>IPAnalyzer.exe --capture [出力ディレクトリ] [カルチャ(en/ja)]</c>
/// 各フォームを画面内 (0,0) に最前面表示し、<see cref="Graphics.CopyFromScreen(Point, Point, Size)"/> で実描画をそのまま撮る。
/// 通常起動 (引数なし) では一切実行されない。
/// </summary>
internal static class GuiCapture
{
    /// <summary>
    /// 260601Cl 追加: --capture で言語を強制指定 (en/ja) した場合のカルチャ。
    /// FormMain ctor / Registry(Read) がレジストリ値で CurrentUICulture を上書きするため、各フォーム構築前に再設定する。
    /// </summary>
    public static System.Globalization.CultureInfo ForcedUICulture;

    // 260601Cl: CopyFromScreen 方式の待機時間。--capture は Application.Run を回さず DoEvents で描画を進めるため、
    // Show / タブ切替 の後に「描画が画面へ反映される」まで明示的に待ってから撮る必要がある。
    private const int FirstPaintSettleMs = 350; // 初回表示後、フォーム全体が描画されるまでの待ち
    private const int PrepareSettleMs = 450;    // 代表状態 (画像読込) 後の再計算・再描画待ち
    private const int TabSwitchSettleMs = 180;  // クロップ時にタブを切り替えた後の再描画待ち

    /// <summary>260601Cl 追加: 実行ファイル (bin/...) からリポルート (...\IPAnalyzer) を辿る。bin が見つからなければ null。</summary>
    private static string RepoRoot()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && dir.Name != "bin")
            dir = dir.Parent;
        return dir?.Parent?.Parent?.FullName; // bin → ...\IPAnalyzer\IPAnalyzer → ...\IPAnalyzer (docs/ を持つリポルート)
    }

    /// <summary>260601Cl 追加: --capture の出力先を省略したときの既定ディレクトリ (docs/src/assets/cap-{en|ja}-auto)。</summary>
    private static string DefaultAutoCaptureDir()
    {
        var culture = ForcedUICulture ?? System.Threading.Thread.CurrentThread.CurrentUICulture;
        var langDir = culture.Name == "ja" ? "cap-ja-auto" : "cap-en-auto";
        var repoRoot = RepoRoot();
        return repoRoot != null
            ? Path.Combine(repoRoot, "docs", "src", "assets", langDir)
            : Path.Combine(Path.GetTempPath(), "ipanalyzer-capture-" + langDir);
    }

    /// <summary>
    /// 260601Cl 追加: FormMain の代表状態用サンプル画像を references/ImageExample から探す。
    /// CeO2 (標準校正物質、明瞭なデバイ環) を優先し、無ければ最初の読込可能画像を返す。巨大ファイルは避ける。無ければ null。
    /// </summary>
    public static string FindSampleImage()
    {
        var root = RepoRoot();
        if (root == null) return null;
        var dir = Path.Combine(root, "references", "ImageExample");
        if (!Directory.Exists(dir)) return null;

        IEnumerable<string> files;
        try { files = Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories); }
        catch { return null; }

        string firstReadable = null;
        foreach (var file in files)
        {
            FileInfo fi;
            try { fi = new FileInfo(file); } catch { continue; }
            if (fi.Length > 32L * 1024 * 1024) continue; // 32MB 超は読込が重いので避ける
            var ext = fi.Extension.TrimStart('.');
            if (!Crystallography.ImageIO.IsReadable(ext)) continue;
            if (fi.Name.Contains("CeO2", StringComparison.OrdinalIgnoreCase))
                return file; // 代表画像: CeO2 を最優先
            firstReadable ??= file;
        }
        return firstReadable;
    }

    /// <summary>
    /// --capture の本体。IPAnalyzer 内の parameterless ctor を持つ Form を順に構築し、フォーム単位の PNG を保存する。
    /// FormMain は他フォームへ注入する代表状態を作るため最後まで保持する。通常起動からは呼ばない開発者向け経路。
    /// </summary>
    public static void Run(string outDir)
    {
        outDir ??= DefaultAutoCaptureDir();
        Directory.CreateDirectory(outDir);

        var log = new List<string>();
        void Trace(string s)
        {
            var line = $"{DateTime.Now:HH:mm:ss.fff}\t{s}";
            log.Add(line);
            Console.WriteLine(line);
        }

        // フォームの Load / VisibleChanged 等で投げられた例外を握りつぶす。
        // これをしないと WinForms 標準の未処理例外ダイアログ (モーダル) が出てハーネスがハングする。
        Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
        Application.ThreadException += (_, e) => Trace($"\tThreadException\t{e.Exception.GetType().Name}: {e.Exception.Message}");

        Trace($"capture start -> {outDir}");

        // CopyFromScreen は物理画面を読むため、RDP セッションが非表示・最小化・フォーカス喪失だと失敗する。毎回最初に注意喚起を出す。
        Trace("==================================================================================");
        Trace("[CAUTION] Capture uses CopyFromScreen. Keep the screen VISIBLE and FOCUSED until done.");
        Trace("          Over Remote Desktop (RDP): keep the RDP window in the foreground, and do NOT");
        Trace("          minimize or disconnect. A hidden/minimized session yields blank/failed shots.");
        Trace("[注意] 画面キャプチャ中はウィンドウを前面・表示のまま保ってください。RDP の場合は RDP ウィンドウを");
        Trace("       前面に出したまま最小化・切断しないでください (非表示だと撮影が失敗/真っ黒になります)。");
        Trace("==================================================================================");

        // 起動時に画面が取得可能か 8x8 で試し、不可ならその場で警告する (全フォーム失敗の前に気付けるように)。
        using (var probe = CaptureScreen(new Rectangle(0, 0, 8, 8), null, Trace, "screen-probe"))
        {
            if (probe == null)
                Trace("[CAUTION] Screen capture is currently UNAVAILABLE. Bring the (RDP) session to the foreground now.");
        }

        // IPAnalyzer アセンブリ内の、パラメータレスコンストラクタを持つ Form 派生型を対象にする。
        // FormMain を先頭に構築する (他フォームへ注入する代表状態をここで作る)。
        var types = typeof(FormMain).Assembly.GetTypes()
            .Where(t => typeof(Form).IsAssignableFrom(t) && !t.IsAbstract && t.GetConstructor(Type.EmptyTypes) != null)
            .OrderBy(t => t == typeof(FormMain) ? 0 : 1).ThenBy(t => t.Name)
            .ToList();
        Trace($"{types.Count} form types (parameterless ctor)");

        int ok = 0, fail = 0;
        FormMain captureFormMain = null; // FormMain を保持し、子フォームへ注入する
        foreach (var type in types)
        {
            Form form = null;
            try
            {
                // 直前のフォーム (特に FormMain) がレジストリ値でカルチャを書き換えても、強制指定があれば戻す。
                if (ForcedUICulture != null)
                    System.Threading.Thread.CurrentThread.CurrentUICulture = ForcedUICulture;
                form = (Form)Activator.CreateInstance(type);
                if (form is FormMain mainForm)
                    captureFormMain = mainForm; // reflection 順の先頭で作った FormMain を後続フォームの親情報として再利用する
                else
                    InjectFormMain(form, captureFormMain); // 子フォームは formMain/FormMain/formFindParameter を注入しないと Show/Close で NRE する

                CaptureForm(form, type.Name, outDir, Trace, closeAfterCapture: !ReferenceEquals(form, captureFormMain));
                ok++;

                // マクロエディタ (FormMacro) は引数付き ctor のため reflection 単独生成できない。FormMain が Load で配線済みの
                // インスタンスを保持しているので、FormMain 直後にここで撮る。
                if (ReferenceEquals(form, captureFormMain) && captureFormMain.FormMacro != null)
                {
                    try { TryShowMacroSamples(captureFormMain.FormMacro, Trace); CaptureForm(captureFormMain.FormMacro, "FormMacro", outDir, Trace, closeAfterCapture: true); ok++; }
                    catch (Exception ex) { fail++; Trace($"FormMacro\tFAIL\t{ex.GetType().Name}: {ex.Message}"); }
                }
            }
            catch (Exception ex)
            {
                fail++;
                Trace($"{type.Name}\tFAIL\t{ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                if (!ReferenceEquals(form, captureFormMain))
                {
                    try { form?.Dispose(); } catch { /* 破棄時例外は無視 */ }
                }
            }
        }

        try { captureFormMain?.Close(); captureFormMain?.Dispose(); } catch { /* 破棄時例外は無視 */ }

        Trace($"done: ok={ok} fail={fail}");
        File.WriteAllLines(Path.Combine(outDir, "_capture-log.tsv"), log);
    }

    /// <summary>
    /// 260601Cl 追加: 子フォームへ FormMain (またはその配線済み子) を注入する。
    /// IPAnalyzer の各フォームは formMain/FormMain/formFindParameter を設定せずに Show/Close すると NullReferenceException する。
    /// (FormMain_Load 内の生成時と同じ規則で注入する)
    /// </summary>
    private static void InjectFormMain(Form form, FormMain main)
    {
        if (main == null) return;
        switch (form)
        {
            case FormProperty f: f.formMain = main; break;
            case FormAutoProcedure f: f.formMain = main; break;
            case FormDrawRing f: f.formMain = main; break;
            case FormCalibrateIntensity f: f.formMain = main; break;
            case FormSequentialImage f: f.formMain = main; break;
            case FormFindParameter f: f.formMain = main; break;
            case FormSaveImage f: f.FormMain = main; break;
            case FormParameterOption f: f.FormMain = main; break;
            case FormFindParameterBruteForce f: f.FormMain = main; break;
            case FormFindParameterOption1 f: f.FormMain = main; break;
            case FormCrystal f: if (main.FormFindParameter != null) f.formFindParameter = main.FormFindParameter; break;
        }
    }

    /// <summary>
    /// 1 つの Form を画面内に最前面表示して撮影する。
    /// Show → 最前面化 → 描画待ち → 代表状態準備 → 再描画待ち の後、ウィンドウ全体を CopyFromScreen で撮り、
    /// 続けて Capture=true のコントロール/メニュー単位クロップを撮る。closeAfterCapture=false は後続フォームの注入元 FormMain を保持するための例外。
    /// </summary>
    private static void CaptureForm(Form form, string name, string outDir, Action<string> trace, bool closeAfterCapture = true)
    {
        form.StartPosition = FormStartPosition.Manual;
        form.ShowInTaskbar = false;
        form.Location = new Point(0, 0); // CopyFromScreen で実描画を撮るため画面内に表示する
        // Show() で Visible=true にしないと子コントロールが描画されない。
        // Load 等の例外は ThreadException ハンドラへ流れるためモーダル化せず、ハングしない。
        try { form.Show(); }
        catch (Exception ex) { trace($"{name}\tWARN\tShow: {ex.GetType().Name}: {ex.Message}"); }

        BringToFront(form);
        Settle(form, FirstPaintSettleMs, trace);
        PrepareSpecialCaptureState(form, trace); // FormMain は代表画像読込+スプラッシュ非表示、FormParameterOption は全チェック
        Settle(form, PrepareSettleMs, trace);

        // prepare 中に DoEvents で他アプリ (IDE 等) が前面を奪い、CopyFromScreen が別ウィンドウを撮ってしまうことがある。撮影直前に再度最前面化する。
        BringToFront(form);
        Settle(form, TabSwitchSettleMs, trace);

        var bounds = GetWindowVisualBounds(form); // タイトルバー等の非クライアント領域も含むウィンドウ全体 (影は除く)
        var bmp = CaptureScreen(bounds, form, trace, name, retryIfSolid: true);
        var captured = bmp != null;
        if (captured)
            using (bmp) bmp.Save(Path.Combine(outDir, name + ".png"), ImageFormat.Png);
        else
            trace($"{name}\tWARN\tfull-form capture failed (RDP screen hidden/minimized?)"); // 撮れなくても次のフォームへ進む
        var cropCount = CaptureControlCrops(form, name, outDir, trace); // Capture=true のコントロール単位クロップ
        var tabCount = CaptureAllTabPages(form, name, outDir, trace); // 260601Cl: 全 TabPage を自動でタブ単位クロップ (マニュアル用の粒度確保)
        var menuCount = CaptureToolStripItemCrops(form, name, outDir, trace); // Capture=true の ToolStripItem (メニュー展開) クロップ
        trace($"{name}\t{(captured ? "OK" : "PARTIAL")}\t{bounds.Width}x{bounds.Height}\tCrops={cropCount}\tTabs={tabCount}\tMenus={menuCount}");

        if (closeAfterCapture)
        {
            form.TopMost = false; // 後続フォームの最前面化を妨げないよう閉じる前に解除
            form.Close();
        }
    }

    /// <summary>CopyFromScreen の前に対象フォームを通常表示・最前面・アクティブ化する。</summary>
    private static void BringToFront(Form form)
    {
        try
        {
            if (form.WindowState != FormWindowState.Normal)
                form.WindowState = FormWindowState.Normal;
            form.TopMost = true; // 無人実行中に他ウィンドウが被って映り込むのを防ぐ
            form.BringToFront();
            form.Activate();
            if (form.IsHandleCreated)
                SetForegroundWindow(form.Handle); // RDP でフォーカスが他へ移っても撮影対象を前面へ取り戻す
        }
        catch { /* 表示状態変更時の例外は無視 (撮影は後段で最善努力) */ }
    }

    /// <summary>
    /// 指定ミリ秒のあいだ DoEvents を回して描画を画面へ反映させる。
    /// --capture は Application.Run を回さないため、CopyFromScreen の前にこの明示的な描画待ちが要る。
    /// </summary>
    private static void Settle(Form form, int ms, Action<string> trace)
    {
        try { form.Refresh(); } catch { /* Refresh 時例外は無視 */ }
        var until = Environment.TickCount + Math.Max(ms, 0);
        do
        {
            Application.DoEvents();
            System.Threading.Thread.Sleep(15);
        } while (Environment.TickCount < until);
    }

    private const int CaptureMaxAttempts = 5; // CopyFromScreen 失敗時の最大試行回数

    /// <summary>
    /// 画面上の指定矩形を CopyFromScreen で撮ってビットマップ化する。
    /// RDP セッションが非表示・最小化・フォーカス喪失だと CopyFromScreen は Win32Exception を投げたり全面単色を返したりする。
    /// そこで失敗時は foregroundForm を取り直して待ち、数回まで再試行する。最終的に撮れなければ null を返し、呼び出し側は次へ進む。
    /// retryIfSolid=true (フォーム全体) では全面単色も「実描画が読めていない」とみなして再試行・null 化する。
    /// </summary>
    private static Bitmap CaptureScreen(Rectangle screenRect, Form foregroundForm = null, Action<string> trace = null, string label = null, bool retryIfSolid = false)
    {
        int w = Math.Max(screenRect.Width, 1), h = Math.Max(screenRect.Height, 1);
        for (int attempt = 1; attempt <= CaptureMaxAttempts; attempt++)
        {
            Bitmap bmp = null;
            try
            {
                bmp = new Bitmap(w, h);
                using (var g = Graphics.FromImage(bmp))
                    g.CopyFromScreen(screenRect.Location, Point.Empty, new Size(w, h));

                if (!retryIfSolid || !IsSolidColor(bmp))
                    return bmp; // 成功

                bmp.Dispose(); // 全面単色 = RDP で実描画が読めていない可能性。破棄して再試行。
                trace?.Invoke($"{label}\tWARN\tCopyFromScreen blank attempt {attempt}/{CaptureMaxAttempts}");
            }
            catch (Exception ex)
            {
                bmp?.Dispose();
                trace?.Invoke($"{label}\tWARN\tCopyFromScreen attempt {attempt}/{CaptureMaxAttempts}: {ex.GetType().Name}: {ex.Message}");
            }

            if (attempt == CaptureMaxAttempts)
                break;
            if (foregroundForm != null)
                BringToFront(foregroundForm); // RDP の一時的なフォーカス喪失対策にフォアグラウンドを取り直す
            System.Threading.Thread.Sleep(400 * attempt); // 線形バックオフ
            Application.DoEvents();
        }
        return null;
    }

    [System.Runtime.InteropServices.StructLayout(System.Runtime.InteropServices.LayoutKind.Sequential)]
    private struct RECT { public int Left, Top, Right, Bottom; }

    [System.Runtime.InteropServices.DllImport("dwmapi.dll")]
    private static extern int DwmGetWindowAttribute(IntPtr hwnd, int attr, out RECT rect, int size);

    [System.Runtime.InteropServices.DllImport("user32.dll")]
    private static extern bool SetForegroundWindow(IntPtr hWnd); // CopyFromScreen 前に対象ウィンドウを確実に前面へ

    private const int DWMWA_EXTENDED_FRAME_BOUNDS = 9;

    /// <summary>
    /// CopyFromScreen で撮るウィンドウ全体の矩形を求める。
    /// WinForms の Control.Bounds は Win10/11 の不可視リサイズ枠を含むため、そのまま使うと下端などに背後のデスクトップが写り込む。
    /// DWM の実視覚矩形 (DWMWA_EXTENDED_FRAME_BOUNDS、影は除く) が取れればそれを使い、失敗時のみ Bounds に戻す。
    /// </summary>
    private static Rectangle GetWindowVisualBounds(Form form)
    {
        try
        {
            if (form.IsHandleCreated
                && DwmGetWindowAttribute(form.Handle, DWMWA_EXTENDED_FRAME_BOUNDS, out var r, System.Runtime.InteropServices.Marshal.SizeOf<RECT>()) == 0
                && r.Right > r.Left && r.Bottom > r.Top)
                return new Rectangle(r.Left, r.Top, r.Right - r.Left, r.Bottom - r.Top);
        }
        catch { /* P/Invoke 失敗時は Bounds にフォールバック */ }
        return form.Bounds;
    }

    /// <summary>コントロールの実際の左上スクリーン座標を求める (FormCaptureGUI と同一規則)。</summary>
    private static Point GetScreenLocation(Control control)
        => control is Form ? control.Bounds.Location
         : control.Parent != null ? control.Parent.PointToScreen(control.Location)
         : control.PointToScreen(Point.Empty);

    /// <summary>
    /// Designer で <c>Capture=true</c> を付けたコントロール単位のクロップを、対話 UI を出さずに生成する。
    /// 各対象を CopyFromScreen で個別に撮る (FormCaptureGUI と同方式・同命名規則)。
    /// Capture=true 判定だけ共有ライブラリの <see cref="Crystallography.Controls.CaptureExtender.IsCaptureEnabled"/> に依存する。
    /// </summary>
    /// <returns>保存できたクロップ数。</returns>
    private static int CaptureControlCrops(Form form, string name, string outDir, Action<string> trace)
    {
        var count = 0;
        foreach (var control in EnumerateControls(form))
        {
            if (control is Form || string.IsNullOrEmpty(control.Name) || control.IsDisposed || control.Width <= 0 || control.Height <= 0)
                continue;
            if (!Crystallography.Controls.CaptureExtender.IsCaptureEnabled(control))
                continue;

            try
            {
                // タブを選択し直したときだけ再描画を待つ (毎回の長い待機を避ける)。
                if (EnsureAncestorTabsSelected(control))
                    Settle(form, TabSwitchSettleMs, trace);

                Bitmap crop;
                if (!IsEffectivelyVisible(form, control))
                {
                    // 既定で Visible=false の Capture=true コントロールは、一時的に可視化・最前面化して単体で撮る。
                    crop = RenderHiddenControl(form, control, trace);
                    if (crop == null)
                        continue;
                }
                else
                {
                    // TabPage は親 TabControl 全体 (タブ見出し込み) を撮る (FormCaptureGUI と同じ見た目)。
                    var region = control is TabPage tabPage && tabPage.Parent is TabControl tabControl ? (Control)tabControl : control;
                    region.Refresh();
                    Settle(form, TabSwitchSettleMs, trace); // Refresh + DoEvents ループ (二重バッファ領域が単色で撮れるのを防ぐ)
                    crop = CaptureScreen(new Rectangle(GetScreenLocation(region), region.Size), form, trace, $"{name}.{control.Name}", retryIfSolid: true);
                    if (crop == null)
                        continue; // RDP 画面が一時的に取得不能 or 何度撮っても単色なら、このクロップは諦めて次へ
                }

                using (crop)
                {
                    if (IsSolidColor(crop))
                        continue; // Visible=false のパネル等で単色になったクロップは保存しない

                    var fileName = SanitizeFileName(BuildCapturePath(form, control)) + ".png";
                    crop.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
                    count++;
                }
            }
            catch (Exception ex)
            {
                // 1 コントロールの失敗で残りのクロップを諦めない (GuiCapture 全体の「可能な限り次へ進む」方針)。
                trace($"{name}\tWARN\tcrop {control.Name}: {ex.GetType().Name}: {ex.Message}");
            }
        }
        return count;
    }

    /// <summary>
    /// 260601Cl 追加: フォーム内の全 TabControl について、各 TabPage を順に選択して TabControl 全体 (タブ見出し込み) を撮る。
    /// Capture=true の付与を待たずにタブ単位のクロップを得るための拡張 (マニュアルの Property タブ等で粒度を確保)。
    /// 命名は Capture=true クロップと同じ規則 (BuildCapturePath) なので、本文の参照先と一致する。
    /// </summary>
    /// <returns>保存できたタブクロップ数。</returns>
    private static int CaptureAllTabPages(Form form, string name, string outDir, Action<string> trace)
    {
        var count = 0;
        foreach (var tabControl in EnumerateControls(form).OfType<TabControl>())
        {
            if (tabControl.IsDisposed || string.IsNullOrEmpty(tabControl.Name) || tabControl.Width <= 0 || tabControl.Height <= 0)
                continue;
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                if (string.IsNullOrEmpty(tabPage.Name))
                    continue;
                try
                {
                    EnsureAncestorTabsSelected(tabPage); // この TabPage と祖先タブをすべて選択・可視化する
                    if (!IsEffectivelyVisible(form, tabControl))
                        continue; // 親が非表示で出せないタブは諦める
                    tabControl.BringToFront();
                    Settle(form, TabSwitchSettleMs, trace);

                    var crop = CaptureScreen(new Rectangle(GetScreenLocation(tabControl), tabControl.Size), form, trace, $"{name}.{tabPage.Name}", retryIfSolid: true);
                    if (crop == null)
                        continue;
                    using (crop)
                    {
                        if (IsSolidColor(crop))
                            continue;
                        var fileName = SanitizeFileName(BuildCapturePath(form, tabPage)) + ".png";
                        crop.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
                        count++;
                    }
                }
                catch (Exception ex)
                {
                    trace($"{name}\tWARN\ttab {tabPage.Name}: {ex.GetType().Name}: {ex.Message}");
                }
            }
        }
        return count;
    }

    /// <summary>
    /// Designer で <c>Capture=true</c> を付けた ToolStripItem (メニュー項目等) のドロップダウンを非対話で撮る。
    /// 祖先含めて ShowDropDown し、開いた DropDown / ContextMenuStrip / Owner ToolStrip を CopyFromScreen する (FormCaptureGUI と同方式・同命名規則)。
    /// </summary>
    /// <returns>保存できたメニュークロップ数。</returns>
    private static int CaptureToolStripItemCrops(Form form, string name, string outDir, Action<string> trace)
    {
        var count = 0;
        foreach (var item in EnumerateToolStripItems(form))
        {
            if (string.IsNullOrEmpty(item.Name) || !Crystallography.Controls.CaptureExtender.IsCaptureEnabled(item))
                continue;

            try
            {
                var host = EnsureToolStripCaptureHostVisible(item);
                if (host == null || host.IsDisposed || host.Width <= 0 || host.Height <= 0)
                    continue;

                host.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(150); // ドロップダウンが画面へ出るまで待つ

                var crop = CaptureScreen(new Rectangle(host.PointToScreen(Point.Empty), host.Size), form, trace, $"{name}.{item.Name}");
                if (crop != null)
                    using (crop)
                    {
                        if (!IsSolidColor(crop))
                        {
                            var fileName = SanitizeFileName(BuildToolStripItemCapturePath(form, item)) + ".png";
                            crop.Save(Path.Combine(outDir, fileName), ImageFormat.Png);
                            count++;
                        }
                    }
            }
            catch (Exception ex)
            {
                trace($"{name}\tWARN\tmenu-crop {item.Name}: {ex.GetType().Name}: {ex.Message}");
            }
            finally
            {
                try { CloseToolStripDropDowns(item); } catch { /* ドロップダウンのクローズ失敗は無視 */ }
            }
        }
        return count;
    }

    /// <summary>フォーム内の全 ToolStripItem を列挙する (Controls 配下の ToolStrip + designer field の ContextMenuStrip 等。ドロップダウン項目も再帰)。</summary>
    private static IEnumerable<ToolStripItem> EnumerateToolStripItems(Form form)
    {
        var toolStrips = new HashSet<ToolStrip>();
        foreach (var toolStrip in EnumerateControls(form).OfType<ToolStrip>())
            toolStrips.Add(toolStrip);
        // Controls 配下にない ToolStrip (ContextMenuStrip 等) を designer field から拾う
        for (var type = form.GetType(); type != null; type = type.BaseType)
            foreach (var field in type.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.DeclaredOnly))
                if (typeof(ToolStrip).IsAssignableFrom(field.FieldType) && field.GetValue(form) is ToolStrip ownedToolStrip)
                    toolStrips.Add(ownedToolStrip);

        var visited = new HashSet<ToolStripItem>();
        foreach (var toolStrip in toolStrips)
            foreach (var item in EnumerateToolStripItems(toolStrip.Items, visited))
                yield return item;
    }

    private static IEnumerable<ToolStripItem> EnumerateToolStripItems(ToolStripItemCollection items, HashSet<ToolStripItem> visited)
    {
        foreach (ToolStripItem item in items)
        {
            if (!visited.Add(item)) continue;
            yield return item;
            if (item is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems)
                foreach (var child in EnumerateToolStripItems(dropDownItem.DropDownItems, visited))
                    yield return child;
        }
    }

    /// <summary>対象項目を撮るためのホスト (開いた DropDown / ContextMenuStrip / Owner ToolStrip) を可視化して返す (FormCaptureGUI と同方式)。</summary>
    private static ToolStrip EnsureToolStripCaptureHostVisible(ToolStripItem item)
    {
        EnsureAncestorDropDownsVisible(item);

        if (item is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems)
        {
            if (!dropDownItem.DropDown.Visible)
            {
                dropDownItem.ShowDropDown(); // File のような親メニュー項目はドロップダウン全体を開いてから撮る
                dropDownItem.DropDown.Refresh();
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            return dropDownItem.DropDown;
        }

        if (item.Owner is ContextMenuStrip contextMenuStrip)
        {
            if (!contextMenuStrip.Visible && contextMenuStrip.SourceControl != null)
            {
                contextMenuStrip.Show(contextMenuStrip.SourceControl, new Point(0, contextMenuStrip.SourceControl.Height));
                Application.DoEvents();
                System.Threading.Thread.Sleep(200);
            }
            return contextMenuStrip;
        }

        return item.Owner is ToolStripDropDown toolStripDropDown ? toolStripDropDown : item.Owner;
    }

    /// <summary>対象項目の祖先ドロップダウンを順に開く (ネストしたサブメニュー対応)。</summary>
    private static void EnsureAncestorDropDownsVisible(ToolStripItem item)
    {
        if (item.OwnerItem is not ToolStripDropDownItem ownerItem) return;
        EnsureAncestorDropDownsVisible(ownerItem);
        if (!ownerItem.DropDown.Visible)
        {
            ownerItem.ShowDropDown();
            ownerItem.DropDown.Refresh();
            Application.DoEvents();
            System.Threading.Thread.Sleep(200);
        }
    }

    /// <summary>撮影のために開いたドロップダウンを子→親の順に閉じる (後続の撮影を妨げないため)。</summary>
    private static void CloseToolStripDropDowns(ToolStripItem item)
    {
        for (var current = item; current != null; current = current.OwnerItem)
            if (current is ToolStripDropDownItem dropDownItem && dropDownItem.HasDropDownItems && dropDownItem.DropDown.Visible)
                dropDownItem.HideDropDown();
        Application.DoEvents();
    }

    /// <summary>
    /// ToolStripItem のキャプチャ用パス (= クロップのファイル名 stem)。owner ToolStrip までの Control パス
    /// (BuildCapturePath) に、項目の OwnerItem 連鎖の名前を "." 連結する。FormCaptureGUI の対話キャプチャと同じ stem になるようにする。
    /// </summary>
    private static string BuildToolStripItemCapturePath(Form form, ToolStripItem item)
    {
        var segments = new List<string>();
        for (var current = item; current != null; current = current.OwnerItem)
            segments.Add(string.IsNullOrEmpty(current.Name) ? current.GetType().Name : current.Name);
        segments.Reverse();

        var top = item;
        while (top.OwnerItem != null)
            top = top.OwnerItem;
        var prefix = top.Owner != null ? BuildCapturePath(form, top.Owner) : form.Name;
        return prefix + "." + string.Join(".", segments);
    }

    /// <summary>
    /// コントロールの祖先 TabPage を順に選択し、クロップ時に可視化する。
    /// いずれかのタブ選択を実際に変更したら true (呼び出し側が再描画待ちを入れるため)。
    /// </summary>
    private static bool EnsureAncestorTabsSelected(Control control)
    {
        var changed = false;
        for (var c = control; c != null; c = c.Parent)
        {
            if (c is TabPage tabPage && tabPage.Parent is TabControl tabControl)
            {
                if (tabControl.SelectedTab != tabPage)
                {
                    tabControl.SelectedTab = tabPage;
                    changed = true;
                }
                tabControl.BringToFront(); // 重なる兄弟コントロールより前面へ
                tabControl.Refresh();
            }
        }
        return changed;
    }

    /// <summary>control から form まで全て Visible なら true。途中に Visible=false があれば false。</summary>
    private static bool IsEffectivelyVisible(Form form, Control control)
    {
        for (var c = control; c != null && !ReferenceEquals(c, form); c = c.Parent)
            if (!c.Visible)
                return false;
        return true;
    }

    /// <summary>
    /// 既定で非表示の Capture=true コントロールを撮るため、自身と非表示の祖先を一時的に Visible=true・最前面にして
    /// CopyFromScreen し、撮影後に必ず元の可視状態へ戻す (後続クロップに影響させない)。
    /// </summary>
    private static Bitmap RenderHiddenControl(Form form, Control control, Action<string> trace)
    {
        var toggled = new List<Control>();
        for (var c = control; c != null && c is not Form; c = c.Parent)
            if (!c.Visible) { c.Visible = true; toggled.Add(c); }
        try
        {
            control.BringToFront();
            control.PerformLayout();
            Settle(form, TabSwitchSettleMs, trace);
            return CaptureScreen(new Rectangle(GetScreenLocation(control), control.Size), form, trace, control.Name);
        }
        finally
        {
            for (var i = toggled.Count - 1; i >= 0; i--) // 逆順 (子→親) で元の非表示へ戻す
                toggled[i].Visible = false;
            Application.DoEvents();
        }
    }

    /// <summary>
    /// コントロールのキャプチャ用パス (= クロップのファイル名 stem) を組み立てる。
    /// form.Name を起点に名前付き祖先の Name を "." で連結する。SplitContainer の SplitterPanel、
    /// ToolStripContainer の ToolStripPanel / ContentPanel、無名コントロールはパスに含めない (FormCaptureGUI と同じ命名規則)。
    /// </summary>
    private static string BuildCapturePath(Form form, Control control)
    {
        var segments = new List<string>();
        for (var c = control; c != null && !ReferenceEquals(c, form); c = c.Parent)
        {
            if (string.IsNullOrEmpty(c.Name) || c is SplitterPanel || c is ToolStripPanel || c is ToolStripContentPanel)
                continue; // SplitContainer/ToolStripContainer の入れ物パネルと無名コントロールはパスに出さない
            segments.Add(c.Name);
        }
        segments.Add(form.Name);
        segments.Reverse();
        return string.Join(".", segments);
    }

    /// <summary>ファイル名に使えない文字を '_' へ置換する (FormCaptureGUI と同一規則)。</summary>
    private static string SanitizeFileName(string name)
    {
        foreach (var ch in Path.GetInvalidFileNameChars())
            name = name.Replace(ch, '_');
        return name;
    }

    /// <summary>
    /// クロップ内側 (上下左右 5px 除外) が一様色なら true。
    /// Visible=false のパネル等で単色になったクロップを検出し、無意味なファイルの保存を防ぐ。
    /// </summary>
    private static bool IsSolidColor(Bitmap bmp)
    {
        const int margin = 5;
        int x0 = margin, y0 = margin, x1 = bmp.Width - margin, y1 = bmp.Height - margin;
        if (x1 <= x0 || y1 <= y0)
            return true; // margin で内側が残らない極小クロップは単色扱い

        var data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        try
        {
            var row = new int[bmp.Width];
            System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y0 * data.Stride, row, 0, bmp.Width);
            int first = row[x0];
            for (int y = y0; y < y1; y++)
            {
                System.Runtime.InteropServices.Marshal.Copy(data.Scan0 + y * data.Stride, row, 0, bmp.Width);
                for (int x = x0; x < x1; x++)
                    if (row[x] != first)
                        return false;
            }
            return true;
        }
        finally
        {
            bmp.UnlockBits(data);
        }
    }

    /// <summary>
    /// フォームを Show しただけではマニュアル用の代表状態にならない画面を、撮影直前に整える。
    /// FormMain は代表的な回折画像を読み込みスプラッシュを隠す。FormParameterOption は全チェックを入れる。
    /// </summary>
    private static void PrepareSpecialCaptureState(Form form, Action<string> trace)
    {
        try
        {
            switch (form)
            {
                case FormMain mainForm:
                    var loaded = mainForm.PrepareCaptureState();
                    trace($"{form.GetType().Name}\tINFO\tprepared FormMain (sample image {(loaded ? "loaded" : "not found")})");
                    break;
                case FormParameterOption parameterOption:
                    parameterOption.AllCheck(); // 全項目チェック済みの代表状態にする
                    Application.DoEvents();
                    trace($"{form.GetType().Name}\tINFO\tprepared parameter option (all checked)");
                    break;
            }
        }
        catch (Exception ex)
        {
            trace($"{form.GetType().Name}\tWARN\tPrepareCapture: {ex.GetType().Name}: {ex.Message}");
        }
    }

    /// <summary>
    /// マクロエディタ (Crystallography.Controls.FormMacro) を「サンプルマクロ表示」状態にする。
    /// capture 責務をこちらに集約する方針 (別リポ Crystallography.Controls は無改変) のため、private な checkBoxSamples を
    /// reflection で取得して Checked=true にする。失敗時はユーザー保存マクロのまま撮る (最善努力)。
    /// </summary>
    private static void TryShowMacroSamples(Form macroForm, Action<string> trace)
    {
        try
        {
            var field = macroForm.GetType().GetField("checkBoxSamples",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Public);
            if (field?.GetValue(macroForm) is CheckBox cb && cb.Visible && !cb.Checked)
                cb.Checked = true; // CheckedChanged が走り、サンプルマクロがエディタに表示される
        }
        catch (Exception ex)
        {
            trace($"{macroForm.Name}\tWARN\tmacro samples toggle: {ex.GetType().Name}: {ex.Message}");
        }
    }

    /// <summary>
    /// フォーム配下の全コントロールを深さ優先で列挙する。
    /// Capture=true のコントロールは Panel / SplitContainer / TabPage などの奥に入っているため、Controls 直下だけでは拾えない。
    /// </summary>
    private static IEnumerable<Control> EnumerateControls(Control root)
    {
        yield return root;

        foreach (Control child in root.Controls)
        {
            foreach (var descendant in EnumerateControls(child))
                yield return descendant;
        }
    }
}
