using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Crystallography
{
    /// <summary>
    /// Crystal �̊T�v�̐����ł��B
    /// </summary>
    [Serializable()]
    public class Crystal : IEquatable<Crystal>, ICloneable, IComparable<Crystal>
    {
        public object Clone()
        {
            Crystal crystal = (Crystal)this.MemberwiseClone();
            crystal.Atoms = new Atoms[Atoms.Length];
            for (int i = 0; i < Atoms.Length; i++)
                crystal.Atoms[i] = (Atoms)Atoms[i].Clone();
            //crystal.EOSCondition = this.EOSCondition.Clone();
            crystal.ElasticStiffnessArray = this.ElasticStiffnessArray;

            return crystal;
        }

        public double Residual = 0;

        public int CompareTo(Crystal o) => Residual.CompareTo(o.Residual);

        public bool Equals(Crystal o)
        {
            if (A == o.A && B == o.B && C == o.C && Alpha == o.Alpha && Beta == o.Beta && Gamma == o.Gamma &&
                   SymmetrySeriesNumber == o.SymmetrySeriesNumber && Name == o.Name && JournalName == o.JournalName && PublSectionTitle == o.PublSectionTitle && JournalName == o.JournalName && ChemicalFormulaSum == o.ChemicalFormulaSum
                   && Density == o.Density)
                if (Atoms.Length == o.Atoms.Length)
                    for (int l = 0; l < Atoms.Length; l++)
                        if (Atoms[l].X == o.Atoms[l].X && Atoms[l].Y == o.Atoms[l].Y && Atoms[l].Z == o.Atoms[l].Z &&
                            Atoms[l].Occ == o.Atoms[l].Occ && Atoms[l].Label == o.Atoms[l].Label && Atoms[l].SubNumberElectron == o.Atoms[l].SubNumberElectron)
                            return true;
            return false;
        }

        #region �v���p�e�B�A�t�B�[���h

        public Bound[] Bounds;

        public LatticePlane[] LatticePlanes;

        [NonSerialized]
        [XmlIgnore]
        public bool FlexibleMode = false;

        /// <summary>
        ///
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Plane> Plane;

        /// <summary>
        /// ���x�N�g���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfAxis = new();

        /// <summary>
        /// �ʃx�N�g���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfPlane = new();

        /// <summary>
        /// �t�i�q�_�x�N�g�� (kinematical)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfG = new();

         /// <summary>
        /// �e�r���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfG_KikuchiLine = new();

        /// <summary>
        /// �Ƀx�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public List<Vector3D> VectorOfPole = new();

        /// <summary>
        /// �x�[�e�@�ɂ�铮�͊w��܂�񋟂���t�B�[���h
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public BetheMethod Bethe;

        [NonSerialized]
        [XmlIgnore]
        public double DiffractionPeakIntensity = -1;

        public double A, B, C, Alpha, Beta, Gamma;	//�i�q�萔
        public double A_err, B_err, C_err, Alpha_err, Beta_err, Gamma_err;  //�i�q�萔�̌덷
        public (double A, double B, double C, double Alpha, double Beta, double Gamma) CellValue => (A, B, C, Alpha, Beta, Gamma);

        [NonSerialized]
        [XmlIgnore]
        public double InitialA, InitialB, InitialC, InitialAlpha, InitialBeta, InitialGamma;    //�i�q�萔

        [NonSerialized]
        [XmlIgnore]
        public double InitialA_err, InitialB_err, InitialC_err, InitialAlpha_err, InitialBeta_err, InitialGamma_err;    //�i�q�萔�̌덷

        [NonSerialized]
        [XmlIgnore]
        public double CellVolumeSqure;

        [NonSerialized]
        [XmlIgnore]
        private double sigma11, sigma22, sigma33, sigma23, sigma31, sigma12;

        /// <summary>
        /// �P�ʊi�q�̐�(nm^3)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public double Volume, Volume_err;

        /// <summary>
        /// a���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D A_Axis;

        /// <summary>
        /// b���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D B_Axis;

        /// <summary>
        /// c���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D C_Axis;

        /// <summary>
        /// a*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D A_Star;

        /// <summary>
        /// b*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D B_Star;

        /// <summary>
        /// c*���x�N�g��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Vector3D C_Star;

        public Matrix3D RotationMatrix = new Matrix3D();

        //public Color color;
        public int Argb;

        public bool Reserved = false;//�ی삳��錋���ł��邩�ǂ���

        [NonSerialized]
        [XmlIgnore]
        public double Consistency, VolumeRatio, WeightRatio, MolRatio;//fittingForm�̂Ƃ���Ŏg�p

        [NonSerialized]
        [XmlIgnore]
        public double WeightPerFormula;

        [NonSerialized]
        [XmlIgnore]
        public double Density, Density_err;//���x

        public string Name = "";
        public string Note = "";

        public string PublAuthorName = "";

        public string PublSectionTitle = "";

        public int SymmetrySeriesNumber = 0;

        public string Journal;//�ׂ����������Ȃ��ꍇ����������B��������Ƃ��͈ȉ����g���B
        public string JournalName = "";
        public string JournalVolume = "";
        public string JournalIssue = "";
        public string JournalYear = "";
        public string JournalPageFirst = "";
        public string JournalPageLast = "";

        [NonSerialized]
        [XmlIgnore]
        public string ChemicalFormulaSum = "";//�v�Z�\�ȏꍇ�́B

        [NonSerialized]
        [XmlIgnore]
        public string ChemicalFormulaStructural = "";

        [NonSerialized]
        [XmlIgnore]
        public int ChemicalFormulaZ;

        /// <summary>
        /// ���f���z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public string[] ElementName;

        /// <summary>
        /// ���f�ԍ��z��
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public double[] ElementNum;

        /// <summary>
        /// �Ώ̐�
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Symmetry Symmetry;

        /// <summary>
        /// �t�i�q�s�� (1�s�ڂ�a*, 2�s�ڂ�b*, 3�s�ڂɂ�*)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Matrix3D MatrixInverse = new();

        /// <summary>
        /// ���i�q�s�� (1��ڂ�a, 2��ڂ�b, 3��ڂɂ�)
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public Matrix3D MatrixReal = new();

        /// <summary>
        /// ���q�̏�����舵��Atoms�N���X�̔z��
        /// </summary>
        public Atoms[] Atoms = Array.Empty<Atoms>();

        /// <summary>
        /// ���q�̏�����舵��Atoms�N���X��ParallelQuery
        /// </summary>
        [NonSerialized]
        [XmlIgnore]
        public ParallelQuery<Atoms> AtomsP;

        /// <summary>
        /// �����̏�����舵��Bond�N���X�̔z��
        /// </summary>
        public Bonds[] Bonds = Array.Empty<Bonds>();

        /// <summary>
        /// �i�q�c�݃e���\��
        /// </summary>
        public Matrix3D Strain = new(0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>
        /// ���̓e���\��
        /// </summary>
        public Matrix3D Stress = new(0, 0, 0, 0, 0, 0, 0, 0, 0);

        /// <summary>
        /// �q���萔
        /// </summary>
        public double HillCoefficient = 0;

        /// <summary>
        /// �e���萔 (�ۑ��p)
        /// </summary>
        public double[] ElasticStiffnessArray = new double[21];

        /// <summary>
        /// �e���萔�}�g���b�N�X
        /// </summary>
        [XmlIgnore]
        public double[,] ElasticStiffness
        {
            set
            {
                ElasticStiffnessArray = new double[]{
                 value[0, 0],value[0, 1], value[0, 2] ,value[0, 3] , value[0, 4] ,value[0, 5] ,
                 value[1, 1], value[1, 2] ,value[1, 3] , value[1, 4] ,value[1, 5] ,
                 value[2, 2] ,value[2, 3] , value[2, 4] ,value[2, 5] ,
                 value[3, 3] , value[3, 4] ,value[3, 5] ,
                 value[4, 4] ,value[4, 5] ,
                  value[5, 5]
                };
            }
            get
            {
                var mtx = new double[6, 6];
                mtx[0, 0] = ElasticStiffnessArray[0];
                mtx[0, 1] = mtx[1, 0] = ElasticStiffnessArray[1];
                mtx[0, 2] = mtx[2, 0] = ElasticStiffnessArray[2];
                mtx[0, 3] = mtx[3, 0] = ElasticStiffnessArray[3];
                mtx[0, 4] = mtx[4, 0] = ElasticStiffnessArray[4];
                mtx[0, 5] = mtx[5, 0] = ElasticStiffnessArray[5];
                mtx[1, 1] = ElasticStiffnessArray[6];
                mtx[1, 2] = mtx[2, 1] = ElasticStiffnessArray[7];
                mtx[1, 3] = mtx[3, 1] = ElasticStiffnessArray[8];
                mtx[1, 4] = mtx[4, 1] = ElasticStiffnessArray[9];
                mtx[1, 5] = mtx[5, 1] = ElasticStiffnessArray[10];
                mtx[2, 2] = ElasticStiffnessArray[11];
                mtx[2, 3] = mtx[3, 2] = ElasticStiffnessArray[12];
                mtx[2, 4] = mtx[4, 2] = ElasticStiffnessArray[13];
                mtx[2, 5] = mtx[5, 2] = ElasticStiffnessArray[14];
                mtx[3, 3] = ElasticStiffnessArray[15];
                mtx[3, 4] = mtx[4, 3] = ElasticStiffnessArray[16];
                mtx[3, 5] = mtx[5, 3] = ElasticStiffnessArray[17];
                mtx[4, 4] = ElasticStiffnessArray[18];
                mtx[4, 5] = mtx[5, 4] = ElasticStiffnessArray[19];
                mtx[5, 5] = ElasticStiffnessArray[20];
                return mtx;
            }
        }

        /// <summary>
        /// EOS�̃p�����[�^
        /// </summary>
        public EOS EOSCondition = new EOS();

        /// <summary>
        /// EOS�𗘗p���邩�ǂ���
        /// </summary>
        public bool DoesUseEOS = false;

        /// <summary>
        /// ���ʂƃT�C�Y��ێ�����Crystallite�N���X�z�� (�������̌v�Z���ɗp����)
        /// </summary>
        [NonSerialized] 
        [XmlIgnore]
        public Crystallite Crystallites;

        public double AngleResolution = 2;
        public int SubDivision = 4;

        /// <summary>
        /// �����q�̃T�C�Y (�P��:nm)
        /// </summary>
        public double GrainSize = 100;

        public int id = 0;

       

        #endregion �v���p�e�B�A�t�B�[���h

        #region �R���X�g���N�^

        public Crystal()
        {
            Symmetry = SymmetryStatic.Symmetries[0];
            Plane = new List<Plane>();
            Atoms = Array.Empty<Atoms>();
            ElasticStiffnessArray = new double[21];
            Bethe = new BetheMethod(this);
            A = B = C = Alpha = Beta = Gamma = 0;
            Name = "";
            Argb = Color.Black.ToArgb();
        }

        public Crystal(
            (double A, double B, double C, double Alpha, double Beta, double Gamma) cell,
            int symmetrySeriesNumber,
            string name,
            Color col)
            : this()
        {
            A = cell.A; B = cell.B; C = cell.C; Alpha = cell.Alpha; Beta = cell.Beta; Gamma = cell.Gamma;
            Name = name;
            Argb = col.ToArgb();
            SymmetrySeriesNumber = symmetrySeriesNumber;
            Symmetry = SymmetryStatic.Symmetries[SymmetrySeriesNumber];

            SetAxis();
        }
        public Crystal(
            (double A, double B, double C, double Alpha, double Beta, double Gamma) cell,
            (double A, double B, double C, double Alpha, double Beta, double Gamma)? err,
            int symmetrySeriesNumber,
            string name,
            Color col)
            : this(cell, symmetrySeriesNumber, name, col)
        {
            if (err != null)
            {
                A_err = err.Value.A; B_err = err.Value.B; C_err = err.Value.C; Alpha_err = err.Value.Alpha; Beta_err = err.Value.Beta; Gamma_err = err.Value.Gamma;
            }
        }


        public Crystal(
          (double A, double B, double C, double Alpha, double Beta, double Gamma) cell, 
          (double A, double B, double C, double Alpha, double Beta, double Gamma)? err,
          int symmetrySeriesNumber,
          string name,
          Color col,
          Matrix3D rot,
          Atoms[] atoms,
          (string Note, string Authors, string Journal, string Title) reference,
          Bonds[] bonds)
          : this(cell, err, symmetrySeriesNumber, name, col)
        {
            Atoms = atoms;
            for (int i = 0; i < atoms.Length; i++)
                Atoms[i].ResetSymmetry(symmetrySeriesNumber);

            AtomsP = Atoms.AsParallel();

            Note = reference.Note; PublAuthorName = reference.Authors; Journal = reference.Journal; PublSectionTitle = reference.Title;
            RotationMatrix = new Matrix3D(rot);
            GetFormulaAndDensity();
            Bonds = bonds;
            
        }


        public Crystal(
          (double A, double B, double C, double Alpha, double Beta, double Gamma) cell,
          (double A, double B, double C, double Alpha, double Beta, double Gamma)? err,
          int symmetrySeriesNumber,
          string name,
          Color col,
          Matrix3D rot,
          Atoms[] atoms,
          (string Note, string Authors, string Journal, string Title) reference,
          Bonds[] bonds,
          Bound[] bounds,
          LatticePlane[] latticePlane,
          EOS eos)
          : this(cell, err, symmetrySeriesNumber, name, col, rot, atoms,reference,bonds)
        {
          
            Bounds = bounds;
            for (int i = 0; i < Bounds.Length; i++)
                Bounds[i].Reset(this);
            LatticePlanes = latticePlane;
            for (int i = 0; i < LatticePlanes.Length; i++)
                LatticePlanes[i].Reset(this);

            EOSCondition = eos;
        }


        public Crystal(Crystal cry)
        {
            A = cry.A; B = cry.B; C = cry.C; Alpha = cry.Alpha; Beta = cry.Beta; Gamma = cry.Gamma;
            A_err = cry.A_err; B_err = cry.B_err; C_err = cry.C_err; Alpha_err = cry.Alpha_err; Beta_err = cry.Beta_err; Gamma_err = cry.Gamma_err;
            Name = cry.Name; Note = cry.Note; /*color = col;*/ Argb = cry.Argb;
            SetAxis();

            SymmetrySeriesNumber = cry.SymmetrySeriesNumber;
            Symmetry = SymmetryStatic.Symmetries[SymmetrySeriesNumber];

            Atoms = cry.Atoms;

            PublAuthorName = cry.PublAuthorName;
            Journal = cry.Journal;
            PublSectionTitle = cry.PublSectionTitle;

            GetFormulaAndDensity();

            Bonds = cry.Bonds;

            LatticePlanes = cry.LatticePlanes;
            Bounds = cry.Bounds;

            ElasticStiffnessArray = cry.ElasticStiffnessArray;
        }

        #endregion �R���X�g���N�^


        /// <summary>
        /// Crystal2�N���X�ɕϊ����܂��B
        /// </summary>
        public Crystal2 ToCrystal2() => Crystal2.FromCrystal(this);

        /// <summary>
        /// �i�q�萔����A�e���̃x�N�g����⏕�萔(sigma�Ȃ�)��ݒ肷��
        /// </summary>
        public void SetAxis()
        {
            # region �܂��A�Ώ̐��ɑ������i�q�萔�ɂȂ�悤�ɋ�������
            switch (Symmetry.CrystalSystemStr)
            {
                case "monoclinic":
                    switch (Symmetry.MainAxis)
                    {
                        case "a":
                            Beta = Gamma = Math.PI/2;
                            Beta_err = Gamma_err = 0;
                            break;

                        case "b":
                            Alpha = Gamma = Math.PI / 2;
                            Alpha_err = Gamma_err = 0;

                            break;

                        case "c":
                            Alpha = Beta = Math.PI / 2;
                            Alpha_err = Beta_err = 0;
                            break;
                    }
                    break;

                case "orthorhombic":
                    Alpha = Beta = Gamma = Math.PI / 2;
                    Alpha_err = Beta_err = Gamma_err = 0;
                    break;

                case "tetragonal":
                    B = A;
                    B_err = A_err;
                    Alpha = Beta = Gamma = Math.PI / 2;
                    Alpha_err = Beta_err = Gamma_err = 0;
                    break;

                case "trigonal":
                    switch (Symmetry.SpaceGroupHMStr.Contains("Rho") && Symmetry.SpaceGroupHMStr.Contains("R"))
                    {
                        case false:
                            B = A;
                            B_err = A_err;
                            Alpha = Beta = Math.PI / 2;
                            Gamma = Math.PI * 2.0 / 3.0;
                            Alpha_err = Beta_err = Gamma_err = 0;
                            break;

                        case true:
                            C = B = A;
                            C_err = B_err = A_err;

                            Alpha = Beta = Gamma;
                            Alpha_err = Beta_err = Gamma_err;
                            break;
                    }
                    break;

                case "hexagonal":
                    B = A;
                    B_err = A_err;
                    Alpha = Beta =  Math.PI / 2;
                    Gamma = Math.PI * 2.0 / 3.0;
                    Alpha_err = Beta_err = Gamma_err = 0;
                    break;

                case "cubic":
                    C = B = A;
                    C_err = B_err = A_err;
                    Alpha = Beta = Gamma = Math.PI / 2;
                    Alpha_err = Beta_err = Gamma_err = 0;
                    break;
            }
            #endregion

            double SinAlfa = Math.Sin(Alpha); double SinBeta = Math.Sin(Beta); double SinGamma = Math.Sin(Gamma);
            double CosAlfa = Math.Cos(Alpha); double CosBeta = Math.Cos(Beta); double CosGamma = Math.Cos(Gamma);
            double a2 = A * A; double b2 = B * B; var c2 = C * C;

            C_Axis = new Vector3D(0, 0, C);
            B_Axis = new Vector3D(0, B * SinAlfa, B * CosAlfa);
            A_Axis = new Vector3D(
            A * Math.Sqrt(1 - CosBeta * CosBeta - (CosGamma - CosAlfa * CosBeta) * (CosGamma - CosAlfa * CosBeta) / SinAlfa / SinAlfa),
            A * (CosGamma - CosAlfa * CosBeta) / SinAlfa,
            A * CosBeta);

            
            MatrixReal = new Matrix3D(A_Axis, B_Axis, C_Axis);
            MatrixInverse = Matrix3D.Inverse(MatrixReal);

            A_Star = new Vector3D(MatrixInverse.E11, MatrixInverse.E12, MatrixInverse.E13);
            B_Star = new Vector3D(MatrixInverse.E21, MatrixInverse.E22, MatrixInverse.E23);
            C_Star = new Vector3D(MatrixInverse.E31, MatrixInverse.E32, MatrixInverse.E33);

            sigma11 = b2 * c2 * SinAlfa * SinAlfa;
            sigma22 = c2 * a2 * SinBeta * SinBeta;
            sigma33 = a2 * b2 * SinGamma * SinGamma;
            sigma23 = a2 * B * C * (CosBeta * CosGamma - CosAlfa);
            sigma31 = A * b2 * C * (CosGamma * CosAlfa - CosBeta);
            sigma12 = A * B * c2 * (CosAlfa * CosBeta - CosGamma);
            CellVolumeSqure = a2 * b2 * c2 * (1 - CosAlfa * CosAlfa - CosBeta * CosBeta - CosGamma * CosGamma + 2 * CosAlfa * CosBeta * CosGamma);
            Volume = Math.Sqrt(CellVolumeSqure);
        }

        public override string ToString() => Name.ToString();

        #region �����􉽊w�֘A

        /// <summary>
        /// (h,k,l)�ʂ̖ʊԊu���v�Z���܂�
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public double GetLengthPlane(int h, int k, int l)
        {
            if ((h == 0 && k == 0 && l == 0) || A * B * C == 0 || CellVolumeSqure <= 0) return 0;
            return Symmetry.CrystalSystemStr switch//�ꍇ���������ق����������ȁH
            {
                "cubic" => A / Math.Sqrt(h * h + k * k + l * l),
                "tetragoanl" => 1 / Math.Sqrt((h * h + k * k) / A / A + l * l / C / C),
                "orthorhombic" => 1 / Math.Sqrt(h * h / A / A + k * k / B / B + l * l / C / C),
                _ => Math.Sqrt(1.0 / (h * h * sigma11 + k * k * sigma22 + l * l * sigma33 + 2 * k * l * sigma23 + 2 * l * h * sigma31 + 2 * h * k * sigma12) * CellVolumeSqure),
            };
        }

        /// <summary>
        /// (h1 k1 l1)�ʂ�(h2 l2 k2)�ʂ̂Ȃ��p���v�Z���܂�
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="k1"></param>
        /// <param name="l1"></param>
        /// <param name="h2"></param>
        /// <param name="k2"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public double GetAnglePlanes(int h1, int k1, int l1, int h2, int k2, int l2)
        {
            if (A * B * C == 0 || (h1 == 0 && k1 == 0 && l1 == 0) || (h2 == 0 && k2 == 0 && l2 == 0) || (h1 == h2 && k1 == k2 && l1 == l2) || CellVolumeSqure <= 0) return 0;
            double temp = GetLengthPlane(h1, k1, l1) * GetLengthPlane(h2, k2, l2) / CellVolumeSqure * (h1 * h2 * sigma11 + k1 * k2 * sigma22 + l1 * l2 * sigma33 + (k1 * l2 + l1 * k2) * sigma23 + (l1 * h2 + h1 * l2) * sigma31 + (h1 * k2 + k1 * h2) * sigma12);
            if (temp >= 1 || temp <= -1) return 0;
            return Math.Acos(temp);
        }

        /// <summary>
        /// ��[pqr]�̎����̒���
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public double GetLengthAxis(int u, int v, int w)
        {
            if (A * B * C == 0 || (u == 0 && v == 0 && w == 0)) return 0;
            return Math.Sqrt(u * u * A * A + v * v * B * B + w * w * C * C + 2 * v * w * B * C * Math.Cos(Alpha) + 2 * w * u * C * A * Math.Cos(Beta) + 2 * u * v * A * B * Math.Cos(Gamma));
        }

        /// <summary>
        /// �񎲂̂Ȃ��p
        /// </summary>
        /// <param name="u1"></param>
        /// <param name="v1"></param>
        /// <param name="w1"></param>
        /// <param name="u2"></param>
        /// <param name="v2"></param>
        /// <param name="w2"></param>
        /// <returns></returns>
        public double GetAngleAxes(int u1, int v1, int w1, int u2, int v2, int w2)
        {
            if (A * B * C == 0 || (u1 == 0 && v1 == 0 && w1 == 0) || (u2 == 0 && v2 == 0 && w2 == 0) || (u1 == u2 && v1 == v2 && w1 == w2)) return 0;
            return Math.Acos(1.0 / GetLengthAxis(u1, v1, w1) / GetLengthAxis(u2, v2, w2) * (u1 * u2 * A * A + v1 * v2 * B * B + w1 * w2 * C * C + (v1 * w2 + w1 * v2) * B * C * Math.Cos(Alpha) + (w1 * u2 + u1 * w2) * C * A * Math.Cos(Beta) + (u1 * v2 + v1 * u2) * A * B * Math.Cos(Gamma)));
        }

        /// <summary>
        /// �ʂ̐����Ǝ��̂Ȃ��p
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="w"></param>
        /// <returns></returns>
        public double GetAnglePlaneAxis(int h, int k, int l, int u, int v, int w)
        {
            if (A * B * C == 0 || (h == 0 && k == 0 && l == 0) || (u == 0 && v == 0 && w == 0)) return 0;
            return Math.Acos(GetLengthPlane(h, k, l) / GetLengthAxis(u, v, w) * (h * u + k * v + l * w));
        }

        /// <summary>
        /// 2�ʂ��琬�鏻�ю�
        /// </summary>
        /// <param name="h1"></param>
        /// <param name="k1"></param>
        /// <param name="l1"></param>
        /// <param name="h2"></param>
        /// <param name="k2"></param>
        /// <param name="l2"></param>
        /// <returns></returns>
        public static string GetZoneAxis(int h1, int k1, int l1, int h2, int k2, int l2)
        {
            int u, v, w, z;
            u = l1 * k2 - k1 * l2; v = h1 * l2 - l1 * h2; w = k1 * h2 - h1 * k2;
            for (z = 2; z <= Math.Abs(u) || z <= Math.Abs(v) || z <= Math.Abs(w); z++)
                if ((u % z == 0) && (v % z == 0) && (w % z == 0))
                {
                    u /= z; v /= z; w /= z; z = 1;
                }
            return $" {u} {v} {w}";
        }

        /// <summary>
        /// a,b,c���x�N�g������hkl�ʂ̕����x�N�g���v�Z
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static Vector3D CalcHklVector(int h, int k, int l, Vector3D a, Vector3D b, Vector3D c) 
            => new(
                -h * (b.Z * c.Y - b.Y * c.Z) - k * (c.Z * a.Y - c.Y * a.Z) - l * (a.Z * b.Y - a.Y * b.Z),
                -h * (b.X * c.Z - b.Z * c.X) - k * (c.X * a.Z - c.Z * a.X) - l * (a.X * b.Z - a.Z * b.X),
                -h * (b.Y * c.X - b.X * c.Y) - k * (c.Y * a.X - c.X * a.Y) - l * (a.Y * b.X - a.X * b.Y)
                );

        /// <summary>
        /// hkl�ʂ̕����x�N�g���v�Z
        /// </summary>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public Vector3D CalcHklVector(int h, int k, int l) 
            => new(
                -h * (B_Axis.Z * C_Axis.Y - B_Axis.Y * C_Axis.Z) - k * (C_Axis.Z * A_Axis.Y - C_Axis.Y * A_Axis.Z) - l * (A_Axis.Z * B_Axis.Y - A_Axis.Y * B_Axis.Z),
                -h * (B_Axis.X * C_Axis.Z - B_Axis.Z * C_Axis.X) - k * (C_Axis.X * A_Axis.Z - C_Axis.Z * A_Axis.X) - l * (A_Axis.X * B_Axis.Z - A_Axis.Z * B_Axis.X),
                -h * (B_Axis.Y * C_Axis.X - B_Axis.X * C_Axis.Y) - k * (C_Axis.Y * A_Axis.X - C_Axis.X * A_Axis.Y) - l * (A_Axis.Y * B_Axis.X - A_Axis.X * B_Axis.Y)
                );

        /// <summary>
        /// ���񂩂ǂ�������
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns>
        public static bool CheckIrreducible(int a, int b, int c)
        {
            for (int n = 2; n <= new[] { Math.Abs(a), Math.Abs(b), Math.Abs(c) }.Max(); n++)
                if (a % n == 0 && b % n == 0 && c % n == 0)
                    return false;
            return true;
        }

        #endregion �����􉽊w�֘A

        #region ���x�N�g���̌v�Z

        /// <summary>
        ///�@�����Ŏw�肳�ꂽ�w���̎��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="indices"></param>
        public void SetVectorOfAxis((int U, int V, int W)[] indices)
        {
            if (A_Axis == null) return;
            VectorOfAxis = new List<Vector3D>();
            foreach (var (U, V, W) in indices)
            {
                var vec = U * A_Axis + V * B_Axis + W * C_Axis;
                vec.Text = $"[{U}{V}{W}]";
                VectorOfAxis.Add(vec);
            }
        }

        /// <summary>
        /// �����Ŏw�肳�ꂽuMax,vMax,wMax�͈̔͂Ŏ��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="uMax"></param>
        /// <param name="vMax"></param>
        /// <param name="wMax"></param>
        public void SetVectorOfAxis(int uMax, int vMax, int wMax)
        {
            if (A_Axis == null) return;
            VectorOfAxis = new List<Vector3D>();
            var vec = new Vector3D();
            vec = A_Axis; vec.Text = "[100]"; VectorOfAxis.Add(vec);
            vec = B_Axis; vec.Text = "[010]"; VectorOfAxis.Add(vec);
            vec = C_Axis; vec.Text = "[001]"; VectorOfAxis.Add(vec);
            vec = -A_Axis; vec.Text = "[-100]"; VectorOfAxis.Add(vec);
            vec = -B_Axis; vec.Text = "[0-10]"; VectorOfAxis.Add(vec);
            vec = -C_Axis; vec.Text = "[00-1]"; VectorOfAxis.Add(vec);

            for (int u = -uMax; u <= uMax; u++)
                for (int v = -vMax; v <= vMax; v++)
                    for (int w = -wMax; w <= wMax; w++)
                        if (CheckIrreducible(u, v, w) && !(u * v == 0 && v * w == 0 && w * u == 0))
                        {
                            vec = u * A_Axis + v * B_Axis + w * C_Axis;
                            vec.Text = $"[{u}{v}{w}]";
                            VectorOfAxis.Add(vec);
                        }
        }

        #endregion ���x�N�g���̌v�Z

        #region �ʃx�N�g���̌v�Z

        /// <summary>
        /// �����Ŏw�肳�ꂽ�w���̖ʃx�N�g�����v�Z���AVectorOfPlane�Ɋi�[
        /// </summary>
        /// <param name="indices"></param>
        public void SetVectorOfPlane((int H, int K, int L)[] indices)
        {
            VectorOfPlane = new List<Vector3D>();
            foreach (var (H, K, L) in indices)
            {
                var vec = H * A_Star + K * B_Star + L * C_Star;
                vec.Text = $"({H}{K}{L})";
                VectorOfPlane.Add(vec);
            }
        }

        /// <summary>
        /// �����Ŏw�肳�ꂽhMax,kMax,lMax�͈̔͂Ŏ��x�N�g�����v�Z���AVectorOfAxis�Ɋi�[
        /// </summary>
        /// <param name="hMax"></param>
        /// <param name="kMax"></param>
        /// <param name="lMax"></param>
        public void SetVectorOfPlane(int hMax, int kMax, int lMax)
        {
            VectorOfPlane = new List<Vector3D>();
            Vector3D vec;

            vec = CalcHklVector(1, 0, 0); vec = vec * GetLengthPlane(1, 0, 0) / vec.d; vec.Text = "(100)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 1, 0); vec = vec * GetLengthPlane(0, 1, 0) / vec.d; vec.Text = "(010)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 0, 1); vec = vec * GetLengthPlane(0, 0, 1) / vec.d; vec.Text = "(001)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(-1, 0, 0); vec = vec * GetLengthPlane(-1, 0, 0) / vec.d; vec.Text = "(-100)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, -1, 0); vec = vec * GetLengthPlane(0, -1, 0) / vec.d; vec.Text = "(0-10)"; VectorOfPlane.Add(vec);
            vec = CalcHklVector(0, 0, -1); vec = vec * GetLengthPlane(0, 0, -1) / vec.d; vec.Text = "(00-1)"; VectorOfPlane.Add(vec);
            for (int h = -hMax; h <= hMax; h++)
                for (int k = -kMax; k <= kMax; k++)
                    for (int l = -lMax; l <= lMax; l++)
                 
                        if (CheckIrreducible(h, k, l) && !(h * k == 0 && k * l == 0 && l * h == 0))
                        {
                            vec = CalcHklVector(h, k, l);
                            vec = vec * GetLengthPlane(h, k, l) / vec.d;
                            vec.Text = $"({h}{k}{l})";
                            VectorOfPlane.Add(vec);
                        }
        }

        /// <summary>
        /// �ʊԊud_limit�ȏ�̖ʂ������A�\�[�g����B
        /// </summary>
        /// <param name="dMax">���̒l�ȏ�̖ʂ���������</param>
        /// <param name="dMin">���̒l�ȉ��̖ʂ���������</param>
        /// <param name="excludeEquivalentPlane">true�̂Ƃ��͌����w�I�ɓ����Ȗʂ�r������</param>
        /// <param name="excludeForbiddenPlane">true�̂Ƃ��͏��ő��Ɉ���������ʂ�r������</param>
        /// <param name="excludeSameDistance">true�̂Ƃ��͌����w�I�ɂ͔񓙉������A�ʊԊu���܂����������ʂ�r������</param>
        /// <param name="combineAdjacentPeak">true�̂Ƃ��́A�߂��s�[�N����������</param>
        /// <param name="horizontalAxis">�����̒P�ʂ��w�肷��</param>
        /// <param name="horizontalThreshold">�w�肳�ꂽ�����P�ʂɂ����鍷������臒l�ȉ��̖ʂǂ����𓝍�����</param>
        /// <param name="horizontalParameter">�������p�x�̎��͓��ː��̔g�����A�G�l���M�[�̎��͎��o���p���w�肷��</param>
        public void SetPlanes(double dMax, double dMin, bool excludeEquivalentPlane, bool excludeForbiddenPlane, bool excludeSameDistance, bool combineAdjacentPeak,
            HorizontalAxis horizontalAxis, double horizontalThreshold, double horizontalParameter)
        {
            #region
            if (dMin < (A + B + C) / 3 / 30)
                dMin = (A + B + C) / 3 / 30;
            var hMax = (int)(A / dMin);
            var kMax = (int)(B / dMin);
            var lMax = (int)(C / dMin);

            var listPlane = new List<Plane>();
            double d;
            int multi = 1;
            if (excludeEquivalentPlane)//�����Ȗʂ�r������Ƃ�
            {
                for (int h = -hMax; h <= hMax; h++)//h��0����͂��߂�
                    for (int k = -kMax; k <= kMax; k++)
                        for (int l = -lMax; l <= lMax; l++)
                            if ((d = GetLengthPlane(h, k, l)) > dMin && d < dMax && SymmetryStatic.IsRootIndex((h, k, l), Symmetry, ref multi))
                            {
                                var temp = new Plane();
                                // if (!excludeForbiddenPlane | (temp.strCondition = SymmetryStatic.CheckExtinctionRule(h, k, l, Symmetry)).Length == 0)
                                if (!excludeForbiddenPlane || (temp.strCondition = Symmetry.CheckExtinctionRule(h, k, l)).Length == 0)
                                {
                                    temp.Multi[0] = multi;
                                    temp.h = h; temp.k = k; temp.l = l; temp.d = d;
                                    temp.strHKL = $"{h} {k} {l}";
                                    temp.IsRootIndex = true;
                                    listPlane.Add(temp);
                                }
                            }
            }
            else//�����Ȗʂ�r�����Ȃ��Ƃ�
            {
                for (int h = -hMax; h <= hMax; h++)//h��-hmax����͂��߂�
                    for (int k = -kMax; k <= kMax; k++)
                        for (int l = -lMax; l <= lMax; l++)
                            if ((d = GetLengthPlane(h, k, l)) > dMin)
                            {
                                var temp = new Plane { IsRootIndex = SymmetryStatic.IsRootIndex((h, k, l), Symmetry, ref multi) };
                                if (!excludeForbiddenPlane || (temp.strCondition = Symmetry.CheckExtinctionRule(h, k, l)).Length == 0)
                                {
                                    temp.Multi[0] = multi;
                                    temp.h = h; temp.k = k; temp.l = l; temp.d = d;
                                    temp.strHKL = $"{h} {k} {l}";
                                    listPlane.Add(temp);
                                }
                            }
            }

            try { listPlane.Sort(); }
            catch { return; }

            if (excludeSameDistance)//�S�����Ȃ������ʖʊԊu��������(511��333�Ƃ�)��r������
            {
                int i = 0;
                while (i < listPlane.Count - 1)
                {
                    if (listPlane[i].d == listPlane[i + 1].d)
                        listPlane.RemoveAt(i + 1);
                    else
                        i++;
                }
            }

            if (combineAdjacentPeak)//d�l�̋߂��s�[�N����������
            {
                if (horizontalAxis == HorizontalAxis.Angle && horizontalThreshold > 0 && horizontalParameter > 0) //臒l���p�x�̏ꍇ
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(Math.Asin(horizontalParameter / listPlane[i].d / 2.0) * 2 - Math.Asin(horizontalParameter / listPlane[i + 1].d / 2.0) * 2))
                            {
                                minDif = Math.Abs(Math.Asin(horizontalParameter / listPlane[i].d / 2.0) * 2 - Math.Asin(horizontalParameter / listPlane[i + 1].d / 2.0) * 2);
                                k = i;
                            }
                        if (minDif < horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif < horizontalThreshold);
                }
                else if (horizontalAxis == HorizontalAxis.EnergyXray && horizontalThreshold > 0 && horizontalParameter > 0)//Energy�̏ꍇ
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i].d, horizontalParameter) - UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i + 1].d, horizontalParameter)))
                            {
                                minDif = Math.Abs(UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i].d, horizontalParameter) - UniversalConstants.Convert.DspacingToXrayEnergy(listPlane[i + 1].d, horizontalParameter));
                                k = i;
                            }
                        if (minDif < horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif < horizontalThreshold);
                }
                else if (horizontalAxis == HorizontalAxis.d && horizontalThreshold >= 0)
                {
                    double minDif = double.PositiveInfinity;
                    do
                    {
                        minDif = double.PositiveInfinity;
                        int k = 0;
                        for (int i = 0; i < listPlane.Count - 1; i++)
                            if (minDif > Math.Abs(listPlane[i].d - listPlane[i + 1].d))
                            {
                                minDif = Math.Abs(listPlane[i].d - listPlane[i + 1].d);
                                k = i;
                            }
                        if (minDif <= horizontalThreshold)
                        {
                            listPlane[k].d = (listPlane[k].d + listPlane[k + 1].d) / 2.0;
                            listPlane[k].strHKL += " + " + listPlane[k + 1].strHKL;
                            int[] multiplisity = new int[listPlane[k].Multi.Length + listPlane[k + 1].Multi.Length];
                            listPlane[k].Multi.CopyTo(multiplisity, 0);
                            listPlane[k + 1].Multi.CopyTo(multiplisity, listPlane[k].Multi.Length);
                            listPlane[k].Multi = multiplisity;

                            listPlane.RemoveAt(k + 1);
                        }
                    } while (minDif <= horizontalThreshold);
                    ;
                }
            }

            var temp_plane = listPlane.ToArray();
            for (int n = 0; n < temp_plane.Length; n++)
            {
                temp_plane[n].F2[0] = -1;
                temp_plane[n].IsFittingChecked = false;
                temp_plane[n].IsFittingSelected = false;
                temp_plane[n].num = n;
                temp_plane[n].SerchRange = 0.10;
                temp_plane[n].SerchOption = temp_plane[n].peakFunction.Option = PeakFunctionForm.PseudoVoigt;
                temp_plane[n].Intensity = -1;
            }

            if (Plane != null)
                for (int n = 0; n < Plane.Count && n < temp_plane.Length; n++)
                {
                    temp_plane[n].SerchRange = Plane[n].SerchRange;
                    temp_plane[n].FWHM = Plane[n].FWHM;
                    temp_plane[n].SerchOption = Plane[n].SerchOption;
                    temp_plane[n].IsFittingChecked = Plane[n].IsFittingChecked;
                    temp_plane[n].simpleParameter = Plane[n].simpleParameter;
                    temp_plane[n].peakFunction = Plane[n].peakFunction;
                    temp_plane[n].Intensity = Plane[n].Intensity;
                    temp_plane[n].observedIntensity = Plane[n].observedIntensity;
                }
            Plane = new List<Plane>();
            Plane.AddRange(temp_plane);

            #endregion �ʃx�N�g���̌v�Z
        }

        //plene[]��d�l���v�Z����B�v�Z����ʂ͈͕̔͂ς��Ȃ�
        public void SetPlanes()
        {
            for (int i = 0; i < Plane.Count; i++)
                Plane[i].d = GetLengthPlane(Plane[i].h, Plane[i].k, Plane[i].l);
        }

        #endregion

        #region �t�i�q�x�N�g���̌v�Z
       /// <summary>
        /// dMin�ȏ�AdMax�ȉ��͈̔͂ŋt�i�q�x�N�g�����v�Z���Awavesorce�ɏ]���āA�\�����q���v�Z
        /// </summary>
        /// <param name="dMin"></param>
        /// <param name="dMax"></param>
        /// <param name="wavesource"></param>
        public void SetVectorOfG(double dMin, WaveSource wavesource, bool excludeLatticeCondition = true)
        {
            if (A_Star == null) SetAxis();

            static int composeKey(in int h, in int k, int l) => ((h > 0) || (h == 0 && k > 0) || (h == 0 && k == 0 && l > 0)) ? ((h + 255) << 20) + ((k + 255) << 10) + l + 255 : -1;
            static (int h, int k, int l) decomposeKey(in int key) => (((key << 2) >> 22) - 255, ((key << 12) >> 22) - 255, ((key << 22) >> 22) - 255);

            double aX = A_Star.X, aY = A_Star.Y, aZ = A_Star.Z;
            double bX = B_Star.X, bY = B_Star.Y, bZ = B_Star.Z;
            double cX = C_Star.X, cY = C_Star.Y, cZ = C_Star.Z;

            var gMax = 1 / dMin;
            (int h, int k, int l)[] directions;
            #region direction��������
            if (excludeLatticeCondition)
            {
                //if (Symmetry.LatticeTypeStr == "F")
                //    directions = new [] { (1, 1, 1), (1, 1, -1), (1, -1, 1), (1, -1, -1), (-1, 1, 1), (-1, 1, -1), (-1, -1, 1), (-1, -1, -1) };
                //else if (Symmetry.LatticeTypeStr == "A")
                //    directions = new [] { (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 0), (-1, 0, 0) };
                //else if (Symmetry.LatticeTypeStr == "B")
                //    directions = new [] { (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1), (0, 1, 0), (0, -1, 0) };
                //else if (Symmetry.LatticeTypeStr == "C")
                //    directions = new [] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 0, 1), (0, 0, -1) };
                //else if (Symmetry.LatticeTypeStr == "I")
                //    directions = new [] { (1, 1, 0), (1, -1, 0), (-1, 1, 0), (-1, -1, 0), (0, 1, 1), (0, 1, -1), (0, -1, 1), (0, -1, -1), (1, 0, 1), (1, 0, -1), (-1, 0, 1), (-1, 0, -1) };
                //else if (Symmetry.LatticeTypeStr == "R" && Symmetry.SpaceGroupHMsubStr == "H")
                //    directions = new [] { (1, 0, 1), (0, -1, 1), (-1, 1, 1), (-1, 0, -1), (0, 1, -1), (1, -1, -1) };
                //else if (Symmetry.CrystalSystemStr == "trigonal" || Symmetry.CrystalSystemStr == "hexagonal")
                //    directions = new [] { (1, 0, 0), (-1, 0, 0), (0, 1, 0), (0, -1, 0), (1, -1, 0), (-1, 1, 0), (0, 0, 1), (0, 0, -1) };
                //else
                directions = new [] { (1, 0, 0),  (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) };//(-1, 0, 0)�͏����Ă���
            }
            else
                directions = new [] { (1, 0, 0),  (0, 1, 0), (0, -1, 0), (0, 0, 1), (0, 0, -1) };//(-1, 0, 0)�͏����Ă���

            #endregion

            var shift = directions.Select(dir => (MatrixInverse * dir).Length).Max();
            
            var maxGnum = 250000;
            var zeroKey = (255 << 20) + (255 << 10) + 255;
            var outer = new Dictionary<int, double>() { { zeroKey, 0 } };
            var gDic = new Dictionary<int, (double x, double y, double z, double len)>() { { zeroKey, (0, 0, 0, 0) } };
            var minG = 0.0;

            while (gDic.Count < maxGnum && (minG = outer.Values.Min()) < gMax)
            {
                var outerList = outer.Where(o => o.Value - minG < shift * 4).Select(o => o.Key).ToList();
                outerList.ForEach(o => outer.Remove(o));

                foreach (var (h1, k1, l1) in outerList.Select(o => decomposeKey(o)))
                    foreach ((int h2, int k2, int l2) in directions)
                    {
                        int h = h1 + h2, k = k1 + k2, l = l1 + l2, key = composeKey(h, k, l);// h * 1024 * 1024 + k * 1024 + l;
                        if (key > 0 && !gDic.ContainsKey(key))
                        {
                            double x = h * aX + k * bX + l * cX, y = h * aY + k * bY + l * cY, z = h * aZ + k * bZ + l * cZ;
                            var len = Math.Sqrt(x * x + y * y + z * z);
                            gDic.Add(key, (x, y, z, len));
                            outer.Add(key, len);
                        }
                    }
            }
            gDic.Remove(zeroKey);

            var gList = gDic.ToList();
            var gArray = new Vector3D[gDic.Count * 2];
            Parallel.For(0, gList.Count, i =>
            {
                var (h, k, l) = decomposeKey(gList[i].Key);
                var (x, y, z, glen) = gList[i].Value;
                var extinction = Symmetry.CheckExtinctionRule(h, k, l);
                gArray[i * 2] = new Vector3D(x, y, z, false) { Index = (h, k, l), d = 1 / glen, Extinction = extinction, Text = $"{h} {k} {l}" };
                gArray[i * 2 + 1] = new Vector3D(-x, -y, -z, false) { Index = (-h, -k, -l), d = 1 / glen, Extinction = extinction, Text = $"{-h} {-k} {-l}" };
            });

            if (wavesource != WaveSource.None)//���x�v�Z����ꍇ 250ms���炢
            {
                Parallel.ForEach(gArray, _g =>
                {
                     _g.F = _g.Extinction.Length == 0 ? GetStructureFactor(wavesource, Atoms, _g.Index, _g.Length2 / 4.0) : 0;
                    _g.RawIntensity = _g.F.MagnitudeSquared();// _g.F.Magnitude2();
                });

                var maxIntensity = gArray.Max(v => v.RawIntensity);
                Parallel.ForEach(gArray, _g => _g.RelativeIntensity = _g.RawIntensity / maxIntensity);
            }
            VectorOfG = gArray.ToList(); //�Ō�ɒl����
        }

        #endregion

        #region �e�r���t�i�q�x�N�g���̌v�Z

        //d_limit�ȏ�͈̔͂ŋe�r���t�i�q�x�N�g�����v�Z
        public void SetVectorOfG_KikuchiLine(double d_limit, double waveLength)
        {
            if (A_Star == null) SetAxis();
            int hMax = (int)(A / d_limit);
            int kMax = (int)(B / d_limit);
            int lMax = (int)(C / d_limit);
            VectorOfG_KikuchiLine = new List<Vector3D>();
            for (int h = 0; h <= hMax; h++)
                for (int k = h == 0 ? 0 : -kMax; k <= kMax; k++)
                    for (int l = (h == 0 && k == 0) ? 1 : -lMax; l <= lMax; l++)
                    {
                        Vector3D temp = h * A_Star + k * B_Star + l * C_Star;
                        if ((temp.d = temp.Length) < 1 / d_limit)
                        {
                            //temp.Theta = waveLength / 2 * temp.Length;
                            //temp.TanTheta = Math.Tan(temp.Theta);
                            temp.Text = $"{h} {k} {l}";
                            VectorOfG_KikuchiLine.Add(temp);
                        }
                    }
        }

        #endregion

        #region ��܋��x�̋������̂�����

        /// <summary>
        /// ���݂̌����\���ŋ��x����ʍő�8�ʂ܂ł̂��̂��������A�Ԃ�
        /// </summary>
        /// <returns></returns>
        public float[] GetDspacingList(double waveLentgh, double d_limit, int count =1000)
        {
            SetPlanes(double.MaxValue, d_limit, true, true, true, false, 0, 0, 0);

            Plane = Plane.Take(Math.Min(count, Plane.Count)).ToList();
            SetPeakIntensity(WaveSource.Xray, WaveColor.Monochrome, waveLentgh, null);

            //���x�̏��Ƀ\�[�g
            Plane.Sort((p1, p2) => -p1.Intensity.CompareTo(p2.Intensity));
            return Plane.Take(Math.Min(8, Plane.Count)).Select(p => (float)p.d).ToArray();
        }
        #endregion

        #region ���q�̒ǉ�/�폜

        //�����̌��q��������
        public bool AddAtoms(Atoms Atoms)
        {
            return AddAtoms(Atoms, true);
        }

        public bool AddAtoms(Atoms atoms, bool RenewFormulaAndDensity)
        {
            if (Atoms.Length > 0)
            {
                Atoms[] temp = new Atoms[Atoms.Length + 1];
                Array.Copy(Atoms, temp, Atoms.Length);
                temp[Atoms.Length] = atoms;
                temp[Atoms.Length].ID = Atoms[^1].ID + 1;
                Atoms = temp;
                if (RenewFormulaAndDensity)
                    GetFormulaAndDensity();
                return true;
            }
            else
            {
                Atoms = new Atoms[1];
                Atoms[0] = atoms;
                if (RenewFormulaAndDensity)
                    GetFormulaAndDensity();
                return true;
            }
        }

        public bool AddAtoms(string label, int atomicNumber, int subXray, int subElectron, double[] isotope, double x, double y, double z, double occ, DiffuseScatteringFactor dsf)
        {
            return AddAtoms(label, atomicNumber, subXray, subElectron, isotope, x, y, z, occ, dsf, true);
        }

        //�����̌��q��������
        public bool AddAtoms(string label, int atomicNumber, int subXray, int subElectron, double[] isotope, double x, double y, double z, double occ, DiffuseScatteringFactor dsf, bool RenewFormulaAndDensity)
        {
            Atoms atoms = new Atoms(label, atomicNumber, subXray, subElectron, isotope, SymmetrySeriesNumber, new Vector3D(x, y, z), occ, dsf);
            return AddAtoms(atoms, RenewFormulaAndDensity);
        }

        //�����̌��q���폜����
        public bool DeleteAtoms(Atoms atoms)
        {
            for (int i = 0; i < Atoms.Length; i++)
            {
                if (Atoms[i].ID == atoms.ID)
                {
                    var temp = new Atoms[Atoms.Length - 1];
                    Array.Copy(Atoms, 0, temp, 0, i);
                    Array.Copy(Atoms, i + 1, temp, i, temp.Length - i);
                    GetFormulaAndDensity();
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// ���C�R�t�ʒu��ۂ����܂܁A���q�ʒu�𗐐��I�ɕω�������
        /// </summary>
        /// <param name="seed"></param>
        public void RandomizeAllAtomicPositionKeepingWykoff(Random r)
        {
            for (int i = 0; i < Atoms.Length; i++)
                Atoms[i].RandomizeKeepingWykoff(r);
        }

        /// <summary>
        /// ���q�̈ʒu���Ē������āA�����Ƃ����_�ʒu�ɋ߂����q��Atoms[i]=0�ɓ����
        /// </summary>
        public void ReCoordinateAtom()
        {
            for (int i = 0; i < Atoms.Length; i++)
            {
                double minR = double.PositiveInfinity;
                double r;
                int k = -1;
                for (int j = 0; j < Atoms[i].Atom.Count; j++)
                    if ((r = Atoms[i].Atom[j].Length2) < minR)
                    {
                        minR = r;
                        k = j;
                    }
                if (k >= 0)
                {
                    Atoms[i].X = Atoms[i].Atom[k].X;
                    Atoms[i].Y = Atoms[i].Atom[k].Y;
                    Atoms[i].Z = Atoms[i].Atom[k].Z;
                }
            }
        }

        /// <summary>
        /// ���݂̌��q��Ɗi�q�萔����A�g���Ɩ��x���v�Z���܂��B
        /// </summary>
        public void GetFormulaAndDensity()
        {
            #region
            if (Atoms == null || Atoms.Length == 0) return;

            var dic = new Dictionary<string, double>();

            for (int i = 0; i < Atoms.Length; i++)
            {
                var key = Atoms[i].ElementName.Split(' ', true)[1];
                var num = Atoms[i].Multiplicity * Atoms[i].Occ;
                if (dic.ContainsKey(key))
                    dic[key] += num;
                else
                    dic.Add(key, num);
            }

            ElementName = dic.Keys.ToArray();
            ElementNum = dic.Values.ToArray();

            if (ElementNum.Sum() == 0)
                return;

            
            //�����Ŋ����Ƃ���܂ł��
            if (ElementName != null)
            {
                var Num = ElementNum.ToArray();

                //�܂�Num�̍ŏ��l��������
                int n = int.MaxValue;
                foreach (double var in Num)
                    if (n > var)
                        n = (int)var;

                //����2���珇�Ԃɂ���Ă���
                for (int i = 2; i <= n; i++)
                {
                    bool IsDivisor = true;
                    foreach (double var in Num)
                        if (var % i != 0) IsDivisor = false;
                    if (IsDivisor)
                    {
                        for (int j = 0; j < Num.Length; j++) Num[j] = Num[j] / i;
                        i--;
                    }
                }

                //�P�ʊi�q������̑g�����̐�Z��
                ChemicalFormulaZ = (int)(ElementNum[0] / Num[0]);

                //�g���� Fe21.333333333 O32  Fe2O3   *32/3 �̂悤�ɕ\��������
                bool is3times = true;
                int denom = 0;
                for (int i = 0; i < Num.Length; i++)
                    if (Math.Abs((Num[i] / 3.0)) % 1.0 > 0.000000001)
                        is3times = false;

                if (is3times == true)
                {
                    denom = (int)(Num[0] * 3 + 0.1);
                    for (int i = 0; i < Num.Length; i++)
                        Num[i] = (int)(Num[i] * 3 + 0.1);
                    //�܂�Num�̍ŏ��l��������
                    int m = int.MaxValue;
                    foreach (double var in Num)
                        if (m > var)
                            m = (int)var;

                    //����2���珇�Ԃɂ���Ă���
                    for (int i = 2; i <= m; i++)
                    {
                        bool IsDivisor = true;
                        foreach (double var in Num)
                            if (var % i != 0)
                                IsDivisor = false;
                        if (IsDivisor)
                        {
                            for (int j = 0; j < Num.Length; j++)
                                Num[j] = Num[j] / i;
                            i--;
                        }
                    }
                    denom /= (int)Num[0];
                }

                ChemicalFormulaSum = "";
                for (int i = 0; i < Num.Length; i++)
                {
                    if (Num[i] == 1)
                        ChemicalFormulaSum += ElementName[i] + " ";
                    else
                        ChemicalFormulaSum += $"{ElementName[i]}{Num[i].Round(12)} ";
                }
                ChemicalFormulaSum = ChemicalFormulaSum[0..^1];

                if (is3times && denom != 3)
                    ChemicalFormulaSum += $"  *{denom}/3";

                double TotalWeightPerUnitCell = 0;
                for (int i = 0; i < ElementName.Length; i++)
                {
                    TotalWeightPerUnitCell += AtomStatic.AtomicWeight(ElementName[i]) * ElementNum[i];
                }
                Density = TotalWeightPerUnitCell / Math.Sqrt(CellVolumeSqure) / 6.0221367 / 100;
                WeightPerFormula = TotalWeightPerUnitCell / ChemicalFormulaZ;
            }
            return;
            #endregion
        }

        #endregion

        #region �\�����q�̌v�Z

       
        [NonSerialized]
        [XmlIgnore]
        private static readonly Complex TwoPiI = 2 * Complex.ImaginaryOne * Math.PI;

        //(h,k,l)�̍\���U�����q(�M�U���U������)��F (���f��) ���v�Z����
        /// <summary>
        /// �\�����q�����߂� s2�̒P�ʂ�nm^-2
        /// </summary>
        /// <param name="wave"></param>
        /// <param name="atomsArray"></param>
        /// <param name="h"></param>
        /// <param name="k"></param>
        /// <param name="l"></param>
        /// <param name="s2">�P�ʂ�nm^-2</param>
        /// <returns></returns>
        private static Complex GetStructureFactor(WaveSource wave, Atoms[] atomsArray, (int h, int k, int l) index, double s2)
        {
            #region
            (int h, int k, int l) = index;
            //s2 = (sin(theta)/ramda)^2 = 1 / 4 /d^2
            if (atomsArray.Length == 0)
                return new Complex(0, 0);
            Complex F = 0, f = 0;
            int atomicNum = -1, subNum = -1;

            foreach (var atoms in atomsArray)
            {
                if (wave == WaveSource.Electron)
                {
                    if (atoms.AtomicNumber != atomicNum || atoms.SubNumberElectron != subNum)
                    {
                        f = new Complex(atoms.GetAtomicScatteringFactorForElectron(s2), 0);
                        atomicNum = atoms.AtomicNumber;
                        subNum = atoms.SubNumberElectron;
                    }
                }
                else if (wave == WaveSource.Xray)
                {
                    if (atoms.AtomicNumber != atomicNum || atoms.SubNumberXray != subNum)
                    {
                        f = new Complex(atoms.GetAtomicScatteringFactorForXray(s2), 0);
                        atomicNum = atoms.AtomicNumber;
                        subNum = atoms.SubNumberXray;
                    }
                }
                else
                    f = atoms.GetAtomicScatteringFactorForNeutron();


                if (atoms.Dsf.UseIso)
                {
                    var T = Math.Exp(-atoms.Dsf.Biso * s2);
                    if (double.IsNaN(T))
                        T = 1;
                    foreach (var atom in atoms.Atom)
                        F += f * T * Complex.Exp(-TwoPiI * (h * atom.X + k * atom.Y + l * atom.Z));
                }
                else
                {
                    foreach (var atom in atoms.Atom)
                    {
                        var (H, K, L) = atom.Operation.ConvertPlaneIndex(h, k, l);
                        var T = Math.Exp(-(atoms.Dsf.B11 * H * H + atoms.Dsf.B22 * K * K + atoms.Dsf.B33 * L * L
                            + 2 * atoms.Dsf.B12 * H * K + 2 * atoms.Dsf.B23 * K * L + 2 * atoms.Dsf.B31 * L * H));
                        if (double.IsNaN(T))
                            T = 1;
                        F += f * T * Complex.Exp(-TwoPiI * (h * atom.X + k * atom.Y + l * atom.Z));
                    }
                }
            }
            return F;// Complex(Real, Inverse);
            #endregion
        }

        /// <summary>
        /// ������܎����ɂ�����(h,k,l)�̉�܋��x�ƈʒu���v�Z����
        /// </summary>
        /// <param name="ramda">�g��</param>
        public void SetPeakIntensity(WaveSource waveSource, WaveColor waveColor, double ramda, Profile whiteProfile)
        {
            #region
            if (Atoms == null || Atoms.Length == 0 || Plane == null|| Plane.Count ==0) return;

            for (int i = 0; i < Plane.Count; i++)
            {
                var sinTheta = ramda / 2 / Plane[i].d;
                var twoTheta = Plane[i].XCalc = 2 * Math.Asin(sinTheta);
                var cosTwoTheta = 1 - 2 * sinTheta * sinTheta;
                var sinTwoTheta = Math.Sin(twoTheta);
                
                var s = Plane[i].strHKL.Split('+', true);
                Plane[i].F2 = new double[s.Length];
                Plane[i].F = new Complex[s.Length];
                Plane[i].eachIntensity = new double[s.Length];
                var d2 = Plane[i].d * Plane[i].d;

                for (int j = 0; j < s.Length; j++)
                {
                    if (s.Length == 1)
                        Plane[i].F[j] = GetStructureFactor(waveSource, Atoms, (Plane[i].h, Plane[i].k, Plane[i].l), 1 / d2 / 4.0); 
                    else
                    {
                        var hkl = s[j].Split(' ', true);
                        int h = Convert.ToInt32(hkl[0]), k = Convert.ToInt32(hkl[1]), l = Convert.ToInt32(hkl[2]);
                        Plane[i].F[j] = GetStructureFactor(waveSource, Atoms, (h, k, l), 1 / d2 / 4.0);
                    }


                    Plane[i].F2[j] = Plane[i].F[j].MagnitudeSquared();

                    if (waveSource == WaveSource.Xray)
                    {
                        if (waveColor == WaveColor.Monochrome)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * (1 + cosTwoTheta * cosTwoTheta) / sinTwoTheta / sinTheta;
                        else if (waveColor == WaveColor.FlatWhite)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * d2;
                    }
                    else if (waveSource == WaveSource.Electron)
                    {
                        Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure / sinTwoTheta / sinTheta;
                    }
                    else if (waveSource == WaveSource.Neutron)
                    {
                        if (waveColor == WaveColor.Monochrome)
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure / sinTwoTheta / sinTheta;
                        else
                            Plane[i].eachIntensity[j] = Plane[i].F2[j] * Plane[i].Multi[j] / CellVolumeSqure * d2 * d2;
                    }
                }

                Plane[i].RawIntensity = 0;
                for (int j = 0; j < s.Length; j++)
                    Plane[i].RawIntensity += Plane[i].eachIntensity[j];
            }
           
            var max = Plane.Max(p => p.RawIntensity);
            for (int i = 0; i < Plane.Count; i++)
            {
                //Plane[i].XCalc = 2 * Math.Asin(ramda / 2 / Plane[i].d) / Math.PI * 180;
                Plane[i].Intensity = Plane[i].RawIntensity /max;
                for (int j = 0; j < Plane[i].eachIntensity.Length; j++)
                    Plane[i].eachIntensity[j] /= max;
            }
            #endregion
        }

        #endregion

        /// <summary>
        /// �Ώ̐��A���q�̈ʒu�A�g���Ȃǂ��Čv�Z����
        /// </summary>
        internal void Reset()
        {
            Symmetry = SymmetryStatic.Symmetries[SymmetrySeriesNumber];
            SetAxis();
            for (int i = 0; i < Atoms.Length; i++)
            {
                if (Symmetry.CrystalSystemStr == "hexagonal" || Symmetry.CrystalSystemStr == "trigonal")
                {
                    double value66667;
                    double value33333;
                    if (Miscellaneous.IsDecimalPointComma)
                    {
                        _ = double.TryParse(",66667", out value66667);
                        _ = double.TryParse(",33333", out value33333);
                    }
                    else
                    {
                        _ = double.TryParse(".66667", out value66667);
                        _ = double.TryParse(".33333", out value33333);
                    }

                    if (Atoms[i].X == value66667) Atoms[i].X = 2.0 / 3.0;
                    if (Atoms[i].X == value33333) Atoms[i].X = 1.0 / 3.0;
                    if (Atoms[i].Y == value66667) Atoms[i].Y = 2.0 / 3.0;
                    if (Atoms[i].Y == value33333) Atoms[i].Y = 1.0 / 3.0;
                }
                Atoms[i].ResetSymmetry(SymmetrySeriesNumber);
            }
            GetFormulaAndDensity();
        }

        public void SetCrystallites() => Crystallites = new Crystallite(this);

        public void SetCrystallites(double[] density) => Crystallites = new Crystallite(this, density);

        public void SaveInitialCellConstants()
        {
            InitialA = A;
            InitialB = B;
            InitialC = C;
            InitialAlpha = Alpha;
            InitialBeta = Beta;
            InitialGamma = Gamma;
            InitialA_err = A_err;
            InitialB_err = B_err;
            InitialC_err = C_err;
            InitialAlpha_err = Alpha_err;
            InitialBeta_err = Beta_err;
            InitialGamma_err = Gamma_err;
        }

        public void RevertInitialCellConstants()
        {
            if (InitialA != 0)
            {
                A = InitialA;
                B = InitialB;
                C = InitialC;
                Alpha = InitialAlpha;
                Beta = InitialBeta;
                Gamma = InitialGamma;
                A_err = InitialA_err;
                B_err = InitialB_err;
                C_err = InitialC_err;
                Alpha_err = InitialAlpha_err;
                Beta_err = InitialBeta_err;
                Gamma_err = InitialGamma_err;
            }
        }
    }
}