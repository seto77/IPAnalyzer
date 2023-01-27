namespace IPAnalyzer
{
    partial class FormSequentialImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSequentialImage));
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.listBox = new System.Windows.Forms.ListBox();
            this.checkBoxMultiSelection = new System.Windows.Forms.CheckBox();
            this.checkBoxAverage = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.radioButtonGetProfileSelectedImages = new System.Windows.Forms.RadioButton();
            this.radioButtonGetProfileOnlyTopmost = new System.Windows.Forms.RadioButton();
            this.radioButtonGetProfileAllImages = new System.Windows.Forms.RadioButton();
            this.checkBoxSummation = new System.Windows.Forms.CheckBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            resources.ApplyResources(this.trackBar1, "trackBar1");
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // listBox
            // 
            resources.ApplyResources(this.listBox, "listBox");
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.FormattingEnabled = true;
            this.listBox.Name = "listBox";
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
            // 
            // checkBoxMultiSelection
            // 
            resources.ApplyResources(this.checkBoxMultiSelection, "checkBoxMultiSelection");
            this.checkBoxMultiSelection.Name = "checkBoxMultiSelection";
            this.checkBoxMultiSelection.UseVisualStyleBackColor = true;
            this.checkBoxMultiSelection.CheckedChanged += new System.EventHandler(this.checkBoxMultiSelection_CheckedChanged);
            // 
            // checkBoxAverage
            // 
            resources.ApplyResources(this.checkBoxAverage, "checkBoxAverage");
            this.checkBoxAverage.Name = "checkBoxAverage";
            this.checkBoxAverage.UseVisualStyleBackColor = true;
            this.checkBoxAverage.CheckedChanged += new System.EventHandler(this.checkBoxAverage_CheckedChanged);
            // 
            // groupBox1
            // 
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // flowLayoutPanel1
            // 
            resources.ApplyResources(this.flowLayoutPanel1, "flowLayoutPanel1");
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileSelectedImages);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileOnlyTopmost);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileAllImages);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            // 
            // radioButtonGetProfileSelectedImages
            // 
            resources.ApplyResources(this.radioButtonGetProfileSelectedImages, "radioButtonGetProfileSelectedImages");
            this.radioButtonGetProfileSelectedImages.Checked = true;
            this.radioButtonGetProfileSelectedImages.Name = "radioButtonGetProfileSelectedImages";
            this.radioButtonGetProfileSelectedImages.TabStop = true;
            this.radioButtonGetProfileSelectedImages.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileSelectedImages.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileOnlyTopmost
            // 
            resources.ApplyResources(this.radioButtonGetProfileOnlyTopmost, "radioButtonGetProfileOnlyTopmost");
            this.radioButtonGetProfileOnlyTopmost.Name = "radioButtonGetProfileOnlyTopmost";
            this.radioButtonGetProfileOnlyTopmost.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileOnlyTopmost.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileAllImages
            // 
            resources.ApplyResources(this.radioButtonGetProfileAllImages, "radioButtonGetProfileAllImages");
            this.radioButtonGetProfileAllImages.Name = "radioButtonGetProfileAllImages";
            this.radioButtonGetProfileAllImages.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileAllImages.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // checkBoxSummation
            // 
            resources.ApplyResources(this.checkBoxSummation, "checkBoxSummation");
            this.checkBoxSummation.Name = "checkBoxSummation";
            this.checkBoxSummation.UseVisualStyleBackColor = true;
            this.checkBoxSummation.CheckedChanged += new System.EventHandler(this.checkBoxSummation_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            resources.ApplyResources(this.flowLayoutPanel2, "flowLayoutPanel2");
            this.flowLayoutPanel2.Controls.Add(this.checkBoxMultiSelection);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxAverage);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxSummation);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            // 
            // FormSequentialImage
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSequentialImage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSequentialImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.CheckBox checkBoxMultiSelection;
        private System.Windows.Forms.CheckBox checkBoxAverage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.RadioButton radioButtonGetProfileOnlyTopmost;
        public System.Windows.Forms.RadioButton radioButtonGetProfileAllImages;
        public System.Windows.Forms.RadioButton radioButtonGetProfileSelectedImages;
        private System.Windows.Forms.CheckBox checkBoxSummation;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
    }
}