using Crystallography;
using Crystallography.Controls;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace IPAnalyzer;

// 260414Cl FormMain から Macro クラスを別ファイルへ分離。
// PDIndexer の Macro.cs と同様にトップレベルクラスとして定義し、
// 必要な FormMain 側メンバーは public プロパティ／メソッドとして公開する方針。

#region IPAのマクロ操作を提供するクラス
/// <summary>
/// IPAのマクロ操作を提供するサブクラス
/// </summary>
public class Macro : MacroBase
{
    public readonly FormMain main;
    public SequentialClass Sequential;
    public DetectorClass Detector;
    public FileClass File;
    public WaveClass Wave;
    public ProfileClass Profile;
    public ImageClass Image;
    public MaskClass Mask;
    public PDIClass PDI;
    public IntegralPropertyClass IntegralProperty;


    public Macro(FormMain _main) : base(_main, "IPA")
    {
        main = _main;

        Sequential = new SequentialClass(this);
        Detector = new DetectorClass(this);
        File = new FileClass(this);
        Wave = new WaveClass(this);
        Profile = new ProfileClass(this);
        Image = new ImageClass(this);
        Mask = new MaskClass(this);
        PDI = new PDIClass(this);
        IntegralProperty = new IntegralPropertyClass(this);

        // 260414Cl PDIndexer と同方式で [Help] 属性からヘルプ文字列を自動生成する。
        // 以前は各サブクラスのコンストラクタで help.Add を手書きしていたが、
        // 名前変更やシグネチャ変更に追従できず表記ゆれや漏れが発生していた。
        help.AddRange(HelpAttribute.GenerateHelpText(Sequential.GetType(), nameof(Sequential)));
        help.AddRange(HelpAttribute.GenerateHelpText(Detector.GetType(), nameof(Detector)));
        help.AddRange(HelpAttribute.GenerateHelpText(File.GetType(), nameof(File)));
        help.AddRange(HelpAttribute.GenerateHelpText(Wave.GetType(), nameof(Wave)));
        help.AddRange(HelpAttribute.GenerateHelpText(Profile.GetType(), nameof(Profile)));
        help.AddRange(HelpAttribute.GenerateHelpText(Image.GetType(), nameof(Image)));
        help.AddRange(HelpAttribute.GenerateHelpText(Mask.GetType(), nameof(Mask)));
        help.AddRange(HelpAttribute.GenerateHelpText(PDI.GetType(), nameof(PDI)));
        help.AddRange(HelpAttribute.GenerateHelpText(IntegralProperty.GetType(), nameof(IntegralProperty)));
    }

    #region PDIClass

    public class PDIClass : MacroSub
    {
        Macro p;
        public PDIClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        // 260414Cl Debug を field → property 化 ([Help] 属性は Field には適用されないため)
        [Help("True/False. \r\n If true, macro on PDI will be executed with step-by-step.")]
        public bool Debug { get; set; } = false;

        [Help("Set/get timeout second for macro operation. Default value is 30 sec.")]
        public int Timeout { get; set; }

        [Help("Execute a macro code in PDIndexer. \r\n Parameters (obj1, obj2, ...) can be read on PDI as 'Obj[1]', 'Obj[2]', ...", "params object[] obj")]
        public void RunMacro(params object[] obj)
        {
            RunMacro("", obj);
        }

        [Help("Execute a macro code in PDIndexer. \r\n 'name' is the macro name on PDI. \r\n Parameters (obj1, obj2, ...) can be read on PDI as 'Obj[1]', 'Obj[2]', ...", "string name, params object[] obj")]
        public void RunMacroName(string name, params object[] obj)
        {
            //Mutexを作成
            using Mutex mutex = new(false, "PDIndexer");
            try
            {
                //Mutexを取得 最大WaitSeconds秒待つ
                if (mutex.WaitOne(Timeout * 1000, true))
                {
                    mutex.ReleaseMutex();
                    Clipboard.SetDataObject(new MacroTrigger("PDI", Debug, obj, name));
                    Thread.Sleep(500);
                }

                //再びMutexを取得できるまで最大WaitSeconds秒待つ
                if (mutex.WaitOne(Timeout * 1000, true))
                    mutex.ReleaseMutex();
            }
            finally { mutex.Close(); }
        }
    }
    #endregion

