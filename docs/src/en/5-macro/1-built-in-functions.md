<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

The methods and properties callable from a macro, grouped by namespace under the `IPA` root object. Descriptions follow the macro editor's in-editor help (`[Help]` attributes); the in-editor help is the authoritative, up-to-date reference.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Returns the full path to a directory. If `filename` is omitted, a folder-selection dialog opens. |
| `GetFileName(message="")` | Opens a file dialog and returns the full path of the selected file. |
| `GetFileNames(message="")` | Opens a multi-select dialog and returns the full paths as a string array. |
| `GetAllFileNames(message="")` | Selects a folder and returns the full paths of all files in it (recursive) as an array. |
| `ReadImage(filename="", flag=None)` | Reads an image file. If omitted, a selection dialog opens. |
| `ReadImageHDF(filename, flag)` | Reads an HDF5 image. `flag` toggles normalization. |
| `SaveImage(filename="")` | Saves the current image (legacy alias; defaults to TIFF). |
| `SaveImageAsTIFF(filename="")` | Saves the image as TIFF. |
| `SaveImageAsPNG(filename="")` | Saves the image as PNG. |
| `SaveImageAsIPA(filename="")` | Saves the image as IPA format. |
| `SaveImageAsCSV(filename="")` | Saves the image as CSV. |
| `ReadParameter(filename="")` | Reads a parameter file. |
| `SaveParameter(filename="")` | Saves the current parameters. |
| `ReadMask(filename="")` | Reads a mask file. |
| `SaveMask(filename="")` | Saves the current mask. |

For all read/save methods, omitting or giving an invalid file name opens a selection dialog.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Sets the wavelength of the incident beam (in nm). |
| `WaveLength` | Set/get the wavelength (in nm). |
| `WaveSource` | Set/get the source as an integer. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Set the X-ray wavelength line as an integer (setter only). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Sets the center (direct spot) position (in pixels). |
| `SetCameraLength(length)` | Sets the camera length (in mm). |
| `CenterX` | Set/get the X value of the center position (in pixels). |
| `CenterY` | Set/get the Y value of the center position (in pixels). |
| `CameraLength` | Set/get the camera length (in mm). |
| `PixelSizeX` | Set/get the pixel X size (pixel width) (in mm). |
| `PixelSizeY` | Set/get the pixel Y size (pixel height) (in mm). |
| `PixelKsi` | Set/get the pixel skew ξ (in degrees). |
| `TiltPhi` | Set/get the tilt φ (in degrees). |
| `TiltTau` | Set/get the tilt τ (in degrees). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Draw the image with a negative gradient (counterpart of `PositiveGradient`). |
| `PositiveGradient` | True/False. Draw the image with a positive gradient (counterpart of `NegativeGradient`). |
| `LinearScale` | True/False. Draw with linear scale (counterpart of `LogScale`). |
| `LogScale` | True/False. Draw with log scale (counterpart of `LinearScale`). |
| `GrayScale` | True/False. Draw with gray scale (counterpart of `ColorScale`). |
| `ColorScale` | True/False. Draw with color scale (counterpart of `GrayScale`). |
| `Maximum` | Set/get the maximum brightness level (float). |
| `Minimum` | Set/get the minimum brightness level (float). |
| `CanvasMagnification` | Set/get the image magnification (float). |
| `SetCanvasCenter(x, y)` | Sets the canvas center position (in pixels). |
| `SetCanvasSize(width, height)` | Sets the canvas (picture box) size (in pixels). |
| `SetArea(top, bottom, left, right)` | Sets the canvas area by top/bottom/left/right bounds (in pixels). |
| `SetFullArea()` | Sets the canvas area so that the whole image is visible. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Masks spots (same as the "Mask Spots" button). |
| `ClearMask()` | Clears the current masks. |
| `InvertMask()` | Inverts the current mask state. |
| `MaskAll()` | Masks the whole area. |
| `MaskTop()` | Masks the top half. |
| `MaskBottom()` | Masks the bottom half. |
| `MaskLeft()` | Masks the left half. |
| `MaskRight()` | Masks the right half. |
| `TakeOver` | Set/get the take-over mask setting (integer). 0: None, 1: take over the current mask state, 2: take over the mask file. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integrate concentrically (2θ–intensity). |
| `RadialIntegration` | True/False. Integrate radially (pizza-cut). |
| `AzimuthalDivision` | True/False. Process in azimuthal-division mode. |
| `AzimuthalDivisionNumber` | Integer. Sets the number of Debye-ring divisions. |
| `FindCenterBeforeGetProfile` | True/False. Run Find Center before Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Run Mask Spots before Get Profile. |
| `SendProfileViaClipboard` | True/False. Send the profile to PDIndexer via the clipboard. |
| `SaveProfileAfterGetProfile` | True/False. Save the profile after Get Profile. |
| `SaveProfileAsPDI` | True/False. Save as PDI format. |
| `SaveProfileAsCSV` | True/False. Save as CSV format. |
| `SaveProfileAsTSV` | True/False. Save as TSV format. |
| `SaveProfileAsGSAS` | True/False. Save as GSAS format. |
| `SaveProfileInOneFile` | True/False. Save sequential/azimuthal-division profiles in one file. |
| `SaveProfileAtImageDirectory` | True/False. Save in the same directory as the image. |
| `GetProfile(filename="")` | Runs one-dimensionalization. If `filename` is given, the profile is saved to that file. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integrate concentrically (2θ–intensity). |
| `RadialIntegration` | True/False. Integrate radially (pizza-cut / cake pattern). |
| `ConcentricStart` | Float. Start value for concentric integration. |
| `ConcentricEnd` | Float. End value for concentric integration. |
| `ConcentricStep` | Float. Step value for concentric integration. |
| `ConcentricUnit` | Integer. Unit for concentric integration. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Donut radius for radial integration. |
| `RadialWidgh` | Float. Donut width for radial integration. Note: the member is spelled `RadialWidgh` in the current version. |
| `RadialStep` | Float. Sector angle (sweep step) for radial integration. |
| `RadialUnit` | Integer. Unit for radial integration. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Get whether the current file is a sequential image. |
| `Count` | Integer. Get the number of images. |
| `SelectedIndex` | Integer. Set/get the selected index (0-based). |
| `SelectedIndices` | Integer array. Set/get the selected indices (for multi-selection mode). |
| `MultiSelection` | True/False. Set/get multi-selection mode. |
| `Averaging` | True/False. Set/get averaging mode. |
| `SelectIndex(index)` | Sets a single selected index (turns off multi-selection). |
| `AppendIndex(index)` | Appends one index to the current selection. |
| `SelectIndices(start, end)` | Sets a contiguous range (start to end, inclusive). |
| `AppendIndices(start, end)` | Appends a contiguous range (start to end, inclusive) to the current selection. |
| `Target_SelectedImages` | True/False. Make the selected images the target for Get Profile. |
| `Target_AllImages` | True/False. Make all images the target for Get Profile. |
| `Target_TopmostImage` | True/False. Make only the topmost image the target for Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Run the macro on PDIndexer step-by-step. |
| `Timeout` | Set/get the timeout (seconds) for the macro operation (default 30 s). |
| `RunMacro(obj1, obj2, ...)` | Executes macro code on PDIndexer. Parameters are read on PDI as `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Executes the named macro `name` on PDIndexer. Parameters are read on PDI as `Obj[1]`, `Obj[2]`, … |
