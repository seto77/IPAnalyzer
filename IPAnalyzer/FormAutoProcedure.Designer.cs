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
            this.checkBoxAutoAfterLoad = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.textBoxDiectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSetDirectory = new System.Windows.Forms.Button();
            this.buttonWatch = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkedListBoxAuto
            // 
            this.checkedListBoxAuto.CheckOnClick = true;
            this.checkedListBoxAuto.ColumnWidth = 150;
            this.checkedListBoxAuto.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkedListBoxAuto.HorizontalScrollbar = true;
            this.checkedListBoxAuto.Items.AddRange(new object[] {
            "Adjust Contrast",
            "Subtract Background",
            "Find Center",
            "Mask Spots",
            "Get Profile"});
            this.checkedListBoxAuto.Location = new System.Drawing.Point(8, 100);
            this.checkedListBoxAuto.Margin = new System.Windows.Forms.Padding(4);
            this.checkedListBoxAuto.MultiColumn = true;
            this.checkedListBoxAuto.Name = "checkedListBoxAuto";
            this.checkedListBoxAuto.Size = new System.Drawing.Size(315, 52);
            this.checkedListBoxAuto.TabIndex = 26;
            // 
            // buttonAuto
            // 
            this.buttonAuto.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.buttonAuto.Location = new System.Drawing.Point(8, 152);
            this.buttonAuto.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAuto.Name = "buttonAuto";
            this.buttonAuto.Size = new System.Drawing.Size(315, 25);
            this.buttonAuto.TabIndex = 23;
            this.buttonAuto.Text = "Auto";
            this.buttonAuto.Click += new System.EventHandler(this.buttonAuto_Click);
            // 
            // checkBoxAutoAfterLoad
            // 
            this.checkBoxAutoAfterLoad.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.checkBoxAutoAfterLoad.Location = new System.Drawing.Point(8, 80);
            this.checkBoxAutoAfterLoad.Margin = new System.Windows.Forms.Padding(4);
            this.checkBoxAutoAfterLoad.Name = "checkBoxAutoAfterLoad";
            this.checkBoxAutoAfterLoad.Size = new System.Drawing.Size(224, 21);
            this.checkBoxAutoAfterLoad.TabIndex = 24;
            this.checkBoxAutoAfterLoad.Text = "After loading an image, Execute \"Auto\"";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // textBoxDiectory
            // 
            this.textBoxDiectory.Location = new System.Drawing.Point(65, 44);
            this.textBoxDiectory.Name = "textBoxDiectory";
            this.textBoxDiectory.Size = new System.Drawing.Size(216, 23);
            this.textBoxDiectory.TabIndex = 27;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 15);
            this.label1.TabIndex = 28;
            this.label1.Text = "Directory";
            // 
            // buttonSetDirectory
            // 
            this.buttonSetDirectory.AutoSize = true;
            this.buttonSetDirectory.Location = new System.Drawing.Point(287, 42);
            this.buttonSetDirectory.Name = "buttonSetDirectory";
            this.buttonSetDirectory.Size = new System.Drawing.Size(36, 25);
            this.buttonSetDirectory.TabIndex = 29;
            this.buttonSetDirectory.Text = "Set";
            this.buttonSetDirectory.UseVisualStyleBackColor = true;
            this.buttonSetDirectory.Click += new System.EventHandler(this.buttonSetDirectory_Click);
            // 
            // buttonWatch
            // 
            this.buttonWatch.AutoSize = true;
            this.buttonWatch.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonWatch.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonWatch.ForeColor = System.Drawing.Color.White;
            this.buttonWatch.Location = new System.Drawing.Point(4, 3);
            this.buttonWatch.Name = "buttonWatch";
            this.buttonWatch.Size = new System.Drawing.Size(196, 32);
            this.buttonWatch.TabIndex = 29;
            this.buttonWatch.Text = "Watch and load a new image";
            this.buttonWatch.UseVisualStyleBackColor = false;
            this.buttonWatch.Click += new System.EventHandler(this.buttonStartWatching_Click);
            // 
            // button1
            // 
            this.button1.AutoSize = true;
            this.button1.BackColor = System.Drawing.Color.Maroon;
            this.button1.Font = new System.Drawing.Font("Yu Gothic UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(4, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 32);
            this.button1.TabIndex = 29;
            this.button1.Text = "Stop watching";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonStopWatching_Click);
            // 
            // FormAutoProcedure
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(328, 180);
            this.Controls.Add(this.buttonWatch);
            this.Controls.Add(this.buttonSetDirectory);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDiectory);
            this.Controls.Add(this.checkedListBoxAuto);
            this.Controls.Add(this.buttonAuto);
            this.Controls.Add(this.checkBoxAutoAfterLoad);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormAutoProcedure";
            this.Text = "Auto Procedure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoProcedure_FormClosing);
            this.Load += new System.EventHandler(this.FormAutoProcedure_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox checkedListBoxAuto;
        private System.Windows.Forms.Button buttonAuto;
        public System.Windows.Forms.CheckBox checkBoxAutoAfterLoad;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.TextBox textBoxDiectory;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button buttonSetDirectory;
        private System.Windows.Forms.Button buttonWatch;
        private System.Windows.Forms.Button button1;
    }
}