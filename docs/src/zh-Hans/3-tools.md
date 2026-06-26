<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Tools

本页介绍从主窗口右侧的纵向工具栏或菜单中启动的辅助工具。关于使用参数校准和宏的具体操作步骤，请参阅 [操作步骤](4-procedures.md)。

## Intensity Table

用于比较两幅图像的强度分布并优化强度转换表的工具。它在保持总积分强度不变的前提下，对 16 个控制点进行 300 次迭代优化，使两幅图像的强度相匹配。例如可用于校准探测器的强度响应。

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

用于监视文件夹、自动加载新图像，并在加载后执行一系列操作的工具。

- **Watch and auto-load**：监视指定文件夹（包括子文件夹），并在文件写入完成后读取该文件。可按文件名（数字匹配、关键字）进行筛选。
- **Auto execution**：在 Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro 中，按顺序执行被勾选的步骤。

这样便可实现诸如在实验过程中监视输出文件夹、并在每幅图像到达时自动对其积分等用途。详情请参阅 [操作步骤](4-procedures.md)。

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

在考虑 IP 倾斜和像素畸变的情况下，在图像上以指定的距离、角度或 d 值绘制圆环。单击 **R (mm)** / **2θ (°)** / **d (Å)** 之一以选择要编辑的值；其余各值将根据波长和相机长度自动计算。

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

将衍射图像从以直射斑点为中心的极坐标展开为直角坐标（横轴 = 角度、距离或 d 值；纵轴 = 方位角）。现在它不再通过专用窗口进行配置，而是通过 **Unroll** 工具栏按钮和属性中的 **Unrolled Image Option** 选项卡进行配置。展开使用与一维化相同的亚像素强度分布算法。

## Circumferential Blur

用于沿周向（方位角）方向模糊圆环图样的工具。指定单一的模糊角度并应用即可。

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

用于处理多帧图像（HDF5 及类似格式；时间序列、温度序列、同步辐射能量扫描）的工具。

- 从帧列表中选择单帧以显示，或使用滑动条逐帧浏览。
- 通过 **multi-selection**，选择多个帧并计算其 **average** 或 **sum**。
- 一维化的目标可从“所有帧 / 选定帧 / 仅最上层”中选择。
- 如果每帧都带有能量信息，则波长会自动更新。

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

校正 IP 倾斜 φ、τ 以及像素畸变 ξ，并以指定的分辨率、采用正方形像素保存图像。相机长度、波长和中心位置等元数据也会一并写入，因此可在保留几何信息的同时将该图像传递给其他图像处理。

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

用于根据标准物质的衍射环优化波长、相机长度、像素尺寸、像素畸变和倾斜 (φ, τ) 的工具。它使用 Primary 和 Secondary 两个图样，您可选择峰并通过 **Refine!** 进行优化。收敛情况（椭圆中心、残差）可在图表上查看。具体步骤请参阅 [操作步骤](4-procedures.md)。

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

用于通过穷举网格搜索（而非梯度法）查找相机长度和波长的工具。当几何优化难以收敛时（例如圆环不完整或数据噪声较大），它很有效。CrystalControl 用于输入晶体参数。详细步骤请参阅 [查找参数（暴力搜索）](6-find-parameter.md)，工作流程请参阅 [操作步骤](4-procedures.md)。

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

通过类 Python 脚本实现操作自动化的功能。从主窗口的 **Macro → Editor** 菜单打开宏编辑器。

- 可使用 `for` / `if` / `while` / `def` / `class`、算术运算以及 `math` 模块。
- `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` 等 API 可用于调用各项操作。
- 内置了示例宏（基本循环、几何设置、批处理、方位角分割、掩蔽、发送到 PDIndexer 等），并且可通过单步执行检查变量。

完整的函数参考和示例请参阅 [宏](5-macro/index.md)，基于宏的工作流程请参阅 [操作步骤](4-procedures.md)。

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

专为 R-Axis 探测器特有的强度校正而设计的工具；目前它仅读取文件，校正本身尚未实现。

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
