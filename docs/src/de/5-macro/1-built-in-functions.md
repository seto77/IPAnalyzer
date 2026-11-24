<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Integrierte Funktionen

Die aus einem Makro aufrufbaren Methoden und Eigenschaften, gruppiert nach Namensräumen unterhalb des Wurzelobjekts `IPA`. Die Beschreibungen folgen der Hilfe im Makro-Editor (`[Help]`-Attribute); die Hilfe im Editor ist die maßgebliche, aktuelle Referenz.

## IPA.File

| Member | Beschreibung |
|------|------|
| `GetDirectoryPath(filename="")` | Gibt den vollständigen Pfad eines Verzeichnisses zurück. Wird `filename` weggelassen, öffnet sich ein Ordnerauswahldialog. |
| `GetFileName(message="")` | Öffnet einen Dateidialog und gibt den vollständigen Pfad der ausgewählten Datei zurück. |
| `GetFileNames(message="")` | Öffnet einen Dialog mit Mehrfachauswahl und gibt die vollständigen Pfade als String-Array zurück. |
| `GetAllFileNames(message="")` | Wählt einen Ordner aus und gibt die vollständigen Pfade aller darin enthaltenen Dateien (rekursiv) als Array zurück. |
| `ReadImage(filename="", flag=None)` | Liest eine Bilddatei. Wird sie weggelassen, öffnet sich ein Auswahldialog. |
| `ReadImageHDF(filename, flag)` | Liest ein HDF5-Bild. `flag` schaltet die Normierung um. In der aktuellen Version funktioniert das Lesen von HDF5 (`.h5`) nicht; NeXus-Dateien (`.nxs`) lassen sich mit `ReadImage(filename)` lesen. |
| `SaveImage(filename="")` | Speichert das aktuelle Bild (veralteter Alias; standardmäßig TIFF). |
| `SaveImageAsTIFF(filename="")` | Speichert das Bild als TIFF. |
| `SaveImageAsPNG(filename="")` | Speichert das Bild als PNG. |
| `SaveImageAsIPA(filename="")` | Speichert das Bild im IPA-Format. |
| `SaveImageAsCSV(filename="")` | Speichert das Bild als CSV. |
| `ReadParameter(filename="")` | Liest eine Parameterdatei. |
| `SaveParameter(filename="")` | Speichert die aktuellen Parameter. |
| `ReadMask(filename="")` | Liest eine Maskendatei. |
| `SaveMask(filename="")` | Speichert die aktuelle Maske. |

Bei allen Lese-/Speichermethoden öffnet sich ein Auswahldialog, wenn der Dateiname weggelassen wird oder ungültig ist.

## IPA.Wave

| Member | Beschreibung |
|------|------|
| `SetWaveLength(wavelength)` | Setzt die Wellenlänge des einfallenden Strahls (in nm). |
| `WaveLength` | Setzt/liefert die Wellenlänge (in nm). |
| `WaveSource` | Setzt/liefert die Quelle als Ganzzahl. 0: keine, 1: Röntgen, 2: Elektronen, 3: Neutronen. |
| `XrayLine` | Setzt die Röntgen-Wellenlängenlinie als Ganzzahl (nur Setter). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Beschreibung |
|------|------|
| `SetCenter(x, y)` | Setzt die Position des Zentrums (Direktstrahls) (in Pixeln). |
| `SetCameraLength(length)` | Setzt die Kameralänge (in mm). |
| `CenterX` | Setzt/liefert den X-Wert der Zentrumsposition (in Pixeln). |
| `CenterY` | Setzt/liefert den Y-Wert der Zentrumsposition (in Pixeln). |
| `CameraLength` | Setzt/liefert die Kameralänge (in mm). |
| `PixelSizeX` | Setzt/liefert die Pixelgröße in X (Pixelbreite) (in mm). |
| `PixelSizeY` | Setzt/liefert die Pixelgröße in Y (Pixelhöhe) (in mm). |
| `PixelKsi` | Setzt/liefert die Pixelscherung ξ (in Grad). |
| `TiltPhi` | Setzt/liefert die Verkippung φ (in Grad). |
| `TiltTau` | Setzt/liefert die Verkippung τ (in Grad). |

## IPA.Image

