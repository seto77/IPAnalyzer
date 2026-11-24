<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). -->

# Makro

IPAnalyzer bietet eine **Makro**-Funktion, die Abfolgen von Operationen mit Python-ähnlichen Skripten automatisiert. Sie ist nützlich für wiederkehrende Arbeiten wie die stapelweise Eindimensionalisierung vieler Dateien, Formatumwandlungen und azimutale Unterteilungsanalysen.

## Den Editor öffnen

Öffnen Sie den Makro-Editor im Hauptfenster über das Menü **Makro (Macro)** → **Editor**. Dort können Sie Code bearbeiten und ausführen, auch schrittweise.

![Makro-Editor](../../assets/cap-en-auto/FormMacro.png)

## Sprache

- Steueranweisungen wie `for` / `if` / `while` / `def` / `class` sowie Arithmetik stehen zur Verfügung.
- Das Modul `math` ist bereits importiert, sodass Sie `math.pi` oder `math.sin(...)` ohne `import`-Anweisung direkt verwenden können.
- `print()` ist nicht verfügbar. Um Werte zu untersuchen, verwenden Sie die **schrittweise Ausführung** (Step by step) und beobachten die Änderungen der Variablen im Debug-Bereich.
- Jede IPAnalyzer-Operation wird über einen Namensraum unterhalb des Wurzelobjekts `IPA` aufgerufen (z. B. `IPA.File`).

## IPA-Namensräume

| Namensraum | Aufgabe |
|------|------|
| `IPA.File` | Bild-, Parameter- und Maskendateien lesen/schreiben; Dateiauswahldialoge |
| `IPA.Wave` | Einfallende Strahlung und Wellenlänge einstellen |
| `IPA.Detector` | Detektorgeometrie einstellen: Zentrum, Kameralänge, Pixelgröße, Verkippung |
| `IPA.Image` | Anzeigeskala, Kontrast und Anzeigebereich steuern |
| `IPA.Mask` | Spots und Bereiche maskieren |
| `IPA.Profile` | Eindimensionalisierung (Profil abrufen / Get Profile) ausführen und Speichern/Senden einstellen |
| `IPA.IntegralProperty` | Bereich, Schritt und Einheit der konzentrischen / radialen Integration einstellen |
| `IPA.Sequential` | Frames eines Multiframe-Bildes auswählen / mitteln / als Ziel festlegen |
| `IPA.PDI` | Makros in PDIndexer aufrufen (Zusammenarbeit über die Zwischenablage) |

Die Liste der Member finden Sie unter [Integrierte Funktionen](1-built-in-functions.md), konkrete Skripte unter [Beispiele](2-examples.md).

!!! tip "Die Hilfe im Editor ist die maßgebliche Referenz"
    Die Beschreibung jeder Funktion/Eigenschaft wird in der Hilfe des Makro-Editors angezeigt; sie ist aktuell, folgt der jeweiligen Version und ist maßgeblich. Weicht diese Seite von der Hilfe im Editor ab, vertrauen Sie Letzterer.

## Beispielmakros

Schalten Sie im Editor **Beispiele anzeigen (Show samples)** ein, um die schreibgeschützten Beispielmakros aufzulisten (einfache Schleifen, mathematische Funktionen, Geometrieeinstellung, Stapelverarbeitung, azimutale Unterteilung, Maskieren, Senden an PDIndexer usw.); schalten Sie es aus, um zu Ihren eigenen gespeicherten Makros zurückzukehren. Sie sind ein bequemer Ausgangspunkt zum Anpassen.

## Zusammenspiel mit der automatischen Prozedur

Selbst geschriebene Makros lassen sich unter einem Namen speichern und auch aus der Liste „nach dem Laden ausführen“ der [Automatischen Prozedur (Auto Procedure)](../3-tools.md) aufrufen, sodass ein Makro während eines Experiments automatisch auf jedes eintreffende Bild angewendet wird.
