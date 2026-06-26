<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Property Windows

속성 창은 선원, 검출기 조건, 그리고 다양한 1차원화 조건을 설정하는 곳입니다. 각 탭은 메인 창의 **Property** 메뉴에서 직접 열 수도 있습니다.

이 창의 UI는 영어입니다. 아래 제목은 실제 탭 및 컨트롤 이름을 사용합니다.

## Wave source

입사 빔의 종류와 파장을 설정합니다. 선원은 X선, 전자, 또는 중성자가 될 수 있습니다. X선의 경우, 원소와 전이(K선, L선 등)를 선택하면 파장이 자동으로 입력됩니다. 방사광의 경우에는 파장을 직접 입력합니다. 전자 및 중성자 빔의 경우, 에너지 또는 파장을 입력합니다(전자 파장은 상대론적으로 보정됩니다).

- **Correct linear polarization**: 선형 편광된 강도를 비편광 등가값으로 보정합니다(방사광 데이터용). 아래 보정식은 방위각 χ(Miscellaneous 탭에서 정의됨)와 산란각 2θ에 의존합니다.

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

검출기의 기하 조건을 설정합니다. 이는 기존의 "IP Condition"에 해당하며, 좌표계 및 검출기 모양 선택기가 추가되었습니다.

- **Coordinates**: **Direct spot**(직접 스폿 기준) / **Foot**(수선의 발 기준).
- **Detector type**: **Flat panel** / **Gandolfi**.
- **Direct spot position** 및 **Camera Length 1**: 직접 스폿 위치(X, Y pix)와 시료에서 직접 스폿까지의 거리(mm).
- **Foot position** 및 **Camera Length 2**: Foot 모드에서 수선의 발 위치와 시료에서 수선의 발까지의 거리.
- **Pixel Shape**: 픽셀 크기 X, Y(mm)와 ξ(Ksi, 평행사변형 기울임 각).
- **Gandolfi Radius**: Gandolfi 모양을 선택했을 때의 반경.
- **Spherical correction**: 구면 보정(보통 0).
- **Tilt**: IP 기울기 φ(Phi)와 τ(Tau).

기울기 φ, τ 및 픽셀 ξ의 정의는 [Overview](0-overview.md)를 참조하십시오.

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

1차원화할 이미지 영역을 지정합니다.

- **Rectangle**: **Direction**(Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free)을 선택하고, **Band Width**, **Angle**(Free 모드에서), **Both Side**를 설정합니다.
- **Sector**: **Start Angle** / **End Angle**로 각도 범위를 지정합니다.
- **Exceptional pixels**: **Masked Spots**, 주어진 임계값 **Under intensity of** / **Over intensity of**에 해당하는 픽셀, 그리고 **pixels from edges** 개수를 제외합니다.

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

적분 방법과 스텝을 설정합니다.

- **Concentric integration (scattering-angle dispersive)**: 가로축 단위를 **Angle**(2θ, °) / **Length**(mm) / **d-spacing**(Å)에서 선택하고, **Start / End / Step**을 설정합니다. **Output pattern**은 **Bragg - Brentano** 또는 **Debye - Scherrer**가 될 수 있습니다.
- **Radial integration (cake pattern)**: 고리 모양 영역을 방위각 방향으로 분석합니다. 가로축을 **Angle** / **d-spacing**에서 선택하고, **Donut radius**(중심 반경), **Donut width**(고리 폭), **Sector angle step**(스윕 스텝)을 설정합니다.

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

마스킹 및 중심/스폿 검출 조건을 설정합니다(기존 "Find Center & Spots"의 확장).

- **Half mask**: 이미지의 위, 아래, 왼쪽, 오른쪽 절반을 빠르게 마스킹하는 버튼입니다.
- **Manual mask mode**: 메인 이미지에서 대화식 마스킹을 활성화합니다. 모양은 **Circle**(드래그하여 중심과 반경 설정), **Polygon**(클릭하여 꼭짓점 추가), **Rectangle**(대각선 꼭짓점 드래그), **Spline curve**, **Spot**(좌/우 클릭으로 스폿 추가/제거)입니다.
- **Takeover**: 새 이미지를 불러올 때 마스크를 어떻게 처리할지(**None** / **Take over the current mask state** / **Take over the mask file**).
- **Find Spots** → **Deviation**: 스폿 검출을 위한 통계적 임계값.
- **Find Center**: 중심 검출을 위한 탐색 범위 등.

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

1차원화 후의 저장 및 전송을 설정합니다.

- **Save File**: 대상("이미지와 동일한 디렉터리" 또는 "매번 선택하는 디렉터리")과 형식을 **PDI** / **CSV** / **TSV** / **GSAS**에서 선택합니다.
- **Send PDIndexer**: 클립보드를 통해 실행 중인 PDIndexer 인스턴스로 프로파일을 전송합니다.

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

펼친(Unroll) 이미지의 매개변수를 설정합니다.

- **Horizontal**: 단위(Angle / Length / d-spacing)와 **Start / End / Step**. 출력 이미지 너비 ≈ (End − Start) / Step.
- **Vertical**: 방위각 스텝(°/pixel). 출력 이미지 높이 ≈ 360 / step.

펼치기(Unrolling)는 직접 스폿을 중심으로 하는 극좌표 회절 이미지를 직교(각도 대 거리) 이미지로 매핑합니다.

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

세부 표시 및 좌표 설정을 모아 놓은 탭입니다.

- **Image name display**: 파일 이름만 / 상위 폴더 + 파일 이름 / 전체 경로.
- **Contrast / intensity-range persistence**: 새 이미지를 불러올 때 표시 설정을 유지할지 여부.
- **Azimuth χ (Chi) orientation**: 기준 위치(Top / Bottom / Left / Right)와 회전 방향(Clockwise / Counterclockwise). χ는 편광 보정과 반경 적분에서 참조됩니다.
- **Scale line**: 색상, 너비, 분할 수, 레이블 표시.
- **Find Center**: 탐색 범위, 피크 피팅 범위, 중심 고정, 마스킹된 픽셀 제외.

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

배경 이미지에 의한 보정을 설정합니다.

- **Background image**: 현재 표시된 이미지를 배경으로 설정하거나(**Set the current image as background**) 지웁니다(**Clear**).
- **Coefficient**: 배경 이미지에 적용하는 계수.
- **Edge mask**: 보정 시 가장자리에 적용하는 추가 마스크 여백(px).

플랫필드 보정, 공기 산란 제거 등에 사용됩니다.

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
