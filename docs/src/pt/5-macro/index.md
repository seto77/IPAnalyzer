<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

O IPAnalyzer oferece um recurso de **macro** que automatiza sequências de operações com scripts no estilo Python. É útil para trabalhos repetitivos, como a unidimensionalização em lote de muitos arquivos, conversão de formatos e análise por divisão azimutal.

## Abrindo o editor

Abra o editor de macros pelo menu **Macro** → **Editor** na janela principal. Lá você pode editar o código e executá-lo, inclusive com execução passo a passo.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Linguagem

- Estão disponíveis instruções de controle como `for` / `if` / `while` / `def` / `class`, além de operações aritméticas.
- O módulo `math` já vem pré-importado, então você pode usar `math.pi` ou `math.sin(...)` diretamente, sem uma instrução `import`.
- `print()` não está disponível. Para inspecionar valores, use a **execução passo a passo** (Step by step) e observe a mudança das variáveis no painel de depuração.
- Cada operação do IPAnalyzer é chamada a partir de um namespace sob o objeto raiz `IPA` (por exemplo, `IPA.File`).

## Namespaces do IPA

| Namespace | Função |
|------|------|
| `IPA.File` | Ler/gravar arquivos de imagem, parâmetros e máscara; diálogos de seleção de arquivos |
| `IPA.Wave` | Definir a fonte incidente e o comprimento de onda |
| `IPA.Detector` | Definir a geometria do detector: centro, comprimento de câmara, tamanho do pixel, inclinação |
| `IPA.Image` | Controlar a escala de exibição, o contraste e a área de visualização |
| `IPA.Mask` | Mascarar pontos (spots) e regiões |
| `IPA.Profile` | Executar a unidimensionalização (Get Profile) e configurar o salvamento/envio |
| `IPA.IntegralProperty` | Definir o intervalo, o passo e a unidade da integração concêntrica / radial |
| `IPA.Sequential` | Selecionar / fazer a média / definir os quadros-alvo de uma imagem multiquadro |
| `IPA.PDI` | Chamar macros no PDIndexer (integração com a área de transferência) |

Consulte [Built-in functions](1-built-in-functions.md) para a lista de membros e [Examples](2-examples.md) para scripts concretos.

!!! tip "A ajuda no editor é a referência autoritativa"
    A descrição de cada função/propriedade é exibida na ajuda do editor de macros e é a fonte da verdade atualizada e versionada. Se esta página divergir da ajuda no editor, confie nesta última.

## Macros de exemplo

Quando a lista de macros salvas do editor está vazia, macros de exemplo (laços básicos, funções matemáticas, configuração de geometria, processamento em lote, divisão azimutal, mascaramento, envio para o PDIndexer, etc.) são inseridas automaticamente. Elas são um ponto de partida fácil de adaptar.

## Trabalhando com o Auto Procedure

As macros que você escrever podem ser salvas por nome e também chamadas a partir da lista "execute after loading" do [Auto Procedure](../3-tools.md), de modo que uma macro seja aplicada automaticamente a cada imagem que chegar durante um experimento.
