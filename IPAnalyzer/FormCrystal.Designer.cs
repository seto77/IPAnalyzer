namespace IPAnalyzer
{
    partial class FormCrystal
    {

        /// <summary>
        /// 使用されているリソースに後処理を実行します。
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.crystalControl = new Crystallography.Controls.CrystalControl();
            this.SuspendLayout();
            // 
            // crystalControl
            // 
            this.crystalControl.A = 0D;
            this.crystalControl.AllowDrop = true;
            this.crystalControl.Alpha = 0D;
            this.crystalControl.AutoSize = true;
            this.crystalControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.crystalControl.B = 0D;
            this.crystalControl.Beta = 0D;
            this.crystalControl.C = 0D;
            this.crystalControl.DefaultTabNumber = 0;
            this.crystalControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.crystalControl.Gamma = 0D;
            this.crystalControl.Location = new System.Drawing.Point(0, 0);
            this.crystalControl.Margin = new System.Windows.Forms.Padding(0);
            this.crystalControl.Name = "crystalControl";
            this.crystalControl.ScatteringFactorVisible = false;
            this.crystalControl.Size = new System.Drawing.Size(752, 417);
            this.crystalControl.SkipEvent = false;
            this.crystalControl.SymmetryInformationVisible = false;
            this.crystalControl.SymmetrySeriesNumber = 0;
            this.crystalControl.TabIndex = 0;
            this.crystalControl.VisibleAtomTab = true;
            this.crystalControl.VisibleBasicInfoTab = true;
            this.crystalControl.VisibleBondsPolyhedraTab = false;
            this.crystalControl.VisibleBoundTab = false;
            this.crystalControl.VisibleElasticityTab = true;
            this.crystalControl.VisibleEOSTab = false;
            this.crystalControl.VisibleLatticePlaneTab = false;
            this.crystalControl.VisiblePolycrystallineTab = false;
            this.crystalControl.VisibleReferenceTab = true;
            this.crystalControl.VisibleStressStrainTab = false;
            // 
            // FormCrystal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(752, 417);
            this.Controls.Add(this.crystalControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormCrystal";
            this.Text = "Crystal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCrystal_FormClosing);
            this.Load += new System.EventHandler(this.FormCrystal_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.Windows.Forms.ToolTip toolTip;
        private Crystallography.Controls.CrystalControl crystalControl;
        private System.ComponentModel.IContainer components;
    }
}