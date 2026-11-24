<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Panoramica

IPAnalyzer converte gli anelli di Debye–Scherrer registrati con imaging plate (IP) o rivelatori CCD/CMOS in profili di diffrazione 1D, con alta precisione e velocità. Il suo design e le sue funzionalità sono modellati su PIP, sviluppato da Hiroshi Fujihisa presso il National Institute of Advanced Industrial Science and Technology (AIST).

Funzionalità principali:

- Supporto di un'ampia gamma di formati immagine (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`) e formati immagine generici)
- Sorgenti a raggi X, elettroni e neutroni
- Integrazione con PDIndexer
- Analisi semiautomatica dei parametri di misura

## Requisiti di sistema e installazione

### Requisiti

Questi requisiti valgono per le build .NET 11 ottenute da questo albero dei sorgenti. Per le release pubblicate, seguire il requisito di runtime indicato per ciascuna release.

- Sistema operativo: Windows (consigliato Windows 11)
- Runtime richiesto: .NET Desktop Runtime 11.0
- Memoria consigliata: 16 GB o più
- CPU consigliata: 8 core o più

Internamente il software fa largo uso di calcolo multithread, quindi una CPU con più core lo rende più scorrevole. Le intensità dell'immagine sono conservate internamente come valori in virgola mobile a doppia precisione.

Il software è distribuito con licenza MIT.

### Installazione

1. Scaricare dalla [pagina delle release](https://github.com/seto77/IPAnalyzer/releases/latest) su GitHub il file adatto al proprio PC.
    - `IPAnalyzer-setup.msi`: programma di installazione per i normali PC Windows (x64) (consigliato). `IPAnalyzerSetup.msi` è identico; quel nome è mantenuto per l'aggiornamento automatico dalle versioni precedenti.
    - `IPAnalyzer-setup_arm64.msi`: programma di installazione per Windows on Arm.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`: versione portatile (senza installazione; il runtime .NET è incluso), per i PC senza diritti di amministratore.
2. Per il programma di installazione, installare prima [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) e poi eseguire il file `.msi` scaricato.
3. Per la versione portatile, estrarre lo ZIP in una cartella scrivibile dall'utente ed eseguire `IPAnalyzer.exe` (non avviarlo dall'interno del visualizzatore ZIP).

## Orientamento degli assi, inclinazione dell'IP e forma del pixel

IPAnalyzer usa un sistema di coordinate destrorso, con l'origine e le direzioni degli assi definite come segue.

- Il punto in cui il fascio di raggi X o di elettroni interseca l'IP (lo spot diretto) è definito come origine (0, 0, 0), e l'asse Z coincide con la direzione del fascio.
- Considerando infinitesima la dimensione del campione, la distanza tra la posizione del campione e l'origine è definita come lunghezza di camera (Camera Length, CL). Il campione si trova quindi in \((0,\ 0,\ -\mathrm{CL})\).
- L'asse X è allineato con la direzione di scansione del laser di lettura dell'IP quando l'IP non è inclinato. L'asse Y punta quindi verso il basso sullo schermo.
- L'inclinazione dell'IP è espressa come una rotazione attorno a una retta giacente nel piano XY e passante per l'origine: una rotazione di \( \tau \) attorno alla retta che forma un angolo \( \varphi \) con l'asse X.
- La forma del pixel è trattata come un parallelogramma descritto da PixSizeX, PixSizeY e \( \xi \). Un valore di \( \xi \) diverso da zero indica uno scostamento nella posizione di inizio della scansione del laser di lettura dell'IP. Il software assume che questo scostamento sia costante lungo l'asse Y.

La lunghezza di camera, \( \varphi \), \( \tau \), la dimensione del pixel e \( \xi \) si impostano nella scheda **Condizione del rivelatore (Detector condition)** della finestra delle proprietà (vedere [2. Finestre delle proprietà](2-property-windows.md)).

### Relazione con (WIN)PIP

In IPAnalyzer, l'asse X (la direzione verso destra dell'immagine IP) viene ruotato in senso orario di \( \varphi \), e l'asse risultante viene poi ruotato di \( \tau \). In PIP, l'asse Y (la direzione verso il basso dell'immagine IP) viene ruotato in senso antiorario di \( \beta \), e l'asse risultante viene poi ruotato di \( \Phi \). Pertanto, per convertire \((\beta,\ \Phi)\) di PIP in \((\varphi,\ \tau)\) di IPAnalyzer, si usa \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Metodo di integrazione dell'intensità dei pixel

Il problema centrale nell'integrazione dell'immagine è come distribuire, tra i passi di integrazione, l'intensità di un pixel che si estende su più passi — cosa che accade ogni volta che l'intervallo di angoli di scattering coperto da un pixel abbraccia più di un passo in 2θ (tanto più spesso quanto più fine è il passo).

Il software calcola le intersezioni tra le linee che delimitano ciascun passo e il pixel, e distribuisce l'intensità determinando l'area del pixel contenuta in ciascun passo. Per gestire i casi in cui il pixel non è esattamente quadrato — a causa dell'inclinazione dell'IP o della distorsione della forma del pixel — le coordinate dei quattro vertici di ogni pixel vengono calcolate in successione per determinarne la forma quadrilatera. In linea di principio, ciò permette di distribuire uniformemente l'intensità del pixel tra i passi, per quanto piccoli essi siano.

Questo algoritmo è usato non solo per la normale integrazione angolo–intensità, Integrazione concentrica (Concentric Integration), ma anche per l'integrazione lungo la circonferenza, Integrazione radiale (Radial Integration), e per il calcolo dell'immagine srotolata (Unrolled Image).
