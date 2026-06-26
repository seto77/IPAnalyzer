<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

O modo de força bruta varia cada parâmetro de forma exaustiva (uma busca em grade) para encontrar os valores que melhor satisfazem:

- picos nítidos (ou seja, FWHM pequeno) e
- pequeno desvio dos valores d.

É eficaz para anéis incompletos ou dados ruidosos, onde a otimização geométrica tem dificuldade para convergir. Consulte [Ferramentas](3-tools.md) para uma visão geral da ferramenta e [Procedimentos](4-procedures.md) para o fluxo básico.

## Steps

1. Carregue os dados de imagem e os parâmetros e clique em **Find Parameter (brute force)**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Selecione o **standard material**. Se ele não estiver na lista, escolha **Others** e insira-o manualmente.
3. Mostre o perfil com **Get profile**.
4. Dê um clique duplo em qualquer linha de pico que você não queira usar na otimização para excluí-la.
5. Defina as opções e pressione **Optimize** para iniciar a otimização.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Especifica a faixa angular ajustada para cada pico.

### Number of repetitions

Especifica o número de ciclos de otimização.

### Per-parameter options

A otimização é realizada sobre os itens marcados. Cada parâmetro percorre a faixa especificada (**Search range**) no passo especificado (**Initial step**).

Por exemplo, se o comprimento de câmara começa em 100 mm com um Initial step de 0,05 mm e um Search range de 4, então 9 (= Search range × 2 + 1) comprimentos de câmara são testados: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Quando as contagens de tentativas dos parâmetros são N1, N2, N3, …, o número total de tentativas por ciclo é N1 × N2 × N3 × …. No exemplo acima, com quatro parâmetros nos Search ranges 4, 4, 3 e 6, isso resulta em (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 tentativas. Em outras palavras, 7371 conjuntos de parâmetros são testados, e a combinação com os picos mais nítidos e o menor desvio dos valores d é escolhida.

!!! warning
    Aumentar o **Search range** eleva acentuadamente o número de tentativas e prolonga cada ciclo. Use-o com cuidado.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Durante a calibração, é exibida uma tela de status como a mostrada acima.

- **Cycle**: o número do ciclo atual. Quando um ciclo termina, o melhor conjunto de parâmetros encontrado nele torna-se o ponto de partida do ciclo seguinte. Se os melhores parâmetros forem idênticos aos do ciclo anterior, o passo é multiplicado por 0,8 para o ciclo seguinte.
- **Current best values**: os melhores parâmetros naquele momento.
- **Current steps**: o passo de cada parâmetro naquele momento.
- **No1, No2, …**: os 5 melhores valores de avaliação no ciclo. Eles caem rapidamente no início e convergem à medida que o ótimo é aproximado.

## Evaluation value R

O valor de avaliação R é calculado da seguinte forma.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Aqui *H* é a altura do pico com o fundo subtraído.