| Member | Beschreibung |
|------|------|
| `NegativeGradient` | True/False. Zeichnet das Bild mit negativem Gradienten (Gegenstück zu `PositiveGradient`). |
| `PositiveGradient` | True/False. Zeichnet das Bild mit positivem Gradienten (Gegenstück zu `NegativeGradient`). |
| `LinearScale` | True/False. Zeichnet mit linearer Skala (Gegenstück zu `LogScale`). |
| `LogScale` | True/False. Zeichnet mit logarithmischer Skala (Gegenstück zu `LinearScale`). |
| `GrayScale` | True/False. Zeichnet in Graustufen (Gegenstück zu `ColorScale`). |
| `ColorScale` | True/False. Zeichnet mit Farbskala (Gegenstück zu `GrayScale`). |
| `Maximum` | Setzt/liefert die maximale Helligkeitsstufe (Gleitkommazahl). |
| `Minimum` | Setzt/liefert die minimale Helligkeitsstufe (Gleitkommazahl). |
| `CanvasMagnification` | Setzt/liefert die Bildvergrößerung (Gleitkommazahl). |
| `SetCanvasCenter(x, y)` | Setzt die Mittelposition der Zeichenfläche (in Pixeln). |
| `SetCanvasSize(width, height)` | Setzt die Größe der Zeichenfläche (PictureBox) (in Pixeln). |
| `SetArea(top, bottom, left, right)` | Setzt den Bereich der Zeichenfläche über obere/untere/linke/rechte Grenze (in Pixeln). |
| `SetFullArea()` | Setzt den Bereich der Zeichenfläche so, dass das ganze Bild sichtbar ist. |

## IPA.Mask

| Member | Beschreibung |
|------|------|
| `MaskSpots()` | Maskiert Spots (wie die Schaltfläche „Spots maskieren“ (Mask Spots)). |
| `ClearMask()` | Löscht die aktuellen Masken. |
| `InvertMask()` | Kehrt den aktuellen Maskenzustand um. |
| `MaskAll()` | Maskiert den gesamten Bereich. |
| `MaskTop()` | Maskiert die obere Hälfte. |
| `MaskBottom()` | Maskiert die untere Hälfte. |
| `MaskLeft()` | Maskiert die linke Hälfte. |
| `MaskRight()` | Maskiert die rechte Hälfte. |
| `TakeOver` | Setzt/liefert die Einstellung zur Maskenübernahme (Ganzzahl). 0: keine, 1: aktuellen Maskenzustand übernehmen, 2: Maskendatei übernehmen. |

## IPA.Profile

| Member | Beschreibung |
|------|------|
| `ConcentricIntegration` | True/False. Konzentrisch integrieren (2θ–Intensität). |
| `RadialIntegration` | True/False. Radial integrieren (Tortenstück-Aufteilung). |
| `AzimuthalDivision` | True/False. Im Modus der azimutalen Unterteilung verarbeiten. |
| `AzimuthalDivisionNumber` | Ganzzahl. Setzt die Anzahl der Unterteilungen des Debye-Rings. |
| `FindCenterBeforeGetProfile` | True/False. Vor „Profil abrufen“ (Get Profile) „Zentrum finden“ (Find Center) ausführen. |
| `MaskSpotsBeforeGetProfile` | True/False. Vor „Profil abrufen“ (Get Profile) „Spots maskieren“ (Mask Spots) ausführen. |
| `SendProfileViaClipboard` | True/False. Das Profil über die Zwischenablage an PDIndexer senden. |
| `SaveProfileAfterGetProfile` | True/False. Das Profil nach „Profil abrufen“ (Get Profile) speichern. |
| `SaveProfileAsPDI` | True/False. Im PDI-Format speichern. |
| `SaveProfileAsCSV` | True/False. Im CSV-Format speichern. |
| `SaveProfileAsTSV` | True/False. Im TSV-Format speichern. |
| `SaveProfileAsGSAS` | True/False. Im GSAS-Format speichern. Nur bei konzentrischer Integration mit 2θ-Achse möglich; wird nicht geschrieben, wenn mehrere Profile in einer Datei gespeichert werden. |
| `SaveProfileInOneFile` | True/False. Profile von Bildsequenzen/azimutaler Unterteilung in einer Datei speichern. |
| `SaveProfileAtImageDirectory` | True/False. Im selben Verzeichnis wie das Bild speichern. |
| `GetProfile(filename="")` | Integriert das Bild zu einem 1D-Profil (wie **Profil abrufen (Get Profile)**). Wird `filename` angegeben, dient er als Basisname, an den die Formaterweiterung angehängt wird (z. B. ergibt `GetProfile("sample.stl")` beim Speichern als CSV `sample.stl.csv`). Ist als Ziel „jedes Mal wählen“ eingestellt, wird der Speicherdialog angezeigt. |

