<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# Ventana principal

La ventana principal es la primera pantalla que se muestra al iniciar IPAnalyzer. Reúne la visualización de la imagen de difracción cargada, las operaciones principales (encontrar el centro, enmascarar puntos, unidimensionalizar) y los puntos de acceso a la configuración de los parámetros del detector.

La ventana se compone, a grandes rasgos, de los menús y la barra de herramientas en la parte superior, el área de visualización de la imagen en el centro, la barra de herramientas vertical a la derecha y el área de gráfico en la parte inferior.

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## Vista central

### Visualización de la imagen

La imagen cargada se muestra aquí. Según la posición del puntero del ratón, el área situada sobre la imagen muestra las coordenadas reales (mm), las coordenadas de la imagen (pix), la distancia desde el centro R (mm), el ángulo de dispersión 2θ, el valor d, el azimut χ y la intensidad. La marca × magenta indica la posición del punto directo (centro).

Los estados de los píxeles se muestran con colores distintos.

| Color | Significado |
| --- | --- |
| Cian | Punto enmascarado |
| Verde | Región excluida de la integración (definida en Integral Region) |
| Magenta | Región angular excluida de la integración (definida en Integral Property) |
| Azul | Píxel por debajo del umbral de intensidad (definido en Integral Region) |
| Rojo | Píxel por encima del umbral de intensidad |

### Operaciones con el ratón

En el modo normal:

- Mantener pulsado el botón izquierdo: busca el centro del punto cercano.
- Doble clic izquierdo: actualiza la posición del centro al punto donde se hizo clic.
- Arrastrar con el botón derecho: amplía la región arrastrada.
- Clic derecho: reduce el zoom.

En **Manual spot mode**, el clic izquierdo enmascara y el clic derecho desenmascara. La forma y el tamaño de la máscara se configuran en la barra de herramientas y en las propiedades.

### Vistas auxiliares e información de la imagen

Junto a la vista central hay visualizaciones auxiliares. Puede alternar entre **Whole image** y **Near center**: la vista de imagen completa marca el rango de visualización actual con un marco amarillo, y la vista de cerca del centro muestra una imagen ampliada.

**Image Information** muestra la resolución de la imagen, la intensidad máxima, la intensidad total, los datos de cabecera, etc.

### Controles de ajuste de la visualización

Controles que ajustan el aspecto de la imagen:

- **Gradient**: invierte el tono.
- **Brightness scale**: logarítmica / lineal.
- **Color scale**: escala de grises / color.
- **Scale line**: visualización de la línea de escala (ninguna / gruesa / media / fina).
- **Auto Contrast** / **Reset Contrast**, e intensidad mínima/máxima explícita.
- Botones de ampliación (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vista inferior

El área inferior tiene tres gráficos/vistas en pestañas.

- **Frequency of Intensity**: la distribución de intensidad de todos los píxeles, en ejes log–log. Ampliable con el ratón.
- **Converted Profile**: el perfil de difracción tras la unidimensionalización (Get Profile). Ampliable con el ratón.
- **Statistical Information**: estadísticas de una región rectangular seleccionada (X1,Y1)–(X2,Y2). Cuando se carga una imagen secuencial, también se pueden comparar las estadísticas de la misma región en otros fotogramas.

## Menús

La barra de menús se compone de **File / Tool / Property / Option / Language / Macro / Help**.

### File

- **Read image**: abre una imagen de difracción. Consulte [Visión general](0-overview.md) para conocer los formatos compatibles.
- **Save image**: guarda en formato TIFF, PNG, CSV o IPA. TIFF conserva las intensidades de píxel originales, PNG conserva la visualización (brillo, contraste, máscara), e IPA es un formato propietario con corrección de distorsión (con metadatos).
- **Read / Save parameter**: importa/exporta la longitud de onda, la longitud de cámara, el tamaño de píxel, la corrección de inclinación, la posición del centro, etc., como un archivo `.prm`.
- **Read / Save / Clear mask**: importa/exporta una máscara como un archivo `.mas`, o la borra (la máscara debe coincidir con la resolución de la imagen actual).
- **Close**.

Los archivos de imagen, parámetros y máscara también se pueden cargar arrastrándolos y soltándolos sobre la ventana.

### Tool

- **Reset Frequency Profile**: borra el gráfico de frecuencia de intensidad (la imagen se conserva).
- **Calibrate Raxis Image**.

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. Estos abren directamente las pestañas correspondientes de la [ventana de propiedades](2-property-windows.md).

### Option

- **ToolTip**: activa/desactiva las descripciones emergentes de los botones y menús.
- **Flip**: horizontal / vertical. **Rotate**: elija un ángulo de rotación. Ambos afectan solo a la visualización; los datos de la imagen cargada no se modifican.
- **Ngen Compile** y **Clear registry** son para desarrollo y resolución de problemas.

### Language

- Cambia entre **English** y **Japanese** (la configuración se guarda en el registro).

### Macro

- **Editor**: abre el editor de macros (consulte [Herramientas](3-tools.md) / [Macro](5-macro/index.md)).

### Help

- **Program Updates**, **Hint**, **License**, **Version History**, **Web Page**.

## Barra de herramientas de operaciones

Las principales operaciones de procesamiento de imágenes (con opciones detalladas en los menús desplegables):

- **Background**: sustracción de una imagen de fondo (configurada en Background Option).
- **Find Center**: detecta el centro del haz mediante ajuste Pseudo-Voigt 2D (rango de búsqueda de 8 px por defecto, definido en Miscellaneous). El menú desplegable también ofrece la detección del centro basada en anillos.
- **Fix center**: fija la posición del centro.
- **Mask Spots**: detecta y enmascara puntos usando el criterio media ± desviación estándar × Deviation. El menú desplegable incluye enmascarar todo, máscara inversa, manual, etc.
- **Manual**: el modo de máscara manual. Puede elegir la forma (círculo / rectángulo) y el tamaño (8–256 px).
- **Get Profile**: integra la imagen en un perfil unidimensional. Admite Concentric (basado en 2θ) y Radial (basado en azimut). El menú desplegable configura la selección de Integral Property/Region, si se debe encontrar el centro y enmascarar los puntos antes de la integración, el envío a PDIndexer, el análisis por división azimutal, el procesamiento de imágenes secuenciales, etc.

## Barra de herramientas (otras herramientas)

La barra de herramientas vertical de la derecha inicia las distintas herramientas. Consulte [Herramientas](3-tools.md) para más detalles.

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
