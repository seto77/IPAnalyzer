<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Procedure

Questa pagina illustra il flusso delle attività tipiche. Per la descrizione dei singoli strumenti, vedere [Strumenti](3-tools.md).

## Flusso di base (integrazione concentrica)

1. **Caricare un'immagine**: File → Read image (oppure trascina e rilascia).
2. **Impostare la sorgente**: impostare l'elemento/transizione oppure la lunghezza d'onda sotto **Wave source** nelle proprietà.
3. **Impostare la condizione del rivelatore**: impostare la lunghezza di camera, la dimensione del pixel, la posizione del centro (approssimativa) e, se necessario, l'inclinazione φ, τ sotto **Detector condition**.
4. **Trovare il centro**: rilevare automaticamente il centro del fascio con **Find Center** sulla barra degli strumenti (l'intervallo di ricerca si imposta sotto Miscellaneous).
5. **Mascherare gli spot**: rimuovere le riflessioni da monocristallo e simili con **Mask Spots**. Se necessario, mascherare manualmente con **Manual**.
6. **Ridurre a una dimensione**: ottenere il profilo con **Get Profile**. Il salvataggio e l'invio si configurano nella scheda **After "Get Profile"** (salvataggio CSV, invio a PDIndexer, ecc.).

Per immagini sequenziali, selezionare un frame in [Sequential](3-tools.md) prima dei passaggi 5–6. Per l'analisi per azimut, usare Radial integration in **Integral Property**.

## Determinazione dei parametri: calibrazione geometrica con un campione di riferimento (double cassette)

Quando la lunghezza di camera o la lunghezza d'onda è sconosciuta, ottimizzare i parametri geometrici a partire dagli anelli di diffrazione di un materiale di riferimento (CeO2 per impostazione predefinita, ecc.), usando [Find Parameter (Geometric)](3-tools.md).

1. Caricare la **Primary image** (campione di riferimento, a una lunghezza di camera) con Open, trovare il centro e mostrare i picchi con **Get Profile**.
2. Trascinando un marcatore di linea di diffrazione nella Profile View, la stima della lunghezza di camera si aggiorna automaticamente.
3. Caricare la **Secondary image** (lo stesso campione di riferimento, a una lunghezza di camera diversa) allo stesso modo, e immettere la **camera-length difference** rispetto a Primary.
4. Nella **Peak List**, selezionare i valori d dei picchi che compaiono in entrambe le immagini (almeno uno per immagine, idealmente tre o più).
5. Sotto **Refinement Option**, scegliere i parametri da ottimizzare (lunghezza d'onda, distanza della pellicola, inclinazione, dimensione del pixel, distorsione del pixel).
6. Eseguire **Refine!** e, una volta che il residuo si stabilizza, copiare i risultati ottimizzati nella maschera principale.

!!! note
    Usare due immagini (una "double cassette") rende più facile determinare separatamente la lunghezza di camera e la lunghezza d'onda.

## Determinazione dei parametri: ottimizzazione a forza bruta (campione arbitrario)

Quando l'ottimizzazione geometrica fatica a convergere, cercare in modo esaustivo la lunghezza di camera e la lunghezza d'onda con [Find Parameter (Brute force)](3-tools.md). Vedere [Trova parametri (forza bruta)](6-find-parameter.md) per una guida dettagliata con screenshot.

1. Caricare le immagini Primary e Secondary (due immagini, con anelli in comune, a lunghezze di camera diverse).
2. Allineare approssimativamente la posizione del centro nella maschera principale (Find Center è di aiuto).
3. Immettere gli **search ranges (min, max, step)** per la lunghezza di camera, la lunghezza d'onda, ecc. Lasciare inizialmente disattivati i parametri sconosciuti (dimensione del pixel, inclinazione).
4. Impostare **Integral Region** su una modalità a fenditura (Rectangle) con una larghezza di banda stretta aiuta a sopprimere il rumore.
5. Avviare la ricerca e copiare la combinazione con il residuo più piccolo nella maschera principale.

## Elaborazione automatizzata (Auto Procedure)

Elaborare automaticamente le immagini che arrivano in una cartella, per esempio durante un esperimento. Vedere [Strumenti](3-tools.md) per i dettagli.

1. Abilitare **Automatically load new images** e scegliere la cartella da monitorare con **Set**.
2. Se necessario, filtrare i file per **number matching** (il numero alla fine del nome del file) o per **keyword**.
3. Abilitare **After Loading Image, Execute "Auto"** e scegliere dall'elenco: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Una volta avviato il monitoraggio, la sequenza viene eseguita automaticamente ogni volta che arriva un'immagine corrispondente.

## Procedure tramite script (macro basate su Python)

L'elaborazione con cicli e condizioni può essere scritta come una [macro](5-macro/index.md). Le macro di esempio incluse sono un buon punto di partenza.

- Caricare un'immagine, impostare la sorgente e il rivelatore (centro, lunghezza di camera, pixel) e adattare la visualizzazione.
- Impostare le condizioni di integrazione concentrica (inizio, fine, passo, unità), ridurre a una dimensione e salvare come CSV.
- Elaborare in batch più file, salvando un CSV accanto a ciascuna immagine.
- Elaborare un'immagine multiframe frame per frame.
- Suddividere un anello di Debye in N settori e analizzare la dipendenza azimutale.
- Mascherare (cancella tutto → maschera gli spot → maschera la regione del beam-stop → salva la maschera) e ridurre a una dimensione.
- Restituire azimut vs. intensità con integrazione radiale (cake).
- Abilitare l'invio agli appunti, ridurre a una dimensione e chiamare una macro denominata in PDIndexer (per esempio il fitting dei picchi).

Le macro che si scrivono possono essere salvate, richiamate per nome ed eseguite anche da Auto Procedure.
