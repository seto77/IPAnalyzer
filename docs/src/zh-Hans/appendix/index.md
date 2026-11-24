<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 附录

本附录汇总了 IPAnalyzer 在将二维衍射图像（Debye–Scherrer 环）转换为高精度一维谱线时所用的 **几何与算法的理论背景**。操作步骤和各功能的用法请参阅手册正文（[0. 概述](../0-overview.md)、[4. 操作步骤](../4-procedures.md) 等）。这里用公式说明其背后的坐标系定义、坐标变换、参数确定方法和积分算法。

内容依据分发包中附带的旧文档 `doc/IPAnalyzerAlgorithm.pdf` 以及当前的实现。

## 附录的结构

- **[A1. 探测器几何与坐标变换](a1-geometry.md)** —— 右手坐标系的定义、描述 IP 倾斜 ($\varphi,\ \tau$) 的旋转矩阵，以及像素形状 ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$) 的校正。
- **[A2. 参数确定](a2-calibration.md)** —— 使用标准物质校准相机长度、波长、像素尺寸和 IP 倾斜（双距离法、双谱线法、椭圆拟合）。
- **[A3. 图像积分](a3-image-integration.md)** —— 将像素强度分配到各角度步长的面积分割算法，以及积分后的归一化。
- **[A4. 对称性信息](a4-symmetry-information.md)** —— 标准晶体的空间群对称性、几何计算、Wyckoff 位置、衍射条件和对称元素图（Crystal 窗口的子窗口）。
- **[A5. 散射因子](a5-scattering-factor.md)** —— 标准晶体的结构因子和衍射列表（X 射线、电子、中子）（晶体窗口中 **射束相互作用 (Beam interaction)** 的 **衍射 (Reflections)** 选项卡）。

## 坐标系（通用参考图）

以下各页均以同一坐标系为共同前提。原点为 IP 上的直射斑点（束流与 IP 的交点），$Z$ 轴为束流传播方向，样品位于 $(0,\ 0,\ -\mathrm{CL})$。

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## 主要参数

| 符号 | 名称 | 含义 |
|------|------|------|
| $\lambda$ | 波长 (Wave Length) | 射线源的波长。特征 X 射线的波长是已知的；同步辐射的波长随单色器位置而变化，每次都必须确定。 |
| $\mathrm{CL}$ | 相机长度 (Camera Length) | 样品与原点（直射斑点）之间的距离。样品位置为 $(0,0,-\mathrm{CL})$。对应界面上的 **相机长度 1 (Camera Length 1)**；**相机长度 2 (Camera Length 2)** 是样品到探测器的垂直距离，存在倾斜 $\tau$ 时两者不同。 |
| $\varphi,\ \tau$ | 倾斜校正 (Tilt Correction) | IP 相对于光轴（$Z$ 轴）的倾斜。$\varphi$ 是倾斜轴在 XY 平面内的方位角，$\tau$ 是绕该轴的旋转角。 |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | 像素大小 (Pixel Size) | 将像素表示为平行四边形。$\xi$ 是读取激光扫描起点的偏移（畸变角）。 |

波长在属性窗口的 **波源 (Wave source)** 选项卡中设置，相机长度、倾斜和像素形状在 **探测器条件 (Detector condition)** 选项卡中设置（参见 [2. 属性窗口](../2-property-windows.md)）。
