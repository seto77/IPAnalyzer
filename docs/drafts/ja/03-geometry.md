本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 検出器の幾何（実装準拠）

対象コード: `Crystallography/Detector/Ring.cs`（submodule `7a435ee`）、`IPAnalyzer/FormMain.cs`、`IPAnalyzer/FormProperty.cs`。
既存マニュアルの対応箇所: `docs/src/ja/0-overview.md`「軸の向き・IP の傾き・画素形状」、`docs/src/ja/appendix/a1-geometry.md`。

## 1. 記号と単位

| 記号 | UI（英 / 日） | 内部変数 | UI 単位 → 内部単位 | 設定箇所 |
|---|---|---|---|---|
| $L$ | Camera Length 1 | `IntegralProperty.FilmDistance` | mm → mm | `FormMain.SetIntegralProperty` ← `FormProperty.CameraLength1` |
| $L_2$ | Camera Length 2 | `FormProperty.CameraLength2` | mm | `FormProperty.DetectorParameters_Changed` |
| $(c_x, c_y)$ | Direct spot position X, Y | `IP.CenterX`, `IP.CenterY` | pix（実数） | 同上 |
| $p_x, p_y$ | Pixel Size X, Y | `IP.PixSizeX`, `IP.PixSizeY` | mm | 同上 |
| $\xi$ | ξ | `IP.ksi` | ° → rad (`numericBoxPixelKsi.RadianValue`) | 同上 |
| $\varphi, \tau$ | φ, τ | `IP.phi`, `IP.tau` | ° → rad | 同上 |
| $\rho^{-1}$ | Inverse of radius / 半径の逆数 | `IP.SpericalRadiusInverse` | m⁻¹ → mm⁻¹（`/1000`） | `FormMain.SetIntegralProperty` |
| $r_G$ | Gandolfi Radius | `IP.GandolfiRadius` | mm | 同上 |
| $\lambda$ | Wavelength | `IP.WaveLength` | 表示は既定 Å（Å/nm 切替あり、`Crystallography.Controls/Wave/WaveLengthControl.cs` の `waveLengthUnitPerNm`）→ 内部は常に **nm** | `FormProperty.WaveLength`。d 出力時に ×10 して Å に戻す（`Ring.GetConcenrticProfile`） |

画素インデックス $(i, j)$ は列・行（$j$ は画面下向きに増加）。**画素中心が整数座標**で、画素の四隅は $(i\pm\tfrac12, j\pm\tfrac12)$（`Ring.GetCorrectedImageArray`、`Ring.GetRadialProfile` の頂点計算）。

## 2. 検出器面内座標（画素歪み ξ）

ダイレクトスポットを原点とする検出器面内座標 $(x_d, y_d)$ [mm] は

$$
x_d = (i - c_x)\,p_x + (j - c_y)\,p_y \tan\xi,\qquad
y_d = (j - c_y)\,p_y
$$

（`Ring.SetTiltParameter` で `TanKsi = Math.Tan(IP.ksi)`、`Ring.FindSpotsThread0`・`Ring.ConvertCoordinateFromDetectorToRealSpace`・`FormMain.convertScreenToDetector` などすべて同じ式）。

> **既存マニュアルとの差**: `appendix/a1-geometry.md` は $x = \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi$ と **sin ξ** で書いているが、実装は **tan ξ**。また a1 の式は $y$ 成分を $\mathrm{PixNumY}\cdot\mathrm{PixSizeY}$ としており、これは実装と一致（すなわち $p_y$ は「行方向の送り量の $y$ 成分」であり、平行四辺形の辺長ではない。辺長は $p_y/\cos\xi$）。

## 3. 実空間座標（平面検出器）

実空間座標系（実装の「real space」）は **試料を原点**、$Z$ をビーム進行方向、$X$ を画像右向き、$Y$ を画像下向きとする右手系。ダイレクトスポットは $(0, 0, L)$。

