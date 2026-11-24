<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Annexe

Cette annexe résume le **contexte théorique de la géométrie et des algorithmes** qu'IPAnalyzer utilise pour convertir une image de diffraction bidimensionnelle (anneaux de Debye–Scherrer) en un profil 1D de haute précision. Pour les procédures d'utilisation et l'emploi de chaque fonction, reportez-vous au manuel principal ([0. Aperçu](../0-overview.md), [4. Procédures](../4-procedures.md), etc.). Nous expliquons ici, à l'aide d'équations, les définitions du système de coordonnées, les transformations de coordonnées, les méthodes de détermination des paramètres et l'algorithme d'intégration sous-jacents.

Le contenu s'appuie sur l'ancien document `doc/IPAnalyzerAlgorithm.pdf` fourni dans le paquet de distribution et sur l'implémentation actuelle.

## Structure de l'annexe

- **[A1. Géométrie du détecteur et transformations de coordonnées](a1-geometry.md)** — définition du système de coordonnées direct, matrices de rotation décrivant l'inclinaison de l'IP ($\varphi,\ \tau$) et correction de la forme du pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Détermination des paramètres](a2-calibration.md)** — calibration de la longueur de caméra, de la longueur d'onde, de la taille de pixel et de l'inclinaison de l'IP à l'aide d'un matériau de référence (méthode des deux distances, méthode des deux raies, ajustement d'ellipse).
- **[A3. Intégration de l'image](a3-image-integration.md)** — l'algorithme de partition par aire qui répartit les intensités des pixels entre les pas angulaires, et la normalisation après l'intégration.
- **[A4. Informations de symétrie](a4-symmetry-information.md)** — symétrie du groupe d'espace, calculs géométriques, positions de Wyckoff, conditions de réflexion et diagrammes des éléments de symétrie du cristal de référence (une sous-fenêtre de la fenêtre Crystal).
- **[A5. Facteur de diffusion](a5-scattering-factor.md)** — facteurs de structure et liste des réflexions du cristal de référence (rayons X, électrons, neutrons) (l'onglet **Réflexions (Reflections)** de **Interaction du faisceau (Beam interaction)** dans la fenêtre Crystal).

## Système de coordonnées (figure de référence commune)

Chacune des pages suivantes repose sur le même système de coordonnées. L'origine est le spot direct sur l'IP (le point où le faisceau coupe l'IP), l'axe $Z$ est la direction de propagation du faisceau, et l'échantillon se trouve en $(0,\ 0,\ -\mathrm{CL})$.

![Système de coordonnées d'IPAnalyzer. On y voit l'IP (imaging plate), les axes X / Y / Z, les anneaux de Debye, les angles d'inclinaison φ et τ, l'échantillon en (0,0,−CL), la longueur de caméra CL, l'angle de diffraction 2θ, la longueur d'onde λ et la forme du pixel (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Paramètres principaux

| Symbole | Nom | Signification |
|------|------|------|
| $\lambda$ | Longueur d'onde (Wave Length) | Longueur d'onde de la source. Connue pour les rayons X caractéristiques ; pour le rayonnement synchrotron, elle varie avec la position du monochromateur et doit être déterminée à chaque fois. |
| $\mathrm{CL}$ | Longueur de caméra (Camera Length) | Distance entre l'échantillon et l'origine (spot direct). La position de l'échantillon est $(0,0,-\mathrm{CL})$. Correspond à **Longueur de caméra 1 (Camera Length 1)** à l'écran ; **Longueur de caméra 2 (Camera Length 2)** est la distance perpendiculaire de l'échantillon au détecteur, qui diffère en présence d'une inclinaison $\tau$. |
| $\varphi,\ \tau$ | Correction d'inclinaison (Tilt Correction) | Inclinaison de l'IP par rapport à l'axe optique (axe $Z$). $\varphi$ est l'azimut de l'axe d'inclinaison dans le plan XY, et $\tau$ l'angle de rotation autour de cet axe. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Taille de pixel (Pixel Size) | Représente un pixel comme un parallélogramme. $\xi$ est le décalage du point de départ du balayage du laser de lecture (angle de distorsion). |

La longueur d'onde se règle dans l'onglet **Source d'onde (Wave source)** de la fenêtre de propriétés, et la longueur de caméra, l'inclinaison et la forme du pixel dans l'onglet **Condition du détecteur (Detector condition)** (voir [2. Fenêtres de propriétés](../2-property-windows.md)).
