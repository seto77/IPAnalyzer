namespace IPAnalyzer;
using System.ComponentModel;
using System.Windows.Forms;

/// <summary>
/// FormCLandWL の概要の説明です。
/// </summary>
partial class FormFindParameter : System.Windows.Forms.Form
{
    /// <summary>
    /// 必要なデザイナ変数です。
    /// </summary>
    private System.ComponentModel.IContainer components = null;


    /// <summary>
    /// 使用されているリソースに後処理を実行します。
    /// </summary>
    protected override void Dispose(bool disposing)
    {
        if (disposing)
        {
            if (components != null)
            {
                components.Dispose();
            }
        }
        if(BmpMain!=null)
        BmpMain.Dispose();
        base.Dispose(disposing);
    }

    #region Windows フォーム デザイナで生成されたコード
    /// <summary>
    /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
    /// コード エディタで変更しないでください。
    /// </summary>
    private void InitializeComponent()
    {
        components = new Container();
        ComponentResourceManager resources = new ComponentResourceManager(typeof(FormFindParameter));
        DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle11 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle12 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle13 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
        DataGridViewCellStyle dataGridViewCellStyle14 = new DataGridViewCellStyle();
        label1 = new Label();
        label7 = new Label();
        label14 = new Label();
        label19 = new Label();
        label24 = new Label();
        label25 = new Label();
        label26 = new Label();
        numericUpDownBandWidth = new NumericUpDown();
        label28 = new Label();
        numericUpDownSearchRange = new NumericUpDown();
        label11 = new Label();
        label27 = new Label();
        checkBoxUseStandardCrystal = new CheckBox();
        label38 = new Label();
        label36 = new Label();
        label46 = new Label();
        label48 = new Label();
        groupBoxPrimaryImage = new GroupBox();
        numericBoxPrimaryImageNum = new Crystallography.Controls.NumericBox();
        numericTextBoxPrimaryCenterPositionY = new Crystallography.Controls.NumericBox();
        numericTextBoxPrimaryFilmDistance = new Crystallography.Controls.NumericBox();
        numericalTextBoxPrimaryCenterPositionX = new Crystallography.Controls.NumericBox();
        label9 = new Label();
        pictureBoxPattern1 = new PictureBox();
        label2 = new Label();
        label43 = new Label();
        label10 = new Label();
        label51 = new Label();
        buttonGetCenterPositionFromMainForm = new Button();
        buttonPrimaryGetProfile = new Button();
        buttonClearPrimaryImage = new Button();
        buttonOpenPrimaryImage = new Button();
        numericalTextBoxPrimaryCenterPositionYDev = new Crystallography.Controls.NumericBox();
        numericalTextBoxPrimaryCenterPositionXDev = new Crystallography.Controls.NumericBox();
        textBoxPrimaryFileName = new TextBox();
        label23 = new Label();
        label53 = new Label();
        groupBoxSecondaryImage = new GroupBox();
        numericBoxSecondaryImageNum = new Crystallography.Controls.NumericBox();
        numericTextBoxSecondaryCenterPositionY = new Crystallography.Controls.NumericBox();
        buttonOpenSecondaryImage = new Button();
        numericTextBoxSecondaryCenterPositionX = new Crystallography.Controls.NumericBox();
        textBoxSecondaryFileName = new TextBox();
        textBoxFilmDistanceDiscrepancy = new Crystallography.Controls.NumericBox();
        textBoxPrimaryFilmDistanceCopy = new Crystallography.Controls.NumericBox();
        pictureBoxPattern2 = new PictureBox();
        label54 = new Label();
        label5 = new Label();
        label55 = new Label();
        buttonGetCenterPositionFromMainForm2 = new Button();
        buttonClearSecondaryImage = new Button();
        buttonSecondaryGetProfile = new Button();
        numericTextBoxSecondaryCenterPositionYDev = new Crystallography.Controls.NumericBox();
        numericTextBoxSecondaryCenterPositionXDev = new Crystallography.Controls.NumericBox();
        label4 = new Label();
        label56 = new Label();
        label31 = new Label();
        label3 = new Label();
        label58 = new Label();
        label29 = new Label();
        checkBoxRefineTiltCorrection = new CheckBox();
        checkBoxRefinePixelSize = new CheckBox();
        checkBoxRefineFilmDistance = new CheckBox();
        checkBoxRefineWaveLength = new CheckBox();
        label18 = new Label();
        label35 = new Label();
        label40 = new Label();
        groupBoxOption = new GroupBox();
        buttonSchematicDiagram = new Button();
        buttonClearGraphs = new Button();
        buttonSetStandardCrystal = new Button();
        checkBoxRefinePixelDistortion = new CheckBox();
        buttonExecuteRefinements = new Button();
        checkBoxSphericalCorrection = new CheckBox();
        checkBoxCenterPosition = new CheckBox();
        numericUpDownRepitition = new NumericUpDown();
        checkBoxPeakDecomposition = new CheckBox();
        checkBoxMouseOperation = new CheckBox();
        checkBoxRefleshMainform = new CheckBox();
        numericUpDownThresholdOfPeak = new NumericUpDown();
        numericUpDownDivision = new NumericUpDown();
        label45 = new Label();
        label21 = new Label();
        label73 = new Label();
        label67 = new Label();
        label82 = new Label();
        label17 = new Label();
        radioButtonRectangle = new RadioButton();
        radioButtonSector = new RadioButton();
        buttonStopRefinements = new Button();
        buttonSetInitioalParam = new Button();
        buttonSendMainForm = new Button();
        groupBoxParameter = new GroupBox();
        textBoxPixelKsi = new Crystallography.Controls.NumericBox();
        textBoxTiltCorrectionSecondaryTau = new Crystallography.Controls.NumericBox();
        textBoxTiltCorrectionPrimaryTau = new Crystallography.Controls.NumericBox();
        numericalTextBoxSphericalRadius = new Crystallography.Controls.NumericBox();
        textBoxTiltCorrectionSecondaryPhi = new Crystallography.Controls.NumericBox();
        textBoxTiltCorrectionPrimaryPhi = new Crystallography.Controls.NumericBox();
        textBoxRefinedPixelKsiDev = new Crystallography.Controls.NumericBox();
        label68 = new Label();
        buttonCopyToClipboard = new Button();
        label34 = new Label();
        textBoxWaveLengthDev = new Crystallography.Controls.NumericBox();
        textBoxRefinedPixelKsi = new Crystallography.Controls.NumericBox();
        label15 = new Label();
        label32 = new Label();
        label70 = new Label();
        textBoxPrimaryFilmDistanceCopy2 = new Crystallography.Controls.NumericBox();
        numericalTextBoxRadiusInverseDev = new Crystallography.Controls.NumericBox();
        textBoxRefinedSecondaryTauDev = new Crystallography.Controls.NumericBox();
        textBoxPixelSizeYDev = new Crystallography.Controls.NumericBox();
        textBoxWaveLength = new Crystallography.Controls.NumericBox();
        textBoxRefinedPixelSizeY = new Crystallography.Controls.NumericBox();
        textBoxRefinedPrimaryTauDev = new Crystallography.Controls.NumericBox();
        textBoxPixelSizeY = new Crystallography.Controls.NumericBox();
        textBoxRefinedSecondaryPhiDev = new Crystallography.Controls.NumericBox();
        label41 = new Label();
        textBoxRefinedPrimaryFilmDistance = new Crystallography.Controls.NumericBox();
        label13 = new Label();
        textBoxRefinedPrimaryPhiDev = new Crystallography.Controls.NumericBox();
        textBoxPixelSizeX = new Crystallography.Controls.NumericBox();
        textBoxRefinedWaveLength = new Crystallography.Controls.NumericBox();
        textBoxRefinedPixelSizeX = new Crystallography.Controls.NumericBox();
        numericalTextBoxRefinedSphericalRadius = new Crystallography.Controls.NumericBox();
        textBoxRefinedSecondaryTau = new Crystallography.Controls.NumericBox();
        label20 = new Label();
        textBoxPixelSizeXDev = new Crystallography.Controls.NumericBox();
        textBoxRefinedPrimaryTau = new Crystallography.Controls.NumericBox();
        label44 = new Label();
        label6 = new Label();
        label69 = new Label();
        label33 = new Label();
        label63 = new Label();
        label39 = new Label();
        label81 = new Label();
        label62 = new Label();
        textBoxCameraLengthDev = new Crystallography.Controls.NumericBox();
        label22 = new Label();
        textBoxRefinedSecondaryPhi = new Crystallography.Controls.NumericBox();
        label42 = new Label();
        textBoxRefinedPrimaryPhi = new Crystallography.Controls.NumericBox();
        label61 = new Label();
        label49 = new Label();
        label30 = new Label();
        label66 = new Label();
        label65 = new Label();
        label64 = new Label();
        label75 = new Label();
        label71 = new Label();
        backgroundWorkerRefine = new BackgroundWorker();
        flowLayoutPanel1 = new FlowLayoutPanel();
        radioButton1 = new RadioButton();
        radioButton2 = new RadioButton();
        buttonGetWaveLengthFromWholePattern = new Button();
        buttonGetCameraLenghtFromWholePattern = new Button();
        dataGridView = new DataGridView();
        ColumnNo = new DataGridViewTextBoxColumn();
        ColumnHKL = new DataGridViewTextBoxColumn();
        ColumnPrimaryCheck = new DataGridViewCheckBoxColumn();
        ColumnPrimary = new DataGridViewTextBoxColumn();
        contextMenuStrip1 = new ContextMenuStrip(components);
        checkUncheckToolStripMenuItem = new ToolStripMenuItem();
        ColumnSecondaryCheck = new DataGridViewCheckBoxColumn();
        ColumnSecondary = new DataGridViewTextBoxColumn();
        pictureBoxMain = new PictureBox();
        pictureBoxPixelKsi = new PictureBox();
        pictureBoxPixelSizeY = new PictureBox();
        pictureBoxPixelSizeX = new PictureBox();
        pictureBoxTiltCorrectionTau2 = new PictureBox();
        pictureBoxTiltCorrectionTau1 = new PictureBox();
        pictureBoxTiltCorrectionPhi2 = new PictureBox();
        pictureBoxTiltCorrectionPhi1 = new PictureBox();
        pictureBoxCameraLength = new PictureBox();
        pictureBoxResidual = new PictureBox();
        pictureBoxWaveLength = new PictureBox();
        pictureBoxTiltCorrection2 = new PictureBox();
        pictureBoxTiltCorrection1 = new PictureBox();
        label74 = new Label();
        label80 = new Label();
        label57 = new Label();
        label60 = new Label();
        label79 = new Label();
        label72 = new Label();
        label37 = new Label();
        label76 = new Label();
        label16 = new Label();
        label8 = new Label();
        label78 = new Label();
        label77 = new Label();
        label47 = new Label();
        label59 = new Label();
        label50 = new Label();
        label52 = new Label();
        toolTipJapanese = new ToolTip(components);
        statusStrip1 = new StatusStrip();
        toolStripProgressBar1 = new ToolStripProgressBar();
        toolStripStatusLabel1 = new ToolStripStatusLabel();
        groupBoxPeakList = new GroupBox();
        buttonCheckPeaks = new Button();
        numericBoxAwayFrom = new Crystallography.Controls.NumericBox();
        numericBoxLowerThan = new Crystallography.Controls.NumericBox();
        panel1 = new Panel();
        flowLayoutPanelEachPeaks = new FlowLayoutPanel();
        checkBoxShowEachPeaks = new CheckBox();
        ((ISupportInitialize)numericUpDownBandWidth).BeginInit();
        ((ISupportInitialize)numericUpDownSearchRange).BeginInit();
        groupBoxPrimaryImage.SuspendLayout();
        ((ISupportInitialize)pictureBoxPattern1).BeginInit();
        groupBoxSecondaryImage.SuspendLayout();
        ((ISupportInitialize)pictureBoxPattern2).BeginInit();
        groupBoxOption.SuspendLayout();
        ((ISupportInitialize)numericUpDownRepitition).BeginInit();
        ((ISupportInitialize)numericUpDownThresholdOfPeak).BeginInit();
        ((ISupportInitialize)numericUpDownDivision).BeginInit();
        groupBoxParameter.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        ((ISupportInitialize)dataGridView).BeginInit();
        contextMenuStrip1.SuspendLayout();
        ((ISupportInitialize)pictureBoxMain).BeginInit();
        ((ISupportInitialize)pictureBoxPixelKsi).BeginInit();
        ((ISupportInitialize)pictureBoxPixelSizeY).BeginInit();
        ((ISupportInitialize)pictureBoxPixelSizeX).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionTau2).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionTau1).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionPhi2).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionPhi1).BeginInit();
        ((ISupportInitialize)pictureBoxCameraLength).BeginInit();
        ((ISupportInitialize)pictureBoxResidual).BeginInit();
        ((ISupportInitialize)pictureBoxWaveLength).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrection2).BeginInit();
        ((ISupportInitialize)pictureBoxTiltCorrection1).BeginInit();
        statusStrip1.SuspendLayout();
        groupBoxPeakList.SuspendLayout();
        panel1.SuspendLayout();
        SuspendLayout();
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
        label1.Name = "label1";
        // 
        // label7
        // 
        resources.ApplyResources(label7, "label7");
        label7.Name = "label7";
        // 
        // label14
        // 
        resources.ApplyResources(label14, "label14");
        label14.Name = "label14";
        // 
        // label19
        // 
        resources.ApplyResources(label19, "label19");
        label19.Name = "label19";
        // 
        // label24
        // 
        resources.ApplyResources(label24, "label24");
        label24.Name = "label24";
        // 
        // label25
        // 
        resources.ApplyResources(label25, "label25");
        label25.Name = "label25";
        // 
        // label26
        // 
        resources.ApplyResources(label26, "label26");
        label26.Name = "label26";
        // 
        // numericUpDownBandWidth
        // 
        resources.ApplyResources(numericUpDownBandWidth, "numericUpDownBandWidth");
        numericUpDownBandWidth.Name = "numericUpDownBandWidth";
        toolTipJapanese.SetToolTip(numericUpDownBandWidth, resources.GetString("numericUpDownBandWidth.ToolTip"));
        numericUpDownBandWidth.Value = new decimal(new int[] { 4, 0, 0, 0 });
        // 
        // label28
        // 
        resources.ApplyResources(label28, "label28");
        label28.BackColor = System.Drawing.SystemColors.Control;
        label28.Name = "label28";
        // 
        // numericUpDownSearchRange
        // 
        numericUpDownSearchRange.DecimalPlaces = 2;
        resources.ApplyResources(numericUpDownSearchRange, "numericUpDownSearchRange");
        numericUpDownSearchRange.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
        numericUpDownSearchRange.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
        numericUpDownSearchRange.Minimum = new decimal(new int[] { 1, 0, 0, 65536 });
        numericUpDownSearchRange.Name = "numericUpDownSearchRange";
        toolTipJapanese.SetToolTip(numericUpDownSearchRange, resources.GetString("numericUpDownSearchRange.ToolTip"));
        numericUpDownSearchRange.Value = new decimal(new int[] { 8, 0, 0, 65536 });
        numericUpDownSearchRange.ValueChanged += numericUpDownSearchRange_ValueChanged;
        // 
        // label11
        // 
        resources.ApplyResources(label11, "label11");
        label11.Name = "label11";
        // 
        // label27
        // 
        resources.ApplyResources(label27, "label27");
        label27.Name = "label27";
        // 
        // checkBoxUseStandardCrystal
        // 
        resources.ApplyResources(checkBoxUseStandardCrystal, "checkBoxUseStandardCrystal");
        checkBoxUseStandardCrystal.Checked = true;
        checkBoxUseStandardCrystal.CheckState = CheckState.Checked;
        checkBoxUseStandardCrystal.Name = "checkBoxUseStandardCrystal";
        toolTipJapanese.SetToolTip(checkBoxUseStandardCrystal, resources.GetString("checkBoxUseStandardCrystal.ToolTip"));
        checkBoxUseStandardCrystal.CheckedChanged += checkBoxShowCrystalParameter_CheckedChanged;
        // 
        // label38
        // 
        resources.ApplyResources(label38, "label38");
        label38.Name = "label38";
        // 
        // label36
        // 
        resources.ApplyResources(label36, "label36");
        label36.Name = "label36";
        // 
        // label46
        // 
        resources.ApplyResources(label46, "label46");
        label46.Name = "label46";
        // 
        // label48
        // 
        resources.ApplyResources(label48, "label48");
        label48.Name = "label48";
        // 
        // groupBoxPrimaryImage
        // 
        groupBoxPrimaryImage.Controls.Add(numericBoxPrimaryImageNum);
        groupBoxPrimaryImage.Controls.Add(numericTextBoxPrimaryCenterPositionY);
        groupBoxPrimaryImage.Controls.Add(numericTextBoxPrimaryFilmDistance);
        groupBoxPrimaryImage.Controls.Add(numericalTextBoxPrimaryCenterPositionX);
        groupBoxPrimaryImage.Controls.Add(label9);
        groupBoxPrimaryImage.Controls.Add(pictureBoxPattern1);
        groupBoxPrimaryImage.Controls.Add(label2);
        groupBoxPrimaryImage.Controls.Add(label43);
        groupBoxPrimaryImage.Controls.Add(label10);
        groupBoxPrimaryImage.Controls.Add(label51);
        groupBoxPrimaryImage.Controls.Add(buttonGetCenterPositionFromMainForm);
        groupBoxPrimaryImage.Controls.Add(buttonPrimaryGetProfile);
        groupBoxPrimaryImage.Controls.Add(buttonClearPrimaryImage);
        groupBoxPrimaryImage.Controls.Add(buttonOpenPrimaryImage);
        groupBoxPrimaryImage.Controls.Add(numericalTextBoxPrimaryCenterPositionYDev);
        groupBoxPrimaryImage.Controls.Add(numericalTextBoxPrimaryCenterPositionXDev);
        groupBoxPrimaryImage.Controls.Add(textBoxPrimaryFileName);
        groupBoxPrimaryImage.Controls.Add(label23);
        groupBoxPrimaryImage.Controls.Add(label53);
        groupBoxPrimaryImage.Controls.Add(label26);
        resources.ApplyResources(groupBoxPrimaryImage, "groupBoxPrimaryImage");
        groupBoxPrimaryImage.Name = "groupBoxPrimaryImage";
        groupBoxPrimaryImage.TabStop = false;
        groupBoxPrimaryImage.DragDrop += groupBoxPrimaryImage_DragDrop;
        groupBoxPrimaryImage.DragEnter += groupBoxPrimaryImage_DragEnter;
        // 
        // numericBoxPrimaryImageNum
        // 
        resources.ApplyResources(numericBoxPrimaryImageNum, "numericBoxPrimaryImageNum");
        numericBoxPrimaryImageNum.BackColor = System.Drawing.SystemColors.Control;
        numericBoxPrimaryImageNum.FooterBackColor = System.Drawing.SystemColors.Control;
        numericBoxPrimaryImageNum.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericBoxPrimaryImageNum.Name = "numericBoxPrimaryImageNum";
        numericBoxPrimaryImageNum.RoundErrorAccuracy = -1;
        numericBoxPrimaryImageNum.SkipEventDuringInput = false;
        numericBoxPrimaryImageNum.SmartIncrement = true;
        numericBoxPrimaryImageNum.ThonsandsSeparator = true;
        // 
        // numericTextBoxPrimaryCenterPositionY
        // 
        resources.ApplyResources(numericTextBoxPrimaryCenterPositionY, "numericTextBoxPrimaryCenterPositionY");
        numericTextBoxPrimaryCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryCenterPositionY.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryCenterPositionY.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryCenterPositionY.Name = "numericTextBoxPrimaryCenterPositionY";
        numericTextBoxPrimaryCenterPositionY.RoundErrorAccuracy = -1;
        numericTextBoxPrimaryCenterPositionY.SkipEventDuringInput = false;
        numericTextBoxPrimaryCenterPositionY.SmartIncrement = true;
        numericTextBoxPrimaryCenterPositionY.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(numericTextBoxPrimaryCenterPositionY, resources.GetString("numericTextBoxPrimaryCenterPositionY.ToolTip"));
        numericTextBoxPrimaryCenterPositionY.ValueChanged += textBox_TextChanged;
        numericTextBoxPrimaryCenterPositionY.DoubleClick += textBoxPrimaryCenterPositionX_DoubleClick;
        // 
        // numericTextBoxPrimaryFilmDistance
        // 
        resources.ApplyResources(numericTextBoxPrimaryFilmDistance, "numericTextBoxPrimaryFilmDistance");
        numericTextBoxPrimaryFilmDistance.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryFilmDistance.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryFilmDistance.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxPrimaryFilmDistance.Name = "numericTextBoxPrimaryFilmDistance";
        numericTextBoxPrimaryFilmDistance.RoundErrorAccuracy = -1;
        numericTextBoxPrimaryFilmDistance.SkipEventDuringInput = false;
        numericTextBoxPrimaryFilmDistance.SmartIncrement = true;
        numericTextBoxPrimaryFilmDistance.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(numericTextBoxPrimaryFilmDistance, resources.GetString("numericTextBoxPrimaryFilmDistance.ToolTip"));
        numericTextBoxPrimaryFilmDistance.ValueChanged += numericTextBoxPrimaryFilmDistance_TextChanged;
        // 
        // numericalTextBoxPrimaryCenterPositionX
        // 
        resources.ApplyResources(numericalTextBoxPrimaryCenterPositionX, "numericalTextBoxPrimaryCenterPositionX");
        numericalTextBoxPrimaryCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionX.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionX.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionX.Name = "numericalTextBoxPrimaryCenterPositionX";
        numericalTextBoxPrimaryCenterPositionX.RoundErrorAccuracy = -1;
        numericalTextBoxPrimaryCenterPositionX.SkipEventDuringInput = false;
        numericalTextBoxPrimaryCenterPositionX.SmartIncrement = true;
        numericalTextBoxPrimaryCenterPositionX.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(numericalTextBoxPrimaryCenterPositionX, resources.GetString("numericalTextBoxPrimaryCenterPositionX.ToolTip"));
        numericalTextBoxPrimaryCenterPositionX.ValueChanged += textBox_TextChanged;
        numericalTextBoxPrimaryCenterPositionX.DoubleClick += textBoxPrimaryCenterPositionX_DoubleClick;
        // 
        // label9
        // 
        resources.ApplyResources(label9, "label9");
        label9.Name = "label9";
        // 
        // pictureBoxPattern1
        // 
        pictureBoxPattern1.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
        pictureBoxPattern1.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxPattern1, "pictureBoxPattern1");
        pictureBoxPattern1.Name = "pictureBoxPattern1";
        pictureBoxPattern1.TabStop = false;
        pictureBoxPattern1.Click += pictureBoxPattern1_Click;
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
        label2.Name = "label2";
        // 
        // label43
        // 
        resources.ApplyResources(label43, "label43");
        label43.Name = "label43";
        // 
        // label10
        // 
        resources.ApplyResources(label10, "label10");
        label10.Name = "label10";
        // 
        // label51
        // 
        resources.ApplyResources(label51, "label51");
        label51.Name = "label51";
        // 
        // buttonGetCenterPositionFromMainForm
        // 
        resources.ApplyResources(buttonGetCenterPositionFromMainForm, "buttonGetCenterPositionFromMainForm");
        buttonGetCenterPositionFromMainForm.Name = "buttonGetCenterPositionFromMainForm";
        buttonGetCenterPositionFromMainForm.UseVisualStyleBackColor = true;
        buttonGetCenterPositionFromMainForm.Click += textBoxPrimaryCenterPositionX_DoubleClick;
        // 
        // buttonPrimaryGetProfile
        // 
        resources.ApplyResources(buttonPrimaryGetProfile, "buttonPrimaryGetProfile");
        buttonPrimaryGetProfile.Name = "buttonPrimaryGetProfile";
        toolTipJapanese.SetToolTip(buttonPrimaryGetProfile, resources.GetString("buttonPrimaryGetProfile.ToolTip"));
        buttonPrimaryGetProfile.UseVisualStyleBackColor = true;
        buttonPrimaryGetProfile.Click += buttonPrimaryGetProfile_Click;
        // 
        // buttonClearPrimaryImage
        // 
        resources.ApplyResources(buttonClearPrimaryImage, "buttonClearPrimaryImage");
        buttonClearPrimaryImage.Name = "buttonClearPrimaryImage";
        buttonClearPrimaryImage.UseVisualStyleBackColor = true;
        buttonClearPrimaryImage.Click += buttonClearPrimaryImage_Click;
        // 
        // buttonOpenPrimaryImage
        // 
        resources.ApplyResources(buttonOpenPrimaryImage, "buttonOpenPrimaryImage");
        buttonOpenPrimaryImage.Name = "buttonOpenPrimaryImage";
        toolTipJapanese.SetToolTip(buttonOpenPrimaryImage, resources.GetString("buttonOpenPrimaryImage.ToolTip"));
        buttonOpenPrimaryImage.UseVisualStyleBackColor = true;
        buttonOpenPrimaryImage.Click += buttonOpenPrimaryImage_Click;
        // 
        // numericalTextBoxPrimaryCenterPositionYDev
        // 
        resources.ApplyResources(numericalTextBoxPrimaryCenterPositionYDev, "numericalTextBoxPrimaryCenterPositionYDev");
        numericalTextBoxPrimaryCenterPositionYDev.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionYDev.DecimalPlaces = 10;
        numericalTextBoxPrimaryCenterPositionYDev.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionYDev.Name = "numericalTextBoxPrimaryCenterPositionYDev";
        numericalTextBoxPrimaryCenterPositionYDev.ReadOnly = true;
        numericalTextBoxPrimaryCenterPositionYDev.RoundErrorAccuracy = -1;
        numericalTextBoxPrimaryCenterPositionYDev.SkipEventDuringInput = false;
        numericalTextBoxPrimaryCenterPositionYDev.SmartIncrement = true;
        numericalTextBoxPrimaryCenterPositionYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionYDev.ThonsandsSeparator = true;
        numericalTextBoxPrimaryCenterPositionYDev.WordWrap = false;
        // 
        // numericalTextBoxPrimaryCenterPositionXDev
        // 
        resources.ApplyResources(numericalTextBoxPrimaryCenterPositionXDev, "numericalTextBoxPrimaryCenterPositionXDev");
        numericalTextBoxPrimaryCenterPositionXDev.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionXDev.DecimalPlaces = 10;
        numericalTextBoxPrimaryCenterPositionXDev.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionXDev.Name = "numericalTextBoxPrimaryCenterPositionXDev";
        numericalTextBoxPrimaryCenterPositionXDev.ReadOnly = true;
        numericalTextBoxPrimaryCenterPositionXDev.RoundErrorAccuracy = -1;
        numericalTextBoxPrimaryCenterPositionXDev.SkipEventDuringInput = false;
        numericalTextBoxPrimaryCenterPositionXDev.SmartIncrement = true;
        numericalTextBoxPrimaryCenterPositionXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxPrimaryCenterPositionXDev.ThonsandsSeparator = true;
        numericalTextBoxPrimaryCenterPositionXDev.WordWrap = false;
        // 
        // textBoxPrimaryFileName
        // 
        resources.ApplyResources(textBoxPrimaryFileName, "textBoxPrimaryFileName");
        textBoxPrimaryFileName.Name = "textBoxPrimaryFileName";
        textBoxPrimaryFileName.ReadOnly = true;
        toolTipJapanese.SetToolTip(textBoxPrimaryFileName, resources.GetString("textBoxPrimaryFileName.ToolTip"));
        textBoxPrimaryFileName.TextChanged += textBoxPrimaryFileName_TextChanged;
        // 
        // label23
        // 
        resources.ApplyResources(label23, "label23");
        label23.Name = "label23";
        // 
        // label53
        // 
        resources.ApplyResources(label53, "label53");
        label53.Name = "label53";
        // 
        // groupBoxSecondaryImage
        // 
        groupBoxSecondaryImage.Controls.Add(numericBoxSecondaryImageNum);
        groupBoxSecondaryImage.Controls.Add(numericTextBoxSecondaryCenterPositionY);
        groupBoxSecondaryImage.Controls.Add(buttonOpenSecondaryImage);
        groupBoxSecondaryImage.Controls.Add(numericTextBoxSecondaryCenterPositionX);
        groupBoxSecondaryImage.Controls.Add(textBoxSecondaryFileName);
        groupBoxSecondaryImage.Controls.Add(textBoxFilmDistanceDiscrepancy);
        groupBoxSecondaryImage.Controls.Add(textBoxPrimaryFilmDistanceCopy);
        groupBoxSecondaryImage.Controls.Add(pictureBoxPattern2);
        groupBoxSecondaryImage.Controls.Add(label54);
        groupBoxSecondaryImage.Controls.Add(label5);
        groupBoxSecondaryImage.Controls.Add(label55);
        groupBoxSecondaryImage.Controls.Add(buttonGetCenterPositionFromMainForm2);
        groupBoxSecondaryImage.Controls.Add(buttonClearSecondaryImage);
        groupBoxSecondaryImage.Controls.Add(buttonSecondaryGetProfile);
        groupBoxSecondaryImage.Controls.Add(numericTextBoxSecondaryCenterPositionYDev);
        groupBoxSecondaryImage.Controls.Add(numericTextBoxSecondaryCenterPositionXDev);
        groupBoxSecondaryImage.Controls.Add(label4);
        groupBoxSecondaryImage.Controls.Add(label56);
        groupBoxSecondaryImage.Controls.Add(label31);
        groupBoxSecondaryImage.Controls.Add(label3);
        groupBoxSecondaryImage.Controls.Add(label58);
        groupBoxSecondaryImage.Controls.Add(label29);
        resources.ApplyResources(groupBoxSecondaryImage, "groupBoxSecondaryImage");
        groupBoxSecondaryImage.Name = "groupBoxSecondaryImage";
        groupBoxSecondaryImage.TabStop = false;
        groupBoxSecondaryImage.DragDrop += groupBoxSecondaryImage_DragDrop;
        groupBoxSecondaryImage.DragEnter += groupBoxSecondaryImage_DragEnter;
        // 
        // numericBoxSecondaryImageNum
        // 
        resources.ApplyResources(numericBoxSecondaryImageNum, "numericBoxSecondaryImageNum");
        numericBoxSecondaryImageNum.BackColor = System.Drawing.SystemColors.Control;
        numericBoxSecondaryImageNum.FooterBackColor = System.Drawing.SystemColors.Control;
        numericBoxSecondaryImageNum.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericBoxSecondaryImageNum.Name = "numericBoxSecondaryImageNum";
        numericBoxSecondaryImageNum.RoundErrorAccuracy = -1;
        numericBoxSecondaryImageNum.SkipEventDuringInput = false;
        numericBoxSecondaryImageNum.SmartIncrement = true;
        numericBoxSecondaryImageNum.ThonsandsSeparator = true;
        // 
        // numericTextBoxSecondaryCenterPositionY
        // 
        resources.ApplyResources(numericTextBoxSecondaryCenterPositionY, "numericTextBoxSecondaryCenterPositionY");
        numericTextBoxSecondaryCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionY.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionY.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionY.Name = "numericTextBoxSecondaryCenterPositionY";
        numericTextBoxSecondaryCenterPositionY.RoundErrorAccuracy = -1;
        numericTextBoxSecondaryCenterPositionY.SkipEventDuringInput = false;
        numericTextBoxSecondaryCenterPositionY.SmartIncrement = true;
        numericTextBoxSecondaryCenterPositionY.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(numericTextBoxSecondaryCenterPositionY, resources.GetString("numericTextBoxSecondaryCenterPositionY.ToolTip"));
        numericTextBoxSecondaryCenterPositionY.ValueChanged += textBox_TextChanged;
        numericTextBoxSecondaryCenterPositionY.DoubleClick += textBoxSecondaryCenterPositionX_DoubleClick;
        // 
        // buttonOpenSecondaryImage
        // 
        resources.ApplyResources(buttonOpenSecondaryImage, "buttonOpenSecondaryImage");
        buttonOpenSecondaryImage.Name = "buttonOpenSecondaryImage";
        toolTipJapanese.SetToolTip(buttonOpenSecondaryImage, resources.GetString("buttonOpenSecondaryImage.ToolTip"));
        buttonOpenSecondaryImage.UseVisualStyleBackColor = true;
        buttonOpenSecondaryImage.Click += buttonOpenSecondaryImage_Click;
        // 
        // numericTextBoxSecondaryCenterPositionX
        // 
        resources.ApplyResources(numericTextBoxSecondaryCenterPositionX, "numericTextBoxSecondaryCenterPositionX");
        numericTextBoxSecondaryCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionX.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionX.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionX.Name = "numericTextBoxSecondaryCenterPositionX";
        numericTextBoxSecondaryCenterPositionX.RoundErrorAccuracy = -1;
        numericTextBoxSecondaryCenterPositionX.SkipEventDuringInput = false;
        numericTextBoxSecondaryCenterPositionX.SmartIncrement = true;
        numericTextBoxSecondaryCenterPositionX.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(numericTextBoxSecondaryCenterPositionX, resources.GetString("numericTextBoxSecondaryCenterPositionX.ToolTip"));
        numericTextBoxSecondaryCenterPositionX.ValueChanged += textBox_TextChanged;
        numericTextBoxSecondaryCenterPositionX.DoubleClick += textBoxSecondaryCenterPositionX_DoubleClick;
        // 
        // textBoxSecondaryFileName
        // 
        resources.ApplyResources(textBoxSecondaryFileName, "textBoxSecondaryFileName");
        textBoxSecondaryFileName.Name = "textBoxSecondaryFileName";
        textBoxSecondaryFileName.ReadOnly = true;
        textBoxSecondaryFileName.TextChanged += textBoxSecondaryFileName_TextChanged;
        // 
        // textBoxFilmDistanceDiscrepancy
        // 
        resources.ApplyResources(textBoxFilmDistanceDiscrepancy, "textBoxFilmDistanceDiscrepancy");
        textBoxFilmDistanceDiscrepancy.BackColor = System.Drawing.SystemColors.Control;
        textBoxFilmDistanceDiscrepancy.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxFilmDistanceDiscrepancy.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxFilmDistanceDiscrepancy.Name = "textBoxFilmDistanceDiscrepancy";
        textBoxFilmDistanceDiscrepancy.RadianValue = 1.7453292519943295D;
        textBoxFilmDistanceDiscrepancy.RoundErrorAccuracy = -1;
        textBoxFilmDistanceDiscrepancy.SkipEventDuringInput = false;
        textBoxFilmDistanceDiscrepancy.SmartIncrement = true;
        textBoxFilmDistanceDiscrepancy.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxFilmDistanceDiscrepancy, resources.GetString("textBoxFilmDistanceDiscrepancy.ToolTip"));
        textBoxFilmDistanceDiscrepancy.Value = 100D;
        textBoxFilmDistanceDiscrepancy.WordWrap = false;
        textBoxFilmDistanceDiscrepancy.ValueChanged += textBoxFilmDistanceDiscrepancy_TextChanged;
        textBoxFilmDistanceDiscrepancy.TextChanged += textBoxFilmDistanceDiscrepancy_TextChanged;
        // 
        // textBoxPrimaryFilmDistanceCopy
        // 
        resources.ApplyResources(textBoxPrimaryFilmDistanceCopy, "textBoxPrimaryFilmDistanceCopy");
        textBoxPrimaryFilmDistanceCopy.BackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy.Name = "textBoxPrimaryFilmDistanceCopy";
        textBoxPrimaryFilmDistanceCopy.RadianValue = 7.7667151713747664D;
        textBoxPrimaryFilmDistanceCopy.ReadOnly = true;
        textBoxPrimaryFilmDistanceCopy.RoundErrorAccuracy = -1;
        textBoxPrimaryFilmDistanceCopy.SkipEventDuringInput = false;
        textBoxPrimaryFilmDistanceCopy.SmartIncrement = true;
        textBoxPrimaryFilmDistanceCopy.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy.ThonsandsSeparator = true;
        textBoxPrimaryFilmDistanceCopy.Value = 445D;
        textBoxPrimaryFilmDistanceCopy.WordWrap = false;
        // 
        // pictureBoxPattern2
        // 
        pictureBoxPattern2.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
        pictureBoxPattern2.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxPattern2, "pictureBoxPattern2");
        pictureBoxPattern2.Name = "pictureBoxPattern2";
        pictureBoxPattern2.TabStop = false;
        pictureBoxPattern2.Click += pictureBoxPattern2_Click;
        // 
        // label54
        // 
        resources.ApplyResources(label54, "label54");
        label54.Name = "label54";
        // 
        // label5
        // 
        resources.ApplyResources(label5, "label5");
        label5.Name = "label5";
        // 
        // label55
        // 
        resources.ApplyResources(label55, "label55");
        label55.Name = "label55";
        // 
        // buttonGetCenterPositionFromMainForm2
        // 
        resources.ApplyResources(buttonGetCenterPositionFromMainForm2, "buttonGetCenterPositionFromMainForm2");
        buttonGetCenterPositionFromMainForm2.Name = "buttonGetCenterPositionFromMainForm2";
        buttonGetCenterPositionFromMainForm2.UseVisualStyleBackColor = true;
        buttonGetCenterPositionFromMainForm2.Click += textBoxSecondaryCenterPositionX_DoubleClick;
        // 
        // buttonClearSecondaryImage
        // 
        resources.ApplyResources(buttonClearSecondaryImage, "buttonClearSecondaryImage");
        buttonClearSecondaryImage.Name = "buttonClearSecondaryImage";
        buttonClearSecondaryImage.UseVisualStyleBackColor = true;
        buttonClearSecondaryImage.Click += buttonClearSecondaryImage_Click;
        // 
        // buttonSecondaryGetProfile
        // 
        resources.ApplyResources(buttonSecondaryGetProfile, "buttonSecondaryGetProfile");
        buttonSecondaryGetProfile.Name = "buttonSecondaryGetProfile";
        toolTipJapanese.SetToolTip(buttonSecondaryGetProfile, resources.GetString("buttonSecondaryGetProfile.ToolTip"));
        buttonSecondaryGetProfile.UseVisualStyleBackColor = true;
        buttonSecondaryGetProfile.Click += buttonSecondaryGetProfile_Click;
        // 
        // numericTextBoxSecondaryCenterPositionYDev
        // 
        resources.ApplyResources(numericTextBoxSecondaryCenterPositionYDev, "numericTextBoxSecondaryCenterPositionYDev");
        numericTextBoxSecondaryCenterPositionYDev.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionYDev.DecimalPlaces = 10;
        numericTextBoxSecondaryCenterPositionYDev.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionYDev.Name = "numericTextBoxSecondaryCenterPositionYDev";
        numericTextBoxSecondaryCenterPositionYDev.ReadOnly = true;
        numericTextBoxSecondaryCenterPositionYDev.RoundErrorAccuracy = -1;
        numericTextBoxSecondaryCenterPositionYDev.SkipEventDuringInput = false;
        numericTextBoxSecondaryCenterPositionYDev.SmartIncrement = true;
        numericTextBoxSecondaryCenterPositionYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionYDev.ThonsandsSeparator = true;
        numericTextBoxSecondaryCenterPositionYDev.WordWrap = false;
        // 
        // numericTextBoxSecondaryCenterPositionXDev
        // 
        resources.ApplyResources(numericTextBoxSecondaryCenterPositionXDev, "numericTextBoxSecondaryCenterPositionXDev");
        numericTextBoxSecondaryCenterPositionXDev.BackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionXDev.DecimalPlaces = 10;
        numericTextBoxSecondaryCenterPositionXDev.FooterBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionXDev.Name = "numericTextBoxSecondaryCenterPositionXDev";
        numericTextBoxSecondaryCenterPositionXDev.ReadOnly = true;
        numericTextBoxSecondaryCenterPositionXDev.RoundErrorAccuracy = -1;
        numericTextBoxSecondaryCenterPositionXDev.SkipEventDuringInput = false;
        numericTextBoxSecondaryCenterPositionXDev.SmartIncrement = true;
        numericTextBoxSecondaryCenterPositionXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericTextBoxSecondaryCenterPositionXDev.ThonsandsSeparator = true;
        numericTextBoxSecondaryCenterPositionXDev.WordWrap = false;
        // 
        // label4
        // 
        resources.ApplyResources(label4, "label4");
        label4.Name = "label4";
        // 
        // label56
        // 
        resources.ApplyResources(label56, "label56");
        label56.Name = "label56";
        // 
        // label31
        // 
        resources.ApplyResources(label31, "label31");
        label31.Name = "label31";
        // 
        // label3
        // 
        resources.ApplyResources(label3, "label3");
        label3.Name = "label3";
        // 
        // label58
        // 
        resources.ApplyResources(label58, "label58");
        label58.Name = "label58";
        // 
        // label29
        // 
        resources.ApplyResources(label29, "label29");
        label29.Name = "label29";
        // 
        // checkBoxRefineTiltCorrection
        // 
        resources.ApplyResources(checkBoxRefineTiltCorrection, "checkBoxRefineTiltCorrection");
        checkBoxRefineTiltCorrection.Checked = true;
        checkBoxRefineTiltCorrection.CheckState = CheckState.Checked;
        checkBoxRefineTiltCorrection.Name = "checkBoxRefineTiltCorrection";
        toolTipJapanese.SetToolTip(checkBoxRefineTiltCorrection, resources.GetString("checkBoxRefineTiltCorrection.ToolTip"));
        checkBoxRefineTiltCorrection.UseVisualStyleBackColor = true;
        checkBoxRefineTiltCorrection.CheckedChanged += checkBoxRefineTiltCorrection_CheckedChanged;
        // 
        // checkBoxRefinePixelSize
        // 
        resources.ApplyResources(checkBoxRefinePixelSize, "checkBoxRefinePixelSize");
        checkBoxRefinePixelSize.Checked = true;
        checkBoxRefinePixelSize.CheckState = CheckState.Checked;
        checkBoxRefinePixelSize.Name = "checkBoxRefinePixelSize";
        toolTipJapanese.SetToolTip(checkBoxRefinePixelSize, resources.GetString("checkBoxRefinePixelSize.ToolTip"));
        checkBoxRefinePixelSize.UseVisualStyleBackColor = true;
        checkBoxRefinePixelSize.CheckedChanged += checkBoxRefinePixelSize_CheckedChanged;
        // 
        // checkBoxRefineFilmDistance
        // 
        resources.ApplyResources(checkBoxRefineFilmDistance, "checkBoxRefineFilmDistance");
        checkBoxRefineFilmDistance.Checked = true;
        checkBoxRefineFilmDistance.CheckState = CheckState.Checked;
        checkBoxRefineFilmDistance.Name = "checkBoxRefineFilmDistance";
        toolTipJapanese.SetToolTip(checkBoxRefineFilmDistance, resources.GetString("checkBoxRefineFilmDistance.ToolTip"));
        checkBoxRefineFilmDistance.UseVisualStyleBackColor = true;
        // 
        // checkBoxRefineWaveLength
        // 
        resources.ApplyResources(checkBoxRefineWaveLength, "checkBoxRefineWaveLength");
        checkBoxRefineWaveLength.Checked = true;
        checkBoxRefineWaveLength.CheckState = CheckState.Checked;
        checkBoxRefineWaveLength.Name = "checkBoxRefineWaveLength";
        toolTipJapanese.SetToolTip(checkBoxRefineWaveLength, resources.GetString("checkBoxRefineWaveLength.ToolTip"));
        checkBoxRefineWaveLength.UseVisualStyleBackColor = true;
        // 
        // label18
        // 
        resources.ApplyResources(label18, "label18");
        label18.Name = "label18";
        // 
        // label35
        // 
        resources.ApplyResources(label35, "label35");
        label35.Name = "label35";
        // 
        // label40
        // 
        resources.ApplyResources(label40, "label40");
        label40.Name = "label40";
        // 
        // groupBoxOption
        // 
        groupBoxOption.Controls.Add(buttonSchematicDiagram);
        groupBoxOption.Controls.Add(buttonClearGraphs);
        groupBoxOption.Controls.Add(buttonSetStandardCrystal);
        groupBoxOption.Controls.Add(checkBoxRefinePixelDistortion);
        groupBoxOption.Controls.Add(buttonExecuteRefinements);
        groupBoxOption.Controls.Add(checkBoxRefinePixelSize);
        groupBoxOption.Controls.Add(checkBoxSphericalCorrection);
        groupBoxOption.Controls.Add(checkBoxCenterPosition);
        groupBoxOption.Controls.Add(checkBoxRefineTiltCorrection);
        groupBoxOption.Controls.Add(checkBoxRefineFilmDistance);
        groupBoxOption.Controls.Add(checkBoxRefineWaveLength);
        groupBoxOption.Controls.Add(numericUpDownRepitition);
        groupBoxOption.Controls.Add(checkBoxPeakDecomposition);
        groupBoxOption.Controls.Add(checkBoxMouseOperation);
        groupBoxOption.Controls.Add(checkBoxRefleshMainform);
        groupBoxOption.Controls.Add(checkBoxUseStandardCrystal);
        groupBoxOption.Controls.Add(numericUpDownThresholdOfPeak);
        groupBoxOption.Controls.Add(numericUpDownDivision);
        groupBoxOption.Controls.Add(numericUpDownBandWidth);
        groupBoxOption.Controls.Add(label45);
        groupBoxOption.Controls.Add(label21);
        groupBoxOption.Controls.Add(label28);
        groupBoxOption.Controls.Add(label27);
        groupBoxOption.Controls.Add(label73);
        groupBoxOption.Controls.Add(numericUpDownSearchRange);
        groupBoxOption.Controls.Add(label11);
        groupBoxOption.Controls.Add(label67);
        groupBoxOption.Controls.Add(label82);
        groupBoxOption.Controls.Add(label17);
        groupBoxOption.Controls.Add(radioButtonRectangle);
        groupBoxOption.Controls.Add(radioButtonSector);
        resources.ApplyResources(groupBoxOption, "groupBoxOption");
        groupBoxOption.Name = "groupBoxOption";
        groupBoxOption.TabStop = false;
        // 
        // buttonSchematicDiagram
        // 
        resources.ApplyResources(buttonSchematicDiagram, "buttonSchematicDiagram");
        buttonSchematicDiagram.Name = "buttonSchematicDiagram";
        toolTipJapanese.SetToolTip(buttonSchematicDiagram, resources.GetString("buttonSchematicDiagram.ToolTip"));
        buttonSchematicDiagram.UseVisualStyleBackColor = true;
        buttonSchematicDiagram.Click += buttonSchematicDiagram_Click;
        // 
        // buttonClearGraphs
        // 
        resources.ApplyResources(buttonClearGraphs, "buttonClearGraphs");
        buttonClearGraphs.Name = "buttonClearGraphs";
        toolTipJapanese.SetToolTip(buttonClearGraphs, resources.GetString("buttonClearGraphs.ToolTip"));
        buttonClearGraphs.Click += buttonClearGraphs_Click;
        // 
        // buttonSetStandardCrystal
        // 
        resources.ApplyResources(buttonSetStandardCrystal, "buttonSetStandardCrystal");
        buttonSetStandardCrystal.Name = "buttonSetStandardCrystal";
        buttonSetStandardCrystal.Click += buttonSetStandardCrystal_Click;
        // 
        // checkBoxRefinePixelDistortion
        // 
        resources.ApplyResources(checkBoxRefinePixelDistortion, "checkBoxRefinePixelDistortion");
        checkBoxRefinePixelDistortion.Checked = true;
        checkBoxRefinePixelDistortion.CheckState = CheckState.Checked;
        checkBoxRefinePixelDistortion.Name = "checkBoxRefinePixelDistortion";
        toolTipJapanese.SetToolTip(checkBoxRefinePixelDistortion, resources.GetString("checkBoxRefinePixelDistortion.ToolTip"));
        checkBoxRefinePixelDistortion.UseVisualStyleBackColor = true;
        // 
        // buttonExecuteRefinements
        // 
        buttonExecuteRefinements.BackColor = System.Drawing.Color.SteelBlue;
        resources.ApplyResources(buttonExecuteRefinements, "buttonExecuteRefinements");
        buttonExecuteRefinements.ForeColor = System.Drawing.SystemColors.ButtonFace;
        buttonExecuteRefinements.Name = "buttonExecuteRefinements";
        toolTipJapanese.SetToolTip(buttonExecuteRefinements, resources.GetString("buttonExecuteRefinements.ToolTip"));
        buttonExecuteRefinements.UseVisualStyleBackColor = false;
        buttonExecuteRefinements.Click += buttonExecuteRefinements_Click;
        // 
        // checkBoxSphericalCorrection
        // 
        resources.ApplyResources(checkBoxSphericalCorrection, "checkBoxSphericalCorrection");
        checkBoxSphericalCorrection.Name = "checkBoxSphericalCorrection";
        toolTipJapanese.SetToolTip(checkBoxSphericalCorrection, resources.GetString("checkBoxSphericalCorrection.ToolTip"));
        checkBoxSphericalCorrection.UseVisualStyleBackColor = true;
        // 
        // checkBoxCenterPosition
        // 
        resources.ApplyResources(checkBoxCenterPosition, "checkBoxCenterPosition");
        checkBoxCenterPosition.Checked = true;
        checkBoxCenterPosition.CheckState = CheckState.Checked;
        checkBoxCenterPosition.Name = "checkBoxCenterPosition";
        toolTipJapanese.SetToolTip(checkBoxCenterPosition, resources.GetString("checkBoxCenterPosition.ToolTip"));
        checkBoxCenterPosition.UseVisualStyleBackColor = true;
        // 
        // numericUpDownRepitition
        // 
        resources.ApplyResources(numericUpDownRepitition, "numericUpDownRepitition");
        numericUpDownRepitition.Name = "numericUpDownRepitition";
        toolTipJapanese.SetToolTip(numericUpDownRepitition, resources.GetString("numericUpDownRepitition.ToolTip"));
        numericUpDownRepitition.Value = new decimal(new int[] { 12, 0, 0, 0 });
        // 
        // checkBoxPeakDecomposition
        // 
        resources.ApplyResources(checkBoxPeakDecomposition, "checkBoxPeakDecomposition");
        checkBoxPeakDecomposition.Name = "checkBoxPeakDecomposition";
        checkBoxPeakDecomposition.CheckedChanged += checkBoxShowCrystalParameter_CheckedChanged;
        // 
        // checkBoxMouseOperation
        // 
        resources.ApplyResources(checkBoxMouseOperation, "checkBoxMouseOperation");
        checkBoxMouseOperation.Name = "checkBoxMouseOperation";
        toolTipJapanese.SetToolTip(checkBoxMouseOperation, resources.GetString("checkBoxMouseOperation.ToolTip"));
        // 
        // checkBoxRefleshMainform
        // 
        resources.ApplyResources(checkBoxRefleshMainform, "checkBoxRefleshMainform");
        checkBoxRefleshMainform.Checked = true;
        checkBoxRefleshMainform.CheckState = CheckState.Checked;
        checkBoxRefleshMainform.Name = "checkBoxRefleshMainform";
        toolTipJapanese.SetToolTip(checkBoxRefleshMainform, resources.GetString("checkBoxRefleshMainform.ToolTip"));
        // 
        // numericUpDownThresholdOfPeak
        // 
        numericUpDownThresholdOfPeak.DecimalPlaces = 2;
        resources.ApplyResources(numericUpDownThresholdOfPeak, "numericUpDownThresholdOfPeak");
        numericUpDownThresholdOfPeak.Increment = new decimal(new int[] { 5, 0, 0, 131072 });
        numericUpDownThresholdOfPeak.Maximum = new decimal(new int[] { 1, 0, 0, 0 });
        numericUpDownThresholdOfPeak.Name = "numericUpDownThresholdOfPeak";
        toolTipJapanese.SetToolTip(numericUpDownThresholdOfPeak, resources.GetString("numericUpDownThresholdOfPeak.ToolTip"));
        numericUpDownThresholdOfPeak.ValueChanged += numericUpDownThresholdOfPeak_ValueChanged;
        // 
        // numericUpDownDivision
        // 
        resources.ApplyResources(numericUpDownDivision, "numericUpDownDivision");
        numericUpDownDivision.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
        numericUpDownDivision.Minimum = new decimal(new int[] { 8, 0, 0, 0 });
        numericUpDownDivision.Name = "numericUpDownDivision";
        numericUpDownDivision.Value = new decimal(new int[] { 18, 0, 0, 0 });
        // 
        // label45
        // 
        resources.ApplyResources(label45, "label45");
        label45.BackColor = System.Drawing.SystemColors.Control;
        label45.Name = "label45";
        // 
        // label21
        // 
        resources.ApplyResources(label21, "label21");
        label21.BackColor = System.Drawing.SystemColors.Control;
        label21.Name = "label21";
        // 
        // label73
        // 
        resources.ApplyResources(label73, "label73");
        label73.Name = "label73";
        // 
        // label67
        // 
        resources.ApplyResources(label67, "label67");
        label67.Name = "label67";
        // 
        // label82
        // 
        resources.ApplyResources(label82, "label82");
        label82.Name = "label82";
        // 
        // label17
        // 
        resources.ApplyResources(label17, "label17");
        label17.Name = "label17";
        // 
        // radioButtonRectangle
        // 
        resources.ApplyResources(radioButtonRectangle, "radioButtonRectangle");
        radioButtonRectangle.Name = "radioButtonRectangle";
        radioButtonRectangle.UseVisualStyleBackColor = true;
        // 
        // radioButtonSector
        // 
        resources.ApplyResources(radioButtonSector, "radioButtonSector");
        radioButtonSector.Checked = true;
        radioButtonSector.Name = "radioButtonSector";
        radioButtonSector.TabStop = true;
        radioButtonSector.UseVisualStyleBackColor = true;
        // 
        // buttonStopRefinements
        // 
        buttonStopRefinements.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
        resources.ApplyResources(buttonStopRefinements, "buttonStopRefinements");
        buttonStopRefinements.ForeColor = System.Drawing.Color.White;
        buttonStopRefinements.Name = "buttonStopRefinements";
        toolTipJapanese.SetToolTip(buttonStopRefinements, resources.GetString("buttonStopRefinements.ToolTip"));
        buttonStopRefinements.UseVisualStyleBackColor = false;
        buttonStopRefinements.Click += buttonStopRefinements_Click;
        // 
        // buttonSetInitioalParam
        // 
        resources.ApplyResources(buttonSetInitioalParam, "buttonSetInitioalParam");
        buttonSetInitioalParam.Name = "buttonSetInitioalParam";
        buttonSetInitioalParam.Click += buttonSetInitioalParam_Click;
        // 
        // buttonSendMainForm
        // 
        resources.ApplyResources(buttonSendMainForm, "buttonSendMainForm");
        buttonSendMainForm.Name = "buttonSendMainForm";
        buttonSendMainForm.Click += buttonSendMainForm_Click;
        // 
        // groupBoxParameter
        // 
        groupBoxParameter.Controls.Add(textBoxPixelKsi);
        groupBoxParameter.Controls.Add(textBoxTiltCorrectionSecondaryTau);
        groupBoxParameter.Controls.Add(textBoxTiltCorrectionPrimaryTau);
        groupBoxParameter.Controls.Add(numericalTextBoxSphericalRadius);
        groupBoxParameter.Controls.Add(textBoxTiltCorrectionSecondaryPhi);
        groupBoxParameter.Controls.Add(textBoxTiltCorrectionPrimaryPhi);
        groupBoxParameter.Controls.Add(textBoxRefinedPixelKsiDev);
        groupBoxParameter.Controls.Add(buttonSetInitioalParam);
        groupBoxParameter.Controls.Add(label68);
        groupBoxParameter.Controls.Add(buttonCopyToClipboard);
        groupBoxParameter.Controls.Add(buttonSendMainForm);
        groupBoxParameter.Controls.Add(label34);
        groupBoxParameter.Controls.Add(textBoxWaveLengthDev);
        groupBoxParameter.Controls.Add(textBoxRefinedPixelKsi);
        groupBoxParameter.Controls.Add(label15);
        groupBoxParameter.Controls.Add(label32);
        groupBoxParameter.Controls.Add(label70);
        groupBoxParameter.Controls.Add(textBoxPrimaryFilmDistanceCopy2);
        groupBoxParameter.Controls.Add(numericalTextBoxRadiusInverseDev);
        groupBoxParameter.Controls.Add(textBoxRefinedSecondaryTauDev);
        groupBoxParameter.Controls.Add(textBoxPixelSizeYDev);
        groupBoxParameter.Controls.Add(textBoxWaveLength);
        groupBoxParameter.Controls.Add(textBoxRefinedPixelSizeY);
        groupBoxParameter.Controls.Add(textBoxRefinedPrimaryTauDev);
        groupBoxParameter.Controls.Add(textBoxPixelSizeY);
        groupBoxParameter.Controls.Add(label1);
        groupBoxParameter.Controls.Add(label40);
        groupBoxParameter.Controls.Add(textBoxRefinedSecondaryPhiDev);
        groupBoxParameter.Controls.Add(label41);
        groupBoxParameter.Controls.Add(textBoxRefinedPrimaryFilmDistance);
        groupBoxParameter.Controls.Add(label13);
        groupBoxParameter.Controls.Add(label19);
        groupBoxParameter.Controls.Add(textBoxRefinedPrimaryPhiDev);
        groupBoxParameter.Controls.Add(textBoxPixelSizeX);
        groupBoxParameter.Controls.Add(label46);
        groupBoxParameter.Controls.Add(textBoxRefinedWaveLength);
        groupBoxParameter.Controls.Add(textBoxRefinedPixelSizeX);
        groupBoxParameter.Controls.Add(numericalTextBoxRefinedSphericalRadius);
        groupBoxParameter.Controls.Add(textBoxRefinedSecondaryTau);
        groupBoxParameter.Controls.Add(label24);
        groupBoxParameter.Controls.Add(label20);
        groupBoxParameter.Controls.Add(textBoxPixelSizeXDev);
        groupBoxParameter.Controls.Add(textBoxRefinedPrimaryTau);
        groupBoxParameter.Controls.Add(label44);
        groupBoxParameter.Controls.Add(label35);
        groupBoxParameter.Controls.Add(label6);
        groupBoxParameter.Controls.Add(label69);
        groupBoxParameter.Controls.Add(label33);
        groupBoxParameter.Controls.Add(label63);
        groupBoxParameter.Controls.Add(label48);
        groupBoxParameter.Controls.Add(label39);
        groupBoxParameter.Controls.Add(label7);
        groupBoxParameter.Controls.Add(label81);
        groupBoxParameter.Controls.Add(label62);
        groupBoxParameter.Controls.Add(label38);
        groupBoxParameter.Controls.Add(textBoxCameraLengthDev);
        groupBoxParameter.Controls.Add(label14);
        groupBoxParameter.Controls.Add(label22);
        groupBoxParameter.Controls.Add(label25);
        groupBoxParameter.Controls.Add(textBoxRefinedSecondaryPhi);
        groupBoxParameter.Controls.Add(label42);
        groupBoxParameter.Controls.Add(textBoxRefinedPrimaryPhi);
        groupBoxParameter.Controls.Add(label36);
        groupBoxParameter.Controls.Add(label61);
        groupBoxParameter.Controls.Add(label49);
        groupBoxParameter.Controls.Add(label30);
        groupBoxParameter.Controls.Add(label66);
        groupBoxParameter.Controls.Add(label65);
        groupBoxParameter.Controls.Add(label64);
        groupBoxParameter.Controls.Add(label75);
        groupBoxParameter.Controls.Add(label71);
        groupBoxParameter.Controls.Add(label18);
        resources.ApplyResources(groupBoxParameter, "groupBoxParameter");
        groupBoxParameter.Name = "groupBoxParameter";
        groupBoxParameter.TabStop = false;
        groupBoxParameter.DragDrop += groupBoxParameter_DragDrop;
        groupBoxParameter.DragEnter += groupBoxParameter_DragEnter;
        // 
        // textBoxPixelKsi
        // 
        resources.ApplyResources(textBoxPixelKsi, "textBoxPixelKsi");
        textBoxPixelKsi.BackColor = System.Drawing.SystemColors.Control;
        textBoxPixelKsi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelKsi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelKsi.Name = "textBoxPixelKsi";
        textBoxPixelKsi.RoundErrorAccuracy = -1;
        textBoxPixelKsi.SkipEventDuringInput = false;
        textBoxPixelKsi.SmartIncrement = true;
        textBoxPixelKsi.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxPixelKsi, resources.GetString("textBoxPixelKsi.ToolTip"));
        textBoxPixelKsi.WordWrap = false;
        textBoxPixelKsi.TextChanged += textBox_TextChanged;
        textBoxPixelKsi.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxTiltCorrectionSecondaryTau
        // 
        resources.ApplyResources(textBoxTiltCorrectionSecondaryTau, "textBoxTiltCorrectionSecondaryTau");
        textBoxTiltCorrectionSecondaryTau.BackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryTau.Name = "textBoxTiltCorrectionSecondaryTau";
        textBoxTiltCorrectionSecondaryTau.RoundErrorAccuracy = -1;
        textBoxTiltCorrectionSecondaryTau.SkipEventDuringInput = false;
        textBoxTiltCorrectionSecondaryTau.SmartIncrement = true;
        textBoxTiltCorrectionSecondaryTau.ThonsandsSeparator = true;
        textBoxTiltCorrectionSecondaryTau.WordWrap = false;
        textBoxTiltCorrectionSecondaryTau.TextChanged += textBox_TextChanged;
        textBoxTiltCorrectionSecondaryTau.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxTiltCorrectionPrimaryTau
        // 
        resources.ApplyResources(textBoxTiltCorrectionPrimaryTau, "textBoxTiltCorrectionPrimaryTau");
        textBoxTiltCorrectionPrimaryTau.BackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryTau.Name = "textBoxTiltCorrectionPrimaryTau";
        textBoxTiltCorrectionPrimaryTau.RoundErrorAccuracy = -1;
        textBoxTiltCorrectionPrimaryTau.SkipEventDuringInput = false;
        textBoxTiltCorrectionPrimaryTau.SmartIncrement = true;
        textBoxTiltCorrectionPrimaryTau.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxTiltCorrectionPrimaryTau, resources.GetString("textBoxTiltCorrectionPrimaryTau.ToolTip"));
        textBoxTiltCorrectionPrimaryTau.WordWrap = false;
        textBoxTiltCorrectionPrimaryTau.TextChanged += textBox_TextChanged;
        textBoxTiltCorrectionPrimaryTau.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // numericalTextBoxSphericalRadius
        // 
        resources.ApplyResources(numericalTextBoxSphericalRadius, "numericalTextBoxSphericalRadius");
        numericalTextBoxSphericalRadius.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxSphericalRadius.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxSphericalRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxSphericalRadius.Name = "numericalTextBoxSphericalRadius";
        numericalTextBoxSphericalRadius.RoundErrorAccuracy = -1;
        numericalTextBoxSphericalRadius.SkipEventDuringInput = false;
        numericalTextBoxSphericalRadius.SmartIncrement = true;
        numericalTextBoxSphericalRadius.ThonsandsSeparator = true;
        numericalTextBoxSphericalRadius.WordWrap = false;
        numericalTextBoxSphericalRadius.TextChanged += textBox_TextChanged;
        numericalTextBoxSphericalRadius.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxTiltCorrectionSecondaryPhi
        // 
        resources.ApplyResources(textBoxTiltCorrectionSecondaryPhi, "textBoxTiltCorrectionSecondaryPhi");
        textBoxTiltCorrectionSecondaryPhi.BackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionSecondaryPhi.Name = "textBoxTiltCorrectionSecondaryPhi";
        textBoxTiltCorrectionSecondaryPhi.RoundErrorAccuracy = -1;
        textBoxTiltCorrectionSecondaryPhi.SkipEventDuringInput = false;
        textBoxTiltCorrectionSecondaryPhi.SmartIncrement = true;
        textBoxTiltCorrectionSecondaryPhi.ThonsandsSeparator = true;
        textBoxTiltCorrectionSecondaryPhi.WordWrap = false;
        textBoxTiltCorrectionSecondaryPhi.TextChanged += textBox_TextChanged;
        textBoxTiltCorrectionSecondaryPhi.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxTiltCorrectionPrimaryPhi
        // 
        resources.ApplyResources(textBoxTiltCorrectionPrimaryPhi, "textBoxTiltCorrectionPrimaryPhi");
        textBoxTiltCorrectionPrimaryPhi.BackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxTiltCorrectionPrimaryPhi.Name = "textBoxTiltCorrectionPrimaryPhi";
        textBoxTiltCorrectionPrimaryPhi.RoundErrorAccuracy = -1;
        textBoxTiltCorrectionPrimaryPhi.SkipEventDuringInput = false;
        textBoxTiltCorrectionPrimaryPhi.SmartIncrement = true;
        textBoxTiltCorrectionPrimaryPhi.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxTiltCorrectionPrimaryPhi, resources.GetString("textBoxTiltCorrectionPrimaryPhi.ToolTip"));
        textBoxTiltCorrectionPrimaryPhi.WordWrap = false;
        textBoxTiltCorrectionPrimaryPhi.TextChanged += textBox_TextChanged;
        textBoxTiltCorrectionPrimaryPhi.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxRefinedPixelKsiDev
        // 
        resources.ApplyResources(textBoxRefinedPixelKsiDev, "textBoxRefinedPixelKsiDev");
        textBoxRefinedPixelKsiDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsiDev.DecimalPlaces = 10;
        textBoxRefinedPixelKsiDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsiDev.Name = "textBoxRefinedPixelKsiDev";
        textBoxRefinedPixelKsiDev.ReadOnly = true;
        textBoxRefinedPixelKsiDev.RoundErrorAccuracy = -1;
        textBoxRefinedPixelKsiDev.SkipEventDuringInput = false;
        textBoxRefinedPixelKsiDev.SmartIncrement = true;
        textBoxRefinedPixelKsiDev.TabStop = false;
        textBoxRefinedPixelKsiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsiDev.ThonsandsSeparator = true;
        textBoxRefinedPixelKsiDev.WordWrap = false;
        // 
        // label68
        // 
        resources.ApplyResources(label68, "label68");
        label68.Name = "label68";
        // 
        // buttonCopyToClipboard
        // 
        resources.ApplyResources(buttonCopyToClipboard, "buttonCopyToClipboard");
        buttonCopyToClipboard.Name = "buttonCopyToClipboard";
        buttonCopyToClipboard.Click += buttonCopyToClipboard_Click;
        // 
        // label34
        // 
        resources.ApplyResources(label34, "label34");
        label34.Name = "label34";
        // 
        // textBoxWaveLengthDev
        // 
        resources.ApplyResources(textBoxWaveLengthDev, "textBoxWaveLengthDev");
        textBoxWaveLengthDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLengthDev.DecimalPlaces = 10;
        textBoxWaveLengthDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLengthDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLengthDev.Name = "textBoxWaveLengthDev";
        textBoxWaveLengthDev.ReadOnly = true;
        textBoxWaveLengthDev.RoundErrorAccuracy = -1;
        textBoxWaveLengthDev.SkipEventDuringInput = false;
        textBoxWaveLengthDev.SmartIncrement = true;
        textBoxWaveLengthDev.TabStop = false;
        textBoxWaveLengthDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLengthDev.ThonsandsSeparator = true;
        textBoxWaveLengthDev.WordWrap = false;
        // 
        // textBoxRefinedPixelKsi
        // 
        resources.ApplyResources(textBoxRefinedPixelKsi, "textBoxRefinedPixelKsi");
        textBoxRefinedPixelKsi.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsi.Name = "textBoxRefinedPixelKsi";
        textBoxRefinedPixelKsi.ReadOnly = true;
        textBoxRefinedPixelKsi.RoundErrorAccuracy = -1;
        textBoxRefinedPixelKsi.SkipEventDuringInput = false;
        textBoxRefinedPixelKsi.SmartIncrement = true;
        textBoxRefinedPixelKsi.TabStop = false;
        textBoxRefinedPixelKsi.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelKsi.ThonsandsSeparator = true;
        textBoxRefinedPixelKsi.WordWrap = false;
        // 
        // label15
        // 
        resources.ApplyResources(label15, "label15");
        label15.Name = "label15";
        // 
        // label32
        // 
        resources.ApplyResources(label32, "label32");
        label32.Name = "label32";
        // 
        // label70
        // 
        resources.ApplyResources(label70, "label70");
        label70.Name = "label70";
        // 
        // textBoxPrimaryFilmDistanceCopy2
        // 
        resources.ApplyResources(textBoxPrimaryFilmDistanceCopy2, "textBoxPrimaryFilmDistanceCopy2");
        textBoxPrimaryFilmDistanceCopy2.BackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy2.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy2.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy2.Name = "textBoxPrimaryFilmDistanceCopy2";
        textBoxPrimaryFilmDistanceCopy2.RadianValue = 7.7667151713747664D;
        textBoxPrimaryFilmDistanceCopy2.ReadOnly = true;
        textBoxPrimaryFilmDistanceCopy2.RoundErrorAccuracy = -1;
        textBoxPrimaryFilmDistanceCopy2.SkipEventDuringInput = false;
        textBoxPrimaryFilmDistanceCopy2.SmartIncrement = true;
        textBoxPrimaryFilmDistanceCopy2.TabStop = false;
        textBoxPrimaryFilmDistanceCopy2.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxPrimaryFilmDistanceCopy2.ThonsandsSeparator = true;
        textBoxPrimaryFilmDistanceCopy2.Value = 445D;
        textBoxPrimaryFilmDistanceCopy2.WordWrap = false;
        // 
        // numericalTextBoxRadiusInverseDev
        // 
        resources.ApplyResources(numericalTextBoxRadiusInverseDev, "numericalTextBoxRadiusInverseDev");
        numericalTextBoxRadiusInverseDev.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRadiusInverseDev.DecimalPlaces = 10;
        numericalTextBoxRadiusInverseDev.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRadiusInverseDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRadiusInverseDev.Name = "numericalTextBoxRadiusInverseDev";
        numericalTextBoxRadiusInverseDev.ReadOnly = true;
        numericalTextBoxRadiusInverseDev.RoundErrorAccuracy = -1;
        numericalTextBoxRadiusInverseDev.SkipEventDuringInput = false;
        numericalTextBoxRadiusInverseDev.SmartIncrement = true;
        numericalTextBoxRadiusInverseDev.TabStop = false;
        numericalTextBoxRadiusInverseDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRadiusInverseDev.ThonsandsSeparator = true;
        numericalTextBoxRadiusInverseDev.WordWrap = false;
        // 
        // textBoxRefinedSecondaryTauDev
        // 
        resources.ApplyResources(textBoxRefinedSecondaryTauDev, "textBoxRefinedSecondaryTauDev");
        textBoxRefinedSecondaryTauDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTauDev.DecimalPlaces = 10;
        textBoxRefinedSecondaryTauDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTauDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTauDev.Name = "textBoxRefinedSecondaryTauDev";
        textBoxRefinedSecondaryTauDev.ReadOnly = true;
        textBoxRefinedSecondaryTauDev.RoundErrorAccuracy = -1;
        textBoxRefinedSecondaryTauDev.SkipEventDuringInput = false;
        textBoxRefinedSecondaryTauDev.SmartIncrement = true;
        textBoxRefinedSecondaryTauDev.TabStop = false;
        textBoxRefinedSecondaryTauDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTauDev.ThonsandsSeparator = true;
        textBoxRefinedSecondaryTauDev.WordWrap = false;
        // 
        // textBoxPixelSizeYDev
        // 
        resources.ApplyResources(textBoxPixelSizeYDev, "textBoxPixelSizeYDev");
        textBoxPixelSizeYDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeYDev.DecimalPlaces = 10;
        textBoxPixelSizeYDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeYDev.Name = "textBoxPixelSizeYDev";
        textBoxPixelSizeYDev.ReadOnly = true;
        textBoxPixelSizeYDev.RoundErrorAccuracy = -1;
        textBoxPixelSizeYDev.SkipEventDuringInput = false;
        textBoxPixelSizeYDev.SmartIncrement = true;
        textBoxPixelSizeYDev.TabStop = false;
        textBoxPixelSizeYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeYDev.ThonsandsSeparator = true;
        textBoxPixelSizeYDev.WordWrap = false;
        // 
        // textBoxWaveLength
        // 
        resources.ApplyResources(textBoxWaveLength, "textBoxWaveLength");
        textBoxWaveLength.BackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLength.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLength.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxWaveLength.Name = "textBoxWaveLength";
        textBoxWaveLength.RadianValue = 0.0069813170079773184D;
        textBoxWaveLength.RoundErrorAccuracy = -1;
        textBoxWaveLength.SkipEventDuringInput = false;
        textBoxWaveLength.SmartIncrement = true;
        textBoxWaveLength.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxWaveLength, resources.GetString("textBoxWaveLength.ToolTip"));
        textBoxWaveLength.Value = 0.4D;
        textBoxWaveLength.WordWrap = false;
        textBoxWaveLength.ValueChanged += textBox_TextChanged;
        textBoxWaveLength.TextChanged += textBox_TextChanged;
        textBoxWaveLength.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxRefinedPixelSizeY
        // 
        resources.ApplyResources(textBoxRefinedPixelSizeY, "textBoxRefinedPixelSizeY");
        textBoxRefinedPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeY.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeY.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeY.Name = "textBoxRefinedPixelSizeY";
        textBoxRefinedPixelSizeY.RadianValue = 0.0017453292519943296D;
        textBoxRefinedPixelSizeY.ReadOnly = true;
        textBoxRefinedPixelSizeY.RoundErrorAccuracy = -1;
        textBoxRefinedPixelSizeY.SkipEventDuringInput = false;
        textBoxRefinedPixelSizeY.SmartIncrement = true;
        textBoxRefinedPixelSizeY.TabStop = false;
        textBoxRefinedPixelSizeY.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeY.ThonsandsSeparator = true;
        textBoxRefinedPixelSizeY.Value = 0.1D;
        textBoxRefinedPixelSizeY.WordWrap = false;
        // 
        // textBoxRefinedPrimaryTauDev
        // 
        resources.ApplyResources(textBoxRefinedPrimaryTauDev, "textBoxRefinedPrimaryTauDev");
        textBoxRefinedPrimaryTauDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTauDev.DecimalPlaces = 10;
        textBoxRefinedPrimaryTauDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTauDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTauDev.Name = "textBoxRefinedPrimaryTauDev";
        textBoxRefinedPrimaryTauDev.ReadOnly = true;
        textBoxRefinedPrimaryTauDev.RoundErrorAccuracy = -1;
        textBoxRefinedPrimaryTauDev.SkipEventDuringInput = false;
        textBoxRefinedPrimaryTauDev.SmartIncrement = true;
        textBoxRefinedPrimaryTauDev.TabStop = false;
        textBoxRefinedPrimaryTauDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTauDev.ThonsandsSeparator = true;
        textBoxRefinedPrimaryTauDev.WordWrap = false;
        // 
        // textBoxPixelSizeY
        // 
        resources.ApplyResources(textBoxPixelSizeY, "textBoxPixelSizeY");
        textBoxPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeY.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeY.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeY.Name = "textBoxPixelSizeY";
        textBoxPixelSizeY.RadianValue = 0.0017453292519943296D;
        textBoxPixelSizeY.RoundErrorAccuracy = -1;
        textBoxPixelSizeY.SkipEventDuringInput = false;
        textBoxPixelSizeY.SmartIncrement = true;
        textBoxPixelSizeY.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxPixelSizeY, resources.GetString("textBoxPixelSizeY.ToolTip"));
        textBoxPixelSizeY.Value = 0.1D;
        textBoxPixelSizeY.WordWrap = false;
        textBoxPixelSizeY.TextChanged += textBox_TextChanged;
        textBoxPixelSizeY.KeyPress += textBoxNumOnly_KeyPress;
        // 
        // textBoxRefinedSecondaryPhiDev
        // 
        resources.ApplyResources(textBoxRefinedSecondaryPhiDev, "textBoxRefinedSecondaryPhiDev");
        textBoxRefinedSecondaryPhiDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhiDev.DecimalPlaces = 10;
        textBoxRefinedSecondaryPhiDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhiDev.Name = "textBoxRefinedSecondaryPhiDev";
        textBoxRefinedSecondaryPhiDev.ReadOnly = true;
        textBoxRefinedSecondaryPhiDev.RoundErrorAccuracy = -1;
        textBoxRefinedSecondaryPhiDev.SkipEventDuringInput = false;
        textBoxRefinedSecondaryPhiDev.SmartIncrement = true;
        textBoxRefinedSecondaryPhiDev.TabStop = false;
        textBoxRefinedSecondaryPhiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhiDev.ThonsandsSeparator = true;
        textBoxRefinedSecondaryPhiDev.WordWrap = false;
        // 
        // label41
        // 
        resources.ApplyResources(label41, "label41");
        label41.Name = "label41";
        // 
        // textBoxRefinedPrimaryFilmDistance
        // 
        resources.ApplyResources(textBoxRefinedPrimaryFilmDistance, "textBoxRefinedPrimaryFilmDistance");
        textBoxRefinedPrimaryFilmDistance.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryFilmDistance.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryFilmDistance.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryFilmDistance.Name = "textBoxRefinedPrimaryFilmDistance";
        textBoxRefinedPrimaryFilmDistance.RadianValue = 6.9813170079773181D;
        textBoxRefinedPrimaryFilmDistance.ReadOnly = true;
        textBoxRefinedPrimaryFilmDistance.RoundErrorAccuracy = -1;
        textBoxRefinedPrimaryFilmDistance.SkipEventDuringInput = false;
        textBoxRefinedPrimaryFilmDistance.SmartIncrement = true;
        textBoxRefinedPrimaryFilmDistance.TabStop = false;
        textBoxRefinedPrimaryFilmDistance.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryFilmDistance.ThonsandsSeparator = true;
        textBoxRefinedPrimaryFilmDistance.Value = 400D;
        textBoxRefinedPrimaryFilmDistance.WordWrap = false;
        // 
        // label13
        // 
        resources.ApplyResources(label13, "label13");
        label13.Name = "label13";
        // 
        // textBoxRefinedPrimaryPhiDev
        // 
        resources.ApplyResources(textBoxRefinedPrimaryPhiDev, "textBoxRefinedPrimaryPhiDev");
        textBoxRefinedPrimaryPhiDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhiDev.DecimalPlaces = 10;
        textBoxRefinedPrimaryPhiDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhiDev.Name = "textBoxRefinedPrimaryPhiDev";
        textBoxRefinedPrimaryPhiDev.ReadOnly = true;
        textBoxRefinedPrimaryPhiDev.RoundErrorAccuracy = -1;
        textBoxRefinedPrimaryPhiDev.SkipEventDuringInput = false;
        textBoxRefinedPrimaryPhiDev.SmartIncrement = true;
        textBoxRefinedPrimaryPhiDev.TabStop = false;
        textBoxRefinedPrimaryPhiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhiDev.ThonsandsSeparator = true;
        textBoxRefinedPrimaryPhiDev.WordWrap = false;
        // 
        // textBoxPixelSizeX
        // 
        resources.ApplyResources(textBoxPixelSizeX, "textBoxPixelSizeX");
        textBoxPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeX.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeX.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeX.Name = "textBoxPixelSizeX";
        textBoxPixelSizeX.RadianValue = 0.0017453292519943296D;
        textBoxPixelSizeX.RoundErrorAccuracy = -1;
        textBoxPixelSizeX.SkipEventDuringInput = false;
        textBoxPixelSizeX.SmartIncrement = true;
        textBoxPixelSizeX.ThonsandsSeparator = true;
        toolTipJapanese.SetToolTip(textBoxPixelSizeX, resources.GetString("textBoxPixelSizeX.ToolTip"));
        textBoxPixelSizeX.Value = 0.1D;
        textBoxPixelSizeX.WordWrap = false;
        // 
        // textBoxRefinedWaveLength
        // 
        resources.ApplyResources(textBoxRefinedWaveLength, "textBoxRefinedWaveLength");
        textBoxRefinedWaveLength.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedWaveLength.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedWaveLength.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedWaveLength.Name = "textBoxRefinedWaveLength";
        textBoxRefinedWaveLength.RadianValue = 0.0069813170079773184D;
        textBoxRefinedWaveLength.ReadOnly = true;
        textBoxRefinedWaveLength.RoundErrorAccuracy = -1;
        textBoxRefinedWaveLength.SkipEventDuringInput = false;
        textBoxRefinedWaveLength.SmartIncrement = true;
        textBoxRefinedWaveLength.TabStop = false;
        textBoxRefinedWaveLength.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedWaveLength.ThonsandsSeparator = true;
        textBoxRefinedWaveLength.Value = 0.4D;
        textBoxRefinedWaveLength.WordWrap = false;
        // 
        // textBoxRefinedPixelSizeX
        // 
        resources.ApplyResources(textBoxRefinedPixelSizeX, "textBoxRefinedPixelSizeX");
        textBoxRefinedPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeX.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeX.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeX.Name = "textBoxRefinedPixelSizeX";
        textBoxRefinedPixelSizeX.RadianValue = 0.0017453292519943296D;
        textBoxRefinedPixelSizeX.ReadOnly = true;
        textBoxRefinedPixelSizeX.RoundErrorAccuracy = -1;
        textBoxRefinedPixelSizeX.SkipEventDuringInput = false;
        textBoxRefinedPixelSizeX.SmartIncrement = true;
        textBoxRefinedPixelSizeX.TabStop = false;
        textBoxRefinedPixelSizeX.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPixelSizeX.ThonsandsSeparator = true;
        textBoxRefinedPixelSizeX.Value = 0.1D;
        textBoxRefinedPixelSizeX.WordWrap = false;
        // 
        // numericalTextBoxRefinedSphericalRadius
        // 
        resources.ApplyResources(numericalTextBoxRefinedSphericalRadius, "numericalTextBoxRefinedSphericalRadius");
        numericalTextBoxRefinedSphericalRadius.BackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRefinedSphericalRadius.FooterBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRefinedSphericalRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRefinedSphericalRadius.Name = "numericalTextBoxRefinedSphericalRadius";
        numericalTextBoxRefinedSphericalRadius.ReadOnly = true;
        numericalTextBoxRefinedSphericalRadius.RoundErrorAccuracy = -1;
        numericalTextBoxRefinedSphericalRadius.SkipEventDuringInput = false;
        numericalTextBoxRefinedSphericalRadius.SmartIncrement = true;
        numericalTextBoxRefinedSphericalRadius.TabStop = false;
        numericalTextBoxRefinedSphericalRadius.TextBoxBackColor = System.Drawing.SystemColors.Control;
        numericalTextBoxRefinedSphericalRadius.ThonsandsSeparator = true;
        numericalTextBoxRefinedSphericalRadius.WordWrap = false;
        // 
        // textBoxRefinedSecondaryTau
        // 
        resources.ApplyResources(textBoxRefinedSecondaryTau, "textBoxRefinedSecondaryTau");
        textBoxRefinedSecondaryTau.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTau.Name = "textBoxRefinedSecondaryTau";
        textBoxRefinedSecondaryTau.ReadOnly = true;
        textBoxRefinedSecondaryTau.RoundErrorAccuracy = -1;
        textBoxRefinedSecondaryTau.SkipEventDuringInput = false;
        textBoxRefinedSecondaryTau.SmartIncrement = true;
        textBoxRefinedSecondaryTau.TabStop = false;
        textBoxRefinedSecondaryTau.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryTau.ThonsandsSeparator = true;
        textBoxRefinedSecondaryTau.WordWrap = false;
        // 
        // label20
        // 
        resources.ApplyResources(label20, "label20");
        label20.Name = "label20";
        // 
        // textBoxPixelSizeXDev
        // 
        resources.ApplyResources(textBoxPixelSizeXDev, "textBoxPixelSizeXDev");
        textBoxPixelSizeXDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeXDev.DecimalPlaces = 10;
        textBoxPixelSizeXDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeXDev.Name = "textBoxPixelSizeXDev";
        textBoxPixelSizeXDev.ReadOnly = true;
        textBoxPixelSizeXDev.RoundErrorAccuracy = -1;
        textBoxPixelSizeXDev.SkipEventDuringInput = false;
        textBoxPixelSizeXDev.SmartIncrement = true;
        textBoxPixelSizeXDev.TabStop = false;
        textBoxPixelSizeXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxPixelSizeXDev.ThonsandsSeparator = true;
        textBoxPixelSizeXDev.WordWrap = false;
        // 
        // textBoxRefinedPrimaryTau
        // 
        resources.ApplyResources(textBoxRefinedPrimaryTau, "textBoxRefinedPrimaryTau");
        textBoxRefinedPrimaryTau.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTau.Name = "textBoxRefinedPrimaryTau";
        textBoxRefinedPrimaryTau.ReadOnly = true;
        textBoxRefinedPrimaryTau.RoundErrorAccuracy = -1;
        textBoxRefinedPrimaryTau.SkipEventDuringInput = false;
        textBoxRefinedPrimaryTau.SmartIncrement = true;
        textBoxRefinedPrimaryTau.TabStop = false;
        textBoxRefinedPrimaryTau.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryTau.ThonsandsSeparator = true;
        textBoxRefinedPrimaryTau.WordWrap = false;
        // 
        // label44
        // 
        resources.ApplyResources(label44, "label44");
        label44.Name = "label44";
        // 
        // label6
        // 
        resources.ApplyResources(label6, "label6");
        label6.Name = "label6";
        // 
        // label69
        // 
        resources.ApplyResources(label69, "label69");
        label69.Name = "label69";
        // 
        // label33
        // 
        resources.ApplyResources(label33, "label33");
        label33.Name = "label33";
        // 
        // label63
        // 
        resources.ApplyResources(label63, "label63");
        label63.Name = "label63";
        // 
        // label39
        // 
        resources.ApplyResources(label39, "label39");
        label39.Name = "label39";
        // 
        // label81
        // 
        resources.ApplyResources(label81, "label81");
        label81.Name = "label81";
        // 
        // label62
        // 
        resources.ApplyResources(label62, "label62");
        label62.Name = "label62";
        // 
        // textBoxCameraLengthDev
        // 
        resources.ApplyResources(textBoxCameraLengthDev, "textBoxCameraLengthDev");
        textBoxCameraLengthDev.BackColor = System.Drawing.SystemColors.Control;
        textBoxCameraLengthDev.DecimalPlaces = 10;
        textBoxCameraLengthDev.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxCameraLengthDev.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxCameraLengthDev.Name = "textBoxCameraLengthDev";
        textBoxCameraLengthDev.ReadOnly = true;
        textBoxCameraLengthDev.RoundErrorAccuracy = -1;
        textBoxCameraLengthDev.SkipEventDuringInput = false;
        textBoxCameraLengthDev.SmartIncrement = true;
        textBoxCameraLengthDev.TabStop = false;
        textBoxCameraLengthDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxCameraLengthDev.ThonsandsSeparator = true;
        textBoxCameraLengthDev.WordWrap = false;
        // 
        // label22
        // 
        resources.ApplyResources(label22, "label22");
        label22.Name = "label22";
        // 
        // textBoxRefinedSecondaryPhi
        // 
        resources.ApplyResources(textBoxRefinedSecondaryPhi, "textBoxRefinedSecondaryPhi");
        textBoxRefinedSecondaryPhi.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhi.Name = "textBoxRefinedSecondaryPhi";
        textBoxRefinedSecondaryPhi.ReadOnly = true;
        textBoxRefinedSecondaryPhi.RoundErrorAccuracy = -1;
        textBoxRefinedSecondaryPhi.SkipEventDuringInput = false;
        textBoxRefinedSecondaryPhi.SmartIncrement = true;
        textBoxRefinedSecondaryPhi.TabStop = false;
        textBoxRefinedSecondaryPhi.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedSecondaryPhi.ThonsandsSeparator = true;
        textBoxRefinedSecondaryPhi.WordWrap = false;
        // 
        // label42
        // 
        resources.ApplyResources(label42, "label42");
        label42.Name = "label42";
        // 
        // textBoxRefinedPrimaryPhi
        // 
        resources.ApplyResources(textBoxRefinedPrimaryPhi, "textBoxRefinedPrimaryPhi");
        textBoxRefinedPrimaryPhi.BackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhi.Name = "textBoxRefinedPrimaryPhi";
        textBoxRefinedPrimaryPhi.ReadOnly = true;
        textBoxRefinedPrimaryPhi.RoundErrorAccuracy = -1;
        textBoxRefinedPrimaryPhi.SkipEventDuringInput = false;
        textBoxRefinedPrimaryPhi.SmartIncrement = true;
        textBoxRefinedPrimaryPhi.TabStop = false;
        textBoxRefinedPrimaryPhi.TextBoxBackColor = System.Drawing.SystemColors.Control;
        textBoxRefinedPrimaryPhi.ThonsandsSeparator = true;
        textBoxRefinedPrimaryPhi.WordWrap = false;
        // 
        // label61
        // 
        resources.ApplyResources(label61, "label61");
        label61.Name = "label61";
        // 
        // label49
        // 
        resources.ApplyResources(label49, "label49");
        label49.Name = "label49";
        // 
        // label30
        // 
        resources.ApplyResources(label30, "label30");
        label30.Name = "label30";
        // 
        // label66
        // 
        resources.ApplyResources(label66, "label66");
        label66.Name = "label66";
        // 
        // label65
        // 
        resources.ApplyResources(label65, "label65");
        label65.Name = "label65";
        // 
        // label64
        // 
        resources.ApplyResources(label64, "label64");
        label64.Name = "label64";
        // 
        // label75
        // 
        resources.ApplyResources(label75, "label75");
        label75.Name = "label75";
        // 
        // label71
        // 
        resources.ApplyResources(label71, "label71");
        label71.Name = "label71";
        // 
        // backgroundWorkerRefine
        // 
        backgroundWorkerRefine.WorkerReportsProgress = true;
        backgroundWorkerRefine.WorkerSupportsCancellation = true;
        backgroundWorkerRefine.DoWork += backgroundWorkerRefine_DoWork;
        backgroundWorkerRefine.ProgressChanged += backgroundWorkerRefine_ProgressChanged;
        backgroundWorkerRefine.RunWorkerCompleted += backgroundWorkerRefine_RunWorkerCompleted;
        // 
        // flowLayoutPanel1
        // 
        resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
        flowLayoutPanel1.Controls.Add(radioButton1);
        flowLayoutPanel1.Controls.Add(radioButton2);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        // 
        // radioButton1
        // 
        resources.ApplyResources(radioButton1, "radioButton1");
        radioButton1.Checked = true;
        radioButton1.Name = "radioButton1";
        radioButton1.TabStop = true;
        radioButton1.UseVisualStyleBackColor = true;
        // 
        // radioButton2
        // 
        resources.ApplyResources(radioButton2, "radioButton2");
        radioButton2.Name = "radioButton2";
        radioButton2.UseVisualStyleBackColor = true;
        // 
        // buttonGetWaveLengthFromWholePattern
        // 
        resources.ApplyResources(buttonGetWaveLengthFromWholePattern, "buttonGetWaveLengthFromWholePattern");
        buttonGetWaveLengthFromWholePattern.Name = "buttonGetWaveLengthFromWholePattern";
        buttonGetWaveLengthFromWholePattern.Click += buttonGetWaveLengthFromWholePattern_Click;
        // 
        // buttonGetCameraLenghtFromWholePattern
        // 
        resources.ApplyResources(buttonGetCameraLenghtFromWholePattern, "buttonGetCameraLenghtFromWholePattern");
        buttonGetCameraLenghtFromWholePattern.Name = "buttonGetCameraLenghtFromWholePattern";
        buttonGetCameraLenghtFromWholePattern.Click += buttonGetCameraLenghtFromWholePattern_Click;
        // 
        // dataGridView
        // 
        dataGridView.AllowUserToAddRows = false;
        dataGridView.AllowUserToDeleteRows = false;
        dataGridView.AllowUserToResizeColumns = false;
        dataGridView.AllowUserToResizeRows = false;
        dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
        resources.ApplyResources(dataGridView, "dataGridView");
        dataGridView.BorderStyle = BorderStyle.Fixed3D;
        dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        dataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView.Columns.AddRange(new DataGridViewColumn[] { ColumnNo, ColumnHKL, ColumnPrimaryCheck, ColumnPrimary, ColumnSecondaryCheck, ColumnSecondary });
        dataGridView.Name = "dataGridView";
        dataGridView.RowHeadersVisible = false;
        dataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
        dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle7;
        dataGridView.RowTemplate.Height = 21;
        toolTipJapanese.SetToolTip(dataGridView, resources.GetString("dataGridView.ToolTip"));
        dataGridView.CellDoubleClick += dataGridView1_CellDoubleClick;
        // 
        // ColumnNo
        // 
        ColumnNo.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle10.Alignment = DataGridViewContentAlignment.TopCenter;
        dataGridViewCellStyle10.Font = new System.Drawing.Font("Tahoma", 8.25F);
        ColumnNo.DefaultCellStyle = dataGridViewCellStyle10;
        resources.ApplyResources(ColumnNo, "ColumnNo");
        ColumnNo.Name = "ColumnNo";
        ColumnNo.ReadOnly = true;
        ColumnNo.Resizable = DataGridViewTriState.False;
        ColumnNo.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // ColumnHKL
        // 
        ColumnHKL.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle11.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridViewCellStyle11.NullValue = null;
        ColumnHKL.DefaultCellStyle = dataGridViewCellStyle11;
        resources.ApplyResources(ColumnHKL, "ColumnHKL");
        ColumnHKL.Name = "ColumnHKL";
        ColumnHKL.ReadOnly = true;
        ColumnHKL.Resizable = DataGridViewTriState.False;
        ColumnHKL.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // ColumnPrimaryCheck
        // 
        ColumnPrimaryCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle12.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
        dataGridViewCellStyle12.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridViewCellStyle12.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle12.NullValue = false;
        dataGridViewCellStyle12.SelectionBackColor = System.Drawing.Color.FromArgb(128, 128, 255);
        dataGridViewCellStyle12.SelectionForeColor = System.Drawing.Color.Black;
        ColumnPrimaryCheck.DefaultCellStyle = dataGridViewCellStyle12;
        resources.ApplyResources(ColumnPrimaryCheck, "ColumnPrimaryCheck");
        ColumnPrimaryCheck.Name = "ColumnPrimaryCheck";
        ColumnPrimaryCheck.Resizable = DataGridViewTriState.False;
        // 
        // ColumnPrimary
        // 
        ColumnPrimary.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        ColumnPrimary.ContextMenuStrip = contextMenuStrip1;
        dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(128, 128, 255);
        dataGridViewCellStyle13.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridViewCellStyle13.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle13.NullValue = null;
        dataGridViewCellStyle13.SelectionBackColor = System.Drawing.Color.FromArgb(64, 64, 128);
        dataGridViewCellStyle13.SelectionForeColor = System.Drawing.Color.White;
        ColumnPrimary.DefaultCellStyle = dataGridViewCellStyle13;
        resources.ApplyResources(ColumnPrimary, "ColumnPrimary");
        ColumnPrimary.Name = "ColumnPrimary";
        ColumnPrimary.ReadOnly = true;
        ColumnPrimary.Resizable = DataGridViewTriState.False;
        ColumnPrimary.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // contextMenuStrip1
        // 
        contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        contextMenuStrip1.Items.AddRange(new ToolStripItem[] { checkUncheckToolStripMenuItem });
        contextMenuStrip1.Name = "contextMenuStrip1";
        resources.ApplyResources(contextMenuStrip1, "contextMenuStrip1");
        // 
        // checkUncheckToolStripMenuItem
        // 
        checkUncheckToolStripMenuItem.Name = "checkUncheckToolStripMenuItem";
        resources.ApplyResources(checkUncheckToolStripMenuItem, "checkUncheckToolStripMenuItem");
        checkUncheckToolStripMenuItem.Click += checkUncheckToolStripMenuItem_Click;
        // 
        // ColumnSecondaryCheck
        // 
        ColumnSecondaryCheck.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleCenter;
        dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
        dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle5.NullValue = false;
        dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(255, 128, 128);
        dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
        ColumnSecondaryCheck.DefaultCellStyle = dataGridViewCellStyle5;
        resources.ApplyResources(ColumnSecondaryCheck, "ColumnSecondaryCheck");
        ColumnSecondaryCheck.Name = "ColumnSecondaryCheck";
        ColumnSecondaryCheck.Resizable = DataGridViewTriState.False;
        // 
        // ColumnSecondary
        // 
        ColumnSecondary.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
        ColumnSecondary.ContextMenuStrip = contextMenuStrip1;
        dataGridViewCellStyle14.BackColor = System.Drawing.Color.FromArgb(255, 128, 128);
        dataGridViewCellStyle14.Font = new System.Drawing.Font("Tahoma", 8.25F);
        dataGridViewCellStyle14.ForeColor = System.Drawing.Color.Black;
        dataGridViewCellStyle14.NullValue = null;
        dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.FromArgb(128, 64, 64);
        dataGridViewCellStyle14.SelectionForeColor = System.Drawing.Color.White;
        ColumnSecondary.DefaultCellStyle = dataGridViewCellStyle14;
        resources.ApplyResources(ColumnSecondary, "ColumnSecondary");
        ColumnSecondary.Name = "ColumnSecondary";
        ColumnSecondary.ReadOnly = true;
        ColumnSecondary.Resizable = DataGridViewTriState.False;
        ColumnSecondary.SortMode = DataGridViewColumnSortMode.NotSortable;
        // 
        // pictureBoxMain
        // 
        resources.ApplyResources(pictureBoxMain, "pictureBoxMain");
        pictureBoxMain.BackColor = System.Drawing.Color.White;
        pictureBoxMain.BorderStyle = BorderStyle.Fixed3D;
        pictureBoxMain.Name = "pictureBoxMain";
        pictureBoxMain.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxMain, resources.GetString("pictureBoxMain.ToolTip"));
        pictureBoxMain.Paint += pictureBoxMain_Paint;
        pictureBoxMain.MouseDown += pictureBoxMain_MouseDown;
        pictureBoxMain.MouseMove += pictureBoxMain_MouseMove;
        pictureBoxMain.MouseUp += pictureBoxMain_MouseUp;
        // 
        // pictureBoxPixelKsi
        // 
        pictureBoxPixelKsi.BackColor = System.Drawing.Color.White;
        pictureBoxPixelKsi.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxPixelKsi, "pictureBoxPixelKsi");
        pictureBoxPixelKsi.Name = "pictureBoxPixelKsi";
        pictureBoxPixelKsi.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxPixelKsi, resources.GetString("pictureBoxPixelKsi.ToolTip"));
        // 
        // pictureBoxPixelSizeY
        // 
        pictureBoxPixelSizeY.BackColor = System.Drawing.Color.White;
        pictureBoxPixelSizeY.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxPixelSizeY, "pictureBoxPixelSizeY");
        pictureBoxPixelSizeY.Name = "pictureBoxPixelSizeY";
        pictureBoxPixelSizeY.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxPixelSizeY, resources.GetString("pictureBoxPixelSizeY.ToolTip"));
        // 
        // pictureBoxPixelSizeX
        // 
        pictureBoxPixelSizeX.BackColor = System.Drawing.Color.White;
        pictureBoxPixelSizeX.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxPixelSizeX, "pictureBoxPixelSizeX");
        pictureBoxPixelSizeX.Name = "pictureBoxPixelSizeX";
        pictureBoxPixelSizeX.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxPixelSizeX, resources.GetString("pictureBoxPixelSizeX.ToolTip"));
        // 
        // pictureBoxTiltCorrectionTau2
        // 
        pictureBoxTiltCorrectionTau2.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrectionTau2.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrectionTau2, "pictureBoxTiltCorrectionTau2");
        pictureBoxTiltCorrectionTau2.Name = "pictureBoxTiltCorrectionTau2";
        pictureBoxTiltCorrectionTau2.TabStop = false;
        // 
        // pictureBoxTiltCorrectionTau1
        // 
        pictureBoxTiltCorrectionTau1.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrectionTau1.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrectionTau1, "pictureBoxTiltCorrectionTau1");
        pictureBoxTiltCorrectionTau1.Name = "pictureBoxTiltCorrectionTau1";
        pictureBoxTiltCorrectionTau1.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxTiltCorrectionTau1, resources.GetString("pictureBoxTiltCorrectionTau1.ToolTip"));
        // 
        // pictureBoxTiltCorrectionPhi2
        // 
        pictureBoxTiltCorrectionPhi2.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrectionPhi2.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrectionPhi2, "pictureBoxTiltCorrectionPhi2");
        pictureBoxTiltCorrectionPhi2.Name = "pictureBoxTiltCorrectionPhi2";
        pictureBoxTiltCorrectionPhi2.TabStop = false;
        // 
        // pictureBoxTiltCorrectionPhi1
        // 
        pictureBoxTiltCorrectionPhi1.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrectionPhi1.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrectionPhi1, "pictureBoxTiltCorrectionPhi1");
        pictureBoxTiltCorrectionPhi1.Name = "pictureBoxTiltCorrectionPhi1";
        pictureBoxTiltCorrectionPhi1.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxTiltCorrectionPhi1, resources.GetString("pictureBoxTiltCorrectionPhi1.ToolTip"));
        // 
        // pictureBoxCameraLength
        // 
        pictureBoxCameraLength.BackColor = System.Drawing.Color.White;
        pictureBoxCameraLength.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxCameraLength, "pictureBoxCameraLength");
        pictureBoxCameraLength.Name = "pictureBoxCameraLength";
        pictureBoxCameraLength.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxCameraLength, resources.GetString("pictureBoxCameraLength.ToolTip"));
        // 
        // pictureBoxResidual
        // 
        pictureBoxResidual.BackColor = System.Drawing.Color.White;
        pictureBoxResidual.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxResidual, "pictureBoxResidual");
        pictureBoxResidual.Name = "pictureBoxResidual";
        pictureBoxResidual.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxResidual, resources.GetString("pictureBoxResidual.ToolTip"));
        // 
        // pictureBoxWaveLength
        // 
        pictureBoxWaveLength.BackColor = System.Drawing.Color.White;
        pictureBoxWaveLength.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxWaveLength, "pictureBoxWaveLength");
        pictureBoxWaveLength.Name = "pictureBoxWaveLength";
        pictureBoxWaveLength.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxWaveLength, resources.GetString("pictureBoxWaveLength.ToolTip"));
        // 
        // pictureBoxTiltCorrection2
        // 
        pictureBoxTiltCorrection2.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrection2.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrection2, "pictureBoxTiltCorrection2");
        pictureBoxTiltCorrection2.Name = "pictureBoxTiltCorrection2";
        pictureBoxTiltCorrection2.TabStop = false;
        // 
        // pictureBoxTiltCorrection1
        // 
        pictureBoxTiltCorrection1.BackColor = System.Drawing.Color.White;
        pictureBoxTiltCorrection1.BorderStyle = BorderStyle.Fixed3D;
        resources.ApplyResources(pictureBoxTiltCorrection1, "pictureBoxTiltCorrection1");
        pictureBoxTiltCorrection1.Name = "pictureBoxTiltCorrection1";
        pictureBoxTiltCorrection1.TabStop = false;
        toolTipJapanese.SetToolTip(pictureBoxTiltCorrection1, resources.GetString("pictureBoxTiltCorrection1.ToolTip"));
        // 
        // label74
        // 
        resources.ApplyResources(label74, "label74");
        label74.Name = "label74";
        // 
        // label80
        // 
        resources.ApplyResources(label80, "label80");
        label80.Name = "label80";
        // 
        // label57
        // 
        resources.ApplyResources(label57, "label57");
        label57.Name = "label57";
        // 
        // label60
        // 
        resources.ApplyResources(label60, "label60");
        label60.Name = "label60";
        // 
        // label79
        // 
        resources.ApplyResources(label79, "label79");
        label79.Name = "label79";
        // 
        // label72
        // 
        resources.ApplyResources(label72, "label72");
        label72.Name = "label72";
        // 
        // label37
        // 
        resources.ApplyResources(label37, "label37");
        label37.Name = "label37";
        // 
        // label76
        // 
        resources.ApplyResources(label76, "label76");
        label76.Name = "label76";
        // 
        // label16
        // 
        resources.ApplyResources(label16, "label16");
        label16.Name = "label16";
        // 
        // label8
        // 
        resources.ApplyResources(label8, "label8");
        label8.Name = "label8";
        // 
        // label78
        // 
        resources.ApplyResources(label78, "label78");
        label78.Name = "label78";
        // 
        // label77
        // 
        resources.ApplyResources(label77, "label77");
        label77.Name = "label77";
        // 
        // label47
        // 
        resources.ApplyResources(label47, "label47");
        label47.Name = "label47";
        // 
        // label59
        // 
        resources.ApplyResources(label59, "label59");
        label59.Name = "label59";
        // 
        // label50
        // 
        resources.ApplyResources(label50, "label50");
        label50.Name = "label50";
        // 
        // label52
        // 
        resources.ApplyResources(label52, "label52");
        label52.Name = "label52";
        // 
        // statusStrip1
        // 
        statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
        statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar1, toolStripStatusLabel1 });
        resources.ApplyResources(statusStrip1, "statusStrip1");
        statusStrip1.Name = "statusStrip1";
        // 
        // toolStripProgressBar1
        // 
        toolStripProgressBar1.Maximum = 100000;
        toolStripProgressBar1.Name = "toolStripProgressBar1";
        resources.ApplyResources(toolStripProgressBar1, "toolStripProgressBar1");
        toolStripProgressBar1.Step = 1;
        toolStripProgressBar1.Style = ProgressBarStyle.Continuous;
        // 
        // toolStripStatusLabel1
        // 
        toolStripStatusLabel1.Name = "toolStripStatusLabel1";
        resources.ApplyResources(toolStripStatusLabel1, "toolStripStatusLabel1");
        // 
        // groupBoxPeakList
        // 
        resources.ApplyResources(groupBoxPeakList, "groupBoxPeakList");
        groupBoxPeakList.Controls.Add(buttonGetWaveLengthFromWholePattern);
        groupBoxPeakList.Controls.Add(dataGridView);
        groupBoxPeakList.Controls.Add(buttonGetCameraLenghtFromWholePattern);
        groupBoxPeakList.Controls.Add(buttonCheckPeaks);
        groupBoxPeakList.Controls.Add(numericBoxAwayFrom);
        groupBoxPeakList.Controls.Add(numericBoxLowerThan);
        groupBoxPeakList.Name = "groupBoxPeakList";
        groupBoxPeakList.TabStop = false;
        // 
        // buttonCheckPeaks
        // 
        resources.ApplyResources(buttonCheckPeaks, "buttonCheckPeaks");
        buttonCheckPeaks.Name = "buttonCheckPeaks";
        buttonCheckPeaks.UseVisualStyleBackColor = true;
        buttonCheckPeaks.Click += buttonCheckPeaks_Click;
        // 
        // numericBoxAwayFrom
        // 
        resources.ApplyResources(numericBoxAwayFrom, "numericBoxAwayFrom");
        numericBoxAwayFrom.BackColor = System.Drawing.SystemColors.Control;
        numericBoxAwayFrom.DecimalPlaces = 2;
        numericBoxAwayFrom.FooterBackColor = System.Drawing.SystemColors.Control;
        numericBoxAwayFrom.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericBoxAwayFrom.Minimum = 0D;
        numericBoxAwayFrom.Name = "numericBoxAwayFrom";
        numericBoxAwayFrom.RadianValue = 0.017453292519943295D;
        numericBoxAwayFrom.RoundErrorAccuracy = -1;
        numericBoxAwayFrom.SkipEventDuringInput = false;
        numericBoxAwayFrom.SmartIncrement = true;
        numericBoxAwayFrom.ThonsandsSeparator = true;
        numericBoxAwayFrom.Value = 1D;
        numericBoxAwayFrom.WordWrap = false;
        numericBoxAwayFrom.TextChanged += textBox_TextChanged;
        // 
        // numericBoxLowerThan
        // 
        resources.ApplyResources(numericBoxLowerThan, "numericBoxLowerThan");
        numericBoxLowerThan.BackColor = System.Drawing.SystemColors.Control;
        numericBoxLowerThan.DecimalPlaces = 2;
        numericBoxLowerThan.FooterBackColor = System.Drawing.SystemColors.Control;
        numericBoxLowerThan.HeaderBackColor = System.Drawing.SystemColors.Control;
        numericBoxLowerThan.Minimum = 0D;
        numericBoxLowerThan.Name = "numericBoxLowerThan";
        numericBoxLowerThan.RadianValue = 2.6179938779914944D;
        numericBoxLowerThan.RoundErrorAccuracy = -1;
        numericBoxLowerThan.SkipEventDuringInput = false;
        numericBoxLowerThan.SmartIncrement = true;
        numericBoxLowerThan.ThonsandsSeparator = true;
        numericBoxLowerThan.Value = 150D;
        numericBoxLowerThan.WordWrap = false;
        numericBoxLowerThan.TextChanged += textBox_TextChanged;
        // 
        // panel1
        // 
        panel1.AllowDrop = true;
        resources.ApplyResources(panel1, "panel1");
        panel1.Controls.Add(pictureBoxMain);
        panel1.Controls.Add(pictureBoxTiltCorrection2);
        panel1.Controls.Add(pictureBoxTiltCorrectionPhi1);
        panel1.Controls.Add(pictureBoxTiltCorrection1);
        panel1.Controls.Add(pictureBoxPixelSizeY);
        panel1.Controls.Add(pictureBoxPixelKsi);
        panel1.Controls.Add(pictureBoxCameraLength);
        panel1.Controls.Add(pictureBoxTiltCorrectionTau2);
        panel1.Controls.Add(pictureBoxResidual);
        panel1.Controls.Add(pictureBoxPixelSizeX);
        panel1.Controls.Add(pictureBoxWaveLength);
        panel1.Controls.Add(pictureBoxTiltCorrectionPhi2);
        panel1.Controls.Add(groupBoxPrimaryImage);
        panel1.Controls.Add(groupBoxSecondaryImage);
        panel1.Controls.Add(groupBoxPeakList);
        panel1.Controls.Add(flowLayoutPanel1);
        panel1.Controls.Add(groupBoxParameter);
        panel1.Controls.Add(groupBoxOption);
        panel1.Controls.Add(label76);
        panel1.Controls.Add(pictureBoxTiltCorrectionTau1);
        panel1.Controls.Add(label8);
        panel1.Controls.Add(label47);
        panel1.Controls.Add(label50);
        panel1.Controls.Add(label59);
        panel1.Controls.Add(label57);
        panel1.Controls.Add(label16);
        panel1.Controls.Add(label77);
        panel1.Controls.Add(label74);
        panel1.Controls.Add(label72);
        panel1.Controls.Add(label78);
        panel1.Controls.Add(label52);
        panel1.Controls.Add(label60);
        panel1.Controls.Add(label37);
        panel1.Controls.Add(label80);
        panel1.Controls.Add(label79);
        panel1.Name = "panel1";
        // 
        // flowLayoutPanelEachPeaks
        // 
        resources.ApplyResources(flowLayoutPanelEachPeaks, "flowLayoutPanelEachPeaks");
        flowLayoutPanelEachPeaks.Name = "flowLayoutPanelEachPeaks";
        // 
        // checkBoxShowEachPeaks
        // 
        resources.ApplyResources(checkBoxShowEachPeaks, "checkBoxShowEachPeaks");
        checkBoxShowEachPeaks.Name = "checkBoxShowEachPeaks";
        checkBoxShowEachPeaks.UseVisualStyleBackColor = true;
        checkBoxShowEachPeaks.CheckedChanged += checkBoxShowEachPeaks_CheckedChanged;
        // 
        // FormFindParameter
        // 
        AllowDrop = true;
        resources.ApplyResources(this, "$this");
        AutoScaleMode = AutoScaleMode.Dpi;
        Controls.Add(flowLayoutPanelEachPeaks);
        Controls.Add(buttonStopRefinements);
        Controls.Add(checkBoxShowEachPeaks);
        Controls.Add(statusStrip1);
        Controls.Add(panel1);
        Name = "FormFindParameter";
        FormClosing += FormFindParameter_FormClosing;
        Load += FormCLandWL_Load;
        VisibleChanged += FormFindParameter_VisibleChanged;
        Resize += FormFindParameter_Resize;
        ((ISupportInitialize)numericUpDownBandWidth).EndInit();
        ((ISupportInitialize)numericUpDownSearchRange).EndInit();
        groupBoxPrimaryImage.ResumeLayout(false);
        groupBoxPrimaryImage.PerformLayout();
        ((ISupportInitialize)pictureBoxPattern1).EndInit();
        groupBoxSecondaryImage.ResumeLayout(false);
        groupBoxSecondaryImage.PerformLayout();
        ((ISupportInitialize)pictureBoxPattern2).EndInit();
        groupBoxOption.ResumeLayout(false);
        groupBoxOption.PerformLayout();
        ((ISupportInitialize)numericUpDownRepitition).EndInit();
        ((ISupportInitialize)numericUpDownThresholdOfPeak).EndInit();
        ((ISupportInitialize)numericUpDownDivision).EndInit();
        groupBoxParameter.ResumeLayout(false);
        groupBoxParameter.PerformLayout();
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        ((ISupportInitialize)dataGridView).EndInit();
        contextMenuStrip1.ResumeLayout(false);
        ((ISupportInitialize)pictureBoxMain).EndInit();
        ((ISupportInitialize)pictureBoxPixelKsi).EndInit();
        ((ISupportInitialize)pictureBoxPixelSizeY).EndInit();
        ((ISupportInitialize)pictureBoxPixelSizeX).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionTau2).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionTau1).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionPhi2).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrectionPhi1).EndInit();
        ((ISupportInitialize)pictureBoxCameraLength).EndInit();
        ((ISupportInitialize)pictureBoxResidual).EndInit();
        ((ISupportInitialize)pictureBoxWaveLength).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrection2).EndInit();
        ((ISupportInitialize)pictureBoxTiltCorrection1).EndInit();
        statusStrip1.ResumeLayout(false);
        statusStrip1.PerformLayout();
        groupBoxPeakList.ResumeLayout(false);
        groupBoxPeakList.PerformLayout();
        panel1.ResumeLayout(false);
        panel1.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
    #endregion

    private Button buttonClearGraphs;
    private Button buttonCopyToClipboard;
    private Button buttonGetCameraLenghtFromWholePattern;
    private Button buttonGetWaveLengthFromWholePattern;
    private Button buttonOpenPrimaryImage;
    private Button buttonOpenSecondaryImage;
    private Button buttonPrimaryGetProfile;
    private Button buttonSchematicDiagram;
    private Button buttonSecondaryGetProfile;
    private Button buttonSendMainForm;
    private Button buttonSetInitioalParam;
    private CheckBox checkBoxRefineFilmDistance;
    private CheckBox checkBoxRefinePixelDistortion;
    private CheckBox checkBoxRefinePixelSize;
    private CheckBox checkBoxRefineTiltCorrection;
    private CheckBox checkBoxRefineWaveLength;
    private DataGridView dataGridView;
    private GroupBox groupBoxOption;
    private GroupBox groupBoxPrimaryImage;
    private GroupBox groupBoxParameter;
    private GroupBox groupBoxSecondaryImage;
    private Label label10;
    private Label label11;
    private Label label13;
    private Label label16;
    private Label label17;
    private Label label18;
    private Label label2;
    private Label label20;
    private Label label21;
    private Label label27;
    private Label label28;
    private Label label3;
    private Label label30;
    private Label label35;
    private Label label36;
    private Label label37;
    private Label label38;
    private Label label39;
    private Label label4;
    private Label label40;
    private Label label41;
    private Label label42;
    private Label label43;
    private Label label44;
    private Label label45;
    private Label label46;
    private Label label48;
    private Label label49;
    private Label label5;
    private Label label50;
    private Label label51;
    private Label label52;
    private Label label53;
    private Label label54;
    private Label label55;
    private Label label56;
    private Label label57;
    private Label label58;
    private Label label6;
    private Label label60;
    private Label label61;
    private Label label62;
    private Label label63;
    private Label label64;
    private Label label67;
    private Label label68;
    private Label label69;
    private Label label70;
    private Label label71;
    private Label label72;
    private Label label73;
    private Label label74;
    private Label label76;
    private Label label79;
    private Label label8;
    private Label label80;
    private Label label9;
    private NumericUpDown numericUpDownBandWidth;
    private NumericUpDown numericUpDownDivision;
    private NumericUpDown numericUpDownRepitition;
    private NumericUpDown numericUpDownSearchRange;
    private NumericUpDown numericUpDownThresholdOfPeak;
    private PictureBox pictureBoxCameraLength;
    private PictureBox pictureBoxMain;
    private PictureBox pictureBoxPattern1;
    private PictureBox pictureBoxPattern2;
    private PictureBox pictureBoxPixelKsi;
    private PictureBox pictureBoxPixelSizeX;
    private PictureBox pictureBoxPixelSizeY;
    private PictureBox pictureBoxResidual;
    private PictureBox pictureBoxTiltCorrection1;
    private PictureBox pictureBoxTiltCorrection2;
    private PictureBox pictureBoxTiltCorrectionPhi1;
    private PictureBox pictureBoxTiltCorrectionPhi2;
    private PictureBox pictureBoxTiltCorrectionTau1;
    private PictureBox pictureBoxTiltCorrectionTau2;
    private PictureBox pictureBoxWaveLength;
    private RadioButton radioButtonRectangle;
    private RadioButton radioButtonSector;
    private System.Windows.Forms.Label label14;
    private System.Windows.Forms.Label label19;
    private System.Windows.Forms.Label label24;
    private System.Windows.Forms.Label label25;
    private System.Windows.Forms.Label label26;
    private System.Windows.Forms.Label label7;
    private Crystallography.Controls.NumericBox textBoxCameraLengthDev;
    private Crystallography.Controls.NumericBox textBoxPixelSizeXDev;
    private Crystallography.Controls.NumericBox textBoxRefinedPixelSizeX;
    private Crystallography.Controls.NumericBox textBoxRefinedPrimaryFilmDistance;
    private Crystallography.Controls.NumericBox textBoxRefinedWaveLength;
    private Crystallography.Controls.NumericBox textBoxWaveLengthDev;
    public Crystallography.Controls.NumericBox textBoxRefinedPixelKsi;
    public Crystallography.Controls.NumericBox textBoxRefinedPixelKsiDev;
    public Crystallography.Controls.NumericBox textBoxRefinedPrimaryPhi;
    public Crystallography.Controls.NumericBox textBoxRefinedPrimaryPhiDev;
    public Crystallography.Controls.NumericBox textBoxRefinedPrimaryTau;
    public Crystallography.Controls.NumericBox textBoxRefinedPrimaryTauDev;
    public Crystallography.Controls.NumericBox textBoxRefinedSecondaryPhi;
    public Crystallography.Controls.NumericBox textBoxRefinedSecondaryPhiDev;
    public Crystallography.Controls.NumericBox textBoxRefinedSecondaryTau;
    public Crystallography.Controls.NumericBox textBoxRefinedSecondaryTauDev;
    private ToolTip toolTipJapanese;
    public CheckBox checkBoxPeakDecomposition;
    public CheckBox checkBoxRefleshMainform;
    public CheckBox checkBoxUseStandardCrystal;
    public Crystallography.Controls.NumericBox numericalTextBoxPrimaryCenterPositionX;
    public Crystallography.Controls.NumericBox numericTextBoxPrimaryCenterPositionY;
    public Crystallography.Controls.NumericBox numericTextBoxPrimaryFilmDistance;
    public Crystallography.Controls.NumericBox numericTextBoxSecondaryCenterPositionX;
    public Crystallography.Controls.NumericBox numericTextBoxSecondaryCenterPositionY;
    public Label label15;
    public Label label34;
    public Label label47;
    public Label label59;
    public Label label65;
    public Label label66;
    public Label label77;
    public Label label78;
    public Crystallography.Controls.NumericBox textBoxFilmDistanceDiscrepancy;
    public Crystallography.Controls.NumericBox textBoxPixelKsi;
    public Crystallography.Controls.NumericBox textBoxPixelSizeX;
    public Crystallography.Controls.NumericBox textBoxPixelSizeY;
    public Crystallography.Controls.NumericBox textBoxPixelSizeYDev;
    public TextBox textBoxPrimaryFileName;
    public Crystallography.Controls.NumericBox textBoxPrimaryFilmDistanceCopy;
    public Crystallography.Controls.NumericBox textBoxPrimaryFilmDistanceCopy2;
    public Crystallography.Controls.NumericBox textBoxRefinedPixelSizeY;
    public TextBox textBoxSecondaryFileName;
    public Crystallography.Controls.NumericBox textBoxTiltCorrectionPrimaryPhi;
    public Crystallography.Controls.NumericBox textBoxTiltCorrectionPrimaryTau;
    public Crystallography.Controls.NumericBox textBoxTiltCorrectionSecondaryPhi;
    public Crystallography.Controls.NumericBox textBoxTiltCorrectionSecondaryTau;
    public Crystallography.Controls.NumericBox textBoxWaveLength;
    private System.Windows.Forms.Label label1;
    private Label label22;
    private Button buttonSetStandardCrystal;
    private FlowLayoutPanel flowLayoutPanel1;
    private RadioButton radioButton1;
    private RadioButton radioButton2;
    private Crystallography.Controls.NumericBox numericalTextBoxPrimaryCenterPositionYDev;
    private Label label23;
    private Crystallography.Controls.NumericBox numericalTextBoxPrimaryCenterPositionXDev;
    private Crystallography.Controls.NumericBox numericTextBoxSecondaryCenterPositionYDev;
    private Crystallography.Controls.NumericBox numericTextBoxSecondaryCenterPositionXDev;
    private Label label31;
    private Label label29;
    private Label label32;
    public Button buttonExecuteRefinements;
    private Button buttonGetCenterPositionFromMainForm;
    private Button buttonGetCenterPositionFromMainForm2;
    public Button buttonStopRefinements;
    public BackgroundWorker backgroundWorkerRefine;
    private CheckBox checkBoxSphericalCorrection;
    public Crystallography.Controls.NumericBox numericalTextBoxSphericalRadius;
    public Crystallography.Controls.NumericBox numericalTextBoxRadiusInverseDev;
    public Crystallography.Controls.NumericBox numericalTextBoxRefinedSphericalRadius;
    private Label label33;
    private Label label81;
    private Label label75;
    private Label label82;
    private StatusStrip statusStrip1;
    private ToolStripProgressBar toolStripProgressBar1;
    private ToolStripStatusLabel toolStripStatusLabel1;
    private GroupBox groupBoxPeakList;
    private Panel panel1;
    public CheckBox checkBoxMouseOperation;
    private FlowLayoutPanel flowLayoutPanelEachPeaks;
    private CheckBox checkBoxShowEachPeaks;
    private ContextMenuStrip contextMenuStrip1;
    private ToolStripMenuItem checkUncheckToolStripMenuItem;
    private DataGridViewTextBoxColumn ColumnNo;
    private DataGridViewTextBoxColumn ColumnHKL;
    private DataGridViewCheckBoxColumn ColumnPrimaryCheck;
    private DataGridViewTextBoxColumn ColumnPrimary;
    private DataGridViewCheckBoxColumn ColumnSecondaryCheck;
    private DataGridViewTextBoxColumn ColumnSecondary;
    public Crystallography.Controls.NumericBox numericBoxPrimaryImageNum;
    public Crystallography.Controls.NumericBox numericBoxSecondaryImageNum;
    private CheckBox checkBoxCenterPosition;
    private Button buttonClearPrimaryImage;
    private Button buttonClearSecondaryImage;
    private Button buttonCheckPeaks;
    public Crystallography.Controls.NumericBox numericBoxAwayFrom;
    public Crystallography.Controls.NumericBox numericBoxLowerThan;
}