<!-- 260601Cl: Reflected from ja/2-property-windows.md (lead language: Japanese). 260601Cl: per-tab auto-capture images embedded. -->

# Property Windows

属性窗口用于配置波源、探测器条件以及各种一维化条件。每个选项卡也可从主窗口的 **Property** 菜单直接打开。

本窗口的界面为英文。下面的标题采用实际的选项卡名和控件名。

## Wave source

设置入射束的类型和波长。波源可以是 X 射线、电子或中子。对于 X 射线，选择一个元素和一个跃迁（K line、L line 等）会自动填入波长；对于同步辐射，请直接输入波长。对于电子束和中子束，请输入能量或波长（电子波长经过相对论修正）。

- **Correct linear polarization**：将线偏振强度修正为非偏振等效值（用于同步辐射数据）。下面的修正公式取决于方位角 χ（在 Miscellaneous 选项卡上定义）和散射角 2θ。

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![Wave source tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## Detector condition

设置探测器的几何条件。这对应于旧版的 "IP Condition"，并增加了坐标系和探测器形状的选择器。

- **Coordinates**：**Direct spot**（直射斑参考） / **Foot**（垂足参考）。
- **Detector type**：**Flat panel** / **Gandolfi**。
- **Direct spot position** 和 **Camera Length 1**：直射斑位置（X、Y pix）以及从样品到直射斑的距离（mm）。
- **Foot position** 和 **Camera Length 2**：在 Foot 模式下，垂足的位置以及从样品到垂足的距离。
- **Pixel Shape**：像素尺寸 X、Y（mm）以及 ξ（Ksi，平行四边形倾斜角）。
- **Gandolfi Radius**：当选择 Gandolfi 形状时的半径。
- **Spherical correction**：球面修正（通常为零）。
- **Tilt**：IP 倾斜 φ（Phi）和 τ（Tau）。

关于倾斜 φ、τ 和像素 ξ 的定义，请参阅 [概述](0-overview.md)。

![Detector condition tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## Integral Region

指定要进行一维化的图像区域。

- **Rectangle**：选择 **Direction**（Full / Top / Bottom / Left / Right / Vertical / Horizontal / Free），并设置 **Band Width**、**Angle**（在 Free 模式下）以及 **Both Side**。
- **Sector**：用 **Start Angle** / **End Angle** 指定角度范围。
- **Exceptional pixels**：排除 **Masked Spots**、强度 **Under intensity of** / **Over intensity of** 给定阈值的像素，以及距边缘若干 **pixels from edges** 的像素。

![Integral Region tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## Integral Property

设置积分方法和步长。

- **Concentric integration (scattering-angle dispersive)**：从 **Angle**（2θ，°） / **Length**（mm） / **d-spacing**（Å）中选择横轴单位，并设置 **Start / End / Step**。**Output pattern** 可以是 **Bragg - Brentano** 或 **Debye - Scherrer**。
- **Radial integration (cake pattern)**：沿方位角方向分析环形区域。从 **Angle** / **d-spacing** 中选择横轴，并设置 **Donut radius**（中心半径）、**Donut width**（环宽）以及 **Sector angle step**（扫描步长）。

![Integral Property tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## Mask Option

设置掩蔽以及中心/斑点检测的条件（旧版 "Find Center & Spots" 的扩展）。

- **Half mask**：用于快速掩蔽图像上半、下半、左半或右半的按钮。
- **Manual mask mode**：在主图像上启用交互式掩蔽。形状有 **Circle**（拖动以设置中心和半径）、**Polygon**（点击以添加顶点）、**Rectangle**（拖动对角顶点）、**Spline curve** 以及 **Spot**（左键/右键点击以添加/移除斑点）。
- **Takeover**：加载新图像时如何处理掩模（**None** / **Take over the current mask state** / **Take over the mask file**）。
- **Find Spots** → **Deviation**：斑点检测的统计阈值。
- **Find Center**：中心检测的搜索范围，等等。

![Mask Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## After "Get Profile"

设置一维化之后的保存与发送。

- **Save File**：选择目标位置（"与图像相同的目录" 或 "每次选择的目录"）以及格式 **PDI** / **CSV** / **TSV** / **GSAS**。
- **Send PDIndexer**：通过剪贴板将谱线发送到正在运行的 PDIndexer 实例。

![After "Get Profile" tab](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## Unrolled Image Option

设置展开（Unroll）图像的参数。

- **Horizontal**：单位（Angle / Length / d-spacing）以及 **Start / End / Step**。输出图像宽度 ≈ (End − Start) / Step。
- **Vertical**：方位角步长（°/pixel）。输出图像高度 ≈ 360 / step。

展开会将以直射斑为中心的极坐标衍射图像映射为笛卡尔（角度对距离）图像。

![Unrolled Image Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## Miscellaneous

汇集较细的显示和坐标设置的选项卡。

- **Image name display**：仅文件名 / 父文件夹 + 文件名 / 完整路径。
- **Contrast / intensity-range persistence**：加载新图像时是否沿用显示设置。
- **Azimuth χ (Chi) orientation**：参考位置（Top / Bottom / Left / Right）以及旋转方向（Clockwise / Counterclockwise）。χ 被偏振修正和径向积分所引用。
- **Scale line**：颜色、宽度、分度数以及标签显示。
- **Find Center**：搜索范围、峰拟合范围、固定中心，以及排除掩蔽像素。

![Miscellaneous tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## Background Option

设置用背景图像进行的修正。

- **Background image**：将当前显示的图像设为背景（**Set the current image as background**），或清除它（**Clear**）。
- **Coefficient**：施加到背景图像上的系数。
- **Edge mask**：在修正时于边缘施加的额外掩模余量（px）。

用于平场修正、去除空气散射等。

![Background Option tab](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
