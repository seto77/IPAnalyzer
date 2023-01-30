namespace IPAnalyzer;

static class Version
{
    static public string Software =
        "IPAnalyzer"
        ;
    static public string VersionAndDate { get => History.Remove(0, 10).Remove(20); }

    static public string History =
        "History" +
        "\r\n ver3.941(2023/01/30) Added: Polygon mode for the mask option." +
        "\r\n ver3.940(2023/01/27) Improved azimuthal division analysis functionality." +
        "\r\n ver3.939(2023/01/23) Fixed minor bugs on 'Auto Procedure'. " +
        "\r\n ver3.938(2022/11/28) Fixed a minor bug on 'Find Parameter'. " +
        "\r\n ver3.937(2022/11/16) Target framework has been changed to .Net Desktop Runtime 7.0." +
        "\r\n ver3.936(2022/11/07) Supported reading '*.img' files output from ADXV." +
        "\r\n ver3.935(2022/10/15) Fixed a bug when saving Tiff file that contains multiple images." +
        "\r\n ver3.933(2022/07/20) Fixed a bug on Find Parameter (brute force)." +
        "\r\n ver3.932(2022/06/29) Improved a sequential image loading. " +
        "\r\n ver3.931(2022/06/26) Improved macro function and top form design. " +
        "\r\n ver3.930(2021/12/01) Fixed a bug on generating unrolled images." +
        "\r\n ver3.929(2021/11/30) Added color scales and scale line drawing." +
        "\r\n ver3.928(2021/11/23) Fixed a minor bug." +
        "\r\n ver3.927(2021/11/22) Fixed bugs on a GUI design." +
        "\r\n ver3.926(2021/11/18) Fixed bugs on loading a parameter file (*.prm)." +
        "\r\n ver3.920(2021/11/12) Target framework has been changed to .Net 6.0." +
        "\r\n ver3.918(2021/11/03) Fixed a minor bug on reading parameter files." +
        "\r\n ver3.917(2021/10/15) Fixed the problem on the Macro function." +
        "\r\n ver3.916(2021/10/12) Fixed the problem of broken design at high DPI." +
        "\r\n ver3.915(2021/10/11) Added the exporting function as GSAS format." +
        "\r\n ver3.914(2021/09/21) Fixed minor bugs about the sequential image mode." +
        "\r\n ver3.913(2021/09/08) Improved mask options. Fixed a bug on 'd-spacing mode'. Improved compatibility of HDF5." +
        "\r\n ver3.912(2021/08/17) Improved compatibility when importing HDF5 files." +
        "\r\n ver3.911(2021/08/10) Renewed 'Find parameter (brute force)'." +
        "\r\n ver3.910(2021/07/19) Fixed a minor bug on 'Fitting parameter' " +
        "\r\n ver3.909(2021/07/10) Fixed a minor bug on 'Fitting parameter' " +
        "\r\n ver3.908(2021/07/01) Target framework has been changed to .Net 5.0" +
        "\r\n ver3.907(2021/05/02) Improved: Image rendering speed and processing speed of 'Find center'" +
        "\r\n ver3.906(2021/05/01) Improved: Speeding up 'Get Profile' and GUI response. Added: mask options." +
        "\r\n ver3.904(2020/12/18) Improved macro functions." +
        "\r\n ver3.903(2020/12/11) Fixed a bug when loading TIFF format." +
        "\r\n ver3.902(2020/12/02) Fixed minor bugs." +
        "\r\n ver3.901(2020/11/17) Added a new image format (*.raw file used in PF)" +
        "\r\n ver3.900(2020/11/16) Fixed a bug when loading Rad-icon file." +
        "\r\n ver3.899(2020/10/31) Improved: Speeding up 'Get Profile'." +
        "\r\n ver3.898(2020/10/25) Fixed a bug on loading ITEX image." +
        "\r\n ver3.897(2020/10/25) Improved SACLA EH5 mode." +
        "\r\n ver3.896(2020/10/15) Fixed minor bugs (Find Center, Correction of polarization, etc.)." +
        "\r\n ver3.895(2020/08/13) Fixed bugs on Macro functions." +
        "\r\n ver3.894(2020/08/08) Improved SACLA EH5 mode." +
        "\r\n ver3.893(2020/07/28) Improved SACLA EH5 mode." +
        "\r\n ver3.892(2020/06/24) Added 'Summation' mode for a sequential image" +
        "\r\n ver3.891(2020/04/10) Fixed a minor bug on 'Program update function'" +
        "\r\n ver3.890(2020/04/09) Added an image format: 32 bit signed Tiff (output of PILATUS CdSe detector)." +
        "\r\n ver3.889(2020/03/11) Minor improvements to the macro functions." +
        "\r\n ver3.888(2020/03/03) Fixed a minor bug on distribution problem." +
        "\r\n ver3.887(2020/03/01) Changed: Distribution site is changed to GitHub." +
        "\r\n ver3.886(2020/02/28) Improved: Sacla XFEL option." +
        "\r\n ver3.885(2019/11/11) Fixed a minor bug on loading sequential image." +
        "\r\n ver3.884(2019/11/07) Fixed a minor bug on the ’Find parameter' function." +
        "\r\n ver3.881(2019/10/06) Fixed a minor bug on the ’Find parameter' function." +
        "\r\n ver3.88 (2019/04/10) Changed the installer. ClickOnce version will be not maintained in the future." +
        "\r\n ver3.875(2019/03/21) Fixed a minor bug on a background subtraction option." +
        "\r\n ver3.874(2019/03/19) Added a background subtraction option." +
        "\r\n ver3.873(2019/03/18) Minor improvements for sequential image mode." +
        "\r\n ver3.872(2019/03/15) Added a new image format (Dexlea co, *.smv file.)." +
        "\r\n ver3.871(2019/03/03) Minor bug fixed: the definition of sector angle is modified correctly." +
        "\r\n ver3.870(2019/02/20) Changed .Net framework version to 4.7.2." +
        "\r\n ver3.869(2018/11/20) Modified some incosistensies." +
        "\r\n ver3.868(2018/09/04) Renewed libraries." +
        "\r\n ver3.867(2018/09/04) Fixed a minor bug." +
        "\r\n ver3.866(2018/08/21) Fixed a minor bug." +
        "\r\n ver3.865(2017/12/14) Fixed a minor bug." +
        "\r\n ver3.864(2017/12/03) Fixed a minor bug." +
        "\r\n ver3.863(2017/07/18) Added a new image format." +
        "\r\n ver3.862(2017/04/26) Fix a bug related with a change on 2016/12/28. Improved a SACLA EH5 optimization." +
        "\r\n ver3.861(2017/01/13) Fix a bug related with a change on 2016/12/28." +
        "\r\n ver3.86 (2016/12/28) Fix a bug on 'Get Profile' for diffraction patterns which include 2 theta > 90 deg." +
        "\r\n ver3.851(2016/12/16) Bug fix for a function of rotate image. Improved a SACLA EH5 optimization." +
        "\r\n ver3.85 (2016/12/04) Added options to rotate image. A rotation angle was automatically saved for each image format" +
        "\r\n ver3.84 (2016/12/02) Added readable image format: '*.raw' file from RadIcon 2064x1548 detectors. " +
        "\r\n ver3.837(2016/07/09) Improved: A color tiff format (RGB and ARGB) is possible to be read as a gray scale image, where red channel is only used. " +
        "\r\n ver3.836(2016/07/06) Fixed a minor bug." +
        "\r\n ver3.835(2016/06/13) Fixed a problem on *.h5 file loading, and improved saving/loading SACLA EH5 parameters." +
        "\r\n ver3.834(2016/05/31) Minor bug fixed." +
        "\r\n ver3.832(2016/05/31) Minor bug fixed." +
        "\r\n ver3.83 (2016/05/21) Improved the unrolled image function for Gandolfi images." +
        "\r\n ver3.82 (2016/04/18) Improved the save parameter option." +
        "\r\n ver3.81 (2016/02/24) Added a 'Polarization Correction' option." +
        "\r\n ver3.80 (2016/01/15) Fixed a major bug on the 'Get Profile' algorithm where cos^3 correction had been not made. The present version fixed this problem." +
        "\r\n ver3.79 (2016/01/06) Added gandolfi camera options." +
        "\r\n ver3.784(2015/12/23) Fixed minor bugs on initial loading." +
        "\r\n ver3.782(2015/12/18) Fixed minor bugs." +
        "\r\n ver3.781(2015/11/30) Fixed minor bugs." +
        "\r\n ver3.78 (2015/11/16) Added a new image format (*.img) for CCD detector made by ADSC." +
        "\r\n ver3.776(2015/10/31) Fixed a minor bug on reading his (Perkin Elmer co.) files." +
        "\r\n ver3.775(2015/09/24) Fixed a minor bug on reading his (Perkin Elmer co.) files." +
        "\r\n ver3.774(2015/09/16) Fixed a minor bug on reading/writing TIFF files." +
        "\r\n ver3.773(2015/08/28) Fixed a minor bug on reading/writing TIFF files." +
        "\r\n ver3.772(2015/08/22) Fixed a minor bug on reading/writing TIFF files." +
        "\r\n ver3.771(2015/08/19) Fixed a minor bug on reading HDF5 files." +
        "\r\n ver3.77 (2015/08/09) Added: Enabled to read multipule-image tiff file." +
        "\r\n ver3.76 (2015/04/12) Improved 'Find Center' function." +
        "\r\n ver3.753(2015/04/05) Fixed a minor bug on 'Find Center'." +
        "\r\n ver3.752(2015/01/27) Added built-in functions to macro." +
        "\r\n ver3.751(2015/01/15) Fixed minor bugs on a calculation of the selected sector region." +
        "\r\n ver3.75 (2014/12/26) Improved macro functions (still under construction)." +
        "\r\n ver3.742(2014/12/17) Improved macro functions (still under construction)." +
        "\r\n ver3.741(2014/12/09) Added macro function (under construction)." +
        "\r\n ver3.74 (2014/12/03) Improved SACLA EH5 option." +
        "\r\n ver3.732(2014/12/02) Fixed a minor bug on 'Draw Ring'." +
        "\r\n ver3.731(2014/11/14) Improved: Enabled to translate image by mouse right drag." +
        "\r\n ver3.73 (2014/11/13) Added: Statistical information for selected area." +
        "\r\n ver3.724(2014/11/12) Fixed minor bugs." +
        "\r\n ver3.723(2014/11/11) Fixed minor bugs." +
        "\r\n ver3.722(2014/11/11) Inproved input form for SACLA EH5 beamline." +
        "\r\n ver3.721(2014/11/10) Fixed minor bugs." +
        "\r\n ver3.72 (2014/10/08) Added readable image format: HDF5 (*.h5) from SACLA EH5 beamline" +
        "\r\n ver3.712(2014/10/06) Added options for sequential image mode: Getting sequential or average profiles options" +
        "\r\n ver3.711(2014/10/04) Improved for sequential image mode: serial number is displayed on menu and is also sent to PDIndexer" +
        "\r\n ver3.71 (2014/09/30) Added readable image format: tiff with 32-bit floating value." +
        "\r\n ver3.70 (2014/09/29) Added Sequential Image mode (for *.his image)." +
        "\r\n ver3.61 (2014/07/02) Added a new image format: '*.his' file(Perkin Elmer co., Flat panel CCD)." +
        "\r\n ver3.603(2014/03/13) Fixed a minor bug on 'Find Parameter'." +
        "\r\n ver3.602(2013/12/17) Improved language option." +
        "\r\n ver3.601(2013/12/14) Fixed minor bugs." +
        "\r\n ver3.60 (2013/12/08) Inproved stabilities and speed of 'Find Parameter'" +
        "\r\n ver3.595(2013/11/11) Fixed a minor bug on 'Find Parameter'" +
        "\r\n ver3.594(2013/11/10) Fixed a minor bug on whole design" +
        "\r\n ver3.593(2013/11/06) Fixed a minor bug on clipboard operation" +
        "\r\n ver3.592(2013/07/06) Fixed a minor bug in Find Parameter" +
        "\r\n ver3.591(2013/02/26) Changed adress of help page." +
        "\r\n ver3.59 (2013/02/25) Added: Update check function." +
        "\r\n ver3.582(2012/12/27) Fixed minor bugs" +
        "\r\n ver3.581(2012/12/05) Fixed minor bugs" +
        "\r\n ver3.58 (2012/11/12) Improved 'Find Parameter' appearance" +
        "\r\n ver3.57 (2012/11/11) Improved 'Find Parameter' stability (maybe)" +
        "\r\n ver3.56 (2012/09/24) Added a new image format: *.mccd file (from SX-165 ccd camera)" +
        "\r\n ver3.551(2012/08/21) Fixed: a minor bug." +
        "\r\n ver3.55 (2012/08/21) Added: Chi-axis option." +
        "\r\n ver3.542(2012/08/20) Fixed: save the concentric/radial mode properly" +
        "\r\n ver3.541(2012/08/12) Fixed: Unrolled image is now correctly calculated by a spherical correction parameter" +
        "\r\n ver3.54 (2012/08/11) Added: Circle, rectangle and spline curve mask mode" +
        "\r\n ver3.534(2012/07/25) Fixed: Dtring size for customized setting" +
        "\r\n ver3.533(2012/07/25) Fixed: Design of 'Find parameter' form" +
        "\r\n ver3.532(2012/07/24) Improved: Design of 'Property' form" +
        "\r\n ver3.531(2012/06/29) Fixed: Small problems on the 'Get Intensity' function." +
        "\r\n ver3.53 (2012/06/05) Added: Spherical Correction parameter to the 'Find Parameter' function" +
        "\r\n ver3.522(2012/05/15) Fixed a bug on 'FindParameter'" +
        "\r\n ver3.521(2012/05/15) Fixed an error on reading MarCCD format." +
        "\r\n ver3.52 (2012/02/10) Fixed a problem on inteinsity value on GEL format. (linear => square)" +
        "\r\n ver3.512(2011/12/19) Fixed bugs on find parameter on japanese mode." +
        "\r\n ver3.511(2011/10/20) Draw ring function was fixed." +
        "\r\n ver3.51 (2011/10/12) Fixed problems on the FindParameter in Japanese language mode." +
        "\r\n ver3.50 (2011/10/05) Supported language option (English or Japanese). Fixed the file-foemat problem on the FindParameter form." +
        "\r\n ver3.43 (2011/08/30) supported mar345 IP format (*.mar*)" +
        "\r\n ver3.42 (2011/07/22) 入射線源部分の改良" +
        "\r\n ver3.412(2011/07/12) Unrollled Imageの左端の部分が切れてしまう問題を解消。" +
        "\r\n ver3.411(2011/07/12) 下の更新のバグ(横軸目盛がずれる)を修正しました。" +
        "\r\n ver3.41 (2011/07/12) Unrolled Imageを保存できるようにしました(Save Imageからtifまたはpng, pngの場合は目盛つき)。また、Unroll imageをBB光学系と一致するように強度補正しました。" +
        "\r\n ver3.401(2011/07/06) 自動保存したプロファイルのファイル名から、元画像の拡張子を削除" +
        "\r\n ver3.40 (2011/07/05) 揺動したRAxisIVファイル(*.osc)の読み込みに対応 && DrawRingのバグ修正" +
        "\r\n ver3.391(2011/06/23) FindParameter部分のバグを修正(中野さま、有難うございます)" +
        "\r\n ver3.39 (2011/05/10) 画像を円周方向に沿ってにじませる機能(Circumferentialblur)を付けました。" +
        "\r\n ver3.38 (2011/04/01) 入射X線のエネルギーを入力できるようにしました。" +
        "\r\n ver3.37 (2011/03/24) Tiff形式、Png形式で保存できるようにしました。" +
        "\r\n ver3.36 (2011/03/22) GEヘルスケア社のFLA7000ファイル形式(gel)に対応。" +
        "\r\n ver3.352(2011/01/24) デザインを再度変更" +
        "\r\n ver3.351(2010/12/08) デザインを若干変更" +
        "\r\n ver3.35 (2010/12/06) PDIndexerにUnrolled Imageを送信する機能を追加。Property=>After GetProfileでSend also Unrolled Imageをチェックすると有効になります。" +
        "\r\n ver3.34 (2010/12/05) 拡張子の関連付けに対応(PropertyからAssociated Extensions)。AutoProcedureの改善。" +
        "\r\n ver3.33 (2010/11/29) MainFormのデザイン変更。パラメータファイルに中心位置を保存/読出。FixCenter機能(中心位置を固定する)を追加。" +
        "\r\n ver3.32 (2010/11/15) Help=>Help(Web)のリンク先を変更。ヘルプ自体は鋭意作成中です。" +
        "\r\n ver3.31 (2010/11/15) 終了時のレジストリ操作で例外が発生するバグを修正＆メイン画面上部にchi角を表示" +
        "\r\n ver3.30 (2010/11/08) 初回起動時にバックグラウンドでネイティブコードを生成するように変更。二回目以降の起動が早くなります。" +
        "\r\n ver3.20 (2010/11/05) Rayonix社SX-200 (CCDカメラ) のファイル形式に対応しました。" +
        "\r\n ver3.192(2010/11/02) 画像拡大縮小のオーバーヘッドを減らして処理を高速化" +
        "\r\n ver3.191(2010/11/02) 画像読み込み時の処理を高速化" +
        "\r\n ver3.19 (2010/11/01) 浜ホトCCDの形式(ITEX形式)に対応しました。" +
        "\r\n ver3.18 (2010/10/29) 切り開きイメージ(Unrolled Image ?)の作成に対応。フォーム下の「Unroll」ボタンを押すと実行できます。" +
        "\r\n ver3.17 (2010/09/09) FujiのFDLを読み込めるように改良 + さまざまな媒体ごとの実験条件(波長、カメラ長など)を保存・読み込みするように修正" +
        "\r\n ver3.163(2010/08/25) FindParameter からCopyToClipboardする時の表記間違いを修正(阪大・下堂さんありがとう)" +
        "\r\n ver3.162(2010/05/29) FindParameter画面が開いているとき、メイン画面のGetProfileが距離モードになってしまう問題を修正" +
        "\r\n ver3.161(2010/05/18) ver3.16の機能追加でFindParameterがうまく動いていなかったバグを修正 (阪大 下堂さん、ご指摘ありがとうございます。" +
        "\r\n ver3.16 (2010/05/09) Cake (あるいはRadial) Pattern の計算に対応しました。" +
        "\r\n ver3.152(2010/04/19) ver3.151で送信データが最後に取得したパターンになってしまっていたバグを修正(久保さん、ご指摘有難うございます)" +
        "\r\n ver3.151(2010/04/18) LPO(セクター)データを送信時、最後にまとめて送信するように仕様変更。PDIndexerが安定して受け取れると思います。" +
        "\r\n ver3.15 (2010/04/13) FindParameterの部分を久々に改良。IP Tiltパラメータや中心位置の誤差を表示できるようにしました。" +
        "\r\n ver3.141(2010/03/31) GetProfile後にファイル保存する機能がLPOオン時にうまく動いていなかった問題を修正" +
        "\r\n ver3.14 (2010/03/31) FindParameter部分で標準結晶の回折線が消滅則を考慮していなかった問題を修正 + GetProfile後にファイル保存する機能を修正" +
        "\r\n ver3.13 (2010/03/29) LPO解析時、データをうまく送信できなかったバグを修正 (佐藤さん、ご指摘ありがとうございます)" +
        "\r\n ver3.12 (2010/02/23) FujiBAS2000の10bitデータを読み込めなかったバグを修正 (鍵様、ご迷惑をおかけしました)" +
        "\r\n ver3.11 (2010/01/25) RAXIS-Vのデータを読み込めるようにしました。+ FittingParameter中でピーク位置の読み取りができていなかったバグを修正" +
        "\r\n ver3.10 (2009/10/20) アプリ間の結晶データ送信が正常に行えなかったバグを修正" +
        "\r\n ver3.09 (2009/09/24) 画像の明るさ設定を改良しました。画面下部のヒストグラムの上限、下限のラインをドラッグして明るさを調整できます" +
        "\r\n ver3.08 (2009/09/03) 64bit OS に対応しました。" +
        "\r\n ver3.07 (2009/08/18) FindParameterで、StandardCrystalを使わずに、ダブルカセット条件でカメラ長を求められるようになりました。" +
        "\r\n ver3.06 (2009/08/17) 出力プロファイルをブラッグブレンターノと一致するよう修正しました。今までより高角側の強度が若干高くなります。（小松さんに感謝)" +
        "\r\n ver3.05 (2009/06/13) 直前の更新にバグ(高さと幅が等しくない画像を読み込めない)がありましたので修正。(飯塚さんに感謝)" +
        "\r\n ver3.04 (2009/06/10) 画像の縁の部分をカットできるオプション(Exclude the edge of the image)を追加しました。" +
        "\r\n ver3.03 (2008/12/25) FindParameter周りを修正 & ClickOnceが不調なので再発行しました。" +
        "\r\n ver3.02 (2008/10/30) 画像読み込み時のバグを修正" +
        "\r\n ver3.01 (2008/10/30) 起動を若干高速化しました。" +
        "\r\n ver3.00 (2008/10/30) マニュアルスポット切り替えボタンを表に出しました。" +
        "\r\n ver2.99 (2008/06/20) メールアドレスなど変更" +
        "\r\n ver2.97 (2008/06/11) 強度頻度図のバグを修正 & 画像表示のバグを修正" +
        "\r\n ver2.96 (2008/05/29) ManualSpotモードにすると強制終了してしまうバグを修正" +
        "\r\n ver2.95 (2008/03/08) FindParameter周りを安定化&精密化" +
        "\r\n ver2.94 (2008/02/27) 強度頻度図を計算する機能を追加＆デザイン変更" +
        "\r\n ver2.93 (2008/02/14) FindParameter周りのバグ修正" +
        "\r\n ver2.92 (2008/02/14) 巨大なファイルを読み込んでも強制終了しないように改良。(速度が若干落ちたかも)" +
        "\r\n ver2.91 (2008/01/26) 起動時にヒントを表示するようにしました。" +
        "\r\n ver2.90 (2008/01/22) 前回開いたディレクトリを記憶するようにしました。" +
        "\r\n ver2.89 (2008/01/21) 発行元を変えました" +
        "\r\n ver2.88 (2008/01/21) スクロールバーがおかしくなっていたのを修正。アイコンに絵をつける" +
        "\r\n ver2.87 (2008/01/16) 16bitグレースケールのTiff画像を読み込めるようにしました。" +
        "\r\n ver2.86 (2008/01/07) 内部形式を変更" +
        "\r\n ver2.85 (2007/12/05) 内部形式を変更 PDIndexerのver3.22以下にはデータを送信できません。" +
        "\r\n ver2.84 (2007/11/24) 形式の違うデータを連続して読み込むときの異常終了を修正" +
        "\r\n ver2.83 (2007/11/14) 強度が飽和した点を含む画像を正常に読み込めなかったバグを修正" +
        "\r\n ver2.82 (2007/10/27) 共通フォーム&コントロールの部分を分離しDLL化した" +
        "\r\n ver2.81 (2007/10/25) 画像表示の部分を大幅変更。スクロールできるようになりました。拡大縮小は右クリックに変更" +
        "\r\n ver2.80 (2007/10/12) プロファイルの保存(Set a directory each time)がうまく動作していなかったのを修正" +
        "\r\n ver2.79 (2007/10/09) FindParameterがたまに止まってしまうバグを修正" +
        "\r\n ver2.78 (2007/10/08) Get Profile後の自動プロファイル保存を改良" +
        "\r\n ver2.77 (2007/08/10) PDIndexerへプロファイルデータの送信時、まれに止まってしまうバグを修正" +
        "\r\n ver2.76 (2007/08/06) AutoProcedure のバグ修正。ファイル更新を監視し、読み込み・積分を自動化できます。" +
        "\r\n ver2.75 (2007/07/25) Find Parameterが不安定になってしまうバグを改良" +
        "\r\n ver2.74 (2007/07/05) 結晶軸の計算がおかしかったのを修正" +
        "\r\n ver2.73 (2007/06/27) Find Parameterが不安定になってしまうバグを改良" +
        "\r\n ver2.72 (2007/06/25) Find Parameterで簡単にCameraLength, WaveLengthを求める機能を追加" +
        "\r\n ver2.71 (2007/06/25) マスク情報を保存できるようにしました。" +
        "\r\n ver2.70 (2007/06/24) Find parameterで結晶がうまく更新できないバグを修正" +
        "\r\n ver2.69 (2007/06/22) ホームページのアドレス変更" +
        "\r\n ver2.68 (2007/06/20) ショートカット機能をつけました。内容は画面下部を参照してください。" +
        "\r\n ver2.67 (2007/06/06) Drag&Dropで画像データ、パラメータデータを受け取れるようにした。" +
        "\r\n ver2.66 (2007/06/03) Brucker CCD ファイルを読み込み後、メモリを解放していなかったバグを修正" +
        "\r\n ver2.65 (2007/04/13) 積算横軸のステップ表示･設定を修正" +
        "\r\n ver2.64 (2007/04/09) 積算時の横軸を Angle,Length,d-spacingの三つに整理しました。" +
        "\r\n ver2.63 (2007/03/22) バックグラウンド減算機能を追加。まだまだ検討の余地あり。" +
        "\r\n ver2.62 (2007/03/10) 読み込んだイメージを保存できるようにしました＆DrawRingのバグ修正" +
        "\r\n ver2.61 (2007/03/09) FindParameterでスタンダード結晶をうまく設定できなかったのを修正" +
        "\r\n ver2.60 (2007/03/06) FujiのデータでFindSpotのmanual設定がうまくできなかったのを修正" +
        "\r\n ver2.59 (2007/03/06) 強度を擬似カラー化できるようにしました" +
        "\r\n ver2.58 (2007/03/02) FindParameterでセクターモードを選べるようにしました。" +
        "\r\n ver2.57 (2007/02/23) RAXISのデータがうまく読み込めない場合があったバグを修正" +
        "\r\n ver2.56 (2007/02/07) ↓の機能がうまく動いていなかったバグ修正" +
        "\r\n ver2.55 (2007/02/06) 前回起動時のフォームサイズ・位置や、波長・カメラ長といったパラメータを再現" +
        "\r\n ver2.54 (2007/02/03) プログラムの署名が期限切れになったため再発行しました。" +
        "\r\n ver2.53 (2007/01/12) FindParameter時にSpotsの情報を保存するようにした" +
        "\r\n ver2.52 (2007/01/12) 中心付近の画像表示する機能を追加" +
        "\r\n ver2.51 (2006/12/23) FindParameterの結果をクリップボードにコピーする機能追加" +
        "\r\n ver2.50 (2006/12/20) FindParameterの改良&デザイン変更。 収束性が良くなった･･･はず" +
        "\r\n ver2.41 (2006/12/12) 画面上部にサムネイル画像を表示するようしました。" +
        "\r\n ver2.40 (2006/12/10) 画面上部に積算したプロファイルを表示するようしました。" +
        "\r\n ver2.30 (2006/11/19) こまかいバグ修正 + FindParameter時にピーク分離フィッティングを実装" +
        "\r\n ver2.27 (2006/11/07) セクター領域のバグを修正 + ツールチップを追加" +
        "\r\n ver2.26 (2006/11/05) 細かいバグ修正" +
        "\r\n ver2.25 (2006/11/01) バグ修正(マルチスレッドを有効にするのを忘れてました)" +
        "\r\n ver2.24 (2006/10/27) 細かいバグ修正" +
        "\r\n ver2.23 (2006/10/18) FindParameter改良 収束が早くなりました。" +
        "\r\n ver2.22 (2006/10/16) Find Center & Spots 高速化" +
        "\r\n ver2.21 (2006/10/14) GetProfileをわずかに高速化+バグ修正" +
        "\r\n ver2.20 (2006/10/12) FindParameter部分大幅改良 + PseudoVoigtのアルゴリズムを改良" +
        "\r\n ver2.12 (2006/09/12) FindParameter バックグラウンドフィッティング追加" +
        "\r\n ver2.11 (2006/09/08) FindCenter 改良" +
        "\r\n ver2.10 (2006/08/13) FindParameterを高速化 & 改良　角度表現をまた変えてしまいました" +
        "\r\n ver2.02 (2006/07/19) FindParameterを高速化 & Sector領域のバグを修正" +
        "\r\n ver2.01 (2006/07/11) DrawRingのバグ修正" +
        "\r\n ver2.0  (2006/07/06) FindParameterを改良 & DrawRingにバグ発見するも直せず･･･" +
        "\r\n ver1.83 (2006/06/28) R-Axis4の読み込みを修正" +
        "\r\n ver1.82 (2006/06/28) FindCenterを改良 & ファイル読み込み時に発生するエラーを修正" +
        "\r\n ver1.81 (2006/06/13) バグフィックス" +
        "\r\n ver1.8  (2006/06/09) DrawRing機能追加。画像中にリングを描くことができます" +
        "\r\n ver1.71 (2006/06/08) FindParameterを改良。途中でストップできるようにした" +
        "\r\n ver1.7  (2006/06/03) FindParameterを大きく変更。TiltCorrectionの自動計算を追加" +
        "\r\n ver1.6  (2006/05/12) GUIを大幅に変更" +
        "\r\n ver1.51 (2006/04/24) FittingParameterの結晶変更のところが動いてなかったのを修正" +
        "\r\n ver1.5  (2006/04/19) TiltCorrection機能追加。" +
        "\r\n ver1.41 (2006/04/09) バグフィックス＆Threshold機能追加" +
        "\r\n ver1.1-4(2006年初)   いろいろ追加(何をしたかわすれました)" +
        "\r\n ver1.00 (2005年末)   とりあえず動いた！！。"
        ;




