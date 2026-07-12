using Crystallography;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormSaveImage : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {
        public FormMain FormMain;

        public FormSaveImage()
        {
            InitializeComponent();
            HelpPage = "3-tools"; //260604Cl 追加
        }

        public double ImageResolution
        {
            get { return (double)(numericUpDownResolution.Value/1000); }
        }

        bool SkipEvent = false;
        private void numericUpDownWidth_ValueChanged(object sender, EventArgs e)
        {
            if (SkipEvent) return;
            SkipEvent = true;
            if (checkBoxKeepAspect.Checked)
            {
                if (((NumericUpDown)sender).Name == "numericUpDownWidth")
                    numericUpDownHeight.Value = numericUpDownWidth.Value;
                if (((NumericUpDown)sender).Name == "numericUpDownHeight")
                    numericUpDownWidth.Value = numericUpDownHeight.Value;
            }
            SkipEvent = false;

            FormMain.Draw();
        }


        public Size ImageSize
        {
            get { return new Size((int)numericUpDownWidth.Value, (int)numericUpDownHeight.Value); }
        }
        
        public PointD ImageCenter
        {
            get { return new PointD((double)numericUpDownCenterX.Value, (double)numericUpDownCenterY.Value); }

        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            SaveImageAsIPA(); //260712Cl SaveImageAsIPA("") が同一のダイアログ〜保存処理を持つため重複を解消
            this.Visible = false;
        }

        public void SaveImageAsIPA(string filename="")
        {
            SaveImageAsIPA(filename, ImageResolution, ImageSize, ImageCenter);
        }

        public void SaveImageAsIPA(string filename, double imageResolution, Size imageSize, PointD imageCenter)
        {
            if (filename == "")
            {
                using SaveFileDialog dlg = new() { Filter = "*.ipa|*.ipa" }; //260712Cl using宣言化
                if (dlg.ShowDialog() == DialogResult.OK)
                    filename = dlg.FileName;
                else
                    return;
            }
            else if (!filename.ToLower().EndsWith(".ipa"))
                filename += ".ipa";

            double[] imageArray = Ring.GetCorrectedImageArray(FormMain.IP, imageResolution, imageSize, imageCenter);
            //260712Cl 未使用の ipaImage 生成を削除。IPAImageWriter へは配列生成に使った引数を渡す (プロパティ直読みだと引数と食い違いヘッダ不整合になる)
            ImageIO.IPAImageWriter(filename, imageArray, imageResolution, imageSize, imageCenter, FormMain.IP.FilmDistance, FormMain.FormProperty.waveLengthControl.Property);

            FormMain.Draw();

        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            FormMain.Draw();
        }

        private void FormSaveImage_VisibleChanged(object sender, EventArgs e)
        {
            FormMain.Draw();
        }

    }
}
