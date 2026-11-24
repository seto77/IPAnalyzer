<!-- 261124Cl: Retranslated from en/6-find-parameter.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# Parameter finden (Brute Force)

Der Brute-Force-Modus variiert jeden Parameter erschöpfend (Rastersuche), um die Werte zu finden, die am besten Folgendes erfüllen:

- kleine Abweichungen (in 2θ) zwischen den berechneten Peakpositionen und den durch Anpassung erhaltenen sowie
- hohe (scharfe) Peaks.

Er ist wirksam bei unvollständigen Ringen oder verrauschten Daten, bei denen die geometrische Optimierung schlecht konvergiert. Einen Überblick über das Werkzeug finden Sie unter [Werkzeuge](3-tools.md), den grundlegenden Ablauf unter [Arbeitsabläufe](4-procedures.md).

## Schritte

1. Laden Sie die Bilddaten und Parameter und klicken Sie dann auf **Parameter finden (Brute Force) (Find parameter (brute force))**.

    ![Starten von Parameter finden (Brute Force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Fenster der Brute-Force-Kalibrierung](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Wählen Sie das **Standardmaterial**. Ist es nicht in der Liste enthalten, wählen Sie **Andere (Other)** und geben es manuell ein.
3. Zeigen Sie das Profil mit **Profil abrufen (Get Profile)** an.
4. Doppelklicken Sie auf jede Peaklinie, die nicht für die Optimierung verwendet werden soll, um sie auszuschließen.
5. Stellen Sie die Optionen ein und klicken Sie auf **Optimieren (Optimize)**, um die Optimierung zu starten.

## Optionen

![Optionseinstellungen](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting Range

Legt den Winkelbereich fest, der für jeden Peak angepasst wird.

### Iteration

Legt die Anzahl der Optimierungszyklen fest.

### Parameterspezifische Optionen

Optimiert werden die angehakten Größen. Jeder Parameter bewegt sich über den angegebenen Bereich (**Suchbereich (Search range)**) in der angegebenen Schrittweite (**Anfangsschritt (Initial step)**).

Beginnt die Kameralänge beispielsweise bei 100 mm mit einem Anfangsschritt von 0,05 mm und einem Suchbereich von 4, werden 9 (= Suchbereich × 2 + 1) Kameralängen ausprobiert: 99,80, 99,85, 99,90, 99,95, 100,00, 100,05, 100,10, 100,15, 100,20 mm.

Sind die Versuchsanzahlen der Parameter N1, N2, N3, …, beträgt die Gesamtzahl der Versuche pro Zyklus N1 × N2 × N3 × …. Im obigen Beispiel ergibt sich bei vier Parametern mit den Suchbereichen 4, 4, 3 und 6 (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 Versuche. Es werden also 7371 Parametersätze ausprobiert, und die Kombination mit dem kleinsten Bewertungswert R (siehe unten) wird gewählt.

!!! warning
    Eine Vergrößerung von **Suchbereich (Search range)** erhöht die Zahl der Versuche stark und verlängert jeden Zyklus. Gehen Sie damit vorsichtig um.

## Statusanzeige

![Statusanzeige](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

Während der Kalibrierung wird eine Statusanzeige wie oben dargestellt.

- **Cycle**: die aktuelle Zyklusnummer. Am Ende eines Zyklus wird der beste darin gefundene Parametersatz zum Ausgangspunkt des nächsten Zyklus. Ist der beste Parametersatz identisch mit dem zu Beginn des Zyklus, wird die Schrittweite für den nächsten Zyklus auf den nächstkleineren Wert der vorgegebenen Reihe (1, 1,3, 1,8, 2,4, 3,2, 4,2, 5,6, 7,5 × 10ⁿ) verringert (z. B. 0,05 mm → 0,042 mm).
- **Current best values**: die zu diesem Zeitpunkt besten Parameter.
- **Current steps**: die zu diesem Zeitpunkt gültige Schrittweite jedes Parameters.
- **No1, No2, …**: die 4 besten Bewertungswerte seit Beginn der Suche (angezeigt, sobald mindestens fünf verschiedene Werte gesammelt wurden). Sie fallen anfangs schnell und konvergieren, wenn sich die Suche dem Optimum nähert.

## Bewertungswert R

Der Bewertungswert R wird wie folgt berechnet.

![Formel für den Bewertungswert R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Dabei ist \(2\theta_{\mathrm{calc},i}\) die aus den aktuellen Parametern berechnete Position von Peak \(i\), \(2\theta_{\mathrm{fit},i}\) die durch Anpassung des Profils erhaltene Position (beide in Grad), *H* die untergrundbereinigte Peakhöhe und *W* das Gewicht (100; diese Einstellung wird in der aktuellen Version nicht auf dem Bildschirm angezeigt). Für einen Flachdetektor lautet die Formel:

$$
R = 1000\left[\sum_i \left(2\theta_{\mathrm{calc},i} - 2\theta_{\mathrm{fit},i}\right)^2 + \frac{W}{\sum_i H_i}\right]
$$

R wird umso kleiner, je kleiner die Positionsabweichungen und je höher (schärfer) die Peaks sind. Die Halbwertsbreite (FWHM) selbst wird für die Bewertung nicht verwendet.