    /// <summary>
    /// はじめに
    /// </summary>
    static public string Introduction =
        "はじめに:\r\n"
        + "　このソフトは粉末X線回折実験における2次元デバイリングパターンを一次元化するプログラムです。おもな特徴は"
        + "\r\n ・Rigaku R-Axis, Brucker CCD, Fuji Bas シリーズのデータを読み込み、表示"
        + "\r\n ・擬似カラー表示、マウスによる拡大縮小、サムネイル表示などのインターフェース"
        + "\r\n ・マルチスレッド使用による高精度かつ高速な一次元化"
        + "\r\n ・X線の波長、カメラ－試料距離、IPの傾きなどの各種パラーメタを半自動決定"
        + "\r\n ・ダイレクトスポット検出、バックグラウンド除去、回折スポットの検出･除去"
        + "\r\n ・拙作ソフト「PDIndexer」との連携"
        + "\r\nなどです。"
        ;

    /// <summary>
    /// 謝辞
    /// </summary>
    static public string Acknowledge =
        "謝辞:\r\n"
        + "　本ソフトは産業総合研究所 藤久裕司氏のPIPに触発されて開発しました。本ソフトのコーディング自体はオリジナルですが、"
        + "藤久氏のご厚意によりPIPのソースを参考にさせていただいており、PIPの設計思想や機能に大いに影響されております。"
        + "したがって本ソフトの真の作者は藤久氏であることを心に深く刻んで本ソフトをご使用ください。\r\n"
        + "　また、本ソフトのエラーの報告、改良の助言にあたっては北海道大学の浜根様、永井様、京都大学の三宅様、IFREEの佐多様を"
        + "中心に多くの方の協力を頂いております。この場を借りて御礼申し上げます。"
        ;

