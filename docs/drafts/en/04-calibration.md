This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# Calibration of detector parameters with a standard sample (as implemented)

Code: `IPAnalyzer/FindParameter/FormFindParameter.cs` (geometric calibration; en "Find Parameter"), `IPAnalyzer/FindParameter/FormFindParameterBruteForce.cs` (brute force; en "Find Parameters (brute force)"), `Crystallography/FindParameter.cs`, `Crystallography/Mathematics/Geometry.cs` (`GetEllipseCenter`, `GetTiltAndOffset`, `GetPixelShape`), `Crystallography/PeakSearch.cs` (`FittingPeak.FitMultiPeaksThread`), `Crystallography/Detector/Ring.cs` (`SetFindTiltParameter`, `GetProfileForFindTiltCorrection`). Line numbers are approximate and refer to `FormFindParameter.cs`.
Corresponding pages of the current manual: `docs/src/en/appendix/a2-calibration.md`, `4-procedures.md`, `6-find-parameter.md`, `3-tools.md`.

Units: lengths in mm; λ in nm internally (Å in the UI); angles in degrees in the UI and rad internally. `Mathematics/Marquardt.cs` is not used by either form (peak fitting uses its own LM inside `FitMultiPeaksThread`).

---

## 1. Geometric calibration (Find Parameter)

### 1.1 Overall structure

The whole geometric model is not least-squares fitted at once. Instead, the procedure is an alternating iteration: **extract points on the rings from the image with the current parameters → update some of the parameters by a closed-form expression or a 1–2-dimensional grid search**, in a fixed order and a fixed number of times (Repetition, default 12) (`RefineParameters`, L1990–2266). There is no convergence test.

### 1.2 Input and preparation

- Initial values (camera length, pixel size X/Y, ξ, λ, φ, τ, center) are taken from the main window when the form is shown (L93–153). The default standard crystal is CeO₂ ($a = 0.5411102$ nm). It can be changed with Set crystal.
- **Primary image**: Open → Get Profile switches the main window to Concentric and Length, builds a full-azimuth 1-D profile (horizontal axis = radius in mm on the central-projection plane, step $0.25\,p_x$, starting at 1 mm), and fits all reflections (`buttonPrimaryGetProfile_Click`, L1247).
- **Secondary image** (optional): an image of the same sample with the camera length changed by $\Delta$ (`textBoxFilmDistanceDiscrepancy`, default 100 mm, may be negative). $L_2 = L_1 + \Delta$; $\Delta$ is not refined. The Secondary image has its own center and φ, τ.
- Check the reflections to use in the Peak List. "Check peaks meeting following condition" automatically checks reflections whose observed position is < lower than (default 150 mm) and that are at least away from (default 1 mm) from neighbouring reflections (`buttonCheckPeaks_Click`).
- Conditions for running: at least 3 checked reflections in each image and at least 1 common hkl (otherwise it **returns without doing anything**, except when only the camera length is refined). After extraction, it aborts if fewer than 2 rings are valid in 5 or more directions.
- Left-dragging a calculated-ring marker on the profile plot updates the Primary camera length by $L = x/\tan(2\arcsin(\lambda/2d))$.

### 1.3 Extraction of points on the rings (`CollectEllipses`, L1451–1568)

1. The azimuth is divided into $N$ parts (Division, default 18, 8–360). Direction $j$ is assigned the azimuth $\alpha_j = 2\pi j/N$.
2. Region: **Sector** (default, $[(j-\tfrac12), (j+\tfrac12)]\cdot 360°/N$) or **Rectangle** (a band along the half-line at angle $j\cdot360°/N$; width = Band width % × image width, default 4 %). It is set by rewriting the Integral Region of the main window.
3. `Ring.SetFindTiltParameter`: masks everything outside the bands $\pm 2\,\mathrm{SR}$ around the predicted radii $p_i = L\tan(2\arcsin(\lambda/2d_i))$ of the checked reflections (SR = Fitting Range, default 0.8 mm).
4. `Ring.GetProfileForFindTiltCorrection`: a 1-D profile in the radius on the central-projection plane with area-weighted distribution (value = $10\sum IA/\sum A$). The spherical correction is the approximate expression of 03-geometry §5(b).
5. Each reflection is fitted (§1.4), and the point $(L_\text{obs}\cos\alpha_j,\ L_\text{obs}\sin\alpha_j)$ is added to that ring.

With the correct parameters, each ring is a circle on the central-projection plane centered at the origin with radius $L\tan 2\theta$.

### 1.4 Peak fitting (`Fitting` + `FittingPeak.FitMultiPeaksThread`)

