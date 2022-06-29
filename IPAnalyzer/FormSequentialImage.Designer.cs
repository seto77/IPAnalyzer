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
            this.trackBar1.AutoSize = false;
            this.trackBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.trackBar1.Location = new System.Drawing.Point(0, 259);
            this.trackBar1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(336, 28);
            this.trackBar1.TabIndex = 3;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.listBox.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.listBox.FormattingEnabled = true;
            this.listBox.ItemHeight = 15;
            this.listBox.Location = new System.Drawing.Point(0, 24);
            this.listBox.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(336, 235);
            this.listBox.TabIndex = 4;
            this.listBox.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox_DrawItem);
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.listBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_KeyDown);
            // 
            // checkBoxMultiSelection
            // 
            this.checkBoxMultiSelection.AutoSize = true;
            this.checkBoxMultiSelection.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxMultiSelection.Location = new System.Drawing.Point(2, 3);
            this.checkBoxMultiSelection.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxMultiSelection.Name = "checkBoxMultiSelection";
            this.checkBoxMultiSelection.Size = new System.Drawing.Size(111, 21);
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
            this.checkBoxAverage.Location = new System.Drawing.Point(117, 3);
            this.checkBoxAverage.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxAverage.Name = "checkBoxAverage";
            this.checkBoxAverage.Size = new System.Drawing.Size(75, 21);
            this.checkBoxAverage.TabIndex = 5;
            this.checkBoxAverage.Text = "Average";
            this.checkBoxAverage.UseVisualStyleBackColor = true;
            this.checkBoxAverage.CheckedChanged += new System.EventHandler(this.checkBoxAverage_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 287);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(336, 79);
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
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(2, 18);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(332, 59);
            this.flowLayoutPanel1.TabIndex = 8;
            this.flowLayoutPanel1.WrapContents = false;
            // 
            // radioButtonGetProfileSelectedImages
            // 
            this.radioButtonGetProfileSelectedImages.AutoSize = true;
            this.radioButtonGetProfileSelectedImages.Checked = true;
            this.radioButtonGetProfileSelectedImages.Location = new System.Drawing.Point(0, 0);
            this.radioButtonGetProfileSelectedImages.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileSelectedImages.Name = "radioButtonGetProfileSelectedImages";
            this.radioButtonGetProfileSelectedImages.Size = new System.Drawing.Size(140, 19);
            this.radioButtonGetProfileSelectedImages.TabIndex = 7;
            this.radioButtonGetProfileSelectedImages.TabStop = true;
            this.radioButtonGetProfileSelectedImages.Text = "The selected image(s)";
            this.radioButtonGetProfileSelectedImages.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileSelectedImages.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileOnlyTopmost
            // 
            this.radioButtonGetProfileOnlyTopmost.AutoSize = true;
            this.radioButtonGetProfileOnlyTopmost.Location = new System.Drawing.Point(0, 19);
            this.radioButtonGetProfileOnlyTopmost.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileOnlyTopmost.Name = "radioButtonGetProfileOnlyTopmost";
            this.radioButtonGetProfileOnlyTopmost.Size = new System.Drawing.Size(154, 19);
            this.radioButtonGetProfileOnlyTopmost.TabIndex = 7;
            this.radioButtonGetProfileOnlyTopmost.Text = "Only the topmost image";
            this.radioButtonGetProfileOnlyTopmost.UseVisualStyleBackColor = true;
            this.radioButtonGetProfileOnlyTopmost.CheckedChanged += new System.EventHandler(this.RadioButtonGetProfileOnlyTopmost_CheckedChanged);
            // 
            // radioButtonGetProfileAllImages
            // 
            this.radioButtonGetProfileAllImages.AutoSize = true;
            this.radioButtonGetProfileAllImages.Location = new System.Drawing.Point(0, 38);
            this.radioButtonGetProfileAllImages.Margin = new System.Windows.Forms.Padding(0);
            this.radioButtonGetProfileAllImages.Name = "radioButtonGetProfileAllImages";
            this.radioButtonGetProfileAllImages.Size = new System.Drawing.Size(253, 19);
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
            this.checkBoxSummation.Location = new System.Drawing.Point(196, 3);
            this.checkBoxSummation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.checkBoxSummation.Name = "checkBoxSummation";
            this.checkBoxSummation.Size = new System.Drawing.Size(92, 21);
            this.checkBoxSummation.TabIndex = 5;
            this.checkBoxSummation.Text = "Summation";
            this.checkBoxSummation.UseVisualStyleBackColor = true;
            this.checkBoxSummation.CheckedChanged += new System.EventHandler(this.checkBoxSummation_CheckedChanged);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.checkBoxMultiSelection);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxAverage);
            this.flowLayoutPanel2.Controls.Add(this.checkBoxSummation);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(336, 24);
            this.flowLayoutPanel2.TabIndex = 8;
            // 
            // FormSequentialImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(336, 366);
            this.Controls.Add(this.listBox);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSequentialImage";
            this.Text = "Sequential Image Option";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormSequentialImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.groupBox1.ResumeLayout(false);
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