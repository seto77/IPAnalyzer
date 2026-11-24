<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). -->

# Manual do IPAnalyzer

## Breve introdução

* O **IPAnalyzer** é um software livre sob a licença MIT que converte imagens bidimensionais de difração de pó (anéis de Debye–Scherrer) registradas com Imaging Plates (IP) ou detectores de painel plano CCD/CMOS em perfis 2θ–intensidade unidimensionais de alta precisão.
* Ele calibra a geometria de medição — comprimento de câmara, comprimento de onda, inclinação do detector e forma do pixel — a partir dos anéis de materiais de referência, suporta fontes de raios X, elétrons e nêutrons, e integra-se com o [PDIndexer](https://github.com/seto77/PDIndexer) para a análise de picos subsequente.
* Seu projeto e suas funcionalidades seguem o *PIP*, desenvolvido por Hiroshi Fujihisa no AIST.

## Encontrar por objetivo

| Objetivo | Comece aqui | Próximos passos principais |
|------|------------|-----------------|
| Entender o sistema de coordenadas e a geometria | [Visão geral](0-overview.md) | [Janelas de propriedades](2-property-windows.md) |
| Carregar uma imagem e obter um perfil 1D | [Procedimentos](4-procedures.md) | [Janela principal](1-main-window.md), [Janelas de propriedades](2-property-windows.md) |
| Calibrar comprimento de câmara / comprimento de onda | [Procedimentos](4-procedures.md) | [Ferramentas](3-tools.md), [Encontrar parâmetros (força bruta)](6-find-parameter.md) |
| Mascarar pontos / lidar com dados multiquadro | [Ferramentas](3-tools.md) | [Procedimentos](4-procedures.md) |
| Automatizar o processamento | [Macro](5-macro/index.md) | [Funções integradas](5-macro/1-built-in-functions.md), [Exemplos](5-macro/2-examples.md), [Procedimento automático (Auto Procedure)](3-tools.md) |
| Solução de problemas e perguntas frequentes | [Q&A](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## Funcionalidades

* **Amplo suporte a formatos** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4 e formatos de imagem gerais. A maior parte da E/S de arquivos aceita arrastar e soltar.
* **Conversão de imagem em perfil** : Integração concêntrica (média radial), radial (azimutal/cake) e cálculo da imagem desenrolada, usando um algoritmo de distribuição de área sub-pixel que trata corretamente a inclinação do detector e pixels em forma de paralelogramo.
* **Calibração da geometria** : Refinamento geométrico (cassete duplo) do comprimento de onda, comprimento de câmara, tamanho/distorção do pixel e inclinação (φ, τ), além de uma busca exaustiva em grade (força bruta) para dados difíceis.
* **Manipulação de imagem** : Detecção automática do centro do feixe, detecção e mascaramento de pontos de monocristal (spots), desfoque circunferencial, sobreposição de anéis, calibração da intensidade de imagens R-AXIS e salvamento no formato IPA preservando a geometria.
* **Dados multiquadro** : Selecione, calcule a média ou some quadros de NeXus (`.nxs`), TIFF de várias páginas e outros dados sequenciais; quando um quadro contém informação de energia, selecioná-lo atualiza o comprimento de onda.
* **Automação** : Procedimento automático (Auto Procedure) com monitoramento de pasta e uma [macro](5-macro/index.md) com sintaxe Python para processamento em lote e por script.
* **Integração com o PDIndexer** : Envie perfis ao [PDIndexer](https://github.com/seto77/PDIndexer) pela área de transferência e dispare nele macros nomeadas.

## Requisitos de sistema

Estes requisitos aplicam-se às compilações .NET 11 feitas a partir deste código-fonte. Para as versões publicadas, siga o requisito de runtime indicado para cada versão.

| Item | Mínimo | Recomendado |
|------|---------|-------------|
| SO | Windows com [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) | Windows 11 |
| Memória | - | 16 GB ou mais |
| CPU | - | 8+ núcleos (as intensidades da imagem são mantidas em precisão dupla e o processamento é multithread) |

## Início rápido

1. Baixe e instale a partir de [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Leia uma imagem de difração (**Arquivo (File) → Ler imagem (Read image)**, ou arrastar e soltar).
3. Defina a **Fonte de ondas (Wave source)** e a **Condição do detector (Detector condition)** (comprimento de câmara, tamanho do pixel, centro aproximado) na janela de propriedades.
4. Se a geometria (comprimento de câmara, comprimento de onda, inclinação) for desconhecida, calibre-a primeiro a partir de uma imagem de uma amostra de referência e aplique os valores — veja [Procedimentos](4-procedures.md).
5. Na imagem da amostra, encontre o centro, mascare os pontos se necessário e pressione **Obter perfil (Get Profile)** para obter o perfil 1D.

Veja [Procedimentos](4-procedures.md) para o fluxo de trabalho completo.

## Como usar este manual

Este manual no GitHub Pages é a referência atual. Use a navegação à esquerda para percorrer os capítulos, ou a busca no cabeçalho para encontrar um nome de função ou um rótulo da interface. Ele substitui o antigo manual em Word/HTML/PDF que era distribuído em `IPAnalyzer/doc/`.

## Licença

O IPAnalyzer é distribuído sob a [Licença MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
