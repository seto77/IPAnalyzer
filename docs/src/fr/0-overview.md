<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). -->

# Aperçu

IPAnalyzer convertit les anneaux de Debye–Scherrer enregistrés avec des Imaging Plates (IP) ou des détecteurs CCD/CMOS en profils de diffraction unidimensionnels, avec une grande précision et une grande rapidité. Sa conception et ses fonctionnalités s'inspirent de PIP, développé par Hiroshi Fujihisa au National Institute of Advanced Industrial Science and Technology (AIST).

Principales caractéristiques :

- Prise en charge d'un large éventail de formats d'image (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`) et formats d'image généraux)
- Sources de rayons X, d'électrons et de neutrons
- Intégration avec PDIndexer
- Analyse semi-automatique des paramètres de mesure

## Configuration requise et installation

### Prérequis

Ces exigences s'appliquent aux builds .NET 11 produits à partir de cette arborescence de sources. Pour les versions publiées, suivez l'exigence d'environnement d'exécution indiquée pour chaque version.

- Système d'exploitation : Windows (Windows 11 recommandé)
- Environnement d'exécution requis : .NET Desktop Runtime 11.0
- Mémoire recommandée : 16 Go ou plus
- Processeur recommandé : 8 cœurs ou plus

Le logiciel fait un usage intensif du calcul multithread ; un processeur doté de davantage de cœurs offre donc un fonctionnement plus confortable. Les intensités de l'image sont conservées en interne sous forme de nombres à virgule flottante en double précision.

Le logiciel est distribué sous licence MIT.

### Installation

1. Téléchargez, depuis la [page des versions](https://github.com/seto77/IPAnalyzer/releases/latest) de GitHub, le fichier adapté à votre PC.
    - `IPAnalyzer-setup.msi` : programme d'installation pour les PC Windows ordinaires (x64) (recommandé). `IPAnalyzerSetup.msi` est identique ; ce nom est conservé pour la mise à jour automatique depuis les anciennes versions.
    - `IPAnalyzer-setup_arm64.msi` : programme d'installation pour Windows on Arm.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip` : version portable (sans installation ; l'environnement d'exécution .NET est inclus), pour les PC sans droits d'administrateur.
2. Pour le programme d'installation, installez au préalable [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0), puis exécutez le fichier `.msi` téléchargé.
3. Pour la version portable, extrayez le ZIP dans un dossier accessible en écriture par l'utilisateur et lancez `IPAnalyzer.exe` (ne le lancez pas depuis l'intérieur de la visionneuse ZIP).

## Orientation des axes, inclinaison de l'IP et forme des pixels

IPAnalyzer utilise un système de coordonnées direct (main droite), dont l'origine et les directions des axes sont définies comme suit.

- Le point où le faisceau de rayons X ou d'électrons coupe l'IP (le spot direct) est défini comme l'origine (0, 0, 0), et l'axe Z coïncide avec la direction du faisceau.
- En considérant la taille de l'échantillon comme infinitésimale, la distance entre la position de l'échantillon et l'origine est définie comme la longueur de caméra (Camera Length, CL). L'échantillon se trouve donc en \((0,\ 0,\ -\mathrm{CL})\).
- L'axe X est aligné sur la direction de balayage du laser de lecture de l'IP lorsque l'IP n'est pas inclinée. L'axe Y est donc orienté vers le bas de l'écran.
- L'inclinaison de l'IP est exprimée comme une rotation autour d'une droite située dans le plan XY et passant par l'origine : une rotation de \( \tau \) autour de la droite qui fait un angle \( \varphi \) avec l'axe X.
- La forme du pixel est traitée comme un parallélogramme décrit par PixSizeX, PixSizeY et \( \xi \). Une valeur non nulle de \( \xi \) signifie qu'il existe un décalage de la position de départ du balayage du laser de lecture de l'IP. Le logiciel suppose que ce décalage est constant le long de l'axe Y.

La longueur de caméra, \( \varphi \), \( \tau \), la taille de pixel et \( \xi \) se règlent dans l'onglet **Condition du détecteur (Detector condition)** de la fenêtre de propriétés (voir [2. Fenêtres de propriétés](2-property-windows.md)).

### Relation avec (WIN)PIP

Dans IPAnalyzer, l'axe X (direction vers la droite de l'image IP) est tourné dans le sens horaire de \( \varphi \), puis l'axe obtenu est tourné de \( \tau \). Dans PIP, l'axe Y (direction vers le bas de l'image IP) est tourné dans le sens antihoraire de \( \beta \), puis l'axe obtenu est tourné de \( \Phi \). Par conséquent, pour convertir les \((\beta,\ \Phi)\) de PIP en \((\varphi,\ \tau)\) d'IPAnalyzer, utilisez \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Méthode d'intégration de l'intensité des pixels

Le problème central de la réduction en une dimension est de savoir comment répartir, entre les pas d'intégration, l'intensité d'un pixel qui chevauche plusieurs pas — ce qui se produit dès que la plage d'angles de diffusion couverte par un pixel s'étend sur plus d'un pas en 2θ (d'autant plus souvent que le pas est fin).

Le logiciel calcule les intersections entre les lignes qui délimitent chaque pas et le pixel, et répartit l'intensité en déterminant l'aire du pixel contenue dans chaque pas. Pour traiter les cas où le pixel n'est pas exactement carré — à cause de l'inclinaison de l'IP ou d'une distorsion de la forme du pixel — les coordonnées des quatre coins de chaque pixel sont calculées successivement afin de déterminer sa forme quadrilatère. En principe, cela permet de répartir l'intensité du pixel de façon continue entre les pas, aussi petits soient-ils.

Cet algorithme est utilisé non seulement pour l'intégration angle–intensité ordinaire (Concentric Integration), mais aussi pour l'intégration le long de la circonférence (Radial Integration) et pour le calcul de l'image déroulée (Unrolled Image).
