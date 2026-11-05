本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 対応ファイル形式（実装準拠）

対象コード: `Crystallography/Images/ImageIO.cs`（`ImageIO.ReadImage` が振り分け）、`Tiff.cs`、`DigitalMicrograph.cs`、`IO/HDF.cs`、`IO/MRC.cs`、`IO/PdiFile.cs`、`Diffraction/DiffractionOptics.cs`、`Profile.cs`（いずれも submodule `7a435ee`）、`IPAnalyzer/FormMain.cs`、`IPAnalyzer/FormSaveImage.cs`、`IPAnalyzer/FormSequentialImage.cs`。

## 1. 入力画像

### 1.1 振り分けの順序

`ImageIO.ReadImage(path, flag)` は次の順に判定し、最初に一致した読み込み関数を使う。`.img` は 9 種類があり、**付随ファイル → ヘッダ文字列**の順で判別する。

| 順 | 条件 | 読み込み関数 | 形式 |
|---|---|---|---|
| 1 | `*img` かつ同名 `.inf` あり | `BAS2000or2500` | Fuji BAS2000/2500（`.inf` 1 行目に `BAS_IMAGE_FILE` が無ければ読み込み失敗） |
| 2 | `*img` かつ同名 `.tem` あり | `FujiFDL` | Fuji FDL |
| 3 | `*img` かつ先頭 `R-AXIS` または `ipdsc\0` | `Raxis4` | Rigaku R-AXIS IV/V |
| 4 | `*img` かつ先頭 `{\nHEADER_BYTES=17408;\nBYTE_ORDER=little_endian` | `RintRapid2Unroll` | Rigaku RINT-RAPID II 展開像 |
| 5 | `*img` かつ先頭 `{\nHEADER_BYTES=  512;\nCOMMENT=Written by adxv;` | `ADXV` | PILATUS の cbf を ADXV で変換した img |
| 6 | `*img` かつ先頭 5 行に `Rigaku 2D-PXD Image Header Format` | `RigakuPXD` | Rigaku 2D-PXD / d*TREK 拡張 |
| 7 | `*img` かつ先頭 `IM` | `ITEX` | 浜松ホトニクス ITEX |
| 8 | `*img` かつ先頭 `{\nHEADER_BYTES= ` | `ADSC` | ADSC |
| 9 | `*img` かつ TIFF 署名 | `Tiff` | TIFF |
| 10–11 | `.stl` / `.osc` | `Raxis4` | R-AXIS IV / IV 揺動 |
| 12 | 拡張子が `0` で始まり TIFF 署名 | `RayonixSX200` | Rayonix SX（`.0001` など） |
| 13 | `.ccd` | `Brucker` | Bruker CCD（SMART/APEX v86） |
| 14 | `.gel` | `Gel` | GE / Molecular Dynamics gel（Typhoon/FLA） |
| 15 | `.ipf` | `Ipf` | IP Display（8000×4000 固定） |
| 16 | 拡張子が `mar` で始まる | `MAR` | Marresearch mar345 等（CCP4 packed） |
| 17 | `.mccd` | `Mccd` | Mar/Rayonix CCD |
| 18 | `.his` | `ITEX` または `HIS` | 先頭 `IM` なら ITEX、それ以外は Perkin Elmer XRD |
| 19 | `.ipa`（`ClipBoard.ipa` 以外） | `IPA` | IPAnalyzer 独自形式 |
| 20 | `.bmp` / `.jpg` / `.png` | `GeneralImage` | 一般画像（RGB 平均の 8 bit グレーに変換） |
| 21 | `.tif` / `.tiff` | `Tiff` | TIFF（マルチページ可） |
| 22 | `.h5` | `HDF5` | **常に失敗**（本体がコメントアウトされ `return false`） |
| 23 | `.dm3` / `.dm4` | `DM` | Gatan DigitalMicrograph |
| 24 | `.raw` | `RadIcon` | Rad-icon（ファイルサイズで判定）または KEK-PF BL18C 形式（ヘッダで判定） |
| 25 | `.smv` | `SMV` | SMV（コメント上は Dexela） |
| 26 | `.mrc` | `MRC` | MRC2014（FEI/TFS TEM カメラ） |
| 27 | `.nxs` | `NXS` | NeXus（X-Spectrum LAMBDA） |

注: `.img` と `mar` の判定は大文字小文字を区別する（`EndsWith("img")`、`StartsWith("mar")`）。

### 1.2 画素値の扱い（主なもの）

