<!-- 261124Cl: Retranslated from en/appendix/a4-symmetry-information.md (UI labels follow the localized GUI). -->

# Anhang A4. Symmetrieinformationen

**Symmetrieinformation (Symmetry Information)** zeigt ausführliche Informationen zur Raumgruppensymmetrie des ausgewählten Kristalls und zeichnet zusätzlich schematische Diagramme der Symmetrieelemente und der allgemeinen Lagen im Stil der *International Tables for Crystallography* Vol. A.

In IPAnalyzer wird dieses Unterfenster aus dem **Kristallfenster** geöffnet (dem CrystalControl, das in [4. Arbeitsabläufe](../4-procedures.md) für die geometrische Kalibrierung und in [6. Parameter finden (Brute Force)](../6-find-parameter.md) verwendet wird).

![Symmetrieinformation (Symmetry Information)](../../assets/cap-en-auto/FormSymmetryInformation.png)

Das Fenster gliedert sich in einen Bereich zur Raumgruppenidentität (oben links), einen Berechnungs-/Tabellenbereich mit Registerkarten (oben rechts) und zwei schematische Diagramme (unten).

---

## Tastatur- und Maus-Kurzbefehle

Dieses Fenster hat keine besonderen Tasten- oder Mauskombinationen. <kbd>F1</kbd> öffnet diese Handbuchseite, und die beiden Schaltflächen **Copy** legen das Diagramm der Symmetrieelemente und das Diagramm der allgemeinen Lagen in die Zwischenablage (als Bitmap oder, wenn **EMF** angehakt ist, als Vektor-EMF).

---

## Raumgruppenidentität

Der Bereich oben links zeigt für die aktuelle Raumgruppe:

- **Number** (1–230) und den Aufstellungsindex
- **Crystal System** (Kristallsystem)
- **Point Group** (Punktgruppe): Hermann–Mauguin-Symbol (HM) und Schoenflies-Symbol (SF)
- **Space Group** (Raumgruppe): HM-Kurzsymbol, vollständiges HM-Symbol, SF-Symbol und **Hall-Symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Geben Sie zwei Kristallebenen \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) oder zwei Richtungsindizes \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) ein, um Folgendes zu erhalten:

- den Netzebenenabstand jeder Ebene / die Länge jeder Achse,
- den Winkel zwischen den beiden Ebenen (bzw. beiden Achsen),
- **die beiden Ebenen gemeinsame Zonenachse** (die Richtung ihrer Schnittgeraden) und **die Ebene, die beide Richtungen enthält**.

Diese Berechnungen berücksichtigen die Metrik der aktuellen Elementarzelle.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Listet jede Wyckoff-Lage mit ihrer Zähligkeit, dem Wyckoff-Buchstaben, der Lagesymmetrie und der Angabe, ob es sich um eine allgemeine oder spezielle Lage handelt. Bei zentrierten Gittern werden die Translationsvektoren des Gitters in der Kopfzeile angezeigt.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Die Reflexionsbedingungen, die sich aus der Gitterzentrierung und aus den Gleitspiegel-/Schraubenoperationen ergeben.

---

## Diagramme der Symmetrieelemente und der allgemeinen Lagen

![Diagramme der Symmetrieelemente und der allgemeinen Lagen](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

Die beiden unteren Bereiche geben die schematischen Symmetriediagramme der Raumgruppe in der Notation der *International Tables for Crystallography* Vol. A wieder.

- **Symmetrieelemente (links)**: Dreh-/Schraubenachsen, Spiegel-/Gleitspiegelebenen sowie Inversionszentren/Drehinversionspunkte werden mit den üblichen grafischen Symbolen gezeichnet.
  - Beim \(F\)-Gitter des kubischen Systems wird nur ein Achtel der Elementarzelle (nur der linke obere Quadrant) dargestellt.
- **Allgemeine Lagen (rechts)**: Die allgemeinen äquivalenten Lagen werden als Kreise dargestellt (ein Komma kennzeichnet ein Spiegelbild) und mit ihren fraktionellen Koordinaten beschriftet.
  - Nur beim kubischen System verbinden Hilfslinien die drei Kreise, die durch eine dreizählige Drehachse miteinander verknüpft sind.

Steuerelemente unter den Diagrammen:

- **Direction** (`a` / `b` / `c`): wählt die Kristallachse, entlang der projiziert wird.
- **Copy** kopiert jedes Diagramm als Vektorbild (**EMF**) oder Rasterbild (**BMP**) in die Zwischenablage; EMF lässt sich in PowerPoint in Einzelteile zerlegen und bearbeiten.

---

## Siehe auch

- [Startseite des Anhangs](index.md)
- [4. Arbeitsabläufe](../4-procedures.md) — geometrische Parameterkalibrierung mit einem Standardkristall.
- [6. Parameter finden (Brute Force)](../6-find-parameter.md)
