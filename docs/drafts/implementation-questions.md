本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 実装上の疑問点（コードは変更していない）

コードを読んで見つけた「誤りの疑い」と「意図の確認が必要な点」。実行による確認はしていない。行番号は概数（IPAnalyzer `0392606`、Crystallography `7a435ee`）。重要度は Claude の判断: **A** = 解析結果を黙って変えうる、**B** = 失敗・例外・データ欠落、**C** = 軽微・表示。

## A. 解析結果に影響しうるもの

| # | 箇所 | 内容と根拠 |
|---|---|---|
| A1 | `FormMain.GetProfile`（3532 行付近）、`DiffractionProfile2.RemoveKalpha2` | **Kα2 除去が既定オン**（`checkBoxTest.Checked = true`、レジストリ保存なし）で、X 線 Kα1 選択時に**横軸の種類を問わず**適用される。`RemoveKalpha2` は X を 2θ[°] とみなして $2\theta' = 2\arcsin(\lambda_1\sin\theta/\lambda_2)$ を計算するので、d-spacing（X = d [Å]）や Radial（X = χ）、方位角分割（2θ なので可）で d・χ に対して誤った引き算をする。また開始角未満の参照には $\tfrac23 I_0$ を使う。 |
| A2 | `FormMain.toolStripSplitButtonFindCenter_ButtonClick`（リング基準、3260 行付近） | セクター $\alpha$ の点を $(L\tan2\theta\sin\alpha,\ -L\tan2\theta\cos\alpha)$（= 画面上で上から時計回り）に置いているが、セクターのマスクは `Ring.SetInsideArea` で Miscellaneous の χ 定義（既定 **Right**・Clockwise、$\operatorname{atan2}(y,x)$ 基準）に従う。既定設定では点が 90° 回転し、楕円中心の補正方向も 90° 回る（反復しても収束しない可能性）。χ 定義が Top・Clockwise のときだけ整合する。要実機確認。 |
| A3 | `Ring.SetTiltParameter`、`FindSpotsThread0` ほか全座標変換 | 画素歪みは $x = \Delta i\,p_x + \Delta j\,p_y\tan\xi$。旧資料・付録 a1 は $\sin\xi$。定義の問題（どちらが正しいかではなく、マニュアルと揃える必要）。 |
| A4 | `Ring.GetConcenrticProfile` | 規格化がモードで異なる: Angle/d は「立体角あたり」（gnomonic 接平面の面積で重み、$\Omega_0=p_xp_y/L^2$ 単位）、Length と Gandolfi は「画素あたり」、Radial は和。同じ画像でもモードで強度の 2θ 依存が変わる。意図の確認。 |
| A5 | `Ring.SetInsideArea`（Radial・d 分岐） vs `Ring.GetRadialProfile` | Radial の d-spacing モードで、マスクは $d_c \pm \Delta d/2$、多角形の切り取りは $d_c \pm \Delta d$。角度モードは両方 $\pm\Delta$（半幅）。d モードでは実効幅が半分。 |
| A6 | `Ring.GetRadialProfile`（反時計回りの反転） | Counterclockwise で `Pt[i].X` と `Pt[length-1-i].X` を入れ替えているが、ビン $i$ の中心は $i\Delta\chi$ なので正しい反転角は $(N-i)\Delta\chi$。実装は $(N-1-i)\Delta\chi$ で 1 ビンずれる。 |
| A7 | `FormProperty.buttonSetBackgroundImage` / `FormMain.FlipRotate_Pollalization_Background` | 背景は `Ring.IntensityOriginal`（反転・回転前）で登録し、反転・回転後の配列から引く。反転・回転を使うと位置が合わない（W≠H の 90° 回転では長さ一致でも別画素）。 |
| A8 | `FormMain.cs` 2107 行・2249 行付近（シーケンシャル画像の TIFF/CSV 保存） | `Ring.CorrectPolarization(toolStripComboBoxRotate.SelectedIndex, …)` で、偏光方向の引数に**回転コンボの番号**を渡している。通常経路は χ 基準方向から 0/1 を決める。χ 基準 Top/Bottom、または回転 90°/270° のとき保存画像の偏光補正が表示と異なる。 |
| A9 | `FormMain.GetProfile`、`FormSequentialImage.SelectedIndices` | フレームごとの波長更新（一括 Get Profile、平均・合計）が `ImageType == HDF5` のときだけ。HDF5 は読めない（B1）ので、エネルギー付きマルチページ TIFF でも全フレームが同じ波長で積分される。 |
| A10 | 球面補正（`Ring.cs` 各所） | 新モデル（弧長写像、`GetProfileThreadWithTiltCorrectionNew`）と旧モデル（$L/(L-r^2\rho^{-1}/2)$、Length モード・Find Parameter）が併存。FindSpots・積分範囲マスク・偏光・Radial・IPA 保存には入らない。Find Parameter が推定した $\rho^{-1}$ は旧モデルで定義される。Find Parameter 画面の単位表示は `/mm`、コードは m⁻¹。 |
| A11 | `IntegralProperty.IsBraggBrentanoMode` | 設定されるが参照なし。Output pattern は無効。ツールチップは効果があるように書いている。 |
| A12 | `ImageIO.BAS2000or2500` | Fuji BAS を $10^{L\cdot QL/2^B}-1$ で変換（PSL ではない。感度・画素サイズ未使用、$2^B$ と $2^B-1$ の違い）。相対強度には影響しないが、絶対値・誤差（$I/\sqrt S$）の意味が変わる。 |
| A13 | `Ring.GetConcenrticProfile`（誤差） | $\sigma = I_k/\sqrt{S_k}$ は $S_k$ をカウントとみなす。PSL 換算・背景減算・偏光補正後は不正確。 |

