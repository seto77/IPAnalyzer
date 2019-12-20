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
            this.buttonOpenFile1.Location = new System.Drawing.Point(256, 4);
            this.buttonOpenFile1.Name = "buttonOpenFile1";
            this.buttonOpenFile1.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile1.TabIndex = 1;
            this.buttonOpenFile1.Text = "Open";
            this.buttonOpenFile1.UseVisualStyleBackColor = true;
            this.buttonOpenFile1.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // buttonOpenFile2
            // 
            this.buttonOpenFile2.Location = new System.Drawing.Point(256, 56);
            this.buttonOpenFile2.Name = "buttonOpenFile2";
            this.buttonOpenFile2.Size = new System.Drawing.Size(75, 23);
            this.buttonOpenFile2.TabIndex = 1;
            this.buttonOpenFile2.Text = "Open";
            this.buttonOpenFile2.UseVisualStyleBackColor = true;
            this.buttonOpenFile2.Click += new System.EventHandler(this.buttonOpenFile_Click);
            // 
            // textBoxFile1
            // 
            this.textBoxFile1.Location = new System.Drawing.Point(66, 8);
            this.textBoxFile1.Name = "textBoxFile1";
            this.textBoxFile1.ReadOnly = true;
            this.textBoxFile1.Size = new System.Drawing.Size(186, 19);
            this.textBoxFile1.TabIndex = 2;
            // 
            // textBoxFile2
            // 
            this.textBoxFile2.Location = new System.Drawing.Point(66, 56);
            this.textBoxFile2.Name = "textBoxFile2";
            this.textBoxFile2.ReadOnly = true;
            this.textBoxFile2.Size = new System.Drawing.Size(186, 19);
            this.textBoxFile2.TabIndex = 2;
            // 
            // buttonCalibrate
            // 
            this.buttonCalibrate.Location = new System.Drawing.Point(148, 109);
            this.buttonCalibrate.Name = "buttonCalibrate";
            this.buttonCalibrate.Size = new System.Drawing.Size(180, 23);
            this.buttonCalibrate.TabIndex = 1;
            this.buttonCalibrate.Text = "Calibrate";
            this.buttonCalibrate.UseVisualStyleBackColor = true;
            this.buttonCalibrate.Click += new System.EventHandler(this.buttonCalibrate_Click);
            // 
            // graphControl1
            // 
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
            this.graphControl1.Location = new System.Drawing.Point(3, 180);
            this.graphControl1.Mode = Crystallography.Controls.GraphControl.DrawingMode.Line;
            this.graphControl1.Name = "graphControl1";
            this.graphControl1.OriginPosition = new System.Drawing.Point(40, 20);
            this.graphControl1.Profile = null;
            this.graphControl1.Size = new System.Drawing.Size(581, 465);
            this.graphControl1.Smoothing = false;
            this.graphControl1.TabIndex = 3;
            this.graphControl1.UpperTextVisible = true;
            this.graphControl1.XLog = false;
            this.graphControl1.YLog = false;
            // 
            // FormCalibrateIntensity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 648);
            this.Controls.Add(this.graphControl1);
            this.Controls.Add(this.textBoxFile2);
            this.Controls.Add(this.textBoxFile1);
            this.Controls.Add(this.buttonCalibrate);
            this.Controls.Add(this.buttonOpenFile2);
            this.Controls.Add(this.buttonOpenFile1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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