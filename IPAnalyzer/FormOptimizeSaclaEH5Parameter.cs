using Crystallography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormOptimizeSaclaEH5Parameter : Form
    {
        public FormMain FormMain;

        public double CL
        {
            set { FormMain.FormProperty.CameraLength = value; }
            get { return FormMain.FormProperty.CameraLength; }
        }

        public double PixX
        {
            set { FormMain.FormProperty.numericBoxPixelSizeX.Value = value; }
            get { return FormMain.FormProperty.numericBoxPixelSizeX.Value; }
        }
        public double PixY
        {
            set { FormMain.FormProperty.numericBoxPixelSizeY.Value = value; }
            get { return FormMain.FormProperty.numericBoxPixelSizeY.Value; }
        }
        public PointD Center
        {
            set { FormMain.FormProperty.ImageCenter = value; }
            get { return FormMain.FormProperty.ImageCenter; }
        }

        public double Phi { set => FormMain.FormProperty.saclaControl.PhiDegree = value; get => FormMain.FormProperty.saclaControl.PhiDegree; }

        public double Tau { set => FormMain.FormProperty.saclaControl.TauDegree = value; get => FormMain.FormProperty.saclaControl.TauDegree; }

        public double Radius
        {
            set { FormMain.FormProperty.numericBoxGandlfiRadius.Value = value; }
            get { return FormMain.FormProperty.numericBoxGandlfiRadius.Value; }
        }

        public double Distance
        {
            set { FormMain.FormProperty.saclaControl.CameraLength2 = value; }
            get { return FormMain.FormProperty.saclaControl.CameraLength2; }
        }

        public double FootX
        {
            set { FormMain.FormProperty.saclaControl.Foot = new PointD(value, FormMain.FormProperty.saclaControl.Foot.Y); }
            get { return FormMain.FormProperty.saclaControl.Foot.X; }
        }
        public double FootY
        {
            set { FormMain.FormProperty.saclaControl.Foot = new PointD(FormMain.FormProperty.saclaControl.Foot.X, value); }
            get { return FormMain.FormProperty.saclaControl.Foot.Y; }
        }

        public FormOptimizeSaclaEH5Parameter()
        {
            InitializeComponent();
            crystalControl1.Crystal = new Crystal((0.407825, 0.407825, 0.407825, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "Au", Color.Violet);
        }

        private void crystalControl1_Load(object sender, EventArgs e)
        {

        }

        private void FormOptimizeSaclaEH5Parameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Visible = false;
        }

        /// <summary>
        /// 画像中のpt位置の2thetaを返す
        /// </summary>
        /// <param name="pt"></param>
        /// <returns></returns>
        private double getTwoTheta(int x, int y)
        {
            Point pt = new Point(x, y);
            FormMain.SetIntegralProperty();
            double SinTau = Math.Sin(Ring.IP.tau), CosTau = Math.Cos(Ring.IP.tau);
            double SinPhi = Math.Sin(Ring.IP.phi), CosPhi = Math.Cos(Ring.IP.phi);
            double _x = (pt.X - Ring.IP.CenterX) * Ring.IP.PixSizeX + (pt.Y - Ring.IP.CenterY) * Ring.IP.PixSizeY * Math.Tan(Ring.IP.ksi);
            double _y = (pt.Y - Ring.IP.CenterY) * Ring.IP.PixSizeY;

            double newX = (_y * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + _x * (CosPhi * CosPhi + CosTau * SinPhi * SinPhi))
                 * Ring.IP.FilmDistance / (_y * CosPhi * SinTau + Ring.IP.FilmDistance - _x * SinPhi * SinTau);
            double newY = (_x * (CosPhi * SinPhi - CosPhi * CosTau * SinPhi) + _y * (CosPhi * CosPhi * CosTau + SinPhi * SinPhi))
                 * Ring.IP.FilmDistance / (_y * CosPhi * SinTau + Ring.IP.FilmDistance - _x * SinPhi * SinTau);
            double r = Math.Sqrt(newX * newX + newY * newY);
            return Math.Atan2(r, Ring.IP.FilmDistance);

        }


        private void InitializeCrystalPlane()
        {
            FormMain.SetIntegralProperty();
            double[] twoTheta;
            //if (FormMain.IsFlatPanelMode)
            //    twoTheta = new double[] { getTwoTheta(0, 0), getTwoTheta(0, Ring.IP.SrcHeight - 1), getTwoTheta(Ring.IP.SrcWidth - 1, 0), getTwoTheta(Ring.IP.SrcWidth - 1, Ring.IP.SrcHeight - 1) };
            //else
                twoTheta = new double[] { Ring.IP.StartAngle, Ring.IP.EndAngle };

            Crystal crystal = crystalControl1.Crystal;
            double d_min = Ring.IP.WaveLength / 2 / Math.Sin(twoTheta.Max() / 2);
            double d_max = Ring.IP.WaveLength / 2 / Math.Sin(twoTheta.Min() / 2);

            List<double> wavelength = new List<double>();
            if (FormMain.FormProperty.waveLengthControl.WaveSource == WaveSource.Xray && FormMain.FormProperty.waveLengthControl.XrayWaveSourceElementNumber!=0 && FormMain.FormProperty.waveLengthControl.XrayWaveSourceLine == XrayLine.Ka)
            {
                wavelength.Add(AtomConstants.CharacteristicXrayWavelength(FormMain.FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka1) / 10.0);
                wavelength.Add(AtomConstants.CharacteristicXrayWavelength(FormMain.FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka2) / 10.0);
            }
            else
                wavelength.Add(FormMain.FormProperty.waveLengthControl.WaveLength);

            if (d_min > 0 && !double.IsInfinity(d_min))
            {
                List<Plane> planes = new List<Plane>();
                foreach (double wave in wavelength)
                {
                    crystal.SetPlanes(d_max, d_min, true, true, true, false, HorizontalAxis.Angle, 0, wave);
                    crystal.SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, wave, null);

                    for (int i = 0; i < crystal.Plane.Count; i++)
                        if (crystal.Plane[i].Intensity < 0.001)
                            crystal.Plane.RemoveAt(i);
                        else
                            crystal.Plane[i].XCalc = 2 * Math.Asin(wave / 2 / crystal.Plane[i].d) / Math.PI * 180;

                    planes.AddRange(crystal.Plane);
                }
                planes.Sort();

                crystal.Plane = planes;
            }
            



        }

        private void drawGraph(Profile profile, List<Plane> planes)
        {
            List<Profile> profiles = new List<Profile>();
            List<PointD> lineList = new List<PointD>();

            foreach (Plane p in crystalControl1.Crystal.Plane)
            {
                PeakFunction pf = p.peakFunction;
                if (!double.IsNaN(pf.X) && pf.Hk != 0)
                {
                    pf.RenewParameter();
                    profiles.Add(new Profile());
                    lineList.Add(new PointD(p.XCalc, double.NaN));
                    for (double k = p.XCalc - pf.range; k < p.XCalc + pf.range; k += (pf.range) / 300)
                        profiles[profiles.Count - 1].Pt.Add(new PointD(k, pf.GetValue(k, false) + pf.B1 + pf.B2 * (k - pf.X)));
                    //backgroundProfile[i].Pt.Add(new PointD(startTheta, pf.B1 + pf.B2 * (startTheta - pf.X)));
                    //backgroundProfile[i].Pt.Add(new PointD(endTheta, pf.B1 + pf.B2 * (endTheta - pf.X)));
                }
            }
            for (int i = 0; i < profiles.Count; i++)
            {
                profiles[i].Color = Color.Red;
                profiles[i].LineWidth = 2;
            }
            graphControl1.LineList = lineList.ToArray();
            profiles.Insert(0, profile);
            graphControl1.AddProfiles(profiles.ToArray());
        }



        private void buttonGetProfile_Click(object sender, EventArgs e)
        {
            getProfile();
        }


        private void getProfile()
        {
            InitializeCrystalPlane();
            Crystal crystal = crystalControl1.Crystal;

            FormMain.SetIntegralProperty();
            Profile profile = Ring.GetProfile(Ring.IP);

            if (FormMain.IsFlatPanelMode)
            {
                //FormMain.FormProperty.numericBoxConcentricStart.Value = crystal.Plane[0].XCalc - 0.5;
                //FormMain.FormProperty.numericBoxConcentricEnd.Value = crystal.Plane[crystal.Plane.Count - 1].XCalc + 0.5;
            }
            Fitting(profile, crystal.Plane);

            drawGraph(profile, crystal.Plane);
        }

        /// <summary>
        /// Fitting処理
        /// </summary>
        private void Fitting(Profile profile, List<Plane> planes)
        {
            if (FormMain.IsFlatPanelMode)
            {
                PointD[] pt = profile.Pt.ToArray();
                //いったん初期化
                for (int j = 0; j < planes.Count; j++)
                {
                    //planes[j].XCalc = 2 * Math.Asin(FormMain.FormProperty.WaveLength / 2 / planes[j].d) / Math.PI * 180;
                    planes[j].peakFunction = new PeakFunction();
                    planes[j].peakFunction.Option = PeakFunctionForm.PseudoVoigt;
                    double twoTheta = 2 * Math.Asin(FormMain.FormProperty.WaveLength / 2 / planes[j].d);
                    planes[j].peakFunction.range = /*(double)numericUpDownSearchRange.Value*/ 0.4 / Math.Cos(twoTheta / 2);
                    planes[j].peakFunction.Hk = planes[j].peakFunction.range / 2;
                    planes[j].peakFunction.X = planes[j].XCalc;
                    PeakFunction[] pf = new[] { planes[j].peakFunction };
                    double r = FittingPeak.FitMultiPeaksThread(pt, true, 0, ref pf);
                }
            }

            else
            {
                PointD[] pt = profile.Pt.ToArray();

                for (int j = 0; j < planes.Count; j++)
                {
                    //planes[j].XCalc = 2 * Math.Asin(FormMain.FormProperty.WaveLength / 2 / planes[j].d) / Math.PI * 180;
                    planes[j].peakFunction = new PeakFunction();
                    planes[j].peakFunction.Option = PeakFunctionForm.PseudoVoigt;
                    double twoTheta = 2 * Math.Asin(FormMain.FormProperty.WaveLength / 2 / planes[j].d);
                    planes[j].peakFunction.range = /*(double)numericUpDownSearchRange.Value*/ (double)numericUpDownFittingRangeForGandolfi.Value / Math.Cos(twoTheta / 2);
                    planes[j].peakFunction.Hk = planes[j].peakFunction.range / 2;
                    planes[j].peakFunction.X = planes[j].XCalc;

                }
                for (int i = 0; i < planes.Count; i++)
                {
                    int count = 1;
                    for (int j = i + 1; j < planes.Count; j++)
                    {
                        if ((planes[j].XCalc - planes[i].XCalc) < (planes[j].peakFunction.range + planes[i].peakFunction.range))
                            count++;
                        else
                            break;
                    }
                    PeakFunction[] pf = new PeakFunction[count];
                    for (int j = i; j < i + count; j++)
                        pf[j - i] = planes[j].peakFunction;

                    i += count - 1;

                    double r = FittingPeak.FitMultiPeaksThread(pt, true, 0, ref pf);
                }


            }
        }

        private void numericUpDownFittingRangeForGandolfi_ValueChanged(object sender, EventArgs e)
        {
            Profile profile = graphControl1.Profile;
            
            if (profile != null && profile.Pt != null && profile.Pt.Count > 0)
            {
                Crystal crystal = crystalControl1.Crystal;
                InitializeCrystalPlane();
                Fitting(profile, crystal.Plane);
                drawGraph(profile, crystal.Plane);
            }
        }

        private void buttonOptimizeSacla_Click(object sender, EventArgs e)
        {
            //InitializeCrystalPlane();
            Crystal crystal = crystalControl1.Crystal;

            if (crystal.Plane.Count == 0) return;

            //積分範囲を設定
            bool[] originalSpots = Ring.IsSpots.ToArray();

            bool[] area = new bool[Ring.IsOutsideOfIntegralProperty.Count];
            for (int j = 0; j < Ring.IsOutsideOfIntegralProperty.Count; j++)
                area[j] = true;
            
            for (int i = 0; i < crystal.Plane.Count; i++)
            {
                FormMain.FormProperty.numericBoxConcentricStart.Value = crystal.Plane[i].XCalc - 1.5;
                FormMain.FormProperty.numericBoxConcentricEnd.Value = crystal.Plane[i].XCalc + 1.5;
                for (int j = 0; j < Ring.IsOutsideOfIntegralProperty.Count; j++)
                    if (Ring.IsOutsideOfIntegralProperty[j] == false)
                        area[j] = false;
            }
           
            FormMain.FormProperty.numericBoxConcentricStart.Value = crystal.Plane[0].XCalc - 1.5;
            FormMain.FormProperty.numericBoxConcentricEnd.Value = crystal.Plane[crystal.Plane.Count - 1].XCalc + 1.5;
            for (int i = 0; i < Ring.IsSpots.Count; i++)
                Ring.IsSpots[i] = area[i] || originalSpots[i];
            
            FormMain.Draw();
            Ring.SetMask(true, true, true);
            double distanceStep = (double)numericUpDownDistanceStep.Value;
            double tauStep = (double)numericUpDownTauStep.Value;
            double phiStep = (double)numericUpDownPhiStep.Value;
            double footXStep = (double)numericUpDownFootPointXStep.Value;
            double footYStep = (double)numericUpDownFootPointYStep.Value;

            int distanceRange = checkBoxDistance.Checked ? (int)numericUpDownDistanceRange.Value : 0;
            int tauRange = checkBoxTwoTheta.Checked ? (int)numericUpDownTauRange.Value : 0;
            int phiRange = checkBoxPhi.Checked ? (int)numericUpDownPhiRange.Value : 0;
            int footXRange = checkBoxFootX.Checked ? (int)numericUpDownFootPointXRange.Value : 0;
            int footYRange = checkBoxFootY.Checked ? (int)numericUpDownFootPointYRange.Value : 0;

            int cycle = (int)numericUpDownIteration.Value;
            

            Stopwatch sw = new Stopwatch();
            sw.Start();
            long beforeTime = 0;
            int count = 0;
            SortedList<double, saclaValues> results = new SortedList<double, saclaValues>();

            var renewalTime = 7;
            void report(Profile profile, int n)
            {
                int total = (2 * phiRange + 1) * (2 * footXRange + 1) + (2 * distanceRange + 1) * (2 * tauRange + 1) * (2 * footYRange + 1)  ;
                double progress = (double)count / cycle / total;
                toolStripStatusLabel1.Text = "  " + ((sw.ElapsedMilliseconds - beforeTime) / (double)renewalTime).ToString("f1") + " ms / step.  "
                    + (progress * 100).ToString("f2") + " % completed.  "
                    + "Elappsed Time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f0") + " sec.  "
                    + "Wait about " + (sw.ElapsedMilliseconds / 1000.0 * (1.0 - progress) / progress).ToString("f0") + " sec.";
                textBox1.Text = "Cycle: " + n.ToString() + "\r\n";
                textBox1.Text += "Current best values\r\n     Distance:\t" + results.Values[0].Distance + "\r\n     Phi:\t\t" + results.Values[0].Phi + "\r\n     Tau:\t\t" + results.Values[0].Tau
                     + "\r\n     Foot X:\t" + results.Values[0].FootX + "\r\n     Foot Y:\t" + results.Values[0].FootY + "\r\n"
                     + "Current steps: \r\n     Distance:\t" + distanceStep + "\r\n     Phi:\t\t" + phiStep + "\r\n     Tau:\t\t" + tauStep
                     + "\r\n     Foot X:\t" + footXStep + "\r\n     Foot Y:\t" + footYStep + "\r\n";
                if (results.Count > 4)
                    textBox1.Text += "\r\n No.1: " + results.Keys[0].ToString() + "\r\n No.2: " + results.Keys[1].ToString()
                        + "\r\n No.3: " + results.Keys[2].ToString() + "\r\n No.4: " + results.Keys[3].ToString();

                beforeTime = sw.ElapsedMilliseconds;
                toolStripProgressBar1.Value = (int)(progress * toolStripProgressBar1.Maximum);
                drawGraph(profile, crystal.Plane);
                Application.DoEvents();
            }

            for (int n = 0; n < cycle; n++)
            {
                
                FormMain.FormProperty.SkipEvent = true;

                saclaValues initialValue = new saclaValues(Distance, Phi, Tau, FootX, FootY);
                results = new SortedList<double, saclaValues>();

                //PhiとFootX
                for (int paramPhi = -phiRange; paramPhi <= phiRange; paramPhi++)
                {
                    Phi = initialValue.Phi + paramPhi * phiStep;
                    for (int paramFootX = -footXRange; paramFootX <= footXRange; paramFootX++)
                    {
                        FootX = initialValue.FootX + paramFootX * footXStep;
                        count++;
                        var values = new saclaValues(Distance, Phi, Tau, FootX, FootY);
                        FormMain.SetIntegralProperty();
                        Profile profile = Ring.GetProfile(Ring.IP);
                        Fitting(profile, crystal.Plane);

                        double r = evaluatePeakHeightAndTwoTheta(profile, crystal.Plane);
                        if (!results.ContainsKey(r) && !double.IsNaN(r))
                            results.Add(r, values);

                        if (count % renewalTime == 0)
                            report(profile, n);
                    }
                }
                Phi = results.Values[0].Phi;
                FootX = results.Values[0].FootX;

                //次にDistance, Tau, FootY
                for (int paramDistance = -distanceRange; paramDistance <= distanceRange; paramDistance++)
                {
                    Distance = initialValue.Distance + paramDistance * distanceStep;
                    for (int paramTau = -tauRange; paramTau <= tauRange; paramTau++)
                    {
                        Tau = initialValue.Tau + paramTau * tauStep;

                        for (int paramFootY = -footYRange; paramFootY <= footYRange; paramFootY++)
                        {
                            FootY = initialValue.FootY + paramFootY * footYStep;
                            count++;

                            var values = new saclaValues(Distance, Phi, Tau, FootX, FootY);
                            FormMain.SetIntegralProperty();
                            Profile profile = Ring.GetProfile(Ring.IP);
                            Fitting(profile, crystal.Plane);

                            double r = evaluatePeakHeightAndTwoTheta(profile, crystal.Plane);
                            if (!results.ContainsKey(r) && !double.IsNaN(r))
                                results.Add(r, values);

                            if (count % renewalTime == 0)
                                report(profile, n);
                        }
                    }
                }
                FormMain.FormProperty.SkipEvent = false;
                Distance = results.Values[0].Distance;
                Tau = results.Values[0].Tau;
                FootY = results.Values[0].FootY;
                
                if (Distance == initialValue.Distance && Tau == initialValue.Tau && Phi == initialValue.Phi && FootX == initialValue.FootX && FootY == initialValue.FootY)
                {
                    distanceStep = nextStep(distanceStep);
                    tauStep = nextStep(tauStep);
                    phiStep = nextStep(phiStep);
                    footXStep = nextStep(footXStep);
                    footYStep = nextStep(footYStep);
                }
            }
            toolStripStatusLabel1.Text = "Complete! Total time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f0") + " sec.";
            FormMain.SetIntegralProperty();
            Profile finalProfile = Ring.GetProfile(Ring.IP);
            Fitting(finalProfile, crystal.Plane);
            drawGraph(finalProfile, crystal.Plane);
        }

        struct saclaValues
        {
            public double Distance, Tau, Phi, FootX, FootY;
            public saclaValues(double distance,double phi, double twoTheta, double footX, double footY)
            {
                Distance = distance;
                Phi = phi;
                Tau = twoTheta;
                FootX = footX;
                FootY = footY;
            }

        }

        struct gandolfiValues
        {
            public double CameraLength, PixelSizeX, PixelSizeY, CenterX, CenterY, Tau, Phi, Radius;
            public gandolfiValues(double cameraLength, double pixSizeX, double pixSizeY, double centerX, double centerY, double tau, double phi, double radius)
            {
                CameraLength = cameraLength;
                PixelSizeX = pixSizeX;
                PixelSizeY = pixSizeY;
                CenterX = centerX;
                CenterY = centerY;
                Tau = tau;
                Phi = phi;
                Radius = radius;
            }

        }

        public double nextStep(double step)
        {
            int n = (int)(Math.Floor(Math.Log10(step)));

            if (step > Math.Pow(10, n) * 7.5)
                return Math.Pow(10, n) * 7.5;
            else if (step > Math.Pow(10, n) * 5.6)
                return Math.Pow(10, n) * 5.6;
            else if (step > Math.Pow(10, n) * 4.2)
                return Math.Pow(10, n) * 4.2;
            else if (step > Math.Pow(10, n) * 3.2)
                return Math.Pow(10, n) * 3.2;
            else if (step > Math.Pow(10, n) * 2.4)
                return Math.Pow(10, n) * 2.4;
            else if (step > Math.Pow(10, n) * 1.8)
                return Math.Pow(10, n) * 1.8;
            else if (step > Math.Pow(10, n) * 1.3)
                return Math.Pow(10, n) * 1.3;
            else if (step > Math.Pow(10, n) * 1.0)
                return Math.Pow(10, n) * 1.0;
            else
                return Math.Pow(10, n - 1) * 7.5;
            //     }



        }

        private double evaluatePeakHeightAndTwoTheta(Profile profile, List<Plane> planes)
        {
            if (FormMain.IsFlatPanelMode)
            {
                double twoThetaDeviation = 0; //, hkWidth = 0;
                double height = 0;
                for (int i = 0; i < planes.Count; i++)
                {
                    if (!double.IsNaN(planes[i].peakFunction.X))
                    {
                        var targetRange = profile.Pt.Where(p => Math.Abs(p.X - planes[i].XCalc) < 0.5);

                        double topHeight = targetRange.Max(p => p.Y);
                        height += topHeight;
                        twoThetaDeviation += (planes[i].XCalc - planes[i].peakFunction.X) * (planes[i].XCalc - planes[i].peakFunction.X);
                    }
                }
                return twoThetaDeviation + 100 / height;// + 1 / hkWidth;
            }
            else
            {

                double twoThetaDeviation = 0; //, hkWidth = 0;
                //double height = 0;
                for (int i = 0; i < planes.Count; i++)
                {
                    //height += planes[i].peakFunction.GetValue(planes[i].peakFunction.X, false);
                    twoThetaDeviation += (planes[i].XCalc - planes[i].peakFunction.X) * (planes[i].XCalc - planes[i].peakFunction.X);
                }
                //Kaを使っている場合は、なるべく強度比が0.5に近い方がよい
                double ratio = 1;
                if (FormMain.FormProperty.waveLengthControl.WaveSource == WaveSource.Xray && FormMain.FormProperty.waveLengthControl.XrayWaveSourceLine == XrayLine.Ka)
                {
                    ratio = 0;
                    for (int i = 0; i < planes.Count; i += 2)
                    {
                        ratio += (planes[i].peakFunction.Int / planes[i + 1].peakFunction.Int - 2) * (planes[i].peakFunction.Int / planes[i + 1].peakFunction.Int - 2);
                    }
                }


                return twoThetaDeviation * ratio;// + 100 / height;// + 1 / hkWidth;



            }
        }
        private double evaluatePeakHeight(Profile profile, List<Plane> planes)
        {
            double height = 0;
            for (int i = 0; i < planes.Count; i++)
            {
                var targetRange = profile.Pt.Where(p => Math.Abs(p.X - planes[i].XCalc) < 0.5);
                double topHeight = targetRange.Max(p => p.Y);
                height += topHeight;
            }
            return 1 / height;
        }


        private void checkBoxDistance_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanelDistanceRange.Enabled = flowLayoutPanelDistanceStep.Enabled = checkBoxDistance.Checked;
            flowLayoutPanelTwoThetaRange.Enabled = flowLayoutPanelTwoThetaStep.Enabled = checkBoxTwoTheta.Checked;
            flowLayoutPanelFootPointXRange.Enabled = flowLayoutPanelFootPointXStep.Enabled = checkBoxFootX.Checked;
            flowLayoutPanelFootPointYRange.Enabled = flowLayoutPanelFootPointYStep.Enabled = checkBoxFootY.Checked;

        }

        private void FormOptimizeSaclaEH5Parameter_VisibleChanged(object sender, EventArgs e)
        {
            if (FormMain.IsFlatPanelMode)
            {
                Crystal c = new Crystal((0.407825, 0.407825, 0.407825, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "Au",  Color.Violet);
                c.AddAtoms(new Atoms("Au", 79, 0, 0, new double[] { 1 }, 523, new Vector3D(0, 0, 0), 1, new DiffuseScatteringFactor()));
                crystalControl1.Crystal = c;
                tabControl1.SelectedIndex = 0;
            }
            else
            {
                crystalControl1.Crystal = new Crystal((0.5411102, 0.5411102, 0.5411102, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "CeO2",  Color.Violet);
                tabControl1.SelectedIndex = 1;
            }

        }

        private void buttonOptimizeGandolfi_Click(object sender, EventArgs e)
        {
            InitializeCrystalPlane();
            Crystal crystal = crystalControl1.Crystal;

            if (crystal.Plane.Count == 0) return;

            //積分範囲を設定
            FormMain.Draw();

            var cameraLengthStep = (double)numericUpDownCameraLengthStep.Value;
            var pixSizeStep = (double)numericUpDownPixelSizeStep.Value;
            var centerStep = (double)numericUpDownCenterPositionStep.Value;
            var tiltStep = (double)numericUpDownIPTiltStep.Value;
            var radiusStep = (double)numericUpDownGandolfiRadiusStep.Value;

            var cameraLengthRange = checkBoxCameraLength.Checked ? (int)numericUpDownCameraLengthRange.Value : 0;
            var pixSizeRange = checkBoxPixelSize.Checked ? (int)numericUpDownPixelSizeRange.Value : 0;
            var centerRange = checkBoxCenterPosition.Checked ? (int)numericUpDownCenterPositionRange.Value : 0;
            var tiltRange = checkBoxIPTilt.Checked ? (int)numericUpDownTiltRange.Value : 0;
            var radiusRange = checkBoxGandlfiRadius.Checked ? (int)numericUpDownGandolfiRadiusRange.Value : 0;

            int cycle = (int)numericUpDownIterationGandolfi.Value;

            Stopwatch sw = new Stopwatch(); sw.Start();

            long beforeTime = 0;

            double alpha1 = AtomConstants.CharacteristicXrayWavelength(42, Crystallography.XrayLine.Ka1);
            double alpha2 = AtomConstants.CharacteristicXrayWavelength(42, Crystallography.XrayLine.Ka2);

            Profile profile;
            for (int n = 0; n < cycle; n++)
            {
                FormMain.FormProperty.SkipEvent = true;

                var initialValue = new gandolfiValues(CL, PixX, PixY, Center.X, Center.Y, Tau, Phi, Radius);
                var results = new SortedList<double, gandolfiValues>();

                var parameters = new List<gandolfiValues>();
                //Center
                for (int p1 = -centerRange; p1 <= centerRange; p1++)
                    for (int p2 = -centerRange; p2 <= centerRange; p2++)
                        parameters.Add(new gandolfiValues
                            (CL, PixX, PixY, Center.X + p1 * centerStep, Center.Y + p2 * centerStep, Tau, Phi, Radius));

                //pixelSize
                for (int p1 = -pixSizeRange; p1 <= pixSizeRange; p1++)
                    for (int p2 = -pixSizeRange; p2 <= pixSizeRange; p2++)
                        parameters.Add(new gandolfiValues
                            (CL, PixX + p1 * pixSizeStep, PixY + p2 * pixSizeStep, Center.X , Center.Y , Tau, Phi, Radius));

                //cameralength, GandolfiRadius
                for (int p1 = -cameraLengthRange; p1 <= cameraLengthRange; p1++)
                    for (int p2 = -radiusRange; p2 <= radiusRange; p2++)
                        parameters.Add(new gandolfiValues
                            (CL + p1 * cameraLengthStep, PixX , PixY , Center.X, Center.Y, Tau, Phi, Radius + p2 * radiusStep));

                //Tilt, Tau
                for (int p1 = -tiltRange; p1 <= tiltRange; p1++)
                    for (int p2 = -tiltRange; p2 <= tiltRange; p2++)
                        parameters.Add(new gandolfiValues
                            (CL, PixX , PixY , Center.X, Center.Y, Tau + p1 * tiltStep, Phi + p2 * tiltStep, Radius));

                int count = 0;
                foreach (var v in parameters)
                {
                    CL = v.CameraLength;
                    Center = new PointD(v.CenterX, v.CenterY);
                    PixX = v.PixelSizeX;
                    PixY = v.PixelSizeY;
                    Tau = v.Tau;
                    Phi = v.Phi;
                    Radius = v.Radius;

                    FormMain.SetIntegralProperty();
                    profile = Ring.GetProfile(Ring.IP);
                    //profile = DiffractionProfile.RemoveKalpha2(profile,alpha1, alpha2, 0.5);

                    Fitting(profile, crystal.Plane);

                    double r = evaluatePeakHeightAndTwoTheta(profile, crystal.Plane);
                    if (!results.ContainsKey(r))
                        results.Add(r, v);

                    drawGraph(profile, crystal.Plane);

                    #region 進捗状況を更新
                    count++;
                    double progress = ((double)n + (double)count  / parameters.Count)/ cycle ;
                    toolStripStatusLabel1.Text = "  " + ((sw.ElapsedMilliseconds - beforeTime) / 1000.0).ToString("f2") + " sec / step.  "
                        + (progress * 100).ToString("f2") + " % completed.  "
                        + "Elappsed Time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f0") + " sec.  "
                        + "Wait about " + (sw.ElapsedMilliseconds / 1000.0 * (1.0 - progress) / progress).ToString("f0") + " sec.";
                    textBox1.Text = "Current best values\r\n" +
                        "\tCamera Length(mm):\t" + results.Values[0].CameraLength + "\r\n     " +
                        "\tPixel Size(mm):\t" + results.Values[0].PixelSizeX + "," + results.Values[0].PixelSizeY + "\r\n" +
                        "\tCenter:\t" + results.Values[0].CenterX + ", " + results.Values[0].CenterY + "\r\n" +
                        "\tTilt(rad):\t" + results.Values[0].Phi + ", " + results.Values[0].Tau + "\r\n" +
                        "\tRadius(mm):\t" + results.Values[0].Radius + "\r\n" +
                        "Current steps: \r\n" +
                        "\tCamera Length:\t" + cameraLengthStep + "\r\n" +
                        "\tPixelSize:\t" + pixSizeStep + "\r\n" +
                        "\tCenter:\t" + centerStep + "\r\n" +
                        "\tTilt:\t" + tiltStep + "\r\n" +
                        "\tRadius:\t" + radiusStep;
                    beforeTime = sw.ElapsedMilliseconds;
                    toolStripProgressBar1.Value = (int)(progress * toolStripProgressBar1.Maximum);
                    #endregion
                    drawGraph(profile, crystal.Plane);
                    Application.DoEvents();
                }

                FormMain.FormProperty.SkipEvent = false;
                CL = results.Values[0].CameraLength;
                Center = new PointD(results.Values[0].CenterX, results.Values[0].CenterY);
                PixX = results.Values[0].PixelSizeX;
                PixY = results.Values[0].PixelSizeY;
                Tau = results.Values[0].Tau;
                Phi = results.Values[0].Phi;
                Radius = results.Values[0].Radius;
                if (CL == initialValue.CameraLength &&
                    Center.X == initialValue.CenterX && Center.Y == initialValue.CenterY &&
                    PixX == initialValue.PixelSizeX && PixY == initialValue.PixelSizeY &&
                    Tau == initialValue.Tau && Phi == initialValue.Phi &&
                    Radius == initialValue.Radius)
                {
                    cameraLengthStep = nextStep(cameraLengthStep);
                    centerStep = nextStep(centerStep);
                    pixSizeStep = nextStep(pixSizeStep);
                    tiltStep = nextStep(tiltStep);
                    radiusStep = nextStep(radiusStep);
                }

            }
            toolStripStatusLabel1.Text = "Complete! Total time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f0") + " sec.";
            FormMain.SetIntegralProperty();
            Profile finalProfile = Ring.GetProfile(Ring.IP);
            Fitting(finalProfile, crystal.Plane);
            drawGraph(finalProfile, crystal.Plane);
        }

        private bool graphControl1_MouseDoubleClick2(PointD pt)
        {

            if (tabControl1.SelectedIndex == 1)
                return false;


            Crystal crystal = crystalControl1.Crystal;

            int index = -1;
            double dev = double.PositiveInfinity;
            for (int i = 0; i < crystal.Plane.Count; i++)
            {
                double twoTheta = Math.Asin(FormMain.FormProperty.waveLengthControl.WaveLength / 2.0 / crystal.Plane[i].d) * 360 / Math.PI;

                if(dev>Math.Abs(twoTheta-pt.X))
                {
                    index = i;
                    dev = Math.Abs(twoTheta - pt.X);

                }
            }

            if(index!=-1 && dev < (graphControl1.UpperX-graphControl1.LowerX)/graphControl1.Width*3.0)
            {
                crystal.Plane.RemoveAt(index);

                double upperX= graphControl1.UpperX;
                double lowerX = graphControl1.LowerX;
                double upperY = graphControl1.UpperY;
                double lowerY = graphControl1.LowerY;

                drawGraph(graphControl1.Profile, crystal.Plane);

                graphControl1.UpperX = upperX;
                graphControl1.LowerX = lowerX;

                graphControl1.UpperY = upperY;
                graphControl1.LowerY = lowerY;
                graphControl1.Draw();

                return true;
            }

            return false;
            ;
        }
    }
}
