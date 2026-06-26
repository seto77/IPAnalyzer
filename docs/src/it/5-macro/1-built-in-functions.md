<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Funzioni integrate

I metodi e le proprietà richiamabili da una macro, raggruppati per namespace sotto l'oggetto radice `IPA`. Le descrizioni seguono la guida interna all'editor di macro (attributi `[Help]`); la guida interna all'editor è il riferimento autorevole e aggiornato.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Restituisce il percorso completo di una cartella. Se `filename` viene omesso, si apre una finestra di dialogo per la selezione della cartella. |
| `GetFileName(message="")` | Apre una finestra di dialogo file e restituisce il percorso completo del file selezionato. |
| `GetFileNames(message="")` | Apre una finestra di dialogo a selezione multipla e restituisce i percorsi completi come array di stringhe. |
| `GetAllFileNames(message="")` | Seleziona una cartella e restituisce i percorsi completi di tutti i file in essa contenuti (in modo ricorsivo) come array. |
| `ReadImage(filename="", flag=None)` | Legge un file immagine. Se omesso, si apre una finestra di dialogo di selezione. |
| `ReadImageHDF(filename, flag)` | Legge un'immagine HDF5. `flag` attiva/disattiva la normalizzazione. |
| `SaveImage(filename="")` | Salva l'immagine corrente (alias legacy; per impostazione predefinita TIFF). |
| `SaveImageAsTIFF(filename="")` | Salva l'immagine come TIFF. |
| `SaveImageAsPNG(filename="")` | Salva l'immagine come PNG. |
| `SaveImageAsIPA(filename="")` | Salva l'immagine in formato IPA. |
| `SaveImageAsCSV(filename="")` | Salva l'immagine come CSV. |
| `ReadParameter(filename="")` | Legge un file di parametri. |
| `SaveParameter(filename="")` | Salva i parametri correnti. |
| `ReadMask(filename="")` | Legge un file di maschera. |
| `SaveMask(filename="")` | Salva la maschera corrente. |

