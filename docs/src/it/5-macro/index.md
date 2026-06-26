<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer offre una funzione **macro** che automatizza sequenze di operazioni tramite script in stile Python. È utile per lavori ripetitivi come la unidimensionalizzazione in blocco di molti file, la conversione di formato e l'analisi a divisione azimutale.

## Apertura dell'editor

Apri l'editor di macro dal menu **Macro** → **Editor** nella finestra principale. Lì puoi modificare il codice ed eseguirlo, inclusa l'esecuzione passo dopo passo.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Linguaggio

- Sono disponibili istruzioni di controllo come `for` / `if` / `while` / `def` / `class`, nonché le operazioni aritmetiche.
- Il modulo `math` è preimportato, quindi puoi usare direttamente `math.pi` o `math.sin(...)` senza un'istruzione `import`.
- `print()` non è disponibile. Per ispezionare i valori, usa l'**esecuzione passo passo** (Step by step) e osserva il cambiamento delle variabili nel pannello di debug.
- Ogni operazione di IPAnalyzer viene chiamata da uno spazio dei nomi sotto l'oggetto radice `IPA` (ad es. `IPA.File`).

## Spazi dei nomi IPA

| Spazio dei nomi | Ruolo |
|------|------|
| `IPA.File` | Lettura/scrittura di file di immagine, parametri e maschere; finestre di dialogo per la selezione dei file |
| `IPA.Wave` | Imposta la sorgente incidente e la lunghezza d'onda |
| `IPA.Detector` | Imposta la geometria del rivelatore: centro, lunghezza di camera, dimensione del pixel, inclinazione |
| `IPA.Image` | Controlla la scala di visualizzazione, il contrasto e l'area di vista |
| `IPA.Mask` | Maschera spot e regioni |
| `IPA.Profile` | Esegue la unidimensionalizzazione (Get Profile) e configura il salvataggio/invio |
| `IPA.IntegralProperty` | Imposta l'intervallo, il passo e l'unità dell'integrazione concentrica / radiale |
| `IPA.Sequential` | Seleziona / media / individua i frame di un'immagine multiframe |
| `IPA.PDI` | Richiama macro su PDIndexer (integrazione tramite appunti) |

Consulta [Funzioni integrate](1-built-in-functions.md) per l'elenco dei membri e [Esempi](2-examples.md) per script concreti.

!!! tip "La guida nell'editor è il riferimento autorevole"
    La descrizione di ciascuna funzione/proprietà è mostrata nella guida dell'editor di macro ed è la fonte di verità aggiornata e allineata alla versione. Se questa pagina è in disaccordo con la guida nell'editor, fidati di quest'ultima.

## Macro di esempio

Quando l'elenco delle macro salvate dell'editor è vuoto, vengono inserite automaticamente macro di esempio (loop di base, funzioni matematiche, impostazione della geometria, elaborazione in blocco, divisione azimutale, mascheratura, invio a PDIndexer, ecc.). Sono un punto di partenza facile da adattare.

## Utilizzo con Auto Procedure

Le macro che scrivi possono essere salvate con un nome ed essere anche richiamate dall'elenco "execute after loading" di [Auto Procedure](../3-tools.md), in modo che una macro venga applicata automaticamente a ciascuna immagine in arrivo durante un esperimento.
