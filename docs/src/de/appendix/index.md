<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Anhang

Dieser Anhang fasst den **theoretischen Hintergrund der Geometrie und der Algorithmen** zusammen, die IPAnalyzer bei der Umwandlung eines zweidimensionalen Beugungsbildes (Debye–Scherrer-Ringe) in ein hochgenaues 1D-Profil verwendet. Bedienabläufe und die Verwendung der einzelnen Funktionen finden Sie im Haupthandbuch ([0. Überblick](../0-overview.md), [4. Arbeitsabläufe](../4-procedures.md) usw.). Hier werden die Definitionen des Koordinatensystems, die Koordinatentransformationen, die Methoden der Parameterbestimmung und der zugrunde liegende Integrationsalgorithmus mit Gleichungen erläutert.

Der Inhalt beruht auf dem früheren Dokument `doc/IPAnalyzerAlgorithm.pdf`, das dem Distributionspaket beilag, sowie auf der aktuellen Implementierung.

## Aufbau des Anhangs

- **[A1. Detektorgeometrie und Koordinatentransformationen](a1-geometry.md)** — Definition des rechtshändigen Koordinatensystems, die Drehmatrizen, die die IP-Verkippung ($\varphi,\ \tau$) beschreiben, und die Korrektur der Pixelform ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$).
- **[A2. Parameterbestimmung](a2-calibration.md)** — Kalibrierung von Kameralänge, Wellenlänge, Pixelgröße und IP-Verkippung mit einem Standardmaterial (Zwei-Abstands-Methode, Zwei-Linien-Methode, Ellipsenanpassung).
- **[A3. Bildintegration](a3-image-integration.md)** — der Flächenaufteilungs-Algorithmus, der Pixelintensitäten auf Winkelschritte verteilt, sowie die Normierung nach der Integration.
- **[A4. Symmetrieinformationen](a4-symmetry-information.md)** — Raumgruppensymmetrie, geometrische Berechnungen, Wyckoff-Lagen, Reflexionsbedingungen und Diagramme der Symmetrieelemente des Standardkristalls (ein Unterfenster des Kristallfensters).
- **[A5. Streufaktor](a5-scattering-factor.md)** — Strukturfaktoren und Reflexliste des Standardkristalls (Röntgen, Elektronen, Neutronen) (die Registerkarte **Reflexe (Reflections)** von **Strahlwechselwirkung (Beam interaction)** im Kristallfenster).

## Koordinatensystem (gemeinsame Bezugsabbildung)

Alle folgenden Seiten setzen dasselbe Koordinatensystem als gemeinsame Grundlage voraus. Der Ursprung ist der Direktstrahl auf der IP (der Punkt, an dem der Strahl die IP schneidet), die $Z$-Achse ist die Ausbreitungsrichtung des Strahls, und die Probe befindet sich bei $(0,\ 0,\ -\mathrm{CL})$.

![Koordinatensystem von IPAnalyzer. Gezeigt sind die IP (Imaging Plate), die X-/Y-/Z-Achsen, die Debye-Ringe, die Verkippungswinkel φ und τ, die Probe bei (0,0,−CL), die Kameralänge CL, der Beugungswinkel 2θ, die Wellenlänge λ und die Pixelform (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## Hauptparameter

| Symbol | Name | Bedeutung |
|------|------|------|
| $\lambda$ | Wellenlänge (Wave Length) | Wellenlänge der Quelle. Bei charakteristischer Röntgenstrahlung bekannt; bei Synchrotronstrahlung ändert sie sich mit der Monochromatorstellung und muss jedes Mal bestimmt werden. |
| $\mathrm{CL}$ | Kameralänge (Camera Length) | Abstand zwischen Probe und Ursprung (Direktstrahl). Die Probenposition ist $(0,0,-\mathrm{CL})$. Entspricht auf dem Bildschirm **Kameralänge 1 (Camera Length 1)**; **Kameralänge 2 (Camera Length 2)** ist der senkrechte Abstand von der Probe zum Detektor, der sich bei einer Verkippung $\tau$ unterscheidet. |
| $\varphi,\ \tau$ | Neigungskorrektur (Tilt Correction) | Verkippung der IP gegenüber der optischen Achse ($Z$-Achse). $\varphi$ ist der Azimut der Kippachse in der XY-Ebene, $\tau$ der Drehwinkel um diese Achse. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixelgröße (Pixel Size) | Stellt ein Pixel als Parallelogramm dar. $\xi$ ist der Versatz des Abtastbeginns des Auslese-Lasers (Verzerrungswinkel). |

Die Wellenlänge wird auf der Registerkarte **Wellenquelle (Wave source)** des Eigenschaftsfensters eingestellt, Kameralänge, Verkippung und Pixelform auf der Registerkarte **Detektorbedingung (Detector condition)** (siehe [2. Eigenschaftsfenster](../2-property-windows.md)).
