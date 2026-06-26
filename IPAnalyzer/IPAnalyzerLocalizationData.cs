namespace IPAnalyzer;

// 260626Cl 追加/更新: 多言語化 Phase 2c/3。Localizable=false の 10 フォームが Designer.cs に直書きした可視ラベルの訳テーブル。
// 共有 Crystallography.Localization の中央レジストリへ app-local provider として登録 (Program.Main 冒頭で Register())。
// CodeLocalizer が FullName キー("IPAnalyzer.<Form>")で引き、FormBase.OnLoad で実行時に差し替える (PDIndexerLocalizationData と同方式)。
// en は Designer 原文ママ。de は共有 LocalizationData の独語用語集に準拠 (Phase 3 de波)。fr..ko は空文字 = en フォールバック (各言語整備時に追記)。
internal static class IPAnalyzerLocalizationData
{
    /// <summary>フォーム生成前に1回呼ぶこと (Program.Main 冒頭)。</summary>
    public static void Register() => Crystallography.Localization.AddProvider(Populate);

    private static void Populate(System.Collections.Generic.Dictionary<string, Crystallography.Localization.Entry[]> reg)
    {
        reg["IPAnalyzer.FormAboutMe"] = new Crystallography.Localization.Entry[]
        {
            new("label5", "Text", " Yusuke Seto (Kobe Univ.)", " 瀬戸 雄介 (神戸大学)", " Yusuke Seto (Univ. Kobe)", "", "", "", "", "", "", "", ""),
            new("label6", "Text", "Mail:", "メール:", "E-Mail:", "", "", "", "", "", "", "", ""),
            new("label4", "Text", "HomePage:", "ホームページ:", "Homepage:", "", "", "", "", "", "", "", ""),
            new("label9", "Text", "Please send your comments and requests by email.", "ご意見,ご要望はメールにてご連絡ください。", "Bitte senden Sie Kommentare und Wünsche per E-Mail.", "", "", "", "", "", "", "", ""),
            new("this", "Text", "About Me", "バージョン情報", "Info", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormBlurAngle"] = new Crystallography.Localization.Entry[]
        {
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Blur Angle", "ぼかし角度", "Unschärfewinkel", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormSaveImage"] = new Crystallography.Localization.Entry[]
        {
            new("label1", "Text", "Width", "幅", "Breite", "", "", "", "", "", "", "", ""),
            new("label2", "Text", "Height", "高さ", "Höhe", "", "", "", "", "", "", "", ""),
            new("label3", "Text", "Resolution", "解像度", "Auflösung", "", "", "", "", "", "", "", ""),
            new("label4", "Text", "Size", "サイズ", "Größe", "", "", "", "", "", "", "", ""),
            new("label5", "Text", "New image property", "新しい画像のプロパティ", "Neue Bildeigenschaft", "", "", "", "", "", "", "", ""),
            new("label6", "Text", "Center position", "中心位置", "Zentrumsposition", "", "", "", "", "", "", "", ""),
            new("checkBoxKeepAspect", "Text", "Keep Aspect Ratio", "アスペクト比を保持", "Seitenverhältnis beibehalten", "", "", "", "", "", "", "", ""),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Save IPA Image", "IPA画像の保存", "IPA-Bild speichern", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormParameterOption"] = new Crystallography.Localization.Entry[]
        {
            new("checkBoxWaveLength", "Text", "Wave propety (source, wave length, etc...)", "波長関連 (線源・波長など)", "Welleneigenschaft (Quelle, Wellenlänge usw.)", "", "", "", "", "", "", "", ""),
            new("checkBoxCameraLength", "Text", "Camera length", "カメラ長", "Kameralänge", "", "", "", "", "", "", "", ""),
            new("checkBoxPixelShape", "Text", "Pixel shape", "ピクセル形状", "Pixelform", "", "", "", "", "", "", "", ""),
            new("checkBoxCenterPosition", "Text", "Center position", "中心位置", "Zentrumsposition", "", "", "", "", "", "", "", ""),
            new("checkBoxTiltCorrection", "Text", "Tilt correction", "傾き補正", "Neigungskorrektur", "", "", "", "", "", "", "", ""),
            new("checkBoxSphericalCorrection", "Text", "Spherical correction", "球面補正", "Sphärische Korrektur", "", "", "", "", "", "", "", ""),
            new("checkBoxCameraMode", "Text", "Camera mode (Flat panel or Gandolfi)", "カメラモード (フラットパネル/ガンドルフィ)", "Kameramodus (Flachdetektor oder Gandolfi)", "", "", "", "", "", "", "", ""),
            new("checkBoxGandolfiRadius", "Text", "Gandolfi Radius", "Gandolfi 半径", "Gandolfi-Radius", "", "", "", "", "", "", "", ""),
            new("groupBox2", "Text", "Detector Condition", "検出器の設定", "Detektorbedingung", "", "", "", "", "", "", "", ""),
            new("checkBoxIntegralRegion", "Text", "Integral Region (rectangle, sector, etc...)", "積算領域 (矩形・扇形など)", "Integrationsbereich (Rechteck, Sektor usw.)", "", "", "", "", "", "", "", ""),
            new("checkBoxInetgralProperty", "Text", "Integral Property (angle range, step, etc..)", "積算条件 (角度範囲・ステップなど)", "Integrationseigenschaft (Winkelbereich, Schritt usw.)", "", "", "", "", "", "", "", ""),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Parameter Option", "パラメータオプション", "Parameteroptionen", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCalibrateIntensity"] = new Crystallography.Localization.Entry[]
        {
            new("buttonOpenFile1", "Text", "Open", "開く", "Öffnen", "", "", "", "", "", "", "", ""),
            new("buttonOpenFile2", "Text", "Open", "開く", "Öffnen", "", "", "", "", "", "", "", ""),
            new("buttonCalibrate", "Text", "Calibrate", "校正", "Kalibrieren", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCalibrateRAxisImage"] = new Crystallography.Localization.Entry[]
        {
            new("buttonReadFile1", "Text", "Open", "開く", "Öffnen", "", "", "", "", "", "", "", ""),
            new("buttonReadFile2", "Text", "Open", "開く", "Öffnen", "", "", "", "", "", "", "", ""),
            new("buttonReadFile3", "Text", "Open", "開く", "Öffnen", "", "", "", "", "", "", "", ""),
            new("label2", "Text", "Image 1", "画像 1", "Bild 1", "", "", "", "", "", "", "", ""),
            new("label1", "Text", "Image 2", "画像 2", "Bild 2", "", "", "", "", "", "", "", ""),
            new("label3", "Text", "Image 3", "画像 3", "Bild 3", "", "", "", "", "", "", "", ""),
            new("button4", "Text", "Calc !", "計算 !", "Berechnen !", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormDrawRing"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Draw Ring", "リング描画", "Ring zeichnen", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormCrystal"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Crystal", "結晶", "Kristall", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormFindParameterOption1"] = new Crystallography.Localization.Entry[]
        {
            new("numericBox1", "HeaderText", "Select Image No.", "画像番号を選択", "Bildnummer wählen", "", "", "", "", "", "", "", ""),
            new("this", "Text", "Option", "オプション", "Optionen", "", "", "", "", "", "", "", ""),
        };
        reg["IPAnalyzer.FormFindParameterGeometry"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Schematic Diagram", "模式図", "Schemazeichnung", "", "", "", "", "", "", "", ""),
        };
    }
}
