<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Fonctions intégrées

Les méthodes et propriétés appelables depuis une macro, regroupées par espace de noms sous l'objet racine `IPA`. Les descriptions reprennent l'aide intégrée de l'éditeur de macros (attributs `[Help]`) ; cette aide intégrée constitue la référence faisant autorité et la plus à jour.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Renvoie le chemin complet vers un répertoire. Si `filename` est omis, une boîte de dialogue de sélection de dossier s'ouvre. |
| `GetFileName(message="")` | Ouvre une boîte de dialogue de fichier et renvoie le chemin complet du fichier sélectionné. |
| `GetFileNames(message="")` | Ouvre une boîte de dialogue à sélection multiple et renvoie les chemins complets sous forme de tableau de chaînes. |
| `GetAllFileNames(message="")` | Sélectionne un dossier et renvoie les chemins complets de tous les fichiers qu'il contient (récursivement) sous forme de tableau. |
| `ReadImage(filename="", flag=None)` | Lit un fichier image. Si omis, une boîte de dialogue de sélection s'ouvre. |
| `ReadImageHDF(filename, flag)` | Lit une image HDF5. `flag` active ou désactive la normalisation. |
| `SaveImage(filename="")` | Enregistre l'image actuelle (alias hérité ; TIFF par défaut). |
| `SaveImageAsTIFF(filename="")` | Enregistre l'image au format TIFF. |
| `SaveImageAsPNG(filename="")` | Enregistre l'image au format PNG. |
| `SaveImageAsIPA(filename="")` | Enregistre l'image au format IPA. |
| `SaveImageAsCSV(filename="")` | Enregistre l'image au format CSV. |
| `ReadParameter(filename="")` | Lit un fichier de paramètres. |
| `SaveParameter(filename="")` | Enregistre les paramètres actuels. |
| `ReadMask(filename="")` | Lit un fichier de masque. |
| `SaveMask(filename="")` | Enregistre le masque actuel. |

