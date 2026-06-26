<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Ventanas de propiedades

La ventana de propiedades es donde se configuran la fuente, las condiciones del detector y las distintas condiciones de unidimensionalización. Cada pestaña también puede abrirse directamente desde el menú **Property** de la ventana principal.

La interfaz de esta ventana está en inglés. Los encabezados que siguen utilizan los nombres reales de las pestañas y los controles.

## Wave source

Establece el tipo de haz incidente y la longitud de onda. La fuente puede ser de rayos X, electrones o neutrones. Para rayos X, al seleccionar un elemento y una transición (línea K, línea L, etc.) la longitud de onda se completa automáticamente; para radiación de sincrotrón, introduzca la longitud de onda directamente. Para haces de electrones y neutrones, introduzca la energía o la longitud de onda (la longitud de onda del electrón se corrige relativísticamente).

- **Correct linear polarization**: corrige una intensidad polarizada linealmente a su equivalente no polarizado (para datos de sincrotrón). La fórmula de corrección que sigue depende del azimut χ (definido en la pestaña Miscellaneous) y del ángulo de dispersión 2θ.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

Establece las condiciones geométricas del detector. Corresponde a la antigua "IP Condition", con la adición de selectores de sistema de coordenadas y de forma del detector.

- **Coordinates**: **Direct spot** (referencia al punto directo) / **Foot** (referencia al pie de la perpendicular).
- **Detector type**: **Flat panel** / **Gandolfi**.
- **Direct spot position** y **Camera Length 1**: la posición del punto directo (X, Y pix) y la distancia desde la muestra hasta el punto directo (mm).
- **Foot position** y **Camera Length 2**: en el modo Foot, la posición del pie de la perpendicular y la distancia desde la muestra hasta el pie.
- **Pixel Shape**: tamaño de píxel X, Y (mm) y ξ (Ksi, el ángulo de inclinación del paralelogramo).
- **Gandolfi Radius**: el radio, cuando se selecciona la forma Gandolfi.
- **Spherical correction**: corrección esférica (normalmente cero).
- **Tilt**: la inclinación del IP φ (Phi) y τ (Tau).

Consulte [Overview](0-overview.md) para conocer las definiciones de la inclinación φ, τ y del píxel ξ.

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

Especifica la región de la imagen que se va a unidimensionalizar.

- **Rectangle**: elija la **Direction** (Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free) y establezca el **Band Width**, el **Angle** (en el modo Free) y **Both Side**.
- **Sector**: especifique el rango angular con **Start Angle** / **End Angle**.
- **Exceptional pixels**: excluya **Masked Spots**, los píxeles **Under intensity of** / **Over intensity of** los umbrales dados, y un número de **pixels from edges**.

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

Establece el método de integración y el paso.

- **Concentric integration (scattering-angle dispersive)**: elija la unidad del eje horizontal entre **Angle** (2θ, °) / **Length** (mm) / **d-spacing** (Å) y establezca **Start / End / Step**. El **Output pattern** puede ser **Bragg - Brentano** o **Debye - Scherrer**.
- **Radial integration (cake pattern)**: analiza una región anular en la dirección azimutal. Elija el eje horizontal entre **Angle** / **d-spacing** y establezca el **Donut radius** (radio central), el **Donut width** (anchura del anillo) y el **Sector angle step** (paso de barrido).

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

Establece las condiciones para el enmascaramiento y para la detección del centro y de los puntos (una ampliación de la antigua "Find Center & Spots").

- **Half mask**: botones que enmascaran rápidamente la mitad superior, inferior, izquierda o derecha de la imagen.
- **Manual mask mode**: habilita el enmascaramiento interactivo sobre la imagen principal. Las formas son **Circle** (arrastre para fijar el centro y el radio), **Polygon** (haga clic para añadir vértices), **Rectangle** (arrastre los vértices diagonales), **Spline curve** y **Spot** (clic izquierdo/derecho para añadir/eliminar puntos).
- **Takeover**: cómo se trata la máscara al cargar una nueva imagen (**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation**: el umbral estadístico para la detección de puntos.
- **Find Center**: el rango de búsqueda para la detección del centro, etc.

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

Establece el guardado y el envío después de la unidimensionalización.

- **Save File**: elija el destino ("el mismo directorio que la imagen" o "un directorio elegido cada vez") y el formato entre **PDI** / **CSV** / **TSV** / **GSAS**.
- **Send PDIndexer**: envía el perfil, a través del portapapeles, a una instancia en ejecución de PDIndexer.

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

Establece los parámetros de la imagen desenrollada (Unroll).

- **Horizontal**: la unidad (Angle / Length / d-spacing) y **Start / End / Step**. La anchura de la imagen de salida ≈ (End − Start) / Step.
- **Vertical**: el paso azimutal (°/pixel). La altura de la imagen de salida ≈ 360 / step.

El desenrollado mapea la imagen polar de difracción centrada en el punto directo a una imagen cartesiana (ángulo frente a distancia).

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

Una pestaña que reúne los ajustes más finos de visualización y de coordenadas.

- **Image name display**: solo el nombre de archivo / carpeta principal + nombre de archivo / ruta completa.
- **Contrast / intensity-range persistence**: si los ajustes de visualización se conservan al cargar una nueva imagen.
- **Azimuth χ (Chi) orientation**: la posición de referencia (Top / Bottom / Left / Right) y el sentido de rotación (Clockwise / Counterclockwise). χ es referenciado por la corrección de polarización y por la integración radial.
- **Scale line**: color, anchura, número de divisiones y visualización de etiquetas.
- **Find Center**: rango de búsqueda, rango de ajuste de pico, fijar el centro y excluir los píxeles enmascarados.

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

Establece la corrección mediante una imagen de fondo.

- **Background image**: establece la imagen actualmente mostrada como fondo (**Set the current image as background**) o la borra (**Clear**).
- **Coefficient**: el factor aplicado a la imagen de fondo.
- **Edge mask**: un margen de máscara adicional (px) aplicado en los bordes durante la corrección.

Se utiliza para la corrección de campo plano, la eliminación de la dispersión por el aire y similares.

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
