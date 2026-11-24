<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Funções integradas

Os métodos e propriedades que podem ser chamados a partir de uma macro, agrupados por namespace sob o objeto raiz `IPA`. As descrições seguem a ajuda do editor de macros (atributos `[Help]`); a ajuda do editor é a referência oficial e atualizada.

## IPA.File

| Membro | Descrição |
|------|------|
| `GetDirectoryPath(filename="")` | Retorna o caminho completo de um diretório. Se `filename` for omitido, abre-se um diálogo de seleção de pasta. |
| `GetFileName(message="")` | Abre um diálogo de arquivo e retorna o caminho completo do arquivo selecionado. |
| `GetFileNames(message="")` | Abre um diálogo de seleção múltipla e retorna os caminhos completos como um array de strings. |
| `GetAllFileNames(message="")` | Seleciona uma pasta e retorna como array os caminhos completos de todos os arquivos nela (recursivamente). |
| `ReadImage(filename="", flag=None)` | Lê um arquivo de imagem. Se omitido, abre-se um diálogo de seleção. |
| `ReadImageHDF(filename, flag)` | Lê uma imagem HDF5. `flag` ativa/desativa a normalização. Na versão atual, a leitura de HDF5 (`.h5`) não funciona; arquivos NeXus (`.nxs`) podem ser lidos com `ReadImage(filename)`. |
| `SaveImage(filename="")` | Salva a imagem atual (alias antigo; o padrão é TIFF). |
| `SaveImageAsTIFF(filename="")` | Salva a imagem como TIFF. |
| `SaveImageAsPNG(filename="")` | Salva a imagem como PNG. |
| `SaveImageAsIPA(filename="")` | Salva a imagem no formato IPA. |
| `SaveImageAsCSV(filename="")` | Salva a imagem como CSV. |
| `ReadParameter(filename="")` | Lê um arquivo de parâmetros. |
| `SaveParameter(filename="")` | Salva os parâmetros atuais. |
| `ReadMask(filename="")` | Lê um arquivo de máscara. |
| `SaveMask(filename="")` | Salva a máscara atual. |

Em todos os métodos de leitura/gravação, omitir o nome do arquivo ou fornecer um nome inválido abre um diálogo de seleção.

## IPA.Wave

| Membro | Descrição |
|------|------|
| `SetWaveLength(wavelength)` | Define o comprimento de onda do feixe incidente (em nm). |
| `WaveLength` | Define/obtém o comprimento de onda (em nm). |
| `WaveSource` | Define/obtém a fonte como um inteiro. 0: nenhuma, 1: raios X, 2: elétrons, 3: nêutrons. |
| `XrayLine` | Define a linha de comprimento de onda dos raios X como um inteiro (somente escrita). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Membro | Descrição |
|------|------|
| `SetCenter(x, y)` | Define a posição do centro (ponto direto) (em pixels). |
| `SetCameraLength(length)` | Define o comprimento de câmara (em mm). |
| `CenterX` | Define/obtém o valor X da posição do centro (em pixels). |
| `CenterY` | Define/obtém o valor Y da posição do centro (em pixels). |
| `CameraLength` | Define/obtém o comprimento de câmara (em mm). |
| `PixelSizeX` | Define/obtém o tamanho X do pixel (largura do pixel) (em mm). |
| `PixelSizeY` | Define/obtém o tamanho Y do pixel (altura do pixel) (em mm). |
| `PixelKsi` | Define/obtém a inclinação ξ do pixel (em graus). |
| `TiltPhi` | Define/obtém a inclinação φ (em graus). |
| `TiltTau` | Define/obtém a inclinação τ (em graus). |

## IPA.Image

| Membro | Descrição |
|------|------|
| `NegativeGradient` | True/False. Desenha a imagem com gradiente negativo (contraparte de `PositiveGradient`). |
| `PositiveGradient` | True/False. Desenha a imagem com gradiente positivo (contraparte de `NegativeGradient`). |
| `LinearScale` | True/False. Desenha com escala linear (contraparte de `LogScale`). |
| `LogScale` | True/False. Desenha com escala logarítmica (contraparte de `LinearScale`). |
| `GrayScale` | True/False. Desenha em tons de cinza (contraparte de `ColorScale`). |
| `ColorScale` | True/False. Desenha em escala de cores (contraparte de `GrayScale`). |
| `Maximum` | Define/obtém o nível máximo de brilho (float). |
| `Minimum` | Define/obtém o nível mínimo de brilho (float). |
| `CanvasMagnification` | Define/obtém a ampliação da imagem (float). |
| `SetCanvasCenter(x, y)` | Define a posição do centro da tela de desenho (em pixels). |
| `SetCanvasSize(width, height)` | Define o tamanho da tela de desenho (picture box) (em pixels). |
| `SetArea(top, bottom, left, right)` | Define a área da tela de desenho pelos limites superior/inferior/esquerdo/direito (em pixels). |
| `SetFullArea()` | Define a área da tela de desenho de modo que a imagem inteira fique visível. |

## IPA.Mask

| Membro | Descrição |
|------|------|
| `MaskSpots()` | Mascara os pontos (o mesmo que o botão **Mascarar pontos (Mask Spots)**). |
| `ClearMask()` | Apaga as máscaras atuais. |
| `InvertMask()` | Inverte o estado atual da máscara. |
| `MaskAll()` | Mascara a área inteira. |
| `MaskTop()` | Mascara a metade superior. |
| `MaskBottom()` | Mascara a metade inferior. |
| `MaskLeft()` | Mascara a metade esquerda. |
| `MaskRight()` | Mascara a metade direita. |
| `TakeOver` | Define/obtém a configuração de herança da máscara (inteiro). 0: nenhuma, 1: herdar o estado atual da máscara, 2: herdar o arquivo de máscara. |

