This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# Operating procedures and settings of the main functions (based on the implementation)

UI strings are given in English. Default values are the Designer values (for items saved in the registry, the previous value applies from the second run onward). For details of the calculations see [03-geometry.md](03-geometry.md), [04-calibration.md](04-calibration.md), [05-integration.md](05-integration.md); for formats see [06-file-formats.md](06-file-formats.md).

## 1. Loading an image

1. File → Read image, or drag and drop one file onto the window (dropping a folder loads its first file). Ctrl+←/→ loads the previous/next file in the same folder.
2. On loading, **the full set of parameters last used for that image type** (detector geometry, center, camera length, pixel size and ξ, φ and τ, Gandolfi radius, source, flip/rotation) is restored automatically (`FormProperty.SetParameterFromImageType`). IPA images use the header values; DM3/DM4 replace the values only when the header values differ by 20 % or more. This is why the parameters "jump" when the image type changes.
3. The mask follows Take over mask setting in Mask Option: None, Take over the current mask state (default), Take over the mask file (only when the pixel count is the same).
4. For images with the extension tif whose minimum is ≤ 0, negative pixels are masked automatically.
5. Images with 2 or more frames enter sequential mode, and Sequential image on the right toolbar becomes enabled (§8).
6. If "Once the new image is loaded, perform the following sequence" in Auto Procedure is on, the automatic processing also runs when an image is loaded manually.

## 2. Adjusting the display

- Gradient, Brightness scale (Log Scale / Liner Scale), Color scale (Gray, Cold-Warm, Spectrum, Fire), Scale line (None to Fine; color, width and labels in Scale line options in Miscellaneous).
- Auto Contrast = mean ∓ 2σ of all pixels. Reset Contrast = 0–65535. It can also be adjusted by dragging the lines in the intensity-frequency graph (bottom tab).
- Magnification buttons ×1 to ×1/16; the wheel zooms ×2 / ×0.5 (about the cursor position). Left or middle drag pans, right drag zooms to a rectangle, right click zooms out.
- Keeping on load (Image loading options in Miscellaneous): Maintain image contrast, Maintain display range (**zoom/pan range**, not intensity range). Both are on by default.
- Option → Flip / Rotate **also changes the array used for calculation** (the file is not modified).
- Pixel colors: red = above upper threshold, blue = below lower threshold, cyan = mask, green = outside the Integral Region, magenta = outside the angle range of the Integral Property, yellow = polygon/spline being created. The center is a fuchsia ×.

## 3. Setting the source and detector (Property tabs 0 and 1)

### Wave source

- Source (X-ray, electron, neutron); for X-rays the wavelength is filled in automatically from the element and line (Kα1 etc.), or the wavelength is entered directly (displayed in Å, nm internally).
- **Correct linear polarization** (default off): converts fully linearly polarized intensity to the unpolarized equivalent. The polarization direction is determined by the χ reference direction in Miscellaneous (Right/Left → horizontal, Top/Bottom → vertical).

### Detector condition

| Item | Meaning / unit | Default |
|---|---|---|
| Coordinates: Direct spot, Foot | Which pair (position and camera length) is the input; the other is computed automatically ($L_2 = L\cos\tau$ etc.). Foot is not available for Gandolfi | Direct spot |
| Detector type: Flat panel, Gandolfi | Plane or cylinder (cylinder axis along the image vertical) | Flat panel |
| Direct spot position X, Y | pix (pixel centers at integers) | 1500, 1500 |
| Camera Length 1 | Sample to direct spot (mm). All calculations use this value | 445 |
| Foot position, Camera Length 2 | Foot of the perpendicular from the sample to the detector plane, and its length | — |
| Pixel Shape: X, Y, ξ | mm, mm, °. $x_d = \Delta i\,p_x + \Delta j\,p_y\tan\xi$ | 0.1, 0.1, 0 |
| Gandolfi Radius | mm (shown only when Gandolfi is selected) | — |
| Spherical correction: Inverse of radius | m⁻¹ (divided by 1000 internally). Normally 0 | 0 |
| Tilt: φ, τ | °. φ is the azimuth of the tilt axis (clockwise from the image right), τ the rotation about that axis | 0, 0 |

## 4. Setting the integration region and conditions (Property tabs 2 and 3)

### Integral Region

