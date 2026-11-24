<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). -->

# Apêndice

Este apêndice resume o **fundamento teórico da geometria e dos algoritmos** que o IPAnalyzer usa ao converter uma imagem de difração bidimensional (anéis de Debye–Scherrer) em um perfil unidimensional de alta exatidão. Para os procedimentos de operação e o uso de cada funcionalidade, consulte o manual principal ([0. Visão geral](../0-overview.md), [4. Procedimentos](../4-procedures.md) etc.). Aqui explicamos, com equações, as definições do sistema de coordenadas, as transformações de coordenadas, os métodos de determinação de parâmetros e o algoritmo de integração por trás deles.

O conteúdo baseia-se no documento antigo `doc/IPAnalyzerAlgorithm.pdf`, incluído no pacote de distribuição, e na implementação atual.

## Estrutura do apêndice

- **[A1. Geometria do detector e transformações de coordenadas](a1-geometry.md)** — definição do sistema de coordenadas dextrógiro, as matrizes de rotação que descrevem a inclinação do IP ($\varphi,\ \tau$) e a correção da forma do pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Determinação de parâmetros](a2-calibration.md)** — calibração do comprimento de câmara, do comprimento de onda, do tamanho do pixel e da inclinação do IP usando um material de referência (método das duas distâncias, método das duas linhas, ajuste de elipse).
- **[A3. Integração da imagem](a3-image-integration.md)** — o algoritmo de partição de área que distribui as intensidades dos pixels entre os passos angulares.
- **[A4. Informação de simetria](a4-symmetry-information.md)** — simetria do grupo espacial, cálculos geométricos, posições de Wyckoff, condições de reflexão e diagramas dos elementos de simetria do cristal padrão (uma subjanela da janela Crystal).
- **[A5. Fator de espalhamento](a5-scattering-factor.md)** — fatores de estrutura e a lista de reflexões do cristal padrão (raios X, elétrons, nêutrons) (uma subjanela da janela Crystal).

## Sistema de coordenadas (figura de referência comum)

Cada uma das páginas a seguir pressupõe o mesmo sistema de coordenadas. A origem é o ponto direto no IP (o ponto em que o feixe intercepta o IP), o eixo $Z$ é a direção de propagação do feixe e a amostra fica em $(0,\ 0,\ -\mathrm{CL})$.

![Sistema de coordenadas do IPAnalyzer. Mostra o IP (Imaging Plate), os eixos X / Y / Z, os anéis de Debye, os ângulos de inclinação φ e τ, a amostra em (0,0,−CL), o comprimento de câmara CL, o ângulo de difração 2θ, o comprimento de onda λ e a forma do pixel (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parâmetros principais

| Símbolo | Nome | Significado |
|------|------|------|
| $\lambda$ | Comprimento de onda (Wave Length) | Comprimento de onda da fonte. É conhecido para raios X característicos; para radiação síncrotron, varia com a posição do monocromador e precisa ser determinado a cada vez. |
| $\mathrm{CL}$ | Comprimento da câmera (Camera Length) | Distância entre a amostra e a origem (ponto direto). A posição da amostra é $(0,0,-\mathrm{CL})$. Corresponde a **Comprimento da câmera 1 (Camera Length 1)** na tela; **Comprimento da câmera 2 (Camera Length 2)** é a distância perpendicular da amostra ao detector, que difere quando há uma inclinação $\tau$. |
| $\varphi,\ \tau$ | Correção de inclinação (Tilt Correction) | Inclinação do IP em relação ao eixo óptico (eixo $Z$). $\varphi$ é o azimute do eixo de inclinação no plano XY, e $\tau$ é o ângulo de rotação em torno desse eixo. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Tamanho do pixel (Pixel Size) | Representa um pixel como um paralelogramo. $\xi$ é o deslocamento do ponto inicial da varredura do laser de leitura (ângulo de distorção). |

O comprimento de onda é definido na aba **Fonte de ondas (Wave source)** da janela de propriedades, e o comprimento de câmara, a inclinação e a forma do pixel na aba **Condição do detector (Detector condition)** (veja [2. Janelas de propriedades](../2-property-windows.md)).
