<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Annexe A3. Intégration de l'image

Lors de la conversion d'une image 2D en un profil 1D, le principal problème est de savoir **comment répartir l'intensité d'un pixel qui chevauche plusieurs pas lorsque le pas angulaire de l'intégration est inférieur à l'espacement des pixels (taille de pixel)**. IPAnalyzer traite cette répartition par une **méthode de répartition fondée sur l'aire**.

---

## Méthode de répartition fondée sur l'aire

Dans ce logiciel, le programme calcule les intersections entre les lignes qui délimitent chaque pas (les frontières d'égal angle de diffraction) et les pixels, détermine l'**aire** de chaque pixel comprise dans un pas donné, et répartit l'intensité proportionnellement à cette aire.

![Répartition fondée sur l'aire. Image réelle des anneaux (à gauche) → échelle du pixel (au centre ; les tirets verts sont les frontières des pas) → intersections avec les frontières des pas à l'intérieur d'un seul pixel (à droite ; aires délimitées par les quatre coins et les intersections).](../../assets/references/integration-area-distribution.png){width=680px}

Cette méthode présente les caractéristiques suivantes.

- À l'intérieur de chaque pixel, l'arc de la frontière du pas est **approché par une droite**. Cela est fait pour la rapidité du calcul et ne pose pratiquement jamais de problème.
- Lorsque la correction d'inclinaison et la correction de forme de pixel de l'[A1. Géométrie du détecteur](a1-geometry.md) sont nécessaires, la forme du pixel n'est pas strictement carrée. Le logiciel **calcule donc successivement les coordonnées des quatre coins du pixel** et obtient l'aire d'un quadrilatère (en général, un parallélogramme).

Avec ce schéma, en principe, aussi fin que soit le pas angulaire, l'intensité du pixel est répartie de façon continue entre les pas.

---

## Domaine d'application

Le même algorithme de répartition fondée sur l'aire est utilisé pour les trois types d'intégration suivants. Ils diffèrent par la coordonnée qui reste sur l'axe horizontal de la sortie, et par les pixels qui sont regroupés en un même point de sortie.

| Fonction | Axe horizontal de la sortie | Pixels regroupés en un point de sortie | Usage |
|------|------|------|------|
| **Intégration concentrique (Concentric integration)** | Angle de diffraction $2\theta$ (ou distance interréticulaire) | Ceux compris dans un pas de $2\theta$ (ou de d), sur tous les azimuts à l'intérieur de la région d'intégration | Création d'un profil $2\theta$-intensité ordinaire. |
| **Intégration radiale (Radial integration)** | Azimut $\chi$ | Ceux compris dans un pas azimutal (**Pas d'angle de secteur (pas de balayage) (Sector angle step (Sweep step))**), à l'intérieur de l'anneau défini par **Rayon de l'anneau (Donut radius)** ± **Largeur de l'anneau (Donut width)** | Évaluation de la dépendance azimutale d'un anneau (orientation, distorsion). |
| **Image déroulée (Unrolled image)** | $2\theta$ (horizontal) × azimut $\chi$ (vertical) | Ceux compris dans un pas de $2\theta$ et un secteur azimutal ($360^\circ/N$) | Création d'une image déroulée 2D, l'anneau étant découpé et ouvert. |

Dans tous les cas, seuls les pixels valides sont utilisés : les pixels masqués et les pixels exclus dans l'onglet **Région d'intégration (Integral Region)** ne contribuent pas.

---

## Normalisation après l'intégration

Les intensités réparties sont normalisées différemment selon la fonction.

- **Intégration concentrique** (détecteur à panneau plat, axe en $2\theta$ ou en distance interréticulaire) et **image déroulée** : pour chaque pas (chaque pixel de l'image déroulée), les intensités réparties sont additionnées, et la somme est divisée par la quantité qui a contribué à ce pas. La contribution de chaque partie d'un pixel est mesurée par son aire projetée sur le plan perpendiculaire au rayon diffusé à la distance de la longueur de caméra, c'est-à-dire par l'angle solide qu'elle sous-tend, compté en unités d'un pixel vu de face à la longueur de caméra. Le résultat est donc une intensité moyenne par unité d'angle solide : il ne dépend ni de la largeur du pas ni du nombre de pixels qui tombent dans un pas, et la diminution de l'angle solide par pixel vers les grands angles sur un détecteur plan est compensée. Un pas qui ne reçoit aucun pixel vaut 0.
- **Intégration radiale** : les intensités réparties sont simplement additionnées pour chaque pas azimutal, sans division. Les valeurs augmentent donc avec la largeur de l'anneau (**Largeur de l'anneau (Donut width)**) et avec le pas azimutal.

Pour l'utilisation de chaque fonction, voir [3. Outils](../3-tools.md).
