<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

Der Brute-Force-Modus variiert jeden Parameter erschöpfend (eine Rastersuche), um die Werte zu finden, die folgende Kriterien am besten erfüllen:

- scharfe Peaks (also kleine Halbwertsbreite, FWHM) und
- geringe Abweichung der d-Werte.

Er ist wirksam bei unvollständigen Ringen oder verrauschten Daten, bei denen eine geometrische Optimierung nur schwer konvergiert. Siehe [Werkzeuge](3-tools.md) für einen Überblick über das Werkzeug und [Arbeitsabläufe](4-procedures.md) für den grundlegenden Ablauf.

## Schritte

1. Laden Sie die Bilddaten und Parameter und klicken Sie dann auf **Find Parameter (brute force)**.

    ![Find Parameter (brute force) starten](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-Force-Kalibrierungsfenster](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Wählen Sie das **standard material**. Falls es nicht in der Liste enthalten ist, wählen Sie **Others** und geben Sie es manuell ein.
3. Zeigen Sie das Profil mit **Get profile** an.
4. Doppelklicken Sie auf jede Peak-Linie, die Sie nicht für die Optimierung verwenden möchten, um sie auszuschließen.
5. Stellen Sie die Optionen ein und drücken Sie **Optimize**, um die Optimierung zu starten.

## Optionen

![Optionseinstellungen](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Gibt den für jeden Peak angepassten Winkelbereich an.

### Number of repetitions

Gibt die Anzahl der Optimierungszyklen an.

### Parameterspezifische Optionen

Die Optimierung wird an den angekreuzten Einträgen durchgeführt. Jeder Parameter bewegt sich über den angegebenen Bereich (**Search range**) in der angegebenen Schrittweite (**Initial step**).

Beginnt beispielsweise die Kameralänge bei 100 mm mit einer Initial step von 0,05 mm und einer Search range von 4, dann werden 9 (= Search range × 2 + 1) Kameralängen ausprobiert: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Sind die Versuchszahlen der Parameter N1, N2, N3, …, so ist die Gesamtzahl der Versuche pro Zyklus N1 × N2 × N3 × …. Im obigen Beispiel ergibt sich mit vier Parametern bei Search ranges von 4, 4, 3 und 6: (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 Versuche. Mit anderen Worten: Es werden 7371 Parametersätze ausprobiert, und die Kombination mit den schärfsten Peaks und der kleinsten Abweichung der d-Werte wird gewählt.

!!! warning
    Eine Vergrößerung von **Search range** erhöht die Anzahl der Versuche stark und verlängert jeden Zyklus. Verwenden Sie sie mit Bedacht.

## Statusanzeige

![Statusanzeige](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Während der Kalibrierung wird eine Statusanzeige wie die obige angezeigt.

- **Cycle**: die aktuelle Zyklusnummer. Wenn ein Zyklus abgeschlossen ist, wird der darin gefundene beste Parametersatz zum Ausgangspunkt des nächsten Zyklus. Sind die besten Parameter mit denen des vorherigen Zyklus identisch, wird die Schrittweite für den nächsten Zyklus mit 0,8 multipliziert.
- **Current best values**: die besten Parameter zu diesem Zeitpunkt.
- **Current steps**: die Schrittweite jedes Parameters zu diesem Zeitpunkt.
- **No1, No2, …**: die besten 5 Bewertungswerte im Zyklus. Sie fallen zunächst rasch ab und konvergieren, je näher man dem Optimum kommt.

## Bewertungswert R

Der Bewertungswert R wird wie folgt berechnet.

![Formel für den Bewertungswert R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Dabei ist *H* die untergrundkorrigierte Peakhöhe.
