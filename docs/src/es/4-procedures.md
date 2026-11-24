<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Procedimientos

Esta página muestra el flujo de las tareas típicas. Para la descripción de cada herramienta, véase [Herramientas](3-tools.md).

## Flujo básico (integración concéntrica)

1. **Cargar una imagen**: **Archivo (File) → Leer imagen (Read image)** (o arrastrar y soltar).
2. **Configurar la fuente**: define el elemento/transición o la longitud de onda en **Fuente de ondas (Wave source)** de las propiedades.
3. **Configurar la condición del detector**: define la longitud de cámara, el tamaño de píxel, la posición del centro (aproximada) y, si es necesario, la inclinación φ, τ en **Condición del detector (Detector condition)**.
4. **Buscar el centro**: detecta automáticamente el centro del haz con **Buscar centro (Find Center)** de la barra de herramientas (el intervalo de búsqueda se define en la pestaña Varios (Miscellaneous)).
5. **Enmascarar puntos**: elimina las reflexiones de monocristal y similares con **Enmascarar puntos (Mask Spots)**. Si es necesario, enmascara manualmente con **Modo manual (Manual Mode)**.
6. **Comprobar la configuración de integración**: selecciona la región objetivo en **Región de integración (Integral Region)** y elige **Integración concéntrica (dispersiva en ángulo de dispersión) (Concentric integration (scattering angle dispersive))** con la unidad del eje y **Inicio / Fin / Paso (Start / End / Step)** en **Propiedad de integración (Integral Property)**.
7. **Integrar la imagen**: obtén el perfil con **Obtener perfil (Get Profile)**. El guardado y el envío se configuran en la pestaña **Después de "Obtener perfil" (After "Get Profile")** (guardado en CSV, envío a PDIndexer, etc.).

Para imágenes secuenciales, selecciona un fotograma en [Imagen secuencial](3-tools.md) antes de los pasos 5–7. Para un análisis por azimut, usa **Análisis de división azimutal (Azimuthal Division Analysis)** en el menú desplegable de **Obtener perfil** (los anillos se dividen en sectores y cada sector se integra; solo disponible con integración concéntrica y el eje **Ángulo (Angle)** (2θ)), o **Integración radial (patrón de pastel) (Radial integration (cake pattern))** en **Propiedad de integración** (un perfil azimut–intensidad).

Si la longitud de cámara, la longitud de onda o la inclinación son desconocidas, calíbralas primero a partir de una imagen de una muestra de referencia como se describe en la sección siguiente, aplica los valores y después integra las imágenes de la muestra.

## Determinación de parámetros: calibración geométrica con una muestra de referencia (doble casete)

Cuando la longitud de cámara o la longitud de onda son desconocidas, optimiza los parámetros geométricos a partir de los anillos de difracción de un material de referencia (CeO2 por defecto, etc.), usando [Buscar parámetro (geométricamente)](3-tools.md).

1. Carga la **Imagen primaria (Primary image)** (muestra de referencia, a una longitud de cámara) con **Abrir (Open)**, busca el centro y muestra los picos con **Obtener perfil (Get Profile)**.
2. Al arrastrar un marcador de línea de difracción en la vista de perfil (Profile View), la estimación de la longitud de cámara se actualiza automáticamente.
3. Carga de la misma manera la **Imagen secundaria (Secondary image)** (la misma muestra de referencia, a otra longitud de cámara) e introduce la diferencia de longitudes de cámara (**camera-length difference**) \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm) (p. ej., +20 si la primaria está a 100 mm y la secundaria a 120 mm). La imagen secundaria es opcional; la calibración también funciona solo con la imagen primaria.
4. En la **Lista de picos (Peak List)**, selecciona los valores d de los picos que aparecen en ambas imágenes (normalmente tres o más por imagen; con dos imágenes, al menos uno debe ser común a ambas. Salvo que solo se refine la longitud de cámara, **¡Refinar! (Refine!)** no hace nada con menos de tres).
5. Elige los parámetros que se van a optimizar (**Longitud de onda (Wave Length)**, **Longitud de cámara (Camera Length)**, **Corrección de inclinación (Tilt Correction)**, **Tamaño de píxel (Pixel Size)**, **Distorsión de píxel (Pixel Distortion)**, **Posición del centro (Center Position)**, **Corrección esférica (Spherical Correction)**).
6. Ejecuta **¡Refinar!**. Se detiene automáticamente tras el número de repeticiones definido (12 por defecto). Después de comprobar el resultado, cópialo al formulario principal con **Parámetros refinados => Formulario principal (Refined parameters => Main form)**.