    /// <summary>
    /// 使い方
    /// </summary>
    static public string Manual =
        "使い方:\r\n"
        + "　このソフトは「IPAnalyzer」を実行することで起動します。画像データはファイルメニューから読み込むことができます。"
        + "「Get Profile」ボタンを押すとリングパターンを一次元化します。拙作ソフト「PDIndexer」を起動していると、クリップボード"
        + "経由で自動転送されます。"
        + "より詳しい使い方は下記ホームページをご覧ください。"
        ;

    /// <summary>
    /// 著作権
    /// </summary>
    static public string CopyRight =
        "著作権:\r\n "
        + "　本プログラムの著作権は、作者である瀬戸雄介、"
        + "およびその所属機関である神戸大学理学研究科地球惑星科学専攻が保有しています。"
        ;

    /// <summary>
    /// 使用条件
    /// </summary>
    static public string Condition =
        "使用条件:\r\n " +
        "本プログラムは学術目的で作成されたフリーソフトウェアです。" +
        "\r\n  ・商用/非商用を問わず、誰でもご自由にお使いいただけます。" +
        "\r\n  ・ただし、軍事目的あるいは違法な目的での使用は固く禁じます。" +
        "\r\n  ・如何なる商用目的の販売、あるいは有償のサポートを行いません。"
         ;