Per tutti i metodi di lettura/salvataggio, omettere o fornire un nome di file non valido apre una finestra di dialogo di selezione.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Imposta la lunghezza d'onda del fascio incidente (in nm). |
| `WaveLength` | Imposta/legge la lunghezza d'onda (in nm). |
| `WaveSource` | Imposta/legge la sorgente come intero. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Imposta la linea di lunghezza d'onda dei raggi X come intero (solo setter). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Imposta la posizione del centro (spot diretto) (in pixel). |
| `SetCameraLength(length)` | Imposta la lunghezza di camera (in mm). |
| `CenterX` | Imposta/legge il valore X della posizione del centro (in pixel). |
| `CenterY` | Imposta/legge il valore Y della posizione del centro (in pixel). |
| `CameraLength` | Imposta/legge la lunghezza di camera (in mm). |
| `PixelSizeX` | Imposta/legge la dimensione X del pixel (larghezza del pixel) (in mm). |
| `PixelSizeY` | Imposta/legge la dimensione Y del pixel (altezza del pixel) (in mm). |
| `PixelKsi` | Imposta/legge lo skew del pixel ξ (in gradi). |
| `TiltPhi` | Imposta/legge l'inclinazione φ (in gradi). |
| `TiltTau` | Imposta/legge l'inclinazione τ (in gradi). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Disegna l'immagine con un gradiente negativo (controparte di `PositiveGradient`). |
| `PositiveGradient` | True/False. Disegna l'immagine con un gradiente positivo (controparte di `NegativeGradient`). |
| `LinearScale` | True/False. Disegna con scala lineare (controparte di `LogScale`). |
| `LogScale` | True/False. Disegna con scala logaritmica (controparte di `LinearScale`). |
| `GrayScale` | True/False. Disegna in scala di grigi (controparte di `ColorScale`). |
| `ColorScale` | True/False. Disegna con scala a colori (controparte di `GrayScale`). |
| `Maximum` | Imposta/legge il livello massimo di luminosità (float). |
| `Minimum` | Imposta/legge il livello minimo di luminosità (float). |
| `CanvasMagnification` | Imposta/legge l'ingrandimento dell'immagine (float). |
| `SetCanvasCenter(x, y)` | Imposta la posizione del centro della tela (in pixel). |
| `SetCanvasSize(width, height)` | Imposta la dimensione della tela (picture box) (in pixel). |
| `SetArea(top, bottom, left, right)` | Imposta l'area della tela tramite i limiti superiore/inferiore/sinistro/destro (in pixel). |
| `SetFullArea()` | Imposta l'area della tela in modo che l'intera immagine sia visibile. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Maschera gli spot (come il pulsante "Mask Spots"). |
| `ClearMask()` | Cancella le maschere correnti. |
| `InvertMask()` | Inverte lo stato corrente della maschera. |
| `MaskAll()` | Maschera l'intera area. |
| `MaskTop()` | Maschera la metà superiore. |
| `MaskBottom()` | Maschera la metà inferiore. |
| `MaskLeft()` | Maschera la metà sinistra. |
| `MaskRight()` | Maschera la metà destra. |
| `TakeOver` | Imposta/legge l'impostazione di ereditarietà della maschera (intero). 0: None, 1: eredita lo stato corrente della maschera, 2: eredita il file di maschera. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra in modo concentrico (2θ–intensità). |
| `RadialIntegration` | True/False. Integra in modo radiale (taglio a pizza). |
| `AzimuthalDivision` | True/False. Elabora in modalità a divisione azimutale. |
| `AzimuthalDivisionNumber` | Intero. Imposta il numero di divisioni dell'anello di Debye. |
| `FindCenterBeforeGetProfile` | True/False. Esegue Find Center prima di Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Esegue Mask Spots prima di Get Profile. |
| `SendProfileViaClipboard` | True/False. Invia il profilo a PDIndexer tramite gli appunti. |
| `SaveProfileAfterGetProfile` | True/False. Salva il profilo dopo Get Profile. |
| `SaveProfileAsPDI` | True/False. Salva in formato PDI. |
| `SaveProfileAsCSV` | True/False. Salva in formato CSV. |
| `SaveProfileAsTSV` | True/False. Salva in formato TSV. |
| `SaveProfileAsGSAS` | True/False. Salva in formato GSAS. |
| `SaveProfileInOneFile` | True/False. Salva i profili sequenziali/a divisione azimutale in un unico file. |
| `SaveProfileAtImageDirectory` | True/False. Salva nella stessa cartella dell'immagine. |
| `GetProfile(filename="")` | Esegue la monodimensionalizzazione. Se viene fornito `filename`, il profilo viene salvato in quel file. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra in modo concentrico (2θ–intensità). |
| `RadialIntegration` | True/False. Integra in modo radiale (taglio a pizza / pattern cake). |
| `ConcentricStart` | Float. Valore iniziale per l'integrazione concentrica. |
| `ConcentricEnd` | Float. Valore finale per l'integrazione concentrica. |
| `ConcentricStep` | Float. Valore del passo per l'integrazione concentrica. |
| `ConcentricUnit` | Intero. Unità per l'integrazione concentrica. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Raggio della ciambella per l'integrazione radiale. |
| `RadialWidgh` | Float. Larghezza della ciambella per l'integrazione radiale. Nota: nella versione corrente il membro è scritto `RadialWidgh`. |
| `RadialStep` | Float. Angolo del settore (passo di spazzamento) per l'integrazione radiale. |
| `RadialUnit` | Intero. Unità per l'integrazione radiale. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Restituisce se il file corrente è un'immagine sequenziale. |
| `Count` | Intero. Restituisce il numero di immagini. |
| `SelectedIndex` | Intero. Imposta/legge l'indice selezionato (in base 0). |
| `SelectedIndices` | Array di interi. Imposta/legge gli indici selezionati (per la modalità a selezione multipla). |
| `MultiSelection` | True/False. Imposta/legge la modalità a selezione multipla. |
| `Averaging` | True/False. Imposta/legge la modalità di media. |
| `SelectIndex(index)` | Imposta un singolo indice selezionato (disattiva la selezione multipla). |
| `AppendIndex(index)` | Aggiunge un indice alla selezione corrente. |
| `SelectIndices(start, end)` | Imposta un intervallo contiguo (da start a end, estremi inclusi). |
| `AppendIndices(start, end)` | Aggiunge un intervallo contiguo (da start a end, estremi inclusi) alla selezione corrente. |
| `Target_SelectedImages` | True/False. Rende le immagini selezionate il bersaglio di Get Profile. |
| `Target_AllImages` | True/False. Rende tutte le immagini il bersaglio di Get Profile. |
| `Target_TopmostImage` | True/False. Rende solo l'immagine più in alto il bersaglio di Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Esegue la macro su PDIndexer passo dopo passo. |
| `Timeout` | Imposta/legge il timeout (secondi) per l'operazione della macro (predefinito 30 s). |
| `RunMacro(obj1, obj2, ...)` | Esegue codice macro su PDIndexer. I parametri vengono letti su PDI come `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Esegue la macro denominata `name` su PDIndexer. I parametri vengono letti su PDI come `Obj[1]`, `Obj[2]`, … |
