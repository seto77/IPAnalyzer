<!-- 261124Cl: Retranslated from en/2-property-windows.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 속성 창

속성 창에서는 선원, 검출기 조건, 그리고 이미지를 1차원 프로파일로 적분하기 위한 여러 조건을 설정합니다. 각 탭은 메인 창의 **속성 (Property)** 메뉴에서 바로 열 수도 있습니다.

아래의 라벨은 한국어 UI 의 표시명이며, 괄호 안은 영어 UI 의 이름입니다. 제목에는 실제 탭 이름과 컨트롤 이름을 사용합니다.

## 파원 (Wave source)

입사 빔의 종류와 파장을 설정합니다. 선원은 X선, 전자, 중성자 중에서 고를 수 있습니다. X선에서는 원소와 전이 (K선, L선 등) 를 선택하면 파장이 자동으로 입력되고, 방사광에서는 파장을 직접 입력합니다. 전자선과 중성자선에서는 에너지 또는 파장을 입력합니다 (전자선의 파장은 상대론적으로 보정됩니다).

- **선편광 보정 (즉, 선편광 → 무편광) (Correct linear polarization (i.e., linear polarized → unpolarized))**: 선편광된 강도를 무편광 상당의 강도로 보정합니다 (방사광 데이터용). 아래 보정식은 방위각 χ 와 산란각 2θ 에 의존합니다. χ 의 기준 방향 (기타 (Miscellaneous) 탭에서 설정) 이 왼쪽 (Left) / 오른쪽 (Right) 이면 수평 편광으로, 위 (Top) / 아래 (Bottom) 이면 수직 편광으로 취급합니다.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![파원 (Wave source) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## 검출기 조건 (Detector condition)

검출기의 기하 조건을 설정합니다. 이전의 "IP Condition" 에 해당하며, 좌표계와 검출기 모양의 선택이 추가되어 있습니다.

- **좌표 (Coordinates)**: **다이렉트 스폿 (Direct spot)** (다이렉트 스폿 기준) / **푸트 (Foot)** (수선의 발 기준).
- **검출기 종류 (Detector type)**: **평판 (Flat panel)** / **간돌피 (Gandolfi)**.
- **다이렉트 스폿 위치 (Direct spot position)** 와 **카메라 길이 1 (Camera Length 1)**: 다이렉트 스폿 위치 (X, Y pix) 와 시료에서 다이렉트 스폿까지의 거리 (mm).
- **푸트 위치 (Foot position)** 와 **카메라 길이 2 (Camera Length 2)**: 푸트 (Foot) 모드에서 수선의 발 위치와 시료에서 수선의 발까지의 거리.
- **픽셀 모양 (Pixel Shape)**: 픽셀 크기 X, Y (mm) 와 ξ (Ksi, 평행사변형의 비틀림 각).
- **간돌피 반지름 (Gandolfi Radius)**: 간돌피 (Gandolfi) 모양을 선택했을 때의 반지름.
- **구면 보정 (Spherical correction)**: 휘어진 검출기의 경우 곡률 반지름의 역수 1/R 을 m⁻¹ 단위로 입력합니다 (화면에 표시되는 단위는 /m). 평판 검출기에서는 0 으로 합니다.
- **기울기 (Tilt)**: IP 기울기 φ (Phi) 와 τ (Tau).

기울기 φ, τ 와 픽셀 ξ 의 정의는 [개요](0-overview.md)를 참조하십시오.

![검출기 조건 (Detector condition) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## 적분 영역 (Integral Region)

적분할 이미지 영역을 지정합니다.

- **직사각형 (Rectangle)**: **방향 (Direction)** (전체 (Full) / 위 (Top) / 아래 (Bottom) / 왼쪽 (Left) / 오른쪽 (Right) / Vertical / Horizontal / Free) 을 고르고, **밴드 폭 (Band Width)**, **각도 (Angle)** (Free 모드에서), **양면 (Both Side)** 을 설정합니다.
- **섹터 (Sector)**: **시작 각도 (Start Angle)** / **끝 각도 (End Angle)** 로 각도 범위를 지정합니다.
- **예외 픽셀 (Exceptional pixels)**: **마스크된 스폿 (Masked Spots)**, 지정한 임계값에 대해 **다음 강도 미만 (Under intensity of)** / **다음 강도 초과 (Over intensity of)** 인 픽셀, 그리고 **가장자리로부터의 픽셀 (pixels from edges)** 수만큼의 픽셀을 제외합니다. 임계값에 의한 마스크는 강도가 바뀔 때마다 보정 후의 강도로 다시 계산됩니다. 연속 이미지에서 다른 프레임을 선택했을 때, 뒤집기/회전 후, 그리고 배경 차감이나 편광 보정을 변경했을 때입니다.

![적분 영역 (Integral Region) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## 적분 속성 (Integral Property)

적분 방식과 스텝을 설정합니다.

- **동심 적분 (산란각 분산) (Concentric integration (scattering angle dispersive))**: 가로축 단위를 **각도 (Angle)** (2θ, °) / **d-간격 (d-spacing)** (Å) 중에서 고르고, **시작 / 끝 / 스텝 (Start / End / Step)** 을 설정합니다. **출력 패턴 (Output pattern)** 의 선택 (브래그-브렌타노 (Bragg - Brentano) / 디바이-셰러 (Debye - Scherrer)) 은 현재 버전에서는 결과에 영향을 주지 않습니다.
- **방사 적분 (케이크 패턴) (Radial integration (cake pattern))**: 고리 모양 영역의 강도를 방위각마다 합산합니다. 고리의 중심 (**도넛 반지름 (Donut radius)**) 과 반폭 (**도넛 폭 (Donut width)**) 을 산란각 2θ (**각도 (Angle)**) 또는 d-간격 (**d-간격 (d-spacing)**) 으로 지정하고, **섹터 각도 스텝 (스윕 스텝) (Sector angle step (Sweep step))** (방위각 스텝) 을 설정합니다. 얻어지는 프로파일의 가로축은 방위각 χ (°) 입니다.

![적분 속성 (Integral Property) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## 마스크 옵션 (Mask Option)

마스크와 스폿 검출의 조건을 설정합니다 (이전의 "Find Center & Spots" 를 확장한 것). 중심 검출의 설정은 기타 (Miscellaneous) 탭에 있습니다.

- **반쪽 마스크 (Half mask)**: 이미지의 위, 아래, 왼쪽, 오른쪽 절반을 빠르게 마스크하는 버튼입니다.
- **수동 마스크 모드 (Manual mask mode)**: 메인 이미지 위에서 대화식으로 마스크할 수 있게 합니다. 모양은 **원 (Circle)** (드래그로 중심과 반지름 설정), **다각형 (Polygon)** (클릭으로 꼭짓점 추가), **직사각형 (Rectangle)** (대각 꼭짓점을 드래그), **스플라인 곡선 (Spline curve)**, **스폿 (Spot)** (왼쪽/오른쪽 클릭으로 스폿 추가/제거) 입니다.
- **마스크 설정 이어받기 (Take over mask setting)**: 새 이미지를 불러올 때 마스크를 다루는 방법 (**없음 (None)** / **현재 마스크 상태 이어받기 (Take over the current mask state)** / **마스크 파일 이어받기 (Take over the mask file)**).
- **스폿 마스크 옵션 (Mask spots option)** → **"스폿 마스크"용 기준 편차 (Criterial deviation for "Mask Spots")**: 스폿 검출의 통계적 임계값입니다 (픽셀이 스폿으로 간주되려면 평균보다 표준편차의 몇 배만큼 높아야 하는지).

![마스크 옵션 (Mask Option) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## "프로파일 가져오기" 후 (After "Get Profile")

적분 후의 저장과 전송을 설정합니다.

- **프로파일 저장 (Save Profiles)**: **저장할 디렉터리 (Directory to be saved)** 에서 저장 위치 (**이미지와 같은 디렉터리에 (At the same directory of the image)** / **매번 선택한 디렉터리에 (At the chosen directory each time)**) 를, **파일 형식 (File format)** 에서 형식 (**PDI** / **CSV** / **TSV** / **GSAS**) 을 고릅니다. GSAS 출력은 가로축이 2θ 인 동심 적분에서만 가능합니다. **연속 이미지 또는 방위 분할 저장 옵션 (Saving option)** (연속 이미지 또는 방위각 분할용) 에서 **하나의 파일에 (GSAS 제외) (In one file (Excluding GSAS))** 를 고르면 GSAS 는 쓰이지 않으므로, 대신 **개별 파일로 (In separate files)** 를 고르십시오.
- **클립보드를 통해 프로파일 데이터를 PDIndexer로 전송 (Send profile data to PDIndexer through Clipboard)**: 실행 중인 PDIndexer 로 클립보드를 통해 프로파일을 보냅니다.

!["프로파일 가져오기" 후 (After "Get Profile") 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## 펼친 이미지 옵션 (Unrolled Image Option)

펼친 (Unroll) 이미지의 매개변수를 설정합니다.

- **수평 (다이렉트 스폿으로부터의 거리) 단위 및 범위 (Horizontal (distance from direct spot) unit and range)**: 산란각 2θ (°) 로 **시작 / 끝 / 스텝 (Start / End / Step)** 을 지정합니다 (단위 선택지가 표시되지만, 현재 버전에서는 값을 항상 2θ 로 취급합니다). 출력 이미지의 폭 ≈ (끝 − 시작) / 스텝.
- **수직 (섹터 각도) 스텝 (Vertical (sector angle) step)**: 방위각 방향의 분할 수 N. 출력 이미지의 높이는 N 픽셀이며, 각 행은 360°/N 을 담당합니다 (기본값 720 이면 0.5°).

펼치기는 다이렉트 스폿을 중심으로 하는 극좌표의 회절 이미지를 직교 좌표 (각도 대 거리) 이미지로 변환합니다.

![펼친 이미지 옵션 (Unrolled Image Option) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## 기타 (Miscellaneous)

표시와 좌표에 관한 세부 설정을 모은 탭입니다.

- **이미지 이름 옵션 (Image name options)**: **파일 이름 (File name)** / **마지막 폴더 + 파일 이름 (Last folder + file name)** / **전체 경로 (Full path)**.
- **이미지 불러오기 옵션 (Image loading options)** → **표시 범위 유지 (Maintain display range)**: 새 이미지를 불러올 때 확대율과 표시 위치 (표시 범위) 를 이어받을지 여부.
- **카이 (χ) 축 옵션 (Chi (χ) axis options)**: 기준 위치 (위 (Top) / 아래 (Bottom) / 왼쪽 (Left) / 오른쪽 (Right)) 와 회전 방향 (시계 방향 (Clockwise) / 반시계 방향 (Counterclockwise)). χ 는 편광 보정과 방사 적분에서 참조됩니다.
- **눈금선 옵션 (Scale line options)**: 색 (**2θ scale line** / **Azimuth scale line**), **선 폭 (Line Width)**, **분할 (Division)**, **라벨 표시 (Show labels)**.
- **중심 찾기 옵션 (Find center options)**: **Search area ±**, **Peak fitting range (2θ)**, **중심 고정 (Fix Center)**, **마스크된 픽셀 제외 (Exclude masked pixels)**.

![기타 (Miscellaneous) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## 배경 옵션 (Background Option)

배경 이미지에 의한 보정을 설정합니다.

- **참조 이미지 설정 (Reference image setting)**: 현재 표시 중인 이미지를 배경으로 설정하거나 (**현재 이미지를 배경으로 설정 (Set the current image as background)**), 지웁니다 (**지우기 (Clear)**).
- **계수 (Coefficient)**: 배경 이미지에 곱하는 계수입니다.

공기 산란처럼 더해지는 배경을 빼는 데 사용합니다. 각 픽셀에 대해 \(I_\mathrm{out} = I - cB\) 를 계산합니다 (\(B\): 배경 이미지, \(c\): 계수). 이미지 가장자리 부근의 픽셀을 제외하려면 적분 영역 (Integral Region) 탭의 **가장자리로부터의 픽셀 (pixels from edges)** 을 사용합니다.

![배경 옵션 (Background Option) 탭](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
