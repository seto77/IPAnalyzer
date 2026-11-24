<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 부록

이 부록은 IPAnalyzer 가 2차원 회절 이미지 (Debye–Scherrer 고리) 를 고정밀 1차원 프로파일로 변환할 때 사용하는 **기하와 알고리즘의 이론적 배경**을 정리한 것입니다. 조작 절차와 각 기능의 사용법은 본편 매뉴얼 ([0. 개요](../0-overview.md), [4. 작업 절차](../4-procedures.md) 등) 을 참조하십시오. 여기서는 그 뒤에 있는 좌표계의 정의, 좌표 변환, 매개변수 결정 방법, 적분 알고리즘을 수식과 함께 설명합니다.

내용은 배포 패키지에 동봉된 이전 문서 `doc/IPAnalyzerAlgorithm.pdf` 와 현재 구현을 바탕으로 합니다.

## 부록의 구성

- **[A1. 검출기 기하와 좌표 변환](a1-geometry.md)** — 오른손 좌표계의 정의, IP 기울기 ($\varphi,\ \tau$) 를 나타내는 회전 행렬, 픽셀 모양 ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$) 의 보정.
- **[A2. 매개변수 결정](a2-calibration.md)** — 표준 물질을 이용한 카메라 길이, 파장, 픽셀 크기, IP 기울기의 보정 (두 거리법, 두 회절선법, 타원 피팅).
- **[A3. 이미지 적분](a3-image-integration.md)** — 픽셀 강도를 각도 스텝으로 분배하는 면적 분할 알고리즘과 적분 후의 규격화.
- **[A4. 대칭 정보](a4-symmetry-information.md)** — 표준 결정의 공간군 대칭, 기하 계산, Wyckoff 위치, 반사 조건, 대칭 요소 도 (결정 창의 하위 창).
- **[A5. 산란 인자](a5-scattering-factor.md)** — 표준 결정의 구조 인자와 반사 목록 (X선, 전자, 중성자) (결정 창의 **빔 상호작용 (Beam interaction)** 에 있는 **반사 (Reflections)** 탭).

## 좌표계 (공통 참조 그림)

이후의 각 페이지는 같은 좌표계를 공통 전제로 합니다. 원점은 IP 위의 다이렉트 스폿 (빔이 IP 와 교차하는 점), $Z$ 축은 빔의 진행 방향이며, 시료는 $(0,\ 0,\ -\mathrm{CL})$ 에 위치합니다.

![IPAnalyzer 의 좌표계. IP (이미징 플레이트), X / Y / Z 축, Debye 고리, 기울기 각 φ 와 τ, (0,0,−CL) 에 있는 시료, 카메라 길이 CL, 회절각 2θ, 파장 λ, 픽셀 모양 (PixSizeX, PixSizeY, ξ) 을 보여 줍니다.](../../assets/references/geometry-coordinate-system.png){width=520px}

## 주요 매개변수

| 기호 | 이름 | 의미 |
|------|------|------|
| $\lambda$ | 파장 (Wave Length) | 선원의 파장. 특성 X선에서는 알려져 있지만, 방사광에서는 모노크로메이터의 위치에 따라 달라지므로 매번 결정해야 합니다. |
| $\mathrm{CL}$ | 카메라 길이 (Camera Length) | 시료와 원점 (다이렉트 스폿) 사이의 거리. 시료 위치는 $(0,0,-\mathrm{CL})$ 입니다. 화면의 **카메라 길이 1 (Camera Length 1)** 에 해당하며, **카메라 길이 2 (Camera Length 2)** 는 시료에서 검출기까지의 수직 거리로, 기울기 $\tau$ 가 있으면 값이 달라집니다. |
| $\varphi,\ \tau$ | 기울기 보정 (Tilt Correction) | 광축 ($Z$ 축) 에 대한 IP 의 기울기. $\varphi$ 는 XY 평면 안에서 기울기 축의 방위각이고, $\tau$ 는 그 축을 중심으로 한 회전각입니다. |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | 픽셀 크기 (Pixel Size) | 픽셀을 평행사변형으로 나타냅니다. $\xi$ 는 판독 레이저 스캔 시작점의 어긋남 (비틀림 각) 입니다. |

파장은 속성 창의 **파원 (Wave source)** 탭에서, 카메라 길이, 기울기, 픽셀 모양은 **검출기 조건 (Detector condition)** 탭에서 설정합니다 ([2. 속성 창](../2-property-windows.md) 참조).
