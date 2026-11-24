<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). -->

# 개요

IPAnalyzer 는 이미징 플레이트 (IP) 또는 CCD/CMOS 검출기로 기록한 Debye–Scherrer 고리를 고정밀·고속으로 1차원 회절 프로파일로 변환합니다. 설계와 기능은 산업기술종합연구소 (AIST) 의 Hiroshi Fujihisa가 개발한 PIP 를 본떠 만들어졌습니다.

주요 기능:

- 다양한 이미지 포맷 지원 (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, Digital Micrograph 3/4, NeXus (`.nxs`), 그리고 일반 이미지 포맷)
- X선, 전자, 중성자 선원
- PDIndexer 와의 연동
- 측정 매개변수의 반자동 해석

## 시스템 요구 사항 및 설치

### 요구 사항

아래 요구 사항은 이 소스 트리에서 만든 .NET 11 빌드에 적용됩니다. 공개된 릴리스에 대해서는 해당 릴리스에 명시된 런타임 요구 사항을 따르십시오.

- OS: Windows (Windows 11 권장)
- 필요한 런타임: .NET Desktop Runtime 11.0
- 권장 메모리: 16 GB 이상
- 권장 CPU: 8코어 이상

내부적으로 멀티스레드 계산을 많이 사용하므로, 코어 수가 많은 CPU일수록 쾌적하게 동작합니다. 이미지 강도는 내부에서 배정밀도 부동소수점 값으로 보관됩니다.

이 소프트웨어는 MIT License 로 배포됩니다.

### 설치

1. GitHub 의 [릴리스 페이지](https://github.com/seto77/IPAnalyzer/releases/latest)에서 사용하는 PC에 맞는 파일을 내려받습니다.
    - `IPAnalyzer-setup.msi`: 일반 (x64) Windows PC용 설치 프로그램 (권장). `IPAnalyzerSetup.msi` 는 내용이 같으며, 이전 버전에서의 자동 업데이트를 위해 이 이름이 유지되고 있습니다.
    - `IPAnalyzer-setup_arm64.msi`: Windows on Arm 용 설치 프로그램.
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`: 포터블 버전 (설치 불필요, .NET 런타임 포함). 관리자 권한이 없는 PC용입니다.
2. 설치 프로그램을 사용할 경우, 미리 [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) 을 설치한 다음 내려받은 `.msi` 를 실행합니다.
3. 포터블 버전은 ZIP 을 사용자가 쓸 수 있는 폴더에 압축 해제한 뒤 `IPAnalyzer.exe` 를 실행합니다 (ZIP 뷰어 안에서 바로 실행하지 마십시오).

## 축 방향, IP 기울기, 픽셀 모양

IPAnalyzer 는 오른손 좌표계를 사용하며, 원점과 축 방향은 다음과 같이 정의됩니다.

- X선 또는 전자 빔이 IP 와 교차하는 점 (다이렉트 스폿) 을 원점 (0, 0, 0) 으로 정의하고, Z 축은 빔 방향과 일치시킵니다.
- 시료 크기를 무한히 작다고 보고, 시료 위치와 원점 사이의 거리를 카메라 길이 (Camera Length, CL) 로 정의합니다. 따라서 시료는 \((0,\ 0,\ -\mathrm{CL})\) 에 위치합니다.
- X 축은 IP 가 기울어지지 않았을 때의 IP 판독 레이저 스캔 방향에 맞춥니다. 따라서 Y 축은 화면에서 아래쪽을 향합니다.
- IP 기울기는 원점을 지나며 XY 평면 안에 놓인 직선을 축으로 하는 회전으로 나타냅니다. 즉, X 축과 \( \varphi \) 의 각을 이루는 직선을 축으로 \( \tau \) 만큼 회전하는 것입니다.
- 픽셀 모양은 PixSizeX, PixSizeY, \( \xi \) 로 기술되는 평행사변형으로 취급합니다. \( \xi \) 가 0이 아니라는 것은 IP 판독 레이저 스캔의 시작 위치에 어긋남이 있다는 뜻입니다. 이 소프트웨어는 이 어긋남이 Y 축을 따라 일정하다고 가정합니다.

카메라 길이, \( \varphi \), \( \tau \), 픽셀 크기, \( \xi \) 는 속성 창의 **검출기 조건 (Detector condition)** 탭에서 설정합니다 ([2. 속성 창](2-property-windows.md) 참조).

### (WIN)PIP와의 관계

IPAnalyzer 에서는 X 축 (IP 이미지의 오른쪽 방향) 을 시계 방향으로 \( \varphi \) 만큼 회전시키고, 그렇게 얻은 축을 중심으로 \( \tau \) 만큼 회전시킵니다. PIP 에서는 Y 축 (IP 이미지의 아래쪽 방향) 을 반시계 방향으로 \( \beta \) 만큼 회전시키고, 그렇게 얻은 축을 중심으로 \( \Phi \) 만큼 회전시킵니다. 따라서 PIP 의 \((\beta,\ \Phi)\) 를 IPAnalyzer 의 \((\varphi,\ \tau)\) 로 변환하려면 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\) 를 사용합니다.

## 픽셀 강도 적분 방법

1차원화의 핵심 문제는, 여러 스텝에 걸쳐 있는 픽셀의 강도를 적분 스텝들 사이에 어떻게 분배하느냐입니다. 이는 한 픽셀이 차지하는 산란각 범위가 2θ 스텝 하나보다 넓을 때마다 일어나며, 스텝이 세밀할수록 더 자주 일어납니다.

이 소프트웨어는 각 스텝을 구분하는 경계선과 픽셀의 교점을 계산하고, 각 스텝 안에 포함되는 픽셀 면적을 구하여 강도를 분배합니다. IP 기울기나 픽셀 모양의 왜곡 때문에 픽셀이 정확한 정사각형이 아닌 경우에도 대응하기 위해, 각 픽셀의 네 꼭짓점 좌표를 차례로 계산하여 그 사각형 모양을 결정합니다. 원리적으로 이 방법을 쓰면 스텝을 아무리 작게 해도 픽셀 강도가 스텝들에 매끄럽게 분배됩니다.

이 알고리즘은 일반적인 각도–강도 적분 (동심 적분 (Concentric Integration)) 뿐만 아니라, 원주 방향 적분 (방사 적분 (Radial Integration)) 과 펼친 이미지 계산 (Unrolled Image) 에도 사용됩니다.
