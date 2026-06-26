<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# 操作步骤

本页展示典型任务的操作流程。各工具的说明请参见 [Tools](3-tools.md)。

## 基本流程（同心积分）

1. **载入图像**：File → Read image（或拖放）。
2. **设置射线源**：在属性中的 **Wave source** 下设置元素/跃迁或波长。
3. **设置探测器条件**：在 **Detector condition** 下设置相机长度、像素尺寸、中心位置（近似值），并在需要时设置倾斜 φ、τ。
4. **查找中心**：使用工具栏上的 **Find Center** 自动检测束流中心（搜索范围在 Miscellaneous 下设置）。
5. **掩蔽斑点**：使用 **Mask Spots** 去除单晶反射等。如有需要，可用 **Manual** 手动掩蔽。
6. **一维化**：使用 **Get Profile** 获得谱线。保存与发送在 **After "Get Profile"** 选项卡上配置（CSV 保存、发送到 PDIndexer 等）。

对于序列图像，请在步骤 5–6 之前在 [Sequential](3-tools.md) 中选择一帧。若要按方位角分析，请使用 **Integral Property** 中的 Radial integration。

## 参数确定：使用标准样品的几何校准（双盒式 double cassette）

当相机长度或波长未知时，可根据标准物质（默认为 CeO2 等）的衍射环优化几何参数，使用 [Find Parameter (Geometric)](3-tools.md)。

1. 使用 Open 载入 **Primary image**（标准样品，在某一相机长度下），查找中心，并用 **Get Profile** 显示峰。
2. 在 Profile View 中拖动衍射线标记会自动更新相机长度估计值。
3. 以相同方式载入 **Secondary image**（同一标准样品，在不同相机长度下），并输入相对于 Primary 的 **camera-length difference**。
4. 在 **Peak List** 中，选择在两幅图像中均出现的峰的 d 值（每幅图像至少一个，理想情况下三个或以上）。
5. 在 **Refinement Option** 下，选择要优化的参数（波长、film distance、倾斜、像素尺寸、像素畸变）。
6. 运行 **Refine!**，待残差稳定后，将优化结果复制回主窗体。

!!! note
    使用两幅图像（"double cassette"）可以更容易地分别确定相机长度和波长。

## 参数确定：暴力优化（任意样品）

当几何优化难以收敛时，可使用 [Find Parameter (Brute force)](3-tools.md) 对相机长度和波长进行穷举搜索。带截图的详细演练请参见 [Find Parameter (brute force)](6-find-parameter.md)。

1. 载入 Primary 和 Secondary 图像（两幅图像，具有共同的环，在不同相机长度下）。
2. 在主窗体中大致对齐中心位置（Find Center 有帮助）。
3. 输入相机长度、波长等的 **search ranges (min, max, step)**。开始时先关闭未知参数（像素尺寸、倾斜）。
4. 将 **Integral Region** 设置为窄带宽的 slit (Rectangle) 模式有助于抑制噪声。
5. 启动搜索，并将残差最小的组合复制回主窗体。

## 自动化处理（Auto Procedure）

自动处理到达某个文件夹的图像，例如在实验过程中。详情请参见 [Tools](3-tools.md)。

1. 启用 **Automatically load new images**，并用 **Set** 选择监视文件夹。
2. 如有需要，按 **number matching**（文件名末尾的数字）或 **keyword** 过滤文件。
3. 启用 **After Loading Image, Execute "Auto"**，并从列表中选择：Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro。
4. 监视开始后，每当匹配的图像到达时，该序列就会自动运行。

## 脚本化操作步骤（基于 Python 的宏）

带循环和条件判断的处理可以编写为[宏](5-macro/index.md)。随附的示例宏是很好的起点。

- 载入图像，设置射线源和探测器（中心、相机长度、像素），并适配显示。
- 设置同心积分条件（起点、终点、步长、单位），进行一维化，并保存为 CSV。
- 批量处理多个文件，在每幅图像旁保存一个 CSV。
- 逐帧处理多帧图像。
- 将 Debye 环分割为 N 个扇区，并分析方位角依赖性。
- 掩蔽（全部清除 → 掩蔽斑点 → 掩蔽 beam-stop 区域 → 保存掩模）并一维化。
- 通过径向（cake）积分输出方位角与强度的关系。
- 启用剪贴板发送，进行一维化，并调用 PDIndexer 中的命名宏（例如峰拟合）。

你编写的宏可以保存、按名称调用，也可以从 Auto Procedure 运行。
