<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# Apéndice A5. Factor de dispersión

**Scattering Factor** (factor de dispersión) enumera los planos cristalinos permitidos (reflexiones) del cristal seleccionado y calcula el **factor de estructura** y la intensidad de difracción de cada uno. El tipo de radiación (rayos X, electrones o neutrones) se puede cambiar, de modo que los factores de estructura de un mismo cristal se pueden comparar entre técnicas de difracción.

En la versión actual, esta lista está en la pestaña **Reflexiones (Reflections)** de **Interacción del haz (Beam interaction)** en la ventana de cristal (los factores de dispersión atómicos propiamente dichos están en la pestaña **Factores de dispersión (Scattering factors)** de la misma ventana). Las pantallas y los elementos descritos a continuación se basan en la antigua ventana Scattering Factor.

En IPAnalyzer, esta subventana se abre desde la **ventana de cristal** (Crystal window; el CrystalControl que se usa en [4. Procedimientos](../4-procedures.md) para la calibración geométrica y en [6. Buscar parámetros (fuerza bruta)](../6-find-parameter.md)).

![Factor de dispersión (Scattering Factor)](../../assets/cap-en-auto/FormScatteringFactor.png)

Las condiciones de cálculo están en la parte superior de la ventana y la lista de reflexiones en la parte inferior. La lista se recalcula inmediatamente cada vez que cambia una condición.

---

## Atajos de teclado y ratón

Esta ventana no tiene combinaciones especiales de teclas ni de ratón. <kbd>F1</kbd> abre esta página del manual, y **Copy to clipboard** exporta toda la tabla de reflexiones como texto que se puede pegar en una hoja de cálculo.

---

## Control de longitud de onda (Wave Length Control)

- **X-ray / Electron / Neutron**: los factores de dispersión atómicos difieren según el tipo de haz incidente, por lo que se cambian aquí.
- Para **X-ray**, al elegir el **Element** (material del ánodo) y la línea característica (Kα, etc.), la longitud de onda de esos rayos X característicos se define automáticamente.

![Control de longitud de onda (Wave Length Control)](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** y **Wavelength (Å)** están vinculados entre sí.
- Esta energía o longitud de onda se usa para calcular 2θ (el ángulo de difracción). Para rayos X también se puede definir mediante la selección del elemento y del tipo de línea.

---

## Opciones de visualización y de cálculo

- **Intensidades de difracción de polvo (óptica Bragg-Brentano) (Powder Diffraction Intensities (Bragg-Brentano Optics))**: calcula la intensidad relativa como intensidad de difracción de polvo (Bragg–Brentano), incluidos la multiplicidad y el factor de Lorentz–polarización. Si está desactivada, muestra la intensidad del factor de estructura.
- **Ocultar planos equivalentes (Hide equivalent planes)**: agrupa en una sola entrada los planos cristalográficamente equivalentes.
- **Ocultar planos prohibidos (Hide prohibited planes)**: excluye los planos cuya intensidad es cero por las reglas de extinción.
- **Unit (Å / nm)**: cambia la unidad de longitud del espaciado d, etc.
- **d-Spacing Cutoff**: excluye las reflexiones con un espaciado d menor que este valor.

---

## Lista de reflexiones

Cada fila corresponde a una reflexión (o a un grupo de planos equivalentes por simetría).

| Columna | Significado |
|------|------|
| **h, k, l** | índices de Miller |
| **Multi.** | multiplicidad (número de planos equivalentes por simetría) |
| **d (Å)** | espaciado interplanar |
| **q (2π/d)** | módulo del vector de dispersión |
| **2θ (°)** | ángulo de difracción para la longitud de onda seleccionada |
| **F_real** | parte real del factor de estructura |
| **F_inv** | parte imaginaria del factor de estructura |
| **\|F\|** | amplitud del factor de estructura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensidad del factor de estructura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensidad relativa, con la reflexión más intensa fijada en 100 |

---

## Copiar al portapapeles

**Copy to Clipboard** copia la lista al portapapeles como texto que se puede pegar en una hoja de cálculo como Excel.

---

## Véase también

- [Página principal del apéndice](index.md)
- [4. Procedimientos](../4-procedures.md) — definición del cristal de referencia cuyos factores de estructura se calculan.
- [6. Buscar parámetros (fuerza bruta)](../6-find-parameter.md)
