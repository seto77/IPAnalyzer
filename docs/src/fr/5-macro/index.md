<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). -->

# Macro

IPAnalyzer propose une fonction **macro** qui automatise des séquences d'opérations avec des scripts de type Python. Elle est utile pour les tâches répétitives telles que la réduction en une dimension par lots de nombreux fichiers, la conversion de formats et l'analyse par division azimutale.

## Ouvrir l'éditeur

Ouvrez l'éditeur de macros depuis le menu **Macro** → **Éditeur (Editor)** de la fenêtre principale. Vous pouvez y modifier le code et l'exécuter, y compris pas à pas.

![Éditeur de macros](../../assets/cap-en-auto/FormMacro.png)

## Langage

- Les instructions de contrôle telles que `for` / `if` / `while` / `def` / `class`, ainsi que l'arithmétique, sont disponibles.
- Le module `math` est pré-importé : vous pouvez utiliser `math.pi` ou `math.sin(...)` directement, sans instruction `import`.
- `print()` n'est pas disponible. Pour inspecter des valeurs, utilisez l'**exécution pas à pas** (Step by step) et observez l'évolution des variables dans le panneau de débogage.
- Chaque opération d'IPAnalyzer est appelée depuis un espace de noms placé sous l'objet racine `IPA` (par ex. `IPA.File`).

## Espaces de noms IPA

| Espace de noms | Rôle |
|------|------|
| `IPA.File` | Lire/écrire les fichiers d'image, de paramètres et de masque ; boîtes de dialogue de sélection de fichiers |
| `IPA.Wave` | Régler la source incidente et la longueur d'onde |
| `IPA.Detector` | Régler la géométrie du détecteur : centre, longueur de caméra, taille de pixel, inclinaison |
| `IPA.Image` | Contrôler l'échelle d'affichage, le contraste et la zone affichée |
| `IPA.Mask` | Masquer des taches et des régions |
| `IPA.Profile` | Lancer la réduction en une dimension (Obtenir le profil (Get Profile)) et configurer l'enregistrement/l'envoi |
| `IPA.IntegralProperty` | Régler la plage, le pas et l'unité de l'intégration concentrique / radiale |
| `IPA.Sequential` | Sélectionner / moyenner / cibler les trames d'une image multi-trames |
| `IPA.PDI` | Appeler des macros dans PDIndexer (intégration par le presse-papiers) |

Voir [Fonctions intégrées](1-built-in-functions.md) pour la liste des membres, et [Exemples](2-examples.md) pour des scripts concrets.

!!! tip "L'aide intégrée à l'éditeur fait foi"
    La description de chaque fonction/propriété est affichée dans l'aide de l'éditeur de macros ; c'est la référence à jour, qui suit les versions. Si cette page contredit l'aide intégrée à l'éditeur, fiez-vous à cette dernière.

## Macros d'exemple

Activez **Afficher les exemples (Show samples)** dans l'éditeur pour lister les macros d'exemple en lecture seule (boucles de base, fonctions mathématiques, réglage de la géométrie, traitement par lots, division azimutale, masquage, envoi vers PDIndexer, etc.) ; désactivez-la pour revenir à vos propres macros enregistrées. Elles constituent un point de départ facile à adapter.

## Utilisation avec la procédure automatique

Les macros que vous écrivez peuvent être enregistrées sous un nom et aussi appelées depuis la liste « exécuter après le chargement » de la [Procédure auto. (Auto procedure)](../3-tools.md), de sorte qu'une macro soit appliquée automatiquement à chaque image arrivant pendant une expérience.
