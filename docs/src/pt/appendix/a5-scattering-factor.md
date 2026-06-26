<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Apêndice A5. Scattering Factor

A janela **Scattering Factor** lista os planos cristalinos permitidos (reflexões) do cristal selecionado e calcula o **fator de estrutura** e a intensidade de difração de cada um. O tipo de radiação (raios X, elétrons ou nêutrons) pode ser alternado, de modo que os fatores de estrutura de um mesmo cristal possam ser comparados entre as diferentes técnicas de difração.

No IPAnalyzer, esta subjanela é aberta a partir da **Crystal window** (o CrystalControl usado em [4. Practical procedures](../4-procedures.md) para a calibração geométrica e em [6. Find Parameter (brute force)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

As condições de cálculo ficam na parte superior da janela e a lista de reflexões na parte inferior. A lista é recalculada imediatamente sempre que uma condição é alterada.

---

## Atalhos de teclado e mouse

Esta janela não possui combinações especiais de teclas ou mouse. <kbd>F1</kbd> abre esta página do manual, e **Copy to clipboard** exporta toda a tabela de reflexões como texto colável em planilhas.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : os fatores de espalhamento atômico diferem conforme o tipo de feixe incidente, portanto são alternados aqui.
- Para **X-ray**, escolher o **Element** (material do ânodo) e a linha característica (Kα, etc.) define automaticamente o comprimento de onda desse raio X característico.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** e **Wavelength (Å)** estão vinculados entre si.
- Essa energia ou comprimento de onda é usado para calcular 2θ (o ângulo de difração). Para X-ray, também pode ser definido por meio da seleção do elemento e do tipo de linha.

---

## Opções de exibição e cálculo

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : calcula a intensidade relativa como uma intensidade de difração de pó (Bragg–Brentano), incluindo a multiplicidade e o fator de Lorentz–polarização. Quando desativada, exibe a intensidade do fator de estrutura.
- **Hide equivalent planes** : agrupa os planos cristalograficamente equivalentes em uma única entrada.
- **Hide prohibited planes** : exclui os planos cuja intensidade é zero pelas regras de extinção.
- **Unit (Å / nm)** : alterna a unidade de comprimento para d-spacing, etc.
- **d-Spacing Cutoff** : exclui as reflexões com d-spacing menor que este valor.

---

## Lista de reflexões

Cada linha corresponde a uma reflexão (ou a um grupo de planos equivalentes por simetria).

| Coluna | Significado |
|------|------|
| **h, k, l** | índices de Miller |
| **Multi.** | multiplicidade (número de planos equivalentes por simetria) |
| **d (Å)** | espaçamento interplanar |
| **q (2π/d)** | magnitude do vetor de espalhamento |
| **2θ (°)** | ângulo de difração para o comprimento de onda selecionado |
| **F_real** | parte real do fator de estrutura |
| **F_inv** | parte imaginária do fator de estrutura |
| **\|F\|** | amplitude do fator de estrutura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensidade do fator de estrutura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensidade relativa, com a reflexão mais intensa definida como 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copia a lista para a área de transferência como texto que pode ser colado em uma planilha, como o Excel.

---

## Veja também

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — definição do cristal de referência cujos fatores de estrutura são calculados.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
