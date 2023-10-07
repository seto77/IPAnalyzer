#region using
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using Crystallography;
using System.Text;
using System.Collections.Generic;
#endregion

namespace IPAnalyzer;

public partial class FormAutoProcedure : Form
{
    #region フィールド、プロパティ
    public FormMain formMain;

    private string targetFolder = "";

    public string[] Macros
    {
        set
        {
            comboBoxMacro.Items.Clear();
            if (value != null)
                foreach (var item in value)
                    comboBoxMacro.Items.Add(item);
        }
    }
    #endregion

    #region コンストラクト、ロード、クローズ
    public FormAutoProcedure()
    {
        InitializeComponent();
    }
    private void FormAutoProcedure_Load(object sender, EventArgs e)
    {
        checkedListBoxAuto.SetItemChecked(0, false);
        checkedListBoxAuto.SetItemChecked(1, false);
        checkedListBoxAuto.SetItemChecked(2, false);
        checkedListBoxAuto.SetItemChecked(3, true);
        checkedListBoxAuto.SetItemChecked(4, false);
    }

    private void FormAutoProcedure_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.toolStripButtonAutoProcedure.Checked = false;
    }
    #endregion

    #region その他イベント
    private void checkedListBoxAuto_ItemCheck(object sender, ItemCheckEventArgs e)
    {
        if (e.Index == 4)
            comboBoxMacro.Enabled = e.NewValue == CheckState.Checked;
    }
    #endregion

    #region 一連の操作を実行する. FormMainから呼ばれる
    public void ExecuteAutoProcedure()
    {
        if (formMain.FormFindParameter.Visible) return;

        //自動輝度調整
        if (checkedListBoxAuto.GetItemChecked(0))
            formMain.buttonAutoLevel_Click(new object(), new EventArgs());
        Application.DoEvents();

        //FindCenter
        if (checkedListBoxAuto.GetItemChecked(1))
            for (int i = 0; i < 2; i++)
                formMain.toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
        Application.DoEvents();

        //MaskSpots
        if (checkedListBoxAuto.GetItemChecked(2))
            formMain.toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());
        Application.DoEvents();

        //GetProfile
        if (checkedListBoxAuto.GetItemChecked(3))
            formMain.toolStripSplitButtonGetProfileButtonClick(new object(), new EventArgs());

        //Execute Macro
        if (checkedListBoxAuto.GetItemChecked(4))
        {
            if (comboBoxMacro.Text != "")
                formMain.FormMacro.RunMacroName(comboBoxMacro.Text);
        }
        Application.DoEvents();
    }
    #endregion

    #region ファイル更新監視
    string[] FileList = Array.Empty<string>();
    private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
    {
        FileList = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
        while (!backgroundWorker.CancellationPending)
        {
            try
            {
                var temp = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);
                if (temp.Length != FileList.Length)
                {
                    foreach (var f in temp.Where(e => !FileList.Contains(e)))
                        if (ImageIO.IsReadable(Path.GetExtension(f)))
                        {
                            if (!checkBoxPatternMatching.Checked)
                            {
                                formMain.ReadImage(f);
                                //  break;
                            }
                            else//パターンマッチングの場合
                            {
                                var filename = Path.GetFileNameWithoutExtension(f);
                                var numStr = new List<char>();
                                for (int i = filename.Length - 1; i >= 0; i--)
                                {
                                    if (filename[i] >= '0' && filename[i] <= '9')
                                        numStr.Add(filename[i]);
                                    else
                                        break;
                                }
                                numStr.Reverse();
                                if (int.TryParse(new string(numStr.ToArray()), out int num))
                                {
                                    if ((radioButtonEqual.Checked && num % numericBoxDivisor.ValueInteger == numericBoxRemainder.ValueInteger) ||
                                        (radioButtonNotEqual.Checked && num % numericBoxDivisor.ValueInteger != numericBoxRemainder.ValueInteger))
                                    {
                                        formMain.ReadImage(f);
                                        //  break;
                                    }
                                }
                            }


                        }
                    FileList = temp;
                }
            }

            catch { System.Threading.Thread.Sleep(1000); }
            System.Threading.Thread.Sleep(200);
        }
    }

    private void buttonSetDirectory_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            textBoxDiectory.Text = folderBrowserDialog1.SelectedPath;
    }

    private void checkBoxAutoLoad_CheckedChanged(object sender, EventArgs e)
    {
        if (checkBoxAutoLoad.Checked)
        {
            targetFolder = textBoxDiectory.Text;
            if (targetFolder.Length == 0 || !Directory.Exists(targetFolder))
            {
                MessageBox.Show("Set the appropriate directories to be monitored.");
                checkBoxAutoLoad.Checked = false;
                return;
            }
            FileList = Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories);

            while (backgroundWorker.IsBusy)
            {
                backgroundWorker.CancelAsync();
                System.Threading.Thread.Sleep(200);
            }
            backgroundWorker.RunWorkerAsync();
        }
        else
            backgroundWorker.CancelAsync();
    }
    #endregion

}