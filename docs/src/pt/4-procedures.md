<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). -->

# Procedimentos

Esta página mostra o fluxo das tarefas típicas. Para as descrições de cada ferramenta, veja [Ferramentas](3-tools.md).

## Fluxo básico (integração concêntrica)

1. **Carregar uma imagem**: **Arquivo (File) → Ler imagem (Read image)** (ou arrastar e soltar).
2. **Definir a fonte**: defina o elemento/transição ou o comprimento de onda em **Fonte de ondas (Wave source)** nas propriedades.
3. **Definir a condição do detector**: defina o comprimento de câmara, o tamanho do pixel, a posição do centro (aproximada) e, se necessário, a inclinação φ, τ em **Condição do detector (Detector condition)**.
4. **Localizar o centro**: detecte automaticamente o centro do feixe com **Localizar centro (Find Center)** na barra de ferramentas (o intervalo de busca é definido na aba **Diversos (Miscellaneous)**).
5. **Mascarar pontos**: remova reflexões de monocristal e similares com **Mascarar pontos (Mask Spots)**. Se necessário, mascare manualmente com **Modo manual (Manual Mode)**.
6. **Verificar as configurações de integração**: selecione a região-alvo em **Região de integração (Integral Region)** e escolha **Integração concêntrica (Concentric integration)** com a unidade do eixo e **Início / Fim / Passo (Start / End / Step)** em **Propriedade de integração (Integral Property)**.
7. **Integrar a imagem**: obtenha o perfil com **Obter perfil (Get Profile)**. O salvamento e o envio são configurados na aba **Após "Obter perfil" (After "Get Profile")** (salvar em CSV, enviar ao PDIndexer etc.).

Para imagens sequenciais, selecione um quadro em [Imagem sequencial](3-tools.md) antes das etapas 5–7. Para a análise por azimute, use **Análise de divisão azimutal (Azimuthal Division Analysis)** no menu suspenso de **Obter perfil** (os anéis são divididos em setores e cada setor é integrado), ou **Integração radial (Radial integration)** em **Propriedade de integração** (um perfil azimute–intensidade).

Se o comprimento de câmara, o comprimento de onda ou a inclinação forem desconhecidos, calibre-os primeiro a partir de uma imagem de uma amostra de referência, como descrito na próxima seção, aplique os valores e só então integre as imagens da amostra.

## Determinação de parâmetros: calibração geométrica com uma amostra de referência (cassete duplo)

Quando o comprimento de câmara ou o comprimento de onda é desconhecido, otimize os parâmetros geométricos a partir dos anéis de difração de um material de referência (CeO2 por padrão etc.), usando [Encontrar parâmetros (geométrico)](3-tools.md).

1. Carregue a **Imagem primária (Primary image)** (amostra de referência, em um comprimento de câmara) com **Abrir (Open)**, localize o centro e exiba os picos com **Obter perfil (Get Profile)**.
2. Arrastar um marcador de linha de difração na Profile View atualiza automaticamente a estimativa do comprimento de câmara.
3. Carregue da mesma forma a **Imagem secundária (Secondary image)** (a mesma amostra de referência, em outro comprimento de câmara) e digite a **diferença de comprimento de câmara** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) (por exemplo, +20 se a primária está a 100 mm e a secundária a 120 mm). A imagem secundária é opcional; a calibração também funciona só com a imagem primária.
4. Na **Lista de picos (Peak List)**, selecione os valores d dos picos que aparecem em ambas as imagens (normalmente três ou mais por imagem; com duas imagens, pelo menos um deve ser comum às duas. A menos que só o comprimento de câmara seja refinado, **Refinar! (Refine!)** não faz nada com menos de três).
5. Escolha os parâmetros a otimizar (comprimento de onda, distância do filme, inclinação, tamanho do pixel, distorção do pixel, posição do centro, correção esférica).
6. Execute **Refinar!**. Ele para automaticamente após o número de repetições definido (12 por padrão). Depois de verificar o resultado, copie-o para o formulário principal com **Parâmetros refinados => formulário principal (Refined parameters => Main form)**.

