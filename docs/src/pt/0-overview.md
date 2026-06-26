<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Visão geral

O IPAnalyzer converte anéis de Debye–Scherrer registrados com imaging plates (IP) ou detectores CCD/CMOS em perfis de difração unidimensionais, com alta precisão e velocidade. Seu projeto e suas funcionalidades são baseados no PIP, desenvolvido por Hiroshi Fujihisa no National Institute of Advanced Industrial Science and Technology (AIST).

Funcionalidades principais:

- Suporta uma ampla variedade de formatos de imagem (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon e formatos de imagem genéricos)
- Fontes de raios X, elétrons e nêutrons
- Integração com o PDIndexer
- Análise semiautomática dos parâmetros de medição

## Requisitos de sistema e instalação

### Requisitos

- SO: Windows (Windows 11 recomendado)
- Runtime necessário: .NET Desktop Runtime 10.0
- Memória recomendada: 16 GB ou mais
- CPU recomendada: 8 núcleos ou mais

Internamente, o software faz uso intenso de computação multithread, de modo que uma CPU com mais núcleos funciona com mais folga. As intensidades da imagem são mantidas internamente como valores de ponto flutuante de dupla precisão.

O software é distribuído sob a licença MIT.

### Instalação

1. Instale antecipadamente o [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Baixe `IPAnalyzerSetup.msi` na [página de releases](https://github.com/seto77/IPAnalyzer/releases) do GitHub.
3. Execute `IPAnalyzerSetup.msi` para instalar.

## Orientação dos eixos, inclinação do IP e forma do pixel

O IPAnalyzer usa um sistema de coordenadas destro, com a origem e as direções dos eixos definidas como segue.

- O ponto onde o feixe de raios X ou de elétrons intersecta o IP (o direct spot) é definido como a origem (0, 0, 0), e o eixo Z coincide com a direção do feixe.
- Tratando o tamanho da amostra como infinitesimal, a distância entre a posição da amostra e a origem é definida como o comprimento de câmara (Camera Length, CL). A amostra está, portanto, localizada em \((0,\ 0,\ -\mathrm{CL})\).
- O eixo X é alinhado com a direção de varredura do laser de leitura do IP quando o IP não está inclinado. O eixo Y aponta, portanto, para baixo na tela.
- A inclinação do IP é expressa como uma rotação em torno de uma reta contida no plano XY que passa pela origem: uma rotação de \( \tau \) em torno da reta que forma um ângulo \( \varphi \) com o eixo X.
- A forma do pixel é tratada como um paralelogramo descrito por PixSizeX, PixSizeY e \( \xi \). Um \( \xi \) não nulo significa que há um deslocamento na posição inicial da varredura do laser de leitura do IP. O software supõe que esse deslocamento é constante ao longo do eixo Y.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

O comprimento de câmara, \( \varphi \), \( \tau \), o tamanho do pixel e \( \xi \) são definidos na aba IP Condition da janela de propriedades (consulte [2. Property Windows](2-property-windows.md)).

### Relação com o (WIN)PIP

No IPAnalyzer, o eixo X (a direção para a direita da imagem do IP) é rotacionado no sentido horário por \( \varphi \), e o eixo resultante é então rotacionado por \( \tau \). No PIP, o eixo Y (a direção para baixo da imagem do IP) é rotacionado no sentido anti-horário por \( \beta \), e o eixo resultante é então rotacionado por \( \Phi \). Portanto, para converter o \((\beta,\ \Phi)\) do PIP no \((\varphi,\ \tau)\) do IPAnalyzer, use \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Método de integração da intensidade dos pixels

O problema central na unidimensionalização é como distribuir, entre os passos de integração, a intensidade de um pixel que abrange vários passos — o que acontece quando o intervalo do passo angular é menor que o intervalo entre pixels (isto é, o tamanho do pixel).

O software calcula as interseções entre as linhas que delimitam cada passo e o pixel, e distribui a intensidade encontrando a área do pixel contida em cada passo. Para tratar os casos em que o pixel não é exatamente quadrado — por causa da inclinação do IP ou da distorção da forma do pixel — as coordenadas dos quatro cantos de cada pixel são calculadas sucessivamente para determinar sua forma quadrilátera. Em princípio, isso permite que a intensidade do pixel seja distribuída suavemente entre os passos, por menores que sejam os passos definidos.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

Esse algoritmo é usado não apenas na integração comum ângulo–intensidade (Concentric Integration), mas também na integração ao longo da circunferência (Radial Integration) e no cálculo da imagem desenrolada (Unrolled Image).
