namespace IPAnalyzer;

// 260626Cl 追加: 多言語化 Phase 2c。Localizable=false の 10 フォームが Designer.cs に直書きした可視ラベルの訳テーブル。
// 共有 Crystallography.Localization の中央レジストリへ app-local provider として登録 (Program.Main 冒頭で Register())。
// CodeLocalizer が FullName キー("IPAnalyzer.<Form>")で引き、FormBase.OnLoad で実行時に差し替える (PDIndexerLocalizationData と同方式)。
// en は Designer 原文ママ (typo 含む)。de..ko は空文字 = en フォールバック (Phase 3 で各言語整備時に追記)。
internal static class IPAnalyzerLocalizationData
{
    /// <summary>フォーム生成前に1回呼ぶこと (Program.Main 冒頭)。</summary>
    public static void Register() => Crystallography.Localization.AddProvider(Populate);

    private static void Populate(System.Collections.Generic.Dictionary<string, Crystallography.Localization.Entry[]> reg)
    {
        reg["IPAnalyzer.FormAboutMe"] = new Crystallography.Localization.Entry[]
        {
            new("label5", "Text", " Yusuke Seto (Kobe Univ.)", " 瀬戸 雄介 (神戸大学)", "", "", "", "", "", "", "", "", ""),
            new("label6", "Text", "Mail:", "メール:", "", "", "", "", "", "", "", "", ""),
            new("label4", "Text", "HomePage:", "ホームページ:", "", "", "", "", "", "", "", "", ""),
            new("label9", "Text", "Please send your comments and requests by email.", "ご意見,ご要望はメールにてご連絡ください。", "", "", "", "", "", "", "", "", ""),
            new("this", "Text", "About Me", "バージョン情報", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormBlurAngle"] = new Crystallography.Localization.Entry[]
        {
            new("buttonCancel", "Text", "Cancel", "キャンセル", "", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Blur Angle", "ぼかし角度", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormSaveImage"] = new Crystallography.Localization.Entry[]
        {
            new("label1", "Text", "Width", "幅", "", "", "", "", "", "", "", "", ""),
            new("label2", "Text", "Height", "高さ", "", "", "", "", "", "", "", "", ""),
            new("label3", "Text", "Resolution", "解像度", "", "", "", "", "", "", "", "", ""),
            new("label4", "Text", "Size", "サイズ", "", "", "", "", "", "", "", "", ""),
            new("label5", "Text", "New image property", "新しい画像のプロパティ", "", "", "", "", "", "", "", "", ""),
            new("label6", "Text", "Center position", "中心位置", "", "", "", "", "", "", "", "", ""),
            new("checkBoxKeepAspect", "Text", "Keep Aspect Ratio", "アスペクト比を保持", "", "", "", "", "", "", "", "", ""),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Save IPA Image", "IPA画像の保存", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormParameterOption"] = new Crystallography.Localization.Entry[]
        {
            new("checkBoxWaveLength", "Text", "Wave propety (source, wave length, etc...)", "波長関連 (線源・波長など)", "", "", "", "", "", "", "", "", ""),
            new("checkBoxCameraLength", "Text", "Camera length", "カメラ長", "", "", "", "", "", "", "", "", ""),
            new("checkBoxPixelShape", "Text", "Pixel shape", "ピクセル形状", "", "", "", "", "", "", "", "", ""),
            new("checkBoxCenterPosition", "Text", "Center position", "中心位置", "", "", "", "", "", "", "", "", ""),
            new("checkBoxTiltCorrection", "Text", "Tilt correction", "傾き補正", "", "", "", "", "", "", "", "", ""),
            new("checkBoxSphericalCorrection", "Text", "Spherical correction", "球面補正", "", "", "", "", "", "", "", "", ""),
            new("checkBoxCameraMode", "Text", "Camera mode (Flat panel or Gandolfi)", "カメラモード (フラットパネル/ガンドルフィ)", "", "", "", "", "", "", "", "", ""),
            new("checkBoxGandolfiRadius", "Text", "Gandolfi Radius", "Gandolfi 半径", "", "", "", "", "", "", "", "", ""),
            new("groupBox2", "Text", "Detector Condition", "検出器の設定", "", "", "", "", "", "", "", "", ""),
            new("checkBoxIntegralRegion", "Text", "Integral Region (rectangle, sector, etc...)", "積算領域 (矩形・扇形など)", "", "", "", "", "", "", "", "", ""),
            new("checkBoxInetgralProperty", "Text", "Integral Property (angle range, step, etc..)", "積算条件 (角度範囲・ステップなど)", "", "", "", "", "", "", "", "", ""),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Parameter Option", "パラメータオプション", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCalibrateIntensity"] = new Crystallography.Localization.Entry[]
        {
            new("buttonOpenFile1", "Text", "Open", "開く", "", "", "", "", "", "", "", "", ""),
            new("buttonOpenFile2", "Text", "Open", "開く", "", "", "", "", "", "", "", "", ""),
            new("buttonCalibrate", "Text", "Calibrate", "校正", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCalibrateRAxisImage"] = new Crystallography.Localization.Entry[]
        {
            new("buttonReadFile1", "Text", "Open", "開く", "", "", "", "", "", "", "", "", ""),
            new("buttonReadFile2", "Text", "Open", "開く", "", "", "", "", "", "", "", "", ""),
            new("buttonReadFile3", "Text", "Open", "開く", "", "", "", "", "", "", "", "", ""),
            new("label2", "Text", "Image 1", "画像 1", "", "", "", "", "", "", "", "", ""),
            new("label1", "Text", "Image 2", "画像 2", "", "", "", "", "", "", "", "", ""),
            new("label3", "Text", "Image 3", "画像 3", "", "", "", "", "", "", "", "", ""),
            new("button4", "Text", "Calc !", "計算 !", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormDrawRing"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Draw Ring", "リング描画", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCrystal"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Crystal", "結晶", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormFindParameterOption1"] = new Crystallography.Localization.Entry[]
        {
            new("numericBox1", "HeaderText", "Select Image No.", "画像番号を選択", "", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Option", "オプション", "", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormFindParameterGeometry"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Schematic Diagram", "模式図", "", "", "", "", "", "", "", "", ""),
        };
    }
}