> 既存マニュアル（`0-overview.md`, `a1-geometry.md`）は「ダイレクトスポットを原点、試料を $(0,0,-\mathrm{CL})$」と書く。平行移動の違いだけで物理的には同じだが、実装を読むときは試料原点で読む必要がある。

傾きは「$XY$ 面内で $X$ 軸から角 $\varphi$ の方向 $\mathbf n = (\cos\varphi, \sin\varphi, 0)$ を軸とする角 $\tau$ の回転」$R$ で表す（Rodrigues 形）。画素の実空間位置は

$$
\mathbf r = R\begin{pmatrix}x_d\\ y_d\\ 0\end{pmatrix} + \begin{pmatrix}0\\0\\L\end{pmatrix},\qquad
R = \begin{pmatrix}
\cos^2\varphi + \cos\tau\sin^2\varphi & \cos\varphi\sin\varphi(1-\cos\tau) & \sin\varphi\sin\tau\\
\cos\varphi\sin\varphi(1-\cos\tau) & \sin^2\varphi + \cos\tau\cos^2\varphi & -\cos\varphi\sin\tau\\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

実装では $R$ の第 1・2 列だけを定数化している（`Ring.SetTiltParameter`）:

| 実装の定数 | 値 | $R$ の要素 |
|---|---|---|
| `Numer2` | $\cos^2\varphi + \cos\tau\sin^2\varphi$ | $R_{11}$ |
| `Numer1` | $\cos\varphi\sin\varphi(1-\cos\tau)$ | $R_{12}=R_{21}$ |
| `Numer3` | $\cos^2\varphi\cos\tau + \sin^2\varphi$ | $R_{22}$ |
| `Denom2` | $-\sin\varphi\sin\tau$ | $R_{31}$ |
| `Denom1` | $\cos\varphi\sin\tau$ | $R_{32}$ |

したがって $X = R_{11}x_d + R_{12}y_d,\ Y = R_{21}x_d + R_{22}y_d,\ Z = L + R_{31}x_d + R_{32}y_d$（`Ring.ConvertCoordinateFromDetectorToRealSpace`、`Ring.GetProfileThreadWithTiltCorrectionNew`）。

### 3.1 φ・τ の向き（符号）

- $\varphi$: 傾き軸の方位。$X$（画像右）から $Y$（画像下）へ向かう向き、すなわち**画面上で時計回り**に測る。既存マニュアル `0-overview.md` の「X 軸を時計回りに φ だけ回した軸」と一致。
- $\tau$: 軸 $\mathbf n$ まわりの右ねじ回転。$Z = L + \sin\tau\,(-\sin\varphi\,x_d + \cos\varphi\,y_d)$ なので、面内で $\mathbf n$ を画面上時計回りに 90° 回した方向 $(-\sin\varphi, \cos\varphi)$ 側の画素が**試料から遠ざかる**（$\tau>0$ のとき）。
- 回転は 1 回（軸 $\mathbf n$ まわり $\tau$）だけで、「$R_z(\varphi)R_x(\tau)R_z(-\varphi)$」と等価。$Z$ 軸まわりの検出器の回転（面内回転）は自由度に含まれない（デバイ環が $Z$ 軸まわりに不変なため。既存 a1 の説明どおり）。

### 3.2 2θ と χ

$$
q = \sqrt{X^2+Y^2},\quad l = |\mathbf r|,\quad
2\theta = \begin{cases}\arcsin(q/l) & (Z\ge 0)\\ \pi - \arcsin(q/l) & (Z<0)\end{cases},\qquad
\chi_\text{raw} = \operatorname{atan2}(Y, X)\in[0, 2\pi)
$$

（`Ring.GetProfileThreadWithTiltCorrectionNew`）。$\chi_\text{raw}$ は画像右向きを 0、**画面上時計回り**が正。ユーザーが Miscellaneous タブで選ぶ χ の定義（基準方向 Top/Bottom/Left/Right、回転方向 Clockwise/Counterclockwise。`FormProperty.cs` で `Ring.ChiDirection`/`Ring.ChiRotation` に設定、既定 Right・Clockwise）は、次の処理にだけ反映される:

