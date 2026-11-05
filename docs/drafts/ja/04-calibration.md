本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 標準試料による検出器パラメータの較正（実装準拠）

対象コード: `IPAnalyzer/FindParameter/FormFindParameter.cs`（幾何的較正。英 "Find Parameter"、日「パラメータ校正 (代数的)」）、`IPAnalyzer/FindParameter/FormFindParameterBruteForce.cs`（総当たり。英 "Find Parameters (brute force)"、日「パラメータ探索 (総当たり)」）、`Crystallography/FindParameter.cs`、`Crystallography/Mathematics/Geometry.cs`（`GetEllipseCenter`, `GetTiltAndOffset`, `GetPixelShape`）、`Crystallography/PeakSearch.cs`（`FittingPeak.FitMultiPeaksThread`）、`Crystallography/Detector/Ring.cs`（`SetFindTiltParameter`, `GetProfileForFindTiltCorrection`）。行番号は `FormFindParameter.cs` の概数。
既存マニュアルの対応箇所: `docs/src/ja/appendix/a2-calibration.md`、`4-procedures.md`、`6-find-parameter.md`、`3-tools.md`。

単位: 長さ mm、λ は内部 nm（UI は Å）、角度は UI 度・内部 rad。`Mathematics/Marquardt.cs` はどちらのフォームからも使われていない（ピークフィットは `FitMultiPeaksThread` 内の独自 LM）。

---

## 1. 幾何的較正（Find Parameter / パラメータ校正 (代数的)）

### 1.1 全体構造

幾何モデル全体を一度に最小二乗するのではなく、**現在のパラメータで画像からリング上の点を抽出 → 一部のパラメータを閉じた式または 1〜2 次元の格子探索で更新**、を決まった順序で決まった回数（Repetition、既定 12）繰り返す交互反復である（`RefineParameters`, L1990–2266）。収束判定は無い。

### 1.2 入力と準備

- 初期値（カメラ長、画素サイズ X/Y、ξ、λ、φ、τ、中心）は表示時にメイン画面から取り込む（L93–153）。標準結晶の既定は CeO₂（$a = 0.5411102$ nm）。Set crystal / 設定 で変更可。
- **Primary image**: Open → Get Profile / 一次元化 で、メイン画面を Concentric・Length に切り替え、全方位の 1 次元プロファイル（横軸 = 中心投影面上の半径 mm、ステップ $0.25\,p_x$、開始 1 mm）を作り、全反射をフィットする（`buttonPrimaryGetProfile_Click`, L1247）。
- **Secondary image**（任意）: カメラ長を $\Delta$（`textBoxFilmDistanceDiscrepancy`、既定 100 mm、負も可）だけ変えた同じ試料の像。$L_2 = L_1 + \Delta$ とし、$\Delta$ は精密化しない。Secondary は独自の中心と φ・τ を持つ。
- Peak List で使う反射をチェックする。「以下の条件を満たすピークをチェック」は、観測位置 < lower than（既定 150 mm）かつ隣接反射から away from（既定 1 mm）以上離れた反射を自動でチェック（`buttonCheckPeaks_Click`）。
- 実行条件: 各画像で 3 本以上のチェックと共通 hkl が 1 本以上（満たさないと**何もせず戻る**。カメラ長だけを精密化する場合を除く）。抽出後、5 方向以上で有効なリングが 2 本未満なら中止。
- プロファイル図上で計算リングのマーカーを左ドラッグすると、$L = x/\tan(2\arcsin(\lambda/2d))$ で Primary のカメラ長を更新する。

### 1.3 リング上の点の抽出（`CollectEllipses`, L1451–1568）

