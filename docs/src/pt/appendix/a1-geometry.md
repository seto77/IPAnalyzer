<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# Apêndice A1. Geometria do detector e transformações de coordenadas

Esta página define, com equações, o **sistema de coordenadas, a correção da inclinação do IP e a correção da forma do pixel** que o IPAnalyzer usa para mapear as posições dos pixels em um detector plano (IP, CCD/CMOS) em ângulos de difração. Para uma visão geral do sistema de coordenadas, veja também a [página inicial do apêndice](index.md) e a [0. Visão geral](../0-overview.md).

---

## Sistema de coordenadas e parâmetros

Internamente, o IPAnalyzer usa de forma consistente um sistema de coordenadas **dextrógiro**.

- O ponto em que o feixe de raios X ou de elétrons intercepta o IP (o **ponto direto**) é tomado como a origem $(0,0,0)$, e o eixo $Z$ é alinhado com a direção de propagação do feixe.
- Tratando a amostra como infinitesimalmente pequena, a distância entre a amostra e a origem é definida como o **comprimento de câmara** $\mathrm{CL}$. A posição da amostra é, portanto, $(0,\ 0,\ -\mathrm{CL})$.
- O eixo $X$ é alinhado com a direção de varredura do laser de leitura quando o IP não está inclinado (a direção para a direita na imagem). O eixo $Y$, portanto, aponta para baixo na tela.
- Um anel de difração com ângulo de cone $2\theta$ é observado, em um plano $XY$ sem inclinação, como um círculo perfeito de raio $\mathrm{CL}\tan 2\theta$.

![Definição do sistema de coordenadas](../../assets/references/geometry-coordinate-system.png){width=520px}

A rotação livre de um objeto 3D requer, em princípio, três eixos; mas, como a distribuição dos anéis de Debye é invariante sob rotação em torno do eixo $Z$, o eixo $X$ pode ser escolhido arbitrariamente. Isso elimina um grau de liberdade, de modo que a inclinação do IP pode ser expressa com **duas variáveis**, $\varphi,\ \tau$.

!!! note "Correspondência com o (WIN)PIP"
    O software antigo PIP expressa a inclinação com outro par de ângulos, $(\beta,\ \Phi)$. A conversão de $(\beta,\ \Phi)$ para o $(\varphi,\ \tau)$ do IPAnalyzer é $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Para mais detalhes, veja "Relação com o (WIN)PIP" na [0. Visão geral](../0-overview.md).

---

## Correção da inclinação do IP

A inclinação do IP em relação ao eixo óptico (o eixo $Z$) é representada por uma rotação cujo eixo é uma reta que passa pela origem e está contida no plano $XY$. Essa rotação pode ser escrita como a matriz de rotação $R = R_2\,R_1\,R_2^{-1}$, uma operação que gira de $\tau$ ($R_1$) em torno de um eixo que foi girado de $\varphi$ em torno do eixo $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Isso equivale a uma rotação de ângulo $\tau$ em torno do vetor unitário $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$, que forma o ângulo $\varphi$ com o eixo $X$ no plano $XY$; desenvolvendo, obtém-se

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Transformação direta (plano sem inclinação → IP inclinado)

Um ponto $P_1 = (X,\ Y,\ 0)$ do plano $XY$ sem inclinação é mapeado em $P_2 = R\,P_1$ no IP inclinado.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projeção (IP inclinado → plano sem inclinação)

O que realmente se precisa é a direção inversa, isto é, a coordenada no plano $XY$ que um "pixel observado no IP inclinado" ocuparia se não houvesse inclinação. Ela é dada pela **projeção central (perspectiva)**, que encontra o ponto $P_3$ em que a reta que une um ponto do IP inclinado e a amostra $(0,0,-\mathrm{CL})$ intercepta o plano $XY$. Como se trata de uma transformação projetiva com a amostra como centro de projeção, resulta

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Como a correção de inclinação, que inclui a projeção central, é uma transformação projetiva que pode ser escrita como uma matriz em coordenadas homogêneas, a posição de cada pixel pode ser calculada rapidamente no computador.

---

## Correção da forma do pixel

A forma do pixel do IP é tratada como um **paralelogramo** com comprimento $\mathrm{PixSizeX}$ ao longo do eixo $X$, comprimento $\mathrm{PixSizeY}$ ao longo do eixo $Y$ e um desvio em relação ao ângulo reto (ângulo de distorção) $\xi$. Um $\xi$ não nulo significa que há um deslocamento na posição inicial da varredura do laser de leitura, e este software supõe que esse deslocamento é constante ao longo do eixo $Y$.

A coordenada real $P$ do pixel que está $\mathrm{PixNumX}$ afastado na direção $X$ e $\mathrm{PixNumY}$ afastado na direção $Y$, contando a partir do pixel central, é dada por

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando essa correção da forma do pixel com a correção de inclinação descrita acima, qualquer pixel de um IP inclinado pode ser mapeado em sua posição correta no plano $XY$ sem inclinação. Esse mapeamento é a base da determinação de parâmetros do próximo capítulo e da [A3. Integração da imagem](a3-image-integration.md).
