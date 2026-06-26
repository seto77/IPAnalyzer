<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Apéndice A5. Factor de dispersión

**Scattering Factor** lista los planos cristalinos permitidos (reflexiones) del cristal seleccionado y calcula el **factor de estructura** y la intensidad de difracción de cada uno. El tipo de radiación (rayos X, electrones o neutrones) se puede cambiar, de modo que los factores de estructura de un mismo cristal pueden compararse entre técnicas de difracción.

En IPAnalyzer, esta subventana se abre desde la **Crystal window** (el CrystalControl utilizado en [4. Practical procedures](../4-procedures.md) para la calibración geométrica y en [6. Find Parameter (brute force)](../6-find-parameter.md)).

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

Las condiciones de cálculo se encuentran en la parte superior de la ventana y la lista de reflexiones en la parte inferior. La lista se vuelve a calcular de inmediato cada vez que cambia una condición.

---

## Atajos de teclado y ratón

Esta ventana no tiene combinaciones especiales de teclas ni de ratón. <kbd>F1</kbd> abre esta página del manual, y **Copy to clipboard** exporta toda la tabla de reflexiones como texto pegable en una hoja de cálculo.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : los factores de dispersión atómicos difieren según el tipo de haz incidente, por lo que se cambian aquí.
- Para **X-ray**, al elegir el **Element** (material del ánodo) y la línea característica (Kα, etc.) se establece automáticamente la longitud de onda de ese rayo X característico.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** y **Wavelength (Å)** están vinculados entre sí.
- Esta energía o longitud de onda se utiliza para calcular 2θ (el ángulo de difracción). Para X-ray también puede establecerse mediante la selección del elemento y el tipo de línea.

---

## Opciones de visualización y cálculo

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : calcula la intensidad relativa como una intensidad de difracción de polvo (Bragg–Brentano), incluyendo la multiplicidad y el factor de Lorentz–polarización. Cuando está desactivado, muestra la intensidad del factor de estructura.
- **Hide equivalent planes** : agrupa los planos cristalográficamente equivalentes en una sola entrada.
- **Hide prohibited planes** : excluye los planos cuya intensidad es cero según las reglas de extinción.
- **Unit (Å / nm)** : cambia la unidad de longitud para el d-spacing, etc.
- **d-Spacing Cutoff** : excluye las reflexiones con un d-spacing menor que este valor.

---

## Lista de reflexiones

Cada fila corresponde a una reflexión (o a un grupo de planos equivalentes por simetría).

| Columna | Significado |
|------|------|
| **h, k, l** | índices de Miller |
| **Multi.** | multiplicidad (número de planos equivalentes por simetría) |
| **d (Å)** | espaciado interplanar |
| **q (2π/d)** | magnitud del vector de dispersión |
| **2θ (°)** | ángulo de difracción para la longitud de onda seleccionada |
| **F_real** | parte real del factor de estructura |
| **F_inv** | parte imaginaria del factor de estructura |
| **\|F\|** | amplitud del factor de estructura ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | intensidad del factor de estructura ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | intensidad relativa, con la reflexión más fuerte fijada en 100 |

---

## Copy to Clipboard

**Copy to Clipboard** copia la lista al portapapeles como texto que puede pegarse en una hoja de cálculo como Excel.

---

## Véase también

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — definición del cristal de referencia cuyos factores de estructura se calculan.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