1. 方位を $N$ 分割（Division / 分割数、既定 18、8〜360）。方向 $j$ に方位 $\alpha_j = 2\pi j/N$ を割り当てる。
2. 領域: **Sector / セクター**（既定、$[(j-\tfrac12), (j+\tfrac12)]\cdot 360°/N$）または **Rectangle / 矩形**（角度 $j\cdot360°/N$ の半直線の帯。幅 = Band width % × 画像幅、既定 4 %）。メイン画面の Integral Region を書き換えて設定する。
3. `Ring.SetFindTiltParameter`: チェックした反射の予測半径 $p_i = L\tan(2\arcsin(\lambda/2d_i))$ の $\pm 2\,\mathrm{SR}$ の帯以外をマスク（SR = Fitting Range、既定 0.8 mm）。
4. `Ring.GetProfileForFindTiltCorrection`: 中心投影面上の半径について面積分配した 1 次元プロファイル（値 = $10\sum IA/\sum A$）。球面補正は 03-geometry §5(b) の近似式。
5. 各反射をフィット（§1.4）し、点 $(L_\text{obs}\cos\alpha_j,\ L_\text{obs}\sin\alpha_j)$ をそのリングに加える。

正しいパラメータでは、各リングは中心投影面上で原点中心・半径 $L\tan 2\theta$ の円になる。

### 1.4 ピークフィット（`Fitting` + `FittingPeak.FitMultiPeaksThread`）

- モデル: 面積規格化 pseudo-Voigt（$H$ = FWHM）＋共通の 1 次背景
  $$
  f(x) = I\,\frac{2}{H}\Big[\frac{\eta}{\pi(1+u)} + (1-\eta)\sqrt{\tfrac{\ln 2}{\pi}}\,e^{-u\ln 2}\Big] + B_1 + B_2(x-x_c),\qquad u = \frac{4(x-X)^2}{H^2}
  $$
  （`PeakSearch.cs` L178）。$\eta\in[0,1]$。
- 窓: 半幅 $\mathrm{SR}/\cos\theta_B$（Secondary はさらに $L_2/L_1$ 倍）。初期位置は計算位置（ピーク探索はしない）。初期 FWHM は、既に採用したピークの $(X, H)$ に全最小二乗直線を当てた値。
- Peak Decomposition / ピーク分離（既定オフ）: 計算位置の差が $2\,\mathrm{SR}$ 未満の反射を同時フィット。
- LM: データを 1/1000 に縮め、$\lambda_\text{LM}$ 初期 10、採用で ×0.5、棄却で ×4、$\lambda_\text{LM}\ge10^9$ か 500 反復、または 50 反復後に相対減少 $<10^{-10}$ で終了。初期値 11 組を試す。
- 棄却: $|X_\text{fit} - X_\text{calc}| > 1.0$ mm（固定値）、S/N（Threshold / ピーク閾値 > 0 のときのみ。既定 0 で無効）。

### 1.5 各パラメータの推定式

