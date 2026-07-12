using System;
using System.Collections.Generic; //260712Cl 追加: HashSet 使用のため
using System.Drawing;
using System.Linq;
using System.Text; //260712Cl 追加: StringBuilder 使用のため
using System.Threading.Tasks; //260712Cl 追加: Parallel.For 使用のため
using System.Windows.Forms;
using Crystallography;

namespace IPAnalyzer;
public partial class FormSequentialImage : Crystallography.Controls.FormBase //260604Cl FormBase 継承に変更
{
    #region プロパティ
    public bool MultiSelection
    {
        set
        {
            skipEvent = true;
            if (checkBoxMultiSelection.Checked != value)
                checkBoxMultiSelection.Checked = value;
            checkBoxAverage.Enabled = checkBoxSummation.Enabled = checkBoxMultiSelection.Checked;
            //listBox_SelectedIndexChanged(new object(), new EventArgs()); //260712Cl skipEvent=true 中は先頭ガードで即 return する no-op のため削除

            listBox.SelectionMode = checkBoxMultiSelection.Checked ? SelectionMode.MultiExtended : SelectionMode.One;
            trackBar1.Enabled = !value;
            skipEvent = false;
        }
        get => checkBoxMultiSelection.Checked;
    }

    public bool AverageMode
    {
        set
        {
            if (checkBoxAverage.Checked != value)
                checkBoxAverage.Checked = value;
        }
        get => checkBoxAverage.Checked;
    }
    public bool SummationMode
    {
        set
        {
            if (checkBoxSummation.Checked != value)
                checkBoxSummation.Checked = value;
        }
        get => checkBoxSummation.Checked;
    }
    public FormMain formMain;
    public bool SkipCalcFreq = false;
    private int selectedIndex = -1;
    public int SelectedIndex
    {
        set
        {
            if (Ring.SequentialImageIntensities != null && Ring.SequentialImageIntensities.Count > value)
            {
                selectedIndex = value;

                skipEvent = true;
                trackBar1.Value = selectedIndex;
                if(listBox.SelectionMode!= SelectionMode.MultiExtended)
                    listBox.SelectedIndex = selectedIndex;
                skipEvent = false;
                
                Ring.IntensityOriginal = [.. Ring.SequentialImageIntensities[selectedIndex]] ;

                formMain.FlipRotate_Pollalization_Background(false);


                if (!SkipCalcFreq)
                {
                    Ring.CalcFreq();
                    formMain.SetFrequencyProfile();
                    formMain.SetStasticalInformation(false);
                }
                formMain.SetText(formMain.FileName, "#" + Ring.SequentialImageNames[selectedIndex]);

                if (Ring.SequentialImageEnergy != null && Ring.SequentialImageEnergy.Count == Ring.SequentialImageIntensities.Count)//イメージごとにエネルギーが設定されているとき
                {
                    formMain.FormProperty.WaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(Ring.SequentialImageEnergy[selectedIndex]);
                }
               
                formMain.SetInformation();


                formMain.Draw();
            }
        }
        get
        {
            if (Ring.SequentialImageIntensities == null || Ring.SequentialImageIntensities.Count < 2)
                return -1;
            else
                return selectedIndex;
        }
    }

