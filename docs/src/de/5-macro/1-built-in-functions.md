<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

Die aus einem Makro aufrufbaren Methoden und Eigenschaften, gruppiert nach Namensraum unter dem `IPA`-Wurzelobjekt. Die Beschreibungen folgen der editorinternen Hilfe des Makro-Editors (`[Help]`-Attribute); die editorinterne Hilfe ist die maßgebliche, stets aktuelle Referenz.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Gibt den vollständigen Pfad zu einem Verzeichnis zurück. Wird `filename` weggelassen, öffnet sich ein Dialog zur Ordnerauswahl. |
| `GetFileName(message="")` | Öffnet einen Dateidialog und gibt den vollständigen Pfad der ausgewählten Datei zurück. |
| `GetFileNames(message="")` | Öffnet einen Mehrfachauswahl-Dialog und gibt die vollständigen Pfade als Zeichenketten-Array zurück. |
| `GetAllFileNames(message="")` | Wählt einen Ordner aus und gibt die vollständigen Pfade aller darin enthaltenen Dateien (rekursiv) als Array zurück. |
| `ReadImage(filename="", flag=None)` | Liest eine Bilddatei. Wird sie weggelassen, öffnet sich ein Auswahldialog. |
| `ReadImageHDF(filename, flag)` | Liest ein HDF5-Bild. `flag` schaltet die Normalisierung um. |
| `SaveImage(filename="")` | Speichert das aktuelle Bild (veralteter Alias; standardmäßig TIFF). |
| `SaveImageAsTIFF(filename="")` | Speichert das Bild als TIFF. |
| `SaveImageAsPNG(filename="")` | Speichert das Bild als PNG. |
| `SaveImageAsIPA(filename="")` | Speichert das Bild im IPA-Format. |
| `SaveImageAsCSV(filename="")` | Speichert das Bild als CSV. |
| `ReadParameter(filename="")` | Liest eine Parameterdatei. |
| `SaveParameter(filename="")` | Speichert die aktuellen Parameter. |
| `ReadMask(filename="")` | Liest eine Maskendatei. |
| `SaveMask(filename="")` | Speichert die aktuelle Maske. |

