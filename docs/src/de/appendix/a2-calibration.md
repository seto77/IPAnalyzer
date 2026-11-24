<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# Anhang A2. Parameterbestimmung

Da die Position jedes Pixels durch die Geometrie aus [A1. Detektorgeometrie](a1-geometry.md) bestimmt wird, führen falsche Parameter dazu, dass Intensitäten an falschen Stellen gelesen werden. Diese Seite erläutert, wie die wahren Parameter — Kameralänge, Wellenlänge, Pixelgröße und IP-Verkippung — aus den Beugungsringen eines **Standardmaterials** bestimmt werden. Die praktische Bedienung finden Sie unter [4. Arbeitsabläufe](../4-procedures.md) und [6. Parameter finden (Brute Force)](../6-find-parameter.md).

---

## Standardmaterial

Für die Kalibrierung messen Sie ein Standardmaterial mit bekannten Gitterkonstanten. Wünschenswert sind **viele Beugungsringe** mit **hohem Signal-Rausch-Verhältnis**, die **weit auseinander** liegen, und **keine Vorzugsorientierung**. Sofern Sie keine besondere Präferenz haben, wird ein kubischer Kristall mit schweren Atomen wie $\mathrm{CeO_2}$ oder $\mathrm{Ag}$ empfohlen. Die Gitterkonstanten müssen auf etwa 5 signifikante Stellen bekannt sein.

---

## Kameralänge — Zwei-Abstands-Methode

Die Kameralänge $\mathrm{CL}$ ist als Abstand zwischen der Probe und dem Direktstrahl auf der IP definiert. Nimmt man zwei Beugungsbilder auf und ändert dabei die Kameralänge um $\Delta$, lässt sich der Absolutwert von $\mathrm{CL}$ aus der Änderung der Radien $r_1,\ r_2$ desselben Rings bestimmen. Die Abstandsdifferenz $\Delta$ kann mit einer Magnescale oder einem ähnlichen Gerät genau eingestellt werden.

![Bestimmung der Kameralänge mit zwei Abständen. Derselbe Ring wird an zwei Positionen im Abstand CL und CL+Δ von der Probe aufgezeichnet, und CL ergibt sich aus den Radien r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

Aus den ähnlichen Dreiecken $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ (mit $r_i$ in derselben Längeneinheit wie $\mathrm{CL}$) erhält man

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

Dabei dürfen $r_1,\ r_2$ in Pixeleinheiten bleiben, und die Kameralänge lässt sich auch dann bestimmen, wenn Verkippungs- und Pixelgrößenkorrektur etwas ungenau sind und sogar wenn die Gitterkonstanten des Standards ungenau sind. Da die Kameralänge somit kaum mit den anderen Parametern korreliert, ist sie der **Parameter, der zuerst bestimmt werden sollte**.

---

## Wellenlänge und Pixelgröße — Zwei-Linien-Methode

Lassen sich zwei Beugungslinien aufzeichnen, können die Bragg-Winkel $\theta_1,\ \theta_2$ aus dem Verhältnis ihrer Peakpositionen (in Pixeln) $p_1,\ p_2$ und ihrer d-Werte $d_1,\ d_2$ berechnet werden, ohne Pixelgröße oder Kameralänge zu kennen. Das Verhältnis der d-Werte sei $\rho_d = d_1/d_2$ und das Verhältnis der Peakpositionen $\rho_p = p_1/p_2$.

Aus dem Braggschen Gesetz und der Geometrie des Flachdetektors gelten

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

Aus dem Verhältnis der ersten Gleichung folgt $\sin\theta_2 = \rho_d \sin\theta_1$, aus dem Verhältnis der zweiten $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Durch Einsetzen von $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ erhält man eine Gleichung, deren einzige Unbekannte $\sin\theta_1$ ist:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Dies führt auf eine kubische Gleichung in $\sin^2\theta_1$. Da eine analytische Lösung den Umgang mit imaginären Zahlen erfordern würde, löst die Software sie **numerisch**. Da $\rho_d$ ein Verhältnis von d-Werten ist, lässt es sich je nach Kristallsymmetrie (etwa im kubischen System) fehlerfrei bestimmen.

Sind die Beugungswinkel bekannt, kann die Kameralänge mit der oben beschriebenen Zwei-Abstands-Methode unabhängig bestimmt werden; damit lassen sich auch die Wellenlänge $\lambda$ und die Pixelgröße $\mathrm{PixSize}$ leicht aus den beiden obigen Gleichungen berechnen.

!!! note "Bei vorhandener Verkippung"
    Ist die IP verkippt, gilt die Beziehung $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ nicht mehr, sodass sich die genauen Werte nicht unmittelbar ergeben. In diesem Fall **führen Sie Verkippungskorrektur und Wellenlängenkorrektur abwechselnd durch**, um die Lösung iterativ gegen den wahren Wert konvergieren zu lassen.

---

## IP-Verkippung — Ellipsenanpassung

Ein Ring mit dem Kegelwinkel $2\theta$ sollte auf einer unverkippten $XY$-Ebene als exakter Kreis mit dem Radius $R_0 = \mathrm{CL}\tan 2\theta$ erscheinen. Auf einer verkippten IP wird der Ring jedoch zu einer **Ellipse**, und deren Zentrum fällt zudem nicht mit dem Strahlzentrum (dem Direktstrahl) zusammen.

![Auf einer verkippten IP wird der Beugungsring zu einer Ellipse, deren Zentrum gegenüber dem Direktstrahl versetzt ist (Projektion in φ-Richtung gesehen).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Auf einer um $\varphi,\ \tau$ verkippten IP-Ebene erfüllt ein Punkt $(x,y)$ auf dem Ring einen allgemeinen Kegelschnitt (Ellipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Die Koeffizienten $A,B,C,D,E$ lassen sich als Funktionen von $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ schreiben und mit elementarer linearer Algebra wie folgt behandeln.

- Das **Zentrum der Ellipse** $(x_c, y_c)$ ist die Lösung der Bedingung, dass der Gradient verschwindet, also des linearen Gleichungssystems
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Die **Richtungen und Längen der Haupt- und Nebenachse** ergeben sich aus dem Eigenwertproblem der symmetrischen Matrix $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

Daraus wird die Verkippung wie folgt bestimmt.

1. **Azimut $\varphi$**: Die Verschiebung des Ellipsenzentrums erfolgt entlang der Richtung der stärksten Neigung (Richtung des maximalen Gradienten), und die Kippachse steht senkrecht darauf. Die Richtung der Kippachse ist daher durch $(-y_c,\ x_c)$ gegeben, woraus sich $\varphi$ bestimmt.
2. **Betrag der Verkippung $\tau$**: Betrachtet man die in $\varphi$-Richtung projizierte Darstellung (Abbildung oben), erfüllt der Abstand $R$ vom Direktstrahl zum Ellipsenzentrum eine Funktion von Kameralänge, Verkippungsbetrag und Beugungswinkel:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Lösen Sie diese Gleichung nach $\tau$ auf. Stehen mehrere Beugungsringe zur Verfügung, nehmen Sie den **gewichteten Mittelwert** der aus den einzelnen Ringen erhaltenen $\tau$ als wahren Wert.
