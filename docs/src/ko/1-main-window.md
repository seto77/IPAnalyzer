<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# Main Window

메인 창은 IPAnalyzer를 시작했을 때 처음 표시되는 화면입니다. 불러온 회절 이미지의 표시, 주요 작업(중심 찾기, 스폿 마스킹, 1차원화), 그리고 검출기 매개변수 설정으로 들어가는 진입점을 한곳에 모아 둡니다.

이 창은 대략 상단의 메뉴와 툴바, 중앙의 이미지 표시 영역, 오른쪽의 세로 툴바, 하단의 그래프 영역으로 구성됩니다.

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## Central View

### Image display

불러온 이미지가 여기에 표시됩니다. 마우스 포인터 위치에 따라 이미지 위쪽 영역에는 실좌표(mm), 이미지 좌표(pix), 중심으로부터의 거리 R(mm), 산란각 2θ, d-value, 방위각 χ, 강도가 표시됩니다. 마젠타색 × 표시는 직접 스폿(중심) 위치를 나타냅니다.

픽셀 상태는 구분되는 색으로 표시됩니다.

| Color | Meaning |
| --- | --- |
| Cyan | 마스킹된 스폿 |
| Green | 적분에서 제외된 영역(**Integral Region**에서 설정) |
| Magenta | 적분에서 제외된 각도 영역(**Integral Property**에서 설정) |
| Blue | 강도 하한값 미만의 픽셀(**Integral Region**에서 설정) |
| Red | 강도 상한값 초과의 픽셀 |

### Mouse operations

일반 모드에서:

- 왼쪽 버튼을 누른 채 유지: 근처의 스폿 중심을 검색합니다.
- 왼쪽 더블 클릭: 클릭한 지점으로 중심 위치를 갱신합니다.
- 오른쪽 드래그: 드래그한 영역으로 확대합니다.
- 오른쪽 클릭: 축소합니다.

**Manual spot mode**에서는 왼쪽 클릭으로 마스킹하고 오른쪽 클릭으로 마스킹을 해제합니다. 마스크 모양과 크기는 툴바와 속성에서 설정합니다.

### Auxiliary views and image information

중앙 뷰 옆에는 보조 표시가 있습니다. **Whole image**와 **Near center**를 전환할 수 있는데, 전체 이미지 뷰는 현재 표시 범위를 노란색 프레임으로 표시하고, 중심 근처 뷰는 확대 이미지를 표시합니다.

**Image Information**은 이미지 해상도, 최대 강도, 총 강도, 헤더 데이터 등을 표시합니다.

### Display adjustment controls

이미지가 보이는 방식을 조정하는 컨트롤:

- **Gradient**: 색조를 반전합니다.
- **Brightness scale**: 로그 / 선형.
- **Color scale**: 그레이스케일 / 컬러.
- **Scale line**: 눈금선 표시(없음 / 거침 / 중간 / 미세함).
- **Auto Contrast** / **Reset Contrast**, 그리고 명시적인 최소/최대 강도.
- 배율 버튼(×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16).

## Lower View

하단 영역에는 탭으로 구분된 세 개의 그래프/뷰가 있습니다.

- **Frequency of Intensity**: 모든 픽셀의 강도 분포를 log–log 축으로 표시합니다. 마우스로 확대할 수 있습니다.
- **Converted Profile**: 1차원화(**Get Profile**) 후의 회절 프로파일입니다. 마우스로 확대할 수 있습니다.
- **Statistical Information**: 선택한 직사각형 영역 (X1,Y1)–(X2,Y2)의 통계입니다. 순차 이미지를 불러온 경우, 다른 프레임에서 동일 영역의 통계도 비교할 수 있습니다.

## Menus

메뉴 막대는 **File / Tool / Property / Option / Language / Macro / Help**로 구성됩니다.

### File

- **Read image**: 회절 이미지를 엽니다. 지원되는 형식은 [Overview](0-overview.md)를 참조하십시오.
- **Save image**: TIFF, PNG, CSV 또는 IPA 형식으로 저장합니다. TIFF는 원본 픽셀 강도를 보존하고, PNG는 표시(밝기, 명암, 마스크)를 보존하며, IPA는 왜곡 보정된 독자 형식(메타데이터 포함)입니다.
- **Read / Save parameter**: 파장, 카메라 길이, 픽셀 크기, 기울기 보정, 중심 위치 등을 `.prm` 파일로 가져오거나 내보냅니다.
- **Read / Save / Clear mask**: 마스크를 `.mas` 파일로 가져오거나 내보내거나, 마스크를 지웁니다(마스크는 현재 이미지의 해상도와 일치해야 합니다).
- **Close**.

이미지, 매개변수, 마스크 파일은 창에 드래그 앤 드롭하여 불러올 수도 있습니다.

### Tool

- **Reset Frequency Profile**: 강도-빈도 그래프를 지웁니다(이미지는 유지됩니다).
- **Calibrate Raxis Image**.

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous. 이들은 [속성 창](2-property-windows.md)의 해당 탭을 직접 엽니다.

### Option

- **ToolTip**: 버튼과 메뉴의 툴팁을 켜고 끕니다.
- **Flip**: 좌우 / 상하. **Rotate**: 회전 각도를 선택합니다. 둘 다 표시에만 영향을 주며, 불러온 이미지 데이터 자체는 변경되지 않습니다.
- **Ngen Compile**과 **Clear registry**는 개발 및 문제 해결용입니다.

### Language

- **English**와 **Japanese**를 전환합니다(설정은 레지스트리에 저장됩니다).

### Macro

- **Editor**: 매크로 편집기를 엽니다([Tools](3-tools.md) / [Macro](5-macro/index.md) 참조).

### Help

- **Program Updates**, **Hint**, **License**, **Version History**, **Web Page**.

## Operation toolbar

주요 이미지 처리 작업(드롭다운에 세부 옵션 있음):

- **Background**: 배경 이미지의 차감(**Background Option**에서 구성).
- **Find Center**: 2D Pseudo-Voigt 피팅으로 빔 중심을 검출합니다(검색 범위는 기본 8 px, **Miscellaneous**에서 설정). 드롭다운에서는 고리 기반 중심 검출도 제공합니다.
- **Fix center**: 중심 위치를 고정합니다.
- **Mask Spots**: 평균 ± 표준편차 × Deviation 기준으로 스폿을 검출하여 마스킹합니다. 드롭다운에는 전체 마스킹, 반전 마스킹, 수동 등이 포함됩니다.
- **Manual**: 수동 마스크 모드입니다. 모양(원 / 직사각형)과 크기(8–256 px)를 선택할 수 있습니다.
- **Get Profile**: 이미지를 1차원 프로파일로 적분합니다. Concentric(2θ 기준)과 Radial(방위각 기준)을 지원합니다. 드롭다운에서는 Integral Property/Region 선택, 적분 전 중심 찾기 및 스폿 마스킹 여부, PDIndexer로 전송, 방위각 분할 분석, 순차 이미지 처리 등을 구성합니다.

## Toolbar (other tools)

오른쪽의 세로 툴바는 여러 도구를 실행합니다. 자세한 내용은 [Tools](3-tools.md)를 참조하십시오.

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
