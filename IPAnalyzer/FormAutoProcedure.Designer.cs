namespace IPAnalyzer;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoProcedure));
            this.checkedListBoxAuto = new System.Windows.Forms.CheckedListBox();
            this.checkBoxAutoAfterLoad = new System.Windows.Forms.CheckBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.textBoxDiectory = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSetDirectory = new System.Windows.Forms.Button();
            this.checkBoxAutoLoad = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxMacro = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // checkedListBoxAuto
            // 
            this.checkedListBoxAuto.CheckOnClick = true;
            resources.ApplyResources(this.checkedListBoxAuto, "checkedListBoxAuto");
            this.checkedListBoxAuto.Items.AddRange(new object[] {
            resources.GetString("checkedListBoxAuto.Items"),
            resources.GetString("checkedListBoxAuto.Items1"),
            resources.GetString("checkedListBoxAuto.Items2"),
            resources.GetString("checkedListBoxAuto.Items3"),
            resources.GetString("checkedListBoxAuto.Items4")});
            this.checkedListBoxAuto.MultiColumn = true;
            this.checkedListBoxAuto.Name = "checkedListBoxAuto";
            this.checkedListBoxAuto.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxAuto_ItemCheck);
            // 
            // checkBoxAutoAfterLoad
            // 
            resources.ApplyResources(this.checkBoxAutoAfterLoad, "checkBoxAutoAfterLoad");
            this.checkBoxAutoAfterLoad.Name = "checkBoxAutoAfterLoad";
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            // 
            // textBoxDiectory
            // 
            resources.ApplyResources(this.textBoxDiectory, "textBoxDiectory");
            this.textBoxDiectory.Name = "textBoxDiectory";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // buttonSetDirectory
            // 
            resources.ApplyResources(this.buttonSetDirectory, "buttonSetDirectory");
            this.buttonSetDirectory.Name = "buttonSetDirectory";
            this.buttonSetDirectory.UseVisualStyleBackColor = true;
            this.buttonSetDirectory.Click += new System.EventHandler(this.buttonSetDirectory_Click);
            // 
            // checkBoxAutoLoad
            // 
            resources.ApplyResources(this.checkBoxAutoLoad, "checkBoxAutoLoad");
            this.checkBoxAutoLoad.Name = "checkBoxAutoLoad";
            this.checkBoxAutoLoad.UseVisualStyleBackColor = true;
            this.checkBoxAutoLoad.CheckedChanged += new System.EventHandler(this.checkBoxAutoLoad_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxDiectory);
            this.groupBox1.Controls.Add(this.buttonSetDirectory);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.comboBoxMacro);
            this.groupBox2.Controls.Add(this.checkedListBoxAuto);
            resources.ApplyResources(this.groupBox2, "groupBox2");
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.TabStop = false;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // comboBoxMacro
            // 
            this.comboBoxMacro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resources.ApplyResources(this.comboBoxMacro, "comboBoxMacro");
            this.comboBoxMacro.FormattingEnabled = true;
            this.comboBoxMacro.Name = "comboBoxMacro";
            // 
            // FormAutoProcedure
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.checkBoxAutoLoad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxAutoAfterLoad);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormAutoProcedure";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAutoProcedure_FormClosing);
            this.Load += new System.EventHandler(this.FormAutoProcedure_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.CheckedListBox checkedListBoxAuto;
    public System.Windows.Forms.CheckBox checkBoxAutoAfterLoad;
    private System.ComponentModel.BackgroundWorker backgroundWorker;
    private System.Windows.Forms.TextBox textBoxDiectory;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
    private System.Windows.Forms.Button buttonSetDirectory;
    private System.Windows.Forms.CheckBox checkBoxAutoLoad;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.ComboBox comboBoxMacro;
    private System.Windows.Forms.Label label2;
}