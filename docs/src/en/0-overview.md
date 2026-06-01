<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Overview

IPAnalyzer converts Debye–Scherrer rings recorded with imaging plates (IP) or CCD/CMOS detectors into one-dimensional diffraction profiles, with high precision and speed. Its design and features are modeled after PIP, developed by Hiroshi Fujihisa at the National Institute of Advanced Industrial Science and Technology (AIST).

Main features:

- Supports a wide range of image formats (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, and general image formats)
- X-ray, electron, and neutron sources
- Integration with PDIndexer
- Semi-automatic analysis of measurement parameters

## System requirements and installation

### Requirements

- OS: Windows (Windows 11 recommended)
- Required runtime: .NET Desktop Runtime 10.0
- Recommended memory: 16 GB or more
- Recommended CPU: 8 cores or more

Internally the software makes heavy use of multi-threaded computation, so a CPU with more cores runs more comfortably. Image intensities are held internally as double-precision floating-point values.

The software is distributed under the MIT License.

### Installation

1. Install [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) in advance.
2. Download `IPAnalyzerSetup.msi` from the GitHub [releases page](https://github.com/seto77/IPAnalyzer/releases).
3. Run `IPAnalyzerSetup.msi` to install.

## Axis orientation, IP tilt, and pixel shape

IPAnalyzer uses a right-handed coordinate system, with the origin and axis directions defined as follows.

- The point where the X-ray or electron beam intersects the IP (the direct spot) is defined as the origin (0, 0, 0), and the Z axis coincides with the beam direction.
- Treating the sample size as infinitesimal, the distance between the sample position and the origin is defined as the camera length (Camera Length, CL). The sample is therefore located at \((0,\ 0,\ -\mathrm{CL})\).
- The X axis is aligned with the scanning direction of the IP read-out laser when the IP is not tilted. The Y axis therefore points downward on the screen.
- The IP tilt is expressed as a rotation about a line lying in the XY plane that passes through the origin: a rotation by \( \tau \) about the line that makes an angle \( \varphi \) with the X axis.
- The pixel shape is treated as a parallelogram described by PixSizeX, PixSizeY, and \( \xi \). A non-zero \( \xi \) means there is an offset in the start position of the IP read-out laser scan. The software assumes this offset is constant along the Y axis.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

The camera length, \( \varphi \), \( \tau \), pixel size, and \( \xi \) are set on the IP Condition tab of the property window (see [2. Property Windows](2-property-windows.md)).

### Relationship with (WIN)PIP

In IPAnalyzer, the X axis (the rightward direction of the IP image) is rotated clockwise by \( \varphi \), and the resulting axis is then rotated by \( \tau \). In PIP, the Y axis (the downward direction of the IP image) is rotated counter-clockwise by \( \beta \), and the resulting axis is then rotated by \( \Phi \). Therefore, to convert PIP's \((\beta,\ \Phi)\) to IPAnalyzer's \((\varphi,\ \tau)\), use \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Pixel intensity integration method

The central problem in one-dimensionalization is how to distribute, among the integration steps, the intensity of a pixel that straddles several steps — which happens when the angular step interval is smaller than the pixel interval (i.e. the pixel size).

The software computes the intersections between the lines that delimit each step and the pixel, and distributes the intensity by finding the pixel area contained in each step. To handle cases where the pixel is not exactly square — because of IP tilt or pixel-shape distortion — the coordinates of the four corners of each pixel are computed successively to determine its quadrilateral shape. In principle, this lets the pixel intensity be distributed smoothly across the steps no matter how small the steps are made.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

This algorithm is used not only for ordinary angle–intensity integration (Concentric Integration), but also for integration along the circumference (Radial Integration) and for the unrolled-image computation (Unrolled Image).
