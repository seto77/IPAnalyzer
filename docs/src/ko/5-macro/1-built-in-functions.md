<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). -->

# 내장 함수

매크로에서 호출할 수 있는 메서드와 속성을, `IPA` 루트 객체 아래의 네임스페이스별로 정리했습니다. 설명은 매크로 편집기 내 도움말 (`[Help]` 특성) 을 따르며, 편집기 내 도움말이 최신 정본입니다.

## IPA.File

| 멤버 | 설명 |
|------|------|
| `GetDirectoryPath(filename="")` | 디렉터리의 전체 경로를 반환합니다. `filename` 을 생략하면 폴더 선택 대화 상자가 열립니다. |
| `GetFileName(message="")` | 파일 대화 상자를 열고, 선택한 파일의 전체 경로를 반환합니다. |
| `GetFileNames(message="")` | 다중 선택 대화 상자를 열고, 전체 경로들을 문자열 배열로 반환합니다. |
| `GetAllFileNames(message="")` | 폴더를 선택하고, 그 안의 모든 파일 (하위 폴더 포함) 의 전체 경로를 배열로 반환합니다. |
| `ReadImage(filename="", flag=None)` | 이미지 파일을 읽습니다. 생략하면 선택 대화 상자가 열립니다. |
| `ReadImageHDF(filename, flag)` | HDF5 이미지를 읽습니다. `flag` 로 정규화를 전환합니다. 현재 버전에서는 HDF5 (`.h5`) 읽기가 동작하지 않습니다. NeXus (`.nxs`) 파일은 `ReadImage(filename)` 으로 읽을 수 있습니다. |
| `SaveImage(filename="")` | 현재 이미지를 저장합니다 (이전 별칭, 기본값은 TIFF). |
| `SaveImageAsTIFF(filename="")` | 이미지를 TIFF 로 저장합니다. |
| `SaveImageAsPNG(filename="")` | 이미지를 PNG 로 저장합니다. |
| `SaveImageAsIPA(filename="")` | 이미지를 IPA 형식으로 저장합니다. |
| `SaveImageAsCSV(filename="")` | 이미지를 CSV 로 저장합니다. |
| `ReadParameter(filename="")` | 매개변수 파일을 읽습니다. |
| `SaveParameter(filename="")` | 현재 매개변수를 저장합니다. |
| `ReadMask(filename="")` | 마스크 파일을 읽습니다. |
| `SaveMask(filename="")` | 현재 마스크를 저장합니다. |

모든 읽기/저장 메서드에서, 파일 이름을 생략하거나 올바르지 않은 파일 이름을 주면 선택 대화 상자가 열립니다.

## IPA.Wave

| 멤버 | 설명 |
|------|------|
| `SetWaveLength(wavelength)` | 입사 빔의 파장을 설정합니다 (nm 단위). |
| `WaveLength` | 파장을 설정/가져옵니다 (nm 단위). |
| `WaveSource` | 선원을 정수로 설정/가져옵니다. 0: 없음, 1: X선, 2: 전자, 3: 중성자. |
| `XrayLine` | X선 파장의 선을 정수로 설정합니다 (설정 전용). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| 멤버 | 설명 |
|------|------|
| `SetCenter(x, y)` | 중심 (다이렉트 스폿) 위치를 설정합니다 (픽셀 단위). |
| `SetCameraLength(length)` | 카메라 길이를 설정합니다 (mm 단위). |
| `CenterX` | 중심 위치의 X 값을 설정/가져옵니다 (픽셀 단위). |
| `CenterY` | 중심 위치의 Y 값을 설정/가져옵니다 (픽셀 단위). |
| `CameraLength` | 카메라 길이를 설정/가져옵니다 (mm 단위). |
| `PixelSizeX` | 픽셀의 X 크기 (픽셀 폭) 를 설정/가져옵니다 (mm 단위). |
| `PixelSizeY` | 픽셀의 Y 크기 (픽셀 높이) 를 설정/가져옵니다 (mm 단위). |
| `PixelKsi` | 픽셀 비틀림 ξ 를 설정/가져옵니다 (도 단위). |
| `TiltPhi` | 기울기 φ 를 설정/가져옵니다 (도 단위). |
| `TiltTau` | 기울기 τ 를 설정/가져옵니다 (도 단위). |

