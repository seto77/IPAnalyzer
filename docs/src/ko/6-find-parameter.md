<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

전수 탐색 모드는 각 매개변수를 빠짐없이 변화시켜(격자 전수 탐색) 다음 조건을 가장 잘 만족하는 값을 찾습니다.

- 날카로운 피크(즉, 작은 FWHM), 그리고
- 작은 d-값 편차.

이 모드는 기하 최적화가 수렴하기 어려운 불완전한 고리나 잡음이 많은 데이터에 효과적입니다. 도구의 개요는 [도구](3-tools.md), 기본 흐름은 [작업 절차](4-procedures.md)를 참조하십시오.

## Steps

1. 이미지 데이터와 매개변수를 불러온 뒤 **Find Parameter (brute force)**를 클릭합니다.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. **standard material**을 선택합니다. 목록에 없으면 **Others**를 선택하여 직접 입력합니다.
3. **Get profile**로 프로파일을 표시합니다.
4. 최적화에 사용하고 싶지 않은 피크 선을 더블 클릭하여 제외합니다.
5. 옵션을 설정하고 **Optimize**를 눌러 최적화를 시작합니다.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

각 피크에 대해 피팅할 각도 범위를 지정합니다.

### Number of repetitions

최적화 사이클의 횟수를 지정합니다.

### Per-parameter options

체크된 항목에 대해 최적화가 수행됩니다. 각 매개변수는 지정된 단계(**Initial step**)로 지정된 범위(**Search range**)에 걸쳐 이동합니다.

예를 들어 카메라 길이가 100 mm에서 시작하고 Initial step이 0.05 mm, Search range가 4이면, 9 (= Search range × 2 + 1)개의 카메라 길이가 시도됩니다: 99.80, 99.85, 99.90, 99.95, 100.00, 100.05, 100.10, 100.15, 100.20 mm.

매개변수의 시도 횟수가 N1, N2, N3, …일 때, 사이클당 총 시도 횟수는 N1 × N2 × N3 × …입니다. 위 예에서 네 개의 매개변수가 Search range 4, 4, 3, 6을 가지면, 이는 (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371회의 시도가 됩니다. 다시 말해 7371개의 매개변수 집합이 시도되고, 가장 날카로운 피크와 가장 작은 d-값 편차를 갖는 조합이 선택됩니다.

!!! warning
    **Search range**를 늘리면 시도 횟수가 급격히 증가하고 각 사이클이 길어집니다. 주의하여 사용하십시오.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

보정 중에는 위와 같은 상태 화면이 표시됩니다.

- **Cycle**: 현재 사이클 번호. 한 사이클이 끝나면 그 안에서 찾은 최적의 매개변수 집합이 다음 사이클의 시작점이 됩니다. 최적 매개변수가 이전 사이클과 동일하면 다음 사이클을 위해 단계에 0.8을 곱합니다.
- **Current best values**: 그 시점의 최적 매개변수.
- **Current steps**: 그 시점의 각 매개변수 단계.
- **No1, No2, …**: 사이클 내 상위 5개 평가값. 처음에는 빠르게 떨어지다가 최적점에 가까워질수록 수렴합니다.

## Evaluation value R

평가값 R은 다음과 같이 계산됩니다.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

여기서 *H*는 배경을 뺀 피크 높이입니다.
