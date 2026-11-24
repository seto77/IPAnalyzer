<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). -->

# IPAnalyzer 매뉴얼

## 간단한 소개

* **IPAnalyzer** 는 이미징 플레이트 (IP) 또는 CCD/CMOS 평판 검출기로 기록한 2차원 분말 회절 이미지(Debye–Scherrer 고리)를 고정밀 1차원 2θ–강도 프로파일로 변환하는 MIT 라이선스 무료 소프트웨어입니다.
* 표준 물질의 고리로부터 측정 기하 — 카메라 길이, 파장, 검출기 기울기, 픽셀 모양 — 를 보정하며, X선·전자·중성자 선원을 지원하고, 이후의 피크 분석을 위해 [PDIndexer](https://github.com/seto77/PDIndexer) 와 연동됩니다.
* 설계와 기능은 AIST의 Hiroshi Fujihisa가 개발한 *PIP* 를 따릅니다.

## 목적별 찾기

| 목적 | 시작 지점 | 주요 다음 단계 |
|------|------------|-----------------|
| 좌표계와 기하 이해 | [개요](0-overview.md) | [속성 창](2-property-windows.md) |
| 이미지를 불러와 1D 프로파일 얻기 | [작업 절차](4-procedures.md) | [메인 창](1-main-window.md), [속성 창](2-property-windows.md) |
| 카메라 길이 / 파장 보정 | [작업 절차](4-procedures.md) | [도구](3-tools.md), [매개변수 찾기 (전수 탐색)](6-find-parameter.md) |
| 스폿 마스킹 / 다중 프레임 데이터 처리 | [도구](3-tools.md) | [작업 절차](4-procedures.md) |
| 처리 자동화 | [매크로](5-macro/index.md) | [내장 함수](5-macro/1-built-in-functions.md), [예제](5-macro/2-examples.md), [자동 절차 (Auto Procedure)](3-tools.md) |
| 문제 해결과 자주 묻는 질문 | [Q&A](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## 기능

* **폭넓은 포맷 지원** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rigaku RINT-RAPID II, SMV, MRC, NeXus (`.nxs`), Digital Micrograph 3/4, 그리고 일반 이미지 포맷. 대부분의 파일 입출력은 드래그 앤 드롭을 지원합니다.
* **이미지-프로파일 변환** : 동심(반경 평균) 적분, 방사(방위각/cake) 적분, 펼친 이미지 계산을 수행하며, 검출기 기울기와 평행사변형 픽셀 모양을 올바르게 처리하는 서브픽셀 면적 분배 알고리즘을 사용합니다.
* **기하 보정** : 파장, 카메라 길이, 픽셀 크기/왜곡, 기울기 (φ, τ) 의 기하학적(double-cassette) 정밀화와, 어려운 데이터를 위한 격자 전수 탐색을 제공합니다.
* **이미지 처리** : 자동 빔 중심 검출, 단결정 스폿 (spot) 검출 및 마스킹, 원주 방향 블러, 링 오버레이, R-AXIS 이미지 강도 보정, 그리고 기하 정보를 보존하는 IPA 저장.
* **다중 프레임 데이터** : NeXus (`.nxs`), 다중 페이지 TIFF 등 순차 데이터의 프레임을 선택·평균·합산합니다. 프레임에 에너지 정보가 있으면, 그 프레임을 선택할 때 파장이 갱신됩니다.
* **자동화** : 폴더를 감시하는 자동 절차 (Auto Procedure) 와, 배치 및 스크립트 처리를 위한 Python 문법 [매크로](5-macro/index.md).
* **PDIndexer 연동** : 클립보드를 통해 프로파일을 [PDIndexer](https://github.com/seto77/PDIndexer) 로 보내고, 그곳에서 이름이 지정된 매크로를 실행합니다.

## 시스템 요구 사항

아래 요구 사항은 이 소스 트리에서 만든 .NET 11 빌드에 적용됩니다. 공개된 릴리스에 대해서는 해당 릴리스에 명시된 런타임 요구 사항을 따르십시오.

| 항목 | 최소 | 권장 |
|------|---------|-------------|
| OS | [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) 이 설치된 Windows | Windows 11 |
| 메모리 | - | 16 GB 이상 |
| CPU | - | 8코어 이상 (이미지 강도는 배정밀도로 보관되며 처리는 멀티스레드로 수행됩니다) |

## 빠른 시작

1. [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 에서 내려받아 설치합니다.
2. 회절 이미지를 읽습니다 (파일 (File) → 이미지 읽기 (Read image), 또는 드래그 앤 드롭).
3. 속성 창에서 **파원 (Wave source)** 과 **검출기 조건 (Detector condition)** (카메라 길이, 픽셀 크기, 대략적인 중심)을 설정합니다.
4. 기하 (카메라 길이, 파장, 기울기) 를 모르는 경우, 먼저 표준 시료의 이미지로 보정하고 그 값을 적용합니다 — [작업 절차](4-procedures.md)를 참조하십시오.
5. 시료 이미지에서 중심을 찾고, 필요하면 스폿을 마스크한 뒤, **프로파일 가져오기 (Get Profile)** 를 눌러 1D 프로파일을 얻습니다.

전체 작업 흐름은 [작업 절차](4-procedures.md)를 참조하십시오.

## 이 매뉴얼의 사용법

이 GitHub Pages 매뉴얼이 현재의 정본입니다. 왼쪽 내비게이션으로 장별로 둘러보거나, 헤더의 검색으로 함수 이름이나 UI 라벨을 찾을 수 있습니다. 이전에 `IPAnalyzer/doc/` 에 포함되어 배포되던 Word/HTML/PDF 매뉴얼을 대체합니다.

## 라이선스

IPAnalyzer 는 [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) 로 배포됩니다.
