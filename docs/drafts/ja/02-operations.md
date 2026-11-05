本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 主要機能の操作手順と設定項目（実装準拠）

UI 文字列は「英 / 日」。既定値は Designer の値（レジストリに保存される項目は 2 回目以降は前回値）。計算の詳細は [03-geometry.md](03-geometry.md)、[04-calibration.md](04-calibration.md)、[05-integration.md](05-integration.md)、形式は [06-file-formats.md](06-file-formats.md)。

## 1. 画像を読み込む

1. File → Read image / 画像を読込、またはウィンドウへ 1 ファイルをドラッグ＆ドロップ（フォルダを落とすと先頭のファイル）。Ctrl+←/→ で同じフォルダの前後のファイル。
2. 読み込むと、**その画像種別で前回使ったパラメータ一式**（検出器形状、中心、カメラ長、画素サイズ・ξ、φ・τ、Gandolfi 半径、線源、反転・回転）が自動で復元される（`FormProperty.SetParameterFromImageType`）。IPA 画像はヘッダの値を使い、DM3/DM4 はヘッダの値が 20 % 以上違うときだけ置き換える。種別を切り替えるとパラメータが「飛ぶ」のはこのため。
3. マスクは Mask Option の Take over mask setting / マスクの引継ぎ に従う: None / なし、Take over the current mask state / マスク状態を引き継ぐ（既定）、Take over the mask file / マスクファイルを引き継ぐ（同じ画素数のときのみ）。
4. 拡張子 tif の画像で最小値 ≤ 0 のとき、負の画素は自動でマスクされる。
5. 2 フレーム以上の画像ではシーケンシャルモードになり、右ツールバー Sequential image が有効になる（§8）。
6. Auto Procedure の「新しい画像が読み込まれたら以下の一連の操作を実行」がオンなら、手動で読み込んだときも自動処理が走る。

## 2. 表示を調整する

- Gradient / ポジ/ネガ、Brightness scale / 強度スケール（Log Scale / Liner Scale）、Color scale / グレー/カラー（Gray, Cold-Warm, Spectrum, Fire）、Scale line / 目盛（None〜Fine。色・太さ・ラベルは Miscellaneous の Scale line options / 目盛線のオプション）。
- Auto Contrast / 自動コントラスト = 全画素の平均 ∓ 2σ。Reset Contrast / リセット = 0–65535。強度頻度グラフ（下部タブ）の線をドラッグしても調整できる。
- 倍率ボタン ×1〜×1/16、ホイールで ×2 / ×0.5（カーソル位置中心）。左または中ボタンドラッグでパン、右ドラッグで矩形拡大、右クリックで縮小。
- 読み込み時の維持（Miscellaneous の Image loading options / 画像読み込みのオプション）: Maintain image contrast / 画像のコントラストを維持、Maintain display range / 画像描画範囲を維持（**ズーム・パン範囲**。強度範囲ではない）。いずれも既定オン。
- Option → Flip / Rotate は**計算に使う配列も変える**（ファイルは変更しない）。
- 画素の色: 赤 = 上限閾値超、青 = 下限閾値未満、水色 = マスク、緑 = Integral Region の外、マゼンタ = Integral Property の角度範囲外、黄 = 作成中の多角形・スプライン。中心は赤紫の ×。

## 3. 線源と検出器を設定する（Property タブ 0・1）

### Wave source / 線源の設定

- 線源（X 線・電子線・中性子線）、X 線は元素と線（Kα1 など）で波長を自動入力、または波長を直接入力（表示単位 Å、内部 nm）。
- **Correct linear polarization / 偏光補正を行う**（既定オフ）: 完全直線偏光を無偏光相当へ換算する。偏光方向は Miscellaneous の χ の基準方向で決まる（Right/Left → 水平、Top/Bottom → 垂直）。

### Detector condition / 検出器の設定

