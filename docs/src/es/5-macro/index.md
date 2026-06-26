<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer ofrece una función de **macro** que automatiza secuencias de operaciones mediante scripts similares a Python. Resulta útil para tareas repetitivas como la unidimensionalización por lotes de muchos archivos, la conversión de formato y el análisis por división azimutal.

## Abrir el editor

Abra el editor de macros desde el menú **Macro** → **Editor** de la ventana principal. Allí puede editar el código y ejecutarlo, incluyendo la ejecución paso a paso.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Lenguaje

- Están disponibles sentencias de control como `for` / `if` / `while` / `def` / `class`, así como operaciones aritméticas.
- El módulo `math` está preimportado, por lo que puede usar `math.pi` o `math.sin(...)` directamente sin una sentencia `import`.
- `print()` no está disponible. Para inspeccionar valores, use la **ejecución paso a paso** (Step by step) y observe el cambio de las variables en el panel de depuración.
- Cada operación de IPAnalyzer se invoca desde un espacio de nombres bajo el objeto raíz `IPA` (p. ej. `IPA.File`).

## Espacios de nombres de IPA

| Espacio de nombres | Función |
|------|------|
| `IPA.File` | Leer/escribir archivos de imagen, parámetros y máscaras; diálogos de selección de archivos |
| `IPA.Wave` | Configurar la fuente incidente y la longitud de onda |
| `IPA.Detector` | Configurar la geometría del detector: centro, longitud de cámara, tamaño de píxel, inclinación |
| `IPA.Image` | Controlar la escala de visualización, el contraste y el área de vista |
| `IPA.Mask` | Enmascarar puntos (spots) y regiones |
| `IPA.Profile` | Ejecutar la unidimensionalización (Get Profile) y configurar el guardado/envío |
| `IPA.IntegralProperty` | Configurar el rango, el paso y la unidad de la integración concéntrica / radial |
| `IPA.Sequential` | Seleccionar / promediar / definir fotogramas de destino de una imagen multifotograma |
| `IPA.PDI` | Invocar macros en PDIndexer (integración con el portapapeles) |

Consulte [Funciones integradas](1-built-in-functions.md) para ver la lista de miembros, y [Ejemplos](2-examples.md) para scripts concretos.

!!! tip "La ayuda dentro del editor es la referencia autorizada"
    La descripción de cada función/propiedad se muestra en la ayuda del editor de macros y es la fuente de verdad actualizada y con seguimiento de versiones. Si esta página difiere de la ayuda dentro del editor, confíe en esta última.

## Macros de ejemplo

Cuando la lista de macros guardadas del editor está vacía, se insertan automáticamente macros de ejemplo (bucles básicos, funciones matemáticas, configuración de la geometría, procesamiento por lotes, división azimutal, enmascaramiento, envío a PDIndexer, etc.). Son un punto de partida sencillo para adaptar.

## Trabajar con Auto Procedure

Las macros que escriba se pueden guardar con un nombre y también invocar desde la lista "execute after loading" de [Auto Procedure](../3-tools.md), de modo que una macro se aplique automáticamente a cada imagen que llegue durante un experimento.
