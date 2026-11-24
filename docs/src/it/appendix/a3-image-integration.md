<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). -->

# Appendice A3. Integrazione dell'immagine

Quando si converte un'immagine 2D in un profilo 1D, il problema maggiore è **come distribuire l'intensità di un pixel che si estende su più passi quando l'ampiezza del passo angolare dell'integrazione è minore della spaziatura dei pixel (dimensione del pixel)**. IPAnalyzer gestisce questa distribuzione con un **metodo di distribuzione basato sulle aree**.

---

## Metodo di distribuzione basato sulle aree

In questo software, il programma calcola le intersezioni tra le linee che delimitano ciascun passo (i confini di uguale angolo di diffrazione) e i pixel, ricava l'**area** di ciascun pixel che ricade in un dato passo e distribuisce l'intensità in proporzione a tale area.

![Distribuzione basata sulle aree. Immagine reale degli anelli (a sinistra) → scala dei pixel (al centro, le linee verdi tratteggiate sono i confini dei passi) → intersezioni con i confini dei passi all'interno di un singolo pixel (a destra, aree delimitate dai quattro vertici e dalle intersezioni).](../../assets/references/integration-area-distribution.png){width=680px}

Questo metodo ha le seguenti caratteristiche.

- All'interno di ciascun pixel, l'arco del confine del passo è **approssimato con una retta**. Ciò si fa per la velocità di calcolo e in pratica non crea quasi mai problemi.
- Quando sono necessarie la correzione dell'inclinazione e la correzione della forma del pixel di [A1. Geometria del rivelatore](a1-geometry.md), la forma del pixel non è rigorosamente quadrata. Il software quindi **calcola in successione le coordinate dei quattro vertici del pixel** e ricava l'area come quella di un quadrilatero (in generale, un parallelogramma).

Con questo schema, in linea di principio, per quanto fine si renda il passo angolare, l'intensità del pixel viene distribuita uniformemente tra i passi.

---

## Ambito di applicazione

Lo stesso algoritmo di distribuzione basato sulle aree è usato per tutti e tre i seguenti tipi di integrazione.

| Funzione | Direzione di integrazione | Uso |
|------|-----------|------|
| **Integrazione concentrica (Concentric Integration)** | Angolo di diffrazione (direzione concentrica) | Creazione di un normale profilo $2\theta$-intensità. |
| **Integrazione radiale (Radial Integration)** | Direzione circonferenziale (azimutale) | Valutazione della dipendenza azimutale di un anello (orientazione, distorsione). |
| **Unrolled Image** | Angolo di diffrazione × azimut | Creazione di un'immagine srotolata 2D con l'anello tagliato e aperto. |

Per l'uso di ciascuna funzione, vedere [3. Strumenti](../3-tools.md).
