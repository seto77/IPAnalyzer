<!-- 261124Cl: Retranslated from en/2-property-windows.md (UI labels follow the localized GUI). -->

# Fenêtres de propriétés

La fenêtre de propriétés permet de configurer la source, les conditions du détecteur et les diverses conditions de réduction en une dimension. Chaque onglet peut aussi être ouvert directement depuis le menu **Propriété (Property)** de la fenêtre principale.

Les libellés ci-dessous sont ceux affichés par l'interface en français, suivis du nom anglais entre parenthèses. Les titres reprennent les noms réels des onglets et des contrôles.

## Source d'onde (Wave source)

Règle le type de faisceau incident et la longueur d'onde. La source peut être des rayons X, des électrons ou des neutrons. Pour les rayons X, le choix d'un élément et d'une transition (raie K, raie L, etc.) renseigne automatiquement la longueur d'onde ; pour le rayonnement synchrotron, saisissez directement la longueur d'onde. Pour les faisceaux d'électrons et de neutrons, saisissez l'énergie ou la longueur d'onde (la longueur d'onde des électrons est corrigée des effets relativistes).

- **Corriger la polarisation linéaire (Correct linear polarization)** : corrige une intensité polarisée linéairement en son équivalent non polarisé (pour les données synchrotron). La formule de correction ci-dessous dépend de l'azimut χ et de l'angle de diffusion 2θ. Si la direction de référence de χ (réglée dans l'onglet Divers (Miscellaneous)) est Gauche/Droite (Left/Right), le faisceau est traité comme polarisé horizontalement ; si elle est Haut/Bas (Top/Bottom), comme polarisé verticalement.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Onglet Source d'onde (Wave source)](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Condition du détecteur (Detector condition)

Règle les conditions géométriques du détecteur. Cet onglet correspond à l'ancien « IP Condition », avec en plus des sélecteurs de système de coordonnées et de forme du détecteur.

- **Coordonnées (Coordinates)** : **Spot direct (Direct spot)** (référence au spot direct) / **Pied (Foot)** (référence au pied de la perpendiculaire).
- **Type de détecteur (Detector type)** : **Panneau plat (Flat panel)** / **Gandolfi**.
- **Position du spot direct (Direct spot position)** et **Longueur de caméra 1 (Camera Length 1)** : la position du spot direct (X, Y pix) et la distance de l'échantillon au spot direct (mm).
- **Position du pied (Foot position)** et **Longueur de caméra 2 (Camera Length 2)** : en mode Pied (Foot), la position du pied de la perpendiculaire et la distance de l'échantillon au pied.
- **Forme du pixel (Pixel Shape)** : taille de pixel X, Y (mm) et ξ (Ksi, l'angle d'inclinaison du parallélogramme).
- **Rayon Gandolfi (Gandolfi Radius)** : le rayon, lorsque la forme Gandolfi est sélectionnée.
- **Correction sphérique (Spherical correction)** : pour un détecteur courbé, saisissez l'inverse du rayon de courbure, 1/R (mm⁻¹). Utilisez 0 pour un détecteur plan.
- **Inclinaison (Tilt)** : l'inclinaison de l'IP φ (Phi) et τ (Tau).

Voir [Aperçu](0-overview.md) pour les définitions de l'inclinaison φ, τ et du ξ des pixels.

![Onglet Condition du détecteur (Detector condition)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Région d'intégration (Integral Region)

Indique la région de l'image à réduire en une dimension.

- **Rectangle** : choisissez la **Direction** (Complet (Full) / Haut (Top) / Bas (Bottom) / Gauche (Left) / Droite (Right) / Vertical / Horizontal / Free), et réglez la **Largeur de bande (Band Width)**, l'**Angle** (en mode Free) et **Les deux côtés (Both Side)**.
- **Secteur (Sector)** : indiquez la plage angulaire avec **Angle de début (Start Angle)** / **Angle de fin (End Angle)**.
- **Pixels exceptionnels (Exceptional pixels)** : excluez les **Spots masqués (Masked Spots)**, les pixels **En dessous de l'intensité de (Under intensity of)** / **Au-dessus de l'intensité de (Over intensity of)** des seuils donnés, et un certain nombre de **pixels depuis les bords (pixels from edges)**.

![Onglet Région d'intégration (Integral Region)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Propriété d'intégration (Integral Property)

Règle la méthode et le pas d'intégration.

- **Intégration concentrique (dispersive en angle de diffusion) (Concentric integration (scattering angle dispersive))** : choisissez l'unité de l'axe horizontal parmi **Angle** (2θ, °) / **Distance interréticulaire (d-spacing)** (Å), et réglez **Début / Fin / Pas (Start / End / Step)**. Le choix **Motif de sortie (Output pattern)** (Bragg - Brentano / Debye - Scherrer) n'a aucun effet sur le résultat dans la version actuelle.
- **Intégration radiale (motif en parts de gâteau) (Radial integration (cake pattern))** : somme l'intensité d'une région annulaire pour chaque azimut. Indiquez le centre de l'anneau (**Rayon de l'anneau (Donut radius)**) et sa demi-largeur (**Largeur de l'anneau (Donut width)**) en angle de diffusion 2θ (**Angle**) ou en distance interréticulaire (**Distance interréticulaire (d-spacing)**), et réglez le **Pas d'angle de secteur (Sector angle step)** (pas azimutal). L'axe horizontal du profil obtenu est l'azimut χ (°).

![Onglet Propriété d'intégration (Integral Property)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Option de masque (Mask Option)

Règle les conditions de masquage et de détection des taches (une extension de l'ancien « Find Center & Spots »). Les réglages de détection du centre se trouvent dans l'onglet Divers (Miscellaneous).

- **Demi-masque (Half mask)** : boutons qui masquent rapidement la moitié supérieure, inférieure, gauche ou droite de l'image.
- **Mode masque manuel (Manual mask mode)** : active le masquage interactif sur l'image principale. Les formes sont **Cercle (Circle)** (glisser pour définir le centre et le rayon), **Polygone (Polygon)** (cliquer pour ajouter des sommets), **Rectangle** (glisser les sommets diagonaux), **Courbe spline (Spline curve)** et **Spot** (clic gauche/droit pour ajouter/supprimer des spots).
- **Reprendre le réglage de masque (Take over mask setting)** : traitement du masque lors du chargement d'une nouvelle image (**Aucun (None)** / **Reprendre l'état actuel du masque (Take over the current mask state)** / **Reprendre le fichier de masque (Take over the mask file)**).
- **Option de masquage des spots (Mask spots option)** → **Écart critère pour « Masquer les spots » (Criterial deviation for "Mask Spots")** : le seuil statistique de la détection des taches.

![Onglet Option de masque (Mask Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## Après « Obtenir le profil » (After "Get Profile")

Règle l'enregistrement et l'envoi après la réduction en une dimension.

- **Enregistrer le profil (Save Profiles)** : choisissez la destination (« Dans le même dossier que l'image (At the same directory of the image) » ou « Dans le dossier choisi à chaque fois (At the chosen directory each time) ») et le format parmi **PDI** / **CSV** / **TSV** / **GSAS**. La sortie GSAS n'est possible que pour l'intégration concentrique avec un axe horizontal en 2θ. Lorsque plusieurs profils doivent être enregistrés dans un seul fichier, le GSAS n'est pas écrit ; enregistrez-les plutôt dans des fichiers séparés.
- **Envoyer les données de profil à PDIndexer via le presse-papiers (Send profile data to PDIndexer through Clipboard)** : envoie le profil, via le presse-papiers, à une instance de PDIndexer en cours d'exécution.

![Onglet Après « Obtenir le profil » (After "Get Profile")](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Option d'image déroulée (Unrolled Image Option)

Règle les paramètres de l'image déroulée (Unroll).

- **Unité et plage horizontales (distance au spot direct) (Horizontal (distance from direct spot) unit and range)** : **Début / Fin / Pas (Start / End / Step)** en angle de diffusion 2θ (°) (des options d'unité sont affichées, mais la version actuelle traite toujours les valeurs comme des 2θ). La largeur de l'image produite ≈ (Fin − Début) / Pas.
- **Pas vertical (angle de secteur) (Vertical (sector angle) step)** : le nombre de divisions N en azimut (**Division**). L'image produite a une hauteur de N pixels, et chaque ligne couvre 360°/N (0,5° pour la valeur par défaut 720).

Le déroulement transforme l'image de diffraction polaire centrée sur le spot direct en une image cartésienne (angle en fonction de la distance).

![Onglet Option d'image déroulée (Unrolled Image Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Divers (Miscellaneous)

Onglet qui regroupe les réglages fins d'affichage et de coordonnées.

- **Options de nom d'image (Image name options)** : nom de fichier seul / dernier dossier + nom de fichier / chemin complet.
- **Maintenir la plage d'affichage (Maintain display range)** : indique si le zoom et la position d'affichage (plage d'affichage) sont conservés lors du chargement d'une nouvelle image.
- **Options de l'axe Chi (χ) (Chi (χ) axis options)** : la position de référence (Haut / Bas / Gauche / Droite (Top / Bottom / Left / Right)) et le sens de rotation (Sens horaire (Clockwise) / Sens antihoraire (Counterclockwise)). χ est utilisé par la correction de polarisation et par l'intégration radiale.
- **Options de ligne d'échelle (Scale line options)** : couleur, largeur, nombre de divisions et affichage des étiquettes.
- **Options de recherche du centre (Find center options)** : plage de recherche, plage d'ajustement des pics, fixation du centre et exclusion des pixels masqués.

![Onglet Divers (Miscellaneous)](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Option de fond (Background Option)

Règle la correction par une image de fond.

- **Réglage de l'image de référence (Reference image setting)** : définissez l'image actuellement affichée comme fond (**Définir l'image actuelle comme fond (Set the current image as background)**), ou effacez-la (**Effacer (Clear)**).
- **Coefficient** : le facteur appliqué à l'image de fond.

Sert à soustraire un fond additif tel que la diffusion par l'air. Pour chaque pixel, \(I_\mathrm{out} = I - cB\) est calculé (\(B\) : image de fond, \(c\) : coefficient). Pour exclure les pixels proches des bords de l'image, utilisez **pixels depuis les bords (pixels from edges)** dans l'onglet Région d'intégration (Integral Region).

![Onglet Option de fond (Background Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
