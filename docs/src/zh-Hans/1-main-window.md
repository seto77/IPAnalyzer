<!-- 261124Cl: Retranslated from en/1-main-window.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 主窗口

主窗口是 IPAnalyzer 启动时显示的第一个界面。它集中了已载入衍射图像的显示、主要操作（查找中心、掩蔽斑点、积分为一维谱线）以及探测器参数设置的入口。

窗口大致由顶部的菜单和工具栏、中央的图像显示区、右侧的竖向工具栏以及底部的图表区组成。

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## 中央视图

### 图像显示

此处显示已载入的图像。根据鼠标指针的位置，图像上方会显示实际坐标 (mm)、图像坐标 (pix)、到中心的距离 R (mm)、散射角 2θ、d 值、方位角 χ 和强度。品红色 × 标记表示直射斑点（中心）的位置。

像素状态以不同颜色显示。

| 颜色 | 含义 |
| --- | --- |
| 青色 | 已掩蔽的斑点 |
| 绿色 | 排除在积分之外的区域（在 **积分区域 (Integral Region)** 中设置） |
| 品红色 | 排除在积分之外的角度区域（在 **积分属性 (Integral Property)** 中设置） |
| 蓝色 | 低于强度阈值的像素（在积分区域中设置） |
| 红色 | 高于强度阈值的像素 |

### 鼠标操作

在普通模式下：

- 左键双击：将中心位置更新为所点击的点。
- 中键单击：以所点击的点为起点搜索中心。
- 右键拖动：放大所拖动的区域。
- 右键单击：缩小。
- Ctrl + 右键拖动：选择用于统计信息的矩形区域。

左键双击和中键单击仅在 **固定中心 (Fix Center)** 关闭时有效。

在 **手动模式 (Manual Mode)** 下，左键单击为掩蔽，右键单击为取消掩蔽。掩模的形状和大小在工具栏和属性中设置。

### 辅助视图与图像信息

中央视图旁边有辅助显示。可在 **整幅图像 (Whole image)** 和 **中心附近 (Near center)** 之间切换：整幅图像视图用黄色框标出当前的显示范围，中心附近视图显示放大的图像。

**图像信息 (Image Information)** 显示图像分辨率、最大强度、总强度、头信息等。

### 显示调整控件

用于调整图像显示方式的控件：

- **渐变 (Gradient)**：反转色调。
- **亮度刻度 (Brightness scale)**：对数 / 线性。
- **色阶 (Color scale)**：灰度 / 彩色。
- **比例尺 (Scale line)**：比例尺显示（无 / 粗 / 中 / 细）。
- **自动对比度 (Auto Contrast)** / **重置对比度 (Reset Contrast)**，以及显式指定最小 / 最大强度。
- 放大倍率按钮（×1、×2、×4、×1/2、×1/4、×1/8、×1/16）。

## 下部视图

底部区域有三个以选项卡切换的图表 / 视图。

- **强度频率 (Frequency of Intensity)**：所有像素的强度分布，以双对数坐标显示。可用鼠标缩放。
- **转换后图谱 (Converted Profile)**：由 **获取图谱 (Get Profile)** 生成的衍射谱线。可用鼠标缩放。
- **统计信息 (Statistical Information)**：在图像上按 Ctrl + 右键拖动所选矩形区域 (X1,Y1)–(X2,Y2) 的统计量。载入序列图像时，还可比较其他帧中同一区域的统计量。

## 菜单

菜单栏由 **文件 (File) / 工具 (Tool) / 属性 (Property) / 选项 (Option) / 语言 (Language) / 宏 (Macro) / 帮助 (Help)** 组成。

### 文件 (File)

- **读取图像 (Read image)**：打开衍射图像。支持的格式请参见[概述](0-overview.md)。
- **保存图像 (Save image)**：保存为 TIFF、PNG、CSV 或 IPA 格式。TIFF 保存当前处理后的像素强度（经过翻转 / 旋转、背景扣除和偏振校正之后），PNG 保留显示状态（亮度、对比度、掩模），IPA 是经过畸变校正的专有格式（含元数据）。
- **读取参数 (Read parameter) / 保存参数 (Save parameter)**：以 `.prm` 文件导入 / 导出波长、相机长度、像素尺寸、倾斜校正、中心位置等。
- **读取掩模 (Read mask) / 保存掩模 (Save mask) / 清除掩模 (Clear mask)**：以 `.mas` 文件导入 / 导出掩模，或将其清除（掩模必须与当前图像的分辨率一致）。
- **关闭 (Close)**。

