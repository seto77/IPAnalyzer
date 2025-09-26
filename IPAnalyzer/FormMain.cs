#region using
using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Threading;
using Crystallography;
using Crystallography.Controls;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IronPython.Hosting;
using System.Diagnostics;
using System.Net;
using System.Runtime.InteropServices;
using System.Xml;
using Microsoft.Scripting.Utils;
#endregion

namespace IPAnalyzer;

public partial class FormMain : Form
{
    #region DllImport
    [LibraryImport("user32")]
    private static partial short GetAsyncKeyState(int nVirtKey);
    #endregion

    #region プロパティ、フィールド

    public bool IsFlatPanelMode => FormProperty.radioButtonFlatPanel.Checked;

    public PseudoBitmap pseudoBitmap = new();
    public bool SkipDrawing { get; set; } = false;

    public Size SrcImgSize;
    public int ThreadTotal = 16;

    //DiffractionProfile diffractionProfile = new DiffractionProfile();

    public bool IsImageReady = false;

    public Crystallography.Controls.CommonDialog InitialDialog;
    //public FormIntTable FormIntTable;
    public FormAutoProcedure FormAutoProc;
    public FormFindParameter FormFindParameter;
    public FormDrawRing FormDrawRing;
    public FormCalibrateIntensity FormCalibrateIntensity;

    public FormSequentialImage FormSequentialImage;
    public FormParameterOption FormParameterOption;

    public FormFindParameterBruteForce FormFindParameterBruteForce;

    public FormSaveImage FormSaveImage;

    public FormProperty FormProperty;

    public FormMacro FormMacro;

    public Profile oneDimensionalProfile = new();
    public Profile frequencyProfile = new();

    //static Mutex mutexClipboard = new Mutex(false, "ClipboardOperation");

    public bool IsNegativeFilm = false;

    public string UserAppDataPath = new DirectoryInfo(Application.UserAppDataPath).Parent.FullName + @"\";

    /// <summary>
    /// イベントや関数を実行せずに抜けたいときに使用するフラグ
    /// </summary>
    public bool Skip { get; set; } = false;

    /// <summary>
    /// イメージの回転. 0: 0度回転, 1: 90度回転, 2: 180度回転, 3: 270度回転
    /// </summary>
    public int CurrentRotation = 0;

    //private string fileName = "";
    public string FileName { set; get; }
    public string FileNameSub { set; get; } = "";

    public string FilePath { set; get; } = "";

    public bool SequentialImageMode { set => toolStripButtonImageSequence.Enabled = value; get => toolStripButtonImageSequence.Enabled; }

    public float SpotsSize = 64;

    public Bitmap MainBmp, ThumbBmp;//最終画像

    public float SrcImgAspect = 1;
    public float ClientAspect = 1;

    public bool IsMouseRangeMode = false;
    public bool IsRingSelectMode = false;
    public bool IsManualSpotMode = false;
    public Point MouseRangeStartPt, MouseRangeEndPt, MouseSpotsPt;
    public Point TableCenterPt;
    public IntegralProperty IP;

    public PointD selectedSpot = new(double.NaN, double.NaN);

    private IProgress<(long, long, long, string)> ip;//IReport

    //public string ImageFilterString = "FujiBAS2000/2500; R-AXIS4/5; ITEX; Bruker CCD; IP Display; IPAimage; Fuji FDL; Rayonix; Marresearch; Perkin Elmer; ADSC; RadIcon; general image"
    //        + "|*.img;*.stl;*.ccd;*.ipf;*.ipa;*.0???;*.gel;*.osc;*.mar*;*.mccd; *.his; *.h5; *.raw; *.bmp;*.jpg;*.tif";

    double maxIntensity = uint.MinValue;
    double sumOfIntensity = 0;
    double variance = 0;
    #endregion

    #region コンストラクタ、ロード、クローズ
    public FormMain()
    {
        using (var regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\IPAnalyzer"))
        {
            try
            {
                var culture = (string)regKey.GetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
                Thread.CurrentThread.CurrentUICulture = culture.ToLower().StartsWith("ja") ?
                        new System.Globalization.CultureInfo("ja") : new System.Globalization.CultureInfo("en");
            }
            catch { }
        }

        InitializeComponent();
        ip = new Progress<(long, long, long, string)>(o => reportProgress(o));//IReport

        this.SetStyle(ControlStyles.ResizeRedraw, true);
        // ダブルバッファリング
        this.SetStyle(ControlStyles.DoubleBuffer, true);
        this.SetStyle(ControlStyles.UserPaint, true);
        this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
    }

    public static void ResetRegistry()
    {
        try { Registry.CurrentUser.DeleteSubKey("Software\\Crystallography\\IPAnalyzer"); }
        catch { }
    }

    #region レジストリをセーブ
    public void SaveRegistry()
    {
        RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\IPAnalyzer");
        if (regKey == null) return;

        try
        {
            regKey.SetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
            regKey.SetValue("initialDialog.AutomaricallyClose", InitialDialog.AutomaticallyClose);

            //Main関係
            regKey.SetValue("formMainWidth", Width);
            regKey.SetValue("formMainHeight", Height);
            regKey.SetValue("formMainLocationX", Location.X);
            regKey.SetValue("formMainLocationY", Location.Y);

            regKey.SetValue("findCenterBeforeGetProfile", findCenterBeforeGetProfileToolStripMenuItem.Checked);
            regKey.SetValue("maskSpotsBeforeGetProfile", maskSpotsBeforeGetProfileToolStripMenuItem.Checked);

            //FindParameter関係
            regKey.SetValue("formFindParameterWidth", FormFindParameter.Width);
            regKey.SetValue("formFindParameterHeight", FormFindParameter.Height);
            regKey.SetValue("formFindParameterLocationX", FormFindParameter.Location.X);
            regKey.SetValue("formFindParameterLocationY", FormFindParameter.Location.Y);

            //IntTable関係
            //regKey.SetValue("formIntTableWidth", FormIntTable.Width);
            //regKey.SetValue("formIntTableHeight", FormIntTable.Height);
            //regKey.SetValue("formIntTableLocationX", FormIntTable.Location.X);
            //regKey.SetValue("formIntTableLocationY", FormIntTable.Location.Y);
            
            //DrawRingK関係
            regKey.SetValue("formDrawRingWidth", FormDrawRing.Width);
            regKey.SetValue("formDrawRingHeight", FormDrawRing.Height);
            regKey.SetValue("formDrawRingLocationX", FormDrawRing.Location.X);
            regKey.SetValue("formDrawRingLocationY", FormDrawRing.Location.Y);

            //Property関係
            regKey.SetValue("formPropertyLocationX", FormProperty.Location.X);
            regKey.SetValue("formPropertyLocationY", FormProperty.Location.Y);

            regKey.SetValue("textBoxPixelSizeXText", FormProperty.numericBoxPixelSizeX.Text);
            regKey.SetValue("textBoxPixelSizeYText", FormProperty.numericBoxPixelSizeY.Text);
            regKey.SetValue("textBoxPixelKsiText", FormProperty.numericBoxPixelKsi.Text);

            regKey.SetValue("textBoxFilmDistanceText", FormProperty.CameraLength1Text);
            regKey.SetValue("textBoxCenterPositionXText", FormProperty.numericBoxDirectSpotPositionX.Text);
            regKey.SetValue("textBoxCenterPositionYText", FormProperty.numericBoxDirectSpotPositionY.Text);

            //ConcentricかRadialか
            regKey.SetValue("formProperty.radioButtonConcentric.Checked", FormProperty.radioButtonConcentric.Checked);
            regKey.SetValue("formProperty.radioButtonRadial.Checked", FormProperty.radioButtonRadial.Checked);

            //Concentric Mode 関連
            regKey.SetValue("numericUpDownIntensityStartAngleValue", FormProperty.StartAngle);
            regKey.SetValue("numericUpDownIntensityEndAngleValue", FormProperty.EndAngle);
            regKey.SetValue("numericUpDownIntensityStepAngleValue", FormProperty.StepAngle);

            regKey.SetValue("numericUpDownIntensityStartLengthValue", FormProperty.StartLength);
            regKey.SetValue("numericUpDownIntensityEndLengthValue", FormProperty.EndLength);
            regKey.SetValue("numericUpDownIntensityStepLengthValue", FormProperty.StepLength);

            regKey.SetValue("numericUpDownIntensityStartDspacingValue", FormProperty.StartDspacing);
            regKey.SetValue("numericUpDownIntensityEndDspacingValue", FormProperty.EndDspacing);
            regKey.SetValue("numericUpDownIntensityStepDspacingValue", FormProperty.StepDspacing);

            regKey.SetValue("formProperty.SectorRadiusTheta", FormProperty.SectorRadiusTheta);
            regKey.SetValue("formProperty.SectorRadiusThetaRange", FormProperty.SectorRadiusThetaRange);
            regKey.SetValue("formProperty.SectorRadiusD", FormProperty.SectorRadiusD);
            regKey.SetValue("formProperty.SectorRadiusDRange", FormProperty.SectorRadiusDRange);
            regKey.SetValue("formProperty.SectorAngle", FormProperty.SectorAngle);

            regKey.SetValue("radioButtonAngleMode", FormProperty.radioButtonConcentricAngle.Checked);
            //regKey.SetValue("radioButtonLengthMode", radioButtonLengthMode.Checked);
            regKey.SetValue("radioButtonDspacingMode", FormProperty.radioButtonConcentricDspacing.Checked);

            regKey.SetValue("formProperty.radioButtonRadialAngle.Checked", FormProperty.radioButtonRadialAngle.Checked);
            regKey.SetValue("formProperty.radioButtonRadialD.Checked", FormProperty.radioButtonRadialDspacing.Checked);

            regKey.SetValue("formProperty.radioButtonChiClockwise.Checked", FormProperty.radioButtonChiClockwise.Checked);

            regKey.SetValue("formProperty.radioButtonChiRight.Checked", FormProperty.radioButtonChiRight.Checked);
            regKey.SetValue("formProperty.radioButtonChiLeft.Checked", FormProperty.radioButtonChiLeft.Checked);
            regKey.SetValue("formProperty.radioButtonChiTop.Checked", FormProperty.radioButtonChiTop.Checked);
            regKey.SetValue("formProperty.radioButtonChiBottom.Checked", FormProperty.radioButtonChiBottom.Checked);

            regKey.SetValue("textBoxTiltCorrectionPhiText", FormProperty.numericBoxTiltPhi.Text);
            regKey.SetValue("textBoxTiltCorrectionPsiText", FormProperty.numericBoxTiltTau.Text);

            regKey.SetValue("radioButtonRectangleChecked", FormProperty.radioButtonRectangle.Checked);

            regKey.SetValue("numericUpDownRectangleAngleValue", FormProperty.numericUpDownRectangleAngle.Value);
            regKey.SetValue("numericUpDownRectangleBandValue", FormProperty.numericUpDownRectangleBand.Value);
            regKey.SetValue("checkBoxRectangleIsBothSideChecked", FormProperty.checkBoxRectangleIsBothSide.Checked);

            regKey.SetValue("numericUpDownSectorStartAngleValue", FormProperty.numericUpDownSectorStartAngle.Value);
            regKey.SetValue("numericUpDownSectorEndAngleValue", FormProperty.numericUpDownSectorEndAngle.Value);

            regKey.SetValue("textBoxWaveLengthText", FormProperty.WaveLengthText);
            regKey.SetValue("comboBoxRectangleDirectionText", FormProperty.comboBoxRectangleDirection.Text);
            regKey.SetValue("numericUpDownFindSpotsDeviationValue", FormProperty.numericUpDownFindSpotsDeviation.Value);



            regKey.SetValue("toolTipToolStripMenuItem", toolTipToolStripMenuItem.Checked);

            regKey.SetValue("toolStripComboBoxGradient.SelectedIndex", comboBoxGradient.SelectedIndex);
            regKey.SetValue("toolStripComboBoxScale1.SelectedIndex", comboBoxScale1.SelectedIndex);
            regKey.SetValue("toolStripComboBoxScale2.SelectedIndex", comboBoxScale2.SelectedIndex);
            regKey.SetValue("toolStripComboBoxScaleLine.SelectedIndex", comboBoxScaleLine.SelectedIndex);

            regKey.SetValue("initialImageDirectory", initialImageDirectory);
            regKey.SetValue("initialParameterDirectory", initialParameterDirectory);
            regKey.SetValue("initialMaskDirectory", initialMaskDirectory);
            regKey.SetValue("filterIndex", filterIndex);

            //ここからイメージタイプごとのパラメータ書き込み
            for (int i = 0; i < Enum.GetValues(typeof(Ring.ImageTypeEnum)).Length; i++)
            {
                regKey.SetValue("ImageTypeParameters.CenterPosX" + i.ToString(), FormProperty.ImageTypeParameters[i].CenterPosX);
                regKey.SetValue("ImageTypeParameters.CenterPosY" + i.ToString(), FormProperty.ImageTypeParameters[i].CenterPosY);
                regKey.SetValue("ImageTypeParameters.CameraLength" + i.ToString(), FormProperty.ImageTypeParameters[i].CameraLength);
                regKey.SetValue("ImageTypeParameters.PixelSizeX" + i.ToString(), FormProperty.ImageTypeParameters[i].PixelSizeX);
                regKey.SetValue("ImageTypeParameters.PixelSizeY" + i.ToString(), FormProperty.ImageTypeParameters[i].PixelSizeY);
                regKey.SetValue("ImageTypeParameters.PixelKsi" + i.ToString(), FormProperty.ImageTypeParameters[i].PixelKsi);
                regKey.SetValue("ImageTypeParameters.Phi" + i.ToString(), FormProperty.ImageTypeParameters[i].Phi);
                regKey.SetValue("ImageTypeParameters.Tau" + i.ToString(), FormProperty.ImageTypeParameters[i].Tau);

                regKey.SetValue("ImageTypeParameters.WaveSource" + i.ToString(), (int)FormProperty.ImageTypeParameters[i].WaveSource);
                regKey.SetValue("ImageTypeParameters.XrayWaveSourceElementNumber" + i.ToString(), FormProperty.ImageTypeParameters[i].XrayWaveSourceElementNumber);
                regKey.SetValue("ImageTypeParameters.XrayLine" + i.ToString(), (int)FormProperty.ImageTypeParameters[i].XrayLine);
                regKey.SetValue("ImageTypeParameters.ElectronAccVoltage" + i.ToString(), FormProperty.ImageTypeParameters[i].ElectronAccVoltage);
                regKey.SetValue("ImageTypeParameters.WaveLength" + i.ToString(), FormProperty.ImageTypeParameters[i].WaveLength);

                regKey.SetValue("ImageTypeParameters.FlipHorizontally" + i.ToString(), FormProperty.ImageTypeParameters[i].FlipHorizontally);
                regKey.SetValue("ImageTypeParameters.FlipVertically" + i.ToString(), FormProperty.ImageTypeParameters[i].FlipVertically);
                regKey.SetValue("ImageTypeParameters.Rotation" + i.ToString(), FormProperty.ImageTypeParameters[i].Rotation);



                regKey.SetValue("ImageTypeParameters.GandolfiRadius" + i.ToString(), FormProperty.ImageTypeParameters[i].GandolfiRadius);


                regKey.SetValue("ImageTypeParameters.CameraMode" + i.ToString(), FormProperty.ImageTypeParameters[i].CameraMode == IntegralProperty.CameraEnum.FlatPanel ? "FlatPanel" : "Gandolfi");


            }

            //マクロ
            //regKey.DeleteSubKeyTree("Macro", false);
            //regKey.CreateSubKey("Macro");
            //var macro = FormMacro.ZippedMacros;
            //regKey.SetValue("MacroLength", macro.Length);
            //for (int i = 0; i < macro.Length; i++)
            //    regKey.SetValue("Macro" + i.ToString(), macro[i]);
            regKey.SetValue("Macro", FormMacro.ZippedMacros);

            //偏光補正
            regKey.SetValue("FormProperty.checkBoxCorrectPolarization.Checked", FormProperty.checkBoxCorrectPolarization.Checked);

            regKey.Close();
        }

        catch
        {
            regKey.Close();
            Registry.CurrentUser.DeleteSubKey("Software\\Crystallography\\IPAnalyzer", false);
        }
    }
    #endregion

    #region レジストリをロード
    public void LoadRegistry()
    {
        try
        {
            RegistryKey regKey = Registry.CurrentUser.OpenSubKey("Software\\Crystallography\\IPAnalyzer");

            if (regKey == null) return;

            //サイズ、位置関係
            if ((int)regKey.GetValue("formMainLocationX", Location.X) >= 0)
            {
                Width = (int)regKey.GetValue("formMainWidth", Width);
                Height = (int)regKey.GetValue("formMainHeight", Height);
                Location = new Point(
                    (int)regKey.GetValue("formMainLocationX", Location.X),
                    (int)regKey.GetValue("formMainLocationY", Location.Y));

                toolTipToolStripMenuItem.Checked = (string)regKey.GetValue("toolTipToolStripMenuItem", "True") == "True";

                comboBoxGradient.SelectedIndex = (int)regKey.GetValue("toolStripComboBoxGradient.SelectedIndex", 0);
                comboBoxScale1.SelectedIndex = (int)regKey.GetValue("toolStripComboBoxScale1.SelectedIndex", 0);
                comboBoxScale2.SelectedIndex = (int)regKey.GetValue("toolStripComboBoxScale2.SelectedIndex", 0);
                comboBoxScaleLine.SelectedIndex = (int)regKey.GetValue("toolStripComboBoxScaleLine.SelectedIndex", 0);

                initialImageDirectory = (string)regKey.GetValue("initialImageDirectory", "");
                initialParameterDirectory = (string)regKey.GetValue("initialParameterDirectory", "");
                initialMaskDirectory = (string)regKey.GetValue("initialMaskDirectory", "");
                filterIndex = (int)regKey.GetValue("filterIndex", 0);
                
                findCenterBeforeGetProfileToolStripMenuItem.Checked = (string)regKey.GetValue("findCenterBeforeGetProfile", "False") == "True";
                maskSpotsBeforeGetProfileToolStripMenuItem.Checked = (string)regKey.GetValue("maskSpotsBeforeGetProfile", "False") == "True";
            }
            if (InitialDialog != null)
            {
                InitialDialog.Location = new Point(Location.X + Width / 2 - InitialDialog.Width / 2, Location.Y + Height / 2 - InitialDialog.Height / 2);
                InitialDialog.AutomaticallyClose = (string)regKey.GetValue("initialDialog.AutomaricallyClose", "True") == "True";
            }


            if (FormFindParameter != null && (int)regKey.GetValue("formFindParameterLocationY", FormFindParameter.Location.Y) >= 0)
            {
                FormFindParameter.Width = (int)regKey.GetValue("formFindParameterWidth", FormFindParameter.Width);
                FormFindParameter.Height = (int)regKey.GetValue("formFindParameterHeight", FormFindParameter.Height);
                FormFindParameter.Location = new Point(
                    (int)regKey.GetValue("formFindParameterLocationX", FormFindParameter.Location.X),
                    (int)regKey.GetValue("formFindParameterLocationY", FormFindParameter.Location.Y));
            }


            //if (FormIntTable != null && (int)regKey.GetValue("formIntTableLocationY", FormIntTable.Location.Y) >= 0)
            //{
            //FormIntTable.Width = (int)regKey.GetValue("formIntTableWidth", FormIntTable.Width);
            //FormIntTable.Height = (int)regKey.GetValue("formIntTableHeight", FormIntTable.Height);
            //FormIntTable.Location = new Point((int)regKey.GetValue("formIntTableLocationX", FormIntTable.Location.X),
            //(int)regKey.GetValue("formIntTableLocationY", FormIntTable.Location.Y));
            //}
            if (FormDrawRing != null && (int)regKey.GetValue("formDrawRingLocationY", FormDrawRing.Location.Y) >= 0)
            {
                FormDrawRing.Width = (int)regKey.GetValue("formDrawRingWidth", FormDrawRing.Width);
                FormDrawRing.Height = (int)regKey.GetValue("formDrawRingHeight", FormDrawRing.Height);
                FormDrawRing.Location = new Point((int)regKey.GetValue("formDrawRingLocationX", FormDrawRing.Location.X), (int)regKey.GetValue("formDrawRingLocationY", FormDrawRing.Location.Y));
            }
            //サイズ、位置関係終了

            if (FormProperty != null && (int)regKey.GetValue("formPropertyLocationY", FormProperty.Location.Y) >= 0)
            {
                //formMain.formProperty.Width = (int)regKey.GetValue("formPropertyWidth", formMain.formProperty.Width);
                //formMain.formProperty.Height = (int)regKey.GetValue("formPropertyHeight", formMain.formProperty.Height);
                FormProperty.Location = new Point((int)regKey.GetValue("formPropertyLocationX", FormProperty.Location.X), (int)regKey.GetValue("formPropertyLocationY", FormProperty.Location.Y));

                FormProperty.numericBoxPixelSizeX.Text = (string)regKey.GetValue("textBoxPixelSizeXText", "0.1");
                FormProperty.numericBoxPixelSizeY.Text = (string)regKey.GetValue("textBoxPixelSizeYText", "0.1");
                FormProperty.numericBoxPixelKsi.Text = (string)regKey.GetValue("textBoxPixelKsiText", "0");

                FormProperty.CameraLength1Text = (string)regKey.GetValue("textBoxFilmDistanceText", "445");
                FormProperty.numericBoxDirectSpotPositionX.Text = (string)regKey.GetValue("textBoxCenterPositionXText", "1500");
                FormProperty.numericBoxDirectSpotPositionY.Text = (string)regKey.GetValue("textBoxCenterPositionYText", "1500");

                //ConcentricかRadialか
                //  if ((string)regKey.GetValue("formProperty.radioButtonConcentric.Checked", "True") == "True")
                FormProperty.radioButtonConcentric.Checked = true;
                //  if ((string)regKey.GetValue("formProperty.radioButtonRadial.Checked", "True") == "True")
                //      formProperty.radioButtonRadial.Checked = true;

                //ここからConcentric Modeの内容
                FormProperty.StartAngle = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStartAngleValue", FormProperty.StartAngle.ToString()));
                FormProperty.EndAngle = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityEndAngleValue", FormProperty.EndAngle.ToString()));
                FormProperty.StepAngle = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStepAngleValue", FormProperty.StepAngle.ToString()));

                FormProperty.StartLength = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStartLengthValue", FormProperty.StartLength.ToString()));
                FormProperty.EndLength = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityEndLengthValue", FormProperty.EndLength.ToString()));
                FormProperty.StepLength = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStepLengthValue", FormProperty.StepLength.ToString()));

                FormProperty.StartDspacing = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStartDspacingValue", FormProperty.StartDspacing.ToString()));
                FormProperty.EndDspacing = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityEndDspacingValue", FormProperty.EndDspacing.ToString()));
                FormProperty.StepDspacing = Convert.ToDouble((string)regKey.GetValue("numericUpDownIntensityStepDspacingValue", FormProperty.StepDspacing.ToString()));

                if ((string)regKey.GetValue("radioButtonAngleMode", "True") == "True")
                    FormProperty.radioButtonConcentricAngle.Checked = true;
                //else if ((string)regKey.GetValue("radioButtonLengthMode", "True") == "True")
                //    radioButtonLengthMode.Checked = true;
                else if ((string)regKey.GetValue("radioButtonDspacingMode", "True") == "True")
                    FormProperty.radioButtonConcentricDspacing.Checked = true;
                FormProperty.radioButtonAngleMode_CheckedChanged(new object(), new EventArgs());

                //ここからRadial Modeの内容
                FormProperty.SectorRadiusTheta = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusTheta", FormProperty.SectorRadiusTheta.ToString()));
                FormProperty.SectorRadiusThetaRange = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusThetaRange", FormProperty.SectorRadiusThetaRange.ToString()));
                FormProperty.SectorRadiusD = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusD", FormProperty.SectorRadiusD.ToString()));
                FormProperty.SectorRadiusDRange = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusDRange", FormProperty.SectorRadiusDRange.ToString()));
                FormProperty.SectorAngle = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorAngle", FormProperty.SectorAngle.ToString()));

                FormProperty.radioButtonRadialAngle.Checked = (string)regKey.GetValue("formProperty.radioButtonRadialAngle.Checked", "True") == "True";

                FormProperty.radioButtonRadialAngle_CheckedChanged(new object(), new EventArgs());

                //chi角の方向など
                if ((string)regKey.GetValue("formProperty.radioButtonChiClockwise.Checked", "True") == "True")
                    FormProperty.radioButtonChiClockwise.Checked = true;
                else
                    FormProperty.radioButtonChiCounterclockwise.Checked = true;

                FormProperty.radioButtonChiRight.Checked = (string)regKey.GetValue("formProperty.radioButtonChiRight.Checked", "True") == "True";
                FormProperty.radioButtonChiLeft.Checked = (string)regKey.GetValue("formProperty.radioButtonChiLeft.Checked", "False") == "True";
                FormProperty.radioButtonChiTop.Checked = (string)regKey.GetValue("formProperty.radioButtonChiTop.Checked", "False") == "True";
                FormProperty.radioButtonChiBottom.Checked = (string)regKey.GetValue("formProperty.radioButtonChiBottom.Checked", "False") == "True";


                //ここからTilt Correction
                FormProperty.numericBoxTiltPhi.Text = (string)regKey.GetValue("textBoxTiltCorrectionPhiText", FormProperty.numericBoxTiltPhi.Text);
                FormProperty.numericBoxTiltTau.Text = (string)regKey.GetValue("textBoxTiltCorrectionPsiText", FormProperty.numericBoxTiltTau.Text);

                //ここから積分領域
                if ((string)regKey.GetValue("radioButtonRectangleChecked", "True") == "True")
                    FormProperty.radioButtonRectangle.Checked = true;
                else
                    FormProperty.radioButtonSector.Checked = true;

                FormProperty.numericUpDownRectangleAngle.Value = Convert.ToDecimal((string)regKey.GetValue("numericUpDownRectangleAngleValue", FormProperty.numericUpDownRectangleAngle.Value.ToString()));
                FormProperty.numericUpDownRectangleBand.Value = Convert.ToDecimal((string)regKey.GetValue("numericUpDownRectangleBandValue", FormProperty.numericUpDownRectangleBand.Value.ToString()));
                FormProperty.checkBoxRectangleIsBothSide.Checked = (string)regKey.GetValue("checkBoxRectangleIsBothSideChecked", "True") == "True";

                FormProperty.numericUpDownSectorStartAngle.Value = Convert.ToDecimal((string)regKey.GetValue("numericUpDownSectorStartAngleValue", FormProperty.numericUpDownSectorStartAngle.Value.ToString()));
                FormProperty.numericUpDownSectorEndAngle.Value = Convert.ToDecimal((string)regKey.GetValue("numericUpDownSectorEndAngleValue", FormProperty.numericUpDownSectorEndAngle.Value.ToString()));

                FormProperty.WaveLengthText = (string)regKey.GetValue("textBoxWaveLengthText", "0.4");
                FormProperty.comboBoxRectangleDirection.Text = (string)regKey.GetValue("comboBoxRectangleDirectionText", FormProperty.comboBoxRectangleDirection.Text);
                FormProperty.numericUpDownFindSpotsDeviation.Value = Convert.ToDecimal((string)regKey.GetValue("numericUpDownFindSpotsDeviationValue", FormProperty.numericUpDownFindSpotsDeviation.Value.ToString()));

                //偏光補正
                FormProperty.checkBoxCorrectPolarization.Checked = (string)regKey.GetValue("FormProperty.checkBoxCorrectPolarization.Checked", "True") == "True";

                //ここからイメージタイプごとのパラメータ読み込み
                #region
                for (int i = 0; i < Enum.GetValues(typeof(Ring.ImageTypeEnum)).Length; i++)
                {
                    FormProperty.ImageTypeParameters[i].CenterPosX = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.CenterPosX" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].CenterPosY = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.CenterPosY" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].CameraLength = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.CameraLength" + i.ToString(), "100"));
                    FormProperty.ImageTypeParameters[i].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.PixelSizeX" + i.ToString(), "0.1"));
                    FormProperty.ImageTypeParameters[i].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.PixelSizeY" + i.ToString(), "0.1"));
                    FormProperty.ImageTypeParameters[i].PixelKsi = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.PixelKsi" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].Phi = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.Phi" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].Tau = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.Tau" + i.ToString(), "0"));

                    FormProperty.ImageTypeParameters[i].WaveSource = (WaveSource)Convert.ToInt32(regKey.GetValue("ImageTypeParameters.WaveSource" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].XrayWaveSourceElementNumber = Convert.ToInt32(regKey.GetValue("ImageTypeParameters.XrayWaveSourceElementNumber" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].XrayLine = (XrayLine)Convert.ToInt32(regKey.GetValue("ImageTypeParameters.XrayLine" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].ElectronAccVoltage = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.ElectronAccVoltage" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].WaveLength = Convert.ToDouble(regKey.GetValue("ImageTypeParameters.WaveLength" + i.ToString(), "0"));

                    FormProperty.ImageTypeParameters[i].ElectronAccVoltage = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.ElectronAccVoltage" + i.ToString(), "0"));
                    FormProperty.ImageTypeParameters[i].WaveLength = Convert.ToDouble(regKey.GetValue("ImageTypeParameters.WaveLength" + i.ToString(), "0"));

                    FormProperty.ImageTypeParameters[i].FlipHorizontally = (string)regKey.GetValue("ImageTypeParameters.FlipHorizontally" + i.ToString(), "False") == "True";
                    FormProperty.ImageTypeParameters[i].FlipVertically = (string)regKey.GetValue("ImageTypeParameters.FlipVertically" + i.ToString(), "False") == "True";

                    FormProperty.ImageTypeParameters[i].Rotation = (int)regKey.GetValue("ImageTypeParameters.Rotation" + i.ToString(), 0);

                    FormProperty.ImageTypeParameters[i].GandolfiRadius = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.GandolfiRadius" + i.ToString(), "127.4"));

                    if ((string)regKey.GetValue("ImageTypeParameters.CameraMode" + i.ToString(), "FlatPanel") == "FlatPanel")
                        FormProperty.ImageTypeParameters[i].CameraMode = IntegralProperty.CameraEnum.FlatPanel;
                    else
                        FormProperty.ImageTypeParameters[i].CameraMode = IntegralProperty.CameraEnum.Gandolfi;
                }

                int m = (int)Ring.ImageTypeEnum.Rigaku_RAxis_IV;//RAxis4用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = Convert.ToDouble((string)regKey.GetValue("centerPosRAxis4X", "1500"));
                    FormProperty.ImageTypeParameters[m].CenterPosY = Convert.ToDouble((string)regKey.GetValue("centerPosRAxis4Y", "1500"));
                    FormProperty.ImageTypeParameters[m].CameraLength = Convert.ToDouble((string)regKey.GetValue("CameraLengthRAxis4", "445"));
                    FormProperty.ImageTypeParameters[m].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("PixelSizeXRAxis4", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("PixelSizeYRAxis4", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelKsi = Convert.ToDouble((string)regKey.GetValue("PixelKsiRAxis4", "0"));
                    FormProperty.ImageTypeParameters[m].Phi = Convert.ToDouble((string)regKey.GetValue("PhiRAxis4", "0"));
                    FormProperty.ImageTypeParameters[m].Tau = Convert.ToDouble((string)regKey.GetValue("TauRAxis4", "0"));

                    FormProperty.ImageTypeParameters[m].WaveSource = 0;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    FormProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthRAxis4", "0.4"));
                }

                m = (int)Ring.ImageTypeEnum.Rigaku_RAxis_V;//RAxis5用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = Convert.ToDouble((string)regKey.GetValue("centerPosRAxis4X", "1500"));
                    FormProperty.ImageTypeParameters[m].CenterPosY = Convert.ToDouble((string)regKey.GetValue("centerPosRAxis4Y", "1500"));
                    FormProperty.ImageTypeParameters[m].CameraLength = Convert.ToDouble((string)regKey.GetValue("CameraLengthRAxis4", "445"));
                    FormProperty.ImageTypeParameters[m].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("PixelSizeXRAxis4", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("PixelSizeYRAxis4", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelKsi = Convert.ToDouble((string)regKey.GetValue("PixelKsiRAxis4", "0"));
                    FormProperty.ImageTypeParameters[m].Phi = Convert.ToDouble((string)regKey.GetValue("PhiRAxis4", "0"));
                    FormProperty.ImageTypeParameters[m].Tau = Convert.ToDouble((string)regKey.GetValue("TauRAxis4", "0"));

                    FormProperty.ImageTypeParameters[m].WaveSource = 0;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    FormProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthRAxis4", "0.4"));
                }

                m = (int)Ring.ImageTypeEnum.Brucker_CCD;  //Brucker用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = Convert.ToDouble((string)regKey.GetValue("centerPosBruckerX", "512"));
                    FormProperty.ImageTypeParameters[m].CenterPosY = Convert.ToDouble((string)regKey.GetValue("centerPosBruckerY", "512"));
                    FormProperty.ImageTypeParameters[m].CameraLength = Convert.ToDouble((string)regKey.GetValue("CameraLengthBrucker", "100"));
                    FormProperty.ImageTypeParameters[m].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("PixelSizeXBrucker", "0.06"));
                    FormProperty.ImageTypeParameters[m].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("PixelSizeYBrucker", "0.06"));
                    FormProperty.ImageTypeParameters[m].PixelKsi = Convert.ToDouble((string)regKey.GetValue("PixelKsiBrucker", "0"));
                    FormProperty.ImageTypeParameters[m].Phi = Convert.ToDouble((string)regKey.GetValue("PhiBrucker", "0"));
                    FormProperty.ImageTypeParameters[m].Tau = Convert.ToDouble((string)regKey.GetValue("TauBrucker", "0"));

                    FormProperty.ImageTypeParameters[m].WaveSource = 0;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    FormProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthBrucker", "0.4"));
                }

                m = (int)Ring.ImageTypeEnum.Fuji_BAS2000;  //FujiBAS用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = Convert.ToDouble((string)regKey.GetValue("centerPosFujiX", "1000"));
                    FormProperty.ImageTypeParameters[m].CenterPosY = Convert.ToDouble((string)regKey.GetValue("centerPosFujiY", "1300"));
                    FormProperty.ImageTypeParameters[m].CameraLength = Convert.ToDouble((string)regKey.GetValue("CameraLengthFuji", "445"));
                    FormProperty.ImageTypeParameters[m].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("PixelSizeXFuji", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("PixelSizeYFuji", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelKsi = Convert.ToDouble((string)regKey.GetValue("PixelKsiBrucker", "0"));
                    FormProperty.ImageTypeParameters[m].Phi = Convert.ToDouble((string)regKey.GetValue("PhiFuji", "0"));
                    FormProperty.ImageTypeParameters[m].Tau = Convert.ToDouble((string)regKey.GetValue("TauFuji", "0"));

                    FormProperty.ImageTypeParameters[m].WaveSource = 0;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    FormProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthFuji", "0.4"));
                }

                m = (int)Ring.ImageTypeEnum.Fuji_BAS2500;  //FujiBAS用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = Convert.ToDouble((string)regKey.GetValue("centerPosFujiX", "1000"));
                    FormProperty.ImageTypeParameters[m].CenterPosY = Convert.ToDouble((string)regKey.GetValue("centerPosFujiY", "1300"));
                    FormProperty.ImageTypeParameters[m].CameraLength = Convert.ToDouble((string)regKey.GetValue("CameraLengthFuji", "445"));
                    FormProperty.ImageTypeParameters[m].PixelSizeX = Convert.ToDouble((string)regKey.GetValue("PixelSizeXFuji", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelSizeY = Convert.ToDouble((string)regKey.GetValue("PixelSizeYFuji", "0.1"));
                    FormProperty.ImageTypeParameters[m].PixelKsi = Convert.ToDouble((string)regKey.GetValue("PixelKsiBrucker", "0"));
                    FormProperty.ImageTypeParameters[m].Phi = Convert.ToDouble((string)regKey.GetValue("PhiFuji", "0"));
                    FormProperty.ImageTypeParameters[m].Tau = Convert.ToDouble((string)regKey.GetValue("TauFuji", "0"));

                    FormProperty.ImageTypeParameters[m].WaveSource = 0;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    FormProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthFuji", "0.4"));
                }

                m = (int)Ring.ImageTypeEnum.Fuji_FDL;  //FujiFDL用
                if (FormProperty.ImageTypeParameters[m].CenterPosX == 0)
                {
                    FormProperty.ImageTypeParameters[m].CenterPosX = 1880;
                    FormProperty.ImageTypeParameters[m].CenterPosY = 1500;
                    FormProperty.ImageTypeParameters[m].CameraLength = 1000;
                    FormProperty.ImageTypeParameters[m].PixelSizeX = 0.025;
                    FormProperty.ImageTypeParameters[m].PixelSizeY = 0.025;
                    FormProperty.ImageTypeParameters[m].PixelKsi = 0;
                    FormProperty.ImageTypeParameters[m].Phi = 0;
                    FormProperty.ImageTypeParameters[m].Tau = 0;

                    FormProperty.ImageTypeParameters[m].WaveSource = WaveSource.Electron;
                    FormProperty.ImageTypeParameters[m].XrayWaveSourceElementNumber = 0;
                    FormProperty.ImageTypeParameters[m].XrayLine = 0;
                    FormProperty.ImageTypeParameters[m].ElectronAccVoltage = 200;
                    //formProperty.ImageTypeParameters[m].WaveLength = Convert.ToDouble((string)regKey.GetValue("WaveLengthFuji", "0.4"));
                }

                #endregion
            }

            //regKey = regKey.OpenSubKey("Macro");
            //int length = (int)regKey.GetValue("MacroLength", 0);
            //byte[][] byteArray = new byte[length][];
            //for (int i = 0; i < length; i++)
            //    byteArray[i] = (byte[])regKey.GetValue("Macro" + i.ToString(), null);
            if (FormMacro != null)
                FormMacro.ZippedMacros = (byte[])regKey.GetValue("Macro", Array.Empty<byte>());

            regKey.Close();
        }

        catch { }
    }
    #endregion

    public void SetText(string filename = "", string filenameSub = "")
    {
        string text = "IPAnalyzer";
#if DEBUG
        text += "(debug)";
#endif
        text += "  " + Version.VersionAndDate;

        if (filename != "")
        {
            FileName = filename;
            text += "  " + FileName;
            if (filenameSub != "")
            {
                FileNameSub = filenameSub;
                text += "  " + FileNameSub;
            }
        }

        this.Text = text;
    }

    //ファームロード時
    private void FormMain_Load(object sender, System.EventArgs e)
    {
        //UserAppDataPathに空フォルダがあったら削除
        foreach (var dir in Directory.GetDirectories(UserAppDataPath))
            if (!Directory.EnumerateFileSystemEntries(dir).Any())
                Directory.Delete(dir);

        //#if !DEBUG
        //            Ngen.Compile();
        //#endif

        toolStripComboBoxRotate.SelectedIndex = 0;

        InitialDialog = new Crystallography.Controls.CommonDialog
        {
            Owner = this,
            DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Initialize,
            Software = Version.Software,
            VersionAndDate = Version.VersionAndDate,
            History = Version.History,
            Hint = Version.Hint,
            Width = 600,

        };
        LoadRegistry();

        InitialDialog.Show();
        Application.DoEvents();

        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.1);

        InitialDialog.Text = "Now Loading...Checking language.";

        englishToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name != "ja";
        japaneseToolStripMenuItem.Checked = Thread.CurrentThread.CurrentUICulture.Name == "ja";


        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.2);
        InitialDialog.Text = "Now Loading...Setting image scales.";
        pseudoBitmap.MaxValue = 65535;
        pseudoBitmap.MinValue = 0;
        IP = new IntegralProperty();

        comboBoxScale1.SelectedIndex = 0;
        comboBoxScale2.SelectedIndex = 0;
        comboBoxGradient.SelectedIndex = 0;

        InitialDialog.Text = "Now Loading...Initializing 'Intensity table' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.3);

        //FormIntTable = new FormIntTable();
        //FormIntTable.formMain = this;
        //FormIntTable.Visible = false;
        //FormIntTable.Owner = this;

        InitialDialog.Text = "Now Loading...Initializing 'Auto procedure' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.4);

        FormAutoProc = new FormAutoProcedure { formMain = this, Visible = false, Owner = this };

        InitialDialog.Text = "Now Loading...Initializing 'Find parameter' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.5);

        FormFindParameter = new FormFindParameter { formMain = this, Visible = false, Owner = this };


        InitialDialog.Text = "Now Loading...Initializing 'Draw ring' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.6);

        FormDrawRing = new FormDrawRing { formMain = this, Visible = false, Owner = this };

        InitialDialog.Text = "Now Loading...Initializing 'Property' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.7);


        FormProperty = new FormProperty { formMain = this, Visible = false, Owner = this };

        InitialDialog.Text = "Now Loading...Initializing 'Calibrate Intensity' form";
        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.8);
        Application.DoEvents();

        FormCalibrateIntensity = new FormCalibrateIntensity { formMain = this, Visible = false, Owner = this };

        InitialDialog.Text = "Now Loading...Initializing 'Save Image' form.";

        FormSaveImage = new FormSaveImage { FormMain = this, Owner = this, Visible = false };

        InitialDialog.Text = "Now Loading...Initializing 'Sequential' form.";

        FormSequentialImage = new FormSequentialImage { formMain = this, Owner = this, Visible = false };

        InitialDialog.Text = "Now Loading...Initializing 'Parameter option' form.";

        FormParameterOption = new FormParameterOption { FormMain = this, Owner = this, Visible = false };

        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.9);
        InitialDialog.Text = "Now Loading...Initializing 'SACLA' form.";

