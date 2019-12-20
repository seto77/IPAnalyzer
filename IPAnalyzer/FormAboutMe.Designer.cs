namespace IPAnalyzer
{
    partial class FormAboutMe
    {
        /// <summary>
        /// 必要なデザイナ変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }


        #region Windows フォーム デザイナで生成されたコード
        /// <summary>
        /// デザイナ サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディタで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAboutMe));
            this.linkLabelMail = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelVersion = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxReadMe = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.linkLabelHomePage = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // linkLabelMail
            // 
            this.linkLabelMail.AutoSize = true;
            this.linkLabelMail.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelMail.Location = new System.Drawing.Point(354, 32);
            this.linkLabelMail.Name = "linkLabelMail";
            this.linkLabelMail.Size = new System.Drawing.Size(143, 15);
            this.linkLabelMail.TabIndex = 25;
            this.linkLabelMail.TabStop = true;
            this.linkLabelMail.Text = "seto@crystal.kobe-u.ac.jp";
            this.linkLabelMail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelMail_LinkClicked);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(439, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(135, 15);
            this.label1.TabIndex = 22;
            this.label1.Text = "Copyright (C) 2005-2015";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(328, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "All Right Reserved.";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // labelVersion
            // 
            this.labelVersion.AutoSize = true;
            this.labelVersion.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVersion.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelVersion.Location = new System.Drawing.Point(0, 0);
            this.labelVersion.Name = "labelVersion";
            this.labelVersion.Size = new System.Drawing.Size(62, 15);
            this.labelVersion.TabIndex = 24;
            this.labelVersion.Text = "IPAnalyzer";
            this.labelVersion.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(148, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(142, 15);
            this.label5.TabIndex = 17;
            this.label5.Text = " Yusuke Seto (Kobe Univ.)";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(326, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "Mail:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(0, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(232, 17);
            this.label9.TabIndex = 18;
            this.label9.Text = "ご意見,ご要望はメールにてご連絡ください。";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBoxReadMe
            // 
            this.textBoxReadMe.Font = new System.Drawing.Font("メイリオ", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxReadMe.Location = new System.Drawing.Point(0, 70);
            this.textBoxReadMe.Multiline = true;
            this.textBoxReadMe.Name = "textBoxReadMe";
            this.textBoxReadMe.ReadOnly = true;
            this.textBoxReadMe.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxReadMe.Size = new System.Drawing.Size(592, 170);
            this.textBoxReadMe.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(4, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(136, 15);
            this.label7.TabIndex = 23;
            this.label7.Text = "(Imaging Plate Analyzer)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(4, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "HomePage:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // linkLabelHomePage
            // 
            this.linkLabelHomePage.AutoSize = true;
            this.linkLabelHomePage.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabelHomePage.Location = new System.Drawing.Point(64, 32);
            this.linkLabelHomePage.Name = "linkLabelHomePage";
            this.linkLabelHomePage.Size = new System.Drawing.Size(230, 15);
            this.linkLabelHomePage.TabIndex = 25;
            this.linkLabelHomePage.TabStop = true;
            this.linkLabelHomePage.Text = "http://pmsl.planet.sci.kobe-u.ac.jp/~seto/";
            this.linkLabelHomePage.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelHomePage_LinkClicked);
            // 
            // FormAboutMe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(592, 240);
            this.Controls.Add(this.textBoxReadMe);
            this.Controls.Add(this.linkLabelHomePage);
            this.Controls.Add(this.linkLabelMail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelVersion);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAboutMe";
            this.Text = "About Me";
            this.Load += new System.EventHandler(this.FormAboutMe_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormAboutMe_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.LinkLabel linkLabelMail;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxReadMe;
        private System.Windows.Forms.Label label7;

        private System.Windows.Forms.Label labelVersion;

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel linkLabelHomePage;
    }
}