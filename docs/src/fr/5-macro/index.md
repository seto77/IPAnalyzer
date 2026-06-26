<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer fournit une fonctionnalité **macro** qui automatise des séquences d'opérations à l'aide de scripts de type Python. Elle est utile pour les tâches répétitives telles que l'unidimensionnalisation par lots de nombreux fichiers, la conversion de format et l'analyse par division azimutale.

## Ouvrir l'éditeur

Ouvrez l'éditeur de macros depuis le menu **Macro** → **Editor** de la fenêtre principale. Vous pouvez y modifier le code et l'exécuter, y compris en exécution pas à pas.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Langage

- Les instructions de contrôle telles que `for` / `if` / `while` / `def` / `class`, ainsi que les opérations arithmétiques, sont disponibles.
- Le module `math` est pré-importé, vous pouvez donc utiliser directement `math.pi` ou `math.sin(...)` sans instruction `import`.
- `print()` n'est pas disponible. Pour examiner des valeurs, utilisez l'**exécution pas à pas** (Step by step) et observez l'évolution des variables dans le panneau de débogage.
- Chaque opération d'IPAnalyzer est appelée depuis un espace de noms sous l'objet racine `IPA` (par exemple `IPA.File`).

## Espaces de noms IPA

| Espace de noms | Rôle |
|------|------|
| `IPA.File` | Lire/écrire des fichiers d'image, de paramètres et de masque ; boîtes de dialogue de sélection de fichiers |
| `IPA.Wave` | Définir la source incidente et la longueur d'onde |
| `IPA.Detector` | Définir la géométrie du détecteur : centre, longueur de caméra, taille de pixel, inclinaison |
| `IPA.Image` | Contrôler l'échelle d'affichage, le contraste et la zone de visualisation |
| `IPA.Mask` | Masquer des taches et des régions |
| `IPA.Profile` | Lancer l'unidimensionnalisation (Get Profile) et configurer l'enregistrement/l'envoi |
| `IPA.IntegralProperty` | Définir la plage, le pas et l'unité de l'intégration concentrique / radiale |
| `IPA.Sequential` | Sélectionner / moyenner / cibler les trames d'une image multi-trames |
| `IPA.PDI` | Appeler des macros sur PDIndexer (intégration via le presse-papiers) |

Consultez [Fonctions intégrées](1-built-in-functions.md) pour la liste des membres, et [Exemples](2-examples.md) pour des scripts concrets.

!!! tip "L'aide intégrée à l'éditeur est la référence faisant autorité"
    La description de chaque fonction/propriété est affichée dans l'aide de l'éditeur de macros et constitue la source de vérité à jour, suivant les versions. Si cette page diffère de l'aide intégrée à l'éditeur, faites confiance à cette dernière.

## Macros d'exemple

Lorsque la liste des macros enregistrées de l'éditeur est vide, des macros d'exemple (boucles de base, fonctions mathématiques, configuration de la géométrie, traitement par lots, division azimutale, masquage, envoi vers PDIndexer, etc.) sont insérées automatiquement. Elles constituent un point de départ facile à adapter.

## Utilisation avec Auto Procedure

Les macros que vous écrivez peuvent être enregistrées par leur nom et également appelées depuis la liste « execute after loading » d'[Auto Procedure](../3-tools.md), de sorte qu'une macro soit appliquée automatiquement à chaque image arrivant au cours d'une expérience.
