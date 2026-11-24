<!-- 261124Cl: Retranslated from en/3-tools.md (UI labels follow the localized GUI). -->

# Herramientas

Esta página describe las herramientas auxiliares que se inician desde la barra de herramientas vertical situada a la derecha de la ventana principal, o desde los menús. Para procedimientos concretos con calibración de parámetros y macros, véase [Procedimientos](4-procedures.md).

## Calibrar imagen R-AXIS (Calibrate Raxis Image)

Ábrela con **Herramienta (Tool) → Calibrar imagen R-AXIS (Calibrate Raxis Image)**. Especifica dos imágenes R-AXIS IV `.stl` del mismo tamaño; la herramienta optimiza una tabla de conversión de intensidad para que las dos intensidades coincidan. La tabla se representa mediante puntos de control, y la suma de sus elementos se mantiene constante durante la optimización. El resultado se muestra como un gráfico. Se usa, por ejemplo, para calibrar la respuesta en intensidad de un detector.

El botón **Tabla de intensidad (Intensity table)** de la barra de herramientas no tiene ninguna función asignada en la versión actual.

![Calibrar imagen R-AXIS (Calibrate Raxis Image)](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Procedimiento automático (Auto procedure)

Una herramienta que supervisa una carpeta, carga automáticamente las imágenes nuevas y ejecuta una secuencia de operaciones tras la carga.

- **Watch and auto-load** (supervisión y carga automática): supervisa la carpeta indicada (incluidas las subcarpetas) y lee cada archivo cuando termina de escribirse. Los archivos se pueden filtrar por nombre (coincidencia numérica, palabra clave).
- **Auto execution** (ejecución automática): ejecuta en orden los pasos marcados de entre Contraste automático → Buscar centro → Enmascarar puntos → Obtener perfil → Execute Macro (Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro).

Esto permite usos como supervisar una carpeta de salida durante un experimento e integrar automáticamente cada imagen a medida que llega. Véase [Procedimientos](4-procedures.md) para más detalles.

![Procedimiento automático (Auto Procedure)](../assets/cap-en-auto/FormAutoProcedure.png)

## Dibujar anillo (Draw Ring)

Dibuja un anillo a una distancia, un ángulo o un valor d especificados sobre la imagen, teniendo en cuenta la inclinación de la IP y la distorsión del píxel. Haz clic en **R (mm)** / **2θ (°)** / **d (Å)** para elegir qué valor editar; los demás se calculan automáticamente a partir de la longitud de onda y la longitud de cámara.

![Dibujar anillo (Draw Ring)](../assets/cap-en-auto/FormDrawRing.png)

## Desplegar (Unroll)

Despliega la imagen de difracción desde coordenadas polares centradas en el punto directo a coordenadas cartesianas (eje horizontal = ángulo de dispersión 2θ; eje vertical = azimut). Actualmente no se configura con una ventana propia, sino con el botón **Desplegar imagen (Unroll image)** de la barra de herramientas y la pestaña **Opciones de imagen desplegada (Unrolled Image Option)** de las propiedades. El despliegue usa el mismo algoritmo de distribución de intensidad subpíxel que la conversión a una dimensión.

## Desenfoque circunferencial (Circumferential Blur)

Una herramienta que difumina el patrón de anillos en la dirección circunferencial (azimutal). Especifica un único ángulo de desenfoque y aplícalo.

![Desenfoque circunferencial (Circumferential Blur)](../assets/cap-en-auto/FormBlurAngle.png)

## Imagen secuencial (Sequential Image)

Una herramienta para manejar imágenes multifotograma (NeXus (`.nxs`), TIFF multipágina y similares; series temporales, series de temperatura, barridos de energía en sincrotrón).

- Selecciona un único fotograma de la lista de fotogramas para mostrarlo, o recórrelos con la barra deslizante.
- Con **Selección múltiple (Multi selection)**, selecciona varios fotogramas y calcula su **Promedio (Average)** o **Suma (Summation)**.
- El objetivo de la conversión a una dimensión se puede elegir entre "todas las imágenes / imágenes seleccionadas / solo la imagen superior" ("Todas las imágenes sin importar las selecciones actuales" (All images irrespective of current selections) / "La(s) imagen(es) seleccionada(s)" (The selected image(s)) / "Solo la imagen superior" (Only the topmost image)).
- Si un fotograma contiene información de energía, la longitud de onda se actualiza al seleccionar ese único fotograma.

![Imagen secuencial (Sequential Image)](../assets/cap-en-auto/FormSequentialImage.png)

## Guardar imagen (formato IPA) (Save Image (IPA format))

Corrige la inclinación de la IP φ, τ y la distorsión del píxel ξ, y guarda la imagen con píxeles cuadrados a una resolución especificada. También se escriben metadatos como la longitud de cámara, la longitud de onda y la posición del centro, de modo que la imagen se puede pasar a otros procesamientos de imagen conservando la información geométrica.

![Guardar imagen (Save Image)](../assets/cap-en-auto/FormSaveImage.png)

## Buscar parámetro (geométricamente) (Find Parameter (Geometric))

Una herramienta que optimiza la longitud de onda, la longitud de cámara, el tamaño de píxel, la distorsión del píxel y la inclinación (φ, τ) a partir de los anillos de difracción de un material de referencia. Usa una imagen de una muestra de referencia (**Primario (Primary)**), o dos imágenes tomadas a longitudes de cámara distintas (**Primario (Primary)** y **Secundario (Secondary)**); se seleccionan los picos y se optimiza con **¡Refinar! (Refine!)**. La convergencia (centro de la elipse, residuos) se puede comprobar en los gráficos. Véase [Procedimientos](4-procedures.md) para los pasos concretos.

![Buscar parámetro (geométricamente) (Find Parameter (Geometric))](../assets/cap-en-auto/FormFindParameter.png)

## Buscar parámetro (fuerza bruta) (Find Parameter (Brute force))

Una herramienta que determina la longitud de cámara, la posición del centro, la inclinación (φ, τ) y, opcionalmente, la longitud de onda (desactivada por defecto) mediante una búsqueda exhaustiva en cuadrícula en lugar de un método de gradiente. Usa la única imagen de una muestra de referencia cargada en la ventana principal. Es eficaz cuando la optimización geométrica tiene dificultades para converger, como con anillos incompletos o datos ruidosos. Elige el material de referencia entre Au / CeO₂ / LaB₆ / Al₂O₃, o selecciona **Otro (Other)** e introduce el cristal. Véase [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para los pasos detallados, y [Procedimientos](4-procedures.md) para el flujo de trabajo.

![Buscar parámetro (fuerza bruta) (Find Parameter (Brute force))](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Una función que automatiza operaciones con scripts de estilo Python. Abre el editor de macros desde el menú **Macro → Editor** de la ventana principal.

- Están disponibles `for` / `if` / `while` / `def` / `class`, la aritmética y el módulo `math`.
- APIs como `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` permiten invocar cada operación.
- Activa **Mostrar ejemplos (Show samples)** para ver las macros de ejemplo de solo lectura (bucles básicos, configuración de la geometría, procesamiento por lotes, división azimutal, enmascaramiento, envío a PDIndexer, etc.). Puedes inspeccionar las variables con la ejecución paso a paso.

Véase [Macro](5-macro/index.md) para la referencia completa de funciones y los ejemplos, y [Procedimientos](4-procedures.md) para los flujos de trabajo basados en macros.

![Editor de macros](../assets/cap-en-auto/FormMacro.png)
