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
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            resources.ApplyResources(this.toolStripContainer1.ContentPanel, "toolStripContainer1.ContentPanel");
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            resources.ApplyResources(this.toolStripContainer1, "toolStripContainer1");
            this.toolStripContainer1.Name = "toolStripContainer1";
            // 
            // toolStripContainer1.RightToolStripPanel
            // 
            this.toolStripContainer1.RightToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.RightToolStripPanel.Controls.Add(this.toolStrip1);
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStrip2);
            // 
            // statusStrip1
            // 
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar,
            this.toolStripStatusLabel});
            this.statusStrip1.Name = "statusStrip1";
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            resources.ApplyResources(this.toolStripProgressBar, "toolStripProgressBar");
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            resources.ApplyResources(this.toolStripStatusLabel, "toolStripStatusLabel");
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.HSplit;
            resources.ApplyResources(this.splitContainer1, "splitContainer1");
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Panel1.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer1.Panel1.Controls.Add(this.panelMousePos);
            this.splitContainer1.Panel1.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            this.splitContainer1.Resize += new System.EventHandler(this.FormMain_Resize);
            // 
            // splitContainer2
            // 
            resources.ApplyResources(this.splitContainer2, "splitContainer2");
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.panel4);
            this.splitContainer2.Panel1.Controls.Add(this.panel3);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.scalablePictureBox);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer2.Panel2.Controls.Add(this.tableLayoutPanel3);
            this.splitContainer2.Panel2.Cursor = System.Windows.Forms.Cursors.Default;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.textBoxInformation);
            this.panel4.Controls.Add(this.label11);
            resources.ApplyResources(this.panel4, "panel4");
            this.panel4.Name = "panel4";
            // 
            // textBoxInformation
            // 
            resources.ApplyResources(this.textBoxInformation, "textBoxInformation");
            this.textBoxInformation.Name = "textBoxInformation";
            this.textBoxInformation.ReadOnly = true;
            // 
            // label11
            // 
            resources.ApplyResources(this.label11, "label11");
            this.label11.Name = "label11";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.scalablePictureBoxThumbnail);
            this.panel3.Controls.Add(this.radioButtonNearCenter);
            this.panel3.Controls.Add(this.radioButtonWhole);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // scalablePictureBoxThumbnail
            // 
            this.scalablePictureBoxThumbnail.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scalablePictureBoxThumbnail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.scalablePictureBoxThumbnail, "scalablePictureBoxThumbnail");
            this.scalablePictureBoxThumbnail.FixZoomAndCenter = false;
            this.scalablePictureBoxThumbnail.FocusEventEnabled = false;
            this.scalablePictureBoxThumbnail.HorizontalFlip = false;
            this.scalablePictureBoxThumbnail.ManualSpotMode = false;
            this.scalablePictureBoxThumbnail.MouseScaling = true;
            this.scalablePictureBoxThumbnail.MouseTranslation = false;
            this.scalablePictureBoxThumbnail.Name = "scalablePictureBoxThumbnail";
            this.scalablePictureBoxThumbnail.ShowAreaRectangle = false;
            this.scalablePictureBoxThumbnail.ShowRimRentangle = false;
            this.scalablePictureBoxThumbnail.VerticalFlip = false;
            this.scalablePictureBoxThumbnail.Zoom = 128D;
            this.scalablePictureBoxThumbnail.MouseDown2 += new Crystallography.Controls.ScalablePictureBox.MouseEvent(this.scalablePictureBoxThumbnail_MouseDown2);
            this.scalablePictureBoxThumbnail.Draw += new Crystallography.Controls.ScalablePictureBox.DrawEvent(this.scalablePictureBoxThumbnail_Draw);
            // 
            // radioButtonNearCenter
            // 
            resources.ApplyResources(this.radioButtonNearCenter, "radioButtonNearCenter");
            this.radioButtonNearCenter.Checked = true;
            this.radioButtonNearCenter.Name = "radioButtonNearCenter";
            this.radioButtonNearCenter.TabStop = true;
            this.radioButtonNearCenter.UseVisualStyleBackColor = true;
            // 
            // radioButtonWhole
            // 
            resources.ApplyResources(this.radioButtonWhole, "radioButtonWhole");
            this.radioButtonWhole.Name = "radioButtonWhole";
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
            this.panel2.Name = "panel2";
            // 
            // comboBoxScale2
            // 
            resources.ApplyResources(this.comboBoxScale2, "comboBoxScale2");
            this.comboBoxScale2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScale2.FormattingEnabled = true;
            this.comboBoxScale2.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale2.Items"),
            resources.GetString("comboBoxScale2.Items1")});
            this.comboBoxScale2.Name = "comboBoxScale2";
            this.comboBoxScale2.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale2_SelectedIndexChanged);
            // 
            // label9
            // 
            resources.ApplyResources(this.label9, "label9");
            this.label9.Name = "label9";
            // 
            // comboBoxScale1
            // 
            resources.ApplyResources(this.comboBoxScale1, "comboBoxScale1");
            this.comboBoxScale1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxScale1.FormattingEnabled = true;
            this.comboBoxScale1.Items.AddRange(new object[] {
            resources.GetString("comboBoxScale1.Items"),
            resources.GetString("comboBoxScale1.Items1")});
            this.comboBoxScale1.Name = "comboBoxScale1";
            this.toolTip.SetToolTip(this.comboBoxScale1, resources.GetString("comboBoxScale1.ToolTip"));
            this.comboBoxScale1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxScale_SelectedIndexChanged);
            // 
            // label7
            // 
            resources.ApplyResources(this.label7, "label7");
            this.label7.Name = "label7";
            // 
            // comboBoxGradient
            // 
            resources.ApplyResources(this.comboBoxGradient, "comboBoxGradient");
            this.comboBoxGradient.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxGradient.FormattingEnabled = true;
            this.comboBoxGradient.Items.AddRange(new object[] {
            resources.GetString("comboBoxGradient.Items"),
            resources.GetString("comboBoxGradient.Items1")});
            this.comboBoxGradient.Name = "comboBoxGradient";
            this.toolTip.SetToolTip(this.comboBoxGradient, resources.GetString("comboBoxGradient.ToolTip"));
            this.comboBoxGradient.SelectedIndexChanged += new System.EventHandler(this.comboBoxGradient_SelectedIndexChanged_1);
            // 
            // label5
            // 
            resources.ApplyResources(this.label5, "label5");
            this.label5.Name = "label5";
            // 
            // scalablePictureBox
            // 
            this.scalablePictureBox.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.scalablePictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            resources.ApplyResources(this.scalablePictureBox, "scalablePictureBox");
            this.scalablePictureBox.FixZoomAndCenter = false;
            this.scalablePictureBox.FocusEventEnabled = false;
            this.scalablePictureBox.HorizontalFlip = false;
            this.scalablePictureBox.ManualSpotMode = false;
            this.scalablePictureBox.MouseScaling = true;
            this.scalablePictureBox.MouseTranslation = true;
            this.scalablePictureBox.Name = "scalablePictureBox";
            this.scalablePictureBox.ShowAreaRectangle = false;
            this.scalablePictureBox.ShowRimRentangle = false;
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
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // labelResolution
            // 
            resources.ApplyResources(this.labelResolution, "labelResolution");
            this.labelResolution.Name = "labelResolution";
            // 
            // labelMousePointChi
            // 
            resources.ApplyResources(this.labelMousePointChi, "labelMousePointChi");
            this.labelMousePointChi.Name = "labelMousePointChi";
            this.labelMousePointChi.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // labelMousePointD
            // 
            resources.ApplyResources(this.labelMousePointD, "labelMousePointD");
            this.labelMousePointD.Name = "labelMousePointD";
            // 
            // labelMousePointTheta
            // 
            resources.ApplyResources(this.labelMousePointTheta, "labelMousePointTheta");
            this.labelMousePointTheta.Name = "labelMousePointTheta";
            // 
            // labelMousePointR
            // 
            resources.ApplyResources(this.labelMousePointR, "labelMousePointR");
            this.labelMousePointR.Name = "labelMousePointR";
            // 
            // labelMousePointIntensity
            // 
            resources.ApplyResources(this.labelMousePointIntensity, "labelMousePointIntensity");
            this.labelMousePointIntensity.Name = "labelMousePointIntensity";
            // 
            // label6
            // 
            resources.ApplyResources(this.label6, "label6");
            this.label6.Name = "label6";
            // 
            // label8
            // 
            resources.ApplyResources(this.label8, "label8");
            this.label8.Name = "label8";
            // 
            // label10
            // 
            resources.ApplyResources(this.label10, "label10");
            this.label10.Name = "label10";
            // 
            // label12
            // 
            resources.ApplyResources(this.label12, "label12");
            this.label12.Name = "label12";
            // 
            // label13
            // 
            resources.ApplyResources(this.label13, "label13");
            this.label13.Name = "label13";
            this.label13.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // label14
            // 
            resources.ApplyResources(this.label14, "label14");
            this.label14.Name = "label14";
            // 
            // tableLayoutPanel3
            // 
            resources.ApplyResources(this.tableLayoutPanel3, "tableLayoutPanel3");
            this.tableLayoutPanel3.Controls.Add(this.labelMousePointReal, 3, 0);
            this.tableLayoutPanel3.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.labelMousePointPixel, 1, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            // 
            // labelMousePointReal
            // 
            resources.ApplyResources(this.labelMousePointReal, "labelMousePointReal");
            this.labelMousePointReal.Name = "labelMousePointReal";
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
            // labelMousePointPixel
            // 
            resources.ApplyResources(this.labelMousePointPixel, "labelMousePointPixel");
            this.labelMousePointPixel.Name = "labelMousePointPixel";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.buttonAutoLevel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonReset, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAdvancedMinInt, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.trackBarAdvancedMaxInt, 1, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            // 
            // buttonAutoLevel
            // 
            resources.ApplyResources(this.buttonAutoLevel, "buttonAutoLevel");
            this.buttonAutoLevel.Name = "buttonAutoLevel";
            this.buttonAutoLevel.Click += new System.EventHandler(this.buttonAutoLevel_Click);
            // 
            // buttonReset
            // 
            resources.ApplyResources(this.buttonReset, "buttonReset");
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // trackBarAdvancedMinInt
            // 
            resources.ApplyResources(this.trackBarAdvancedMinInt, "trackBarAdvancedMinInt");
            this.trackBarAdvancedMinInt.ControlHeight = 27;
            this.trackBarAdvancedMinInt.DecimalPlaces = 0;
            this.trackBarAdvancedMinInt.LogScrollBar = false;
            this.trackBarAdvancedMinInt.Maximum = 65535D;
            this.trackBarAdvancedMinInt.Minimum = 0D;
            this.trackBarAdvancedMinInt.Name = "trackBarAdvancedMinInt";
            this.trackBarAdvancedMinInt.NumericBoxSize = 120;
            this.trackBarAdvancedMinInt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAdvancedMinInt.Smart_Increment = true;
            this.trackBarAdvancedMinInt.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.trackBarAdvancedMinInt.UpDown_Increment = 1D;
            this.trackBarAdvancedMinInt.Value = 0D;
            this.trackBarAdvancedMinInt.ValueChanged += new Crystallography.Controls.TrackBarAdvanced.ValueChangedDelegate(this.trackBarAdvancedMinInt_ValueChanged);
            // 
            // trackBarAdvancedMaxInt
            // 
            resources.ApplyResources(this.trackBarAdvancedMaxInt, "trackBarAdvancedMaxInt");
            this.trackBarAdvancedMaxInt.ControlHeight = 27;
            this.trackBarAdvancedMaxInt.DecimalPlaces = 0;
            this.trackBarAdvancedMaxInt.LogScrollBar = false;
            this.trackBarAdvancedMaxInt.Maximum = 65535D;
            this.trackBarAdvancedMaxInt.Minimum = 0D;
            this.trackBarAdvancedMaxInt.Name = "trackBarAdvancedMaxInt";
            this.trackBarAdvancedMaxInt.NumericBoxSize = 120;
            this.trackBarAdvancedMaxInt.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarAdvancedMaxInt.Smart_Increment = true;
            this.trackBarAdvancedMaxInt.TickStyle = System.Windows.Forms.TickStyle.BottomRight;
            this.trackBarAdvancedMaxInt.UpDown_Increment = 1D;
            this.trackBarAdvancedMaxInt.Value = 65534D;
            this.trackBarAdvancedMaxInt.ValueChanged += new Crystallography.Controls.TrackBarAdvanced.ValueChangedDelegate(this.trackBarAdvancedMaxInt_ValueChanged);
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // panelMousePos
            // 
            resources.ApplyResources(this.panelMousePos, "panelMousePos");
            this.panelMousePos.Name = "panelMousePos";
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tabControl1, "tabControl1");
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.graphControlFrequency);
            this.tabPage1.Cursor = System.Windows.Forms.Cursors.Default;
            resources.ApplyResources(this.tabPage1, "tabPage1");
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // graphControlFrequency
            // 
            this.graphControlFrequency.AllowMouseOperation = true;
            this.graphControlFrequency.BackgroundColor = System.Drawing.Color.White;
            this.graphControlFrequency.BottomMargin = 0D;
            this.graphControlFrequency.DivisionLineColor = System.Drawing.Color.Black;
            this.graphControlFrequency.DivisionSubLineColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.graphControlFrequency, "graphControlFrequency");
            this.graphControlFrequency.FixRangeHorizontal = false;
            this.graphControlFrequency.FixRangeVertical = false;
            this.graphControlFrequency.GraphName = "";
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
            this.graphControlFrequency.Smoothing = false;
            this.graphControlFrequency.TextFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.tabPage2.Controls.Add(this.graphControlProfile);
            resources.ApplyResources(this.tabPage2, "tabPage2");
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // graphControlProfile
            // 
            this.graphControlProfile.AllowMouseOperation = true;
            this.graphControlProfile.BackgroundColor = System.Drawing.Color.White;
            this.graphControlProfile.BottomMargin = 0D;
            this.graphControlProfile.DivisionLineColor = System.Drawing.Color.Black;
            this.graphControlProfile.DivisionSubLineColor = System.Drawing.Color.LightGray;
            resources.ApplyResources(this.graphControlProfile, "graphControlProfile");
            this.graphControlProfile.FixRangeHorizontal = false;
            this.graphControlProfile.FixRangeVertical = false;
            this.graphControlProfile.GraphName = "";
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
            this.graphControlProfile.Smoothing = false;
            this.graphControlProfile.TextFont = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
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
            this.tabPage3.Controls.Add(this.textBoxStatisticsSelectedAreaSequential);
            this.tabPage3.Controls.Add(this.textBoxStatisticsSelectedArea);
            this.tabPage3.Controls.Add(this.flowLayoutPanel2);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label16);
            resources.ApplyResources(this.tabPage3, "tabPage3");
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // textBoxStatisticsSelectedAreaSequential
            // 
            resources.ApplyResources(this.textBoxStatisticsSelectedAreaSequential, "textBoxStatisticsSelectedAreaSequential");
            this.textBoxStatisticsSelectedAreaSequential.Name = "textBoxStatisticsSelectedAreaSequential";
            this.textBoxStatisticsSelectedAreaSequential.ReadOnly = true;
            // 
            // textBoxStatisticsSelectedArea
            // 
            resources.ApplyResources(this.textBoxStatisticsSelectedArea, "textBoxStatisticsSelectedArea");
            this.textBoxStatisticsSelectedArea.Name = "textBoxStatisticsSelectedArea";
            this.textBoxStatisticsSelectedArea.ReadOnly = true;
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
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // label17
            // 
            resources.ApplyResources(this.label17, "label17");
            this.label17.Name = "label17";
            // 
            // numericUpDownSelectedAreaX1
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaX1, "numericUpDownSelectedAreaX1");
            this.numericUpDownSelectedAreaX1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaX1.Name = "numericUpDownSelectedAreaX1";
            this.numericUpDownSelectedAreaX1.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label18
            // 
            resources.ApplyResources(this.label18, "label18");
            this.label18.Name = "label18";
            // 
            // numericUpDownSelectedAreaY1
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaY1, "numericUpDownSelectedAreaY1");
            this.numericUpDownSelectedAreaY1.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaY1.Name = "numericUpDownSelectedAreaY1";
            this.numericUpDownSelectedAreaY1.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label19
            // 
            resources.ApplyResources(this.label19, "label19");
            this.label19.Name = "label19";
            // 
            // numericUpDownSelectedAreaX2
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaX2, "numericUpDownSelectedAreaX2");
            this.numericUpDownSelectedAreaX2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaX2.Name = "numericUpDownSelectedAreaX2";
            this.numericUpDownSelectedAreaX2.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label20
            // 
            resources.ApplyResources(this.label20, "label20");
            this.label20.Name = "label20";
            // 
            // numericUpDownSelectedAreaY2
            // 
            resources.ApplyResources(this.numericUpDownSelectedAreaY2, "numericUpDownSelectedAreaY2");
            this.numericUpDownSelectedAreaY2.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownSelectedAreaY2.Name = "numericUpDownSelectedAreaY2";
            this.numericUpDownSelectedAreaY2.ValueChanged += new System.EventHandler(this.numericUpDownSelectedArea_ValueChanged);
            // 
            // label21
            // 
            resources.ApplyResources(this.label21, "label21");
            this.label21.Name = "label21";
            // 
            // label15
            // 
            resources.ApplyResources(this.label15, "label15");
            this.label15.Name = "label15";
            // 
            // label16
            // 
            resources.ApplyResources(this.label16, "label16");
            this.label16.Name = "label16";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
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
            // 
            // toolStripButtonIntensityTable
            // 
            this.toolStripButtonIntensityTable.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonIntensityTable, "toolStripButtonIntensityTable");
            this.toolStripButtonIntensityTable.Image = global::IPAnalyzer.Properties.Resources.Table;
            this.toolStripButtonIntensityTable.Name = "toolStripButtonIntensityTable";
            this.toolStripButtonIntensityTable.Padding = new System.Windows.Forms.Padding(1);
            // 
            // toolStripSeparator16
            // 
            this.toolStripSeparator16.Name = "toolStripSeparator16";
            resources.ApplyResources(this.toolStripSeparator16, "toolStripSeparator16");
            // 
            // toolStripButtonAutoProcedure
            // 
            this.toolStripButtonAutoProcedure.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonAutoProcedure, "toolStripButtonAutoProcedure");
            this.toolStripButtonAutoProcedure.Image = global::IPAnalyzer.Properties.Resources.AutoProc;
            this.toolStripButtonAutoProcedure.Name = "toolStripButtonAutoProcedure";
            this.toolStripButtonAutoProcedure.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonAutoProcedure.CheckedChanged += new System.EventHandler(this.toolStripButtonAutoProcedure_CheckedChanged);
            // 
            // toolStripSeparator15
            // 
            this.toolStripSeparator15.Name = "toolStripSeparator15";
            resources.ApplyResources(this.toolStripSeparator15, "toolStripSeparator15");
            // 
            // toolStripButtonRing
            // 
            this.toolStripButtonRing.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonRing, "toolStripButtonRing");
            this.toolStripButtonRing.Image = global::IPAnalyzer.Properties.Resources.Ring;
            this.toolStripButtonRing.Name = "toolStripButtonRing";
            this.toolStripButtonRing.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonRing.CheckedChanged += new System.EventHandler(this.toolStripButtonRing_CheckedChanged);
            // 
            // toolStripSeparator14
            // 
            this.toolStripSeparator14.Name = "toolStripSeparator14";
            resources.ApplyResources(this.toolStripSeparator14, "toolStripSeparator14");
            // 
            // toolStripButtonFindParameter
            // 
            this.toolStripButtonFindParameter.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonFindParameter, "toolStripButtonFindParameter");
            this.toolStripButtonFindParameter.Image = global::IPAnalyzer.Properties.Resources.FindParameter;
            this.toolStripButtonFindParameter.Name = "toolStripButtonFindParameter";
            this.toolStripButtonFindParameter.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonFindParameter.CheckedChanged += new System.EventHandler(this.toolStripButtonFindParameter_CheckedChanged);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            resources.ApplyResources(this.toolStripSeparator9, "toolStripSeparator9");
            // 
            // toolStripButtonFindParameterBruteForce
            // 
            this.toolStripButtonFindParameterBruteForce.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonFindParameterBruteForce, "toolStripButtonFindParameterBruteForce");
            this.toolStripButtonFindParameterBruteForce.Image = global::IPAnalyzer.Properties.Resources.FindParameter;
            this.toolStripButtonFindParameterBruteForce.Name = "toolStripButtonFindParameterBruteForce";
            this.toolStripButtonFindParameterBruteForce.Padding = new System.Windows.Forms.Padding(1);
            this.toolStripButtonFindParameterBruteForce.CheckedChanged += new System.EventHandler(this.toolStripButtonFindParameterBruteForce_CheckedChanged);
            // 
            // toolStripSeparator31
            // 
            this.toolStripSeparator31.Name = "toolStripSeparator31";
            resources.ApplyResources(this.toolStripSeparator31, "toolStripSeparator31");
            // 
            // toolStripButtonUnroll
            // 
            this.toolStripButtonUnroll.CheckOnClick = true;
            this.toolStripButtonUnroll.DoubleClickEnabled = true;
            resources.ApplyResources(this.toolStripButtonUnroll, "toolStripButtonUnroll");
            this.toolStripButtonUnroll.Image = global::IPAnalyzer.Properties.Resources.Unrolled;
            this.toolStripButtonUnroll.Name = "toolStripButtonUnroll";
            this.toolStripButtonUnroll.CheckedChanged += new System.EventHandler(this.toolStripSplitButtonUnroll_CheckChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
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
            this.toolStripSeparator17.Name = "toolStripSeparator17";
            resources.ApplyResources(this.toolStripSeparator17, "toolStripSeparator17");
            // 
            // toolStripButtonImageSequence
            // 
            this.toolStripButtonImageSequence.CheckOnClick = true;
            resources.ApplyResources(this.toolStripButtonImageSequence, "toolStripButtonImageSequence");
            this.toolStripButtonImageSequence.Image = global::IPAnalyzer.Properties.Resources.Sequence;
            this.toolStripButtonImageSequence.Name = "toolStripButtonImageSequence";
            this.toolStripButtonImageSequence.CheckedChanged += new System.EventHandler(this.toolStripButtonImageSequence_CheckedChanged);
            // 
            // toolStripSeparator19
            // 
            this.toolStripSeparator19.Name = "toolStripSeparator19";
            resources.ApplyResources(this.toolStripSeparator19, "toolStripSeparator19");
            // 
            // menuStrip
            // 
            resources.ApplyResources(this.menuStrip, "menuStrip");
            this.menuStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
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
            // 
            // fileToolStripMenuItem
            // 
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
            resources.ApplyResources(this.fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // readImageToolStripMenuItem
            // 
            this.readImageToolStripMenuItem.Name = "readImageToolStripMenuItem";
            resources.ApplyResources(this.readImageToolStripMenuItem, "readImageToolStripMenuItem");
            this.readImageToolStripMenuItem.Click += new System.EventHandler(this.readImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItemSaveImage
            // 
            this.toolStripMenuItemSaveImage.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tiffToolStripMenuItem,
            this.pngToolStripMenuItem,
            this.ipaToolStripMenuItem});
            this.toolStripMenuItemSaveImage.Name = "toolStripMenuItemSaveImage";
            resources.ApplyResources(this.toolStripMenuItemSaveImage, "toolStripMenuItemSaveImage");
            // 
            // tiffToolStripMenuItem
            // 
            this.tiffToolStripMenuItem.Name = "tiffToolStripMenuItem";
            resources.ApplyResources(this.tiffToolStripMenuItem, "tiffToolStripMenuItem");
            this.tiffToolStripMenuItem.Click += new System.EventHandler(this.tiffToolStripMenuItem_Click);
            // 
            // pngToolStripMenuItem
            // 
            this.pngToolStripMenuItem.Name = "pngToolStripMenuItem";
            resources.ApplyResources(this.pngToolStripMenuItem, "pngToolStripMenuItem");
            this.pngToolStripMenuItem.Click += new System.EventHandler(this.pngToolStripMenuItem_Click);
            // 
            // ipaToolStripMenuItem
            // 
            this.ipaToolStripMenuItem.Name = "ipaToolStripMenuItem";
            resources.ApplyResources(this.ipaToolStripMenuItem, "ipaToolStripMenuItem");
            this.ipaToolStripMenuItem.Click += new System.EventHandler(this.ipaToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // toolStripMenuItemReadParameter
            // 
            this.toolStripMenuItemReadParameter.Name = "toolStripMenuItemReadParameter";
            resources.ApplyResources(this.toolStripMenuItemReadParameter, "toolStripMenuItemReadParameter");
            this.toolStripMenuItemReadParameter.Click += new System.EventHandler(this.toolStripMenuItemReadParameter_Click);
            // 
            // toolStripMenuItemSaveParameter
            // 
            this.toolStripMenuItemSaveParameter.Name = "toolStripMenuItemSaveParameter";
            resources.ApplyResources(this.toolStripMenuItemSaveParameter, "toolStripMenuItemSaveParameter");
            this.toolStripMenuItemSaveParameter.Click += new System.EventHandler(this.toolStripMenuItemSaveParameter_Click);
            // 
            // toolStripSeparator13
            // 
            this.toolStripSeparator13.Name = "toolStripSeparator13";
            resources.ApplyResources(this.toolStripSeparator13, "toolStripSeparator13");
            // 
            // toolStripMenuItemReadMask
            // 
            this.toolStripMenuItemReadMask.Name = "toolStripMenuItemReadMask";
            resources.ApplyResources(this.toolStripMenuItemReadMask, "toolStripMenuItemReadMask");
            this.toolStripMenuItemReadMask.Click += new System.EventHandler(this.toolStripMenuItemReadMask_Click);
            // 
            // toolStripMenuItemSaveMask
            // 
            this.toolStripMenuItemSaveMask.Name = "toolStripMenuItemSaveMask";
            resources.ApplyResources(this.toolStripMenuItemSaveMask, "toolStripMenuItemSaveMask");
            this.toolStripMenuItemSaveMask.Click += new System.EventHandler(this.toolStripMenuItemSaveMask_Click);
            // 
            // clearMaskToolStripMenuItem
            // 
            this.clearMaskToolStripMenuItem.Name = "clearMaskToolStripMenuItem";
            resources.ApplyResources(this.clearMaskToolStripMenuItem, "clearMaskToolStripMenuItem");
            this.clearMaskToolStripMenuItem.Click += new System.EventHandler(this.clearMaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(this.exitToolStripMenuItem, "exitToolStripMenuItem");
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolToolStripMenuItem
            // 
            this.toolToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetFrequencyProfileToolStripMenuItem,
            this.calibrateRaxisImageToolStripMenuItem});
            this.toolToolStripMenuItem.Name = "toolToolStripMenuItem";
            resources.ApplyResources(this.toolToolStripMenuItem, "toolToolStripMenuItem");
            // 
            // resetFrequencyProfileToolStripMenuItem
            // 
            this.resetFrequencyProfileToolStripMenuItem.Name = "resetFrequencyProfileToolStripMenuItem";
            resources.ApplyResources(this.resetFrequencyProfileToolStripMenuItem, "resetFrequencyProfileToolStripMenuItem");
            this.resetFrequencyProfileToolStripMenuItem.Click += new System.EventHandler(this.resetFrequencyProfileToolStripMenuItem_Click);
            // 
            // calibrateRaxisImageToolStripMenuItem
            // 
            this.calibrateRaxisImageToolStripMenuItem.Name = "calibrateRaxisImageToolStripMenuItem";
            resources.ApplyResources(this.calibrateRaxisImageToolStripMenuItem, "calibrateRaxisImageToolStripMenuItem");
            this.calibrateRaxisImageToolStripMenuItem.Click += new System.EventHandler(this.calibrateRaxisImageToolStripMenuItem_Click);
            // 
            // toolStripMenuItem5
            // 
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
            resources.ApplyResources(this.toolStripMenuItem5, "toolStripMenuItem5");
            // 
            // toolStripMenuItemPropertyWaveSource
            // 
            this.toolStripMenuItemPropertyWaveSource.Name = "toolStripMenuItemPropertyWaveSource";
            resources.ApplyResources(this.toolStripMenuItemPropertyWaveSource, "toolStripMenuItemPropertyWaveSource");
            this.toolStripMenuItemPropertyWaveSource.Click += new System.EventHandler(this.toolStripMenuItemWaveSource_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            resources.ApplyResources(this.toolStripMenuItem9, "toolStripMenuItem9");
            this.toolStripMenuItem9.Click += new System.EventHandler(this.toolStripMenuItemIPCondition_Click);
            // 
            // toolStripSeparator22
            // 
            this.toolStripSeparator22.Name = "toolStripSeparator22";
            resources.ApplyResources(this.toolStripSeparator22, "toolStripSeparator22");
            // 
            // toolStripMenuItem10
            // 
            this.toolStripMenuItem10.Name = "toolStripMenuItem10";
            resources.ApplyResources(this.toolStripMenuItem10, "toolStripMenuItem10");
            this.toolStripMenuItem10.Click += new System.EventHandler(this.toolStripMenuItemIntegralRegion_Click);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            resources.ApplyResources(this.toolStripMenuItem11, "toolStripMenuItem11");
            this.toolStripMenuItem11.Click += new System.EventHandler(this.toolStripMenuItemIntegralProperty_Click);
            // 
            // toolStripSeparator23
            // 
            this.toolStripSeparator23.Name = "toolStripSeparator23";
            resources.ApplyResources(this.toolStripSeparator23, "toolStripSeparator23");
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            resources.ApplyResources(this.toolStripMenuItem12, "toolStripMenuItem12");
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItemManualMaskMode_Click);
            // 
            // toolStripSeparator24
            // 
            this.toolStripSeparator24.Name = "toolStripSeparator24";
            resources.ApplyResources(this.toolStripSeparator24, "toolStripSeparator24");
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            resources.ApplyResources(this.toolStripMenuItem13, "toolStripMenuItem13");
            this.toolStripMenuItem13.Click += new System.EventHandler(this.toolStripMenuItemAfterGetProfile_Click);
            // 
            // toolStripSeparator25
            // 
            this.toolStripSeparator25.Name = "toolStripSeparator25";
            resources.ApplyResources(this.toolStripSeparator25, "toolStripSeparator25");
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            resources.ApplyResources(this.toolStripMenuItem14, "toolStripMenuItem14");
            this.toolStripMenuItem14.Click += new System.EventHandler(this.toolStripMenuItemUnrolledImage_Click);
            // 
            // toolStripSeparator26
            // 
            this.toolStripSeparator26.Name = "toolStripSeparator26";
            resources.ApplyResources(this.toolStripSeparator26, "toolStripSeparator26");
            // 
            // toolStripMenuItem15
            // 
            this.toolStripMenuItem15.Name = "toolStripMenuItem15";
            resources.ApplyResources(this.toolStripMenuItem15, "toolStripMenuItem15");
            this.toolStripMenuItem15.Click += new System.EventHandler(this.toolStripMenuItemAssociatedExtensions_Click);
            // 
            // toolStripSeparator18
            // 
            this.toolStripSeparator18.Name = "toolStripSeparator18";
            resources.ApplyResources(this.toolStripSeparator18, "toolStripSeparator18");
            // 
            // misToolStripMenuItem
            // 
            this.misToolStripMenuItem.Name = "misToolStripMenuItem";
            resources.ApplyResources(this.misToolStripMenuItem, "misToolStripMenuItem");
            this.misToolStripMenuItem.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // optionToolStripMenuItem
            // 
            this.optionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolTipToolStripMenuItem,
            this.toolStripMenuItem2,
            this.rotateToolStripMenuItem,
            this.toolStripSeparator28,
            this.ngenCompileToolStripMenuItem});
            this.optionToolStripMenuItem.Name = "optionToolStripMenuItem";
            resources.ApplyResources(this.optionToolStripMenuItem, "optionToolStripMenuItem");
            // 
            // toolTipToolStripMenuItem
            // 
            this.toolTipToolStripMenuItem.Checked = true;
            this.toolTipToolStripMenuItem.CheckOnClick = true;
            this.toolTipToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolTipToolStripMenuItem.Name = "toolTipToolStripMenuItem";
            resources.ApplyResources(this.toolTipToolStripMenuItem, "toolTipToolStripMenuItem");
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.flipHorizontallyToolStripMenuItem,
            this.flipVerticallyToolStripMenuItem});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            resources.ApplyResources(this.toolStripMenuItem2, "toolStripMenuItem2");
            // 
            // flipHorizontallyToolStripMenuItem
            // 
            this.flipHorizontallyToolStripMenuItem.CheckOnClick = true;
            this.flipHorizontallyToolStripMenuItem.Name = "flipHorizontallyToolStripMenuItem";
            resources.ApplyResources(this.flipHorizontallyToolStripMenuItem, "flipHorizontallyToolStripMenuItem");
            this.flipHorizontallyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.flipHorizontallyToolStripMenuItem_CheckedChanged);
            // 
            // flipVerticallyToolStripMenuItem
            // 
            this.flipVerticallyToolStripMenuItem.CheckOnClick = true;
            this.flipVerticallyToolStripMenuItem.Name = "flipVerticallyToolStripMenuItem";
            resources.ApplyResources(this.flipVerticallyToolStripMenuItem, "flipVerticallyToolStripMenuItem");
            this.flipVerticallyToolStripMenuItem.CheckedChanged += new System.EventHandler(this.flipVerticallyToolStripMenuItem_CheckedChanged);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxRotate});
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            resources.ApplyResources(this.rotateToolStripMenuItem, "rotateToolStripMenuItem");
            // 
            // toolStripComboBoxRotate
            // 
            this.toolStripComboBoxRotate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxRotate.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxRotate.Items"),
            resources.GetString("toolStripComboBoxRotate.Items1"),
            resources.GetString("toolStripComboBoxRotate.Items2"),
            resources.GetString("toolStripComboBoxRotate.Items3")});
            this.toolStripComboBoxRotate.Name = "toolStripComboBoxRotate";
            resources.ApplyResources(this.toolStripComboBoxRotate, "toolStripComboBoxRotate");
            this.toolStripComboBoxRotate.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBoxRotate_SelectedIndexChanged);
            // 
            // toolStripSeparator28
            // 
            this.toolStripSeparator28.Name = "toolStripSeparator28";
            resources.ApplyResources(this.toolStripSeparator28, "toolStripSeparator28");
            // 
            // ngenCompileToolStripMenuItem
            // 
            this.ngenCompileToolStripMenuItem.Name = "ngenCompileToolStripMenuItem";
            resources.ApplyResources(this.ngenCompileToolStripMenuItem, "ngenCompileToolStripMenuItem");
            this.ngenCompileToolStripMenuItem.Click += new System.EventHandler(this.ngenCompileToolStripMenuItem_Click);
            // 
            // languageToolStripMenuItem
            // 
            this.languageToolStripMenuItem.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.languageToolStripMenuItem.Checked = true;
            this.languageToolStripMenuItem.CheckOnClick = true;
            this.languageToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.englishToolStripMenuItem,
            this.japaneseToolStripMenuItem});
            this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(this.languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishToolStripMenuItem
            // 
            this.englishToolStripMenuItem.Checked = true;
            this.englishToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.englishToolStripMenuItem, "englishToolStripMenuItem");
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
            this.macroToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editorToolStripMenuItem,
            this.toolStripSeparator27});
            this.macroToolStripMenuItem.Name = "macroToolStripMenuItem";
            resources.ApplyResources(this.macroToolStripMenuItem, "macroToolStripMenuItem");
            // 
            // editorToolStripMenuItem
            // 
            this.editorToolStripMenuItem.Name = "editorToolStripMenuItem";
            resources.ApplyResources(this.editorToolStripMenuItem, "editorToolStripMenuItem");
            this.editorToolStripMenuItem.Click += new System.EventHandler(this.editorToolStripMenuItem_Click);
            // 
            // toolStripSeparator27
            // 
            this.toolStripSeparator27.Name = "toolStripSeparator27";
            resources.ApplyResources(this.toolStripSeparator27, "toolStripSeparator27");
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programUpdatesToolStripMenuItem,
            this.toolStripSeparator30,
            this.hintToolStripMenuItem,
            this.licenseToolStripMenuItem,
            this.versionHistoryToolStripMenuItem,
            this.toolStripSeparator29,
            this.webPageToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(this.helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // programUpdatesToolStripMenuItem
            // 
            this.programUpdatesToolStripMenuItem.Name = "programUpdatesToolStripMenuItem";
            resources.ApplyResources(this.programUpdatesToolStripMenuItem, "programUpdatesToolStripMenuItem");
            this.programUpdatesToolStripMenuItem.Click += new System.EventHandler(this.programUpdatesToolStripMenuItem_Click);
            // 
            // toolStripSeparator30
            // 
            this.toolStripSeparator30.Name = "toolStripSeparator30";
            resources.ApplyResources(this.toolStripSeparator30, "toolStripSeparator30");
            // 
            // hintToolStripMenuItem
            // 
            this.hintToolStripMenuItem.Name = "hintToolStripMenuItem";
            resources.ApplyResources(this.hintToolStripMenuItem, "hintToolStripMenuItem");
            this.hintToolStripMenuItem.Click += new System.EventHandler(this.hintToolStripMenuItem_Click);
            // 
            // licenseToolStripMenuItem
            // 
            this.licenseToolStripMenuItem.Name = "licenseToolStripMenuItem";
            resources.ApplyResources(this.licenseToolStripMenuItem, "licenseToolStripMenuItem");
            this.licenseToolStripMenuItem.Click += new System.EventHandler(this.licenseToolStripMenuItem_Click);
            // 
            // versionHistoryToolStripMenuItem
            // 
            this.versionHistoryToolStripMenuItem.Name = "versionHistoryToolStripMenuItem";
            resources.ApplyResources(this.versionHistoryToolStripMenuItem, "versionHistoryToolStripMenuItem");
            this.versionHistoryToolStripMenuItem.Click += new System.EventHandler(this.versionHistoryToolStripMenuItem_Click);
            // 
            // toolStripSeparator29
            // 
            this.toolStripSeparator29.Name = "toolStripSeparator29";
            resources.ApplyResources(this.toolStripSeparator29, "toolStripSeparator29");
            // 
            // webPageToolStripMenuItem
            // 
            this.webPageToolStripMenuItem.Name = "webPageToolStripMenuItem";
            resources.ApplyResources(this.webPageToolStripMenuItem, "webPageToolStripMenuItem");
            this.webPageToolStripMenuItem.Click += new System.EventHandler(this.webPageToolStripMenuItem_Click);
            // 
            // toolStrip2
            // 
            this.toolStrip2.BackColor = System.Drawing.SystemColors.Control;
            resources.ApplyResources(this.toolStrip2, "toolStrip2");
            this.toolStrip2.GripMargin = new System.Windows.Forms.Padding(0);
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
            this.toolStrip2.Stretch = true;
            // 
            // toolStripSplitButtonBackground
            // 
            this.toolStripSplitButtonBackground.AutoToolTip = false;
            this.toolStripSplitButtonBackground.DropDownButtonWidth = 18;
            this.toolStripSplitButtonBackground.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.toolStripMenuItem4,
            this.fourierToolStripMenuItem,
            this.toolStripMenuItemReferenceBackground});
            resources.ApplyResources(this.toolStripSplitButtonBackground, "toolStripSplitButtonBackground");
            this.toolStripSplitButtonBackground.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSplitButtonBackground.Image = global::IPAnalyzer.Properties.Resources.BackGround;
            this.toolStripSplitButtonBackground.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonBackground.Name = "toolStripSplitButtonBackground";
            this.toolStripSplitButtonBackground.ButtonClick += new System.EventHandler(this.toolStripSplitButtonBackground_ButtonClick);
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            resources.ApplyResources(this.resetToolStripMenuItem, "resetToolStripMenuItem");
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetBackgroundToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem6,
            this.toolStripComboBoxBackgroundLower,
            this.toolStripMenuItem7,
            this.toolStripComboBoxBackgroundUpper});
            resources.ApplyResources(this.toolStripMenuItem4, "toolStripMenuItem4");
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            resources.ApplyResources(this.toolStripMenuItem6, "toolStripMenuItem6");
            // 
            // toolStripComboBoxBackgroundLower
            // 
            this.toolStripComboBoxBackgroundLower.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxBackgroundLower.Items"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items1"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items2"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items3"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items4"),
            resources.GetString("toolStripComboBoxBackgroundLower.Items5")});
            this.toolStripComboBoxBackgroundLower.Name = "toolStripComboBoxBackgroundLower";
            resources.ApplyResources(this.toolStripComboBoxBackgroundLower, "toolStripComboBoxBackgroundLower");
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            resources.ApplyResources(this.toolStripMenuItem7, "toolStripMenuItem7");
            // 
            // toolStripComboBoxBackgroundUpper
            // 
            this.toolStripComboBoxBackgroundUpper.Items.AddRange(new object[] {
            resources.GetString("toolStripComboBoxBackgroundUpper.Items"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items1"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items2"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items3"),
            resources.GetString("toolStripComboBoxBackgroundUpper.Items4")});
            this.toolStripComboBoxBackgroundUpper.Name = "toolStripComboBoxBackgroundUpper";
            resources.ApplyResources(this.toolStripComboBoxBackgroundUpper, "toolStripComboBoxBackgroundUpper");
            // 
            // fourierToolStripMenuItem
            // 
            this.fourierToolStripMenuItem.Name = "fourierToolStripMenuItem";
            resources.ApplyResources(this.fourierToolStripMenuItem, "fourierToolStripMenuItem");
            this.fourierToolStripMenuItem.Click += new System.EventHandler(this.fourierToolStripMenuItem_Click);
            // 
            // toolStripMenuItemReferenceBackground
            // 
            this.toolStripMenuItemReferenceBackground.Name = "toolStripMenuItemReferenceBackground";
            resources.ApplyResources(this.toolStripMenuItemReferenceBackground, "toolStripMenuItemReferenceBackground");
            this.toolStripMenuItemReferenceBackground.Click += new System.EventHandler(this.ToolStripMenuItemReferenceBackground_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            resources.ApplyResources(this.toolStripSeparator8, "toolStripSeparator8");
            // 
            // toolStripSplitButtonFindCenter
            // 
            this.toolStripSplitButtonFindCenter.DropDownButtonWidth = 18;
            this.toolStripSplitButtonFindCenter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFindCenterOption,
            this.findCenterBasedOnTheRingToolStripMenuItem});
            resources.ApplyResources(this.toolStripSplitButtonFindCenter, "toolStripSplitButtonFindCenter");
            this.toolStripSplitButtonFindCenter.Image = global::IPAnalyzer.Properties.Resources.Center;
            this.toolStripSplitButtonFindCenter.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonFindCenter.Name = "toolStripSplitButtonFindCenter";
            this.toolStripSplitButtonFindCenter.ButtonClick += new System.EventHandler(this.toolStripSplitButtonFindCenter_ButtonClick);
            // 
            // toolStripMenuItemFindCenterOption
            // 
            this.toolStripMenuItemFindCenterOption.Name = "toolStripMenuItemFindCenterOption";
            resources.ApplyResources(this.toolStripMenuItemFindCenterOption, "toolStripMenuItemFindCenterOption");
            this.toolStripMenuItemFindCenterOption.Click += new System.EventHandler(this.toolStripMenuItemMiscellaneous_Click);
            // 
            // findCenterBasedOnTheRingToolStripMenuItem
            // 
            resources.ApplyResources(this.findCenterBasedOnTheRingToolStripMenuItem, "findCenterBasedOnTheRingToolStripMenuItem");
            this.findCenterBasedOnTheRingToolStripMenuItem.Name = "findCenterBasedOnTheRingToolStripMenuItem";
            // 
            // toolStripButtonFixCenter
            // 
            this.toolStripButtonFixCenter.CheckOnClick = true;
            this.toolStripButtonFixCenter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonFixCenter, "toolStripButtonFixCenter");
            this.toolStripButtonFixCenter.ForeColor = System.Drawing.Color.Gray;
            this.toolStripButtonFixCenter.Name = "toolStripButtonFixCenter";
            this.toolStripButtonFixCenter.CheckedChanged += new System.EventHandler(this.toolStripButtonFixCenter_CheckedChanged);
            this.toolStripButtonFixCenter.Click += new System.EventHandler(this.toolStripButtonFixCenter_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            resources.ApplyResources(this.toolStripSeparator6, "toolStripSeparator6");
            // 
            // toolStripSplitButtonFindSpots
            // 
            this.toolStripSplitButtonFindSpots.DropDownButtonWidth = 18;
            this.toolStripSplitButtonFindSpots.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearMask,
            this.toolStripMenuItemMaskAll,
            this.inverseMaskToolStripMenuItem,
            this.toolStripSeparator5,
            this.toolStripMenuItemFindSpotsManual,
            this.toolStripSeparator10,
            this.toolStripMenuItemFindSpotsOption});
            resources.ApplyResources(this.toolStripSplitButtonFindSpots, "toolStripSplitButtonFindSpots");
            this.toolStripSplitButtonFindSpots.ForeColor = System.Drawing.Color.Black;
            this.toolStripSplitButtonFindSpots.Image = global::IPAnalyzer.Properties.Resources.Spot;
            this.toolStripSplitButtonFindSpots.Margin = new System.Windows.Forms.Padding(0);
            this.toolStripSplitButtonFindSpots.Name = "toolStripSplitButtonFindSpots";
            this.toolStripSplitButtonFindSpots.ButtonClick += new System.EventHandler(this.toolStripSplitButtonFindSpots_ButtonClick);
            // 
            // toolStripMenuItemClearMask
            // 
            this.toolStripMenuItemClearMask.Name = "toolStripMenuItemClearMask";
            resources.ApplyResources(this.toolStripMenuItemClearMask, "toolStripMenuItemClearMask");
            this.toolStripMenuItemClearMask.Click += new System.EventHandler(this.toolStripMenuItemClearSpots_Click);
            // 
            // toolStripMenuItemMaskAll
            // 
            this.toolStripMenuItemMaskAll.Name = "toolStripMenuItemMaskAll";
            resources.ApplyResources(this.toolStripMenuItemMaskAll, "toolStripMenuItemMaskAll");
            this.toolStripMenuItemMaskAll.Click += new System.EventHandler(this.toolStripMenuItemMaskAll_Click);
            // 
            // inverseMaskToolStripMenuItem
            // 
            this.inverseMaskToolStripMenuItem.Name = "inverseMaskToolStripMenuItem";
            resources.ApplyResources(this.inverseMaskToolStripMenuItem, "inverseMaskToolStripMenuItem");
            this.inverseMaskToolStripMenuItem.Click += new System.EventHandler(this.inverseMaskToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            resources.ApplyResources(this.toolStripSeparator5, "toolStripSeparator5");
            // 
            // toolStripMenuItemFindSpotsManual
            // 
            this.toolStripMenuItemFindSpotsManual.Name = "toolStripMenuItemFindSpotsManual";
            resources.ApplyResources(this.toolStripMenuItemFindSpotsManual, "toolStripMenuItemFindSpotsManual");
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            resources.ApplyResources(this.toolStripSeparator10, "toolStripSeparator10");
            // 
            // toolStripMenuItemFindSpotsOption
            // 
            this.toolStripMenuItemFindSpotsOption.Name = "toolStripMenuItemFindSpotsOption";
            resources.ApplyResources(this.toolStripMenuItemFindSpotsOption, "toolStripMenuItemFindSpotsOption");
            this.toolStripMenuItemFindSpotsOption.Click += new System.EventHandler(this.toolStripMenuItemManualMaskMode_Click);
            // 
            // toolStripButtonManualSpotMode
            // 
            this.toolStripButtonManualSpotMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(this.toolStripButtonManualSpotMode, "toolStripButtonManualSpotMode");
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
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // toolStripSplitButtonGetProfile
            // 
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
            resources.ApplyResources(this.toolStripSplitButtonGetProfile, "toolStripSplitButtonGetProfile");
            this.toolStripSplitButtonGetProfile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSplitButtonGetProfile.Image = global::IPAnalyzer.Properties.Resources.Profile;
            this.toolStripSplitButtonGetProfile.Name = "toolStripSplitButtonGetProfile";
            this.toolStripSplitButtonGetProfile.ButtonClick += new System.EventHandler(this.toolStripSplitButtonGetProfile_ButtonClick);
            // 
            // toolStripMenuItemGetProfileIntegralProperty
            // 
            this.toolStripMenuItemGetProfileIntegralProperty.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripMenuItemGetProfileIntegralProperty.Name = "toolStripMenuItemGetProfileIntegralProperty";
            resources.ApplyResources(this.toolStripMenuItemGetProfileIntegralProperty, "toolStripMenuItemGetProfileIntegralProperty");
            this.toolStripMenuItemGetProfileIntegralProperty.Click += new System.EventHandler(this.toolStripMenuItemIntegralProperty_Click);
            // 
            // toolStripMenuItemConcenctricIntegration
            // 
            this.toolStripMenuItemConcenctricIntegration.Checked = true;
            this.toolStripMenuItemConcenctricIntegration.CheckState = System.Windows.Forms.CheckState.Checked;
            resources.ApplyResources(this.toolStripMenuItemConcenctricIntegration, "toolStripMenuItemConcenctricIntegration");
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
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            resources.ApplyResources(this.toolStripSeparator7, "toolStripSeparator7");
            // 
            // toolStripMenuItemGetProfileIntegralRegion
            // 
            this.toolStripMenuItemGetProfileIntegralRegion.Name = "toolStripMenuItemGetProfileIntegralRegion";
            resources.ApplyResources(this.toolStripMenuItemGetProfileIntegralRegion, "toolStripMenuItemGetProfileIntegralRegion");
            this.toolStripMenuItemGetProfileIntegralRegion.Click += new System.EventHandler(this.toolStripMenuItemIntegralRegion_Click);
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            resources.ApplyResources(this.toolStripSeparator11, "toolStripSeparator11");
            // 
            // findCenterBeforeGetProfileToolStripMenuItem
            // 
            this.findCenterBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.Checked = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            this.findCenterBeforeGetProfileToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.findCenterBeforeGetProfileToolStripMenuItem.Name = "findCenterBeforeGetProfileToolStripMenuItem";
            resources.ApplyResources(this.findCenterBeforeGetProfileToolStripMenuItem, "findCenterBeforeGetProfileToolStripMenuItem");
            // 
            // findSpotsBeforeGetProfileToolStripMenuItem
            // 
            this.findSpotsBeforeGetProfileToolStripMenuItem.AutoToolTip = true;
            this.findSpotsBeforeGetProfileToolStripMenuItem.CheckOnClick = true;
            this.findSpotsBeforeGetProfileToolStripMenuItem.Name = "findSpotsBeforeGetProfileToolStripMenuItem";
            resources.ApplyResources(this.findSpotsBeforeGetProfileToolStripMenuItem, "findSpotsBeforeGetProfileToolStripMenuItem");
            // 
            // toolStripSeparator21
            // 
            this.toolStripSeparator21.Name = "toolStripSeparator21";
            resources.ApplyResources(this.toolStripSeparator21, "toolStripSeparator21");
            // 
            // toolStripMenuItemSendProfileToPDIndexer
            // 
            this.toolStripMenuItemSendProfileToPDIndexer.Checked = true;
            this.toolStripMenuItemSendProfileToPDIndexer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItemSendProfileToPDIndexer.Name = "toolStripMenuItemSendProfileToPDIndexer";
            resources.ApplyResources(this.toolStripMenuItemSendProfileToPDIndexer, "toolStripMenuItemSendProfileToPDIndexer");
            this.toolStripMenuItemSendProfileToPDIndexer.Click += new System.EventHandler(this.toolStripMenuItemSendProfileToPDIndexer_Click);
            // 
            // toolStripMenuItemSendUnrolledImage
            // 
            this.toolStripMenuItemSendUnrolledImage.Name = "toolStripMenuItemSendUnrolledImage";
            resources.ApplyResources(this.toolStripMenuItemSendUnrolledImage, "toolStripMenuItemSendUnrolledImage");
            this.toolStripMenuItemSendUnrolledImage.Click += new System.EventHandler(this.toolStripMenuItemSendUnrolledImage_Click);
            // 
            // toolStripSeparator12
            // 
            this.toolStripSeparator12.Name = "toolStripSeparator12";
            resources.ApplyResources(this.toolStripSeparator12, "toolStripSeparator12");
            // 
            // toolStripMenuItemDividedByAngleStep
            // 
            this.toolStripMenuItemDividedByAngleStep.CheckOnClick = true;
            this.toolStripMenuItemDividedByAngleStep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.toolStripComboBoxAngleStep});
            this.toolStripMenuItemDividedByAngleStep.Name = "toolStripMenuItemDividedByAngleStep";
            resources.ApplyResources(this.toolStripMenuItemDividedByAngleStep, "toolStripMenuItemDividedByAngleStep");
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
            this.toolStripSeparator20.Name = "toolStripSeparator20";
            resources.ApplyResources(this.toolStripSeparator20, "toolStripSeparator20");
            // 
            // toolStripMenuItemAllSequentialImages
            // 
            this.toolStripMenuItemAllSequentialImages.CheckOnClick = true;
            this.toolStripMenuItemAllSequentialImages.Name = "toolStripMenuItemAllSequentialImages";
            resources.ApplyResources(this.toolStripMenuItemAllSequentialImages, "toolStripMenuItemAllSequentialImages");
            this.toolStripMenuItemAllSequentialImages.CheckedChanged += new System.EventHandler(this.toolStripMenuItemAllSequentialImages_CheckedChanged);
            // 
            // toolStripMenuItemSelectedSequentialImages
            // 
            this.toolStripMenuItemSelectedSequentialImages.CheckOnClick = true;
            this.toolStripMenuItemSelectedSequentialImages.Name = "toolStripMenuItemSelectedSequentialImages";
            resources.ApplyResources(this.toolStripMenuItemSelectedSequentialImages, "toolStripMenuItemSelectedSequentialImages");
            this.toolStripMenuItemSelectedSequentialImages.CheckedChanged += new System.EventHandler(this.toolStripMenuItemSelectedSequentialImages_CheckedChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Name = "toolStripButton1";
            resources.ApplyResources(this.toolStripButton1, "toolStripButton1");
            // 
            // toolTip
            // 
            this.toolTip.IsBalloon = true;
            // 
            // FormMain
            // 
            this.AllowDrop = true;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.toolStripContainer1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
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