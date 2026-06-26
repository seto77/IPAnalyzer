<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Ferramentas

Esta página descreve as ferramentas auxiliares iniciadas a partir da barra de ferramentas vertical à direita da janela principal ou dos menus. Para procedimentos concretos usando calibração de parâmetros e macros, consulte [Procedimentos](4-procedures.md).

## Intensity Table

Uma ferramenta que compara as distribuições de intensidade de duas imagens e otimiza uma tabela de conversão de intensidade. Ela otimiza 16 pontos de controle ao longo de 300 iterações para igualar as duas intensidades preservando a intensidade integrada total. É usada, por exemplo, para calibrar a resposta de intensidade de um detector.

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

Uma ferramenta que monitora uma pasta, carrega novas imagens automaticamente e executa uma sequência de operações após o carregamento.

- **Watch and auto-load**: monitora a pasta especificada (incluindo subpastas) e lê um arquivo após a conclusão de sua escrita. Os arquivos podem ser filtrados por nome (correspondência de número, palavra-chave).
- **Auto execution**: executa as etapas marcadas, em ordem, dentre Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro.

Isso permite usos como monitorar uma pasta de saída durante um experimento e integrar cada imagem automaticamente à medida que chega. Consulte [Procedimentos](4-procedures.md) para detalhes.

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

Desenha um anel a uma distância, ângulo ou valor d especificado na imagem, levando em conta a inclinação do IP e a distorção do pixel. Clique em um de **R (mm)** / **2θ (°)** / **d (Å)** para escolher qual valor editar; os outros são calculados automaticamente a partir do comprimento de onda e do comprimento de câmara.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

Desdobra a imagem de difração de coordenadas polares centradas no ponto direto para coordenadas cartesianas (eixo horizontal = ângulo, distância ou valor d; eixo vertical = azimute). Agora ele é configurado não com uma janela dedicada, mas com o botão **Unroll** da barra de ferramentas e a aba **Unrolled Image Option** das propriedades. O desenrolamento usa o mesmo algoritmo de distribuição de intensidade sub-pixel que a unidimensionalização.

## Circumferential Blur

Uma ferramenta que desfoca o padrão de anéis ao longo da direção circunferencial (azimutal). Especifique um único ângulo de desfoque e aplique-o.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

Uma ferramenta para lidar com imagens multiquadro (HDF5 e similares; séries temporais, séries de temperatura, varreduras de energia em síncrotron).

- Selecione um único quadro na lista de quadros para exibi-lo ou avance com a trackbar.
- Com a **seleção múltipla**, selecione vários quadros e calcule sua **média** ou **soma**.
- O alvo da unidimensionalização pode ser escolhido entre "todos os quadros / quadros selecionados / apenas o do topo".
- Se cada quadro carregar informação de energia, o comprimento de onda é atualizado automaticamente.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

Corrige a inclinação do IP φ, τ e a distorção do pixel ξ, e salva a imagem com pixels quadrados em uma resolução especificada. Metadados como o comprimento de câmara, o comprimento de onda e a posição do centro também são gravados, de modo que a imagem possa ser passada para outro processamento de imagem preservando a informação geométrica.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

Uma ferramenta que otimiza o comprimento de onda, o comprimento de câmara, o tamanho do pixel, a distorção do pixel e a inclinação (φ, τ) a partir dos anéis de difração de um material de referência. Ela usa dois padrões, Primary e Secondary, e você seleciona picos e otimiza com **Refine!**. A convergência (centro da elipse, resíduos) pode ser verificada nos gráficos. Consulte [Procedimentos](4-procedures.md) para os passos concretos.

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

Uma ferramenta que encontra o comprimento de câmara e o comprimento de onda por uma busca exaustiva em grade em vez de um método de gradiente. É eficaz quando a otimização geométrica tem dificuldade para convergir, como em anéis incompletos ou dados ruidosos. O CrystalControl é usado para inserir os parâmetros do cristal. Consulte [Encontrar parâmetros (força bruta)](6-find-parameter.md) para os passos detalhados, e [Procedimentos](4-procedures.md) para o fluxo de trabalho.

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Um recurso que automatiza operações com scripts no estilo Python. Abra o editor de macros a partir do menu **Macro → Editor** na janela principal.

- `for` / `if` / `while` / `def` / `class`, aritmética e o módulo `math` estão disponíveis.
- APIs como `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permitem chamar cada operação.
- Macros de exemplo (laços básicos, configuração de geometria, processamento em lote, divisão azimutal, mascaramento, envio ao PDIndexer, etc.) vêm incluídas, e você pode inspecionar variáveis com execução passo a passo.

Consulte [Macro](5-macro/index.md) para a referência completa de funções e exemplos, e [Procedimentos](4-procedures.md) para fluxos de trabalho baseados em macros.

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

Uma ferramenta destinada à correção de intensidade específica de detectores R-Axis; no momento ela apenas lê o arquivo, e a correção em si ainda não foi implementada.

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
