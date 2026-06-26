<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Anhang A4. Symmetry Information

**Symmetry Information** zeigt detaillierte Informationen über die Raumgruppensymmetrie des ausgewählten Kristalls an und stellt zusätzlich schematische Diagramme der Symmetrieelemente und der allgemeinen Lagen im Stil der *International Tables for Crystallography* Vol. A dar.

In IPAnalyzer wird dieses Unterfenster aus dem **Crystal window** geöffnet (dem CrystalControl, das in [4. Practical procedures](../4-procedures.md) für die geometrische Kalibrierung und in [6. Find Parameter (brute force)](../6-find-parameter.md) verwendet wird).

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

Das Fenster gliedert sich in einen Bereich zur Raumgruppenidentität (oben links), einen Berechnungs-/Tabellenbereich mit Registerkarten (oben rechts) und zwei schematische Diagramme (unten).

---

## Tastatur- und Maus-Kurzbefehle

Dieses Fenster verfügt über keine besonderen Tasten- oder Mauskombinationen. <kbd>F1</kbd> öffnet diese Handbuchseite, und die beiden **Copy**-Schaltflächen legen das Diagramm der Symmetrieelemente und das Diagramm der allgemeinen Lagen in die Zwischenablage (als Bitmap oder als Vektor-EMF, wenn **EMF** angehakt ist).

---

## Raumgruppenidentität

Das Panel oben links listet für die aktuelle Raumgruppe auf:

- **Number** (1–230) und den Aufstellungsindex
- **Crystal System**
- **Point Group** : Hermann–Mauguin- (HM) und Schoenflies-Symbole (SF)
- **Space Group** : HM-Kurzsymbol, HM-Vollsymbol, SF-Symbol und **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Geben Sie zwei Kristallebenen \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) oder zwei Richtungsindizes \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) ein, um Folgendes zu erhalten:

- den d-spacing jeder Ebene / die Länge jeder Achse,
- den Winkel zwischen den beiden Ebenen (oder den beiden Achsen),
- **den Richtungsindex senkrecht zu beiden Ebenen** und **den Ebenenindex senkrecht zu beiden Achsen**.

Diese Berechnungen berücksichtigen die Metrik der aktuellen Elementarzelle.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Listet jede Wyckoff-Lage mit ihrer Zähligkeit, ihrem Wyckoff-Buchstaben, ihrer Lagesymmetrie und der Angabe auf, ob es sich um eine allgemeine oder eine spezielle Lage handelt. Für zentrierte Gitter werden die Gittertranslationsvektoren in der Kopfzeile angezeigt.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Die Reflexionsbedingungen, die sich aus der Gitterzentrierung und aus den Gleit-/Schraubensymmetrieoperatoren ergeben.

---

## Diagramme der Symmetrieelemente und der allgemeinen Lagen

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

Die beiden Panels am unteren Rand geben die schematischen Symmetriediagramme der Raumgruppe in der Notation der *International Tables for Crystallography* Vol. A wieder.

- **Symmetrieelemente (links)**: Dreh-/Schraubenachsen, Spiegel-/Gleitebenen sowie Inversionszentren/Drehinversionspunkte werden mit den konventionellen grafischen Symbolen gezeichnet.
  - Für das \(F\)-Gitter des kubischen Systems wird nur ein Achtel der Elementarzelle (nur der obere linke Quadrant) dargestellt.
- **Allgemeine Lagen (rechts)**: Die allgemeinen äquivalenten Lagen werden als Kreise dargestellt (ein Komma kennzeichnet ein Spiegelbild) und mit ihren Bruchkoordinaten beschriftet.
  - Nur für das kubische System verbinden Hilfslinien die drei Kreise, die durch eine dreizählige Drehachse miteinander verknüpft sind.

Steuerelemente unterhalb der Diagramme:

- **Direction** (`a` / `b` / `c`) : Wahl der Kristallachse, entlang der projiziert wird.
- **Copy** jedes Diagramms in die Zwischenablage als Vektorbild (**EMF**) oder Rasterbild (**BMP**); EMF kann in PowerPoint aufgehoben (ungroup) und bearbeitet werden.

---

## Siehe auch

- [Anhang-Startseite](index.md)
- [4. Practical procedures](../4-procedures.md) — geometrische Parameterkalibrierung mit einem Standardkristall.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
