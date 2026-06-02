<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Appendix A2. Parameter determination

Because the position of each pixel is governed by the geometry of [A1. Detector geometry](a1-geometry.md), using incorrect parameters means reading intensities at the wrong locations. This page explains how to determine the true parameters — camera length, wavelength, pixel size, and IP tilt — from the diffraction rings of a **standard material**. For the actual operations, see [4. Practical procedures](../4-procedures.md) and [6. Parameter calibration (brute force)](../6-find-parameter.md).

---

## Standard material

For calibration, you measure a standard material whose lattice constants are known. The desirable conditions are **many diffraction rings** with a **high SN ratio**, positioned **sparsely**, and with **no preferred orientation**. Unless you have a particular preference, a cubic crystal containing heavy atoms such as $\mathrm{CeO_2}$ or $\mathrm{Ag}$ is recommended. The lattice constants must be known to about 5 significant figures.

---

## Camera length — two-distance method

The camera length $\mathrm{CL}$ is defined as the distance connecting the sample and the direct spot on the IP. If you take two diffraction patterns while changing the camera length by $\Delta$, you can determine the absolute value of $\mathrm{CL}$ from the change in the radius (in pixels) $r_1,\ r_2$ of the same ring. The distance difference $\Delta$ can be controlled accurately with a Magnescale or similar device.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

From the similar triangles $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

is obtained. Here $r_1,\ r_2$ may remain in pixel units, and the camera length can be obtained even if the tilt correction and pixel-size correction are somewhat inaccurate, and even if the lattice constants of the standard are inaccurate. Because the camera length thus has little correlation with the other parameters, it is the **parameter that should be determined first**.

---

## Wavelength and pixel size — two-line method

If two diffraction lines can be recorded, the diffraction angles $\theta_1,\ \theta_2$ can be calculated from the ratio of their peak positions (in pixels) $p_1,\ p_2$ and their d-spacings $d_1,\ d_2$, without knowing the pixel size or the camera length. Let the d-spacing ratio be $\rho_d = d_1/d_2$ and the peak-position ratio be $\rho_p = p_1/p_2$.

From Bragg's law and the geometry of the flat detector,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

hold. From the ratio of the first equation, $\sin\theta_2 = \rho_d \sin\theta_1$, and from the ratio of the second equation, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Substituting $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ yields an equation whose only unknown is $\sin\theta_1$:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

This reduces to a cubic equation in $\sin^2\theta_1$. Because solving it analytically would require handling imaginary numbers, this software solves it **numerically** to obtain the value. Since $\rho_d$ is a ratio of d-spacings, it can be determined without error depending on the crystal symmetry (for example, in the cubic system).

Once the diffraction angles are obtained, the camera length can be determined independently by the two-distance method described above, so the wavelength $\lambda$ and the pixel size $\mathrm{PixSize}$ can also be calculated easily from the two equations above.

!!! note "When there is a tilt"
    If the IP is tilted, the relation $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ breaks down, so the accurate values cannot be obtained as is. In this case, **perform the tilt correction and the wavelength correction alternately** to converge the solution iteratively toward the true value.

---

## IP tilt — ellipse fitting

A ring with cone angle $2\theta$ should be observed as a true circle of radius $R_0 = \mathrm{CL}\tan 2\theta$ on an untilted $XY$ plane. On a tilted IP, however, the ring becomes an **ellipse**, and furthermore its center does not coincide with the beam center (the direct spot).

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

On an IP plane tilted by $\varphi,\ \tau$, a point $(x,y)$ on the ring satisfies a general conic (ellipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

The coefficients $A,B,C,D,E$ can be written as functions of $\varphi,\ \tau,\ \mathrm{CL},\ R_0$, and can be handled with elementary linear algebra as follows.

- The **center of the ellipse** $(x_c, y_c)$ is the solution of the condition that the gradient vanishes, i.e. the simultaneous linear equations
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- The **directions and lengths of the major and minor axes** are obtained by solving the eigenvalue problem of the symmetric matrix $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

From these, the tilt is determined as follows.

1. **Azimuth $\varphi$**: The displacement of the ellipse center occurs along the direction of steepest tilt (the maximum-gradient direction), and the tilt axis is orthogonal to it. Therefore the direction of the tilt axis is given by $(-y_c,\ x_c)$, from which $\varphi$ is determined.
2. **Tilt magnitude $\tau$**: Considering the figure projected along the $\varphi$ direction (the figure above), the distance $R$ from the direct spot to the ellipse center satisfies a function of the camera length, the tilt magnitude, and the diffraction angle:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Solve this equation for $\tau$. When multiple diffraction rings are available, take the **weighted average** of the $\tau$ obtained from each ring as the true value.
