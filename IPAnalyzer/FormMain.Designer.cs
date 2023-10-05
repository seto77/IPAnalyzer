using System;
using System.Drawing;
using System.ComponentModel;
using System.Windows.Forms;
using Crystallography.Controls;

namespace IPAnalyzer
{
    /// <summary>
    /// Form1 の概要の説明です。
    /// </summary>
    partial class FormMain : System.Windows.Forms.Form
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private IContainer components = null;

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
            if (pseudoBitmap != null)
                pseudoBitmap.Dispose();
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
            ComponentResourceManager resources = new ComponentResourceManager(typeof(FormMain));
            toolStripContainer1 = new ToolStripContainer();
            statusStrip1 = new StatusStrip();
            toolStripProgressBar = new ToolStripProgressBar();
            toolStripStatusLabel = new ToolStripStatusLabel();
            splitContainer1 = new SplitContainer();
            splitContainer2 = new SplitContainer();
            panel4 = new Panel();
            textBoxInformation = new TextBox();
            label11 = new Label();
            panel3 = new Panel();
            scalablePictureBoxThumbnail = new ScalablePictureBox();
            radioButtonNearCenter = new RadioButton();
            radioButtonWhole = new RadioButton();
            panel2 = new Panel();
            comboBoxScaleLine = new ComboBox();
            label1 = new Label();
            comboBoxScale2 = new ComboBox();
            label9 = new Label();
            comboBoxScale1 = new ComboBox();
            label7 = new Label();
            comboBoxGradient = new ComboBox();
            label5 = new Label();
            scalablePictureBox = new ScalablePictureBox();
            flowLayoutPanel3 = new FlowLayoutPanel();
            label14 = new Label();
            labelResolution = new Label();
            buttonMag1 = new Button();
            buttonMag2 = new Button();
            buttonMag4 = new Button();
            buttonMag_2 = new Button();
            buttonMag_4 = new Button();
            buttonMag_8 = new Button();
            buttonMag_16 = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            labelMousePointChi = new Label();
            labelMousePointD = new Label();
            labelMousePointTheta = new Label();
            labelMousePointR = new Label();
            labelMousePointIntensity = new Label();
            label6 = new Label();
            label8 = new Label();
            label10 = new Label();
            label12 = new Label();
            label13 = new Label();
            tableLayoutPanel3 = new TableLayoutPanel();
            labelMousePointReal = new Label();
            label3 = new Label();
            label4 = new Label();
            labelMousePointPixel = new Label();
            tableLayoutPanel2 = new TableLayoutPanel();
            buttonAutoLevel = new Button();
            buttonReset = new Button();
            trackBarAdvancedMinInt = new TrackBarAdvanced();
            trackBarAdvancedMaxInt = new TrackBarAdvanced();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panelMousePos = new Panel();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            graphControlFrequency = new GraphControl();
            tabPage2 = new TabPage();
            graphControlProfile = new GraphControl();
            tabPage3 = new TabPage();
            textBoxStatisticsSelectedAreaSequential = new TextBox();
            textBoxStatisticsSelectedArea = new TextBox();
            flowLayoutPanel2 = new FlowLayoutPanel();
            label17 = new Label();
            numericUpDownSelectedAreaX1 = new NumericUpDown();
            label18 = new Label();
            numericUpDownSelectedAreaY1 = new NumericUpDown();
            label19 = new Label();
            numericUpDownSelectedAreaX2 = new NumericUpDown();
            label20 = new Label();
            numericUpDownSelectedAreaY2 = new NumericUpDown();
            label21 = new Label();
            label15 = new Label();
            label16 = new Label();
            toolStrip1 = new ToolStrip();
            toolStripButtonIntensityTable = new ToolStripButton();
            toolStripSeparator16 = new ToolStripSeparator();
            toolStripButtonAutoProcedure = new ToolStripButton();
            toolStripSeparator15 = new ToolStripSeparator();
            toolStripButtonRing = new ToolStripButton();
            toolStripSeparator14 = new ToolStripSeparator();
            toolStripButtonFindParameter = new ToolStripButton();
            toolStripSeparator9 = new ToolStripSeparator();
            toolStripButtonFindParameterBruteForce = new ToolStripButton();
            toolStripSeparator31 = new ToolStripSeparator();
            toolStripButtonUnroll = new ToolStripButton();
            toolStripSeparator1 = new ToolStripSeparator();
            toolStripButtonCircumferentialBlur = new ToolStripButton();
            toolStripSeparator17 = new ToolStripSeparator();
            toolStripButtonImageSequence = new ToolStripButton();
            toolStripSeparator19 = new ToolStripSeparator();
            menuStrip = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            readImageToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemSaveImage = new ToolStripMenuItem();
            tiffToolStripMenuItem = new ToolStripMenuItem();
            pngToolStripMenuItem = new ToolStripMenuItem();
            ipaToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator3 = new ToolStripSeparator();
            toolStripMenuItemReadParameter = new ToolStripMenuItem();
            toolStripMenuItemSaveParameter = new ToolStripMenuItem();
            toolStripSeparator13 = new ToolStripSeparator();
            toolStripMenuItemReadMask = new ToolStripMenuItem();
            toolStripMenuItemSaveMask = new ToolStripMenuItem();
            clearMaskToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator4 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            toolToolStripMenuItem = new ToolStripMenuItem();
            resetFrequencyProfileToolStripMenuItem = new ToolStripMenuItem();
            calibrateRaxisImageToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem5 = new ToolStripMenuItem();
            toolStripMenuItemPropertyWaveSource = new ToolStripMenuItem();
            toolStripMenuItem9 = new ToolStripMenuItem();
            toolStripSeparator22 = new ToolStripSeparator();
            toolStripMenuItem10 = new ToolStripMenuItem();
            toolStripMenuItem11 = new ToolStripMenuItem();
            toolStripSeparator23 = new ToolStripSeparator();
            toolStripMenuItem12 = new ToolStripMenuItem();
            toolStripSeparator24 = new ToolStripSeparator();
            toolStripMenuItem13 = new ToolStripMenuItem();
            toolStripSeparator25 = new ToolStripSeparator();
            toolStripMenuItem14 = new ToolStripMenuItem();
            toolStripSeparator26 = new ToolStripSeparator();
            toolStripMenuItem15 = new ToolStripMenuItem();
            toolStripSeparator18 = new ToolStripSeparator();
            misToolStripMenuItem = new ToolStripMenuItem();
            optionToolStripMenuItem = new ToolStripMenuItem();
            toolTipToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            flipHorizontallyToolStripMenuItem = new ToolStripMenuItem();
            flipVerticallyToolStripMenuItem = new ToolStripMenuItem();
            rotateToolStripMenuItem = new ToolStripMenuItem();
            toolStripComboBoxRotate = new ToolStripComboBox();
            toolStripSeparator28 = new ToolStripSeparator();
            ngenCompileToolStripMenuItem = new ToolStripMenuItem();
            clearRegistrycheckAndRestartToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishToolStripMenuItem = new ToolStripMenuItem();
            japaneseToolStripMenuItem = new ToolStripMenuItem();
            macroToolStripMenuItem = new ToolStripMenuItem();
            editorToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator27 = new ToolStripSeparator();
            helpToolStripMenuItem = new ToolStripMenuItem();
            programUpdatesToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator30 = new ToolStripSeparator();
            hintToolStripMenuItem = new ToolStripMenuItem();
            licenseToolStripMenuItem = new ToolStripMenuItem();
            versionHistoryToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator29 = new ToolStripSeparator();
            webPageToolStripMenuItem = new ToolStripMenuItem();
            toolStrip2 = new ToolStrip();
            toolStripSplitButtonBackground = new ToolStripSplitButton();
            resetToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripMenuItem();
            toolStripMenuItem6 = new ToolStripMenuItem();
            toolStripComboBoxBackgroundLower = new ToolStripComboBox();
            toolStripMenuItem7 = new ToolStripMenuItem();
            toolStripComboBoxBackgroundUpper = new ToolStripComboBox();
            fourierToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItemReferenceBackground = new ToolStripMenuItem();
            toolStripSeparator8 = new ToolStripSeparator();
            toolStripSplitButtonFindCenter = new ToolStripSplitButton();
            toolStripMenuItemFindCenterOption = new ToolStripMenuItem();
            findCenterBasedOnTheRingToolStripMenuItem = new ToolStripMenuItem();
            toolStripButtonFixCenter = new ToolStripButton();
            toolStripSeparator6 = new ToolStripSeparator();
            toolStripSplitButtonFindSpots = new ToolStripSplitButton();
            toolStripMenuItemClearMask = new ToolStripMenuItem();
            toolStripMenuItemMaskAll = new ToolStripMenuItem();
            inverseMaskToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator5 = new ToolStripSeparator();
            toolStripMenuItemFindSpotsManual = new ToolStripMenuItem();
            toolStripSeparator10 = new ToolStripSeparator();
            toolStripMenuItemFindSpotsOption = new ToolStripMenuItem();
            toolStripButtonManualSpotMode = new ToolStripButton();
            toolStripComboBoxManualSpotSize = new ToolStripComboBox();
            toolStripSeparator2 = new ToolStripSeparator();
            toolStripSplitButtonGetProfile = new ToolStripSplitButton();
            toolStripMenuItemGetProfileIntegralProperty = new ToolStripMenuItem();
            toolStripMenuItemConcenctricIntegration = new ToolStripMenuItem();
            toolStripMenuItemRadialIntegration = new ToolStripMenuItem();
            toolStripSeparator7 = new ToolStripSeparator();
            toolStripMenuItemGetProfileIntegralRegion = new ToolStripMenuItem();
            toolStripSeparator11 = new ToolStripSeparator();
            findCenterBeforeGetProfileToolStripMenuItem = new ToolStripMenuItem();
            findSpotsBeforeGetProfileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator21 = new ToolStripSeparator();
            toolStripMenuItemSendProfileToPDIndexer = new ToolStripMenuItem();
            toolStripMenuItemSendUnrolledImage = new ToolStripMenuItem();
            toolStripSeparator12 = new ToolStripSeparator();
            toolStripMenuItemAzimuthalDivisionAnalysis = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripComboBoxAzimuthalDivisionNumber = new ToolStripComboBox();
            toolStripSeparator20 = new ToolStripSeparator();
            toolStripMenuItemAllSequentialImages = new ToolStripMenuItem();
            toolStripMenuItemSelectedSequentialImages = new ToolStripMenuItem();
            toolStripButton1 = new ToolStripButton();
            toolTip = new ToolTip(components);
            toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            toolStripContainer1.ContentPanel.SuspendLayout();
            toolStripContainer1.RightToolStripPanel.SuspendLayout();
            toolStripContainer1.TopToolStripPanel.SuspendLayout();
            toolStripContainer1.SuspendLayout();
            statusStrip1.SuspendLayout();
            ((ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            ((ISupportInitialize)splitContainer2).BeginInit();
            splitContainer2.Panel1.SuspendLayout();
            splitContainer2.Panel2.SuspendLayout();
            splitContainer2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            flowLayoutPanel3.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage3.SuspendLayout();
            flowLayoutPanel2.SuspendLayout();
            ((ISupportInitialize)numericUpDownSelectedAreaX1).BeginInit();
            ((ISupportInitialize)numericUpDownSelectedAreaY1).BeginInit();
            ((ISupportInitialize)numericUpDownSelectedAreaX2).BeginInit();
            ((ISupportInitialize)numericUpDownSelectedAreaY2).BeginInit();
            toolStrip1.SuspendLayout();
            menuStrip.SuspendLayout();
            toolStrip2.SuspendLayout();
            SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            toolStripContainer1.BottomToolStripPanel.Controls.Add(statusStrip1);
            toolTip.SetToolTip(toolStripContainer1.BottomToolStripPanel, resources.GetString("toolStripContainer1.BottomToolStripPanel.ToolTip"));
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            toolStripContainer1.ContentPanel.Controls.Add(splitContainer1);
            toolTip.SetToolTip(toolStripContainer1.ContentPanel, resources.GetString("toolStripContainer1.ContentPanel.ToolTip"));
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            toolTip.SetToolTip(toolStripContainer1.LeftToolStripPanel, resources.GetString("toolStripContainer1.LeftToolStripPanel.ToolTip"));
            toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            toolStripContainer1.RightToolStripPanel.BackColor = SystemColors.Control;
            toolStripContainer1.RightToolStripPanel.Controls.Add(toolStrip1);
            toolTip.SetToolTip(toolStripContainer1.RightToolStripPanel, resources.GetString("toolStripContainer1.RightToolStripPanel.ToolTip"));
            toolTip.SetToolTip(toolStripContainer1, resources.GetString("toolStripContainer1.ToolTip"));
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            toolStripContainer1.TopToolStripPanel.BackColor = SystemColors.Control;
            toolStripContainer1.TopToolStripPanel.Controls.Add(menuStrip);
            toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip2);
            toolTip.SetToolTip(toolStripContainer1.TopToolStripPanel, resources.GetString("toolStripContainer1.TopToolStripPanel.ToolTip"));
            // 
            // statusStrip1
            // 
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { toolStripProgressBar, toolStripStatusLabel });
            statusStrip1.Name = "statusStrip1";
            toolTip.SetToolTip(statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // toolStripProgressBar
            // 
            resources.ApplyResources(toolStripProgressBar, "toolStripProgressBar");
            toolStripProgressBar.Name = "toolStripProgressBar";
            // 
            // toolStripStatusLabel
            // 
            resources.ApplyResources(toolStripStatusLabel, "toolStripStatusLabel");
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(splitContainer1, "splitContainer1");
            splitContainer1.Cursor = Cursors.HSplit;
            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(splitContainer1.Panel1, "splitContainer1.Panel1");
            splitContainer1.Panel1.Controls.Add(splitContainer2);
            splitContainer1.Panel1.Controls.Add(tableLayoutPanel2);
            splitContainer1.Panel1.Controls.Add(flowLayoutPanel1);
            splitContainer1.Panel1.Controls.Add(panelMousePos);
            splitContainer1.Panel1.Cursor = Cursors.Default;
            toolTip.SetToolTip(splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(splitContainer1.Panel2, "splitContainer1.Panel2");
            splitContainer1.Panel2.Controls.Add(tabControl1);
            splitContainer1.Panel2.Cursor = Cursors.Default;
            toolTip.SetToolTip(splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            toolTip.SetToolTip(splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            splitContainer1.SplitterMoved += splitContainer1_SplitterMoved;
            splitContainer1.Resize += FormMain_Resize;
            // 
            // splitContainer2
            // 
            resources.ApplyResources(splitContainer2, "splitContainer2");
            splitContainer2.FixedPanel = FixedPanel.Panel1;
            splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(splitContainer2.Panel1, "splitContainer2.Panel1");
            splitContainer2.Panel1.Controls.Add(panel4);
            splitContainer2.Panel1.Controls.Add(panel3);
            splitContainer2.Panel1.Controls.Add(panel2);
            toolTip.SetToolTip(splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.ToolTip"));
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(splitContainer2.Panel2, "splitContainer2.Panel2");
            splitContainer2.Panel2.Controls.Add(scalablePictureBox);
            splitContainer2.Panel2.Controls.Add(flowLayoutPanel3);
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel1);
            splitContainer2.Panel2.Controls.Add(tableLayoutPanel3);
            toolTip.SetToolTip(splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.ToolTip"));
            toolTip.SetToolTip(splitContainer2, resources.GetString("splitContainer2.ToolTip"));
            // 
            // panel4
            // 
            resources.ApplyResources(panel4, "panel4");
            panel4.Controls.Add(textBoxInformation);
            panel4.Controls.Add(label11);
            panel4.Name = "panel4";
            toolTip.SetToolTip(panel4, resources.GetString("panel4.ToolTip"));
            // 
            // textBoxInformation
            // 
            resources.ApplyResources(textBoxInformation, "textBoxInformation");
            textBoxInformation.Name = "textBoxInformation";
            textBoxInformation.ReadOnly = true;
            toolTip.SetToolTip(textBoxInformation, resources.GetString("textBoxInformation.ToolTip"));
            // 
            // label11
            // 
            resources.ApplyResources(label11, "label11");
            label11.Name = "label11";
            toolTip.SetToolTip(label11, resources.GetString("label11.ToolTip"));
            // 
            // panel3
            // 
            resources.ApplyResources(panel3, "panel3");
            panel3.Controls.Add(scalablePictureBoxThumbnail);
            panel3.Controls.Add(radioButtonNearCenter);
            panel3.Controls.Add(radioButtonWhole);
            panel3.Name = "panel3";
            toolTip.SetToolTip(panel3, resources.GetString("panel3.ToolTip"));
            // 
            // scalablePictureBoxThumbnail
            // 
            resources.ApplyResources(scalablePictureBoxThumbnail, "scalablePictureBoxThumbnail");
            scalablePictureBoxThumbnail.BackColor = SystemColors.ActiveCaption;
            scalablePictureBoxThumbnail.BorderStyle = BorderStyle.Fixed3D;
            scalablePictureBoxThumbnail.FixZoomAndCenter = false;
            scalablePictureBoxThumbnail.FocusEventEnabled = false;
            scalablePictureBoxThumbnail.HorizontalFlip = false;
            scalablePictureBoxThumbnail.ManualSpotMode = false;
            scalablePictureBoxThumbnail.MouseScaling = true;
            scalablePictureBoxThumbnail.MouseTranslation = false;
            scalablePictureBoxThumbnail.Name = "scalablePictureBoxThumbnail";
            scalablePictureBoxThumbnail.ShowAreaRectangle = false;
            scalablePictureBoxThumbnail.ShowRimRentangle = false;
            scalablePictureBoxThumbnail.Title = ((string, Font, Color, Color))resources.GetObject("scalablePictureBoxThumbnail.Title");
            scalablePictureBoxThumbnail.TitleVisible = false;
            toolTip.SetToolTip(scalablePictureBoxThumbnail, resources.GetString("scalablePictureBoxThumbnail.ToolTip"));
            scalablePictureBoxThumbnail.VerticalFlip = false;
            scalablePictureBoxThumbnail.Zoom = 128D;
            scalablePictureBoxThumbnail.MouseDown2 += scalablePictureBoxThumbnail_MouseDown2;
            scalablePictureBoxThumbnail.Draw += scalablePictureBoxThumbnail_Draw;
            // 
            // radioButtonNearCenter
            // 
            resources.ApplyResources(radioButtonNearCenter, "radioButtonNearCenter");
            radioButtonNearCenter.Checked = true;
            radioButtonNearCenter.Name = "radioButtonNearCenter";
            radioButtonNearCenter.TabStop = true;
            toolTip.SetToolTip(radioButtonNearCenter, resources.GetString("radioButtonNearCenter.ToolTip"));
            radioButtonNearCenter.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhole
            // 
            resources.ApplyResources(radioButtonWhole, "radioButtonWhole");
            radioButtonWhole.Name = "radioButtonWhole";
            toolTip.SetToolTip(radioButtonWhole, resources.GetString("radioButtonWhole.ToolTip"));
            radioButtonWhole.UseVisualStyleBackColor = true;
            radioButtonWhole.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // panel2
            // 
            resources.ApplyResources(panel2, "panel2");
            panel2.Controls.Add(comboBoxScaleLine);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(comboBoxScale2);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(comboBoxScale1);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(comboBoxGradient);
            panel2.Controls.Add(label5);
            panel2.Name = "panel2";
            toolTip.SetToolTip(panel2, resources.GetString("panel2.ToolTip"));
            // 
            // comboBoxScaleLine
            // 
            resources.ApplyResources(comboBoxScaleLine, "comboBoxScaleLine");
            comboBoxScaleLine.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScaleLine.FormattingEnabled = true;
            comboBoxScaleLine.Items.AddRange(new object[] { resources.GetString("comboBoxScaleLine.Items"), resources.GetString("comboBoxScaleLine.Items1"), resources.GetString("comboBoxScaleLine.Items2"), resources.GetString("comboBoxScaleLine.Items3") });
            comboBoxScaleLine.Name = "comboBoxScaleLine";
            toolTip.SetToolTip(comboBoxScaleLine, resources.GetString("comboBoxScaleLine.ToolTip"));
            comboBoxScaleLine.SelectedIndexChanged += comboBoxScaleLine_SelectedIndexChanged;
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip"));
            // 
            // comboBoxScale2
            // 
            resources.ApplyResources(comboBoxScale2, "comboBoxScale2");
            comboBoxScale2.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScale2.FormattingEnabled = true;
            comboBoxScale2.Items.AddRange(new object[] { resources.GetString("comboBoxScale2.Items"), resources.GetString("comboBoxScale2.Items1"), resources.GetString("comboBoxScale2.Items2"), resources.GetString("comboBoxScale2.Items3") });
            comboBoxScale2.Name = "comboBoxScale2";
            toolTip.SetToolTip(comboBoxScale2, resources.GetString("comboBoxScale2.ToolTip"));
            comboBoxScale2.SelectedIndexChanged += toolStripComboBoxScale2_SelectedIndexChanged;
            // 
            // label9
            // 
            resources.ApplyResources(label9, "label9");
            label9.Name = "label9";
            toolTip.SetToolTip(label9, resources.GetString("label9.ToolTip"));
            // 
            // comboBoxScale1
            // 
            resources.ApplyResources(comboBoxScale1, "comboBoxScale1");
            comboBoxScale1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxScale1.FormattingEnabled = true;
            comboBoxScale1.Items.AddRange(new object[] { resources.GetString("comboBoxScale1.Items"), resources.GetString("comboBoxScale1.Items1") });
            comboBoxScale1.Name = "comboBoxScale1";
            toolTip.SetToolTip(comboBoxScale1, resources.GetString("comboBoxScale1.ToolTip"));
            comboBoxScale1.SelectedIndexChanged += toolStripComboBoxScale_SelectedIndexChanged;
            // 
            // label7
            // 
            resources.ApplyResources(label7, "label7");
            label7.Name = "label7";
            toolTip.SetToolTip(label7, resources.GetString("label7.ToolTip"));
            // 
            // comboBoxGradient
            // 
            resources.ApplyResources(comboBoxGradient, "comboBoxGradient");
            comboBoxGradient.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGradient.FormattingEnabled = true;
            comboBoxGradient.Items.AddRange(new object[] { resources.GetString("comboBoxGradient.Items"), resources.GetString("comboBoxGradient.Items1") });
            comboBoxGradient.Name = "comboBoxGradient";
            toolTip.SetToolTip(comboBoxGradient, resources.GetString("comboBoxGradient.ToolTip"));
            comboBoxGradient.SelectedIndexChanged += comboBoxGradient_SelectedIndexChanged_1;
            // 
            // label5
            // 
            resources.ApplyResources(label5, "label5");
            label5.Name = "label5";
            toolTip.SetToolTip(label5, resources.GetString("label5.ToolTip"));
            // 
            // scalablePictureBox
            // 
            resources.ApplyResources(scalablePictureBox, "scalablePictureBox");
            scalablePictureBox.BackColor = SystemColors.ActiveCaption;
            scalablePictureBox.BorderStyle = BorderStyle.Fixed3D;
            scalablePictureBox.FixZoomAndCenter = false;
            scalablePictureBox.FocusEventEnabled = false;
            scalablePictureBox.HorizontalFlip = false;
            scalablePictureBox.ManualSpotMode = false;
            scalablePictureBox.MouseScaling = true;
            scalablePictureBox.MouseTranslation = true;
            scalablePictureBox.Name = "scalablePictureBox";
            scalablePictureBox.ShowAreaRectangle = false;
            scalablePictureBox.ShowRimRentangle = false;
            scalablePictureBox.Title = ((string, Font, Color, Color))resources.GetObject("scalablePictureBox.Title");
            scalablePictureBox.TitleVisible = false;
            toolTip.SetToolTip(scalablePictureBox, resources.GetString("scalablePictureBox.ToolTip"));
            scalablePictureBox.VerticalFlip = false;
            scalablePictureBox.Zoom = 128D;
            scalablePictureBox.MouseMove2 += scalablePictureBox_MouseMove2;
            scalablePictureBox.MouseUp2 += scalablePictureBox_MouseUp2;
            scalablePictureBox.MouseDown2 += scalablePictureBox_MouseDown2;
            scalablePictureBox.MouseWheel2 += scalablePictureBox_MouseWheel2;
            scalablePictureBox.Draw += scalablePictureBox_Draw;
            // 
            // flowLayoutPanel3
            // 
            resources.ApplyResources(flowLayoutPanel3, "flowLayoutPanel3");
            flowLayoutPanel3.Controls.Add(label14);
            flowLayoutPanel3.Controls.Add(labelResolution);
            flowLayoutPanel3.Controls.Add(buttonMag1);
            flowLayoutPanel3.Controls.Add(buttonMag2);
            flowLayoutPanel3.Controls.Add(buttonMag4);
            flowLayoutPanel3.Controls.Add(buttonMag_2);
            flowLayoutPanel3.Controls.Add(buttonMag_4);
            flowLayoutPanel3.Controls.Add(buttonMag_8);
            flowLayoutPanel3.Controls.Add(buttonMag_16);
            flowLayoutPanel3.Name = "flowLayoutPanel3";
            toolTip.SetToolTip(flowLayoutPanel3, resources.GetString("flowLayoutPanel3.ToolTip"));
            // 
            // label14
            // 
            resources.ApplyResources(label14, "label14");
            label14.Name = "label14";
            toolTip.SetToolTip(label14, resources.GetString("label14.ToolTip"));
            // 
            // labelResolution
            // 
            resources.ApplyResources(labelResolution, "labelResolution");
            labelResolution.Name = "labelResolution";
            toolTip.SetToolTip(labelResolution, resources.GetString("labelResolution.ToolTip"));
            // 
            // buttonMag1
            // 
            resources.ApplyResources(buttonMag1, "buttonMag1");
            buttonMag1.Name = "buttonMag1";
            toolTip.SetToolTip(buttonMag1, resources.GetString("buttonMag1.ToolTip"));
            buttonMag1.UseVisualStyleBackColor = true;
            buttonMag1.Click += buttonMag_Click;
            // 
            // buttonMag2
            // 
            resources.ApplyResources(buttonMag2, "buttonMag2");
            buttonMag2.Name = "buttonMag2";
            toolTip.SetToolTip(buttonMag2, resources.GetString("buttonMag2.ToolTip"));
            buttonMag2.UseVisualStyleBackColor = true;
            buttonMag2.Click += buttonMag_Click;
            // 
            // buttonMag4
            // 
            resources.ApplyResources(buttonMag4, "buttonMag4");
            buttonMag4.Name = "buttonMag4";
            toolTip.SetToolTip(buttonMag4, resources.GetString("buttonMag4.ToolTip"));
            buttonMag4.UseVisualStyleBackColor = true;
            buttonMag4.Click += buttonMag_Click;
            // 
            // buttonMag_2
            // 
            resources.ApplyResources(buttonMag_2, "buttonMag_2");
            buttonMag_2.Name = "buttonMag_2";
            toolTip.SetToolTip(buttonMag_2, resources.GetString("buttonMag_2.ToolTip"));
            buttonMag_2.UseVisualStyleBackColor = true;
            buttonMag_2.Click += buttonMag_Click;
            // 
            // buttonMag_4
            // 
            resources.ApplyResources(buttonMag_4, "buttonMag_4");
            buttonMag_4.Name = "buttonMag_4";
            toolTip.SetToolTip(buttonMag_4, resources.GetString("buttonMag_4.ToolTip"));
            buttonMag_4.UseVisualStyleBackColor = true;
            buttonMag_4.Click += buttonMag_Click;
            // 
            // buttonMag_8
            // 
            resources.ApplyResources(buttonMag_8, "buttonMag_8");
            buttonMag_8.Name = "buttonMag_8";
            toolTip.SetToolTip(buttonMag_8, resources.GetString("buttonMag_8.ToolTip"));
            buttonMag_8.UseVisualStyleBackColor = true;
            buttonMag_8.Click += buttonMag_Click;
            // 
            // buttonMag_16
            // 
            resources.ApplyResources(buttonMag_16, "buttonMag_16");
            buttonMag_16.Name = "buttonMag_16";
            toolTip.SetToolTip(buttonMag_16, resources.GetString("buttonMag_16.ToolTip"));
            buttonMag_16.UseVisualStyleBackColor = true;
            buttonMag_16.Click += buttonMag_Click;
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(tableLayoutPanel1, "tableLayoutPanel1");
            tableLayoutPanel1.Controls.Add(labelMousePointChi, 9, 0);
            tableLayoutPanel1.Controls.Add(labelMousePointD, 7, 0);
            tableLayoutPanel1.Controls.Add(labelMousePointTheta, 5, 0);
            tableLayoutPanel1.Controls.Add(labelMousePointR, 3, 0);
            tableLayoutPanel1.Controls.Add(labelMousePointIntensity, 1, 0);
            tableLayoutPanel1.Controls.Add(label6, 0, 0);
            tableLayoutPanel1.Controls.Add(label8, 2, 0);
            tableLayoutPanel1.Controls.Add(label10, 4, 0);
            tableLayoutPanel1.Controls.Add(label12, 6, 0);
            tableLayoutPanel1.Controls.Add(label13, 8, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            toolTip.SetToolTip(tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // labelMousePointChi
            // 
            resources.ApplyResources(labelMousePointChi, "labelMousePointChi");
            labelMousePointChi.Name = "labelMousePointChi";
            toolTip.SetToolTip(labelMousePointChi, resources.GetString("labelMousePointChi.ToolTip"));
            labelMousePointChi.Click += toolStripMenuItemMiscellaneous_Click;
            // 
            // labelMousePointD
            // 
            resources.ApplyResources(labelMousePointD, "labelMousePointD");
            labelMousePointD.Name = "labelMousePointD";
            toolTip.SetToolTip(labelMousePointD, resources.GetString("labelMousePointD.ToolTip"));
            // 
            // labelMousePointTheta
            // 
            resources.ApplyResources(labelMousePointTheta, "labelMousePointTheta");
            labelMousePointTheta.Name = "labelMousePointTheta";
            toolTip.SetToolTip(labelMousePointTheta, resources.GetString("labelMousePointTheta.ToolTip"));
            // 
            // labelMousePointR
            // 
            resources.ApplyResources(labelMousePointR, "labelMousePointR");
            labelMousePointR.Name = "labelMousePointR";
            toolTip.SetToolTip(labelMousePointR, resources.GetString("labelMousePointR.ToolTip"));
            // 
            // labelMousePointIntensity
            // 
            resources.ApplyResources(labelMousePointIntensity, "labelMousePointIntensity");
            labelMousePointIntensity.Name = "labelMousePointIntensity";
            toolTip.SetToolTip(labelMousePointIntensity, resources.GetString("labelMousePointIntensity.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(label6, "label6");
            label6.Name = "label6";
            toolTip.SetToolTip(label6, resources.GetString("label6.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(label8, "label8");
            label8.Name = "label8";
            toolTip.SetToolTip(label8, resources.GetString("label8.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(label10, "label10");
            label10.Name = "label10";
            toolTip.SetToolTip(label10, resources.GetString("label10.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(label12, "label12");
            label12.Name = "label12";
            toolTip.SetToolTip(label12, resources.GetString("label12.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(label13, "label13");
            label13.Name = "label13";
            toolTip.SetToolTip(label13, resources.GetString("label13.ToolTip"));
            label13.Click += toolStripMenuItemMiscellaneous_Click;
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(tableLayoutPanel3, "tableLayoutPanel3");
            tableLayoutPanel3.Controls.Add(labelMousePointReal, 3, 0);
            tableLayoutPanel3.Controls.Add(label3, 2, 0);
            tableLayoutPanel3.Controls.Add(label4, 0, 0);
            tableLayoutPanel3.Controls.Add(labelMousePointPixel, 1, 0);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            toolTip.SetToolTip(tableLayoutPanel3, resources.GetString("tableLayoutPanel3.ToolTip"));
            // 
            // labelMousePointReal
            // 
            resources.ApplyResources(labelMousePointReal, "labelMousePointReal");
            labelMousePointReal.Name = "labelMousePointReal";
            toolTip.SetToolTip(labelMousePointReal, resources.GetString("labelMousePointReal.ToolTip"));
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
            // labelMousePointPixel
            // 
            resources.ApplyResources(labelMousePointPixel, "labelMousePointPixel");
            labelMousePointPixel.Name = "labelMousePointPixel";
            toolTip.SetToolTip(labelMousePointPixel, resources.GetString("labelMousePointPixel.ToolTip"));
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(tableLayoutPanel2, "tableLayoutPanel2");
            tableLayoutPanel2.Controls.Add(buttonAutoLevel, 0, 0);
            tableLayoutPanel2.Controls.Add(buttonReset, 0, 1);
            tableLayoutPanel2.Controls.Add(trackBarAdvancedMinInt, 1, 0);
            tableLayoutPanel2.Controls.Add(trackBarAdvancedMaxInt, 1, 1);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            toolTip.SetToolTip(tableLayoutPanel2, resources.GetString("tableLayoutPanel2.ToolTip"));
            // 
            // buttonAutoLevel
            // 
            resources.ApplyResources(buttonAutoLevel, "buttonAutoLevel");
            buttonAutoLevel.Name = "buttonAutoLevel";
            toolTip.SetToolTip(buttonAutoLevel, resources.GetString("buttonAutoLevel.ToolTip"));
            buttonAutoLevel.Click += buttonAutoLevel_Click;
            // 
            // buttonReset
            // 
            resources.ApplyResources(buttonReset, "buttonReset");
            buttonReset.Name = "buttonReset";
            toolTip.SetToolTip(buttonReset, resources.GetString("buttonReset.ToolTip"));
            buttonReset.Click += buttonReset_Click;
            // 
            // trackBarAdvancedMinInt
            // 
            resources.ApplyResources(trackBarAdvancedMinInt, "trackBarAdvancedMinInt");
            trackBarAdvancedMinInt.ControlHeight = 27;
            trackBarAdvancedMinInt.DecimalPlaces = 0;
            trackBarAdvancedMinInt.LogScrollBar = false;
            trackBarAdvancedMinInt.Maximum = 65535D;
            trackBarAdvancedMinInt.Minimum = 0D;
            trackBarAdvancedMinInt.Name = "trackBarAdvancedMinInt";
            trackBarAdvancedMinInt.NumericBoxSize = 120;
            trackBarAdvancedMinInt.Orientation = Orientation.Vertical;
            trackBarAdvancedMinInt.Smart_Increment = true;
            trackBarAdvancedMinInt.TickStyle = TickStyle.BottomRight;
            toolTip.SetToolTip(trackBarAdvancedMinInt, resources.GetString("trackBarAdvancedMinInt.ToolTip"));
            trackBarAdvancedMinInt.UpDown_Increment = 1D;
            trackBarAdvancedMinInt.Value = 0D;
            trackBarAdvancedMinInt.ValueChanged += trackBarAdvancedMinInt_ValueChanged;
            // 
            // trackBarAdvancedMaxInt
            // 
            resources.ApplyResources(trackBarAdvancedMaxInt, "trackBarAdvancedMaxInt");
            trackBarAdvancedMaxInt.ControlHeight = 27;
            trackBarAdvancedMaxInt.DecimalPlaces = 0;
            trackBarAdvancedMaxInt.LogScrollBar = false;
            trackBarAdvancedMaxInt.Maximum = 65535D;
            trackBarAdvancedMaxInt.Minimum = 0D;
            trackBarAdvancedMaxInt.Name = "trackBarAdvancedMaxInt";
            trackBarAdvancedMaxInt.NumericBoxSize = 120;
            trackBarAdvancedMaxInt.Orientation = Orientation.Vertical;
            trackBarAdvancedMaxInt.Smart_Increment = true;
            trackBarAdvancedMaxInt.TickStyle = TickStyle.BottomRight;
            toolTip.SetToolTip(trackBarAdvancedMaxInt, resources.GetString("trackBarAdvancedMaxInt.ToolTip"));
            trackBarAdvancedMaxInt.UpDown_Increment = 1D;
            trackBarAdvancedMaxInt.Value = 65534D;
            trackBarAdvancedMaxInt.ValueChanged += trackBarAdvancedMaxInt_ValueChanged;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            toolTip.SetToolTip(flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // panelMousePos
            // 
            resources.ApplyResources(panelMousePos, "panelMousePos");
            panelMousePos.Name = "panelMousePos";
            toolTip.SetToolTip(panelMousePos, resources.GetString("panelMousePos.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(tabControl1, "tabControl1");
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            toolTip.SetToolTip(tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(tabPage1, "tabPage1");
            tabPage1.Controls.Add(graphControlFrequency);
            tabPage1.Name = "tabPage1";
            toolTip.SetToolTip(tabPage1, resources.GetString("tabPage1.ToolTip"));
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // graphControlFrequency
            // 
            resources.ApplyResources(graphControlFrequency, "graphControlFrequency");
            graphControlFrequency.AllowMouseOperation = true;
            graphControlFrequency.AxisLineColor = Color.Gray;
            graphControlFrequency.AxisTextColor = Color.Black;
            graphControlFrequency.AxisTextFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            graphControlFrequency.AxisXTextVisible = true;
            graphControlFrequency.AxisYTextVisible = true;
            graphControlFrequency.BackgroundColor = Color.White;
            graphControlFrequency.BottomMargin = 0D;
            graphControlFrequency.DivisionLineColor = Color.LightGray;
            graphControlFrequency.DivisionLineXVisible = true;
            graphControlFrequency.DivisionLineYVisible = true;
            graphControlFrequency.DrawingRange = (Crystallography.RectangleD)resources.GetObject("graphControlFrequency.DrawingRange");
            graphControlFrequency.FixRangeHorizontal = false;
            graphControlFrequency.FixRangeVertical = false;
            graphControlFrequency.GraphTitle = "";
            graphControlFrequency.Interpolation = false;
            graphControlFrequency.IsIntegerX = true;
            graphControlFrequency.IsIntegerY = true;
            graphControlFrequency.LabelX = "Intensity:";
            graphControlFrequency.LabelY = "Frequency:";
            graphControlFrequency.LeftMargin = 0F;
            graphControlFrequency.LineWidth = 1F;
            graphControlFrequency.LowerX = 0D;
            graphControlFrequency.LowerY = 0D;
            graphControlFrequency.MaximalX = 1D;
            graphControlFrequency.MaximalY = 1D;
            graphControlFrequency.MinimalX = 0D;
            graphControlFrequency.MinimalY = 0D;
            graphControlFrequency.Mode = GraphControl.DrawingMode.Histogram;
            graphControlFrequency.MousePositionVisible = true;
            graphControlFrequency.MousePositionXDigit = -1;
            graphControlFrequency.MousePositionYDigit = -1;
            graphControlFrequency.Name = "graphControlFrequency";
            graphControlFrequency.OriginPosition = new Point(40, 20);
            graphControlFrequency.Profile = null;
            graphControlFrequency.Smoothing = false;
            toolTip.SetToolTip(graphControlFrequency, resources.GetString("graphControlFrequency.ToolTip"));
            graphControlFrequency.UnitX = "";
            graphControlFrequency.UnitY = "";
            graphControlFrequency.UpperPanelFont = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            graphControlFrequency.UpperPanelVisible = true;
            graphControlFrequency.UpperX = 1D;
            graphControlFrequency.UpperY = 1D;
            graphControlFrequency.UseLineWidth = true;
            graphControlFrequency.VerticalLineColor = Color.Red;
            graphControlFrequency.XLog = true;
            graphControlFrequency.YLog = true;
            graphControlFrequency.LinePositionChanged += graphControlFrequency_LinePositionChanged;
            // 
            // tabPage2
            // 
            resources.ApplyResources(tabPage2, "tabPage2");
            tabPage2.Controls.Add(graphControlProfile);
            tabPage2.Name = "tabPage2";
            toolTip.SetToolTip(tabPage2, resources.GetString("tabPage2.ToolTip"));
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphControlProfile
            // 
            resources.ApplyResources(graphControlProfile, "graphControlProfile");
            graphControlProfile.AllowMouseOperation = true;
            graphControlProfile.AxisLineColor = Color.Gray;
            graphControlProfile.AxisTextColor = Color.Black;
            graphControlProfile.AxisTextFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            graphControlProfile.AxisXTextVisible = true;
            graphControlProfile.AxisYTextVisible = true;
            graphControlProfile.BackgroundColor = Color.White;
            graphControlProfile.BottomMargin = 0D;
            graphControlProfile.DivisionLineColor = Color.LightGray;
            graphControlProfile.DivisionLineXVisible = true;
            graphControlProfile.DivisionLineYVisible = true;
            graphControlProfile.DrawingRange = (Crystallography.RectangleD)resources.GetObject("graphControlProfile.DrawingRange");
            graphControlProfile.FixRangeHorizontal = false;
            graphControlProfile.FixRangeVertical = false;
            graphControlProfile.GraphTitle = "aaa";
            graphControlProfile.Interpolation = false;
            graphControlProfile.IsIntegerX = false;
            graphControlProfile.IsIntegerY = false;
            graphControlProfile.LabelX = "Angle:";
            graphControlProfile.LabelY = "Intensity:";
            graphControlProfile.LeftMargin = 0F;
            graphControlProfile.LineWidth = 1F;
            graphControlProfile.LowerX = 0D;
            graphControlProfile.LowerY = 0D;
            graphControlProfile.MaximalX = 1D;
            graphControlProfile.MaximalY = 1D;
            graphControlProfile.MinimalX = 0D;
            graphControlProfile.MinimalY = 0D;
            graphControlProfile.Mode = GraphControl.DrawingMode.Line;
            graphControlProfile.MousePositionVisible = false;
            graphControlProfile.MousePositionXDigit = -1;
            graphControlProfile.MousePositionYDigit = -1;
            graphControlProfile.Name = "graphControlProfile";
            graphControlProfile.OriginPosition = new Point(40, 20);
            graphControlProfile.Profile = null;
            graphControlProfile.Smoothing = false;
            toolTip.SetToolTip(graphControlProfile, resources.GetString("graphControlProfile.ToolTip"));
            graphControlProfile.UnitX = "";
            graphControlProfile.UnitY = "";
            graphControlProfile.UpperPanelFont = new Font("Segoe UI Symbol", 9F, FontStyle.Regular, GraphicsUnit.Point);
            graphControlProfile.UpperPanelVisible = false;
            graphControlProfile.UpperX = 1D;
            graphControlProfile.UpperY = 1D;
            graphControlProfile.UseLineWidth = true;
            graphControlProfile.VerticalLineColor = Color.Red;
            graphControlProfile.XLog = false;
            graphControlProfile.YLog = false;
            // 
            // tabPage3
            // 
            resources.ApplyResources(tabPage3, "tabPage3");
            tabPage3.Controls.Add(textBoxStatisticsSelectedAreaSequential);
            tabPage3.Controls.Add(textBoxStatisticsSelectedArea);
            tabPage3.Controls.Add(flowLayoutPanel2);
            tabPage3.Controls.Add(label15);
            tabPage3.Controls.Add(label16);
            tabPage3.Name = "tabPage3";
            toolTip.SetToolTip(tabPage3, resources.GetString("tabPage3.ToolTip"));
            tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxStatisticsSelectedAreaSequential
            // 
            resources.ApplyResources(textBoxStatisticsSelectedAreaSequential, "textBoxStatisticsSelectedAreaSequential");
            textBoxStatisticsSelectedAreaSequential.Name = "textBoxStatisticsSelectedAreaSequential";
            textBoxStatisticsSelectedAreaSequential.ReadOnly = true;
            toolTip.SetToolTip(textBoxStatisticsSelectedAreaSequential, resources.GetString("textBoxStatisticsSelectedAreaSequential.ToolTip"));
            // 
            // textBoxStatisticsSelectedArea
            // 
            resources.ApplyResources(textBoxStatisticsSelectedArea, "textBoxStatisticsSelectedArea");
            textBoxStatisticsSelectedArea.Name = "textBoxStatisticsSelectedArea";
            textBoxStatisticsSelectedArea.ReadOnly = true;
            toolTip.SetToolTip(textBoxStatisticsSelectedArea, resources.GetString("textBoxStatisticsSelectedArea.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(flowLayoutPanel2, "flowLayoutPanel2");
            flowLayoutPanel2.Controls.Add(label17);
            flowLayoutPanel2.Controls.Add(numericUpDownSelectedAreaX1);
            flowLayoutPanel2.Controls.Add(label18);
            flowLayoutPanel2.Controls.Add(numericUpDownSelectedAreaY1);
            flowLayoutPanel2.Controls.Add(label19);
            flowLayoutPanel2.Controls.Add(numericUpDownSelectedAreaX2);
            flowLayoutPanel2.Controls.Add(label20);
            flowLayoutPanel2.Controls.Add(numericUpDownSelectedAreaY2);
            flowLayoutPanel2.Controls.Add(label21);
            flowLayoutPanel2.Name = "flowLayoutPanel2";
            toolTip.SetToolTip(flowLayoutPanel2, resources.GetString("flowLayoutPanel2.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(label17, "label17");
            label17.Name = "label17";
            toolTip.SetToolTip(label17, resources.GetString("label17.ToolTip"));
            // 
            // numericUpDownSelectedAreaX1
            // 
            resources.ApplyResources(numericUpDownSelectedAreaX1, "numericUpDownSelectedAreaX1");
            numericUpDownSelectedAreaX1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSelectedAreaX1.Name = "numericUpDownSelectedAreaX1";
            toolTip.SetToolTip(numericUpDownSelectedAreaX1, resources.GetString("numericUpDownSelectedAreaX1.ToolTip"));
            numericUpDownSelectedAreaX1.ValueChanged += numericUpDownSelectedArea_ValueChanged;
            // 
            // label18
            // 
            resources.ApplyResources(label18, "label18");
            label18.Name = "label18";
            toolTip.SetToolTip(label18, resources.GetString("label18.ToolTip"));
            // 
            // numericUpDownSelectedAreaY1
            // 
            resources.ApplyResources(numericUpDownSelectedAreaY1, "numericUpDownSelectedAreaY1");
            numericUpDownSelectedAreaY1.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSelectedAreaY1.Name = "numericUpDownSelectedAreaY1";
            toolTip.SetToolTip(numericUpDownSelectedAreaY1, resources.GetString("numericUpDownSelectedAreaY1.ToolTip"));
            numericUpDownSelectedAreaY1.ValueChanged += numericUpDownSelectedArea_ValueChanged;
            // 
            // label19
            // 
            resources.ApplyResources(label19, "label19");
            label19.Name = "label19";
            toolTip.SetToolTip(label19, resources.GetString("label19.ToolTip"));
            // 
            // numericUpDownSelectedAreaX2
            // 
            resources.ApplyResources(numericUpDownSelectedAreaX2, "numericUpDownSelectedAreaX2");
            numericUpDownSelectedAreaX2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSelectedAreaX2.Name = "numericUpDownSelectedAreaX2";
            toolTip.SetToolTip(numericUpDownSelectedAreaX2, resources.GetString("numericUpDownSelectedAreaX2.ToolTip"));
            numericUpDownSelectedAreaX2.ValueChanged += numericUpDownSelectedArea_ValueChanged;
            // 
            // label20
            // 
            resources.ApplyResources(label20, "label20");
            label20.Name = "label20";
            toolTip.SetToolTip(label20, resources.GetString("label20.ToolTip"));
            // 
            // numericUpDownSelectedAreaY2
            // 
            resources.ApplyResources(numericUpDownSelectedAreaY2, "numericUpDownSelectedAreaY2");
            numericUpDownSelectedAreaY2.Maximum = new decimal(new int[] { 10000, 0, 0, 0 });
            numericUpDownSelectedAreaY2.Name = "numericUpDownSelectedAreaY2";
            toolTip.SetToolTip(numericUpDownSelectedAreaY2, resources.GetString("numericUpDownSelectedAreaY2.ToolTip"));
            numericUpDownSelectedAreaY2.ValueChanged += numericUpDownSelectedArea_ValueChanged;
            // 
            // label21
            // 
            resources.ApplyResources(label21, "label21");
            label21.Name = "label21";
            toolTip.SetToolTip(label21, resources.GetString("label21.ToolTip"));
            // 
            // label15
            // 
            resources.ApplyResources(label15, "label15");
            label15.Name = "label15";
            toolTip.SetToolTip(label15, resources.GetString("label15.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(label16, "label16");
            label16.Name = "label16";
            toolTip.SetToolTip(label16, resources.GetString("label16.ToolTip"));
            // 
            // toolStrip1
            // 
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.BackColor = SystemColors.Control;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { toolStripButtonIntensityTable, toolStripSeparator16, toolStripButtonAutoProcedure, toolStripSeparator15, toolStripButtonRing, toolStripSeparator14, toolStripButtonFindParameter, toolStripSeparator9, toolStripButtonFindParameterBruteForce, toolStripSeparator31, toolStripButtonUnroll, toolStripSeparator1, toolStripButtonCircumferentialBlur, toolStripSeparator17, toolStripButtonImageSequence, toolStripSeparator19 });
            toolStrip1.Name = "toolStrip1";
            toolStrip1.RenderMode = ToolStripRenderMode.System;
            toolTip.SetToolTip(toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // toolStripButtonIntensityTable
            // 
            resources.ApplyResources(toolStripButtonIntensityTable, "toolStripButtonIntensityTable");
            toolStripButtonIntensityTable.CheckOnClick = true;
            toolStripButtonIntensityTable.Image = Properties.Resources.Table;
            toolStripButtonIntensityTable.Name = "toolStripButtonIntensityTable";
            toolStripButtonIntensityTable.Padding = new Padding(1);
            // 
            // toolStripSeparator16
            // 
            resources.ApplyResources(toolStripSeparator16, "toolStripSeparator16");
            toolStripSeparator16.Name = "toolStripSeparator16";
            // 
            // toolStripButtonAutoProcedure
            // 
            resources.ApplyResources(toolStripButtonAutoProcedure, "toolStripButtonAutoProcedure");
            toolStripButtonAutoProcedure.CheckOnClick = true;
            toolStripButtonAutoProcedure.Image = Properties.Resources.AutoProc;
            toolStripButtonAutoProcedure.Name = "toolStripButtonAutoProcedure";
            toolStripButtonAutoProcedure.Padding = new Padding(1);
            toolStripButtonAutoProcedure.CheckedChanged += toolStripButtonAutoProcedure_CheckedChanged;
            // 
            // toolStripSeparator15
            // 
            resources.ApplyResources(toolStripSeparator15, "toolStripSeparator15");
            toolStripSeparator15.Name = "toolStripSeparator15";
            // 
            // toolStripButtonRing
            // 
            resources.ApplyResources(toolStripButtonRing, "toolStripButtonRing");
            toolStripButtonRing.CheckOnClick = true;
            toolStripButtonRing.Image = Properties.Resources.Ring;
            toolStripButtonRing.Name = "toolStripButtonRing";
            toolStripButtonRing.Padding = new Padding(1);
            toolStripButtonRing.CheckedChanged += toolStripButtonRing_CheckedChanged;
            // 
            // toolStripSeparator14
            // 
            resources.ApplyResources(toolStripSeparator14, "toolStripSeparator14");
            toolStripSeparator14.Name = "toolStripSeparator14";
            // 
            // toolStripButtonFindParameter
            // 
            resources.ApplyResources(toolStripButtonFindParameter, "toolStripButtonFindParameter");
            toolStripButtonFindParameter.CheckOnClick = true;
            toolStripButtonFindParameter.Image = Properties.Resources.FindParameter;
            toolStripButtonFindParameter.Name = "toolStripButtonFindParameter";
            toolStripButtonFindParameter.Padding = new Padding(1);
            toolStripButtonFindParameter.CheckedChanged += toolStripButtonFindParameter_CheckedChanged;
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(toolStripSeparator9, "toolStripSeparator9");
            toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // toolStripButtonFindParameterBruteForce
            // 
            resources.ApplyResources(toolStripButtonFindParameterBruteForce, "toolStripButtonFindParameterBruteForce");
            toolStripButtonFindParameterBruteForce.CheckOnClick = true;
            toolStripButtonFindParameterBruteForce.Image = Properties.Resources.FindParameter;
            toolStripButtonFindParameterBruteForce.Name = "toolStripButtonFindParameterBruteForce";
            toolStripButtonFindParameterBruteForce.Padding = new Padding(1);
            toolStripButtonFindParameterBruteForce.CheckedChanged += toolStripButtonFindParameterBruteForce_CheckedChanged;
            // 
            // toolStripSeparator31
            // 
            resources.ApplyResources(toolStripSeparator31, "toolStripSeparator31");
            toolStripSeparator31.Name = "toolStripSeparator31";
            // 
            // toolStripButtonUnroll
            // 
            resources.ApplyResources(toolStripButtonUnroll, "toolStripButtonUnroll");
            toolStripButtonUnroll.CheckOnClick = true;
            toolStripButtonUnroll.DoubleClickEnabled = true;
            toolStripButtonUnroll.Image = Properties.Resources.Unrolled;
            toolStripButtonUnroll.Name = "toolStripButtonUnroll";
            toolStripButtonUnroll.CheckedChanged += toolStripSplitButtonUnroll_CheckChanged;
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripButtonCircumferentialBlur
            // 
            resources.ApplyResources(toolStripButtonCircumferentialBlur, "toolStripButtonCircumferentialBlur");
            toolStripButtonCircumferentialBlur.Image = Properties.Resources.Unrolled;
            toolStripButtonCircumferentialBlur.Name = "toolStripButtonCircumferentialBlur";
            toolStripButtonCircumferentialBlur.Click += toolStripButtonCircumferentialBlur_Click;
            // 
            // toolStripSeparator17
            // 
            resources.ApplyResources(toolStripSeparator17, "toolStripSeparator17");
            toolStripSeparator17.Name = "toolStripSeparator17";
            // 
            // toolStripButtonImageSequence
            // 
            resources.ApplyResources(toolStripButtonImageSequence, "toolStripButtonImageSequence");
            toolStripButtonImageSequence.CheckOnClick = true;
            toolStripButtonImageSequence.Image = Properties.Resources.Sequence;
            toolStripButtonImageSequence.Name = "toolStripButtonImageSequence";
            toolStripButtonImageSequence.CheckedChanged += toolStripButtonImageSequence_CheckedChanged;
            // 
            // toolStripSeparator19
            // 
            resources.ApplyResources(toolStripSeparator19, "toolStripSeparator19");
            toolStripSeparator19.Name = "toolStripSeparator19";
            // 
            // menuStrip
            // 
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.GripStyle = ToolStripGripStyle.Visible;
            menuStrip.ImageScalingSize = new Size(20, 20);
            menuStrip.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, toolToolStripMenuItem, toolStripMenuItem5, optionToolStripMenuItem, languageToolStripMenuItem, macroToolStripMenuItem, helpToolStripMenuItem });
            menuStrip.Name = "menuStrip";
            toolTip.SetToolTip(menuStrip, resources.GetString("menuStrip.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { readImageToolStripMenuItem, toolStripMenuItemSaveImage, toolStripSeparator3, toolStripMenuItemReadParameter, toolStripMenuItemSaveParameter, toolStripSeparator13, toolStripMenuItemReadMask, toolStripMenuItemSaveMask, clearMaskToolStripMenuItem, toolStripSeparator4, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // readImageToolStripMenuItem
            // 
            resources.ApplyResources(readImageToolStripMenuItem, "readImageToolStripMenuItem");
            readImageToolStripMenuItem.Name = "readImageToolStripMenuItem";
            readImageToolStripMenuItem.Click += readImageToolStripMenuItem_Click;
            // 
            // toolStripMenuItemSaveImage
            // 
            resources.ApplyResources(toolStripMenuItemSaveImage, "toolStripMenuItemSaveImage");
            toolStripMenuItemSaveImage.DropDownItems.AddRange(new ToolStripItem[] { tiffToolStripMenuItem, pngToolStripMenuItem, ipaToolStripMenuItem });
            toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            // 
            // tiffToolStripMenuItem
            // 
            resources.ApplyResources(tiffToolStripMenuItem, "tiffToolStripMenuItem");
            tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            tiffToolStripMenuItem.Click += tiffToolStripMenuItem_Click;
            // 
            // pngToolStripMenuItem
            // 
            resources.ApplyResources(pngToolStripMenuItem, "pngToolStripMenuItem");
            pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            pngToolStripMenuItem.Click += pngToolStripMenuItem_Click;
            // 
            // ipaToolStripMenuItem
            // 
            resources.ApplyResources(ipaToolStripMenuItem, "ipaToolStripMenuItem");
            ipaToolStripMenuItem.Name = "ipaToolStripMenuItem";
            ipaToolStripMenuItem.Click += ipaToolStripMenuItem_Click;
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(toolStripSeparator3, "toolStripSeparator3");
            toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripMenuItemReadParameter
            // 
            resources.ApplyResources(toolStripMenuItemReadParameter, "toolStripMenuItemReadParameter");
            toolStripMenuItemReadParameter.Name = "toolStripMenuItemReadParameter";
            toolStripMenuItemReadParameter.Click += toolStripMenuItemReadParameter_Click;
            // 
            // toolStripMenuItemSaveParameter
            // 
            resources.ApplyResources(toolStripMenuItemSaveParameter, "toolStripMenuItemSaveParameter");
            toolStripMenuItemSaveParameter.Name = "toolStripMenuItemSaveParameter";
            toolStripMenuItemSaveParameter.Click += toolStripMenuItemSaveParameter_Click;
            // 
            // toolStripSeparator13
            // 
            resources.ApplyResources(toolStripSeparator13, "toolStripSeparator13");
            toolStripSeparator13.Name = "toolStripSeparator13";
            // 
            // toolStripMenuItemReadMask
            // 
            resources.ApplyResources(toolStripMenuItemReadMask, "toolStripMenuItemReadMask");
            toolStripMenuItemReadMask.Name = "toolStripMenuItemReadMask";
            toolStripMenuItemReadMask.Click += toolStripMenuItemReadMask_Click;
            // 
            // toolStripMenuItemSaveMask
            // 
            resources.ApplyResources(toolStripMenuItemSaveMask, "toolStripMenuItemSaveMask");
            toolStripMenuItemSaveMask.Name = "toolStripMenuItemSaveMask";
            toolStripMenuItemSaveMask.Click += toolStripMenuItemSaveMask_Click;
            // 
            // clearMaskToolStripMenuItem
            // 
            resources.ApplyResources(clearMaskToolStripMenuItem, "clearMaskToolStripMenuItem");
            clearMaskToolStripMenuItem.Name = "clearMaskToolStripMenuItem";
            clearMaskToolStripMenuItem.Click += clearMaskToolStripMenuItem_Click;
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(toolStripSeparator4, "toolStripSeparator4");
            toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // toolToolStripMenuItem
            // 
            resources.ApplyResources(toolToolStripMenuItem, "toolToolStripMenuItem");
            toolToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { resetFrequencyProfileToolStripMenuItem, calibrateRaxisImageToolStripMenuItem });
            toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            // 
            // resetFrequencyProfileToolStripMenuItem
            // 
            resources.ApplyResources(resetFrequencyProfileToolStripMenuItem, "resetFrequencyProfileToolStripMenuItem");
            resetFrequencyProfileToolStripMenuItem.Name = "resetFrequencyProfileToolStripMenuItem";
            resetFrequencyProfileToolStripMenuItem.Click += resetFrequencyProfileToolStripMenuItem_Click;
            // 
            // calibrateRaxisImageToolStripMenuItem
            // 
            resources.ApplyResources(calibrateRaxisImageToolStripMenuItem, "calibrateRaxisImageToolStripMenuItem");
            calibrateRaxisImageToolStripMenuItem.Name = "calibrateRaxisImageToolStripMenuItem";
            calibrateRaxisImageToolStripMenuItem.Click += calibrateRaxisImageToolStripMenuItem_Click;
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(toolStripMenuItem5, "toolStripMenuItem5");
            toolStripMenuItem5.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemPropertyWaveSource, toolStripMenuItem9, toolStripSeparator22, toolStripMenuItem10, toolStripMenuItem11, toolStripSeparator23, toolStripMenuItem12, toolStripSeparator24, toolStripMenuItem13, toolStripSeparator25, toolStripMenuItem14, toolStripSeparator26, toolStripMenuItem15, toolStripSeparator18, misToolStripMenuItem });
            toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // toolStripMenuItemPropertyWaveSource
            // 
            resources.ApplyResources(toolStripMenuItemPropertyWaveSource, "toolStripMenuItemPropertyWaveSource");
            toolStripMenuItemPropertyWaveSource.Name = "toolStripMenuItemPropertyWaveSource";
            toolStripMenuItemPropertyWaveSource.Click += toolStripMenuItemWaveSource_Click;
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(toolStripMenuItem9, "toolStripMenuItem9");
            toolStripMenuItem9.Name = "toolStripMenuItem9";
            toolStripMenuItem9.Click += toolStripMenuItemIPCondition_Click;
            // 
            // toolStripSeparator22
            // 
            resources.ApplyResources(toolStripSeparator22, "toolStripSeparator22");
            toolStripSeparator22.Name = "toolStripSeparator22";
            // 
            // toolStripMenuItem10
            // 
            resources.ApplyResources(toolStripMenuItem10, "toolStripMenuItem10");
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Click += toolStripMenuItemIntegralRegion_Click;
            // 
            // toolStripMenuItem11
            // 
            resources.ApplyResources(toolStripMenuItem11, "toolStripMenuItem11");
            toolStripMenuItem11.Name = "toolStripMenuItem11";
            toolStripMenuItem11.Click += toolStripMenuItemIntegralProperty_Click;
            // 
            // toolStripSeparator23
            // 
            resources.ApplyResources(toolStripSeparator23, "toolStripSeparator23");
            toolStripSeparator23.Name = "toolStripSeparator23";
            // 
            // toolStripMenuItem12
            // 
            resources.ApplyResources(toolStripMenuItem12, "toolStripMenuItem12");
            toolStripMenuItem12.Name = "toolStripMenuItem12";
            toolStripMenuItem12.Click += toolStripMenuItemManualMaskMode_Click;
            // 
            // toolStripSeparator24
            // 
            resources.ApplyResources(toolStripSeparator24, "toolStripSeparator24");
            toolStripSeparator24.Name = "toolStripSeparator24";
            // 
            // toolStripMenuItem13
            // 
            resources.ApplyResources(toolStripMenuItem13, "toolStripMenuItem13");
            toolStripMenuItem13.Name = "toolStripMenuItem13";
            toolStripMenuItem13.Click += toolStripMenuItemAfterGetProfile_Click;
            // 
            // toolStripSeparator25
            // 
            resources.ApplyResources(toolStripSeparator25, "toolStripSeparator25");
            toolStripSeparator25.Name = "toolStripSeparator25";
            // 
            // toolStripMenuItem14
            // 
            resources.ApplyResources(toolStripMenuItem14, "toolStripMenuItem14");
            toolStripMenuItem14.Name = "toolStripMenuItem14";
            toolStripMenuItem14.Click += toolStripMenuItemUnrolledImage_Click;
            // 
            // toolStripSeparator26
            // 
            resources.ApplyResources(toolStripSeparator26, "toolStripSeparator26");
            toolStripSeparator26.Name = "toolStripSeparator26";
            // 
            // toolStripMenuItem15
            // 
            resources.ApplyResources(toolStripMenuItem15, "toolStripMenuItem15");
            toolStripMenuItem15.Name = "toolStripMenuItem15";
            toolStripMenuItem15.Click += toolStripMenuItemAssociatedExtensions_Click;
            // 
            // toolStripSeparator18
            // 
            resources.ApplyResources(toolStripSeparator18, "toolStripSeparator18");
            toolStripSeparator18.Name = "toolStripSeparator18";
            // 
            // misToolStripMenuItem
            // 
            resources.ApplyResources(misToolStripMenuItem, "misToolStripMenuItem");
            misToolStripMenuItem.Name = "misToolStripMenuItem";
            misToolStripMenuItem.Click += toolStripMenuItemMiscellaneous_Click;
            // 
            // optionToolStripMenuItem
            // 
            resources.ApplyResources(optionToolStripMenuItem, "optionToolStripMenuItem");
            optionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolTipToolStripMenuItem, toolStripMenuItem2, rotateToolStripMenuItem, toolStripSeparator28, ngenCompileToolStripMenuItem, clearRegistrycheckAndRestartToolStripMenuItem });
            optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            // 
            // toolTipToolStripMenuItem
            // 
            resources.ApplyResources(toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            toolTipToolStripMenuItem.Checked = true;
            toolTipToolStripMenuItem.CheckOnClick = true;
            toolTipToolStripMenuItem.CheckState = CheckState.Checked;
            toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(toolStripMenuItem2, "toolStripMenuItem2");
            toolStripMenuItem2.DropDownItems.AddRange(new ToolStripItem[] { flipHorizontallyToolStripMenuItem, flipVerticallyToolStripMenuItem });
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            resources.ApplyResources(flipHorizontallyToolStripMenuItem, "flipHorizontallyToolStripMenuItem");
            flipHorizontallyToolStripMenuItem.CheckOnClick = true;
            flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            flipHorizontallyToolStripMenuItem.CheckedChanged += flipHorizontallyToolStripMenuItem_CheckedChanged;
            // 
            // flipVerticallyToolStripMenuItem
            // 
            resources.ApplyResources(flipVerticallyToolStripMenuItem, "flipVerticallyToolStripMenuItem");
            flipVerticallyToolStripMenuItem.CheckOnClick = true;
            flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            flipVerticallyToolStripMenuItem.CheckedChanged += flipVerticallyToolStripMenuItem_CheckedChanged;
            // 
            // rotateToolStripMenuItem
            // 
            resources.ApplyResources(rotateToolStripMenuItem, "rotateToolStripMenuItem");
            rotateToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { toolStripComboBoxRotate });
            rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            // 
            // toolStripComboBoxRotate
            // 
            resources.ApplyResources(toolStripComboBoxRotate, "toolStripComboBoxRotate");
            toolStripComboBoxRotate.DropDownStyle = ComboBoxStyle.DropDownList;
            toolStripComboBoxRotate.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxRotate.Items"), resources.GetString("toolStripComboBoxRotate.Items1"), resources.GetString("toolStripComboBoxRotate.Items2"), resources.GetString("toolStripComboBoxRotate.Items3") });
            toolStripComboBoxRotate.Name = "toolStripComboBoxRotate";
            toolStripComboBoxRotate.SelectedIndexChanged += toolStripComboBoxRotate_SelectedIndexChanged;
            // 
            // toolStripSeparator28
            // 
            resources.ApplyResources(toolStripSeparator28, "toolStripSeparator28");
            toolStripSeparator28.Name = "toolStripSeparator28";
            // 
            // ngenCompileToolStripMenuItem
            // 
            resources.ApplyResources(ngenCompileToolStripMenuItem, "ngenCompileToolStripMenuItem");
            ngenCompileToolStripMenuItem.Name = "ngenCompileToolStripMenuItem";
            // 
            // clearRegistrycheckAndRestartToolStripMenuItem
            // 
            resources.ApplyResources(clearRegistrycheckAndRestartToolStripMenuItem, "clearRegistrycheckAndRestartToolStripMenuItem");
            clearRegistrycheckAndRestartToolStripMenuItem.CheckOnClick = true;
            clearRegistrycheckAndRestartToolStripMenuItem.Name = "clearRegistrycheckAndRestartToolStripMenuItem";
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            languageToolStripMenuItem.Alignment = ToolStripItemAlignment.Right;
            languageToolStripMenuItem.Checked = true;
            languageToolStripMenuItem.CheckOnClick = true;
            languageToolStripMenuItem.CheckState = CheckState.Checked;
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishToolStripMenuItem, japaneseToolStripMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(englishToolStripMenuItem, "englishToolStripMenuItem");
            englishToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.CheckState = CheckState.Checked;
            englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            englishToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            japaneseToolStripMenuItem.Click += languageToolStripMenuItem_Click;
            // 
            // macroToolStripMenuItem
            // 
            resources.ApplyResources(macroToolStripMenuItem, "macroToolStripMenuItem");
            macroToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { editorToolStripMenuItem, toolStripSeparator27 });
            macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            // 
            // editorToolStripMenuItem
            // 
            resources.ApplyResources(editorToolStripMenuItem, "editorToolStripMenuItem");
            editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            editorToolStripMenuItem.Click += editorToolStripMenuItem_Click;
            // 
            // toolStripSeparator27
            // 
            resources.ApplyResources(toolStripSeparator27, "toolStripSeparator27");
            toolStripSeparator27.Name = "toolStripSeparator27";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { programUpdatesToolStripMenuItem, toolStripSeparator30, hintToolStripMenuItem, licenseToolStripMenuItem, versionHistoryToolStripMenuItem, toolStripSeparator29, webPageToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // programUpdatesToolStripMenuItem
            // 
            resources.ApplyResources(programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            programUpdatesToolStripMenuItem.Click += programUpdatesToolStripMenuItem_Click;
            // 
            // toolStripSeparator30
            // 
            resources.ApplyResources(toolStripSeparator30, "toolStripSeparator30");
            toolStripSeparator30.Name = "toolStripSeparator30";
            // 
            // hintToolStripMenuItem
            // 
            resources.ApplyResources(hintToolStripMenuItem, "hintToolStripMenuItem");
            hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            hintToolStripMenuItem.Click += hintToolStripMenuItem_Click;
            // 
            // licenseToolStripMenuItem
            // 
            resources.ApplyResources(licenseToolStripMenuItem, "licenseToolStripMenuItem");
            licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            licenseToolStripMenuItem.Click += licenseToolStripMenuItem_Click;
            // 
            // versionHistoryToolStripMenuItem
            // 
            resources.ApplyResources(versionHistoryToolStripMenuItem, "versionHistoryToolStripMenuItem");
            versionHistoryToolStripMenuItem.Name = "versionHistoryToolStripMenuItem";
            versionHistoryToolStripMenuItem.Click += versionHistoryToolStripMenuItem_Click;
            // 
            // toolStripSeparator29
            // 
            resources.ApplyResources(toolStripSeparator29, "toolStripSeparator29");
            toolStripSeparator29.Name = "toolStripSeparator29";
            // 
            // webPageToolStripMenuItem
            // 
            resources.ApplyResources(webPageToolStripMenuItem, "webPageToolStripMenuItem");
            webPageToolStripMenuItem.Name = "webPageToolStripMenuItem";
            webPageToolStripMenuItem.Click += webPageToolStripMenuItem_Click;
            // 
            // toolStrip2
            // 
            resources.ApplyResources(toolStrip2, "toolStrip2");
            toolStrip2.BackColor = SystemColors.Control;
            toolStrip2.GripMargin = new Padding(0);
            toolStrip2.ImageScalingSize = new Size(20, 20);
            toolStrip2.Items.AddRange(new ToolStripItem[] { toolStripSplitButtonBackground, toolStripSeparator8, toolStripSplitButtonFindCenter, toolStripButtonFixCenter, toolStripSeparator6, toolStripSplitButtonFindSpots, toolStripButtonManualSpotMode, toolStripComboBoxManualSpotSize, toolStripSeparator2, toolStripSplitButtonGetProfile });
            toolStrip2.Name = "toolStrip2";
            toolStrip2.Stretch = true;
            toolTip.SetToolTip(toolStrip2, resources.GetString("toolStrip2.ToolTip"));
            // 
            // toolStripSplitButtonBackground
            // 
            resources.ApplyResources(toolStripSplitButtonBackground, "toolStripSplitButtonBackground");
            toolStripSplitButtonBackground.AutoToolTip = false;
            toolStripSplitButtonBackground.DropDownButtonWidth = 18;
            toolStripSplitButtonBackground.DropDownItems.AddRange(new ToolStripItem[] { resetToolStripMenuItem, toolStripMenuItem4, fourierToolStripMenuItem, toolStripMenuItemReferenceBackground });
            toolStripSplitButtonBackground.ForeColor = SystemColors.ControlText;
            toolStripSplitButtonBackground.Image = Properties.Resources.BackGround;
            toolStripSplitButtonBackground.Margin = new Padding(0);
            toolStripSplitButtonBackground.Name = "toolStripSplitButtonBackground";
            toolStripSplitButtonBackground.ButtonClick += toolStripSplitButtonBackground_ButtonClick;
            // 
            // resetToolStripMenuItem
            // 
            resources.ApplyResources(resetToolStripMenuItem, "resetToolStripMenuItem");
            resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resetToolStripMenuItem.Click += resetBackgroundToolStripMenuItem_Click;
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(toolStripMenuItem4, "toolStripMenuItem4");
            toolStripMenuItem4.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem6, toolStripComboBoxBackgroundLower, toolStripMenuItem7, toolStripComboBoxBackgroundUpper });
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(toolStripMenuItem6, "toolStripMenuItem6");
            toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // toolStripComboBoxBackgroundLower
            // 
            resources.ApplyResources(toolStripComboBoxBackgroundLower, "toolStripComboBoxBackgroundLower");
            toolStripComboBoxBackgroundLower.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxBackgroundLower.Items"), resources.GetString("toolStripComboBoxBackgroundLower.Items1"), resources.GetString("toolStripComboBoxBackgroundLower.Items2"), resources.GetString("toolStripComboBoxBackgroundLower.Items3"), resources.GetString("toolStripComboBoxBackgroundLower.Items4"), resources.GetString("toolStripComboBoxBackgroundLower.Items5") });
            toolStripComboBoxBackgroundLower.Name = "toolStripComboBoxBackgroundLower";
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(toolStripMenuItem7, "toolStripMenuItem7");
            toolStripMenuItem7.Name = "toolStripMenuItem7";
            // 
            // toolStripComboBoxBackgroundUpper
            // 
            resources.ApplyResources(toolStripComboBoxBackgroundUpper, "toolStripComboBoxBackgroundUpper");
            toolStripComboBoxBackgroundUpper.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxBackgroundUpper.Items"), resources.GetString("toolStripComboBoxBackgroundUpper.Items1"), resources.GetString("toolStripComboBoxBackgroundUpper.Items2"), resources.GetString("toolStripComboBoxBackgroundUpper.Items3"), resources.GetString("toolStripComboBoxBackgroundUpper.Items4") });
            toolStripComboBoxBackgroundUpper.Name = "toolStripComboBoxBackgroundUpper";
            // 
            // fourierToolStripMenuItem
            // 
            resources.ApplyResources(fourierToolStripMenuItem, "fourierToolStripMenuItem");
            fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            // 
            // toolStripMenuItemReferenceBackground
            // 
            resources.ApplyResources(toolStripMenuItemReferenceBackground, "toolStripMenuItemReferenceBackground");
            toolStripMenuItemReferenceBackground.Name = "toolStripMenuItemReferenceBackground";
            toolStripMenuItemReferenceBackground.Click += ToolStripMenuItemReferenceBackground_Click;
            // 
            // toolStripSeparator8
            // 
            resources.ApplyResources(toolStripSeparator8, "toolStripSeparator8");
            toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // toolStripSplitButtonFindCenter
            // 
            resources.ApplyResources(toolStripSplitButtonFindCenter, "toolStripSplitButtonFindCenter");
            toolStripSplitButtonFindCenter.DropDownButtonWidth = 18;
            toolStripSplitButtonFindCenter.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemFindCenterOption, findCenterBasedOnTheRingToolStripMenuItem });
            toolStripSplitButtonFindCenter.Image = Properties.Resources.Center;
            toolStripSplitButtonFindCenter.Margin = new Padding(0);
            toolStripSplitButtonFindCenter.Name = "toolStripSplitButtonFindCenter";
            toolStripSplitButtonFindCenter.ButtonClick += toolStripSplitButtonFindCenter_ButtonClick;
            // 
            // toolStripMenuItemFindCenterOption
            // 
            resources.ApplyResources(toolStripMenuItemFindCenterOption, "toolStripMenuItemFindCenterOption");
            toolStripMenuItemFindCenterOption.Name = "toolStripMenuItemFindCenterOption";
            toolStripMenuItemFindCenterOption.Click += toolStripMenuItemMiscellaneous_Click;
            // 
            // findCenterBasedOnTheRingToolStripMenuItem
            // 
            resources.ApplyResources(findCenterBasedOnTheRingToolStripMenuItem, "findCenterBasedOnTheRingToolStripMenuItem");
            findCenterBasedOnTheRingToolStripMenuItem.Name = "findCenterBasedOnTheRingToolStripMenuItem";
            // 
            // toolStripButtonFixCenter
            // 
            resources.ApplyResources(toolStripButtonFixCenter, "toolStripButtonFixCenter");
            toolStripButtonFixCenter.CheckOnClick = true;
            toolStripButtonFixCenter.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonFixCenter.ForeColor = Color.Gray;
            toolStripButtonFixCenter.Name = "toolStripButtonFixCenter";
            toolStripButtonFixCenter.CheckedChanged += toolStripButtonFixCenter_CheckedChanged;
            toolStripButtonFixCenter.Click += toolStripButtonFixCenter_Click;
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(toolStripSeparator6, "toolStripSeparator6");
            toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // toolStripSplitButtonFindSpots
            // 
            resources.ApplyResources(toolStripSplitButtonFindSpots, "toolStripSplitButtonFindSpots");
            toolStripSplitButtonFindSpots.DropDownButtonWidth = 18;
            toolStripSplitButtonFindSpots.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemClearMask, toolStripMenuItemMaskAll, inverseMaskToolStripMenuItem, toolStripSeparator5, toolStripMenuItemFindSpotsManual, toolStripSeparator10, toolStripMenuItemFindSpotsOption });
            toolStripSplitButtonFindSpots.ForeColor = Color.Black;
            toolStripSplitButtonFindSpots.Image = Properties.Resources.Spot;
            toolStripSplitButtonFindSpots.Margin = new Padding(0);
            toolStripSplitButtonFindSpots.Name = "toolStripSplitButtonFindSpots";
            toolStripSplitButtonFindSpots.ButtonClick += toolStripSplitButtonFindSpots_ButtonClick;
            // 
            // toolStripMenuItemClearMask
            // 
            resources.ApplyResources(toolStripMenuItemClearMask, "toolStripMenuItemClearMask");
            toolStripMenuItemClearMask.Name = "toolStripMenuItemClearMask";
            toolStripMenuItemClearMask.Click += toolStripMenuItemClearSpots_Click;
            // 
            // toolStripMenuItemMaskAll
            // 
            resources.ApplyResources(toolStripMenuItemMaskAll, "toolStripMenuItemMaskAll");
            toolStripMenuItemMaskAll.Name = "toolStripMenuItemMaskAll";
            toolStripMenuItemMaskAll.Click += toolStripMenuItemMaskAll_Click;
            // 
            // inverseMaskToolStripMenuItem
            // 
            resources.ApplyResources(inverseMaskToolStripMenuItem, "inverseMaskToolStripMenuItem");
            inverseMaskToolStripMenuItem.Name = "inverseMaskToolStripMenuItem";
            inverseMaskToolStripMenuItem.Click += inverseMaskToolStripMenuItem_Click;
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(toolStripSeparator5, "toolStripSeparator5");
            toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // toolStripMenuItemFindSpotsManual
            // 
            resources.ApplyResources(toolStripMenuItemFindSpotsManual, "toolStripMenuItemFindSpotsManual");
            toolStripMenuItemFindSpotsManual.Name = "toolStripMenuItemFindSpotsManual";
            // 
            // toolStripSeparator10
            // 
            resources.ApplyResources(toolStripSeparator10, "toolStripSeparator10");
            toolStripSeparator10.Name = "toolStripSeparator10";
            // 
            // toolStripMenuItemFindSpotsOption
            // 
            resources.ApplyResources(toolStripMenuItemFindSpotsOption, "toolStripMenuItemFindSpotsOption");
            toolStripMenuItemFindSpotsOption.Name = "toolStripMenuItemFindSpotsOption";
            toolStripMenuItemFindSpotsOption.Click += toolStripMenuItemManualMaskMode_Click;
            // 
            // toolStripButtonManualSpotMode
            // 
            resources.ApplyResources(toolStripButtonManualSpotMode, "toolStripButtonManualSpotMode");
            toolStripButtonManualSpotMode.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripButtonManualSpotMode.ForeColor = Color.Gray;
            toolStripButtonManualSpotMode.MergeIndex = 3;
            toolStripButtonManualSpotMode.Name = "toolStripButtonManualSpotMode";
            toolStripButtonManualSpotMode.CheckedChanged += toolStripButtonManualSpotMode_CheckedChanged;
            toolStripButtonManualSpotMode.Click += toolStripButtonManualSpotMode_Click;
            // 
            // toolStripComboBoxManualSpotSize
            // 
            resources.ApplyResources(toolStripComboBoxManualSpotSize, "toolStripComboBoxManualSpotSize");
            toolStripComboBoxManualSpotSize.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxManualSpotSize.Items"), resources.GetString("toolStripComboBoxManualSpotSize.Items1"), resources.GetString("toolStripComboBoxManualSpotSize.Items2"), resources.GetString("toolStripComboBoxManualSpotSize.Items3"), resources.GetString("toolStripComboBoxManualSpotSize.Items4"), resources.GetString("toolStripComboBoxManualSpotSize.Items5"), resources.GetString("toolStripComboBoxManualSpotSize.Items6"), resources.GetString("toolStripComboBoxManualSpotSize.Items7"), resources.GetString("toolStripComboBoxManualSpotSize.Items8") });
            toolStripComboBoxManualSpotSize.Name = "toolStripComboBoxManualSpotSize";
            toolStripComboBoxManualSpotSize.TextChanged += toolStripComboBoxManualSpotSize_TextChanged;
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripSplitButtonGetProfile
            // 
            resources.ApplyResources(toolStripSplitButtonGetProfile, "toolStripSplitButtonGetProfile");
            toolStripSplitButtonGetProfile.DropDownButtonWidth = 18;
            toolStripSplitButtonGetProfile.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItemGetProfileIntegralProperty, toolStripMenuItemConcenctricIntegration, toolStripMenuItemRadialIntegration, toolStripSeparator7, toolStripMenuItemGetProfileIntegralRegion, toolStripSeparator11, findCenterBeforeGetProfileToolStripMenuItem, findSpotsBeforeGetProfileToolStripMenuItem, toolStripSeparator21, toolStripMenuItemSendProfileToPDIndexer, toolStripMenuItemSendUnrolledImage, toolStripSeparator12, toolStripMenuItemAzimuthalDivisionAnalysis, toolStripSeparator20, toolStripMenuItemAllSequentialImages, toolStripMenuItemSelectedSequentialImages });
            toolStripSplitButtonGetProfile.ForeColor = SystemColors.ControlText;
            toolStripSplitButtonGetProfile.Image = Properties.Resources.Profile;
            toolStripSplitButtonGetProfile.Name = "toolStripSplitButtonGetProfile";
            toolStripSplitButtonGetProfile.ButtonClick += toolStripSplitButtonGetProfileButtonClick;
            // 
            // toolStripMenuItemGetProfileIntegralProperty
            // 
            resources.ApplyResources(toolStripMenuItemGetProfileIntegralProperty, "toolStripMenuItemGetProfileIntegralProperty");
            toolStripMenuItemGetProfileIntegralProperty.DisplayStyle = ToolStripItemDisplayStyle.Text;
            toolStripMenuItemGetProfileIntegralProperty.Name = "toolStripMenuItemGetProfileIntegralProperty";
            toolStripMenuItemGetProfileIntegralProperty.Click += toolStripMenuItemIntegralProperty_Click;
            // 
            // toolStripMenuItemConcenctricIntegration
            // 
            resources.ApplyResources(toolStripMenuItemConcenctricIntegration, "toolStripMenuItemConcenctricIntegration");
            toolStripMenuItemConcenctricIntegration.Checked = true;
            toolStripMenuItemConcenctricIntegration.CheckState = CheckState.Checked;
            toolStripMenuItemConcenctricIntegration.Name = "toolStripMenuItemConcenctricIntegration";
            toolStripMenuItemConcenctricIntegration.Click += toolStripMenuItemConcenctricIntegration_Click;
            // 
            // toolStripMenuItemRadialIntegration
            // 
            resources.ApplyResources(toolStripMenuItemRadialIntegration, "toolStripMenuItemRadialIntegration");
            toolStripMenuItemRadialIntegration.Name = "toolStripMenuItemRadialIntegration";
            toolStripMenuItemRadialIntegration.Click += toolStripMenuItemRadialIntegration_Click;
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(toolStripSeparator7, "toolStripSeparator7");
            toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // toolStripMenuItemGetProfileIntegralRegion
            // 
            resources.ApplyResources(toolStripMenuItemGetProfileIntegralRegion, "toolStripMenuItemGetProfileIntegralRegion");
            toolStripMenuItemGetProfileIntegralRegion.Name = "toolStripMenuItemGetProfileIntegralRegion";
            toolStripMenuItemGetProfileIntegralRegion.Click += toolStripMenuItemIntegralRegion_Click;
            // 
            // toolStripSeparator11
            // 
            resources.ApplyResources(toolStripSeparator11, "toolStripSeparator11");
            toolStripSeparator11.Name = "toolStripSeparator11";
            // 
            // findCenterBeforeGetProfileToolStripMenuItem
            // 
            resources.ApplyResources(findCenterBeforeGetProfileToolStripMenuItem, "findCenterBeforeGetProfileToolStripMenuItem");
            findCenterBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            findCenterBeforeGetProfileToolStripMenuItem.Checked = true;
            findCenterBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            findCenterBeforeGetProfileToolStripMenuItem.CheckState = CheckState.Checked;
            findCenterBeforeGetProfileToolStripMenuItem.Name = "findCenterBeforeGetProfileToolStripMenuItem";
            // 
            // findSpotsBeforeGetProfileToolStripMenuItem
            // 
            resources.ApplyResources(findSpotsBeforeGetProfileToolStripMenuItem, "findSpotsBeforeGetProfileToolStripMenuItem");
            findSpotsBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            findSpotsBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            findSpotsBeforeGetProfileToolStripMenuItem.Name = "findSpotsBeforeGetProfileToolStripMenuItem";
            // 
            // toolStripSeparator21
            // 
            resources.ApplyResources(toolStripSeparator21, "toolStripSeparator21");
            toolStripSeparator21.Name = "toolStripSeparator21";
            // 
            // toolStripMenuItemSendProfileToPDIndexer
            // 
            resources.ApplyResources(toolStripMenuItemSendProfileToPDIndexer, "toolStripMenuItemSendProfileToPDIndexer");
            toolStripMenuItemSendProfileToPDIndexer.Checked = true;
            toolStripMenuItemSendProfileToPDIndexer.CheckState = CheckState.Checked;
            toolStripMenuItemSendProfileToPDIndexer.Name = "toolStripMenuItemSendProfileToPDIndexer";
            toolStripMenuItemSendProfileToPDIndexer.Click += toolStripMenuItemSendProfileToPDIndexer_Click;
            // 
            // toolStripMenuItemSendUnrolledImage
            // 
            resources.ApplyResources(toolStripMenuItemSendUnrolledImage, "toolStripMenuItemSendUnrolledImage");
            toolStripMenuItemSendUnrolledImage.Name = "toolStripMenuItemSendUnrolledImage";
            toolStripMenuItemSendUnrolledImage.Click += toolStripMenuItemSendUnrolledImage_Click;
            // 
            // toolStripSeparator12
            // 
            resources.ApplyResources(toolStripSeparator12, "toolStripSeparator12");
            toolStripSeparator12.Name = "toolStripSeparator12";
            // 
            // toolStripMenuItemAzimuthalDivisionAnalysis
            // 
            resources.ApplyResources(toolStripMenuItemAzimuthalDivisionAnalysis, "toolStripMenuItemAzimuthalDivisionAnalysis");
            toolStripMenuItemAzimuthalDivisionAnalysis.CheckOnClick = true;
            toolStripMenuItemAzimuthalDivisionAnalysis.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem1, toolStripComboBoxAzimuthalDivisionNumber });
            toolStripMenuItemAzimuthalDivisionAnalysis.Name = "toolStripMenuItemAzimuthalDivisionAnalysis";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(toolStripMenuItem1, "toolStripMenuItem1");
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripComboBoxAzimuthalDivisionNumber
            // 
            resources.ApplyResources(toolStripComboBoxAzimuthalDivisionNumber, "toolStripComboBoxAzimuthalDivisionNumber");
            toolStripComboBoxAzimuthalDivisionNumber.Items.AddRange(new object[] { resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items1"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items2"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items3"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items4"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items5"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items6"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items7"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items8"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items9"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items10"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items11"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items12"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items13"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items14"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items15"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items16"), resources.GetString("toolStripComboBoxAzimuthalDivisionNumber.Items17") });
            toolStripComboBoxAzimuthalDivisionNumber.Name = "toolStripComboBoxAzimuthalDivisionNumber";
            // 
            // toolStripSeparator20
            // 
            resources.ApplyResources(toolStripSeparator20, "toolStripSeparator20");
            toolStripSeparator20.Name = "toolStripSeparator20";
            // 
            // toolStripMenuItemAllSequentialImages
            // 
            resources.ApplyResources(toolStripMenuItemAllSequentialImages, "toolStripMenuItemAllSequentialImages");
            toolStripMenuItemAllSequentialImages.CheckOnClick = true;
            toolStripMenuItemAllSequentialImages.Name = "toolStripMenuItemAllSequentialImages";
            toolStripMenuItemAllSequentialImages.CheckedChanged += toolStripMenuItemAllSequentialImages_CheckedChanged;
            // 
            // toolStripMenuItemSelectedSequentialImages
            // 
            resources.ApplyResources(toolStripMenuItemSelectedSequentialImages, "toolStripMenuItemSelectedSequentialImages");
            toolStripMenuItemSelectedSequentialImages.CheckOnClick = true;
            toolStripMenuItemSelectedSequentialImages.Name = "toolStripMenuItemSelectedSequentialImages";
            toolStripMenuItemSelectedSequentialImages.CheckedChanged += toolStripMenuItemSelectedSequentialImages_CheckedChanged;
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(toolStripButton1, "toolStripButton1");
            toolStripButton1.Name = "toolStripButton1";
            // 
            // toolTip
            // 
            toolTip.IsBalloon = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            AllowDrop = true;
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(toolStripContainer1);
            KeyPreview = true;
            MainMenuStrip = menuStrip;
            Name = "FormMain";
            toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            FormClosing += FormMain_FormClosing;
            FormClosed += FormMain_FormClosed;
            Load += FormMain_Load;
            DragDrop += FormMain_DragDrop;
            DragEnter += FormMain_DragEnter;
            KeyDown += FormMain_KeyDown;
            KeyUp += FormMain_KeyUp;
            Resize += FormMain_Resize;
            toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            toolStripContainer1.BottomToolStripPanel.PerformLayout();
            toolStripContainer1.ContentPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            toolStripContainer1.RightToolStripPanel.PerformLayout();
            toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            toolStripContainer1.TopToolStripPanel.PerformLayout();
            toolStripContainer1.ResumeLayout(false);
            toolStripContainer1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel1.PerformLayout();
            splitContainer1.Panel2.ResumeLayout(false);
            ((ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            splitContainer2.Panel1.ResumeLayout(false);
            splitContainer2.Panel1.PerformLayout();
            splitContainer2.Panel2.ResumeLayout(false);
            splitContainer2.Panel2.PerformLayout();
            ((ISupportInitialize)splitContainer2).EndInit();
            splitContainer2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanel3.ResumeLayout(false);
            flowLayoutPanel3.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            tableLayoutPanel2.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            flowLayoutPanel2.ResumeLayout(false);
            flowLayoutPanel2.PerformLayout();
            ((ISupportInitialize)numericUpDownSelectedAreaX1).EndInit();
            ((ISupportInitialize)numericUpDownSelectedAreaY1).EndInit();
            ((ISupportInitialize)numericUpDownSelectedAreaX2).EndInit();
            ((ISupportInitialize)numericUpDownSelectedAreaY2).EndInit();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            toolStrip2.ResumeLayout(false);
            toolStrip2.PerformLayout();
            ResumeLayout(false);
        }

        private void SplitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            throw new NotImplementedException();
        }
        #endregion
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItemSaveImage;
        private ToolStripMenuItem toolStripMenuItemSaveParameter;
        private ToolStripMenuItem toolStripMenuItemReadParameter;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripMenuItem exitToolStripMenuItem;
        public ToolStrip toolStrip1;
        public ToolStrip toolStrip2;
        public ToolStripContainer toolStripContainer1;
        public ToolStripSplitButton toolStripSplitButtonFindSpots;
        public ToolStripMenuItem toolStripMenuItemFindSpotsManual;
        public ToolStripSeparator toolStripSeparator5;
        public ToolStripMenuItem toolStripMenuItemClearMask;
        public ToolStripSplitButton toolStripSplitButtonGetProfile;
        public ToolStripSeparator toolStripSeparator7;
        public ToolStripMenuItem toolStripMenuItemGetProfileIntegralRegion;
        public ToolStripSeparator toolStripSeparator10;
        public ToolStripMenuItem toolStripMenuItemFindSpotsOption;
        public ToolStripButton toolStripButtonIntensityTable;
        public ToolStripButton toolStripButtonAutoProcedure;
        public ToolStripButton toolStripButtonFindParameter;
        private ToolStripMenuItem toolStripMenuItemGetProfileIntegralProperty;
        public ToolStripSplitButton toolStripSplitButtonFindCenter;
        public ToolStripMenuItem toolStripMenuItemFindCenterOption;
        private Label labelMousePointReal;
        private Label labelMousePointR;
        private Label labelMousePointPixel;
        private Label labelMousePointD;
        private Label labelMousePointIntensity;
        private Label labelMousePointTheta;
        private Panel panelMousePos;
        private ToolStripMenuItem webPageToolStripMenuItem;
        private Button buttonReset;
        public Button buttonAutoLevel;
        private ToolStripButton toolStripButton1;
        public ToolStripButton toolStripButtonRing;
        private ToolTip toolTip;
        private SplitContainer splitContainer1;
        private ToolStripSeparator toolStripSeparator11;
        private ToolStripMenuItem findCenterBeforeGetProfileToolStripMenuItem;
        private ToolStripMenuItem findSpotsBeforeGetProfileToolStripMenuItem;
        private RadioButton radioButtonNearCenter;
        private RadioButton radioButtonWhole;
        private ToolStripMenuItem optionToolStripMenuItem;
        public ToolStripMenuItem toolTipToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator12;
        private ToolStripMenuItem toolStripMenuItemAzimuthalDivisionAnalysis;
        private MenuStrip menuStrip;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem readImageToolStripMenuItem;
        private ToolStripMenuItem toolToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;

        private ToolStripMenuItem toolStripMenuItem1;
        public ToolStripSplitButton toolStripSplitButtonBackground;
        private ToolStripMenuItem resetToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem4;
        private ToolStripMenuItem toolStripMenuItem6;
        private ToolStripComboBox toolStripComboBoxBackgroundLower;
        private ToolStripMenuItem toolStripMenuItem7;
        private ToolStripComboBox toolStripComboBoxBackgroundUpper;
        private ToolStripMenuItem toolStripMenuItemMaskAll;
        private ToolStripSeparator toolStripSeparator13;
        private ToolStripMenuItem toolStripMenuItemReadMask;
        private ToolStripMenuItem toolStripMenuItemSaveMask;
        private ScalablePictureBox scalablePictureBoxThumbnail;
        private ToolStripMenuItem inverseMaskToolStripMenuItem;
        public ScalablePictureBox scalablePictureBox;
        private ToolStripMenuItem hintToolStripMenuItem;
        private GraphControl graphControlFrequency;
        private Label label9;
        private Label label7;
        private Label label5;
        public ComboBox comboBoxGradient;
        public ComboBox comboBoxScale2;
        public ComboBox comboBoxScale1;
        private TextBox textBoxInformation;
        private Label label11;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private GraphControl graphControlProfile;
        private ToolStripMenuItem resetFrequencyProfileToolStripMenuItem;
        private ToolStripMenuItem calibrateRaxisImageToolStripMenuItem;
        private ToolStripMenuItem fourierToolStripMenuItem;
        private FlowLayoutPanel flowLayoutPanel1;
        public ToolStripMenuItem toolStripMenuItemRadialIntegration;
        public ToolStripMenuItem toolStripMenuItemConcenctricIntegration;
        private ToolStripButton toolStripButtonUnroll;
        private Label labelMousePointChi;
        private TableLayoutPanel tableLayoutPanel1;
        public ToolStripButton toolStripButtonManualSpotMode;
        private ToolStripSeparator toolStripSeparator16;
        private ToolStripSeparator toolStripSeparator15;
        private ToolStripSeparator toolStripSeparator14;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripSeparator toolStripSeparator2;
        public ToolStripButton toolStripButtonFixCenter;
        public ToolStripComboBox toolStripComboBoxManualSpotSize;
        private ToolStripSeparator toolStripSeparator21;
        public ToolStripMenuItem toolStripMenuItemSendProfileToPDIndexer;
        public ToolStripMenuItem toolStripMenuItemSendUnrolledImage;
        private ToolStripMenuItem toolStripMenuItem5;
        public ToolStripMenuItem toolStripMenuItemPropertyWaveSource;
        public ToolStripMenuItem toolStripMenuItem9;
        private ToolStripSeparator toolStripSeparator22;
        private ToolStripMenuItem toolStripMenuItem10;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripSeparator toolStripSeparator23;
        private ToolStripMenuItem toolStripMenuItem12;
        private ToolStripSeparator toolStripSeparator24;
        private ToolStripMenuItem toolStripMenuItem13;
        private ToolStripSeparator toolStripSeparator25;
        private ToolStripMenuItem toolStripMenuItem14;
        private ToolStripSeparator toolStripSeparator26;
        private ToolStripMenuItem toolStripMenuItem15;
        private StatusStrip statusStrip1;
        public ToolStripStatusLabel toolStripStatusLabel;
        private ToolStripMenuItem tiffToolStripMenuItem;
        private ToolStripMenuItem ipaToolStripMenuItem;
        private ToolStripMenuItem pngToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton toolStripButtonCircumferentialBlur;
        private Label labelResolution;
        private ToolStripSeparator toolStripSeparator17;
        private SplitContainer splitContainer2;
        private ToolStripSeparator toolStripSeparator18;
        private ToolStripMenuItem misToolStripMenuItem;
        private Label label3;
        private Label label4;
        private Label label6;
        private Label label8;
        private Label label10;
        private Label label12;
        private Label label13;
        private Label label14;
        private TableLayoutPanel tableLayoutPanel3;
        private ToolStripMenuItem programUpdatesToolStripMenuItem;
        private Panel panel4;
        private Panel panel3;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem englishToolStripMenuItem;
        private ToolStripMenuItem japaneseToolStripMenuItem;
        public ToolStripButton toolStripButtonImageSequence;
        private ToolStripSeparator toolStripSeparator19;
        private ToolStripSeparator toolStripSeparator20;
        private TabPage tabPage3;
        private TextBox textBoxStatisticsSelectedArea;
        private Label label16;
        private FlowLayoutPanel flowLayoutPanel2;
        private Label label17;
        private NumericUpDown numericUpDownSelectedAreaX1;
        private Label label18;
        private NumericUpDown numericUpDownSelectedAreaY1;
        private Label label19;
        private NumericUpDown numericUpDownSelectedAreaX2;
        private Label label20;
        private NumericUpDown numericUpDownSelectedAreaY2;
        private Label label21;
        private Label label15;
        private TextBox textBoxStatisticsSelectedAreaSequential;
        private ToolStripMenuItem macroToolStripMenuItem;
        private ToolStripMenuItem editorToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator27;
        private ToolStripMenuItem findCenterBasedOnTheRingToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator28;
        private ToolStripMenuItem ngenCompileToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItemReferenceBackground;
        private ToolStripMenuItem toolStripMenuItem2;
        public ToolStripMenuItem flipHorizontallyToolStripMenuItem;
        public ToolStripMenuItem flipVerticallyToolStripMenuItem;
        private ToolStripMenuItem rotateToolStripMenuItem;
        public ToolStripComboBox toolStripComboBoxRotate;
        public ToolStripMenuItem toolStripMenuItemSelectedSequentialImages;
        public ToolStripMenuItem toolStripMenuItemAllSequentialImages;
        private ToolStripProgressBar toolStripProgressBar;
        private ToolStripSeparator toolStripSeparator30;
        private ToolStripMenuItem licenseToolStripMenuItem;
        private ToolStripMenuItem versionHistoryToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator29;
        private TrackBarAdvanced trackBarAdvancedMinInt;
        private TrackBarAdvanced trackBarAdvancedMaxInt;
        private ToolStripMenuItem clearMaskToolStripMenuItem;
        public ToolStripButton toolStripButtonFindParameterBruteForce;
        private ToolStripSeparator toolStripSeparator31;
        public ComboBox comboBoxScaleLine;
        private Label label1;
        private FlowLayoutPanel flowLayoutPanel3;
        private Button buttonMag1;
        private Button buttonMag2;
        private Button buttonMag_2;
        private Button buttonMag_4;
        private Button buttonMag_8;
        private Button buttonMag_16;
        private Button buttonMag4;
        private ToolStripMenuItem clearRegistrycheckAndRestartToolStripMenuItem;
        public ToolStripComboBox toolStripComboBoxAzimuthalDivisionNumber;
        //private ScalablePictureBox scalablePictureBox;








    }
}