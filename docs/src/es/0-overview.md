<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Visión general

IPAnalyzer convierte los anillos de Debye–Scherrer registrados con imaging plates (IP) o detectores CCD/CMOS en perfiles de difracción unidimensionales, con alta precisión y rapidez. Su diseño y características están inspirados en PIP, desarrollado por Hiroshi Fujihisa en el National Institute of Advanced Industrial Science and Technology (AIST).

Características principales:

- Admite una amplia variedad de formatos de imagen (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon y formatos de imagen generales)
- Fuentes de rayos X, electrones y neutrones
- Integración con PDIndexer
- Análisis semiautomático de los parámetros de medición

## Requisitos del sistema e instalación

### Requisitos

- SO: Windows (se recomienda Windows 11)
- Entorno de ejecución requerido: .NET Desktop Runtime 10.0
- Memoria recomendada: 16 GB o más
- CPU recomendada: 8 núcleos o más

Internamente, el software hace un uso intensivo del cálculo multihilo, por lo que una CPU con más núcleos resulta más cómoda. Las intensidades de la imagen se mantienen internamente como valores de punto flotante de doble precisión.

El software se distribuye bajo la licencia MIT.

### Instalación

1. Instale previamente [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Descargue `IPAnalyzerSetup.msi` desde la [página de releases](https://github.com/seto77/IPAnalyzer/releases) de GitHub.
3. Ejecute `IPAnalyzerSetup.msi` para instalar.

## Orientación de los ejes, inclinación de la IP y forma de los píxeles

IPAnalyzer utiliza un sistema de coordenadas de mano derecha, con el origen y las direcciones de los ejes definidos como se indica a continuación.

- El punto donde el haz de rayos X o de electrones interseca la IP (el spot directo) se define como el origen (0, 0, 0), y el eje Z coincide con la dirección del haz.
- Tratando el tamaño de la muestra como infinitesimal, la distancia entre la posición de la muestra y el origen se define como la longitud de cámara (Camera Length, CL). Por tanto, la muestra se ubica en \((0,\ 0,\ -\mathrm{CL})\).
- El eje X se alinea con la dirección de barrido del láser de lectura de la IP cuando la IP no está inclinada. Por tanto, el eje Y apunta hacia abajo en la pantalla.
- La inclinación de la IP se expresa como una rotación alrededor de una línea contenida en el plano XY que pasa por el origen: una rotación de \( \tau \) alrededor de la línea que forma un ángulo \( \varphi \) con el eje X.
- La forma del píxel se trata como un paralelogramo descrito por PixSizeX, PixSizeY y \( \xi \). Un \( \xi \) distinto de cero significa que existe un desplazamiento en la posición inicial del barrido del láser de lectura de la IP. El software supone que este desplazamiento es constante a lo largo del eje Y.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

La longitud de cámara, \( \varphi \), \( \tau \), el tamaño de píxel y \( \xi \) se establecen en la pestaña IP Condition de la ventana de propiedades (véase [2. Ventanas de propiedades](2-property-windows.md)).

### Relación con (WIN)PIP

En IPAnalyzer, el eje X (la dirección hacia la derecha de la imagen de la IP) se rota en sentido horario en \( \varphi \), y el eje resultante se rota luego en \( \tau \). En PIP, el eje Y (la dirección hacia abajo de la imagen de la IP) se rota en sentido antihorario en \( \beta \), y el eje resultante se rota luego en \( \Phi \). Por tanto, para convertir \((\beta,\ \Phi)\) de PIP a \((\varphi,\ \tau)\) de IPAnalyzer, utilice \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Método de integración de la intensidad de los píxeles

El problema central de la unidimensionalización es cómo distribuir, entre los pasos de integración, la intensidad de un píxel que abarca varios pasos, lo que ocurre cuando el intervalo angular del paso es menor que el intervalo entre píxeles (es decir, el tamaño del píxel).

El software calcula las intersecciones entre las líneas que delimitan cada paso y el píxel, y distribuye la intensidad hallando el área del píxel contenida en cada paso. Para manejar los casos en que el píxel no es exactamente cuadrado —debido a la inclinación de la IP o a la distorsión de la forma del píxel— se calculan sucesivamente las coordenadas de las cuatro esquinas de cada píxel para determinar su forma cuadrilátera. En principio, esto permite que la intensidad del píxel se distribuya de forma continua entre los pasos, por pequeños que se hagan los pasos.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

Este algoritmo se utiliza no solo para la integración ordinaria ángulo–intensidad (Concentric Integration), sino también para la integración a lo largo de la circunferencia (Radial Integration) y para el cálculo de la imagen desenrollada (Unrolled Image).
