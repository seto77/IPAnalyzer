<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# Appendice A1. Geometria del rivelatore e trasformazioni di coordinate

Questa pagina definisce, con le equazioni, il **sistema di coordinate, la correzione dell'inclinazione dell'IP e la correzione della forma del pixel** che IPAnalyzer usa per associare le posizioni dei pixel su un rivelatore piano (IP, CCD/CMOS) agli angoli di diffrazione. Per una panoramica del sistema di coordinate, vedere anche la [pagina iniziale dell'appendice](index.md) e [0. Panoramica](../0-overview.md).

---

## Sistema di coordinate e parametri

Internamente IPAnalyzer usa in modo coerente un sistema di coordinate **destrorso**.

- Il punto in cui il fascio di raggi X o di elettroni interseca l'IP (lo **spot diretto**) è preso come origine $(0,0,0)$, e l'asse $Z$ è allineato con la direzione di propagazione del fascio.
- Considerando il campione infinitesimamente piccolo, la distanza tra il campione e l'origine è definita come **lunghezza di camera** $\mathrm{CL}$. La posizione del campione è quindi $(0,\ 0,\ -\mathrm{CL})$.
- L'asse $X$ è allineato con la direzione di scansione del laser di lettura quando l'IP non è inclinato (la direzione verso destra dell'immagine). L'asse $Y$ punta quindi verso il basso sullo schermo.
- Un anello di diffrazione con angolo del cono $2\theta$ si osserva, su un piano $XY$ non inclinato, come un cerchio perfetto di raggio $\mathrm{CL}\tan 2\theta$.

![Definizione del sistema di coordinate](../../assets/references/geometry-coordinate-system.png){width=520px}

La rotazione libera di un oggetto 3D richiede in sé tre assi, ma poiché la distribuzione degli anelli di Debye è invariante per rotazione attorno all'asse $Z$, l'asse $X$ si può scegliere arbitrariamente. Ciò elimina un grado di libertà, quindi l'inclinazione dell'IP si può esprimere con **due variabili** $\varphi,\ \tau$.

!!! note "Corrispondenza con (WIN)PIP"
    Il vecchio software PIP esprime l'inclinazione con una diversa coppia di angoli $(\beta,\ \Phi)$. La conversione da $(\beta,\ \Phi)$ a $(\varphi,\ \tau)$ di IPAnalyzer è $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Per i dettagli vedere "Relazione con (WIN)PIP" in [0. Panoramica](../0-overview.md).

---

## Correzione dell'inclinazione dell'IP

L'inclinazione dell'IP rispetto all'asse ottico (l'asse $Z$) è rappresentata da una rotazione il cui asse è una retta passante per l'origine e giacente nel piano $XY$. Questa rotazione si può scrivere come la matrice di rotazione $R = R_2\,R_1\,R_2^{-1}$, un'operazione che ruota di $\tau$ ($R_1$) attorno a un asse che è stato ruotato di $\varphi$ attorno all'asse $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Ciò equivale a una rotazione di angolo $\tau$ attorno al vettore unitario $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ che forma un angolo $\varphi$ con l'asse $X$ nel piano $XY$, e sviluppando si ottiene

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Trasformazione diretta (piano non inclinato → IP inclinato)

Un punto $P_1 = (X,\ Y,\ 0)$ sul piano $XY$ non inclinato corrisponde a $P_2 = R\,P_1$ sull'IP inclinato.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Proiezione (IP inclinato → piano non inclinato)

Ciò che serve in realtà è la direzione inversa, cioè la coordinata nel piano $XY$ che un "pixel osservato sull'IP inclinato" occuperebbe se non ci fosse inclinazione. Questa è data dalla **proiezione centrale (prospettica)** che trova il punto $P_3$ in cui la retta che congiunge un punto dell'IP inclinato e il campione $(0,0,-\mathrm{CL})$ interseca il piano $XY$. Poiché si tratta di una trasformazione proiettiva con il campione come centro di proiezione, si ottiene

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Poiché la correzione dell'inclinazione, che include la proiezione centrale, è una trasformazione proiettiva esprimibile come matrice in coordinate omogenee, la posizione di ogni pixel si può calcolare rapidamente al computer.

---

## Correzione della forma del pixel

La forma del pixel dell'IP è trattata come un **parallelogramma** di lunghezza $\mathrm{PixSizeX}$ lungo l'asse $X$, lunghezza $\mathrm{PixSizeY}$ lungo l'asse $Y$ e scostamento dall'angolo retto (angolo di distorsione) $\xi$. Un valore di $\xi$ diverso da zero indica uno scostamento nella posizione di inizio della scansione del laser di lettura, e questo software assume che tale scostamento sia costante lungo l'asse $Y$.

La coordinata reale $P$ del pixel che dista $\mathrm{PixNumX}$ nella direzione $X$ e $\mathrm{PixNumY}$ nella direzione $Y$, contando dal pixel centrale, è data da

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando questa correzione della forma del pixel con la correzione dell'inclinazione descritta sopra, qualsiasi pixel di un IP inclinato può essere associato alla sua posizione corretta sul piano $XY$ non inclinato. Questa associazione è la base della determinazione dei parametri del capitolo successivo e di [A3. Integrazione dell'immagine](a3-image-integration.md).
