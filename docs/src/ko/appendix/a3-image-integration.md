<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Appendix A3. Image integration

2D 이미지를 1D 프로파일로 변환할 때 가장 큰 문제는 **적분의 각도 스텝 크기가 픽셀 간격(픽셀 크기)보다 작을 경우, 여러 스텝에 걸쳐 있는 픽셀의 강도를 어떻게 분배할 것인가** 입니다. IPAnalyzer는 이 분배를 **면적 기반 분배법**으로 처리합니다.

---

## 면적 기반 분배법

이 소프트웨어에서는 각 스텝을 구분하는 선(동일 회절각의 경계)과 픽셀의 교점을 계산하고, 특정 스텝 안에 들어가는 각 픽셀의 **면적**을 구하여, 그 면적에 비례해 강도를 분배합니다.

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

이 방법은 다음과 같은 특징을 가집니다.

- 각 픽셀 내부에서 스텝 경계의 호는 **직선으로 근사**됩니다. 이는 계산 속도를 위한 것이며 실제로는 거의 문제가 되지 않습니다.
- [A1. Detector geometry](a1-geometry.md)의 기울기 보정 및 픽셀 모양 보정이 필요한 경우, 픽셀 모양은 엄밀하게는 정사각형이 아닙니다. 따라서 소프트웨어는 **픽셀의 네 모서리 좌표를 순차적으로 계산**하여 사각형(일반적으로 평행사변형)으로서의 면적을 구합니다.

이 방식에 의해, 원리적으로는 각도 스텝을 아무리 미세하게 하더라도 픽셀 강도가 스텝 전체에 걸쳐 매끄럽게 분배됩니다.

---

## 적용 범위

다음 세 가지 유형의 적분 모두에 동일한 면적 기반 분배 알고리즘이 사용됩니다.

| Function | 적분 방향 | 용도 |
|------|-----------|------|
| **Concentric Integration** | 회절각(동심 방향) | 일반적인 $2\theta$-강도 프로파일 작성. |
| **Radial Integration** | 원주(방위각) 방향 | 고리의 방위각 의존성(배향, 변형) 평가. |
| **Unrolled Image** | 회절각 × 방위각 | 고리를 펼친 2D 펼친 이미지 작성. |

각 기능의 조작 방법은 [3. Tools](../3-tools.md)를 참조하십시오.
