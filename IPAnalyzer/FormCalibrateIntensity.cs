using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Buffers.Binary; // 261111Cl 追加
using System.Runtime.InteropServices; // 261111Cl 追加
using Crystallography;

namespace IPAnalyzer
{
    public partial class FormCalibrateIntensity : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
    {
        public FormMain formMain;


        public FormCalibrateIntensity()
        {
            InitializeComponent();
            HelpPage = "3-tools"; //260604Cl 追加
        }

        private void buttonOpenFile_Click(object sender, EventArgs e)
        {
            using var dlg = new OpenFileDialog { Filter = "Fuji[*.img]; R-AXIS4[*.stl]; Bruker CCD[*.ccd]; IP Display(PF Bl4b1)[*.ipf]|*.img;*.stl;*.ccd;*.ipf" }; //260712Cl using宣言+初期化子
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (((Button)sender).Name == buttonOpenFile1.Name)
                    textBoxFile1.Text = dlg.FileName;
                else
                    textBoxFile2.Text = dlg.FileName;
                formMain.ReadImage(dlg.FileName);
            }
        }
        private ushort[] getRawIntensity(string str)
        {
            if (str.EndsWith("stl"))
            {//Rigaku R-Axis4
                //260712Cl SetBytePosition が ref br を Close→再生成するため using 宣言不可。try/finally で例外時のリークを防止
                var br = new BinaryReader(new FileStream(str, FileMode.Open, FileAccess.Read));
                try
                {
                    FormMain.SetBytePosition(str, ref br, 288);
                    string target = new string(br.ReadChars(4));//Target
                    float wl = ImageIO.convertToSingle(br);//Wavelength (A)
                    br.ReadBytes(48);
                    float camera_len = br.ReadSingle();//Camera length (mm)
                    br.ReadBytes(420);
                    int num_x_pixs = ImageIO.convertToInt(br);//Number of pixel X
                    int num_y_pixs = ImageIO.convertToInt(br);//Number of pixel Y
                    int length = num_x_pixs * num_y_pixs;
                    FormMain.SetBytePosition(str, ref br, num_x_pixs * 2);
                    ushort[] intensity = new ushort[length];
                    //for (int y = 0; y < num_y_pixs; y++)
                    //    for (int x = 0; x < num_x_pixs; x++)
                    //    {
                    //        int i = (num_y_pixs - y - 1) * num_x_pixs + x;
                    //        intensity[i] = (ushort)(256 * br.ReadByte() + br.ReadByte());
                    //    }
                    // 261111Cl 変更: 1 画素ごとに ReadByte を 2 回 → 全画素を ReadBytes で一括して読み、行ごとにビッグエンディアンから変換する (上下反転の並びは旧と同じ)
                    byte[] raw = br.ReadBytes(length * 2);
                    if (raw.Length < length * 2)
                        throw new EndOfStreamException(); // 旧の ReadByte と同じく、データが足りなければ例外
                    var src = MemoryMarshal.Cast<byte, ushort>(raw.AsSpan());
                    for (int y = 0; y < num_y_pixs; y++)
                    {
                        var srcRow = src.Slice(y * num_x_pixs, num_x_pixs);
                        var dstRow = intensity.AsSpan((num_y_pixs - y - 1) * num_x_pixs, num_x_pixs);
                        if (BitConverter.IsLittleEndian)
                            BinaryPrimitives.ReverseEndianness(srcRow, dstRow);
                        else
                            srcRow.CopyTo(dstRow);
                    }
                    return intensity;
                }
                finally { br.Close(); }
            }
            else return [];
        }

        double total = 0;
        private double[] getConvertTable(List<PointD> controlPoint, uint max)
        {
            double[] convertTable = new double[max+1];

            //for(int i = 0 ; i< controlPoint.Count-1 ; i++)
            //    for(int j= (int)controlPoint[i].X ; j < (int)controlPoint[i+1].X && j < max ; j++)
            //        convertTable[j] = (j - controlPoint[i].X) / (controlPoint[i + 1].X - controlPoint[i].X) * (controlPoint[i + 1].Y - controlPoint[i].Y) + controlPoint[i].Y;
            // 261111Cl 変更: 旧は j < max のため、最大の画素値 (飽和画素であることが多い) の表が 0 のままになり、その画素に大きな罰が付いて制御点が動かなかった。
            // 最大値まで表を作る。各区間は [X_i, X_{i+1}) で、最後の区間だけ右端 X_{i+1} も含める (高ビット画素があると最大値が最後の制御点になるため)
            for (int i = 0; i < controlPoint.Count - 1; i++)
            {
                int end = (int)controlPoint[i + 1].X + (i == controlPoint.Count - 2 ? 1 : 0);
                for (int j = (int)controlPoint[i].X; j < end && j <= max; j++)
                    convertTable[j] = controlPoint[i + 1].X == controlPoint[i].X ? controlPoint[i].Y // 幅 0 の最後の区間 (最後の制御点が重複) は 0/0 を避ける
                        : (j - controlPoint[i].X) / (controlPoint[i + 1].X - controlPoint[i].X) * (controlPoint[i + 1].Y - controlPoint[i].Y) + controlPoint[i].Y;
            }
            if (total == 0)
                for (int i = 0; i < convertTable.Length; i++)
                    total += convertTable[i];
            else
            {
                double tempTotal = 0;
                for (int i = 0; i < convertTable.Length; i++)
                    tempTotal += convertTable[i];
                for (int i = 0; i < convertTable.Length; i++)
                    convertTable[i]*= total/tempTotal;

            }
            
            return convertTable;
        }

