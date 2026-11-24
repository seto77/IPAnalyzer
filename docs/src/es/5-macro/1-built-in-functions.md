<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Funciones integradas

Los métodos y propiedades que se pueden invocar desde una macro, agrupados por espacio de nombres bajo el objeto raíz `IPA`. Las descripciones siguen la ayuda del editor de macros (atributos `[Help]`); la ayuda del editor es la referencia de autoridad y actualizada.

## IPA.File

| Miembro | Descripción |
|------|------|
| `GetDirectoryPath(filename="")` | Devuelve la ruta completa de un directorio. Si se omite `filename`, se abre un diálogo de selección de carpeta. |
| `GetFileName(message="")` | Abre un diálogo de archivo y devuelve la ruta completa del archivo seleccionado. |
| `GetFileNames(message="")` | Abre un diálogo de selección múltiple y devuelve las rutas completas como un array de cadenas. |
| `GetAllFileNames(message="")` | Selecciona una carpeta y devuelve como array las rutas completas de todos los archivos que contiene (de forma recursiva). |
| `ReadImage(filename="", flag=None)` | Lee un archivo de imagen. Si se omite, se abre un diálogo de selección. |
| `ReadImageHDF(filename, flag)` | Lee una imagen HDF5. `flag` activa o desactiva la normalización. En la versión actual la lectura de HDF5 (`.h5`) no funciona; los archivos NeXus (`.nxs`) se pueden leer con `ReadImage(filename)`. |
| `SaveImage(filename="")` | Guarda la imagen actual (alias heredado; por defecto en TIFF). |
| `SaveImageAsTIFF(filename="")` | Guarda la imagen como TIFF. |
| `SaveImageAsPNG(filename="")` | Guarda la imagen como PNG. |
| `SaveImageAsIPA(filename="")` | Guarda la imagen en formato IPA. |
| `SaveImageAsCSV(filename="")` | Guarda la imagen como CSV. |
| `ReadParameter(filename="")` | Lee un archivo de parámetros. |
| `SaveParameter(filename="")` | Guarda los parámetros actuales. |
| `ReadMask(filename="")` | Lee un archivo de máscara. |
| `SaveMask(filename="")` | Guarda la máscara actual. |

En todos los métodos de lectura/guardado, si se omite el nombre de archivo o se da uno no válido, se abre un diálogo de selección.

## IPA.Wave

| Miembro | Descripción |
|------|------|
| `SetWaveLength(wavelength)` | Define la longitud de onda del haz incidente (en nm). |
| `WaveLength` | Define/obtiene la longitud de onda (en nm). |
| `WaveSource` | Define/obtiene la fuente como un entero. 0: ninguna, 1: rayos X, 2: electrones, 3: neutrones. |
| `XrayLine` | Define la línea de longitud de onda de rayos X como un entero (solo escritura). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Miembro | Descripción |
|------|------|
| `SetCenter(x, y)` | Define la posición del centro (punto directo) (en píxeles). |
| `SetCameraLength(length)` | Define la longitud de cámara (en mm). |
| `CenterX` | Define/obtiene el valor X de la posición del centro (en píxeles). |
| `CenterY` | Define/obtiene el valor Y de la posición del centro (en píxeles). |
| `CameraLength` | Define/obtiene la longitud de cámara (en mm). |
| `PixelSizeX` | Define/obtiene el tamaño X del píxel (anchura del píxel) (en mm). |
| `PixelSizeY` | Define/obtiene el tamaño Y del píxel (altura del píxel) (en mm). |
| `PixelKsi` | Define/obtiene el sesgo del píxel ξ (en grados). |
| `TiltPhi` | Define/obtiene la inclinación φ (en grados). |
| `TiltTau` | Define/obtiene la inclinación τ (en grados). |

## IPA.Image

| Miembro | Descripción |
|------|------|
| `NegativeGradient` | True/False. Dibuja la imagen con gradiente negativo (contrapartida de `PositiveGradient`). |
| `PositiveGradient` | True/False. Dibuja la imagen con gradiente positivo (contrapartida de `NegativeGradient`). |
| `LinearScale` | True/False. Dibuja con escala lineal (contrapartida de `LogScale`). |
| `LogScale` | True/False. Dibuja con escala logarítmica (contrapartida de `LinearScale`). |
| `GrayScale` | True/False. Dibuja en escala de grises (contrapartida de `ColorScale`). |
| `ColorScale` | True/False. Dibuja en escala de color (contrapartida de `GrayScale`). |
| `Maximum` | Define/obtiene el nivel de brillo máximo (float). |
| `Minimum` | Define/obtiene el nivel de brillo mínimo (float). |
| `CanvasMagnification` | Define/obtiene el aumento de la imagen (float). |
| `SetCanvasCenter(x, y)` | Define la posición del centro del lienzo (en píxeles). |
| `SetCanvasSize(width, height)` | Define el tamaño del lienzo (picture box) (en píxeles). |
| `SetArea(top, bottom, left, right)` | Define el área del lienzo mediante los límites superior/inferior/izquierdo/derecho (en píxeles). |
| `SetFullArea()` | Define el área del lienzo de modo que se vea la imagen completa. |

## IPA.Mask

| Miembro | Descripción |
|------|------|
| `MaskSpots()` | Enmascara los puntos (igual que el botón "Enmascarar puntos" ("Mask Spots")). |
| `ClearMask()` | Borra las máscaras actuales. |
| `InvertMask()` | Invierte el estado actual de la máscara. |
| `MaskAll()` | Enmascara toda el área. |
| `MaskTop()` | Enmascara la mitad superior. |
| `MaskBottom()` | Enmascara la mitad inferior. |
| `MaskLeft()` | Enmascara la mitad izquierda. |
| `MaskRight()` | Enmascara la mitad derecha. |
| `TakeOver` | Define/obtiene la configuración de herencia de la máscara (entero). 0: ninguna, 1: heredar el estado de máscara actual, 2: heredar el archivo de máscara. |

