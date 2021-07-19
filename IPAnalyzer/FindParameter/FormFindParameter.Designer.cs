namespace IPAnalyzer
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Drawing.Drawing2D;
    using Crystallography;
    using System.Collections.Generic;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFindParameter));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.numericUpDownBandWidth = new System.Windows.Forms.NumericUpDown();
            this.label28 = new System.Windows.Forms.Label();
            this.numericUpDownSearchRange = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.checkBoxUseStandardCrystal = new System.Windows.Forms.CheckBox();
            this.label38 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.groupBoxPrimaryImage = new System.Windows.Forms.GroupBox();
            this.numericBoxPrimaryImageNum = new Crystallography.Controls.NumericBox();
            this.numericTextBoxPrimaryCenterPositionY = new Crystallography.Controls.NumericBox();
            this.numericTextBoxPrimaryFilmDistance = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPrimaryCenterPositionX = new Crystallography.Controls.NumericBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBoxPattern1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label43 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.buttonGetCenterPositionFromMainForm = new System.Windows.Forms.Button();
            this.buttonPrimaryGetProfile = new System.Windows.Forms.Button();
            this.buttonClearPrimaryImage = new System.Windows.Forms.Button();
            this.buttonOpenPrimaryImage = new System.Windows.Forms.Button();
            this.numericalTextBoxPrimaryCenterPositionYDev = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxPrimaryCenterPositionXDev = new Crystallography.Controls.NumericBox();
            this.textBoxPrimaryFileName = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.groupBoxSecondaryImage = new System.Windows.Forms.GroupBox();
            this.numericBoxSecondaryImageNum = new Crystallography.Controls.NumericBox();
            this.numericTextBoxSecondaryCenterPositionY = new Crystallography.Controls.NumericBox();
            this.buttonOpenSecondaryImage = new System.Windows.Forms.Button();
            this.numericTextBoxSecondaryCenterPositionX = new Crystallography.Controls.NumericBox();
            this.textBoxSecondaryFileName = new System.Windows.Forms.TextBox();
            this.textBoxFilmDistanceDiscrepancy = new Crystallography.Controls.NumericBox();
            this.textBoxPrimaryFilmDistanceCopy = new Crystallography.Controls.NumericBox();
            this.pictureBoxPattern2 = new System.Windows.Forms.PictureBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.buttonGetCenterPositionFromMainForm2 = new System.Windows.Forms.Button();
            this.buttonClearSecondaryImage = new System.Windows.Forms.Button();
            this.buttonSecondaryGetProfile = new System.Windows.Forms.Button();
            this.numericTextBoxSecondaryCenterPositionYDev = new Crystallography.Controls.NumericBox();
            this.numericTextBoxSecondaryCenterPositionXDev = new Crystallography.Controls.NumericBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.label31 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.checkBoxRefineTiltCorrection = new System.Windows.Forms.CheckBox();
            this.checkBoxRefinePixelSize = new System.Windows.Forms.CheckBox();
            this.checkBoxRefineFilmDistance = new System.Windows.Forms.CheckBox();
            this.checkBoxRefineWaveLength = new System.Windows.Forms.CheckBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.groupBoxOption = new System.Windows.Forms.GroupBox();
            this.buttonSchematicDiagram = new System.Windows.Forms.Button();
            this.buttonClearGraphs = new System.Windows.Forms.Button();
            this.buttonSetStandardCrystal = new System.Windows.Forms.Button();
            this.checkBoxRefinePixelDistortion = new System.Windows.Forms.CheckBox();
            this.buttonExecuteRefinements = new System.Windows.Forms.Button();
            this.checkBoxSphericalCorrection = new System.Windows.Forms.CheckBox();
            this.checkBoxCenterPosition = new System.Windows.Forms.CheckBox();
            this.numericUpDownRepitition = new System.Windows.Forms.NumericUpDown();
            this.checkBoxPeakDecomposition = new System.Windows.Forms.CheckBox();
            this.checkBoxMouseOperation = new System.Windows.Forms.CheckBox();
            this.checkBoxRefleshMainform = new System.Windows.Forms.CheckBox();
            this.numericUpDownThresholdOfPeak = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownDivision = new System.Windows.Forms.NumericUpDown();
            this.label45 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label73 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label82 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.radioButtonRectangle = new System.Windows.Forms.RadioButton();
            this.radioButtonSector = new System.Windows.Forms.RadioButton();
            this.buttonStopRefinements = new System.Windows.Forms.Button();
            this.buttonSetInitioalParam = new System.Windows.Forms.Button();
            this.buttonSendMainForm = new System.Windows.Forms.Button();
            this.groupBoxParameter = new System.Windows.Forms.GroupBox();
            this.textBoxPixelKsi = new Crystallography.Controls.NumericBox();
            this.textBoxTiltCorrectionSecondaryTau = new Crystallography.Controls.NumericBox();
            this.textBoxTiltCorrectionPrimaryTau = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxSphericalRadius = new Crystallography.Controls.NumericBox();
            this.textBoxTiltCorrectionSecondaryPhi = new Crystallography.Controls.NumericBox();
            this.textBoxTiltCorrectionPrimaryPhi = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPixelKsiDev = new Crystallography.Controls.NumericBox();
            this.label68 = new System.Windows.Forms.Label();
            this.buttonCopyToClipboard = new System.Windows.Forms.Button();
            this.label34 = new System.Windows.Forms.Label();
            this.textBoxWaveLengthDev = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPixelKsi = new Crystallography.Controls.NumericBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label32 = new System.Windows.Forms.Label();
            this.label70 = new System.Windows.Forms.Label();
            this.textBoxPrimaryFilmDistanceCopy2 = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxRadiusInverseDev = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedSecondaryTauDev = new Crystallography.Controls.NumericBox();
            this.textBoxPixelSizeYDev = new Crystallography.Controls.NumericBox();
            this.textBoxWaveLength = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPixelSizeY = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPrimaryTauDev = new Crystallography.Controls.NumericBox();
            this.textBoxPixelSizeY = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedSecondaryPhiDev = new Crystallography.Controls.NumericBox();
            this.label41 = new System.Windows.Forms.Label();
            this.textBoxRefinedPrimaryFilmDistance = new Crystallography.Controls.NumericBox();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxRefinedPrimaryPhiDev = new Crystallography.Controls.NumericBox();
            this.textBoxPixelSizeX = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedWaveLength = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPixelSizeX = new Crystallography.Controls.NumericBox();
            this.numericalTextBoxRefinedSphericalRadius = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedSecondaryTau = new Crystallography.Controls.NumericBox();
            this.label20 = new System.Windows.Forms.Label();
            this.textBoxPixelSizeXDev = new Crystallography.Controls.NumericBox();
            this.textBoxRefinedPrimaryTau = new Crystallography.Controls.NumericBox();
            this.label44 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label63 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label62 = new System.Windows.Forms.Label();
            this.textBoxCameraLengthDev = new Crystallography.Controls.NumericBox();
            this.label22 = new System.Windows.Forms.Label();
            this.textBoxRefinedSecondaryPhi = new Crystallography.Controls.NumericBox();
            this.label42 = new System.Windows.Forms.Label();
            this.textBoxRefinedPrimaryPhi = new Crystallography.Controls.NumericBox();
            this.label61 = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.label64 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.backgroundWorkerRefine = new System.ComponentModel.BackgroundWorker();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.buttonGetWaveLengthFromWholePattern = new System.Windows.Forms.Button();
            this.buttonGetCameraLenghtFromWholePattern = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.ColumnNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnHKL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPrimaryCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnPrimary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.checkUncheckToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ColumnSecondaryCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSecondary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.pictureBoxPixelKsi = new System.Windows.Forms.PictureBox();
            this.pictureBoxPixelSizeY = new System.Windows.Forms.PictureBox();
            this.pictureBoxPixelSizeX = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrectionTau2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrectionTau1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrectionPhi2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrectionPhi1 = new System.Windows.Forms.PictureBox();
            this.pictureBoxCameraLength = new System.Windows.Forms.PictureBox();
            this.pictureBoxResidual = new System.Windows.Forms.PictureBox();
            this.pictureBoxWaveLength = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrection2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxTiltCorrection1 = new System.Windows.Forms.PictureBox();
            this.label74 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label57 = new System.Windows.Forms.Label();
            this.label60 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label37 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label52 = new System.Windows.Forms.Label();
            this.toolTipJapanese = new System.Windows.Forms.ToolTip(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBoxPeakList = new System.Windows.Forms.GroupBox();
            this.buttonCheckPeaks = new System.Windows.Forms.Button();
            this.numericBoxAwayFrom = new Crystallography.Controls.NumericBox();
            this.numericBoxLowerThan = new Crystallography.Controls.NumericBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.flowLayoutPanelEachPeaks = new System.Windows.Forms.FlowLayoutPanel();
            this.checkBoxShowEachPeaks = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBandWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).BeginInit();
            this.groupBoxPrimaryImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern1)).BeginInit();
            this.groupBoxSecondaryImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern2)).BeginInit();
            this.groupBoxOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepitition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfPeak)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivision)).BeginInit();
            this.groupBoxParameter.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelKsi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelSizeY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelSizeX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionTau2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionTau1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionPhi2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionPhi1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCameraLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResidual)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaveLength)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrection2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrection1)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.groupBoxPeakList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // label24
            // 
            resources.ApplyResources(this.label24, "label24");
            this.label24.Name = "label24";
            // 
            // label25
            // 
            resources.ApplyResources(this.label25, "label25");
            this.label25.Name = "label25";
            // 
            // label26
            // 
            resources.ApplyResources(this.label26, "label26");
            this.label26.Name = "label26";
            // 
            // numericUpDownBandWidth
            // 
            resources.ApplyResources(this.numericUpDownBandWidth, "numericUpDownBandWidth");
            this.numericUpDownBandWidth.Name = "numericUpDownBandWidth";
            this.toolTipJapanese.SetToolTip(this.numericUpDownBandWidth, resources.GetString("numericUpDownBandWidth.ToolTip"));
            this.numericUpDownBandWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // label28
            // 
            resources.ApplyResources(this.label28, "label28");
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.Name = "label28";
            // 
            // numericUpDownSearchRange
            // 
            this.numericUpDownSearchRange.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownSearchRange, "numericUpDownSearchRange");
            this.numericUpDownSearchRange.Increment = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchRange.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownSearchRange.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            65536});
            this.numericUpDownSearchRange.Name = "numericUpDownSearchRange";
            this.toolTipJapanese.SetToolTip(this.numericUpDownSearchRange, resources.GetString("numericUpDownSearchRange.ToolTip"));
            this.numericUpDownSearchRange.Value = new decimal(new int[] {
            8,
            0,
            0,
            65536});
            this.numericUpDownSearchRange.ValueChanged += new System.EventHandler(this.numericUpDownSearchRange_ValueChanged);
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            this.label11.Click += new System.EventHandler(this.label11_Click);
            // 
            // label27
            // 
            resources.ApplyResources(this.label27, "label27");
            this.label27.Name = "label27";
            // 
            // checkBoxUseStandardCrystal
            // 
            resources.ApplyResources(this.checkBoxUseStandardCrystal, "checkBoxUseStandardCrystal");
            this.checkBoxUseStandardCrystal.Checked = true;
            this.checkBoxUseStandardCrystal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxUseStandardCrystal.Name = "checkBoxUseStandardCrystal";
            this.toolTipJapanese.SetToolTip(this.checkBoxUseStandardCrystal, resources.GetString("checkBoxUseStandardCrystal.ToolTip"));
            this.checkBoxUseStandardCrystal.CheckedChanged += new System.EventHandler(this.checkBoxShowCrystalParameter_CheckedChanged);
            // 
            // label38
            // 
            resources.ApplyResources(this.label38, "label38");
            this.label38.Name = "label38";
            // 
            // label36
            // 
            resources.ApplyResources(this.label36, "label36");
            this.label36.Name = "label36";
            // 
            // label46
            // 
            resources.ApplyResources(this.label46, "label46");
            this.label46.Name = "label46";
            // 
            // label48
            // 
            resources.ApplyResources(this.label48, "label48");
            this.label48.Name = "label48";
            // 
            // groupBoxPrimaryImage
            // 
            this.groupBoxPrimaryImage.Controls.Add(this.numericBoxPrimaryImageNum);
            this.groupBoxPrimaryImage.Controls.Add(this.numericTextBoxPrimaryCenterPositionY);
            this.groupBoxPrimaryImage.Controls.Add(this.numericTextBoxPrimaryFilmDistance);
            this.groupBoxPrimaryImage.Controls.Add(this.numericalTextBoxPrimaryCenterPositionX);
            this.groupBoxPrimaryImage.Controls.Add(this.label9);
            this.groupBoxPrimaryImage.Controls.Add(this.pictureBoxPattern1);
            this.groupBoxPrimaryImage.Controls.Add(this.label2);
            this.groupBoxPrimaryImage.Controls.Add(this.label43);
            this.groupBoxPrimaryImage.Controls.Add(this.label10);
            this.groupBoxPrimaryImage.Controls.Add(this.label51);
            this.groupBoxPrimaryImage.Controls.Add(this.buttonGetCenterPositionFromMainForm);
            this.groupBoxPrimaryImage.Controls.Add(this.buttonPrimaryGetProfile);
            this.groupBoxPrimaryImage.Controls.Add(this.buttonClearPrimaryImage);
            this.groupBoxPrimaryImage.Controls.Add(this.buttonOpenPrimaryImage);
            this.groupBoxPrimaryImage.Controls.Add(this.numericalTextBoxPrimaryCenterPositionYDev);
            this.groupBoxPrimaryImage.Controls.Add(this.numericalTextBoxPrimaryCenterPositionXDev);
            this.groupBoxPrimaryImage.Controls.Add(this.textBoxPrimaryFileName);
            this.groupBoxPrimaryImage.Controls.Add(this.label23);
            this.groupBoxPrimaryImage.Controls.Add(this.label53);
            this.groupBoxPrimaryImage.Controls.Add(this.label26);
            resources.ApplyResources(this.groupBoxPrimaryImage, "groupBoxPrimaryImage");
            this.groupBoxPrimaryImage.Name = "groupBoxPrimaryImage";
            this.groupBoxPrimaryImage.TabStop = false;
            this.groupBoxPrimaryImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxPrimaryImage_DragDrop);
            this.groupBoxPrimaryImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBoxPrimaryImage_DragEnter);
            // 
            // numericBoxPrimaryImageNum
            // 
            resources.ApplyResources(this.numericBoxPrimaryImageNum, "numericBoxPrimaryImageNum");
            this.numericBoxPrimaryImageNum.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPrimaryImageNum.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPrimaryImageNum.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxPrimaryImageNum.Name = "numericBoxPrimaryImageNum";
            this.numericBoxPrimaryImageNum.RoundErrorAccuracy = -1;
            this.numericBoxPrimaryImageNum.SkipEventDuringInput = false;
            this.numericBoxPrimaryImageNum.SmartIncrement = true;
            this.numericBoxPrimaryImageNum.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxPrimaryImageNum.ThonsandsSeparator = true;
            // 
            // numericTextBoxPrimaryCenterPositionY
            // 
            resources.ApplyResources(this.numericTextBoxPrimaryCenterPositionY, "numericTextBoxPrimaryCenterPositionY");
            this.numericTextBoxPrimaryCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryCenterPositionY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryCenterPositionY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryCenterPositionY.Name = "numericTextBoxPrimaryCenterPositionY";
            this.numericTextBoxPrimaryCenterPositionY.RoundErrorAccuracy = -1;
            this.numericTextBoxPrimaryCenterPositionY.SkipEventDuringInput = false;
            this.numericTextBoxPrimaryCenterPositionY.SmartIncrement = true;
            this.numericTextBoxPrimaryCenterPositionY.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxPrimaryCenterPositionY.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.numericTextBoxPrimaryCenterPositionY, resources.GetString("numericTextBoxPrimaryCenterPositionY.ToolTip"));
            this.numericTextBoxPrimaryCenterPositionY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericTextBoxPrimaryCenterPositionY.DoubleClick += new System.EventHandler(this.textBoxPrimaryCenterPositionX_DoubleClick);
            // 
            // numericTextBoxPrimaryFilmDistance
            // 
            resources.ApplyResources(this.numericTextBoxPrimaryFilmDistance, "numericTextBoxPrimaryFilmDistance");
            this.numericTextBoxPrimaryFilmDistance.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryFilmDistance.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryFilmDistance.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxPrimaryFilmDistance.Name = "numericTextBoxPrimaryFilmDistance";
            this.numericTextBoxPrimaryFilmDistance.RoundErrorAccuracy = -1;
            this.numericTextBoxPrimaryFilmDistance.SkipEventDuringInput = false;
            this.numericTextBoxPrimaryFilmDistance.SmartIncrement = true;
            this.numericTextBoxPrimaryFilmDistance.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxPrimaryFilmDistance.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.numericTextBoxPrimaryFilmDistance, resources.GetString("numericTextBoxPrimaryFilmDistance.ToolTip"));
            this.numericTextBoxPrimaryFilmDistance.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericTextBoxPrimaryFilmDistance_TextChanged);
            // 
            // numericalTextBoxPrimaryCenterPositionX
            // 
            resources.ApplyResources(this.numericalTextBoxPrimaryCenterPositionX, "numericalTextBoxPrimaryCenterPositionX");
            this.numericalTextBoxPrimaryCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionX.Name = "numericalTextBoxPrimaryCenterPositionX";
            this.numericalTextBoxPrimaryCenterPositionX.RoundErrorAccuracy = -1;
            this.numericalTextBoxPrimaryCenterPositionX.SkipEventDuringInput = false;
            this.numericalTextBoxPrimaryCenterPositionX.SmartIncrement = true;
            this.numericalTextBoxPrimaryCenterPositionX.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPrimaryCenterPositionX.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.numericalTextBoxPrimaryCenterPositionX, resources.GetString("numericalTextBoxPrimaryCenterPositionX.ToolTip"));
            this.numericalTextBoxPrimaryCenterPositionX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericalTextBoxPrimaryCenterPositionX.DoubleClick += new System.EventHandler(this.textBoxPrimaryCenterPositionX_DoubleClick);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // pictureBoxPattern1
            // 
            this.pictureBoxPattern1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pictureBoxPattern1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxPattern1, "pictureBoxPattern1");
            this.pictureBoxPattern1.Name = "pictureBoxPattern1";
            this.pictureBoxPattern1.TabStop = false;
            this.pictureBoxPattern1.Click += new System.EventHandler(this.pictureBoxPattern1_Click);
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // label43
            // 
            resources.ApplyResources(this.label43, "label43");
            this.label43.Name = "label43";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label51
            // 
            resources.ApplyResources(this.label51, "label51");
            this.label51.Name = "label51";
            // 
            // buttonGetCenterPositionFromMainForm
            // 
            resources.ApplyResources(this.buttonGetCenterPositionFromMainForm, "buttonGetCenterPositionFromMainForm");
            this.buttonGetCenterPositionFromMainForm.Name = "buttonGetCenterPositionFromMainForm";
            this.buttonGetCenterPositionFromMainForm.UseVisualStyleBackColor = true;
            this.buttonGetCenterPositionFromMainForm.Click += new System.EventHandler(this.textBoxPrimaryCenterPositionX_DoubleClick);
            // 
            // buttonPrimaryGetProfile
            // 
            resources.ApplyResources(this.buttonPrimaryGetProfile, "buttonPrimaryGetProfile");
            this.buttonPrimaryGetProfile.Name = "buttonPrimaryGetProfile";
            this.toolTipJapanese.SetToolTip(this.buttonPrimaryGetProfile, resources.GetString("buttonPrimaryGetProfile.ToolTip"));
            this.buttonPrimaryGetProfile.UseVisualStyleBackColor = true;
            this.buttonPrimaryGetProfile.Click += new System.EventHandler(this.buttonPrimaryGetProfile_Click);
            // 
            // buttonClearPrimaryImage
            // 
            resources.ApplyResources(this.buttonClearPrimaryImage, "buttonClearPrimaryImage");
            this.buttonClearPrimaryImage.Name = "buttonClearPrimaryImage";
            this.buttonClearPrimaryImage.UseVisualStyleBackColor = true;
            this.buttonClearPrimaryImage.Click += new System.EventHandler(this.buttonClearPrimaryImage_Click);
            // 
            // buttonOpenPrimaryImage
            // 
            resources.ApplyResources(this.buttonOpenPrimaryImage, "buttonOpenPrimaryImage");
            this.buttonOpenPrimaryImage.Name = "buttonOpenPrimaryImage";
            this.toolTipJapanese.SetToolTip(this.buttonOpenPrimaryImage, resources.GetString("buttonOpenPrimaryImage.ToolTip"));
            this.buttonOpenPrimaryImage.UseVisualStyleBackColor = true;
            this.buttonOpenPrimaryImage.Click += new System.EventHandler(this.buttonOpenPrimaryImage_Click);
            // 
            // numericalTextBoxPrimaryCenterPositionYDev
            // 
            resources.ApplyResources(this.numericalTextBoxPrimaryCenterPositionYDev, "numericalTextBoxPrimaryCenterPositionYDev");
            this.numericalTextBoxPrimaryCenterPositionYDev.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionYDev.DecimalPlaces = 10;
            this.numericalTextBoxPrimaryCenterPositionYDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionYDev.Name = "numericalTextBoxPrimaryCenterPositionYDev";
            this.numericalTextBoxPrimaryCenterPositionYDev.ReadOnly = true;
            this.numericalTextBoxPrimaryCenterPositionYDev.RoundErrorAccuracy = -1;
            this.numericalTextBoxPrimaryCenterPositionYDev.SkipEventDuringInput = false;
            this.numericalTextBoxPrimaryCenterPositionYDev.SmartIncrement = true;
            this.numericalTextBoxPrimaryCenterPositionYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionYDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPrimaryCenterPositionYDev.ThonsandsSeparator = true;
            this.numericalTextBoxPrimaryCenterPositionYDev.WordWrap = false;
            // 
            // numericalTextBoxPrimaryCenterPositionXDev
            // 
            resources.ApplyResources(this.numericalTextBoxPrimaryCenterPositionXDev, "numericalTextBoxPrimaryCenterPositionXDev");
            this.numericalTextBoxPrimaryCenterPositionXDev.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionXDev.DecimalPlaces = 10;
            this.numericalTextBoxPrimaryCenterPositionXDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionXDev.Name = "numericalTextBoxPrimaryCenterPositionXDev";
            this.numericalTextBoxPrimaryCenterPositionXDev.ReadOnly = true;
            this.numericalTextBoxPrimaryCenterPositionXDev.RoundErrorAccuracy = -1;
            this.numericalTextBoxPrimaryCenterPositionXDev.SkipEventDuringInput = false;
            this.numericalTextBoxPrimaryCenterPositionXDev.SmartIncrement = true;
            this.numericalTextBoxPrimaryCenterPositionXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxPrimaryCenterPositionXDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxPrimaryCenterPositionXDev.ThonsandsSeparator = true;
            this.numericalTextBoxPrimaryCenterPositionXDev.WordWrap = false;
            // 
            // textBoxPrimaryFileName
            // 
            resources.ApplyResources(this.textBoxPrimaryFileName, "textBoxPrimaryFileName");
            this.textBoxPrimaryFileName.Name = "textBoxPrimaryFileName";
            this.textBoxPrimaryFileName.ReadOnly = true;
            this.toolTipJapanese.SetToolTip(this.textBoxPrimaryFileName, resources.GetString("textBoxPrimaryFileName.ToolTip"));
            this.textBoxPrimaryFileName.TextChanged += new System.EventHandler(this.textBoxPrimaryFileName_TextChanged);
            // 
            // label23
            // 
            resources.ApplyResources(this.label23, "label23");
            this.label23.Name = "label23";
            // 
            // label53
            // 
            resources.ApplyResources(this.label53, "label53");
            this.label53.Name = "label53";
            // 
            // groupBoxSecondaryImage
            // 
            this.groupBoxSecondaryImage.Controls.Add(this.numericBoxSecondaryImageNum);
            this.groupBoxSecondaryImage.Controls.Add(this.numericTextBoxSecondaryCenterPositionY);
            this.groupBoxSecondaryImage.Controls.Add(this.buttonOpenSecondaryImage);
            this.groupBoxSecondaryImage.Controls.Add(this.numericTextBoxSecondaryCenterPositionX);
            this.groupBoxSecondaryImage.Controls.Add(this.textBoxSecondaryFileName);
            this.groupBoxSecondaryImage.Controls.Add(this.textBoxFilmDistanceDiscrepancy);
            this.groupBoxSecondaryImage.Controls.Add(this.textBoxPrimaryFilmDistanceCopy);
            this.groupBoxSecondaryImage.Controls.Add(this.pictureBoxPattern2);
            this.groupBoxSecondaryImage.Controls.Add(this.label54);
            this.groupBoxSecondaryImage.Controls.Add(this.label5);
            this.groupBoxSecondaryImage.Controls.Add(this.label55);
            this.groupBoxSecondaryImage.Controls.Add(this.buttonGetCenterPositionFromMainForm2);
            this.groupBoxSecondaryImage.Controls.Add(this.buttonClearSecondaryImage);
            this.groupBoxSecondaryImage.Controls.Add(this.buttonSecondaryGetProfile);
            this.groupBoxSecondaryImage.Controls.Add(this.numericTextBoxSecondaryCenterPositionYDev);
            this.groupBoxSecondaryImage.Controls.Add(this.numericTextBoxSecondaryCenterPositionXDev);
            this.groupBoxSecondaryImage.Controls.Add(this.label4);
            this.groupBoxSecondaryImage.Controls.Add(this.label56);
            this.groupBoxSecondaryImage.Controls.Add(this.label31);
            this.groupBoxSecondaryImage.Controls.Add(this.label3);
            this.groupBoxSecondaryImage.Controls.Add(this.label58);
            this.groupBoxSecondaryImage.Controls.Add(this.label29);
            resources.ApplyResources(this.groupBoxSecondaryImage, "groupBoxSecondaryImage");
            this.groupBoxSecondaryImage.Name = "groupBoxSecondaryImage";
            this.groupBoxSecondaryImage.TabStop = false;
            this.groupBoxSecondaryImage.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxSecondaryImage_DragDrop);
            this.groupBoxSecondaryImage.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBoxSecondaryImage_DragEnter);
            // 
            // numericBoxSecondaryImageNum
            // 
            resources.ApplyResources(this.numericBoxSecondaryImageNum, "numericBoxSecondaryImageNum");
            this.numericBoxSecondaryImageNum.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxSecondaryImageNum.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxSecondaryImageNum.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxSecondaryImageNum.Name = "numericBoxSecondaryImageNum";
            this.numericBoxSecondaryImageNum.RoundErrorAccuracy = -1;
            this.numericBoxSecondaryImageNum.SkipEventDuringInput = false;
            this.numericBoxSecondaryImageNum.SmartIncrement = true;
            this.numericBoxSecondaryImageNum.TextFont = new System.Drawing.Font("メイリオ", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxSecondaryImageNum.ThonsandsSeparator = true;
            // 
            // numericTextBoxSecondaryCenterPositionY
            // 
            resources.ApplyResources(this.numericTextBoxSecondaryCenterPositionY, "numericTextBoxSecondaryCenterPositionY");
            this.numericTextBoxSecondaryCenterPositionY.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionY.Name = "numericTextBoxSecondaryCenterPositionY";
            this.numericTextBoxSecondaryCenterPositionY.RoundErrorAccuracy = -1;
            this.numericTextBoxSecondaryCenterPositionY.SkipEventDuringInput = false;
            this.numericTextBoxSecondaryCenterPositionY.SmartIncrement = true;
            this.numericTextBoxSecondaryCenterPositionY.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxSecondaryCenterPositionY.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.numericTextBoxSecondaryCenterPositionY, resources.GetString("numericTextBoxSecondaryCenterPositionY.ToolTip"));
            this.numericTextBoxSecondaryCenterPositionY.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericTextBoxSecondaryCenterPositionY.DoubleClick += new System.EventHandler(this.textBoxSecondaryCenterPositionX_DoubleClick);
            // 
            // buttonOpenSecondaryImage
            // 
            resources.ApplyResources(this.buttonOpenSecondaryImage, "buttonOpenSecondaryImage");
            this.buttonOpenSecondaryImage.Name = "buttonOpenSecondaryImage";
            this.toolTipJapanese.SetToolTip(this.buttonOpenSecondaryImage, resources.GetString("buttonOpenSecondaryImage.ToolTip"));
            this.buttonOpenSecondaryImage.UseVisualStyleBackColor = true;
            this.buttonOpenSecondaryImage.Click += new System.EventHandler(this.buttonOpenSecondaryImage_Click);
            // 
            // numericTextBoxSecondaryCenterPositionX
            // 
            resources.ApplyResources(this.numericTextBoxSecondaryCenterPositionX, "numericTextBoxSecondaryCenterPositionX");
            this.numericTextBoxSecondaryCenterPositionX.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionX.Name = "numericTextBoxSecondaryCenterPositionX";
            this.numericTextBoxSecondaryCenterPositionX.RoundErrorAccuracy = -1;
            this.numericTextBoxSecondaryCenterPositionX.SkipEventDuringInput = false;
            this.numericTextBoxSecondaryCenterPositionX.SmartIncrement = true;
            this.numericTextBoxSecondaryCenterPositionX.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxSecondaryCenterPositionX.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.numericTextBoxSecondaryCenterPositionX, resources.GetString("numericTextBoxSecondaryCenterPositionX.ToolTip"));
            this.numericTextBoxSecondaryCenterPositionX.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.numericTextBoxSecondaryCenterPositionX.DoubleClick += new System.EventHandler(this.textBoxSecondaryCenterPositionX_DoubleClick);
            // 
            // textBoxSecondaryFileName
            // 
            resources.ApplyResources(this.textBoxSecondaryFileName, "textBoxSecondaryFileName");
            this.textBoxSecondaryFileName.Name = "textBoxSecondaryFileName";
            this.textBoxSecondaryFileName.ReadOnly = true;
            this.textBoxSecondaryFileName.TextChanged += new System.EventHandler(this.textBoxSecondaryFileName_TextChanged);
            // 
            // textBoxFilmDistanceDiscrepancy
            // 
            resources.ApplyResources(this.textBoxFilmDistanceDiscrepancy, "textBoxFilmDistanceDiscrepancy");
            this.textBoxFilmDistanceDiscrepancy.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxFilmDistanceDiscrepancy.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxFilmDistanceDiscrepancy.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxFilmDistanceDiscrepancy.Name = "textBoxFilmDistanceDiscrepancy";
            this.textBoxFilmDistanceDiscrepancy.RadianValue = 1.7453292519943295D;
            this.textBoxFilmDistanceDiscrepancy.RoundErrorAccuracy = -1;
            this.textBoxFilmDistanceDiscrepancy.SkipEventDuringInput = false;
            this.textBoxFilmDistanceDiscrepancy.SmartIncrement = true;
            this.textBoxFilmDistanceDiscrepancy.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxFilmDistanceDiscrepancy.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxFilmDistanceDiscrepancy, resources.GetString("textBoxFilmDistanceDiscrepancy.ToolTip"));
            this.textBoxFilmDistanceDiscrepancy.Value = 100D;
            this.textBoxFilmDistanceDiscrepancy.WordWrap = false;
            this.textBoxFilmDistanceDiscrepancy.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBoxFilmDistanceDiscrepancy_TextChanged);
            this.textBoxFilmDistanceDiscrepancy.TextChanged += new System.EventHandler(this.textBoxFilmDistanceDiscrepancy_TextChanged);
            // 
            // textBoxPrimaryFilmDistanceCopy
            // 
            resources.ApplyResources(this.textBoxPrimaryFilmDistanceCopy, "textBoxPrimaryFilmDistanceCopy");
            this.textBoxPrimaryFilmDistanceCopy.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy.Name = "textBoxPrimaryFilmDistanceCopy";
            this.textBoxPrimaryFilmDistanceCopy.RadianValue = 7.7667151713747664D;
            this.textBoxPrimaryFilmDistanceCopy.ReadOnly = true;
            this.textBoxPrimaryFilmDistanceCopy.RoundErrorAccuracy = -1;
            this.textBoxPrimaryFilmDistanceCopy.SkipEventDuringInput = false;
            this.textBoxPrimaryFilmDistanceCopy.SmartIncrement = true;
            this.textBoxPrimaryFilmDistanceCopy.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPrimaryFilmDistanceCopy.ThonsandsSeparator = true;
            this.textBoxPrimaryFilmDistanceCopy.Value = 445D;
            this.textBoxPrimaryFilmDistanceCopy.WordWrap = false;
            // 
            // pictureBoxPattern2
            // 
            this.pictureBoxPattern2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.pictureBoxPattern2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxPattern2, "pictureBoxPattern2");
            this.pictureBoxPattern2.Name = "pictureBoxPattern2";
            this.pictureBoxPattern2.TabStop = false;
            this.pictureBoxPattern2.Click += new System.EventHandler(this.pictureBoxPattern2_Click);
            // 
            // label54
            // 
            resources.ApplyResources(this.label54, "label54");
            this.label54.Name = "label54";
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // label55
            // 
            resources.ApplyResources(this.label55, "label55");
            this.label55.Name = "label55";
            // 
            // buttonGetCenterPositionFromMainForm2
            // 
            resources.ApplyResources(this.buttonGetCenterPositionFromMainForm2, "buttonGetCenterPositionFromMainForm2");
            this.buttonGetCenterPositionFromMainForm2.Name = "buttonGetCenterPositionFromMainForm2";
            this.buttonGetCenterPositionFromMainForm2.UseVisualStyleBackColor = true;
            this.buttonGetCenterPositionFromMainForm2.Click += new System.EventHandler(this.textBoxSecondaryCenterPositionX_DoubleClick);
            // 
            // buttonClearSecondaryImage
            // 
            resources.ApplyResources(this.buttonClearSecondaryImage, "buttonClearSecondaryImage");
            this.buttonClearSecondaryImage.Name = "buttonClearSecondaryImage";
            this.buttonClearSecondaryImage.UseVisualStyleBackColor = true;
            this.buttonClearSecondaryImage.Click += new System.EventHandler(this.buttonClearSecondaryImage_Click);
            // 
            // buttonSecondaryGetProfile
            // 
            resources.ApplyResources(this.buttonSecondaryGetProfile, "buttonSecondaryGetProfile");
            this.buttonSecondaryGetProfile.Name = "buttonSecondaryGetProfile";
            this.toolTipJapanese.SetToolTip(this.buttonSecondaryGetProfile, resources.GetString("buttonSecondaryGetProfile.ToolTip"));
            this.buttonSecondaryGetProfile.UseVisualStyleBackColor = true;
            this.buttonSecondaryGetProfile.Click += new System.EventHandler(this.buttonSecondaryGetProfile_Click);
            // 
            // numericTextBoxSecondaryCenterPositionYDev
            // 
            resources.ApplyResources(this.numericTextBoxSecondaryCenterPositionYDev, "numericTextBoxSecondaryCenterPositionYDev");
            this.numericTextBoxSecondaryCenterPositionYDev.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionYDev.DecimalPlaces = 10;
            this.numericTextBoxSecondaryCenterPositionYDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionYDev.Name = "numericTextBoxSecondaryCenterPositionYDev";
            this.numericTextBoxSecondaryCenterPositionYDev.ReadOnly = true;
            this.numericTextBoxSecondaryCenterPositionYDev.RoundErrorAccuracy = -1;
            this.numericTextBoxSecondaryCenterPositionYDev.SkipEventDuringInput = false;
            this.numericTextBoxSecondaryCenterPositionYDev.SmartIncrement = true;
            this.numericTextBoxSecondaryCenterPositionYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionYDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxSecondaryCenterPositionYDev.ThonsandsSeparator = true;
            this.numericTextBoxSecondaryCenterPositionYDev.WordWrap = false;
            // 
            // numericTextBoxSecondaryCenterPositionXDev
            // 
            resources.ApplyResources(this.numericTextBoxSecondaryCenterPositionXDev, "numericTextBoxSecondaryCenterPositionXDev");
            this.numericTextBoxSecondaryCenterPositionXDev.BackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionXDev.DecimalPlaces = 10;
            this.numericTextBoxSecondaryCenterPositionXDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionXDev.Name = "numericTextBoxSecondaryCenterPositionXDev";
            this.numericTextBoxSecondaryCenterPositionXDev.ReadOnly = true;
            this.numericTextBoxSecondaryCenterPositionXDev.RoundErrorAccuracy = -1;
            this.numericTextBoxSecondaryCenterPositionXDev.SkipEventDuringInput = false;
            this.numericTextBoxSecondaryCenterPositionXDev.SmartIncrement = true;
            this.numericTextBoxSecondaryCenterPositionXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericTextBoxSecondaryCenterPositionXDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericTextBoxSecondaryCenterPositionXDev.ThonsandsSeparator = true;
            this.numericTextBoxSecondaryCenterPositionXDev.WordWrap = false;
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // label56
            // 
            resources.ApplyResources(this.label56, "label56");
            this.label56.Name = "label56";
            // 
            // label31
            // 
            resources.ApplyResources(this.label31, "label31");
            this.label31.Name = "label31";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label58
            // 
            resources.ApplyResources(this.label58, "label58");
            this.label58.Name = "label58";
            // 
            // label29
            // 
            resources.ApplyResources(this.label29, "label29");
            this.label29.Name = "label29";
            // 
            // checkBoxRefineTiltCorrection
            // 
            resources.ApplyResources(this.checkBoxRefineTiltCorrection, "checkBoxRefineTiltCorrection");
            this.checkBoxRefineTiltCorrection.Checked = true;
            this.checkBoxRefineTiltCorrection.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefineTiltCorrection.Name = "checkBoxRefineTiltCorrection";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefineTiltCorrection, resources.GetString("checkBoxRefineTiltCorrection.ToolTip"));
            this.checkBoxRefineTiltCorrection.UseVisualStyleBackColor = true;
            this.checkBoxRefineTiltCorrection.CheckedChanged += new System.EventHandler(this.checkBoxRefineTiltCorrection_CheckedChanged);
            // 
            // checkBoxRefinePixelSize
            // 
            resources.ApplyResources(this.checkBoxRefinePixelSize, "checkBoxRefinePixelSize");
            this.checkBoxRefinePixelSize.Checked = true;
            this.checkBoxRefinePixelSize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefinePixelSize.Name = "checkBoxRefinePixelSize";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefinePixelSize, resources.GetString("checkBoxRefinePixelSize.ToolTip"));
            this.checkBoxRefinePixelSize.UseVisualStyleBackColor = true;
            this.checkBoxRefinePixelSize.CheckedChanged += new System.EventHandler(this.checkBoxRefinePixelSize_CheckedChanged);
            // 
            // checkBoxRefineFilmDistance
            // 
            resources.ApplyResources(this.checkBoxRefineFilmDistance, "checkBoxRefineFilmDistance");
            this.checkBoxRefineFilmDistance.Checked = true;
            this.checkBoxRefineFilmDistance.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefineFilmDistance.Name = "checkBoxRefineFilmDistance";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefineFilmDistance, resources.GetString("checkBoxRefineFilmDistance.ToolTip"));
            this.checkBoxRefineFilmDistance.UseVisualStyleBackColor = true;
            // 
            // checkBoxRefineWaveLength
            // 
            resources.ApplyResources(this.checkBoxRefineWaveLength, "checkBoxRefineWaveLength");
            this.checkBoxRefineWaveLength.Checked = true;
            this.checkBoxRefineWaveLength.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefineWaveLength.Name = "checkBoxRefineWaveLength";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefineWaveLength, resources.GetString("checkBoxRefineWaveLength.ToolTip"));
            this.checkBoxRefineWaveLength.UseVisualStyleBackColor = true;
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // label35
            // 
            resources.ApplyResources(this.label35, "label35");
            this.label35.Name = "label35";
            // 
            // label40
            // 
            resources.ApplyResources(this.label40, "label40");
            this.label40.Name = "label40";
            // 
            // groupBoxOption
            // 
            this.groupBoxOption.Controls.Add(this.buttonSchematicDiagram);
            this.groupBoxOption.Controls.Add(this.buttonClearGraphs);
            this.groupBoxOption.Controls.Add(this.buttonSetStandardCrystal);
            this.groupBoxOption.Controls.Add(this.checkBoxRefinePixelDistortion);
            this.groupBoxOption.Controls.Add(this.buttonExecuteRefinements);
            this.groupBoxOption.Controls.Add(this.checkBoxRefinePixelSize);
            this.groupBoxOption.Controls.Add(this.checkBoxSphericalCorrection);
            this.groupBoxOption.Controls.Add(this.checkBoxCenterPosition);
            this.groupBoxOption.Controls.Add(this.checkBoxRefineTiltCorrection);
            this.groupBoxOption.Controls.Add(this.checkBoxRefineFilmDistance);
            this.groupBoxOption.Controls.Add(this.checkBoxRefineWaveLength);
            this.groupBoxOption.Controls.Add(this.numericUpDownRepitition);
            this.groupBoxOption.Controls.Add(this.checkBoxPeakDecomposition);
            this.groupBoxOption.Controls.Add(this.checkBoxMouseOperation);
            this.groupBoxOption.Controls.Add(this.checkBoxRefleshMainform);
            this.groupBoxOption.Controls.Add(this.checkBoxUseStandardCrystal);
            this.groupBoxOption.Controls.Add(this.numericUpDownThresholdOfPeak);
            this.groupBoxOption.Controls.Add(this.numericUpDownDivision);
            this.groupBoxOption.Controls.Add(this.numericUpDownBandWidth);
            this.groupBoxOption.Controls.Add(this.label45);
            this.groupBoxOption.Controls.Add(this.label21);
            this.groupBoxOption.Controls.Add(this.label28);
            this.groupBoxOption.Controls.Add(this.label27);
            this.groupBoxOption.Controls.Add(this.label73);
            this.groupBoxOption.Controls.Add(this.numericUpDownSearchRange);
            this.groupBoxOption.Controls.Add(this.label11);
            this.groupBoxOption.Controls.Add(this.label67);
            this.groupBoxOption.Controls.Add(this.label82);
            this.groupBoxOption.Controls.Add(this.label17);
            this.groupBoxOption.Controls.Add(this.radioButtonRectangle);
            this.groupBoxOption.Controls.Add(this.radioButtonSector);
            resources.ApplyResources(this.groupBoxOption, "groupBoxOption");
            this.groupBoxOption.Name = "groupBoxOption";
            this.groupBoxOption.TabStop = false;
            // 
            // buttonSchematicDiagram
            // 
            resources.ApplyResources(this.buttonSchematicDiagram, "buttonSchematicDiagram");
            this.buttonSchematicDiagram.Name = "buttonSchematicDiagram";
            this.toolTipJapanese.SetToolTip(this.buttonSchematicDiagram, resources.GetString("buttonSchematicDiagram.ToolTip"));
            this.buttonSchematicDiagram.UseVisualStyleBackColor = true;
            this.buttonSchematicDiagram.Click += new System.EventHandler(this.buttonSchematicDiagram_Click);
            // 
            // buttonClearGraphs
            // 
            resources.ApplyResources(this.buttonClearGraphs, "buttonClearGraphs");
            this.buttonClearGraphs.Name = "buttonClearGraphs";
            this.toolTipJapanese.SetToolTip(this.buttonClearGraphs, resources.GetString("buttonClearGraphs.ToolTip"));
            this.buttonClearGraphs.Click += new System.EventHandler(this.buttonClearGraphs_Click);
            // 
            // buttonSetStandardCrystal
            // 
            resources.ApplyResources(this.buttonSetStandardCrystal, "buttonSetStandardCrystal");
            this.buttonSetStandardCrystal.Name = "buttonSetStandardCrystal";
            this.buttonSetStandardCrystal.Click += new System.EventHandler(this.buttonSetStandardCrystal_Click);
            // 
            // checkBoxRefinePixelDistortion
            // 
            resources.ApplyResources(this.checkBoxRefinePixelDistortion, "checkBoxRefinePixelDistortion");
            this.checkBoxRefinePixelDistortion.Checked = true;
            this.checkBoxRefinePixelDistortion.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefinePixelDistortion.Name = "checkBoxRefinePixelDistortion";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefinePixelDistortion, resources.GetString("checkBoxRefinePixelDistortion.ToolTip"));
            this.checkBoxRefinePixelDistortion.UseVisualStyleBackColor = true;
            // 
            // buttonExecuteRefinements
            // 
            this.buttonExecuteRefinements.BackColor = System.Drawing.Color.SteelBlue;
            resources.ApplyResources(this.buttonExecuteRefinements, "buttonExecuteRefinements");
            this.buttonExecuteRefinements.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonExecuteRefinements.Name = "buttonExecuteRefinements";
            this.toolTipJapanese.SetToolTip(this.buttonExecuteRefinements, resources.GetString("buttonExecuteRefinements.ToolTip"));
            this.buttonExecuteRefinements.UseVisualStyleBackColor = false;
            this.buttonExecuteRefinements.Click += new System.EventHandler(this.buttonExecuteRefinements_Click);
            // 
            // checkBoxSphericalCorrection
            // 
            resources.ApplyResources(this.checkBoxSphericalCorrection, "checkBoxSphericalCorrection");
            this.checkBoxSphericalCorrection.Name = "checkBoxSphericalCorrection";
            this.toolTipJapanese.SetToolTip(this.checkBoxSphericalCorrection, resources.GetString("checkBoxSphericalCorrection.ToolTip"));
            this.checkBoxSphericalCorrection.UseVisualStyleBackColor = true;
            // 
            // checkBoxCenterPosition
            // 
            resources.ApplyResources(this.checkBoxCenterPosition, "checkBoxCenterPosition");
            this.checkBoxCenterPosition.Checked = true;
            this.checkBoxCenterPosition.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxCenterPosition.Name = "checkBoxCenterPosition";
            this.toolTipJapanese.SetToolTip(this.checkBoxCenterPosition, resources.GetString("checkBoxCenterPosition.ToolTip"));
            this.checkBoxCenterPosition.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRepitition
            // 
            resources.ApplyResources(this.numericUpDownRepitition, "numericUpDownRepitition");
            this.numericUpDownRepitition.Name = "numericUpDownRepitition";
            this.toolTipJapanese.SetToolTip(this.numericUpDownRepitition, resources.GetString("numericUpDownRepitition.ToolTip"));
            this.numericUpDownRepitition.Value = new decimal(new int[] {
            12,
            0,
            0,
            0});
            // 
            // checkBoxPeakDecomposition
            // 
            resources.ApplyResources(this.checkBoxPeakDecomposition, "checkBoxPeakDecomposition");
            this.checkBoxPeakDecomposition.Name = "checkBoxPeakDecomposition";
            this.checkBoxPeakDecomposition.CheckedChanged += new System.EventHandler(this.checkBoxShowCrystalParameter_CheckedChanged);
            // 
            // checkBoxMouseOperation
            // 
            resources.ApplyResources(this.checkBoxMouseOperation, "checkBoxMouseOperation");
            this.checkBoxMouseOperation.Name = "checkBoxMouseOperation";
            this.toolTipJapanese.SetToolTip(this.checkBoxMouseOperation, resources.GetString("checkBoxMouseOperation.ToolTip"));
            // 
            // checkBoxRefleshMainform
            // 
            resources.ApplyResources(this.checkBoxRefleshMainform, "checkBoxRefleshMainform");
            this.checkBoxRefleshMainform.Checked = true;
            this.checkBoxRefleshMainform.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxRefleshMainform.Name = "checkBoxRefleshMainform";
            this.toolTipJapanese.SetToolTip(this.checkBoxRefleshMainform, resources.GetString("checkBoxRefleshMainform.ToolTip"));
            // 
            // numericUpDownThresholdOfPeak
            // 
            this.numericUpDownThresholdOfPeak.DecimalPlaces = 2;
            resources.ApplyResources(this.numericUpDownThresholdOfPeak, "numericUpDownThresholdOfPeak");
            this.numericUpDownThresholdOfPeak.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownThresholdOfPeak.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownThresholdOfPeak.Name = "numericUpDownThresholdOfPeak";
            this.toolTipJapanese.SetToolTip(this.numericUpDownThresholdOfPeak, resources.GetString("numericUpDownThresholdOfPeak.ToolTip"));
            this.numericUpDownThresholdOfPeak.ValueChanged += new System.EventHandler(this.numericUpDownThresholdOfPeak_ValueChanged);
            // 
            // numericUpDownDivision
            // 
            resources.ApplyResources(this.numericUpDownDivision, "numericUpDownDivision");
            this.numericUpDownDivision.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.numericUpDownDivision.Minimum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.numericUpDownDivision.Name = "numericUpDownDivision";
            this.numericUpDownDivision.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // label45
            // 
            resources.ApplyResources(this.label45, "label45");
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.Name = "label45";
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.Name = "label21";
            // 
            // label73
            // 
            resources.ApplyResources(this.label73, "label73");
            this.label73.Name = "label73";
            // 
            // label67
            // 
            resources.ApplyResources(this.label67, "label67");
            this.label67.Name = "label67";
            // 
            // label82
            // 
            resources.ApplyResources(this.label82, "label82");
            this.label82.Name = "label82";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // radioButtonRectangle
            // 
            resources.ApplyResources(this.radioButtonRectangle, "radioButtonRectangle");
            this.radioButtonRectangle.Name = "radioButtonRectangle";
            this.radioButtonRectangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonSector
            // 
            resources.ApplyResources(this.radioButtonSector, "radioButtonSector");
            this.radioButtonSector.Checked = true;
            this.radioButtonSector.Name = "radioButtonSector";
            this.radioButtonSector.TabStop = true;
            this.radioButtonSector.UseVisualStyleBackColor = true;
            // 
            // buttonStopRefinements
            // 
            this.buttonStopRefinements.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            resources.ApplyResources(this.buttonStopRefinements, "buttonStopRefinements");
            this.buttonStopRefinements.ForeColor = System.Drawing.Color.White;
            this.buttonStopRefinements.Name = "buttonStopRefinements";
            this.toolTipJapanese.SetToolTip(this.buttonStopRefinements, resources.GetString("buttonStopRefinements.ToolTip"));
            this.buttonStopRefinements.UseVisualStyleBackColor = false;
            this.buttonStopRefinements.Click += new System.EventHandler(this.buttonStopRefinements_Click);
            // 
            // buttonSetInitioalParam
            // 
            resources.ApplyResources(this.buttonSetInitioalParam, "buttonSetInitioalParam");
            this.buttonSetInitioalParam.Name = "buttonSetInitioalParam";
            this.buttonSetInitioalParam.Click += new System.EventHandler(this.buttonSetInitioalParam_Click);
            // 
            // buttonSendMainForm
            // 
            resources.ApplyResources(this.buttonSendMainForm, "buttonSendMainForm");
            this.buttonSendMainForm.Name = "buttonSendMainForm";
            this.buttonSendMainForm.Click += new System.EventHandler(this.buttonSendMainForm_Click);
            // 
            // groupBoxParameter
            // 
            this.groupBoxParameter.Controls.Add(this.textBoxPixelKsi);
            this.groupBoxParameter.Controls.Add(this.textBoxTiltCorrectionSecondaryTau);
            this.groupBoxParameter.Controls.Add(this.textBoxTiltCorrectionPrimaryTau);
            this.groupBoxParameter.Controls.Add(this.numericalTextBoxSphericalRadius);
            this.groupBoxParameter.Controls.Add(this.textBoxTiltCorrectionSecondaryPhi);
            this.groupBoxParameter.Controls.Add(this.textBoxTiltCorrectionPrimaryPhi);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPixelKsiDev);
            this.groupBoxParameter.Controls.Add(this.buttonSetInitioalParam);
            this.groupBoxParameter.Controls.Add(this.label68);
            this.groupBoxParameter.Controls.Add(this.buttonCopyToClipboard);
            this.groupBoxParameter.Controls.Add(this.buttonSendMainForm);
            this.groupBoxParameter.Controls.Add(this.label34);
            this.groupBoxParameter.Controls.Add(this.textBoxWaveLengthDev);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPixelKsi);
            this.groupBoxParameter.Controls.Add(this.label15);
            this.groupBoxParameter.Controls.Add(this.label32);
            this.groupBoxParameter.Controls.Add(this.label70);
            this.groupBoxParameter.Controls.Add(this.textBoxPrimaryFilmDistanceCopy2);
            this.groupBoxParameter.Controls.Add(this.numericalTextBoxRadiusInverseDev);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedSecondaryTauDev);
            this.groupBoxParameter.Controls.Add(this.textBoxPixelSizeYDev);
            this.groupBoxParameter.Controls.Add(this.textBoxWaveLength);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPixelSizeY);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPrimaryTauDev);
            this.groupBoxParameter.Controls.Add(this.textBoxPixelSizeY);
            this.groupBoxParameter.Controls.Add(this.label1);
            this.groupBoxParameter.Controls.Add(this.label40);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedSecondaryPhiDev);
            this.groupBoxParameter.Controls.Add(this.label41);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPrimaryFilmDistance);
            this.groupBoxParameter.Controls.Add(this.label13);
            this.groupBoxParameter.Controls.Add(this.label19);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPrimaryPhiDev);
            this.groupBoxParameter.Controls.Add(this.textBoxPixelSizeX);
            this.groupBoxParameter.Controls.Add(this.label46);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedWaveLength);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPixelSizeX);
            this.groupBoxParameter.Controls.Add(this.numericalTextBoxRefinedSphericalRadius);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedSecondaryTau);
            this.groupBoxParameter.Controls.Add(this.label24);
            this.groupBoxParameter.Controls.Add(this.label20);
            this.groupBoxParameter.Controls.Add(this.textBoxPixelSizeXDev);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPrimaryTau);
            this.groupBoxParameter.Controls.Add(this.label44);
            this.groupBoxParameter.Controls.Add(this.label35);
            this.groupBoxParameter.Controls.Add(this.label6);
            this.groupBoxParameter.Controls.Add(this.label69);
            this.groupBoxParameter.Controls.Add(this.label33);
            this.groupBoxParameter.Controls.Add(this.label63);
            this.groupBoxParameter.Controls.Add(this.label48);
            this.groupBoxParameter.Controls.Add(this.label39);
            this.groupBoxParameter.Controls.Add(this.label7);
            this.groupBoxParameter.Controls.Add(this.label81);
            this.groupBoxParameter.Controls.Add(this.label62);
            this.groupBoxParameter.Controls.Add(this.label38);
            this.groupBoxParameter.Controls.Add(this.textBoxCameraLengthDev);
            this.groupBoxParameter.Controls.Add(this.label14);
            this.groupBoxParameter.Controls.Add(this.label22);
            this.groupBoxParameter.Controls.Add(this.label25);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedSecondaryPhi);
            this.groupBoxParameter.Controls.Add(this.label42);
            this.groupBoxParameter.Controls.Add(this.textBoxRefinedPrimaryPhi);
            this.groupBoxParameter.Controls.Add(this.label36);
            this.groupBoxParameter.Controls.Add(this.label61);
            this.groupBoxParameter.Controls.Add(this.label49);
            this.groupBoxParameter.Controls.Add(this.label30);
            this.groupBoxParameter.Controls.Add(this.label66);
            this.groupBoxParameter.Controls.Add(this.label65);
            this.groupBoxParameter.Controls.Add(this.label64);
            this.groupBoxParameter.Controls.Add(this.label75);
            this.groupBoxParameter.Controls.Add(this.label71);
            this.groupBoxParameter.Controls.Add(this.label18);
            resources.ApplyResources(this.groupBoxParameter, "groupBoxParameter");
            this.groupBoxParameter.Name = "groupBoxParameter";
            this.groupBoxParameter.TabStop = false;
            this.groupBoxParameter.DragDrop += new System.Windows.Forms.DragEventHandler(this.groupBoxParameter_DragDrop);
            this.groupBoxParameter.DragEnter += new System.Windows.Forms.DragEventHandler(this.groupBoxParameter_DragEnter);
            // 
            // textBoxPixelKsi
            // 
            resources.ApplyResources(this.textBoxPixelKsi, "textBoxPixelKsi");
            this.textBoxPixelKsi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelKsi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelKsi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelKsi.Name = "textBoxPixelKsi";
            this.textBoxPixelKsi.RoundErrorAccuracy = -1;
            this.textBoxPixelKsi.SkipEventDuringInput = false;
            this.textBoxPixelKsi.SmartIncrement = true;
            this.textBoxPixelKsi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPixelKsi.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxPixelKsi, resources.GetString("textBoxPixelKsi.ToolTip"));
            this.textBoxPixelKsi.WordWrap = false;
            this.textBoxPixelKsi.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxPixelKsi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxTiltCorrectionSecondaryTau
            // 
            resources.ApplyResources(this.textBoxTiltCorrectionSecondaryTau, "textBoxTiltCorrectionSecondaryTau");
            this.textBoxTiltCorrectionSecondaryTau.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryTau.Name = "textBoxTiltCorrectionSecondaryTau";
            this.textBoxTiltCorrectionSecondaryTau.RoundErrorAccuracy = -1;
            this.textBoxTiltCorrectionSecondaryTau.SkipEventDuringInput = false;
            this.textBoxTiltCorrectionSecondaryTau.SmartIncrement = true;
            this.textBoxTiltCorrectionSecondaryTau.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTiltCorrectionSecondaryTau.ThonsandsSeparator = true;
            this.textBoxTiltCorrectionSecondaryTau.WordWrap = false;
            this.textBoxTiltCorrectionSecondaryTau.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxTiltCorrectionSecondaryTau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxTiltCorrectionPrimaryTau
            // 
            resources.ApplyResources(this.textBoxTiltCorrectionPrimaryTau, "textBoxTiltCorrectionPrimaryTau");
            this.textBoxTiltCorrectionPrimaryTau.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryTau.Name = "textBoxTiltCorrectionPrimaryTau";
            this.textBoxTiltCorrectionPrimaryTau.RoundErrorAccuracy = -1;
            this.textBoxTiltCorrectionPrimaryTau.SkipEventDuringInput = false;
            this.textBoxTiltCorrectionPrimaryTau.SmartIncrement = true;
            this.textBoxTiltCorrectionPrimaryTau.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTiltCorrectionPrimaryTau.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxTiltCorrectionPrimaryTau, resources.GetString("textBoxTiltCorrectionPrimaryTau.ToolTip"));
            this.textBoxTiltCorrectionPrimaryTau.WordWrap = false;
            this.textBoxTiltCorrectionPrimaryTau.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxTiltCorrectionPrimaryTau.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // numericalTextBoxSphericalRadius
            // 
            resources.ApplyResources(this.numericalTextBoxSphericalRadius, "numericalTextBoxSphericalRadius");
            this.numericalTextBoxSphericalRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxSphericalRadius.Name = "numericalTextBoxSphericalRadius";
            this.numericalTextBoxSphericalRadius.RoundErrorAccuracy = -1;
            this.numericalTextBoxSphericalRadius.SkipEventDuringInput = false;
            this.numericalTextBoxSphericalRadius.SmartIncrement = true;
            this.numericalTextBoxSphericalRadius.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxSphericalRadius.ThonsandsSeparator = true;
            this.numericalTextBoxSphericalRadius.WordWrap = false;
            this.numericalTextBoxSphericalRadius.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.numericalTextBoxSphericalRadius.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxTiltCorrectionSecondaryPhi
            // 
            resources.ApplyResources(this.textBoxTiltCorrectionSecondaryPhi, "textBoxTiltCorrectionSecondaryPhi");
            this.textBoxTiltCorrectionSecondaryPhi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionSecondaryPhi.Name = "textBoxTiltCorrectionSecondaryPhi";
            this.textBoxTiltCorrectionSecondaryPhi.RoundErrorAccuracy = -1;
            this.textBoxTiltCorrectionSecondaryPhi.SkipEventDuringInput = false;
            this.textBoxTiltCorrectionSecondaryPhi.SmartIncrement = true;
            this.textBoxTiltCorrectionSecondaryPhi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTiltCorrectionSecondaryPhi.ThonsandsSeparator = true;
            this.textBoxTiltCorrectionSecondaryPhi.WordWrap = false;
            this.textBoxTiltCorrectionSecondaryPhi.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxTiltCorrectionSecondaryPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxTiltCorrectionPrimaryPhi
            // 
            resources.ApplyResources(this.textBoxTiltCorrectionPrimaryPhi, "textBoxTiltCorrectionPrimaryPhi");
            this.textBoxTiltCorrectionPrimaryPhi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxTiltCorrectionPrimaryPhi.Name = "textBoxTiltCorrectionPrimaryPhi";
            this.textBoxTiltCorrectionPrimaryPhi.RoundErrorAccuracy = -1;
            this.textBoxTiltCorrectionPrimaryPhi.SkipEventDuringInput = false;
            this.textBoxTiltCorrectionPrimaryPhi.SmartIncrement = true;
            this.textBoxTiltCorrectionPrimaryPhi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxTiltCorrectionPrimaryPhi.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxTiltCorrectionPrimaryPhi, resources.GetString("textBoxTiltCorrectionPrimaryPhi.ToolTip"));
            this.textBoxTiltCorrectionPrimaryPhi.WordWrap = false;
            this.textBoxTiltCorrectionPrimaryPhi.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxTiltCorrectionPrimaryPhi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxRefinedPixelKsiDev
            // 
            resources.ApplyResources(this.textBoxRefinedPixelKsiDev, "textBoxRefinedPixelKsiDev");
            this.textBoxRefinedPixelKsiDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsiDev.DecimalPlaces = 10;
            this.textBoxRefinedPixelKsiDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsiDev.Name = "textBoxRefinedPixelKsiDev";
            this.textBoxRefinedPixelKsiDev.ReadOnly = true;
            this.textBoxRefinedPixelKsiDev.RoundErrorAccuracy = -1;
            this.textBoxRefinedPixelKsiDev.SkipEventDuringInput = false;
            this.textBoxRefinedPixelKsiDev.SmartIncrement = true;
            this.textBoxRefinedPixelKsiDev.TabStop = false;
            this.textBoxRefinedPixelKsiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsiDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPixelKsiDev.ThonsandsSeparator = true;
            this.textBoxRefinedPixelKsiDev.WordWrap = false;
            // 
            // label68
            // 
            resources.ApplyResources(this.label68, "label68");
            this.label68.Name = "label68";
            // 
            // buttonCopyToClipboard
            // 
            resources.ApplyResources(this.buttonCopyToClipboard, "buttonCopyToClipboard");
            this.buttonCopyToClipboard.Name = "buttonCopyToClipboard";
            this.buttonCopyToClipboard.Click += new System.EventHandler(this.buttonCopyToClipboard_Click);
            // 
            // label34
            // 
            resources.ApplyResources(this.label34, "label34");
            this.label34.Name = "label34";
            // 
            // textBoxWaveLengthDev
            // 
            resources.ApplyResources(this.textBoxWaveLengthDev, "textBoxWaveLengthDev");
            this.textBoxWaveLengthDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLengthDev.DecimalPlaces = 10;
            this.textBoxWaveLengthDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLengthDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLengthDev.Name = "textBoxWaveLengthDev";
            this.textBoxWaveLengthDev.ReadOnly = true;
            this.textBoxWaveLengthDev.RoundErrorAccuracy = -1;
            this.textBoxWaveLengthDev.SkipEventDuringInput = false;
            this.textBoxWaveLengthDev.SmartIncrement = true;
            this.textBoxWaveLengthDev.TabStop = false;
            this.textBoxWaveLengthDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLengthDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxWaveLengthDev.ThonsandsSeparator = true;
            this.textBoxWaveLengthDev.WordWrap = false;
            // 
            // textBoxRefinedPixelKsi
            // 
            resources.ApplyResources(this.textBoxRefinedPixelKsi, "textBoxRefinedPixelKsi");
            this.textBoxRefinedPixelKsi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsi.Name = "textBoxRefinedPixelKsi";
            this.textBoxRefinedPixelKsi.ReadOnly = true;
            this.textBoxRefinedPixelKsi.RoundErrorAccuracy = -1;
            this.textBoxRefinedPixelKsi.SkipEventDuringInput = false;
            this.textBoxRefinedPixelKsi.SmartIncrement = true;
            this.textBoxRefinedPixelKsi.TabStop = false;
            this.textBoxRefinedPixelKsi.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelKsi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPixelKsi.ThonsandsSeparator = true;
            this.textBoxRefinedPixelKsi.WordWrap = false;
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label32
            // 
            resources.ApplyResources(this.label32, "label32");
            this.label32.Name = "label32";
            // 
            // label70
            // 
            resources.ApplyResources(this.label70, "label70");
            this.label70.Name = "label70";
            // 
            // textBoxPrimaryFilmDistanceCopy2
            // 
            resources.ApplyResources(this.textBoxPrimaryFilmDistanceCopy2, "textBoxPrimaryFilmDistanceCopy2");
            this.textBoxPrimaryFilmDistanceCopy2.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy2.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy2.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy2.Name = "textBoxPrimaryFilmDistanceCopy2";
            this.textBoxPrimaryFilmDistanceCopy2.RadianValue = 7.7667151713747664D;
            this.textBoxPrimaryFilmDistanceCopy2.ReadOnly = true;
            this.textBoxPrimaryFilmDistanceCopy2.RoundErrorAccuracy = -1;
            this.textBoxPrimaryFilmDistanceCopy2.SkipEventDuringInput = false;
            this.textBoxPrimaryFilmDistanceCopy2.SmartIncrement = true;
            this.textBoxPrimaryFilmDistanceCopy2.TabStop = false;
            this.textBoxPrimaryFilmDistanceCopy2.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPrimaryFilmDistanceCopy2.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPrimaryFilmDistanceCopy2.ThonsandsSeparator = true;
            this.textBoxPrimaryFilmDistanceCopy2.Value = 445D;
            this.textBoxPrimaryFilmDistanceCopy2.WordWrap = false;
            // 
            // numericalTextBoxRadiusInverseDev
            // 
            resources.ApplyResources(this.numericalTextBoxRadiusInverseDev, "numericalTextBoxRadiusInverseDev");
            this.numericalTextBoxRadiusInverseDev.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRadiusInverseDev.DecimalPlaces = 10;
            this.numericalTextBoxRadiusInverseDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRadiusInverseDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRadiusInverseDev.Name = "numericalTextBoxRadiusInverseDev";
            this.numericalTextBoxRadiusInverseDev.ReadOnly = true;
            this.numericalTextBoxRadiusInverseDev.RoundErrorAccuracy = -1;
            this.numericalTextBoxRadiusInverseDev.SkipEventDuringInput = false;
            this.numericalTextBoxRadiusInverseDev.SmartIncrement = true;
            this.numericalTextBoxRadiusInverseDev.TabStop = false;
            this.numericalTextBoxRadiusInverseDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRadiusInverseDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxRadiusInverseDev.ThonsandsSeparator = true;
            this.numericalTextBoxRadiusInverseDev.WordWrap = false;
            // 
            // textBoxRefinedSecondaryTauDev
            // 
            resources.ApplyResources(this.textBoxRefinedSecondaryTauDev, "textBoxRefinedSecondaryTauDev");
            this.textBoxRefinedSecondaryTauDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTauDev.DecimalPlaces = 10;
            this.textBoxRefinedSecondaryTauDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTauDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTauDev.Name = "textBoxRefinedSecondaryTauDev";
            this.textBoxRefinedSecondaryTauDev.ReadOnly = true;
            this.textBoxRefinedSecondaryTauDev.RoundErrorAccuracy = -1;
            this.textBoxRefinedSecondaryTauDev.SkipEventDuringInput = false;
            this.textBoxRefinedSecondaryTauDev.SmartIncrement = true;
            this.textBoxRefinedSecondaryTauDev.TabStop = false;
            this.textBoxRefinedSecondaryTauDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTauDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedSecondaryTauDev.ThonsandsSeparator = true;
            this.textBoxRefinedSecondaryTauDev.WordWrap = false;
            // 
            // textBoxPixelSizeYDev
            // 
            resources.ApplyResources(this.textBoxPixelSizeYDev, "textBoxPixelSizeYDev");
            this.textBoxPixelSizeYDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeYDev.DecimalPlaces = 10;
            this.textBoxPixelSizeYDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeYDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeYDev.Name = "textBoxPixelSizeYDev";
            this.textBoxPixelSizeYDev.ReadOnly = true;
            this.textBoxPixelSizeYDev.RoundErrorAccuracy = -1;
            this.textBoxPixelSizeYDev.SkipEventDuringInput = false;
            this.textBoxPixelSizeYDev.SmartIncrement = true;
            this.textBoxPixelSizeYDev.TabStop = false;
            this.textBoxPixelSizeYDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeYDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPixelSizeYDev.ThonsandsSeparator = true;
            this.textBoxPixelSizeYDev.WordWrap = false;
            // 
            // textBoxWaveLength
            // 
            resources.ApplyResources(this.textBoxWaveLength, "textBoxWaveLength");
            this.textBoxWaveLength.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLength.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLength.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxWaveLength.Name = "textBoxWaveLength";
            this.textBoxWaveLength.RadianValue = 0.0069813170079773184D;
            this.textBoxWaveLength.RoundErrorAccuracy = -1;
            this.textBoxWaveLength.SkipEventDuringInput = false;
            this.textBoxWaveLength.SmartIncrement = true;
            this.textBoxWaveLength.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxWaveLength.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxWaveLength, resources.GetString("textBoxWaveLength.ToolTip"));
            this.textBoxWaveLength.Value = 0.4D;
            this.textBoxWaveLength.WordWrap = false;
            this.textBoxWaveLength.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.textBox_TextChanged);
            this.textBoxWaveLength.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxWaveLength.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxRefinedPixelSizeY
            // 
            resources.ApplyResources(this.textBoxRefinedPixelSizeY, "textBoxRefinedPixelSizeY");
            this.textBoxRefinedPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeY.Name = "textBoxRefinedPixelSizeY";
            this.textBoxRefinedPixelSizeY.RadianValue = 0.0017453292519943296D;
            this.textBoxRefinedPixelSizeY.ReadOnly = true;
            this.textBoxRefinedPixelSizeY.RoundErrorAccuracy = -1;
            this.textBoxRefinedPixelSizeY.SkipEventDuringInput = false;
            this.textBoxRefinedPixelSizeY.SmartIncrement = true;
            this.textBoxRefinedPixelSizeY.TabStop = false;
            this.textBoxRefinedPixelSizeY.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeY.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPixelSizeY.ThonsandsSeparator = true;
            this.textBoxRefinedPixelSizeY.Value = 0.1D;
            this.textBoxRefinedPixelSizeY.WordWrap = false;
            // 
            // textBoxRefinedPrimaryTauDev
            // 
            resources.ApplyResources(this.textBoxRefinedPrimaryTauDev, "textBoxRefinedPrimaryTauDev");
            this.textBoxRefinedPrimaryTauDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTauDev.DecimalPlaces = 10;
            this.textBoxRefinedPrimaryTauDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTauDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTauDev.Name = "textBoxRefinedPrimaryTauDev";
            this.textBoxRefinedPrimaryTauDev.ReadOnly = true;
            this.textBoxRefinedPrimaryTauDev.RoundErrorAccuracy = -1;
            this.textBoxRefinedPrimaryTauDev.SkipEventDuringInput = false;
            this.textBoxRefinedPrimaryTauDev.SmartIncrement = true;
            this.textBoxRefinedPrimaryTauDev.TabStop = false;
            this.textBoxRefinedPrimaryTauDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTauDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPrimaryTauDev.ThonsandsSeparator = true;
            this.textBoxRefinedPrimaryTauDev.WordWrap = false;
            // 
            // textBoxPixelSizeY
            // 
            resources.ApplyResources(this.textBoxPixelSizeY, "textBoxPixelSizeY");
            this.textBoxPixelSizeY.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeY.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeY.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeY.Name = "textBoxPixelSizeY";
            this.textBoxPixelSizeY.RadianValue = 0.0017453292519943296D;
            this.textBoxPixelSizeY.RoundErrorAccuracy = -1;
            this.textBoxPixelSizeY.SkipEventDuringInput = false;
            this.textBoxPixelSizeY.SmartIncrement = true;
            this.textBoxPixelSizeY.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPixelSizeY.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxPixelSizeY, resources.GetString("textBoxPixelSizeY.ToolTip"));
            this.textBoxPixelSizeY.Value = 0.1D;
            this.textBoxPixelSizeY.WordWrap = false;
            this.textBoxPixelSizeY.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            this.textBoxPixelSizeY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxNumOnly_KeyPress);
            // 
            // textBoxRefinedSecondaryPhiDev
            // 
            resources.ApplyResources(this.textBoxRefinedSecondaryPhiDev, "textBoxRefinedSecondaryPhiDev");
            this.textBoxRefinedSecondaryPhiDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhiDev.DecimalPlaces = 10;
            this.textBoxRefinedSecondaryPhiDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhiDev.Name = "textBoxRefinedSecondaryPhiDev";
            this.textBoxRefinedSecondaryPhiDev.ReadOnly = true;
            this.textBoxRefinedSecondaryPhiDev.RoundErrorAccuracy = -1;
            this.textBoxRefinedSecondaryPhiDev.SkipEventDuringInput = false;
            this.textBoxRefinedSecondaryPhiDev.SmartIncrement = true;
            this.textBoxRefinedSecondaryPhiDev.TabStop = false;
            this.textBoxRefinedSecondaryPhiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhiDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedSecondaryPhiDev.ThonsandsSeparator = true;
            this.textBoxRefinedSecondaryPhiDev.WordWrap = false;
            // 
            // label41
            // 
            resources.ApplyResources(this.label41, "label41");
            this.label41.Name = "label41";
            // 
            // textBoxRefinedPrimaryFilmDistance
            // 
            resources.ApplyResources(this.textBoxRefinedPrimaryFilmDistance, "textBoxRefinedPrimaryFilmDistance");
            this.textBoxRefinedPrimaryFilmDistance.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryFilmDistance.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryFilmDistance.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryFilmDistance.Name = "textBoxRefinedPrimaryFilmDistance";
            this.textBoxRefinedPrimaryFilmDistance.RadianValue = 6.9813170079773181D;
            this.textBoxRefinedPrimaryFilmDistance.ReadOnly = true;
            this.textBoxRefinedPrimaryFilmDistance.RoundErrorAccuracy = -1;
            this.textBoxRefinedPrimaryFilmDistance.SkipEventDuringInput = false;
            this.textBoxRefinedPrimaryFilmDistance.SmartIncrement = true;
            this.textBoxRefinedPrimaryFilmDistance.TabStop = false;
            this.textBoxRefinedPrimaryFilmDistance.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryFilmDistance.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPrimaryFilmDistance.ThonsandsSeparator = true;
            this.textBoxRefinedPrimaryFilmDistance.Value = 400D;
            this.textBoxRefinedPrimaryFilmDistance.WordWrap = false;
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            // 
            // textBoxRefinedPrimaryPhiDev
            // 
            resources.ApplyResources(this.textBoxRefinedPrimaryPhiDev, "textBoxRefinedPrimaryPhiDev");
            this.textBoxRefinedPrimaryPhiDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhiDev.DecimalPlaces = 10;
            this.textBoxRefinedPrimaryPhiDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhiDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhiDev.Name = "textBoxRefinedPrimaryPhiDev";
            this.textBoxRefinedPrimaryPhiDev.ReadOnly = true;
            this.textBoxRefinedPrimaryPhiDev.RoundErrorAccuracy = -1;
            this.textBoxRefinedPrimaryPhiDev.SkipEventDuringInput = false;
            this.textBoxRefinedPrimaryPhiDev.SmartIncrement = true;
            this.textBoxRefinedPrimaryPhiDev.TabStop = false;
            this.textBoxRefinedPrimaryPhiDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhiDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPrimaryPhiDev.ThonsandsSeparator = true;
            this.textBoxRefinedPrimaryPhiDev.WordWrap = false;
            // 
            // textBoxPixelSizeX
            // 
            resources.ApplyResources(this.textBoxPixelSizeX, "textBoxPixelSizeX");
            this.textBoxPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeX.Name = "textBoxPixelSizeX";
            this.textBoxPixelSizeX.RadianValue = 0.0017453292519943296D;
            this.textBoxPixelSizeX.RoundErrorAccuracy = -1;
            this.textBoxPixelSizeX.SkipEventDuringInput = false;
            this.textBoxPixelSizeX.SmartIncrement = true;
            this.textBoxPixelSizeX.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPixelSizeX.ThonsandsSeparator = true;
            this.toolTipJapanese.SetToolTip(this.textBoxPixelSizeX, resources.GetString("textBoxPixelSizeX.ToolTip"));
            this.textBoxPixelSizeX.Value = 0.1D;
            this.textBoxPixelSizeX.WordWrap = false;
            // 
            // textBoxRefinedWaveLength
            // 
            resources.ApplyResources(this.textBoxRefinedWaveLength, "textBoxRefinedWaveLength");
            this.textBoxRefinedWaveLength.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedWaveLength.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedWaveLength.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedWaveLength.Name = "textBoxRefinedWaveLength";
            this.textBoxRefinedWaveLength.RadianValue = 0.0069813170079773184D;
            this.textBoxRefinedWaveLength.ReadOnly = true;
            this.textBoxRefinedWaveLength.RoundErrorAccuracy = -1;
            this.textBoxRefinedWaveLength.SkipEventDuringInput = false;
            this.textBoxRefinedWaveLength.SmartIncrement = true;
            this.textBoxRefinedWaveLength.TabStop = false;
            this.textBoxRefinedWaveLength.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedWaveLength.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedWaveLength.ThonsandsSeparator = true;
            this.textBoxRefinedWaveLength.Value = 0.4D;
            this.textBoxRefinedWaveLength.WordWrap = false;
            // 
            // textBoxRefinedPixelSizeX
            // 
            resources.ApplyResources(this.textBoxRefinedPixelSizeX, "textBoxRefinedPixelSizeX");
            this.textBoxRefinedPixelSizeX.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeX.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeX.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeX.Name = "textBoxRefinedPixelSizeX";
            this.textBoxRefinedPixelSizeX.RadianValue = 0.0017453292519943296D;
            this.textBoxRefinedPixelSizeX.ReadOnly = true;
            this.textBoxRefinedPixelSizeX.RoundErrorAccuracy = -1;
            this.textBoxRefinedPixelSizeX.SkipEventDuringInput = false;
            this.textBoxRefinedPixelSizeX.SmartIncrement = true;
            this.textBoxRefinedPixelSizeX.TabStop = false;
            this.textBoxRefinedPixelSizeX.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPixelSizeX.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPixelSizeX.ThonsandsSeparator = true;
            this.textBoxRefinedPixelSizeX.Value = 0.1D;
            this.textBoxRefinedPixelSizeX.WordWrap = false;
            // 
            // numericalTextBoxRefinedSphericalRadius
            // 
            resources.ApplyResources(this.numericalTextBoxRefinedSphericalRadius, "numericalTextBoxRefinedSphericalRadius");
            this.numericalTextBoxRefinedSphericalRadius.BackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRefinedSphericalRadius.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRefinedSphericalRadius.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRefinedSphericalRadius.Name = "numericalTextBoxRefinedSphericalRadius";
            this.numericalTextBoxRefinedSphericalRadius.ReadOnly = true;
            this.numericalTextBoxRefinedSphericalRadius.RoundErrorAccuracy = -1;
            this.numericalTextBoxRefinedSphericalRadius.SkipEventDuringInput = false;
            this.numericalTextBoxRefinedSphericalRadius.SmartIncrement = true;
            this.numericalTextBoxRefinedSphericalRadius.TabStop = false;
            this.numericalTextBoxRefinedSphericalRadius.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.numericalTextBoxRefinedSphericalRadius.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericalTextBoxRefinedSphericalRadius.ThonsandsSeparator = true;
            this.numericalTextBoxRefinedSphericalRadius.WordWrap = false;
            // 
            // textBoxRefinedSecondaryTau
            // 
            resources.ApplyResources(this.textBoxRefinedSecondaryTau, "textBoxRefinedSecondaryTau");
            this.textBoxRefinedSecondaryTau.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTau.Name = "textBoxRefinedSecondaryTau";
            this.textBoxRefinedSecondaryTau.ReadOnly = true;
            this.textBoxRefinedSecondaryTau.RoundErrorAccuracy = -1;
            this.textBoxRefinedSecondaryTau.SkipEventDuringInput = false;
            this.textBoxRefinedSecondaryTau.SmartIncrement = true;
            this.textBoxRefinedSecondaryTau.TabStop = false;
            this.textBoxRefinedSecondaryTau.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryTau.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedSecondaryTau.ThonsandsSeparator = true;
            this.textBoxRefinedSecondaryTau.WordWrap = false;
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // textBoxPixelSizeXDev
            // 
            resources.ApplyResources(this.textBoxPixelSizeXDev, "textBoxPixelSizeXDev");
            this.textBoxPixelSizeXDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeXDev.DecimalPlaces = 10;
            this.textBoxPixelSizeXDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeXDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeXDev.Name = "textBoxPixelSizeXDev";
            this.textBoxPixelSizeXDev.ReadOnly = true;
            this.textBoxPixelSizeXDev.RoundErrorAccuracy = -1;
            this.textBoxPixelSizeXDev.SkipEventDuringInput = false;
            this.textBoxPixelSizeXDev.SmartIncrement = true;
            this.textBoxPixelSizeXDev.TabStop = false;
            this.textBoxPixelSizeXDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxPixelSizeXDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxPixelSizeXDev.ThonsandsSeparator = true;
            this.textBoxPixelSizeXDev.WordWrap = false;
            // 
            // textBoxRefinedPrimaryTau
            // 
            resources.ApplyResources(this.textBoxRefinedPrimaryTau, "textBoxRefinedPrimaryTau");
            this.textBoxRefinedPrimaryTau.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTau.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTau.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTau.Name = "textBoxRefinedPrimaryTau";
            this.textBoxRefinedPrimaryTau.ReadOnly = true;
            this.textBoxRefinedPrimaryTau.RoundErrorAccuracy = -1;
            this.textBoxRefinedPrimaryTau.SkipEventDuringInput = false;
            this.textBoxRefinedPrimaryTau.SmartIncrement = true;
            this.textBoxRefinedPrimaryTau.TabStop = false;
            this.textBoxRefinedPrimaryTau.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryTau.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPrimaryTau.ThonsandsSeparator = true;
            this.textBoxRefinedPrimaryTau.WordWrap = false;
            // 
            // label44
            // 
            resources.ApplyResources(this.label44, "label44");
            this.label44.Name = "label44";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label69
            // 
            resources.ApplyResources(this.label69, "label69");
            this.label69.Name = "label69";
            // 
            // label33
            // 
            resources.ApplyResources(this.label33, "label33");
            this.label33.Name = "label33";
            // 
            // label63
            // 
            resources.ApplyResources(this.label63, "label63");
            this.label63.Name = "label63";
            // 
            // label39
            // 
            resources.ApplyResources(this.label39, "label39");
            this.label39.Name = "label39";
            // 
            // label81
            // 
            resources.ApplyResources(this.label81, "label81");
            this.label81.Name = "label81";
            // 
            // label62
            // 
            resources.ApplyResources(this.label62, "label62");
            this.label62.Name = "label62";
            // 
            // textBoxCameraLengthDev
            // 
            resources.ApplyResources(this.textBoxCameraLengthDev, "textBoxCameraLengthDev");
            this.textBoxCameraLengthDev.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxCameraLengthDev.DecimalPlaces = 10;
            this.textBoxCameraLengthDev.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxCameraLengthDev.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxCameraLengthDev.Name = "textBoxCameraLengthDev";
            this.textBoxCameraLengthDev.ReadOnly = true;
            this.textBoxCameraLengthDev.RoundErrorAccuracy = -1;
            this.textBoxCameraLengthDev.SkipEventDuringInput = false;
            this.textBoxCameraLengthDev.SmartIncrement = true;
            this.textBoxCameraLengthDev.TabStop = false;
            this.textBoxCameraLengthDev.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxCameraLengthDev.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxCameraLengthDev.ThonsandsSeparator = true;
            this.textBoxCameraLengthDev.WordWrap = false;
            // 
            // label22
            // 
            resources.ApplyResources(this.label22, "label22");
            this.label22.Name = "label22";
            // 
            // textBoxRefinedSecondaryPhi
            // 
            resources.ApplyResources(this.textBoxRefinedSecondaryPhi, "textBoxRefinedSecondaryPhi");
            this.textBoxRefinedSecondaryPhi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhi.Name = "textBoxRefinedSecondaryPhi";
            this.textBoxRefinedSecondaryPhi.ReadOnly = true;
            this.textBoxRefinedSecondaryPhi.RoundErrorAccuracy = -1;
            this.textBoxRefinedSecondaryPhi.SkipEventDuringInput = false;
            this.textBoxRefinedSecondaryPhi.SmartIncrement = true;
            this.textBoxRefinedSecondaryPhi.TabStop = false;
            this.textBoxRefinedSecondaryPhi.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedSecondaryPhi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedSecondaryPhi.ThonsandsSeparator = true;
            this.textBoxRefinedSecondaryPhi.WordWrap = false;
            // 
            // label42
            // 
            resources.ApplyResources(this.label42, "label42");
            this.label42.Name = "label42";
            // 
            // textBoxRefinedPrimaryPhi
            // 
            resources.ApplyResources(this.textBoxRefinedPrimaryPhi, "textBoxRefinedPrimaryPhi");
            this.textBoxRefinedPrimaryPhi.BackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhi.FooterBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhi.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhi.Name = "textBoxRefinedPrimaryPhi";
            this.textBoxRefinedPrimaryPhi.ReadOnly = true;
            this.textBoxRefinedPrimaryPhi.RoundErrorAccuracy = -1;
            this.textBoxRefinedPrimaryPhi.SkipEventDuringInput = false;
            this.textBoxRefinedPrimaryPhi.SmartIncrement = true;
            this.textBoxRefinedPrimaryPhi.TabStop = false;
            this.textBoxRefinedPrimaryPhi.TextBoxBackColor = System.Drawing.SystemColors.Control;
            this.textBoxRefinedPrimaryPhi.TextFont = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.textBoxRefinedPrimaryPhi.ThonsandsSeparator = true;
            this.textBoxRefinedPrimaryPhi.WordWrap = false;
            // 
            // label61
            // 
            resources.ApplyResources(this.label61, "label61");
            this.label61.Name = "label61";
            // 
            // label49
            // 
            resources.ApplyResources(this.label49, "label49");
            this.label49.Name = "label49";
            // 
            // label30
            // 
            resources.ApplyResources(this.label30, "label30");
            this.label30.Name = "label30";
            // 
            // label66
            // 
            resources.ApplyResources(this.label66, "label66");
            this.label66.Name = "label66";
            // 
            // label65
            // 
            resources.ApplyResources(this.label65, "label65");
            this.label65.Name = "label65";
            // 
            // label64
            // 
            resources.ApplyResources(this.label64, "label64");
            this.label64.Name = "label64";
            // 
            // label75
            // 
            resources.ApplyResources(this.label75, "label75");
            this.label75.Name = "label75";
            // 
            // label71
            // 
            resources.ApplyResources(this.label71, "label71");
            this.label71.Name = "label71";
            // 
            // backgroundWorkerRefine
            // 
            this.backgroundWorkerRefine.WorkerReportsProgress = true;
            this.backgroundWorkerRefine.WorkerSupportsCancellation = true;
            this.backgroundWorkerRefine.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorkerRefine_DoWork);
            this.backgroundWorkerRefine.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorkerRefine_ProgressChanged);
            this.backgroundWorkerRefine.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorkerRefine_RunWorkerCompleted);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButton1);
            this.flowLayoutPanel1.Controls.Add(this.radioButton2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButton1
            // 
            resources.ApplyResources(this.radioButton1, "radioButton1");
            this.radioButton1.Checked = true;
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.TabStop = true;
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            resources.ApplyResources(this.radioButton2, "radioButton2");
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // buttonGetWaveLengthFromWholePattern
            // 
            resources.ApplyResources(this.buttonGetWaveLengthFromWholePattern, "buttonGetWaveLengthFromWholePattern");
            this.buttonGetWaveLengthFromWholePattern.Name = "buttonGetWaveLengthFromWholePattern";
            this.buttonGetWaveLengthFromWholePattern.Click += new System.EventHandler(this.buttonGetWaveLengthFromWholePattern_Click);
            // 
            // buttonGetCameraLenghtFromWholePattern
            // 
            resources.ApplyResources(this.buttonGetCameraLenghtFromWholePattern, "buttonGetCameraLenghtFromWholePattern");
            this.buttonGetCameraLenghtFromWholePattern.Name = "buttonGetCameraLenghtFromWholePattern";
            this.buttonGetCameraLenghtFromWholePattern.Click += new System.EventHandler(this.buttonGetCameraLenghtFromWholePattern_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AllowUserToResizeColumns = false;
            this.dataGridView.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            resources.ApplyResources(this.dataGridView, "dataGridView");
            this.dataGridView.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridView.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnNo,
            this.ColumnHKL,
            this.ColumnPrimaryCheck,
            this.ColumnPrimary,
            this.ColumnSecondaryCheck,
            this.ColumnSecondary});
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.dataGridView.RowsDefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView.RowTemplate.Height = 21;
            this.toolTipJapanese.SetToolTip(this.dataGridView, resources.GetString("dataGridView.ToolTip"));
            this.dataGridView.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellDoubleClick);
            // 
            // ColumnNo
            // 
            this.ColumnNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ColumnNo.DefaultCellStyle = dataGridViewCellStyle2;
            resources.ApplyResources(this.ColumnNo, "ColumnNo");
            this.ColumnNo.Name = "ColumnNo";
            this.ColumnNo.ReadOnly = true;
            this.ColumnNo.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnNo.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnHKL
            // 
            this.ColumnHKL.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.NullValue = null;
            this.ColumnHKL.DefaultCellStyle = dataGridViewCellStyle3;
            resources.ApplyResources(this.ColumnHKL, "ColumnHKL");
            this.ColumnHKL.Name = "ColumnHKL";
            this.ColumnHKL.ReadOnly = true;
            this.ColumnHKL.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnHKL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPrimaryCheck
            // 
            this.ColumnPrimaryCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.NullValue = false;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnPrimaryCheck.DefaultCellStyle = dataGridViewCellStyle4;
            resources.ApplyResources(this.ColumnPrimaryCheck, "ColumnPrimaryCheck");
            this.ColumnPrimaryCheck.Name = "ColumnPrimaryCheck";
            this.ColumnPrimaryCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnPrimary
            // 
            this.ColumnPrimary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnPrimary.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.NullValue = null;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            this.ColumnPrimary.DefaultCellStyle = dataGridViewCellStyle5;
            resources.ApplyResources(this.ColumnPrimary, "ColumnPrimary");
            this.ColumnPrimary.Name = "ColumnPrimary";
            this.ColumnPrimary.ReadOnly = true;
            this.ColumnPrimary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnPrimary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checkUncheckToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            resources.ApplyResources(this.contextMenuStrip1, "contextMenuStrip1");
            // 
            // checkUncheckToolStripMenuItem
            // 
            this.checkUncheckToolStripMenuItem.Name = "checkUncheckToolStripMenuItem";
            resources.ApplyResources(this.checkUncheckToolStripMenuItem, "checkUncheckToolStripMenuItem");
            this.checkUncheckToolStripMenuItem.Click += new System.EventHandler(this.checkUncheckToolStripMenuItem_Click);
            // 
            // ColumnSecondaryCheck
            // 
            this.ColumnSecondaryCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.NullValue = false;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.ColumnSecondaryCheck.DefaultCellStyle = dataGridViewCellStyle6;
            resources.ApplyResources(this.ColumnSecondaryCheck, "ColumnSecondaryCheck");
            this.ColumnSecondaryCheck.Name = "ColumnSecondaryCheck";
            this.ColumnSecondaryCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // ColumnSecondary
            // 
            this.ColumnSecondary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnSecondary.ContextMenuStrip = this.contextMenuStrip1;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.NullValue = null;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.White;
            this.ColumnSecondary.DefaultCellStyle = dataGridViewCellStyle7;
            resources.ApplyResources(this.ColumnSecondary, "ColumnSecondary");
            this.ColumnSecondary.Name = "ColumnSecondary";
            this.ColumnSecondary.ReadOnly = true;
            this.ColumnSecondary.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnSecondary.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // pictureBoxMain
            // 
            resources.ApplyResources(this.pictureBoxMain, "pictureBoxMain");
            this.pictureBoxMain.BackColor = System.Drawing.Color.White;
            this.pictureBoxMain.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxMain, resources.GetString("pictureBoxMain.ToolTip"));
            this.pictureBoxMain.Click += new System.EventHandler(this.pictureBoxMain_Click);
            this.pictureBoxMain.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxMain_Paint);
            this.pictureBoxMain.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseDown);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            this.pictureBoxMain.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseUp);
            // 
            // pictureBoxPixelKsi
            // 
            this.pictureBoxPixelKsi.BackColor = System.Drawing.Color.White;
            this.pictureBoxPixelKsi.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxPixelKsi, "pictureBoxPixelKsi");
            this.pictureBoxPixelKsi.Name = "pictureBoxPixelKsi";
            this.pictureBoxPixelKsi.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxPixelKsi, resources.GetString("pictureBoxPixelKsi.ToolTip"));
            // 
            // pictureBoxPixelSizeY
            // 
            this.pictureBoxPixelSizeY.BackColor = System.Drawing.Color.White;
            this.pictureBoxPixelSizeY.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxPixelSizeY, "pictureBoxPixelSizeY");
            this.pictureBoxPixelSizeY.Name = "pictureBoxPixelSizeY";
            this.pictureBoxPixelSizeY.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxPixelSizeY, resources.GetString("pictureBoxPixelSizeY.ToolTip"));
            // 
            // pictureBoxPixelSizeX
            // 
            this.pictureBoxPixelSizeX.BackColor = System.Drawing.Color.White;
            this.pictureBoxPixelSizeX.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxPixelSizeX, "pictureBoxPixelSizeX");
            this.pictureBoxPixelSizeX.Name = "pictureBoxPixelSizeX";
            this.pictureBoxPixelSizeX.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxPixelSizeX, resources.GetString("pictureBoxPixelSizeX.ToolTip"));
            // 
            // pictureBoxTiltCorrectionTau2
            // 
            this.pictureBoxTiltCorrectionTau2.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrectionTau2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrectionTau2, "pictureBoxTiltCorrectionTau2");
            this.pictureBoxTiltCorrectionTau2.Name = "pictureBoxTiltCorrectionTau2";
            this.pictureBoxTiltCorrectionTau2.TabStop = false;
            // 
            // pictureBoxTiltCorrectionTau1
            // 
            this.pictureBoxTiltCorrectionTau1.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrectionTau1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrectionTau1, "pictureBoxTiltCorrectionTau1");
            this.pictureBoxTiltCorrectionTau1.Name = "pictureBoxTiltCorrectionTau1";
            this.pictureBoxTiltCorrectionTau1.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxTiltCorrectionTau1, resources.GetString("pictureBoxTiltCorrectionTau1.ToolTip"));
            // 
            // pictureBoxTiltCorrectionPhi2
            // 
            this.pictureBoxTiltCorrectionPhi2.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrectionPhi2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrectionPhi2, "pictureBoxTiltCorrectionPhi2");
            this.pictureBoxTiltCorrectionPhi2.Name = "pictureBoxTiltCorrectionPhi2";
            this.pictureBoxTiltCorrectionPhi2.TabStop = false;
            // 
            // pictureBoxTiltCorrectionPhi1
            // 
            this.pictureBoxTiltCorrectionPhi1.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrectionPhi1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrectionPhi1, "pictureBoxTiltCorrectionPhi1");
            this.pictureBoxTiltCorrectionPhi1.Name = "pictureBoxTiltCorrectionPhi1";
            this.pictureBoxTiltCorrectionPhi1.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxTiltCorrectionPhi1, resources.GetString("pictureBoxTiltCorrectionPhi1.ToolTip"));
            // 
            // pictureBoxCameraLength
            // 
            this.pictureBoxCameraLength.BackColor = System.Drawing.Color.White;
            this.pictureBoxCameraLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxCameraLength, "pictureBoxCameraLength");
            this.pictureBoxCameraLength.Name = "pictureBoxCameraLength";
            this.pictureBoxCameraLength.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxCameraLength, resources.GetString("pictureBoxCameraLength.ToolTip"));
            // 
            // pictureBoxResidual
            // 
            this.pictureBoxResidual.BackColor = System.Drawing.Color.White;
            this.pictureBoxResidual.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxResidual, "pictureBoxResidual");
            this.pictureBoxResidual.Name = "pictureBoxResidual";
            this.pictureBoxResidual.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxResidual, resources.GetString("pictureBoxResidual.ToolTip"));
            // 
            // pictureBoxWaveLength
            // 
            this.pictureBoxWaveLength.BackColor = System.Drawing.Color.White;
            this.pictureBoxWaveLength.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxWaveLength, "pictureBoxWaveLength");
            this.pictureBoxWaveLength.Name = "pictureBoxWaveLength";
            this.pictureBoxWaveLength.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxWaveLength, resources.GetString("pictureBoxWaveLength.ToolTip"));
            // 
            // pictureBoxTiltCorrection2
            // 
            this.pictureBoxTiltCorrection2.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrection2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrection2, "pictureBoxTiltCorrection2");
            this.pictureBoxTiltCorrection2.Name = "pictureBoxTiltCorrection2";
            this.pictureBoxTiltCorrection2.TabStop = false;
            // 
            // pictureBoxTiltCorrection1
            // 
            this.pictureBoxTiltCorrection1.BackColor = System.Drawing.Color.White;
            this.pictureBoxTiltCorrection1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.pictureBoxTiltCorrection1, "pictureBoxTiltCorrection1");
            this.pictureBoxTiltCorrection1.Name = "pictureBoxTiltCorrection1";
            this.pictureBoxTiltCorrection1.TabStop = false;
            this.toolTipJapanese.SetToolTip(this.pictureBoxTiltCorrection1, resources.GetString("pictureBoxTiltCorrection1.ToolTip"));
            // 
            // label74
            // 
            resources.ApplyResources(this.label74, "label74");
            this.label74.Name = "label74";
            // 
            // label80
            // 
            resources.ApplyResources(this.label80, "label80");
            this.label80.Name = "label80";
            // 
            // label57
            // 
            resources.ApplyResources(this.label57, "label57");
            this.label57.Name = "label57";
            // 
            // label60
            // 
            resources.ApplyResources(this.label60, "label60");
            this.label60.Name = "label60";
            // 
            // label79
            // 
            resources.ApplyResources(this.label79, "label79");
            this.label79.Name = "label79";
            // 
            // label72
            // 
            resources.ApplyResources(this.label72, "label72");
            this.label72.Name = "label72";
            // 
            // label37
            // 
            resources.ApplyResources(this.label37, "label37");
            this.label37.Name = "label37";
            // 
            // label76
            // 
            resources.ApplyResources(this.label76, "label76");
            this.label76.Name = "label76";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label78
            // 
            resources.ApplyResources(this.label78, "label78");
            this.label78.Name = "label78";
            // 
            // label77
            // 
            resources.ApplyResources(this.label77, "label77");
            this.label77.Name = "label77";
            // 
            // label47
            // 
            resources.ApplyResources(this.label47, "label47");
            this.label47.Name = "label47";
            // 
            // label59
            // 
            resources.ApplyResources(this.label59, "label59");
            this.label59.Name = "label59";
            // 
            // label50
            // 
            resources.ApplyResources(this.label50, "label50");
            this.label50.Name = "label50";
            // 
            // label52
            // 
            resources.ApplyResources(this.label52, "label52");
            this.label52.Name = "label52";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1,
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Maximum = 100000;
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            resources.ApplyResources(this.toolStripProgressBar1, "toolStripProgressBar1");
            this.toolStripProgressBar1.Step = 1;
            this.toolStripProgressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // groupBoxPeakList
            // 
            resources.ApplyResources(this.groupBoxPeakList, "groupBoxPeakList");
            this.groupBoxPeakList.Controls.Add(this.buttonGetWaveLengthFromWholePattern);
            this.groupBoxPeakList.Controls.Add(this.dataGridView);
            this.groupBoxPeakList.Controls.Add(this.buttonGetCameraLenghtFromWholePattern);
            this.groupBoxPeakList.Controls.Add(this.buttonCheckPeaks);
            this.groupBoxPeakList.Controls.Add(this.numericBoxAwayFrom);
            this.groupBoxPeakList.Controls.Add(this.numericBoxLowerThan);
            this.groupBoxPeakList.Name = "groupBoxPeakList";
            this.groupBoxPeakList.TabStop = false;
            // 
            // buttonCheckPeaks
            // 
            resources.ApplyResources(this.buttonCheckPeaks, "buttonCheckPeaks");
            this.buttonCheckPeaks.Name = "buttonCheckPeaks";
            this.buttonCheckPeaks.UseVisualStyleBackColor = true;
            this.buttonCheckPeaks.Click += new System.EventHandler(this.buttonCheckPeaks_Click);
            // 
            // numericBoxAwayFrom
            // 
            resources.ApplyResources(this.numericBoxAwayFrom, "numericBoxAwayFrom");
            this.numericBoxAwayFrom.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAwayFrom.DecimalPlaces = 2;
            this.numericBoxAwayFrom.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAwayFrom.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxAwayFrom.Minimum = 0D;
            this.numericBoxAwayFrom.Name = "numericBoxAwayFrom";
            this.numericBoxAwayFrom.RadianValue = 0.017453292519943295D;
            this.numericBoxAwayFrom.RoundErrorAccuracy = -1;
            this.numericBoxAwayFrom.SkipEventDuringInput = false;
            this.numericBoxAwayFrom.SmartIncrement = true;
            this.numericBoxAwayFrom.TextFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxAwayFrom.ThonsandsSeparator = true;
            this.numericBoxAwayFrom.Value = 1D;
            this.numericBoxAwayFrom.WordWrap = false;
            this.numericBoxAwayFrom.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // numericBoxLowerThan
            // 
            resources.ApplyResources(this.numericBoxLowerThan, "numericBoxLowerThan");
            this.numericBoxLowerThan.BackColor = System.Drawing.SystemColors.Control;
            this.numericBoxLowerThan.DecimalPlaces = 2;
            this.numericBoxLowerThan.FooterBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxLowerThan.HeaderBackColor = System.Drawing.SystemColors.Control;
            this.numericBoxLowerThan.Minimum = 0D;
            this.numericBoxLowerThan.Name = "numericBoxLowerThan";
            this.numericBoxLowerThan.RadianValue = 2.6179938779914944D;
            this.numericBoxLowerThan.RoundErrorAccuracy = -1;
            this.numericBoxLowerThan.SkipEventDuringInput = false;
            this.numericBoxLowerThan.SmartIncrement = true;
            this.numericBoxLowerThan.TextFont = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numericBoxLowerThan.ThonsandsSeparator = true;
            this.numericBoxLowerThan.Value = 150D;
            this.numericBoxLowerThan.WordWrap = false;
            this.numericBoxLowerThan.TextChanged += new System.EventHandler(this.textBox_TextChanged);
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrection2);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrectionPhi1);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrection1);
            this.panel1.Controls.Add(this.pictureBoxPixelSizeY);
            this.panel1.Controls.Add(this.pictureBoxPixelKsi);
            this.panel1.Controls.Add(this.pictureBoxCameraLength);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrectionTau2);
            this.panel1.Controls.Add(this.pictureBoxResidual);
            this.panel1.Controls.Add(this.pictureBoxPixelSizeX);
            this.panel1.Controls.Add(this.pictureBoxWaveLength);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrectionPhi2);
            this.panel1.Controls.Add(this.groupBoxPrimaryImage);
            this.panel1.Controls.Add(this.groupBoxSecondaryImage);
            this.panel1.Controls.Add(this.groupBoxPeakList);
            this.panel1.Controls.Add(this.flowLayoutPanel1);
            this.panel1.Controls.Add(this.groupBoxParameter);
            this.panel1.Controls.Add(this.groupBoxOption);
            this.panel1.Controls.Add(this.label76);
            this.panel1.Controls.Add(this.pictureBoxTiltCorrectionTau1);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label47);
            this.panel1.Controls.Add(this.label50);
            this.panel1.Controls.Add(this.label59);
            this.panel1.Controls.Add(this.label57);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.label77);
            this.panel1.Controls.Add(this.label74);
            this.panel1.Controls.Add(this.label72);
            this.panel1.Controls.Add(this.label78);
            this.panel1.Controls.Add(this.label52);
            this.panel1.Controls.Add(this.label60);
            this.panel1.Controls.Add(this.label37);
            this.panel1.Controls.Add(this.label80);
            this.panel1.Controls.Add(this.label79);
            this.panel1.Name = "panel1";
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // flowLayoutPanelEachPeaks
            // 
            resources.ApplyResources(this.flowLayoutPanelEachPeaks, "flowLayoutPanelEachPeaks");
            this.flowLayoutPanelEachPeaks.Name = "flowLayoutPanelEachPeaks";
            // 
            // checkBoxShowEachPeaks
            // 
            resources.ApplyResources(this.checkBoxShowEachPeaks, "checkBoxShowEachPeaks");
            this.checkBoxShowEachPeaks.Name = "checkBoxShowEachPeaks";
            this.checkBoxShowEachPeaks.UseVisualStyleBackColor = true;
            this.checkBoxShowEachPeaks.CheckedChanged += new System.EventHandler(this.checkBoxShowEachPeaks_CheckedChanged);
            // 
            // FormFindParameter
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.flowLayoutPanelEachPeaks);
            this.Controls.Add(this.buttonStopRefinements);
            this.Controls.Add(this.checkBoxShowEachPeaks);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Name = "FormFindParameter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormFindParameter_FormClosing);
            this.Load += new System.EventHandler(this.FormCLandWL_Load);
            this.VisibleChanged += new System.EventHandler(this.FormFindParameter_VisibleChanged);
            this.Resize += new System.EventHandler(this.FormFindParameter_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownBandWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSearchRange)).EndInit();
            this.groupBoxPrimaryImage.ResumeLayout(false);
            this.groupBoxPrimaryImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern1)).EndInit();
            this.groupBoxSecondaryImage.ResumeLayout(false);
            this.groupBoxSecondaryImage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPattern2)).EndInit();
            this.groupBoxOption.ResumeLayout(false);
            this.groupBoxOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownRepitition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownThresholdOfPeak)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownDivision)).EndInit();
            this.groupBoxParameter.ResumeLayout(false);
            this.groupBoxParameter.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelKsi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelSizeY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPixelSizeX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionTau2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionTau1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionPhi2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrectionPhi1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCameraLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxResidual)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWaveLength)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrection2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxTiltCorrection1)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBoxPeakList.ResumeLayout(false);
            this.groupBoxPeakList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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

}