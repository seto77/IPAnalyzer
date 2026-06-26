<!-- 260601Cl: Reflected from ja/5-macro/2-examples.md. Migrated from the wiki; updated the stale API name FindSpotsBeforeGetProfile -> MaskSpotsBeforeGetProfile. -->

# Exemplos

Os exemplos abaixo podem ser copiados e colados diretamente no editor de macros. Funções que envolvem uma caixa de diálogo, como `IPA.File.GetFileNames()`, abrem uma tela de seleção de arquivos quando executadas. Consulte [Built-in functions](1-built-in-functions.md) para os detalhes de cada membro.

!!! tip
    Quando a lista de macros salvas do editor está vazia, um conjunto mais rico de amostras (laços básicos, funções matemáticas, configuração da geometria, divisão azimutal, mascaramento, envio ao PDIndexer, etc.) é inserido automaticamente. Examiná-las primeiro é uma boa maneira de aprender o estilo.

## Converter vários arquivos em perfis 1D e salvá-los (arquivos de imagem única)

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

## Converter vários arquivos em perfis 1D e salvá-los (arquivos de múltiplas imagens)

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

## Converter em lote vários arquivos (stl, his, ...) para TIFF

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
