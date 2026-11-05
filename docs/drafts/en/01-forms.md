This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# List of forms and chapter structure (based on the implementation)

This lists every window (form) of IPAnalyzer, with how it is opened, its role, and the corresponding page of the existing manual. UI strings were taken from `*.resx` (English) / `*.ja.resx` (Japanese), and for forms with Localizable=false from the runtime translations in `IPAnalyzer/IPAnalyzerLocalizationData.cs`. Only the English UI strings are given here.

All forms inherit from `Crystallography.Controls.FormBase`; **F1** opens the corresponding page (`HelpPage`) of the online manual (English: `https://seto77.github.io/IPAnalyzer/<page>/`, other languages: `/IPAnalyzer/<lang>/<page>/`; `FormMain` constructor). The title carries the suffix "(F1: Help)".

## 1. List

| Form (class) | Title | How to open | Role | HelpPage |
|---|---|---|---|---|
| `FormMain` | IPAnalyzer | At startup | Image display, operations, menus | 1-main-window |
| `FormProperty` | Property | Shown at startup. Property menu (opens each tab directly), Option in each drop-down | All settings: source, detector, integration conditions, etc. (9 tabs) | 2-property-windows |
| `FormParameterOption` | Save checked parameters / Read checked parameters (overwritten at runtime) | File → Read parameter / Save parameter, dropping a `.prm` while holding Ctrl | Selects which items are read/written in a `.prm` | 2-property-windows |
| `FormAutoProcedure` | Auto Procedure | Right toolbar Auto procedure | Folder monitoring and automatic processing after loading | 3-tools |
| `FormDrawRing` | Draw Ring | Right toolbar Draw ring | Overlays a ring at a given R, 2θ or d. While shown, Find Center becomes ring-based | 3-tools |
| `FormFindParameter` | Find Parameter (in the Japanese UI the title is 「パラメータ校正 (代数的)」, "algebraic") | Right toolbar Find parameter (geometrically) | Geometric calibration with a standard sample (Primary/Secondary) | 4-procedures |
| `FormFindParameterBruteForce` | Find Parameters (brute force) | Right toolbar Find parameter (brute force) | Brute-force calibration using the current image | 6-find-parameter |
| `FormFindParameterGeometry` | Schematic Diagram | Schematic diagram in Find Parameter | Schematic diagram of the geometry (image only) | appendix/a1-geometry |
| `FormFindParameterOption1` | Option | When a multi-frame image is opened in Find Parameter | Specifies the frame number to use (Select Image No.) | 3-tools |
| `FormCrystal` | Crystal | Set crystal in Find Parameter | Editing the standard crystal (CrystalControl; can open the symmetry information window) | — |
| `FormSequentialImage` | Sequential Image Option | Right toolbar Sequential image (enabled for 2 or more frames) | Frame selection, averaging, summation, targets of batch processing | 3-tools |
| `FormSaveImage` | Save IPA Image | File → Save image → as IPA format | Saving an IPA image with tilt and distortion removed | 3-tools |
| `FormBlurAngle` | Blur Angle | Right toolbar Circumferential blur (modal) | Input of the circumferential blur angle | 3-tools |
| `FormCalibrateIntensity` | (no title) | **Tool → Calibrate Raxis Image** | Optimizes an intensity conversion table from two R-AXIS `.stl` images of the same size (the result is only shown as a graph) | 3-tools |
| `FormCalibrateRAxisImage` | — | **Not created from anywhere** (unreachable) | Unfinished | 3-tools |
| `FormAboutMe` | About Me | **Not created from anywhere** | Old version information | — |
| `FormMacro` (Crystallography.Controls) | Macro | Macro → Editor | Editing and running macros (API in `IPAnalyzer/Macro.cs`) | 5-macro |
| `CommonDialog` (Crystallography.Controls) | — | Startup splash, Help → Hint / License / Version history | Startup progress, hints, license, history | — |
| `FormPDF` (Crystallography.Controls) | — | Help → Help | Displays the bundled PDF (`<exe>/doc/IPAnalyzerManual(ja|en).pdf`) | — |

The handler of the **Intensity table** button on the right toolbar is commented out; pressing it opens nothing (around line 3794 of `FormMain.cs`).

## 2. Layout of the main window

### 2.1 Menu (`menuStrip`)

| Menu | Items | Action (handler) |
|---|---|---|
| File | Read image | `readImageToolStripMenuItem_Click` |
| | Save image → as TIFF format, as PNG format (preserve brightness, contrast, masked area), as CSV format, as IPA format (original format) | `saveImageAsTiff` / `saveImageAsPng` / `saveImageAsCSV` / `FormSaveImage` |
| | Read parameter, Save parameter | The items are chosen each time in `FormParameterOption` (only Camera mode and Gandolfi Radius are checked by default) |
| | Read mask, Save mask, Clear mask | `.mas` |
| | Close | |
| Tool | Reset Frequency Profile | Rebuilds the intensity-frequency histogram with the default range (`SetFrequencyProfile`) |
| | Calibrate Raxis Image | Opens `FormCalibrateIntensity` |
| Property | Wave Source, Imaging Plate Condition, Integral Region, Integral Property, Manual Mask Mode, After "Get Profile", Unrolled Image Option, Miscellaneous | Opens tabs 0–7 of `FormProperty`. There is no item for tab 8 (Background Option) |
| Option | ToolTip | Only saved in the registry; does not toggle tooltip display |
| | Flip → Horizontally, Vertically; Rotate (0/90/180/270 deg) | The array used for calculation also changes (`FlipRotate_Pollalization_Background`). Remembered per image type |
| | Ngen Compile | No handler (does nothing) |
| | Clear registry (check and restart) | If checked, the registry is deleted instead of written at exit. The user restarts manually |
| Language | English, 日本語, Deutsch, Français, Español, Português, Italiano, Русский, 简体中文, 繁體中文, 한국어 | Generated at runtime (`PopulateLanguageMenu`). Selecting one restarts after confirmation |
| Macro | Editor, names of saved macros | `FormMacro`, `SetMacroToMenu` |
| Help | Program Updates (hidden in the portable build), Hint, License, Version history, Help (bundled PDF) | |

