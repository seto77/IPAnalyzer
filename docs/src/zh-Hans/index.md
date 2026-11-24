<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). -->

# IPAnalyzer 手册

## 简要介绍

* **IPAnalyzer** 是基于 MIT 许可的免费软件，可将成像板 (IP) 或 CCD/CMOS 平板探测器记录的二维粉末衍射图像（Debye–Scherrer 环）转换为高精度的一维 2θ–强度谱线。
* 它可根据标准物质的衍射环校准测量几何——相机长度、波长、探测器倾斜和像素形状——支持 X 射线、电子和中子源，并可与 [PDIndexer](https://github.com/seto77/PDIndexer) 联动以进行后续的峰分析。
* 其设计与功能沿袭了 AIST 的 Hiroshi Fujihisa 开发的 *PIP*。

## 按目标查找

| 目标 | 从这里开始 | 主要后续步骤 |
|------|------------|-----------------|
| 理解坐标系与几何 | [概述](0-overview.md) | [属性窗口](2-property-windows.md) |
| 载入图像并获取一维谱线 | [操作步骤](4-procedures.md) | [主窗口](1-main-window.md)、[属性窗口](2-property-windows.md) |
| 校准相机长度 / 波长 | [操作步骤](4-procedures.md) | [工具](3-tools.md)、[查找参数（暴力搜索）](6-find-parameter.md) |
| 掩蔽斑点 / 处理多帧数据 | [工具](3-tools.md) | [操作步骤](4-procedures.md) |
| 自动化处理 | [宏](5-macro/index.md) | [内置函数](5-macro/1-built-in-functions.md)、[示例](5-macro/2-examples.md)、[自动流程 (Auto Procedure)](3-tools.md) |
| 故障排除与常见问题 | [Q&A](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## 功能

* **广泛的格式支持** ：Fuji BAS2000/2500/FDL、Rigaku R-AXIS IV/V、ITEX、Bruker CCD、Rayonix、MAR research、Perkin Elmer、ADSC、RadIcon、Rigaku RINT-RAPID II、SMV、MRC、NeXus (`.nxs`)、Digital Micrograph 3/4 以及通用图像格式。大多数文件读写都支持拖放。
* **图像到谱线的转换** ：支持同心（径向平均）积分、径向（方位角 / cake）积分和展开图像计算，采用亚像素面积分配算法，可正确处理探测器倾斜和平行四边形像素形状。
* **几何校准** ：以几何法（双暗盒法）精修波长、相机长度、像素尺寸 / 畸变和倾斜 (φ, τ)，并为难以收敛的数据提供网格暴力搜索。
* **图像处理** ：束流中心自动检测、单晶斑点检测与掩蔽、周向模糊、圆环叠加、R-AXIS 图像强度校准，以及保留几何信息的 IPA 格式保存。
* **多帧数据** ：可对 NeXus (`.nxs`)、多页 TIFF 等序列数据的帧进行选择、平均或求和；若帧带有能量信息，选择该帧时会更新波长。
* **自动化** ：监视文件夹的自动流程 (Auto Procedure)，以及用于批处理和脚本处理的 Python 语法[宏](5-macro/index.md)。
* **PDIndexer 联动** ：通过剪贴板将谱线发送到 [PDIndexer](https://github.com/seto77/PDIndexer)，并触发其中的命名宏。

## 系统要求

以下要求适用于由本源代码树构建的 .NET 11 版本。对于已发布的版本，请遵循该版本所注明的运行时要求。

| 项目 | 最低 | 推荐 |
|------|---------|-------------|
| OS | 安装了 [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) 的 Windows | Windows 11 |
| 内存 | - | 16 GB 以上 |
| CPU | - | 8 核以上（图像强度以双精度保存，处理采用多线程） |

## 快速入门

1. 从 [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 下载并安装。
2. 读取衍射图像（**文件 (File) → 读取图像 (Read image)**，或拖放）。
3. 在属性窗口中设置 **波源 (Wave source)** 和 **探测器条件 (Detector condition)**（相机长度、像素尺寸、大致中心）。
4. 若几何（相机长度、波长、倾斜）未知，请先用标准样品的图像进行校准并应用所得值——参见[操作步骤](4-procedures.md)。
5. 在样品图像上查找中心，必要时掩蔽斑点，然后按 **获取图谱 (Get Profile)** 获得一维谱线。

完整流程请参见[操作步骤](4-procedures.md)。

## 如何使用本手册

本 GitHub Pages 手册是当前的正式版本。可通过左侧导航按章节浏览，或使用页眉中的搜索查找函数名或 UI 标签。它取代了以前在 `IPAnalyzer/doc/` 中分发的旧版 Word/HTML/PDF 手册。

## 许可

IPAnalyzer 以 [MIT 许可](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md)分发。
