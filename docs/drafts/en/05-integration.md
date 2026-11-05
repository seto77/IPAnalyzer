This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# From 2D image to 1D profile: integration and corrections (as implemented)

Code: `Crystallography/Detector/Ring.cs` (submodule `7a435ee`), `Crystallography/Profile.cs`, `IPAnalyzer/FormMain.cs`, `IPAnalyzer/FormProperty.cs`.
Geometric symbols ($L, x_d, y_d, R, \mathbf r, 2\theta, \chi_\text{raw}$, …) follow [03-geometry.md](03-geometry.md).
Corresponding pages of the current manual: `docs/src/en/0-overview.md` (pixel-intensity integration), `docs/src/en/appendix/a3-image-integration.md`, `docs/src/en/2-property-windows.md`.

## 1. Order of processing

On image load, and whenever flip/rotate, background or polarization settings change, `FormMain.FlipRotate_Pollalization_Background` rebuilds `Ring.Intensity`. Integration works on this corrected array.

1. Flip/rotate: `Ring.FlipAndRotate(Ring.IntensityOriginal, …, flipV, flipH, rotate)` (Option menu Flip / Rotate). **The array used for computation changes**, not just the display.
2. Background subtraction: `Ring.SubtractBackground`, $I \leftarrow I - c\,B$ ($B$: image registered on the Background Option tab, $c$: `numericBoxBackgroundCoeff`, default 1). Nothing happens if the pixel counts differ.
3. Polarization correction (if Correct linear polarization is on): `Ring.CorrectPolarization` (§6.1).
4. Intensity histogram: `Ring.CalcFreq`.

Get Profile (`FormMain.GetProfile`):

1. `SetIntegralProperty` copies UI values into `IntegralProperty IP`.
2. If "find center before Get Profile" is on in the drop-down and the centre is not fixed, Find Center runs twice.
3. If "mask spots before Get Profile" is on and Manual mode is off, Mask Spots runs.
4. `SetMask` → `Ring.SetMask` (§2).
5. `Ring.GetProfile(IP)` (Concentric → `GetConcenrticProfile`, Radial → `GetRadialProfile`). For sequential images this repeats for each target frame; for HDF5 the wavelength is replaced by the frame energy.
6. If Kα2 removal is on: `DiffractionProfile2.RemoveKalpha2` (§6.3).
7. Saving (After "Get Profile" tab) and sending to PDIndexer.

## 2. Pixels used (masks)

`Ring.SetMask(OmitSpots, OmitThresholdMin, OmitThresholdMax)`:

$$
\text{IsValid} = \neg\big(\text{OutsideRegion} \lor \text{OutsideProperty} \lor (\text{OmitSpots}\land\text{Spots}) \lor (\text{OmitMin}\land I<n_\text{min}) \lor (\text{OmitMax}\land I>n_\text{max})\big)
$$

- OutsideRegion (`Ring.SetInsideArea`, calcRegion/calcEdge): outside the Integral Region Rectangle (band) / Sector, plus Edge pixels from each image border if enabled.
- OutsideProperty (`Ring.SetInsideArea`, calcProperty): the 2θ of the pixel **centre** is outside the integration range: [Start, End] for Concentric, [Radius − Range, Radius + Range] for Radial (Angle). The test compares $\cos^2 2\theta$ computed directly from $\mathbf r$ (no central projection).
- Thresholds (`FormProperty.cs`): Under means $I < n_\text{min}$, Over means $I > n_\text{max}$.

## 3. Concentric integration: Angle / d-spacing modes

Code: `Ring.GetConcenrticProfile` → `Ring.GetProfileThreadWithTiltCorrectionNew` (new implementation since 2020-04-30).

### 3.1 Bins

In Angle mode there are $N = \lfloor(\text{End}-\text{Start})/\Delta\rfloor + 1$ bins; bin $k$ has

$$
\text{edges}:\ 2\theta^{\pm}_k = \text{Start} + (k\pm\tfrac12)\Delta,\qquad \text{output}:\ 2\theta_k = \text{Start} + k\Delta
$$