- Model: area-normalized pseudo-Voigt ($H$ = FWHM) + a common linear background
  $$
  f(x) = I\,\frac{2}{H}\Big[\frac{\eta}{\pi(1+u)} + (1-\eta)\sqrt{\tfrac{\ln 2}{\pi}}\,e^{-u\ln 2}\Big] + B_1 + B_2(x-x_c),\qquad u = \frac{4(x-X)^2}{H^2}
  $$
  (`PeakSearch.cs` L178). $\eta\in[0,1]$.
- Window: half-width $\mathrm{SR}/\cos\theta_B$ (for the Secondary image, further multiplied by $L_2/L_1$). The initial position is the calculated position (no peak search). The initial FWHM is the value from a total-least-squares line fitted to the $(X, H)$ of the peaks already accepted.
- Peak Decomposition (default off): reflections whose calculated positions differ by less than $2\,\mathrm{SR}$ are fitted simultaneously.
- LM: the data are scaled by 1/1000; $\lambda_\text{LM}$ starts at 10, ×0.5 on acceptance, ×4 on rejection; it terminates when $\lambda_\text{LM}\ge10^9$, after 500 iterations, or when the relative decrease is $<10^{-10}$ after 50 iterations. 11 sets of initial values are tried.
- Rejection: $|X_\text{fit} - X_\text{calc}| > 1.0$ mm (fixed value); S/N (only when Threshold > 0; the default 0 disables it).

### 1.5 Estimation formula for each parameter

| Target | Method | Implementation |
|---|---|---|
| λ (1 image) | Two-line method. For each ring pair $(i,k)$ and each direction, with $Y = L_k/L_i$, $X = d_i/d_k$, $s = \sin^2\theta_i$, solve $Y^2 = X^2(1-X^2s)(1-2s)^2/\{(1-2X^2s)^2(1-s)\}$. Solved by a grid search over $s\in[0.1, 4]\,(\lambda_\text{cur}/2d_i)^2$ with 1000 divisions, repeated 25 times (window ±2.5 steps, step ×0.32). $\lambda = 2d_i\sqrt s$ is averaged with weights $1/(\sigma_i^2+\sigma_k^2)$ ($\sigma$ is the change in λ when the position is shifted by 0.1 mm). Independent of the absolute scale of camera length and pixel size | `FindParameter.GetSinTheta`, `FindWaveLengthFromMultiPeaks` |
| λ (2 images, pixel size not refined) | For each ring, $\lambda = 2d\sin(\tfrac12\arctan(\bar r/L))$ | `FindWaveLengthFromFixedPixelSize` |
| Combining λ and $\rho^{-1}$ from 2 images | Weighted mean with $w_k = N_{\text{ring},k}/\sigma_k^2$ | L1863–1899, L1614–1635 |
| Camera length (1 image) | Simple mean of $L = L_\text{obs}/\tan(2\arcsin(\lambda/2d))$ over all points | `FindFilmDistanceFromWaveLength` |
| Camera length (2 images, two-distance method) | For the same hkl and the same direction, $L_1 = \Delta\,r_1/(r_2 - r_1)$, weight $100/(\delta_1^2+\delta_2^2)$ | `FindFilmDistanceFromDiscrepancy`, `FindCameraLength` |
| Center only (when tilt and pixel are not refined) | Move the center by the mean of the ellipse centers of the rings (limited to ±1 pix per call) | `SetCenterPosition` |
| Tilt + center | §1.6 below | `SetTiltCorrection` → `Geometry.GetTiltAndOffset` |
| Spherical $\rho^{-1}$ | For each ring pair and direction, $p = \tan 2\theta_i/\tan 2\theta_k$ (current λ), and the weighted mean of $\Delta\rho^{-1} = L(L_i - pL_k)/\{L_iL_k(L_k - L_i)\}$ is **added** to the current value | `FindSphericalCorrection` |
| Pixel size, ξ | The second-order coefficients of each ring's conic are normalized by $R_\text{calc}^2/10^6$ and decomposed as $x^2/A^2 - 2Bxy/(A^2C) + (A^2+B^2)y^2/(A^2C^2)$: $A = 1/\sqrt a$, $B = -b/\sqrt{a(4ac-b^2)}$, $C = 2\sqrt{a/(4ac-b^2)}$. The new values $p_x/A$, $p_y/C$, $\xi = \arctan\{(C/A)(\tan\xi - B)\}$ are averaged over the rings (Primary only, even with 2 images) | `Geometry.GetPixelShape` |

### 1.6 Tilt and center (`Geometry.GetTiltAndOffset`)

