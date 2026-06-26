<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# Main Window

Das Hauptfenster ist der erste Bildschirm, der beim Start von IPAnalyzer angezeigt wird. Es vereint die Darstellung des geladenen Beugungsbildes, die wichtigsten Operationen (Zentrum finden, Reflexe maskieren, Eindimensionalisierung) sowie die Einstiegspunkte zu den Einstellungen der Detektorparameter.

Das Fenster gliedert sich grob in die Menüs und die Symbolleiste oben, den Bildanzeigebereich in der Mitte, die vertikale Symbolleiste rechts und den Graphenbereich unten.

![Das IPAnalyzer-Hauptfenster](../assets/cap-en-auto/FormMain.png)

## Central View

### Image display

Das geladene Bild wird hier dargestellt. Je nach Position des Mauszeigers zeigt der Bereich oberhalb des Bildes die realen Koordinaten (mm), die Bildkoordinaten (pix), den Abstand vom Zentrum R (mm), den Streuwinkel 2θ, den d-Wert, den Azimut χ und die Intensität an. Die magentafarbene ×-Markierung kennzeichnet die Position des Direktreflexes (Zentrum).

Pixelzustände werden in unterschiedlichen Farben dargestellt.

| Color | Meaning |
| --- | --- |
| Cyan | Maskierter Reflex |
| Green | Von der Integration ausgeschlossener Bereich (in Integral Region festgelegt) |
| Magenta | Von der Integration ausgeschlossener Winkelbereich (in Integral Property festgelegt) |
| Blue | Pixel unterhalb der Intensitätsschwelle (in Integral Region festgelegt) |
| Red | Pixel oberhalb der Intensitätsschwelle |

### Mouse operations

Im Normalmodus:

- Linke Taste gedrückt halten: sucht in der Nähe nach dem Reflexzentrum.
- Doppelklick links: aktualisiert die Zentrumsposition auf den angeklickten Punkt.
- Ziehen mit rechts: zoomt in den aufgezogenen Bereich hinein.
- Rechtsklick: zoomt heraus.

Im **Manual spot mode** maskiert ein Linksklick und ein Rechtsklick hebt die Maskierung auf. Form und Größe der Maske werden in der Symbolleiste und in den Eigenschaften festgelegt.

### Auxiliary views and image information

Neben der zentralen Ansicht befinden sich Hilfsdarstellungen. Sie können zwischen **Whole image** und **Near center** umschalten: Die Gesamtbildansicht markiert den aktuell angezeigten Bereich mit einem gelben Rahmen, und die Ansicht nahe dem Zentrum zeigt ein vergrößertes Bild.

**Image Information** zeigt die Bildauflösung, die maximale Intensität, die Gesamtintensität, die Header-Daten und Ähnliches an.

### Display adjustment controls

Steuerelemente, die die Darstellung des Bildes anpassen:

- **Gradient**: kehrt die Tonwerte um.
- **Brightness scale**: logarithmisch / linear.
- **Color scale**: Graustufen / Farbe.
- **Scale line**: Anzeige von Maßstabslinien (keine / grob / mittel / fein).
- **Auto Contrast** / **Reset Contrast** sowie explizite minimale/maximale Intensität.
- Vergrößerungsschaltflächen (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Lower View

Der untere Bereich enthält drei Graphen/Ansichten in Registerkarten.

- **Frequency of Intensity**: die Intensitätsverteilung aller Pixel auf doppelt logarithmischen Achsen. Mit der Maus zoombar.
- **Converted Profile**: das Beugungsprofil nach der Eindimensionalisierung (Get Profile). Mit der Maus zoombar.
- **Statistical Information**: Statistiken für einen ausgewählten rechteckigen Bereich (X1,Y1)–(X2,Y2). Wenn ein sequenzielles Bild geladen ist, können auch die Statistiken desselben Bereichs in anderen Frames verglichen werden.

## Menus

Die Menüleiste besteht aus **File / Tool / Property / Option / Language / Macro / Help**.

### File

- **Read image**: öffnet ein Beugungsbild. Die unterstützten Formate finden Sie im [Überblick](0-overview.md).
- **Save image**: speichert im TIFF-, PNG-, CSV- oder IPA-Format. TIFF bewahrt die ursprünglichen Pixelintensitäten, PNG bewahrt die Darstellung (Helligkeit, Kontrast, Maske), und IPA ist ein verzeichnungskorrigiertes proprietäres Format (mit Metadaten).
- **Read / Save parameter**: importiert/exportiert Wellenlänge, Kameralänge, Pixelgröße, Verkippungskorrektur, Zentrumsposition usw. als `.prm`-Datei.
- **Read / Save / Clear mask**: importiert/exportiert eine Maske als `.mas`-Datei oder löscht sie (die Maske muss zur Auflösung des aktuellen Bildes passen).
- **Close**.

Bild-, Parameter- und Maskendateien können auch per Drag & Drop auf das Fenster geladen werden.

### Tool

- **Reset Frequency Profile**: löscht den Intensitätshäufigkeitsgraphen (das Bild bleibt erhalten).
- **Calibrate Raxis Image**.

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. Diese öffnen die entsprechenden Registerkarten des [Eigenschaftsfensters](2-property-windows.md) direkt.

### Option

- **ToolTip**: schaltet die Tooltips auf Schaltflächen und Menüs ein bzw. aus.
- **Flip**: horizontal / vertikal. **Rotate**: Auswahl eines Drehwinkels. Beide wirken sich nur auf die Darstellung aus; die geladenen Bilddaten selbst werden nicht verändert.
- **Ngen Compile** und **Clear registry** dienen der Entwicklung und Fehlersuche.

### Language

- Wechselt zwischen **English** und **Japanese** (die Einstellung wird in der Registry gespeichert).

### Macro

- **Editor**: öffnet den Makro-Editor (siehe [Werkzeuge](3-tools.md) / [Makro](5-macro/index.md)).

### Help

- **Program Updates**, **Hint**, **License**, **Version History**, **Web Page**.

## Operation toolbar

Die wichtigsten Bildverarbeitungsoperationen (mit detaillierten Optionen in den Dropdown-Menüs):

- **Background**: Subtraktion eines Hintergrundbildes (konfiguriert in Background Option).
- **Find Center**: erkennt das Strahlzentrum durch 2D-Pseudo-Voigt-Anpassung (Suchbereich standardmäßig 8 px, festgelegt in Miscellaneous). Das Dropdown-Menü bietet zudem eine ringbasierte Zentrumserkennung.
- **Fix center**: fixiert die Zentrumsposition.
- **Mask Spots**: erkennt und maskiert Reflexe anhand des Kriteriums Mittelwert ± Standardabweichung × Deviation. Das Dropdown-Menü umfasst Maskieren-alle, invertiertes Maskieren, manuell und so weiter.
- **Manual**: der manuelle Maskenmodus. Sie können die Form (Kreis / Rechteck) und die Größe (8–256 px) wählen.
- **Get Profile**: integriert das Bild zu einem eindimensionalen Profil. Unterstützt Concentric (2θ-basiert) und Radial (azimutbasiert). Das Dropdown-Menü konfiguriert die Auswahl von Integral Property/Region, ob vor der Integration das Zentrum gefunden und Reflexe maskiert werden, das Senden an PDIndexer, die azimutale Sektoranalyse, die Verarbeitung sequenzieller Bilder und so weiter.

## Toolbar (other tools)

Die vertikale Symbolleiste rechts startet die verschiedenen Werkzeuge. Einzelheiten finden Sie unter [Werkzeuge](3-tools.md).

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
