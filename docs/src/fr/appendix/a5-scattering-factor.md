<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Annexe A5. Scattering Factor

**Scattering Factor** liste les plans cristallins autorisés (réflexions) du cristal sélectionné et calcule le **facteur de structure** ainsi que l'intensité de diffraction de chacun. Le type de rayonnement (rayons X, électrons ou neutrons) peut être commuté, de sorte que les facteurs de structure d'un même cristal peuvent être comparés entre différentes techniques de diffraction.

Dans IPAnalyzer, cette sous-fenêtre s'ouvre depuis la **Crystal window** (le CrystalControl utilisé dans [4. Practical procedures](../4-procedures.md) pour la calibration géométrique et dans [6. Find Parameter (brute force)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Les conditions de calcul se trouvent en haut de la fenêtre et la liste des réflexions en bas. La liste est recalculée immédiatement dès qu'une condition change.

---

## Raccourcis clavier et souris

Cette fenêtre n'a pas de combinaison de touches ou de souris particulière. <kbd>F1</kbd> ouvre cette page de manuel, et **Copy to clipboard** exporte la totalité du tableau des réflexions sous forme de texte collable dans un tableur.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : les facteurs de diffusion atomique diffèrent selon le type de faisceau incident, ils se commutent donc ici.
- Pour les **X-ray**, le choix de l'**Element** (matériau de l'anode) et de la raie caractéristique (Kα, etc.) règle automatiquement la longueur d'onde de ce rayonnement X caractéristique.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** et **Wavelength (Å)** sont liés l'un à l'autre.
- Cette énergie ou cette longueur d'onde sert à calculer 2θ (l'angle de diffraction). Pour les rayons X, elle peut aussi être définie via la sélection de l'élément et du type de raie.

---

## Options d'affichage et de calcul

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : calcule l'intensité relative en tant qu'intensité de diffraction de poudre (Bragg–Brentano), en incluant la multiplicité et le facteur de Lorentz–polarisation. Lorsque cette option est désactivée, l'intensité du facteur de structure est affichée.
- **Hide equivalent planes** : regroupe les plans cristallographiquement équivalents en une seule entrée.
- **Hide prohibited planes** : exclut les plans dont l'intensité est nulle selon les règles d'extinction.
- **Unit (Å / nm)** : commute l'unité de longueur pour la distance d-spacing, etc.
- **d-Spacing Cutoff** : exclut les réflexions dont la distance d-spacing est inférieure à cette valeur.

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
| **Rel. Int. (%)** | intensité relative, la réflexion la plus forte étant fixée à 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copie la liste dans le presse-papiers sous forme de texte pouvant être collé dans un tableur tel qu'Excel.

---

## Voir aussi

- [Haut de l'annexe](index.md)
- [4. Practical procedures](../4-procedures.md) — définition du cristal de référence dont les facteurs de structure sont calculés.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
