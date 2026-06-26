<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

Le mode force brute fait varier chaque paramètre de manière exhaustive (une recherche sur grille) afin de trouver les valeurs qui satisfont au mieux :

- des pics nets (c.-à-d. une faible FWHM), et
- un faible écart des valeurs d.

Il est efficace pour les anneaux incomplets ou les données bruitées, où l'optimisation géométrique peine à converger. Voir [Outils](3-tools.md) pour un aperçu de l'outil et [Procédures](4-procedures.md) pour le déroulement de base.

## Étapes

1. Chargez les données d'image et les paramètres, puis cliquez sur **Find Parameter (brute force)**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Sélectionnez le **standard material**. S'il n'est pas dans la liste, choisissez **Others** et saisissez-le manuellement.
3. Affichez le profil avec **Get profile**.
4. Double-cliquez sur toute ligne de pic que vous ne souhaitez pas utiliser pour l'optimisation afin de l'exclure.
5. Réglez les options et appuyez sur **Optimize** pour lancer l'optimisation.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Spécifie la plage angulaire ajustée pour chaque pic.

### Number of repetitions

Spécifie le nombre de cycles d'optimisation.

### Per-parameter options

L'optimisation est effectuée sur les éléments cochés. Chaque paramètre se déplace sur la plage spécifiée (**Search range**) selon le pas spécifié (**Initial step**).

Par exemple, si la longueur de caméra commence à 100 mm avec un Initial step de 0,05 mm et un Search range de 4, alors 9 (= Search range × 2 + 1) longueurs de caméra sont essayées : 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Lorsque les nombres d'essais des paramètres sont N1, N2, N3, …, le nombre total d'essais par cycle est N1 × N2 × N3 × …. Dans l'exemple ci-dessus, avec quatre paramètres ayant des Search range de 4, 4, 3 et 6, cela donne (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 essais. Autrement dit, 7371 jeux de paramètres sont essayés, et la combinaison présentant les pics les plus nets et le plus faible écart des valeurs d est choisie.

!!! warning
    Augmenter **Search range** accroît fortement le nombre d'essais et allonge chaque cycle. À utiliser avec précaution.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Pendant la calibration, un écran d'état comme celui ci-dessus est affiché.

- **Cycle** : le numéro du cycle en cours. Lorsqu'un cycle se termine, le meilleur jeu de paramètres qui y a été trouvé devient le point de départ du cycle suivant. Si les meilleurs paramètres sont identiques à ceux du cycle précédent, le pas est multiplié par 0,8 pour le cycle suivant.
- **Current best values** : les meilleurs paramètres à cet instant.
- **Current steps** : le pas de chaque paramètre à cet instant.
- **No1, No2, …** : les 5 meilleures valeurs d'évaluation du cycle. Elles chutent rapidement au début et convergent à mesure que l'on approche de l'optimum.

## Evaluation value R

La valeur d'évaluation R est calculée comme suit.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Ici *H* est la hauteur de pic après soustraction du fond.
