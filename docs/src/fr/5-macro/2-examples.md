<!-- 261124Cl: Retranslated from en/5-macro/2-examples.md (UI labels follow the localized GUI). -->

# Exemples

Les exemples ci-dessous peuvent être copiés et collés directement dans l'éditeur de macros. Les fonctions qui font intervenir une boîte de dialogue, comme `IPA.File.GetFileNames()`, ouvrent un écran de sélection de fichiers lors de l'exécution. Voir [Fonctions intégrées](1-built-in-functions.md) pour le détail de chaque membre.

!!! tip
    Activez **Afficher les exemples (Show samples)** dans l'éditeur de macros pour voir un ensemble plus riche d'exemples en lecture seule (boucles de base, fonctions mathématiques, réglage de la géométrie, division azimutale, masquage, envoi vers PDIndexer, etc.). Les parcourir d'abord est un bon moyen d'apprendre le style.

## Convertir plusieurs fichiers en profils 1D et les enregistrer (fichiers à image unique)

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
        # Run Get Profile; the profile is saved as filename plus the format extension (.csv etc.)
        IPA.Profile.GetProfile(filename)
```

## Convertir plusieurs fichiers en profils 1D et les enregistrer (fichiers multi-images)

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
        # Integrate one frame at a time (with the 'all images' setting every frame would be processed on each pass)
        IPA.Sequential.Target_TopmostImage = True
        # Loop over the number of contained images (IPA.Sequential.Count)
        for num in range(IPA.Sequential.Count):
            # Select the frame
            IPA.Sequential.SelectIndex(num)
            # Run Get Profile and save with the frame number appended
            IPA.Profile.GetProfile(filename + '_' + str(num))
```

## Convertir par lots plusieurs fichiers (stl, his, ...) en TIFF

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
