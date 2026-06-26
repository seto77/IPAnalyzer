<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer는 Python과 유사한 스크립트로 일련의 작업을 자동화하는 **macro** 기능을 제공합니다. 많은 파일의 일괄 1차원화, 포맷 변환, 방위각 분할 분석 등 반복 작업에 유용합니다.

## 에디터 열기

메인 창의 **Macro** 메뉴 → **Editor** 에서 매크로 에디터를 엽니다. 거기서 코드를 편집하고 실행할 수 있으며, 단계별 실행(step-by-step)도 가능합니다.

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## 언어

- `for` / `if` / `while` / `def` / `class` 등의 제어문과 산술 연산을 사용할 수 있습니다.
- `math` 모듈이 미리 임포트되어 있으므로 `import` 문 없이 `math.pi` 나 `math.sin(...)` 를 바로 사용할 수 있습니다.
- `print()` 는 사용할 수 없습니다. 값을 확인하려면 **단계 실행**(Step by step)을 사용하여 디버그 패널에서 변수의 변화를 관찰하세요.
- 각 IPAnalyzer 작업은 `IPA` 루트 객체 아래의 네임스페이스에서 호출됩니다(예: `IPA.File`).

## IPA 네임스페이스

| Namespace | 역할 |
|------|------|
| `IPA.File` | 이미지, 매개변수, 마스크 파일의 읽기/쓰기 및 파일 선택 대화상자 |
| `IPA.Wave` | 입사 선원과 파장 설정 |
| `IPA.Detector` | 검출기 기하 설정: 중심, 카메라 길이, 픽셀 크기, 기울기 |
| `IPA.Image` | 표시 배율, 명암, 표시 영역 제어 |
| `IPA.Mask` | 스폿 및 영역 마스킹 |
| `IPA.Profile` | 1차원화(Get Profile) 실행 및 저장/전송 설정 |
| `IPA.IntegralProperty` | 동심/반경 적분의 범위, 스텝, 단위 설정 |
| `IPA.Sequential` | 다중 프레임 이미지의 프레임 선택 / 평균 / 대상 지정 |
| `IPA.PDI` | PDIndexer의 매크로 호출(클립보드 연동) |

멤버 목록은 [내장 함수](1-built-in-functions.md)를, 구체적인 스크립트는 [예제](2-examples.md)를 참조하세요.

!!! tip "에디터 내 도움말이 가장 권위 있는 참조입니다"
    각 함수/속성의 설명은 매크로 에디터의 도움말에 표시되며, 이것이 최신이자 버전을 추적하는 신뢰할 수 있는 정보원입니다. 이 페이지와 에디터 내 도움말이 다를 경우, 후자를 신뢰하세요.

## 샘플 매크로

에디터의 저장된 매크로 목록이 비어 있을 때는 샘플 매크로(기본 루프, 수학 함수, 기하 설정, 일괄 처리, 방위각 분할, 마스킹, PDIndexer로 전송 등)가 자동으로 삽입됩니다. 이를 변형하여 시작하기 좋은 출발점이 됩니다.

## Auto Procedure와 함께 사용하기

작성한 매크로는 이름을 붙여 저장할 수 있으며, [Auto Procedure](../3-tools.md)의 "로드 후 실행" 목록에서도 호출할 수 있습니다. 이를 통해 실험 중에 도착하는 각 이미지에 매크로가 자동으로 적용됩니다.