(`R2[i] = (i + 0.5) * StepAngle + StartAngle` is the upper edge). In d-spacing mode the edges are $d^{\pm}_k = d_\text{Start} + (k\pm\tfrac12)\Delta d$, converted to angles by $2\theta = 2\arcsin(\lambda/2d)$ and processed the same way; the output is $d_k = d_\text{Start} + k\Delta d$ (Å) in ascending d (descending 2θ).

Because the mask is tested at pixel centres (§2), the first and last bins receive pixels from only half of their range (the mean is barely biased, but statistics are poorer).

### 3.2 Pixel splitting (area distribution)

For each valid pixel:

1. From the centre $\mathbf r$ and the in-plane half-pixel vectors $\mathbf s_x = R(p_x/2, 0, 0)^{\mathsf T}$, $\mathbf s_y = R(p_y\tan\xi/2,\ p_y/2,\ 0)^{\mathsf T}$, two corners $\mathbf r + (\mathbf s_x\pm\mathbf s_y)$ are built; the other two are taken as point reflections about the centre. If the spherical correction is on, the centre is first mapped as in 03-geometry §5 (the corners only follow by the same translation).
2. The corners are centrally projected (**gnomonic projection**) onto the plane perpendicular to the pixel direction at distance $L$ from the sample, giving local coordinates $(u, v)$; $u$ points to increasing 2θ in the meridional plane (containing $Z$ and the pixel centre), $v$ is azimuthal:
   $$
   u = L\tan\delta,\qquad v = \frac{(\mathbf a\cdot\hat{\mathbf e}_\chi)\,l\,L}{\mathbf a\cdot\mathbf r}
   $$
   ($\mathbf a$: corner, $\delta$: angle between the corner projected onto the meridional plane and the pixel centre, $\hat{\mathbf e}_\chi = (-Y, X, 0)/q$).
3. Each 2θ edge $2\theta^+_k$ is approximated in this local frame by the line $u = L\tan(2\theta^+_k - 2\theta)$; the pixel polygon is cut successively and the area $A_k$ in each bin computed (shoelace formula, `Ring.getArea`). With azimuthal division (§7) it is cut further by $v = (q/l)\,L\tan(\chi_m - \chi)$.

The area on this tangent plane is $A \approx L^2\,\Omega$ ($\Omega$: solid angle subtended at the sample).

### 3.3 Normalization

With pixel intensity $I_p$, total area $A_p$ and partial area $A_{p,k}$ in bin $k$:

$$
S_k = \sum_p I_p\,\frac{A_{p,k}}{A_p},\qquad
W_k = \frac{1}{p_x p_y}\sum_p A_{p,k},\qquad
I_k = \frac{S_k}{W_k},\qquad
\sigma_k = \frac{I_k}{\sqrt{S_k}}
$$

(`profile[k] += area * intensityPerArea`, `pixels[k] += area`, finally `pixels *= 1/(pixSizeX*pixSizeY)`; in `GetConcenrticProfile`, `temp = ProfileIntensity / ContributedPixels`, `Err = temp / Sqrt(ProfileIntensity)`).

$W_k$ counts the solid angle contributing to the bin in units of $\Omega_0 = p_xp_y/L^2$, the solid angle of one pixel at the direct spot of an untilted detector. So $I_k$ is **intensity per unit solid angle (expressed per $\Omega_0$)**: the flat-detector solid-angle/obliquity factor ($\cos^3 2\theta$ without tilt) is corrected implicitly by this normalization.

- The old implementation (commented out) used area fractions and divided by $\cos^3 2\theta$; a comment says it was changed on 2016-12-27 (`GetConcenrticProfile`).
- $\sigma_k$ is the relative Poisson error of $S_k$, treated as counts, times $I_k$. It is meaningless if $I_p$ are not photon counts (PSL values, after background subtraction or polarization correction, etc.).
- There is no correction for detector absorption efficiency, sensor thickness or air absorption.

## 4. Concentric integration: Length mode