- Exceptional pixels: Masked Spots (default on), Over intenstiy of (sic) (65535), Under intensity of (1), pixels from edges (default on, 5).
- Rectangle (default): Direction = Full, Top, Bottom, Right, Left, Vertical, Horizontal, Free. Top=270°, Bottom=90°, Right=0°, Left=180°; Vertical/Horizontal come with Both Side. With Free, Angle is specified. Band Width is the half-width of the band (pix, default 1500).
- Sector: Start Angle, End Angle (°, following the χ definition in Miscellaneous).

### Integral Property

- Concentric integration (default): Angle (°) or d-spacing (Å). Start, End, Step (defaults 1°, 30°, 0.01°; for d, 0.5, 5, 0.005 Å). The output is at bin centers Start + kΔ. Length is hidden in the UI.
- The choice of Output pattern: Bragg - Brentano / Debye - Scherrer **currently has no effect on the calculation** (Debye - Scherrer is shown disabled).
- Radial integration (cake pattern): Donut radius (center 2θ or d, default 20°), Donut width (**half-width**, default 0.1°), Sector angle step (azimuthal step, default 0.05°). In the Japanese UI the labels 「リング幅」 (ring width) and 「リング半径」 (ring radius) are swapped relative to the English ones.

## 5. Determining the center and masking

- **Find Center** (Ctrl+Shift+F): fits a 2D pseudo-Voigt within ±Search area (Miscellaneous, default 8 pix; not saved) around the current center. Exclude masked pixels excludes masked pixels. If pressed while the Draw Ring window is open with R set, the ellipse center is obtained from the peak positions of that ring in 18 directions (3 iterations, Peak fitting range (2θ) default 0.1°).
- Setting the center by hand: left double-click, or middle click (middle click also runs Find Center afterward). Ctrl+Shift+arrow moves it by one screen pixel. All of these are disabled while **Fix Center** is on.
- **Mask Spots** (Ctrl+Shift+S): for each concentric ring (1 pixel wide), pixels exceeding mean + k·SD and their surroundings within radius 3 pix are added to the mask. k = the value of Mask spots option (default 5). Dark pixels are not targeted.
- **Manual mask** (Manual Mode, Ctrl+Shift+M; shape in the Mask Option tab):
  - Spot: left click/drag masks, right unmasks (in the Japanese UI the label 「右/左クリック: 追加/削除」 has left and right reversed). Shape Circle / Rectangle; size is the half-width (2^n pix, default 64; changed with the wheel).
  - Circle: drag sets center and radius. Rectangle: drag the diagonal. Polygon: click to add vertices, double-click to finalize (left = mask, right = unmask). Spline curve: left adds a point, right deletes the nearest point, double-click finalizes (Line width default 5).
- Mask All, Unmask All, Invert mask, Half mask (Left/Top/Bottom/Right; added to the existing mask) in Mask Option.
- File → Save mask / Read mask saves to / reads from `.mas`.

## 6. Converting to a 1D profile (Get Profile)

1. Press Get Profile (Ctrl+Shift+G). By default Find Center is run twice beforehand (Find Center before Get Profile, default on; not run while Fix Center is on).
2. The result is shown in Converted Profile at the bottom.
3. After "Get Profile" tab:
   - **Remove Kα2 (if Kα1 line is selected)**: **default on** (not saved; on every time), Kα2/Kα1 = 0.5. If the X-ray Kα1 line is selected, the Kα2 component is subtracted from the output.
   - Send profile data to PDIndexer through Clipboard (default on), Send also Unrolled Image.
   - Save Profiles (default off): File format = PDI (`.pdi2`) / CSV (default) / TSV / GSAS (`.gsa`); Directory = At the same directory of the image (default) or At the chosen directory each time; Saving option = In one file (Excluding GSAS) or In separate files (default).
4. **Azimuthal division analysis**: turn on Azimuthal Division Analysis in the Get Profile drop-down, choose the number of divisions (default 60), then Get Profile. The Integral Region is switched to Rectangle/Full, and a whole profile (`-whole`) plus one profile per division (`-000`, `-006`, … being the angle of the azimuthal bin center) are produced. χ is fixed as clockwise from the image right, and the horizontal axis is 2θ only.
5. Circumferential (cake): select Radial integration in Integral Property and Get Profile. The output is the summed intensity versus χ (following the χ definition in Miscellaneous).

