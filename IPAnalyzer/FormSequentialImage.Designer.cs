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
            IPAnalyzer.Properties.Settings settings1 = new IPAnalyzer.Properties.Settings();
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.Location = new System.Drawing.Point(12, 217);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(289, 69);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // listBox
            // 
            this.listBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(3, 26);
            this.listBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(308, 184);
            this.listBox.TabIndex = 4;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
            // 
            // checkBoxMultiSelection
            // 
            this.checkBoxMultiSelection.AutoSize = true;
            this.checkBoxMultiSelection.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxMultiSelection.Location = new System.Drawing.Point(12, 3);
            this.checkBoxMultiSelection.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxMultiSelection.Name = "checkBoxMultiSelection";
            this.checkBoxMultiSelection.Size = new System.Drawing.Size(166, 32);
            this.checkBoxMultiSelection.TabIndex = 5;
            this.checkBoxMultiSelection.Text = "Multi selection";
            this.checkBoxMultiSelection.UseVisualStyleBackColor = true;
            this.checkBoxMultiSelection.CheckedChanged += new System.EventHandler(this.checkBoxMultiSelection_CheckedChanged);
            // 
            // checkBoxAverage
            // 
            this.checkBoxAverage.AutoSize = true;
            this.checkBoxAverage.Enabled = false;
            this.checkBoxAverage.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAverage.Location = new System.Drawing.Point(136, 3);
            this.checkBoxAverage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxAverage.Name = "checkBoxAverage";
            this.checkBoxAverage.Size = new System.Drawing.Size(110, 32);
            this.checkBoxAverage.TabIndex = 5;
            this.checkBoxAverage.Text = "Average";
            this.checkBoxAverage.UseVisualStyleBackColor = true;
            this.checkBoxAverage.CheckedChanged += new System.EventHandler(this.checkBoxAverage_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Location = new System.Drawing.Point(3, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(268, 82);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Target(s) of \"Get Profile\"";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileSelectedImages);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileOnlyTopmost);
            this.flowLayoutPanel1.Controls.Add(this.radioButtonGetProfileAllImages);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 27);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(262, 52);
            this.flowLayoutPanel1.TabIndex = 8;
            // 
            // radioButtonGetProfileSelectedImages
            // 
            this.radioButtonGetProfileSelectedImages.AutoSize = true;
            this.radioButtonGetProfileSelectedImages.Checked = true;
            this.radioButtonGetProfileSelectedImages.Location = new System.Drawing.Point(0, 0);
            this.radioButtonGetProfileSelectedImages.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileSelectedImages.Name = "radioButtonGetProfileSelectedImages";
            this.radioButtonGetProfileSelectedImages.Size = new System.Drawing.Size(206, 29);
            this.radioButtonGetProfileSelectedImages.TabIndex = 7;
            this.radioButtonGetProfileSelectedImages.TabStop = true;
            this.radioButtonGetProfileSelectedImages.Text = "The selected image(s)";
            this.radioButtonGetProfileSelectedImages.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileSelectedImages.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileOnlyTopmost
            // 
            this.radioButtonGetProfileOnlyTopmost.AutoSize = true;
            this.radioButtonGetProfileOnlyTopmost.Location = new System.Drawing.Point(0, 29);
            this.radioButtonGetProfileOnlyTopmost.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileOnlyTopmost.Name = "radioButtonGetProfileOnlyTopmost";
            this.radioButtonGetProfileOnlyTopmost.Size = new System.Drawing.Size(232, 29);
            this.radioButtonGetProfileOnlyTopmost.TabIndex = 7;
            this.radioButtonGetProfileOnlyTopmost.Text = "Only the topmost image";
            this.radioButtonGetProfileOnlyTopmost.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileOnlyTopmost.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileAllImages
            // 
            this.radioButtonGetProfileAllImages.AutoSize = true;
            this.radioButtonGetProfileAllImages.Location = new System.Drawing.Point(0, 58);
            this.radioButtonGetProfileAllImages.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileAllImages.Name = "radioButtonGetProfileAllImages";
            this.radioButtonGetProfileAllImages.Size = new System.Drawing.Size(377, 29);
            this.radioButtonGetProfileAllImages.TabIndex = 7;
            this.radioButtonGetProfileAllImages.Text = "All images irrespective of current selections";
            this.radioButtonGetProfileAllImages.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileAllImages.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // checkBoxSummation
            // 
            this.checkBoxSummation.AutoSize = true;
            this.checkBoxSummation.Enabled = false;
            this.checkBoxSummation.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxSummation.Location = new System.Drawing.Point(217, 3);
            this.checkBoxSummation.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.checkBoxSummation.Name = "checkBoxSummation";
            this.checkBoxSummation.Size = new System.Drawing.Size(139, 32);
            this.checkBoxSummation.TabIndex = 5;
            this.checkBoxSummation.Text = "Summation";
            this.checkBoxSummation.UseVisualStyleBackColor = true;
            this.checkBoxSummation.CheckedChanged += new System.EventHandler(this.checkBoxSummation_CheckedChanged);
            // 
            // FormSequentialImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(313, 349);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxSummation);
            this.Controls.Add(this.checkBoxAverage);
            this.Controls.Add(this.checkBoxMultiSelection);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.trackBar1);
            settings1.SettingsKey = "";
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", settings1, "FormSequentialImageLocation", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSequentialImage";
            this.Text = "Sequential Image Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSequentialImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}