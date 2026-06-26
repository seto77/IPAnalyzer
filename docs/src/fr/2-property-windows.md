<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Fenêtres de propriétés

La fenêtre de propriétés est l'endroit où vous configurez la source, les conditions du détecteur et les diverses conditions d'unidimensionnalisation. Chaque onglet peut également être ouvert directement depuis le menu **Property** de la fenêtre principale.

L'interface de cette fenêtre est en anglais. Les titres ci-dessous reprennent les noms réels des onglets et des contrôles.

## Wave source

Définit le type de faisceau incident et la longueur d'onde. La source peut être des rayons X, des électrons ou des neutrons. Pour les rayons X, le choix d'un élément et d'une transition (raie K, raie L, etc.) renseigne automatiquement la longueur d'onde ; pour le rayonnement synchrotron, saisissez directement la longueur d'onde. Pour les faisceaux d'électrons et de neutrons, saisissez l'énergie ou la longueur d'onde (la longueur d'onde des électrons est corrigée de façon relativiste).

- **Correct linear polarization** : corrige une intensité polarisée linéairement vers l'équivalent non polarisé (pour les données synchrotron). La formule de correction ci-dessous dépend de l'azimut χ (défini dans l'onglet Miscellaneous) et de l'angle de diffusion 2θ.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

Définit les conditions géométriques du détecteur. Cela correspond à l'ancien « IP Condition », avec l'ajout de sélecteurs de système de coordonnées et de forme du détecteur.

- **Coordinates** : **Direct spot** (référence du spot direct) / **Foot** (référence du pied de la perpendiculaire).
- **Detector type** : **Flat panel** / **Gandolfi**.
- **Direct spot position** et **Camera Length 1** : la position du spot direct (X, Y pix) et la distance de l'échantillon au spot direct (mm).
- **Foot position** et **Camera Length 2** : en mode Foot, la position du pied de la perpendiculaire et la distance de l'échantillon au pied.
- **Pixel Shape** : taille de pixel X, Y (mm) et ξ (Ksi, l'angle d'inclinaison du parallélogramme).
- **Gandolfi Radius** : le rayon, lorsque la forme Gandolfi est sélectionnée.
- **Spherical correction** : correction sphérique (normalement zéro).
- **Tilt** : l'inclinaison de l'IP φ (Phi) et τ (Tau).

Voir [Aperçu](0-overview.md) pour les définitions de l'inclinaison φ, τ et du ξ du pixel.

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

Spécifie la région de l'image à unidimensionnaliser.

- **Rectangle** : choisissez la **Direction** (Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free) et réglez la **Band Width**, l'**Angle** (en mode Free) et **Both Side**.
- **Sector** : spécifiez la plage angulaire avec **Start Angle** / **End Angle**.
- **Exceptional pixels** : excluez les **Masked Spots**, les pixels **Under intensity of** / **Over intensity of** les seuils donnés, et un certain nombre de **pixels from edges**.

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

Définit la méthode et le pas d'intégration.

- **Concentric integration (scattering-angle dispersive)** : choisissez l'unité de l'axe horizontal parmi **Angle** (2θ, °) / **Length** (mm) / **d-spacing** (Å), et réglez **Start / End / Step**. L'**Output pattern** peut être **Bragg - Brentano** ou **Debye - Scherrer**.
- **Radial integration (cake pattern)** : analyse une région en forme d'anneau dans la direction azimutale. Choisissez l'axe horizontal parmi **Angle** / **d-spacing**, et réglez le **Donut radius** (rayon central), la **Donut width** (largeur de l'anneau) et le **Sector angle step** (pas de balayage).

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

Définit les conditions de masquage et de détection du centre/des taches (une extension de l'ancien « Find Center & Spots »).

- **Half mask** : boutons qui masquent rapidement la moitié supérieure, inférieure, gauche ou droite de l'image.
- **Manual mask mode** : active le masquage interactif sur l'image principale. Les formes sont **Circle** (glisser pour définir le centre et le rayon), **Polygon** (cliquer pour ajouter des sommets), **Rectangle** (glisser les sommets diagonaux), **Spline curve** et **Spot** (clic gauche/droit pour ajouter/supprimer des taches).
- **Takeover** : la manière dont le masque est traité lorsqu'une nouvelle image est chargée (**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation** : le seuil statistique pour la détection des taches.
- **Find Center** : la plage de recherche pour la détection du centre, et ainsi de suite.

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

Définit l'enregistrement et l'envoi après l'unidimensionnalisation.

- **Save File** : choisissez la destination (« le même répertoire que l'image » ou « un répertoire choisi à chaque fois ») et le format parmi **PDI** / **CSV** / **TSV** / **GSAS**.
- **Send PDIndexer** : envoie le profil, via le presse-papiers, à une instance en cours d'exécution de PDIndexer.

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

Définit les paramètres de l'image déroulée (Unroll).

- **Horizontal** : l'unité (Angle / Length / d-spacing) et **Start / End / Step**. La largeur de l'image de sortie ≈ (End − Start) / Step.
- **Vertical** : le pas azimutal (°/pixel). La hauteur de l'image de sortie ≈ 360 / step.

Le déroulement transforme l'image de diffraction polaire centrée sur le spot direct en une image cartésienne (angle vs. distance).

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

Un onglet qui rassemble les réglages plus fins d'affichage et de coordonnées.

- **Image name display** : nom de fichier seul / dossier parent + nom de fichier / chemin complet.
- **Contrast / intensity-range persistence** : si les réglages d'affichage sont conservés lorsqu'une nouvelle image est chargée.
- **Azimuth χ (Chi) orientation** : la position de référence (Top / Bottom / Left / Right) et le sens de rotation (Clockwise / Counterclockwise). χ est référencé par la correction de polarisation et l'intégration radiale.
- **Scale line** : couleur, épaisseur, nombre de divisions et affichage des étiquettes.
- **Find Center** : plage de recherche, plage d'ajustement de pic, fixer le centre et exclure les pixels masqués.

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

Définit la correction par une image de fond.

- **Background image** : définit l'image actuellement affichée comme fond (**Set the current image as background**) ou l'efface (**Clear**).
- **Coefficient** : le facteur appliqué à l'image de fond.
- **Edge mask** : une marge de masque supplémentaire (px) appliquée aux bords lors de la correction.

Utilisé pour la correction de champ plat, la suppression de la diffusion par l'air, et autres opérations similaires.

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
