<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). -->

# Hauptfenster

Das Hauptfenster ist der erste Bildschirm, der beim Start von IPAnalyzer erscheint. Hier sind die Anzeige des geladenen Beugungsbildes, die wichtigsten Operationen (Zentrum finden, Spots maskieren, Eindimensionalisierung) und die Zugänge zu den Einstellungen der Detektorparameter zusammengefasst.

Das Fenster besteht grob aus Menüs und Symbolleiste oben, dem Bildanzeigebereich in der Mitte, der vertikalen Symbolleiste rechts und dem Diagrammbereich unten.

![Das Hauptfenster von IPAnalyzer](../assets/cap-en-auto/FormMain.png)

## Zentrale Ansicht

### Bildanzeige

Hier wird das geladene Bild angezeigt. Oberhalb des Bildes werden, abhängig von der Position des Mauszeigers, die realen Koordinaten (mm), die Bildkoordinaten (pix), der Abstand vom Zentrum R (mm), der Streuwinkel 2θ, der d-Wert, der Azimut χ und die Intensität angezeigt. Das magentafarbene ×-Zeichen markiert die Position des Direktstrahls (Zentrums).

Pixelzustände werden in unterschiedlichen Farben dargestellt.

| Farbe | Bedeutung |
| --- | --- |
| Cyan | Maskierter Spot |
| Grün | Von der Integration ausgeschlossener Bereich (festgelegt in Integralbereich (Integral Region)) |
| Magenta | Von der Integration ausgeschlossener Winkelbereich (festgelegt in Integraleigenschaft (Integral Property)) |
| Blau | Pixel unterhalb der Intensitätsschwelle (festgelegt in Integralbereich (Integral Region)) |
| Rot | Pixel oberhalb der Intensitätsschwelle |

### Mausbedienung

Im normalen Modus:

- Linker Doppelklick: setzt die Zentrumsposition auf den angeklickten Punkt.
- Mittelklick: sucht das Zentrum, ausgehend vom angeklickten Punkt.
- Rechts ziehen: zoomt in den aufgezogenen Bereich.
- Rechtsklick: zoomt heraus.
- Strg + Rechts ziehen: wählt den rechteckigen Bereich für die statistischen Informationen aus.

Linker Doppelklick und Mittelklick funktionieren nur, solange **Zentrum fixieren (Fix Center)** ausgeschaltet ist.

Ist **Manueller Modus (Manual Mode)** aktiv, maskiert ein Linksklick, und ein Rechtsklick hebt die Maskierung auf. Form und Größe der Maske werden in der Symbolleiste und in den Eigenschaften eingestellt.

### Hilfsansichten und Bildinformationen

Neben der zentralen Ansicht befinden sich Hilfsanzeigen. Sie können zwischen **Ganzes Bild (Whole image)** und **Nahe dem Zentrum (Near center)** umschalten: Die Gesamtansicht markiert den aktuellen Anzeigebereich mit einem gelben Rahmen, die Ansicht nahe dem Zentrum zeigt ein vergrößertes Bild.

**Bildinformation (Image Information)** zeigt die Bildauflösung, die maximale Intensität, die Gesamtintensität, Header-Daten usw.

### Steuerelemente für die Anzeige

Steuerelemente, mit denen die Darstellung des Bildes angepasst wird:

