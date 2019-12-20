namespace IPAnalyzer
{
    partial class FormIntTable
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

        
            


        public System.Windows.Forms.NumericUpDown numericUpDownMatrixNum;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.DataGrid dataGrid;
        private System.Data.DataSet dataSet;
        private System.Windows.Forms.TextBox textBoxResult;
        private System.Windows.Forms.TextBox textBoxList;
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>

  



        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIntTable));
            this.numericUpDownMatrixNum = new System.Windows.Forms.NumericUpDown();
            this.textBoxResult = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.textBoxList = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGrid();
            this.dataSet = new System.Data.DataSet();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixNum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // numericUpDownMatrixNum
            // 
            this.numericUpDownMatrixNum.Location = new System.Drawing.Point(4, 4);
            this.numericUpDownMatrixNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownMatrixNum.Name = "numericUpDownMatrixNum";
            this.numericUpDownMatrixNum.Size = new System.Drawing.Size(60, 19);
            this.numericUpDownMatrixNum.TabIndex = 2;
            this.numericUpDownMatrixNum.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numericUpDownMatrixNum.ValueChanged += new System.EventHandler(this.numericUpDownMatrixNum_ValueChanged);
            // 
            // textBoxResult
            // 
            this.textBoxResult.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxResult.Location = new System.Drawing.Point(4, 260);
            this.textBoxResult.Name = "textBoxResult";
            this.textBoxResult.Size = new System.Drawing.Size(204, 19);
            this.textBoxResult.TabIndex = 3;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(208, 260);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(104, 20);
            this.buttonAdd.TabIndex = 5;
            this.buttonAdd.Text = "追加";
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // textBoxList
            // 
            this.textBoxList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxList.Location = new System.Drawing.Point(8, 284);
            this.textBoxList.Multiline = true;
            this.textBoxList.Name = "textBoxList";
            this.textBoxList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxList.Size = new System.Drawing.Size(300, 88);
            this.textBoxList.TabIndex = 6;
            // 
            // dataGrid
            // 
            this.dataGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGrid.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGrid.CaptionVisible = false;
            this.dataGrid.DataMember = "";
            this.dataGrid.HeaderForeColor = System.Drawing.SystemColors.ControlText;
            this.dataGrid.Location = new System.Drawing.Point(8, 24);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.PreferredColumnWidth = 36;
            this.dataGrid.ReadOnly = true;
            this.dataGrid.Size = new System.Drawing.Size(480, 232);
            this.dataGrid.TabIndex = 7;
            // 
            // dataSet
            // 
            this.dataSet.DataSetName = "NewDataSet";
            this.dataSet.Locale = new System.Globalization.CultureInfo("ja-JP");
            // 
            // FormIntTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 375);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.textBoxList);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.textBoxResult);
            this.Controls.Add(this.numericUpDownMatrixNum);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormIntTable";
            this.Text = "Intensity Table";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormIntTable_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormIntTable_FormClosed);
            this.Load += new System.EventHandler(this.FormIntTable_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMatrixNum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}