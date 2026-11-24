<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Visión general

IPAnalyzer convierte, con alta precisión y rapidez, los anillos de Debye–Scherrer registrados con Imaging Plates (IP) o detectores CCD/CMOS en perfiles de difracción 1D. Su diseño y funciones se inspiran en PIP, desarrollado por Hiroshi Fujihisa en el National Institute of Advanced Industrial Science and Technology (AIST).

Funciones principales:

- Admite una amplia gama de formatos de imagen (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`) y formatos de imagen generales)
- Fuentes de rayos X, electrones y neutrones
- Integración con PDIndexer
- Análisis semiautomático de los parámetros de medición

## Requisitos del sistema e instalación

### Requisitos

Estos requisitos se aplican a las compilaciones .NET 11 de este árbol de código fuente. Para las versiones publicadas, sigue el requisito de runtime indicado para cada versión.

- OS: Windows (se recomienda Windows 11)
- Runtime necesario: .NET Desktop Runtime 11.0
- Memoria recomendada: 16 GB o más
- CPU recomendada: 8 núcleos o más

Internamente el programa hace un uso intensivo del cálculo multihilo, por lo que una CPU con más núcleos funciona con más fluidez. Las intensidades de imagen se almacenan internamente como valores de coma flotante de doble precisión.

El programa se distribuye bajo la Licencia MIT.

### Instalación

1. Descarga el archivo adecuado para tu PC desde la [página de releases](https://github.com/seto77/IPAnalyzer/releases/latest) de GitHub.
    - `IPAnalyzer-setup.msi`: instalador para PC con Windows convencional (x64) (recomendado). `IPAnalyzerSetup.msi` es idéntico; ese nombre se mantiene para la actualización automática desde versiones antiguas.
    - `IPAnalyzer-setup_arm64.msi`: instalador para Windows on Arm.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`: versión portable (sin instalación; incluye el runtime de .NET), para PC sin derechos de administrador.
2. Para el instalador, instala antes [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) y después ejecuta el `.msi` descargado.
3. Para la versión portable, extrae el ZIP en una carpeta en la que el usuario pueda escribir y ejecuta `IPAnalyzer.exe` (no lo inicies desde dentro del visor del ZIP).

## Orientación de los ejes, inclinación de la IP y forma de píxel

IPAnalyzer utiliza un sistema de coordenadas dextrógiro, con el origen y las direcciones de los ejes definidos como sigue.

- El punto en que el haz de rayos X o de electrones corta la IP (el punto directo) se define como el origen (0, 0, 0), y el eje Z coincide con la dirección del haz.
- Considerando la muestra de tamaño infinitesimal, la distancia entre la posición de la muestra y el origen se define como la longitud de cámara (Camera Length, CL). Por tanto, la muestra se encuentra en \((0,\ 0,\ -\mathrm{CL})\).
- El eje X se alinea con la dirección de barrido del láser de lectura de la IP cuando la IP no está inclinada. Por tanto, el eje Y apunta hacia abajo en la pantalla.
- La inclinación de la IP se expresa como una rotación alrededor de una recta contenida en el plano XY que pasa por el origen: una rotación de \( \tau \) alrededor de la recta que forma un ángulo \( \varphi \) con el eje X.
- La forma del píxel se trata como un paralelogramo descrito por PixSizeX, PixSizeY y \( \xi \). Un \( \xi \) distinto de cero significa que hay un desplazamiento en la posición de inicio del barrido del láser de lectura de la IP. El programa supone que este desplazamiento es constante a lo largo del eje Y.

La longitud de cámara, \( \varphi \), \( \tau \), el tamaño de píxel y \( \xi \) se configuran en la pestaña **Condición del detector (Detector condition)** de la ventana de propiedades (véase [2. Ventanas de propiedades](2-property-windows.md)).

### Relación con (WIN)PIP

En IPAnalyzer, el eje X (la dirección hacia la derecha de la imagen de la IP) se gira en sentido horario un ángulo \( \varphi \), y el eje resultante se gira después \( \tau \). En PIP, el eje Y (la dirección hacia abajo de la imagen de la IP) se gira en sentido antihorario un ángulo \( \beta \), y el eje resultante se gira después \( \Phi \). Por tanto, para convertir \((\beta,\ \Phi)\) de PIP en \((\varphi,\ \tau)\) de IPAnalyzer, usa \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Método de integración de la intensidad de los píxeles

El problema central de la integración de la imagen es cómo repartir entre los pasos de integración la intensidad de un píxel que abarca varios pasos — lo que ocurre siempre que el intervalo de ángulos de dispersión que cubre un píxel se extiende sobre más de un paso de 2θ (con más frecuencia cuanto más fino es el paso).

El programa calcula las intersecciones entre las líneas que delimitan cada paso y el píxel, y reparte la intensidad hallando el área del píxel contenida en cada paso. Para tratar los casos en que el píxel no es exactamente cuadrado — debido a la inclinación de la IP o a la distorsión de la forma del píxel — se calculan sucesivamente las coordenadas de las cuatro esquinas de cada píxel para determinar su forma cuadrilátera. En principio, esto permite repartir la intensidad del píxel de forma suave entre los pasos, por pequeños que sean.

Este algoritmo se usa no solo para la integración ordinaria ángulo–intensidad (integración concéntrica, Concentric Integration), sino también para la integración a lo largo de la circunferencia (integración radial, Radial Integration) y para el cálculo de la imagen desplegada (Unrolled Image).
