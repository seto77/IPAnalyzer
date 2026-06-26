<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# 主窗口

主窗口是 IPAnalyzer 启动时首先显示的画面。它汇集了已加载衍射图像的显示、主要操作（查找中心、掩蔽斑点、一维化），以及进入探测器参数设置的入口。

该窗口大致由顶部的菜单和工具栏、中央的图像显示区、右侧的纵向工具栏，以及底部的图形区构成。

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## 中央视图

### 图像显示

已加载的图像在此处显示。根据鼠标指针的位置，图像上方区域会显示实际坐标 (mm)、图像坐标 (pix)、距中心的距离 R (mm)、散射角 2θ、d 值、方位角 χ 以及强度。洋红色的 × 标记表示直接束斑（中心）位置。

像素状态以不同颜色显示。

| 颜色 | 含义 |
| --- | --- |
| Cyan | 被掩蔽的斑点 |
| Green | 排除在积分之外的区域（在 Integral Region 中设置） |
| Magenta | 排除在积分之外的角度区域（在 Integral Property 中设置） |
| Blue | 低于强度阈值的像素（在 Integral Region 中设置） |
| Red | 高于强度阈值的像素 |

### 鼠标操作

在普通模式下：

- 按住左键：在附近搜索斑点中心。
- 左键双击：将中心位置更新为点击点。
- 右键拖动：放大至拖动的区域。
- 右键单击：缩小。

在 **Manual spot mode** 下，左键单击进行掩蔽，右键单击取消掩蔽。掩模的形状和大小在工具栏和属性中设置。

### 辅助视图与图像信息

中央视图旁边是辅助显示。可在 **Whole image** 与 **Near center** 之间切换：整图视图用黄色边框标出当前的显示范围，近中心视图显示放大后的图像。

**Image Information** 显示图像分辨率、最大强度、总强度、头部数据等。

### 显示调整控件

用于调整图像显示方式的控件：

- **Gradient**：反转色调。
- **Brightness scale**：对数 / 线性。
- **Color scale**：灰度 / 彩色。
- **Scale line**：刻度线显示（无 / 粗 / 中 / 细）。
- **Auto Contrast** / **Reset Contrast**，以及明确的最小/最大强度。
- 放大倍率按钮（×1、×2、×4、×1/2、×1/4、×1/8、×1/16）。

## 下方视图

底部区域有三个带标签页的图形/视图。

- **Frequency of Intensity**：所有像素的强度分布，采用 log–log 坐标轴。可用鼠标缩放。
- **Converted Profile**：一维化（Get Profile）之后的衍射谱线。可用鼠标缩放。
- **Statistical Information**：选定矩形区域 (X1,Y1)–(X2,Y2) 的统计信息。当加载了序列图像时，还可比较其他帧中同一区域的统计信息。

## 菜单

菜单栏由 **File / Tool / Property / Option / Language / Macro / Help** 构成。

### File

- **Read image**：打开一张衍射图像。支持的格式见 [概述](0-overview.md)。
- **Save image**：保存为 TIFF、PNG、CSV 或 IPA 格式。TIFF 保留原始像素强度，PNG 保留显示效果（亮度、对比度、掩模），IPA 是经过畸变校正的专有格式（含元数据）。
- **Read / Save parameter**：将波长、相机长度、像素尺寸、倾斜校正、中心位置等作为 `.prm` 文件导入/导出。
- **Read / Save / Clear mask**：将掩模作为 `.mas` 文件导入/导出，或将其清除（掩模必须与当前图像的分辨率匹配）。
- **Close**。

图像、参数和掩模文件也可以通过拖放到窗口上来加载。

### Tool

- **Reset Frequency Profile**：清除强度频率图（图像保留）。
- **Calibrate Raxis Image**。

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous。这些会直接打开[属性窗口](2-property-windows.md)中对应的标签页。

### Option

- **ToolTip**：切换按钮和菜单上的工具提示。
- **Flip**：水平 / 垂直。**Rotate**：选择旋转角度。两者都仅影响显示；已加载的图像数据本身不会被更改。
- **Ngen Compile** 和 **Clear registry** 用于开发和故障排查。

### Language

- 在 **English** 与 **Japanese** 之间切换（该设置保存在注册表中）。

### Macro

- **Editor**：打开宏编辑器（见[工具](3-tools.md) / [宏](5-macro/index.md)）。

### Help

- **Program Updates**、**Hint**、**License**、**Version History**、**Web Page**。

## 操作工具栏

主要的图像处理操作（下拉菜单中提供详细选项）：

- **Background**：扣除背景图像（在 Background Option 中配置）。
- **Find Center**：通过二维 Pseudo-Voigt 拟合检测束流中心（默认搜索范围 8 px，在 Miscellaneous 中设置）。下拉菜单还提供基于圆环的中心检测。
- **Fix center**：固定中心位置。
- **Mask Spots**：使用判据 mean ± standard deviation × Deviation 检测并掩蔽斑点。下拉菜单包含全部掩蔽、反向掩蔽、手动等。
- **Manual**：手动掩蔽模式。可选择形状（circle / rectangle）和大小（8–256 px）。
- **Get Profile**：将图像积分为一维谱线。支持 Concentric（基于 2θ）和 Radial（基于方位角）。下拉菜单可配置 Integral Property/Region 的选择、是否在积分前查找中心并掩蔽斑点、发送到 PDIndexer、方位角分割分析、序列图像处理等。

## 工具栏（其他工具）

右侧的纵向工具栏用于启动各种工具。详见[工具](3-tools.md)。

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
