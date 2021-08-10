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
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            IPAnalyzer.Properties.Settings settings1 = new IPAnalyzer.Properties.Settings();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel4 = new System.Windows.Forms.Panel();
            this.textBoxInformation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.scalablePictureBoxThumbnail = new Crystallography.Controls.ScalablePictureBox();
            this.radioButtonNearCenter = new System.Windows.Forms.RadioButton();
            this.radioButtonWhole = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBoxScale2 = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxScale1 = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBoxGradient = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.scalablePictureBox = new Crystallography.Controls.ScalablePictureBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelResolution = new System.Windows.Forms.Label();
            this.labelMousePointChi = new System.Windows.Forms.Label();
            this.labelMousePointD = new System.Windows.Forms.Label();
            this.labelMousePointTheta = new System.Windows.Forms.Label();
            this.labelMousePointR = new System.Windows.Forms.Label();
            this.labelMousePointIntensity = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.labelMousePointReal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelMousePointPixel = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonAutoLevel = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.trackBarAdvancedMinInt = new Crystallography.Controls.TrackBarAdvanced();
            this.trackBarAdvancedMaxInt = new Crystallography.Controls.TrackBarAdvanced();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panelMousePos = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.graphControlFrequency = new Crystallography.Controls.GraphControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.graphControlProfile = new Crystallography.Controls.GraphControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.textBoxStatisticsSelectedAreaSequential = new System.Windows.Forms.TextBox();
            this.textBoxStatisticsSelectedArea = new System.Windows.Forms.TextBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label17 = new System.Windows.Forms.Label();
            this.numericUpDownSelectedAreaX1 = new System.Windows.Forms.NumericUpDown();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownSelectedAreaY1 = new System.Windows.Forms.NumericUpDown();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownSelectedAreaX2 = new System.Windows.Forms.NumericUpDown();
            this.label20 = new System.Windows.Forms.Label();
            this.numericUpDownSelectedAreaY2 = new System.Windows.Forms.NumericUpDown();
            this.label21 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonIntensityTable = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator16 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonAutoProcedure = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator15 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonRing = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator14 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFindParameter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonFindParameterBruteForce = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator31 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonUnroll = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonCircumferentialBlur = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator17 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonImageSequence = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator19 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.tiffToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ipaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemReadParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveParameter = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator13 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemReadMask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSaveMask = new System.Windows.Forms.ToolStripMenuItem();
            this.clearMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetFrequencyProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calibrateRaxisImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemPropertyWaveSource = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator22 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator23 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator24 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator25 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator26 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem15 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator18 = new System.Windows.Forms.ToolStripSeparator();
            this.misToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.flipHorizontallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.flipVerticallyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxRotate = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator28 = new System.Windows.Forms.ToolStripSeparator();
            this.ngenCompileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.japaneseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.macroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator27 = new System.Windows.Forms.ToolStripSeparator();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programUpdatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator30 = new System.Windows.Forms.ToolStripSeparator();
            this.hintToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.licenseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.versionHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator29 = new System.Windows.Forms.ToolStripSeparator();
            this.webPageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripSplitButtonBackground = new System.Windows.Forms.ToolStripSplitButton();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxBackgroundLower = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxBackgroundUpper = new System.Windows.Forms.ToolStripComboBox();
            this.fourierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemReferenceBackground = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButtonFindCenter = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemFindCenterOption = new System.Windows.Forms.ToolStripMenuItem();
            this.findCenterBasedOnTheRingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonFixCenter = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButtonFindSpots = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemClearMask = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemMaskAll = new System.Windows.Forms.ToolStripMenuItem();
            this.inverseMaskToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemFindSpotsManual = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemFindSpotsOption = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripButtonManualSpotMode = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxManualSpotSize = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSplitButtonGetProfile = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItemGetProfileIntegralProperty = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemConcenctricIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemRadialIntegration = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemGetProfileIntegralRegion = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.findCenterBeforeGetProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findSpotsBeforeGetProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator21 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemSendProfileToPDIndexer = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSendUnrolledImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator12 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemDividedByAngleStep = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBoxAngleStep = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator20 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemAllSequentialImages = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSelectedSequentialImages = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider = new System.Windows.Forms.HelpProvider();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.RightToolStripPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaX1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaY1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaX2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaY2)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.BottomToolStripPanel, "toolStripContainer1.BottomToolStripPanel");
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1.BottomToolStripPanel, resources.GetString("toolStripContainer1.BottomToolStripPanel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1.BottomToolStripPanel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.BottomToolStripPanel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1.BottomToolStripPanel, resources.GetString("toolStripContainer1.BottomToolStripPanel.HelpString"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1.BottomToolStripPanel, ((bool)(resources.GetObject("toolStripContainer1.BottomToolStripPanel.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1.BottomToolStripPanel, resources.GetString("toolStripContainer1.BottomToolStripPanel.ToolTip"));
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1.ContentPanel, resources.GetString("toolStripContainer1.ContentPanel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1.ContentPanel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.ContentPanel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1.ContentPanel, resources.GetString("toolStripContainer1.ContentPanel.HelpString"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1.ContentPanel, ((bool)(resources.GetObject("toolStripContainer1.ContentPanel.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1.ContentPanel, resources.GetString("toolStripContainer1.ContentPanel.ToolTip"));
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1, resources.GetString("toolStripContainer1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1, resources.GetString("toolStripContainer1.HelpString"));
            // 
            // toolStripContainer1.LeftToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.LeftToolStripPanel, "toolStripContainer1.LeftToolStripPanel");
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1.LeftToolStripPanel, resources.GetString("toolStripContainer1.LeftToolStripPanel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1.LeftToolStripPanel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.LeftToolStripPanel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1.LeftToolStripPanel, resources.GetString("toolStripContainer1.LeftToolStripPanel.HelpString"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1.LeftToolStripPanel, ((bool)(resources.GetObject("toolStripContainer1.LeftToolStripPanel.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1.LeftToolStripPanel, resources.GetString("toolStripContainer1.LeftToolStripPanel.ToolTip"));
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.RightToolStripPanel, "toolStripContainer1.RightToolStripPanel");
            this.toolStripContainer1.RightToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1.RightToolStripPanel, resources.GetString("toolStripContainer1.RightToolStripPanel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1.RightToolStripPanel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.RightToolStripPanel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1.RightToolStripPanel, resources.GetString("toolStripContainer1.RightToolStripPanel.HelpString"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1.RightToolStripPanel, ((bool)(resources.GetObject("toolStripContainer1.RightToolStripPanel.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1.RightToolStripPanel, resources.GetString("toolStripContainer1.RightToolStripPanel.ToolTip"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1, ((bool)(resources.GetObject("toolStripContainer1.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1, resources.GetString("toolStripContainer1.ToolTip"));
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.TopToolStripPanel, "toolStripContainer1.TopToolStripPanel");
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.helpProvider.SetHelpKeyword(this.toolStripContainer1.TopToolStripPanel, resources.GetString("toolStripContainer1.TopToolStripPanel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStripContainer1.TopToolStripPanel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStripContainer1.TopToolStripPanel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStripContainer1.TopToolStripPanel, resources.GetString("toolStripContainer1.TopToolStripPanel.HelpString"));
            this.helpProvider.SetShowHelp(this.toolStripContainer1.TopToolStripPanel, ((bool)(resources.GetObject("toolStripContainer1.TopToolStripPanel.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStripContainer1.TopToolStripPanel, resources.GetString("toolStripContainer1.TopToolStripPanel.ToolTip"));
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.helpProvider.SetHelpKeyword(this.statusStrip1, resources.GetString("statusStrip1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.statusStrip1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("statusStrip1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.statusStrip1, resources.GetString("statusStrip1.HelpString"));
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Name = "statusStrip1";
            this.helpProvider.SetShowHelp(this.statusStrip1, ((bool)(resources.GetObject("statusStrip1.ShowHelp"))));
            this.toolTip.SetToolTip(this.statusStrip1, resources.GetString("statusStrip1.ToolTip"));
            // 
            // toolStripProgressBar
            // 
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            // 
            // toolStripStatusLabel
            // 
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            // 
            // splitContainer1
            // 
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.helpProvider.SetHelpKeyword(this.splitContainer1, resources.GetString("splitContainer1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer1, resources.GetString("splitContainer1.HelpString"));
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            resources.ApplyResources(this.splitContainer1.Panel1, "splitContainer1.Panel1");
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.panelMousePos);
            this.helpProvider.SetHelpKeyword(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer1.Panel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer1.Panel1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.HelpString"));
            this.helpProvider.SetShowHelp(this.splitContainer1.Panel1, ((bool)(resources.GetObject("splitContainer1.Panel1.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer1.Panel1, resources.GetString("splitContainer1.Panel1.ToolTip"));
            // 
            // splitContainer1.Panel2
            // 
            resources.ApplyResources(this.splitContainer1.Panel2, "splitContainer1.Panel2");
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.helpProvider.SetHelpKeyword(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer1.Panel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer1.Panel2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.HelpString"));
            this.helpProvider.SetShowHelp(this.splitContainer1.Panel2, ((bool)(resources.GetObject("splitContainer1.Panel2.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer1.Panel2, resources.GetString("splitContainer1.Panel2.ToolTip"));
            this.helpProvider.SetShowHelp(this.splitContainer1, ((bool)(resources.GetObject("splitContainer1.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer1, resources.GetString("splitContainer1.ToolTip"));
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.Resize += new System.EventHandler(this.FormMain_Resize);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.helpProvider.SetHelpKeyword(this.splitContainer2, resources.GetString("splitContainer2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer2, resources.GetString("splitContainer2.HelpString"));
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            resources.ApplyResources(this.splitContainer2.Panel1, "splitContainer2.Panel1");
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            this.helpProvider.SetHelpKeyword(this.splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer2.Panel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer2.Panel1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.HelpString"));
            this.helpProvider.SetShowHelp(this.splitContainer2.Panel1, ((bool)(resources.GetObject("splitContainer2.Panel1.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer2.Panel1, resources.GetString("splitContainer2.Panel1.ToolTip"));
            // 
            // splitContainer2.Panel2
            // 
            resources.ApplyResources(this.splitContainer2.Panel2, "splitContainer2.Panel2");
            this.splitContainer2.Panel2.Controls.Add(this.scalablePictureBox);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.helpProvider.SetHelpKeyword(this.splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.splitContainer2.Panel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("splitContainer2.Panel2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.HelpString"));
            this.helpProvider.SetShowHelp(this.splitContainer2.Panel2, ((bool)(resources.GetObject("splitContainer2.Panel2.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer2.Panel2, resources.GetString("splitContainer2.Panel2.ToolTip"));
            this.helpProvider.SetShowHelp(this.splitContainer2, ((bool)(resources.GetObject("splitContainer2.ShowHelp"))));
            this.toolTip.SetToolTip(this.splitContainer2, resources.GetString("splitContainer2.ToolTip"));
            // 
            // panel4
            // 
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Controls.Add(this.textBoxInformation);
            this.panel4.Controls.Add(this.label11);
            this.helpProvider.SetHelpKeyword(this.panel4, resources.GetString("panel4.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.panel4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panel4.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.panel4, resources.GetString("panel4.HelpString"));
            this.panel4.Name = "panel4";
            this.helpProvider.SetShowHelp(this.panel4, ((bool)(resources.GetObject("panel4.ShowHelp"))));
            this.toolTip.SetToolTip(this.panel4, resources.GetString("panel4.ToolTip"));
            // 
            // textBoxInformation
            // 
            resources.ApplyResources(this.textBoxInformation, "textBoxInformation");
            this.helpProvider.SetHelpKeyword(this.textBoxInformation, resources.GetString("textBoxInformation.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.textBoxInformation, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("textBoxInformation.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.textBoxInformation, resources.GetString("textBoxInformation.HelpString"));
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.ReadOnly = true;
            this.helpProvider.SetShowHelp(this.textBoxInformation, ((bool)(resources.GetObject("textBoxInformation.ShowHelp"))));
            this.toolTip.SetToolTip(this.textBoxInformation, resources.GetString("textBoxInformation.ToolTip"));
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.helpProvider.SetHelpKeyword(this.label11, resources.GetString("label11.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label11, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label11.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label11, resources.GetString("label11.HelpString"));
            this.label11.Name = "label11";
            this.helpProvider.SetShowHelp(this.label11, ((bool)(resources.GetObject("label11.ShowHelp"))));
            this.toolTip.SetToolTip(this.label11, resources.GetString("label11.ToolTip"));
            // 
            // panel3
            // 
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Controls.Add(this.scalablePictureBoxThumbnail);
            this.panel3.Controls.Add(this.radioButtonNearCenter);
            this.panel3.Controls.Add(this.radioButtonWhole);
            this.helpProvider.SetHelpKeyword(this.panel3, resources.GetString("panel3.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.panel3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panel3.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.panel3, resources.GetString("panel3.HelpString"));
            this.panel3.Name = "panel3";
            this.helpProvider.SetShowHelp(this.panel3, ((bool)(resources.GetObject("panel3.ShowHelp"))));
            this.toolTip.SetToolTip(this.panel3, resources.GetString("panel3.ToolTip"));
            // 
            // scalablePictureBoxThumbnail
            // 
            resources.ApplyResources(this.scalablePictureBoxThumbnail, "scalablePictureBoxThumbnail");
            this.scalablePictureBoxThumbnail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scalablePictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scalablePictureBoxThumbnail.FixZoomAndCenter = false;
            this.scalablePictureBoxThumbnail.FocusEventEnabled = false;
            this.helpProvider.SetHelpKeyword(this.scalablePictureBoxThumbnail, resources.GetString("scalablePictureBoxThumbnail.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.scalablePictureBoxThumbnail, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("scalablePictureBoxThumbnail.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.scalablePictureBoxThumbnail, resources.GetString("scalablePictureBoxThumbnail.HelpString"));
            this.scalablePictureBoxThumbnail.HorizontalFlip = false;
            this.scalablePictureBoxThumbnail.ManualSpotMode = false;
            this.scalablePictureBoxThumbnail.MouseScaling = true;
            this.scalablePictureBoxThumbnail.MouseTranslation = false;
            this.scalablePictureBoxThumbnail.Name = "scalablePictureBoxThumbnail";
            this.scalablePictureBoxThumbnail.ShowAreaRectangle = false;
            this.helpProvider.SetShowHelp(this.scalablePictureBoxThumbnail, ((bool)(resources.GetObject("scalablePictureBoxThumbnail.ShowHelp"))));
            this.scalablePictureBoxThumbnail.ShowRimRentangle = false;
            this.toolTip.SetToolTip(this.scalablePictureBoxThumbnail, resources.GetString("scalablePictureBoxThumbnail.ToolTip"));
            this.scalablePictureBoxThumbnail.VerticalFlip = false;
            this.scalablePictureBoxThumbnail.Zoom = 128D;
            this.scalablePictureBoxThumbnail.MouseDown2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBoxThumbnail_MouseDown2);
            this.scalablePictureBoxThumbnail.Draw += new Crystallography.Controls.ScalablePictureBox.DrawEvent(this.scalablePictureBoxThumbnail_Draw);
            // 
            // radioButtonNearCenter
            // 
            resources.ApplyResources(this.radioButtonNearCenter, "radioButtonNearCenter");
            this.radioButtonNearCenter.Checked = true;
            this.helpProvider.SetHelpKeyword(this.radioButtonNearCenter, resources.GetString("radioButtonNearCenter.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.radioButtonNearCenter, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("radioButtonNearCenter.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.radioButtonNearCenter, resources.GetString("radioButtonNearCenter.HelpString"));
            this.radioButtonNearCenter.Name = "radioButtonNearCenter";
            this.helpProvider.SetShowHelp(this.radioButtonNearCenter, ((bool)(resources.GetObject("radioButtonNearCenter.ShowHelp"))));
            this.radioButtonNearCenter.TabStop = true;
            this.toolTip.SetToolTip(this.radioButtonNearCenter, resources.GetString("radioButtonNearCenter.ToolTip"));
            this.radioButtonNearCenter.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhole
            // 
            resources.ApplyResources(this.radioButtonWhole, "radioButtonWhole");
            this.helpProvider.SetHelpKeyword(this.radioButtonWhole, resources.GetString("radioButtonWhole.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.radioButtonWhole, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("radioButtonWhole.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.radioButtonWhole, resources.GetString("radioButtonWhole.HelpString"));
            this.radioButtonWhole.Name = "radioButtonWhole";
            this.helpProvider.SetShowHelp(this.radioButtonWhole, ((bool)(resources.GetObject("radioButtonWhole.ShowHelp"))));
            this.toolTip.SetToolTip(this.radioButtonWhole, resources.GetString("radioButtonWhole.ToolTip"));
            this.radioButtonWhole.UseVisualStyleBackColor = true;
            this.radioButtonWhole.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // panel2
            // 
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Controls.Add(this.comboBoxScale2);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.comboBoxScale1);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.comboBoxGradient);
            this.panel2.Controls.Add(this.label5);
            this.helpProvider.SetHelpKeyword(this.panel2, resources.GetString("panel2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.panel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panel2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.panel2, resources.GetString("panel2.HelpString"));
            this.panel2.Name = "panel2";
            this.helpProvider.SetShowHelp(this.panel2, ((bool)(resources.GetObject("panel2.ShowHelp"))));
            this.toolTip.SetToolTip(this.panel2, resources.GetString("panel2.ToolTip"));
            // 
            // comboBoxScale2
            // 
            resources.ApplyResources(this.comboBoxScale2, "comboBoxScale2");
            this.comboBoxScale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScale2.FormattingEnabled = true;
            this.helpProvider.SetHelpKeyword(this.comboBoxScale2, resources.GetString("comboBoxScale2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.comboBoxScale2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("comboBoxScale2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.comboBoxScale2, resources.GetString("comboBoxScale2.HelpString"));
            this.comboBoxScale2.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale2.Items"),
            resources.GetString("comboBoxScale2.Items1")});
            this.comboBoxScale2.Name = "comboBoxScale2";
            this.helpProvider.SetShowHelp(this.comboBoxScale2, ((bool)(resources.GetObject("comboBoxScale2.ShowHelp"))));
            this.toolTip.SetToolTip(this.comboBoxScale2, resources.GetString("comboBoxScale2.ToolTip"));
            this.comboBoxScale2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale2_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.helpProvider.SetHelpKeyword(this.label9, resources.GetString("label9.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label9, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label9.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label9, resources.GetString("label9.HelpString"));
            this.label9.Name = "label9";
            this.helpProvider.SetShowHelp(this.label9, ((bool)(resources.GetObject("label9.ShowHelp"))));
            this.toolTip.SetToolTip(this.label9, resources.GetString("label9.ToolTip"));
            // 
            // comboBoxScale1
            // 
            resources.ApplyResources(this.comboBoxScale1, "comboBoxScale1");
            this.comboBoxScale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScale1.FormattingEnabled = true;
            this.helpProvider.SetHelpKeyword(this.comboBoxScale1, resources.GetString("comboBoxScale1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.comboBoxScale1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("comboBoxScale1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.comboBoxScale1, resources.GetString("comboBoxScale1.HelpString"));
            this.comboBoxScale1.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale1.Items"),
            resources.GetString("comboBoxScale1.Items1")});
            this.comboBoxScale1.Name = "comboBoxScale1";
            this.helpProvider.SetShowHelp(this.comboBoxScale1, ((bool)(resources.GetObject("comboBoxScale1.ShowHelp"))));
            this.toolTip.SetToolTip(this.comboBoxScale1, resources.GetString("comboBoxScale1.ToolTip"));
            this.comboBoxScale1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.helpProvider.SetHelpKeyword(this.label7, resources.GetString("label7.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label7, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label7.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label7, resources.GetString("label7.HelpString"));
            this.label7.Name = "label7";
            this.helpProvider.SetShowHelp(this.label7, ((bool)(resources.GetObject("label7.ShowHelp"))));
            this.toolTip.SetToolTip(this.label7, resources.GetString("label7.ToolTip"));
            // 
            // comboBoxGradient
            // 
            resources.ApplyResources(this.comboBoxGradient, "comboBoxGradient");
            this.comboBoxGradient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGradient.FormattingEnabled = true;
            this.helpProvider.SetHelpKeyword(this.comboBoxGradient, resources.GetString("comboBoxGradient.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.comboBoxGradient, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("comboBoxGradient.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.comboBoxGradient, resources.GetString("comboBoxGradient.HelpString"));
            this.comboBoxGradient.Items.AddRange(new object[] {
            resources.GetString("comboBoxGradient.Items"),
            resources.GetString("comboBoxGradient.Items1")});
            this.comboBoxGradient.Name = "comboBoxGradient";
            this.helpProvider.SetShowHelp(this.comboBoxGradient, ((bool)(resources.GetObject("comboBoxGradient.ShowHelp"))));
            this.toolTip.SetToolTip(this.comboBoxGradient, resources.GetString("comboBoxGradient.ToolTip"));
            this.comboBoxGradient.SelectedIndexChanged += new System.EventHandler(this.comboBoxGradient_SelectedIndexChanged_1);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.helpProvider.SetHelpKeyword(this.label5, resources.GetString("label5.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label5, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label5.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label5, resources.GetString("label5.HelpString"));
            this.label5.Name = "label5";
            this.helpProvider.SetShowHelp(this.label5, ((bool)(resources.GetObject("label5.ShowHelp"))));
            this.toolTip.SetToolTip(this.label5, resources.GetString("label5.ToolTip"));
            // 
            // scalablePictureBox
            // 
            resources.ApplyResources(this.scalablePictureBox, "scalablePictureBox");
            this.scalablePictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scalablePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.scalablePictureBox.FixZoomAndCenter = false;
            this.scalablePictureBox.FocusEventEnabled = false;
            this.helpProvider.SetHelpKeyword(this.scalablePictureBox, resources.GetString("scalablePictureBox.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.scalablePictureBox, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("scalablePictureBox.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.scalablePictureBox, resources.GetString("scalablePictureBox.HelpString"));
            this.scalablePictureBox.HorizontalFlip = false;
            this.scalablePictureBox.ManualSpotMode = false;
            this.scalablePictureBox.MouseScaling = true;
            this.scalablePictureBox.MouseTranslation = true;
            this.scalablePictureBox.Name = "scalablePictureBox";
            this.scalablePictureBox.ShowAreaRectangle = false;
            this.helpProvider.SetShowHelp(this.scalablePictureBox, ((bool)(resources.GetObject("scalablePictureBox.ShowHelp"))));
            this.scalablePictureBox.ShowRimRentangle = false;
            this.toolTip.SetToolTip(this.scalablePictureBox, resources.GetString("scalablePictureBox.ToolTip"));
            this.scalablePictureBox.VerticalFlip = false;
            this.scalablePictureBox.Zoom = 128D;
            this.scalablePictureBox.MouseMove2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBox_MouseMove2);
            this.scalablePictureBox.MouseUp2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBox_MouseUp2);
            this.scalablePictureBox.MouseDown2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBox_MouseDown2);
            this.scalablePictureBox.MouseWheel2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBox_MouseWheel2);
            this.scalablePictureBox.Draw += new Crystallography.Controls.ScalablePictureBox.DrawEvent(this.scalablePictureBox_Draw);
            // 
            // tableLayoutPanel1
            // 
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.labelResolution, 11, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePointChi, 9, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePointD, 7, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePointTheta, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePointR, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelMousePointIntensity, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label10, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label12, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.label13, 8, 0);
            this.tableLayoutPanel1.Controls.Add(this.label14, 10, 0);
            this.helpProvider.SetHelpKeyword(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tableLayoutPanel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tableLayoutPanel1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.HelpString"));
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.helpProvider.SetShowHelp(this.tableLayoutPanel1, ((bool)(resources.GetObject("tableLayoutPanel1.ShowHelp"))));
            this.toolTip.SetToolTip(this.tableLayoutPanel1, resources.GetString("tableLayoutPanel1.ToolTip"));
            // 
            // labelResolution
            // 
            resources.ApplyResources(this.labelResolution, "labelResolution");
            this.helpProvider.SetHelpKeyword(this.labelResolution, resources.GetString("labelResolution.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelResolution, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelResolution.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelResolution, resources.GetString("labelResolution.HelpString"));
            this.labelResolution.Name = "labelResolution";
            this.helpProvider.SetShowHelp(this.labelResolution, ((bool)(resources.GetObject("labelResolution.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelResolution, resources.GetString("labelResolution.ToolTip"));
            // 
            // labelMousePointChi
            // 
            resources.ApplyResources(this.labelMousePointChi, "labelMousePointChi");
            this.helpProvider.SetHelpKeyword(this.labelMousePointChi, resources.GetString("labelMousePointChi.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointChi, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointChi.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointChi, resources.GetString("labelMousePointChi.HelpString"));
            this.labelMousePointChi.Name = "labelMousePointChi";
            this.helpProvider.SetShowHelp(this.labelMousePointChi, ((bool)(resources.GetObject("labelMousePointChi.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointChi, resources.GetString("labelMousePointChi.ToolTip"));
            this.labelMousePointChi.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // labelMousePointD
            // 
            resources.ApplyResources(this.labelMousePointD, "labelMousePointD");
            this.helpProvider.SetHelpKeyword(this.labelMousePointD, resources.GetString("labelMousePointD.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointD, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointD.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointD, resources.GetString("labelMousePointD.HelpString"));
            this.labelMousePointD.Name = "labelMousePointD";
            this.helpProvider.SetShowHelp(this.labelMousePointD, ((bool)(resources.GetObject("labelMousePointD.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointD, resources.GetString("labelMousePointD.ToolTip"));
            // 
            // labelMousePointTheta
            // 
            resources.ApplyResources(this.labelMousePointTheta, "labelMousePointTheta");
            this.helpProvider.SetHelpKeyword(this.labelMousePointTheta, resources.GetString("labelMousePointTheta.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointTheta, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointTheta.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointTheta, resources.GetString("labelMousePointTheta.HelpString"));
            this.labelMousePointTheta.Name = "labelMousePointTheta";
            this.helpProvider.SetShowHelp(this.labelMousePointTheta, ((bool)(resources.GetObject("labelMousePointTheta.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointTheta, resources.GetString("labelMousePointTheta.ToolTip"));
            // 
            // labelMousePointR
            // 
            resources.ApplyResources(this.labelMousePointR, "labelMousePointR");
            this.helpProvider.SetHelpKeyword(this.labelMousePointR, resources.GetString("labelMousePointR.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointR, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointR.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointR, resources.GetString("labelMousePointR.HelpString"));
            this.labelMousePointR.Name = "labelMousePointR";
            this.helpProvider.SetShowHelp(this.labelMousePointR, ((bool)(resources.GetObject("labelMousePointR.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointR, resources.GetString("labelMousePointR.ToolTip"));
            // 
            // labelMousePointIntensity
            // 
            resources.ApplyResources(this.labelMousePointIntensity, "labelMousePointIntensity");
            this.helpProvider.SetHelpKeyword(this.labelMousePointIntensity, resources.GetString("labelMousePointIntensity.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointIntensity, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointIntensity.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointIntensity, resources.GetString("labelMousePointIntensity.HelpString"));
            this.labelMousePointIntensity.Name = "labelMousePointIntensity";
            this.helpProvider.SetShowHelp(this.labelMousePointIntensity, ((bool)(resources.GetObject("labelMousePointIntensity.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointIntensity, resources.GetString("labelMousePointIntensity.ToolTip"));
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.helpProvider.SetHelpKeyword(this.label6, resources.GetString("label6.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label6, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label6.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label6, resources.GetString("label6.HelpString"));
            this.label6.Name = "label6";
            this.helpProvider.SetShowHelp(this.label6, ((bool)(resources.GetObject("label6.ShowHelp"))));
            this.toolTip.SetToolTip(this.label6, resources.GetString("label6.ToolTip"));
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.helpProvider.SetHelpKeyword(this.label8, resources.GetString("label8.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label8, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label8.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label8, resources.GetString("label8.HelpString"));
            this.label8.Name = "label8";
            this.helpProvider.SetShowHelp(this.label8, ((bool)(resources.GetObject("label8.ShowHelp"))));
            this.toolTip.SetToolTip(this.label8, resources.GetString("label8.ToolTip"));
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.helpProvider.SetHelpKeyword(this.label10, resources.GetString("label10.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label10, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label10.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label10, resources.GetString("label10.HelpString"));
            this.label10.Name = "label10";
            this.helpProvider.SetShowHelp(this.label10, ((bool)(resources.GetObject("label10.ShowHelp"))));
            this.toolTip.SetToolTip(this.label10, resources.GetString("label10.ToolTip"));
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.helpProvider.SetHelpKeyword(this.label12, resources.GetString("label12.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label12, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label12.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label12, resources.GetString("label12.HelpString"));
            this.label12.Name = "label12";
            this.helpProvider.SetShowHelp(this.label12, ((bool)(resources.GetObject("label12.ShowHelp"))));
            this.toolTip.SetToolTip(this.label12, resources.GetString("label12.ToolTip"));
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.helpProvider.SetHelpKeyword(this.label13, resources.GetString("label13.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label13, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label13.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label13, resources.GetString("label13.HelpString"));
            this.label13.Name = "label13";
            this.helpProvider.SetShowHelp(this.label13, ((bool)(resources.GetObject("label13.ShowHelp"))));
            this.toolTip.SetToolTip(this.label13, resources.GetString("label13.ToolTip"));
            this.label13.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.helpProvider.SetHelpKeyword(this.label14, resources.GetString("label14.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label14, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label14.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label14, resources.GetString("label14.HelpString"));
            this.label14.Name = "label14";
            this.helpProvider.SetShowHelp(this.label14, ((bool)(resources.GetObject("label14.ShowHelp"))));
            this.toolTip.SetToolTip(this.label14, resources.GetString("label14.ToolTip"));
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.labelMousePointReal, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelMousePointPixel, 1, 0);
            this.helpProvider.SetHelpKeyword(this.tableLayoutPanel3, resources.GetString("tableLayoutPanel3.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tableLayoutPanel3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tableLayoutPanel3.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tableLayoutPanel3, resources.GetString("tableLayoutPanel3.HelpString"));
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.helpProvider.SetShowHelp(this.tableLayoutPanel3, ((bool)(resources.GetObject("tableLayoutPanel3.ShowHelp"))));
            this.toolTip.SetToolTip(this.tableLayoutPanel3, resources.GetString("tableLayoutPanel3.ToolTip"));
            // 
            // labelMousePointReal
            // 
            resources.ApplyResources(this.labelMousePointReal, "labelMousePointReal");
            this.helpProvider.SetHelpKeyword(this.labelMousePointReal, resources.GetString("labelMousePointReal.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointReal, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointReal.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointReal, resources.GetString("labelMousePointReal.HelpString"));
            this.labelMousePointReal.Name = "labelMousePointReal";
            this.helpProvider.SetShowHelp(this.labelMousePointReal, ((bool)(resources.GetObject("labelMousePointReal.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointReal, resources.GetString("labelMousePointReal.ToolTip"));
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.helpProvider.SetHelpKeyword(this.label3, resources.GetString("label3.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label3.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label3, resources.GetString("label3.HelpString"));
            this.label3.Name = "label3";
            this.helpProvider.SetShowHelp(this.label3, ((bool)(resources.GetObject("label3.ShowHelp"))));
            this.toolTip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.helpProvider.SetHelpKeyword(this.label4, resources.GetString("label4.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label4, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label4.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label4, resources.GetString("label4.HelpString"));
            this.label4.Name = "label4";
            this.helpProvider.SetShowHelp(this.label4, ((bool)(resources.GetObject("label4.ShowHelp"))));
            this.toolTip.SetToolTip(this.label4, resources.GetString("label4.ToolTip"));
            // 
            // labelMousePointPixel
            // 
            resources.ApplyResources(this.labelMousePointPixel, "labelMousePointPixel");
            this.helpProvider.SetHelpKeyword(this.labelMousePointPixel, resources.GetString("labelMousePointPixel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.labelMousePointPixel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("labelMousePointPixel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.labelMousePointPixel, resources.GetString("labelMousePointPixel.HelpString"));
            this.labelMousePointPixel.Name = "labelMousePointPixel";
            this.helpProvider.SetShowHelp(this.labelMousePointPixel, ((bool)(resources.GetObject("labelMousePointPixel.ShowHelp"))));
            this.toolTip.SetToolTip(this.labelMousePointPixel, resources.GetString("labelMousePointPixel.ToolTip"));
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.buttonAutoLevel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonReset, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAdvancedMinInt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAdvancedMaxInt, 1, 1);
            this.helpProvider.SetHelpKeyword(this.tableLayoutPanel2, resources.GetString("tableLayoutPanel2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tableLayoutPanel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tableLayoutPanel2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tableLayoutPanel2, resources.GetString("tableLayoutPanel2.HelpString"));
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.helpProvider.SetShowHelp(this.tableLayoutPanel2, ((bool)(resources.GetObject("tableLayoutPanel2.ShowHelp"))));
            this.toolTip.SetToolTip(this.tableLayoutPanel2, resources.GetString("tableLayoutPanel2.ToolTip"));
            // 
            // buttonAutoLevel
            // 
            resources.ApplyResources(this.buttonAutoLevel, "buttonAutoLevel");
            this.helpProvider.SetHelpKeyword(this.buttonAutoLevel, resources.GetString("buttonAutoLevel.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.buttonAutoLevel, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("buttonAutoLevel.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.buttonAutoLevel, resources.GetString("buttonAutoLevel.HelpString"));
            this.buttonAutoLevel.Name = "buttonAutoLevel";
            this.helpProvider.SetShowHelp(this.buttonAutoLevel, ((bool)(resources.GetObject("buttonAutoLevel.ShowHelp"))));
            this.toolTip.SetToolTip(this.buttonAutoLevel, resources.GetString("buttonAutoLevel.ToolTip"));
            this.buttonAutoLevel.Click += new System.EventHandler(this.buttonAutoLevel_Click);
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.helpProvider.SetHelpKeyword(this.buttonReset, resources.GetString("buttonReset.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.buttonReset, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("buttonReset.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.buttonReset, resources.GetString("buttonReset.HelpString"));
            this.buttonReset.Name = "buttonReset";
            this.helpProvider.SetShowHelp(this.buttonReset, ((bool)(resources.GetObject("buttonReset.ShowHelp"))));
            this.toolTip.SetToolTip(this.buttonReset, resources.GetString("buttonReset.ToolTip"));
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // trackBarAdvancedMinInt
            // 
            resources.ApplyResources(this.trackBarAdvancedMinInt, "trackBarAdvancedMinInt");
            this.trackBarAdvancedMinInt.ControlHeight = 27;
            this.trackBarAdvancedMinInt.DecimalPlaces = 0;
            this.helpProvider.SetHelpKeyword(this.trackBarAdvancedMinInt, resources.GetString("trackBarAdvancedMinInt.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.trackBarAdvancedMinInt, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("trackBarAdvancedMinInt.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.trackBarAdvancedMinInt, resources.GetString("trackBarAdvancedMinInt.HelpString"));
            this.trackBarAdvancedMinInt.LogScrollBar = false;
            this.trackBarAdvancedMinInt.Maximum = 65535D;
            this.trackBarAdvancedMinInt.Minimum = 0D;
            this.trackBarAdvancedMinInt.Name = "trackBarAdvancedMinInt";
            this.trackBarAdvancedMinInt.NumericBoxSize = 120;
            this.trackBarAdvancedMinInt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.helpProvider.SetShowHelp(this.trackBarAdvancedMinInt, ((bool)(resources.GetObject("trackBarAdvancedMinInt.ShowHelp"))));
            this.trackBarAdvancedMinInt.Smart_Increment = true;
            this.trackBarAdvancedMinInt.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.toolTip.SetToolTip(this.trackBarAdvancedMinInt, resources.GetString("trackBarAdvancedMinInt.ToolTip"));
            this.trackBarAdvancedMinInt.UpDown_Increment = 1D;
            this.trackBarAdvancedMinInt.Value = 0D;
            this.trackBarAdvancedMinInt.ValueChanged += new Crystallography.Controls.TrackBarAdvanced.ValueChangedDelegate(this.trackBarAdvancedMinInt_ValueChanged);
            // 
            // trackBarAdvancedMaxInt
            // 
            resources.ApplyResources(this.trackBarAdvancedMaxInt, "trackBarAdvancedMaxInt");
            this.trackBarAdvancedMaxInt.ControlHeight = 27;
            this.trackBarAdvancedMaxInt.DecimalPlaces = 0;
            this.helpProvider.SetHelpKeyword(this.trackBarAdvancedMaxInt, resources.GetString("trackBarAdvancedMaxInt.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.trackBarAdvancedMaxInt, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("trackBarAdvancedMaxInt.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.trackBarAdvancedMaxInt, resources.GetString("trackBarAdvancedMaxInt.HelpString"));
            this.trackBarAdvancedMaxInt.LogScrollBar = false;
            this.trackBarAdvancedMaxInt.Maximum = 65535D;
            this.trackBarAdvancedMaxInt.Minimum = 0D;
            this.trackBarAdvancedMaxInt.Name = "trackBarAdvancedMaxInt";
            this.trackBarAdvancedMaxInt.NumericBoxSize = 120;
            this.trackBarAdvancedMaxInt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.helpProvider.SetShowHelp(this.trackBarAdvancedMaxInt, ((bool)(resources.GetObject("trackBarAdvancedMaxInt.ShowHelp"))));
            this.trackBarAdvancedMaxInt.Smart_Increment = true;
            this.trackBarAdvancedMaxInt.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.toolTip.SetToolTip(this.trackBarAdvancedMaxInt, resources.GetString("trackBarAdvancedMaxInt.ToolTip"));
            this.trackBarAdvancedMaxInt.UpDown_Increment = 1D;
            this.trackBarAdvancedMaxInt.Value = 65535D;
            this.trackBarAdvancedMaxInt.ValueChanged += new Crystallography.Controls.TrackBarAdvanced.ValueChangedDelegate(this.trackBarAdvancedMaxInt_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.helpProvider.SetHelpKeyword(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.flowLayoutPanel1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("flowLayoutPanel1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.HelpString"));
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.helpProvider.SetShowHelp(this.flowLayoutPanel1, ((bool)(resources.GetObject("flowLayoutPanel1.ShowHelp"))));
            this.toolTip.SetToolTip(this.flowLayoutPanel1, resources.GetString("flowLayoutPanel1.ToolTip"));
            // 
            // panelMousePos
            // 
            resources.ApplyResources(this.panelMousePos, "panelMousePos");
            this.helpProvider.SetHelpKeyword(this.panelMousePos, resources.GetString("panelMousePos.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.panelMousePos, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("panelMousePos.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.panelMousePos, resources.GetString("panelMousePos.HelpString"));
            this.panelMousePos.Name = "panelMousePos";
            this.helpProvider.SetShowHelp(this.panelMousePos, ((bool)(resources.GetObject("panelMousePos.ShowHelp"))));
            this.toolTip.SetToolTip(this.panelMousePos, resources.GetString("panelMousePos.ToolTip"));
            // 
            // tabControl1
            // 
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.helpProvider.SetHelpKeyword(this.tabControl1, resources.GetString("tabControl1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tabControl1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabControl1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tabControl1, resources.GetString("tabControl1.HelpString"));
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.helpProvider.SetShowHelp(this.tabControl1, ((bool)(resources.GetObject("tabControl1.ShowHelp"))));
            this.toolTip.SetToolTip(this.tabControl1, resources.GetString("tabControl1.ToolTip"));
            // 
            // tabPage1
            // 
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Controls.Add(this.graphControlFrequency);
            this.helpProvider.SetHelpKeyword(this.tabPage1, resources.GetString("tabPage1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tabPage1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPage1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tabPage1, resources.GetString("tabPage1.HelpString"));
            this.tabPage1.Name = "tabPage1";
            this.helpProvider.SetShowHelp(this.tabPage1, ((bool)(resources.GetObject("tabPage1.ShowHelp"))));
            this.toolTip.SetToolTip(this.tabPage1, resources.GetString("tabPage1.ToolTip"));
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // graphControlFrequency
            // 
            resources.ApplyResources(this.graphControlFrequency, "graphControlFrequency");
            this.graphControlFrequency.AllowMouseOperation = true;
            this.graphControlFrequency.BackgroundColor = System.Drawing.Color.White;
            this.graphControlFrequency.BottomMargin = 0D;
            this.graphControlFrequency.DivisionLineColor = System.Drawing.Color.Black;
            this.graphControlFrequency.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControlFrequency.FixRangeHorizontal = false;
            this.graphControlFrequency.FixRangeVertical = false;
            this.graphControlFrequency.GraphName = "";
            this.helpProvider.SetHelpKeyword(this.graphControlFrequency, resources.GetString("graphControlFrequency.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.graphControlFrequency, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("graphControlFrequency.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.graphControlFrequency, resources.GetString("graphControlFrequency.HelpString"));
            this.graphControlFrequency.HorizontalGradiationTextVisivle = true;
            this.graphControlFrequency.Interpolation = false;
            this.graphControlFrequency.IsIntegerX = true;
            this.graphControlFrequency.IsIntegerY = true;
            this.graphControlFrequency.LabelX = "Intensity:";
            this.graphControlFrequency.LabelY = "Frequency:";
            this.graphControlFrequency.LeftMargin = 0F;
            this.graphControlFrequency.LineColor = System.Drawing.Color.Red;
            this.graphControlFrequency.LineWidth = 1F;
            this.graphControlFrequency.LowerX = 0D;
            this.graphControlFrequency.LowerY = 0D;
            this.graphControlFrequency.MaximalX = 1D;
            this.graphControlFrequency.MaximalY = 1D;
            this.graphControlFrequency.MinimalX = 0D;
            this.graphControlFrequency.MinimalY = 0D;
            this.graphControlFrequency.Mode = Crystallography.Controls.GraphControl.DrawingMode.Histogram;
            this.graphControlFrequency.MousePositionVisible = true;
            this.graphControlFrequency.Name = "graphControlFrequency";
            this.graphControlFrequency.OriginPosition = new System.Drawing.Point(40, 20);
            this.helpProvider.SetShowHelp(this.graphControlFrequency, ((bool)(resources.GetObject("graphControlFrequency.ShowHelp"))));
            this.graphControlFrequency.Smoothing = false;
            this.graphControlFrequency.TextFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolTip.SetToolTip(this.graphControlFrequency, resources.GetString("graphControlFrequency.ToolTip"));
            this.graphControlFrequency.UnitX = "";
            this.graphControlFrequency.UnitY = "";
            this.graphControlFrequency.UpperText = "";
            this.graphControlFrequency.UpperTextVisible = true;
            this.graphControlFrequency.UpperX = 1D;
            this.graphControlFrequency.UpperY = 1D;
            this.graphControlFrequency.UseLineWidth = true;
            this.graphControlFrequency.VerticalGradiationTextVisivle = true;
            this.graphControlFrequency.XLog = true;
            this.graphControlFrequency.XScaleLineVisible = true;
            this.graphControlFrequency.YLog = true;
            this.graphControlFrequency.YScaleLineVisible = true;
            this.graphControlFrequency.LinePositionChanged += new Crystallography.Controls.GraphControl.LinePositionChengedEventHandler(this.graphControlFrequency_LinePositionChanged);
            // 
            // tabPage2
            // 
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Controls.Add(this.graphControlProfile);
            this.helpProvider.SetHelpKeyword(this.tabPage2, resources.GetString("tabPage2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tabPage2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPage2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tabPage2, resources.GetString("tabPage2.HelpString"));
            this.tabPage2.Name = "tabPage2";
            this.helpProvider.SetShowHelp(this.tabPage2, ((bool)(resources.GetObject("tabPage2.ShowHelp"))));
            this.toolTip.SetToolTip(this.tabPage2, resources.GetString("tabPage2.ToolTip"));
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphControlProfile
            // 
            resources.ApplyResources(this.graphControlProfile, "graphControlProfile");
            this.graphControlProfile.AllowMouseOperation = true;
            this.graphControlProfile.BackgroundColor = System.Drawing.Color.White;
            this.graphControlProfile.BottomMargin = 0D;
            this.graphControlProfile.DivisionLineColor = System.Drawing.Color.Black;
            this.graphControlProfile.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControlProfile.FixRangeHorizontal = false;
            this.graphControlProfile.FixRangeVertical = false;
            this.graphControlProfile.GraphName = "";
            this.helpProvider.SetHelpKeyword(this.graphControlProfile, resources.GetString("graphControlProfile.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.graphControlProfile, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("graphControlProfile.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.graphControlProfile, resources.GetString("graphControlProfile.HelpString"));
            this.graphControlProfile.HorizontalGradiationTextVisivle = true;
            this.graphControlProfile.Interpolation = false;
            this.graphControlProfile.IsIntegerX = false;
            this.graphControlProfile.IsIntegerY = false;
            this.graphControlProfile.LabelX = "Angle:";
            this.graphControlProfile.LabelY = "Intensity:";
            this.graphControlProfile.LeftMargin = 0F;
            this.graphControlProfile.LineColor = System.Drawing.Color.Red;
            this.graphControlProfile.LineWidth = 1F;
            this.graphControlProfile.LowerX = 0D;
            this.graphControlProfile.LowerY = 0D;
            this.graphControlProfile.MaximalX = 1D;
            this.graphControlProfile.MaximalY = 1D;
            this.graphControlProfile.MinimalX = 0D;
            this.graphControlProfile.MinimalY = 0D;
            this.graphControlProfile.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControlProfile.MousePositionVisible = true;
            this.graphControlProfile.Name = "graphControlProfile";
            this.graphControlProfile.OriginPosition = new System.Drawing.Point(40, 20);
            this.helpProvider.SetShowHelp(this.graphControlProfile, ((bool)(resources.GetObject("graphControlProfile.ShowHelp"))));
            this.graphControlProfile.Smoothing = false;
            this.graphControlProfile.TextFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.toolTip.SetToolTip(this.graphControlProfile, resources.GetString("graphControlProfile.ToolTip"));
            this.graphControlProfile.UnitX = "";
            this.graphControlProfile.UnitY = "";
            this.graphControlProfile.UpperText = "";
            this.graphControlProfile.UpperTextVisible = true;
            this.graphControlProfile.UpperX = 1D;
            this.graphControlProfile.UpperY = 1D;
            this.graphControlProfile.UseLineWidth = true;
            this.graphControlProfile.VerticalGradiationTextVisivle = true;
            this.graphControlProfile.XLog = false;
            this.graphControlProfile.XScaleLineVisible = true;
            this.graphControlProfile.YLog = false;
            this.graphControlProfile.YScaleLineVisible = true;
            // 
            // tabPage3
            // 
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Controls.Add(this.textBoxStatisticsSelectedAreaSequential);
            this.tabPage3.Controls.Add(this.textBoxStatisticsSelectedArea);
            this.tabPage3.Controls.Add(this.flowLayoutPanel2);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            this.helpProvider.SetHelpKeyword(this.tabPage3, resources.GetString("tabPage3.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.tabPage3, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("tabPage3.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.tabPage3, resources.GetString("tabPage3.HelpString"));
            this.tabPage3.Name = "tabPage3";
            this.helpProvider.SetShowHelp(this.tabPage3, ((bool)(resources.GetObject("tabPage3.ShowHelp"))));
            this.toolTip.SetToolTip(this.tabPage3, resources.GetString("tabPage3.ToolTip"));
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxStatisticsSelectedAreaSequential
            // 
            resources.ApplyResources(this.textBoxStatisticsSelectedAreaSequential, "textBoxStatisticsSelectedAreaSequential");
            this.helpProvider.SetHelpKeyword(this.textBoxStatisticsSelectedAreaSequential, resources.GetString("textBoxStatisticsSelectedAreaSequential.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.textBoxStatisticsSelectedAreaSequential, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("textBoxStatisticsSelectedAreaSequential.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.textBoxStatisticsSelectedAreaSequential, resources.GetString("textBoxStatisticsSelectedAreaSequential.HelpString"));
            this.textBoxStatisticsSelectedAreaSequential.Name = "textBoxStatisticsSelectedAreaSequential";
            this.textBoxStatisticsSelectedAreaSequential.ReadOnly = true;
            this.helpProvider.SetShowHelp(this.textBoxStatisticsSelectedAreaSequential, ((bool)(resources.GetObject("textBoxStatisticsSelectedAreaSequential.ShowHelp"))));
            this.toolTip.SetToolTip(this.textBoxStatisticsSelectedAreaSequential, resources.GetString("textBoxStatisticsSelectedAreaSequential.ToolTip"));
            // 
            // textBoxStatisticsSelectedArea
            // 
            resources.ApplyResources(this.textBoxStatisticsSelectedArea, "textBoxStatisticsSelectedArea");
            this.helpProvider.SetHelpKeyword(this.textBoxStatisticsSelectedArea, resources.GetString("textBoxStatisticsSelectedArea.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.textBoxStatisticsSelectedArea, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("textBoxStatisticsSelectedArea.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.textBoxStatisticsSelectedArea, resources.GetString("textBoxStatisticsSelectedArea.HelpString"));
            this.textBoxStatisticsSelectedArea.Name = "textBoxStatisticsSelectedArea";
            this.textBoxStatisticsSelectedArea.ReadOnly = true;
            this.helpProvider.SetShowHelp(this.textBoxStatisticsSelectedArea, ((bool)(resources.GetObject("textBoxStatisticsSelectedArea.ShowHelp"))));
            this.toolTip.SetToolTip(this.textBoxStatisticsSelectedArea, resources.GetString("textBoxStatisticsSelectedArea.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.label17);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownSelectedAreaX1);
            this.flowLayoutPanel2.Controls.Add(this.label18);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownSelectedAreaY1);
            this.flowLayoutPanel2.Controls.Add(this.label19);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownSelectedAreaX2);
            this.flowLayoutPanel2.Controls.Add(this.label20);
            this.flowLayoutPanel2.Controls.Add(this.numericUpDownSelectedAreaY2);
            this.flowLayoutPanel2.Controls.Add(this.label21);
            this.helpProvider.SetHelpKeyword(this.flowLayoutPanel2, resources.GetString("flowLayoutPanel2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.flowLayoutPanel2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("flowLayoutPanel2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.flowLayoutPanel2, resources.GetString("flowLayoutPanel2.HelpString"));
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.helpProvider.SetShowHelp(this.flowLayoutPanel2, ((bool)(resources.GetObject("flowLayoutPanel2.ShowHelp"))));
            this.toolTip.SetToolTip(this.flowLayoutPanel2, resources.GetString("flowLayoutPanel2.ToolTip"));
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.helpProvider.SetHelpKeyword(this.label17, resources.GetString("label17.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label17, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label17.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label17, resources.GetString("label17.HelpString"));
            this.label17.Name = "label17";
            this.helpProvider.SetShowHelp(this.label17, ((bool)(resources.GetObject("label17.ShowHelp"))));
            this.toolTip.SetToolTip(this.label17, resources.GetString("label17.ToolTip"));
            // 
            // numericUpDownSelectedAreaX1
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaX1, "numericUpDownSelectedAreaX1");
            this.helpProvider.SetHelpKeyword(this.numericUpDownSelectedAreaX1, resources.GetString("numericUpDownSelectedAreaX1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.numericUpDownSelectedAreaX1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("numericUpDownSelectedAreaX1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.numericUpDownSelectedAreaX1, resources.GetString("numericUpDownSelectedAreaX1.HelpString"));
            this.numericUpDownSelectedAreaX1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaX1.Name = "numericUpDownSelectedAreaX1";
            this.helpProvider.SetShowHelp(this.numericUpDownSelectedAreaX1, ((bool)(resources.GetObject("numericUpDownSelectedAreaX1.ShowHelp"))));
            this.toolTip.SetToolTip(this.numericUpDownSelectedAreaX1, resources.GetString("numericUpDownSelectedAreaX1.ToolTip"));
            this.numericUpDownSelectedAreaX1.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.helpProvider.SetHelpKeyword(this.label18, resources.GetString("label18.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label18, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label18.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label18, resources.GetString("label18.HelpString"));
            this.label18.Name = "label18";
            this.helpProvider.SetShowHelp(this.label18, ((bool)(resources.GetObject("label18.ShowHelp"))));
            this.toolTip.SetToolTip(this.label18, resources.GetString("label18.ToolTip"));
            // 
            // numericUpDownSelectedAreaY1
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaY1, "numericUpDownSelectedAreaY1");
            this.helpProvider.SetHelpKeyword(this.numericUpDownSelectedAreaY1, resources.GetString("numericUpDownSelectedAreaY1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.numericUpDownSelectedAreaY1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("numericUpDownSelectedAreaY1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.numericUpDownSelectedAreaY1, resources.GetString("numericUpDownSelectedAreaY1.HelpString"));
            this.numericUpDownSelectedAreaY1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaY1.Name = "numericUpDownSelectedAreaY1";
            this.helpProvider.SetShowHelp(this.numericUpDownSelectedAreaY1, ((bool)(resources.GetObject("numericUpDownSelectedAreaY1.ShowHelp"))));
            this.toolTip.SetToolTip(this.numericUpDownSelectedAreaY1, resources.GetString("numericUpDownSelectedAreaY1.ToolTip"));
            this.numericUpDownSelectedAreaY1.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.helpProvider.SetHelpKeyword(this.label19, resources.GetString("label19.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label19, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label19.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label19, resources.GetString("label19.HelpString"));
            this.label19.Name = "label19";
            this.helpProvider.SetShowHelp(this.label19, ((bool)(resources.GetObject("label19.ShowHelp"))));
            this.toolTip.SetToolTip(this.label19, resources.GetString("label19.ToolTip"));
            // 
            // numericUpDownSelectedAreaX2
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaX2, "numericUpDownSelectedAreaX2");
            this.helpProvider.SetHelpKeyword(this.numericUpDownSelectedAreaX2, resources.GetString("numericUpDownSelectedAreaX2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.numericUpDownSelectedAreaX2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("numericUpDownSelectedAreaX2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.numericUpDownSelectedAreaX2, resources.GetString("numericUpDownSelectedAreaX2.HelpString"));
            this.numericUpDownSelectedAreaX2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaX2.Name = "numericUpDownSelectedAreaX2";
            this.helpProvider.SetShowHelp(this.numericUpDownSelectedAreaX2, ((bool)(resources.GetObject("numericUpDownSelectedAreaX2.ShowHelp"))));
            this.toolTip.SetToolTip(this.numericUpDownSelectedAreaX2, resources.GetString("numericUpDownSelectedAreaX2.ToolTip"));
            this.numericUpDownSelectedAreaX2.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.helpProvider.SetHelpKeyword(this.label20, resources.GetString("label20.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label20, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label20.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label20, resources.GetString("label20.HelpString"));
            this.label20.Name = "label20";
            this.helpProvider.SetShowHelp(this.label20, ((bool)(resources.GetObject("label20.ShowHelp"))));
            this.toolTip.SetToolTip(this.label20, resources.GetString("label20.ToolTip"));
            // 
            // numericUpDownSelectedAreaY2
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaY2, "numericUpDownSelectedAreaY2");
            this.helpProvider.SetHelpKeyword(this.numericUpDownSelectedAreaY2, resources.GetString("numericUpDownSelectedAreaY2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.numericUpDownSelectedAreaY2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("numericUpDownSelectedAreaY2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.numericUpDownSelectedAreaY2, resources.GetString("numericUpDownSelectedAreaY2.HelpString"));
            this.numericUpDownSelectedAreaY2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaY2.Name = "numericUpDownSelectedAreaY2";
            this.helpProvider.SetShowHelp(this.numericUpDownSelectedAreaY2, ((bool)(resources.GetObject("numericUpDownSelectedAreaY2.ShowHelp"))));
            this.toolTip.SetToolTip(this.numericUpDownSelectedAreaY2, resources.GetString("numericUpDownSelectedAreaY2.ToolTip"));
            this.numericUpDownSelectedAreaY2.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.helpProvider.SetHelpKeyword(this.label21, resources.GetString("label21.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label21, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label21.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label21, resources.GetString("label21.HelpString"));
            this.label21.Name = "label21";
            this.helpProvider.SetShowHelp(this.label21, ((bool)(resources.GetObject("label21.ShowHelp"))));
            this.toolTip.SetToolTip(this.label21, resources.GetString("label21.ToolTip"));
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.helpProvider.SetHelpKeyword(this.label15, resources.GetString("label15.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label15, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label15.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label15, resources.GetString("label15.HelpString"));
            this.label15.Name = "label15";
            this.helpProvider.SetShowHelp(this.label15, ((bool)(resources.GetObject("label15.ShowHelp"))));
            this.toolTip.SetToolTip(this.label15, resources.GetString("label15.ToolTip"));
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.helpProvider.SetHelpKeyword(this.label16, resources.GetString("label16.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.label16, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("label16.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.label16, resources.GetString("label16.HelpString"));
            this.label16.Name = "label16";
            this.helpProvider.SetShowHelp(this.label16, ((bool)(resources.GetObject("label16.ShowHelp"))));
            this.toolTip.SetToolTip(this.label16, resources.GetString("label16.ToolTip"));
            // 
            // toolStrip1
            // 
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.helpProvider.SetHelpKeyword(this.toolStrip1, resources.GetString("toolStrip1.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStrip1, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStrip1.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStrip1, resources.GetString("toolStrip1.HelpString"));
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonIntensityTable,
            this.toolStripSeparator16,
            this.toolStripButtonAutoProcedure,
            this.toolStripSeparator15,
            this.toolStripButtonRing,
            this.toolStripSeparator14,
            this.toolStripButtonFindParameter,
            this.toolStripSeparator9,
            this.toolStripButtonFindParameterBruteForce,
            this.toolStripSeparator31,
            this.toolStripButtonUnroll,
            this.toolStripSeparator1,
            this.toolStripButtonCircumferentialBlur,
            this.toolStripSeparator17,
            this.toolStripButtonImageSequence,
            this.toolStripSeparator19});
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.helpProvider.SetShowHelp(this.toolStrip1, ((bool)(resources.GetObject("toolStrip1.ShowHelp"))));
            this.toolTip.SetToolTip(this.toolStrip1, resources.GetString("toolStrip1.ToolTip"));
            // 
            // toolStripButtonIntensityTable
            // 
            resources.ApplyResources(this.toolStripButtonIntensityTable, "toolStripButtonIntensityTable");
            this.toolStripButtonIntensityTable.CheckOnClick = true;
            this.toolStripButtonIntensityTable.Image = global::IPAnalyzer.Properties.Resources.Table;
            this.toolStripButtonIntensityTable.Name = "toolStripButtonIntensityTable";
            this.toolStripButtonIntensityTable.Padding = new System.Windows.Forms.Padding(1);
            // 
            // toolStripSeparator16
            // 
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            // 
            // toolStripButtonAutoProcedure
            // 
            resources.ApplyResources(this.toolStripButtonAutoProcedure, "toolStripButtonAutoProcedure");
            this.toolStripButtonAutoProcedure.CheckOnClick = true;
            this.toolStripButtonAutoProcedure.Image = global::IPAnalyzer.Properties.Resources.AutoProc;
            this.toolStripButtonAutoProcedure.Name = "toolStripButtonAutoProcedure";
            this.toolStripButtonAutoProcedure.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonAutoProcedure.CheckedChanged += new System.EventHandler(this.toolStripButtonAutoProcedure_CheckedChanged);
            // 
            // toolStripSeparator15
            // 
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            // 
            // toolStripButtonRing
            // 
            resources.ApplyResources(this.toolStripButtonRing, "toolStripButtonRing");
            this.toolStripButtonRing.CheckOnClick = true;
            this.toolStripButtonRing.Image = global::IPAnalyzer.Properties.Resources.Ring;
            this.toolStripButtonRing.Name = "toolStripButtonRing";
            this.toolStripButtonRing.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonRing.CheckedChanged += new System.EventHandler(this.toolStripButtonRing_CheckedChanged);
            // 
            // toolStripSeparator14
            // 
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            // 
            // toolStripButtonFindParameter
            // 
            resources.ApplyResources(this.toolStripButtonFindParameter, "toolStripButtonFindParameter");
            this.toolStripButtonFindParameter.CheckOnClick = true;
            this.toolStripButtonFindParameter.Image = global::IPAnalyzer.Properties.Resources.FindParameter;
            this.toolStripButtonFindParameter.Name = "toolStripButtonFindParameter";
            this.toolStripButtonFindParameter.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonFindParameter.CheckedChanged += new System.EventHandler(this.toolStripButtonFindParameter_CheckedChanged);
            // 
            // toolStripSeparator9
            // 
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            // 
            // toolStripButtonFindParameterBruteForce
            // 
            resources.ApplyResources(this.toolStripButtonFindParameterBruteForce, "toolStripButtonFindParameterBruteForce");
            this.toolStripButtonFindParameterBruteForce.CheckOnClick = true;
            this.toolStripButtonFindParameterBruteForce.Image = global::IPAnalyzer.Properties.Resources.FindParameter;
            this.toolStripButtonFindParameterBruteForce.Name = "toolStripButtonFindParameterBruteForce";
            this.toolStripButtonFindParameterBruteForce.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonFindParameterBruteForce.CheckedChanged += new System.EventHandler(this.toolStripButtonFindParameterBruteForce_CheckedChanged);
            // 
            // toolStripSeparator31
            // 
            resources.ApplyResources(this.toolStripSeparator31, "toolStripSeparator31");
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            // 
            // toolStripButtonUnroll
            // 
            resources.ApplyResources(this.toolStripButtonUnroll, "toolStripButtonUnroll");
            this.toolStripButtonUnroll.CheckOnClick = true;
            this.toolStripButtonUnroll.DoubleClickEnabled = true;
            this.toolStripButtonUnroll.Image = global::IPAnalyzer.Properties.Resources.Unrolled;
            this.toolStripButtonUnroll.Name = "toolStripButtonUnroll";
            this.toolStripButtonUnroll.CheckedChanged += new System.EventHandler(this.toolStripSplitButtonUnroll_CheckChanged);
            // 
            // toolStripSeparator1
            // 
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            // 
            // toolStripButtonCircumferentialBlur
            // 
            resources.ApplyResources(this.toolStripButtonCircumferentialBlur, "toolStripButtonCircumferentialBlur");
            this.toolStripButtonCircumferentialBlur.Image = global::IPAnalyzer.Properties.Resources.Unrolled;
            this.toolStripButtonCircumferentialBlur.Name = "toolStripButtonCircumferentialBlur";
            this.toolStripButtonCircumferentialBlur.Click += new System.EventHandler(this.toolStripButtonCircumferentialBlur_Click);
            // 
            // toolStripSeparator17
            // 
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            // 
            // toolStripButtonImageSequence
            // 
            resources.ApplyResources(this.toolStripButtonImageSequence, "toolStripButtonImageSequence");
            this.toolStripButtonImageSequence.CheckOnClick = true;
            this.toolStripButtonImageSequence.Image = global::IPAnalyzer.Properties.Resources.Sequence;
            this.toolStripButtonImageSequence.Name = "toolStripButtonImageSequence";
            this.toolStripButtonImageSequence.CheckedChanged += new System.EventHandler(this.toolStripButtonImageSequence_CheckedChanged);
            // 
            // toolStripSeparator19
            // 
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.helpProvider.SetHelpKeyword(this.menuStrip, resources.GetString("menuStrip.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.menuStrip, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("menuStrip.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.menuStrip, resources.GetString("menuStrip.HelpString"));
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolToolStripMenuItem,
            this.toolStripMenuItem5,
            this.optionToolStripMenuItem,
            this.languageToolStripMenuItem,
            this.macroToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Name = "menuStrip";
            this.helpProvider.SetShowHelp(this.menuStrip, ((bool)(resources.GetObject("menuStrip.ShowHelp"))));
            this.toolTip.SetToolTip(this.menuStrip, resources.GetString("menuStrip.ToolTip"));
            // 
            // fileToolStripMenuItem
            // 
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readImageToolStripMenuItem,
            this.toolStripMenuItemSaveImage,
            this.toolStripSeparator3,
            this.toolStripMenuItemReadParameter,
            this.toolStripMenuItemSaveParameter,
            this.toolStripSeparator13,
            this.toolStripMenuItemReadMask,
            this.toolStripMenuItemSaveMask,
            this.clearMaskToolStripMenuItem,
            this.toolStripSeparator4,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            // 
            // readImageToolStripMenuItem
            // 
            resources.ApplyResources(this.readImageToolStripMenuItem, "readImageToolStripMenuItem");
            this.readImageToolStripMenuItem.Name = "readImageToolStripMenuItem";
            this.readImageToolStripMenuItem.Click += new System.EventHandler(this.readImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveImage
            // 
            resources.ApplyResources(this.toolStripMenuItemSaveImage, "toolStripMenuItemSaveImage");
            this.toolStripMenuItemSaveImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiffToolStripMenuItem,
            this.pngToolStripMenuItem,
            this.ipaToolStripMenuItem});
            this.toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            // 
            // tiffToolStripMenuItem
            // 
            resources.ApplyResources(this.tiffToolStripMenuItem, "tiffToolStripMenuItem");
            this.tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            this.tiffToolStripMenuItem.Click += new System.EventHandler(this.tiffToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem
            // 
            resources.ApplyResources(this.pngToolStripMenuItem, "pngToolStripMenuItem");
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // ipaToolStripMenuItem
            // 
            resources.ApplyResources(this.ipaToolStripMenuItem, "ipaToolStripMenuItem");
            this.ipaToolStripMenuItem.Name = "ipaToolStripMenuItem";
            this.ipaToolStripMenuItem.Click += new System.EventHandler(this.ipaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            // 
            // toolStripMenuItemReadParameter
            // 
            resources.ApplyResources(this.toolStripMenuItemReadParameter, "toolStripMenuItemReadParameter");
            this.toolStripMenuItemReadParameter.Name = "toolStripMenuItemReadParameter";
            this.toolStripMenuItemReadParameter.Click += new System.EventHandler(this.toolStripMenuItemReadParameter_Click);
            // 
            // toolStripMenuItemSaveParameter
            // 
            resources.ApplyResources(this.toolStripMenuItemSaveParameter, "toolStripMenuItemSaveParameter");
            this.toolStripMenuItemSaveParameter.Name = "toolStripMenuItemSaveParameter";
            this.toolStripMenuItemSaveParameter.Click += new System.EventHandler(this.toolStripMenuItemSaveParameter_Click);
            // 
            // toolStripSeparator13
            // 
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            // 
            // toolStripMenuItemReadMask
            // 
            resources.ApplyResources(this.toolStripMenuItemReadMask, "toolStripMenuItemReadMask");
            this.toolStripMenuItemReadMask.Name = "toolStripMenuItemReadMask";
            this.toolStripMenuItemReadMask.Click += new System.EventHandler(this.toolStripMenuItemReadMask_Click);
            // 
            // toolStripMenuItemSaveMask
            // 
            resources.ApplyResources(this.toolStripMenuItemSaveMask, "toolStripMenuItemSaveMask");
            this.toolStripMenuItemSaveMask.Name = "toolStripMenuItemSaveMask";
            this.toolStripMenuItemSaveMask.Click += new System.EventHandler(this.toolStripMenuItemSaveMask_Click);
            // 
            // clearMaskToolStripMenuItem
            // 
            resources.ApplyResources(this.clearMaskToolStripMenuItem, "clearMaskToolStripMenuItem");
            this.clearMaskToolStripMenuItem.Name = "clearMaskToolStripMenuItem";
            this.clearMaskToolStripMenuItem.Click += new System.EventHandler(this.clearMaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            // 
            // exitToolStripMenuItem
            // 
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            resources.ApplyResources(this.toolToolStripMenuItem, "toolToolStripMenuItem");
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFrequencyProfileToolStripMenuItem,
            this.calibrateRaxisImageToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            // 
            // resetFrequencyProfileToolStripMenuItem
            // 
            resources.ApplyResources(this.resetFrequencyProfileToolStripMenuItem, "resetFrequencyProfileToolStripMenuItem");
            this.resetFrequencyProfileToolStripMenuItem.Name = "resetFrequencyProfileToolStripMenuItem";
            this.resetFrequencyProfileToolStripMenuItem.Click += new System.EventHandler(this.resetFrequencyProfileToolStripMenuItem_Click);
            // 
            // calibrateRaxisImageToolStripMenuItem
            // 
            resources.ApplyResources(this.calibrateRaxisImageToolStripMenuItem, "calibrateRaxisImageToolStripMenuItem");
            this.calibrateRaxisImageToolStripMenuItem.Name = "calibrateRaxisImageToolStripMenuItem";
            this.calibrateRaxisImageToolStripMenuItem.Click += new System.EventHandler(this.calibrateRaxisImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            this.toolStripMenuItem5.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPropertyWaveSource,
            this.toolStripMenuItem9,
            this.toolStripSeparator22,
            this.toolStripMenuItem10,
            this.toolStripMenuItem11,
            this.toolStripSeparator23,
            this.toolStripMenuItem12,
            this.toolStripSeparator24,
            this.toolStripMenuItem13,
            this.toolStripSeparator25,
            this.toolStripMenuItem14,
            this.toolStripSeparator26,
            this.toolStripMenuItem15,
            this.toolStripSeparator18,
            this.misToolStripMenuItem});
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            // 
            // toolStripMenuItemPropertyWaveSource
            // 
            resources.ApplyResources(this.toolStripMenuItemPropertyWaveSource, "toolStripMenuItemPropertyWaveSource");
            this.toolStripMenuItemPropertyWaveSource.Name = "toolStripMenuItemPropertyWaveSource";
            this.toolStripMenuItemPropertyWaveSource.Click += new System.EventHandler(this.toolStripMenuItemWaveSource_Click);
            // 
            // toolStripMenuItem9
            // 
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItemIPCondition_Click);
            // 
            // toolStripSeparator22
            // 
            resources.ApplyResources(this.toolStripSeparator22, "toolStripSeparator22");
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            // 
            // toolStripMenuItem10
            // 
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItemIntegralRegion_Click);
            // 
            // toolStripMenuItem11
            // 
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItemIntegralProperty_Click);
            // 
            // toolStripSeparator23
            // 
            resources.ApplyResources(this.toolStripSeparator23, "toolStripSeparator23");
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            // 
            // toolStripMenuItem12
            // 
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItemManualMaskMode_Click);
            // 
            // toolStripSeparator24
            // 
            resources.ApplyResources(this.toolStripSeparator24, "toolStripSeparator24");
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            // 
            // toolStripMenuItem13
            // 
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItemAfterGetProfile_Click);
            // 
            // toolStripSeparator25
            // 
            resources.ApplyResources(this.toolStripSeparator25, "toolStripSeparator25");
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            // 
            // toolStripMenuItem14
            // 
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItemUnrolledImage_Click);
            // 
            // toolStripSeparator26
            // 
            resources.ApplyResources(this.toolStripSeparator26, "toolStripSeparator26");
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            // 
            // toolStripMenuItem15
            // 
            resources.ApplyResources(this.toolStripMenuItem15, "toolStripMenuItem15");
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItemAssociatedExtensions_Click);
            // 
            // toolStripSeparator18
            // 
            resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            // 
            // misToolStripMenuItem
            // 
            resources.ApplyResources(this.misToolStripMenuItem, "misToolStripMenuItem");
            this.misToolStripMenuItem.Name = "misToolStripMenuItem";
            this.misToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // optionToolStripMenuItem
            // 
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTipToolStripMenuItem,
            this.toolStripMenuItem2,
            this.rotateToolStripMenuItem,
            this.toolStripSeparator28,
            this.ngenCompileToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            // 
            // toolTipToolStripMenuItem
            // 
            resources.ApplyResources(this.toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            this.toolTipToolStripMenuItem.Checked = true;
            this.toolTipToolStripMenuItem.CheckOnClick = true;
            this.toolTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            // 
            // toolStripMenuItem2
            // 
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            resources.ApplyResources(this.flipHorizontallyToolStripMenuItem, "flipHorizontallyToolStripMenuItem");
            this.flipHorizontallyToolStripMenuItem.CheckOnClick = true;
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            this.flipHorizontallyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.flipHorizontallyToolStripMenuItem_CheckedChanged);
            // 
            // flipVerticallyToolStripMenuItem
            // 
            resources.ApplyResources(this.flipVerticallyToolStripMenuItem, "flipVerticallyToolStripMenuItem");
            this.flipVerticallyToolStripMenuItem.CheckOnClick = true;
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            this.flipVerticallyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.flipVerticallyToolStripMenuItem_CheckedChanged);
            // 
            // rotateToolStripMenuItem
            // 
            resources.ApplyResources(this.rotateToolStripMenuItem, "rotateToolStripMenuItem");
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxRotate});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            // 
            // toolStripComboBoxRotate
            // 
            resources.ApplyResources(this.toolStripComboBoxRotate, "toolStripComboBoxRotate");
            this.toolStripComboBoxRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxRotate.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxRotate.Items"),
            resources.GetString("toolStripComboBoxRotate.Items1"),
            resources.GetString("toolStripComboBoxRotate.Items2"),
            resources.GetString("toolStripComboBoxRotate.Items3")});
            this.toolStripComboBoxRotate.Name = "toolStripComboBoxRotate";
            this.toolStripComboBoxRotate.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRotate_SelectedIndexChanged);
            // 
            // toolStripSeparator28
            // 
            resources.ApplyResources(this.toolStripSeparator28, "toolStripSeparator28");
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            // 
            // ngenCompileToolStripMenuItem
            // 
            resources.ApplyResources(this.ngenCompileToolStripMenuItem, "ngenCompileToolStripMenuItem");
            this.ngenCompileToolStripMenuItem.Name = "ngenCompileToolStripMenuItem";
            this.ngenCompileToolStripMenuItem.Click += new System.EventHandler(this.ngenCompileToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            this.languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languageToolStripMenuItem.Checked = true;
            this.languageToolStripMenuItem.CheckOnClick = true;
            this.languageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            // 
            // englishToolStripMenuItem
            // 
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
            this.englishToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // japaneseToolStripMenuItem
            // 
            resources.ApplyResources(this.japaneseToolStripMenuItem, "japaneseToolStripMenuItem");
            this.japaneseToolStripMenuItem.Name = "japaneseToolStripMenuItem";
            this.japaneseToolStripMenuItem.Click += new System.EventHandler(this.languageToolStripMenuItem_Click);
            // 
            // macroToolStripMenuItem
            // 
            resources.ApplyResources(this.macroToolStripMenuItem, "macroToolStripMenuItem");
            this.macroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.toolStripSeparator27});
            this.macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            // 
            // editorToolStripMenuItem
            // 
            resources.ApplyResources(this.editorToolStripMenuItem, "editorToolStripMenuItem");
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            resources.ApplyResources(this.toolStripSeparator27, "toolStripSeparator27");
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            // 
            // helpToolStripMenuItem
            // 
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programUpdatesToolStripMenuItem,
            this.toolStripSeparator30,
            this.hintToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.versionHistoryToolStripMenuItem,
            this.toolStripSeparator29,
            this.webPageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            // 
            // programUpdatesToolStripMenuItem
            // 
            resources.ApplyResources(this.programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            this.programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            this.programUpdatesToolStripMenuItem.Click += new System.EventHandler(this.programUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator30
            // 
            resources.ApplyResources(this.toolStripSeparator30, "toolStripSeparator30");
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            // 
            // hintToolStripMenuItem
            // 
            resources.ApplyResources(this.hintToolStripMenuItem, "hintToolStripMenuItem");
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            resources.ApplyResources(this.licenseToolStripMenuItem, "licenseToolStripMenuItem");
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // versionHistoryToolStripMenuItem
            // 
            resources.ApplyResources(this.versionHistoryToolStripMenuItem, "versionHistoryToolStripMenuItem");
            this.versionHistoryToolStripMenuItem.Name = "versionHistoryToolStripMenuItem";
            this.versionHistoryToolStripMenuItem.Click += new System.EventHandler(this.versionHistoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            resources.ApplyResources(this.toolStripSeparator29, "toolStripSeparator29");
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            // 
            // webPageToolStripMenuItem
            // 
            resources.ApplyResources(this.webPageToolStripMenuItem, "webPageToolStripMenuItem");
            this.webPageToolStripMenuItem.Name = "webPageToolStripMenuItem";
            this.webPageToolStripMenuItem.Click += new System.EventHandler(this.webPageToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
            this.helpProvider.SetHelpKeyword(this.toolStrip2, resources.GetString("toolStrip2.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this.toolStrip2, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("toolStrip2.HelpNavigator"))));
            this.helpProvider.SetHelpString(this.toolStrip2, resources.GetString("toolStrip2.HelpString"));
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSplitButtonBackground,
            this.toolStripSeparator8,
            this.toolStripSplitButtonFindCenter,
            this.toolStripButtonFixCenter,
            this.toolStripSeparator6,
            this.toolStripSplitButtonFindSpots,
            this.toolStripButtonManualSpotMode,
            this.toolStripComboBoxManualSpotSize,
            this.toolStripSeparator2,
            this.toolStripSplitButtonGetProfile});
            this.toolStrip2.Name = "toolStrip2";
            this.helpProvider.SetShowHelp(this.toolStrip2, ((bool)(resources.GetObject("toolStrip2.ShowHelp"))));
            this.toolStrip2.Stretch = true;
            this.toolTip.SetToolTip(this.toolStrip2, resources.GetString("toolStrip2.ToolTip"));
            // 
            // toolStripSplitButtonBackground
            // 
            resources.ApplyResources(this.toolStripSplitButtonBackground, "toolStripSplitButtonBackground");
            this.toolStripSplitButtonBackground.AutoToolTip = false;
            this.toolStripSplitButtonBackground.DropDownButtonWidth = 18;
            this.toolStripSplitButtonBackground.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.toolStripMenuItem4,
            this.fourierToolStripMenuItem,
            this.toolStripMenuItemReferenceBackground});
            this.toolStripSplitButtonBackground.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSplitButtonBackground.Image = global::IPAnalyzer.Properties.Resources.BackGround;
            this.toolStripSplitButtonBackground.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonBackground.Name = "toolStripSplitButtonBackground";
            this.toolStripSplitButtonBackground.ButtonClick += new System.EventHandler(this.toolStripSplitButtonBackground_ButtonClick);
            // 
            // resetToolStripMenuItem
            // 
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetBackgroundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripComboBoxBackgroundLower,
            this.toolStripMenuItem7,
            this.toolStripComboBoxBackgroundUpper});
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // toolStripMenuItem6
            // 
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            // 
            // toolStripComboBoxBackgroundLower
            // 
            resources.ApplyResources(this.toolStripComboBoxBackgroundLower, "toolStripComboBoxBackgroundLower");
            this.toolStripComboBoxBackgroundLower.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxBackgroundLower.Items"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items1"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items2"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items3"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items4"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items5")});
            this.toolStripComboBoxBackgroundLower.Name = "toolStripComboBoxBackgroundLower";
            // 
            // toolStripMenuItem7
            // 
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            // 
            // toolStripComboBoxBackgroundUpper
            // 
            resources.ApplyResources(this.toolStripComboBoxBackgroundUpper, "toolStripComboBoxBackgroundUpper");
            this.toolStripComboBoxBackgroundUpper.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxBackgroundUpper.Items"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items1"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items2"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items3"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items4")});
            this.toolStripComboBoxBackgroundUpper.Name = "toolStripComboBoxBackgroundUpper";
            // 
            // fourierToolStripMenuItem
            // 
            resources.ApplyResources(this.fourierToolStripMenuItem, "fourierToolStripMenuItem");
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            this.fourierToolStripMenuItem.Click += new System.EventHandler(this.fourierToolStripMenuItem_Click);
            // 
            // toolStripMenuItemReferenceBackground
            // 
            resources.ApplyResources(this.toolStripMenuItemReferenceBackground, "toolStripMenuItemReferenceBackground");
            this.toolStripMenuItemReferenceBackground.Name = "toolStripMenuItemReferenceBackground";
            this.toolStripMenuItemReferenceBackground.Click += new System.EventHandler(this.ToolStripMenuItemReferenceBackground_Click);
            // 
            // toolStripSeparator8
            // 
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            // 
            // toolStripSplitButtonFindCenter
            // 
            resources.ApplyResources(this.toolStripSplitButtonFindCenter, "toolStripSplitButtonFindCenter");
            this.toolStripSplitButtonFindCenter.DropDownButtonWidth = 18;
            this.toolStripSplitButtonFindCenter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFindCenterOption,
            this.findCenterBasedOnTheRingToolStripMenuItem});
            this.toolStripSplitButtonFindCenter.Image = global::IPAnalyzer.Properties.Resources.Center;
            this.toolStripSplitButtonFindCenter.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonFindCenter.Name = "toolStripSplitButtonFindCenter";
            this.toolStripSplitButtonFindCenter.ButtonClick += new System.EventHandler(this.toolStripSplitButtonFindCenter_ButtonClick);
            // 
            // toolStripMenuItemFindCenterOption
            // 
            resources.ApplyResources(this.toolStripMenuItemFindCenterOption, "toolStripMenuItemFindCenterOption");
            this.toolStripMenuItemFindCenterOption.Name = "toolStripMenuItemFindCenterOption";
            this.toolStripMenuItemFindCenterOption.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // findCenterBasedOnTheRingToolStripMenuItem
            // 
            resources.ApplyResources(this.findCenterBasedOnTheRingToolStripMenuItem, "findCenterBasedOnTheRingToolStripMenuItem");
            this.findCenterBasedOnTheRingToolStripMenuItem.Name = "findCenterBasedOnTheRingToolStripMenuItem";
            // 
            // toolStripButtonFixCenter
            // 
            resources.ApplyResources(this.toolStripButtonFixCenter, "toolStripButtonFixCenter");
            this.toolStripButtonFixCenter.CheckOnClick = true;
            this.toolStripButtonFixCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonFixCenter.ForeColor = System.Drawing.Color.Gray;
            this.toolStripButtonFixCenter.Name = "toolStripButtonFixCenter";
            this.toolStripButtonFixCenter.CheckedChanged += new System.EventHandler(this.toolStripButtonFixCenter_CheckedChanged);
            this.toolStripButtonFixCenter.Click += new System.EventHandler(this.toolStripButtonFixCenter_Click);
            // 
            // toolStripSeparator6
            // 
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            // 
            // toolStripSplitButtonFindSpots
            // 
            resources.ApplyResources(this.toolStripSplitButtonFindSpots, "toolStripSplitButtonFindSpots");
            this.toolStripSplitButtonFindSpots.DropDownButtonWidth = 18;
            this.toolStripSplitButtonFindSpots.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearMask,
            this.toolStripMenuItemMaskAll,
            this.inverseMaskToolStripMenuItem,
            this.toolStripSeparator5,
            this.toolStripMenuItemFindSpotsManual,
            this.toolStripSeparator10,
            this.toolStripMenuItemFindSpotsOption});
            this.toolStripSplitButtonFindSpots.ForeColor = System.Drawing.Color.Black;
            this.toolStripSplitButtonFindSpots.Image = global::IPAnalyzer.Properties.Resources.Spot;
            this.toolStripSplitButtonFindSpots.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonFindSpots.Name = "toolStripSplitButtonFindSpots";
            this.toolStripSplitButtonFindSpots.ButtonClick += new System.EventHandler(this.toolStripSplitButtonFindSpots_ButtonClick);
            // 
            // toolStripMenuItemClearMask
            // 
            resources.ApplyResources(this.toolStripMenuItemClearMask, "toolStripMenuItemClearMask");
            this.toolStripMenuItemClearMask.Name = "toolStripMenuItemClearMask";
            this.toolStripMenuItemClearMask.Click += new System.EventHandler(this.toolStripMenuItemClearSpots_Click);
            // 
            // toolStripMenuItemMaskAll
            // 
            resources.ApplyResources(this.toolStripMenuItemMaskAll, "toolStripMenuItemMaskAll");
            this.toolStripMenuItemMaskAll.Name = "toolStripMenuItemMaskAll";
            this.toolStripMenuItemMaskAll.Click += new System.EventHandler(this.toolStripMenuItemMaskAll_Click);
            // 
            // inverseMaskToolStripMenuItem
            // 
            resources.ApplyResources(this.inverseMaskToolStripMenuItem, "inverseMaskToolStripMenuItem");
            this.inverseMaskToolStripMenuItem.Name = "inverseMaskToolStripMenuItem";
            this.inverseMaskToolStripMenuItem.Click += new System.EventHandler(this.inverseMaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            // 
            // toolStripMenuItemFindSpotsManual
            // 
            resources.ApplyResources(this.toolStripMenuItemFindSpotsManual, "toolStripMenuItemFindSpotsManual");
            this.toolStripMenuItemFindSpotsManual.Name = "toolStripMenuItemFindSpotsManual";
            // 
            // toolStripSeparator10
            // 
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            // 
            // toolStripMenuItemFindSpotsOption
            // 
            resources.ApplyResources(this.toolStripMenuItemFindSpotsOption, "toolStripMenuItemFindSpotsOption");
            this.toolStripMenuItemFindSpotsOption.Name = "toolStripMenuItemFindSpotsOption";
            this.toolStripMenuItemFindSpotsOption.Click += new System.EventHandler(this.toolStripMenuItemManualMaskMode_Click);
            // 
            // toolStripButtonManualSpotMode
            // 
            resources.ApplyResources(this.toolStripButtonManualSpotMode, "toolStripButtonManualSpotMode");
            this.toolStripButtonManualSpotMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonManualSpotMode.ForeColor = System.Drawing.Color.Gray;
            this.toolStripButtonManualSpotMode.MergeIndex = 3;
            this.toolStripButtonManualSpotMode.Name = "toolStripButtonManualSpotMode";
            this.toolStripButtonManualSpotMode.CheckedChanged += new System.EventHandler(this.toolStripButtonManualSpotMode_CheckedChanged);
            this.toolStripButtonManualSpotMode.Click += new System.EventHandler(this.toolStripButtonManualSpotMode_Click);
            // 
            // toolStripComboBoxManualSpotSize
            // 
            resources.ApplyResources(this.toolStripComboBoxManualSpotSize, "toolStripComboBoxManualSpotSize");
            this.toolStripComboBoxManualSpotSize.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxManualSpotSize.Items"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items1"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items2"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items3"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items4"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items5"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items6"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items7"),
            resources.GetString("toolStripComboBoxManualSpotSize.Items8")});
            this.toolStripComboBoxManualSpotSize.Name = "toolStripComboBoxManualSpotSize";
            this.toolStripComboBoxManualSpotSize.TextChanged += new System.EventHandler(this.toolStripComboBoxManualSpotSize_TextChanged);
            // 
            // toolStripSeparator2
            // 
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            // 
            // toolStripSplitButtonGetProfile
            // 
            resources.ApplyResources(this.toolStripSplitButtonGetProfile, "toolStripSplitButtonGetProfile");
            this.toolStripSplitButtonGetProfile.DropDownButtonWidth = 18;
            this.toolStripSplitButtonGetProfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemGetProfileIntegralProperty,
            this.toolStripMenuItemConcenctricIntegration,
            this.toolStripMenuItemRadialIntegration,
            this.toolStripSeparator7,
            this.toolStripMenuItemGetProfileIntegralRegion,
            this.toolStripSeparator11,
            this.findCenterBeforeGetProfileToolStripMenuItem,
            this.findSpotsBeforeGetProfileToolStripMenuItem,
            this.toolStripSeparator21,
            this.toolStripMenuItemSendProfileToPDIndexer,
            this.toolStripMenuItemSendUnrolledImage,
            this.toolStripSeparator12,
            this.toolStripMenuItemDividedByAngleStep,
            this.toolStripSeparator20,
            this.toolStripMenuItemAllSequentialImages,
            this.toolStripMenuItemSelectedSequentialImages});
            this.toolStripSplitButtonGetProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSplitButtonGetProfile.Image = global::IPAnalyzer.Properties.Resources.Profile;
            this.toolStripSplitButtonGetProfile.Name = "toolStripSplitButtonGetProfile";
            this.toolStripSplitButtonGetProfile.ButtonClick += new System.EventHandler(this.toolStripSplitButtonGetProfile_ButtonClick);
            // 
            // toolStripMenuItemGetProfileIntegralProperty
            // 
            resources.ApplyResources(this.toolStripMenuItemGetProfileIntegralProperty, "toolStripMenuItemGetProfileIntegralProperty");
            this.toolStripMenuItemGetProfileIntegralProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemGetProfileIntegralProperty.Name = "toolStripMenuItemGetProfileIntegralProperty";
            this.toolStripMenuItemGetProfileIntegralProperty.Click += new System.EventHandler(this.toolStripMenuItemIntegralProperty_Click);
            // 
            // toolStripMenuItemConcenctricIntegration
            // 
            resources.ApplyResources(this.toolStripMenuItemConcenctricIntegration, "toolStripMenuItemConcenctricIntegration");
            this.toolStripMenuItemConcenctricIntegration.Checked = true;
            this.toolStripMenuItemConcenctricIntegration.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemConcenctricIntegration.Name = "toolStripMenuItemConcenctricIntegration";
            this.toolStripMenuItemConcenctricIntegration.Click += new System.EventHandler(this.toolStripMenuItemConcenctricIntegration_Click);
            // 
            // toolStripMenuItemRadialIntegration
            // 
            resources.ApplyResources(this.toolStripMenuItemRadialIntegration, "toolStripMenuItemRadialIntegration");
            this.toolStripMenuItemRadialIntegration.Name = "toolStripMenuItemRadialIntegration";
            this.toolStripMenuItemRadialIntegration.Click += new System.EventHandler(this.toolStripMenuItemRadialIntegration_Click);
            // 
            // toolStripSeparator7
            // 
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            // 
            // toolStripMenuItemGetProfileIntegralRegion
            // 
            resources.ApplyResources(this.toolStripMenuItemGetProfileIntegralRegion, "toolStripMenuItemGetProfileIntegralRegion");
            this.toolStripMenuItemGetProfileIntegralRegion.Name = "toolStripMenuItemGetProfileIntegralRegion";
            this.toolStripMenuItemGetProfileIntegralRegion.Click += new System.EventHandler(this.toolStripMenuItemIntegralRegion_Click);
            // 
            // toolStripSeparator11
            // 
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            // 
            // findCenterBeforeGetProfileToolStripMenuItem
            // 
            resources.ApplyResources(this.findCenterBeforeGetProfileToolStripMenuItem, "findCenterBeforeGetProfileToolStripMenuItem");
            this.findCenterBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.Checked = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findCenterBeforeGetProfileToolStripMenuItem.Name = "findCenterBeforeGetProfileToolStripMenuItem";
            // 
            // findSpotsBeforeGetProfileToolStripMenuItem
            // 
            resources.ApplyResources(this.findSpotsBeforeGetProfileToolStripMenuItem, "findSpotsBeforeGetProfileToolStripMenuItem");
            this.findSpotsBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            this.findSpotsBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            this.findSpotsBeforeGetProfileToolStripMenuItem.Name = "findSpotsBeforeGetProfileToolStripMenuItem";
            // 
            // toolStripSeparator21
            // 
            resources.ApplyResources(this.toolStripSeparator21, "toolStripSeparator21");
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            // 
            // toolStripMenuItemSendProfileToPDIndexer
            // 
            resources.ApplyResources(this.toolStripMenuItemSendProfileToPDIndexer, "toolStripMenuItemSendProfileToPDIndexer");
            this.toolStripMenuItemSendProfileToPDIndexer.Checked = true;
            this.toolStripMenuItemSendProfileToPDIndexer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemSendProfileToPDIndexer.Name = "toolStripMenuItemSendProfileToPDIndexer";
            this.toolStripMenuItemSendProfileToPDIndexer.Click += new System.EventHandler(this.toolStripMenuItemSendProfileToPDIndexer_Click);
            // 
            // toolStripMenuItemSendUnrolledImage
            // 
            resources.ApplyResources(this.toolStripMenuItemSendUnrolledImage, "toolStripMenuItemSendUnrolledImage");
            this.toolStripMenuItemSendUnrolledImage.Name = "toolStripMenuItemSendUnrolledImage";
            this.toolStripMenuItemSendUnrolledImage.Click += new System.EventHandler(this.toolStripMenuItemSendUnrolledImage_Click);
            // 
            // toolStripSeparator12
            // 
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            // 
            // toolStripMenuItemDividedByAngleStep
            // 
            resources.ApplyResources(this.toolStripMenuItemDividedByAngleStep, "toolStripMenuItemDividedByAngleStep");
            this.toolStripMenuItemDividedByAngleStep.CheckOnClick = true;
            this.toolStripMenuItemDividedByAngleStep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripComboBoxAngleStep});
            this.toolStripMenuItemDividedByAngleStep.Name = "toolStripMenuItemDividedByAngleStep";
            // 
            // toolStripMenuItem1
            // 
            resources.ApplyResources(this.toolStripMenuItem1, "toolStripMenuItem1");
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            // 
            // toolStripComboBoxAngleStep
            // 
            resources.ApplyResources(this.toolStripComboBoxAngleStep, "toolStripComboBoxAngleStep");
            this.toolStripComboBoxAngleStep.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxAngleStep.Items"),
            resources.GetString("toolStripComboBoxAngleStep.Items1"),
            resources.GetString("toolStripComboBoxAngleStep.Items2"),
            resources.GetString("toolStripComboBoxAngleStep.Items3"),
            resources.GetString("toolStripComboBoxAngleStep.Items4"),
            resources.GetString("toolStripComboBoxAngleStep.Items5"),
            resources.GetString("toolStripComboBoxAngleStep.Items6"),
            resources.GetString("toolStripComboBoxAngleStep.Items7"),
            resources.GetString("toolStripComboBoxAngleStep.Items8"),
            resources.GetString("toolStripComboBoxAngleStep.Items9"),
            resources.GetString("toolStripComboBoxAngleStep.Items10"),
            resources.GetString("toolStripComboBoxAngleStep.Items11"),
            resources.GetString("toolStripComboBoxAngleStep.Items12"),
            resources.GetString("toolStripComboBoxAngleStep.Items13"),
            resources.GetString("toolStripComboBoxAngleStep.Items14"),
            resources.GetString("toolStripComboBoxAngleStep.Items15"),
            resources.GetString("toolStripComboBoxAngleStep.Items16"),
            resources.GetString("toolStripComboBoxAngleStep.Items17")});
            this.toolStripComboBoxAngleStep.Name = "toolStripComboBoxAngleStep";
            // 
            // toolStripSeparator20
            // 
            resources.ApplyResources(this.toolStripSeparator20, "toolStripSeparator20");
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            // 
            // toolStripMenuItemAllSequentialImages
            // 
            resources.ApplyResources(this.toolStripMenuItemAllSequentialImages, "toolStripMenuItemAllSequentialImages");
            this.toolStripMenuItemAllSequentialImages.CheckOnClick = true;
            this.toolStripMenuItemAllSequentialImages.Name = "toolStripMenuItemAllSequentialImages";
            this.toolStripMenuItemAllSequentialImages.CheckedChanged += new System.EventHandler(this.toolStripMenuItemAllSequentialImages_CheckedChanged);
            // 
            // toolStripMenuItemSelectedSequentialImages
            // 
            resources.ApplyResources(this.toolStripMenuItemSelectedSequentialImages, "toolStripMenuItemSelectedSequentialImages");
            this.toolStripMenuItemSelectedSequentialImages.CheckOnClick = true;
            this.toolStripMenuItemSelectedSequentialImages.Name = "toolStripMenuItemSelectedSequentialImages";
            this.toolStripMenuItemSelectedSequentialImages.CheckedChanged += new System.EventHandler(this.toolStripMenuItemSelectedSequentialImages_CheckedChanged);
            // 
            // helpProvider
            // 
            resources.ApplyResources(this.helpProvider, "helpProvider");
            // 
            // toolStripButton1
            // 
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            this.toolStripButton1.Name = "toolStripButton1";
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // FormMain
            // 
            resources.ApplyResources(this, "$this");
            this.AllowDrop = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            settings1.SettingsKey = "";
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", settings1, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.helpProvider.SetHelpKeyword(this, resources.GetString("$this.HelpKeyword"));
            this.helpProvider.SetHelpNavigator(this, ((System.Windows.Forms.HelpNavigator)(resources.GetObject("$this.HelpNavigator"))));
            this.helpProvider.SetHelpString(this, resources.GetString("$this.HelpString"));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.helpProvider.SetShowHelp(this, ((bool)(resources.GetObject("$this.ShowHelp"))));
            this.toolTip.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FormMain_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.FormMain_DragEnter);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FormMain_KeyUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.RightToolStripPanel.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaX1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaY1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaX2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownSelectedAreaY2)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private HelpProvider helpProvider;
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
        private ToolStripMenuItem toolStripMenuItemDividedByAngleStep;
        private ToolStripComboBox toolStripComboBoxAngleStep;
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
        //private ScalablePictureBox scalablePictureBox;








    }
}