| 処理 | χ 定義の反映 | 実装 |
|---|---|---|
| Integral Region の Sector（扇形） | あり | `Ring.SetInsideArea`（Sector 分岐） |
| Radial integration（cake）出力の横軸 | あり | `Ring.GetRadialProfile` 末尾のシフト／反転 |
| 偏光補正の偏光方向 | 基準方向のみ（Right/Left → 水平、Top/Bottom → 垂直） | `FormMain.FlipRotate_Pollalization_Background` |
| 方位角分割解析（Azimuthal Division） | **なし**（$\chi_\text{raw}$ 固定） | `Ring.GetConcenrticProfilesBySector`／`GetProfileThreadWithTiltCorrectionNew` 末尾コメント「未実装 最後にChiRotationとChiDirectionを考慮して、行を入れ替え」 |
| 切り開き画像（Unroll）の縦軸 | **なし** | `Ring.GetUnrolledImageArray` |

### 3.3 傾きのない面への中心投影

一部の処理は、$\mathbf r$ を試料中心から $Z=L$ 面へ中心投影した点

$$
(X', Y') = \frac{L}{Z}(X, Y),\qquad \tan 2\theta = \frac{\sqrt{X'^2+Y'^2}}{L}
$$

で計算する（`Ring.FindSpotsThread0`、`Ring.CorrectPolarization`、`Ring.GetRadialProfile`、`Ring.GetProfileThreadWithTiltCorrection`（Length モード）、`Ring.GetCorrectedImageArray`）。既存 `a1-geometry.md` の「射影」節の $P_3$ と同じ。

## 4. Direct spot 基準と Foot 基準

Detector condition タブの Coordinates で **Direct spot** / **Foot** を選ぶ（`FormProperty.DetectorCoordinatesEnum`）。Foot は試料から検出器面へ下ろした垂線の足。`FormProperty.DetectorParameters_Changed` は次の関係で一方から他方を計算する:

$$
L_2 = L\cos\tau,\qquad
(x_F, y_F) = L\sin\tau\,(\sin\varphi,\ -\cos\varphi)\ \text{[mm, 面内]},
$$
$$
\Delta j_F = \frac{y_F}{p_y},\qquad \Delta i_F = \frac{x_F - y_F\tan\xi}{p_x},\qquad
\text{Foot} = \text{DirectSpot} + (\Delta i_F, \Delta j_F)
$$

（Foot モードのときは $L = L_2/\cos\tau$ として逆に Direct spot を求める）。積分・補正の計算は常に Direct spot と $L$（Camera Length 1）で行われる（`FormMain.SetIntegralProperty` は `FormProperty.CameraLength1` と `numericBoxDirectSpotPositionX/Y` だけを読む）。マウス位置の座標表示は Foot 原点・`FormProperty.DetectorRotation`（$R^{\mathsf T}$ に相当する行列）と $L_2$ を使う（`FormMain.convertScreenToDetector` / `convertDetectorToReal`）。

## 5. 球面（湾曲）補正

UI: Detector condition の Spherical correction「Inverse of radius」（単位表示 `/m`、既定 0）。内部では $\rho^{-1}$ [mm⁻¹] = 入力値 / 1000。0 のとき無効。実装が 2 系統あり、式が異なる。

**(a) 新実装**（`Ring.GetProfileThreadWithTiltCorrectionNew`、`Ring.ConvertCoordinateFromDetectorToRealSpace`）: 平面上の点 $\mathbf r$ を、ダイレクトスポット $\mathbf D=(0,0,L)$ で平面に接する半径 $\rho$ の球面上へ「接点からの面内距離 = 弧長」となるよう写す。

