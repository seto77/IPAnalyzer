<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes; fully retranslated for the Beam Interaction → Reflections tab) -->

# Anhang A5. Streufaktor

In der aktuellen Version werden die Reflexe und Strukturfaktoren eines Kristalls auf der Registerkarte **Reflexe (Reflections)** des Fensters **Strahlwechselwirkung (Beam Interaction)** angezeigt (es ersetzt das frühere Fenster Scattering Factor). Die Registerkarte listet die erlaubten Kristallebenen (Reflexe) des ausgewählten Kristalls und berechnet für jede den **Strukturfaktor** und die Beugungsintensität. Die Strahlungsart (Röntgen, Elektronen oder Neutronen) lässt sich umschalten, sodass die Strukturfaktoren desselben Kristalls zwischen verschiedenen Beugungsverfahren verglichen werden können.

In IPAnalyzer öffnen Sie es aus dem Kristallfenster, das den für die Parameterkalibrierung verwendeten Standardkristall definiert (dem Kristallfenster, das mit **Kristall festlegen (Set crystal)** in [Parameter finden (geometrisch)](../3-tools.md) geöffnet wird, oder dem Kristallbereich von [6. Parameter finden (Brute Force)](../6-find-parameter.md)): Klicken Sie auf die Schaltfläche **Strahlwechselwirkung (Beam interaction)** oder wählen Sie **Strahlwechselwirkung (Beam Interaction)** im Kontextmenü des Kristallbereichs.

![Fenster Strahlwechselwirkung (Beam Interaction), Registerkarte Reflexe (Reflections)](../../assets/references/beam-interaction-reflections-en.png)

Im Band oben wird der einfallende Strahl ausgewählt; die Registerkarte **Reflexe (Reflections)** darunter zeigt die Reflexliste (oberer Teil) und ein Strichdiagramm derselben Reflexe (unterer Teil). Die Liste wird sofort neu berechnet, sobald sich eine Bedingung ändert. Die übrigen Registerkarten (**Schwächung & Transport (Attenuations & transport)**, **Streufaktoren (Scattering factors)**, **Fluoreszenz (Fluorescence)**) werden für IPAnalyzer nicht benötigt; siehe dazu [Strahlwechselwirkung im ReciPro-Handbuch](https://seto77.github.io/ReciPro/3-beam-interaction/).

---

## Tastatur- und Maus-Kurzbefehle

Dieses Fenster hat keine besonderen Tasten- oder Mauskombinationen. <kbd>F1</kbd> öffnet diese Handbuchseite, und **Kopieren (Copy)** exportiert die Reflextabelle als Text, der sich in eine Tabellenkalkulation einfügen lässt.

---

## Strahl und Wellenlänge

- **X-ray / Electron / Neutron**: Die Atomformfaktoren unterscheiden sich je nach Art des einfallenden Strahls und werden daher hier umgeschaltet.
- Bei **X-ray** wird durch Auswahl des **Element** (Anodenmaterial) und der charakteristischen Linie (Kα usw.) die Wellenlänge dieser charakteristischen Röntgenstrahlung automatisch eingestellt.
- **Energy** (keV) und **Wavelength** (Å) sind gekoppelt: Wird einer der beiden Werte eingestellt, aktualisiert sich der andere, und beide dienen zur Berechnung von 2θ jedes Reflexes.
- **Unit** (**Å** / **nm**) schaltet die Längeneinheit für d-Werte und ähnliche Größen um.

---

## Optionen der Registerkarte Reflexe

- **Pulverbeugungsintensitäten (Bragg-Brentano-Optik) (Powder diffraction intensities (Bragg-Brentano optics))**: berechnet die relative Intensität als Pulverbeugungsintensität (Bragg–Brentano), $I \propto m\,\lvert F\rvert^2 / V^2 \times L$, wobei $m$ die Zähligkeit, $V$ das Zellvolumen und $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (Lorentz-Polarisationsfaktor) für Röntgenstrahlung bzw. $L = 1/(\sin 2\theta\,\sin\theta)$ (nur Lorentzfaktor) für Elektronen und Neutronen ist. Reflexe, die der Strahl nicht erreichen kann (d < λ/2), erhalten die Intensität 0. Ist die Option aus, wird die Strukturfaktorintensität $\lvert F\rvert^2$ angezeigt. Beim Einschalten werden auch **Äquivalente Ebenen ausblenden (Hide equivalent planes)** und **Verbotene Ebenen ausblenden (Hide prohibited planes)** eingeschaltet und ausgegraut.
- **Äquivalente Ebenen ausblenden (Hide equivalent planes)** (standardmäßig ein): fasst kristallographisch äquivalente Ebenen zu einem einzigen Eintrag zusammen. Die Spalte **Multi.** wird nur angezeigt, solange diese Option eingeschaltet ist.
- **Verbotene Ebenen ausblenden (Hide prohibited planes)** (standardmäßig ein): schließt Ebenen aus, die nach den Auslöschungsregeln systematisch ausgelöscht sind. Ist die Option aus, zeigt eine Spalte **Condition** die Reflexionsbedingung(en), die jede ausgelöschte Ebene verbieten.
- **d-spacing cutoff >** (Standard 1 Å): schließt Reflexe mit einem d-Wert kleiner als dieser Wert aus (die Längeneinheit folgt **Unit**).

---

## Reflexliste

Jede Zeile entspricht einem Reflex (bzw. einer Gruppe symmetrieäquivalenter Ebenen).

| Spalte | Bedeutung |
|------|------|
| **h, k, l** | Millersche Indizes |
| **Multi.** | Zähligkeit (Anzahl symmetrieäquivalenter Ebenen) |
| **d (Å)** | Netzebenenabstand |
| **q (2π/d)** | Betrag des Streuvektors |
| **2θ (°)** | Beugungswinkel für die gewählte Wellenlänge |
| **F_real** | Realteil des Strukturfaktors |
| **F_inv** | Imaginärteil des Strukturfaktors |
| **\|F\|** | Strukturfaktor-Amplitude ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | Strukturfaktor-Intensität ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | relative Intensität, wobei der stärkste Reflex auf 100 gesetzt ist |
| **Condition** | von der Ebene verletzte Auslöschungsbedingung(en) (nur angezeigt, wenn **Verbotene Ebenen ausblenden (Hide prohibited planes)** aus ist) |

Unterhalb der Tabelle werden dieselben Reflexe als Strichmuster gezeichnet; die stärksten Peaks sind mit ihren *hkl* beschriftet. Die Auswahl legt die horizontale Achse aus **2θ**, **d** und **Q** ($= 4\pi\sin\theta/\lambda$) fest, **Log I** schaltet die Intensitätsachse zwischen linear und logarithmisch um, und die Felder **Range** legen den dargestellten Bereich fest.

---

## In die Zwischenablage kopieren

**Kopieren (Copy)** kopiert die Reflexliste als Text in die Zwischenablage, der sich in eine Tabellenkalkulation wie Excel einfügen lässt.

---

## Siehe auch

- [Startseite des Anhangs](index.md)
- [4. Arbeitsabläufe](../4-procedures.md) — Definition des Standardkristalls, dessen Strukturfaktoren berechnet werden.
- [6. Parameter finden (Brute Force)](../6-find-parameter.md)
- [Strahlwechselwirkung im ReciPro-Handbuch](https://seto77.github.io/ReciPro/3-beam-interaction/) — alle vier Registerkarten desselben Fensters.
