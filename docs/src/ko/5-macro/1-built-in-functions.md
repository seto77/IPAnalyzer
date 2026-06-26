<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

`IPA` 루트 객체 아래에 네임스페이스별로 그룹화된, 매크로에서 호출 가능한 메서드와 속성입니다. 설명은 매크로 편집기의 편집기 내 도움말(`[Help]` 속성)을 따릅니다. 편집기 내 도움말이 가장 권위 있고 최신의 참조입니다.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | 디렉터리의 전체 경로를 반환합니다. `filename`을 생략하면 폴더 선택 대화 상자가 열립니다. |
| `GetFileName(message="")` | 파일 대화 상자를 열고 선택한 파일의 전체 경로를 반환합니다. |
| `GetFileNames(message="")` | 다중 선택 대화 상자를 열고 전체 경로를 문자열 배열로 반환합니다. |
| `GetAllFileNames(message="")` | 폴더를 선택하고 그 안의 모든 파일(재귀적)의 전체 경로를 배열로 반환합니다. |
| `ReadImage(filename="", flag=None)` | 이미지 파일을 읽습니다. 생략하면 선택 대화 상자가 열립니다. |
| `ReadImageHDF(filename, flag)` | HDF5 이미지를 읽습니다. `flag`는 정규화를 토글합니다. |
| `SaveImage(filename="")` | 현재 이미지를 저장합니다(레거시 별칭, 기본값은 TIFF). |
| `SaveImageAsTIFF(filename="")` | 이미지를 TIFF로 저장합니다. |
| `SaveImageAsPNG(filename="")` | 이미지를 PNG로 저장합니다. |
| `SaveImageAsIPA(filename="")` | 이미지를 IPA 형식으로 저장합니다. |
| `SaveImageAsCSV(filename="")` | 이미지를 CSV로 저장합니다. |
| `ReadParameter(filename="")` | 매개변수 파일을 읽습니다. |
| `SaveParameter(filename="")` | 현재 매개변수를 저장합니다. |
| `ReadMask(filename="")` | 마스크 파일을 읽습니다. |
| `SaveMask(filename="")` | 현재 마스크를 저장합니다. |

