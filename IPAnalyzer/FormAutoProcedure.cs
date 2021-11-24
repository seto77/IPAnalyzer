using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace IPAnalyzer
{
    public partial class FormAutoProcedure : Form
    {

        public FormMain formMain;

        private string targetFolder="";

        public FormAutoProcedure()
        {
            InitializeComponent();
        }
        private void FormAutoProcedure_Load(object sender, EventArgs e)
        {

            checkBoxAutoAfterLoad.Checked = true;

            checkedListBoxAuto.SetItemChecked(0, false);
            checkedListBoxAuto.SetItemChecked(1, false);
            checkedListBoxAuto.SetItemChecked(2, true);
            checkedListBoxAuto.SetItemChecked(3, false);
            checkedListBoxAuto.SetItemChecked(4, true);

        }

        private void FormAutoProcedure_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonAutoProcedure.Checked = false;
        }
        public void buttonAuto_Click(object sender, EventArgs e)
        {
            if (formMain.FormFindParameter.Visible) return;

            //自動輝度調整
            if (checkedListBoxAuto.GetItemChecked(0))
                formMain.buttonAutoLevel_Click(new object(), new EventArgs());
            Application.DoEvents();

            if (checkedListBoxAuto.GetItemChecked(1))
                formMain.toolStripSplitButtonBackground_ButtonClick(new object(), new EventArgs());
            Application.DoEvents();

            //FindCenter
            if (checkedListBoxAuto.GetItemChecked(2))
                for (int i = 0; i < 2; i++)
                    formMain.toolStripSplitButtonFindCenter_ButtonClick(new object(), new EventArgs());
            Application.DoEvents();

            //MaskSpots
            if (checkedListBoxAuto.GetItemChecked(3))
                formMain.toolStripSplitButtonFindSpots_ButtonClick(new object(), new EventArgs());
            Application.DoEvents();

            //PixelIntensity
            if (checkedListBoxAuto.GetItemChecked(4))
                formMain.toolStripSplitButtonGetProfile_ButtonClick(new object(), new EventArgs());
            Application.DoEvents();

        }


        public List<string> FileList=new List<string>();
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                try
                {
                    var temp = new List<string>(Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories));
                    if (temp.Count != FileList.Count)
                    {
                        foreach (var f in temp.Where(e => !FileList.Contains(e)))
                            if (f.EndsWith("img") || f.EndsWith("tif") || f.EndsWith("stl") || f.EndsWith("ccd") || f.EndsWith("ipf"))
                            {

                                formMain.ReadImage(f);
                                break;
                            }
                        FileList = temp;
                    }
                }

                catch { System.Threading.Thread.Sleep(1000); }
                System.Threading.Thread.Sleep(200);
            }
            while (!backgroundWorker.CancellationPending);
        }

        private void buttonStartWatching_Click(object sender, EventArgs e)
        {
            targetFolder = textBoxDiectory.Text;
            if (Directory.Exists(targetFolder))
            {
                FileList.Clear();
                FileList.AddRange(Directory.GetFiles(targetFolder, "*", SearchOption.AllDirectories));
                backgroundWorker.RunWorkerAsync();
                buttonWatch.Visible = false;
            }
        }

        private void buttonStopWatching_Click(object sender, EventArgs e)
        {
            backgroundWorker.CancelAsync();
            buttonWatch.Visible = true;

        }

        private void buttonSetDirectory_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                textBoxDiectory.Text = folderBrowserDialog1.SelectedPath;
        }
    }
}