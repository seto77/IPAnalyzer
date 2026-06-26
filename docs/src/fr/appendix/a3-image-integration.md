<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Annexe A3. Intégration de l'image

Lors de la conversion d'une image 2D en un profil 1D, le plus gros problème est **la manière de répartir l'intensité d'un pixel qui chevauche plusieurs pas lorsque le pas angulaire de l'intégration est inférieur à l'espacement des pixels (taille de pixel)**. IPAnalyzer gère cette répartition à l'aide d'une **méthode de répartition basée sur l'aire**.

---

## Méthode de répartition basée sur l'aire

Dans ce logiciel, le programme calcule les intersections entre les lignes qui délimitent chaque pas (les frontières d'angle de diffraction égal) et les pixels, obtient l'**aire** de chaque pixel comprise dans un pas donné, et répartit l'intensité proportionnellement à cette aire.

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

Cette méthode présente les caractéristiques suivantes.

- À l'intérieur de chaque pixel, l'arc de la frontière de pas est **approximé par une ligne droite**. Cela est fait pour la vitesse de calcul et ne pose presque jamais de problème en pratique.
- Lorsque la correction d'inclinaison et la correction de forme de pixel décrites dans [A1. Géométrie du détecteur](a1-geometry.md) sont nécessaires, la forme du pixel n'est pas strictement carrée. Le logiciel **calcule donc séquentiellement les coordonnées des quatre coins du pixel** et obtient l'aire comme un quadrilatère (en général, un parallélogramme).

Avec ce schéma, en principe, quelle que soit la finesse du pas angulaire, l'intensité du pixel est répartie de manière régulière entre les pas.

---

## Domaine d'application

Le même algorithme de répartition basée sur l'aire est utilisé pour les trois types d'intégration suivants.

| Function | Direction de l'intégration | Utilisation |
|------|-----------|------|
| **Concentric Integration** | Angle de diffraction (direction concentrique) | Création d'un profil $2\theta$-intensité ordinaire. |
| **Radial Integration** | Direction circonférentielle (azimutale) | Évaluation de la dépendance azimutale d'un anneau (orientation, distorsion). |
| **Unrolled Image** | Angle de diffraction × azimut | Création d'une image déroulée 2D avec l'anneau ouvert. |

Pour savoir comment utiliser chaque fonction, voir [3. Outils](../3-tools.md).
