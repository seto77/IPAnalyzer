本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 2 次元像から 1 次元プロファイルへ：積分と補正（実装準拠）

対象コード: `Crystallography/Detector/Ring.cs`（submodule `7a435ee`）、`Crystallography/Profile.cs`、`IPAnalyzer/FormMain.cs`、`IPAnalyzer/FormProperty.cs`。
幾何の記号（$L, x_d, y_d, R, \mathbf r, 2\theta, \chi_\text{raw}$ など）は [03-geometry.md](03-geometry.md) に従う。
既存マニュアルの対応箇所: `docs/src/ja/0-overview.md`「ピクセル強度の積算方法」、`docs/src/ja/appendix/a3-image-integration.md`、`docs/src/ja/2-property-windows.md`。

## 1. 処理の順序

画像読み込み時、および反転・回転・背景・偏光の設定変更時に `FormMain.FlipRotate_Pollalization_Background` が `Ring.Intensity` を作り直す。積分はこの補正済み配列に対して行う。

1. 反転・回転: `Ring.FlipAndRotate(Ring.IntensityOriginal, …, flipV, flipH, rotate)`（Option メニューの Flip / Rotate。表示だけでなく**計算に使う配列自体が変わる**）。
2. 背景減算: `Ring.SubtractBackground` … $I \leftarrow I - c\,B$（$B$: Background Option で登録した画像、$c$: 係数 `numericBoxBackgroundCoeff`、既定 1）。$B$ の画素数が一致しないときは何もしない。
3. 偏光補正（Correct linear polarization がオンのとき）: `Ring.CorrectPolarization`（§6.1）。
4. 強度頻度の再計算: `Ring.CalcFreq`。

Get Profile（`FormMain.GetProfile`）の流れ:

1. `SetIntegralProperty` で UI 値を `IntegralProperty IP` に転記。
2. （ドロップダウンの「一次元化前に中心を検索」がオンで中心固定でなければ）`Find Center` を 2 回実行。
3. （「一次元化前にスポットを検出」がオンで Manual モードでなければ）`Mask Spots`。
4. `SetMask` → `Ring.SetMask`（§2）。
5. `Ring.GetProfile(IP)`（Concentric → `GetConcenrticProfile`、Radial → `GetRadialProfile`）。シーケンシャル画像では対象フレームごとに繰り返し、HDF5 ではフレームのエネルギーから波長を置き換える。
6. （Kα2 除去がオンなら）`DiffractionProfile2.RemoveKalpha2`（§6.3）。
7. 保存（After "Get Profile" タブ）・PDIndexer への送信。

## 2. 積分に使う画素（マスク）

`Ring.SetMask(OmitSpots, OmitThresholdMin, OmitThresholdMax)` で

$$
\text{IsValid} = \neg\big(\text{OutsideRegion} \lor \text{OutsideProperty} \lor (\text{OmitSpots}\land\text{Spots}) \lor (\text{OmitMin}\land I<n_\text{min}) \lor (\text{OmitMax}\land I>n_\text{max})\big)
$$

- OutsideRegion（`Ring.SetInsideArea`, calcRegion/calcEdge）: Integral Region の Rectangle（帯）／Sector（扇形）の外、および Edge 指定時は画像の各辺から Edge 画素。
- OutsideProperty（`Ring.SetInsideArea`, calcProperty）: 画素**中心**の 2θ が積分範囲外。Concentric では [Start, End]、Radial では [Radius − Range, Radius + Range]（Angle）。判定は $\cos^2 2\theta$ の比較で、中心投影を使わず $\mathbf r$ から直接計算。
- 閾値（`FormProperty.cs`）: Under は $I < n_\text{min}$、Over は $I > n_\text{max}$。

## 3. 同心円積分（Concentric）：Angle / d-spacing モード

実装: `Ring.GetConcenrticProfile` → `Ring.GetProfileThreadWithTiltCorrectionNew`（2020-04-30 以降の新実装）。

### 3.1 ビン

Angle モードでは $N = \lfloor(\text{End}-\text{Start})/\Delta\rfloor + 1$ 個のビンを作り、ビン $k$ の境界と出力横軸は

$$
\text{境界}:\ 2\theta^{\pm}_k = \text{Start} + (k\pm\tfrac12)\Delta,\qquad \text{出力}:\ 2\theta_k = \text{Start} + k\Delta
$$

