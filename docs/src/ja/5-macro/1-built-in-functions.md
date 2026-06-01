<!-- 260601Cl 追加: Wiki の List-of-macro-functions を移行。記述は現行コード (Macro.cs の [Help] 属性, ver3.977) を正本として再生成。 -->

# 組み込み関数

`IPA` ルートオブジェクト配下の名前空間ごとに、マクロから呼べるメソッド・プロパティの一覧を示します。説明はマクロエディタ内のヘルプ（`[Help]` 属性）に基づきます。最新の正本はエディタ内ヘルプです。

## IPA.File

| メンバー | 説明 |
|------|------|
| `GetDirectoryPath(filename="")` | ディレクトリのフルパスを返します。`filename` を省略するとフォルダ選択ダイアログが開きます。 |
| `GetFileName(message="")` | ファイル選択ダイアログを開き、選択したファイルのフルパスを返します。 |
| `GetFileNames(message="")` | 複数選択ダイアログを開き、選択したファイルのフルパスを文字列配列で返します。 |
| `GetAllFileNames(message="")` | フォルダを選択し、その中（サブフォルダ含む）の全ファイルのフルパスを配列で返します。 |
| `ReadImage(filename="", flag=None)` | 画像ファイルを読み込みます。省略すると選択ダイアログが開きます。 |
| `ReadImageHDF(filename, flag)` | HDF5 画像を読み込みます。`flag` で正規化の有無を切り替えます。 |
| `SaveImage(filename="")` | 現在の画像を保存します（旧 API のエイリアス。既定は TIFF）。 |
| `SaveImageAsTIFF(filename="")` | 画像を TIFF 形式で保存します。 |
| `SaveImageAsPNG(filename="")` | 画像を PNG 形式で保存します。 |
| `SaveImageAsIPA(filename="")` | 画像を IPA 形式で保存します。 |
| `SaveImageAsCSV(filename="")` | 画像を CSV 形式で保存します。 |
| `ReadParameter(filename="")` | パラメータファイルを読み込みます。 |
| `SaveParameter(filename="")` | 現在のパラメータを保存します。 |
| `ReadMask(filename="")` | マスクファイルを読み込みます。 |
| `SaveMask(filename="")` | 現在のマスクを保存します。 |

いずれの保存・読込メソッドも、ファイル名を省略・無効にすると選択ダイアログが開きます。

## IPA.Wave

| メンバー | 説明 |
|------|------|
| `SetWaveLength(wavelength)` | 入射波の波長を設定します（単位 nm）。 |
| `WaveLength` | 波長を設定／取得します（単位 nm）。 |
| `WaveSource` | 線源を整数で設定／取得します。0: なし, 1: X 線, 2: 電子線, 3: 中性子線。 |
| `XrayLine` | X 線の波長線を整数で設定します（設定専用）。0: Kα, 1: Kα1, 2: Kα2。 |

## IPA.Detector

| メンバー | 説明 |
|------|------|
| `SetCenter(x, y)` | 中心（ダイレクトスポット）位置を設定します（単位 pixel）。 |
| `SetCameraLength(length)` | カメラ長を設定します（単位 mm）。 |
| `CenterX` | 中心の X 座標を設定／取得します（単位 pixel）。 |
| `CenterY` | 中心の Y 座標を設定／取得します（単位 pixel）。 |
| `CameraLength` | カメラ長を設定／取得します（単位 mm）。 |
| `PixelSizeX` | 画素の X 方向サイズ（幅）を設定／取得します（単位 mm）。 |
| `PixelSizeY` | 画素の Y 方向サイズ（高さ）を設定／取得します（単位 mm）。 |
| `PixelKsi` | 画素の歪み ξ を設定／取得します（単位 °）。 |
| `TiltPhi` | 検出器の傾き φ を設定／取得します（単位 °）。 |
| `TiltTau` | 検出器の傾き τ を設定／取得します（単位 °）。 |

## IPA.Image

| メンバー | 説明 |
|------|------|
| `NegativeGradient` | ネガティブ階調で表示するかを True/False で設定／取得します（`PositiveGradient` と対）。 |
| `PositiveGradient` | ポジティブ階調で表示するかを True/False で設定／取得します（`NegativeGradient` と対）。 |
| `LinearScale` | リニアスケール表示にするかを True/False で設定／取得します（`LogScale` と対）。 |
| `LogScale` | 対数スケール表示にするかを True/False で設定／取得します（`LinearScale` と対）。 |
| `GrayScale` | グレースケール表示にするかを True/False で設定／取得します（`ColorScale` と対）。 |
| `ColorScale` | カラースケール表示にするかを True/False で設定／取得します（`GrayScale` と対）。 |
| `Maximum` | 表示輝度の最大値を実数で設定／取得します。 |
| `Minimum` | 表示輝度の最小値を実数で設定／取得します。 |
| `CanvasMagnification` | 画像の表示倍率を実数で設定／取得します。 |
| `SetCanvasCenter(x, y)` | キャンバスの中心位置を pixel 単位で設定します。 |
| `SetCanvasSize(width, height)` | 表示領域（ピクチャボックス）のサイズを pixel 単位で設定します。 |
| `SetArea(top, bottom, left, right)` | 表示領域を上下左右の境界（pixel 単位）で設定します。 |
| `SetFullArea()` | 画像全体が収まるように表示領域を設定します。 |

## IPA.Mask