Code: `Ring.GetConcenrticProfile` → `Ring.GetProfileThreadWithTiltCorrection` (old implementation). In the current UI the Length radio button `radioButtonConcentricLength` is `Visible=False`, so it cannot be selected (Find Parameter uses this mode internally).

- The pixel corners are mapped to the projection plane $(X', Y')$ (spherical correction as in 03-geometry §5(b)). The intersections of the boundary circles $R_k = \text{Start} + (k+\tfrac12)\Delta$ (radius $\sqrt{X'^2+Y'^2}$) with the quadrilateral edges are solved analytically, and the intensity is distributed by area, with arcs replaced by chords.
- Normalization: $I_k = \sum_p I_p A_{p,k}/A_p \big/ \sum_p A_{p,k}/A_p$, i.e. **mean per pixel (area fraction)**. There is no solid-angle normalization, unlike the Angle/d modes.
- The horizontal axis is the radius on the projection plane [mm] ($= L\tan 2\theta$).

## 5. Gandolfi mode

Code: `Ring.GetProfileGandlfi` (Angle mode only). Pixel corners on the cylinder are mapped to real space; in each pixel's local frame, the intersections of the constant-2θ curve with the lines $v = d$ are found from a quadratic, and the intensity is distributed by area. Normalization: $\sum I A_{p,k}/A_p \big/ \sum A_{p,k}$ (per area). Bin edges are $(i-\tfrac12)\Delta + \text{Start}$; output $\text{Start} + i\Delta$.

## 6. Corrections

### 6.1 Linear polarization (Correct linear polarization)

Code: `Ring.CorrectPolarization(rotate, intensity)`. With the projected coordinates $(x, y) = (X', Y')$ and $r^2 = x^2+y^2$, for polarization along the image horizontal (`rotate` 0 or 2):

$$
I_\text{corr} = \frac{I}{c},\qquad c = \frac{2\,(y^2 + L^2)}{x^2 + y^2 + 2L^2}
= \frac{\sin^2\chi + \cos^2\chi\cos^2 2\theta}{\tfrac12(1+\cos^2 2\theta)}
$$

($\chi$ measured from the image horizontal). For vertical polarization (`rotate` 1 or 3), $x \leftrightarrow y$. Full linear polarization (degree 1) is assumed and the pattern is converted to the unpolarized equivalent. This is mathematically identical to the formula in `2-property-windows.md`.

- The `rotate` argument is supplied differently by the callers:
  - Normal display/integration path (`FormMain.FlipRotate_Pollalization_Background`): 0 (horizontal) if the χ reference on Miscellaneous is Right/Left, 1 (vertical) if Top/Bottom.
  - Sequential-image save path (`FormMain.cs` around lines 2107 and 2249): passes the Option→Rotate combo index `toolStripComboBoxRotate.SelectedIndex` (a rotation). See Implementation questions.
- "Azimuth χ (defined on the Miscellaneous tab)" in the current manual should be restricted to: only the χ **reference direction** (= polarization direction) matters, the sense of rotation does not.
- The extra factor in the comment "20190906追記 … / cos(2th)" is not implemented.
- Tilt φ, τ and ξ enter through the central projection; the spherical correction does not.

### 6.2 Background image

Item 2 in §1. "Set the current image as background" on the Background Option tab (tab 8; there is no Property-menu item for it) stores a copy of `Ring.IntensityOriginal` (**raw data before flip/rotate**) as $B$, whereas the subtraction is applied to the array **after** flip/rotate (see Implementation questions). Registering it does not trigger a recomputation; it takes effect on the next reload, coefficient change, flip, etc. The **Background** toolbar button is `Enabled=False` in the resx (always disabled); its handler `toolStripSplitButtonBackground_ButtonClick` only checks the upper/lower values and redraws; they are not used in any calculation.

### 6.3 Kα2 removal (Remove Kα2)

UI: "Remove Kα2 (if Kα1 line is selected)" on the After "Get Profile" tab (`FormProperty.checkBoxTest`) and the ratio "Kα2/Kα1" (`numericBoxTest`, default 0.5). **It is on by default in the Designer** and not persisted (absent from the `rw(...)` list in `FormMain.cs`), so it is on again at every start. If the X-ray element number is > 10 and the line is Kα1, `DiffractionProfile2.RemoveKalpha2` is applied after Get Profile:

