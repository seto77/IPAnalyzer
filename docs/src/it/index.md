<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# Manuale di IPAnalyzer

## Breve introduzione

* **IPAnalyzer** è un software gratuito con licenza MIT che converte immagini bidimensionali di diffrazione di polveri (anelli di Debye–Scherrer) registrate con imaging plate (IP) o rivelatori a pannello piatto CCD/CMOS in profili unidimensionali 2θ–intensità ad alta precisione.
* Calibra la geometria di misura — lunghezza di camera, lunghezza d'onda, inclinazione del rivelatore e forma del pixel — a partire dagli anelli di materiali di riferimento, supporta sorgenti a raggi X, elettroni e neutroni, e si integra con [PDIndexer](https://github.com/seto77/PDIndexer) per la successiva analisi dei picchi.
* Il suo design e le sue funzionalità seguono *PIP*, sviluppato da Hiroshi Fujihisa presso AIST.

## Trova per obiettivo

| Obiettivo | Inizia qui | Passi successivi principali |
|------|------------|-----------------|
| Comprendere il sistema di coordinate e la geometria | [Panoramica](0-overview.md) | [Finestre delle proprietà](2-property-windows.md) |
| Caricare un'immagine e ottenere un profilo 1D | [Procedure](4-procedures.md) | [Finestra principale](1-main-window.md), [Finestre delle proprietà](2-property-windows.md) |
| Calibrare lunghezza di camera / lunghezza d'onda | [Procedure](4-procedures.md) | [Strumenti](3-tools.md), [Trova parametri (forza bruta)](6-find-parameter.md) |
| Mascherare spot / gestire dati multiframe | [Strumenti](3-tools.md) | [Procedure](4-procedures.md) |
| Automatizzare l'elaborazione | [Macro](5-macro/index.md) | [Funzioni integrate](5-macro/1-built-in-functions.md), [Esempi](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Funzionalità

* **Ampio supporto di formati** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4 e formati immagine generici. La maggior parte dell'I/O su file supporta il drag & drop.
* **Conversione immagine-profilo** : Calcolo concentrico (media radiale), radiale (azimutale/cake) e di immagine srotolata, usando un algoritmo di distribuzione d'area sub-pixel che gestisce correttamente l'inclinazione del rivelatore e le forme di pixel a parallelogramma.
* **Calibrazione della geometria** : Affinamento geometrico (a doppia cassetta) di lunghezza d'onda, lunghezza di camera, dimensione/distorsione del pixel e inclinazione (φ, τ), oltre a una ricerca esaustiva su griglia (forza bruta) per i dati difficili.
* **Gestione delle immagini** : Rilevamento automatico del centro del fascio, rilevamento e mascheratura di spot di monocristallo, sfocatura circonferenziale, sovrapposizioni di anelli, calibrazione del rivelatore tramite tabella di intensità e salvataggio IPA che preserva la geometria.
* **Dati multiframe** : Selezione, media o somma di frame di dati HDF5/NeXus e altri dati sequenziali, con lunghezza d'onda per frame ricavata dall'energia incorporata.
* **Automazione** : Auto Procedure con monitoraggio della cartella e una [macro](5-macro/index.md) con sintassi Python per l'elaborazione batch e scriptata.
* **Integrazione con PDIndexer** : Invio di profili a [PDIndexer](https://github.com/seto77/PDIndexer) tramite gli appunti e attivazione di macro denominate al suo interno.
* **Tema chiaro / scuro** : L'interfaccia segue una modalità colore chiara o scura selezionabile.

## Requisiti di sistema

| Voce | Minimo | Consigliato |
|------|---------|-------------|
| OS | Windows con [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Memoria | - | 16 GB o più |
| CPU | - | 8+ core (le intensità dell'immagine sono mantenute in doppia precisione e l'elaborazione è multi-thread) |

## Avvio rapido

1. Scarica e installa da [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Leggi un'immagine di diffrazione (File → Read image, oppure drag & drop).
3. Imposta **Wave source** e **Detector condition** (lunghezza di camera, dimensione del pixel, centro approssimativo) nella finestra delle proprietà.
4. Trova il centro, maschera gli spot se necessario e premi **Get Profile** per ottenere il profilo 1D.
5. Se la geometria è sconosciuta, calibrala a partire da un materiale di riferimento — vedi [Procedure](4-procedures.md).

Vedi [Procedure](4-procedures.md) per il flusso di lavoro completo.

## Come usare questo manuale

Questo manuale su GitHub Pages è la fonte di riferimento attuale. Usa la navigazione a sinistra per sfogliare per capitolo, oppure usa la ricerca nell'intestazione per trovare il nome di una funzione o un'etichetta dell'interfaccia. Sostituisce il vecchio manuale Word/HTML/PDF distribuito in `IPAnalyzer/doc/`.

## Licenza

IPAnalyzer è distribuito sotto la [Licenza MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
