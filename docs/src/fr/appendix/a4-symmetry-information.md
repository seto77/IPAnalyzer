<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Annexe A4. Informations de symétrie

**Symmetry Information** affiche des informations détaillées sur la symétrie du groupe d'espace du cristal sélectionné, et rend en outre des diagrammes schématiques des éléments de symétrie et des positions générales dans le style des *International Tables for Crystallography* Vol. A.

Dans IPAnalyzer, cette sous-fenêtre s'ouvre depuis la **Crystal window** (le CrystalControl utilisé dans [4. Procédures](../4-procedures.md) pour la calibration géométrique et dans [6. Recherche de paramètres (force brute)](../6-find-parameter.md)).

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

La fenêtre se divise en une zone d'identité du groupe d'espace (en haut à gauche), une zone de calcul/tableau avec onglets (en haut à droite), et deux diagrammes schématiques (en bas).

---

## Raccourcis clavier et souris

Cette fenêtre n'a pas de combinaisons de touches ou de souris particulières. <kbd>F1</kbd> ouvre cette page de manuel, et les deux boutons **Copy** placent le diagramme des éléments de symétrie et le diagramme des positions générales dans le presse-papiers (sous forme de bitmap, ou de EMF vectoriel lorsque **EMF** est coché).

---

## Identité du groupe d'espace

Le panneau en haut à gauche liste, pour le groupe d'espace courant :

- **Number** (1–230) et l'indice de setting
- **Crystal System**
- **Point Group** : symboles Hermann–Mauguin (HM) et Schoenflies (SF)
- **Space Group** : symbole HM court, symbole HM complet, symbole SF, et **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Saisissez deux plans cristallins \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) ou deux indices de direction \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) pour obtenir :

- le d-spacing de chaque plan / la longueur de chaque axe,
- l'angle entre les deux plans (ou les deux axes),
- **l'indice de direction normal aux deux plans** et **l'indice de plan normal aux deux axes**.

Ces calculs respectent la métrique de la maille élémentaire courante.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Liste chaque position de Wyckoff avec sa multiplicité, sa lettre de Wyckoff, sa symétrie de site, et indique s'il s'agit d'une position générale ou spéciale. Pour les réseaux centrés, les vecteurs de translation du réseau sont indiqués dans la ligne d'en-tête.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Les conditions de réflexion provenant du centrage du réseau et des opérateurs de symétrie de glissement/hélicoïdaux.

---

## Diagrammes des éléments de symétrie et des positions générales

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

Les deux panneaux du bas reproduisent les diagrammes schématiques de symétrie du groupe d'espace dans la notation des *International Tables for Crystallography* Vol. A.

- **Symmetry elements (gauche)** : les axes de rotation/hélicoïdaux, les plans miroir/de glissement, et les centres d'inversion/points de rotoinversion sont dessinés avec les symboles graphiques conventionnels.
  - Pour le réseau \(F\) du système cubique, seul un huitième de la maille élémentaire (le quadrant supérieur gauche uniquement) est affiché.
- **General positions (droite)** : les positions générales équivalentes sont représentées par des cercles (une virgule indique une image miroir), annotées avec leurs coordonnées fractionnaires.
  - Pour le système cubique uniquement, des lignes auxiliaires relient les trois cercles liés par un axe de rotation d'ordre trois.

Contrôles sous les diagrammes :

- **Direction** (`a` / `b` / `c`) : choisir l'axe cristallin le long duquel projeter.
- **Copy** chaque diagramme dans le presse-papiers sous forme d'image vectorielle (**EMF**) ou matricielle (**BMP**) ; le EMF peut être dégroupé et édité dans PowerPoint.

---

## Voir aussi

- [Haut de l'annexe](index.md)
- [4. Procédures](../4-procedures.md) — calibration des paramètres géométriques à l'aide d'un cristal de référence.
- [6. Recherche de paramètres (force brute)](../6-find-parameter.md)
