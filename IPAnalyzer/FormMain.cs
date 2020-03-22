using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Runtime.InteropServices;
using System.Threading;
using Crystallography;
using Crystallography.Controls;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using IronPython.Hosting;
using System.Threading.Tasks;
using System.Numerics;
using System.Diagnostics;
using System.Net;

namespace IPAnalyzer
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    public partial class FormMain : System.Windows.Forms.Form
    {
        public bool IsFlatPanelMode { get { return FormProperty.radioButtonFlatPanel.Checked; } }

        public PseudoBitmap pseudoBitmap = new PseudoBitmap();
        public bool IsDrawing = true;

        public Size SrcImgSize;
        public int ThreadTotal = 16;

        DiffractionProfile diffractionProfile = new DiffractionProfile();

        public bool IsImageReady = false;

        public WaitDlg InitialDialog;
        public FormIntTable FormIntTable;
        public FormAutoProcedure FormAutoProc;
        public FormFindParameter FormFindParameter;
        public FormDrawRing FormDrawRing;
        public FormCalibrateIntensity FormCalibrateIntensity;

        public FormSequentialImage FormSequentialImage;
        public FormParameterOption FormParameterOption;

        public FormOptimizeSaclaEH5Parameter FormSaclaParameter;

        public FormSaveImage FormSaveImage;

        public FormProperty FormProperty;

        public FormMacro FormMacro;

        public Profile oneDimensionalProfile = new Profile();
        public Profile frequencyProfile = new Profile();

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
        public string FileName
        {
            set;get;
        }
        private string fileNameSub = "";
        public string FileNameSub
        {
            set { fileNameSub = value; }
            get { return fileNameSub; }
        }

        private string filePath = "";
        public string FilePath
        {
            set { filePath = value; }
            get { return filePath; }
        }

        public bool SequentialImageMode
        {
            set { toolStripButtonImageSequence.Enabled = value; }
            get { return toolStripButtonImageSequence.Enabled; }

        }

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

        public PointD selectedSpot = new PointD(double.NaN,double.NaN);

        private IProgress<(long, long, long, string)> ip;//IReport

        //public string ImageFilterString = "FujiBAS2000/2500; R-AXIS4/5; ITEX; Bruker CCD; IP Display; IPAimage; Fuji FDL; Rayonix; Marresearch; Perkin Elmer; ADSC; RadIcon; general image"
        //        + "|*.img;*.stl;*.ccd;*.ipf;*.ipa;*.0???;*.gel;*.osc;*.mar*;*.mccd; *.his; *.h5; *.raw; *.bmp;*.jpg;*.tif";


        private IntPtr NextHandle;
        private const int WM_DRAWCLIPBOARD = 0x0308;

        private const int WM_CHANGECBCHAIN = 0x030D;
        [DllImport("user32")]
        public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);
        [DllImport("user32")]
        public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);
        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static int SendMessage(IntPtr hWnd, int Msg, IntPtr wParam, IntPtr lParam);
        //クリップボード監視スレッド
        protected override void WndProc(ref Message msg)
        {
            switch (msg.Msg)
            {
                case WM_DRAWCLIPBOARD:
                    using (Mutex clipboard = new Mutex(false, "ClipboardOperation"))
                    {
                        if (clipboard.WaitOne(10000, false))
                        {
                            if (((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(ImageIO.IPAImage)))
                            {
                                /*
                                try
                                {
                                    IDataObject data = Clipboard.GetDataObject();
                                    ImageIO.IPAImage ipa = (ImageIO.IPAImage)data.GetData(typeof(ImageIO.IPAImage));

                                    ImageIO.IPAImageReader(ipa);

                                    FormProperty.waveLengthControl.Property = ipa.WaveProperty;
                                    FormProperty.CameraLength = ipa.CameraLength;
                                    FormProperty.numericalTextBoxPixelSizeX.Value = FormProperty.numericalTextBoxPixelSizeY.Value = ipa.Resolution;
                                    FormProperty.ImageCenter = ipa.Center;
                                    FormProperty.numericalTextBoxTiltCorrectionPhi.Value = FormProperty.numericalTextBoxTiltCorrectionTau.Value = FormProperty.numericalTextBoxPixelKsi.Value = 0;

                                    ReadImage("ClipBoard.ipa");
                                }
                                catch
                                {
                                }
                                 */
                            }
                            else if (((IDataObject)Clipboard.GetDataObject()).GetDataPresent(typeof(Crystal2)))
                            {
                                if (FormFindParameter != null && FormFindParameter.Visible && FormFindParameter.formCrystal.Visible)
                                {
                                    IDataObject data = Clipboard.GetDataObject();
                                    var c2 = (Crystal2)data.GetData(typeof(Crystal2));
                                    FormFindParameter.formCrystal.CrystalChanged(Crystal2.GetCrystal(c2));
                                }
                            }
                            clipboard.ReleaseMutex();
                            if ((int)NextHandle != 0)
                                SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                            
                        }
                        clipboard.Close();
                    }
                    break;
                case WM_CHANGECBCHAIN:
                    if (msg.WParam == NextHandle)
                        NextHandle = (IntPtr)msg.LParam;
                    else if ((int)NextHandle != 0)
                        SendMessage(NextHandle, msg.Msg, msg.WParam, msg.LParam);
                    break;
            }
            base.WndProc(ref msg);

        }

        public FormMain()
        {
            ip = new Progress<(long, long, long, string)>(o => reportProgress(o));//IReport

            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\IPAnalyzer");
            try
            {
                string culture = (string)regKey.GetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);
                if (culture.ToLower().StartsWith("ja"))
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ja");
                else
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en");
            }
            catch { }

            InitializeComponent();

            

            //splitContainer2.SplitterDistance = scalablePictureBoxThumbnail.Height + splitContainer2.SplitterDistance - scalablePictureBoxThumbnail.Width;
        }

        #region フォームロード＆クローズ

        public void SaveRegistry()
        {
            RegistryKey regKey = Registry.CurrentUser.CreateSubKey("Software\\Crystallography\\IPAnalyzer");
            if (regKey == null) return;

            try
            {

                regKey.SetValue("Culture", Thread.CurrentThread.CurrentUICulture.Name);

                regKey.SetValue("initialDialog.AutomaricallyClose", InitialDialog.AutomaricallyClose);


                //Main関係
                regKey.SetValue("formMainWidth", Width);
                regKey.SetValue("formMainHeight", Height);
                regKey.SetValue("formMainLocationX", Location.X);
                regKey.SetValue("formMainLocationY", Location.Y);

                //FindParameter関係
                regKey.SetValue("formFindParameterWidth", FormFindParameter.Width);
                regKey.SetValue("formFindParameterHeight", FormFindParameter.Height);
                regKey.SetValue("formFindParameterLocationX", FormFindParameter.Location.X);
                regKey.SetValue("formFindParameterLocationY", FormFindParameter.Location.Y);

                

                //IntTable関係
                regKey.SetValue("formIntTableWidth", FormIntTable.Width);
                regKey.SetValue("formIntTableHeight", FormIntTable.Height);
                regKey.SetValue("formIntTableLocationX", FormIntTable.Location.X);
                regKey.SetValue("formIntTableLocationY", FormIntTable.Location.Y);
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
                regKey.SetValue("textBoxPixelKsiText", FormProperty.numericalTextBoxPixelKsi.Text);

                regKey.SetValue("textBoxFilmDistanceText", FormProperty.CameraLengthText);
                regKey.SetValue("textBoxCenterPositionXText", FormProperty.numericBoxCenterPositionX.Text);
                regKey.SetValue("textBoxCenterPositionYText", FormProperty.numericBoxCenterPositionY.Text);

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

                regKey.SetValue("checkBoxTiltCorrectionChecked", FormProperty.checkBoxTiltCorrection.Checked);
                regKey.SetValue("textBoxTiltCorrectionPhiText", FormProperty.numericBoxTiltCorrectionPhi.Text);
                regKey.SetValue("textBoxTiltCorrectionPsiText", FormProperty.numericBoxTiltCorrectionTau.Text);

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


                regKey.SetValue("initialImageDirectory", initialImageDirectory);
                regKey.SetValue("initialParameterDirectory", initialParameterDirectory);
                regKey.SetValue("initialMasdDirectory", initialMaskDirectory);
                regKey.SetValue("filterIndex", filterIndex);

                regKey.SetValue("initialMasdDirectory", initialMaskDirectory);
                regKey.SetValue("filterIndex", filterIndex);


                //ここからイメージタイプごとのパラメータ書き込み
                for (int i = 0; i < Enum.GetValues(typeof(Ring.ImageTypeEnum)).Length; i++)
                {
                    regKey.SetValue("ImageTypeParameters.CneterPosX" + i.ToString(), FormProperty.ImageTypeParameters[i].CenterPosX);
                    regKey.SetValue("ImageTypeParameters.CneterPosY" + i.ToString(), FormProperty.ImageTypeParameters[i].CenterPosY);
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


                    initialImageDirectory = (string)regKey.GetValue("initialImageDirectory", "");
                    initialParameterDirectory = (string)regKey.GetValue("initialParameterDirectory", "");
                    initialMaskDirectory = (string)regKey.GetValue("initialMasdDirectory", "");
                    filterIndex = (int)regKey.GetValue("filterIndex", 0);
                }
                if (InitialDialog != null)
                {
                    InitialDialog.Location = new Point(Location.X + Width / 2 - InitialDialog.Width / 2, Location.Y + Height / 2 - InitialDialog.Height / 2);
                    InitialDialog.AutomaricallyClose = (string)regKey.GetValue("initialDialog.AutomaricallyClose", "False") == "True";
                }

                
                if ((int)regKey.GetValue("formFindParameterLocationY", FormFindParameter.Location.Y) >= 0)
                {
                    FormFindParameter.Width = (int)regKey.GetValue("formFindParameterWidth", FormFindParameter.Width);
                    FormFindParameter.Height = (int)regKey.GetValue("formFindParameterHeight", FormFindParameter.Height);
                    FormFindParameter.Location = new Point(
                        (int)regKey.GetValue("formFindParameterLocationX", FormFindParameter.Location.X),
                        (int)regKey.GetValue("formFindParameterLocationY", FormFindParameter.Location.Y));
                }
                

                if ((int)regKey.GetValue("formIntTableLocationY", FormIntTable.Location.Y) >= 0)
                {
                    FormIntTable.Width = (int)regKey.GetValue("formIntTableWidth", FormIntTable.Width);
                    FormIntTable.Height = (int)regKey.GetValue("formIntTableHeight", FormIntTable.Height);
                    FormIntTable.Location = new Point((int)regKey.GetValue("formIntTableLocationX", FormIntTable.Location.X),
                    (int)regKey.GetValue("formIntTableLocationY", FormIntTable.Location.Y));
                }
                if ((int)regKey.GetValue("formDrawRingLocationY", FormDrawRing.Location.Y) >= 0)
                {
                    FormDrawRing.Width = (int)regKey.GetValue("formDrawRingWidth", FormDrawRing.Width);
                    FormDrawRing.Height = (int)regKey.GetValue("formDrawRingHeight", FormDrawRing.Height);
                    FormDrawRing.Location = new Point((int)regKey.GetValue("formDrawRingLocationX", FormDrawRing.Location.X), (int)regKey.GetValue("formDrawRingLocationY", FormDrawRing.Location.Y));
                }
                //サイズ、位置関係終了

                if ((int)regKey.GetValue("formPropertyLocationY", FormProperty.Location.Y) >= 0)
                {
                    //formMain.formProperty.Width = (int)regKey.GetValue("formPropertyWidth", formMain.formProperty.Width);
                    //formMain.formProperty.Height = (int)regKey.GetValue("formPropertyHeight", formMain.formProperty.Height);
                    FormProperty.Location = new Point((int)regKey.GetValue("formPropertyLocationX", FormProperty.Location.X), (int)regKey.GetValue("formPropertyLocationY", FormProperty.Location.Y));
                   


                    FormProperty.numericBoxPixelSizeX.Text = (string)regKey.GetValue("textBoxPixelSizeXText", "0.1");
                    FormProperty.numericBoxPixelSizeY.Text = (string)regKey.GetValue("textBoxPixelSizeYText", "0.1");
                    FormProperty.numericalTextBoxPixelKsi.Text = (string)regKey.GetValue("textBoxPixelKsiText", "0");

                    FormProperty.CameraLengthText = (string)regKey.GetValue("textBoxFilmDistanceText", "445");
                    FormProperty.numericBoxCenterPositionX.Text = (string)regKey.GetValue("textBoxCenterPositionXText", "1500");
                    FormProperty.numericBoxCenterPositionY.Text = (string)regKey.GetValue("textBoxCenterPositionYText", "1500");

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
                    FormProperty.SectorRadiusTheta = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusTheta", FormProperty.SectorRadiusTheta));
                    FormProperty.SectorRadiusThetaRange = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusThetaRange", FormProperty.SectorRadiusThetaRange));
                    FormProperty.SectorRadiusD = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusD", FormProperty.SectorRadiusD));
                    FormProperty.SectorRadiusDRange = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorRadiusDRange", FormProperty.SectorRadiusDRange));
                    FormProperty.SectorAngle = Convert.ToDouble((string)regKey.GetValue("formProperty.SectorAngle", FormProperty.SectorAngle));

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
                    FormProperty.checkBoxTiltCorrection.Checked = (string)regKey.GetValue("checkBoxTiltCorrectionChecked", "True") == "True";
                    FormProperty.numericBoxTiltCorrectionPhi.Text = (string)regKey.GetValue("textBoxTiltCorrectionPhiText", FormProperty.numericBoxTiltCorrectionPhi.Text);
                    FormProperty.numericBoxTiltCorrectionTau.Text = (string)regKey.GetValue("textBoxTiltCorrectionPsiText", FormProperty.numericBoxTiltCorrectionTau.Text);

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

                    //ここからイメージタイプごとのパラメータ読み込み
                    for (int i = 0; i < Enum.GetValues(typeof(Ring.ImageTypeEnum)).Length; i++)
                    {
                        FormProperty.ImageTypeParameters[i].CenterPosX = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.CneterPosX" + i.ToString(), "0"));
                        FormProperty.ImageTypeParameters[i].CenterPosY = Convert.ToDouble((string)regKey.GetValue("ImageTypeParameters.CneterPosY" + i.ToString(), "0"));
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

                }

                //regKey = regKey.OpenSubKey("Macro");
                //int length = (int)regKey.GetValue("MacroLength", 0);
                //byte[][] byteArray = new byte[length][];
                //for (int i = 0; i < length; i++)
                //    byteArray[i] = (byte[])regKey.GetValue("Macro" + i.ToString(), null);

                FormMacro.ZippedMacros = (byte[])regKey.GetValue("Macro", new byte[0]);

                //偏光補正
                FormProperty.checkBoxCorrectPolarization.Checked = (string)regKey.GetValue("FormProperty.checkBoxCorrectPolarization.Checked", "True") == "True";

                regKey.Close();
            }

            catch { }
        }

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
        private void Form1_Load(object sender, System.EventArgs e)
        {

            //#if !DEBUG
            //            Ngen.Compile();
            //#endif

            toolStripComboBoxRotate.SelectedIndex = 0;

            InitialDialog = new WaitDlg();
            InitialDialog.ShowHints = false;
            LoadRegistry();
            InitialDialog.Owner = this;
            InitialDialog.Version = $"IPAnalyzer  {Version.VersionAndDate}";
            InitialDialog.Text = "Now Loading...";
            InitialDialog.ShowVersion = true;
            InitialDialog.Hint = Version.Hint;

            InitialDialog.Show();
            Application.DoEvents();

            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.1);

            InitialDialog.Text = "Now Loading...Checking laguage.";

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

            FormIntTable = new FormIntTable();
            FormIntTable.formMain = this;
            FormIntTable.Visible = false;
            FormIntTable.Owner = this;

            InitialDialog.Text = "Now Loading...Initializing 'Auto procedure' form";
            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.4);

            FormAutoProc = new FormAutoProcedure();
            FormAutoProc.formMain = this;
            FormAutoProc.Visible = false;
            FormAutoProc.Owner = this;

            InitialDialog.Text = "Now Loading...Initializing 'Find parameter' form";
            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.5);

            FormFindParameter = new FormFindParameter();
            FormFindParameter.formMain = this;
            FormFindParameter.Visible = false;
            FormFindParameter.Owner = this; ;


            InitialDialog.Text = "Now Loading...Initializing 'Draw ring' form";
            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.6);

            FormDrawRing = new FormDrawRing();
            FormDrawRing.formMain = this;
            FormDrawRing.Visible = false;
            FormDrawRing.Owner = this;

            InitialDialog.Text = "Now Loading...Initializing 'Property' form";
            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.7);
            

            FormProperty = new FormProperty();
            FormProperty.formMain = this;
            FormProperty.Visible = false;
            FormProperty.Owner = this;

            InitialDialog.Text = "Now Loading...Initializing 'Calibrate Intensity' form";
            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.8);
            Application.DoEvents();

            FormCalibrateIntensity = new FormCalibrateIntensity();
            FormCalibrateIntensity.formMain = this;
            FormCalibrateIntensity.Visible = false;
            FormCalibrateIntensity.Owner = this;

            InitialDialog.Text = "Now Loading...Initializing 'Save Image' form.";

            FormSaveImage = new FormSaveImage();
            FormSaveImage.FormMain = this;
            FormSaveImage.Owner = this;
            FormSaveImage.Visible = false;

            InitialDialog.Text = "Now Loading...Initializing 'Sequential' form.";

            FormSequentialImage = new FormSequentialImage();
            FormSequentialImage.formMain = this;
            FormSequentialImage.Owner = this;
            FormSequentialImage.Visible = false;

            InitialDialog.Text = "Now Loading...Initializing 'Parameter option' form.";

            FormParameterOption = new FormParameterOption();
            FormParameterOption.FormMain = this;
            FormParameterOption.Owner = this;
            FormParameterOption.Visible = false;

            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 0.9);
            InitialDialog.Text = "Now Loading...Initializing 'SACLA' form.";

            FormSaclaParameter = new FormOptimizeSaclaEH5Parameter();
            FormSaclaParameter.FormMain = this;
            FormSaclaParameter.Owner = this;
            FormSaclaParameter.Visible = false;

            //FormProperty.Location = new Point(0, 0);
            //FormProperty.Size = new Size(500, 599);
            FormProperty.Visible = true;


            InitialDialog.Text = "Now Loading...Initializing Macro function.";

            FormMacro = new Crystallography.Controls.FormMacro(Python.CreateEngine(), new Macro(this));
            FormMacro.Visible = false;
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
            String[] s = Environment.GetCommandLineArgs();
            string fileName = "";
            for (int i = 1; i < s.Length; i++)
                fileName += (i == 1 ? "" : " ") + s[i];
            if (s.Length > 1)
            {
                if (fileName.EndsWith("img") || fileName.EndsWith("stl") || fileName.EndsWith("ccd") || fileName.EndsWith("ipf"))
                    ReadImage(fileName);
                else if (fileName.EndsWith("prm"))
                    ReadParameter(fileName);
                else if (fileName.EndsWith("mas"))
                    readMaskFile(fileName);
            }

            InitialDialog.Text = "Now Loading...Checking Click Once.";
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {
                programUpdatesToolStripMenuItem.Visible = false;//click onceの場合
                this.Text += "   Caution! ClickOnce vesion will be not maintained in the future.";
            }

            NextHandle = SetClipboardViewer(this.Handle);
            Clipboard.SetDataObject("IPAnalyzer");

            SetText();

            InitialDialog.progressBar.Value = (int)(InitialDialog.progressBar.Maximum * 1);

            InitialDialog.Text = "Initializing has been finished successfully. You can close this window.";
            if (InitialDialog.AutomaricallyClose)
                InitialDialog.Visible = false;

            Directory.Delete(Application.UserAppDataPath, true);
            if (!File.Exists(UserAppDataPath + "IPAnalyzerSetup.msi"))
                File.Delete(UserAppDataPath + "IPAnalyzerSetup.msi");
        }

        //フォームクローズ時
        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormProperty.SaveParameterForEachImageType(Ring.ImageType);
            SaveRegistry();
            ChangeClipboardChain(this.Handle, NextHandle);
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
            FormIntTable.Close();
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

            if (!IsDrawing) return;
            if (!IsImageReady) return;
            if (!toolStripButtonUnroll.Checked)
            {
                pseudoBitmap.Filter1 = Ring.IsThresholdOver;
                pseudoBitmap.Filter2 = Ring.IsThresholdUnder;
                pseudoBitmap.Filter3 = Ring.IsSpots;
                pseudoBitmap.Filter4 = Ring.IsOutsideOfIntegralRegion;
            }

            Bitmap bmp = pseudoBitmap.GetImage(scalablePictureBox.Center, scalablePictureBox.Zoom, scalablePictureBox.pictureBox.ClientSize);
            if (bmp == null) return;
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //メイン中に水色の枠(Int.Tableの範囲)を表示
            if (FormIntTable.Visible && TableCenterPt.X > 0)
            {
                int length = (int)FormIntTable.numericUpDownMatrixNum.Value;

                Pen pen = new Pen(Brushes.LightBlue);
                RectangleF rect = scalablePictureBox.ConvertToClientRect(new RectangleD(TableCenterPt.X - length / 2.0, TableCenterPt.Y - length / 2.0, length, length)).ToRectangleF();
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }

            //メイン中に水色の枠(SaveImageの範囲)を表示
            if (FormSaveImage.Visible)
            {
                Pen pen = new Pen(Brushes.LightBlue);
                //傾きを考慮していないので、正確ではないが、とりあえず。
                PointD upperLeft = new PointD(
                    FormProperty.ImageCenter.X - FormSaveImage.ImageCenter.X * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeX.Value,
                    FormProperty.ImageCenter.Y - FormSaveImage.ImageCenter.Y * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeY.Value);

                PointD lowerRight = new PointD(
                    FormProperty.ImageCenter.X + (FormSaveImage.ImageSize.Width - FormSaveImage.ImageCenter.X) * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeX.Value,
                    FormProperty.ImageCenter.Y + (FormSaveImage.ImageSize.Height - FormSaveImage.ImageCenter.Y) * FormSaveImage.ImageResolution / FormProperty.numericBoxPixelSizeY.Value);

                RectangleF rect = scalablePictureBox.ConvertToClientRect(new RectangleD(upperLeft.X, upperLeft.Y, lowerRight.X - upperLeft.X, lowerRight.Y - upperLeft.Y)).ToRectangleF();

                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);

            }

            //中心点にペケ
            try
            {
                PointD pt = scalablePictureBox.ConvertToClientPt(new PointD(FormProperty.numericBoxCenterPositionX.Value, FormProperty.numericBoxCenterPositionY.Value));
                Pen pen = new Pen(Brushes.Fuchsia);
                g.DrawLine(pen, new PointF((float)pt.X + 4, (float)pt.Y + 4), new PointF((float)pt.X - 4, (float)pt.Y - 4));
                g.DrawLine(pen, new PointF((float)pt.X - 4, (float)pt.Y + 4), new PointF((float)pt.X + 4, (float)pt.Y - 4));
            }
            catch { }

            //マウスで一秒以上長押しした点にペケ
            try
            {
                if (!selectedSpot.IsNaN)
                {
                    PointD pt = scalablePictureBox.ConvertToClientPt(selectedSpot);
                    Pen pen = new Pen(Brushes.Orange);
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
                        PointD pt = scalablePictureBox.ConvertToClientPt(p);
                        Pen pen = new Pen(Brushes.HotPink);
                        g.DrawLine(pen, new PointF((float)pt.X + 4, (float)pt.Y + 4), new PointF((float)pt.X - 4, (float)pt.Y - 4));
                        g.DrawLine(pen, new PointF((float)pt.X - 4, (float)pt.Y + 4), new PointF((float)pt.X + 4, (float)pt.Y - 4));
                    }
                }
            }
            catch { }

            #region リングをかく
            if (FormDrawRing.Visible && FormDrawRing.R > 0)
            {
                try
                {
                    PointD OffSet = new PointD(0, 0);
                    RectangleF Rect = new RectangleF(0, 0, 0, 0);
                    double Filmdistance = FormProperty.CameraLength;
                    double Phi = FormProperty.numericBoxTiltCorrectionPhi.RadianValue;
                    double Tau = FormProperty.numericBoxTiltCorrectionTau.RadianValue;
                    double EllipseWidth = 0;
                    double EllipseHeight = 0;
                    double Cos = 0;
                    double Sin = 0;

                    Geometriy.GetEllipseRectangleAndRot(FormDrawRing.R, Filmdistance, Phi, Tau,
                    ref OffSet, ref EllipseWidth, ref EllipseHeight, ref Cos, ref Sin);

                    g = Graphics.FromImage(bmp);
                    g.SmoothingMode = SmoothingMode.AntiAlias;

                    //まずビーム中心を原点に持ってくる
                    
                    PointF center = scalablePictureBox.ConvertToClientPt(FormProperty.ImageCenter).ToPointF();
                    PointD centerD = scalablePictureBox.ConvertToClientPt(FormProperty.ImageCenter);
                    
                    Matrix3D m = new Matrix3D(1, 0, 0, 0, 1, 0, centerD.X, centerD.Y, 1);

                    //次にディスプレイ上のピクセルと画像のピクセルを同じにする
                    float scale = (float)(1 / scalablePictureBox.Zoom); //SrcRectF.Width / ClientRect.Width;
                    
                    m = m * new Matrix3D(1 / scale, 0, 0, 0, 1 / scale, 0, 0, 0, 1);
                    //次に画像ピクセル空間を実空間にする
                    float pixelSizeX = (float)FormProperty.numericBoxPixelSizeX.Value;
                    float pixelSizeY = (float)FormProperty.numericBoxPixelSizeY.Value;
                    float TanKsi = (float)Math.Tan(FormProperty.numericalTextBoxPixelKsi.RadianValue);
                   
                    m = m * new Matrix3D(1 / pixelSizeX, 0, 0, -TanKsi / pixelSizeX, 1 / pixelSizeY, 0, 0, 0, 1);

                    //楕円の中心位置のずれをオフセット
                   

                    m = m * new Matrix3D(1, 0, 0, 0, 1, 0, OffSet.X, OffSet.Y, 1);

                    //楕円の傾きをセット
                 

                    m = m * new Matrix3D(Cos, Sin, 0, -Sin, Cos, 0, 0, 0, 1);

                   
                    g.MultiplyTransform(new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, center.X, center.Y));

                    g.MultiplyTransform(new System.Drawing.Drawing2D.Matrix(1 / pixelSizeX, 0, -TanKsi / pixelSizeX, 1 / pixelSizeY, 0, 0));

                    g.MultiplyTransform(new System.Drawing.Drawing2D.Matrix(1 / scale, 0, 0, 1 / scale, 0, 0));



                    g.MultiplyTransform(new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, (float)OffSet.X, (float)OffSet.Y));

                  

                    g.MultiplyTransform(new System.Drawing.Drawing2D.Matrix((float)Cos, (float)Sin, -(float)Sin, (float)Cos, 0, 0));


                    //最後に楕円を描画
                    RectangleF RectangleOfEllipse = new RectangleF(-(float)EllipseWidth, -(float)EllipseHeight,
                       (float)EllipseWidth * 2, (float)EllipseHeight * 2);

                    g.Transform = new System.Drawing.Drawing2D.Matrix((float)m.E11, (float)m.E21, (float)m.E12, (float)m.E22, (float)m.E13, (float)m.E23);

                    g.DrawEllipse(new Pen(Brushes.Yellow, 0.01f), RectangleOfEllipse);

                    g.Transform = new System.Drawing.Drawing2D.Matrix(1, 0, 0, 1, 0, 0);
                }
                catch { }

            }

            #endregion

            scalablePictureBox.pictureBox.Image = bmp;
            scalablePictureBox.Refresh();

            //サムネイルに画像転送
            DrawThumnail();
        }


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
                scalablePictureBoxThumbnail.Center = new PointD(FormProperty.numericBoxCenterPositionX.Value, FormProperty.numericBoxCenterPositionY.Value);
            }

            Bitmap bmp = pseudoBitmap.GetImage(scalablePictureBoxThumbnail.Center, scalablePictureBoxThumbnail.Zoom, scalablePictureBoxThumbnail.pictureBox.ClientSize);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            if (thumbnailmode)
            {
                //サムネイル中に黄色い枠を表示
                Pen pen = new Pen(Brushes.Yellow);
                RectangleF rect = scalablePictureBoxThumbnail.ConvertToClientRect(scalablePictureBox.ConvertToSrcRect(scalablePictureBox.pictureBox.ClientRectangle)).ToRectangleF();
                g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
            }
            else
            {
                try
                {
                    PointF pt = scalablePictureBoxThumbnail.ConvertToClientPt(new PointD(FormProperty.numericBoxCenterPositionX.Value, FormProperty.numericBoxCenterPositionY.Value)).ToPointF();
                    Pen pen = new Pen(Brushes.Fuchsia);
                    g.DrawLine(pen, new PointF(pt.X + 4, pt.Y + 3), new PointF(pt.X - 4, pt.Y - 4));
                    g.DrawLine(pen, new PointF(pt.X - 4, pt.Y + 3), new PointF(pt.X + 4, pt.Y - 4));
                }
                catch { }
            }

            scalablePictureBoxThumbnail.pictureBox.Image = bmp;
        }

        #endregion


        //ここよりピクチャーボックスのマウスイベント関係
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
                FormProperty.ImageCenter = new PointD(pt.X, pt.Y);
                TableCenterPt = new Point((int)(pt.X + 0.5), (int)(pt.Y + 0.5));
                if (FormIntTable != null)
                    FormIntTable.SetData((int)(pt.X + 0.5), (int)(pt.Y + 0.5));
                //さらに真ん中ボタンクリックであればFindCenterもする　
                if (e.Button == MouseButtons.Middle)
                    toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
                Draw();
            }

            return true;
        }

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();

        public List<PointD> manualMaskPoints = new List<PointD>();
        public List<bool> splineTemp = new List<bool>();
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
                splineTemp = Convolution.BlurPixels(pseudoBitmap.FilterTemporary, SrcImgSize.Width, (int)FormProperty.numericUpDownSplineWidth.Value);
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
                else if (FormProperty.radioButtonManualSpline.Checked)//スプラインモード
                {
                    if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Left)//追加
                    {
                        bool flag = true;
                        foreach (PointD p in manualMaskPoints)
                            if (p.X == pt.X && p.Y == pt.Y)
                                flag = false;
                        if (flag)
                            manualMaskPoints.Add(pt);
                        setSpline();

                        Draw();
                        return true;//マウスイベント終了
                    }
                    else if (e.Clicks == 1 && e.Button == System.Windows.Forms.MouseButtons.Right)//削除
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
                        if (e.Button == System.Windows.Forms.MouseButtons.Left)
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
                    double SinTau = Math.Sin(IP.tau);
                    double CosTau = Math.Cos(IP.tau);
                    double SinPhi = Math.Sin(IP.phi);
                    double CosPhi = Math.Cos(IP.phi);
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
                    IsRingSelectMode = Math.Abs(FormDrawRing.R - r) < devR ? true : false;

                    sw.Stop();
                    sw.Reset();
                }
            }
            else if (toolStripButtonFixCenter.Checked == false)
                if ((e.Button == MouseButtons.Left && e.Clicks == 2) || e.Button == MouseButtons.Middle)
                {//左ダブルクリックかつリング非表示時 あるいは　中ボタンクリック時
                    //PointF pt = ConvertToSrcPt(SrcRectF, ClientRect, new PointF(e.X, e.Y));

                    FormProperty.ImageCenter = new PointD(pt.X, pt.Y);
                    int x = (int)(pt.X + 0.5);
                    int y = (int)(pt.Y + 0.5);
                    TableCenterPt = new Point(x, y);
                    if (FormIntTable != null)
                        FormIntTable.SetData(x, y);

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
            double r = 0;
            double chi = 0;
            double newX = 0, newY = 0;
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

            }
            catch { r = 0; }
            //画面にマウス座標を表示
            if (X >= 0 && Ring.Intensity != null && X + Y * SrcImgSize.Width > -1 && X + Y * SrcImgSize.Width < Ring.Intensity.Count)
            {
                labelMousePointPixel.Text = X.ToString().PadLeft(5) + "," + Y.ToString().PadLeft(5);
                labelMousePointReal.Text = newX.ToString("f3").PadLeft(7) + ", " + newY.ToString("f3").PadLeft(7);
                labelMousePointIntensity.Text = (Ring.Intensity[X + Y * SrcImgSize.Width]).ToString();
                labelMousePointR.Text = r.ToString("f2");
                double theta = Math.Atan2(r, IP.FilmDistance);
                labelMousePointTheta.Text = (180.0 / Math.PI * theta).ToString("f3") + "°";
                labelMousePointD.Text = (IP.WaveLength / 2 * 10 / Math.Sin(theta / 2)).ToString("f3") + "Å";
                labelMousePointChi.Text = (180.0 / Math.PI * chi).ToString("f2") + "°";
                if (pseudoBitmap != null)
                    labelResolution.Text = "Mag: " + scalablePictureBox.Zoom.ToString("f2");
            }
            //マウス位置のピクセル情報　ここまで

            if (IsRingSelectMode){
                FormDrawRing.SetR(r);
                return true;//マウス左ボタンによる平行移動をキャンセル
            }
            //スポット選択モードのとき
            else if (FormProperty.checkBoxManualMaskMode.Checked)
            {
                if (FormProperty.radioButtonManualCircle.Checked)
                {
                    if (manualMaskPoints.Count == 1)
                    {
                        double radius = (manualMaskPoints[0] - pt).Length;

                        for (int j = Math.Max((int)Math.Round(manualMaskPoints[0].Y - radius), 0); j <= Math.Min((int)Math.Round(manualMaskPoints[0].Y + radius), SrcImgSize.Height - 1); j++)
                            for (int i = Math.Max((int)Math.Round(manualMaskPoints[0].X - radius), 0); i <= Math.Min((int)Math.Round(manualMaskPoints[0].X + radius), SrcImgSize.Width - 1); i++)
                                if ((i - manualMaskPoints[0].X) * (i - manualMaskPoints[0].X) + (j - manualMaskPoints[0].Y) * (j - manualMaskPoints[0].Y) <= radius * radius)
                                    pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
                    }
                }
                else if (FormProperty.radioButtonManualRectangle.Checked)
                {
                    if (manualMaskPoints.Count == 1)
                    {
                        for (int j = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].Y, pt.Y) + 0.5)); j <= Math.Min(SrcImgSize.Height - 1, (int)(Math.Max(manualMaskPoints[0].Y, pt.Y) + 0.5)); j++)
                            for (int i = Math.Max(0, (int)(Math.Min(manualMaskPoints[0].X, pt.X) + 0.5)); i <= Math.Min(SrcImgSize.Width - 1, (int)(Math.Max(manualMaskPoints[0].X, pt.X) + 0.5)); i++)
                                pseudoBitmap.FilterTemporary[j * SrcImgSize.Width + i] = true;
                    }
                }
                else if (FormProperty.radioButtonManualSpline.Checked)
                {
                    if (splineTemp.Count == pseudoBitmap.FilterTemporary.Count)
                    {
                        pseudoBitmap.FilterTemporary.Clear();
                        pseudoBitmap.FilterTemporary.AddRange(splineTemp.ToArray());
                        Draw();

                    }
                    return false;//イベント続行
                }

                else if (FormProperty.radioButtonManualSpot.Checked)
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
            if (FormProperty.checkBoxManualMaskMode.Checked)//マスクモード時
            {
                if (FormProperty.radioButtonManualCircle.Checked)
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
                else if (FormProperty.radioButtonManualRectangle.Checked)
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
                else if (FormProperty.radioButtonManualSpline.Checked && e.Clicks == 2)
                {

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

        public void FormMain_Resize(object sender, System.EventArgs e)
        {
            Draw();
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            FormMain_Resize(new object(), new EventArgs());
        }

        #region 輝度調節関係
        public bool SkipMax = false;
        public bool SkipMin = false;
        //NumetricUpDownpseudBitmap.MaxValue変更時
        private void numericUpDownMaxInt_ValueChanged(object sender, System.EventArgs e)
        {
            if (SkipMax) return;
            SkipMax = true;

            pseudoBitmap.MaxValue = (uint)numericUpDownMaxInt.Value;

            if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
                numericUpDownMinInt.Value = numericUpDownMaxInt.Value - 1;


            if (numericUpDownMaxInt.Value <= 1)
                trackBarMaxInt.Value = 1;
            else
                trackBarMaxInt.Value = (int)(Math.Log((double)numericUpDownMaxInt.Value, (double)numericUpDownMaxInt.Maximum) * (double)trackBarMaxInt.Maximum);

            if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
            {
                graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 1 : 0].X = (double)numericUpDownMaxInt.Value;
                graphControlFrequency.Draw();
            }

            Draw();
            SkipMax = false;
        }
        //NumetricUpDownpseudBitmap.MinValue変更時
        private void numericUpDownMinInt_ValueChanged(object sender, System.EventArgs e)
        {
            if (SkipMin) return;
            SkipMin = true;
            pseudoBitmap.MinValue = (uint)numericUpDownMinInt.Value;

            if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
                numericUpDownMaxInt.Value = numericUpDownMinInt.Value + 1;

            if (numericUpDownMinInt.Value == 0)
                trackBarMinInt.Value = 0;
            else
                trackBarMinInt.Value = (int)(Math.Log((double)numericUpDownMinInt.Value, (double)numericUpDownMinInt.Maximum) * (double)trackBarMinInt.Maximum);

            if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
            {
                graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 0 : 1].X = (double)numericUpDownMinInt.Value;
                graphControlFrequency.Draw();
            }

            Draw();
            SkipMin = false;
        }

        //TrackBarpseudBitmap.MaxValueスクロール時
        private void trackBarMaxInt_Scroll(object sender, System.EventArgs e)
        {
            if (!IsImageReady || SkipMax) return;
            SkipMax = true;
            numericUpDownMaxInt.Value = (int)Math.Pow((double)numericUpDownMaxInt.Maximum, (double)trackBarMaxInt.Value / (double)trackBarMaxInt.Maximum);
            pseudoBitmap.MaxValue = (uint)numericUpDownMaxInt.Value;
            if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
                numericUpDownMinInt.Value = numericUpDownMaxInt.Value - 1;

            if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
            {
                graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 1 : 0].X = (double)numericUpDownMaxInt.Value;
                graphControlFrequency.Draw();
            }

            SkipMax = false;

            Draw();

        }
        //TrackBarpseudBitmap.MinValueスクロール時
        private void trackBarMinInt_Scroll(object sender, System.EventArgs e)
        {
            if (!IsImageReady || SkipMin) return;
            SkipMin = true;
            numericUpDownMinInt.Value = (int)Math.Pow((double)numericUpDownMinInt.Maximum, (double)trackBarMinInt.Value / (double)trackBarMinInt.Maximum);
            pseudoBitmap.MinValue = (uint)numericUpDownMinInt.Value;
            if (pseudoBitmap.MaxValue <= pseudoBitmap.MinValue)
                numericUpDownMaxInt.Value = numericUpDownMinInt.Value + 1;

            if (graphControlFrequency.LineList != null && graphControlFrequency.LineList.Length == 2)
            {
                graphControlFrequency.LineList[graphControlFrequency.LineList[0].X < graphControlFrequency.LineList[1].X ? 0 : 1].X = (double)numericUpDownMinInt.Value;
                graphControlFrequency.Draw();
            }

            SkipMin = false;

            Draw();
        }

        //AutoAdjustボタンクリック時
        public void buttonAutoLevel_Click(object sender, System.EventArgs e)
        {
            if (variance != 0)
            {
                numericUpDownMaxInt.Value = Math.Min((decimal)(sumOfIntensity / Ring.Intensity.Count + 2 * variance), numericUpDownMaxInt.Maximum);
                numericUpDownMinInt.Value = Math.Max((decimal)(sumOfIntensity / Ring.Intensity.Count - 2 * variance), numericUpDownMinInt.Minimum);
            }

        }
        //Resetボタンクリック時
        private void buttonReset_Click(object sender, System.EventArgs e)
        {
            if (!IsImageReady) return;
            numericUpDownMaxInt.Maximum = (decimal)65535;
            numericUpDownMinInt.Maximum = (decimal)65534;
            numericUpDownMaxInt.Value = (decimal)65535;
            numericUpDownMinInt.Value = (decimal)0;
            pseudoBitmap.MaxValue = 65535;
            pseudoBitmap.MinValue = 0;
            Draw();
        }
        #endregion

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
            string[] fileName =
                (string[])e.Data.GetData(DataFormats.FileDrop, false);
            //ListBoxに追加する
            if (fileName.Length == 1)
            {
                string ext = Path.GetExtension(fileName[0]).TrimStart(new char[] { '.' });
                if (ImageIO.IsReadable(ext))
                    ReadImage(fileName[0]);
                else if (fileName[0].EndsWith("prm"))
                    ReadParameter(fileName[0], (e.KeyState & 8) != 8);//8はCTRLキーを表す
                else if (fileName[0].EndsWith("mas"))
                    readMaskFile(fileName[0]);
                else if (Directory.Exists(fileName[0]))
                {
                    var files = Directory.GetFiles(fileName[0]);
                    if(files !=null && files.Length>0)
                    {
                        Array.Sort(files);
                        ext = Path.GetExtension(files[0]).TrimStart(new char[] { '.' });
                        if (ImageIO.IsReadable(ext))
                            ReadImage(files[0]);
                    }
                }
            }
      
        }

        //ここよりメニューアイテム ファイル

        public int filterIndex;
        public string initialImageDirectory = "";
        private void readImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ImageIO.FilterString;
            if (initialImageDirectory != "")
                dlg.InitialDirectory = initialImageDirectory;
            dlg.FilterIndex = filterIndex;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                ReadImage(dlg.FileName);
                filterIndex = dlg.FilterIndex;
                initialImageDirectory = Path.GetDirectoryName(dlg.FileName);
            }
        }

        delegate void ReadImageCallBack(string str, bool? flag = null);
        public void ReadImage(string str, bool? flag = null)
        {
            if (str != "ClipBoard.ipa" && !File.Exists(str)) return;  // ファイルの有無をチェック

            //改行文字が含まれている場合は、それを削除
            str = str.TrimEnd('\n');
            str = str.TrimEnd('\r');

            if (this.InvokeRequired)//別スレッド(ファイル更新監視スレッド)から呼び出されたとき
            {
                ReadImageCallBack d = new ReadImageCallBack(ReadImage);
                this.Invoke(d, new object[] { str, flag });
                return;
            }

            //ファイルを読み込む前に現在のイメージタイプの情報を保存
            FormProperty.SaveParameterForEachImageType(Ring.ImageType);
            IsImageReady = false;
            toolStripButtonImageSequence.Enabled = false;
            toolStripButtonImageSequence.Checked = false;

            if (!ImageIO.ReadImage(str, flag))
                return;

            string ext = Path.GetExtension(str).TrimStart(new char[] { '.' });
            if (ext == "ipa")
            {
                FormProperty.waveLengthControl.Property = Ring.IP.WaveProperty;
                FormProperty.CameraLength = Ring.IP.FilmDistance;
                FormProperty.numericBoxPixelSizeX.Value = Ring.IP.PixSizeX;
                FormProperty.numericBoxPixelSizeY.Value = Ring.IP.PixSizeY;
                FormProperty.ImageCenter = new PointD(Ring.IP.CenterX, Ring.IP.CenterY);
                FormProperty.numericBoxTiltCorrectionPhi.Value = FormProperty.numericBoxTiltCorrectionTau.Value = FormProperty.numericalTextBoxPixelKsi.Value = 0;
            }
            else if (ext == "h5")
            {
                FormProperty.numericBoxPixelSizeX.Value = Ring.IP.PixSizeX;
                FormProperty.numericBoxPixelSizeY.Value = Ring.IP.PixSizeY;
                if (Ring.IP.SrcWidth == 1024 && Ring.IP.SrcHeight == 1024)
                    toolStripButtonFixCenter.Checked = true;
            }

            SrcImgSize = Ring.SrcImgSize;

            GC.Collect();

            diffractionProfile = new DiffractionProfile();

            initializeFilter();
            setScale();
            FormProperty.checkBoxThreshold_CheckedChanged(new object(), new EventArgs());
            IsImageReady = true;
            IntegralArea_Changed(new object(), new EventArgs());

            
            graphControlFrequency.LineList = new PointD[2] { new PointD((double)numericUpDownMinInt.Value, double.NaN), new PointD((double)numericUpDownMaxInt.Value, double.NaN) };
            Ring.CalcFreq();
            SetFrequencyProfile();//強度頻度グラフを作成
            graphControlProfile.Profile = new Profile();//プロファイルは初期化

            SetInformation();


            FileName = str.Remove(0, str.LastIndexOf('\\') + 1);
            string oldFilePath = FilePath;
            FilePath = str.Remove(str.LastIndexOf('\\') + 1);

            SetText(FileName);

            if (FormAutoProc != null && FormAutoProc.Visible && FormAutoProc.checkBoxIsWatchAndLoad.Checked && FilePath != oldFilePath)
                FormAutoProc.FileList = new List<string>(Directory.GetFiles(FilePath));

            if (FormAutoProc != null && FormAutoProc.Visible && FormAutoProc.checkBoxAutoAfterLoad.Checked)
                FormAutoProc.buttonAuto_Click(new object(), new EventArgs());


            numericUpDownMaxInt.Maximum = (decimal)Ring.Intensity.Max();
            numericUpDownMinInt.Maximum = numericUpDownMaxInt.Maximum - 1;
            numericUpDownMaxInt.Minimum = 1;
            numericUpDownMinInt.Minimum = 0;


            //SequentialImageを読み込んだ時の処理
            if (Ring.SequentialImageIntensities != null)
            {
                if (Ring.SequentialImageIntensities.Count >= 2)
                {
                    SequentialImageMode = true;
                    toolStripButtonImageSequence.Checked = true;
                }
                FormSequentialImage.MaximumNumber = Ring.SequentialImageIntensities.Count;
                FormSequentialImage.SelectedIndex = 0;

                numericUpDownMaxInt.Maximum = (decimal)Ring.SequentialImageIntensities.Max(i => i.Max());
                numericUpDownMinInt.Maximum = numericUpDownMaxInt.Maximum - 1;

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

                if (Math.Abs(FormProperty.waveLengthControl.Energy*1000 - acc )/acc > 0.2)
                    FormProperty.waveLengthControl.Energy = acc / 1000;

                if (Math.Abs((FormProperty.numericBoxPixelSizeX.Value - size) / size) > 0.2)
                {
                    FormProperty.numericBoxPixelSizeX.Value = size;
                    FormProperty.numericBoxPixelSizeY.Value = size;
                    FormProperty.numericalTextBoxPixelKsi.Value = 0;
                }
                double length = size / Math.Tan(2 * FormProperty.waveLengthControl.WaveLength * scale / 2);
                if (Math.Abs((FormProperty.CameraLength - length) / length) > 0.2)
                    FormProperty.CameraLength = length;
            }
        }

        public void SetInformation()
        {
            textBoxInformation.Text =
                "Size:\r\n " + SrcImgSize.Width.ToString() + "*" + SrcImgSize.Height.ToString() + "\r\n" +
                "Dynamic range:\r\n " + Ring.Intensity.Min().ToString() + " - " + Ring.Intensity.Max().ToString("#,#") + "\r\n" +
                "Max Intensity:\r\n " + maxIntensity.ToString("#,#") + "\r\n" +
                "Sum Intensity:\r\n " + sumOfIntensity.ToString("#,#") + "\r\n" +
                "Ave. Intensity:\r\n " + (sumOfIntensity / Ring.Intensity.Count).ToString("#,#.####") + "\r\n\r\n"
                + Ring.Comments;

            if (Ring.SequentialImagePulsePower != null && Ring.SequentialImagePulsePower.Count == Ring.SequentialImageIntensities.Count)//イメージごとにエネルギーが設定されているとき
            {
                if (Ring.SequentialImageIntensities.Count == 1)
                    textBoxInformation.Text += "\r\nPulse Power: " + Ring.SequentialImagePulsePower[0].ToString();
                else if(FormSequentialImage.SelectedIndex>-1)
                    textBoxInformation.Text += "\r\nPulse Power: " + Ring.SequentialImagePulsePower[FormSequentialImage.SelectedIndex].ToString();
            }
        }

        public void initializeFilter()
        {
            if (Ring.IsValid.Count != Ring.Intensity.Count)
            {
                Ring.IsValid.Clear();
                Ring.IsOutsideOfIntegralRegion.Clear();
                Ring.IsOutsideOfIntegralProperty.Clear();
                Ring.IsSpots.Clear();
                Ring.IsThresholdOver.Clear();
                Ring.IsThresholdUnder.Clear();
                Ring.IsValid.AddRange(new bool[Ring.Intensity.Count]);
                Ring.IsOutsideOfIntegralRegion.AddRange(new bool[Ring.Intensity.Count]);
                Ring.IsSpots.AddRange(new bool[Ring.Intensity.Count]);
                Ring.IsThresholdOver.AddRange(new bool[Ring.Intensity.Count]);
                Ring.IsThresholdUnder.AddRange(new bool[Ring.Intensity.Count]);
                Ring.IsOutsideOfIntegralProperty.AddRange(new bool[Ring.Intensity.Count]);
                ;
            }
            else
            {
                for (int i = 0; i < Ring.Intensity.Count; i++)
                {
                    Ring.IsValid[i] = false;
                    Ring.IsOutsideOfIntegralRegion[i] = false;
                    Ring.IsOutsideOfIntegralProperty[i] = false;
                    Ring.IsSpots[i] = false;
                    Ring.IsThresholdOver[i] = false;
                    Ring.IsThresholdUnder[i] = false;
                }
            }
            pseudoBitmap = new PseudoBitmap(Ring.Intensity.ToArray(), SrcImgSize.Width, PseudoBitmap.BrightnessScaleLiner, PseudoBitmap.BrightnessScaleLiner, PseudoBitmap.BrightnessScaleLiner);

            pseudoBitmap.Filter1 = Ring.IsThresholdOver;
            pseudoBitmap.Filter2 = Ring.IsThresholdUnder;
            pseudoBitmap.Filter3 = Ring.IsSpots;
            pseudoBitmap.Filter4 = Ring.IsOutsideOfIntegralRegion;
            pseudoBitmap.Filter5 = Ring.IsOutsideOfIntegralProperty;
            pseudoBitmap.FilterTemporary.AddRange(new bool[SrcImgSize.Width * SrcImgSize.Height]);
            pseudoBitmap.MaxValue = (uint)((double)numericUpDownMaxInt.Value);
            pseudoBitmap.MinValue = (uint)((double)numericUpDownMinInt.Value);
            scalablePictureBox.PseudoBitmap = pseudoBitmap;
            scalablePictureBoxThumbnail.PseudoBitmap = pseudoBitmap;
            setScale();
        }

        public void SetBytePosition(string str, ref BinaryReader br, int count)
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
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.tif|*.tif";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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
                        d[i] = Ring.FlipAndRotate(Ring.SequentialImageIntensities[i], Ring.IP.SrcWidth,
                                flipVerticallyToolStripMenuItem.Checked,
                                flipHorizontallyToolStripMenuItem.Checked,
                                toolStripComboBoxRotate.SelectedIndex).ToArray();

                        //Background
                        if (Ring.Background != null && Ring.Background.Count == d[i].Length)
                            d[i] = Ring.SubtractBackground(d[i], Ring.Background, FormProperty.numericBoxBackgroundCoeff.Value).ToArray();

                        //偏光補正
                        if (FormProperty != null && FormProperty.checkBoxCorrectPolarization.Checked)
                            d[i] = Ring.CorrectPolarization(toolStripComboBoxRotate.SelectedIndex).ToArray();
                    }
                    if (Ring.SequentialImageEnergy != null && Ring.SequentialImageEnergy.Count == Ring.SequentialImageIntensities.Count)
                    {//各画像にエネルギー値があるとき(h5ファイルの時)
                        List<Tiff.IFD> ifdEnergy = new List<Tiff.IFD>();
                        List<Tiff.IFD> ifdName = new List<Tiff.IFD>();
                        List<Tiff.IFD> ifdPulsePower = new List<Tiff.IFD>();
                        for (int i = 0; i < Ring.SequentialImageEnergy.Count; i++)
                        {
                            ifdEnergy.Add(new Tiff.IFD(60000, typeof(float), new object[] { Ring.SequentialImageEnergy[i] }));
                            ifdName.Add(new Tiff.IFD(60001, typeof(string), new object[] { Ring.SequentialImageNames[i] }));
                            if(Ring.PulsePowerNormarized)
                                ifdPulsePower.Add(new Tiff.IFD(60002, typeof(float), new object[] { -1.0 }));
                            else
                                ifdPulsePower.Add(new Tiff.IFD(60002, typeof(float), new object[] { Ring.SequentialImagePulsePower[i] }));
                        }
                        Tiff.Writer(filename, d, 0, Ring.SrcImgSize.Width, new Tiff.IFD[][] { /*ifdEnergy.ToArray(), ifdName.ToArray(), */ifdPulsePower.ToArray() });
                    }
                    else//h5ファイルではないとき
                        Tiff.Writer(filename, d, 0, Ring.SrcImgSize.Width);
                }
                //単一画像モードの時
                else
                    Tiff.Writer(filename, new double[][] { Ring.Intensity.ToArray() }, 0, Ring.SrcImgSize.Width);
            }
            //Unrolled Imageのとき
            else
                Tiff.Writer(filename, new double[][] { pseudoBitmap.SrcValuesGray }, 3, pseudoBitmap.Width);
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
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.png|*.png";
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    filename = dlg.FileName;
                else
                    return;
            }
            else if (!filename.ToLower().EndsWith(".png"))
                filename += ".png";

            Bitmap bmp = pseudoBitmap.GetImage(new RectangleD(new Point(0, 0), new Size(scalablePictureBox.PseudoBitmap.Width, scalablePictureBox.PseudoBitmap.Height))
                , new Size(scalablePictureBox.PseudoBitmap.Width, scalablePictureBox.PseudoBitmap.Height));

            if (toolStripButtonUnroll.Checked) //UnrolledImageの目盛を付ける
            {
                Bitmap bmpWithAxis = new Bitmap(bmp.Width + 40, bmp.Height + 40);
                Graphics g = Graphics.FromImage(bmpWithAxis);
                g.SmoothingMode = SmoothingMode.HighQuality;
                g.Clear(Color.White);
                double upper = (double)FormProperty.numericUpDownUnrolledImageXend.Value;
                double lower = (double)FormProperty.numericUpDownUnrolledImageXstart.Value;

                float gradiation;//ここより角度目盛りの描画
                double d = (upper - lower) / Math.Pow(10, (int)Math.Log10(upper - lower));
                if (d < 1.6) gradiation = (float)(Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
                else if (d < 3.2) gradiation = (float)(2 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
                else if (d < 8.0) gradiation = (float)(5 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
                else gradiation = (float)(10 * Math.Pow(10, (int)Math.Log10(upper - lower) - 1));
                Pen pen = new Pen(Color.LightBlue, 1);
                Font strFont = new Font(new FontFamily("tahoma"), 8);
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

        private void ipaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SrcImgSize == null || SrcImgSize.Width == 0) return;

            FormSaveImage.Visible = true;

        }

        public void SetIntegralProperty()
        {
            try
            {
                IP.Camera = FormProperty.radioButtonFlatPanel.Checked ? IntegralProperty.CameraEnum.FlatPanel : IntegralProperty.CameraEnum.Gandolfi;
                IP.GandolfiRadius = FormProperty.numericBoxGandlfiRadius.Value;

                IP.SrcWidth = SrcImgSize.Width; ;//ソース画像の幅
                IP.SrcHeight = SrcImgSize.Height; ;//ソース画像の高さ
                IP.CenterX = FormProperty.numericBoxCenterPositionX.Value;//センターのx位置
                IP.CenterY = FormProperty.numericBoxCenterPositionY.Value;//センターのy位置
                IP.PixSizeX = FormProperty.numericBoxPixelSizeX.Value;
                IP.PixSizeY = FormProperty.numericBoxPixelSizeY.Value;//ピクセルサイズ
                IP.ksi = FormProperty.numericalTextBoxPixelKsi.RadianValue;

                IP.SpericalRadiusInverse = FormProperty.numericalTextBoxSphericalCorections.Value / 1000;

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
                        IP.StepDspacing =FormProperty.numericBoxConcentricStep.Value / 10.0;//角度もしくはピクセルのステップ
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


                IP.FilmDistance = FormProperty.CameraLength;//カメラ長
                IP.phi = FormProperty.numericBoxTiltCorrectionPhi.RadianValue; //IPの角度Tilt
                IP.tau = FormProperty.numericBoxTiltCorrectionTau.RadianValue; ;//IPの角度Azumuth;

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

                IP.IsTiltCorrection = FormProperty.checkBoxTiltCorrection.Checked;

                IP.IsBraggBrentanoMode = FormProperty.radioButtonBraggBrentano.Checked;
            }
            catch
            {
                MessageBox.Show("適切に入力されていない項目があります");
                return;
            }
            Ring.IP = IP;
        }

        #region 画像演算ボタン
        //FindCenterボタン
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
                    FormProperty.ImageCenter = center;
                }
                toolStripSplitButtonFindCenter.Enabled = true;
                this.toolStripStatusLabel.Text = "Calculating Time (Find Center):  " + (sw.ElapsedMilliseconds).ToString() + "ms";

                FormProperty.ImageTypeParameters[(int)Ring.ImageType].CenterPosX = FormProperty.ImageCenter.X;
                FormProperty.ImageTypeParameters[(int)Ring.ImageType].CenterPosY = FormProperty.ImageCenter.Y;

                if (FormFindParameter.Visible)
                {
                    
                    if (FormFindParameter.textBoxPrimaryFileName.Text.EndsWith(FileName) && (!SequentialImageMode||FormSequentialImage.SelectedIndex == FormFindParameter.numericBoxPrimaryImageNum.ValueInteger ))
                    {
                        FormFindParameter.numericalTextBoxPrimaryCenterPositionX.Text = FormProperty.ImageCenter.X.ToString("f8");
                        FormFindParameter.numericTextBoxPrimaryCenterPositionY.Text = FormProperty.ImageCenter.Y.ToString("f8");
                    }
                    else
                    {
                        FormFindParameter.numericTextBoxSecondaryCenterPositionX.Text = FormProperty.ImageCenter.X.ToString("f8");
                        FormFindParameter.numericTextBoxSecondaryCenterPositionY.Text = FormProperty.ImageCenter.Y.ToString("f8");
                    }
                }
            }
            else if (FormDrawRing.Visible && FormDrawRing.R>0)//デバイリングから、中心位置を検索する時
            {
                this.Enabled = false;
                tabControl1.SelectedIndex = 1;
                FormProperty.radioButtonConcentric.Checked = true;
                FormProperty.radioButtonConcentricAngle.Checked = true;
                var concentricStart = FormProperty.numericBoxConcentricStart.Value;
                var concentricEnd = FormProperty.numericBoxConcentricEnd.Value;

                var fittingRange = FormProperty.numericBoxFindCenterPeakFittingRange.Value;
                FormProperty.numericBoxConcentricStart.Value = FormDrawRing.TwoTheta / Math.PI * 180 - fittingRange*5;
                FormProperty.numericBoxConcentricEnd.Value = FormDrawRing.TwoTheta / Math.PI * 180 + fittingRange*5;

                PeakFunction pf = new PeakFunction(FormDrawRing.TwoTheta / Math.PI * 180, fittingRange/2, fittingRange, PeakFunctionForm.PseudoVoigt);
                FormProperty.radioButtonSector.Checked = true;
                for (int n = 0; n < 3; n++)
                {
                    List<PointD> pts = new List<PointD>();
                    var angleStep = 15;
                    for (int i = 0; i < 360 / angleStep; i++)
                    {
                        Skip = true;
                        FormProperty.numericUpDownSectorStartAngle.Value = (decimal)(angleStep * i - angleStep / 2);
                        Skip = false;
                        FormProperty.numericUpDownSectorEndAngle.Value = (decimal)(angleStep * i + angleStep / 2);
                        var profile = Ring.GetProfile(IP);

                        FittingPeak.FitPeakThread(profile.Pt.ToArray(), true, 0, ref pf);

                        graphControlProfile.Profile = profile;
                        graphControlProfile.Peaks = new PeakFunction[] { pf };
                        if (!double.IsNaN(pf.X) && pf.X != 0)
                            pts.Add(new PointD(IP.FilmDistance * Math.Tan(Math.PI / 180.0 * pf.X) * Math.Cos(Math.PI / 180.0 * angleStep * i), IP.FilmDistance * Math.Tan(Math.PI / 180.0 * pf.X) * Math.Sin(Math.PI / 180.0 * angleStep * i)));
                        Application.DoEvents();
                    }

                    var centerOffset = Geometriy.GetEllipseCenter(pts.ToArray());
                    if (double.IsNaN(centerOffset.X))
                        break;
                    double centerX = centerOffset.X / IP.PixSizeX + IP.CenterX;
                    double centerY = centerOffset.Y / IP.PixSizeY + IP.CenterY;
                    FormProperty.ImageCenter = new PointD(centerX, centerY);
                }

                FormProperty.radioButtonRectangle.Checked = true;
                FormProperty.numericBoxConcentricStart.Value = concentricStart;
                FormProperty.numericBoxConcentricEnd.Value = concentricEnd;

                this.Enabled = true;
            }
            Draw();
        }


        //FindSpotsボタン
        public void toolStripSplitButtonFindSpots_ButtonClick(object sender, EventArgs e)
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




        #region Maskボタン関連
        //ClearSpotsボタン
        public void toolStripMenuItemClearSpots_Click(object sender, EventArgs e)
        {
            if (!IsImageReady) return;
            for (int i = 0; i < Ring.IsSpots.Count; i++)
                Ring.IsSpots[i] = false;

            Draw();
        }

        private void inverseMaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!IsImageReady) return;
            for (int i = 0; i < Ring.IsSpots.Count; i++)
                Ring.IsSpots[i] = !Ring.IsSpots[i];
            Draw();
        }

        private void toolStripMenuItemMaskAll_Click(object sender, EventArgs e)
        {
            if (!IsImageReady) return;
            for (int i = 0; i < Ring.IsSpots.Count; i++)
                Ring.IsSpots[i] = true;
            Draw();
        }
        #endregion


        //GetIntensityボタン
        public void toolStripSplitButtonGetProfile_ButtonClick(object sender, EventArgs e)
        {
            GetProfile();
        }
        public void GetProfile(string fileName = "")
        {
            if (!IsImageReady) return;
            this.Cursor = Cursors.WaitCursor;
            toolStripSplitButtonGetProfile.Enabled = false;
            int d = Environment.TickCount;
            SetIntegralProperty();

            //パラメータをイメージ種ごとに保存
            FormProperty.SaveParameterForEachImageType(Ring.ImageType);

            if (findCenterBeforeGetProfileToolStripMenuItem.Checked == true && toolStripButtonFixCenter.Checked == false)
            {
                toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
                toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
            }
            if (findSpotsBeforeGetProfileToolStripMenuItem.Checked == true && toolStripButtonManualSpotMode.Checked == false)
                toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());

            if (FormProperty.radioButtonConcentricAngle.Checked)
                IP.Mode = HorizontalAxis.Angle;
            else
                IP.Mode = HorizontalAxis.d;

            //通常積分モード
            if (!toolStripMenuItemDividedByAngleStep.Checked)
            {
                try
                {
                    SetMask();

                    diffractionProfile.SrcAxisMode = IP.Mode;
                    diffractionProfile.SrcWaveLength = IP.WaveLength;
                    diffractionProfile.Mode = FormProperty.radioButtonConcentric.Checked ? DiffractionProfileMode.Concentric : DiffractionProfileMode.Radial;

                    int[] targets = new int[1];
                    //シーケンシャルモードの時の処理
                    if (toolStripButtonImageSequence.Enabled)
                    {
                        if (toolStripMenuItemAllSequentialImages.Checked)
                        {
                            targets = new int[FormSequentialImage.MaximumNumber];

                            for (int n = 0; n < FormSequentialImage.MaximumNumber; n++)
                                targets[n] = n;
                        }
                        else if (toolStripMenuItemSelectedSequentialImages.Checked)
                            targets = FormSequentialImage.SelectedIndices;
                    }

                    List<DiffractionProfile> dpList = new List<DiffractionProfile>();

                    for (int i = 0; i < targets.Length; i++)
                    {
                        //シーケンシャルモードの時の処理
                        if (toolStripButtonImageSequence.Enabled && (toolStripMenuItemAllSequentialImages.Checked || toolStripMenuItemSelectedSequentialImages.Checked))
                        {
                            FormSequentialImage.SkipCalcFreq = i != targets.Length - 1;
                            FormSequentialImage.AverageMode = false;
                            FormSequentialImage.SelectedIndex = targets[i];
                            if (Ring.ImageType == Ring.ImageTypeEnum.HDF5)
                                diffractionProfile.SrcWaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(Ring.SequentialImageEnergy[targets[i]]);
                        }

                        diffractionProfile.Name = FileName;
                        if (toolStripButtonImageSequence.Enabled)
                            diffractionProfile.Name += "  " + FileNameSub;

                        diffractionProfile.OriginalProfile = Ring.GetProfile(IP);

                        //必要であればKalpha2を除去
                        if(FormProperty.checkBoxTest.Checked)
                        {
                            if (FormProperty.waveLengthControl.XrayWaveSourceElementNumber > 10 && FormProperty.waveLengthControl.XrayWaveSourceLine == XrayLine.Ka1)
                            {
                                double alpha1 = AtomConstants.CharacteristicXrayWavelength(FormProperty.waveLengthControl.XrayWaveSourceElementNumber, Crystallography.XrayLine.Ka1);
                                double alpha2 = AtomConstants.CharacteristicXrayWavelength(FormProperty.waveLengthControl.XrayWaveSourceElementNumber, Crystallography.XrayLine.Ka2);
                                double ratio = FormProperty.numericBoxTest.Value;
                                diffractionProfile.OriginalProfile= DiffractionProfile.RemoveKalpha2(diffractionProfile.OriginalProfile,alpha1,alpha2,ratio);
                            }
                        }
                        //Unrolled Imageの作成
                        if (FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked)
                        {
                            double sectorStep = Math.PI * 1.0 / 180.0;
                            double xStart = IP.StartAngle;
                            double xEnd = IP.EndAngle;
                            double xStep = IP.StepAngle;
                            double[] temp = Ring.GetUnrolledImageArray(IP, sectorStep, xStart, xEnd, xStep);
                            diffractionProfile.ImageArray = new double[temp.Length];
                            for (int j = 0; j < temp.Length; j++)
                                diffractionProfile.ImageArray[j] = temp[j];
                            diffractionProfile.ImageScale = 1;
                            diffractionProfile.ImageWidth = (int)((xEnd - xStart) / xStep);
                            diffractionProfile.ImageHeight = (int)(2 * Math.PI / sectorStep);
                        }
                        else
                            diffractionProfile.ImageArray = null;

                        dpList.Add((DiffractionProfile)diffractionProfile.Clone());
                    }

                    //PDIndexerへの送信
                    if (FormProperty.checkBoxSendProfileToPDIndexer.Checked)
                    {
                        using Mutex clipboard = new Mutex(false, "ClipboardOperation");
                        if (clipboard.WaitOne(500, false))
                        {
                            Clipboard.SetDataObject(dpList.ToArray());
                            clipboard.ReleaseMutex();
                        }
                        clipboard.Close();
                    }
                    //ファイル保存
                    if (FormProperty.checkBoxSaveFile.Checked)
                        SaveProfile(diffractionProfile,fileName);

                    graphControlProfile.Profile = diffractionProfile.OriginalProfile;

                    toolStripSplitButtonGetProfile.Enabled = true;
                    this.toolStripStatusLabel.Text = "Calculating Time (Get Profile):  " + (Environment.TickCount - d).ToString() + "ms";
                }

                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("正常にデータを送信できませんでした。");
                    this.Cursor = Cursors.Default;
                    toolStripSplitButtonGetProfile.Enabled = true;
                    return;
                }
            }
            else //LPOモードのとき
            {
                #region
                try
                {
                    List<DiffractionProfile> dpList = new List<DiffractionProfile>();

                    toolStripSplitButtonGetProfile.Enabled = false;

                    double anglestep;
                    try { anglestep = Convert.ToDouble(toolStripComboBoxAngleStep.Text); }
                    catch { return; }

                    FormProperty.radioButtonRectangle.Checked = true; ;
                    FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;

                    diffractionProfile.OriginalProfile = Ring.GetProfile(IP);
                    diffractionProfile.Name = FileName + " - whole";
                    diffractionProfile.SrcAxisMode = FormProperty.radioButtonConcentricAngle.Checked ? HorizontalAxis.Angle : HorizontalAxis.Length;
                    diffractionProfile.SrcWaveLength = IP.WaveLength;
                    diffractionProfile.IsLPOmain = true;
                    diffractionProfile.IsLPOchild = false;

                    this.toolStripStatusLabel.Text = "Calculating Time (Get Profile):  " + (Environment.TickCount - d).ToString() + "ms";

                    dpList.Add((DiffractionProfile)diffractionProfile.Clone());

                    string tempFilename = "";
                    if (FormProperty.checkBoxSaveFile.Checked)
                    {
                        if (FormProperty.radioButtonSetDirectoryEachTime.Checked)
                        {
                            string extension = FormProperty.radioButtonAsPDIformat.Checked ? ".pdi" : ".csv";
                            SaveFileDialog dlg = new SaveFileDialog();
                            dlg.FileName = FileName;
                            dlg.Filter = extension + "|" + extension;

                            if (dlg.ShowDialog() != DialogResult.OK)
                                throw new Exception();

                            tempFilename = dlg.FileName;
                            tempFilename = tempFilename.Remove(tempFilename.LastIndexOf("."));
                            SaveProfile(diffractionProfile,tempFilename + "-whole" + extension);
                        }
                        else
                            SaveProfile(diffractionProfile,fileName);
                    }

                    graphControlProfile.Profile = diffractionProfile.Profile;


                    FormProperty.radioButtonSector.Checked = true;
                    for (int i = 0; i < 360 / anglestep; i++)
                    {
                        Skip = true;
                        FormProperty.numericUpDownSectorStartAngle.Value = (decimal)(anglestep * i - anglestep / 2);
                        Skip = false;
                        FormProperty.numericUpDownSectorEndAngle.Value = (decimal)(anglestep * i + anglestep / 2);
                        Application.DoEvents();
                        //SetMask();
                        diffractionProfile.OriginalProfile = Ring.GetProfile(IP);
                        diffractionProfile.Name = FileName + " - " + (i * anglestep).ToString("000");
                        diffractionProfile.SrcAxisMode = FormProperty.radioButtonConcentricAngle.Checked ? HorizontalAxis.Angle : HorizontalAxis.Length;
                        diffractionProfile.SrcTakeoffAngle = IP.WaveLength;
                        diffractionProfile.IsLPOmain = false;
                        diffractionProfile.IsLPOchild = true;

                        this.toolStripStatusLabel.Text = "Calculating Time (Get Profile):  " + (Environment.TickCount - d).ToString() + "ms";
                        //toolStripSplitButtonGetProfile.Enabled = true;

                        dpList.Add((DiffractionProfile)diffractionProfile.Clone());
                        if (FormProperty.checkBoxSaveFile.Checked)
                        {
                            if (FormProperty.radioButtonSetDirectoryEachTime.Checked)
                                SaveProfile( diffractionProfile,tempFilename + "-" + (i * anglestep).ToString("000"));
                            else
                                SaveProfile(diffractionProfile);
                        }

                    }
                    if (FormProperty.checkBoxSendProfileToPDIndexer.Checked)
                    {
                        using (Mutex clipboard = new Mutex(false, "ClipboardOperation"))
                        {
                            if (clipboard.WaitOne(5000, false))
                            {
                                Clipboard.SetDataObject(dpList.ToArray());
                                clipboard.ReleaseMutex();
                            }
                            clipboard.Close();
                        }
                    }
                    FormProperty.radioButtonRectangle.Checked = true; ;
                    FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;
                    toolStripSplitButtonGetProfile.Enabled = true;
                }
                catch
                {
                    toolStripSplitButtonGetProfile.Enabled = true;
                    FormProperty.radioButtonRectangle.Checked = true;
                    FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;

                    MessageBox.Show("正常にデータを送信できませんでした。");
                    this.Cursor = Cursors.Default;
                    return;
                }
                #endregion
            }

            this.Cursor = Cursors.Default;
        }



        private void toolStripMenuItemProperty_Click(object sender, EventArgs e)
        {
            FormProperty.Visible = true;
        }

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
        private void toolStripMenuItemAssociatedExtensions_Click(object sender, EventArgs e)
        {
            FormProperty.Visible = true;
            FormProperty.tabControl.SelectedIndex = 7;
        }
        private void toolStripMenuItemMiscellaneous_Click(object sender, EventArgs e)
        {
            FormProperty.Visible = true;
            FormProperty.tabControl.SelectedIndex = 8;
        }

        #endregion

        private void SaveProfile(DiffractionProfile dp, string filename="")
        {
            string extension = FormProperty.radioButtonAsPDIformat.Checked ? ".pdi" : ".csv";
            if (FormProperty.radioButtonSetDirectoryEachTime.Checked)
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = extension + "|" + extension;
                dialog.FileName = dp.Name.Substring(0, dp.Name.LastIndexOf('.'));
                if (dialog.ShowDialog() == DialogResult.OK)
                    filename = dialog.FileName;
                else return;
            }
            else if(filename=="")
                filename = FilePath + dp.Name.Substring(0, dp.Name.LastIndexOf('.')) + extension;


            if (FormProperty.radioButtonAsPDIformat.Checked)
            {
                if (!filename.EndsWith(".pdi"))
                    filename += ".pdi";
                XYFile.SavePdiFile(new DiffractionProfile[] { dp }, filename);
            }
            else if (FormProperty.radioButtonAsCSVformat.Checked)
            {
                if (!filename.EndsWith(".csv"))
                    filename += ".csv";
                StreamWriter sw = new StreamWriter(filename);
                for (int i = 0; i < dp.OriginalProfile.Pt.Count; i++)
                    sw.WriteLine(dp.OriginalProfile.Pt[i].X.ToString() + "," + dp.OriginalProfile.Pt[i].Y.ToString());
                sw.Close();
            }
            else if (FormProperty.radioButtonAsTSVformat.Checked)
            {
                if (!filename.EndsWith(".tsv"))
                    filename += ".tsv";
                StreamWriter sw = new StreamWriter(filename);
                for (int i = 0; i < dp.OriginalProfile.Pt.Count; i++)
                    sw.WriteLine(dp.OriginalProfile.Pt[i].X.ToString() + "\t" + dp.OriginalProfile.Pt[i].Y.ToString());
                sw.Close();
            }
        }

      //  private void SaveProfile(string filename, DiffractionProfile dp)
    
        public void SetMask()
        {
            //ここを呼び出す時には
            //インテグラルプロパティをセット
            SetIntegralProperty();
            Ring.SetMask(FormProperty.checkBoxOmitSpots.Checked, FormProperty.checkBoxThresholdMin.Checked, FormProperty.checkBoxThresholdMax.Checked);
        }

        //public bool Skip = false;
        public void IntegralArea_Changed(object sender, EventArgs e)
        {
            if (!IsImageReady || Skip) return;

            SetIntegralProperty();

            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            if (FormFindParameter.Visible && FormFindParameter.backgroundWorkerRefine.IsBusy)
                Ring.SetInsideArea(IP, true, false, false);
            else
                Ring.SetInsideArea(IP);

            this.toolStripStatusLabel.Text = "Calculating Time (SetIntegralArea):  " + sw.ElapsedMilliseconds.ToString() + "ms";

            SetMask();
            Draw();
        }

        #region 子フォームの立ち上げ、終了

        private void toolStripButtonIntensityTable_CheckedChanged(object sender, EventArgs e)
        {
            FormIntTable.Visible = toolStripButtonIntensityTable.Checked;
        }

        private void toolStripButtonAutoProcedure_CheckedChanged(object sender, EventArgs e)
        {
            FormAutoProc.Visible = toolStripButtonAutoProcedure.Checked;
        }

        private void toolStripButtonRing_CheckedChanged(object sender, EventArgs e)
        {
           var loc = FormDrawRing.Location;

            FormDrawRing.Visible = toolStripButtonRing.Checked;

            FormDrawRing.Location = loc;
           
        }

        private void toolStripButtonFindParameter_CheckedChanged(object sender, EventArgs e)
        {
            FormFindParameter.Visible = toolStripButtonFindParameter.Checked;
        }

        private void toolStripButtonImageSequence_CheckedChanged(object sender, EventArgs e)
        {
            FormSequentialImage.Visible = toolStripButtonImageSequence.Checked;
            FormSequentialImage.Location = new Point(this.Location.X + 50, this.Location.Y + 50);
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
        private void setScale()
        {
            pseudoBitmap.IsNegative = comboBoxGradient.SelectedIndex == 1;

            //スケールをセット
            if (comboBoxScale1.SelectedIndex == 0)//ログスケール
                if (comboBoxScale2.SelectedIndex == 0)//グレー
                {
                    pseudoBitmap.ScaleR = pseudoBitmap.ScaleG = pseudoBitmap.ScaleB = PseudoBitmap.BrightnessScaleLog;
                    pseudoBitmap.GrayScale = true;
                }
                else
                {
                    pseudoBitmap.ScaleR = PseudoBitmap.BrightnessScaleLogColorR;
                    pseudoBitmap.ScaleG = PseudoBitmap.BrightnessScaleLogColorG;
                    pseudoBitmap.ScaleB = PseudoBitmap.BrightnessScaleLogColorB;
                    pseudoBitmap.GrayScale = false;
                }
            else//リニア
                if (comboBoxScale2.SelectedIndex == 0)//グレー
                {
                    pseudoBitmap.ScaleR = pseudoBitmap.ScaleG = pseudoBitmap.ScaleB = PseudoBitmap.BrightnessScaleLiner;
                    pseudoBitmap.GrayScale = true;
                }
                else//color
                {
                    pseudoBitmap.ScaleR = PseudoBitmap.BrightnessScaleLinerColorR;
                    pseudoBitmap.ScaleG = PseudoBitmap.BrightnessScaleLinerColorG;
                    pseudoBitmap.ScaleB = PseudoBitmap.BrightnessScaleLinerColorB;
                    pseudoBitmap.GrayScale = false;
                }
            numericUpDownMaxInt_ValueChanged(new object(), new EventArgs());
            numericUpDownMinInt_ValueChanged(new object(), new EventArgs());
        }

        #endregion


        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b')
                e.Handled = true;
        }

        private void aboutMeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAboutMe formAboutMe = new FormAboutMe();
            formAboutMe.ShowDialog();
        }

        #region パラメータの読み書き

        private void toolStripMenuItemReadParameter_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "*.prm[Parameter File]|*.prm";
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
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "*.prm[Parameter File]|*.prm";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                SaveParameter(dialog.FileName, ((ToolStripMenuItem)sender).Name.Contains("Fully"));
                initialParameterDirectory = Path.GetDirectoryName(dialog.FileName);
            }
        }


        public string initialParameterDirectory;
        public void SaveParameter(string filename, bool fullySave = true)
        {
            fullySave = false;
            try
            {
                DiffractionOptics.Parameter prm = new DiffractionOptics.Parameter();
               
                if (!fullySave)
                {
                    FormParameterOption.Text = "Save checked parameters";
                    if (FormParameterOption.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                else
                    FormParameterOption.AllCheck();

                prm.SACLA_EH5 = (FormProperty.checkBoxSACLA.Checked) ? "True" : null;

                if (FormProperty.checkBoxSACLA.Checked)
                {
                    prm.SACLA_EH5_CameraLength2 = FormProperty.saclaControl.CameraLength2.ToString();
                    prm.SACLA_EH5_Phi = FormProperty.saclaControl.PhiDegree.ToString();
                    prm.SACLA_EH5_Tau = FormProperty.saclaControl.TauDegree.ToString();
                    prm.SACLA_EH5_PixelHeight = FormProperty.saclaControl.PixelHeight.ToString();
                    prm.SACLA_EH5_PixelWidth = FormProperty.saclaControl.PixelWidth.ToString();
                    prm.SACLA_EH5_PixleSize = FormProperty.saclaControl.PixelSize.ToString();
                    prm.SACLA_EH5_FootX = FormProperty.saclaControl.Foot.X.ToString();
                    prm.SACLA_EH5_FootY = FormProperty.saclaControl.Foot.Y.ToString();
                }

                prm.cameraMode = (FormParameterOption.CameraModeChecked) ? (FormProperty.radioButtonFlatPanel.Checked ? "FlatPanel" : "Gandolfi") : null;

                prm.waveSource = (FormParameterOption.WaveLengthChecked) ? ((int)FormProperty.waveLengthControl.WaveSource).ToString() : null;
                prm.waveLength = (FormParameterOption.WaveLengthChecked) ? FormProperty.WaveLengthText : null;

                prm.xRayElement = (FormParameterOption.WaveLengthChecked) ? FormProperty.waveLengthControl.XrayWaveSourceElementNumber.ToString() : null;
                prm.xRayLine = (FormParameterOption.WaveLengthChecked) ? ((int)FormProperty.waveLengthControl.XrayWaveSourceLine).ToString() : null;

                prm.cameraLength = (FormParameterOption.CameraLengthChecked) ? FormProperty.CameraLengthText : null;

                prm.pixSizeX = (FormParameterOption.PixelShapeChecked) ? FormProperty.numericBoxPixelSizeX.Text : null;
                prm.pixSizeY = (FormParameterOption.PixelShapeChecked) ? FormProperty.numericBoxPixelSizeY.Text : null;
                prm.pixKsi = (FormParameterOption.PixelShapeChecked) ? FormProperty.numericalTextBoxPixelKsi.Text : null;

                prm.tiltPhi = (FormParameterOption.TiltCorrectionChecked) ? FormProperty.numericBoxTiltCorrectionPhi.Text : null;
                prm.tiltTau = (FormParameterOption.TiltCorrectionChecked) ? FormProperty.numericBoxTiltCorrectionTau.Text : null;

                prm.centerX = (FormParameterOption.CenterPositionChecked) ? FormProperty.numericBoxCenterPositionX.Text : null;
                prm.centerY = (FormParameterOption.CenterPositionChecked) ? FormProperty.numericBoxCenterPositionY.Text : null;

                prm.sphericalRadiusInverse = (FormParameterOption.SphericalCorrectionChecked) ? FormProperty.numericalTextBoxSphericalCorections.Text : null;

                prm.GandolfiRadius = (FormParameterOption.GandolfiRadiusChecked) ? FormProperty.numericBoxGandlfiRadius.Text : null;

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

                System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(typeof(DiffractionOptics.Parameter));
                System.IO.FileStream fs = new System.IO.FileStream(filename, System.IO.FileMode.Create);
                serializer.Serialize(fs, prm);
                fs.Close();

            }
            catch { MessageBox.Show("Failed to save the file. Sorry."); }

        }



        public void ReadParameter(string filename, bool fullyRead = true)
        {
            fullyRead = false;
            //イベントをスキップ
            skipSelectedAreaChangedEvent = true;
            Skip = true;

            try
            {
                DiffractionOptics.Parameter prm = DiffractionOptics.Read(filename);

                if (!fullyRead)
                {
                    FormParameterOption.Text = "Read checked parameters";
                    FormParameterOption.Location = new Point(MousePosition.X - FormParameterOption.Width / 2, MousePosition.Y - FormParameterOption.Height / 2);
                    if (FormParameterOption.ShowDialog() == System.Windows.Forms.DialogResult.Cancel)
                        return;
                }
                else
                    FormParameterOption.AllCheck();


                FormProperty.checkBoxSACLA.Checked = prm.SACLA_EH5 == "True";
                if (prm.SACLA_EH5 == "True")
                {
                    if (prm.SACLA_EH5_CameraLength2 != null)
                        FormProperty.saclaControl.CameraLength2 = Convert.ToDouble(prm.SACLA_EH5_CameraLength2);
                    else
                        FormProperty.saclaControl.CameraLength2 = Convert.ToDouble(prm.SACLA_EH5_Distance);

                    FormProperty.saclaControl.PixelHeight = Convert.ToDouble(prm.SACLA_EH5_PixelHeight);
                    FormProperty.saclaControl.PixelWidth = Convert.ToDouble(prm.SACLA_EH5_PixelWidth);
                    FormProperty.saclaControl.PixelSize = Convert.ToDouble(prm.SACLA_EH5_PixleSize);

                    FormProperty.saclaControl.Foot = new PointD(Convert.ToDouble(prm.SACLA_EH5_FootX), Convert.ToDouble(prm.SACLA_EH5_FootY));

                    if (prm.SACLA_EH5_Phi != null)
                    {
                        FormProperty.saclaControl.PhiDegree = Convert.ToDouble(prm.SACLA_EH5_Phi);
                        FormProperty.saclaControl.TauDegree = Convert.ToDouble(prm.SACLA_EH5_Tau);
                    }
                    else
                    {
                        FormProperty.saclaControl.PhiDegree = 0;
                        FormProperty.saclaControl.TauDegree = Convert.ToDouble(prm.SACLA_EH5_TwoTheta);
                    }
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
                        FormProperty.waveLengthControl.XrayWaveSourceLine = (Crystallography.XrayLine)Convert.ToInt32(prm.xRayLine);

                    if (prm.waveLength != null && (FormProperty.waveLengthControl.WaveSource == WaveSource.Electron || FormProperty.waveLengthControl.XrayWaveSourceElementNumber == 0))
                        FormProperty.WaveLengthText = prm.waveLength;
                }

                if (FormParameterOption.CameraLengthChecked && prm.cameraLength != null)
                    FormProperty.CameraLengthText = prm.cameraLength;

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
                        FormProperty.numericalTextBoxPixelKsi.Text = prm.pixKsi;

                }

                //CenterPorition
                if (FormParameterOption.CenterPositionChecked && prm.centerX != null)
                {
                    FormProperty.numericBoxCenterPositionX.Text = prm.centerX;
                    FormProperty.numericBoxCenterPositionY.Text = prm.centerY;
                }

                //TiltCorrection
                if (FormParameterOption.TiltCorrectionChecked && prm.tiltPhi != null)
                {
                    FormProperty.numericBoxTiltCorrectionPhi.Text = prm.tiltPhi;
                    FormProperty.numericBoxTiltCorrectionTau.Text = prm.tiltTau;
                }

                //SphericalRadius
                if (FormParameterOption.TiltCorrectionChecked && prm.sphericalRadiusInverse != null)
                    FormProperty.numericalTextBoxSphericalCorections.Text = prm.sphericalRadiusInverse;

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
            IntegralArea_Changed(new object(),new EventArgs());

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



        private void webPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (Thread.CurrentThread.CurrentUICulture.ToString().Contains("ja"))
                    System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/IPAnalyzer/ja/IPAnalyzerHelp.html");
                else
                    System.Diagnostics.Process.Start("http://pmsl.planet.sci.kobe-u.ac.jp/~seto/software/IPAnalyzer/en/IPAnalyzerHelp.html");


            }
            catch { }
        }

        public bool thumbnailmode = false;
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            thumbnailmode = !thumbnailmode;
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

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Draw();
        }



        private void FormMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Shift && e.KeyCode == Keys.C)
                toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
            else if (e.Control && e.Shift && e.KeyCode == Keys.S)
                toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());
            else if (e.Control && e.Shift && e.KeyCode == Keys.G)
                toolStripSplitButtonGetProfile_ButtonClick(new object(), new EventArgs());
            else if (e.Control && e.Shift && e.KeyCode == Keys.B)
                toolStripSplitButtonBackground_ButtonClick(new object(), new EventArgs());
            else if (e.Control && e.Shift && e.KeyCode == Keys.M)
                FormProperty.checkBoxManualMaskMode.Checked = !FormProperty.checkBoxManualMaskMode.Checked;
            else if (e.Control && scalablePictureBox.Focused)
            {
                IsManualSpotMode = true;
                FormProperty.checkBoxManualMaskMode.Checked = true;
                Draw();
            }
            else if (e.Control && e.KeyCode == Keys.Left && toolStripButtonImageSequence.Enabled && FormSequentialImage.SelectedIndex > 0)
                FormSequentialImage.SelectedIndex--;
            else if (e.Control && e.KeyCode == Keys.Right && toolStripButtonImageSequence.Enabled && FormSequentialImage.SelectedIndex < FormSequentialImage.MaximumNumber)
                FormSequentialImage.SelectedIndex++;

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

        #region Maskファイルの読み書き
        public string initialMaskDirectory;
        private void toolStripMenuItemReadMask_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Mask file; *.mas|*.mas";
            if (initialMaskDirectory != "")
                dlg.InitialDirectory = initialMaskDirectory;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                readMaskFile(dlg.FileName);
                initialMaskDirectory = Path.GetDirectoryName(dlg.FileName);
            }
        }

        private void readMaskFile(string filename)
        {
            try
            {
                BinaryReader br = new BinaryReader(new FileStream(filename, FileMode.Open, FileAccess.ReadWrite));
                bool[] mask = new bool[br.ReadInt32()];
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
                if (Ring.IsSpots != null && mask != null && mask.Length == Ring.IsSpots.Count)
                {
                    for (int i = 0; i < mask.Length; i++)
                        Ring.IsSpots[i] = mask[i];


                    SetMask();
                    Draw();
                }
            }
            catch { }
        }


        public void toolStripMenuItemSaveMask_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "Mask file; *.mas|*.mas";
            if (dlg.ShowDialog() == DialogResult.OK)
                SaveMask(dlg.FileName);
        }

        public void SaveMask(string fileName)
        {
            BinaryWriter br = new BinaryWriter(new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite));
            br.Write(Ring.IsSpots.Count);
            int n = 0;
            for (int i = 0; i < Ring.IsSpots.Count / 8; i++)
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
        #endregion




        private void hintToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitialDialog.ShowProgressBar = false;
            InitialDialog.Text = "Hint";
            InitialDialog.Show();
        }



        double maxIntensity = uint.MinValue;
        double sumOfIntensity = 0;
        double variance = 0;
        public void SetFrequencyProfile()
        {
            maxIntensity = uint.MinValue;
            sumOfIntensity = 0;
            double sumOfSquare = 0;
            frequencyProfile = new Profile();
            frequencyProfile.Pt = new List<PointD>();
            for (int i = 0; i < Ring.Intensity.Count; i++)
            {
                double intensity = Ring.Intensity[i];
                maxIntensity = Math.Max(maxIntensity, intensity);
                sumOfIntensity += intensity;
                sumOfSquare += intensity * intensity;
            }

            for (int i = 0; i < Ring.Frequency.Count; i++)
                frequencyProfile.Pt.Add(new PointD(Ring.Frequency.Keys[i], Ring.Frequency[Ring.Frequency.Keys[i]]));
            graphControlFrequency.Profile = frequencyProfile;
            variance = Math.Sqrt((Ring.Intensity.Count * sumOfSquare - sumOfIntensity * sumOfIntensity) / Ring.Intensity.Count / (Ring.Intensity.Count - 1));
        }



        private void graphControlFrequency_LinePositionChanged()
        {
            if (graphControlFrequency.LineList.Length == 2)
            {
                decimal max = (decimal)((int)Math.Max(graphControlFrequency.LineList[0].X, graphControlFrequency.LineList[1].X));
                if (numericUpDownMaxInt.Maximum < max)
                    numericUpDownMaxInt.Value = numericUpDownMaxInt.Maximum;
                else if (numericUpDownMinInt.Minimum > max)
                    numericUpDownMaxInt.Value = numericUpDownMaxInt.Minimum;
                else
                    numericUpDownMaxInt.Value = max;

                decimal min = (decimal)((int)Math.Min(graphControlFrequency.LineList[0].X, graphControlFrequency.LineList[1].X));
                if (numericUpDownMinInt.Maximum < min)
                    numericUpDownMinInt.Value = numericUpDownMinInt.Maximum;
                else if (numericUpDownMinInt.Minimum > min)
                    numericUpDownMinInt.Value = numericUpDownMinInt.Minimum;
                else
                    numericUpDownMinInt.Value = min;
            }
        }

        private void resetFrequencyProfileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetFrequencyProfile();
        }

        private void calibrateRaxisImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormCalibrateIntensity.Show();
        }

        private void fourierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double[][] valueGray = new double[Ring.SrcImgSize.Height][];
            int n = 0;
            for (int y = 0; y < Ring.SrcImgSize.Height; y++)
            {
                valueGray[y] = new double[Ring.SrcImgSize.Width];
                for (int x = 0; x < Ring.SrcImgSize.Width; x++)
                    valueGray[y][x] = Ring.Intensity[n++];
            }
            Complex[][] reverse = Fourier.FFT(valueGray);
            //return new PseudoBitmap(, scale, scale, scale, normarize, false);
            byte[] scale = new byte[256];
            for (int i = 0; i < 256; i++)
                scale[i] = (byte)i;

            pseudoBitmap = new PseudoBitmap(reverse, scale, scale, scale, false, false);
            scalablePictureBox.PseudoBitmap = pseudoBitmap;
            scalablePictureBoxThumbnail.PseudoBitmap = pseudoBitmap;
            Draw();
        }

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





        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
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

                if (MessageBox.Show("Check parameters!　This process will take few minutes if the resolution of the unrolled image is high. ", "", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    double sectorStep = Math.PI * (double)FormProperty.numericUpDownUnrollSectorStep.Value / 180.0;
                    double xStart = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXstart.Value / 180.0;
                    double xEnd = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXend.Value / 180.0;
                    double xStep = Math.PI * (double)FormProperty.numericUpDownUnrolledImageXstep.Value / 180.0;

                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();

                    double[] imageArray = Ring.GetUnrolledImageArray(IP, sectorStep, xStart, xEnd, xStep);

                    this.toolStripStatusLabel.Text = "Calculating Time (Unroll Image):  " + sw.ElapsedMilliseconds.ToString() + "ms";

                    byte[] scale = new byte[256];
                    for (int i = 0; i < 256; i++)
                        scale[i] = (byte)i;
                    pseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / (int)(2 * Math.PI / sectorStep), scale, scale, scale, false);

                    scalablePictureBox.PseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / (int)(2 * Math.PI / sectorStep), scale, scale, scale, false);
                    scalablePictureBoxThumbnail.PseudoBitmap = new PseudoBitmap(imageArray, imageArray.Length / (int)(2 * Math.PI / sectorStep), scale, scale, scale, false);
                    //setScale();
                    Draw();
                }
                else
                {
                    toolStripButtonUnroll.Checked = false;
                }
            }
            else
            {
                initializeFilter();
                //setScale();
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

        private void toolStripMenuItemSendProfileToPDIndexer_Click(object sender, EventArgs e)
        {
            FormProperty.checkBoxSendProfileToPDIndexer.Checked = !FormProperty.checkBoxSendProfileToPDIndexer.Checked;
        }

        private void toolStripMenuItemSendUnrolledImage_Click(object sender, EventArgs e)
        {
            FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked = !FormProperty.checkBoxSendUnrolledImageToPDIndexer.Checked;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            FormCalibrateIntensity.Visible = true;
        }

        private void toolStripComboBoxManualSpotSize_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripButtonCircumferentialBlur_Click(object sender, EventArgs e)
        {
            FormBlurAngle formBlurAngle = new FormBlurAngle();
            if (formBlurAngle.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Ring.CircumferentialBlur(formBlurAngle.BlurAngle);
                initializeFilter();
                Draw();
            }
        }


        private void languageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            englishToolStripMenuItem.Checked = ((ToolStripMenuItem)sender).Name.Contains("english");
            japaneseToolStripMenuItem.Checked = !englishToolStripMenuItem.Checked;
            Thread.CurrentThread.CurrentUICulture = englishToolStripMenuItem.Checked ? new System.Globalization.CultureInfo("en") : new System.Globalization.CultureInfo("ja");
            Language.Change(this);
        }

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



        public void FlipRotate_Pollalization_Background(bool zoomReset = true)
        {
            if (Skip) return;

            if (Ring.IntensityOriginal == null || Ring.Intensity.Count == 0)
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

            if (Ring.Background != null && Ring.Background.Count == Ring.Intensity.Count)
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

                Ring.Intensity = Ring.CorrectPolarization(toolStripComboBoxRotate.SelectedIndex);
                this.toolStripStatusLabel.Text = "Calculating Time (Polarization Correction):  " + (sw.ElapsedMilliseconds).ToString() + "ms";
            }
            //偏光補正ここまで

            Ring.CalcFreq();
            SetFrequencyProfile();//強度頻度グラフを作成

            for (int i = 0; i < Ring.Intensity.Count; i++)
                pseudoBitmap.SrcValuesGray[i] = pseudoBitmap.SrcValuesGrayOriginal[i] = Ring.Intensity[i];

            IntegralArea_Changed(new object(), new EventArgs());
            if (zoomReset)
                scalablePictureBox.Zoom = 0;
        }


        private void flipHorizontallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FlipRotate_Pollalization_Background();
        }

        private void flipVerticallyToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            FlipRotate_Pollalization_Background();
        }

        private void toolStripComboBoxRotate_SelectedIndexChanged(object sender, EventArgs e)
        {
            FlipRotate_Pollalization_Background();
        }


        #region
        /*
        private void Rotate(int rotateDegree)
        {
            if (Ring.IntensityOriginal == null)
                return;

            double[] tempIntensity = new double[Ring.SrcImgSize.Width * Ring.SrcImgSize.Height];

            Func<int, int, int> convertIndex;
            if (rotateDegree == 90)
                convertIndex = new Func<int, int, int>((w, h) => Ring.SrcImgSize.Height * w + Ring.SrcImgSize.Height - h - 1);
            else if (rotateDegree == 180)
                convertIndex = new Func<int, int, int>((w, h) => (Ring.SrcImgSize.Height - h - 1) * Ring.SrcImgSize.Width + (Ring.SrcImgSize.Width - w - 1));
            else if (rotateDegree == 270)
                convertIndex = new Func<int, int, int>((w, h) => Ring.SrcImgSize.Height * (Ring.SrcImgSize.Width - w - 1) + h);
            else
                return;

            for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                for (int w = 0; w < Ring.SrcImgSize.Width; w++)
                    tempIntensity[convertIndex(w, h)] = Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + w];

            for (int i = 0; i < Ring.IntensityOriginal.Count; i++)
                pseudoBitmap.SrcValuesGray[i] = pseudoBitmap.SrcValuesGrayOriginal[i] = Ring.IntensityOriginal[i] = tempIntensity[i];

            if (rotateDegree == 90 || rotateDegree == 270)
            {
                Ring.SrcImgSize = new Size(Ring.SrcImgSize.Height, Ring.SrcImgSize.Width);
                Ring.IP.SrcHeight = Ring.SrcImgSize.Width;
                Ring.IP.SrcWidth = Ring.SrcImgSize.Height;
                pseudoBitmap.Width = Ring.SrcImgSize.Width;
                pseudoBitmap.Height = Ring.SrcImgSize.Height;
                SrcImgSize = Ring.SrcImgSize;
                IntegralArea_Changed(new object(), new EventArgs());
                scalablePictureBox.ResetMinimumZoomValue();
                
            }

            

            if (SequentialImageMode)
            {
                for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
                {
                    for (int w = 0; w < Ring.SrcImgSize.Width; w++)
                        for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                            tempIntensity[convertIndex(w, h)] = Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + w];
                    for (int j = 0; j < Ring.IntensityOriginal.Count; j++)
                        Ring.SequentialImageIntensities[i][j] = tempIntensity[j];
                }
            }

            for (int i = 0; i < Ring.Intensity.Count; i++)
                Ring.Intensity[i] =   Ring.IntensityOriginal[i];

            Draw();

        }


        private void FlipHorizontally()
        {
            if (Ring.IntensityOriginal != null)
            {
                for (int w = 0; w < Ring.SrcImgSize.Width / 2; w++)
                    for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                    {
                        double intensity = Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + w];
                        Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + w] = Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + Ring.SrcImgSize.Width - w - 1];
                        Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + Ring.SrcImgSize.Width - w - 1] = intensity;
                    }
                for (int i = 0; i < Ring.IntensityOriginal.Count; i++)
                    pseudoBitmap.SrcValuesGray[i] = pseudoBitmap.SrcValuesGrayOriginal[i] = Ring.IntensityOriginal[i];
               

                if (SequentialImageMode)
                {
                    for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
                        for (int w = 0; w < Ring.SrcImgSize.Width / 2; w++)
                            for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                            {
                                double intensity = Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + w];
                                Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + w] = Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + Ring.SrcImgSize.Width - w - 1];
                                Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + Ring.SrcImgSize.Width - w - 1] = intensity;
                            }

                }
                for (int i = 0; i < Ring.Intensity.Count; i++)
                    Ring.Intensity[i] = Ring.IntensityOriginal[i];
                Draw();
            }
        }

        private void FlipVertically()
        {
            if (Ring.IntensityOriginal != null)
            {
                for (int h = 0; h < Ring.SrcImgSize.Height / 2; h++)
                    for (int w = 0; w < Ring.SrcImgSize.Width; w++)
                    {
                        double intensity = Ring.IntensityOriginal[(Ring.SrcImgSize.Height - h - 1) * Ring.SrcImgSize.Width + w];
                        Ring.IntensityOriginal[(Ring.SrcImgSize.Height - h - 1) * Ring.SrcImgSize.Width + w] = Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + w];
                        Ring.IntensityOriginal[h * Ring.SrcImgSize.Width + w] = intensity;
                    }
                for (int i = 0; i < Ring.IntensityOriginal.Count; i++)
                    pseudoBitmap.SrcValuesGray[i] = pseudoBitmap.SrcValuesGrayOriginal[i] = Ring.IntensityOriginal[i];
                

                if (SequentialImageMode)
                {
                    for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
                        for (int w = 0; w < Ring.SrcImgSize.Width / 2; w++)
                            for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                            {
                                double intensity = Ring.SequentialImageIntensities[i][(Ring.SrcImgSize.Height - h - 1) * Ring.SrcImgSize.Width + w];
                                Ring.SequentialImageIntensities[i][(Ring.SrcImgSize.Height - h - 1) * Ring.SrcImgSize.Width + w] = Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + w];
                                Ring.SequentialImageIntensities[i][h * Ring.SrcImgSize.Width + w] = intensity;
                            }
                }
                for (int i = 0; i < Ring.Intensity.Count; i++)
                    Ring.Intensity[i] = Ring.IntensityOriginal[i];

                Draw();
            }
        }*/
        #endregion

        #region 偏光補正