## IPA.Image

| 멤버 | 설명 |
|------|------|
| `NegativeGradient` | True/False. 이미지를 음의 계조로 그립니다 (`PositiveGradient` 의 짝). |
| `PositiveGradient` | True/False. 이미지를 양의 계조로 그립니다 (`NegativeGradient` 의 짝). |
| `LinearScale` | True/False. 선형 스케일로 그립니다 (`LogScale` 의 짝). |
| `LogScale` | True/False. 로그 스케일로 그립니다 (`LinearScale` 의 짝). |
| `GrayScale` | True/False. 그레이 스케일로 그립니다 (`ColorScale` 의 짝). |
| `ColorScale` | True/False. 컬러 스케일로 그립니다 (`GrayScale` 의 짝). |
| `Maximum` | 최대 밝기 레벨을 설정/가져옵니다 (float). |
| `Minimum` | 최소 밝기 레벨을 설정/가져옵니다 (float). |
| `CanvasMagnification` | 이미지 배율을 설정/가져옵니다 (float). |
| `SetCanvasCenter(x, y)` | 캔버스 중심 위치를 설정합니다 (픽셀 단위). |
| `SetCanvasSize(width, height)` | 캔버스 (picture box) 크기를 설정합니다 (픽셀 단위). |
| `SetArea(top, bottom, left, right)` | 위/아래/왼쪽/오른쪽 경계로 캔버스 영역을 설정합니다 (픽셀 단위). |
| `SetFullArea()` | 이미지 전체가 보이도록 캔버스 영역을 설정합니다. |

## IPA.Mask

| 멤버 | 설명 |
|------|------|
| `MaskSpots()` | 스폿을 마스크합니다 ("스폿 마스크 (Mask Spots)" 버튼과 같음). |
| `ClearMask()` | 현재 마스크를 지웁니다. |
| `InvertMask()` | 현재 마스크 상태를 반전합니다. |
| `MaskAll()` | 전체 영역을 마스크합니다. |
| `MaskTop()` | 위쪽 절반을 마스크합니다. |
| `MaskBottom()` | 아래쪽 절반을 마스크합니다. |
| `MaskLeft()` | 왼쪽 절반을 마스크합니다. |
| `MaskRight()` | 오른쪽 절반을 마스크합니다. |
| `TakeOver` | 마스크 이어받기 설정을 설정/가져옵니다 (정수). 0: 없음, 1: 현재 마스크 상태 이어받기, 2: 마스크 파일 이어받기. |

## IPA.Profile

| 멤버 | 설명 |
|------|------|
| `ConcentricIntegration` | True/False. 동심으로 적분합니다 (2θ–강도). |
| `RadialIntegration` | True/False. 방사로 적분합니다 (피자 조각 모양). |
| `AzimuthalDivision` | True/False. 방위각 분할 모드로 처리합니다. |
| `AzimuthalDivisionNumber` | 정수. Debye 고리의 분할 수를 설정합니다. |
| `FindCenterBeforeGetProfile` | True/False. Get Profile 전에 Find Center 를 실행합니다. |
| `MaskSpotsBeforeGetProfile` | True/False. Get Profile 전에 Mask Spots 를 실행합니다. |
| `SendProfileViaClipboard` | True/False. 클립보드를 통해 프로파일을 PDIndexer 로 보냅니다. |
| `SaveProfileAfterGetProfile` | True/False. Get Profile 후에 프로파일을 저장합니다. |
| `SaveProfileAsPDI` | True/False. PDI 형식으로 저장합니다. |
| `SaveProfileAsCSV` | True/False. CSV 형식으로 저장합니다. |
| `SaveProfileAsTSV` | True/False. TSV 형식으로 저장합니다. |
| `SaveProfileAsGSAS` | True/False. GSAS 형식으로 저장합니다. 가로축이 2θ 인 동심 적분에서만 가능하며, 여러 프로파일을 한 파일에 저장할 때는 쓰이지 않습니다. |
| `SaveProfileInOneFile` | True/False. 연속 이미지/방위각 분할 프로파일을 한 파일에 저장합니다. |
| `SaveProfileAtImageDirectory` | True/False. 이미지와 같은 디렉터리에 저장합니다. |
| `GetProfile(filename="")` | 1차원화를 실행합니다. `filename` 을 주면 그것을 기본 이름으로 사용하고 형식의 확장자를 덧붙입니다 (예: `GetProfile("sample.stl")` 을 CSV 로 저장하면 `sample.stl.csv`). 저장 위치가 "매번 선택" 으로 설정되어 있으면 저장 대화 상자가 표시됩니다. |