$$
d = |\mathbf r - \mathbf D|,\quad \alpha = d/\rho,\qquad
\mathbf r' = \mathbf D + \frac{\rho\sin\alpha}{d}(\mathbf r - \mathbf D) + \rho(1-\cos\alpha)\,\hat{\mathbf n}_s,\qquad
\hat{\mathbf n}_s = (-\sin\varphi\sin\tau,\ \cos\varphi\sin\tau,\ -\cos\tau) = -R\,\hat{\mathbf e}_z
$$

$\hat{\mathbf n}_s$ は試料側を向く検出器法線なので、$\rho>0$ では検出器が試料側へ湾曲する（$\rho = L$, $\tau=0$ で試料中心の球面）。

**(b) 旧実装**（Length モードの `Ring.GetProfileThreadWithTiltCorrection`）: 投影座標 $(X', Y')$ に対し、コード中コメントの式 $l' = L\rho\sin(l/\rho)/\{L - \rho(1-\cos(l/\rho))\}$ を小角近似した

$$
(X'', Y'') = \frac{L}{L - (X'^2+Y'^2)\rho^{-1}/2}(X', Y')
$$

を用いる。

球面補正は、スポット検出（`FindSpotsThread0`）、積分角度範囲マスク（`SetInsideArea` の Flat panel 分岐）、偏光補正（`CorrectPolarization`）、Radial integration（`GetRadialProfile`）、IPA 保存の補正画像（`GetCorrectedImageArray`）には**入っていない**（Sector 領域判定だけは `ConvertCoordinateFromDetectorToRealSpace` 経由で入る）。

## 6. Gandolfi（円筒）検出器

Detector type を **Gandolfi** にすると、別の写像になる（`Ring.SetInsideArea` の Gandolfi 分岐、`Ring.GetProfileGandlfi`）。

$$
\mathbf v = R_y(\tau)\,R_x(\varphi)\begin{pmatrix} r_G\sin\!\big((i-c_x)p_x/r_G\big)\\ -(j-c_y)\,p_y\\ r_G\big(\cos((i-c_x)p_x/r_G) - 1\big)\end{pmatrix},\qquad
\cos 2\theta = \frac{v_z + L}{\sqrt{v_x^2+v_y^2+(v_z+L)^2}}
$$

（`Matrix3D(CosTau, SinTau*SinPhi, SinTau*CosPhi, 0, CosPhi, -SinPhi, -SinTau, CosTau*SinPhi, CosTau*CosPhi)` $= R_y(\tau)R_x(\varphi)$）。平面検出器との違い:

- 円筒軸は画像の縦方向、$x$ 方向の画素位置は円筒上の弧長。
- $y$ の符号が平面検出器と逆（上向き正）。
- **φ, τ の意味が平面検出器と異なる**（$x$ 軸まわり $\varphi$ → $y$ 軸まわり $\tau$ の 2 回転）。
- ξ と球面補正は使われない。

## 7. （WIN）PIP との対応

既存マニュアル（`0-overview.md`）の「PIP の $(\beta, \Phi)$ → IPAnalyzer の $(\varphi,\tau) = (270^\circ-\beta, \Phi)$」は、コード中に対応する変換処理・コメントが見当たらない（既存文書の記述をそのまま残す）。

## 要確認事項

1. ξ の定義を tan ξ（実装）に合わせて既存 a1 を直してよいか。あるいは sin ξ が物理的定義で、実装を直すべきか（「実装上の疑問点」Q1）。
2. $p_y$ を「行送りの $y$ 成分」と読む解釈でよいか（辺長は $p_y/\cos\xi$）。
3. 球面補正の符号規約（$\rho>0$ で試料側へ湾曲）と、UI 単位 `/m` の表記で正しいか。旧実装 (b) と新実装 (a) の差は意図どおりか。
4. 方位角分割・切り開き画像で χ 定義を反映しないのは仕様か未実装か（コメント上は未実装）。
5. Gandolfi の φ・τ の定義（$R_y(\tau)R_x(\varphi)$）をマニュアルに明記してよいか。
6. PIP との換算式 $(270^\circ-\beta,\Phi)$ の出典。
