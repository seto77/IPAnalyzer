<!-- 261124Cl: Retranslated from en/7-qa.md (UI labels follow the localized GUI). -->

# Q&A (Perguntas frequentes)

Esta página reúne as perguntas feitas com mais frequência e os pontos que costumam ser mal compreendidos. Os rótulos são os nomes exibidos na interface em português, com o nome em inglês entre parênteses. Para perguntas não abordadas aqui, ou para relatar um erro, use o [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Instalação e inicialização

### Só a janela de propriedades aparece; a janela principal não pode ser vista

A janela principal está posicionada fora da tela.

1. Passe o mouse sobre o ícone do IPAnalyzer na barra de tarefas, clique com o botão direito na miniatura, escolha **Move**, pressione uma tecla de seta uma vez e depois mova o mouse.
2. Se isso não resolver, feche o IPAnalyzer, abra o Editor do Registro (regedit), apague `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer` e inicie o IPAnalyzer novamente (todas as configurações voltam aos valores padrão).

### Depois de atualizar, a versão antiga continua em execução / o IPAnalyzer não inicia mais

Reinstale diretamente a partir da [versão mais recente](https://github.com/seto77/IPAnalyzer/releases/latest). Se a instalação não sobrescrever a versão antiga, ou se o programa não iniciar, desinstale-o uma vez pelas Configurações do Windows e instale-o novamente. Se uma versão nova tiver algum problema, é possível instalar uma versão mais antiga pela mesma página de releases.

### Quero usá-lo em um PC sem direitos de administrador, ou no Windows on Arm

- Sem direitos de administrador, use a versão portátil (`IPAnalyzer-v.<version>.zip`), que não precisa de instalação e inclui o runtime do .NET.
- No Windows on Arm, use o instalador arm64 (`IPAnalyzer-setup_arm64.msi`) ou a versão portátil (`IPAnalyzer-v.<version>_arm64.zip`).

Veja [Instalação na Visão geral](0-overview.md#instalação) para mais detalhes.

### Carregar muitos quadros causa um erro. Quanta memória é necessária?

O IPAnalyzer guarda a intensidade de cada pixel em precisão dupla (8 bytes), qualquer que seja a profundidade de bits original. Por exemplo, 5000 imagens de 1554×516 pixels precisam de cerca de 32 GB só para as intensidades. Trate dados com muitos quadros em um PC com memória suficiente, ou processe-os em partes com uma macro.

## Leitura de imagens

### Os arquivos do meu detector não podem ser lidos

O formato pode ainda não ser suportado. Entre em contato pelo [Issues](https://github.com/seto77/IPAnalyzer/issues) ou com o autor, enviando um arquivo real (de preferência um com padrão de difração, e não apenas uma imagem escura). A exatidão das intensidades e a orientação da imagem só podem ser verificadas com uma imagem que mostre um padrão.

!!! note "Quando uma imagem bruta tem a largura e a altura erradas"
    Para arquivos brutos sem cabeçalho, o modelo do detector e o número de pixels são inferidos a partir do tamanho do arquivo. O número real de pixels muitas vezes difere do valor de catálogo; por isso, envie o arquivo se a detecção falhar.

### Depois de carregar um arquivo de parâmetros e abrir uma imagem, os parâmetros mudam

O IPAnalyzer **memoriza parâmetros como o comprimento de câmara, o comprimento de onda e o tamanho do pixel para cada formato de imagem** e passa a usar esses valores quando uma imagem é aberta. Portanto, carregue o arquivo de parâmetros (`.prm`) **depois de abrir a imagem**. Formatos com extensões diferentes são memorizados separadamente, mesmo que seu conteúdo seja o mesmo.

### Preciso inverter ou girar cada imagem de novo?

Não. As configurações de **Opção → Inverter / Girar (Option → Flip / Rotate)** também são memorizadas por formato de imagem e aplicadas automaticamente na próxima vez que uma imagem do mesmo formato for aberta. A inversão e a rotação também afetam a integração e o salvamento da imagem (o arquivo de origem não é alterado).

### Como são tratados os arquivos com vários quadros (`.his`, `.nxs`, TIFF de várias páginas, …)?

Quando um arquivo desse tipo é carregado, abre-se a janela **Imagem sequencial (Sequential image)**, na qual é possível selecionar o quadro a exibir. Para integrá-los em conjunto, use **Obter perfis para todas as imagens sequenciais (Get Profiles for all sequential images)** ou **Obter perfis para imagens selecionadas (Get Profiles for selected images)** no menu suspenso de **Obter perfil (Get Profile)**. Veja [Ferramentas](3-tools.md#imagem-sequencial-sequential-image) para mais detalhes.

## Calibração

### Quando devo usar Localizar parâmetro (geometricamente) e quando Localizar parâmetro (força bruta)?

| | Geometricamente (Geometrically) | Força bruta (Brute force) |
|---|---|---|
| Princípio | Divide a imagem em setores, encontra as posições dos picos e determina o centro, a inclinação etc. a partir das formas elípticas e dos centros dos anéis de Debye | Varia os parâmetros passo a passo e procura a combinação que melhor faz coincidir as posições de pico calculadas e ajustadas |
| Dados adequados | Anéis visíveis quase na volta inteira (em pelo menos cinco direções) | Apenas parte dos anéis registrada, ponto direto fora da imagem, anéis pontilhados |
| Imagens | Uma, ou duas tomadas em comprimentos de câmara diferentes | Uma |
| Cuidado | A exatidão cai ou o refinamento não converge se os anéis não forem visíveis na volta inteira | Precisa de valores iniciais razoavelmente bons; leva tempo |

Veja [Procedimentos](4-procedures.md) e [Encontrar parâmetros (força bruta)](6-find-parameter.md) para as etapas.

### Que amostra de referência devo usar na calibração?

É adequada uma amostra de grãos finos que produza anéis de Debye contínuos (não pontilhados), visíveis da forma mais completa possível. Cerca de cinco anéis ou mais é uma boa referência. Com apenas dois anéis completos, uma determinação precisa é difícil, e o comprimento de onda ou o comprimento de câmara deve ser conhecido. Para a calibração por força bruta, escolha o padrão entre Au / CeO₂ / LaB₆ / Al₂O₃, ou selecione **Outro (Other)** e informe as constantes de rede.

### A calibração não converge / o centro continua se deslocando

- Fixe os valores em que você pode confiar (tamanho do pixel de catálogo, comprimento de onda conhecido etc.) e reduza o número de variáveis refinadas.
- Primeiro ajuste de modo aproximado com alguns anéis de baixo ângulo e depois acrescente os anéis de alto ângulo.
- Um anel cuja análise falhou pode perturbar todo o resultado. Se um anel se destacar dos demais no gráfico dos centros dos anéis, remova-o.
- Se o ajuste falhar quando os anéis de alto ângulo são incluídos, restrinja os picos àqueles cujos anéis ainda são visíveis na volta inteira, amplie o intervalo de ajuste e use menos setores.
- Antes de começar, digite valores iniciais tão corretos quanto possível.

### O comprimento de câmara e o comprimento de onda só podem ser determinados se um deles for fixado?

Com um padrão cujas constantes de rede são conhecidas com exatidão, ambos podem ser determinados até com uma única imagem (a partir das razões entre as posições dos anéis). No entanto, **o comprimento de câmara e o tamanho do pixel não podem ser determinados juntos a partir de uma única imagem**. Confie no tamanho do pixel de catálogo e fixe-o. Com duas imagens cuja diferença de comprimento de câmara é conhecida (método do cassete duplo), o tamanho do pixel também pode ser refinado.

### O ponto direto não foi registrado / está fora da imagem

Digite manualmente a posição do ponto direto e desmarque **Localizar centro antes de Obter perfil (Find Center before Get Profile)** no menu suspenso de **Obter perfil (Get Profile)**. Se o ponto estiver fora da imagem, coordenadas negativas não são problema. Use a calibração por força bruta para esse tipo de dado.

### O centro obtido por Localizar centro difere alguns pixels do centro calibrado

Eles são determinados de maneiras diferentes. **Localizar centro (Find Center)** ajusta o ponto direto próximo ao centro atual com uma função pseudo-Voigt bidimensional. A calibração não usa a intensidade do ponto direto; ela obtém o centro a partir dos centros das elipses de vários anéis de Debye. Uma vez determinada corretamente a inclinação, o centro calibrado pode ser usado tal como está. Se o ponto direto estiver saturado, exiba um círculo sobre um anel de Debye com **Desenhar anel (Draw ring)** e pressione **Localizar centro**: o centro passa então a ser determinado a partir do anel.

### O que é a correção esférica?

Uma correção para um detector curvado como uma esfera. Digite o inverso do raio de curvatura, 1/R (mm⁻¹). Use 0 para um detector plano. Ajuda quando os anéis de alto ângulo não coincidem, por exemplo com um detector grande colocado perto da amostra.

### Como converto valores de inclinação de outros softwares (como o PIP)?

O (β, Φ) do PIP converte-se no (φ, τ) do IPAnalyzer como (φ, τ) = (270° − β, Φ). Veja a [Visão geral](0-overview.md#relação-com-o-winpip) para as definições.

## Integração e saída

### O eixo horizontal do resultado parece errado / a intensidade parece quase constante

Verifique se **Integração radial (Radial integration)** está selecionada na aba **Propriedade de integração (Integral Property)** da janela de propriedades. Nesse modo, o perfil tem o azimute χ como eixo horizontal. O perfil usual 2θ–intensidade é obtido com **Integração concêntrica (Concentric integration)**.

### Quero salvar o perfil em um arquivo sem o PDIndexer

Na aba **Após "Obter perfil" (After "Get Profile")** da janela de propriedades, defina em **Save File** o destino (mesma pasta da imagem / escolher a cada vez) e o formato (PDI / CSV / TSV / GSAS). O perfil passa então a ser salvo toda vez que você integra.

### O que é a terceira coluna do CSV?

O erro de contagem da intensidade, calculado a partir da raiz quadrada da intensidade somada dos pixels em cada passo, tratada como contagens. A intensidade da segunda coluna é convertida para o equivalente da geometria de Bragg–Brentano, de modo que não é igual ao quadrado da terceira coluna. O PDIndexer pode exibi-la como barras de erro.

### Os valores de 2θ no CSV têm só duas casas decimais. Esse é o limite de precisão?

Não. Isso só parece assim porque a integração foi configurada, por exemplo, com início em 20,00° e passo de 0,01°. O cálculo é feito em precisão dupla. A precisão do resultado é determinada pelos erros dos parâmetros de entrada, como o comprimento de câmara e o comprimento de onda.

### Para imagens sequenciais, devo usar Média ou Soma?

A relação S/N é a mesma nos dois casos. **Soma (Summation)** dá uma estimativa correta dos erros e, por isso, é recomendada para análises que usam os erros, como o refinamento de Rietveld.

### Quero integrar para cada azimute (cada setor)

Ative **Análise de divisão azimutal (Azimuthal Division Analysis)** no menu suspenso de **Obter perfil (Get Profile)**, defina o **Número de divisões (Number of divisions)** e integre. São criados um perfil completo (nome terminado em `-whole`) e um perfil por setor (com o ângulo inicial acrescentado, como `-000`, `-010`, …). Com divisões demais, os dados enviados ao PDIndexer podem ficar grandes demais.

### Quero um mapa bidimensional de 2θ e do azimute χ (imagem desenrolada)

Use **Desenrolar imagem (Unroll image)** na barra de ferramentas. Defina o intervalo e o passo na aba **Opção de imagem desenrolada (Unrolled Image Option)** da janela de propriedades. Com **Arquivo → Salvar imagem (File → Save image)**, o TIFF guarda os valores de ponto flutuante calculados, e o PNG salva o que é mostrado na tela.

### Quero a soma ou a média da intensidade de uma parte retangular da imagem

Selecione um retângulo com Ctrl + arrastar com o botão direito sobre a imagem. As estatísticas aparecem na aba **Informação estatística (Statistical Information)** na parte inferior. Para imagens sequenciais, a mesma região pode ser comparada entre os quadros.

### Uma imagem escura fica mais clara em direção às bordas de alto ângulo

Se **Corrigir polarização linear (Correct linear polarization)** estiver ativado em **Fonte de ondas (Wave source)** na janela de propriedades, a correção também é aplicada a sinais que não vêm dos raios X (corrente escura, ruído eletrônico), e o lado de alto ângulo fica mais claro. Desative-a para imagens escuras.

### Quero subtrair uma imagem escura (de fundo)

Na aba **Opção de fundo (Background Option)** da janela de propriedades, registre a imagem atual como fundo e defina o coeficiente. A partir daí, ela é subtraída automaticamente das imagens do mesmo tamanho. Veja [Janelas de propriedades](2-property-windows.md) para mais detalhes.

## Processamento em lote e macros

### Quero integrar muitos arquivos de uma vez

**Obter perfis para todas as imagens sequenciais (Get Profiles for all sequential images)** é para vários quadros contidos em um único arquivo. Para processar vários arquivos, use uma [macro](5-macro/index.md). Os [exemplos](5-macro/2-examples.md) incluem um que integra em sequência os arquivos selecionados e salva arquivos CSV. Antes de executá-lo, abra uma imagem e carregue o arquivo de parâmetros (veja [a memorização dos parâmetros](#depois-de-carregar-um-arquivo-de-parâmetros-e-abrir-uma-imagem-os-parâmetros-mudam)).

### Quero chamar pelo menu uma macro usada com frequência

Dê um nome à macro e adicione-a no editor de macros; ela poderá então ser chamada pelo menu **Macro** da janela principal.

### Quero integrar as imagens à medida que chegam durante uma medição

Monitore a pasta com o [Procedimento automático (Auto procedure)](3-tools.md#procedimento-automático-auto-procedure). Os arquivos que ainda estão sendo gravados são lidos depois que a gravação termina. Se a leitura falhar para uma pasta na rede, salve no disco local do PC de medição e monitore essa pasta.

## Relatar um erro

### O que devo enviar com um relatório de erro?

Muitas vezes o problema não pode ser reproduzido no ambiente do autor; por isso, anexe:

- o arquivo de parâmetros daquele momento (**Arquivo → Salvar parâmetro (File → Save parameter)**),
- o arquivo de imagem com o qual o problema ocorreu, e
- a mensagem de erro (uma captura de tela serve) e a versão do IPAnalyzer.

Relate pelo [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Equívocos comuns

| Suposição | Na verdade |
|---|---|
| Carregar primeiro o arquivo de parâmetros e depois abrir a imagem | Abrir uma imagem passa a usar os valores memorizados para o seu formato. Abra primeiro a imagem e depois carregue o arquivo de parâmetros |
| **Obter perfis para todas as imagens sequenciais (Get Profiles for all sequential images)** processa vários arquivos de uma vez | É para vários quadros em um único arquivo. Use uma macro para vários arquivos |
| O PDIndexer é necessário para salvar um perfil | O IPAnalyzer sozinho pode salvar em um arquivo (aba **Após "Obter perfil" (After "Get Profile")**) |
| A terceira coluna do CSV é outro perfil | É o erro de contagem da intensidade |
| **Soma (Summation)** melhora a S/N | A S/N é a mesma de **Média (Average)**; só a estimativa do erro é diferente |
| O comprimento de câmara e o tamanho do pixel podem ambos ser determinados a partir de uma imagem | Não juntos a partir de uma imagem; fixe o tamanho do pixel no valor de catálogo |
| A inversão e a rotação só mudam a exibição | Elas também afetam a integração e o salvamento da imagem |
| O envio ao PDIndexer aplica ao perfil uma correção de Lorentz-polarização | O PDIndexer considera a polarização apenas para as intensidades das linhas de difração calculadas; o próprio perfil não é modificado |