## 7. Unrolled image (Unroll)

Turning on Unroll image on the right toolbar builds an unrolled image from Start/End/Step in the Unrolled Image Option tab (interpreted as **degrees of 2θ**; the unit radio buttons have no effect) and the number of vertical divisions (default 720), and displays it in place of the image. Turning it off restores the original. File → Save image can save it as TIFF (float) / PNG (with scale) / CSV.

## 8. Multi-frame (Sequential Image Option)

- Select frames with the list or the track bar (Ctrl+←/→ also steps through them). If the energy in TIFF tag 60000 is present, the wavelength is updated when a single frame is selected.
- Multi selection → Average or Summation shows the per-pixel average or sum.
- Target(s) of "Get Profile": The selected image(s), Only the topmost image, All images irrespective of current selections (linked to the items in the Get Profile drop-down).

## 9. Calibration

See [04-calibration.md](04-calibration.md). Key points of the procedure:

- **Geometric calibration** (Find parameter (geometrically)): Open the Primary image → Get Profile → check 3 or more peaks in the Peak List → (optionally Open the Secondary image, enter the camera-length difference Δ → Get Profile) → choose the targets in Refined Parameter → Refine! (stops automatically after 12 cycles by default) → Refined parameters => Main form.
- **Brute-force calibration** (Find parameter (brute force)): load an image of the standard sample in the main window and roughly set the center → choose the standard sample (Au by default) → Get Profile → set the parameters to search and their Initial step / Search range → Optimize. The best values are written to the main window at each cycle.

## 10. Automatic processing (Auto Procedure)

1. Set the Directory to be monitored with Set (subfolders are also monitored).
2. Optionally, Pattern matching ($N \bmod$ divisor = / ≠ remainder for the trailing number $N$ of the file name; defaults 3, 2) and Keyowrd (a substring contained in the file name without extension; case-sensitive). If both are on, they are combined with AND.
3. Automatically load new images: monitors every 100 ms and detects new files **only when the number of files in the folder changes** (overwrites are not detected). Waits for the write to finish (lock released, size constant) before loading.
4. Once the new image is loaded, perform the following sequence: Auto contrast, Find center (twice), Mask spots, Get profile (only this is on by default), Execute macro (choose a macro). Not executed while the Find Parameter window is shown.

## 11. Saving and loading parameters

File → Save parameter / Read parameter shows the "Save/Read checked parameters" dialog each time to select the items (Wave propety, Camera mode, Camera length, Center position, Pixel shape, Tilt correction, Spherical correction, Gandolfi Radius, Integral Region, Integral Property; only Camera mode and Gandolfi Radius are checked by default). Dragging and dropping a `.prm` reads all items (with Ctrl held, the dialog is shown).

## 12. Other tools

- **Draw Ring**: enter one of R (mm), 2θ (°) or d (Å) and press Enter/OK. $2\theta = \arctan(R/L)$, $d = \lambda/2\sin\theta$. Left-dragging near the ring makes the radius follow.
- **Circumferential blur**: specify the angle (0.01–10°, default 1°). Rewrites the intensities in memory.
- **Save IPA Image**: Width/Height (default 1000; Keep Aspect Ratio makes width = height), Resolution (µm/pixel, default 100), Center position (default 500, 500). While shown, the output range is drawn on the image.
- **Calibrate Raxis Image** (Tool menu): open two `.stl` images of the same size and press Calibrate. It only optimizes the intensity conversion table and plots it; the result is neither applied nor saved.
- **Keys**: Ctrl+Shift+F (center), S (spots), G (1D profile), B (background; effectively nothing, since the button is disabled), M (manual mask), C (copies the displayed image, or the selected area when the statistics tab is active, to the clipboard).

## Items to confirm

1. Should Kα2 removal remain on by default? Should the manual give a strong warning about it?
2. May Band Width be described as "half-width (pix)"? (Judged from `wx = Band/sin` in `Ring.SetInsideArea`.)
3. For brute-force calibration, is any preprocessing recommended besides "roughly set the center" (e.g. setting the Integral Region)?
4. Is it intended that Auto Procedure does not detect overwritten files?
5. Until the application of Kα2 removal to d-spacing and Radial profiles (see Implementation questions) is fixed, how should the manual describe it?
