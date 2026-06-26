<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# Manual de IPAnalyzer

## Breve introducción

* **IPAnalyzer** es software libre con licencia MIT que convierte imágenes bidimensionales de difracción de polvo (anillos de Debye–Scherrer) registradas con Imaging Plates (IP) o detectores de panel plano CCD/CMOS en perfiles unidimensionales 2θ–intensidad de alta precisión.
* Calibra la geometría de medición — longitud de cámara, longitud de onda, inclinación del detector y forma de píxel — a partir de los anillos de materiales de referencia, admite fuentes de rayos X, electrones y neutrones, y se integra con [PDIndexer](https://github.com/seto77/PDIndexer) para el análisis posterior de picos.
* Su diseño y funciones siguen los de *PIP*, desarrollado por Hiroshi Fujihisa en AIST.

## Buscar por objetivo

| Objetivo | Empieza aquí | Pasos principales siguientes |
|------|------------|-----------------|
| Comprender el sistema de coordenadas y la geometría | [Visión general](0-overview.md) | [Ventanas de propiedades](2-property-windows.md) |
| Cargar una imagen y obtener un perfil 1D | [Procedimientos](4-procedures.md) | [Ventana principal](1-main-window.md), [Ventanas de propiedades](2-property-windows.md) |
| Calibrar la longitud de cámara / longitud de onda | [Procedimientos](4-procedures.md) | [Herramientas](3-tools.md), [Buscar parámetros (fuerza bruta)](6-find-parameter.md) |
| Enmascarar puntos / gestionar datos multifotograma | [Herramientas](3-tools.md) | [Procedimientos](4-procedures.md) |
| Automatizar el procesamiento | [Macro](5-macro/index.md) | [Funciones integradas](5-macro/1-built-in-functions.md), [Ejemplos](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## Funciones

* **Amplio soporte de formatos** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4 y formatos de imagen generales. La mayoría de la E/S de archivos admite arrastrar y soltar.
* **Conversión de imagen a perfil** : Cálculo concéntrico (promedio radial), radial (azimutal/cake) e imagen desenrollada, mediante un algoritmo de distribución de área subpíxel que gestiona correctamente la inclinación del detector y las formas de píxel en paralelogramo.
* **Calibración de la geometría** : Refinamiento geométrico (doble casete) de la longitud de onda, longitud de cámara, tamaño/distorsión de píxel e inclinación (φ, τ), además de una búsqueda exhaustiva en cuadrícula (fuerza bruta) para datos difíciles.
* **Manejo de imágenes** : Detección automática del centro del haz, detección y enmascaramiento de puntos de monocristal (spot), desenfoque circunferencial, superposiciones de anillos, calibración del detector por tabla de intensidades y guardado IPA que preserva la geometría.
* **Datos multifotograma** : Seleccionar, promediar o sumar fotogramas de HDF5/NeXus y otros datos secuenciales, con longitud de onda por fotograma a partir de la energía incrustada.
* **Automatización** : Auto Procedure con supervisión de carpeta y una [macro](5-macro/index.md) de sintaxis Python para el procesamiento por lotes y mediante scripts.
* **Integración con PDIndexer** : Envía perfiles a [PDIndexer](https://github.com/seto77/PDIndexer) a través del portapapeles y activa macros con nombre allí.
* **Tema claro / oscuro** : La interfaz sigue un modo de color claro u oscuro seleccionable.

## Requisitos del sistema

| Elemento | Mínimo | Recomendado |
|------|---------|-------------|
| OS | Windows con [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) | Windows 11 |
| Memoria | - | 16 GB o más |
| CPU | - | 8+ núcleos (las intensidades de imagen se almacenan en doble precisión y el procesamiento es multihilo) |

## Inicio rápido

1. Descarga e instala desde [Releases](https://github.com/seto77/IPAnalyzer/releases/latest).
2. Lee una imagen de difracción (File → Read image, o arrastrar y soltar).
3. Configura **Wave source** y **Detector condition** (longitud de cámara, tamaño de píxel, centro aproximado) en la ventana de propiedades.
4. Encuentra el centro, enmascara los puntos si es necesario y pulsa **Get Profile** para obtener el perfil 1D.
5. Si la geometría es desconocida, calíbrala a partir de un material de referencia — véase [Procedimientos](4-procedures.md).

Véase [Procedimientos](4-procedures.md) para el flujo de trabajo completo.

## Cómo usar este manual

Este manual de GitHub Pages es la fuente de referencia actual. Usa la navegación de la izquierda para explorar por capítulo, o usa la búsqueda en la cabecera para encontrar un nombre de función o una etiqueta de la interfaz. Reemplaza al antiguo manual en Word/HTML/PDF que se distribuía en `IPAnalyzer/doc/`.

## Licencia

IPAnalyzer se distribuye bajo la [Licencia MIT](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md).
