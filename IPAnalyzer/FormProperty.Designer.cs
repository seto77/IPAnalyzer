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
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.numericUpDownFindSpotsDeviation = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
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
            this.numericUpDownSplineWidth = new System.Windows.Forms.NumericUpDown();
            this.label49 = new System.Windows.Forms.Label();
            this.buttonMaskAll = new System.Windows.Forms.Button();
            this.buttonUnmaskAll = new System.Windows.Forms.Button();
            this.buttonSaveMask = new System.Windows.Forms.Button();
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
            this.numericUpDownUnrollSectorStep = new System.Windows.Forms.NumericUpDown();
            this.label43 = new System.Windows.Forms.Label();
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
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindSpotsDeviation)).BeginInit();
            this.groupBoxManualMode.SuspendLayout();
            this.groupBoxManualSpot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpotSize)).BeginInit();
            this.groupBoxSpline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplineWidth)).BeginInit();
            this.tabPageAfterGetProfile.SuspendLayout();
            this.groupBoxSaveProfile.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBoxSendPDI.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrollSectorStep)).BeginInit();
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
            this.tabPageXRay.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageXRay.Controls.Add(this.label15);
            this.tabPageXRay.Controls.Add(this.label6);
            this.tabPageXRay.Controls.Add(this.checkBoxCorrectPolarization);
            this.tabPageXRay.Controls.Add(this.waveLengthControl);
            resources.ApplyResources(this.tabPageXRay, "tabPageXRay");
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
            this.waveLengthControl.Energy = 17.444196720128065D;
            this.waveLengthControl.Name = "waveLengthControl";
            this.waveLengthControl.ShowWaveSource = true;
            this.waveLengthControl.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.waveLengthControl.WaveLength = 0.07107471D;
            this.waveLengthControl.WaveSource = Crystallography.WaveSource.Xray;
            this.waveLengthControl.XrayWaveSourceElementNumber = 42;
            this.waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka;
            // 
            // tabPageIP
            // 
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
            resources.ApplyResources(this.tabPageIP, "tabPageIP");
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
            this.groupBoxCameaLength.Controls.Add(this.numericalTextBoxCameraLength);
            resources.ApplyResources(this.groupBoxCameaLength, "groupBoxCameaLength");
            this.groupBoxCameaLength.Name = "groupBoxCameaLength";
            this.groupBoxCameaLength.TabStop = false;
            // 
            // numericalTextBoxCameraLength
            // 
            resources.ApplyResources(this.numericalTextBoxCameraLength, "numericalTextBoxCameraLength");
            this.numericalTextBoxCameraLength.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxCameraLength.DecimalPlaces = -1;
            this.numericalTextBoxCameraLength.Maximum = double.PositiveInfinity;
            this.numericalTextBoxCameraLength.Minimum = double.NegativeInfinity;
            this.numericalTextBoxCameraLength.Multiline = false;
            this.numericalTextBoxCameraLength.Name = "numericalTextBoxCameraLength";
            this.numericalTextBoxCameraLength.RadianValue = 7.7667151713747664D;
            this.numericalTextBoxCameraLength.ReadOnly = false;
            this.numericalTextBoxCameraLength.RestrictLimitValue = true;
            this.numericalTextBoxCameraLength.ShowFraction = false;
            this.numericalTextBoxCameraLength.ShowPositiveSign = false;
            this.numericalTextBoxCameraLength.ShowUpDown = false;
            this.numericalTextBoxCameraLength.SkipEventDuringInput = false;
            this.numericalTextBoxCameraLength.SmartIncrement = true;
            this.numericalTextBoxCameraLength.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxCameraLength.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxCameraLength.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxCameraLength.ThonsandsSeparator = true;
            this.numericalTextBoxCameraLength.UpDown_Increment = 1D;
            this.numericalTextBoxCameraLength.Value = 445D;
            this.numericalTextBoxCameraLength.WordWrap = true;
            this.numericalTextBoxCameraLength.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxDirectSpotPosition
            // 
            this.groupBoxDirectSpotPosition.Controls.Add(this.numericBoxCenterPositionY);
            this.groupBoxDirectSpotPosition.Controls.Add(this.numericBoxCenterPositionX);
            resources.ApplyResources(this.groupBoxDirectSpotPosition, "groupBoxDirectSpotPosition");
            this.groupBoxDirectSpotPosition.Name = "groupBoxDirectSpotPosition";
            this.groupBoxDirectSpotPosition.TabStop = false;
            // 
            // numericBoxCenterPositionY
            // 
            resources.ApplyResources(this.numericBoxCenterPositionY, "numericBoxCenterPositionY");
            this.numericBoxCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionY.DecimalPlaces = -1;
            this.numericBoxCenterPositionY.Maximum = double.PositiveInfinity;
            this.numericBoxCenterPositionY.Minimum = double.NegativeInfinity;
            this.numericBoxCenterPositionY.Multiline = false;
            this.numericBoxCenterPositionY.Name = "numericBoxCenterPositionY";
            this.numericBoxCenterPositionY.RadianValue = 26.179938779914945D;
            this.numericBoxCenterPositionY.ReadOnly = false;
            this.numericBoxCenterPositionY.RestrictLimitValue = true;
            this.numericBoxCenterPositionY.ShowFraction = false;
            this.numericBoxCenterPositionY.ShowPositiveSign = false;
            this.numericBoxCenterPositionY.ShowUpDown = false;
            this.numericBoxCenterPositionY.SkipEventDuringInput = false;
            this.numericBoxCenterPositionY.SmartIncrement = true;
            this.numericBoxCenterPositionY.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCenterPositionY.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCenterPositionY.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCenterPositionY.ThonsandsSeparator = true;
            this.numericBoxCenterPositionY.UpDown_Increment = 1D;
            this.numericBoxCenterPositionY.Value = 1500D;
            this.numericBoxCenterPositionY.WordWrap = true;
            this.numericBoxCenterPositionY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxCenterPositionX
            // 
            resources.ApplyResources(this.numericBoxCenterPositionX, "numericBoxCenterPositionX");
            this.numericBoxCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxCenterPositionX.DecimalPlaces = -1;
            this.numericBoxCenterPositionX.Maximum = double.PositiveInfinity;
            this.numericBoxCenterPositionX.Minimum = double.NegativeInfinity;
            this.numericBoxCenterPositionX.Multiline = false;
            this.numericBoxCenterPositionX.Name = "numericBoxCenterPositionX";
            this.numericBoxCenterPositionX.RadianValue = 26.179938779914945D;
            this.numericBoxCenterPositionX.ReadOnly = false;
            this.numericBoxCenterPositionX.RestrictLimitValue = true;
            this.numericBoxCenterPositionX.ShowFraction = false;
            this.numericBoxCenterPositionX.ShowPositiveSign = false;
            this.numericBoxCenterPositionX.ShowUpDown = false;
            this.numericBoxCenterPositionX.SkipEventDuringInput = false;
            this.numericBoxCenterPositionX.SmartIncrement = true;
            this.numericBoxCenterPositionX.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxCenterPositionX.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxCenterPositionX.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxCenterPositionX.ThonsandsSeparator = true;
            this.numericBoxCenterPositionX.UpDown_Increment = 1D;
            this.numericBoxCenterPositionX.Value = 1500D;
            this.numericBoxCenterPositionX.WordWrap = true;
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
            this.groupBoxPixelShape.Controls.Add(this.numericalTextBoxPixelKsi);
            this.groupBoxPixelShape.Controls.Add(this.numericBoxPixelSizeY);
            this.groupBoxPixelShape.Controls.Add(this.numericBoxPixelSizeX);
            resources.ApplyResources(this.groupBoxPixelShape, "groupBoxPixelShape");
            this.groupBoxPixelShape.Name = "groupBoxPixelShape";
            this.groupBoxPixelShape.TabStop = false;
            // 
            // numericalTextBoxPixelKsi
            // 
            resources.ApplyResources(this.numericalTextBoxPixelKsi, "numericalTextBoxPixelKsi");
            this.numericalTextBoxPixelKsi.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPixelKsi.DecimalPlaces = -1;
            this.numericalTextBoxPixelKsi.Maximum = double.PositiveInfinity;
            this.numericalTextBoxPixelKsi.Minimum = double.NegativeInfinity;
            this.numericalTextBoxPixelKsi.Multiline = false;
            this.numericalTextBoxPixelKsi.Name = "numericalTextBoxPixelKsi";
            this.numericalTextBoxPixelKsi.RadianValue = 0D;
            this.numericalTextBoxPixelKsi.ReadOnly = false;
            this.numericalTextBoxPixelKsi.RestrictLimitValue = true;
            this.numericalTextBoxPixelKsi.ShowFraction = false;
            this.numericalTextBoxPixelKsi.ShowPositiveSign = false;
            this.numericalTextBoxPixelKsi.ShowUpDown = false;
            this.numericalTextBoxPixelKsi.SkipEventDuringInput = false;
            this.numericalTextBoxPixelKsi.SmartIncrement = true;
            this.numericalTextBoxPixelKsi.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxPixelKsi.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxPixelKsi.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxPixelKsi.ThonsandsSeparator = true;
            this.numericalTextBoxPixelKsi.UpDown_Increment = 1D;
            this.numericalTextBoxPixelKsi.Value = 0D;
            this.numericalTextBoxPixelKsi.WordWrap = true;
            this.numericalTextBoxPixelKsi.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxPixelSizeY
            // 
            resources.ApplyResources(this.numericBoxPixelSizeY, "numericBoxPixelSizeY");
            this.numericBoxPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeY.DecimalPlaces = -1;
            this.numericBoxPixelSizeY.Maximum = double.PositiveInfinity;
            this.numericBoxPixelSizeY.Minimum = double.NegativeInfinity;
            this.numericBoxPixelSizeY.Multiline = false;
            this.numericBoxPixelSizeY.Name = "numericBoxPixelSizeY";
            this.numericBoxPixelSizeY.RadianValue = 0.0017453292519943296D;
            this.numericBoxPixelSizeY.ReadOnly = false;
            this.numericBoxPixelSizeY.RestrictLimitValue = true;
            this.numericBoxPixelSizeY.ShowFraction = false;
            this.numericBoxPixelSizeY.ShowPositiveSign = false;
            this.numericBoxPixelSizeY.ShowUpDown = false;
            this.numericBoxPixelSizeY.SkipEventDuringInput = false;
            this.numericBoxPixelSizeY.SmartIncrement = true;
            this.numericBoxPixelSizeY.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxPixelSizeY.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxPixelSizeY.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxPixelSizeY.ThonsandsSeparator = true;
            this.numericBoxPixelSizeY.UpDown_Increment = 1D;
            this.numericBoxPixelSizeY.Value = 0.1D;
            this.numericBoxPixelSizeY.WordWrap = true;
            this.numericBoxPixelSizeY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericBoxPixelSizeY.Load += new System.EventHandler(this.numericalTextBoxPixelSizeY_Load);
            // 
            // numericBoxPixelSizeX
            // 
            resources.ApplyResources(this.numericBoxPixelSizeX, "numericBoxPixelSizeX");
            this.numericBoxPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPixelSizeX.DecimalPlaces = -1;
            this.numericBoxPixelSizeX.Maximum = double.PositiveInfinity;
            this.numericBoxPixelSizeX.Minimum = double.NegativeInfinity;
            this.numericBoxPixelSizeX.Multiline = false;
            this.numericBoxPixelSizeX.Name = "numericBoxPixelSizeX";
            this.numericBoxPixelSizeX.RadianValue = 0.0017453292519943296D;
            this.numericBoxPixelSizeX.ReadOnly = false;
            this.numericBoxPixelSizeX.RestrictLimitValue = true;
            this.numericBoxPixelSizeX.ShowFraction = false;
            this.numericBoxPixelSizeX.ShowPositiveSign = false;
            this.numericBoxPixelSizeX.ShowUpDown = false;
            this.numericBoxPixelSizeX.SkipEventDuringInput = false;
            this.numericBoxPixelSizeX.SmartIncrement = true;
            this.numericBoxPixelSizeX.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxPixelSizeX.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxPixelSizeX.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxPixelSizeX.ThonsandsSeparator = true;
            this.numericBoxPixelSizeX.UpDown_Increment = 1D;
            this.numericBoxPixelSizeX.Value = 0.1D;
            this.numericBoxPixelSizeX.WordWrap = true;
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
            this.groupBoxGandlfiRadius.Controls.Add(this.numericBoxGandlfiRadius);
            resources.ApplyResources(this.groupBoxGandlfiRadius, "groupBoxGandlfiRadius");
            this.groupBoxGandlfiRadius.Name = "groupBoxGandlfiRadius";
            this.groupBoxGandlfiRadius.TabStop = false;
            // 
            // numericBoxGandlfiRadius
            // 
            resources.ApplyResources(this.numericBoxGandlfiRadius, "numericBoxGandlfiRadius");
            this.numericBoxGandlfiRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxGandlfiRadius.DecimalPlaces = -1;
            this.numericBoxGandlfiRadius.Maximum = double.PositiveInfinity;
            this.numericBoxGandlfiRadius.Minimum = double.NegativeInfinity;
            this.numericBoxGandlfiRadius.Multiline = false;
            this.numericBoxGandlfiRadius.Name = "numericBoxGandlfiRadius";
            this.numericBoxGandlfiRadius.RadianValue = 0D;
            this.numericBoxGandlfiRadius.ReadOnly = false;
            this.numericBoxGandlfiRadius.RestrictLimitValue = true;
            this.numericBoxGandlfiRadius.ShowFraction = false;
            this.numericBoxGandlfiRadius.ShowPositiveSign = false;
            this.numericBoxGandlfiRadius.ShowUpDown = false;
            this.numericBoxGandlfiRadius.SkipEventDuringInput = false;
            this.numericBoxGandlfiRadius.SmartIncrement = true;
            this.numericBoxGandlfiRadius.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxGandlfiRadius.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxGandlfiRadius.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxGandlfiRadius.ThonsandsSeparator = true;
            this.numericBoxGandlfiRadius.UpDown_Increment = 1D;
            this.numericBoxGandlfiRadius.Value = 0D;
            this.numericBoxGandlfiRadius.WordWrap = true;
            this.numericBoxGandlfiRadius.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxSphericalCorrection
            // 
            this.groupBoxSphericalCorrection.Controls.Add(this.numericalTextBoxSphericalCorections);
            resources.ApplyResources(this.groupBoxSphericalCorrection, "groupBoxSphericalCorrection");
            this.groupBoxSphericalCorrection.Name = "groupBoxSphericalCorrection";
            this.groupBoxSphericalCorrection.TabStop = false;
            // 
            // numericalTextBoxSphericalCorections
            // 
            resources.ApplyResources(this.numericalTextBoxSphericalCorections, "numericalTextBoxSphericalCorections");
            this.numericalTextBoxSphericalCorections.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalCorections.DecimalPlaces = -1;
            this.numericalTextBoxSphericalCorections.Maximum = double.PositiveInfinity;
            this.numericalTextBoxSphericalCorections.Minimum = double.NegativeInfinity;
            this.numericalTextBoxSphericalCorections.Multiline = false;
            this.numericalTextBoxSphericalCorections.Name = "numericalTextBoxSphericalCorections";
            this.numericalTextBoxSphericalCorections.RadianValue = 0D;
            this.numericalTextBoxSphericalCorections.ReadOnly = false;
            this.numericalTextBoxSphericalCorections.RestrictLimitValue = true;
            this.numericalTextBoxSphericalCorections.ShowFraction = false;
            this.numericalTextBoxSphericalCorections.ShowPositiveSign = false;
            this.numericalTextBoxSphericalCorections.ShowUpDown = false;
            this.numericalTextBoxSphericalCorections.SkipEventDuringInput = false;
            this.numericalTextBoxSphericalCorections.SmartIncrement = true;
            this.numericalTextBoxSphericalCorections.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericalTextBoxSphericalCorections.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericalTextBoxSphericalCorections.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericalTextBoxSphericalCorections.ThonsandsSeparator = true;
            this.numericalTextBoxSphericalCorections.UpDown_Increment = 1D;
            this.numericalTextBoxSphericalCorections.Value = 0D;
            this.numericalTextBoxSphericalCorections.WordWrap = true;
            this.numericalTextBoxSphericalCorections.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // groupBoxTiltCorrection
            // 
            this.groupBoxTiltCorrection.Controls.Add(this.numericBoxTiltCorrectionTau);
            this.groupBoxTiltCorrection.Controls.Add(this.numericBoxTiltCorrectionPhi);
            resources.ApplyResources(this.groupBoxTiltCorrection, "groupBoxTiltCorrection");
            this.groupBoxTiltCorrection.Name = "groupBoxTiltCorrection";
            this.groupBoxTiltCorrection.TabStop = false;
            // 
            // numericBoxTiltCorrectionTau
            // 
            resources.ApplyResources(this.numericBoxTiltCorrectionTau, "numericBoxTiltCorrectionTau");
            this.numericBoxTiltCorrectionTau.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionTau.DecimalPlaces = -1;
            this.numericBoxTiltCorrectionTau.Maximum = double.PositiveInfinity;
            this.numericBoxTiltCorrectionTau.Minimum = double.NegativeInfinity;
            this.numericBoxTiltCorrectionTau.Multiline = false;
            this.numericBoxTiltCorrectionTau.Name = "numericBoxTiltCorrectionTau";
            this.numericBoxTiltCorrectionTau.RadianValue = 0D;
            this.numericBoxTiltCorrectionTau.ReadOnly = false;
            this.numericBoxTiltCorrectionTau.RestrictLimitValue = true;
            this.numericBoxTiltCorrectionTau.ShowFraction = false;
            this.numericBoxTiltCorrectionTau.ShowPositiveSign = false;
            this.numericBoxTiltCorrectionTau.ShowUpDown = false;
            this.numericBoxTiltCorrectionTau.SkipEventDuringInput = false;
            this.numericBoxTiltCorrectionTau.SmartIncrement = true;
            this.numericBoxTiltCorrectionTau.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxTiltCorrectionTau.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxTiltCorrectionTau.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxTiltCorrectionTau.ThonsandsSeparator = true;
            this.numericBoxTiltCorrectionTau.UpDown_Increment = 1D;
            this.numericBoxTiltCorrectionTau.Value = 0D;
            this.numericBoxTiltCorrectionTau.WordWrap = true;
            this.numericBoxTiltCorrectionTau.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            // 
            // numericBoxTiltCorrectionPhi
            // 
            resources.ApplyResources(this.numericBoxTiltCorrectionPhi, "numericBoxTiltCorrectionPhi");
            this.numericBoxTiltCorrectionPhi.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTiltCorrectionPhi.DecimalPlaces = -1;
            this.numericBoxTiltCorrectionPhi.Maximum = double.PositiveInfinity;
            this.numericBoxTiltCorrectionPhi.Minimum = double.NegativeInfinity;
            this.numericBoxTiltCorrectionPhi.Multiline = false;
            this.numericBoxTiltCorrectionPhi.Name = "numericBoxTiltCorrectionPhi";
            this.numericBoxTiltCorrectionPhi.RadianValue = 0D;
            this.numericBoxTiltCorrectionPhi.ReadOnly = false;
            this.numericBoxTiltCorrectionPhi.RestrictLimitValue = true;
            this.numericBoxTiltCorrectionPhi.ShowFraction = false;
            this.numericBoxTiltCorrectionPhi.ShowPositiveSign = false;
            this.numericBoxTiltCorrectionPhi.ShowUpDown = false;
            this.numericBoxTiltCorrectionPhi.SkipEventDuringInput = false;
            this.numericBoxTiltCorrectionPhi.SmartIncrement = true;
            this.numericBoxTiltCorrectionPhi.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxTiltCorrectionPhi.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxTiltCorrectionPhi.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxTiltCorrectionPhi.ThonsandsSeparator = true;
            this.numericBoxTiltCorrectionPhi.UpDown_Increment = 1D;
            this.numericBoxTiltCorrectionPhi.Value = 0D;
            this.numericBoxTiltCorrectionPhi.WordWrap = true;
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
            this.tabPageIntegralRegion.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageIntegralRegion.Controls.Add(this.groupBox8);
            this.tabPageIntegralRegion.Controls.Add(this.radioButtonRectangle);
            this.tabPageIntegralRegion.Controls.Add(this.groupBoxRectangle);
            this.tabPageIntegralRegion.Controls.Add(this.radioButtonSector);
            this.tabPageIntegralRegion.Controls.Add(this.groupBoxSector);
            resources.ApplyResources(this.tabPageIntegralRegion, "tabPageIntegralRegion");
            this.tabPageIntegralRegion.Name = "tabPageIntegralRegion";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.numericUpDownThresholdOfIntensityMax);
            this.groupBox8.Controls.Add(this.label2);
            this.groupBox8.Controls.Add(this.checkBoxThresholdMax);
            this.groupBox8.Controls.Add(this.checkBoxThresholdMin);
            this.groupBox8.Controls.Add(this.numericUpDownThresholdOfIntensityMin);
            this.groupBox8.Controls.Add(this.numericUpDownEdge);
            this.groupBox8.Controls.Add(this.checkBoxOmitSpots);
            this.groupBox8.Controls.Add(this.checkBoxMaskEdge);
            resources.ApplyResources(this.groupBox8, "groupBox8");
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
            this.checkBoxOmitSpots.Checked = true;
            this.checkBoxOmitSpots.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkBoxOmitSpots, "checkBoxOmitSpots");
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
            this.groupBoxRectangle.Controls.Add(this.checkBoxRectangleIsBothSide);
            this.groupBoxRectangle.Controls.Add(this.comboBoxRectangleDirection);
            this.groupBoxRectangle.Controls.Add(this.label8);
            this.groupBoxRectangle.Controls.Add(this.label7);
            this.groupBoxRectangle.Controls.Add(this.numericUpDownRectangleBand);
            this.groupBoxRectangle.Controls.Add(this.numericUpDownRectangleAngle);
            this.groupBoxRectangle.Controls.Add(this.label9);
            resources.ApplyResources(this.groupBoxRectangle, "groupBoxRectangle");
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
            this.numericUpDownRectangleAngle.DecimalPlaces = 3;
            resources.ApplyResources(this.numericUpDownRectangleAngle, "numericUpDownRectangleAngle");
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
            this.groupBoxSector.Controls.Add(this.numericUpDownSectorStartAngle);
            this.groupBoxSector.Controls.Add(this.numericUpDownSectorEndAngle);
            this.groupBoxSector.Controls.Add(this.label10);
            this.groupBoxSector.Controls.Add(this.label11);
            resources.ApplyResources(this.groupBoxSector, "groupBoxSector");
            this.groupBoxSector.Name = "groupBoxSector";
            this.groupBoxSector.TabStop = false;
            // 
            // numericUpDownSectorStartAngle
            // 
            this.numericUpDownSectorStartAngle.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownSectorStartAngle, "numericUpDownSectorStartAngle");
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
            this.numericUpDownSectorEndAngle.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownSectorEndAngle, "numericUpDownSectorEndAngle");
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
            this.tabPageIntegralProperty.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageIntegralProperty.Controls.Add(this.radioButtonRadial);
            this.tabPageIntegralProperty.Controls.Add(this.groupBoxRadial);
            this.tabPageIntegralProperty.Controls.Add(this.radioButtonConcentric);
            this.tabPageIntegralProperty.Controls.Add(this.groupBoxConcentric);
            resources.ApplyResources(this.tabPageIntegralProperty, "tabPageIntegralProperty");
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
            resources.ApplyResources(this.groupBoxRadial, "groupBoxRadial");
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
            this.numericBoxRadialRange.Maximum = double.PositiveInfinity;
            this.numericBoxRadialRange.Minimum = double.NegativeInfinity;
            this.numericBoxRadialRange.Multiline = false;
            this.numericBoxRadialRange.Name = "numericBoxRadialRange";
            this.numericBoxRadialRange.RadianValue = 0.0017453292519943296D;
            this.numericBoxRadialRange.ReadOnly = false;
            this.numericBoxRadialRange.RestrictLimitValue = true;
            this.numericBoxRadialRange.ShowFraction = false;
            this.numericBoxRadialRange.ShowPositiveSign = false;
            this.numericBoxRadialRange.ShowUpDown = false;
            this.numericBoxRadialRange.SkipEventDuringInput = false;
            this.numericBoxRadialRange.SmartIncrement = true;
            this.numericBoxRadialRange.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxRadialRange.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxRadialRange.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxRadialRange.ThonsandsSeparator = true;
            this.numericBoxRadialRange.UpDown_Increment = 1D;
            this.numericBoxRadialRange.Value = 0.1D;
            this.numericBoxRadialRange.WordWrap = true;
            this.numericBoxRadialRange.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // numericBoxRadialRadius
            // 
            resources.ApplyResources(this.numericBoxRadialRadius, "numericBoxRadialRadius");
            this.numericBoxRadialRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialRadius.DecimalPlaces = 4;
            this.numericBoxRadialRadius.Maximum = double.PositiveInfinity;
            this.numericBoxRadialRadius.Minimum = double.NegativeInfinity;
            this.numericBoxRadialRadius.Multiline = false;
            this.numericBoxRadialRadius.Name = "numericBoxRadialRadius";
            this.numericBoxRadialRadius.RadianValue = 0.3490658503988659D;
            this.numericBoxRadialRadius.ReadOnly = false;
            this.numericBoxRadialRadius.RestrictLimitValue = true;
            this.numericBoxRadialRadius.ShowFraction = false;
            this.numericBoxRadialRadius.ShowPositiveSign = false;
            this.numericBoxRadialRadius.ShowUpDown = false;
            this.numericBoxRadialRadius.SkipEventDuringInput = false;
            this.numericBoxRadialRadius.SmartIncrement = true;
            this.numericBoxRadialRadius.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxRadialRadius.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxRadialRadius.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxRadialRadius.ThonsandsSeparator = true;
            this.numericBoxRadialRadius.UpDown_Increment = 1D;
            this.numericBoxRadialRadius.Value = 20D;
            this.numericBoxRadialRadius.WordWrap = true;
            this.numericBoxRadialRadius.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBoxIntegralProperty_ValueChanged);
            // 
            // numericBoxRadialStep
            // 
            resources.ApplyResources(this.numericBoxRadialStep, "numericBoxRadialStep");
            this.numericBoxRadialStep.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxRadialStep.DecimalPlaces = 3;
            this.numericBoxRadialStep.Maximum = double.PositiveInfinity;
            this.numericBoxRadialStep.Minimum = double.NegativeInfinity;
            this.numericBoxRadialStep.Multiline = false;
            this.numericBoxRadialStep.Name = "numericBoxRadialStep";
            this.numericBoxRadialStep.RadianValue = 0.0008726646259971648D;
            this.numericBoxRadialStep.ReadOnly = false;
            this.numericBoxRadialStep.RestrictLimitValue = true;
            this.numericBoxRadialStep.ShowFraction = false;
            this.numericBoxRadialStep.ShowPositiveSign = false;
            this.numericBoxRadialStep.ShowUpDown = false;
            this.numericBoxRadialStep.SkipEventDuringInput = false;
            this.numericBoxRadialStep.SmartIncrement = true;
            this.numericBoxRadialStep.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxRadialStep.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxRadialStep.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxRadialStep.ThonsandsSeparator = true;
            this.numericBoxRadialStep.UpDown_Increment = 1D;
            this.numericBoxRadialStep.Value = 0.05D;
            this.numericBoxRadialStep.WordWrap = true;
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
            this.groupBoxConcentric.Controls.Add(this.groupBox4);
            this.groupBoxConcentric.Controls.Add(this.groupBox5);
            resources.ApplyResources(this.groupBoxConcentric, "groupBoxConcentric");
            this.groupBoxConcentric.Name = "groupBoxConcentric";
            this.groupBoxConcentric.TabStop = false;
            // 
            // groupBox4
            // 
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
            resources.ApplyResources(this.groupBox4, "groupBox4");
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.TabStop = false;
            // 
            // numericBoxConcentricStep
            // 
            resources.ApplyResources(this.numericBoxConcentricStep, "numericBoxConcentricStep");
            this.numericBoxConcentricStep.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxConcentricStep.DecimalPlaces = 4;
            this.numericBoxConcentricStep.Maximum = double.PositiveInfinity;
            this.numericBoxConcentricStep.Minimum = double.NegativeInfinity;
            this.numericBoxConcentricStep.Multiline = false;
            this.numericBoxConcentricStep.Name = "numericBoxConcentricStep";
            this.numericBoxConcentricStep.RadianValue = 8.7266462599716482E-05D;
            this.numericBoxConcentricStep.ReadOnly = false;
            this.numericBoxConcentricStep.RestrictLimitValue = true;
            this.numericBoxConcentricStep.ShowFraction = false;
            this.numericBoxConcentricStep.ShowPositiveSign = false;
            this.numericBoxConcentricStep.ShowUpDown = false;
            this.numericBoxConcentricStep.SkipEventDuringInput = false;
            this.numericBoxConcentricStep.SmartIncrement = true;
            this.numericBoxConcentricStep.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxConcentricStep.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxConcentricStep.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxConcentricStep.ThonsandsSeparator = true;
            this.numericBoxConcentricStep.UpDown_Increment = 1D;
            this.numericBoxConcentricStep.Value = 0.005D;
            this.numericBoxConcentricStep.WordWrap = true;
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
            this.numericBoxConcentricEnd.Maximum = double.PositiveInfinity;
            this.numericBoxConcentricEnd.Minimum = double.NegativeInfinity;
            this.numericBoxConcentricEnd.Multiline = false;
            this.numericBoxConcentricEnd.Name = "numericBoxConcentricEnd";
            this.numericBoxConcentricEnd.RadianValue = 0.52359877559829882D;
            this.numericBoxConcentricEnd.ReadOnly = false;
            this.numericBoxConcentricEnd.RestrictLimitValue = true;
            this.numericBoxConcentricEnd.ShowFraction = false;
            this.numericBoxConcentricEnd.ShowPositiveSign = false;
            this.numericBoxConcentricEnd.ShowUpDown = false;
            this.numericBoxConcentricEnd.SkipEventDuringInput = false;
            this.numericBoxConcentricEnd.SmartIncrement = true;
            this.numericBoxConcentricEnd.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxConcentricEnd.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxConcentricEnd.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxConcentricEnd.ThonsandsSeparator = true;
            this.numericBoxConcentricEnd.UpDown_Increment = 1D;
            this.numericBoxConcentricEnd.Value = 30D;
            this.numericBoxConcentricEnd.WordWrap = true;
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
            this.numericBoxConcentricStart.Maximum = double.PositiveInfinity;
            this.numericBoxConcentricStart.Minimum = double.NegativeInfinity;
            this.numericBoxConcentricStart.Multiline = false;
            this.numericBoxConcentricStart.Name = "numericBoxConcentricStart";
            this.numericBoxConcentricStart.RadianValue = 0.017453292519943295D;
            this.numericBoxConcentricStart.ReadOnly = false;
            this.numericBoxConcentricStart.RestrictLimitValue = true;
            this.numericBoxConcentricStart.ShowFraction = false;
            this.numericBoxConcentricStart.ShowPositiveSign = false;
            this.numericBoxConcentricStart.ShowUpDown = false;
            this.numericBoxConcentricStart.SkipEventDuringInput = false;
            this.numericBoxConcentricStart.SmartIncrement = true;
            this.numericBoxConcentricStart.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxConcentricStart.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxConcentricStart.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxConcentricStart.ThonsandsSeparator = true;
            this.numericBoxConcentricStart.UpDown_Increment = 1D;
            this.numericBoxConcentricStart.Value = 1D;
            this.numericBoxConcentricStart.WordWrap = true;
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
            this.groupBox5.Controls.Add(this.radioButtonBraggBrentano);
            this.groupBox5.Controls.Add(this.radioButtonDebyeScherrer);
            resources.ApplyResources(this.groupBox5, "groupBox5");
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
            this.tabPageSpotsAndCenter.Controls.Add(this.checkBoxManualMaskMode);
            this.tabPageSpotsAndCenter.Controls.Add(this.groupBox12);
            this.tabPageSpotsAndCenter.Controls.Add(this.groupBoxManualMode);
            this.tabPageSpotsAndCenter.Controls.Add(this.buttonMaskAll);
            this.tabPageSpotsAndCenter.Controls.Add(this.buttonUnmaskAll);
            this.tabPageSpotsAndCenter.Controls.Add(this.buttonSaveMask);
            resources.ApplyResources(this.tabPageSpotsAndCenter, "tabPageSpotsAndCenter");
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
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.numericUpDownFindSpotsDeviation);
            this.groupBox12.Controls.Add(this.label28);
            resources.ApplyResources(this.groupBox12, "groupBox12");
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.TabStop = false;
            // 
            // numericUpDownFindSpotsDeviation
            // 
            this.numericUpDownFindSpotsDeviation.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownFindSpotsDeviation, "numericUpDownFindSpotsDeviation");
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
            // groupBoxManualMode
            // 
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualCircle);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualSpline);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualRectangle);
            this.groupBoxManualMode.Controls.Add(this.radioButtonManualSpot);
            this.groupBoxManualMode.Controls.Add(this.groupBoxManualSpot);
            this.groupBoxManualMode.Controls.Add(this.groupBoxSpline);
            resources.ApplyResources(this.groupBoxManualMode, "groupBoxManualMode");
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
            this.groupBoxManualSpot.Controls.Add(this.textBoxManualSpotSize);
            this.groupBoxManualSpot.Controls.Add(this.radioButton1);
            this.groupBoxManualSpot.Controls.Add(this.numericUpDownManualSpotSize);
            this.groupBoxManualSpot.Controls.Add(this.label30);
            this.groupBoxManualSpot.Controls.Add(this.radioButtonCircle);
            resources.ApplyResources(this.groupBoxManualSpot, "groupBoxManualSpot");
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
            this.groupBoxSpline.Controls.Add(this.label48);
            this.groupBoxSpline.Controls.Add(this.numericUpDownSplineWidth);
            this.groupBoxSpline.Controls.Add(this.label49);
            resources.ApplyResources(this.groupBoxSpline, "groupBoxSpline");
            this.groupBoxSpline.Name = "groupBoxSpline";
            this.groupBoxSpline.TabStop = false;
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
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
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
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
            // buttonSaveMask
            // 
            resources.ApplyResources(this.buttonSaveMask, "buttonSaveMask");
            this.buttonSaveMask.Name = "buttonSaveMask";
            this.buttonSaveMask.UseVisualStyleBackColor = true;
            this.buttonSaveMask.Click += new System.EventHandler(this.buttonSaveMask_Click);
            // 
            // tabPageAfterGetProfile
            // 
            this.tabPageAfterGetProfile.Controls.Add(this.numericBoxTest);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxTest);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxSendProfileToPDIndexer);
            this.tabPageAfterGetProfile.Controls.Add(this.checkBoxSaveFile);
            this.tabPageAfterGetProfile.Controls.Add(this.groupBoxSaveProfile);
            this.tabPageAfterGetProfile.Controls.Add(this.groupBoxSendPDI);
            resources.ApplyResources(this.tabPageAfterGetProfile, "tabPageAfterGetProfile");
            this.tabPageAfterGetProfile.Name = "tabPageAfterGetProfile";
            this.tabPageAfterGetProfile.UseVisualStyleBackColor = true;
            // 
            // numericBoxTest
            // 
            resources.ApplyResources(this.numericBoxTest, "numericBoxTest");
            this.numericBoxTest.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxTest.DecimalPlaces = -2;
            this.numericBoxTest.Maximum = 2D;
            this.numericBoxTest.Minimum = 0D;
            this.numericBoxTest.Multiline = false;
            this.numericBoxTest.Name = "numericBoxTest";
            this.numericBoxTest.RadianValue = 0.0087266462599716477D;
            this.numericBoxTest.ReadOnly = false;
            this.numericBoxTest.RestrictLimitValue = true;
            this.numericBoxTest.ShowFraction = false;
            this.numericBoxTest.ShowPositiveSign = false;
            this.numericBoxTest.ShowUpDown = false;
            this.numericBoxTest.SkipEventDuringInput = false;
            this.numericBoxTest.SmartIncrement = true;
            this.numericBoxTest.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxTest.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxTest.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxTest.ThonsandsSeparator = true;
            this.numericBoxTest.UpDown_Increment = 1D;
            this.numericBoxTest.Value = 0.5D;
            this.numericBoxTest.WordWrap = true;
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
            this.checkBoxSendProfileToPDIndexer.Checked = true;
            this.checkBoxSendProfileToPDIndexer.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.checkBoxSendProfileToPDIndexer, "checkBoxSendProfileToPDIndexer");
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
            this.groupBoxSaveProfile.Controls.Add(this.flowLayoutPanel2);
            this.groupBoxSaveProfile.Controls.Add(this.flowLayoutPanel1);
            resources.ApplyResources(this.groupBoxSaveProfile, "groupBoxSaveProfile");
            this.groupBoxSaveProfile.Name = "groupBoxSaveProfile";
            this.groupBoxSaveProfile.TabStop = false;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsPDIformat);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsCSVformat);
            this.flowLayoutPanel2.Controls.Add(this.radioButtonAsTSVformat);
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
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
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSetDirectoryEachTime);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonSaveAtImageDirectory);
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
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
            this.groupBoxSendPDI.Controls.Add(this.checkBoxSendUnrolledImageToPDIndexer);
            resources.ApplyResources(this.groupBoxSendPDI, "groupBoxSendPDI");
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
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.numericUpDownUnrollSectorStep);
            this.groupBox3.Controls.Add(this.label43);
            resources.ApplyResources(this.groupBox3, "groupBox3");
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.TabStop = false;
            // 
            // numericUpDownUnrollSectorStep
            // 
            this.numericUpDownUnrollSectorStep.DecimalPlaces = 3;
            resources.ApplyResources(this.numericUpDownUnrollSectorStep, "numericUpDownUnrollSectorStep");
            this.numericUpDownUnrollSectorStep.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownUnrollSectorStep.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownUnrollSectorStep.Name = "numericUpDownUnrollSectorStep";
            this.numericUpDownUnrollSectorStep.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // groupBox1
            // 
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
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // numericUpDownUnrolledImageXend
            // 
            this.numericUpDownUnrolledImageXend.DecimalPlaces = 3;
            resources.ApplyResources(this.numericUpDownUnrolledImageXend, "numericUpDownUnrolledImageXend");
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
            this.numericUpDownUnrolledImageXstart.DecimalPlaces = 4;
            resources.ApplyResources(this.numericUpDownUnrolledImageXstart, "numericUpDownUnrolledImageXstart");
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
            this.numericUpDownUnrolledImageXstep.DecimalPlaces = 4;
            resources.ApplyResources(this.numericUpDownUnrolledImageXstep, "numericUpDownUnrolledImageXstep");
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
            this.tabPage2.Controls.Add(this.checkBoxExtensionIPA);
            this.tabPage2.Controls.Add(this.checkBoxExtensionIPF);
            this.tabPage2.Controls.Add(this.checkBoxExtensionIMG);
            this.tabPage2.Controls.Add(this.checkBoxExtensionCCD);
            this.tabPage2.Controls.Add(this.checkBoxExtensionSTL);
            resources.ApplyResources(this.tabPage2, "tabPage2");
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
            this.tabPage5.Controls.Add(this.groupBox11);
            this.tabPage5.Controls.Add(this.groupBox2);
            resources.ApplyResources(this.tabPage5, "tabPage5");
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.label50);
            this.groupBox11.Controls.Add(this.flowLayoutPanel3);
            this.groupBox11.Controls.Add(this.pictureBox1);
            this.groupBox11.Controls.Add(this.radioButtonChiLeft);
            this.groupBox11.Controls.Add(this.radioButtonChiBottom);
            this.groupBox11.Controls.Add(this.radioButtonChiTop);
            this.groupBox11.Controls.Add(this.radioButtonChiRight);
            resources.ApplyResources(this.groupBox11, "groupBox11");
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
            this.pictureBox1.Image = global::IPAnalyzer.Properties.Resources.chi;
            resources.ApplyResources(this.pictureBox1, "pictureBox1");
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
            this.groupBox2.Controls.Add(this.flowLayoutPanel4);
            this.groupBox2.Controls.Add(this.flowLayoutPanelFindCenterOption);
            this.groupBox2.Controls.Add(this.checkBoxFixCenter);
            resources.ApplyResources(this.groupBox2, "groupBox2");
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
            this.numericBoxFindCenterPeakFittingRange.Maximum = double.PositiveInfinity;
            this.numericBoxFindCenterPeakFittingRange.Minimum = 0D;
            this.numericBoxFindCenterPeakFittingRange.Multiline = false;
            this.numericBoxFindCenterPeakFittingRange.Name = "numericBoxFindCenterPeakFittingRange";
            this.numericBoxFindCenterPeakFittingRange.RadianValue = 0.0017453292519943296D;
            this.numericBoxFindCenterPeakFittingRange.ReadOnly = false;
            this.numericBoxFindCenterPeakFittingRange.RestrictLimitValue = true;
            this.numericBoxFindCenterPeakFittingRange.ShowFraction = false;
            this.numericBoxFindCenterPeakFittingRange.ShowPositiveSign = false;
            this.numericBoxFindCenterPeakFittingRange.ShowUpDown = false;
            this.numericBoxFindCenterPeakFittingRange.SkipEventDuringInput = false;
            this.numericBoxFindCenterPeakFittingRange.SmartIncrement = true;
            this.numericBoxFindCenterPeakFittingRange.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxFindCenterPeakFittingRange.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxFindCenterPeakFittingRange.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxFindCenterPeakFittingRange.ThonsandsSeparator = true;
            this.numericBoxFindCenterPeakFittingRange.UpDown_Increment = 1D;
            this.numericBoxFindCenterPeakFittingRange.Value = 0.1D;
            this.numericBoxFindCenterPeakFittingRange.WordWrap = true;
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
            this.numericBoxFindCenterSearchArea.Maximum = double.PositiveInfinity;
            this.numericBoxFindCenterSearchArea.Minimum = double.NegativeInfinity;
            this.numericBoxFindCenterSearchArea.Multiline = false;
            this.numericBoxFindCenterSearchArea.Name = "numericBoxFindCenterSearchArea";
            this.numericBoxFindCenterSearchArea.RadianValue = 0.13962634015954636D;
            this.numericBoxFindCenterSearchArea.ReadOnly = false;
            this.numericBoxFindCenterSearchArea.RestrictLimitValue = true;
            this.numericBoxFindCenterSearchArea.ShowFraction = false;
            this.numericBoxFindCenterSearchArea.ShowPositiveSign = false;
            this.numericBoxFindCenterSearchArea.ShowUpDown = false;
            this.numericBoxFindCenterSearchArea.SkipEventDuringInput = false;
            this.numericBoxFindCenterSearchArea.SmartIncrement = true;
            this.numericBoxFindCenterSearchArea.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxFindCenterSearchArea.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxFindCenterSearchArea.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxFindCenterSearchArea.ThonsandsSeparator = true;
            this.numericBoxFindCenterSearchArea.UpDown_Increment = 1D;
            this.numericBoxFindCenterSearchArea.Value = 8D;
            this.numericBoxFindCenterSearchArea.WordWrap = true;
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
            this.tabPage3.Controls.Add(this.groupBox6);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.label16);
            this.groupBox6.Controls.Add(this.textBoxBackgroundImage);
            this.groupBox6.Controls.Add(this.buttonClearBackgroundImage);
            this.groupBox6.Controls.Add(this.buttonSetBackgroundImage);
            this.groupBox6.Controls.Add(this.numericBoxBackgroundCoeff);
            resources.ApplyResources(this.groupBox6, "groupBox6");
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
            this.numericBoxBackgroundCoeff.Maximum = 10D;
            this.numericBoxBackgroundCoeff.Minimum = 0D;
            this.numericBoxBackgroundCoeff.Multiline = false;
            this.numericBoxBackgroundCoeff.Name = "numericBoxBackgroundCoeff";
            this.numericBoxBackgroundCoeff.RadianValue = 0.017453292519943295D;
            this.numericBoxBackgroundCoeff.ReadOnly = false;
            this.numericBoxBackgroundCoeff.RestrictLimitValue = true;
            this.numericBoxBackgroundCoeff.ShowFraction = false;
            this.numericBoxBackgroundCoeff.ShowPositiveSign = false;
            this.numericBoxBackgroundCoeff.ShowUpDown = false;
            this.numericBoxBackgroundCoeff.SkipEventDuringInput = false;
            this.numericBoxBackgroundCoeff.SmartIncrement = false;
            this.numericBoxBackgroundCoeff.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBoxBackgroundCoeff.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBoxBackgroundCoeff.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBoxBackgroundCoeff.ThonsandsSeparator = true;
            this.numericBoxBackgroundCoeff.UpDown_Increment = 0.001D;
            this.numericBoxBackgroundCoeff.Value = 1D;
            this.numericBoxBackgroundCoeff.WordWrap = true;
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
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::IPAnalyzer.Properties.Settings.Default, "LocationProperty", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Location = global::IPAnalyzer.Properties.Settings.Default.LocationProperty;
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
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFindSpotsDeviation)).EndInit();
            this.groupBoxManualMode.ResumeLayout(false);
            this.groupBoxManualMode.PerformLayout();
            this.groupBoxManualSpot.ResumeLayout(false);
            this.groupBoxManualSpot.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownManualSpotSize)).EndInit();
            this.groupBoxSpline.ResumeLayout(false);
            this.groupBoxSpline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSplineWidth)).EndInit();
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
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownUnrollSectorStep)).EndInit();
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
        public System.Windows.Forms.NumericUpDown numericUpDownUnrollSectorStep;
        public System.Windows.Forms.NumericUpDown numericUpDownUnrolledImageXend;
        public System.Windows.Forms.Label label43;
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
        private System.Windows.Forms.Button buttonSaveMask;
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
        private System.Windows.Forms.GroupBox groupBoxSpline;
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
    }
}