    private int[] selectedIndices = []; //260712Cl new int[]{} → [] (Array.Empty<int>() 共有)
    public int[] SelectedIndices
    {
        set
        {
            skipEvent = true;
            int selectedIndex = listBox.SelectedIndex;
            //valueに含まれているものだけを選択状態にする
            //260712Cl value.Contains の線形探索 (O(n×m)) と Enumerable.Range/Where のイテレータ割り当てを HashSet+for に置換
            var newSelection = new HashSet<int>(value);
            for (int i = 0; i < listBox.Items.Count; i++)
                if (!newSelection.Contains(i) && listBox.GetSelected(i))
                    listBox.SetSelected(i, false);
            foreach (var i in value)
                if (!listBox.GetSelected(i))
                    listBox.SetSelected(i, true);
            if (newSelection.Contains(selectedIndex))
                listBox.SelectedIndex = selectedIndex;
            skipEvent = false;

            //260712Cl 範囲ガードの比較対象を修正 (旧: Ring.Intensity.Length=ピクセル数 と比較しており事実上素通り。value はイメージ番号)
            if (Ring.SequentialImageIntensities == null)
                return;
            foreach (var v in value)
                if (v < 0 || v >= Ring.SequentialImageIntensities.Count)
                    return;
            selectedIndices = value;

            if (AverageMode || SummationMode)
            {
                checkBoxMultiSelection.Checked = true;
                //260712Cl 除数と double[] 参照をループ外へ巻き上げ + ピクセル単位で並列化。
                //各ピクセル i の j 昇順加算は単一スレッド内で保持されるため浮動小数点結果は元コードとビット一致 (0.0+x==x)。
                //エネルギー加算は別の直列ループに分離。
                double energy = 0;
                if (Ring.ImageType == Ring.ImageTypeEnum.HDF5 && Ring.SequentialImageEnergy != null)
                    for (int j = 0; j < selectedIndices.Length; j++)
                        energy += Ring.SequentialImageEnergy[selectedIndices[j]] / selectedIndices.Length;

                double divisor = AverageMode ? selectedIndices.Length : 1;
                var srcs = Array.ConvertAll(selectedIndices, n => Ring.SequentialImageIntensities[n]);
                Parallel.For(0, Ring.Intensity.Length, i =>
                {
                    double sum = 0;
                    for (int j = 0; j < srcs.Length; j++)
                        sum += srcs[j][i] / divisor;
                    Ring.IntensityOriginal[i] = sum;
                });

                formMain.FlipRotate_Pollalization_Background(false);

                if (Ring.ImageType == Ring.ImageTypeEnum.HDF5)
                    formMain.FormProperty.WaveLength = UniversalConstants.Convert.EnergyToXrayWaveLength(energy);

                Ring.CalcFreq();

                string text = "";


                for (int i = 0; i < selectedIndices.Length; i++)
                {
                    if (i == 0)
                        text += Ring.SequentialImageNames[selectedIndices[i]];
                    else if (selectedIndices[i] == selectedIndices[i - 1] + 1)
                    {
                        if (!text.EndsWith("-"))
                            text += "-";
                        if (i == selectedIndices.Length - 1)
                            text += Ring.SequentialImageNames[selectedIndices[i]];
                    }
                    else
                    {
                        if (text.EndsWith("-"))
                            text += Ring.SequentialImageNames[selectedIndices[i - 1]];
                        text += ", " + Ring.SequentialImageNames[selectedIndices[i]];
                    }
                }
                formMain.SetText(formMain.FileName, (AverageMode ? Crystallography.Localization.Loc(en: "Ave. of #", ja: "平均 #", de: "Mittelw. von #", fr: "Moy. de #", es: "Prom. de #", pt: "Méd. de #", it: "Media di #", ru: "Сред. по #", zhHans: "# 的平均值", zhHant: "# 的平均", ko: "# 평균") : Crystallography.Localization.Loc(en: "Sum. of #", ja: "積算 #", de: "Summe von #", fr: "Somme de #", es: "Suma de #", pt: "Soma de #", it: "Somma di #", ru: "Сумма по #", zhHans: "# 的总和", zhHant: "# 的總和", ko: "# 합계")) + text); // 260626Cl Loc化
                formMain.SetStasticalInformation(false);
                formMain.SetFrequencyProfile();
                formMain.Draw();
            }
            else
                SelectedIndex = listBox.SelectedIndex;

        }
        get => selectedIndices;
    }


    public int MaximumNumber
    {
        set
        {
            trackBar1.Maximum = value - 1;
            if (value > 20)
                trackBar1.LargeChange = value / 10;
            else if (value > 3)
                trackBar1.LargeChange = 2;

            //260712Cl BeginUpdate/EndUpdate + AddRange で一括追加 (オーナードローの Items.Add ループは数千枚で O(n²) 的に遅い)
            listBox.BeginUpdate();
            listBox.Items.Clear();
            var items = new object[value];
            for (int i = 0; i < value; i++)
                items[i] = $"{formMain.FileName}  #{Ring.SequentialImageNames[i]}";
            listBox.Items.AddRange(items);
            listBox.EndUpdate();
        }

        get => trackBar1.Maximum + 1;
    }
    #endregion

    public FormSequentialImage()
    {
        InitializeComponent();
        HelpPage = "3-tools"; //260604Cl 追加
    }

    private void FormSequentialImage_FormClosing(object sender, FormClosingEventArgs e)
    {
        e.Cancel = true;
        formMain.toolStripButtonImageSequence.Checked = false;
    }

    bool skipEvent = false;

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
        if (skipEvent) return;