Bei allen Lese-/Speichermethoden öffnet das Weglassen oder die Angabe eines ungültigen Dateinamens einen Auswahldialog.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Setzt die Wellenlänge des einfallenden Strahls (in nm). |
| `WaveLength` | Setzt/liest die Wellenlänge (in nm). |
| `WaveSource` | Setzt/liest die Quelle als Ganzzahl. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Setzt die Röntgen-Wellenlängenlinie als Ganzzahl (nur Setter). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Setzt die Position des Zentrums (direkter Spot) (in Pixeln). |
| `SetCameraLength(length)` | Setzt die Kameralänge (in mm). |
| `CenterX` | Setzt/liest den X-Wert der Zentrumsposition (in Pixeln). |
| `CenterY` | Setzt/liest den Y-Wert der Zentrumsposition (in Pixeln). |
| `CameraLength` | Setzt/liest die Kameralänge (in mm). |
| `PixelSizeX` | Setzt/liest die Pixelgröße in X (Pixelbreite) (in mm). |
| `PixelSizeY` | Setzt/liest die Pixelgröße in Y (Pixelhöhe) (in mm). |
| `PixelKsi` | Setzt/liest die Pixelschrägung ξ (in Grad). |
| `TiltPhi` | Setzt/liest die Verkippung φ (in Grad). |
| `TiltTau` | Setzt/liest die Verkippung τ (in Grad). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Zeichnet das Bild mit negativem Verlauf (Gegenstück zu `PositiveGradient`). |
| `PositiveGradient` | True/False. Zeichnet das Bild mit positivem Verlauf (Gegenstück zu `NegativeGradient`). |
| `LinearScale` | True/False. Zeichnet mit linearer Skala (Gegenstück zu `LogScale`). |
| `LogScale` | True/False. Zeichnet mit logarithmischer Skala (Gegenstück zu `LinearScale`). |
| `GrayScale` | True/False. Zeichnet mit Graustufen (Gegenstück zu `ColorScale`). |
| `ColorScale` | True/False. Zeichnet mit Farbskala (Gegenstück zu `GrayScale`). |
| `Maximum` | Setzt/liest die maximale Helligkeitsstufe (float). |
| `Minimum` | Setzt/liest die minimale Helligkeitsstufe (float). |
| `CanvasMagnification` | Setzt/liest die Bildvergrößerung (float). |
| `SetCanvasCenter(x, y)` | Setzt die Position des Leinwandzentrums (in Pixeln). |
| `SetCanvasSize(width, height)` | Setzt die Größe der Leinwand (Picture Box) (in Pixeln). |
| `SetArea(top, bottom, left, right)` | Setzt den Leinwandbereich über die Grenzen oben/unten/links/rechts (in Pixeln). |
| `SetFullArea()` | Setzt den Leinwandbereich so, dass das gesamte Bild sichtbar ist. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Maskiert Spots (entspricht der Schaltfläche „Mask Spots“). |
| `ClearMask()` | Löscht die aktuellen Masken. |
| `InvertMask()` | Invertiert den aktuellen Maskenzustand. |
| `MaskAll()` | Maskiert den gesamten Bereich. |
| `MaskTop()` | Maskiert die obere Hälfte. |
| `MaskBottom()` | Maskiert die untere Hälfte. |
| `MaskLeft()` | Maskiert die linke Hälfte. |
| `MaskRight()` | Maskiert die rechte Hälfte. |
| `TakeOver` | Setzt/liest die Übernahme-Einstellung der Maske (Ganzzahl). 0: None, 1: aktuellen Maskenzustand übernehmen, 2: Maskendatei übernehmen. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Konzentrisch integrieren (2θ–Intensität). |
| `RadialIntegration` | True/False. Radial integrieren (Pizza-Schnitt). |
| `AzimuthalDivision` | True/False. Im Modus der azimutalen Unterteilung verarbeiten. |
| `AzimuthalDivisionNumber` | Ganzzahl. Setzt die Anzahl der Debye-Ring-Unterteilungen. |
| `FindCenterBeforeGetProfile` | True/False. Find Center vor Get Profile ausführen. |
| `MaskSpotsBeforeGetProfile` | True/False. Mask Spots vor Get Profile ausführen. |
| `SendProfileViaClipboard` | True/False. Das Profil über die Zwischenablage an PDIndexer senden. |
| `SaveProfileAfterGetProfile` | True/False. Das Profil nach Get Profile speichern. |
| `SaveProfileAsPDI` | True/False. Im PDI-Format speichern. |
| `SaveProfileAsCSV` | True/False. Im CSV-Format speichern. |
| `SaveProfileAsTSV` | True/False. Im TSV-Format speichern. |
| `SaveProfileAsGSAS` | True/False. Im GSAS-Format speichern. |
| `SaveProfileInOneFile` | True/False. Sequenzielle/azimutal unterteilte Profile in einer Datei speichern. |
| `SaveProfileAtImageDirectory` | True/False. Im selben Verzeichnis wie das Bild speichern. |
| `GetProfile(filename="")` | Führt die Eindimensionalisierung aus. Wird `filename` angegeben, wird das Profil in dieser Datei gespeichert. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Konzentrisch integrieren (2θ–Intensität). |
| `RadialIntegration` | True/False. Radial integrieren (Pizza-Schnitt / Cake-Muster). |
| `ConcentricStart` | Float. Startwert für die konzentrische Integration. |
| `ConcentricEnd` | Float. Endwert für die konzentrische Integration. |
| `ConcentricStep` | Float. Schrittwert für die konzentrische Integration. |
| `ConcentricUnit` | Ganzzahl. Einheit für die konzentrische Integration. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Donut-Radius für die radiale Integration. |
| `RadialWidgh` | Float. Donut-Breite für die radiale Integration. Hinweis: Das Member ist in der aktuellen Version `RadialWidgh` geschrieben. |
| `RadialStep` | Float. Sektorwinkel (Sweep-Schritt) für die radiale Integration. |
| `RadialUnit` | Ganzzahl. Einheit für die radiale Integration. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Liest, ob die aktuelle Datei ein sequenzielles Bild ist. |
| `Count` | Ganzzahl. Liest die Anzahl der Bilder. |
| `SelectedIndex` | Ganzzahl. Setzt/liest den ausgewählten Index (0-basiert). |
| `SelectedIndices` | Ganzzahl-Array. Setzt/liest die ausgewählten Indizes (für den Mehrfachauswahl-Modus). |
| `MultiSelection` | True/False. Setzt/liest den Mehrfachauswahl-Modus. |
| `Averaging` | True/False. Setzt/liest den Mittelungsmodus. |
| `SelectIndex(index)` | Setzt einen einzelnen ausgewählten Index (schaltet die Mehrfachauswahl aus). |
| `AppendIndex(index)` | Fügt der aktuellen Auswahl einen Index hinzu. |
| `SelectIndices(start, end)` | Setzt einen zusammenhängenden Bereich (start bis end, einschließlich). |
| `AppendIndices(start, end)` | Fügt der aktuellen Auswahl einen zusammenhängenden Bereich (start bis end, einschließlich) hinzu. |
| `Target_SelectedImages` | True/False. Macht die ausgewählten Bilder zum Ziel für Get Profile. |
| `Target_AllImages` | True/False. Macht alle Bilder zum Ziel für Get Profile. |
| `Target_TopmostImage` | True/False. Macht nur das oberste Bild zum Ziel für Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Das Makro auf PDIndexer schrittweise ausführen. |
| `Timeout` | Setzt/liest das Zeitlimit (Sekunden) für die Makrooperation (Standard 30 s). |
| `RunMacro(obj1, obj2, ...)` | Führt Makrocode auf PDIndexer aus. Die Parameter werden auf PDI als `Obj[1]`, `Obj[2]`, … gelesen. |
| `RunMacroName(name, obj1, obj2, ...)` | Führt das benannte Makro `name` auf PDIndexer aus. Die Parameter werden auf PDI als `Obj[1]`, `Obj[2]`, … gelesen. |
