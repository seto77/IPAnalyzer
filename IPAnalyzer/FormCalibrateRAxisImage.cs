using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Crystallography;

namespace IPAnalyzer
{
    public partial class FormCalibrateRAxisImage : Form
    {


        public FormCalibrateRAxisImage()
        {
            InitializeComponent();
        }


        uint[] rawTable = new uint[65536];
        private void buttonReadFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "*.img,*.stl|*.img;*.stl";
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ImageIO.Raxis4(dlg.FileName, rawTable);
            }
        }
    }
}
