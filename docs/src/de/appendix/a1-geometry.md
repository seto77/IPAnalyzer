<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Anhang A1. Detektorgeometrie und Koordinatentransformationen

Diese Seite definiert mit Gleichungen das **Koordinatensystem, die IP-Verkippungskorrektur und die Pixelform-Korrektur**, die IPAnalyzer verwendet, um Pixelpositionen auf einem flachen Detektor (IP, CCD/CMOS) auf Beugungswinkel abzubilden. Für einen Überblick über das Koordinatensystem siehe auch die [Übersichtsseite des Anhangs](index.md) und [0. Überblick](../0-overview.md).

---

## Koordinatensystem und Parameter

IPAnalyzer verwendet intern durchgängig ein **rechtshändiges** Koordinatensystem.

- Der Punkt, an dem der Röntgen- oder Elektronenstrahl die IP durchstößt (der **direkte Spot**), wird als Ursprung $(0,0,0)$ gewählt, und die $Z$-Achse ist mit der Ausbreitungsrichtung des Strahls ausgerichtet.
- Wird die Probe als infinitesimal klein behandelt, so wird der Abstand zwischen Probe und Ursprung als **Kameralänge** $\mathrm{CL}$ definiert. Die Probenposition ist daher $(0,\ 0,\ -\mathrm{CL})$.
- Die $X$-Achse ist bei nicht verkippter IP mit der Scanrichtung des Auslese-Lasers ausgerichtet (die Richtung nach rechts im Bild). Die $Y$-Achse zeigt daher auf dem Bildschirm nach unten.
- Ein Beugungsring mit Kegelwinkel $2\theta$ wird auf einer unverkippten $XY$-Ebene als perfekter Kreis mit Radius $\mathrm{CL}\tan 2\theta$ beobachtet.

![Definition des Koordinatensystems](../../assets/references/geometry-coordinate-system.png){width=520px}

Die freie Rotation eines 3D-Objekts erfordert grundsätzlich drei Achsen, doch da die Verteilung des Debye-Rings unter Rotation um die $Z$-Achse invariant ist, kann die $X$-Achse beliebig gewählt werden. Dies entfernt einen Freiheitsgrad, sodass die IP-Verkippung mit **zwei Variablen** $\varphi,\ \tau$ ausgedrückt werden kann.

!!! note "Korrespondenz mit (WIN)PIP"
    Die Altsoftware PIP drückt die Verkippung mit einem anderen Winkelpaar $(\beta,\ \Phi)$ aus. Die Umrechnung von $(\beta,\ \Phi)$ in IPAnalyzers $(\varphi,\ \tau)$ lautet $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$. Einzelheiten siehe „Beziehung zu (WIN)PIP" in [0. Überblick](../0-overview.md).

---

## IP-Verkippungskorrektur

Die Verkippung der IP gegenüber der optischen Achse (der $Z$-Achse) wird durch eine Rotation dargestellt, deren Achse eine Gerade ist, die durch den Ursprung verläuft und in der $XY$-Ebene liegt. Diese Rotation lässt sich als Rotationsmatrix $R = R_2\,R_1\,R_2^{-1}$ schreiben, eine Operation, die um $\tau$ entlang ($R_1$) einer Achse rotiert, die zuvor um $\varphi$ um die $Z$-Achse gedreht wurde ($R_2$).

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

Dies ist äquivalent zu einer Rotation um den Winkel $\tau$ um den Einheitsvektor $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$, der mit der $X$-Achse in der $XY$-Ebene den Winkel $\varphi$ bildet, und das Ausmultiplizieren liefert

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

Tatsächlich benötigt wird die umgekehrte Richtung, nämlich die $XY$-Ebenenkoordinate, die ein „auf der verkippten IP beobachtetes Pixel" einnehmen würde, wenn keine Verkippung vorläge. Diese ergibt sich aus der **zentralen (perspektivischen) Projektion**, die den Punkt $P_3$ bestimmt, in dem die Verbindungsgerade zwischen einem Punkt auf der verkippten IP und der Probe $(0,0,-\mathrm{CL})$ die $XY$-Ebene schneidet. Da es sich um eine projektive Transformation mit der Probe als Projektionszentrum handelt, ergibt sich

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

Da die gesamte Verkippungskorrektur eine lineare (in homogenen Koordinaten projektive) Transformation ist, lässt sich die Position jedes Pixels auf einem Computer schnell berechnen.

---

## Pixelform-Korrektur

Die Pixelform der IP wird als **Parallelogramm** behandelt, mit der Länge $\mathrm{PixSizeX}$ entlang der $X$-Achse, der Länge $\mathrm{PixSizeY}$ entlang der $Y$-Achse und einer Abweichung vom rechten Winkel (Verzerrungswinkel) $\xi$. Ein von null verschiedenes $\xi$ bedeutet, dass es einen Versatz in der Startposition des Auslese-Laserscans gibt, und diese Software nimmt an, dass dieser Versatz entlang der $Y$-Achse konstant ist.

Die tatsächliche Koordinate $P$ des Pixels, das vom zentralen Pixel aus gezählt um $\mathrm{PixNumX}$ in $X$-Richtung und um $\mathrm{PixNumY}$ in $Y$-Richtung entfernt ist, ergibt sich zu

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

Durch Kombination dieser Pixelform-Korrektur mit der oben beschriebenen Verkippungskorrektur lässt sich jedes Pixel auf einer verkippten IP auf seine korrekte Position auf der unverkippten $XY$-Ebene abbilden. Diese Abbildung bildet die Grundlage für die Parameterbestimmung im nächsten Kapitel und für [A3. Bildintegration](a3-image-integration.md).
