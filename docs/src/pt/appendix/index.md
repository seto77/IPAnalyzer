<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Apêndice

Este apêndice resume o **embasamento teórico da geometria e dos algoritmos** que o IPAnalyzer utiliza ao converter uma imagem de difração bidimensional (anéis de Debye–Scherrer) em um perfil unidimensional de alta precisão. Para procedimentos operacionais e instruções de uso de cada recurso, consulte o manual principal ([0. Visão geral](../0-overview.md), [4. Procedimentos práticos](../4-procedures.md), etc.). Aqui explicamos, com equações, as definições do sistema de coordenadas, as transformações de coordenadas, os métodos de determinação de parâmetros e o algoritmo de integração por trás disso.

O conteúdo baseia-se no documento legado `doc/IPAnalyzerAlgorithm.pdf` incluído no pacote de distribuição e na implementação atual.

## Estrutura do apêndice

- **[A1. Geometria do detector e transformações de coordenadas](a1-geometry.md)** — definição do sistema de coordenadas destro, as matrizes de rotação que descrevem a inclinação da IP ($\varphi,\ \tau$) e a correção da forma do pixel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Determinação de parâmetros](a2-calibration.md)** — calibração do comprimento de câmara, comprimento de onda, tamanho do pixel e inclinação da IP usando um material de referência (método de duas distâncias, método de duas linhas, ajuste de elipse).
- **[A3. Integração da imagem](a3-image-integration.md)** — o algoritmo de particionamento de área que distribui as intensidades dos pixels em passos angulares.
- **[A4. Informação de simetria](a4-symmetry-information.md)** — simetria do grupo espacial, cálculos geométricos, posições de Wyckoff, condições de reflexão e diagramas de elementos de simetria do cristal padrão (uma subjanela da janela Crystal).
- **[A5. Fator de espalhamento](a5-scattering-factor.md)** — fatores de estrutura e a lista de reflexões do cristal padrão (raios X, elétrons, nêutrons) (uma subjanela da janela Crystal).

## Sistema de coordenadas (figura de referência comum)

Cada uma das páginas a seguir pressupõe o mesmo sistema de coordenadas como premissa comum. A origem é o ponto direto (direct spot) na IP (o ponto onde o feixe intercepta a IP), o eixo $Z$ é a direção de propagação do feixe e a amostra está localizada em $(0,\ 0,\ -\mathrm{CL})$.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parâmetros principais

| Símbolo | Nome | Significado |
|------|------|------|
| $\lambda$ | Wave Length | Comprimento de onda da fonte. Conhecido para raios X característicos; para radiação síncrotron varia com a posição do monocromador e deve ser determinado a cada vez. |
| $\mathrm{CL}$ | Camera Length | Distância entre a amostra e a origem (direct spot). A posição da amostra é $(0,0,-\mathrm{CL})$. |
| $\varphi,\ \tau$ | Tilt Correction | Inclinação da IP em relação ao eixo óptico (eixo $Z$). $\varphi$ é o azimute do eixo de inclinação no plano XY e $\tau$ é o ângulo de rotação em torno desse eixo. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | Representa um pixel como um paralelogramo. $\xi$ é o deslocamento do ponto inicial de varredura do laser de leitura (ângulo de distorção). |

Esses valores são definidos na aba IP Condition da janela de propriedades (consulte [2. Janelas de propriedades](../2-property-windows.md)).
