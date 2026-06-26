<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Janelas de propriedades

A janela de propriedades é onde você configura a fonte, as condições do detector e as diversas condições de unidimensionalização. Cada aba também pode ser aberta diretamente pelo menu **Property** na janela principal.

A interface desta janela está em inglês. Os títulos abaixo usam os nomes reais das abas e dos controles.

## Wave source

Define o tipo do feixe incidente e o comprimento de onda. A fonte pode ser raios X, elétrons ou nêutrons. Para raios X, selecionar um elemento e uma transição (linha K, linha L, etc.) preenche o comprimento de onda automaticamente; para radiação síncrotron, informe o comprimento de onda diretamente. Para feixes de elétrons e nêutrons, informe a energia ou o comprimento de onda (o comprimento de onda do elétron recebe correção relativística).

- **Correct linear polarization**: corrige uma intensidade linearmente polarizada para o equivalente não polarizado (para dados de síncrotron). A fórmula de correção abaixo depende do azimute χ (definido na aba Miscellaneous) e do ângulo de espalhamento 2θ.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

Define as condições geométricas do detector. Corresponde à antiga "IP Condition", com o acréscimo de seletores de sistema de coordenadas e de forma do detector.

- **Coordinates**: **Direct spot** (referência pelo ponto direto) / **Foot** (referência pelo pé da perpendicular).
- **Detector type**: **Flat panel** / **Gandolfi**.
- **Direct spot position** e **Camera Length 1**: a posição do ponto direto (X, Y pix) e a distância da amostra ao ponto direto (mm).
- **Foot position** e **Camera Length 2**: no modo Foot, a posição do pé da perpendicular e a distância da amostra ao pé.
- **Pixel Shape**: tamanho do pixel X, Y (mm) e ξ (Ksi, o ângulo de inclinação do paralelogramo).
- **Gandolfi Radius**: o raio, quando a forma Gandolfi está selecionada.
- **Spherical correction**: correção esférica (normalmente zero).
- **Tilt**: a inclinação do IP φ (Phi) e τ (Tau).

Consulte [Visão geral](0-overview.md) para as definições da inclinação φ, τ e do pixel ξ.

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

Especifica a região da imagem a ser unidimensionalizada.

- **Rectangle**: escolha a **Direction** (Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free) e defina o **Band Width**, o **Angle** (no modo Free) e **Both Side**.
- **Sector**: especifique a faixa angular com **Start Angle** / **End Angle**.
- **Exceptional pixels**: exclua os **Masked Spots**, os pixels **Under intensity of** / **Over intensity of** os limiares informados e um número de **pixels from edges**.

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

Define o método de integração e o passo.

- **Concentric integration (scattering-angle dispersive)**: escolha a unidade do eixo horizontal entre **Angle** (2θ, °) / **Length** (mm) / **d-spacing** (Å) e defina **Start / End / Step**. O **Output pattern** pode ser **Bragg - Brentano** ou **Debye - Scherrer**.
- **Radial integration (cake pattern)**: analisa uma região em forma de anel na direção azimutal. Escolha o eixo horizontal entre **Angle** / **d-spacing** e defina o **Donut radius** (raio central), o **Donut width** (largura do anel) e o **Sector angle step** (passo de varredura).

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

Define as condições de mascaramento e de detecção de centro/pontos (uma expansão da antiga "Find Center & Spots").

- **Half mask**: botões que mascaram rapidamente a metade superior, inferior, esquerda ou direita da imagem.
- **Manual mask mode**: habilita o mascaramento interativo sobre a imagem principal. As formas são **Circle** (arraste para definir centro e raio), **Polygon** (clique para adicionar vértices), **Rectangle** (arraste vértices diagonais), **Spline curve** e **Spot** (clique esquerdo/direito para adicionar/remover pontos).
- **Takeover**: como a máscara é tratada quando uma nova imagem é carregada (**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation**: o limiar estatístico para a detecção de pontos.
- **Find Center**: a faixa de busca para a detecção do centro, e assim por diante.

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

Define o salvamento e o envio após a unidimensionalização.

- **Save File**: escolha o destino ("o mesmo diretório da imagem" ou "um diretório escolhido a cada vez") e o formato entre **PDI** / **CSV** / **TSV** / **GSAS**.
- **Send PDIndexer**: envia o perfil, via área de transferência, para uma instância em execução do PDIndexer.

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

Define os parâmetros da imagem desenrolada (Unroll).

- **Horizontal**: a unidade (Angle / Length / d-spacing) e **Start / End / Step**. A largura da imagem de saída ≈ (End − Start) / Step.
- **Vertical**: o passo azimutal (°/pixel). A altura da imagem de saída ≈ 360 / step.

O desenrolamento mapeia a imagem de difração polar centrada no ponto direto em uma imagem cartesiana (ângulo vs. distância).

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

Uma aba que reúne os ajustes mais finos de exibição e de coordenadas.

- **Image name display**: apenas o nome do arquivo / pasta pai + nome do arquivo / caminho completo.
- **Contrast / intensity-range persistence**: se as configurações de exibição são mantidas quando uma nova imagem é carregada.
- **Azimuth χ (Chi) orientation**: a posição de referência (Top / Bottom / Left / Right) e o sentido de rotação (Clockwise / Counterclockwise). χ é referenciado pela correção de polarização e pela integração radial.
- **Scale line**: cor, largura, número de divisões e exibição de rótulos.
- **Find Center**: faixa de busca, faixa de ajuste de pico, fixar centro e excluir pixels mascarados.

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

Define a correção por uma imagem de fundo.

- **Background image**: defina a imagem exibida no momento como fundo (**Set the current image as background**) ou remova-a (**Clear**).
- **Coefficient**: o fator aplicado à imagem de fundo.
- **Edge mask**: uma margem de máscara adicional (px) aplicada nas bordas durante a correção.

Usado para correção de campo plano (flat-field), remoção de espalhamento de ar e similares.

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
