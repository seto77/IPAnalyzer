<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# 부록

이 부록은 IPAnalyzer가 2차원 회절 이미지(Debye–Scherrer 고리)를 고정밀 1차원 프로파일로 변환할 때 사용하는 **기하 및 알고리즘의 이론적 배경**을 정리합니다. 조작 절차와 각 기능의 사용 방법은 본 매뉴얼([0. 개요](../0-overview.md), [4. 작업 절차](../4-procedures.md) 등)을 참조하세요. 여기서는 그 배경이 되는 좌표계 정의, 좌표 변환, 매개변수 결정 방법, 적분 알고리즘을 수식과 함께 설명합니다.

내용은 배포 패키지에 포함된 레거시 문서 `doc/IPAnalyzerAlgorithm.pdf`와 현재 구현을 바탕으로 합니다.

## 부록의 구성

- **[A1. 검출기 기하 및 좌표 변환](a1-geometry.md)** — 오른손 좌표계의 정의, IP 기울기($\varphi,\ \tau$)를 기술하는 회전 행렬, 픽셀 모양($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$)의 보정.
- **[A2. 매개변수 결정](a2-calibration.md)** — 표준 물질을 이용한 카메라 길이, 파장, 픽셀 크기, IP 기울기의 보정(2거리법, 2선법, 타원 피팅).
- **[A3. 이미지 적분](a3-image-integration.md)** — 픽셀 강도를 각도 스텝으로 분배하는 면적 분할 알고리즘.
- **[A4. 대칭 정보](a4-symmetry-information.md)** — 공간군 대칭, 기하 계산, Wyckoff 위치, 반사 조건, 표준 결정의 대칭 요소 도표(Crystal 창의 하위 창).
- **[A5. 산란 인자](a5-scattering-factor.md)** — 표준 결정의 구조 인자와 반사 목록(X선, 전자, 중성자)(Crystal 창의 하위 창).

## 좌표계 (공통 참조 그림)

다음의 각 페이지는 공통 전제로서 동일한 좌표계를 가정합니다. 원점은 IP 상의 직접 스폿(빔이 IP와 교차하는 지점)이며, $Z$ 축은 빔 진행 방향이고, 시료는 $(0,\ 0,\ -\mathrm{CL})$에 위치합니다.

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## 주요 매개변수

| Symbol | Name | 의미 |
|------|------|------|
| $\lambda$ | Wave Length | 선원의 파장. 특성 X선에서는 알려져 있으며, 방사광에서는 모노크로미터 위치에 따라 변하므로 매번 결정해야 합니다. |
| $\mathrm{CL}$ | Camera Length | 시료와 원점(직접 스폿) 사이의 거리. 시료 위치는 $(0,0,-\mathrm{CL})$입니다. |
| $\varphi,\ \tau$ | Tilt Correction | 광축($Z$ 축)에 대한 IP의 기울기. $\varphi$는 XY 평면에서 기울기 축의 방위각이고, $\tau$는 그 축을 중심으로 한 회전각입니다. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | 픽셀을 평행사변형으로 나타냅니다. $\xi$는 판독 레이저 스캔 시작점의 오프셋(왜곡 각도)입니다. |

이 값들은 속성 창의 IP Condition 탭에서 설정합니다([2. 속성 창](../2-property-windows.md) 참조).
