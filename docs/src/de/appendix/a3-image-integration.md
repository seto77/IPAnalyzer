<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). -->

# Anhang A3. Bildintegration

Bei der Umwandlung eines 2D-Bildes in ein 1D-Profil besteht das größte Problem darin, **wie die Intensität eines Pixels, das mehrere Schritte überdeckt, verteilt wird, wenn die Winkelschrittweite der Integration kleiner als der Pixelabstand (die Pixelgröße) ist**. IPAnalyzer löst diese Verteilung mit einer **flächenbasierten Verteilungsmethode**.

---

## Flächenbasierte Verteilungsmethode

In dieser Software berechnet das Programm die Schnittpunkte zwischen den Linien, die die einzelnen Schritte begrenzen (die Grenzen gleichen Beugungswinkels), und den Pixeln, bestimmt die **Fläche** jedes Pixels, die in einen gegebenen Schritt fällt, und verteilt die Intensität proportional zu dieser Fläche.

![Flächenbasierte Verteilung. Reales Ringbild (links) → Pixelmaßstab (Mitte, grüne gestrichelte Linien sind die Schrittgrenzen) → Schnittpunkte mit den Schrittgrenzen innerhalb eines einzelnen Pixels (rechts, durch die vier Ecken und die Schnittpunkte begrenzte Flächen).](../../assets/references/integration-area-distribution.png){width=680px}

Diese Methode hat folgende Eigenschaften.

- Innerhalb jedes Pixels wird der Bogen der Schrittgrenze **durch eine Gerade angenähert**. Dies geschieht aus Gründen der Rechengeschwindigkeit und ist in der Praxis fast nie ein Problem.
- Sind die Verkippungs- und Pixelform-Korrektur aus [A1. Detektorgeometrie](a1-geometry.md) erforderlich, ist das Pixel nicht streng quadratisch. Die Software **berechnet daher nacheinander die Koordinaten der vier Ecken des Pixels** und bestimmt die Fläche als Viereck (im Allgemeinen ein Parallelogramm).

Mit diesem Verfahren wird die Pixelintensität prinzipiell glatt auf die Schritte verteilt, wie fein die Winkelschrittweite auch gewählt wird.

---

## Anwendungsbereich

Derselbe flächenbasierte Verteilungsalgorithmus wird für alle drei folgenden Integrationsarten verwendet.

| Funktion | Integrationsrichtung | Verwendung |
|------|-----------|------|
| **Konzentrische Integration (Concentric Integration)** | Beugungswinkel (konzentrische Richtung) | Erstellung eines gewöhnlichen $2\theta$-Intensitätsprofils. |
| **Radiale Integration (Radial Integration)** | Umfangsrichtung (azimutal) | Bewertung der Azimutabhängigkeit eines Rings (Orientierung, Verzerrung). |
| **Unrolled Image** | Beugungswinkel × Azimut | Erstellung eines 2D-Bildes, in dem der Ring aufgeschnitten und abgewickelt ist. |

Zur Bedienung der einzelnen Funktionen siehe [3. Werkzeuge](../3-tools.md).
