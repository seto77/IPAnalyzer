<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Finestra principale

La finestra principale è la prima schermata mostrata all'avvio di IPAnalyzer. Riunisce la visualizzazione dell'immagine di diffrazione caricata, le operazioni principali (ricerca del centro, mascheratura degli spot, integrazione in un profilo 1D) e i punti di accesso alle impostazioni dei parametri del rivelatore.

La finestra è composta, a grandi linee, dai menu e dalla barra degli strumenti in alto, dall'area di visualizzazione dell'immagine al centro, dalla barra degli strumenti verticale a destra e dall'area dei grafici in basso.

![La finestra principale di IPAnalyzer](../assets/cap-en-auto/FormMain.png)

## Vista centrale

### Visualizzazione dell'immagine

Qui viene visualizzata l'immagine caricata. In base alla posizione del puntatore del mouse, l'area sopra l'immagine mostra le coordinate reali (mm), le coordinate dell'immagine (pix), la distanza dal centro R (mm), l'angolo di scattering 2θ, il valore d, l'azimut χ e l'intensità. Il simbolo × magenta indica la posizione dello spot diretto (centro).

Gli stati dei pixel sono mostrati con colori distinti.

| Colore | Significato |
| --- | --- |
| Ciano | Spot mascherato |
| Verde | Regione esclusa dall'integrazione (impostata in Regione di integrazione (Integral Region)) |
| Magenta | Regione angolare esclusa dall'integrazione (impostata in Proprietà di integrazione (Integral Property)) |
| Blu | Pixel sotto la soglia di intensità (impostata in Regione di integrazione) |
| Rosso | Pixel sopra la soglia di intensità |

### Operazioni con il mouse

Nella modalità normale:

- Doppio clic sinistro: sposta la posizione del centro nel punto cliccato.
- Clic centrale: cerca il centro partendo dal punto cliccato.
- Trascinamento con il tasto destro: ingrandisce la regione trascinata.
- Clic destro: riduce l'ingrandimento.
- Ctrl + trascinamento con il tasto destro: seleziona la regione rettangolare usata per le informazioni statistiche.

Il doppio clic sinistro e il clic centrale funzionano solo quando **Fissa centro (Fix Center)** è disattivato.

In **Modalità manuale (Manual Mode)**, il clic sinistro maschera e il clic destro rimuove la maschera. La forma e la dimensione della maschera si impostano nella barra degli strumenti e nelle proprietà.

### Viste ausiliarie e informazioni sull'immagine

Accanto alla vista centrale si trovano delle visualizzazioni ausiliarie. Si può passare da **Immagine intera (Whole image)** a **Vicino al centro (Near center)** e viceversa: la vista dell'immagine intera indica con un riquadro giallo l'intervallo attualmente visualizzato, mentre la vista vicino al centro mostra un'immagine ingrandita.

**Informazioni immagine (Image Information)** mostra la risoluzione dell'immagine, l'intensità massima, l'intensità totale, i dati dell'intestazione e così via.

### Controlli di regolazione della visualizzazione

Controlli che regolano l'aspetto dell'immagine:

