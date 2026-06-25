namespace IPAnalyzer
{
    partial class FormProperty
    {

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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormProperty));
            toolTip = new System.Windows.Forms.ToolTip(components);
            checkBoxCorrectPolarization = new System.Windows.Forms.CheckBox();
            radioButtonDirectSpotMode = new System.Windows.Forms.RadioButton();
            radioButtonFootMode = new System.Windows.Forms.RadioButton();
            radioButtonFlatPanel = new System.Windows.Forms.RadioButton();
            radioButtonGandlfi = new System.Windows.Forms.RadioButton();
            numericUpDownThresholdOfIntensityMax = new System.Windows.Forms.NumericUpDown();
            numericUpDownThresholdOfIntensityMin = new System.Windows.Forms.NumericUpDown();
            numericUpDownEdge = new System.Windows.Forms.NumericUpDown();
            checkBoxOmitSpots = new System.Windows.Forms.CheckBox();
            checkBoxMaskEdge = new System.Windows.Forms.CheckBox();
            checkBoxThresholdMax = new System.Windows.Forms.CheckBox();
            checkBoxThresholdMin = new System.Windows.Forms.CheckBox();
            radioButtonRectangle = new System.Windows.Forms.RadioButton();
            checkBoxRectangleIsBothSide = new System.Windows.Forms.CheckBox();
            comboBoxRectangleDirection = new System.Windows.Forms.ComboBox();
            numericUpDownRectangleBand = new System.Windows.Forms.NumericUpDown();
            numericUpDownRectangleAngle = new System.Windows.Forms.NumericUpDown();
            radioButtonSector = new System.Windows.Forms.RadioButton();
            numericUpDownSectorStartAngle = new System.Windows.Forms.NumericUpDown();
            numericUpDownSectorEndAngle = new System.Windows.Forms.NumericUpDown();
            radioButtonRadial = new System.Windows.Forms.RadioButton();
            radioButtonRadialAngle = new System.Windows.Forms.RadioButton();
            radioButtonRadialDspacing = new System.Windows.Forms.RadioButton();
            radioButtonConcentric = new System.Windows.Forms.RadioButton();
            radioButtonConcentricLength = new System.Windows.Forms.RadioButton();
            radioButtonConcentricDspacing = new System.Windows.Forms.RadioButton();
            radioButtonConcentricAngle = new System.Windows.Forms.RadioButton();
            radioButtonBraggBrentano = new System.Windows.Forms.RadioButton();
            radioButtonDebyeScherrer = new System.Windows.Forms.RadioButton();
            buttonMaskLeft = new System.Windows.Forms.Button();
            buttonMaskTop = new System.Windows.Forms.Button();
            buttonMaskBottom = new System.Windows.Forms.Button();
            buttonMaskRight = new System.Windows.Forms.Button();
            checkBoxManualMaskMode = new System.Windows.Forms.CheckBox();
            radioButtonManualCircle = new System.Windows.Forms.RadioButton();
            radioButtonManualSpline = new System.Windows.Forms.RadioButton();
            radioButtonManualPolygon = new System.Windows.Forms.RadioButton();
            radioButtonManualRectangle = new System.Windows.Forms.RadioButton();
            radioButtonManualSpot = new System.Windows.Forms.RadioButton();
            textBoxManualSpotSize = new System.Windows.Forms.TextBox();
            radioButton1 = new System.Windows.Forms.RadioButton();
            numericUpDownManualSpotSize = new System.Windows.Forms.NumericUpDown();
            radioButtonCircle = new System.Windows.Forms.RadioButton();
            radioButtonTakeoverNothing = new System.Windows.Forms.RadioButton();
            radioButtonTakeoverMask = new System.Windows.Forms.RadioButton();
            radioButtonTakeOverMaskfile = new System.Windows.Forms.RadioButton();
            numericUpDownFindSpotsDeviation = new System.Windows.Forms.NumericUpDown();
            buttonMaskAll = new System.Windows.Forms.Button();
            buttonInvertMask = new System.Windows.Forms.Button();
            buttonUnmaskAll = new System.Windows.Forms.Button();
            checkBoxTest = new System.Windows.Forms.CheckBox();
            checkBoxSendProfileToPDIndexer = new System.Windows.Forms.CheckBox();
            checkBoxSaveFile = new System.Windows.Forms.CheckBox();
            radioButtonSaveInOneFile = new System.Windows.Forms.RadioButton();
            radioButtonSaveInSeparateFiles = new System.Windows.Forms.RadioButton();
            radioButtonSetDirectoryEachTime = new System.Windows.Forms.RadioButton();
            radioButtonSaveAtImageDirectory = new System.Windows.Forms.RadioButton();
            radioButtonAsPDIformat = new System.Windows.Forms.RadioButton();
            radioButtonAsCSVformat = new System.Windows.Forms.RadioButton();
            radioButtonAsTSVformat = new System.Windows.Forms.RadioButton();
            radioButtonAsGSASformat = new System.Windows.Forms.RadioButton();
            checkBoxSendUnrolledImageToPDIndexer = new System.Windows.Forms.CheckBox();
            numericUpDownUnrollChiDivision = new System.Windows.Forms.NumericUpDown();
            numericUpDownUnrolledImageXend = new System.Windows.Forms.NumericUpDown();
            numericUpDownUnrolledImageXstart = new System.Windows.Forms.NumericUpDown();
            numericUpDownUnrolledImageXstep = new System.Windows.Forms.NumericUpDown();
            radioButton2 = new System.Windows.Forms.RadioButton();
            radioButton4 = new System.Windows.Forms.RadioButton();
            radioButton3 = new System.Windows.Forms.RadioButton();
            comboBoxScaleLineDivisions = new System.Windows.Forms.ComboBox();
            checkBoxScaleLabel = new System.Windows.Forms.CheckBox();
            trackBarScaleLineWidth = new System.Windows.Forms.TrackBar();
            radioButtonImageName_FullPath = new System.Windows.Forms.RadioButton();
            radioButtonImageName_LastFolderPlusFilename = new System.Windows.Forms.RadioButton();
            radioButtonImageName_FileName = new System.Windows.Forms.RadioButton();
            checkBoxMaintainImageContrast = new System.Windows.Forms.CheckBox();
            checkBoxMaintainImageRange = new System.Windows.Forms.CheckBox();
            radioButtonChiClockwise = new System.Windows.Forms.RadioButton();
            radioButtonChiCounterclockwise = new System.Windows.Forms.RadioButton();
            pictureBox1 = new System.Windows.Forms.PictureBox();
            radioButtonChiLeft = new System.Windows.Forms.RadioButton();
            radioButtonChiRight = new System.Windows.Forms.RadioButton();
            radioButtonChiBottom = new System.Windows.Forms.RadioButton();
            radioButtonChiTop = new System.Windows.Forms.RadioButton();
            checkBoxFixCenter = new System.Windows.Forms.CheckBox();
            checkBoxExcludeMaskedPixels = new System.Windows.Forms.CheckBox();
            textBoxBackgroundImage = new System.Windows.Forms.TextBox();
            buttonClearBackgroundImage = new System.Windows.Forms.Button();
            buttonSetBackgroundImage = new System.Windows.Forms.Button();
            numericBoxFootPositionY = new Crystallography.Controls.NumericBox();
            numericBoxFootPositionX = new Crystallography.Controls.NumericBox();
            numericBoxCameraLength2 = new Crystallography.Controls.NumericBox();
            numericBoxDirectSpotPositionY = new Crystallography.Controls.NumericBox();
            numericBoxDirectSpotPositionX = new Crystallography.Controls.NumericBox();
            numericBoxCameraLength1 = new Crystallography.Controls.NumericBox();
            numericBoxPixelKsi = new Crystallography.Controls.NumericBox();
            numericBoxPixelSizeY = new Crystallography.Controls.NumericBox();
            numericBoxPixelSizeX = new Crystallography.Controls.NumericBox();
            numericBoxGandlfiRadius = new Crystallography.Controls.NumericBox();
            numericBoxSphericalCorections = new Crystallography.Controls.NumericBox();
            numericBoxTiltTau = new Crystallography.Controls.NumericBox();
            numericBoxTiltPhi = new Crystallography.Controls.NumericBox();
            numericBoxRadialRange = new Crystallography.Controls.NumericBox();
            numericBoxRadialRadius = new Crystallography.Controls.NumericBox();
            numericBoxRadialStep = new Crystallography.Controls.NumericBox();
            numericBoxConcentricStep = new Crystallography.Controls.NumericBox();
            numericBoxConcentricEnd = new Crystallography.Controls.NumericBox();
            numericBoxConcentricStart = new Crystallography.Controls.NumericBox();
            numericBoxSplineWidth = new Crystallography.Controls.NumericBox();
            numericBoxTest = new Crystallography.Controls.NumericBox();
            numericBoxFindCenterPeakFittingRange = new Crystallography.Controls.NumericBox();
            numericBoxFindCenterSearchArea = new Crystallography.Controls.NumericBox();
            numericBoxBackgroundCoeff = new Crystallography.Controls.NumericBox();
            tabControl = new System.Windows.Forms.TabControl();
            tabPageXRay = new System.Windows.Forms.TabPage();
            label15 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            waveLengthControl = new Crystallography.Controls.WaveLengthControl();
            tabPageIP = new System.Windows.Forms.TabPage();
            flowLayoutPanel8 = new System.Windows.Forms.FlowLayoutPanel();
            label22 = new System.Windows.Forms.Label();
            flowLayoutPanel7 = new System.Windows.Forms.FlowLayoutPanel();
            label19 = new System.Windows.Forms.Label();
            flowLayoutPanelFootMode = new System.Windows.Forms.FlowLayoutPanel();
            groupBox9 = new System.Windows.Forms.GroupBox();
            groupBox10 = new System.Windows.Forms.GroupBox();
            label17 = new System.Windows.Forms.Label();
            flowLayoutPanelDirectSpotMode = new System.Windows.Forms.FlowLayoutPanel();
            groupBoxDirectSpotPosition = new System.Windows.Forms.GroupBox();
            groupBoxCameaLength = new System.Windows.Forms.GroupBox();
            label18 = new System.Windows.Forms.Label();
            groupBoxPixelShape = new System.Windows.Forms.GroupBox();
            groupBoxGandlfiRadius = new System.Windows.Forms.GroupBox();
            groupBoxSphericalCorrection = new System.Windows.Forms.GroupBox();
            label26 = new System.Windows.Forms.Label();
            groupBoxTiltCorrection = new System.Windows.Forms.GroupBox();
            tabPageIntegralRegion = new System.Windows.Forms.TabPage();
            groupBox8 = new System.Windows.Forms.GroupBox();
            label2 = new System.Windows.Forms.Label();
            groupBoxRectangle = new System.Windows.Forms.GroupBox();
            label8 = new System.Windows.Forms.Label();
            label7 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            groupBoxSector = new System.Windows.Forms.GroupBox();
            label10 = new System.Windows.Forms.Label();
            label11 = new System.Windows.Forms.Label();
            tabPageIntegralProperty = new System.Windows.Forms.TabPage();
            groupBoxRadial = new System.Windows.Forms.GroupBox();
            label46 = new System.Windows.Forms.Label();
            label40 = new System.Windows.Forms.Label();
            labelDimensionRadial2 = new System.Windows.Forms.Label();
            label37 = new System.Windows.Forms.Label();
            label36 = new System.Windows.Forms.Label();
            labelDimensionRadial1 = new System.Windows.Forms.Label();
            groupBoxConcentric = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label13 = new System.Windows.Forms.Label();
            label14 = new System.Windows.Forms.Label();
            label12 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            tabPageSpotsAndCenter = new System.Windows.Forms.TabPage();
            groupBox13 = new System.Windows.Forms.GroupBox();
            groupBoxManualMode = new System.Windows.Forms.GroupBox();
            groupBoxManualSpot = new System.Windows.Forms.GroupBox();
            label31 = new System.Windows.Forms.Label();
            label30 = new System.Windows.Forms.Label();
            groupBoxSpline = new System.Windows.Forms.GroupBox();
            label29 = new System.Windows.Forms.Label();
            label27 = new System.Windows.Forms.Label();
            groupBox7 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel5 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox12 = new System.Windows.Forms.GroupBox();
            label28 = new System.Windows.Forms.Label();
            tabPageAfterGetProfile = new System.Windows.Forms.TabPage();
            groupBoxSaveProfile = new System.Windows.Forms.GroupBox();
            groupBox17 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox16 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox15 = new System.Windows.Forms.GroupBox();
            flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            groupBoxSendPDI = new System.Windows.Forms.GroupBox();
            tabPage1 = new System.Windows.Forms.TabPage();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox1 = new System.Windows.Forms.GroupBox();
            label38 = new System.Windows.Forms.Label();
            label39 = new System.Windows.Forms.Label();
            label25 = new System.Windows.Forms.Label();
            label41 = new System.Windows.Forms.Label();
            label24 = new System.Windows.Forms.Label();
            label42 = new System.Windows.Forms.Label();
            tabPage5 = new System.Windows.Forms.TabPage();
            groupBox14 = new System.Windows.Forms.GroupBox();
            label5 = new System.Windows.Forms.Label();
            label23 = new System.Windows.Forms.Label();
            colorControlScaleAzimuth = new Crystallography.Controls.ColorControl();
            colorControlScale2Theta = new Crystallography.Controls.ColorControl();
            groupBox19 = new System.Windows.Forms.GroupBox();
            groupBox18 = new System.Windows.Forms.GroupBox();
            groupBox11 = new System.Windows.Forms.GroupBox();
            label50 = new System.Windows.Forms.Label();
            flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            groupBox2 = new System.Windows.Forms.GroupBox();
            flowLayoutPanelFindCenterOption = new System.Windows.Forms.FlowLayoutPanel();
            tabPage3 = new System.Windows.Forms.TabPage();
            groupBox6 = new System.Windows.Forms.GroupBox();
            label16 = new System.Windows.Forms.Label();
            label20 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label21 = new System.Windows.Forms.Label();
            numericUpDownMaskEdge = new System.Windows.Forms.NumericUpDown();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThresholdOfIntensityMax).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThresholdOfIntensityMin).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEdge).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangleBand).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangleAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSectorStartAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSectorEndAngle).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownManualSpotSize).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFindSpotsDeviation).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrollChiDivision).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXend).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXstart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXstep).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLineWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl.SuspendLayout();
            tabPageXRay.SuspendLayout();
            tabPageIP.SuspendLayout();
            flowLayoutPanel8.SuspendLayout();
            flowLayoutPanel7.SuspendLayout();
            flowLayoutPanelFootMode.SuspendLayout();
            groupBox9.SuspendLayout();
            groupBox10.SuspendLayout();
            flowLayoutPanelDirectSpotMode.SuspendLayout();
            groupBoxDirectSpotPosition.SuspendLayout();
            groupBoxCameaLength.SuspendLayout();
            groupBoxPixelShape.SuspendLayout();
            groupBoxGandlfiRadius.SuspendLayout();
            groupBoxSphericalCorrection.SuspendLayout();
            groupBoxTiltCorrection.SuspendLayout();
            tabPageIntegralRegion.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBoxRectangle.SuspendLayout();
            groupBoxSector.SuspendLayout();
            tabPageIntegralProperty.SuspendLayout();
            groupBoxRadial.SuspendLayout();
            groupBoxConcentric.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox5.SuspendLayout();
            tabPageSpotsAndCenter.SuspendLayout();
            groupBox13.SuspendLayout();
            groupBoxManualMode.SuspendLayout();
            groupBoxManualSpot.SuspendLayout();
            groupBoxSpline.SuspendLayout();
            groupBox7.SuspendLayout();
            flowLayoutPanel5.SuspendLayout();
            groupBox12.SuspendLayout();
            tabPageAfterGetProfile.SuspendLayout();
            groupBoxSaveProfile.SuspendLayout();
            groupBox17.SuspendLayout();
            flowLayoutPanel4.SuspendLayout();
            groupBox16.SuspendLayout();
            flowLayoutPanel1.SuspendLayout();
            groupBox15.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            groupBoxSendPDI.SuspendLayout();
            tabPage1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox1.SuspendLayout();
            tabPage5.SuspendLayout();
            groupBox14.SuspendLayout();
            groupBox19.SuspendLayout();
            groupBox18.SuspendLayout();
            groupBox11.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            groupBox2.SuspendLayout();
            flowLayoutPanelFindCenterOption.SuspendLayout();
            tabPage3.SuspendLayout();
            groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaskEdge).BeginInit();
            SuspendLayout();
            // 
            // toolTip
            // 
            toolTip.AutoPopDelay = 10000;
            toolTip.InitialDelay = 500;
            toolTip.IsBalloon = true;
            toolTip.ReshowDelay = 100;
            // 
            // checkBoxCorrectPolarization
            // 
            resources.ApplyResources(checkBoxCorrectPolarization, "checkBoxCorrectPolarization");
            checkBoxCorrectPolarization.Name = "checkBoxCorrectPolarization";
            toolTip.SetToolTip(checkBoxCorrectPolarization, resources.GetString("checkBoxCorrectPolarization.ToolTip"));
            checkBoxCorrectPolarization.UseVisualStyleBackColor = true;
            checkBoxCorrectPolarization.CheckedChanged += checkBoxCorrectPolarization_CheckedChanged;
            // 
            // radioButtonDirectSpotMode
            // 
            resources.ApplyResources(radioButtonDirectSpotMode, "radioButtonDirectSpotMode");
            radioButtonDirectSpotMode.Checked = true;
            radioButtonDirectSpotMode.Name = "radioButtonDirectSpotMode";
            radioButtonDirectSpotMode.TabStop = true;
            toolTip.SetToolTip(radioButtonDirectSpotMode, resources.GetString("radioButtonDirectSpotMode.ToolTip"));
            radioButtonDirectSpotMode.UseVisualStyleBackColor = true;
            radioButtonDirectSpotMode.CheckedChanged += radioButtonDirectSpotMode_CheckedChanged;
            // 
            // radioButtonFootMode
            // 
            resources.ApplyResources(radioButtonFootMode, "radioButtonFootMode");
            radioButtonFootMode.Name = "radioButtonFootMode";
            toolTip.SetToolTip(radioButtonFootMode, resources.GetString("radioButtonFootMode.ToolTip"));
            radioButtonFootMode.UseVisualStyleBackColor = true;
            // 
            // radioButtonFlatPanel
            // 
            resources.ApplyResources(radioButtonFlatPanel, "radioButtonFlatPanel");
            radioButtonFlatPanel.Checked = true;
            radioButtonFlatPanel.Name = "radioButtonFlatPanel";
            radioButtonFlatPanel.TabStop = true;
            toolTip.SetToolTip(radioButtonFlatPanel, resources.GetString("radioButtonFlatPanel.ToolTip"));
            radioButtonFlatPanel.UseVisualStyleBackColor = true;
            radioButtonFlatPanel.CheckedChanged += radioButtonFlatPanel_CheckedChanged;
            // 
            // radioButtonGandlfi
            // 
            resources.ApplyResources(radioButtonGandlfi, "radioButtonGandlfi");
            radioButtonGandlfi.Name = "radioButtonGandlfi";
            toolTip.SetToolTip(radioButtonGandlfi, resources.GetString("radioButtonGandlfi.ToolTip"));
            radioButtonGandlfi.UseVisualStyleBackColor = true;
            // 
            // numericUpDownThresholdOfIntensityMax
            // 
            resources.ApplyResources(numericUpDownThresholdOfIntensityMax, "numericUpDownThresholdOfIntensityMax");
            numericUpDownThresholdOfIntensityMax.Maximum = new decimal(new int[] { 1410065408, 2, 0, 0 });
            numericUpDownThresholdOfIntensityMax.Name = "numericUpDownThresholdOfIntensityMax";
            toolTip.SetToolTip(numericUpDownThresholdOfIntensityMax, resources.GetString("numericUpDownThresholdOfIntensityMax.ToolTip"));
            numericUpDownThresholdOfIntensityMax.Value = new decimal(new int[] { 65535, 0, 0, 0 });
            numericUpDownThresholdOfIntensityMax.ValueChanged += numericUpDownThresholdOfIntensityMax_ValueChanged;
            // 
            // numericUpDownThresholdOfIntensityMin
            // 
            resources.ApplyResources(numericUpDownThresholdOfIntensityMin, "numericUpDownThresholdOfIntensityMin");
            numericUpDownThresholdOfIntensityMin.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDownThresholdOfIntensityMin.Name = "numericUpDownThresholdOfIntensityMin";
            toolTip.SetToolTip(numericUpDownThresholdOfIntensityMin, resources.GetString("numericUpDownThresholdOfIntensityMin.ToolTip"));
            numericUpDownThresholdOfIntensityMin.Value = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownThresholdOfIntensityMin.ValueChanged += numericUpDownThresholdOfIntensityMin_ValueChanged;
            // 
            // numericUpDownEdge
            // 
            resources.ApplyResources(numericUpDownEdge, "numericUpDownEdge");
            numericUpDownEdge.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericUpDownEdge.Name = "numericUpDownEdge";
            toolTip.SetToolTip(numericUpDownEdge, resources.GetString("numericUpDownEdge.ToolTip"));
            numericUpDownEdge.Value = new decimal(new int[] { 5, 0, 0, 0 });
            numericUpDownEdge.ValueChanged += checkBoxMaskEdge_CheckedChanged_1;
            // 
            // checkBoxOmitSpots
            // 
            resources.ApplyResources(checkBoxOmitSpots, "checkBoxOmitSpots");
            checkBoxOmitSpots.Checked = true;
            checkBoxOmitSpots.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxOmitSpots.Name = "checkBoxOmitSpots";
            toolTip.SetToolTip(checkBoxOmitSpots, resources.GetString("checkBoxOmitSpots.ToolTip"));
            // 
            // checkBoxMaskEdge
            // 
            resources.ApplyResources(checkBoxMaskEdge, "checkBoxMaskEdge");
            checkBoxMaskEdge.Checked = true;
            checkBoxMaskEdge.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxMaskEdge.Name = "checkBoxMaskEdge";
            toolTip.SetToolTip(checkBoxMaskEdge, resources.GetString("checkBoxMaskEdge.ToolTip"));
            checkBoxMaskEdge.UseVisualStyleBackColor = true;
            checkBoxMaskEdge.CheckedChanged += checkBoxMaskEdge_CheckedChanged_1;
            // 
            // checkBoxThresholdMax
            // 
            resources.ApplyResources(checkBoxThresholdMax, "checkBoxThresholdMax");
            checkBoxThresholdMax.Name = "checkBoxThresholdMax";
            toolTip.SetToolTip(checkBoxThresholdMax, resources.GetString("checkBoxThresholdMax.ToolTip"));
            checkBoxThresholdMax.CheckedChanged += checkBoxThreshold_CheckedChanged;
            // 
            // checkBoxThresholdMin
            // 
            resources.ApplyResources(checkBoxThresholdMin, "checkBoxThresholdMin");
            checkBoxThresholdMin.Name = "checkBoxThresholdMin";
            toolTip.SetToolTip(checkBoxThresholdMin, resources.GetString("checkBoxThresholdMin.ToolTip"));
            checkBoxThresholdMin.CheckedChanged += checkBoxThreshold_CheckedChanged;
            // 
            // radioButtonRectangle
            // 
            resources.ApplyResources(radioButtonRectangle, "radioButtonRectangle");
            radioButtonRectangle.Checked = true;
            radioButtonRectangle.Name = "radioButtonRectangle";
            radioButtonRectangle.TabStop = true;
            toolTip.SetToolTip(radioButtonRectangle, resources.GetString("radioButtonRectangle.ToolTip"));
            radioButtonRectangle.CheckedChanged += radioButtonRectangle_CheckedChanged;
            // 
            // checkBoxRectangleIsBothSide
            // 
            resources.ApplyResources(checkBoxRectangleIsBothSide, "checkBoxRectangleIsBothSide");
            checkBoxRectangleIsBothSide.Name = "checkBoxRectangleIsBothSide";
            toolTip.SetToolTip(checkBoxRectangleIsBothSide, resources.GetString("checkBoxRectangleIsBothSide.ToolTip"));
            checkBoxRectangleIsBothSide.UseVisualStyleBackColor = true;
            checkBoxRectangleIsBothSide.CheckedChanged += checkBoxRectangleIsBothSide_CheckedChanged;
            // 
            // comboBoxRectangleDirection
            // 
            resources.ApplyResources(comboBoxRectangleDirection, "comboBoxRectangleDirection");
            comboBoxRectangleDirection.Items.AddRange(new object[] { resources.GetString("comboBoxRectangleDirection.Items"), resources.GetString("comboBoxRectangleDirection.Items1"), resources.GetString("comboBoxRectangleDirection.Items2"), resources.GetString("comboBoxRectangleDirection.Items3"), resources.GetString("comboBoxRectangleDirection.Items4"), resources.GetString("comboBoxRectangleDirection.Items5"), resources.GetString("comboBoxRectangleDirection.Items6"), resources.GetString("comboBoxRectangleDirection.Items7") });
            comboBoxRectangleDirection.Name = "comboBoxRectangleDirection";
            toolTip.SetToolTip(comboBoxRectangleDirection, resources.GetString("comboBoxRectangleDirection.ToolTip"));
            comboBoxRectangleDirection.SelectedIndexChanged += comboBoxRectangleDirection_SelectedIndexChanged;
            // 
            // numericUpDownRectangleBand
            // 
            resources.ApplyResources(numericUpDownRectangleBand, "numericUpDownRectangleBand");
            numericUpDownRectangleBand.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownRectangleBand.Name = "numericUpDownRectangleBand";
            toolTip.SetToolTip(numericUpDownRectangleBand, resources.GetString("numericUpDownRectangleBand.ToolTip"));
            numericUpDownRectangleBand.Value = new decimal(new int[] { 1500, 0, 0, 0 });
            numericUpDownRectangleBand.ValueChanged += numericUpDownRectangleBand_ValueChanged;
            // 
            // numericUpDownRectangleAngle
            // 
            resources.ApplyResources(numericUpDownRectangleAngle, "numericUpDownRectangleAngle");
            numericUpDownRectangleAngle.DecimalPlaces = 3;
            numericUpDownRectangleAngle.Maximum = new decimal(new int[] { 360, 0, 0, 0 });
            numericUpDownRectangleAngle.Name = "numericUpDownRectangleAngle";
            toolTip.SetToolTip(numericUpDownRectangleAngle, resources.GetString("numericUpDownRectangleAngle.ToolTip"));
            numericUpDownRectangleAngle.ValueChanged += numericUpDownRectangleAngle_ValueChanged;
            // 
            // radioButtonSector
            // 
            resources.ApplyResources(radioButtonSector, "radioButtonSector");
            radioButtonSector.Name = "radioButtonSector";
            toolTip.SetToolTip(radioButtonSector, resources.GetString("radioButtonSector.ToolTip"));
            // 
            // numericUpDownSectorStartAngle
            // 
            resources.ApplyResources(numericUpDownSectorStartAngle, "numericUpDownSectorStartAngle");
            numericUpDownSectorStartAngle.DecimalPlaces = 2;
            numericUpDownSectorStartAngle.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            numericUpDownSectorStartAngle.Minimum = new decimal(new int[] { 720, 0, 0, int.MinValue });
            numericUpDownSectorStartAngle.Name = "numericUpDownSectorStartAngle";
            toolTip.SetToolTip(numericUpDownSectorStartAngle, resources.GetString("numericUpDownSectorStartAngle.ToolTip"));
            numericUpDownSectorStartAngle.ValueChanged += numericUpDownSectorAngle_ValueChanged;
            // 
            // numericUpDownSectorEndAngle
            // 
            resources.ApplyResources(numericUpDownSectorEndAngle, "numericUpDownSectorEndAngle");
            numericUpDownSectorEndAngle.DecimalPlaces = 2;
            numericUpDownSectorEndAngle.Maximum = new decimal(new int[] { 720, 0, 0, 0 });
            numericUpDownSectorEndAngle.Name = "numericUpDownSectorEndAngle";
            toolTip.SetToolTip(numericUpDownSectorEndAngle, resources.GetString("numericUpDownSectorEndAngle.ToolTip"));
            numericUpDownSectorEndAngle.ValueChanged += numericUpDownSectorAngle_ValueChanged;
            // 
            // radioButtonRadial
            // 
            resources.ApplyResources(radioButtonRadial, "radioButtonRadial");
            radioButtonRadial.Name = "radioButtonRadial";
            toolTip.SetToolTip(radioButtonRadial, resources.GetString("radioButtonRadial.ToolTip"));
            radioButtonRadial.UseVisualStyleBackColor = true;
            // 
            // radioButtonRadialAngle
            // 
            resources.ApplyResources(radioButtonRadialAngle, "radioButtonRadialAngle");
            radioButtonRadialAngle.Checked = true;
            radioButtonRadialAngle.Name = "radioButtonRadialAngle";
            radioButtonRadialAngle.TabStop = true;
            toolTip.SetToolTip(radioButtonRadialAngle, resources.GetString("radioButtonRadialAngle.ToolTip"));
            radioButtonRadialAngle.CheckedChanged += radioButtonRadialAngle_CheckedChanged;
            // 
            // radioButtonRadialDspacing
            // 
            resources.ApplyResources(radioButtonRadialDspacing, "radioButtonRadialDspacing");
            radioButtonRadialDspacing.Name = "radioButtonRadialDspacing";
            toolTip.SetToolTip(radioButtonRadialDspacing, resources.GetString("radioButtonRadialDspacing.ToolTip"));
            // 
            // radioButtonConcentric
            // 
            resources.ApplyResources(radioButtonConcentric, "radioButtonConcentric");
            radioButtonConcentric.Checked = true;
            radioButtonConcentric.Name = "radioButtonConcentric";
            radioButtonConcentric.TabStop = true;
            toolTip.SetToolTip(radioButtonConcentric, resources.GetString("radioButtonConcentric.ToolTip"));
            radioButtonConcentric.UseVisualStyleBackColor = true;
            radioButtonConcentric.CheckedChanged += radioButtonRadial_CheckedChanged;
            // 
            // radioButtonConcentricLength
            // 
            resources.ApplyResources(radioButtonConcentricLength, "radioButtonConcentricLength");
            radioButtonConcentricLength.Name = "radioButtonConcentricLength";
            toolTip.SetToolTip(radioButtonConcentricLength, resources.GetString("radioButtonConcentricLength.ToolTip"));
            radioButtonConcentricLength.CheckedChanged += radioButtonAngleMode_CheckedChanged;
            // 
            // radioButtonConcentricDspacing
            // 
            resources.ApplyResources(radioButtonConcentricDspacing, "radioButtonConcentricDspacing");
            radioButtonConcentricDspacing.Name = "radioButtonConcentricDspacing";
            toolTip.SetToolTip(radioButtonConcentricDspacing, resources.GetString("radioButtonConcentricDspacing.ToolTip"));
            radioButtonConcentricDspacing.CheckedChanged += radioButtonAngleMode_CheckedChanged;
            // 
            // radioButtonConcentricAngle
            // 
            resources.ApplyResources(radioButtonConcentricAngle, "radioButtonConcentricAngle");
            radioButtonConcentricAngle.Checked = true;
            radioButtonConcentricAngle.Name = "radioButtonConcentricAngle";
            radioButtonConcentricAngle.TabStop = true;
            toolTip.SetToolTip(radioButtonConcentricAngle, resources.GetString("radioButtonConcentricAngle.ToolTip"));
            radioButtonConcentricAngle.CheckedChanged += radioButtonAngleMode_CheckedChanged;
            // 
            // radioButtonBraggBrentano
            // 
            resources.ApplyResources(radioButtonBraggBrentano, "radioButtonBraggBrentano");
            radioButtonBraggBrentano.Checked = true;
            radioButtonBraggBrentano.Name = "radioButtonBraggBrentano";
            radioButtonBraggBrentano.TabStop = true;
            toolTip.SetToolTip(radioButtonBraggBrentano, resources.GetString("radioButtonBraggBrentano.ToolTip"));
            // 
            // radioButtonDebyeScherrer
            // 
            resources.ApplyResources(radioButtonDebyeScherrer, "radioButtonDebyeScherrer");
            radioButtonDebyeScherrer.Name = "radioButtonDebyeScherrer";
            toolTip.SetToolTip(radioButtonDebyeScherrer, resources.GetString("radioButtonDebyeScherrer.ToolTip"));
            // 
            // buttonMaskLeft
            // 
            resources.ApplyResources(buttonMaskLeft, "buttonMaskLeft");
            buttonMaskLeft.Name = "buttonMaskLeft";
            toolTip.SetToolTip(buttonMaskLeft, resources.GetString("buttonMaskLeft.ToolTip"));
            buttonMaskLeft.UseVisualStyleBackColor = true;
            buttonMaskLeft.Click += buttonMaskAll_Click;
            // 
            // buttonMaskTop
            // 
            resources.ApplyResources(buttonMaskTop, "buttonMaskTop");
            buttonMaskTop.Name = "buttonMaskTop";
            toolTip.SetToolTip(buttonMaskTop, resources.GetString("buttonMaskTop.ToolTip"));
            buttonMaskTop.UseVisualStyleBackColor = true;
            buttonMaskTop.Click += buttonMaskAll_Click;
            // 
            // buttonMaskBottom
            // 
            resources.ApplyResources(buttonMaskBottom, "buttonMaskBottom");
            buttonMaskBottom.Name = "buttonMaskBottom";
            toolTip.SetToolTip(buttonMaskBottom, resources.GetString("buttonMaskBottom.ToolTip"));
            buttonMaskBottom.UseVisualStyleBackColor = true;
            buttonMaskBottom.Click += buttonMaskAll_Click;
            // 
            // buttonMaskRight
            // 
            resources.ApplyResources(buttonMaskRight, "buttonMaskRight");
            buttonMaskRight.Name = "buttonMaskRight";
            toolTip.SetToolTip(buttonMaskRight, resources.GetString("buttonMaskRight.ToolTip"));
            buttonMaskRight.UseVisualStyleBackColor = true;
            buttonMaskRight.Click += buttonMaskAll_Click;
            // 
            // checkBoxManualMaskMode
            // 
            resources.ApplyResources(checkBoxManualMaskMode, "checkBoxManualMaskMode");
            checkBoxManualMaskMode.Name = "checkBoxManualMaskMode";
            toolTip.SetToolTip(checkBoxManualMaskMode, resources.GetString("checkBoxManualMaskMode.ToolTip"));
            checkBoxManualMaskMode.UseVisualStyleBackColor = true;
            checkBoxManualMaskMode.CheckedChanged += checkBoxManualMaskMode_CheckedChanged;
            // 
            // radioButtonManualCircle
            // 
            resources.ApplyResources(radioButtonManualCircle, "radioButtonManualCircle");
            radioButtonManualCircle.Name = "radioButtonManualCircle";
            toolTip.SetToolTip(radioButtonManualCircle, resources.GetString("radioButtonManualCircle.ToolTip"));
            radioButtonManualCircle.UseVisualStyleBackColor = true;
            radioButtonManualCircle.CheckedChanged += radioButtonManualSpot_CheckedChanged;
            // 
            // radioButtonManualSpline
            // 
            resources.ApplyResources(radioButtonManualSpline, "radioButtonManualSpline");
            radioButtonManualSpline.Name = "radioButtonManualSpline";
            toolTip.SetToolTip(radioButtonManualSpline, resources.GetString("radioButtonManualSpline.ToolTip"));
            radioButtonManualSpline.UseVisualStyleBackColor = true;
            radioButtonManualSpline.CheckedChanged += radioButtonManualSpot_CheckedChanged;
            // 
            // radioButtonManualPolygon
            // 
            resources.ApplyResources(radioButtonManualPolygon, "radioButtonManualPolygon");
            radioButtonManualPolygon.Name = "radioButtonManualPolygon";
            toolTip.SetToolTip(radioButtonManualPolygon, resources.GetString("radioButtonManualPolygon.ToolTip"));
            radioButtonManualPolygon.UseVisualStyleBackColor = true;
            radioButtonManualPolygon.CheckedChanged += radioButtonManualSpot_CheckedChanged;
            // 
            // radioButtonManualRectangle
            // 
            resources.ApplyResources(radioButtonManualRectangle, "radioButtonManualRectangle");
            radioButtonManualRectangle.Name = "radioButtonManualRectangle";
            toolTip.SetToolTip(radioButtonManualRectangle, resources.GetString("radioButtonManualRectangle.ToolTip"));
            radioButtonManualRectangle.UseVisualStyleBackColor = true;
            radioButtonManualRectangle.CheckedChanged += radioButtonManualSpot_CheckedChanged;
            // 
            // radioButtonManualSpot
            // 
            resources.ApplyResources(radioButtonManualSpot, "radioButtonManualSpot");
            radioButtonManualSpot.Checked = true;
            radioButtonManualSpot.Name = "radioButtonManualSpot";
            radioButtonManualSpot.TabStop = true;
            toolTip.SetToolTip(radioButtonManualSpot, resources.GetString("radioButtonManualSpot.ToolTip"));
            radioButtonManualSpot.UseVisualStyleBackColor = true;
            radioButtonManualSpot.CheckedChanged += radioButtonManualSpot_CheckedChanged;
            // 
            // textBoxManualSpotSize
            // 
            resources.ApplyResources(textBoxManualSpotSize, "textBoxManualSpotSize");
            textBoxManualSpotSize.Name = "textBoxManualSpotSize";
            toolTip.SetToolTip(textBoxManualSpotSize, resources.GetString("textBoxManualSpotSize.ToolTip"));
            textBoxManualSpotSize.TextChanged += textBoxManualSpotSize_TextChanged;
            // 
            // radioButton1
            // 
            resources.ApplyResources(radioButton1, "radioButton1");
            radioButton1.Name = "radioButton1";
            toolTip.SetToolTip(radioButton1, resources.GetString("radioButton1.ToolTip"));
            radioButton1.UseVisualStyleBackColor = true;
            // 
            // numericUpDownManualSpotSize
            // 
            resources.ApplyResources(numericUpDownManualSpotSize, "numericUpDownManualSpotSize");
            numericUpDownManualSpotSize.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownManualSpotSize.Name = "numericUpDownManualSpotSize";
            toolTip.SetToolTip(numericUpDownManualSpotSize, resources.GetString("numericUpDownManualSpotSize.ToolTip"));
            numericUpDownManualSpotSize.Value = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownManualSpotSize.ValueChanged += numericUpDownManualSpotSize_ValueChanged;
            // 
            // radioButtonCircle
            // 
            resources.ApplyResources(radioButtonCircle, "radioButtonCircle");
            radioButtonCircle.Checked = true;
            radioButtonCircle.Name = "radioButtonCircle";
            radioButtonCircle.TabStop = true;
            toolTip.SetToolTip(radioButtonCircle, resources.GetString("radioButtonCircle.ToolTip"));
            radioButtonCircle.UseVisualStyleBackColor = true;
            // 
            // radioButtonTakeoverNothing
            // 
            resources.ApplyResources(radioButtonTakeoverNothing, "radioButtonTakeoverNothing");
            radioButtonTakeoverNothing.Name = "radioButtonTakeoverNothing";
            toolTip.SetToolTip(radioButtonTakeoverNothing, resources.GetString("radioButtonTakeoverNothing.ToolTip"));
            radioButtonTakeoverNothing.UseVisualStyleBackColor = true;
            // 
            // radioButtonTakeoverMask
            // 
            resources.ApplyResources(radioButtonTakeoverMask, "radioButtonTakeoverMask");
            radioButtonTakeoverMask.Checked = true;
            radioButtonTakeoverMask.Name = "radioButtonTakeoverMask";
            radioButtonTakeoverMask.TabStop = true;
            toolTip.SetToolTip(radioButtonTakeoverMask, resources.GetString("radioButtonTakeoverMask.ToolTip"));
            radioButtonTakeoverMask.UseVisualStyleBackColor = true;
            // 
            // radioButtonTakeOverMaskfile
            // 
            resources.ApplyResources(radioButtonTakeOverMaskfile, "radioButtonTakeOverMaskfile");
            radioButtonTakeOverMaskfile.Name = "radioButtonTakeOverMaskfile";
            toolTip.SetToolTip(radioButtonTakeOverMaskfile, resources.GetString("radioButtonTakeOverMaskfile.ToolTip"));
            radioButtonTakeOverMaskfile.UseVisualStyleBackColor = true;
            // 
            // numericUpDownFindSpotsDeviation
            // 
            resources.ApplyResources(numericUpDownFindSpotsDeviation, "numericUpDownFindSpotsDeviation");
            numericUpDownFindSpotsDeviation.DecimalPlaces = 2;
            numericUpDownFindSpotsDeviation.Increment = new decimal(new int[] { 1, 0, 0, 65536 });
            numericUpDownFindSpotsDeviation.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            numericUpDownFindSpotsDeviation.Name = "numericUpDownFindSpotsDeviation";
            toolTip.SetToolTip(numericUpDownFindSpotsDeviation, resources.GetString("numericUpDownFindSpotsDeviation.ToolTip"));
            numericUpDownFindSpotsDeviation.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // buttonMaskAll
            // 
            resources.ApplyResources(buttonMaskAll, "buttonMaskAll");
            buttonMaskAll.Name = "buttonMaskAll";
            toolTip.SetToolTip(buttonMaskAll, resources.GetString("buttonMaskAll.ToolTip"));
            buttonMaskAll.UseVisualStyleBackColor = true;
            buttonMaskAll.Click += buttonMaskAll_Click;
            // 
            // buttonInvertMask
            // 
            resources.ApplyResources(buttonInvertMask, "buttonInvertMask");
            buttonInvertMask.Name = "buttonInvertMask";
            toolTip.SetToolTip(buttonInvertMask, resources.GetString("buttonInvertMask.ToolTip"));
            buttonInvertMask.UseVisualStyleBackColor = true;
            buttonInvertMask.Click += buttonInvertMask_Click;
            // 
            // buttonUnmaskAll
            // 
            resources.ApplyResources(buttonUnmaskAll, "buttonUnmaskAll");
            buttonUnmaskAll.Name = "buttonUnmaskAll";
            toolTip.SetToolTip(buttonUnmaskAll, resources.GetString("buttonUnmaskAll.ToolTip"));
            buttonUnmaskAll.UseVisualStyleBackColor = true;
            buttonUnmaskAll.Click += buttonUnmaskAll_Click;
            // 
            // checkBoxTest
            // 
            resources.ApplyResources(checkBoxTest, "checkBoxTest");
            checkBoxTest.Checked = true;
            checkBoxTest.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxTest.Name = "checkBoxTest";
            toolTip.SetToolTip(checkBoxTest, resources.GetString("checkBoxTest.ToolTip"));
            checkBoxTest.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendProfileToPDIndexer
            // 
            resources.ApplyResources(checkBoxSendProfileToPDIndexer, "checkBoxSendProfileToPDIndexer");
            checkBoxSendProfileToPDIndexer.Checked = true;
            checkBoxSendProfileToPDIndexer.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxSendProfileToPDIndexer.Name = "checkBoxSendProfileToPDIndexer";
            toolTip.SetToolTip(checkBoxSendProfileToPDIndexer, resources.GetString("checkBoxSendProfileToPDIndexer.ToolTip"));
            checkBoxSendProfileToPDIndexer.CheckedChanged += checkBoxSendProfileToPDIndexer_CheckedChanged;
            // 
            // checkBoxSaveFile
            // 
            resources.ApplyResources(checkBoxSaveFile, "checkBoxSaveFile");
            checkBoxSaveFile.Name = "checkBoxSaveFile";
            toolTip.SetToolTip(checkBoxSaveFile, resources.GetString("checkBoxSaveFile.ToolTip"));
            checkBoxSaveFile.CheckedChanged += checkBoxSaveFile_CheckedChanged;
            // 
            // radioButtonSaveInOneFile
            // 
            resources.ApplyResources(radioButtonSaveInOneFile, "radioButtonSaveInOneFile");
            radioButtonSaveInOneFile.Name = "radioButtonSaveInOneFile";
            toolTip.SetToolTip(radioButtonSaveInOneFile, resources.GetString("radioButtonSaveInOneFile.ToolTip"));
            radioButtonSaveInOneFile.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveInSeparateFiles
            // 
            resources.ApplyResources(radioButtonSaveInSeparateFiles, "radioButtonSaveInSeparateFiles");
            radioButtonSaveInSeparateFiles.Checked = true;
            radioButtonSaveInSeparateFiles.Name = "radioButtonSaveInSeparateFiles";
            radioButtonSaveInSeparateFiles.TabStop = true;
            toolTip.SetToolTip(radioButtonSaveInSeparateFiles, resources.GetString("radioButtonSaveInSeparateFiles.ToolTip"));
            radioButtonSaveInSeparateFiles.UseVisualStyleBackColor = true;
            // 
            // radioButtonSetDirectoryEachTime
            // 
            resources.ApplyResources(radioButtonSetDirectoryEachTime, "radioButtonSetDirectoryEachTime");
            radioButtonSetDirectoryEachTime.Name = "radioButtonSetDirectoryEachTime";
            toolTip.SetToolTip(radioButtonSetDirectoryEachTime, resources.GetString("radioButtonSetDirectoryEachTime.ToolTip"));
            radioButtonSetDirectoryEachTime.UseVisualStyleBackColor = true;
            // 
            // radioButtonSaveAtImageDirectory
            // 
            resources.ApplyResources(radioButtonSaveAtImageDirectory, "radioButtonSaveAtImageDirectory");
            radioButtonSaveAtImageDirectory.Checked = true;
            radioButtonSaveAtImageDirectory.Name = "radioButtonSaveAtImageDirectory";
            radioButtonSaveAtImageDirectory.TabStop = true;
            toolTip.SetToolTip(radioButtonSaveAtImageDirectory, resources.GetString("radioButtonSaveAtImageDirectory.ToolTip"));
            radioButtonSaveAtImageDirectory.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsPDIformat
            // 
            resources.ApplyResources(radioButtonAsPDIformat, "radioButtonAsPDIformat");
            radioButtonAsPDIformat.Name = "radioButtonAsPDIformat";
            toolTip.SetToolTip(radioButtonAsPDIformat, resources.GetString("radioButtonAsPDIformat.ToolTip"));
            radioButtonAsPDIformat.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsCSVformat
            // 
            resources.ApplyResources(radioButtonAsCSVformat, "radioButtonAsCSVformat");
            radioButtonAsCSVformat.Checked = true;
            radioButtonAsCSVformat.Name = "radioButtonAsCSVformat";
            radioButtonAsCSVformat.TabStop = true;
            toolTip.SetToolTip(radioButtonAsCSVformat, resources.GetString("radioButtonAsCSVformat.ToolTip"));
            radioButtonAsCSVformat.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsTSVformat
            // 
            resources.ApplyResources(radioButtonAsTSVformat, "radioButtonAsTSVformat");
            radioButtonAsTSVformat.Name = "radioButtonAsTSVformat";
            toolTip.SetToolTip(radioButtonAsTSVformat, resources.GetString("radioButtonAsTSVformat.ToolTip"));
            radioButtonAsTSVformat.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsGSASformat
            // 
            resources.ApplyResources(radioButtonAsGSASformat, "radioButtonAsGSASformat");
            radioButtonAsGSASformat.Name = "radioButtonAsGSASformat";
            toolTip.SetToolTip(radioButtonAsGSASformat, resources.GetString("radioButtonAsGSASformat.ToolTip"));
            radioButtonAsGSASformat.UseVisualStyleBackColor = true;
            // 
            // checkBoxSendUnrolledImageToPDIndexer
            // 
            resources.ApplyResources(checkBoxSendUnrolledImageToPDIndexer, "checkBoxSendUnrolledImageToPDIndexer");
            checkBoxSendUnrolledImageToPDIndexer.Name = "checkBoxSendUnrolledImageToPDIndexer";
            toolTip.SetToolTip(checkBoxSendUnrolledImageToPDIndexer, resources.GetString("checkBoxSendUnrolledImageToPDIndexer.ToolTip"));
            checkBoxSendUnrolledImageToPDIndexer.CheckedChanged += checkBoxSendUnrolledImageToPDIndexer_CheckedChanged;
            // 
            // numericUpDownUnrollChiDivision
            // 
            resources.ApplyResources(numericUpDownUnrollChiDivision, "numericUpDownUnrollChiDivision");
            numericUpDownUnrollChiDivision.Maximum = new decimal(new int[] { 2048, 0, 0, 0 });
            numericUpDownUnrollChiDivision.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownUnrollChiDivision.Name = "numericUpDownUnrollChiDivision";
            toolTip.SetToolTip(numericUpDownUnrollChiDivision, resources.GetString("numericUpDownUnrollChiDivision.ToolTip"));
            numericUpDownUnrollChiDivision.Value = new decimal(new int[] { 720, 0, 0, 0 });
            // 
            // numericUpDownUnrolledImageXend
            // 
            resources.ApplyResources(numericUpDownUnrolledImageXend, "numericUpDownUnrolledImageXend");
            numericUpDownUnrolledImageXend.DecimalPlaces = 3;
            numericUpDownUnrolledImageXend.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numericUpDownUnrolledImageXend.Name = "numericUpDownUnrolledImageXend";
            toolTip.SetToolTip(numericUpDownUnrolledImageXend, resources.GetString("numericUpDownUnrolledImageXend.ToolTip"));
            numericUpDownUnrolledImageXend.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // numericUpDownUnrolledImageXstart
            // 
            resources.ApplyResources(numericUpDownUnrolledImageXstart, "numericUpDownUnrolledImageXstart");
            numericUpDownUnrolledImageXstart.DecimalPlaces = 4;
            numericUpDownUnrolledImageXstart.Increment = new decimal(new int[] { 1, 0, 0, 131072 });
            numericUpDownUnrolledImageXstart.Maximum = new decimal(new int[] { 180, 0, 0, 0 });
            numericUpDownUnrolledImageXstart.Name = "numericUpDownUnrolledImageXstart";
            toolTip.SetToolTip(numericUpDownUnrolledImageXstart, resources.GetString("numericUpDownUnrolledImageXstart.ToolTip"));
            numericUpDownUnrolledImageXstart.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // numericUpDownUnrolledImageXstep
            // 
            resources.ApplyResources(numericUpDownUnrolledImageXstep, "numericUpDownUnrolledImageXstep");
            numericUpDownUnrolledImageXstep.DecimalPlaces = 4;
            numericUpDownUnrolledImageXstep.Increment = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownUnrolledImageXstep.Minimum = new decimal(new int[] { 1, 0, 0, 196608 });
            numericUpDownUnrolledImageXstep.Name = "numericUpDownUnrolledImageXstep";
            toolTip.SetToolTip(numericUpDownUnrolledImageXstep, resources.GetString("numericUpDownUnrolledImageXstep.ToolTip"));
            numericUpDownUnrolledImageXstep.Value = new decimal(new int[] { 4, 0, 0, 131072 });
            // 
            // radioButton2
            // 
            resources.ApplyResources(radioButton2, "radioButton2");
            radioButton2.Name = "radioButton2";
            toolTip.SetToolTip(radioButton2, resources.GetString("radioButton2.ToolTip"));
            // 
            // radioButton4
            // 
            resources.ApplyResources(radioButton4, "radioButton4");
            radioButton4.Checked = true;
            radioButton4.Name = "radioButton4";
            radioButton4.TabStop = true;
            toolTip.SetToolTip(radioButton4, resources.GetString("radioButton4.ToolTip"));
            // 
            // radioButton3
            // 
            resources.ApplyResources(radioButton3, "radioButton3");
            radioButton3.Name = "radioButton3";
            toolTip.SetToolTip(radioButton3, resources.GetString("radioButton3.ToolTip"));
            // 
            // comboBoxScaleLineDivisions
            // 
            resources.ApplyResources(comboBoxScaleLineDivisions, "comboBoxScaleLineDivisions");
            comboBoxScaleLineDivisions.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            comboBoxScaleLineDivisions.FormattingEnabled = true;
            comboBoxScaleLineDivisions.Items.AddRange(new object[] { resources.GetString("comboBoxScaleLineDivisions.Items"), resources.GetString("comboBoxScaleLineDivisions.Items1"), resources.GetString("comboBoxScaleLineDivisions.Items2"), resources.GetString("comboBoxScaleLineDivisions.Items3") });
            comboBoxScaleLineDivisions.Name = "comboBoxScaleLineDivisions";
            toolTip.SetToolTip(comboBoxScaleLineDivisions, resources.GetString("comboBoxScaleLineDivisions.ToolTip"));
            comboBoxScaleLineDivisions.SelectedIndexChanged += comboBoxScaleLineDivisions_SelectedIndexChanged;
            // 
            // checkBoxScaleLabel
            // 
            resources.ApplyResources(checkBoxScaleLabel, "checkBoxScaleLabel");
            checkBoxScaleLabel.Checked = true;
            checkBoxScaleLabel.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxScaleLabel.Name = "checkBoxScaleLabel";
            toolTip.SetToolTip(checkBoxScaleLabel, resources.GetString("checkBoxScaleLabel.ToolTip"));
            checkBoxScaleLabel.UseVisualStyleBackColor = true;
            checkBoxScaleLabel.CheckedChanged += checkBoxScaleLabel_CheckedChanged;
            // 
            // trackBarScaleLineWidth
            // 
            resources.ApplyResources(trackBarScaleLineWidth, "trackBarScaleLineWidth");
            trackBarScaleLineWidth.Minimum = 1;
            trackBarScaleLineWidth.Name = "trackBarScaleLineWidth";
            trackBarScaleLineWidth.TickStyle = System.Windows.Forms.TickStyle.None;
            toolTip.SetToolTip(trackBarScaleLineWidth, resources.GetString("trackBarScaleLineWidth.ToolTip"));
            trackBarScaleLineWidth.Value = 1;
            trackBarScaleLineWidth.Scroll += trackBarScaleLineWidth_Scroll;
            // 
            // radioButtonImageName_FullPath
            // 
            resources.ApplyResources(radioButtonImageName_FullPath, "radioButtonImageName_FullPath");
            radioButtonImageName_FullPath.Name = "radioButtonImageName_FullPath";
            toolTip.SetToolTip(radioButtonImageName_FullPath, resources.GetString("radioButtonImageName_FullPath.ToolTip"));
            radioButtonImageName_FullPath.UseVisualStyleBackColor = true;
            // 
            // radioButtonImageName_LastFolderPlusFilename
            // 
            resources.ApplyResources(radioButtonImageName_LastFolderPlusFilename, "radioButtonImageName_LastFolderPlusFilename");
            radioButtonImageName_LastFolderPlusFilename.Name = "radioButtonImageName_LastFolderPlusFilename";
            toolTip.SetToolTip(radioButtonImageName_LastFolderPlusFilename, resources.GetString("radioButtonImageName_LastFolderPlusFilename.ToolTip"));
            radioButtonImageName_LastFolderPlusFilename.UseVisualStyleBackColor = true;
            // 
            // radioButtonImageName_FileName
            // 
            resources.ApplyResources(radioButtonImageName_FileName, "radioButtonImageName_FileName");
            radioButtonImageName_FileName.Checked = true;
            radioButtonImageName_FileName.Name = "radioButtonImageName_FileName";
            radioButtonImageName_FileName.TabStop = true;
            toolTip.SetToolTip(radioButtonImageName_FileName, resources.GetString("radioButtonImageName_FileName.ToolTip"));
            radioButtonImageName_FileName.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaintainImageContrast
            // 
            resources.ApplyResources(checkBoxMaintainImageContrast, "checkBoxMaintainImageContrast");
            checkBoxMaintainImageContrast.Checked = true;
            checkBoxMaintainImageContrast.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxMaintainImageContrast.Name = "checkBoxMaintainImageContrast";
            toolTip.SetToolTip(checkBoxMaintainImageContrast, resources.GetString("checkBoxMaintainImageContrast.ToolTip"));
            checkBoxMaintainImageContrast.UseVisualStyleBackColor = true;
            checkBoxMaintainImageContrast.CheckedChanged += checkBoxFixCenter_CheckedChanged;
            // 
            // checkBoxMaintainImageRange
            // 
            resources.ApplyResources(checkBoxMaintainImageRange, "checkBoxMaintainImageRange");
            checkBoxMaintainImageRange.Checked = true;
            checkBoxMaintainImageRange.CheckState = System.Windows.Forms.CheckState.Checked;
            checkBoxMaintainImageRange.Name = "checkBoxMaintainImageRange";
            toolTip.SetToolTip(checkBoxMaintainImageRange, resources.GetString("checkBoxMaintainImageRange.ToolTip"));
            checkBoxMaintainImageRange.UseVisualStyleBackColor = true;
            checkBoxMaintainImageRange.CheckedChanged += checkBoxFixCenter_CheckedChanged;
            // 
            // radioButtonChiClockwise
            // 
            resources.ApplyResources(radioButtonChiClockwise, "radioButtonChiClockwise");
            radioButtonChiClockwise.Checked = true;
            radioButtonChiClockwise.Name = "radioButtonChiClockwise";
            radioButtonChiClockwise.TabStop = true;
            toolTip.SetToolTip(radioButtonChiClockwise, resources.GetString("radioButtonChiClockwise.ToolTip"));
            radioButtonChiClockwise.UseVisualStyleBackColor = true;
            radioButtonChiClockwise.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // radioButtonChiCounterclockwise
            // 
            resources.ApplyResources(radioButtonChiCounterclockwise, "radioButtonChiCounterclockwise");
            radioButtonChiCounterclockwise.Name = "radioButtonChiCounterclockwise";
            toolTip.SetToolTip(radioButtonChiCounterclockwise, resources.GetString("radioButtonChiCounterclockwise.ToolTip"));
            radioButtonChiCounterclockwise.UseVisualStyleBackColor = true;
            radioButtonChiCounterclockwise.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // pictureBox1
            // 
            resources.ApplyResources(pictureBox1, "pictureBox1");
            pictureBox1.Image = Properties.Resources.chi;
            pictureBox1.Name = "pictureBox1";
            pictureBox1.TabStop = false;
            toolTip.SetToolTip(pictureBox1, resources.GetString("pictureBox1.ToolTip"));
            // 
            // radioButtonChiLeft
            // 
            resources.ApplyResources(radioButtonChiLeft, "radioButtonChiLeft");
            radioButtonChiLeft.Name = "radioButtonChiLeft";
            toolTip.SetToolTip(radioButtonChiLeft, resources.GetString("radioButtonChiLeft.ToolTip"));
            radioButtonChiLeft.UseVisualStyleBackColor = true;
            radioButtonChiLeft.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // radioButtonChiRight
            // 
            resources.ApplyResources(radioButtonChiRight, "radioButtonChiRight");
            radioButtonChiRight.Checked = true;
            radioButtonChiRight.Name = "radioButtonChiRight";
            radioButtonChiRight.TabStop = true;
            toolTip.SetToolTip(radioButtonChiRight, resources.GetString("radioButtonChiRight.ToolTip"));
            radioButtonChiRight.UseVisualStyleBackColor = true;
            radioButtonChiRight.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // radioButtonChiBottom
            // 
            resources.ApplyResources(radioButtonChiBottom, "radioButtonChiBottom");
            radioButtonChiBottom.Name = "radioButtonChiBottom";
            toolTip.SetToolTip(radioButtonChiBottom, resources.GetString("radioButtonChiBottom.ToolTip"));
            radioButtonChiBottom.UseVisualStyleBackColor = true;
            radioButtonChiBottom.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // radioButtonChiTop
            // 
            resources.ApplyResources(radioButtonChiTop, "radioButtonChiTop");
            radioButtonChiTop.Name = "radioButtonChiTop";
            toolTip.SetToolTip(radioButtonChiTop, resources.GetString("radioButtonChiTop.ToolTip"));
            radioButtonChiTop.UseVisualStyleBackColor = true;
            radioButtonChiTop.CheckedChanged += radioButtonChi_CheckedChanged;
            // 
            // checkBoxFixCenter
            // 
            resources.ApplyResources(checkBoxFixCenter, "checkBoxFixCenter");
            checkBoxFixCenter.Name = "checkBoxFixCenter";
            toolTip.SetToolTip(checkBoxFixCenter, resources.GetString("checkBoxFixCenter.ToolTip"));
            checkBoxFixCenter.UseVisualStyleBackColor = true;
            checkBoxFixCenter.CheckedChanged += checkBoxFixCenter_CheckedChanged;
            // 
            // checkBoxExcludeMaskedPixels
            // 
            resources.ApplyResources(checkBoxExcludeMaskedPixels, "checkBoxExcludeMaskedPixels");
            checkBoxExcludeMaskedPixels.Name = "checkBoxExcludeMaskedPixels";
            toolTip.SetToolTip(checkBoxExcludeMaskedPixels, resources.GetString("checkBoxExcludeMaskedPixels.ToolTip"));
            checkBoxExcludeMaskedPixels.UseVisualStyleBackColor = true;
            checkBoxExcludeMaskedPixels.CheckedChanged += checkBoxFixCenter_CheckedChanged;
            // 
            // textBoxBackgroundImage
            // 
            resources.ApplyResources(textBoxBackgroundImage, "textBoxBackgroundImage");
            textBoxBackgroundImage.Name = "textBoxBackgroundImage";
            textBoxBackgroundImage.ReadOnly = true;
            toolTip.SetToolTip(textBoxBackgroundImage, resources.GetString("textBoxBackgroundImage.ToolTip"));
            // 
            // buttonClearBackgroundImage
            // 
            resources.ApplyResources(buttonClearBackgroundImage, "buttonClearBackgroundImage");
            buttonClearBackgroundImage.Name = "buttonClearBackgroundImage";
            toolTip.SetToolTip(buttonClearBackgroundImage, resources.GetString("buttonClearBackgroundImage.ToolTip"));
            buttonClearBackgroundImage.UseVisualStyleBackColor = true;
            buttonClearBackgroundImage.Click += buttonClearBackgroundImage_Click;
            // 
            // buttonSetBackgroundImage
            // 
            resources.ApplyResources(buttonSetBackgroundImage, "buttonSetBackgroundImage");
            buttonSetBackgroundImage.Name = "buttonSetBackgroundImage";
            toolTip.SetToolTip(buttonSetBackgroundImage, resources.GetString("buttonSetBackgroundImage.ToolTip"));
            buttonSetBackgroundImage.UseVisualStyleBackColor = true;
            buttonSetBackgroundImage.Click += buttonSetBackgroundImage_Click;
            // 
            // numericBoxFootPositionY
            // 
            resources.ApplyResources(numericBoxFootPositionY, "numericBoxFootPositionY");
            numericBoxFootPositionY.BackColor = System.Drawing.SystemColors.Control;
            numericBoxFootPositionY.Name = "numericBoxFootPositionY";
            numericBoxFootPositionY.RadianValue = 26.179938779914945D;
            numericBoxFootPositionY.RoundErrorAccuracy = 8;
            numericBoxFootPositionY.SkipEventDuringInput = false;
            numericBoxFootPositionY.SmartIncrement = true;
            numericBoxFootPositionY.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxFootPositionY, resources.GetString("numericBoxFootPositionY.ToolTip"));
            numericBoxFootPositionY.Value = 1500D;
            numericBoxFootPositionY.ValueFontSize = 9F;
            numericBoxFootPositionY.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxFootPositionX
            // 
            resources.ApplyResources(numericBoxFootPositionX, "numericBoxFootPositionX");
            numericBoxFootPositionX.BackColor = System.Drawing.SystemColors.Control;
            numericBoxFootPositionX.Name = "numericBoxFootPositionX";
            numericBoxFootPositionX.RadianValue = 26.179938779914945D;
            numericBoxFootPositionX.RoundErrorAccuracy = 8;
            numericBoxFootPositionX.SkipEventDuringInput = false;
            numericBoxFootPositionX.SmartIncrement = true;
            numericBoxFootPositionX.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxFootPositionX, resources.GetString("numericBoxFootPositionX.ToolTip"));
            numericBoxFootPositionX.Value = 1500D;
            numericBoxFootPositionX.ValueFontSize = 9F;
            numericBoxFootPositionX.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxCameraLength2
            // 
            resources.ApplyResources(numericBoxCameraLength2, "numericBoxCameraLength2");
            numericBoxCameraLength2.BackColor = System.Drawing.SystemColors.Control;
            numericBoxCameraLength2.Name = "numericBoxCameraLength2";
            numericBoxCameraLength2.RadianValue = 7.7667151713747664D;
            numericBoxCameraLength2.RoundErrorAccuracy = 8;
            numericBoxCameraLength2.SkipEventDuringInput = false;
            numericBoxCameraLength2.SmartIncrement = true;
            numericBoxCameraLength2.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxCameraLength2, resources.GetString("numericBoxCameraLength2.ToolTip"));
            numericBoxCameraLength2.Value = 445D;
            numericBoxCameraLength2.ValueFontSize = 9F;
            numericBoxCameraLength2.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxDirectSpotPositionY
            // 
            resources.ApplyResources(numericBoxDirectSpotPositionY, "numericBoxDirectSpotPositionY");
            numericBoxDirectSpotPositionY.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDirectSpotPositionY.Name = "numericBoxDirectSpotPositionY";
            numericBoxDirectSpotPositionY.RadianValue = 26.179938779914945D;
            numericBoxDirectSpotPositionY.RoundErrorAccuracy = 8;
            numericBoxDirectSpotPositionY.SkipEventDuringInput = false;
            numericBoxDirectSpotPositionY.SmartIncrement = true;
            numericBoxDirectSpotPositionY.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxDirectSpotPositionY, resources.GetString("numericBoxDirectSpotPositionY.ToolTip"));
            numericBoxDirectSpotPositionY.Value = 1500D;
            numericBoxDirectSpotPositionY.ValueFontSize = 9F;
            numericBoxDirectSpotPositionY.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxDirectSpotPositionX
            // 
            resources.ApplyResources(numericBoxDirectSpotPositionX, "numericBoxDirectSpotPositionX");
            numericBoxDirectSpotPositionX.BackColor = System.Drawing.SystemColors.Control;
            numericBoxDirectSpotPositionX.Name = "numericBoxDirectSpotPositionX";
            numericBoxDirectSpotPositionX.RadianValue = 26.179938779914945D;
            numericBoxDirectSpotPositionX.RoundErrorAccuracy = 8;
            numericBoxDirectSpotPositionX.SkipEventDuringInput = false;
            numericBoxDirectSpotPositionX.SmartIncrement = true;
            numericBoxDirectSpotPositionX.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxDirectSpotPositionX, resources.GetString("numericBoxDirectSpotPositionX.ToolTip"));
            numericBoxDirectSpotPositionX.Value = 1500D;
            numericBoxDirectSpotPositionX.ValueFontSize = 9F;
            numericBoxDirectSpotPositionX.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxCameraLength1
            // 
            resources.ApplyResources(numericBoxCameraLength1, "numericBoxCameraLength1");
            numericBoxCameraLength1.BackColor = System.Drawing.SystemColors.Control;
            numericBoxCameraLength1.Name = "numericBoxCameraLength1";
            numericBoxCameraLength1.RadianValue = 7.7667151713747664D;
            numericBoxCameraLength1.RoundErrorAccuracy = 8;
            numericBoxCameraLength1.SkipEventDuringInput = false;
            numericBoxCameraLength1.SmartIncrement = true;
            numericBoxCameraLength1.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxCameraLength1, resources.GetString("numericBoxCameraLength1.ToolTip"));
            numericBoxCameraLength1.Value = 445D;
            numericBoxCameraLength1.ValueFontSize = 9F;
            numericBoxCameraLength1.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxPixelKsi
            // 
            resources.ApplyResources(numericBoxPixelKsi, "numericBoxPixelKsi");
            numericBoxPixelKsi.BackColor = System.Drawing.SystemColors.Control;
            numericBoxPixelKsi.Name = "numericBoxPixelKsi";
            numericBoxPixelKsi.RoundErrorAccuracy = 8;
            numericBoxPixelKsi.SmartIncrement = true;
            numericBoxPixelKsi.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxPixelKsi, resources.GetString("numericBoxPixelKsi.ToolTip"));
            numericBoxPixelKsi.ValueFontSize = 9F;
            numericBoxPixelKsi.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxPixelSizeY
            // 
            resources.ApplyResources(numericBoxPixelSizeY, "numericBoxPixelSizeY");
            numericBoxPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
            numericBoxPixelSizeY.Name = "numericBoxPixelSizeY";
            numericBoxPixelSizeY.RadianValue = 0.0017453292519943296D;
            numericBoxPixelSizeY.RoundErrorAccuracy = 10;
            numericBoxPixelSizeY.SmartIncrement = true;
            numericBoxPixelSizeY.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxPixelSizeY, resources.GetString("numericBoxPixelSizeY.ToolTip"));
            numericBoxPixelSizeY.Value = 0.1D;
            numericBoxPixelSizeY.ValueFontSize = 9F;
            numericBoxPixelSizeY.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxPixelSizeX
            // 
            resources.ApplyResources(numericBoxPixelSizeX, "numericBoxPixelSizeX");
            numericBoxPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
            numericBoxPixelSizeX.Name = "numericBoxPixelSizeX";
            numericBoxPixelSizeX.RadianValue = 0.0017453292519943296D;
            numericBoxPixelSizeX.RoundErrorAccuracy = 10;
            numericBoxPixelSizeX.SmartIncrement = true;
            numericBoxPixelSizeX.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxPixelSizeX, resources.GetString("numericBoxPixelSizeX.ToolTip"));
            numericBoxPixelSizeX.Value = 0.1D;
            numericBoxPixelSizeX.ValueFontSize = 9F;
            numericBoxPixelSizeX.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxGandlfiRadius
            // 
            resources.ApplyResources(numericBoxGandlfiRadius, "numericBoxGandlfiRadius");
            numericBoxGandlfiRadius.BackColor = System.Drawing.SystemColors.Control;
            numericBoxGandlfiRadius.Name = "numericBoxGandlfiRadius";
            numericBoxGandlfiRadius.RoundErrorAccuracy = 8;
            numericBoxGandlfiRadius.SmartIncrement = true;
            numericBoxGandlfiRadius.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxGandlfiRadius, resources.GetString("numericBoxGandlfiRadius.ToolTip"));
            numericBoxGandlfiRadius.ValueFontSize = 9F;
            numericBoxGandlfiRadius.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxSphericalCorections
            // 
            resources.ApplyResources(numericBoxSphericalCorections, "numericBoxSphericalCorections");
            numericBoxSphericalCorections.BackColor = System.Drawing.SystemColors.Control;
            numericBoxSphericalCorections.Name = "numericBoxSphericalCorections";
            numericBoxSphericalCorections.RoundErrorAccuracy = 8;
            numericBoxSphericalCorections.SkipEventDuringInput = false;
            numericBoxSphericalCorections.SmartIncrement = true;
            numericBoxSphericalCorections.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxSphericalCorections, resources.GetString("numericBoxSphericalCorections.ToolTip"));
            numericBoxSphericalCorections.ValueFontSize = 9F;
            numericBoxSphericalCorections.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxTiltTau
            // 
            resources.ApplyResources(numericBoxTiltTau, "numericBoxTiltTau");
            numericBoxTiltTau.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTiltTau.Name = "numericBoxTiltTau";
            numericBoxTiltTau.RoundErrorAccuracy = 9;
            numericBoxTiltTau.SkipEventDuringInput = false;
            numericBoxTiltTau.SmartIncrement = true;
            numericBoxTiltTau.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTiltTau, resources.GetString("numericBoxTiltTau.ToolTip"));
            numericBoxTiltTau.ValueFontSize = 9F;
            numericBoxTiltTau.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxTiltPhi
            // 
            resources.ApplyResources(numericBoxTiltPhi, "numericBoxTiltPhi");
            numericBoxTiltPhi.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTiltPhi.Name = "numericBoxTiltPhi";
            numericBoxTiltPhi.RoundErrorAccuracy = 8;
            numericBoxTiltPhi.SkipEventDuringInput = false;
            numericBoxTiltPhi.SmartIncrement = true;
            numericBoxTiltPhi.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTiltPhi, resources.GetString("numericBoxTiltPhi.ToolTip"));
            numericBoxTiltPhi.ValueFontSize = 9F;
            numericBoxTiltPhi.ValueChanged += DetectorParameters_Changed;
            // 
            // numericBoxRadialRange
            // 
            resources.ApplyResources(numericBoxRadialRange, "numericBoxRadialRange");
            numericBoxRadialRange.BackColor = System.Drawing.SystemColors.Control;
            numericBoxRadialRange.DecimalPlaces = 3;
            numericBoxRadialRange.Name = "numericBoxRadialRange";
            numericBoxRadialRange.RadianValue = 0.0017453292519943296D;
            numericBoxRadialRange.SkipEventDuringInput = false;
            numericBoxRadialRange.SmartIncrement = true;
            numericBoxRadialRange.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxRadialRange, resources.GetString("numericBoxRadialRange.ToolTip"));
            numericBoxRadialRange.Value = 0.1D;
            numericBoxRadialRange.ValueFontSize = 9F;
            numericBoxRadialRange.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxRadialRadius
            // 
            resources.ApplyResources(numericBoxRadialRadius, "numericBoxRadialRadius");
            numericBoxRadialRadius.BackColor = System.Drawing.SystemColors.Control;
            numericBoxRadialRadius.DecimalPlaces = 4;
            numericBoxRadialRadius.Name = "numericBoxRadialRadius";
            numericBoxRadialRadius.RadianValue = 0.3490658503988659D;
            numericBoxRadialRadius.SkipEventDuringInput = false;
            numericBoxRadialRadius.SmartIncrement = true;
            numericBoxRadialRadius.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxRadialRadius, resources.GetString("numericBoxRadialRadius.ToolTip"));
            numericBoxRadialRadius.Value = 20D;
            numericBoxRadialRadius.ValueFontSize = 9F;
            numericBoxRadialRadius.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxRadialStep
            // 
            resources.ApplyResources(numericBoxRadialStep, "numericBoxRadialStep");
            numericBoxRadialStep.BackColor = System.Drawing.SystemColors.Control;
            numericBoxRadialStep.DecimalPlaces = 3;
            numericBoxRadialStep.Name = "numericBoxRadialStep";
            numericBoxRadialStep.RadianValue = 0.0008726646259971648D;
            numericBoxRadialStep.SkipEventDuringInput = false;
            numericBoxRadialStep.SmartIncrement = true;
            numericBoxRadialStep.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxRadialStep, resources.GetString("numericBoxRadialStep.ToolTip"));
            numericBoxRadialStep.Value = 0.05D;
            numericBoxRadialStep.ValueFontSize = 9F;
            numericBoxRadialStep.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxConcentricStep
            // 
            resources.ApplyResources(numericBoxConcentricStep, "numericBoxConcentricStep");
            numericBoxConcentricStep.BackColor = System.Drawing.SystemColors.Control;
            numericBoxConcentricStep.DecimalPlaces = 4;
            numericBoxConcentricStep.Name = "numericBoxConcentricStep";
            numericBoxConcentricStep.RadianValue = 8.7266462599716482E-05D;
            numericBoxConcentricStep.ShowUpDown = true;
            numericBoxConcentricStep.SmartIncrement = true;
            numericBoxConcentricStep.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxConcentricStep, resources.GetString("numericBoxConcentricStep.ToolTip"));
            numericBoxConcentricStep.Value = 0.005D;
            numericBoxConcentricStep.ValueFontSize = 9F;
            numericBoxConcentricStep.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxConcentricEnd
            // 
            resources.ApplyResources(numericBoxConcentricEnd, "numericBoxConcentricEnd");
            numericBoxConcentricEnd.BackColor = System.Drawing.SystemColors.Control;
            numericBoxConcentricEnd.DecimalPlaces = 4;
            numericBoxConcentricEnd.Name = "numericBoxConcentricEnd";
            numericBoxConcentricEnd.RadianValue = 0.52359877559829882D;
            numericBoxConcentricEnd.ShowUpDown = true;
            numericBoxConcentricEnd.SmartIncrement = true;
            numericBoxConcentricEnd.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxConcentricEnd, resources.GetString("numericBoxConcentricEnd.ToolTip"));
            numericBoxConcentricEnd.Value = 30D;
            numericBoxConcentricEnd.ValueFontSize = 9F;
            numericBoxConcentricEnd.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxConcentricStart
            // 
            resources.ApplyResources(numericBoxConcentricStart, "numericBoxConcentricStart");
            numericBoxConcentricStart.BackColor = System.Drawing.SystemColors.Control;
            numericBoxConcentricStart.DecimalPlaces = 4;
            numericBoxConcentricStart.Name = "numericBoxConcentricStart";
            numericBoxConcentricStart.RadianValue = 0.017453292519943295D;
            numericBoxConcentricStart.ShowUpDown = true;
            numericBoxConcentricStart.SmartIncrement = true;
            numericBoxConcentricStart.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxConcentricStart, resources.GetString("numericBoxConcentricStart.ToolTip"));
            numericBoxConcentricStart.Value = 1D;
            numericBoxConcentricStart.ValueFontSize = 9F;
            numericBoxConcentricStart.ValueChanged += numericBoxIntegralProperty_ValueChanged;
            // 
            // numericBoxSplineWidth
            // 
            resources.ApplyResources(numericBoxSplineWidth, "numericBoxSplineWidth");
            numericBoxSplineWidth.BackColor = System.Drawing.Color.Transparent;
            numericBoxSplineWidth.Maximum = 50D;
            numericBoxSplineWidth.Minimum = 1D;
            numericBoxSplineWidth.Name = "numericBoxSplineWidth";
            numericBoxSplineWidth.RadianValue = 0.087266462599716474D;
            numericBoxSplineWidth.ShowUpDown = true;
            toolTip.SetToolTip(numericBoxSplineWidth, resources.GetString("numericBoxSplineWidth.ToolTip"));
            numericBoxSplineWidth.Value = 5D;
            numericBoxSplineWidth.ValueFontSize = 9F;
            numericBoxSplineWidth.ValueChanged += numericUpDownSplineWidth_ValueChanged;
            // 
            // numericBoxTest
            // 
            resources.ApplyResources(numericBoxTest, "numericBoxTest");
            numericBoxTest.BackColor = System.Drawing.SystemColors.Control;
            numericBoxTest.Maximum = 2D;
            numericBoxTest.Minimum = 0D;
            numericBoxTest.Name = "numericBoxTest";
            numericBoxTest.RadianValue = 0.0087266462599716477D;
            numericBoxTest.SkipEventDuringInput = false;
            numericBoxTest.SmartIncrement = true;
            numericBoxTest.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxTest, resources.GetString("numericBoxTest.ToolTip"));
            numericBoxTest.Value = 0.5D;
            numericBoxTest.ValueFontSize = 9F;
            // 
            // numericBoxFindCenterPeakFittingRange
            // 
            resources.ApplyResources(numericBoxFindCenterPeakFittingRange, "numericBoxFindCenterPeakFittingRange");
            numericBoxFindCenterPeakFittingRange.BackColor = System.Drawing.Color.Transparent;
            numericBoxFindCenterPeakFittingRange.DecimalPlaces = 3;
            numericBoxFindCenterPeakFittingRange.Minimum = 0D;
            numericBoxFindCenterPeakFittingRange.Name = "numericBoxFindCenterPeakFittingRange";
            numericBoxFindCenterPeakFittingRange.RadianValue = 0.0017453292519943296D;
            numericBoxFindCenterPeakFittingRange.SkipEventDuringInput = false;
            numericBoxFindCenterPeakFittingRange.SmartIncrement = true;
            numericBoxFindCenterPeakFittingRange.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxFindCenterPeakFittingRange, resources.GetString("numericBoxFindCenterPeakFittingRange.ToolTip"));
            numericBoxFindCenterPeakFittingRange.Value = 0.1D;
            numericBoxFindCenterPeakFittingRange.ValueFontSize = 9F;
            // 
            // numericBoxFindCenterSearchArea
            // 
            resources.ApplyResources(numericBoxFindCenterSearchArea, "numericBoxFindCenterSearchArea");
            numericBoxFindCenterSearchArea.BackColor = System.Drawing.Color.Transparent;
            numericBoxFindCenterSearchArea.DecimalPlaces = 0;
            numericBoxFindCenterSearchArea.Name = "numericBoxFindCenterSearchArea";
            numericBoxFindCenterSearchArea.RadianValue = 0.13962634015954636D;
            numericBoxFindCenterSearchArea.SkipEventDuringInput = false;
            numericBoxFindCenterSearchArea.SmartIncrement = true;
            numericBoxFindCenterSearchArea.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxFindCenterSearchArea, resources.GetString("numericBoxFindCenterSearchArea.ToolTip"));
            numericBoxFindCenterSearchArea.Value = 8D;
            numericBoxFindCenterSearchArea.ValueFontSize = 9F;
            // 
            // numericBoxBackgroundCoeff
            // 
            resources.ApplyResources(numericBoxBackgroundCoeff, "numericBoxBackgroundCoeff");
            numericBoxBackgroundCoeff.BackColor = System.Drawing.SystemColors.Control;
            numericBoxBackgroundCoeff.DecimalPlaces = 3;
            numericBoxBackgroundCoeff.Maximum = 10D;
            numericBoxBackgroundCoeff.Minimum = 0D;
            numericBoxBackgroundCoeff.Name = "numericBoxBackgroundCoeff";
            numericBoxBackgroundCoeff.RadianValue = 0.017453292519943295D;
            numericBoxBackgroundCoeff.SkipEventDuringInput = false;
            numericBoxBackgroundCoeff.ThousandsSeparator = true;
            toolTip.SetToolTip(numericBoxBackgroundCoeff, resources.GetString("numericBoxBackgroundCoeff.ToolTip"));
            numericBoxBackgroundCoeff.UpDown_Increment = 0.001D;
            numericBoxBackgroundCoeff.Value = 1D;
            numericBoxBackgroundCoeff.ValueFontSize = 9F;
            numericBoxBackgroundCoeff.ValueChanged += NumericBoxBackgroundCoeff_ValueChanged;
            // 
            // tabControl
            // 
            resources.ApplyResources(tabControl, "tabControl");
            tabControl.Controls.Add(tabPageXRay);
            tabControl.Controls.Add(tabPageIP);
            tabControl.Controls.Add(tabPageIntegralRegion);
            tabControl.Controls.Add(tabPageIntegralProperty);
            tabControl.Controls.Add(tabPageSpotsAndCenter);
            tabControl.Controls.Add(tabPageAfterGetProfile);
            tabControl.Controls.Add(tabPage1);
            tabControl.Controls.Add(tabPage5);
            tabControl.Controls.Add(tabPage3);
            tabControl.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            tabControl.HotTrack = true;
            tabControl.Multiline = true;
            tabControl.Name = "tabControl";
            tabControl.SelectedIndex = 0;
            tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            toolTip.SetToolTip(tabControl, resources.GetString("tabControl.ToolTip"));
            tabControl.DrawItem += tabControl1_DrawItem;
            // 
            // tabPageXRay
            // 
            resources.ApplyResources(tabPageXRay, "tabPageXRay");
            tabPageXRay.BackColor = System.Drawing.SystemColors.Control;
            tabPageXRay.Controls.Add(label15);
            tabPageXRay.Controls.Add(label6);
            tabPageXRay.Controls.Add(checkBoxCorrectPolarization);
            tabPageXRay.Controls.Add(waveLengthControl);
            tabPageXRay.Name = "tabPageXRay";
            toolTip.SetToolTip(tabPageXRay, resources.GetString("tabPageXRay.ToolTip"));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            toolTip.SetToolTip(label15, resources.GetString("label15.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            toolTip.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // waveLengthControl
            // 
            resources.ApplyResources(waveLengthControl, "waveLengthControl");
            waveLengthControl.DirectionWaveSource = System.Windows.Forms.FlowDirection.TopDown;
            waveLengthControl.DirectionWhole = System.Windows.Forms.FlowDirection.LeftToRight;
            waveLengthControl.Energy = 17.44419672D;
            waveLengthControl.Name = "waveLengthControl";
            toolTip.SetToolTip(waveLengthControl, resources.GetString("waveLengthControl.ToolTip"));
            waveLengthControl.WaveLength = 0.07107471D;
            waveLengthControl.XrayWaveSourceElementNumber = 42;
            waveLengthControl.XrayWaveSourceLine = Crystallography.XrayLine.Ka;
            // 
            // tabPageIP
            // 
            resources.ApplyResources(tabPageIP, "tabPageIP");
            tabPageIP.BackColor = System.Drawing.SystemColors.Control;
            tabPageIP.Controls.Add(flowLayoutPanel8);
            tabPageIP.Controls.Add(flowLayoutPanel7);
            tabPageIP.Controls.Add(flowLayoutPanelFootMode);
            tabPageIP.Controls.Add(flowLayoutPanelDirectSpotMode);
            tabPageIP.Controls.Add(groupBoxPixelShape);
            tabPageIP.Controls.Add(groupBoxGandlfiRadius);
            tabPageIP.Controls.Add(groupBoxSphericalCorrection);
            tabPageIP.Controls.Add(groupBoxTiltCorrection);
            tabPageIP.Name = "tabPageIP";
            toolTip.SetToolTip(tabPageIP, resources.GetString("tabPageIP.ToolTip"));
            // 
            // flowLayoutPanel8
            // 
            resources.ApplyResources(flowLayoutPanel8, "flowLayoutPanel8");
            flowLayoutPanel8.Controls.Add(label22);
            flowLayoutPanel8.Controls.Add(radioButtonDirectSpotMode);
            flowLayoutPanel8.Controls.Add(radioButtonFootMode);
            flowLayoutPanel8.Name = "flowLayoutPanel8";
            toolTip.SetToolTip(flowLayoutPanel8, resources.GetString("flowLayoutPanel8.ToolTip"));
            // 
            // label22
            // 
            resources.ApplyResources(label22, "label22");
            label22.Name = "label22";
            toolTip.SetToolTip(label22, resources.GetString("label22.ToolTip"));
            // 
            // flowLayoutPanel7
            // 
            resources.ApplyResources(flowLayoutPanel7, "flowLayoutPanel7");
            flowLayoutPanel7.Controls.Add(label19);
            flowLayoutPanel7.Controls.Add(radioButtonFlatPanel);
            flowLayoutPanel7.Controls.Add(radioButtonGandlfi);
            flowLayoutPanel7.Name = "flowLayoutPanel7";
            toolTip.SetToolTip(flowLayoutPanel7, resources.GetString("flowLayoutPanel7.ToolTip"));
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            toolTip.SetToolTip(label19, resources.GetString("label19.ToolTip"));
            // 
            // flowLayoutPanelFootMode
            // 
            resources.ApplyResources(flowLayoutPanelFootMode, "flowLayoutPanelFootMode");
            flowLayoutPanelFootMode.Controls.Add(groupBox9);
            flowLayoutPanelFootMode.Controls.Add(groupBox10);
            flowLayoutPanelFootMode.Name = "flowLayoutPanelFootMode";
            toolTip.SetToolTip(flowLayoutPanelFootMode, resources.GetString("flowLayoutPanelFootMode.ToolTip"));
            // 
            // groupBox9
            // 
            resources.ApplyResources(groupBox9, "groupBox9");
            groupBox9.Controls.Add(numericBoxFootPositionY);
            groupBox9.Controls.Add(numericBoxFootPositionX);
            groupBox9.Name = "groupBox9";
            groupBox9.TabStop = false;
            toolTip.SetToolTip(groupBox9, resources.GetString("groupBox9.ToolTip"));
            // 
            // groupBox10
            // 
            resources.ApplyResources(groupBox10, "groupBox10");
            groupBox10.Controls.Add(label17);
            groupBox10.Controls.Add(numericBoxCameraLength2);
            groupBox10.Name = "groupBox10";
            groupBox10.TabStop = false;
            toolTip.SetToolTip(groupBox10, resources.GetString("groupBox10.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            toolTip.SetToolTip(label17, resources.GetString("label17.ToolTip"));
            // 
            // flowLayoutPanelDirectSpotMode
            // 
            resources.ApplyResources(flowLayoutPanelDirectSpotMode, "flowLayoutPanelDirectSpotMode");
            flowLayoutPanelDirectSpotMode.Controls.Add(groupBoxDirectSpotPosition);
            flowLayoutPanelDirectSpotMode.Controls.Add(groupBoxCameaLength);
            flowLayoutPanelDirectSpotMode.Name = "flowLayoutPanelDirectSpotMode";
            toolTip.SetToolTip(flowLayoutPanelDirectSpotMode, resources.GetString("flowLayoutPanelDirectSpotMode.ToolTip"));
            // 
            // groupBoxDirectSpotPosition
            // 
            resources.ApplyResources(groupBoxDirectSpotPosition, "groupBoxDirectSpotPosition");
            groupBoxDirectSpotPosition.Controls.Add(numericBoxDirectSpotPositionY);
            groupBoxDirectSpotPosition.Controls.Add(numericBoxDirectSpotPositionX);
            groupBoxDirectSpotPosition.Name = "groupBoxDirectSpotPosition";
            groupBoxDirectSpotPosition.TabStop = false;
            toolTip.SetToolTip(groupBoxDirectSpotPosition, resources.GetString("groupBoxDirectSpotPosition.ToolTip"));
            // 
            // groupBoxCameaLength
            // 
            resources.ApplyResources(groupBoxCameaLength, "groupBoxCameaLength");
            groupBoxCameaLength.Controls.Add(label18);
            groupBoxCameaLength.Controls.Add(numericBoxCameraLength1);
            groupBoxCameaLength.Name = "groupBoxCameaLength";
            groupBoxCameaLength.TabStop = false;
            toolTip.SetToolTip(groupBoxCameaLength, resources.GetString("groupBoxCameaLength.ToolTip"));
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            toolTip.SetToolTip(label18, resources.GetString("label18.ToolTip"));
            // 
            // groupBoxPixelShape
            // 
            resources.ApplyResources(groupBoxPixelShape, "groupBoxPixelShape");
            groupBoxPixelShape.Controls.Add(numericBoxPixelKsi);
            groupBoxPixelShape.Controls.Add(numericBoxPixelSizeY);
            groupBoxPixelShape.Controls.Add(numericBoxPixelSizeX);
            groupBoxPixelShape.Name = "groupBoxPixelShape";
            groupBoxPixelShape.TabStop = false;
            toolTip.SetToolTip(groupBoxPixelShape, resources.GetString("groupBoxPixelShape.ToolTip"));
            // 
            // groupBoxGandlfiRadius
            // 
            resources.ApplyResources(groupBoxGandlfiRadius, "groupBoxGandlfiRadius");
            groupBoxGandlfiRadius.Controls.Add(numericBoxGandlfiRadius);
            groupBoxGandlfiRadius.Name = "groupBoxGandlfiRadius";
            groupBoxGandlfiRadius.TabStop = false;
            toolTip.SetToolTip(groupBoxGandlfiRadius, resources.GetString("groupBoxGandlfiRadius.ToolTip"));
            groupBoxGandlfiRadius.Enter += groupBoxGandlfiRadius_Enter;
            // 
            // groupBoxSphericalCorrection
            // 
            resources.ApplyResources(groupBoxSphericalCorrection, "groupBoxSphericalCorrection");
            groupBoxSphericalCorrection.Controls.Add(numericBoxSphericalCorections);
            groupBoxSphericalCorrection.Controls.Add(label26);
            groupBoxSphericalCorrection.Name = "groupBoxSphericalCorrection";
            groupBoxSphericalCorrection.TabStop = false;
            toolTip.SetToolTip(groupBoxSphericalCorrection, resources.GetString("groupBoxSphericalCorrection.ToolTip"));
            // 
            // label26
            // 
            resources.ApplyResources(label26, "label26");
            label26.BackColor = System.Drawing.Color.Transparent;
            label26.Name = "label26";
            toolTip.SetToolTip(label26, resources.GetString("label26.ToolTip"));
            // 
            // groupBoxTiltCorrection
            // 
            resources.ApplyResources(groupBoxTiltCorrection, "groupBoxTiltCorrection");
            groupBoxTiltCorrection.Controls.Add(numericBoxTiltTau);
            groupBoxTiltCorrection.Controls.Add(numericBoxTiltPhi);
            groupBoxTiltCorrection.Name = "groupBoxTiltCorrection";
            groupBoxTiltCorrection.TabStop = false;
            toolTip.SetToolTip(groupBoxTiltCorrection, resources.GetString("groupBoxTiltCorrection.ToolTip"));
            // 
            // tabPageIntegralRegion
            // 
            resources.ApplyResources(tabPageIntegralRegion, "tabPageIntegralRegion");
            tabPageIntegralRegion.BackColor = System.Drawing.SystemColors.Control;
            tabPageIntegralRegion.Controls.Add(groupBox8);
            tabPageIntegralRegion.Controls.Add(radioButtonRectangle);
            tabPageIntegralRegion.Controls.Add(groupBoxRectangle);
            tabPageIntegralRegion.Controls.Add(radioButtonSector);
            tabPageIntegralRegion.Controls.Add(groupBoxSector);
            tabPageIntegralRegion.Name = "tabPageIntegralRegion";
            toolTip.SetToolTip(tabPageIntegralRegion, resources.GetString("tabPageIntegralRegion.ToolTip"));
            // 
            // groupBox8
            // 
            resources.ApplyResources(groupBox8, "groupBox8");
            groupBox8.Controls.Add(numericUpDownThresholdOfIntensityMax);
            groupBox8.Controls.Add(label2);
            groupBox8.Controls.Add(numericUpDownThresholdOfIntensityMin);
            groupBox8.Controls.Add(numericUpDownEdge);
            groupBox8.Controls.Add(checkBoxOmitSpots);
            groupBox8.Controls.Add(checkBoxMaskEdge);
            groupBox8.Controls.Add(checkBoxThresholdMax);
            groupBox8.Controls.Add(checkBoxThresholdMin);
            groupBox8.Name = "groupBox8";
            groupBox8.TabStop = false;
            toolTip.SetToolTip(groupBox8, resources.GetString("groupBox8.ToolTip"));
            // 
            // label2
            // 
            resources.ApplyResources(label2, "label2");
            label2.Name = "label2";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip"));
            // 
            // groupBoxRectangle
            // 
            resources.ApplyResources(groupBoxRectangle, "groupBoxRectangle");
            groupBoxRectangle.Controls.Add(checkBoxRectangleIsBothSide);
            groupBoxRectangle.Controls.Add(comboBoxRectangleDirection);
            groupBoxRectangle.Controls.Add(label8);
            groupBoxRectangle.Controls.Add(label7);
            groupBoxRectangle.Controls.Add(numericUpDownRectangleBand);
            groupBoxRectangle.Controls.Add(numericUpDownRectangleAngle);
            groupBoxRectangle.Controls.Add(label9);
            groupBoxRectangle.Name = "groupBoxRectangle";
            groupBoxRectangle.TabStop = false;
            toolTip.SetToolTip(groupBoxRectangle, resources.GetString("groupBoxRectangle.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            toolTip.SetToolTip(label8, resources.GetString("label8.ToolTip"));
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            toolTip.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            toolTip.SetToolTip(label9, resources.GetString("label9.ToolTip"));
            // 
            // groupBoxSector
            // 
            resources.ApplyResources(groupBoxSector, "groupBoxSector");
            groupBoxSector.Controls.Add(numericUpDownSectorStartAngle);
            groupBoxSector.Controls.Add(numericUpDownSectorEndAngle);
            groupBoxSector.Controls.Add(label10);
            groupBoxSector.Controls.Add(label11);
            groupBoxSector.Name = "groupBoxSector";
            groupBoxSector.TabStop = false;
            toolTip.SetToolTip(groupBoxSector, resources.GetString("groupBoxSector.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            toolTip.SetToolTip(label10, resources.GetString("label10.ToolTip"));
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            toolTip.SetToolTip(label11, resources.GetString("label11.ToolTip"));
            // 
            // tabPageIntegralProperty
            // 
            resources.ApplyResources(tabPageIntegralProperty, "tabPageIntegralProperty");
            tabPageIntegralProperty.BackColor = System.Drawing.SystemColors.Control;
            tabPageIntegralProperty.Controls.Add(radioButtonRadial);
            tabPageIntegralProperty.Controls.Add(groupBoxRadial);
            tabPageIntegralProperty.Controls.Add(radioButtonConcentric);
            tabPageIntegralProperty.Controls.Add(groupBoxConcentric);
            tabPageIntegralProperty.Name = "tabPageIntegralProperty";
            toolTip.SetToolTip(tabPageIntegralProperty, resources.GetString("tabPageIntegralProperty.ToolTip"));
            // 
            // groupBoxRadial
            // 
            resources.ApplyResources(groupBoxRadial, "groupBoxRadial");
            groupBoxRadial.Controls.Add(label46);
            groupBoxRadial.Controls.Add(label40);
            groupBoxRadial.Controls.Add(numericBoxRadialRange);
            groupBoxRadial.Controls.Add(numericBoxRadialRadius);
            groupBoxRadial.Controls.Add(numericBoxRadialStep);
            groupBoxRadial.Controls.Add(radioButtonRadialAngle);
            groupBoxRadial.Controls.Add(radioButtonRadialDspacing);
            groupBoxRadial.Controls.Add(labelDimensionRadial2);
            groupBoxRadial.Controls.Add(label37);
            groupBoxRadial.Controls.Add(label36);
            groupBoxRadial.Controls.Add(labelDimensionRadial1);
            groupBoxRadial.Name = "groupBoxRadial";
            groupBoxRadial.TabStop = false;
            toolTip.SetToolTip(groupBoxRadial, resources.GetString("groupBoxRadial.ToolTip"));
            // 
            // label46
            // 
            resources.ApplyResources(label46, "label46");
            label46.Name = "label46";
            toolTip.SetToolTip(label46, resources.GetString("label46.ToolTip"));
            // 
            // label40
            // 
            resources.ApplyResources(label40, "label40");
            label40.Name = "label40";
            toolTip.SetToolTip(label40, resources.GetString("label40.ToolTip"));
            // 
            // labelDimensionRadial2
            // 
            resources.ApplyResources(labelDimensionRadial2, "labelDimensionRadial2");
            labelDimensionRadial2.Name = "labelDimensionRadial2";
            toolTip.SetToolTip(labelDimensionRadial2, resources.GetString("labelDimensionRadial2.ToolTip"));
            // 
            // label37
            // 
            resources.ApplyResources(label37, "label37");
            label37.Name = "label37";
            toolTip.SetToolTip(label37, resources.GetString("label37.ToolTip"));
            // 
            // label36
            // 
            resources.ApplyResources(label36, "label36");
            label36.Name = "label36";
            toolTip.SetToolTip(label36, resources.GetString("label36.ToolTip"));
            // 
            // labelDimensionRadial1
            // 
            resources.ApplyResources(labelDimensionRadial1, "labelDimensionRadial1");
            labelDimensionRadial1.Name = "labelDimensionRadial1";
            toolTip.SetToolTip(labelDimensionRadial1, resources.GetString("labelDimensionRadial1.ToolTip"));
            // 
            // groupBoxConcentric
            // 
            resources.ApplyResources(groupBoxConcentric, "groupBoxConcentric");
            groupBoxConcentric.Controls.Add(groupBox4);
            groupBoxConcentric.Controls.Add(groupBox5);
            groupBoxConcentric.Name = "groupBoxConcentric";
            groupBoxConcentric.TabStop = false;
            toolTip.SetToolTip(groupBoxConcentric, resources.GetString("groupBoxConcentric.ToolTip"));
            // 
            // groupBox4
            // 
            resources.ApplyResources(groupBox4, "groupBox4");
            groupBox4.Controls.Add(numericBoxConcentricStep);
            groupBox4.Controls.Add(radioButtonConcentricLength);
            groupBox4.Controls.Add(numericBoxConcentricEnd);
            groupBox4.Controls.Add(radioButtonConcentricDspacing);
            groupBox4.Controls.Add(numericBoxConcentricStart);
            groupBox4.Controls.Add(radioButtonConcentricAngle);
            groupBox4.Controls.Add(label13);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label12);
            groupBox4.Name = "groupBox4";
            groupBox4.TabStop = false;
            toolTip.SetToolTip(groupBox4, resources.GetString("groupBox4.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            toolTip.SetToolTip(label13, resources.GetString("label13.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            toolTip.SetToolTip(label14, resources.GetString("label14.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            toolTip.SetToolTip(label12, resources.GetString("label12.ToolTip"));
            // 
            // groupBox5
            // 
            resources.ApplyResources(groupBox5, "groupBox5");
            groupBox5.Controls.Add(radioButtonBraggBrentano);
            groupBox5.Controls.Add(radioButtonDebyeScherrer);
            groupBox5.Name = "groupBox5";
            groupBox5.TabStop = false;
            toolTip.SetToolTip(groupBox5, resources.GetString("groupBox5.ToolTip"));
            // 
            // tabPageSpotsAndCenter
            // 
            resources.ApplyResources(tabPageSpotsAndCenter, "tabPageSpotsAndCenter");
            tabPageSpotsAndCenter.Controls.Add(groupBox13);
            tabPageSpotsAndCenter.Controls.Add(checkBoxManualMaskMode);
            tabPageSpotsAndCenter.Controls.Add(groupBoxManualMode);
            tabPageSpotsAndCenter.Controls.Add(groupBox7);
            tabPageSpotsAndCenter.Controls.Add(groupBox12);
            tabPageSpotsAndCenter.Controls.Add(buttonMaskAll);
            tabPageSpotsAndCenter.Controls.Add(buttonInvertMask);
            tabPageSpotsAndCenter.Controls.Add(buttonUnmaskAll);
            tabPageSpotsAndCenter.Name = "tabPageSpotsAndCenter";
            toolTip.SetToolTip(tabPageSpotsAndCenter, resources.GetString("tabPageSpotsAndCenter.ToolTip"));
            tabPageSpotsAndCenter.UseVisualStyleBackColor = true;
            // 
            // groupBox13
            // 
            resources.ApplyResources(groupBox13, "groupBox13");
            groupBox13.Controls.Add(buttonMaskLeft);
            groupBox13.Controls.Add(buttonMaskTop);
            groupBox13.Controls.Add(buttonMaskBottom);
            groupBox13.Controls.Add(buttonMaskRight);
            groupBox13.Name = "groupBox13";
            groupBox13.TabStop = false;
            toolTip.SetToolTip(groupBox13, resources.GetString("groupBox13.ToolTip"));
            // 
            // groupBoxManualMode
            // 
            resources.ApplyResources(groupBoxManualMode, "groupBoxManualMode");
            groupBoxManualMode.Controls.Add(radioButtonManualCircle);
            groupBoxManualMode.Controls.Add(radioButtonManualSpline);
            groupBoxManualMode.Controls.Add(radioButtonManualPolygon);
            groupBoxManualMode.Controls.Add(radioButtonManualRectangle);
            groupBoxManualMode.Controls.Add(radioButtonManualSpot);
            groupBoxManualMode.Controls.Add(groupBoxManualSpot);
            groupBoxManualMode.Controls.Add(groupBoxSpline);
            groupBoxManualMode.Name = "groupBoxManualMode";
            groupBoxManualMode.TabStop = false;
            toolTip.SetToolTip(groupBoxManualMode, resources.GetString("groupBoxManualMode.ToolTip"));
            groupBoxManualMode.Enter += groupBoxManualMode_Enter;
            // 
            // groupBoxManualSpot
            // 
            resources.ApplyResources(groupBoxManualSpot, "groupBoxManualSpot");
            groupBoxManualSpot.Controls.Add(textBoxManualSpotSize);
            groupBoxManualSpot.Controls.Add(label31);
            groupBoxManualSpot.Controls.Add(radioButton1);
            groupBoxManualSpot.Controls.Add(numericUpDownManualSpotSize);
            groupBoxManualSpot.Controls.Add(label30);
            groupBoxManualSpot.Controls.Add(radioButtonCircle);
            groupBoxManualSpot.Name = "groupBoxManualSpot";
            groupBoxManualSpot.TabStop = false;
            toolTip.SetToolTip(groupBoxManualSpot, resources.GetString("groupBoxManualSpot.ToolTip"));
            // 
            // label31
            // 
            resources.ApplyResources(label31, "label31");
            label31.Name = "label31";
            toolTip.SetToolTip(label31, resources.GetString("label31.ToolTip"));
            // 
            // label30
            // 
            resources.ApplyResources(label30, "label30");
            label30.Name = "label30";
            toolTip.SetToolTip(label30, resources.GetString("label30.ToolTip"));
            // 
            // groupBoxSpline
            // 
            resources.ApplyResources(groupBoxSpline, "groupBoxSpline");
            groupBoxSpline.Controls.Add(label29);
            groupBoxSpline.Controls.Add(numericBoxSplineWidth);
            groupBoxSpline.Controls.Add(label27);
            groupBoxSpline.Name = "groupBoxSpline";
            groupBoxSpline.TabStop = false;
            toolTip.SetToolTip(groupBoxSpline, resources.GetString("groupBoxSpline.ToolTip"));
            // 
            // label29
            // 
            resources.ApplyResources(label29, "label29");
            label29.Name = "label29";
            toolTip.SetToolTip(label29, resources.GetString("label29.ToolTip"));
            // 
            // label27
            // 
            resources.ApplyResources(label27, "label27");
            label27.Name = "label27";
            toolTip.SetToolTip(label27, resources.GetString("label27.ToolTip"));
            // 
            // groupBox7
            // 
            resources.ApplyResources(groupBox7, "groupBox7");
            groupBox7.Controls.Add(flowLayoutPanel5);
            groupBox7.Name = "groupBox7";
            groupBox7.TabStop = false;
            toolTip.SetToolTip(groupBox7, resources.GetString("groupBox7.ToolTip"));
            // 
            // flowLayoutPanel5
            // 
            resources.ApplyResources(flowLayoutPanel5, "flowLayoutPanel5");
            flowLayoutPanel5.Controls.Add(radioButtonTakeoverNothing);
            flowLayoutPanel5.Controls.Add(radioButtonTakeoverMask);
            flowLayoutPanel5.Controls.Add(radioButtonTakeOverMaskfile);
            flowLayoutPanel5.Name = "flowLayoutPanel5";
            toolTip.SetToolTip(flowLayoutPanel5, resources.GetString("flowLayoutPanel5.ToolTip"));
            // 
            // groupBox12
            // 
            resources.ApplyResources(groupBox12, "groupBox12");
            groupBox12.Controls.Add(numericUpDownFindSpotsDeviation);
            groupBox12.Controls.Add(label28);
            groupBox12.Name = "groupBox12";
            groupBox12.TabStop = false;
            toolTip.SetToolTip(groupBox12, resources.GetString("groupBox12.ToolTip"));
            // 
            // label28
            // 
            resources.ApplyResources(label28, "label28");
            label28.Name = "label28";
            toolTip.SetToolTip(label28, resources.GetString("label28.ToolTip"));
            // 
            // tabPageAfterGetProfile
            // 
            resources.ApplyResources(tabPageAfterGetProfile, "tabPageAfterGetProfile");
            tabPageAfterGetProfile.Controls.Add(numericBoxTest);
            tabPageAfterGetProfile.Controls.Add(checkBoxTest);
            tabPageAfterGetProfile.Controls.Add(checkBoxSendProfileToPDIndexer);
            tabPageAfterGetProfile.Controls.Add(checkBoxSaveFile);
            tabPageAfterGetProfile.Controls.Add(groupBoxSaveProfile);
            tabPageAfterGetProfile.Controls.Add(groupBoxSendPDI);
            tabPageAfterGetProfile.Name = "tabPageAfterGetProfile";
            toolTip.SetToolTip(tabPageAfterGetProfile, resources.GetString("tabPageAfterGetProfile.ToolTip"));
            tabPageAfterGetProfile.UseVisualStyleBackColor = true;
            // 
            // groupBoxSaveProfile
            // 
            resources.ApplyResources(groupBoxSaveProfile, "groupBoxSaveProfile");
            groupBoxSaveProfile.Controls.Add(groupBox17);
            groupBoxSaveProfile.Controls.Add(groupBox16);
            groupBoxSaveProfile.Controls.Add(groupBox15);
            groupBoxSaveProfile.Name = "groupBoxSaveProfile";
            groupBoxSaveProfile.TabStop = false;
            toolTip.SetToolTip(groupBoxSaveProfile, resources.GetString("groupBoxSaveProfile.ToolTip"));
            groupBoxSaveProfile.Enter += groupBoxSaveProfile_Enter;
            // 
            // groupBox17
            // 
            resources.ApplyResources(groupBox17, "groupBox17");
            groupBox17.Controls.Add(flowLayoutPanel4);
            groupBox17.Name = "groupBox17";
            groupBox17.TabStop = false;
            toolTip.SetToolTip(groupBox17, resources.GetString("groupBox17.ToolTip"));
            // 
            // flowLayoutPanel4
            // 
            resources.ApplyResources(flowLayoutPanel4, "flowLayoutPanel4");
            flowLayoutPanel4.Controls.Add(radioButtonSaveInOneFile);
            flowLayoutPanel4.Controls.Add(radioButtonSaveInSeparateFiles);
            flowLayoutPanel4.Name = "flowLayoutPanel4";
            toolTip.SetToolTip(flowLayoutPanel4, resources.GetString("flowLayoutPanel4.ToolTip"));
            // 
            // groupBox16
            // 
            resources.ApplyResources(groupBox16, "groupBox16");
            groupBox16.Controls.Add(flowLayoutPanel1);
            groupBox16.Name = "groupBox16";
            groupBox16.TabStop = false;
            toolTip.SetToolTip(groupBox16, resources.GetString("groupBox16.ToolTip"));
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Controls.Add(radioButtonSetDirectoryEachTime);
            flowLayoutPanel1.Controls.Add(radioButtonSaveAtImageDirectory);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            toolTip.SetToolTip(flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // groupBox15
            // 
            resources.ApplyResources(groupBox15, "groupBox15");
            groupBox15.Controls.Add(flowLayoutPanel2);
            groupBox15.Name = "groupBox15";
            groupBox15.TabStop = false;
            toolTip.SetToolTip(groupBox15, resources.GetString("groupBox15.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(radioButtonAsPDIformat);
            flowLayoutPanel2.Controls.Add(radioButtonAsCSVformat);
            flowLayoutPanel2.Controls.Add(radioButtonAsTSVformat);
            flowLayoutPanel2.Controls.Add(radioButtonAsGSASformat);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            toolTip.SetToolTip(flowLayoutPanel2, resources.GetString("flowLayoutPanel2.ToolTip"));
            // 
            // groupBoxSendPDI
            // 
            resources.ApplyResources(groupBoxSendPDI, "groupBoxSendPDI");
            groupBoxSendPDI.Controls.Add(checkBoxSendUnrolledImageToPDIndexer);
            groupBoxSendPDI.Name = "groupBoxSendPDI";
            groupBoxSendPDI.TabStop = false;
            toolTip.SetToolTip(groupBoxSendPDI, resources.GetString("groupBoxSendPDI.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(groupBox1);
            tabPage1.Name = "tabPage1";
            toolTip.SetToolTip(tabPage1, resources.GetString("tabPage1.ToolTip"));
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            resources.ApplyResources(groupBox3, "groupBox3");
            groupBox3.Controls.Add(numericUpDownUnrollChiDivision);
            groupBox3.Name = "groupBox3";
            groupBox3.TabStop = false;
            toolTip.SetToolTip(groupBox3, resources.GetString("groupBox3.ToolTip"));
            // 
            // groupBox1
            // 
            resources.ApplyResources(groupBox1, "groupBox1");
            groupBox1.Controls.Add(numericUpDownUnrolledImageXend);
            groupBox1.Controls.Add(numericUpDownUnrolledImageXstart);
            groupBox1.Controls.Add(label38);
            groupBox1.Controls.Add(label39);
            groupBox1.Controls.Add(label25);
            groupBox1.Controls.Add(label41);
            groupBox1.Controls.Add(numericUpDownUnrolledImageXstep);
            groupBox1.Controls.Add(label24);
            groupBox1.Controls.Add(label42);
            groupBox1.Controls.Add(radioButton2);
            groupBox1.Controls.Add(radioButton4);
            groupBox1.Controls.Add(radioButton3);
            groupBox1.Name = "groupBox1";
            groupBox1.TabStop = false;
            toolTip.SetToolTip(groupBox1, resources.GetString("groupBox1.ToolTip"));
            // 
            // label38
            // 
            resources.ApplyResources(label38, "label38");
            label38.Name = "label38";
            toolTip.SetToolTip(label38, resources.GetString("label38.ToolTip"));
            // 
            // label39
            // 
            resources.ApplyResources(label39, "label39");
            label39.Name = "label39";
            toolTip.SetToolTip(label39, resources.GetString("label39.ToolTip"));
            // 
            // label25
            // 
            resources.ApplyResources(label25, "label25");
            label25.Name = "label25";
            toolTip.SetToolTip(label25, resources.GetString("label25.ToolTip"));
            // 
            // label41
            // 
            resources.ApplyResources(label41, "label41");
            label41.Name = "label41";
            toolTip.SetToolTip(label41, resources.GetString("label41.ToolTip"));
            // 
            // label24
            // 
            resources.ApplyResources(label24, "label24");
            label24.Name = "label24";
            toolTip.SetToolTip(label24, resources.GetString("label24.ToolTip"));
            // 
            // label42
            // 
            resources.ApplyResources(label42, "label42");
            label42.Name = "label42";
            toolTip.SetToolTip(label42, resources.GetString("label42.ToolTip"));
            // 
            // tabPage5
            // 
            resources.ApplyResources(tabPage5, "tabPage5");
            tabPage5.Controls.Add(groupBox14);
            tabPage5.Controls.Add(groupBox19);
            tabPage5.Controls.Add(groupBox18);
            tabPage5.Controls.Add(groupBox11);
            tabPage5.Controls.Add(groupBox2);
            tabPage5.Name = "tabPage5";
            toolTip.SetToolTip(tabPage5, resources.GetString("tabPage5.ToolTip"));
            tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox14
            // 
            resources.ApplyResources(groupBox14, "groupBox14");
            groupBox14.Controls.Add(comboBoxScaleLineDivisions);
            groupBox14.Controls.Add(checkBoxScaleLabel);
            groupBox14.Controls.Add(trackBarScaleLineWidth);
            groupBox14.Controls.Add(label5);
            groupBox14.Controls.Add(label23);
            groupBox14.Controls.Add(colorControlScaleAzimuth);
            groupBox14.Controls.Add(colorControlScale2Theta);
            groupBox14.Name = "groupBox14";
            groupBox14.TabStop = false;
            toolTip.SetToolTip(groupBox14, resources.GetString("groupBox14.ToolTip"));
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            toolTip.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // label23
            // 
            resources.ApplyResources(label23, "label23");
            label23.Name = "label23";
            toolTip.SetToolTip(label23, resources.GetString("label23.ToolTip"));
            // 
            // colorControlScaleAzimuth
            // 
            resources.ApplyResources(colorControlScaleAzimuth, "colorControlScaleAzimuth");
            colorControlScaleAzimuth.BackColor = System.Drawing.SystemColors.Control;
            colorControlScaleAzimuth.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScaleAzimuth.Color = System.Drawing.Color.FromArgb(119, 68, 70);
            colorControlScaleAzimuth.Name = "colorControlScaleAzimuth";
            toolTip.SetToolTip(colorControlScaleAzimuth, resources.GetString("colorControlScaleAzimuth.ToolTip1"));
            colorControlScaleAzimuth.Load += colorControlScale2Theta_Load;
            // 
            // colorControlScale2Theta
            // 
            resources.ApplyResources(colorControlScale2Theta, "colorControlScale2Theta");
            colorControlScale2Theta.BackColor = System.Drawing.SystemColors.Control;
            colorControlScale2Theta.BoxSize = new System.Drawing.Size(20, 20);
            colorControlScale2Theta.Color = System.Drawing.Color.FromArgb(68, 68, 120);
            colorControlScale2Theta.Name = "colorControlScale2Theta";
            toolTip.SetToolTip(colorControlScale2Theta, resources.GetString("colorControlScale2Theta.ToolTip1"));
            colorControlScale2Theta.Load += colorControlScale2Theta_Load;
            // 
            // groupBox19
            // 
            resources.ApplyResources(groupBox19, "groupBox19");
            groupBox19.Controls.Add(radioButtonImageName_FullPath);
            groupBox19.Controls.Add(radioButtonImageName_LastFolderPlusFilename);
            groupBox19.Controls.Add(radioButtonImageName_FileName);
            groupBox19.Name = "groupBox19";
            groupBox19.TabStop = false;
            toolTip.SetToolTip(groupBox19, resources.GetString("groupBox19.ToolTip"));
            // 
            // groupBox18
            // 
            resources.ApplyResources(groupBox18, "groupBox18");
            groupBox18.Controls.Add(checkBoxMaintainImageContrast);
            groupBox18.Controls.Add(checkBoxMaintainImageRange);
            groupBox18.Name = "groupBox18";
            groupBox18.TabStop = false;
            toolTip.SetToolTip(groupBox18, resources.GetString("groupBox18.ToolTip"));
            // 
            // groupBox11
            // 
            resources.ApplyResources(groupBox11, "groupBox11");
            groupBox11.Controls.Add(label50);
            groupBox11.Controls.Add(flowLayoutPanel3);
            groupBox11.Controls.Add(pictureBox1);
            groupBox11.Controls.Add(radioButtonChiLeft);
            groupBox11.Controls.Add(radioButtonChiRight);
            groupBox11.Controls.Add(radioButtonChiBottom);
            groupBox11.Controls.Add(radioButtonChiTop);
            groupBox11.Name = "groupBox11";
            groupBox11.TabStop = false;
            toolTip.SetToolTip(groupBox11, resources.GetString("groupBox11.ToolTip"));
            // 
            // label50
            // 
            resources.ApplyResources(label50, "label50");
            label50.Name = "label50";
            toolTip.SetToolTip(label50, resources.GetString("label50.ToolTip"));
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(radioButtonChiClockwise);
            flowLayoutPanel3.Controls.Add(radioButtonChiCounterclockwise);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            toolTip.SetToolTip(flowLayoutPanel3, resources.GetString("flowLayoutPanel3.ToolTip"));
            // 
            // groupBox2
            // 
            resources.ApplyResources(groupBox2, "groupBox2");
            groupBox2.Controls.Add(checkBoxFixCenter);
            groupBox2.Controls.Add(numericBoxFindCenterPeakFittingRange);
            groupBox2.Controls.Add(flowLayoutPanelFindCenterOption);
            groupBox2.Name = "groupBox2";
            groupBox2.TabStop = false;
            toolTip.SetToolTip(groupBox2, resources.GetString("groupBox2.ToolTip"));
            // 
            // flowLayoutPanelFindCenterOption
            // 
            resources.ApplyResources(flowLayoutPanelFindCenterOption, "flowLayoutPanelFindCenterOption");
            flowLayoutPanelFindCenterOption.Controls.Add(numericBoxFindCenterSearchArea);
            flowLayoutPanelFindCenterOption.Controls.Add(checkBoxExcludeMaskedPixels);
            flowLayoutPanelFindCenterOption.Name = "flowLayoutPanelFindCenterOption";
            toolTip.SetToolTip(flowLayoutPanelFindCenterOption, resources.GetString("flowLayoutPanelFindCenterOption.ToolTip"));
            // 
            // tabPage3
            // 
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Controls.Add(groupBox6);
            tabPage3.Name = "tabPage3";
            toolTip.SetToolTip(tabPage3, resources.GetString("tabPage3.ToolTip"));
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            resources.ApplyResources(groupBox6, "groupBox6");
            groupBox6.Controls.Add(label16);
            groupBox6.Controls.Add(textBoxBackgroundImage);
            groupBox6.Controls.Add(buttonClearBackgroundImage);
            groupBox6.Controls.Add(buttonSetBackgroundImage);
            groupBox6.Controls.Add(numericBoxBackgroundCoeff);
            groupBox6.Name = "groupBox6";
            groupBox6.TabStop = false;
            toolTip.SetToolTip(groupBox6, resources.GetString("groupBox6.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            toolTip.SetToolTip(label16, resources.GetString("label16.ToolTip"));
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            toolTip.SetToolTip(label20, resources.GetString("label20.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(label3, "label3");
            label3.Name = "label3";
            toolTip.SetToolTip(label3, resources.GetString("label3.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(label4, "label4");
            label4.Name = "label4";
            toolTip.SetToolTip(label4, resources.GetString("label4.ToolTip"));
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            toolTip.SetToolTip(label21, resources.GetString("label21.ToolTip"));
            // 
            // numericUpDownMaskEdge
            // 
            resources.ApplyResources(numericUpDownMaskEdge, "numericUpDownMaskEdge");
            numericUpDownMaskEdge.Maximum = new decimal(new int[] { 256, 0, 0, 0 });
            numericUpDownMaskEdge.Name = "numericUpDownMaskEdge";
            toolTip.SetToolTip(numericUpDownMaskEdge, resources.GetString("numericUpDownMaskEdge.ToolTip"));
            numericUpDownMaskEdge.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // FormProperty
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            Controls.Add(tabControl);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            Name = "FormProperty";
            ShowIcon = false;
            toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            FormClosing += FormProperty_FormClosing;
            ((System.ComponentModel.ISupportInitialize)numericUpDownThresholdOfIntensityMax).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownThresholdOfIntensityMin).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownEdge).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangleBand).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRectangleAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSectorStartAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownSectorEndAngle).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownManualSpotSize).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownFindSpotsDeviation).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrollChiDivision).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXend).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXstart).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownUnrolledImageXstep).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBarScaleLineWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl.ResumeLayout(false);
            tabPageXRay.ResumeLayout(false);
            tabPageXRay.PerformLayout();
            tabPageIP.ResumeLayout(false);
            tabPageIP.PerformLayout();
            flowLayoutPanel8.ResumeLayout(false);
            flowLayoutPanel8.PerformLayout();
            flowLayoutPanel7.ResumeLayout(false);
            flowLayoutPanel7.PerformLayout();
            flowLayoutPanelFootMode.ResumeLayout(false);
            groupBox9.ResumeLayout(false);
            groupBox10.ResumeLayout(false);
            groupBox10.PerformLayout();
            flowLayoutPanelDirectSpotMode.ResumeLayout(false);
            groupBoxDirectSpotPosition.ResumeLayout(false);
            groupBoxCameaLength.ResumeLayout(false);
            groupBoxCameaLength.PerformLayout();
            groupBoxPixelShape.ResumeLayout(false);
            groupBoxGandlfiRadius.ResumeLayout(false);
            groupBoxSphericalCorrection.ResumeLayout(false);
            groupBoxSphericalCorrection.PerformLayout();
            groupBoxTiltCorrection.ResumeLayout(false);
            tabPageIntegralRegion.ResumeLayout(false);
            tabPageIntegralRegion.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBoxRectangle.ResumeLayout(false);
            groupBoxRectangle.PerformLayout();
            groupBoxSector.ResumeLayout(false);
            groupBoxSector.PerformLayout();
            tabPageIntegralProperty.ResumeLayout(false);
            tabPageIntegralProperty.PerformLayout();
            groupBoxRadial.ResumeLayout(false);
            groupBoxRadial.PerformLayout();
            groupBoxConcentric.ResumeLayout(false);
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            tabPageSpotsAndCenter.ResumeLayout(false);
            tabPageSpotsAndCenter.PerformLayout();
            groupBox13.ResumeLayout(false);
            groupBoxManualMode.ResumeLayout(false);
            groupBoxManualMode.PerformLayout();
            groupBoxManualSpot.ResumeLayout(false);
            groupBoxManualSpot.PerformLayout();
            groupBoxSpline.ResumeLayout(false);
            groupBoxSpline.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            flowLayoutPanel5.ResumeLayout(false);
            flowLayoutPanel5.PerformLayout();
            groupBox12.ResumeLayout(false);
            groupBox12.PerformLayout();
            tabPageAfterGetProfile.ResumeLayout(false);
            tabPageAfterGetProfile.PerformLayout();
            groupBoxSaveProfile.ResumeLayout(false);
            groupBox17.ResumeLayout(false);
            groupBox17.PerformLayout();
            flowLayoutPanel4.ResumeLayout(false);
            flowLayoutPanel4.PerformLayout();
            groupBox16.ResumeLayout(false);
            groupBox16.PerformLayout();
            flowLayoutPanel1.ResumeLayout(false);
            flowLayoutPanel1.PerformLayout();
            groupBox15.ResumeLayout(false);
            groupBox15.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            groupBoxSendPDI.ResumeLayout(false);
            groupBoxSendPDI.PerformLayout();
            tabPage1.ResumeLayout(false);
            groupBox3.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            tabPage5.ResumeLayout(false);
            groupBox14.ResumeLayout(false);
            groupBox14.PerformLayout();
            groupBox19.ResumeLayout(false);
            groupBox19.PerformLayout();
            groupBox18.ResumeLayout(false);
            groupBox18.PerformLayout();
            groupBox11.ResumeLayout(false);
            groupBox11.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            flowLayoutPanelFindCenterOption.ResumeLayout(false);
            flowLayoutPanelFindCenterOption.PerformLayout();
            tabPage3.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numericUpDownMaskEdge).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.TabControl tabControl;
        public System.Windows.Forms.TabPage tabPageIP;
        public System.Windows.Forms.TabPage tabPageXRay;
        public System.Windows.Forms.GroupBox groupBoxTiltCorrection;
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
        private Crystallography.Controls.NumericBox numericBoxCameraLength1;
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
        public Crystallography.Controls.NumericBox numericBoxPixelKsi;
        public Crystallography.Controls.NumericBox numericBoxTiltTau;
        public Crystallography.Controls.NumericBox numericBoxTiltPhi;
        public Crystallography.Controls.NumericBox numericBoxDirectSpotPositionY;
        public Crystallography.Controls.NumericBox numericBoxDirectSpotPositionX;
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
        public System.Windows.Forms.GroupBox groupBoxSphericalCorrection;
        public Crystallography.Controls.NumericBox numericBoxSphericalCorections;
        public System.Windows.Forms.Label label46;
        private System.Windows.Forms.TabPage tabPage5;
        public System.Windows.Forms.GroupBox groupBoxManualSpot;
        private System.Windows.Forms.Button buttonMaskAll;
        private System.Windows.Forms.Button buttonUnmaskAll;
        public System.Windows.Forms.RadioButton radioButtonManualCircle;
        public System.Windows.Forms.RadioButton radioButtonManualRectangle;
        public System.Windows.Forms.RadioButton radioButtonManualSpline;
        public System.Windows.Forms.RadioButton radioButtonManualSpot;
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
        public Crystallography.Controls.NumericBox numericBoxConcentricStep;
        public Crystallography.Controls.NumericBox numericBoxConcentricEnd;
        public Crystallography.Controls.NumericBox numericBoxConcentricStart;
        public Crystallography.Controls.NumericBox numericBoxRadialRange;
        public Crystallography.Controls.NumericBox numericBoxRadialRadius;
        public Crystallography.Controls.NumericBox numericBoxRadialStep;
        public Crystallography.Controls.NumericBox numericBoxFindCenterSearchArea;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFindCenterOption;
        public System.Windows.Forms.CheckBox checkBoxExcludeMaskedPixels;
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
        public System.Windows.Forms.RadioButton radioButtonTakeoverNothing;
        private System.Windows.Forms.GroupBox groupBox10;
        private Crystallography.Controls.NumericBox numericBoxCameraLength2;
        public System.Windows.Forms.GroupBox groupBox9;
        public Crystallography.Controls.NumericBox numericBoxFootPositionY;
        public Crystallography.Controls.NumericBox numericBoxFootPositionX;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel7;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelFootMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelDirectSpotMode;
        public System.Windows.Forms.RadioButton radioButtonFootMode;
        public System.Windows.Forms.RadioButton radioButtonDirectSpotMode;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel8;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Button buttonMaskTop;
        private System.Windows.Forms.GroupBox groupBox13;
        private System.Windows.Forms.Button buttonMaskLeft;
        private System.Windows.Forms.Button buttonMaskBottom;
        private System.Windows.Forms.Button buttonMaskRight;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel5;
        public System.Windows.Forms.RadioButton radioButtonAsGSASformat;
        private System.Windows.Forms.GroupBox groupBoxSendPDI;
        public System.Windows.Forms.CheckBox checkBoxSendUnrolledImageToPDIndexer;
        public System.Windows.Forms.GroupBox groupBox14;
        private System.Windows.Forms.Label label23;
        public System.Windows.Forms.ComboBox comboBoxScaleLineDivisions;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.CheckBox checkBoxScaleLabel;
        public System.Windows.Forms.TrackBar trackBarScaleLineWidth;
        public Crystallography.Controls.ColorControl colorControlScaleAzimuth;
        public Crystallography.Controls.ColorControl colorControlScale2Theta;
        private System.Windows.Forms.GroupBox groupBox15;
        private System.Windows.Forms.GroupBox groupBox17;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        public System.Windows.Forms.RadioButton radioButtonSaveInOneFile;
        public System.Windows.Forms.RadioButton radioButtonSaveInSeparateFiles;
        private System.Windows.Forms.GroupBox groupBox16;
        public System.Windows.Forms.RadioButton radioButtonManualPolygon;
        private System.Windows.Forms.Label label31;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label27;
        public Crystallography.Controls.NumericBox numericBoxSplineWidth;
        private System.Windows.Forms.Button buttonInvertMask;
        public System.Windows.Forms.GroupBox groupBox18;
        public System.Windows.Forms.CheckBox checkBoxMaintainImageRange;
        public System.Windows.Forms.CheckBox checkBoxMaintainImageContrast;
        public System.Windows.Forms.GroupBox groupBox19;
        private System.Windows.Forms.RadioButton radioButtonImageName_FileName;
        private System.Windows.Forms.RadioButton radioButtonImageName_FullPath;
        private System.Windows.Forms.RadioButton radioButtonImageName_LastFolderPlusFilename;
    private System.Windows.Forms.ToolTip toolTip; // 260531Cl 追加
        private System.ComponentModel.IContainer components;
    }
}