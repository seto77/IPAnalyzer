This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# Detector geometry (as implemented)

Code: `Crystallography/Detector/Ring.cs` (submodule `7a435ee`), `IPAnalyzer/FormMain.cs`, `IPAnalyzer/FormProperty.cs`.
Corresponding pages of the current manual: `docs/src/en/0-overview.md` (axes, tilt, pixel shape) and `docs/src/en/appendix/a1-geometry.md`.

## 1. Symbols and units

| Symbol | UI label | Internal variable | UI unit → internal unit | Set in |
|---|---|---|---|---|
| $L$ | Camera Length 1 | `IntegralProperty.FilmDistance` | mm → mm | `FormMain.SetIntegralProperty` ← `FormProperty.CameraLength1` |
| $L_2$ | Camera Length 2 | `FormProperty.CameraLength2` | mm | `FormProperty.DetectorParameters_Changed` |
| $(c_x, c_y)$ | Direct spot position X, Y | `IP.CenterX`, `IP.CenterY` | pix (real) | same |
| $p_x, p_y$ | Pixel Size X, Y | `IP.PixSizeX`, `IP.PixSizeY` | mm | same |
| $\xi$ | ξ | `IP.ksi` | ° → rad (`numericBoxPixelKsi.RadianValue`) | same |
| $\varphi, \tau$ | φ, τ | `IP.phi`, `IP.tau` | ° → rad | same |
| $\rho^{-1}$ | Inverse of radius | `IP.SpericalRadiusInverse` | m⁻¹ → mm⁻¹ (`/1000`) | `FormMain.SetIntegralProperty` |
| $r_G$ | Gandolfi Radius | `IP.GandolfiRadius` | mm | same |
| $\lambda$ | Wavelength | `IP.WaveLength` | displayed in Å by default (Å/nm switchable, `waveLengthUnitPerNm` in `Crystallography.Controls/Wave/WaveLengthControl.cs`) → always **nm** internally | `FormProperty.WaveLength`; d output is multiplied by 10 back to Å (`Ring.GetConcenrticProfile`) |

Pixel indices $(i, j)$ are column and row ($j$ increases downward). **Pixel centres sit on integer coordinates**; the corners are at $(i\pm\tfrac12, j\pm\tfrac12)$ (vertex computation in `Ring.GetCorrectedImageArray`, `Ring.GetRadialProfile`).

## 2. In-plane detector coordinates (pixel skew ξ)

In-plane coordinates $(x_d, y_d)$ [mm] with origin at the direct spot:

$$
x_d = (i - c_x)\,p_x + (j - c_y)\,p_y \tan\xi,\qquad
y_d = (j - c_y)\,p_y
$$

(`Ring.SetTiltParameter` sets `TanKsi = Math.Tan(IP.ksi)`; the same formula is used in `Ring.FindSpotsThread0`, `Ring.ConvertCoordinateFromDetectorToRealSpace`, `FormMain.convertScreenToDetector`, etc.).

> **Difference from the current manual**: `appendix/a1-geometry.md` writes $x = \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi$, i.e. **sin ξ**; the code uses **tan ξ**. The $y$ component $\mathrm{PixNumY}\cdot\mathrm{PixSizeY}$ agrees with the code, so $p_y$ is the $y$ component of the row step, not the parallelogram side (the side is $p_y/\cos\xi$).

## 3. Real-space coordinates (flat panel)

The real-space frame used in the code has the **sample at the origin**, $Z$ along the beam, $X$ to the image right and $Y$ to the image bottom (right-handed). The direct spot is at $(0, 0, L)$.

> The current manual (`0-overview.md`, `a1-geometry.md`) puts the origin at the direct spot with the sample at $(0,0,-\mathrm{CL})$. This is only a translation, but the code must be read with the sample at the origin.

The tilt is a rotation $R$ by $\tau$ about $\mathbf n = (\cos\varphi, \sin\varphi, 0)$, the in-plane direction at angle $\varphi$ from $X$ (Rodrigues form). A pixel's real-space position is

$$
\mathbf r = R\begin{pmatrix}x_d\\ y_d\\ 0\end{pmatrix} + \begin{pmatrix}0\\0\\L\end{pmatrix},\qquad
R = \begin{pmatrix}
\cos^2\varphi + \cos\tau\sin^2\varphi & \cos\varphi\sin\varphi(1-\cos\tau) & \sin\varphi\sin\tau\\
\cos\varphi\sin\varphi(1-\cos\tau) & \sin^2\varphi + \cos\tau\cos^2\varphi & -\cos\varphi\sin\tau\\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

Only the first two columns are precomputed (`Ring.SetTiltParameter`):

