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
                textBoxReadMe.Text = Crystallography.Localization.Loc(en: "Hidden comment\r\n", ja: "隠しコメント\r\n", de: "Versteckter Kommentar\r\n", fr: "Commentaire caché\r\n", es: "Comentario oculto\r\n", pt: "Comentário oculto\r\n", it: "Commento nascosto\r\n", ru: "Скрытый комментарий\r\n", zhHans: "隐藏注释\r\n", zhHant: "隱藏註解\r\n", ko: "숨겨진 코멘트\r\n"); // 260627Cl fr..ko
                textBoxReadMe.Text += Crystallography.Localization.Loc(
                    en: "This software is free, but donations are gladly accepted.\r\nIf you found this software useful, please treat me to a meal at a conference or some other occasion.",
                    ja: "このソフトはフリーですが、喜んで寄付も申し受けております。\r\nもしこのソフトを使って便利だなぁと感じた方、学会か何かの折にご飯をおごってください。",
                    de: "Diese Software ist kostenlos, über Spenden freue ich mich aber sehr.\r\nWenn Sie diese Software nützlich finden, laden Sie mich bei Gelegenheit (z. B. auf einer Tagung) gern zu einer Mahlzeit ein.",
                    fr: "Ce logiciel est gratuit, mais les dons sont les bienvenus.\r\nSi ce logiciel vous a été utile, offrez-moi un repas lors d'une conférence ou d'une autre occasion.",
                    es: "Este software es gratuito, pero las donaciones son bienvenidas.\r\nSi este software le resultó útil, invíteme a una comida en un congreso u otra ocasión.",
                    pt: "Este software é gratuito, mas doações são bem-vindas.\r\nSe este software lhe foi útil, ofereça-me uma refeição em uma conferência ou outra ocasião.",
                    it: "Questo software è gratuito, ma le donazioni sono ben accette.\r\nSe questo software ti è stato utile, offrimi un pasto a un convegno o in un'altra occasione.",
                    ru: "Эта программа бесплатна, но пожертвования приветствуются.\r\nЕсли программа оказалась полезной, угостите меня обедом на конференции или в другой раз.",
                    zhHans: "本软件免费，但欢迎捐赠。\r\n如果您觉得本软件有用，请在学术会议等场合请我吃顿饭。",
                    zhHant: "本軟體免費，但歡迎捐贈。\r\n如果您覺得本軟體有用，請在學術會議等場合請我吃頓飯。",
                    ko: "이 소프트웨어는 무료이지만 기부는 언제든 환영합니다.\r\n이 소프트웨어가 유용했다면 학회 등에서 식사를 대접해 주세요."); // 260627Cl fr..ko

                n = 0;

            }
        }


    }
}
