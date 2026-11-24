<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Funzioni integrate

I metodi e le proprietà richiamabili da una macro, raggruppati per spazio dei nomi sotto l'oggetto radice `IPA`. Le descrizioni seguono la guida integrata nell'editor delle macro (attributi `[Help]`); la guida nell'editor è il riferimento autorevole e aggiornato.

## IPA.File

| Membro | Descrizione |
|------|------|
| `GetDirectoryPath(filename="")` | Restituisce il percorso completo di una cartella. Se `filename` è omesso, si apre una finestra di selezione della cartella. |
| `GetFileName(message="")` | Apre una finestra di dialogo dei file e restituisce il percorso completo del file selezionato. |
| `GetFileNames(message="")` | Apre una finestra a selezione multipla e restituisce i percorsi completi come array di stringhe. |
| `GetAllFileNames(message="")` | Seleziona una cartella e restituisce come array i percorsi completi di tutti i file contenuti (ricorsivamente). |
| `ReadImage(filename="", flag=None)` | Legge un file di immagine. Se omesso, si apre una finestra di selezione. |
| `ReadImageHDF(filename, flag)` | Legge un'immagine HDF5. `flag` attiva/disattiva la normalizzazione. Nella versione attuale la lettura di HDF5 (`.h5`) non funziona; i file NeXus (`.nxs`) si possono leggere con `ReadImage(filename)`. |
| `SaveImage(filename="")` | Salva l'immagine corrente (alias storico; TIFF per impostazione predefinita). |
| `SaveImageAsTIFF(filename="")` | Salva l'immagine in TIFF. |
| `SaveImageAsPNG(filename="")` | Salva l'immagine in PNG. |
| `SaveImageAsIPA(filename="")` | Salva l'immagine in formato IPA. |
| `SaveImageAsCSV(filename="")` | Salva l'immagine in CSV. |
| `ReadParameter(filename="")` | Legge un file di parametri. |
| `SaveParameter(filename="")` | Salva i parametri correnti. |
| `ReadMask(filename="")` | Legge un file di maschera. |
| `SaveMask(filename="")` | Salva la maschera corrente. |

Per tutti i metodi di lettura/salvataggio, omettendo il nome del file o indicandone uno non valido si apre una finestra di selezione.

## IPA.Wave

| Membro | Descrizione |
|------|------|
| `SetWaveLength(wavelength)` | Imposta la lunghezza d'onda del fascio incidente (in nm). |
| `WaveLength` | Imposta/legge la lunghezza d'onda (in nm). |
| `WaveSource` | Imposta/legge la sorgente come intero. 0: nessuna, 1: raggi X, 2: elettroni, 3: neutroni. |
| `XrayLine` | Imposta come intero la riga della lunghezza d'onda dei raggi X (solo scrittura). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Membro | Descrizione |
|------|------|
| `SetCenter(x, y)` | Imposta la posizione del centro (spot diretto) (in pixel). |
| `SetCameraLength(length)` | Imposta la lunghezza di camera (in mm). |
| `CenterX` | Imposta/legge il valore X della posizione del centro (in pixel). |
| `CenterY` | Imposta/legge il valore Y della posizione del centro (in pixel). |
| `CameraLength` | Imposta/legge la lunghezza di camera (in mm). |
| `PixelSizeX` | Imposta/legge la dimensione X del pixel (larghezza del pixel) (in mm). |
| `PixelSizeY` | Imposta/legge la dimensione Y del pixel (altezza del pixel) (in mm). |
| `PixelKsi` | Imposta/legge l'inclinazione ξ del pixel (in gradi). |
| `TiltPhi` | Imposta/legge l'inclinazione φ (in gradi). |
| `TiltTau` | Imposta/legge l'inclinazione τ (in gradi). |

## IPA.Image

| Membro | Descrizione |
|------|------|
| `NegativeGradient` | True/False. Disegna l'immagine con gradiente negativo (controparte di `PositiveGradient`). |
| `PositiveGradient` | True/False. Disegna l'immagine con gradiente positivo (controparte di `NegativeGradient`). |
| `LinearScale` | True/False. Disegna in scala lineare (controparte di `LogScale`). |
| `LogScale` | True/False. Disegna in scala logaritmica (controparte di `LinearScale`). |
| `GrayScale` | True/False. Disegna in scala di grigi (controparte di `ColorScale`). |
| `ColorScale` | True/False. Disegna in scala di colori (controparte di `GrayScale`). |
| `Maximum` | Imposta/legge il livello massimo di luminosità (float). |
| `Minimum` | Imposta/legge il livello minimo di luminosità (float). |
| `CanvasMagnification` | Imposta/legge l'ingrandimento dell'immagine (float). |
| `SetCanvasCenter(x, y)` | Imposta la posizione del centro dell'area di disegno (in pixel). |
| `SetCanvasSize(width, height)` | Imposta la dimensione dell'area di disegno (picture box) (in pixel). |
| `SetArea(top, bottom, left, right)` | Imposta l'area di disegno mediante i limiti superiore/inferiore/sinistro/destro (in pixel). |
| `SetFullArea()` | Imposta l'area di disegno in modo che sia visibile l'intera immagine. |

## IPA.Mask

| Membro | Descrizione |
|------|------|
| `MaskSpots()` | Maschera gli spot (come il pulsante "Maschera spot" (Mask Spots)). |
| `ClearMask()` | Cancella le maschere correnti. |
| `InvertMask()` | Inverte lo stato corrente della maschera. |
| `MaskAll()` | Maschera l'intera area. |
| `MaskTop()` | Maschera la metà superiore. |
| `MaskBottom()` | Maschera la metà inferiore. |
| `MaskLeft()` | Maschera la metà sinistra. |
| `MaskRight()` | Maschera la metà destra. |
| `TakeOver` | Imposta/legge l'impostazione di eredità della maschera (intero). 0: nessuna, 1: eredita lo stato corrente della maschera, 2: eredita il file maschera. |