### 幾何的較正（`FormFindParameter`）

| # | 箇所 | 内容と根拠 |
|---|---|---|
| A14 | `SetTiltCorrection`（1650–1671 行） | リング半径は全リングで追加し、楕円中心は 8 点以上のリングだけ追加する。リングの採用条件は 5 方向以上なので、5〜7 方向のリングがあると半径と中心の対応がずれる。 |
| A15 | 同 1678 行 | Secondary の傾き推定にも Primary のカメラ長 `FilmDistance[0]` を渡している（Δ = 100 mm なら 2θ と $R_i$ の尺度が違う）。 |
| A16 | 同 1681 行・1771 行 | 中心の mm → pix 変換が $p_x = B_x/p_x - B_y\tan\xi/p_y$。正しくは $(B_x - B_y\tan\xi)/p_x$。$p_x = p_y$ でなければずれる。 |
| A17 | `GetResidual`（1811 行） | 残差 $=\sqrt{\sum\Delta^2}/n$。RMS でも二乗和でもない（表示名は "The mean relative residual" / 「残差二乗和」）。 |
| A18 | `FindParameter.cs`（45, 135, 174, 213 行） | λ・$\rho^{-1}$ の誤差が $\mathrm{SD}/(2N)^{1/4}$（4 乗根）。この誤差を Primary/Secondary 合成の重みに使う。 |
| A19 | `FindSphericalCorrection` | 旧モデルを線形化した正しい増分は $2L(L_1-pL_2)/\{L_1(L_2-L_1)(L_2+L_1)\}$ だが、実装は $L(L_1-pL_2)/\{L_1L_2(L_2-L_1)\}$。固定点は同じで収束速度だけ違う。 |
| A20 | 1 枚モード | 波長・カメラ長・画素サイズを同時に精密化すると、画素の絶対スケールとカメラ長が分離できない（既定で全部オン）。 |
| A21 | `Geometry.GetPixelShape` | 2 次曲線の 1 次項（中心のずれ）を無視して 2 次の係数を規格化するため、中心がずれていると $O((x_0^2+y_0^2)/R^2)$ の偏り。 |
| A22 | セクターの方位（`CollectEllipses`） | 点の方位は $2\pi j/N$ 固定だが、セクターのマスクはメイン画面の χ 定義に従う。χ 定義を既定以外にすると点の方位がずれる（A2 と同種）。 |

### 総当たり較正（`FormFindParameterBruteForce`）

| # | 箇所 | 内容と根拠 |
|---|---|---|
| A23 | `evaluatePeakHeightAndTwoTheta`（630 行付近） | $H_i\le 0$ が一つでもあると $\sum H=\infty$ とされ $W/\sum H = 0$、つまり失敗したピークが評価値を**最良にする**。フィット失敗の反射は両方の和から除かれるので、ピークを失うほど $\sum(\Delta2\theta)^2$ が小さくなる。 |
| A24 | `Fitting`（252 行付近） | 平面検出器で全反射の XCalc を $2\arcsin(\lambda/2d)$ で上書きするため、Kα2 の反射が Kα1 の位置になる。 |
| A25 | `InitializeCrystalPlane`（166–170 行） | 前向き `for` 内の `RemoveAt(i)` で次の反射を飛ばす。 |
| A26 | Gandolfi の評価値 | $\sum(I_i/I_{i+1}-2)^2$ を掛ける（コメントは 0.5 を目標）。強度比が合えば位置に関係なく 0 になる。 |

## B. 失敗・例外・データ欠落

