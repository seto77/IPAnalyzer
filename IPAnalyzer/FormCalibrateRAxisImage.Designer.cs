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
            components = new System.ComponentModel.Container(); // 260531Cl 追加
            toolTip = new System.Windows.Forms.ToolTip(components); // 260531Cl 追加
            toolTip.IsBalloon = true; // 260531Cl 追加: バルーン表示に統一
            toolTip.AutoPopDelay = 10000; // 260531Cl 追加: 長文ツールチップ用に表示時間を10秒へ延長
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibrateRAxisImage));
            textBoxFile1 = new System.Windows.Forms.TextBox();
            textBoxFile2 = new System.Windows.Forms.TextBox();
            textBoxFile3 = new System.Windows.Forms.TextBox();
            buttonReadFile1 = new System.Windows.Forms.Button();
            buttonReadFile2 = new System.Windows.Forms.Button();
            buttonReadFile3 = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            graphControl1 = new Crystallography.Controls.GraphControl();
            button4 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // textBoxFile1
            // 
            textBoxFile1.Location = new System.Drawing.Point(66, 14);
            textBoxFile1.Name = "textBoxFile1";
            toolTip.SetToolTip(textBoxFile1, resources.GetString("textBoxFile1.ToolTip")); // 260531Cl 追加
            textBoxFile1.Size = new System.Drawing.Size(257, 22);
            textBoxFile1.TabIndex = 0;
            // 
            // textBoxFile2
            // 
            textBoxFile2.Location = new System.Drawing.Point(66, 41);
            textBoxFile2.Name = "textBoxFile2";
            toolTip.SetToolTip(textBoxFile2, resources.GetString("textBoxFile2.ToolTip")); // 260531Cl 追加
            textBoxFile2.Size = new System.Drawing.Size(257, 22);
            textBoxFile2.TabIndex = 0;
            // 
            // textBoxFile3
            // 
            textBoxFile3.Location = new System.Drawing.Point(66, 70);
            textBoxFile3.Name = "textBoxFile3";
            toolTip.SetToolTip(textBoxFile3, resources.GetString("textBoxFile3.ToolTip")); // 260531Cl 追加
            textBoxFile3.Size = new System.Drawing.Size(257, 22);
            textBoxFile3.TabIndex = 0;
            // 
            // buttonReadFile1
            // 
            buttonReadFile1.Location = new System.Drawing.Point(329, 11);
            buttonReadFile1.Name = "buttonReadFile1";
            toolTip.SetToolTip(buttonReadFile1, resources.GetString("buttonReadFile1.ToolTip")); // 260531Cl 追加
            buttonReadFile1.Size = new System.Drawing.Size(75, 27);
            buttonReadFile1.TabIndex = 1;
            buttonReadFile1.Text = "Open";
            buttonReadFile1.UseVisualStyleBackColor = true;
            buttonReadFile1.Click += buttonReadFile1_Click;
            // 
            // buttonReadFile2
            // 
            buttonReadFile2.Location = new System.Drawing.Point(329, 39);
            buttonReadFile2.Name = "buttonReadFile2";
            toolTip.SetToolTip(buttonReadFile2, resources.GetString("buttonReadFile2.ToolTip")); // 260531Cl 追加
            buttonReadFile2.Size = new System.Drawing.Size(75, 27);
            buttonReadFile2.TabIndex = 1;
            buttonReadFile2.Text = "Open";
            buttonReadFile2.UseVisualStyleBackColor = true;
            // 
            // buttonReadFile3
            // 
            buttonReadFile3.Location = new System.Drawing.Point(329, 67);
            buttonReadFile3.Name = "buttonReadFile3";
            toolTip.SetToolTip(buttonReadFile3, resources.GetString("buttonReadFile3.ToolTip")); // 260531Cl 追加
            buttonReadFile3.Size = new System.Drawing.Size(75, 27);
            buttonReadFile3.TabIndex = 1;
            buttonReadFile3.Text = "Open";
            buttonReadFile3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(10, 45);
            label1.Name = "label1";
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip")); // 260531Cl 追加
            label1.Size = new System.Drawing.Size(50, 14);
            label1.TabIndex = 3;
            label1.Text = "Image 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 17);
            label2.Name = "label2";
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip")); // 260531Cl 追加
            label2.Size = new System.Drawing.Size(50, 14);
            label2.TabIndex = 3;
            label2.Text = "Image 1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(10, 73);
            label3.Name = "label3";
            toolTip.SetToolTip(label3, resources.GetString("label3.ToolTip")); // 260531Cl 追加
            label3.Size = new System.Drawing.Size(50, 14);
            label3.TabIndex = 3;
            label3.Text = "Image 3";
            // 
            // graphControl1
            // 
            graphControl1.AllowMouseOperation = true;
            graphControl1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            graphControl1.AxisLineColor = System.Drawing.Color.Gray;
            graphControl1.AxisTextColor = System.Drawing.Color.Black;
            graphControl1.AxisXTextVisible = true;
            graphControl1.AxisYTextVisible = true;
            graphControl1.BackgroundColor = System.Drawing.Color.White;
            graphControl1.DivisionLineColor = System.Drawing.Color.LightGray;
            graphControl1.DivisionLineXVisible = true;
            graphControl1.DivisionLineYVisible = true;
            graphControl1.DrawingRange = (Crystallography.RectangleD)resources.GetObject("graphControl1.DrawingRange");
            graphControl1.FixRangeHorizontal = false;
            graphControl1.FixRangeVertical = false;
            graphControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl1.GraphTitle = "";
            graphControl1.Interpolation = false;
            graphControl1.IsIntegerX = false;
            graphControl1.IsIntegerY = false;
            graphControl1.LabelX = "X:";
            graphControl1.LabelY = "Y:";
            graphControl1.LineWidth = 1F;
            graphControl1.Location = new System.Drawing.Point(10, 102);
            graphControl1.LowerX = 0D;
            graphControl1.LowerY = 0D;
            graphControl1.MaximalX = 1D;
            graphControl1.MaximalY = 1D;
            graphControl1.MinimalX = 0D;
            graphControl1.MinimalY = 0D;
            graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            graphControl1.MousePositionVisible = true;
            graphControl1.MousePositionXDigit = -1;
            graphControl1.MousePositionYDigit = -1;
            graphControl1.Name = "graphControl1";
            graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            graphControl1.Profile = null;
            graphControl1.Size = new System.Drawing.Size(799, 486);
            graphControl1.Smoothing = false;
            graphControl1.TabIndex = 4;
            graphControl1.UnitX = "";
            graphControl1.UnitY = "";
            graphControl1.UpperPanelFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl1.UpperX = 1D;
            graphControl1.UpperY = 1D;
            graphControl1.UseLineWidth = true;
            graphControl1.VerticalLineColor = System.Drawing.Color.Red;
            graphControl1.XLog = false;
            graphControl1.YLog = false;
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(623, 34);
            button4.Name = "button4";
            toolTip.SetToolTip(button4, resources.GetString("button4.ToolTip")); // 260531Cl 追加
            button4.Size = new System.Drawing.Size(75, 27);
            button4.TabIndex = 1;
            button4.Text = "Calc !";
            button4.UseVisualStyleBackColor = true;
            // 
            // FormCalibrateRAxisImage
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(821, 600);
            Controls.Add(graphControl1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonReadFile3);
            Controls.Add(button4);
            Controls.Add(buttonReadFile2);
            Controls.Add(buttonReadFile1);
            Controls.Add(textBoxFile3);
            Controls.Add(textBoxFile2);
            Controls.Add(textBoxFile1);
            Name = "FormCalibrateRAxisImage";
            Text = "FormCalibrateRAxisImage";
            ResumeLayout(false);
            PerformLayout();
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
    private System.Windows.Forms.ToolTip toolTip; // 260531Cl 追加
    }
}