| 対象 | 方法 | 実装 |
|---|---|---|
| λ（1 枚） | 2 線法。リング対 $(i,k)$ と方向ごとに $Y = L_k/L_i$, $X = d_i/d_k$, $s = \sin^2\theta_i$ として $Y^2 = X^2(1-X^2s)(1-2s)^2/\{(1-2X^2s)^2(1-s)\}$ を解く。解法は $s\in[0.1, 4]\,(\lambda_\text{cur}/2d_i)^2$ の 1000 分割格子探索を 25 回（窓 ±2.5 ステップ、ステップ ×0.32）。$\lambda = 2d_i\sqrt s$ を重み $1/(\sigma_i^2+\sigma_k^2)$（$\sigma$ は位置を 0.1 mm ずらしたときの λ の変化）で平均。カメラ長・画素の絶対スケールに依存しない | `FindParameter.GetSinTheta`, `FindWaveLengthFromMultiPeaks` |
| λ（2 枚、画素サイズを精密化しない） | 各リングで $\lambda = 2d\sin(\tfrac12\arctan(\bar r/L))$ | `FindWaveLengthFromFixedPixelSize` |
| λ・$\rho^{-1}$ の 2 枚合成 | $w_k = N_{\text{ring},k}/\sigma_k^2$ の重み付き平均 | L1863–1899, L1614–1635 |
| カメラ長（1 枚） | 全点で $L = L_\text{obs}/\tan(2\arcsin(\lambda/2d))$ の単純平均 | `FindFilmDistanceFromWaveLength` |
| カメラ長（2 枚、2 距離法） | 同じ hkl・同じ方向で $L_1 = \Delta\,r_1/(r_2 - r_1)$、重み $100/(\delta_1^2+\delta_2^2)$ | `FindFilmDistanceFromDiscrepancy`, `FindCameraLength` |
| 中心のみ（傾き・画素を精密化しないとき） | 各リングの楕円中心の平均だけ中心を移動（1 回あたり ±1 pix に制限） | `SetCenterPosition` |
| 傾き + 中心 | 下記 §1.6 | `SetTiltCorrection` → `Geometry.GetTiltAndOffset` |
| 球面 $\rho^{-1}$ | リング対・方向ごとに $p = \tan 2\theta_i/\tan 2\theta_k$（現在の λ）、$\Delta\rho^{-1} = L(L_i - pL_k)/\{L_iL_k(L_k - L_i)\}$ を加重平均して現在値に**加算** | `FindSphericalCorrection` |
| 画素サイズ・ξ | 各リングの 2 次曲線の 2 次の係数を $R_\text{calc}^2/10^6$ で規格化し、$x^2/A^2 - 2Bxy/(A^2C) + (A^2+B^2)y^2/(A^2C^2)$ に分解: $A = 1/\sqrt a$, $B = -b/\sqrt{a(4ac-b^2)}$, $C = 2\sqrt{a/(4ac-b^2)}$。新しい値 $p_x/A$, $p_y/C$, $\xi = \arctan\{(C/A)(\tan\xi - B)\}$ をリングで平均（2 枚のときも Primary だけ） | `Geometry.GetPixelShape` |

### 1.6 傾きと中心（`Geometry.GetTiltAndOffset`）

1. 各リングに $ax^2+bxy+cy^2+dx+ey = 10^6$ を代数的最小二乗で当て（8 点以上）、中心 $\mathbf c_i$ を得る。半径 $R_i$ は $L_\text{obs}$ の平均。
2. 全リングの中心に主成分分析で直線 $x\sin\varphi_1 - y\cos\varphi_1 = A$ を当てる。
3. 直線上の位置 $B$ と残りの傾き $\tau_1$ について 2 次元格子探索で
   $$
   S = \sum_i 1000\,\big|\mathbf B + R_i(\tau_1)\,\mathbf u - \mathbf c_i\big|^2,\qquad
   R_i(\tau_1) = \frac{L\sin 2\theta_i}{2}\Big(\frac{1}{\cos(2\theta_i+\tau_1)} - \frac{1}{\cos(2\theta_i-\tau_1)}\Big),\quad 2\theta_i = \operatorname{atan2}(R_i, L)
   $$
   を最小化（$\mathbf u = (\cos\varphi_1, \sin\varphi_1)$。$B$ は −5〜+5 mm 刻み 0.1、$\tau_1$ は −1°〜+1° 刻み 0.02°、40 回、窓 ±2.4 ステップ、ステップ ×0.8。1 回の呼び出しで最大約 ±1.24°）。
4. 傾き軸 $\varphi_1$ = 直線方向 − 90°（$\tau_1$ の符号で象限を決め、$\tau_1 \leftarrow |\tau_1|$）。
5. 現在の傾きと合成: $Q = R(\varphi_1, \tau_1)\,R(\varphi, \tau)$、$R(\varphi,\tau) = R_z(\varphi)R_x(\tau)R_z(-\varphi)$。$\tau = \arccos Q_{33}$, $\varphi = \operatorname{atan2}(-Q_{31}, Q_{32})$ を初期値に、$\|Q - R(\varphi,\tau)\|_F^2$ を 2 次元格子探索で最小化（$Q$ は一般に $Z$ まわりのねじれを含むため、2 パラメータの族へ射影する）。
6. 誤差: リング対ごとの同じ手続きの解の標準偏差。
7. 中心: $\mathbf B$ [mm] を画素に換算し（1 回あたり ±1 pix に制限）、現在の中心に加える。

既存 a2 の「リングごとに τ を求めて加重平均」とは異なり、**全リング中心に対する同時最小二乗**であり、ビーム中心のずれも同時に求めている。