        FormFindParameterBruteForce = new FormFindParameterBruteForce { FormMain = this, Owner = this, Visible = false };

        FormProperty.Visible = true;


        InitialDialog.Text = "Now Loading...Initializing Macro function.";

        FormMacro = new FormMacro(Python.CreateEngine(), new Macro(this))        {            Visible = false        };
        Type t = typeof(Macro);
        MemberInfo[] members = t.GetMembers();
        var methods = t.GetMethods();


        InitialDialog.Text = "Now Loading...Reading registries";

        LoadRegistry();

        InitialDialog.Text = "Now Loading...Generating ReadMe.txt.";

        ReadMeGenerator.WriteReadMeFile(
            "IPAnalyzer   " + Version.VersionAndDate,
            Version.Introduction,
            Version.Manual,
            Version.CopyRight,
            Version.Condition,
            Version.Exemption,
            Version.Adress,
            Version.Acknowledge,
            Version.History);

        InitialDialog.Text = "Now Loading...Checking command line options.";
        var s = Environment.GetCommandLineArgs();
        var fileName = "";
        for (int i = 1; i < s.Length; i++)
            fileName += (i == 1 ? "" : " ") + s[i];
        if (s.Length > 1)
        {
            if (fileName.EndsWith("img") || fileName.EndsWith("stl") || fileName.EndsWith("ccd") || fileName.EndsWith("ipf"))
                ReadImage(fileName);
            else if (fileName.EndsWith("prm"))
                ReadParameter(fileName);
            else if (fileName.EndsWith("mas"))
                ReadMask(fileName);
        }

        Clipboard.SetDataObject("IPAnalyzer");

        SetText();

        InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 1);

        InitialDialog.Text = "Initializing has been finished successfully. You can close this window.";
        if (InitialDialog.AutomaticallyClose)
            InitialDialog.Visible = false;

        Directory.Delete(Application.UserAppDataPath, true);
        if (!File.Exists(UserAppDataPath + "IPAnalyzerSetup.msi"))
            File.Delete(UserAppDataPath + "IPAnalyzerSetup.msi");

    }

    //フォームクローズ時
    private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
    {
        FormProperty.SaveParameterForEachImageType(Ring.ImageType);

        if (!clearRegistrycheckAndRestartToolStripMenuItem.Checked)
            SaveRegistry();
        else
            ResetRegistry();

        graphControlProfile.AddProfile(new Profile());
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {

        Properties.Settings.Default.Save();
        FormProperty.Close();
        FormDrawRing.Close();
        FormFindParameter.Close();
        FormAutoProc.Close();
        //FormIntTable.Close();
        e.Cancel = false;
    }

    #endregion

    #region 描画関数
    private void scalablePictureBox_Draw()
    {//scalablePictureBoxから描画要求が出されたとき
        Draw();
    }

    private void scalablePictureBoxThumbnail_Draw()
    {

    }

    public void Draw()
    {
        if (SkipDrawing || !IsImageReady) return;
        if (!toolStripButtonUnroll.Checked)
        {
            pseudoBitmap.Filter1 = [.. Ring.IsThresholdOver];
            pseudoBitmap.Filter2 = [.. Ring.IsThresholdUnder];
            pseudoBitmap.Filter3 = [.. Ring.IsSpots];
            pseudoBitmap.Filter4 = [.. Ring.IsOutsideOfIntegralRegion];
            pseudoBitmap.Filter5 = [.. Ring.IsOutsideOfIntegralProperty];
        }

        var bmp = pseudoBitmap.GetImage(scalablePictureBox.Center, scalablePictureBox.Zoom, scalablePictureBox.pictureBox.ClientSize);
        if (bmp == null) return;
        var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;

        //メイン中に水色の枠(SaveImageの範囲)を表示
        if (FormSaveImage.Visible)
        {
            var pen = new Pen(Brushes.LightBlue);
            //傾きを考慮していないので、正確ではないが、とりあえず。
            var upperLeft = new PointD(
                FormProperty.DirectSpotPosition.X - FormSaveImage.ImageCenter.X * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeX.Value,
                FormProperty.DirectSpotPosition.Y - FormSaveImage.ImageCenter.Y * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeY.Value);

            var lowerRight = new PointD(
                FormProperty.DirectSpotPosition.X + (FormSaveImage.ImageSize.Width - FormSaveImage.ImageCenter.X) * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeX.Value,
                FormProperty.DirectSpotPosition.Y + (FormSaveImage.ImageSize.Height - FormSaveImage.ImageCenter.Y) * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeY.Value);

            var rect = scalablePictureBox.ConvertToClientRect(new RectangleD(upperLeft.X, upperLeft.Y, lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y)).ToRectangleF();

            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }

        //マウスで一秒以上長押しした点にペケ
        try
        {
            if (!selectedSpot.IsNaN)
            {
                var pt = scalablePictureBox.ConvertToClientPt(selectedSpot);
                var pen = new Pen(Brushes.Orange);
                g.DrawLine(pen, new PointF((float)pt.X + 4, (float)pt.Y + 4), new PointF((float)pt.X - 4, (float)pt.Y - 4));
                g.DrawLine(pen, new PointF((float)pt.X - 4, (float)pt.Y + 4), new PointF((float)pt.X + 4, (float)pt.Y - 4));
            }
        }
        catch { }

        //マニュアルマスク点にペケ
        try
        {
            if (manualMaskPoints.Count > 0)
            {
                foreach (PointD p in manualMaskPoints)
                {
                    var pt = scalablePictureBox.ConvertToClientPt(p);
                    var pen = new Pen(Brushes.HotPink);
                    g.DrawLine(pen, new PointF((float)pt.X + 4, (float)pt.Y + 4), new PointF((float)pt.X - 4, (float)pt.Y - 4));
                    g.DrawLine(pen, new PointF((float)pt.X - 4, (float)pt.Y + 4), new PointF((float)pt.X + 4, (float)pt.Y - 4));
                }
            }
        }
        catch { }

        #region リングを描く
        if (FormDrawRing.Visible && FormDrawRing.R > 0)
        {
            try
            {
                var Rect = new RectangleF(0, 0, 0, 0);
                var cameraLength1 = FormProperty.CameraLength1;
                var Phi = FormProperty.numericBoxTiltPhi.RadianValue;
                var Tau = FormProperty.numericBoxTiltTau.RadianValue;

                (var OffSet, var EllipseWidth, var EllipseHeight, var Cos, var Sin) = Geometry.GetEllipseRectangleAndRot(FormDrawRing.R, cameraLength1, Phi, Tau);

                g = Graphics.FromImage(bmp);
                g.SmoothingMode = SmoothingMode.AntiAlias;

                //まずビーム中心を原点に持ってくる

                PointF center = scalablePictureBox.ConvertToClientPt(FormProperty.DirectSpotPosition).ToPointF();
                PointD centerD = scalablePictureBox.ConvertToClientPt(FormProperty.DirectSpotPosition);

                Matrix3D m = new(1, 0, 0, 0, 1, 0, centerD.X, centerD.Y, 1);

                //次にディスプレイ上のピクセルと画像のピクセルを同じにする
                float scale = (float)(1 / scalablePictureBox.Zoom); //SrcRectF.Width / ClientRect.Width;

                m *= new Matrix3D(1 / scale, 0, 0, 0, 1 / scale, 0, 0, 0, 1);
                //次に画像ピクセル空間を実空間にする
                float pixelSizeX = (float)FormProperty.numericBoxPixelSizeX.Value;
                float pixelSizeY = (float)FormProperty.numericBoxPixelSizeY.Value;
                float TanKsi = (float)Math.Tan(FormProperty.numericBoxPixelKsi.RadianValue);

                m *= new Matrix3D(1 / pixelSizeX, 0, 0, -TanKsi / pixelSizeX, 1 / pixelSizeY, 0, 0, 0, 1);

                //楕円の中心位置のずれをオフセット

                m *= new Matrix3D(1, 0, 0, 0, 1, 0, OffSet.X, OffSet.Y, 1);

                //楕円の傾きをセット

                m *= new Matrix3D(Cos, Sin, 0, -Sin, Cos, 0, 0, 0, 1);

                g.MultiplyTransform(new Matrix(1, 0, 0, 1, center.X, center.Y));

                g.MultiplyTransform(new Matrix(1 / pixelSizeX, 0, -TanKsi / pixelSizeX, 1 / pixelSizeY, 0, 0));

                g.MultiplyTransform(new Matrix(1 / scale, 0, 0, 1 / scale, 0, 0));

                g.MultiplyTransform(new Matrix(1, 0, 0, 1, (float)OffSet.X, (float)OffSet.Y));

                g.MultiplyTransform(new Matrix((float)Cos, (float)Sin, -(float)Sin, (float)Cos, 0, 0));

                //最後に楕円を描画
                RectangleF RectangleOfEllipse = new RectangleF(-(float)EllipseWidth, -(float)EllipseHeight,
                   (float)EllipseWidth * 2, (float)EllipseHeight * 2);

                g.Transform = new Matrix((float)m.E11, (float)m.E21, (float)m.E12, (float)m.E22, (float)m.E13, (float)m.E23);

                g.DrawEllipse(new Pen(Brushes.Yellow, 0.01f), RectangleOfEllipse);

                g.Transform = new Matrix(1, 0, 0, 1, 0, 0);
            }
            catch { }

        }
        #endregion

        //Scale Line
        if (comboBoxScaleLine.SelectedIndex != 0)
            DrawScale(g);

        //中心点にペケ
        try
        {
            PointD pt = scalablePictureBox.ConvertToClientPt(FormProperty.DirectSpotPosition);
            Pen pen = new Pen(Brushes.Fuchsia);
            g.DrawLine(pen, new PointF((float)pt.X + 4, (float)pt.Y + 4), new PointF((float)pt.X - 4, (float)pt.Y - 4));
            g.DrawLine(pen, new PointF((float)pt.X - 4, (float)pt.Y + 4), new PointF((float)pt.X + 4, (float)pt.Y - 4));
        }
        catch { }

        scalablePictureBox.pictureBox.Image = bmp;
        scalablePictureBox.Refresh();

        //サムネイルに画像転送
        DrawThumnail();
    }

    #region DrawScale
    private void DrawScale(Graphics g)
    {
        int width = scalablePictureBox.pictureBox.ClientSize.Width, height = scalablePictureBox.pictureBox.ClientSize.Height;
        if (width == 0 || height == 0) return;

        var zoom = scalablePictureBox.Zoom; //SrcRectF.Width / ClientRect.Width;
        var clientCenter = scalablePictureBox.Center;
        var pixelSizeX = (float)FormProperty.numericBoxPixelSizeX.Value;
        var pixelSizeY = (float)FormProperty.numericBoxPixelSizeY.Value;
        var TanKsi = (float)Math.Tan(FormProperty.numericBoxPixelKsi.RadianValue);
        g.Transform = new Matrix(
            (float)(1 * zoom / pixelSizeX), 0, (float)(-TanKsi * zoom / pixelSizeX), (float)(zoom / pixelSizeY),
            (float)(FormProperty.FootPosition.X * zoom + width / 2.0 - clientCenter.X * zoom),
            (float)(FormProperty.FootPosition.Y * zoom + height / 2.0 - clientCenter.Y * zoom));

        //検出器の隅っこ4点の座標(検出器座標系 mm単位)
        var cornerDetector = new[] { convertScreenToDetector(0, 0), convertScreenToDetector(width, 0), convertScreenToDetector(width, height), convertScreenToDetector(0, height) };
        var cornerReals = new[] { convertScreenToReal(0, 0), convertScreenToReal(width, 0), convertScreenToReal(width, height), convertScreenToReal(0, height) };
        var originSrc = convertReciprocalToDetector(new Vector3DBase(0, 0, 0));

        var p = scalablePictureBox.ConvertToClientPt(FormProperty.DirectSpotPosition);
        var originInside = p.X > 0 && p.Y > 0 && p.X < width && p.Y < height;

        //Azimuthのスケールライン ここから
        int azimuthStep = comboBoxScaleLine.SelectedIndex switch { 1 => 30, 2 => 15, 3 => 5, _ => 30 };
        var pen = new Pen(FormProperty.colorControlScaleAzimuth.Color, (float)(FormProperty.trackBarScaleLineWidth.Value / zoom * (pixelSizeX + pixelSizeY) / 2));
        var font = new Font("Tahoma", (float)(15 / zoom * (pixelSizeX + pixelSizeY) / 2));

        var length = new[] { (cornerReals[0]- cornerReals[1]).Length, (cornerReals[1] - cornerReals[2]).Length,
            (cornerReals[2] - cornerReals[3]).Length, (cornerReals[3] - cornerReals[0]).Length };

        for (double n = 0; n < 180; n += azimuthStep)
        {
            pen.DashStyle = n % 10 == 0 ? DashStyle.Dash : DashStyle.Dot;

            var crossPts = new List<(PointD pt, int index)>();
            double cos = Math.Cos(n / 180.0 * Math.PI), sin = Math.Sin(n / 180.0 * Math.PI);
            //n度傾いた平面と、画像のエッジの交点を求める
            for (int i = 0; i < 4; i++)
            {
                //  0 - 1
                //  |   |
                //  3 - 2 
                var j = i < 3 ? i + 1 : 0;
                var cross = Geometry.GetCrossPoint(sin, -cos, 0, 0, cornerReals[i], cornerReals[j]);
                double length1 = (cornerReals[i] - cross).Length, length2 = (cornerReals[j] - cross).Length;
                if (length1 + length2 < length[i] * 1.001)
                    crossPts.Add((length1 / length[i] * cornerDetector[j] + length2 / length[i] * cornerDetector[i], i));
                if (crossPts.Count == 2)
                {
                    //直線描画
                    g.DrawLine(pen, crossPts[0].pt.ToPointF(), crossPts[1].pt.ToPointF());

                    if (FormProperty.checkBoxScaleLabel.Checked)//ラベル描画
                    {
                        //インデックス 0 が、n°に相当するかどうかを判定
                        var atan = Math.Atan2(crossPts[0].pt.Y - originSrc.Y, crossPts[0].pt.X - originSrc.X) / Math.PI * 180;
                        if (atan < -135) atan += 360;

                        var str = new string[2];
                        if (Math.Min(Math.Abs(atan - n), Math.Abs(atan - n + 360)) < Math.Min(Math.Abs(atan - n + 180), Math.Abs(atan - n - 180)))
                            str = originInside ? [n.ToString("g12"), (n - 180).ToString("g12")] : [n.ToString("g12"), n.ToString("g12")];
                        else
                            str = originInside ? [(n - 180).ToString("g12"), n.ToString("g12")] : [(n - 180).ToString("g12"), (n - 180).ToString("g12")];

                        var skip = -1;
                        if (!originInside)//ダイレクトスポットが描画範囲内に含まれていないときは 中心に近い点は削除
                            skip = (crossPts[0].pt - originSrc).Length > (crossPts[1].pt - originSrc).Length ? 1 : 0;

                        for (int k = 0; k < 2; k++)
                        {
                            var shift = new PointD(crossPts[k].index == 1 ? -3 : 0, crossPts[k].index == 2 ? -2 : 0) * font.Size;
                            if (skip != k)
                                g.DrawString(str[k] + "°", font, new SolidBrush(FormProperty.colorControlScaleAzimuth.Color), (crossPts[k].pt + shift).ToPointF());
                        }
                    }
                    break;
                }
            }
        }
        //Azimuthのスケールライン ここまで

        //ここから2θのスケールラインの描画

        //2θの最大/最小値
        double max2Theta = 0, min2Theta = 0.0;
        var edges = new List<Vector3DBase>();
        edges.AddRange(Enumerable.Range(0, width).Select(w => convertScreenToReal(w, 0)));
        edges.AddRange(Enumerable.Range(0, width).Select(w => convertScreenToReal(w, height)));
        edges.AddRange(Enumerable.Range(0, height).Select(h => convertScreenToReal(0, h)));
        edges.AddRange(Enumerable.Range(0, height).Select(h => convertScreenToReal(width, h)));
        if (!originInside)
            min2Theta = edges.Select(p => Math.Atan2(Math.Sqrt(p.X2Y2), p.Z)).Min() / Math.PI * 180.0;
        max2Theta = edges.Select(p => Math.Atan2(Math.Sqrt(p.X2Y2), p.Z)).Max() / Math.PI * 180.0;
        //2θの最大/最小値　ここまで

        //分割幅をきめる　ここから
        //fineのときは20分割以上、mediumは10分割以上、coarseは5分割以上になるように調節
        double dev = max2Theta - min2Theta;
        int thereshold = comboBoxScaleLine.SelectedIndex switch { 1 => 5, 2 => 15, 3 => 30, _ => 30 };
        int stepInteger = 5, stepPow = 0;
        for (stepPow = (int)Math.Log10(dev) + 1; stepPow > -7; stepPow--)
        {
            if (dev / (stepInteger = 5) / Math.Pow(10, stepPow) > thereshold) break;
            if (dev / (stepInteger = 2) / Math.Pow(10, stepPow) > thereshold) break;
            if (dev / (stepInteger = 1) / Math.Pow(10, stepPow) > thereshold) break;
        }
        //分割幅をきめる　ここまで

        int startN = (int)(min2Theta / stepInteger / Math.Pow(10, stepPow));
        int endN = (int)(max2Theta / stepInteger / Math.Pow(10, stepPow)) + 1;

        pen.Brush = new SolidBrush(FormProperty.colorControlScale2Theta.Color);


        for (double n = Math.Max(1, startN); n < endN; n++)
        {
            if (stepInteger == 1)
                pen.DashStyle = (n * stepInteger) % 5 == 0 ? DashStyle.Dash : DashStyle.Dot;
            else
                pen.DashStyle = (n * stepInteger) % 10 == 0 ? DashStyle.Dash : DashStyle.Dot;

            var twoTheta = n * stepInteger * Math.Pow(10, stepPow);
            var ptsArray = Geometry.ConicSection(twoTheta / 180 * Math.PI, FormProperty.DetectorTiltPhi.ToRadians(), FormProperty.DetectorTiltTau.ToRadians(), FormProperty.CameraLength2, cornerDetector[0], cornerDetector[2]);
            foreach (var pts in ptsArray)
                g.DrawLines(pen, pts.ToArray());

            var labelPosition = getLabelPosition(ptsArray.SelectMany(p => p).Where(e =>
            {
                var p = scalablePictureBox.ConvertToClientPt(e);
                return p.X > 20 && p.Y > 20 && p.X < width - 20 && p.Y < height - 20;
            }), originSrc, 0);
            if (FormProperty.checkBoxScaleLabel.Checked && ptsArray.Count != 0 && ptsArray[0].Count != 0)
                g.DrawString(twoTheta.ToString("g12") + "°", font, new SolidBrush(FormProperty.colorControlScale2Theta.Color), ptsArray[0][ptsArray[0].Count / 4].ToPointF());// labelPosition.ToPointF());
        }


        g.Transform = new Matrix(1, 0, 0, 1, 0, 0);
    }

    /// <summary>
    /// 与えられた点集合 pts の中から、もっとも指定した方向に近い点を返す. deg 0 : 右, deg 90: 下, deg 180: 左, deg -90:上
    /// </summary>
    /// <param name="list"></param>
    /// <param name="origin"></param>
    /// <returns></returns>
    private static PointD getLabelPosition(IEnumerable<PointD> list, PointD origin, double deg)
    {
        var residual = double.PositiveInfinity;
        var result = new PointD(float.NaN, float.NaN);
        foreach (var p in list)
        {
            var dev = Math.Abs((deg / 180) * Math.PI - Math.Atan2(p.Y - origin.Y, p.X - origin.X));
            if (residual > dev)
            {
                residual = dev;
                result = p;
            }
        }
        return result;
    }

    /// <summary>
    /// 座標変換 画面(Screen)上の点(pixel)を検出器(Detector)上の座標 (mm, Foot原点)に変換
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private PointD convertScreenToDetector(in int x, in int y)
    {
        var pt = scalablePictureBox.ConvertToSrcPt(new Point(x, y));
        return new PointD(
              (pt.X - FormProperty.FootPosition.X) * IP.PixSizeX + (pt.Y - FormProperty.FootPosition.Y) * IP.PixSizeY * Math.Tan(IP.ksi),
              (pt.Y - FormProperty.FootPosition.Y) * IP.PixSizeY);
    }

    /// <summary>
    /// 座標変換 画面(Screen)上の点(pixel) を 実空間座標(mm, ３次元座標)に変換
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector3DBase convertScreenToReal(in int x, in int y)
    {
        var p = convertScreenToDetector(x, y);//まずフィルム上の位置を取得
        return convertDetectorToReal(p.X, p.Y);//実空間の座標に変換
    }

    /// <summary>
    /// 座標変換 
    /// 検出器(Detector)上の点(Foot中心, mm単位) を 実空間座標(mm単位, ３次元座標)に変換
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private Vector3DBase convertDetectorToReal(in double x, in double y) => FormProperty.DetectorRotation * new Vector3DBase(x, y, FormProperty.CameraLength2);
    #region 座標変換の計算式
    // (CosPhi, SinPhi, 0) の周りに Tau回転する行列は、
    //   Cos2Phi * (1 - CosTau) + CosTau | CosPhi * SinPhi * (1 - CosTau)  |  SinPhi * SinTau
    //   CosPhi * SinPhi * (1 - CosTau)  | Sin2Phi * (1 - CosTau) + CosTau | -CosPhi * SinTau
    //  -SinPhi * SinTau                 | cosPhi  * sinTau                |  CosTau  
    //この行列を(x,y,CameraLength2)に作用させればよい
    #endregion

    /// <summary>
    /// 逆空間座標を検出器座標に変換。逆空間座標のy,zの符号を反転することに注意
    /// </summary>
    /// <param name="g"></param>
    /// <returns></returns>
    private PointD convertReciprocalToDetector(Vector3DBase g)
    {
        var v = FormProperty.DetectorRotationInv * new Vector3DBase(g.X, -g.Y, 1 / FormProperty.WaveLength - g.Z);
        var coeff = FormProperty.CameraLength2 / v.Z;
        return new PointD(v.X * coeff, v.Y * coeff);
    }
    #endregion

    //画像読み込み後にサムネイルを描く関数
    private void DrawThumnail()
    {
        //全体像モードのときは
        if (thumbnailmode)
            scalablePictureBoxThumbnail.Zoom = 0f;

        //中心位置拡大のとき
        else
        {
            scalablePictureBoxThumbnail.Zoom = 12f;
            scalablePictureBoxThumbnail.Center = new PointD(FormProperty.numericBoxDirectSpotPositionX.Value, FormProperty.numericBoxDirectSpotPositionY.Value);
        }

        var bmp = pseudoBitmap.GetImage(scalablePictureBoxThumbnail.Center, scalablePictureBoxThumbnail.Zoom, scalablePictureBoxThumbnail.pictureBox.ClientSize);
        var g = Graphics.FromImage(bmp);
        g.SmoothingMode = SmoothingMode.AntiAlias;
        if (thumbnailmode)
        {
            //サムネイル中に黄色い枠を表示
            var pen = new Pen(Brushes.Yellow);
            var rect = scalablePictureBoxThumbnail.ConvertToClientRect(scalablePictureBox.ConvertToSrcRect(scalablePictureBox.pictureBox.ClientRectangle)).ToRectangleF();
            g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
        }
        else
        {
            try
            {
                var pt = scalablePictureBoxThumbnail.ConvertToClientPt(new PointD(FormProperty.numericBoxDirectSpotPositionX.Value, FormProperty.numericBoxDirectSpotPositionY.Value)).ToPointF();
                var pen = new Pen(Brushes.Fuchsia);
                g.DrawLine(pen, new PointF(pt.X + 4, pt.Y + 3), new PointF(pt.X - 4, pt.Y - 4));
                g.DrawLine(pen, new PointF(pt.X - 4, pt.Y + 3), new PointF(pt.X + 4, pt.Y - 4));
            }
            catch { }
        }

        scalablePictureBoxThumbnail.pictureBox.Image = bmp;
    }

    #endregion

    #region マウスイベント
    //マウスボタンダウン

    private bool scalablePictureBoxThumbnail_MouseDown2(object sender, MouseEventArgs e, PointD pt)
    {

        if (thumbnailmode)//サムネイルモードでクリックしたとき
        {
            //クリックされた位置を中心にする。
            scalablePictureBoxThumbnail.Center = pt;
            Draw();
        }
        else if (e.Clicks == 2 || e.Button == MouseButtons.Middle)//中心拡大モードでダブルクリックされたとき
        {
            //クリックされた位置を中心にする。
            FormProperty.DirectSpotPosition = new PointD(pt.X, pt.Y);
            TableCenterPt = new Point((int)(pt.X + 0.5), (int)(pt.Y + 0.5));
            //if (FormIntTable != null)
            //    FormIntTable.SetData((int)(pt.X + 0.5), (int)(pt.Y + 0.5));
            //さらに真ん中ボタンクリックであればFindCenterもする　
            if (e.Button == MouseButtons.Middle)
                toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
            Draw();
        }

        return true;
    }

    readonly Stopwatch sw = new();

    public List<PointD> manualMaskPoints = [];
    public List<bool> splineTemp = [];
    Spline2nd sp;

    public void setSpline()
    {
        if (manualMaskPoints.Count > 2)
        {
            sp = new Spline2nd(manualMaskPoints);
            {
                for (double t = -0.5; t < manualMaskPoints.Count - 0.5; t += 0.001)
                {
                    PointD p = sp.GetValue(t);
                    int x = (int)(p.X + 0.5);
                    int y = (int)(p.Y + 0.5);
                    if (x >= 0 && x < SrcImgSize.Width && y >= 0 && y < SrcImgSize.Height)
                        pseudoBitmap.FilterTemporary[y * SrcImgSize.Width + x] = true;
                }
            }
            splineTemp = Convolution.BlurPixels(pseudoBitmap.FilterTemporary, SrcImgSize.Width, FormProperty.numericBoxSplineWidth.ValueInteger);
        }
        else
        {
            splineTemp.Clear();
            splineTemp.AddRange(new bool[pseudoBitmap.FilterTemporary.Count]);
        }
    }

    private bool scalablePictureBox_MouseDown2(object sender, MouseEventArgs e, PointD pt)
    {
        if (!IsImageReady) return true; ;

        //マニュアルスポットモード時
        if (toolStripMenuItemFindSpotsManual.Checked)
        {
            // PointD p = new PointD((pt.X - IP.CenterX) * IP.PixSizeX + (pt.Y - IP.CenterY) * IP.PixSizeY * Math.Tan(IP.ksi), (pt.Y - IP.CenterY) * IP.PixSizeY);
            if (FormProperty.radioButtonManualSpot.Checked)
                return true;//マウスイベント終了
            if (FormProperty.radioButtonManualCircle.Checked && manualMaskPoints.Count == 0)
            {
                manualMaskPoints.Add(pt);
                return true;//マウスイベント終了
            }
            else if (FormProperty.radioButtonManualRectangle.Checked && manualMaskPoints.Count == 0)
            {
                manualMaskPoints.Add(pt);
                return true;//マウスイベント終了
            }
            else if (FormProperty.radioButtonManualPolygon.Checked)//ポリゴンモード
            {
                if (e.Clicks == 1)//追加
                {
                    manualMaskPoints.Add(pt);
                }
                else if (e.Clicks == 2)
                {
                    //ダブルクリックした点は加えないので最後を削除
                    manualMaskPoints.RemoveAt(manualMaskPoints.Count - 1);

                    if (manualMaskPoints.Count >= 3)//三点以上の場合のみ
                    {
                        var (xMax, xMin) = ((int)(manualMaskPoints.Max(p => p.X) + 0.5), (int)(manualMaskPoints.Min(p => p.X) + 0.5));
                        var (yMax, yMin) = ((int)(manualMaskPoints.Max(p => p.Y) + 0.5), (int)(manualMaskPoints.Min(p => p.Y) + 0.5));
                        for (int j = Math.Max(yMin, 0); j <= Math.Min(yMax, SrcImgSize.Height - 1); j++)
                            for (int i = Math.Max(xMin, 0); i <= Math.Min(xMax, SrcImgSize.Width - 1); i++)
                                if (Geometry.InsidePolygonalArea(manualMaskPoints, new PointD(i, j)))
                                    Ring.IsSpots[j * SrcImgSize.Width + i] = e.Button == MouseButtons.Left;
                    }
                    manualMaskPoints.Clear();
                }
                Draw();
                return true;//マウスイベント終了
            }

            else if (FormProperty.radioButtonManualSpline.Checked)//スプラインモード
            {
                if (e.Clicks == 1 && e.Button == MouseButtons.Left)//追加
                {
                    bool flag = true;
                    foreach (PointD p in manualMaskPoints)
                        if (p.X == pt.X && p.Y == pt.Y)
                            flag = false;
                    if (flag)
                        manualMaskPoints.Add(pt);
                    Draw();
                    return true;//マウスイベント終了
                }
                else if (e.Clicks == 1 && e.Button == MouseButtons.Right)//削除
                {
                    double minDistance = double.MaxValue;
                    int index = 0;

                    for (int i = 0; i < manualMaskPoints.Count; i++)
                    {
                        PointD p = scalablePictureBox.ConvertToClientPt(manualMaskPoints[i]);
                        if ((p.X - e.X) * (p.X - e.X) + (p.X - e.X) * (p.X - e.X) < minDistance)
                        {
                            minDistance = (p.X - e.X) * (p.X - e.X) + (p.X - e.X) * (p.X - e.X);
                            index = i;
                        }
                    }
                    if (minDistance < 26)//距離が十分近かったら
                    {
                        manualMaskPoints.RemoveAt(index);
                        setSpline();
                        return true;//マウスイベント終了
                    }
                    else
                        return false;//マウスイベント続行
                }

                else if (e.Clicks == 2)
                {
                    if (e.Button == MouseButtons.Left)
                    {
                        manualMaskPoints.RemoveAt(manualMaskPoints.Count - 1);
                        setSpline();
                    }

                    if (manualMaskPoints.Count > 2)
                    {
                        for (int i = 0; i < splineTemp.Count; i++)
                            if (splineTemp[i])
                                Ring.IsSpots[i] = e.Button == MouseButtons.Left;
                    }
                    manualMaskPoints.Clear();
                    setSpline();
                    Draw();
                }
            }

        }

        else if (e.Button == MouseButtons.Left && e.Clicks == 1)
        {
            sw.Reset();
            sw.Start();
            if (FormDrawRing.Visible && FormDrawRing.R > 0)
            {//左シングルかつリング表示時
                //クリックした点の付近5pt以内にリングがあるときはリング選択モードへ
                //まず現在のマウス位置のR値を求める
                double x = (pt.X - IP.CenterX) * IP.PixSizeX + (pt.Y - IP.CenterY) * IP.PixSizeY * Math.Tan(IP.ksi);
                double y = (pt.Y - IP.CenterY) * IP.PixSizeY;
                double SinTau = Math.Sin(IP.tau), CosTau = Math.Cos(IP.tau);
                double SinPhi = Math.Sin(IP.phi), CosPhi = Math.Cos(IP.phi);
                double newX = (y * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + x * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);
                double newY = (x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + y * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);

                double r = Math.Sqrt(newX * newX + newY * newY);
                //現在のマウス座標からｘ、ｙとも外へ5ptずつ寄せる
                pt = scalablePictureBox.ConvertToSrcPt(
                    new PointD(pt.X - IP.CenterX > 0 ? e.X + 5 : e.X - 5, pt.Y - IP.CenterY > 0 ? e.Y + 5 : e.Y - 5));
                x = (pt.X - IP.CenterX) * IP.PixSizeX + (pt.Y - IP.CenterY) * IP.PixSizeY * Math.Tan(IP.ksi);
                y = (pt.Y - IP.CenterY) * IP.PixSizeY;
                newX = (y * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + x * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);
                newY = (x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + y * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);
                double devR = Math.Sqrt(newX * newX + newY * newY) - r;

                //もし範囲内にリングがあれば。。。
                IsRingSelectMode = Math.Abs(FormDrawRing.R - r) < devR;

                sw.Stop();
                sw.Reset();
            }
        }
        else if (toolStripButtonFixCenter.Checked == false)
            if ((e.Button == MouseButtons.Left && e.Clicks == 2) || e.Button == MouseButtons.Middle)
            {//左ダブルクリックかつリング非表示時 あるいは　中ボタンクリック時
                //PointF pt = ConvertToSrcPt(SrcRectF, ClientRect, new PointF(e.X, e.Y));

                FormProperty.DirectSpotPosition = new PointD(pt.X, pt.Y);
                int x = (int)(pt.X + 0.5);
                int y = (int)(pt.Y + 0.5);
                TableCenterPt = new Point(x, y);
                //if (FormIntTable != null)
                //    FormIntTable.SetData(x, y);

                if (e.Button == MouseButtons.Middle)
                    toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
                Draw();

                sw.Stop();
                sw.Reset();
            }

        return false;


    }

    //マウス移動時
    private bool scalablePictureBox_MouseMove2(object sender, MouseEventArgs e, PointD pt)
    {
        if (!IsImageReady) return false;

        //マウス位置のピクセル情報　ここから
        int X = (int)(pt.X + 0.5);
        int Y = (int)(pt.Y + 0.5);
        double r = 0, chi = 0, newX = 0, newY = 0;
        try
        {
            //まず現在のマウス位置のR値を求める
            double x = (pt.X - IP.CenterX) * IP.PixSizeX + (pt.Y - IP.CenterY) * IP.PixSizeY * Math.Tan(IP.ksi);
            double y = (pt.Y - IP.CenterY) * IP.PixSizeY;
            double SinTau = Math.Sin(IP.tau), CosTau = Math.Cos(IP.tau);
            double SinPhi = Math.Sin(IP.phi), CosPhi = Math.Cos(IP.phi);
            newX = (y * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + x * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);
            newY = (x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + y * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);

            r = Math.Sqrt(newX * newX + newY * newY);
            chi = Math.Atan2(newY, newX);
            #region chi角の設定
            if (FormProperty.radioButtonChiClockwise.Checked)
            {
                if (FormProperty.radioButtonChiBottom.Checked)
                    chi -= Math.PI / 2;
                else if (FormProperty.radioButtonChiLeft.Checked)
                    chi -= Math.PI;
                else if (FormProperty.radioButtonChiTop.Checked)
                    chi -= Math.PI * 1.5;
            }
            else
            {
                chi = -chi;
                if (FormProperty.radioButtonChiBottom.Checked)
                    chi -= Math.PI * 1.5;
                else if (FormProperty.radioButtonChiLeft.Checked)
                    chi -= Math.PI;
                else if (FormProperty.radioButtonChiTop.Checked)
                    chi -= Math.PI / 2;
            }
            if (chi < -Math.PI)
                chi += 2 * Math.PI;
            if (chi > Math.PI)
                chi -= 2 * Math.PI;
            #endregion
        }
        catch { r = 0; }

        # region 画面にマウス座標を表示
        if (X >= 0 && Ring.Intensity != null && X + Y * SrcImgSize.Width > -1 && X + Y * SrcImgSize.Width < Ring.Intensity.Length)
        {
            labelMousePointPixel.Text = $"{X,5},{Y,5}";
            labelMousePointReal.Text = $"{newX,7:f3}, {newY,7:f3}";
            labelMousePointIntensity.Text = Ring.Intensity[X + Y * SrcImgSize.Width].ToString();
            labelMousePointR.Text = r.ToString("f2");
            var theta = Math.Atan2(r, IP.FilmDistance);
            labelMousePointTheta.Text = $"{180.0 / Math.PI * theta:f3}°";
            labelMousePointD.Text = $"{IP.WaveLength / 2 * 10 / Math.Sin(theta / 2):f3}Å";
            labelMousePointChi.Text = $"{180.0 / Math.PI * chi:f2}°";
            if (pseudoBitmap != null)
                labelResolution.Text = $"Mag: {scalablePictureBox.Zoom:f2}";
        }
        #endregion

        if (IsRingSelectMode)
        {
            FormDrawRing.SetR(r);
            return true;//マウス左ボタンによる平行移動をキャンセル
        }
        //スポット選択モードのとき
        else if (FormProperty.checkBoxManualMaskMode.Checked)
        {
            if (FormProperty.radioButtonManualCircle.Checked && manualMaskPoints.Count == 1)//サークルモードの時
            {
                double radius = (manualMaskPoints[0] - pt).Length;
                for (int j = Math.Max((int)Math.Round(manualMaskPoints[0].Y - radius), 0); j <= Math.Min((int)Math.Round(manualMaskPoints[0].Y + radius), SrcImgSize.Height - 1); j++)
                    for (int i = Math.Max((int)Math.Round(manualMaskPoints[0].X - radius), 0); i <= Math.Min((int)Math.Round(manualMaskPoints[0].X + radius), SrcImgSize.Width - 1); i++)
                        if ((i - manualMaskPoints[0].X) * (i - manualMaskPoints[0].X) + (j - manualMaskPoints[0].Y) * (j - manualMaskPoints[0].Y) <= radius * radius)
                            pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
            }
            else if (FormProperty.radioButtonManualRectangle.Checked && manualMaskPoints.Count == 1)//矩形モードの時
            {
                for (int j = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].Y, pt.Y) + 0.5)); j <= Math.Min(SrcImgSize.Height - 1, (int)(Math.Max(manualMaskPoints[0].Y, pt.Y) + 0.5)); j++)
                    for (int i = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].X, pt.X) + 0.5)); i <= Math.Min(SrcImgSize.Width - 1, (int)(Math.Max(manualMaskPoints[0].X, pt.X) + 0.5)); i++)
                        pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
            }
            else if (FormProperty.radioButtonManualPolygon.Checked && manualMaskPoints.Count >= 2)//ポリゴンモードの時
            {
                var pts = new List<PointD>(manualMaskPoints) { pt };
                var (xMax, xMin) = ((int)(pts.Max(p => p.X) + 0.5), (int)(pts.Min(p => p.X) + 0.5));
                var (yMax, yMin) = ((int)(pts.Max(p => p.Y) + 0.5), (int)(pts.Min(p => p.Y) + 0.5));

                for (int j = Math.Max(yMin, 0); j <= Math.Min(yMax, SrcImgSize.Height - 1); j++)
                    for (int i = Math.Max(xMin, 0); i <= Math.Min(xMax, SrcImgSize.Width - 1); i++)
                        if (Geometry.InsidePolygonalArea(pts, new PointD(i, j)))
                            pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
            }
            else if (FormProperty.radioButtonManualSpline.Checked)//スプラインモードの時
            {
                if (splineTemp.Count == pseudoBitmap.FilterTemporary.Count)
                {
                    pseudoBitmap.FilterTemporary.Clear();
                    pseudoBitmap.FilterTemporary.AddRange([.. splineTemp]);
                    Draw();

                }
                return false;//イベント続行
            }
            else if (FormProperty.radioButtonManualSpot.Checked)//スポットモードの時
            {
                for (int j = Math.Max((int)Math.Round(pt.Y - SpotsSize), 0); j <= Math.Min((int)Math.Round(pt.Y + SpotsSize), SrcImgSize.Height - 1); j++)
                    for (int i = Math.Max((int)Math.Round(pt.X - SpotsSize), 0); i <= Math.Min((int)Math.Round(pt.X + SpotsSize), SrcImgSize.Width - 1); i++)
                        if (!FormProperty.radioButtonCircle.Checked || (i - pt.X) * (i - pt.X) + (j - pt.Y) * (j - pt.Y) <= SpotsSize * SpotsSize)
                            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
                                Ring.IsSpots[j * SrcImgSize.Width + i] = e.Button == MouseButtons.Left;
                            else if (e.Button == MouseButtons.None)
                                pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
            }

            Draw();
            return true;
        }
        return false;
    }


    //マウスボタンアップ
    private bool scalablePictureBox_MouseUp2(object sender, MouseEventArgs e, PointD pt)
    {
        if (!IsImageReady) return true;
        if (IsRingSelectMode)
            IsRingSelectMode = false;

        #region お蔵入り
        //一秒以上左クリック長押し
        /*    if (e.Button == MouseButtons.Left && sw.ElapsedMilliseconds > 1000 && !FormProperty.checkBoxManualMaskMode.Checked)
            {
                SetIntegralProperty();
                int pixel = (int)FormProperty.numericUpDownFindCenterSearchRange.Value;
                double[,] tempIntensity = new double[pixel * 2 + 1, pixel * 2 + 1];
                int i, j;
                for (i = 0; i < pixel * 2 + 1; i++)
                    for (j = 0; j < pixel * 2 + 1; j++)
                        tempIntensity[i, j] = Ring.Intensity[((int)(pt.Y - pixel) + j) * IP.SrcWidth + (int)((pt.X - pixel) + i)];
                PointD offset = FittingPeak.FitPeakAsPseudoVoigtByMarcal2D(tempIntensity);

                if (double.IsInfinity(offset.X)) return false;
                selectedSpot = new PointD(offset.X + (int)(pt.X - pixel), offset.Y + (int)(pt.Y - pixel));

                double x = (selectedSpot.X - IP.CenterX) * IP.PixSizeX + (selectedSpot.Y - IP.CenterY) * IP.PixSizeY * Math.Tan(IP.ksi);
                double y = (selectedSpot.Y - IP.CenterY) * IP.PixSizeY;
                double SinTau = Math.Sin(IP.tau), CosTau = Math.Cos(IP.tau);
                double SinPhi = Math.Sin(IP.phi), CosPhi = Math.Cos(IP.phi);
                double newX = (y * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + x * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);
                double newY = (x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + y * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                    * IP.FilmDistance / (y * CosPhi * SinTau + IP.FilmDistance - x * SinPhi * SinTau);

                double r = Math.Sqrt(newX * newX + newY * newY);
                string rStr = "R: " + r.ToString("f3") + "mm";
                double chi = Math.Atan2(newY, newX);
                double theta = Math.Atan2(r, IP.FilmDistance);
                string thetaStr = "2θ: " + (theta / Math.PI * 180.0).ToString("f3") + "°";
                string dStr = "d:" + (IP.WaveLength / 2 * 10 / Math.Sin(theta / 2)).ToString("f3") + "Å";
                string chiStr = "chi: " + (180.0 / Math.PI * chi).ToString("f3") + "°";
                Draw();
                MessageBox.Show("Image　Coord. X: " + selectedSpot.X.ToString("f3") + ", Y: " + selectedSpot.Y.ToString("f3") +
                    "\r\nReal Coord. X: " + newX.ToString("f3") + "mm, Y: " + newY.ToString("f3") + "mm" +
                    "\r\n" + rStr + "\r\n" + thetaStr + "\r\n" + dStr + "\r\n" + chiStr);
                selectedSpot = null;
                Draw();
                sw.Stop();
                sw.Reset();
                return true;
            }

            else */

        #endregion

        if (FormProperty.checkBoxManualMaskMode.Checked)//マスクモード時
        {
            if (FormProperty.radioButtonManualCircle.Checked)//サークルモードの時
            {
                if (manualMaskPoints.Count == 1)
                {
                    double r = (manualMaskPoints[0] - pt).Length;

                    for (int j = Math.Max((int)Math.Round(manualMaskPoints[0].Y - r), 0); j <= Math.Min((int)Math.Round(manualMaskPoints[0].Y + r), SrcImgSize.Height - 1); j++)
                        for (int i = Math.Max((int)Math.Round(manualMaskPoints[0].X - r), 0); i <= Math.Min((int)Math.Round(manualMaskPoints[0].X + r), SrcImgSize.Width - 1); i++)
                            if ((i - manualMaskPoints[0].X) * (i - manualMaskPoints[0].X) + (j - manualMaskPoints[0].Y) * (j - manualMaskPoints[0].Y) <= r * r)
                                Ring.IsSpots[j * SrcImgSize.Width + i] = e.Button == MouseButtons.Left;

                }
                manualMaskPoints.Clear();
                Draw();
            }
            else if (FormProperty.radioButtonManualRectangle.Checked)//矩形モードの時
            {
                if (manualMaskPoints.Count == 1)
                {
                    for (int j = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].Y, pt.Y) + 0.5)); j <= Math.Min(SrcImgSize.Height - 1, (int)(Math.Max(manualMaskPoints[0].Y, pt.Y) + 0.5)); j++)
                        for (int i = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].X, pt.X) + 0.5)); i <= Math.Min(SrcImgSize.Width - 1, (int)(Math.Max(manualMaskPoints[0].X, pt.X) + 0.5)); i++)
                            Ring.IsSpots[j * SrcImgSize.Width + i] = e.Button == MouseButtons.Left;
                }
                manualMaskPoints.Clear();
                Draw();
            }
            else if (FormProperty.radioButtonManualSpot.Checked)
            {
                for (int j = Math.Max((int)Math.Round(pt.Y - SpotsSize), 0); j <= Math.Min((int)Math.Round(pt.Y + SpotsSize), SrcImgSize.Height - 1); j++)
                    for (int i = Math.Max((int)Math.Round(pt.X - SpotsSize), 0); i <= Math.Min((int)Math.Round(pt.X + SpotsSize), SrcImgSize.Width - 1); i++)
                        if (!FormProperty.radioButtonCircle.Checked || (i - pt.X) * (i - pt.X) + (j - pt.Y) * (j - pt.Y) <= SpotsSize * SpotsSize)
                            Ring.IsSpots[j * SrcImgSize.Width + i] = e.Button == MouseButtons.Left;
                Draw();
                return false;
            }

        }
        else if (scalablePictureBox.ShowAreaRectangle)//AreaRectangle情報表示の場合
        {
            var rect = scalablePictureBox.AreaRectangle;
            decimal oldX1 = numericUpDownSelectedAreaX1.Value, oldY1 = numericUpDownSelectedAreaY1.Value, oldX2 = numericUpDownSelectedAreaX2.Value, oldY2 = numericUpDownSelectedAreaY2.Value;
            skipSelectedAreaChangedEvent = true;
            numericUpDownSelectedAreaX1.Value = (int)(rect.X + 1);
            numericUpDownSelectedAreaY1.Value = (int)(rect.Y + 1);
            numericUpDownSelectedAreaX2.Value = (int)(rect.X + rect.Width);
            numericUpDownSelectedAreaY2.Value = (int)(rect.Y + rect.Height);
            skipSelectedAreaChangedEvent = false;
            if (oldX1 != numericUpDownSelectedAreaX1.Value || oldY1 != numericUpDownSelectedAreaY1.Value || oldX2 != numericUpDownSelectedAreaX2.Value || oldY2 != numericUpDownSelectedAreaY2.Value)
            {
                numericUpDownSelectedArea_ValueChanged(sender, e);
                tabControl1.SelectedIndex = 2;
            }
        }

        return false;

    }

    //マウスホイール
    private bool scalablePictureBox_MouseWheel2(object sender, MouseEventArgs e, PointD pt)
    {
        if (FormProperty.checkBoxManualMaskMode.Checked && FormProperty.radioButtonManualSpot.Checked)
        {
            if (e.Delta > 0)
                FormProperty.numericUpDownManualSpotSize.Value = Math.Min(FormProperty.numericUpDownManualSpotSize.Maximum, FormProperty.numericUpDownManualSpotSize.Value + 1);
            else
                FormProperty.numericUpDownManualSpotSize.Value = Math.Max(FormProperty.numericUpDownManualSpotSize.Minimum, FormProperty.numericUpDownManualSpotSize.Value - 1);

            scalablePictureBox_MouseMove2(sender, e, pt);
            return true;
        }
        return false;
    }

    #endregion

    #region リサイズ イベント
    public void FormMain_Resize(object sender, EventArgs e) => Draw();

    private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e) => FormMain_Resize(new object(), new EventArgs());
    #endregion

    #region 輝度調節関係
    public bool SkipMax = false;
    public bool SkipMin = false;
    //NumetricUpDownpseudBitmap.MaxValue変更時


    private bool trackBarAdvancedMaxInt_ValueChanged(object sender, double value)
    {
        if (SkipMax) return true;
        SkipMax = true;

        pseudoBitmap.MaxValue = trackBarAdvancedMaxInt.Value;

        if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
            trackBarAdvancedMinInt.Value = trackBarAdvancedMaxInt.Value - 1;

        if (graphControlFrequency.VerticalLines != null && graphControlFrequency.VerticalLines.Length == 2)
        {
            graphControlFrequency.VerticalLines = [new PointD(trackBarAdvancedMinInt.Value, double.NaN), new PointD(trackBarAdvancedMaxInt.Value, double.NaN)];
            graphControlFrequency.Draw();
            graphControlFrequency.Refresh();
        }

        Draw();
        SkipMax = false;
        return true;
    }

    private bool trackBarAdvancedMinInt_ValueChanged(object sender, double value)
    {
        if (SkipMin) return true;
        SkipMin = true;
        pseudoBitmap.MinValue = trackBarAdvancedMinInt.Value;

        if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
            trackBarAdvancedMaxInt.Value = trackBarAdvancedMinInt.Value + 1;

        if (graphControlFrequency.VerticalLines != null && graphControlFrequency.VerticalLines.Length == 2)
        {
            graphControlFrequency.VerticalLines = [new PointD(trackBarAdvancedMinInt.Value, double.NaN), new PointD(trackBarAdvancedMaxInt.Value, double.NaN)];
            graphControlFrequency.Draw();
            graphControlFrequency.Refresh();
        }

        Draw();
        SkipMin = false;
        return true;
    }

    //AutoAdjustボタンクリック時
    public void buttonAutoLevel_Click(object sender, System.EventArgs e)
    {
        if (variance != 0)
        {
            pseudoBitmap.MaxValue = trackBarAdvancedMaxInt.Value = Math.Min(sumOfIntensity / Ring.Intensity.Length + 2 * variance, trackBarAdvancedMaxInt.Maximum);
            pseudoBitmap.MinValue = trackBarAdvancedMinInt.Value = Math.Max(sumOfIntensity / Ring.Intensity.Length - 2 * variance, trackBarAdvancedMinInt.Minimum);
            Draw();
        }

    }
    //Resetボタンクリック時
    private void buttonReset_Click(object sender, System.EventArgs e)
    {
        if (!IsImageReady) return;
        trackBarAdvancedMaxInt.Maximum = 65535;
        trackBarAdvancedMinInt.Maximum = 65534;
        trackBarAdvancedMaxInt.Value = 65535;
        trackBarAdvancedMinInt.Value = 0;
        pseudoBitmap.MaxValue = 65535;
        pseudoBitmap.MinValue = 0;
        Draw();
    }
    #endregion

    #region ドラッグドロップ
    private void FormMain_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
        else

            e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
    }

    private void FormMain_DragDrop(object sender, DragEventArgs e)
    {
        //コントロール内にドロップされたとき実行される
        //ドロップされたすべてのファイル名を取得する
        string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
        //ListBoxに追加する
        if (fileName.Length == 1)
        {
            string ext = Path.GetExtension(fileName[0]).TrimStart(['.']);
            if (ImageIO.IsReadable(ext))
                ReadImage(fileName[0]);
            else if (fileName[0].EndsWith("prm"))
                ReadParameter(fileName[0], (e.KeyState & 8) != 8);//8はCTRLキーを表す
            else if (fileName[0].EndsWith("mas"))
                ReadMask(fileName[0]);
            else if (Directory.Exists(fileName[0]))
            {
                var files = Directory.GetFiles(fileName[0]);
                if (files != null && files.Length > 0)
                {
                    ext = Path.GetExtension(files[0]).TrimStart(['.']);
                    if (ImageIO.IsReadable(ext))
                        ReadImage(files[0]);
                    initialImageDirectory = Path.GetDirectoryName(files[0]);
                }
            }
        }

    }
    #endregion

    #region File メニュー イメージの読み書き

    public int filterIndex;
    public string initialImageDirectory = "";

    /// <summary>
    /// Read Image ボタン
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void readImageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog { Filter = ImageIO.FilterString + "|All files(*.*)|*.*", FilterIndex = filterIndex };

        if (initialImageDirectory != "")
            dlg.InitialDirectory = initialImageDirectory;

        if (dlg.ShowDialog() == DialogResult.OK)
        {
            ReadImage(dlg.FileName);
            filterIndex = dlg.FilterIndex;
            initialImageDirectory = Path.GetDirectoryName(dlg.FileName);
        }
    }

    delegate void ReadImageCallBack(string str, bool? flag = null);
    /// <summary>
    /// 画像を読み込む
    /// </summary>
    /// <param name="str"></param>
    /// <param name="flag"></param>
    public void ReadImage(string str, bool? flag = null)
    {
        SkipDrawing = true;

        if (str != "ClipBoard.ipa" && !File.Exists(str)) return;  // ファイルの有無をチェック

        //改行文字が含まれている場合は、それを削除
        str = str.TrimEnd('\n');
        str = str.TrimEnd('\r');

        if (this.InvokeRequired)//別スレッド(ファイル更新監視スレッド)から呼び出されたとき
        {
            ReadImageCallBack d = new ReadImageCallBack(ReadImage);
            this.Invoke(d, [str, flag]);
            return;
        }

        //直前に読み込まれている画像が存在するかどうか
        var lastImageExist = scalablePictureBox.PseudoBitmap.Height != 0;

        //ファイルを読み込む前に直前のイメージタイプの情報を保存
        FormProperty.SaveParameterForEachImageType(Ring.ImageType);
        IsImageReady = false;
        toolStripButtonImageSequence.Enabled = false;
        toolStripButtonImageSequence.Checked = false;

        //直前のマスク情報を保存
        var justBeforeImageSize = Ring.SrcImgSize;
        var justBeforeMask = Ring.IsSpots.ToArray();

        //直前の描画範囲を保存
        var justBeforeZoomAndCenter = scalablePictureBox.ZoomAndCenter;

        //直前の最小・最大強度を保存
        var justBeforeMin = trackBarAdvancedMinInt.Value;
        var justBeforeMax = trackBarAdvancedMaxInt.Value;


        if (!ImageIO.ReadImage(str, flag))
            return;

        string ext = Path.GetExtension(str).TrimStart(['.']).ToLower();
        if (ext == "ipa")
        {
            FormProperty.waveLengthControl.Property = Ring.IP.WaveProperty;
            FormProperty.CameraLength1 = Ring.IP.FilmDistance;
            FormProperty.numericBoxPixelSizeX.Value = Ring.IP.PixSizeX;
            FormProperty.numericBoxPixelSizeY.Value = Ring.IP.PixSizeY;
            FormProperty.DirectSpotPosition = new PointD(Ring.IP.CenterX, Ring.IP.CenterY);
            FormProperty.numericBoxTiltPhi.Value = FormProperty.numericBoxTiltTau.Value = FormProperty.numericBoxPixelKsi.Value = 0;
        }
        else if (ext == "h5")
        {
            FormProperty.numericBoxPixelSizeX.Value = Ring.IP.PixSizeX;
            FormProperty.numericBoxPixelSizeY.Value = Ring.IP.PixSizeY;
            if (Ring.IP.SrcWidth == 1024 && Ring.IP.SrcHeight == 1024)
                toolStripButtonFixCenter.Checked = true;
        }

        SrcImgSize = Ring.SrcImgSize;

        initializeFilter();
        setScale();
        FormProperty.checkBoxThreshold_CheckedChanged(new object(), new EventArgs());
        IsImageReady = true;
        //IntegralArea_Changed(new object(), new EventArgs());


        Ring.CalcFreq();
        SetFrequencyProfile();//強度頻度グラフを作成
        graphControlProfile.Profile = new Profile();//プロファイルは初期化

        var (min, max) = Ring.Intensity.MinMax();
        trackBarAdvancedMaxInt.Maximum = trackBarAdvancedMinInt.Maximum = max;
        trackBarAdvancedMinInt.Minimum = trackBarAdvancedMaxInt.Minimum = min;

        //直前に画像が読み込まれていた場合、マスク、描画強度、描画範囲の引継ぎ
        if (lastImageExist)
        {
            //マスクの引継ぎ処理
            if (FormProperty.radioButtonTakeoverMask.Checked)
            {
                if (Ring.IsSpots.Length == justBeforeMask.Length)
                    for (int i = 0; i < Ring.IsSpots.Length; i++)
                        if (Ring.IsSpots[i] != justBeforeMask[i])
                            Ring.IsSpots[i] = justBeforeMask[i];
            }
            else if (FormProperty.radioButtonTakeOverMaskfile.Checked && justBeforeMaskFile != "")
                ReadMask(justBeforeMaskFile);

            //描画範囲の引継ぎ
            if (FormProperty.MaintainImageRange)
                scalablePictureBox.ZoomAndCenter = justBeforeZoomAndCenter;

            //描画強度の引継ぎ
            trackBarAdvancedMinInt.Value = FormProperty.MaintainImageContrast ? justBeforeMin : min;
            trackBarAdvancedMaxInt.Value = FormProperty.MaintainImageContrast ? justBeforeMax : max;
        }
        else
        {
            trackBarAdvancedMinInt.Value = min;
            trackBarAdvancedMaxInt.Value = max;
        }

        graphControlFrequency.VerticalLines = [new(trackBarAdvancedMinInt.Value, double.NaN), new PointD(trackBarAdvancedMaxInt.Value, double.NaN)];


        FileName = str[(str.LastIndexOf('\\') + 1)..];
        string oldFilePath = FilePath;
        FilePath = str[..(str.LastIndexOf('\\') + 1)];

        SetText(FileName);

        SetInformation();

        //SP8-BL43LXUのような32bit signed tiffの場合は、負の値をマスク
        if (ext.StartsWith("tif") && Ring.Intensity.Min() <= 0)
        {
            for (int i = 0; i < Ring.Intensity.Length; i++)
                if (Ring.Intensity[i] < 0)
                    Ring.IsSpots[i] = true;
        }

        //SequentialImageを読み込んだ時の処理
        if (Ring.SequentialImageIntensities != null)
        {
            if (Ring.SequentialImageIntensities.Count >= 2)
            {
                SequentialImageMode = true;
                toolStripButtonImageSequence.Checked = true;
            }
            FormSequentialImage.MaximumNumber = Ring.SequentialImageIntensities.Count;

            if (Ring.SequentialImageIntensities.Count >= 2)
                FormSequentialImage.SelectedIndex = 0;

            trackBarAdvancedMaxInt.Maximum = Ring.SequentialImageIntensities.Max(i => i.Max());
            trackBarAdvancedMinInt.Maximum = trackBarAdvancedMaxInt.Maximum - 1;

        }
        bool renewEnergy = true;//hdfファイルのように、エネルギーが埋め込まれているファイルへの対応
        if (Ring.SequentialImageIntensities != null
            && Ring.SequentialImageEnergy != null
            && Ring.SequentialImageIntensities.Count == Ring.SequentialImageEnergy.Count)
            renewEnergy = false;

        //偏光補正、FlipRotation, Background補正は、SetParameterFromImageTypeで実行される
        if (Ring.ImageType != Ring.ImageTypeEnum.IPAImage)
            FormProperty.SetParameterFromImageType(Ring.ImageType, renewEnergy);

        //DigitalMicrographのファイルに関しては、ファイル情報のパラメータと現在のパラメータのずれが大きすぎる場合、ファイル情報のパラメータをセットする
        if (ext.StartsWith("dm"))
        {
            FormProperty.waveLengthControl.WaveSource = WaveSource.Electron;

            var acc = Ring.DigitalMicrographProperty.AccVoltage;
            var size = Ring.DigitalMicrographProperty.PixelSizeInMicron / 1000;
            var scale = Ring.DigitalMicrographProperty.PixelScale;

            if (Math.Abs(FormProperty.waveLengthControl.Energy * 1000 - acc) / acc > 0.2)
                FormProperty.waveLengthControl.Energy = acc / 1000;

            if (Math.Abs((FormProperty.numericBoxPixelSizeX.Value - size) / size) > 0.2)
            {
                FormProperty.numericBoxPixelSizeX.Value = size;
                FormProperty.numericBoxPixelSizeY.Value = size;
                FormProperty.numericBoxPixelKsi.Value = 0;
            }
            double length = size / Math.Tan(2 * FormProperty.waveLengthControl.WaveLength * scale / 2);
            if (Math.Abs((FormProperty.CameraLength1 - length) / length) > 0.2)
                FormProperty.CameraLength1 = length;
        }

        SkipDrawing = false;
        Draw();

        if (FormAutoProc.checkBoxAutoAfterLoad.Checked)
            FormAutoProc.ExecuteAutoProcedure();
    }

    public void SetInformation()
    {
        var (min, max) = Ring.Intensity.MinMax();
        textBoxInformation.Text =
            $"Fine name:\r\n {FileName}\r\n" +
            $"Size:\r\n {SrcImgSize.Width}*{SrcImgSize.Height}\r\n" +
            $"Dynamic range:\r\n {min} - {max:#,#}\r\n" +
            $"Max Intensity:\r\n {maxIntensity:#,#}\r\n" +
            $"Sum Intensity:\r\n {sumOfIntensity:#,#}\r\n" +
            $"Ave. Intensity:\r\n {sumOfIntensity / Ring.Intensity.Length:#,#.####}\r\n\r\n" +
            $"{Ring.Comments}";

        if (Ring.SequentialImagePulsePower != null && Ring.SequentialImagePulsePower.Count == Ring.SequentialImageIntensities.Count)//イメージごとにエネルギーが設定されているとき
        {
            if (Ring.SequentialImageIntensities.Count == 1)
                textBoxInformation.Text += $"\r\nPulse Power: {Ring.SequentialImagePulsePower[0]}";
            else if (FormSequentialImage.SelectedIndex > -1)
                textBoxInformation.Text += $"\r\nPulse Power: {Ring.SequentialImagePulsePower[FormSequentialImage.SelectedIndex]}";
        }
    }

    public void initializeFilter()
    {
        if (Ring.IsValid.Length != Ring.Intensity.Length)
        {
            Ring.IsValid = [.. Enumerable.Repeat(true, Ring.Intensity.Length)];
            Ring.IsOutsideOfIntegralRegion = new bool[Ring.Intensity.Length];
            Ring.IsSpots = new bool[Ring.Intensity.Length];
            Ring.IsThresholdOver = new bool[Ring.Intensity.Length];
            Ring.IsThresholdUnder = new bool[Ring.Intensity.Length];
            Ring.IsOutsideOfIntegralProperty = new bool[Ring.Intensity.Length];
        }
        else
        {
            for (int i = 0; i < Ring.Intensity.Length; i++)
            {
                Ring.IsValid[i] = true;
                Ring.IsOutsideOfIntegralRegion[i] = false;
                Ring.IsOutsideOfIntegralProperty[i] = false;
                Ring.IsSpots[i] = false;
                Ring.IsThresholdOver[i] = false;
                Ring.IsThresholdUnder[i] = false;
            }
        }
        pseudoBitmap = new PseudoBitmap(Ring.Intensity.ToArray(), SrcImgSize.Width)
        {
            Filter1 = [.. Ring.IsThresholdOver],
            Filter2 = [.. Ring.IsThresholdUnder],
            Filter3 = [.. Ring.IsSpots],
            Filter4 = [.. Ring.IsOutsideOfIntegralRegion],
            Filter5 = [.. Ring.IsOutsideOfIntegralProperty]
        };
        pseudoBitmap.FilterTemporary.AddRange(new bool[SrcImgSize.Width * SrcImgSize.Height]);
        pseudoBitmap.MaxValue = trackBarAdvancedMaxInt.Value;
        pseudoBitmap.MinValue = trackBarAdvancedMinInt.Value;
        scalablePictureBox.PseudoBitmap = pseudoBitmap;
        scalablePictureBoxThumbnail.PseudoBitmap = pseudoBitmap;
        setScale();
    }

    public static void SetBytePosition(string str, ref BinaryReader br, int count)
    {
        br.Close();
        br = new BinaryReader(new FileStream(str, FileMode.Open, FileAccess.Read));
        br.ReadBytes(count);
    }

    //画像を保存する

    //Tiff形式
    private void tiffToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SrcImgSize.Width == 0) return;
        saveImageAsTiff();
    }

    private void saveImageAsTiff(string filename = "")
    {
        if (SrcImgSize.Width == 0) return;

        if (filename == "")
        {
            var dlg = new SaveFileDialog() { Filter = "*.tif|*.tif" };
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }
        else if (!filename.ToLower().EndsWith(".tif"))
            filename += ".tif";

        //通常 Imageのとき
        if (!toolStripButtonUnroll.Checked)
        {
            //複数画像モードの時
            if (Ring.SequentialImageIntensities != null && Ring.SequentialImageIntensities.Count > 1)
            {
                var d = new double[Ring.SequentialImageIntensities.Count][];
                for (int i = 0; i < d.Length; i++)
                {
                    //d[i] = Ring.SequentialImageIntensities[i].ToArray();

                    //Flip and Rotate
                    d[i] = [.. Ring.FlipAndRotate(Ring.SequentialImageIntensities[i], Ring.IP.SrcWidth,
                            flipVerticallyToolStripMenuItem.Checked,
                            flipHorizontallyToolStripMenuItem.Checked,
                            toolStripComboBoxRotate.SelectedIndex)];

                    //Background
                    if (Ring.Background != null && Ring.Background.Length == d[i].Length)
                        d[i] = [.. Ring.SubtractBackground(d[i], Ring.Background, FormProperty.numericBoxBackgroundCoeff.Value)];

                    //偏光補正
                    if (FormProperty != null && FormProperty.checkBoxCorrectPolarization.Checked)
                        d[i] = [.. Ring.CorrectPolarization(toolStripComboBoxRotate.SelectedIndex, d[i])];
                }
                if (Ring.SequentialImageEnergy != null && Ring.SequentialImageEnergy.Count == Ring.SequentialImageIntensities.Count)
                {//各画像にエネルギー値があるとき(h5ファイルの時)
                    var ifdEnergy = new List<Tiff.IFD>();
                    var ifdName = new List<Tiff.IFD>();
                    var ifdPulsePower = new List<Tiff.IFD>();
                    for (int i = 0; i < Ring.SequentialImageEnergy.Count; i++)
                    {
                        ifdEnergy.Add(new Tiff.IFD(60000, typeof(float), [Ring.SequentialImageEnergy[i]]));
                        ifdName.Add(new Tiff.IFD(60001, typeof(string), [Ring.SequentialImageNames[i]]));
                        if (Ring.PulsePowerNormarized)
                            ifdPulsePower.Add(new Tiff.IFD(60002, typeof(float), [-1.0]));
                        else
                            ifdPulsePower.Add(new Tiff.IFD(60002, typeof(float), [Ring.SequentialImagePulsePower[i]]));
                    }
                    Tiff.Writer(filename, d, 0, Ring.SrcImgSize.Width, [/*ifdEnergy.ToArray(), ifdName.ToArray(), */[.. ifdPulsePower]]);
                }
                else//h5ファイルではないとき
                    Tiff.Writer(filename, d, 0, Ring.SrcImgSize.Width);
            }
            //単一画像モードの時
            else
                Tiff.Writer(filename, [[.. Ring.Intensity]], 0, Ring.SrcImgSize.Width);
        }
        //Unrolled Imageのとき
        else
            Tiff.Writer(filename, [pseudoBitmap.SrcValuesGray], 3, pseudoBitmap.Width);
    }

    private void pngToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SrcImgSize.Width == 0) return;
        saveImageAsPng();
    }

    private void saveImageAsPng(string filename = "")
    {
        if (SrcImgSize.Width == 0) return;
        if (filename == "")
        {
            var dlg = new SaveFileDialog { Filter = "*.png|*.png" };
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }
        else if (!filename.ToLower().EndsWith(".png"))
            filename += ".png";

        var bmp = pseudoBitmap.GetImage(new RectangleD(new Point(0, 0), new Size(scalablePictureBox.PseudoBitmap.Width, scalablePictureBox.PseudoBitmap.Height))
            , new Size(scalablePictureBox.PseudoBitmap.Width, scalablePictureBox.PseudoBitmap.Height));

        if (toolStripButtonUnroll.Checked) //UnrolledImageの目盛を付ける
        {
            var bmpWithAxis = new Bitmap(bmp.Width + 40, bmp.Height + 40);
            var g = Graphics.FromImage(bmpWithAxis);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            var upper = (double)FormProperty.numericUpDownUnrolledImageXend.Value;
            var lower = (double)FormProperty.numericUpDownUnrolledImageXstart.Value;

            float gradiation;//ここより角度目盛りの描画
            var d = (upper - lower) / Math.Pow(10, (int)Math.Log10(upper - lower));
            if (d < 1.6) gradiation = (float)(Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
            else if (d < 3.2) gradiation = (float)(2 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
            else if (d < 8.0) gradiation = (float)(5 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
            else gradiation = (float)(10 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
            var pen = new Pen(Color.LightBlue, 1);
            var strFont = new Font(new FontFamily("tahoma"), 8);
            for (int i = (int)(lower / gradiation) + 1; i <= upper / gradiation; i++)
            {
                g.DrawLine(pen, 40 + bmp.Width * (i * gradiation - lower) / (upper - lower), bmp.Height, 40 + bmp.Width * (i * gradiation - lower) / (upper - lower), bmp.Height + 5);
                g.DrawString(Math.Round(i * gradiation, 5).ToString("#,#.###############"), strFont, Brushes.LightBlue,
                   new PointF(40 + bmp.Width * (float)(i * gradiation - lower) / (float)(upper - lower), bmp.Height + 5));
            }

            for (int i = 0; i <= 360; i += 30)
            {
                g.DrawLine(pen, 35, ((360 - i) / 360.0) * bmp.Height, 40, ((360 - i) / 360.0) * bmp.Height);
                g.DrawString(i.ToString("#,#.###############"), strFont, Brushes.LightBlue, new PointF(0, (float)((360 - i) / 360.0) * bmp.Height));
            }

            g.DrawImage(bmp, new Point(40, 0));
            bmp = bmpWithAxis;
        }

        bmp.Save(filename, ImageFormat.Png);
    }

    private void csvToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SrcImgSize.Width == 0) return;
        saveImageAsCSV();
    }

    public void saveImageAsCSV(string filename = "")
    {
        if (filename == "")
        {
            var dlg = new SaveFileDialog { Filter = "*.csv|*.csv" };
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }
        else if (!filename.ToLower().EndsWith(".csv"))
            filename += ".csv";

        try
        {
            using (StreamWriter writer = new StreamWriter(filename, false, Encoding.UTF8))
            {
                // 通常 Imageのとき
                if (!toolStripButtonUnroll.Checked)
                {
                    // 複数画像モードの時
                    if (Ring.SequentialImageIntensities != null && Ring.SequentialImageIntensities.Count > 1)
                    {
                        var d = new double[Ring.SequentialImageIntensities.Count][];
                        for (int i = 0; i < d.Length; i++)
                        {
                            var intensity = Ring.SequentialImageIntensities[i];

                            // Flip and Rotate
                            d[i] = [.. Ring.FlipAndRotate(Ring.SequentialImageIntensities[i], Ring.IP.SrcWidth,
                                flipVerticallyToolStripMenuItem.Checked,
                                flipHorizontallyToolStripMenuItem.Checked,
                                toolStripComboBoxRotate.SelectedIndex)];

                            // Background
                            if (Ring.Background != null && Ring.Background.Length == d[i].Length)
                                d[i] = [.. Ring.SubtractBackground(d[i], Ring.Background, FormProperty.numericBoxBackgroundCoeff.Value)];

                            // 偏光補正
                            if (FormProperty != null && FormProperty.checkBoxCorrectPolarization.Checked)
                                d[i] = [.. Ring.CorrectPolarization(toolStripComboBoxRotate.SelectedIndex, d[i])];

                            // CSVに書き出し
                            writer.WriteLine($"# Image {i + 1}");
                            WriteIntensityToCSV(writer, d[i], Ring.IP.SrcWidth);
                        }
                    }
                    // 単一画像モードの時
                    else
                    {
                        WriteIntensityToCSV(writer, [.. Ring.Intensity], Ring.IP.SrcWidth);
                    }
                }
                // Unrolled Imageのとき
                else
                {
                    WriteIntensityToCSV(writer, pseudoBitmap.SrcValuesGray, pseudoBitmap.Width);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"エラーが発生しました: {ex.Message}");
        }
    }

    // 強度データをCSV形式で書き出すヘルパーメソッド
    private void WriteIntensityToCSV(StreamWriter writer, double[] intensity, int width)
    {
        for (int i = 0; i < intensity.Length; i += width)
        {
            var row = intensity.Skip(i).Take(width).Select(value => value.ToString("G"));
            writer.WriteLine(string.Join(",", row));
        }
    }

    private void ipaToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (SrcImgSize.Width == 0) return;

        FormSaveImage.Visible = true;

    }
    #endregion

    #region File メニュー パラメータの読み書き

    private void toolStripMenuItemReadParameter_Click(object sender, EventArgs e)
    {
        var dialog = new OpenFileDialog { Filter = "*.prm[Parameter File]|*.prm", Title = "Read parameter file" };
        if (initialParameterDirectory != "")
            dialog.InitialDirectory = initialParameterDirectory;
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            ReadParameter(dialog.FileName, ((ToolStripMenuItem)sender).Name.Contains("Interactively"));
            initialParameterDirectory = Path.GetDirectoryName(dialog.FileName);
        }
    }

    private void toolStripMenuItemSaveParameter_Click(object sender, EventArgs e)
    {
        var dialog = new SaveFileDialog() { Filter = "*.prm[Parameter File]|*.prm", Title = "Save parameter file" };
        if (dialog.ShowDialog() == DialogResult.OK)
        {
            SaveParameter(dialog.FileName, ((ToolStripMenuItem)sender).Name.Contains("Fully"));
            initialParameterDirectory = Path.GetDirectoryName(dialog.FileName);
        }
    }


    public string initialParameterDirectory;
    public void SaveParameter(string filename, bool fullySave = true)
    {
        if (filename == "")
        {
            var dlg = new OpenFileDialog() { Filter = "*.prm[Parameter File]|*.prm", Title = "Save parameter file" };
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }
        if (!filename.EndsWith("prm"))
            filename += ".prm";


        fullySave = false;
        try
        {
            var prm = new DiffractionOptics.Parameter();

            if (!fullySave)
            {
                FormParameterOption.Text = "Save checked parameters";
                if (FormParameterOption.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                    return;
            }
            else
                FormParameterOption.AllCheck();

            prm.cameraMode = FormParameterOption.CameraModeChecked ? (FormProperty.radioButtonFlatPanel.Checked ? "FlatPanel" : "Gandolfi") : null;

            prm.FootMode = FormProperty.DetectorCoordinates == FormProperty.DetectorCoordinatesEnum.Foot ? "True" : "False";

            prm.CameraLength1 = FormParameterOption.CameraLengthChecked ? FormProperty.CameraLength1Text : null;
            prm.DirectSpotX = FormParameterOption.CenterPositionChecked ? FormProperty.numericBoxDirectSpotPositionX.Text : null;
            prm.DirectSpotY = FormParameterOption.CenterPositionChecked ? FormProperty.numericBoxDirectSpotPositionY.Text : null;

            prm.CameraLength2 = FormParameterOption.CameraLengthChecked ? FormProperty.CameraLength2.ToString() : null;
            prm.FootX = FormParameterOption.CenterPositionChecked ? FormProperty.FootPosition.X.ToString() : null;
            prm.FootY = FormParameterOption.CenterPositionChecked ? FormProperty.FootPosition.Y.ToString() : null;

            prm.waveSource = FormParameterOption.WaveLengthChecked ? ((int)FormProperty.waveLengthControl.WaveSource).ToString() : null;
            prm.waveLength = FormParameterOption.WaveLengthChecked ? FormProperty.WaveLengthText : null;

            prm.xRayElement = FormParameterOption.WaveLengthChecked ? FormProperty.waveLengthControl.XrayWaveSourceElementNumber.ToString() : null;
            prm.xRayLine = FormParameterOption.WaveLengthChecked ? ((int)FormProperty.waveLengthControl.XrayWaveSourceLine).ToString() : null;

            prm.pixSizeX = FormParameterOption.PixelShapeChecked ? FormProperty.numericBoxPixelSizeX.Text : null;
            prm.pixSizeY = FormParameterOption.PixelShapeChecked ? FormProperty.numericBoxPixelSizeY.Text : null;
            prm.pixKsi = !FormParameterOption.PixelShapeChecked ? null : FormProperty.numericBoxPixelKsi.Text;

            prm.tiltPhi = FormParameterOption.TiltCorrectionChecked ? FormProperty.numericBoxTiltPhi.Text : null;
            prm.tiltTau = FormParameterOption.TiltCorrectionChecked ? FormProperty.numericBoxTiltTau.Text : null;

            prm.sphericalRadiusInverse = FormParameterOption.SphericalCorrectionChecked ? FormProperty.numericBoxSphericalCorections.Text : null;

            prm.GandolfiRadius = FormParameterOption.GandolfiRadiusChecked ? FormProperty.numericBoxGandlfiRadius.Text : null;

            //IntegralRegion
            if (FormParameterOption.IntegralRegionChecked)
            {
                prm.RegionMode = FormProperty.radioButtonRectangle.Checked ? "Rectangle" : "Sector";

                prm.RectangleDirection = FormProperty.comboBoxRectangleDirection.SelectedIndex.ToString();
                prm.RectangleBothSide = FormProperty.checkBoxRectangleIsBothSide.Checked ? "True" : "False";
                prm.RectangleBandWidth = FormProperty.numericUpDownRectangleBand.Value.ToString();
                prm.RectangleAngle = FormProperty.numericUpDownRectangleAngle.Value.ToString();

                prm.SectorStart = FormProperty.numericUpDownSectorStartAngle.Value.ToString();
                prm.SectorEnd = FormProperty.numericUpDownSectorEndAngle.Value.ToString();
            }

            //IntegralRegion
            if (FormParameterOption.IntegralPropertyChecked)
            {
                prm.IntegrationMode = FormProperty.radioButtonConcentric.Checked ? "Concentric" : "Radial";

                prm.ConcentricUnit = FormProperty.radioButtonConcentricAngle.Checked ? "Angle" : FormProperty.radioButtonConcentricLength.Checked ? "Length" : "d-spacing";
                prm.ConcentricStart = FormProperty.numericBoxConcentricStart.Text;
                prm.ConcentricEnd = FormProperty.numericBoxConcentricEnd.Text;
                prm.ConcentricStep = FormProperty.numericBoxConcentricStep.Text;

                prm.RadialUnit = FormProperty.radioButtonRadialAngle.Checked ? "Angle" : "d-spacing";
                prm.RadialRadius = FormProperty.numericBoxRadialRadius.Text;
                prm.RadialWidth = FormProperty.numericBoxRadialRange.Text;
                prm.RadialStep = FormProperty.numericBoxRadialStep.Text;
            }

            System.Xml.Serialization.XmlSerializer serializer = new(typeof(DiffractionOptics.Parameter));

            var sw = new StreamWriter(filename, false, new UTF8Encoding());
            var writer = XmlWriter.Create(sw, new XmlWriterSettings { Indent = true });
            serializer.Serialize(writer, prm);
            sw.Close();

        }
        catch { MessageBox.Show("Failed to save the file. Sorry."); }

    }




    public void ReadParameter(string filename, bool fullyRead = false)
    {
        if (filename == "")
        {
            var dlg = new OpenFileDialog { Filter = "*.prm[Parameter File]|*.prm", Title = "Read parameter file" };
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }

        //イベントをスキップ
        skipSelectedAreaChangedEvent = true;
        Skip = true;

        try
        {
            DiffractionOptics.Parameter prm = DiffractionOptics.Read(filename);

            if (!fullyRead)
            {
                FormParameterOption.Text = "Read checked parameters";
                FormParameterOption.Location = new Point(this.Location.X + 100, this.Location.Y + 100);
                if (FormParameterOption.ShowDialog() == DialogResult.Cancel)
                    return;
            }
            else
                FormParameterOption.AllCheck();

            if (prm.FootMode != null && prm.FootMode == "False")
            {
                FormProperty.DetectorCoordinates = FormProperty.DetectorCoordinatesEnum.DirectSpot;

                //カメラ長1
                if (FormParameterOption.CameraLengthChecked && prm.CameraLength1 != null)
                    FormProperty.CameraLength1Text = prm.CameraLength1;

                //Direct Spot Position
                if (FormParameterOption.CenterPositionChecked && prm.DirectSpotX != null)
                    FormProperty.DirectSpotPosition = new PointD(Convert.ToDouble(prm.DirectSpotX), Convert.ToDouble(prm.DirectSpotY));
            }
            else
            {
                FormProperty.DetectorCoordinates = FormProperty.DetectorCoordinatesEnum.Foot;

                //カメラ長2
                if (FormParameterOption.CameraLengthChecked && prm.CameraLength2 != null)
                    FormProperty.CameraLength2 = Convert.ToDouble(prm.CameraLength2);

                //Foot Position
                if (FormParameterOption.CenterPositionChecked && prm.FootX != null)
                    FormProperty.FootPosition = new PointD(Convert.ToDouble(prm.FootX), Convert.ToDouble(prm.FootY));
            }

            //Camera Mode
            if (FormParameterOption.CameraModeChecked)
            {
                if (prm.cameraMode == null || prm.cameraMode == "FlatPanel")
                {
                    FormProperty.radioButtonFlatPanel.Checked = true;
                    FormProperty.radioButtonGandlfi.Checked = false;
                }
                else
                {
                    FormProperty.radioButtonFlatPanel.Checked = false;
                    FormProperty.radioButtonGandlfi.Checked = true;
                }
            }

            //WaveProperty
            if (FormParameterOption.WaveLengthChecked)
            {
                if (prm.waveSource != null)
                    FormProperty.waveLengthControl.WaveSource = (WaveSource)Convert.ToInt32(prm.waveSource);

                if (prm.xRayElement != null)
                    FormProperty.waveLengthControl.XrayWaveSourceElementNumber = Convert.ToInt32(prm.xRayElement);
                if (prm.xRayLine != null)
                    FormProperty.waveLengthControl.XrayWaveSourceLine = (XrayLine)Convert.ToInt32(prm.xRayLine);

                if (prm.waveLength != null && (FormProperty.waveLengthControl.WaveSource == WaveSource.Electron || FormProperty.waveLengthControl.XrayWaveSourceElementNumber == 0))
                    FormProperty.WaveLengthText = prm.waveLength;
            }

            //PixelShape
            if (FormParameterOption.PixelShapeChecked)
            {
                if (prm.pixSizeX != null)
                {
                    FormProperty.numericBoxPixelSizeX.Text = prm.pixSizeX;
                    FormProperty.numericBoxPixelSizeY.Text = prm.pixSizeY;
                }
                else if (prm.pixSize != null)
                {
                    FormProperty.numericBoxPixelSizeX.Text = prm.pixSize;
                    FormProperty.numericBoxPixelSizeY.Text = (Convert.ToDouble(prm.pixSize) * Convert.ToDouble(prm.aspectRatio)).ToString();
                }
                if (prm.pixKsi != null)
                    FormProperty.numericBoxPixelKsi.Text = prm.pixKsi;
            }

            //TiltCorrection
            if (FormParameterOption.TiltCorrectionChecked && prm.tiltPhi != null)
            {
                FormProperty.numericBoxTiltPhi.Text = prm.tiltPhi;
                FormProperty.numericBoxTiltTau.Text = prm.tiltTau;
            }

            //SphericalRadius
            if (FormParameterOption.TiltCorrectionChecked && prm.sphericalRadiusInverse != null)
                FormProperty.numericBoxSphericalCorections.Text = prm.sphericalRadiusInverse;

            //GandolfiRadius
            if (FormParameterOption.GandolfiRadiusChecked && prm.GandolfiRadius != null)
                FormProperty.numericBoxGandlfiRadius.Text = prm.GandolfiRadius;

            //IntegralRegion
            if (FormParameterOption.IntegralRegionChecked)
            {
                if (prm.RegionMode != null)
                {
                    FormProperty.radioButtonRectangle.Checked = prm.RegionMode == "Rectangle";
                    FormProperty.radioButtonSector.Checked = prm.RegionMode == "Sector";
                }

                if (prm.RectangleDirection != null)
                    FormProperty.comboBoxRectangleDirection.SelectedIndex = Convert.ToInt32(prm.RectangleDirection);
                if (prm.RectangleBothSide != null)
                    FormProperty.checkBoxRectangleIsBothSide.Checked = prm.RectangleBothSide == "True";
                if (prm.RectangleBandWidth != null)
                    FormProperty.numericUpDownRectangleBand.Value = Convert.ToDecimal(prm.RectangleBandWidth);
                if (prm.RectangleAngle != null)
                    FormProperty.numericUpDownRectangleAngle.Value = Convert.ToDecimal(prm.RectangleAngle);

                if (prm.SectorStart != null)
                    FormProperty.numericUpDownSectorStartAngle.Value = Convert.ToDecimal(prm.SectorStart);
                if (prm.SectorEnd != null)
                    FormProperty.numericUpDownSectorEndAngle.Value = Convert.ToDecimal(prm.SectorEnd);
            }

            //IntegralProperty
            if (FormParameterOption.IntegralPropertyChecked)
            {
                if (prm.IntegrationMode != null)
                {
                    FormProperty.radioButtonConcentric.Checked = prm.IntegrationMode == "Concentric";
                    FormProperty.radioButtonRadial.Checked = prm.IntegrationMode == "Radial";
                }

                if (prm.ConcentricUnit != null)
                {
                    FormProperty.radioButtonConcentricAngle.Checked = prm.ConcentricUnit == "Angle";
                    FormProperty.radioButtonConcentricLength.Checked = prm.ConcentricUnit == "Length";
                    FormProperty.radioButtonConcentricDspacing.Checked = prm.ConcentricUnit == "d-spacing";
                }
                if (prm.ConcentricStart != null)
                    FormProperty.numericBoxConcentricStart.Text = prm.ConcentricStart;
                if (prm.ConcentricEnd != null)
                    FormProperty.numericBoxConcentricEnd.Text = prm.ConcentricEnd;
                if (prm.ConcentricStep != null)
                    FormProperty.numericBoxConcentricStep.Text = prm.ConcentricStep;

                if (prm.RadialUnit != null)
                {
                    FormProperty.radioButtonRadialAngle.Checked = prm.RadialUnit == "Angle";
                    FormProperty.radioButtonRadialDspacing.Checked = prm.RadialUnit == "d-spacing";
                }

                if (prm.RadialRadius != null)
                    FormProperty.numericBoxRadialRadius.Text = prm.RadialRadius;
                if (prm.RadialWidth != null)
                    FormProperty.numericBoxRadialRange.Text = prm.RadialWidth;
                if (prm.RadialStep != null)
                    FormProperty.numericBoxRadialStep.Text = prm.RadialStep;
            }


        }
        catch { MessageBox.Show("Failed to read the file. Sorry."); }
        //イベントスキップを解除
        skipSelectedAreaChangedEvent = false;
        Skip = false;
        IntegralArea_Changed(new object(), new EventArgs());

        FormProperty.SaveParameterForEachImageType(Ring.ImageType);
    }

    /*
    [Serializable()]
    public class Parameter
    {
        /// <summary>
        /// "FlatPanel" か "Gandolfi"
        /// </summary>
        public string cameraMode;

        public string SACLA_EH5;
        public string SACLA_EH5_PixelWidth;
        public string SACLA_EH5_PixelHeight;
        public string SACLA_EH5_PixleSize;
        public string SACLA_EH5_TwoTheta;
        public string SACLA_EH5_Distance;
        public string SACLA_EH5_FootX;
        public string SACLA_EH5_FootY;

        public string waveSource;
        public string electronEnergy;

        public string xRayElement;
        public string xRayLine;
        public string waveLength;

        public string cameraLength;
        public string pixSize;
        public string pixSizeX;
        public string pixSizeY;
        public string pixKsi;
        public string aspectRatio;
        public string tiltPhi;
        public string tiltTau;
        public string centerX;
        public string centerY;
        public string sphericalRadiusInverse;
        public string GandolfiRadius;

        /// <summary>
        /// Concentric か Radial
        /// </summary>
        public string IntegrationMode;

        public string ConcentricStart;
        public string ConcentricEnd;
        public string ConcentricStep;
        /// <summary>
        /// Angle, Length, d-spacing
        /// </summary>
        public string ConcentricUnit;

        public string RadialRadius;
        public string RadialWidth;
        public string RadialStep;
        /// <summary>
        /// Angle, d-spacing
        /// </summary>
        public string RadialUnit;

        //Rectangle or Sector
        public string RegionMode;

        public string RectangleDirection;
        public string RectangleBandWidth;
        public string RectangleBothSide;
        public string RectangleAngle;

        public string SectorStart;
        public string SectorEnd;

        public string ExceptMaskedSpots;
        public string ExceptEdges;
        public string ExceptOver;
        public string ExceptUnder;




    }
    */

    #endregion

    #region File メニュー Maskファイルの読み書き
    public string initialMaskDirectory;
    private void toolStripMenuItemReadMask_Click(object sender, EventArgs e)
    {
        var dlg = new OpenFileDialog() { Filter = "Mask file; *.mas|*.mas", Title = "Read mask file" };
        if (initialMaskDirectory != "")
            dlg.InitialDirectory = initialMaskDirectory;
        if (dlg.ShowDialog() == DialogResult.OK)
        {
            ReadMask(dlg.FileName);
            initialMaskDirectory = Path.GetDirectoryName(dlg.FileName);
        }
    }

    string justBeforeMaskFile = "";
    public void ReadMask(string filename)
    {
        if (filename == "")
        {
            var dlg = new SaveFileDialog { Filter = "*.mas|*.mas" };
            if (dlg.ShowDialog() == DialogResult.OK)
                filename = dlg.FileName;
            else
                return;
        }

        try
        {
            var br = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.ReadWrite));
            var mask = new bool[br.ReadInt32()];
            int n = 0;
            for (int i = 0; i < mask.Length / 8; i++)
            {
                byte b = br.ReadByte();
                for (int j = 0; j < 8; j++)
                {
                    mask[n++] = (b & 1) == 1;
                    b >>= 1;
                }
            }
            br.Close();
            if (Ring.IsSpots != null && mask != null && mask.Length == Ring.IsSpots.Length)
            {
                for (int i = 0; i < mask.Length; i++)
                    Ring.IsSpots[i] = mask[i];

                SetMask();
                Draw();
                justBeforeMaskFile = filename;
            }
        }
        catch { }
    }



    public void toolStripMenuItemSaveMask_Click(object sender, EventArgs e)
    {
        var dlg = new SaveFileDialog { Filter = "Mask file; *.mas|*.mas", Title = "Save mask file" };
        if (dlg.ShowDialog() == DialogResult.OK)
            SaveMask(dlg.FileName);
    }

    public static void SaveMask(string fileName)
    {
        if (fileName == "")
        {
            var dlg = new OpenFileDialog { Filter = "*.mas|*.mas" };
            if (dlg.ShowDialog() == DialogResult.OK)
                fileName = dlg.FileName;
            else
                return;
            if (!fileName.EndsWith("mas"))
                fileName += ".mas";
        }

        var br = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite));
        br.Write(Ring.IsSpots.Length);
        int n = 0;
        for (int i = 0; i < Ring.IsSpots.Length / 8; i++)
        {
            byte b = 0;
            byte m = 1;
            for (int j = 0; j < 8; j++)
            {
                if (Ring.IsSpots[n++])
                    b += m;
                m *= 2;
            }
            br.Write(b);

        }
        br.Close();

    }

    private void clearMaskToolStripMenuItem_Click(object sender, EventArgs e)
    {
        ClearMask();
    }



    public void SetMask()
    {
        //ここを呼び出す時には
        //インテグラルプロパティをセット
        SetIntegralProperty();
        Ring.SetMask(FormProperty.checkBoxOmitSpots.Checked, FormProperty.checkBoxThresholdMin.Checked, FormProperty.checkBoxThresholdMax.Checked);
    }

    private void exitToolStripMenuItem_Click(object sender, EventArgs e) => Close();

    #endregion

    #region Tool メニュー
    private void resetFrequencyProfileToolStripMenuItem_Click(object sender, EventArgs e) => SetFrequencyProfile();

    private void calibrateRaxisImageToolStripMenuItem_Click(object sender, EventArgs e) => FormCalibrateIntensity.Show();

    #endregion

    #region Property メニュー
    private void toolStripMenuItemProperty_Click(object sender, EventArgs e) => FormProperty.Visible = true;

    private void toolStripMenuItemWaveSource_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 0;
    }

    private void toolStripMenuItemIPCondition_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 1;
    }
    private void toolStripMenuItemIntegralRegion_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 2;
    }
    private void toolStripMenuItemIntegralProperty_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 3;
    }
    private void toolStripMenuItemManualMaskMode_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 4;
    }
    private void toolStripMenuItemAfterGetProfile_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 5;
    }
    private void toolStripMenuItemUnrolledImage_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 6;
    }
    private void toolStripMenuItemMiscellaneous_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 7;
    }

    #endregion

    #region Option メニュー
    private void flipHorizontallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        => FlipRotate_Pollalization_Background();

    private void flipVerticallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        => FlipRotate_Pollalization_Background();

    private void toolStripComboBoxRotate_SelectedIndexChanged(object sender, EventArgs e)
        => FlipRotate_Pollalization_Background();

    #endregion

    #region Help メニュー 
    private void hintToolStripMenuItem_Click(object sender, EventArgs e)
    {
        InitialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.Hint;
        InitialDialog.Visible = true;
    }

    private void licenseToolStripMenuItem_Click(object sender, EventArgs e)
    {
        InitialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.License;
        InitialDialog.Visible = true;
    }

    private void versionHistoryToolStripMenuItem_Click(object sender, EventArgs e)
    {
        InitialDialog.DialogMode = Crystallography.Controls.CommonDialog.DialogModeEnum.History;
        InitialDialog.Visible = true;
    }

    private void webPageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        try
        {
            var fn = "\\doc\\IPAnalyzerManual(" + (japaneseToolStripMenuItem.Checked ? "ja" : "en") + ").pdf";
            var appPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var f = new FormPDF(appPath + fn) { Text = "IPAnalyzer manual" };
            f.Show();

        }
        catch { }
    }
    #endregion

    #region Macro メニュー マクロ関連
    /// <summary>
    /// FormMacroから呼ばれてマクロをメニューアイテムに追加する。 (dynamicで呼ばれるので、参照はゼロに見える。)
    /// </summary>
    /// <param name="name"></param>
    public void SetMacroToMenu(string[] name)
    {
        if (macroToolStripMenuItem.DropDownItems.Count == 1)
            macroToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
        for (int i = macroToolStripMenuItem.DropDownItems.Count - 1; i > 1; i--)
            macroToolStripMenuItem.DropDownItems.RemoveAt(i);


        for (int i = 0; i < name.Length; i++)
        {
            var item = new ToolStripMenuItem(name[i]) { Name = name[i] };
            item.Click += macroMenuItem_Click;
            macroToolStripMenuItem.DropDownItems.Add(item);
        }

        FormAutoProc.Macros = name;
    }

    void macroMenuItem_Click(object sender, EventArgs e)
    {
        FormMacro.RunMacroName(((ToolStripMenuItem)sender).Name);
    }



    private void ToolStripMenuItemReferenceBackground_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 9;
    }
    private void editorToolStripMenuItem_Click(object sender, EventArgs e) => FormMacro.Visible = true;
    #endregion

    #region Language メニュー
    private void languageToolStripMenuItem_Click(object sender, EventArgs e)
    {
        englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
        japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
        Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
        Language.Change(this);
    }

    #endregion

    #region SetIntegralProperty パラメータをフォームから読み取り、IPのフィールドにセットする
    public void SetIntegralProperty()
    {
        try
        {
            IP.Camera = FormProperty.radioButtonFlatPanel.Checked ? IntegralProperty.CameraEnum.FlatPanel : IntegralProperty.CameraEnum.Gandolfi;
            IP.GandolfiRadius = FormProperty.numericBoxGandlfiRadius.Value;

            IP.SrcWidth = SrcImgSize.Width; ;//ソース画像の幅
            IP.SrcHeight = SrcImgSize.Height; ;//ソース画像の高さ
            IP.CenterX = FormProperty.numericBoxDirectSpotPositionX.Value;//センターのx位置
            IP.CenterY = FormProperty.numericBoxDirectSpotPositionY.Value;//センターのy位置
            IP.PixSizeX = FormProperty.numericBoxPixelSizeX.Value;
            IP.PixSizeY = FormProperty.numericBoxPixelSizeY.Value;//ピクセルサイズ
            IP.ksi = FormProperty.numericBoxPixelKsi.RadianValue;

            IP.SpericalRadiusInverse = FormProperty.numericBoxSphericalCorections.Value / 1000;

            IP.WaveLength = FormProperty.WaveLength;

            IP.ThresholdMax = (int)FormProperty.numericUpDownThresholdOfIntensityMax.Value;
            IP.ThresholdMin = (int)FormProperty.numericUpDownThresholdOfIntensityMin.Value;

            IP.Edge = (int)FormProperty.numericUpDownEdge.Value;
            IP.DoesExcludeEdge = FormProperty.checkBoxMaskEdge.Checked;

            IP.ConcentricMode = FormProperty.radioButtonConcentric.Checked;



            if (IP.ConcentricMode)
            {//コンセントリックモードのとき
                if (FormProperty.radioButtonConcentricAngle.Checked)
                {
                    IP.StartAngle = (double)(FormProperty.numericBoxConcentricStart.Value) * Math.PI / 180.0;
                    IP.EndAngle = (double)FormProperty.numericBoxConcentricEnd.Value * Math.PI / 180.0; ;
                    IP.StepAngle = (double)FormProperty.numericBoxConcentricStep.Value * Math.PI / 180.0; ;
                    IP.Mode = HorizontalAxis.Angle;
                }
                else if (FormProperty.radioButtonConcentricLength.Checked)
                {
                    IP.StartLength = FormProperty.numericBoxConcentricStart.Value;
                    IP.EndLength = FormProperty.numericBoxConcentricEnd.Value;
                    IP.StepLength = FormProperty.numericBoxConcentricStep.Value;
                    IP.Mode = HorizontalAxis.Length;
                }
                else
                {
                    IP.StartDspacing = FormProperty.numericBoxConcentricStart.Value / 10.0;
                    IP.EndDspacing = FormProperty.numericBoxConcentricEnd.Value / 10.0;//角度もしくはピクセルの上限値、下限値
                    IP.StepDspacing = FormProperty.numericBoxConcentricStep.Value / 10.0;//角度もしくはピクセルのステップ
                    IP.Mode = HorizontalAxis.d;
                }
            }
            else
            {//ラディアルモードのとき
                if (FormProperty.radioButtonRadialAngle.Checked)
                {
                    IP.RadialRadiusAngle = FormProperty.numericBoxRadialRadius.Value * Math.PI / 180.0;
                    IP.RadialRadiusAngleRange = FormProperty.numericBoxRadialRange.Value * Math.PI / 180.0;
                    IP.Mode = HorizontalAxis.Angle;
                }
                else
                {
                    IP.RadialRadiusDspacing = FormProperty.numericBoxRadialRadius.Value / 10.0;
                    IP.RadialRadiusDspacingRange = FormProperty.numericBoxRadialRange.Value / 10.0;
                    IP.Mode = HorizontalAxis.d;
                }
                IP.RadialSectorAngle = FormProperty.numericBoxRadialStep.Value;
            }


            IP.FilmDistance = FormProperty.CameraLength1;//カメラ長
            IP.phi = FormProperty.numericBoxTiltPhi.RadianValue; //IPの角度Tilt
            IP.tau = FormProperty.numericBoxTiltTau.RadianValue; ;//IPの角度Azumuth;

            if (FormProperty.radioButtonRectangle.Checked) IP.IsRectangle = true;//RectangleかSectorか
            else IP.IsRectangle = false;

            //Rectangleモードのとき
            if ((string)FormProperty.comboBoxRectangleDirection.SelectedItem == "Full") IP.IsFull = true; else IP.IsFull = false;
            IP.RectangleBand = (double)FormProperty.numericUpDownRectangleBand.Value;//バンドの太さ
            IP.RectangleAngle = (double)FormProperty.numericUpDownRectangleAngle.Value * Math.PI / 180.0; //角度
            IP.RectangleIsBothSide = FormProperty.checkBoxRectangleIsBothSide.Checked;//半直線かどうか 
            //Sectorモードのとき
            IP.SectorStartAngle = (double)FormProperty.numericUpDownSectorStartAngle.Value * Math.PI / 180.0; //開始角度
            IP.SectorEndAngle = (double)FormProperty.numericUpDownSectorEndAngle.Value * Math.PI / 180.0; ;//終了角度

            IP.IsBraggBrentanoMode = FormProperty.radioButtonBraggBrentano.Checked;
        }
        catch
        {
            MessageBox.Show("適切に入力されていない項目があります");
            return;
        }
        Ring.IP = IP;
    }

    #endregion

    #region Backgroundボタン 関連
    private void resetBackgroundToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Draw();
    }

    public void toolStripSplitButtonBackground_ButtonClick(object sender, EventArgs e)
    {
        if (!IsImageReady) return;
        SetIntegralProperty();
        try
        {
            double upper = Convert.ToDouble(toolStripComboBoxBackgroundUpper.Text) * 0.01;
            double lower = Convert.ToDouble(toolStripComboBoxBackgroundLower.Text) * 0.01;
            Draw();
        }
        catch
        { return; }

    }

    #endregion

    #region FindCenterボタン関連
    //
    public void toolStripSplitButtonFindCenter_ButtonClick(object sender, EventArgs e)
    {
        if (!IsImageReady) return;

        sw.Restart();
        if (!FormDrawRing.Visible)//通常モードの時
        {
            toolStripSplitButtonFindCenter.Enabled = false;
            for (int i = 0; i < 1; i++)
            {
                SetIntegralProperty();
                if (IP.CenterX < 0 || IP.CenterX > IP.SrcWidth || IP.CenterY < 0 || IP.CenterY > IP.SrcHeight)
                    return;

                PointD center = Ring.FindCenter(IP, (int)FormProperty.numericBoxFindCenterSearchArea.Value, FormProperty.checkBoxExcludeMaskedPixels.Checked ? Ring.IsSpots : null);
                FormProperty.DirectSpotPosition = center;
            }
            toolStripSplitButtonFindCenter.Enabled = true;
            this.toolStripStatusLabel.Text = "Calculating Time (Find Center):  " + (sw.ElapsedMilliseconds).ToString() + "ms";

            FormProperty.ImageTypeParameters[(int)Ring.ImageType].CenterPosX = FormProperty.DirectSpotPosition.X;
            FormProperty.ImageTypeParameters[(int)Ring.ImageType].CenterPosY = FormProperty.DirectSpotPosition.Y;

            if (FormFindParameter.Visible)
            {

                if (FormFindParameter.textBoxPrimaryFileName.Text.EndsWith(FileName) && (!SequentialImageMode || FormSequentialImage.SelectedIndex == FormFindParameter.numericBoxPrimaryImageNum.ValueInteger))
                {
                    FormFindParameter.numericalTextBoxPrimaryCenterPositionX.Text = FormProperty.DirectSpotPosition.X.ToString("f8");
                    FormFindParameter.numericTextBoxPrimaryCenterPositionY.Text = FormProperty.DirectSpotPosition.Y.ToString("f8");
                }
                else
                {
                    FormFindParameter.numericTextBoxSecondaryCenterPositionX.Text = FormProperty.DirectSpotPosition.X.ToString("f8");
                    FormFindParameter.numericTextBoxSecondaryCenterPositionY.Text = FormProperty.DirectSpotPosition.Y.ToString("f8");
                }
            }
        }
        else if (FormDrawRing.Visible && FormDrawRing.R > 0)//デバイリングから、中心位置を検索する時
        {
            this.Enabled = false;
            tabControl1.SelectedIndex = 1;
            FormProperty.radioButtonConcentric.Checked = true;
            FormProperty.radioButtonConcentricAngle.Checked = true;
            var concentricStart = FormProperty.numericBoxConcentricStart.Value;
            var concentricEnd = FormProperty.numericBoxConcentricEnd.Value;

            var fittingRange = FormProperty.numericBoxFindCenterPeakFittingRange.Value;
            FormProperty.numericBoxConcentricStart.Value = FormDrawRing.TwoTheta / Math.PI * 180 - fittingRange * 5;
            FormProperty.numericBoxConcentricEnd.Value = FormDrawRing.TwoTheta / Math.PI * 180 + fittingRange * 5;

            var pf = new PeakFunction(FormDrawRing.TwoTheta / Math.PI * 180, fittingRange / 2, fittingRange, PeakFunctionForm.PseudoVoigt);
            FormProperty.radioButtonSector.Checked = true;
            for (int n = 0; n < 3; n++)
            {
                var pts = new List<PointD>();
                var angleStep = 20;
                for (int i = 0; i < 360 / angleStep; i++)
                {
                    Skip = true;
                    FormProperty.numericUpDownSectorStartAngle.Value = angleStep * i - angleStep / 2;
                    Skip = false;
                    FormProperty.numericUpDownSectorEndAngle.Value = angleStep * i + angleStep / 2;
                    var profile = Ring.GetProfile(IP);

                    FittingPeak.FitPeakThread(profile.Pt, true, 0, ref pf);

                    graphControlProfile.Profile = profile;
                    graphControlProfile.Peaks = [pf];
                    if (!double.IsNaN(pf.X) && pf.X != 0)
                        pts.Add(new PointD(
                            IP.FilmDistance * Math.Tan(Math.PI / 180 * pf.X) * Math.Sin(Math.PI / 180 * angleStep * i),
                            -IP.FilmDistance * Math.Tan(Math.PI / 180 * pf.X) * Math.Cos(Math.PI / 180 * angleStep * i)));
                    Application.DoEvents();
                }

                var centerOffset = Geometry.GetEllipseCenter([.. pts]);
                if (double.IsNaN(centerOffset.X))
                    break;
                double centerX = centerOffset.X / IP.PixSizeX + IP.CenterX;
                double centerY = centerOffset.Y / IP.PixSizeY + IP.CenterY;
                FormProperty.DirectSpotPosition = new PointD(centerX, centerY);
            }

            FormProperty.radioButtonRectangle.Checked = true;
            FormProperty.numericBoxConcentricStart.Value = concentricStart;
            FormProperty.numericBoxConcentricEnd.Value = concentricEnd;

            this.Enabled = true;
            Draw();
        }
    }

    private void toolStripButtonFixCenter_Click(object sender, EventArgs e)
    {
        FormProperty.checkBoxFixCenter.Checked = !FormProperty.checkBoxFixCenter.Checked;
    }

    private void toolStripButtonFixCenter_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripButtonFixCenter.Checked)
        {
            toolStripButtonFixCenter.ForeColor = Color.Red;
            toolStripSplitButtonFindCenter.Enabled = false;
        }
        else
        {
            toolStripButtonFixCenter.ForeColor = Color.Gray;
            toolStripSplitButtonFindCenter.Enabled = true;

        }
    }


    #endregion

    #region FindSpotsボタン関連
    public void toolStripSplitButtonFindSpots_ButtonClick(object sender, EventArgs e)
    {
        MaskSpots();
    }

    public void MaskSpots()
    {
        if (!IsImageReady) return;

        this.Cursor = Cursors.WaitCursor;
        toolStripSplitButtonFindSpots.Enabled = false;
        int d = Environment.TickCount;
        SetIntegralProperty();
        Ring.FindSpots(IP, (double)FormProperty.numericUpDownFindSpotsDeviation.Value);
        Draw();
        this.Cursor = Cursors.Default;
        toolStripSplitButtonFindSpots.Enabled = true;
        this.toolStripStatusLabel.Text = "Calculating Time (Find Spots):  " + (Environment.TickCount - d).ToString() + "ms";


    }

    #endregion

    #region Maskボタン関連
    //ClearSpotsボタン
    public void toolStripMenuItemClearSpots_Click(object sender, EventArgs e)
    {
        ClearMask();
    }

    public void ClearMask()
    {
        if (!IsImageReady) return;
        for (int i = 0; i < Ring.IsSpots.Length; i++)
            Ring.IsSpots[i] = false;

        Draw();
    }

    private void inverseMaskToolStripMenuItem_Click(object sender, EventArgs e)
    {
        InvertMask();
    }

    public void InvertMask()
    {
        if (!IsImageReady) return;
        for (int i = 0; i < Ring.IsSpots.Length; i++)
            Ring.IsSpots[i] = !Ring.IsSpots[i];
        Draw();
    }

    private void toolStripMenuItemMaskAll_Click(object sender, EventArgs e)
    {
        MaskAll();
    }

    public void MaskAll()
    {
        if (!IsImageReady) return;
        for (int i = 0; i < Ring.IsSpots.Length; i++)
            Ring.IsSpots[i] = true;
        Draw();
    }

    //マニュアルモードボタンがクリックされた時の反応
    private void toolStripButtonManualSpotMode_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = !toolStripButtonManualSpotMode.Checked;
        toolStripButtonManualSpotMode.Checked = !toolStripButtonManualSpotMode.Checked;
    }

    //マニュアルモードボタンのチェック状態が変更したとき
    private void toolStripButtonManualSpotMode_CheckedChanged(object sender, EventArgs e)
    {
        toolStripComboBoxManualSpotSize.Visible = toolStripButtonManualSpotMode.Checked && FormProperty.radioButtonManualSpot.Checked;

        if (toolStripButtonManualSpotMode.Checked)
        {
            toolStripButtonManualSpotMode.ForeColor = Color.Red;
            toolStripSplitButtonFindSpots.Enabled = false;
            FormProperty.tabControl.SelectedIndex = 4;
            FormProperty.checkBoxManualMaskMode.Checked = true;
        }
        else
        {
            toolStripButtonManualSpotMode.ForeColor = Color.Gray;
            toolStripSplitButtonFindSpots.Enabled = true;
            FormProperty.checkBoxManualMaskMode.Checked = false;
        }
    }

    private void toolStripComboBoxManualSpotSize_TextChanged(object sender, EventArgs e)
    {
        if (FormProperty.textBoxManualSpotSize.Text != toolStripComboBoxManualSpotSize.Text)
            FormProperty.textBoxManualSpotSize.Text = toolStripComboBoxManualSpotSize.Text;
    }

    #endregion

    #region Get Profileボタン関連
    private void toolStripMenuItemAngleSetting_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.tabControl.SelectedIndex = 3;
    }

    private void toolStripMenuItemConcenctricIntegration_Click(object sender, EventArgs e)
    {
        FormProperty.Visible = true;
        FormProperty.radioButtonConcentric.Checked = true;
        FormProperty.tabControl.SelectedIndex = 3;
        FormProperty.Visible = true;
    }

    private void toolStripMenuItemRadialIntegration_Click(object sender, EventArgs e)
    {
        FormProperty.radioButtonRadial.Checked = true;
        FormProperty.tabControl.SelectedIndex = 3;
        FormProperty.Visible = true;
    }
    public void toolStripSplitButtonGetProfileButtonClick(object sender, EventArgs e) => GetProfile();
    public void GetProfile(string fileName = "")
    {
        if (!IsImageReady) return;
        Cursor = Cursors.WaitCursor;
        toolStripSplitButtonGetProfile.Enabled = false;
        SetIntegralProperty();

        sw.Restart();

        //パラメータをイメージ種ごとに保存
        FormProperty.SaveParameterForEachImageType(Ring.ImageType);

        //中心位置検索の必要があれば
        if (findCenterBeforeGetProfileToolStripMenuItem.Checked == true && toolStripButtonFixCenter.Checked == false)
        {
            FormProperty.SkipEvent = true;
            toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
            FormProperty.SkipEvent = false;
            toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
        }
        //スポット検出の必要があれば
        if (maskSpotsBeforeGetProfileToolStripMenuItem.Checked == true && toolStripButtonManualSpotMode.Checked == false)
            toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());

        IP.Mode = FormProperty.radioButtonConcentricAngle.Checked ? HorizontalAxis.Angle : HorizontalAxis.d;
        try
        {
            toolStripSplitButtonGetProfile.Enabled = false;
            var dpList = new List<DiffractionProfile2>();
            var azimuthalDivMode = toolStripMenuItemAzimuthalDivisionAnalysis.Checked;

            //通常積分モード
            if (!azimuthalDivMode)
            {
                SetMask();
                var diffractionProfile = new DiffractionProfile2
                {
                    Mode = FormProperty.radioButtonConcentric.Checked ? DiffractionProfileMode.Concentric : DiffractionProfileMode.Radial,
                };
                diffractionProfile.SrcProperty.AxisMode = IP.Mode;
                if (diffractionProfile.SrcProperty.AxisMode == HorizontalAxis.d)
                    diffractionProfile.SrcProperty.DspacingUnit = LengthUnitEnum.Angstrom;
                diffractionProfile.SrcProperty.WaveLength = IP.WaveLength;

                var targets = new int[] { -1 };

                if (toolStripButtonImageSequence.Enabled)
                {//シーケンシャルイメージモードの時の処理
                    if (toolStripMenuItemAllSequentialImages.Checked)
                        targets = [.. Enumerable.Range(0, FormSequentialImage.MaximumNumber)];
                    else if (toolStripMenuItemSelectedSequentialImages.Checked)
                        targets = FormSequentialImage.SelectedIndices;
                }

                for (int i = 0; i < targets.Length; i++)
                {

                    if (targets[0] != -1)
                    {//シーケンシャルイメージモードの時の処理
                        FormSequentialImage.SkipCalcFreq = i != targets.Length - 1;
                        FormSequentialImage.AverageMode = false;
                        FormSequentialImage.SelectedIndex = targets[i];
                        if (Ring.ImageType == Ring.ImageTypeEnum.HDF5)
                            diffractionProfile.SrcProperty.WaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(Ring.SequentialImageEnergy[targets[i]]);
                    }

                    if (toolStripButtonImageSequence.Enabled)
                        diffractionProfile.Name = FileName + "  " + FileNameSub;
                    else
                        diffractionProfile.Name = FileName;

                    //プロファイルを作成
                    diffractionProfile.SourceProfile = Ring.GetProfile(IP);

                    //必要であればKα2を除去
                    #region
                    if (FormProperty.checkBoxTest.Checked)
                    {
                        if (FormProperty.waveLengthControl.XrayWaveSourceElementNumber > 10 && FormProperty.waveLengthControl.XrayWaveSourceLine == XrayLine.Ka1)
                        {
                            var alpha1 = AtomStatic.CharacteristicXrayWavelength(FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka1);
                            var alpha2 = AtomStatic.CharacteristicXrayWavelength(FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka2);
                            var ratio = FormProperty.numericBoxTest.Value;
                            diffractionProfile.SourceProfile = DiffractionProfile2.RemoveKalpha2(diffractionProfile.SourceProfile, alpha1, alpha2, ratio);
                        }
                    }
                    #endregion

                    //必要であればUnrolledImageを作成
                    #region
                    if (FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked)
                    {
                        var chiDivision = 360;
                        diffractionProfile.ImageArray = Ring.GetUnrolledImageArray(IP, chiDivision, IP.StartAngle, IP.EndAngle, IP.StepAngle);
                        diffractionProfile.ImageScale = 1;
                        diffractionProfile.ImageWidth = diffractionProfile.ImageArray.Length / chiDivision;
                        diffractionProfile.ImageHeight = chiDivision;
                    }
                    else
                        diffractionProfile.ImageArray = null;
                    #endregion

                    dpList.Add((DiffractionProfile2)diffractionProfile.Clone());
                }
                graphControlProfile.Profile = diffractionProfile.SourceProfile;
                toolStripStatusLabel.Text = $"Calculating Time (Get Profile):  {sw.ElapsedMilliseconds} ms.";
            }
            else //LPOモードのとき
            {
                #region
                SetMask();
                FormProperty.radioButtonRectangle.Checked = true;
                FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;

                var fn = FileName;
                if (toolStripButtonImageSequence.Enabled)
                    fn += "  " + FileNameSub;

                dpList.Add(new DiffractionProfile2
                {
                    SourceProfile = Ring.GetProfile(IP),
                    Name = fn + " -whole",
                    SrcProperty = new HorizontalAxisProperty(FormProperty.waveLengthControl.WaveSource, IP.WaveLength, AngleUnitEnum.Degree),
                    IsLPOmain = true,
                    IsLPOchild = false
                });

                graphControlProfile.Profile = dpList[0].Profile;

                if (!int.TryParse(toolStripComboBoxAzimuthalDivisionNumber.Text, out int chiDiv))
                    return;

                //アジマス方向に角度分割したプロファイル行列を一括で計算
                var profiles = Ring.GetConcenrticProfilesBySector(IP, chiDiv);

                for (int i = 0; i < profiles.Length; i++)
                {
                    dpList.Add(new DiffractionProfile2()
                    {
                        SourceProfile = profiles[i],
                        Name = $"{fn} -{i * 360 / chiDiv:000}",
                        SrcProperty = new HorizontalAxisProperty(FormProperty.waveLengthControl.WaveSource, IP.WaveLength, AngleUnitEnum.Degree),
                        IsLPOmain = false,
                        IsLPOchild = true,
                    });
                }
                toolStripStatusLabel.Text = $"Calculating Time (Get Profiles by Sector):  {sw.ElapsedMilliseconds} ms.";
                #endregion
            }

            //ファイル保存
            if (FormProperty.checkBoxSaveFile.Checked)
                SaveProfile(dpList, fileName);

            //PDindexerへの送信
            if (FormProperty.checkBoxSendProfileToPDIndexer.Checked)
            {
                using var mutex = new Mutex(false, "PDIndexer");
                bool result = false;
                try
                {
                    if (result = mutex.WaitOne(azimuthalDivMode ? 5000 : 500, true))
                    {
                        mutex.ReleaseMutex();

                        Clipboard.SetDataObject(dpList.ToArray());


                    }
                    Thread.Sleep(500);

                    if (mutex.WaitOne(azimuthalDivMode ? 5000 : 500, false))
                        mutex.ReleaseMutex();
                }
                finally { mutex.Close(); }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            MessageBox.Show("Failed to processing. sorry.");
        }
        finally
        {
            Cursor = Cursors.Default;
            toolStripSplitButtonGetProfile.Enabled = true;

            if (toolStripMenuItemAzimuthalDivisionAnalysis.Checked)
            {
                FormProperty.radioButtonRectangle.Checked = true;
                FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;
            }
        }
    }



    private void toolStripMenuItemSendProfileToPDIndexer_Click(object sender, EventArgs e)
    {
        FormProperty.checkBoxSendProfileToPDIndexer.Checked = !FormProperty.checkBoxSendProfileToPDIndexer.Checked;
    }

    #endregion

    #region SaveProfile

    private void SaveProfile(List<DiffractionProfile2> dpList, string filename = "")
    {
        if (dpList == null || dpList.Count == 0) return;

        string extension;
        #region 拡張子を設定
        if (FormProperty.radioButtonAsPDIformat.Checked) extension = ".pdi2";
        else if (FormProperty.radioButtonAsCSVformat.Checked) extension = ".csv";
        else if (FormProperty.radioButtonAsTSVformat.Checked) extension = ".tsv";
        else extension = ".gsa";
        #endregion

        //ファイル名を決定する
        if (FormProperty.radioButtonSetDirectoryEachTime.Checked)
        {
            var dialog = new SaveFileDialog { Filter = extension + "|" + extension, FileName = FileName[..FileName.LastIndexOf('.')] };
            if (dialog.ShowDialog() == DialogResult.OK)
                filename = dialog.FileName;
            else return;
        }
        else if (filename == "")
        {
            if (Path.GetExtension(FileName)[1..].StartsWith("0"))//Ryonixデータ(0###のような拡張子)に対応
                filename = FilePath + FileName;
            else
                filename = FilePath + FileName[..FileName.LastIndexOf('.')];
        }
        if (toolStripButtonImageSequence.Enabled)
            filename += FileNameSub;

        //一つのファイルにまとめて保存する場合
        if (dpList.Count > 1 && FormProperty.radioButtonSaveInOneFile.Checked)
        {
            //PDI形式の場合
            if (FormProperty.radioButtonAsPDIformat.Checked)
                XYFile.SavePdi2File([.. dpList], filename + extension);
            //CSVかTSVの場合
            else if (!FormProperty.radioButtonAsGSASformat.Checked)
            {
                using var sw = new StreamWriter(filename + extension);
                var s = FormProperty.radioButtonAsCSVformat.Checked ? "," : "\t";

                //1行目
                for (int j = 0; j < dpList.Count; j++)
                    sw.Write(dpList[j].Name + (j == dpList.Count - 1 ? "\r\n" : s + s + s));
                //2行目
                for (int j = 0; j < dpList.Count; j++)
                    sw.Write($"x{s}y{s}" + (j == dpList.Count - 1 ? "\r\n" : s));
                //3行目以降
                var length = dpList.Max(d => d.SourceProfile.Pt.Count);
                for (int i = 0; i < length; i++)
                    for (int j = 0; j < dpList.Count; j++)
                    {
                        if (i < dpList[j].SourceProfile.Pt.Count)
                            sw.Write($"{dpList[j].SourceProfile.Pt[i].X}{s}{dpList[j].SourceProfile.Pt[i].Y}{s}");
                        else
                            sw.Write($"{s}{s}");
                        sw.Write(j == dpList.Count - 1 ? "\r\n" : s);
                    }
            }
        }
        //個別のファイルに分けて保存する場合
        else
        {
            foreach (var dp in dpList)
            {
                var fn = filename;
                if (toolStripButtonImageSequence.Enabled && dp.Name.Contains('#'))//シーケンシャルイメージモードの時
                    fn += dp.Name[dp.Name.LastIndexOf('#')..].Replace(" ", "");
                else if (dpList[0].Name.EndsWith("-whole") && dp.Name.Contains('-'))//Azimuthal divison モードの時
                    fn += dp.Name[dp.Name.LastIndexOf('-')..].Replace(" ", "");

                if (FormProperty.radioButtonAsPDIformat.Checked)
                    XYFile.SavePdi2File([dp], fn + extension);
                else
                {
                    using var sw = new StreamWriter(fn + extension);
                    if (FormProperty.radioButtonAsGSASformat.Checked)
                    {
                        var lines = Profile.ToGSAS(fn, dp.SourceProfile, HorizontalAxis.Angle);
                        for (int i = 0; i < lines.Length; i++)
                            sw.WriteLine(lines[i]);
                    }
                    else
                    {
                        var s = FormProperty.radioButtonAsCSVformat.Checked ? "," : "\t";
                        foreach (var p in dp.SourceProfile.Pt)
                            sw.WriteLine($"{p.X}{s}{p.Y}{s}{p.Y}");
                    }
                }
            }
        }
    }
    #endregion

    #region IntegralArea_Changed
    public void IntegralArea_Changed(object sender, EventArgs e)
    {
        if (!IsImageReady || Skip) return;

        SetIntegralProperty();

        Stopwatch sw = new();
        sw.Start();

        if (FormFindParameter.Visible && FormFindParameter.backgroundWorkerRefine.IsBusy)
            Ring.SetInsideArea(IP, true, false, false);
        else
            Ring.SetInsideArea(IP);

        this.toolStripStatusLabel.Text = "Calculating Time (SetIntegralArea):  " + sw.ElapsedMilliseconds.ToString() + "ms";

        SetMask();
        Draw();
    }
    #endregion

    #region UnrolledImage
    private void toolStripMenuItemSendUnrolledImage_Click(object sender, EventArgs e)
    {
        FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked = !FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked;
    }

    private void toolStripButtonCircumferentialBlur_Click(object sender, EventArgs e)
    {
        var formBlurAngle = new FormBlurAngle();
        if (formBlurAngle.ShowDialog() == DialogResult.OK)
        {
            Ring.CircumferentialBlur(formBlurAngle.BlurAngle);
            initializeFilter();
            Draw();
        }
    }
    #endregion

    #region 子フォームの立ち上げ、終了

    #region Intensity Table
    //private void toolStripButtonIntensityTable_CheckedChanged(object sender, EventArgs e)
    //    => FormIntTable.Visible = toolStripButtonIntensityTable.Checked;
    #endregion

    #region Auto Procedure
    private void toolStripButtonAutoProcedure_CheckedChanged(object sender, EventArgs e)
        => FormAutoProc.Visible = toolStripButtonAutoProcedure.Checked;
    #endregion

    #region Draw Ring
    private void toolStripButtonRing_CheckedChanged(object sender, EventArgs e)
    {
        var loc = FormDrawRing.Location;

        FormDrawRing.Visible = toolStripButtonRing.Checked;

        FormDrawRing.Location = loc;

    }
    #endregion

    private void toolStripButtonFindParameterBruteForce_CheckedChanged(object sender, EventArgs e)
    {
        FormFindParameterBruteForce.Visible = toolStripButtonFindParameterBruteForce.Checked;
    }

    private void toolStripButtonFindParameter_CheckedChanged(object sender, EventArgs e)
        => FormFindParameter.Visible = toolStripButtonFindParameter.Checked;

    private void toolStripButtonImageSequence_CheckedChanged(object sender, EventArgs e)
    {
        FormSequentialImage.Visible = toolStripButtonImageSequence.Checked;
        FormSequentialImage.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
    }


    /// <summary>
    /// UnrolledImageの作成
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void toolStripSplitButtonUnroll_CheckChanged(object sender, EventArgs e)
    {
        if (!IsImageReady) return;
        if (toolStripButtonUnroll.Checked)
        {
            //formProperty.radioButtonRadial.Checked = true;
            FormProperty.tabControl.SelectedIndex = 6;
            FormProperty.Visible = true;

            var chiDivision = (int)FormProperty.numericUpDownUnrollChiDivision.Value;
            var xStart = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXstart.Value / 180.0;
            var xEnd = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXend.Value / 180.0;
            var xStep = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXstep.Value / 180.0;

            var sw = new Stopwatch();
            sw.Start();

            double[] imageArray = Ring.GetUnrolledImageArray(IP, chiDivision, xStart, xEnd, xStep);

            this.toolStripStatusLabel.Text = "Calculating Time (Unroll Image):  " + sw.ElapsedMilliseconds.ToString() + "ms";

            byte[] scale = new byte[256];
            for (int i = 0; i < 256; i++)
                scale[i] = (byte)i;
            pseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / chiDivision, scale, scale, scale, false);

            scalablePictureBox.PseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / chiDivision, scale, scale, scale, false);
            scalablePictureBoxThumbnail.PseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / chiDivision, scale, scale, scale, false);
            Draw();
        }
        else
        {
            initializeFilter();
            IntegralArea_Changed(new object(), new EventArgs());
            Draw();
        }
    }

    #endregion

    #region View関連
    private void toolStripComboBoxScale_SelectedIndexChanged(object sender, EventArgs e)
    {
        setScale();
        Draw();
    }

    private void toolStripComboBoxScale2_SelectedIndexChanged(object sender, EventArgs e)
    {
        setScale();
        Draw();
    }

    private void comboBoxGradient_SelectedIndexChanged_1(object sender, EventArgs e)
    {
        setScale();
        Draw();
    }

    private void comboBoxScaleLine_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (FormProperty != null)
        {
            FormProperty.SkipEvent = true;
            FormProperty.comboBoxScaleLineDivisions.SelectedIndex = comboBoxScaleLine.SelectedIndex;
            FormProperty.SkipEvent = false;
        }
        Draw();
    }
    private void setScale()
    {
        pseudoBitmap.IsNegative = comboBoxGradient.SelectedIndex == 1;

        var linear = comboBoxScale1.SelectedIndex == 1;

        //スケールをセット
        switch (comboBoxScale2.SelectedIndex)
        {
            case 0: pseudoBitmap.SetScaleGray(linear); break;//グレー
            case 1: pseudoBitmap.SetScaleColdWarm(linear); break;//Cold-Warm
            case 2: pseudoBitmap.SetScaleSpectrum(linear); break;//Cold-Warm
            case 3: pseudoBitmap.SetScaleFire(linear); break;//Cold-Warm
        }

        trackBarAdvancedMaxInt_ValueChanged(new object(), 0);
        trackBarAdvancedMinInt_ValueChanged(new object(), 0);
    }

    #endregion

    #region Whole image / Near centerの切り替え
    public bool thumbnailmode = false;
    private void radioButton1_CheckedChanged(object sender, EventArgs e)
    {
        thumbnailmode = !thumbnailmode;
        Draw();
    }
    #endregion

    #region KeyDown, KeyUpイベント
    private void FormMain_KeyDown(object sender, KeyEventArgs e)
    {
        bool left = GetAsyncKeyState(37) != 0, up = GetAsyncKeyState(38) != 0, right = GetAsyncKeyState(39) != 0, down = GetAsyncKeyState(40) != 0;

        if (e.Control)//コントロールが押されているとき
        {
            if (e.Shift)//シフトキーが押されているとき
            {
                if (e.KeyCode == Keys.F)
                    toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());//CTRL + SHIFT + F
                else if (e.KeyCode == Keys.S)
                    toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());//CTRL + SHIFT + S
                else if (e.KeyCode == Keys.G)
                    toolStripSplitButtonGetProfileButtonClick(new object(), new EventArgs());//CTRL + SHIFT + G
                else if (e.KeyCode == Keys.B)
                    toolStripSplitButtonBackground_ButtonClick(new object(), new EventArgs());//CTRL + SHIFT + B
                else if (e.KeyCode == Keys.M)
                    FormProperty.checkBoxManualMaskMode.Checked = !FormProperty.checkBoxManualMaskMode.Checked;//CTRL + SHIFT + M
                else if (e.KeyCode == Keys.C)
                {
                    //StasticalInformationタブが開かれていて選択領域が有効な場合は、その領域をクリップボードにコピー
                    if (tabControl1.SelectedIndex == 2)
                    {
                        double _left = Math.Max((double)Math.Min(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value), 0);
                        double _right = Math.Min((double)Math.Max(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value), Ring.SrcImgSize.Width - 1);
                        double _top = Math.Max((double)Math.Min(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), 0);
                        double _bottom = Math.Min((double)Math.Max(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), Ring.SrcImgSize.Height - 1);
                        //scalablePictureBox.AreaRectangle
                        var rec = new RectangleD(_left, _top, _right - _left + 1, _bottom - _top + 1);
                        Clipboard.SetDataObject(scalablePictureBox.PseudoBitmap.GetImage(rec, rec.ToSize()), true);
                    }
                    else
                    {
                        Clipboard.SetDataObject(scalablePictureBox.PseudoBitmap.GetImage(), true);
                    }
                }
                else
                {
                    var shift = 1 / scalablePictureBox.Zoom;
                    if (up)
                        FormProperty.DirectSpotPosition += new PointD(0, -shift);//CTRL + SHIFT + ↑
                    else if (down)
                        FormProperty.DirectSpotPosition += new PointD(0, shift);//CTRL + SHIFT + ↓
                    else if (right)
                        FormProperty.DirectSpotPosition += new PointD(shift, 0);//CTRL + SHIFT + →
                    else if (left)
                        FormProperty.DirectSpotPosition += new PointD(-shift, 0);//CTRL + SHIFT + ←
                }
            }
            else //シフトキーが押されていないとき
            {
                if (up || down || left || right)
                {
                    if (toolStripButtonImageSequence.Enabled) //シーケンシャルイメージモードの時
                    {
                        if ((left || up) && FormSequentialImage.SelectedIndex > 0)
                            FormSequentialImage.SelectedIndex--;// ←あるいは↑で イメージのインデックスを戻す
                        else if ((right || down) && FormSequentialImage.SelectedIndex < FormSequentialImage.MaximumNumber)
                            FormSequentialImage.SelectedIndex++;// →あるいは↓で イメージのインデックスを進める
                    }
                    else //現在読み込んでいる画像が存在するフォルダで、ファイル名順に画像を移動する
                    {
                        var files = Directory.GetFiles(FilePath).ToList();//まずフォルダ中の同じ拡張子のファイルを全部取得
                        if (files.Count > 0)
                        {
                            files.Sort();
                            var i = files.IndexOf(FilePath + FileName);
                            if (i != -1)
                            {
                                if (i < files.Count - 1 && (right || down))
                                    ReadImage(files[i + 1]);
                                else if (i > 0 && (left || up))
                                    ReadImage(files[i - 1]);
                            }
                        }
                    }
                }
            }

            //else if (e.Control && scalablePictureBox.Focused)
            //{
            //    IsManualSpotMode = true;
            //    FormProperty.checkBoxManualMaskMode.Checked = true;
            //    Draw();
            //}

        }
    }

    private void FormMain_KeyUp(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 17 && IsManualSpotMode)
        {
            IsManualSpotMode = false;
            FormProperty.checkBoxManualMaskMode.Checked = false;
            Draw();
        }
    }

    #endregion

    #region 強度ヒストグラム関連


    public void SetFrequencyProfile()
    {
        maxIntensity = uint.MinValue;
        sumOfIntensity = 0;
        double sumOfSquare = 0;
        frequencyProfile = new Profile { Pt = [] };
        for (int i = 0; i < Ring.Intensity.Length; i++)
        {
            double intensity = Ring.Intensity[i];
            maxIntensity = Math.Max(maxIntensity, intensity);
            sumOfIntensity += intensity;
            sumOfSquare += intensity * intensity;
        }

        for (int i = 0; i < Ring.Frequency.Count; i++)
            frequencyProfile.Pt.Add(new PointD(Ring.Frequency.Keys[i], Ring.Frequency[Ring.Frequency.Keys[i]]));
        graphControlFrequency.Profile = frequencyProfile;
        variance = Math.Sqrt((Ring.Intensity.Length * sumOfSquare - sumOfIntensity * sumOfIntensity) / Ring.Intensity.Length / (Ring.Intensity.Length - 1));
    }

    private void graphControlFrequency_LinePositionChanged()
    {
        if (graphControlFrequency.VerticalLines.Length == 2)
        {
            var max = Math.Max(graphControlFrequency.VerticalLines[0].X, graphControlFrequency.VerticalLines[1].X);
            if (trackBarAdvancedMaxInt.Maximum < max)
                trackBarAdvancedMaxInt.Value = trackBarAdvancedMaxInt.Maximum;
            else if (trackBarAdvancedMinInt.Minimum > max)
                trackBarAdvancedMaxInt.Value = trackBarAdvancedMaxInt.Minimum;
            else
                trackBarAdvancedMaxInt.Value = max;

            var min = Math.Min(graphControlFrequency.VerticalLines[0].X, graphControlFrequency.VerticalLines[1].X);
            if (trackBarAdvancedMinInt.Maximum < min)
                trackBarAdvancedMinInt.Value = trackBarAdvancedMinInt.Maximum;
            else if (trackBarAdvancedMinInt.Minimum > min)
                trackBarAdvancedMinInt.Value = trackBarAdvancedMinInt.Minimum;
            else
                trackBarAdvancedMinInt.Value = min;
        }
    }

    #endregion

    #region Program updates
    private void programUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
    {
        toolStripProgressBar.Visible = true;

        (var Title, var Message, var NeedUpdate, var URL, var Path) = ProgramUpdates.Check(Version.Software, Version.VersionAndDate);

        if (!NeedUpdate)
            MessageBox.Show(Message, Title, MessageBoxButtons.OK);
        else if (MessageBox.Show(Message, Title, MessageBoxButtons.YesNo) == DialogResult.Yes)
            using (var wc = new WebClient())
            {
                long counter = 1;
                wc.DownloadProgressChanged += (s, ev) =>
                {
                    if (counter++ % 10 == 0)
                        ip.Report(ProgramUpdates.ProgressMessage(ev, sw));
                };

                wc.DownloadFileCompleted += (s, ev) =>
                {
                    if (ProgramUpdates.Execute(Path))
                        Close();
                    else
                        MessageBox.Show($"Failed to downlod {Path}. \r\nSorry!", "Error!");
                };
                sw.Restart();
                try
                {
                    wc.DownloadFileAsync(new Uri(URL), Path);
                }
                catch
                {
                    MessageBox.Show($"Failed update check. \r\nServer may be down. \r\nAccess https://github.com/seto77/{Version.Software}/releases/latest", "Error");
                }
            }
    }

    private bool skipProgressEvent { get; set; } = false;
    /// <summary>
    /// 進捗状況を更新
    /// </summary>
    /// <param name="current"></param>
    /// <param name="total"></param>
    /// <param name="elapsedMilliseconds">経過時間</param>
    /// <param name="message">メッセージ</param>
    /// <param name="interval">何回に一回更新するか</param>
    /// <param name="sleep"></param>
    /// <param name="showPercentage"></param>
    /// <param name="showEllapsedTime"></param>
    /// <param name="showRemainTime"></param>
    /// <param name="digit"></param>
    private void reportProgress(long current, long total, long elapsedMilliseconds, string message,
        int sleep = 0, bool showPercentage = true, bool showEllapsedTime = true, bool showRemainTime = true, int digit = 1)
    {
        if (skipProgressEvent || current > total)
            return;
        skipProgressEvent = true;
        try
        {
            toolStripProgressBar.Maximum = int.MaxValue;
            var ratio = (double)current / total;
            toolStripProgressBar.Value = (int)(ratio * toolStripProgressBar.Maximum);
            var ellapsedSec = elapsedMilliseconds / 1000.0;
            var format = $"f{digit}";

            if (showPercentage) message += $" Completed: {(ratio * 100).ToString(format)} %.";
            if (showEllapsedTime) message += $" Elappsed: {ellapsedSec.ToString(format)} s.";
            if (showRemainTime) message += $" Remaining: {(ellapsedSec / current * (total - current)).ToString(format)} s.";

            toolStripStatusLabel.Text = message;

            Application.DoEvents();

            if (sleep != 0) Thread.Sleep(sleep);
        }
        catch (Exception e)
        {

        }
        skipProgressEvent = false;
    }
    private void reportProgress((long current, long total, long elapsedMilliseconds, string message) o)
        => reportProgress(o.current, o.total, o.elapsedMilliseconds, o.message);

    #endregion

    #region Sequential Image関連
    private void toolStripMenuItemAllSequentialImages_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripMenuItemAllSequentialImages.Checked)
            toolStripMenuItemSelectedSequentialImages.Checked = false;

        FormSequentialImage.setRadio();
    }

    private void toolStripMenuItemSelectedSequentialImages_CheckedChanged(object sender, EventArgs e)
    {
        if (toolStripMenuItemSelectedSequentialImages.Checked)
            toolStripMenuItemAllSequentialImages.Checked = false;
        FormSequentialImage.setRadio();
    }
    #endregion

    #region Rotate, Pollalization処理
    public void FlipRotate_Pollalization_Background(bool zoomReset = true)
    {
        if (Skip) return;

        if (Ring.IntensityOriginal == null || Ring.Intensity.Length == 0 || pseudoBitmap.SrcValuesGray == null)
            return;

        int originalWidth = Ring.SrcImgSizeOriginal.Width;
        int originalHeight = Ring.SrcImgSizeOriginal.Height;

        if (toolStripComboBoxRotate.SelectedIndex == 0 || toolStripComboBoxRotate.SelectedIndex == 2)
            Ring.SrcImgSize = new Size(Ring.SrcImgSizeOriginal.Width, Ring.SrcImgSizeOriginal.Height);
        else
            Ring.SrcImgSize = new Size(Ring.SrcImgSizeOriginal.Height, Ring.SrcImgSizeOriginal.Width);

        Ring.IP.SrcWidth = Ring.SrcImgSize.Width;
        Ring.IP.SrcHeight = Ring.SrcImgSize.Height;
        pseudoBitmap.Width = Ring.SrcImgSize.Width;
        pseudoBitmap.Height = Ring.SrcImgSize.Height;
        SrcImgSize = Ring.SrcImgSize;
        scalablePictureBox.ResetMinimumZoomValue();

        //Flip & Rotate処理ここから

        //  Ring.Flip
        Ring.Intensity = Ring.FlipAndRotate(Ring.IntensityOriginal, Ring.IP.SrcWidth,
            flipVerticallyToolStripMenuItem.Checked,
            flipHorizontallyToolStripMenuItem.Checked,
            toolStripComboBoxRotate.SelectedIndex);

        //Flip & Rotate処理 ここまで

        //Background補正ここから

        if (Ring.Background != null && Ring.Background.Length == Ring.Intensity.Length)
            Ring.Intensity = Ring.SubtractBackground(Ring.Intensity, Ring.Background, FormProperty.numericBoxBackgroundCoeff.Value);
        //Background補正ここまで

        //偏光補正ここから
        if (FormProperty != null && FormProperty.checkBoxCorrectPolarization.Checked)
        {
            sw.Restart();
            #region Ringのスタティック関数に移動
            /*
            double SinTau = Math.Sin(IP.tau), CosTau = Math.Cos(IP.tau);
            double SinPhi = Math.Sin(IP.phi), CosPhi = Math.Cos(IP.phi), sinPhi2 = SinPhi * SinPhi, cosPhi2 = CosPhi * CosPhi, cosPhiSinPhi = CosPhi * SinPhi;
            double tanKsi = Math.Tan(IP.ksi);//
            double sinPhiSinTau = SinPhi * SinTau, cosPhiSinTau = CosPhi * SinTau;
            double numer1 = (cosPhiSinPhi - CosPhi * CosTau * SinPhi);
            double temp2 = (cosPhi2 + CosTau * sinPhi2);
            double temp3 = (cosPhi2 * CosTau + sinPhi2);
            double fd = IP.FilmDistance, fd2 = fd * fd;
            double sizeX = IP.PixSizeX, sizeY = IP.PixSizeY;
            double centX = IP.CenterX, centY = IP.CenterY;
            Func<double, double, double> coeff;
            if (FormProperty.radioButtonChiRight.Checked || FormProperty.radioButtonChiLeft.Checked)
                coeff = new Func<double, double, double>((x2, y2) => (1 - x2 / (x2 + y2 + fd2)));
            else
                coeff = new Func<double, double, double>((x2, y2) => (1 - y2 / (x2 + y2 + fd2)));

            //Parallel.Forを使わないほうが早い
            int i = 0;
            for (int pixY = 0; pixY < Ring.SrcImgSize.Height; pixY++)
            {
                double tempY = (pixY - centY) * sizeY;
                double temp4 = tempY * cosPhiSinTau + fd;
                double temp5 = tempY * numer1;
                double temp6 = tempY * temp3;
                double temp7 = tempY * tanKsi;

                for (int pixX = 0; pixX < Ring.SrcImgSize.Width; pixX++)
                {
                    double tempX = (pixX - centX) * sizeX + temp7;
                    double temp8 = fd / (temp4 - tempX * sinPhiSinTau);
                    double x = (temp5 + tempX * temp2) * temp8;
                    double y = (tempX * numer1 + temp6) * temp8;
                    double x2 = x * x, y2 = y * y;
                    Ring.Intensity[i] /= coeff(x2, y2);
                    i++;
                }
            }
            */
            #endregion

            int index = FormProperty.radioButtonChiRight.Checked || FormProperty.radioButtonChiLeft.Checked ? 0 : 1;
            Ring.Intensity = Ring.CorrectPolarization(index);
            this.toolStripStatusLabel.Text = "Calculating Time (Polarization Correction):  " + (sw.ElapsedMilliseconds).ToString() + "ms";
        }
        //偏光補正ここまで

        Ring.CalcFreq();
        SetFrequencyProfile();//

        pseudoBitmap.SrcValuesGray = [.. Ring.Intensity];
        pseudoBitmap.SrcValuesGrayOriginal = [.. Ring.Intensity];

        IntegralArea_Changed(new object(), new EventArgs());
        if (zoomReset)
            scalablePictureBox.Zoom = 0;
    }

    #endregion

    #region 画像の統計情報関連

    public void SetStasticalInformation(bool renewArea = true)
    {
        //矩形の大きさ情報
        int left = Math.Max((int)(scalablePictureBox.AreaRectangle.X + 1), 0);
        int top = Math.Max((int)(scalablePictureBox.AreaRectangle.Y + 1), 0);
        int right = Math.Min((int)(scalablePictureBox.AreaRectangle.X + scalablePictureBox.AreaRectangle.Width), Ring.SrcImgSize.Width - 1);
        int bottom = Math.Min((int)(scalablePictureBox.AreaRectangle.Y + scalablePictureBox.AreaRectangle.Height), Ring.SrcImgSize.Height - 1);

        var sb = new StringBuilder();

        var data = new List<double>();
        for (int y = top; y <= bottom; y++)
            for (int x = left; x <= right; x++)
                data.Add(Ring.Intensity[Ring.SrcImgSize.Width * y + x]);

        if (data.Count == 0)
        {
            textBoxStatisticsSelectedArea.Text = textBoxStatisticsSelectedAreaSequential.Text = "";
            return;
        }

        sb.AppendLine($"Area:\t{data.Count.ToString()} pixels");

        double sumValue = data.Sum();
        sb.AppendLine($"Sum:\t{sumValue.ToString("g9")}");

        double averageValue = data.Average();
        sb.AppendLine($"Average:\t{averageValue.ToString("g9")}");

        double maxValue = data.Max();
        int maxIndex = data.FindIndex(d1 => d1 == maxValue);

        Point maxValuePoint = new(maxIndex % (right - left + 1) + left, maxIndex / (right - left + 1) + top);
        sb.AppendLine($"Max.:\t{maxValue.ToString("g9")} @ ({maxValuePoint.X}, {maxValuePoint.Y})");

        double minValue = data.Min();
        int minIndex = data.FindIndex(d1 => d1 == minValue);
        Point minValuePoint = new(minIndex % (right - left + 1) + left, minIndex / (right - left + 1) + top);
        sb.AppendLine($"Min.:\t{minValue.ToString("g9")} @ ({minValuePoint.X}, {minValuePoint.Y})");

        double variance = data.Average(d => d * d) - sumValue * sumValue / data.Count / data.Count;
        sb.AppendLine("Variance:\t" + variance.ToString("g9"));

        textBoxStatisticsSelectedArea.Text = sb.ToString();

        if (SequentialImageMode && renewArea)
        {
            var dataList = new List<List<double>>();
            sb.Clear();
            for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
            {
                dataList.Add([]);
                for (int y = top; y <= bottom; y++)
                    for (int x = left; x <= right; x++)
                        dataList[i].Add(Ring.SequentialImageIntensities[i][Ring.SrcImgSize.Width * y + x]);
            }
            sb.AppendLine("No.\tAverage\tMax.\tMin\tVariance");
            for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
            {
                sumValue = dataList[i].Sum();
                averageValue = dataList[i].Average();
                variance = dataList[i].Average(d => d * d) - sumValue * sumValue / dataList[i].Count / dataList[i].Count;
                maxValue = dataList[i].Max();
                minValue = dataList[i].Min();
                sb.AppendLine($"#{i.ToString("000")}\t{averageValue.ToString("g6")}\t{maxValue.ToString("g6")}\t{minValue.ToString("g6")}\t{variance.ToString("g6")}");


            }
            textBoxStatisticsSelectedAreaSequential.Text = sb.ToString();
        }
    }

    private void buttonMag_Click(object sender, EventArgs e)
    {
        var name = (sender as Button).Name;
        if (name.Contains("Mag1"))
            scalablePictureBox.Zoom = 1;
        else if (name.Contains("Mag2"))
            scalablePictureBox.Zoom = 2;
        else if (name.Contains("Mag4"))
            scalablePictureBox.Zoom = 4;
        else if (name.Contains("Mag_2"))
            scalablePictureBox.Zoom = 0.5;
        else if (name.Contains("Mag_4"))
            scalablePictureBox.Zoom = 0.25;
        else if (name.Contains("Mag_8"))
            scalablePictureBox.Zoom = 0.125;
        else if (name.Contains("Mag_16"))
            scalablePictureBox.Zoom = 0.0625;
    }



    bool skipSelectedAreaChangedEvent = false;
    private void numericUpDownSelectedArea_ValueChanged(object sender, EventArgs e)
    {
        if (skipSelectedAreaChangedEvent)
            return;
        double left = Math.Max((double)Math.Min(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value), 0);
        double right = Math.Min((double)Math.Max(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value), Ring.SrcImgSize.Width - 1);
        double top = Math.Max((double)Math.Min(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), 0);
        double bottom = Math.Min((double)Math.Max(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), Ring.SrcImgSize.Height - 1);

        scalablePictureBox.AreaRectangle = new RectangleD(left - 0.5, top - 0.5, right - left + 1, bottom - top + 1);
        scalablePictureBox.Refresh();

        SetStasticalInformation(true);
    }

    #endregion

    #region IPAのマクロ操作を提供するサブクラス
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

        }

        #region PDIClass

        public class PDIClass : MacroSub
        {
            Macro p;
            public PDIClass(Macro _p) : base(_p.main)
            {
                p = _p;
                p.help.Add("IPA.PDI.RunMacro() # Execute a macro code in PDIndexer.");
                p.help.Add("IPA.PDI.RunMacroName(string name) # Execute a macro code in PDIndexer. \r\n Name is macro name on PDI.");
                p.help.Add("IPA.PDI.RunMacro(obj1, obj2, ...)# Execute a macro code in PDIndexer. \r\n Parameters (obj1, obj2,) can be readable \r\n on PDI as 'Obj[1]', 'Obj[2]', ... ");
                p.help.Add("IPA.PDI.RunMacroName(string name, obj1, obj2, ...) # Execute a macro code in PDIndexer. \r\n Parameters (obj1, obj2,) can be readable \r\n on PDI as 'Obj[1]', 'Obj[2]', ... \r\n Name is macro name on PDI.");
                p.help.Add("IPA.PDI.Timeout # Set/get timeout second for macro operation. Default value is 30 sec.");
                p.help.Add("IPA.PDI.Debug #True/False. \r\n If true, macro on PDI will be executed with step-by-step.");
            }
            public bool Debug = false;
            public int Timeout { get; set; }

            public void RunMacro(params object[] obj)
            {
                RunMacro("", obj);
            }
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
                        Clipboard.SetDataObject(new MacroTriger("PDI", Debug, obj, name));
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
                p.help.Add("IPA.Image.NegativeGradient  # True/False. \r\n If true, an image is drawn with negative gradient. \r\n This parameter is a counterpart of 'IPA.Image.PositiveGradient'");
                p.help.Add("IPA.Image.PositiveGradient  # True/False.  \r\n If true, an image is drawn with positive gradient. \r\n This parameter is a counterpart of 'IPA.Image.NegativeGradient'");
                p.help.Add("IPA.Image.LinearScale  # True/False. \r\n If true, an image is drawn with liner-scale. \r\n This parameter is a counterpart of 'IPA.Image.LogScale'");
                p.help.Add("IPA.Image.LogScale   # True/False. \r\n If true, an image is drawn with log-scale. \r\n This parameter is a counterpart of 'IPA.Image.LinerScale'");
                p.help.Add("IPA.Image.GrayScale  # True/False. \r\n If true, an image is drawn with gray-scale. \r\n This parameter is a counterpart of 'IPA.Image.ColorScale'");
                p.help.Add("IPA.Image.ColorScale  # True/False. \r\n If true, an image is drawn with color-scale. \r\n This parameter is a counterpart of 'IPA.Image.GrayScale'");
                p.help.Add("IPA.Image.Maximum  #  Float. \r\n Set/get maximum level of brightness.");
                p.help.Add("IPA.Image.Minimum  # Float. \r\n Set/get miniimum level of brightness.");
                p.help.Add("IPA.Image.CanvasMagnification # Float. \r\n Set/get magnification of image");
                p.help.Add("IPA.Image.SetCanvasSize(int Width, int Height)  # Set canvas size (width and height) of picture box in pixel unit.");
            }

            public bool NegativeGradient
            {
                set => Execute(new Action(() => p.main.comboBoxGradient.SelectedIndex = value ? 1 : 0));
                get => Execute(() => p.main.comboBoxGradient.SelectedIndex == 1);
            }
            public bool PositiveGradient
            {
                set => Execute(new Action(() => p.main.comboBoxGradient.SelectedIndex = value ? 0 : 1));
                get => Execute(() => p.main.comboBoxGradient.SelectedIndex == 0);
            }

            public bool LinearScale
            {
                set => Execute(new Action(() => p.main.comboBoxScale1.SelectedIndex = value ? 1 : 0));
                get => Execute(() => p.main.comboBoxScale1.SelectedIndex == 1);
            }
            public bool LogScale
            {
                set => Execute(new Action(() => p.main.comboBoxScale1.SelectedIndex = value ? 0 : 1));
                get => Execute(() => p.main.comboBoxScale1.SelectedIndex == 0);
            }

            public bool GrayScale
            {
                set => Execute(new Action(() => p.main.comboBoxScale2.SelectedIndex = value ? 1 : 0));
                get => Execute(() => p.main.comboBoxScale2.SelectedIndex == 1);
            }
            public bool ColorScale
            {
                set => Execute(new Action(() => p.main.comboBoxScale2.SelectedIndex = value ? 0 : 1));
                get => Execute(() => p.main.comboBoxScale2.SelectedIndex == 0);
            }

            public double Maximum
            {
                set => Execute(new Action(() =>
                         p.main.trackBarAdvancedMaxInt.Value = Math.Max(Math.Min(p.main.trackBarAdvancedMaxInt.Maximum, value), p.main.trackBarAdvancedMaxInt.Minimum)
                        ));
                get => Execute(() => p.main.trackBarAdvancedMaxInt.Value);
            }
            public double Minimum
            {
                set => Execute(new Action(() =>
                         p.main.trackBarAdvancedMinInt.Value = Math.Max(Math.Min(p.main.trackBarAdvancedMinInt.Maximum, value), p.main.trackBarAdvancedMinInt.Minimum)
                        ));
                get => Execute(() => p.main.trackBarAdvancedMinInt.Value);
            }

            public double CanvasMagnification
            {
                set => Execute(new Action(() => p.main.scalablePictureBox.Zoom = value));
                get => Execute(() => p.main.scalablePictureBox.Zoom);
            }

            public void SetCanvasCenter(double x, double y) => Execute(new Action(() => p.main.scalablePictureBox.Center = new PointD(x, y)));

            public void SetCanvasSize(int width, int height) => Execute(new Action(() =>
            {
                if (width < 1 || height < 1) return;
                p.main.splitContainer1.FixedPanel = FixedPanel.Panel2;
                var clientSize = p.main.scalablePictureBox.ClientSize;
                var mainSize = p.main.Size;
                var destSize = new Size(mainSize.Width + width - clientSize.Width, mainSize.Height + height - clientSize.Height);
                p.main.Size = destSize;
                p.main.splitContainer1.FixedPanel = FixedPanel.None;
            }));

            public void SetArea(double top, double bottom, double left, double right) => Execute(new Action(() =>
            {
                int width = (int)(CanvasMagnification * (right - left) + 0.5);
                int height = (int)(CanvasMagnification * (bottom - top) + 0.5);

                if (width < 1 || height < 1) return;

                SetCanvasSize(width, height);
                SetCanvasCenter((left + right) / 2.0, (bottom + top) / 2.0);
            }));

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
                p.help.Add("IPA.Mask.MaskSpots() # Mask spots.");
                p.help.Add("IPA.Mask.ClearMask() # Clear the current masks.");
                p.help.Add("IPA.Mask.MaskAll() # Mask all area.");
                p.help.Add("IPA.Mask.InvertMask() # Invert the current mask state.");
                p.help.Add("IPA.Mask.MaskTop() # Mask the top half area.");
                p.help.Add("IPA.Mask.MaskBottom() # Mask the bottom half area.");
                p.help.Add("IPA.Mask.MaskRight() # Mask the right half area.");
                p.help.Add("IPA.Mask.MaskLeft() # Mask the left half area.");

                p.help.Add("IPA.Mask.TakeOver # Integer. Set/get the take over mask setting. 0: None, 1: Take over the current mask state. 2: Take over the mask file.");
            }

            public void MaskSpots() => Execute(new Action(() => p.main.MaskSpots()));
            public void ClearMask() => Execute(new Action(() => p.main.ClearMask()));
            public void InvertMask() => Execute(new Action(() => p.main.InvertMask()));
            public void MaskAll() => Execute(new Action(() => p.main.MaskAll()));
            public void MaskTop() => Execute(new Action(() => p.main.FormProperty.MaskTop()));
            public void MaskBottom() => Execute(new Action(() => p.main.FormProperty.MaskBottom()));
            public void MaskLeft() => Execute(new Action(() => p.main.FormProperty.MaskLeft()));
            public void MaskRight() => Execute(new Action(() => p.main.FormProperty.MaskRight()));

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
                p.help.Add("IPA.Profile.GetProfile() # Get profile.");
                p.help.Add("IPA.Profile.GetProfile(string filename) # Get profile. \r\n Profile will be saved to the assigned filename");
                p.help.Add("IPA.Profile.ConcentricIntegration # True/False. \r\n If true, the image will be \r\n integrated concentrically (2θ-intensity).");
                p.help.Add("IPA.Profile.RadialIntegration # True/False. \r\n If true, the image will be \r\nintegrated radially (pizza-cut).");
                p.help.Add("IPA.Profile.FindCenterBeforeGetProfile # True/False. \r\n If true, 'Find Center' will be \r\n executed before 'Get Profile'");
                p.help.Add("IPA.Profile.FindSpotsBeforeGetProfile  # True/False. \r\n If true, 'Mask Spots' will be \r\n executed before 'Get Profile'");
                p.help.Add("IPA.Profile.SendProfileViaClipboard  # True/False. \r\n If true, the profile will be sent to PDIndexer via clipboard");
                p.help.Add("IPA.Profile.SaveProfileAfterGetProfile  # True/False. \r\n If true, the profile will be saved after 'Get Profile'");
                p.help.Add("IPA.Profile.SaveProfileAsPDI   # True/False. \r\n If true, the profile will be saved as PDI format");
                p.help.Add("IPA.Profile.SaveProfileAsCSV  # True/False. \r\n If true, the profile will be saved as CSV format");
                p.help.Add("IPA.Profile.SaveProfileAsTSV  # True/False. \r\n If true, the profile will be saved as TSV format");
                p.help.Add("IPA.Profile.SaveProfileAsGSAS  # True/False. \r\n If true, the profile will be saved as GSAS format");
                p.help.Add("IPA.Profile.SaveProfileInOneFile   # True/False. \r\n If true, the profiles of sequential image or azimuthal division data will be saved in one file.");
                p.help.Add("IPA.Profile.SaveProfileAtImageDirectory   # True/False. \r\n If true, the profiles will be saved in the same directory of the image.");
                p.help.Add("IPA.Profile.AzimuthalDivision  # True/False. \r\n If true, the profile will be processed azimuthal division mode.");
                p.help.Add("IPA.Profile.AzimuthalDivisionNumber  # Integer. \r\n Sets the number of Debye ring to be divided.");
            }

            public int AzimuthalDivisionNumber
            {
                set => Execute(new Action(() => p.main.toolStripComboBoxAzimuthalDivisionNumber.Text = value.ToString()));
                get => Execute(() => p.main.toolStripComboBoxAzimuthalDivisionNumber.Text.ToInt());
            }

            public bool AzimuthalDivision
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemAzimuthalDivisionAnalysis.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemAzimuthalDivisionAnalysis.Checked);
            }

            public bool ConcentricIntegration
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemConcenctricIntegration.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemConcenctricIntegration.Checked);
            }
            public bool RadialIntegration
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemRadialIntegration.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemRadialIntegration.Checked);
            }
            public bool FindCenterBeforeGetProfile
            {
                set => Execute(new Action(() => p.main.findCenterBeforeGetProfileToolStripMenuItem.Checked = value));
                get => Execute(() => p.main.findCenterBeforeGetProfileToolStripMenuItem.Checked);
            }
            public bool FindSpotsBeforeGetProfile
            {
                set => Execute(new Action(() => p.main.maskSpotsBeforeGetProfileToolStripMenuItem.Checked = value));
                get => Execute(() => p.main.maskSpotsBeforeGetProfileToolStripMenuItem.Checked);
            }
            public bool SendProfileViaClipboard
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemSendProfileToPDIndexer.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemSendProfileToPDIndexer.Checked);
            }
            public bool SaveProfileAfterGetProfile
            {
                set => Execute(new Action(() => p.main.FormProperty.checkBoxSaveFile.Checked = value));
                get => Execute(() => p.main.FormProperty.checkBoxSaveFile.Checked);
            }
            public bool SaveProfileAsPDI
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonAsPDIformat.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonAsPDIformat.Checked);
            }
            public bool SaveProfileAsCSV
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonAsCSVformat.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonAsCSVformat.Checked);
            }
            public bool SaveProfileAsTSV
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonAsTSVformat.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonAsTSVformat.Checked);
            }

            public bool SaveProfileAsGSAS
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonAsGSASformat.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonAsGSASformat.Checked);
            }

            public bool SaveProfileInOneFile
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonSaveInOneFile.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonSaveInOneFile.Checked);
            }

            public bool SaveProfileAtImageDirectory
            {
                set => Execute(new Action(() => p.main.FormProperty.radioButtonSaveAtImageDirectory.Checked = value));
                get => Execute(() => p.main.FormProperty.radioButtonSaveAtImageDirectory.Checked);
            }

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
                p.help.Add("IPA.IntegralProperty.ConcentricIntegration # True/False. \r\n If true, the image will be \r\n integrated concentrically (2θ-intensity).");
                p.help.Add("IPA.IntegralProperty.RadialIntegration # True/False. \r\n If true, the image will be \r\nintegrated radially (pizza-cut or cake-pattern).");
                p.help.Add("IPA.IntegralProperty.ConcentricStart # Float. \r\n Set/get start value for concentric integration mode.");
                p.help.Add("IPA.IntegralProperty.ConcentricEnd # Float. \r\n Set/get end value for concentric integration mode.");
                p.help.Add("IPA.IntegralProperty.ConcentricStart # Float. \r\n Set/get step value for concentric integration mode.");
                p.help.Add("IPA.IntegralProperty.ConcentricUnit # Integer. \r\n Set/get a unit of concentric integration mode. 0: Angle(°), 1: d-spacing(Å), 2: Length (mm)");
                p.help.Add("IPA.IntegralProperty.RadialRadius # Float. \r\n Set/get a donut radius for radial integration mode");
                p.help.Add("IPA.IntegralProperty.RadialWidth # Float. \r\n Set/get a donut width for radial integration mode");
                p.help.Add("IPA.IntegralProperty.RadialStep # Float. \r\n Set/get a sector angle (sweep step) for radial integration mode");
                p.help.Add("IPA.IntegralProperty.RadialUnit # Integer. \r\n Set/get a unit of concentric integration mode. 0: Angle(°), 2: d-spacing(Å)");
            }

            public bool ConcentricIntegration
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemConcenctricIntegration.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemConcenctricIntegration.Checked);
            }
            public bool RadialIntegration
            {
                set => Execute(new Action(() => p.main.toolStripMenuItemRadialIntegration.Checked = value));
                get => Execute(() => p.main.toolStripMenuItemRadialIntegration.Checked);
            }
            public double ConcentricStart
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStart.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxConcentricStart.Value);
            }
            public double ConcentricEnd
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricEnd.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxConcentricEnd.Value);
            }
            public double ConcentricStep
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStep.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxConcentricStep.Value);
            }

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
            public double RadialRadius
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialRadius.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxRadialRadius.Value);
            }
            public double RadialWidgh
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialRange.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxRadialRange.Value);
            }
            public double RadialStep
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxRadialStep.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxRadialStep.Value);
            }

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
                p.help.Add("IPA.Wave.SetWaveLength(float wavelength) # Set wavelength (float value) of incident beam in nm unit.");
                p.help.Add("IPA.Wave.WaveLength           # Float. \r\n Set/get wavelength of incident beam in nm unit.");

            }

            public void SetWaveLength(double x) => Execute(new Action(() => p.main.FormProperty.WaveLength = x));
            public double WaveLength
            {
                set => Execute(new Action(() => p.main.FormProperty.WaveLength = value));
                get => Execute(() => p.main.FormProperty.WaveLength);
            }

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
                p.help.Add("IPA.File.GetFileName() # Get a fil name. \r\n Returned string is a full path of the selected file.");
                p.help.Add("IPA.File.GetFileNames() # Get filenames. \r\n Returned value is a string array, \r\n each of which is a full path of selected files.");
                p.help.Add("IPA.File.GetAllFileNames() # Get all file names in the directory. \r\n Returned value is a string array, \r\n each of which is a full path of selected files.");
                p.help.Add("IPA.File.GetDirectoryPath() # Get a directory path.\r\n Returned string is a full path to the filename.\r\n If filename is omitted, selection dialog will open.");

                p.help.Add("IPA.File.ReadImage(string filename)          # Read image file. \r\n If filename is omitted, selection dialog will open.");
                p.help.Add("IPA.File.ReadImageHDF(string filename, bool Normarize) # Read HDF5 image file. \r\n If filename is omitted, selection dialog will open.");
                p.help.Add("IPA.File.SaveImageAsTIFF(string filename)    # Save image file as Tiff format. \r\n If filename is omitted, selection dialog will open.");
                p.help.Add("IPA.File.SaveImageAsPNG(string filename)     # Save image file as PNG format. \r\n If filename is omitted, selection dialog will open.");
                p.help.Add("IPA.File.SaveImageAsIPA(string filename)     # Save image file as IPA format. \r\n If filename is omitted, selection dialog will open.");

                p.help.Add("IPA.File.ReadParameter(string filename)      # Read parameter file. \r\n If filename is omitted or invalid, selection dialog will open.");
                p.help.Add("IPA.File.SaveParameter(string filename)      # Save parameter file. \r\n If filename is omitted or invalid, selection dialog will open.");
                p.help.Add("IPA.File.ReadMask(string filename)           # Read mask file. \r\n If filename is omitted or invalid, selection dialog will open.");
                p.help.Add("IPA.File.SaveMask(string filename)           # Save mask file. \r\n If filename is omitted or invalid, selection dialog will open.");
            }

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


            public string GetFileName(string message = "") => Execute<string>(new Func<string>(() =>
            {
                var dlg = new OpenFileDialog() { Title = message };
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
            }));


            public string[] GetFileNames(string message = "") => Execute<string[]>(new Func<string[]>(() =>
            {
                var dlg = new OpenFileDialog { Multiselect = true, Title = message };
                return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : [];
            }));

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

            public void SaveImageAsTIFF(string fileName = "") => Execute(() => p.main.saveImageAsTiff(fileName));
            public void SaveImageAsPNG(string fileName = "") => Execute(() => p.main.saveImageAsPng(fileName));
            public void SaveImageAsIPA(string fileName = "") => Execute(() => p.main.FormSaveImage.SaveImageAsIPA(fileName));
            public void SaveImageAsCSV(string fileName = "") => Execute(() => p.main.saveImageAsCSV(fileName));
            public void ReadImageHDF(string _fileName, bool? flag) => Execute(() => p.main.ReadImage(_fileName, flag));

            /// <summary>
            /// Read image file. if filename is omitted, dialog will open.
            /// </summary>
            /// <param name="_fileName"></param>
            public void ReadImage(string _fileName = "", bool? flag = null) => Execute(new Action(() =>
            {
                if (!System.IO.File.Exists(_fileName))
                    p.main.readImageToolStripMenuItem_Click(new object(), new EventArgs());
                else
                    p.main.ReadImage(_fileName, flag);
            }));

            public void SaveImage(string fileName = "") => Execute(new Action(() => p.main.saveImageAsTiff(fileName)));

            /// <summary>
            /// Read parameter file.
            /// </summary>
            /// <param name="_fileName"></param>
            public void ReadParameter(string fileName = "") => Execute(new Action(() => p.main.ReadParameter(fileName, true)));

            public void SaveParameter(string fileName = "") => Execute(new Action(() => p.main.SaveParameter(fileName, true)));

            public void ReadMask(string fileName = "") => Execute(new Action(() => p.main.ReadMask(fileName)));
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
                p.help.Add("IPA.Sequential.SequentialImageMode # True/False. Get whether the current file is sequential image or not.");
                p.help.Add("IPA.Sequential.Count # Integer.\r\n  Get the number of images");
                p.help.Add("IPA.Sequential.SelectedIndex # Integer. \r\n Set or get the selected index of the current sequential image.");
                p.help.Add("IPA.Sequential.SelectedIndices # Array of itegers (like 1,3,5,9). \r\n Set or get the selected indices of the current sequential image.");

                p.help.Add("IPA.Sequential.SelectIndex(int index) # Set number of selected index.");
                p.help.Add("IPA.Sequential.AppendIndex(int index) # Append selected index to current selections.");

                p.help.Add("IPA.Sequential.SelectIndices(int Start,int End) # Set selected indices (from int_Start to int_End).");
                p.help.Add("IPA.Sequential.AppendIndices(int Start,int End) # Append indices (from int_Start to int_End) to current selections");

                p.help.Add("IPA.Sequential.MultiSelection # True/False. \r\n Set or get the state of multi-selection mode.");
                p.help.Add("IPA.Sequential.Averaging # True/False. \r\n Set or get the state of averaging mode .");

                p.help.Add("IPA.Sequential.Target_SelectedImages # True/False. \r\n If set true, the selected images are targets for 'Get Profile'.");
                p.help.Add("IPA.Sequential.Target_AllImages # True/False. \r\n If set true, all images are targets for 'Get Profile'.");
                p.help.Add("IPA.Sequential.Target_TopmostImage # True/False. \r\n If set true, the topmost image will be target for 'Get Profile'.");
            }



            public bool Target_SelectedImages
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileSelectedImages.Checked = value));
                get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileSelectedImages.Checked);
            }

            public bool Target_AllImages
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileAllImages.Checked = value));
                get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileAllImages.Checked);
            }

            public bool Target_TopmostImage
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.radioButtonGetProfileOnlyTopmost.Checked = value));
                get => Execute(() => p.main.FormSequentialImage.radioButtonGetProfileOnlyTopmost.Checked);
            }

            public bool SequentialImageMode => Execute(() => p.main.SequentialImageMode);
            public int SelectedIndex
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.SelectedIndex = value));
                get => Execute(() => p.main.FormSequentialImage.SelectedIndex);
            }

            public int Count => Execute(() => p.main.FormSequentialImage.MaximumNumber);

            public int[] SelectedIndices
            {
                set { Execute(new Action(() => p.main.FormSequentialImage.SelectedIndices = value)); }
                get => Execute(() => p.main.FormSequentialImage.SelectedIndices);
            }

            public bool MultiSelection
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.MultiSelection = value));
                get => Execute(() => p.main.FormSequentialImage.MultiSelection);
            }
            public bool Averaging
            {
                set => Execute(new Action(() => p.main.FormSequentialImage.AverageMode = value));
                get => Execute(() => p.main.FormSequentialImage.AverageMode);
            }

            /// <summary>
            /// 選択する
            /// </summary>
            /// <param name="n"></param>
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
                p.help.Add("IPA.Detector.SetCenter(float X, float Y) # Set center (direct spot) position in pixel unit.");
                p.help.Add("IPA.Detector.CenterX # Float. \r\n Set or get X value of center (direct spot) position in pixel unit.");
                p.help.Add("IPA.Detector.CenterY # Float. \r\n Set or get Y value of center (direct spot) position in pixel unit.");
                p.help.Add("IPA.Detector.CameraLength # Float. \r\n Set or get camera length in mm unit.");
                p.help.Add("IPA.Detector.PixelSizeX  # Float. \r\n Set or get pixel X value (pixel width) in mm unit.");
                p.help.Add("IPA.Detector.PixelSizeY  # Float. \r\n Set or get pixel Y value (pixel height) in mm unit.");
                p.help.Add("IPA.Detector.PixelKsi  # Float. \r\n Set or get pixel Ksi value (pixel height) in degree unit.");
                p.help.Add("IPA.Detector.TiltPhi  # Float. \r\n Set or get tilt phi value in degree unit.");
                p.help.Add("IPA.Detector.TiltTau  # Float. \r\n Set or get tilt tau value in degree unit.");
            }


            public void SetCenter(double x, double y) => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(x, y)));

            public void SetCameraLength(double x) => Execute(new Action(() => p.main.FormProperty.CameraLength1 = x));

            public double CenterX
            {
                set => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(value, p.main.FormProperty.DirectSpotPosition.Y)));
                get => Execute(() => p.main.FormProperty.DirectSpotPosition.X);
            }
            public double CenterY
            {
                set => Execute(new Action(() => p.main.FormProperty.DirectSpotPosition = new PointD(p.main.FormProperty.DirectSpotPosition.X, value)));
                get => Execute(() => p.main.FormProperty.DirectSpotPosition.Y);
            }
            public double CameraLength
            {
                set => Execute(new Action(() => p.main.FormProperty.CameraLength1 = value));
                get => Execute(() => p.main.FormProperty.CameraLength1);
            }
            public double PixelSizeX
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeX.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxPixelSizeX.Value);
            }
            public double PixelSizeY
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeY.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxPixelSizeY.Value);
            }
            public double PixelKsi
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxPixelKsi.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxPixelKsi.Value);
            }
            public double TiltPhi
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxTiltPhi.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxTiltPhi.Value);
            }
            public double TiltTau
            {
                set => Execute(new Action(() => p.main.FormProperty.numericBoxTiltTau.Value = value));
                get => Execute(() => p.main.FormProperty.numericBoxTiltTau.Value);
            }

        }

    }


    #endregion

    #endregion
}