    /// <summary>
    /// 免責事項
    /// </summary>
    static public string Exemption =
        "免責:"
        + "\r\n　作者は本プログラムの"
        + "\r\n　 ・動作保証を致しません。"
        + "\r\n　 ・使用によって直接的あるいは間接的に生じた障害、損害についての責任を負いません。"
        + "\r\n　 ・修正、及びバージョンアップの義務を負いません。"
        ;

    /// <summary>
    /// 連絡先
    /// </summary>
    static public string Adress =
        "連絡先:\r\n"
        + "　プログラムの不具合、改善要望などがありましたらメールにてご連絡ください。"
        + "また詳しい使い方についてはホームページでも解説しています。"
        + "\r\n mail: seto@crystal.kobe-u.ac.jp"
        + "\r\n Home Page: http://pmsl.planet.sci.kobe-u.ac.jp/~seto/"
        + "\r\nできるだけご要望にお応えしたいと思います。"
        ;


    static public string[] Hint = new string[]{
           "'Manual Spot'では左クリックでスポット選択、右クリックでスポット消去ができます。スポットのサイズはマウスホイールで変更できます",
           "マウス中クリックすると、クリック点付近を2次元PseudoVoigtフィッティングし、中心点を検索することができます。",
           "GetProfileするとClipboard経由でPDIndexerに自動的に積算プロファイルが転送されます。",
           "表示画像の輝度反転、スケール変更は「View]オプションから変更できます。"
        };
}
