<!-- 261124Cl: Retranslated from en/3-tools.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Ferramentas

Esta página descreve as ferramentas auxiliares iniciadas pela barra de ferramentas vertical à direita da janela principal ou pelos menus. Para procedimentos concretos com calibração de parâmetros e macros, veja [Procedimentos](4-procedures.md).

## Calibrar imagem R-AXIS (Calibrate Raxis Image)

Abra-a com **Ferramenta → Calibrar imagem R-AXIS (Tool → Calibrate Raxis Image)**. Especifique duas imagens R-AXIS IV `.stl` do mesmo tamanho; a ferramenta otimiza uma tabela de conversão de intensidade para que as duas intensidades coincidam. A tabela é representada por pontos de controle, e a soma de seus elementos é mantida constante durante a otimização. O resultado é mostrado em um gráfico. É usada, por exemplo, para calibrar a resposta em intensidade de um detector.

![Calibrate Raxis Image](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Procedimento automático (Auto procedure)

Uma ferramenta que monitora uma pasta, carrega automaticamente as novas imagens e executa uma sequência de operações após o carregamento.

- **Monitoramento e carregamento automático**: monitora a pasta especificada (**Diretório a ser monitorado (Directory to be monitored)**, incluindo as subpastas) e lê um arquivo depois que sua gravação termina. Os arquivos podem ser filtrados pelo nome (**Correspondência de padrões (Pattern matching)** sobre o número no nome do arquivo, **Palavra-chave (Keyword)**); os arquivos que não correspondem são ignorados sem espera. Se um arquivo ainda estiver bloqueado depois da espera pela gravação (cerca de 50 s), ele não é descartado, mas tentado novamente nas varreduras seguintes; só se desiste dele se ainda estiver bloqueado 10 minutos depois de ter sido encontrado pela primeira vez.
- **Execução automática**: quando **Após carregar a nova imagem, executar a seguinte sequência (Once the new image is loaded, perform the following sequence)** está ativado, executa, em ordem, as etapas marcadas entre **Auto contrast** → **Find center** → **Mask spots** → **Get profile** → **Execute macro**.

Isso permite usos como monitorar a pasta de saída durante um experimento e integrar automaticamente cada imagem assim que ela chega. Veja [Procedimentos](4-procedures.md) para mais detalhes.

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Desenhar anel (Draw Ring)

Desenha um anel a uma distância, um ângulo ou um valor d especificado sobre a imagem, levando em conta a inclinação do IP e a distorção do pixel. Clique em um de **R (mm)** / **2θ (°)** / **d (Å)** para escolher qual valor editar; os demais são calculados automaticamente a partir do comprimento de onda e do comprimento de câmara.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Desenrolar (Unroll)

Desdobra a imagem de difração das coordenadas polares centradas no ponto direto para coordenadas cartesianas (eixo horizontal = ângulo de espalhamento 2θ; eixo vertical = azimute). Atualmente, isso não é configurado em uma janela própria, mas com o botão **Desenrolar imagem (Unroll image)** da barra de ferramentas e com a aba **Opção de imagem desenrolada (Unrolled Image Option)** das propriedades. O desenrolamento usa o mesmo algoritmo de distribuição de intensidade sub-pixel da integração em um perfil 1D.

## Desfoque circunferencial (Circumferential Blur)

Uma ferramenta que desfoca o padrão de anéis ao longo da direção circunferencial (azimutal). Especifique um único ângulo de desfoque e aplique-o.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Imagem sequencial (Sequential Image)

Uma ferramenta para lidar com imagens multiquadro (NeXus (`.nxs`), TIFF de várias páginas e semelhantes; séries temporais, séries de temperatura, varreduras de energia em síncrotron).

- Selecione um único quadro na lista de quadros para exibi-lo, ou percorra-os com a barra deslizante.
- Com **Seleção múltipla (Multi selection)**, selecione vários quadros e calcule a **Média (Average)** ou a **Soma (Summation)**.
- Os quadros integrados por **Obter perfil (Get Profile)** são escolhidos em **Alvo(s) de "Obter perfil" (Target(s) of "Get Profile")**: **Todas as imagens independentemente das seleções atuais (All images irrespective of current selections)** / **A(s) imagem(ns) selecionada(s) (The selected image(s))** / **Apenas a imagem superior (Only the topmost image)**.
- Se um quadro contém informação de energia, o comprimento de onda é atualizado quando esse quadro é selecionado sozinho.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Salvar imagem (formato IPA)

Corrige a inclinação do IP φ, τ e a distorção do pixel ξ, e salva a imagem com pixels quadrados em uma resolução especificada. Metadados como o comprimento de câmara, o comprimento de onda e a posição do centro também são gravados, de modo que a imagem pode ser passada a outros processamentos de imagem preservando a informação geométrica.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Encontrar parâmetros (geométrico)

Uma ferramenta que otimiza o comprimento de onda, o comprimento de câmara, o tamanho do pixel, a distorção do pixel e a inclinação (φ, τ) a partir dos anéis de difração de um material de referência. Ela usa uma imagem de uma amostra de referência (**Primária (Primary)**), ou duas imagens tomadas em comprimentos de câmara diferentes (**Primária** e **Secundária (Secondary)**); você seleciona os picos e otimiza com **Refinar! (Refine!)**. A convergência (centro da elipse, resíduos) pode ser verificada nos gráficos. Veja [Procedimentos](4-procedures.md) para as etapas concretas.

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Encontrar parâmetros (força bruta)

Uma ferramenta que encontra o comprimento de câmara, a posição do centro, a inclinação (φ, τ) e, opcionalmente, o comprimento de onda (desativado por padrão) por uma busca exaustiva em grade, em vez de um método de gradiente. Ela usa a imagem única de uma amostra de referência carregada na janela principal. É eficaz quando a otimização geométrica tem dificuldade em convergir, como com anéis incompletos ou dados ruidosos. Escolha o padrão entre Au / CeO₂ / LaB₆ / Al₂O₃, ou selecione **Outro (Other)** e informe o cristal. Veja [Encontrar parâmetros (força bruta)](6-find-parameter.md) para as etapas detalhadas e [Procedimentos](4-procedures.md) para o fluxo de trabalho.

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Uma funcionalidade que automatiza operações com scripts no estilo Python. Abra o editor de macros pelo menu **Macro → Editor** da janela principal.

- `for` / `if` / `while` / `def` / `class`, a aritmética e o módulo `math` estão disponíveis.
- APIs como `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permitem chamar cada operação.
- Ative **Mostrar exemplos (Show samples)** para ver as macros de exemplo somente leitura (laços básicos, configuração da geometria, processamento em lote, divisão azimutal, mascaramento, envio ao PDIndexer etc.). É possível inspecionar as variáveis com a execução passo a passo.

Veja [Macro](5-macro/index.md) para a referência completa de funções e os exemplos, e [Procedimentos](4-procedures.md) para fluxos de trabalho baseados em macros.

![Macro editor](../assets/cap-en-auto/FormMacro.png)
