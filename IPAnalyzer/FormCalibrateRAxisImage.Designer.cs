namespace IPAnalyzer
{
    partial class FormCalibrateRAxisImage
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
            this.textBoxFile1 = new System.Windows.Forms.TextBox();
            this.textBoxFile2 = new System.Windows.Forms.TextBox();
            this.textBoxFile3 = new System.Windows.Forms.TextBox();
            this.buttonReadFile1 = new System.Windows.Forms.Button();
            this.buttonReadFile2 = new System.Windows.Forms.Button();
            this.buttonReadFile3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxFile1
            // 
            this.textBoxFile1.Location = new System.Drawing.Point(66, 14);
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.Size = new System.Drawing.Size(257, 22);
            this.textBoxFile1.TabIndex = 0;
            // 
            // textBoxFile2
            // 
            this.textBoxFile2.Location = new System.Drawing.Point(66, 41);
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.Size = new System.Drawing.Size(257, 22);
            this.textBoxFile2.TabIndex = 0;
            // 
            // textBoxFile3
            // 
            this.textBoxFile3.Location = new System.Drawing.Point(66, 70);
            this.textBoxFile3.Name = "textBoxFile3";
            this.textBoxFile3.Size = new System.Drawing.Size(257, 22);
            this.textBoxFile3.TabIndex = 0;
            // 
            // buttonReadFile1
            // 
            this.buttonReadFile1.Location = new System.Drawing.Point(329, 11);
            this.buttonReadFile1.Name = "buttonReadFile1";
            this.buttonReadFile1.Size = new System.Drawing.Size(75, 27);
            this.buttonReadFile1.TabIndex = 1;
            this.buttonReadFile1.Text = "Open";
            this.buttonReadFile1.UseVisualStyleBackColor = true;
            this.buttonReadFile1.Click += new System.EventHandler(this.buttonReadFile1_Click);
            // 
            // buttonReadFile2
            // 
            this.buttonReadFile2.Location = new System.Drawing.Point(329, 39);
            this.buttonReadFile2.Name = "buttonReadFile2";
            this.buttonReadFile2.Size = new System.Drawing.Size(75, 27);
            this.buttonReadFile2.TabIndex = 1;
            this.buttonReadFile2.Text = "Open";
            this.buttonReadFile2.UseVisualStyleBackColor = true;
            // 
            // buttonReadFile3
            // 
            this.buttonReadFile3.Location = new System.Drawing.Point(329, 67);
            this.buttonReadFile3.Name = "buttonReadFile3";
            this.buttonReadFile3.Size = new System.Drawing.Size(75, 27);
            this.buttonReadFile3.TabIndex = 1;
            this.buttonReadFile3.Text = "Open";
            this.buttonReadFile3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Image 2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Image 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "Image 3";
            // 
            // graphControl1
            // 
            this.graphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0F;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControl1.FixRangeHorizontal = false;
            this.graphControl1.FixRangeVertical = false;
            this.graphControl1.IsIntegerX = false;
            this.graphControl1.IsIntegerY = false;
            this.graphControl1.LabelX = "X:";
            this.graphControl1.LabelY = "Y:";
            this.graphControl1.LeftMargin = 0F;
            this.graphControl1.LineColor = System.Drawing.Color.Red;
            this.graphControl1.LineList = new Crystallography.PointD[0];
            this.graphControl1.LineWidth = 1F;
            this.graphControl1.Location = new System.Drawing.Point(10, 102);
            this.graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            this.graphControl1.Profile = null;
            this.graphControl1.Size = new System.Drawing.Size(799, 486);
            this.graphControl1.Smoothing = false;
            this.graphControl1.TabIndex = 4;
            this.graphControl1.UpperTextVisible = true;
            this.graphControl1.XLog = false;
            this.graphControl1.YLog = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(623, 34);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 27);
            this.button4.TabIndex = 1;
            this.button4.Text = "Calc !";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // FormCalibrateRAxisImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 600);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonReadFile3);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.buttonReadFile2);
            this.Controls.Add(this.buttonReadFile1);
            this.Controls.Add(this.textBoxFile3);
            this.Controls.Add(this.textBoxFile2);
            this.Controls.Add(this.textBoxFile1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "FormCalibrateRAxisImage";
            this.Text = "FormCalibrateRAxisImage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFile1;
        private System.Windows.Forms.TextBox textBoxFile2;
        private System.Windows.Forms.TextBox textBoxFile3;
        private System.Windows.Forms.Button buttonReadFile1;
        private System.Windows.Forms.Button buttonReadFile2;
        private System.Windows.Forms.Button buttonReadFile3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private Crystallography.Controls.GraphControl graphControl1;
        private System.Windows.Forms.Button button4;
    }
}