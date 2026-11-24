<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). -->

# IPAnalyzer-Handbuch

## Kurze Einführung

* **IPAnalyzer** ist eine MIT-lizenzierte freie Software, die zweidimensionale Pulverbeugungsbilder (Debye–Scherrer-Ringe), die mit Imaging Plates (IP) oder CCD/CMOS-Flachdetektoren aufgenommen wurden, in hochpräzise eindimensionale 2θ–Intensitätsprofile umwandelt.
* Sie kalibriert die Messgeometrie — Kameralänge, Wellenlänge, Detektorverkippung und Pixelform — anhand der Ringe von Standardmaterialien, unterstützt Röntgen-, Elektronen- und Neutronenquellen und arbeitet für die anschließende Peak-Analyse mit [PDIndexer](https://github.com/seto77/PDIndexer) zusammen.
* Aufbau und Funktionsumfang orientieren sich an *PIP*, das von Hiroshi Fujihisa am AIST entwickelt wurde.

## Nach Ziel finden

| Ziel | Hier beginnen | Wichtigste nächste Schritte |
|------|------------|-----------------|
| Koordinatensystem und Geometrie verstehen | [Überblick](0-overview.md) | [Eigenschaftsfenster](2-property-windows.md) |
| Ein Bild laden und ein 1D-Profil erhalten | [Arbeitsabläufe](4-procedures.md) | [Hauptfenster](1-main-window.md), [Eigenschaftsfenster](2-property-windows.md) |
| Kameralänge / Wellenlänge kalibrieren | [Arbeitsabläufe](4-procedures.md) | [Werkzeuge](3-tools.md), [Parameter finden (Brute Force)](6-find-parameter.md) |
| Spots maskieren / Multiframe-Daten verarbeiten | [Werkzeuge](3-tools.md) | [Arbeitsabläufe](4-procedures.md) |
| Verarbeitung automatisieren | [Makro](5-macro/index.md) | [Integrierte Funktionen](5-macro/1-built-in-functions.md), [Beispiele](5-macro/2-examples.md), [Automatische Prozedur (Auto Procedure)](3-tools.md) |
| Fehlersuche und häufige Fragen | [Fragen und Antworten](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## Funktionen

* **Breite Formatunterstützung** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4 sowie allgemeine Bildformate. Die meisten Datei-Ein-/Ausgaben unterstützen Drag & Drop.
* **Umwandlung von Bild zu Profil** : Konzentrische (radial gemittelte), radiale (azimutale/Cake-) Integration und Berechnung des abgewickelten Bildes mit einem subpixelgenauen Flächenverteilungs-Algorithmus, der Detektorverkippung und parallelogrammförmige Pixel korrekt berücksichtigt.
* **Geometriekalibrierung** : Geometrische (Doppelkassetten-)Verfeinerung von Wellenlänge, Kameralänge, Pixelgröße/-verzerrung und Verkippung (φ, τ) sowie eine Brute-Force-Rastersuche für schwierige Daten.
* **Bildverarbeitung** : Automatische Erkennung des Strahlzentrums, Erkennung und Maskierung von Einkristall-Reflexen (Spots), Umfangsunschärfe, Ring-Overlays, Intensitätskalibrierung von R-AXIS-Bildern und geometrieerhaltendes Speichern im IPA-Format.
* **Multiframe-Daten** : Auswählen, Mitteln oder Summieren von Frames aus NeXus (`.nxs`), mehrseitigen TIFF-Dateien und anderen sequenziellen Daten; enthält ein Frame Energieinformationen, wird beim Auswählen die Wellenlänge aktualisiert.
* **Automatisierung** : Ordnerüberwachende automatische Prozedur (Auto Procedure) und ein [Makro](5-macro/index.md) in Python-Syntax für Stapel- und skriptgesteuerte Verarbeitung.
* **PDIndexer-Integration** : Senden von Profilen an [PDIndexer](https://github.com/seto77/PDIndexer) über die Zwischenablage und Auslösen benannter Makros dort.

## Systemvoraussetzungen

Diese Voraussetzungen gelten für .NET-11-Builds aus diesem Quellbaum. Für veröffentlichte Releases gilt die jeweils für das Release angegebene Laufzeitvoraussetzung.

| Element | Minimum | Empfohlen |
|------|---------|-------------|
| Betriebssystem | Windows mit [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) | Windows 11 |
| Arbeitsspeicher | - | 16 GB oder mehr |
| CPU | - | 8+ Kerne (Bildintensitäten werden in doppelter Genauigkeit gehalten, die Verarbeitung ist mehrfädig) |

## Schnellstart

1. Laden Sie IPAnalyzer von [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) herunter und installieren Sie es.
2. Lesen Sie ein Beugungsbild ein (**Datei → Bild einlesen (File → Read image)** oder per Drag & Drop).
3. Legen Sie im Eigenschaftsfenster **Wellenquelle (Wave source)** und **Detektorbedingung (Detector condition)** fest (Kameralänge, Pixelgröße, ungefähres Zentrum).
4. Ist die Geometrie (Kameralänge, Wellenlänge, Verkippung) unbekannt, kalibrieren Sie sie zuerst anhand des Bildes einer Standardprobe und übernehmen Sie die Werte — siehe [Arbeitsabläufe](4-procedures.md).
5. Suchen Sie im Probenbild das Zentrum, maskieren Sie bei Bedarf Spots und klicken Sie auf **Profil abrufen (Get Profile)**, um das 1D-Profil zu erhalten.

Den vollständigen Ablauf finden Sie unter [Arbeitsabläufe](4-procedures.md).

## Verwendung dieses Handbuchs

Dieses Handbuch auf GitHub Pages ist die aktuell maßgebliche Dokumentation. Blättern Sie über die linke Navigation kapitelweise oder suchen Sie über das Suchfeld in der Kopfzeile nach einem Funktionsnamen oder einer UI-Beschriftung. Es ersetzt das frühere Word/HTML/PDF-Handbuch, das in `IPAnalyzer/doc/` ausgeliefert wurde.

## Lizenz

IPAnalyzer wird unter der [MIT-Lizenz](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) vertrieben.
