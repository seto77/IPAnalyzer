<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->
<!-- 261124Cl: Corrected mouse operations, labels, flip/rotate, TIFF saving and the spot-detection criterion to match the current implementation. Renamed labels to the actual English GUI (Clear registry (check and restart), Version history, Criterial deviation for "Mask Spots"); Help → Help now opens this online manual; removed Ngen Compile and the Intensity table button (hidden in the current version); noted that Azimuthal Division Analysis needs concentric integration with a 2θ axis; replaced "one-dimensionalization" with "integration". -->

# Main Window

The main window is the first screen shown when IPAnalyzer starts. It brings together the display of the loaded diffraction image, the main operations (find center, mask spots, integration into a 1D profile), and the entry points to the detector-parameter settings.

The window consists, roughly, of the menus and toolbar at the top, the image display area in the center, the vertical toolbar on the right, and the graph area at the bottom.

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## Central View

### Image display

The loaded image is displayed here. Depending on the mouse-pointer position, the area above the image shows the real coordinates (mm), image coordinates (pix), distance from center R (mm), scattering angle 2θ, d-value, azimuth χ, and intensity. The magenta × mark indicates the direct-spot (center) position.

Pixel states are shown in distinct colors.

| Color | Meaning |
| --- | --- |
| Cyan | Masked spot |
| Green | Region excluded from integration (set in Integral Region) |
| Magenta | Angular region excluded from integration (set in Integral Property) |
| Blue | Pixel below the intensity threshold (set in Integral Region) |
| Red | Pixel above the intensity threshold |

### Mouse operations

In the normal mode:

- Left double-click: updates the center position to the clicked point.
- Middle-click: searches for the center, starting from the clicked point.
- Right-drag: zooms into the dragged region.
- Right-click: zooms out.
- Ctrl + right-drag: selects the rectangular region used for the statistical information.

Left double-click and middle-click work only while **Fix Center** is off.

In **Manual Mode**, left-click masks and right-click unmasks. The mask shape and size are set on the toolbar and in the properties.

### Auxiliary views and image information

Beside the central view are auxiliary displays. You can switch between **Whole image** and **Near center**: the whole-image view marks the current display range with a yellow frame, and the near-center view shows a magnified image.

**Image Information** shows the image resolution, maximum intensity, total intensity, header data, and so on.

### Display adjustment controls

Controls that adjust how the image appears:

- **Gradient**: invert the tone.
- **Brightness scale**: logarithmic / linear.
- **Color scale**: grayscale / color.
- **Scale line**: scale-line display (none / coarse / medium / fine).
- **Auto Contrast** / **Reset Contrast**, and explicit minimum/maximum intensity.
- Magnification buttons (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Lower View

The bottom area has three tabbed graphs/views.

- **Frequency of Intensity**: the intensity distribution of all pixels, on log–log axes. Zoomable with the mouse.
- **Converted Profile**: the diffraction profile produced by **Get Profile**. Zoomable with the mouse.
- **Statistical Information**: statistics for the rectangular region (X1,Y1)–(X2,Y2) selected by Ctrl + right-dragging on the image. When a sequential image is loaded, statistics of the same region in other frames can also be compared.

## Menus

The menu bar consists of **File / Tool / Property / Option / Language / Macro / Help**.

### File

- **Read image**: opens a diffraction image. See [Overview](0-overview.md) for the supported formats.
- **Save image**: saves as TIFF, PNG, CSV, or IPA format. TIFF stores the current processed pixel intensities (after flip/rotate, background subtraction and polarization correction), PNG preserves the display (brightness, contrast, mask), and IPA is a distortion-corrected proprietary format (with metadata).
- **Read / Save parameter**: imports/exports the wavelength, camera length, pixel size, tilt correction, center position, etc. as a `.prm` file.
- **Read / Save / Clear mask**: imports/exports a mask as a `.mas` file, or clears it (the mask must match the resolution of the current image).
- **Close**.

Image, parameter, and mask files can also be loaded by dragging and dropping onto the window.

### Tool

- **Reset Frequency Profile**: rebuilds the intensity-frequency graph of the current image with the default range (the image is kept).
- **Calibrate Raxis Image**: derives an intensity conversion table from two R-AXIS images (see [Tools](3-tools.md)).

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. These open the corresponding tabs of the [property window](2-property-windows.md) directly.

### Option

- **ToolTip**: toggles the tooltips on buttons and menus.
- **Flip**: **Horizontally** / **Vertically**. **Rotate**: choose a rotation angle. Flip and rotation are applied to the working image data and therefore also affect subsequent integration and image saving (the source file on disk is not changed).
- **Clear registry (check and restart)**: a troubleshooting item that erases the saved settings.

### Language

- Selects the display language (11 languages). After confirmation the application restarts. The setting is saved in the registry.

### Macro

- **Editor**: opens the macro editor (see [Tools](3-tools.md) / [Macro](5-macro/index.md)).

### Help

- **Program Updates**, **Hint**, **License**, **Version history**, **Help**.
- **Help** opens this online manual in the default web browser, like pressing **F1**.
- Press **F1** in any window to open the corresponding page of this online manual.

## Operation toolbar

The main image-processing operations (with detailed options on the dropdowns):

- **Background**: this button is disabled in the current version. Background-image subtraction is configured on the **Background Option** tab of the property window.
- **Find Center**: detects the beam center by 2D Pseudo-Voigt fitting (the search range is ±8 px around the center by default, set on the Miscellaneous tab). When rings are shown with **Draw ring**, the center is determined from the ring instead.
- **Fix Center**: fixes the center position.
- **Mask Spots**: within each radial band, pixels whose intensity exceeds mean + standard deviation × **Criterial deviation for "Mask Spots"** (Mask Option tab) are detected as spots and masked together with their surroundings. The dropdown includes **Mask all area**, **Invert mask**, **Manual Mode**, and so on.
- **Manual Mode**: the manual mask mode. You can choose the mask shape (spot (circle/rectangle) / circle / rectangle / polygon / spline) and the spot size (half-width).
- **Get Profile**: integrates the image into a 1D profile. Supports **Concentric Integration** (2θ-based) and **Radial integration** (azimuth-based). The dropdown configures the Integral Property/Region selection, whether to find center and mask spots before integration, sending to PDIndexer, **Azimuthal Division Analysis** (only with concentric integration and the **Angle** (2θ) axis; otherwise a warning is shown and nothing is run), sequential-image processing, and so on.

## Toolbar (other tools)

The vertical toolbar on the right launches the various tools. See [Tools](3-tools.md) for details.

- **Auto procedure**
- **Draw ring**
- **Find parameter (geometrically)** / **Find parameter (brute force)**
- **Unroll image**
- **Circumferential blur**
- **Sequential image**