모든 읽기/저장 메서드에서, 파일 이름을 생략하거나 잘못된 이름을 지정하면 선택 대화 상자가 열립니다.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | 입사 빔의 파장을 설정합니다(단위: nm). |
| `WaveLength` | 파장을 설정/가져옵니다(단위: nm). |
| `WaveSource` | 선원을 정수로 설정/가져옵니다. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | X선 파장 선을 정수로 설정합니다(설정 전용). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | 중심(직접 스폿) 위치를 설정합니다(단위: 픽셀). |
| `SetCameraLength(length)` | 카메라 길이를 설정합니다(단위: mm). |
| `CenterX` | 중심 위치의 X 값을 설정/가져옵니다(단위: 픽셀). |
| `CenterY` | 중심 위치의 Y 값을 설정/가져옵니다(단위: 픽셀). |
| `CameraLength` | 카메라 길이를 설정/가져옵니다(단위: mm). |
| `PixelSizeX` | 픽셀 X 크기(픽셀 너비)를 설정/가져옵니다(단위: mm). |
| `PixelSizeY` | 픽셀 Y 크기(픽셀 높이)를 설정/가져옵니다(단위: mm). |
| `PixelKsi` | 픽셀 기울기 ξ를 설정/가져옵니다(단위: 도). |
| `TiltPhi` | 기울기 φ를 설정/가져옵니다(단위: 도). |
| `TiltTau` | 기울기 τ를 설정/가져옵니다(단위: 도). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. 이미지를 음의 그라데이션으로 그립니다(`PositiveGradient`의 반대). |
| `PositiveGradient` | True/False. 이미지를 양의 그라데이션으로 그립니다(`NegativeGradient`의 반대). |
| `LinearScale` | True/False. 선형 스케일로 그립니다(`LogScale`의 반대). |
| `LogScale` | True/False. 로그 스케일로 그립니다(`LinearScale`의 반대). |
| `GrayScale` | True/False. 회색조로 그립니다(`ColorScale`의 반대). |
| `ColorScale` | True/False. 컬러 스케일로 그립니다(`GrayScale`의 반대). |
| `Maximum` | 최대 밝기 레벨을 설정/가져옵니다(float). |
| `Minimum` | 최소 밝기 레벨을 설정/가져옵니다(float). |
| `CanvasMagnification` | 이미지 배율을 설정/가져옵니다(float). |
| `SetCanvasCenter(x, y)` | 캔버스 중심 위치를 설정합니다(단위: 픽셀). |
| `SetCanvasSize(width, height)` | 캔버스(픽처 박스) 크기를 설정합니다(단위: 픽셀). |
| `SetArea(top, bottom, left, right)` | 상/하/좌/우 경계로 캔버스 영역을 설정합니다(단위: 픽셀). |
| `SetFullArea()` | 전체 이미지가 보이도록 캔버스 영역을 설정합니다. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | 스폿을 마스킹합니다("Mask Spots" 버튼과 동일). |
| `ClearMask()` | 현재 마스크를 지웁니다. |
| `InvertMask()` | 현재 마스크 상태를 반전합니다. |
| `MaskAll()` | 전체 영역을 마스킹합니다. |
| `MaskTop()` | 위쪽 절반을 마스킹합니다. |
| `MaskBottom()` | 아래쪽 절반을 마스킹합니다. |
| `MaskLeft()` | 왼쪽 절반을 마스킹합니다. |
| `MaskRight()` | 오른쪽 절반을 마스킹합니다. |
| `TakeOver` | 마스크 인계 설정을 설정/가져옵니다(정수). 0: None, 1: 현재 마스크 상태를 인계, 2: 마스크 파일을 인계. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. 동심으로 적분합니다(2θ–강도). |
| `RadialIntegration` | True/False. 반경 방향으로 적분합니다(피자 컷). |
| `AzimuthalDivision` | True/False. 방위각 분할 모드로 처리합니다. |
| `AzimuthalDivisionNumber` | 정수. Debye 고리 분할 개수를 설정합니다. |
| `FindCenterBeforeGetProfile` | True/False. Get Profile 전에 Find Center를 실행합니다. |
| `MaskSpotsBeforeGetProfile` | True/False. Get Profile 전에 Mask Spots를 실행합니다. |
| `SendProfileViaClipboard` | True/False. 클립보드를 통해 프로파일을 PDIndexer로 보냅니다. |
| `SaveProfileAfterGetProfile` | True/False. Get Profile 후에 프로파일을 저장합니다. |
| `SaveProfileAsPDI` | True/False. PDI 형식으로 저장합니다. |
| `SaveProfileAsCSV` | True/False. CSV 형식으로 저장합니다. |
| `SaveProfileAsTSV` | True/False. TSV 형식으로 저장합니다. |
| `SaveProfileAsGSAS` | True/False. GSAS 형식으로 저장합니다. |
| `SaveProfileInOneFile` | True/False. 순차/방위각 분할 프로파일을 하나의 파일에 저장합니다. |
| `SaveProfileAtImageDirectory` | True/False. 이미지와 같은 디렉터리에 저장합니다. |
| `GetProfile(filename="")` | 1차원화를 실행합니다. `filename`을 지정하면 프로파일이 해당 파일에 저장됩니다. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. 동심으로 적분합니다(2θ–강도). |
| `RadialIntegration` | True/False. 반경 방향으로 적분합니다(피자 컷 / cake 패턴). |
| `ConcentricStart` | Float. 동심 적분의 시작 값. |
| `ConcentricEnd` | Float. 동심 적분의 끝 값. |
| `ConcentricStep` | Float. 동심 적분의 간격 값. |
| `ConcentricUnit` | 정수. 동심 적분의 단위. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. 반경 적분의 도넛 반지름. |
| `RadialWidgh` | Float. 반경 적분의 도넛 너비. 참고: 현재 버전에서 멤버 철자는 `RadialWidgh`입니다. |
| `RadialStep` | Float. 반경 적분의 섹터 각도(스윕 간격). |
| `RadialUnit` | 정수. 반경 적분의 단위. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. 현재 파일이 순차 이미지인지 여부를 가져옵니다. |
| `Count` | 정수. 이미지 개수를 가져옵니다. |
| `SelectedIndex` | 정수. 선택된 인덱스를 설정/가져옵니다(0부터 시작). |
| `SelectedIndices` | 정수 배열. 선택된 인덱스를 설정/가져옵니다(다중 선택 모드용). |
| `MultiSelection` | True/False. 다중 선택 모드를 설정/가져옵니다. |
| `Averaging` | True/False. 평균화 모드를 설정/가져옵니다. |
| `SelectIndex(index)` | 단일 선택 인덱스를 설정합니다(다중 선택을 끔). |
| `AppendIndex(index)` | 현재 선택에 인덱스 하나를 추가합니다. |
| `SelectIndices(start, end)` | 연속 범위를 설정합니다(start부터 end까지, 양 끝 포함). |
| `AppendIndices(start, end)` | 현재 선택에 연속 범위를 추가합니다(start부터 end까지, 양 끝 포함). |
| `Target_SelectedImages` | True/False. 선택된 이미지를 Get Profile의 대상으로 만듭니다. |
| `Target_AllImages` | True/False. 모든 이미지를 Get Profile의 대상으로 만듭니다. |
| `Target_TopmostImage` | True/False. 맨 위 이미지만 Get Profile의 대상으로 만듭니다. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. PDIndexer에서 매크로를 단계별로 실행합니다. |
| `Timeout` | 매크로 작업의 제한 시간(초)을 설정/가져옵니다(기본값 30초). |
| `RunMacro(obj1, obj2, ...)` | PDIndexer에서 매크로 코드를 실행합니다. 매개변수는 PDI에서 `Obj[1]`, `Obj[2]`, … 로 읽힙니다. |
| `RunMacroName(name, obj1, obj2, ...)` | PDIndexer에서 이름이 지정된 매크로 `name`을 실행합니다. 매개변수는 PDI에서 `Obj[1]`, `Obj[2]`, … 로 읽힙니다. |
