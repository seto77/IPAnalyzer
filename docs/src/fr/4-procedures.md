<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Procédures

Cette page présente le déroulement des tâches typiques. Pour la description de chaque outil, voir [Outils](3-tools.md).

## Déroulement de base (intégration concentrique)

1. **Charger une image** : Fichier → Lire l'image (File → Read image) (ou glisser-déposer).
2. **Régler la source** : réglez l'élément/la transition ou la longueur d'onde dans **Source d'onde (Wave source)** des propriétés.
3. **Régler la condition du détecteur** : réglez la longueur de caméra, la taille de pixel, la position du centre (approximative) et, si nécessaire, l'inclinaison φ, τ dans **Condition du détecteur (Detector condition)**.
4. **Trouver le centre** : détectez automatiquement le centre du faisceau avec **Trouver le centre (Find Center)** dans la barre d'outils (la plage de recherche se règle dans l'onglet Divers (Miscellaneous)).
5. **Masquer les taches** : supprimez les réflexions de monocristal et autres avec **Masquer les taches (Mask Spots)**. Si nécessaire, masquez manuellement avec **Mode manuel (Manual Mode)**.
6. **Vérifier les réglages d'intégration** : sélectionnez la région cible dans **Région d'intégration (Integral Region)**, et choisissez **Intégration concentrique (dispersive en angle de diffusion) (Concentric integration (scattering angle dispersive))** avec l'unité de l'axe et **Début / Fin / Pas (Start / End / Step)** dans **Propriété d'intégration (Integral Property)**.
7. **Intégrer l'image** : obtenez le profil avec **Obtenir le profil (Get Profile)**. L'enregistrement et l'envoi se règlent dans l'onglet **Après « Obtenir le profil » (After "Get Profile")** (enregistrement CSV, envoi vers PDIndexer, etc.).

Pour les images séquentielles, sélectionnez une trame dans [Image séquentielle (Sequential image)](3-tools.md) avant les étapes 5 à 7. Pour une analyse par azimut, utilisez **Analyse par division azimutale (Azimuthal Division Analysis)** dans le menu déroulant de **Obtenir le profil (Get Profile)** (les anneaux sont découpés en secteurs et chaque secteur est intégré ; disponible uniquement avec l'intégration concentrique et l'axe **Angle** (2θ)), ou **Intégration radiale (motif en parts de gâteau) (Radial integration (cake pattern))** dans **Propriété d'intégration (Integral Property)** (un profil azimut–intensité).

Si la longueur de caméra, la longueur d'onde ou l'inclinaison sont inconnues, calibrez-les d'abord à partir d'une image d'un échantillon de référence comme décrit dans la section suivante, appliquez les valeurs obtenues, puis intégrez les images de l'échantillon.

## Détermination des paramètres : calibration géométrique avec un échantillon de référence (double cassette)

Lorsque la longueur de caméra ou la longueur d'onde est inconnue, optimisez les paramètres géométriques à partir des anneaux de diffraction d'un matériau de référence (CeO2 par défaut, etc.), à l'aide de [Trouver paramètre (géométriquement) (Find parameter (geometrically))](3-tools.md).

1. Chargez l'**Image primaire (Primary image)** (échantillon de référence, à une longueur de caméra) avec **Ouvrir (Open)**, trouvez le centre et affichez les pics avec **Obtenir le profil (Get Profile)**.
2. Faire glisser un marqueur de raie de diffraction dans la Profile View met automatiquement à jour l'estimation de la longueur de caméra.
3. Chargez de la même façon l'**Image secondaire (Secondary image)** (le même échantillon de référence, à une autre longueur de caméra), et saisissez la **différence de longueur de caméra** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) (par ex. +20 si l'image primaire est à 100 mm et l'image secondaire à 120 mm). L'image secondaire est facultative ; la calibration fonctionne aussi avec l'image primaire seule.
4. Dans la **Liste des pics (Peak List)**, sélectionnez les valeurs d des pics qui apparaissent dans les deux images (normalement trois ou plus par image ; avec deux images, au moins un doit être commun aux deux. Sauf si seule la longueur de caméra est affinée, **Affiner ! (Refine!)** ne fait rien avec moins de trois pics).
5. Choisissez les paramètres à optimiser (**Longueur d'onde (Wave Length)**, **Longueur de caméra (Camera Length)**, **Correction d'inclinaison (Tilt Correction)**, **Taille de pixel (Pixel Size)**, **Distorsion de pixel (Pixel Distortion)**, **Position du centre (Center Position)**, **Correction sphérique (Spherical Correction)**).
6. Lancez **Affiner ! (Refine!)**. L'affinement s'arrête automatiquement après le nombre de répétitions réglé (12 par défaut). Après avoir vérifié le résultat, copiez-le vers la fenêtre principale avec **Paramètres affinés => Fenêtre principale (Refined parameters => Main form)**.

