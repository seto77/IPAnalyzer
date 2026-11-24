<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# Annexe A5. Facteur de diffusion

**Scattering Factor** liste les plans cristallins autorisés (réflexions) du cristal sélectionné et calcule le **facteur de structure** et l'intensité de diffraction de chacun. Le type de rayonnement (rayons X, électrons ou neutrons) peut être changé, ce qui permet de comparer les facteurs de structure d'un même cristal entre techniques de diffraction.

Dans la version actuelle, cette liste se trouve dans l'onglet **Réflexions (Reflections)** de **Interaction du faisceau (Beam interaction)** dans la fenêtre du cristal (les facteurs de diffusion atomique eux-mêmes se trouvent dans l'onglet **Facteurs de diffusion (Scattering factors)** de la même fenêtre). Les écrans et éléments décrits ci-dessous sont ceux de l'ancienne fenêtre Scattering Factor.

Dans IPAnalyzer, cette sous-fenêtre s'ouvre depuis la **fenêtre Crystal (Crystal window)** (le CrystalControl utilisé dans [4. Procédures](../4-procedures.md) pour la calibration géométrique et dans [6. Recherche de paramètres (force brute)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Les conditions de calcul se trouvent en haut de la fenêtre et la liste des réflexions en bas. La liste est recalculée immédiatement chaque fois qu'une condition change.

---

## Raccourcis clavier et souris

Cette fenêtre n'a pas de combinaison de touches ou de souris particulière. <kbd>F1</kbd> ouvre cette page du manuel, et **Copy to clipboard** exporte l'ensemble du tableau des réflexions sous forme de texte collable dans un tableur.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : les facteurs de diffusion atomique diffèrent selon le type de faisceau incident ; on les change donc ici.
- Pour **X-ray**, le choix de l'**Element** (matériau de l'anode) et de la raie caractéristique (Kα, etc.) règle automatiquement la longueur d'onde de ce rayonnement X caractéristique.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** et **Wavelength (Å)** sont liées l'une à l'autre.
- Cette énergie ou cette longueur d'onde sert à calculer 2θ (l'angle de diffraction). Pour les rayons X, elle peut aussi être réglée par le choix de l'élément et du type de raie.

---

## Options d'affichage et de calcul

- **Intensités de diffraction des poudres (optique de Bragg-Brentano) (Powder diffraction intensities (Bragg-Brentano optics))** : calcule l'intensité relative comme une intensité de diffraction de poudre (Bragg–Brentano), en incluant la multiplicité et le facteur de Lorentz-polarisation. Désactivée, elle affiche l'intensité du facteur de structure.
- **Masquer les plans équivalents (Hide equivalent planes)** : regroupe en une seule entrée les plans cristallographiquement équivalents.
- **Masquer les plans interdits (Hide prohibited planes)** : exclut les plans dont l'intensité est nulle d'après les règles d'extinction.
- **Unit (Å / nm)** : change l'unité de longueur des distances interréticulaires, etc.
- **d-Spacing Cutoff** : exclut les réflexions dont la distance interréticulaire est inférieure à cette valeur.

---

## Liste des réflexions

Chaque ligne correspond à une réflexion (ou à un groupe de plans équivalents par symétrie).

| Colonne | Signification |
|------|------|
| **h, k, l** | indices de Miller |
| **Multi.** | multiplicité (nombre de plans équivalents par symétrie) |
| **d (Å)** | distance interréticulaire |
| **q (2π/d)** | norme du vecteur de diffusion |
| **2θ (°)** | angle de diffraction pour la longueur d'onde sélectionnée |
| **F_real** | partie réelle du facteur de structure |
| **F_inv** | partie imaginaire du facteur de structure |
| **\|F\|** | amplitude du facteur de structure ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensité du facteur de structure ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensité relative, la réflexion la plus forte valant 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copie la liste dans le presse-papiers sous forme de texte pouvant être collé dans un tableur tel qu'Excel.

---

## Voir aussi

- [Page d'accueil de l'annexe](index.md)
- [4. Procédures](../4-procedures.md) — définition du cristal de référence dont les facteurs de structure sont calculés.
- [6. Recherche de paramètres (force brute)](../6-find-parameter.md)
