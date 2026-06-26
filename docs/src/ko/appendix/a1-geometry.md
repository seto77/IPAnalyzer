<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Appendix A1. Detector geometry and coordinate transforms

이 페이지는 평판 검출기(IP, CCD/CMOS) 위의 픽셀 위치를 회절각으로 변환하기 위해 IPAnalyzer가 사용하는 **좌표계, IP 기울기 보정, 픽셀 모양 보정**을 수식과 함께 정의합니다. 좌표계의 개요는 [appendix top page](index.md) 및 [0. Overview](../0-overview.md)도 참조하십시오.

---

## Coordinate system and parameters

IPAnalyzer는 내부적으로 일관되게 **오른손** 좌표계를 사용합니다.

- X선 또는 전자 빔이 IP와 교차하는 지점(**direct spot**)을 원점 $(0,0,0)$ 으로 잡고, $Z$ 축을 빔 진행 방향에 일치시킵니다.
- 시료를 무한히 작은 것으로 간주하고, 시료와 원점 사이의 거리를 **camera length** $\mathrm{CL}$ 로 정의합니다. 따라서 시료 위치는 $(0,\ 0,\ -\mathrm{CL})$ 입니다.
- $X$ 축은 IP가 기울어지지 않았을 때 판독 레이저의 스캔 방향(이미지의 오른쪽 방향)에 일치시킵니다. 따라서 $Y$ 축은 화면에서 아래쪽을 가리킵니다.
- 원뿔각 $2\theta$ 의 회절 고리는 기울어지지 않은 $XY$ 평면 위에서 반지름 $\mathrm{CL}\tan 2\theta$ 의 완전한 원으로 관측됩니다.

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

3D 물체의 자유로운 회전은 본질적으로 세 개의 축을 필요로 하지만, Debye 고리 분포는 $Z$ 축에 관한 회전에 대해 불변이므로 $X$ 축은 임의로 선택할 수 있습니다. 이로써 자유도가 하나 제거되어, IP 기울기는 **두 개의 변수** $\varphi,\ \tau$ 로 표현할 수 있습니다.

!!! note "Correspondence with (WIN)PIP"
    레거시 소프트웨어 PIP는 기울기를 다른 한 쌍의 각도 $(\beta,\ \Phi)$ 로 표현합니다. $(\beta,\ \Phi)$ 에서 IPAnalyzer의 $(\varphi,\ \tau)$ 로의 변환은 $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$ 입니다. 자세한 내용은 [0. Overview](../0-overview.md) 의 "Relationship with (WIN)PIP" 를 참조하십시오.

---

## IP tilt correction

광축($Z$ 축)에 대한 IP의 기울기는, 원점을 지나면서 $XY$ 평면 안에 놓인 직선을 축으로 하는 회전으로 표현됩니다. 이 회전은 회전 행렬 $R = R_2\,R_1\,R_2^{-1}$ 로 쓸 수 있으며, 이는 $Z$ 축에 관해 $\varphi$ 만큼 회전된($R_2$) 축을 따라 $\tau$ 만큼 회전시키는($R_1$) 연산입니다.

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

이것은 $XY$ 평면에서 $X$ 축과 각도 $\varphi$ 를 이루는 단위 벡터 $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ 에 관해 각도 $\tau$ 만큼 회전하는 것과 동등하며, 전개하면 다음을 얻습니다.

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Forward transform (untilted plane → tilted IP)

기울어지지 않은 $XY$ 평면 위의 점 $P_1 = (X,\ Y,\ 0)$ 은 기울어진 IP 위의 $P_2 = R\,P_1$ 로 변환됩니다.

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projection (tilted IP → untilted plane)

실제로 필요한 것은 그 역방향, 즉 "기울어진 IP 위에서 관측된 픽셀"이 기울기가 없었다면 차지했을 $XY$ 평면 좌표입니다. 이것은 기울어진 IP 위의 한 점과 시료 $(0,0,-\mathrm{CL})$ 를 잇는 직선이 $XY$ 평면과 교차하는 점 $P_3$ 를 구하는 **central (perspective) projection** 으로 주어집니다. 이는 시료를 투영 중심으로 하는 사영 변환이므로,

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

가 됩니다. 기울기 보정 전체가 선형(동차 좌표에서 사영) 변환이므로, 각 픽셀의 위치를 컴퓨터에서 빠르게 계산할 수 있습니다.

---

## Pixel-shape correction

IP의 픽셀 모양은, $X$ 축을 따라 길이 $\mathrm{PixSizeX}$, $Y$ 축을 따라 길이 $\mathrm{PixSizeY}$, 그리고 직각으로부터의 편차(왜곡각) $\xi$ 를 갖는 **평행사변형**으로 다룹니다. $\xi$ 가 0이 아니라는 것은 판독 레이저 스캔의 시작 위치에 오프셋이 있음을 의미하며, 이 소프트웨어는 이 오프셋이 $Y$ 축을 따라 일정하다고 가정합니다.

중심 픽셀로부터 세어 $X$ 방향으로 $\mathrm{PixNumX}$, $Y$ 방향으로 $\mathrm{PixNumY}$ 만큼 떨어진 픽셀의 실제 좌표 $P$ 는 다음으로 주어집니다.

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

이 픽셀 모양 보정을 위에서 설명한 기울기 보정과 결합함으로써, 기울어진 IP 위의 임의의 픽셀을 기울어지지 않은 $XY$ 평면 위의 올바른 위치로 변환할 수 있습니다. 이 변환은 다음 장의 매개변수 결정과 [A3. Image integration](a3-image-integration.md) 의 기초가 됩니다.
