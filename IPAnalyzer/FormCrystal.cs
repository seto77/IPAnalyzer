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
    public partial class FormCrystal : FormBase //260604Cl FormBase 継承に変更
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
            HelpPage = "3-tools"; //260604Cl 追加

            //260605Cl 追加: CrystalControl 内の対称性情報/散乱因子サブウィンドウの F1 ヘルプ先を付録ページに設定。
            crystalControl.FormSymmetryInformation.HelpPage = "appendix/a4-symmetry-information";
            crystalControl.FormScatteringFactor.HelpPage = "appendix/a5-scattering-factor";

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
            crystalControl.CrystalChanged += new EventHandler(crystalForm_CrystalChanged);
        }

        private void FormCrystal_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            //formFindParameter.checkBoxShowCrystalParameter.Checked = false;
            this.Visible = false;
        }

        void crystalForm_CrystalChanged(object sender, EventArgs e)
        {
            this.crystal = crystalControl.Crystal;
            formFindParameter.CrystalChanged(crystal);
        }



    }
}
