<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# Manuel d'IPAnalyzer

## Brève introduction

* **IPAnalyzer** est un logiciel libre sous licence MIT qui convertit les images de diffraction de poudre bidimensionnelles (anneaux de Debye–Scherrer) enregistrées avec des imaging plates (IP) ou des détecteurs à panneau plat CCD/CMOS en profils 2θ–intensité unidimensionnels de haute précision.
* Il calibre la géométrie de mesure — longueur de caméra, longueur d'onde, inclinaison du détecteur et forme de pixel — à partir des anneaux de matériaux de référence, prend en charge les sources de rayons X, d'électrons et de neutrons, et s'intègre avec [PDIndexer](https://github.com/seto77/PDIndexer) pour l'analyse de pics ultérieure.
* Sa conception et ses fonctionnalités suivent *PIP*, développé par Hiroshi Fujihisa à l'AIST.

## Trouver par objectif

| Objectif | Commencer ici | Étapes suivantes principales |
|------|------------|-----------------|
| Comprendre le système de coordonnées et la géométrie | [Aperçu](0-overview.md) | [Fenêtres de propriétés](2-property-windows.md) |
| Charger une image et obtenir un profil 1D | [Procédures](4-procedures.md) | [Fenêtre principale](1-main-window.md), [Fenêtres de propriétés](2-property-windows.md) |
| Calibrer la longueur de caméra / la longueur d'onde | [Procédures](4-procedures.md) | [Outils](3-tools.md), [Recherche de paramètres (force brute)](6-find-parameter.md) |
| Masquer des taches / traiter des données multi-trames | [Outils](3-tools.md) | [Procédures](4-procedures.md) |
| Automatiser le traitement | [Macro](5-macro/index.md) | [Fonctions intégrées](5-macro/1-built-in-functions.md), [Exemples](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Fonctionnalités

* **Prise en charge étendue des formats** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4 et formats d'image généraux. La plupart des entrées/sorties de fichiers prennent en charge le glisser-déposer.
* **Conversion image-vers-profil** : Calcul concentrique (moyenne radiale), radial (azimutal/cake) et d'image déroulée, à l'aide d'un algorithme de distribution d'aire en sous-pixels qui traite correctement l'inclinaison du détecteur et les formes de pixel en parallélogramme.
* **Calibration de la géométrie** : Affinement géométrique (double cassette) de la longueur d'onde, de la longueur de caméra, de la taille/distorsion de pixel et de l'inclinaison (φ, τ), ainsi qu'une recherche exhaustive sur grille (force brute) pour les données difficiles.
* **Traitement d'image** : Détection automatique du centre du faisceau, détection et masquage des taches de monocristal (spots), flou circonférentiel, superpositions d'anneaux, calibration du détecteur par table d'intensités et sauvegarde IPA préservant la géométrie.
* **Données multi-trames** : Sélectionner, moyenner ou sommer les trames de données HDF5/NeXus et autres données séquentielles, avec une longueur d'onde par trame issue de l'énergie embarquée.
* **Automatisation** : Auto Procedure avec surveillance de dossier et une [macro](5-macro/index.md) à syntaxe Python pour le traitement par lots et scripté.
* **Intégration PDIndexer** : Envoyer les profils vers [PDIndexer](https://github.com/seto77/PDIndexer) via le presse-papiers et y déclencher des macros nommées.
* **Thème clair / sombre** : L'interface suit un mode de couleur clair ou sombre sélectionnable.

## Configuration requise

| Élément | Minimum | Recommandé |
|------|---------|-------------|
| OS | Windows avec [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Mémoire | - | 16 Go ou plus |
| CPU | - | 8 cœurs ou plus (les intensités d'image sont conservées en double précision et le traitement est multithreadé) |

## Démarrage rapide

1. Téléchargez et installez depuis [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Lisez une image de diffraction (File → Read image, ou glisser-déposer).
3. Définissez le **Wave source** et la **Detector condition** (longueur de caméra, taille de pixel, centre approximatif) dans la fenêtre de propriétés.
4. Trouvez le centre, masquez les taches si nécessaire, et appuyez sur **Get Profile** pour obtenir le profil 1D.
5. Si la géométrie est inconnue, calibrez-la à partir d'un matériau de référence — voir [Procédures](4-procedures.md).

Voir [Procédures](4-procedures.md) pour le flux de travail complet.

## Comment utiliser ce manuel

Ce manuel GitHub Pages est la source de référence actuelle. Utilisez la navigation de gauche pour parcourir par chapitre, ou utilisez la recherche dans l'en-tête pour trouver un nom de fonction ou une étiquette d'interface. Il remplace l'ancien manuel Word/HTML/PDF distribué dans `IPAnalyzer/doc/`.

## Licence

IPAnalyzer est distribué sous la [licence MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
