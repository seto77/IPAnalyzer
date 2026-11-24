<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes; fully retranslated for the Beam interaction → Reflections tab) -->

# Appendice A5. Fattore di diffusione

Nella versione attuale, le riflessioni e i fattori di struttura di un cristallo sono mostrati nella scheda **Riflessioni (Reflections)** della finestra **Interazione del fascio (Beam Interaction)** (che ha sostituito la precedente finestra Scattering Factor). La scheda elenca i piani cristallini permessi (riflessioni) del cristallo selezionato e calcola il **fattore di struttura** e l'intensità di diffrazione di ciascuno. Il tipo di radiazione (raggi X, elettroni o neutroni) si può cambiare, così da confrontare i fattori di struttura dello stesso cristallo tra diverse tecniche di diffrazione.

In IPAnalyzer, la si apre dalla finestra del cristallo che definisce il cristallo di riferimento usato per la calibrazione dei parametri (la finestra del cristallo aperta con **Imposta cristallo (Set crystal)** in [Trova parametro (geometricamente)](../3-tools.md), oppure il pannello del cristallo di [6. Trova parametri (forza bruta)](../6-find-parameter.md)): premere il pulsante **Interazione del fascio (Beam interaction)**, oppure scegliere **Interazione del fascio (Beam Interaction)** dal menu del tasto destro del pannello del cristallo.

![Finestra Interazione del fascio (scheda Riflessioni)](../../assets/references/beam-interaction-reflections-en.png)

La fascia in alto seleziona il fascio incidente, e la scheda **Riflessioni (Reflections)** sottostante mostra l'elenco delle riflessioni (parte superiore) e un diagramma a barre delle stesse riflessioni (parte inferiore). L'elenco viene ricalcolato immediatamente ogni volta che una condizione cambia. Le altre schede (**Attenuazioni & trasporto (Attenuations & transport)**, **Fattori di diffusione (Scattering factors)**, **Fluorescenza (Fluorescence)**) non servono per IPAnalyzer; per queste vedere [Beam Interaction nel manuale di ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/).

---

## Scorciatoie da tastiera e mouse

Questa finestra non ha combinazioni speciali di tasti o mouse. <kbd>F1</kbd> apre questa pagina del manuale, e **Copia (Copy)** esporta la tabella delle riflessioni come testo incollabile in un foglio di calcolo.

---

## Fascio e lunghezza d'onda

- **X-ray / Electron / Neutron** : i fattori di diffusione atomici differiscono a seconda del tipo di fascio incidente, quindi si cambiano qui.
- Per **X-ray**, scegliendo l'**Element** (materiale dell'anodo) e la riga caratteristica (Kα, ecc.) si imposta automaticamente la lunghezza d'onda di quei raggi X caratteristici.
- **Energy** (keV) e **Wavelength** (Å) sono collegati: impostando l'uno si aggiorna l'altro, ed entrambi servono a calcolare il 2θ di ciascuna riflessione.
- **Unit** (**Å** / **nm**) cambia l'unità di lunghezza usata per la distanza interplanare e grandezze simili.

---

## Opzioni della scheda Riflessioni

- **Intensità di diffrazione da polveri (ottica Bragg-Brentano) (Powder diffraction intensities (Bragg-Brentano optics))** : calcola l'intensità relativa come intensità di diffrazione di polveri (Bragg–Brentano), $I \propto m\,\lvert F\rvert^2 / V^2 \times L$, dove $m$ è la molteplicità, $V$ il volume della cella e $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (fattore di Lorentz-polarizzazione) per i raggi X oppure $L = 1/(\sin 2\theta\,\sin\theta)$ (solo fattore di Lorentz) per elettroni e neutroni. Le riflessioni che il fascio non può raggiungere (d < λ/2) hanno intensità 0. Quando è disattivata, viene mostrata l'intensità del fattore di struttura $\lvert F\rvert^2$. Attivandola si attivano anche **Nascondi piani equivalenti (Hide equivalent planes)** e **Nascondi piani proibiti (Hide prohibited planes)**, che vengono resi non modificabili (in grigio).
- **Nascondi piani equivalenti (Hide equivalent planes)** (attivo per impostazione predefinita) : raggruppa in un'unica voce i piani cristallograficamente equivalenti. La colonna **Multi.** è mostrata solo mentre questa opzione è attiva.
- **Nascondi piani proibiti (Hide prohibited planes)** (attivo per impostazione predefinita) : esclude i piani sistematicamente assenti per le regole di estinzione. Mentre è disattivata, una colonna **Condition** mostra la condizione o le condizioni di riflessione che vietano ciascun piano assente.
- **d-spacing cutoff >** (predefinito 1 Å) : esclude le riflessioni con distanza interplanare minore di questo valore (l'unità di lunghezza segue **Unit**).

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
| **Condition** | condizione o condizioni di estinzione violate dal piano (mostrata solo quando **Nascondi piani proibiti (Hide prohibited planes)** è disattivata) |

Sotto la tabella, le stesse riflessioni sono disegnate come pattern a barre, con i picchi più intensi etichettati con i loro *hkl*. Il selettore sceglie l'asse orizzontale tra **2θ**, **d** e **Q** ($= 4\pi\sin\theta/\lambda$), **Log I** commuta l'asse delle intensità tra scala lineare e logaritmica, e le caselle **Range** impostano l'intervallo rappresentato.

---

## Copia negli appunti

**Copia (Copy)** copia l'elenco delle riflessioni negli appunti come testo che si può incollare in un foglio di calcolo come Excel.

---

## Vedere anche

- [Pagina iniziale dell'appendice](index.md)
- [4. Procedure](../4-procedures.md) — definizione del cristallo di riferimento di cui si calcolano i fattori di struttura.
- [6. Trova parametri (forza bruta)](../6-find-parameter.md)
- [Beam Interaction nel manuale di ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/) — tutte e quattro le schede della stessa finestra.