| 形式 | 画素値 | 実装上の注意 |
|---|---|---|
| Fuji BAS2000/2500 | ビッグエンディアン 16 bit（bits ≤ 8 なら 8 bit）の QL を表で変換: $I = 10^{\,L\cdot \mathrm{QL}/2^B} - 1$（上限 $10^L-1$）。$L$: latitude、$B$: bit 数（`.inf`） | **PSL 換算ではない**。感度・画素サイズは読むが使わない（→実装上の疑問点） |
| Fuji FDL | ビッグエンディアン 16 bit の値をそのまま | 対数変換しない |
| R-AXIS | ビッグエンディアン uint16。$>$ 0x7fff は $(v\,\&\,0\mathrm{x}7\mathrm{fff})\times \mathrm{hilo}$（hilo: ヘッダ 800 byte 目の float） | 読み込み後に上下反転。ヘッダの波長・カメラ長・画素サイズは読むが使わない |
| Rad-icon（`.raw`） | ビッグエンディアン **符号付き** int16 | 画像サイズはファイルサイズから: 688×2064, 2048×2048, 2064×1548, 2064×2236, 2080×2238, 3096×3100, 1300×4608, 2940×4608, 5888×4608。非正方形は縦横を連続性で推定（`CalcWrapAndVertAvg`） |
| TIFF | 非圧縮 8/16/32 bit 整数（符号あり・なし）・32 bit 浮動小数。RGB は赤チャネルのみ | 同じサイズ・形式の IFD が続く限りマルチフレーム。拡張子 tif で最小値 ≤ 0 のとき負の画素を自動でマスク（`FormMain.ReadImage`） |
| DM3/DM4 | float / uint32 / int32 / 複素 FFT（振幅） | int16・uint16・double・byte は読み込み失敗 |
| MRC | MODE 0,1,2,6 | 先頭セクションのみ |
| NeXus | `/entry/instrument/detector/data`（[n,h,w]） | n>1 でマルチフレーム |

### 1.3 ヘッダの幾何情報

ヘッダの値が光学系パラメータに入るのは次の 2 形式だけ:

- **IPA**: カメラ長、解像度（→ PixSizeX = PixSizeY）、中心、波長。さらに φ = τ = ξ = 0 にする（`FormMain.ReadImage`）。
- **DM3/DM4**: 線源を電子線にし、加速電圧・画素サイズ・カメラ長（$L = s/\tan(\lambda\cdot\mathrm{scale})$ の形で換算）を、現在値と 20 % 以上違うときだけ置き換える。

それ以外の形式は、**画像の種類（`Ring.ImageTypeEnum`）ごとに前回使ったパラメータ一式**（検出器形状、Gandolfi 半径、カメラ長、画素サイズ・ξ、φ・τ、線源、反転・回転、中心）を復元する（`FormProperty.SetParameterFromImageType`。保存は `SaveParameterForEachImageType`、レジストリに永続化）。Rigaku 2D-PXD は SMV と、gel は MCCD と同じ種別として記憶される。RINT-RAPID II は種別を設定しない（直前の画像の種別を引き継ぐ）。

### 1.4 マルチフレーム（シーケンシャル）

複数フレームになるのは TIFF（マルチページ）、NeXus（n>1）、SMV（SIZE3）、Perkin Elmer HIS、連結 ITEX、KEK-PF raw。2 フレーム以上でシーケンシャルモードになる（`FormMain.ReadImage`）。

- TIFF の独自タグ 60000（X 線エネルギー eV）、60001（名前）、60002（パルス強度）を読む。60002 があると「パルス強度で規格化するか」を尋ね、はいなら $I/P/10000$。
- 1 フレームを選んだときだけ、そのフレームのエネルギーから波長を更新する（$\lambda[\mathrm{nm}] = 1239.84/E[\mathrm{eV}]$、`UniversalConstants.Convert.EnergyToXrayWaveLength`）。平均・合計、および全フレーム／選択フレームの一括 Get Profile でのフレームごとの波長更新は、画像種別が HDF5 のときだけ行う分岐になっており、現状は実行されない。
- 平均・合計（Sequential Image ウィンドウ）: 画素ごとに $\sum I / n$（平均）または $\sum I$（合計）。

### 1.5 開く方法

- メニュー File → Read image のダイアログフィルタ（`ImageIO.FilterString`）: `*.img;*.stl;*.ccd;*.ipf;*.ipa;*.0???;*.gel;*.osc;*.mar*;*.mccd;*.his;*.h5;*.dm?;*.raw;*.bmp;*.jpg;*.tif;*.tiff;*.png;*.smv;*.mrc;*.nxs`。
- ドラッグ＆ドロップ（`FormMain_DragDrop`）: **1 つだけ**落としたときに有効。画像 → 読み込み、`.prm` → パラメータ読み込み（Ctrl を押しながらだと読み込む項目の選択ダイアログ）、`.mas` → マスク読み込み、フォルダ → その中の先頭ファイル。
- コマンドライン引数: `img|stl|ccd|ipf`、`prm`、`mas` のみ。
- Ctrl+←/→: シーケンシャルモードではフレーム送り、それ以外では同じフォルダの前後のファイルを開く。

