<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Ventana principal

La ventana principal es la primera pantalla que aparece al iniciar IPAnalyzer. Reúne la visualización de la imagen de difracción cargada, las operaciones principales (búsqueda del centro, enmascaramiento de puntos, integración en un perfil 1D) y los accesos a la configuración de los parámetros del detector.

A grandes rasgos, la ventana consta de los menús y la barra de herramientas en la parte superior, el área de visualización de la imagen en el centro, la barra de herramientas vertical a la derecha y el área de gráficos en la parte inferior.

![La ventana principal de IPAnalyzer](../assets/cap-en-auto/FormMain.png)

## Vista central

### Visualización de la imagen

Aquí se muestra la imagen cargada. Según la posición del puntero del ratón, el área situada sobre la imagen muestra las coordenadas reales (mm), las coordenadas de imagen (pix), la distancia al centro R (mm), el ángulo de dispersión 2θ, el valor d, el azimut χ y la intensidad. La marca × magenta indica la posición del punto directo (centro).

Los estados de los píxeles se muestran con colores distintos.

| Color | Significado |
| --- | --- |
| Cian | Punto enmascarado |
| Verde | Región excluida de la integración (se define en Región de integración (Integral Region)) |
| Magenta | Región angular excluida de la integración (se define en Propiedad de integración (Integral Property)) |
| Azul | Píxel por debajo del umbral de intensidad (se define en Región de integración (Integral Region)) |
| Rojo | Píxel por encima del umbral de intensidad |

### Operaciones con el ratón

En el modo normal:

- Doble clic izquierdo: actualiza la posición del centro al punto pulsado.
- Clic central: busca el centro a partir del punto pulsado.
- Arrastrar con el botón derecho: amplía la región arrastrada.
- Clic derecho: reduce el zoom.
- Ctrl + arrastrar con el botón derecho: selecciona la región rectangular usada para la información estadística.

El doble clic izquierdo y el clic central solo funcionan mientras **Fijar centro (Fix Center)** está desactivado.

En **Modo manual (Manual Mode)**, el clic izquierdo enmascara y el clic derecho desenmascara. La forma y el tamaño de la máscara se configuran en la barra de herramientas y en las propiedades.

### Vistas auxiliares e información de la imagen

Junto a la vista central hay visualizaciones auxiliares. Puedes alternar entre **Imagen completa (Whole image)** y **Cerca del centro (Near center)**: la vista de imagen completa marca el intervalo de visualización actual con un marco amarillo, y la vista cercana al centro muestra una imagen ampliada.

**Información de la imagen (Image Information)** muestra la resolución de la imagen, la intensidad máxima, la intensidad total, los datos de cabecera, etc.

### Controles de ajuste de la visualización

Controles que ajustan el aspecto de la imagen:

