<!-- 261124Cl: Retranslated from en/3-tools.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Outils

Cette page décrit les outils auxiliaires lancés depuis la barre d'outils verticale à droite de la fenêtre principale, ou depuis les menus. Pour des procédures concrètes utilisant la calibration des paramètres et les macros, voir [Procédures](4-procedures.md).

## Étalonner l'image R-AXIS (Calibrate Raxis Image)

Ouvrez-le avec **Outil → Étalonner l'image R-AXIS (Tool → Calibrate Raxis Image)**. Indiquez deux images R-AXIS IV `.stl` de même taille ; l'outil optimise une table de conversion d'intensité de sorte que les deux intensités concordent. La table est représentée par des points de contrôle, et la somme de ses éléments est maintenue constante pendant l'optimisation. Le résultat est affiché sous forme de graphique. Il sert, par exemple, à calibrer la réponse en intensité d'un détecteur.

![Étalonner l'image R-AXIS (Calibrate Raxis Image)](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Procédure auto. (Auto procedure)

Outil qui surveille un dossier, charge automatiquement les nouvelles images et exécute une séquence d'opérations après le chargement.

- **Surveillance et chargement automatique** : surveille le dossier indiqué (**Répertoire à surveiller (Directory to be monitored)**, sous-dossiers compris) et lit un fichier une fois son écriture terminée. Les fichiers peuvent être filtrés par nom (**Correspondance de motifs (Pattern matching)** sur le numéro du nom de fichier, **Mot-clé (Keyword)**) ; les fichiers qui ne correspondent pas sont ignorés sans attente. Si un fichier est encore verrouillé après l'attente de la fin de l'écriture (environ 50 s), il n'est pas abandonné mais retenté lors des balayages suivants ; il n'est abandonné que s'il est toujours verrouillé 10 minutes après sa première détection.
- **Exécution automatique** : lorsque **Une fois la nouvelle image chargée, exécuter la séquence suivante (Once the new image is loaded, perform the following sequence)** est activé, exécute dans l'ordre les étapes cochées parmi **Auto contrast** → **Find center** → **Mask spots** → **Get profile** → **Execute macro**.

Cela permet par exemple de surveiller un dossier de sortie pendant une expérience et d'intégrer automatiquement chaque image dès son arrivée. Voir [Procédures](4-procedures.md) pour plus de détails.

![Procédure auto. (Auto procedure)](../assets/cap-en-auto/FormAutoProcedure.png)

## Tracer l'anneau (Draw Ring)

Trace sur l'image un anneau à une distance, un angle ou une valeur d donnés, en tenant compte de l'inclinaison de l'IP et de la distorsion des pixels. Cliquez sur l'un des champs **R (mm)** / **2θ (°)** / **d (Å)** pour choisir la valeur à modifier ; les autres sont calculées automatiquement à partir de la longueur d'onde et de la longueur de caméra.

![Tracer l'anneau (Draw Ring)](../assets/cap-en-auto/FormDrawRing.png)

## Dérouler l'image (Unroll)

Déplie l'image de diffraction, des coordonnées polaires centrées sur le spot direct vers des coordonnées cartésiennes (axe horizontal = angle de diffusion 2θ ; axe vertical = azimut). Ce déroulement se règle désormais non pas dans une fenêtre dédiée, mais avec le bouton **Dérouler l'image (Unroll image)** de la barre d'outils et l'onglet **Option d'image déroulée (Unrolled Image Option)** des propriétés. Le déroulement utilise le même algorithme de répartition d'intensité en sous-pixels que l'intégration en un profil 1D.

## Flou circonférentiel (Circumferential Blur)

Outil qui floute le motif des anneaux dans la direction circonférentielle (azimutale). Indiquez un angle de flou unique et appliquez-le.

![Flou circonférentiel (Circumferential Blur)](../assets/cap-en-auto/FormBlurAngle.png)

## Image séquentielle (Sequential Image)

Outil de traitement des images multi-trames (NeXus (`.nxs`), TIFF multipages et similaires ; séries temporelles, séries en température, balayages en énergie au synchrotron).

- Sélectionnez une trame dans la liste pour l'afficher, ou parcourez-les avec le curseur.
- Avec **Sélection multiple (Multi selection)**, sélectionnez plusieurs trames et calculez leur **Moyenne (Average)** ou leur **Sommation (Summation)**.
- Les trames intégrées par **Obtenir le profil (Get Profile)** se choisissent sous **Cible(s) de « Get Profile » (Target(s) of "Get Profile")** : **Toutes les images indépendamment des sélections actuelles (All images irrespective of current selections)** / **La ou les images sélectionnées (The selected image(s))** / **Uniquement l'image au premier plan (Only the topmost image)**.
- Si une trame contient une information d'énergie, la longueur d'onde est mise à jour lorsque cette trame est sélectionnée seule.

![Image séquentielle (Sequential Image)](../assets/cap-en-auto/FormSequentialImage.png)

## Enregistrer l'image (Save Image, format IPA)

Corrige l'inclinaison de l'IP φ, τ et la distorsion des pixels ξ, et enregistre l'image avec des pixels carrés à une résolution donnée. Des métadonnées telles que la longueur de caméra, la longueur d'onde et la position du centre sont également écrites, si bien que l'image peut être transmise à d'autres traitements d'image en conservant l'information géométrique.

![Enregistrer l'image (Save Image)](../assets/cap-en-auto/FormSaveImage.png)

## Trouver paramètre (géométriquement) (Find parameter (geometrically))

Outil qui optimise la longueur d'onde, la longueur de caméra, la taille de pixel, la distorsion de pixel et l'inclinaison (φ, τ) à partir des anneaux de diffraction d'un matériau de référence. Il utilise une image d'un échantillon de référence (Primaire (Primary)), ou deux images prises à des longueurs de caméra différentes (Primaire et Secondaire (Primary et Secondary)) ; vous sélectionnez les pics et optimisez avec **Affiner ! (Refine!)**. La convergence (centre des ellipses, résidus) peut être vérifiée sur les graphiques. Voir [Procédures](4-procedures.md) pour les étapes concrètes.

![Trouver paramètre (géométriquement) (Find parameter (geometrically))](../assets/cap-en-auto/FormFindParameter.png)

## Trouver paramètre (force brute) (Find parameter (brute force))

Outil qui détermine la longueur de caméra, la position du centre, l'inclinaison (φ, τ) et, en option, la longueur d'onde (désactivée par défaut) par une recherche exhaustive sur grille plutôt que par une méthode de gradient. Il utilise l'unique image d'un échantillon de référence chargée dans la fenêtre principale. Il est efficace lorsque l'optimisation géométrique converge difficilement, par exemple avec des anneaux incomplets ou des données bruitées. Choisissez le matériau de référence parmi Au / CeO₂ / LaB₆ / Al₂O₃, ou sélectionnez **Autre (Other)** et saisissez le cristal. Voir [Recherche de paramètres (force brute)](6-find-parameter.md) pour les étapes détaillées, et [Procédures](4-procedures.md) pour le déroulement général.

![Trouver paramètre (force brute) (Find parameter (brute force))](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Fonction qui automatise les opérations avec des scripts de type Python. Ouvrez l'éditeur de macros depuis le menu **Macro → Éditeur (Macro → Editor)** de la fenêtre principale.

- `for` / `if` / `while` / `def` / `class`, l'arithmétique et le module `math` sont disponibles.
- Des API telles que `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permettent d'appeler chaque opération.
- Activez **Afficher les exemples (Show samples)** pour voir les macros d'exemple en lecture seule (boucles de base, réglage de la géométrie, traitement par lots, division azimutale, masquage, envoi vers PDIndexer, etc.). Vous pouvez inspecter les variables avec l'exécution pas à pas.

Voir [Macro](5-macro/index.md) pour la référence complète des fonctions et les exemples, et [Procédures](4-procedures.md) pour les déroulements fondés sur les macros.

![Éditeur de macros](../assets/cap-en-auto/FormMacro.png)
