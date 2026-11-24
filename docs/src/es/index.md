<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Manual de IPAnalyzer

## Breve introducción

* **IPAnalyzer** es software libre con licencia MIT que convierte imágenes bidimensionales de difracción de polvo (anillos de Debye–Scherrer) registradas con Imaging Plates (IP) o detectores de panel plano CCD/CMOS en perfiles 1D 2θ–intensidad de alta precisión.
* Calibra la geometría de medición — longitud de cámara, longitud de onda, inclinación del detector y forma de píxel — a partir de los anillos de materiales de referencia, admite fuentes de rayos X, electrones y neutrones, y se integra con [PDIndexer](https://github.com/seto77/PDIndexer) para el análisis posterior de picos.
* Su diseño y funciones siguen los de *PIP*, desarrollado por Hiroshi Fujihisa en AIST.

## Buscar por objetivo

| Objetivo | Empieza aquí | Pasos principales siguientes |
|------|------------|-----------------|
| Comprender el sistema de coordenadas y la geometría | [Visión general](0-overview.md) | [Ventanas de propiedades](2-property-windows.md) |
| Cargar una imagen y obtener un perfil 1D | [Procedimientos](4-procedures.md) | [Ventana principal](1-main-window.md), [Ventanas de propiedades](2-property-windows.md) |
| Calibrar la longitud de cámara / longitud de onda | [Procedimientos](4-procedures.md) | [Herramientas](3-tools.md), [Buscar parámetros (fuerza bruta)](6-find-parameter.md) |
| Enmascarar puntos / gestionar datos multifotograma | [Herramientas](3-tools.md) | [Procedimientos](4-procedures.md) |
| Automatizar el procesamiento | [Macro](5-macro/index.md) | [Funciones integradas](5-macro/1-built-in-functions.md), [Ejemplos](5-macro/2-examples.md), [Procedimiento automático (Auto Procedure)](3-tools.md) |
| Resolución de problemas y preguntas frecuentes | [Preguntas y respuestas](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## Funciones

* **Amplio soporte de formatos** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4 y formatos de imagen generales. La mayoría de las operaciones de lectura y escritura de archivos admiten arrastrar y soltar.
* **Conversión de imagen a perfil** : Cálculo concéntrico (promedio radial), radial (azimutal/cake) y de imagen desplegada, mediante un algoritmo de distribución de área subpíxel que trata correctamente la inclinación del detector y las formas de píxel en paralelogramo.
* **Calibración de la geometría** : Refinamiento geométrico (doble casete) de la longitud de onda, la longitud de cámara, el tamaño/distorsión de píxel y la inclinación (φ, τ), además de una búsqueda exhaustiva en cuadrícula (fuerza bruta) para datos difíciles.
* **Manejo de imágenes** : Detección automática del centro del haz, detección y enmascaramiento de puntos de monocristal (spots), desenfoque circunferencial, superposición de anillos, calibración de intensidad de imágenes R-AXIS y guardado en formato IPA que conserva la geometría.
* **Datos multifotograma** : Selección, promedio o suma de fotogramas de NeXus (`.nxs`), TIFF multipágina y otros datos secuenciales; si un fotograma contiene información de energía, al seleccionarlo se actualiza la longitud de onda.
* **Automatización** : Procedimiento automático (Auto Procedure) con supervisión de carpeta y una [macro](5-macro/index.md) con sintaxis de Python para el procesamiento por lotes y mediante scripts.
* **Integración con PDIndexer** : Envía perfiles a [PDIndexer](https://github.com/seto77/PDIndexer) a través del portapapeles y ejecuta allí macros con nombre.

## Requisitos del sistema

Estos requisitos se aplican a las compilaciones .NET 11 de este árbol de código fuente. Para las versiones publicadas, sigue el requisito de runtime indicado para cada versión.

| Elemento | Mínimo | Recomendado |
|------|---------|-------------|
| OS | Windows con [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) | Windows 11 |
| Memoria | - | 16 GB o más |
| CPU | - | 8 núcleos o más (las intensidades de imagen se almacenan en doble precisión y el procesamiento es multihilo) |

## Inicio rápido

1. Descarga e instala desde [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Lee una imagen de difracción (**Archivo (File) → Leer imagen (Read image)**, o arrastrar y soltar).
3. Configura **Fuente de ondas (Wave source)** y **Condición del detector (Detector condition)** (longitud de cámara, tamaño de píxel, centro aproximado) en la ventana de propiedades.
4. Si la geometría (longitud de cámara, longitud de onda, inclinación) es desconocida, calíbrala primero con una imagen de una muestra de referencia y aplica los valores — véase [Procedimientos](4-procedures.md).
5. En la imagen de la muestra, busca el centro, enmascara los puntos si es necesario y pulsa **Obtener perfil (Get Profile)** para obtener el perfil 1D.

Véase [Procedimientos](4-procedures.md) para el flujo de trabajo completo.

## Cómo usar este manual

Este manual de GitHub Pages es la fuente de referencia actual. Usa la navegación de la izquierda para explorar por capítulo, o la búsqueda de la cabecera para encontrar un nombre de función o una etiqueta de la interfaz. Sustituye al antiguo manual en Word/HTML/PDF que se distribuía en `IPAnalyzer/doc/`.

## Licencia

IPAnalyzer se distribuye bajo la [Licencia MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
