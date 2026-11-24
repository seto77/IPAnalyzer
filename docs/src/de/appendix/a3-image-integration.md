<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

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

Derselbe flächenbasierte Verteilungsalgorithmus wird für alle drei folgenden Integrationsarten verwendet. Sie unterscheiden sich darin, welche Koordinate auf der horizontalen Achse der Ausgabe verbleibt und welche Pixel zu einem Ausgabepunkt zusammengefasst werden.

| Funktion | Horizontale Achse der Ausgabe | Zu einem Ausgabepunkt zusammengefasste Pixel | Verwendung |
|------|------|------|------|
| **Konzentrische Integration (Concentric integration)** | Beugungswinkel $2\theta$ (oder d-Wert) | Pixel innerhalb eines Schritts von $2\theta$ (bzw. d), über alle Azimute innerhalb des Integrationsbereichs | Erstellung eines gewöhnlichen $2\theta$-Intensitätsprofils. |
| **Radiale Integration (Radial integration)** | Azimut $\chi$ | Pixel innerhalb eines azimutalen Schritts (**Sektorwinkel-Schritt (Sweep-Schritt) (Sector angle step (Sweep step))**), innerhalb des durch **Donut-Radius (Donut radius)** ± **Donut-Breite (Donut width)** gegebenen Rings | Bewertung der Azimutabhängigkeit eines Rings (Orientierung, Verzerrung). |
| **Unrolled image** | $2\theta$ (horizontal) × Azimut $\chi$ (vertikal) | Pixel innerhalb eines $2\theta$-Schritts und eines azimutalen Sektors ($360^\circ/N$) | Erstellung eines 2D-Bildes, in dem der Ring aufgeschnitten und abgewickelt ist. |

In allen Fällen werden nur gültige Pixel verwendet: Maskierte Pixel und auf der Registerkarte **Integralbereich (Integral Region)** ausgeschlossene Pixel tragen nicht bei.

---

## Normierung nach der Integration

Die verteilten Intensitäten werden je nach Funktion unterschiedlich normiert.

- **Konzentrische Integration** (Flachdetektor, Achse $2\theta$ oder d-Wert) und das **abgewickelte Bild (Unrolled image)**: Für jeden Schritt (jedes Pixel des abgewickelten Bildes) werden die verteilten Intensitäten summiert, und die Summe wird durch den Anteil geteilt, der zu diesem Schritt beigetragen hat. Der Beitrag jedes Pixelteils wird durch seine Fläche gemessen, projiziert auf die Ebene senkrecht zum gestreuten Strahl im Abstand der Kameralänge — also durch den Raumwinkel, den er einnimmt —, gezählt in Einheiten eines Pixels, das in der Kameralänge frontal betrachtet wird. Das Ergebnis ist daher eine mittlere Intensität pro Raumwinkeleinheit: Es hängt weder von der Schrittweite noch davon ab, wie viele Pixel in einen Schritt fallen, und die Abnahme des Raumwinkels pro Pixel zu großen Winkeln hin auf einem Flachdetektor wird ausgeglichen. Ein Schritt, der kein Pixel erhält, ist 0.
- **Radiale Integration**: Die verteilten Intensitäten werden für jeden azimutalen Schritt einfach summiert und nicht geteilt. Die Werte wachsen daher mit der Ringbreite (**Donut-Breite (Donut width)**) und dem azimutalen Schritt.

Zur Bedienung der einzelnen Funktionen siehe [3. Werkzeuge](../3-tools.md).
