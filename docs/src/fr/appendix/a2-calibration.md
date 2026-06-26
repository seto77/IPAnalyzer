<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Annexe A2. Détermination des paramètres

Comme la position de chaque pixel est régie par la géométrie décrite dans [A1. Géométrie du détecteur](a1-geometry.md), l'utilisation de paramètres incorrects revient à lire les intensités à de mauvais emplacements. Cette page explique comment déterminer les véritables paramètres — longueur de caméra, longueur d'onde, taille de pixel et inclinaison de l'IP — à partir des anneaux de diffraction d'un **matériau de référence**. Pour les opérations concrètes, voir [4. Procédures pratiques](../4-procedures.md) et [6. Calibration des paramètres (force brute)](../6-find-parameter.md).

---

## Matériau de référence

Pour la calibration, on mesure un matériau de référence dont les constantes de maille sont connues. Les conditions souhaitables sont **de nombreux anneaux de diffraction** avec un **rapport signal/bruit élevé**, répartis de manière **éparse** et sans **orientation préférentielle**. Sauf préférence particulière, on recommande un cristal cubique contenant des atomes lourds tels que $\mathrm{CeO_2}$ ou $\mathrm{Ag}$. Les constantes de maille doivent être connues à environ 5 chiffres significatifs.

---

## Longueur de caméra — méthode des deux distances

La longueur de caméra $\mathrm{CL}$ est définie comme la distance reliant l'échantillon et la tache directe sur l'IP. Si vous prenez deux clichés de diffraction en modifiant la longueur de caméra de $\Delta$, vous pouvez déterminer la valeur absolue de $\mathrm{CL}$ à partir de la variation du rayon (en pixels) $r_1,\ r_2$ d'un même anneau. La différence de distance $\Delta$ peut être contrôlée avec précision à l'aide d'un Magnescale ou d'un dispositif similaire.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

À partir des triangles semblables $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

est obtenue. Ici $r_1,\ r_2$ peuvent rester en unités de pixels, et la longueur de caméra peut être obtenue même si la correction d'inclinaison et la correction de taille de pixel sont quelque peu imprécises, et même si les constantes de maille de la référence sont imprécises. Comme la longueur de caméra présente ainsi peu de corrélation avec les autres paramètres, c'est le **paramètre qui doit être déterminé en premier**.

---

## Longueur d'onde et taille de pixel — méthode des deux raies

Si deux raies de diffraction peuvent être enregistrées, les angles de diffraction $\theta_1,\ \theta_2$ peuvent être calculés à partir du rapport de leurs positions de pic (en pixels) $p_1,\ p_2$ et de leurs distances réticulaires $d_1,\ d_2$, sans connaître la taille de pixel ni la longueur de caméra. Soit le rapport des distances réticulaires $\rho_d = d_1/d_2$ et le rapport des positions de pic $\rho_p = p_1/p_2$.

D'après la loi de Bragg et la géométrie du détecteur plat,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

sont valables. À partir du rapport de la première équation, $\sin\theta_2 = \rho_d \sin\theta_1$, et à partir du rapport de la seconde équation, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. En substituant $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$, on obtient une équation dont la seule inconnue est $\sin\theta_1$ :

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Ceci se réduit à une équation cubique en $\sin^2\theta_1$. Comme sa résolution analytique nécessiterait de manipuler des nombres imaginaires, ce logiciel la résout **numériquement** pour en obtenir la valeur. Puisque $\rho_d$ est un rapport de distances réticulaires, il peut être déterminé sans erreur selon la symétrie du cristal (par exemple, dans le système cubique).

Une fois les angles de diffraction obtenus, la longueur de caméra peut être déterminée de manière indépendante par la méthode des deux distances décrite ci-dessus, de sorte que la longueur d'onde $\lambda$ et la taille de pixel $\mathrm{PixSize}$ peuvent également être calculées facilement à partir des deux équations ci-dessus.

!!! note "When there is a tilt"
    Si l'IP est inclinée, la relation $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ n'est plus valable, de sorte que les valeurs exactes ne peuvent pas être obtenues telles quelles. Dans ce cas, **effectuez alternativement la correction d'inclinaison et la correction de longueur d'onde** afin de faire converger la solution itérativement vers la valeur véritable.

---

## Inclinaison de l'IP — ajustement d'ellipse

Un anneau d'angle de cône $2\theta$ devrait être observé comme un cercle parfait de rayon $R_0 = \mathrm{CL}\tan 2\theta$ sur un plan $XY$ non incliné. Sur une IP inclinée, cependant, l'anneau devient une **ellipse**, et de plus son centre ne coïncide pas avec le centre du faisceau (la tache directe).

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Sur un plan d'IP incliné de $\varphi,\ \tau$, un point $(x,y)$ de l'anneau satisfait une conique générale (ellipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Les coefficients $A,B,C,D,E$ peuvent s'écrire comme des fonctions de $\varphi,\ \tau,\ \mathrm{CL},\ R_0$, et peuvent être traités par de l'algèbre linéaire élémentaire comme suit.

- Le **centre de l'ellipse** $(x_c, y_c)$ est la solution de la condition d'annulation du gradient, c'est-à-dire le système d'équations linéaires
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Les **directions et longueurs des axes majeur et mineur** s'obtiennent en résolvant le problème aux valeurs propres de la matrice symétrique $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

À partir de cela, l'inclinaison est déterminée comme suit.

1. **Azimut $\varphi$** : Le déplacement du centre de l'ellipse se produit le long de la direction de plus forte inclinaison (la direction de gradient maximal), et l'axe d'inclinaison lui est orthogonal. Par conséquent, la direction de l'axe d'inclinaison est donnée par $(-y_c,\ x_c)$, d'où $\varphi$ est déterminé.
2. **Amplitude de l'inclinaison $\tau$** : En considérant la figure projetée le long de la direction $\varphi$ (la figure ci-dessus), la distance $R$ de la tache directe au centre de l'ellipse satisfait une fonction de la longueur de caméra, de l'amplitude de l'inclinaison et de l'angle de diffraction :

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Résolvez cette équation pour $\tau$. Lorsque plusieurs anneaux de diffraction sont disponibles, prenez la **moyenne pondérée** des $\tau$ obtenus à partir de chaque anneau comme valeur véritable.
