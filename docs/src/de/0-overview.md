<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# Überblick

IPAnalyzer wandelt Debye–Scherrer-Ringe, die mit Imaging Plates (IP) oder CCD/CMOS-Detektoren aufgezeichnet wurden, mit hoher Präzision und Geschwindigkeit in eindimensionale Beugungsprofile um. Aufbau und Funktionen sind PIP nachempfunden, das von Hiroshi Fujihisa am National Institute of Advanced Industrial Science and Technology (AIST) entwickelt wurde.

Hauptfunktionen:

- Unterstützt eine Vielzahl von Bildformaten (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon und allgemeine Bildformate)
- Röntgen-, Elektronen- und Neutronenquellen
- Integration mit PDIndexer
- Halbautomatische Analyse der Messparameter

## Systemanforderungen und Installation

### Anforderungen

- Betriebssystem: Windows (Windows 11 empfohlen)
- Erforderliche Laufzeitumgebung: .NET Desktop Runtime 10.0
- Empfohlener Arbeitsspeicher: 16 GB oder mehr
- Empfohlene CPU: 8 Kerne oder mehr

Intern nutzt die Software in großem Umfang Multithread-Berechnungen, sodass eine CPU mit mehr Kernen komfortabler läuft. Die Bildintensitäten werden intern als Gleitkommawerte mit doppelter Genauigkeit gehalten.

Die Software wird unter der MIT-Lizenz verteilt.

### Installation

1. Installieren Sie vorab [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0).
2. Laden Sie `IPAnalyzerSetup.msi` von der GitHub-[Releases-Seite](https://github.com/seto77/IPAnalyzer/releases) herunter.
3. Führen Sie `IPAnalyzerSetup.msi` aus, um die Installation durchzuführen.

## Achsenorientierung, IP-Verkippung und Pixelform

IPAnalyzer verwendet ein rechtshändiges Koordinatensystem, dessen Ursprung und Achsenrichtungen wie folgt definiert sind.

- Der Punkt, an dem der Röntgen- oder Elektronenstrahl die IP schneidet (der Direktstrahlfleck), wird als Ursprung (0, 0, 0) definiert, und die Z-Achse fällt mit der Strahlrichtung zusammen.
- Behandelt man die Probengröße als infinitesimal, so wird der Abstand zwischen Probenposition und Ursprung als Kameralänge (Camera Length, CL) definiert. Die Probe befindet sich daher bei \((0,\ 0,\ -\mathrm{CL})\).
- Die X-Achse ist bei nicht verkippter IP an der Abtastrichtung des IP-Auslese-Lasers ausgerichtet. Die Y-Achse zeigt daher auf dem Bildschirm nach unten.
- Die IP-Verkippung wird als Rotation um eine Gerade ausgedrückt, die in der XY-Ebene liegt und durch den Ursprung verläuft: eine Drehung um \( \tau \) um die Gerade, die mit der X-Achse einen Winkel \( \varphi \) bildet.
- Die Pixelform wird als Parallelogramm behandelt, das durch PixSizeX, PixSizeY und \( \xi \) beschrieben wird. Ein von null verschiedenes \( \xi \) bedeutet, dass ein Versatz in der Startposition der Abtastung des IP-Auslese-Lasers vorliegt. Die Software nimmt an, dass dieser Versatz entlang der Y-Achse konstant ist.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

Die Kameralänge, \( \varphi \), \( \tau \), die Pixelgröße und \( \xi \) werden auf der Registerkarte IP Condition des Eigenschaftsfensters eingestellt (siehe [2. Property Windows](2-property-windows.md)).

### Beziehung zu (WIN)PIP

In IPAnalyzer wird die X-Achse (die nach rechts weisende Richtung des IP-Bildes) im Uhrzeigersinn um \( \varphi \) gedreht, und die resultierende Achse anschließend um \( \tau \) gedreht. In PIP wird die Y-Achse (die nach unten weisende Richtung des IP-Bildes) gegen den Uhrzeigersinn um \( \beta \) gedreht, und die resultierende Achse anschließend um \( \Phi \) gedreht. Um daher PIPs \((\beta,\ \Phi)\) in IPAnalyzers \((\varphi,\ \tau)\) umzurechnen, verwenden Sie \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Methode der Pixelintensitätsintegration

Das zentrale Problem bei der Eindimensionalisierung besteht darin, wie die Intensität eines Pixels, das sich über mehrere Schritte erstreckt, auf die Integrationsschritte verteilt wird — was eintritt, wenn das Intervall des Winkelschritts kleiner als das Pixelintervall (d. h. die Pixelgröße) ist.

Die Software berechnet die Schnittpunkte zwischen den Geraden, die jeden Schritt begrenzen, und dem Pixel und verteilt die Intensität, indem sie die in jedem Schritt enthaltene Pixelfläche ermittelt. Um Fälle zu behandeln, in denen das Pixel nicht exakt quadratisch ist — aufgrund von IP-Verkippung oder Verzerrung der Pixelform —, werden die Koordinaten der vier Ecken jedes Pixels sukzessive berechnet, um seine Viereckform zu bestimmen. Im Prinzip erlaubt dies, die Pixelintensität gleichmäßig über die Schritte zu verteilen, gleichgültig wie klein die Schritte gewählt werden.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

Dieser Algorithmus wird nicht nur für die gewöhnliche Winkel–Intensität-Integration (Concentric Integration) verwendet, sondern auch für die Integration entlang des Umfangs (Radial Integration) und für die Berechnung des abgewickelten Bildes (Unrolled Image).
