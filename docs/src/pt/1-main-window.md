<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). -->

# Janela principal

A janela principal é a primeira tela exibida quando o IPAnalyzer é iniciado. Ela reúne a exibição da imagem de difração carregada, as operações principais (localizar o centro, mascarar pontos, conversão para uma dimensão) e os pontos de acesso às configurações dos parâmetros do detector.

A janela é composta, de forma geral, pelos menus e pela barra de ferramentas na parte superior, pela área de exibição da imagem no centro, pela barra de ferramentas vertical à direita e pela área de gráficos na parte inferior.

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## Vista central

### Exibição da imagem

A imagem carregada é exibida aqui. Conforme a posição do ponteiro do mouse, a área acima da imagem mostra as coordenadas reais (mm), as coordenadas da imagem (pix), a distância ao centro R (mm), o ângulo de espalhamento 2θ, o valor d, o azimute χ e a intensidade. A marca × magenta indica a posição do ponto direto (centro).

Os estados dos pixels são mostrados em cores distintas.

| Cor | Significado |
| --- | --- |
| Ciano | Ponto mascarado |
| Verde | Região excluída da integração (definida em **Região de integração (Integral Region)**) |
| Magenta | Região angular excluída da integração (definida em **Propriedade de integração (Integral Property)**) |
| Azul | Pixel abaixo do limiar de intensidade (definido em **Região de integração**) |
| Vermelho | Pixel acima do limiar de intensidade |

### Operações com o mouse

No modo normal:

- Clique duplo com o botão esquerdo: atualiza a posição do centro para o ponto clicado.
- Clique com o botão do meio: procura o centro a partir do ponto clicado.
- Arrastar com o botão direito: amplia a região arrastada.
- Clique com o botão direito: reduz o zoom.
- Ctrl + arrastar com o botão direito: seleciona a região retangular usada nas informações estatísticas.

O clique duplo com o botão esquerdo e o clique com o botão do meio só funcionam enquanto **Fixar centro (Fix Center)** está desativado.

No **Modo manual (Manual Mode)**, o clique com o botão esquerdo mascara e o clique com o botão direito remove a máscara. A forma e o tamanho da máscara são definidos na barra de ferramentas e nas propriedades.

### Vistas auxiliares e informação da imagem

Ao lado da vista central há exibições auxiliares. É possível alternar entre **Imagem inteira (Whole image)** e **Perto do centro (Near center)**: a vista da imagem inteira marca o intervalo de exibição atual com um quadro amarelo, e a vista perto do centro mostra uma imagem ampliada.

**Informação da imagem (Image Information)** mostra a resolução da imagem, a intensidade máxima, a intensidade total, os dados do cabeçalho etc.

### Controles de ajuste da exibição

Controles que ajustam a aparência da imagem:

