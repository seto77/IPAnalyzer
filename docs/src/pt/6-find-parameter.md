<!-- 261124Cl: Retranslated from en/6-find-parameter.md (UI labels follow the localized GUI). -->

# Encontrar parâmetros (força bruta)

O modo de força bruta varia cada parâmetro de forma exaustiva (uma busca em grade) para encontrar os valores que melhor satisfazem:

- pequenos desvios (em 2θ) entre as posições de pico calculadas e as obtidas por ajuste, e
- picos altos (estreitos).

É eficaz para anéis incompletos ou dados ruidosos, nos quais a otimização geométrica tem dificuldade em convergir. Veja [Ferramentas](3-tools.md) para uma visão geral da ferramenta e [Procedimentos](4-procedures.md) para o fluxo básico.

## Etapas

1. Carregue os dados da imagem e os parâmetros e clique em **Localizar parâmetro (força bruta) (Find Parameter (brute force))**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Selecione o **material de referência**. Se ele não estiver na lista, escolha **Outro (Other)** e informe-o manualmente.
3. Exiba o perfil com **Obter perfil (Get Profile)**.
4. Dê um clique duplo em qualquer linha de pico que não queira usar na otimização para excluí-la.
5. Defina as opções e pressione **Otimizar (Optimize)** para iniciar a otimização.

## Opções

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Especifica o intervalo angular ajustado para cada pico.

### Número de repetições

Especifica o número de ciclos de otimização.

### Opções de cada parâmetro

A otimização é feita nos itens marcados. Cada parâmetro percorre o intervalo especificado (**Intervalo de busca (Search range)**) com o passo especificado (**Passo inicial (Initial step)**).

Por exemplo, se o comprimento de câmara começa em 100 mm com um **Passo inicial** de 0,05 mm e um **Intervalo de busca** de 4, são testados 9 (= Intervalo de busca × 2 + 1) comprimentos de câmara: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Quando os números de tentativas dos parâmetros são N1, N2, N3, …, o número total de tentativas por ciclo é N1 × N2 × N3 × …. No exemplo acima, com quatro parâmetros com Intervalos de busca 4, 4, 3 e 6, isso dá (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 tentativas. Ou seja, são testados 7371 conjuntos de parâmetros, e é escolhida a combinação com o menor valor de avaliação R (veja abaixo).

!!! warning "Atenção"
    Aumentar o **Intervalo de busca (Search range)** aumenta bruscamente o número de tentativas e alonga cada ciclo. Use-o com cuidado.

## Tela de status

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Durante a calibração, é exibida uma tela de status como a mostrada acima.

- **Cycle**: o número do ciclo atual. Quando um ciclo termina, o melhor conjunto de parâmetros encontrado nele passa a ser o ponto de partida do ciclo seguinte. Se os melhores parâmetros forem idênticos aos do início do ciclo, o passo é reduzido, no ciclo seguinte, ao próximo valor menor da série predefinida (1, 1,3, 1,8, 2,4, 3,2, 4,2, 5,6, 7,5 × 10ⁿ) (por exemplo, 0,05 mm → 0,042 mm).
- **Current best values**: os melhores parâmetros naquele momento.
- **Current steps**: o passo de cada parâmetro naquele momento.
- **No1, No2, …**: os 4 melhores valores de avaliação desde o início da busca (exibidos depois que pelo menos cinco valores diferentes tiverem sido coletados). Eles caem rapidamente no início e convergem à medida que o ótimo se aproxima.

## Valor de avaliação R

O valor de avaliação R é calculado como segue.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Aqui, \(2\theta_{\mathrm{calc},i}\) é a posição do pico \(i\) calculada a partir dos parâmetros atuais, \(2\theta_{\mathrm{fit},i}\) a posição obtida pelo ajuste do perfil (ambas em graus), *H* a altura do pico após a subtração do fundo e *W* o peso (**Weight**, padrão 100). Para um detector plano, a fórmula é:

$$
R = 1000\left[\sum_i \left(2\theta_{\mathrm{calc},i} - 2\theta_{\mathrm{fit},i}\right)^2 + \frac{W}{\sum_i H_i}\right]
$$

R diminui à medida que os desvios de posição diminuem e os picos ficam mais altos (mais estreitos). A própria FWHM não é usada na avaliação.
