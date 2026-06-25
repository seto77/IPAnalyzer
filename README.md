# IPAnalyzer

[![Documentation](https://img.shields.io/badge/%F0%9F%93%96_Documentation-blue)](https://seto77.github.io/IPAnalyzer/)
[![Latest Release](https://img.shields.io/github/v/release/seto77/IPAnalyzer?logo=github)](https://github.com/seto77/IPAnalyzer/releases/latest)
[![License: MIT](https://img.shields.io/badge/License-MIT-green)](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md)

*IPAnalyzer* is free and open-source software for processing two-dimensional powder-diffraction images. It converts Debye–Scherrer ring patterns recorded with imaging plates (IP) or CCD/CMOS flat-panel detectors into high-precision one-dimensional 2θ–intensity profiles, and calibrates the measurement geometry (camera length, wavelength, detector tilt, pixel shape) from the diffraction rings of standard materials. It supports X-ray, electron, and neutron sources, and integrates seamlessly with [PDIndexer](https://github.com/seto77/PDIndexer) for subsequent peak analysis and indexing.

*IPAnalyzer* has been developed since 2005. Its design and features are modeled after *PIP*, developed by Hiroshi Fujihisa at the National Institute of Advanced Industrial Science and Technology (AIST).

***[See the manual to learn how to use!](https://seto77.github.io/IPAnalyzer/)***

<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormMain.png" width="600px" alt="IPAnalyzer main window converting a Debye-ring pattern into a 1D profile">

## Author

*IPAnalyzer* is developed by [Seto Y.](https://yseto.net/) (Osaka Metropolitan University, Japan).

## Install

* Access https://github.com/seto77/IPAnalyzer/releases/latest and download the latest release.
* Recommended: download `IPAnalyzer-setup.msi` (x64) and run the installer. For Windows on Arm (e.g. Snapdragon PCs), download `IPAnalyzer-setup_arm64.msi` instead. <!-- 260625Cl WiX asset names + arm64 -->
* Alternative for managed Windows PCs: download the portable ZIP (`IPAnalyzer-v.<ver>.zip` for x64, or `IPAnalyzer-v.<ver>_arm64.zip` for Arm), extract it to a user-writable folder, and run `IPAnalyzer.exe` from the extracted folder.
* The MSI installer requires ***.Net Desktop Runtime 10.0*** (NOT ***.Net Runtime 10.0***), which can be installed from [here](https://dotnet.microsoft.com/download/dotnet/10.0). On Windows on Arm, install the **Arm64** build of the Desktop Runtime.
* The portable ZIP package is self-contained for the matching architecture (x64 or Arm64) and does not require a separate .NET Desktop Runtime installation. It is a no-install package, but it still stores user settings and copied default data under the current user's AppData folder.
* *IPAnalyzer* is distributed under the **MIT license** (free for anyone to use, modify, and redistribute).

### Note on Windows Security Warnings

* Please download *IPAnalyzer* only from the official GitHub Releases page: https://github.com/seto77/IPAnalyzer/releases/latest
* On some Windows systems, Microsoft Defender SmartScreen or Smart App Control may display a warning before the installer is executed. This may happen for newly built or narrowly distributed research software, and the warning itself does not necessarily mean that the installer is malicious.
* If you would like to verify the downloaded installer yourself, you can calculate its SHA256 hash in PowerShell:

```powershell
Get-FileHash .\IPAnalyzer-setup.msi -Algorithm SHA256
Get-FileHash .\IPAnalyzer-v.*.zip -Algorithm SHA256
```

* For an additional check, you may also scan the installer with a multi-engine service such as VirusTotal.

## Privacy

*IPAnalyzer* is a local desktop application. It does **not** collect, store, or transmit any personal or usage data, and it contains no telemetry or analytics. After installation it runs fully offline.

The only network connection *IPAnalyzer* makes is an optional, user-initiated one:

* **Check for updates** (menu command): compares your installed version with the latest GitHub release and, if you choose, downloads the new installer from the official [GitHub Releases](https://github.com/seto77/IPAnalyzer/releases/latest) page.

Integration with *PDIndexer* is performed locally through the Windows clipboard and does not involve any network communication.

## Manual

* Online manual (English / Japanese) : https://seto77.github.io/IPAnalyzer/

The manual offers full-text search, a light / dark theme, and English / 日本語 language tabs.

***

## Main Features

### Wide range of supported file formats

* Imaging plate / flat panel: Fuji BAS2000 / BAS2500 / FDL, Rigaku R-AXIS IV / V, ITEX, Bruker CCD, Rayonix SX, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, IP Display / IPAimage, and more.
* Multi-frame / scan data: HDF5, NeXus (`*.nxs`), Digital Micrograph 3 / 4, and other sequential formats (time, temperature, or energy series).
* General image formats (TIFF, PNG, etc.) and the native IPA format that preserves geometry metadata.

### Image-to-profile conversion (one-dimensionalization)

* Converts diffraction images into 2θ–intensity (or d-value / distance) profiles.
* **Concentric integration** (radial averaging), **radial integration** (azimuthal / cake), and **unrolled-image** computation.
* A sub-pixel area-distribution algorithm distributes each pixel's intensity across integration steps by computing pixel/step intersections, correctly handling detector tilt and parallelogram pixel shapes — so the step interval can be made arbitrarily fine.
* X-ray, electron, and neutron sources; characteristic X-ray energies are built in.

### Geometry calibration

* **Geometric calibration (double cassette)**: refines wavelength, camera length, pixel size, pixel distortion, and tilt (φ, τ) from the rings of a standard material using two patterns.
* **Brute-force calibration**: an exhaustive grid search for camera length and wavelength, effective for incomplete rings or noisy data where gradient methods struggle to converge.

### Image handling

* Automatic beam-center detection, single-crystal spot detection and masking, manual masking, and beam-stop masking.
* **Sequential image** tool for multi-frame data: select / average / sum frames, with per-frame wavelength from embedded energy.
* **Circumferential blur**, **Draw Ring** overlays, **Intensity Table** detector-response calibration, and **Save Image (IPA)** that rectifies tilt and pixel distortion.

### Automation

* **Auto Procedure**: watch a folder and automatically load + process new images as they arrive (auto-contrast → find center → mask spots → get profile → run macro).
* **Python-syntax macro** for scripting repetitive tasks (batch conversion, azimuthal splitting, masking, format conversion, etc.). See the [Macro manual](https://seto77.github.io/IPAnalyzer/en/5-macro/).
* **PDIndexer integration**: send profiles directly to [PDIndexer](https://github.com/seto77/PDIndexer) via the clipboard and trigger named macros there.

***

## Screenshots

<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormMain.png" height="320px" alt="Main window">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormProperty.png" height="320px" alt="Property window">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormFindParameter.png" height="320px" alt="Find Parameter (geometric)">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormFindParameterBruteForce.png" height="320px" alt="Find Parameter (brute force)">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormDrawRing.png" height="320px" alt="Draw Ring">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormSequentialImage.png" height="320px" alt="Sequential Image">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormSaveImage.png" height="320px" alt="Save Image (IPA)">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormAutoProcedure.png" height="320px" alt="Auto Procedure">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormCalibrateIntensity.png" height="320px" alt="Intensity Table">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormBlurAngle.png" height="320px" alt="Circumferential Blur">
<img src="https://seto77.github.io/IPAnalyzer/assets/cap-en-auto/FormMacro.png" height="320px" alt="Macro editor">
