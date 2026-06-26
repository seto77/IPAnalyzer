<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Anhang A5. Streufaktor

**Scattering Factor** listet die erlaubten Kristallebenen (Reflexe) des ausgewählten Kristalls auf und berechnet für jeden den **Strukturfaktor** sowie die Beugungsintensität. Die Strahlungsart (Röntgen, Elektronen oder Neutronen) lässt sich umschalten, sodass sich die Strukturfaktoren desselben Kristalls über verschiedene Beugungsverfahren hinweg vergleichen lassen.

In IPAnalyzer wird dieses Unterfenster aus dem **Crystal window** (dem CrystalControl, das in [4. Praktische Arbeitsabläufe](../4-procedures.md) zur geometrischen Kalibrierung und in [6. Parameter finden (Brute-Force)](../6-find-parameter.md) verwendet wird) geöffnet.

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Die Berechnungsbedingungen befinden sich oben im Fenster und die Reflexliste unten. Die Liste wird sofort neu berechnet, sobald sich eine Bedingung ändert.

---

## Tastatur- und Maus-Kurzbefehle

Dieses Fenster besitzt keine besonderen Tasten- oder Mauskombinationen. <kbd>F1</kbd> öffnet diese Handbuchseite, und **Copy to clipboard** exportiert die gesamte Reflextabelle als in Tabellenkalkulationen einfügbaren Text.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : Die atomaren Streufaktoren unterscheiden sich je nach Art des einfallenden Strahls und werden daher hier umgeschaltet.
- Bei **X-ray** legt die Wahl des **Element** (Anodenmaterials) und der charakteristischen Linie (Kα usw.) die Wellenlänge dieser charakteristischen Röntgenstrahlung automatisch fest.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** und **Wavelength (Å)** sind miteinander verknüpft.
- Diese Energie bzw. Wellenlänge wird zur Berechnung von 2θ (dem Beugungswinkel) verwendet. Bei Röntgenstrahlung kann sie auch über die Auswahl von Element und Linientyp festgelegt werden.

---

## Anzeige- und Berechnungsoptionen

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : berechnet die relative Intensität als Pulverbeugungsintensität (Bragg–Brentano), einschließlich Multiplizität und Lorentz-Polarisationsfaktor. Wenn ausgeschaltet, wird die Strukturfaktor-Intensität angezeigt.
- **Hide equivalent planes** : fasst kristallographisch äquivalente Ebenen zu einem einzigen Eintrag zusammen.
- **Hide prohibited planes** : schließt Ebenen aus, deren Intensität aufgrund der Auslöschungsregeln null ist.
- **Unit (Å / nm)** : schaltet die Längeneinheit für d-spacing usw. um.
- **d-Spacing Cutoff** : schließt Reflexe aus, deren d-spacing kleiner als dieser Wert ist.

---

## Reflexliste

Jede Zeile entspricht einem Reflex (oder einer Gruppe symmetrieäquivalenter Ebenen).

| Spalte | Bedeutung |
|------|------|
| **h, k, l** | Miller-Indizes |
| **Multi.** | Multiplizität (Anzahl der symmetrieäquivalenten Ebenen) |
| **d (Å)** | Netzebenenabstand |
| **q (2π/d)** | Betrag des Streuvektors |
| **2θ (°)** | Beugungswinkel für die gewählte Wellenlänge |
| **F_real** | Realteil des Strukturfaktors |
| **F_inv** | Imaginärteil des Strukturfaktors |
| **\|F\|** | Strukturfaktor-Amplitude ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | Strukturfaktor-Intensität ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | relative Intensität, wobei der stärkste Reflex auf 100 gesetzt wird |

---

## Copy to Clipboard

**Copy to Clipboard** kopiert die Liste als Text in die Zwischenablage, der in eine Tabellenkalkulation wie Excel eingefügt werden kann.

---

## Siehe auch

- [Anhang-Übersicht](index.md)
- [4. Praktische Arbeitsabläufe](../4-procedures.md) — Festlegen des Standardkristalls, dessen Strukturfaktoren berechnet werden.
- [6. Parameter finden (Brute-Force)](../6-find-parameter.md)
