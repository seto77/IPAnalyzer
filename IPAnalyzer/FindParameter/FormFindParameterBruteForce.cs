using Crystallography;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Threading;

namespace IPAnalyzer;

public partial class FormFindParameterBruteForce : Form
{
    #region プロパティ
    public FormMain FormMain;

    public double CameraLength1 { set => FormMain.FormProperty.CameraLength1 = value; get => FormMain.FormProperty.CameraLength1; }
    public double CameraLength2 { set => FormMain.FormProperty.CameraLength2 = value; get => FormMain.FormProperty.CameraLength2; }

    public double PixX { set => FormMain.FormProperty.DetectorPixelSizeX = value; get => FormMain.FormProperty.DetectorPixelSizeX; }
    public double PixY { set => FormMain.FormProperty.DetectorPixelSizeY = value; get => FormMain.FormProperty.DetectorPixelSizeY; }
    public double PixKsi { set => FormMain.FormProperty.DetectorPixelKsi = value; get => FormMain.FormProperty.DetectorPixelKsi; }

    public PointD DirectSpotPosition { set => FormMain.FormProperty.DirectSpotPosition = value; get => FormMain.FormProperty.DirectSpotPosition; }
    public PointD FootPosition { set => FormMain.FormProperty.FootPosition = value; get => FormMain.FormProperty.FootPosition; }

    public double Phi { set => FormMain.FormProperty.DetectorTiltPhi = value; get => FormMain.FormProperty.DetectorTiltPhi; }

    public double Tau { set => FormMain.FormProperty.DetectorTiltTau = value; get => FormMain.FormProperty.DetectorTiltTau; }

    public double Radius { set => FormMain.FormProperty.numericBoxGandlfiRadius.Value = value; get => FormMain.FormProperty.numericBoxGandlfiRadius.Value; }

    public double FootX
    {
        set => FormMain.FormProperty.FootPosition = new PointD(value, FormMain.FormProperty.FootPosition.Y);
        get => FormMain.FormProperty.FootPosition.X;
    }
    public double FootY
    {
        set => FormMain.FormProperty.FootPosition = new PointD(FormMain.FormProperty.FootPosition.X, value);
        get => FormMain.FormProperty.FootPosition.Y;
    }

    public double DirectX
    {
        set => FormMain.FormProperty.DirectSpotPosition = new PointD(value, FormMain.FormProperty.DirectSpotPosition.Y);
        get => FormMain.FormProperty.DirectSpotPosition.X;
    }
    public double DirectY
    {
        set => FormMain.FormProperty.DirectSpotPosition = new PointD(FormMain.FormProperty.DirectSpotPosition.X, value);
        get => FormMain.FormProperty.DirectSpotPosition.Y;
    }

    public double WaveLength { set => FormMain.FormProperty.WaveLength = value; get => FormMain.FormProperty.WaveLength; }