## IPA.Profile

| Membro | Descrizione |
|------|------|
| `ConcentricIntegration` | True/False. Integra in modo concentrico (2θ–intensità). |
| `RadialIntegration` | True/False. Integra in modo radiale (taglio a spicchi). |
| `AzimuthalDivision` | True/False. Elabora in modalità di divisione azimutale. |
| `AzimuthalDivisionNumber` | Intero. Imposta il numero di divisioni dell'anello di Debye. |
| `FindCenterBeforeGetProfile` | True/False. Esegue Trova centro (Find Center) prima di Ottieni profilo (Get Profile). |
| `MaskSpotsBeforeGetProfile` | True/False. Esegue Maschera spot (Mask Spots) prima di Ottieni profilo. |
| `SendProfileViaClipboard` | True/False. Invia il profilo a PDIndexer tramite gli appunti. |
| `SaveProfileAfterGetProfile` | True/False. Salva il profilo dopo Ottieni profilo. |
| `SaveProfileAsPDI` | True/False. Salva in formato PDI. |
| `SaveProfileAsCSV` | True/False. Salva in formato CSV. |
| `SaveProfileAsTSV` | True/False. Salva in formato TSV. |
| `SaveProfileAsGSAS` | True/False. Salva in formato GSAS. Possibile solo per l'integrazione concentrica con asse 2θ; non viene scritto quando più profili sono salvati in un unico file. |
| `SaveProfileInOneFile` | True/False. Salva in un unico file i profili sequenziali/a divisione azimutale. |
| `SaveProfileAtImageDirectory` | True/False. Salva nella stessa cartella dell'immagine. |
| `GetProfile(filename="")` | Integra l'immagine in un profilo 1D (come **Ottieni profilo (Get Profile)**). Se si indica `filename`, viene usato come nome base e vi si aggiunge l'estensione del formato (ad es. `GetProfile("sample.stl")` salvato in CSV dà `sample.stl.csv`). Se la destinazione è impostata su "scelta ogni volta", viene mostrata la finestra di salvataggio. |

## IPA.IntegralProperty

| Membro | Descrizione |
|------|------|
| `ConcentricIntegration` | True/False. Integra in modo concentrico (2θ–intensità). |
| `RadialIntegration` | True/False. Integra in modo radiale (taglio a spicchi / pattern a torta). |
| `ConcentricStart` | Float. Valore iniziale dell'integrazione concentrica. |
| `ConcentricEnd` | Float. Valore finale dell'integrazione concentrica. |
| `ConcentricStep` | Float. Valore del passo dell'integrazione concentrica. |
| `ConcentricUnit` | Intero. Unità dell'integrazione concentrica. 0: angolo (gradi), 1: distanza d (Å), 2: lunghezza (mm). |
| `RadialRadius` | Float. Raggio della ciambella per l'integrazione radiale. |
| `RadialWidgh` | Float. Larghezza della ciambella per l'integrazione radiale. Nota: nella versione attuale il membro si scrive `RadialWidgh`. |
| `RadialStep` | Float. Angolo del settore (passo di scansione) per l'integrazione radiale. |
| `RadialUnit` | Intero. Unità dell'integrazione radiale. 0: angolo (gradi), 1: distanza d (Å). |

## IPA.Sequential

| Membro | Descrizione |
|------|------|
| `SequentialImageMode` | True/False. Indica se il file corrente è un'immagine sequenziale. |
| `Count` | Intero. Restituisce il numero di immagini. |
| `SelectedIndex` | Intero. Imposta/legge l'indice selezionato (a partire da 0). |
| `SelectedIndices` | Array di interi. Imposta/legge gli indici selezionati (per la modalità di selezione multipla). |
| `MultiSelection` | True/False. Imposta/legge la modalità di selezione multipla. |
| `Averaging` | True/False. Imposta/legge la modalità di media. |
| `SelectIndex(index)` | Imposta un unico indice selezionato (disattiva la selezione multipla). |
| `AppendIndex(index)` | Aggiunge un indice alla selezione corrente. |
| `SelectIndices(start, end)` | Imposta un intervallo contiguo (da start a end, inclusi). |
| `AppendIndices(start, end)` | Aggiunge alla selezione corrente un intervallo contiguo (da start a end, inclusi). |
| `Target_SelectedImages` | True/False. Rende le immagini selezionate la destinazione di Ottieni profilo. |
| `Target_AllImages` | True/False. Rende tutte le immagini la destinazione di Ottieni profilo. |
| `Target_TopmostImage` | True/False. Rende solo l'immagine in cima la destinazione di Ottieni profilo. |

## IPA.PDI

| Membro | Descrizione |
|------|------|
| `Debug` | True/False. Esegue passo passo la macro in PDIndexer. |
| `Timeout` | Imposta/legge il timeout (secondi) dell'operazione della macro (predefinito 30 s). |
| `RunMacro(obj1, obj2, ...)` | Esegue il codice attualmente aperto nell'editor delle macro di PDIndexer. In PDIndexer i parametri si leggono come `PDI.Obj[0]`, `PDI.Obj[1]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Esegue la macro salvata con il nome `name` in PDIndexer. In PDIndexer i parametri si leggono come `PDI.Obj[0]`, `PDI.Obj[1]`, … |