| 項目 | 意味・単位 | 既定 |
|---|---|---|
| Coordinates / 座標の基準: Direct spot / ダイレクトスポット、Foot / 垂線の足 | どちらの組（位置とカメラ長）を入力値とするか。もう一方は自動計算（$L_2 = L\cos\tau$ など）。Gandolfi では Foot 不可 | Direct spot |
| Detector type / 検出器のタイプ: Flat panel / フラットパネル、Gandolfi / ガンドルフィ | 平面または円筒（円筒軸は画像縦） | Flat panel |
| Direct spot position / ダイレクトスポット位置 X, Y | pix（画素中心が整数） | 1500, 1500 |
| Camera Length 1 / カメラ長1 | 試料からダイレクトスポットまで（mm）。計算はすべてこの値 | 445 |
| Foot position / 垂線の足の位置、Camera Length 2 / カメラ長2 | 試料から検出器面へ下ろした垂線の足とその長さ | — |
| Pixel Shape / ピクセル形状: X, Y, ξ | mm, mm, °。$x_d = \Delta i\,p_x + \Delta j\,p_y\tan\xi$ | 0.1, 0.1, 0 |
| Gandolfi Radius / Gandolfi 半径 | mm（Gandolfi 選択時のみ表示） | — |
| Spherical correction / 球面補正: Inverse of radius / 半径の逆数 | m⁻¹（内部で ÷1000）。通常 0 | 0 |
| Tilt / 検出器の傾き: φ, τ | °。φ は傾き軸の方位（画像右から時計回り）、τ はその軸まわりの回転 | 0, 0 |

## 4. 積分の範囲と条件を設定する（Property タブ 2・3）

### Integral Region / 画像範囲の設定

- Exceptional pixels / 積算除外ピクセル: Masked Spots / マスクされたピクセル（既定オン）、Over intenstiy of（原文ママ） / 強度が右値以上（65535）、Under intensity of / 強度が右値以下（1）、端から pixels from edges / ピクセル分の画像端（既定オン、5）。
- Rectangle / 矩形（既定）: Direction / 方向 = Full, Top, Bottom, Right, Left, Vertical, Horizontal, Free。Top=270°, Bottom=90°, Right=0°, Left=180°、Vertical/Horizontal は Both Side / 中心対称 付き。Free では Angle / 角度 を指定。Band Width / バンド幅 は帯の半幅（pix、既定 1500）。
- Sector / 扇形: Start Angle / 開始角度、End Angle / 終了角度（°、Miscellaneous の χ 定義に従う）。

### Integral Property / 1次元化の条件

- Concentric integration / 散乱角(2θ)積算（既定）: Angle / 角度（°）または d-spacing / d値（Å）。Start / 開始、End / 終了、Step / ステップ（既定 1°, 30°, 0.01°。d は 0.5, 5, 0.005 Å）。出力はビン中心 Start + kΔ。Length は UI で非表示。
- Output pattern / 光学系: Bragg - Brentano / Debye - Scherrer の選択は**現在計算に影響しない**（Debye - Scherrer は無効表示）。
- Radial integration (cake pattern) / 偏角 (sector angle) 積算: Donut radius（中心 2θ または d、既定 20°）、Donut width（**半幅**、既定 0.1°）、Sector angle step（方位ステップ、既定 0.05°）。日本語 UI ではラベル「リング幅」「リング半径」が英語と逆に付いている。

## 5. 中心を決め、マスクする

- **Find Center / 中心位置**（Ctrl+Shift+F）: 現在の中心のまわり ±Search area（Miscellaneous、既定 8 pix。保存されない）を 2 次元 pseudo-Voigt でフィット。Exclude masked pixels / マスク領域は除外 でマスク画素を除外。Draw Ring ウィンドウを開いて R を設定した状態で押すと、そのリングの 18 方向のピーク位置から楕円中心を求める（3 回反復、Peak fitting range (2θ) 既定 0.1°）。
- 中心を手で置く: 左ダブルクリック、または中クリック（中クリックは続けて Find Center も実行）。Ctrl+Shift+矢印で 1 画面画素ずつ移動。**Fix Center / 中心固定** 中はいずれも無効。
- **Mask Spots / スポット検出**（Ctrl+Shift+S）: 同心リング（幅 1 画素）ごとに平均 + k·SD を超える画素とその周囲半径 3 pix をマスクに追加。k = Mask spots option / スポット検出 の値（既定 5）。暗い画素は対象外。
- **手動マスク**（Manual Mode / マニュアルモード、Ctrl+Shift+M。形状は Mask Option タブ）:
  - Spot: 左クリック／ドラッグでマスク、右で解除（日本語 UI の「右/左クリック: 追加/削除」は逆）。形は Circle / Rectangle、寸法は半幅（2^n pix、既定 64。ホイールで変更）。
  - Circle: ドラッグで中心と半径。Rectangle: 対角をドラッグ。Polygon: クリックで頂点、ダブルクリックで確定（左 = マスク、右 = 解除）。Spline curve: 左で点追加、右で近い点を削除、ダブルクリックで確定（Line width 既定 5）。