| Constant | Value | Element of $R$ |
|---|---|---|
| `Numer2` | $\cos^2\varphi + \cos\tau\sin^2\varphi$ | $R_{11}$ |
| `Numer1` | $\cos\varphi\sin\varphi(1-\cos\tau)$ | $R_{12}=R_{21}$ |
| `Numer3` | $\cos^2\varphi\cos\tau + \sin^2\varphi$ | $R_{22}$ |
| `Denom2` | $-\sin\varphi\sin\tau$ | $R_{31}$ |
| `Denom1` | $\cos\varphi\sin\tau$ | $R_{32}$ |

Hence $X = R_{11}x_d + R_{12}y_d,\ Y = R_{21}x_d + R_{22}y_d,\ Z = L + R_{31}x_d + R_{32}y_d$ (`Ring.ConvertCoordinateFromDetectorToRealSpace`, `Ring.GetProfileThreadWithTiltCorrectionNew`).

### 3.1 Sign conventions of φ and τ

- $\varphi$: azimuth of the tilt axis, measured from $X$ (image right) towards $Y$ (image down), i.e. **clockwise on screen**. This agrees with `0-overview.md` ("the X axis rotated clockwise by φ").
- $\tau$: right-handed rotation about $\mathbf n$. Since $Z = L + \sin\tau\,(-\sin\varphi\,x_d + \cos\varphi\,y_d)$, for $\tau>0$ the pixels on the $(-\sin\varphi, \cos\varphi)$ side (the axis turned 90° clockwise on screen) move **away from the sample**.
- There is a single rotation (by $\tau$ about $\mathbf n$), equivalent to $R_z(\varphi)R_x(\tau)R_z(-\varphi)$. An in-plane rotation of the detector about $Z$ is not a degree of freedom (Debye rings are invariant under it, as a1 explains).

### 3.2 2θ and χ

$$
q = \sqrt{X^2+Y^2},\quad l = |\mathbf r|,\quad
2\theta = \begin{cases}\arcsin(q/l) & (Z\ge 0)\\ \pi - \arcsin(q/l) & (Z<0)\end{cases},\qquad
\chi_\text{raw} = \operatorname{atan2}(Y, X)\in[0, 2\pi)
$$

(`Ring.GetProfileThreadWithTiltCorrectionNew`). $\chi_\text{raw}$ is 0 to the image right and positive **clockwise on screen**. The user-selectable χ definition on the Miscellaneous tab (reference direction Top/Bottom/Left/Right and sense Clockwise/Counterclockwise; stored in `Ring.ChiDirection`/`Ring.ChiRotation` in `FormProperty.cs`, default Right, Clockwise) is used only in the following places:

| Process | Uses the χ definition? | Code |
|---|---|---|
| Integral Region → Sector | yes | `Ring.SetInsideArea` (Sector branch) |
| Radial integration (cake) output axis | yes | shift/flip at the end of `Ring.GetRadialProfile` |
| Polarization direction | reference direction only (Right/Left → horizontal, Top/Bottom → vertical) | `FormMain.FlipRotate_Pollalization_Background` |
| Azimuthal Division Analysis | **no** (fixed $\chi_\text{raw}$) | `Ring.GetConcenrticProfilesBySector` / end of `GetProfileThreadWithTiltCorrectionNew` (comment: "未実装 最後にChiRotationとChiDirectionを考慮して、行を入れ替え" = not implemented) |
| Unrolled image vertical axis | **no** | `Ring.GetUnrolledImageArray` |

### 3.3 Central projection onto the untilted plane

Some routines use the central projection of $\mathbf r$ from the sample onto the plane $Z=L$:

$$
(X', Y') = \frac{L}{Z}(X, Y),\qquad \tan 2\theta = \frac{\sqrt{X'^2+Y'^2}}{L}
$$

(`Ring.FindSpotsThread0`, `Ring.CorrectPolarization`, `Ring.GetRadialProfile`, `Ring.GetProfileThreadWithTiltCorrection` (Length mode), `Ring.GetCorrectedImageArray`). This is $P_3$ in the "projection" section of a1.

## 4. Direct-spot and Foot coordinates

Coordinates on the Detector condition tab: **Direct spot** / **Foot** (`FormProperty.DetectorCoordinatesEnum`). The foot is the foot of the perpendicular from the sample onto the detector plane. `FormProperty.DetectorParameters_Changed` converts between them:

$$
L_2 = L\cos\tau,\qquad
(x_F, y_F) = L\sin\tau\,(\sin\varphi,\ -\cos\varphi)\ \text{[mm, in-plane]},
$$
$$
\Delta j_F = \frac{y_F}{p_y},\qquad \Delta i_F = \frac{x_F - y_F\tan\xi}{p_x},\qquad
\text{Foot} = \text{DirectSpot} + (\Delta i_F, \Delta j_F)
$$

