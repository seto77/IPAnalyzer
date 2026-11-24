<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Fonctions intégrées

Les méthodes et propriétés utilisables depuis une macro, regroupées par espace de noms sous l'objet racine `IPA`. Les descriptions suivent l'aide intégrée à l'éditeur de macros (attributs `[Help]`) ; l'aide intégrée à l'éditeur est la référence à jour qui fait foi.

## IPA.File

| Membre | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Renvoie le chemin complet d'un dossier. Si `filename` est omis, une boîte de dialogue de sélection de dossier s'ouvre. |
| `GetFileName(message="")` | Ouvre une boîte de dialogue de fichier et renvoie le chemin complet du fichier sélectionné. |
| `GetFileNames(message="")` | Ouvre une boîte de dialogue à sélection multiple et renvoie les chemins complets sous forme de tableau de chaînes. |
| `GetAllFileNames(message="")` | Sélectionne un dossier et renvoie sous forme de tableau les chemins complets de tous les fichiers qu'il contient (récursivement). |
| `ReadImage(filename="", flag=None)` | Lit un fichier image. S'il est omis, une boîte de dialogue de sélection s'ouvre. |
| `ReadImageHDF(filename, flag)` | Lit une image HDF5. `flag` active ou désactive la normalisation. Dans la version actuelle, la lecture HDF5 (`.h5`) ne fonctionne pas ; les fichiers NeXus (`.nxs`) peuvent être lus avec `ReadImage(filename)`. |
| `SaveImage(filename="")` | Enregistre l'image actuelle (alias historique ; TIFF par défaut). |
| `SaveImageAsTIFF(filename="")` | Enregistre l'image au format TIFF. |
| `SaveImageAsPNG(filename="")` | Enregistre l'image au format PNG. |
| `SaveImageAsIPA(filename="")` | Enregistre l'image au format IPA. |
| `SaveImageAsCSV(filename="")` | Enregistre l'image au format CSV. |
| `ReadParameter(filename="")` | Lit un fichier de paramètres. |
| `SaveParameter(filename="")` | Enregistre les paramètres actuels. |
| `ReadMask(filename="")` | Lit un fichier de masque. |
| `SaveMask(filename="")` | Enregistre le masque actuel. |

Pour toutes les méthodes de lecture/enregistrement, omettre le nom de fichier ou en donner un invalide ouvre une boîte de dialogue de sélection.

## IPA.Wave

| Membre | Description |
|------|------|
| `SetWaveLength(wavelength)` | Règle la longueur d'onde du faisceau incident (en nm). |
| `WaveLength` | Règle/lit la longueur d'onde (en nm). |
| `WaveSource` | Règle/lit la source sous forme d'entier. 0 : aucune, 1 : rayons X, 2 : électrons, 3 : neutrons. |
| `XrayLine` | Règle la raie de longueur d'onde des rayons X sous forme d'entier (écriture seule). 0 : Kα, 1 : Kα1, 2 : Kα2. |

## IPA.Detector

| Membre | Description |
|------|------|
| `SetCenter(x, y)` | Règle la position du centre (spot direct) (en pixels). |
| `SetCameraLength(length)` | Règle la longueur de caméra (en mm). |
| `CenterX` | Règle/lit la valeur X de la position du centre (en pixels). |
| `CenterY` | Règle/lit la valeur Y de la position du centre (en pixels). |
| `CameraLength` | Règle/lit la longueur de caméra (en mm). |
| `PixelSizeX` | Règle/lit la taille X du pixel (largeur du pixel) (en mm). |
| `PixelSizeY` | Règle/lit la taille Y du pixel (hauteur du pixel) (en mm). |
| `PixelKsi` | Règle/lit l'inclinaison ξ du pixel (en degrés). |
| `TiltPhi` | Règle/lit l'inclinaison φ (en degrés). |
| `TiltTau` | Règle/lit l'inclinaison τ (en degrés). |

## IPA.Image

| Membre | Description |
|------|------|
| `NegativeGradient` | True/False. Affiche l'image avec un dégradé négatif (pendant de `PositiveGradient`). |
| `PositiveGradient` | True/False. Affiche l'image avec un dégradé positif (pendant de `NegativeGradient`). |
| `LinearScale` | True/False. Affiche avec une échelle linéaire (pendant de `LogScale`). |
| `LogScale` | True/False. Affiche avec une échelle logarithmique (pendant de `LinearScale`). |
| `GrayScale` | True/False. Affiche en niveaux de gris (pendant de `ColorScale`). |
| `ColorScale` | True/False. Affiche avec une échelle de couleur (pendant de `GrayScale`). |
| `Maximum` | Règle/lit le niveau de luminosité maximal (nombre réel). |
| `Minimum` | Règle/lit le niveau de luminosité minimal (nombre réel). |
| `CanvasMagnification` | Règle/lit le grossissement de l'image (nombre réel). |
| `SetCanvasCenter(x, y)` | Règle la position du centre du canevas (en pixels). |
| `SetCanvasSize(width, height)` | Règle la taille du canevas (picture box) (en pixels). |
| `SetArea(top, bottom, left, right)` | Règle la zone du canevas par ses limites haut/bas/gauche/droite (en pixels). |
| `SetFullArea()` | Règle la zone du canevas de sorte que l'image entière soit visible. |

## IPA.Mask

| Membre | Description |
|------|------|
| `MaskSpots()` | Masque les taches (identique au bouton « Masquer les taches » (Mask Spots)). |
| `ClearMask()` | Efface les masques actuels. |
| `InvertMask()` | Inverse l'état actuel du masque. |
| `MaskAll()` | Masque toute la zone. |
| `MaskTop()` | Masque la moitié supérieure. |
| `MaskBottom()` | Masque la moitié inférieure. |
| `MaskLeft()` | Masque la moitié gauche. |
| `MaskRight()` | Masque la moitié droite. |
| `TakeOver` | Règle/lit le réglage de reprise du masque (entier). 0 : aucun, 1 : reprendre l'état actuel du masque, 2 : reprendre le fichier de masque. |