- Mask Option の Mask All / 全てマスク、Unmask All / 解除、Invert mask / 反転、Half mask / 半分マスク（Left/Top/Bottom/Right。既存マスクに追加）。
- File → Save mask / Read mask で `.mas` に保存・読み込み。

## 6. 1 次元化する（Get Profile）

1. Get Profile / 1次元化（Ctrl+Shift+G）を押す。既定では直前に Find Center を 2 回実行する（Find Center before Get Profile、既定オン。Fix Center 中は実行しない）。
2. 結果は下部の Converted Profile / 変換プロファイル に表示。
3. After "Get Profile" / １次元化後の処理 タブ:
   - **Remove Kα2 (if Kα1 line is selected) / Kα2を除去**: **既定オン**（保存されず毎回オン）、Kα2/Kα1 = 0.5。X 線の Kα1 を選んでいると出力から Kα2 成分を差し引く。
   - Send profile data to PDIndexer through Clipboard / クリップボードを介してプロファイルをPDIndexerに送信（既定オン）、Send also Unrolled Image / 切り開き画像も一緒に送る。
   - Save Profiles / １次元化したプロファイルをファイルとして保存（既定オフ）: File format = PDI（`.pdi2`）/ CSV（既定）/ TSV / GSAS（`.gsa`）、Directory = At the same directory of the image / イメージファイルと同じ（既定）または At the chosen directory each time / 保存の度に指定、Saving option = In one file (Excluding GSAS) / 一つのファイルにまとめる または In separate files / 個別のファイルに保存（既定）。
4. **方位角分割解析**: Get Profile のドロップダウンで Azimuthal Division Analysis / 方位角分割解析 をオンにし、分割数（既定 60）を選んでから Get Profile。Integral Region が Rectangle/Full に切り替わり、全体（`-whole`）と分割数ぶんのプロファイル（`-000`, `-006`, … は方位ビン中心の角度）を作る。χ は画像右から時計回りに固定、横軸は 2θ のみ。
5. 円周方向（cake）: Integral Property で Radial integration を選んで Get Profile。出力は χ（Miscellaneous の χ 定義に従う）対強度の和。

## 7. 切り開き画像（Unroll）

右ツールバー Unroll image / 切り開き をオンにすると、Unrolled Image Option タブの Start/End/Step（**2θ の度**として解釈。単位ラジオボタンは無効）と縦の分割数（既定 720）で展開像を作り、画像の代わりに表示する。オフで元に戻る。File → Save image で TIFF（float）/PNG（目盛付き）/CSV に保存できる。

## 8. マルチフレーム（Sequential Image Option / シーケンシャル画像 オプション）

- リストまたはトラックバーでフレームを選ぶ（Ctrl+←/→ でも送れる）。TIFF タグ 60000 のエネルギーがあれば、1 フレームを選んだときに波長を更新。
- Multi selection / 複数選択 → Average / 平均 または Summation / 積算 で画素ごとの平均・合計を表示。
- Target(s) of "Get Profile" / 一次元化の対象: The selected image(s) / 選択した画像、Only the topmost image / 最初の画像のみ、All images irrespective of current selections / 全画像（Get Profile ドロップダウンの項目と連動）。

## 9. 較正

[04-calibration.md](04-calibration.md) を参照。手順の要点:

- **幾何的較正**（Find parameter (geometrically)）: Primary を Open → Get Profile → Peak List で 3 本以上チェック →（任意で Secondary を Open し カメラ長差 Δ を入力 → Get Profile）→ Refined Parameter / オプション で対象を選ぶ → Refine! / 実行!（既定 12 回で自動停止）→ Refined parameters => Main form / 校正パラメータをメインフォームに送信。
- **総当たり較正**（Find parameter (brute force)）: メイン画面に標準試料の画像を読み込み、中心をおおよそ合わせる → 標準試料（Au 既定）を選ぶ → Get Profile → 探索するパラメータと Initial step / Search range を設定 → Optimize / 最適化。最良値はサイクルごとにメイン画面へ書き込まれる。

## 10. 自動処理（Auto Procedure / 自動処理）

1. Directory to be monitored / 監視するディレクトリ を Set / 設定（サブフォルダも監視）。
2. 任意で Pattern matching / パターンマッチング（ファイル名末尾の数 $N$ について $N \bmod$ 除数 = / ≠ 余り。既定 3, 2）、キーワード（拡張子を除いたファイル名に含まれる部分文字列。大文字小文字を区別）。両方オンなら AND。
3. Automatically load new images / 新しい画像を自動で読み込む: 100 ms ごとに監視し、**フォルダ内のファイル数が変わったときだけ**新ファイルを検出する（上書きは検出しない）。書き込み完了（ロック解除・サイズ一定）を待って読み込む。
4. Once the new image is loaded, perform the following sequence / 新しい画像が読み込まれたら以下の一連の操作を実行: Auto contrast, Find center（2 回）, Mask spots, Get profile（既定でこれだけオン）, Execute macro（マクロを選ぶ）。Find Parameter ウィンドウ表示中は実行しない。

## 11. パラメータの保存・読み込み

File → Save parameter / Read parameter は毎回「Save/Read checked parameters」ダイアログで対象を選ぶ（Wave propety, Camera mode, Camera length, Center position, Pixel shape, Tilt correction, Spherical correction, Gandolfi Radius, Integral Region, Integral Property。既定でチェックは Camera mode と Gandolfi Radius だけ）。`.prm` をドラッグ＆ドロップするとすべての項目を読み込む（Ctrl を押しながらだとダイアログ）。

## 12. その他のツール

- **Draw Ring / リング描画**: R (mm)・2θ (°)・d (Å) のいずれかを入力して Enter/OK。$2\theta = \arctan(R/L)$、$d = \lambda/2\sin\theta$。リング付近を左ドラッグすると半径が追従。
- **Circumferential blur / 回転ぼかし**: 角度（0.01〜10°、既定 1°）を指定。メモリ上の強度を書き換える。
- **Save IPA Image / IPA画像の保存**: Width/Height（既定 1000、Keep Aspect Ratio で幅 = 高さ）、Resolution（µm/pixel、既定 100）、Center position（既定 500, 500）。表示中は出力範囲が画像上に描かれる。
- **R-AXIS画像の校正**（Tool メニュー）: 同じサイズの `.stl` 2 枚を開いて Calibrate / 校正。強度変換表を最適化してグラフに描くだけで、結果は適用・保存されない。
- **キー操作**: Ctrl+Shift+F（中心）、S（スポット）、G（1 次元化）、B（背景。ボタン無効のため実質なし）、M（手動マスク）、C（表示画像、統計タブでは選択範囲をクリップボードへ）。

## 要確認事項

1. Kα2 除去を既定オンのままにするか。マニュアルで強く注意喚起すべきか。
2. Band Width を「半幅（pix）」と書いてよいか（`Ring.SetInsideArea` の `wx = Band/sin` から判断）。
3. 総当たり較正で「中心をおおよそ合わせる」以外に推奨される前処理（Integral Region の設定など）はあるか。
4. Auto Procedure が上書きファイルを検出しない仕様でよいか。
5. Kα2 除去が d-spacing や Radial のプロファイルにも適用される点（実装上の疑問点）を直すまで、マニュアルにどう書くか。