!!! note "Nota"
    Usar duas imagens (um "cassete duplo") facilita determinar separadamente o comprimento de câmara e o comprimento de onda.

## Determinação de parâmetros: otimização por força bruta (amostra de referência)

Quando a otimização geométrica tem dificuldade em convergir, faça uma busca exaustiva do comprimento de câmara, da posição do centro, da inclinação e, opcionalmente, do comprimento de onda com [Encontrar parâmetros (força bruta)](3-tools.md). Veja [Encontrar parâmetros (força bruta)](6-find-parameter.md) para um passo a passo detalhado com capturas de tela.

1. Carregue uma imagem de uma amostra de referência no formulário principal, abra **Localizar parâmetro (força bruta) (Find parameter (brute force))** e selecione o padrão correspondente.
2. Alinhe aproximadamente a posição do centro no formulário principal (**Localizar centro (Find Center)** ajuda).
3. Escolha os itens a otimizar e digite a largura do passo **Passo inicial (Initial step)** (centrada no valor atual) e o número de passos de cada lado (**Intervalo de busca (Search range)**). Para um detector plano, o tamanho do pixel não é alvo da busca. Veja [Encontrar parâmetros (força bruta)](6-find-parameter.md) para exemplos numéricos.
4. Definir a **Região de integração (Integral Region)** no modo fenda (**Retângulo (Rectangle)**) com uma largura de banda estreita ajuda a suprimir o ruído.
5. Inicie a busca com **Otimizar (Optimize)**. Em cada ciclo, a combinação com o menor valor de avaliação R é adotada e gravada automaticamente nos parâmetros do formulário principal.

## Processamento automático (Auto Procedure)

Processe automaticamente as imagens que chegam a uma pasta, por exemplo durante um experimento. Veja [Ferramentas](3-tools.md) para mais detalhes.

1. Escolha a pasta a monitorar com **Definir (Set)**.
2. Se necessário, filtre os arquivos por **correspondência de números** (o número no final do nome do arquivo) ou por **palavra-chave (keyword)**.
3. Ative **After Loading Image, Execute "Auto"** e escolha na lista: **Contraste automático (Auto Contrast)** / **Localizar centro (Find Center)** / **Mascarar pontos (Mask Spots)** / **Obter perfil (Get Profile)** / Execute Macro.
4. Por fim, ative **Carregar novas imagens automaticamente (Automatically load new images)** para iniciar o monitoramento (não é possível ativá-lo sem uma pasta; são usadas as condições de número/palavra-chave vigentes no início do monitoramento). A sequência é então executada automaticamente cada vez que chega uma imagem correspondente.

## Procedimentos por script (macros baseadas em Python)

Processamentos com laços e condicionais podem ser escritos como uma [macro](5-macro/index.md). As macros de exemplo exibidas com **Mostrar exemplos (Show samples)** no editor de macros são um bom ponto de partida.

- Carregar uma imagem, definir a fonte e o detector (centro, comprimento de câmara, pixels) e ajustar a exibição.
- Definir as condições de integração concêntrica (início, fim, passo, unidade), converter para uma dimensão e salvar em CSV.
- Processar vários arquivos em lote, salvando um CSV ao lado de cada imagem.
- Processar uma imagem multiquadro quadro a quadro.
- Dividir um anel de Debye em N setores e analisar a dependência azimutal.
- Mascarar (limpar tudo → mascarar pontos → mascarar a região do beam stop → salvar a máscara) e converter para uma dimensão.
- Gerar azimute vs. intensidade com a integração radial (cake).
- Ativar o envio pela área de transferência, converter para uma dimensão e chamar uma macro nomeada no PDIndexer (por exemplo, ajuste de picos).

As macros que você escreve podem ser salvas, chamadas pelo nome e também executadas a partir do **Procedimento automático (Auto Procedure)**.
