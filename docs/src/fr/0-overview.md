<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Aperçu

IPAnalyzer convertit les anneaux de Debye–Scherrer enregistrés avec des imaging plates (IP) ou des détecteurs CCD/CMOS en profils de diffraction unidimensionnels, avec une grande précision et rapidité. Sa conception et ses fonctionnalités s'inspirent de PIP, développé par Hiroshi Fujihisa au National Institute of Advanced Industrial Science and Technology (AIST).

Fonctionnalités principales :

- Prend en charge un large éventail de formats d'image (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon et formats d'image courants)
- Sources de rayons X, d'électrons et de neutrons
- Intégration avec PDIndexer
- Analyse semi-automatique des paramètres de mesure

## Configuration requise et installation

### Prérequis

- OS : Windows (Windows 11 recommandé)
- Runtime requis : .NET Desktop Runtime 10.0
- Mémoire recommandée : 16 Go ou plus
- CPU recommandé : 8 cœurs ou plus

En interne, le logiciel fait un usage intensif du calcul multi-thread, de sorte qu'un CPU disposant de plus de cœurs fonctionne plus confortablement. Les intensités des images sont conservées en interne sous forme de valeurs à virgule flottante en double précision.

Le logiciel est distribué sous licence MIT.

### Installation

1. Installez au préalable [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Téléchargez `IPAnalyzerSetup.msi` depuis la [page des releases](https://github.com/seto77/IPAnalyzer/releases) GitHub.
3. Exécutez `IPAnalyzerSetup.msi` pour procéder à l'installation.

## Orientation des axes, inclinaison de l'IP et forme des pixels

IPAnalyzer utilise un système de coordonnées orienté à droite, dont l'origine et les directions des axes sont définies comme suit.

- Le point où le faisceau de rayons X ou d'électrons intersecte l'IP (le direct spot) est défini comme l'origine (0, 0, 0), et l'axe Z coïncide avec la direction du faisceau.
- En considérant la taille de l'échantillon comme infinitésimale, la distance entre la position de l'échantillon et l'origine est définie comme la longueur de caméra (Camera Length, CL). L'échantillon est donc situé en \((0,\ 0,\ -\mathrm{CL})\).
- L'axe X est aligné avec la direction de balayage du laser de lecture de l'IP lorsque l'IP n'est pas inclinée. L'axe Y pointe donc vers le bas de l'écran.
- L'inclinaison de l'IP est exprimée comme une rotation autour d'une ligne située dans le plan XY et passant par l'origine : une rotation de \( \tau \) autour de la ligne qui fait un angle \( \varphi \) avec l'axe X.
- La forme du pixel est traitée comme un parallélogramme décrit par PixSizeX, PixSizeY et \( \xi \). Une valeur de \( \xi \) non nulle signifie qu'il existe un décalage dans la position de départ du balayage du laser de lecture de l'IP. Le logiciel suppose que ce décalage est constant le long de l'axe Y.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

La longueur de caméra, \( \varphi \), \( \tau \), la taille de pixel et \( \xi \) se règlent dans l'onglet IP Condition de la fenêtre de propriétés (voir [2. Fenêtres de propriétés](2-property-windows.md)).

### Relation avec (WIN)PIP

Dans IPAnalyzer, l'axe X (la direction vers la droite de l'image IP) est tourné dans le sens horaire de \( \varphi \), puis l'axe résultant est tourné de \( \tau \). Dans PIP, l'axe Y (la direction vers le bas de l'image IP) est tourné dans le sens antihoraire de \( \beta \), puis l'axe résultant est tourné de \( \Phi \). Par conséquent, pour convertir le couple \((\beta,\ \Phi)\) de PIP vers le couple \((\varphi,\ \tau)\) d'IPAnalyzer, utilisez \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Méthode d'intégration de l'intensité des pixels

Le problème central de l'unidimensionnalisation consiste à savoir comment répartir, entre les pas d'intégration, l'intensité d'un pixel qui chevauche plusieurs pas — ce qui se produit lorsque l'intervalle de pas angulaire est plus petit que l'intervalle des pixels (c'est-à-dire la taille de pixel).

Le logiciel calcule les intersections entre les lignes qui délimitent chaque pas et le pixel, et répartit l'intensité en déterminant l'aire de pixel contenue dans chaque pas. Pour gérer les cas où le pixel n'est pas exactement carré — en raison de l'inclinaison de l'IP ou d'une distorsion de la forme du pixel — les coordonnées des quatre coins de chaque pixel sont calculées successivement afin de déterminer sa forme quadrilatérale. En principe, cela permet de répartir l'intensité du pixel de manière continue entre les pas, quelle que soit la finesse des pas.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

Cet algorithme est utilisé non seulement pour l'intégration ordinaire angle–intensité (Concentric Integration), mais aussi pour l'intégration le long de la circonférence (Radial Integration) et pour le calcul de l'image déroulée (Unrolled Image).
