<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Apéndice A3. Integración de la imagen

Al convertir una imagen 2D en un perfil 1D, el mayor problema es **cómo distribuir la intensidad de un píxel que abarca varios pasos cuando el tamaño del paso angular de la integración es menor que el espaciado de píxeles (tamaño de píxel)**. IPAnalyzer gestiona esta distribución con un **método de distribución basado en el área**.

---

## Método de distribución basado en el área

En este software, el programa calcula las intersecciones entre las líneas que delimitan cada paso (los límites de igual ángulo de difracción) y los píxeles, obtiene el **área** de cada píxel que cae dentro de un paso dado y distribuye la intensidad de forma proporcional a esa área.

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

Este método tiene las siguientes características.

- Dentro de cada píxel, el arco del límite del paso se **aproxima como una línea recta**. Esto se hace por velocidad de cálculo y casi nunca supone un problema en la práctica.
- Cuando se requieren la corrección de inclinación y la corrección de forma de píxel de [A1. Geometría del detector](a1-geometry.md), la forma del píxel no es estrictamente cuadrada. Por ello, el software **calcula secuencialmente las coordenadas de las cuatro esquinas del píxel** y obtiene el área como un cuadrilátero (en general, un paralelogramo).

Con este esquema, en principio, por muy fino que se haga el paso angular, la intensidad del píxel se distribuye de forma suave entre los pasos.

---

## Ámbito de aplicación

El mismo algoritmo de distribución basado en el área se utiliza para los tres tipos de integración siguientes.

| Función | Dirección de integración | Uso |
|------|-----------|------|
| **Concentric Integration** | Ángulo de difracción (dirección concéntrica) | Creación de un perfil $2\theta$-intensidad ordinario. |
| **Radial Integration** | Dirección circunferencial (azimutal) | Evaluación de la dependencia azimutal de un anillo (orientación, distorsión). |
| **Unrolled Image** | Ángulo de difracción × azimut | Creación de una imagen desenrollada 2D con el anillo cortado y abierto. |

Para saber cómo operar cada función, consulte [3. Herramientas](../3-tools.md).
