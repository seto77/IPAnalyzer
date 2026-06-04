using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormFindParameterGeometry : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {
        public FormFindParameterGeometry()
        {
            InitializeComponent();
            HelpPage = "appendix/a1-geometry"; //260604Cl 追加
        }
    }
}