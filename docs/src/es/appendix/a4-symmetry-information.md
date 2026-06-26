<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Apéndice A4. Symmetry Information

**Symmetry Information** muestra información detallada sobre la simetría del grupo espacial del cristal seleccionado y, además, dibuja diagramas esquemáticos de los elementos de simetría y las posiciones generales al estilo de las *International Tables for Crystallography* Vol. A.

En IPAnalyzer, esta subventana se abre desde la **Crystal window** (el CrystalControl utilizado en [4. Procedimientos prácticos](../4-procedures.md) para la calibración geométrica y en [6. Find Parameter (brute force)](../6-find-parameter.md)).

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

La ventana se divide en un área de identidad del grupo espacial (arriba a la izquierda), un área de cálculo/tablas con pestañas (arriba a la derecha) y dos diagramas esquemáticos (abajo).

---

## Atajos de teclado y ratón

Esta ventana no tiene combinaciones especiales de teclas ni de ratón. <kbd>F1</kbd> abre esta página del manual, y los dos botones **Copy** colocan el diagrama de elementos de simetría y el diagrama de posiciones generales en el portapapeles (como mapa de bits, o como EMF vectorial cuando **EMF** está marcado).

---

## Identidad del grupo espacial

El panel superior izquierdo enumera, para el grupo espacial actual:

- **Number** (1–230) y el índice del setting
- **Crystal System**
- **Point Group** : símbolos de Hermann–Mauguin (HM) y Schoenflies (SF)
- **Space Group** : símbolo corto HM, símbolo completo HM, símbolo SF y **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

Introduzca dos planos cristalinos \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) o dos índices de dirección \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) para obtener:

- el d-spacing de cada plano / la longitud de cada eje,
- el ángulo entre los dos planos (o los dos ejes),
- **el índice de dirección normal a ambos planos** y **el índice de plano normal a ambos ejes**.

Estos cálculos respetan la métrica de la celda unidad actual.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

Enumera cada posición de Wyckoff con su multiplicidad, letra de Wyckoff, simetría del sitio y si se trata de una posición general o especial. Para las redes centradas, los vectores de traslación de la red se muestran en la fila de encabezado.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

Las condiciones de reflexión que surgen del centrado de la red y de los operadores de simetría de deslizamiento/tornillo (glide/screw).

---

## Diagramas de elementos de simetría y de posiciones generales

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

Los dos paneles inferiores reproducen los diagramas esquemáticos de simetría del grupo espacial en la notación de las *International Tables for Crystallography* Vol. A.

- **Symmetry elements (izquierda)**: los ejes de rotación/tornillo, los planos de espejo/deslizamiento y los centros de inversión/puntos de rotoinversión se dibujan con los símbolos gráficos convencionales.
  - Para la red \(F\) del sistema cúbico, solo se muestra un octavo de la celda unidad (únicamente el cuadrante superior izquierdo).
- **General positions (derecha)**: las posiciones equivalentes generales se representan como círculos (una coma denota una imagen especular), anotadas con sus coordenadas fraccionarias.
  - Solo para el sistema cúbico, líneas auxiliares conectan los tres círculos relacionados por un eje de rotación de orden tres.

Controles debajo de los diagramas:

- **Direction** (`a` / `b` / `c`) : elija el eje cristalino sobre el que proyectar.
- **Copy** cada diagrama al portapapeles como imagen vectorial (**EMF**) o imagen rasterizada (**BMP**); el EMF puede desagruparse y editarse en PowerPoint.

---

## Véase también

- [Inicio del apéndice](index.md)
- [4. Procedimientos prácticos](../4-procedures.md) — calibración de los parámetros geométricos usando un cristal de referencia.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
