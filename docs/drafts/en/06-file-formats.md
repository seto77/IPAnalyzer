This is a draft written by Claude from the source code (2026-11-05). Not yet reviewed by the author.

# Supported file formats (as implemented)

Code: `Crystallography/Images/ImageIO.cs` (`ImageIO.ReadImage` dispatches), `Tiff.cs`, `DigitalMicrograph.cs`, `IO/HDF.cs`, `IO/MRC.cs`, `IO/PdiFile.cs`, `Diffraction/DiffractionOptics.cs`, `Profile.cs` (all in submodule `7a435ee`), `IPAnalyzer/FormMain.cs`, `IPAnalyzer/FormSaveImage.cs`, `IPAnalyzer/FormSequentialImage.cs`.

## 1. Input images

### 1.1 Order of dispatch

`ImageIO.ReadImage(path, flag)` tests the following in order and uses the reader of the first match. There are 9 kinds of `.img`, distinguished in the order **companion file → header string**.

| Order | Condition | Reader | Format |
|---|---|---|---|
| 1 | `*img` and a `.inf` with the same name exists | `BAS2000or2500` | Fuji BAS2000/2500 (reading fails if line 1 of `.inf` does not contain `BAS_IMAGE_FILE`) |
| 2 | `*img` and a `.tem` with the same name exists | `FujiFDL` | Fuji FDL |
| 3 | `*img` and starts with `R-AXIS` or `ipdsc\0` | `Raxis4` | Rigaku R-AXIS IV/V |
| 4 | `*img` and starts with `{\nHEADER_BYTES=17408;\nBYTE_ORDER=little_endian` | `RintRapid2Unroll` | Rigaku RINT-RAPID II unrolled image |
| 5 | `*img` and starts with `{\nHEADER_BYTES=  512;\nCOMMENT=Written by adxv;` | `ADXV` | img converted from PILATUS cbf by ADXV |
| 6 | `*img` and `Rigaku 2D-PXD Image Header Format` in the first 5 lines | `RigakuPXD` | Rigaku 2D-PXD / d*TREK extension |
| 7 | `*img` and starts with `IM` | `ITEX` | Hamamatsu Photonics ITEX |
| 8 | `*img` and starts with `{\nHEADER_BYTES= ` | `ADSC` | ADSC |
| 9 | `*img` and TIFF signature | `Tiff` | TIFF |
| 10–11 | `.stl` / `.osc` | `Raxis4` | R-AXIS IV / IV oscillation |
| 12 | extension starts with `0` and TIFF signature | `RayonixSX200` | Rayonix SX (`.0001` etc.) |
| 13 | `.ccd` | `Brucker` | Bruker CCD (SMART/APEX v86) |
| 14 | `.gel` | `Gel` | GE / Molecular Dynamics gel (Typhoon/FLA) |
| 15 | `.ipf` | `Ipf` | IP Display (fixed 8000×4000) |
| 16 | extension starts with `mar` | `MAR` | Marresearch mar345 etc. (CCP4 packed) |
| 17 | `.mccd` | `Mccd` | Mar/Rayonix CCD |
| 18 | `.his` | `ITEX` or `HIS` | ITEX if it starts with `IM`, otherwise Perkin Elmer XRD |
| 19 | `.ipa` (other than `ClipBoard.ipa`) | `IPA` | IPAnalyzer native format |
| 20 | `.bmp` / `.jpg` / `.png` | `GeneralImage` | General images (converted to 8-bit gray by RGB average) |
| 21 | `.tif` / `.tiff` | `Tiff` | TIFF (multi-page allowed) |
| 22 | `.h5` | `HDF5` | **Always fails** (the body is commented out and it does `return false`) |
| 23 | `.dm3` / `.dm4` | `DM` | Gatan DigitalMicrograph |
| 24 | `.raw` | `RadIcon` | Rad-icon (identified by file size) or KEK-PF BL18C format (identified by header) |
| 25 | `.smv` | `SMV` | SMV (Dexela according to the comment) |
| 26 | `.mrc` | `MRC` | MRC2014 (FEI/TFS TEM cameras) |
| 27 | `.nxs` | `NXS` | NeXus (X-Spectrum LAMBDA) |

Note: the `.img` and `mar` tests are case-sensitive (`EndsWith("img")`, `StartsWith("mar")`).

### 1.2 Handling of pixel values (main formats)

