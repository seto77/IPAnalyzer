<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Arbeitsabläufe

Diese Seite zeigt den Ablauf typischer Aufgaben. Beschreibungen der einzelnen Werkzeuge finden Sie unter [Tools](3-tools.md).

## Grundablauf (konzentrische Integration)

1. **Bild laden**: File → Read image (oder per Drag & Drop).
2. **Quelle einstellen**: Legen Sie das Element/den Übergang oder die Wellenlänge unter **Wave source** in den Eigenschaften fest.
3. **Detektorbedingung einstellen**: Legen Sie die Kameralänge, die Pixelgröße, die Zentrumsposition (näherungsweise) und bei Bedarf die Verkippung φ, τ unter **Detector condition** fest.
4. **Zentrum finden**: Erkennen Sie das Strahlzentrum automatisch mit **Find Center** in der Symbolleiste (der Suchbereich wird unter Miscellaneous eingestellt).
5. **Reflexe maskieren**: Entfernen Sie Einkristall-Reflexe und dergleichen mit **Mask Spots**. Bei Bedarf maskieren Sie manuell mit **Manual**.
6. **Eindimensionalisieren**: Erhalten Sie das Profil mit **Get Profile**. Das Speichern und Versenden wird auf der Registerkarte **After "Get Profile"** konfiguriert (CSV speichern, an PDIndexer senden usw.).

Wählen Sie bei sequenziellen Bildern vor den Schritten 5–6 einen Frame unter [Sequential](3-tools.md) aus. Für die Analyse pro Azimut verwenden Sie die Radial integration in der **Integral Property**.

## Parameterbestimmung: Geometriekalibrierung mit einer Standardprobe (Doppelkassette)

Wenn die Kameralänge oder die Wellenlänge unbekannt ist, optimieren Sie die geometrischen Parameter aus den Beugungsringen eines Standardmaterials (standardmäßig CeO2 usw.) mit [Find Parameter (Geometric)](3-tools.md).

1. Laden Sie das **Primary image** (Standardprobe, bei einer Kameralänge) mit Open, finden Sie das Zentrum und zeigen Sie die Peaks mit **Get Profile** an.
2. Das Ziehen einer Beugungslinien-Markierung in der Profile View aktualisiert die Schätzung der Kameralänge automatisch.
3. Laden Sie das **Secondary image** (dieselbe Standardprobe, bei einer anderen Kameralänge) auf dieselbe Weise und geben Sie die **camera-length difference** relativ zu Primary ein.
4. Wählen Sie in der **Peak List** die d-spacing-Werte von Peaks aus, die in beiden Bildern erscheinen (mindestens einer pro Bild, idealerweise drei oder mehr).
5. Wählen Sie unter **Refinement Option** die zu optimierenden Parameter aus (Wellenlänge, Filmabstand, Verkippung, Pixelgröße, Pixelverzerrung).
6. Führen Sie **Refine!** aus, und sobald sich das Residuum stabilisiert hat, kopieren Sie die optimierten Ergebnisse zurück in das Hauptformular.

!!! note
    Die Verwendung zweier Bilder (eine „Doppelkassette") erleichtert es, die Kameralänge und die Wellenlänge getrennt zu bestimmen.

## Parameterbestimmung: Brute-Force-Optimierung (beliebige Probe)

Wenn die geometrische Optimierung Schwierigkeiten hat zu konvergieren, durchsuchen Sie die Kameralänge und die Wellenlänge erschöpfend mit [Find Parameter (Brute force)](3-tools.md). Eine ausführliche Anleitung mit Screenshots finden Sie unter [Find Parameter (brute force)](6-find-parameter.md).

1. Laden Sie das Primary- und das Secondary-Bild (zwei Bilder mit gemeinsamen Ringen, bei unterschiedlichen Kameralängen).
2. Richten Sie die Zentrumsposition im Hauptformular grob aus (Find Center hilft dabei).
3. Geben Sie die **search ranges (min, max, step)** für die Kameralänge, die Wellenlänge usw. ein. Lassen Sie unbekannte Parameter (Pixelgröße, Verkippung) zunächst ausgeschaltet.
4. Das Setzen der **Integral Region** auf einen Schlitzmodus (Rectangle) mit schmaler Bandbreite hilft, Rauschen zu unterdrücken.
5. Starten Sie die Suche und kopieren Sie die Kombination mit dem kleinsten Residuum zurück in das Hauptformular.

## Automatisierte Verarbeitung (Auto Procedure)

Verarbeiten Sie Bilder, die in einem Ordner eintreffen, automatisch, zum Beispiel während eines Experiments. Einzelheiten finden Sie unter [Tools](3-tools.md).

1. Aktivieren Sie **Automatically load new images** und wählen Sie den Überwachungsordner mit **Set** aus.
2. Filtern Sie bei Bedarf Dateien nach **number matching** (der Zahl am Ende des Dateinamens) oder nach **keyword**.
3. Aktivieren Sie **After Loading Image, Execute "Auto"** und wählen Sie aus der Liste: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Sobald die Überwachung gestartet ist, läuft die Sequenz jedes Mal automatisch ab, wenn ein passendes Bild eintrifft.

## Skriptgesteuerte Abläufe (Python-basierte Makros)

Eine Verarbeitung mit Schleifen und Bedingungen kann als [Makro](5-macro/index.md) geschrieben werden. Die mitgelieferten Beispielmakros sind ein guter Ausgangspunkt.

- Ein Bild laden, die Quelle und den Detektor einstellen (Zentrum, Kameralänge, Pixel) und die Anzeige einpassen.
- Die Bedingungen der konzentrischen Integration festlegen (Start, Ende, Schrittweite, Einheit), eindimensionalisieren und als CSV speichern.
- Mehrere Dateien stapelweise verarbeiten und jeweils eine CSV neben dem Bild speichern.
- Ein Multiframe-Bild Frame für Frame verarbeiten.
- Einen Debye-Ring in N Sektoren aufteilen und die azimutale Abhängigkeit analysieren.
- Maskieren (alles löschen → Reflexe maskieren → den Beam-Stop-Bereich maskieren → die Maske speichern) und eindimensionalisieren.
- Azimut gegen Intensität mit radialer (Cake-)Integration ausgeben.
- Das Senden an die Zwischenablage aktivieren, eindimensionalisieren und ein benanntes Makro in PDIndexer aufrufen (z. B. Peak-Fitting).

Selbst geschriebene Makros können gespeichert, namentlich aufgerufen und auch aus Auto Procedure ausgeführt werden.
