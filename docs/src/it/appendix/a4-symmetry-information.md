<!-- 261124Cl: Retranslated from en/appendix/a4-symmetry-information.md (UI labels follow the localized GUI). -->

# Appendice A4. Informazioni di simmetria

**Informazioni di simmetria (Symmetry Information)** mostra informazioni dettagliate sulla simmetria del gruppo spaziale del cristallo selezionato, e inoltre disegna i diagrammi schematici degli elementi di simmetria e delle posizioni generali nello stile delle *International Tables for Crystallography* Vol. A.

In IPAnalyzer questa sottofinestra si apre dalla **finestra del cristallo** (il CrystalControl usato in [4. Procedure](../4-procedures.md) per la calibrazione geometrica e in [6. Trova parametri (forza bruta)](../6-find-parameter.md)).

![Informazioni di simmetria](../../assets/cap-en-auto/FormSymmetryInformation.png)

La finestra è suddivisa in un'area di identificazione del gruppo spaziale (in alto a sinistra), un'area di calcolo/tabelle a schede (in alto a destra) e due diagrammi schematici (in basso).

---

## Scorciatoie da tastiera e mouse

Questa finestra non ha combinazioni speciali di tasti o mouse. <kbd>F1</kbd> apre questa pagina del manuale, e i due pulsanti **Copy** copiano negli appunti il diagramma degli elementi di simmetria e il diagramma delle posizioni generali (come bitmap, oppure come EMF vettoriale quando **EMF** è selezionato).

---

## Identificazione del gruppo spaziale

Il pannello in alto a sinistra elenca, per il gruppo spaziale corrente:

- **Number** (1–230) e l'indice di setting
- **Crystal System** (sistema cristallino)
- **Point Group** : simboli di Hermann–Mauguin (HM) e di Schoenflies (SF)
- **Space Group** : simbolo HM breve, simbolo HM completo, simbolo SF e **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Inserendo due piani cristallini \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) o due indici di direzione \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) si ottengono:

- la distanza interplanare di ciascun piano / la lunghezza di ciascun asse,
- l'angolo tra i due piani (o i due assi),
- **l'asse di zona comune a entrambi i piani** (la direzione della loro intersezione) e **il piano che contiene entrambe le direzioni**.

Questi calcoli tengono conto della metrica della cella elementare corrente.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Elenca ogni posizione di Wyckoff con la sua molteplicità, la lettera di Wyckoff, la simmetria del sito e se si tratta di una posizione generale o speciale. Per i reticoli centrati, i vettori di traslazione del reticolo sono mostrati nella riga di intestazione.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Le condizioni di riflessione derivanti dalla centratura del reticolo e dagli operatori di simmetria di slittamento/elicoidali.

---

## Diagrammi degli elementi di simmetria e delle posizioni generali

![Diagrammi degli elementi di simmetria e delle posizioni generali](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

I due pannelli in basso riproducono i diagrammi schematici di simmetria del gruppo spaziale nella notazione delle *International Tables for Crystallography* Vol. A.

- **Elementi di simmetria (a sinistra)**: assi di rotazione/elicoidali, piani di specchio/di slittamento e centri di inversione/punti di rotoinversione sono disegnati con i simboli grafici convenzionali.
  - Per il reticolo \(F\) del sistema cubico, viene mostrato solo un ottavo della cella elementare (solo il quadrante superiore sinistro).
- **Posizioni generali (a destra)**: le posizioni equivalenti generali sono rappresentate come cerchi (una virgola indica un'immagine speculare), annotati con le loro coordinate frazionarie.
  - Solo per il sistema cubico, linee ausiliarie collegano i tre cerchi legati da un asse di rotazione ternario.

Controlli sotto i diagrammi:

- **Direction** (`a` / `b` / `c`) : sceglie l'asse cristallino lungo il quale proiettare.
- **Copy** copia ciascun diagramma negli appunti come immagine vettoriale (**EMF**) o immagine raster (**BMP**); l'EMF si può separare e modificare in PowerPoint.

---

## Vedere anche

- [Pagina iniziale dell'appendice](index.md)
- [4. Procedure](../4-procedures.md) — calibrazione geometrica dei parametri mediante un cristallo di riferimento.
- [6. Trova parametri (forza bruta)](../6-find-parameter.md)
