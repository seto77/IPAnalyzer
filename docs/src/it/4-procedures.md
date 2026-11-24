<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Procedure

Questa pagina mostra il flusso delle operazioni tipiche. Per la descrizione dei singoli strumenti vedere [Strumenti](3-tools.md).

## Flusso di base (integrazione concentrica)

1. **Caricare un'immagine**: File → Leggi immagine (File → Read image) (oppure trascinamento e rilascio).
2. **Impostare la sorgente**: impostare l'elemento/la transizione oppure la lunghezza d'onda in **Sorgente d'onda (Wave source)** nelle proprietà.
3. **Impostare la condizione del rivelatore**: impostare la lunghezza di camera, la dimensione del pixel, la posizione del centro (approssimativa) e, se necessario, l'inclinazione φ, τ in **Condizione del rivelatore (Detector condition)**.
4. **Trovare il centro**: rilevare automaticamente il centro del fascio con **Trova centro (Find Center)** nella barra degli strumenti (l'intervallo di ricerca si imposta nella scheda Varie).
5. **Mascherare gli spot**: eliminare le riflessioni di monocristallo e simili con **Maschera spot (Mask Spots)**. Se necessario, mascherare manualmente con **Modalità manuale (Manual Mode)**.
6. **Verificare le impostazioni di integrazione**: selezionare la regione di interesse in **Regione di integrazione (Integral Region)**, e scegliere **Integrazione concentrica (dispersiva nell'angolo di scattering) (Concentric integration (scattering angle dispersive))** con l'unità dell'asse e **Inizio / Fine / Passo (Start / End / Step)** in **Proprietà di integrazione (Integral Property)**.
7. **Integrare l'immagine**: ottenere il profilo con **Ottieni profilo (Get Profile)**. Il salvataggio e l'invio si configurano nella scheda **Dopo "Ottieni profilo" (After "Get Profile")** (salvataggio CSV, invio a PDIndexer, ecc.).

Per le immagini sequenziali, selezionare un frame in [Immagine sequenziale](3-tools.md) prima dei passi 5–7. Per l'analisi per azimut, usare **Analisi a divisione azimutale (Azimuthal Division Analysis)** nel menu a discesa di **Ottieni profilo** (gli anelli vengono suddivisi in settori e ciascun settore viene integrato; disponibile solo con l'integrazione concentrica e l'asse **Angolo (Angle)** (2θ)), oppure **Integrazione radiale (pattern a torta) (Radial integration (cake pattern))** in **Proprietà di integrazione** (un profilo azimut–intensità).

Se la lunghezza di camera, la lunghezza d'onda o l'inclinazione non sono note, calibrarle prima da un'immagine di un campione di riferimento come descritto nella sezione successiva, applicare i valori e poi integrare le immagini del campione.

## Determinazione dei parametri: calibrazione geometrica con un campione di riferimento (doppia cassetta)

Quando la lunghezza di camera o la lunghezza d'onda non sono note, ottimizzare i parametri geometrici a partire dagli anelli di diffrazione di un materiale di riferimento (CeO2 per impostazione predefinita, ecc.), usando [Trova parametro (geometricamente)](3-tools.md).

1. Caricare l'**Immagine primaria (Primary image)** (campione di riferimento, a una certa lunghezza di camera) con Apri (Open), trovare il centro e visualizzare i picchi con **Ottieni profilo (Get Profile)**.
2. Trascinando un marcatore di linea di diffrazione nella Profile View, la stima della lunghezza di camera viene aggiornata automaticamente.
3. Caricare allo stesso modo l'**Immagine secondaria (Secondary image)** (lo stesso campione di riferimento, a una lunghezza di camera diversa), e inserire la **differenza di lunghezza di camera** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) (ad es. +20 se l'immagine primaria è a 100 mm e la secondaria a 120 mm). L'immagine secondaria è facoltativa; la calibrazione funziona anche con la sola immagine primaria.
4. Nell'**Elenco picchi (Peak List)**, selezionare i valori d dei picchi che compaiono in entrambe le immagini (normalmente tre o più per immagine; con due immagini, almeno uno deve essere comune a entrambe. A meno che non si affini solo la lunghezza di camera, con meno di tre picchi **Affina! (Refine!)** non fa nulla).
5. Scegliere i parametri da ottimizzare (**Lunghezza d'onda (Wave Length)**, **Lunghezza camera (Camera Length)**, **Correzione inclinazione (Tilt Correction)**, **Dimensione pixel (Pixel Size)**, **Distorsione pixel (Pixel Distortion)**, **Posizione centro (Center Position)**, **Correzione sferica (Spherical Correction)**).
6. Eseguire **Affina!**. Si arresta automaticamente dopo il numero di ripetizioni impostato (12 per impostazione predefinita). Dopo aver verificato il risultato, copiarlo nella finestra principale con **Parametri affinati => Finestra principale (Refined parameters => Main form)**.

!!! note
    L'uso di due immagini (una "doppia cassetta") rende più facile determinare separatamente la lunghezza di camera e la lunghezza d'onda.

## Determinazione dei parametri: ottimizzazione a forza bruta (campione di riferimento)

Quando l'ottimizzazione geometrica fatica a convergere, cercare in modo esaustivo la lunghezza di camera, la posizione del centro, l'inclinazione e, facoltativamente, la lunghezza d'onda con [Trova parametro (forza bruta)](3-tools.md). Per una guida dettagliata con schermate vedere [Trova parametri (forza bruta)](6-find-parameter.md).

1. Caricare un'immagine di un campione di riferimento nella finestra principale, aprire Trova parametro (forza bruta) (Find parameter (brute force)) e selezionare il materiale di riferimento corrispondente.
2. Allineare approssimativamente la posizione del centro nella finestra principale (Trova centro aiuta).
3. Scegliere le voci da ottimizzare e inserire l'ampiezza del passo **Passo iniziale (Initial step)** (centrata sul valore corrente) e il numero di passi su ciascun lato (**Intervallo di ricerca (Search range)**). Per un rivelatore piano, la dimensione del pixel non è oggetto della ricerca. Per esempi numerici vedere [Trova parametri (forza bruta)](6-find-parameter.md).
4. Impostare la **Regione di integrazione (Integral Region)** in modalità fenditura (Rettangolo, Rectangle) con una larghezza di banda stretta aiuta a sopprimere il rumore.
5. Avviare la ricerca con **Ottimizza (Optimize)**. In ogni ciclo viene adottata la combinazione con il valore di valutazione R più piccolo, che viene scritta automaticamente nei parametri della finestra principale.

## Elaborazione automatica (Procedura automatica)

Elaborare automaticamente le immagini che arrivano in una cartella, ad esempio durante un esperimento. Per i dettagli vedere [Strumenti](3-tools.md).

1. Scegliere la cartella da monitorare con **Imposta (Set)**.
2. Se necessario, filtrare i file con **Corrispondenza di pattern (Pattern matching)** (il numero alla fine del nome del file) o con **Parola chiave (Keyword)**.
3. Abilitare **Una volta caricata la nuova immagine, esegui la seguente sequenza (Once the new image is loaded, perform the following sequence)**, e scegliere dall'elenco: **Auto contrast** / **Find center** / **Mask spots** / **Get profile** / **Execute macro**.
4. Infine, attivare **Carica automaticamente le nuove immagini (Automatically load new images)** per avviare il monitoraggio (non si può attivare senza una cartella; vengono usate le condizioni di numero/parola chiave in vigore all'avvio del monitoraggio). La sequenza viene quindi eseguita automaticamente ogni volta che arriva un'immagine corrispondente. Un file ancora bloccato dopo l'attesa della scrittura (circa 50 s) viene ritentato nelle scansioni successive e vi si rinuncia 10 minuti dopo che è stato trovato per la prima volta.

## Procedure tramite script (macro basate su Python)

Le elaborazioni con cicli e condizioni si possono scrivere come [macro](5-macro/index.md). Le macro di esempio mostrate con **Mostra esempi (Show samples)** nell'editor delle macro sono un buon punto di partenza.

- Caricare un'immagine, impostare la sorgente e il rivelatore (centro, lunghezza di camera, pixel) e adattare la visualizzazione.
- Impostare le condizioni dell'integrazione concentrica (inizio, fine, passo, unità), integrare e salvare in CSV.
- Elaborare in batch più file, salvando un CSV accanto a ciascuna immagine.
- Elaborare un'immagine multiframe frame per frame.
- Suddividere un anello di Debye in N settori e analizzare la dipendenza azimutale.
- Mascherare (cancella tutto → maschera spot → maschera la regione del beam stop → salva la maschera) e integrare.
- Produrre azimut rispetto a intensità con l'integrazione radiale (cake).
- Abilitare l'invio tramite appunti, integrare e richiamare una macro denominata in PDIndexer (ad es. fitting dei picchi).

Le macro scritte si possono salvare, richiamare per nome ed eseguire anche dalla Procedura automatica (Auto Procedure).
