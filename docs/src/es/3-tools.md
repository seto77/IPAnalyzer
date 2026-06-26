<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Herramientas

Esta página describe las herramientas auxiliares que se abren desde la barra de herramientas vertical a la derecha de la ventana principal, o desde los menús. Para procedimientos concretos que usan la calibración de parámetros y las macros, consulte [Procedimientos](4-procedures.md).

## Intensity Table

Una herramienta que compara las distribuciones de intensidad de dos imágenes y optimiza una tabla de conversión de intensidad. Optimiza 16 puntos de control a lo largo de 300 iteraciones para igualar ambas intensidades preservando la intensidad integrada total. Se utiliza, por ejemplo, para calibrar la respuesta de intensidad de un detector.

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

Una herramienta que supervisa una carpeta, carga imágenes nuevas automáticamente y ejecuta una secuencia de operaciones tras la carga.

- **Watch and auto-load**: supervisa la carpeta especificada (incluidas las subcarpetas) y lee un archivo una vez que su escritura ha finalizado. Los archivos se pueden filtrar por nombre (coincidencia numérica, palabra clave).
- **Auto execution**: ejecuta los pasos marcados, en orden, entre Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro.

Esto permite usos como supervisar una carpeta de salida durante un experimento e integrar automáticamente cada imagen a medida que llega. Consulte [Procedimientos](4-procedures.md) para más detalles.

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

Dibuja un anillo a una distancia, ángulo o valor d especificados sobre la imagen, teniendo en cuenta la inclinación de la IP y la distorsión de píxel. Haga clic en uno de **R (mm)** / **2θ (°)** / **d (Å)** para elegir qué valor editar; los demás se calculan automáticamente a partir de la longitud de onda y la longitud de cámara.

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

Despliega la imagen de difracción desde coordenadas polares centradas en el punto directo (direct spot) hacia coordenadas cartesianas (eje horizontal = ángulo, distancia o valor d; eje vertical = azimut). Ahora se configura no mediante una ventana dedicada, sino con el botón **Unroll** de la barra de herramientas y la pestaña **Unrolled Image Option** de las propiedades. El desenrollado utiliza el mismo algoritmo de distribución de intensidad a nivel de subpíxel que la unidimensionalización.

## Circumferential Blur

Una herramienta que difumina el patrón de anillos a lo largo de la dirección circunferencial (azimutal). Especifique un único ángulo de desenfoque y aplíquelo.

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

Una herramienta para manejar imágenes multifotograma (HDF5 y similares; series temporales, series de temperatura, barridos de energía de sincrotrón).

- Seleccione un único fotograma de la lista de fotogramas para mostrarlo, o recórralos con la barra de desplazamiento.
- Con **multi-selección**, seleccione varios fotogramas y calcule su **promedio** o **suma**.
- El objetivo de la unidimensionalización se puede elegir entre "todos los fotogramas / fotogramas seleccionados / solo el superior".
- Si cada fotograma incluye información de energía, la longitud de onda se actualiza automáticamente.

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

Corrige la inclinación φ, τ de la IP y la distorsión de píxel ξ, y guarda la imagen con píxeles cuadrados a una resolución especificada. También se escriben metadatos como la longitud de cámara, la longitud de onda y la posición del centro, de modo que la imagen se puede pasar a otro procesamiento de imágenes conservando la información geométrica.

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

Una herramienta que optimiza la longitud de onda, la longitud de cámara, el tamaño de píxel, la distorsión de píxel y la inclinación (φ, τ) a partir de los anillos de difracción de un material de referencia. Utiliza dos patrones, Primary y Secondary, y usted selecciona los picos y optimiza con **Refine!**. La convergencia (centro de la elipse, residuos) se puede comprobar en las gráficas. Consulte [Procedimientos](4-procedures.md) para los pasos concretos.

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

Una herramienta que halla la longitud de cámara y la longitud de onda mediante una búsqueda exhaustiva en cuadrícula en lugar de un método de gradiente. Resulta eficaz cuando la optimización geométrica tiene dificultades para converger, como con anillos incompletos o datos ruidosos. El CrystalControl se utiliza para introducir los parámetros del cristal. Consulte [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para los pasos detallados, y [Procedimientos](4-procedures.md) para el flujo de trabajo.

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

Una función que automatiza operaciones con scripts de tipo Python. Abra el editor de macros desde el menú **Macro → Editor** en la ventana principal.

- Están disponibles `for` / `if` / `while` / `def` / `class`, la aritmética y el módulo `math`.
- APIs como `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` le permiten invocar cada operación.
- Se incluyen macros de ejemplo (bucles básicos, configuración de la geometría, procesamiento por lotes, división azimutal, enmascaramiento, envío a PDIndexer, etc.), y puede inspeccionar las variables con la ejecución paso a paso.

Consulte [Macro](5-macro/index.md) para la referencia completa de funciones y ejemplos, y [Procedimientos](4-procedures.md) para los flujos de trabajo basados en macros.

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

Una herramienta destinada a la corrección de intensidad específica de los detectores R-Axis; en la actualidad solo lee el archivo, y la corrección en sí aún no está implementada.

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
