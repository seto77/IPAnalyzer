<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes; fully retranslated from the rewritten en page) -->

# Apêndice A5. Fator de espalhamento

Na versão atual, as reflexões e os fatores de estrutura de um cristal são mostrados na aba **Reflexões (Reflections)** da janela **Interação do feixe (Beam Interaction)** (a antiga janela Scattering Factor foi substituída por ela). A aba lista os planos cristalinos permitidos (reflexões) do cristal selecionado e calcula o **fator de estrutura** e a intensidade de difração de cada um. O tipo de radiação (raios X, elétrons ou nêutrons) pode ser alternado, de modo que os fatores de estrutura do mesmo cristal podem ser comparados entre as técnicas de difração.

No IPAnalyzer, abra-a a partir da janela do cristal que define o cristal padrão usado na calibração de parâmetros (a janela do cristal aberta com **Definir cristal (Set crystal)** em [Encontrar parâmetros (geométrico)](../3-tools.md), ou o painel do cristal de [6. Encontrar parâmetros (força bruta)](../6-find-parameter.md)): pressione o botão **Interação do feixe (Beam interaction)** ou escolha **Interação do feixe (Beam Interaction)** no menu de clique com o botão direito do painel do cristal.

![Janela Interação do feixe (aba Reflexões)](../../assets/references/beam-interaction-reflections-en.png)

A faixa na parte superior seleciona o feixe incidente, e a aba **Reflexões (Reflections)** abaixo mostra a lista de reflexões (parte superior) e um diagrama de barras das mesmas reflexões (parte inferior). A lista é recalculada imediatamente sempre que uma condição muda. As demais abas (**Atenuação & Transporte (Attenuations & transport)**, **Fatores de dispersão (Scattering factors)**, **Fluorescência (Fluorescence)**) não são necessárias para o IPAnalyzer; para elas, veja [Interação do feixe no manual do ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/).

---

## Atalhos de teclado e mouse

Esta janela não tem combinações especiais de teclas ou de mouse. <kbd>F1</kbd> abre esta página do manual, e **Copiar (Copy)** exporta a tabela de reflexões como texto que pode ser colado em uma planilha.

---

## Feixe e comprimento de onda

- **X-ray / Electron / Neutron** : os fatores de espalhamento atômico diferem conforme o tipo de feixe incidente, por isso são alternados aqui.
- Para **X-ray**, escolher o **Element** (material do ânodo) e a linha característica (Kα etc.) define automaticamente o comprimento de onda desses raios X característicos.
- **Energy** (keV) e **Wavelength** (Å) estão vinculados; definir um deles atualiza o outro, e ambos são usados para calcular o 2θ de cada reflexão.
- **Unit** (**Å** / **nm**) alterna a unidade de comprimento usada para a distância interplanar e grandezas semelhantes.

---

## Opções da aba Reflexões

- **Intensidades de difração de pó (óptica Bragg-Brentano) (Powder diffraction intensities (Bragg-Brentano optics))** : calcula a intensidade relativa como uma intensidade de difração de pó (Bragg–Brentano), $I \propto m\,\lvert F\rvert^2 / V^2 \times L$, em que $m$ é a multiplicidade, $V$ o volume da célula e $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (fator de Lorentz–polarização) para raios X, ou $L = 1/(\sin 2\theta\,\sin\theta)$ (somente o fator de Lorentz) para elétrons e nêutrons. As reflexões que o feixe não consegue alcançar (d < λ/2) recebem intensidade 0. Quando desativado, é mostrada a intensidade do fator de estrutura $\lvert F\rvert^2$. Ativá-lo também ativa **Ocultar planos equivalentes (Hide equivalent planes)** e **Ocultar planos proibidos (Hide prohibited planes)** e os deixa desabilitados (em cinza).
- **Ocultar planos equivalentes (Hide equivalent planes)** (ativado por padrão) : reúne os planos cristalograficamente equivalentes em uma única entrada. A coluna **Multi.** só é exibida enquanto esta opção está ativada.
- **Ocultar planos proibidos (Hide prohibited planes)** (ativado por padrão) : exclui os planos sistematicamente ausentes pelas regras de extinção. Enquanto está desativada, uma coluna **Condition** mostra a(s) condição(ões) de reflexão que proíbem cada plano ausente.
- **d-spacing cutoff >** (padrão 1 Å) : exclui as reflexões com distância interplanar menor que este valor (a unidade de comprimento segue **Unit**).

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
| **Condition** | condição(ões) de extinção violada(s) pelo plano (exibida somente quando **Ocultar planos proibidos (Hide prohibited planes)** está desativado) |

Abaixo da tabela, as mesmas reflexões são desenhadas como um padrão de barras, com os picos mais fortes rotulados pelos seus *hkl*. O seletor escolhe o eixo horizontal entre **2θ**, **d** e **Q** ($= 4\pi\sin\theta/\lambda$), **Log I** alterna o eixo de intensidade entre linear e logarítmico, e as caixas **Range** definem o intervalo representado.

---

## Copiar para a área de transferência

**Copiar (Copy)** copia a lista de reflexões para a área de transferência como texto que pode ser colado em uma planilha como o Excel.

---

## Veja também

- [Página inicial do apêndice](index.md)
- [4. Procedimentos](../4-procedures.md) — definição do cristal padrão cujos fatores de estrutura são calculados.
- [6. Encontrar parâmetros (força bruta)](../6-find-parameter.md)
- [Interação do feixe no manual do ReciPro](https://seto77.github.io/ReciPro/3-beam-interaction/) — as quatro abas da mesma janela.
