<!-- 261124Cl: Retranslated from en/2-property-windows.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Eigenschaftsfenster

Im Eigenschaftsfenster stellen Sie die Strahlungsquelle, die Detektorbedingungen und die verschiedenen Bedingungen für die Integration des Bildes zu einem 1D-Profil ein. Jede Registerkarte lässt sich auch direkt über das Menü **Eigenschaften (Property)** im Hauptfenster öffnen.

Die Beschriftungen unten sind die Anzeigenamen der deutschen Oberfläche; in Klammern steht jeweils der englische Name. Die Überschriften verwenden die tatsächlichen Namen der Registerkarten und Steuerelemente.

## Wellenquelle (Wave source)

Legt die Art des einfallenden Strahls und die Wellenlänge fest. Als Quelle stehen Röntgen-, Elektronen- und Neutronenstrahlung zur Wahl. Bei Röntgenstrahlung wird die Wellenlänge durch Auswahl eines Elements und eines Übergangs (K-Linie, L-Linie usw.) automatisch eingetragen; bei Synchrotronstrahlung geben Sie die Wellenlänge direkt ein. Bei Elektronen- und Neutronenstrahlen geben Sie die Energie oder die Wellenlänge ein (die Elektronenwellenlänge wird relativistisch korrigiert).

- **Lineare Polarisation korrigieren (d. h. linear polarisiert → unpolarisiert) (Correct linear polarization (i.e., linear polarized → unpolarized))**: korrigiert eine linear polarisierte Intensität auf das unpolarisierte Äquivalent (für Synchrotrondaten). Die unten stehende Korrekturformel hängt vom Azimut χ und vom Streuwinkel 2θ ab. Ist die χ-Bezugsrichtung (auf der Registerkarte Sonstiges (Miscellaneous) eingestellt) Links/Rechts, wird der Strahl als horizontal polarisiert behandelt; ist sie Oben/Unten, als vertikal polarisiert.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Registerkarte Wellenquelle (Wave source)](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detektorbedingung (Detector condition)

Legt die geometrischen Bedingungen des Detektors fest. Dies entspricht der früheren „IP Condition“, ergänzt um die Auswahl des Koordinatensystems und der Detektorform.

- **Koordinaten (Coordinates)**: **Direktstrahl (Direct spot)** (Bezug auf den Direktstrahl) / **Fuß (Foot)** (Bezug auf den Lotfußpunkt).
- **Detektortyp (Detector type)**: **Flachdetektor (Flat panel)** / **Gandolfi**.
- **Direktstrahlposition (Direct spot position)** und **Kameralänge 1 (Camera Length 1)**: die Position des Direktstrahls (X, Y pix) und der Abstand von der Probe zum Direktstrahl (mm).
- **Fußposition (Foot position)** und **Kameralänge 2 (Camera Length 2)**: im Fuß-Modus die Position des Lotfußpunkts und der Abstand von der Probe zum Lotfußpunkt.
- **Pixelform (Pixel Shape)**: Pixelgröße X, Y (mm) und ξ (Ksi, der Scherwinkel des Parallelogramms).
- **Gandolfi-Radius (Gandolfi Radius)**: der Radius, wenn die Gandolfi-Form gewählt ist.
- **Sphärische Korrektur (Spherical correction)**: Geben Sie für einen gekrümmten Detektor den Kehrwert des Krümmungsradius 1/R in m⁻¹ ein (auf dem Bildschirm wird die Einheit als /m angezeigt). Für einen Flachdetektor verwenden Sie 0.
- **Neigung (Tilt)**: die IP-Verkippung φ (Phi) und τ (Tau).

Die Definitionen der Verkippung φ, τ und des Pixelparameters ξ finden Sie im [Überblick](0-overview.md).

![Registerkarte Detektorbedingung (Detector condition)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integralbereich (Integral Region)

Legt den Bildbereich fest, der integriert wird.

- **Rechteck (Rectangle)**: Wählen Sie die **Richtung (Direction)** (Voll / Oben / Unten / Links / Rechts (Full / Top / Bottom / Left / Right) sowie Vertical / Horizontal / Free) und stellen Sie die **Bandbreite (Band Width)**, den **Winkel (Angle)** (im Modus Free) und **Beide Seiten (Both Side)** ein.
- **Sektor (Sector)**: Geben Sie den Winkelbereich mit **Startwinkel (Start Angle)** / **Endwinkel (End Angle)** an.
- **Ausnahmepixel (Exceptional pixels)**: schließt **Maskierte Spots (Masked Spots)**, Pixel **Unter Intensität von (Under intensity of)** / **Über Intensität von (Over intensity of)** den angegebenen Schwellen sowie eine Anzahl **Pixel von den Rändern (pixels from edges)** aus. Die Schwellenwertmasken werden aus den korrigierten Intensitäten neu berechnet, sobald sich die Intensitäten ändern: wenn ein anderer Frame eines Sequenzbildes ausgewählt wird, nach Spiegeln/Drehen sowie bei Änderung des Hintergrundabzugs oder der Polarisationskorrektur.

![Registerkarte Integralbereich (Integral Region)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integraleigenschaft (Integral Property)

Legt Integrationsmethode und Schrittweite fest.

- **Konzentrische Integration (streuwinkeldispersiv) (Concentric integration (scattering angle dispersive))**: Wählen Sie die Einheit der horizontalen Achse aus **Winkel (Angle)** (2θ, °) / **d-Wert (d-spacing)** (Å) und stellen Sie **Start / Ende / Schritt (Start / End / Step)** ein. Die Auswahl **Ausgabemuster (Output pattern)** (Bragg-Brentano / Debye-Scherrer) wirkt sich in der aktuellen Version nicht auf das Ergebnis aus.
- **Radiale Integration (Cake-Muster) (Radial integration (cake pattern))**: summiert die Intensität eines ringförmigen Bereichs für jeden Azimut. Geben Sie die Ringmitte (**Donut-Radius (Donut radius)**) und die Halbbreite (**Donut-Breite (Donut width)**) als Streuwinkel 2θ (**Winkel (Angle)**) oder d-Wert (**d-Wert (d-spacing)**) an und stellen Sie den **Sektorwinkel-Schritt (Sweep-Schritt) (Sector angle step (Sweep step))** (azimutale Schrittweite) ein. Die horizontale Achse des erhaltenen Profils ist der Azimut χ (°).

![Registerkarte Integraleigenschaft (Integral Property)](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Maskenoptionen (Mask Option)

Legt die Bedingungen für das Maskieren und die Spot-Erkennung fest (eine Erweiterung des früheren „Find Center & Spots“). Die Einstellungen für die Zentrumserkennung befinden sich auf der Registerkarte Sonstiges (Miscellaneous).

- **Halbmaske (Half mask)**: Schaltflächen, mit denen die obere, untere, linke oder rechte Bildhälfte schnell maskiert wird.
- **Manueller Maskenmodus (Manual mask mode)**: aktiviert das interaktive Maskieren im Hauptbild. Die Formen sind **Kreis (Circle)** (Ziehen setzt Zentrum und Radius), **Polygon** (Klicken fügt Ecken hinzu), **Rechteck (Rectangle)** (Ziehen der Diagonalecken), **Spline-Kurve (Spline curve)** und **Spot** (Links-/Rechtsklick fügt Spots hinzu/entfernt sie).
- **Maskeneinstellung übernehmen (Take over mask setting)**: wie die Maske beim Laden eines neuen Bildes behandelt wird (**Keine (None)** / **Aktuellen Maskenzustand übernehmen (Take over the current mask state)** / **Maskendatei übernehmen (Take over the mask file)**).
- **Spots-Maskieren-Optionen (Mask spots option)** → **Kriteriumsabweichung für "Spots maskieren" (Criterial deviation for "Mask Spots")**: die statistische Schwelle für die Spot-Erkennung (um wie viele Standardabweichungen ein Pixel über dem Mittelwert liegen muss, um als Spot zu gelten).

![Registerkarte Maskenoptionen (Mask Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## Nach "Profil abrufen" (After "Get Profile")

Legt das Speichern und Senden nach der Integration fest.

- **Profil speichern (Save Profiles)**: Wählen Sie das Ziel unter **Speicherverzeichnis (Directory to be saved)** (**Im selben Verzeichnis wie das Bild (At the same directory of the image)** / **Jedes Mal im gewählten Verzeichnis (At the chosen directory each time)**) und das Format unter **Dateiformat (File format)** (**PDI** / **CSV** / **TSV** / **GSAS**). Die GSAS-Ausgabe ist nur bei konzentrischer Integration mit 2θ als horizontaler Achse möglich. Unter **Speicheroption für Bildserie oder azimutale Unterteilung (Saving option)** wird bei **In einer Datei (außer GSAS) (In one file (Excluding GSAS))** kein GSAS geschrieben; wählen Sie stattdessen **In getrennten Dateien (In separate files)**.
- **Profildaten über Zwischenablage an PDIndexer senden (Send profile data to PDIndexer through Clipboard)**: sendet das Profil über die Zwischenablage an eine laufende PDIndexer-Instanz.

![Registerkarte Nach "Profil abrufen" (After "Get Profile")](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Abgewickeltes Bild – Optionen (Unrolled Image Option)

Legt die Parameter für das abgewickelte (Unroll-)Bild fest.

- **Horizontal (Abstand vom Direktstrahl): Einheit und Bereich (Horizontal (distance from direct spot) unit and range)**: **Start / Ende / Schritt (Start / End / Step)** im Streuwinkel 2θ (°) (Einheitenoptionen werden angezeigt, die aktuelle Version behandelt die Werte jedoch immer als 2θ). Die Breite des Ausgabebildes ≈ (Ende − Start) / Schritt.
- **Vertikal (Sektorwinkel): Schritt (Vertical (sector angle) step)**: die Anzahl der Unterteilungen N im Azimut. Das Ausgabebild ist N Pixel hoch, und jede Zeile deckt 360°/N ab (0,5° beim Standardwert 720).

Beim Abwickeln wird das polare Beugungsbild mit dem Direktstrahl als Zentrum in ein kartesisches Bild (Winkel gegen Abstand) abgebildet.

![Registerkarte Abgewickeltes Bild – Optionen (Unrolled Image Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Sonstiges (Miscellaneous)

Eine Registerkarte, die feinere Anzeige- und Koordinateneinstellungen zusammenfasst.

- **Bildnamen-Optionen (Image name options)**: **Dateiname (File name)** / **Letzter Ordner + Dateiname (Last folder + file name)** / **Vollständiger Pfad (Full path)**.
- **Bildladeoptionen (Image loading options)** → **Anzeigebereich beibehalten (Maintain display range)**: ob Zoom und Anzeigeposition (Anzeigebereich) beim Laden eines neuen Bildes übernommen werden.
- **Chi-(χ)-Achsen-Optionen (Chi (χ) axis options)**: die Bezugsposition (Oben / Unten / Links / Rechts (Top / Bottom / Left / Right)) und der Drehsinn (Im Uhrzeigersinn / Gegen den Uhrzeigersinn (Clockwise / Counterclockwise)). χ wird von der Polarisationskorrektur und der radialen Integration verwendet.
- **Maßstabslinien-Optionen (Scale line options)**: Farben (**2θ scale line** / **Azimuth scale line**), **Linienbreite (Line Width)**, **Unterteilung (Division)** und **Beschriftungen anzeigen (Show labels)**.
- **Zentrumsuche-Optionen (Find center options)**: **Search area ±**, **Peak fitting range (2θ)**, **Zentrum fixieren (Fix Center)** und **Maskierte Pixel ausschließen (Exclude masked pixels)**.

![Registerkarte Sonstiges (Miscellaneous)](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Hintergrundoptionen (Background Option)

Legt die Korrektur mit einem Hintergrundbild fest.

- **Referenzbild-Einstellung (Reference image setting)**: Legen Sie das aktuell angezeigte Bild als Hintergrund fest (**Aktuelles Bild als Hintergrund festlegen (Set the current image as background)**) oder löschen Sie es (**Leeren (Clear)**).
- **Koeffizient (Coefficient)**: der Faktor, mit dem das Hintergrundbild multipliziert wird.

Dient zum Abzug eines additiven Untergrunds wie der Luftstreuung. Für jedes Pixel wird \(I_\mathrm{out} = I - cB\) berechnet (\(B\): Hintergrundbild, \(c\): Koeffizient). Um Pixel nahe den Bildrändern auszuschließen, verwenden Sie **Pixel von den Rändern (pixels from edges)** auf der Registerkarte Integralbereich (Integral Region).

![Registerkarte Hintergrundoptionen (Background Option)](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
