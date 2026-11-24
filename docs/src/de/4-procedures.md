<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Arbeitsabläufe

Diese Seite zeigt den Ablauf typischer Aufgaben. Beschreibungen der einzelnen Werkzeuge finden Sie unter [Werkzeuge](3-tools.md).

## Grundablauf (konzentrische Integration)

1. **Bild laden**: **Datei → Bild einlesen (File → Read image)** (oder per Drag & Drop).
2. **Quelle einstellen**: Stellen Sie in den Eigenschaften unter **Wellenquelle (Wave source)** Element/Übergang oder die Wellenlänge ein.
3. **Detektorbedingung einstellen**: Stellen Sie unter **Detektorbedingung (Detector condition)** Kameralänge, Pixelgröße, (ungefähre) Zentrumsposition und bei Bedarf die Verkippung φ, τ ein.
4. **Zentrum finden**: Ermitteln Sie das Strahlzentrum automatisch mit **Zentrum finden (Find Center)** in der Symbolleiste (der Suchbereich wird auf der Registerkarte Sonstiges (Miscellaneous) eingestellt).
5. **Spots maskieren**: Entfernen Sie Einkristall-Reflexe und Ähnliches mit **Spots maskieren (Mask Spots)**. Bei Bedarf maskieren Sie manuell mit **Manueller Modus (Manual Mode)**.
6. **Integrationseinstellungen prüfen**: Wählen Sie unter **Integralbereich (Integral Region)** den Zielbereich und unter **Integraleigenschaft (Integral Property)** die **Konzentrische Integration (streuwinkeldispersiv) (Concentric integration (scattering angle dispersive))** mit Achseneinheit und **Start / Ende / Schritt (Start / End / Step)**.
7. **Bild integrieren**: Erhalten Sie das Profil mit **Profil abrufen (Get Profile)**. Speichern und Senden werden auf der Registerkarte **Nach "Profil abrufen" (After "Get Profile")** eingestellt (CSV-Speicherung, Senden an PDIndexer usw.).

Bei Bildsequenzen wählen Sie vor den Schritten 5–7 einen Frame unter [Bildsequenz (Sequential image)](3-tools.md) aus. Für eine azimutabhängige Analyse verwenden Sie **Azimutale Unterteilungsanalyse (Azimuthal Division Analysis)** im Dropdown-Menü von **Profil abrufen** (die Ringe werden in Sektoren geteilt und jeder Sektor wird integriert; nur bei konzentrischer Integration mit der Achse **Winkel (Angle)** (2θ) verfügbar) oder **Radiale Integration (Cake-Muster) (Radial integration (cake pattern))** in **Integraleigenschaft** (ein Azimut–Intensitäts-Profil).

Sind Kameralänge, Wellenlänge oder Verkippung unbekannt, kalibrieren Sie sie zuerst wie im nächsten Abschnitt beschrieben anhand des Bildes einer Standardprobe, übernehmen die Werte und integrieren erst dann die Probenbilder.

## Parameterbestimmung: Geometriekalibrierung mit einer Standardprobe (Doppelkassette)

Sind Kameralänge oder Wellenlänge unbekannt, optimieren Sie die geometrischen Parameter anhand der Beugungsringe eines Standardmaterials (standardmäßig CeO2 usw.) mit [Parameter finden (geometrisch)](3-tools.md).

1. Laden Sie das **Primärbild (Primary image)** (Standardprobe bei einer Kameralänge) mit **Öffnen (Open)**, suchen Sie das Zentrum und zeigen Sie die Peaks mit **Profil abrufen (Get Profile)** an.
2. Wenn Sie in der Profilansicht (Profile View) eine Beugungslinienmarke ziehen, wird die Schätzung der Kameralänge automatisch aktualisiert.
3. Laden Sie das **Sekundärbild (Secondary image)** (dieselbe Standardprobe bei einer anderen Kameralänge) auf dieselbe Weise und geben Sie die **Kameralängendifferenz** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) ein (z. B. +20, wenn Primary bei 100 mm und Secondary bei 120 mm liegt). Das Sekundärbild ist optional; die Kalibrierung funktioniert auch mit dem Primärbild allein.
4. Wählen Sie in der **Peak-Liste (Peak List)** die d-Werte von Peaks, die in beiden Bildern auftreten (normalerweise drei oder mehr pro Bild; bei zwei Bildern muss mindestens einer beiden gemeinsam sein. Sofern nicht nur die Kameralänge verfeinert wird, tut **Verfeinern! (Refine!)** bei weniger als drei Peaks nichts).
5. Wählen Sie die zu optimierenden Parameter (**Wellenlänge (Wave Length)**, **Kameralänge (Camera Length)**, **Neigungskorrektur (Tilt Correction)**, **Pixelgröße (Pixel Size)**, **Pixelverzerrung (Pixel Distortion)**, **Zentrumsposition (Center Position)**, **Kugelkorrektur (Spherical Correction)**).
6. Führen Sie **Verfeinern!** aus. Es stoppt automatisch nach der eingestellten Anzahl von Wiederholungen (standardmäßig 12). Übertragen Sie das Ergebnis nach der Prüfung mit **Verfeinerte Parameter => Hauptformular (Refined parameters => Main form)** in das Hauptformular.

