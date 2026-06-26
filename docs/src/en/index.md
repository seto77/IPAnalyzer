<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# IPAnalyzer Manual

## Brief introduction

* **IPAnalyzer** is MIT-licensed free software that converts two-dimensional powder-diffraction images (Debye–Scherrer rings) recorded with imaging plates (IP) or CCD/CMOS flat-panel detectors into high-precision one-dimensional 2θ–intensity profiles.
* It calibrates the measurement geometry — camera length, wavelength, detector tilt, and pixel shape — from the rings of standard materials, supports X-ray, electron, and neutron sources, and integrates with [PDIndexer](https://github.com/seto77/PDIndexer) for subsequent peak analysis.
* Its design and features follow *PIP*, developed by Hiroshi Fujihisa at AIST.

## Find by goal

| Goal | Start here | Main next steps |
|------|------------|-----------------|
| Understand the coordinate system and geometry | [Overview](0-overview.md) | [Property Windows](2-property-windows.md) |
| Load an image and get a 1D profile | [Procedures](4-procedures.md) | [Main Window](1-main-window.md), [Property Windows](2-property-windows.md) |
| Calibrate camera length / wavelength | [Procedures](4-procedures.md) | [Tools](3-tools.md), [Find Parameter (brute force)](6-find-parameter.md) |
| Mask spots / handle multi-frame data | [Tools](3-tools.md) | [Procedures](4-procedures.md) |
| Automate processing | [Macro](5-macro/index.md) | [Built-in functions](5-macro/1-built-in-functions.md), [Examples](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Features

* **Wide format support** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4, and general image formats. Most file I/O supports drag & drop.
* **Image-to-profile conversion** : Concentric (radial-average), radial (azimuthal/cake), and unrolled-image computation, using a sub-pixel area-distribution algorithm that correctly handles detector tilt and parallelogram pixel shapes.
* **Geometry calibration** : Geometric (double-cassette) refinement of wavelength, camera length, pixel size/distortion, and tilt (φ, τ), plus a brute-force grid search for difficult data.
* **Image handling** : Automatic beam-center detection, single-crystal spot detection and masking, circumferential blur, draw-ring overlays, intensity-table detector calibration, and geometry-preserving IPA save.
* **Multi-frame data** : Select, average, or sum frames of HDF5/NeXus and other sequential data, with per-frame wavelength from embedded energy.
* **Automation** : Folder-watching Auto Procedure and a Python-syntax [macro](5-macro/index.md) for batch and scripted processing.
* **PDIndexer integration** : Send profiles to [PDIndexer](https://github.com/seto77/PDIndexer) via the clipboard and trigger named macros there.
* **Light / dark theme** : The interface follows a selectable light or dark colour mode.

## System requirements

| Item | Minimum | Recommended |
|------|---------|-------------|
| OS | Windows with [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Memory | - | 16 GB or more |
| CPU | - | 8+ cores (image intensities are held as double precision and processing is multi-threaded) |

## Quick start

1. Download and install from [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Read a diffraction image (File → Read image, or drag & drop).
3. Set the **Wave source** and **Detector condition** (camera length, pixel size, approximate center) in the property window.
4. Find the center, mask spots if needed, and press **Get Profile** to obtain the 1D profile.
5. If the geometry is unknown, calibrate it from a standard material — see [Procedures](4-procedures.md).

See [Procedures](4-procedures.md) for the full workflow.

## How to use this manual

This GitHub Pages manual is the current source of truth. Use the left navigation to browse by chapter, or use search in the header to find a function name or UI label. It replaces the legacy Word/HTML/PDF manual that was distributed in `IPAnalyzer/doc/`.

## License

IPAnalyzer is distributed under the [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
