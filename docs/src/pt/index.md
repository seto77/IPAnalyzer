<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# Manual do IPAnalyzer

## Breve introdução

* O **IPAnalyzer** é um software livre licenciado sob a licença MIT que converte imagens bidimensionais de difração de pó (anéis de Debye–Scherrer) registradas com Imaging Plates (IP) ou detectores de painel plano CCD/CMOS em perfis 2θ–intensidade unidimensionais de alta precisão.
* Ele calibra a geometria de medição — comprimento de câmara, comprimento de onda, inclinação do detector e forma do pixel — a partir dos anéis de materiais de referência, suporta fontes de raios X, elétrons e nêutrons, e integra-se com o [PDIndexer](https://github.com/seto77/PDIndexer) para a análise de picos subsequente.
* Seu projeto e funcionalidades seguem o *PIP*, desenvolvido por Hiroshi Fujihisa no AIST.

## Encontrar por objetivo

| Objetivo | Comece aqui | Próximos passos principais |
|------|------------|-----------------|
| Entender o sistema de coordenadas e a geometria | [Visão geral](0-overview.md) | [Janelas de propriedades](2-property-windows.md) |
| Carregar uma imagem e obter um perfil 1D | [Procedimentos](4-procedures.md) | [Janela principal](1-main-window.md), [Janelas de propriedades](2-property-windows.md) |
| Calibrar comprimento de câmara / comprimento de onda | [Procedimentos](4-procedures.md) | [Ferramentas](3-tools.md), [Encontrar parâmetros (força bruta)](6-find-parameter.md) |
| Mascarar pontos / lidar com dados multiquadro | [Ferramentas](3-tools.md) | [Procedimentos](4-procedures.md) |
| Automatizar o processamento | [Macro](5-macro/index.md) | [Funções integradas](5-macro/1-built-in-functions.md), [Exemplos](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Funcionalidades

* **Amplo suporte a formatos** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4 e formatos de imagem gerais. A maior parte da E/S de arquivos suporta arrastar e soltar.
* **Conversão de imagem em perfil** : Cálculo de integração concêntrica (média radial), radial (azimutal/cake) e de imagem desenrolada, usando um algoritmo de distribuição de área sub-pixel que trata corretamente a inclinação do detector e formas de pixel em paralelogramo.
* **Calibração da geometria** : Refinamento geométrico (de cassete duplo) do comprimento de onda, comprimento de câmara, tamanho/distorção do pixel e inclinação (φ, τ), além de uma busca exaustiva em grade (força bruta) para dados difíceis.
* **Manipulação de imagem** : Detecção automática do centro do feixe, detecção e mascaramento de pontos de monocristal (spot), desfoque circunferencial, sobreposição de anéis, calibração do detector por tabela de intensidades e salvamento IPA preservando a geometria.
* **Dados multiquadro** : Selecionar, calcular a média ou somar quadros de HDF5/NeXus e outros dados sequenciais, com comprimento de onda por quadro a partir da energia incorporada.
* **Automação** : Auto Procedure com monitoramento de pasta e uma [macro](5-macro/index.md) com sintaxe Python para processamento em lote e por script.
* **Integração com o PDIndexer** : Envie perfis ao [PDIndexer](https://github.com/seto77/PDIndexer) através da área de transferência e dispare macros nomeadas nele.
* **Tema claro / escuro** : A interface segue um modo de cor claro ou escuro selecionável.

## Requisitos de sistema

| Item | Mínimo | Recomendado |
|------|---------|-------------|
| OS | Windows com [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Memória | - | 16 GB ou mais |
| CPU | - | 8+ núcleos (as intensidades da imagem são mantidas em precisão dupla e o processamento é multithread) |

## Início rápido

1. Baixe e instale a partir de [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Leia uma imagem de difração (File → Read image, ou arrastar e soltar).
3. Defina a **Wave source** e a **Detector condition** (comprimento de câmara, tamanho do pixel, centro aproximado) na janela de propriedades.
4. Encontre o centro, mascare os pontos se necessário e pressione **Get Profile** para obter o perfil 1D.
5. Se a geometria for desconhecida, calibre-a a partir de um material de referência — veja [Procedimentos](4-procedures.md).

Veja [Procedimentos](4-procedures.md) para o fluxo de trabalho completo.

## Como usar este manual

Este manual no GitHub Pages é a fonte de verdade atual. Use a navegação à esquerda para navegar por capítulo, ou use a busca no cabeçalho para encontrar um nome de função ou rótulo de UI. Ele substitui o antigo manual em Word/HTML/PDF que era distribuído em `IPAnalyzer/doc/`.

## Licença

O IPAnalyzer é distribuído sob a [Licença MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
