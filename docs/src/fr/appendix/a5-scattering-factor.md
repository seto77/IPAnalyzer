<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes) Fully retranslated for the rewritten en page (Beam interaction → Reflections tab). -->

# Annexe A5. Facteur de diffusion

Dans la version actuelle, les réflexions et les facteurs de structure d'un cristal sont affichés dans l'onglet **Réflexions (Reflections)** de la fenêtre **Interaction du faisceau (Beam Interaction)** (qui remplace l'ancienne fenêtre Scattering Factor). Cet onglet liste les plans cristallins autorisés (réflexions) du cristal sélectionné et calcule le **facteur de structure** et l'intensité de diffraction de chacun. Le type de rayonnement (rayons X, électrons ou neutrons) peut être changé, ce qui permet de comparer les facteurs de structure d'un même cristal entre techniques de diffraction.

Dans IPAnalyzer, ouvrez-la depuis la fenêtre du cristal qui définit le cristal de référence utilisé pour la calibration des paramètres (la fenêtre du cristal ouverte avec **Définir le cristal (Set crystal)** dans [Trouver paramètre (géométriquement) (Find parameter (geometrically))](../3-tools.md), ou le panneau du cristal de [6. Recherche de paramètres (force brute)](../6-find-parameter.md)) : appuyez sur le bouton **Interaction du faisceau (Beam interaction)**, ou choisissez **Interaction du faisceau (Beam Interaction)** dans le menu contextuel (clic droit) du panneau du cristal.

![Fenêtre Interaction du faisceau (onglet Réflexions)](../../assets/references/beam-interaction-reflections-en.png)

La bande du haut sélectionne le faisceau incident, et l'onglet **Réflexions (Reflections)** situé en dessous affiche la liste des réflexions (partie supérieure) et un diagramme en bâtons des mêmes réflexions (partie inférieure). La liste est recalculée immédiatement chaque fois qu'une condition change. Les autres onglets (**Atténuations & transport (Attenuations & transport)**, **Facteurs de diffusion (Scattering factors)**, **Fluorescence**) ne sont pas nécessaires pour IPAnalyzer ; pour ceux-ci, voir [Interaction du faisceau dans le manuel de ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/).

---

## Raccourcis clavier et souris

Cette fenêtre n'a pas de combinaison de touches ou de souris particulière. <kbd>F1</kbd> ouvre cette page du manuel, et **Copier (Copy)** exporte le tableau des réflexions sous forme de texte collable dans un tableur.

---

## Faisceau et longueur d'onde

- **X-ray / Electron / Neutron** : les facteurs de diffusion atomique diffèrent selon le type de faisceau incident ; on les change donc ici.
- Pour **X-ray**, le choix de l'**Element** (matériau de l'anode) et de la raie caractéristique (Kα, etc.) règle automatiquement la longueur d'onde de ce rayonnement X caractéristique.
- **Energy** (keV) et **Wavelength** (Å) sont liées : régler l'une met l'autre à jour, et elles servent à calculer le 2θ de chaque réflexion.
- **Unit** (**Å** / **nm**) change l'unité de longueur utilisée pour les distances interréticulaires et les grandeurs similaires.

---

## Options de l'onglet Réflexions

- **Intensités de diffraction des poudres (optique de Bragg-Brentano) (Powder diffraction intensities (Bragg-Brentano optics))** : calcule l'intensité relative comme une intensité de diffraction de poudre (Bragg–Brentano), $I \propto m\,\lvert F\rvert^2 / V^2 \times L$, où $m$ est la multiplicité, $V$ le volume de la maille, et $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (facteur de Lorentz-polarisation) pour les rayons X ou $L = 1/(\sin 2\theta\,\sin\theta)$ (facteur de Lorentz seul) pour les électrons et les neutrons. Les réflexions que le faisceau ne peut pas atteindre (d < λ/2) reçoivent une intensité nulle. Désactivée, l'intensité du facteur de structure $\lvert F\rvert^2$ est affichée. L'activer active aussi **Masquer les plans équivalents (Hide equivalent planes)** et **Masquer les plans interdits (Hide prohibited planes)** et les grise.
- **Masquer les plans équivalents (Hide equivalent planes)** (activé par défaut) : regroupe en une seule entrée les plans cristallographiquement équivalents. La colonne **Multi.** n'est affichée que lorsque cette option est activée.
- **Masquer les plans interdits (Hide prohibited planes)** (activé par défaut) : exclut les plans systématiquement éteints d'après les règles d'extinction. Lorsqu'elle est désactivée, une colonne **Condition** indique la ou les conditions de réflexion qui interdisent chaque plan éteint.
- **d-spacing cutoff >** (1 Å par défaut) : exclut les réflexions dont la distance interréticulaire est inférieure à cette valeur (l'unité de longueur suit **Unit**).

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
| **Condition** | condition(s) d'extinction violée(s) par le plan (affichée uniquement lorsque **Masquer les plans interdits (Hide prohibited planes)** est désactivé) |

Sous le tableau, les mêmes réflexions sont tracées sous forme de diagramme en bâtons, les pics les plus intenses étant étiquetés par leurs *hkl*. Le sélecteur choisit l'axe horizontal parmi **2θ**, **d** et **Q** ($= 4\pi\sin\theta/\lambda$), **Log I** fait passer l'axe des intensités de linéaire à logarithmique, et les cases **Range** règlent la plage tracée.

---

## Copier dans le presse-papiers

**Copier (Copy)** copie la liste des réflexions dans le presse-papiers sous forme de texte pouvant être collé dans un tableur tel qu'Excel.

---

## Voir aussi

- [Page d'accueil de l'annexe](index.md)
- [4. Procédures](../4-procedures.md) — définition du cristal de référence dont les facteurs de structure sont calculés.
- [6. Recherche de paramètres (force brute)](../6-find-parameter.md)
- [Interaction du faisceau dans le manuel de ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/) — les quatre onglets de la même fenêtre.
