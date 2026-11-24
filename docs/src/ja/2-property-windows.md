<!-- 260601Cl: 旧 doc と現行コード(FormProperty)の検証結果を基にプロパティウィンドウを再構成。タブUIは英語表示のため英語名を見出しに用い、日本語の補足を併記。260601Cl: 各タブの自動キャプチャ画像を組込。 -->
<!-- 261124Cl: 球面補正の単位、横軸の選択肢、Output pattern、円周方向積分・切り開きの入力値、GSAS の条件、バックグラウンド補正を実装に合わせて訂正。 -->

# プロパティウィンドウ

プロパティウィンドウでは、線源・検出器条件・一次元化の各種条件を設定します。各タブはメインウィンドウの **Property** メニューから直接開くこともできます。

日本語環境では各タブ・コントロールは日本語で表示されます。以下の見出しは英語のタブ名と日本語のタブ名を併記し、本文では各タブの設定項目を説明します。

## Wave source（線源の設定）

入射線の種類と波長を設定します。線源は X 線・電子線・中性子線から選べます。X 線では元素と遷移（K 線、L 線など）を選ぶと波長が自動入力され、放射光では波長を直接入力します。電子線・中性子線ではエネルギーまたは波長を入力します（電子線は相対論補正済み）。

- **Correct linear polarization**: 直線偏光の強度を無偏光相当へ補正します（放射光向け）。補正式は次のとおりで、方位角 χ と散乱角 2θ に依存します。χ の基準方向（［その他］タブで設定）が左右なら水平偏光、上下なら垂直偏光として扱います。

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition（検出器の設定）

検出器の幾何条件を設定します。旧マニュアルの "IP Condition" に相当し、座標系と検出器形状の選択が加わっています。

- **Coordinates（座標基準）**: **Direct spot**（ダイレクトスポット基準）／ **Foot**（垂線の足基準）。
- **Detector type（検出器形状）**: **Flat panel**（平面検出器）／ **Gandolfi**（ガンドルフィ）。
- **Direct spot position** と **Camera Length 1**: ダイレクトスポット位置 (X, Y pix) と、試料からダイレクトスポットまでの距離 (mm)。
- **Foot position** と **Camera Length 2**: Foot モードのときの垂線の足の位置と、試料から足までの距離。
- **Pixel Shape**: 画素サイズ X, Y (mm) と ξ（Ksi、平行四辺形の歪み角）。
- **Gandolfi Radius**: Gandolfi 形状選択時の半径。
- **Spherical correction**: 球面補正。湾曲した検出器の曲率半径 R の逆数 1/R（mm⁻¹）を入力します。平面検出器では 0 にします。
- **Tilt**: IP の傾き φ（Phi）・τ（Tau）。

傾き φ・τ・画素 ξ の定義は[概要](0-overview.md)を参照してください。

