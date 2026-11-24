<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Visão geral

O IPAnalyzer converte anéis de Debye–Scherrer registrados com Imaging Plates (IP) ou detectores CCD/CMOS em perfis de difração 1D, com alta precisão e rapidez. Seu projeto e suas funcionalidades seguem o PIP, desenvolvido por Hiroshi Fujihisa no National Institute of Advanced Industrial Science and Technology (AIST).

Principais funcionalidades:

- Suporte a uma ampla gama de formatos de imagem (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`) e formatos de imagem gerais)
- Fontes de raios X, elétrons e nêutrons
- Integração com o PDIndexer
- Análise semiautomática dos parâmetros de medição

## Requisitos de sistema e instalação

### Requisitos

Estes requisitos aplicam-se às compilações .NET 11 feitas a partir deste código-fonte. Para as versões publicadas, siga o requisito de runtime indicado para cada versão.

- SO: Windows (Windows 11 recomendado)
- Runtime necessário: .NET Desktop Runtime 11.0
- Memória recomendada: 16 GB ou mais
- CPU recomendada: 8 núcleos ou mais

Internamente, o software faz uso intenso de cálculo multithread, de modo que uma CPU com mais núcleos funciona com mais folga. As intensidades da imagem são mantidas internamente como valores de ponto flutuante de precisão dupla.

O software é distribuído sob a licença MIT.

### Instalação

1. Baixe o arquivo adequado ao seu PC na [página de releases](https://github.com/seto77/IPAnalyzer/releases/latest) do GitHub.
    - `IPAnalyzer-setup.msi`: instalador para PCs Windows comuns (x64) (recomendado). `IPAnalyzerSetup.msi` é idêntico; esse nome é mantido para a atualização automática a partir de versões antigas.
    - `IPAnalyzer-setup_arm64.msi`: instalador para Windows on Arm.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`: versão portátil (sem instalação; o runtime do .NET vem incluído), para PCs sem direitos de administrador.
2. No caso do instalador, instale antes o [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) e depois execute o `.msi` baixado.
3. No caso da versão portátil, extraia o ZIP para uma pasta em que o usuário tenha permissão de escrita e execute `IPAnalyzer.exe` (não o inicie de dentro do visualizador de ZIP).

## Orientação dos eixos, inclinação do IP e forma do pixel

O IPAnalyzer usa um sistema de coordenadas dextrógiro, com a origem e as direções dos eixos definidas como segue.

- O ponto em que o feixe de raios X ou de elétrons intercepta o IP (o ponto direto) é definido como a origem (0, 0, 0), e o eixo Z coincide com a direção do feixe.
- Tratando o tamanho da amostra como infinitesimal, a distância entre a posição da amostra e a origem é definida como o comprimento de câmara (Camera Length, CL). A amostra fica, portanto, em \((0,\ 0,\ -\mathrm{CL})\).
- O eixo X está alinhado com a direção de varredura do laser de leitura do IP quando o IP não está inclinado. O eixo Y, portanto, aponta para baixo na tela.
- A inclinação do IP é expressa como uma rotação em torno de uma reta contida no plano XY que passa pela origem: uma rotação de \( \tau \) em torno da reta que forma um ângulo \( \varphi \) com o eixo X.
- A forma do pixel é tratada como um paralelogramo descrito por PixSizeX, PixSizeY e \( \xi \). Um \( \xi \) não nulo significa que há um deslocamento na posição inicial da varredura do laser de leitura do IP. O software supõe que esse deslocamento é constante ao longo do eixo Y.

O comprimento de câmara, \( \varphi \), \( \tau \), o tamanho do pixel e \( \xi \) são definidos na aba **Condição do detector (Detector condition)** da janela de propriedades (veja [2. Janelas de propriedades](2-property-windows.md)).

### Relação com o (WIN)PIP

No IPAnalyzer, o eixo X (a direção para a direita na imagem do IP) é girado no sentido horário por \( \varphi \), e o eixo resultante é então girado por \( \tau \). No PIP, o eixo Y (a direção para baixo na imagem do IP) é girado no sentido anti-horário por \( \beta \), e o eixo resultante é então girado por \( \Phi \). Portanto, para converter \((\beta,\ \Phi)\) do PIP em \((\varphi,\ \tau)\) do IPAnalyzer, use \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Método de integração da intensidade dos pixels

O problema central da integração da imagem é como distribuir, entre os passos de integração, a intensidade de um pixel que abrange vários passos — o que acontece sempre que o intervalo de ângulos de espalhamento coberto por um pixel ultrapassa um passo de 2θ (e com mais frequência quanto mais fino o passo).

O software calcula as interseções entre as retas que delimitam cada passo e o pixel, e distribui a intensidade determinando a área do pixel contida em cada passo. Para tratar os casos em que o pixel não é exatamente quadrado — por causa da inclinação do IP ou da distorção da forma do pixel — as coordenadas dos quatro cantos de cada pixel são calculadas sucessivamente para determinar sua forma quadrilátera. Em princípio, isso permite distribuir a intensidade do pixel de modo suave entre os passos, por menores que eles sejam.

Esse algoritmo é usado não apenas na integração comum ângulo–intensidade (Integração concêntrica, Concentric Integration), mas também na integração ao longo da circunferência (Integração radial, Radial Integration) e no cálculo da imagem desenrolada (Unrolled Image).
