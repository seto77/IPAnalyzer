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
    public partial class FormAboutMe : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {
        public FormAboutMe()
        {
            InitializeComponent();
            HelpPage = "0-overview"; //260604Cl 追加
        }




        private void buttonOK_Click(object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void linkLabelMail_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("mailto:" + linkLabelMail.Text);
            }
            catch { }
        }
        private void linkLabelHomePage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(linkLabelHomePage.Text);
            }
            catch { }
        }

        private void FormAboutMe_Load(object sender, System.EventArgs e)
        {
            labelVersion.Text = "IPAnalyzer  " + Version.VersionAndDate;

            string str = "";

            str += Version.Introduction + "\r\n\r\n";//はじめに
            str += Version.CopyRight + "\r\n\r\n";//著作権
            str += Version.Condition + "\r\n\r\n";//実行条件
            str += Version.Exemption + "\r\n\r\n";//免責
            str += Version.Adress + "\r\n\r\n";//連絡先
            str += Version.Acknowledge + "\r\n\r\n";//謝辞
            str += Version.History;//履歴

            textBoxReadMe.Text += str;
        }

        public int n = 0;
        private void FormAboutMe_MouseDown(object sender, MouseEventArgs e)
        {
            if (n == 0 && e.Button == MouseButtons.Left)
                n++;
            else if (n == 1 && e.Button == MouseButtons.Left)
                n++;
            else if (n == 2 && e.Button == MouseButtons.Right)
                n++;
            else if (n == 3)
            {
                // 260626Cl Loc化 (英語環境で日本語直書きが出ていたのを修正)
                textBoxReadMe.Text = Crystallography.Localization.Loc(en: "Hidden comment\r\n", ja: "隠しコメント\r\n");
                textBoxReadMe.Text += Crystallography.Localization.Loc(
                    en: "This software is free, but donations are gladly accepted.\r\nIf you found this software useful, please treat me to a meal at a conference or some other occasion.",
                    ja: "このソフトはフリーですが、喜んで寄付も申し受けております。\r\nもしこのソフトを使って便利だなぁと感じた方、学会か何かの折にご飯をおごってください。");

                n = 0;

            }
        }


    }
}
