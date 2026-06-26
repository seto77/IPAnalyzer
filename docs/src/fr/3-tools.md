<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Outils

Cette page décrit les outils auxiliaires lancés depuis la barre d'outils verticale à droite de la fenêtre principale, ou depuis les menus. Pour des procédures concrètes utilisant la calibration des paramètres et les macros, voir [Procédures](4-procedures.md).

## Intensity Table

Un outil qui compare les distributions d'intensité de deux images et optimise une table de conversion d'intensité. Il optimise 16 points de contrôle sur 300 itérations afin de faire correspondre les deux intensités tout en préservant l'intensité intégrée totale. Il est utilisé, par exemple, pour calibrer la réponse en intensité d'un détecteur.

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

Un outil qui surveille un dossier, charge automatiquement les nouvelles images et exécute une séquence d'opérations après le chargement.

- **Watch and auto-load** : surveille le dossier spécifié (y compris les sous-dossiers) et lit un fichier une fois son écriture terminée. Les fichiers peuvent être filtrés par nom (correspondance de numéro, mot-clé).
- **Auto execution** : exécute les étapes cochées, dans l'ordre, parmi Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro.

Cela permet des usages tels que surveiller un dossier de sortie pendant une expérience et intégrer automatiquement chaque image à mesure qu'elle arrive. Voir [Procédures](4-procedures.md) pour les détails.

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

Dessine un anneau à une distance, un angle ou une valeur d spécifiés sur l'image, en tenant compte de l'inclinaison de l'IP et de la distorsion des pixels. Cliquez sur l'un des **R (mm)** / **2θ (°)** / **d (Å)** pour choisir quelle valeur éditer ; les autres sont calculées automatiquement à partir de la longueur d'onde et de la longueur de caméra.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

Déplie l'image de diffraction depuis des coordonnées polaires centrées sur le spot direct vers des coordonnées cartésiennes (axe horizontal = angle, distance ou valeur d ; axe vertical = azimut). Cela se configure désormais non pas avec une fenêtre dédiée, mais avec le bouton **Unroll** de la barre d'outils et l'onglet **Unrolled Image Option** des propriétés. Le dépliage utilise le même algorithme de distribution d'intensité sous-pixel que l'unidimensionnalisation.

## Circumferential Blur

Un outil qui floute le motif d'anneaux le long de la direction circonférentielle (azimutale). Spécifiez un seul angle de flou et appliquez-le.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

Un outil pour traiter les images multi-trames (HDF5 et similaires ; séries temporelles, séries de température, balayages en énergie synchrotron).

- Sélectionnez une seule trame dans la liste des trames pour l'afficher, ou parcourez-les avec la trackbar.
- Avec la **multi-sélection**, sélectionnez plusieurs trames et calculez leur **average** ou **sum**.
- La cible de l'unidimensionnalisation peut être choisie parmi « toutes les trames / trames sélectionnées / uniquement la plus haute ».
- Si chaque trame porte une information d'énergie, la longueur d'onde est mise à jour automatiquement.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

Corrige l'inclinaison de l'IP φ, τ et la distorsion des pixels ξ, et enregistre l'image avec des pixels carrés à une résolution spécifiée. Des métadonnées telles que la longueur de caméra, la longueur d'onde et la position du centre sont également écrites, de sorte que l'image peut être transmise à d'autres traitements d'image tout en préservant l'information géométrique.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

Un outil qui optimise la longueur d'onde, la longueur de caméra, la taille de pixel, la distorsion des pixels et l'inclinaison (φ, τ) à partir des anneaux de diffraction d'un matériau de référence. Il utilise deux motifs, Primary et Secondary, et vous sélectionnez les pics et optimisez avec **Refine!**. La convergence (centre de l'ellipse, résidus) peut être vérifiée sur les graphiques. Voir [Procédures](4-procedures.md) pour les étapes concrètes.

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

Un outil qui trouve la longueur de caméra et la longueur d'onde par une recherche exhaustive sur grille plutôt que par une méthode de gradient. Il est efficace lorsque l'optimisation géométrique peine à converger, par exemple avec des anneaux incomplets ou des données bruitées. Le CrystalControl est utilisé pour saisir les paramètres du cristal. Voir [Recherche de paramètres (force brute)](6-find-parameter.md) pour les étapes détaillées, et [Procédures](4-procedures.md) pour le flux de travail.

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Une fonctionnalité qui automatise les opérations à l'aide de scripts de type Python. Ouvrez l'éditeur de macros depuis le menu **Macro → Editor** de la fenêtre principale.

- `for` / `if` / `while` / `def` / `class`, l'arithmétique et le module `math` sont disponibles.
- Des API telles que `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permettent d'appeler chaque opération.
- Des macros d'exemple (boucles de base, configuration de la géométrie, traitement par lots, division azimutale, masquage, envoi vers PDIndexer, etc.) sont fournies, et vous pouvez inspecter les variables avec l'exécution pas à pas.

Voir [Macro](5-macro/index.md) pour la référence complète des fonctions et des exemples, et [Procédures](4-procedures.md) pour les flux de travail basés sur les macros.

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

Un outil destiné à la correction d'intensité spécifique aux détecteurs R-Axis ; pour l'instant il ne fait que lire le fichier, et la correction elle-même n'est pas encore implémentée.

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