| Format | Pixel values | Implementation notes |
|---|---|---|
| Fuji BAS2000/2500 | Big-endian 16-bit (8-bit if bits ≤ 8) QL converted via a table: $I = 10^{\,L\cdot \mathrm{QL}/2^B} - 1$ (upper limit $10^L-1$). $L$: latitude, $B$: number of bits (`.inf`) | **Not converted to PSL**. Sensitivity and pixel size are read but not used (→ Implementation questions) |
| Fuji FDL | Big-endian 16-bit values as they are | No logarithmic conversion |
| R-AXIS | Big-endian uint16. Values $>$ 0x7fff become $(v\,\&\,0\mathrm{x}7\mathrm{fff})\times \mathrm{hilo}$ (hilo: float at byte 800 of the header) | Flipped vertically after reading. Wavelength, camera length and pixel size in the header are read but not used |
| Rad-icon (`.raw`) | Big-endian **signed** int16 | Image size from the file size: 688×2064, 2048×2048, 2064×1548, 2064×2236, 2080×2238, 3096×3100, 1300×4608, 2940×4608, 5888×4608. For non-square sizes, width and height are inferred from continuity (`CalcWrapAndVertAvg`) |
| TIFF | Uncompressed 8/16/32-bit integers (signed and unsigned), 32-bit float. For RGB, only the red channel | Multi-frame as long as IFDs of the same size and format follow. With extension tif and minimum ≤ 0, negative pixels are masked automatically (`FormMain.ReadImage`) |
| DM3/DM4 | float / uint32 / int32 / complex FFT (amplitude) | Reading fails for int16, uint16, double, byte |
| MRC | MODE 0,1,2,6 | First section only |
| NeXus | `/entry/instrument/detector/data` ([n,h,w]) | Multi-frame if n>1 |

### 1.3 Geometry information in headers

Header values are put into the optics parameters only for the following 2 formats:

- **IPA**: camera length, resolution (→ PixSizeX = PixSizeY), center, wavelength. In addition, φ = τ = ξ = 0 is set (`FormMain.ReadImage`).
- **DM3/DM4**: the source is set to electrons, and acceleration voltage, pixel size and camera length (converted in the form $L = s/\tan(\lambda\cdot\mathrm{scale})$) replace the current values only when they differ from them by 20 % or more.

For all other formats, **the full set of parameters last used for that image type (`Ring.ImageTypeEnum`)** (detector shape, Gandolfi radius, camera length, pixel size and ξ, φ and τ, source, flip/rotation, center) is restored (`FormProperty.SetParameterFromImageType`; saved by `SaveParameterForEachImageType`, persisted in the registry). Rigaku 2D-PXD is stored as the same type as SMV, and gel as the same type as MCCD. RINT-RAPID II does not set a type (it inherits the type of the previous image).

### 1.4 Multi-frame (sequential)

Multiple frames occur for TIFF (multi-page), NeXus (n>1), SMV (SIZE3), Perkin Elmer HIS, concatenated ITEX, and KEK-PF raw. With 2 or more frames the program enters sequential mode (`FormMain.ReadImage`).

- The private TIFF tags 60000 (X-ray energy, eV), 60001 (name), 60002 (pulse intensity) are read. If 60002 is present, the user is asked "Normarize intensities by pulse power?"; if yes, $I/P/10000$.
- Only when a single frame is selected is the wavelength updated from that frame's energy ($\lambda[\mathrm{nm}] = 1239.84/E[\mathrm{eV}]$, `UniversalConstants.Convert.EnergyToXrayWaveLength`). Per-frame wavelength updates for average/sum, and for batch Get Profile of all frames / selected frames, are in a branch executed only when the image type is HDF5, so they are currently never executed.
- Average/sum (Sequential Image window): per pixel $\sum I / n$ (average) or $\sum I$ (sum).

### 1.5 Ways to open

- Dialog filter of the menu File → Read image (`ImageIO.FilterString`): `*.img;*.stl;*.ccd;*.ipf;*.ipa;*.0???;*.gel;*.osc;*.mar*;*.mccd;*.his;*.h5;*.dm?;*.raw;*.bmp;*.jpg;*.tif;*.tiff;*.png;*.smv;*.mrc;*.nxs`.
- Drag and drop (`FormMain_DragDrop`): effective only when **exactly one** item is dropped. Image → read; `.prm` → read parameters (with Ctrl held, a dialog to select the items to read); `.mas` → read mask; folder → the first file in it.
- Command-line arguments: only `img|stl|ccd|ipf`, `prm`, `mas`.
- Ctrl+←/→: in sequential mode, step through frames; otherwise, open the previous/next file in the same folder.

