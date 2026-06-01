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
                // args[1] が en/ja なら「カルチャのみ指定 (出力先は既定)」、それ以外なら出力先ディレクトリとみなす。
                if (args[1] is "en" or "ja") captureCulture = args[1];
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
