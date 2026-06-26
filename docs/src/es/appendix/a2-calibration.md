<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Apéndice A2. Determinación de parámetros

Dado que la posición de cada píxel se rige por la geometría de [A1. Geometría del detector](a1-geometry.md), usar parámetros incorrectos significa leer intensidades en ubicaciones equivocadas. Esta página explica cómo determinar los parámetros verdaderos — longitud de cámara, longitud de onda, tamaño de píxel e inclinación de la IP — a partir de los anillos de difracción de un **material de referencia**. Para las operaciones concretas, consulte [4. Practical procedures](../4-procedures.md) y [6. Parameter calibration (brute force)](../6-find-parameter.md).

---

## Material de referencia

Para la calibración se mide un material de referencia cuyas constantes de red son conocidas. Las condiciones deseables son **muchos anillos de difracción** con una **relación SN alta**, dispuestos de forma **dispersa** y **sin orientación preferente**. Salvo que tenga una preferencia particular, se recomienda un cristal cúbico que contenga átomos pesados como $\mathrm{CeO_2}$ o $\mathrm{Ag}$. Las constantes de red deben conocerse con unas 5 cifras significativas.

---

## Longitud de cámara — método de las dos distancias

La longitud de cámara $\mathrm{CL}$ se define como la distancia que une la muestra y el punto directo sobre la IP. Si toma dos patrones de difracción cambiando la longitud de cámara en $\Delta$, puede determinar el valor absoluto de $\mathrm{CL}$ a partir del cambio en el radio (en píxeles) $r_1,\ r_2$ del mismo anillo. La diferencia de distancia $\Delta$ puede controlarse con precisión con un Magnescale o un dispositivo similar.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

A partir de los triángulos semejantes $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

se obtiene. Aquí $r_1,\ r_2$ pueden permanecer en unidades de píxel, y la longitud de cámara puede obtenerse aunque la corrección de inclinación y la corrección del tamaño de píxel sean algo inexactas, e incluso si las constantes de red del estándar son inexactas. Como la longitud de cámara tiene así poca correlación con los demás parámetros, es el **parámetro que debe determinarse primero**.

---

## Longitud de onda y tamaño de píxel — método de las dos líneas

Si pueden registrarse dos líneas de difracción, los ángulos de difracción $\theta_1,\ \theta_2$ pueden calcularse a partir de la razón de sus posiciones de pico (en píxeles) $p_1,\ p_2$ y de sus d-spacings $d_1,\ d_2$, sin conocer el tamaño de píxel ni la longitud de cámara. Sea la razón de d-spacings $\rho_d = d_1/d_2$ y la razón de posiciones de pico $\rho_p = p_1/p_2$.

A partir de la ley de Bragg y de la geometría del detector plano,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

se cumplen. De la razón de la primera ecuación, $\sin\theta_2 = \rho_d \sin\theta_1$, y de la razón de la segunda ecuación, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Sustituyendo $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ se obtiene una ecuación cuya única incógnita es $\sin\theta_1$:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Esto se reduce a una ecuación cúbica en $\sin^2\theta_1$. Como resolverla analíticamente exigiría manejar números imaginarios, este software la resuelve **numéricamente** para obtener el valor. Dado que $\rho_d$ es una razón de d-spacings, puede determinarse sin error según la simetría del cristal (por ejemplo, en el sistema cúbico).

Una vez obtenidos los ángulos de difracción, la longitud de cámara puede determinarse de forma independiente mediante el método de las dos distancias descrito arriba, de modo que la longitud de onda $\lambda$ y el tamaño de píxel $\mathrm{PixSize}$ también pueden calcularse fácilmente a partir de las dos ecuaciones anteriores.

!!! note "Cuando hay inclinación"
    Si la IP está inclinada, la relación $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ deja de cumplirse, por lo que no pueden obtenerse los valores exactos tal cual. En este caso, **realice la corrección de inclinación y la corrección de longitud de onda de forma alternada** para hacer converger la solución iterativamente hacia el valor verdadero.

---

## Inclinación de la IP — ajuste de elipse

Un anillo con ángulo de cono $2\theta$ debería observarse como un círculo verdadero de radio $R_0 = \mathrm{CL}\tan 2\theta$ sobre un plano $XY$ sin inclinar. Sin embargo, sobre una IP inclinada, el anillo se convierte en una **elipse** y, además, su centro no coincide con el centro del haz (el punto directo).

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Sobre un plano de IP inclinado en $\varphi,\ \tau$, un punto $(x,y)$ del anillo satisface una cónica general (elipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Los coeficientes $A,B,C,D,E$ pueden escribirse como funciones de $\varphi,\ \tau,\ \mathrm{CL},\ R_0$, y pueden tratarse con álgebra lineal elemental como sigue.

- El **centro de la elipse** $(x_c, y_c)$ es la solución de la condición de que el gradiente se anule, es decir, las ecuaciones lineales simultáneas
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Las **direcciones y longitudes de los ejes mayor y menor** se obtienen resolviendo el problema de valores propios de la matriz simétrica $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

A partir de estos, la inclinación se determina como sigue.

1. **Azimut $\varphi$**: El desplazamiento del centro de la elipse ocurre a lo largo de la dirección de máxima inclinación (la dirección de gradiente máximo), y el eje de inclinación es ortogonal a ella. Por lo tanto, la dirección del eje de inclinación viene dada por $(-y_c,\ x_c)$, a partir de lo cual se determina $\varphi$.
2. **Magnitud de la inclinación $\tau$**: Considerando la figura proyectada a lo largo de la dirección $\varphi$ (la figura anterior), la distancia $R$ desde el punto directo hasta el centro de la elipse satisface una función de la longitud de cámara, la magnitud de la inclinación y el ángulo de difracción:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Resuelva esta ecuación para $\tau$. Cuando se dispone de varios anillos de difracción, tome el **promedio ponderado** de los $\tau$ obtenidos de cada anillo como valor verdadero.
