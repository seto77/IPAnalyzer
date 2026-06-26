<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Anhang A2. Parameterbestimmung

Da die Position jedes Pixels durch die Geometrie aus [A1. Detektorgeometrie](a1-geometry.md) bestimmt wird, bedeutet die Verwendung falscher Parameter, dass Intensitäten an den falschen Stellen ausgelesen werden. Diese Seite erläutert, wie die wahren Parameter — Kameralänge, Wellenlänge, Pixelgröße und IP-Verkippung — aus den Beugungsringen eines **Standardmaterials** bestimmt werden. Zu den konkreten Arbeitsschritten siehe [4. Arbeitsabläufe](../4-procedures.md) und [6. Parameterkalibrierung (Brute-Force)](../6-find-parameter.md).

---

## Standardmaterial

Zur Kalibrierung misst man ein Standardmaterial, dessen Gitterkonstanten bekannt sind. Wünschenswert sind **viele Beugungsringe** mit einem **hohen SN-Verhältnis**, die **dünn verteilt** liegen und **keine Vorzugsorientierung** aufweisen. Sofern keine besondere Präferenz besteht, empfiehlt sich ein kubischer Kristall mit schweren Atomen wie $\mathrm{CeO_2}$ oder $\mathrm{Ag}$. Die Gitterkonstanten müssen auf etwa 5 signifikante Stellen genau bekannt sein.

---

## Kameralänge — Zwei-Abstands-Methode

Die Kameralänge $\mathrm{CL}$ ist definiert als der Abstand zwischen der Probe und dem Direktstrahlfleck auf der IP. Nimmt man zwei Beugungsmuster auf, während man die Kameralänge um $\Delta$ verändert, lässt sich der Absolutwert von $\mathrm{CL}$ aus der Änderung des Radius (in Pixeln) $r_1,\ r_2$ desselben Rings bestimmen. Die Abstandsdifferenz $\Delta$ kann mit einem Magnescale oder einem ähnlichen Gerät präzise eingestellt werden.

![Zwei-Abstands-Bestimmung der Kameralänge. Derselbe Ring wird an zwei Positionen aufgenommen, in den Abständen CL und CL+Δ von der Probe, und CL wird aus den Radien r₁, r₂ gewonnen.](../../assets/references/calibration-camera-length.svg){width=440px}

Aus den ähnlichen Dreiecken $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ ergibt sich

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

Dabei können $r_1,\ r_2$ in Pixeleinheiten verbleiben, und die Kameralänge lässt sich selbst dann bestimmen, wenn die Verkippungskorrektur und die Pixelgrößenkorrektur etwas ungenau sind und sogar wenn die Gitterkonstanten des Standards ungenau sind. Da die Kameralänge somit nur eine geringe Korrelation mit den übrigen Parametern aufweist, ist sie der **Parameter, der zuerst bestimmt werden sollte**.

---

## Wellenlänge und Pixelgröße — Zwei-Linien-Methode

Lassen sich zwei Beugungslinien aufnehmen, so können die Beugungswinkel $\theta_1,\ \theta_2$ aus dem Verhältnis ihrer Peakpositionen (in Pixeln) $p_1,\ p_2$ und ihrer d-spacings $d_1,\ d_2$ berechnet werden, ohne dass die Pixelgröße oder die Kameralänge bekannt sein müssen. Sei das d-spacing-Verhältnis $\rho_d = d_1/d_2$ und das Peakpositions-Verhältnis $\rho_p = p_1/p_2$.

Aus dem Braggschen Gesetz und der Geometrie des Flachdetektors gelten

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

Aus dem Verhältnis der ersten Gleichung folgt $\sin\theta_2 = \rho_d \sin\theta_1$, und aus dem Verhältnis der zweiten Gleichung $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$. Einsetzen von $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ ergibt eine Gleichung, deren einzige Unbekannte $\sin\theta_1$ ist:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

Dies lässt sich auf eine kubische Gleichung in $\sin^2\theta_1$ zurückführen. Da eine analytische Lösung die Behandlung imaginärer Zahlen erfordern würde, löst diese Software sie **numerisch**, um den Wert zu erhalten. Da $\rho_d$ ein Verhältnis von d-spacings ist, kann es je nach Kristallsymmetrie (zum Beispiel im kubischen System) fehlerfrei bestimmt werden.

Sind die Beugungswinkel einmal ermittelt, lässt sich die Kameralänge mit der oben beschriebenen Zwei-Abstands-Methode unabhängig bestimmen, sodass auch die Wellenlänge $\lambda$ und die Pixelgröße $\mathrm{PixSize}$ leicht aus den beiden obigen Gleichungen berechnet werden können.

!!! note "Bei vorhandener Verkippung"
    Ist die IP verkippt, so bricht die Beziehung $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ zusammen, sodass die genauen Werte nicht ohne Weiteres erhalten werden können. In diesem Fall **führt man die Verkippungskorrektur und die Wellenlängenkorrektur abwechselnd durch**, um die Lösung iterativ gegen den wahren Wert konvergieren zu lassen.

---

## IP-Verkippung — Ellipsenanpassung

Ein Ring mit Kegelwinkel $2\theta$ sollte auf einer unverkippten $XY$-Ebene als wahrer Kreis mit Radius $R_0 = \mathrm{CL}\tan 2\theta$ beobachtet werden. Auf einer verkippten IP wird der Ring jedoch zu einer **Ellipse**, und darüber hinaus fällt sein Mittelpunkt nicht mit dem Strahlzentrum (dem Direktstrahlfleck) zusammen.

![Auf einer verkippten IP wird der Beugungsring zu einer Ellipse, und ihr Mittelpunkt ist gegenüber dem Direktstrahlfleck versetzt (Projektion entlang der φ-Richtung betrachtet).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

Auf einer um $\varphi,\ \tau$ verkippten IP-Ebene erfüllt ein Punkt $(x,y)$ auf dem Ring einen allgemeinen Kegelschnitt (eine Ellipse)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

Die Koeffizienten $A,B,C,D,E$ lassen sich als Funktionen von $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ schreiben und können wie folgt mit elementarer linearer Algebra behandelt werden.

- Der **Mittelpunkt der Ellipse** $(x_c, y_c)$ ist die Lösung der Bedingung, dass der Gradient verschwindet, also des linearen Gleichungssystems
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- Die **Richtungen und Längen der Haupt- und Nebenachsen** ergeben sich aus der Lösung des Eigenwertproblems der symmetrischen Matrix $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$.

Daraus wird die Verkippung wie folgt bestimmt.

1. **Azimut $\varphi$**: Die Verschiebung des Ellipsenmittelpunkts erfolgt entlang der Richtung der stärksten Verkippung (der Richtung des maximalen Gradienten), und die Kippachse steht orthogonal dazu. Daher ist die Richtung der Kippachse durch $(-y_c,\ x_c)$ gegeben, woraus sich $\varphi$ bestimmt.
2. **Verkippungsbetrag $\tau$**: Betrachtet man die entlang der $\varphi$-Richtung projizierte Figur (die obige Abbildung), so erfüllt der Abstand $R$ vom Direktstrahlfleck zum Ellipsenmittelpunkt eine Funktion der Kameralänge, des Verkippungsbetrags und des Beugungswinkels:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    Löse diese Gleichung nach $\tau$ auf. Stehen mehrere Beugungsringe zur Verfügung, so nimmt man den **gewichteten Mittelwert** der aus jedem Ring erhaltenen $\tau$ als wahren Wert.
