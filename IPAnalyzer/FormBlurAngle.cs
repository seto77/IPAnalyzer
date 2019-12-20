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
    public partial class FormBlurAngle : Form
    {
        public double BlurAngle
        {
            set { numericUpDown1.Value = (decimal)(value / Math.PI * 180); }
            get { return (double)numericUpDown1.Value / 180 * Math.PI; }
        }

        public FormBlurAngle()
        {
            InitializeComponent();
        }
    }
}