## IPA.IntegralProperty

| 멤버 | 설명 |
|------|------|
| `ConcentricIntegration` | True/False. 동심으로 적분합니다 (2θ–강도). |
| `RadialIntegration` | True/False. 방사로 적분합니다 (피자 조각 / 케이크 패턴). |
| `ConcentricStart` | Float. 동심 적분의 시작 값. |
| `ConcentricEnd` | Float. 동심 적분의 끝 값. |
| `ConcentricStep` | Float. 동심 적분의 스텝 값. |
| `ConcentricUnit` | 정수. 동심 적분의 단위. 0: 각도 (deg), 1: d-간격 (Å), 2: 길이 (mm). |
| `RadialRadius` | Float. 방사 적분의 도넛 반지름. |
| `RadialWidgh` | Float. 방사 적분의 도넛 폭. 참고: 현재 버전에서 멤버 이름의 철자는 `RadialWidgh` 입니다. |
| `RadialStep` | Float. 방사 적분의 섹터 각도 (스윕 스텝). |
| `RadialUnit` | 정수. 방사 적분의 단위. 0: 각도 (deg), 1: d-간격 (Å). |

## IPA.Sequential

| 멤버 | 설명 |
|------|------|
| `SequentialImageMode` | True/False. 현재 파일이 연속 이미지인지 여부를 가져옵니다. |
| `Count` | 정수. 이미지 수를 가져옵니다. |
| `SelectedIndex` | 정수. 선택된 인덱스 (0부터 시작) 를 설정/가져옵니다. |
| `SelectedIndices` | 정수 배열. 선택된 인덱스들을 설정/가져옵니다 (다중 선택 모드용). |
| `MultiSelection` | True/False. 다중 선택 모드를 설정/가져옵니다. |
| `Averaging` | True/False. 평균 모드를 설정/가져옵니다. |
| `SelectIndex(index)` | 단일 선택 인덱스를 설정합니다 (다중 선택을 끕니다). |
| `AppendIndex(index)` | 현재 선택에 인덱스 하나를 추가합니다. |
| `SelectIndices(start, end)` | 연속된 범위 (start 부터 end 까지, 양끝 포함) 를 설정합니다. |
| `AppendIndices(start, end)` | 현재 선택에 연속된 범위 (start 부터 end 까지, 양끝 포함) 를 추가합니다. |
| `Target_SelectedImages` | True/False. 선택된 이미지를 Get Profile 의 대상으로 합니다. |
| `Target_AllImages` | True/False. 모든 이미지를 Get Profile 의 대상으로 합니다. |
| `Target_TopmostImage` | True/False. 최상단 이미지만 Get Profile 의 대상으로 합니다. |

## IPA.PDI

| 멤버 | 설명 |
|------|------|
| `Debug` | True/False. PDIndexer 에서 매크로를 단계별로 실행합니다. |
| `Timeout` | 매크로 동작의 제한 시간 (초) 을 설정/가져옵니다 (기본값 30 초). |
| `RunMacro(obj1, obj2, ...)` | PDIndexer 의 매크로 편집기에 현재 열려 있는 코드를 실행합니다. 매개변수는 PDIndexer 쪽에서 `PDI.Obj[0]`, `PDI.Obj[1]`, … 로 읽습니다. |
| `RunMacroName(name, obj1, obj2, ...)` | PDIndexer 에 `name` 으로 저장된 매크로를 실행합니다. 매개변수는 PDIndexer 쪽에서 `PDI.Obj[0]`, `PDI.Obj[1]`, … 로 읽습니다. |
