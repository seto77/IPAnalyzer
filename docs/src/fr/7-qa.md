<!-- 261124Cl: Retranslated from en/7-qa.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Questions et réponses (foire aux questions)

Cette page rassemble les questions posées le plus souvent et les points facilement mal compris. Les libellés sont les noms affichés par l'interface en français ; le nom anglais est indiqué entre parenthèses. Pour les questions qui ne sont pas traitées ici, ou pour signaler un bogue, veuillez utiliser [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Installation et démarrage

### Seule la fenêtre de propriétés apparaît ; la fenêtre principale est invisible

La fenêtre principale est placée en dehors de l'écran.

1. Survolez l'icône d'IPAnalyzer dans la barre des tâches, cliquez avec le bouton droit sur la miniature, choisissez **Déplacer (Move)**, appuyez une fois sur une touche fléchée, puis déplacez la souris.
2. Si cela ne suffit pas, quittez IPAnalyzer, ouvrez l'Éditeur du Registre (regedit), supprimez `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer`, puis redémarrez IPAnalyzer (tous les réglages reviennent à leurs valeurs par défaut).

### Après une mise à jour, l'ancienne version tourne toujours / IPAnalyzer ne démarre plus

Réinstallez directement depuis la [dernière version](https://github.com/seto77/IPAnalyzer/releases/latest). Si l'installation n'écrase pas l'ancienne version, ou si le programme ne démarre pas, désinstallez-le une fois depuis les Paramètres de Windows, puis réinstallez-le. Si une nouvelle version pose problème, vous pouvez installer une version plus ancienne depuis la même page des versions.

### Je veux l'utiliser sur un PC sans droits d'administrateur, ou sous Windows on Arm

- Sans droits d'administrateur, utilisez la version portable (`IPAnalyzer-v.<version>.zip`), qui ne nécessite pas d'installation et inclut l'environnement d'exécution .NET.
- Sous Windows on Arm, utilisez le programme d'installation arm64 (`IPAnalyzer-setup_arm64.msi`) ou la version portable (`IPAnalyzer-v.<version>_arm64.zip`).

Voir [Installation dans l'Aperçu](0-overview.md#installation) pour plus de détails.

### Le chargement de nombreuses trames provoque une erreur. Quelle quantité de mémoire faut-il ?

IPAnalyzer conserve l'intensité de chaque pixel en double précision (8 octets), quelle que soit la profondeur de bits d'origine. Par exemple, 5000 images de 1554×516 pixels nécessitent environ 32 Go pour les seules intensités. Traitez les données comportant de nombreuses trames sur un PC disposant de suffisamment de mémoire, ou traitez-les par portions avec une macro.

## Lecture des images

### Les fichiers de mon détecteur ne peuvent pas être lus

Le format n'est peut-être pas encore pris en charge. Veuillez nous contacter via [Issues](https://github.com/seto77/IPAnalyzer/issues) ou contacter l'auteur en joignant un fichier réel (de préférence un fichier avec un cliché de diffraction, et pas seulement une image d'obscurité). L'exactitude des intensités et l'orientation de l'image ne peuvent être vérifiées qu'avec une image qui montre un cliché. Si le chargement échoue, l'image chargée précédemment est conservée ; vous pouvez donc continuer à travailler avec elle.

!!! note "Lorsqu'une image brute a une largeur et une hauteur erronées"
    Pour les fichiers bruts sans en-tête, le modèle de détecteur et le nombre de pixels sont déduits de la taille du fichier. Le nombre réel de pixels diffère souvent de la valeur du catalogue ; veuillez donc envoyer le fichier si la détection échoue.

### Après avoir chargé un fichier de paramètres puis ouvert une image, les paramètres changent

IPAnalyzer **mémorise les paramètres tels que la longueur de caméra, la longueur d'onde et la taille de pixel pour chaque format d'image**, et bascule sur ces valeurs à l'ouverture d'une image. Chargez donc le fichier de paramètres (`.prm`) **après avoir ouvert l'image**. Les formats ayant des extensions différentes sont mémorisés séparément, même si leur contenu est identique.

### Dois-je retourner ou faire pivoter chaque image à nouveau ?

Non. Les réglages **Option → Retourner / Pivoter (Option → Flip / Rotate)** sont eux aussi mémorisés par format d'image et sont appliqués automatiquement à la prochaine ouverture d'une image du même format. Le retournement et la rotation affectent aussi l'intégration et l'enregistrement d'image (le fichier source n'est pas modifié).

### Comment les fichiers à plusieurs trames (`.his`, `.nxs`, TIFF multipages, …) sont-ils traités ?

Lorsqu'un tel fichier est chargé, la fenêtre **Image séquentielle (Sequential image)** s'ouvre et vous pouvez sélectionner la trame à afficher. Pour les intégrer ensemble, utilisez **Obtenir les profils de toutes les images séquentielles (Get Profiles for all sequential images)** ou **Obtenir les profils des images sélectionnées (Get Profiles for selected images)** dans le menu déroulant de **Obtenir le profil (Get Profile)**. Voir [Outils](3-tools.md#image-séquentielle-sequential-image) pour plus de détails.

## Calibration

### Quand utiliser Trouver paramètre (géométriquement) et quand Trouver paramètre (force brute) ?

| | Géométriquement | Force brute |
|---|---|---|
| Principe | Divise l'image en secteurs, trouve les positions des pics et détermine le centre, l'inclinaison, etc. à partir des formes elliptiques et des centres des anneaux de Debye | Fait varier les paramètres pas à pas et cherche la combinaison qui fait le mieux concorder les positions de pics calculées et ajustées |
| Données adaptées | Anneaux visibles presque sur tout le tour (au moins cinq directions) | Seule une partie des anneaux enregistrée, spot direct hors de l'image, anneaux tachetés |
| Images | Une, ou deux prises à des longueurs de caméra différentes | Une |
| Précaution | La précision diminue ou l'affinement ne converge pas si les anneaux ne sont pas visibles sur tout le tour | Nécessite des valeurs de départ assez bonnes ; prend du temps |

Voir [Procédures](4-procedures.md) et [Recherche de paramètres (force brute)](6-find-parameter.md) pour les étapes.

### Quel échantillon de référence utiliser pour la calibration ?

Un échantillon à grains fins donnant des anneaux de Debye lisses (non tachetés), visibles sur un tour aussi complet que possible, convient. Environ cinq anneaux ou plus est un bon repère. Avec seulement deux anneaux complets, une détermination précise est difficile, et il faut connaître soit la longueur d'onde, soit la longueur de caméra. Pour la calibration par force brute, choisissez le matériau de référence parmi Au / CeO₂ / LaB₆ / Al₂O₃, ou sélectionnez **Autre (Other)** et saisissez les paramètres de maille.

### La calibration ne converge pas / le centre ne cesse de dériver

- Fixez les valeurs auxquelles vous pouvez vous fier (taille de pixel du catalogue, longueur d'onde connue, etc.) et réduisez le nombre de variables affinées.
- Ajustez d'abord grossièrement avec quelques anneaux aux petits angles, puis ajoutez les anneaux aux grands angles.
- Un anneau dont l'analyse a échoué peut perturber tout le résultat. Si un anneau s'écarte des autres dans le graphique des centres d'anneaux, retirez-le.
- Si l'ajustement échoue lorsque les anneaux aux grands angles sont inclus, limitez les pics à ceux dont les anneaux sont encore visibles sur tout le tour, élargissez la plage d'ajustement et utilisez moins de secteurs.
- Saisissez des valeurs de départ aussi correctes que possible avant de commencer.

### La longueur de caméra et la longueur d'onde ne peuvent-elles être déterminées que si l'une d'elles est fixée ?

Avec un matériau de référence dont les paramètres de maille sont connus avec précision, les deux peuvent être déterminées même à partir d'une seule image (à partir des rapports des positions des anneaux). En revanche, **la longueur de caméra et la taille de pixel ne peuvent pas être déterminées ensemble à partir d'une seule image**. Fiez-vous à la taille de pixel du catalogue et fixez-la. Avec deux images dont la différence de longueur de caméra est connue (méthode de la double cassette), la taille de pixel peut aussi être affinée.

### Le spot direct n'est pas enregistré / se trouve hors de l'image

Saisissez la position du spot direct à la main et décochez **Trouver le centre avant d'obtenir le profil (Find Center before Get Profile)** dans le menu déroulant de **Obtenir le profil (Get Profile)**. Si le spot se trouve hors de l'image, des coordonnées négatives conviennent. Utilisez la calibration par force brute pour ce type de données.

### Le centre trouvé par Trouver le centre diffère de quelques pixels du centre calibré

Ils sont déterminés différemment. **Trouver le centre (Find Center)** ajuste le spot direct près du centre actuel avec une fonction pseudo-Voigt bidimensionnelle. La calibration n'utilise pas l'intensité du spot direct ; elle déduit le centre des centres des ellipses de plusieurs anneaux de Debye. Une fois l'inclinaison correctement déterminée, le centre calibré peut être utilisé tel quel. Si le spot direct est saturé, affichez un cercle sur un anneau de Debye avec **Tracer l'anneau (Draw ring)** et appuyez sur **Trouver le centre (Find Center)** : le centre est alors déterminé à partir de l'anneau.

### Qu'est-ce que la correction sphérique ?

Une correction pour un détecteur courbé comme une sphère. Saisissez l'inverse du rayon de courbure, 1/R, en m⁻¹ (affiché /m à l'écran). Utilisez 0 pour un détecteur plan. Elle est utile lorsque les anneaux aux grands angles ne concordent pas, par exemple avec un grand détecteur placé près de l'échantillon.

### Comment convertir les valeurs d'inclinaison d'autres logiciels (comme PIP) ?

Les (β, Φ) de PIP se convertissent en (φ, τ) d'IPAnalyzer = (270° − β, Φ). Voir l'[Aperçu](0-overview.md#relation-avec-winpip) pour les définitions.

## Intégration et sortie

### L'axe horizontal du résultat semble faux / l'intensité semble presque constante

Vérifiez si **Intégration radiale (motif en parts de gâteau) (Radial integration (cake pattern))** est sélectionnée dans l'onglet **Propriété d'intégration (Integral Property)** de la fenêtre de propriétés. Dans ce mode, le profil a pour axe horizontal l'azimut χ. Le profil 2θ–intensité habituel s'obtient avec **Intégration concentrique (dispersive en angle de diffusion) (Concentric integration (scattering angle dispersive))**.

### Je veux enregistrer le profil dans un fichier sans PDIndexer

Dans l'onglet **Après « Obtenir le profil » (After "Get Profile")** de la fenêtre de propriétés, réglez la destination (même dossier que l'image / choix à chaque fois) et le format (PDI / CSV / TSV / GSAS) sous **Enregistrer le profil (Save Profiles)**. Le profil est alors enregistré à chaque intégration.

### Que contient la troisième colonne du CSV ?

L'erreur de comptage sur l'intensité, calculée à partir de la racine carrée de l'intensité de pixel sommée dans chaque pas, traitée comme un nombre de coups. L'intensité de la deuxième colonne est convertie en l'équivalent d'une géométrie de Bragg–Brentano ; elle n'est donc pas égale au carré de la troisième colonne. PDIndexer peut l'afficher sous forme de barres d'erreur.

### Les valeurs de 2θ du CSV n'ont que deux décimales. Est-ce la limite de précision ?

Non. Cela ne paraît ainsi que parce que l'intégration a été configurée avec, par exemple, un début à 20,00° et un pas de 0,01°. Le calcul est effectué en double précision. La précision du résultat est déterminée par les erreurs sur les paramètres d'entrée tels que la longueur de caméra et la longueur d'onde.

### Pour les images séquentielles, faut-il utiliser Moyenne ou Sommation ?

Le rapport S/B est le même dans les deux cas. **Sommation (Summation)** donne une estimation correcte des erreurs ; elle est donc recommandée pour les analyses qui utilisent les erreurs, comme l'affinement de Rietveld.

### Je veux intégrer pour chaque azimut (chaque secteur)

Activez **Analyse par division azimutale (Azimuthal Division Analysis)** dans le menu déroulant de **Obtenir le profil (Get Profile)**, réglez **Nombre de divisions (Number of divisions)** et intégrez. Un profil global (nom se terminant par `-whole`) et un profil par secteur (avec l'angle de début ajouté, comme `-000`, `-010`, …) sont créés. Cela ne fonctionne qu'avec **Intégration concentrique (dispersive en angle de diffusion) (Concentric integration (scattering angle dispersive))** et l'axe **Angle** (2θ) ; avec l'intégration radiale ou un axe en distance interréticulaire, un avertissement s'affiche et rien n'est exécuté. Avec trop de divisions, les données envoyées à PDIndexer peuvent devenir trop volumineuses.

### Je veux une carte bidimensionnelle de 2θ et de l'azimut χ (image déroulée)

Utilisez **Dérouler l'image (Unroll image)** dans la barre d'outils. Réglez la plage et le pas dans l'onglet **Option d'image déroulée (Unrolled Image Option)** de la fenêtre de propriétés. Avec **Fichier → Enregistrer l'image (File → Save image)**, le TIFF conserve les valeurs calculées en virgule flottante, et le PNG enregistre ce qui est affiché à l'écran.

### Je veux la somme ou la moyenne des intensités d'une partie rectangulaire de l'image

Sélectionnez un rectangle par Ctrl + glisser droit sur l'image. Les statistiques apparaissent dans l'onglet **Informations statistiques (Statistical Information)** en bas. Pour les images séquentielles, la même région peut être comparée d'une trame à l'autre.

### Une image d'obscurité devient plus claire vers les bords aux grands angles

Si **Corriger la polarisation linéaire (c.-à-d. polarisée linéairement → non polarisée) (Correct linear polarization (i.e., linear polarized → unpolarized))** est activé sous **Source d'onde (Wave source)** dans la fenêtre de propriétés, la correction est aussi appliquée aux signaux qui ne proviennent pas des rayons X (courant d'obscurité, bruit électronique), et le côté des grands angles devient plus clair. Désactivez-la pour les images d'obscurité.

### Je veux soustraire une image d'obscurité (de fond)

Dans l'onglet **Option de fond (Background Option)** de la fenêtre de propriétés, enregistrez l'image actuelle comme fond et réglez le coefficient. Elle est ensuite soustraite automatiquement des images de même taille. Voir [Fenêtres de propriétés](2-property-windows.md) pour plus de détails.

## Traitement par lots et macros

### Je veux intégrer de nombreux fichiers en une seule fois

**Obtenir les profils de toutes les images séquentielles (Get Profiles for all sequential images)** concerne plusieurs trames contenues dans un seul fichier. Pour traiter plusieurs fichiers, utilisez une [macro](5-macro/index.md). Les [exemples](5-macro/2-examples.md) en comprennent un qui intègre tour à tour les fichiers sélectionnés et enregistre des fichiers CSV. Avant de l'exécuter, ouvrez une image et chargez le fichier de paramètres (voir [la mémorisation des paramètres](#après-avoir-chargé-un-fichier-de-paramètres-puis-ouvert-une-image-les-paramètres-changent)).

### Je veux appeler depuis le menu une macro souvent utilisée

Donnez un nom à la macro et ajoutez-la dans l'éditeur de macros ; elle peut alors être appelée depuis le menu **Macro** de la fenêtre principale.

### Je veux intégrer les images au fur et à mesure de leur arrivée pendant une mesure

Surveillez le dossier avec la [Procédure auto. (Auto procedure)](3-tools.md#procédure-auto-auto-procedure). Les fichiers encore en cours d'écriture sont lus une fois l'écriture terminée ; un fichier encore verrouillé après environ 50 s est retenté lors des balayages suivants et abandonné 10 minutes après sa première détection. Si la lecture échoue pour un dossier situé sur le réseau, enregistrez sur le disque local du PC de mesure et surveillez ce dossier.

## Signaler un bogue

### Que faut-il joindre à un rapport de bogue ?

Le problème ne peut souvent pas être reproduit dans l'environnement de l'auteur ; veuillez donc joindre :

- le fichier de paramètres au moment du problème (**Fichier → Enregistrer le paramètre (File → Save parameter)**),
- le fichier image avec lequel le problème s'est produit, et
- le message d'erreur (une capture d'écran convient) et la version d'IPAnalyzer.

Veuillez signaler le problème via [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Malentendus fréquents

| Idée reçue | En réalité |
|---|---|
| Charger d'abord le fichier de paramètres, puis ouvrir l'image | L'ouverture d'une image bascule sur les valeurs mémorisées pour son format. Ouvrez d'abord l'image, puis chargez le fichier de paramètres |
| **Obtenir les profils de toutes les images séquentielles (Get Profiles for all sequential images)** traite plusieurs fichiers à la fois | Cette fonction concerne plusieurs trames d'un seul fichier. Utilisez une macro pour plusieurs fichiers |
| PDIndexer est nécessaire pour enregistrer un profil | IPAnalyzer seul peut enregistrer dans un fichier (onglet Après « Obtenir le profil » (After "Get Profile")) |
| La troisième colonne du CSV est un autre profil | C'est l'erreur de comptage sur l'intensité |
| La sommation améliore le rapport S/B | Le rapport S/B est le même qu'avec la moyenne ; seule l'estimation des erreurs diffère |
| La longueur de caméra et la taille de pixel peuvent toutes deux être déterminées à partir d'une seule image | Pas ensemble à partir d'une seule image ; fixez la taille de pixel à sa valeur du catalogue |
| Le retournement et la rotation ne changent que l'affichage | Ils affectent aussi l'intégration et l'enregistrement d'image |
| L'envoi vers PDIndexer applique au profil une correction de Lorentz-polarisation | PDIndexer ne tient compte de la polarisation que pour les intensités des raies de diffraction calculées ; le profil lui-même n'est pas modifié |
