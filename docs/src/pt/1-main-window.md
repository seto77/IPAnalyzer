<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# Janela principal

A janela principal é a primeira tela exibida quando o IPAnalyzer é iniciado. Ela reúne a visualização da imagem de difração carregada, as operações principais (encontrar o centro, mascarar pontos, unidimensionalizar) e os pontos de acesso à configuração dos parâmetros do detector.

A janela é composta, de modo geral, pelos menus e pela barra de ferramentas na parte superior, pela área de visualização da imagem ao centro, pela barra de ferramentas vertical à direita e pela área de gráfico na parte inferior.

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## Vista central

### Visualização da imagem

A imagem carregada é exibida aqui. Conforme a posição do ponteiro do mouse, a área acima da imagem mostra as coordenadas reais (mm), as coordenadas da imagem (pix), a distância em relação ao centro R (mm), o ângulo de espalhamento 2θ, o valor d, o azimute χ e a intensidade. A marca × magenta indica a posição do ponto direto (centro).

Os estados dos pixels são mostrados em cores distintas.

| Cor | Significado |
| --- | --- |
| Ciano | Ponto mascarado |
| Verde | Região excluída da integração (definida em Integral Region) |
| Magenta | Região angular excluída da integração (definida em Integral Property) |
| Azul | Pixel abaixo do limiar de intensidade (definido em Integral Region) |
| Vermelho | Pixel acima do limiar de intensidade |

### Operações com o mouse

No modo normal:

- Manter pressionado o botão esquerdo: procura o centro do ponto nas proximidades.
- Duplo clique esquerdo: atualiza a posição do centro para o ponto clicado.
- Arrastar com o botão direito: aplica zoom na região arrastada.
- Clique direito: reduz o zoom.

No **Manual spot mode**, o clique esquerdo mascara e o clique direito desmascara. A forma e o tamanho da máscara são definidos na barra de ferramentas e nas propriedades.

### Vistas auxiliares e informações da imagem

Ao lado da vista central há visualizações auxiliares. Você pode alternar entre **Whole image** e **Near center**: a vista da imagem completa marca o intervalo de visualização atual com uma moldura amarela, e a vista de perto do centro mostra uma imagem ampliada.

**Image Information** mostra a resolução da imagem, a intensidade máxima, a intensidade total, os dados de cabeçalho, etc.

### Controles de ajuste da visualização

Controles que ajustam a aparência da imagem:

- **Gradient**: inverte o tom.
- **Brightness scale**: logarítmica / linear.
- **Color scale**: escala de cinza / cor.
- **Scale line**: exibição da linha de escala (nenhuma / grossa / média / fina).
- **Auto Contrast** / **Reset Contrast**, e intensidade mínima/máxima explícita.
- Botões de ampliação (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vista inferior

A área inferior tem três gráficos/vistas em abas.

- **Frequency of Intensity**: a distribuição de intensidade de todos os pixels, em eixos log–log. Ampliável com o mouse.
- **Converted Profile**: o perfil de difração após a unidimensionalização (Get Profile). Ampliável com o mouse.
- **Statistical Information**: estatísticas de uma região retangular selecionada (X1,Y1)–(X2,Y2). Quando uma imagem sequencial é carregada, também é possível comparar as estatísticas da mesma região em outros quadros.

## Menus

A barra de menus é composta por **File / Tool / Property / Option / Language / Macro / Help**.

### File

- **Read image**: abre uma imagem de difração. Consulte [Visão geral](0-overview.md) para conhecer os formatos compatíveis.
- **Save image**: salva no formato TIFF, PNG, CSV ou IPA. TIFF preserva as intensidades de pixel originais, PNG preserva a visualização (brilho, contraste, máscara), e IPA é um formato proprietário com correção de distorção (com metadados).
- **Read / Save parameter**: importa/exporta o comprimento de onda, o comprimento de câmara, o tamanho do pixel, a correção de inclinação, a posição do centro, etc., como um arquivo `.prm`.
- **Read / Save / Clear mask**: importa/exporta uma máscara como um arquivo `.mas`, ou a apaga (a máscara deve corresponder à resolução da imagem atual).
- **Close**.

Arquivos de imagem, parâmetros e máscara também podem ser carregados arrastando-os e soltando-os sobre a janela.

### Tool

- **Reset Frequency Profile**: apaga o gráfico de frequência de intensidade (a imagem é mantida).
- **Calibrate Raxis Image**.

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. Estes abrem diretamente as abas correspondentes da [janela de propriedades](2-property-windows.md).

### Option

- **ToolTip**: ativa/desativa as dicas de ferramentas dos botões e menus.
- **Flip**: horizontal / vertical. **Rotate**: escolha um ângulo de rotação. Ambos afetam apenas a visualização; os dados da imagem carregada não são alterados.
- **Ngen Compile** e **Clear registry** são para desenvolvimento e resolução de problemas.

### Language

- Alterna entre **English** e **Japanese** (a configuração é salva no registro).

### Macro

- **Editor**: abre o editor de macros (consulte [Ferramentas](3-tools.md) / [Macro](5-macro/index.md)).

### Help

- **Program Updates**, **Hint**, **License**, **Version History**, **Web Page**.

## Barra de ferramentas de operações

As principais operações de processamento de imagem (com opções detalhadas nos menus suspensos):

- **Background**: subtração de uma imagem de fundo (configurada em Background Option).
- **Find Center**: detecta o centro do feixe por ajuste Pseudo-Voigt 2D (intervalo de busca de 8 px por padrão, definido em Miscellaneous). O menu suspenso também oferece a detecção do centro baseada em anéis.
- **Fix center**: fixa a posição do centro.
- **Mask Spots**: detecta e mascara pontos usando o critério média ± desvio padrão × Deviation. O menu suspenso inclui mascarar tudo, máscara inversa, manual, etc.
- **Manual**: o modo de máscara manual. Você pode escolher a forma (círculo / retângulo) e o tamanho (8–256 px).
- **Get Profile**: integra a imagem em um perfil unidimensional. Suporta Concentric (baseado em 2θ) e Radial (baseado no azimute). O menu suspenso configura a seleção de Integral Property/Region, se o centro deve ser encontrado e os pontos mascarados antes da integração, o envio para PDIndexer, a análise por divisão azimutal, o processamento de imagens sequenciais, etc.

## Barra de ferramentas (outras ferramentas)

A barra de ferramentas vertical à direita inicia as diversas ferramentas. Consulte [Ferramentas](3-tools.md) para mais detalhes.

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
