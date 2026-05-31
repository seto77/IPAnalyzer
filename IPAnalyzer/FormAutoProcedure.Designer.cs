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
            components = new System.ComponentModel.Container(); // 260531Cl 追加
            toolTip = new System.Windows.Forms.ToolTip(components); // 260531Cl 追加
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAutoProcedure));
        checkedListBoxAuto = new System.Windows.Forms.CheckedListBox();
        checkBoxAutoAfterLoad = new System.Windows.Forms.CheckBox();
        backgroundWorker = new System.ComponentModel.BackgroundWorker();
        textBoxDiectory = new System.Windows.Forms.TextBox();
        label1 = new System.Windows.Forms.Label();
        folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
        buttonSetDirectory = new System.Windows.Forms.Button();
        checkBoxAutoLoad = new System.Windows.Forms.CheckBox();
        groupBox1 = new System.Windows.Forms.GroupBox();
        checkBoxKeywords = new System.Windows.Forms.CheckBox();
        checkBoxNumberMatching = new System.Windows.Forms.CheckBox();
        flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
        numericBoxDivisor = new Crystallography.Controls.NumericBox();
        radioButtonEqual = new System.Windows.Forms.RadioButton();
        radioButtonNotEqual = new System.Windows.Forms.RadioButton();
        numericBoxRemainder = new Crystallography.Controls.NumericBox();
        textBoxKeyword = new System.Windows.Forms.TextBox();
        groupBox2 = new System.Windows.Forms.GroupBox();
        label2 = new System.Windows.Forms.Label();
        comboBoxMacro = new System.Windows.Forms.ComboBox();
        groupBox1.SuspendLayout();
        flowLayoutPanel1.SuspendLayout();
        groupBox2.SuspendLayout();
        SuspendLayout();
        // 
        // checkedListBoxAuto
        // 
        resources.ApplyResources(checkedListBoxAuto, "checkedListBoxAuto");
            toolTip.SetToolTip(checkedListBoxAuto, resources.GetString("checkedListBoxAuto.ToolTip")); // 260531Cl 追加
        checkedListBoxAuto.CheckOnClick = true;
        checkedListBoxAuto.Items.AddRange(new object[] { resources.GetString("checkedListBoxAuto.Items"), resources.GetString("checkedListBoxAuto.Items1"), resources.GetString("checkedListBoxAuto.Items2"), resources.GetString("checkedListBoxAuto.Items3"), resources.GetString("checkedListBoxAuto.Items4") });
        checkedListBoxAuto.MultiColumn = true;
        checkedListBoxAuto.Name = "checkedListBoxAuto";
        checkedListBoxAuto.ItemCheck += checkedListBoxAuto_ItemCheck;
        // 
        // checkBoxAutoAfterLoad
        // 
        resources.ApplyResources(checkBoxAutoAfterLoad, "checkBoxAutoAfterLoad");
            toolTip.SetToolTip(checkBoxAutoAfterLoad, resources.GetString("checkBoxAutoAfterLoad.ToolTip")); // 260531Cl 追加
        checkBoxAutoAfterLoad.Name = "checkBoxAutoAfterLoad";
        // 
        // backgroundWorker
        // 
        backgroundWorker.WorkerSupportsCancellation = true;
        backgroundWorker.DoWork += backgroundWorker_DoWork;
        backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
        // 
        // textBoxDiectory
        // 
        resources.ApplyResources(textBoxDiectory, "textBoxDiectory");
            toolTip.SetToolTip(textBoxDiectory, resources.GetString("textBoxDiectory.ToolTip")); // 260531Cl 追加
        textBoxDiectory.Name = "textBoxDiectory";
        // 
        // label1
        // 
        resources.ApplyResources(label1, "label1");
            toolTip.SetToolTip(label1, resources.GetString("label1.ToolTip")); // 260531Cl 追加
        label1.Name = "label1";
        // 
        // folderBrowserDialog1
        // 
        resources.ApplyResources(folderBrowserDialog1, "folderBrowserDialog1");
        // 
        // buttonSetDirectory
        // 
        resources.ApplyResources(buttonSetDirectory, "buttonSetDirectory");
            toolTip.SetToolTip(buttonSetDirectory, resources.GetString("buttonSetDirectory.ToolTip")); // 260531Cl 追加
        buttonSetDirectory.Name = "buttonSetDirectory";
        buttonSetDirectory.UseVisualStyleBackColor = true;
        buttonSetDirectory.Click += buttonSetDirectory_Click;
        // 
        // checkBoxAutoLoad
        // 
        resources.ApplyResources(checkBoxAutoLoad, "checkBoxAutoLoad");
            toolTip.SetToolTip(checkBoxAutoLoad, resources.GetString("checkBoxAutoLoad.ToolTip")); // 260531Cl 追加
        checkBoxAutoLoad.Name = "checkBoxAutoLoad";
        checkBoxAutoLoad.UseVisualStyleBackColor = true;
        checkBoxAutoLoad.CheckedChanged += checkBoxAutoLoad_CheckedChanged;
        // 
        // groupBox1
        // 
        resources.ApplyResources(groupBox1, "groupBox1");
        groupBox1.Controls.Add(checkBoxKeywords);
        groupBox1.Controls.Add(checkBoxNumberMatching);
        groupBox1.Controls.Add(flowLayoutPanel1);
        groupBox1.Controls.Add(label1);
        groupBox1.Controls.Add(textBoxKeyword);
        groupBox1.Controls.Add(textBoxDiectory);
        groupBox1.Controls.Add(buttonSetDirectory);
        groupBox1.Name = "groupBox1";
        groupBox1.TabStop = false;
        // 
        // checkBoxKeywords
        // 
        resources.ApplyResources(checkBoxKeywords, "checkBoxKeywords");
            toolTip.SetToolTip(checkBoxKeywords, resources.GetString("checkBoxKeywords.ToolTip")); // 260531Cl 追加
        checkBoxKeywords.Name = "checkBoxKeywords";
        // 
        // checkBoxNumberMatching
        // 
        resources.ApplyResources(checkBoxNumberMatching, "checkBoxNumberMatching");
            toolTip.SetToolTip(checkBoxNumberMatching, resources.GetString("checkBoxNumberMatching.ToolTip")); // 260531Cl 追加
        checkBoxNumberMatching.Name = "checkBoxNumberMatching";
        // 
        // flowLayoutPanel1
        // 
        resources.ApplyResources(flowLayoutPanel1, "flowLayoutPanel1");
        flowLayoutPanel1.Controls.Add(numericBoxDivisor);
        flowLayoutPanel1.Controls.Add(radioButtonEqual);
        flowLayoutPanel1.Controls.Add(radioButtonNotEqual);
        flowLayoutPanel1.Controls.Add(numericBoxRemainder);
        flowLayoutPanel1.Name = "flowLayoutPanel1";
        // 
        // numericBoxDivisor
        // 
        resources.ApplyResources(numericBoxDivisor, "numericBoxDivisor");
        numericBoxDivisor.BackColor = System.Drawing.Color.Transparent;
        numericBoxDivisor.Name = "numericBoxDivisor";
        numericBoxDivisor.RadianValue = 0.052359877559829883D;
        numericBoxDivisor.Value = 3D;
        numericBoxDivisor.ValueFontSize = 8F;
        // 
        // radioButtonEqual
        // 
        resources.ApplyResources(radioButtonEqual, "radioButtonEqual");
            toolTip.SetToolTip(radioButtonEqual, resources.GetString("radioButtonEqual.ToolTip")); // 260531Cl 追加
        radioButtonEqual.Name = "radioButtonEqual";
        radioButtonEqual.TabStop = true;
        radioButtonEqual.UseVisualStyleBackColor = true;
        // 
        // radioButtonNotEqual
        // 
        resources.ApplyResources(radioButtonNotEqual, "radioButtonNotEqual");
            toolTip.SetToolTip(radioButtonNotEqual, resources.GetString("radioButtonNotEqual.ToolTip")); // 260531Cl 追加
        radioButtonNotEqual.Name = "radioButtonNotEqual";
        radioButtonNotEqual.TabStop = true;
        radioButtonNotEqual.UseVisualStyleBackColor = true;
        // 
        // numericBoxRemainder
        // 
        resources.ApplyResources(numericBoxRemainder, "numericBoxRemainder");
        numericBoxRemainder.BackColor = System.Drawing.Color.Transparent;
        numericBoxRemainder.Name = "numericBoxRemainder";
        numericBoxRemainder.RadianValue = 0.034906585039886591D;
        numericBoxRemainder.Value = 2D;
        numericBoxRemainder.ValueFontSize = 8F;
        // 
        // textBoxKeyword
        // 
        resources.ApplyResources(textBoxKeyword, "textBoxKeyword");
            toolTip.SetToolTip(textBoxKeyword, resources.GetString("textBoxKeyword.ToolTip")); // 260531Cl 追加
        textBoxKeyword.Name = "textBoxKeyword";
        // 
        // groupBox2
        // 
        resources.ApplyResources(groupBox2, "groupBox2");
        groupBox2.Controls.Add(label2);
        groupBox2.Controls.Add(comboBoxMacro);
        groupBox2.Controls.Add(checkedListBoxAuto);
        groupBox2.Name = "groupBox2";
        groupBox2.TabStop = false;
        // 
        // label2
        // 
        resources.ApplyResources(label2, "label2");
            toolTip.SetToolTip(label2, resources.GetString("label2.ToolTip")); // 260531Cl 追加
        label2.Name = "label2";
        // 
        // comboBoxMacro
        // 
        resources.ApplyResources(comboBoxMacro, "comboBoxMacro");
            toolTip.SetToolTip(comboBoxMacro, resources.GetString("comboBoxMacro.ToolTip")); // 260531Cl 追加
        comboBoxMacro.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        comboBoxMacro.FormattingEnabled = true;
        comboBoxMacro.Name = "comboBoxMacro";
        // 
        // FormAutoProcedure
        // 
        resources.ApplyResources(this, "$this");
        AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
        Controls.Add(checkBoxAutoLoad);
        Controls.Add(groupBox1);
        Controls.Add(checkBoxAutoAfterLoad);
        Controls.Add(groupBox2);
        FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
        Name = "FormAutoProcedure";
        FormClosing += FormAutoProcedure_FormClosing;
        Load += FormAutoProcedure_Load;
        groupBox1.ResumeLayout(false);
        groupBox1.PerformLayout();
        flowLayoutPanel1.ResumeLayout(false);
        flowLayoutPanel1.PerformLayout();
        groupBox2.ResumeLayout(false);
        groupBox2.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
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
    private Crystallography.Controls.NumericBox numericBoxDivisor;
    private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    private Crystallography.Controls.NumericBox numericBoxRemainder;
    public System.Windows.Forms.CheckBox checkBoxNumberMatching;
    private System.Windows.Forms.RadioButton radioButtonEqual;
    private System.Windows.Forms.RadioButton radioButtonNotEqual;
    public System.Windows.Forms.CheckBox checkBoxKeywords;
    private System.Windows.Forms.TextBox textBoxKeyword;
    private System.Windows.Forms.ToolTip toolTip; // 260531Cl 追加
}