（`R2[i] = (i + 0.5) * StepAngle + StartAngle` が上側境界）。d-spacing モードでは境界を $d^{\pm}_k = d_\text{Start} + (k\pm\tfrac12)\Delta d$ とし、$2\theta = 2\arcsin(\lambda/2d)$ で角度に直して同じ処理を行い、出力は $d_k = d_\text{Start} + k\Delta d$（Å）を d の昇順で並べる（2θ では降順）。

マスクは画素中心で判定する（§2）ので、先頭・末尾ビンは半分の範囲しか画素が入らない（平均値なので強度の偏りは小さいが、統計は悪い）。

### 3.2 画素の分割（面積分配）

各有効画素について:

1. 画素中心 $\mathbf r$ と、検出器面内の半画素ベクトル $\mathbf s_x = R(p_x/2, 0, 0)^{\mathsf T}$、$\mathbf s_y = R(p_y\tan\xi/2,\ p_y/2,\ 0)^{\mathsf T}$ から、2 つの頂点 $\mathbf r + (\mathbf s_x\pm\mathbf s_y)$ を作る（残り 2 頂点は画素中心に関する点対称として扱う）。球面補正がオンなら中心をまず §5（03-geometry）で写す（頂点の写像は中心と同じ平行移動のみ）。
2. 頂点を、**画素中心方向に垂直で試料から距離 $L$ の接平面へ中心投影（gnomonic 投影）**した局所 2 次元座標 $(u, v)$ に変換する。$u$ は子午面（$Z$ 軸と画素中心を含む面）内で 2θ が増す向き、$v$ は方位方向:
   $$
   u = L\tan\delta,\qquad v = \frac{(\mathbf a\cdot\hat{\mathbf e}_\chi)\,l\,L}{\mathbf a\cdot\mathbf r}
   $$
   （$\mathbf a$: 頂点、$\delta$: 子午面へ射影した頂点と画素中心のなす角、$\hat{\mathbf e}_\chi = (-Y, X, 0)/q$）。
3. 2θ ビン境界 $2\theta^+_k$ を、この局所座標で直線 $u = L\tan(2\theta^+_k - 2\theta)$ と近似し、画素の多角形を順に切り分けて各ビンの面積 $A_k$ を求める（多角形面積は `Ring.getArea`、靴紐公式）。方位分割（§7）のときはさらに $v = (q/l)\,L\tan(\chi_m - \chi)$ で切る。

この接平面上の面積は $A \approx L^2\,\Omega$（$\Omega$: その部分が試料から張る立体角）である。

### 3.3 強度の規格化

画素 $p$ の強度 $I_p$、全面積 $A_p$、ビン $k$ に入る部分面積 $A_{p,k}$ として

$$
S_k = \sum_p I_p\,\frac{A_{p,k}}{A_p},\qquad
W_k = \frac{1}{p_x p_y}\sum_p A_{p,k},\qquad
I_k = \frac{S_k}{W_k},\qquad
\sigma_k = \frac{I_k}{\sqrt{S_k}}
$$

（`profile[k] += area * intensityPerArea`、`pixels[k] += area`、最後に `pixels *= 1/(pixSizeX*pixSizeY)`、`GetConcenrticProfile` で `temp = ProfileIntensity / ContributedPixels`、`Err = temp / Sqrt(ProfileIntensity)`）。

$W_k$ は「ビンに寄与した立体角」を、傾きのない検出器のダイレクトスポット位置の 1 画素が張る立体角 $\Omega_0 = p_xp_y/L^2$ を単位に数えたものなので、$I_k$ は **単位立体角あたりの強度（$\Omega_0$ あたりに換算）** になる。すなわち、平面検出器の立体角・斜入射の幾何因子（傾きなしなら $\cos^3 2\theta$）は、この規格化で暗に補正されている。

- 旧実装（コメントアウト）は面積比で数えたうえで $\cos^3 2\theta$ で割る方式で、2016-12-27 に変更された旨のコメントがある（`GetConcenrticProfile`）。
- 誤差 $\sigma_k$ は $S_k$ をカウント数とみなした Poisson 誤差の相対値を $I_k$ に掛けたもの。$I_p$ が光子数でない（PSL 変換値、背景減算後、偏光補正後など）場合は意味を持たない。
- 検出器の吸収効率・センサー厚・空気吸収などの補正は無い。

## 4. 同心円積分：Length モード

実装: `Ring.GetConcenrticProfile` → `Ring.GetProfileThreadWithTiltCorrection`（旧実装）。現行 UI では Length のラジオボタン `radioButtonConcentricLength` が `Visible=False` で選べない（幾何的較正 Find Parameter が内部で使う）。

