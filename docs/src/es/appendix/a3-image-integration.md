<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

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

El mismo algoritmo de distribución basado en el área se usa en los tres tipos de integración siguientes. Se diferencian en qué coordenada queda en el eje horizontal de la salida y en qué píxeles se combinan en un punto de salida.

| Función | Eje horizontal de la salida | Píxeles combinados en un punto de salida | Uso |
|------|------|------|------|
| **Integración concéntrica (Concentric integration)** | Ángulo de difracción $2\theta$ (o espaciado d) | Los que caen dentro de un paso de $2\theta$ (o d), en todos los azimuts dentro de la región de integración | Crear un perfil ordinario $2\theta$-intensidad. |
| **Integración radial (Radial integration)** | Azimut $\chi$ | Los que caen dentro de un paso azimutal (**Paso del ángulo de sector (paso de barrido) (Sector angle step (Sweep step))**), dentro del anillo definido por **Radio del anillo (Donut radius)** ± **Anchura del anillo (Donut width)** | Evaluar la dependencia azimutal de un anillo (orientación, deformación). |
| **Unrolled image** (imagen desplegada) | $2\theta$ (horizontal) × azimut $\chi$ (vertical) | Los que caen dentro de un paso de $2\theta$ y un sector azimutal ($360^\circ/N$) | Crear una imagen desplegada 2D con el anillo abierto. |

En todos los casos solo se usan los píxeles válidos: los píxeles enmascarados y los excluidos en la pestaña **Región de integración (Integral Region)** no contribuyen.

---

## Normalización tras la integración

Las intensidades distribuidas se normalizan de forma distinta según la función.

- **Integración concéntrica** (detector de panel plano, eje $2\theta$ o de espaciado d) e **imagen desplegada**: para cada paso (cada píxel de la imagen desplegada), se suman las intensidades distribuidas y la suma se divide por la cantidad que ha contribuido a ese paso. La contribución de cada parte de un píxel se mide por su área proyectada sobre el plano perpendicular al rayo dispersado a la distancia de la longitud de cámara, es decir, por el ángulo sólido que subtiende, contado en unidades de un píxel visto de frente a la longitud de cámara. Por tanto, el resultado es una intensidad media por unidad de ángulo sólido: no depende de la anchura del paso ni de cuántos píxeles caen en un paso, y se compensa la disminución del ángulo sólido por píxel hacia ángulos altos en un detector plano. Un paso que no recibe ningún píxel vale 0.
- **Integración radial**: las intensidades distribuidas simplemente se suman para cada paso azimutal y no se dividen. Por tanto, los valores crecen con la anchura del anillo (**Anchura del anillo (Donut width)**) y con el paso azimutal.

Para el manejo de cada función, véase [3. Herramientas](../3-tools.md).
