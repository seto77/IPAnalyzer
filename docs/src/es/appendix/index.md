<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Apéndice

Este apéndice resume los **fundamentos teóricos de la geometría y los algoritmos** que IPAnalyzer utiliza al convertir una imagen de difracción bidimensional (anillos de Debye–Scherrer) en un perfil unidimensional de alta precisión. Para los procedimientos de operación y el uso de cada función, consulte el manual principal ([0. Visión general](../0-overview.md), [4. Procedimientos prácticos](../4-procedures.md), etc.). Aquí se explican, con ecuaciones, las definiciones del sistema de coordenadas, las transformaciones de coordenadas, los métodos de determinación de parámetros y el algoritmo de integración que hay detrás.

El contenido se basa en el documento heredado `doc/IPAnalyzerAlgorithm.pdf` incluido en el paquete de distribución y en la implementación actual.

## Estructura del apéndice

- **[A1. Detector geometry and coordinate transforms](a1-geometry.md)** — definición del sistema de coordenadas de mano derecha, las matrices de rotación que describen la inclinación de la IP ($\varphi,\ \tau$) y la corrección de la forma del píxel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Parameter determination](a2-calibration.md)** — calibración de la longitud de cámara, la longitud de onda, el tamaño de píxel y la inclinación de la IP usando un material de referencia (método de dos distancias, método de dos líneas, ajuste de elipse).
- **[A3. Image integration](a3-image-integration.md)** — el algoritmo de partición de área que distribuye las intensidades de los píxeles en pasos angulares.
- **[A4. Symmetry information](a4-symmetry-information.md)** — simetría del grupo espacial, cálculos geométricos, posiciones de Wyckoff, condiciones de reflexión y diagramas de elementos de simetría del cristal de referencia (una subventana de la ventana Crystal).
- **[A5. Scattering factor](a5-scattering-factor.md)** — factores de estructura y la lista de reflexiones del cristal de referencia (rayos X, electrones, neutrones) (una subventana de la ventana Crystal).

## Sistema de coordenadas (figura de referencia común)

Cada una de las páginas siguientes asume el mismo sistema de coordenadas como premisa común. El origen es el punto directo sobre la IP (el punto donde el haz interseca la IP), el eje $Z$ es la dirección de propagación del haz y la muestra se sitúa en $(0,\ 0,\ -\mathrm{CL})$.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parámetros principales

| Símbolo | Nombre | Significado |
|------|------|------|
| $\lambda$ | Wave Length | Longitud de onda de la fuente. Es conocida para los rayos X característicos; en la radiación de sincrotrón varía con la posición del monocromador y debe determinarse cada vez. |
| $\mathrm{CL}$ | Camera Length | Distancia entre la muestra y el origen (punto directo). La posición de la muestra es $(0,0,-\mathrm{CL})$. |
| $\varphi,\ \tau$ | Tilt Correction | Inclinación de la IP respecto al eje óptico (eje $Z$). $\varphi$ es el azimut del eje de inclinación en el plano XY, y $\tau$ es el ángulo de rotación alrededor de ese eje. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | Representa un píxel como un paralelogramo. $\xi$ es el desplazamiento del punto de inicio del barrido del láser de lectura (ángulo de distorsión). |

Estos valores se establecen en la pestaña IP Condition de la ventana de propiedades (véase [2. Property windows](../2-property-windows.md)).
