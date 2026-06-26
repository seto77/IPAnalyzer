<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Anhang A3. Bildintegration

Bei der Umwandlung eines 2D-Bildes in ein 1D-Profil besteht das größte Problem darin, **wie die Intensität eines Pixels verteilt wird, das mehrere Schritte überspannt, wenn die Winkelschrittweite der Integration kleiner ist als der Pixelabstand (die Pixelgröße)**. IPAnalyzer behandelt diese Verteilung mit einer **flächenbasierten Verteilungsmethode**.

---

## Flächenbasierte Verteilungsmethode

In dieser Software berechnet das Programm die Schnittpunkte zwischen den Linien, die jeden Schritt begrenzen (den Grenzen gleichen Beugungswinkels), und den Pixeln, ermittelt die **Fläche** jedes Pixels, die in einen bestimmten Schritt fällt, und verteilt die Intensität proportional zu dieser Fläche.

![Flächenbasierte Verteilung. Reales Ringbild (links) → Pixelmaßstab (Mitte, die grünen gestrichelten Linien sind die Schrittgrenzen) → Schnittpunkte mit den Schrittgrenzen innerhalb eines einzelnen Pixels (rechts, durch die vier Ecken und die Schnittpunkte begrenzte Flächen).](../../assets/references/integration-area-distribution.png){width=680px}

Diese Methode weist die folgenden Eigenschaften auf.

- Innerhalb jedes Pixels wird der Bogen der Schrittgrenze **als Gerade angenähert**. Dies geschieht aus Gründen der Rechengeschwindigkeit und ist in der Praxis nahezu nie ein Problem.
- Wenn die Verkippungskorrektur und die Pixelformkorrektur aus [A1. Detektorgeometrie](a1-geometry.md) erforderlich sind, ist die Pixelform nicht streng quadratisch. Die Software **berechnet daher die Koordinaten der vier Ecken des Pixels nacheinander** und ermittelt die Fläche als Viereck (im Allgemeinen ein Parallelogramm).

Mit diesem Verfahren wird die Pixelintensität im Prinzip, egal wie fein der Winkelschritt gewählt wird, gleichmäßig über die Schritte verteilt.

---

## Anwendungsbereich

Derselbe flächenbasierte Verteilungsalgorithmus wird für alle drei der folgenden Integrationsarten verwendet.

| Funktion | Integrationsrichtung | Verwendung |
|------|-----------|------|
| **Concentric Integration** | Beugungswinkel (konzentrische Richtung) | Erstellung eines gewöhnlichen $2\theta$-Intensitätsprofils. |
| **Radial Integration** | Umfangsrichtung (azimutal) | Bewertung der azimutalen Abhängigkeit eines Rings (Orientierung, Verzerrung). |
| **Unrolled Image** | Beugungswinkel × Azimut | Erstellung eines abgewickelten 2D-Bildes mit aufgeschnittenem Ring. |

Wie die einzelnen Funktionen bedient werden, siehe [3. Werkzeuge](../3-tools.md).
