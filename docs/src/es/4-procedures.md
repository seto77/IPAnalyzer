<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# Procedimientos

Esta página muestra el flujo de las tareas típicas. Para descripciones de las herramientas individuales, consulte [Herramientas](3-tools.md).

## Flujo básico (integración concéntrica)

1. **Cargar una imagen**: File → Read image (o arrastrar y soltar).
2. **Establecer la fuente**: configure el elemento/transición o la longitud de onda en **Wave source** dentro de las propiedades.
3. **Establecer la condición del detector**: configure la longitud de cámara, el tamaño de píxel, la posición del centro (aproximada) y, si es necesario, la inclinación φ, τ en **Detector condition**.
4. **Buscar el centro**: detecte el centro del haz automáticamente con **Find Center** en la barra de herramientas (el rango de búsqueda se configura en Miscellaneous).
5. **Enmascarar puntos**: elimine las reflexiones de monocristal y similares con **Mask Spots**. Si es necesario, enmascare manualmente con **Manual**.
6. **Unidimensionalizar**: obtenga el perfil con **Get Profile**. El guardado y el envío se configuran en la pestaña **After "Get Profile"** (guardado en CSV, envío a PDIndexer, etc.).

Para imágenes secuenciales, seleccione un fotograma en [Sequential](3-tools.md) antes de los pasos 5–6. Para el análisis por azimut, utilice Radial integration en **Integral Property**.

## Determinación de parámetros: calibración geométrica con una muestra de referencia (doble casete)

Cuando la longitud de cámara o la longitud de onda son desconocidas, optimice los parámetros geométricos a partir de los anillos de difracción de un material de referencia (CeO2 por defecto, etc.), usando [Find Parameter (Geometric)](3-tools.md).

1. Cargue la **Primary image** (muestra de referencia, a una longitud de cámara) con Open, busque el centro y muestre los picos con **Get Profile**.
2. Al arrastrar un marcador de línea de difracción en la Profile View, la estimación de la longitud de cámara se actualiza automáticamente.
3. Cargue la **Secondary image** (la misma muestra de referencia, a una longitud de cámara diferente) de la misma manera, e introduzca la **camera-length difference** relativa a Primary.
4. En la **Peak List**, seleccione los valores d de los picos que aparecen en ambas imágenes (al menos uno por imagen, idealmente tres o más).
5. En **Refinement Option**, elija los parámetros a optimizar (longitud de onda, distancia de la película, inclinación, tamaño de píxel, distorsión de píxel).
6. Ejecute **Refine!** y, una vez que el residual se estabilice, copie los resultados optimizados de vuelta al formulario principal.

!!! note
    Usar dos imágenes (un "doble casete") facilita determinar por separado la longitud de cámara y la longitud de onda.

## Determinación de parámetros: optimización por fuerza bruta (muestra arbitraria)

Cuando la optimización geométrica tiene dificultades para converger, busque la longitud de cámara y la longitud de onda de forma exhaustiva con [Find Parameter (Brute force)](3-tools.md). Consulte [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para un recorrido detallado con capturas de pantalla.

1. Cargue las imágenes Primary y Secondary (dos imágenes, con anillos en común, a longitudes de cámara diferentes).
2. Alinee de forma aproximada la posición del centro en el formulario principal (Find Center ayuda).
3. Introduzca los **search ranges (min, max, step)** para la longitud de cámara, la longitud de onda, etc. Deje desactivados al principio los parámetros desconocidos (tamaño de píxel, inclinación).
4. Establecer **Integral Region** en un modo de ranura (Rectangle) con un ancho de banda estrecho ayuda a suprimir el ruido.
5. Inicie la búsqueda y copie la combinación con el residual más pequeño de vuelta al formulario principal.

## Procesamiento automatizado (Auto Procedure)

Procese automáticamente las imágenes que llegan a una carpeta, por ejemplo durante un experimento. Consulte [Herramientas](3-tools.md) para más detalles.

1. Active **Automatically load new images** y elija la carpeta a supervisar con **Set**.
2. Si es necesario, filtre los archivos por **number matching** (el número al final del nombre del archivo) o por **keyword**.
3. Active **After Loading Image, Execute "Auto"** y elija de la lista: Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro.
4. Una vez que comienza la supervisión, la secuencia se ejecuta automáticamente cada vez que llega una imagen coincidente.

## Procedimientos por script (macros basadas en Python)

El procesamiento con bucles y condicionales se puede escribir como una [macro](5-macro/index.md). Las macros de ejemplo incluidas son un buen punto de partida.

- Cargar una imagen, establecer la fuente y el detector (centro, longitud de cámara, píxeles) y ajustar la visualización.
- Establecer las condiciones de la integración concéntrica (inicio, fin, paso, unidad), unidimensionalizar y guardar como CSV.
- Procesar por lotes varios archivos, guardando un CSV junto a cada imagen.
- Procesar una imagen multifotograma fotograma a fotograma.
- Dividir un anillo de Debye en N sectores y analizar la dependencia azimutal.
- Enmascarar (limpiar todo → enmascarar puntos → enmascarar la región del beam-stop → guardar la máscara) y unidimensionalizar.
- Generar azimut vs. intensidad con integración radial (cake).
- Activar el envío al portapapeles, unidimensionalizar y llamar a una macro con nombre en PDIndexer (p. ej., ajuste de picos).

Las macros que escriba se pueden guardar, llamar por nombre y también ejecutar desde Auto Procedure.
