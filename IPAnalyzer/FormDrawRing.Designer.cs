namespace IPAnalyzer
{
    partial class FormDrawRing
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDrawRing));
            this.textBoxR = new System.Windows.Forms.TextBox();
            this.textBoxTwoTheta = new System.Windows.Forms.TextBox();
            this.textBoxD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.buttonOk = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBoxR
            // 
            this.textBoxR.Location = new System.Drawing.Point(20, 3);
            this.textBoxR.Name = "textBoxR";
            this.textBoxR.Size = new System.Drawing.Size(84, 22);
            this.textBoxR.TabIndex = 0;
            this.textBoxR.Text = "0";
            this.textBoxR.TextChanged += new System.EventHandler(this.textBoxR_TextChanged);
            this.textBoxR.Click += new System.EventHandler(this.textBoxR_Click);
            this.textBoxR.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxR_KeyDown);
            // 
            // textBoxTwoTheta
            // 
            this.textBoxTwoTheta.Location = new System.Drawing.Point(20, 29);
            this.textBoxTwoTheta.Name = "textBoxTwoTheta";
            this.textBoxTwoTheta.ReadOnly = true;
            this.textBoxTwoTheta.Size = new System.Drawing.Size(84, 22);
            this.textBoxTwoTheta.TabIndex = 0;
            this.textBoxTwoTheta.Text = "0";
            this.textBoxTwoTheta.TextChanged += new System.EventHandler(this.textBoxTowTheta_TextChanged);
            this.textBoxTwoTheta.Click += new System.EventHandler(this.textBoxTowTheta_Click);
            this.textBoxTwoTheta.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTwoTheta_KeyDown);
            // 
            // textBoxD
            // 
            this.textBoxD.Location = new System.Drawing.Point(20, 55);
            this.textBoxD.Name = "textBoxD";
            this.textBoxD.ReadOnly = true;
            this.textBoxD.Size = new System.Drawing.Size(84, 22);
            this.textBoxD.TabIndex = 0;
            this.textBoxD.Text = "0";
            this.textBoxD.TextChanged += new System.EventHandler(this.textBoxD_TextChanged);
            this.textBoxD.Click += new System.EventHandler(this.textBoxD_Click);
            this.textBoxD.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxD_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(0, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "2θ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(13, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "d";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 15);
            this.label3.TabIndex = 1;
            this.label3.Text = "R";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(104, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "mm";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(104, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(11, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "°";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(104, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(14, 15);
            this.label6.TabIndex = 1;
            this.label6.Text = "Å";
            // 
            // buttonOk
            // 
            this.buttonOk.Location = new System.Drawing.Point(68, 80);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(60, 24);
            this.buttonOk.TabIndex = 2;
            this.buttonOk.Text = "OK";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // FormDrawRing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(134, 106);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxD);
            this.Controls.Add(this.textBoxTwoTheta);
            this.Controls.Add(this.textBoxR);
            this.Font = new System.Drawing.Font("Arial Unicode MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormDrawRing";
            this.Text = "DrawRing";
            this.Load += new System.EventHandler(this.FormDrawRing_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormDrawRing_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxR;
        private System.Windows.Forms.TextBox textBoxTwoTheta;
        private System.Windows.Forms.TextBox textBoxD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button buttonOk;
    }
}