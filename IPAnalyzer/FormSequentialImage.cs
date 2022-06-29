using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Crystallography;

namespace IPAnalyzer
{
    public partial class FormSequentialImage : Form
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
                listBox_SelectedIndexChanged(new object(), new EventArgs());
                
                listBox.SelectionMode = checkBoxMultiSelection.Checked ? SelectionMode.MultiExtended : SelectionMode.One;
                trackBar1.Enabled = !value;
                skipEvent = false;
            }
            get { return checkBoxMultiSelection.Checked; }
        }

        public bool AverageMode
        {
            set
            {
                if (checkBoxAverage.Checked != value)
                    checkBoxAverage.Checked = value;
            }
            get { return checkBoxAverage.Checked; }

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
                    
                    Ring.IntensityOriginal.Clear();
                    Ring.IntensityOriginal.AddRange(Ring.SequentialImageIntensities[selectedIndex]);

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

        private int[] selectedIndices = new int[] { };
        public int[] SelectedIndices
        {
            set
            {
                skipEvent = true;
                int selectedIndex = listBox.SelectedIndex;
                //valueに含まれているものだけを選択状態にする
                foreach (var i in Enumerable.Range(0, listBox.Items.Count).Where(n => !value.Contains(n) && listBox.GetSelected(n)))
                    listBox.SetSelected(i, false);
                foreach (var i in value.Where(n => !listBox.GetSelected(n)))
                    listBox.SetSelected(i, true);
                if (value.Contains(selectedIndex))
                    listBox.SelectedIndex = selectedIndex;
                skipEvent = false;

                for (int i = 0; i < value.Length; i++)
                    if (Ring.SequentialImageIntensities == null || value[i] < 0 || value[i] >= Ring.Intensity.Count)
                        return;
                selectedIndices = value;

                if (AverageMode || SummationMode)
                {
                    checkBoxMultiSelection.Checked = true;
                    double energy = 0;
                    for (int j = 0; j < selectedIndices.Length; j++)
                    {
                        if (Ring.ImageType == Ring.ImageTypeEnum.HDF5 && Ring.SequentialImageEnergy != null )
                            energy += Ring.SequentialImageEnergy[selectedIndices[j]] / selectedIndices.Length;
                        for (int i = 0; i < Ring.Intensity.Count; i++)
                            if (j == 0)
                                Ring.IntensityOriginal[i] = Ring.SequentialImageIntensities[selectedIndices[j]][i] / (AverageMode ? selectedIndices.Length : 1);
                            else
                                Ring.IntensityOriginal[i] += Ring.SequentialImageIntensities[selectedIndices[j]][i] / (AverageMode ? selectedIndices.Length : 1);
                    }

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
                    formMain.SetText(formMain.FileName, (AverageMode ? "Ave. of #" : "Sum. of #") + text);
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

                listBox.Items.Clear();
                for (int i = 0; i < value; i++)
                    listBox.Items.Add(formMain.FileName + "  #" + Ring.SequentialImageNames[i]);

            }
            get { return trackBar1.Maximum+1; }
        }
        #endregion

        public FormSequentialImage()
        {
            InitializeComponent();
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
            listBox_SelectedIndexChanged(new object(), new EventArgs());
            if (checkBoxAverage.Checked && checkBoxSummation.Checked)
                checkBoxSummation.Checked = false;
                
        }
        private void checkBoxSummation_CheckedChanged(object sender, EventArgs e)
        {
            listBox_SelectedIndexChanged(new object(), new EventArgs());
            if (checkBoxAverage.Checked && checkBoxSummation.Checked)
                checkBoxAverage.Checked = false;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (skipEvent) return;

            skipEvent = true;
            int[] temp = new int[listBox.SelectedIndices.Count];
            for (int i = 0; i < listBox.SelectedIndices.Count; i++)
                temp[i] = listBox.SelectedIndices[i];
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

                var numFont = new Font(listBox.Font.FontFamily, listBox.Font.Size, FontStyle.Italic);
                var numWidth = e.Graphics.MeasureString(num, numFont).Width;

                Color c = ((e.State & DrawItemState.Selected) != DrawItemState.Selected) ? Color.Blue : Color.LightGreen ;

                e.Graphics.DrawString(num, numFont, new SolidBrush(c), new RectangleF(e.Bounds.X, e.Bounds.Y, numWidth, e.Bounds.Height));
                e.Graphics.DrawString(txt, listBox.Font, new SolidBrush(e.ForeColor), new RectangleF(e.Bounds.X + numWidth, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height));
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
                listBox_SelectedIndexChanged(selectedIndex, new EventArgs());
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
}
