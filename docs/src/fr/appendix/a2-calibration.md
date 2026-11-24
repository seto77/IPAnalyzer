<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# Annexe A2. Détermination des paramètres

Comme la position de chaque pixel est régie par la géométrie de l'[A1. Géométrie du détecteur](a1-geometry.md), utiliser des paramètres incorrects revient à lire les intensités aux mauvais endroits. Cette page explique comment déterminer les vrais paramètres — longueur de caméra, longueur d'onde, taille de pixel et inclinaison de l'IP — à partir des anneaux de diffraction d'un **matériau de référence**. Pour les opérations concrètes, voir [4. Procédures](../4-procedures.md) et [6. Recherche de paramètres (force brute)](../6-find-parameter.md).

---

## Matériau de référence

Pour la calibration, on mesure un matériau de référence dont les paramètres de maille sont connus. Les conditions souhaitables sont : **de nombreux anneaux de diffraction**, un **rapport signal/bruit élevé**, des anneaux **espacés** et **aucune orientation préférentielle**. Sauf préférence particulière, un cristal cubique contenant des atomes lourds, tel que $\mathrm{CeO_2}$ ou $\mathrm{Ag}$, est recommandé. Les paramètres de maille doivent être connus à environ 5 chiffres significatifs.

---

## Longueur de caméra — méthode des deux distances

La longueur de caméra $\mathrm{CL}$ est définie comme la distance entre l'échantillon et le spot direct sur l'IP. Si l'on enregistre deux clichés de diffraction en modifiant la longueur de caméra de $\Delta$, on peut déterminer la valeur absolue de $\mathrm{CL}$ à partir de la variation du rayon $r_1,\ r_2$ d'un même anneau. La différence de distance $\Delta$ peut être contrôlée avec précision à l'aide d'un Magnescale ou d'un dispositif analogue.

![Détermination de la longueur de caméra par deux distances. Le même anneau est enregistré à deux positions, aux distances CL et CL+Δ de l'échantillon, et CL est obtenue à partir des rayons r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

D'après les triangles semblables $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ (avec $r_i$ dans la même unité de longueur que $\mathrm{CL}$), on obtient

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

Ici, $r_1,\ r_2$ peuvent rester en unités de pixels, et la longueur de caméra peut être obtenue même si la correction d'inclinaison et la correction de taille de pixel sont quelque peu inexactes, et même si les paramètres de maille du matériau de référence sont inexacts. Comme la longueur de caméra est ainsi peu corrélée aux autres paramètres, c'est le **paramètre à déterminer en premier**.

---

## Longueur d'onde et taille de pixel — méthode des deux raies

Si deux raies de diffraction peuvent être enregistrées, les angles de Bragg $\theta_1,\ \theta_2$ peuvent être calculés à partir du rapport de leurs positions de pic (en pixels) $p_1,\ p_2$ et de leurs distances interréticulaires $d_1,\ d_2$, sans connaître la taille de pixel ni la longueur de caméra. Notons $\rho_d = d_1/d_2$ le rapport des distances interréticulaires et $\rho_p = p_1/p_2$ le rapport des positions de pic.

D'après la loi de Bragg et la géométrie du détecteur plan,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

sont vérifiées. Le rapport de la première équation donne $\sin\theta_2 = \rho_d \sin\theta_1$, et le rapport de la seconde donne $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. En substituant $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$, on obtient une équation dont la seule inconnue est $\sin\theta_1$ :

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Elle se ramène à une équation du troisième degré en $\sin^2\theta_1$. Comme sa résolution analytique exigerait de manipuler des nombres imaginaires, ce logiciel la résout **numériquement** pour obtenir la valeur. Comme $\rho_d$ est un rapport de distances interréticulaires, il peut être déterminé sans erreur selon la symétrie du cristal (par exemple dans le système cubique).

Une fois les angles de diffraction obtenus, la longueur de caméra pouvant être déterminée indépendamment par la méthode des deux distances décrite ci-dessus, la longueur d'onde $\lambda$ et la taille de pixel $\mathrm{PixSize}$ se calculent aussi facilement à partir des deux équations ci-dessus.

!!! note "En présence d'une inclinaison"
    Si l'IP est inclinée, la relation $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ n'est plus valable, et les valeurs exactes ne peuvent donc pas être obtenues telles quelles. Dans ce cas, **effectuez alternativement la correction d'inclinaison et la correction de longueur d'onde** pour faire converger la solution de manière itérative vers la vraie valeur.

---

## Inclinaison de l'IP — ajustement d'ellipse

Un anneau d'angle de cône $2\theta$ devrait être observé comme un cercle parfait de rayon $R_0 = \mathrm{CL}\tan 2\theta$ sur un plan $XY$ non incliné. Sur une IP inclinée, cependant, l'anneau devient une **ellipse**, et de plus son centre ne coïncide pas avec le centre du faisceau (le spot direct).

![Sur une IP inclinée, l'anneau de diffraction devient une ellipse et son centre est décalé par rapport au spot direct (projection vue selon la direction φ).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Sur un plan d'IP incliné de $\varphi,\ \tau$, un point $(x,y)$ de l'anneau satisfait une conique générale (ellipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Les coefficients $A,B,C,D,E$ peuvent s'écrire comme des fonctions de $\varphi,\ \tau,\ \mathrm{CL},\ R_0$, et se traitent par l'algèbre linéaire élémentaire comme suit.

- Le **centre de l'ellipse** $(x_c, y_c)$ est la solution de la condition d'annulation du gradient, c'est-à-dire du système d'équations linéaires
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Les **directions et longueurs du grand axe et du petit axe** s'obtiennent en résolvant le problème aux valeurs propres de la matrice symétrique $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

On en déduit l'inclinaison comme suit.

1. **Azimut $\varphi$** : le déplacement du centre de l'ellipse se produit selon la direction de plus grande pente (direction du gradient maximal), et l'axe d'inclinaison lui est orthogonal. La direction de l'axe d'inclinaison est donc donnée par $(-y_c,\ x_c)$, d'où l'on détermine $\varphi$.
2. **Amplitude de l'inclinaison $\tau$** : en considérant la figure projetée selon la direction $\varphi$ (figure ci-dessus), la distance $R$ entre le spot direct et le centre de l'ellipse satisfait une fonction de la longueur de caméra, de l'amplitude de l'inclinaison et de l'angle de diffraction :

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Résolvez cette équation en $\tau$. Lorsque plusieurs anneaux de diffraction sont disponibles, prenez la **moyenne pondérée** des $\tau$ obtenus pour chaque anneau comme vraie valeur.
