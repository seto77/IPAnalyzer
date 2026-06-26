<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Eigenschaftsfenster

Im Eigenschaftsfenster konfigurieren Sie die Strahlquelle, die Detektorbedingungen und die verschiedenen Bedingungen für die Eindimensionalisierung. Jede Registerkarte lässt sich auch direkt über das Menü **Property** im Hauptfenster öffnen.

Die Benutzeroberfläche dieses Fensters ist in Englisch. Die folgenden Überschriften verwenden die tatsächlichen Registerkarten- und Steuerelementnamen.

## Wave source

Legt die Art des einfallenden Strahls und die Wellenlänge fest. Als Quelle kommen Röntgen-, Elektronen- oder Neutronenstrahlung in Frage. Bei Röntgenstrahlung füllt die Auswahl eines Elements und eines Übergangs (K-Linie, L-Linie usw.) die Wellenlänge automatisch aus; bei Synchrotronstrahlung geben Sie die Wellenlänge direkt ein. Für Elektronen- und Neutronenstrahlen geben Sie die Energie oder die Wellenlänge ein (die Elektronenwellenlänge wird relativistisch korrigiert).

- **Correct linear polarization**: korrigiert eine linear polarisierte Intensität auf das unpolarisierte Äquivalent (für Synchrotrondaten). Die nachstehende Korrekturformel hängt vom Azimut χ (definiert auf der Registerkarte Miscellaneous) und vom Streuwinkel 2θ ab.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Registerkarte Wave source](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

Legt die geometrischen Bedingungen des Detektors fest. Dies entspricht der früheren „IP Condition", ergänzt um Auswahlmöglichkeiten für das Koordinatensystem und die Detektorform.

- **Coordinates**: **Direct spot** (Bezug auf den Direktstrahlfleck) / **Foot** (Bezug auf den Lotfußpunkt).
- **Detector type**: **Flat panel** / **Gandolfi**.
- **Direct spot position** und **Camera Length 1**: die Position des Direktstrahlflecks (X, Y pix) und der Abstand von der Probe zum Direktstrahlfleck (mm).
- **Foot position** und **Camera Length 2**: im Foot-Modus die Position des Lotfußpunkts und der Abstand von der Probe zum Fußpunkt.
- **Pixel Shape**: Pixelgröße X, Y (mm) und ξ (Ksi, der Scherwinkel des Parallelogramms).
- **Gandolfi Radius**: der Radius, wenn die Gandolfi-Form gewählt ist.
- **Spherical correction**: sphärische Korrektur (normalerweise null).
- **Tilt**: die IP-Verkippung φ (Phi) und τ (Tau).

Die Definitionen der Verkippung φ, τ und des Pixels ξ finden Sie im [Überblick](0-overview.md).

![Registerkarte Detector condition](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

Legt den Bildbereich fest, der eindimensionalisiert werden soll.

- **Rectangle**: wählen Sie die **Direction** (Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free) und legen Sie die **Band Width**, den **Angle** (im Free-Modus) und **Both Side** fest.
- **Sector**: geben Sie den Winkelbereich mit **Start Angle** / **End Angle** an.
- **Exceptional pixels**: schließen Sie **Masked Spots** aus, Pixel **Under intensity of** / **Over intensity of** den angegebenen Schwellenwerten sowie eine Anzahl von **pixels from edges**.

![Registerkarte Integral Region](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

Legt die Integrationsmethode und die Schrittweite fest.

- **Concentric integration (scattering-angle dispersive)**: wählen Sie die Einheit der horizontalen Achse aus **Angle** (2θ, °) / **Length** (mm) / **d-spacing** (Å) und legen Sie **Start / End / Step** fest. Das **Output pattern** kann **Bragg - Brentano** oder **Debye - Scherrer** sein.
- **Radial integration (cake pattern)**: analysiert einen ringförmigen Bereich in azimutaler Richtung. Wählen Sie die horizontale Achse aus **Angle** / **d-spacing** und legen Sie den **Donut radius** (zentraler Radius), die **Donut width** (Ringbreite) und den **Sector angle step** (Sweep-Schrittweite) fest.

![Registerkarte Integral Property](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

Legt die Bedingungen für die Maskierung und für die Zentrums-/Reflexerkennung fest (eine Erweiterung des früheren „Find Center & Spots").

- **Half mask**: Schaltflächen, die schnell die obere, untere, linke oder rechte Hälfte des Bildes maskieren.
- **Manual mask mode**: aktiviert das interaktive Maskieren auf dem Hauptbild. Die Formen sind **Circle** (Ziehen zum Festlegen von Zentrum und Radius), **Polygon** (Klicken zum Hinzufügen von Eckpunkten), **Rectangle** (diagonale Eckpunkte ziehen), **Spline curve** und **Spot** (Links-/Rechtsklick zum Hinzufügen/Entfernen von Reflexen).
- **Takeover**: wie die Maske behandelt wird, wenn ein neues Bild geladen wird (**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation**: der statistische Schwellenwert für die Reflexerkennung.
- **Find Center**: der Suchbereich für die Zentrumserkennung usw.

![Registerkarte Mask Option](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

Legt das Speichern und Senden nach der Eindimensionalisierung fest.

- **Save File**: wählen Sie das Ziel („dasselbe Verzeichnis wie das Bild" oder „ein jeweils auszuwählendes Verzeichnis") und das Format aus **PDI** / **CSV** / **TSV** / **GSAS**.
- **Send PDIndexer**: sendet das Profil über die Zwischenablage an eine laufende Instanz von PDIndexer.

![Registerkarte After "Get Profile"](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

Legt die Parameter für das abgewickelte (Unroll-)Bild fest.

- **Horizontal**: die Einheit (Angle / Length / d-spacing) und **Start / End / Step**. Die Breite des Ausgabebildes ≈ (End − Start) / Step.
- **Vertical**: die azimutale Schrittweite (°/Pixel). Die Höhe des Ausgabebildes ≈ 360 / Schrittweite.

Das Abwickeln bildet das polare Beugungsbild, zentriert auf den Direktstrahlfleck, in ein kartesisches Bild (Winkel gegen Abstand) ab.

![Registerkarte Unrolled Image Option](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

Eine Registerkarte, die die feineren Anzeige- und Koordinateneinstellungen zusammenfasst.

- **Image name display**: nur Dateiname / übergeordneter Ordner + Dateiname / vollständiger Pfad.
- **Contrast / intensity-range persistence**: ob Anzeigeeinstellungen beim Laden eines neuen Bildes übernommen werden.
- **Azimuth χ (Chi) orientation**: die Bezugsposition (Top / Bottom / Left / Right) und der Drehsinn (Clockwise / Counterclockwise). χ wird von der Polarisationskorrektur und der radialen Integration herangezogen.
- **Scale line**: Farbe, Breite, Anzahl der Unterteilungen und Beschriftungsanzeige.
- **Find Center**: Suchbereich, Bereich der Peak-Anpassung, Zentrum fixieren und maskierte Pixel ausschließen.

![Registerkarte Miscellaneous](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

Legt die Korrektur mittels eines Hintergrundbildes fest.

- **Background image**: legt das aktuell angezeigte Bild als Hintergrund fest (**Set the current image as background**) oder löscht es (**Clear**).
- **Coefficient**: der auf das Hintergrundbild angewandte Faktor.
- **Edge mask**: ein zusätzlicher Maskenrand (px), der bei der Korrektur an den Rändern angewendet wird.

Wird für die Flatfield-Korrektur, die Entfernung von Luftstreuung und Ähnliches verwendet.

![Registerkarte Background Option](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
