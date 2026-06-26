<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Procedimentos

Esta página mostra o fluxo de tarefas típicas. Para descrições das ferramentas individuais, consulte [Tools](3-tools.md).

## Fluxo básico (integração concêntrica)

1. **Carregar uma imagem**: File → Read image (ou arrastar e soltar).
2. **Definir a fonte**: defina o elemento/transição ou o comprimento de onda em **Wave source** nas propriedades.
3. **Definir a condição do detector**: defina o comprimento de câmara, o tamanho do pixel, a posição do centro (aproximada) e, se necessário, a inclinação φ, τ em **Detector condition**.
4. **Encontrar o centro**: detecte o centro do feixe automaticamente com **Find Center** na barra de ferramentas (o intervalo de busca é definido em Miscellaneous).
5. **Mascarar pontos**: remova reflexões de monocristal e similares com **Mask Spots**. Se necessário, mascare manualmente com **Manual**.
6. **Unidimensionalizar**: obtenha o perfil com **Get Profile**. O salvamento e o envio são configurados na aba **After "Get Profile"** (salvar CSV, enviar para PDIndexer, etc.).

Para imagens sequenciais, selecione um quadro em [Sequential](3-tools.md) antes das etapas 5–6. Para análise por azimute, use a Radial integration em **Integral Property**.

## Determinação de parâmetros: calibração geométrica com uma amostra de referência (cassete duplo)

Quando o comprimento de câmara ou o comprimento de onda é desconhecido, otimize os parâmetros geométricos a partir dos anéis de difração de um material de referência (CeO2 por padrão, etc.), usando [Find Parameter (Geometric)](3-tools.md).

1. Carregue a **Primary image** (amostra de referência, em um comprimento de câmara) com Open, encontre o centro e exiba os picos com **Get Profile**.
2. Arrastar um marcador de linha de difração na Profile View atualiza automaticamente a estimativa do comprimento de câmara.
3. Carregue a **Secondary image** (a mesma amostra de referência, em um comprimento de câmara diferente) da mesma maneira e insira a **diferença de comprimento de câmara** em relação à Primary.
4. Na **Peak List**, selecione os valores de d dos picos que aparecem em ambas as imagens (pelo menos um por imagem, idealmente três ou mais).
5. Em **Refinement Option**, escolha os parâmetros a otimizar (comprimento de onda, distância do filme, inclinação, tamanho do pixel, distorção do pixel).
6. Execute **Refine!** e, assim que o resíduo estabilizar, copie os resultados otimizados de volta para o formulário principal.

!!! note
    Usar duas imagens (um "cassete duplo") facilita determinar separadamente o comprimento de câmara e o comprimento de onda.

## Determinação de parâmetros: otimização por força bruta (amostra arbitrária)

Quando a otimização geométrica tem dificuldade em convergir, busque exaustivamente o comprimento de câmara e o comprimento de onda com [Find Parameter (Brute force)](3-tools.md). Consulte [Find Parameter (brute force)](6-find-parameter.md) para um passo a passo detalhado com capturas de tela.

1. Carregue as imagens Primary e Secondary (duas imagens, com anéis em comum, em comprimentos de câmara diferentes).
2. Alinhe aproximadamente a posição do centro no formulário principal (o Find Center ajuda).
3. Insira os **intervalos de busca (min, max, step)** para o comprimento de câmara, o comprimento de onda, etc. Deixe os parâmetros desconhecidos (tamanho do pixel, inclinação) desativados no início.
4. Definir o **Integral Region** para um modo de fenda (Rectangle) com uma largura de banda estreita ajuda a suprimir o ruído.
5. Inicie a busca e copie a combinação com o menor resíduo de volta para o formulário principal.

## Processamento automatizado (Auto Procedure)

Processe automaticamente as imagens que chegam a uma pasta, por exemplo durante um experimento. Consulte [Tools](3-tools.md) para detalhes.

1. Habilite **Automatically load new images** e escolha a pasta monitorada com **Set**.
2. Se necessário, filtre os arquivos por **number matching** (o número no final do nome do arquivo) ou por **keyword**.
3. Habilite **After Loading Image, Execute "Auto"** e escolha da lista: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Uma vez iniciado o monitoramento, a sequência é executada automaticamente sempre que uma imagem correspondente chega.

## Procedimentos por script (macros baseadas em Python)

O processamento com loops e condicionais pode ser escrito como uma [macro](5-macro/index.md). As macros de exemplo incluídas são um bom ponto de partida.

- Carregar uma imagem, definir a fonte e o detector (centro, comprimento de câmara, pixels) e ajustar a exibição.
- Definir as condições da integração concêntrica (start, end, step, unit), unidimensionalizar e salvar como CSV.
- Processar em lote vários arquivos, salvando um CSV ao lado de cada imagem.
- Processar uma imagem multiquadro quadro a quadro.
- Dividir um anel de Debye em N setores e analisar a dependência azimutal.
- Mascarar (limpar tudo → mascarar pontos → mascarar a região do beam-stop → salvar a máscara) e unidimensionalizar.
- Gerar azimute vs. intensidade com integração radial (cake).
- Habilitar o envio para a área de transferência, unidimensionalizar e chamar uma macro nomeada no PDIndexer (por exemplo, ajuste de picos).

As macros que você escreve podem ser salvas, chamadas pelo nome e também executadas a partir do Auto Procedure.
