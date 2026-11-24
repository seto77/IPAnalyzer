<!-- 261124Cl: Added. Q&A distilled from past enquiries (GitHub issues and e-mail): what users struggled with and what is easily misunderstood. Reflected from ja/7-qa.md. No personal or institutional information is included. -->
<!-- 261124Cl: Renamed labels to the actual English GUI (Save Profiles, Concentric integration (scattering angle dispersive), Radial integration (cake pattern), Correct linear polarization (i.e., linear polarized → unpolarized)); set the spherical-correction unit to the on-screen m⁻¹; added that a failed load keeps the previous image, that Azimuthal Division Analysis needs concentric integration with a 2θ axis, and that Auto procedure retries locked files. -->

# Q&A (Frequently asked questions)

This page collects the questions asked most often and the points that are easily misunderstood. Labels are those of the English interface. For questions not covered here, or to report a bug, please use [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Installation and start-up

### Only the property window appears; the main window cannot be seen

The main window is placed outside the screen.

1. Hover over the IPAnalyzer icon on the taskbar, right-click the thumbnail, choose **Move**, press an arrow key once, and then move the mouse.
2. If that does not help, quit IPAnalyzer, open the Registry Editor (regedit), delete `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer`, and start IPAnalyzer again (all settings return to their defaults).

### After updating, the old version is still running / IPAnalyzer no longer starts

Reinstall directly from the [latest release](https://github.com/seto77/IPAnalyzer/releases/latest). If the installation does not overwrite the old version, or the program does not start, uninstall it once from Windows Settings and then install again. If a new version has a problem, you can install an older version from the same releases page.

### I want to use it on a PC without administrator rights, or on Windows on Arm

- Without administrator rights, use the portable version (`IPAnalyzer-v.<version>.zip`), which needs no installation and bundles the .NET runtime.
- On Windows on Arm, use the arm64 installer (`IPAnalyzer-setup_arm64.msi`) or the portable version (`IPAnalyzer-v.<version>_arm64.zip`).

See [Installation in the Overview](0-overview.md#installation) for details.

### Loading many frames causes an error. How much memory is needed?

IPAnalyzer keeps the intensity of every pixel in double precision (8 bytes), whatever the original bit depth. For example, 5000 images of 1554×516 pixels need about 32 GB for the intensities alone. Handle data with many frames on a PC with enough memory, or process them in portions with a macro.

## Reading images

### My detector's files cannot be read

The format may not be supported yet. Please contact us through [Issues](https://github.com/seto77/IPAnalyzer/issues) or the author with an actual file (preferably one with a diffraction pattern, not only a dark image). The correctness of the intensities and the orientation of the image can only be checked with an image that shows a pattern. If loading fails, the previously loaded image stays, so you can continue working with it.

!!! note "When a raw image has the wrong width and height"
    For headerless raw files, the detector model and pixel count are inferred from the file size. The actual pixel count often differs from the catalogue value, so please send the file if the detection fails.

### After loading a parameter file and then opening an image, the parameters change

IPAnalyzer **remembers parameters such as camera length, wavelength and pixel size for each image format** and switches to those values when an image is opened. Therefore load the parameter file (`.prm`) **after opening the image**. Formats with different extensions are remembered separately even if their contents are the same.

### Do I need to flip or rotate every image again?

No. The **Option → Flip / Rotate** settings are also remembered per image format and are applied automatically the next time an image of the same format is opened. Flip and rotation also affect integration and image saving (the source file is not changed).

### How are files with several frames (`.his`, `.nxs`, multi-page TIFF, …) handled?

When such a file is loaded, the **Sequential image** window opens and you can select the frame to display. To integrate them together, use **Get Profiles for all sequential images** or **Get Profiles for selected images** on the **Get Profile** dropdown. See [Tools](3-tools.md#sequential-image) for details.

## Calibration

### When should I use Find parameter (geometrically) and when Find parameter (brute force)?

| | Geometrically | Brute force |
|---|---|---|
| Principle | Divides the image into sectors, finds the peak positions, and determines the center, tilt, etc. from the elliptical shapes and centers of the Debye rings | Varies the parameters step by step and looks for the combination that best matches the calculated and fitted peak positions |
| Suitable data | Rings visible almost all the way round (at least five directions) | Only part of the rings recorded, direct spot outside the image, spotty rings |
| Images | One, or two taken at different camera lengths | One |
| Caution | Accuracy drops or the refinement does not converge if the rings are not visible all round | Needs fairly good starting values; takes time |

See [Procedures](4-procedures.md) and [Find Parameter (brute force)](6-find-parameter.md) for the steps.

### What standard sample should I use for calibration?

A sample giving smooth (not spotty) Debye rings from fine grains, visible as fully round as possible, is suitable. About five or more rings is a guide. With only two complete rings a precise determination is difficult, and either the wavelength or the camera length should be known. For brute-force calibration, choose the standard from Au / CeO₂ / LaB₆ / Al₂O₃, or select **Other** and enter the lattice constants.

### The calibration does not converge / the center keeps drifting

- Fix the values you can trust (catalogue pixel size, known wavelength, etc.) and reduce the number of refined variables.
- First fit roughly with a few low-angle rings, then add the high-angle rings.
- A ring whose analysis failed can disturb the whole result. If one ring stands apart in the ring-center graph, remove it.
- If the fit fails when high-angle rings are included, restrict the peaks to those whose rings are still visible all round, widen the fitting range, and use fewer sectors.
- Enter starting values that are as correct as possible before starting.

### Can the camera length and wavelength be determined only if one of them is fixed?

With a standard whose lattice constants are accurately known, both can be determined even from a single image (from the ratios of the ring positions). However, **the camera length and the pixel size cannot be determined together from a single image**. Trust the catalogue pixel size and fix it. With two images whose camera-length difference is known (double-cassette method), the pixel size can also be refined.

### The direct spot is not recorded / lies outside the image

Enter the direct-spot position by hand and clear **Find Center before Get Profile** on the **Get Profile** dropdown. If the spot lies outside the image, negative coordinates are fine. Use brute-force calibration for such data.

### The center from Find Center differs by a few pixels from the calibrated center

They are determined differently. **Find Center** fits the direct spot near the current center with a two-dimensional pseudo-Voigt function. The calibration does not use the direct-spot intensity; it derives the center from the ellipse centers of several Debye rings. Once the tilt is determined correctly, the calibrated center can be used as it is. If the direct spot is saturated, show a circle on a Debye ring with **Draw ring** and press **Find Center**: the center is then determined from the ring.

### What is the spherical correction?

A correction for a detector that is bent like a sphere. Enter the inverse of the radius of curvature, 1/R, in m⁻¹ (shown as /m on screen). Use 0 for a flat detector. It helps when the high-angle rings do not match, for example with a large detector placed close to the sample.

### How do I convert tilt values from other software (such as PIP)?

PIP's (β, Φ) converts to IPAnalyzer's (φ, τ) = (270° − β, Φ). See the [Overview](0-overview.md#relationship-with-winpip) for the definitions.

## Integration and output

### The horizontal axis of the result looks wrong / the intensity looks almost constant

Check whether **Radial integration (cake pattern)** is selected on the **Integral Property** tab of the property window. In this mode the profile has the azimuth χ as its horizontal axis. The usual 2θ–intensity profile is obtained with **Concentric integration (scattering angle dispersive)**.

### I want to save the profile to a file without PDIndexer

On the **After "Get Profile"** tab of the property window, set the destination (same folder as the image / choose each time) and the format (PDI / CSV / TSV / GSAS) under **Save Profiles**. The profile is then saved every time you integrate.

### What is the third column of the CSV?

The counting error of the intensity, calculated from the square root of the summed pixel intensity in each step, treated as counts. The intensity in the second column is converted to the equivalent of Bragg–Brentano geometry, so it does not equal the square of the third column. PDIndexer can show it as error bars.

### The 2θ values in the CSV have only two decimal places. Is that the precision limit?

No. It only looks that way because the integration was set up with, for example, a start of 20.00° and a step of 0.01°. The calculation is done in double precision. The precision of the result is determined by the errors of the input parameters such as the camera length and wavelength.

### For sequential images, should I use Average or Summation?

The S/N ratio is the same either way. **Summation** gives a correct estimate of the errors, so it is recommended for analyses that use the errors, such as Rietveld refinement.

### I want to integrate for each azimuth (each sector)

Turn on **Azimuthal Division Analysis** on the **Get Profile** dropdown, set **Number of divisions**, and integrate. A whole profile (name ending in `-whole`) and one profile per sector (with the start angle appended, such as `-000`, `-010`, …) are created. This works only with **Concentric integration (scattering angle dispersive)** and the **Angle** (2θ) axis; with radial integration or a d-spacing axis a warning is shown and nothing is run. With too many divisions, the data sent to PDIndexer can become too large.

### I want a two-dimensional map of 2θ and the azimuth χ (unrolled image)

Use **Unroll image** on the toolbar. Set the range and step on the **Unrolled Image Option** tab of the property window. With **File → Save image**, TIFF keeps the calculated floating-point values, and PNG saves what is shown on screen.

### I want the sum or mean intensity of a rectangular part of the image

Select a rectangle by Ctrl + right-dragging on the image. The statistics appear on the **Statistical Information** tab at the bottom. For sequential images, the same region can be compared across frames.

### A dark image becomes brighter towards the high-angle edges

If **Correct linear polarization (i.e., linear polarized → unpolarized)** is on under **Wave source** in the property window, the correction is also applied to signals that do not come from X-rays (dark current, electronic noise), and the high-angle side becomes brighter. Turn it off for dark images.

### I want to subtract a dark (background) image

On the **Background Option** tab of the property window, register the current image as the background and set the coefficient. From then on it is subtracted automatically from images of the same size. See [Property windows](2-property-windows.md) for details.

## Batch processing and macros

### I want to integrate many files at once

**Get Profiles for all sequential images** is for several frames contained in one file. To process several files, use a [macro](5-macro/index.md). The [examples](5-macro/2-examples.md) include one that integrates the selected files in turn and saves CSV files. Before running it, open one image and load the parameter file (see [the parameter memory](#after-loading-a-parameter-file-and-then-opening-an-image-the-parameters-change)).

### I want to call a frequently used macro from the menu

Give the macro a name and add it in the macro editor; it can then be called from the **Macro** menu of the main window.

### I want to integrate images as they arrive during a measurement

Watch the folder with [Auto procedure](3-tools.md#auto-procedure). Files still being written are read after writing has finished; a file that is still locked after about 50 s is retried in later scans and given up 10 minutes after it was first found. If reading fails for a folder on the network, save to the measurement PC's local disk and watch that folder.

## Reporting a bug

### What should I send with a bug report?

The problem often cannot be reproduced in the author's environment, so please attach:

- the parameter file at that time (**File → Save parameter**),
- the image file with which the problem occurred, and
- the error message (a screenshot is fine) and the IPAnalyzer version.

Please report through [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Common misunderstandings

| Assumption | Actually |
|---|---|
| Load the parameter file first, then open the image | Opening an image switches to the values remembered for its format. Open the image first, then load the parameter file |
| **Get Profiles for all sequential images** processes several files at once | It is for several frames in one file. Use a macro for several files |
| PDIndexer is needed to save a profile | IPAnalyzer alone can save to a file (After "Get Profile" tab) |
| The third CSV column is another profile | It is the counting error of the intensity |
| Summation improves the S/N | The S/N is the same as for Average; only the error estimate differs |
| The camera length and pixel size can both be determined from one image | Not together from one image; fix the pixel size at its catalogue value |
| Flip and rotation only change the display | They also affect integration and image saving |
| Sending to PDIndexer applies a Lorentz-polarization correction to the profile | PDIndexer considers polarization only for the intensities of the calculated diffraction lines; the profile itself is not modified |