        if (!MultiSelection && SelectedIndex != trackBar1.Value)
        {
            skipEvent = true;
            SelectedIndex = trackBar1.Value;
            skipEvent = false;
        }
    }

    private void checkBoxMultiSelection_CheckedChanged(object sender, EventArgs e)
    {
        if (skipEvent) return;
        MultiSelection = checkBoxMultiSelection.Checked;
        
    }

    private void checkBoxAverage_CheckedChanged(object sender, EventArgs e)
    {
        listBox_SelectedIndexChanged(this, EventArgs.Empty); //260712Cl new object(),new EventArgs() を this,EventArgs.Empty に
        if (checkBoxAverage.Checked && checkBoxSummation.Checked)
            checkBoxSummation.Checked = false;

    }
    private void checkBoxSummation_CheckedChanged(object sender, EventArgs e)
    {
        listBox_SelectedIndexChanged(this, EventArgs.Empty); //260712Cl
        if (checkBoxAverage.Checked && checkBoxSummation.Checked)
            checkBoxAverage.Checked = false;
    }

    private void listBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (skipEvent) return;

        skipEvent = true;
        int[] temp = new int[listBox.SelectedIndices.Count];
        listBox.SelectedIndices.CopyTo(temp, 0); //260712Cl 手動ループを CopyTo に
        SelectedIndices = temp;

        skipEvent = false;
    }

    private void listBox_DrawItem(object sender, DrawItemEventArgs e)
    {
        //背景を描画する
        //項目が選択されている時は強調表示される
        e.DrawBackground();

        //ListBoxが空のときにListBoxが選択されるとe.Indexが-1になる
        if (e.Index > -1)
        {
            //描画する文字列の取得
            string txt = ((ListBox)sender).Items[e.Index].ToString();
            string num = "";
            if (txt.Contains(".h5") || Ring.SequentialImageEnergy!=null)
                num = e.Index.ToString("000") + ":  ";

            //文字列の描画
            //260712Cl Font/SolidBrush×2 を using 化 (旧: 未Dispose で描画のたびに GDI+ ハンドルをリークしていた)
            using var numFont = new Font(listBox.Font, FontStyle.Italic);
            var numWidth = e.Graphics.MeasureString(num, numFont).Width;

            Color c = ((e.State & DrawItemState.Selected) != DrawItemState.Selected) ? Color.Blue : Color.LightGreen;

            using var numBrush = new SolidBrush(c);
            using var foreBrush = new SolidBrush(e.ForeColor);
            e.Graphics.DrawString(num, numFont, numBrush, new RectangleF(e.Bounds.X, e.Bounds.Y, numWidth, e.Bounds.Height));
            e.Graphics.DrawString(txt, listBox.Font, foreBrush, new RectangleF(e.Bounds.X + numWidth, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
            //後始末
        }

        //フォーカスを示す四角形を描画
        e.DrawFocusRectangle();
    }

    private void listBox_KeyDown(object sender, KeyEventArgs e)
    {

        if (checkBoxMultiSelection.Checked && e.Control && e.KeyCode == Keys.A)
        {
            skipEvent = true;
            for (int i = 0; i < listBox.Items.Count; i++)
                listBox.SetSelected(i, true);
            skipEvent = false;
            listBox_SelectedIndexChanged(listBox, EventArgs.Empty); //260712Cl int の box 化と EventArgs 割り当てを回避
        }
    }

    private void RadioButtonGetProfileOnlyTopmost_CheckedChanged(object sender, EventArgs e)
    {
        if (skipEvent) return;

        skipEvent = true;

        if (radioButtonGetProfileAllImages.Checked)
        {
            formMain.toolStripMenuItemAllSequentialImages.Checked = true;
            formMain.toolStripMenuItemSelectedSequentialImages.Checked = false;
        }
        else if (radioButtonGetProfileOnlyTopmost.Checked)
        {
            formMain.toolStripMenuItemAllSequentialImages.Checked = false;
            formMain.toolStripMenuItemSelectedSequentialImages.Checked = false;
        }
        else if(radioButtonGetProfileSelectedImages.Checked)
        {
            formMain.toolStripMenuItemAllSequentialImages.Checked = false;
            formMain.toolStripMenuItemSelectedSequentialImages.Checked = true;
        }
        skipEvent = false;
    }

    internal void setRadio()
    {
        if (skipEvent) return;
        skipEvent = true;
        if (formMain.toolStripMenuItemAllSequentialImages.Checked)
            radioButtonGetProfileAllImages.Checked = true;
        else if (formMain.toolStripMenuItemSelectedSequentialImages.Checked)
            radioButtonGetProfileSelectedImages.Checked = true;
        else
            radioButtonGetProfileOnlyTopmost.Checked = true;
        skipEvent = false;
    }
  
}