![Detector condition タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region（画像範囲の設定）

一次元化の対象とする画像領域を指定します。

- **Rectangle（矩形）**: **Direction** で方向（Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free）を選び、**Band Width**（帯幅）や **Angle**（Free 時の角度）、**Both Side** を設定します。
- **Sector（扇形）**: **Start Angle** / **End Angle** で角度範囲を指定します。
- **Exceptional pixels（積算除外ピクセル）**: **Masked Spots**（マスクしたスポット）、**Under intensity of** / **Over intensity of**（強度の下限・上限）、端から指定ピクセル数 (**pixels from edges**) を除外します。

![Integral Region タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property（１次元化の条件）

一次元化の方式と刻みを設定します。

- **Concentric integration（同心円積分・散乱角分散）**: 横軸の単位を **Angle**（2θ, °）／ **d-spacing**（Å）から選び、**Start / End / Step** を指定します。**Output pattern**（Bragg - Brentano / Debye - Scherrer）の選択は、現行版では結果に影響しません。
- **Radial integration (cake pattern)（円周方向積分）**: リング状の領域の強度を方位角ごとにまとめます。積分する環の中心 **Donut radius**（リング半径）と半幅 **Donut width**（リング幅）を散乱角 2θ（**Angle**）または面間隔 d（**d-spacing**）で指定し、**Sector angle step**（方位角の刻み）を設定します。得られるプロファイルの横軸は方位角 χ（°）です。

![Integral Property タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option（マスク条件）

マスクとスポット検出の条件を設定します（旧マニュアルの "Find Center & Spots" を拡張）。中心検出の条件は［その他］タブにあります。

- **Half mask**: 画像の上下左右半分を素早くマスクするボタン（Top / Bottom / Left / Right）。
- **Manual mask mode**: メイン画像上での対話的マスクを有効にします。形状は **Circle**（ドラッグで中心と半径）／ **Polygon**（クリックで頂点追加）／ **Rectangle**（対角ドラッグ）／ **Spline curve**（曲線）／ **Spot**（左右クリックでスポット追加・削除）。
- **Takeover（引き継ぎ）**: 画像読込時のマスクの扱い（**None** / **Take over the current mask state** / **Take over the mask file**）。
- **Find Spots** の **Deviation**: スポット検出の統計しきい値。

![Mask Option タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"（１次元化後の処理）

一次元化後の保存と送信を設定します。

- **Save File**: 保存先を「画像と同じディレクトリ」または「毎回選択」から選び、形式を **PDI** / **CSV** / **TSV** / **GSAS** から選びます。GSAS 形式で保存できるのは、同心円積分で横軸が 2θ の場合だけです。複数のプロファイルを 1 つのファイルにまとめる設定では GSAS 形式は保存されないので、個別のファイルに保存してください。
- **Send PDIndexer**: クリップボード経由で、起動中の PDIndexer へプロファイルを送信します。

![After "Get Profile" タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option（切り開き画像の設定）

切り開き（Unroll）展開画像のパラメータを設定します。

- **横方向**: **Start / End / Step** を散乱角 2θ（°）で指定します（単位の選択肢は表示されますが、現行版では常に 2θ として扱います）。出力画像の幅 ≈ (End − Start) / Step。
- **縦方向**: 方位角の**分割数** N を指定します。出力画像の高さは N 画素で、1 行あたりの角度幅は 360°/N です（既定の 720 なら 0.5°）。

切り開きは、ダイレクトスポットを中心とする極座標の回折像を、直交座標（角度・距離）の画像へ展開します。

![Unrolled Image Option タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous（その他）

表示や座標の細かな設定をまとめたタブです。

- **画像名の表示**: ファイル名のみ / 親フォルダ＋ファイル名 / フルパス。
- **画像描画範囲を維持**: 画像読込時に、拡大率と表示位置（描画範囲）を引き継ぐかどうか。
- **方位角 χ（Chi）の向き**: 基準位置（Top / Bottom / Left / Right）と回転方向（Clockwise / Counterclockwise）。χ は偏光補正や円周方向積分で参照されます。
- **目盛線**: 色・太さ・分割数・ラベル表示。
- **Find Center**: 探索範囲、ピークフィッティング範囲、中心固定、マスクピクセルの除外。

![Miscellaneous タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPage5.png)

## Background Option（バックグラウンドオプション）

バックグラウンド画像による補正を設定します。

- **バックグラウンド画像**: 現在表示している画像をバックグラウンドに設定（**Set the current image as background**）、または消去（**Clear**）します。
- **係数**: バックグラウンド画像に掛ける係数。

空気散乱など、加算的に重なった背景の減算に用います。各画素で \(I_\mathrm{out} = I - cB\)（\(B\): バックグラウンド画像、\(c\): 係数）を計算します。画像の端の画素を除外したい場合は、［画像範囲の設定］タブの **pixels from edges** を使います。

![Background Option タブ](../assets/cap-ja-auto/FormProperty.tabControl.tabPage3.png)