- **Gradiente (Gradient)**: invierte la tonalidad.
- **Escala de brillo (Brightness scale)**: logarítmica / lineal.
- **Escala de color (Color scale)**: escala de grises / color.
- **Línea de escala (Scale line)**: visualización de líneas de escala (ninguna / gruesa / media / fina).
- **Contraste automático (Auto Contrast)** / **Restablecer contraste (Reset Contrast)**, e intensidad mínima/máxima explícita.
- Botones de aumento (×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Vista inferior

El área inferior tiene tres gráficos/vistas en pestañas.

- **Frecuencia de intensidad (Frequency of Intensity)**: la distribución de intensidad de todos los píxeles, en ejes log–log. Se puede ampliar con el ratón.
- **Perfil convertido (Converted Profile)**: el perfil de difracción producido por **Obtener perfil (Get Profile)**. Se puede ampliar con el ratón.
- **Información estadística (Statistical Information)**: estadísticas de la región rectangular (X1,Y1)–(X2,Y2) seleccionada con Ctrl + arrastrar con el botón derecho sobre la imagen. Cuando se carga una imagen secuencial, también se pueden comparar las estadísticas de la misma región en otros fotogramas.

## Menús

La barra de menús consta de **Archivo / Herramienta / Propiedad / Opción / Idioma / Macro / Ayuda (File / Tool / Property / Option / Language / Macro / Help)**.

### Archivo (File)

- **Leer imagen (Read image)**: abre una imagen de difracción. Véase [Visión general](0-overview.md) para los formatos admitidos.
- **Guardar imagen (Save image)**: guarda en formato TIFF, PNG, CSV o IPA. TIFF almacena las intensidades de píxel procesadas actuales (tras voltear/rotar, restar el fondo y corregir la polarización), PNG conserva la visualización (brillo, contraste, máscara) e IPA es un formato propio con la distorsión corregida (con metadatos).
- **Leer parámetro (Read parameter)** / **Guardar parámetro (Save parameter)**: importa/exporta la longitud de onda, la longitud de cámara, el tamaño de píxel, la corrección de inclinación, la posición del centro, etc. como archivo `.prm`.
- **Leer máscara (Read mask)** / **Guardar máscara (Save mask)** / **Borrar máscara (Clear mask)**: importa/exporta una máscara como archivo `.mas`, o la borra (la máscara debe coincidir con la resolución de la imagen actual).
- **Cerrar (Close)**.

Los archivos de imagen, de parámetros y de máscara también se pueden cargar arrastrándolos y soltándolos sobre la ventana.

### Herramienta (Tool)

- **Restablecer perfil de frecuencia (Reset Frequency Profile)**: reconstruye el gráfico de frecuencia de intensidad de la imagen actual con el intervalo predeterminado (la imagen se conserva).
- **Calibrar imagen R-AXIS (Calibrate Raxis Image)**: obtiene una tabla de conversión de intensidad a partir de dos imágenes R-AXIS (véase [Herramientas](3-tools.md)).

### Propiedad (Property)

Fuente de radiación (Wave Source) / Condición de la placa de imagen (Imaging Plate Condition) / Región de integración (Integral Region) / Propiedad de integración (Integral Property) / Modo de máscara manual (Manual Mask Mode) / Tras "Obtener perfil" (After "Get Profile") / Opción de imagen desplegada (Unrolled Image Option) / Varios (Miscellaneous). Estos elementos abren directamente las pestañas correspondientes de la [ventana de propiedades](2-property-windows.md).

### Opción (Option)

- **Información sobre herramientas (ToolTip)**: activa o desactiva la información sobre herramientas de botones y menús.
- **Voltear (Flip)**: **Horizontalmente (Horizontally)** / **Verticalmente (Vertically)**. **Rotar (Rotate)**: elige un ángulo de rotación. El volteo y la rotación se aplican a los datos de imagen de trabajo y, por tanto, también afectan a la integración y al guardado de imagen posteriores (el archivo de origen en disco no se modifica).
- **Borrar registro (comprobar y reiniciar) (Clear registry (check and restart))**: elemento de resolución de problemas que borra la configuración guardada.

### Idioma (Language)

- Selecciona el idioma de visualización (11 idiomas). Tras la confirmación, la aplicación se reinicia. La configuración se guarda en el registro.

### Macro

- **Editor**: abre el editor de macros (véase [Herramientas](3-tools.md) / [Macro](5-macro/index.md)).

### Ayuda (Help)

- **Actualizaciones del programa (Program Updates)**, **Sugerencia (Hint)**, **Licencia (License)**, **Historial de versiones (Version history)**, **Ayuda (Help)**.
- **Ayuda (Help)** abre este manual en línea en el navegador web predeterminado, igual que pulsar **F1**.
- Pulsa **F1** en cualquier ventana para abrir la página correspondiente de este manual en línea.

## Barra de herramientas de operaciones

Las operaciones principales de procesamiento de imagen (con opciones detalladas en los menús desplegables):

- **Fondo (Background)**: este botón está deshabilitado en la versión actual. La resta de una imagen de fondo se configura en la pestaña **Opciones de fondo (Background Option)** de la ventana de propiedades.
- **Buscar centro (Find Center)**: detecta el centro del haz mediante un ajuste Pseudo-Voigt 2D (por defecto, el intervalo de búsqueda es de ±8 px alrededor del centro; se define en la pestaña Varios (Miscellaneous)). Cuando se muestran anillos con **Dibujar anillo (Draw ring)**, el centro se determina a partir del anillo.
- **Fijar centro (Fix Center)**: fija la posición del centro.
- **Enmascarar puntos (Mask Spots)**: dentro de cada banda radial, los píxeles cuya intensidad supera media + desviación estándar × **Desviación de criterio para "Enmascarar puntos" (Criterial deviation for "Mask Spots")** (pestaña Opciones de máscara (Mask Option)) se detectan como puntos y se enmascaran junto con su entorno. El menú desplegable incluye **Enmascarar toda el área (Mask all area)**, **Invertir máscara (Invert mask)**, **Modo manual (Manual Mode)**, etc.
- **Modo manual (Manual Mode)**: el modo de máscara manual. Puedes elegir la forma de la máscara (punto (círculo/rectángulo) / círculo / rectángulo / polígono / spline) y el tamaño del punto (semianchura).
- **Obtener perfil (Get Profile)**: integra la imagen en un perfil 1D. Admite **Integración concéntrica (Concentric Integration)** (basada en 2θ) e **Integración radial (Radial integration)** (basada en el azimut). El menú desplegable configura la selección de Propiedad de integración/Región de integración (Integral Property/Region), si se busca el centro y se enmascaran los puntos antes de la integración, el envío a PDIndexer, el **Análisis de división azimutal (Azimuthal Division Analysis)** (solo con integración concéntrica y el eje **Ángulo (Angle)** (2θ); en otro caso se muestra una advertencia y no se ejecuta nada), el procesamiento de imágenes secuenciales, etc.

## Barra de herramientas (otras herramientas)

La barra de herramientas vertical de la derecha inicia las distintas herramientas. Véase [Herramientas](3-tools.md) para más detalles.

- **Procedimiento automático (Auto procedure)**
- **Dibujar anillo (Draw ring)**
- **Buscar parámetro (geométricamente) (Find parameter (geometrically))** / **Buscar parámetro (fuerza bruta) (Find parameter (brute force))**
- **Desplegar imagen (Unroll image)**
- **Desenfoque circunferencial (Circumferential blur)**
- **Imagen secuencial (Sequential image)**
