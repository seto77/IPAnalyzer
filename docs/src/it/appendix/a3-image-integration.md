<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Appendix A3. Image integration

Quando si converte un'immagine 2D in un profilo 1D, il problema più grande è **come distribuire l'intensità di un pixel che si estende su più step quando l'ampiezza dello step angolare dell'integrazione è inferiore alla spaziatura dei pixel (dimensione del pixel)**. IPAnalyzer gestisce questa distribuzione con un **metodo di distribuzione basato sull'area**.

---

## Metodo di distribuzione basato sull'area

In questo software, il programma calcola le intersezioni tra le linee che delimitano ciascuno step (i contorni di uguale angolo di diffrazione) e i pixel, ottiene l'**area** di ciascun pixel che ricade in un dato step e distribuisce l'intensità in proporzione a tale area.

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

Questo metodo ha le seguenti caratteristiche.

- All'interno di ciascun pixel, l'arco del contorno dello step viene **approssimato come una retta**. Ciò viene fatto per velocità di calcolo e quasi mai costituisce un problema nella pratica.
- Quando sono necessarie la correzione dell'inclinazione e la correzione della forma del pixel descritte in [A1. Detector geometry](a1-geometry.md), la forma del pixel non è rigorosamente quadrata. Il software quindi **calcola sequenzialmente le coordinate dei quattro angoli del pixel** e ottiene l'area come un quadrilatero (in generale, un parallelogramma).

Con questo schema, in linea di principio, per quanto fine venga reso lo step angolare, l'intensità del pixel viene distribuita in modo uniforme tra gli step.

---

## Ambito di applicazione

Lo stesso algoritmo di distribuzione basato sull'area viene utilizzato per tutti e tre i seguenti tipi di integrazione.

| Function | Direction of integration | Use |
|------|-----------|------|
| **Concentric Integration** | Angolo di diffrazione (direzione concentrica) | Creazione di un ordinario profilo $2\theta$-intensità. |
| **Radial Integration** | Direzione circonferenziale (azimutale) | Valutazione della dipendenza azimutale di un anello (orientazione, distorsione). |
| **Unrolled Image** | Angolo di diffrazione × azimut | Creazione di un'immagine srotolata 2D con l'anello aperto. |

Per la modalità d'uso di ciascuna funzione, vedere [3. Tools](../3-tools.md).
