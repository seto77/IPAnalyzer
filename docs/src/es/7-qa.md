<!-- 261124Cl: Retranslated from en/7-qa.md (UI labels follow the localized GUI). -->

# Preguntas y respuestas (preguntas frecuentes)

Esta página reúne las preguntas planteadas con más frecuencia y los puntos que se malinterpretan con facilidad. Las etiquetas son los nombres que muestra la interfaz en español, y entre paréntesis se indica el nombre en inglés. Para preguntas que no se tratan aquí, o para informar de un error, utiliza [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Instalación e inicio

### Solo aparece la ventana de propiedades; no se ve la ventana principal

La ventana principal está situada fuera de la pantalla.

1. Pasa el ratón sobre el icono de IPAnalyzer en la barra de tareas, haz clic derecho en la miniatura, elige **Mover (Move)**, pulsa una vez una tecla de flecha y después mueve el ratón.
2. Si eso no funciona, cierra IPAnalyzer, abre el Editor del Registro (regedit), elimina `HKEY_CURRENT_USER\Software\Crystallography\IPAnalyzer` y vuelve a iniciar IPAnalyzer (toda la configuración vuelve a sus valores predeterminados).

### Tras actualizar, sigue ejecutándose la versión antigua / IPAnalyzer ya no se inicia

Vuelve a instalar directamente desde la [última versión](https://github.com/seto77/IPAnalyzer/releases/latest). Si la instalación no sobrescribe la versión antigua, o el programa no se inicia, desinstálalo una vez desde la Configuración de Windows y vuelve a instalarlo. Si una versión nueva tiene algún problema, puedes instalar una versión anterior desde la misma página de releases.

### Quiero usarlo en un PC sin derechos de administrador, o en Windows on Arm

- Sin derechos de administrador, usa la versión portable (`IPAnalyzer-v.<version>.zip`), que no necesita instalación e incluye el runtime de .NET.
- En Windows on Arm, usa el instalador arm64 (`IPAnalyzer-setup_arm64.msi`) o la versión portable (`IPAnalyzer-v.<version>_arm64.zip`).

Véase [Instalación en la Visión general](0-overview.md#instalación) para más detalles.

### Cargar muchos fotogramas provoca un error. ¿Cuánta memoria se necesita?

IPAnalyzer guarda la intensidad de cada píxel en doble precisión (8 bytes), sea cual sea la profundidad de bits original. Por ejemplo, 5000 imágenes de 1554×516 píxeles necesitan unos 32 GB solo para las intensidades. Trata los datos con muchos fotogramas en un PC con memoria suficiente, o procésalos por partes con una macro.

## Lectura de imágenes

### No se pueden leer los archivos de mi detector

Puede que el formato aún no esté admitido. Ponte en contacto a través de [Issues](https://github.com/seto77/IPAnalyzer/issues) o con el autor y envía un archivo real (preferiblemente uno con un patrón de difracción, no solo una imagen oscura). La corrección de las intensidades y la orientación de la imagen solo se pueden comprobar con una imagen que muestre un patrón.

!!! note "Cuando una imagen raw tiene una anchura y una altura incorrectas"
    En los archivos raw sin cabecera, el modelo de detector y el número de píxeles se deducen del tamaño del archivo. El número real de píxeles difiere a menudo del valor de catálogo, así que envía el archivo si la detección falla.

### Después de cargar un archivo de parámetros y abrir una imagen, los parámetros cambian

IPAnalyzer **recuerda parámetros como la longitud de cámara, la longitud de onda y el tamaño de píxel para cada formato de imagen** y cambia a esos valores al abrir una imagen. Por tanto, carga el archivo de parámetros (`.prm`) **después de abrir la imagen**. Los formatos con extensiones distintas se recuerdan por separado aunque su contenido sea el mismo.

### ¿Hay que voltear o rotar de nuevo cada imagen?

No. La configuración de **Opción (Option) → Voltear (Flip) / Rotar (Rotate)** también se recuerda por formato de imagen y se aplica automáticamente la próxima vez que se abre una imagen del mismo formato. El volteo y la rotación también afectan a la integración y al guardado de imagen (el archivo de origen no se modifica).

### ¿Cómo se tratan los archivos con varios fotogramas (`.his`, `.nxs`, TIFF multipágina, …)?

Al cargar un archivo de este tipo, se abre la ventana **Imagen secuencial (Sequential image)** y puedes seleccionar el fotograma que se muestra. Para integrarlos todos juntos, usa **Obtener perfiles de todas las imágenes secuenciales (Get Profiles for all sequential images)** u **Obtener perfiles de las imágenes seleccionadas (Get Profiles for selected images)** en el menú desplegable de **Obtener perfil (Get Profile)**. Véase [Herramientas](3-tools.md#imagen-secuencial-sequential-image) para más detalles.

## Calibración

### ¿Cuándo debo usar Buscar parámetro (geométricamente) y cuándo Buscar parámetro (fuerza bruta)?

| | Geométricamente | Fuerza bruta |
|---|---|---|
| Principio | Divide la imagen en sectores, busca las posiciones de los picos y determina el centro, la inclinación, etc. a partir de las formas elípticas y los centros de los anillos de Debye | Varía los parámetros paso a paso y busca la combinación con la que mejor coinciden las posiciones de pico calculadas y ajustadas |
| Datos adecuados | Anillos visibles casi en toda la vuelta (al menos en cinco direcciones) | Solo se registra parte de los anillos, punto directo fuera de la imagen, anillos con puntos (spotty) |
| Imágenes | Una, o dos tomadas a longitudes de cámara distintas | Una |
| Precaución | La precisión baja o el refinamiento no converge si los anillos no se ven en toda la vuelta | Necesita valores iniciales bastante buenos; lleva tiempo |

Véase [Procedimientos](4-procedures.md) y [Buscar parámetros (fuerza bruta)](6-find-parameter.md) para los pasos.

### ¿Qué muestra de referencia debo usar para la calibración?

Es adecuada una muestra que dé anillos de Debye lisos (sin puntos) a partir de granos finos, visibles en una vuelta lo más completa posible. Como orientación, unos cinco anillos o más. Con solo dos anillos completos es difícil una determinación precisa, y debe conocerse la longitud de onda o la longitud de cámara. Para la calibración por fuerza bruta, elige el material de referencia entre Au / CeO₂ / LaB₆ / Al₂O₃, o selecciona **Otro (Other)** e introduce las constantes de red.

### La calibración no converge / el centro se desplaza cada vez más

- Fija los valores en los que puedas confiar (tamaño de píxel de catálogo, longitud de onda conocida, etc.) y reduce el número de variables refinadas.
- Ajusta primero de forma aproximada con unos pocos anillos de ángulo bajo y añade después los anillos de ángulo alto.
- Un anillo cuyo análisis ha fallado puede perturbar todo el resultado. Si un anillo se separa de los demás en el gráfico de centros de anillo, elimínalo.
- Si el ajuste falla al incluir los anillos de ángulo alto, limita los picos a aquellos cuyos anillos aún se ven en toda la vuelta, amplía el intervalo de ajuste y usa menos sectores.
- Introduce valores iniciales lo más correctos posible antes de empezar.

### ¿Solo se pueden determinar la longitud de cámara y la longitud de onda si se fija una de ellas?

Con un material de referencia cuyas constantes de red se conozcan con exactitud, ambas se pueden determinar incluso a partir de una sola imagen (a partir de los cocientes de las posiciones de los anillos). Sin embargo, **la longitud de cámara y el tamaño de píxel no se pueden determinar juntos a partir de una sola imagen**. Confía en el tamaño de píxel de catálogo y fíjalo. Con dos imágenes cuya diferencia de longitud de cámara se conoce (método de doble casete), también se puede refinar el tamaño de píxel.

### El punto directo no está registrado / queda fuera de la imagen

Introduce a mano la posición del punto directo y desmarca **Buscar centro antes de obtener perfil (Find Center before Get Profile)** en el menú desplegable de **Obtener perfil (Get Profile)**. Si el punto queda fuera de la imagen, las coordenadas negativas son válidas. Usa la calibración por fuerza bruta para este tipo de datos.

### El centro obtenido con Buscar centro difiere en unos píxeles del centro calibrado

Se determinan de forma distinta. **Buscar centro (Find Center)** ajusta el punto directo cercano al centro actual con una función pseudo-Voigt bidimensional. La calibración no usa la intensidad del punto directo; obtiene el centro a partir de los centros de las elipses de varios anillos de Debye. Una vez determinada correctamente la inclinación, el centro calibrado se puede usar tal cual. Si el punto directo está saturado, muestra un círculo sobre un anillo de Debye con **Dibujar anillo (Draw ring)** y pulsa **Buscar centro**: el centro se determina entonces a partir del anillo.

### ¿Qué es la corrección esférica?

Una corrección para un detector curvado como una esfera. Introduce el inverso del radio de curvatura, 1/R (mm⁻¹). Usa 0 para un detector plano. Ayuda cuando los anillos de ángulo alto no coinciden, por ejemplo con un detector grande colocado cerca de la muestra.

### ¿Cómo convierto los valores de inclinación de otros programas (como PIP)?

(β, Φ) de PIP se convierte en (φ, τ) de IPAnalyzer = (270° − β, Φ). Véase la [Visión general](0-overview.md#relación-con-winpip) para las definiciones.

## Integración y salida

### El eje horizontal del resultado parece incorrecto / la intensidad parece casi constante

Comprueba si está seleccionada **Integración radial (Radial integration)** en la pestaña **Propiedad de integración (Integral Property)** de la ventana de propiedades. En este modo, el perfil tiene el azimut χ como eje horizontal. El perfil habitual 2θ–intensidad se obtiene con **Integración concéntrica (Concentric integration)**.

### Quiero guardar el perfil en un archivo sin PDIndexer

En la pestaña **Después de "Obtener perfil" (After "Get Profile")** de la ventana de propiedades, define en **Save File** el destino (la misma carpeta que la imagen / elegir cada vez) y el formato (PDI / CSV / TSV / GSAS). A partir de entonces, el perfil se guarda cada vez que integras.

### ¿Qué es la tercera columna del CSV?

El error de recuento de la intensidad, calculado a partir de la raíz cuadrada de la intensidad de píxel sumada en cada paso, tratada como cuentas. La intensidad de la segunda columna se convierte al equivalente de la geometría Bragg–Brentano, por lo que no es igual al cuadrado de la tercera columna. PDIndexer puede mostrarla como barras de error.

### Los valores de 2θ del CSV solo tienen dos decimales. ¿Es ese el límite de precisión?

No. Solo lo parece porque la integración se configuró, por ejemplo, con un inicio de 20.00° y un paso de 0.01°. El cálculo se hace en doble precisión. La precisión del resultado la determinan los errores de los parámetros de entrada, como la longitud de cámara y la longitud de onda.

### Para imágenes secuenciales, ¿debo usar Promedio o Suma?

La relación S/N es la misma en ambos casos. **Suma (Summation)** da una estimación correcta de los errores, por lo que se recomienda para los análisis que usan los errores, como el refinamiento de Rietveld.

### Quiero integrar para cada azimut (cada sector)

Activa **Análisis de división azimutal (Azimuthal Division Analysis)** en el menú desplegable de **Obtener perfil (Get Profile)**, define **Número de divisiones (Number of divisions)** e integra. Se crean un perfil completo (con nombre terminado en `-whole`) y un perfil por sector (con el ángulo inicial añadido, como `-000`, `-010`, …). Con demasiadas divisiones, los datos enviados a PDIndexer pueden resultar demasiado grandes.

### Quiero un mapa bidimensional de 2θ y el azimut χ (imagen desplegada)

Usa **Desplegar imagen (Unroll image)** de la barra de herramientas. Define el intervalo y el paso en la pestaña **Opciones de imagen desplegada (Unrolled Image Option)** de la ventana de propiedades. Con **Archivo (File) → Guardar imagen (Save image)**, TIFF conserva los valores de coma flotante calculados y PNG guarda lo que se muestra en pantalla.

### Quiero la suma o la media de la intensidad de una parte rectangular de la imagen

Selecciona un rectángulo con Ctrl + arrastrar con el botón derecho sobre la imagen. Las estadísticas aparecen en la pestaña **Información estadística (Statistical Information)** de la parte inferior. Para imágenes secuenciales, se puede comparar la misma región entre fotogramas.

### Una imagen oscura se vuelve más brillante hacia los bordes de ángulo alto

Si **Corregir polarización lineal (Correct linear polarization)** está activada en **Fuente de ondas (Wave source)** de la ventana de propiedades, la corrección también se aplica a las señales que no proceden de los rayos X (corriente oscura, ruido electrónico), y el lado de ángulo alto se vuelve más brillante. Desactívala para las imágenes oscuras.

### Quiero restar una imagen oscura (de fondo)

En la pestaña **Opciones de fondo (Background Option)** de la ventana de propiedades, registra la imagen actual como fondo y define el coeficiente. A partir de entonces se resta automáticamente de las imágenes del mismo tamaño. Véase [Ventanas de propiedades](2-property-windows.md) para más detalles.

## Procesamiento por lotes y macros

### Quiero integrar muchos archivos a la vez

**Obtener perfiles de todas las imágenes secuenciales (Get Profiles for all sequential images)** sirve para varios fotogramas contenidos en un único archivo. Para procesar varios archivos, usa una [macro](5-macro/index.md). Los [ejemplos](5-macro/2-examples.md) incluyen uno que integra en orden los archivos seleccionados y guarda archivos CSV. Antes de ejecutarlo, abre una imagen y carga el archivo de parámetros (véase [la memoria de parámetros](#después-de-cargar-un-archivo-de-parámetros-y-abrir-una-imagen-los-parámetros-cambian)).

### Quiero invocar desde el menú una macro que uso a menudo

Da un nombre a la macro y añádela en el editor de macros; así se puede invocar desde el menú **Macro** de la ventana principal.

### Quiero integrar las imágenes a medida que llegan durante una medición

Supervisa la carpeta con el [Procedimiento automático](3-tools.md#procedimiento-automático-auto-procedure). Los archivos que aún se están escribiendo se leen cuando termina la escritura. Si la lectura falla en una carpeta de red, guarda en el disco local del PC de medición y supervisa esa carpeta.

## Informar de un error

### ¿Qué debo enviar con un informe de error?

A menudo el problema no se puede reproducir en el entorno del autor, así que adjunta:

- el archivo de parámetros de ese momento (**Archivo (File) → Guardar parámetro (Save parameter)**),
- el archivo de imagen con el que se produjo el problema, y
- el mensaje de error (basta con una captura de pantalla) y la versión de IPAnalyzer.

Informa a través de [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues).

## Malentendidos frecuentes

| Suposición | En realidad |
|---|---|
| Se carga primero el archivo de parámetros y después se abre la imagen | Al abrir una imagen se cambia a los valores recordados para su formato. Abre primero la imagen y después carga el archivo de parámetros |
| **Obtener perfiles de todas las imágenes secuenciales (Get Profiles for all sequential images)** procesa varios archivos a la vez | Sirve para varios fotogramas de un único archivo. Usa una macro para varios archivos |
| Se necesita PDIndexer para guardar un perfil | IPAnalyzer puede guardar en un archivo por sí solo (pestaña Después de "Obtener perfil" (After "Get Profile")) |
| La tercera columna del CSV es otro perfil | Es el error de recuento de la intensidad |
| Suma (Summation) mejora la S/N | La S/N es la misma que con Promedio (Average); solo cambia la estimación del error |
| La longitud de cámara y el tamaño de píxel se pueden determinar ambos a partir de una imagen | No juntos a partir de una imagen; fija el tamaño de píxel en su valor de catálogo |
| El volteo y la rotación solo cambian la visualización | También afectan a la integración y al guardado de imagen |
| Al enviar a PDIndexer se aplica al perfil una corrección de Lorentz-polarización | PDIndexer considera la polarización solo para las intensidades de las líneas de difracción calculadas; el perfil en sí no se modifica |
