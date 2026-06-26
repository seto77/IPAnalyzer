<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# Appendix

本附录总结了 IPAnalyzer 将二维衍射图像（Debye–Scherrer 环）转换为高精度一维谱线时所使用的**几何与算法的理论背景**。关于操作步骤以及各功能的使用方法，请参阅主手册（[0. Overview](../0-overview.md)、[4. Practical procedures](../4-procedures.md) 等）。这里通过公式说明其背后的坐标系定义、坐标变换、参数确定方法以及积分算法。

本部分内容基于分发包中附带的旧版文档 `doc/IPAnalyzerAlgorithm.pdf` 以及当前的实现。

## 附录结构

- **[A1. Detector geometry and coordinate transforms](a1-geometry.md)** — 右手坐标系的定义、描述 IP 倾斜 ($\varphi,\ \tau$) 的旋转矩阵，以及像素形状 ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$) 的校正。
- **[A2. Parameter determination](a2-calibration.md)** — 使用标准物质对相机长度、波长、像素尺寸和 IP 倾斜进行校准（双距离法、双线法、椭圆拟合）。
- **[A3. Image integration](a3-image-integration.md)** — 将像素强度分配到各角度步长的面积划分算法。
- **[A4. Symmetry information](a4-symmetry-information.md)** — 标准晶体的空间群对称性、几何计算、Wyckoff 位置、衍射条件以及对称元素图（Crystal 窗口的子窗口）。
- **[A5. Scattering factor](a5-scattering-factor.md)** — 标准晶体的结构因子和衍射列表（X 射线、电子、中子）（Crystal 窗口的子窗口）。

## 坐标系（通用参考图）

以下各页都以同一坐标系作为共同前提。原点为 IP 上的直射斑点（束流与 IP 相交的点），$Z$ 轴为束流传播方向，样品位于 $(0,\ 0,\ -\mathrm{CL})$。

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## 主要参数

| Symbol | Name | Meaning |
|------|------|------|
| $\lambda$ | Wave Length | 光源的波长。对于特征 X 射线为已知量；对于同步辐射，其值随单色器位置变化，每次都必须确定。 |
| $\mathrm{CL}$ | Camera Length | 样品与原点（直射斑点）之间的距离。样品位置为 $(0,0,-\mathrm{CL})$。 |
| $\varphi,\ \tau$ | Tilt Correction | IP 相对于光轴（$Z$ 轴）的倾斜。$\varphi$ 是倾斜轴在 XY 平面内的方位角，$\tau$ 是绕该轴的旋转角。 |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | 将像素表示为平行四边形。$\xi$ 是读出激光扫描起点的偏移（畸变角）。 |

这些值在属性窗口的 IP Condition 选项卡中设置（参见 [2. Property windows](../2-property-windows.md)）。
