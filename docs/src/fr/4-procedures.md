<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Procédures

Cette page présente le déroulement des tâches typiques. Pour la description des différents outils, voir [Outils](3-tools.md).

## Déroulement de base (intégration concentrique)

1. **Charger une image** : File → Read image (ou glisser-déposer).
2. **Définir la source** : définissez l'élément/la transition ou la longueur d'onde sous **Wave source** dans les propriétés.
3. **Définir la condition du détecteur** : définissez la longueur de caméra, la taille de pixel, la position du centre (approximative) et, si nécessaire, l'inclinaison φ, τ sous **Detector condition**.
4. **Trouver le centre** : détectez automatiquement le centre du faisceau avec **Find Center** dans la barre d'outils (la plage de recherche se définit sous Miscellaneous).
5. **Masquer les taches** : supprimez les réflexions de monocristal et similaires avec **Mask Spots**. Si nécessaire, masquez manuellement avec **Manual**.
6. **Unidimensionnaliser** : obtenez le profil avec **Get Profile**. L'enregistrement et l'envoi se configurent dans l'onglet **After "Get Profile"** (enregistrement CSV, envoi vers PDIndexer, etc.).

Pour les images séquentielles, sélectionnez une trame dans [Sequential](3-tools.md) avant les étapes 5–6. Pour une analyse par azimut, utilisez l'intégration radiale dans **Integral Property**.

## Détermination des paramètres : calibration géométrique avec un échantillon de référence (double cassette)

Lorsque la longueur de caméra ou la longueur d'onde est inconnue, optimisez les paramètres géométriques à partir des anneaux de diffraction d'un matériau de référence (CeO2 par défaut, etc.), en utilisant [Find Parameter (Geometric)](3-tools.md).

1. Chargez la **Primary image** (échantillon de référence, à une longueur de caméra) avec Open, trouvez le centre et affichez les pics avec **Get Profile**.
2. Faire glisser un marqueur de ligne de diffraction dans la Profile View met à jour automatiquement l'estimation de la longueur de caméra.
3. Chargez de la même manière la **Secondary image** (le même échantillon de référence, à une longueur de caméra différente) et saisissez la **différence de longueur de caméra** par rapport à Primary.
4. Dans la **Peak List**, sélectionnez les valeurs d des pics qui apparaissent dans les deux images (au moins un par image, idéalement trois ou plus).
5. Sous **Refinement Option**, choisissez les paramètres à optimiser (longueur d'onde, distance du film, inclinaison, taille de pixel, distorsion de pixel).
6. Lancez **Refine!** et, une fois le résidu stabilisé, recopiez les résultats optimisés dans le formulaire principal.

!!! note
    L'utilisation de deux images (une « double cassette ») facilite la détermination séparée de la longueur de caméra et de la longueur d'onde.

## Détermination des paramètres : optimisation par force brute (échantillon arbitraire)

Lorsque l'optimisation géométrique peine à converger, recherchez la longueur de caméra et la longueur d'onde de façon exhaustive avec [Find Parameter (Brute force)](3-tools.md). Voir [Recherche de paramètres (force brute)](6-find-parameter.md) pour un guide détaillé avec captures d'écran.

1. Chargez les Primary et Secondary images (deux images, avec des anneaux en commun, à des longueurs de caméra différentes).
2. Alignez grossièrement la position du centre dans le formulaire principal (Find Center est utile).
3. Saisissez les **plages de recherche (min, max, step)** pour la longueur de caméra, la longueur d'onde, etc. Laissez désactivés au début les paramètres inconnus (taille de pixel, inclinaison).
4. Régler **Integral Region** en mode fente (Rectangle) avec une bande étroite aide à supprimer le bruit.
5. Lancez la recherche et recopiez la combinaison ayant le plus petit résidu dans le formulaire principal.

## Traitement automatisé (Auto Procedure)

Traitez automatiquement les images qui arrivent dans un dossier, par exemple pendant une expérience. Voir [Outils](3-tools.md) pour les détails.

1. Activez **Automatically load new images** et choisissez le dossier surveillé avec **Set**.
2. Si nécessaire, filtrez les fichiers par **number matching** (le numéro à la fin du nom de fichier) ou par **keyword**.
3. Activez **After Loading Image, Execute "Auto"** et choisissez dans la liste : Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Une fois la surveillance démarrée, la séquence s'exécute automatiquement à chaque arrivée d'une image correspondante.

## Procédures scriptées (macros basées sur Python)

Les traitements avec boucles et conditions peuvent s'écrire sous forme de [macro](5-macro/index.md). Les exemples de macros fournis constituent un bon point de départ.

- Charger une image, définir la source et le détecteur (centre, longueur de caméra, pixels) et ajuster l'affichage.
- Définir les conditions d'intégration concentrique (start, end, step, unité), unidimensionnaliser et enregistrer en CSV.
- Traiter par lots plusieurs fichiers, en enregistrant un CSV à côté de chaque image.
- Traiter une image multi-trames trame par trame.
- Diviser un anneau de Debye en N secteurs et analyser la dépendance azimutale.
- Masquer (tout effacer → masquer les taches → masquer la région du beam-stop → enregistrer le masque) et unidimensionnaliser.
- Sortir l'azimut en fonction de l'intensité avec une intégration radiale (cake).
- Activer l'envoi vers le presse-papiers, unidimensionnaliser et appeler une macro nommée dans PDIndexer (par exemple un ajustement de pics).

Les macros que vous écrivez peuvent être enregistrées, appelées par leur nom et également exécutées depuis Auto Procedure.
