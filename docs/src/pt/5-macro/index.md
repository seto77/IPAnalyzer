<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Macro

O IPAnalyzer oferece uma funcionalidade de **macro** que automatiza sequências de operações com scripts no estilo Python. Ela é útil para trabalhos repetitivos, como a integração em lote de muitos arquivos em perfis 1D, a conversão de formatos e a análise de divisão azimutal.

## Abrir o editor

Abra o editor de macros pelo menu **Macro** → **Editor** da janela principal. Nele é possível editar o código e executá-lo, inclusive passo a passo.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Linguagem

- Estão disponíveis instruções de controle como `for` / `if` / `while` / `def` / `class`, além da aritmética.
- O módulo `math` já vem importado, de modo que é possível usar `math.pi` ou `math.sin(...)` diretamente, sem uma instrução `import`.
- `print()` não está disponível. Para inspecionar valores, use a **execução passo a passo** (Step by step) e acompanhe a mudança das variáveis no painel de depuração.
- Cada operação do IPAnalyzer é chamada a partir de um namespace sob o objeto raiz `IPA` (por exemplo, `IPA.File`).

## Namespaces do IPA

| Namespace | Função |
|------|------|
| `IPA.File` | Ler/gravar arquivos de imagem, de parâmetros e de máscara; diálogos de seleção de arquivos |
| `IPA.Wave` | Definir a fonte incidente e o comprimento de onda |
| `IPA.Detector` | Definir a geometria do detector: centro, comprimento de câmara, tamanho do pixel, inclinação |
| `IPA.Image` | Controlar a escala de exibição, o contraste e a área visível |
| `IPA.Mask` | Mascarar pontos e regiões |
| `IPA.Profile` | Integrar a imagem (Obter perfil / Get Profile) e configurar o salvamento/envio |
| `IPA.IntegralProperty` | Definir o intervalo, o passo e a unidade da integração concêntrica / radial |
| `IPA.Sequential` | Selecionar / calcular a média / definir o alvo dos quadros de uma imagem multiquadro |
| `IPA.PDI` | Chamar macros no PDIndexer (integração pela área de transferência) |

Veja [Funções integradas](1-built-in-functions.md) para a lista de membros e [Exemplos](2-examples.md) para scripts concretos.

!!! tip "A ajuda do editor é a referência oficial"
    A descrição de cada função/propriedade é mostrada na ajuda do editor de macros e é a referência atualizada, que acompanha cada versão. Se esta página divergir da ajuda do editor, confie nesta última.

## Macros de exemplo

Ative **Mostrar exemplos (Show samples)** no editor para listar as macros de exemplo somente leitura (laços básicos, funções matemáticas, configuração da geometria, processamento em lote, divisão azimutal, mascaramento, envio ao PDIndexer etc.); desative-o para voltar às suas próprias macros salvas. Elas são um ponto de partida fácil de adaptar.

## Uso com o Procedimento automático (Auto Procedure)

As macros que você escreve podem ser salvas com um nome e também executadas a partir do [Procedimento automático (Auto Procedure)](../3-tools.md) (escolha-a em **Macro** e marque **Execute macro**), de modo que uma macro seja aplicada automaticamente a cada imagem que chega durante um experimento.
