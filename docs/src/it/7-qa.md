<!-- 261124Cl: Retranslated from en/7-qa.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Q&A (Domande frequenti)

Questa pagina raccoglie le domande poste più spesso e i punti che si fraintendono facilmente. Le etichette sono i nomi visualizzati nell'interfaccia italiana, con il nome inglese tra parentesi. Per le domande non trattate qui, o per segnalare un bug, usare [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Installazione e avvio

### Compare solo la finestra delle proprietà; la finestra principale non si vede

La finestra principale è posizionata fuori dallo schermo.

1. Passare con il mouse sull'icona di IPAnalyzer nella barra delle applicazioni, fare clic con il tasto destro sulla miniatura, scegliere **Sposta** (Move), premere una volta un tasto freccia e poi muovere il mouse.
2. Se non basta, chiudere IPAnalyzer, aprire l'Editor del Registro di sistema (regedit), eliminare `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer` e avviare di nuovo IPAnalyzer (tutte le impostazioni tornano ai valori predefiniti).

### Dopo l'aggiornamento è ancora in esecuzione la vecchia versione / IPAnalyzer non si avvia più

Reinstallare direttamente dall'[ultima release](https://github.com/seto77/IPAnalyzer/releases/latest). Se l'installazione non sovrascrive la vecchia versione, o il programma non si avvia, disinstallarlo una volta dalle Impostazioni di Windows e poi reinstallarlo. Se una nuova versione presenta un problema, si può installare una versione precedente dalla stessa pagina delle release.

### Voglio usarlo su un PC senza diritti di amministratore, o su Windows on Arm

- Senza diritti di amministratore, usare la versione portatile (`IPAnalyzer-v.<version>.zip`), che non richiede installazione e include il runtime .NET.
- Su Windows on Arm, usare il programma di installazione arm64 (`IPAnalyzer-setup_arm64.msi`) o la versione portatile (`IPAnalyzer-v.<version>_arm64.zip`).

