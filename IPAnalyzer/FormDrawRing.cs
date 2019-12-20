using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormDrawRing : Form
    {
        public FormMain formMain;
        public double R, D, TwoTheta;

        public FormDrawRing()
        {
            InitializeComponent();
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
            double pixelSize = formMain.IP.PixSizeX;
            double FilmDistance = formMain.IP.FilmDistance;
            double WaveLength = formMain.IP.WaveLength;
            if (textBoxR.ReadOnly == false)//ピクセル距離を入力したときは
            {
                R = Convert.ToDouble(textBoxR.Text);
                TwoTheta = Math.Atan(R / FilmDistance);
                D = WaveLength / 2 / Math.Sin(TwoTheta / 2);

                textBoxTwoTheta.Text = (TwoTheta * 180 / Math.PI).ToString();
                textBoxD.Text = (D * 10).ToString();
            }
            else if (textBoxTwoTheta.ReadOnly == false)//2シーたを打ち込まれたとき
            {
                TwoTheta = Convert.ToDouble(textBoxTwoTheta.Text) / 180.0 * Math.PI;

                D = WaveLength / 2.0 / Math.Sin(TwoTheta / 2.0);
                R = Math.Tan(TwoTheta) * FilmDistance;

                textBoxR.Text = R.ToString();
                textBoxD.Text = (D * 10).ToString();
            }
            else//D値を打ち込まれたとき
            {
                D = Convert.ToDouble(textBoxD.Text) / 10.0;
                TwoTheta = 2 * Math.Asin(WaveLength / 2 / D);
                R = Math.Tan(TwoTheta) * FilmDistance;

                textBoxR.Text = R.ToString();
                textBoxTwoTheta.Text = (TwoTheta * 180 / Math.PI).ToString();
            }
            formMain.Draw();
        }

        public void SetR(double r)//外部からr値をセットされたとき
        {
            double pixelSize = formMain.IP.PixSizeX;
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
                buttonOk_Click(new object(), new EventArgs());
        }

        private void textBoxTwoTheta_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                buttonOk_Click(new object(), new EventArgs());
        }

        private void textBoxD_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Return)
                buttonOk_Click(new object(), new EventArgs());
        }





    }
}