### 1.7 反復の順序

- 1 枚: 各反復で λ → カメラ長 → （中心のみ）→ 抽出 + 傾き → 抽出 + 球面 → 抽出 + 画素 → 抽出 + 残差。
- 2 枚: 初回は Primary だけで λ・カメラ長 → 2 枚で λ → 2 距離法でカメラ長 → Secondary と Primary の傾き → 球面 → 画素（Primary）→ 残差。2 回目以降はカメラ長（2 距離法）から始まる。
- 既定で精密化: 波長、カメラ長、傾き補正、ピクセルサイズ、ピクセル歪み、中心位置。球面補正はオフ。傾き補正をオンにすると中心位置は強制的にオン。

### 1.8 残差（グラフ「残差二乗和」/ "The mean relative residual"）

$$
\mathrm{Res} = \frac{\sqrt{\sum \Delta^2}}{n},\qquad \Delta = L_\text{obs} - L_\text{calc}\ \text{[mm]}
$$

（`GetResidual`, L1811。表示のみ）。RMS（$\sqrt{\sum\Delta^2/n}$）でも二乗和でもない（→ 実装上の疑問点）。

### 1.9 結果の反映

Refined parameters => Main form / 校正パラメータをメインフォームに送信: カメラ長、画素 X/Y、ξ、Primary の φ・τ、λ、$\rho^{-1}$、Primary の中心をメイン画面へ。Refined parameters => clipboard は ± 誤差付きのタブ区切り。

### 1.10 補助ボタン

- Get Camera Length / カメラ長を取得: 全方位プロファイルのピーク位置から 2 距離法でカメラ長（標準試料を使わないモードでも動く）。
- Get Wave Length / 波長を取得: 全方位のピーク位置から 2 線法で λ、さらに $p_\text{new} = L\tan 2\theta_1/L_1\cdot p$ で等方的な画素サイズ（Refine! の画素推定とは別の方法）。
- 標準試料を使わない（Use standard crystal / 標準試料を使っている をオフ）ときは、ダブルクリックで手動ピークを追加できるが、Refine! と Get Wave Length は無効。

### 1.11 既定値（Designer。いくつかはレジストリに保存されるので初回のみ）

Division 18、Band width 4 %、Fitting Range 0.8 mm、Threshold 0、Repetition 12、Sector、Peak Decomposition オフ、Δ 100 mm、lower than 150 mm、away from 1 mm。

---

## 2. 総当たり較正（Find Parameters (brute force) / パラメータ探索 (総当たり)）

### 2.1 対象

メイン画面に読み込んでいる**1 枚の画像**を、メイン画面の積分設定（横軸 2θ）で使う。Primary/Secondary は無い。試行値を直接メイン画面（Camera Length 1/2、Direct spot / Foot の X・Y、φ・τ、λ）に書き込み、試行ごとに `DetectorParameters_Changed` を呼ぶ。タブは Flat Panel / Gandolfi（検出器形状で自動選択）。

標準試料: Au（$a=0.407825$ nm、既定）、CeO₂、LaB₆、Al₂O₃、Other（CrystalControl で編集）。積分範囲内の反射を列挙し、X 線 Kα のときは Kα1/Kα2 の両方を作る。グラフ上の赤線をダブルクリックすると、その反射を除外する。

### 2.2 評価値 R（Flat Panel、`evaluatePeakHeightAndTwoTheta`）

$$
R = 1000\Big[\sum_i \big(2\theta^\text{calc}_i - X_i\big)^2 + \frac{W}{\sum_i H_i}\Big]
$$

- $X_i$: ピーク中心（2θ、度）。各反射を pseudo-Voigt＋1 次背景で単独フィット（§1.4 と同じルーチン。初期位置 $2\arcsin(\lambda/2d)$、窓半幅 Fitting range$/\cos\theta$、既定 0.4°）。
- $H_i$: 背景を除いたピーク値（フィットした 1 次背景の上の高さ）。
- $W$: Weight（`numericBoxWeight`、既定 100）。
- 半値幅の項は無い。鋭さは $H$ を通じてのみ入る。「d 値のずれ」は実際には 2θ（度）のずれの二乗和。
- フィットが失敗した反射は両方の和から除かれる。$H_i \le 0$ が一つでもあると $\sum H = +\infty$ とされ第 2 項が 0 になる（→ 実装上の疑問点）。

