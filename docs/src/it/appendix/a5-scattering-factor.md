<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# Appendice A5. Fattore di diffusione

**Scattering Factor** elenca i piani cristallini permessi (riflessioni) del cristallo selezionato e calcola il **fattore di struttura** e l'intensità di diffrazione di ciascuno. Il tipo di radiazione (raggi X, elettroni o neutroni) si può cambiare, così da confrontare i fattori di struttura dello stesso cristallo tra diverse tecniche di diffrazione.

Nella versione attuale questo elenco si trova nella scheda **Riflessioni (Reflections)** di **Interazione del fascio (Beam interaction)** nella finestra del cristallo (i fattori di diffusione atomici veri e propri si trovano nella scheda **Fattori di diffusione (Scattering factors)** della stessa finestra). Le schermate e le voci descritte di seguito si basano sulla precedente finestra Scattering Factor.

In IPAnalyzer questa sottofinestra si apre dalla **finestra del cristallo** (il CrystalControl usato in [4. Procedure](../4-procedures.md) per la calibrazione geometrica e in [6. Trova parametri (forza bruta)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Le condizioni di calcolo si trovano nella parte superiore della finestra e l'elenco delle riflessioni nella parte inferiore. L'elenco viene ricalcolato immediatamente ogni volta che una condizione cambia.

---

## Scorciatoie da tastiera e mouse

Questa finestra non ha combinazioni speciali di tasti o mouse. <kbd>F1</kbd> apre questa pagina del manuale, e **Copy to clipboard** esporta l'intera tabella delle riflessioni come testo incollabile in un foglio di calcolo.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : i fattori di diffusione atomici differiscono a seconda del tipo di fascio incidente, quindi si cambiano qui.
- Per **X-ray**, scegliendo l'**Element** (materiale dell'anodo) e la riga caratteristica (Kα, ecc.) si imposta automaticamente la lunghezza d'onda di quei raggi X caratteristici.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** e **Wavelength (Å)** sono collegati tra loro.
- Questa energia o lunghezza d'onda è usata per calcolare 2θ (l'angolo di diffrazione). Per i raggi X si può impostare anche tramite la scelta dell'elemento e del tipo di riga.

---

## Opzioni di visualizzazione e di calcolo

- **Intensità di diffrazione da polveri (ottica Bragg-Brentano) (Powder Diffraction Intensities (Bragg-Brentano Optics))** : calcola l'intensità relativa come intensità di diffrazione di polveri (Bragg–Brentano), includendo la molteplicità e il fattore di Lorentz-polarizzazione. Quando è disattivata, mostra l'intensità del fattore di struttura.
- **Nascondi piani equivalenti (Hide equivalent planes)** : raggruppa in un'unica voce i piani cristallograficamente equivalenti.
- **Nascondi piani proibiti (Hide prohibited planes)** : esclude i piani la cui intensità è nulla per le regole di estinzione.
- **Unit (Å / nm)** : cambia l'unità di lunghezza per la distanza interplanare, ecc.
- **d-Spacing Cutoff** : esclude le riflessioni con distanza interplanare minore di questo valore.

---

## Elenco delle riflessioni

Ogni riga corrisponde a una riflessione (o a un gruppo di piani equivalenti per simmetria).

| Colonna | Significato |
|------|------|
| **h, k, l** | indici di Miller |
| **Multi.** | molteplicità (numero di piani equivalenti per simmetria) |
| **d (Å)** | distanza interplanare |
| **q (2π/d)** | modulo del vettore di scattering |
| **2θ (°)** | angolo di diffrazione per la lunghezza d'onda selezionata |
| **F_real** | parte reale del fattore di struttura |
| **F_inv** | parte immaginaria del fattore di struttura |
| **\|F\|** | ampiezza del fattore di struttura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensità del fattore di struttura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensità relativa, con la riflessione più intensa posta a 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copia l'elenco negli appunti come testo che si può incollare in un foglio di calcolo come Excel.

---

## Vedere anche

- [Pagina iniziale dell'appendice](index.md)
- [4. Procedure](../4-procedures.md) — definizione del cristallo di riferimento di cui si calcolano i fattori di struttura.
- [6. Trova parametri (forza bruta)](../6-find-parameter.md)