1. Fit $ax^2+bxy+cy^2+dx+ey = 10^6$ to each ring by algebraic least squares (8 or more points) and obtain the center $\mathbf c_i$. The radius $R_i$ is the mean of $L_\text{obs}$.
2. Fit a line $x\sin\varphi_1 - y\cos\varphi_1 = A$ to the centers of all rings by principal component analysis.
3. For the position $B$ along the line and the remaining tilt $\tau_1$, minimize by a 2-D grid search
   $$
   S = \sum_i 1000\,\big|\mathbf B + R_i(\tau_1)\,\mathbf u - \mathbf c_i\big|^2,\qquad
   R_i(\tau_1) = \frac{L\sin 2\theta_i}{2}\Big(\frac{1}{\cos(2\theta_i+\tau_1)} - \frac{1}{\cos(2\theta_i-\tau_1)}\Big),\quad 2\theta_i = \operatorname{atan2}(R_i, L)
   $$
   ($\mathbf u = (\cos\varphi_1, \sin\varphi_1)$. $B$ from −5 to +5 mm in steps of 0.1, $\tau_1$ from −1° to +1° in steps of 0.02°, 40 rounds, window ±2.4 steps, step ×0.8. At most about ±1.24° per call.)
4. Tilt axis $\varphi_1$ = line direction − 90° (the quadrant is determined by the sign of $\tau_1$, then $\tau_1 \leftarrow |\tau_1|$).
5. Composition with the current tilt: $Q = R(\varphi_1, \tau_1)\,R(\varphi, \tau)$, $R(\varphi,\tau) = R_z(\varphi)R_x(\tau)R_z(-\varphi)$. Starting from $\tau = \arccos Q_{33}$, $\varphi = \operatorname{atan2}(-Q_{31}, Q_{32})$, minimize $\|Q - R(\varphi,\tau)\|_F^2$ by a 2-D grid search ($Q$ generally contains a twist about $Z$, so it is projected onto the 2-parameter family).
6. Error: standard deviation of the solutions of the same procedure for each ring pair.
7. Center: $\mathbf B$ [mm] is converted to pixels (limited to ±1 pix per call) and added to the current center.

Unlike "determine τ for each ring and take a weighted mean" in the current a2, this is a **simultaneous least-squares fit to all ring centers**, and it also determines the beam-center offset at the same time.

### 1.7 Order of the iteration

- 1 image: in each iteration, λ → camera length → (center only) → extraction + tilt → extraction + spherical → extraction + pixel → extraction + residual.
- 2 images: in the first iteration, λ and camera length from the Primary only → λ from 2 images → camera length by the two-distance method → tilt of Secondary and Primary → spherical → pixel (Primary) → residual. From the second iteration on, it starts from the camera length (two-distance method).
- Refined by default: Wave Length, Camera Length, Tilt Correction, Pixel Size, Pixel Distortion, Center Position. Spherical Correction is off. Turning Tilt Correction on forces Center Position on.

### 1.8 Residual (graph "The mean relative residual")

$$
\mathrm{Res} = \frac{\sqrt{\sum \Delta^2}}{n},\qquad \Delta = L_\text{obs} - L_\text{calc}\ \text{[mm]}
$$

(`GetResidual`, L1811; display only). It is neither the RMS ($\sqrt{\sum\Delta^2/n}$) nor the sum of squares (→ Implementation questions).

### 1.9 Applying the results

Refined parameters => Main form: sends camera length, pixel X/Y, ξ, Primary φ and τ, λ, $\rho^{-1}$, and the Primary center to the main window. Refined parameters => clipboard gives tab-separated values with ± errors.

### 1.10 Auxiliary buttons

- Get Camera Length: camera length by the two-distance method from the peak positions of the full-azimuth profiles (works also in the mode without a standard sample).
- Get Wave Length: λ by the two-line method from the full-azimuth peak positions, and further an isotropic pixel size by $p_\text{new} = L\tan 2\theta_1/L_1\cdot p$ (a different method from the pixel estimation in Refine!).
- When no standard sample is used (Use standard crystal off), manual peaks can be added by double-clicking, but Refine! and Get Wave Length are disabled.

### 1.11 Default values (Designer; some are saved in the registry, so these apply only on first run)

Division 18, Band width 4 %, Fitting Range 0.8 mm, Threshold 0, Repetition 12, Sector, Peak Decomposition off, Δ 100 mm, lower than 150 mm, away from 1 mm.

---

## 2. Brute-force calibration (Find Parameters (brute force))

### 2.1 Scope

It uses the **single image** loaded in the main window, with the integration settings of the main window (horizontal axis 2θ). There is no Primary/Secondary. Trial values are written directly into the main window (Camera Length 1/2, X and Y of Direct spot / Foot, φ, τ, λ), and `DetectorParameters_Changed` is called for each trial. Tabs: Flat Panel / Gandolfi (selected automatically from the detector shape).