## IPA.Profile

| Membre | Description |
|------|------|
| `ConcentricIntegration` | True/False. Intègre de façon concentrique (2θ–intensité). |
| `RadialIntegration` | True/False. Intègre radialement (découpe en parts de pizza). |
| `AzimuthalDivision` | True/False. Traite en mode de division azimutale. |
| `AzimuthalDivisionNumber` | Entier. Règle le nombre de divisions de l'anneau de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Exécute Trouver le centre (Find Center) avant Obtenir le profil (Get Profile). |
| `MaskSpotsBeforeGetProfile` | True/False. Exécute Masquer les taches (Mask Spots) avant Obtenir le profil (Get Profile). |
| `SendProfileViaClipboard` | True/False. Envoie le profil à PDIndexer via le presse-papiers. |
| `SaveProfileAfterGetProfile` | True/False. Enregistre le profil après Obtenir le profil (Get Profile). |
| `SaveProfileAsPDI` | True/False. Enregistre au format PDI. |
| `SaveProfileAsCSV` | True/False. Enregistre au format CSV. |
| `SaveProfileAsTSV` | True/False. Enregistre au format TSV. |
| `SaveProfileAsGSAS` | True/False. Enregistre au format GSAS. Possible uniquement pour l'intégration concentrique avec un axe en 2θ ; non écrit lorsque plusieurs profils sont enregistrés dans un seul fichier. |
| `SaveProfileInOneFile` | True/False. Enregistre dans un seul fichier les profils séquentiels/de division azimutale. |
| `SaveProfileAtImageDirectory` | True/False. Enregistre dans le même dossier que l'image. |
| `GetProfile(filename="")` | Intègre l'image en un profil 1D (identique à **Obtenir le profil (Get Profile)**). Si `filename` est donné, il sert de nom de base et l'extension du format y est ajoutée (par ex. `GetProfile("sample.stl")` enregistré en CSV donne `sample.stl.csv`). Si la destination est réglée sur « Dans le dossier choisi à chaque fois » (At the chosen directory each time), la boîte de dialogue d'enregistrement s'affiche. |

## IPA.IntegralProperty

| Membre | Description |
|------|------|
| `ConcentricIntegration` | True/False. Intègre de façon concentrique (2θ–intensité). |
| `RadialIntegration` | True/False. Intègre radialement (découpe en parts de pizza / motif en parts de gâteau). |
| `ConcentricStart` | Réel. Valeur de début de l'intégration concentrique. |
| `ConcentricEnd` | Réel. Valeur de fin de l'intégration concentrique. |
| `ConcentricStep` | Réel. Valeur du pas de l'intégration concentrique. |
| `ConcentricUnit` | Entier. Unité de l'intégration concentrique. 0 : angle (deg), 1 : distance interréticulaire d (Å), 2 : longueur (mm). |
| `RadialRadius` | Réel. Rayon de l'anneau (donut radius) pour l'intégration radiale. |
| `RadialWidgh` | Réel. Largeur de l'anneau (donut width) pour l'intégration radiale. Remarque : le membre s'écrit `RadialWidgh` dans la version actuelle. |
| `RadialStep` | Réel. Angle de secteur (pas de balayage) pour l'intégration radiale. |
| `RadialUnit` | Entier. Unité de l'intégration radiale. 0 : angle (deg), 1 : distance interréticulaire d (Å). |

## IPA.Sequential

| Membre | Description |
|------|------|
| `SequentialImageMode` | True/False. Indique si le fichier actuel est une image séquentielle. |
| `Count` | Entier. Renvoie le nombre d'images. |
| `SelectedIndex` | Entier. Règle/lit l'indice sélectionné (à partir de 0). |
| `SelectedIndices` | Tableau d'entiers. Règle/lit les indices sélectionnés (en mode de sélection multiple). |
| `MultiSelection` | True/False. Règle/lit le mode de sélection multiple. |
| `Averaging` | True/False. Règle/lit le mode de moyenne. |
| `SelectIndex(index)` | Règle un indice sélectionné unique (désactive la sélection multiple). |
| `AppendIndex(index)` | Ajoute un indice à la sélection actuelle. |
| `SelectIndices(start, end)` | Règle une plage contiguë (de début à fin, bornes incluses). |
| `AppendIndices(start, end)` | Ajoute une plage contiguë (de début à fin, bornes incluses) à la sélection actuelle. |
| `Target_SelectedImages` | True/False. Fait des images sélectionnées la cible d'Obtenir le profil (Get Profile). |
| `Target_AllImages` | True/False. Fait de toutes les images la cible d'Obtenir le profil (Get Profile). |
| `Target_TopmostImage` | True/False. Fait de la seule image du premier plan la cible d'Obtenir le profil (Get Profile). |

## IPA.PDI

| Membre | Description |
|------|------|
| `Debug` | True/False. Exécute la macro dans PDIndexer pas à pas. |
| `Timeout` | Règle/lit le délai d'expiration (en secondes) de l'opération de macro (30 s par défaut). |
| `RunMacro(obj1, obj2, ...)` | Exécute le code actuellement ouvert dans l'éditeur de macros de PDIndexer. Les paramètres sont lus dans PDIndexer sous la forme `PDI.Obj[0]`, `PDI.Obj[1]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Exécute la macro enregistrée sous le nom `name` dans PDIndexer. Les paramètres sont lus dans PDIndexer sous la forme `PDI.Obj[0]`, `PDI.Obj[1]`, … |
