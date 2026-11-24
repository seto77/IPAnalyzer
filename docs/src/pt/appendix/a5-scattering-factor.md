<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# Apêndice A5. Fator de espalhamento

**Scattering Factor** lista os planos cristalinos permitidos (reflexões) do cristal selecionado e calcula o **fator de estrutura** e a intensidade de difração de cada um. O tipo de radiação (raios X, elétrons ou nêutrons) pode ser alternado, de modo que os fatores de estrutura do mesmo cristal podem ser comparados entre as técnicas de difração.

Na versão atual, esta lista fica na aba **Reflexões (Reflections)** de **Interação do feixe (Beam interaction)** na janela do cristal (os próprios fatores de espalhamento atômico ficam na aba **Fatores de dispersão (Scattering factors)** da mesma janela). As telas e os itens descritos abaixo baseiam-se na antiga janela Scattering Factor.

No IPAnalyzer, esta subjanela é aberta a partir da **Crystal window** (o CrystalControl usado na calibração geométrica em [4. Procedimentos](../4-procedures.md) e em [6. Encontrar parâmetros (força bruta)](../6-find-parameter.md)).

![Fator de espalhamento](../../assets/cap-en-auto/FormScatteringFactor.png)

As condições de cálculo ficam na parte superior da janela, e a lista de reflexões na parte inferior. A lista é recalculada imediatamente sempre que uma condição muda.

---

## Atalhos de teclado e mouse

Esta janela não tem combinações especiais de teclas ou de mouse. <kbd>F1</kbd> abre esta página do manual, e **Copy to clipboard** exporta a tabela de reflexões inteira como texto que pode ser colado em uma planilha.

---

## Wave Length Control (controle do comprimento de onda)

- **X-ray / Electron / Neutron** : os fatores de espalhamento atômico diferem conforme o tipo de feixe incidente, por isso são alternados aqui.
- Para **X-ray**, escolher o **Element** (material do ânodo) e a linha característica (Kα etc.) define automaticamente o comprimento de onda desses raios X característicos.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** e **Wavelength (Å)** estão vinculados entre si.
- Essa energia ou esse comprimento de onda é usado para calcular 2θ (o ângulo de difração). Para raios X, também pode ser definido pela seleção do elemento e do tipo de linha.

---

## Opções de exibição e de cálculo

- **Intensidades de difração de pó (óptica Bragg-Brentano) (Powder Diffraction Intensities (Bragg-Brentano Optics))** : calcula a intensidade relativa como uma intensidade de difração de pó (Bragg–Brentano), incluindo a multiplicidade e o fator de Lorentz–polarização. Quando desativado, exibe a intensidade do fator de estrutura.
- **Ocultar planos equivalentes (Hide equivalent planes)** : reúne os planos cristalograficamente equivalentes em uma única entrada.
- **Ocultar planos proibidos (Hide prohibited planes)** : exclui os planos cuja intensidade é nula pelas regras de extinção.
- **Unit (Å / nm)** : alterna a unidade de comprimento da distância interplanar etc.
- **d-Spacing Cutoff** : exclui as reflexões com distância interplanar menor que este valor.

---

## Lista de reflexões

Cada linha corresponde a uma reflexão (ou a um grupo de planos equivalentes por simetria).

| Coluna | Significado |
|------|------|
| **h, k, l** | índices de Miller |
| **Multi.** | multiplicidade (número de planos equivalentes por simetria) |
| **d (Å)** | distância interplanar |
| **q (2π/d)** | módulo do vetor de espalhamento |
| **2θ (°)** | ângulo de difração para o comprimento de onda selecionado |
| **F_real** | parte real do fator de estrutura |
| **F_inv** | parte imaginária do fator de estrutura |
| **\|F\|** | amplitude do fator de estrutura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensidade do fator de estrutura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensidade relativa, com a reflexão mais forte igual a 100 |

---

## Copiar para a área de transferência

**Copy to Clipboard** copia a lista para a área de transferência como texto que pode ser colado em uma planilha como o Excel.

---

## Veja também

- [Página inicial do apêndice](index.md)
- [4. Procedimentos](../4-procedures.md) — definição do cristal padrão cujos fatores de estrutura são calculados.
- [6. Encontrar parâmetros (força bruta)](../6-find-parameter.md)
