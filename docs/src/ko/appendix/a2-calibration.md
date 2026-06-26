<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Appendix A2. Parameter determination

각 픽셀의 위치는 [A1. Detector geometry](a1-geometry.md)의 기하에 의해 지배되므로, 잘못된 매개변수를 사용하면 잘못된 위치에서 강도를 읽게 됩니다. 이 페이지에서는 **표준 물질**의 회절 고리로부터 참 매개변수 — 카메라 길이, 파장, 픽셀 크기, IP 기울기 — 를 결정하는 방법을 설명합니다. 실제 조작에 대해서는 [4. Practical procedures](../4-procedures.md) 및 [6. Parameter calibration (brute force)](../6-find-parameter.md)을 참조하십시오.

---

## Standard material

보정을 위해서는 격자 상수가 알려진 표준 물질을 측정합니다. 바람직한 조건은 **높은 SN 비**를 가지며 **드문드문** 위치하고 **우선 배향이 없는** **다수의 회절 고리**입니다. 특별한 선호가 없다면, $\mathrm{CeO_2}$ 나 $\mathrm{Ag}$ 와 같은 무거운 원자를 포함하는 입방정 결정을 권장합니다. 격자 상수는 약 5자리 유효 숫자까지 알려져 있어야 합니다.

---

## Camera length — two-distance method

카메라 길이 $\mathrm{CL}$ 은 시료와 IP 상의 직접 스폿(direct spot)을 잇는 거리로 정의됩니다. 카메라 길이를 $\Delta$ 만큼 변화시키면서 두 개의 회절 패턴을 촬영하면, 동일한 고리의 반경(픽셀 단위) $r_1,\ r_2$ 의 변화로부터 $\mathrm{CL}$ 의 절대값을 결정할 수 있습니다. 거리 차이 $\Delta$ 는 Magnescale 등의 장치로 정확하게 제어할 수 있습니다.

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

닮음 삼각형 $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ 로부터,

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

이 얻어집니다. 여기서 $r_1,\ r_2$ 는 픽셀 단위 그대로 두어도 되며, 기울기 보정과 픽셀 크기 보정이 다소 부정확하더라도, 그리고 표준 물질의 격자 상수가 부정확하더라도 카메라 길이를 얻을 수 있습니다. 이렇게 카메라 길이는 다른 매개변수와의 상관이 작기 때문에, **가장 먼저 결정해야 할 매개변수**입니다.

---

## Wavelength and pixel size — two-line method

두 개의 회절선을 기록할 수 있다면, 그 피크 위치(픽셀 단위) $p_1,\ p_2$ 의 비와 d-spacing $d_1,\ d_2$ 로부터, 픽셀 크기나 카메라 길이를 모르더라도 회절각 $\theta_1,\ \theta_2$ 를 계산할 수 있습니다. d-spacing 비를 $\rho_d = d_1/d_2$, 피크 위치 비를 $\rho_p = p_1/p_2$ 라 합시다.

Bragg 법칙과 평판 검출기의 기하로부터,

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

이 성립합니다. 첫 번째 식의 비로부터 $\sin\theta_2 = \rho_d \sin\theta_1$, 두 번째 식의 비로부터 $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$ 가 됩니다. $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ 를 대입하면, 유일한 미지수가 $\sin\theta_1$ 인 식이 얻어집니다:

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

이것은 $\sin^2\theta_1$ 에 대한 3차 방정식으로 귀착됩니다. 해석적으로 풀려면 허수를 다루어야 하므로, 이 소프트웨어는 이를 **수치적으로** 풀어 값을 얻습니다. $\rho_d$ 는 d-spacing의 비이므로, 결정 대칭에 따라(예를 들어 입방정계에서) 오차 없이 결정할 수 있습니다.

회절각이 얻어지면, 앞서 설명한 two-distance method로 카메라 길이를 독립적으로 결정할 수 있으므로, 파장 $\lambda$ 와 픽셀 크기 $\mathrm{PixSize}$ 도 위의 두 식으로부터 쉽게 계산할 수 있습니다.

!!! note "When there is a tilt"
    IP가 기울어져 있으면 $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ 의 관계가 성립하지 않으므로, 그대로는 정확한 값을 얻을 수 없습니다. 이 경우 **기울기 보정과 파장 보정을 번갈아 수행**하여 해를 참값을 향해 반복적으로 수렴시킵니다.

---

## IP tilt — ellipse fitting

원뿔각이 $2\theta$ 인 고리는, 기울어지지 않은 $XY$ 평면 위에서는 반경 $R_0 = \mathrm{CL}\tan 2\theta$ 의 진원으로 관측되어야 합니다. 그러나 기울어진 IP 위에서는 고리가 **타원**이 되고, 더욱이 그 중심은 빔 중심(직접 스폿)과 일치하지 않습니다.

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

$\varphi,\ \tau$ 만큼 기울어진 IP 평면 위에서, 고리 위의 점 $(x,y)$ 는 일반적인 원뿔 곡선(타원)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

을 만족합니다. 계수 $A,B,C,D,E$ 는 $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ 의 함수로 쓸 수 있으며, 다음과 같이 기초적인 선형 대수로 다룰 수 있습니다.

- **타원의 중심** $(x_c, y_c)$ 는 기울기(gradient)가 사라지는 조건, 즉 연립 일차 방정식
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
  의 해입니다.
- **장축과 단축의 방향과 길이**는 대칭 행렬 $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$ 의 고유값 문제를 풀어 얻어집니다.

이로부터 기울기는 다음과 같이 결정됩니다.

1. **방위각 $\varphi$**: 타원 중심의 변위는 기울기가 가장 급한 방향(최대 경사 방향)을 따라 발생하며, 기울기 축은 그것에 직교합니다. 따라서 기울기 축의 방향은 $(-y_c,\ x_c)$ 로 주어지며, 이로부터 $\varphi$ 가 결정됩니다.
2. **기울기 크기 $\tau$**: $\varphi$ 방향을 따라 투영한 도형(위 그림)을 고려하면, 직접 스폿에서 타원 중심까지의 거리 $R$ 은 카메라 길이, 기울기 크기, 회절각의 함수를 만족합니다:

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    이 식을 $\tau$ 에 대해 풉니다. 여러 개의 회절 고리를 이용할 수 있을 때는, 각 고리로부터 얻어진 $\tau$ 의 **가중 평균**을 참값으로 취합니다.
