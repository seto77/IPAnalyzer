<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->
<!-- 261124Cl: Rewritten for the current screen (crystal window → Beam interaction → Reflections tab), based on ReciPro docs/src/en/3-beam-interaction.md (the same shared control) and limited to what IPAnalyzer uses (the reflection list and structure factors of the standard crystal). Replaced the screenshots of the former Scattering Factor window with the current one (assets/references/beam-interaction-reflections-en.png, copied from ReciPro). -->

# Appendix A5. Scattering Factor

In the current version, the reflections and structure factors of a crystal are shown on the **Reflections** tab of the **Beam Interaction** window (the former Scattering Factor window has been replaced by it). The tab lists the allowed crystal planes (reflections) of the selected crystal and calculates the **structure factor** and diffraction intensity of each. The radiation type (X-ray, electron, or neutron) can be switched, so the structure factors of the same crystal can be compared across diffraction techniques.

In IPAnalyzer, open it from the crystal window that defines the standard crystal used for parameter calibration (the crystal window opened with **Set crystal** in [Find Parameter (Geometric)](../3-tools.md), or the crystal panel of [6. Find Parameter (brute force)](../6-find-parameter.md)): press the **Beam interaction** button, or choose **Beam Interaction** from the right-click menu of the crystal panel.

![Beam Interaction window (Reflections tab)](../../assets/references/beam-interaction-reflections-en.png)

The band at the top selects the incident beam, and the **Reflections** tab below shows the reflection list (upper part) and a stick diagram of the same reflections (lower part). The list is recomputed immediately whenever a condition changes. The other tabs (**Attenuations & transport**, **Scattering factors**, **Fluorescence**) are not needed for IPAnalyzer; see [Beam Interaction in the ReciPro manual](https://seto77.github.io/ReciPro/3-beam-interaction/) for them.

---

## Keyboard & mouse shortcuts

This window has no special key or mouse combinations. <kbd>F1</kbd> opens this manual page, and **Copy** exports the reflection table as spreadsheet-pasteable text.

---

## Beam and wavelength

- **X-ray / Electron / Neutron** : the atomic scattering factors differ by the type of incident beam, so they are switched here.
- For **X-ray**, choosing the **Element** (anode material) and characteristic line (Kα, etc.) sets the wavelength of that characteristic X-ray automatically.
- **Energy** (keV) and **Wavelength** (Å) are linked; setting either updates the other, and both are used to compute the 2θ of each reflection.
- **Unit** (**Å** / **nm**) switches the length unit used for d-spacing and similar quantities.

---

## Options of the Reflections tab

- **Powder diffraction intensities (Bragg-Brentano optics)** : computes the relative intensity as a powder-diffraction (Bragg–Brentano) intensity, $I \propto m\,\lvert F\rvert^2 / V^2 \times L$, where $m$ is the multiplicity, $V$ the cell volume, and $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (Lorentz–polarization factor) for X-rays or $L = 1/(\sin 2\theta\,\sin\theta)$ (Lorentz factor only) for electrons and neutrons. Reflections the beam cannot reach (d < λ/2) get an intensity of 0. When off, the structure-factor intensity $\lvert F\rvert^2$ is shown. Turning it on also turns on **Hide equivalent planes** and **Hide prohibited planes** and greys them out.
- **Hide equivalent planes** (on by default) : collapses crystallographically equivalent planes into a single entry. The **Multi.** column is shown only while this is on.
- **Hide prohibited planes** (on by default) : excludes planes that are systematically absent by the extinction rules. While it is off, a **Condition** column shows the reflection condition(s) that forbid each absent plane.
- **d-spacing cutoff >** (default 1 Å) : excludes reflections with a d-spacing smaller than this value (the length unit follows **Unit**).

---

## Reflection list

Each row corresponds to one reflection (or a group of symmetry-equivalent planes).

| Column | Meaning |
|------|------|
| **h, k, l** | Miller indices |
| **Multi.** | multiplicity (number of symmetry-equivalent planes) |
| **d (Å)** | interplanar spacing |
| **q (2π/d)** | magnitude of the scattering vector |
| **2θ (°)** | diffraction angle for the selected wavelength |
| **F_real** | real part of the structure factor |
| **F_inv** | imaginary part of the structure factor |
| **\|F\|** | structure-factor amplitude ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | structure-factor intensity ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | relative intensity, with the strongest reflection set to 100 |
| **Condition** | extinction condition(s) violated by the plane (shown only when **Hide prohibited planes** is off) |

Below the table, the same reflections are drawn as a stick pattern, with the strongest peaks labelled by their *hkl*. The selector chooses the horizontal axis from **2θ**, **d** and **Q** ($= 4\pi\sin\theta/\lambda$), **Log I** switches the intensity axis between linear and logarithmic, and the **Range** boxes set the plotted range.

---

## Copy to Clipboard

**Copy** copies the reflection list to the clipboard as text that can be pasted into a spreadsheet such as Excel.

---

## See also

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — defining the standard crystal whose structure factors are calculated.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
- [Beam Interaction in the ReciPro manual](https://seto77.github.io/ReciPro/3-beam-interaction/) — all four tabs of the same window.
