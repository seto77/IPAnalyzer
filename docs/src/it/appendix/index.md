<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). -->

# Appendice

Questa appendice riassume il **fondamento teorico della geometria e degli algoritmi** che IPAnalyzer usa per convertire un'immagine di diffrazione bidimensionale (anelli di Debye–Scherrer) in un profilo unidimensionale ad alta precisione. Per le procedure operative e l'uso di ciascuna funzionalità, fare riferimento al manuale principale ([0. Panoramica](../0-overview.md), [4. Procedure](../4-procedures.md), ecc.). Qui si spiegano, con le equazioni, le definizioni del sistema di coordinate, le trasformazioni di coordinate, i metodi di determinazione dei parametri e l'algoritmo di integrazione che ne stanno alla base.

Il contenuto si basa sul vecchio documento `doc/IPAnalyzerAlgorithm.pdf` incluso nel pacchetto di distribuzione e sull'implementazione attuale.

## Struttura dell'appendice

- **[A1. Geometria del rivelatore e trasformazioni di coordinate](a1-geometry.md)** — definizione del sistema di coordinate destrorso, matrici di rotazione che descrivono l'inclinazione dell'IP ($\varphi,\ \tau$) e correzione della forma del pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Determinazione dei parametri](a2-calibration.md)** — calibrazione della lunghezza di camera, della lunghezza d'onda, della dimensione del pixel e dell'inclinazione dell'IP mediante un materiale di riferimento (metodo delle due distanze, metodo delle due linee, fitting di ellissi).
- **[A3. Integrazione dell'immagine](a3-image-integration.md)** — l'algoritmo di ripartizione delle aree che distribuisce le intensità dei pixel nei passi angolari.
- **[A4. Informazioni di simmetria](a4-symmetry-information.md)** — simmetria del gruppo spaziale, calcoli geometrici, posizioni di Wyckoff, condizioni di riflessione e diagrammi degli elementi di simmetria del cristallo di riferimento (una sottofinestra della finestra del cristallo).
- **[A5. Fattore di diffusione](a5-scattering-factor.md)** — fattori di struttura ed elenco delle riflessioni del cristallo di riferimento (raggi X, elettroni, neutroni) (una sottofinestra della finestra del cristallo).

## Sistema di coordinate (figura di riferimento comune)

Ciascuna delle pagine seguenti assume come premessa comune lo stesso sistema di coordinate. L'origine è lo spot diretto sull'IP (il punto in cui il fascio interseca l'IP), l'asse $Z$ è la direzione di propagazione del fascio e il campione si trova in $(0,\ 0,\ -\mathrm{CL})$.

![Sistema di coordinate di IPAnalyzer. Mostra l'IP (imaging plate), gli assi X / Y / Z, gli anelli di Debye, gli angoli di inclinazione φ e τ, il campione in (0,0,−CL), la lunghezza di camera CL, l'angolo di diffrazione 2θ, la lunghezza d'onda λ e la forma del pixel (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parametri principali

| Simbolo | Nome | Significato |
|------|------|------|
| $\lambda$ | Lunghezza d'onda (Wave Length) | Lunghezza d'onda della sorgente. È nota per i raggi X caratteristici; per la radiazione di sincrotrone varia con la posizione del monocromatore e deve essere determinata ogni volta. |
| $\mathrm{CL}$ | Lunghezza camera (Camera Length) | Distanza tra il campione e l'origine (spot diretto). La posizione del campione è $(0,0,-\mathrm{CL})$. Corrisponde a **Lunghezza camera 1 (Camera Length 1)** sullo schermo; **Lunghezza camera 2 (Camera Length 2)** è la distanza perpendicolare campione–rivelatore, che differisce quando c'è un'inclinazione $\tau$. |
| $\varphi,\ \tau$ | Correzione inclinazione (Tilt Correction) | Inclinazione dell'IP rispetto all'asse ottico (asse $Z$). $\varphi$ è l'azimut dell'asse di inclinazione nel piano XY, e $\tau$ è l'angolo di rotazione attorno a quell'asse. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Dimensione pixel (Pixel Size) | Rappresenta un pixel come un parallelogramma. $\xi$ è lo scostamento del punto di inizio della scansione del laser di lettura (angolo di distorsione). |

La lunghezza d'onda si imposta nella scheda **Sorgente d'onda (Wave source)** della finestra delle proprietà, mentre la lunghezza di camera, l'inclinazione e la forma del pixel nella scheda **Condizione del rivelatore (Detector condition)** (vedere [2. Finestre delle proprietà](../2-property-windows.md)).