## 2. 出力

### 2.1 画像の保存（File → Save image）

| 形式 | 内容 | 実装 |
|---|---|---|
| TIFF | 現在の `Ring.Intensity`（反転・回転・背景・偏光補正**後**）。整数値だけなら最大値に応じて 8/16/32 bit 符号なし、小数があれば 32 bit float。負値は 0。シーケンシャルは全フレームを同じ補正をかけてマルチページで保存 | `FormMain.saveImageAsTiff`、`Tiff.Writer` |
| PNG | 表示どおり（コントラスト、カラースケール、マスク表示を含む）。Unroll 表示中は 2θ・χ の目盛を付ける | `FormMain.saveImageAsPng` |
| CSV | 画素値を行ごとにカンマ区切り（UTF-8 BOM 付き） | `FormMain.saveImageAsCSV` |
| IPA | 傾き・画素歪みを除いた正方画素画像（下記） | `FormSaveImage.SaveImageAsIPA` |

**IPA 保存**（Save Image ウィンドウ: Width/Height 既定 1000、Resolution 既定 100 µm、Center 既定 500）: 元画素の四隅を傾き補正と中心投影で $Z=L$ 面へ写し、出力画素の正方形との重なり面積比で強度を配分する（`Ring.GetCorrectedImageArray`。保存則を満たす多角形リビニングで、補間はしない）。マスク・球面補正・Gandolfi は考慮しない。ファイルは `IPAImage` の XML シリアライズで、強度（double 配列）、幅・高さ、中心、解像度 [mm/pix]、波長情報、カメラ長を含む。

### 2.2 パラメータファイル（`.prm`）

`DiffractionOptics.Parameter` の XML（値は UI 上の文字列）。項目: 検出器形状、Foot モード、ダイレクトスポット・Foot 位置、Camera Length 1/2、線源・波長・元素・線、画素サイズ X/Y・ξ、φ・τ、球面補正、Gandolfi 半径、積分領域（Rectangle/Sector の各値）、積分モード（Concentric/Radial の単位・範囲）。保存時は毎回「保存する項目」ダイアログ（`FormParameterOption`）が出る。読み込み時は旧形式のタグ名を新形式に**書き換えてファイルを上書き保存**してから読む（`DiffractionOptics.Read`）。

### 2.3 マスクファイル（`.mas`）

リトルエンディアン Int32 の画素数 $N$ と、$\lfloor N/8\rfloor$ バイトのビット列（LSB が先）。画素数が現在の画像と一致しないときは無視する。

### 2.4 プロファイル（After "Get Profile" タブ）

| 形式 | 拡張子 | 内容 |
|---|---|---|
| PDI | `.pdi2` | `DiffractionProfile2[]` の XML（`XYFile.SavePdi2File`） |
| CSV / TSV | `.csv` / `.tsv` | 1 ファイルに 1 プロファイルなら 1 行 `X, Y, Y`（Y が 2 回）。複数プロファイルを 1 ファイルにまとめるときは 1 行目に名前、2 行目に `x, y`、以降 1 プロファイル 3 列（x, y, 空） |
| GSAS | `.gsa` | FXYE 形式。`BANK 1 n n CONST start×100 step×100 0 0 FXYE`、データは `X×100  Y  σ`（センチ度） |

保存先は「画像と同じフォルダ」または「毎回選択」、複数プロファイル（シーケンシャル・方位角分割）は「1 ファイルにまとめる / 別ファイル」を選べる。別ファイルの名前はシーケンシャルで `#フレーム名`、方位角分割で `-NNN`（中心角）と `-whole`。

### 2.5 PDIndexer への送信

`checkBoxSendProfileToPDIndexer`（既定オン）。名前付きミューテックス `PDIndexer` で PDIndexer の起動を確認し（500 ms、方位角分割では 5 s 待つ）、`DiffractionProfile2[]` を MemoryPack でシリアライズしてクリップボードへ置く。切り開き画像の同時送信も可。

## 要確認事項

1. HDF5（`.h5`）は廃止扱いでよいか。既存マニュアル・README の「HDF5 対応」の記述を消すか。フィルタからも外すか。
2. README・index の「Rad-Xcam」は、Rad-icon のどのサイズ（2940×4608 など）に当たるか。
3. BAS の変換式を「PSL に比例（定数倍と −1 のずれ）」と書いてよいか。PSL 換算にする予定はあるか。
4. R-AXIS・ADSC・Rigaku PXD などのヘッダの波長・カメラ長・ビーム中心を使わない（種別ごとの記憶値を使う）のは方針どおりか。
5. 一括 Get Profile でフレームごとの波長が更新されない（HDF5 専用分岐）ことをマニュアルにどう書くか。
6. CSV の Y 2 列出力は仕様か。
