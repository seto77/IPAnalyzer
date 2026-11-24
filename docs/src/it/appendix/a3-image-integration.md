<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

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

Lo stesso algoritmo di distribuzione basato sulle aree è usato per tutti e tre i seguenti tipi di integrazione. Essi differiscono per la coordinata che rimane sull'asse orizzontale dell'output e per i pixel che vengono riuniti in un unico punto dell'output.

| Funzione | Asse orizzontale dell'output | Pixel riuniti in un punto dell'output | Uso |
|------|------|------|------|
| **Integrazione concentrica (Concentric integration)** | Angolo di diffrazione $2\theta$ (o distanza d) | Quelli entro un passo di $2\theta$ (o di d), su tutti gli azimut all'interno della regione di integrazione | Creazione di un normale profilo $2\theta$-intensità. |
| **Integrazione radiale (Radial integration)** | Azimut $\chi$ | Quelli entro un passo azimutale (**Passo angolo settore (passo scansione) (Sector angle step (Sweep step))**), all'interno dell'anello dato da **Raggio ciambella (Donut radius)** ± **Larghezza ciambella (Donut width)** | Valutazione della dipendenza azimutale di un anello (orientazione, distorsione). |
| **Unrolled image** | $2\theta$ (orizzontale) × azimut $\chi$ (verticale) | Quelli entro un passo di $2\theta$ e un settore azimutale ($360^\circ/N$) | Creazione di un'immagine srotolata 2D con l'anello tagliato e aperto. |

In ogni caso vengono usati solo i pixel validi: i pixel mascherati e quelli esclusi nella scheda **Regione di integrazione (Integral Region)** non contribuiscono.

---

## Normalizzazione dopo l'integrazione

Le intensità distribuite vengono normalizzate in modo diverso a seconda della funzione.

- **Integrazione concentrica** (rivelatore a pannello piatto, asse $2\theta$ o distanza d) e **Unrolled image** (immagine srotolata): per ciascun passo (ciascun pixel dell'immagine srotolata), le intensità distribuite vengono sommate e la somma viene divisa per la quantità che ha contribuito a quel passo. Il contributo di ciascuna parte di un pixel è misurato dalla sua area proiettata sul piano perpendicolare al raggio diffuso alla distanza della lunghezza di camera, cioè dall'angolo solido che sottende, contato in unità di un pixel visto frontalmente alla lunghezza di camera. Il risultato è quindi un'intensità media per unità di angolo solido: non dipende dall'ampiezza del passo né da quanti pixel ricadono in un passo, e la diminuzione dell'angolo solido per pixel verso gli alti angoli su un rivelatore piano viene compensata. Un passo che non riceve alcun pixel vale 0.
- **Integrazione radiale**: le intensità distribuite vengono semplicemente sommate per ciascun passo azimutale e non vengono divise. I valori crescono quindi con la larghezza dell'anello (**Larghezza ciambella (Donut width)**) e con il passo azimutale.

Per l'uso di ciascuna funzione, vedere [3. Strumenti](../3-tools.md).
