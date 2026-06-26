<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Appendice A1. Geometria del rivelatore e trasformazioni di coordinate

Questa pagina definisce, con equazioni, il **sistema di coordinate, la correzione dell'inclinazione dell'IP e la correzione della forma del pixel** che IPAnalyzer utilizza per mappare le posizioni dei pixel su un rivelatore piatto (IP, CCD/CMOS) agli angoli di diffrazione. Per una panoramica del sistema di coordinate, si vedano anche la [pagina iniziale dell'appendice](index.md) e la [0. Panoramica](../0-overview.md).

---

## Sistema di coordinate e parametri

IPAnalyzer utilizza internamente in modo coerente un sistema di coordinate **destrorso**.

- Il punto in cui il fascio di raggi X o di elettroni interseca l'IP (lo **spot diretto**) è preso come origine $(0,0,0)$, e l'asse $Z$ è allineato con la direzione di propagazione del fascio.
- Trattando il campione come infinitamente piccolo, la distanza tra il campione e l'origine è definita come **lunghezza di camera** $\mathrm{CL}$. La posizione del campione è quindi $(0,\ 0,\ -\mathrm{CL})$.
- L'asse $X$ è allineato con la direzione di scansione del laser di lettura quando l'IP non è inclinato (la direzione verso destra dell'immagine). L'asse $Y$ punta quindi verso il basso sullo schermo.
- Un anello di diffrazione con angolo del cono $2\theta$ viene osservato, su un piano $XY$ non inclinato, come un cerchio perfetto di raggio $\mathrm{CL}\tan 2\theta$.

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

La rotazione libera di un oggetto 3D richiede intrinsecamente tre assi, ma poiché la distribuzione dell'anello di Debye è invariante rispetto alla rotazione attorno all'asse $Z$, l'asse $X$ può essere scelto arbitrariamente. Ciò elimina un grado di libertà, cosicché l'inclinazione dell'IP può essere espressa con **due variabili** $\varphi,\ \tau$.

!!! note "Correspondence with (WIN)PIP"
    Il software legacy PIP esprime l'inclinazione con una coppia di angoli diversa $(\beta,\ \Phi)$. La conversione da $(\beta,\ \Phi)$ ai $(\varphi,\ \tau)$ di IPAnalyzer è $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Per i dettagli, si veda "Relationship with (WIN)PIP" in [0. Panoramica](../0-overview.md).

---

## Correzione dell'inclinazione dell'IP

L'inclinazione dell'IP rispetto all'asse ottico (l'asse $Z$) è rappresentata da una rotazione il cui asse è una retta passante per l'origine e giacente nel piano $XY$. Questa rotazione può essere scritta come la matrice di rotazione $R = R_2\,R_1\,R_2^{-1}$, un'operazione che ruota di $\tau$ attorno a ($R_1$) un asse che è stato ruotato di $\varphi$ attorno all'asse $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Ciò equivale a una rotazione di angolo $\tau$ attorno al versore $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ che forma un angolo $\varphi$ con l'asse $X$ nel piano $XY$, e sviluppando si ottiene

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Trasformazione diretta (piano non inclinato → IP inclinato)

Un punto $P_1 = (X,\ Y,\ 0)$ sul piano $XY$ non inclinato viene mappato in $P_2 = R\,P_1$ sull'IP inclinato.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Proiezione (IP inclinato → piano non inclinato)

Ciò che serve effettivamente è la direzione inversa, ovvero la coordinata sul piano $XY$ che un "pixel osservato sull'IP inclinato" occuperebbe se non vi fosse alcuna inclinazione. Questa è data dalla **proiezione centrale (prospettica)** che trova il punto $P_3$ in cui la retta che congiunge un punto sull'IP inclinato e il campione $(0,0,-\mathrm{CL})$ interseca il piano $XY$. Poiché si tratta di una trasformazione proiettiva con il campione come centro di proiezione,

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

ne risulta. Poiché l'intera correzione dell'inclinazione è una trasformazione lineare (proiettiva in coordinate omogenee), la posizione di ciascun pixel può essere calcolata rapidamente su un computer.

---

## Correzione della forma del pixel

La forma del pixel dell'IP è trattata come un **parallelogramma** con lunghezza $\mathrm{PixSizeX}$ lungo l'asse $X$, lunghezza $\mathrm{PixSizeY}$ lungo l'asse $Y$ e una deviazione dall'angolo retto (angolo di distorsione) $\xi$. Un $\xi$ non nullo significa che vi è uno scostamento nella posizione iniziale della scansione del laser di lettura, e questo software assume che tale scostamento sia costante lungo l'asse $Y$.

La coordinata effettiva $P$ del pixel che dista $\mathrm{PixNumX}$ nella direzione $X$ e $\mathrm{PixNumY}$ nella direzione $Y$, contando a partire dal pixel centrale, è data da

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando questa correzione della forma del pixel con la correzione dell'inclinazione descritta sopra, qualsiasi pixel su un IP inclinato può essere mappato nella sua posizione corretta sul piano $XY$ non inclinato. Questa mappatura è la base per la determinazione dei parametri nel capitolo successivo e per la [A3. Integrazione dell'immagine](a3-image-integration.md).