## IPA.Profile

| Membro | Descrição |
|------|------|
| `ConcentricIntegration` | True/False. Integra de forma concêntrica (2θ–intensidade). |
| `RadialIntegration` | True/False. Integra radialmente (em fatias de pizza). |
| `AzimuthalDivision` | True/False. Processa no modo de divisão azimutal. |
| `AzimuthalDivisionNumber` | Inteiro. Define o número de divisões do anel de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Executa Localizar centro (Find Center) antes de Obter perfil (Get Profile). |
| `MaskSpotsBeforeGetProfile` | True/False. Executa Mascarar pontos (Mask Spots) antes de Obter perfil (Get Profile). |
| `SendProfileViaClipboard` | True/False. Envia o perfil ao PDIndexer pela área de transferência. |
| `SaveProfileAfterGetProfile` | True/False. Salva o perfil após Obter perfil (Get Profile). |
| `SaveProfileAsPDI` | True/False. Salva no formato PDI. |
| `SaveProfileAsCSV` | True/False. Salva no formato CSV. |
| `SaveProfileAsTSV` | True/False. Salva no formato TSV. |
| `SaveProfileAsGSAS` | True/False. Salva no formato GSAS. Só é possível para a integração concêntrica com eixo em 2θ; não é gravado quando vários perfis são salvos em um único arquivo. |
| `SaveProfileInOneFile` | True/False. Salva os perfis sequenciais/de divisão azimutal em um único arquivo. |
| `SaveProfileAtImageDirectory` | True/False. Salva no mesmo diretório da imagem. |
| `GetProfile(filename="")` | Integra a imagem em um perfil 1D (o mesmo que **Obter perfil (Get Profile)**). Se `filename` for fornecido, ele é usado como nome base e a extensão do formato é acrescentada (por exemplo, `GetProfile("sample.stl")` salvo como CSV gera `sample.stl.csv`). Se o destino estiver definido como "escolher a cada vez", o diálogo de salvamento é exibido. |

## IPA.IntegralProperty

| Membro | Descrição |
|------|------|
| `ConcentricIntegration` | True/False. Integra de forma concêntrica (2θ–intensidade). |
| `RadialIntegration` | True/False. Integra radialmente (fatias de pizza / padrão cake). |
| `ConcentricStart` | Float. Valor inicial da integração concêntrica. |
| `ConcentricEnd` | Float. Valor final da integração concêntrica. |
| `ConcentricStep` | Float. Valor do passo da integração concêntrica. |
| `ConcentricUnit` | Inteiro. Unidade da integração concêntrica. 0: ângulo (graus), 1: distância d (Å), 2: comprimento (mm). |
| `RadialRadius` | Float. Raio do anel (donut radius) da integração radial. |
| `RadialWidgh` | Float. Largura do anel (donut width) da integração radial. Nota: na versão atual, o membro é escrito `RadialWidgh`. |
| `RadialStep` | Float. Ângulo do setor (passo de varredura) da integração radial. |
| `RadialUnit` | Inteiro. Unidade da integração radial. 0: ângulo (graus), 1: distância d (Å). |

## IPA.Sequential

| Membro | Descrição |
|------|------|
| `SequentialImageMode` | True/False. Obtém se o arquivo atual é uma imagem sequencial. |
| `Count` | Inteiro. Obtém o número de imagens. |
| `SelectedIndex` | Inteiro. Define/obtém o índice selecionado (a partir de 0). |
| `SelectedIndices` | Array de inteiros. Define/obtém os índices selecionados (para o modo de seleção múltipla). |
| `MultiSelection` | True/False. Define/obtém o modo de seleção múltipla. |
| `Averaging` | True/False. Define/obtém o modo de média. |
| `SelectIndex(index)` | Define um único índice selecionado (desativa a seleção múltipla). |
| `AppendIndex(index)` | Acrescenta um índice à seleção atual. |
| `SelectIndices(start, end)` | Define um intervalo contíguo (de start a end, inclusive). |
| `AppendIndices(start, end)` | Acrescenta um intervalo contíguo (de start a end, inclusive) à seleção atual. |
| `Target_SelectedImages` | True/False. Torna as imagens selecionadas o alvo de Obter perfil (Get Profile). |
| `Target_AllImages` | True/False. Torna todas as imagens o alvo de Obter perfil (Get Profile). |
| `Target_TopmostImage` | True/False. Torna somente a imagem superior o alvo de Obter perfil (Get Profile). |

## IPA.PDI

| Membro | Descrição |
|------|------|
| `Debug` | True/False. Executa a macro no PDIndexer passo a passo. |
| `Timeout` | Define/obtém o tempo limite (segundos) da operação de macro (padrão de 30 s). |
| `RunMacro(obj1, obj2, ...)` | Executa o código aberto no momento no editor de macros do PDIndexer. Os parâmetros são lidos no PDIndexer como `PDI.Obj[0]`, `PDI.Obj[1]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Executa a macro salva com o nome `name` no PDIndexer. Os parâmetros são lidos no PDIndexer como `PDI.Obj[0]`, `PDI.Obj[1]`, … |