    #region ImageClass

    public class ImageClass : MacroSub
    {
        Macro p;
        public ImageClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        // 260414Cl comboBox* 直接アクセスを廃止し FormMain の bool プロパティ経由に変更
        [Help("True/False. \r\n If true, an image is drawn with negative gradient. \r\n Counterpart of 'IPA.Image.PositiveGradient'.")]
        public bool NegativeGradient
        {
            set => Execute(new Action(() => p.main.IsNegativeGradient = value));
            get => Execute(() => p.main.IsNegativeGradient);
        }
        [Help("True/False. \r\n If true, an image is drawn with positive gradient. \r\n Counterpart of 'IPA.Image.NegativeGradient'.")]
        public bool PositiveGradient
        {
            set => Execute(new Action(() => p.main.IsNegativeGradient = !value));
            get => Execute(() => !p.main.IsNegativeGradient);
        }

        [Help("True/False. \r\n If true, an image is drawn with linear-scale. \r\n Counterpart of 'IPA.Image.LogScale'.")]
        public bool LinearScale
        {
            set => Execute(new Action(() => p.main.IsLinearScale = value));
            get => Execute(() => p.main.IsLinearScale);
        }
        [Help("True/False. \r\n If true, an image is drawn with log-scale. \r\n Counterpart of 'IPA.Image.LinearScale'.")]
        public bool LogScale
        {
            set => Execute(new Action(() => p.main.IsLinearScale = !value));
            get => Execute(() => !p.main.IsLinearScale);
        }

        [Help("True/False. \r\n If true, an image is drawn with gray-scale. \r\n Counterpart of 'IPA.Image.ColorScale'.")]
        public bool GrayScale
        {
            set => Execute(new Action(() => p.main.IsGrayScale = value));
            get => Execute(() => p.main.IsGrayScale);
        }
        [Help("True/False. \r\n If true, an image is drawn with color-scale. \r\n Counterpart of 'IPA.Image.GrayScale'.")]
        public bool ColorScale
        {
            set => Execute(new Action(() => p.main.IsGrayScale = !value));
            get => Execute(() => !p.main.IsGrayScale);
        }

        // 260414Cl trackBar 直接アクセスを廃止し FormMain.IntensityDisplayMax/Min を経由
        // setter のクランプ処理は FormMain 側プロパティに移譲
        [Help("Float. \r\n Set/get maximum level of brightness.")]
        public double Maximum
        {
            set => Execute(new Action(() => p.main.IntensityDisplayMax = value));
            get => Execute(() => p.main.IntensityDisplayMax);
        }
        [Help("Float. \r\n Set/get minimum level of brightness.")]
        public double Minimum
        {
            set => Execute(new Action(() => p.main.IntensityDisplayMin = value));
            get => Execute(() => p.main.IntensityDisplayMin);
        }

        // 260414Cl scalablePictureBox 直接アクセスを廃止し FormMain の CanvasZoom / SetCanvasCenter 経由に変更
        [Help("Float. \r\n Set/get magnification of image.")]
        public double CanvasMagnification
        {
            set => Execute(new Action(() => p.main.CanvasZoom = value));
            get => Execute(() => p.main.CanvasZoom);
        }

        [Help("Set canvas center position in pixel unit.", "double x, double y")]
        public void SetCanvasCenter(double x, double y) => Execute(new Action(() => p.main.SetCanvasCenter(x, y)));

        // 260414Cl splitContainer1 直接操作を廃止し FormMain.ResizeCanvas へ委譲
        [Help("Set canvas size (width and height) of picture box in pixel unit.", "int width, int height")]
        public void SetCanvasSize(int width, int height) => Execute(new Action(() => p.main.ResizeCanvas(width, height)));

        [Help("Set canvas area by specifying top/bottom/left/right bounds in pixel unit.", "double top, double bottom, double left, double right")]
        public void SetArea(double top, double bottom, double left, double right) => Execute(new Action(() =>
        {
            int width = (int)(CanvasMagnification * (right - left) + 0.5);
            int height = (int)(CanvasMagnification * (bottom - top) + 0.5);

            if (width < 1 || height < 1) return;

            SetCanvasSize(width, height);
            SetCanvasCenter((left + right) / 2.0, (bottom + top) / 2.0);
        }));

