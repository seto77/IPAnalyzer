<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Procedures

This page shows the flow of typical tasks. For descriptions of the individual tools, see [Tools](3-tools.md).

## Basic flow (concentric integration)

1. **Load an image**: File → Read image (or drag and drop).
2. **Set the source**: set the element/transition or the wavelength under **Wave source** in the properties.
3. **Set the detector condition**: set the camera length, pixel size, center position (approximate), and, if needed, the tilt φ, τ under **Detector condition**.
4. **Find the center**: detect the beam center automatically with **Find Center** on the toolbar (the search range is set under Miscellaneous).
5. **Mask spots**: remove single-crystal reflections and the like with **Mask Spots**. If needed, mask manually with **Manual**.
6. **One-dimensionalize**: obtain the profile with **Get Profile**. Saving and sending are configured on the **After "Get Profile"** tab (CSV save, send to PDIndexer, etc.).

For sequential images, select a frame in [Sequential](3-tools.md) before steps 5–6. For per-azimuth analysis, use Radial integration in **Integral Property**.

## Parameter determination: geometric calibration with a standard sample (double cassette)

When the camera length or wavelength is unknown, optimize the geometric parameters from the diffraction rings of a standard material (CeO2 by default, etc.), using [Find Parameter (Geometric)](3-tools.md).

1. Load the **Primary image** (standard sample, at one camera length) with Open, find the center, and show the peaks with **Get Profile**.
2. Dragging a diffraction-line marker in the Profile View updates the camera-length estimate automatically.
3. Load the **Secondary image** (the same standard sample, at a different camera length) in the same way, and enter the **camera-length difference** relative to Primary.
4. In the **Peak List**, select the d-values of peaks that appear in both images (at least one per image, ideally three or more).
5. Under **Refinement Option**, choose the parameters to optimize (wavelength, film distance, tilt, pixel size, pixel distortion).
6. Run **Refine!**, and once the residual stabilizes, copy the optimized results back to the main form.

!!! note
    Using two images (a "double cassette") makes it easier to determine the camera length and the wavelength separately.

## Parameter determination: brute-force optimization (arbitrary sample)

When geometric optimization struggles to converge, search the camera length and wavelength exhaustively with [Find Parameter (Brute force)](3-tools.md). See [Find Parameter (brute force)](6-find-parameter.md) for a detailed walkthrough with screenshots.

1. Load the Primary and Secondary images (two images, with rings in common, at different camera lengths).
2. Roughly align the center position in the main form (Find Center helps).
3. Enter the **search ranges (min, max, step)** for the camera length, wavelength, etc. Leave unknown parameters (pixel size, tilt) off at first.
4. Setting **Integral Region** to a slit (Rectangle) mode with a narrow band width helps suppress noise.
5. Start the search, and copy the combination with the smallest residual back to the main form.

## Automated processing (Auto Procedure)

Process images that arrive in a folder automatically, for example during an experiment. See [Tools](3-tools.md) for details.

1. Enable **Automatically load new images**, and choose the watch folder with **Set**.
2. If needed, filter files by **number matching** (the number at the end of the filename) or by **keyword**.
3. Enable **After Loading Image, Execute "Auto"**, and choose from the list: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Once monitoring starts, the sequence runs automatically each time a matching image arrives.

## Scripted procedures (Python-based macros)

Processing with loops and conditionals can be written as a [macro](5-macro/index.md). The bundled sample macros are a good starting point.

- Load an image, set the source and detector (center, camera length, pixels), and fit the display.
- Set the concentric-integration conditions (start, end, step, unit), one-dimensionalize, and save as CSV.
- Batch-process several files, saving a CSV next to each image.
- Process a multi-frame image frame by frame.
- Split a Debye ring into N sectors and analyze the azimuthal dependence.
- Mask (clear all → mask spots → mask the beam-stop region → save the mask) and one-dimensionalize.
- Output azimuth vs. intensity with radial (cake) integration.
- Enable clipboard sending, one-dimensionalize, and call a named macro in PDIndexer (e.g. peak fitting).

Macros you write can be saved, called by name, and also run from Auto Procedure.
