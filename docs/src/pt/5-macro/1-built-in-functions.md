<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

Os métodos e propriedades chamáveis a partir de uma macro, agrupados por namespace sob o objeto raiz `IPA`. As descrições seguem a ajuda integrada do editor de macros (atributos `[Help]`); a ajuda integrada do editor é a referência autoritativa e atualizada.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Retorna o caminho completo de um diretório. Se `filename` for omitido, abre-se uma caixa de diálogo de seleção de pasta. |
| `GetFileName(message="")` | Abre uma caixa de diálogo de arquivo e retorna o caminho completo do arquivo selecionado. |
| `GetFileNames(message="")` | Abre uma caixa de diálogo de seleção múltipla e retorna os caminhos completos como um array de strings. |
| `GetAllFileNames(message="")` | Seleciona uma pasta e retorna os caminhos completos de todos os arquivos nela (recursivo) como um array. |
| `ReadImage(filename="", flag=None)` | Lê um arquivo de imagem. Se omitido, abre-se uma caixa de diálogo de seleção. |
| `ReadImageHDF(filename, flag)` | Lê uma imagem HDF5. `flag` ativa/desativa a normalização. |
| `SaveImage(filename="")` | Salva a imagem atual (alias legado; o padrão é TIFF). |
| `SaveImageAsTIFF(filename="")` | Salva a imagem como TIFF. |
| `SaveImageAsPNG(filename="")` | Salva a imagem como PNG. |
| `SaveImageAsIPA(filename="")` | Salva a imagem no formato IPA. |
| `SaveImageAsCSV(filename="")` | Salva a imagem como CSV. |
| `ReadParameter(filename="")` | Lê um arquivo de parâmetros. |
| `SaveParameter(filename="")` | Salva os parâmetros atuais. |
| `ReadMask(filename="")` | Lê um arquivo de máscara. |
| `SaveMask(filename="")` | Salva a máscara atual. |

