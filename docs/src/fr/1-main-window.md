<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). -->

# Fenêtre principale

La fenêtre principale est le premier écran affiché au démarrage d'IPAnalyzer. Elle regroupe l'affichage de l'image de diffraction chargée, les opérations principales (recherche du centre, masquage des taches, réduction en une dimension) et les points d'accès aux réglages des paramètres du détecteur.

La fenêtre se compose, en gros, des menus et de la barre d'outils en haut, de la zone d'affichage de l'image au centre, de la barre d'outils verticale à droite et de la zone des graphiques en bas.

![La fenêtre principale d'IPAnalyzer](../assets/cap-en-auto/FormMain.png)

## Vue centrale

### Affichage de l'image

L'image chargée est affichée ici. Selon la position du pointeur de la souris, la zone au-dessus de l'image indique les coordonnées réelles (mm), les coordonnées image (pix), la distance au centre R (mm), l'angle de diffusion 2θ, la valeur d, l'azimut χ et l'intensité. La croix × magenta indique la position du spot direct (centre).

Les états des pixels sont affichés avec des couleurs distinctes.

| Couleur | Signification |
| --- | --- |
| Cyan | Tache (spot) masquée |
| Vert | Région exclue de l'intégration (réglée dans Région d'intégration (Integral Region)) |
| Magenta | Région angulaire exclue de l'intégration (réglée dans Propriété d'intégration (Integral Property)) |
| Bleu | Pixel sous le seuil d'intensité (réglé dans Région d'intégration (Integral Region)) |
| Rouge | Pixel au-dessus du seuil d'intensité |

### Opérations à la souris

En mode normal :

- Double-clic gauche : place le centre au point cliqué.
- Clic du milieu : recherche le centre en partant du point cliqué.
- Glisser droit : agrandit la région délimitée.
- Clic droit : réduit l'affichage.
- Ctrl + glisser droit : sélectionne la région rectangulaire utilisée pour les informations statistiques.

Le double-clic gauche et le clic du milieu ne fonctionnent que lorsque **Fixer le centre (Fix Center)** est désactivé.

En **Mode manuel (Manual Mode)**, le clic gauche masque et le clic droit démasque. La forme et la taille du masque se règlent dans la barre d'outils et dans les propriétés.

### Vues auxiliaires et informations sur l'image

À côté de la vue centrale se trouvent des affichages auxiliaires. Vous pouvez basculer entre **Image entière (Whole image)** et **Près du centre (Near center)** : la vue de l'image entière indique la plage d'affichage actuelle par un cadre jaune, et la vue près du centre montre une image agrandie.

**Informations sur l'image (Image Information)** indique la résolution de l'image, l'intensité maximale, l'intensité totale, les données d'en-tête, etc.

### Commandes de réglage de l'affichage

Commandes qui règlent l'apparence de l'image :

- **Dégradé (Gradient)** : inverse les tons.
- **Échelle de luminosité (Brightness scale)** : logarithmique / linéaire.
- **Échelle de couleur (Color scale)** : niveaux de gris / couleur.
- **Ligne d'échelle (Scale line)** : affichage des lignes d'échelle (aucune / grossière / moyenne / fine).
- **Contraste auto. (Auto Contrast)** / **Réinit. contraste (Reset Contrast)**, et intensités minimale/maximale explicites.
- Boutons de grossissement (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vue inférieure

La zone inférieure comporte trois graphiques/vues à onglets.

- **Fréquence d'intensité (Frequency of Intensity)** : la distribution des intensités de tous les pixels, en axes log–log. Agrandissable à la souris.
- **Profil converti (Converted Profile)** : le profil de diffraction produit par **Obtenir le profil (Get Profile)**. Agrandissable à la souris.
- **Informations statistiques (Statistical Information)** : statistiques de la région rectangulaire (X1,Y1)–(X2,Y2) sélectionnée par Ctrl + glisser droit sur l'image. Lorsqu'une image séquentielle est chargée, les statistiques de la même région dans les autres trames peuvent aussi être comparées.

## Menus

La barre de menus se compose de **Fichier / Outil / Propriété / Option / Langue / Macro / Aide** (File / Tool / Property / Option / Language / Macro / Help).

### Fichier (File)

- **Lire l'image (Read image)** : ouvre une image de diffraction. Voir [Aperçu](0-overview.md) pour les formats pris en charge.
- **Enregistrer l'image (Save image)** : enregistre au format TIFF, PNG, CSV ou IPA. Le TIFF stocke les intensités de pixel actuelles après traitement (après retournement/rotation, soustraction du fond et correction de polarisation), le PNG conserve l'affichage (luminosité, contraste, masque) et l'IPA est un format propriétaire corrigé des distorsions (avec métadonnées).
- **Lire le paramètre / Enregistrer le paramètre (Read / Save parameter)** : importe/exporte la longueur d'onde, la longueur de caméra, la taille de pixel, la correction d'inclinaison, la position du centre, etc. sous forme de fichier `.prm`.
- **Lire le masque / Enregistrer le masque / Effacer le masque (Read / Save / Clear mask)** : importe/exporte un masque sous forme de fichier `.mas`, ou l'efface (le masque doit avoir la même résolution que l'image actuelle).
- **Fermer (Close)**.

