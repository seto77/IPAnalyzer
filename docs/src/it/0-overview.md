<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Panoramica

IPAnalyzer converte gli anelli di Debye–Scherrer registrati con imaging plate (IP) o rivelatori CCD/CMOS in profili di diffrazione unidimensionali, con elevata precisione e velocità. Il suo design e le sue funzionalità sono modellati su PIP, sviluppato da Hiroshi Fujihisa presso il National Institute of Advanced Industrial Science and Technology (AIST).

Funzionalità principali:

- Supporta un'ampia gamma di formati di immagine (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon e formati di immagine generici)
- Sorgenti a raggi X, elettroni e neutroni
- Integrazione con PDIndexer
- Analisi semi-automatica dei parametri di misura

## Requisiti di sistema e installazione

### Requisiti

- OS: Windows (Windows 11 consigliato)
- Runtime richiesto: .NET Desktop Runtime 10.0
- Memoria consigliata: 16 GB o più
- CPU consigliata: 8 core o più

Internamente il software fa ampio uso di calcolo multi-thread, quindi una CPU con più core funziona in modo più confortevole. Le intensità delle immagini sono mantenute internamente come valori in virgola mobile a doppia precisione.

Il software è distribuito sotto licenza MIT.

### Installazione

1. Installare preventivamente [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Scaricare `IPAnalyzerSetup.msi` dalla [pagina delle release](https://github.com/seto77/IPAnalyzer/releases) su GitHub.
3. Eseguire `IPAnalyzerSetup.msi` per installare.

## Orientamento degli assi, inclinazione dell'IP e forma del pixel

IPAnalyzer utilizza un sistema di coordinate destrorso, con l'origine e le direzioni degli assi definite come segue.

- Il punto in cui il fascio di raggi X o di elettroni interseca l'IP (il direct spot) è definito come origine (0, 0, 0), e l'asse Z coincide con la direzione del fascio.
- Trattando la dimensione del campione come infinitesima, la distanza tra la posizione del campione e l'origine è definita come lunghezza di camera (Camera Length, CL). Il campione si trova quindi in \((0,\ 0,\ -\mathrm{CL})\).
- L'asse X è allineato con la direzione di scansione del laser di lettura dell'IP quando l'IP non è inclinato. L'asse Y punta quindi verso il basso sullo schermo.
- L'inclinazione dell'IP è espressa come una rotazione attorno a una retta giacente nel piano XY che passa per l'origine: una rotazione di \( \tau \) attorno alla retta che forma un angolo \( \varphi \) con l'asse X.
- La forma del pixel è trattata come un parallelogramma descritto da PixSizeX, PixSizeY e \( \xi \). Un \( \xi \) non nullo significa che esiste uno scostamento nella posizione iniziale della scansione del laser di lettura dell'IP. Il software assume che questo scostamento sia costante lungo l'asse Y.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

La lunghezza di camera, \( \varphi \), \( \tau \), la dimensione del pixel e \( \xi \) si impostano nella scheda IP Condition della finestra delle proprietà (vedere [2. Property Windows](2-property-windows.md)).

### Relazione con (WIN)PIP

In IPAnalyzer, l'asse X (la direzione verso destra dell'immagine IP) viene ruotato in senso orario di \( \varphi \), e l'asse risultante viene poi ruotato di \( \tau \). In PIP, l'asse Y (la direzione verso il basso dell'immagine IP) viene ruotato in senso antiorario di \( \beta \), e l'asse risultante viene poi ruotato di \( \Phi \). Pertanto, per convertire i valori \((\beta,\ \Phi)\) di PIP nei valori \((\varphi,\ \tau)\) di IPAnalyzer, usare \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Metodo di integrazione dell'intensità dei pixel

Il problema centrale nella riduzione a una dimensione è come distribuire, tra i passi di integrazione, l'intensità di un pixel che si estende su più passi — cosa che accade quando l'intervallo del passo angolare è più piccolo dell'intervallo del pixel (cioè della dimensione del pixel).

Il software calcola le intersezioni tra le rette che delimitano ciascun passo e il pixel, e distribuisce l'intensità individuando l'area del pixel contenuta in ciascun passo. Per gestire i casi in cui il pixel non è esattamente quadrato — a causa dell'inclinazione dell'IP o della distorsione della forma del pixel — le coordinate dei quattro angoli di ciascun pixel vengono calcolate in successione per determinarne la forma quadrilatera. In linea di principio, ciò consente di distribuire in modo regolare l'intensità del pixel tra i passi, per quanto piccoli essi vengano resi.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

Questo algoritmo è utilizzato non solo per l'ordinaria integrazione angolo–intensità (Concentric Integration), ma anche per l'integrazione lungo la circonferenza (Radial Integration) e per il calcolo dell'immagine srotolata (Unrolled Image).
