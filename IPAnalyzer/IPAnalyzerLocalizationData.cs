namespace IPAnalyzer;

// 260627Cl 更新: 多言語化 Phase 2c/3。Localizable=false の 10 フォームの可視ラベル訳テーブル (全11言語)。
// 共有 Crystallography.Localization の中央レジストリへ app-local provider として登録 (Program.Main 冒頭で Register())。
// CodeLocalizer が FullName キー("IPAnalyzer.<Form>")で引き、FormBase.OnLoad で実行時に差し替える。
// en は Designer 原文ママ。ja/de/fr/es/pt/it/ru/zh-Hans/zh-Hant/ko は用語集準拠・ネイティブ検証 (Phase 3)。
internal static class IPAnalyzerLocalizationData
{
    /// <summary>フォーム生成前に1回呼ぶこと (Program.Main 冒頭)。</summary>
    public static void Register() => Crystallography.Localization.AddProvider(Populate);

    private static void Populate(System.Collections.Generic.Dictionary<string, Crystallography.Localization.Entry[]> reg)
    {
        reg["IPAnalyzer.FormAboutMe"] = new Crystallography.Localization.Entry[]
        {
            new("label5", "Text", " Yusuke Seto (Kobe Univ.)", " 瀬戸 雄介 (神戸大学)", " Yusuke Seto (Univ. Kobe)", " Yusuke Seto (Univ. de Kobe)", " Yusuke Seto (Univ. de Kobe)", " Yusuke Seto (Kobe Univ.)", " Yusuke Seto (Kobe Univ.)", " Yusuke Seto (Kobe Univ.)", " Yusuke Seto (Kobe Univ.)", " Yusuke Seto (神戶大學)", " Yusuke Seto (Kobe Univ.)"),
            new("label6", "Text", "Mail:", "メール:", "E-Mail:", "Courriel :", "Correo:", "E-mail:", "Mail:", "Почта:", "邮箱：", "郵件:", "메일:"),
            new("label4", "Text", "HomePage:", "ホームページ:", "Homepage:", "Page d'accueil :", "Página web:", "Página inicial:", "HomePage:", "Домашняя страница:", "主页：", "首頁:", "홈페이지:"),
            new("label9", "Text", "Please send your comments and requests by email.", "ご意見,ご要望はメールにてご連絡ください。", "Bitte senden Sie Kommentare und Wünsche per E-Mail.", "Veuillez envoyer vos commentaires et demandes par courriel.", "Envíe sus comentarios y solicitudes por correo electrónico.", "Envie seus comentários e solicitações por e-mail.", "Invia i tuoi commenti e richieste via email.", "Отправляйте свои комментарии и пожелания по электронной почте.", "请通过电子邮件发送您的意见和需求。", "請以電子郵件傳送您的意見與需求。", "의견과 요청 사항을 이메일로 보내 주세요."),
            new("this", "Text", "About Me", "バージョン情報", "Info", "À propos", "Acerca de mí", "Sobre mim", "Informazioni", "Об авторе", "关于", "關於我", "소개"),
        };
        reg["IPAnalyzer.FormBlurAngle"] = new Crystallography.Localization.Entry[]
        {
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("this", "Text", "Blur Angle", "ぼかし角度", "Unschärfewinkel", "Angle de flou", "Ángulo de desenfoque", "Ângulo de desfoque", "Angolo di sfocatura", "Угол размытия", "模糊角度", "模糊角度", "블러 각도"),
        };
        reg["IPAnalyzer.FormSaveImage"] = new Crystallography.Localization.Entry[]
        {
            new("label1", "Text", "Width", "幅", "Breite", "Largeur", "Anchura", "Largura", "Larghezza", "Ширина", "宽度", "寬度", "너비"),
            new("label2", "Text", "Height", "高さ", "Höhe", "Hauteur", "Altura", "Altura", "Altezza", "Высота", "高度", "高度", "높이"),
            new("label3", "Text", "Resolution", "解像度", "Auflösung", "Résolution", "Resolución", "Resolução", "Risoluzione", "Разрешение", "分辨率", "解析度", "분해능"),
            new("label4", "Text", "Size", "サイズ", "Größe", "Taille", "Tamaño", "Tamanho", "Dimensione", "Размер", "大小", "大小", "크기"),
            new("label5", "Text", "New image property", "新しい画像のプロパティ", "Neue Bildeigenschaft", "Propriété de la nouvelle image", "Propiedad de la nueva imagen", "Propriedade de nova imagem", "Proprietà della nuova immagine", "Свойства нового изображения", "新建图像属性", "新影像性質", "새 이미지 속성"),
            new("label6", "Text", "Center position", "中心位置", "Zentrumsposition", "Position du centre", "Posición del centro", "Posição do centro", "Posizione del centro", "Положение центра", "中心位置", "中心位置", "중심 위치"),
            new("checkBoxKeepAspect", "Text", "Keep Aspect Ratio", "アスペクト比を保持", "Seitenverhältnis beibehalten", "Conserver les proportions", "Mantener relación de aspecto", "Manter proporção", "Mantieni proporzioni", "Сохранять соотношение сторон", "保持纵横比", "保持長寬比", "종횡비 유지"),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("this", "Text", "Save IPA Image", "IPA画像の保存", "IPA-Bild speichern", "Enregistrer l'image IPA", "Guardar imagen IPA", "Salvar imagem IPA", "Salva immagine IPA", "Сохранить изображение IPA", "保存 IPA 图像", "儲存 IPA 影像", "IPA 이미지 저장"),
        };
        reg["IPAnalyzer.FormParameterOption"] = new Crystallography.Localization.Entry[]
        {
            new("checkBoxWaveLength", "Text", "Wave propety (source, wave length, etc...)", "波長関連 (線源・波長など)", "Welleneigenschaft (Quelle, Wellenlänge usw.)", "Propriété de l'onde (source, longueur d'onde, etc.)", "Propiedad de onda (fuente, longitud de onda, etc...)", "Propriedade da onda (fonte, comprimento de onda, etc...)", "Proprietà dell'onda (sorgente, lunghezza d'onda, ecc...)", "Свойства волны (источник, длина волны и т. д.)", "射线属性 (波源、波长等...)", "波性質 (波源、波長等...)", "파 속성 (선원, 파장 등...)"),
            new("checkBoxCameraLength", "Text", "Camera length", "カメラ長", "Kameralänge", "Longueur de caméra", "Longitud de cámara", "Comprimento da câmera", "Lunghezza camera", "Длина камеры", "相机长度", "相機長度", "카메라 길이"),
            new("checkBoxPixelShape", "Text", "Pixel shape", "ピクセル形状", "Pixelform", "Forme du pixel", "Forma del píxel", "Forma do pixel", "Forma del pixel", "Форма пикселя", "像素形状", "像素形狀", "픽셀 형상"),
            new("checkBoxCenterPosition", "Text", "Center position", "中心位置", "Zentrumsposition", "Position du centre", "Posición del centro", "Posição do centro", "Posizione del centro", "Положение центра", "中心位置", "中心位置", "중심 위치"),
            new("checkBoxTiltCorrection", "Text", "Tilt correction", "傾き補正", "Neigungskorrektur", "Correction d'inclinaison", "Corrección de inclinación", "Correção de inclinação", "Correzione inclinazione", "Коррекция наклона", "倾斜校正", "傾斜校正", "기울기 보정"),
            new("checkBoxSphericalCorrection", "Text", "Spherical correction", "球面補正", "Sphärische Korrektur", "Correction sphérique", "Corrección esférica", "Correção esférica", "Correzione sferica", "Сферическая коррекция", "球面校正", "球面校正", "구면 보정"),
            new("checkBoxCameraMode", "Text", "Camera mode (Flat panel or Gandolfi)", "カメラモード (フラットパネル/ガンドルフィ)", "Kameramodus (Flachdetektor oder Gandolfi)", "Mode de caméra (panneau plat ou Gandolfi)", "Modo de cámara (panel plano o Gandolfi)", "Modo da câmera (Painel plano ou Gandolfi)", "Modalità camera (Pannello piatto o Gandolfi)", "Режим камеры (плоская панель или Гандольфи)", "相机模式 (平板或 Gandolfi)", "相機模式 (平板或 Gandolfi)", "카메라 모드 (플랫 패널 또는 간돌피)"),
            new("checkBoxGandolfiRadius", "Text", "Gandolfi Radius", "Gandolfi 半径", "Gandolfi-Radius", "Rayon Gandolfi", "Radio de Gandolfi", "Raio de Gandolfi", "Raggio Gandolfi", "Радиус Гандольфи", "Gandolfi 半径", "Gandolfi 半徑", "간돌피 반지름"),
            new("groupBox2", "Text", "Detector Condition", "検出器の設定", "Detektorbedingung", "Condition du détecteur", "Condición del detector", "Condição do detector", "Condizione del rivelatore", "Условия детектора", "探测器条件", "偵測器條件", "검출기 조건"),
            new("checkBoxIntegralRegion", "Text", "Integral Region (rectangle, sector, etc...)", "積算領域 (矩形・扇形など)", "Integrationsbereich (Rechteck, Sektor usw.)", "Région d'intégration (rectangle, secteur, etc.)", "Región de integración (rectángulo, sector, etc...)", "Região de integração (retângulo, setor, etc...)", "Regione di integrazione (rettangolo, settore, ecc...)", "Область интегрирования (прямоугольник, сектор и т. д.)", "积分区域 (矩形、扇形等...)", "積分區域 (矩形、扇形等...)", "적분 영역 (직사각형, 부채꼴 등...)"),
            new("checkBoxInetgralProperty", "Text", "Integral Property (angle range, step, etc..)", "積算条件 (角度範囲・ステップなど)", "Integrationseigenschaft (Winkelbereich, Schritt usw.)", "Propriété d'intégration (plage d'angle, pas, etc.)", "Propiedad de integración (rango angular, paso, etc..)", "Propriedade de integração (intervalo de ângulo, passo, etc..)", "Proprietà di integrazione (intervallo angolare, passo, ecc..)", "Свойства интегрирования (диапазон углов, шаг и т. д.)", "积分属性 (角度范围、步长等...)", "積分性質 (角度範圍、步進等...)", "적분 속성 (각도 범위, 스텝 등...)"),
            new("buttonCancel", "Text", "Cancel", "キャンセル", "Abbrechen", "Annuler", "Cancelar", "Cancelar", "Annulla", "Отмена", "取消", "取消", "취소"),
            new("this", "Text", "Parameter Option", "パラメータオプション", "Parameteroptionen", "Options de paramètre", "Opción de parámetro", "Opção de parâmetro", "Opzioni parametri", "Параметры", "参数选项", "參數選項", "매개변수 옵션"),
        };
        reg["IPAnalyzer.FormCalibrateIntensity"] = new Crystallography.Localization.Entry[]
        {
            new("buttonOpenFile1", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("buttonOpenFile2", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("buttonCalibrate", "Text", "Calibrate", "校正", "Kalibrieren", "Étalonner", "Calibrar", "Calibrar", "Calibra", "Калибровать", "校准", "校正", "보정"),
        };
        reg["IPAnalyzer.FormCalibrateRAxisImage"] = new Crystallography.Localization.Entry[]
        {
            new("buttonReadFile1", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("buttonReadFile2", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("buttonReadFile3", "Text", "Open", "開く", "Öffnen", "Ouvrir", "Abrir", "Abrir", "Apri", "Открыть", "打开", "開啟", "열기"),
            new("label2", "Text", "Image 1", "画像 1", "Bild 1", "Image 1", "Imagen 1", "Imagem 1", "Immagine 1", "Изображение 1", "图像 1", "影像 1", "이미지 1"),
            new("label1", "Text", "Image 2", "画像 2", "Bild 2", "Image 2", "Imagen 2", "Imagem 2", "Immagine 2", "Изображение 2", "图像 2", "影像 2", "이미지 2"),
            new("label3", "Text", "Image 3", "画像 3", "Bild 3", "Image 3", "Imagen 3", "Imagem 3", "Immagine 3", "Изображение 3", "图像 3", "影像 3", "이미지 3"),
            new("button4", "Text", "Calc !", "計算 !", "Berechnen !", "Calc. !", "¡Calcular!", "Calcular !", "Calcola !", "Расчёт !", "计算 !", "計算 !", "계산 !"),
        };
        reg["IPAnalyzer.FormDrawRing"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Draw Ring", "リング描画", "Ring zeichnen", "Tracer l'anneau", "Dibujar anillo", "Desenhar anel", "Disegna anello", "Нарисовать кольцо", "绘制环", "繪製環", "링 그리기"),
        };
        reg["IPAnalyzer.FormCrystal"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Crystal", "結晶", "Kristall", "Cristal", "Cristal", "Cristal", "Cristallo", "Кристалл", "晶体", "晶體", "결정"),
        };
        reg["IPAnalyzer.FormFindParameterOption1"] = new Crystallography.Localization.Entry[]
        {
            new("numericBox1", "HeaderText", "Select Image No.", "画像番号を選択", "Bildnummer wählen", "Sélectionner le n° d'image", "Seleccionar n.º de imagen", "Selecionar nº da imagem", "Seleziona n. immagine", "Выбрать № изображения", "选择图像编号", "選取影像編號", "이미지 번호 선택"),
            new("this", "Text", "Option", "オプション", "Optionen", "Option", "Opción", "Opção", "Opzioni", "Параметры", "选项", "選項", "옵션"),
        };
        reg["IPAnalyzer.FormFindParameterGeometry"] = new Crystallography.Localization.Entry[]
        {
            new("this", "Text", "Schematic Diagram", "模式図", "Schemazeichnung", "Schéma de principe", "Diagrama esquemático", "Diagrama esquemático", "Schema", "Схематическая диаграмма", "示意图", "示意圖", "개략도"),
        };
    }
}
