<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# Fenêtre principale

La fenêtre principale est le premier écran affiché au démarrage d'IPAnalyzer. Elle réunit l'affichage de l'image de diffraction chargée, les opérations principales (recherche du centre, masquage des taches, unidimensionnalisation) ainsi que les points d'accès aux réglages des paramètres du détecteur.

La fenêtre se compose, grossièrement, des menus et de la barre d'outils en haut, de la zone d'affichage de l'image au centre, de la barre d'outils verticale à droite et de la zone de graphique en bas.

![La fenêtre principale d'IPAnalyzer](../assets/cap-en-auto/FormMain.png)

## Vue centrale

### Affichage de l'image

L'image chargée est affichée ici. Selon la position du pointeur de la souris, la zone située au-dessus de l'image indique les coordonnées réelles (mm), les coordonnées image (pix), la distance au centre R (mm), l'angle de diffusion 2θ, la valeur d, l'azimut χ et l'intensité. La marque × magenta indique la position de la tache directe (centre).

Les états des pixels sont indiqués par des couleurs distinctes.

| Couleur | Signification |
| --- | --- |
| Cyan | Tache masquée |
| Vert | Région exclue de l'intégration (définie dans Integral Region) |
| Magenta | Région angulaire exclue de l'intégration (définie dans Integral Property) |
| Bleu | Pixel sous le seuil d'intensité (défini dans Integral Region) |
| Rouge | Pixel au-dessus du seuil d'intensité |

### Opérations à la souris

En mode normal :

- Maintenir le bouton gauche enfoncé : recherche le centre de la tache à proximité.
- Double-clic gauche : met à jour la position du centre vers le point cliqué.
- Glisser avec le bouton droit : effectue un zoom sur la région sélectionnée.
- Clic droit : effectue un zoom arrière.

En **Manual spot mode**, le clic gauche masque et le clic droit démasque. La forme et la taille du masque se règlent dans la barre d'outils et dans les propriétés.

### Vues auxiliaires et informations sur l'image

À côté de la vue centrale se trouvent des affichages auxiliaires. Vous pouvez basculer entre **Whole image** et **Near center** : la vue de l'image entière marque la plage d'affichage actuelle par un cadre jaune, et la vue près du centre montre une image agrandie.

**Image Information** affiche la résolution de l'image, l'intensité maximale, l'intensité totale, les données d'en-tête, etc.

### Commandes de réglage de l'affichage

Commandes qui ajustent l'apparence de l'image :

- **Gradient** : inverse la tonalité.
- **Brightness scale** : logarithmique / linéaire.
- **Color scale** : niveaux de gris / couleur.
- **Scale line** : affichage des lignes d'échelle (aucune / grossière / moyenne / fine).
- **Auto Contrast** / **Reset Contrast**, ainsi que l'intensité minimale/maximale explicite.
- Boutons d'agrandissement (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vue inférieure

La zone inférieure comporte trois graphiques/vues à onglets.

- **Frequency of Intensity** : la distribution d'intensité de tous les pixels, en axes log–log. Zoomable à la souris.
- **Converted Profile** : le profil de diffraction après unidimensionnalisation (Get Profile). Zoomable à la souris.
- **Statistical Information** : statistiques pour une région rectangulaire sélectionnée (X1,Y1)–(X2,Y2). Lorsqu'une image séquentielle est chargée, les statistiques de la même région dans d'autres trames peuvent également être comparées.

## Menus

La barre de menus se compose de **File / Tool / Property / Option / Language / Macro / Help**.

### File

- **Read image** : ouvre une image de diffraction. Voir [Aperçu](0-overview.md) pour les formats pris en charge.
- **Save image** : enregistre au format TIFF, PNG, CSV ou IPA. Le TIFF conserve les intensités de pixel d'origine, le PNG conserve l'affichage (luminosité, contraste, masque), et l'IPA est un format propriétaire corrigé de la distorsion (avec métadonnées).
- **Read / Save parameter** : importe/exporte la longueur d'onde, la longueur de caméra, la taille de pixel, la correction d'inclinaison, la position du centre, etc. sous forme de fichier `.prm`.
- **Read / Save / Clear mask** : importe/exporte un masque sous forme de fichier `.mas`, ou l'efface (le masque doit correspondre à la résolution de l'image courante).
- **Close**.

Les fichiers d'image, de paramètres et de masque peuvent également être chargés par glisser-déposer sur la fenêtre.

### Tool

- **Reset Frequency Profile** : efface le graphique de fréquence d'intensité (l'image est conservée).
- **Calibrate Raxis Image**.

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. Ces éléments ouvrent directement les onglets correspondants de la [fenêtre de propriétés](2-property-windows.md).

### Option

- **ToolTip** : active ou désactive les infobulles sur les boutons et les menus.
- **Flip** : horizontalement / verticalement. **Rotate** : choisit un angle de rotation. Tous deux n'affectent que l'affichage ; les données de l'image chargée elles-mêmes ne sont pas modifiées.
- **Ngen Compile** et **Clear registry** sont destinés au développement et au dépannage.

### Language

- Bascule entre **English** et **Japanese** (le réglage est enregistré dans le registre).

### Macro

- **Editor** : ouvre l'éditeur de macros (voir [Outils](3-tools.md) / [Macro](5-macro/index.md)).

### Help

- **Program Updates**, **Hint**, **License**, **Version History**, **Web Page**.

## Barre d'outils d'opération

Les principales opérations de traitement d'image (avec des options détaillées dans les menus déroulants) :

- **Background** : soustraction d'une image de fond (configurée dans Background Option).
- **Find Center** : détecte le centre du faisceau par ajustement Pseudo-Voigt 2D (plage de recherche de 8 px par défaut, définie dans Miscellaneous). Le menu déroulant propose également une détection du centre basée sur les anneaux.
- **Fix center** : fixe la position du centre.
- **Mask Spots** : détecte et masque les taches selon le critère moyenne ± écart-type × Deviation. Le menu déroulant inclut tout masquer, masque inverse, manuel, etc.
- **Manual** : le mode de masquage manuel. Vous pouvez choisir la forme (cercle / rectangle) et la taille (8–256 px).
- **Get Profile** : intègre l'image en un profil unidimensionnel. Prend en charge Concentric (basé sur 2θ) et Radial (basé sur l'azimut). Le menu déroulant configure la sélection Integral Property/Region, l'exécution ou non de la recherche du centre et du masquage des taches avant l'intégration, l'envoi vers PDIndexer, l'analyse par division azimutale, le traitement d'images séquentielles, etc.

## Barre d'outils (autres outils)

La barre d'outils verticale à droite lance les différents outils. Voir [Outils](3-tools.md) pour les détails.

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