        private void buttonCalibrate_Click(object sender, EventArgs e)
        {
            total = 0; //260712Cl 実行毎にリセット (フィールドのため前回実行の合計値へ正規化されるバグを防止)
            ushort[] image1 = getRawIntensity(textBoxFile1.Text);
            ushort[] image2 = getRawIntensity(textBoxFile2.Text);
            //260712Cl 空配列(.stl以外)・サイズ不一致のガードを追加 (旧: image2[i] のインデックスで IndexOutOfRange か、空配列で 300 反復空回り)
            if (image1.Length == 0 || image1.Length != image2.Length)
            {
                MessageBox.Show(Crystallography.Localization.Loc(en: "Please specify two .stl images of the same size.", ja: "同一サイズの 2 つの .stl イメージを指定してください。"));
                return;
            }
            //260712Cl 手動ループを SimdLinq の Max に (ushort[] は SIMD 化。空配列ガード済みで例外なし)
            ushort maxRawIntensity = Math.Max(image1.Max(), image2.Max());
            // 261112Cl 追加 (作者判断): 飽和画素 (2 枚を通じた最大の画素値) を含む組は残差から除く。真の強度が分からず当てはめを偏らせるため
            //   (合成データで真の変換との隔たり 0.0405→約 0.009)。表 (getConvertTable) は従来どおり最大値まで作る。除くと組が残らないときは除かない
            bool skipSaturated = false;
            for (int i = 0; i < image1.Length && !skipSaturated; i++)
                skipSaturated = image1[i] != maxRawIntensity && image2[i] != maxRawIntensity;

            double[] convertTableCurrent = new double[maxRawIntensity+1];
            Profile initialProfile = new Profile();
            Profile destProfile = new Profile();
            for (uint i = 0; i <= maxRawIntensity; i++)
            {
                if (i > 0x7fff)
                    convertTableCurrent[i] = (uint)((i & 0x7fff) * 32);
                else
                    convertTableCurrent[i] = i;
                initialProfile.Pt.Add(new PointD(i, convertTableCurrent[i]));
                destProfile.Pt.Add(new PointD(i, convertTableCurrent[i]));
            }
            graphControl1.Profile = initialProfile;


            graphControl1.AddProfile(destProfile);


            //現在の残差を計算
            double temp1=0,temp2=0;
            for (int i = 0; i < image1.Length; i++)
                {
                    if (skipSaturated && (image1[i] == maxRawIntensity || image2[i] == maxRawIntensity)) continue; // 261112Cl 追加: 飽和の組を除く
                    temp1 += convertTableCurrent[image1[i]] * convertTableCurrent[image2[i]];
                    temp2 +=  convertTableCurrent[image1[i]] * convertTableCurrent[image1[i]];
                }
            double A= temp1/temp2;
            double ResidualSquareCurrent = 0, ResidualSquareNew = 0;
            for (int i = 0; i < image1.Length; i++)
                {
                    if (skipSaturated && (image1[i] == maxRawIntensity || image2[i] == maxRawIntensity)) continue; // 261112Cl 追加: 飽和の組を除く
                    double temp = A*convertTableCurrent[image1[i]] -convertTableCurrent[image2[i]];
                    ResidualSquareCurrent += temp*temp;
                }

            //駆動点を16個作る
            List<PointD> controlPoints = [];
            int step = maxRawIntensity / 16 + 1;
            for (int i = 0; i <= maxRawIntensity; i += step)
                controlPoints.Add(new PointD(i, convertTableCurrent[i]));
            controlPoints.Add(new PointD(convertTableCurrent.Length - 1, convertTableCurrent[convertTableCurrent.Length - 1]));
            controlPoints.Add(new PointD(32767,32767));
            controlPoints.Add(new PointD(32768,0));
            controlPoints.Sort();

            #region 261111Cl 追加: 区間モーメントの集計 (残差の計算を画素数に依存しない形にする)
            // 最適化の間、制御点の X は変わらず Y だけが動く。getConvertTable の表は、区間 k (画素値 v が X_k ≤ v < X_{k+1} かつ v ≤ max。最後の区間は v = X_{k+1} も含む) で
            //   t(v) = s·(Y_k + β_k·(v − X_k)),  β_k = (Y_{k+1} − Y_k)/(X_{k+1} − X_k),  s = 表の合計を total に揃える係数
            // の一次式になる (261111Cl 変更: 旧は v < max で、v = max は t = 0 だった)。よって S₁ = Σt(a)², S₁₂ = Σt(a)t(b), S₂ = Σt(b)²
            // (和は全画素 (261112Cl: 飽和の組を除く)。a = image1, b = image2) は、区間ごと・区間の組ごとの 画素数, Σda, Σdb, Σda², Σdb², Σda·db (da = a − X_σ, db = b − X_τ)
            // から求まる。これらは整数なので、全画素を 1 回だけ走査して long で正確に集計しておく。
            // 残差は旧の Σ(A·t(a) − t(b))² を展開した A²S₁ − 2A·S₁₂ + S₂ (A = S₁₂/S₁)。
            int nSeg = controlPoints.Count - 1;
            var segX = new int[nSeg];
            var segOf = new int[maxRawIntensity + 1]; // 画素値 → 区間の番号 (-1 は表の値が 0)
            Array.Fill(segOf, -1);
            for (int k = 0; k < nSeg; k++)
            {
                segX[k] = (int)controlPoints[k].X;
                //for (int j = (int)controlPoints[k].X; j < (int)controlPoints[k + 1].X && j < maxRawIntensity; j++) // getConvertTable と同じ範囲・同じ上書き順
                // 261111Cl 変更: getConvertTable の修正に合わせ、最大値まで (最後の区間は右端も含めて) 区間に入れる
                int end = (int)controlPoints[k + 1].X + (k == nSeg - 1 ? 1 : 0);
                for (int j = (int)controlPoints[k].X; j < end && j <= maxRawIntensity; j++) // getConvertTable と同じ範囲・同じ上書き順
                    segOf[j] = k;
            }
            // 表の合計 (getConvertTable の total / tempTotal) 用: 区間ごとの画素値の個数と Σ(v − X_k)
            var tabCount = new long[nSeg];
            var tabSum = new long[nSeg];
            for (int j = 0; j <= maxRawIntensity; j++)
            {
                int s = segOf[j];
                if (s >= 0) { tabCount[s]++; tabSum[s] += j - segX[s]; }
            }
            // 画素のモーメント (image1 と image2 の区間ごと、および区間の組ごと)
            var cnt1 = new long[nSeg]; var sum1 = new long[nSeg]; var sq1 = new long[nSeg];
            var cnt2 = new long[nSeg]; var sum2 = new long[nSeg]; var sq2 = new long[nSeg];
            var cnt12 = new long[nSeg * nSeg]; var sumA12 = new long[nSeg * nSeg]; var sumB12 = new long[nSeg * nSeg]; var prod12 = new long[nSeg * nSeg];
            for (int i = 0; i < image1.Length; i++)
            {
                if (skipSaturated && (image1[i] == maxRawIntensity || image2[i] == maxRawIntensity)) continue; // 261112Cl 追加: 飽和の組を除く (上の初期残差と同じ)
                int sa = segOf[image1[i]], sb = segOf[image2[i]];
                long da = 0, db = 0;
                if (sa >= 0) { da = image1[i] - segX[sa]; cnt1[sa]++; sum1[sa] += da; sq1[sa] += da * da; }
                if (sb >= 0) { db = image2[i] - segX[sb]; cnt2[sb]++; sum2[sb] += db; sq2[sb] += db * db; }
                if (sa >= 0 && sb >= 0)
                {
                    int idx = sa * nSeg + sb;
                    cnt12[idx]++; sumA12[idx] += da; sumB12[idx] += db; prod12[idx] += da * db;
                }
            }
            var yk = new double[nSeg];
            var bk = new double[nSeg];
            #endregion

            // 261111Cl 追加: 表の合計の基準 total を、ずらす前の制御点の表から決める (getConvertTable は total == 0 のとき表の合計を total に入れる)。
            // 旧は最初の試行 (制御点 0 を −100 ずらした表) の合計が total になり、初期の残差 (ずらさない表) と尺度がずれていた
            getConvertTable(controlPoints, maxRawIntensity);

            double bestY=0;

            List<double> residualRecorder = [];
            double[] convertTableNew;
            for(int m = 0 ; m<300;m++){
                for (int n = 0; n < controlPoints.Count; n++)
                {
                    double initialY = controlPoints[n].Y;
                    bestY = double.NaN;
                    for (double y = initialY - 100; y <= initialY + 100; y += 50)
                    {
                        //convertTableCurrent = getConvertTable(controlPoints, maxRawIntensity);

                        //controlPoints[n].Y = y;
                        controlPoints[n] = new PointD(controlPoints[n].X, y);
                        #region 261111Cl 変更前: 試行ごとに表を作り、全画素を 2 パス走査 (300 反復 × 制御点 × 5 試行)
                        //convertTableNew = getConvertTable(controlPoints, maxRawIntensity);
                        //
                        //temp1 = 0; temp2 = 0;
                        //for (int i = 0; i < image1.Length; i++)
                        //{
                        //    temp1 += convertTableNew[image1[i]] * convertTableNew[image2[i]];
                        //    temp2 += convertTableNew[image1[i]] * convertTableNew[image1[i]];
                        //}
                        //A = temp1 / temp2;
                        //ResidualSquareNew = 0;
                        //for (int i = 0; i < image1.Length; i++)
                        //{
                        //    double temp = A * convertTableNew[image1[i]] - convertTableNew[image2[i]];
                        //    ResidualSquareNew += temp * temp;
                        //}
                        #endregion
                        // 261111Cl 変更: 上で集計した区間モーメントから残差を計算する (区間数² の計算。画素数に依存しない)。結果は丸め誤差の範囲で旧と一致
                        double tableSum = 0, s1 = 0, s2 = 0, s12 = 0;
                        for (int k = 0; k < nSeg; k++)
                        {
                            double dx = controlPoints[k + 1].X - controlPoints[k].X;
                            yk[k] = controlPoints[k].Y;
                            bk[k] = dx != 0 ? (controlPoints[k + 1].Y - controlPoints[k].Y) / dx : 0; // 幅 0 の区間は画素を含まない (NaN を持ち込まない)
                            tableSum += tabCount[k] * yk[k] + tabSum[k] * bk[k];
                            s1 += yk[k] * yk[k] * cnt1[k] + 2 * yk[k] * bk[k] * sum1[k] + bk[k] * bk[k] * sq1[k];
                            s2 += yk[k] * yk[k] * cnt2[k] + 2 * yk[k] * bk[k] * sum2[k] + bk[k] * bk[k] * sq2[k];
                        }
                        for (int sa = 0; sa < nSeg; sa++)
                            for (int sb = 0; sb < nSeg; sb++)
                            {
                                int idx = sa * nSeg + sb;
                                if (cnt12[idx] != 0)
                                    s12 += yk[sa] * yk[sb] * cnt12[idx] + yk[sa] * bk[sb] * sumB12[idx] + bk[sa] * yk[sb] * sumA12[idx] + bk[sa] * bk[sb] * prod12[idx];
                            }
                        // getConvertTable と同じく、最初の 1 回で total を決め (このときは s = 1)、以降は表の合計を total に揃える
                        // (261111Cl: total は反復の前に決めてあるので、total == 0 の分岐は表の合計が 0 になる退化した場合だけ)
                        double scale = 1;
                        if (total == 0)
                            total = tableSum;
                        else
                            scale = total / tableSum;
                        A = s12 / s1; // s 倍しても変わらない
                        ResidualSquareNew = scale * scale * (A * A * s1 - 2 * A * s12 + s2);

                        if (ResidualSquareNew < ResidualSquareCurrent)
                        {
                            ResidualSquareCurrent = ResidualSquareNew;
                            bestY = y;
                        }

                    }
                    if (double.IsNaN(bestY))
                        //controlPoints[n].Y = initialY;
                        controlPoints[n] = new PointD(controlPoints[n].X, initialY);
                    else
                        //controlPoints[n].Y = bestY;
                        controlPoints[n] = new PointD(controlPoints[n].X, bestY);
                    Application.DoEvents();
                }
                
                residualRecorder.Add(ResidualSquareNew);
                if(residualRecorder.Count>10)
                    residualRecorder.RemoveAt(0);

                convertTableNew = getConvertTable(controlPoints, maxRawIntensity);
                Profile currentProfile = new Profile();
                for (int i = 0; i < convertTableNew.Length; i++)
                    currentProfile.Pt.Add(new PointD(i, convertTableNew[i]));
                graphControl1.Profile = currentProfile;
                graphControl1.Draw();

                Application.DoEvents();
 

            }
            
        }




    }

}