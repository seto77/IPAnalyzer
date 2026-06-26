<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# 개요

IPAnalyzer는 이미징 플레이트 (IP)나 CCD/CMOS 검출기로 기록한 Debye–Scherrer 고리를 고정밀·고속으로 1차원 회절 프로파일로 변환합니다. 그 설계와 기능은 산업기술종합연구소(AIST)의 Hiroshi Fujihisa가 개발한 PIP를 모델로 삼았습니다.

주요 기능:

- 다양한 이미지 포맷 지원 (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon 및 일반 이미지 포맷)
- X선, 전자, 중성자 선원
- PDIndexer와의 연계
- 측정 매개변수의 반자동 분석

## 시스템 요구 사항 및 설치

### 요구 사항

- OS: Windows (Windows 11 권장)
- 필수 런타임: .NET Desktop Runtime 10.0
- 권장 메모리: 16 GB 이상
- 권장 CPU: 8코어 이상

내부적으로 이 소프트웨어는 멀티스레드 연산을 많이 사용하므로, 코어 수가 많은 CPU일수록 더 쾌적하게 동작합니다. 이미지 강도는 내부적으로 배정밀도 부동소수점 값으로 유지됩니다.

이 소프트웨어는 MIT License로 배포됩니다.

### 설치

1. 사전에 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)을 설치합니다.
2. GitHub [releases page](https://github.com/seto77/IPAnalyzer/releases)에서 `IPAnalyzerSetup.msi`를 다운로드합니다.
3. `IPAnalyzerSetup.msi`를 실행하여 설치합니다.

## 축 방향, IP 기울기, 픽셀 모양

IPAnalyzer는 오른손 좌표계를 사용하며, 원점과 축 방향을 다음과 같이 정의합니다.

- X선 또는 전자 빔이 IP와 교차하는 점(다이렉트 스폿)을 원점 (0, 0, 0)으로 정의하고, Z축은 빔 방향과 일치합니다.
- 시료 크기를 무한히 작다고 간주하여, 시료 위치와 원점 사이의 거리를 카메라 길이(Camera Length, CL)로 정의합니다. 따라서 시료는 \((0,\ 0,\ -\mathrm{CL})\)에 위치합니다.
- X축은 IP가 기울어지지 않았을 때 IP 판독 레이저의 주사 방향에 정렬됩니다. 따라서 Y축은 화면에서 아래쪽을 향합니다.
- IP 기울기는 원점을 지나 XY 평면에 놓인 직선을 중심으로 한 회전으로 표현됩니다. 즉, X축과 \( \varphi \) 각을 이루는 직선을 중심으로 \( \tau \)만큼 회전합니다.
- 픽셀 모양은 PixSizeX, PixSizeY, \( \xi \)로 기술되는 평행사변형으로 다룹니다. \( \xi \)가 0이 아니라는 것은 IP 판독 레이저 주사의 시작 위치에 오프셋이 있음을 의미합니다. 이 소프트웨어는 이 오프셋이 Y축을 따라 일정하다고 가정합니다.

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

카메라 길이, \( \varphi \), \( \tau \), 픽셀 크기, \( \xi \)는 속성 창의 IP Condition 탭에서 설정합니다([2. 속성 창](2-property-windows.md) 참조).

### (WIN)PIP와의 관계

IPAnalyzer에서는 X축(IP 이미지의 오른쪽 방향)을 시계 방향으로 \( \varphi \)만큼 회전하고, 그 결과 얻어진 축을 다시 \( \tau \)만큼 회전합니다. PIP에서는 Y축(IP 이미지의 아래쪽 방향)을 반시계 방향으로 \( \beta \)만큼 회전하고, 그 결과 얻어진 축을 다시 \( \Phi \)만큼 회전합니다. 따라서 PIP의 \((\beta,\ \Phi)\)를 IPAnalyzer의 \((\varphi,\ \tau)\)로 변환하려면 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\)를 사용합니다.

## 픽셀 강도 적분 방법

1차원화에서 핵심 문제는, 각도 스텝 간격이 픽셀 간격(즉 픽셀 크기)보다 작을 때 발생하는, 여러 스텝에 걸친 픽셀의 강도를 적분 스텝들 사이에 어떻게 분배할 것인가입니다.

이 소프트웨어는 각 스텝을 구분하는 선과 픽셀의 교점을 계산하고, 각 스텝에 포함되는 픽셀 면적을 구하여 강도를 분배합니다. IP 기울기나 픽셀 모양 왜곡으로 인해 픽셀이 정확한 정사각형이 아닌 경우를 처리하기 위해, 각 픽셀 네 모서리의 좌표를 순차적으로 계산하여 그 사각형 모양을 결정합니다. 원리적으로 이는 스텝을 아무리 작게 만들더라도 픽셀 강도를 스텝들에 매끄럽게 분배할 수 있게 합니다.

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

이 알고리즘은 일반적인 각도–강도 적분(Concentric Integration)뿐만 아니라, 원주 방향 적분(Radial Integration)과 펼친 이미지 계산(Unrolled Image)에도 사용됩니다.
