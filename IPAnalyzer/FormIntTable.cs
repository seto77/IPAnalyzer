using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Crystallography;

namespace IPAnalyzer
{
    /// <summary>
    /// Form2 の概要の説明です。
    /// </summary>
    public partial class FormIntTable : System.Windows.Forms.Form
    {
        public FormMain formMain;
        public FormIntTable()
        {
            //
            // Windows フォーム デザイナ サポートに必要です。
            //
            InitializeComponent();

            //
            // TODO: InitializeComponent 呼び出しの後に、コンストラクタ コードを追加してください。
            //
        }


        public void SetData(int SrcX, int SrcY)
        {
            if (Ring.Intensity == null) return;
            int Length = (int)numericUpDownMatrixNum.Value;
            int StartX, StartY;
            int t = Length / 2;
            StartX = SrcX - t;
            StartY = SrcY - t;
            int[,] intensity = new int[Length, Length];
            Size size = formMain.SrcImgSize;
            for (int j = 0; j < Length; j++)
                for (int i = 0; i < Length; i++)
                {
                    if (StartX + i >= 0 && StartX + i < size.Width && StartY + j >= 0 && StartY + j < size.Height)
                        intensity[i, j] = (int)Ring.Intensity[(StartX + i) + size.Width * (StartY + j)];
                    else
                        intensity[i, j] = -1;
                }
            DataSet dataSet = new DataSet(" ");
            DataTable dataTable = dataSet.Tables.Add("");

            dataTable.Columns.Add(" ");//先に一列加えておいて
            for (int i = StartX; i < StartX + Length; i++)
            {
                dataTable.Columns.Add(i.ToString(), typeof(int));//データ列
            }

            // テーブルにデータを追加
            object[] obj = new Object[Length + 1];
            for (int j = 0; j < Length; j++)
            {
                for (int i = 1; i <= Length; i++)
                    obj[i] = intensity[i - 1, j];
                obj[0] = StartY + j;
                dataTable.Rows.Add(obj);
            }

            // データグリッドの行の追加と削除、データ編集を不許可にする
            dataTable.DefaultView.AllowNew = false;
            dataTable.DefaultView.AllowDelete = false;
            dataTable.DefaultView.AllowEdit = false;

            // データグリッドにテーブルを表示する
            dataGrid.SetDataBinding(dataTable.DefaultView, "");

            int max = int.MinValue;
            int tempI, tempJ; tempI = tempJ = 0;
            int tempX, tempY; tempX = tempY = 0;
            for (int i = 0; i < Length; i++)
                for (int j = 0; j < Length; j++)
                {
                    if (max < intensity[i, j])
                    {
                        max = intensity[i, j];
                        tempX = i + StartX;
                        tempY = j + StartY;
                        tempI = i;
                        tempJ = j;
                    }
                }
            textBoxResult.Text = tempY.ToString() + "," + tempX.ToString() + "," + intensity[tempI, tempJ].ToString();

            string str = "";
            for (int j = 0; j < Length; j++)
            {
                for (int i = 0; i < Length; i++)
                {
                    str += intensity[i, j].ToString() + "\t";
                }
                str += "\r\n";
            }
            Clipboard.SetDataObject(str, true);
        }


        private void FormIntTable_Load(object sender, System.EventArgs e)
        {
        }

        private void numericUpDownMatrixNum_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void buttonAdd_Click(object sender, System.EventArgs e)
        {
            textBoxList.Text += textBoxResult.Text + "\r\n";
        }

        private void FormIntTable_FormClosed(object sender, FormClosedEventArgs e)
        {

        }

        private void FormIntTable_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            formMain.toolStripButtonIntensityTable.Checked = false;
        }



    }
}
