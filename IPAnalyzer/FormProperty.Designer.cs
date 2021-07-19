namespace IPAnalyzer
{
    partial class FormProperty
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        public System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProperty));
            IPAnalyzer.Properties.Settings settings1 = new IPAnalyzer.Properties.Settings();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageXRay = new System.Windows.Forms.TabPage();
            this.label15 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.checkBoxCorrectPolarization = new System.Windows.Forms.CheckBox();
            this.waveLengthControl = new Crystallography.Controls.WaveLengthControl();
            this.tabPageIP = new System.Windows.Forms.TabPage();
            this.radioButtonGandlfi = new System.Windows.Forms.RadioButton();
            this.radioButtonFlatPanel = new System.Windows.Forms.RadioButton();
            this.buttonOptimizeSaclaEH5Parameter = new System.Windows.Forms.Button();
            this.groupBoxCameaLength = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxCameraLength = new Crystallography.Controls.NumericBox();
            this.groupBoxDirectSpotPosition = new System.Windows.Forms.GroupBox();
            this.numericBoxCenterPositionY = new Crystallography.Controls.NumericBox();
            this.numericBoxCenterPositionX = new Crystallography.Controls.NumericBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.groupBoxPixelShape = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxPixelKsi = new Crystallography.Controls.NumericBox();
            this.numericBoxPixelSizeY = new Crystallography.Controls.NumericBox();
            this.numericBoxPixelSizeX = new Crystallography.Controls.NumericBox();
            this.checkBoxTiltCorrection = new System.Windows.Forms.CheckBox();
            this.groupBoxGandlfiRadius = new System.Windows.Forms.GroupBox();
            this.numericBoxGandlfiRadius = new Crystallography.Controls.NumericBox();
            this.groupBoxSphericalCorrection = new System.Windows.Forms.GroupBox();
            this.numericalTextBoxSphericalCorections = new Crystallography.Controls.NumericBox();
            this.groupBoxTiltCorrection = new System.Windows.Forms.GroupBox();
            this.numericBoxTiltCorrectionTau = new Crystallography.Controls.NumericBox();
            this.numericBoxTiltCorrectionPhi = new Crystallography.Controls.NumericBox();
            this.saclaControl = new Crystallography.Controls.SaclaControl();
            this.checkBoxSACLA = new System.Windows.Forms.CheckBox();
            this.tabPageIntegralRegion = new System.Windows.Forms.TabPage();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.numericUpDownThresholdOfIntensityMax = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBoxThresholdMax = new System.Windows.Forms.CheckBox();
            this.checkBoxThresholdMin = new System.Windows.Forms.CheckBox();
            this.numericUpDownThresholdOfIntensityMin = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownEdge = new System.Windows.Forms.NumericUpDown();
            this.checkBoxOmitSpots = new System.Windows.Forms.CheckBox();
            this.checkBoxMaskEdge = new System.Windows.Forms.CheckBox();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.groupBoxRectangle = new System.Windows.Forms.GroupBox();
            this.checkBoxRectangleIsBothSide = new System.Windows.Forms.CheckBox();
            this.comboBoxRectangleDirection = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.numericUpDownRectangleBand = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownRectangleAngle = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.radioButtonSector = new System.Windows.Forms.RadioButton();
            this.groupBoxSector = new System.Windows.Forms.GroupBox();
            this.numericUpDownSectorStartAngle = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownSectorEndAngle = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tabPageIntegralProperty = new System.Windows.Forms.TabPage();
            this.radioButtonRadial = new System.Windows.Forms.RadioButton();
            this.groupBoxRadial = new System.Windows.Forms.GroupBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.numericBoxRadialRange = new Crystallography.Controls.NumericBox();
            this.numericBoxRadialRadius = new Crystallography.Controls.NumericBox();
            this.numericBoxRadialStep = new Crystallography.Controls.NumericBox();
            this.radioButtonRadialAngle = new System.Windows.Forms.RadioButton();
            this.radioButtonRadialDspacing = new System.Windows.Forms.RadioButton();
            this.labelDimensionRadial2 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.labelDimensionRadial1 = new System.Windows.Forms.Label();
            this.radioButtonConcentric = new System.Windows.Forms.RadioButton();
            this.groupBoxConcentric = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.numericBoxConcentricStep = new Crystallography.Controls.NumericBox();
            this.radioButtonConcentricLength = new System.Windows.Forms.RadioButton();
            this.numericBoxConcentricEnd = new Crystallography.Controls.NumericBox();
            this.radioButtonConcentricDspacing = new System.Windows.Forms.RadioButton();
            this.numericBoxConcentricStart = new Crystallography.Controls.NumericBox();
            this.radioButtonConcentricAngle = new System.Windows.Forms.RadioButton();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelIntegralDimension3 = new System.Windows.Forms.Label();
            this.labelIntegralDimension1 = new System.Windows.Forms.Label();
            this.labelIntegralDimension2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButtonBraggBrentano = new System.Windows.Forms.RadioButton();
            this.radioButtonDebyeScherrer = new System.Windows.Forms.RadioButton();
            this.tabPageSpotsAndCenter = new System.Windows.Forms.TabPage();
            this.checkBoxManualMaskMode = new System.Windows.Forms.CheckBox();
            this.groupBoxManualMode = new System.Windows.Forms.GroupBox();
            this.radioButtonManualCircle = new System.Windows.Forms.RadioButton();
            this.radioButtonManualSpline = new System.Windows.Forms.RadioButton();
            this.radioButtonManualRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonManualSpot = new System.Windows.Forms.RadioButton();
            this.groupBoxManualSpot = new System.Windows.Forms.GroupBox();
            this.textBoxManualSpotSize = new System.Windows.Forms.TextBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.numericUpDownManualSpotSize = new System.Windows.Forms.NumericUpDown();
            this.label30 = new System.Windows.Forms.Label();
            this.radioButtonCircle = new System.Windows.Forms.RadioButton();
            this.groupBoxSpline = new System.Windows.Forms.GroupBox();
            this.label48 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.numericUpDownSplineWidth = new System.Windows.Forms.NumericUpDown();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.radioButtonTakeOverMaskfile = new System.Windows.Forms.RadioButton();
            this.radioButtonTakeoverMask = new System.Windows.Forms.RadioButton();
            this.radioButtonTakoverNothing = new System.Windows.Forms.RadioButton();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.numericUpDownFindSpotsDeviation = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.buttonMaskAll = new System.Windows.Forms.Button();
            this.buttonUnmaskAll = new System.Windows.Forms.Button();
            this.tabPageAfterGetProfile = new System.Windows.Forms.TabPage();
            this.numericBoxTest = new Crystallography.Controls.NumericBox();
            this.checkBoxTest = new System.Windows.Forms.CheckBox();
            this.checkBoxSendProfileToPDIndexer = new System.Windows.Forms.CheckBox();
            this.checkBoxSaveFile = new System.Windows.Forms.CheckBox();
            this.groupBoxSaveProfile = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonAsPDIformat = new System.Windows.Forms.RadioButton();
            this.radioButtonAsCSVformat = new System.Windows.Forms.RadioButton();
            this.radioButtonAsTSVformat = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonSetDirectoryEachTime = new System.Windows.Forms.RadioButton();
            this.radioButtonSaveAtImageDirectory = new System.Windows.Forms.RadioButton();
            this.groupBoxSendPDI = new System.Windows.Forms.GroupBox();
            this.checkBoxSendUnrolledImageToPDIndexer = new System.Windows.Forms.CheckBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.numericUpDownUnrollChiDivision = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.numericUpDownUnrolledImageXend = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownUnrolledImageXstart = new System.Windows.Forms.NumericUpDown();
            this.label38 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.numericUpDownUnrolledImageXstep = new System.Windows.Forms.NumericUpDown();
            this.label24 = new System.Windows.Forms.Label();
            this.label42 = new System.Windows.Forms.Label();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.checkBoxExtensionIPA = new System.Windows.Forms.CheckBox();
            this.checkBoxExtensionIPF = new System.Windows.Forms.CheckBox();
            this.checkBoxExtensionIMG = new System.Windows.Forms.CheckBox();
            this.checkBoxExtensionCCD = new System.Windows.Forms.CheckBox();
            this.checkBoxExtensionSTL = new System.Windows.Forms.CheckBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.label50 = new System.Windows.Forms.Label();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonChiClockwise = new System.Windows.Forms.RadioButton();
            this.radioButtonChiCounterclockwise = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.radioButtonChiLeft = new System.Windows.Forms.RadioButton();
            this.radioButtonChiBottom = new System.Windows.Forms.RadioButton();
            this.radioButtonChiTop = new System.Windows.Forms.RadioButton();
            this.radioButtonChiRight = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.numericBoxFindCenterPeakFittingRange = new Crystallography.Controls.NumericBox();
            this.flowLayoutPanelFindCenterOption = new System.Windows.Forms.FlowLayoutPanel();
            this.numericBoxFindCenterSearchArea = new Crystallography.Controls.NumericBox();
            this.checkBoxExcludeMaskedPixels = new System.Windows.Forms.CheckBox();
            this.checkBoxFixCenter = new System.Windows.Forms.CheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.textBoxBackgroundImage = new System.Windows.Forms.TextBox();
            this.buttonClearBackgroundImage = new System.Windows.Forms.Button();
            this.buttonSetBackgroundImage = new System.Windows.Forms.Button();
            this.numericBoxBackgroundCoeff = new Crystallography.Controls.NumericBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.numericUpDownMaskEdge = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageXRay.SuspendLayout();
            this.tabPageIP.SuspendLayout();
            this.groupBoxCameaLength.SuspendLayout();
            this.groupBoxDirectSpotPosition.SuspendLayout();
            this.groupBoxPixelShape.SuspendLayout();
            this.groupBoxGandlfiRadius.SuspendLayout();
            this.groupBoxSphericalCorrection.SuspendLayout();
            this.groupBoxTiltCorrection.SuspendLayout();
            this.tabPageIntegralRegion.SuspendLayout();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfIntensityMax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfIntensityMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdge)).BeginInit();
            this.groupBoxRectangle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangleBand)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangleAngle)).BeginInit();
            this.groupBoxSector.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectorStartAngle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectorEndAngle)).BeginInit();
            this.tabPageIntegralProperty.SuspendLayout();
            this.groupBoxRadial.SuspendLayout();
            this.groupBoxConcentric.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabPageSpotsAndCenter.SuspendLayout();
            this.groupBoxManualMode.SuspendLayout();
            this.groupBoxManualSpot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpotSize)).BeginInit();
            this.groupBoxSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplineWidth)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindSpotsDeviation)).BeginInit();
            this.tabPageAfterGetProfile.SuspendLayout();
            this.groupBoxSaveProfile.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxSendPDI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrollChiDivision)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXstart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXstep)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.flowLayoutPanelFindCenterOption.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaskEdge)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Controls.Add(this.tabPageXRay);
            this.tabControl.Controls.Add(this.tabPageIP);
            this.tabControl.Controls.Add(this.tabPageIntegralRegion);
            this.tabControl.Controls.Add(this.tabPageIntegralProperty);
            this.tabControl.Controls.Add(this.tabPageSpotsAndCenter);
            this.tabControl.Controls.Add(this.tabPageAfterGetProfile);
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage5);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControl.HotTrack = true;
            this.tabControl.Multiline = true;
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.tabControl1_DrawItem);
            // 
            // tabPageXRay
            // 
            resources.ApplyResources(this.tabPageXRay, "tabPageXRay");
            this.tabPageXRay.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageXRay.Controls.Add(this.label15);
            this.tabPageXRay.Controls.Add(this.label6);
            this.tabPageXRay.Controls.Add(this.checkBoxCorrectPolarization);
            this.tabPageXRay.Controls.Add(this.waveLengthControl);
            this.tabPageXRay.Name = "tabPageXRay";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // checkBoxCorrectPolarization
            // 
            resources.ApplyResources(this.checkBoxCorrectPolarization, "checkBoxCorrectPolarization");
            this.checkBoxCorrectPolarization.Name = "checkBoxCorrectPolarization";
            this.checkBoxCorrectPolarization.UseVisualStyleBackColor = true;
            this.checkBoxCorrectPolarization.CheckedChanged += new System.EventHandler(this.checkBoxCorrectPolarization_CheckedChanged);
            // 
            // waveLengthControl
            // 
            resources.ApplyResources(this.waveLengthControl, "waveLengthControl");
            this.waveLengthControl.Energy = 17.4441967201D;
            this.waveLengthControl.Name = "waveLengthControl";
            this.waveLengthControl.ShowWaveSource = true;
            this.waveLengthControl.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.waveLengthControl.WaveLength = 0.07107471D;
            this.waveLengthControl.WaveSource = Crystallography.WaveSource.Xray;
            this.waveLengthControl.XrayWaveSourceElementNumber = 42;
            this.waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka;
            // 
            // tabPageIP
            // 
            resources.ApplyResources(this.tabPageIP, "tabPageIP");
            this.tabPageIP.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageIP.Controls.Add(this.radioButtonGandlfi);
            this.tabPageIP.Controls.Add(this.radioButtonFlatPanel);
            this.tabPageIP.Controls.Add(this.buttonOptimizeSaclaEH5Parameter);
            this.tabPageIP.Controls.Add(this.groupBoxCameaLength);
            this.tabPageIP.Controls.Add(this.groupBoxDirectSpotPosition);
            this.tabPageIP.Controls.Add(this.checkBox1);
            this.tabPageIP.Controls.Add(this.groupBoxPixelShape);
            this.tabPageIP.Controls.Add(this.checkBoxTiltCorrection);
            this.tabPageIP.Controls.Add(this.groupBoxGandlfiRadius);
            this.tabPageIP.Controls.Add(this.groupBoxSphericalCorrection);
            this.tabPageIP.Controls.Add(this.groupBoxTiltCorrection);
            this.tabPageIP.Controls.Add(this.saclaControl);
            this.tabPageIP.Controls.Add(this.checkBoxSACLA);
            this.tabPageIP.Name = "tabPageIP";
            // 
            // radioButtonGandlfi
            // 
            resources.ApplyResources(this.radioButtonGandlfi, "radioButtonGandlfi");
            this.radioButtonGandlfi.Name = "radioButtonGandlfi";
            this.radioButtonGandlfi.UseVisualStyleBackColor = true;
            // 
            // radioButtonFlatPanel
            // 
            resources.ApplyResources(this.radioButtonFlatPanel, "radioButtonFlatPanel");
            this.radioButtonFlatPanel.Checked = true;
            this.radioButtonFlatPanel.Name = "radioButtonFlatPanel";
            this.radioButtonFlatPanel.TabStop = true;
            this.radioButtonFlatPanel.UseVisualStyleBackColor = true;
            this.radioButtonFlatPanel.CheckedChanged += new System.EventHandler(this.radioButtonFlatPanel_CheckedChanged);
            // 
            // buttonOptimizeSaclaEH5Parameter
            // 
            resources.ApplyResources(this.buttonOptimizeSaclaEH5Parameter, "buttonOptimizeSaclaEH5Parameter");
            this.buttonOptimizeSaclaEH5Parameter.Name = "buttonOptimizeSaclaEH5Parameter";
            this.buttonOptimizeSaclaEH5Parameter.UseVisualStyleBackColor = true;
            this.buttonOptimizeSaclaEH5Parameter.Click += new System.EventHandler(this.buttonOptimizeSaclaEH5Parameter_Click);
            // 
            // groupBoxCameaLength
            // 
            resources.ApplyResources(this.groupBoxCameaLength, "groupBoxCameaLength");
            this.groupBoxCameaLength.Controls.Add(this.numericalTextBoxCameraLength);
            this.groupBoxCameaLength.Name = "groupBoxCameaLength";
            this.groupBoxCameaLength.TabStop = false;
            // 
            // numericalTextBoxCameraLength
            // 
            resources.ApplyResources(this.numericalTextBoxCameraLength, "numericalTextBoxCameraLength");
            this.numericalTextBoxCameraLength.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCameraLength.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCameraLength.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCameraLength.Name = "numericalTextBoxCameraLength";
            this.numericalTextBoxCameraLength.RadianValue = 7.7667151713747664D;
            this.numericalTextBoxCameraLength.RoundErrorAccuracy = 10;
            this.numericalTextBoxCameraLength.SkipEventDuringInput = false;
            this.numericalTextBoxCameraLength.SmartIncrement = true;
            this.numericalTextBoxCameraLength.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxCameraLength.ThonsandsSeparator = true;
            this.numericalTextBoxCameraLength.Value = 445D;
            this.numericalTextBoxCameraLength.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxDirectSpotPosition
            // 
            resources.ApplyResources(this.groupBoxDirectSpotPosition, "groupBoxDirectSpotPosition");
            this.groupBoxDirectSpotPosition.Controls.Add(this.numericBoxCenterPositionY);
            this.groupBoxDirectSpotPosition.Controls.Add(this.numericBoxCenterPositionX);
            this.groupBoxDirectSpotPosition.Name = "groupBoxDirectSpotPosition";
            this.groupBoxDirectSpotPosition.TabStop = false;
            // 
            // numericBoxCenterPositionY
            // 
            resources.ApplyResources(this.numericBoxCenterPositionY, "numericBoxCenterPositionY");
            this.numericBoxCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionY.Name = "numericBoxCenterPositionY";
            this.numericBoxCenterPositionY.RadianValue = 26.179938779914945D;
            this.numericBoxCenterPositionY.RoundErrorAccuracy = 10;
            this.numericBoxCenterPositionY.SkipEventDuringInput = false;
            this.numericBoxCenterPositionY.SmartIncrement = true;
            this.numericBoxCenterPositionY.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxCenterPositionY.ThonsandsSeparator = true;
            this.numericBoxCenterPositionY.Value = 1500D;
            this.numericBoxCenterPositionY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxCenterPositionX
            // 
            resources.ApplyResources(this.numericBoxCenterPositionX, "numericBoxCenterPositionX");
            this.numericBoxCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionX.Name = "numericBoxCenterPositionX";
            this.numericBoxCenterPositionX.RadianValue = 26.179938779914945D;
            this.numericBoxCenterPositionX.RoundErrorAccuracy = 10;
            this.numericBoxCenterPositionX.SkipEventDuringInput = false;
            this.numericBoxCenterPositionX.SmartIncrement = true;
            this.numericBoxCenterPositionX.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxCenterPositionX.ThonsandsSeparator = true;
            this.numericBoxCenterPositionX.Value = 1500D;
            this.numericBoxCenterPositionX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBoxTiltCorrection_CheckedChanged);
            // 
            // groupBoxPixelShape
            // 
            resources.ApplyResources(this.groupBoxPixelShape, "groupBoxPixelShape");
            this.groupBoxPixelShape.Controls.Add(this.numericalTextBoxPixelKsi);
            this.groupBoxPixelShape.Controls.Add(this.numericBoxPixelSizeY);
            this.groupBoxPixelShape.Controls.Add(this.numericBoxPixelSizeX);
            this.groupBoxPixelShape.Name = "groupBoxPixelShape";
            this.groupBoxPixelShape.TabStop = false;
            // 
            // numericalTextBoxPixelKsi
            // 
            resources.ApplyResources(this.numericalTextBoxPixelKsi, "numericalTextBoxPixelKsi");
            this.numericalTextBoxPixelKsi.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPixelKsi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPixelKsi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPixelKsi.Name = "numericalTextBoxPixelKsi";
            this.numericalTextBoxPixelKsi.RoundErrorAccuracy = 10;
            this.numericalTextBoxPixelKsi.SkipEventDuringInput = false;
            this.numericalTextBoxPixelKsi.SmartIncrement = true;
            this.numericalTextBoxPixelKsi.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPixelKsi.ThonsandsSeparator = true;
            this.numericalTextBoxPixelKsi.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxPixelSizeY
            // 
            resources.ApplyResources(this.numericBoxPixelSizeY, "numericBoxPixelSizeY");
            this.numericBoxPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeY.Name = "numericBoxPixelSizeY";
            this.numericBoxPixelSizeY.RadianValue = 0.0017453292519943296D;
            this.numericBoxPixelSizeY.RoundErrorAccuracy = 10;
            this.numericBoxPixelSizeY.SkipEventDuringInput = false;
            this.numericBoxPixelSizeY.SmartIncrement = true;
            this.numericBoxPixelSizeY.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPixelSizeY.ThonsandsSeparator = true;
            this.numericBoxPixelSizeY.Value = 0.1D;
            this.numericBoxPixelSizeY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericBoxPixelSizeY.Load += new System.EventHandler(this.numericalTextBoxPixelSizeY_Load);
            // 
            // numericBoxPixelSizeX
            // 
            resources.ApplyResources(this.numericBoxPixelSizeX, "numericBoxPixelSizeX");
            this.numericBoxPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeX.Name = "numericBoxPixelSizeX";
            this.numericBoxPixelSizeX.RadianValue = 0.0017453292519943296D;
            this.numericBoxPixelSizeX.RoundErrorAccuracy = 10;
            this.numericBoxPixelSizeX.SkipEventDuringInput = false;
            this.numericBoxPixelSizeX.SmartIncrement = true;
            this.numericBoxPixelSizeX.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPixelSizeX.ThonsandsSeparator = true;
            this.numericBoxPixelSizeX.Value = 0.1D;
            this.numericBoxPixelSizeX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // checkBoxTiltCorrection
            // 
            resources.ApplyResources(this.checkBoxTiltCorrection, "checkBoxTiltCorrection");
            this.checkBoxTiltCorrection.Checked = true;
            this.checkBoxTiltCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTiltCorrection.Name = "checkBoxTiltCorrection";
            this.checkBoxTiltCorrection.UseVisualStyleBackColor = true;
            this.checkBoxTiltCorrection.CheckedChanged += new System.EventHandler(this.checkBoxTiltCorrection_CheckedChanged);
            // 
            // groupBoxGandlfiRadius
            // 
            resources.ApplyResources(this.groupBoxGandlfiRadius, "groupBoxGandlfiRadius");
            this.groupBoxGandlfiRadius.Controls.Add(this.numericBoxGandlfiRadius);
            this.groupBoxGandlfiRadius.Name = "groupBoxGandlfiRadius";
            this.groupBoxGandlfiRadius.TabStop = false;
            // 
            // numericBoxGandlfiRadius
            // 
            resources.ApplyResources(this.numericBoxGandlfiRadius, "numericBoxGandlfiRadius");
            this.numericBoxGandlfiRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGandlfiRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGandlfiRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGandlfiRadius.Name = "numericBoxGandlfiRadius";
            this.numericBoxGandlfiRadius.RoundErrorAccuracy = 10;
            this.numericBoxGandlfiRadius.SkipEventDuringInput = false;
            this.numericBoxGandlfiRadius.SmartIncrement = true;
            this.numericBoxGandlfiRadius.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxGandlfiRadius.ThonsandsSeparator = true;
            this.numericBoxGandlfiRadius.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxSphericalCorrection
            // 
            resources.ApplyResources(this.groupBoxSphericalCorrection, "groupBoxSphericalCorrection");
            this.groupBoxSphericalCorrection.Controls.Add(this.numericalTextBoxSphericalCorections);
            this.groupBoxSphericalCorrection.Name = "groupBoxSphericalCorrection";
            this.groupBoxSphericalCorrection.TabStop = false;
            // 
            // numericalTextBoxSphericalCorections
            // 
            resources.ApplyResources(this.numericalTextBoxSphericalCorections, "numericalTextBoxSphericalCorections");
            this.numericalTextBoxSphericalCorections.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalCorections.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalCorections.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalCorections.Name = "numericalTextBoxSphericalCorections";
            this.numericalTextBoxSphericalCorections.RoundErrorAccuracy = -1;
            this.numericalTextBoxSphericalCorections.SkipEventDuringInput = false;
            this.numericalTextBoxSphericalCorections.SmartIncrement = true;
            this.numericalTextBoxSphericalCorections.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxSphericalCorections.ThonsandsSeparator = true;
            this.numericalTextBoxSphericalCorections.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxTiltCorrection
            // 
            resources.ApplyResources(this.groupBoxTiltCorrection, "groupBoxTiltCorrection");
            this.groupBoxTiltCorrection.Controls.Add(this.numericBoxTiltCorrectionTau);
            this.groupBoxTiltCorrection.Controls.Add(this.numericBoxTiltCorrectionPhi);
            this.groupBoxTiltCorrection.Name = "groupBoxTiltCorrection";
            this.groupBoxTiltCorrection.TabStop = false;
            // 
            // numericBoxTiltCorrectionTau
            // 
            resources.ApplyResources(this.numericBoxTiltCorrectionTau, "numericBoxTiltCorrectionTau");
            this.numericBoxTiltCorrectionTau.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionTau.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionTau.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionTau.Name = "numericBoxTiltCorrectionTau";
            this.numericBoxTiltCorrectionTau.RoundErrorAccuracy = 10;
            this.numericBoxTiltCorrectionTau.SkipEventDuringInput = false;
            this.numericBoxTiltCorrectionTau.SmartIncrement = true;
            this.numericBoxTiltCorrectionTau.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTiltCorrectionTau.ThonsandsSeparator = true;
            this.numericBoxTiltCorrectionTau.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxTiltCorrectionPhi
            // 
            resources.ApplyResources(this.numericBoxTiltCorrectionPhi, "numericBoxTiltCorrectionPhi");
            this.numericBoxTiltCorrectionPhi.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionPhi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionPhi.Name = "numericBoxTiltCorrectionPhi";
            this.numericBoxTiltCorrectionPhi.RoundErrorAccuracy = 10;
            this.numericBoxTiltCorrectionPhi.SkipEventDuringInput = false;
            this.numericBoxTiltCorrectionPhi.SmartIncrement = true;
            this.numericBoxTiltCorrectionPhi.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTiltCorrectionPhi.ThonsandsSeparator = true;
            this.numericBoxTiltCorrectionPhi.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // saclaControl
            // 
            resources.ApplyResources(this.saclaControl, "saclaControl");
            this.saclaControl.CameraLength2 = 300D;
            this.saclaControl.Foot = ((Crystallography.PointD)(resources.GetObject("saclaControl.Foot")));
            this.saclaControl.Name = "saclaControl";
            this.saclaControl.PhiDegree = 0D;
            this.saclaControl.PhiRadian = 0D;
            this.saclaControl.PixelHeight = 1024D;
            this.saclaControl.PixelSize = 0.05D;
            this.saclaControl.PixelWidth = 1024D;
            this.saclaControl.TauDegree = 20.000000000000007D;
            this.saclaControl.TauRadian = 0.349065850398866D;
            this.saclaControl.ValueChanged += new Crystallography.Controls.SaclaControl.MyEventHandler(this.saclaControl_ValueChanged);
            // 
            // checkBoxSACLA
            // 
            resources.ApplyResources(this.checkBoxSACLA, "checkBoxSACLA");
            this.checkBoxSACLA.Name = "checkBoxSACLA";
            this.checkBoxSACLA.UseVisualStyleBackColor = true;
            this.checkBoxSACLA.CheckedChanged += new System.EventHandler(this.checkBoxSACLA_CheckedChanged);
            // 
            // tabPageIntegralRegion
            // 
            resources.ApplyResources(this.tabPageIntegralRegion, "tabPageIntegralRegion");
            this.tabPageIntegralRegion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageIntegralRegion.Controls.Add(this.groupBox8);
            this.tabPageIntegralRegion.Controls.Add(this.radioButtonRectangle);
            this.tabPageIntegralRegion.Controls.Add(this.groupBoxRectangle);
            this.tabPageIntegralRegion.Controls.Add(this.radioButtonSector);
            this.tabPageIntegralRegion.Controls.Add(this.groupBoxSector);
            this.tabPageIntegralRegion.Name = "tabPageIntegralRegion";
            // 
            // groupBox8
            // 
            resources.ApplyResources(this.groupBox8, "groupBox8");
            this.groupBox8.Controls.Add(this.numericUpDownThresholdOfIntensityMax);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.checkBoxThresholdMax);
            this.groupBox8.Controls.Add(this.checkBoxThresholdMin);
            this.groupBox8.Controls.Add(this.numericUpDownThresholdOfIntensityMin);
            this.groupBox8.Controls.Add(this.numericUpDownEdge);
            this.groupBox8.Controls.Add(this.checkBoxOmitSpots);
            this.groupBox8.Controls.Add(this.checkBoxMaskEdge);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.TabStop = false;
            // 
            // numericUpDownThresholdOfIntensityMax
            // 
            resources.ApplyResources(this.numericUpDownThresholdOfIntensityMax, "numericUpDownThresholdOfIntensityMax");
            this.numericUpDownThresholdOfIntensityMax.Maximum = new decimal(new int[] {
            1410065408,
            2,
            0,
            0});
            this.numericUpDownThresholdOfIntensityMax.Name = "numericUpDownThresholdOfIntensityMax";
            this.numericUpDownThresholdOfIntensityMax.Value = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownThresholdOfIntensityMax.ValueChanged += new System.EventHandler(this.numericUpDownThresholdOfIntensityMax_ValueChanged);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // checkBoxThresholdMax
            // 
            resources.ApplyResources(this.checkBoxThresholdMax, "checkBoxThresholdMax");
            this.checkBoxThresholdMax.Name = "checkBoxThresholdMax";
            this.checkBoxThresholdMax.CheckedChanged += new System.EventHandler(this.checkBoxThreshold_CheckedChanged);
            // 
            // checkBoxThresholdMin
            // 
            resources.ApplyResources(this.checkBoxThresholdMin, "checkBoxThresholdMin");
            this.checkBoxThresholdMin.Name = "checkBoxThresholdMin";
            this.checkBoxThresholdMin.CheckedChanged += new System.EventHandler(this.checkBoxThreshold_CheckedChanged);
            // 
            // numericUpDownThresholdOfIntensityMin
            // 
            resources.ApplyResources(this.numericUpDownThresholdOfIntensityMin, "numericUpDownThresholdOfIntensityMin");
            this.numericUpDownThresholdOfIntensityMin.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numericUpDownThresholdOfIntensityMin.Name = "numericUpDownThresholdOfIntensityMin";
            this.numericUpDownThresholdOfIntensityMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThresholdOfIntensityMin.ValueChanged += new System.EventHandler(this.numericUpDownThresholdOfIntensityMin_ValueChanged);
            // 
            // numericUpDownEdge
            // 
            resources.ApplyResources(this.numericUpDownEdge, "numericUpDownEdge");
            this.numericUpDownEdge.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownEdge.Name = "numericUpDownEdge";
            this.numericUpDownEdge.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownEdge.ValueChanged += new System.EventHandler(this.checkBoxMaskEdge_CheckedChanged_1);
            // 
            // checkBoxOmitSpots
            // 
            resources.ApplyResources(this.checkBoxOmitSpots, "checkBoxOmitSpots");
            this.checkBoxOmitSpots.Checked = true;
            this.checkBoxOmitSpots.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxOmitSpots.Name = "checkBoxOmitSpots";
            // 
            // checkBoxMaskEdge
            // 
            resources.ApplyResources(this.checkBoxMaskEdge, "checkBoxMaskEdge");
            this.checkBoxMaskEdge.Checked = true;
            this.checkBoxMaskEdge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxMaskEdge.Name = "checkBoxMaskEdge";
            this.checkBoxMaskEdge.UseVisualStyleBackColor = true;
            this.checkBoxMaskEdge.CheckedChanged += new System.EventHandler(this.checkBoxMaskEdge_CheckedChanged_1);
            // 
            // radioButtonRectangle
            // 
            resources.ApplyResources(this.radioButtonRectangle, "radioButtonRectangle");
            this.radioButtonRectangle.Checked = true;
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.TabStop = true;
            this.radioButtonRectangle.CheckedChanged += new System.EventHandler(this.radioButtonRectangle_CheckedChanged);
            // 
            // groupBoxRectangle
            // 
            resources.ApplyResources(this.groupBoxRectangle, "groupBoxRectangle");
            this.groupBoxRectangle.Controls.Add(this.checkBoxRectangleIsBothSide);
            this.groupBoxRectangle.Controls.Add(this.comboBoxRectangleDirection);
            this.groupBoxRectangle.Controls.Add(this.label8);
            this.groupBoxRectangle.Controls.Add(this.label7);
            this.groupBoxRectangle.Controls.Add(this.numericUpDownRectangleBand);
            this.groupBoxRectangle.Controls.Add(this.numericUpDownRectangleAngle);
            this.groupBoxRectangle.Controls.Add(this.label9);
            this.groupBoxRectangle.Name = "groupBoxRectangle";
            this.groupBoxRectangle.TabStop = false;
            // 
            // checkBoxRectangleIsBothSide
            // 
            resources.ApplyResources(this.checkBoxRectangleIsBothSide, "checkBoxRectangleIsBothSide");
            this.checkBoxRectangleIsBothSide.Name = "checkBoxRectangleIsBothSide";
            this.checkBoxRectangleIsBothSide.UseVisualStyleBackColor = true;
            this.checkBoxRectangleIsBothSide.CheckedChanged += new System.EventHandler(this.checkBoxRectangleIsBothSide_CheckedChanged);
            // 
            // comboBoxRectangleDirection
            // 
            resources.ApplyResources(this.comboBoxRectangleDirection, "comboBoxRectangleDirection");
            this.comboBoxRectangleDirection.Items.AddRange(new object[] {
            resources.GetString("comboBoxRectangleDirection.Items"),
            resources.GetString("comboBoxRectangleDirection.Items1"),
            resources.GetString("comboBoxRectangleDirection.Items2"),
            resources.GetString("comboBoxRectangleDirection.Items3"),
            resources.GetString("comboBoxRectangleDirection.Items4"),
            resources.GetString("comboBoxRectangleDirection.Items5"),
            resources.GetString("comboBoxRectangleDirection.Items6"),
            resources.GetString("comboBoxRectangleDirection.Items7")});
            this.comboBoxRectangleDirection.Name = "comboBoxRectangleDirection";
            this.comboBoxRectangleDirection.SelectedIndexChanged += new System.EventHandler(this.comboBoxRectangleDirection_SelectedIndexChanged);
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // numericUpDownRectangleBand
            // 
            resources.ApplyResources(this.numericUpDownRectangleBand, "numericUpDownRectangleBand");
            this.numericUpDownRectangleBand.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownRectangleBand.Name = "numericUpDownRectangleBand";
            this.numericUpDownRectangleBand.Value = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.numericUpDownRectangleBand.ValueChanged += new System.EventHandler(this.numericUpDownRectangleBand_ValueChanged);
            // 
            // numericUpDownRectangleAngle
            // 
            resources.ApplyResources(this.numericUpDownRectangleAngle, "numericUpDownRectangleAngle");
            this.numericUpDownRectangleAngle.DecimalPlaces = 3;
            this.numericUpDownRectangleAngle.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownRectangleAngle.Name = "numericUpDownRectangleAngle";
            this.numericUpDownRectangleAngle.ValueChanged += new System.EventHandler(this.numericUpDownRectangleAngle_ValueChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // radioButtonSector
            // 
            resources.ApplyResources(this.radioButtonSector, "radioButtonSector");
            this.radioButtonSector.Name = "radioButtonSector";
            this.radioButtonSector.CheckedChanged += new System.EventHandler(this.radioButtonSector_CheckedChanged);
            // 
            // groupBoxSector
            // 
            resources.ApplyResources(this.groupBoxSector, "groupBoxSector");
            this.groupBoxSector.Controls.Add(this.numericUpDownSectorStartAngle);
            this.groupBoxSector.Controls.Add(this.numericUpDownSectorEndAngle);
            this.groupBoxSector.Controls.Add(this.label10);
            this.groupBoxSector.Controls.Add(this.label11);
            this.groupBoxSector.Name = "groupBoxSector";
            this.groupBoxSector.TabStop = false;
            // 
            // numericUpDownSectorStartAngle
            // 
            resources.ApplyResources(this.numericUpDownSectorStartAngle, "numericUpDownSectorStartAngle");
            this.numericUpDownSectorStartAngle.DecimalPlaces = 2;
            this.numericUpDownSectorStartAngle.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownSectorStartAngle.Minimum = new decimal(new int[] {
            720,
            0,
            0,
            -2147483648});
            this.numericUpDownSectorStartAngle.Name = "numericUpDownSectorStartAngle";
            this.numericUpDownSectorStartAngle.ValueChanged += new System.EventHandler(this.numericUpDownSectorAngle_ValueChanged);
            // 
            // numericUpDownSectorEndAngle
            // 
            resources.ApplyResources(this.numericUpDownSectorEndAngle, "numericUpDownSectorEndAngle");
            this.numericUpDownSectorEndAngle.DecimalPlaces = 2;
            this.numericUpDownSectorEndAngle.Maximum = new decimal(new int[] {
            720,
            0,
            0,
            0});
            this.numericUpDownSectorEndAngle.Name = "numericUpDownSectorEndAngle";
            this.numericUpDownSectorEndAngle.ValueChanged += new System.EventHandler(this.numericUpDownSectorAngle_ValueChanged);
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // tabPageIntegralProperty
            // 
            resources.ApplyResources(this.tabPageIntegralProperty, "tabPageIntegralProperty");
            this.tabPageIntegralProperty.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageIntegralProperty.Controls.Add(this.radioButtonRadial);
            this.tabPageIntegralProperty.Controls.Add(this.groupBoxRadial);
            this.tabPageIntegralProperty.Controls.Add(this.radioButtonConcentric);
            this.tabPageIntegralProperty.Controls.Add(this.groupBoxConcentric);
            this.tabPageIntegralProperty.Name = "tabPageIntegralProperty";
            // 
            // radioButtonRadial
            // 
            resources.ApplyResources(this.radioButtonRadial, "radioButtonRadial");
            this.radioButtonRadial.Name = "radioButtonRadial";
            this.radioButtonRadial.UseVisualStyleBackColor = true;
            // 
            // groupBoxRadial
            // 
            resources.ApplyResources(this.groupBoxRadial, "groupBoxRadial");
            this.groupBoxRadial.Controls.Add(this.label46);
            this.groupBoxRadial.Controls.Add(this.label40);
            this.groupBoxRadial.Controls.Add(this.numericBoxRadialRange);
            this.groupBoxRadial.Controls.Add(this.numericBoxRadialRadius);
            this.groupBoxRadial.Controls.Add(this.numericBoxRadialStep);
            this.groupBoxRadial.Controls.Add(this.radioButtonRadialAngle);
            this.groupBoxRadial.Controls.Add(this.radioButtonRadialDspacing);
            this.groupBoxRadial.Controls.Add(this.labelDimensionRadial2);
            this.groupBoxRadial.Controls.Add(this.label37);
            this.groupBoxRadial.Controls.Add(this.label36);
            this.groupBoxRadial.Controls.Add(this.labelDimensionRadial1);
            this.groupBoxRadial.Name = "groupBoxRadial";
            this.groupBoxRadial.TabStop = false;
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // numericBoxRadialRange
            // 
            resources.ApplyResources(this.numericBoxRadialRange, "numericBoxRadialRange");
            this.numericBoxRadialRange.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRange.DecimalPlaces = 3;
            this.numericBoxRadialRange.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRange.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRange.Name = "numericBoxRadialRange";
            this.numericBoxRadialRange.RadianValue = 0.0017453292519943296D;
            this.numericBoxRadialRange.RoundErrorAccuracy = -1;
            this.numericBoxRadialRange.SkipEventDuringInput = false;
            this.numericBoxRadialRange.SmartIncrement = true;
            this.numericBoxRadialRange.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxRadialRange.ThonsandsSeparator = true;
            this.numericBoxRadialRange.Value = 0.1D;
            this.numericBoxRadialRange.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // numericBoxRadialRadius
            // 
            resources.ApplyResources(this.numericBoxRadialRadius, "numericBoxRadialRadius");
            this.numericBoxRadialRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRadius.DecimalPlaces = 4;
            this.numericBoxRadialRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRadius.Name = "numericBoxRadialRadius";
            this.numericBoxRadialRadius.RadianValue = 0.3490658503988659D;
            this.numericBoxRadialRadius.RoundErrorAccuracy = -1;
            this.numericBoxRadialRadius.SkipEventDuringInput = false;
            this.numericBoxRadialRadius.SmartIncrement = true;
            this.numericBoxRadialRadius.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxRadialRadius.ThonsandsSeparator = true;
            this.numericBoxRadialRadius.Value = 20D;
            this.numericBoxRadialRadius.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // numericBoxRadialStep
            // 
            resources.ApplyResources(this.numericBoxRadialStep, "numericBoxRadialStep");
            this.numericBoxRadialStep.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialStep.DecimalPlaces = 3;
            this.numericBoxRadialStep.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialStep.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialStep.Name = "numericBoxRadialStep";
            this.numericBoxRadialStep.RadianValue = 0.0008726646259971648D;
            this.numericBoxRadialStep.RoundErrorAccuracy = -1;
            this.numericBoxRadialStep.SkipEventDuringInput = false;
            this.numericBoxRadialStep.SmartIncrement = true;
            this.numericBoxRadialStep.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxRadialStep.ThonsandsSeparator = true;
            this.numericBoxRadialStep.Value = 0.05D;
            this.numericBoxRadialStep.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // radioButtonRadialAngle
            // 
            resources.ApplyResources(this.radioButtonRadialAngle, "radioButtonRadialAngle");
            this.radioButtonRadialAngle.Checked = true;
            this.radioButtonRadialAngle.Name = "radioButtonRadialAngle";
            this.radioButtonRadialAngle.TabStop = true;
            this.radioButtonRadialAngle.CheckedChanged += new System.EventHandler(this.radioButtonRadialAngle_CheckedChanged);
            // 
            // radioButtonRadialDspacing
            // 
            resources.ApplyResources(this.radioButtonRadialDspacing, "radioButtonRadialDspacing");
            this.radioButtonRadialDspacing.Name = "radioButtonRadialDspacing";
            // 
            // labelDimensionRadial2
            // 
            resources.ApplyResources(this.labelDimensionRadial2, "labelDimensionRadial2");
            this.labelDimensionRadial2.Name = "labelDimensionRadial2";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // labelDimensionRadial1
            // 
            resources.ApplyResources(this.labelDimensionRadial1, "labelDimensionRadial1");
            this.labelDimensionRadial1.Name = "labelDimensionRadial1";
            // 
            // radioButtonConcentric
            // 
            resources.ApplyResources(this.radioButtonConcentric, "radioButtonConcentric");
            this.radioButtonConcentric.Checked = true;
            this.radioButtonConcentric.Name = "radioButtonConcentric";
            this.radioButtonConcentric.TabStop = true;
            this.radioButtonConcentric.UseVisualStyleBackColor = true;
            this.radioButtonConcentric.CheckedChanged += new System.EventHandler(this.radioButtonRadial_CheckedChanged);
            // 
            // groupBoxConcentric
            // 
            resources.ApplyResources(this.groupBoxConcentric, "groupBoxConcentric");
            this.groupBoxConcentric.Controls.Add(this.groupBox4);
            this.groupBoxConcentric.Controls.Add(this.groupBox5);
            this.groupBoxConcentric.Name = "groupBoxConcentric";
            this.groupBoxConcentric.TabStop = false;
            // 
            // groupBox4
            // 
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Controls.Add(this.numericBoxConcentricStep);
            this.groupBox4.Controls.Add(this.radioButtonConcentricLength);
            this.groupBox4.Controls.Add(this.numericBoxConcentricEnd);
            this.groupBox4.Controls.Add(this.radioButtonConcentricDspacing);
            this.groupBox4.Controls.Add(this.numericBoxConcentricStart);
            this.groupBox4.Controls.Add(this.radioButtonConcentricAngle);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.labelIntegralDimension3);
            this.groupBox4.Controls.Add(this.labelIntegralDimension1);
            this.groupBox4.Controls.Add(this.labelIntegralDimension2);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // numericBoxConcentricStep
            // 
            resources.ApplyResources(this.numericBoxConcentricStep, "numericBoxConcentricStep");
            this.numericBoxConcentricStep.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStep.DecimalPlaces = 4;
            this.numericBoxConcentricStep.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStep.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStep.Name = "numericBoxConcentricStep";
            this.numericBoxConcentricStep.RadianValue = 8.7266462599716482E-05D;
            this.numericBoxConcentricStep.RoundErrorAccuracy = -1;
            this.numericBoxConcentricStep.ShowUpDown = true;
            this.numericBoxConcentricStep.SmartIncrement = true;
            this.numericBoxConcentricStep.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxConcentricStep.ThonsandsSeparator = true;
            this.numericBoxConcentricStep.Value = 0.005D;
            this.numericBoxConcentricStep.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // radioButtonConcentricLength
            // 
            resources.ApplyResources(this.radioButtonConcentricLength, "radioButtonConcentricLength");
            this.radioButtonConcentricLength.Name = "radioButtonConcentricLength";
            this.radioButtonConcentricLength.CheckedChanged += new System.EventHandler(this.radioButtonAngleMode_CheckedChanged);
            // 
            // numericBoxConcentricEnd
            // 
            resources.ApplyResources(this.numericBoxConcentricEnd, "numericBoxConcentricEnd");
            this.numericBoxConcentricEnd.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricEnd.DecimalPlaces = 4;
            this.numericBoxConcentricEnd.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricEnd.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricEnd.Name = "numericBoxConcentricEnd";
            this.numericBoxConcentricEnd.RadianValue = 0.52359877559829882D;
            this.numericBoxConcentricEnd.RoundErrorAccuracy = -1;
            this.numericBoxConcentricEnd.ShowUpDown = true;
            this.numericBoxConcentricEnd.SmartIncrement = true;
            this.numericBoxConcentricEnd.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxConcentricEnd.ThonsandsSeparator = true;
            this.numericBoxConcentricEnd.Value = 30D;
            this.numericBoxConcentricEnd.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // radioButtonConcentricDspacing
            // 
            resources.ApplyResources(this.radioButtonConcentricDspacing, "radioButtonConcentricDspacing");
            this.radioButtonConcentricDspacing.Name = "radioButtonConcentricDspacing";
            this.radioButtonConcentricDspacing.CheckedChanged += new System.EventHandler(this.radioButtonAngleMode_CheckedChanged);
            // 
            // numericBoxConcentricStart
            // 
            resources.ApplyResources(this.numericBoxConcentricStart, "numericBoxConcentricStart");
            this.numericBoxConcentricStart.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStart.DecimalPlaces = 4;
            this.numericBoxConcentricStart.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStart.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStart.Name = "numericBoxConcentricStart";
            this.numericBoxConcentricStart.RadianValue = 0.017453292519943295D;
            this.numericBoxConcentricStart.RoundErrorAccuracy = -1;
            this.numericBoxConcentricStart.ShowUpDown = true;
            this.numericBoxConcentricStart.SmartIncrement = true;
            this.numericBoxConcentricStart.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxConcentricStart.ThonsandsSeparator = true;
            this.numericBoxConcentricStart.Value = 1D;
            this.numericBoxConcentricStart.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // radioButtonConcentricAngle
            // 
            resources.ApplyResources(this.radioButtonConcentricAngle, "radioButtonConcentricAngle");
            this.radioButtonConcentricAngle.Checked = true;
            this.radioButtonConcentricAngle.Name = "radioButtonConcentricAngle";
            this.radioButtonConcentricAngle.TabStop = true;
            this.radioButtonConcentricAngle.CheckedChanged += new System.EventHandler(this.radioButtonAngleMode_CheckedChanged);
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // labelIntegralDimension3
            // 
            resources.ApplyResources(this.labelIntegralDimension3, "labelIntegralDimension3");
            this.labelIntegralDimension3.Name = "labelIntegralDimension3";
            // 
            // labelIntegralDimension1
            // 
            resources.ApplyResources(this.labelIntegralDimension1, "labelIntegralDimension1");
            this.labelIntegralDimension1.Name = "labelIntegralDimension1";
            // 
            // labelIntegralDimension2
            // 
            resources.ApplyResources(this.labelIntegralDimension2, "labelIntegralDimension2");
            this.labelIntegralDimension2.Name = "labelIntegralDimension2";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // groupBox5
            // 
            resources.ApplyResources(this.groupBox5, "groupBox5");
            this.groupBox5.Controls.Add(this.radioButtonBraggBrentano);
            this.groupBox5.Controls.Add(this.radioButtonDebyeScherrer);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.TabStop = false;
            // 
            // radioButtonBraggBrentano
            // 
            resources.ApplyResources(this.radioButtonBraggBrentano, "radioButtonBraggBrentano");
            this.radioButtonBraggBrentano.Checked = true;
            this.radioButtonBraggBrentano.Name = "radioButtonBraggBrentano";
            this.radioButtonBraggBrentano.TabStop = true;
            // 
            // radioButtonDebyeScherrer
            // 
            resources.ApplyResources(this.radioButtonDebyeScherrer, "radioButtonDebyeScherrer");
            this.radioButtonDebyeScherrer.Name = "radioButtonDebyeScherrer";
            // 
            // tabPageSpotsAndCenter
            // 
            resources.ApplyResources(this.tabPageSpotsAndCenter, "tabPageSpotsAndCenter");
            this.tabPageSpotsAndCenter.Controls.Add(this.checkBoxManualMaskMode);
            this.tabPageSpotsAndCenter.Controls.Add(this.groupBoxManualMode);
            this.tabPageSpotsAndCenter.Controls.Add(this.groupBox7);
            this.tabPageSpotsAndCenter.Controls.Add(this.groupBox12);
            this.tabPageSpotsAndCenter.Controls.Add(this.buttonMaskAll);
            this.tabPageSpotsAndCenter.Controls.Add(this.buttonUnmaskAll);
            this.tabPageSpotsAndCenter.Name = "tabPageSpotsAndCenter";
            this.tabPageSpotsAndCenter.UseVisualStyleBackColor = true;
            this.tabPageSpotsAndCenter.Click += new System.EventHandler(this.tabPageSpotsAndCenter_Click);
            // 
            // checkBoxManualMaskMode
            // 
            resources.ApplyResources(this.checkBoxManualMaskMode, "checkBoxManualMaskMode");
            this.checkBoxManualMaskMode.Name = "checkBoxManualMaskMode";
            this.checkBoxManualMaskMode.UseVisualStyleBackColor = true;
            this.checkBoxManualMaskMode.CheckedChanged += new System.EventHandler(this.checkBoxManualMaskMode_CheckedChanged);
            // 
            // groupBoxManualMode
            // 
            resources.ApplyResources(this.groupBoxManualMode, "groupBoxManualMode");
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualCircle);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualSpline);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualRectangle);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualSpot);
            this.groupBoxManualMode.Controls.Add(this.groupBoxManualSpot);
            this.groupBoxManualMode.Controls.Add(this.groupBoxSpline);
            this.groupBoxManualMode.Name = "groupBoxManualMode";
            this.groupBoxManualMode.TabStop = false;
            this.groupBoxManualMode.Enter += new System.EventHandler(this.groupBoxManualMode_Enter);
            // 
            // radioButtonManualCircle
            // 
            resources.ApplyResources(this.radioButtonManualCircle, "radioButtonManualCircle");
            this.radioButtonManualCircle.Name = "radioButtonManualCircle";
            this.radioButtonManualCircle.UseVisualStyleBackColor = true;
            this.radioButtonManualCircle.CheckedChanged += new System.EventHandler(this.radioButtonManualSpot_CheckedChanged);
            // 
            // radioButtonManualSpline
            // 
            resources.ApplyResources(this.radioButtonManualSpline, "radioButtonManualSpline");
            this.radioButtonManualSpline.Name = "radioButtonManualSpline";
            this.radioButtonManualSpline.UseVisualStyleBackColor = true;
            this.radioButtonManualSpline.CheckedChanged += new System.EventHandler(this.radioButtonManualSpot_CheckedChanged);
            // 
            // radioButtonManualRectangle
            // 
            resources.ApplyResources(this.radioButtonManualRectangle, "radioButtonManualRectangle");
            this.radioButtonManualRectangle.Name = "radioButtonManualRectangle";
            this.radioButtonManualRectangle.UseVisualStyleBackColor = true;
            this.radioButtonManualRectangle.CheckedChanged += new System.EventHandler(this.radioButtonManualSpot_CheckedChanged);
            // 
            // radioButtonManualSpot
            // 
            resources.ApplyResources(this.radioButtonManualSpot, "radioButtonManualSpot");
            this.radioButtonManualSpot.Checked = true;
            this.radioButtonManualSpot.Name = "radioButtonManualSpot";
            this.radioButtonManualSpot.TabStop = true;
            this.radioButtonManualSpot.UseVisualStyleBackColor = true;
            this.radioButtonManualSpot.CheckedChanged += new System.EventHandler(this.radioButtonManualSpot_CheckedChanged);
            // 
            // groupBoxManualSpot
            // 
            resources.ApplyResources(this.groupBoxManualSpot, "groupBoxManualSpot");
            this.groupBoxManualSpot.Controls.Add(this.textBoxManualSpotSize);
            this.groupBoxManualSpot.Controls.Add(this.radioButton1);
            this.groupBoxManualSpot.Controls.Add(this.numericUpDownManualSpotSize);
            this.groupBoxManualSpot.Controls.Add(this.label30);
            this.groupBoxManualSpot.Controls.Add(this.radioButtonCircle);
            this.groupBoxManualSpot.Name = "groupBoxManualSpot";
            this.groupBoxManualSpot.TabStop = false;
            // 
            // textBoxManualSpotSize
            // 
            resources.ApplyResources(this.textBoxManualSpotSize, "textBoxManualSpotSize");
            this.textBoxManualSpotSize.Name = "textBoxManualSpotSize";
            this.textBoxManualSpotSize.TextChanged += new System.EventHandler(this.textBoxManualSpotSize_TextChanged);
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownManualSpotSize
            // 
            resources.ApplyResources(this.numericUpDownManualSpotSize, "numericUpDownManualSpotSize");
            this.numericUpDownManualSpotSize.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownManualSpotSize.Name = "numericUpDownManualSpotSize";
            this.numericUpDownManualSpotSize.Value = new decimal(new int[] {
            6,
            0,
            0,
            0});
            this.numericUpDownManualSpotSize.ValueChanged += new System.EventHandler(this.numetricUpDownManualSpotSize_ValueChanged);
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // radioButtonCircle
            // 
            resources.ApplyResources(this.radioButtonCircle, "radioButtonCircle");
            this.radioButtonCircle.Checked = true;
            this.radioButtonCircle.Name = "radioButtonCircle";
            this.radioButtonCircle.TabStop = true;
            this.radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // groupBoxSpline
            // 
            resources.ApplyResources(this.groupBoxSpline, "groupBoxSpline");
            this.groupBoxSpline.Controls.Add(this.label48);
            this.groupBoxSpline.Controls.Add(this.label49);
            this.groupBoxSpline.Controls.Add(this.numericUpDownSplineWidth);
            this.groupBoxSpline.Name = "groupBoxSpline";
            this.groupBoxSpline.TabStop = false;
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // numericUpDownSplineWidth
            // 
            resources.ApplyResources(this.numericUpDownSplineWidth, "numericUpDownSplineWidth");
            this.numericUpDownSplineWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDownSplineWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownSplineWidth.Name = "numericUpDownSplineWidth";
            this.numericUpDownSplineWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numericUpDownSplineWidth.ValueChanged += new System.EventHandler(this.numericUpDownSplineWidth_ValueChanged);
            // 
            // groupBox7
            // 
            resources.ApplyResources(this.groupBox7, "groupBox7");
            this.groupBox7.Controls.Add(this.radioButtonTakeOverMaskfile);
            this.groupBox7.Controls.Add(this.radioButtonTakeoverMask);
            this.groupBox7.Controls.Add(this.radioButtonTakoverNothing);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.TabStop = false;
            // 
            // radioButtonTakeOverMaskfile
            // 
            resources.ApplyResources(this.radioButtonTakeOverMaskfile, "radioButtonTakeOverMaskfile");
            this.radioButtonTakeOverMaskfile.Name = "radioButtonTakeOverMaskfile";
            this.radioButtonTakeOverMaskfile.UseVisualStyleBackColor = true;
            // 
            // radioButtonTakeoverMask
            // 
            resources.ApplyResources(this.radioButtonTakeoverMask, "radioButtonTakeoverMask");
            this.radioButtonTakeoverMask.Checked = true;
            this.radioButtonTakeoverMask.Name = "radioButtonTakeoverMask";
            this.radioButtonTakeoverMask.TabStop = true;
            this.radioButtonTakeoverMask.UseVisualStyleBackColor = true;
            // 
            // radioButtonTakoverNothing
            // 
            resources.ApplyResources(this.radioButtonTakoverNothing, "radioButtonTakoverNothing");
            this.radioButtonTakoverNothing.Name = "radioButtonTakoverNothing";
            this.radioButtonTakoverNothing.UseVisualStyleBackColor = true;
            // 
            // groupBox12
            // 
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.Controls.Add(this.numericUpDownFindSpotsDeviation);
            this.groupBox12.Controls.Add(this.label28);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            // 
            // numericUpDownFindSpotsDeviation
            // 
            resources.ApplyResources(this.numericUpDownFindSpotsDeviation, "numericUpDownFindSpotsDeviation");
            this.numericUpDownFindSpotsDeviation.DecimalPlaces = 2;
            this.numericUpDownFindSpotsDeviation.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownFindSpotsDeviation.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownFindSpotsDeviation.Name = "numericUpDownFindSpotsDeviation";
            this.numericUpDownFindSpotsDeviation.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.Name = "label28";
            // 
            // buttonMaskAll
            // 
            resources.ApplyResources(this.buttonMaskAll, "buttonMaskAll");
            this.buttonMaskAll.Name = "buttonMaskAll";
            this.buttonMaskAll.UseVisualStyleBackColor = true;
            this.buttonMaskAll.Click += new System.EventHandler(this.buttonMaskAll_Click);
            // 
            // buttonUnmaskAll
            // 
            resources.ApplyResources(this.buttonUnmaskAll, "buttonUnmaskAll");
            this.buttonUnmaskAll.Name = "buttonUnmaskAll";
            this.buttonUnmaskAll.UseVisualStyleBackColor = true;
            this.buttonUnmaskAll.Click += new System.EventHandler(this.buttonUnmaskAll_Click);
            // 
            // tabPageAfterGetProfile
            // 
            resources.ApplyResources(this.tabPageAfterGetProfile, "tabPageAfterGetProfile");
            this.tabPageAfterGetProfile.Controls.Add(this.numericBoxTest);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxTest);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxSendProfileToPDIndexer);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxSaveFile);
            this.tabPageAfterGetProfile.Controls.Add(this.groupBoxSaveProfile);
            this.tabPageAfterGetProfile.Controls.Add(this.groupBoxSendPDI);
            this.tabPageAfterGetProfile.Name = "tabPageAfterGetProfile";
            this.tabPageAfterGetProfile.UseVisualStyleBackColor = true;
            // 
            // numericBoxTest
            // 
            resources.ApplyResources(this.numericBoxTest, "numericBoxTest");
            this.numericBoxTest.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTest.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTest.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTest.Maximum = 2D;
            this.numericBoxTest.Minimum = 0D;
            this.numericBoxTest.Name = "numericBoxTest";
            this.numericBoxTest.RadianValue = 0.0087266462599716477D;
            this.numericBoxTest.RoundErrorAccuracy = -1;
            this.numericBoxTest.SkipEventDuringInput = false;
            this.numericBoxTest.SmartIncrement = true;
            this.numericBoxTest.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxTest.ThonsandsSeparator = true;
            this.numericBoxTest.Value = 0.5D;
            // 
            // checkBoxTest
            // 
            resources.ApplyResources(this.checkBoxTest, "checkBoxTest");
            this.checkBoxTest.Checked = true;
            this.checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxTest.Name = "checkBoxTest";
            this.checkBoxTest.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendProfileToPDIndexer
            // 
            resources.ApplyResources(this.checkBoxSendProfileToPDIndexer, "checkBoxSendProfileToPDIndexer");
            this.checkBoxSendProfileToPDIndexer.Checked = true;
            this.checkBoxSendProfileToPDIndexer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSendProfileToPDIndexer.Name = "checkBoxSendProfileToPDIndexer";
            this.checkBoxSendProfileToPDIndexer.CheckedChanged += new System.EventHandler(this.checkBoxSendProfileToPDIndexer_CheckedChanged);
            // 
            // checkBoxSaveFile
            // 
            resources.ApplyResources(this.checkBoxSaveFile, "checkBoxSaveFile");
            this.checkBoxSaveFile.Name = "checkBoxSaveFile";
            this.checkBoxSaveFile.CheckedChanged += new System.EventHandler(this.checkBoxSaveFile_CheckedChanged);
            // 
            // groupBoxSaveProfile
            // 
            resources.ApplyResources(this.groupBoxSaveProfile, "groupBoxSaveProfile");
            this.groupBoxSaveProfile.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxSaveProfile.Controls.Add(this.flowLayoutPanel1);
            this.groupBoxSaveProfile.Name = "groupBoxSaveProfile";
            this.groupBoxSaveProfile.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsPDIformat);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsCSVformat);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsTSVformat);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // radioButtonAsPDIformat
            // 
            resources.ApplyResources(this.radioButtonAsPDIformat, "radioButtonAsPDIformat");
            this.radioButtonAsPDIformat.Name = "radioButtonAsPDIformat";
            this.radioButtonAsPDIformat.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsCSVformat
            // 
            resources.ApplyResources(this.radioButtonAsCSVformat, "radioButtonAsCSVformat");
            this.radioButtonAsCSVformat.Checked = true;
            this.radioButtonAsCSVformat.Name = "radioButtonAsCSVformat";
            this.radioButtonAsCSVformat.TabStop = true;
            this.radioButtonAsCSVformat.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsTSVformat
            // 
            resources.ApplyResources(this.radioButtonAsTSVformat, "radioButtonAsTSVformat");
            this.radioButtonAsTSVformat.Name = "radioButtonAsTSVformat";
            this.radioButtonAsTSVformat.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSetDirectoryEachTime);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSaveAtImageDirectory);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonSetDirectoryEachTime
            // 
            resources.ApplyResources(this.radioButtonSetDirectoryEachTime, "radioButtonSetDirectoryEachTime");
            this.radioButtonSetDirectoryEachTime.Name = "radioButtonSetDirectoryEachTime";
            this.radioButtonSetDirectoryEachTime.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveAtImageDirectory
            // 
            resources.ApplyResources(this.radioButtonSaveAtImageDirectory, "radioButtonSaveAtImageDirectory");
            this.radioButtonSaveAtImageDirectory.Checked = true;
            this.radioButtonSaveAtImageDirectory.Name = "radioButtonSaveAtImageDirectory";
            this.radioButtonSaveAtImageDirectory.TabStop = true;
            this.radioButtonSaveAtImageDirectory.UseVisualStyleBackColor = true;
            // 
            // groupBoxSendPDI
            // 
            resources.ApplyResources(this.groupBoxSendPDI, "groupBoxSendPDI");
            this.groupBoxSendPDI.Controls.Add(this.checkBoxSendUnrolledImageToPDIndexer);
            this.groupBoxSendPDI.Name = "groupBoxSendPDI";
            this.groupBoxSendPDI.TabStop = false;
            // 
            // checkBoxSendUnrolledImageToPDIndexer
            // 
            resources.ApplyResources(this.checkBoxSendUnrolledImageToPDIndexer, "checkBoxSendUnrolledImageToPDIndexer");
            this.checkBoxSendUnrolledImageToPDIndexer.Name = "checkBoxSendUnrolledImageToPDIndexer";
            this.checkBoxSendUnrolledImageToPDIndexer.CheckedChanged += new System.EventHandler(this.checkBoxSendUnrolledImageToPDIndexer_CheckedChanged);
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Controls.Add(this.numericUpDownUnrollChiDivision);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // numericUpDownUnrollChiDivision
            // 
            resources.ApplyResources(this.numericUpDownUnrollChiDivision, "numericUpDownUnrollChiDivision");
            this.numericUpDownUnrollChiDivision.Maximum = new decimal(new int[] {
            2048,
            0,
            0,
            0});
            this.numericUpDownUnrollChiDivision.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownUnrollChiDivision.Name = "numericUpDownUnrollChiDivision";
            this.numericUpDownUnrollChiDivision.Value = new decimal(new int[] {
            720,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.numericUpDownUnrolledImageXend);
            this.groupBox1.Controls.Add(this.numericUpDownUnrolledImageXstart);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.label39);
            this.groupBox1.Controls.Add(this.label25);
            this.groupBox1.Controls.Add(this.label41);
            this.groupBox1.Controls.Add(this.numericUpDownUnrolledImageXstep);
            this.groupBox1.Controls.Add(this.label24);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton4);
            this.groupBox1.Controls.Add(this.radioButton3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numericUpDownUnrolledImageXend
            // 
            resources.ApplyResources(this.numericUpDownUnrolledImageXend, "numericUpDownUnrolledImageXend");
            this.numericUpDownUnrolledImageXend.DecimalPlaces = 3;
            this.numericUpDownUnrolledImageXend.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownUnrolledImageXend.Name = "numericUpDownUnrolledImageXend";
            this.numericUpDownUnrolledImageXend.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // numericUpDownUnrolledImageXstart
            // 
            resources.ApplyResources(this.numericUpDownUnrolledImageXstart, "numericUpDownUnrolledImageXstart");
            this.numericUpDownUnrolledImageXstart.DecimalPlaces = 4;
            this.numericUpDownUnrolledImageXstart.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownUnrolledImageXstart.Maximum = new decimal(new int[] {
            180,
            0,
            0,
            0});
            this.numericUpDownUnrolledImageXstart.Name = "numericUpDownUnrolledImageXstart";
            this.numericUpDownUnrolledImageXstart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // numericUpDownUnrolledImageXstep
            // 
            resources.ApplyResources(this.numericUpDownUnrolledImageXstep, "numericUpDownUnrolledImageXstep");
            this.numericUpDownUnrolledImageXstep.DecimalPlaces = 4;
            this.numericUpDownUnrolledImageXstep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownUnrolledImageXstep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownUnrolledImageXstep.Name = "numericUpDownUnrolledImageXstep";
            this.numericUpDownUnrolledImageXstep.Value = new decimal(new int[] {
            4,
            0,
            0,
            131072});
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            // 
            // radioButton4
            // 
            resources.ApplyResources(this.radioButton4, "radioButton4");
            this.radioButton4.Checked = true;
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.TabStop = true;
            // 
            // radioButton3
            // 
            resources.ApplyResources(this.radioButton3, "radioButton3");
            this.radioButton3.Name = "radioButton3";
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.checkBoxExtensionIPA);
            this.tabPage2.Controls.Add(this.checkBoxExtensionIPF);
            this.tabPage2.Controls.Add(this.checkBoxExtensionIMG);
            this.tabPage2.Controls.Add(this.checkBoxExtensionCCD);
            this.tabPage2.Controls.Add(this.checkBoxExtensionSTL);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // checkBoxExtensionIPA
            // 
            resources.ApplyResources(this.checkBoxExtensionIPA, "checkBoxExtensionIPA");
            this.checkBoxExtensionIPA.Name = "checkBoxExtensionIPA";
            this.checkBoxExtensionIPA.UseVisualStyleBackColor = true;
            this.checkBoxExtensionIPA.CheckedChanged += new System.EventHandler(this.checkBoxExtensionIPA_CheckedChanged);
            // 
            // checkBoxExtensionIPF
            // 
            resources.ApplyResources(this.checkBoxExtensionIPF, "checkBoxExtensionIPF");
            this.checkBoxExtensionIPF.Name = "checkBoxExtensionIPF";
            this.checkBoxExtensionIPF.UseVisualStyleBackColor = true;
            this.checkBoxExtensionIPF.CheckedChanged += new System.EventHandler(this.checkBoxExtensionIPF_CheckedChanged);
            // 
            // checkBoxExtensionIMG
            // 
            resources.ApplyResources(this.checkBoxExtensionIMG, "checkBoxExtensionIMG");
            this.checkBoxExtensionIMG.Name = "checkBoxExtensionIMG";
            this.checkBoxExtensionIMG.UseVisualStyleBackColor = true;
            this.checkBoxExtensionIMG.CheckedChanged += new System.EventHandler(this.checkBoxExtensionIMG_CheckedChanged);
            // 
            // checkBoxExtensionCCD
            // 
            resources.ApplyResources(this.checkBoxExtensionCCD, "checkBoxExtensionCCD");
            this.checkBoxExtensionCCD.Name = "checkBoxExtensionCCD";
            this.checkBoxExtensionCCD.UseVisualStyleBackColor = true;
            this.checkBoxExtensionCCD.CheckedChanged += new System.EventHandler(this.checkBoxExtensionCCD_CheckedChanged);
            // 
            // checkBoxExtensionSTL
            // 
            resources.ApplyResources(this.checkBoxExtensionSTL, "checkBoxExtensionSTL");
            this.checkBoxExtensionSTL.Name = "checkBoxExtensionSTL";
            this.checkBoxExtensionSTL.UseVisualStyleBackColor = true;
            this.checkBoxExtensionSTL.CheckedChanged += new System.EventHandler(this.checkBoxExtensionSTL_CheckedChanged);
            // 
            // tabPage5
            // 
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Controls.Add(this.groupBox11);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            resources.ApplyResources(this.groupBox11, "groupBox11");
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.flowLayoutPanel3);
            this.groupBox11.Controls.Add(this.pictureBox1);
            this.groupBox11.Controls.Add(this.radioButtonChiLeft);
            this.groupBox11.Controls.Add(this.radioButtonChiBottom);
            this.groupBox11.Controls.Add(this.radioButtonChiTop);
            this.groupBox11.Controls.Add(this.radioButtonChiRight);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.TabStop = false;
            // 
            // label50
            // 
            resources.ApplyResources(this.label50, "label50");
            this.label50.Name = "label50";
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(this.flowLayoutPanel3, "flowLayoutPanel3");
            this.flowLayoutPanel3.Controls.Add(this.radioButtonChiClockwise);
            this.flowLayoutPanel3.Controls.Add(this.radioButtonChiCounterclockwise);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            // 
            // radioButtonChiClockwise
            // 
            resources.ApplyResources(this.radioButtonChiClockwise, "radioButtonChiClockwise");
            this.radioButtonChiClockwise.Checked = true;
            this.radioButtonChiClockwise.Name = "radioButtonChiClockwise";
            this.radioButtonChiClockwise.TabStop = true;
            this.radioButtonChiClockwise.UseVisualStyleBackColor = true;
            this.radioButtonChiClockwise.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // radioButtonChiCounterclockwise
            // 
            resources.ApplyResources(this.radioButtonChiCounterclockwise, "radioButtonChiCounterclockwise");
            this.radioButtonChiCounterclockwise.Name = "radioButtonChiCounterclockwise";
            this.radioButtonChiCounterclockwise.UseVisualStyleBackColor = true;
            this.radioButtonChiCounterclockwise.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // pictureBox1
            // 
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
            this.pictureBox1.Image = global::IPAnalyzer.Properties.Resources.chi;
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.TabStop = false;
            // 
            // radioButtonChiLeft
            // 
            resources.ApplyResources(this.radioButtonChiLeft, "radioButtonChiLeft");
            this.radioButtonChiLeft.Name = "radioButtonChiLeft";
            this.radioButtonChiLeft.UseVisualStyleBackColor = true;
            this.radioButtonChiLeft.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // radioButtonChiBottom
            // 
            resources.ApplyResources(this.radioButtonChiBottom, "radioButtonChiBottom");
            this.radioButtonChiBottom.Name = "radioButtonChiBottom";
            this.radioButtonChiBottom.UseVisualStyleBackColor = true;
            this.radioButtonChiBottom.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // radioButtonChiTop
            // 
            resources.ApplyResources(this.radioButtonChiTop, "radioButtonChiTop");
            this.radioButtonChiTop.Name = "radioButtonChiTop";
            this.radioButtonChiTop.UseVisualStyleBackColor = true;
            this.radioButtonChiTop.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // radioButtonChiRight
            // 
            resources.ApplyResources(this.radioButtonChiRight, "radioButtonChiRight");
            this.radioButtonChiRight.Checked = true;
            this.radioButtonChiRight.Name = "radioButtonChiRight";
            this.radioButtonChiRight.TabStop = true;
            this.radioButtonChiRight.UseVisualStyleBackColor = true;
            this.radioButtonChiRight.CheckedChanged += new System.EventHandler(this.radioButtonChi_CheckedChanged);
            // 
            // groupBox2
            // 
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Controls.Add(this.flowLayoutPanelFindCenterOption);
            this.groupBox2.Controls.Add(this.checkBoxFixCenter);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(this.flowLayoutPanel4, "flowLayoutPanel4");
            this.flowLayoutPanel4.Controls.Add(this.label5);
            this.flowLayoutPanel4.Controls.Add(this.numericBoxFindCenterPeakFittingRange);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // numericBoxFindCenterPeakFittingRange
            // 
            resources.ApplyResources(this.numericBoxFindCenterPeakFittingRange, "numericBoxFindCenterPeakFittingRange");
            this.numericBoxFindCenterPeakFittingRange.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxFindCenterPeakFittingRange.DecimalPlaces = 3;
            this.numericBoxFindCenterPeakFittingRange.Minimum = 0D;
            this.numericBoxFindCenterPeakFittingRange.Name = "numericBoxFindCenterPeakFittingRange";
            this.numericBoxFindCenterPeakFittingRange.RadianValue = 0.0017453292519943296D;
            this.numericBoxFindCenterPeakFittingRange.RoundErrorAccuracy = -1;
            this.numericBoxFindCenterPeakFittingRange.SkipEventDuringInput = false;
            this.numericBoxFindCenterPeakFittingRange.SmartIncrement = true;
            this.numericBoxFindCenterPeakFittingRange.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxFindCenterPeakFittingRange.ThonsandsSeparator = true;
            this.numericBoxFindCenterPeakFittingRange.Value = 0.1D;
            // 
            // flowLayoutPanelFindCenterOption
            // 
            resources.ApplyResources(this.flowLayoutPanelFindCenterOption, "flowLayoutPanelFindCenterOption");
            this.flowLayoutPanelFindCenterOption.Controls.Add(this.numericBoxFindCenterSearchArea);
            this.flowLayoutPanelFindCenterOption.Controls.Add(this.checkBoxExcludeMaskedPixels);
            this.flowLayoutPanelFindCenterOption.Name = "flowLayoutPanelFindCenterOption";
            // 
            // numericBoxFindCenterSearchArea
            // 
            resources.ApplyResources(this.numericBoxFindCenterSearchArea, "numericBoxFindCenterSearchArea");
            this.numericBoxFindCenterSearchArea.BackColor = System.Drawing.Color.Transparent;
            this.numericBoxFindCenterSearchArea.DecimalPlaces = 0;
            this.numericBoxFindCenterSearchArea.Name = "numericBoxFindCenterSearchArea";
            this.numericBoxFindCenterSearchArea.RadianValue = 0.13962634015954636D;
            this.numericBoxFindCenterSearchArea.RoundErrorAccuracy = -1;
            this.numericBoxFindCenterSearchArea.SkipEventDuringInput = false;
            this.numericBoxFindCenterSearchArea.SmartIncrement = true;
            this.numericBoxFindCenterSearchArea.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxFindCenterSearchArea.ThonsandsSeparator = true;
            this.numericBoxFindCenterSearchArea.Value = 8D;
            // 
            // checkBoxExcludeMaskedPixels
            // 
            resources.ApplyResources(this.checkBoxExcludeMaskedPixels, "checkBoxExcludeMaskedPixels");
            this.checkBoxExcludeMaskedPixels.Name = "checkBoxExcludeMaskedPixels";
            this.checkBoxExcludeMaskedPixels.UseVisualStyleBackColor = true;
            this.checkBoxExcludeMaskedPixels.CheckedChanged += new System.EventHandler(this.checkBoxFixCenter_CheckedChanged);
            // 
            // checkBoxFixCenter
            // 
            resources.ApplyResources(this.checkBoxFixCenter, "checkBoxFixCenter");
            this.checkBoxFixCenter.Name = "checkBoxFixCenter";
            this.checkBoxFixCenter.UseVisualStyleBackColor = true;
            this.checkBoxFixCenter.CheckedChanged += new System.EventHandler(this.checkBoxFixCenter_CheckedChanged);
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.textBoxBackgroundImage);
            this.groupBox6.Controls.Add(this.buttonClearBackgroundImage);
            this.groupBox6.Controls.Add(this.buttonSetBackgroundImage);
            this.groupBox6.Controls.Add(this.numericBoxBackgroundCoeff);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // textBoxBackgroundImage
            // 
            resources.ApplyResources(this.textBoxBackgroundImage, "textBoxBackgroundImage");
            this.textBoxBackgroundImage.Name = "textBoxBackgroundImage";
            this.textBoxBackgroundImage.ReadOnly = true;
            // 
            // buttonClearBackgroundImage
            // 
            resources.ApplyResources(this.buttonClearBackgroundImage, "buttonClearBackgroundImage");
            this.buttonClearBackgroundImage.Name = "buttonClearBackgroundImage";
            this.buttonClearBackgroundImage.UseVisualStyleBackColor = true;
            this.buttonClearBackgroundImage.Click += new System.EventHandler(this.buttonClearBackgroundImage_Click);
            // 
            // buttonSetBackgroundImage
            // 
            resources.ApplyResources(this.buttonSetBackgroundImage, "buttonSetBackgroundImage");
            this.buttonSetBackgroundImage.Name = "buttonSetBackgroundImage";
            this.buttonSetBackgroundImage.UseVisualStyleBackColor = true;
            this.buttonSetBackgroundImage.Click += new System.EventHandler(this.buttonSetBackgroundImage_Click);
            // 
            // numericBoxBackgroundCoeff
            // 
            resources.ApplyResources(this.numericBoxBackgroundCoeff, "numericBoxBackgroundCoeff");
            this.numericBoxBackgroundCoeff.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBackgroundCoeff.DecimalPlaces = 3;
            this.numericBoxBackgroundCoeff.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBackgroundCoeff.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxBackgroundCoeff.Maximum = 10D;
            this.numericBoxBackgroundCoeff.Minimum = 0D;
            this.numericBoxBackgroundCoeff.Name = "numericBoxBackgroundCoeff";
            this.numericBoxBackgroundCoeff.RadianValue = 0.017453292519943295D;
            this.numericBoxBackgroundCoeff.RoundErrorAccuracy = -1;
            this.numericBoxBackgroundCoeff.SkipEventDuringInput = false;
            this.numericBoxBackgroundCoeff.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxBackgroundCoeff.ThonsandsSeparator = true;
            this.numericBoxBackgroundCoeff.UpDown_Increment = 0.001D;
            this.numericBoxBackgroundCoeff.Value = 1D;
            this.numericBoxBackgroundCoeff.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.NumericBoxBackgroundCoeff_ValueChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // numericUpDownMaskEdge
            // 
            resources.ApplyResources(this.numericUpDownMaskEdge, "numericUpDownMaskEdge");
            this.numericUpDownMaskEdge.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.numericUpDownMaskEdge.Name = "numericUpDownMaskEdge";
            this.numericUpDownMaskEdge.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // FormProperty
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.tabControl);
            settings1.SettingsKey = "";
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", settings1, "LocationProperty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormProperty";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormProperty_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormProperty_FormClosed);
            this.Load += new System.EventHandler(this.FormProperty_Load);
            this.tabControl.ResumeLayout(false);
            this.tabPageXRay.ResumeLayout(false);
            this.tabPageXRay.PerformLayout();
            this.tabPageIP.ResumeLayout(false);
            this.tabPageIP.PerformLayout();
            this.groupBoxCameaLength.ResumeLayout(false);
            this.groupBoxDirectSpotPosition.ResumeLayout(false);
            this.groupBoxPixelShape.ResumeLayout(false);
            this.groupBoxGandlfiRadius.ResumeLayout(false);
            this.groupBoxSphericalCorrection.ResumeLayout(false);
            this.groupBoxTiltCorrection.ResumeLayout(false);
            this.tabPageIntegralRegion.ResumeLayout(false);
            this.tabPageIntegralRegion.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfIntensityMax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfIntensityMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownEdge)).EndInit();
            this.groupBoxRectangle.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangleBand)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRectangleAngle)).EndInit();
            this.groupBoxSector.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectorStartAngle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSectorEndAngle)).EndInit();
            this.tabPageIntegralProperty.ResumeLayout(false);
            this.tabPageIntegralProperty.PerformLayout();
            this.groupBoxRadial.ResumeLayout(false);
            this.groupBoxRadial.PerformLayout();
            this.groupBoxConcentric.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabPageSpotsAndCenter.ResumeLayout(false);
            this.tabPageSpotsAndCenter.PerformLayout();
            this.groupBoxManualMode.ResumeLayout(false);
            this.groupBoxManualMode.PerformLayout();
            this.groupBoxManualSpot.ResumeLayout(false);
            this.groupBoxManualSpot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpotSize)).EndInit();
            this.groupBoxSpline.ResumeLayout(false);
            this.groupBoxSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplineWidth)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindSpotsDeviation)).EndInit();
            this.tabPageAfterGetProfile.ResumeLayout(false);
            this.tabPageAfterGetProfile.PerformLayout();
            this.groupBoxSaveProfile.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBoxSendPDI.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrollChiDivision)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXstart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrolledImageXstep)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.flowLayoutPanelFindCenterOption.ResumeLayout(false);
            this.flowLayoutPanelFindCenterOption.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaskEdge)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.TabPage tabPageIP;
        public System.Windows.Forms.TabPage tabPageXRay;
        public System.Windows.Forms.GroupBox groupBoxTiltCorrection;
        public System.Windows.Forms.CheckBox checkBoxTiltCorrection;
        public System.Windows.Forms.GroupBox groupBoxPixelShape;
        public System.Windows.Forms.Label label20;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label21;
        public System.Windows.Forms.TabPage tabPageIntegralRegion;
        public System.Windows.Forms.RadioButton radioButtonRectangle;
        public System.Windows.Forms.GroupBox groupBoxRectangle;
        public System.Windows.Forms.CheckBox checkBoxRectangleIsBothSide;
        public System.Windows.Forms.ComboBox comboBoxRectangleDirection;
        public System.Windows.Forms.Label label8;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.NumericUpDown numericUpDownRectangleBand;
        public System.Windows.Forms.NumericUpDown numericUpDownRectangleAngle;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.RadioButton radioButtonSector;
        public System.Windows.Forms.GroupBox groupBoxSector;
        public System.Windows.Forms.Label label10;
        public System.Windows.Forms.NumericUpDown numericUpDownSectorStartAngle;
        public System.Windows.Forms.Label label11;
        public System.Windows.Forms.NumericUpDown numericUpDownSectorEndAngle;
        public System.Windows.Forms.TabPage tabPageSpotsAndCenter;
        public System.Windows.Forms.GroupBox groupBox12;
        public System.Windows.Forms.CheckBox checkBoxManualMaskMode;
        public System.Windows.Forms.Label label30;
        public System.Windows.Forms.Label label28;
        public System.Windows.Forms.NumericUpDown numericUpDownFindSpotsDeviation;
        public System.Windows.Forms.TabPage tabPageIntegralProperty;
        public System.Windows.Forms.GroupBox groupBox4;
        public System.Windows.Forms.NumericUpDown numericUpDownThresholdOfIntensityMin;
        public System.Windows.Forms.RadioButton radioButtonConcentricAngle;
        public System.Windows.Forms.NumericUpDown numericUpDownThresholdOfIntensityMax;
        public System.Windows.Forms.Label label12;
        public System.Windows.Forms.Label label13;
        public System.Windows.Forms.Label label14;
        public System.Windows.Forms.CheckBox checkBoxThresholdMax;
        public System.Windows.Forms.CheckBox checkBoxThresholdMin;
        public System.Windows.Forms.CheckBox checkBoxOmitSpots;
        public System.Windows.Forms.GroupBox groupBoxDirectSpotPosition;
        public System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.RadioButton radioButtonConcentricDspacing;
        public System.Windows.Forms.Label labelIntegralDimension3;
        public System.Windows.Forms.Label labelIntegralDimension1;
        public System.Windows.Forms.Label labelIntegralDimension2;
        private System.Windows.Forms.GroupBox groupBoxManualMode;
        private System.Windows.Forms.RadioButton radioButton1;
        public System.Windows.Forms.RadioButton radioButtonCircle;
        public System.Windows.Forms.NumericUpDown numericUpDownManualSpotSize;
        public System.Windows.Forms.TextBox textBoxManualSpotSize;
        private System.Windows.Forms.TabPage tabPageAfterGetProfile;
        public System.Windows.Forms.CheckBox checkBoxSendProfileToPDIndexer;
        public System.Windows.Forms.CheckBox checkBoxSaveFile;
        private System.Windows.Forms.GroupBox groupBoxSaveProfile;
        public System.Windows.Forms.RadioButton radioButtonSaveAtImageDirectory;
        public System.Windows.Forms.RadioButton radioButtonSetDirectoryEachTime;
        private Crystallography.Controls.NumericBox numericalTextBoxCameraLength;
        public System.Windows.Forms.CheckBox checkBoxMaskEdge;
        public System.Windows.Forms.NumericUpDown numericUpDownEdge;
        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.NumericUpDown numericUpDownMaskEdge;
        public System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox5;
        public System.Windows.Forms.RadioButton radioButtonBraggBrentano;
        public System.Windows.Forms.RadioButton radioButtonDebyeScherrer;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        public System.Windows.Forms.RadioButton radioButtonAsPDIformat;
        public System.Windows.Forms.RadioButton radioButtonAsCSVformat;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBoxCameaLength;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.GroupBox groupBoxRadial;
        public System.Windows.Forms.RadioButton radioButtonRadialAngle;
        public System.Windows.Forms.Label label36;
        public System.Windows.Forms.Label label37;
        public System.Windows.Forms.Label labelDimensionRadial1;
        public System.Windows.Forms.Label labelDimensionRadial2;
        public System.Windows.Forms.Label label40;
        private System.Windows.Forms.GroupBox groupBoxConcentric;
        public System.Windows.Forms.RadioButton radioButtonRadialDspacing;
        public System.Windows.Forms.RadioButton radioButtonConcentric;
        public System.Windows.Forms.RadioButton radioButtonRadial;
        public System.Windows.Forms.RadioButton radioButtonConcentricLength;
        public Crystallography.Controls.WaveLengthControl waveLengthControl;
        public Crystallography.Controls.NumericBox numericBoxPixelSizeX;
        public Crystallography.Controls.NumericBox numericBoxPixelSizeY;
        public Crystallography.Controls.NumericBox numericalTextBoxPixelKsi;
        public Crystallography.Controls.NumericBox numericBoxTiltCorrectionTau;
        public Crystallography.Controls.NumericBox numericBoxTiltCorrectionPhi;
        public Crystallography.Controls.NumericBox numericBoxCenterPositionY;
        public Crystallography.Controls.NumericBox numericBoxCenterPositionX;
        private System.Windows.Forms.TabPage tabPage1;
        public System.Windows.Forms.NumericUpDown numericUpDownUnrolledImageXstart;
        public System.Windows.Forms.NumericUpDown numericUpDownUnrollChiDivision;
        public System.Windows.Forms.NumericUpDown numericUpDownUnrolledImageXend;
        public System.Windows.Forms.NumericUpDown numericUpDownUnrolledImageXstep;
        public System.Windows.Forms.RadioButton radioButton2;
        public System.Windows.Forms.RadioButton radioButton3;
        public System.Windows.Forms.RadioButton radioButton4;
        public System.Windows.Forms.Label label42;
        public System.Windows.Forms.Label label24;
        public System.Windows.Forms.Label label41;
        public System.Windows.Forms.Label label25;
        public System.Windows.Forms.Label label39;
        public System.Windows.Forms.Label label38;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.CheckBox checkBoxFixCenter;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox checkBoxExtensionIPF;
        private System.Windows.Forms.CheckBox checkBoxExtensionIMG;
        private System.Windows.Forms.CheckBox checkBoxExtensionCCD;
        private System.Windows.Forms.CheckBox checkBoxExtensionSTL;
        private System.Windows.Forms.GroupBox groupBoxSendPDI;
        public System.Windows.Forms.CheckBox checkBoxSendUnrolledImageToPDIndexer;
        private System.Windows.Forms.CheckBox checkBoxExtensionIPA;
        public System.Windows.Forms.CheckBox checkBox1;
        public System.Windows.Forms.GroupBox groupBoxSphericalCorrection;
        public Crystallography.Controls.NumericBox numericalTextBoxSphericalCorections;
        public System.Windows.Forms.Label label46;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.GroupBox groupBoxManualSpot;
        private System.Windows.Forms.Button buttonMaskAll;
        private System.Windows.Forms.Button buttonUnmaskAll;
        public System.Windows.Forms.RadioButton radioButtonManualCircle;
        public System.Windows.Forms.RadioButton radioButtonManualRectangle;
        public System.Windows.Forms.RadioButton radioButtonManualSpline;
        public System.Windows.Forms.RadioButton radioButtonManualSpot;
        public System.Windows.Forms.NumericUpDown numericUpDownSplineWidth;
        public System.Windows.Forms.Label label49;
        public System.Windows.Forms.Label label48;
        public System.Windows.Forms.GroupBox groupBox11;
        private System.Windows.Forms.PictureBox pictureBox1;
        public System.Windows.Forms.Label label50;
        public System.Windows.Forms.RadioButton radioButtonChiLeft;
        public System.Windows.Forms.RadioButton radioButtonChiBottom;
        public System.Windows.Forms.RadioButton radioButtonChiTop;
        public System.Windows.Forms.RadioButton radioButtonChiRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        public System.Windows.Forms.RadioButton radioButtonChiClockwise;
        public System.Windows.Forms.RadioButton radioButtonChiCounterclockwise;
        public System.Windows.Forms.CheckBox checkBoxSACLA;
        private System.Windows.Forms.Button buttonOptimizeSaclaEH5Parameter;
        public Crystallography.Controls.SaclaControl saclaControl;
        public Crystallography.Controls.NumericBox numericBoxConcentricStep;
        public Crystallography.Controls.NumericBox numericBoxConcentricEnd;
        public Crystallography.Controls.NumericBox numericBoxConcentricStart;
        public Crystallography.Controls.NumericBox numericBoxRadialRange;
        public Crystallography.Controls.NumericBox numericBoxRadialRadius;
        public Crystallography.Controls.NumericBox numericBoxRadialStep;
        public Crystallography.Controls.NumericBox numericBoxFindCenterSearchArea;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFindCenterOption;
        public System.Windows.Forms.CheckBox checkBoxExcludeMaskedPixels;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.Label label5;
        public Crystallography.Controls.NumericBox numericBoxFindCenterPeakFittingRange;
        public System.Windows.Forms.GroupBox groupBoxGandlfiRadius;
        public Crystallography.Controls.NumericBox numericBoxGandlfiRadius;
        public System.Windows.Forms.RadioButton radioButtonFlatPanel;
        public System.Windows.Forms.RadioButton radioButtonGandlfi;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button buttonSetBackgroundImage;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.CheckBox checkBoxTest;
        public Crystallography.Controls.NumericBox numericBoxTest;
        public System.Windows.Forms.CheckBox checkBoxCorrectPolarization;
        private System.Windows.Forms.TextBox textBoxBackgroundImage;
        private System.Windows.Forms.Button buttonClearBackgroundImage;
        public Crystallography.Controls.NumericBox numericBoxBackgroundCoeff;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.RadioButton radioButtonAsTSVformat;
        private System.Windows.Forms.GroupBox groupBoxSpline;
        public System.Windows.Forms.GroupBox groupBox7;
        public System.Windows.Forms.RadioButton radioButtonTakeOverMaskfile;
        public System.Windows.Forms.RadioButton radioButtonTakeoverMask;
        public System.Windows.Forms.RadioButton radioButtonTakoverNothing;
    }
}