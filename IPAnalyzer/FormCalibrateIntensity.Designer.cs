namespace IPAnalyzer
{
    partial class FormCalibrateIntensity
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
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナで生成されたコード

        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormCalibrateIntensity));
            buttonOpenFile1 = new System.Windows.Forms.Button();
            buttonOpenFile2 = new System.Windows.Forms.Button();
            textBoxFile1 = new System.Windows.Forms.TextBox();
            textBoxFile2 = new System.Windows.Forms.TextBox();
            buttonCalibrate = new System.Windows.Forms.Button();
            graphControl1 = new Crystallography.Controls.GraphControl();
            SuspendLayout();
            // 
            // buttonOpenFile1
            // 
            buttonOpenFile1.Location = new System.Drawing.Point(299, 5);
            buttonOpenFile1.Margin = new System.Windows.Forms.Padding(4);
            buttonOpenFile1.Name = "buttonOpenFile1";
            buttonOpenFile1.Size = new System.Drawing.Size(88, 29);
            buttonOpenFile1.TabIndex = 1;
            buttonOpenFile1.Text = "Open";
            buttonOpenFile1.UseVisualStyleBackColor = true;
            buttonOpenFile1.Click += buttonOpenFile_Click;
            // 
            // buttonOpenFile2
            // 
            buttonOpenFile2.Location = new System.Drawing.Point(299, 70);
            buttonOpenFile2.Margin = new System.Windows.Forms.Padding(4);
            buttonOpenFile2.Name = "buttonOpenFile2";
            buttonOpenFile2.Size = new System.Drawing.Size(88, 29);
            buttonOpenFile2.TabIndex = 1;
            buttonOpenFile2.Text = "Open";
            buttonOpenFile2.UseVisualStyleBackColor = true;
            buttonOpenFile2.Click += buttonOpenFile_Click;
            // 
            // textBoxFile1
            // 
            textBoxFile1.Location = new System.Drawing.Point(77, 10);
            textBoxFile1.Margin = new System.Windows.Forms.Padding(4);
            textBoxFile1.Name = "textBoxFile1";
            textBoxFile1.ReadOnly = true;
            textBoxFile1.Size = new System.Drawing.Size(216, 23);
            textBoxFile1.TabIndex = 2;
            // 
            // textBoxFile2
            // 
            textBoxFile2.Location = new System.Drawing.Point(77, 70);
            textBoxFile2.Margin = new System.Windows.Forms.Padding(4);
            textBoxFile2.Name = "textBoxFile2";
            textBoxFile2.ReadOnly = true;
            textBoxFile2.Size = new System.Drawing.Size(216, 23);
            textBoxFile2.TabIndex = 2;
            // 
            // buttonCalibrate
            // 
            buttonCalibrate.Location = new System.Drawing.Point(173, 136);
            buttonCalibrate.Margin = new System.Windows.Forms.Padding(4);
            buttonCalibrate.Name = "buttonCalibrate";
            buttonCalibrate.Size = new System.Drawing.Size(210, 29);
            buttonCalibrate.TabIndex = 1;
            buttonCalibrate.Text = "Calibrate";
            buttonCalibrate.UseVisualStyleBackColor = true;
            buttonCalibrate.Click += buttonCalibrate_Click;
            // 
            // graphControl1
            // 
            graphControl1.AllowMouseOperation = true;
            graphControl1.AxisLineColor = System.Drawing.Color.Gray;
            graphControl1.AxisTextColor = System.Drawing.Color.Black;
            graphControl1.AxisTextFont = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl1.AxisXTextVisible = true;
            graphControl1.AxisYTextVisible = true;
            graphControl1.BackgroundColor = System.Drawing.Color.White;
            graphControl1.BottomMargin = 0D;
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
            graphControl1.LeftMargin = 0F;
            graphControl1.LineWidth = 1F;
            graphControl1.Location = new System.Drawing.Point(4, 225);
            graphControl1.LowerX = 0D;
            graphControl1.LowerY = 0D;
            graphControl1.Margin = new System.Windows.Forms.Padding(4);
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
            graphControl1.Size = new System.Drawing.Size(678, 581);
            graphControl1.Smoothing = false;
            graphControl1.TabIndex = 3;
            graphControl1.UnitX = "";
            graphControl1.UnitY = "";
            graphControl1.UpperPanelFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            graphControl1.UpperPanelVisible = true;
            graphControl1.UpperX = 1D;
            graphControl1.UpperY = 1D;
            graphControl1.UseLineWidth = true;
            graphControl1.VerticalLineColor = System.Drawing.Color.Red;
            graphControl1.XLog = false;
            graphControl1.YLog = false;
            // 
            // FormCalibrateIntensity
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            ClientSize = new System.Drawing.Size(684, 810);
            Controls.Add(graphControl1);
            Controls.Add(textBoxFile2);
            Controls.Add(textBoxFile1);
            Controls.Add(buttonCalibrate);
            Controls.Add(buttonOpenFile2);
            Controls.Add(buttonOpenFile1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4);
            Name = "FormCalibrateIntensity";
            Text = "FormCalibrateIntensity";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonOpenFile1;
        private System.Windows.Forms.Button buttonOpenFile2;
        private System.Windows.Forms.Button buttonCalibrate;
        public System.Windows.Forms.TextBox textBoxFile1;
        public System.Windows.Forms.TextBox textBoxFile2;
        private Crystallography.Controls.GraphControl graphControl1;
    }
}