    public FormProperty.DetectorCoordinatesEnum DetectorCoordinates
    {
        get
        {
            if (radioButtonDirectSpotMode.Checked)
                return FormProperty.DetectorCoordinatesEnum.DirectSpot;
            else
                return FormProperty.DetectorCoordinatesEnum.Foot;
        }
        set
        {
            if(value != DetectorCoordinates)
            {
                if(value== FormProperty.DetectorCoordinatesEnum.DirectSpot)
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
        }
    }

    #endregion

    #region 起動/終了
    public FormFindParameterBruteForce()
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
        FormMain.toolStripButtonFindParameterBruteForce.Checked = false;
    
    }
    #endregion

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
            wavelength.Add(AtomStatic.CharacteristicXrayWavelength(FormMain.FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka1) / 10.0);
            wavelength.Add(AtomStatic.CharacteristicXrayWavelength(FormMain.FormProperty.waveLengthControl.XrayWaveSourceElementNumber, XrayLine.Ka2) / 10.0);
        }
        else
            wavelength.Add(FormMain.FormProperty.waveLengthControl.WaveLength);

        if (d_min > 0 && !double.IsInfinity(d_min))
        {
            var planes = new List<Plane>();
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
        var profiles = new List<Profile>();
        var lineList = new List<PointD>();

        foreach (var p in crystalControl1.Crystal.Plane)
        {
            var pf = p.peakFunction;
            if (!double.IsNaN(pf.X) && pf.Hk != 0)
            {
                pf.RenewParameter();
                profiles.Add(new Profile());
                lineList.Add(new PointD(p.XCalc, double.NaN));
                for (double k = p.XCalc - pf.range; k < p.XCalc + pf.range; k += (pf.range) / 300)
                    profiles[^1].Pt.Add(new PointD(k, pf.GetValue(k, false) + pf.B1 + pf.B2 * (k - pf.X)));
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
        Ring.SetMask(true, true, true);
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
            var pt = profile.Pt;
            //いったん初期化

            Parallel.ForEach(planes, p =>
            //for (int j = 0; j < planes.Count; j++)
            {
                p.XCalc = Math.Asin(WaveLength / 2 / p.d) / Math.PI * 360;

                p.peakFunction = new PeakFunction();
                p.peakFunction.Option = PeakFunctionForm.PseudoVoigt;
                var twoTheta = 2 * Math.Asin(FormMain.FormProperty.WaveLength / 2 / p.d);
                p.peakFunction.range = /*(double)numericUpDownSearchRange.Value*/ numericBoxFittingRange.Value / Math.Cos(twoTheta / 2);
                p.peakFunction.Hk = p.peakFunction.range / 2;
                p.peakFunction.X = p.XCalc;
                var pf = new[] { p.peakFunction };
                double r = FittingPeak.FitMultiPeaksThread(pt, true, 0, ref pf);
            }
            );
        }

        else
        {
            var pt = profile.Pt;

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

    bool stopFlag = false;
    private void buttonStop_Click(object sender, EventArgs e)
    {
        stopFlag = true;
        buttonStop.Visible = false;

        if (originalSpots != null)
        {
            Ring.IsSpots.Clear();
            Ring.IsSpots.AddRange(originalSpots);
        }
        FormMain.FormProperty.numericBoxConcentricStart.Value = initialStart;
        FormMain.FormProperty.numericBoxConcentricEnd.Value = initialEnd;
        FormMain.SkipDrawing = false;
        FormMain.Draw();
    }

    bool[] originalSpots;
    double initialStart=0;
    double initialEnd=0;
    private void buttonOptimizeSacla_Click(object sender, EventArgs e)
    {
        buttonStop.Visible = true;
        stopFlag = false;

        //InitializeCrystalPlane();
        Crystal crystal = crystalControl1.Crystal;

        if (crystal.Plane.Count == 0) return;

        //スポットと、積分角度範囲の初期値を記憶
        originalSpots = Ring.IsSpots.ToArray();
        initialStart = FormMain.FormProperty.numericBoxConcentricStart.Value;
        initialEnd = FormMain.FormProperty.numericBoxConcentricEnd.Value;
        //積分範囲を設定
        bool[] area = new bool[Ring.IsOutsideOfIntegralProperty.Count];
        for (int j = 0; j < Ring.IsOutsideOfIntegralProperty.Count; j++)
            area[j] = true;
        
        for (int i = 0; i < crystal.Plane.Count; i++)
        {
            FormMain.FormProperty.numericBoxConcentricStart.Value = crystal.Plane[i].XCalc - numericBoxFittingRange.Value * 2;
            FormMain.FormProperty.numericBoxConcentricEnd.Value = crystal.Plane[i].XCalc + numericBoxFittingRange.Value * 2;
            for (int j = 0; j < Ring.IsOutsideOfIntegralProperty.Count; j++)
                if (Ring.IsOutsideOfIntegralProperty[j] == false)
                    area[j] = false;
        }
       
        FormMain.FormProperty.numericBoxConcentricStart.Value = crystal.Plane[0].XCalc - numericBoxFittingRange.Value * 2;
        FormMain.FormProperty.numericBoxConcentricEnd.Value = crystal.Plane[^1].XCalc + numericBoxFittingRange.Value * 2;
        for (int i = 0; i < Ring.IsSpots.Count; i++)
            Ring.IsSpots[i] = area[i] || originalSpots[i];
        
        FormMain.Draw();
        Ring.SetMask(true, true, true);
        var cameraLengthStep = numericBoxCameraLengthStep.Value;
        var tauStep = numericBoxTauStep.Value;
        var phiStep = numericBoxPhiStep.Value;
        var pointXStep = numericBoxPointXStep.Value;
        var pointYStep = numericBoxPointYStep.Value;
        var waveLengthStep = numericBoxWaveLengthStep.Value;

        //「3」と入力したら、 0,-1,1,-2,2,-3,3 の数列を返す関数
        List<int> genArray(int n)
        {
            var result = Enumerable.Range(-n, 2*n + 1).ToList();
            result.Sort((n1, n2) => Math.Abs(n1).CompareTo(Math.Abs(n2)));
           return result;
        }

        var cameraLengthRange = genArray(checkBoxCameraLength.Checked ? numericBoxCameraLengthRange.ValueInteger : 0);
        var tauRange = genArray(checkBoxTau.Checked ? numericBoxTauRange.ValueInteger : 0);
        var phiRange = genArray(checkBoxPhi.Checked ? numericBoxPhiRange.ValueInteger : 0);
        var pointXRange = genArray(checkBoxPointX.Checked ? numericBoxFootPointXRange.ValueInteger : 0);
        var pointYRange = genArray(checkBoxPointY.Checked ? numericBoxFootPointYRange.ValueInteger : 0);
        var waveLengthRange = genArray(checkBoxWaveLength.Checked ? numericBoxWaveLengthRange.ValueInteger : 0);

        var sw = new Stopwatch();
        sw.Start();
        long beforeTime = 0;
        int count = 0;
        var results = new SortedList<double, flatPanelValues>();

        var renewalTime = 6;
        
        FormMain.SkipDrawing = true;

        var directMode = DetectorCoordinates == FormProperty.DetectorCoordinatesEnum.DirectSpot;

        flatPanelValues initialValue;
        for (int n = 0; n < (int)numericBoxIteration.Value; n++)
        {
            initialValue = DetectorCoordinates == FormProperty.DetectorCoordinatesEnum.DirectSpot ?
                new flatPanelValues(CameraLength1, Phi, Tau, DirectX, DirectY, WaveLength) :
                new flatPanelValues(CameraLength2, Phi, Tau, FootX, FootY, WaveLength);

            foreach (int paramCameraLength in cameraLengthRange)
                foreach (int paramPointX in pointXRange)
                    foreach (int paramPointY in pointYRange)
                        foreach (int paramPhi in phiRange)
                            foreach (int paramTau in tauRange)
                            {
                                if (n < (int)numericBoxIteration.Value)
                                {
                                    //各パラメータの値を変更
                                    var cameraLength = initialValue.CameraLength + paramCameraLength * cameraLengthStep;
                                    var centerX = initialValue.PointX + paramPointX * pointXStep;
                                    var centerY = initialValue.PointY + paramPointY * pointYStep;
                                    var phi = initialValue.Phi + paramPhi * phiStep;
                                    var tau = initialValue.Tau + paramTau * tauStep;

                                    FormMain.FormProperty.SkipEvent = true;
                                    if (directMode)
                                    {
                                        CameraLength1 = cameraLength;
                                        DirectX = centerX;
                                        DirectY = centerY;
                                    }
                                    else
                                    {
                                        CameraLength2 = cameraLength;
                                        FootX = centerX;
                                        FootY = centerY;
                                    }
                                    Tau = tau;
                                    Phi = phi;
                                    FormMain.FormProperty.SkipEvent = false;

                                    FormMain.FormProperty.DetectorParameters_Changed(sender, e);
                                    FormMain.SetIntegralProperty();

                                    var profile = Ring.GetProfile(Ring.IP);

                                    foreach (int paramWaveLength in waveLengthRange)
                                    {
                                        WaveLength = initialValue.WaveLength + paramWaveLength * waveLengthStep * 0.1;

                                        count++;
                                        Fitting(profile, crystal.Plane);
                                        var r = evaluatePeakHeightAndTwoTheta(profile, crystal.Plane);
                                        if (!results.ContainsKey(r) && !double.IsNaN(r))
                                            results.Add(r, new flatPanelValues(cameraLength, phi, tau, centerX, centerY, WaveLength));

                                        if (count % renewalTime == 0)
                                            report(profile, n);

                                        if (stopFlag)//終了フラグが立っているときは、初期値に戻して終了
                                        {
                                            results.Clear();
                                            results.Add(0, new flatPanelValues(initialValue.CameraLength, initialValue.Phi, initialValue.Tau, initialValue.PointX, initialValue.PointY, initialValue.WaveLength));
                                            n = int.MaxValue - 1;
                                            break;
                                        }
                                    }
                                }
                            }
            //最も成績の良かったパラメータを採用する
            FormMain.FormProperty.SkipEvent = true;
            if (directMode)
            {
                CameraLength1 = results.Values[0].CameraLength;
                DirectX = results.Values[0].PointX;
                DirectY = results.Values[0].PointY;
            }
            else
            {
                CameraLength2 = results.Values[0].CameraLength;
                FootX = results.Values[0].PointX;
                FootY = results.Values[0].PointY;
            }
            Phi = results.Values[0].Phi;
            Tau = results.Values[0].Tau;
            WaveLength = results.Values[0].WaveLength;
            FormMain.FormProperty.SkipEvent = false;
            FormMain.FormProperty.DetectorParameters_Changed(sender, e);

            //改善が無かった場合は、ステップを小さくする
            if ((directMode && CameraLength1 == initialValue.CameraLength && DirectX == initialValue.PointX && DirectY == initialValue.PointY) ||
                (!directMode && CameraLength2 == initialValue.CameraLength && FootX == initialValue.PointX && FootY == initialValue.PointY))
                if (Tau == initialValue.Tau && Phi == initialValue.Phi && WaveLength == initialValue.WaveLength)
                {
                    cameraLengthStep = nextStep(cameraLengthStep);
                    tauStep = nextStep(tauStep);
                    phiStep = nextStep(phiStep);
                    pointXStep = nextStep(pointXStep);
                    pointYStep = nextStep(pointYStep);
                    waveLengthStep = nextStep(waveLengthStep);
                }
        }
        FormMain.SkipDrawing = false;

        #region 進捗状況報告のためのローカル関数
        void report(Profile profile, int n)
        {
            //int total = (2 * phiRange + 1) * (2 * footXRange + 1) + (2 * distanceRange + 1) * (2 * tauRange + 1) * (2 * footYRange + 1)  ;

            var total = phiRange.Count() * pointXRange.Count() * cameraLengthRange.Count() * tauRange.Count() * pointYRange.Count() * waveLengthRange.Count();
            double progress = (double)count / (int)numericBoxIteration.Value / total;
            toolStripStatusLabel1.Text = 
                $"  {(sw.ElapsedMilliseconds - beforeTime) / (double)renewalTime:f1} ms / step." +
                $"  {progress * 100:f2} % completed.  Elappsed Time: {sw.ElapsedMilliseconds / 1000.0:f0} sec." +
                $"  Wait about {sw.ElapsedMilliseconds / 1000.0 * (1.0 - progress) / progress:f0} sec.";

            textBox1.Text = $"Cycle: {n}\r\n";
            var best = results.Values[0];
            var x = $"xx{0.1:g8}";

            textBox1.Text +=
                $"Current best values\r\n" +
                $"    CL  : {best.CameraLength:g10}{(best.CameraLength!=initialValue.CameraLength? " (Changed)" : " (Unchanged)")}\r\n" +
                $"    X   : {best.PointX:g10}{(best.PointX != initialValue.PointX ? " (Changed)" : " (Unchanged)")}\r\n" +
                $"    Y   : {best.PointY:g10}{(best.PointY != initialValue.PointY ? " (Changed)" : " (Unchanged)")}\r\n" +
                $"    Phi : {best.Phi:g10}{(best.Phi != initialValue.Phi ? " (Changed)" : " (Unchanged)")}\r\n" +
                $"    Tau : {best.Tau:g10}{(best.Tau != initialValue.Tau ? " (Changed)" : " (Unchanged)")}\r\n" +
                $"    Wave:\t{best.WaveLength}{(best.WaveLength != initialValue.WaveLength ? " (Changed)" : " (Unchanged)")}\r\n" +
                $"Current steps: \r\n" +
                $"    CL  : {cameraLengthStep:g10}\r\n" +
                $"    X   : {pointXStep:g10}\r\n" +
                $"    Y   : {pointYStep:g10}\r\n" +
                $"    Phi : {phiStep:g10}\r\n" +
                $"    Tau : {tauStep:g10}\r\n" +
                $"    Wave:\t{waveLengthStep:g10}\r\n";
            if (results.Count > 4)
                textBox1.Text += $"\r\n No.1: {results.Keys[0]}\r\n No.2: {results.Keys[1]}\r\n No.3: {results.Keys[2]}\r\n No.4: {results.Keys[3]}";

            beforeTime = sw.ElapsedMilliseconds;
            toolStripProgressBar1.Value = (int)(progress * toolStripProgressBar1.Maximum);
            drawGraph(profile, crystal.Plane);
            Application.DoEvents();
        }
        #endregion

        toolStripStatusLabel1.Text = "Complete! Total time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f0") + " sec.";
        buttonStop.Visible = false;
        FormMain.SetIntegralProperty();
        var finalProfile = Ring.GetProfile(Ring.IP);
        Fitting(finalProfile, crystal.Plane);
        drawGraph(finalProfile, crystal.Plane);

        if (originalSpots != null)
        {
            Ring.IsSpots.Clear();
            Ring.IsSpots.AddRange(originalSpots);
        }
        FormMain.FormProperty.numericBoxConcentricStart.Value = initialStart;
        FormMain.FormProperty.numericBoxConcentricEnd.Value = initialEnd;
        FormMain.Draw();
    }

    struct flatPanelValues
    {
        public double CameraLength, Tau, Phi, PointX, PointY, WaveLength;
        public flatPanelValues(double cameraLength,double phi, double tau, double centerX, double centerY, double waveLength)
        {
            CameraLength = cameraLength;
            Phi = phi;
            Tau = tau;
            PointX = centerX;
            PointY = centerY;
            WaveLength = waveLength;
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
                    var targetRange = profile.Pt.Where(p => Math.Abs(p.X - planes[i].XCalc) < 0.4);

                    //double topHeight = targetRange.Max(p => p.Y);
                    //double topHeight = planes[i].peakFunction.GetValue(planes[i].XCalc, true);
                    double topHeight = planes[i].peakFunction.GetValue(planes[i].peakFunction.X, true);
                    height += topHeight;

                    planes[i].peakFunction.GetValue(planes[i].XCalc, true);

                    
                    twoThetaDeviation += (planes[i].XCalc - planes[i].peakFunction.X) * (planes[i].XCalc - planes[i].peakFunction.X);
                }
            }
            return (twoThetaDeviation + numericBoxWeight.Value / height) * 1000;// + 1 / hkWidth;
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
        numericBoxCameraLengthRange.Enabled = numericBoxCameraLengthStep.Enabled = checkBoxCameraLength.Checked;
        numericBoxWaveLengthRange.Enabled = numericBoxWaveLengthStep.Enabled = checkBoxWaveLength.Checked;
        numericBoxTauRange.Enabled = numericBoxTauStep.Enabled = checkBoxTau.Checked;
        numericBoxPhiRange.Enabled = numericBoxPhiStep.Enabled = checkBoxPhi.Checked;
        numericBoxFootPointXRange.Enabled = numericBoxPointXStep.Enabled = checkBoxPointX.Checked;
        numericBoxFootPointYRange.Enabled = numericBoxPointYStep.Enabled = checkBoxPointY.Checked;

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

        var cameraLengthRange = checkBoxCameraLengthGandlfi.Checked ? (int)numericUpDownCameraLengthRange.Value : 0;
        var pixSizeRange = checkBoxPixelSize.Checked ? (int)numericUpDownPixelSizeRange.Value : 0;
        var centerRange = checkBoxCenterPosition.Checked ? (int)numericUpDownCenterPositionRange.Value : 0;
        var tiltRange = checkBoxIPTilt.Checked ? (int)numericUpDownTiltRange.Value : 0;
        var radiusRange = checkBoxGandlfiRadius.Checked ? (int)numericUpDownGandolfiRadiusRange.Value : 0;

        int cycle = (int)numericUpDownIterationGandolfi.Value;

        Stopwatch sw = new Stopwatch(); sw.Start();

        long beforeTime = 0;

        double alpha1 = AtomStatic.CharacteristicXrayWavelength(42, Crystallography.XrayLine.Ka1);
        double alpha2 = AtomStatic.CharacteristicXrayWavelength(42, Crystallography.XrayLine.Ka2);

        Profile profile;
        for (int n = 0; n < cycle; n++)
        {
            

            var initialValue = new gandolfiValues(CameraLength1, PixX, PixY, DirectSpotPosition.X, DirectSpotPosition.Y, Tau, Phi, Radius);
            var results = new SortedList<double, gandolfiValues>();

            var parameters = new List<gandolfiValues>();
            //Center
            for (int p1 = -centerRange; p1 <= centerRange; p1++)
                for (int p2 = -centerRange; p2 <= centerRange; p2++)
                    parameters.Add(new gandolfiValues
                        (CameraLength1, PixX, PixY, DirectSpotPosition.X + p1 * centerStep, DirectSpotPosition.Y + p2 * centerStep, Tau, Phi, Radius));

            //pixelSize
            for (int p1 = -pixSizeRange; p1 <= pixSizeRange; p1++)
                for (int p2 = -pixSizeRange; p2 <= pixSizeRange; p2++)
                    parameters.Add(new gandolfiValues
                        (CameraLength1, PixX + p1 * pixSizeStep, PixY + p2 * pixSizeStep, DirectSpotPosition.X , DirectSpotPosition.Y , Tau, Phi, Radius));

            //cameralength, GandolfiRadius
            for (int p1 = -cameraLengthRange; p1 <= cameraLengthRange; p1++)
                for (int p2 = -radiusRange; p2 <= radiusRange; p2++)
                    parameters.Add(new gandolfiValues
                        (CameraLength1 + p1 * cameraLengthStep, PixX , PixY , DirectSpotPosition.X, DirectSpotPosition.Y, Tau, Phi, Radius + p2 * radiusStep));

            //Tilt, Tau
            for (int p1 = -tiltRange; p1 <= tiltRange; p1++)
                for (int p2 = -tiltRange; p2 <= tiltRange; p2++)
                    parameters.Add(new gandolfiValues
                        (CameraLength1, PixX , PixY , DirectSpotPosition.X, DirectSpotPosition.Y, Tau + p1 * tiltStep, Phi + p2 * tiltStep, Radius));

            int count = 0;
            foreach (var v in parameters)
            {
                FormMain.FormProperty.SkipEvent = true;

                CameraLength1 = v.CameraLength;
                DirectSpotPosition = new PointD(v.CenterX, v.CenterY);
                PixX = v.PixelSizeX;
                PixY = v.PixelSizeY;
                Tau = v.Tau;
                Phi = v.Phi;
                Radius = v.Radius;
                FormMain.FormProperty.SkipEvent = false;

                FormMain.FormProperty.DetectorParameters_Changed(sender, e);

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

            
            CameraLength1 = results.Values[0].CameraLength;
            DirectSpotPosition = new PointD(results.Values[0].CenterX, results.Values[0].CenterY);
            PixX = results.Values[0].PixelSizeX;
            PixY = results.Values[0].PixelSizeY;
            Tau = results.Values[0].Tau;
            Phi = results.Values[0].Phi;
            Radius = results.Values[0].Radius;
            if (CameraLength1 == initialValue.CameraLength &&
                DirectSpotPosition.X == initialValue.CenterX && DirectSpotPosition.Y == initialValue.CenterY &&
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

    private void radioButtonStandard_CheckedChanged(object sender, EventArgs e)
    {
        if (!(sender as RadioButton).Checked)
            return;
        var name = (sender as RadioButton).Name;
        Crystal crystal;
       
        if (name.Contains("Au"))
        {
            crystal = new Crystal((0.407825, 0.407825, 0.407825, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "Au", Color.Violet);
            crystal.AddAtoms("Au", 79, 0, 0, null, 0, 0, 0, 1, new DiffuseScatteringFactor());

        }
        else if(name.Contains("CeO2"))
        {
            crystal = new Crystal((0.5411102, 0.5411102, 0.5411102, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "CeO2", Color.Violet);
            crystal.AddAtoms("Ce", 58, 0, 0, null, 0, 0, 0, 1, new DiffuseScatteringFactor());
            crystal.AddAtoms("O", 8, 0, 0, null, 0.25, 0.25, 0.25, 1, new DiffuseScatteringFactor());


        }
        else if (name.Contains("LaB6"))
        {
            crystal = new Crystal((0.4157, 0.4157, 0.4157, Math.PI / 2, Math.PI / 2, Math.PI / 2), 517, "LaB6", Color.Violet);

            crystal.AddAtoms("La", 57, 0, 0, null, 0, 0, 0, 1, new DiffuseScatteringFactor());
            crystal.AddAtoms("B", 5, 0, 0, null, 0.1975, 0.5, 0.5, 1, new DiffuseScatteringFactor());
        }
        else if (name .Contains("Al2O3"))
        {
            crystal = new Crystal((0.47657, 0.47657, 1.301, Math.PI / 2, Math.PI / 2, Math.PI *2/ 3), 460, "Al2O3", Color.Violet);

            crystal.AddAtoms("Al", 13, 0, 0, null, 0, 0, 0.352, 1, new DiffuseScatteringFactor());
            crystal.AddAtoms("O", 8, 0, 0, null, 0.306, 0, 0.25, 1, new DiffuseScatteringFactor());
        }
        else
        {
            crystalControl1.Enabled = true;
            return;
        }

        crystalControl1.Crystal = crystal;
        crystalControl1.Enabled = false;
    }

    private void radioButtonDirectSpotMode_CheckedChanged(object sender, EventArgs e)
    {
        FormMain.FormProperty.DetectorCoordinates = DetectorCoordinates;

        var jp = Thread.CurrentThread.CurrentUICulture.ToString().Contains("ja");
        if (DetectorCoordinates== FormProperty.DetectorCoordinatesEnum.DirectSpot)
        {
            if(jp)
            {
                checkBoxCameraLength.Text = "カメラ長1";
                checkBoxPointX.Text = "ダイレクトスポット X";
                checkBoxPointY.Text = "ダイレクトスポット Y";
            }
            else
            {
                checkBoxCameraLength.Text = "Camera length 1";
                checkBoxPointX.Text = "Direct spot X";
                checkBoxPointY.Text = "Direct spot Y";
            }
        }
        else
        {
            if (jp)
            {
                checkBoxCameraLength.Text = "カメラ長2";
                checkBoxPointX.Text = "垂線の足 X";
                checkBoxPointY.Text = "垂線の足 Y";
            }
            else
            {
                checkBoxCameraLength.Text = "Camera length 2";
                checkBoxPointX.Text = "Foot X";
                checkBoxPointY.Text = "Foot Y";
            }

        }


    }

   
}
