<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). -->

# Überblick

IPAnalyzer wandelt Debye–Scherrer-Ringe, die mit Imaging Plates (IP) oder CCD/CMOS-Detektoren aufgenommen wurden, schnell und mit hoher Präzision in eindimensionale Beugungsprofile um. Aufbau und Funktionsumfang orientieren sich an PIP, das von Hiroshi Fujihisa am National Institute of Advanced Industrial Science and Technology (AIST) entwickelt wurde.

Hauptfunktionen:

- Unterstützung zahlreicher Bildformate (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`) sowie allgemeine Bildformate)
- Röntgen-, Elektronen- und Neutronenquellen
- Zusammenarbeit mit PDIndexer
- Halbautomatische Bestimmung der Messparameter

## Systemanforderungen und Installation

### Anforderungen

Diese Anforderungen gelten für .NET-11-Builds aus diesem Quellbaum. Für veröffentlichte Releases gilt die jeweils für das Release angegebene Laufzeitvoraussetzung.

- Betriebssystem: Windows (Windows 11 empfohlen)
- Erforderliche Laufzeit: .NET Desktop Runtime 11.0
- Empfohlener Arbeitsspeicher: 16 GB oder mehr
- Empfohlene CPU: 8 Kerne oder mehr

Intern nutzt die Software in großem Umfang mehrfädige Berechnungen; mit mehr CPU-Kernen arbeitet sie daher flüssiger. Bildintensitäten werden intern als Gleitkommazahlen doppelter Genauigkeit gehalten.

Die Software wird unter der MIT-Lizenz vertrieben.

### Installation

1. Laden Sie die zu Ihrem PC passende Datei von der GitHub-[Release-Seite](https://github.com/seto77/IPAnalyzer/releases/latest) herunter.
    - `IPAnalyzer-setup.msi`: Installer für gewöhnliche (x64-)Windows-PCs (empfohlen). `IPAnalyzerSetup.msi` ist identisch; dieser Name bleibt für die automatische Aktualisierung älterer Versionen erhalten.
    - `IPAnalyzer-setup_arm64.msi`: Installer für Windows on Arm.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`: portable Version (ohne Installation; die .NET-Laufzeit ist enthalten) für PCs ohne Administratorrechte.
2. Für den Installer installieren Sie vorab die [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) und führen dann die heruntergeladene `.msi` aus.
3. Für die portable Version entpacken Sie die ZIP-Datei in einen Ordner mit Schreibrechten für den Benutzer und starten `IPAnalyzer.exe` (nicht aus der ZIP-Ansicht heraus starten).

## Achsenorientierung, IP-Verkippung und Pixelform

IPAnalyzer verwendet ein rechtshändiges Koordinatensystem; Ursprung und Achsenrichtungen sind wie folgt definiert.

- Der Punkt, an dem der Röntgen- oder Elektronenstrahl die IP schneidet (der Direktstrahl), ist der Ursprung (0, 0, 0); die Z-Achse fällt mit der Strahlrichtung zusammen.
- Die Probe wird als unendlich klein betrachtet; der Abstand zwischen Probenposition und Ursprung ist als Kameralänge (Camera Length, CL) definiert. Die Probe liegt daher bei \((0,\ 0,\ -\mathrm{CL})\).
- Die X-Achse ist bei unverkippter IP an der Abtastrichtung des Auslese-Lasers der IP ausgerichtet. Die Y-Achse zeigt daher auf dem Bildschirm nach unten.
- Die IP-Verkippung wird als Drehung um eine in der XY-Ebene liegende Gerade durch den Ursprung beschrieben: eine Drehung um \( \tau \) um die Gerade, die mit der X-Achse den Winkel \( \varphi \) einschließt.
- Die Pixelform wird als Parallelogramm behandelt, das durch PixSizeX, PixSizeY und \( \xi \) beschrieben wird. Ein von null verschiedenes \( \xi \) bedeutet, dass die Startposition der Laserabtastung beim Auslesen der IP versetzt ist. Die Software nimmt an, dass dieser Versatz entlang der Y-Achse konstant ist.

Kameralänge, \( \varphi \), \( \tau \), Pixelgröße und \( \xi \) werden auf der Registerkarte **Detektorbedingung (Detector condition)** des Eigenschaftsfensters eingestellt (siehe [2. Eigenschaftsfenster](2-property-windows.md)).

### Beziehung zu (WIN)PIP

In IPAnalyzer wird die X-Achse (die Richtung nach rechts im IP-Bild) um \( \varphi \) im Uhrzeigersinn gedreht und anschließend um die so erhaltene Achse um \( \tau \) gedreht. In PIP wird die Y-Achse (die Richtung nach unten im IP-Bild) um \( \beta \) gegen den Uhrzeigersinn gedreht und anschließend um die so erhaltene Achse um \( \Phi \) gedreht. Um PIPs \((\beta,\ \Phi)\) in IPAnalyzers \((\varphi,\ \tau)\) umzurechnen, verwenden Sie daher \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\).

## Methode der Pixelintensitätsintegration

Das zentrale Problem der Eindimensionalisierung ist, wie die Intensität eines Pixels, das mehrere Integrationsschritte überdeckt, auf diese Schritte verteilt wird — das tritt immer dann auf, wenn der von einem Pixel abgedeckte Streuwinkelbereich mehr als einen 2θ-Schritt umfasst (umso häufiger, je feiner der Schritt ist).

Die Software berechnet die Schnittpunkte zwischen den Linien, die die einzelnen Schritte begrenzen, und dem Pixel und verteilt die Intensität entsprechend der Pixelfläche, die in jedem Schritt liegt. Damit auch Fälle erfasst werden, in denen das Pixel wegen der IP-Verkippung oder einer Verzerrung der Pixelform nicht genau quadratisch ist, werden die Koordinaten der vier Ecken jedes Pixels nacheinander berechnet, um seine Vierecksform zu bestimmen. Prinzipiell lässt sich die Pixelintensität so glatt auf die Schritte verteilen, wie klein die Schritte auch gewählt werden.

Dieser Algorithmus wird nicht nur für die gewöhnliche Winkel–Intensitäts-Integration (Konzentrische Integration / Concentric Integration) verwendet, sondern auch für die Integration entlang des Umfangs (Radiale Integration / Radial Integration) und für die Berechnung des abgewickelten Bildes (Unrolled Image).
