using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormFindParameterOption1 : Form
    {
        public int SetMaximumNumber
        { set { numericBox1.Maximum = value; } }

        public FormFindParameterOption1()
        {
            InitializeComponent();
        }

        public FormMain FormMain;

        private void numericBox1_Load(object sender, EventArgs e)
        {

        }

        private void numericBox1_ValueChanged(object sender, EventArgs e)
        {
            FormMain.FormSequentialImage.SelectedIndex = numericBox1.ValueInteger;
        }

        private void FormFindParameterOption1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
                numericBox1.Maximum = FormMain.FormSequentialImage.MaximumNumber - 1;
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