Standard samples: Au ($a=0.407825$ nm, default), CeO₂, LaB₆, Al₂O₃, Other (edited in CrystalControl). Reflections within the integration range are listed; for X-ray Kα both Kα1 and Kα2 are generated. Double-clicking a red line on the graph excludes that reflection.

### 2.2 Figure of merit R (Flat Panel, `evaluatePeakHeightAndTwoTheta`)

$$
R = 1000\Big[\sum_i \big(2\theta^\text{calc}_i - X_i\big)^2 + \frac{W}{\sum_i H_i}\Big]
$$

- $X_i$: peak center (2θ, degrees). Each reflection is fitted individually with pseudo-Voigt + linear background (the same routine as §1.4; initial position $2\arcsin(\lambda/2d)$, window half-width Fitting range$/\cos\theta$, default 0.4°).
- $H_i$: background-subtracted peak value (height above the fitted linear background).
- $W$: Weight (`numericBoxWeight`, default 100).
- There is no FWHM term. Sharpness enters only through $H$. The "d-value deviation" is actually the sum of squares of the 2θ (degree) deviations.
- Reflections whose fit fails are excluded from both sums. If even one $H_i \le 0$, $\sum H$ is set to $+\infty$ and the second term becomes 0 (→ Implementation questions).

Gandolfi tab: $R = \sum(2\theta^\text{calc}-X)^2 \times r$, with $r = 1$, or for Kα $\sum_{i\ \text{even}}(I_i/I_{i+1} - 2)^2$.

### 2.3 Search (Flat Panel, `buttonOptimizeSacla_Click`)

- Everything outside the bands $2\theta^\text{calc}\pm 2\times$Fitting range of the reflections is masked.
- Search targets (those checked): camera length (CL1 in Direct spot mode, CL2 in Foot mode), X and Y of the center (or Foot) (pix), φ, τ (degrees), λ. For each parameter $p$: $p_0 + k\,\delta_p$, $k = 0, -1, +1, \dots, -N, +N$ ($N$ = Search range, $\delta_p$ = Initial step). The λ step is the input value (Å) × 0.1 (nm).
- Direct product CL × X × Y × φ × τ (re-integrated for each combination) × λ (innermost, no re-integration). Number of trials per cycle: $\prod(2N_k+1)$.
- The best value over all cycles is kept; after each cycle the best value is written to the main window and becomes the center of the next cycle.
- Step reduction: only when the best value of the cycle equals the initial point **for all parameters**, all steps are set to the next lower value in the series 1, 1.3, 1.8, 2.4, 3.2, 4.2, 5.6, 7.5 × 10ⁿ (about ×0.72–0.77; a value not in the series goes to the series value just below it, e.g. 0.05 → 0.042).
- Number of cycles: Iteration (default 10).
- Display: Cycle, Current best values, Current steps, and the top **4** best R values (over all cycles).
- Stop: restores the initial values.
- The pixel size X/Y and ξ controls are on the Flat Panel tab but are disabled and not used in the code.

Defaults (Flat Panel): camera length 0.05 mm ±1 ✓, X/Y 0.2 pix ±1 ✓, φ/τ 0.01° ±1 ✓, λ 5×10⁻⁵ Å ±2 (off), Iteration 10, Fitting range 0.4°, Weight 100, Au, Direct spot.

### 2.4 Gandolfi tab (`buttonOptimizeGandolfi_Click`)

Not a direct product, but the union of 2-D grids searched around the current values for (center X, Y), (pixel X, Y), (camera length, Gandolfi radius), and (τ, φ: same step). Defaults: camera length 0.5 mm ±2, pixel 0.0001 mm ±2, center 1 pix ±2, tilt 0.01 ±2, radius 0.5 mm ±2, Fitting range 0.2°, iterations 30. The "Square pixel" check box is not referenced in the code.

---

## Items to confirm

1. Name of the geometric calibration: the Japanese UI says 「パラメータ校正 (代数的)」 ("algebraic"), the current Japanese manual says 「（幾何学的）」 ("geometric"). Which should be used consistently?
2. In 1-image mode (no Secondary), refining wavelength, camera length and pixel size simultaneously cannot separate the absolute scale of camera length and pixel size (see Q). Should the manual carry a note about this?
3. May a2 be rewritten to describe the tilt estimation as a "simultaneous least-squares fit to all ring centers"?
4. Should the residual definition ($\sqrt{\sum\Delta^2}/n$) be documented as is, or should the implementation be fixed?
5. Meaning of the brute-force Weight ($W/\sum H$) and the basis for the default 100.
6. Target value of $I_i/I_{i+1}$ on the Gandolfi tab (0.5 in the comment, 2 in the code).
7. Unit of the spherical correction: the Find Parameter window shows `/mm`, the code uses m⁻¹ (÷1000).