/*
        public void correctPolarization(bool correct)
        {

            if (Ring.Intensity.Count != 0)
            {
                if (correct)
                {
                    sw.Restart();
                    double SinTau = Math.Sin(IP.tau), CosTau = Math.Cos(IP.tau);
                    double SinPhi = Math.Sin(IP.phi), CosPhi = Math.Cos(IP.phi), sinPhi2 = SinPhi * SinPhi, cosPhi2 = CosPhi * CosPhi, cosPhiSinPhi = CosPhi * SinPhi;
                    double tanKsi = Math.Tan(IP.ksi);
                    double sinPhiSinTau = SinPhi * SinTau, cosPhiSinTau = CosPhi * SinTau;
                    double temp1 = (cosPhiSinPhi - CosPhi * CosTau * SinPhi);
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
                        double temp5 = tempY * temp1;
                        double temp6 = tempY * temp3;
                        double temp7 = tempY * tanKsi;

                        for (int pixX = 0; pixX < Ring.SrcImgSize.Width; pixX++)
                        {
                            double tempX = (pixX - centX) * sizeX + temp7;
                            //double x = (tempY * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + tempX * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                            //    * IP.FilmDistance / (tempY * CosPhi * SinTau + IP.FilmDistance - tempX * SinPhi * SinTau);
                            //double y = (x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + tempY * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                            //    * IP.FilmDistance / (tempY * CosPhi * SinTau + IP.FilmDistance - tempX * SinPhi * SinTau);
                            double temp8 = fd / (temp4 - tempX * sinPhiSinTau);
                            double x = (temp5 + tempX * temp2) * temp8;
                            double y = (tempX * temp1 + temp6) * temp8;
                            //double chi = convChi(Math.Atan2(y, x));
                            //double twoTheta = Math.Atan2(Math.Sqrt(x * x + y * y), fd);
                            //Ring.Intensity[i] = Ring.IntensityOriginal[i] / (1 - Math.Cos(chi) * Math.Cos(chi) * Math.Sin(twoTheta) * Math.Sin(twoTheta));
                            double x2 = x * x, y2 = y * y;
                            Ring.Intensity[i] = Ring.IntensityOriginal[i] / coeff(x2, y2);
                            i++;
                        }
                    }
                    this.toolStripStatusLabelComputationTime.Text = "Calculating Time (Polarization Correction):  " + (sw.ElapsedMilliseconds).ToString() + "ms";
                }
                else
                {
                    for (int i = 0; i < Ring.Intensity.Count; i++)
                        Ring.Intensity[i] = Ring.IntensityOriginal[i];
                }
                pseudoBitmap.SrcValuesGray = Ring.Intensity.ToArray();
                scalablePictureBox.drawPictureBox();

                Ring.CalcFreq();
                SetFrequencyProfile();//強度頻度グラフを作成
            }

        }
        */
        #endregion






        public void SetStasticalInformation(bool renewArea=true)
        {
            //矩形の大きさ情報
            int left = Math.Max((int)(scalablePictureBox.AreaRectangle.X + 1), 0);
            int top = Math.Max((int)(scalablePictureBox.AreaRectangle.Y + 1), 0);
            int right = Math.Min((int)(scalablePictureBox.AreaRectangle.X + scalablePictureBox.AreaRectangle.Width), Ring.SrcImgSize.Width - 1);
            int bottom = Math.Min((int)(scalablePictureBox.AreaRectangle.Y + scalablePictureBox.AreaRectangle.Height), Ring.SrcImgSize.Height - 1);

            StringBuilder sb = new StringBuilder();

            List<double> data = new List<double>();
            for (int y = top; y <= bottom; y++)
                for (int x = left; x <= right; x++)
                    data.Add(Ring.Intensity[Ring.SrcImgSize.Width * y + x]);

            if (data.Count == 0)
            {
                textBoxStatisticsSelectedArea.Text = textBoxStatisticsSelectedAreaSequential.Text = "";
                return;
            }
            
            sb.AppendLine("Area:\t" + data.Count.ToString() + " pixels");

            double sumValue = data.Sum();
            sb.AppendLine("Sum:\t" + sumValue.ToString("g9"));

            double averageValue = data.Average();
            sb.AppendLine("Average:\t" + averageValue.ToString("g9"));

            double maxValue = data.Max();
            int maxIndex = data.FindIndex(d1 => d1 == maxValue);

            Point maxValuePoint = new Point(maxIndex % (right - left + 1) + left, maxIndex / (right - left + 1) + top);
            sb.AppendLine("Max.:\t" + maxValue.ToString("g9") + " @ (" + maxValuePoint.X + ", " + maxValuePoint.Y + ")");
            
            double minValue = data.Min();
            int minIndex = data.FindIndex(d1 => d1 == minValue);
            Point minValuePoint = new Point(minIndex % (right - left + 1)+left, minIndex / (right - left + 1)+top);
            sb.AppendLine("Min.:\t" + minValue.ToString("g9") + " @ (" + minValuePoint.X + ", " + minValuePoint.Y + ")");

            double variance = data.Average(d => d * d) - sumValue * sumValue / data.Count / data.Count;
            sb.AppendLine("Variance:\t" + variance.ToString("g9"));

            textBoxStatisticsSelectedArea.Text = sb.ToString();

            if (SequentialImageMode && renewArea)
            {
                List<List<double>> dataList = new List<List<double>>();
                sb = new StringBuilder();
                for (int i = 0; i < Ring.SequentialImageIntensities.Count; i++)
                {
                    dataList.Add(new List<double>());
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
                    sb.AppendLine("#" + i.ToString("000") + "\t" +
                        averageValue.ToString("g6") + "\t" +
                        maxValue.ToString("g6") + "\t" +
                        minValue.ToString("g6") + "\t" +
                        variance.ToString("g6"));


                }
                textBoxStatisticsSelectedAreaSequential.Text = sb.ToString();
            }
        }
        

        bool skipSelectedAreaChangedEvent = false;
        private void numericUpDownSelectedArea_ValueChanged(object sender, EventArgs e)
        {
            if (skipSelectedAreaChangedEvent)
                return;
            double left = Math.Max((double)Math.Min(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value), 0);
            double right =Math.Min( (double)Math.Max(numericUpDownSelectedAreaX1.Value, numericUpDownSelectedAreaX2.Value),Ring.SrcImgSize.Width-1);
            double top = Math.Max((double)Math.Min(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), 0);
            double bottom = Math.Min((double)Math.Max(numericUpDownSelectedAreaY1.Value, numericUpDownSelectedAreaY2.Value), Ring.SrcImgSize.Height - 1);

            scalablePictureBox.AreaRectangle = new RectangleD(left - 0.5, top - 0.5, right - left + 1, bottom - top + 1);
            scalablePictureBox.Refresh();

            SetStasticalInformation(true);


        }

        #region マクロ関連


        public void SetMacroToMenu(string[] name)
        {
            if (macroToolStripMenuItem.DropDownItems.Count == 1)
                macroToolStripMenuItem.DropDownItems.Add(new ToolStripSeparator());
            for (int i = macroToolStripMenuItem.DropDownItems.Count-1; i > 1; i--)
                macroToolStripMenuItem.DropDownItems.RemoveAt(i);


            for (int i = 0; i < name.Length; i++) 
            {
                var item = new ToolStripMenuItem(name[i]);
                item.Name = name[i];
                item.Click += macroMenuItem_Click;
                macroToolStripMenuItem.DropDownItems.Add(item);
            }
        }

        void macroMenuItem_Click(object sender, EventArgs e)
        {
            FormMacro.RunMacroName(((ToolStripMenuItem)sender).Name, false);
        }

        private void ngenCompileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ngen.Compile();
        }

        private void ToolStripMenuItemReferenceBackground_Click(object sender, EventArgs e)
        {
            FormProperty.Visible = true;
            FormProperty.tabControl.SelectedIndex = 9;
        }
        #endregion

        /// <summary>
        /// IPAのマクロ操作を提供する
        /// </summary>
        public class Macro: MacroBase
        {
            private FormMain main;
            public SequentialClass Sequential;
            public DetectorClass Detector;
            public FileClass File;
            public WaveClass Wave;
            public ProfileClass Profile;
            public ImageClass Image;
            public PDIClass PDI;
            public IntegralPropertyClass IntegralProperty;
           

            public Macro(FormMain _main):base(_main,"IPA")
            {
                main = _main;
           
                Sequential = new SequentialClass(this);
                Detector = new DetectorClass(this);
                File = new FileClass(this);
                Wave = new WaveClass(this);
                Profile = new ProfileClass(this);
                Image = new ImageClass(this);
                PDI = new PDIClass(this);
                IntegralProperty = new IntegralPropertyClass(this);
                
            }

            public class PDIClass:MacroSub
            {
                Macro p;
                public PDIClass(Macro _p):base(_p.main)
                {
                    p = _p;
                    p.help.Add("IPA.PDI.RunMacro() # Execute a macro code in PDIndexer.");
                    p.help.Add("IPA.PDI.RunMacroName(string name) # Execute a macro code in PDIndexer. \r\n Name is macro name on PDI.");
                    p.help.Add("IPA.PDI.RunMacro(obj1, obj2, ...)# Execute a macro code in PDIndexer. \r\n Parameters (obj1, obj2,) can be readable \r\n on PDI as 'Obj[1]', 'Obj[2]', ... ");
                    p.help.Add("IPA.PDI.RunMacroName(string name, obj1, obj2, ...) # Execute a macro code in PDIndexer. \r\n Parameters (obj1, obj2,) can be readable \r\n on PDI as 'Obj[1]', 'Obj[2]', ... \r\n Name is macro name on PDI.");
                    p.help.Add("IPA.PDI.Debug #True/False. \r\n If true, macro on PDI will be executed with step-by-step.");
                    p.help.Add("IPA.PDI.WaitSeconds #Integer. \r\n Set/get tolerance time for a macro running on PDIndexer.");
                }
                public bool Debug = false;
                public int WaitSeconds = 120;
                public void RunMacro(params object[] obj)
                {
                    RunMacro("", obj);
                }
                public void RunMacroName(string name, params object[] obj)
                {
                    try
                    {
                        using Mutex clipboard = new Mutex(false, "ClipboardOperation");
                        bool result = clipboard.WaitOne(10000, false);
                        if (result)
                        {
                            Clipboard.SetDataObject(new MacroTriger("PDI", Debug, obj, name));
                            clipboard.ReleaseMutex();
                        }
                        clipboard.Close();
                    }
                    catch { }
                }
            }

            public class ImageClass: MacroSub
            {
                Macro p;
                public ImageClass(Macro _p):base(_p.main)
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

                public bool NegativeGradient { 
                    set { Execute(new Action(() => p.main.comboBoxGradient.SelectedIndex = value ? 1 : 0)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxGradient.SelectedIndex == 1)); }
                }
                public bool PositiveGradient { set {
                    Execute(new Action(()=> p.main.comboBoxGradient.SelectedIndex = value ? 0 : 1)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxGradient.SelectedIndex == 0)); }
                }

                public bool LinearScale
                {
                    set { Execute(new Action(() => p.main.comboBoxScale1.SelectedIndex = value ? 1 : 0)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxScale1.SelectedIndex == 1)); }
                }
                public bool LogScale
                {
                    set { Execute(new Action(() => p.main.comboBoxScale1.SelectedIndex = value ? 0 : 1)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxScale1.SelectedIndex == 0)); }
                }

                public bool GrayScale
                {
                    set { Execute(new Action(() => p.main.comboBoxScale2.SelectedIndex = value ? 1 : 0)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxScale2.SelectedIndex == 1)); }
                }
                public bool ColorScale
                {
                    set { Execute(new Action(() => p.main.comboBoxScale2.SelectedIndex = value ? 0 : 1)); }
                    get { return Execute(new Func<bool>(() => p.main.comboBoxScale2.SelectedIndex == 0)); }
                }

                public double Maximum
                {
                    set
                    {
                        Execute(new Action(() =>
                            p.main.numericUpDownMaxInt.Value = Math.Max(Math.Min(p.main.numericUpDownMaxInt.Maximum, (decimal)value), p.main.numericUpDownMaxInt.Minimum)
                            ));
                    }
                    get { return Execute(new Func<double>(() => (double)p.main.numericUpDownMaxInt.Value)); }
                }
                public double Minimum
                {
                    set
                    {
                        Execute(new Action(() =>
                            p.main.numericUpDownMinInt.Value = Math.Max(Math.Min(p.main.numericUpDownMinInt.Maximum, (decimal)value), p.main.numericUpDownMinInt.Minimum)
                            ));
                    }
                    get { return Execute(new Func<double>(() => (double)p.main.numericUpDownMinInt.Value)); }
                }

                public double CanvasMagnification {
                    set { Execute(new Action(() => p.main.scalablePictureBox.Zoom = value)); } 
                    get { return Execute(new Func<double>(() =>p.main.scalablePictureBox.Zoom)); } }



                public void SetCanvasCenter(double x, double y) { Execute(() => setCanvasCenter(x, y)); }
                private void setCanvasCenter(double x, double y)
                {
                    p.main.scalablePictureBox.Center = new PointD(x, y);    
                }

                public void SetCanvasSize(int width, int height) { Execute(() => setCanvasSize(width, height)); }
                private void setCanvasSize(int width, int height)
                {
                    if (width < 1 || height < 1) return;
                    p.main.splitContainer1.FixedPanel = FixedPanel.Panel2;
                    Size clientSize = p.main.scalablePictureBox.ClientSize;
                    Size mainSize = p.main.Size;
                    Size destSize = new Size(mainSize.Width + width - clientSize.Width, mainSize.Height + height - clientSize.Height);
                    p.main.Size = destSize;
                    p.main.splitContainer1.FixedPanel = FixedPanel.None;
                }

                public void SetArea(double top, double bottom, double left, double right) { Execute(() => setArea(top, bottom, left, right)); }
                private void setArea(double top, double bottom, double left, double right)
                {
                    int width = (int)(CanvasMagnification * (right - left) + 0.5);
                    int height = (int)(CanvasMagnification * (bottom - top) + 0.5);
                    
                    if (width < 1 || height < 1) return;

                    SetCanvasSize(width, height);
                    SetCanvasCenter((left + right) / 2.0, (bottom + top) / 2.0);
                }

                public void SetFullArea() { Execute(() => setFullArea()); }
                private void setFullArea()
                {
                    int width = (int)(CanvasMagnification * p.main.IP.SrcWidth + 0.5);
                    int height = (int)(CanvasMagnification * p.main.IP.SrcHeight + 0.5);

                    if (width < 1 || height < 1) return;

                    SetCanvasSize(width, height);
                    SetCanvasCenter((double)p.main.IP.SrcWidth / 2.0, (double)p.main.IP.SrcHeight / 2.0);
                }

            }

            public class ProfileClass :MacroSub
            {
                Macro p;
                public ProfileClass(Macro _p):base(_p.main)
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
                }

                public bool ConcentricIntegration
                {
                    set => Execute(new Action(() => p.main.toolStripMenuItemConcenctricIntegration.Checked = value));
                    get => Execute(new Func<bool>(() => p.main.toolStripMenuItemConcenctricIntegration.Checked));
                }
                public bool RadialIntegration
                {
                    set => Execute(new Action(() => p.main.toolStripMenuItemRadialIntegration.Checked = value));
                    get => Execute(new Func<bool>(() => p.main.toolStripMenuItemRadialIntegration.Checked));
                }
                public bool FindCenterBeforeGetProfile
                {
                    set => Execute(new Action(() => p.main.findCenterBeforeGetProfileToolStripMenuItem.Checked = value));
                    get => Execute(new Func<bool>(() => p.main.findCenterBeforeGetProfileToolStripMenuItem.Checked));
                }
                public bool FindSpotsBeforeGetProfile
                {
                    set { Execute(new Action(()=>p.main.findSpotsBeforeGetProfileToolStripMenuItem.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.findSpotsBeforeGetProfileToolStripMenuItem.Checked)); }
                }
                public bool SendProfileViaClipboard
                {
                    set {Execute(new Action(()=> p.main.toolStripMenuItemSendProfileToPDIndexer.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.toolStripMenuItemSendProfileToPDIndexer.Checked)); }
                }
                public bool SaveProfileAfterGetProfile
                {
                    set { Execute(new Action(()=>p.main.FormProperty.checkBoxSaveFile.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.FormProperty.checkBoxSaveFile.Checked)); }
                }
                public bool SaveProfileAsPDI
                {
                    set { Execute(new Action(()=>p.main.FormProperty.radioButtonAsPDIformat.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.FormProperty.radioButtonAsPDIformat.Checked)); }
                }
                public bool SaveProfileAsCSV
                {
                    set { Execute(new Action(()=>p.main.FormProperty.radioButtonAsCSVformat.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.FormProperty.radioButtonAsCSVformat.Checked)); }
                }
                public bool SaveProfileAsTSV
                {
                    set => Execute(new Action(() => p.main.FormProperty.radioButtonAsTSVformat.Checked = value));
                    get => Execute(new Func<bool>(() => p.main.FormProperty.radioButtonAsTSVformat.Checked));
                }

                public void GetProfile(string filename = "") { Execute(() => getProfile(filename)); }
                private void getProfile(string filename = "")
                {
                    if (filename != "")
                        SaveProfileAfterGetProfile = true;
                    p.main.GetProfile(filename);
                    using Mutex clipboard = new Mutex(false, "ClipboardOperation");
                    if (clipboard.WaitOne(10000, false))
                    {
                        clipboard.ReleaseMutex();
                        clipboard.Close();
                    }
                }
            }

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
                    set { Execute(new Action(() => p.main.toolStripMenuItemConcenctricIntegration.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.toolStripMenuItemConcenctricIntegration.Checked)); }
                }
                public bool RadialIntegration
                {
                    set { Execute(new Action(() => p.main.toolStripMenuItemRadialIntegration.Checked = value)); }
                    get { return Execute(new Func<bool>(() => p.main.toolStripMenuItemRadialIntegration.Checked)); }
                }
                public double ConcentricStart
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStart.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxConcentricStart.Value)); }
                }
                public double ConcentricEnd
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxConcentricEnd.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxConcentricEnd.Value)); }
                }
                public double ConcentricStep
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxConcentricStep.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxConcentricStep.Value)); }
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
                        return Execute(new Func<int>(() =>
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
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxRadialRadius.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxRadialRadius.Value)); }
                }
                public double RadialWidgh
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxRadialRange.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxRadialRange.Value)); }
                }
                public double RadialStep
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxRadialStep.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxRadialStep.Value)); }
                }

                public int RadialUnit
                {
                    set
                    {
                        Execute(new Action(() =>
                        {
                            switch (value)
                            {
                                case 1: p.main.FormProperty.radioButtonRadialDspacing.Checked = true; break;
                                default: p.main.FormProperty.radioButtonRadialAngle.Checked = true; break;
                            }
                        }));
                    }
                    get
                    {
                        return Execute(new Func<int>(() =>
                         {
                             int i = 0;
                             if (p.main.FormProperty.radioButtonRadialDspacing.Checked) i = 1;
                             return i;
                         }));
                    }
                }
            }

            public class WaveClass:MacroSub
            {
                Macro p;
                public WaveClass(Macro _p):base(_p.main)
                {
                    p = _p;
                    p.help.Add("IPA.Wave.SetWaveLength(float wavelength) # Set wavelength (float value) of incident beam in nm unit.");
                    p.help.Add("IPA.Wave.WaveLength           # Float. \r\n Set/get wavelength of incident beam in nm unit.");

                }

                public void SetWaveLength(double x) { Execute(() => setWaveLength(x)); }
                private void setWaveLength(double x)
                {
                    p.main.FormProperty.WaveLength = x;
                }
                public double WaveLength
                {
                    set { Execute(new Action(() => p.main.FormProperty.WaveLength = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.WaveLength)); }
                }

                public int WaveSource
                {
                    set
                    {
                        Execute(new Action(() =>
                        {
                            p.main.FormProperty.waveLengthControl.WaveSource = value switch
                            {
                                1 => Crystallography.WaveSource.Xray,
                                2 => Crystallography.WaveSource.Electron,
                                3 => Crystallography.WaveSource.Neutron,
                                _ => Crystallography.WaveSource.None,
                            };
                        }));
                    }
                    get
                    {
                        return Execute(new Func<int>(() =>
                        {
                            return p.main.FormProperty.waveLengthControl.WaveSource switch
                            {
                                Crystallography.WaveSource.Xray => 1,
                                Crystallography.WaveSource.Electron => 2,
                                Crystallography.WaveSource.Neutron => 3,
                                _ => 0,
                            };
                        }));
                    }
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
                        }
                    }
                }
            }

            public class FileClass:MacroSub
            {
                Macro p;
                public FileClass(Macro _p):base(_p.main)
                {
                    p = _p;
                    p.help.Add("IPA.File.GetFileName() # Get a file name. \r\n Returned string is a full path of the selected file.");
                    p.help.Add("IPA.File.GetFileNames() # Get file names. \r\n Returned value is a string array, \r\n each of which is a full path of selected files.");
                    p.help.Add("IPA.File.GetDirectoryPath(string filename) # Get a directory path.\r\n Returned string is a full path to the filename.\r\n If filename is omitted, selection dialog will open.");

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

                public string GetDirectoryPath(string filename = "") { return Execute(new Func<string>(() => getDirectoryPath(filename))); }
                private string getDirectoryPath(string filename = "")
                {
                    string path = "";
                    if (filename == "")
                    {
                        var dlg = new FolderBrowserDialog();
                        path = dlg.ShowDialog() == DialogResult.OK ? dlg.SelectedPath : "";
                    }
                    else
                        path = System.IO.Path.GetDirectoryName(filename);
                    return path + "\\";
                }


                public string GetFileName() { return Execute(new Func<string>(() => getFileName())); }
                private string getFileName()
                {
                    var dlg = new OpenFileDialog();
                    return dlg.ShowDialog() == DialogResult.OK ? dlg.FileName : "";
                }


                public string[] GetFileNames() { return Execute(new Func<string[]>(() => getFileNames())); }
                private string[] getFileNames()
                {
                    var dlg = new OpenFileDialog();
                    dlg.Multiselect = true;
                    return dlg.ShowDialog() == DialogResult.OK ? dlg.FileNames : new string[0];
                }


                public void SaveImageAsTIFF(string fileName="")
                {
                    Execute(() =>
                        p.main.saveImageAsTiff(fileName)
                    );
                }
                public void SaveImageAsPNG(string fileName = "")
                {
                    Execute(() =>
                        p.main.saveImageAsPng(fileName)
                    );
                }

                public void SaveImageAsIPA(string fileName = "")
                {
                    Execute(() =>
                        p.main.FormSaveImage.SaveImageAsIPA(fileName)
                    );
                }


                public void ReadImageHDF(string _fileName, bool? flag)
                {
                    Execute(() =>
                        p.main.ReadImage(_fileName, flag)
                        );
                }

                /// <summary>
                /// Read image file. if filename is omitted, dialog will open.
                /// </summary>
                /// <param name="_fileName"></param>
                public void ReadImage(string _fileName = "", bool? flag = null) { Execute(() => readImage(_fileName, flag)); }
                private void readImage(string _fileName = "", bool? flag=null)
                {
                    if (!System.IO.File.Exists(_fileName))
                        p.main.readImageToolStripMenuItem_Click(new object(), new EventArgs());
                    else
                        p.main.ReadImage(_fileName, flag);
                }


                public void SaveImage(string _fileName = "") { Execute(() => saveImage(_fileName)); }
                private void saveImage(string _fileName="")
                {
                    string fileName = _fileName;
                    if (_fileName == "")
                    {
                        SaveFileDialog dlg = new SaveFileDialog();
                        dlg.Filter = "*.tif|";
                        if (dlg.ShowDialog() == DialogResult.OK)
                            fileName = dlg.FileName;
                    }
                }

                /// <summary>
                /// Read parameter file.
                /// </summary>
                /// <param name="_fileName"></param>
                public void ReadParameter(string _fileName = "") { Execute(() => readParameter(_fileName)); }
                private void readParameter(string _fileName = "")
                {
                    string fileName = _fileName;
                    if (_fileName == "")
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        if (dlg.ShowDialog() == DialogResult.OK)
                            fileName = dlg.FileName;
                    }
                    p.main.ReadParameter(fileName);
                }

                public void SaveParameter(string _fileName = "") { Execute(() => saveParameter(_fileName)); }
                private void saveParameter(string _fileName = "")
                {
                    string fileName = _fileName;
                    if (_fileName == "")
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        if (dlg.ShowDialog() == DialogResult.OK)
                            fileName = dlg.FileName;
                    }
                    if (!fileName.EndsWith("prm"))
                        fileName += ".prm";
                    p.main.SaveParameter(fileName);
                }


                public void SaveMask(string _fileName = "") { Execute(() => saveMask(_fileName)); }
                private void saveMask(string _fileName = "")
                {
                    string fileName = _fileName;
                    if (_fileName == "")
                    {
                        OpenFileDialog dlg = new OpenFileDialog();
                        if (dlg.ShowDialog() == DialogResult.OK)
                            fileName = dlg.FileName;
                    }
                    if (!fileName.EndsWith("mas"))
                        fileName += ".mas";
                    p.main.SaveMask(fileName);
                }

            }

            public class SequentialClass:MacroSub
            {
                Macro p;
                public SequentialClass(Macro _p):base(_p.main)
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

                }

                public bool SequentialImageMode => Execute(new Func<bool>(() => p.main.SequentialImageMode));
                public int SelectedIndex
                {
                    set => Execute(new Action(() => p.main.FormSequentialImage.SelectedIndex = value));
                    get => Execute(new Func<int>(() => p.main.FormSequentialImage.SelectedIndex));
                }

                public int Count => Execute(new Func<int>(() => p.main.FormSequentialImage.MaximumNumber));

                public int[] SelectedIndices
                {
                    set {Execute(new Action(() =>  p.main.FormSequentialImage.SelectedIndices = value)); }
                    get { return Execute(new Func<int[]>(() => p.main.FormSequentialImage.SelectedIndices)); }
                }

                public bool MultiSelection
                {
                    set { Execute(new Action(() => p.main.FormSequentialImage.MultiSelection = value)); }
                    get { return Execute(new Func<bool>(() => p.main.FormSequentialImage.MultiSelection)); }
                }
                public bool Averaging
                {
                    set { Execute(new Action(() => p.main.FormSequentialImage.AverageMode = value)); }
                    get { return Execute(new Func<bool>(() => p.main.FormSequentialImage.AverageMode)); }
                }

                /// <summary>
                /// 選択する
                /// </summary>
                /// <param name="n"></param>
                public void SelectIndex(int n) { Execute(() => selectIndex(n)); }
                private void selectIndex(int n)
                {
                    if (!SequentialImageMode) return;
                    MultiSelection = false;
                    p.main.FormSequentialImage.SelectedIndex = n;
                }
                /// <summary>
                /// 選択を追加する
                /// </summary>
                /// <param name="n"></param>
                public void AppendIndex(int n) { Execute(() => appendIndex(n)); }
                private void appendIndex(int n)
                {
                    if (!SequentialImageMode) return;
                    if (n >= 0 && n < p.main.FormSequentialImage.MaximumNumber)
                    {
                        MultiSelection = true;
                        p.main.FormSequentialImage.SelectedIndex = n;
                    }
                }
                /// <summary>
                /// 範囲を選択する
                /// </summary>
                /// <param name="start"></param>
                /// <param name="end"></param>
                public void SelectIndices(int start, int end) { Execute(() => selectIndices(start,end)); }
                private void selectIndices(int start, int end)
                {
                    if (!SequentialImageMode) return;
                    if (start < end && start >= 0 && end < p.main.FormSequentialImage.MaximumNumber)
                    {
                        MultiSelection = true;
                        List<int> list = new List<int>();
                        for (int i = start; i <= end; i++)
                            if (!list.Contains(i))
                                list.Add(i);
                        p.main.FormSequentialImage.SelectedIndices = list.ToArray();
                    //    SelectedIndex = end;
                    }
                }
                /// <summary>
                /// 範囲を追加する
                /// </summary>
                /// <param name="start"></param>
                /// <param name="end"></param>
                public void AppendIndices(int start, int end) { Execute(() => appendIndices(start, end)); }
                private void appendIndices(int start, int end)
                {
                    if (!SequentialImageMode) return;
                    if (start < end && start >= 0 && end < p.main.FormSequentialImage.MaximumNumber)
                    {
                        MultiSelection = true;
                        List<int> list = new List<int>(p.main.FormSequentialImage.SelectedIndices);
                        for (int i = start; i <= end; i++)
                            if (!list.Contains(i))
                                list.Add(i);
                        p.main.FormSequentialImage.SelectedIndices = list.ToArray();
                        SelectedIndex = end;
                    }
                }

            }


            public class DetectorClass:MacroSub
            {
                Macro p;
                public DetectorClass(Macro _p):base(_p.main)
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


                public void SetCenter(double x, double y) { Execute(() => setCenter(x, y)); }
                private void setCenter(double x, double y)
                {
                    p.main.FormProperty.ImageCenter = new PointD(x, y);
                }

                public void SetCameraLength(double x) { Execute(() => setCameraLength(x)); }
                private void setCameraLength(double x)
                {
                    p.main.FormProperty.CameraLength = x;
                }

                public double CenterX
                {
                    set {Execute(new Action(() =>  p.main.FormProperty.ImageCenter = new PointD(value, p.main.FormProperty.ImageCenter.Y))); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.ImageCenter.X)); }
                }
                public double CenterY
                {
                    set { Execute(new Action(() => p.main.FormProperty.ImageCenter = new PointD(p.main.FormProperty.ImageCenter.X, value))); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.ImageCenter.Y)); }
                }
                public double CameraLength
                {
                    set { Execute(new Action(() => p.main.FormProperty.CameraLength = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.CameraLength)); }
                }
                public double PixelSizeX
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeX.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxPixelSizeX.Value)); }
                }
                public double PixelSizeY
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxPixelSizeY.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxPixelSizeY.Value)); }
                }
                public double PixelKsi
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericalTextBoxPixelKsi.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericalTextBoxPixelKsi.Value)); }
                }
                public double TiltPhi
                {
                    set {Execute(new Action(() =>  p.main.FormProperty.numericBoxTiltCorrectionPhi.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxTiltCorrectionPhi.Value)); }
                }
                public double TiltTau
                {
                    set { Execute(new Action(() => p.main.FormProperty.numericBoxTiltCorrectionTau.Value = value)); }
                    get { return Execute(new Func<double>(() => p.main.FormProperty.numericBoxTiltCorrectionTau.Value)); }
                }



            }

        }

     

        private void process1_Exited(object sender, EventArgs e)
        {

        }

        private void editorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMacro.Visible = true;
        }



      


    }
}
