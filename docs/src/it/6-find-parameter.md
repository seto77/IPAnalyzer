<!-- 261124Cl: Retranslated from en/6-find-parameter.md (UI labels follow the localized GUI). -->

# Trova parametri (forza bruta)

La modalità a forza bruta varia ciascun parametro in modo esaustivo (una ricerca su griglia) per trovare i valori che soddisfano al meglio:

- piccole deviazioni (in 2θ) tra le posizioni dei picchi calcolate e quelle ottenute dal fitting, e
- picchi alti (stretti).

È efficace per anelli incompleti o dati rumorosi, per i quali l'ottimizzazione geometrica fatica a convergere. Per una panoramica dello strumento vedere [Strumenti](3-tools.md), e per il flusso di base [Procedure](4-procedures.md).

## Passi

1. Caricare i dati dell'immagine e i parametri, poi fare clic su **Trova parametro (forza bruta) (Find Parameter (brute force))**.

    ![Avvio di Trova parametro (forza bruta)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Finestra di calibrazione a forza bruta](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Selezionare il **materiale di riferimento**. Se non è nell'elenco, scegliere **Altro (Other)** e inserirlo manualmente.
3. Visualizzare il profilo con **Ottieni profilo (Get Profile)**.
4. Fare doppio clic sulle linee dei picchi che non si vogliono usare per l'ottimizzazione, per escluderle.
5. Impostare le opzioni e premere **Ottimizza (Optimize)** per avviare l'ottimizzazione.

## Opzioni

![Impostazioni delle opzioni](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Intervallo di fitting

Specifica l'intervallo angolare sottoposto a fitting per ciascun picco.

### Numero di ripetizioni

Specifica il numero di cicli di ottimizzazione.

### Opzioni per parametro

L'ottimizzazione viene eseguita sulle voci selezionate. Ogni parametro si sposta sull'intervallo specificato (**Intervallo di ricerca (Search range)**) con il passo specificato (**Passo iniziale (Initial step)**).

Ad esempio, se la lunghezza di camera parte da 100 mm con un Passo iniziale di 0,05 mm e un Intervallo di ricerca di 4, vengono provate 9 (= Intervallo di ricerca × 2 + 1) lunghezze di camera: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Quando i numeri di prove dei parametri sono N1, N2, N3, …, il numero totale di prove per ciclo è N1 × N2 × N3 × …. Nell'esempio precedente, con quattro parametri con Intervallo di ricerca 4, 4, 3 e 6, si ottiene (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 prove. In altre parole, vengono provati 7371 insiemi di parametri, e viene scelta la combinazione con il valore di valutazione R (vedere sotto) più piccolo.

!!! warning "Attenzione"
    Aumentare l'**Intervallo di ricerca (Search range)** fa crescere bruscamente il numero di prove e allunga ogni ciclo. Usarlo con cautela.

## Schermata di stato

![Schermata di stato](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Durante la calibrazione viene mostrata una schermata di stato come quella sopra.

- **Cycle**: il numero del ciclo corrente. Al termine di un ciclo, il miglior insieme di parametri trovato in esso diventa il punto di partenza del ciclo successivo. Se i parametri migliori sono identici a quelli all'inizio del ciclo, per il ciclo successivo il passo viene ridotto al valore immediatamente inferiore della serie predefinita (1, 1.3, 1.8, 2.4, 3.2, 4.2, 5.6, 7.5 × 10ⁿ) (ad es. 0,05 mm → 0,042 mm).
- **Current best values**: i parametri migliori in quel momento.
- **Current steps**: il passo di ciascun parametro in quel momento.
- **No1, No2, …**: i 4 migliori valori di valutazione dall'inizio della ricerca (mostrati quando sono stati raccolti almeno cinque valori diversi). Calano rapidamente all'inizio e convergono man mano che ci si avvicina all'ottimo.

## Valore di valutazione R

Il valore di valutazione R si calcola come segue.

![Formula del valore di valutazione R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Qui \(2\theta_{\mathrm{calc},i}\) è la posizione del picco \(i\) calcolata dai parametri correnti, \(2\theta_{\mathrm{fit},i}\) la posizione ottenuta dal fitting del profilo (entrambe in gradi), *H* l'altezza del picco al netto dello sfondo e *W* il peso (**Weight**, predefinito 100). Per un rivelatore piano la formula è:

$$
R = 1000\left[\sum_i \left(2\theta_{\mathrm{calc},i} - 2\theta_{\mathrm{fit},i}\right)^2 + \frac{W}{\sum_i H_i}\right]
$$

R diventa più piccolo quanto più piccole sono le deviazioni di posizione e quanto più alti (stretti) sono i picchi. La FWHM in sé non viene usata nella valutazione.