- **Gradiente (Gradient)**: inverte la tonalità.
- **Scala di luminosità (Brightness scale)**: logaritmica / lineare.
- **Scala di colore (Color scale)**: scala di grigi / colori.
- **Linea di scala (Scale line)**: visualizzazione delle linee di scala (nessuna / grossolana / media / fine).
- **Contrasto automatico (Auto Contrast)** / **Reimposta contrasto (Reset Contrast)**, e intensità minima/massima esplicite.
- Pulsanti di ingrandimento (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vista inferiore

L'area inferiore contiene tre grafici/viste a schede.

- **Frequenza dell'intensità (Frequency of Intensity)**: la distribuzione delle intensità di tutti i pixel, su assi log–log. Si può ingrandire con il mouse.
- **Profilo convertito (Converted Profile)**: il profilo di diffrazione prodotto da **Ottieni profilo (Get Profile)**. Si può ingrandire con il mouse.
- **Informazioni statistiche (Statistical Information)**: le statistiche della regione rettangolare (X1,Y1)–(X2,Y2) selezionata con Ctrl + trascinamento con il tasto destro sull'immagine. Quando è caricata un'immagine sequenziale, si possono confrontare anche le statistiche della stessa regione negli altri frame.

## Menu

La barra dei menu è composta da **File / Strumenti / Proprietà / Opzioni / Lingua / Macro / Guida** (File / Tool / Property / Option / Language / Macro / Help).

### File

- **Leggi immagine (Read image)**: apre un'immagine di diffrazione. Per i formati supportati vedere [Panoramica](0-overview.md).
- **Salva immagine (Save image)**: salva in formato TIFF, PNG, CSV o IPA. TIFF memorizza le intensità dei pixel elaborate correnti (dopo capovolgimento/rotazione, sottrazione dello sfondo e correzione della polarizzazione), PNG conserva la visualizzazione (luminosità, contrasto, maschera) e IPA è un formato proprietario con correzione della distorsione (con metadati).
- **Leggi parametro / Salva parametro (Read / Save parameter)**: importa/esporta in un file `.prm` la lunghezza d'onda, la lunghezza di camera, la dimensione del pixel, la correzione dell'inclinazione, la posizione del centro, ecc.
- **Leggi maschera / Salva maschera / Cancella maschera (Read / Save / Clear mask)**: importa/esporta una maschera in un file `.mas`, oppure la cancella (la maschera deve avere la stessa risoluzione dell'immagine corrente).
- **Chiudi (Close)**.

I file di immagine, di parametri e di maschera si possono caricare anche trascinandoli e rilasciandoli sulla finestra.

### Strumenti (Tool)

- **Reimposta profilo di frequenza (Reset Frequency Profile)**: ricostruisce con l'intervallo predefinito il grafico della frequenza delle intensità dell'immagine corrente (l'immagine viene mantenuta).
- **Calibra immagine R-AXIS (Calibrate Raxis Image)**: ricava una tabella di conversione delle intensità da due immagini R-AXIS (vedere [Strumenti](3-tools.md)).

### Proprietà (Property)

Sorgente di radiazione (Wave Source) / Condizione dell'imaging plate (Imaging Plate Condition) / Regione di integrazione (Integral Region) / Proprietà di integrazione (Integral Property) / Modalità maschera manuale (Manual Mask Mode) / Dopo "Ottieni profilo" (After "Get Profile") / Opzione immagine srotolata (Unrolled Image Option) / Varie (Miscellaneous). Queste voci aprono direttamente le schede corrispondenti della [finestra delle proprietà](2-property-windows.md).

### Opzioni (Option)

- **Suggerimento (ToolTip)**: attiva/disattiva i suggerimenti su pulsanti e menu.
- **Capovolgi (Flip)**: **Orizzontalmente (Horizontally)** / **Verticalmente (Vertically)**. **Ruota (Rotate)**: sceglie un angolo di rotazione. Il capovolgimento e la rotazione vengono applicati ai dati dell'immagine in lavorazione e quindi influiscono anche sulla successiva integrazione e sul salvataggio dell'immagine (il file di origine su disco non viene modificato).
- **Cancella registro (verifica e riavvia) (Clear registry (check and restart))**: una voce per la risoluzione dei problemi che cancella le impostazioni salvate.

### Lingua (Language)

- Seleziona la lingua di visualizzazione (11 lingue). Dopo la conferma l'applicazione si riavvia. L'impostazione viene salvata nel registro.

### Macro

- **Editor**: apre l'editor delle macro (vedere [Strumenti](3-tools.md) / [Macro](5-macro/index.md)).

### Guida (Help)

- **Aggiornamenti del programma (Program Updates)**, **Suggerimento (Hint)**, **Licenza (License)**, **Cronologia versioni (Version history)**, **Guida (Help)**.
- **Guida (Help)** apre questo manuale online nel browser web predefinito, come premendo **F1**.
- Premendo **F1** in qualsiasi finestra si apre la pagina corrispondente di questo manuale online.

## Barra degli strumenti delle operazioni

Le principali operazioni di elaborazione dell'immagine (con opzioni dettagliate nei menu a discesa):

- **Sfondo (Background)**: questo pulsante è disattivato nella versione attuale. La sottrazione di un'immagine di sfondo si configura nella scheda **Opzioni sfondo (Background Option)** della finestra delle proprietà.
- **Trova centro (Find Center)**: rileva il centro del fascio mediante un fitting Pseudo-Voigt 2D (l'intervallo di ricerca è per impostazione predefinita ±8 px attorno al centro, impostato nella scheda Varie). Quando gli anelli sono mostrati con **Disegna anello (Draw ring)**, il centro viene invece determinato dall'anello.
- **Fissa centro (Fix Center)**: fissa la posizione del centro.
- **Maschera spot (Mask Spots)**: all'interno di ciascuna banda radiale, i pixel la cui intensità supera media + deviazione standard × **Deviazione critica per "Maschera spot" (Criterial deviation for "Mask Spots")** (scheda Opzioni maschera) vengono rilevati come spot e mascherati insieme ai pixel circostanti. Il menu a discesa include **Maschera tutta l'area (Mask all area)**, **Inverti maschera (Invert mask)**, **Modalità manuale (Manual Mode)** e così via.
- **Modalità manuale (Manual Mode)**: la modalità di mascheratura manuale. Si può scegliere la forma della maschera (spot (cerchio/rettangolo) / cerchio / rettangolo / poligono / spline) e la dimensione dello spot (semilarghezza).
- **Ottieni profilo (Get Profile)**: integra l'immagine in un profilo 1D. Supporta l'**Integrazione concentrica (Concentric Integration)** (basata su 2θ) e l'**Integrazione radiale (Radial integration)** (basata sull'azimut). Il menu a discesa configura la scelta di Proprietà di integrazione/Regione di integrazione, se cercare il centro e mascherare gli spot prima dell'integrazione, l'invio a PDIndexer, l'**Analisi a divisione azimutale (Azimuthal Division Analysis)** (solo con l'integrazione concentrica e l'asse **Angolo (Angle)** (2θ); altrimenti viene mostrato un avviso e non viene eseguito nulla), l'elaborazione delle immagini sequenziali e così via.

## Barra degli strumenti (altri strumenti)

La barra degli strumenti verticale a destra avvia i vari strumenti. Per i dettagli vedere [Strumenti](3-tools.md).

- **Procedura automatica (Auto procedure)**
- **Disegna anello (Draw ring)**
- **Trova parametro (geometricamente) (Find parameter (geometrically))** / **Trova parametro (forza bruta) (Find parameter (brute force))**
- **Srotola immagine (Unroll image)**
- **Sfocatura circonferenziale (Circumferential blur)**
- **Immagine sequenziale (Sequential image)**
