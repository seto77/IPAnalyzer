<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). -->

# 操作步骤

本页介绍典型任务的流程。各工具的说明请参见[工具](3-tools.md)。

## 基本流程（同心积分）

1. **载入图像**：**文件 (File) → 读取图像 (Read image)**（或拖放）。
2. **设置射线源**：在属性的 **波源 (Wave source)** 中设置元素 / 跃迁或波长。
3. **设置探测器条件**：在 **探测器条件 (Detector condition)** 中设置相机长度、像素尺寸、中心位置（大致值），必要时还要设置倾斜 φ、τ。
4. **查找中心**：用工具栏上的 **查找中心 (Find Center)** 自动检测束流中心（搜索范围在杂项 (Miscellaneous) 选项卡中设置）。
5. **掩蔽斑点**：用 **掩蔽斑点 (Mask Spots)** 去除单晶衍射等。必要时用 **手动模式 (Manual Mode)** 手动掩蔽。
6. **检查积分设置**：在 **积分区域 (Integral Region)** 中选择目标区域，并在 **积分属性 (Integral Property)** 中选择 **同心积分 (Concentric integration)**，设置坐标轴单位和 **开始 / 结束 / 步长 (Start / End / Step)**。
7. **对图像进行积分**：用 **获取图谱 (Get Profile)** 获得谱线。保存和发送在 **"获取图谱"之后 (After "Get Profile")** 选项卡中设置（CSV 保存、发送到 PDIndexer 等）。

对于序列图像，请在第 5–7 步之前在[序列图像 (Sequential image)](3-tools.md) 中选择帧。若要按方位角分析，请使用 **获取图谱 (Get Profile)** 下拉菜单中的 **方位角分割分析 (Azimuthal Division Analysis)**（将圆环分割为扇区并分别积分），或 **积分属性 (Integral Property)** 中的 **径向积分 (Radial integration)**（方位角–强度谱线）。

若相机长度、波长或倾斜未知，请先按下一节所述用标准样品的图像进行校准，应用所得值后再对样品图像进行积分。

## 参数确定：用标准样品进行几何校准（双暗盒法）

当相机长度或波长未知时，使用[查找参数 (几何法) (Find Parameter (Geometric))](3-tools.md)，根据标准物质（默认为 CeO2 等）的衍射环优化几何参数。

1. 用 **打开 (Open)** 载入 **主图像 (Primary image)**（标准样品，某一相机长度），查找中心，并用 **获取图谱 (Get Profile)** 显示峰。
2. 在 Profile View 中拖动衍射线标记，相机长度的估计值会自动更新。
3. 以同样方式载入 **次图像 (Secondary image)**（同一标准样品，不同的相机长度），并输入 **相机长度差** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm)（例如 Primary 为 100 mm、Secondary 为 120 mm 时为 +20）。次图像可以省略，仅用主图像也能校准。
4. 在 **峰列表 (Peak List)** 中选择两幅图像中都出现的峰的 d 值（通常每幅图像 3 个以上；使用两幅图像时，至少要有 1 个峰为两者共有。除仅精修相机长度的情况外，少于 3 个时 **精修! (Refine!)** 不会执行）。
5. 选择要优化的参数（波长、胶片距离、倾斜、像素尺寸、像素畸变、中心位置、球面校正）。
6. 运行 **精修! (Refine!)**。达到所设定的重复次数 (Repitition)（默认 12 次）后会自动停止。确认结果后，用 **精修参数 => 主窗体 (Refined parameters => Main form)** 将其复制到主窗体。

!!! note "注意"
    使用两幅图像（“双暗盒”）更容易将相机长度和波长分别确定。

## 参数确定：暴力优化（标准样品）

当几何法优化难以收敛时，用[查找参数 (穷举法) (Find Parameter (Brute force))](3-tools.md) 对相机长度、中心位置、倾斜以及可选的波长进行穷举搜索。带截图的详细说明请参见[查找参数（暴力搜索）](6-find-parameter.md)。

1. 在主窗体中载入一幅标准样品图像，打开 查找参数 (穷举法) (Find parameter (brute force))，并选择对应的标准物质。
2. 在主窗体中大致对准中心位置（查找中心 (Find Center) 会有帮助）。
3. 选择要优化的项目，输入步长 **初始步长 (Initial step)**（以当前值为中心）以及每一侧的步数（**搜索范围 (Search range)**）。对于平板探测器，像素尺寸不是搜索对象。数值示例请参见[查找参数（暴力搜索）](6-find-parameter.md)。
4. 将 **积分区域 (Integral Region)** 设为窄带宽的狭缝（矩形 (Rectangle)）模式有助于抑制噪声。
5. 用 **优化 (Optimize)** 开始搜索。每个循环中，评价值 R 最小的组合会被采用，并自动写入主窗体的参数。

## 自动处理（自动流程 (Auto Procedure)）

自动处理到达文件夹中的图像，例如在实验过程中。详情请参见[工具](3-tools.md)。

1. 用 **设置 (Set)** 选择监视文件夹。
2. 必要时按 **number matching**（文件名末尾的编号）或 **关键字 (keyword)** 筛选文件。
3. 启用 **After Loading Image, Execute "Auto"**，并从列表中选择：自动对比度 (Auto Contrast) / 查找中心 (Find Center) / 掩蔽斑点 (Mask Spots) / 获取图谱 (Get Profile) / Execute Macro。
4. 最后打开 **自动加载新图像 (Automatically load new images)** 开始监视（未指定文件夹时无法打开；使用开始监视时有效的编号 / 关键字条件）。之后每当有符合条件的图像到达，就会自动执行这一系列处理。

## 脚本化步骤（基于 Python 的宏）

包含循环和条件分支的处理可以写成[宏](5-macro/index.md)。宏编辑器中通过 **显示示例 (Show samples)** 显示的示例宏是很好的起点。

- 载入图像，设置射线源和探测器（中心、相机长度、像素），并调整显示。
- 设置同心积分的条件（开始、结束、步长、单位），进行一维化并保存为 CSV。
- 批处理多个文件，在每幅图像旁保存 CSV。
- 逐帧处理多帧图像。
- 将 Debye 环分割为 N 个扇区并分析方位角依赖性。
- 掩蔽（全部清除 → 掩蔽斑点 → 掩蔽束流挡板区域 → 保存掩模）并进行一维化。
- 用径向 (cake) 积分输出方位角 vs. 强度。
- 启用剪贴板发送，进行一维化，并调用 PDIndexer 中的命名宏（例如峰拟合）。

编写的宏可以保存、按名称调用，也可以从自动流程 (Auto Procedure) 中运行。
