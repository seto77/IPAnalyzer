<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# IPAnalyzer 手册

## 简要介绍

* **IPAnalyzer** 是基于 MIT 许可的免费软件，可将成像板 (IP) 或 CCD/CMOS 平板探测器记录的二维粉末衍射图像（Debye–Scherrer 环）转换为高精度的一维 2θ–强度谱线。
* 它可从标准物质的衍射环校准测量几何——相机长度、波长、探测器倾斜以及像素形状——支持 X 射线、电子和中子源，并可与 [PDIndexer](https://github.com/seto77/PDIndexer) 集成以进行后续的峰分析。
* 其设计与功能沿袭了由 AIST 的 Hiroshi Fujihisa 开发的 *PIP*。

## 按目标查找

| 目标 | 从这里开始 | 主要后续步骤 |
|------|------------|-----------------|
| 理解坐标系与几何 | [概述](0-overview.md) | [属性窗口](2-property-windows.md) |
| 载入图像并获取一维谱线 | [操作步骤](4-procedures.md) | [主窗口](1-main-window.md)、[属性窗口](2-property-windows.md) |
| 校准相机长度 / 波长 | [操作步骤](4-procedures.md) | [工具](3-tools.md)、[查找参数（暴力搜索）](6-find-parameter.md) |
| 掩蔽斑点 / 处理多帧数据 | [工具](3-tools.md) | [操作步骤](4-procedures.md) |
| 自动化处理 | [宏](5-macro/index.md) | [内置函数](5-macro/1-built-in-functions.md)、[示例](5-macro/2-examples.md)、[Auto Procedure](3-tools.md) |

## 功能特性

* **广泛的格式支持** : Fuji BAS2000/2500/FDL、Rigaku R-AXIS IV/V、ITEX、Bruker CCD、Rayonix、MAR research、Perkin Elmer、ADSC、RadIcon、Rad-Xcam、HDF5/NeXus、Digital Micrograph 3/4 以及常规图像格式。大多数文件 I/O 支持拖放。
* **图像到谱线的转换** : 同心（径向平均）、径向（方位角/cake）以及展开图像计算，采用亚像素面积分布算法，可正确处理探测器倾斜和平行四边形像素形状。
* **几何校准** : 对波长、相机长度、像素尺寸/畸变以及倾斜 (φ, τ) 进行几何（双盒式）精修，并为疑难数据提供网格暴力搜索。
* **图像处理** : 自动束流中心检测、单晶斑点 (spot) 检测与掩蔽、周向模糊、圆环叠加、强度表探测器校准，以及保留几何的 IPA 保存。
* **多帧数据** : 选择、平均或求和 HDF5/NeXus 及其他序列数据的帧，并可由嵌入的能量获得每帧波长。
* **自动化** : 文件夹监视的 Auto Procedure，以及用于批处理和脚本化处理的 Python 语法[宏](5-macro/index.md)。
* **PDIndexer 集成** : 通过剪贴板将谱线发送至 [PDIndexer](https://github.com/seto77/PDIndexer)，并在其中触发命名宏。
* **浅色 / 深色主题** : 界面遵循可选择的浅色或深色配色模式。

## 系统要求

| 项目 | 最低 | 推荐 |
|------|---------|-------------|
| OS | 安装有 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) 的 Windows | Windows 11 |
| 内存 | - | 16 GB 或更多 |
| CPU | - | 8 核以上（图像强度以双精度保存，处理为多线程） |

## 快速入门

1. 从 [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 下载并安装。
2. 读取衍射图像（File → Read image，或拖放）。
3. 在属性窗口中设置 **Wave source** 和 **Detector condition**（相机长度、像素尺寸、近似中心）。
4. 查找中心，必要时掩蔽斑点，然后按 **Get Profile** 获取一维谱线。
5. 如果几何未知，则从标准物质进行校准——参见[操作步骤](4-procedures.md)。

完整的工作流程请参见[操作步骤](4-procedures.md)。

## 如何使用本手册

此 GitHub Pages 手册是当前的权威来源。使用左侧导航按章节浏览，或使用页眉中的搜索查找函数名或 UI 标签。它取代了曾随 `IPAnalyzer/doc/` 分发的旧版 Word/HTML/PDF 手册。

## 许可证

IPAnalyzer 依据 [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) 分发。