## 2. Output

### 2.1 Saving images (File → Save image)

| Format | Content | Implementation |
|---|---|---|
| TIFF | The current `Ring.Intensity` (**after** flip/rotation, background and polarization correction). If all values are integers, 8/16/32-bit unsigned depending on the maximum; if there are fractional values, 32-bit float. Negative values become 0. For sequential images, all frames are saved as multi-page with the same corrections applied | `FormMain.saveImageAsTiff`, `Tiff.Writer` |
| PNG | As displayed (including contrast, color scale and mask display). While the Unroll view is shown, 2θ and χ scales are added | `FormMain.saveImageAsPng` |
| CSV | Pixel values comma-separated row by row (UTF-8 with BOM) | `FormMain.saveImageAsCSV` |
| IPA | Square-pixel image with tilt and pixel distortion removed (below) | `FormSaveImage.SaveImageAsIPA` |

**IPA saving** (Save Image window: Width/Height default 1000, Resolution default 100 µm, Center default 500): the four corners of each source pixel are mapped onto the $Z=L$ plane with tilt correction and central projection, and the intensity is distributed by the overlap-area ratio with the output pixel squares (`Ring.GetCorrectedImageArray`; conservative polygon rebinning, no interpolation). Mask, spherical correction and Gandolfi are not taken into account. The file is an XML serialization of `IPAImage` containing intensity (double array), width and height, center, resolution [mm/pix], wavelength information, and camera length.

### 2.2 Parameter file (`.prm`)

XML of `DiffractionOptics.Parameter` (values are the UI strings). Items: detector shape, Foot mode, direct-spot and Foot positions, Camera Length 1/2, source, wavelength, element, line, pixel size X/Y and ξ, φ and τ, spherical correction, Gandolfi radius, integral region (each value for Rectangle/Sector), integration mode (unit and range for Concentric/Radial). Each time it is saved, the "Save checked parameters" dialog (`FormParameterOption`) appears. On reading, old-format tag names are rewritten to the new format and **the file is overwritten** before it is read (`DiffractionOptics.Read`).

### 2.3 Mask file (`.mas`)

A little-endian Int32 pixel count $N$, followed by a bit string of $\lfloor N/8\rfloor$ bytes (LSB first). It is ignored if the pixel count does not match the current image.

### 2.4 Profiles (After "Get Profile" tab)

| Format | Extension | Content |
|---|---|---|
| PDI | `.pdi2` | XML of `DiffractionProfile2[]` (`XYFile.SavePdi2File`) |
| CSV / TSV | `.csv` / `.tsv` | With one profile per file, each line is `X, Y, Y` (Y twice). When multiple profiles are combined into one file, line 1 holds the names, line 2 `x, y`, and thereafter 3 columns per profile (x, y, empty) |
| GSAS | `.gsa` | FXYE format. `BANK 1 n n CONST start×100 step×100 0 0 FXYE`; data are `X×100  Y  σ` (centidegrees) |

The destination is "At the same directory of the image" or "At the chosen directory each time"; for multiple profiles (sequential, azimuthal division) the Saving option is "In one file (Excluding GSAS)" or "In separate files". Separate file names are `#<frame name>` for sequential images, and `-NNN` (center angle) and `-whole` for azimuthal division.

### 2.5 Sending to PDIndexer

`checkBoxSendProfileToPDIndexer` (default on). It checks that PDIndexer is running via the named mutex `PDIndexer` (waits 500 ms; 5 s for azimuthal division), serializes `DiffractionProfile2[]` with MemoryPack, and puts it on the clipboard. The unrolled image can also be sent at the same time.

## Items to confirm

1. May HDF5 (`.h5`) be treated as discontinued? Should the "HDF5 support" statements in the current manual and README be removed? Should it also be removed from the filter?
2. Which Rad-icon size (2940×4608 etc.) does "Rad-Xcam" in the README and index correspond to?
3. May the BAS conversion be described as "proportional to PSL (up to a constant factor and an offset of −1)"? Is there a plan to convert to PSL?
4. Is not using the wavelength, camera length and beam center in the headers of R-AXIS, ADSC, Rigaku PXD, etc. (using the per-type stored values instead) as intended?
5. How should the manual describe that the per-frame wavelength is not updated in batch Get Profile (HDF5-only branch)?
6. Is the two-column Y output in CSV intended?