        [Help("Set the canvas area so that the whole image is visible.")]
        public void SetFullArea() => Execute(new Action(() =>
        {
            var width = (int)(CanvasMagnification * p.main.IP.SrcWidth + 0.5);
            var height = (int)(CanvasMagnification * p.main.IP.SrcHeight + 0.5);

            if (width < 1 || height < 1) return;

            SetCanvasSize(width, height);
            SetCanvasCenter(p.main.IP.SrcWidth / 2.0, p.main.IP.SrcHeight / 2.0);
        }));

    }
    #endregion

    #region MaskClass
    public class MaskClass : MacroSub
    {
        Macro p;
        public MaskClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        [Help("Mask spots.")]
        public void MaskSpots() => Execute(new Action(() => p.main.MaskSpots()));
        [Help("Clear the current masks.")]
        public void ClearMask() => Execute(new Action(() => p.main.ClearMask()));
        [Help("Invert the current mask state.")]
        public void InvertMask() => Execute(new Action(() => p.main.InvertMask()));
        [Help("Mask all area.")]
        public void MaskAll() => Execute(new Action(() => p.main.MaskAll()));
        [Help("Mask the top half area.")]
        public void MaskTop() => Execute(new Action(() => p.main.FormProperty.MaskTop()));
        [Help("Mask the bottom half area.")]
        public void MaskBottom() => Execute(new Action(() => p.main.FormProperty.MaskBottom()));
        [Help("Mask the left half area.")]
        public void MaskLeft() => Execute(new Action(() => p.main.FormProperty.MaskLeft()));
        [Help("Mask the right half area.")]
        public void MaskRight() => Execute(new Action(() => p.main.FormProperty.MaskRight()));

        [Help("Integer. \r\n Set/get the take over mask setting. \r\n 0: None, 1: Take over the current mask state, 2: Take over the mask file.")]
        public int TakeOver
        {
            get
            {
                if (p.main.FormProperty.radioButtonTakeoverNothing.Checked)
                    return 0;
                else if (p.main.FormProperty.radioButtonTakeoverMask.Checked)
                    return 1;
                else
                    return 2;
            }
            set
            {

                if (value == 0)
                    Execute(new Action(() => p.main.FormProperty.radioButtonTakeoverNothing.Checked = true));
                else if (value == 1)
                    Execute(new Action(() => p.main.FormProperty.radioButtonTakeoverMask.Checked = true));
                else if (value == 2)
                    Execute(new Action(() => p.main.FormProperty.radioButtonTakeOverMaskfile.Checked = true));

            }
        }

    }
    #endregion

    #region ProfileClass
    public class ProfileClass : MacroSub
    {
        Macro p;
        public ProfileClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        [Help("Integer. \r\n Sets the number of Debye ring to be divided.")]
        public int AzimuthalDivisionNumber
        {
            // 260414Cl toolStripComboBoxAzimuthalDivisionNumber 直接アクセスを廃止
            set => Execute(new Action(() => p.main.AzimuthalDivisionNumber = value));
            get => Execute(() => p.main.AzimuthalDivisionNumber);
        }

        [Help("True/False. \r\n If true, the profile will be processed in azimuthal division mode.")]
        public bool AzimuthalDivision
        {
            // 260414Cl toolStripMenuItemAzimuthalDivisionAnalysis 直接アクセスを廃止
            set => Execute(new Action(() => p.main.AzimuthalDivisionAnalysisEnabled = value));
            get => Execute(() => p.main.AzimuthalDivisionAnalysisEnabled);
        }

