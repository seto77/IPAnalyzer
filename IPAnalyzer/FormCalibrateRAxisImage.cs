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
    public partial class FormCalibrateRAxisImage : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {


        public FormCalibrateRAxisImage()
        {
            InitializeComponent();
            HelpPage = "3-tools"; //260604Cl 追加
        }


        uint[] rawTable = new uint[65536];
        private void buttonReadFile1_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "*.img,*.stl|*.img;*.stl" }; //260712Cl using宣言+ターゲット型new+初期化子
            if (dlg.ShowDialog() == DialogResult.OK)
                ImageIO.Raxis4(dlg.FileName, rawTable);
        }
    }
}