Les fichiers d'image, de paramètres et de masque peuvent aussi être chargés par glisser-déposer sur la fenêtre.

### Outil (Tool)

- **Réinit. le profil de fréquence (Reset Frequency Profile)** : reconstruit le graphique de fréquence d'intensité de l'image actuelle avec la plage par défaut (l'image est conservée).
- **Étalonner l'image R-AXIS (Calibrate Raxis Image)** : détermine une table de conversion d'intensité à partir de deux images R-AXIS (voir [Outils](3-tools.md)).

### Propriété (Property)

Source de rayonnement (Wave Source) / Condition de l'écran photostimulable (Imaging Plate Condition) / Région d'intégration (Integral Region) / Propriété d'intégration (Integral Property) / Mode masque manuel (Manual Mask Mode) / Après « Obtenir le profil » (After "Get Profile") / Option d'image déroulée (Unrolled Image Option) / Divers (Miscellaneous). Ces éléments ouvrent directement les onglets correspondants de la [fenêtre de propriétés](2-property-windows.md).

### Option

- **Info-bulle (ToolTip)** : active ou désactive les info-bulles des boutons et des menus.
- **Retourner (Flip)** : horizontalement / verticalement. **Pivoter (Rotate)** : choix d'un angle de rotation. Le retournement et la rotation s'appliquent aux données de l'image de travail et affectent donc aussi l'intégration et l'enregistrement d'image qui suivent (le fichier source sur le disque n'est pas modifié).
- **Effacer le registre (Clear registry)** : élément de dépannage qui efface les réglages enregistrés. **Compilation Ngen (Ngen Compile)** n'a aucune fonction dans la version actuelle.

### Langue (Language)

- Sélectionne la langue d'affichage (11 langues). Après confirmation, l'application redémarre. Le réglage est enregistré dans le registre.

### Macro

- **Éditeur (Editor)** : ouvre l'éditeur de macros (voir [Outils](3-tools.md) / [Macro](5-macro/index.md)).

### Aide (Help)

- **Mises à jour du programme (Program Updates)**, **Astuce (Hint)**, **Licence (License)**, **Historique des versions (Version History)**, **Aide (Help)** (ouvre le manuel PDF fourni).
- Appuyez sur **F1** dans n'importe quelle fenêtre pour ouvrir la page correspondante de ce manuel en ligne.

## Barre d'outils d'opération

Les principales opérations de traitement d'image (avec des options détaillées dans les menus déroulants) :

- **Fond (Background)** : ce bouton est désactivé dans la version actuelle. La soustraction d'une image de fond se règle dans l'onglet **Option de fond (Background Option)** de la fenêtre de propriétés.
- **Trouver le centre (Find Center)** : détecte le centre du faisceau par ajustement d'une fonction Pseudo-Voigt 2D (la plage de recherche est de ±8 px autour du centre par défaut, réglée dans l'onglet Divers (Miscellaneous)). Lorsque des anneaux sont affichés avec **Tracer l'anneau (Draw ring)**, le centre est alors déterminé à partir de l'anneau.
- **Fixer le centre (Fix Center)** : fixe la position du centre.
- **Masquer les taches (Mask Spots)** : dans chaque bande radiale, les pixels dont l'intensité dépasse moyenne + écart-type × Deviation sont détectés comme taches et masqués avec leur voisinage. Le menu déroulant comprend notamment le masquage total, l'inversion du masque et le mode manuel.
- **Mode manuel (Manual Mode)** : le mode de masquage manuel. Vous pouvez choisir la forme du masque (spot (cercle/rectangle) / cercle / rectangle / polygone / spline) et la taille du spot (demi-largeur).
- **Obtenir le profil (Get Profile)** : intègre l'image en un profil unidimensionnel. Prend en charge l'intégration concentrique (Concentric, basée sur 2θ) et l'intégration radiale (Radial, basée sur l'azimut). Le menu déroulant règle notamment le choix de Propriété d'intégration/Région d'intégration (Integral Property/Region), la recherche du centre et le masquage des taches avant l'intégration, l'envoi vers PDIndexer, l'analyse par division azimutale et le traitement des images séquentielles.

## Barre d'outils (autres outils)

La barre d'outils verticale de droite lance les différents outils. Voir [Outils](3-tools.md) pour plus de détails.

- **Table d'intensités (Intensity table)** (aucune fonction n'est attribuée à ce bouton dans la version actuelle ; pour la calibration de l'intensité R-AXIS, utilisez **Outil → Étalonner l'image R-AXIS (Tool → Calibrate Raxis Image)**)
- **Procédure auto. (Auto procedure)**
- **Tracer l'anneau (Draw ring)**
- **Trouver paramètre (géométriquement) (Find parameter (geometrically))** / **Trouver paramètre (force brute) (Find parameter (brute force))**
- **Dérouler l'image (Unroll image)**
- **Flou circonférentiel (Circumferential blur)**
- **Image séquentielle (Sequential image)**
