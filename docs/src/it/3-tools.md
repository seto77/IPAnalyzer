<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Strumenti

Questa pagina descrive gli strumenti ausiliari avviati dalla barra degli strumenti verticale a destra della finestra principale, oppure dai menu. Per procedure concrete che utilizzano la calibrazione dei parametri e le macro, vedere [Procedure](4-procedures.md).

## Intensity Table

Uno strumento che confronta le distribuzioni di intensità di due immagini e ottimizza una tabella di conversione dell'intensità. Ottimizza 16 punti di controllo su 300 iterazioni per far coincidere le due intensità preservando l'intensità integrata totale. Viene usato, ad esempio, per calibrare la risposta in intensità di un rivelatore.

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

Uno strumento che monitora una cartella, carica automaticamente le nuove immagini ed esegue una sequenza di operazioni dopo il caricamento.

- **Watch and auto-load**: monitora la cartella specificata (incluse le sottocartelle) e legge un file dopo il completamento della sua scrittura. I file possono essere filtrati per nome (corrispondenza numerica, parola chiave).
- **Auto execution**: esegue, in ordine, i passi selezionati tra Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro.

Ciò consente impieghi come il monitoraggio di una cartella di output durante un esperimento e l'integrazione automatica di ogni immagine man mano che arriva. Vedere [Procedure](4-procedures.md) per i dettagli.

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

Disegna un anello a una distanza, un angolo o un valore d specificato sull'immagine, tenendo conto dell'inclinazione dell'IP e della distorsione del pixel. Fare clic su uno tra **R (mm)** / **2θ (°)** / **d (Å)** per scegliere quale valore modificare; gli altri vengono calcolati automaticamente dalla lunghezza d'onda e dalla lunghezza di camera.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

Srotola l'immagine di diffrazione da coordinate polari centrate sullo spot diretto in coordinate cartesiane (asse orizzontale = angolo, distanza o valore d; asse verticale = azimut). Ora è configurato non con una finestra dedicata, ma con il pulsante **Unroll** della barra degli strumenti e con la scheda **Unrolled Image Option** delle proprietà. Lo srotolamento usa lo stesso algoritmo di distribuzione dell'intensità a livello di sub-pixel della unidimensionalizzazione.

## Circumferential Blur

Uno strumento che sfoca il pattern ad anelli lungo la direzione circonferenziale (azimutale). Specificare un singolo angolo di sfocatura e applicarlo.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

Uno strumento per gestire immagini multiframe (HDF5 e simili; serie temporali, serie di temperatura, scansioni in energia da sincrotrone).

- Selezionare un singolo frame dall'elenco dei frame per visualizzarlo, oppure scorrere con la trackbar.
- Con la **multi-selezione**, selezionare diversi frame e calcolarne la **media** o la **somma**.
- Il bersaglio della unidimensionalizzazione può essere scelto tra "tutti i frame / frame selezionati / solo il primo".
- Se ogni frame contiene informazioni sull'energia, la lunghezza d'onda viene aggiornata automaticamente.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

Corregge l'inclinazione dell'IP φ, τ e la distorsione del pixel ξ, e salva l'immagine con pixel quadrati a una risoluzione specificata. Vengono scritti anche metadati come la lunghezza di camera, la lunghezza d'onda e la posizione del centro, in modo che l'immagine possa essere passata ad altre elaborazioni preservando le informazioni geometriche.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

Uno strumento che ottimizza la lunghezza d'onda, la lunghezza di camera, la dimensione del pixel, la distorsione del pixel e l'inclinazione (φ, τ) a partire dagli anelli di diffrazione di un materiale di riferimento. Utilizza due pattern, Primary e Secondary, e si selezionano i picchi e si ottimizza con **Refine!**. La convergenza (centro dell'ellisse, residui) può essere verificata sui grafici. Vedere [Procedure](4-procedures.md) per i passi concreti.

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

Uno strumento che trova la lunghezza di camera e la lunghezza d'onda mediante una ricerca esaustiva su griglia anziché con un metodo del gradiente. È efficace quando l'ottimizzazione geometrica fatica a convergere, ad esempio con anelli incompleti o dati rumorosi. Il CrystalControl viene usato per inserire i parametri del cristallo. Vedere [Trova parametri (forza bruta)](6-find-parameter.md) per i passi dettagliati, e [Procedure](4-procedures.md) per il flusso di lavoro.

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Una funzione che automatizza le operazioni con script in stile Python. Aprire l'editor delle macro dal menu **Macro → Editor** nella finestra principale.

- Sono disponibili `for` / `if` / `while` / `def` / `class`, l'aritmetica e il modulo `math`.
- API come `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permettono di richiamare ciascuna operazione.
- Sono incluse macro di esempio (cicli di base, configurazione della geometria, elaborazione batch, divisione azimutale, mascheratura, invio a PDIndexer, ecc.) ed è possibile ispezionare le variabili con l'esecuzione passo passo.

Vedere [Macro](5-macro/index.md) per il riferimento completo delle funzioni e gli esempi, e [Procedure](4-procedures.md) per i flussi di lavoro basati su macro.

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

Uno strumento destinato alla correzione dell'intensità specifica dei rivelatori R-Axis; al momento si limita a leggere il file, e la correzione vera e propria non è ancora implementata.

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
