<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). -->

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

Le même algorithme de répartition fondée sur l'aire est utilisé pour les trois types d'intégration suivants.

| Fonction | Direction d'intégration | Usage |
|------|-----------|------|
| **Intégration concentrique (Concentric Integration)** | Angle de diffraction (direction concentrique) | Création d'un profil $2\theta$-intensité ordinaire. |
| **Intégration radiale (Radial Integration)** | Direction circonférentielle (azimutale) | Évaluation de la dépendance azimutale d'un anneau (orientation, distorsion). |
| **Image déroulée (Unrolled Image)** | Angle de diffraction × azimut | Création d'une image déroulée 2D, l'anneau étant découpé et ouvert. |

Pour l'utilisation de chaque fonction, voir [3. Outils](../3-tools.md).
