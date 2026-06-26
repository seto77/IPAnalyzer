<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Anhang

Dieser Anhang fasst den **theoretischen Hintergrund der Geometrie und der Algorithmen** zusammen, die IPAnalyzer bei der Umwandlung eines zweidimensionalen Beugungsbildes (Debye–Scherrer-Ringe) in ein hochgenaues eindimensionales Profil verwendet. Für die Bedienschritte und die Verwendung der einzelnen Funktionen sei auf das Haupthandbuch verwiesen ([0. Überblick](../0-overview.md), [4. Arbeitsabläufe](../4-procedures.md) usw.). Hier werden mit Gleichungen die Definitionen des Koordinatensystems, die Koordinatentransformationen, die Methoden zur Parameterbestimmung und der dahinterliegende Integrationsalgorithmus erläutert.

Der Inhalt beruht auf dem im Distributionspaket enthaltenen Altdokument `doc/IPAnalyzerAlgorithm.pdf` und auf der aktuellen Implementierung.

## Aufbau des Anhangs

- **[A1. Detektorgeometrie und Koordinatentransformationen](a1-geometry.md)** — Definition des rechtshändigen Koordinatensystems, die Rotationsmatrizen, die die IP-Verkippung ($\varphi,\ \tau$) beschreiben, und die Korrektur der Pixelform ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Parameterbestimmung](a2-calibration.md)** — Kalibrierung von Kameralänge, Wellenlänge, Pixelgröße und IP-Verkippung anhand eines Standardmaterials (Zwei-Abstands-Methode, Zwei-Linien-Methode, Ellipsenanpassung).
- **[A3. Bildintegration](a3-image-integration.md)** — der Flächenaufteilungsalgorithmus, der Pixelintensitäten auf Winkelschritte verteilt.
- **[A4. Symmetrieinformationen](a4-symmetry-information.md)** — Raumgruppensymmetrie, geometrische Berechnungen, Wyckoff-Positionen, Reflexionsbedingungen und Symmetrieelement-Diagramme des Standardkristalls (ein Unterfenster des Crystal-Fensters).
- **[A5. Streufaktor](a5-scattering-factor.md)** — Strukturfaktoren und die Reflexliste des Standardkristalls (Röntgen, Elektronen, Neutronen) (ein Unterfenster des Crystal-Fensters).

## Koordinatensystem (gemeinsame Bezugsabbildung)

Jede der folgenden Seiten setzt dasselbe Koordinatensystem als gemeinsame Voraussetzung voraus. Der Ursprung ist der direkte Spot auf der IP (der Punkt, an dem der Strahl die IP schneidet), die $Z$-Achse ist die Ausbreitungsrichtung des Strahls, und die Probe befindet sich bei $(0,\ 0,\ -\mathrm{CL})$.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Hauptparameter

| Symbol | Name | Bedeutung |
|------|------|------|
| $\lambda$ | Wave Length | Wellenlänge der Quelle. Für charakteristische Röntgenstrahlung bekannt; bei Synchrotronstrahlung ändert sie sich mit der Monochromatorstellung und muss jedes Mal bestimmt werden. |
| $\mathrm{CL}$ | Camera Length | Abstand zwischen Probe und Ursprung (direkter Spot). Die Probenposition ist $(0,0,-\mathrm{CL})$. |
| $\varphi,\ \tau$ | Tilt Correction | Verkippung der IP relativ zur optischen Achse ($Z$-Achse). $\varphi$ ist der Azimut der Kippachse in der XY-Ebene, und $\tau$ ist der Drehwinkel um diese Achse. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | Stellt ein Pixel als Parallelogramm dar. $\xi$ ist der Versatz des Startpunkts der Auslese-Laserabtastung (Verzerrungswinkel). |

Diese Werte werden auf der Registerkarte IP Condition des Eigenschaftsfensters gesetzt (siehe [2. Eigenschaftsfenster](../2-property-windows.md)).