- 画素の四隅を中心投影面 $(X', Y')$ に写し（球面補正は 03-geometry §5(b)）、半径 $\sqrt{X'^2+Y'^2}$ の境界円 $R_k = \text{Start} + (k+\tfrac12)\Delta$ と四角形の辺の交点を解析的に求め、円弧を弦で近似した面積で配分する。
- 規格化は $I_k = \sum_p I_p A_{p,k}/A_p \big/ \sum_p A_{p,k}/A_p$、すなわち**画素数（面積比）あたりの平均**。立体角の規格化は入らない（Angle / d モードと規格化が異なる）。
- 横軸は投影面上の半径 [mm]（$= L\tan 2\theta$）。

## 5. Gandolfi モード

実装: `Ring.GetProfileGandlfi`（Angle モードのみ想定）。円筒上の画素頂点を実空間に写し、各画素の局所座標系で 2θ 一定の曲線と直線 $v = d$ の交点を 2 次方程式で求めて面積配分する。規格化は $\sum I A_{p,k}/A_p \big/ \sum A_{p,k}$（面積あたり）。ビン境界は $(i-\tfrac12)\Delta + \text{Start}$ で、出力は $\text{Start} + i\Delta$。

## 6. 補正

### 6.1 直線偏光補正（Correct linear polarization）

実装: `Ring.CorrectPolarization(rotate, intensity)`。中心投影座標 $(x, y) = (X', Y')$、$r^2 = x^2+y^2$ として、偏光方向が画像の横方向（`rotate` が 0 または 2）のとき

$$
I_\text{corr} = \frac{I}{c},\qquad c = \frac{2\,(y^2 + L^2)}{x^2 + y^2 + 2L^2}
= \frac{\sin^2\chi + \cos^2\chi\cos^2 2\theta}{\tfrac12(1+\cos^2 2\theta)}
$$

（$\chi$ は画像横軸から測った方位）。縦方向（`rotate` が 1 または 3）のときは $x \leftrightarrow y$。完全直線偏光（偏光度 1）を仮定し、無偏光相当へ換算する。既存 `2-property-windows.md` の式と数学的に一致する。

- `rotate` 引数の与え方が呼び出し元で異なる:
  - 通常の表示・積分経路（`FormMain.FlipRotate_Pollalization_Background`）: Miscellaneous の χ 基準が Right/Left なら 0（横偏光）、Top/Bottom なら 1（縦偏光）。
  - シーケンシャル画像の保存経路（`FormMain.cs` 2107 行・2249 行付近）: Option→Rotate のコンボ `toolStripComboBoxRotate.SelectedIndex`（回転角）を渡している。→「実装上の疑問点」。
- 既存マニュアルの「方位角 χ（Miscellaneous タブで定義）」は、χ の**基準方向**（偏光方向）だけが効き、回転方向は無関係、という意味に限定すべき。
- コメント「20190906追記 … / cos(2th)」の追加因子は実装されていない。
- 傾き φ, τ と ξ は中心投影を通じて反映される。球面補正は反映されない。

### 6.2 背景画像

§1 の 2.。Background Option / バックグラウンドオプション タブ（tab 8。Property メニューには項目が無い）の「Set the current image as background / 現在の画像をバックグラウンドに設定」は、`Ring.IntensityOriginal`（**反転・回転前の生データ**）の複製を $B$ として登録する。一方、減算は反転・回転**後**の配列に対して行われる（→ 実装上の疑問点）。登録しただけでは再計算されず、次の再読込・係数変更・反転などで反映される。ツールバーの **Background / バックグラウンド補正** ボタンは resx で `Enabled=False`（常に無効）。ハンドラ `toolStripSplitButtonBackground_ButtonClick` も上限・下限の入力値を検査して再描画するだけで、計算には使われない。

### 6.3 Kα2 除去（Remove Kα2 / Kα2を除去）

UI: After "Get Profile" / １次元化後の処理 タブの「Remove Kα2 (if Kα1 line is selected) / Kα2を除去 (線源が Kα1 の場合)」（`FormProperty.checkBoxTest`）と比「Kα2/Kα1」（`numericBoxTest`、既定 0.5）。**Designer の既定でオン**、レジストリ保存対象外（`FormMain.cs` の `rw(...)` 一覧に無い）なので起動のたびにオンに戻る。X 線源の元素番号 > 10 かつ線が Kα1 のとき、Get Profile 後に `DiffractionProfile2.RemoveKalpha2` を適用:

