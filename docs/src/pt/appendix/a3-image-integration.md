<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

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

O mesmo algoritmo de distribuição por área é usado nos três tipos de integração a seguir. Eles diferem quanto à coordenada que permanece no eixo horizontal da saída e quanto aos pixels que são reunidos em um ponto da saída.

| Função | Eixo horizontal da saída | Pixels reunidos em um ponto da saída | Uso |
|------|------|------|------|
| **Integração concêntrica (Concentric integration)** | Ângulo de difração $2\theta$ (ou distância d) | Os que estão dentro de um passo de $2\theta$ (ou de d), em todos os azimutes dentro da região de integração | Criar um perfil $2\theta$-intensidade comum. |
| **Integração radial (Radial integration)** | Azimute $\chi$ | Os que estão dentro de um passo azimutal (**Passo do ângulo do setor (passo de varredura) (Sector angle step (Sweep step))**), no anel dado por **Raio do anel (Donut radius)** ± **Largura do anel (Donut width)** | Avaliar a dependência azimutal de um anel (orientação, distorção). |
| **Unrolled image** | $2\theta$ (horizontal) × azimute $\chi$ (vertical) | Os que estão dentro de um passo de $2\theta$ e de um setor azimutal ($360^\circ/N$) | Criar uma imagem desenrolada 2D, com o anel cortado e aberto. |

Em todos os casos, só são usados os pixels válidos: os pixels mascarados e os pixels excluídos na aba **Região de integração (Integral Region)** não contribuem.

---

## Normalização após a integração

As intensidades distribuídas são normalizadas de maneira diferente conforme a função.

- **Integração concêntrica** (detector de painel plano, eixo $2\theta$ ou distância d) e a **imagem desenrolada**: para cada passo (cada pixel da imagem desenrolada), as intensidades distribuídas são somadas, e a soma é dividida pela quantidade que contribuiu para esse passo. A contribuição de cada parte de um pixel é medida pela sua área projetada no plano perpendicular ao raio espalhado, à distância do comprimento de câmara, ou seja, pelo ângulo sólido que ela subtende, contado em unidades de um pixel visto de frente à distância do comprimento de câmara. O resultado é, portanto, uma intensidade média por unidade de ângulo sólido: não depende da largura do passo nem de quantos pixels caem em um passo, e a diminuição do ângulo sólido por pixel em direção aos ângulos altos em um detector plano é compensada. Um passo que não recebe nenhum pixel vale 0.
- **Integração radial**: as intensidades distribuídas são simplesmente somadas para cada passo azimutal e não são divididas. Os valores, portanto, crescem com a largura do anel (**Largura do anel (Donut width)**) e com o passo azimutal.

Para saber como operar cada função, veja [3. Ferramentas](../3-tools.md).