!!! note
    L'utilisation de deux images (une « double cassette ») permet de déterminer plus facilement la longueur de caméra et la longueur d'onde séparément.

## Détermination des paramètres : optimisation par force brute (échantillon de référence)

Lorsque l'optimisation géométrique converge difficilement, recherchez de façon exhaustive la longueur de caméra, la position du centre, l'inclinaison et, en option, la longueur d'onde avec [Trouver paramètre (force brute) (Find parameter (brute force))](3-tools.md). Voir [Recherche de paramètres (force brute)](6-find-parameter.md) pour une présentation détaillée avec captures d'écran.

1. Chargez une image d'un échantillon de référence dans la fenêtre principale, ouvrez Trouver paramètre (force brute) (Find parameter (brute force)) et sélectionnez le matériau de référence correspondant.
2. Alignez grossièrement la position du centre dans la fenêtre principale (Trouver le centre (Find Center) est utile).
3. Choisissez les éléments à optimiser, et saisissez le pas **Pas initial (Initial step)** (centré sur la valeur actuelle) et le nombre de pas de chaque côté (**Plage de recherche (Search range)**). Pour un détecteur plan, la taille de pixel n'est pas une cible de la recherche. Voir [Recherche de paramètres (force brute)](6-find-parameter.md) pour des exemples numériques.
4. Régler **Région d'intégration (Integral Region)** en mode fente (**Rectangle**) avec une faible largeur de bande aide à réduire le bruit.
5. Lancez la recherche avec **Optimiser (Optimize)**. À chaque cycle, la combinaison donnant la plus petite valeur d'évaluation R est retenue et écrite automatiquement dans les paramètres de la fenêtre principale.

## Traitement automatisé (Procédure auto.)

Traitez automatiquement les images qui arrivent dans un dossier, par exemple pendant une expérience. Voir [Outils](3-tools.md) pour plus de détails.

1. Choisissez le dossier à surveiller avec **Définir (Set)**.
2. Si nécessaire, filtrez les fichiers par **Correspondance de motifs (Pattern matching)** (le numéro à la fin du nom de fichier) ou par **Mot-clé (Keyword)**.
3. Activez **Une fois la nouvelle image chargée, exécuter la séquence suivante (Once the new image is loaded, perform the following sequence)**, et choisissez dans la liste : **Auto contrast** / **Find center** / **Mask spots** / **Get profile** / **Execute macro**.
4. Enfin, activez **Charger automatiquement les nouvelles images (Automatically load new images)** pour lancer la surveillance (cette option ne peut pas être activée sans dossier ; les conditions de numéro/mot-clé en vigueur au démarrage de la surveillance sont utilisées). La séquence s'exécute alors automatiquement à chaque arrivée d'une image correspondante. Un fichier encore verrouillé après l'attente de la fin de l'écriture (environ 50 s) est retenté lors des balayages suivants et abandonné 10 minutes après sa première détection.

## Procédures scriptées (macros basées sur Python)

Les traitements comportant des boucles et des conditions peuvent être écrits sous forme de [macro](5-macro/index.md). Les macros d'exemple affichées avec **Afficher les exemples (Show samples)** dans l'éditeur de macros constituent un bon point de départ.

- Charger une image, régler la source et le détecteur (centre, longueur de caméra, pixels) et ajuster l'affichage.
- Régler les conditions de l'intégration concentrique (début, fin, pas, unité), intégrer et enregistrer au format CSV.
- Traiter par lots plusieurs fichiers, en enregistrant un CSV à côté de chaque image.
- Traiter une image multi-trames trame par trame.
- Découper un anneau de Debye en N secteurs et analyser la dépendance azimutale.
- Masquer (tout effacer → masquer les taches → masquer la région du beam-stop → enregistrer le masque) et intégrer.
- Produire l'intensité en fonction de l'azimut avec l'intégration radiale (cake).
- Activer l'envoi par le presse-papiers, intégrer et appeler une macro nommée dans PDIndexer (par ex. ajustement de pics).

Les macros que vous écrivez peuvent être enregistrées, appelées par leur nom et aussi exécutées depuis la Procédure auto. (Auto procedure).
