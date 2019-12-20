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
    public partial class FormSaveImage : Form
    {
        public FormMain FormMain;

        public FormSaveImage()
        {
            InitializeComponent();
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
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "*.ipa|*.ipa";
            if (dlg.ShowDialog() == DialogResult.OK)
                SaveImageAsIPA(dlg.FileName, ImageResolution, ImageSize, ImageCenter);
          
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
                SaveFileDialog dlg = new SaveFileDialog();
                dlg.Filter = "*.ipa|*.ipa";
                if (dlg.ShowDialog() == DialogResult.OK)
                    filename = dlg.FileName;
                else
                    return;
            }
            else if (!filename.ToLower().EndsWith(".ipa"))
                filename += ".ipa";

            double[] imageArray = Ring.GetCorrectedImageArray(FormMain.IP, imageResolution, imageSize, imageCenter);
            ImageIO.IPAImage ipaImage = new ImageIO.IPAImage();

            ImageIO.IPAImageWriter(filename, imageArray, ImageResolution, ImageSize, ImageCenter, FormMain.IP.FilmDistance, FormMain.FormProperty.waveLengthControl.Property);

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
