using System;
using System.Windows.Forms;

namespace IPAnalyzer; // 260712Cl ファイルスコープ namespace 化 (Macro.cs/Version.cs と統一、ネスト1段削減)

static class Program
{
    // 260601Cl 追加: GUI スクショ一括取得モード (--capture) の起動引数。ReciPro と同じ仕組み。
    private const string CaptureArg = "--capture";
    // 260820Cl 追加: 多言語化のオーバーフロー診断 / 単一フォーム画面なし撮影の引数 (GuiCaptureHarness 共通。ReciPro/Program.cs と同じ仕様)
    private const string DiagnoseArg = "--diagnose";
    private const string CaptureFormArg = "--capture-form";

    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    // 260601Cl 旧シグネチャ: static void Main()  (--capture 対応のため string[] args を追加)
    [STAThread]
    static void Main(string[] args)
    {
        // 260626Cl 追加 (多言語化 Phase 2c): Localizable=false フォームの Designer 直書きラベルの訳テーブルを、
        //   フォーム生成より前に共有 Crystallography.Localization の中央レジストリへ app-local provider として登録する。
        //   FormBase.OnLoad の CodeLocalizer.Apply が FullName キー("IPAnalyzer.<Form>")で引き OnLoad で差し替える。
        IPAnalyzerLocalizationData.Register();

        // 260601Cl 追加: --capture の言語指定を FormMain 構築より前に確定させる (各フォームの resx ローカライズが
        // CurrentUICulture を参照するため)。ReciPro/Program.cs と同じ引数仕様。
        //   IPAnalyzer.exe --capture [出力ディレクトリ] [カルチャ(en/ja)]
        //   IPAnalyzer.exe --capture [カルチャ(en/ja)]                   (出力先省略=既定 docs/src/assets/cap-*-auto)
        string captureDir = null, captureCulture = null;
        if (args.Length >= 2 && args[0] == CaptureArg)
        {
            // args[1] が対応カルチャ名なら「カルチャのみ指定 (出力先は既定)」、それ以外なら出力先ディレクトリとみなす。
            // 260625Cl 変更: en/ja 固定判定から SupportedCultures.All 駆動へ (Phase 0。将来 --capture <dir> de 等を通すため。ReciPro/Program.cs と統一)。
            // 旧: if (args[1] is "en" or "ja") captureCulture = args[1];
            if (Array.Exists(Crystallography.SupportedCultures.All, c => string.Equals(c.Name, args[1], StringComparison.OrdinalIgnoreCase)))
                captureCulture = args[1];
            else { captureDir = args[1]; captureCulture = args.Length >= 3 ? args[2] : null; }
        }
        //260820Cl 追加: --capture-form <TypeName> <out.png> [カルチャ] のカルチャ指定。--capture と同じくフォント確定前に決める
        if (args.Length >= 4 && args[0] == CaptureFormArg
            && Array.Exists(Crystallography.SupportedCultures.All, c => string.Equals(c.Name, args[3], StringComparison.OrdinalIgnoreCase)))
            captureCulture = args[3];
        if (captureCulture != null)
        {
            var ci = new System.Globalization.CultureInfo(captureCulture);
            System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
            System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = ci;
            GuiCapture.ForcedUICulture = ci;
        }

        // 260820Cl 追加: 多言語化のオーバーフロー診断モード (GuiCaptureHarness.Diagnose)。--capture 同様 SetDefaultFont 前に言語を確定させる。
        //   IPAnalyzer.exe --diagnose [カルチャ] [水増し%]   (水増し% 例 140 = 文字が 40% 伸びたら切れるかを実翻訳無しで先出し)
        bool doDiagnose = false; double diagnoseInflate = 1.0;
        if (args.Length >= 1 && args[0] == DiagnoseArg)
        {
            doDiagnose = true;
            string diagnoseCulture = null;
            if (args.Length >= 2 && Array.Exists(Crystallography.SupportedCultures.All, c => string.Equals(c.Name, args[1], StringComparison.OrdinalIgnoreCase)))
                diagnoseCulture = args[1];
            var pctArg = diagnoseCulture != null ? (args.Length >= 3 ? args[2] : null) : (args.Length >= 2 ? args[1] : null);
            if (int.TryParse(pctArg, out var pct) && pct > 0) diagnoseInflate = pct / 100.0;
            if (diagnoseCulture != null)
            {
                var ci = new System.Globalization.CultureInfo(diagnoseCulture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = ci;
                GuiCapture.ForcedUICulture = ci;
            }
        }

        Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);

        // 260625Cl 追加: 言語別 UI フォント (Designer 未指定コントロール用のデフォルト)。ReciPro/Program.cs と統一。
        // Designer/resx で明示指定されたコントロールには影響しない。--capture でカルチャを強制した場合は上で確定済みのため
        // その言語のフォントになる (通常起動では FormMain ctor のレジストリ復元前=OS 既定カルチャのフォント)。
        Application.SetDefaultFont(Crystallography.Controls.FontHelper.GetUIFont());

        // 260820Cl 追加: オーバーフロー診断モード本体。通常起動には一切影響しない。
        if (doDiagnose)
        {
            var cult = (GuiCapture.ForcedUICulture ?? System.Threading.Thread.CurrentThread.CurrentUICulture).Name;
            var outFile = System.IO.Path.Combine(System.IO.Path.GetTempPath(), $"ipanalyzer-diagnose-{cult}-x{(int)(diagnoseInflate * 100)}.tsv");
            new GuiCapture().Diagnose(outFile, diagnoseInflate);
            Environment.Exit(0);
        }

        // 260601Cl 追加: --capture なら全フォームを一括撮影して終了する。通常起動 (引数なし) には一切影響しない。
        if (args.Length >= 1 && args[0] == CaptureArg)
        {
            // GuiCapture.Run(captureDir); // 260820Cl 旧 (static)
            new GuiCapture().Run(captureDir); // 260820Cl: GuiCaptureHarness 派生のインスタンスへ
            Environment.Exit(0);
        }

        //260820Cl 追加: 1 フォームだけを DrawToBitmap で撮る headless モード (GuiCaptureHarness.CaptureSingleForm)。
        //  IPAnalyzer.exe --capture-form <FormTypeName> <出力png> [カルチャ]
        if (args.Length >= 3 && args[0] == CaptureFormArg)
        {
            new GuiCapture().CaptureSingleForm(args[1], args[2]);
            Environment.Exit(0);
        }

        Application.Run(new FormMain());
    }
}