- **Gradiente (Gradient)**: inverte a tonalidade.
- **Escala de brilho (Brightness scale)**: logarítmica / linear.
- **Escala de cores (Color scale)**: tons de cinza / cores.
- **Linha de escala (Scale line)**: exibição das linhas de escala (nenhuma / grossa / média / fina).
- **Contraste automático (Auto Contrast)** / **Redefinir contraste (Reset Contrast)**, e intensidade mínima/máxima explícita.
- Botões de ampliação (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vista inferior

A área inferior tem três gráficos/vistas em abas.

- **Frequência da intensidade (Frequency of Intensity)**: a distribuição de intensidade de todos os pixels, em eixos log–log. Pode ser ampliada com o mouse.
- **Perfil convertido (Converted Profile)**: o perfil de difração produzido por **Obter perfil (Get Profile)**. Pode ser ampliado com o mouse.
- **Informação estatística (Statistical Information)**: estatísticas da região retangular (X1,Y1)–(X2,Y2) selecionada com Ctrl + arrastar com o botão direito sobre a imagem. Quando uma imagem sequencial está carregada, também é possível comparar as estatísticas da mesma região em outros quadros.

## Menus

A barra de menus é composta por **Arquivo / Ferramenta / Propriedade / Opção / Idioma / Macro / Ajuda (File / Tool / Property / Option / Language / Macro / Help)**.

### Arquivo (File)

- **Ler imagem (Read image)**: abre uma imagem de difração. Veja a [Visão geral](0-overview.md) para os formatos suportados.
- **Salvar imagem (Save image)**: salva nos formatos TIFF, PNG, CSV ou IPA. O TIFF guarda as intensidades atuais dos pixels já processadas (após inversão/rotação, subtração de fundo e correção de polarização), o PNG preserva a exibição (brilho, contraste, máscara) e o IPA é um formato próprio com correção de distorção (com metadados).
- **Ler parâmetro / Salvar parâmetro (Read / Save parameter)**: importa/exporta o comprimento de onda, o comprimento de câmara, o tamanho do pixel, a correção de inclinação, a posição do centro etc. como um arquivo `.prm`.
- **Ler máscara / Salvar máscara / Limpar máscara (Read / Save / Clear mask)**: importa/exporta uma máscara como um arquivo `.mas`, ou a apaga (a máscara precisa ter a mesma resolução da imagem atual).
- **Fechar (Close)**.

Arquivos de imagem, de parâmetros e de máscara também podem ser carregados arrastando-os e soltando-os sobre a janela.

### Ferramenta (Tool)

- **Redefinir perfil de frequência (Reset Frequency Profile)**: reconstrói o gráfico de frequência de intensidade da imagem atual com o intervalo padrão (a imagem é mantida).
- **Calibrar imagem R-AXIS (Calibrate Raxis Image)**: obtém uma tabela de conversão de intensidade a partir de duas imagens R-AXIS (veja [Ferramentas](3-tools.md)).

### Propriedade (Property)

**Fonte de radiação (Wave Source)** / **Condição da imaging plate (Imaging Plate Condition)** / **Região de integração (Integral Region)** / **Propriedade de integração (Integral Property)** / **Modo de máscara manual (Manual Mask Mode)** / **Após "Obter perfil" (After "Get Profile")** / **Opção de imagem desenrolada (Unrolled Image Option)** / **Diversos (Miscellaneous)**. Esses itens abrem diretamente as abas correspondentes da [janela de propriedades](2-property-windows.md).

### Opção (Option)

- **Dica de ferramenta (ToolTip)**: ativa/desativa as dicas nos botões e menus.
- **Inverter (Flip)**: **Horizontalmente (Horizontally)** / **Verticalmente (Vertically)**. **Girar (Rotate)**: escolhe um ângulo de rotação. A inversão e a rotação são aplicadas aos dados da imagem em trabalho e, portanto, também afetam a integração e o salvamento da imagem posteriores (o arquivo de origem no disco não é alterado).
- **Limpar registro (Clear registry)**: um item de solução de problemas que apaga as configurações salvas. **Compilar Ngen (Ngen Compile)** não tem função na versão atual.

### Idioma (Language)

- Seleciona o idioma de exibição (11 idiomas). Após a confirmação, o aplicativo é reiniciado. A configuração é salva no registro.

### Macro

- **Editor**: abre o editor de macros (veja [Ferramentas](3-tools.md) / [Macro](5-macro/index.md)).

### Ajuda (Help)

- **Atualizações do programa (Program Updates)**, **Dica (Hint)**, **Licença (License)**, **Histórico de versões (Version History)**, **Ajuda (Help)** (abre o manual em PDF incluído).
- Pressione **F1** em qualquer janela para abrir a página correspondente deste manual on-line.

## Barra de ferramentas de operação

As principais operações de processamento de imagem (com opções detalhadas nos menus suspensos):

- **Fundo (Background)**: este botão está desativado na versão atual. A subtração de uma imagem de fundo é configurada na aba **Opção de fundo (Background Option)** da janela de propriedades.
- **Localizar centro (Find Center)**: detecta o centro do feixe por ajuste de uma Pseudo-Voigt 2D (por padrão, o intervalo de busca é de ±8 px em torno do centro, definido na aba **Diversos (Miscellaneous)**). Quando há anéis exibidos com **Desenhar anel (Draw ring)**, o centro passa a ser determinado a partir do anel.
- **Fixar centro (Fix Center)**: fixa a posição do centro.
- **Mascarar pontos (Mask Spots)**: dentro de cada faixa radial, os pixels cuja intensidade excede média + desvio-padrão × Deviation são detectados como pontos e mascarados junto com seus arredores. O menu suspenso inclui mascarar tudo, inverter a máscara, modo manual etc.
- **Modo manual (Manual Mode)**: o modo de máscara manual. É possível escolher a forma da máscara (ponto (círculo/retângulo) / círculo / retângulo / polígono / spline) e o tamanho do ponto (meia largura).
- **Obter perfil (Get Profile)**: integra a imagem em um perfil unidimensional. Suporta a integração concêntrica (baseada em 2θ) e a radial (baseada no azimute). O menu suspenso configura a escolha de **Propriedade de integração** / **Região de integração**, se o centro deve ser localizado e os pontos mascarados antes da integração, o envio ao PDIndexer, a análise de divisão azimutal, o processamento de imagens sequenciais etc.

## Barra de ferramentas (outras ferramentas)

A barra de ferramentas vertical à direita inicia as diversas ferramentas. Veja [Ferramentas](3-tools.md) para mais detalhes.

- **Tabela de intensidade (Intensity table)** (nenhuma função está atribuída a este botão na versão atual; use **Ferramenta → Calibrar imagem R-AXIS (Tool → Calibrate Raxis Image)** para a calibração de intensidade de R-AXIS)
- **Procedimento automático (Auto procedure)**
- **Desenhar anel (Draw ring)**
- **Localizar parâmetro (geometricamente) (Find parameter (geometrically))** / **Localizar parâmetro (força bruta) (Find parameter (brute force))**
- **Desenrolar imagem (Unroll image)**
- **Desfoque circunferencial (Circumferential blur)**
- **Imagem sequencial (Sequential image)**
