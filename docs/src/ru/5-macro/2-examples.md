<!-- 261124Cl: Retranslated from en/5-macro/2-examples.md (UI labels follow the localized GUI). -->

# Примеры

Приведённые ниже примеры можно скопировать и вставить прямо в редактор макросов. Функции, использующие диалог, например `IPA.File.GetFileNames()`, при выполнении открывают окно выбора файлов. Подробности о каждом члене см. в разделе [Встроенные функции](1-built-in-functions.md).

!!! tip "Совет"
    Включите **Показать примеры (Show samples)** в редакторе макросов, чтобы просмотреть более богатый набор примеров только для чтения (базовые циклы, математические функции, настройка геометрии, азимутальное деление, маскирование, отправка в PDIndexer и т. д.). Просмотреть их сначала — хороший способ освоить стиль.

## Преобразование нескольких файлов в 1D-профили с сохранением (файлы с одним изображением)

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

## Преобразование нескольких файлов в 1D-профили с сохранением (файлы с несколькими изображениями)

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

## Пакетное преобразование нескольких файлов (stl, his, ...) в TIFF

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
