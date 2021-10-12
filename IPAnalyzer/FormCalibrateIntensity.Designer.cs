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
            this.buttonOpenFile1 = new System.Windows.Forms.Button();
            this.buttonOpenFile2 = new System.Windows.Forms.Button();
            this.textBoxFile1 = new System.Windows.Forms.TextBox();
            this.textBoxFile2 = new System.Windows.Forms.TextBox();
            this.buttonCalibrate = new System.Windows.Forms.Button();
            this.graphControl1 = new Crystallography.Controls.GraphControl();
            this.SuspendLayout();
            // 
            // buttonOpenFile1
            // 
            this.buttonOpenFile1.Location = new System.Drawing.Point(299, 5);
            this.buttonOpenFile1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpenFile1.Name = "buttonOpenFile1";
            this.buttonOpenFile1.Size = new System.Drawing.Size(88, 29);
            this.buttonOpenFile1.TabIndex = 1;
            this.buttonOpenFile1.Text = "Open";
            this.buttonOpenFile1.UseVisualStyleBackColor = true;
            this.buttonOpenFile1.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonOpenFile2
            // 
            this.buttonOpenFile2.Location = new System.Drawing.Point(299, 70);
            this.buttonOpenFile2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonOpenFile2.Name = "buttonOpenFile2";
            this.buttonOpenFile2.Size = new System.Drawing.Size(88, 29);
            this.buttonOpenFile2.TabIndex = 1;
            this.buttonOpenFile2.Text = "Open";
            this.buttonOpenFile2.UseVisualStyleBackColor = true;
            this.buttonOpenFile2.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxFile1
            // 
            this.textBoxFile1.Location = new System.Drawing.Point(77, 10);
            this.textBoxFile1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.ReadOnly = true;
            this.textBoxFile1.Size = new System.Drawing.Size(216, 23);
            this.textBoxFile1.TabIndex = 2;
            // 
            // textBoxFile2
            // 
            this.textBoxFile2.Location = new System.Drawing.Point(77, 70);
            this.textBoxFile2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.ReadOnly = true;
            this.textBoxFile2.Size = new System.Drawing.Size(216, 23);
            this.textBoxFile2.TabIndex = 2;
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.Location = new System.Drawing.Point(173, 136);
            this.buttonCalibrate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(210, 29);
            this.buttonCalibrate.TabIndex = 1;
            this.buttonCalibrate.Text = "Calibrate";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            this.buttonCalibrate.Click += new System.EventHandler(this.buttonCalibrate_Click);
            // 
            // graphControl1
            // 
            this.graphControl1.AllowMouseOperation = true;
            this.graphControl1.BackgroundColor = System.Drawing.Color.White;
            this.graphControl1.BottomMargin = 0D;
            this.graphControl1.DivisionLineColor = System.Drawing.Color.Gray;
            this.graphControl1.DivisionSubLineColor = System.Drawing.Color.LightGray;
            this.graphControl1.FixRangeHorizontal = false;
            this.graphControl1.FixRangeVertical = false;
            this.graphControl1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphControl1.GraphName = "";
            this.graphControl1.HorizontalGradiationTextVisivle = true;
            this.graphControl1.Interpolation = false;
            this.graphControl1.IsIntegerX = false;
            this.graphControl1.IsIntegerY = false;
            this.graphControl1.LabelX = "X:";
            this.graphControl1.LabelY = "Y:";
            this.graphControl1.LeftMargin = 0F;
            this.graphControl1.LineColor = System.Drawing.Color.Red;
            this.graphControl1.LineWidth = 1F;
            this.graphControl1.Location = new System.Drawing.Point(4, 225);
            this.graphControl1.LowerX = 0D;
            this.graphControl1.LowerY = 0D;
            this.graphControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.graphControl1.MaximalX = 1D;
            this.graphControl1.MaximalY = 1D;
            this.graphControl1.MinimalX = 0D;
            this.graphControl1.MinimalY = 0D;
            this.graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControl1.MousePositionVisible = true;
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            this.graphControl1.Size = new System.Drawing.Size(678, 581);
            this.graphControl1.Smoothing = false;
            this.graphControl1.TabIndex = 3;
            this.graphControl1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.graphControl1.UnitX = "";
            this.graphControl1.UnitY = "";
            this.graphControl1.UpperText = "";
            this.graphControl1.UpperTextVisible = true;
            this.graphControl1.UpperX = 1D;
            this.graphControl1.UpperY = 1D;
            this.graphControl1.UseLineWidth = true;
            this.graphControl1.VerticalGradiationTextVisivle = true;
            this.graphControl1.XLog = false;
            this.graphControl1.XScaleLineVisible = true;
            this.graphControl1.YLog = false;
            this.graphControl1.YScaleLineVisible = true;
            // 
            // FormCalibrateIntensity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(684, 810);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.textBoxFile2);
            this.Controls.Add(this.textBoxFile1);
            this.Controls.Add(this.buttonCalibrate);
            this.Controls.Add(this.buttonOpenFile2);
            this.Controls.Add(this.buttonOpenFile1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormCalibrateIntensity";
            this.Text = "FormCalibrateIntensity";
            this.ResumeLayout(false);
            this.PerformLayout();

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