<!-- 261124Cl: Retranslated from en/appendix/a1-geometry.md (UI labels follow the localized GUI). -->

# 附录 A1. 探测器几何与坐标变换

本页用公式定义 IPAnalyzer 将平板探测器（IP、CCD/CMOS）上的像素位置映射为衍射角时所用的 **坐标系、IP 倾斜校正和像素形状校正**。坐标系的概要也请参见[附录首页](index.md)和 [0. 概述](../0-overview.md)。

---

## 坐标系与参数

IPAnalyzer 内部始终使用 **右手** 坐标系。

- X 射线或电子束与 IP 相交的点（**直射斑点**）取为原点 $(0,0,0)$，$Z$ 轴与束流传播方向一致。
- 将样品视为无限小，样品与原点之间的距离定义为 **相机长度** $\mathrm{CL}$。因此样品位置为 $(0,\ 0,\ -\mathrm{CL})$。
- $X$ 轴与 IP 未倾斜时读取激光的扫描方向（图像的向右方向）一致。因此 $Y$ 轴在屏幕上指向下方。
- 锥角为 $2\theta$ 的衍射环在未倾斜的 $XY$ 平面上被观测为半径为 $\mathrm{CL}\tan 2\theta$ 的正圆。

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

三维物体的自由旋转本来需要三个轴，但由于 Debye 环的分布在绕 $Z$ 轴旋转时不变，$X$ 轴可以任意选取。这样就去掉了一个自由度，因此 IP 倾斜可以用 **两个变量** $\varphi,\ \tau$ 表示。

!!! note "与 (WIN)PIP 的对应关系"
    旧软件 PIP 用另一对角度 $(\beta,\ \Phi)$ 表示倾斜。从 $(\beta,\ \Phi)$ 到 IPAnalyzer 的 $(\varphi,\ \tau)$ 的换算为 $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$。详情请参见 [0. 概述](../0-overview.md) 中的“与 (WIN)PIP 的关系”。

---

## IP 倾斜校正

IP 相对于光轴（$Z$ 轴）的倾斜，用以通过原点且位于 $XY$ 平面内的直线为轴的旋转来表示。该旋转可以写成旋转矩阵 $R = R_2\,R_1\,R_2^{-1}$，即沿着绕 $Z$ 轴旋转了 $\varphi$ ($R_2$) 的轴旋转 $\tau$ ($R_1$) 的操作。

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

这等价于绕 $XY$ 平面内与 $X$ 轴成 $\varphi$ 角的单位向量 $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$ 旋转角度 $\tau$，展开后得到

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### 正变换（未倾斜平面 → 倾斜的 IP）

未倾斜的 $XY$ 平面上的点 $P_1 = (X,\ Y,\ 0)$ 映射为倾斜 IP 上的 $P_2 = R\,P_1$。

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### 投影（倾斜的 IP → 未倾斜平面）

实际需要的是反方向，即“在倾斜 IP 上观测到的像素”在没有倾斜时应位于的 $XY$ 平面坐标。这由 **中心（透视）投影** 给出：求出连接倾斜 IP 上的点与样品 $(0,0,-\mathrm{CL})$ 的直线与 $XY$ 平面的交点 $P_3$。由于这是以样品为投影中心的射影变换，可得

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

包含中心投影在内的倾斜校正是可以在齐次坐标中写成矩阵的射影变换，因此可以在计算机上快速计算各像素的位置。

---

## 像素形状校正

IP 的像素形状被视为一个 **平行四边形**：沿 $X$ 轴的长度为 $\mathrm{PixSizeX}$，沿 $Y$ 轴的长度为 $\mathrm{PixSizeY}$，与直角的偏差（畸变角）为 $\xi$。$\xi$ 不为零表示读取激光扫描的起始位置存在偏移，本软件假定该偏移沿 $Y$ 轴恒定。

从中心像素算起，在 $X$ 方向相距 $\mathrm{PixNumX}$、在 $Y$ 方向相距 $\mathrm{PixNumY}$ 的像素，其实际坐标 $P$ 为

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\tan\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\tan\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

将该像素形状校正与上述倾斜校正结合，即可将倾斜 IP 上的任意像素映射到未倾斜 $XY$ 平面上的正确位置。该映射是下一章参数确定以及 [A3. 图像积分](a3-image-integration.md) 的基础。
