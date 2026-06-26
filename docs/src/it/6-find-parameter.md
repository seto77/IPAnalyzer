<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

La modalità a forza bruta varia ogni parametro in modo esaustivo (una ricerca su griglia) per trovare i valori che soddisfano al meglio:

- picchi netti (cioè FWHM piccola), e
- piccola deviazione dei valori d.

È efficace per anelli incompleti o dati rumorosi, dove l'ottimizzazione geometrica fatica a convergere. Vedere [Strumenti](3-tools.md) per una panoramica dello strumento e [Procedure](4-procedures.md) per il flusso di base.

## Passaggi

1. Caricare i dati dell'immagine e i parametri, quindi fare clic su **Find Parameter (brute force)**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Selezionare il **standard material**. Se non è presente nell'elenco, scegliere **Others** e inserirlo manualmente.
3. Mostrare il profilo con **Get profile**.
4. Fare doppio clic su qualsiasi linea di picco che non si desidera utilizzare per l'ottimizzazione per escluderla.
5. Impostare le opzioni e premere **Optimize** per avviare l'ottimizzazione.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Specifica l'intervallo angolare adattato per ciascun picco.

### Number of repetitions

Specifica il numero di cicli di ottimizzazione.

### Per-parameter options

L'ottimizzazione viene eseguita sugli elementi selezionati. Ciascun parametro si muove sull'intervallo specificato (**Search range**) con il passo specificato (**Initial step**).

Ad esempio, se la lunghezza di camera parte da 100 mm con un Initial step di 0,05 mm e un Search range di 4, allora vengono provate 9 (= Search range × 2 + 1) lunghezze di camera: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Quando i conteggi delle prove dei parametri sono N1, N2, N3, …, il numero totale di prove per ciclo è N1 × N2 × N3 × …. Nell'esempio precedente, con quattro parametri con Search range 4, 4, 3 e 6, questo è (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 prove. In altre parole, vengono provati 7371 set di parametri e viene scelta la combinazione con i picchi più netti e la minore deviazione dei valori d.

!!! warning
    Aumentare il **Search range** incrementa fortemente il numero di prove e allunga ogni ciclo. Usarlo con cautela.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Durante la calibrazione viene mostrata una schermata di stato come quella sopra.

- **Cycle**: il numero del ciclo corrente. Quando un ciclo termina, il miglior set di parametri trovato in esso diventa il punto di partenza del ciclo successivo. Se i migliori parametri sono identici a quelli del ciclo precedente, il passo viene moltiplicato per 0,8 per il ciclo successivo.
- **Current best values**: i migliori parametri in quel momento.
- **Current steps**: il passo di ciascun parametro in quel momento.
- **No1, No2, …**: i 5 migliori valori di valutazione nel ciclo. All'inizio diminuiscono rapidamente e convergono man mano che ci si avvicina all'ottimo.

## Evaluation value R

Il valore di valutazione R è calcolato come segue.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Qui *H* è l'altezza del picco con sottrazione del fondo.
