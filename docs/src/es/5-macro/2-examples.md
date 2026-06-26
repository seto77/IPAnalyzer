<!-- 260601Cl: Reflected from ja/5-macro/2-examples.md. Migrated from the wiki; updated the stale API name FindSpotsBeforeGetProfile -> MaskSpotsBeforeGetProfile. -->

# Ejemplos

Los ejemplos siguientes pueden copiarse y pegarse directamente en el editor de macros. Las funciones que implican un cuadro de diálogo, como `IPA.File.GetFileNames()`, abren una pantalla de selección de archivos al ejecutarse. Consulte [Funciones integradas](1-built-in-functions.md) para conocer los detalles de cada miembro.

!!! tip
    Cuando la lista de macros guardadas del editor está vacía, se inserta automáticamente un conjunto más completo de ejemplos (bucles básicos, funciones matemáticas, configuración de la geometría, división azimutal, enmascaramiento, envío a PDIndexer, etc.). Explorarlos primero es una buena manera de aprender el estilo.

## Convertir varios archivos a perfiles 1D y guardarlos (archivos de una sola imagen)

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

## Convertir varios archivos a perfiles 1D y guardarlos (archivos de varias imágenes)

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

## Convertir por lotes varios archivos (stl, his, ...) a TIFF

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