!!! note
    Usar dos imágenes (un "doble casete") facilita determinar por separado la longitud de cámara y la longitud de onda.

## Determinación de parámetros: optimización por fuerza bruta (muestra de referencia)

Cuando la optimización geométrica tiene dificultades para converger, busca de forma exhaustiva la longitud de cámara, la posición del centro, la inclinación y, opcionalmente, la longitud de onda con [Buscar parámetro (fuerza bruta)](3-tools.md). Véase [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para un recorrido detallado con capturas de pantalla.

1. Carga una imagen de una muestra de referencia en el formulario principal, abre **Buscar parámetro (fuerza bruta) (Find parameter (brute force))** y selecciona el material de referencia correspondiente.
2. Alinea aproximadamente la posición del centro en el formulario principal (**Buscar centro (Find Center)** ayuda).
3. Elige los elementos que se van a optimizar e introduce la anchura de paso **Paso inicial (Initial step)** (centrada en el valor actual) y el número de pasos a cada lado (**Intervalo de búsqueda (Search range)**). Para un detector plano, el tamaño de píxel no es un objetivo de búsqueda. Véase [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para ejemplos numéricos.
4. Configurar **Región de integración (Integral Region)** en un modo de rendija (**Rectángulo (Rectangle)**) con un ancho de banda estrecho ayuda a suprimir el ruido.
5. Inicia la búsqueda con **Optimizar (Optimize)**. En cada ciclo se adopta la combinación con el menor valor de evaluación R, que se escribe automáticamente en los parámetros del formulario principal.

## Procesamiento automatizado (Procedimiento automático)

Procesa automáticamente las imágenes que llegan a una carpeta, por ejemplo durante un experimento. Véase [Herramientas](3-tools.md) para más detalles.

1. Elige la carpeta que se va a supervisar con **Definir (Set)**.
2. Si es necesario, filtra los archivos por **Coincidencia de patrones (Pattern matching)** (el número al final del nombre de archivo) o por **Palabra clave (Keyword)**.
3. Activa **Una vez cargada la imagen nueva, ejecutar la siguiente secuencia (Once the new image is loaded, perform the following sequence)** y elige en la lista: **Auto contrast** / **Find center** / **Mask spots** / **Get profile** / **Execute macro**.
4. Por último, activa **Cargar imágenes nuevas automáticamente (Automatically load new images)** para empezar a supervisar (no se puede activar sin una carpeta; se usan las condiciones de número/palabra clave vigentes al empezar la supervisión). A partir de ahí, la secuencia se ejecuta automáticamente cada vez que llega una imagen que cumple las condiciones. Un archivo que sigue bloqueado tras esperar a que termine la escritura (unos 50 s) se vuelve a intentar en exploraciones posteriores y se abandona 10 minutos después de detectarse por primera vez.

## Procedimientos mediante scripts (macros basadas en Python)

El procesamiento con bucles y condicionales se puede escribir como una [macro](5-macro/index.md). Las macros de ejemplo que se muestran con **Mostrar ejemplos (Show samples)** en el editor de macros son un buen punto de partida.

- Cargar una imagen, configurar la fuente y el detector (centro, longitud de cámara, píxeles) y ajustar la visualización.
- Configurar las condiciones de integración concéntrica (inicio, fin, paso, unidad), integrar y guardar como CSV.
- Procesar por lotes varios archivos, guardando un CSV junto a cada imagen.
- Procesar una imagen multifotograma fotograma a fotograma.
- Dividir un anillo de Debye en N sectores y analizar la dependencia azimutal.
- Enmascarar (borrar todo → enmascarar puntos → enmascarar la región del beam stop → guardar la máscara) e integrar.
- Obtener azimut frente a intensidad con la integración radial (cake).
- Habilitar el envío al portapapeles, integrar e invocar una macro con nombre en PDIndexer (p. ej., ajuste de picos).

Las macros que escribas se pueden guardar, invocar por su nombre y ejecutar también desde el Procedimiento automático (Auto Procedure).