(in Foot mode, $L = L_2/\cos\tau$ and the direct spot is computed backwards). Integration and corrections always use the direct spot and $L$ (Camera Length 1): `FormMain.SetIntegralProperty` reads only `FormProperty.CameraLength1` and `numericBoxDirectSpotPositionX/Y`. The cursor read-out uses the foot origin, `FormProperty.DetectorRotation` (a matrix equivalent to $R^{\mathsf T}$) and $L_2$ (`FormMain.convertScreenToDetector` / `convertDetectorToReal`).

## 5. Spherical (curvature) correction

UI: Spherical correction, "Inverse of radius" on the Detector condition tab (unit shown `/m`, default 0). Internally $\rho^{-1}$ [mm⁻¹] = input / 1000; 0 disables it. There are two implementations with different formulas.

**(a) New implementation** (`Ring.GetProfileThreadWithTiltCorrectionNew`, `Ring.ConvertCoordinateFromDetectorToRealSpace`): a point $\mathbf r$ on the plane is mapped onto a sphere of radius $\rho$ tangent to the plane at the direct spot $\mathbf D=(0,0,L)$, so that the in-plane distance from the tangent point becomes the arc length:

$$
d = |\mathbf r - \mathbf D|,\quad \alpha = d/\rho,\qquad
\mathbf r' = \mathbf D + \frac{\rho\sin\alpha}{d}(\mathbf r - \mathbf D) + \rho(1-\cos\alpha)\,\hat{\mathbf n}_s,\qquad
\hat{\mathbf n}_s = (-\sin\varphi\sin\tau,\ \cos\varphi\sin\tau,\ -\cos\tau) = -R\,\hat{\mathbf e}_z
$$

$\hat{\mathbf n}_s$ is the detector normal pointing towards the sample, so for $\rho>0$ the detector curves towards the sample ($\rho = L$, $\tau=0$ gives a sphere centred on the sample).

**(b) Old implementation** (Length mode, `Ring.GetProfileThreadWithTiltCorrection`): the projected coordinates are scaled by the small-angle form of the formula in the code comment, $l' = L\rho\sin(l/\rho)/\{L - \rho(1-\cos(l/\rho))\}$:

$$
(X'', Y'') = \frac{L}{L - (X'^2+Y'^2)\rho^{-1}/2}(X', Y')
$$

The spherical correction is **not** applied in spot finding (`FindSpotsThread0`), the integration-angle mask (`SetInsideArea`, flat-panel branch), polarization correction (`CorrectPolarization`), radial integration (`GetRadialProfile`) or the rectified image for IPA saving (`GetCorrectedImageArray`). The Sector-region test does use it, through `ConvertCoordinateFromDetectorToRealSpace`.

## 6. Gandolfi (cylindrical) detector

With Detector type = **Gandolfi**, a different mapping is used (`Ring.SetInsideArea` Gandolfi branch, `Ring.GetProfileGandlfi`):

$$
\mathbf v = R_y(\tau)\,R_x(\varphi)\begin{pmatrix} r_G\sin\!\big((i-c_x)p_x/r_G\big)\\ -(j-c_y)\,p_y\\ r_G\big(\cos((i-c_x)p_x/r_G) - 1\big)\end{pmatrix},\qquad
\cos 2\theta = \frac{v_z + L}{\sqrt{v_x^2+v_y^2+(v_z+L)^2}}
$$

(`Matrix3D(CosTau, SinTau*SinPhi, SinTau*CosPhi, 0, CosPhi, -SinPhi, -SinTau, CosTau*SinPhi, CosTau*CosPhi)` $= R_y(\tau)R_x(\varphi)$). Differences from the flat panel:

- The cylinder axis is the image vertical; the $x$ pixel position is the arc length on the cylinder.
- The sign of $y$ is reversed (up is positive).
- **φ and τ mean something different** (rotation by $\varphi$ about $x$, then by $\tau$ about $y$).
- ξ and the spherical correction are not used.

## 7. Relation to (WIN)PIP

The conversion "PIP $(\beta, \Phi)$ → IPAnalyzer $(\varphi,\tau) = (270^\circ-\beta, \Phi)$" in `0-overview.md` has no counterpart in the code (no conversion routine or comment). It is kept as stated in the current manual.

## Items to confirm

1. Should a1 be corrected to tan ξ (as implemented), or is sin ξ the intended physical definition and the code should change (Implementation questions, Q1)?
2. Is it right to read $p_y$ as the $y$ component of the row step (side length $p_y/\cos\xi$)?
3. Is the sign convention of the spherical correction ($\rho>0$ curves towards the sample) and the UI unit `/m` correct? Is the difference between the old (b) and new (a) formulas intended?
4. Is the missing χ-definition support in azimuthal division and unrolling by design or unfinished (the comment says unfinished)?
5. May the Gandolfi definition of φ and τ ($R_y(\tau)R_x(\varphi)$) be stated in the manual?
6. Source of the PIP conversion $(270^\circ-\beta,\Phi)$.
