<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Funciones integradas

Los métodos y propiedades invocables desde una macro, agrupados por espacio de nombres bajo el objeto raíz `IPA`. Las descripciones siguen la ayuda integrada del editor de macros (atributos `[Help]`); dicha ayuda integrada es la referencia autorizada y actualizada.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Devuelve la ruta completa a un directorio. Si se omite `filename`, se abre un cuadro de diálogo de selección de carpeta. |
| `GetFileName(message="")` | Abre un cuadro de diálogo de archivo y devuelve la ruta completa del archivo seleccionado. |
| `GetFileNames(message="")` | Abre un cuadro de diálogo de selección múltiple y devuelve las rutas completas como un arreglo de cadenas. |
| `GetAllFileNames(message="")` | Selecciona una carpeta y devuelve las rutas completas de todos los archivos contenidos en ella (recursivo) como un arreglo. |
| `ReadImage(filename="", flag=None)` | Lee un archivo de imagen. Si se omite, se abre un cuadro de diálogo de selección. |
| `ReadImageHDF(filename, flag)` | Lee una imagen HDF5. `flag` activa o desactiva la normalización. |
| `SaveImage(filename="")` | Guarda la imagen actual (alias heredado; por defecto TIFF). |
| `SaveImageAsTIFF(filename="")` | Guarda la imagen como TIFF. |
| `SaveImageAsPNG(filename="")` | Guarda la imagen como PNG. |
| `SaveImageAsIPA(filename="")` | Guarda la imagen en formato IPA. |
| `SaveImageAsCSV(filename="")` | Guarda la imagen como CSV. |
| `ReadParameter(filename="")` | Lee un archivo de parámetros. |
| `SaveParameter(filename="")` | Guarda los parámetros actuales. |
| `ReadMask(filename="")` | Lee un archivo de máscara. |
| `SaveMask(filename="")` | Guarda la máscara actual. |