## IPA.Profile

| Miembro | Descripción |
|------|------|
| `ConcentricIntegration` | True/False. Integra de forma concéntrica (2θ–intensidad). |
| `RadialIntegration` | True/False. Integra de forma radial (corte en porciones de pizza). |
| `AzimuthalDivision` | True/False. Procesa en el modo de división azimutal. |
| `AzimuthalDivisionNumber` | Entero. Define el número de divisiones del anillo de Debye. |
| `FindCenterBeforeGetProfile` | True/False. Ejecuta Buscar centro (Find Center) antes de Obtener perfil (Get Profile). |
| `MaskSpotsBeforeGetProfile` | True/False. Ejecuta Enmascarar puntos (Mask Spots) antes de Obtener perfil (Get Profile). |
| `SendProfileViaClipboard` | True/False. Envía el perfil a PDIndexer a través del portapapeles. |
| `SaveProfileAfterGetProfile` | True/False. Guarda el perfil después de Obtener perfil (Get Profile). |
| `SaveProfileAsPDI` | True/False. Guarda en formato PDI. |
| `SaveProfileAsCSV` | True/False. Guarda en formato CSV. |
| `SaveProfileAsTSV` | True/False. Guarda en formato TSV. |
| `SaveProfileAsGSAS` | True/False. Guarda en formato GSAS. Solo es posible para la integración concéntrica con eje en 2θ; no se escribe cuando se guardan varios perfiles en un único archivo. |
| `SaveProfileInOneFile` | True/False. Guarda en un único archivo los perfiles secuenciales/de división azimutal. |
| `SaveProfileAtImageDirectory` | True/False. Guarda en el mismo directorio que la imagen. |
| `GetProfile(filename="")` | Integra la imagen en un perfil 1D (igual que **Obtener perfil (Get Profile)**). Si se da `filename`, se usa como nombre base y se añade la extensión del formato (p. ej., `GetProfile("sample.stl")` guardado como CSV da `sample.stl.csv`). Si el destino está configurado como "elegir cada vez", se muestra el diálogo de guardado. |

## IPA.IntegralProperty

| Miembro | Descripción |
|------|------|
| `ConcentricIntegration` | True/False. Integra de forma concéntrica (2θ–intensidad). |
| `RadialIntegration` | True/False. Integra de forma radial (corte en porciones de pizza / patrón de pastel). |
| `ConcentricStart` | Float. Valor inicial de la integración concéntrica. |
| `ConcentricEnd` | Float. Valor final de la integración concéntrica. |
| `ConcentricStep` | Float. Valor del paso de la integración concéntrica. |
| `ConcentricUnit` | Entero. Unidad de la integración concéntrica. 0: ángulo (grados), 1: espaciado d (Å), 2: longitud (mm). |
| `RadialRadius` | Float. Radio del anillo (donut) para la integración radial. |
| `RadialWidgh` | Float. Anchura del anillo (donut) para la integración radial. Nota: en la versión actual el miembro se escribe `RadialWidgh`. |
| `RadialStep` | Float. Ángulo de sector (paso de barrido) para la integración radial. |
| `RadialUnit` | Entero. Unidad de la integración radial. 0: ángulo (grados), 1: espaciado d (Å). |

## IPA.Sequential

| Miembro | Descripción |
|------|------|
| `SequentialImageMode` | True/False. Obtiene si el archivo actual es una imagen secuencial. |
| `Count` | Entero. Obtiene el número de imágenes. |
| `SelectedIndex` | Entero. Define/obtiene el índice seleccionado (base 0). |
| `SelectedIndices` | Array de enteros. Define/obtiene los índices seleccionados (para el modo de selección múltiple). |
| `MultiSelection` | True/False. Define/obtiene el modo de selección múltiple. |
| `Averaging` | True/False. Define/obtiene el modo de promediado. |
| `SelectIndex(index)` | Define un único índice seleccionado (desactiva la selección múltiple). |
| `AppendIndex(index)` | Añade un índice a la selección actual. |
| `SelectIndices(start, end)` | Define un intervalo contiguo (de start a end, ambos incluidos). |
| `AppendIndices(start, end)` | Añade un intervalo contiguo (de start a end, ambos incluidos) a la selección actual. |
| `Target_SelectedImages` | True/False. Hace que las imágenes seleccionadas sean el objetivo de Obtener perfil (Get Profile). |
| `Target_AllImages` | True/False. Hace que todas las imágenes sean el objetivo de Obtener perfil (Get Profile). |
| `Target_TopmostImage` | True/False. Hace que solo la imagen superior sea el objetivo de Obtener perfil (Get Profile). |

## IPA.PDI

| Miembro | Descripción |
|------|------|
| `Debug` | True/False. Ejecuta la macro en PDIndexer paso a paso. |
| `Timeout` | Define/obtiene el tiempo de espera (segundos) de la operación de macro (por defecto, 30 s). |
| `RunMacro(obj1, obj2, ...)` | Ejecuta el código abierto actualmente en el editor de macros de PDIndexer. En PDIndexer, los parámetros se leen como `PDI.Obj[0]`, `PDI.Obj[1]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Ejecuta la macro guardada con el nombre `name` en PDIndexer. En PDIndexer, los parámetros se leen como `PDI.Obj[0]`, `PDI.Obj[1]`, … |
