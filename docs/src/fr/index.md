<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Manuel d'IPAnalyzer

## Brève introduction

* **IPAnalyzer** est un logiciel libre sous licence MIT qui convertit les images de diffraction de poudre bidimensionnelles (anneaux de Debye–Scherrer) enregistrées avec des Imaging Plates (IP) ou des détecteurs à panneau plat CCD/CMOS en profils 2θ–intensité 1D de haute précision.
* Il calibre la géométrie de mesure — longueur de caméra, longueur d'onde, inclinaison du détecteur et forme de pixel — à partir des anneaux de matériaux de référence, prend en charge les sources de rayons X, d'électrons et de neutrons, et s'intègre avec [PDIndexer](https://github.com/seto77/PDIndexer) pour l'analyse ultérieure des pics.
* Sa conception et ses fonctionnalités suivent *PIP*, développé par Hiroshi Fujihisa à l'AIST.

## Trouver par objectif

| Objectif | Commencer ici | Étapes suivantes principales |
|------|------------|-----------------|
| Comprendre le système de coordonnées et la géométrie | [Aperçu](0-overview.md) | [Fenêtres de propriétés](2-property-windows.md) |
| Charger une image et obtenir un profil 1D | [Procédures](4-procedures.md) | [Fenêtre principale](1-main-window.md), [Fenêtres de propriétés](2-property-windows.md) |
| Calibrer la longueur de caméra / la longueur d'onde | [Procédures](4-procedures.md) | [Outils](3-tools.md), [Recherche de paramètres (force brute)](6-find-parameter.md) |
| Masquer des taches / traiter des données multi-trames | [Outils](3-tools.md) | [Procédures](4-procedures.md) |
| Automatiser le traitement | [Macro](5-macro/index.md) | [Fonctions intégrées](5-macro/1-built-in-functions.md), [Exemples](5-macro/2-examples.md), [Procédure auto. (Auto procedure)](3-tools.md) |
| Dépannage et questions fréquentes | [Questions et réponses](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## Fonctionnalités

* **Prise en charge étendue des formats** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4 et formats d'image généraux. La plupart des entrées/sorties de fichiers acceptent le glisser-déposer.
* **Conversion image → profil** : intégration concentrique (moyenne radiale), intégration radiale (azimutale/cake) et calcul de l'image déroulée, à l'aide d'un algorithme de répartition d'aire en sous-pixels qui traite correctement l'inclinaison du détecteur et les pixels en forme de parallélogramme.
* **Calibration de la géométrie** : affinement géométrique (double cassette) de la longueur d'onde, de la longueur de caméra, de la taille/distorsion de pixel et de l'inclinaison (φ, τ), ainsi qu'une recherche exhaustive sur grille (force brute) pour les données difficiles.
* **Traitement d'image** : détection automatique du centre du faisceau, détection et masquage des taches de monocristal (spots), flou circonférentiel, superposition d'anneaux, calibration de l'intensité des images R-AXIS et enregistrement au format IPA préservant la géométrie.
* **Données multi-trames** : sélectionner, moyenner ou sommer les trames de fichiers NeXus (`.nxs`), de TIFF multipages et d'autres données séquentielles ; lorsqu'une trame contient une information d'énergie, sa sélection met à jour la longueur d'onde.
* **Automatisation** : la Procédure auto. (Auto procedure) avec surveillance de dossier, et une [macro](5-macro/index.md) à syntaxe Python pour le traitement par lots et scripté.
* **Intégration avec PDIndexer** : envoyer les profils vers [PDIndexer](https://github.com/seto77/PDIndexer) via le presse-papiers et y déclencher des macros nommées.

## Configuration requise

Ces exigences s'appliquent aux builds .NET 11 produits à partir de cette arborescence de sources. Pour les versions publiées, suivez l'exigence d'environnement d'exécution indiquée pour chaque version.

| Élément | Minimum | Recommandé |
|------|---------|-------------|
| Système d'exploitation | Windows avec [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) | Windows 11 |
| Mémoire | - | 16 Go ou plus |
| Processeur | - | 8 cœurs ou plus (les intensités de l'image sont conservées en double précision et le traitement est multithread) |

## Démarrage rapide

1. Téléchargez et installez la version disponible sur [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Lisez une image de diffraction (Fichier → Lire l'image (File → Read image), ou glisser-déposer).
3. Dans la fenêtre de propriétés, réglez **Source d'onde (Wave source)** et **Condition du détecteur (Detector condition)** (longueur de caméra, taille de pixel, centre approximatif).
4. Si la géométrie (longueur de caméra, longueur d'onde, inclinaison) est inconnue, calibrez-la d'abord à partir d'une image d'un échantillon de référence et appliquez les valeurs obtenues — voir [Procédures](4-procedures.md).
5. Sur l'image de l'échantillon, trouvez le centre, masquez les taches si nécessaire, puis appuyez sur **Obtenir le profil (Get Profile)** pour obtenir le profil 1D.

Voir [Procédures](4-procedures.md) pour le déroulement complet.

## Comment utiliser ce manuel

Ce manuel GitHub Pages est la référence actuelle. Utilisez la navigation de gauche pour parcourir les chapitres, ou la recherche dans l'en-tête pour trouver un nom de fonction ou un libellé de l'interface. Il remplace l'ancien manuel Word/HTML/PDF distribué dans `IPAnalyzer/doc/`.

## Licence

IPAnalyzer est distribué sous la [licence MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