!!! note
    Mit zwei Bildern (einer „Doppelkassette“) lassen sich Kameralänge und Wellenlänge leichter getrennt bestimmen.

## Parameterbestimmung: Brute-Force-Optimierung (Standardprobe)

Konvergiert die geometrische Optimierung schlecht, durchsuchen Sie Kameralänge, Zentrumsposition, Verkippung und optional die Wellenlänge erschöpfend mit [Parameter finden (Brute Force)](3-tools.md). Eine ausführliche Anleitung mit Bildschirmfotos finden Sie unter [Parameter finden (Brute Force)](6-find-parameter.md).

1. Laden Sie im Hauptformular ein Bild einer Standardprobe, öffnen Sie **Parameter finden (Brute Force) (Find parameter (brute force))** und wählen Sie den entsprechenden Standard.
2. Richten Sie die Zentrumsposition im Hauptformular grob aus (**Zentrum finden (Find Center)** hilft dabei).
3. Wählen Sie die zu optimierenden Größen und geben Sie die Schrittweite **Anfangsschritt (Initial step)** (um den aktuellen Wert zentriert) und die Anzahl der Schritte auf jeder Seite (**Suchbereich (Search range)**) ein. Bei einem Flachdetektor ist die Pixelgröße kein Suchziel. Zahlenbeispiele finden Sie unter [Parameter finden (Brute Force)](6-find-parameter.md).
4. Wird **Integralbereich (Integral Region)** auf einen Schlitzmodus (**Rechteck (Rectangle)**) mit schmaler Bandbreite gestellt, lässt sich das Rauschen unterdrücken.
5. Starten Sie die Suche mit **Optimieren (Optimize)**. In jedem Zyklus wird die Kombination mit dem kleinsten Bewertungswert R übernommen und automatisch in die Parameter des Hauptformulars geschrieben.

## Automatisierte Verarbeitung (Automatische Prozedur)

Bilder, die in einem Ordner eintreffen, werden automatisch verarbeitet, beispielsweise während eines Experiments. Einzelheiten finden Sie unter [Werkzeuge](3-tools.md).

1. Wählen Sie den Überwachungsordner mit **Festlegen (Set)**.
2. Filtern Sie bei Bedarf Dateien nach **Mustervergleich (Pattern matching)** (der Zahl am Ende des Dateinamens) oder nach **Stichwort (Keyword)**.
3. Aktivieren Sie **Nach dem Laden des neuen Bildes folgende Sequenz ausführen (Once the new image is loaded, perform the following sequence)** und wählen Sie aus der Liste: **Auto contrast** / **Find center** / **Mask spots** / **Get profile** / **Execute macro**.
4. Schalten Sie zuletzt **Neue Bilder automatisch laden (Automatically load new images)** ein, um die Überwachung zu starten (ohne Ordner lässt es sich nicht einschalten; verwendet werden die Nummern-/Stichwortbedingungen, die beim Start der Überwachung gelten). Die Abfolge läuft dann jedes Mal automatisch ab, wenn ein passendes Bild eintrifft. Eine Datei, die nach dem Warten auf den Schreibvorgang (etwa 50 s) noch gesperrt ist, wird bei späteren Durchläufen erneut versucht und 10 Minuten nach ihrem ersten Auffinden aufgegeben.

## Skriptgesteuerte Abläufe (Python-basierte Makros)

Verarbeitungen mit Schleifen und Bedingungen lassen sich als [Makro](5-macro/index.md) schreiben. Die Beispielmakros, die im Makro-Editor mit **Beispiele anzeigen (Show samples)** angezeigt werden, sind ein guter Ausgangspunkt.

- Ein Bild laden, Quelle und Detektor (Zentrum, Kameralänge, Pixel) einstellen und die Anzeige einpassen.
- Die Bedingungen der konzentrischen Integration (Start, Ende, Schritt, Einheit) einstellen, integrieren und als CSV speichern.
- Mehrere Dateien stapelweise verarbeiten und neben jedem Bild eine CSV-Datei speichern.
- Ein Multiframe-Bild Frame für Frame verarbeiten.
- Einen Debye-Ring in N Sektoren teilen und die Azimutabhängigkeit analysieren.
- Maskieren (alles löschen → Spots maskieren → Bereich des Primärstrahlfängers maskieren → Maske speichern) und integrieren.
- Mit radialer (Cake-)Integration Azimut gegen Intensität ausgeben.
- Das Senden über die Zwischenablage aktivieren, integrieren und in PDIndexer ein benanntes Makro aufrufen (z. B. Peak-Anpassung).

Selbst geschriebene Makros lassen sich speichern, über ihren Namen aufrufen und auch aus der automatischen Prozedur (Auto Procedure) heraus ausführen.
