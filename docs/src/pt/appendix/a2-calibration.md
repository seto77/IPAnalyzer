<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# Apêndice A2. Determinação de parâmetros

Como a posição de cada pixel é regida pela geometria da [A1. Geometria do detector](a1-geometry.md), usar parâmetros incorretos significa ler as intensidades nos lugares errados. Esta página explica como determinar os parâmetros verdadeiros — comprimento de câmara, comprimento de onda, tamanho do pixel e inclinação do IP — a partir dos anéis de difração de um **material de referência**. Para as operações reais, veja [4. Procedimentos](../4-procedures.md) e [6. Encontrar parâmetros (força bruta)](../6-find-parameter.md).

---

## Material de referência

Para a calibração, mede-se um material de referência cujas constantes de rede são conhecidas. As condições desejáveis são **muitos anéis de difração** com **alta relação S/N**, posicionados de forma **esparsa** e **sem orientação preferencial**. Salvo preferência particular, recomenda-se um cristal cúbico com átomos pesados, como $\mathrm{CeO_2}$ ou $\mathrm{Ag}$. As constantes de rede precisam ser conhecidas com cerca de 5 algarismos significativos.

---

## Comprimento de câmara — método das duas distâncias

O comprimento de câmara $\mathrm{CL}$ é definido como a distância que liga a amostra ao ponto direto no IP. Se forem tomados dois padrões de difração alterando o comprimento de câmara em $\Delta$, é possível determinar o valor absoluto de $\mathrm{CL}$ a partir da variação do raio $r_1,\ r_2$ do mesmo anel. A diferença de distância $\Delta$ pode ser controlada com exatidão com uma Magnescale ou dispositivo semelhante.

![Determinação do comprimento de câmara pelo método das duas distâncias. O mesmo anel é registrado em duas posições, às distâncias CL e CL+Δ da amostra, e CL é obtido a partir dos raios r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

A partir dos triângulos semelhantes $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ (com $r_i$ na mesma unidade de comprimento que $\mathrm{CL}$), obtém-se

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

Aqui, $r_1,\ r_2$ podem permanecer em unidades de pixel, e o comprimento de câmara pode ser obtido mesmo que a correção de inclinação e a correção do tamanho do pixel sejam um tanto inexatas, e mesmo que as constantes de rede do padrão sejam inexatas. Como o comprimento de câmara tem, assim, pouca correlação com os demais parâmetros, ele é o **parâmetro que deve ser determinado primeiro**.

---

## Comprimento de onda e tamanho do pixel — método das duas linhas

Se for possível registrar duas linhas de difração, os ângulos de Bragg $\theta_1,\ \theta_2$ podem ser calculados a partir da razão entre suas posições de pico (em pixels) $p_1,\ p_2$ e suas distâncias interplanares $d_1,\ d_2$, sem conhecer o tamanho do pixel nem o comprimento de câmara. Seja $\rho_d = d_1/d_2$ a razão das distâncias interplanares e $\rho_p = p_1/p_2$ a razão das posições de pico.

Pela lei de Bragg e pela geometria do detector plano, valem

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

Da razão da primeira equação, $\sin\theta_2 = \rho_d \sin\theta_1$, e da razão da segunda, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Substituindo $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$, obtém-se uma equação cuja única incógnita é $\sin\theta_1$:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Ela se reduz a uma equação cúbica em $\sin^2\theta_1$. Como resolvê-la analiticamente exigiria lidar com números imaginários, este software a resolve **numericamente** para obter o valor. Como $\rho_d$ é uma razão de distâncias interplanares, ela pode ser determinada sem erro conforme a simetria do cristal (por exemplo, no sistema cúbico).

Uma vez obtidos os ângulos de difração, o comprimento de câmara pode ser determinado de forma independente pelo método das duas distâncias descrito acima, de modo que o comprimento de onda $\lambda$ e o tamanho do pixel $\mathrm{PixSize}$ também podem ser calculados facilmente a partir das duas equações acima.

!!! note "Quando há inclinação"
    Se o IP estiver inclinado, a relação $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ deixa de valer, de modo que os valores exatos não podem ser obtidos diretamente. Nesse caso, **faça a correção de inclinação e a correção do comprimento de onda alternadamente** para que a solução convirja iterativamente para o valor verdadeiro.

---

## Inclinação do IP — ajuste de elipse

Um anel com ângulo de cone $2\theta$ deveria ser observado como um círculo perfeito de raio $R_0 = \mathrm{CL}\tan 2\theta$ em um plano $XY$ sem inclinação. Em um IP inclinado, porém, o anel se torna uma **elipse** e, além disso, seu centro não coincide com o centro do feixe (o ponto direto).

![Em um IP inclinado, o anel de difração se torna uma elipse, e seu centro fica deslocado em relação ao ponto direto (projeção vista ao longo da direção φ).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Em um plano do IP inclinado por $\varphi,\ \tau$, um ponto $(x,y)$ do anel satisfaz uma cônica geral (elipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Os coeficientes $A,B,C,D,E$ podem ser escritos como funções de $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ e tratados com álgebra linear elementar, como segue.

- O **centro da elipse** $(x_c, y_c)$ é a solução da condição de gradiente nulo, isto é, do sistema de equações lineares
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- As **direções e os comprimentos dos eixos maior e menor** são obtidos resolvendo o problema de autovalores da matriz simétrica $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

A partir disso, a inclinação é determinada como segue.

1. **Azimute $\varphi$**: o deslocamento do centro da elipse ocorre ao longo da direção de inclinação mais acentuada (a direção de gradiente máximo), e o eixo de inclinação é ortogonal a ela. Portanto, a direção do eixo de inclinação é dada por $(-y_c,\ x_c)$, a partir da qual $\varphi$ é determinado.
2. **Magnitude da inclinação $\tau$**: considerando a figura projetada ao longo da direção $\varphi$ (a figura acima), a distância $R$ do ponto direto ao centro da elipse satisfaz uma função do comprimento de câmara, da magnitude da inclinação e do ângulo de difração:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Resolva essa equação para $\tau$. Quando há vários anéis de difração disponíveis, tome como valor verdadeiro a **média ponderada** dos $\tau$ obtidos de cada anel.
