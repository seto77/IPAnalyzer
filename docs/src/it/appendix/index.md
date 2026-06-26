<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Appendice

Questa appendice riassume il **contesto teorico della geometria e degli algoritmi** che IPAnalyzer utilizza per convertire un'immagine di diffrazione bidimensionale (anelli di Debye–Scherrer) in un profilo unidimensionale ad alta accuratezza. Per le procedure operative e per l'uso di ciascuna funzione, fare riferimento al manuale principale ([0. Panoramica](../0-overview.md), [4. Procedure pratiche](../4-procedures.md), ecc.). Qui spieghiamo, con equazioni, le definizioni del sistema di coordinate, le trasformazioni di coordinate, i metodi di determinazione dei parametri e l'algoritmo di integrazione che ne stanno alla base.

Il contenuto si basa sul documento storico `doc/IPAnalyzerAlgorithm.pdf` incluso nel pacchetto di distribuzione e sull'implementazione attuale.

## Struttura dell'appendice

- **[A1. Geometria del rivelatore e trasformazioni di coordinate](a1-geometry.md)** — definizione del sistema di coordinate destrorso, le matrici di rotazione che descrivono l'inclinazione dell'IP ($\varphi,\ \tau$) e la correzione della forma del pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Determinazione dei parametri](a2-calibration.md)** — calibrazione della lunghezza di camera, della lunghezza d'onda, della dimensione del pixel e dell'inclinazione dell'IP usando un materiale di riferimento (metodo a due distanze, metodo a due linee, fitting di ellisse).
- **[A3. Integrazione dell'immagine](a3-image-integration.md)** — l'algoritmo di partizionamento delle aree che distribuisce le intensità dei pixel negli step angolari.
- **[A4. Informazioni di simmetria](a4-symmetry-information.md)** — simmetria del gruppo spaziale, calcoli geometrici, posizioni di Wyckoff, condizioni di riflessione e diagrammi degli elementi di simmetria del cristallo di riferimento (una sotto-finestra della finestra Crystal).
- **[A5. Fattore di diffusione](a5-scattering-factor.md)** — fattori di struttura e lista delle riflessioni del cristallo di riferimento (raggi X, elettroni, neutroni) (una sotto-finestra della finestra Crystal).

## Sistema di coordinate (figura di riferimento comune)

Ciascuna delle pagine seguenti assume lo stesso sistema di coordinate come premessa comune. L'origine è il direct spot sull'IP (il punto in cui il fascio interseca l'IP), l'asse $Z$ è la direzione di propagazione del fascio e il campione si trova in $(0,\ 0,\ -\mathrm{CL})$.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parametri principali

| Simbolo | Nome | Significato |
|------|------|------|
| $\lambda$ | Wave Length | Lunghezza d'onda della sorgente. Nota per i raggi X caratteristici; per la radiazione di sincrotrone varia con la posizione del monocromatore e deve essere determinata ogni volta. |
| $\mathrm{CL}$ | Camera Length | Distanza tra il campione e l'origine (direct spot). La posizione del campione è $(0,0,-\mathrm{CL})$. |
| $\varphi,\ \tau$ | Tilt Correction | Inclinazione dell'IP rispetto all'asse ottico (asse $Z$). $\varphi$ è l'azimut dell'asse di inclinazione nel piano XY e $\tau$ è l'angolo di rotazione attorno a tale asse. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | Rappresenta un pixel come un parallelogramma. $\xi$ è l'offset del punto di partenza della scansione del laser di lettura (angolo di distorsione). |

Questi valori vengono impostati nella scheda IP Condition della finestra delle proprietà (vedere [2. Finestre delle proprietà](../2-property-windows.md)).
