<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Annexe A1. Géométrie du détecteur et transformations de coordonnées

Cette page définit, à l'aide d'équations, le **système de coordonnées, la correction d'inclinaison de l'IP et la correction de forme de pixel** qu'IPAnalyzer utilise pour faire correspondre les positions de pixels sur un détecteur plat (IP, CCD/CMOS) aux angles de diffraction. Pour un aperçu du système de coordonnées, voir également la [page d'accueil de l'annexe](index.md) et [0. Aperçu](../0-overview.md).

---

## Système de coordonnées et paramètres

IPAnalyzer utilise systématiquement, en interne, un système de coordonnées **dextrogyre (main droite)**.

- Le point où le faisceau de rayons X ou d'électrons coupe l'IP (le **direct spot**) est pris comme origine $(0,0,0)$, et l'axe $Z$ est aligné avec la direction de propagation du faisceau.
- En traitant l'échantillon comme infiniment petit, la distance entre l'échantillon et l'origine est définie comme la **longueur de caméra** $\mathrm{CL}$. La position de l'échantillon est donc $(0,\ 0,\ -\mathrm{CL})$.
- L'axe $X$ est aligné avec la direction de balayage du laser de lecture lorsque l'IP n'est pas inclinée (la direction vers la droite de l'image). L'axe $Y$ pointe donc vers le bas à l'écran.
- Un anneau de diffraction de demi-angle au sommet $2\theta$ est observé, sur un plan $XY$ non incliné, comme un cercle parfait de rayon $\mathrm{CL}\tan 2\theta$.

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

La rotation libre d'un objet 3D nécessite intrinsèquement trois axes, mais comme la distribution de l'anneau de Debye est invariante par rotation autour de l'axe $Z$, l'axe $X$ peut être choisi arbitrairement. Cela supprime un degré de liberté, de sorte que l'inclinaison de l'IP peut être exprimée à l'aide de **deux variables** $\varphi,\ \tau$.

!!! note "Correspondance avec (WIN)PIP"
    Le logiciel hérité PIP exprime l'inclinaison à l'aide d'un autre couple d'angles $(\beta,\ \Phi)$. La conversion de $(\beta,\ \Phi)$ vers le couple $(\varphi,\ \tau)$ d'IPAnalyzer est $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Pour plus de détails, voir « Relationship with (WIN)PIP » dans [0. Aperçu](../0-overview.md).

---

## Correction d'inclinaison de l'IP

L'inclinaison de l'IP par rapport à l'axe optique (l'axe $Z$) est représentée par une rotation dont l'axe est une droite passant par l'origine et située dans le plan $XY$. Cette rotation peut s'écrire sous la forme de la matrice de rotation $R = R_2\,R_1\,R_2^{-1}$, une opération qui effectue une rotation de $\tau$ autour ($R_1$) d'un axe qui a été tourné de $\varphi$ autour de l'axe $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Cela équivaut à une rotation d'angle $\tau$ autour du vecteur unitaire $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ qui fait un angle $\varphi$ avec l'axe $X$ dans le plan $XY$, et le développement donne

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Transformation directe (plan non incliné → IP inclinée)

Un point $P_1 = (X,\ Y,\ 0)$ sur le plan $XY$ non incliné se transforme en $P_2 = R\,P_1$ sur l'IP inclinée.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projection (IP inclinée → plan non incliné)

Ce qui est réellement nécessaire, c'est la direction inverse, à savoir la coordonnée dans le plan $XY$ qu'occuperait un « pixel observé sur l'IP inclinée » s'il n'y avait pas d'inclinaison. Elle est donnée par la **projection centrale (perspective)** qui détermine le point $P_3$ où la droite joignant un point de l'IP inclinée et l'échantillon $(0,0,-\mathrm{CL})$ coupe le plan $XY$. Comme il s'agit d'une transformation projective ayant l'échantillon pour centre de projection,

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

en résulte. Comme l'ensemble de la correction d'inclinaison est une transformation linéaire (projective en coordonnées homogènes), la position de chaque pixel peut être calculée rapidement sur un ordinateur.

---

## Correction de forme de pixel

La forme du pixel de l'IP est traitée comme un **parallélogramme** de longueur $\mathrm{PixSizeX}$ le long de l'axe $X$, de longueur $\mathrm{PixSizeY}$ le long de l'axe $Y$, et présentant un écart à l'angle droit (angle de distorsion) $\xi$. Un $\xi$ non nul signifie qu'il existe un décalage de la position de départ du balayage du laser de lecture, et ce logiciel suppose que ce décalage est constant le long de l'axe $Y$.

La coordonnée réelle $P$ du pixel situé à $\mathrm{PixNumX}$ dans la direction $X$ et à $\mathrm{PixNumY}$ dans la direction $Y$, en comptant à partir du pixel central, est donnée par

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

En combinant cette correction de forme de pixel avec la correction d'inclinaison décrite ci-dessus, tout pixel d'une IP inclinée peut être mis en correspondance avec sa position correcte sur le plan $XY$ non incliné. Cette correspondance constitue la base de la détermination des paramètres au chapitre suivant et de [A3. Intégration de l'image](a3-image-integration.md).
