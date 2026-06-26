<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Apêndice A2. Determinação de parâmetros

Como a posição de cada pixel é governada pela geometria de [A1. Geometria do detector](a1-geometry.md), usar parâmetros incorretos significa ler intensidades em locais errados. Esta página explica como determinar os parâmetros verdadeiros — comprimento de câmara, comprimento de onda, tamanho do pixel e inclinação do IP — a partir dos anéis de difração de um **material de referência**. Para as operações reais, consulte [4. Procedimentos práticos](../4-procedures.md) e [6. Calibração de parâmetros (força bruta)](../6-find-parameter.md).

---

## Material de referência

Para a calibração, mede-se um material de referência cujas constantes de rede são conhecidas. As condições desejáveis são **muitos anéis de difração** com **alta razão SN**, posicionados de forma **esparsa** e **sem orientação preferencial**. A menos que se tenha uma preferência específica, recomenda-se um cristal cúbico contendo átomos pesados como $\mathrm{CeO_2}$ ou $\mathrm{Ag}$. As constantes de rede devem ser conhecidas com cerca de 5 algarismos significativos.

---

## Comprimento de câmara — método das duas distâncias

O comprimento de câmara $\mathrm{CL}$ é definido como a distância que liga a amostra e o ponto direto (direct spot) no IP. Se forem obtidos dois padrões de difração alterando o comprimento de câmara por $\Delta$, é possível determinar o valor absoluto de $\mathrm{CL}$ a partir da variação do raio (em pixels) $r_1,\ r_2$ do mesmo anel. A diferença de distância $\Delta$ pode ser controlada com precisão por um Magnescale ou dispositivo semelhante.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

A partir dos triângulos semelhantes $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

é obtido. Aqui $r_1,\ r_2$ podem permanecer em unidades de pixel, e o comprimento de câmara pode ser obtido mesmo que a correção de inclinação e a correção de tamanho do pixel sejam um tanto imprecisas, e mesmo que as constantes de rede do material de referência sejam imprecisas. Como o comprimento de câmara tem, assim, pouca correlação com os demais parâmetros, ele é o **parâmetro que deve ser determinado primeiro**.

---

## Comprimento de onda e tamanho do pixel — método das duas linhas

Se duas linhas de difração puderem ser registradas, os ângulos de difração $\theta_1,\ \theta_2$ podem ser calculados a partir da razão de suas posições de pico (em pixels) $p_1,\ p_2$ e de seus d-spacings $d_1,\ d_2$, sem conhecer o tamanho do pixel ou o comprimento de câmara. Seja a razão de d-spacing $\rho_d = d_1/d_2$ e a razão de posições de pico $\rho_p = p_1/p_2$.

A partir da lei de Bragg e da geometria do detector plano,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

são válidas. Da razão da primeira equação, $\sin\theta_2 = \rho_d \sin\theta_1$, e da razão da segunda equação, $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Substituindo $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ obtém-se uma equação cuja única incógnita é $\sin\theta_1$:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Isso se reduz a uma equação cúbica em $\sin^2\theta_1$. Como resolvê-la analiticamente exigiria lidar com números imaginários, este software a resolve **numericamente** para obter o valor. Visto que $\rho_d$ é uma razão de d-spacings, ela pode ser determinada sem erro dependendo da simetria do cristal (por exemplo, no sistema cúbico).

Uma vez obtidos os ângulos de difração, o comprimento de câmara pode ser determinado independentemente pelo método das duas distâncias descrito acima, de modo que o comprimento de onda $\lambda$ e o tamanho do pixel $\mathrm{PixSize}$ também podem ser calculados facilmente a partir das duas equações acima.

!!! note "When there is a tilt"
    Se o IP estiver inclinado, a relação $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ deixa de valer, de modo que os valores precisos não podem ser obtidos diretamente. Neste caso, **execute a correção de inclinação e a correção de comprimento de onda alternadamente** para fazer a solução convergir iterativamente para o valor verdadeiro.

---

## Inclinação do IP — ajuste de elipse

Um anel com ângulo de cone $2\theta$ deveria ser observado como um círculo verdadeiro de raio $R_0 = \mathrm{CL}\tan 2\theta$ em um plano $XY$ não inclinado. Em um IP inclinado, porém, o anel torna-se uma **elipse** e, além disso, seu centro não coincide com o centro do feixe (o ponto direto / direct spot).

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Em um plano de IP inclinado por $\varphi,\ \tau$, um ponto $(x,y)$ sobre o anel satisfaz uma cônica geral (elipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Os coeficientes $A,B,C,D,E$ podem ser escritos como funções de $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ e podem ser tratados com álgebra linear elementar como segue.

- O **centro da elipse** $(x_c, y_c)$ é a solução da condição de que o gradiente se anula, isto é, do sistema linear de equações
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- As **direções e comprimentos dos eixos maior e menor** são obtidos resolvendo o problema de autovalores da matriz simétrica $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

A partir desses, a inclinação é determinada como segue.

1. **Azimute $\varphi$**: O deslocamento do centro da elipse ocorre ao longo da direção de inclinação mais íngreme (a direção de gradiente máximo), e o eixo de inclinação é ortogonal a ela. Portanto, a direção do eixo de inclinação é dada por $(-y_c,\ x_c)$, a partir da qual $\varphi$ é determinado.
2. **Magnitude da inclinação $\tau$**: Considerando a figura projetada ao longo da direção $\varphi$ (a figura acima), a distância $R$ do ponto direto ao centro da elipse satisfaz uma função do comprimento de câmara, da magnitude da inclinação e do ângulo de difração:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Resolva esta equação para $\tau$. Quando vários anéis de difração estão disponíveis, tome a **média ponderada** dos $\tau$ obtidos de cada anel como o valor verdadeiro.