### 2.2 Upper operation toolbar (`toolStrip2`)

| Button | Action | Drop-down |
|---|---|---|
| Background | **Always disabled** (`Enabled=False` in resx) | Reference image (tries to open the nonexistent tab number 9) |
| Find Center | Center detection by 2D pseudo-Voigt (ring-based while Draw Ring is shown) | Option (Miscellaneous tab), Find center based on the ring (hidden, disabled) |
| Fix Center | Fixes the center (stops Find Center and center setting by double-click / middle-click) | |
| Mask Spots | Masks pixels exceeding mean + k·SD of each concentric ring | Clear mask, Mask all area, Invert mask, Manual Mode (display only), Option (Mask Option tab) |
| Manual Mode | Toggles manual mask mode. Turning it on hides the Property window | Mask size combo (2–512, default 64; shown only for the Spot shape) |
| Get Profile | Converts to a 1D profile | Integral Property, Concentric Integration, Radial integration, Integral Region, Find Center before Get Profile (default on), Mask Spots before Get Profile (default off), Send profile to PDIndexer (default on), with unrolled image, Azimuthal Division Analysis (number of divisions 6–360, default 60), Get Profiles for all sequential images, Get Profiles for selected images |

### 2.3 Right vertical toolbar (`toolStrip1`)

Intensity table (no function), Auto procedure, Draw ring, Find parameter (geometrically), Find parameter (brute force), Unroll image, Circumferential blur, Sequential image.

### 2.4 Other areas

- Image Information: file name, size, dynamic range, maximum / sum / average intensity, header comments.
- Thumbnail: Near center (default), Whole image.
- Display adjustment: Gradient (Positive Film / Negative Film), Brightness scale (Log Scale / Liner Scale), Color scale (Gray / Cold-Warm / Spectrum / Fire), Scale line (None / Coarse / Medium / Fine), Auto Contrast (mean ∓ 2σ of all pixels), Reset Contrast (0–65535), magnification buttons ×1 to ×1/16.
- Mouse position readout: Int., R(mm), 2θ, d, c (= χ), Real Coord.(mm), Image Coord.(pix).
- Bottom tabs: Frequency of Intensity, Converted Profile, Statistical Information (range specified with Ctrl + right drag).

## 3. Tabs of the Property window

| No. | Tab | Main contents |
|---|---|---|
| 0 | Wave source | Source, element, line, wavelength; linear polarization correction |
| 1 | Detector condition | Coordinate reference (Direct spot / Foot), detector type (Flat panel / Gandolfi), direct spot position, Camera Length 1/2, pixel shape, Gandolfi radius, spherical correction, tilt φ, τ |
| 2 | Integral Region | Excluded pixels (mask, intensity thresholds, edge), Rectangle (direction, band width, angle, centrosymmetric) / Sector (start and end angles) |
| 3 | Integral Property | Concentric (Angle / d-spacing; Length is hidden), Output pattern (no effect), Radial (Donut radius / width, Sector angle step) |
| 4 | Mask Option | Mask all, unmask, invert; half mask; manual mask (Spot / Circle / Rectangle / Polygon / Spline); mask take-over; spot detection threshold |
| 5 | After "Get Profile" | Kα2 removal (default on), sending to PDIndexer (default on) and sending the unrolled image as well, saving profiles (default off; format, destination, one file / separate files) |
| 6 | Unrolled Image Option | Number of vertical divisions (default 720), horizontal Start/End/Step (only 2θ is effective) |
| 7 | Miscellaneous | Scale lines, image name display, keeping contrast and display range on loading, definition of χ, center-detection settings |
| 8 | Background Option | Registering and clearing the background image, coefficient |

The meaning of the items on each tab is described in [02-operations.md](02-operations.md).

## 4. Proposed chapter structure (user manual)

Keep the existing chapter structure of `docs/src/<lang>/` (0 Overview to 6 Brute force, appendices A1–A5) and add the following:

1. In "1. Main window", add complete tables of shortcuts and mouse operations, and an explanation of the per-image-type parameter memory.
2. In "2. Property window", add Kα2 removal, saving options, the actual meaning of Unrolled, and `FormParameterOption`.
3. In "3. Tools", merge the Intensity table / R-AXIS calibration sections to match the implementation (Tool menu → `FormCalibrateIntensity`).
4. In "4. Practical procedures", add a procedure for azimuthal division analysis, and correct the brute-force procedure to a single-image procedure.
5. Revise appendices A1–A3 with the contents of [03-geometry.md](03-geometry.md), [04-calibration.md](04-calibration.md) and [05-integration.md](05-integration.md), and create a new appendix "A6. Supported file formats" ([06-file-formats.md](06-file-formats.md)).

## Items to confirm

1. Are the Intensity table button, the Background button, Ngen Compile, ToolTip, `FormCalibrateRAxisImage` and `FormAboutMe` going to be removed from the UI and code, or should the manual describe them as "not implemented"?
2. Is the English PDF opened by Help → Help (`IPAnalyzerManual(en).pdf`) included in the distribution? (The repository contains only the ja PDF and an en docx for a different product.)
3. Unify the name of the geometric calibration (in the Japanese UI, the toolbar says 「(幾何学的)」 "geometrically" while the form title says 「(代数的)」 "algebraic").
