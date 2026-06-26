<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Appendix A1. Detector geometry and coordinate transforms

本页用公式定义 IPAnalyzer 将平板探测器（IP、CCD/CMOS）上的像素位置映射为衍射角时所使用的**坐标系、IP 倾斜校正与像素形状校正**。关于坐标系的概览，另请参阅[附录首页](index.md)与 [0. Overview](../0-overview.md)。

---

## Coordinate system and parameters

IPAnalyzer 在内部始终使用**右手**坐标系。

- 将 X 射线或电子束与 IP 相交的点（**direct spot**）取为原点 $(0,0,0)$，并令 $Z$ 轴与束流传播方向一致。
- 将样品视为无限小，样品与原点之间的距离定义为**相机长度** $\mathrm{CL}$。因此样品位置为 $(0,\ 0,\ -\mathrm{CL})$。
- 当 IP 未倾斜时，$X$ 轴与读出激光的扫描方向（图像的向右方向）一致。因此 $Y$ 轴在屏幕上指向下方。
- 锥角为 $2\theta$ 的衍射环，在未倾斜的 $XY$ 平面上，观察为半径 $\mathrm{CL}\tan 2\theta$ 的正圆。

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

三维物体的自由旋转本质上需要三个轴，但由于 Debye 环的分布在绕 $Z$ 轴旋转下保持不变，$X$ 轴可以任意选取。这消除了一个自由度，因此 IP 倾斜可以用**两个变量** $\varphi,\ \tau$ 来表示。

!!! note "Correspondence with (WIN)PIP"
    旧版软件 PIP 用另一对角度 $(\beta,\ \Phi)$ 来表示倾斜。从 $(\beta,\ \Phi)$ 到 IPAnalyzer 的 $(\varphi,\ \tau)$ 的转换为 $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$。详情请参阅 [0. Overview](../0-overview.md) 中的 "Relationship with (WIN)PIP"。

---

## IP tilt correction

IP 相对于光轴（$Z$ 轴）的倾斜，由一个旋转表示，其旋转轴是一条经过原点且位于 $XY$ 平面内的直线。该旋转可写成旋转矩阵 $R = R_2\,R_1\,R_2^{-1}$，即沿着一个已绕 $Z$ 轴旋转了 $\varphi$（$R_2$）的轴旋转 $\tau$（$R_1$）的操作。

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

这等价于绕在 $XY$ 平面内与 $X$ 轴成 $\varphi$ 角的单位向量 $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ 旋转角度 $\tau$，展开后得到

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### Forward transform (untilted plane → tilted IP)

未倾斜 $XY$ 平面上的点 $P_1 = (X,\ Y,\ 0)$ 映射到倾斜 IP 上的 $P_2 = R\,P_1$。

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### Projection (tilted IP → untilted plane)

实际需要的是反方向，即"在倾斜 IP 上观察到的像素"在没有倾斜时所应占据的 $XY$ 平面坐标。这由**中心（透视）投影**给出，它求出连接倾斜 IP 上的某点与样品 $(0,0,-\mathrm{CL})$ 的直线与 $XY$ 平面的交点 $P_3$。由于这是以样品为投影中心的射影变换，

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

即为所求结果。由于整个倾斜校正是一个线性（在齐次坐标下为射影）变换，每个像素的位置都可以在计算机上快速计算。

---

## Pixel-shape correction

IP 的像素形状被视为一个**平行四边形**，沿 $X$ 轴长度为 $\mathrm{PixSizeX}$，沿 $Y$ 轴长度为 $\mathrm{PixSizeY}$，并带有偏离直角的偏差（畸变角）$\xi$。$\xi$ 非零意味着读出激光扫描的起始位置存在偏移，本软件假定该偏移沿 $Y$ 轴为恒定值。

从中心像素起算、在 $X$ 方向上相距 $\mathrm{PixNumX}$、在 $Y$ 方向上相距 $\mathrm{PixNumY}$ 的像素，其实际坐标 $P$ 由下式给出

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

将这一像素形状校正与上述倾斜校正相结合，倾斜 IP 上的任何像素都可以映射到未倾斜 $XY$ 平面上的正确位置。此映射是下一章参数确定以及 [A3. Image integration](a3-image-integration.md) 的基础。
