<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# Anhang A1. Detektorgeometrie und Koordinatentransformationen

Diese Seite definiert mit Gleichungen das **Koordinatensystem, die IP-Verkippungskorrektur und die Pixelform-Korrektur**, mit denen IPAnalyzer Pixelpositionen auf einem Flachdetektor (IP, CCD/CMOS) den Beugungswinkeln zuordnet. Einen Überblick über das Koordinatensystem finden Sie auch auf der [Startseite des Anhangs](index.md) und im [0. Überblick](../0-overview.md).

---

## Koordinatensystem und Parameter

IPAnalyzer verwendet intern durchgehend ein **rechtshändiges** Koordinatensystem.

- Der Punkt, an dem der Röntgen- oder Elektronenstrahl die IP schneidet (der **Direktstrahl**), wird als Ursprung $(0,0,0)$ gewählt, und die $Z$-Achse wird an der Ausbreitungsrichtung des Strahls ausgerichtet.
- Die Probe wird als unendlich klein betrachtet; der Abstand zwischen Probe und Ursprung ist als **Kameralänge** $\mathrm{CL}$ definiert. Die Probenposition ist daher $(0,\ 0,\ -\mathrm{CL})$.
- Die $X$-Achse ist bei unverkippter IP an der Abtastrichtung des Auslese-Lasers ausgerichtet (Richtung nach rechts im Bild). Die $Y$-Achse zeigt daher auf dem Bildschirm nach unten.
- Ein Beugungsring mit dem Kegelwinkel $2\theta$ erscheint auf einer unverkippten $XY$-Ebene als exakter Kreis mit dem Radius $\mathrm{CL}\tan 2\theta$.

![Definition des Koordinatensystems](../../assets/references/geometry-coordinate-system.png){width=520px}

Eine freie Drehung eines 3D-Objekts erfordert grundsätzlich drei Achsen. Da die Verteilung der Debye-Ringe jedoch unter Drehung um die $Z$-Achse invariant ist, kann die $X$-Achse beliebig gewählt werden. Dadurch entfällt ein Freiheitsgrad, sodass sich die IP-Verkippung mit **zwei Variablen** $\varphi,\ \tau$ ausdrücken lässt.

!!! note "Entsprechung zu (WIN)PIP"
    Die frühere Software PIP beschreibt die Verkippung mit einem anderen Winkelpaar $(\beta,\ \Phi)$. Die Umrechnung von $(\beta,\ \Phi)$ in IPAnalyzers $(\varphi,\ \tau)$ lautet $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Einzelheiten finden Sie unter „Beziehung zu (WIN)PIP“ im [0. Überblick](../0-overview.md).

---

## IP-Verkippungskorrektur

Die Verkippung der IP gegenüber der optischen Achse (der $Z$-Achse) wird durch eine Drehung dargestellt, deren Achse eine durch den Ursprung verlaufende, in der $XY$-Ebene liegende Gerade ist. Diese Drehung lässt sich als Drehmatrix $R = R_2\,R_1\,R_2^{-1}$ schreiben: eine Operation, die um $\tau$ ($R_1$) um eine Achse dreht, die zuvor um $\varphi$ um die $Z$-Achse gedreht wurde ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Dies ist äquivalent zu einer Drehung um den Winkel $\tau$ um den Einheitsvektor $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$, der in der $XY$-Ebene mit der $X$-Achse den Winkel $\varphi$ einschließt; ausmultipliziert ergibt sich

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Vorwärtstransformation (unverkippte Ebene → verkippte IP)

Ein Punkt $P_1 = (X,\ Y,\ 0)$ auf der unverkippten $XY$-Ebene wird auf $P_2 = R\,P_1$ auf der verkippten IP abgebildet.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projektion (verkippte IP → unverkippte Ebene)

Tatsächlich benötigt wird die umgekehrte Richtung, nämlich die $XY$-Koordinate, die ein „auf der verkippten IP beobachtetes Pixel“ ohne Verkippung einnehmen würde. Sie ergibt sich aus der **Zentralprojektion (perspektivischen Projektion)**, die den Punkt $P_3$ bestimmt, an dem die Verbindungsgerade zwischen einem Punkt auf der verkippten IP und der Probe $(0,0,-\mathrm{CL})$ die $XY$-Ebene schneidet. Da es sich um eine projektive Transformation mit der Probe als Projektionszentrum handelt, ergibt sich

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Da die Verkippungskorrektur einschließlich der Zentralprojektion eine projektive Transformation ist, die sich in homogenen Koordinaten als Matrix schreiben lässt, kann die Position jedes Pixels auf einem Computer schnell berechnet werden.

---

## Pixelform-Korrektur

Die Pixelform der IP wird als **Parallelogramm** behandelt, mit der Länge $\mathrm{PixSizeX}$ entlang der $X$-Achse, der Länge $\mathrm{PixSizeY}$ entlang der $Y$-Achse und einer Abweichung vom rechten Winkel (Verzerrungswinkel) $\xi$. Ein von null verschiedenes $\xi$ bedeutet, dass die Startposition der Laserabtastung beim Auslesen versetzt ist; die Software nimmt an, dass dieser Versatz entlang der $Y$-Achse konstant ist.

Die tatsächliche Koordinate $P$ des Pixels, das vom Zentralpixel aus gezählt $\mathrm{PixNumX}$ in $X$-Richtung und $\mathrm{PixNumY}$ in $Y$-Richtung entfernt ist, lautet

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Durch die Kombination dieser Pixelform-Korrektur mit der oben beschriebenen Verkippungskorrektur lässt sich jedes Pixel auf einer verkippten IP an seine korrekte Position auf der unverkippten $XY$-Ebene abbilden. Diese Abbildung ist die Grundlage der Parameterbestimmung im nächsten Kapitel und von [A3. Bildintegration](a3-image-integration.md).
