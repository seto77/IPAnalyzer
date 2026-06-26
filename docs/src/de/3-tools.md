<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Werkzeuge

Diese Seite beschreibt die Hilfswerkzeuge, die über die vertikale Symbolleiste am rechten Rand des Hauptfensters oder über die Menüs gestartet werden. Konkrete Vorgehensweisen zur Parameterkalibrierung und zu Makros finden Sie unter [Arbeitsabläufe](4-procedures.md).

## Intensity Table

Ein Werkzeug, das die Intensitätsverteilungen zweier Bilder vergleicht und eine Tabelle zur Intensitätsumrechnung optimiert. Es optimiert 16 Kontrollpunkte über 300 Iterationen, um die beiden Intensitäten aneinander anzugleichen, während die gesamte integrierte Intensität erhalten bleibt. Es wird beispielsweise verwendet, um die Intensitätsantwort eines Detektors zu kalibrieren.

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

Ein Werkzeug, das einen Ordner überwacht, neue Bilder automatisch lädt und nach dem Laden eine Folge von Operationen ausführt.

- **Watch and auto-load**: überwacht den angegebenen Ordner (einschließlich Unterordner) und liest eine Datei, nachdem ihr Schreibvorgang abgeschlossen ist. Dateien können nach Name gefiltert werden (Zahlenabgleich, Schlüsselwort).
- **Auto execution**: führt die angehakten Schritte der Reihe nach aus, aus Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro.

Dies ermöglicht Anwendungen wie das Überwachen eines Ausgabeordners während eines Experiments und das automatische Integrieren jedes Bildes, sobald es eintrifft. Einzelheiten finden Sie unter [Arbeitsabläufe](4-procedures.md).

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

Zeichnet einen Ring in einem angegebenen Abstand, Winkel oder d-Wert auf dem Bild und berücksichtigt dabei die IP-Verkippung und die Pixelverzerrung. Klicken Sie auf eines der Felder **R (mm)** / **2θ (°)** / **d (Å)**, um zu wählen, welcher Wert bearbeitet werden soll; die übrigen werden automatisch aus der Wellenlänge und der Kameralänge berechnet.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

Wickelt das Beugungsbild aus Polarkoordinaten, die auf den Durchstrahlfleck zentriert sind, in kartesische Koordinaten ab (horizontale Achse = Winkel, Abstand oder d-Wert; vertikale Achse = Azimut). Es wird inzwischen nicht über ein eigenes Fenster, sondern über die Symbolleisten-Schaltfläche **Unroll** und die Registerkarte **Unrolled Image Option** der Eigenschaften konfiguriert. Das Abwickeln verwendet denselben Subpixel-Algorithmus zur Intensitätsverteilung wie die Eindimensionalisierung.

## Circumferential Blur

Ein Werkzeug, das das Ringmuster entlang der Umfangsrichtung (azimutal) weichzeichnet. Geben Sie einen einzelnen Unschärfewinkel an und wenden Sie ihn an.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

Ein Werkzeug zur Handhabung von Multiframe-Bildern (HDF5 und ähnliche; Zeitreihen, Temperaturreihen, Synchrotron-Energiescans).

- Wählen Sie ein einzelnes Frame aus der Frame-Liste aus, um es anzuzeigen, oder schalten Sie mit dem Schieberegler durch.
- Mit **multi-selection** wählen Sie mehrere Frames aus und berechnen deren **average** oder **sum**.
- Das Ziel der Eindimensionalisierung kann aus „alle Frames / ausgewählte Frames / nur oberstes" gewählt werden.
- Wenn jedes Frame Energieinformationen enthält, wird die Wellenlänge automatisch aktualisiert.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

Korrigiert die IP-Verkippung φ, τ und die Pixelverzerrung ξ und speichert das Bild mit quadratischen Pixeln in einer angegebenen Auflösung. Metadaten wie Kameralänge, Wellenlänge und Zentrumsposition werden ebenfalls geschrieben, sodass das Bild unter Beibehaltung der geometrischen Informationen an andere Bildverarbeitung übergeben werden kann.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

Ein Werkzeug, das die Wellenlänge, Kameralänge, Pixelgröße, Pixelverzerrung und Verkippung (φ, τ) aus den Beugungsringen eines Standardmaterials optimiert. Es verwendet zwei Muster, Primary und Secondary, und Sie wählen Peaks aus und optimieren mit **Refine!**. Die Konvergenz (Ellipsenmittelpunkt, Residuen) kann in den Diagrammen überprüft werden. Die konkreten Schritte finden Sie unter [Arbeitsabläufe](4-procedures.md).

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

Ein Werkzeug, das die Kameralänge und Wellenlänge durch eine erschöpfende Rastersuche statt durch ein Gradientenverfahren findet. Es ist wirksam, wenn die geometrische Optimierung Schwierigkeiten mit der Konvergenz hat, etwa bei unvollständigen Ringen oder verrauschten Daten. Das CrystalControl wird zur Eingabe der Kristallparameter verwendet. Die detaillierten Schritte finden Sie unter [Parameter finden (Brute-Force)](6-find-parameter.md) und den Arbeitsablauf unter [Arbeitsabläufe](4-procedures.md).

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Eine Funktion, die Operationen mit Python-ähnlichen Skripten automatisiert. Öffnen Sie den Makro-Editor über das Menü **Macro → Editor** im Hauptfenster.

- `for` / `if` / `while` / `def` / `class`, Arithmetik und das Modul `math` stehen zur Verfügung.
- APIs wie `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` ermöglichen den Aufruf jeder Operation.
- Beispielmakros (grundlegende Schleifen, Geometrie-Einrichtung, Stapelverarbeitung, azimutale Unterteilung, Maskieren, Senden an PDIndexer usw.) sind enthalten, und Sie können Variablen mit schrittweiser Ausführung untersuchen.

Die vollständige Funktionsreferenz und Beispiele finden Sie unter [Makro](5-macro/index.md) und makrobasierte Arbeitsabläufe unter [Arbeitsabläufe](4-procedures.md).

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

Ein Werkzeug, das für die spezifische Intensitätskorrektur von R-Axis-Detektoren vorgesehen ist; derzeit liest es nur die Datei, die Korrektur selbst ist noch nicht implementiert.

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
