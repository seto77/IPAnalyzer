using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormDrawRing : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {
        public FormMain formMain;
        public double R, D, TwoTheta;

        public FormDrawRing()
        {
            InitializeComponent();
            HelpPage = "3-tools"; //260604Cl 追加
        }

        private void FormDrawRing_Load(object sender, EventArgs e)
        {

        }

        bool SkipChangeEvent = false;
        private void textBoxR_TextChanged(object sender, EventArgs e)
        {
            if (SkipChangeEvent) return;
        }

        private void textBoxTowTheta_TextChanged(object sender, EventArgs e)
        {
            if (SkipChangeEvent) return;
        }

        private void textBoxD_TextChanged(object sender, EventArgs e)
        {
            if (SkipChangeEvent) return;
        }

        private void textBoxR_Click(object sender, EventArgs e)
        {
            textBoxR.ReadOnly = false;
            textBoxD.ReadOnly = true;
            textBoxTwoTheta.ReadOnly = true;
        }

        private void textBoxTowTheta_Click(object sender, EventArgs e)
        {
            textBoxR.ReadOnly = true;
            textBoxD.ReadOnly = true;
            textBoxTwoTheta.ReadOnly = false;
        }

        private void textBoxD_Click(object sender, EventArgs e)
        {
            textBoxR.ReadOnly = true;
            textBoxD.ReadOnly = false;
            textBoxTwoTheta.ReadOnly = true;
        }



        private void FormDrawRing_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonRing.Checked = false;
        }

        public void buttonOk_Click(object sender, EventArgs e)
        {
            //double pixelSize = formMain.IP.PixSizeX; //260712Cl 未使用のため削除 (R は mm 入力で FilmDistance と同単位のため乗算不要)
            double FilmDistance = formMain.IP.FilmDistance;
            double WaveLength = formMain.IP.WaveLength;
            if (textBoxR.ReadOnly == false)//ピクセル距離を入力したときは
            {
                if (!double.TryParse(textBoxR.Text, out var rValue)) return; //260712Cl 不正入力(空・"1."等)の FormatException クラッシュを防止
                R = rValue;
                TwoTheta = Math.Atan(R / FilmDistance);
                D = WaveLength / 2 / Math.Sin(TwoTheta / 2);

                textBoxTwoTheta.Text = (TwoTheta * 180 / Math.PI).ToString();
                textBoxD.Text = (D * 10).ToString();
            }
            else if (textBoxTwoTheta.ReadOnly == false)//2シーたを打ち込まれたとき
            {
                if (!double.TryParse(textBoxTwoTheta.Text, out var twoThetaDeg)) return; //260712Cl
                TwoTheta = twoThetaDeg / 180.0 * Math.PI;

                D = WaveLength / 2.0 / Math.Sin(TwoTheta / 2.0);
                R = Math.Tan(TwoTheta) * FilmDistance;

                textBoxR.Text = R.ToString();
                textBoxD.Text = (D * 10).ToString();
            }
            else//D値を打ち込まれたとき
            {
                if (!double.TryParse(textBoxD.Text, out var dValue)) return; //260712Cl
                D = dValue / 10.0;
                TwoTheta = 2 * Math.Asin(WaveLength / 2 / D);
                R = Math.Tan(TwoTheta) * FilmDistance;

                textBoxR.Text = R.ToString();
                textBoxTwoTheta.Text = (TwoTheta * 180 / Math.PI).ToString();
            }
            formMain.Draw();
        }

        public void SetR(double r)//外部からr値をセットされたとき
        {
            //double pixelSize = formMain.IP.PixSizeX; //260712Cl 未使用のため削除
            double FilmDistance = formMain.IP.FilmDistance;
            double WaveLength = formMain.IP.WaveLength;
            R = r;
            TwoTheta = Math.Atan(R / FilmDistance);
            D = WaveLength / 2 / Math.Sin(TwoTheta / 2);
            textBoxR.Text = R.ToString();
            textBoxTwoTheta.Text = (TwoTheta * 180 / Math.PI).ToString();
            textBoxD.Text = (D * 10).ToString();
            formMain.Draw();
        }

        private void textBoxR_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                buttonOk_Click(sender, e); //260712Cl ダミー割り当てを回避し sender/e を転送
        }

        private void textBoxTwoTheta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                buttonOk_Click(sender, e); //260712Cl ダミー割り当てを回避し sender/e を転送
        }

        private void textBoxD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                buttonOk_Click(sender, e); //260712Cl ダミー割り当てを回避し sender/e を転送
        }





    }
}