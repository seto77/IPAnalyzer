<!-- 261124Cl: Retranslated from en/6-find-parameter.md (UI labels follow the localized GUI). -->

# Recherche de paramètres (force brute)

Le mode force brute fait varier chaque paramètre de façon exhaustive (recherche sur grille) afin de trouver les valeurs qui satisfont au mieux les critères suivants :

- de faibles écarts (en 2θ) entre les positions de pics calculées et celles obtenues par ajustement, et
- des pics hauts (fins).

Il est efficace pour les anneaux incomplets ou les données bruitées, avec lesquels l'optimisation géométrique converge difficilement. Voir [Outils](3-tools.md) pour une présentation de l'outil et [Procédures](4-procedures.md) pour le déroulement de base.

## Étapes

1. Chargez les données d'image et les paramètres, puis cliquez sur **Trouver paramètre (force brute) (Find parameter (brute force))**.

    ![Lancement de Trouver paramètre (force brute)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Fenêtre de calibration par force brute](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Sélectionnez le **matériau de référence**. S'il ne figure pas dans la liste, choisissez **Autre (Other)** et saisissez-le manuellement.
3. Affichez le profil avec **Obtenir le profil (Get Profile)**.
4. Double-cliquez sur toute raie de pic que vous ne souhaitez pas utiliser pour l'optimisation afin de l'exclure.
5. Réglez les options et appuyez sur **Optimiser (Optimize)** pour lancer l'optimisation.

## Options

![Réglage des options](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Plage d'ajustement

Indique la plage angulaire ajustée pour chaque pic.

### Nombre de répétitions

Indique le nombre de cycles d'optimisation.

### Options par paramètre

L'optimisation porte sur les éléments cochés. Chaque paramètre parcourt la plage indiquée (**Plage de recherche (Search range)**) avec le pas indiqué (**Pas initial (Initial step)**).

Par exemple, si la longueur de caméra vaut initialement 100 mm, avec un Pas initial (Initial step) de 0,05 mm et une Plage de recherche (Search range) de 4, alors 9 (= Plage de recherche × 2 + 1) longueurs de caméra sont essayées : 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Lorsque les nombres d'essais des paramètres sont N1, N2, N3, …, le nombre total d'essais par cycle est N1 × N2 × N3 × …. Dans l'exemple ci-dessus, avec quatre paramètres dont les plages de recherche valent 4, 4, 3 et 6, on obtient (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 essais. Autrement dit, 7371 jeux de paramètres sont essayés, et la combinaison donnant la plus petite valeur d'évaluation R (voir ci-dessous) est retenue.

!!! warning
    Augmenter la **Plage de recherche (Search range)** accroît fortement le nombre d'essais et allonge chaque cycle. Utilisez-la avec prudence.

## Écran d'état

![Écran d'état](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Pendant la calibration, un écran d'état comme celui ci-dessus est affiché.

- **Cycle** : le numéro du cycle en cours. À la fin d'un cycle, le meilleur jeu de paramètres trouvé devient le point de départ du cycle suivant. Si les meilleurs paramètres sont identiques à ceux du début du cycle, le pas est réduit à la valeur immédiatement inférieure de la série prédéfinie (1, 1.3, 1.8, 2.4, 3.2, 4.2, 5.6, 7.5 × 10ⁿ) pour le cycle suivant (par ex. 0,05 mm → 0,042 mm).
- **Current best values** : les meilleurs paramètres à cet instant.
- **Current steps** : le pas de chaque paramètre à cet instant.
- **No1, No2, …** : les 4 meilleures valeurs d'évaluation depuis le début de la recherche (affichées dès qu'au moins cinq valeurs différentes ont été recueillies). Elles diminuent rapidement au début puis convergent à l'approche de l'optimum.

## Valeur d'évaluation R

La valeur d'évaluation R est calculée comme suit.

![Formule de la valeur d'évaluation R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Ici, \(2\theta_{\mathrm{calc},i}\) est la position du pic \(i\) calculée à partir des paramètres actuels, \(2\theta_{\mathrm{fit},i}\) la position obtenue par ajustement du profil (toutes deux en degrés), *H* la hauteur du pic après soustraction du fond, et *W* le poids (**Weight**, 100 par défaut). Pour un détecteur plan, la formule est :

$$
R = 1000\left[\sum_i \left(2\theta_{\mathrm{calc},i} - 2\theta_{\mathrm{fit},i}\right)^2 + \frac{W}{\sum_i H_i}\right]
$$

R diminue à mesure que les écarts de position diminuent et que les pics deviennent plus hauts (plus fins). La largeur à mi-hauteur (FWHM) elle-même n'est pas utilisée dans l'évaluation.
