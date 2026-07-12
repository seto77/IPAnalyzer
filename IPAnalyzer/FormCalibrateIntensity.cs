using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
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
                    for (int y = 0; y < num_y_pixs; y++)
                        for (int x = 0; x < num_x_pixs; x++)
                        {
                            int i = (num_y_pixs - y - 1) * num_x_pixs + x;
                            intensity[i] = (ushort)(256 * br.ReadByte() + br.ReadByte());
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

            for(int i = 0 ; i< controlPoint.Count-1 ; i++)
                for(int j= (int)controlPoint[i].X ; j < (int)controlPoint[i+1].X && j < max ; j++)
                    convertTable[j] = (j - controlPoint[i].X) / (controlPoint[i + 1].X - controlPoint[i].X) * (controlPoint[i + 1].Y - controlPoint[i].Y) + controlPoint[i].Y;
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
                    temp1 += convertTableCurrent[image1[i]] * convertTableCurrent[image2[i]];
                    temp2 +=  convertTableCurrent[image1[i]] * convertTableCurrent[image1[i]];
                }
            double A= temp1/temp2;
            double ResidualSquareCurrent = 0, ResidualSquareNew = 0;
            for (int i = 0; i < image1.Length; i++)
                {
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
                        convertTableNew = getConvertTable(controlPoints, maxRawIntensity);

                        temp1 = 0; temp2 = 0;
                        for (int i = 0; i < image1.Length; i++)
                        {
                            temp1 += convertTableNew[image1[i]] * convertTableNew[image2[i]];
                            temp2 += convertTableNew[image1[i]] * convertTableNew[image1[i]];
                        }
                        A = temp1 / temp2;
                        ResidualSquareNew = 0;
                        for (int i = 0; i < image1.Length; i++)
                        {
                            double temp = A * convertTableNew[image1[i]] - convertTableNew[image2[i]];
                            ResidualSquareNew += temp * temp;
                        }

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