$$
I_1(2\theta_i) = I(2\theta_i) - \rho_{21}\,I_1(2\theta'_i),\qquad
2\theta'_i = 2\arcsin\!\Big(\frac{\lambda_1}{\lambda_2}\sin\theta_i\Big)
$$

(Rachinger-type recursion using already-corrected values with linear interpolation, `GetValue(theta, 2, 1)`. If $2\theta'_i$ is below the profile start, $\tfrac23 I(2\theta_0)\,\rho_{21}$ is subtracted.) The formula assumes the horizontal axis is 2θ in degrees, but **the caller (`FormMain.GetProfile`) applies it regardless of Concentric/Radial and Angle/d/Length**; see Implementation questions.

### 6.4 Solid angle and obliquity

There is no separate correction. In the Angle/d modes the normalization of §3.3 yields intensity per solid angle and so includes it implicitly. It is absent from the Length, Gandolfi and Radial modes.

### 6.5 Output pattern (Bragg - Brentano / Debye - Scherrer)

The radio-button value (tooltip: "Apply Bragg-Brentano … intensity convention to the output 1D pattern") is copied to `IP.IsBraggBrentanoMode` but **never read by any calculation** (grep finds only the assignment). The choice currently has no effect.

## 7. Azimuthal Division Analysis

With `toolStripMenuItemAzimuthalDivisionAnalysis` checked in the Get Profile drop-down (LPO branch of `FormMain.GetProfile`):

1. The Integral Region is forced to Rectangle/Full and the whole profile (name suffix ` -whole`) is computed.
2. `Ring.GetConcenrticProfilesBySector(IP, M)` is called with $M$ = `toolStripComboBoxAzimuthalDivisionNumber`. Azimuth bin $m$ covers $\chi_\text{raw}\in[(2m-1)\pi/M,\ (2m+1)\pi/M]$ (centre $2\pi m/M$); pixels are cut in both 2θ and χ as in §3.2. Name suffix: ` -{m·360/M:000}` (centre angle in degrees).
3. χ is fixed to $\chi_\text{raw}$ (0 at image right, clockwise on screen); the Miscellaneous χ definition is not applied.
4. The horizontal axis is always 2θ (Angle); d and Length settings are ignored (`GetConcenrticProfilesBySector` uses only `StartAngle/EndAngle/StepAngle`).

## 8. Radial integration (cake)

Code: `Ring.GetRadialProfile`.

- Radius range on the projection plane: $[L\tan(2\theta_c - \Delta),\ L\tan(2\theta_c + \Delta)]$ (Angle; $\Delta$ = Donut width, a half width); in d-spacing mode $d_c \pm \Delta d$ converted to angles.
- Azimuth step $\Delta\chi$ (Sector angle step); $\mathrm{round}(360/\Delta\chi)$ bins; bin $m$ = $[(m-\tfrac12)\Delta\chi, (m+\tfrac12)\Delta\chi]$.
- Pixel corners are projected; each pixel is clipped by two radial lines and by two lines perpendicular to the bin-centre direction at the inner/outer radius (arcs replaced by straight lines), and the intensity is distributed by area fraction.
- The value is a **sum** ($\sum_p I_p A_{p,m}/A_p$), not normalized by the contributing area; the unit differs from Concentric.
- The χ definition is applied to the output axis: for Counterclockwise the array is reversed, then shifted by −90/−180/−270° depending on the reference direction and wrapped into [0, 360).

## 9. Unrolled image

Code: `FormMain.toolStripSplitButtonUnroll_CheckChanged` → `Ring.GetUnrolledImageArray(IP, chiDivision, start, end, step)`. The horizontal axis is 2θ (Start/End/Step on the Unrolled Image Option tab are read **as degrees**); the vertical axis divides $\chi_\text{raw}$ into `numericUpDownUnrollChiDivision` parts (default 720 = image height). The horizontal unit radio buttons (Length/Angle/d-spacing) are not read by the code. Cells are computed with the same splitting as §3.2–3.3 (value $S/W$, mean per solid angle). If "send the unrolled image to PDIndexer" (`checkBoxSendUnrolledImageToPDIndexer`) is on in After "Get Profile", the same computation with 360 χ divisions is attached to the profile.

## 10. Image-processing algorithms

### 10.1 Find Center

`Ring.FindCenter(IP, radius, mask)`: takes $(2r+1)^2$ pixels around the current centre ($r$ = Search area, default 8 pix), normalizes them by their sum and fits a 2D pseudo-Voigt

$$
F = \frac{2A}{\pi H}\Big[\frac{\eta}{1+4s} + (1-\eta)\sqrt{\pi\ln 2}\,e^{-4\ln 2\,s}\Big] + B_1 + B_2(X-x) + B_3(Y-y),\quad
s = \frac{(X-x)^2 + C(Y-y)^2}{H^2}
$$

with a 9-parameter Levenberg–Marquardt (≤ 300 iterations, $\lambda<10^9$); $(X, Y)$ becomes the new centre (`FittingPeak.FitPeakAsPseudoVoigtByMarcal2D`, `Crystallography/PeakSearch.cs`). With "Exclude masked pixels" on, masked pixels are set to NaN. Nothing happens if the centre is within $r+2$ pixels of the image edge.

**Centre from a ring** (Find Center while the Draw Ring window is shown): second half of `FormMain.toolStripSplitButtonFindCenter_ButtonClick`. Around the Draw Ring 2θ, a Concentric Angle integration over ±5×(Peak fitting range) is done in 18 sectors of 20°, and a pseudo-Voigt is fitted to each to get the peak 2θ. A conic $ax^2+bxy+cy^2+dx+ey=10^6$ is least-squares fitted to the points $\big(L\tan 2\theta\,\sin\alpha,\ -L\tan 2\theta\,\cos\alpha\big)$ ($\alpha$ = sector centre angle) (`Geometry.GetEllipseCenter`; aborted with fewer than 8 points), and the centre is moved to the ellipse centre. This is repeated 3 times.

### 10.2 Mask Spots

`Ring.FindSpots(IP, k)`: pixels are grouped by ring number $r_n$ = projected radius rounded in units of $p_x$; in each ring the mean $\bar I$ and unbiased SD $s$ (excluding existing spots and out-of-region pixels) are computed; pixels with $I > \bar I + k s$ and their neighbours with $\Delta i^2+\Delta j^2 < 9$ are added to the spots (existing spots are kept). $k$ = Deviation (`numericUpDownFindSpotsDeviation`, default 5). Dark pixels are not flagged.

### 10.3 Circumferential Blur

`Ring.CircumferentialBlur(θ)`: assumes square pixels and no tilt. Using the distance $r$ and azimuth $\phi$ of each pixel from the current direct spot (pixel units), each pixel is replaced by the normalized weighted mean of its neighbours with weight $\exp\{-(\Delta\phi/\theta)^2 - (\Delta r)^2/0.25\}$ ($|\Delta r|<1.5$, $|\Delta\phi|<3\theta$, distance $< r\sin3\theta$). It overwrites `Ring.Intensity` (presumably undone only by reloading or by a recomputation such as flip/rotate; to confirm).

## Items to confirm

1. Is the difference between "per solid angle" normalization (Angle/d) and "per pixel / sum" (Length/Gandolfi/Radial) intended? How should the manual present it?
2. Is it acceptable that the first and last bins are only half filled because of the pixel-centre mask?
3. May the assumption behind $\sigma_k = I_k/\sqrt{S_k}$ (counts) be stated?
4. Is Kα2 removal being on by default and not persisted intended?
5. Will Bragg-Brentano / Debye-Scherrer be implemented, or removed from the UI?
6. Is it intended that the background is registered before flip/rotate but subtracted after it (harmless while flip/rotate are 0)?
7. How to undo Circumferential Blur.
8. For azimuthal division and Unroll, is it enough to state "χ is fixed: 0 at image right, clockwise"?
