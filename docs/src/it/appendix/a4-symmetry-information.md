<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendice A4. Symmetry Information

**Symmetry Information** mostra informazioni dettagliate sulla simmetria del gruppo spaziale del cristallo selezionato e, inoltre, disegna i diagrammi schematici degli elementi di simmetria e delle posizioni generali nello stile delle *International Tables for Crystallography* Vol. A.

In IPAnalyzer, questa finestra secondaria si apre dalla **Crystal window** (il CrystalControl utilizzato in [4. Procedure pratiche](../4-procedures.md) per la calibrazione geometrica e in [6. Trova parametri (forza bruta)](../6-find-parameter.md)).

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

La finestra è suddivisa in un'area di identità del gruppo spaziale (in alto a sinistra), un'area di calcolo/tabella con schede (in alto a destra) e due diagrammi schematici (in basso).

---

## Scorciatoie da tastiera e mouse

Questa finestra non ha combinazioni di tasti o mouse speciali. <kbd>F1</kbd> apre questa pagina del manuale e i due pulsanti **Copy** copiano negli appunti il diagramma degli elementi di simmetria e il diagramma delle posizioni generali (come bitmap, oppure come EMF vettoriale quando **EMF** è selezionato).

---

## Identità del gruppo spaziale

Il pannello in alto a sinistra elenca, per il gruppo spaziale corrente:

- **Number** (1–230) e l'indice di setting
- **Crystal System**
- **Point Group** : simboli di Hermann–Mauguin (HM) e Schoenflies (SF)
- **Space Group** : simbolo HM breve, simbolo HM completo, simbolo SF e **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Inserire due piani cristallini \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) oppure due indici di direzione \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) per ottenere:

- il d-spacing di ciascun piano / la lunghezza di ciascun asse,
- l'angolo tra i due piani (o i due assi),
- **l'indice di direzione normale a entrambi i piani** e **l'indice di piano normale a entrambi gli assi**.

Questi calcoli rispettano la metrica della cella elementare corrente.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Elenca ogni posizione di Wyckoff con la sua molteplicità, lettera di Wyckoff, simmetria del sito e se si tratta di una posizione generale o speciale. Per i reticoli centrati, i vettori di traslazione del reticolo sono mostrati nella riga di intestazione.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Le condizioni di riflessione derivanti dalla centratura del reticolo e dagli operatori di simmetria glide/screw.

---

## Diagrammi degli elementi di simmetria e delle posizioni generali

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

I due pannelli in basso riproducono i diagrammi schematici di simmetria del gruppo spaziale nella notazione delle *International Tables for Crystallography* Vol. A.

- **Symmetry elements (a sinistra)**: assi di rotazione/screw, piani di specchio/glide e centri di inversione/punti di rotoinversione sono disegnati con i simboli grafici convenzionali.
  - Per il reticolo \(F\) del sistema cubico, viene mostrato solo un ottavo della cella elementare (solo il quadrante in alto a sinistra).
- **General positions (a destra)**: le posizioni equivalenti generali sono rappresentate come cerchi (una virgola indica un'immagine speculare), annotate con le loro coordinate frazionarie.
  - Solo per il sistema cubico, linee ausiliarie collegano i tre cerchi correlati da un asse di rotazione ternario.

Controlli sotto i diagrammi:

- **Direction** (`a` / `b` / `c`) : scegliere l'asse cristallino lungo cui proiettare.
- **Copy** ciascun diagramma negli appunti come immagine vettoriale (**EMF**) o immagine raster (**BMP**); l'EMF può essere separato e modificato in PowerPoint.

---

## Vedi anche

- [Inizio appendice](index.md)
- [4. Procedure pratiche](../4-procedures.md) — calibrazione dei parametri geometrici tramite un cristallo di riferimento.
- [6. Trova parametri (forza bruta)](../6-find-parameter.md)
