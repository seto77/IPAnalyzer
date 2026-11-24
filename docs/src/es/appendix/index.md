<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Apéndice

Este apéndice resume el **fundamento teórico de la geometría y los algoritmos** que IPAnalyzer utiliza al convertir una imagen de difracción bidimensional (anillos de Debye–Scherrer) en un perfil 1D de alta precisión. Para los procedimientos de operación y el uso de cada función, consulta el manual principal ([0. Visión general](../0-overview.md), [4. Procedimientos](../4-procedures.md), etc.). Aquí se explican, con ecuaciones, las definiciones del sistema de coordenadas, las transformaciones de coordenadas, los métodos de determinación de parámetros y el algoritmo de integración en que se basa.

El contenido se basa en el documento heredado `doc/IPAnalyzerAlgorithm.pdf` incluido en el paquete de distribución y en la implementación actual.

## Estructura del apéndice

- **[A1. Geometría del detector y transformaciones de coordenadas](a1-geometry.md)** — definición del sistema de coordenadas dextrógiro, las matrices de rotación que describen la inclinación de la IP ($\varphi,\ \tau$) y la corrección de la forma del píxel ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Determinación de parámetros](a2-calibration.md)** — calibración de la longitud de cámara, la longitud de onda, el tamaño de píxel y la inclinación de la IP mediante un material de referencia (método de dos distancias, método de dos líneas, ajuste de elipses).
- **[A3. Integración de la imagen](a3-image-integration.md)** — el algoritmo de partición de áreas que distribuye las intensidades de los píxeles entre los pasos angulares, y la normalización tras la integración.
- **[A4. Información de simetría](a4-symmetry-information.md)** — simetría del grupo espacial, cálculos geométricos, posiciones de Wyckoff, condiciones de reflexión y diagramas de elementos de simetría del cristal de referencia (una subventana de la ventana de cristal).
- **[A5. Factor de dispersión](a5-scattering-factor.md)** — factores de estructura y lista de reflexiones del cristal de referencia (rayos X, electrones, neutrones) (la pestaña **Reflexiones (Reflections)** de **Interacción del haz (Beam interaction)** en la ventana de cristal).

## Sistema de coordenadas (figura de referencia común)

Cada una de las páginas siguientes parte del mismo sistema de coordenadas como premisa común. El origen es el punto directo sobre la IP (el punto en que el haz corta la IP), el eje $Z$ es la dirección de propagación del haz y la muestra se encuentra en $(0,\ 0,\ -\mathrm{CL})$.

![Sistema de coordenadas de IPAnalyzer. Muestra la IP (Imaging Plate), los ejes X / Y / Z, los anillos de Debye, los ángulos de inclinación φ y τ, la muestra en (0,0,−CL), la longitud de cámara CL, el ángulo de difracción 2θ, la longitud de onda λ y la forma del píxel (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Parámetros principales

| Símbolo | Nombre | Significado |
|------|------|------|
| $\lambda$ | Longitud de onda (Wave Length) | Longitud de onda de la fuente. Es conocida para los rayos X característicos; para la radiación sincrotrón varía con la posición del monocromador y debe determinarse cada vez. |
| $\mathrm{CL}$ | Longitud de cámara (Camera Length) | Distancia entre la muestra y el origen (punto directo). La posición de la muestra es $(0,0,-\mathrm{CL})$. Corresponde a **Longitud de cámara 1 (Camera Length 1)** en pantalla; **Longitud de cámara 2 (Camera Length 2)** es la distancia perpendicular de la muestra al detector, que difiere cuando hay una inclinación $\tau$. |
| $\varphi,\ \tau$ | Corrección de inclinación (Tilt Correction) | Inclinación de la IP respecto al eje óptico (eje $Z$). $\varphi$ es el azimut del eje de inclinación en el plano XY y $\tau$ es el ángulo de rotación alrededor de ese eje. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Tamaño de píxel (Pixel Size) | Representa un píxel como un paralelogramo. $\xi$ es el desplazamiento del punto de inicio del barrido del láser de lectura (ángulo de distorsión). |

La longitud de onda se configura en la pestaña **Fuente de ondas (Wave source)** de la ventana de propiedades, y la longitud de cámara, la inclinación y la forma del píxel en la pestaña **Condición del detector (Detector condition)** (véase [2. Ventanas de propiedades](../2-property-windows.md)).
