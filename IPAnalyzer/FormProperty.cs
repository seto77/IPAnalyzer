using Crystallography;
using IronPython.Modules;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormProperty : Form
    {
        #region プロパティ、フィールド
        public FormMain formMain;

        public double WaveLength { set => waveLengthControl.WaveLength = value; get => waveLengthControl.WaveLength; }
        public string WaveLengthText { set => waveLengthControl.WaveLengthText = value; get => waveLengthControl.WaveLengthText; }
        public double CameraLength1 { set => numericBoxCameraLength1.Value = value; get => numericBoxCameraLength1.Value; }
        public string CameraLength1Text
        {
            set
            {
                try { numericBoxCameraLength1.Value = Convert.ToDouble(value); } catch { }
            }
            get => numericBoxCameraLength1.Value.ToString();
        }
        public double CameraLength2 { set => numericBoxCameraLength2.Value = value; get => numericBoxCameraLength2.Value; }

        public PointD DirectSpotPosition
        {
            set
            {
                if (SkipEvent)
                {
                    numericBoxDirectSpotPositionX.Value = value.X;
                    numericBoxDirectSpotPositionY.Value = value.Y;
                }
                else
                {
                    SkipEvent = true;
                    numericBoxDirectSpotPositionX.Value = value.X;
                    numericBoxDirectSpotPositionY.Value = value.Y;
                    SkipEvent = false;
                    DetectorParameters_Changed(numericBoxDirectSpotPositionX, new EventArgs());
                }
            }
            get => new(numericBoxDirectSpotPositionX.Value, numericBoxDirectSpotPositionY.Value);
        }

        public PointD FootPosition
        {
            set
            {
                if (SkipEvent)
                {
                    numericBoxFootPositionX.Value = value.X;
                    numericBoxFootPositionY.Value = value.Y;
                }
                else
                {
                    SkipEvent = true;
                    numericBoxFootPositionX.Value = value.X;
                    numericBoxFootPositionY.Value = value.Y;
                    SkipEvent = false;
                    DetectorParameters_Changed(numericBoxFootPositionX, new EventArgs());
                }
            }
            get => new(numericBoxFootPositionX.Value, numericBoxFootPositionY.Value);
        }

        public double DetectorPixelSizeX { set => numericBoxPixelSizeX.Value = value; get => numericBoxPixelSizeX.Value; }
        public double DetectorPixelSizeY { set => numericBoxPixelSizeY.Value = value; get => numericBoxPixelSizeY.Value; }
        public double DetectorPixelKsi { set => numericBoxPixelKsi.Value = value; get => numericBoxPixelKsi.Value; }
        public double DetectorPixelKsiRadians { set => numericBoxPixelKsi.RadianValue = value; get => numericBoxPixelKsi.RadianValue; }

        public double DetectorTiltTau { set => numericBoxTiltTau.Value = value; get => numericBoxTiltTau.Value; }
        public double DetectorTiltTauRadian { set => numericBoxTiltTau.RadianValue = value; get => numericBoxTiltTau.RadianValue; }

        public double DetectorTiltPhi { set => numericBoxTiltPhi.Value = value; get => numericBoxTiltPhi.Value; }
        public double DetectorTiltPhiRadian { set => numericBoxTiltPhi.RadianValue = value; get => numericBoxTiltPhi.RadianValue; }

        public Matrix3D DetectorRotation { get; set; } = Matrix3D.IdentityMatrix;
        public Matrix3D DetectorRotationInv { get; set; } = Matrix3D.IdentityMatrix;

        public enum DetectorCoordinatesEnum { DirectSpot, Foot}
        public DetectorCoordinatesEnum DetectorCoordinates
        {
            set
            {
                if (value == DetectorCoordinatesEnum.DirectSpot)
                {
                    radioButtonDirectSpotMode.Checked = true;
                    radioButtonFootMode.Checked = false;
                }
                else
                {
                    radioButtonDirectSpotMode.Checked = false;
                    radioButtonFootMode.Checked = true;
                }
            }
            get
            {
                if (radioButtonDirectSpotMode.Checked)
                    return DetectorCoordinatesEnum.DirectSpot;
                else
                    return DetectorCoordinatesEnum.Foot;
            }
        }

        public double StartAngle { set; get; } = 1;
        public double EndAngle { set; get; } = 30;
        public double StepAngle { set; get; } = 0.01;
        public double StartLength { set; get; } = 1;
        public double EndLength { set; get; } = 30;
        public double StepLength { set; get; } = 0.01;
        public double StartDspacing { set; get; } = 0.5;
        public double EndDspacing { set; get; } = 5;
        public double StepDspacing { set; get; } = 0.005;
        public double SectorRadiusD { set; get; } = 1.5;
        public double SectorRadiusDRange { set; get; } = 0.01;
        public double SectorRadiusTheta { set; get; } = 20;
        public double SectorRadiusThetaRange { set; get; } = 0.1;
        public double SectorAngle { set; get; } = 0.05;

        #endregion

        public ImageTypeParameter[] ImageTypeParameters = new ImageTypeParameter[Enum.GetValues( typeof( Ring.ImageTypeEnum)).Length];


        public FormProperty()
        {
            PerformAutoScale();

            InitializeComponent();

            PerformAutoScale();


            for (int i = 0; i < ImageTypeParameters.Length; i++)
                ImageTypeParameters[i] = new ImageTypeParameter();
           
            //LoadInitialFile();
            try
            {
            //    checkBoxExtensionCCD.Checked = AssociatedExtension.Check(".ccd", "IPAnalyzer");
            //    checkBoxExtensionIMG.Checked = AssociatedExtension.Check(".img", "IPAnalyzer");
            //    checkBoxExtensionSTL.Checked = AssociatedExtension.Check(".stl", "IPAnalyzer");
            //    checkBoxExtensionIPF.Checked = AssociatedExtension.Check(".ipf", "IPAnalyzer");
            }
            catch { }
        }



        //TabControl1のDrawItemイベントハンドラ
        private void tabControl1_DrawItem(object sender, DrawItemEventArgs e)
        {
            //対象のTabControlを取得
            TabControl tab = (TabControl)sender;
            TabPage page = tab.TabPages[e.Index];
            //タブページのテキストを取得
            string txt = page.Text;

            //StringFormatを作成
            StringFormat sf = new StringFormat();
            //水平垂直方向の中央に、行が完全に表示されるようにする
            sf.LineAlignment = StringAlignment.Center;
            sf.Alignment = StringAlignment.Center;
            sf.FormatFlags |= StringFormatFlags.LineLimit;

            //背景の描画
            Brush backBrush;
             if (tabControl.SelectedIndex == e.Index)
            backBrush = new SolidBrush(page.BackColor);
             else
                 backBrush = new SolidBrush(Color.DarkGray);

            e.Graphics.FillRectangle(backBrush, e.Bounds);
            backBrush.Dispose();

            Brush selectedBrush = new SolidBrush(Color.SteelBlue);

            //Textの描画
            Brush foreBrush = new SolidBrush(page.ForeColor);
       

            if (tabControl.SelectedIndex == e.Index)
                e.Graphics.DrawString(txt, new Font(page.Font.FontFamily, page.Font.Size, FontStyle.Bold), selectedBrush, e.Bounds, sf);
            else
                e.Graphics.DrawString(txt, page.Font, foreBrush, e.Bounds, sf);
         
            foreBrush.Dispose();
        }


        private void FormProperty_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
           // formMain.toolStripMenuItemProperty.Checked = false;
            this.Visible = false;
        }
        private void comboBoxRectangleDirection_SelectedIndexChanged(object sender, EventArgs e)
        {
            formMain.Skip = true;
            switch ((string)comboBoxRectangleDirection.SelectedItem)
            {
                case "Full":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = false;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    break;
                case "Top":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = false;
                    numericUpDownRectangleAngle.Value = 270;
                    break;
                case "Bottom":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = false;
                    numericUpDownRectangleAngle.Value = 90;
                    break;
                case "Right":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = false;
                    numericUpDownRectangleAngle.Value = 0;
                    break;
                case "Left":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = false;
                    numericUpDownRectangleAngle.Value = 180;
                    break;
                case "Vertical":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = true;
                    numericUpDownRectangleAngle.Value = 90;
                    break;
                case "Horizontal":
                    numericUpDownRectangleAngle.Enabled = false;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = false;
                    checkBoxRectangleIsBothSide.Checked = true;
                    numericUpDownRectangleAngle.Value = 0;
                    break;
                case "Free":
                    numericUpDownRectangleAngle.Enabled = true;
                    numericUpDownRectangleBand.Enabled = true;
                    checkBoxRectangleIsBothSide.Enabled = true;
                    numericUpDownRectangleAngle.Value = 0;
                    break;
            }
            formMain.Skip = false;
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        bool IsSkipNumetricUpDownInIntensity = false;
        public void radioButtonAngleMode_CheckedChanged(object sender, EventArgs e)
        {
            IsSkipNumetricUpDownInIntensity = true;
            if (radioButtonConcentricAngle.Checked)
            {
                numericBoxConcentricStart.FooterText = numericBoxConcentricEnd.FooterText = numericBoxConcentricStep.FooterText = "°";
                numericBoxConcentricStart.Maximum = 360;
                numericBoxConcentricStart.DecimalPlaces = 3;
                //numericBoxConcentricStart.Increment = (decimal)1;
                numericBoxConcentricStart.Value = StartAngle;
                numericBoxConcentricEnd.Maximum = 180;
                numericBoxConcentricEnd.DecimalPlaces = 3;
               // numericBoxConcentricEnd.Increment = (decimal)1;
                numericBoxConcentricEnd.Value = EndAngle;
                numericBoxConcentricStep.Maximum = 180;
                numericBoxConcentricStep.Minimum = 0.001;
                numericBoxConcentricStep.DecimalPlaces = 3;
                //numericBoxConcentricStep.Increment = (decimal)0.001;
                numericBoxConcentricStep.Value = StepAngle;
            }
            else if(radioButtonConcentricLength.Checked)
            {
                numericBoxConcentricStart.FooterText = numericBoxConcentricEnd.FooterText = numericBoxConcentricStep.FooterText = "mm";
                numericBoxConcentricStart.Maximum = 10000;
                numericBoxConcentricStart.DecimalPlaces = 2;
                //numericBoxConcentricStart.Increment = (decimal)1;
                numericBoxConcentricStart.Value = StartLength;
                numericBoxConcentricEnd.Maximum = 10000;
                numericBoxConcentricEnd.DecimalPlaces = 2;
                //numericBoxConcentricEnd.Increment = (decimal)1;
                numericBoxConcentricEnd.Value = EndLength;
                numericBoxConcentricStep.Maximum = 10000;
                numericBoxConcentricStep.Minimum = 0.001;
                numericBoxConcentricStep.DecimalPlaces = 2;
                //numericBoxConcentricStep.Increment = (decimal)0.01;
                numericBoxConcentricStep.Value = StepLength;

            }
            else if (radioButtonConcentricDspacing.Checked)
            {
                numericBoxConcentricStart.FooterText = numericBoxConcentricEnd.FooterText = numericBoxConcentricStep.FooterText = "Å";

                numericBoxConcentricStart.Maximum = 10000;
                numericBoxConcentricStart.DecimalPlaces = 4;
                //numericBoxConcentricStart.Increment = (decimal)0.1;
                numericBoxConcentricStart.Value = StartDspacing;
                numericBoxConcentricEnd.Maximum = 10000;
                numericBoxConcentricEnd.DecimalPlaces = 4;
                //numericBoxConcentricEnd.Increment = (decimal)0.1;
                numericBoxConcentricEnd.Value = EndDspacing;
                numericBoxConcentricStep.Maximum = 10000;
                numericBoxConcentricStep.Minimum = 0.0001;
                numericBoxConcentricStep.DecimalPlaces = 4;
                //numericBoxConcentricStep.Increment = (decimal)0.0001;
                numericBoxConcentricStep.Value = StepDspacing;
            }
            IsSkipNumetricUpDownInIntensity = false;
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        public void checkBoxThreshold_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxThresholdMax.Checked)
            {
                numericUpDownThresholdOfIntensityMax.Enabled = true;
                numericUpDownThresholdOfIntensityMax_ValueChanged(new object(), new EventArgs());
            }
            else
            {
                numericUpDownThresholdOfIntensityMax.Enabled = false;
                Ring.IsThresholdOver.Clear();
                Ring.IsThresholdOver.AddRange(new bool[Ring.Intensity.Count]);
                formMain.Draw();
            }

            if (checkBoxThresholdMin.Checked)
            {
                numericUpDownThresholdOfIntensityMin.Enabled = true;
                numericUpDownThresholdOfIntensityMin_ValueChanged(new object(), new EventArgs());
            }
            else
            {
                numericUpDownThresholdOfIntensityMin.Enabled = false;
                Ring.IsThresholdUnder.Clear();
                Ring.IsThresholdUnder.AddRange(new bool[Ring.Intensity.Count]);
                formMain.Draw();
            }
        }



        private void checkBoxMaskEdge_CheckedChanged_1(object sender, EventArgs e)
        {
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void numericUpDownThresholdOfIntensityMin_ValueChanged(object sender, EventArgs e)
        {
            uint n = (uint)numericUpDownThresholdOfIntensityMin.Value + 1;
            for (int i = 0; i < Ring.IsValid.Count; i++)
                    Ring.IsThresholdUnder[i] = n > Ring.Intensity[i];

            formMain.Draw();
        }

        private void numericUpDownThresholdOfIntensityMax_ValueChanged(object sender, EventArgs e)
        {
            uint n = Math.Min(uint.MaxValue, (uint)numericUpDownThresholdOfIntensityMax.Value - 1);

            for (int i = 0; i < Ring.IsValid.Count; i++)
                    Ring.IsThresholdOver[i] = n <Ring.Intensity[i];

            formMain.Draw();
        }

        private void numericBoxIntegralProperty_ValueChanged(object sender, EventArgs e)
        {
            if (IsSkipNumetricUpDownInIntensity) return;

            if (radioButtonConcentric.Checked)
            {//Concentricモードのとき
                //角度モードのとき
                if (radioButtonConcentricAngle.Checked)
                {
                    StartAngle = numericBoxConcentricStart.Value;
                    EndAngle = numericBoxConcentricEnd.Value;
                    StepAngle = numericBoxConcentricStep.Value;
                }
                else if(radioButtonConcentricLength.Checked)
                {
                    StartLength = numericBoxConcentricStart.Value;
                    EndLength = numericBoxConcentricEnd.Value;
                    StepLength = numericBoxConcentricStep.Value;
                }
                else if (radioButtonConcentricDspacing.Checked)
                {
                    StartDspacing = numericBoxConcentricStart.Value;
                    EndDspacing = numericBoxConcentricEnd.Value;
                    StepDspacing = numericBoxConcentricStep.Value;
                }
            }
            else if (radioButtonRadial.Checked)
            {//Radialモードのとき
                    if (radioButtonRadialAngle.Checked)
                    {
                        SectorRadiusTheta = numericBoxRadialRadius.Value;
                        SectorRadiusThetaRange = numericBoxRadialRange.Value;
                    }
                    else
                    {
                        SectorRadiusD = numericBoxRadialRadius.Value;
                        SectorRadiusDRange = numericBoxRadialRange.Value;
                    }
                    SectorAngle = numericBoxRadialStep.Value;
            }
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void radioButtonRectangle_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxRectangle.Enabled = radioButtonRectangle.Checked;
            groupBoxSector.Enabled = !radioButtonRectangle.Checked;
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void textBoxPixelSizeX_TextChanged(object sender, EventArgs e)
        {
            formMain.Draw();
        }

        private void numetricUpDownManualSpotSize_ValueChanged(object sender, EventArgs e)
        {
            textBoxManualSpotSize.Text = Math.Pow(2, (double)numericUpDownManualSpotSize.Value).ToString();
        }

        private void textBoxManualSpotSize_TextChanged(object sender, EventArgs e)
        {
            try
            {
                formMain.SpotsSize = Convert.ToSingle(textBoxManualSpotSize.Text);
                formMain.toolStripComboBoxManualSpotSize.Text = textBoxManualSpotSize.Text;
            }
            catch
            {
                formMain.SpotsSize = 64;
            }
        }

        #region 読み込まれたイメージごとのPropertyの設定、保存
        /// <summary>
        /// 読み込まれたイメージタイプごとに中心位置、波長、フィルム距離などをPropertyに設定する. 
        /// renewEnergyは、入射X線波長を更新するかどうかを決めるフラグ. hdfのようにファイルにエネルギー値が埋め込まれている場合への対応。
        /// </summary>
        /// <param name="s"></param>
        public void SetParameterFromImageType(Ring.ImageTypeEnum imageType, bool renewWavelength=true)
        {
            formMain.Skip = true;

            int i = (int)imageType;
            ImageTypeParameter p = ImageTypeParameters[i];
            formMain.Skip = true;

            radioButtonFlatPanel.Checked = p.CameraMode == IntegralProperty.CameraEnum.FlatPanel;
            radioButtonGandlfi.Checked = p.CameraMode == IntegralProperty.CameraEnum.Gandolfi;

            numericBoxGandlfiRadius.Value = p.GandolfiRadius;

            CameraLength1 = p.CameraLength;
            numericBoxPixelSizeX.Value = p.PixelSizeX;
            numericBoxPixelSizeY.Value = p.PixelSizeY;
            numericBoxPixelKsi.RadianValue = p.PixelKsi;
            numericBoxTiltPhi.RadianValue = p.Phi;
            numericBoxTiltTau.RadianValue = p.Tau;

            waveLengthControl.WaveSource = p.WaveSource;
            waveLengthControl.XrayWaveSourceElementNumber = p.XrayWaveSourceElementNumber;
            waveLengthControl.XrayWaveSourceLine = p.XrayLine;
            if (renewWavelength && waveLengthControl.XrayWaveSourceElementNumber == 0)
            {
                waveLengthControl.Energy = p.ElectronAccVoltage;
                waveLengthControl.WaveLength = p.WaveLength;
            }

            formMain.flipHorizontallyToolStripMenuItem.Checked = ImageTypeParameters[i].FlipHorizontally;
            formMain.flipVerticallyToolStripMenuItem.Checked = ImageTypeParameters[i].FlipVertically;
            formMain.toolStripComboBoxRotate.SelectedIndex = ImageTypeParameters[i].Rotation;
            formMain.FlipRotate_Pollalization_Background();


            formMain.Skip = false;
            DirectSpotPosition = new PointD(p.CenterPosX, p.CenterPosY);
        }

        /// <summary>
        /// 現在の読み込まれているイメージタイプごとに、パラメータを保存する。
        /// </summary>
        public void SaveParameterForEachImageType(Ring.ImageTypeEnum imageType)
        {
            formMain.SetIntegralProperty();

            int i = (int)imageType;

            ImageTypeParameters[i].CameraMode = radioButtonFlatPanel.Checked ? IntegralProperty.CameraEnum.FlatPanel : IntegralProperty.CameraEnum.Gandolfi;

            ImageTypeParameters[i].CenterPosX = formMain.IP.CenterX;
            ImageTypeParameters[i].CenterPosY = formMain.IP.CenterY;
            ImageTypeParameters[i].CameraLength = formMain.IP.FilmDistance;
            ImageTypeParameters[i].PixelSizeX = formMain.IP.PixSizeX;
            ImageTypeParameters[i].PixelSizeY = formMain.IP.PixSizeY;
            ImageTypeParameters[i].PixelKsi = formMain.IP.ksi;
            ImageTypeParameters[i].Phi = formMain.IP.phi;
            ImageTypeParameters[i].Tau = formMain.IP.tau;

            ImageTypeParameters[i].WaveLength = formMain.IP.WaveLength;
            
            ImageTypeParameters[i].XrayLine = waveLengthControl.XrayWaveSourceLine;
            ImageTypeParameters[i].XrayWaveSourceElementNumber = waveLengthControl.XrayWaveSourceElementNumber;
            ImageTypeParameters[i].ElectronAccVoltage = waveLengthControl.Energy;

            ImageTypeParameters[i].WaveSource = waveLengthControl.WaveSource;

            ImageTypeParameters[i].FlipHorizontally = formMain.flipHorizontallyToolStripMenuItem.Checked;
            ImageTypeParameters[i].FlipVertically = formMain.flipVerticallyToolStripMenuItem.Checked;

            ImageTypeParameters[i].Rotation = formMain.toolStripComboBoxRotate.SelectedIndex;

            ImageTypeParameters[i].GandolfiRadius = formMain.IP.GandolfiRadius;

        }
        #endregion
        
        private void numericUpDownRectangleAngle_ValueChanged(object sender, EventArgs e)
        {
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void numericUpDownRectangleBand_ValueChanged(object sender, EventArgs e)
        {
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void checkBoxRectangleIsBothSide_CheckedChanged(object sender, EventArgs e)
        {
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void checkBoxManualMaskMode_CheckedChanged(object sender, EventArgs e)
        {
            formMain.toolStripMenuItemFindSpotsManual.Checked = checkBoxManualMaskMode.Checked;
            formMain.toolStripButtonManualSpotMode.Checked = checkBoxManualMaskMode.Checked;
            groupBoxManualMode.Enabled = checkBoxManualMaskMode.Checked;

            //formMain.scalablePictureBox.MouseScaling = !checkBoxManualMaskMode.Checked;
        }

        　
        public bool SkipEvent = false;

        /// <summary>
        /// 検出器のパラメータが変更されたときのイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void DetectorParameters_Changed(object sender, EventArgs e)
        {
            if (SkipEvent) return;

            #region 幾何学考察
            //検出器の回転行列は以下の行列である.
            // cosφ^2 (1-cosτ) + cosτ , cosφ sinφ (1-cosτ)     ,  sinφ sinτ
            // cosφ sinφ (1-cosτ)     , sinφ^2 (1-cosτ) + cosτ , -cosφ sinτ
            // -sinφ sinτ             , cosφ sinτ              , cosτ
            //ダイレクトスポット (0,0,0), サンプル位置 (0,0, C1)として、
            //検出器平面の方程式は
            // sinφ * sinτ * X - cosφ * sinτ * Y + cosτ * Z = 0 となる。
            //サンプルから検出器平面におろした垂線の足の空間座標をFとすれば
            // F =(C1 * cosτ * sinτ * sinφ, -C1 * cosτ * sinτ * cosφ, -C1 + C1 * cosτ * cosτ)
            //この垂線の足を逆回転して、傾いていないときの座標F'は、
            // F' = (C1 * sinφ * sinτ, -C1 * cosφ * sinτ)
            // これをdirect spotからのピクセル座標F''で考えれば、
            // F'' = C1 *( (sinφ * sinτ + cosφ * sinτ * tanξ) / PixX, - cosφ * sinτ / PixY)
            #endregion
            SkipEvent = true;
            double tau = numericBoxTiltTau.RadianValue, phi = numericBoxTiltPhi.RadianValue, ksi = numericBoxPixelKsi.RadianValue;

            double CosTau = Math.Cos(tau), CosTauSquare = CosTau * CosTau;
            double SinTau = Math.Sin(tau), SinTauSquare = SinTau * SinTau;
            double CosPhi = Math.Cos(phi), CosPhiSquare = CosPhi * CosPhi;
            double SinPhi = Math.Sin(phi), SinPhiSquare = SinPhi * SinPhi;

            DetectorRotation = new Matrix3D(
             CosPhiSquare * (1 - CosTau) + CosTau, CosPhi * SinPhi * (1 - CosTau), -SinPhi * SinTau,
             CosPhi * SinPhi * (1 - CosTau), SinPhiSquare * (1 - CosTau) + CosTau, CosPhi * SinTau,
             SinPhi * SinTau, -CosPhi * SinTau, CosTau
             );

            DetectorRotationInv = DetectorRotation.Inverse();

            var c1 = radioButtonDirectSpotMode.Checked ? numericBoxCameraLength1.Value : numericBoxCameraLength2.Value / CosTau;
            double realX = c1 * SinPhi * SinTau, realY = -c1 * CosPhi * SinTau;
            var fx = (realX - realY * Math.Tan(ksi)) / numericBoxPixelSizeX.Value;
            var fy = realY / numericBoxPixelSizeY.Value;
            if (radioButtonDirectSpotMode.Checked)
            {
                numericBoxCameraLength2.Value = c1 * CosTau;
                FootPosition = DirectSpotPosition + new PointD(fx, fy);
            }
            else
            {
                numericBoxCameraLength1.Value = c1;
                DirectSpotPosition = FootPosition - new PointD(fx, fy);
            }
            SkipEvent = false;

            formMain.IntegralArea_Changed(new object(), new EventArgs());

            //偏光補正がチェックされており、再計算が必要な場合の対処
            if (checkBoxCorrectPolarization.Checked)
                if (sender is Crystallography.Controls.NumericBox b)
                {
                    //再計算が必要なパラメータかどうかを判断
                    if (b.Name.Contains("Center") || b.Name.Contains("CameraLength") || b.Name.Contains("PixelSize")
                           || b.Name.Contains("PixelSize") || b.Name.Contains("TiltCorrection"))
                    {
                        formMain.FlipRotate_Pollalization_Background(false);
                    }
                }
            //formMain.IntegralArea_Changedの中でDrawされているので以下をコメントアウト
            //formMain.Draw();

         
        }


        private void numericUpDownSectorAngle_ValueChanged(object sender, EventArgs e)
        {
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void checkBoxSaveFile_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSaveProfile.Enabled = checkBoxSaveFile.Checked;
        }

        private void radioButtonRadial_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxConcentric.Enabled = radioButtonConcentric.Checked;
            groupBoxRadial.Enabled = !radioButtonConcentric.Checked;
            formMain.IntegralArea_Changed(new object(), new EventArgs());
            formMain.toolStripMenuItemConcenctricIntegration.Checked = radioButtonConcentric.Checked;
            formMain.toolStripMenuItemRadialIntegration.Checked = radioButtonRadial.Checked;
        }

        public void radioButtonRadialAngle_CheckedChanged(object sender, EventArgs e)
        {
            IsSkipNumetricUpDownInIntensity = true;
            numericBoxRadialStep.Value = SectorAngle;
            if (radioButtonRadialAngle.Checked)
            {
                labelDimensionRadial1.Text = labelDimensionRadial2.Text = "°";
                numericBoxRadialRadius.Value = SectorRadiusTheta;
                numericBoxRadialRange.Value = SectorRadiusThetaRange;
            }
            else
            {
                labelDimensionRadial1.Text = labelDimensionRadial2.Text = "Å";
                numericBoxRadialRadius.Value = SectorRadiusD;
                numericBoxRadialRange.Value = SectorRadiusDRange;
            }
            IsSkipNumetricUpDownInIntensity = false;
            formMain.IntegralArea_Changed(new object(), new EventArgs());

        }

        private void checkBoxFixCenter_CheckedChanged(object sender, EventArgs e)
        {
           formMain.toolStripButtonFixCenter.Checked=  checkBoxFixCenter.Checked;
           flowLayoutPanelFindCenterOption.Enabled = !checkBoxFixCenter.Checked;
        }

        private void checkBoxSendProfileToPDIndexer_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxSendPDI.Enabled = checkBoxSendProfileToPDIndexer.Checked;

            formMain.toolStripMenuItemSendProfileToPDIndexer.Checked = checkBoxSendProfileToPDIndexer.Checked;
            formMain.toolStripMenuItemSendUnrolledImage.Enabled = checkBoxSendProfileToPDIndexer.Checked;
        }

        private void checkBoxSendUnrolledImageToPDIndexer_CheckedChanged(object sender, EventArgs e)
        {
            formMain.toolStripMenuItemSendUnrolledImage.Checked = checkBoxSendUnrolledImageToPDIndexer.Checked;
        }

        
        private void radioButtonManualSpot_CheckedChanged(object sender, EventArgs e)
        {
            groupBoxManualSpot.Enabled = radioButtonManualSpot.Checked;
            groupBoxSpline.Enabled = radioButtonManualSpline.Checked;
            numericUpDownSplineWidth.Enabled = radioButtonManualSpline.Checked;
            formMain.toolStripComboBoxManualSpotSize.Visible = radioButtonManualSpot.Checked;
            formMain.manualMaskPoints.Clear();
            formMain.Draw();
        }

        private void numericUpDownSplineWidth_ValueChanged(object sender, EventArgs e)
        {
            formMain.setSpline();
            formMain.pseudoBitmap.FilterTemporary.Clear();
            formMain.pseudoBitmap.FilterTemporary.AddRange(formMain.splineTemp.ToArray());
            formMain.Draw();
        }

        private void buttonMaskAll_Click(object sender, EventArgs e)
        {
            if (Ring.IsSpots.Count == 0) return;
         
            var text = (sender as Button).Text;

            if (text.Contains("All"))
                for (int i = 0; i < Ring.IsSpots.Count; i++)
                    Ring.IsSpots[i] = true;

            else if (text.Contains("Top"))
                MaskTop();

            else if (text.Contains("Bottom"))
                MaskBottom();

            else if (text.Contains("Left"))
                MaskLeft();

            else if (text.Contains("Right"))
                MaskRight();

                formMain.Draw();
        }

        public void MaskTop()
        {
            if (Ring.IsSpots.Count == 0) return;
            for (int i = 0; i < Ring.IsSpots.Count / 2; i++)
                Ring.IsSpots[i] = true;
        }
        public void MaskBottom()
        {
            if (Ring.IsSpots.Count == 0) return;
            for (int i = Ring.IsSpots.Count / 2; i < Ring.IsSpots.Count; i++)
                Ring.IsSpots[i] = true;
        }
        public void MaskLeft()
        {
            if (Ring.IsSpots.Count == 0) return;
            for (int h = 0; h < Ring.SrcImgSize.Height; h++)
                for (int w = 0; w < Ring.SrcImgSize.Width / 2; w++)
                    Ring.IsSpots[h * Ring.SrcImgSize.Width + w] = true;
        }
        public void MaskRight()
        {
            if (Ring.IsSpots.Count == 0) return;
            for (int h = 0; h<Ring.SrcImgSize.Height; h++)
                    for (int w = Ring.SrcImgSize.Width / 2; w<Ring.SrcImgSize.Width; w++)
                        Ring.IsSpots[h * Ring.SrcImgSize.Width + w] = true;
        }


        private void buttonUnmaskAll_Click(object sender, EventArgs e)
        {
            if (Ring.IsSpots.Count > 0)
                for (int i = 0; i < Ring.IsSpots.Count; i++)
                    Ring.IsSpots[i] = false;
            formMain.Draw();
        }

        private void buttonSaveMask_Click(object sender, EventArgs e)
        {
            formMain.toolStripMenuItemSaveMask_Click(sender, e);
        }

        Image chiImage;
        private void radioButtonChi_CheckedChanged(object sender, EventArgs e)
        {
            if (chiImage == null)
                chiImage = (Image)pictureBox1.Image.Clone();

            Image temp = (Image)chiImage.Clone();
            if (radioButtonChiCounterclockwise.Checked)
            {
                if (radioButtonChiRight.Checked)
                    temp.RotateFlip(RotateFlipType.Rotate180FlipX);
                else if (radioButtonChiBottom.Checked)
                    temp.RotateFlip(RotateFlipType.Rotate90FlipX);
                else if (radioButtonChiLeft.Checked)
                    temp.RotateFlip(RotateFlipType.RotateNoneFlipX);
                else
                    temp.RotateFlip(RotateFlipType.Rotate270FlipX);
            }
            else
            {
                if (radioButtonChiBottom.Checked)
                    temp.RotateFlip(RotateFlipType.Rotate90FlipNone);
                else if (radioButtonChiLeft.Checked)
                    temp.RotateFlip(RotateFlipType.Rotate180FlipNone);
                else if(radioButtonChiTop.Checked)
                    temp.RotateFlip(RotateFlipType.Rotate270FlipNone);

            }
            pictureBox1.Image = temp;
            pictureBox1.Refresh();

            Ring.ChiRotation = radioButtonChiClockwise.Checked ? Ring.Rotation.Clockwise : Ring.Rotation.Counterclockwise;
            Ring.ChiDirection = Ring.Direction.Right;
            if (radioButtonChiBottom.Checked) Ring.ChiDirection = Ring.Direction.Bottom;
            else if (radioButtonChiLeft.Checked) Ring.ChiDirection = Ring.Direction.Left;
            else if (radioButtonChiTop.Checked) Ring.ChiDirection = Ring.Direction.Top;
            formMain.IntegralArea_Changed(new object(), new EventArgs());
        }

        private void radioButtonFlatPanel_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButtonFlatPanel.Checked)
            {
                groupBoxGandlfiRadius.Visible = false;
                radioButtonFootMode.Enabled = true;
            }
            else
            {
                groupBoxGandlfiRadius.Visible = true;
                radioButtonFootMode.Enabled = false;
                if(radioButtonFootMode.Checked)
                {
                    radioButtonFootMode.Checked = false;
                    radioButtonDirectSpotMode.Checked = true;
                }

            }
            DetectorParameters_Changed(SectorAngle, e);


        }

        

        #region Background関連
        private void buttonSetBackgroundImage_Click(object sender, EventArgs e)
        {
            if(Ring.Intensity!=null && Ring.Intensity.Count>0)
            {
                Ring.Background = new List<double>(Ring.IntensityOriginal.ToArray());
                textBoxBackgroundImage.Text = formMain.FilePath + formMain.FileName;
            }
        }

        private void buttonClearBackgroundImage_Click(object sender, EventArgs e)
        {
            textBoxBackgroundImage.Text = "";
            Ring.Background.Clear();
            formMain.FlipRotate_Pollalization_Background();
        }

        private void NumericBoxBackgroundCoeff_ValueChanged(object sender, EventArgs e)
        {
            formMain.FlipRotate_Pollalization_Background();

        }

        #endregion Background関連

        private void checkBoxCorrectPolarization_CheckedChanged(object sender, EventArgs e)
        {
            formMain.FlipRotate_Pollalization_Background();
        }

        private void radioButtonDirectSpotMode_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDirectSpotMode.Checked)
            {
                flowLayoutPanelDirectSpotMode.Enabled = true;
                flowLayoutPanelFootMode.Enabled = false;
            }
            else
            {
                flowLayoutPanelDirectSpotMode.Enabled = false;
                flowLayoutPanelFootMode.Enabled = true;
            }
            formMain.FormFindParameterBruteForce.DetectorCoordinates = DetectorCoordinates;
        }

        private void groupBoxSphericalCorrection_Enter(object sender, EventArgs e)
        {

        }

        private void groupBoxPixelShape_Enter(object sender, EventArgs e)
        {

        }

        private void comboBoxScaleLineDivisions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (SkipEvent) return;
            formMain.comboBoxScaleLine.SelectedIndex = comboBoxScaleLineDivisions.SelectedIndex;
        }

        private void colorControlScale2Theta_Load(object sender, EventArgs e)
        {
            formMain.Draw();
        }

        private void trackBarScaleLineWidth_Scroll(object sender, EventArgs e)
        {
            formMain.Draw();
        }

        private void checkBoxScaleLabel_CheckedChanged(object sender, EventArgs e)
        {
            formMain.Draw();
        }
    }


    public class ImageTypeParameter
    {
        public IntegralProperty.CameraEnum CameraMode = IntegralProperty.CameraEnum.FlatPanel;

        public double CenterPosX=100, CenterPosY=100;
        public double[] SourceParameters;
        public double CameraLength=300;
        public double PixelSizeX = 0.1, PixelSizeY = 0.1, PixelKsi = 0.0;
        public double Tau = 0.0;
        public double Phi = 0.0;
        public double GandolfiRadius = 150;

        public WaveSource WaveSource= WaveSource.Xray;
        public int  XrayWaveSourceElementNumber=0;
        public XrayLine XrayLine= XrayLine.Ka;
        public double ElectronAccVoltage = 200;
        public double WaveLength = 0.04;

        public bool FlipHorizontally = false;
        public bool FlipVertically = false;

        /// <summary>
        /// イメージの回転. 0: 0度回転, 1: 90度回転, 2: 180度回転, 3: 270度回転
        /// </summary>
        public int Rotation = 0;

       



    }

}