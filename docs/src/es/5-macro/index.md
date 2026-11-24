<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). -->

# Macro

IPAnalyzer ofrece una función de **macro** que automatiza secuencias de operaciones con scripts de estilo Python. Resulta útil para tareas repetitivas como la conversión a una dimensión por lotes de muchos archivos, la conversión de formatos y el análisis de división azimutal.

## Abrir el editor

Abre el editor de macros desde el menú **Macro** → **Editor** de la ventana principal. Allí puedes editar el código y ejecutarlo, incluida la ejecución paso a paso.

![Editor de macros](../../assets/cap-en-auto/FormMacro.png)

## Lenguaje

- Están disponibles las sentencias de control como `for` / `if` / `while` / `def` / `class`, y la aritmética.
- El módulo `math` está importado de antemano, por lo que puedes usar `math.pi` o `math.sin(...)` directamente sin una sentencia `import`.
- `print()` no está disponible. Para inspeccionar valores, usa la **ejecución paso a paso** (Step by step) y observa cómo cambian las variables en el panel de depuración.
- Cada operación de IPAnalyzer se invoca desde un espacio de nombres bajo el objeto raíz `IPA` (p. ej., `IPA.File`).

## Espacios de nombres IPA

| Espacio de nombres | Función |
|------|------|
| `IPA.File` | Leer/escribir archivos de imagen, de parámetros y de máscara; diálogos de selección de archivos |
| `IPA.Wave` | Configurar la fuente incidente y la longitud de onda |
| `IPA.Detector` | Configurar la geometría del detector: centro, longitud de cámara, tamaño de píxel, inclinación |
| `IPA.Image` | Controlar la escala de visualización, el contraste y el área de vista |
| `IPA.Mask` | Enmascarar puntos y regiones |
| `IPA.Profile` | Ejecutar la conversión a una dimensión (Obtener perfil (Get Profile)) y configurar el guardado/envío |
| `IPA.IntegralProperty` | Configurar el intervalo, el paso y la unidad de la integración concéntrica / radial |
| `IPA.Sequential` | Seleccionar / promediar / elegir como objetivo los fotogramas de una imagen multifotograma |
| `IPA.PDI` | Invocar macros en PDIndexer (integración mediante el portapapeles) |

Véase [Funciones integradas](1-built-in-functions.md) para la lista de miembros, y [Ejemplos](2-examples.md) para scripts concretos.

!!! tip "La ayuda del editor es la referencia de autoridad"
    La descripción de cada función/propiedad se muestra en la ayuda del editor de macros, y es la fuente de referencia actualizada que sigue a cada versión. Si esta página no coincide con la ayuda del editor, confía en esta última.

## Macros de ejemplo

Activa **Mostrar ejemplos (Show samples)** en el editor para listar las macros de ejemplo de solo lectura (bucles básicos, funciones matemáticas, configuración de la geometría, procesamiento por lotes, división azimutal, enmascaramiento, envío a PDIndexer, etc.); desactívalo para volver a tus propias macros guardadas. Son un punto de partida sencillo para adaptarlas.

## Uso con el Procedimiento automático

Las macros que escribas se pueden guardar con un nombre e invocar también desde la lista "ejecutar tras la carga" del [Procedimiento automático (Auto Procedure)](../3-tools.md), de modo que la macro se aplique automáticamente a cada imagen que llegue durante un experimento.
