namespace IPAnalyzer
{
    partial class FormSaveImage
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
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numericUpDownHeight = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownWidth = new System.Windows.Forms.NumericUpDown();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOK = new System.Windows.Forms.Button();
            this.numericUpDownResolution = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.checkBoxKeepAspect = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownCenterX = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownCenterY = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(209, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(2, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(129, 17);
            this.label5.TabIndex = 11;
            this.label5.Text = "New image property";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(108, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 8;
            this.label1.Text = "Width";
            // 
            // numericUpDownHeight
            // 
            this.numericUpDownHeight.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownHeight.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownHeight.Location = new System.Drawing.Point(261, 35);
            this.numericUpDownHeight.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDownHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownHeight.Name = "numericUpDownHeight";
            this.numericUpDownHeight.Size = new System.Drawing.Size(47, 25);
            this.numericUpDownHeight.TabIndex = 1;
            this.numericUpDownHeight.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownHeight.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // numericUpDownWidth
            // 
            this.numericUpDownWidth.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownWidth.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownWidth.Location = new System.Drawing.Point(156, 35);
            this.numericUpDownWidth.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDownWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownWidth.Name = "numericUpDownWidth";
            this.numericUpDownWidth.Size = new System.Drawing.Size(47, 25);
            this.numericUpDownWidth.TabIndex = 0;
            this.numericUpDownWidth.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownWidth.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(416, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(65, 25);
            this.buttonCancel.TabIndex = 5;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOK.Location = new System.Drawing.Point(345, 95);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(65, 25);
            this.buttonOK.TabIndex = 4;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // numericUpDownResolution
            // 
            this.numericUpDownResolution.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownResolution.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownResolution.Location = new System.Drawing.Point(156, 97);
            this.numericUpDownResolution.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownResolution.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownResolution.Name = "numericUpDownResolution";
            this.numericUpDownResolution.Size = new System.Drawing.Size(47, 25);
            this.numericUpDownResolution.TabIndex = 3;
            this.numericUpDownResolution.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownResolution.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(209, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 17);
            this.label7.TabIndex = 10;
            this.label7.Text = "μm / pixel";
            // 
            // checkBoxKeepAspect
            // 
            this.checkBoxKeepAspect.AutoSize = true;
            this.checkBoxKeepAspect.Checked = true;
            this.checkBoxKeepAspect.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxKeepAspect.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxKeepAspect.Location = new System.Drawing.Point(325, 39);
            this.checkBoxKeepAspect.Name = "checkBoxKeepAspect";
            this.checkBoxKeepAspect.Size = new System.Drawing.Size(134, 21);
            this.checkBoxKeepAspect.TabIndex = 2;
            this.checkBoxKeepAspect.Text = "Keep Aspect Ratio";
            this.checkBoxKeepAspect.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(34, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Resolution";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(34, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 11;
            this.label6.Text = "Center position";
            // 
            // numericUpDownCenterX
            // 
            this.numericUpDownCenterX.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCenterX.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCenterX.Location = new System.Drawing.Point(156, 66);
            this.numericUpDownCenterX.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDownCenterX.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
            this.numericUpDownCenterX.Name = "numericUpDownCenterX";
            this.numericUpDownCenterX.Size = new System.Drawing.Size(47, 25);
            this.numericUpDownCenterX.TabIndex = 0;
            this.numericUpDownCenterX.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownCenterX.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // numericUpDownCenterY
            // 
            this.numericUpDownCenterY.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownCenterY.Increment = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numericUpDownCenterY.Location = new System.Drawing.Point(261, 66);
            this.numericUpDownCenterY.Maximum = new decimal(new int[] {
            4096,
            0,
            0,
            0});
            this.numericUpDownCenterY.Minimum = new decimal(new int[] {
            4096,
            0,
            0,
            -2147483648});
            this.numericUpDownCenterY.Name = "numericUpDownCenterY";
            this.numericUpDownCenterY.Size = new System.Drawing.Size(47, 25);
            this.numericUpDownCenterY.TabIndex = 0;
            this.numericUpDownCenterY.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.numericUpDownCenterY.ValueChanged += new System.EventHandler(this.numericUpDownWidth_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(137, 68);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(16, 17);
            this.label8.TabIndex = 8;
            this.label8.Text = "X";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(239, 68);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(15, 17);
            this.label9.TabIndex = 8;
            this.label9.Text = "Y";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(34, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Size";
            // 
            // FormSaveImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 130);
            this.ControlBox = false;
            this.Controls.Add(this.checkBoxKeepAspect);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownHeight);
            this.Controls.Add(this.numericUpDownResolution);
            this.Controls.Add(this.numericUpDownCenterY);
            this.Controls.Add(this.numericUpDownCenterX);
            this.Controls.Add(this.numericUpDownWidth);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSaveImage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Save IPA Image";
            this.TopMost = true;
            this.VisibleChanged += new System.EventHandler(this.FormSaveImage_VisibleChanged);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownResolution)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownCenterY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.NumericUpDown numericUpDownHeight;
        public System.Windows.Forms.NumericUpDown numericUpDownWidth;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOK;
        public System.Windows.Forms.NumericUpDown numericUpDownResolution;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox checkBoxKeepAspect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.NumericUpDown numericUpDownCenterX;
        public System.Windows.Forms.NumericUpDown numericUpDownCenterY;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
    }
}