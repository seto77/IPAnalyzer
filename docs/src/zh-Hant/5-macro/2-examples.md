<!-- 261124Cl: Retranslated from en/5-macro/2-examples.md (UI labels follow the localized GUI). -->

# 範例

以下的範例可以直接複製並貼上到巨集編輯器中。像 `IPA.File.GetFileNames()` 這類會開啟對話框的函式，在執行時會顯示檔案選擇畫面。各成員的詳細說明請參見[內建函式](1-built-in-functions.md)。

!!! tip "提示"
    在巨集編輯器中開啟 **顯示範例 (Show samples)**，即可檢視一組更豐富的唯讀範例（基本迴圈、數學函式、幾何設定、方位角分割、遮罩、傳送至 PDIndexer 等）。先瀏覽這些範例是熟悉寫法的好方法。

## 將多個檔案轉換為一維曲線並儲存（單一影像的檔案）

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

## 將多個檔案轉換為一維曲線並儲存（含多張影像的檔案）

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

## 將多個檔案（stl、his 等）批次轉換為 TIFF

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
