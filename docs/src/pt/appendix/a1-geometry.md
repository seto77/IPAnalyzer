<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Apêndice A1. Geometria do detector e transformações de coordenadas

Esta página define, com equações, o **sistema de coordenadas, a correção de inclinação do IP e a correção da forma do pixel** que o IPAnalyzer usa para mapear posições de pixel em um detector plano (IP, CCD/CMOS) para ângulos de difração. Para uma visão geral do sistema de coordenadas, veja também a [página inicial do apêndice](index.md) e [0. Visão geral](../0-overview.md).

---

## Sistema de coordenadas e parâmetros

O IPAnalyzer usa de forma consistente, internamente, um sistema de coordenadas **dextrogiro** (right-handed).

- O ponto onde o feixe de raios X ou de elétrons intercepta o IP (o **direct spot**) é tomado como a origem $(0,0,0)$, e o eixo $Z$ é alinhado com a direção de propagação do feixe.
- Tratando a amostra como infinitesimalmente pequena, a distância entre a amostra e a origem é definida como o **comprimento de câmara** $\mathrm{CL}$. A posição da amostra é, portanto, $(0,\ 0,\ -\mathrm{CL})$.
- O eixo $X$ é alinhado com a direção de varredura do laser de leitura quando o IP não está inclinado (a direção para a direita da imagem). O eixo $Y$ aponta, portanto, para baixo na tela.
- Um anel de difração com ângulo de cone $2\theta$ é observado, em um plano $XY$ não inclinado, como um círculo perfeito de raio $\mathrm{CL}\tan 2\theta$.

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

A rotação livre de um objeto 3D requer inerentemente três eixos, mas como a distribuição do anel de Debye é invariante sob rotação em torno do eixo $Z$, o eixo $X$ pode ser escolhido arbitrariamente. Isso remove um grau de liberdade, de modo que a inclinação do IP pode ser expressa com **duas variáveis** $\varphi,\ \tau$.

!!! note "Correspondence with (WIN)PIP"
    O software legado PIP expressa a inclinação com um par diferente de ângulos $(\beta,\ \Phi)$. A conversão de $(\beta,\ \Phi)$ para o $(\varphi,\ \tau)$ do IPAnalyzer é $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Para detalhes, veja "Relationship with (WIN)PIP" em [0. Visão geral](../0-overview.md).

---

## Correção de inclinação do IP

A inclinação do IP em relação ao eixo óptico (o eixo $Z$) é representada por uma rotação cujo eixo é uma reta que passa pela origem e está contida no plano $XY$. Essa rotação pode ser escrita como a matriz de rotação $R = R_2\,R_1\,R_2^{-1}$, uma operação que rotaciona por $\tau$ ao longo ($R_1$) de um eixo que foi rotacionado por $\varphi$ em torno do eixo $Z$ ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Isso é equivalente a uma rotação por ângulo $\tau$ em torno do vetor unitário $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ que forma ângulo $\varphi$ com o eixo $X$ no plano $XY$, e expandindo resulta

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Transformação direta (plano não inclinado → IP inclinado)

Um ponto $P_1 = (X,\ Y,\ 0)$ no plano $XY$ não inclinado mapeia para $P_2 = R\,P_1$ no IP inclinado.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projeção (IP inclinado → plano não inclinado)

O que de fato é necessário é a direção inversa, isto é, a coordenada no plano $XY$ que um "pixel observado no IP inclinado" ocuparia se não houvesse inclinação. Isso é dado pela **projeção central (em perspectiva)** que encontra o ponto $P_3$ onde a reta que une um ponto no IP inclinado e a amostra $(0,0,-\mathrm{CL})$ intercepta o plano $XY$. Como esta é uma transformação projetiva com a amostra como o centro de projeção,

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

resulta. Como toda a correção de inclinação é uma transformação linear (projetiva em coordenadas homogêneas), a posição de cada pixel pode ser calculada rapidamente em um computador.

---

## Correção da forma do pixel

A forma do pixel do IP é tratada como um **paralelogramo** com comprimento $\mathrm{PixSizeX}$ ao longo do eixo $X$, comprimento $\mathrm{PixSizeY}$ ao longo do eixo $Y$ e um desvio do ângulo reto (ângulo de distorção) $\xi$. Um $\xi$ não nulo significa que há um deslocamento na posição inicial da varredura do laser de leitura, e este software assume que esse deslocamento é constante ao longo do eixo $Y$.

A coordenada real $P$ do pixel que está a $\mathrm{PixNumX}$ de distância na direção $X$ e a $\mathrm{PixNumY}$ de distância na direção $Y$, contando a partir do pixel central, é dada por

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Combinando esta correção da forma do pixel com a correção de inclinação descrita acima, qualquer pixel em um IP inclinado pode ser mapeado para sua posição correta no plano $XY$ não inclinado. Esse mapeamento é a base para a determinação de parâmetros no próximo capítulo e para [A3. Integração da imagem](a3-image-integration.md).
