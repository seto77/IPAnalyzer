<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Finestre delle proprietà

La finestra delle proprietà è dove si configurano la sorgente, le condizioni del rivelatore e le varie condizioni di unidimensionalizzazione. Ogni scheda può essere aperta direttamente anche dal menu **Property** nella finestra principale.

L'interfaccia di questa finestra è in inglese. I titoli sottostanti utilizzano i nomi effettivi delle schede e dei controlli.

## Wave source

Imposta il tipo di fascio incidente e la lunghezza d'onda. La sorgente può essere raggi X, elettroni o neutroni. Per i raggi X, selezionando un elemento e una transizione (linea K, linea L, ecc.) la lunghezza d'onda viene compilata automaticamente; per la radiazione di sincrotrone, inserire direttamente la lunghezza d'onda. Per i fasci di elettroni e neutroni, inserire l'energia o la lunghezza d'onda (la lunghezza d'onda degli elettroni è corretta relativisticamente).

- **Correct linear polarization**: corregge un'intensità polarizzata linearmente all'equivalente non polarizzato (per dati di sincrotrone). La formula di correzione seguente dipende dall'azimut χ (definito nella scheda Miscellaneous) e dall'angolo di diffusione 2θ.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

Imposta le condizioni geometriche del rivelatore. Corrisponde alla precedente "IP Condition", con l'aggiunta dei selettori del sistema di coordinate e della forma del rivelatore.

- **Coordinates**: **Direct spot** (riferimento allo spot diretto) / **Foot** (riferimento al piede della perpendicolare).
- **Detector type**: **Flat panel** / **Gandolfi**.
- **Direct spot position** e **Camera Length 1**: la posizione dello spot diretto (X, Y pix) e la distanza dal campione allo spot diretto (mm).
- **Foot position** e **Camera Length 2**: in modalità Foot, la posizione del piede della perpendicolare e la distanza dal campione al piede.
- **Pixel Shape**: dimensione del pixel X, Y (mm) e ξ (Ksi, l'angolo di inclinazione del parallelogramma).
- **Gandolfi Radius**: il raggio, quando è selezionata la forma Gandolfi.
- **Spherical correction**: correzione sferica (normalmente zero).
- **Tilt**: l'inclinazione dell'IP φ (Phi) e τ (Tau).

Vedere [Overview](0-overview.md) per le definizioni dell'inclinazione φ, τ e del pixel ξ.

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

Specifica la regione dell'immagine da unidimensionalizzare.

- **Rectangle**: scegliere la **Direction** (Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free) e impostare la **Band Width**, l'**Angle** (in modalità Free) e **Both Side**.
- **Sector**: specificare l'intervallo angolare con **Start Angle** / **End Angle**.
- **Exceptional pixels**: escludere i **Masked Spots**, i pixel **Under intensity of** / **Over intensity of** le soglie indicate e un certo numero di **pixels from edges**.

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

Imposta il metodo di integrazione e il passo.

- **Concentric integration (scattering-angle dispersive)**: scegliere l'unità dell'asse orizzontale tra **Angle** (2θ, °) / **Length** (mm) / **d-spacing** (Å) e impostare **Start / End / Step**. L'**Output pattern** può essere **Bragg - Brentano** o **Debye - Scherrer**.
- **Radial integration (cake pattern)**: analizza una regione ad anello nella direzione azimutale. Scegliere l'asse orizzontale tra **Angle** / **d-spacing** e impostare il **Donut radius** (raggio centrale), la **Donut width** (larghezza dell'anello) e il **Sector angle step** (passo di scansione).

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

Imposta le condizioni per la mascheratura e per il rilevamento del centro/spot (un'espansione della precedente "Find Center & Spots").

- **Half mask**: pulsanti che mascherano rapidamente la metà superiore, inferiore, sinistra o destra dell'immagine.
- **Manual mask mode**: abilita la mascheratura interattiva sull'immagine principale. Le forme sono **Circle** (trascinare per impostare centro e raggio), **Polygon** (fare clic per aggiungere vertici), **Rectangle** (trascinare i vertici diagonali), **Spline curve** e **Spot** (clic sinistro/destro per aggiungere/rimuovere spot).
- **Takeover**: come viene trattata la maschera al caricamento di una nuova immagine (**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation**: la soglia statistica per il rilevamento degli spot.
- **Find Center**: l'intervallo di ricerca per il rilevamento del centro, e così via.

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

Imposta il salvataggio e l'invio dopo l'unidimensionalizzazione.

- **Save File**: scegliere la destinazione ("la stessa directory dell'immagine" o "una directory scelta ogni volta") e il formato tra **PDI** / **CSV** / **TSV** / **GSAS**.
- **Send PDIndexer**: invia il profilo, tramite gli appunti, a un'istanza di PDIndexer in esecuzione.

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

Imposta i parametri per l'immagine srotolata (Unroll).

- **Horizontal**: l'unità (Angle / Length / d-spacing) e **Start / End / Step**. La larghezza dell'immagine di uscita ≈ (End − Start) / Step.
- **Vertical**: il passo azimutale (°/pixel). L'altezza dell'immagine di uscita ≈ 360 / step.

Lo srotolamento mappa l'immagine di diffrazione polare centrata sullo spot diretto in un'immagine cartesiana (angolo vs. distanza).

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

Una scheda che raccoglie le impostazioni più fini di visualizzazione e di coordinate.

- **Image name display**: solo nome file / cartella superiore + nome file / percorso completo.
- **Contrast / intensity-range persistence**: se le impostazioni di visualizzazione vengono mantenute al caricamento di una nuova immagine.
- **Azimuth χ (Chi) orientation**: la posizione di riferimento (Top / Bottom / Left / Right) e il verso di rotazione (Clockwise / Counterclockwise). χ è utilizzato come riferimento dalla correzione di polarizzazione e dall'integrazione radiale.
- **Scale line**: colore, larghezza, numero di divisioni e visualizzazione dell'etichetta.
- **Find Center**: intervallo di ricerca, intervallo di fitting del picco, fissare il centro ed escludere i pixel mascherati.

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

Imposta la correzione tramite un'immagine di sfondo.

- **Background image**: imposta l'immagine attualmente visualizzata come sfondo (**Set the current image as background**) o la cancella (**Clear**).
- **Coefficient**: il fattore applicato all'immagine di sfondo.
- **Edge mask**: un margine di maschera aggiuntivo (px) applicato ai bordi durante la correzione.

Utilizzato per la correzione di campo piatto, la rimozione della diffusione dell'aria e simili.

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
