<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->
<!-- 261124Cl: Added a step to check the integration settings; corrected the peak-count rule, the sign of the camera-length difference and the transfer button for geometric calibration, the brute-force inputs (one standard image, Initial step / Search range, automatic transfer) and the order of the Auto procedure steps. -->

# Procedures

This page shows the flow of typical tasks. For descriptions of the individual tools, see [Tools](3-tools.md).

## Basic flow (concentric integration)

1. **Load an image**: File → Read image (or drag and drop).
2. **Set the source**: set the element/transition or the wavelength under **Wave source** in the properties.
3. **Set the detector condition**: set the camera length, pixel size, center position (approximate), and, if needed, the tilt φ, τ under **Detector condition**.
4. **Find the center**: detect the beam center automatically with **Find Center** on the toolbar (the search range is set on the Miscellaneous tab).
5. **Mask spots**: remove single-crystal reflections and the like with **Mask Spots**. If needed, mask manually with **Manual Mode**.
6. **Check the integration settings**: select the target region under **Integral Region**, and choose **Concentric integration** with the axis unit and **Start / End / Step** under **Integral Property**.
7. **Integrate the image**: obtain the profile with **Get Profile**. Saving and sending are configured on the **After "Get Profile"** tab (CSV save, send to PDIndexer, etc.).

For sequential images, select a frame in [Sequential image](3-tools.md) before steps 5–7. For per-azimuth analysis, use **Azimuthal Division Analysis** on the **Get Profile** dropdown (the rings are split into sectors and each sector is integrated), or **Radial integration** in **Integral Property** (an azimuth–intensity profile).

If the camera length, wavelength or tilt is unknown, first calibrate them from an image of a standard sample as described in the next section, apply the values, and then integrate the sample images.

## Parameter determination: geometric calibration with a standard sample (double cassette)

When the camera length or wavelength is unknown, optimize the geometric parameters from the diffraction rings of a standard material (CeO2 by default, etc.), using [Find Parameter (Geometric)](3-tools.md).

1. Load the **Primary image** (standard sample, at one camera length) with Open, find the center, and show the peaks with **Get Profile**.
2. Dragging a diffraction-line marker in the Profile View updates the camera-length estimate automatically.
3. Load the **Secondary image** (the same standard sample, at a different camera length) in the same way, and enter the **camera-length difference** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) (e.g. +20 if Primary is at 100 mm and Secondary at 120 mm). The Secondary image is optional; calibration also works with the Primary image alone.
4. In the **Peak List**, select the d-values of peaks that appear in both images (normally three or more per image; with two images, at least one must be common to both. Unless only the camera length is refined, **Refine!** does nothing with fewer than three).
5. Choose the parameters to optimize (wavelength, film distance, tilt, pixel size, pixel distortion, center position, spherical correction).
6. Run **Refine!**. It stops automatically after the number of repetitions set (12 by default). After checking the result, copy it to the main form with **Refined parameters => Main form**.

!!! note
    Using two images (a "double cassette") makes it easier to determine the camera length and the wavelength separately.

## Parameter determination: brute-force optimization (standard sample)

When geometric optimization struggles to converge, search the camera length, center position, tilt and, optionally, the wavelength exhaustively with [Find Parameter (Brute force)](3-tools.md). See [Find Parameter (brute force)](6-find-parameter.md) for a detailed walkthrough with screenshots.

1. Load one image of a standard sample in the main form, open Find parameter (brute force), and select the corresponding standard.
2. Roughly align the center position in the main form (Find Center helps).
3. Choose the items to optimize, and enter the step width **Initial step** (centered on the current value) and the number of steps on each side (**Search range**). For a flat detector, the pixel size is not a search target. See [Find Parameter (brute force)](6-find-parameter.md) for numerical examples.
4. Setting **Integral Region** to a slit (Rectangle) mode with a narrow band width helps suppress noise.
5. Start the search with **Optimize**. In each cycle, the combination with the smallest evaluation value R is adopted and written to the main-form parameters automatically.

## Automated processing (Auto Procedure)

Process images that arrive in a folder automatically, for example during an experiment. See [Tools](3-tools.md) for details.

1. Choose the watch folder with **Set**.
2. If needed, filter files by **number matching** (the number at the end of the filename) or by **keyword**.
3. Enable **After Loading Image, Execute "Auto"**, and choose from the list: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Finally, turn on **Automatically load new images** to start watching (it cannot be turned on without a folder; the number/keyword conditions in effect when watching starts are used). The sequence then runs automatically each time a matching image arrives.

## Scripted procedures (Python-based macros)

Processing with loops and conditionals can be written as a [macro](5-macro/index.md). The sample macros shown with **Show samples** in the macro editor are a good starting point.

- Load an image, set the source and detector (center, camera length, pixels), and fit the display.
- Set the concentric-integration conditions (start, end, step, unit), one-dimensionalize, and save as CSV.
- Batch-process several files, saving a CSV next to each image.
- Process a multi-frame image frame by frame.
- Split a Debye ring into N sectors and analyze the azimuthal dependence.
- Mask (clear all → mask spots → mask the beam-stop region → save the mask) and one-dimensionalize.
- Output azimuth vs. intensity with radial (cake) integration.
- Enable clipboard sending, one-dimensionalize, and call a named macro in PDIndexer (e.g. peak fitting).

Macros you write can be saved, called by name, and also run from Auto Procedure.
