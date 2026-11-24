<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# 부록 A2. 매개변수 결정

각 픽셀의 위치는 [A1. 검출기 기하](a1-geometry.md)의 기하로 결정되므로, 잘못된 매개변수를 사용하면 엉뚱한 위치의 강도를 읽게 됩니다. 이 페이지에서는 **표준 물질**의 회절 고리로부터 참된 매개변수 — 카메라 길이, 파장, 픽셀 크기, IP 기울기 — 를 결정하는 방법을 설명합니다. 실제 조작은 [4. 작업 절차](../4-procedures.md)와 [6. 매개변수 찾기 (전수 탐색)](../6-find-parameter.md)를 참조하십시오.

---

## 표준 물질

보정에는 격자 상수를 알고 있는 표준 물질을 측정합니다. 바람직한 조건은 **회절 고리가 많고**, **SN 비가 높으며**, 고리가 **드문드문** 떨어져 있고, **우선 배향이 없는** 것입니다. 특별한 선호가 없다면 $\mathrm{CeO_2}$ 나 $\mathrm{Ag}$ 처럼 무거운 원자를 포함하는 입방정을 권장합니다. 격자 상수는 유효숫자 5자리 정도까지 알고 있어야 합니다.

---

## 카메라 길이 — 두 거리법

카메라 길이 $\mathrm{CL}$ 은 시료와 IP 위의 다이렉트 스폿을 잇는 거리로 정의됩니다. 카메라 길이를 $\Delta$ 만큼 바꾸어 두 장의 회절 패턴을 찍으면, 같은 고리의 반지름 $r_1,\ r_2$ 의 변화로부터 $\mathrm{CL}$ 의 절댓값을 결정할 수 있습니다. 거리 차 $\Delta$ 는 Magnescale 같은 장치로 정확하게 제어할 수 있습니다.

![카메라 길이의 두 거리법 결정. 같은 고리를 시료로부터의 거리가 CL 과 CL+Δ 인 두 위치에서 기록하고, 반지름 r₁, r₂ 로부터 CL 을 구합니다.](../../assets/references/calibration-camera-length.svg){width=440px}

닮은 삼각형 $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$ ($r_i$ 는 $\mathrm{CL}$ 과 같은 길이 단위) 로부터

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

를 얻습니다. 여기서 $r_1,\ r_2$ 는 픽셀 단위 그대로여도 되며, 기울기 보정과 픽셀 크기 보정이 다소 부정확하더라도, 또 표준 물질의 격자 상수가 부정확하더라도 카메라 길이를 구할 수 있습니다. 이처럼 카메라 길이는 다른 매개변수와의 상관이 작으므로, **가장 먼저 결정해야 할 매개변수**입니다.

---

## 파장과 픽셀 크기 — 두 회절선법

회절선 두 개를 기록할 수 있으면, 픽셀 크기나 카메라 길이를 몰라도 피크 위치 (픽셀 단위) $p_1,\ p_2$ 의 비와 d-간격 $d_1,\ d_2$ 로부터 Bragg 각 $\theta_1,\ \theta_2$ 를 계산할 수 있습니다. d-간격의 비를 $\rho_d = d_1/d_2$, 피크 위치의 비를 $\rho_p = p_1/p_2$ 라 합니다.

Bragg 법칙과 평판 검출기의 기하로부터

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

가 성립합니다. 첫 번째 식의 비로부터 $\sin\theta_2 = \rho_d \sin\theta_1$, 두 번째 식의 비로부터 $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$ 를 얻습니다. $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$ 를 대입하면, 미지수가 $\sin\theta_1$ 뿐인 방정식이 됩니다.

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

이는 $\sin^2\theta_1$ 에 대한 3차 방정식으로 귀결됩니다. 해석적으로 풀려면 허수를 다뤄야 하므로, 이 소프트웨어는 이를 **수치적으로** 풀어 값을 구합니다. $\rho_d$ 는 d-간격의 비이므로, 결정의 대칭에 따라서는 (예를 들어 입방정계에서는) 오차 없이 결정할 수 있습니다.

회절각을 얻으면 앞에서 설명한 두 거리법으로 카메라 길이를 독립적으로 결정할 수 있으므로, 위의 두 식으로부터 파장 $\lambda$ 와 픽셀 크기 $\mathrm{PixSize}$ 도 쉽게 계산할 수 있습니다.

!!! note "기울기가 있는 경우"
    IP 가 기울어져 있으면 $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ 관계가 성립하지 않으므로, 그대로는 정확한 값을 얻을 수 없습니다. 이 경우에는 **기울기 보정과 파장 보정을 번갈아 수행**하여 해를 참값으로 반복 수렴시킵니다.

---

## IP 기울기 — 타원 피팅

원뿔각 $2\theta$ 의 고리는 기울어지지 않은 $XY$ 평면 위에서 반지름 $R_0 = \mathrm{CL}\tan 2\theta$ 의 진원으로 관측되어야 합니다. 그러나 기울어진 IP 위에서는 고리가 **타원**이 되며, 게다가 그 중심이 빔 중심 (다이렉트 스폿) 과 일치하지 않습니다.

![기울어진 IP 위에서는 회절 고리가 타원이 되고, 그 중심이 다이렉트 스폿에서 어긋납니다 (φ 방향에서 본 투영).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

$\varphi,\ \tau$ 만큼 기울어진 IP 평면 위에서, 고리 위의 점 $(x,y)$ 는 일반적인 이차 곡선 (타원)

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

을 만족합니다. 계수 $A,B,C,D,E$ 는 $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ 의 함수로 쓸 수 있으며, 다음과 같이 초등적인 선형대수로 다룰 수 있습니다.

- **타원의 중심** $(x_c, y_c)$ 는 기울기 (gradient) 가 0이 되는 조건, 즉 연립 일차 방정식
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
  의 해입니다.
- **장축과 단축의 방향과 길이**는 대칭 행렬 $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$ 의 고윳값 문제를 풀어 얻습니다.

이로부터 기울기를 다음과 같이 결정합니다.

1. **방위각 $\varphi$**: 타원 중심의 변위는 가장 가파르게 기울어진 방향 (최대 경사 방향) 을 따라 일어나며, 기울기 축은 그 방향과 직교합니다. 따라서 기울기 축의 방향은 $(-y_c,\ x_c)$ 로 주어지고, 이로부터 $\varphi$ 가 결정됩니다.
2. **기울기 크기 $\tau$**: $\varphi$ 방향을 따라 투영한 그림 (위 그림) 을 생각하면, 다이렉트 스폿에서 타원 중심까지의 거리 $R$ 은 카메라 길이, 기울기 크기, 회절각의 함수로 다음을 만족합니다.

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    이 식을 $\tau$ 에 대해 풉니다. 회절 고리가 여러 개 있을 때는 각 고리에서 얻은 $\tau$ 의 **가중 평균**을 참값으로 합니다.
