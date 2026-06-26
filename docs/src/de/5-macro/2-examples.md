<!-- 260601Cl: Reflected from ja/5-macro/2-examples.md. Migrated from the wiki; updated the stale API name FindSpotsBeforeGetProfile -> MaskSpotsBeforeGetProfile. -->

# Beispiele

Die folgenden Beispiele können direkt in den Makro-Editor kopiert und eingefügt werden. Funktionen, die einen Dialog beinhalten, wie etwa `IPA.File.GetFileNames()`, öffnen beim Ausführen einen Dateiauswahl-Bildschirm. Einzelheiten zu den jeweiligen Mitgliedern finden Sie unter [Integrierte Funktionen](1-built-in-functions.md).

!!! tip
    Wenn die Liste der gespeicherten Makros im Editor leer ist, wird automatisch eine umfangreichere Sammlung von Beispielen eingefügt (einfache Schleifen, mathematische Funktionen, Geometrie-Einrichtung, azimutale Unterteilung, Maskieren, Senden an PDIndexer usw.). Diese zuerst durchzusehen ist eine gute Möglichkeit, sich mit dem Stil vertraut zu machen.

## Mehrere Dateien in 1D-Profile umwandeln und speichern (Einzelbild-Dateien)

```python
# Convert several files in the same folder into 1D profiles and save them
# (when each file contains a single image)

# First, get the file names (multiple allowed)
filelist = IPA.File.GetFileNames()
# Loop over filelist
for filename in filelist:
    # If the extension is .stl
    if filename.endswith('.stl'):
        # Read the file
        IPA.File.ReadImage(filename)
        # Set True to find the center before Get Profile
        IPA.Profile.FindCenterBeforeGetProfile = True
        # Set True to mask spots before Get Profile
        IPA.Profile.MaskSpotsBeforeGetProfile = True
        # Set True to save the profile after Get Profile
        IPA.Profile.SaveProfileAfterGetProfile = True
        # Set True to save as CSV (also SaveProfileAsTSV, SaveProfileAsPDI, ...)
        IPA.Profile.SaveProfileAsCSV = True
        # Run Get Profile and save to the given file name
        IPA.Profile.GetProfile(filename)
```

## Mehrere Dateien in 1D-Profile umwandeln und speichern (Mehrbild-Dateien)

```python
# Convert several files in the same folder into 1D profiles and save them
# (when each file contains multiple images)

# First, get the file names (multiple allowed)
filelist = IPA.File.GetFileNames()
# Loop over filelist
for filename in filelist:
    # If the extension is .his
    if filename.endswith('.his'):
        # Read the file
        IPA.File.ReadImage(filename)
        IPA.Profile.FindCenterBeforeGetProfile = True
        IPA.Profile.MaskSpotsBeforeGetProfile = True
        IPA.Profile.SaveProfileAfterGetProfile = True
        IPA.Profile.SaveProfileAsCSV = True
        # Loop over the number of contained images (IPA.Sequential.Count)
        for num in range(IPA.Sequential.Count):
            # Select the frame
            IPA.Sequential.SelectedIndex = num
            # Run Get Profile and save with the frame number appended
            IPA.Profile.GetProfile(filename + '_' + str(num))
```

## Mehrere Dateien (stl, his, ...) stapelweise in TIFF umwandeln

```python
# Batch-convert several files (stl, his, ...) in the same folder to TIFF

# Get the files (multiple allowed) with IPA.File.GetFileNames()
filelist = IPA.File.GetFileNames()
# Loop over filelist
for filename in filelist:
    # If the extension is .his
    if filename.endswith('.his'):
        IPA.File.ReadImage(filename)                               # read the file
        IPA.File.SaveImageAsTIFF(filename.replace('.his', '.tif')) # save as tif
    # If the extension is .stl
    if filename.endswith('.stl'):
        IPA.File.ReadImage(filename)                               # read the file
        IPA.File.SaveImageAsTIFF(filename.replace('.stl', '.tif')) # save as tif
```
