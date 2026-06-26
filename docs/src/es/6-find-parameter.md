<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

El modo de fuerza bruta varía cada parámetro de forma exhaustiva (una búsqueda en cuadrícula) para encontrar los valores que mejor satisfacen:

- picos agudos (es decir, FWHM pequeño), y
- desviación pequeña de los valores d.

Es eficaz para anillos incompletos o datos ruidosos, donde la optimización geométrica tiene dificultades para converger. Consulte [Herramientas](3-tools.md) para una visión general de la herramienta y [Procedimientos](4-procedures.md) para el flujo básico.

## Pasos

1. Cargue los datos de la imagen y los parámetros, luego haga clic en **Find Parameter (brute force)**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Seleccione el **standard material**. Si no está en la lista, elija **Others** e introdúzcalo manualmente.
3. Muestre el perfil con **Get profile**.
4. Haga doble clic en cualquier línea de pico que no desee usar para la optimización para excluirla.
5. Configure las opciones y pulse **Optimize** para iniciar la optimización.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Especifica el rango angular ajustado para cada pico.

### Number of repetitions

Especifica el número de ciclos de optimización.

### Per-parameter options

La optimización se realiza sobre los elementos marcados. Cada parámetro se desplaza sobre el rango especificado (**Search range**) en el paso especificado (**Initial step**).

Por ejemplo, si la longitud de cámara comienza en 100 mm con un Initial step de 0,05 mm y un Search range de 4, entonces se prueban 9 (= Search range × 2 + 1) longitudes de cámara: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Cuando los recuentos de pruebas de los parámetros son N1, N2, N3, …, el número total de pruebas por ciclo es N1 × N2 × N3 × …. En el ejemplo anterior, con cuatro parámetros en Search range 4, 4, 3 y 6, esto es (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 pruebas. En otras palabras, se prueban 7371 conjuntos de parámetros, y se elige la combinación con los picos más agudos y la menor desviación de los valores d.

!!! warning
    Aumentar **Search range** incrementa bruscamente el número de pruebas y alarga cada ciclo. Úselo con cuidado.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Durante la calibración, se muestra una pantalla de estado como la anterior.

- **Cycle**: el número de ciclo actual. Cuando un ciclo termina, el mejor conjunto de parámetros encontrado en él se convierte en el punto de partida del siguiente ciclo. Si los mejores parámetros son idénticos a los del ciclo anterior, el paso se multiplica por 0,8 para el siguiente ciclo.
- **Current best values**: los mejores parámetros en ese momento.
- **Current steps**: el paso de cada parámetro en ese momento.
- **No1, No2, …**: los 5 mejores valores de evaluación en el ciclo. Caen rápidamente al principio y convergen a medida que se aproxima al óptimo.

## Evaluation value R

El valor de evaluación R se calcula de la siguiente manera.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Aquí *H* es la altura del pico con el fondo restado.
