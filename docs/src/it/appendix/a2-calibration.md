<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Appendix A2. Parameter determination

Poiché la posizione di ogni pixel è governata dalla geometria di [A1. Detector geometry](a1-geometry.md), l'uso di parametri errati comporta la lettura delle intensità in posizioni sbagliate. Questa pagina spiega come determinare i parametri reali — lunghezza di camera, lunghezza d'onda, dimensione del pixel e inclinazione dell'IP — a partire dagli anelli di diffrazione di un **materiale di riferimento**. Per le operazioni effettive, vedere [4. Practical procedures](../4-procedures.md) e [6. Parameter calibration (brute force)](../6-find-parameter.md).

---

## Standard material

Per la calibrazione si misura un materiale di riferimento le cui costanti reticolari siano note. Le condizioni desiderabili sono **molti anelli di diffrazione** con un **alto rapporto SN**, posizionati in modo **rado** e **senza orientazione preferenziale**. Salvo preferenze particolari, si raccomanda un cristallo cubico contenente atomi pesanti come $\mathrm{CeO_2}$ o $\mathrm{Ag}$. Le costanti reticolari devono essere note a circa 5 cifre significative.

---

## Camera length — two-distance method

La lunghezza di camera $\mathrm{CL}$ è definita come la distanza che collega il campione e lo spot diretto sull'IP. Se si acquisiscono due pattern di diffrazione variando la lunghezza di camera di $\Delta$, è possibile determinare il valore assoluto di $\mathrm{CL}$ dalla variazione del raggio (in pixel) $r_1,\ r_2$ dello stesso anello. La differenza di distanza $\Delta$ può essere controllata accuratamente con un Magnescale o un dispositivo analogo.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

Dai triangoli simili $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

si ottiene. Qui $r_1,\ r_2$ possono restare in unità di pixel, e la lunghezza di camera può essere ricavata anche se la correzione dell'inclinazione e la correzione della dimensione del pixel sono in qualche misura imprecise, e anche se le costanti reticolari del riferimento sono imprecise. Poiché la lunghezza di camera ha quindi scarsa correlazione con gli altri parametri, è il **parametro che dovrebbe essere determinato per primo**.

---

## Wavelength and pixel size — two-line method

Se si possono registrare due linee di diffrazione, gli angoli di diffrazione $\theta_1,\ \theta_2$ possono essere calcolati dal rapporto delle loro posizioni di picco (in pixel) $p_1,\ p_2$ e dalle loro d-spacing $d_1,\ d_2$, senza conoscere la dimensione del pixel o la lunghezza di camera. Sia il rapporto delle d-spacing $\rho_d = d_1/d_2$ e il rapporto delle posizioni di picco $\rho_p = p_1/p_2$.

Dalla legge di Bragg e dalla geometria del rivelatore piatto,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

valgono. Dal rapporto della prima equazione, $\sin\theta_2 = \rho_d \sin\theta_1$, e dal rapporto della seconda equazione, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Sostituendo $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ si ottiene un'equazione la cui unica incognita è $\sin\theta_1$:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Questa si riduce a un'equazione cubica in $\sin^2\theta_1$. Poiché risolverla analiticamente richiederebbe la gestione di numeri immaginari, questo software la risolve **numericamente** per ottenere il valore. Dato che $\rho_d$ è un rapporto di d-spacing, può essere determinato senza errore a seconda della simmetria del cristallo (per esempio, nel sistema cubico).

Una volta ottenuti gli angoli di diffrazione, la lunghezza di camera può essere determinata indipendentemente con il two-distance method descritto sopra, quindi anche la lunghezza d'onda $\lambda$ e la dimensione del pixel $\mathrm{PixSize}$ possono essere calcolate facilmente dalle due equazioni precedenti.

!!! note "When there is a tilt"
    Se l'IP è inclinato, la relazione $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ non è più valida, perciò i valori accurati non possono essere ottenuti così come sono. In questo caso, **eseguire alternativamente la correzione dell'inclinazione e la correzione della lunghezza d'onda** per far convergere iterativamente la soluzione verso il valore reale.

---

## IP tilt — ellipse fitting

Un anello con angolo di cono $2\theta$ dovrebbe essere osservato come un cerchio perfetto di raggio $R_0 = \mathrm{CL}\tan 2\theta$ su un piano $XY$ non inclinato. Su un IP inclinato, tuttavia, l'anello diventa un'**ellisse**, e inoltre il suo centro non coincide con il centro del fascio (lo spot diretto).

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Su un piano IP inclinato di $\varphi,\ \tau$, un punto $(x,y)$ sull'anello soddisfa una conica generale (ellisse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

I coefficienti $A,B,C,D,E$ possono essere scritti come funzioni di $\varphi,\ \tau,\ \mathrm{CL},\ R_0$, e possono essere trattati con algebra lineare elementare come segue.

- Il **centro dell'ellisse** $(x_c, y_c)$ è la soluzione della condizione che il gradiente si annulli, ossia il sistema di equazioni lineari
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Le **direzioni e lunghezze degli assi maggiore e minore** si ottengono risolvendo il problema agli autovalori della matrice simmetrica $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

Da questi, l'inclinazione è determinata come segue.

1. **Azimut $\varphi$**: Lo spostamento del centro dell'ellisse avviene lungo la direzione di massima pendenza dell'inclinazione (la direzione di gradiente massimo), e l'asse di inclinazione è ortogonale ad essa. Pertanto la direzione dell'asse di inclinazione è data da $(-y_c,\ x_c)$, da cui si determina $\varphi$.
2. **Entità dell'inclinazione $\tau$**: Considerando la figura proiettata lungo la direzione $\varphi$ (la figura sopra), la distanza $R$ dallo spot diretto al centro dell'ellisse soddisfa una funzione della lunghezza di camera, dell'entità dell'inclinazione e dell'angolo di diffrazione:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Risolvere questa equazione per $\tau$. Quando sono disponibili più anelli di diffrazione, prendere la **media pesata** dei $\tau$ ottenuti da ciascun anello come valore reale.
