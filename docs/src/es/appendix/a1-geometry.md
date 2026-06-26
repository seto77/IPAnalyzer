<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Apéndice A1. Geometría del detector y transformaciones de coordenadas

Esta página define, mediante ecuaciones, el **sistema de coordenadas, la corrección de inclinación de la IP y la corrección de la forma de píxel** que IPAnalyzer utiliza para mapear las posiciones de los píxeles en un detector plano (IP, CCD/CMOS) a ángulos de difracción. Para una visión general del sistema de coordenadas, véanse también la [página principal del apéndice](index.md) y [0. Overview](../0-overview.md).

---

## Sistema de coordenadas y parámetros

IPAnalyzer utiliza de forma coherente un sistema de coordenadas **dextrógiro** (right-handed) internamente.

- El punto donde el haz de rayos X o de electrones intersecta la IP (el **direct spot**) se toma como el origen $(0,0,0)$, y el eje $Z$ se alinea con la dirección de propagación del haz.
- Tratando la muestra como infinitesimalmente pequeña, la distancia entre la muestra y el origen se define como la **longitud de cámara** $\mathrm{CL}$. La posición de la muestra es, por tanto, $(0,\ 0,\ -\mathrm{CL})$.
- El eje $X$ se alinea con la dirección de barrido del láser de lectura cuando la IP no está inclinada (la dirección hacia la derecha de la imagen). El eje $Y$, por consiguiente, apunta hacia abajo en la pantalla.
- Un anillo de difracción con ángulo de cono $2\theta$ se observa, en un plano $XY$ no inclinado, como un círculo perfecto de radio $\mathrm{CL}\tan 2\theta$.

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

La rotación libre de un objeto 3D requiere intrínsecamente tres ejes, pero como la distribución del anillo de Debye es invariante bajo rotación alrededor del eje $Z$, el eje $X$ puede elegirse arbitrariamente. Esto elimina un grado de libertad, de modo que la inclinación de la IP puede expresarse con **dos variables** $\varphi,\ \tau$.

!!! note "Correspondence with (WIN)PIP"
    El software heredado PIP expresa la inclinación con un par diferente de ángulos $(\beta,\ \Phi)$. La conversión de $(\beta,\ \Phi)$ a los $(\varphi,\ \tau)$ de IPAnalyzer es $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Para más detalles, véase "Relationship with (WIN)PIP" en [0. Overview](../0-overview.md).

---

## Corrección de inclinación de la IP

La inclinación de la IP respecto al eje óptico (el eje $Z$) se representa mediante una rotación cuyo eje es una recta que pasa por el origen y se sitúa en el plano $XY$. Esta rotación puede escribirse como la matriz de rotación $R = R_2\,R_1\,R_2^{-1}$, una operación que rota un ángulo $\tau$ a lo largo de ($R_1$) un eje que ha sido rotado un ángulo $\varphi$ alrededor del eje $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Esto equivale a una rotación de ángulo $\tau$ alrededor del vector unitario $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ que forma un ángulo $\varphi$ con el eje $X$ en el plano $XY$, y al desarrollarla se obtiene

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Transformación directa (plano no inclinado → IP inclinada)

Un punto $P_1 = (X,\ Y,\ 0)$ en el plano $XY$ no inclinado se mapea a $P_2 = R\,P_1$ en la IP inclinada.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Proyección (IP inclinada → plano no inclinado)

Lo que realmente se necesita es la dirección inversa, es decir, la coordenada en el plano $XY$ que ocuparía un "píxel observado en la IP inclinada" si no hubiera inclinación. Esto viene dado por la **proyección central (en perspectiva)** que encuentra el punto $P_3$ donde la recta que une un punto de la IP inclinada con la muestra $(0,0,-\mathrm{CL})$ intersecta el plano $XY$. Dado que se trata de una transformación proyectiva con la muestra como centro de proyección, resulta

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Como toda la corrección de inclinación es una transformación lineal (proyectiva en coordenadas homogéneas), la posición de cada píxel puede calcularse rápidamente en un ordenador.

---

## Corrección de la forma de píxel

La forma de píxel de la IP se trata como un **paralelogramo** con longitud $\mathrm{PixSizeX}$ a lo largo del eje $X$, longitud $\mathrm{PixSizeY}$ a lo largo del eje $Y$, y una desviación del ángulo recto (ángulo de distorsión) $\xi$. Un $\xi$ distinto de cero significa que existe un desplazamiento en la posición de inicio del barrido del láser de lectura, y este software supone que dicho desplazamiento es constante a lo largo del eje $Y$.

La coordenada real $P$ del píxel que está a $\mathrm{PixNumX}$ de distancia en la dirección $X$ y a $\mathrm{PixNumY}$ de distancia en la dirección $Y$, contando desde el píxel central, viene dada por

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando esta corrección de la forma de píxel con la corrección de inclinación descrita anteriormente, cualquier píxel de una IP inclinada puede mapearse a su posición correcta en el plano $XY$ no inclinado. Este mapeo es la base para la determinación de parámetros del capítulo siguiente y para [A3. Image integration](a3-image-integration.md).