$$
I_1(2\theta_i) = I(2\theta_i) - \rho_{21}\,I_1(2\theta'_i),\qquad
2\theta'_i = 2\arcsin\!\Big(\frac{\lambda_1}{\lambda_2}\sin\theta_i\Big)
$$

（Rachinger 型。$I_1$ は既に補正済みの値を線形補間（`GetValue(theta, 2, 1)`）で参照する逐次法。$2\theta'_i$ がプロファイル開始角より小さい場合は $\tfrac23 I(2\theta_0)\,\rho_{21}$ を引く）。横軸を 2θ[°] と仮定しているが、**呼び出し側（`FormMain.GetProfile`）は Concentric/Radial・Angle/d/Length を区別せずに適用する**→「実装上の疑問点」。

### 6.4 立体角・斜入射

独立した補正項目は無い。Angle / d モードの規格化（§3.3）が立体角あたりの強度を与えることで実質的に含まれる。Length・Gandolfi・Radial モードには入らない。

### 6.5 出力パターン（Bragg - Brentano / Debye - Scherrer）

UI のラジオボタン（ツールチップは「出力 1 次元パターンに Bragg-Brentano の強度規約を適用」）の値は `IP.IsBraggBrentanoMode` に転記されるが、**どの計算からも参照されていない**（`grep IsBraggBrentanoMode` で代入箇所のみ）。現状、選択は結果に影響しない。

## 7. 方位角分割解析（Azimuthal Division Analysis）

Get Profile のドロップダウン `toolStripMenuItemAzimuthalDivisionAnalysis` をオンにすると（`FormMain.GetProfile` の LPO モード分岐）:

1. Integral Region を Rectangle・Full に強制し、全体のプロファイル（名前末尾 ` -whole`）を作る。
2. 分割数 $M$（`toolStripComboBoxAzimuthalDivisionNumber`）で `Ring.GetConcenrticProfilesBySector(IP, M)` を呼ぶ。方位ビン $m$ の範囲は $\chi_\text{raw}\in[(2m-1)\pi/M,\ (2m+1)\pi/M]$（中心 $2\pi m/M$）で、画素は §3.2 の手順で 2θ と χ の両方で切り分ける。名前末尾は ` -{m·360/M:000}`（中心角、度）。
3. χ は $\chi_\text{raw}$（画像右が 0、画面上時計回り）に固定。Miscellaneous の χ 定義は反映されない。
4. 横軸は常に 2θ（Angle）。d・Length モードの設定は無視される（`GetConcenrticProfilesBySector` が `StartAngle/EndAngle/StepAngle` だけを使う）。

## 8. 円周方向積分（Radial integration, cake）

実装: `Ring.GetRadialProfile`。

- 半径範囲は投影面上で $[L\tan(2\theta_c - \Delta),\ L\tan(2\theta_c + \Delta)]$（Angle；$\Delta$ は Donut width = 半幅）、d-spacing では $d_c \pm \Delta d$ を角度に換算。
- 方位ステップ $\Delta\chi$（Sector angle step）でビン数 $\mathrm{round}(360/\Delta\chi)$。ビン $m$ は $[(m-\tfrac12)\Delta\chi, (m+\tfrac12)\Delta\chi]$。
- 画素の四隅を中心投影面に写し、放射状の 2 直線と、ビン中心方向に垂直な 2 直線（$\pm$ 半径。円弧を直線で近似）で切り取った面積比で配分。
- 強度は**和**（$\sum_p I_p A_{p,m}/A_p$）で、寄与面積による規格化をしない。Concentric と単位が異なる。
- 出力横軸に χ 定義（Miscellaneous）を適用: Counterclockwise のとき配列を反転し、基準方向に応じて −90/−180/−270° シフトして [0, 360) に折り返す。

## 9. 切り開き画像（Unroll）

実装: `FormMain.toolStripSplitButtonUnroll_CheckChanged` → `Ring.GetUnrolledImageArray(IP, chiDivision, start, end, step)`。横軸は 2θ（Unrolled Image Option の Start/End/Step を**度として**読む）、縦軸は $\chi_\text{raw}$ を `numericUpDownUnrollChiDivision`（既定 720。画像の高さ）等分。横軸の単位ラジオボタン（Length/Angle/d-spacing）はコードから読まれない。各セルは §3.2〜3.3 と同じ切り分けで、値は $S/W$（立体角あたり平均）。After "Get Profile" の「切り開き画像を PDIndexer に送る」（`checkBoxSendUnrolledImageToPDIndexer`）がオンのときは $\chi$ 360 分割で同じ計算を行い、プロファイルに添付する。

## 10. 画像処理系のアルゴリズム

### 10.1 Find Center（中心位置）

`Ring.FindCenter(IP, radius, mask)`: 現在の中心のまわり $(2r+1)^2$ 画素（$r$ = Search area、既定 8 pix）を切り出し、強度を総和で規格化して、2 次元 pseudo-Voigt

$$
F = \frac{2A}{\pi H}\Big[\frac{\eta}{1+4s} + (1-\eta)\sqrt{\pi\ln 2}\,e^{-4\ln 2\,s}\Big] + B_1 + B_2(X-x) + B_3(Y-y),\quad
s = \frac{(X-x)^2 + C(Y-y)^2}{H^2}
$$

を 9 パラメータの Levenberg–Marquardt（最大 300 反復、$\lambda<10^9$）で当てはめ、$(X, Y)$ を新しい中心とする（`FittingPeak.FitPeakAsPseudoVoigtByMarcal2D`, `Crystallography/PeakSearch.cs`）。「Exclude masked pixels」がオンならマスク画素を NaN として除外。中心が画像端から $r+2$ 画素以内なら何もしない。

**リングからの中心検出**（Draw Ring ウィンドウ表示中に Find Center）: `FormMain.toolStripSplitButtonFindCenter_ButtonClick` の後半。Draw Ring の 2θ を中心に ±5×(Peak fitting range) の Concentric Angle 積分を、Sector 20° 刻み 18 方向で行い、各方向で pseudo-Voigt を当ててピーク 2θ を得る。点 $\big(L\tan 2\theta\,\sin\alpha,\ -L\tan 2\theta\,\cos\alpha\big)$（$\alpha$ = セクター中心角）に 2 次曲線 $ax^2+bxy+cy^2+dx+ey=10^6$ を最小二乗で当てはめ（`Geometry.GetEllipseCenter`、8 点未満なら中止）、楕円中心だけ中心を移動する。これを 3 回繰り返す。

### 10.2 Mask Spots（スポット除外）

`Ring.FindSpots(IP, k)`: 中心投影面上の半径を $p_x$ 単位で四捨五入したリング番号 $r_n$ で画素を分類し、各リングで（既存スポット・領域外を除いた画素の）平均 $\bar I$ と不偏標準偏差 $s$ を求め、$I > \bar I + k s$ の画素とその周囲 $\Delta i^2+\Delta j^2 < 9$ の画素を Spots に追加する（既存のスポットは消さない）。$k$ = Deviation（`numericUpDownFindSpotsDeviation`、既定 5）。下側（暗い画素）は判定しない。

### 10.3 Circumferential Blur（回転ぼかし）

`Ring.CircumferentialBlur(θ)`: 正方形画素・傾きなしを仮定し、画素中心からの距離 $r$ と方位 $\phi$（画素単位、中心 = 現在のダイレクトスポット）を使い、近傍画素に重み $\exp\{-(\Delta\phi/\theta)^2 - (\Delta r)^2/0.25\}$（$|\Delta r|<1.5$、$|\Delta\phi|<3\theta$、距離 $< r\sin3\theta$）を付けた正規化平均で置き換える。`Ring.Intensity` を上書きする（元に戻すには再読込または反転・回転などの再計算が必要と思われる。要確認）。

## 要確認事項

1. Angle/d モードの「立体角あたり」規格化と、Length/Gandolfi/Radial の「画素あたり／和」の違いは意図どおりか。マニュアルにどう書くか。
2. 先頭・末尾ビンが画素中心マスクで半分しか埋まらない仕様でよいか。
3. 誤差 $\sigma_k = I_k/\sqrt{S_k}$ の前提（カウント数）を明記してよいか。
4. Kα2 除去の既定オン・非永続は意図どおりか。
5. Bragg-Brentano / Debye-Scherrer の切替を将来実装する予定か、UI から外すか。
6. 背景画像を反転・回転前の配列で登録し、反転・回転後の配列から引く仕様でよいか（反転・回転が既定 0 なら問題は出ない）。
7. Circumferential Blur 後の元画像への戻し方。
8. 方位角分割・Unroll の χ 定義非対応はマニュアルで「χ は画像右から時計回り固定」と書けばよいか。
