<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). -->

# Apéndice A3. Integración de la imagen

Al convertir una imagen 2D en un perfil 1D, el mayor problema es **cómo repartir la intensidad de un píxel que abarca varios pasos cuando el tamaño del paso angular de la integración es menor que la separación entre píxeles (tamaño de píxel)**. IPAnalyzer resuelve este reparto con un **método de distribución basado en el área**.

---

## Método de distribución basado en el área

En este programa se calculan las intersecciones entre las líneas que delimitan cada paso (las fronteras de igual ángulo de difracción) y los píxeles, se obtiene el **área** de cada píxel que cae dentro de un paso dado y se reparte la intensidad en proporción a esa área.

![Distribución basada en el área. Imagen real de anillos (izquierda) → escala de píxel (centro; las líneas discontinuas verdes son las fronteras de los pasos) → intersecciones con las fronteras de los pasos dentro de un único píxel (derecha; áreas delimitadas por las cuatro esquinas y las intersecciones).](../../assets/references/integration-area-distribution.png){width=680px}

Este método tiene las características siguientes.

- Dentro de cada píxel, el arco de la frontera del paso se **aproxima por una recta**. Esto se hace por velocidad de cálculo y en la práctica casi nunca supone un problema.
- Cuando se necesitan la corrección de inclinación y la corrección de la forma del píxel de [A1. Geometría del detector](a1-geometry.md), la forma del píxel no es estrictamente cuadrada. Por ello, el programa **calcula sucesivamente las coordenadas de las cuatro esquinas del píxel** y obtiene el área como un cuadrilátero (en general, un paralelogramo).

Con este esquema, en principio, por fino que sea el paso angular, la intensidad del píxel se reparte de forma suave entre los pasos.

---

## Ámbito de aplicación

El mismo algoritmo de distribución basado en el área se usa en los tres tipos de integración siguientes.

| Función | Dirección de integración | Uso |
|------|-----------|------|
| **Integración concéntrica (Concentric Integration)** | Ángulo de difracción (dirección concéntrica) | Crear un perfil ordinario $2\theta$-intensidad. |
| **Integración radial (Radial Integration)** | Dirección circunferencial (azimutal) | Evaluar la dependencia azimutal de un anillo (orientación, deformación). |
| **Unrolled Image** (imagen desplegada) | Ángulo de difracción × azimut | Crear una imagen desplegada 2D con el anillo abierto. |

Para el manejo de cada función, véase [3. Herramientas](../3-tools.md).
