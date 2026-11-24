<!-- 261124Cl: Retranslated from en/7-qa.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Fragen und Antworten (häufig gestellte Fragen)

Diese Seite sammelt die am häufigsten gestellten Fragen und Punkte, die leicht missverstanden werden. Die Beschriftungen sind die Anzeigenamen der deutschen Oberfläche; in Klammern steht jeweils der englische Name. Für Fragen, die hier nicht behandelt werden, oder um einen Fehler zu melden, nutzen Sie bitte [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Installation und Start

### Nur das Eigenschaftsfenster erscheint; das Hauptfenster ist nicht zu sehen

Das Hauptfenster liegt außerhalb des Bildschirms.

1. Bewegen Sie den Mauszeiger über das IPAnalyzer-Symbol in der Taskleiste, klicken Sie mit der rechten Maustaste auf die Miniaturansicht, wählen Sie **Verschieben (Move)**, drücken Sie einmal eine Pfeiltaste und bewegen Sie dann die Maus.
2. Hilft das nicht, beenden Sie IPAnalyzer, öffnen den Registrierungs-Editor (regedit), löschen `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer` und starten IPAnalyzer erneut (alle Einstellungen werden auf die Standardwerte zurückgesetzt).

### Nach dem Update läuft noch die alte Version / IPAnalyzer startet nicht mehr

Installieren Sie IPAnalyzer direkt aus dem [neuesten Release](https://github.com/seto77/IPAnalyzer/releases/latest) neu. Überschreibt die Installation die alte Version nicht oder startet das Programm nicht, deinstallieren Sie es einmal über die Windows-Einstellungen und installieren Sie es dann erneut. Hat eine neue Version ein Problem, können Sie von derselben Release-Seite eine ältere Version installieren.

### Ich möchte es auf einem PC ohne Administratorrechte oder unter Windows on Arm verwenden

- Ohne Administratorrechte verwenden Sie die portable Version (`IPAnalyzer-v.<version>.zip`), die keine Installation benötigt und die .NET-Laufzeit enthält.
- Unter Windows on Arm verwenden Sie den arm64-Installer (`IPAnalyzer-setup_arm64.msi`) oder die portable Version (`IPAnalyzer-v.<version>_arm64.zip`).

Einzelheiten finden Sie unter [Installation im Überblick](0-overview.md#installation).

### Beim Laden vieler Frames tritt ein Fehler auf. Wie viel Arbeitsspeicher wird benötigt?

IPAnalyzer hält die Intensität jedes Pixels unabhängig von der ursprünglichen Bittiefe in doppelter Genauigkeit (8 Byte). So benötigen beispielsweise 5000 Bilder mit 1554×516 Pixeln allein für die Intensitäten etwa 32 GB. Verarbeiten Sie Daten mit vielen Frames auf einem PC mit ausreichend Arbeitsspeicher oder teilweise mit einem Makro.

## Bilder einlesen

### Die Dateien meines Detektors lassen sich nicht einlesen

Das Format wird möglicherweise noch nicht unterstützt. Bitte wenden Sie sich über [Issues](https://github.com/seto77/IPAnalyzer/issues) oder an den Autor und schicken Sie eine echte Datei mit (möglichst eine mit Beugungsmuster, nicht nur ein Dunkelbild). Die Richtigkeit der Intensitäten und die Orientierung des Bildes lassen sich nur an einem Bild prüfen, das ein Muster zeigt. Schlägt das Laden fehl, bleibt das zuvor geladene Bild erhalten, sodass Sie damit weiterarbeiten können.

!!! note "Wenn ein Rohbild falsche Breite und Höhe hat"
    Bei Rohdateien ohne Header werden Detektormodell und Pixelzahl aus der Dateigröße abgeleitet. Die tatsächliche Pixelzahl weicht oft vom Katalogwert ab; schicken Sie die Datei daher bitte ein, wenn die Erkennung fehlschlägt.

### Nach dem Laden einer Parameterdatei und dem anschließenden Öffnen eines Bildes ändern sich die Parameter

IPAnalyzer **merkt sich Parameter wie Kameralänge, Wellenlänge und Pixelgröße für jedes Bildformat** und wechselt beim Öffnen eines Bildes zu diesen Werten. Laden Sie die Parameterdatei (`.prm`) daher **nach dem Öffnen des Bildes**. Formate mit unterschiedlichen Dateierweiterungen werden getrennt gespeichert, auch wenn ihr Inhalt gleich ist.

### Muss ich jedes Bild erneut spiegeln oder drehen?

Nein. Die Einstellungen unter **Optionen → Spiegeln / Drehen (Option → Flip / Rotate)** werden ebenfalls pro Bildformat gespeichert und beim nächsten Öffnen eines Bildes desselben Formats automatisch angewendet. Spiegeln und Drehen wirken sich auch auf die Integration und das Speichern von Bildern aus (die Quelldatei wird nicht verändert).

### Wie werden Dateien mit mehreren Frames (`.his`, `.nxs`, mehrseitige TIFF-Dateien, …) behandelt?

Wird eine solche Datei geladen, öffnet sich das Fenster **Bildsequenz (Sequential image)**, in dem Sie den anzuzeigenden Frame auswählen können. Um die Frames gemeinsam zu integrieren, verwenden Sie **Profile für alle Sequenzbilder abrufen (Get Profiles for all sequential images)** oder **Profile für ausgewählte Bilder abrufen (Get Profiles for selected images)** im Dropdown-Menü von **Profil abrufen (Get Profile)**. Einzelheiten finden Sie unter [Werkzeuge](3-tools.md#bildsequenz-sequential-image).

## Kalibrierung

### Wann verwende ich Parameter finden (geometrisch) und wann Parameter finden (Brute Force)?

| | Geometrisch | Brute Force |
|---|---|---|
| Prinzip | Teilt das Bild in Sektoren, bestimmt die Peakpositionen und ermittelt Zentrum, Verkippung usw. aus den elliptischen Formen und Zentren der Debye-Ringe | Variiert die Parameter schrittweise und sucht die Kombination, bei der berechnete und angepasste Peakpositionen am besten übereinstimmen |
| Geeignete Daten | Ringe, die fast ringsum sichtbar sind (in mindestens fünf Richtungen) | Nur Teile der Ringe aufgezeichnet, Direktstrahl außerhalb des Bildes, fleckige Ringe |
| Bilder | Eines oder zwei, bei unterschiedlichen Kameralängen aufgenommen | Eines |
| Vorsicht | Die Genauigkeit sinkt oder die Verfeinerung konvergiert nicht, wenn die Ringe nicht ringsum sichtbar sind | Benötigt recht gute Startwerte; braucht Zeit |

Die Schritte finden Sie unter [Arbeitsabläufe](4-procedures.md) und [Parameter finden (Brute Force)](6-find-parameter.md).

### Welche Standardprobe sollte ich für die Kalibrierung verwenden?

Geeignet ist eine Probe, die aus feinen Körnern glatte (nicht fleckige) Debye-Ringe ergibt, die möglichst vollständig rund sichtbar sind. Etwa fünf oder mehr Ringe sind ein Richtwert. Mit nur zwei vollständigen Ringen ist eine präzise Bestimmung schwierig, und entweder die Wellenlänge oder die Kameralänge sollte bekannt sein. Für die Brute-Force-Kalibrierung wählen Sie den Standard aus Au / CeO₂ / LaB₆ / Al₂O₃ oder wählen **Andere (Other)** und geben die Gitterkonstanten ein.

### Die Kalibrierung konvergiert nicht / das Zentrum driftet immer weiter

- Fixieren Sie die Werte, denen Sie vertrauen können (Katalogwert der Pixelgröße, bekannte Wellenlänge usw.), und verringern Sie die Zahl der verfeinerten Variablen.
- Passen Sie zunächst grob mit einigen Ringen bei kleinen Winkeln an und fügen Sie dann die Ringe bei großen Winkeln hinzu.
- Ein Ring, dessen Analyse fehlgeschlagen ist, kann das gesamte Ergebnis stören. Liegt im Diagramm der Ringzentren ein Ring abseits, entfernen Sie ihn.
- Schlägt die Anpassung fehl, sobald Ringe bei großen Winkeln einbezogen werden, beschränken Sie die Peaks auf solche, deren Ringe noch ringsum sichtbar sind, vergrößern Sie den Anpassungsbereich und verwenden Sie weniger Sektoren.
- Geben Sie vor dem Start möglichst korrekte Startwerte ein.

### Lassen sich Kameralänge und Wellenlänge nur bestimmen, wenn eine der beiden fixiert ist?

Mit einem Standard, dessen Gitterkonstanten genau bekannt sind, lassen sich beide sogar aus einem einzigen Bild bestimmen (aus den Verhältnissen der Ringpositionen). Jedoch **lassen sich Kameralänge und Pixelgröße nicht gemeinsam aus einem einzigen Bild bestimmen**. Vertrauen Sie dem Katalogwert der Pixelgröße und fixieren Sie ihn. Mit zwei Bildern, deren Kameralängendifferenz bekannt ist (Doppelkassetten-Methode), lässt sich auch die Pixelgröße verfeinern.

### Der Direktstrahl ist nicht aufgezeichnet / liegt außerhalb des Bildes

Geben Sie die Position des Direktstrahls von Hand ein und deaktivieren Sie **Zentrum vor Profilabruf finden (Find Center before Get Profile)** im Dropdown-Menü von **Profil abrufen (Get Profile)**. Liegt der Spot außerhalb des Bildes, sind negative Koordinaten zulässig. Verwenden Sie für solche Daten die Brute-Force-Kalibrierung.

### Das mit „Zentrum finden“ ermittelte Zentrum weicht um einige Pixel vom kalibrierten Zentrum ab

Die beiden werden unterschiedlich bestimmt. **Zentrum finden (Find Center)** passt den Direktstrahl in der Nähe des aktuellen Zentrums mit einer zweidimensionalen Pseudo-Voigt-Funktion an. Die Kalibrierung verwendet die Intensität des Direktstrahls nicht; sie leitet das Zentrum aus den Ellipsenzentren mehrerer Debye-Ringe ab. Ist die Verkippung korrekt bestimmt, kann das kalibrierte Zentrum unverändert verwendet werden. Ist der Direktstrahl gesättigt, zeigen Sie mit **Ring zeichnen (Draw ring)** einen Kreis auf einem Debye-Ring an und klicken auf **Zentrum finden**: Das Zentrum wird dann aus dem Ring bestimmt.

### Was ist die sphärische Korrektur?

Eine Korrektur für einen Detektor, der kugelförmig gekrümmt ist. Geben Sie den Kehrwert des Krümmungsradius 1/R in m⁻¹ ein (auf dem Bildschirm als /m angezeigt). Für einen Flachdetektor verwenden Sie 0. Sie hilft, wenn die Ringe bei großen Winkeln nicht übereinstimmen, etwa bei einem großen Detektor dicht an der Probe.

### Wie rechne ich Verkippungswerte aus anderer Software (etwa PIP) um?

PIPs (β, Φ) entspricht IPAnalyzers (φ, τ) = (270° − β, Φ). Die Definitionen finden Sie im [Überblick](0-overview.md#beziehung-zu-winpip).

## Integration und Ausgabe

### Die horizontale Achse des Ergebnisses sieht falsch aus / die Intensität wirkt nahezu konstant

Prüfen Sie, ob auf der Registerkarte **Integraleigenschaft (Integral Property)** des Eigenschaftsfensters **Radiale Integration (Cake-Muster) (Radial integration (cake pattern))** ausgewählt ist. In diesem Modus hat das Profil den Azimut χ als horizontale Achse. Das übliche 2θ–Intensitätsprofil erhalten Sie mit **Konzentrische Integration (streuwinkeldispersiv) (Concentric integration (scattering angle dispersive))**.

### Ich möchte das Profil ohne PDIndexer in einer Datei speichern

Stellen Sie auf der Registerkarte **Nach "Profil abrufen" (After "Get Profile")** des Eigenschaftsfensters unter **Profil speichern (Save Profiles)** das Ziel (gleicher Ordner wie das Bild / jedes Mal wählen) und das Format (PDI / CSV / TSV / GSAS) ein. Das Profil wird dann bei jeder Integration gespeichert.

### Was steht in der dritten Spalte der CSV-Datei?

Der Zählfehler der Intensität, berechnet aus der Quadratwurzel der in jedem Schritt summierten Pixelintensität, die als Zählereignisse behandelt wird. Die Intensität in der zweiten Spalte ist in das Äquivalent der Bragg–Brentano-Geometrie umgerechnet und entspricht daher nicht dem Quadrat der dritten Spalte. PDIndexer kann sie als Fehlerbalken anzeigen.

### Die 2θ-Werte in der CSV-Datei haben nur zwei Nachkommastellen. Ist das die Genauigkeitsgrenze?

Nein. Das sieht nur so aus, weil die Integration beispielsweise mit einem Start von 20,00° und einem Schritt von 0,01° eingerichtet wurde. Gerechnet wird in doppelter Genauigkeit. Die Genauigkeit des Ergebnisses wird durch die Fehler der Eingabeparameter wie Kameralänge und Wellenlänge bestimmt.

### Soll ich bei Bildsequenzen Mittelwert oder Summierung verwenden?

Das Signal-Rausch-Verhältnis ist in beiden Fällen gleich. **Summierung (Summation)** liefert eine korrekte Schätzung der Fehler und wird daher für Analysen empfohlen, die die Fehler verwenden, etwa die Rietveld-Verfeinerung.

### Ich möchte für jeden Azimut (jeden Sektor) integrieren

Schalten Sie **Azimutale Unterteilungsanalyse (Azimuthal Division Analysis)** im Dropdown-Menü von **Profil abrufen (Get Profile)** ein, stellen Sie **Anzahl der Unterteilungen (Number of divisions)** ein und integrieren Sie. Es entstehen ein Gesamtprofil (Name endet auf `-whole`) und je ein Profil pro Sektor (mit angehängtem Startwinkel, etwa `-000`, `-010`, …). Dies funktioniert nur mit **Konzentrische Integration (streuwinkeldispersiv) (Concentric integration (scattering angle dispersive))** und der Achse **Winkel (Angle)** (2θ); bei radialer Integration oder einer d-Wert-Achse erscheint eine Warnung und es wird nichts ausgeführt. Bei zu vielen Unterteilungen können die an PDIndexer gesendeten Daten zu groß werden.

### Ich möchte eine zweidimensionale Karte aus 2θ und Azimut χ (abgewickeltes Bild)

Verwenden Sie **Bild abrollen (Unroll image)** in der Symbolleiste. Bereich und Schrittweite stellen Sie auf der Registerkarte **Abgewickeltes Bild – Optionen (Unrolled Image Option)** des Eigenschaftsfensters ein. Mit **Datei → Bild speichern (File → Save image)** behält TIFF die berechneten Gleitkommawerte, und PNG speichert, was auf dem Bildschirm angezeigt wird.

### Ich möchte die Summe oder den Mittelwert der Intensität in einem rechteckigen Bildausschnitt

Wählen Sie im Bild durch Strg + Rechts ziehen ein Rechteck aus. Die Statistik erscheint unten auf der Registerkarte **Statistische Information (Statistical Information)**. Bei Bildsequenzen lässt sich derselbe Bereich über die Frames hinweg vergleichen.

### Ein Dunkelbild wird zu den Rändern bei großen Winkeln hin heller

Ist im Eigenschaftsfenster unter **Wellenquelle (Wave source)** die Option **Lineare Polarisation korrigieren (d. h. linear polarisiert → unpolarisiert) (Correct linear polarization (i.e., linear polarized → unpolarized))** eingeschaltet, wird die Korrektur auch auf Signale angewendet, die nicht von Röntgenstrahlen stammen (Dunkelstrom, elektronisches Rauschen), und die Seite bei großen Winkeln wird heller. Schalten Sie sie für Dunkelbilder aus.

### Ich möchte ein Dunkelbild (Hintergrund) abziehen

Registrieren Sie auf der Registerkarte **Hintergrundoptionen (Background Option)** des Eigenschaftsfensters das aktuelle Bild als Hintergrund und stellen Sie den Koeffizienten ein. Von da an wird es automatisch von Bildern gleicher Größe abgezogen. Einzelheiten finden Sie unter [Eigenschaftsfenster](2-property-windows.md).

## Stapelverarbeitung und Makros

### Ich möchte viele Dateien auf einmal integrieren

**Profile für alle Sequenzbilder abrufen (Get Profiles for all sequential images)** ist für mehrere Frames in einer Datei gedacht. Um mehrere Dateien zu verarbeiten, verwenden Sie ein [Makro](5-macro/index.md). Die [Beispiele](5-macro/2-examples.md) enthalten eines, das die ausgewählten Dateien nacheinander integriert und CSV-Dateien speichert. Öffnen Sie vor der Ausführung ein Bild und laden Sie die Parameterdatei (siehe [das Parametergedächtnis](#nach-dem-laden-einer-parameterdatei-und-dem-anschließenden-öffnen-eines-bildes-ändern-sich-die-parameter)).

### Ich möchte ein häufig verwendetes Makro aus dem Menü aufrufen

Geben Sie dem Makro einen Namen und fügen Sie es im Makro-Editor hinzu; es lässt sich dann über das Menü **Makro (Macro)** des Hauptfensters aufrufen.

### Ich möchte Bilder während einer Messung integrieren, sobald sie eintreffen

Überwachen Sie den Ordner mit der [Automatischen Prozedur (Auto procedure)](3-tools.md#automatische-prozedur-auto-procedure). Dateien, die noch geschrieben werden, werden nach Abschluss des Schreibvorgangs eingelesen; eine Datei, die nach etwa 50 s noch gesperrt ist, wird bei späteren Durchläufen erneut versucht und 10 Minuten nach ihrem ersten Auffinden aufgegeben. Schlägt das Einlesen bei einem Netzwerkordner fehl, speichern Sie auf die lokale Festplatte des Mess-PCs und überwachen Sie diesen Ordner.

## Einen Fehler melden

### Was sollte ich mit einer Fehlermeldung mitschicken?

Das Problem lässt sich in der Umgebung des Autors oft nicht reproduzieren; fügen Sie daher bitte Folgendes bei:

- die damals verwendete Parameterdatei (**Datei → Parameter speichern (File → Save parameter)**),
- die Bilddatei, bei der das Problem aufgetreten ist, und
- die Fehlermeldung (ein Bildschirmfoto genügt) sowie die IPAnalyzer-Version.

Bitte melden Sie Fehler über [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Häufige Missverständnisse

| Annahme | Tatsächlich |
|---|---|
| Erst die Parameterdatei laden, dann das Bild öffnen | Beim Öffnen eines Bildes wird zu den für sein Format gespeicherten Werten gewechselt. Öffnen Sie zuerst das Bild, dann laden Sie die Parameterdatei |
| **Profile für alle Sequenzbilder abrufen (Get Profiles for all sequential images)** verarbeitet mehrere Dateien auf einmal | Es ist für mehrere Frames in einer Datei gedacht. Für mehrere Dateien verwenden Sie ein Makro |
| Zum Speichern eines Profils wird PDIndexer benötigt | IPAnalyzer kann allein in eine Datei speichern (Registerkarte Nach "Profil abrufen" (After "Get Profile")) |
| Die dritte CSV-Spalte ist ein weiteres Profil | Sie ist der Zählfehler der Intensität |
| Summierung verbessert das Signal-Rausch-Verhältnis | Das Signal-Rausch-Verhältnis ist dasselbe wie beim Mittelwert; nur die Fehlerschätzung unterscheidet sich |
| Kameralänge und Pixelgröße lassen sich beide aus einem Bild bestimmen | Nicht gemeinsam aus einem Bild; fixieren Sie die Pixelgröße auf ihren Katalogwert |
| Spiegeln und Drehen ändern nur die Anzeige | Sie wirken sich auch auf die Integration und das Speichern von Bildern aus |
| Beim Senden an PDIndexer wird das Profil einer Lorentz-Polarisations-Korrektur unterzogen | PDIndexer berücksichtigt die Polarisation nur für die Intensitäten der berechneten Beugungslinien; das Profil selbst wird nicht verändert |
