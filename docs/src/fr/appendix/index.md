<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Annexe

Cette annexe résume le **contexte théorique de la géométrie et des algorithmes** utilisés par IPAnalyzer lors de la conversion d'une image de diffraction bidimensionnelle (anneaux de Debye–Scherrer) en un profil unidimensionnel de haute précision. Pour les procédures d'utilisation et l'emploi de chaque fonction, reportez-vous au manuel principal ([0. Aperçu](../0-overview.md), [4. Procédures pratiques](../4-procedures.md), etc.). Nous expliquons ici, à l'aide d'équations, les définitions du système de coordonnées, les transformations de coordonnées, les méthodes de détermination des paramètres et l'algorithme d'intégration qui les sous-tendent.

Le contenu s'appuie sur le document hérité `doc/IPAnalyzerAlgorithm.pdf` inclus dans le paquet de distribution et sur l'implémentation actuelle.

## Structure de l'annexe

- **[A1. Géométrie du détecteur et transformations de coordonnées](a1-geometry.md)** — définition du système de coordonnées dextrogyre, des matrices de rotation décrivant l'inclinaison de l'IP ($\varphi,\ \tau$) et de la correction de la forme de pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Détermination des paramètres](a2-calibration.md)** — calibration de la longueur de caméra, de la longueur d'onde, de la taille de pixel et de l'inclinaison de l'IP à l'aide d'un matériau de référence (méthode à deux distances, méthode à deux lignes, ajustement d'ellipse).
- **[A3. Intégration de l'image](a3-image-integration.md)** — l'algorithme de partitionnement de surface qui répartit les intensités des pixels dans les pas angulaires.
- **[A4. Informations de symétrie](a4-symmetry-information.md)** — symétrie du groupe d'espace, calculs géométriques, positions de Wyckoff, conditions de réflexion et diagrammes des éléments de symétrie du cristal de référence (sous-fenêtre de la fenêtre Crystal).
- **[A5. Facteur de diffusion](a5-scattering-factor.md)** — facteurs de structure et liste des réflexions du cristal de référence (rayons X, électrons, neutrons) (sous-fenêtre de la fenêtre Crystal).

## Système de coordonnées (figure de référence commune)

Chacune des pages suivantes suppose, comme prémisse commune, le même système de coordonnées. L'origine est le spot direct sur l'IP (le point où le faisceau coupe l'IP), l'axe $Z$ est la direction de propagation du faisceau, et l'échantillon est situé en $(0,\ 0,\ -\mathrm{CL})$.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Paramètres principaux

| Symbole | Nom | Signification |
|------|------|------|
| $\lambda$ | Wave Length | Longueur d'onde de la source. Connue pour les rayons X caractéristiques ; pour le rayonnement synchrotron, elle varie selon la position du monochromateur et doit être déterminée à chaque fois. |
| $\mathrm{CL}$ | Camera Length | Distance entre l'échantillon et l'origine (spot direct). La position de l'échantillon est $(0,0,-\mathrm{CL})$. |
| $\varphi,\ \tau$ | Tilt Correction | Inclinaison de l'IP par rapport à l'axe optique (axe $Z$). $\varphi$ est l'azimut de l'axe d'inclinaison dans le plan XY, et $\tau$ est l'angle de rotation autour de cet axe. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | Représente un pixel sous forme de parallélogramme. $\xi$ est le décalage du point de départ du balayage du laser de lecture (angle de distorsion). |

Ces valeurs se règlent dans l'onglet IP Condition de la fenêtre de propriétés (voir [2. Fenêtres de propriétés](../2-property-windows.md)).
