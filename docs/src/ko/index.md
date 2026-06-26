<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# IPAnalyzer 매뉴얼

## 간단한 소개

* **IPAnalyzer** 는 이미징 플레이트 (IP) 또는 CCD/CMOS 평판 검출기로 기록한 2차원 분말 회절 이미지(Debye–Scherrer 고리)를 고정밀 1차원 2θ–강도 프로파일로 변환하는 MIT 라이선스 무료 소프트웨어입니다.
* 표준 물질의 고리로부터 측정 기하 — 카메라 길이, 파장, 검출기 기울기, 픽셀 모양 — 를 보정하며, X선·전자·중성자 선원을 지원하고, 이후의 피크 분석을 위해 [PDIndexer](https://github.com/seto77/PDIndexer) 와 연동됩니다.
* 그 설계와 기능은 AIST의 Hiroshi Fujihisa가 개발한 *PIP* 를 따릅니다.

## 목적별 찾기

| 목적 | 시작 지점 | 주요 다음 단계 |
|------|------------|-----------------|
| 좌표계와 기하 이해 | [개요](0-overview.md) | [속성 창](2-property-windows.md) |
| 이미지를 불러와 1D 프로파일 얻기 | [작업 절차](4-procedures.md) | [메인 창](1-main-window.md), [속성 창](2-property-windows.md) |
| 카메라 길이 / 파장 보정 | [작업 절차](4-procedures.md) | [도구](3-tools.md), [매개변수 찾기 (전수 탐색)](6-find-parameter.md) |
| 스폿 마스킹 / 다중 프레임 데이터 처리 | [도구](3-tools.md) | [작업 절차](4-procedures.md) |
| 처리 자동화 | [매크로](5-macro/index.md) | [내장 함수](5-macro/1-built-in-functions.md), [예제](5-macro/2-examples.md), [Auto Procedure](3-tools.md) |

## 기능

* **폭넓은 포맷 지원** : Fuji BAS2000/2500/FDL, Rigaku R-AXIS IV/V, ITEX, Bruker CCD, Rayonix, MAR research, Perkin Elmer, ADSC, RadIcon, Rad-Xcam, HDF5/NeXus, Digital Micrograph 3/4, 그리고 일반 이미지 포맷. 대부분의 파일 입출력은 드래그 앤 드롭을 지원합니다.
* **이미지-프로파일 변환** : 동심(반경 평균), 반경(방위각/cake), 펼친 이미지 계산을 수행하며, 검출기 기울기와 평행사변형 픽셀 모양을 올바르게 처리하는 서브픽셀 면적 분포 알고리즘을 사용합니다.
* **기하 보정** : 파장, 카메라 길이, 픽셀 크기/왜곡, 기울기 (φ, τ) 의 기하학적(double-cassette) 정밀화와, 어려운 데이터를 위한 격자 전수 탐색을 제공합니다.
* **이미지 처리** : 자동 빔 중심 검출, 단결정 스폿 (spot) 검출 및 마스킹, 원주 방향 블러, 링 오버레이, 강도 테이블 검출기 보정, 그리고 기하를 보존하는 IPA 저장.
* **다중 프레임 데이터** : HDF5/NeXus 및 기타 순차 데이터의 프레임을 선택·평균·합산하며, 내장된 에너지로부터 프레임별 파장을 얻습니다.
* **자동화** : 폴더 감시 Auto Procedure 와 배치 및 스크립트 처리를 위한 Python 문법 [매크로](5-macro/index.md).
* **PDIndexer 연동** : 클립보드를 통해 프로파일을 [PDIndexer](https://github.com/seto77/PDIndexer) 로 보내고 거기에서 명명된 매크로를 실행합니다.
* **라이트 / 다크 테마** : 인터페이스는 선택 가능한 라이트 또는 다크 색상 모드를 따릅니다.

## 시스템 요구 사항

| 항목 | 최소 | 권장 |
|------|---------|-------------|
| OS | [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) 이 설치된 Windows | Windows 11 |
| 메모리 | - | 16 GB 이상 |
| CPU | - | 8코어 이상 (이미지 강도는 배정밀도로 보관되며 처리는 멀티스레드로 수행됩니다) |

## 빠른 시작

1. [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 에서 다운로드하여 설치합니다.
2. 회절 이미지를 읽습니다 (File → Read image, 또는 드래그 앤 드롭).
3. 속성 창에서 **Wave source** 와 **Detector condition** (카메라 길이, 픽셀 크기, 대략적인 중심) 을 설정합니다.
4. 중심을 찾고, 필요하면 스폿을 마스킹한 뒤 **Get Profile** 을 눌러 1D 프로파일을 얻습니다.
5. 기하를 모르는 경우 표준 물질로부터 보정합니다 — [작업 절차](4-procedures.md) 를 참조하세요.

전체 워크플로는 [작업 절차](4-procedures.md) 를 참조하세요.

## 이 매뉴얼 사용법

이 GitHub Pages 매뉴얼이 현재의 기준 문서입니다. 왼쪽 내비게이션으로 장별로 탐색하거나, 헤더의 검색을 사용해 함수 이름이나 UI 라벨을 찾으세요. 이는 `IPAnalyzer/doc/` 에 배포되던 기존 Word/HTML/PDF 매뉴얼을 대체합니다.

## 라이선스

IPAnalyzer 는 [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) 하에 배포됩니다.