Pour toutes les méthodes de lecture/enregistrement, omettre le nom de fichier ou en fournir un invalide ouvre une boîte de dialogue de sélection.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Définit la longueur d'onde du faisceau incident (en nm). |
| `WaveLength` | Définit/récupère la longueur d'onde (en nm). |
| `WaveSource` | Définit/récupère la source sous forme d'entier. 0 : None, 1 : X-ray, 2 : Electron, 3 : Neutron. |
| `XrayLine` | Définit la raie de longueur d'onde des rayons X sous forme d'entier (setter uniquement). 0 : Kα, 1 : Kα1, 2 : Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Définit la position du centre (tache directe) (en pixels). |
| `SetCameraLength(length)` | Définit la longueur de caméra (en mm). |
| `CenterX` | Définit/récupère la valeur X de la position du centre (en pixels). |
| `CenterY` | Définit/récupère la valeur Y de la position du centre (en pixels). |
| `CameraLength` | Définit/récupère la longueur de caméra (en mm). |
| `PixelSizeX` | Définit/récupère la taille X du pixel (largeur du pixel) (en mm). |
| `PixelSizeY` | Définit/récupère la taille Y du pixel (hauteur du pixel) (en mm). |
| `PixelKsi` | Définit/récupère l'inclinaison du pixel ξ (en degrés). |
| `TiltPhi` | Définit/récupère l'inclinaison φ (en degrés). |
| `TiltTau` | Définit/récupère l'inclinaison τ (en degrés). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Dessine l'image avec un gradient négatif (homologue de `PositiveGradient`). |
| `PositiveGradient` | True/False. Dessine l'image avec un gradient positif (homologue de `NegativeGradient`). |
| `LinearScale` | True/False. Dessine en échelle linéaire (homologue de `LogScale`). |
| `LogScale` | True/False. Dessine en échelle logarithmique (homologue de `LinearScale`). |
| `GrayScale` | True/False. Dessine en niveaux de gris (homologue de `ColorScale`). |
| `ColorScale` | True/False. Dessine en échelle de couleurs (homologue de `GrayScale`). |
| `Maximum` | Définit/récupère le niveau de luminosité maximal (float). |
| `Minimum` | Définit/récupère le niveau de luminosité minimal (float). |
| `CanvasMagnification` | Définit/récupère le grossissement de l'image (float). |
| `SetCanvasCenter(x, y)` | Définit la position du centre du canevas (en pixels). |
| `SetCanvasSize(width, height)` | Définit la taille du canevas (picture box) (en pixels). |
| `SetArea(top, bottom, left, right)` | Définit la zone du canevas selon les limites haut/bas/gauche/droite (en pixels). |
| `SetFullArea()` | Définit la zone du canevas de sorte que l'image entière soit visible. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Masque les taches (identique au bouton « Mask Spots »). |
| `ClearMask()` | Efface les masques actuels. |
| `InvertMask()` | Inverse l'état actuel du masque. |
| `MaskAll()` | Masque la zone entière. |
| `MaskTop()` | Masque la moitié supérieure. |
| `MaskBottom()` | Masque la moitié inférieure. |
| `MaskLeft()` | Masque la moitié gauche. |
| `MaskRight()` | Masque la moitié droite. |
| `TakeOver` | Définit/récupère le réglage de report du masque (entier). 0 : None, 1 : reporter l'état actuel du masque, 2 : reporter le fichier de masque. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Intègre de façon concentrique (2θ–intensité). |
| `RadialIntegration` | True/False. Intègre de façon radiale (pizza-cut). |
| `AzimuthalDivision` | True/False. Traite en mode division azimutale. |
| `AzimuthalDivisionNumber` | Entier. Définit le nombre de divisions de l'anneau de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Exécute Find Center avant Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Exécute Mask Spots avant Get Profile. |
| `SendProfileViaClipboard` | True/False. Envoie le profil à PDIndexer via le presse-papiers. |
| `SaveProfileAfterGetProfile` | True/False. Enregistre le profil après Get Profile. |
| `SaveProfileAsPDI` | True/False. Enregistre au format PDI. |
| `SaveProfileAsCSV` | True/False. Enregistre au format CSV. |
| `SaveProfileAsTSV` | True/False. Enregistre au format TSV. |
| `SaveProfileAsGSAS` | True/False. Enregistre au format GSAS. |
| `SaveProfileInOneFile` | True/False. Enregistre les profils séquentiels/de division azimutale dans un seul fichier. |
| `SaveProfileAtImageDirectory` | True/False. Enregistre dans le même répertoire que l'image. |
| `GetProfile(filename="")` | Exécute l'unidimensionnalisation. Si `filename` est fourni, le profil est enregistré dans ce fichier. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Intègre de façon concentrique (2θ–intensité). |
| `RadialIntegration` | True/False. Intègre de façon radiale (pizza-cut / motif en cake). |
| `ConcentricStart` | Float. Valeur de début pour l'intégration concentrique. |
| `ConcentricEnd` | Float. Valeur de fin pour l'intégration concentrique. |
| `ConcentricStep` | Float. Valeur du pas pour l'intégration concentrique. |
| `ConcentricUnit` | Entier. Unité pour l'intégration concentrique. 0 : Angle (deg), 1 : d-spacing (Å), 2 : Length (mm). |
| `RadialRadius` | Float. Rayon de l'anneau (donut) pour l'intégration radiale. |
| `RadialWidgh` | Float. Largeur de l'anneau (donut) pour l'intégration radiale. Remarque : le membre s'écrit `RadialWidgh` dans la version actuelle. |
| `RadialStep` | Float. Angle de secteur (pas de balayage) pour l'intégration radiale. |
| `RadialUnit` | Entier. Unité pour l'intégration radiale. 0 : Angle (deg), 1 : d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Indique si le fichier actuel est une image séquentielle. |
| `Count` | Entier. Récupère le nombre d'images. |
| `SelectedIndex` | Entier. Définit/récupère l'index sélectionné (à partir de 0). |
| `SelectedIndices` | Tableau d'entiers. Définit/récupère les index sélectionnés (pour le mode sélection multiple). |
| `MultiSelection` | True/False. Définit/récupère le mode sélection multiple. |
| `Averaging` | True/False. Définit/récupère le mode moyennage. |
| `SelectIndex(index)` | Définit un unique index sélectionné (désactive la sélection multiple). |
| `AppendIndex(index)` | Ajoute un index à la sélection actuelle. |
| `SelectIndices(start, end)` | Définit une plage contiguë (de start à end, inclus). |
| `AppendIndices(start, end)` | Ajoute une plage contiguë (de start à end, inclus) à la sélection actuelle. |
| `Target_SelectedImages` | True/False. Fait des images sélectionnées la cible de Get Profile. |
| `Target_AllImages` | True/False. Fait de toutes les images la cible de Get Profile. |
| `Target_TopmostImage` | True/False. Fait de la seule image la plus en avant la cible de Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Exécute la macro sur PDIndexer pas à pas. |
| `Timeout` | Définit/récupère le délai d'expiration (en secondes) de l'opération de macro (30 s par défaut). |
| `RunMacro(obj1, obj2, ...)` | Exécute du code de macro sur PDIndexer. Les paramètres sont lus sur PDI sous la forme `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Exécute la macro nommée `name` sur PDIndexer. Les paramètres sont lus sur PDI sous la forme `Obj[1]`, `Obj[2]`, … |
