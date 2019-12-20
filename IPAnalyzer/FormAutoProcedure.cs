using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IPAnalyzer
{
    public partial class FormAutoProcedure : Form
    {

        public FormMain formMain;
        public System.IO.FileSystemWatcher watcher;


        public FormAutoProcedure()
        {
            InitializeComponent();
        }
        private void FormAutoProcedure_Load(object sender, EventArgs e)
        {
            watcher = new System.IO.FileSystemWatcher();
            watcher.IncludeSubdirectories = true;
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Created);

            checkBoxIsWatchAndLoad.Checked = true;
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

           // watcher.EnableRaisingEvents = false;

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

            //watcher.EnableRaisingEvents = true;
        }

        public void checkBoxIsWatchAndLoad_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxIsWatchAndLoad.Checked)
            {
                if (System.IO.Directory.Exists(formMain.FilePath))
                {
                    //watcher.Path = formMain.FilePath;
                    //watcher.EnableRaisingEvents = true;
                    FileList.Clear();
                    FileList.AddRange(Directory.GetFiles(formMain.FilePath));
                    backgroundWorker.RunWorkerAsync();
                }
            }
            else
            {
                //watcher.EnableRaisingEvents = false;
                backgroundWorker.CancelAsync();
            }
        }

        void watcher_Created(object sender, System.IO.FileSystemEventArgs e)
        {
            watcher.EnableRaisingEvents = false;
            do
            {
                try
                {
                    System.IO.FileStream fs = System.IO.File.Open(e.FullPath, System.IO.FileMode.Open);
                    fs.Close();
                    break;
                }
                catch { System.Threading.Thread.Sleep(100); }
            }
            while (true);

            formMain.ReadImage(e.FullPath);

            watcher.EnableRaisingEvents = true;
        }

        private void FormAutoProcedure_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
            {
                //watcher.EnableRaisingEvents = false;
                backgroundWorker.CancelAsync();
            }
            else
                checkBoxIsWatchAndLoad_CheckedChanged(new object(), new EventArgs());
        }

        public List<string> FileList=new List<string>();
        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            do
            {
                try
                {
                    List<string> temp = new List<string>( Directory.GetFiles(formMain.FilePath));
                    if (temp.Count != FileList.Count)
                    {
                      for(int i= 0 ; i<temp.Count ; i++)
                          if (FileList.Contains(temp[i]) == false && (temp[i].EndsWith("img") || temp[i].EndsWith("stl") || temp[i].EndsWith("ccd") || temp[i].EndsWith("ipf")))
                          {
                              FileList = temp;
                              formMain.ReadImage(temp[i]);
                              break;
                          }
                    }
                }
            
                catch { System.Threading.Thread.Sleep(1000); }
                System.Threading.Thread.Sleep(200);
            }
            while (!backgroundWorker.CancellationPending);


        }






    }
}