using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Crystallography;
using Crystallography.Controls;

namespace IPAnalyzer
{
    /// <summary>
    /// FormCrystal の概要の説明です。
    /// </summary>
    public partial class FormCrystal : System.Windows.Forms.Form
    {
        public FormFindParameter formFindParameter;

        public int atomSeriesNum = 0;
        public int numSG;
        public Crystal crystal;

   

        public FormCrystal()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }





       

        public void CrystalChanged(Crystal crystal)
        {
            crystalControl.Crystal = crystal;
        }

        private void FormCrystal_Load(object sender, EventArgs e)
        {
            crystalControl.CrystalChanged += new CrystalControl.MyEventHandler(crystalForm_CrystalChanged);
        }

        private void FormCrystal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //formFindParameter.checkBoxShowCrystalParameter.Checked = false;
            this.Visible = false;
        }

        void crystalForm_CrystalChanged(Crystal crystal)
        {
            this.crystal = crystal;
            formFindParameter.CrystalChanged(crystal);
        }



    }
}
