<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Manuale di IPAnalyzer

## Breve introduzione

* **IPAnalyzer** è un software gratuito con licenza MIT che converte immagini bidimensionali di diffrazione di polveri (anelli di Debye–Scherrer) registrate con imaging plate (IP) o rivelatori a pannello piatto CCD/CMOS in profili 1D 2θ–intensità ad alta precisione.
* Calibra la geometria di misura — lunghezza di camera, lunghezza d'onda, inclinazione del rivelatore e forma del pixel — a partire dagli anelli di materiali di riferimento, supporta sorgenti a raggi X, elettroni e neutroni, e si integra con [PDIndexer](https://github.com/seto77/PDIndexer) per la successiva analisi dei picchi.
* Il suo design e le sue funzionalità seguono *PIP*, sviluppato da Hiroshi Fujihisa presso AIST.

## Trova per obiettivo

| Obiettivo | Inizia qui | Passi successivi principali |
|------|------------|-----------------|
| Comprendere il sistema di coordinate e la geometria | [Panoramica](0-overview.md) | [Finestre delle proprietà](2-property-windows.md) |
| Caricare un'immagine e ottenere un profilo 1D | [Procedure](4-procedures.md) | [Finestra principale](1-main-window.md), [Finestre delle proprietà](2-property-windows.md) |
| Calibrare lunghezza di camera / lunghezza d'onda | [Procedure](4-procedures.md) | [Strumenti](3-tools.md), [Trova parametri (forza bruta)](6-find-parameter.md) |
| Mascherare spot / gestire dati multiframe | [Strumenti](3-tools.md) | [Procedure](4-procedures.md) |
| Automatizzare l'elaborazione | [Macro](5-macro/index.md) | [Funzioni integrate](5-macro/1-built-in-functions.md), [Esempi](5-macro/2-examples.md), [Procedura automatica](3-tools.md) |
| Risoluzione dei problemi e domande frequenti | [Q&A](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## Funzionalità

* **Ampio supporto di formati** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4 e formati immagine generici. La maggior parte dell'I/O su file supporta il trascinamento e rilascio.
* **Conversione immagine-profilo** : calcolo concentrico (media radiale), radiale (azimutale/cake) e di immagine srotolata, con un algoritmo di distribuzione d'area sub-pixel che gestisce correttamente l'inclinazione del rivelatore e le forme di pixel a parallelogramma.
* **Calibrazione della geometria** : affinamento geometrico (a doppia cassetta) di lunghezza d'onda, lunghezza di camera, dimensione/distorsione del pixel e inclinazione (φ, τ), oltre a una ricerca esaustiva su griglia (forza bruta) per i dati difficili.
* **Gestione delle immagini** : rilevamento automatico del centro del fascio, rilevamento e mascheratura di spot di monocristallo, sfocatura circonferenziale, sovrapposizione di anelli, calibrazione delle intensità delle immagini R-AXIS e salvataggio IPA che preserva la geometria.
* **Dati multiframe** : selezione, media o somma dei frame di NeXus (`.nxs`), TIFF multipagina e altri dati sequenziali; quando un frame contiene informazioni sull'energia, selezionandolo si aggiorna la lunghezza d'onda.
* **Automazione** : Procedura automatica (Auto Procedure) con monitoraggio della cartella e una [macro](5-macro/index.md) con sintassi Python per l'elaborazione batch e tramite script.
* **Integrazione con PDIndexer** : invio dei profili a [PDIndexer](https://github.com/seto77/PDIndexer) tramite gli appunti e attivazione di macro denominate al suo interno.

## Requisiti di sistema

Questi requisiti valgono per le build .NET 11 ottenute da questo albero dei sorgenti. Per le release pubblicate, seguire il requisito di runtime indicato per ciascuna release.

| Voce | Minimo | Consigliato |
|------|---------|-------------|
| Sistema operativo | Windows con [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) | Windows 11 |
| Memoria | - | 16 GB o più |
| CPU | - | 8 o più core (le intensità dell'immagine sono conservate in doppia precisione e l'elaborazione è multithread) |

## Avvio rapido

1. Scaricare e installare da [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Leggere un'immagine di diffrazione (File → Leggi immagine (File → Read image), oppure trascinamento e rilascio).
3. Impostare la **Sorgente d'onda (Wave source)** e la **Condizione del rivelatore (Detector condition)** (lunghezza di camera, dimensione del pixel, centro approssimativo) nella finestra delle proprietà.
4. Se la geometria (lunghezza di camera, lunghezza d'onda, inclinazione) non è nota, calibrarla prima da un'immagine di un campione di riferimento e applicare i valori — vedere [Procedure](4-procedures.md).
5. Sull'immagine del campione, trovare il centro, mascherare gli spot se necessario e premere **Ottieni profilo (Get Profile)** per ottenere il profilo 1D.

Per il flusso di lavoro completo vedere [Procedure](4-procedures.md).

## Come usare questo manuale

Questo manuale su GitHub Pages è il riferimento attuale. Usare la navigazione a sinistra per sfogliare per capitolo, oppure la ricerca nell'intestazione per trovare il nome di una funzione o un'etichetta dell'interfaccia. Sostituisce il vecchio manuale Word/HTML/PDF distribuito in `IPAnalyzer/doc/`.

## Licenza

IPAnalyzer è distribuito con la [licenza MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