Gandolfi タブ: $R = \sum(2\theta^\text{calc}-X)^2 \times r$、$r = 1$ または Kα のとき $\sum_{i\ \text{偶数}}(I_i/I_{i+1} - 2)^2$。

### 2.3 探索（Flat Panel、`buttonOptimizeSacla_Click`）

- 反射の $2\theta^\text{calc}\pm 2\times$Fitting range の帯以外をマスクする。
- 探索対象（チェックしたもの）: カメラ長（Direct spot モードでは CL1、Foot モードでは CL2）、中心（または Foot）の X・Y（pix）、φ、τ（度）、λ。各パラメータ $p$ について $p_0 + k\,\delta_p$、$k = 0, -1, +1, \dots, -N, +N$（$N$ = Search range / 探索範囲、$\delta_p$ = Initial step / 初期ステップ）。λ の刻みは入力値（Å）× 0.1（nm）。
- CL × X × Y × φ × τ の直積（各組で再積分）× λ（最内側、再積分なし）。1 サイクルの試行数 $\prod(2N_k+1)$。
- 結果は全サイクル通しての最良値を保持し、各サイクル後に最良値をメイン画面に書いて次のサイクルの中心にする。
- ステップ縮小: サイクルの最良値が**すべてのパラメータで**初期点と同じときだけ、全ステップを 1, 1.3, 1.8, 2.4, 3.2, 4.2, 5.6, 7.5 × 10ⁿ の系列の一つ下の値にする（約 ×0.72〜0.77。系列外の値は直下の系列値。例 0.05 → 0.042）。
- サイクル数: Iteration / 反復（既定 10）。
- 表示: Cycle、Current best values、Current steps、最良 R の上位 **4 個**（全サイクル通し）。
- Stop / 停止: 初期値に戻す。
- 画素サイズ X/Y・ξ のコントロールは Flat Panel タブにあるが無効で、コードでも使われない。

既定値（Flat Panel）: カメラ長 0.05 mm ±1 ✓、X/Y 0.2 pix ±1 ✓、φ/τ 0.01° ±1 ✓、λ 5×10⁻⁵ Å ±2（オフ）、Iteration 10、Fitting range 0.4°、Weight 100、Au、Direct spot。

### 2.4 Gandolfi タブ（`buttonOptimizeGandolfi_Click`）

直積ではなく、（中心 X,Y）、（画素 X,Y）、（カメラ長, Gandolfi 半径）、（τ, φ：同じステップ）の 2 次元格子をそれぞれ現在値のまわりで探索した和集合。既定: カメラ長 0.5 mm ±2、画素 0.0001 mm ±2、中心 1 pix ±2、傾き 0.01 ±2、半径 0.5 mm ±2、Fitting range 0.2°、反復 30。「Square pixel / 正方ピクセル」チェックはコードで参照されていない。

---

## 要確認事項

1. 幾何的較正の名称: UI の日本語は「パラメータ校正 (代数的)」、既存マニュアルは「（幾何学的）」。どちらに統一するか。
2. 1 枚モード（Secondary なし）で 波長・カメラ長・画素サイズを同時に精密化すると、カメラ長と画素の絶対スケールが分離できない（Q 参照）。マニュアルで注意書きにするか。
3. 傾き推定を「全リング中心の同時最小二乗」として a2 を書き直してよいか。
4. 残差の定義（$\sqrt{\sum\Delta^2}/n$）をそのまま書くか、実装を直すか。
5. 総当たりの Weight の意味（$W/\sum H$）と既定 100 の根拠。
6. Gandolfi タブの $I_i/I_{i+1}$ の目標値（コメント 0.5、コード 2）。
7. 球面補正の単位: Find Parameter 画面は `/mm` 表示、コードは m⁻¹（÷1000）。
