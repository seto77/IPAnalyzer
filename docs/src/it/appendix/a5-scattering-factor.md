<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendix A5. Fattore di diffusione

**Scattering Factor** elenca i piani cristallini consentiti (riflessioni) del cristallo selezionato e ne calcola il **fattore di struttura** e l'intensità di diffrazione per ciascuno. Il tipo di radiazione (raggi X, elettroni o neutroni) può essere commutato, in modo da poter confrontare i fattori di struttura dello stesso cristallo tra le diverse tecniche di diffrazione.

In IPAnalyzer, questa sotto-finestra si apre dalla **Crystal window** (il CrystalControl utilizzato in [4. Practical procedures](../4-procedures.md) per la calibrazione geometrica e in [6. Find Parameter (brute force)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Le condizioni di calcolo si trovano nella parte superiore della finestra e l'elenco delle riflessioni in quella inferiore. L'elenco viene ricalcolato immediatamente ogni volta che una condizione cambia.

---

## Scorciatoie da tastiera e mouse

Questa finestra non ha combinazioni speciali di tasti o mouse. <kbd>F1</kbd> apre questa pagina del manuale e **Copy to clipboard** esporta l'intera tabella delle riflessioni come testo incollabile in un foglio di calcolo.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : i fattori di diffusione atomici differiscono a seconda del tipo di fascio incidente, quindi vengono commutati qui.
- Per **X-ray**, la scelta dell'**Element** (materiale dell'anodo) e della linea caratteristica (Kα, ecc.) imposta automaticamente la lunghezza d'onda di quel raggio X caratteristico.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** e **Wavelength (Å)** sono collegati tra loro.
- Questa energia o lunghezza d'onda viene utilizzata per calcolare 2θ (l'angolo di diffrazione). Per i raggi X può anche essere impostata tramite la selezione dell'elemento e del tipo di linea.

---

## Opzioni di visualizzazione e calcolo

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : calcola l'intensità relativa come intensità di diffrazione di polveri (Bragg–Brentano), includendo la molteplicità e il fattore di Lorentz–polarizzazione. Quando è disattivata, visualizza l'intensità del fattore di struttura.
- **Hide equivalent planes** : raggruppa i piani cristallograficamente equivalenti in un'unica voce.
- **Hide prohibited planes** : esclude i piani la cui intensità è zero per le regole di estinzione.
- **Unit (Å / nm)** : commuta l'unità di lunghezza per il d-spacing, ecc.
- **d-Spacing Cutoff** : esclude le riflessioni con un d-spacing inferiore a questo valore.

---

## Elenco delle riflessioni

Ogni riga corrisponde a una riflessione (o a un gruppo di piani simmetricamente equivalenti).

| Column | Significato |
|------|------|
| **h, k, l** | indici di Miller |
| **Multi.** | molteplicità (numero di piani simmetricamente equivalenti) |
| **d (Å)** | distanza interplanare |
| **q (2π/d)** | modulo del vettore di diffusione |
| **2θ (°)** | angolo di diffrazione per la lunghezza d'onda selezionata |
| **F_real** | parte reale del fattore di struttura |
| **F_inv** | parte immaginaria del fattore di struttura |
| **\|F\|** | ampiezza del fattore di struttura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensità del fattore di struttura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensità relativa, con la riflessione più intensa impostata a 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copia l'elenco negli appunti come testo che può essere incollato in un foglio di calcolo come Excel.

---

## Vedi anche

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — definizione del cristallo di riferimento di cui vengono calcolati i fattori di struttura.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