        // 260414Cl toolStripMenuItem* 直接アクセスを廃止し FormMain の bool プロパティ経由に変更
        [Help("True/False. \r\n If true, the image will be integrated concentrically (2θ-intensity).")]
        public bool ConcentricIntegration
        {
            set => Execute(new Action(() => p.main.ConcentricIntegrationEnabled = value));
            get => Execute(() => p.main.ConcentricIntegrationEnabled);
        }
        [Help("True/False. \r\n If true, the image will be integrated radially (pizza-cut).")]
        public bool RadialIntegration
        {
            set => Execute(new Action(() => p.main.RadialIntegrationEnabled = value));
            get => Execute(() => p.main.RadialIntegrationEnabled);
        }
        [Help("True/False. \r\n If true, 'Find Center' will be executed before 'Get Profile'.")]
        public bool FindCenterBeforeGetProfile
        {
            // 260414Cl findCenterBeforeGetProfileToolStripMenuItem 直接アクセスを廃止
            set => Execute(new Action(() => p.main.FindCenterBeforeGetProfile = value));
            get => Execute(() => p.main.FindCenterBeforeGetProfile);
        }
        [Help("True/False. \r\n If true, 'Mask Spots' will be executed before 'Get Profile'.")]
        public bool MaskSpotsBeforeGetProfile
        {
            // 260414Cl maskSpotsBeforeGetProfileToolStripMenuItem 直接アクセスを廃止
            set => Execute(new Action(() => p.main.MaskSpotsBeforeGetProfile = value));
            get => Execute(() => p.main.MaskSpotsBeforeGetProfile);
        }
        [Help("True/False. \r\n If true, the profile will be sent to PDIndexer via clipboard.")]
        public bool SendProfileViaClipboard
        {
            set => Execute(new Action(() => p.main.SendProfileToPDIndexerEnabled = value));
            get => Execute(() => p.main.SendProfileToPDIndexerEnabled);
        }
        [Help("True/False. \r\n If true, the profile will be saved after 'Get Profile'.")]
        public bool SaveProfileAfterGetProfile
        {
            set => Execute(new Action(() => p.main.FormProperty.checkBoxSaveFile.Checked = value));
            get => Execute(() => p.main.FormProperty.checkBoxSaveFile.Checked);
        }
        [Help("True/False. \r\n If true, the profile will be saved as PDI format.")]
        public bool SaveProfileAsPDI
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonAsPDIformat.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonAsPDIformat.Checked);
        }
        [Help("True/False. \r\n If true, the profile will be saved as CSV format.")]
        public bool SaveProfileAsCSV
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonAsCSVformat.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonAsCSVformat.Checked);
        }
        [Help("True/False. \r\n If true, the profile will be saved as TSV format.")]
        public bool SaveProfileAsTSV
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonAsTSVformat.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonAsTSVformat.Checked);
        }

        [Help("True/False. \r\n If true, the profile will be saved as GSAS format.")]
        public bool SaveProfileAsGSAS
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonAsGSASformat.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonAsGSASformat.Checked);
        }

        [Help("True/False. \r\n If true, the profiles of sequential image or azimuthal division data will be saved in one file.")]
        public bool SaveProfileInOneFile
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonSaveInOneFile.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonSaveInOneFile.Checked);
        }

        [Help("True/False. \r\n If true, the profiles will be saved in the same directory as the image.")]
        public bool SaveProfileAtImageDirectory
        {
            set => Execute(new Action(() => p.main.FormProperty.radioButtonSaveAtImageDirectory.Checked = value));
            get => Execute(() => p.main.FormProperty.radioButtonSaveAtImageDirectory.Checked);
        }

        [Help("Get profile. \r\n If filename is assigned, the profile will be saved to that file.", "string filename")]
        public void GetProfile(string filename = "") => Execute(new Action(() =>
        {
            if (filename != "")
                SaveProfileAfterGetProfile = true;
            p.main.GetProfile(filename);

            using var mutex = new Mutex(false, "PDIndexer");
            try { mutex.WaitOne(10000, false); mutex.ReleaseMutex(); }
            finally { mutex.Close(); }
        }));
    }
    #endregion

    #region IntegralPropertyClass

    public class IntegralPropertyClass : MacroSub
    {
        Macro p;
        public IntegralPropertyClass(Macro _p)
            : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        // 260414Cl toolStripMenuItem* 直接アクセスを廃止し FormMain の bool プロパティ経由に変更
        [Help("True/False. \r\n If true, the image will be integrated concentrically (2theta-intensity).")]
        public bool ConcentricIntegration
        {
            set => Execute(new Action(() => p.main.ConcentricIntegrationEnabled = value));
            get => Execute(() => p.main.ConcentricIntegrationEnabled);
        }
        [Help("True/False. \r\n If true, the image will be integrated radially (pizza-cut / cake-pattern).")]
        public bool RadialIntegration
        {
            set => Execute(new Action(() => p.main.RadialIntegrationEnabled = value));
            get => Execute(() => p.main.RadialIntegrationEnabled);
        }
        [Help("Float. \r\n Set/get start value for concentric integration mode.")]
        public double ConcentricStart
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStart.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxConcentricStart.Value);
        }
        [Help("Float. \r\n Set/get end value for concentric integration mode.")]
        public double ConcentricEnd
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricEnd.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxConcentricEnd.Value);
        }
        [Help("Float. \r\n Set/get step value for concentric integration mode.")]
        public double ConcentricStep
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStep.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxConcentricStep.Value);
        }

        [Help("Integer. \r\n Set/get a unit of concentric integration mode. \r\n 0: Angle (deg), 1: d-spacing (A), 2: Length (mm).")]
        public int ConcentricUnit
        {
            set
            {
                Execute(new Action(() =>
                {
                    switch (value)
                    {
                        case 1: p.main.FormProperty.radioButtonConcentricDspacing.Checked = true; break;
                        case 2: p.main.FormProperty.radioButtonConcentricLength.Checked = true; break;
                        default: p.main.FormProperty.radioButtonConcentricAngle.Checked = true; break;
                    }
                }));
            }
            get
            {
                return Execute<int>(new Func<int>(() =>
                {
                    int i = 0;
                    if (p.main.FormProperty.radioButtonConcentricDspacing.Checked) i = 1;
                    if (p.main.FormProperty.radioButtonConcentricLength.Checked) i = 2;
                    return i;
                }));
            }
        }
        [Help("Float. \r\n Set/get a donut radius for radial integration mode.")]
        public double RadialRadius
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialRadius.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxRadialRadius.Value);
        }
        [Help("Float. \r\n Set/get a donut width for radial integration mode.")]
        public double RadialWidgh
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialRange.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxRadialRange.Value);
        }
        [Help("Float. \r\n Set/get a sector angle (sweep step) for radial integration mode.")]
        public double RadialStep
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialStep.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxRadialStep.Value);
        }

        [Help("Integer. \r\n Set/get a unit of radial integration mode. \r\n 0: Angle (deg), 1: d-spacing (A).")]
        public int RadialUnit
        {
            set => Execute(new Action(() =>
            {
                switch (value)
                {
                    case 1: p.main.FormProperty.radioButtonRadialDspacing.Checked = true; break;
                    default: p.main.FormProperty.radioButtonRadialAngle.Checked = true; break;
                }
            }));
            get => Execute<int>(new Func<int>(() =>
            {
                int i = 0;
                if (p.main.FormProperty.radioButtonRadialDspacing.Checked) i = 1;
                return i;
            }));
        }
    }

    #endregion

    #region WaveClass

    public class WaveClass : MacroSub
    {
        Macro p;
        public WaveClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        [Help("Set wavelength of incident beam in nm unit.", "double wavelength")]
        public void SetWaveLength(double x) => Execute(new Action(() => p.main.FormProperty.WaveLength = x));

        [Help("Float. \r\n Set/get wavelength of incident beam in nm unit.")]
        public double WaveLength
        {
            set => Execute(new Action(() => p.main.FormProperty.WaveLength = value));
            get => Execute(() => p.main.FormProperty.WaveLength);
        }

        [Help("Integer. \r\n Set/get the wave source. \r\n 0: None, 1: X-ray, 2: Electron, 3: Neutron.")]
        public int WaveSource
        {
            set => Execute(new Action(() =>
            {
                p.main.FormProperty.waveLengthControl.WaveSource = value switch
                {
                    1 => Crystallography.WaveSource.Xray,
                    2 => Crystallography.WaveSource.Electron,
                    3 => Crystallography.WaveSource.Neutron,
                    _ => Crystallography.WaveSource.None,
                };
            }));

            get => Execute<int>(new Func<int>(() =>
                p.main.FormProperty.waveLengthControl.WaveSource switch
                {
                    Crystallography.WaveSource.Xray => 1,
                    Crystallography.WaveSource.Electron => 2,
                    Crystallography.WaveSource.Neutron => 3,
                    _ => 0,
                }
            ));
        }

        [Help("Integer. \r\n Set the X-ray wavelength line (setter only). \r\n 0: Ka, 1: Ka1, 2: Ka2.")]
        public int XrayLine
        {
            set
            {
                switch (value)
                {
                    case 0: p.main.FormProperty.waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka; break;
                    case 1: p.main.FormProperty.waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka1; break;
                    case 2: p.main.FormProperty.waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka2; break;
                    default: break;
                }
            }
        }
    }
    #endregion

    #region FileClass

    public class FileClass : MacroSub
    {
        Macro p;
        public FileClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        [Help("Get a directory path. \r\n Returned string is a full path to the directory. \r\n If filename is omitted, a selection dialog will open.", "string filename")]
        public string GetDirectoryPath(string filename = "") => Execute<string>(new Func<string>(() =>
        {
            var path = "";
            if (filename == "")
            {
                var dlg = new FolderBrowserDialog();
                path = dlg.ShowDialog() == DialogResult.OK ? dlg.SelectedPath : "";
            }
            else
                path = Path.GetDirectoryName(filename);
            return path + "\\";
        }));


        [Help("Get a file name. \r\n Returned string is a full path of the selected file.", "string message")]
        public string GetFileName(string message = "") => Execute<string>(new Func<string>(() =>
        {
            var dlg = new OpenFileDialog() { Title = message };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
        }));


        [Help("Get file names (multi-select). \r\n Returned value is a string array, \r\n each of which is a full path of a selected file.", "string message")]
        public string[] GetFileNames(string message = "") => Execute<string[]>(new Func<string[]>(() =>
        {
            var dlg = new OpenFileDialog { Multiselect = true, Title = message };
            return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : [];
        }));

        [Help("Get all file names in the selected directory (recursive). \r\n Returned value is a string array of full paths.", "string message")]
        public string[] GetAllFileNames(string message = "") => Execute<string[]>(new Func<string[]>(() =>
        {
            var dlg = new FolderBrowserDialog() { Description = message };
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var dir = Path.GetDirectoryName(dlg.SelectedPath);
                return Directory.GetFiles(dir, "*", SearchOption.AllDirectories);
            }
            else
                return [];
        }));

        [Help("Save image file as Tiff format. \r\n If filename is omitted, a selection dialog will open.", "string fileName")]
        public void SaveImageAsTIFF(string fileName = "") => Execute(() => p.main.saveImageAsTiff(fileName));

        [Help("Save image file as PNG format. \r\n If filename is omitted, a selection dialog will open.", "string fileName")]
        public void SaveImageAsPNG(string fileName = "") => Execute(() => p.main.saveImageAsPng(fileName));

        [Help("Save image file as IPA format. \r\n If filename is omitted, a selection dialog will open.", "string fileName")]
        public void SaveImageAsIPA(string fileName = "") => Execute(() => p.main.FormSaveImage.SaveImageAsIPA(fileName));

        [Help("Save image file as CSV format. \r\n If filename is omitted, a selection dialog will open.", "string fileName")]
        public void SaveImageAsCSV(string fileName = "") => Execute(() => p.main.saveImageAsCSV(fileName));

        [Help("Read HDF5 image file. \r\n 'flag' toggles normalization. \r\n If filename is omitted, a selection dialog will open.", "string fileName, bool? flag")]
        public void ReadImageHDF(string _fileName, bool? flag) => Execute(() => p.main.ReadImage(_fileName, flag));

        /// <summary>
        /// Read image file. if filename is omitted, dialog will open.
        /// </summary>
        /// <param name="_fileName"></param>
        [Help("Read image file. \r\n If filename is omitted, a selection dialog will open.", "string fileName, bool? flag")]
        public void ReadImage(string _fileName = "", bool? flag = null) => Execute(new Action(() =>
        {
            // 260414Cl readImageToolStripMenuItem_Click 直接呼出を廃止し OpenImageDialog 経由に
            if (!System.IO.File.Exists(_fileName))
                p.main.OpenImageDialog();
            else
                p.main.ReadImage(_fileName, flag);
        }));

        [Help("Save current image. Legacy alias; defaults to Tiff format.", "string fileName")]
        public void SaveImage(string fileName = "") => Execute(new Action(() => p.main.saveImageAsTiff(fileName)));

        /// <summary>
        /// Read parameter file.
        /// </summary>
        /// <param name="_fileName"></param>
        [Help("Read parameter file. \r\n If filename is omitted or invalid, a selection dialog will open.", "string fileName")]
        public void ReadParameter(string fileName = "") => Execute(new Action(() => p.main.ReadParameter(fileName, true)));

        [Help("Save parameter file. \r\n If filename is omitted or invalid, a selection dialog will open.", "string fileName")]
        public void SaveParameter(string fileName = "") => Execute(new Action(() => p.main.SaveParameter(fileName, true)));

        [Help("Read mask file. \r\n If filename is omitted or invalid, a selection dialog will open.", "string fileName")]
        public void ReadMask(string fileName = "") => Execute(new Action(() => p.main.ReadMask(fileName)));

        [Help("Save mask file. \r\n If filename is omitted or invalid, a selection dialog will open.", "string fileName")]
        public void SaveMask(string fileName = "") => Execute(new Action(() => FormMain.SaveMask(fileName)));



    }
    #endregion

    #region SequentialClass
    public class SequentialClass : MacroSub
    {
        Macro p;
        public SequentialClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }

        [Help("True/False. \r\n If set true, the selected images are targets for 'Get Profile'.")]
        public bool Target_SelectedImages
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileSelectedImages.Checked = value));
            get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileSelectedImages.Checked);
        }

        [Help("True/False. \r\n If set true, all images are targets for 'Get Profile'.")]
        public bool Target_AllImages
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileAllImages.Checked = value));
            get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileAllImages.Checked);
        }

        [Help("True/False. \r\n If set true, the topmost image is the target for 'Get Profile'.")]
        public bool Target_TopmostImage
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileOnlyTopmost.Checked = value));
            get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileOnlyTopmost.Checked);
        }

        [Help("True/False. \r\n Get whether the current file is a sequential image.")]
        public bool SequentialImageMode => Execute(() => p.main.SequentialImageMode);

        [Help("Integer. \r\n Set/get the selected index of the current sequential image.")]
        public int SelectedIndex
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.SelectedIndex = value));
            get => Execute(() => p.main.FormSequentialImage.SelectedIndex);
        }

        [Help("Integer. \r\n Get the number of images.")]
        public int Count => Execute(() => p.main.FormSequentialImage.MaximumNumber);

        [Help("Integer array. \r\n Set/get the selected indices of the current sequential image.")]
        public int[] SelectedIndices
        {
            set { Execute(new Action(() => p.main.FormSequentialImage.SelectedIndices = value)); }
            get => Execute(() => p.main.FormSequentialImage.SelectedIndices);
        }

        [Help("True/False. \r\n Set/get the state of multi-selection mode.")]
        public bool MultiSelection
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.MultiSelection = value));
            get => Execute(() => p.main.FormSequentialImage.MultiSelection);
        }
        [Help("True/False. \r\n Set/get the state of averaging mode.")]
        public bool Averaging
        {
            set => Execute(new Action(() => p.main.FormSequentialImage.AverageMode = value));
            get => Execute(() => p.main.FormSequentialImage.AverageMode);
        }

        /// <summary>
        /// 選択する
        /// </summary>
        /// <param name="n"></param>
        [Help("Set a single selected index (turns off multi-selection).", "int index")]
        public void SelectIndex(int n) => Execute(new Action(() =>
        {
            if (!SequentialImageMode) return;
            MultiSelection = false;
            p.main.FormSequentialImage.SelectedIndex = n;
        }));

        /// <summary>
        /// 選択を追加する
        /// </summary>
        /// <param name="n"></param>
        [Help("Append an index to the current selection.", "int index")]
        public void AppendIndex(int n) => Execute(new Action(() =>
        {
            if (!SequentialImageMode) return;
            if (n >= 0 && n < p.main.FormSequentialImage.MaximumNumber)
            {
                MultiSelection = true;
                p.main.FormSequentialImage.SelectedIndex = n;
            }
        }));
        /// <summary>
        /// 範囲を選択する
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        [Help("Set a contiguous range of selected indices (from start to end, inclusive).", "int start, int end")]
        public void SelectIndices(int start, int end) => Execute(new Action(() =>
        {
            if (!SequentialImageMode) return;
            if (start < end && start >= 0 && end < p.main.FormSequentialImage.MaximumNumber)
            {
                MultiSelection = true;
                List<int> list = [];
                for (int i = start; i <= end; i++)
                    if (!list.Contains(i))
                        list.Add(i);
                p.main.FormSequentialImage.SelectedIndices = [.. list];
                //    SelectedIndex = end;
            }
        }));
        /// <summary>
        /// 範囲を追加する
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        [Help("Append a contiguous range of indices (from start to end, inclusive) to the current selection.", "int start, int end")]
        public void AppendIndices(int start, int end) => Execute(new Action(() =>
        {
            if (!SequentialImageMode) return;
            if (start < end && start >= 0 && end < p.main.FormSequentialImage.MaximumNumber)
            {
                MultiSelection = true;
                List<int> list = [.. p.main.FormSequentialImage.SelectedIndices];
                for (int i = start; i <= end; i++)
                    if (!list.Contains(i))
                        list.Add(i);
                p.main.FormSequentialImage.SelectedIndices = [.. list];
                SelectedIndex = end;
            }
        }));

    }

    #endregion

    #region DetectorClass

    public class DetectorClass : MacroSub
    {
        Macro p;
        public DetectorClass(Macro _p) : base(_p.main)
        {
            p = _p;
            // 260414Cl help.Add 手書き撤去 ([Help] 属性に移行)
        }


        [Help("Set center (direct spot) position in pixel unit.", "double x, double y")]
        public void SetCenter(double x, double y) => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(x, y)));

        [Help("Set camera length in mm unit.", "double length")]
        public void SetCameraLength(double x) => Execute(new Action(() => p.main.FormProperty.CameraLength1 = x));

        [Help("Float. \r\n Set/get X value of center (direct spot) position in pixel unit.")]
        public double CenterX
        {
            set => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(value, p.main.FormProperty.DirectSpotPosition.Y)));
            get => Execute(() => p.main.FormProperty.DirectSpotPosition.X);
        }
        [Help("Float. \r\n Set/get Y value of center (direct spot) position in pixel unit.")]
        public double CenterY
        {
            set => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(p.main.FormProperty.DirectSpotPosition.X, value)));
            get => Execute(() => p.main.FormProperty.DirectSpotPosition.Y);
        }
        [Help("Float. \r\n Set/get camera length in mm unit.")]
        public double CameraLength
        {
            set => Execute(new Action(() => p.main.FormProperty.CameraLength1 = value));
            get => Execute(() => p.main.FormProperty.CameraLength1);
        }
        [Help("Float. \r\n Set/get pixel X size (pixel width) in mm unit.")]
        public double PixelSizeX
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeX.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxPixelSizeX.Value);
        }
        [Help("Float. \r\n Set/get pixel Y size (pixel height) in mm unit.")]
        public double PixelSizeY
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeY.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxPixelSizeY.Value);
        }
        [Help("Float. \r\n Set/get pixel Ksi (skew) value in degree unit.")]
        public double PixelKsi
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelKsi.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxPixelKsi.Value);
        }
        [Help("Float. \r\n Set/get tilt phi value in degree unit.")]
        public double TiltPhi
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxTiltPhi.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxTiltPhi.Value);
        }
        [Help("Float. \r\n Set/get tilt tau value in degree unit.")]
        public double TiltTau
        {
            set => Execute(new Action(() => p.main.FormProperty.numericBoxTiltTau.Value = value));
            get => Execute(() => p.main.FormProperty.numericBoxTiltTau.Value);
        }

    }

}


    #endregion

#endregion