| # | 箇所 | 内容 |
|---|---|---|
| B1 | `ImageIO.HDF5` | 常に `false`。`.h5` はフィルタ・`IsReadable` に残る。 |
| B2 | `FormMain.SaveProfile` | GSAS + In one file + 複数プロファイルで何も書かない（PDI 分岐と `!GSAS` 分岐しかない）。 |
| B3 | `FormMain.SaveProfile`（3743 行） | CSV/TSV（別ファイル）が `X,Y,Y` と Y を 2 回書き、カルチャ依存の小数点（de/fr では小数点がカンマ）。 |
| B4 | `Profile.ToGSAS` | `EndsWith(".")` の置換が X・σ の列も Y の文字列で置き換えうる。`y[..10]` が短い文字列で例外。11 文字切り詰めで指数部が欠ける。d モードでも `HorizontalAxis.Angle` 固定。 |
| B5 | `FormMain.saveImageAsTiff`（2109–2122 行） | `SequentialImageEnergy.Count` を条件に `SequentialImagePulsePower[i]` を参照（パルスタグ無しで範囲外例外）。タグ 60000/60001 は書かない。 |
| B6 | `.mas`（2733, 2784 行） | $\lfloor N/8\rfloor$ バイトしか読み書きせず、末尾 $N \bmod 8$ 画素のマスクが失われる。 |
| B7 | `IPA.PDI.RunMacro`（`Macro.cs`） | `RunMacro("", obj)` が自分自身を呼ぶ無限再帰（StackOverflow）。`RunMacroName` の誤りと思われる。 |
| B8 | `ImageIO.RintRapid2Unroll` | `Ring.ImageType` を設定しない（直前の画像種別のパラメータを引き継ぐ）。`RigakuPXD` は種別 SMV、`Gel` は MCCD として記憶。 |
| B9 | `ImageIO.SMV` / `RigakuPXD` / `ADSC` | `BYTE_ORDER` を無視（ADSC は常にリトルエンディアン）。 |
| B10 | `ImageIO.Raxis4` | カメラ長だけリトルエンディアンで読む（他はビッグエンディアン）。値は使われない。 |
| B11 | `ImageIO.ReadImage` | `.img` と `mar` の判定が大文字小文字を区別（`.IMG` は失敗）。`.inf` があり BAS でなければ他の判定に進まず失敗。 |
| B12 | `ImageIO.DM` | int16/uint16/double/byte のデータを黙って拒否。 |
| B13 | `ImageIO.NXS` | try/catch 無し、3 次元を仮定。 |
| B14 | `MRC.cs` | MODE 0 を `byte − 128` で読む（MRC2014 の MODE 0 は符号付き int8）。 |
| B15 | `ImageIO.Brucker` | ヘッダ長を 7680 バイト固定、オーバーフロー表を無視。 |
| B16 | `FormMain.SaveProfile` 既定ファイル名 | 画像名オプションが「最後のフォルダ名 + ファイル名」「フルパス」のとき `FilePath + FileName` が二重になる。Ctrl+矢印のファイル送りも同様。 |
| B17 | `FormMain.SaveParameter`（2342 行） | `fullySave = false` を強制（マクロの `SaveParameter` でもダイアログが出る）。読込では球面補正を `TiltCorrectionChecked` で判定、保存は `SphericalCorrectionChecked`。 |
| B18 | `DiffractionOptics.Read` | 読み込むたびに旧タグ名を書き換えてユーザーの `.prm` を上書き保存する。 |
| B19 | `FormFindParameter.SetCenterPosition`（1763 行） | 全リングが 8 点未満だと空リストの `Average` で例外（BackgroundWorker 内）。 |
| B20 | `toolStripMenuItemReferenceBackground`（2949 行） | `tabControl.SelectedIndex = 9`（タブは 0〜8）。 |

## C. 軽微・表示

| # | 箇所 | 内容 |
|---|---|---|
| C1 | `FormProperty.ja.resx` | Donut radius/width の日本語ラベルが逆、Spot の左右が逆、After Get Profile の label27 にスプラインの説明文。 |
| C2 | `FormFindParameter.ja.resx` | 結果欄 label60/79/80 の φ・τ・メイン/サブの食い違い。英語の綴り誤り多数（00-audit §3）。 |
| C3 | `FormFindParameter` の「Get Wave Length」（3018 行） | `textBoxPixelSizeY.Text = textBoxRefinedPixelSizeX.Text`（Y に X を代入）。 |
| C4 | `FormFindParameter` の Secondary マーカーのドラッグ | `FilmDistance[1]` を変えるが Δ は変えないので、次のイベントで $L_1+\Delta$ に戻る。 |
| C5 | `FormFindParameterBruteForce` の単位表示 | τ/φ のツールチップは rad、値は度。Gandolfi の報告は "Tilt(rad)" と表示して度の値。 |
| C6 | `Ring.GetRadialProfile` | 自身で `SetTiltParameter` を呼ばず、直前の呼び出し（通常は `SetInsideArea`）の値に依存。 |
| C7 | `Ring.GetConcenrticProfilesBySector` / `GetUnrolledImageArray` | χ 定義を反映しない（コメント「未実装」）。 |
| C8 | Option → ToolTip、Ngen Compile、Intensity table、Background、Find center based on the ring、Unrolled の単位ラジオ、`FormCalibrateRAxisImage`、`FormAboutMe` | 機能しない UI・到達不能なフォーム。 |
| C9 | `Wave.XrayLine`（マクロ）の setter | UI スレッドへの委譲（`Execute`）が無い。 |
| C10 | `FormMain` Ctrl+→（3993 行） | 条件が `SelectedIndex < MaximumNumber`（`-1` が抜けている。setter 側で防いでいる）。 |
