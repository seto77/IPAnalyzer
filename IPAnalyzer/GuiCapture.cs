using System;
using System.IO;
using System.Windows.Forms;
using Crystallography.Controls;

namespace IPAnalyzer;

/// <summary>
/// 260601Cl 追加: GUI 統一性監査・マニュアル用に IPAnalyzer の全フォームを構築して PNG 一括保存する開発者向けツール。
/// 260820Cl: ReciPro からの移植コピー (788 行。撮影エンジン・クロップ・メニュー展開を丸ごと複製) を廃し、
/// Crystallography.Controls の共通ハーネス <see cref="GuiCaptureHarness"/> の派生へ移行した。ここに残るのは IPAnalyzer 固有部のみ:
/// 子フォームへの formMain 注入・代表状態 (サンプル画像読込 / FormParameterOption 全チェック)・全 TabPage 自動クロップの有効化。
/// これにより ReciPro 側で入った修正 (メニューが閉じて背後が写る対策 260726 / 非表示コントロールの DrawToBitmap 退避 /
/// 文字溢れ報告 / --diagnose / --capture-form) が IPAnalyzer でもそのまま使える。
/// 起動: <c>IPAnalyzer.exe --capture [出力ディレクトリ] [カルチャ]</c> / <c>--diagnose [カルチャ] [水増し%]</c> /
/// <c>--capture-form &lt;Type&gt; &lt;out.png&gt; [カルチャ]</c>。通常起動 (引数なし) では一切実行されない。
/// </summary>
// 旧: internal static class GuiCapture (Run は static。FormMain.cs は GuiCapture.ForcedUICulture / GuiCapture.FindSampleImage を参照)
internal sealed class GuiCapture : GuiCaptureHarness
{
    protected override Type MainFormType => typeof(FormMain);

    /// <summary>260601Cl: 全 TabPage を自動でタブ単位クロップ (マニュアル用の粒度確保)。ハーネスの opt-in 機能を有効化。</summary>
    protected override bool CaptureAllTabPagesEnabled => true;

    /// <summary>
    /// 260601Cl 追加: FormMain の代表状態用サンプル画像を references/ImageExample から探す。
    /// CeO2 (標準校正物質、明瞭なデバイ環) を優先し、無ければ最初の読込可能画像を返す。巨大ファイルは避ける。無ければ null。
    /// FormMain.PrepareCaptureState から呼ばれるため public static のまま残す。
    /// </summary>
    public static string FindSampleImage()
    {
        var root = RepoRoot(); // 260820Cl: ハーネス共通の RepoRoot() (bin → リポルート) へ
        if (root == null) return null;
        var dir = Path.Combine(root.FullName, "references", "ImageExample");
        if (!Directory.Exists(dir)) return null;

        //260712Cl try を列挙ループ全体に広げる。EnumerateFiles は遅延評価で foreach 中に IO 例外が出るため、
        //         旧コード (try が EnumerateFiles 呼び出しのみを囲む) では列挙途中の例外が保護されずフォールバックが機能しなかった。
        string firstReadable = null;
        try
        {
            foreach (var file in Directory.EnumerateFiles(dir, "*.*", SearchOption.AllDirectories))
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
        }
        catch { /* 列挙途中の IO 例外は打ち切り、それまでに見つかった firstReadable を返す */ }
        return firstReadable;
    }

    /// <summary>
    /// 260601Cl 追加: 子フォームへ FormMain (またはその配線済み子) を注入する。
    /// IPAnalyzer の各フォームは formMain/FormMain/formFindParameter を設定せずに Show/Close すると NullReferenceException する。
    /// (FormMain_Load 内の生成時と同じ規則で注入する)
    /// </summary>
    // 旧: private static void InjectFormMain(Form form, FormMain main)
    protected override void WireDependencies(Form form, Form main)
    {
        if (main is not FormMain m) return;
        switch (form)
        {
            case FormProperty f: f.formMain = m; break;
            case FormAutoProcedure f: f.formMain = m; break;
            case FormDrawRing f: f.formMain = m; break;
            case FormCalibrateIntensity f: f.formMain = m; break;
            case FormSequentialImage f: f.formMain = m; break;
            case FormFindParameter f: f.formMain = m; break;
            case FormSaveImage f: f.FormMain = m; break;
            case FormParameterOption f: f.FormMain = m; break;
            case FormFindParameterBruteForce f: f.FormMain = m; break;
            case FormFindParameterOption1 f: f.FormMain = m; break;
            case FormCrystal f: if (m.FormFindParameter != null) f.formFindParameter = m.FormFindParameter; break;
        }
    }

    // マクロエディタ (FormMacro) は引数付き ctor のため reflection 単独生成できない。FormMain が Load で配線済みの
    // インスタンスを保持しているので基底に渡し、FormMain 直後に撮ってもらう (サンプル表示は基底の PrepareCaptureState が行う)。
    protected override FormMacro GetMacroEditor(Form main) => (main as FormMain)?.FormMacro;

    /// <summary>
    /// フォームを Show しただけではマニュアル用の代表状態にならない画面を、撮影直前に整える。
    /// FormMain は代表的な回折画像を読み込みスプラッシュを隠す。FormParameterOption は全チェックを入れる。
    /// FormMacro (Controls 所有) は基底が扱う。
    /// </summary>
    // 旧: private static void PrepareSpecialCaptureState(Form form, Action<string> trace)
    protected override void PrepareCaptureState(Form form, Action<string> trace)
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
                default:
                    base.PrepareCaptureState(form, trace); // 260820Cl: FormMacro 等 Controls 所有フォームは基底が扱う
                    break;
            }
        }
        catch (Exception ex)
        {
            trace($"{form.GetType().Name}\tWARN\tPrepareCapture: {ex.GetType().Name}: {ex.Message}");
        }
    }

    // 260820Cl 削除: 以下は GuiCaptureHarness (Crystallography.Controls) へ集約した (ReciPro 版と同一の複製だった)。
    //   Run / CaptureForm / BringToFront / Settle / CaptureScreen / GetWindowVisualBounds / GetScreenLocation / CaptureControlCrops /
    //   CaptureAllTabPages (→ CaptureAllTabPagesEnabled で有効化) / CaptureToolStripItemCrops / EnumerateToolStripItems /
    //   EnsureToolStripCaptureHostVisible / EnsureAncestorDropDownsVisible / CloseToolStripDropDowns / BuildToolStripItemCapturePath /
    //   EnsureAncestorTabsSelected / IsEffectivelyVisible / RenderHiddenControl / BuildCapturePath / SanitizeFileName / IsSolidColor /
    //   EnumerateControls / DefaultAutoCaptureDir (→ DefaultOutputDir) / RepoRoot / TryShowMacroSamples (→ FormMacro.PrepareCaptureForGuiAudit)
    //   挙動差: 撮影終了時に FormMain を Close() せず Dispose() だけにした (基底の方針。Close は FormClosing → レジストリ書込で
    //   --capture の強制カルチャを普段の UI 言語として焼き付けてしまうため)。
}