## IPA.IntegralProperty

| Member | Beschreibung |
|------|------|
| `ConcentricIntegration` | True/False. Konzentrisch integrieren (2θ–Intensität). |
| `RadialIntegration` | True/False. Radial integrieren (Tortenstück-Aufteilung / Cake-Muster). |
| `ConcentricStart` | Gleitkommazahl. Startwert der konzentrischen Integration. |
| `ConcentricEnd` | Gleitkommazahl. Endwert der konzentrischen Integration. |
| `ConcentricStep` | Gleitkommazahl. Schrittweite der konzentrischen Integration. |
| `ConcentricUnit` | Ganzzahl. Einheit der konzentrischen Integration. 0: Winkel (Grad), 1: d-Wert (Å), 2: Länge (mm). |
| `RadialRadius` | Gleitkommazahl. Donut-Radius der radialen Integration. |
| `RadialWidgh` | Gleitkommazahl. Donut-Breite der radialen Integration. Hinweis: Der Member heißt in der aktuellen Version `RadialWidgh`. |
| `RadialStep` | Gleitkommazahl. Sektorwinkel (Sweep-Schritt) der radialen Integration. |
| `RadialUnit` | Ganzzahl. Einheit der radialen Integration. 0: Winkel (Grad), 1: d-Wert (Å). |

## IPA.Sequential

| Member | Beschreibung |
|------|------|
| `SequentialImageMode` | True/False. Liefert, ob die aktuelle Datei eine Bildsequenz ist. |
| `Count` | Ganzzahl. Liefert die Anzahl der Bilder. |
| `SelectedIndex` | Ganzzahl. Setzt/liefert den ausgewählten Index (0-basiert). |
| `SelectedIndices` | Ganzzahl-Array. Setzt/liefert die ausgewählten Indizes (für den Mehrfachauswahlmodus). |
| `MultiSelection` | True/False. Setzt/liefert den Mehrfachauswahlmodus. |
| `Averaging` | True/False. Setzt/liefert den Mittelungsmodus. |
| `SelectIndex(index)` | Setzt einen einzelnen ausgewählten Index (schaltet die Mehrfachauswahl aus). |
| `AppendIndex(index)` | Fügt der aktuellen Auswahl einen Index hinzu. |
| `SelectIndices(start, end)` | Setzt einen zusammenhängenden Bereich (start bis end, einschließlich). |
| `AppendIndices(start, end)` | Fügt der aktuellen Auswahl einen zusammenhängenden Bereich (start bis end, einschließlich) hinzu. |
| `Target_SelectedImages` | True/False. Die ausgewählten Bilder zum Ziel von „Profil abrufen“ (Get Profile) machen. |
| `Target_AllImages` | True/False. Alle Bilder zum Ziel von „Profil abrufen“ (Get Profile) machen. |
| `Target_TopmostImage` | True/False. Nur das oberste Bild zum Ziel von „Profil abrufen“ (Get Profile) machen. |

## IPA.PDI

| Member | Beschreibung |
|------|------|
| `Debug` | True/False. Das Makro in PDIndexer schrittweise ausführen. |
| `Timeout` | Setzt/liefert das Zeitlimit (Sekunden) für die Makro-Operation (Standard 30 s). |
| `RunMacro(obj1, obj2, ...)` | Führt den Code aus, der gerade im Makro-Editor von PDIndexer geöffnet ist. Die Parameter werden in PDIndexer als `PDI.Obj[0]`, `PDI.Obj[1]`, … gelesen. |
| `RunMacroName(name, obj1, obj2, ...)` | Führt das in PDIndexer unter `name` gespeicherte Makro aus. Die Parameter werden in PDIndexer als `PDI.Obj[0]`, `PDI.Obj[1]`, … gelesen. |