Para todos os métodos de leitura/salvamento, omitir ou fornecer um nome de arquivo inválido abre uma caixa de diálogo de seleção.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Define o comprimento de onda do feixe incidente (em nm). |
| `WaveLength` | Define/obtém o comprimento de onda (em nm). |
| `WaveSource` | Define/obtém a fonte como um inteiro. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Define a linha de comprimento de onda de raios X como um inteiro (apenas setter). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
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

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Desenha a imagem com gradiente negativo (contraparte de `PositiveGradient`). |
| `PositiveGradient` | True/False. Desenha a imagem com gradiente positivo (contraparte de `NegativeGradient`). |
| `LinearScale` | True/False. Desenha em escala linear (contraparte de `LogScale`). |
| `LogScale` | True/False. Desenha em escala logarítmica (contraparte de `LinearScale`). |
| `GrayScale` | True/False. Desenha em escala de cinza (contraparte de `ColorScale`). |
| `ColorScale` | True/False. Desenha em escala de cor (contraparte de `GrayScale`). |
| `Maximum` | Define/obtém o nível máximo de brilho (float). |
| `Minimum` | Define/obtém o nível mínimo de brilho (float). |
| `CanvasMagnification` | Define/obtém a ampliação da imagem (float). |
| `SetCanvasCenter(x, y)` | Define a posição do centro do canvas (em pixels). |
| `SetCanvasSize(width, height)` | Define o tamanho do canvas (picture box) (em pixels). |
| `SetArea(top, bottom, left, right)` | Define a área do canvas pelos limites superior/inferior/esquerdo/direito (em pixels). |
| `SetFullArea()` | Define a área do canvas de modo que toda a imagem fique visível. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Mascara os pontos (igual ao botão "Mask Spots"). |
| `ClearMask()` | Limpa as máscaras atuais. |
| `InvertMask()` | Inverte o estado atual da máscara. |
| `MaskAll()` | Mascara toda a área. |
| `MaskTop()` | Mascara a metade superior. |
| `MaskBottom()` | Mascara a metade inferior. |
| `MaskLeft()` | Mascara a metade esquerda. |
| `MaskRight()` | Mascara a metade direita. |
| `TakeOver` | Define/obtém a configuração de herança de máscara (inteiro). 0: None, 1: herda o estado atual da máscara, 2: herda o arquivo de máscara. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra concentricamente (2θ–intensidade). |
| `RadialIntegration` | True/False. Integra radialmente (pizza-cut). |
| `AzimuthalDivision` | True/False. Processa em modo de divisão azimutal. |
| `AzimuthalDivisionNumber` | Inteiro. Define o número de divisões do anel de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Executa Find Center antes de Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Executa Mask Spots antes de Get Profile. |
| `SendProfileViaClipboard` | True/False. Envia o perfil para o PDIndexer pela área de transferência. |
| `SaveProfileAfterGetProfile` | True/False. Salva o perfil após Get Profile. |
| `SaveProfileAsPDI` | True/False. Salva no formato PDI. |
| `SaveProfileAsCSV` | True/False. Salva no formato CSV. |
| `SaveProfileAsTSV` | True/False. Salva no formato TSV. |
| `SaveProfileAsGSAS` | True/False. Salva no formato GSAS. |
| `SaveProfileInOneFile` | True/False. Salva os perfis sequenciais/de divisão azimutal em um único arquivo. |
| `SaveProfileAtImageDirectory` | True/False. Salva no mesmo diretório da imagem. |
| `GetProfile(filename="")` | Executa a unidimensionalização. Se `filename` for fornecido, o perfil é salvo nesse arquivo. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra concentricamente (2θ–intensidade). |
| `RadialIntegration` | True/False. Integra radialmente (pizza-cut / padrão cake). |
| `ConcentricStart` | Float. Valor inicial para a integração concêntrica. |
| `ConcentricEnd` | Float. Valor final para a integração concêntrica. |
| `ConcentricStep` | Float. Valor de passo para a integração concêntrica. |
| `ConcentricUnit` | Inteiro. Unidade para a integração concêntrica. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Raio do donut para a integração radial. |
| `RadialWidgh` | Float. Largura do donut para a integração radial. Nota: o membro está escrito `RadialWidgh` na versão atual. |
| `RadialStep` | Float. Ângulo do setor (passo de varredura) para a integração radial. |
| `RadialUnit` | Inteiro. Unidade para a integração radial. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Obtém se o arquivo atual é uma imagem sequencial. |
| `Count` | Inteiro. Obtém o número de imagens. |
| `SelectedIndex` | Inteiro. Define/obtém o índice selecionado (baseado em 0). |
| `SelectedIndices` | Array de inteiros. Define/obtém os índices selecionados (para o modo de seleção múltipla). |
| `MultiSelection` | True/False. Define/obtém o modo de seleção múltipla. |
| `Averaging` | True/False. Define/obtém o modo de média. |
| `SelectIndex(index)` | Define um único índice selecionado (desativa a seleção múltipla). |
| `AppendIndex(index)` | Acrescenta um índice à seleção atual. |
| `SelectIndices(start, end)` | Define um intervalo contíguo (de start a end, inclusive). |
| `AppendIndices(start, end)` | Acrescenta um intervalo contíguo (de start a end, inclusive) à seleção atual. |
| `Target_SelectedImages` | True/False. Torna as imagens selecionadas o alvo de Get Profile. |
| `Target_AllImages` | True/False. Torna todas as imagens o alvo de Get Profile. |
| `Target_TopmostImage` | True/False. Torna apenas a imagem mais ao topo o alvo de Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Executa a macro no PDIndexer passo a passo. |
| `Timeout` | Define/obtém o tempo limite (segundos) para a operação da macro (padrão 30 s). |
| `RunMacro(obj1, obj2, ...)` | Executa código de macro no PDIndexer. Os parâmetros são lidos no PDI como `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Executa a macro nomeada `name` no PDIndexer. Os parâmetros são lidos no PDI como `Obj[1]`, `Obj[2]`, … |