| メンバー | 説明 |
|------|------|
| `MaskSpots()` | スポットをマスクします（「スポット除外」ボタンと同じ動作）。 |
| `ClearMask()` | 現在のマスクをすべて消去します。 |
| `InvertMask()` | 現在のマスク領域を反転します。 |
| `MaskAll()` | 全領域をマスクします。 |
| `MaskTop()` | 上半分をマスクします。 |
| `MaskBottom()` | 下半分をマスクします。 |
| `MaskLeft()` | 左半分をマスクします。 |
| `MaskRight()` | 右半分をマスクします。 |
| `TakeOver` | マスクの引き継ぎ設定を整数で設定／取得します。0: なし, 1: 現在のマスク状態を引き継ぐ, 2: マスクファイルを引き継ぐ。 |

## IPA.Profile

| メンバー | 説明 |
|------|------|
| `ConcentricIntegration` | 同心円（2θ–強度）積算モードにするかを True/False で設定／取得します。 |
| `RadialIntegration` | 偏角（ピザ切り）積算モードにするかを True/False で設定／取得します。 |
| `AzimuthalDivision` | 方位角分割モードで処理するかを True/False で設定／取得します。 |
| `AzimuthalDivisionNumber` | デバイ環を分割する数を整数で設定します。 |
| `FindCenterBeforeGetProfile` | Get Profile の前に Find Center を実行するかを True/False で設定／取得します。 |
| `MaskSpotsBeforeGetProfile` | Get Profile の前に Mask Spots を実行するかを True/False で設定／取得します。 |
| `SendProfileViaClipboard` | プロファイルをクリップボード経由で PDIndexer に送るかを True/False で設定／取得します。 |
| `SaveProfileAfterGetProfile` | Get Profile 後にプロファイルを保存するかを True/False で設定／取得します。 |
| `SaveProfileAsPDI` | PDI 形式で保存するかを True/False で設定／取得します。 |
| `SaveProfileAsCSV` | CSV 形式で保存するかを True/False で設定／取得します。 |
| `SaveProfileAsTSV` | TSV 形式で保存するかを True/False で設定／取得します。 |
| `SaveProfileAsGSAS` | GSAS 形式で保存するかを True/False で設定／取得します。 |
| `SaveProfileInOneFile` | シーケンシャル／方位角分割のプロファイルを 1 ファイルにまとめて保存するかを True/False で設定／取得します。 |
| `SaveProfileAtImageDirectory` | 画像と同じディレクトリに保存するかを True/False で設定／取得します。 |
| `GetProfile(filename="")` | 一次元化を実行します。`filename` を指定するとそのファイルに保存します。 |

## IPA.IntegralProperty

| メンバー | 説明 |
|------|------|
| `ConcentricIntegration` | 同心円（2θ–強度）積算モードにするかを True/False で設定／取得します。 |
| `RadialIntegration` | 偏角（ピザ切り／ケーキ）積算モードにするかを True/False で設定／取得します。 |
| `ConcentricStart` | 同心円積算の開始値を実数で設定／取得します。 |
| `ConcentricEnd` | 同心円積算の終了値を実数で設定／取得します。 |
| `ConcentricStep` | 同心円積算のステップを実数で設定／取得します。 |
| `ConcentricUnit` | 同心円積算の単位を整数で設定／取得します。0: 角度 (°), 1: d 値 (Å), 2: 距離 (mm)。 |
| `RadialRadius` | 偏角積算の対象半径（ドーナツ半径）を実数で設定／取得します。 |
| `RadialWidgh` | 偏角積算の対象幅（ドーナツ幅）を実数で設定／取得します。※現バージョンではメンバー名が `RadialWidgh` と綴られています。 |
| `RadialStep` | 偏角積算の方位角ステップ（扇形角）を実数で設定／取得します。 |
| `RadialUnit` | 偏角積算の単位を整数で設定／取得します。0: 角度 (°), 1: d 値 (Å)。 |

## IPA.Sequential

| メンバー | 説明 |
|------|------|
| `SequentialImageMode` | 現在のファイルがシーケンシャル画像かを True/False で取得します。 |
| `Count` | 含まれる画像枚数を整数で取得します。 |
| `SelectedIndex` | 選択中の画像番号（0 始まり）を整数で設定／取得します。 |
| `SelectedIndices` | 選択中の画像番号を整数配列で設定／取得します（複数選択モード用）。 |
| `MultiSelection` | 複数選択モードの有効／無効を True/False で設定／取得します。 |
| `Averaging` | 平均モードの有効／無効を True/False で設定／取得します。 |
| `SelectIndex(index)` | 単一の画像を選択します（複数選択モードは解除されます）。 |
| `AppendIndex(index)` | 現在の選択に画像を 1 枚追加します。 |
| `SelectIndices(start, end)` | start〜end（両端含む）の連続範囲を選択します。 |
| `AppendIndices(start, end)` | start〜end（両端含む）の連続範囲を現在の選択に追加します。 |
| `Target_SelectedImages` | 選択画像を Get Profile の対象にするかを True/False で設定／取得します。 |
| `Target_AllImages` | 全画像を Get Profile の対象にするかを True/False で設定／取得します。 |
| `Target_TopmostImage` | 最前面の画像のみを Get Profile の対象にするかを True/False で設定／取得します。 |

## IPA.PDI

| メンバー | 説明 |
|------|------|
| `Debug` | PDIndexer 側マクロをステップ実行するかを True/False で設定／取得します。 |
| `Timeout` | マクロ操作のタイムアウト秒数を設定／取得します（既定 30 秒）。 |
| `RunMacro(obj1, obj2, ...)` | PDIndexer 側でマクロコードを実行します。引数は PDI 側で `Obj[1]`, `Obj[2]`, … として読めます。 |
| `RunMacroName(name, obj1, obj2, ...)` | PDIndexer 側の名前付きマクロ `name` を実行します。引数は PDI 側で `Obj[1]`, `Obj[2]`, … として読めます。 |
