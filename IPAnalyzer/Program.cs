using System;
using System.Windows.Forms;

namespace IPAnalyzer
{
    static class Program
    {
        // 260601Cl 追加: GUI スクショ一括取得モード (--capture) の起動引数。ReciPro と同じ仕組み。
        private const string CaptureArg = "--capture";

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        // 260601Cl 旧シグネチャ: static void Main()  (--capture 対応のため string[] args を追加)
        [STAThread]
        static void Main(string[] args)
        {
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
            if (captureCulture != null)
            {
                var ci = new System.Globalization.CultureInfo(captureCulture);
                System.Threading.Thread.CurrentThread.CurrentUICulture = ci;
                System.Globalization.CultureInfo.DefaultThreadCurrentUICulture = ci;
                GuiCapture.ForcedUICulture = ci;
            }

            Application.SetHighDpiMode(HighDpiMode.DpiUnawareGdiScaled);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // 260625Cl 追加: 言語別 UI フォント (Designer 未指定コントロール用のデフォルト)。ReciPro/Program.cs と統一。
            // Designer/resx で明示指定されたコントロールには影響しない。--capture でカルチャを強制した場合は上で確定済みのため
            // その言語のフォントになる (通常起動では FormMain ctor のレジストリ復元前=OS 既定カルチャのフォント)。
            Application.SetDefaultFont(Crystallography.Controls.FontHelper.GetUIFont());

            // 260601Cl 追加: --capture なら全フォームを一括撮影して終了する。通常起動 (引数なし) には一切影響しない。
            if (args.Length >= 1 && args[0] == CaptureArg)
            {
                GuiCapture.Run(captureDir);
                Environment.Exit(0);
            }

            Application.Run(new FormMain());
        }
    }
}
