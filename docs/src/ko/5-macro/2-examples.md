<!-- 261124Cl: Retranslated from en/5-macro/2-examples.md (UI labels follow the localized GUI). -->

# 예제

아래 예제는 매크로 편집기에 그대로 복사하여 붙여 넣을 수 있습니다. `IPA.File.GetFileNames()` 처럼 대화 상자를 사용하는 함수는 실행하면 파일 선택 화면이 열립니다. 각 멤버의 자세한 내용은 [내장 함수](1-built-in-functions.md)를 참조하십시오.

!!! tip
    매크로 편집기에서 **예제 표시 (Show samples)** 를 켜면 더 풍부한 읽기 전용 예제 (기본 루프, 수학 함수, 기하 설정, 방위각 분할, 마스킹, PDIndexer 로 전송 등) 를 볼 수 있습니다. 먼저 그것들을 훑어보면 작성 방식을 익히는 데 좋습니다.

## 여러 파일을 1D 프로파일로 변환하여 저장하기 (단일 이미지 파일)

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

## 여러 파일을 1D 프로파일로 변환하여 저장하기 (다중 이미지 파일)

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

## 여러 파일 (stl, his, ...) 을 TIFF 로 일괄 변환하기

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
