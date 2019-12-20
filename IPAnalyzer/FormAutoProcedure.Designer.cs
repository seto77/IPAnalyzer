namespace IPAnalyzer
{
    partial class FormAutoProcedure
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
            this.checkedListBoxAuto = new System.Windows.Forms.CheckedListBox();
            this.buttonAuto = new System.Windows.Forms.Button();
            this.checkBoxIsWatchAndLoad = new System.Windows.Forms.CheckBox();
            this.checkBoxAutoAfterLoad = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // checkedListBoxAuto
            // 
            this.checkedListBoxAuto.CheckOnClick = true;
            this.checkedListBoxAuto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkedListBoxAuto.HorizontalScrollbar = true;
            this.checkedListBoxAuto.Items.AddRange(new object[] {
            "Adjust Contrast",
            "Subtract Background",
            "Find Center",
            "Mask Spots",
            "Get Profile"});
            this.checkedListBoxAuto.Location = new System.Drawing.Point(4, 66);
            this.checkedListBoxAuto.Name = "checkedListBoxAuto";
            this.checkedListBoxAuto.Size = new System.Drawing.Size(173, 84);
            this.checkedListBoxAuto.TabIndex = 26;
            // 
            // buttonAuto
            // 
            this.buttonAuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAuto.Location = new System.Drawing.Point(4, 152);
            this.buttonAuto.Name = "buttonAuto";
            this.buttonAuto.Size = new System.Drawing.Size(173, 24);
            this.buttonAuto.TabIndex = 23;
            this.buttonAuto.Text = "Auto";
            this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
            // 
            // checkBoxIsWatchAndLoad
            // 
            this.checkBoxIsWatchAndLoad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxIsWatchAndLoad.Location = new System.Drawing.Point(3, 2);
            this.checkBoxIsWatchAndLoad.Name = "checkBoxIsWatchAndLoad";
            this.checkBoxIsWatchAndLoad.Size = new System.Drawing.Size(174, 32);
            this.checkBoxIsWatchAndLoad.TabIndex = 25;
            this.checkBoxIsWatchAndLoad.Text = "Watch && load a new image from the current directory";
            this.checkBoxIsWatchAndLoad.CheckedChanged += new System.EventHandler(this.checkBoxIsWatchAndLoad_CheckedChanged);
            // 
            // checkBoxAutoAfterLoad
            // 
            this.checkBoxAutoAfterLoad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBoxAutoAfterLoad.Location = new System.Drawing.Point(3, 34);
            this.checkBoxAutoAfterLoad.Name = "checkBoxAutoAfterLoad";
            this.checkBoxAutoAfterLoad.Size = new System.Drawing.Size(174, 32);
            this.checkBoxAutoAfterLoad.TabIndex = 24;
            this.checkBoxAutoAfterLoad.Text = "After loading an image, Execute \"Auto\"";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // FormAutoProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 176);
            this.Controls.Add(this.checkedListBoxAuto);
            this.Controls.Add(this.buttonAuto);
            this.Controls.Add(this.checkBoxIsWatchAndLoad);
            this.Controls.Add(this.checkBoxAutoAfterLoad);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAutoProcedure";
            this.Text = "Auto Procedure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoProcedure_FormClosing);
            this.Load += new System.EventHandler(this.FormAutoProcedure_Load);
            this.VisibleChanged += new System.EventHandler(this.FormAutoProcedure_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAuto;
        private System.Windows.Forms.Button buttonAuto;
        public System.Windows.Forms.CheckBox checkBoxIsWatchAndLoad;
        public System.Windows.Forms.CheckBox checkBoxAutoAfterLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorker;

    }
}