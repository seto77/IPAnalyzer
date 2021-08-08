using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IPAnalyzer
{
    public partial class FormParameterOption : Form
    {
        public FormMain FormMain;
        public bool CameraModeChecked { get { return checkBoxCameraMode.Checked; } set { checkBoxCameraMode.Checked = value; } }
        public bool WaveLengthChecked { get { return checkBoxWaveLength.Checked; } set { checkBoxWaveLength.Checked = value; } }
        public bool CameraLengthChecked { get { return checkBoxCameraLength.Checked; } set { checkBoxCameraLength.Checked = value; } }
        public bool PixelShapeChecked { get { return checkBoxPixelShape.Checked; } set { checkBoxPixelShape.Checked = value; } }
        public bool CenterPositionChecked { get { return checkBoxCenterPosition.Checked; } set { checkBoxCenterPosition.Checked = value; } }
        public bool TiltCorrectionChecked { get { return checkBoxTiltCorrection.Checked; } set { checkBoxTiltCorrection.Checked = value; } }
        public bool SphericalCorrectionChecked { get { return checkBoxSphericalCorrection.Checked; } set { checkBoxSphericalCorrection.Checked = value; } }
        public bool GandolfiRadiusChecked { get { return checkBoxGandolfiRadius.Checked; } set { checkBoxGandolfiRadius.Checked = value; } }
        public bool IntegralPropertyChecked { get { return checkBoxInetgralProperty.Checked; } set { checkBoxInetgralProperty.Checked = value; } }
        public bool IntegralRegionChecked { get { return checkBoxIntegralRegion.Checked; } set { checkBoxIntegralRegion.Checked = value; } }

        public void AllCheck()
        {
            CameraModeChecked =
            WaveLengthChecked =
            CameraLengthChecked =
            PixelShapeChecked =
            CenterPositionChecked =
            TiltCorrectionChecked =
            SphericalCorrectionChecked =
            GandolfiRadiusChecked =
            IntegralPropertyChecked =
            IntegralRegionChecked = true;
        }



        public FormParameterOption()
        {
            InitializeComponent();
        }

        private void FormParameterOption_Load(object sender, EventArgs e)
        {

        }
    }
}
