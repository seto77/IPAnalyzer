<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). -->

# Apêndice A3. Integração da imagem

Ao converter uma imagem 2D em um perfil 1D, o maior problema é **como distribuir a intensidade de um pixel que abrange vários passos quando o passo angular da integração é menor que o espaçamento dos pixels (tamanho do pixel)**. O IPAnalyzer trata essa distribuição com um **método de distribuição por área**.

---

## Método de distribuição por área

Neste software, o programa calcula as interseções entre as retas que delimitam cada passo (as fronteiras de igual ângulo de difração) e os pixels, obtém a **área** de cada pixel que cai dentro de um dado passo e distribui a intensidade proporcionalmente a essa área.

![Distribuição por área. Imagem real dos anéis (esquerda) → escala dos pixels (centro; as linhas tracejadas verdes são as fronteiras dos passos) → interseções com as fronteiras dos passos dentro de um único pixel (direita; áreas delimitadas pelos quatro cantos e pelas interseções).](../../assets/references/integration-area-distribution.png){width=680px}

Este método tem as seguintes características.

- Dentro de cada pixel, o arco da fronteira do passo é **aproximado por uma reta**. Isso é feito pela velocidade de cálculo e quase nunca é um problema na prática.
- Quando a correção de inclinação e a correção da forma do pixel da [A1. Geometria do detector](a1-geometry.md) são necessárias, a forma do pixel não é estritamente quadrada. O software, portanto, **calcula sucessivamente as coordenadas dos quatro cantos do pixel** e obtém a área como um quadrilátero (em geral, um paralelogramo).

Com esse esquema, em princípio, por mais fino que seja o passo angular, a intensidade do pixel é distribuída de modo suave entre os passos.

---

## Âmbito de aplicação

O mesmo algoritmo de distribuição por área é usado nos três tipos de integração a seguir.

| Função | Direção da integração | Uso |
|------|-----------|------|
| **Integração concêntrica (Concentric Integration)** | Ângulo de difração (direção concêntrica) | Criar um perfil $2\theta$-intensidade comum. |
| **Integração radial (Radial Integration)** | Direção circunferencial (azimutal) | Avaliar a dependência azimutal de um anel (orientação, distorção). |
| **Unrolled Image** | Ângulo de difração × azimute | Criar uma imagem desenrolada 2D, com o anel cortado e aberto. |

Para saber como operar cada função, veja [3. Ferramentas](../3-tools.md).
