<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Makro

IPAnalyzer bietet eine **macro**-Funktion, die Abfolgen von Operationen mit Python-ähnlichen Skripten automatisiert. Sie ist nützlich für wiederkehrende Arbeiten wie die Stapel-Eindimensionalisierung vieler Dateien, die Formatkonvertierung und die azimutal aufgeteilte Analyse.

## Den Editor öffnen

Öffnen Sie den Makro-Editor über das Menü **Macro** → **Editor** im Hauptfenster. Dort können Sie Code bearbeiten und ausführen, einschließlich schrittweiser Ausführung.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Sprache

- Kontrollanweisungen wie `for` / `if` / `while` / `def` / `class` sowie Arithmetik stehen zur Verfügung.
- Das Modul `math` ist bereits importiert, sodass Sie `math.pi` oder `math.sin(...)` direkt ohne `import`-Anweisung verwenden können.
- `print()` ist nicht verfügbar. Um Werte zu prüfen, verwenden Sie die **Schrittausführung** (Step by step) und beobachten Sie die Veränderung der Variablen im Debug-Panel.
- Jede IPAnalyzer-Operation wird aus einem Namensraum unterhalb des Wurzelobjekts `IPA` aufgerufen (z. B. `IPA.File`).

## IPA-Namensräume

| Namensraum | Rolle |
|------|------|
| `IPA.File` | Lesen/Schreiben von Bild-, Parameter- und Maskendateien; Dateiauswahl-Dialoge |
| `IPA.Wave` | Einfallende Quelle und Wellenlänge festlegen |
| `IPA.Detector` | Detektorgeometrie festlegen: Zentrum, Kameralänge, Pixelgröße, Verkippung |
| `IPA.Image` | Anzeigemaßstab, Kontrast und Ansichtsbereich steuern |
| `IPA.Mask` | Reflexe und Bereiche maskieren |
| `IPA.Profile` | Eindimensionalisierung ausführen (Get Profile) und Speichern/Senden konfigurieren |
| `IPA.IntegralProperty` | Bereich, Schrittweite und Einheit der konzentrischen / radialen Integration festlegen |
| `IPA.Sequential` | Frames eines Multiframe-Bildes auswählen / mitteln / als Ziel setzen |
| `IPA.PDI` | Makros auf PDIndexer aufrufen (Integration über die Zwischenablage) |

Siehe [Integrierte Funktionen](1-built-in-functions.md) für die Mitgliederliste und [Beispiele](2-examples.md) für konkrete Skripte.

!!! tip "Die Hilfe im Editor ist die maßgebliche Referenz"
    Die Beschreibung jeder Funktion/Eigenschaft wird in der Hilfe des Makro-Editors angezeigt und ist die aktuelle, versionsverfolgende Quelle der Wahrheit. Falls diese Seite der Editor-Hilfe widerspricht, vertrauen Sie Letzterer.

## Beispiel-Makros

Wenn die Liste der gespeicherten Makros im Editor leer ist, werden automatisch Beispiel-Makros eingefügt (einfache Schleifen, mathematische Funktionen, Geometrie-Einrichtung, Stapelverarbeitung, azimutale Aufteilung, Maskierung, Senden an PDIndexer usw.). Sie sind ein bequemer Ausgangspunkt zum Anpassen.

## Zusammenspiel mit Auto Procedure

Von Ihnen geschriebene Makros können unter einem Namen gespeichert und außerdem aus der Liste „nach dem Laden ausführen" der [Auto Procedure](../3-tools.md) aufgerufen werden, sodass ein Makro automatisch auf jedes während eines Experiments eintreffende Bild angewendet wird.