En todos los métodos de lectura/guardado, omitir o indicar un nombre de archivo inválido abre un cuadro de diálogo de selección.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Establece la longitud de onda del haz incidente (en nm). |
| `WaveLength` | Establece u obtiene la longitud de onda (en nm). |
| `WaveSource` | Establece u obtiene la fuente como un entero. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Establece la línea de longitud de onda de rayos X como un entero (solo setter). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Establece la posición del centro (punto directo) (en píxeles). |
| `SetCameraLength(length)` | Establece la longitud de cámara (en mm). |
| `CenterX` | Establece u obtiene el valor X de la posición del centro (en píxeles). |
| `CenterY` | Establece u obtiene el valor Y de la posición del centro (en píxeles). |
| `CameraLength` | Establece u obtiene la longitud de cámara (en mm). |
| `PixelSizeX` | Establece u obtiene el tamaño X del píxel (ancho del píxel) (en mm). |
| `PixelSizeY` | Establece u obtiene el tamaño Y del píxel (alto del píxel) (en mm). |
| `PixelKsi` | Establece u obtiene la inclinación del píxel ξ (en grados). |
| `TiltPhi` | Establece u obtiene la inclinación φ (en grados). |
| `TiltTau` | Establece u obtiene la inclinación τ (en grados). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Dibuja la imagen con un gradiente negativo (contraparte de `PositiveGradient`). |
| `PositiveGradient` | True/False. Dibuja la imagen con un gradiente positivo (contraparte de `NegativeGradient`). |
| `LinearScale` | True/False. Dibuja con escala lineal (contraparte de `LogScale`). |
| `LogScale` | True/False. Dibuja con escala logarítmica (contraparte de `LinearScale`). |
| `GrayScale` | True/False. Dibuja con escala de grises (contraparte de `ColorScale`). |
| `ColorScale` | True/False. Dibuja con escala de color (contraparte de `GrayScale`). |
| `Maximum` | Establece u obtiene el nivel máximo de brillo (float). |
| `Minimum` | Establece u obtiene el nivel mínimo de brillo (float). |
| `CanvasMagnification` | Establece u obtiene la ampliación de la imagen (float). |
| `SetCanvasCenter(x, y)` | Establece la posición del centro del lienzo (en píxeles). |
| `SetCanvasSize(width, height)` | Establece el tamaño del lienzo (picture box) (en píxeles). |
| `SetArea(top, bottom, left, right)` | Establece el área del lienzo mediante los límites superior/inferior/izquierdo/derecho (en píxeles). |
| `SetFullArea()` | Establece el área del lienzo de modo que toda la imagen sea visible. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Enmascara los puntos (igual que el botón "Mask Spots"). |
| `ClearMask()` | Borra las máscaras actuales. |
| `InvertMask()` | Invierte el estado actual de la máscara. |
| `MaskAll()` | Enmascara toda el área. |
| `MaskTop()` | Enmascara la mitad superior. |
| `MaskBottom()` | Enmascara la mitad inferior. |
| `MaskLeft()` | Enmascara la mitad izquierda. |
| `MaskRight()` | Enmascara la mitad derecha. |
| `TakeOver` | Establece u obtiene la configuración de heredar máscara (entero). 0: None, 1: hereda el estado actual de la máscara, 2: hereda el archivo de máscara. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra concéntricamente (2θ–intensidad). |
| `RadialIntegration` | True/False. Integra radialmente (pizza-cut). |
| `AzimuthalDivision` | True/False. Procesa en modo de división azimutal. |
| `AzimuthalDivisionNumber` | Entero. Establece el número de divisiones del anillo de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Ejecuta Find Center antes de Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Ejecuta Mask Spots antes de Get Profile. |
| `SendProfileViaClipboard` | True/False. Envía el perfil a PDIndexer a través del portapapeles. |
| `SaveProfileAfterGetProfile` | True/False. Guarda el perfil después de Get Profile. |
| `SaveProfileAsPDI` | True/False. Guarda en formato PDI. |
| `SaveProfileAsCSV` | True/False. Guarda en formato CSV. |
| `SaveProfileAsTSV` | True/False. Guarda en formato TSV. |
| `SaveProfileAsGSAS` | True/False. Guarda en formato GSAS. |
| `SaveProfileInOneFile` | True/False. Guarda los perfiles secuenciales/de división azimutal en un solo archivo. |
| `SaveProfileAtImageDirectory` | True/False. Guarda en el mismo directorio que la imagen. |
| `GetProfile(filename="")` | Ejecuta la unidimensionalización. Si se indica `filename`, el perfil se guarda en ese archivo. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Integra concéntricamente (2θ–intensidad). |
| `RadialIntegration` | True/False. Integra radialmente (pizza-cut / cake pattern). |
| `ConcentricStart` | Float. Valor inicial para la integración concéntrica. |
| `ConcentricEnd` | Float. Valor final para la integración concéntrica. |
| `ConcentricStep` | Float. Valor del paso para la integración concéntrica. |
| `ConcentricUnit` | Entero. Unidad para la integración concéntrica. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Radio del anillo (donut) para la integración radial. |
| `RadialWidgh` | Float. Ancho del anillo (donut) para la integración radial. Nota: el miembro se escribe `RadialWidgh` en la versión actual. |
| `RadialStep` | Float. Ángulo del sector (paso de barrido) para la integración radial. |
| `RadialUnit` | Entero. Unidad para la integración radial. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Obtiene si el archivo actual es una imagen secuencial. |
| `Count` | Entero. Obtiene el número de imágenes. |
| `SelectedIndex` | Entero. Establece u obtiene el índice seleccionado (basado en 0). |
| `SelectedIndices` | Arreglo de enteros. Establece u obtiene los índices seleccionados (para el modo de selección múltiple). |
| `MultiSelection` | True/False. Establece u obtiene el modo de selección múltiple. |
| `Averaging` | True/False. Establece u obtiene el modo de promediado. |
| `SelectIndex(index)` | Establece un único índice seleccionado (desactiva la selección múltiple). |
| `AppendIndex(index)` | Agrega un índice a la selección actual. |
| `SelectIndices(start, end)` | Establece un rango contiguo (de start a end, ambos incluidos). |
| `AppendIndices(start, end)` | Agrega un rango contiguo (de start a end, ambos incluidos) a la selección actual. |
| `Target_SelectedImages` | True/False. Hace que las imágenes seleccionadas sean el objetivo de Get Profile. |
| `Target_AllImages` | True/False. Hace que todas las imágenes sean el objetivo de Get Profile. |
| `Target_TopmostImage` | True/False. Hace que solo la imagen superior sea el objetivo de Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Ejecuta la macro en PDIndexer paso a paso. |
| `Timeout` | Establece u obtiene el tiempo de espera (segundos) para la operación de la macro (predeterminado 30 s). |
| `RunMacro(obj1, obj2, ...)` | Ejecuta código de macro en PDIndexer. Los parámetros se leen en PDI como `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Ejecuta la macro con nombre `name` en PDIndexer. Los parámetros se leen en PDI como `Obj[1]`, `Obj[2]`, … |