图像、参数和掩模文件也可以通过拖放到窗口上来载入。

### 工具 (Tool)

- **重置频率图谱 (Reset Frequency Profile)**：以默认范围重建当前图像的强度频率图（图像保持不变）。
- **校准 R-AXIS 图像 (Calibrate Raxis Image)**：由两幅 R-AXIS 图像求出强度换算表（参见[工具](3-tools.md)）。

### 属性 (Property)

波源 (Wave Source) / 成像板条件 (Imaging Plate Condition) / 积分区域 (Integral Region) / 积分属性 (Integral Property) / 手动掩模模式 (Manual Mask Mode) / 在“获取图谱”之后 (After "Get Profile") / 展开图像选项 (Unrolled Image Option) / 杂项 (Miscellaneous)。这些菜单项直接打开[属性窗口](2-property-windows.md)中对应的选项卡。

### 选项 (Option)

- **工具提示 (ToolTip)**：切换按钮和菜单上的工具提示。
- **翻转 (Flip)**：**水平 (Horizontally)** / **垂直 (Vertically)**。**旋转 (Rotate)**：选择旋转角度。翻转和旋转作用于工作中的图像数据，因此也会影响之后的积分和图像保存（磁盘上的源文件不会被修改）。
- **清除注册表 (检查并重启) (Clear registry (check and restart))**：用于故障排除的项目，会清除已保存的设置。

### 语言 (Language)

- 选择显示语言（11 种语言）。确认后应用程序会重新启动。该设置保存在注册表中。

### 宏 (Macro)

- **编辑器 (Editor)**：打开宏编辑器（参见[工具](3-tools.md) / [宏](5-macro/index.md)）。

### 帮助 (Help)

- **程序更新 (Program Updates)**、**提示 (Hint)**、**许可 (License)**、**版本历史 (Version history)**、**帮助 (Help)**。
- **帮助 (Help)** 与按 **F1** 一样，在默认的网页浏览器中打开本在线手册。
- 在任意窗口中按 **F1** 可打开本在线手册的对应页面。

## 操作工具栏

主要的图像处理操作（详细选项在下拉菜单中）：

- **背景 (Background)**：此按钮在当前版本中不可用。背景图像扣除在属性窗口的 **背景选项 (Background Option)** 选项卡中设置。
- **查找中心 (Find Center)**：通过二维 Pseudo-Voigt 拟合检测束流中心（默认搜索范围为中心周围 ±8 px，在杂项 (Miscellaneous) 选项卡中设置）。用 **绘制环 (Draw ring)** 显示圆环时，改为根据圆环确定中心。
- **固定中心 (Fix Center)**：固定中心位置。
- **掩蔽斑点 (Mask Spots)**：在每个径向带内，强度超过 平均值 + 标准差 × **"掩蔽斑点"的判据偏差 (Criterial deviation for "Mask Spots")**（掩模选项 (Mask Option) 选项卡）的像素被检测为斑点，并连同其周围一起被掩蔽。下拉菜单中包括 **掩蔽全部区域 (Mask all area)**、**反转掩模 (Invert mask)**、**手动模式 (Manual Mode)** 等。
- **手动模式 (Manual Mode)**：手动掩模模式。可选择掩模形状（斑点（圆 / 矩形）/ 圆 / 矩形 / 多边形 / 样条曲线）以及斑点大小（半宽）。
- **获取图谱 (Get Profile)**：将图像积分为一维谱线。支持 **同心积分 (Concentric Integration)**（基于 2θ）和 **径向积分 (Radial integration)**（基于方位角）。下拉菜单用于设置积分属性 / 积分区域的选择、积分前是否查找中心和掩蔽斑点、发送到 PDIndexer、**方位角分割分析 (Azimuthal Division Analysis)**（仅适用于同心积分且横轴为 **角度 (Angle)** (2θ) 的情况；否则会显示警告且不执行）、序列图像处理等。

## 工具栏（其他工具）

右侧的竖向工具栏用于启动各种工具。详情请参见[工具](3-tools.md)。

- **自动流程 (Auto procedure)**
- **绘制环 (Draw ring)**
- **查找参数 (几何法) (Find parameter (geometrically))** / **查找参数 (穷举法) (Find parameter (brute force))**
- **展开图像 (Unroll image)**
- **周向模糊 (Circumferential blur)**
- **序列图像 (Sequential image)**
