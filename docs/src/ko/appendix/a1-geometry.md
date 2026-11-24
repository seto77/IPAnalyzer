<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# 부록 A1. 검출기 기하와 좌표 변환

이 페이지는 평판 검출기 (IP, CCD/CMOS) 위의 픽셀 위치를 회절각으로 대응시키기 위해 IPAnalyzer 가 사용하는 **좌표계, IP 기울기 보정, 픽셀 모양 보정**을 수식으로 정의합니다. 좌표계의 개요는 [부록 첫 페이지](index.md)와 [0. 개요](../0-overview.md)도 참조하십시오.

---

## 좌표계와 매개변수

IPAnalyzer 는 내부적으로 일관되게 **오른손** 좌표계를 사용합니다.

- X선 또는 전자 빔이 IP 와 교차하는 점 (**다이렉트 스폿**) 을 원점 $(0,0,0)$ 으로 잡고, $Z$ 축을 빔의 진행 방향에 맞춥니다.
- 시료를 무한히 작다고 보고, 시료와 원점 사이의 거리를 **카메라 길이** $\mathrm{CL}$ 로 정의합니다. 따라서 시료 위치는 $(0,\ 0,\ -\mathrm{CL})$ 입니다.
- $X$ 축은 IP 가 기울어지지 않았을 때의 판독 레이저 스캔 방향 (이미지의 오른쪽 방향) 에 맞춥니다. 따라서 $Y$ 축은 화면에서 아래쪽을 향합니다.
- 원뿔각 $2\theta$ 의 회절 고리는 기울어지지 않은 $XY$ 평면 위에서 반지름 $\mathrm{CL}\tan 2\theta$ 의 완전한 원으로 관측됩니다.

![좌표계의 정의](../../assets/references/geometry-coordinate-system.png){width=520px}

3차원 물체의 자유로운 회전에는 본래 세 개의 축이 필요하지만, Debye 고리의 분포는 $Z$ 축에 대한 회전에 대해 불변이므로 $X$ 축을 임의로 고를 수 있습니다. 이로써 자유도가 하나 줄어, IP 기울기는 **두 변수** $\varphi,\ \tau$ 로 표현할 수 있습니다.

!!! note "(WIN)PIP 와의 대응"
    이전 소프트웨어 PIP 는 다른 한 쌍의 각도 $(\beta,\ \Phi)$ 로 기울기를 표현합니다. $(\beta,\ \Phi)$ 에서 IPAnalyzer 의 $(\varphi,\ \tau)$ 로의 변환은 $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$ 입니다. 자세한 내용은 [0. 개요](../0-overview.md)의 "(WIN)PIP와의 관계" 를 참조하십시오.

---

## IP 기울기 보정

광축 ($Z$ 축) 에 대한 IP 의 기울기는 원점을 지나며 $XY$ 평면 안에 놓인 직선을 축으로 하는 회전으로 나타냅니다. 이 회전은 회전 행렬 $R = R_2\,R_1\,R_2^{-1}$ 로 쓸 수 있으며, $Z$ 축을 중심으로 $\varphi$ 만큼 회전한 ($R_2$) 축을 따라 $\tau$ 만큼 회전하는 ($R_1$) 연산입니다.

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

이것은 $XY$ 평면에서 $X$ 축과 각도 $\varphi$ 를 이루는 단위 벡터 $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ 를 축으로 각도 $\tau$ 만큼 회전하는 것과 같으며, 전개하면 다음과 같습니다.

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### 순변환 (기울어지지 않은 평면 → 기울어진 IP)

기울어지지 않은 $XY$ 평면 위의 점 $P_1 = (X,\ Y,\ 0)$ 은 기울어진 IP 위의 $P_2 = R\,P_1$ 로 옮겨집니다.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### 투영 (기울어진 IP → 기울어지지 않은 평면)

실제로 필요한 것은 반대 방향, 즉 "기울어진 IP 위에서 관측된 픽셀" 이 기울기가 없었다면 차지했을 $XY$ 평면상의 좌표입니다. 이는 기울어진 IP 위의 점과 시료 $(0,0,-\mathrm{CL})$ 를 잇는 직선이 $XY$ 평면과 만나는 점 $P_3$ 을 구하는 **중심 (원근) 투영**으로 주어집니다. 시료를 투영 중심으로 하는 사영 변환이므로,

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

가 됩니다. 중심 투영을 포함한 기울기 보정은 동차 좌표에서 행렬로 쓸 수 있는 사영 변환이므로, 컴퓨터에서 각 픽셀의 위치를 빠르게 계산할 수 있습니다.

---

## 픽셀 모양 보정

IP 의 픽셀 모양은 $X$ 축 방향 길이 $\mathrm{PixSizeX}$, $Y$ 축 방향 길이 $\mathrm{PixSizeY}$, 직각으로부터의 어긋남 (비틀림 각) $\xi$ 를 갖는 **평행사변형**으로 취급합니다. $\xi$ 가 0이 아니라는 것은 판독 레이저 스캔의 시작 위치에 어긋남이 있다는 뜻이며, 이 소프트웨어는 이 어긋남이 $Y$ 축을 따라 일정하다고 가정합니다.

중심 픽셀로부터 세어 $X$ 방향으로 $\mathrm{PixNumX}$, $Y$ 방향으로 $\mathrm{PixNumY}$ 만큼 떨어진 픽셀의 실제 좌표 $P$ 는 다음과 같이 주어집니다.

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

이 픽셀 모양 보정과 앞에서 설명한 기울기 보정을 조합하면, 기울어진 IP 위의 임의의 픽셀을 기울어지지 않은 $XY$ 평면 위의 올바른 위치로 대응시킬 수 있습니다. 이 대응이 다음 장의 매개변수 결정과 [A3. 이미지 적분](a3-image-integration.md)의 기초가 됩니다.