Per i dettagli vedere [Installazione nella Panoramica](0-overview.md#installazione).

### Caricando molti frame si verifica un errore. Quanta memoria serve?

IPAnalyzer conserva l'intensità di ogni pixel in doppia precisione (8 byte), qualunque sia la profondità di bit originale. Ad esempio, 5000 immagini di 1554×516 pixel richiedono circa 32 GB solo per le intensità. Gestire i dati con molti frame su un PC con memoria sufficiente, oppure elaborarli a porzioni con una macro.

## Lettura delle immagini

### I file del mio rivelatore non si possono leggere

Il formato potrebbe non essere ancora supportato. Contattateci tramite [Issues](https://github.com/seto77/IPAnalyzer/issues) o scrivete all'autore allegando un file reale (preferibilmente uno con un pattern di diffrazione, non solo un'immagine di buio). La correttezza delle intensità e l'orientamento dell'immagine si possono verificare solo con un'immagine che mostri un pattern. Se il caricamento non riesce, l'immagine caricata in precedenza resta, quindi si può continuare a lavorare con essa.

!!! note "Quando un'immagine raw ha larghezza e altezza errate"
    Per i file raw senza intestazione, il modello di rivelatore e il numero di pixel vengono dedotti dalla dimensione del file. Il numero effettivo di pixel differisce spesso dal valore di catalogo, quindi inviate il file se il riconoscimento non riesce.

### Dopo aver caricato un file di parametri e aperto un'immagine, i parametri cambiano

IPAnalyzer **memorizza per ciascun formato di immagine parametri come la lunghezza di camera, la lunghezza d'onda e la dimensione del pixel**, e passa a quei valori quando si apre un'immagine. Caricare quindi il file di parametri (`.prm`) **dopo aver aperto l'immagine**. I formati con estensioni diverse vengono memorizzati separatamente anche se il loro contenuto è lo stesso.

### Devo capovolgere o ruotare di nuovo ogni immagine?

No. Anche le impostazioni **Opzioni → Capovolgi / Ruota** (Option → Flip / Rotate) vengono memorizzate per formato di immagine e applicate automaticamente la volta successiva che si apre un'immagine dello stesso formato. Il capovolgimento e la rotazione influiscono anche sull'integrazione e sul salvataggio dell'immagine (il file di origine non viene modificato).

### Come vengono gestiti i file con più frame (`.his`, `.nxs`, TIFF multipagina, …)?

Quando si carica un file di questo tipo, si apre la finestra **Immagine sequenziale (Sequential image)** e si può selezionare il frame da visualizzare. Per integrarli insieme, usare **Ottieni profili per tutte le immagini sequenziali (Get Profiles for all sequential images)** oppure **Ottieni profili per le immagini selezionate (Get Profiles for selected images)** nel menu a discesa di **Ottieni profilo (Get Profile)**. Per i dettagli vedere [Strumenti](3-tools.md#immagine-sequenziale-sequential-image).

## Calibrazione

### Quando usare Trova parametro (geometricamente) e quando Trova parametro (forza bruta)?

| | Geometricamente (geometrically) | Forza bruta (brute force) |
|---|---|---|
| Principio | Suddivide l'immagine in settori, trova le posizioni dei picchi e determina il centro, l'inclinazione, ecc. dalle forme ellittiche e dai centri degli anelli di Debye | Varia i parametri passo per passo e cerca la combinazione che fa coincidere al meglio le posizioni dei picchi calcolate e quelle ottenute dal fitting |
| Dati adatti | Anelli visibili quasi per l'intera circonferenza (almeno in cinque direzioni) | Solo una parte degli anelli registrata, spot diretto fuori dall'immagine, anelli a spot |
| Immagini | Una, oppure due acquisite a lunghezze di camera diverse | Una |
| Attenzione | La precisione cala o l'affinamento non converge se gli anelli non sono visibili per l'intera circonferenza | Richiede valori iniziali abbastanza buoni; richiede tempo |

Per i passi vedere [Procedure](4-procedures.md) e [Trova parametri (forza bruta)](6-find-parameter.md).

### Quale campione di riferimento usare per la calibrazione?

È adatto un campione che dia anelli di Debye uniformi (non a spot) da grani fini, visibili il più possibile per l'intera circonferenza. Circa cinque anelli o più è un'indicazione. Con solo due anelli completi una determinazione precisa è difficile, e la lunghezza d'onda o la lunghezza di camera dovrebbe essere nota. Per la calibrazione a forza bruta, scegliere il materiale di riferimento tra Au / CeO₂ / LaB₆ / Al₂O₃, oppure selezionare **Altro (Other)** e inserire le costanti reticolari.

### La calibrazione non converge / il centro continua a spostarsi

- Fissare i valori di cui ci si può fidare (dimensione del pixel di catalogo, lunghezza d'onda nota, ecc.) e ridurre il numero di variabili affinate.
- Eseguire prima un fitting approssimativo con alcuni anelli a basso angolo, poi aggiungere gli anelli ad alto angolo.
- Un anello la cui analisi non è riuscita può alterare l'intero risultato. Se un anello si discosta dagli altri nel grafico dei centri degli anelli, rimuoverlo.
- Se il fitting fallisce quando si includono gli anelli ad alto angolo, limitare i picchi a quelli i cui anelli sono ancora visibili per l'intera circonferenza, allargare l'intervallo di fitting e usare meno settori.
- Prima di iniziare, inserire valori iniziali il più possibile corretti.

### La lunghezza di camera e la lunghezza d'onda si possono determinare solo se una delle due è fissata?

Con un materiale di riferimento le cui costanti reticolari sono note con precisione, si possono determinare entrambe anche da una sola immagine (dai rapporti tra le posizioni degli anelli). Tuttavia, **la lunghezza di camera e la dimensione del pixel non si possono determinare insieme da una sola immagine**. Fidarsi della dimensione del pixel di catalogo e fissarla. Con due immagini la cui differenza di lunghezza di camera è nota (metodo della doppia cassetta), si può affinare anche la dimensione del pixel.

### Lo spot diretto non è registrato / si trova fuori dall'immagine

Inserire a mano la posizione dello spot diretto e disattivare **Trova centro prima di Ottieni profilo (Find Center before Get Profile)** nel menu a discesa di **Ottieni profilo (Get Profile)**. Se lo spot si trova fuori dall'immagine, le coordinate negative vanno bene. Per questi dati usare la calibrazione a forza bruta.

### Il centro di Trova centro differisce di alcuni pixel dal centro calibrato

Sono determinati in modo diverso. **Trova centro (Find Center)** esegue il fitting dello spot diretto vicino al centro corrente con una funzione pseudo-Voigt bidimensionale. La calibrazione non usa l'intensità dello spot diretto; ricava il centro dai centri delle ellissi di più anelli di Debye. Una volta determinata correttamente l'inclinazione, il centro calibrato si può usare così com'è. Se lo spot diretto è saturo, mostrare un cerchio su un anello di Debye con **Disegna anello (Draw ring)** e premere **Trova centro**: il centro viene allora determinato dall'anello.

### Che cos'è la correzione sferica?

Una correzione per un rivelatore curvato come una sfera. Inserire l'inverso del raggio di curvatura, 1/R, in m⁻¹ (mostrato a schermo come /m). Usare 0 per un rivelatore piano. È utile quando gli anelli ad alto angolo non coincidono, ad esempio con un rivelatore grande posto vicino al campione.

### Come si convertono i valori di inclinazione di altri software (come PIP)?

(β, Φ) di PIP si converte in (φ, τ) di IPAnalyzer = (270° − β, Φ). Per le definizioni vedere la [Panoramica](0-overview.md#relazione-con-winpip).

## Integrazione e output

### L'asse orizzontale del risultato sembra sbagliato / l'intensità sembra quasi costante

Verificare se nella scheda **Proprietà di integrazione (Integral Property)** della finestra delle proprietà è selezionata **Integrazione radiale (pattern a torta) (Radial integration (cake pattern))**. In questa modalità il profilo ha come asse orizzontale l'azimut χ. Il consueto profilo 2θ–intensità si ottiene con **Integrazione concentrica (dispersiva nell'angolo di scattering) (Concentric integration (scattering angle dispersive))**.

### Voglio salvare il profilo in un file senza PDIndexer

Nella scheda **Dopo "Ottieni profilo" (After "Get Profile")** della finestra delle proprietà, impostare in **Salva profilo (Save Profiles)** la destinazione (stessa cartella dell'immagine / scelta ogni volta) e il formato (PDI / CSV / TSV / GSAS). Il profilo viene quindi salvato a ogni integrazione.

### Che cos'è la terza colonna del CSV?

L'errore di conteggio dell'intensità, calcolato come radice quadrata dell'intensità dei pixel sommata in ciascun passo, trattata come conteggi. L'intensità nella seconda colonna è convertita nell'equivalente della geometria Bragg–Brentano, quindi non è uguale al quadrato della terza colonna. PDIndexer può mostrarlo come barre di errore.

### I valori di 2θ nel CSV hanno solo due cifre decimali. È il limite di precisione?

No. Sembra così solo perché l'integrazione è stata impostata, ad esempio, con un inizio di 20.00° e un passo di 0.01°. Il calcolo è eseguito in doppia precisione. La precisione del risultato è determinata dagli errori dei parametri di ingresso, come la lunghezza di camera e la lunghezza d'onda.

### Per le immagini sequenziali, conviene usare Media o Sommatoria?

Il rapporto S/N è lo stesso in entrambi i casi. **Sommatoria (Summation)** dà una stima corretta degli errori, quindi è consigliata per le analisi che usano gli errori, come l'affinamento di Rietveld.

### Voglio integrare per ciascun azimut (ciascun settore)

Attivare **Analisi a divisione azimutale (Azimuthal Division Analysis)** nel menu a discesa di **Ottieni profilo (Get Profile)**, impostare **Numero di divisioni (Number of divisions)** e integrare. Vengono creati un profilo complessivo (nome che termina con `-whole`) e un profilo per ciascun settore (con l'angolo iniziale aggiunto, come `-000`, `-010`, …). Funziona solo con **Integrazione concentrica (dispersiva nell'angolo di scattering) (Concentric integration (scattering angle dispersive))** e l'asse **Angolo (Angle)** (2θ); con l'integrazione radiale o con l'asse in distanza d viene mostrato un avviso e non viene eseguito nulla. Con troppe divisioni, i dati inviati a PDIndexer possono diventare troppo grandi.

### Voglio una mappa bidimensionale di 2θ e dell'azimut χ (immagine srotolata)

Usare **Srotola immagine (Unroll image)** nella barra degli strumenti. Impostare l'intervallo e il passo nella scheda **Opzioni immagine srotolata (Unrolled Image Option)** della finestra delle proprietà. Con **File → Salva immagine** (File → Save image), il formato TIFF conserva i valori in virgola mobile calcolati, mentre PNG salva ciò che è mostrato sullo schermo.

### Voglio la somma o la media dell'intensità di una parte rettangolare dell'immagine

Selezionare un rettangolo con Ctrl + trascinamento con il tasto destro sull'immagine. Le statistiche compaiono nella scheda **Informazioni statistiche (Statistical Information)** in basso. Per le immagini sequenziali, la stessa regione si può confrontare tra i frame.

### Un'immagine di buio diventa più luminosa verso i bordi ad alto angolo

Se in **Sorgente d'onda (Wave source)** nella finestra delle proprietà è attivo **Correggi polarizzazione lineare (cioè polarizzata linearmente → non polarizzata) (Correct linear polarization (i.e., linear polarized → unpolarized))**, la correzione viene applicata anche ai segnali che non provengono dai raggi X (corrente di buio, rumore elettronico), e il lato ad alto angolo diventa più luminoso. Disattivarlo per le immagini di buio.

### Voglio sottrarre un'immagine di buio (sfondo)

Nella scheda **Opzioni sfondo (Background Option)** della finestra delle proprietà, registrare l'immagine corrente come sfondo e impostare il coefficiente. Da quel momento viene sottratta automaticamente dalle immagini della stessa dimensione. Per i dettagli vedere [Finestre delle proprietà](2-property-windows.md).

## Elaborazione batch e macro

### Voglio integrare molti file in una volta

**Ottieni profili per tutte le immagini sequenziali (Get Profiles for all sequential images)** è per più frame contenuti in un unico file. Per elaborare più file, usare una [macro](5-macro/index.md). Gli [esempi](5-macro/2-examples.md) ne includono uno che integra in sequenza i file selezionati e salva file CSV. Prima di eseguirla, aprire un'immagine e caricare il file di parametri (vedere [la memorizzazione dei parametri](#dopo-aver-caricato-un-file-di-parametri-e-aperto-unimmagine-i-parametri-cambiano)).

### Voglio richiamare dal menu una macro usata spesso

Dare un nome alla macro e aggiungerla nell'editor delle macro; si potrà poi richiamarla dal menu **Macro** della finestra principale.

### Voglio integrare le immagini man mano che arrivano durante una misura

Monitorare la cartella con la [Procedura automatica (Auto procedure)](3-tools.md#procedura-automatica-auto-procedure). I file ancora in scrittura vengono letti al termine della scrittura; un file ancora bloccato dopo circa 50 s viene ritentato nelle scansioni successive e vi si rinuncia 10 minuti dopo che è stato trovato per la prima volta. Se la lettura non riesce per una cartella in rete, salvare sul disco locale del PC di misura e monitorare quella cartella.

## Segnalare un bug

### Che cosa inviare con una segnalazione di bug?

Spesso il problema non si riesce a riprodurre nell'ambiente dell'autore, quindi allegare:

- il file di parametri in uso in quel momento (**File → Salva parametro** (File → Save parameter)),
- il file di immagine con cui si è verificato il problema, e
- il messaggio di errore (va bene uno screenshot) e la versione di IPAnalyzer.

Effettuare la segnalazione tramite [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Fraintendimenti comuni

| Convinzione | In realtà |
|---|---|
| Prima si carica il file di parametri, poi si apre l'immagine | Aprendo un'immagine si passa ai valori memorizzati per il suo formato. Aprire prima l'immagine, poi caricare il file di parametri |
| **Ottieni profili per tutte le immagini sequenziali (Get Profiles for all sequential images)** elabora più file in una volta | È per più frame in un unico file. Per più file usare una macro |
| Per salvare un profilo serve PDIndexer | IPAnalyzer da solo può salvare in un file (scheda Dopo "Ottieni profilo" (After "Get Profile")) |
| La terza colonna del CSV è un altro profilo | È l'errore di conteggio dell'intensità |
| Sommatoria (Summation) migliora il rapporto S/N | Il rapporto S/N è lo stesso di Media (Average); cambia solo la stima dell'errore |
| La lunghezza di camera e la dimensione del pixel si possono determinare entrambe da un'immagine | Non insieme da una sola immagine; fissare la dimensione del pixel al valore di catalogo |
| Il capovolgimento e la rotazione cambiano solo la visualizzazione | Influiscono anche sull'integrazione e sul salvataggio dell'immagine |
| L'invio a PDIndexer applica al profilo una correzione di Lorentz-polarizzazione | PDIndexer considera la polarizzazione solo per le intensità delle linee di diffrazione calcolate; il profilo stesso non viene modificato |
