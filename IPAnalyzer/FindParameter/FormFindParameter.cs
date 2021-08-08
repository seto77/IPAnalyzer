namespace IPAnalyzer
{
    using System;
    using System.Drawing;
    using System.Collections;
    using System.ComponentModel;
    using System.Windows.Forms;
    using System.Data;
    using System.IO;
    using System.Text;
    using System.Drawing.Drawing2D;
    using Crystallography;
    using System.Collections.Generic;
    using System.Threading;
    using Crystallography.Controls;
    using System.Threading.Tasks;
    using System.Linq;

    /// <summary>
    /// FormCLandWL の概要の説明です。
    /// </summary>
    public partial class FormFindParameter : System.Windows.Forms.Form
    {
        public FormCrystal formCrystal;
        int NumberOfDirection = 20;//計算する方向の数

        public int SelectedCrystalIndex = -1;
        public int SelectedPlaneIndex = -1;
        public bool IsPlaneSelected = false;

        public bool IsSkipTextChangeEvent = false;

        public float StartAngle;
        public double AngleScale;
        public double UpperX, LowerX;
        public double UpperY, LowerY;
        public double MaximalX, MinimalX;
        public double MaximalY, MinimalY;
        public Bitmap BmpMain, BmpIntensity, BmpAngle;
        public Graphics gMain, gAngle, gIntensity;
        public Point MouseRangeStart, MouseRangeEnd;
        public bool MouseRange = false;

        public bool IsBgPtSelected = false;
        public int SelectedBgPtIndex = -1;
        public int SelectedProfileIndex = -1;

        public double[] FilmDistance = new double[2];
        public double WaveLength, FilmDistanceDiscrepancy, AspectRatio, Ksi;

        public double FilmDistanceDev, WaveLengthDev, PixSizeXDev, PixSizeYDev, KsiDev;

        public int numSG;

        public Plane[] plane1, plane2;
        DiffractionProfile[] dp = new DiffractionProfile[2];
        public PeakFunction[] pf = new PeakFunction[2];
        public FormMain formMain;
        public static Crystal[] crystal = new Crystal[2];
        public static Crystal[] flexibleCrystal = new Crystal[2];

        public IntegralProperty IP = new IntegralProperty();

        enum DrawingMode { Primary, Secondary, Both }

        

        public FormFindParameter()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //

        }





        //ロードされたとき
        private void FormCLandWL_Load(object sender, System.EventArgs e)
        {
            //まずメインウィンドウのパラメータに置き換える。
            numericTextBoxPrimaryFilmDistance.Text = formMain.FormProperty.CameraLengthText;
            textBoxPixelSizeX.Value = formMain.FormProperty.numericBoxPixelSizeX.Value;
            textBoxPixelSizeY.Value = formMain.FormProperty.numericBoxPixelSizeY.Value;
            textBoxPixelKsi.Value= formMain.FormProperty.numericBoxPixelKsi.Value;
            textBoxWaveLength.Text = formMain.FormProperty.WaveLengthText;
            //numericTextBoxPrimaryFilmDistance.Text = formMain.formProperty.textBoxCameraLength.Text;
            textBoxTiltCorrectionPrimaryPhi.Value = formMain.FormProperty.numericBoxTiltPhi.Value;
            textBoxTiltCorrectionPrimaryTau.Value = formMain.FormProperty.numericBoxTiltTau.Value;
            numericalTextBoxPrimaryCenterPositionX.Value = numericTextBoxSecondaryCenterPositionX.Value = formMain.FormProperty.numericBoxDirectSpotPositionX.Value;
            numericTextBoxPrimaryCenterPositionY.Value = numericTextBoxSecondaryCenterPositionY.Value = formMain.FormProperty.numericBoxDirectSpotPositionY.Value;

            FilmDistance[0] = numericTextBoxPrimaryFilmDistance.Value;
            WaveLength = textBoxWaveLength.Value / 10;

            dp[0] = new DiffractionProfile();
            dp[0].ColorARGB = pictureBoxPattern1.BackColor.ToArgb();
            dp[0].OriginalProfile = null;
            dp[1] = new DiffractionProfile();
            dp[1].ColorARGB = pictureBoxPattern2.BackColor.ToArgb();
            dp[1].OriginalProfile = null;

            formCrystal = new FormCrystal();

            crystal[0] = new Crystal((0.5411102, 0.5411102, 0.5411102, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "CeO2",  Color.Violet);
            crystal[1] = new Crystal((0.5411102, 0.5411102, 0.5411102, Math.PI / 2, Math.PI / 2, Math.PI / 2), 523, "CeO2",  Color.Violet);
            flexibleCrystal[0] = new Crystal((0, 0, 0, 0, 0, 0), 0,  "", Color.Violet);
            flexibleCrystal[1] = new Crystal((0, 0, 0, 0, 0, 0), 0,  "", Color.Violet);
            flexibleCrystal[0].Plane = new List<Plane>();
            flexibleCrystal[1].Plane = new List<Plane>();

            formCrystal.CrystalChanged(crystal[0]);
            formCrystal.Visible = false;

            groupBoxSecondaryImage.AllowDrop = true;
            groupBoxPrimaryImage.AllowDrop = true;
            groupBoxParameter.AllowDrop = true;
           
        }
        //クローズされたとき
        private void FormFindParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonFindParameter.Checked = false;
        }

        
        private void FormFindParameter_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //まずメインウィンドウのパラメータに置き換える。
                numericTextBoxPrimaryFilmDistance.Text = formMain.FormProperty.CameraLengthText;
                textBoxPixelSizeX.Value = formMain.FormProperty.numericBoxPixelSizeX.Value;
                textBoxPixelSizeY.Value = formMain.FormProperty.numericBoxPixelSizeY.Value;
                textBoxPixelKsi.Value = formMain.FormProperty.numericBoxPixelKsi.Value;
                textBoxWaveLength.Text = formMain.FormProperty.WaveLengthText;
                textBoxTiltCorrectionSecondaryPhi.Value = textBoxTiltCorrectionPrimaryPhi.Value = formMain.FormProperty.numericBoxTiltPhi.Value;
                textBoxTiltCorrectionSecondaryTau.Value = textBoxTiltCorrectionPrimaryTau.Value = formMain.FormProperty.numericBoxTiltTau.Value;
                numericalTextBoxPrimaryCenterPositionX.Value = numericTextBoxSecondaryCenterPositionX.Value = formMain.FormProperty.numericBoxDirectSpotPositionX.Value;
                numericTextBoxPrimaryCenterPositionY.Value = numericTextBoxSecondaryCenterPositionY.Value = formMain.FormProperty.numericBoxDirectSpotPositionY.Value;
            }
        }

        private HorizontalAxis originalHorizontalAxis = HorizontalAxis.Angle;
        private bool IsConcentricMode = true;
        /// <summary>
        /// 直前の軸モード等を記憶したうえで、FindParameter用の軸モードにセットする
        /// </summary>
        private void setHorizontalMode()
        {
            if (formMain.FormProperty.radioButtonConcentric.Checked)
            {
                IsConcentricMode = true;
                if (formMain.FormProperty.radioButtonConcentricAngle.Checked)
                    originalHorizontalAxis = HorizontalAxis.Angle;
                else if (formMain.FormProperty.radioButtonConcentricLength.Checked)
                    originalHorizontalAxis = HorizontalAxis.Length;
                else if (formMain.FormProperty.radioButtonConcentricDspacing.Checked)
                    originalHorizontalAxis = HorizontalAxis.d;
            }
            else
            {
                IsConcentricMode = false;
                if (formMain.FormProperty.radioButtonRadialAngle.Checked)
                    originalHorizontalAxis = HorizontalAxis.Angle;
                else if(formMain.FormProperty.radioButtonRadialDspacing.Checked)
                    originalHorizontalAxis = HorizontalAxis.d;
            }

            formMain.FormProperty.radioButtonConcentric.Checked = true;
            formMain.FormProperty.radioButtonConcentricLength.Checked = true;
        }
        /// <summary>
        /// 直前の軸モードに戻す
        /// </summary>
        private void resetHorizontalMode()
        {
            if (IsConcentricMode)
            {
                formMain.FormProperty.radioButtonConcentric.Checked = true;
                if (originalHorizontalAxis == HorizontalAxis.Angle)
                    formMain.FormProperty.radioButtonConcentricAngle.Checked = true;
                else if (originalHorizontalAxis == HorizontalAxis.Length)
                    formMain.FormProperty.radioButtonConcentricLength.Checked = true;
                else if (originalHorizontalAxis == HorizontalAxis.d)
                    formMain.FormProperty.radioButtonConcentricDspacing.Checked = true;
            }
            else
            {
                formMain.FormProperty.radioButtonRadial.Checked = true;
                if (originalHorizontalAxis == HorizontalAxis.Angle)
                    formMain.FormProperty.radioButtonRadialAngle.Checked = true;
                else if (originalHorizontalAxis == HorizontalAxis.d)
                    formMain.FormProperty.radioButtonRadialDspacing.Checked = true;
            }
        }


        #region ピクチャーボックスでのマウス操作
        //マウスボタンが押されたとき
        private void pictureBoxMain_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            PointD pt = ConvToRealCoord(e.X, e.Y);
            //Diffractionモード
            if (e.Button == MouseButtons.Left && e.Clicks == 1 && checkBoxUseStandardCrystal.Checked && buttonExecuteRefinements.Enabled)
            { //左シングルクリックはPlaneを選択モードに
                SearchPt(e.X, crystal);
                if (SelectedCrystalIndex >= 0 && SelectedPlaneIndex >= 0)
                {
                    IsPlaneSelected = true;
                    return;
                }
            }
            else if (!checkBoxUseStandardCrystal.Checked)
            {

                if (dp == null || dp[0] == null || dp[1] == null) return;
                if (e.Button == MouseButtons.Left && e.Clicks == 1)
                {
                    SearchPt(e.X, flexibleCrystal);
                    if (SelectedCrystalIndex >= 0 && SelectedPlaneIndex >= 0)
                    {
                        IsPlaneSelected = true;
                        return;
                    }
                }
                if (e.Button == MouseButtons.Left & e.Clicks == 2)//何もないところでダブルクリックした場合
                {
                    int index = radioButton1.Checked ? 0 : 1;
                    Plane p = new Plane();
                    p.MillimeterCalc = pt.X;
                    PointD tempPt = ConvToDspacing(pt, FilmDistance[index]);
                    p.d = tempPt.X;
                    p.SerchOption = PeakFunctionForm.PseudoVoigt;
                    flexibleCrystal[index].Plane.Add(p);
                    flexibleCrystal[index].Plane.Sort();
                    for (int i = 0; i < flexibleCrystal[index].Plane.Count; i++)
                        flexibleCrystal[index].Plane[i].strHKL = "No." + (i+1).ToString();
                    InitializeCrystalPlane(false);
                    Fitting();
                    return;
                }
                if (e.Button == MouseButtons.Right & e.Clicks == 1)
                {
                    SearchPt(e.X, flexibleCrystal);
                    if (SelectedCrystalIndex >= 0 && SelectedPlaneIndex >= 0)
                    {
                        flexibleCrystal[SelectedCrystalIndex].Plane.RemoveAt(SelectedPlaneIndex);
                        flexibleCrystal[SelectedCrystalIndex].Plane.Sort();
                        for (int i = 0; i < flexibleCrystal[SelectedCrystalIndex].Plane.Count; i++)
                            flexibleCrystal[SelectedCrystalIndex].Plane[i].strHKL = "No." + (i+1).ToString();
                        InitializeCrystalPlane(false);
                        Fitting();
                        return;
                    }
                }
               
                //formFitting.SetCheckedListBoxPlanes(false);
            }

            if (e.Button == MouseButtons.Right)
            {
                MouseRange = true;
                MouseRangeStart = new Point(e.X, e.Y);
            }
        }


        private void pictureBoxMain_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {//マウスボタンがあがったとき
            InitializeCrystalPlane(false);

            if (IsPlaneSelected)
            {
                IsPlaneSelected = false;

                if (checkBoxUseStandardCrystal.Checked)
                {
                    flexibleCrystal[SelectedCrystalIndex].Plane.Sort();
                    for (int i = 0; i < flexibleCrystal[SelectedCrystalIndex].Plane.Count; i++)
                        flexibleCrystal[SelectedCrystalIndex].Plane[i].strHKL = "No." + (i + 1).ToString();
                }

                InitializeCrystalPlane(false);
                Fitting();
            }
            else if (MouseRange)
            {
                MouseRange = false;
                MouseRangeEnd = new Point(e.X, e.Y);
                if (Math.Abs(MouseRangeEnd.X - MouseRangeStart.X) < 2 || Math.Abs(MouseRangeEnd.Y - MouseRangeStart.Y) < 2)
                {//選択範囲が小さかったら  
                    //縮小
                    LowerX = LowerX * 1.5f - UpperX * 0.5f;
                    if (LowerX < 0) LowerX = 0;
                    UpperX = UpperX * 1.5f - LowerX * 0.5f;
                    if (UpperX > MaximalX) UpperX = MaximalX;
                    LowerY = (int)(LowerY * 1.5f - UpperY * 0.5f + 0.5f);
                    if (LowerY < 0) LowerY = 0;
                    UpperY = (int)(UpperY * 1.5f - LowerY * 0.5f + 0.5f);
                    if (UpperY > MaximalY) UpperY = MaximalY;
                    InitializeCrystalPlane(false);
                    Draw();
                }
                if (Math.Abs(MouseRangeEnd.X - MouseRangeStart.X) < 10 || Math.Abs(MouseRangeEnd.Y - MouseRangeStart.Y) < 10)
                {//中途半端に小さかったら
                    MouseRange = false;
                    pictureBoxMain.Refresh();
                    return;
                }
                else
                {
                    double xmax = ConvToRealCoord(Math.Max(MouseRangeStart.X, MouseRangeEnd.X), 1).X;
                    double xmin = ConvToRealCoord(Math.Min(MouseRangeStart.X, MouseRangeEnd.X), 1).X;
                    double ymin = ConvToRealCoord(1, Math.Max(MouseRangeStart.Y, MouseRangeEnd.Y)).Y;
                    double ymax = ConvToRealCoord(1, Math.Min(MouseRangeStart.Y, MouseRangeEnd.Y)).Y;
                    if (xmax > UpperX) xmax = UpperX;
                    if (xmin < LowerX) xmin = LowerX;
                    if (ymax > UpperY) ymax = UpperY;
                    if (ymin < LowerY) ymin = LowerY;

                    if (xmax - xmin < 0.05 || ymax - ymin < 3) return;
                    LowerX = xmin; UpperX = xmax; LowerY = ymin; UpperY = ymax;
                    Draw();
                }
            }
        }

        private void pictureBoxMain_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {//マウスが動いたとき
            PointD pt = ConvToRealCoord(e.X, e.Y);

            
            if (IsPlaneSelected && e.Button == MouseButtons.Left)//Plane選択モードのとき
            {
                if (checkBoxUseStandardCrystal.Checked)//通常結晶モードのとき
                {

                    if (SelectedCrystalIndex == 0)//Primaryを変更したとき
                        FilmDistance[0] = pt.X / Math.Tan(2 * Math.Asin(WaveLength / 2.0 / crystal[0].Plane[SelectedPlaneIndex].d));
                    else//Secondaryを選択したとき
                        FilmDistance[1] = pt.X / Math.Tan(2 * Math.Asin(WaveLength / 2.0 / crystal[1].Plane[SelectedPlaneIndex].d));
                    IsSkipTextChangeEvent = true;
                    numericTextBoxPrimaryFilmDistance.Value = FilmDistance[0];
                    IsSkipTextChangeEvent = false;

                    Draw();

                    return;
                }
                else//FlexibleCrystalのとき
                {
                    if (SelectedCrystalIndex == 1 || SelectedCrystalIndex == 0)
                    {
                        PointD tempPt = ConvToDspacing(pt, FilmDistance[SelectedCrystalIndex]);
                        flexibleCrystal[SelectedCrystalIndex].Plane[SelectedPlaneIndex].d = tempPt.X;
                        flexibleCrystal[SelectedCrystalIndex].Plane[SelectedPlaneIndex].MillimeterCalc = pt.X;
                        flexibleCrystal[SelectedCrystalIndex].Plane.Sort();
                        for (int i = 0; i < flexibleCrystal[SelectedCrystalIndex].Plane.Count; i++)
                            flexibleCrystal[SelectedCrystalIndex].Plane[i].strHKL = "No." + (i + 1).ToString();
                        Draw();
                    }
                    return;
                }
            }
            if (MouseRange)
            {//範囲選択モードのとき
                MouseRangeEnd = new Point(e.X, e.Y);
                pictureBoxMain.Refresh();
            }
        }
        #endregion

        /// <summary>
        /// 結晶面の限度を計算し、データグリッドビューの設定をおこなう
        /// </summary>
        /// <param name="DoesChangeCrystal"></param>
        private void InitializeCrystalPlane()
        {
            InitializeCrystalPlane(false);
        }
        /// <summary>
        /// 結晶面の限度を計算し、データグリッドビューの設定をおこなう
        /// </summary>
        /// <param name="DoesChangeCrystal"></param>
        private void InitializeCrystalPlane(bool DoesChangeCrystal)
        {
            if (MaximalX == 0) return;

            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)//通常結晶モードのとき
            {
                cry = crystal;
                for (int i = 0; i < 2; i++)
                {
                    double Maximal2Theta = Math.Atan(MaximalX / FilmDistance[i]);
                    double d_limit = WaveLength / 2 / Math.Sin(Maximal2Theta / 2);
                    if (d_limit > 0 && !double.IsInfinity(d_limit))
                        cry[i].SetPlanes(1000, d_limit, true, true, true, false, HorizontalAxis.Length, 0, 0);
                }
            }
            else//flexible結晶の場合
            {
                cry = flexibleCrystal;
            }

            //datagridviewを設定する
            int n = cry[0].Plane.Count < cry[1].Plane.Count ? 1 : 0;
            //すでにリストにある場合はチェックボックスの内容だけを保持して初期化
            if (DoesChangeCrystal == false)
            {
                if (dataGridView.Rows.Count > 0)
                {
                    if (dataGridView.Rows.Count > cry[n].Plane.Count)
                        for (int i = dataGridView.Rows.Count - 1; i >= cry[n].Plane.Count; i--)
                            dataGridView.Rows.RemoveAt(i);
                    else
                        for (int i = dataGridView.Rows.Count; i < cry[n].Plane.Count; i++)
                            dataGridView.Rows.Add(i + 1, cry[n].Plane[i].strHKL, false, 0, false, 0);
                }
                else
                    for (int i = 0; i < cry[n].Plane.Count; i++)
                        dataGridView.Rows.Add(i + 1, cry[n].Plane[i].strHKL, false, 0, false, 0);
            }
            else
            {
                dataGridView.Rows.Clear();
                for (int i = 0; i < cry[n].Plane.Count; i++)
                    dataGridView.Rows.Add(i + 1, cry[n].Plane[i].strHKL, false, 0, false, 0);
            }
        }
 
    


        #region 座標変換関係
        private PointF ConvToPicBoxCoord(double angle, double intensity)
        {//プロファイル座標をピクチャーボックスの座標系に変換
            if (UpperY - LowerY == 0) return new PointF(0, 0);
            return new PointF((float)((pictureBoxMain.Width - 40) / (UpperX - LowerX) * (angle - LowerX)) + 40,
                (float)(pictureBoxMain.Height - 20 - (pictureBoxMain.Height - 20) / (UpperY - LowerY) * (intensity - LowerY)));
        }
        private PointF ConvToPicBoxCoord(PointD p)
        {//ピクチャーボックスの座標系に変換
            if (UpperY - LowerY == 0) return new PointF(0, 0);
            return new PointF((float)((pictureBoxMain.Width - 40) / (UpperX - LowerX) * (p.X - LowerX)) + 40,
                (float)(pictureBoxMain.Height - 20 - (pictureBoxMain.Height - 20) / (UpperY - LowerY) * (p.Y - LowerY)));
        }
        private PointD ConvToRealCoord(int x, int y)
        {//マウス座標をオリジナルの座標系に変換
            return new PointD(
                (double)(x - 40) / (pictureBoxMain.Width - 40) * (UpperX - LowerX) + LowerX,
                (double)(pictureBoxMain.Height - y - 20) / (pictureBoxMain.Height - 20) * (UpperY - LowerY) + LowerY);
        }

        private PointD ConvToDspacing(PointD pt, double fd)
        {//プロファイル座標の横軸をd値に変換( 縦軸はそのまま)
                pt.X =   WaveLength / 2 / Math.Sin(Math.Atan2(pt.X,fd)/2) ;
            return pt;
        }

        #endregion

        #region 描画関係の関数
        //メインウィンドウ全体の描画

        public void Draw(object sender, System.EventArgs e)
        {
            Draw();
        }

        delegate void drawCallBack();
        public void Draw()
        {
            if (this.InvokeRequired)//別スレッドから呼び出されたとき Invokeして呼びなおす
            {
                drawCallBack d = new drawCallBack(Draw);
                this.Invoke(d, null);
                return;
            }

            if (pictureBoxMain.Width <= 0 || pictureBoxMain.Height <= 0)
                return;

            if (crystal[0] == null || dp[0] == null)
                return;

            if (crystal[0].Plane == null && crystal[1].Plane == null)
                InitializeCrystalPlane(false);

            BmpMain = new Bitmap(pictureBoxMain.Width, pictureBoxMain.Height);
            gMain = Graphics.FromImage(BmpMain);
            gMain.SmoothingMode = SmoothingMode.AntiAlias;
            gMain.Clear(Color.White);
            DrawPictureBoxes();
        }

        //ピクチャーボックスの描画
        private void DrawPictureBoxes()
        {
            if (flowLayoutPanelEachPeaks.Visible == false)
            {
                DrawProfile_Original();//オリジナルプロファイル
                DrawProfile_diffraction();//各種ピーク位置描画
                DrawProfile_Fitting();//フィッティング曲線
                DrawGradiation();//目盛りの描画

                pictureBoxMain.Image = BmpMain;
            }
            else
            {
                DrawEachPeaks();
            }
        }

        private List<GraphControl> graph= new List<GraphControl>();
        private void DrawEachPeaks()
        {
            //まず現在がPrimary(0)かSecondary(1)かを調べる
            int n = textBoxPrimaryFileName.Text == formMain.FilePath + formMain.FileName ? 0 : 1;
            if (n == 0 && formMain.SequentialImageMode && Ring.SequentialImageIntensities.Count >= 2)
                n = numericBoxPrimaryImageNum.ValueInteger == formMain.FormSequentialImage.SelectedIndex ? 0 : 1;
                

            if (dp[n].OriginalProfile == null) return;
            //次に必要なgraph数をカウント
            Crystal[] cry = checkBoxUseStandardCrystal.Checked ? crystal: flexibleCrystal;
            if (cry[0] == null || (cry[0].Plane == null && cry[1].Plane == null)) return;
            //描画対象の面をピックアップしリストをつくる
            List<int> drawPeakList=new List<int>();
            for (int i = 0; i < cry[n].Plane.Count; i++)
                if (cry[n].Plane[i].IsFittingChecked)
                    drawPeakList.Add(i);
            //現在のgraphが多かったら削除
            if (drawPeakList.Count < graph.Count)
            {
                for (int i = drawPeakList.Count; i < graph.Count; i++)
                    graph[i].Visible = false;
            }
            flowLayoutPanelEachPeaks.Refresh();
            //現在のgraphが少なかったら追加
            for (int i = graph.Count; i < drawPeakList.Count; i++)
            {
                GraphControl g = new GraphControl();
                graph.Add(g);
                g.AllowMouseOperation = checkBoxMouseOperation.Checked;
                g.GraphName = "";
                g.LineColor = System.Drawing.Color.Red;
                g.MousePositionVisible = false;
                g.Size = new System.Drawing.Size(240, 120);
                g.OriginPosition = new Point(0, 20);
                g.UseLineWidth = false;
                g.VerticalGradiationTextVisivle = false;
                flowLayoutPanelEachPeaks.Controls.Add(g);
            }
            Color s = Color.FromArgb(dp[n].ColorARGB.Value);
            Color c = Color.FromArgb((int)(s.R * 0.5), (int)(s.G * 0.5), (int)(s.B * 0.5));


            //dp[0].OriginalProfileから、描画範囲のProfileを切り取る+フィッティングカーブを生成
            PointD[] pt = dp[n].OriginalProfile.Pt.ToArray();
            Profile[] sourceProfile = new Profile[drawPeakList.Count];
            Profile[] fittigProfile = new Profile[drawPeakList.Count];
            PointD[] centerLine = new PointD[drawPeakList.Count];
            Profile[] backgroundProfile = new Profile[drawPeakList.Count];
            for (int i = 0; i < drawPeakList.Count; i++)
            {
                sourceProfile[i] = new Profile();
                fittigProfile[i] = new Profile();
                backgroundProfile[i] = new Profile();
                centerLine[i] = new PointD();
                sourceProfile[i].Color = s;
                sourceProfile[i].LineWidth = 4f;
                fittigProfile[i].Color = backgroundProfile[i].Color = c;
                fittigProfile[i].LineWidth = backgroundProfile[i].LineWidth = 2f;

                double theta = Math.Asin(WaveLength / 2 / cry[n].Plane[drawPeakList[i]].d);
                double Range = (double)numericUpDownSearchRange.Value / Math.Cos(theta);
                double startTheta = cry[n].Plane[drawPeakList[i]].MillimeterCalc - Range;
                double endTheta = cry[n].Plane[drawPeakList[i]].MillimeterCalc + Range;
                

                for (int j = 0; j < pt.Length && pt[j].X < endTheta + Range * 0.2; j++)
                    if (pt[j].X > startTheta - Range * 0.2)
                        sourceProfile[i].Pt.Add(pt[j]);

                PeakFunction pf = cry[n].Plane[drawPeakList[i]].peakFunction;
                
                if (!double.IsNaN(pf.X) && pf.Hk != 0)
                {
                    centerLine[i] = new PointD(cry[n].Plane[drawPeakList[i]].MillimeterCalc, pf.GetValue(cry[n].Plane[drawPeakList[i]].MillimeterCalc, false));
                    pf.RenewParameter();
                    for (double k = startTheta; k < endTheta; k += (endTheta - startTheta) / 300)
                        fittigProfile[i].Pt.Add(new PointD(k, pf.GetValue(k, false) + pf.B1 + pf.B2 * (k - pf.X)));
                    backgroundProfile[i].Pt.Add(new PointD(startTheta, pf.B1 + pf.B2 * (startTheta - pf.X)));
                    backgroundProfile[i].Pt.Add(new PointD(endTheta, pf.B1 + pf.B2 * (endTheta - pf.X)));
                }
            }

            for (int i = 0; i < drawPeakList.Count; i++)
            {
                graph[i].Visible = true;
                graph[i].GraphName = "(" + cry[n].Plane[drawPeakList[i]].h.ToString() + " " + cry[n].Plane[drawPeakList[i]].k.ToString() + " " + cry[n].Plane[drawPeakList[i]].l.ToString() + ")";
                graph[i].LineList = new PointD[] { centerLine[i] };
                graph[i].LineWidth = 2f;
                graph[i].LineColor = c;
                graph[i].DrawingRange = new RectangleD(sourceProfile[i].MinX, sourceProfile[i].MinY, sourceProfile[i].MaxX - sourceProfile[i].MinX, sourceProfile[i].MaxY - sourceProfile[i].MinY);

                graph[i].AddProfiles(new Profile[] { sourceProfile[i], fittigProfile[i], backgroundProfile[i] }, graph[i].DrawingRange);
            }
            
        }

        //オリジナルプロファイルの描画
        private void DrawProfile_Original()
        {
            Pen pen;
            PointD[] pt;

            if (dp[0].OriginalProfile != null)
            {
                pen = new Pen(Color.FromArgb(dp[0].ColorARGB.Value), 1);
                pt = dp[0].OriginalProfile.Pt.ToArray();
                for (int i = 0; i < pt.Length - 1; i++)
                    gMain.DrawLine(pen, ConvToPicBoxCoord(pt[i]), ConvToPicBoxCoord(pt[i + 1]));
            }

            if (dp[1].OriginalProfile != null)
            {
                pen = new Pen(Color.FromArgb(dp[1].ColorARGB.Value), 1);
                pt = dp[1].OriginalProfile.Pt.ToArray();
                for (int i = 0; i < pt.Length - 1; i++)
                    gMain.DrawLine(pen, ConvToPicBoxCoord(pt[i]), ConvToPicBoxCoord(pt[i + 1]));
            }
        }

        //結晶の計算上のピーク位置の描画
        private void DrawProfile_diffraction()
        {
            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)
                cry = crystal;
            else
                cry = flexibleCrystal;

            if (cry[0] == null || (cry[0].Plane == null && cry[1].Plane == null)) return;
            Font font = new Font("Tahoma", 8);
            Pen pen;
            PointF pt;

            for (int i = 0; i < 2; i++)
                if (dp[i].OriginalProfile != null)
                {
                    //字の部分
                    float JustBeforeX = -10;
                    int shiftY = 40;
                    for (int j = 0; j < cry[i].Plane.Count; j++)
                    {
                        Brush br = new SolidBrush(Color.FromArgb(dp[i].ColorARGB.Value));
                        cry[i].Plane[j].MillimeterCalc = Math.Tan(2 * Math.Asin(WaveLength / 2 / cry[i].Plane[j].d)) * FilmDistance[i];
                        pt = ConvToPicBoxCoord(cry[i].Plane[j].MillimeterCalc, UpperY);
                        if (pt.X - JustBeforeX < 6)
                        {//字がかぶらないようにするための措置
                            pt.Y += shiftY;
                            gMain.DrawString("  " + cry[i].Plane[j].strHKL, font, br, pt, new StringFormat(StringFormatFlags.DirectionVertical));
                            shiftY += 40;
                        }
                        else
                        {
                            gMain.DrawString(cry[i].Plane[j].strHKL, font, br, pt, new StringFormat(StringFormatFlags.DirectionVertical));
                            shiftY = 40;
                        }
                        JustBeforeX = pt.X;
                        //ここから線の部分
                        if (i == SelectedCrystalIndex && j == SelectedPlaneIndex)
                            pen = new Pen(Color.FromArgb(dp[i].ColorARGB.Value), 3);
                        else
                            pen = new Pen(Color.FromArgb(dp[i].ColorARGB.Value), 1);
                        gMain.DrawLine(pen, ConvToPicBoxCoord(cry[i].Plane[j].MillimeterCalc, LowerY), ConvToPicBoxCoord(cry[i].Plane[j].MillimeterCalc, UpperY));
                    }
                }
        }

        //フィッティング曲線の描画
        private void DrawProfile_Fitting()
        {
            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)
                cry = crystal;
            else
                cry = flexibleCrystal;

            if (cry[0] == null || (cry[0].Plane == null && cry[1].Plane == null)) return;
            double step = (ConvToRealCoord(1, 0).X - ConvToRealCoord(0, 0).X)/3;

            for (int n = 0; n < 2; n++)
                if (dp[n].OriginalProfile != null)
                {
                    Color s = Color.FromArgb(dp[n].ColorARGB.Value);
                    Color c = Color.FromArgb((int)(s.R * 0.5), (int)(s.G * 0.5), (int)(s.B * 0.5));
                    Pen pen = new Pen(c, 2);
                    for (int i = 0; i < cry[n].Plane.Count; i++)
                    {
                        if (cry[n].Plane != null && cry[n].Plane[i].peakFunction != null)
                        {
                            double theta = Math.Asin(WaveLength / 2 / cry[n].Plane[i].d);
                            double Range = (double)numericUpDownSearchRange.Value /Math.Cos(theta) ;
                            double startTheta = cry[n].Plane[i].MillimeterCalc - Range;
                            double endTheta = cry[n].Plane[i].MillimeterCalc + Range;

                            PeakFunction pf = cry[n].Plane[i].peakFunction;
                      //      try
                            {
                                for (double k = startTheta; k < endTheta; k += step)
                                    if (!double.IsNaN(pf.X) && pf.Hk != 0)
                                    {
                                        if (k == startTheta)
                                            pf.RenewParameter();

                                        var pt1 = ConvToPicBoxCoord(k, pf.GetValue(k, false) + pf.B1 + pf.B2 * (k - pf.X));
                                        var pt2 = ConvToPicBoxCoord(k + step, pf.GetValue(k + step, false) + pf.B1 + pf.B2 * (k - pf.X + step));
                                        if (!double.IsNaN(pt1.Y))
                                        {

                                            gMain.DrawLine(pen, pt1, pt2);

                                            pt1 = ConvToPicBoxCoord(k, pf.B1 + pf.B2 * (k - pf.X));
                                            pt2 = ConvToPicBoxCoord(k + step, pf.B1 + pf.B2 * (k + step - pf.X));

                                            gMain.DrawLine(pen, pt1, pt2);
                                        }
                                    }
                            }
                       //     catch { }
                        }
                    }
                }
        }

        //目盛りを描画する部分
        private void DrawGradiation()
        {
            gMain.FillRectangle(Brushes.White, 0, 0, 40, pictureBoxMain.Height);
            gMain.FillRectangle(Brushes.White, 0, pictureBoxMain.Height - 20, pictureBoxMain.Width, pictureBoxMain.Height);

         
            float AngleGradiation = 1;//ここより角度目盛りの描画
            double d = (UpperX - LowerX);
            int maxDivisionNumber = (pictureBoxMain.Width - 40) / (d > 0.1 ? 40 : 60) + 1;
            if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
            double unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));

            if (d / unit < maxDivisionNumber) AngleGradiation = (float)unit;
            else if (d / unit / 2 < maxDivisionNumber) AngleGradiation = (float)unit * 2;
            else if (d / unit / 5 < maxDivisionNumber) AngleGradiation = (float)unit * 5;
            else if (d / unit / 10 < maxDivisionNumber) AngleGradiation = (float)unit * 10;

            Pen pen = new Pen(Brushes.Black, 1);

            gMain.DrawLine(pen, 40, pictureBoxMain.Height - 20, pictureBoxMain.Width, pictureBoxMain.Height - 20);
            Font strFont = new Font(new FontFamily("tahoma"), 8);
            for (int i = (int)(LowerX / AngleGradiation) + 1; i < UpperX / AngleGradiation; i++)
            {
                pen = new Pen(Brushes.Black, 1);
                gMain.DrawLine(pen, ConvToPicBoxCoord(i * AngleGradiation, 0).X, pictureBoxMain.Height - 20, ConvToPicBoxCoord(i * AngleGradiation, 0).X, pictureBoxMain.Height - 16);
                gMain.DrawString((i * AngleGradiation).ToString(), strFont, Brushes.Black, ConvToPicBoxCoord(i * AngleGradiation, 0).X - 2, pictureBoxMain.Height - 16);
                pen = new Pen(Brushes.LightGray, 1);
            }

           /* float IntensityGradiation;//ここより強度目盛りの描画
            d = (UpperY - LowerY) / Math.Pow(10, (int)Math.Log10(UpperY - LowerY));
            if (d < 1.6) IntensityGradiation = (float)(Math.Pow(10, (int)Math.Log10(UpperY - LowerY) - 1));
            else if (d < 3.2) IntensityGradiation = (float)(2 * Math.Pow(10, (int)Math.Log10(UpperY - LowerY) - 1));
            else if (d < 8.0) IntensityGradiation = (float)(5 * Math.Pow(10, (int)Math.Log10(UpperY - LowerY) - 1));
            else IntensityGradiation = (float)(10 * Math.Pow(10, (int)Math.Log10(UpperY - LowerY) - 1));*/

            float IntensityGradiation = 1;//ここより角度目盛りの描画
            d = (UpperY - LowerY);
            maxDivisionNumber = (pictureBoxMain.Height - 20) / 30 + 1;
            if (maxDivisionNumber < 1 || double.IsNaN(maxDivisionNumber)) return;
            unit = Math.Pow(10, Math.Floor(Math.Log10(d / maxDivisionNumber)));
            if (d / unit < maxDivisionNumber) IntensityGradiation = (float)unit;
            else if (d / unit / 2 < maxDivisionNumber) IntensityGradiation = (float)unit * 2;
            else if (d / unit / 5 < maxDivisionNumber) IntensityGradiation = (float)unit * 5;
            else if (d / unit / 10 < maxDivisionNumber) IntensityGradiation = (float)unit * 10;

            pen = new Pen(Brushes.Black, 1);
            gMain.DrawLine(pen, 40, 0, 40, pictureBoxMain.Height - 20);
            for (int i = (int)(LowerY / IntensityGradiation) + 1; i < UpperY / IntensityGradiation; i++)
            {
                pen = new Pen(Brushes.Black, 1);
                gMain.DrawLine(pen, 32, ConvToPicBoxCoord(0, i * IntensityGradiation).Y, 40, ConvToPicBoxCoord(0, i * IntensityGradiation).Y);
                gMain.DrawString((i * IntensityGradiation).ToString(), strFont, Brushes.Black, 0, ConvToPicBoxCoord(0, i * IntensityGradiation).Y - 6);
                pen = new Pen(Brushes.LightGray, 1);


            }
        }
        #endregion

        private void SetDrawRange(bool ResetCurrentRange)
        {
            MinimalX = 0;
            MaximalX = double.NegativeInfinity;
            MinimalY = 0;
            MaximalY = double.NegativeInfinity;

            for (int n = 0; n < dp.Length; n++)
                if (dp[n].OriginalProfile != null && dp[n].OriginalProfile.Pt.Count > 0)
                {
                    if (MaximalX < dp[n].OriginalProfile.Pt[dp[n].OriginalProfile.Pt.Count - 1].X)
                        MaximalX = dp[n].OriginalProfile.Pt[dp[n].OriginalProfile.Pt.Count - 1].X;
                    for (int i = 0; i < dp[n].OriginalProfile.Pt.Count; i++)
                    {
                        if (MaximalY < dp[n].OriginalProfile.Pt[i].Y)
                            MaximalY = dp[n].OriginalProfile.Pt[i].Y;
                    }
                }
            MaximalY *= 1.1;
            if (ResetCurrentRange || UpperX > MaximalX)
                UpperX = MaximalX;
            if (ResetCurrentRange || LowerX < MinimalX)
                LowerX = MinimalX;
            if (ResetCurrentRange || UpperY > MaximalY)
                UpperY = MaximalY;
            if (ResetCurrentRange || LowerY < MinimalY)
                LowerY = MinimalY;
        }
      

        #region マウスクリック位置に近い回折線、Bg点を返す関数群

        //もっともdに近いcry.planeの要素番号を返す。その差がdev以下が必須条件
        public void SearchPt(int MousePointX, Crystal[] cry)
        {
            if (crystal[0] == null || (crystal[0].Plane == null && crystal[1].Plane == null)) return;

            double temp = double.PositiveInfinity;
            SelectedPlaneIndex = SelectedCrystalIndex = -1;
            double theta;

            for (int j = 0; j < 2; j++)
                if (dp[j].OriginalProfile != null)
                {
                    double dev = Math.Atan((ConvToRealCoord(MousePointX, 0).X - ConvToRealCoord(MousePointX - 5, 0).X) / FilmDistance[j]);
                    double x = Math.Atan(ConvToRealCoord(MousePointX, 0).X / FilmDistance[j]);
                    for (int i = 0; i < cry[j].Plane.Count; i++)
                    {
                        theta = Math.Asin(WaveLength / 2 / cry[j].Plane[i].d) * 2;
                        if (Math.Abs(x - theta) < temp && Math.Abs(x - theta) < dev)
                        {
                            temp = Math.Abs(x - theta);
                            SelectedPlaneIndex = i;
                            SelectedCrystalIndex = j;
                        }
                    }
                }
        }

        #endregion

        //pictureBoxの再描画時に呼び出される
        private void pictureBoxMain_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (MouseRange)
            {
                Pen pen = new Pen(Brushes.Gray);
                pen.DashStyle = DashStyle.Dash;
                e.Graphics.DrawRectangle(pen, Math.Min(MouseRangeStart.X, MouseRangeEnd.X), Math.Min(MouseRangeStart.Y, MouseRangeEnd.Y),
                    Math.Abs(MouseRangeStart.X - MouseRangeEnd.X), Math.Abs(MouseRangeStart.Y - MouseRangeEnd.Y));
            }
        }

        delegate void FittingCallBack();
        double initialHK = -1;

        /// <summary>
        /// Fitting時に使用する半値幅のパラメーター
        /// </summary>
        double[] hk_theta = new double[2];
        /// <summary>
        /// Fitting時に使用する半値幅のパラメーター
        /// </summary>
        double[] hk_a = new double[2];
        /// <summary>
        /// Fitting処理
        /// </summary>
        private void Fitting()
        {
            if (this.InvokeRequired)//別スレッドから呼び出されたとき Invokeして呼びなおす
            {
                FittingCallBack d = new FittingCallBack(Fitting);
                this.Invoke(d, null);
                return;
            }

            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)
                cry = crystal;
            else
                cry = flexibleCrystal;

            if (cry[0] == null || (cry[0].Plane == null && cry[1].Plane == null)) return;
            int i, j;
            double range = (double)numericUpDownSearchRange.Value;

            for (i = 0; i < 2; i++)

                if (dp[i].OriginalProfile != null)
                {
                   PointD[] pt = dp[i].OriginalProfile.Pt.ToArray();
                    //いったん初期化
                   for (j = 0; j < cry[i].Plane.Count; j++)
                   {
                       cry[i].Plane[j].DecompositionGroup = -1;
                       if (checkBoxUseStandardCrystal.Checked)//標準結晶を使う場合
                       {
                           cry[i].Plane[j].MillimeterCalc = Math.Tan(2 * Math.Asin(WaveLength / 2 / cry[i].Plane[j].d)) * FilmDistance[i];
                           cry[i].Plane[j].MillimeterObs = double.NaN;
                       }
                       else//使わない場合
                       {
                         //  cry[i].Plane[j].MillimeterCalc　= 

                       }
                       cry[i].Plane[j].peakFunction = new PeakFunction();
                       double twoTheta = 2 * Math.Asin(WaveLength / 2 / cry[i].Plane[j].d);
                       if (i == 0)
                           cry[i].Plane[j].peakFunction.range = (double)numericUpDownSearchRange.Value / Math.Cos(twoTheta / 2);
                       else
                           cry[i].Plane[j].peakFunction.range = (double)numericUpDownSearchRange.Value / Math.Cos(twoTheta / 2) * FilmDistance[1] / FilmDistance[0];

                       /*if (initialHK < 0 || double.IsNaN(initialHK))
                           cry[i].Plane[j].peakFunction.Hk =　 cry[i].Plane[j].peakFunction.range / 4;
                       else
                           cry[i].Plane[j].peakFunction.Hk = initialHK;*/
                       if (hk_theta[i] == 0 || hk_theta[i] > Math.PI / 4 || hk_a[i] >= 0)
                           cry[i].Plane[j].peakFunction.Hk = cry[i].Plane[j].peakFunction.range / 2;
                       else
                           cry[i].Plane[j].peakFunction.Hk = Math.Tan(hk_theta[i]) * cry[i].Plane[j].MillimeterCalc - hk_a[i] / Math.Cos(hk_theta[i]);

                       cry[i].Plane[j].peakFunction.X = cry[i].Plane[j].MillimeterCalc;
                       cry[i].Plane[j].peakFunction.SerchPeakTop = false;

                   }

                    int LastDecompositionGroup = -1;
                    List<int> count = new List<int>();
                    List<PeakFunction> listPF = new List<PeakFunction>();
                    int LastNumber = -1;
                    int n = 0;
                    for (j = 0; j < cry[i].Plane.Count; j++)
                    {
                        //先ず分離対象となるピークを検出する。対象となるのはピークとピークがSerchRangeの範囲で重なり合うもの
                        if (this.Enabled == true)
                        {
                            if (LastDecompositionGroup == -1)//もしまだ何のグループにも属していなかったら
                            {
                                listPF.Add(cry[i].Plane[j].peakFunction);
                                LastDecompositionGroup = j;
                                LastNumber = j;
                                n++;
                            }
                            //もし前回のグループに属していたら
                            else if (checkBoxPeakDecomposition.Checked &&
                                Math.Abs(cry[i].Plane[j].MillimeterCalc - cry[i].Plane[LastNumber].MillimeterCalc) < range * 2)
                            {
                                listPF.Add(cry[i].Plane[j].peakFunction);
                                LastNumber = j;
                                n++;
                            }
                            else
                            {
                                listPF.Add(cry[i].Plane[j].peakFunction);
                                count.Add(n);
                                LastNumber = j;
                                n = 1;
                            }
                        }
                    }
                    //ループ終了後の処理
                    count.Add(n);
                    n = 0;
                    PeakFunction[][] listPfTemp = new PeakFunction[count.Count][];
                    for (int k = 0; k < count.Count; k++)
                    {
                        listPfTemp[k] = new PeakFunction[count[k]];
                        for (j = 0; j < count[k]; j++)
                        {
                            listPfTemp[k][j] = listPF[n];
                            n++;
                        }
                    }

                    double[] residual = new double[count.Count];
                    
                    for(int k= 0 ; k< count.Count; k++)
                    //Parallel.For(0, count.Count, k =>
                    {
                        residual[k] = FittingPeak.FitMultiPeaksThread(pt, true, (double)numericUpDownThresholdOfPeak.Value, ref listPfTemp[k]);
                    }
                    //);

                    for (j = 0; j < cry[i].Plane.Count; j++)
                        cry[i].Plane[j].MillimeterObs = cry[i].Plane[j].peakFunction.X;

                    List<PointD> hk= new List<PointD>();
                    List<double> x = new List<double>();
                    List<double> y = new List<double>();
                    for (int k = 0; k < listPfTemp.Length; k++)
                    {
                        if (residual[k] < 0.01)
                            for (j = 0; j < count[k]; j++)
                            {
                                hk.Add(new PointD(listPfTemp[k][j].X, listPfTemp[k][j].Hk));
                                x.Add(listPfTemp[k][j].X);
                                y.Add(listPfTemp[k][j].Hk);

                            
                            }
                    }
                    
                    Statistics.LineFitting(hk.ToArray(), ref hk_theta[i], ref hk_a[i]);
                    
                }
            //ピーク分離フィッティングモード終了

            RefreshDatagridView();
            Draw();

        }
        

        private void RefreshDatagridView()
        {
            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)
                cry = crystal;
            else
                cry = flexibleCrystal;

            int length = Math.Max(cry[0].Plane.Count, cry[1].Plane.Count);
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < length; j++)
                    if (j < cry[i].Plane.Count)
                    {
                            if (double.IsNaN(cry[i].Plane[j].MillimeterObs) || cry[i].Plane[j].MillimeterObs == 0 ||
                            (backgroundWorkerRefine.IsBusy && !(bool)dataGridView.Rows[j].Cells[2 + i * 2].Value)
                            )
                                dataGridView.Rows[j].Cells[3 + i * 2].Value = "-";
                            else
                                dataGridView.Rows[j].Cells[3 + i * 2].Value = cry[i].Plane[j].MillimeterObs.ToString("f3");
                    }
                    else
                        dataGridView.Rows[j].Cells[3 + i * 2].Value = "--";
        }
        private void textBoxNumOnly_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if ((e.KeyChar < '.' || e.KeyChar > '9') && e.KeyChar != '\b' && e.KeyChar != 3 && e.KeyChar != 22)
                e.Handled = true;
        }

        #region カラーダイアログ関連
        private void pictureBoxPattern1_Click(object sender, EventArgs e)
        {
            if (dp[0] != null && crystal != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = pictureBoxPattern1.BackColor;
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;
                colorDialog.SolidColorOnly = false;
                colorDialog.ShowHelp = true;
                colorDialog.ShowDialog();
                pictureBoxPattern1.BackColor = colorDialog.Color;
                dp[0].ColorARGB = colorDialog.Color.ToArgb();
                Draw();
            }
        }

        private void pictureBoxPattern2_Click(object sender, EventArgs e)
        {
            if (dp[1] != null && crystal != null)
            {
                ColorDialog colorDialog = new ColorDialog();
                colorDialog.Color = pictureBoxPattern2.BackColor;
                colorDialog.AllowFullOpen = true;
                colorDialog.AnyColor = true;
                colorDialog.SolidColorOnly = false;
                colorDialog.ShowHelp = true;
                colorDialog.ShowDialog();
                pictureBoxPattern2.BackColor = colorDialog.Color;
                dp[1].ColorARGB = colorDialog.Color.ToArgb();
                Draw();
            }
        }
        #endregion

        private void buttonSetStandardCrystal_Click(object sender, EventArgs e)
        {
            if (checkBoxUseStandardCrystal.Checked)
            {
                if (!formCrystal.Visible)
                {
                    //formCrystal = new FormCrystal();
                    formCrystal.formFindParameter = this;
                    formCrystal.Show(this);
                    formCrystal.CrystalChanged(crystal[0]);
                    formCrystal.Visible = true;
                }
                else
                {
                    formCrystal.Visible =false;
                }
            }
           
        }

        //CrystalParameterチェックボックス変更
        private void checkBoxShowCrystalParameter_CheckedChanged(object sender, EventArgs e)
        {
            buttonExecuteRefinements.Enabled = checkBoxUseStandardCrystal.Checked;
            buttonGetWaveLengthFromWholePattern.Enabled = checkBoxUseStandardCrystal.Checked;
            flowLayoutPanel1.Visible = !checkBoxUseStandardCrystal.Checked;
            InitializeCrystalPlane(true);
            Fitting();
            
        }

        public void CrystalChanged(Crystal c)
        {
            crystal[0] = new Crystal((c.A, c.B, c.C, c.Alpha, c.Beta, c.Gamma), c.Symmetry.SeriesNumber, c.Name,  pictureBoxPattern1.BackColor);
            crystal[1] = new Crystal((c.A, c.B, c.C, c.Alpha, c.Beta, c.Gamma), c.Symmetry.SeriesNumber, c.Name,  pictureBoxPattern1.BackColor);
            InitializeCrystalPlane(true);
            Fitting();
        }


        //ファイルを開く
        private void buttonOpenPrimaryImage_Click(object sender, EventArgs e)
        {
            //ファイルを選択
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ImageIO.FilterString;
            if (dlg.ShowDialog() == DialogResult.OK)
                formMain.ReadImage(dlg.FileName);
            else
                return;
            textBoxPrimaryFileName.Text = dlg.FileName;
            if (formMain.SequentialImageMode && Ring.SequentialImageIntensities.Count >= 2)
            {
                selectSequentialImageNumber();
                numericBoxPrimaryImageNum.Value = formMain.FormSequentialImage.SelectedIndex;
            }
            if (dlg.FileName == "")
                dp[0].OriginalProfile = null;
        }
        private void buttonClearPrimaryImage_Click(object sender, EventArgs e)
        {
            textBoxPrimaryFileName.Text = "";
            dp[0].OriginalProfile = null;
        }

        private void buttonOpenSecondaryImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = ImageIO.FilterString;
            if (dlg.ShowDialog() == DialogResult.OK)
                formMain.ReadImage(dlg.FileName);
            else
                return;
            textBoxSecondaryFileName.Text = dlg.FileName;

            if (formMain.SequentialImageMode && Ring.SequentialImageIntensities.Count >= 2)
            {
                selectSequentialImageNumber();
                numericBoxSecondaryImageNum.Value = formMain.FormSequentialImage.SelectedIndex;
            }

            if (dlg.FileName == "")
                dp[1].OriginalProfile = null;
        }
        private void buttonClearSecondaryImage_Click(object sender, EventArgs e)
        {
            textBoxSecondaryFileName.Text = "";
            dp[1].OriginalProfile = null;
        }

        private void selectSequentialImageNumber()
        {
            formMain.toolStripButtonImageSequence.Checked = false;
            var formOption = new FormFindParameterOption1();
            formOption.FormMain = formMain;
            //formOption.Location = new Point(this.Location.X + 30, this.Location.Y + 30);
            formOption.ShowDialog();

            return;
        }

        private void textBoxPrimaryCenterPositionX_DoubleClick(object sender, EventArgs e)
        {
            numericalTextBoxPrimaryCenterPositionX.Value = formMain.FormProperty.numericBoxDirectSpotPositionX.Value;
            numericTextBoxPrimaryCenterPositionY.Value = formMain.FormProperty.numericBoxDirectSpotPositionY.Value;
        }

        private void textBoxSecondaryCenterPositionX_DoubleClick(object sender, EventArgs e)
        {
            numericTextBoxSecondaryCenterPositionX.Value = formMain.FormProperty.numericBoxDirectSpotPositionX.Value;
            numericTextBoxSecondaryCenterPositionY.Value = formMain.FormProperty.numericBoxDirectSpotPositionY.Value;
        }

        //Primaryのプロファイルゲットボタン
        private void buttonPrimaryGetProfile_Click(object sender, EventArgs e)
        {
            setHorizontalMode();

            this.Enabled = false;
 //           if (formMain.FilePath + formMain.FileName != textBoxPrimaryFileName.Text)
            SetImage(true);
            SetInitialIntegralProperty(true, false);
            //設定したIPにしたがってプロファイルをげっと
            dp[0].OriginalProfile = Ring.GetProfile(IP);
            //dp[0].SetSmoothingAndBackGround();
            numericTextBoxPrimaryFilmDistance_TextChanged(new object(), new EventArgs());
            SetDrawRange(true);

            this.Enabled = true;
            InitializeCrystalPlane(false);
            Draw();
            Fitting();

            resetHorizontalMode();
        }

        //Secondaryのプロファイルゲットボタン
        private void buttonSecondaryGetProfile_Click(object sender, EventArgs e)
        {
            setHorizontalMode();

            this.Enabled = false;
     //       if (formMain.FilePath + formMain.FileName != textBoxSecondaryFileName.Text)
                SetImage(false);
            SetInitialIntegralProperty(false, false);

            //設定したIPにしたがってプロファイルをげっと
            dp[1].OriginalProfile = Ring.GetProfile(IP);
            //dp[1].SetSmoothingAndBackGround();
            numericTextBoxPrimaryFilmDistance_TextChanged(new object(), new EventArgs());
            SetDrawRange(true);

            this.Enabled = true;
            InitializeCrystalPlane(false);
            Draw();
            Fitting();

            resetHorizontalMode();
        }


        public List<bool> IsSpotsPrimary = new List<bool>(), IsSpotsSecondary = new List<bool>();//画像のSpots情報

        /// <summary>
        /// メインウィンドウにfilenameを読み込ませます。
        /// 同時に画像の幅、高さをIPに設定します。マスク情報も設定します。
        /// </summary>
        /// <param name="filename"></param>
        public void SetImage(bool isPrimary)
        {
            //sequentialImageの時の対応
            string fileNamePrimary = textBoxPrimaryFileName.Text;
            int numPrimary = numericBoxPrimaryImageNum.ValueInteger;
            
            string fileNameSecondary = textBoxSecondaryFileName.Text;
            int numSecondary = numericBoxSecondaryImageNum.ValueInteger;

            string fileName = isPrimary ? fileNamePrimary : fileNameSecondary;
            int num = isPrimary ? numPrimary : numSecondary;

            //読み込む前に現在のSpots情報を保存しておく
            if (formMain.FileName !=null && formMain.FileName != "")
            {
                if (fileNamePrimary.EndsWith(formMain.FileName) && formMain.FormSequentialImage.SelectedIndex == num)
                {
                    IsSpotsPrimary.Clear();
                    for (int i = 0; i < Ring.IsSpots.Count; i++)
                        IsSpotsPrimary.Add(Ring.IsSpots[i]);
                }
                else if (fileNameSecondary.EndsWith(formMain.FileName) && formMain.FormSequentialImage.SelectedIndex == num)
                {
                    IsSpotsSecondary.Clear();
                    for (int i = 0; i < Ring.IsSpots.Count; i++)
                        IsSpotsSecondary.Add(Ring.IsSpots[i]);
                }
            }

            if (formMain.FilePath + formMain.FileName != fileName)
                formMain.ReadImage(fileName);

            //sequentialImageの時の対応
            if (num >= 0)
                formMain.FormSequentialImage.SelectedIndex = num;

            formMain.SetIntegralProperty();

            //IsSpotsが設定されたときだけ以下の処理をする
            if (fileNamePrimary.EndsWith(formMain.FileNameSub) && IsSpotsPrimary != null && IsSpotsPrimary.Count == Ring.IsSpots.Count && formMain.FormSequentialImage.SelectedIndex == num)
            {
                Ring.IsSpots.Clear();
                for (int i = 0; i < IsSpotsPrimary.Count; i++)
                    Ring.IsSpots.Add(IsSpotsPrimary[i]);
            }
            else if (fileNameSecondary.EndsWith(formMain.FileName) && IsSpotsSecondary != null && IsSpotsSecondary.Count == Ring.IsSpots.Count && formMain.FormSequentialImage.SelectedIndex == num)
            {
                Ring.IsSpots.Clear();
                for (int i = 0; i < IsSpotsSecondary.Count; i++)
                    Ring.IsSpots.Add(IsSpotsSecondary[i]);
            }
            formMain.SetMask();

            IP.SrcWidth = formMain.IP.SrcWidth;
            IP.SrcHeight = formMain.IP.SrcHeight;
            formMain.Draw();
        }

        /// <summary>
        /// このフォームで設定されているInitial波長、ピクセルサイズ関係、TiltCorrectionなどをIPにセットします。
        /// </summary>
        public void SetInitialIntegralProperty(bool IsPrimary, bool resetIntegralRegion)
        {
            IP.SrcWidth = formMain.IP.SrcWidth;
            IP.SrcHeight = formMain.IP.SrcHeight;

            IP.WaveLength = textBoxWaveLength.Value / 10;
            IP.PixSizeX = textBoxPixelSizeX.Value;
            IP.PixSizeY = textBoxPixelSizeY.Value;
            IP.ksi = textBoxPixelKsi.RadianValue;
            IP.phi = textBoxTiltCorrectionPrimaryPhi.RadianValue;
            IP.tau = textBoxTiltCorrectionPrimaryTau.RadianValue;

            IP.SpericalRadiusInverse = numericalTextBoxSphericalRadius.Value/1000;

            IP.ConcentricMode = true;
            IP.Mode = HorizontalAxis.Length;
            if (resetIntegralRegion)
                IP.IsFull = true;

            IP.StartLength = 1;
            formMain.FormProperty.numericBoxConcentricStart.Value = IP.StartLength;
            formMain.FormProperty.radioButtonRectangle.Checked = true;
            formMain.FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;
            formMain.FormProperty.radioButtonConcentric.Checked = true;

            IP.StepLength = textBoxPixelSizeX.Value * 0.25;

            if (IsPrimary)//今読み込んでいるのがprimaryのとき
            {
                IP.FilmDistance = numericTextBoxPrimaryFilmDistance.Value;
                IP.CenterX = numericalTextBoxPrimaryCenterPositionX.Value;
                IP.CenterY = numericTextBoxPrimaryCenterPositionY.Value;
            }
            else//Secondaryのとき
            {
                IP.FilmDistance = numericTextBoxPrimaryFilmDistance.Value + textBoxFilmDistanceDiscrepancy.Value;
                IP.CenterX = numericTextBoxSecondaryCenterPositionX.Value;
                IP.CenterY = numericTextBoxSecondaryCenterPositionY.Value;
            }
            double w = Math.Max(Math.Abs(IP.CenterX), Math.Abs(IP.SrcWidth - IP.CenterX));
            double h = Math.Max(Math.Abs(IP.CenterY), Math.Abs(IP.SrcWidth - IP.CenterY));
            IP.EndLength = textBoxPixelSizeX.Value * Math.Sqrt(w * w + h * h);
            formMain.FormProperty.numericBoxConcentricEnd.Value = IP.EndLength;
          
          
        }

        /// <summary>
        /// このフォームで設定されているRefined波長、ピクセルサイズ関係、TiltCorrectionなどをIPにセットします。
        /// </summary>
        public void SetRefinedIntegralProperty(bool IsPrimary)
        {
            IP.WaveLength = textBoxRefinedWaveLength.Value;
            IP.PixSizeX = textBoxRefinedPixelSizeX.Value;
            IP.PixSizeY = textBoxRefinedPixelSizeY.Value;
            IP.ksi = textBoxRefinedPixelKsi.RadianValue;
            IP.SpericalRadiusInverse = numericalTextBoxRefinedSphericalRadius.Value/1000;

            IP.ConcentricMode = true;

            IP.Mode = HorizontalAxis.Length;
            IP.IsFull = true;

            IP.StartLength = 1;
            //formMain.formProperty.numericUpDownIntensityStart.Value = (decimal)IP.StartLength;
            IP.StepLength = textBoxPixelSizeX.Value * 0.5;

            if (IsPrimary)//今読み込んでいるのがprimaryのとき
            {
                IP.FilmDistance = textBoxRefinedPrimaryFilmDistance.Value;
                IP.CenterX = numericalTextBoxPrimaryCenterPositionX.Value;
                IP.CenterY = numericTextBoxPrimaryCenterPositionY.Value;
                IP.phi = textBoxRefinedPrimaryPhi.RadianValue;
                IP.tau = textBoxRefinedPrimaryTau.RadianValue;
            }
            else//Secondaryのとき
            {
                IP.FilmDistance = textBoxRefinedPrimaryFilmDistance.Value + textBoxFilmDistanceDiscrepancy.Value;
                IP.CenterX = numericTextBoxSecondaryCenterPositionX.Value;
                IP.CenterY = numericTextBoxSecondaryCenterPositionY.Value;
                IP.phi = textBoxRefinedSecondaryPhi.RadianValue;
                IP.tau = textBoxRefinedSecondaryTau.RadianValue;
            }
            double w = Math.Max(Math.Abs(IP.CenterX), Math.Abs(IP.SrcWidth - IP.CenterX));
            double h = Math.Max(Math.Abs(IP.CenterY), Math.Abs(IP.SrcWidth - IP.CenterY));
            IP.EndLength = textBoxPixelSizeX.Value * Math.Sqrt(w * w + h * h);
            //formMain.formProperty.numericUpDownIntensityEnd.Value = (decimal)IP.EndLength;

        }

        private List<EllipseParameter> CollectEllipses(double progress, bool IsPrimary)
        {
            return CollectEllipses(progress, IsPrimary, true);
        }

        delegate List<EllipseParameter> CollectEllipsesCallBack(double progress, bool IsPrimary, bool IsRenewIP);
        private List<EllipseParameter> CollectEllipses(double progress, bool IsPrimary, bool IsRenewIP)
        {
            if (this.InvokeRequired)//別スレッドから呼び出されたとき Invokeして呼びなおす
            {
                CollectEllipsesCallBack d = new CollectEllipsesCallBack(CollectEllipses);
                return (List<EllipseParameter>)this.Invoke(d, new object[] { progress, IsPrimary, IsRenewIP });
            }
            
            if (backgroundWorkerRefine.CancellationPending) return null;

            //読み込んでいる画像が違ったら
            if (formMain.SequentialImageMode || IsPrimary != (textBoxPrimaryFileName.Text == formMain.FilePath + formMain.FileName))
            {
                if (IsPrimary)
                    SetImage(true);
                else
                    SetImage(false);
            }

            int profileNumber = IsPrimary ? 0 : 1;
            dp[profileNumber == 1 ? 0 : 1].OriginalProfile = null;
            if (IsRenewIP)
                SetRefinedIntegralProperty(IsPrimary);
            formMain.FormProperty.comboBoxRectangleDirection.SelectedIndex = 7;
            IP.StartLength = 1;
            IP.Mode = HorizontalAxis.Length;
            IP.StepLength = textBoxPixelSizeX.Value * 0.25;
            double w = Math.Max(Math.Abs(IP.CenterX), Math.Abs(IP.SrcWidth - IP.CenterX));
            double h = Math.Max(Math.Abs(IP.CenterY), Math.Abs(IP.SrcWidth - IP.CenterY));
            IP.EndLength = textBoxPixelSizeX.Value * Math.Sqrt(w * w + h * h);
            IP.IsTiltCorrection = true;

            List<double> peak = new List<double>();
            for (int i = 0; i < crystal[profileNumber].Plane.Count; i++)
                if (crystal[profileNumber].Plane[i].IsFittingChecked)
                {
                   // peak.Add(crystal[profileNumber].Plane[i].MillimeterCalc);
                    peak.Add(Math.Tan(2 * Math.Asin(WaveLength / 2 / crystal[profileNumber].Plane[i].d)) * FilmDistance[profileNumber]);
                }
            formMain.FormProperty.DirectSpotPosition = new PointD(IP.CenterX, IP.CenterY);

            List<EllipseParameter> ellipseParameters = new List<EllipseParameter>();

            for (int i = 0; i < crystal[profileNumber].Plane.Count; i++)
                if (crystal[profileNumber].Plane[i].IsFittingChecked)
                {
                    ellipseParameters.Add(new EllipseParameter());
                    ellipseParameters[ellipseParameters.Count - 1].millimeterCalc = crystal[profileNumber].Plane[i].MillimeterCalc;
                    ellipseParameters[ellipseParameters.Count - 1].strHKL = crystal[profileNumber].Plane[i].strHKL;
                    ellipseParameters[ellipseParameters.Count - 1].d = crystal[profileNumber].Plane[i].d;
                }

            double startProgress = (double)toolStripProgressBar1.Value / toolStripProgressBar1.Maximum;

            NumberOfDirection = (int)numericUpDownDivision.Value;

            for (int j = 0; j < NumberOfDirection; j++)//NumberOfDirectionの数だけ回す
            {
                formMain.Skip = true;

             
                if (radioButtonSector.Checked)
                {
                    formMain.FormProperty.radioButtonSector.Checked = true;
                    formMain.FormProperty.numericUpDownSectorStartAngle.Value = (decimal)((j - 0.5) * 360.0 / NumberOfDirection);
                    formMain.Skip = false;
                    formMain.FormProperty.numericUpDownSectorEndAngle.Value = (decimal)((j + 0.5) * 360.0 / NumberOfDirection);
                }
                else
                {
                    formMain.FormProperty.radioButtonRectangle.Checked = true;
                    formMain.FormProperty.numericUpDownRectangleBand.Value = (decimal)(numericUpDownBandWidth.Value * IP.SrcWidth / 100);
                    formMain.Skip = false;
                    formMain.FormProperty.numericUpDownRectangleAngle.Value = (decimal)(j * 360.0 / NumberOfDirection);//方向を設定
                }

                Ring.SetFindTiltParameter(IP, peak.ToArray(), (double)numericUpDownSearchRange.Value);//GetIntensityのときのパラメータを設定
                dp[profileNumber].OriginalProfile = Ring.GetProfileForFindTiltCorrection(IP);//Profileをゲット
                SetDrawRange(false);
                Fitting();

                int n = 0;
                for (int i = 0; i < crystal[profileNumber].Plane.Count; i++)
                    if (crystal[profileNumber].Plane[i].IsFittingChecked)
                        ellipseParameters[n++].Add(crystal[profileNumber].Plane[i].MillimeterObs, (double)j / NumberOfDirection * Math.PI * 2.0);

                if (backgroundWorkerRefine.CancellationPending) return null;
                toolStripProgressBar1.Value = (int)((startProgress + (double)j / NumberOfDirection * (progress - startProgress)) * toolStripProgressBar1.Maximum);
                toolStripStatusLabel1.Text = "Calculating ..."
                   + "Progress: " + (100.0 * toolStripProgressBar1.Value / toolStripProgressBar1.Maximum).ToString("f2") + "%" +
                   "   Elapsed time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f2") + "sec., " +
                   "   Estimated remaining time: " +
                   ((double)(toolStripProgressBar1.Maximum - toolStripProgressBar1.Value) / toolStripProgressBar1.Value * sw.ElapsedMilliseconds / 1000.0).ToString("f2") + " sec.";

                Application.DoEvents();
            }
            //5方向以上のデータを得られたリングのみ採用する
            for (int i = ellipseParameters.Count - 1; i >= 0; i--)
            {
                int n = 0;
                for (int j = 0; j < ellipseParameters[i].millimeters.Count; j++)
                    if (!double.IsNaN(ellipseParameters[i].millimeters[j]))
                        n++;
                if (n < 5)
                    ellipseParameters.RemoveAt(i);
            }

            if (ellipseParameters.Count < 2)
                if (!(!checkBoxRefineWaveLength.Checked && checkBoxRefineFilmDistance.Checked && !checkBoxRefinePixelSize.Checked && !checkBoxRefineTiltCorrection.Checked))
                    //集まった楕円情報が1つ以下で、かつカメラ長だけをフィッティングしたい場合でなければ･･･
                    backgroundWorkerRefine.CancelAsync();

            backgroundWorkerRefine.ReportProgress(0);

            return ellipseParameters;

        }

        /// <summary>
        /// 現在読み込まれている画像を使ってピクセルの形を求めます。
        /// </summary>
        private void SetPixelShape(List<EllipseParameter> ellipses, bool distortion)
        {
            Geometriy.GetPixelShape(ellipses.ToArray(), ref IP.PixSizeX, ref IP.PixSizeY, ref IP.ksi, ref PixSizeXDev, ref PixSizeYDev, ref KsiDev, distortion);

            textBoxRefinedPixelKsi.RadianValue = IP.ksi;
            textBoxRefinedPixelKsiDev.RadianValue = KsiDev;

            textBoxRefinedPixelSizeX.Value = IP.PixSizeX;
            textBoxPixelSizeXDev.Value = PixSizeXDev;

            textBoxRefinedPixelSizeY.Value = IP.PixSizeY;
            textBoxPixelSizeYDev.Value = PixSizeYDev;

            DrawPixelSizeX();
            DrawPixelSizeY();
            DrawPixelKsi();
        }


        /// <summary>
        /// 球面補正
        /// </summary>
        /// <param name="searchRange"></param>
        /// <param name="iterationNum"></param>
        /// <param name="progress"></param>
        private void SetSphericfalCorrection(List<EllipseParameter> ellipses, bool IsPrimary)
        {
            //まず各楕円の中心位置および各楕円の平均半径を求める。
            double radiusInverse = numericalTextBoxRefinedSphericalRadius.Value / 1000;
            double radiusInverseDev = 0;

            FindParameter.FindSphericalCorrection(ellipses, WaveLength, IsPrimary ? FilmDistance[0] : FilmDistance[1], ref radiusInverse, ref radiusInverseDev);

            numericalTextBoxRefinedSphericalRadius.Value = radiusInverse * 1000;
            numericalTextBoxRadiusInverseDev.Value = radiusInverseDev * 1000;
            IP.SpericalRadiusInverse = radiusInverse;


        }

        /// <summary>
        /// このモードでは一発で傾き、オフセットを求める
        /// </summary>
        /// <param name="searchRange"></param>
        /// <param name="iterationNum"></param>
        /// <param name="progress"></param>
        private void SetTiltCorrection(List<EllipseParameter> ellipses, bool IsPrimary)
        {
            //まず各楕円の中心位置および各楕円の平均半径を求める。
            if (ellipses == null) return;
            List<PointD> EllipseCenter = new List<PointD>();
            List<double> Radius = new List<double>();
            PointD p = new PointD();
            for (int i = 0; i < ellipses.Count; i++)
            {
                double temp = 0;
                int n = 0;
                for (int j = 0; j < ellipses[i].millimeters.Count; j++)
                    if (!double.IsNaN(ellipses[i].millimeters[j]))
                    {
                        temp += ellipses[i].millimeters[j];
                        n++;
                    }
                Radius.Add(temp / n);

                List<PointD> pt = new List<PointD>();
                for (int j = 0; j < ellipses[i].points.Count; j++)
                    if (!double.IsNaN(ellipses[i].points[j].X))
                        pt.Add(ellipses[i].points[j]);

                p = Geometriy.GetEllipseCenter(pt.ToArray());

                if (!double.IsNaN(p.X) && !double.IsNaN(p.Y))
                    EllipseCenter.Add(p);
            }

            PointD centerOffset = new PointD(0, 0);//このときのCenterOffsetはmillimeter単位
            SetRefinedIntegralProperty(IsPrimary);

            double phiDev = 0, tauDev = 0;
            PointD centerOffsetDev = new PointD();
            Geometriy.GetTiltAndOffset(EllipseCenter.ToArray(), Radius.ToArray(), FilmDistance[0], ref centerOffset, ref centerOffsetDev, ref IP.tau, ref tauDev, ref IP.phi, ref phiDev);

            //center位置をPixel単位に変換
            p.X = centerOffset.X / IP.PixSizeX - centerOffset.Y * Math.Tan(IP.ksi) / IP.PixSizeY;
            p.Y = centerOffset.Y / IP.PixSizeY;
            centerOffsetDev.X = centerOffsetDev.X / IP.PixSizeX - centerOffsetDev.Y * Math.Tan(IP.ksi) / IP.PixSizeY;
            centerOffsetDev.Y = centerOffsetDev.Y / IP.PixSizeY;

            if (IsPrimary)
            {
                IP.CenterX = numericalTextBoxPrimaryCenterPositionX.Value + p.X;
                IP.CenterY = numericTextBoxPrimaryCenterPositionY.Value + p.Y;
            }
            else
            {
                IP.CenterX = numericTextBoxSecondaryCenterPositionX.Value + p.X;
                IP.CenterY = numericTextBoxSecondaryCenterPositionY.Value + p.Y;
            }


            //現在読み込んでいるのがprimaryかsecondaryかに応じてCenterPositionを設定
            if (IsPrimary)
            {
                numericalTextBoxPrimaryCenterPositionX.Value = IP.CenterX;
                numericalTextBoxPrimaryCenterPositionXDev.Value = centerOffsetDev.X;
                numericTextBoxPrimaryCenterPositionY.Value = IP.CenterY;
                numericalTextBoxPrimaryCenterPositionYDev.Value = centerOffsetDev.Y;

                textBoxRefinedPrimaryPhi.RadianValue = IP.phi;
                textBoxRefinedPrimaryPhiDev.RadianValue = phiDev;
                textBoxRefinedPrimaryTau.RadianValue = IP.tau;
                textBoxRefinedPrimaryTauDev.RadianValue = tauDev;

            }
            else
            {
                numericTextBoxSecondaryCenterPositionX.Value = IP.CenterX;
                numericTextBoxSecondaryCenterPositionXDev.Value = centerOffsetDev.X;
                numericTextBoxSecondaryCenterPositionY.Value = IP.CenterY;
                numericTextBoxSecondaryCenterPositionYDev.Value = centerOffsetDev.Y;

                textBoxRefinedSecondaryPhi.RadianValue = IP.phi;
                textBoxRefinedSecondaryPhiDev.RadianValue = phiDev;
                textBoxRefinedSecondaryTau.RadianValue = IP.tau;
                textBoxRefinedSecondaryTauDev.RadianValue = tauDev;

            }
            DrawTiltCorrection(EllipseCenter, centerOffset, IsPrimary);

            DrawPhi(true, IsPrimary);
            DrawTau(true, IsPrimary);
        }


        /// <summary>
        /// 中心位置のみを決める
        /// </summary>
        /// <param name="searchRange"></param>
        /// <param name="iterationNum"></param>
        /// <param name="progress"></param>
        private void SetCenterPosition(List<EllipseParameter> ellipses, bool IsPrimary)
        {
            //まず各楕円の中心位置および各楕円の平均半径を求める。
            if (ellipses == null) return;
            List<PointD> EllipseCenter = new List<PointD>();
            List<double> Radius = new List<double>();
            PointD p = new PointD();
            for (int i = 0; i < ellipses.Count; i++)
            {
                List<PointD> pt = new List<PointD>();
                for (int j = 0; j < ellipses[i].points.Count; j++)
                    if (!double.IsNaN(ellipses[i].points[j].X))
                        pt.Add(ellipses[i].points[j]);

                p = Geometriy.GetEllipseCenter(pt.ToArray());

                if (!double.IsNaN(p.X) && !double.IsNaN(p.Y))
                    EllipseCenter.Add(p);
            }

            double x = 0, y = 0;
            for(int i =0; i<EllipseCenter.Count; i++)
            {
                x += EllipseCenter[i].X;
                y += EllipseCenter[i].Y;
            }

            PointD centerOffset = new PointD(x / EllipseCenter.Count, y / EllipseCenter.Count);//このときのCenterOffsetはmillimeter単位
            SetRefinedIntegralProperty(IsPrimary);

            PointD centerOffsetDev= new PointD();

            //center位置をPixel単位に変換
            p.X = centerOffset.X / IP.PixSizeX - centerOffset.Y * Math.Tan(IP.ksi) / IP.PixSizeY;
            p.Y = centerOffset.Y / IP.PixSizeY;
            centerOffsetDev.X = centerOffsetDev.X / IP.PixSizeX - centerOffsetDev.Y * Math.Tan(IP.ksi) / IP.PixSizeY;
            centerOffsetDev.Y = centerOffsetDev.Y / IP.PixSizeY;
            
            if (IsPrimary)
            {
                IP.CenterX = numericalTextBoxPrimaryCenterPositionX.Value + p.X;
                IP.CenterY = numericTextBoxPrimaryCenterPositionY.Value + p.Y;
            }
            else
            {
                IP.CenterX = numericTextBoxSecondaryCenterPositionX.Value + p.X;
                IP.CenterY = numericTextBoxSecondaryCenterPositionY.Value + p.Y;
            }


            //現在読み込んでいるのがprimaryかsecondaryかに応じてCenterPositionを設定
            if (IsPrimary)
            {
                numericalTextBoxPrimaryCenterPositionX.Value = IP.CenterX;
                numericalTextBoxPrimaryCenterPositionXDev.Value = centerOffsetDev.X;
                numericTextBoxPrimaryCenterPositionY.Value = IP.CenterY;
                numericalTextBoxPrimaryCenterPositionYDev.Value = centerOffsetDev.Y;
            }
            else
            {
                numericTextBoxSecondaryCenterPositionX.Value = IP.CenterX;
                numericTextBoxSecondaryCenterPositionXDev.Value = centerOffsetDev.X;
                numericTextBoxSecondaryCenterPositionY.Value = IP.CenterY;
                numericTextBoxSecondaryCenterPositionYDev.Value = centerOffsetDev.Y;
            }
            DrawTiltCorrection(EllipseCenter, centerOffset, IsPrimary);
        }

        //残差を見積もる
        private void GetResidual(List<EllipseParameter> ellipses)
        {
            if (ellipses == null) return;

            double residual = 0;
            int n = 0;
            for (int i = 0; i < ellipses.Count; i++)
                for (int j = 0; j < ellipses[i].millimeters.Count; j++)
                {
                    if (!double.IsNaN(ellipses[i].millimeters[j]))
                    {
                        double temp = (ellipses[i].millimeters[j] - ellipses[i].millimeterCalc) * 100;
                        residual += temp * temp;
                        n++;
                    }
                }
            residual = Math.Sqrt(residual / 10000) / n;
            DrawResidual(residual);
        }
        //残差を見積もる (powerPlay用)
        private double GetResidualForPowerPlay(List<EllipseParameter> ellipses)
        {
            if (ellipses == null) return 1;
            double residual = 0;
            int n = 0;
            for (int i = 0; i < ellipses.Count; i++)
                for (int j = 0; j < ellipses[i].millimeters.Count; j++)
                {
                    if (!double.IsNaN(ellipses[i].millimeters[j]))
                    {
                        double temp = (ellipses[i].millimeters[j] - ellipses[i].millimeterCalc) * 100;
                        residual += temp * temp;
                        n++;
                    }
                }
            return Math.Sqrt(residual / 10000) / n;
        }


        #region フィッティング後のピーク値を使って各種パラメータを決めるルーチン
        //1枚のイメージの複数のピークの距離の比を使って波長を求める。テキストボックスもセット
        private void GetWaveLengthFromMultiPeaks(List<EllipseParameter> ellipses)
        {
            FindParameter.FindWaveLengthFromMultiPeaks(ellipses, ref WaveLength, ref WaveLengthDev);
            
            textBoxRefinedWaveLength.Value = WaveLength * 10;
            textBoxWaveLengthDev.Value = WaveLengthDev * 10;
            IP.WaveLength = WaveLength;
            DrawWaveLength();
        }

        //2枚のイメージの複数のピークの距離の比を使って波長を求める。テキストボックスもセット
        private void GetWaveLengthFromMultiPeaks(List<EllipseParameter> ellipses1, List<EllipseParameter> ellipses2)
        {
            if (ellipses1 == null || ellipses2 == null) return;
            double WaveLength1, WaveLength2, WaveLengthDev1, WaveLengthDev2;
            WaveLength1 = WaveLength2 = WaveLength;
            WaveLengthDev1 = WaveLengthDev2 = 1;
            FindParameter.FindWaveLengthFromMultiPeaks(ellipses1, ref WaveLength1, ref WaveLengthDev1);
            FindParameter.FindWaveLengthFromMultiPeaks(ellipses2, ref WaveLength2, ref WaveLengthDev2);
            double weight1 = ellipses1.Count / WaveLengthDev1 / WaveLengthDev1;
            double weight2 = ellipses2.Count / WaveLengthDev2 / WaveLengthDev2;
            WaveLength = (WaveLength1 * weight1 + WaveLength2 * weight2) / (weight1 + weight2);
            WaveLengthDev = Math.Sqrt(1 / (weight1 + weight2));

            textBoxRefinedWaveLength.Value = WaveLength * 10;
            textBoxWaveLengthDev.Value = WaveLengthDev * 10;
            IP.WaveLength = WaveLength;
            DrawWaveLength();
        }

        //固定のピクセル形状と2枚のイメージを使って波長を求める。テキストボックスもセット
        private void GetWaveLengthFromTwoImageFixedPixelShape(List<EllipseParameter> ellipses1, List<EllipseParameter> ellipses2)
        {
            double WaveLength1, WaveLength2, WaveLengthDev1, WaveLengthDev2;
            WaveLength1 = WaveLength2 = WaveLengthDev1 = WaveLengthDev2 = 0;
            FindParameter.FindWaveLengthFromFixedPixelSize(ellipses1, FilmDistance[0], ref WaveLength1, ref WaveLengthDev1);
            FindParameter.FindWaveLengthFromFixedPixelSize(ellipses2, FilmDistance[1], ref WaveLength2, ref WaveLengthDev2);

            double weight1 = ellipses1.Count / WaveLengthDev1 / WaveLengthDev1;
            double weight2 = ellipses2.Count / WaveLengthDev2 / WaveLengthDev2;
            WaveLength = (WaveLength1 * weight1 + WaveLength2 * weight2) / (weight1 + weight2);
            WaveLengthDev = Math.Sqrt(1 / (weight1 + weight2));

            textBoxRefinedWaveLength.Value = WaveLength * 10;
            textBoxWaveLengthDev.Value = WaveLengthDev * 10;
            IP.WaveLength = WaveLength;
            DrawWaveLength();
        }

        //1枚のイメージを使ってフィルム距離を求める。テキストボックスもセット
        private void GetFilmDistanceFromOneImage(List<EllipseParameter> ellipses)
        {
            FindParameter.FindFilmDistanceFromWaveLength(ellipses, WaveLength, ref FilmDistance[0], ref FilmDistanceDev);
            textBoxRefinedPrimaryFilmDistance.Value = FilmDistance[0];
            textBoxCameraLengthDev.Value = FilmDistanceDev;
            IP.FilmDistance = FilmDistance[0];
            DrawFilmDistance();
        }
        //2枚のイメージを使ってフィルム距離を求める。テキストボックスもセット
        private void GetFilmDistanceFromTwoImage(List<EllipseParameter> ellipse1, List<EllipseParameter> ellipse2)
        {
            FindParameter.FindFilmDistanceFromDiscrepancy(ellipse1, ellipse2, FilmDistanceDiscrepancy, ref FilmDistance[0], ref FilmDistanceDev);
            textBoxRefinedPrimaryFilmDistance.Value = FilmDistance[0];
            textBoxCameraLengthDev.Value = FilmDistanceDev;
            FilmDistance[1] = FilmDistance[0] + FilmDistanceDiscrepancy;
            DrawFilmDistance();
        }
        #endregion

        #region 最適化のメインルーチン

        System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //最適化ボタン押下
        private void buttonExecuteRefinements_Click(object sender, EventArgs e)
        {
            if (backgroundWorkerRefine.IsBusy)
                return;

            setHorizontalMode();

            if (!checkBoxRefleshMainform.Checked) formMain.SkipDrawing = false;
            IsSkipTextChangeEvent = true;
            CheckForIllegalCrossThreadCalls = false;
            buttonStopRefinements.Enabled = true;
            checkBoxShowEachPeaks.Visible = true;
            checkBoxShowEachPeaks.Checked = true;
            flowLayoutPanel1.Visible = false;
            buttonExecuteRefinements.Enabled = false;

           


                this.panel1.Enabled = false;
            if (!checkBoxMouseOperation.Checked)
                pictureBoxMain.Enabled = false;

            if (backgroundWorkerRefine.IsBusy)
                backgroundWorkerRefine.CancelAsync();
            else
                backgroundWorkerRefine.RunWorkerAsync();

        }

        private void buttonStopRefinements_Click(object sender, EventArgs e)
        {
            backgroundWorkerRefine.CancelAsync();
            resetHorizontalMode();
        }

        //最適化スレッドが終了したとき
        private void backgroundWorkerRefine_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            while (backgroundWorkerRefine.IsBusy)
                Thread.Sleep(100);

            sw.Stop();
            resetHorizontalMode();
            formMain.toolStripStatusLabel.Text = "Calculating Time (Find Parameter):  " + (sw.ElapsedMilliseconds).ToString() + "ms";

            IsSkipTextChangeEvent = false;


            buttonStopRefinements.Enabled = false;
            checkBoxShowEachPeaks.Visible = false;
            checkBoxShowEachPeaks.Checked = false;
            buttonExecuteRefinements.Enabled = true;
            this.panel1.Enabled = true;
            pictureBoxMain.Enabled = true;
            flowLayoutPanel1.Visible = !checkBoxUseStandardCrystal.Checked;
            
            formMain.SkipDrawing = false;
            formMain.FormProperty.radioButtonRectangle.Checked = true;
            formMain.FormProperty.comboBoxRectangleDirection.SelectedIndex = 0;
            resetHorizontalMode();
        }
        //最適化スレッドの開始イベント発生時
        private void backgroundWorkerRefine_DoWork(object sender, DoWorkEventArgs e)
        {
            RefineParameters();
        }

        private void RefineParameters()
        {
            if (crystal[0].Plane == null) return;

            //チェックされているものを設定
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < crystal[i].Plane.Count; j++)
                    crystal[i].Plane[j].IsFittingChecked = (bool)dataGridView.Rows[j].Cells[2 + i * 2].Value;

            //チェックされているもの少なすぎないか
            int n = 0;
            for (int i = 0; i < crystal[0].Plane.Count; i++)
                if (crystal[0].Plane[i].IsFittingChecked)
                    n++;
            //カメラ長だけを計算したいときに備える

            if (n < 3)
                if (!(!checkBoxRefineWaveLength.Checked && checkBoxRefineFilmDistance.Checked && !checkBoxRefinePixelSize.Checked && !checkBoxRefineTiltCorrection.Checked))
                    return;

            //2イメージのとき
            if (textBoxSecondaryFileName.Text != "")
            {
                //チェックされているもの少なすぎないか
                n = 0;
                for (int i = 0; i < crystal[1].Plane.Count; i++)
                    if (crystal[1].Plane[i].IsFittingChecked)
                        n++;
                if (n < 3)
                    if (!(!checkBoxRefineWaveLength.Checked && checkBoxRefineFilmDistance.Checked && !checkBoxRefinePixelSize.Checked && !checkBoxRefineTiltCorrection.Checked))
                        return;

                //同時に選ばれているものが最低一枚はあるか
                bool flag = false;
                for (int i = 0; i < crystal[0].Plane.Count && i < crystal[1].Plane.Count; i++)
                    if (crystal[0].Plane[i].IsFittingChecked && crystal[1].Plane[i].IsFittingChecked)
                        flag = true;
                if (flag == false)
                    return;
            }

            textBoxRefinedPrimaryPhi.Value = textBoxTiltCorrectionPrimaryPhi.Value;
            textBoxRefinedPrimaryTau.Value = textBoxTiltCorrectionPrimaryTau.Value;
            textBoxRefinedSecondaryPhi.Value = textBoxTiltCorrectionSecondaryPhi.Value;
            textBoxRefinedSecondaryTau.Value = textBoxTiltCorrectionSecondaryTau.Value;
            textBoxRefinedWaveLength.Value = textBoxWaveLength.Value;
            textBoxRefinedPixelSizeX.Value = textBoxPixelSizeX.Value;
            textBoxRefinedPixelSizeY.Value = textBoxPixelSizeY.Value;
            textBoxRefinedPixelKsi.Value = textBoxPixelKsi.Value;

            textBoxRefinedPrimaryFilmDistance.Value = numericTextBoxPrimaryFilmDistance.Value;

            numericalTextBoxRefinedSphericalRadius.Value = numericalTextBoxSphericalRadius.Value;

            textBoxWaveLengthDev.Text = "N.A.";
            textBoxPixelSizeXDev.Text = "N.A.";
            textBoxPixelSizeYDev.Text = "N.A.";
            textBoxCameraLengthDev.Text = "N.A.";

            formMain.IP.Mode = HorizontalAxis.Length;//アングルモードかピクセルモードか
            formMain.FormProperty.radioButtonRectangle.Checked = true;
            formMain.FormProperty.checkBoxRectangleIsBothSide.Checked = false;

            int Repetition = (int)numericUpDownRepitition.Value;

            sw.Reset();
            sw.Start();
            toolStripProgressBar1.Value = 0;

            List<EllipseParameter> ellipsesPrimary = new List<EllipseParameter>();
            List<EllipseParameter> ellipsesSecondary = new List<EllipseParameter>();

            if (checkBoxRefineTiltCorrection.Checked)
                IP.IsTiltCorrection = true;

            if (textBoxSecondaryFileName.Text == "")//1イメージのとき
            {
                SetRefinedIntegralProperty(true);
                SetImage(true);

                for (int j = 0; j < Repetition; j++)
                {
                    if (j == 0)
                    {
                        ellipsesPrimary = CollectEllipses(0.2 / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        GetResidual(ellipsesPrimary);
                    }
                    if (backgroundWorkerRefine.CancellationPending) return;

                    if (checkBoxRefineWaveLength.Checked)
                        GetWaveLengthFromMultiPeaks(ellipsesPrimary);//X線の波長をもとめる

                    //Spherical補正
                    if (checkBoxSphericalCorrection.Checked)
                    {
                        if (backgroundWorkerRefine.CancellationPending) return;
                        SetSphericfalCorrection(ellipsesPrimary, true);
                        ellipsesPrimary = CollectEllipses((j + 0.4) / Repetition, true);
                    }

                    //カメラ長補正
                    if (checkBoxRefineFilmDistance.Checked)
                        GetFilmDistanceFromOneImage(ellipsesPrimary);//フィルムの距離をもとめる

                    //Tilt補正もPixelSize補正もしないが、CenterPositionだけ補正する場合
                    if (!checkBoxRefineTiltCorrection.Checked && !checkBoxRefinePixelSize.Checked && checkBoxCenterPosition.Checked)
                    {
                        //ellipsesPrimary = CollectEllipses((j + 0.5) / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        SetCenterPosition(ellipsesPrimary, true);
                    }

                    //Tilt補正
                    if (checkBoxRefineTiltCorrection.Checked)
                    {
                        ellipsesPrimary = CollectEllipses((j + 0.60) / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        SetTiltCorrection(ellipsesPrimary, true);
                    }
                    //Pixel Size & Distortion補正
                    if (checkBoxRefinePixelSize.Checked)
                    {
                        ellipsesPrimary = CollectEllipses((j + 0.8) / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        SetPixelShape(ellipsesPrimary, checkBoxRefinePixelDistortion.Checked);
                    }

                    ellipsesPrimary = CollectEllipses((j + 1.0) / Repetition, true);
                    GetResidual(ellipsesPrimary);
                }

            }//1イメージのとき終了

            else//2イメージのとき
            {
                for (int i = 0; i < Repetition; i++)
                {
                    //primary 
                    if (i == 0)//最初の一回は  荒く決めなければいけないので逐一Collectする
                    {
                        ellipsesPrimary = CollectEllipses(0.1 / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        GetResidual(ellipsesPrimary);

                        if (checkBoxRefineWaveLength.Checked)//X線の波長をもとめる
                            GetWaveLengthFromMultiPeaks(ellipsesPrimary);
                        if (checkBoxRefineFilmDistance.Checked)//カメラ長補正
                            GetFilmDistanceFromOneImage(ellipsesPrimary);//フィルムの距離をもとめる
                        ellipsesPrimary = CollectEllipses(0.2 / Repetition, true);
                        if (checkBoxRefineWaveLength.Checked)//X線の波長をもとめる
                            GetWaveLengthFromMultiPeaks(ellipsesPrimary);
                        if (checkBoxRefineFilmDistance.Checked)//カメラ長補正
                            GetFilmDistanceFromOneImage(ellipsesPrimary);//フィルムの距離をもとめる
                        FilmDistance[1] = FilmDistance[0] + FilmDistanceDiscrepancy;

                        //X線の波長をもとめる
                        if (checkBoxRefineWaveLength.Checked)
                        {
                            ellipsesSecondary = CollectEllipses(0.3 / Repetition, false);
                            //PixelShapeを求めるとき　＝＞PixelShapeに依存しないように波長を決めなければならない
                            if (checkBoxRefinePixelSize.Checked)
                                GetWaveLengthFromMultiPeaks(ellipsesPrimary, ellipsesSecondary);
                            else
                                GetWaveLengthFromTwoImageFixedPixelShape(ellipsesPrimary, ellipsesSecondary);
                            if (backgroundWorkerRefine.CancellationPending) return;
                        }

                        //FilmDistanceを決める
                        if (checkBoxRefineFilmDistance.Checked)
                        {
                            ellipsesSecondary = CollectEllipses(0.4 / Repetition, false);
                            ellipsesPrimary = CollectEllipses(0.5 / Repetition, true);
                            GetFilmDistanceFromTwoImage(ellipsesPrimary, ellipsesSecondary);
                            if (backgroundWorkerRefine.CancellationPending) return;
                        }

                        //Tilt補正
                        if (checkBoxRefineTiltCorrection.Checked)
                        {
                            //secondary
                            ellipsesSecondary = CollectEllipses(0.6 / Repetition, false);
                            if (backgroundWorkerRefine.CancellationPending) return;
                            SetTiltCorrection(ellipsesSecondary, false);

                            //primary
                            ellipsesPrimary = CollectEllipses(0.7 / Repetition, true);
                            if (backgroundWorkerRefine.CancellationPending) return;
                            SetTiltCorrection(ellipsesPrimary, true);
                            if (backgroundWorkerRefine.CancellationPending) return;
                        }

                        //AspectRatio補正
                        if (checkBoxRefinePixelSize.Checked)
                        {
                            ellipsesPrimary = CollectEllipses(0.8 / Repetition, true);
                            if (backgroundWorkerRefine.CancellationPending) return;
                            SetPixelShape(ellipsesPrimary, checkBoxRefinePixelDistortion.Checked);
                        }

                        //残差をチェック
                        ellipsesPrimary = CollectEllipses(0.9 / Repetition, true);
                        GetResidual(ellipsesPrimary);
                    }
                    else//2回目以降のとき
                    {
                        //secondary
                        ellipsesSecondary = CollectEllipses((i + 0.3333333) / Repetition, false);
                        if (backgroundWorkerRefine.CancellationPending) return;

                        //FilmDistanceを決める
                        if (checkBoxRefineFilmDistance.Checked)
                            GetFilmDistanceFromTwoImage(ellipsesPrimary, ellipsesSecondary);

                        //X線の波長をもとめる
                        if (checkBoxRefineWaveLength.Checked)
                        {
                            //PixelShapeを求めるとき　＝＞PixelShapeに依存しないように波長を決めなければならない
                            if (checkBoxRefinePixelSize.Checked)
                                GetWaveLengthFromMultiPeaks(ellipsesPrimary, ellipsesSecondary);
                            else
                                GetWaveLengthFromTwoImageFixedPixelShape(ellipsesPrimary, ellipsesSecondary);
                        }

                        //Tilt補正
                        if (checkBoxRefineTiltCorrection.Checked)
                        {
                            SetTiltCorrection(ellipsesSecondary, false);
                            SetTiltCorrection(ellipsesPrimary, true);

                        }
                        //AspectRatio補正
                        if (checkBoxRefinePixelSize.Checked)
                        {
                            ellipsesPrimary = CollectEllipses((i + 0.66666666666) / Repetition, true);
                            if (backgroundWorkerRefine.CancellationPending) return;
                            SetPixelShape(ellipsesPrimary, checkBoxRefinePixelDistortion.Checked);
                        }
                        //残差をチェック
                        ellipsesPrimary = CollectEllipses((i + 1.0) / Repetition, true);
                        if (backgroundWorkerRefine.CancellationPending) return;
                        GetResidual(ellipsesPrimary);
                    }

                }
            }//2imageモード終了

            toolStripProgressBar1.Value = toolStripProgressBar1.Maximum;
            toolStripStatusLabel1.Text = "Completed !  Elapsed time: " + (sw.ElapsedMilliseconds / 1000.0).ToString("f2") + "sec.";
        }

        /// <summary>
        /// RefineParametersなどから呼び出されて、画面更新などを行う
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorkerRefine_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

        }


        #endregion

        //テキストボックスが変更されたとき
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            if (IsSkipTextChangeEvent) return;
            IP.WaveLength = textBoxWaveLength.Value / 10;
            if (IP.WaveLength < 0.001) IP.WaveLength = 0.04;
            WaveLength = IP.WaveLength;

            IP.PixSizeX = textBoxPixelSizeX.Value;
            if (IP.PixSizeX < 0.00000000001) IP.PixSizeX = 0.1;

            IP.PixSizeY = textBoxPixelSizeY.Value;
            if (IP.PixSizeY < 0.00000000001) IP.PixSizeY = 0.1;

            IP.ksi = textBoxPixelKsi.RadianValue;

            IP.phi = textBoxTiltCorrectionPrimaryPhi.RadianValue;

            IP.tau = textBoxTiltCorrectionPrimaryTau.RadianValue;

            IP.SpericalRadiusInverse = numericalTextBoxSphericalRadius.Value / 1000;

            InitializeCrystalPlane();
            Fitting();
        }
        //FilmDistanceの変更
        private void numericTextBoxPrimaryFilmDistance_TextChanged(object sender, EventArgs e)
        {
            textBoxPrimaryFilmDistanceCopy.Value = numericTextBoxPrimaryFilmDistance.Value;
            textBoxPrimaryFilmDistanceCopy2.Value = numericTextBoxPrimaryFilmDistance.Value;
            if (IsSkipTextChangeEvent) return;

            FilmDistance[0] = numericTextBoxPrimaryFilmDistance.Value;

            FilmDistanceDiscrepancy = textBoxFilmDistanceDiscrepancy.Value;
            if (FilmDistance[0] - FilmDistanceDiscrepancy < 0)
                FilmDistanceDiscrepancy = 0;
            FilmDistance[1] = FilmDistanceDiscrepancy + FilmDistance[0];

            if (checkBoxUseStandardCrystal.Checked)
            {
                InitializeCrystalPlane();
                Fitting();
            }
        }

        //FilmDistanceの差が変更されたとき
        private void textBoxFilmDistanceDiscrepancy_TextChanged(object sender, EventArgs e)
        {
            if (IsSkipTextChangeEvent) return;
            //    try
            {
                FilmDistanceDiscrepancy = textBoxFilmDistanceDiscrepancy.Value;
                FilmDistance[0] = numericTextBoxPrimaryFilmDistance.Value;
            }
            //    catch { return; }
            FilmDistance[1] = FilmDistance[0] + FilmDistanceDiscrepancy;
            if (checkBoxUseStandardCrystal.Checked)
            {
                InitializeCrystalPlane();
                Fitting();
            }
        }
        private void textBoxPrimaryFileName_TextChanged(object sender, EventArgs e)
        {
            buttonPrimaryGetProfile.Enabled = textBoxPrimaryFileName.Text != "";
            buttonGetCenterPositionFromMainForm.Enabled = textBoxPrimaryFileName.Text != "";
            groupBoxSecondaryImage.Enabled = buttonPrimaryGetProfile.Enabled;
        }

        private void textBoxSecondaryFileName_TextChanged(object sender, EventArgs e)
        {
            buttonSecondaryGetProfile.Enabled = textBoxSecondaryFileName.Text != "";
            buttonGetCenterPositionFromMainForm2.Enabled = textBoxSecondaryFileName.Text != "";
        }

        //sendMainボタンが押されたとき
        private void buttonSendMainForm_Click(object sender, EventArgs e)
        {
            formMain.FormProperty.SkipEvent = true;
            formMain.FormProperty.CameraLengthText = textBoxRefinedPrimaryFilmDistance.Text;
            formMain.FormProperty.numericBoxPixelSizeX.Value = textBoxRefinedPixelSizeX.Value;
            formMain.FormProperty.numericBoxPixelSizeY.Value = textBoxRefinedPixelSizeY.Value;
            formMain.FormProperty.numericBoxPixelKsi.Value = textBoxRefinedPixelKsi.Value;
            formMain.FormProperty.numericBoxTiltPhi.Value = textBoxRefinedPrimaryPhi.Value;
            formMain.FormProperty.numericBoxTiltTau.Value = textBoxRefinedPrimaryTau.Value;
            formMain.FormProperty.WaveLengthText = textBoxRefinedWaveLength.Text;
           
            formMain.FormProperty.numericBoxSphericalCorections.Value = numericalTextBoxRefinedSphericalRadius.Value;
            formMain.FormProperty.SkipEvent = false;
            formMain.FormProperty.DirectSpotPosition = new PointD(numericalTextBoxPrimaryCenterPositionX.Value, numericTextBoxPrimaryCenterPositionY.Value);
        }

        private void buttonSetInitioalParam_Click(object sender, EventArgs e)
        {
            numericTextBoxPrimaryFilmDistance.Text = formMain.FormProperty.CameraLengthText;
            textBoxPixelSizeX.Value = formMain.FormProperty.numericBoxPixelSizeX.Value;
            textBoxPixelSizeY.Value = formMain.FormProperty.numericBoxPixelSizeY.Value;
            textBoxPixelKsi.Value = formMain.FormProperty.numericBoxPixelKsi.Value;
            textBoxTiltCorrectionPrimaryPhi.Value = formMain.FormProperty.numericBoxTiltPhi.Value;
            textBoxTiltCorrectionPrimaryTau.Value = formMain.FormProperty.numericBoxTiltTau.Value;
            textBoxWaveLength.Text = formMain.FormProperty.WaveLengthText;
            numericalTextBoxSphericalRadius.Value = formMain.FormProperty.numericBoxSphericalCorections.Value;

        }

        #region グラフを描画する部分


        List<List<PointD>> EllipseCenterPrimary = new List<List<PointD>>();
        List<PointD> DirectSpotsPrimary = new List<PointD>();
        List<List<PointD>> EllipseCenterSecondary = new List<List<PointD>>();
        List<PointD> DirectSpotsSecondary = new List<PointD>();
        Brush[] BrushesForAnalysis =
            new Brush[] { 
                    new SolidBrush(Color.MediumBlue),
                    new SolidBrush(Color.Green), 
                    new SolidBrush(Color.Red), 
                    new SolidBrush(Color.Pink), 
                    new SolidBrush(Color.Orange) 
                };
        Pen[] PensForAnalysis =
            new Pen[] { 
                    new Pen(Color.MediumBlue),
                    new Pen(Color.Green), 
                    new Pen(Color.Red), 
                    new Pen(Color.Pink), 
                    new Pen(Color.Orange) 
                };
        //引数無しのときはただ書くだけ
        private void DrawTiltCorrection(bool IsPrimary)
        {//textBoxPrimaryFileName.Text.EndsWith(formMain.fileName)
            if (IsPrimary)//今読み込んでいるのがprimaryのとき
                DrawTiltCorrectionMain(EllipseCenterPrimary, DirectSpotsPrimary, IsPrimary);
            else
                DrawTiltCorrectionMain(EllipseCenterSecondary, DirectSpotsSecondary, IsPrimary);
        }
        private void DrawTiltCorrection(List<PointD> pt, PointD centerOffset, bool IsPrimary)
        {
            if (IsPrimary)//今読み込んでいるのがprimaryのとき
            {
                if (EllipseCenterPrimary.Count >= 3)
                {
                    EllipseCenterPrimary.RemoveAt(EllipseCenterPrimary.Count - 1);
                    DirectSpotsPrimary.RemoveAt(DirectSpotsPrimary.Count - 1);
                }
                EllipseCenterPrimary.Insert(0, pt);
                DirectSpotsPrimary.Insert(0, centerOffset);
                DrawTiltCorrectionMain(EllipseCenterPrimary, DirectSpotsPrimary, IsPrimary);
                //中心の位置を補正
                if (DirectSpotsPrimary.Count > 0)
                {
                    double offserX = DirectSpotsPrimary[0].X;
                    double offsetY = DirectSpotsPrimary[0].Y;
                    PointD temp;
                    for (int i = 0; i < EllipseCenterPrimary.Count; i++)
                    {
                        temp = DirectSpotsPrimary[i];
                        DirectSpotsPrimary.RemoveAt(i);
                        DirectSpotsPrimary.Insert(i, new PointD(temp.X - offserX, temp.Y - offsetY));

                        for (int j = 0; j < EllipseCenterPrimary[i].Count; j++)
                        {
                            temp = EllipseCenterPrimary[i][j];
                            EllipseCenterPrimary[i].RemoveAt(j);
                            EllipseCenterPrimary[i].Insert(j, new PointD(temp.X - offserX, temp.Y - offsetY));
                        }
                    }
                }
            }
            else
            {
                if (EllipseCenterSecondary.Count >= 3)
                {
                    EllipseCenterSecondary.RemoveAt(EllipseCenterSecondary.Count - 1);
                    DirectSpotsSecondary.RemoveAt(DirectSpotsSecondary.Count - 1);
                }
                EllipseCenterSecondary.Insert(0, pt);
                DirectSpotsSecondary.Insert(0, centerOffset);
                DrawTiltCorrectionMain(EllipseCenterSecondary, DirectSpotsSecondary, IsPrimary);
                //中心の位置を補正
                if (DirectSpotsSecondary.Count > 0)
                {
                    double offserX = DirectSpotsSecondary[0].X;
                    double offsetY = DirectSpotsSecondary[0].Y;
                    PointD temp;
                    for (int i = 0; i < EllipseCenterSecondary.Count; i++)
                    {
                        temp = DirectSpotsSecondary[i];
                        DirectSpotsSecondary.RemoveAt(i);
                        DirectSpotsSecondary.Insert(i, new PointD(temp.X - offserX, temp.Y - offsetY));

                        for (int j = 0; j < EllipseCenterSecondary[i].Count; j++)
                        {
                            temp = EllipseCenterSecondary[i][j];
                            EllipseCenterSecondary[i].RemoveAt(j);
                            EllipseCenterSecondary[i].Insert(j, new PointD(temp.X - offserX, temp.Y - offsetY));
                        }
                    }
                }
            }
        }

        private void DrawTiltCorrectionMain(List<List<PointD>> EllipseCenter, List<PointD> DirectSpots, bool IsPrimary)
        {

            //まず座標の絶対値の最大値を決める。
            double max = double.NegativeInfinity;
            for (int i = 0; i < EllipseCenter.Count; i++)
            {
                if (DirectSpots[i].X != double.NaN)
                {
                    max = Math.Max(max, Math.Abs(DirectSpots[i].X));
                    max = Math.Max(max, Math.Abs(DirectSpots[i].Y));
                }
                for (int j = 0; j < EllipseCenter[i].Count; j++)
                {
                    if (EllipseCenter[i][j].X != double.NaN)
                    {
                        max = Math.Max(max, Math.Abs(EllipseCenter[i][j].X));
                        max = Math.Max(max, Math.Abs(EllipseCenter[i][j].Y));
                    }
                }
            }
            max *= 1.2;

            Bitmap bmp;
            if (IsPrimary)
                bmp = new Bitmap(pictureBoxTiltCorrection1.Width, pictureBoxTiltCorrection1.Height);
            else
                bmp = new Bitmap(pictureBoxTiltCorrection2.Width, pictureBoxTiltCorrection2.Height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.Clear(Color.White);
            Font strFont = new Font(new FontFamily("tahoma"), 8);

            if (IsPrimary)//今読み込んでいるのがprimaryのとき
                g.DrawString("Primary", strFont, Brushes.Black, 0, 0);
            else
                g.DrawString("Secondary", strFont, Brushes.Black, 0, 0);

            //目盛りを描く
            double graduation;//ここより角度目盛りの描画
            int log10 = Math.Log10(2 * max) > 0 ? (int)Math.Log10(2 * max) : (int)Math.Log10(2 * max) - 1;
            double d = max / Math.Pow(10, log10);
            if (d < 1.6) graduation = (2 * Math.Pow(10, log10 - 1));
            else if (d < 4.0) graduation = (5 * Math.Pow(10, log10 - 1));
            else graduation = (Math.Pow(10, log10));

            Pen pen = new Pen(Brushes.LightGray, 1);
            g.DrawLine(pen, ConvCoodTiltCorrection(-max, 0, max), ConvCoodTiltCorrection(max, 0, max));
            g.DrawLine(pen, ConvCoodTiltCorrection(0, -max, max), ConvCoodTiltCorrection(0, max, max));

            pen = new Pen(Brushes.LightGray, 1);
            for (int i = (int)(-max / graduation) + 1; i < max / graduation; i++)
            {
                g.DrawLine(pen, ConvCoodTiltCorrection(i * graduation, 0, max), new PointF(ConvCoodTiltCorrection(i * graduation, 0, max).X, ConvCoodTiltCorrection(i * graduation, 0, max).Y + 2));
                //g.DrawString((i * graduation).ToString(), strFont, Brushes.LightGray, ConvCoodTiltCorrection(i * graduation, 0, max).X - 2, ConvCoodTiltCorrection(i * graduation, 0, max).Y + 2);

                g.DrawLine(pen, ConvCoodTiltCorrection(0, i * graduation, max), new PointF(ConvCoodTiltCorrection(0, i * graduation, max).X + 2, ConvCoodTiltCorrection(0, i * graduation, max).Y));
                g.DrawString(Math.Round(i * graduation, 8).ToString(), strFont, Brushes.LightGray, ConvCoodTiltCorrection(0, i * graduation, max).X + 4, ConvCoodTiltCorrection(0, i * graduation, max).Y - 4);
            }


            //まず点(楕円の中心位置)と
            for (int i = EllipseCenter.Count - 1; i >= 0; i--)
            {
                g.FillEllipse(BrushesForAnalysis[i], ConvCoodTiltCorrection(DirectSpots[i], max).X - 3, ConvCoodTiltCorrection(DirectSpots[i], max).Y - 4, 8, 8);

                int k;

                for (int j = 0; j < EllipseCenter[i].Count; j++)
                {
                    g.DrawRectangle(PensForAnalysis[i],
                        ConvCoodTiltCorrection(EllipseCenter[i][j], max).X - 3, ConvCoodTiltCorrection(EllipseCenter[i][j], max).Y - 3, 6, 6);
                    //番号を振る
                    int temp = -1;
                    for (k = 0; k < crystal[IsPrimary ? 0 : 1].Plane.Count; k++)
                        if (crystal[IsPrimary ? 0 : 1].Plane[k].IsFittingChecked)
                            if (++temp == j)
                                break;

                    g.DrawString((k + 1).ToString(), new Font("Tahoma", 7), BrushesForAnalysis[i],
                        ConvCoodTiltCorrection(EllipseCenter[i][j], max).X + 3, ConvCoodTiltCorrection(EllipseCenter[i][j], max).Y + 3);
                }
            }
            if (IsPrimary)
                pictureBoxTiltCorrection1.Image = bmp;
            else
                pictureBoxTiltCorrection2.Image = bmp;
        }
        private PointF ConvCoodTiltCorrection(PointD pt, double max)
        {
            return new PointF((float)((pt.X / max + 1) * 0.5 * pictureBoxTiltCorrection1.Width), (float)((pt.Y / max + 1) * 0.5 * pictureBoxTiltCorrection1.Height));
        }
        private PointF ConvCoodTiltCorrection(double x, double y, double max)
        {
            return new PointF((float)((x / max + 1) * 0.5 * pictureBoxTiltCorrection1.Width), (float)((y / max + 1) * 0.5 * pictureBoxTiltCorrection1.Height));
        }


        /// <summary>
        /// 各パラメータの時系列変化を描画
        /// </summary>
        /// <param name="SeriesValue"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        private Bitmap DrawGraph(double[] SeriesValue, int width, int height)
        {

            double max = double.NegativeInfinity;
            double min = double.PositiveInfinity;
            for (int i = 0; i < SeriesValue.Length; i++)
            {
                max = Math.Max(max, SeriesValue[i]);
                min = Math.Min(min, SeriesValue[i]);
            }

            if (max - min < 10E-8)
            {
                max += 10E-8;
                min -= 10E-8;
            }
            double temp = max - min;
            max += temp * 0.1;
            min -= temp * 0.1;

            if (width == 0 || height == 0)
                return new Bitmap(1, 1);

            Bitmap bmp = new Bitmap(width, height);
            Graphics g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.White);


            //目盛りを描く

            //ここより角度目盛りの描画

            int log10 = Math.Log10(max - min) > 0 ? (int)Math.Log10(max - min) : (int)Math.Log10(max - min) - 1;

            double d = (max - min) / Math.Pow(10, log10);

            double graduation;
            if (d < 1.6) graduation = (2 * Math.Pow(10, log10 - 1));
            else if (d < 4.0) graduation = (5 * Math.Pow(10, log10 - 1));
            else graduation = (Math.Pow(10, log10));

            if (graduation < 10E-14)
                return bmp;

            Pen pen = new Pen(Brushes.LightGray, 1);
            g.DrawLine(pen, 45, 0, 45, 500);
            Font strFont = new Font(new FontFamily("tahoma"), 8);
            pen = new Pen(Brushes.LightGray, 1);

            try
            {
                for (int i = (int)(min / graduation) + 1; i < max / graduation; i++)
                {
                    g.DrawLine(pen,
                        new PointF(45, ConvCoodForAnalysis(0, i * graduation, min, max, width, height).Y),
                        new PointF(500, ConvCoodForAnalysis(0, i * graduation, min, max, width, height).Y));

                    g.DrawString(Math.Round(i * graduation, 8).ToString(), strFont, Brushes.LightGray, 0,
                        ConvCoodForAnalysis(0, i * graduation, max, min, width, height).Y - 4);
                }


                //点を描く
                for (int i = 0; i < SeriesValue.Length; i++)
                    g.FillEllipse(Brushes.Black,
                        ConvCoodForAnalysis(i, SeriesValue[i], max, min, width, height).X - 3,
                        ConvCoodForAnalysis(i, SeriesValue[i], max, min, width, height).Y - 3, 6, 6);
                //線を描く
                for (int i = 0; i < SeriesValue.Length - 1; i++)
                    g.DrawLine(new Pen(Brushes.Black, 1),
                        ConvCoodForAnalysis(i, SeriesValue[i], max, min, width, height),
                        ConvCoodForAnalysis(i + 1, SeriesValue[i + 1], max, min, width, height));
            }
            catch { }
            return bmp;
        }
        private PointF ConvCoodForAnalysis(int x, double y, double max, double min, int width, int height)
        {
            return new PointF((float)(48 + (width - 60) * x / 8.0), (float)(height * (max - y) / (max - min)));
        }

        List<double> ResidualSeries = new List<double>();
        private void DrawResidual(double residual)
        {
            if (ResidualSeries.Count >= 9)
                ResidualSeries.RemoveAt(0);
            ResidualSeries.Add(residual);
            pictureBoxResidual.Image =
                    DrawGraph(ResidualSeries.ToArray(),
                    pictureBoxResidual.Width, pictureBoxResidual.Height);
            Application.DoEvents();
        }

        List<double> WaveLengthSeries = new List<double>();
        private void DrawWaveLength()
        {
            if (WaveLengthSeries.Count >= 9)
                WaveLengthSeries.RemoveAt(0);
            WaveLengthSeries.Add(textBoxRefinedWaveLength.Value);
            pictureBoxWaveLength.Image =
                    DrawGraph(WaveLengthSeries.ToArray(),
                    pictureBoxWaveLength.Width, pictureBoxWaveLength.Height);
            Application.DoEvents();
        }

        List<double> FilmDistanceSeries = new List<double>();
        private void DrawFilmDistance()
        {
            if (FilmDistanceSeries.Count >= 9)
                FilmDistanceSeries.RemoveAt(0);
            FilmDistanceSeries.Add(textBoxRefinedPrimaryFilmDistance.Value);
            pictureBoxCameraLength.Image =
                    DrawGraph(FilmDistanceSeries.ToArray(),
                    pictureBoxCameraLength.Width, pictureBoxCameraLength.Height);
            Application.DoEvents();
        }

        List<double> PhiSeriesPrimary = new List<double>();
        List<double> PhiSeriesSecondary = new List<double>();
        private void DrawPhi(bool isNew, bool IsPrimary)
        {
            if (IsPrimary)
            {
                if (isNew)
                {
                    if (PhiSeriesPrimary.Count >= 9)
                        PhiSeriesPrimary.RemoveAt(0);
                    PhiSeriesPrimary.Add(textBoxRefinedPrimaryPhi.Value);
                }
                pictureBoxTiltCorrectionPhi1.Image =
                    DrawGraph(PhiSeriesPrimary.ToArray(),
                    pictureBoxTiltCorrectionPhi1.Width, pictureBoxTiltCorrectionPhi1.Height);
            }
            else
            {
                if (isNew)
                {
                    if (PhiSeriesSecondary.Count >= 9)
                        PhiSeriesSecondary.RemoveAt(0);
                    PhiSeriesSecondary.Add(textBoxRefinedSecondaryPhi.Value);
                }
                pictureBoxTiltCorrectionPhi2.Image =
                    DrawGraph(PhiSeriesSecondary.ToArray(),
                    pictureBoxTiltCorrectionPhi2.Width, pictureBoxTiltCorrectionPhi2.Height);

            }
            Application.DoEvents();
        }

        List<double> TauSeriesPrimary = new List<double>();
        List<double> TauSeriesSecondary = new List<double>();
        private void DrawTau(bool isNew, bool IsPrimary)
        {

            if (IsPrimary)
            {
                if (isNew)
                {
                    if (TauSeriesPrimary.Count >= 9)
                        TauSeriesPrimary.RemoveAt(0);
                    TauSeriesPrimary.Add(textBoxRefinedPrimaryTau.RadianValue);
                }
                pictureBoxTiltCorrectionTau1.Image =
                    DrawGraph(TauSeriesPrimary.ToArray(),
                    pictureBoxTiltCorrectionTau1.Width, pictureBoxTiltCorrectionTau1.Height);
            }
            else
            {
                if (isNew)
                {
                    if (TauSeriesSecondary.Count >= 9)
                        TauSeriesSecondary.RemoveAt(0);
                    TauSeriesSecondary.Add(textBoxRefinedSecondaryTau.RadianValue);
                }
                pictureBoxTiltCorrectionTau2.Image =
                    DrawGraph(TauSeriesSecondary.ToArray(),
                    pictureBoxTiltCorrectionTau2.Width, pictureBoxTiltCorrectionTau2.Height);
            }
            Application.DoEvents();
        }

        List<double> PixelKsiSeries = new List<double>();
        private void DrawPixelKsi()
        {
            if (PixelKsiSeries.Count >= 9)
                PixelKsiSeries.RemoveAt(0);
            PixelKsiSeries.Add(textBoxRefinedPixelKsi.RadianValue);
            pictureBoxPixelKsi.Image =
                    DrawGraph(PixelKsiSeries.ToArray(),
                    pictureBoxPixelKsi.Width, pictureBoxPixelKsi.Height);
            Application.DoEvents();
        }

        List<double> PixelSizeYSeries = new List<double>();
        private void DrawPixelSizeY()
        {
            if (PixelSizeYSeries.Count >= 9)
                PixelSizeYSeries.RemoveAt(0);
            PixelSizeYSeries.Add(textBoxRefinedPixelSizeY.Value);
            pictureBoxPixelSizeY.Image =
                    DrawGraph(PixelSizeYSeries.ToArray(),
                    pictureBoxPixelSizeY.Width, pictureBoxPixelSizeY.Height);
            Application.DoEvents();
        }

        List<double> PixelSizeXSeries = new List<double>();
        private void DrawPixelSizeX()
        {
            if (PixelSizeXSeries.Count >= 9)
                PixelSizeXSeries.RemoveAt(0);
            PixelSizeXSeries.Add(textBoxRefinedPixelSizeX.Value);
            pictureBoxPixelSizeX.Image =
                    DrawGraph(PixelSizeXSeries.ToArray(),
                    pictureBoxPixelSizeX.Width, pictureBoxPixelSizeX.Height);
            Application.DoEvents();
        }

        private void buttonClearGraphs_Click(object sender, EventArgs e)
        {
            ResidualSeries = new List<double>();
            PixelSizeXSeries = new List<double>();
            PixelKsiSeries = new List<double>();
            PixelSizeYSeries = new List<double>();
            TauSeriesPrimary = new List<double>();
            TauSeriesSecondary = new List<double>();
            PhiSeriesPrimary = new List<double>();
            PhiSeriesSecondary = new List<double>();
            WaveLengthSeries = new List<double>();
            FilmDistanceSeries = new List<double>();
            EllipseCenterPrimary = new List<List<PointD>>();
            DirectSpotsPrimary = new List<PointD>();
            EllipseCenterSecondary = new List<List<PointD>>();
            DirectSpotsSecondary = new List<PointD>();

            Bitmap bmp = new Bitmap(pictureBoxPixelSizeY.Width, pictureBoxPixelSizeY.Height);
            pictureBoxResidual.Image = bmp;
            pictureBoxPixelSizeY.Image = bmp;
            pictureBoxCameraLength.Image = bmp;
            pictureBoxPixelSizeX.Image = bmp;
            pictureBoxPixelKsi.Image = bmp;
            pictureBoxTiltCorrectionPhi1.Image = bmp;
            pictureBoxTiltCorrectionTau1.Image = bmp;
            pictureBoxTiltCorrectionPhi2.Image = bmp;
            pictureBoxTiltCorrectionTau2.Image = bmp;
            pictureBoxWaveLength.Image = bmp;
            pictureBoxTiltCorrection1.Image = new Bitmap(pictureBoxTiltCorrection1.Width, pictureBoxTiltCorrection1.Height);
            pictureBoxTiltCorrection2.Image = new Bitmap(pictureBoxTiltCorrection2.Width, pictureBoxTiltCorrection2.Height);

        }

        #endregion

        private void buttonSchematicDiagram_Click(object sender, EventArgs e)
        {
            FormFindParameterGeometry formFindParameter2 = new FormFindParameterGeometry();
            formFindParameter2.ShowDialog();
        }

        private void checkBoxBackground_CheckedChanged(object sender, EventArgs e)
        {
            Fitting();
        }

        private void numericUpDownSearchRange_ValueChanged(object sender, EventArgs e)
        {
            Fitting();
        }

        private void checkBoxRefineTiltCorrection_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRefineTiltCorrection.Checked)
            {
                checkBoxCenterPosition.Checked = true;
                checkBoxCenterPosition.Enabled = false;
            }
            else
            {
                checkBoxCenterPosition.Enabled = true;
            }
        }

        /// <summary>
        /// 条件に適したピークを選ぶ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCheckPeaks_Click(object sender, EventArgs e)
        {
            var lower = numericBoxLowerThan.Value;
            var away = numericBoxAwayFrom.Value;
            if (dataGridView.Rows.Count > 1)
            {
                var pos = new List<double>[] { new List<double>(),new List<double>()};

                for (int i = 0; i < dataGridView.Rows.Count; i++)
                    for (int j = 0; j < 2; j++)
                        if (double.TryParse((string)dataGridView.Rows[i].Cells[3 + j * 2].Value, out double val))
                            pos[j].Add(val);

                for (int j = 0; j < 2; j++)
                {
                    for(int i=0; i<pos[j].Count; i++)
                    {
                        if (pos[j][i] < lower &&
                             (
                             (i == 0 && pos[j][i + 1] - pos[j][i] > away) ||
                             (i == pos[j].Count-1 && pos[j][i] - pos[j][i-1] > away) ||
                             (i != 0 && i != pos[j].Count - 1 && pos[j][i] - pos[j][i - 1] > away && pos[j][i+1] - pos[j][i] > away)
                             )
                          )
                            dataGridView.Rows[i].Cells[2 + j * 2].Value = true;
                        else
                            dataGridView.Rows[i].Cells[2 + j * 2].Value = false;


                    }

                }





            }

         
        
        
        
        }

        private void checkBoxRefinePixelSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRefinePixelSize.Checked)
            {
                checkBoxRefinePixelDistortion.Enabled = true;
            }
            else
            {
                checkBoxRefinePixelDistortion.Enabled = false;
                checkBoxRefinePixelDistortion.Checked = false;


            }

        }

        private void numericUpDownThresholdOfPeak_ValueChanged(object sender, EventArgs e)
        {
            Fitting();
        }

        private void buttonCopyToClipboard_Click(object sender, EventArgs e)
        {
            string str = "";
            str += "Wave length (0.1nm)" + "\t" + textBoxRefinedWaveLength.Text + "\t" + "+/-" + "\t" + textBoxWaveLengthDev.Text;
            str += "\r\n" + "Camera Length (mm)" + "\t" + textBoxRefinedPrimaryFilmDistance.Text + "\t" + "+/-" + "\t" + textBoxCameraLengthDev.Text;

            str += "\r\n" + "Pixel Size X (mm)" + "\t" + textBoxRefinedPixelSizeX.Text + "\t" + "+/-" + "\t" + textBoxPixelSizeXDev.Text;
            str += "\r\n" + "Pixel Size Y (mm)" + "\t" + textBoxRefinedPixelSizeY.Text + "\t" + "+/-" + "\t" + textBoxPixelSizeYDev.Text;
            str += "\r\n" + "Pixel Ksi (degree)" + "\t" + textBoxRefinedPixelKsi.Text + "\t" + "+/-" + "\t" + textBoxRefinedPixelKsiDev.Text;

            str += "\r\n" + "Primary IP tilt Phi (degree)" + "\t" + textBoxRefinedPrimaryPhi.Text + "\t" + "+/-" + "\t" + textBoxRefinedPrimaryPhiDev.Text;
            str += "\r\n" + "Primary IP tilt Tau (degree)" + "\t" + textBoxRefinedPrimaryTau.Text + "\t" + "+/-" + "\t" + textBoxRefinedPrimaryTauDev.Text;

            str += "\r\n" + "Secondary IP tilt Phi (degree)" + "\t" + textBoxRefinedSecondaryPhi.Text + "\t" + "+/-" + "\t" + textBoxRefinedSecondaryPhiDev.Text;
            str += "\r\n" + "Secondary IP tilt Tau (degree)" + "\t" + textBoxRefinedSecondaryTau.Text + "\t" + "+/-" + "\t" + textBoxRefinedSecondaryTauDev.Text;

            str += "\r\n" + "Primary Center X (pixel)" + "\t" + numericalTextBoxPrimaryCenterPositionX.Text + "\t" + "+/-" + "\t" + numericalTextBoxPrimaryCenterPositionXDev.Text; 
            str += "\r\n" + "Primary Center Y (pixel)" + "\t" + numericTextBoxPrimaryCenterPositionY.Text + "\t" + "+/-" + "\t" + numericalTextBoxPrimaryCenterPositionYDev.Text;


            str += "\r\n" + "Secondary Center X (pixel)" + "\t" + numericTextBoxSecondaryCenterPositionX.Text + "\t" + "+/-" + "\t" + numericTextBoxSecondaryCenterPositionXDev.Text;
            str += "\r\n" + "Secondary Center Y (pixel)" + "\t" + numericTextBoxSecondaryCenterPositionY.Text + "\t" + "+/-" + "\t" + numericTextBoxSecondaryCenterPositionYDev.Text; 

            Clipboard.SetDataObject(str, true);
        }

        private void buttonGetCameraLenghtFromWholePattern_Click(object sender, EventArgs e)
        {

            Crystal[] cry;
            if (checkBoxUseStandardCrystal.Checked)
                cry = crystal;
            else
                cry = flexibleCrystal;

            if (cry[0].Plane == null || cry[1].Plane == null)
                return;

            Fitting();
            //チェックされているものを設定
            for (int i = 0; i < 2; i++)
                for (int j = 0; j < cry[i].Plane.Count; j++)
                    cry[i].Plane[j].IsFittingChecked = (bool)dataGridView.Rows[j].Cells[2 + i * 2].Value;

            double fd=0, fdd=0;
           // FindParameter.FindFilmDistanceFromDiscrepancy(cry[0].Plane, cry[1].Plane, FilmDistanceDiscrepancy, ref FilmDistance[0], ref FilmDistanceDev);
            FindParameter.FindFilmDistanceFromDiscrepancy(cry[0].Plane, cry[1].Plane, FilmDistanceDiscrepancy, ref fd, ref fdd);
            
            
            if (fd > 0)
            {
                textBoxRefinedPrimaryFilmDistance.Value = FilmDistance[0] =fd;
                textBoxCameraLengthDev.Value = FilmDistanceDev =fdd;
                numericTextBoxPrimaryFilmDistance.Value = textBoxRefinedPrimaryFilmDistance.Value;
            }
        }

        private void buttonGetWaveLengthFromWholePattern_Click(object sender, EventArgs e)
        {
            //SetInitialIntegralProperty(true);

            if (crystal[0].Plane == null || crystal[1].Plane == null)
                return;

            Fitting();
            //チェックされているものを設定
            int[] checkedNo = new int[2];
            checkedNo[0] = checkedNo[1] = 0;
            for (int i = 0; i < 2; i++)
                for (int j = 0; crystal[i].Plane != null && j < crystal[i].Plane.Count; j++)
                {
                    crystal[i].Plane[j].IsFittingChecked = (bool)dataGridView.Rows[j].Cells[2 + i * 2].Value;
                    if (crystal[i].Plane[j].IsFittingChecked)
                        checkedNo[i]++;
                }

            double WaveLength1, WaveLength2, WaveLengthDev1, WaveLengthDev2;
            WaveLength1 = WaveLength2 = WaveLength;
            WaveLengthDev1 = WaveLengthDev2 = double.PositiveInfinity;

            FindParameter.FindWaveLengthFromMultiPeaks(crystal[0].Plane, ref WaveLength1, ref WaveLengthDev1);
            FindParameter.FindWaveLengthFromMultiPeaks(crystal[1].Plane, ref WaveLength2, ref WaveLengthDev2);

            if (double.IsNaN(WaveLength1) || double.IsNaN(WaveLength2) || double.IsNaN(WaveLengthDev1) || double.IsNaN(WaveLengthDev2))
                return;
            double weight1 = checkedNo[0] / WaveLengthDev1 / WaveLengthDev1;
            double weight2 = checkedNo[1] / WaveLengthDev2 / WaveLengthDev2;

            WaveLength = (WaveLength1 * weight1 + WaveLength2 * weight2) / (weight1 + weight2);
            WaveLengthDev = Math.Sqrt(1 / (weight1 + weight2));

            textBoxRefinedWaveLength.Value = WaveLength * 10;
            textBoxWaveLengthDev.Value = WaveLengthDev * 10;

            double PixelSize1, PixelSize2, PixelSizeDev1, PixelSizeDev2;
            PixelSize1 = PixelSize2 = (IP.PixSizeX + IP.PixSizeY) / 2;
            PixelSizeDev1 = PixelSizeDev2 = double.PositiveInfinity;

            FindParameter.FindPixelSizeFromMultiPeaks(crystal[0].Plane, textBoxRefinedPrimaryFilmDistance.Value, WaveLength, ref PixelSize1, ref  PixelSizeDev1);
            FindParameter.FindPixelSizeFromMultiPeaks(crystal[1].Plane, textBoxRefinedPrimaryFilmDistance.Value + FilmDistanceDiscrepancy, WaveLength, ref PixelSize2, ref  PixelSizeDev2);

            if (double.IsNaN(PixelSize1) || double.IsNaN(PixelSize2) || double.IsNaN(PixelSizeDev1) || double.IsNaN(PixelSizeDev2))
                return;
            weight1 = checkedNo[0] / PixelSizeDev1 / PixelSizeDev1;
            weight2 = checkedNo[1] / PixelSizeDev2 / PixelSizeDev2;


            double pixSize = (PixelSize1 * weight1 + PixelSize2 * weight2) / (weight1 + weight2);
            double mag = pixSize / (IP.PixSizeX + IP.PixSizeY) * 2;

            PixSizeXDev = PixSizeYDev = Math.Sqrt(1 / (weight1 + weight2));
            IP.PixSizeX *= mag;
            IP.PixSizeY *= mag;

            textBoxRefinedPixelSizeX.Text = IP.PixSizeX.ToString("f10");
            textBoxRefinedPixelSizeY.Text = IP.PixSizeY.ToString("f10");
            textBoxPixelSizeXDev.Text = textBoxPixelSizeYDev.Text = (PixSizeYDev).ToString("f10");
            textBoxPixelSizeX.Text = textBoxRefinedPixelSizeX.Text;
            textBoxPixelSizeY.Text = textBoxRefinedPixelSizeX.Text;

            textBoxWaveLength.Text = textBoxRefinedWaveLength.Text;

            buttonPrimaryGetProfile_Click(new object(), new EventArgs());
            buttonSecondaryGetProfile_Click(new object(), new EventArgs());
        }

        private void FormFindParameter_Resize(object sender, EventArgs e)
        {
            Draw();
        }

        private void pictureBoxMain_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxShowEachPeaks_CheckedChanged(object sender, EventArgs e)
        {
            flowLayoutPanelEachPeaks.Visible = checkBoxShowEachPeaks.Checked;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        /// 複数選択時に、チェックを入れ替える
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkUncheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int j = 0; j < dataGridView.Rows.Count; j++)
                for (int i = 0; i < 2; i++)
                    if (dataGridView.Rows[j].Cells[3 + i * 2].Selected)
                        dataGridView.Rows[j].Cells[2 + i * 2].Value = (bool)dataGridView.Rows[j].Cells[2 + i * 2].Value != true;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int crystalNo = 0;
            if (e.ColumnIndex == 3) crystalNo = 0;
            else if (e.ColumnIndex == 5) crystalNo = 1;
            else return;

            if (e.RowIndex >= 0)
            {
                
                if (dp[crystalNo] != null && crystal[crystalNo].Plane[e.RowIndex].MillimeterCalc != 0)
                {
                    LowerX = crystal[crystalNo].Plane[e.RowIndex].MillimeterCalc - (double)numericUpDownSearchRange.Value * 4;
                    UpperX = crystal[crystalNo].Plane[e.RowIndex].MillimeterCalc + (double)numericUpDownSearchRange.Value * 4;

                    LowerY = 0;UpperY=0;
                    for (int i = 0; i < dp[crystalNo].OriginalProfile.Pt.Count; i++)
                    {
                        double y = dp[crystalNo].OriginalProfile.Pt[i].Y * 1.1;
                        double x = dp[crystalNo].OriginalProfile.Pt[i].X;
                        if (UpperY < y && x > LowerX && x < UpperX)
                            UpperY = y;
                    }

                    SelectedCrystalIndex = crystalNo;
                    SelectedPlaneIndex = e.RowIndex;
                    Draw();
                }

            }
        }

        private void groupBoxPrimaryImage_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたとき実行される
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length == 1)
            {
                string ext = Path.GetExtension(fileName[0]).TrimStart(new char[] { '.' });
                if (ext == "img" || ext == "stl" || ext == "ccd" || ext == "ipf"
                    || ext == "png" || ext == "tif" || ext == "jpg" || ext == "bmp" || ext == "gel" || ext == "osc" || ext.StartsWith("mar")
                    || ext == "ipa" || ext.StartsWith("0") || ext == "mccd" || ext=="his")
                    formMain.ReadImage(fileName[0]);
                textBoxPrimaryFileName.Text = fileName[0];

                if (formMain.SequentialImageMode && Ring.SequentialImageIntensities.Count >= 2)
                {
                    selectSequentialImageNumber();
                    textBoxPrimaryFileName.Text += " " + formMain.FormSequentialImage.SelectedIndex.ToString();
                }
            }
        }
        private void groupBoxSecondaryImage_DragDrop(object sender, DragEventArgs e)
        {
            if (!groupBoxSecondaryImage.Enabled) return;
            //ドロップされたとき実行される
            string[] fileName =                (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length == 1)
            {
                string ext = Path.GetExtension(fileName[0]).TrimStart(new char[] { '.' });
                if (ext == "img" || ext == "stl" || ext == "ccd" || ext == "ipf"
                    || ext == "png" || ext == "tif" || ext == "jpg" || ext == "bmp" || ext == "gel" || ext == "osc" || ext.StartsWith("mar")
                    || ext == "ipa" || ext.StartsWith("0") || ext == "mccd" || ext == "his")
                    formMain.ReadImage(fileName[0]);
                textBoxSecondaryFileName.Text = fileName[0];

                if (formMain.SequentialImageMode && Ring.SequentialImageIntensities.Count >= 2)
                {
                    selectSequentialImageNumber();
                    textBoxSecondaryFileName.Text += " " + formMain.FormSequentialImage.SelectedIndex.ToString();
                }
            }
        }

        private void groupBoxParameter_DragDrop(object sender, DragEventArgs e)
        {
            //ドロップされたすべてのファイル名を取得する
            string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            if (fileName.Length == 1)
            {
                string ext = Path.GetExtension(fileName[0]).TrimStart(new char[] { '.' });
                if (fileName[0].EndsWith("prm"))
                    formMain.ReadParameter(fileName[0]);
                buttonSetInitioalParam_Click(sender, new EventArgs());

            }
        }
        private void groupBoxPrimaryImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            else

                e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
        }

        

        private void groupBoxSecondaryImage_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            else

                e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
        }

       

        private void groupBoxParameter_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy; //ドラッグされたデータ形式を調べ、ファイルのときはコピーとする
            else

                e.Effect = DragDropEffects.None;//ファイル以外は受け付けない
        }

        

     

       












    }



}

