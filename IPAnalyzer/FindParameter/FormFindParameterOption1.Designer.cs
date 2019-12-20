namespace IPAnalyzer
{
    partial class FormFindParameterOption1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.numericBox1 = new Crystallography.Controls.NumericBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numericBox1
            // 
            this.numericBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.numericBox1.BackColor = System.Drawing.SystemColors.Control;
            this.numericBox1.DecimalPlaces = -2;
            this.numericBox1.Font = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBox1.FooterFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBox1.FooterText = "";
            this.numericBox1.HeaderFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBox1.HeaderText = "Select Image No.";
            this.numericBox1.Location = new System.Drawing.Point(10, 11);
            this.numericBox1.Margin = new System.Windows.Forms.Padding(0);
            this.numericBox1.Maximum = 10D;
            this.numericBox1.MaximumSize = new System.Drawing.Size(1000, 25);
            this.numericBox1.Minimum = 0D;
            this.numericBox1.MinimumSize = new System.Drawing.Size(1, 25);
            this.numericBox1.Multiline = false;
            this.numericBox1.Name = "numericBox1";
            this.numericBox1.Padding = new System.Windows.Forms.Padding(0, 0, 1, 0);
            this.numericBox1.RadianValue = 0D;
            this.numericBox1.ReadOnly = false;
            this.numericBox1.RestrictLimitValue = true;
            this.numericBox1.ShowFraction = false;
            this.numericBox1.ShowPositiveSign = false;
            this.numericBox1.ShowUpDown = true;
            this.numericBox1.Size = new System.Drawing.Size(182, 25);
            this.numericBox1.SkipEventDuringInput = false;
            this.numericBox1.SmartIncrement = false;
            this.numericBox1.TabIndex = 0;
            this.numericBox1.TextBoxBackColor = System.Drawing.SystemColors.Window;
            this.numericBox1.TextBoxForeColor = System.Drawing.SystemColors.WindowText;
            this.numericBox1.TextFont = new System.Drawing.Font("Segoe UI Symbol", 9.75F);
            this.numericBox1.ThonsandsSeparator = true;
            this.numericBox1.ToolTip = "";
            this.numericBox1.UpDown_Increment = 1D;
            this.numericBox1.Value = 0D;
            this.numericBox1.WordWrap = true;
            this.numericBox1.ValueChanged += new Crystallography.Controls.NumericBox.MyEventHandler(this.numericBox1_ValueChanged);
            this.numericBox1.Load += new System.EventHandler(this.numericBox1_Load);
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(105, 40);
            this.buttonOK.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(87, 29);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // FormFindParameterOption1
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(196, 77);
            this.ControlBox = false;
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.numericBox1);
            this.Font = new System.Drawing.Font("Segoe UI Symbol", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormFindParameterOption1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Option";
            this.VisibleChanged += new System.EventHandler(this.FormFindParameterOption1_VisibleChanged);
            this.ResumeLayout(false);

        }

        #endregion

        private Crystallography.Controls.NumericBox numericBox1;
        private System.Windows.Forms.Button buttonOK;
    }
}