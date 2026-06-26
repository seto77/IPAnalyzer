<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Apêndice A3. Integração da imagem

Ao converter uma imagem 2D em um perfil 1D, o maior problema é **como distribuir a intensidade de um pixel que abrange vários passos quando o tamanho do passo angular da integração é menor que o espaçamento dos pixels (tamanho do pixel)**. O IPAnalyzer trata essa distribuição com um **método de distribuição baseado em área**.

---

## Método de distribuição baseado em área

Neste software, o programa calcula as interseções entre as linhas que delimitam cada passo (as fronteiras de igual ângulo de difração) e os pixels, obtém a **área** de cada pixel que se enquadra em um dado passo e distribui a intensidade proporcionalmente a essa área.

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

Esse método tem as seguintes características.

- Dentro de cada pixel, o arco da fronteira do passo é **aproximado como uma linha reta**. Isso é feito para ganhar velocidade de cálculo e quase nunca é um problema na prática.
- Quando a correção de inclinação e a correção de forma do pixel descritas em [A1. Geometria do detector](a1-geometry.md) são necessárias, a forma do pixel não é estritamente quadrada. Por isso, o software **calcula sequencialmente as coordenadas dos quatro cantos do pixel** e obtém a área como um quadrilátero (em geral, um paralelogramo).

Com esse esquema, em princípio, por mais fino que se torne o passo angular, a intensidade do pixel é distribuída suavemente entre os passos.

---

## Escopo de aplicação

O mesmo algoritmo de distribuição baseado em área é usado para os três tipos de integração a seguir.

| Função | Direção da integração | Uso |
|------|-----------|------|
| **Concentric Integration** | Ângulo de difração (direção concêntrica) | Criação de um perfil $2\theta$-intensidade comum. |
| **Radial Integration** | Direção circunferencial (azimutal) | Avaliação da dependência azimutal de um anel (orientação, distorção). |
| **Unrolled Image** | Ângulo de difração × azimute | Criação de uma imagem 2D desenrolada com o anel aberto. |

Para saber como operar cada função, consulte [3. Ferramentas](../3-tools.md).