- **Gradient**: kehrt die Tonwerte um.
- **Helligkeitsskala (Brightness scale)**: logarithmisch / linear.
- **Farbskala (Color scale)**: Graustufen / Farbe.
- **Maßstabslinie (Scale line)**: Anzeige der Maßstabslinien (keine / grob / mittel / fein).
- **Autokontrast (Auto Contrast)** / **Kontrast zurücksetzen (Reset Contrast)** sowie explizite Angabe der minimalen/maximalen Intensität.
- Vergrößerungsschaltflächen (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Untere Ansicht

Der untere Bereich enthält drei Diagramme/Ansichten in Registerkarten.

- **Intensitätshäufigkeit (Frequency of Intensity)**: die Intensitätsverteilung aller Pixel in doppelt logarithmischer Darstellung. Mit der Maus zoombar.
- **Konvertiertes Profil (Converted Profile)**: das mit **Profil abrufen (Get Profile)** erzeugte Beugungsprofil. Mit der Maus zoombar.
- **Statistische Information (Statistical Information)**: Statistik des rechteckigen Bereichs (X1,Y1)–(X2,Y2), der durch Strg + Rechts ziehen im Bild ausgewählt wurde. Ist eine Bildsequenz geladen, lässt sich auch die Statistik desselben Bereichs in anderen Frames vergleichen.

## Menüs

Die Menüleiste besteht aus **Datei / Werkzeuge / Eigenschaften / Optionen / Sprache / Makro / Hilfe (File / Tool / Property / Option / Language / Macro / Help)**.

### Datei (File)

- **Bild einlesen (Read image)**: öffnet ein Beugungsbild. Die unterstützten Formate finden Sie im [Überblick](0-overview.md).
- **Bild speichern (Save image)**: speichert im TIFF-, PNG-, CSV- oder IPA-Format. TIFF speichert die aktuellen verarbeiteten Pixelintensitäten (nach Spiegeln/Drehen, Hintergrundabzug und Polarisationskorrektur), PNG bewahrt die Anzeige (Helligkeit, Kontrast, Maske), und IPA ist ein verzerrungskorrigiertes eigenes Format (mit Metadaten).
- **Parameter einlesen / Parameter speichern (Read / Save parameter)**: importiert/exportiert Wellenlänge, Kameralänge, Pixelgröße, Neigungskorrektur, Zentrumsposition usw. als `.prm`-Datei.
- **Maske einlesen / Maske speichern / Maske löschen (Read / Save / Clear mask)**: importiert/exportiert eine Maske als `.mas`-Datei oder löscht sie (die Maske muss zur Auflösung des aktuellen Bildes passen).
- **Schließen (Close)**.

Bild-, Parameter- und Maskendateien lassen sich auch per Drag & Drop auf das Fenster laden.

### Werkzeuge (Tool)

- **Häufigkeitsprofil zurücksetzen (Reset Frequency Profile)**: baut das Intensitätshäufigkeits-Diagramm des aktuellen Bildes mit dem Standardbereich neu auf (das Bild bleibt erhalten).
- **R-AXIS-Bild kalibrieren (Calibrate Raxis Image)**: ermittelt aus zwei R-AXIS-Bildern eine Intensitätsumrechnungstabelle (siehe [Werkzeuge](3-tools.md)).

### Eigenschaften (Property)

Strahlungsart (Wave Source) / Imaging-Plate-Bedingung (Imaging Plate Condition) / Integralbereich (Integral Region) / Integraleigenschaft (Integral Property) / Manueller Maskenmodus (Manual Mask Mode) / Nach "Profil abrufen" (After "Get Profile") / Option für abgerolltes Bild (Unrolled Image Option) / Verschiedenes (Miscellaneous). Diese Einträge öffnen direkt die entsprechenden Registerkarten des [Eigenschaftsfensters](2-property-windows.md).

### Optionen (Option)

- **QuickInfo (ToolTip)**: schaltet die QuickInfos an Schaltflächen und Menüs ein oder aus.
- **Spiegeln (Flip)**: **Horizontal (Horizontally)** / **Vertikal (Vertically)**. **Drehen (Rotate)**: wählt einen Drehwinkel. Spiegeln und Drehen werden auf die Arbeitsbilddaten angewendet und wirken sich daher auch auf die anschließende Integration und das Speichern des Bildes aus (die Quelldatei auf dem Datenträger wird nicht verändert).
- **Registry löschen (Clear registry)**: ein Eintrag zur Fehlerbehebung, der die gespeicherten Einstellungen löscht. **Ngen-Kompilierung (Ngen Compile)** hat in der aktuellen Version keine Funktion.

### Sprache (Language)

- Wählt die Anzeigesprache (11 Sprachen). Nach einer Bestätigung wird die Anwendung neu gestartet. Die Einstellung wird in der Registry gespeichert.

### Makro (Macro)

- **Editor**: öffnet den Makro-Editor (siehe [Werkzeuge](3-tools.md) / [Makro](5-macro/index.md)).

### Hilfe (Help)

- **Programm-Updates (Program Updates)**, **Hinweis (Hint)**, **Lizenz (License)**, **Versionsverlauf (Version History)**, **Hilfe (Help)** (öffnet das mitgelieferte PDF-Handbuch).
- Drücken Sie in einem beliebigen Fenster **F1**, um die zugehörige Seite dieses Online-Handbuchs zu öffnen.

## Bedienungs-Symbolleiste

Die wichtigsten Bildverarbeitungsoperationen (mit ausführlichen Optionen in den Dropdown-Menüs):

- **Hintergrund (Background)**: Diese Schaltfläche ist in der aktuellen Version deaktiviert. Der Abzug eines Hintergrundbildes wird auf der Registerkarte **Hintergrundoptionen (Background Option)** des Eigenschaftsfensters eingestellt.
- **Zentrum finden (Find Center)**: ermittelt das Strahlzentrum durch eine 2D-Pseudo-Voigt-Anpassung (der Suchbereich beträgt standardmäßig ±8 px um das Zentrum und wird auf der Registerkarte Sonstiges (Miscellaneous) eingestellt). Werden mit **Ring zeichnen (Draw ring)** Ringe angezeigt, wird das Zentrum stattdessen aus dem Ring bestimmt.
- **Zentrum fixieren (Fix Center)**: fixiert die Zentrumsposition.
- **Spots maskieren (Mask Spots)**: Innerhalb jedes radialen Bandes werden Pixel, deren Intensität Mittelwert + Standardabweichung × Deviation übersteigt, als Spots erkannt und zusammen mit ihrer Umgebung maskiert. Das Dropdown-Menü enthält u. a. Gesamten Bereich maskieren (Mask all area), Maske umkehren (Invert mask) und den manuellen Modus.
- **Manueller Modus (Manual Mode)**: der manuelle Maskenmodus. Sie können die Maskenform (Spot (Kreis/Rechteck) / Kreis / Rechteck / Polygon / Spline) und die Spotgröße (Halbwertsbreite) wählen.
- **Profil abrufen (Get Profile)**: integriert das Bild zu einem eindimensionalen Profil. Unterstützt konzentrische (2θ-basierte) und radiale (azimutbasierte) Integration. Im Dropdown-Menü werden u. a. die Auswahl von Integraleigenschaft/Integralbereich, das Finden des Zentrums und Maskieren von Spots vor der Integration, das Senden an PDIndexer, die azimutale Unterteilungsanalyse und die Verarbeitung von Bildsequenzen eingestellt.

## Symbolleiste (weitere Werkzeuge)

Die vertikale Symbolleiste rechts startet die verschiedenen Werkzeuge. Einzelheiten finden Sie unter [Werkzeuge](3-tools.md).

- **Intensitätstabelle (Intensity table)** (dieser Schaltfläche ist in der aktuellen Version keine Funktion zugewiesen; verwenden Sie für die Intensitätskalibrierung von R-AXIS-Bildern **Werkzeuge → R-AXIS-Bild kalibrieren (Tool → Calibrate Raxis Image)**)
- **Autoprozedur (Auto procedure)**
- **Ring zeichnen (Draw ring)**
- **Parameter finden (geometrisch) (Find parameter (geometrically))** / **Parameter finden (Brute Force) (Find parameter (brute force))**
- **Bild abrollen (Unroll image)**
- **Umfangsunschärfe (Circumferential blur)**
- **Bildsequenz (Sequential image)**
