<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# Apéndice A1. Geometría del detector y transformaciones de coordenadas

Esta página define, con ecuaciones, el **sistema de coordenadas, la corrección de la inclinación de la IP y la corrección de la forma del píxel** que IPAnalyzer utiliza para asignar a las posiciones de los píxeles de un detector plano (IP, CCD/CMOS) los ángulos de difracción correspondientes. Para una visión general del sistema de coordenadas, véanse también la [página principal del apéndice](index.md) y [0. Visión general](../0-overview.md).

---

## Sistema de coordenadas y parámetros

IPAnalyzer utiliza internamente, de forma coherente, un sistema de coordenadas **dextrógiro**.

- El punto en que el haz de rayos X o de electrones corta la IP (el **punto directo**) se toma como el origen $(0,0,0)$, y el eje $Z$ se alinea con la dirección de propagación del haz.
- Considerando la muestra infinitesimalmente pequeña, la distancia entre la muestra y el origen se define como la **longitud de cámara** $\mathrm{CL}$. Por tanto, la posición de la muestra es $(0,\ 0,\ -\mathrm{CL})$.
- El eje $X$ se alinea con la dirección de barrido del láser de lectura cuando la IP no está inclinada (la dirección hacia la derecha de la imagen). Por tanto, el eje $Y$ apunta hacia abajo en la pantalla.
- Un anillo de difracción con ángulo de cono $2\theta$ se observa, sobre un plano $XY$ sin inclinar, como un círculo perfecto de radio $\mathrm{CL}\tan 2\theta$.

![Definición del sistema de coordenadas](../../assets/references/geometry-coordinate-system.png){width=520px}

La rotación libre de un objeto 3D requiere en principio tres ejes, pero como la distribución de los anillos de Debye es invariante frente a la rotación alrededor del eje $Z$, el eje $X$ se puede elegir arbitrariamente. Esto elimina un grado de libertad, de modo que la inclinación de la IP se puede expresar con **dos variables** $\varphi,\ \tau$.

!!! note "Correspondencia con (WIN)PIP"
    El programa heredado PIP expresa la inclinación con otro par de ángulos $(\beta,\ \Phi)$. La conversión de $(\beta,\ \Phi)$ a $(\varphi,\ \tau)$ de IPAnalyzer es $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Para más detalles, véase "Relación con (WIN)PIP" en [0. Visión general](../0-overview.md).

---

## Corrección de la inclinación de la IP

La inclinación de la IP respecto al eje óptico (el eje $Z$) se representa mediante una rotación cuyo eje es una recta que pasa por el origen y está contenida en el plano $XY$. Esta rotación se puede escribir como la matriz de rotación $R = R_2\,R_1\,R_2^{-1}$, una operación que gira $\tau$ ($R_1$) alrededor de un eje que se ha girado $\varphi$ alrededor del eje $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Esto equivale a una rotación de ángulo $\tau$ alrededor del vector unitario $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$, que forma un ángulo $\varphi$ con el eje $X$ en el plano $XY$, y al desarrollarla se obtiene

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Transformación directa (plano sin inclinar → IP inclinada)

Un punto $P_1 = (X,\ Y,\ 0)$ del plano $XY$ sin inclinar se transforma en $P_2 = R\,P_1$ sobre la IP inclinada.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Proyección (IP inclinada → plano sin inclinar)

Lo que realmente se necesita es la dirección inversa, es decir, la coordenada del plano $XY$ que ocuparía un "píxel observado sobre la IP inclinada" si no hubiera inclinación. Esta la da la **proyección central (perspectiva)**, que halla el punto $P_3$ en que la recta que une un punto de la IP inclinada con la muestra $(0,0,-\mathrm{CL})$ corta el plano $XY$. Como se trata de una transformación proyectiva con la muestra como centro de proyección, se obtiene

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Como la corrección de inclinación, que incluye la proyección central, es una transformación proyectiva que se puede escribir como una matriz en coordenadas homogéneas, la posición de cada píxel se puede calcular rápidamente en un ordenador.

---

## Corrección de la forma del píxel

La forma del píxel de la IP se trata como un **paralelogramo** de longitud $\mathrm{PixSizeX}$ a lo largo del eje $X$, longitud $\mathrm{PixSizeY}$ a lo largo del eje $Y$ y una desviación respecto al ángulo recto (ángulo de distorsión) $\xi$. Un $\xi$ distinto de cero significa que hay un desplazamiento en la posición de inicio del barrido del láser de lectura, y este programa supone que dicho desplazamiento es constante a lo largo del eje $Y$.

La coordenada real $P$ del píxel situado a $\mathrm{PixNumX}$ en la dirección $X$ y a $\mathrm{PixNumY}$ en la dirección $Y$, contando desde el píxel central, viene dada por

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando esta corrección de la forma del píxel con la corrección de inclinación descrita anteriormente, cualquier píxel de una IP inclinada se puede llevar a su posición correcta sobre el plano $XY$ sin inclinar. Esta correspondencia es la base de la determinación de parámetros del capítulo siguiente y de [A3. Integración de la imagen](a3-image-integration.md).
