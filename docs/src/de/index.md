<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# IPAnalyzer-Handbuch

## Kurze Einführung

* **IPAnalyzer** ist eine MIT-lizenzierte freie Software, die zweidimensionale Pulverbeugungsbilder (Debye–Scherrer-Ringe), die mit Imaging Plates (IP) oder CCD/CMOS-Flachdetektoren aufgenommen wurden, in hochpräzise eindimensionale 2θ–Intensitätsprofile umwandelt.
* Sie kalibriert die Messgeometrie — Kameralänge, Wellenlänge, Detektorverkippung und Pixelform — anhand der Ringe von Standardmaterialien, unterstützt Röntgen-, Elektronen- und Neutronenquellen und arbeitet für die anschließende Peak-Analyse mit [PDIndexer](https://github.com/seto77/PDIndexer) zusammen.
* Aufbau und Funktionsumfang orientieren sich an *PIP*, das von Hiroshi Fujihisa am AIST entwickelt wurde.

## Nach Ziel finden

| Ziel | Hier beginnen | Wichtigste nächste Schritte |
|------|------------|-----------------|
| Das Koordinatensystem und die Geometrie verstehen | [Überblick](0-overview.md) | [Eigenschaftsfenster](2-property-windows.md) |
| Ein Bild laden und ein 1D-Profil erhalten | [Arbeitsabläufe](4-procedures.md) | [Hauptfenster](1-main-window.md), [Eigenschaftsfenster](2-property-windows.md) |
| Kameralänge / Wellenlänge kalibrieren | [Arbeitsabläufe](4-procedures.md) | [Werkzeuge](3-tools.md), [Find Parameter (brute force)](6-find-parameter.md) |
| Reflexe maskieren / Multiframe-Daten verarbeiten | [Werkzeuge](3-tools.md) | [Arbeitsabläufe](4-procedures.md) |
| Verarbeitung automatisieren | [Makro](5-macro/index.md) | [Integrierte Funktionen](5-macro/1-built-in-functions.md), [Beispiele](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Funktionen

* **Breite Formatunterstützung** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4 sowie allgemeine Bildformate. Die meisten Datei-Ein-/Ausgaben unterstützen Drag & Drop.
* **Umwandlung von Bild zu Profil** : Konzentrische (radial gemittelte), radiale (azimutale/Cake-) und abgewickelte Bildberechnung mithilfe eines subpixelgenauen Flächenverteilungs-Algorithmus, der Detektorverkippung und parallelogrammförmige Pixelformen korrekt berücksichtigt.
* **Geometriekalibrierung** : Geometrische (Doppelkassetten-)Verfeinerung von Wellenlänge, Kameralänge, Pixelgröße/-verzerrung und Verkippung (φ, τ) sowie eine Brute-Force-Rastersuche für schwierige Daten.
* **Bildverarbeitung** : Automatische Erkennung des Strahlzentrums, Erkennung und Maskierung von Einkristall-Reflexen (Spots), Umfangsunschärfe, Ring-Overlays, Detektorkalibrierung über Intensitätstabellen und geometrieerhaltendes IPA-Speichern.
* **Multiframe-Daten** : Auswählen, Mitteln oder Summieren von Frames aus HDF5/NeXus und anderen sequenziellen Daten, mit framespezifischer Wellenlänge aus der eingebetteten Energie.
* **Automatisierung** : Ordnerüberwachende Auto Procedure und ein Python-syntaktisches [Makro](5-macro/index.md) für Stapel- und skriptgesteuerte Verarbeitung.
* **PDIndexer-Integration** : Senden von Profilen an [PDIndexer](https://github.com/seto77/PDIndexer) über die Zwischenablage und Auslösen benannter Makros dort.
* **Helles / dunkles Design** : Die Oberfläche folgt einem wählbaren hellen oder dunklen Farbmodus.

## Systemvoraussetzungen

| Punkt | Minimum | Empfohlen |
|------|---------|-------------|
| Betriebssystem | Windows mit [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Arbeitsspeicher | - | 16 GB oder mehr |
| CPU | - | 8+ Kerne (Bildintensitäten werden in doppelter Genauigkeit gehalten und die Verarbeitung erfolgt mehrfädig) |

## Schnellstart

1. Von [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) herunterladen und installieren.
2. Ein Beugungsbild einlesen (File → Read image oder per Drag & Drop).
3. Die **Wave source** und die **Detector condition** (camera length, pixel size, ungefähres Zentrum) im Eigenschaftsfenster festlegen.
4. Das Zentrum bestimmen, bei Bedarf Reflexe maskieren und **Get Profile** drücken, um das 1D-Profil zu erhalten.
5. Ist die Geometrie unbekannt, kalibrieren Sie sie anhand eines Standardmaterials — siehe [Arbeitsabläufe](4-procedures.md).

Den vollständigen Arbeitsablauf finden Sie unter [Arbeitsabläufe](4-procedures.md).

## Verwendung dieses Handbuchs

Dieses GitHub-Pages-Handbuch ist die aktuell maßgebliche Quelle. Nutzen Sie die Navigation links, um nach Kapitel zu blättern, oder die Suche in der Kopfzeile, um einen Funktions- oder UI-Bezeichnernamen zu finden. Es ersetzt das frühere Word-/HTML-/PDF-Handbuch, das in `IPAnalyzer/doc/` ausgeliefert wurde.

## Lizenz

IPAnalyzer wird unter der [MIT-Lizenz](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) vertrieben.
