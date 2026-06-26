<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# 概述

IPAnalyzer 能将成像板 (IP) 或 CCD/CMOS 探测器记录的 Debye–Scherrer 环高精度、高速地转换为一维衍射谱线。其设计与功能参照了由国立先进工业科学技术研究所 (AIST) 的 Hiroshi Fujihisa 开发的 PIP。

主要功能:

- 支持多种图像格式 (FujiBAS2000/2500, R-AXIS4/5, ITEX, Bruker CCD, IP Display, IPAimage, Fuji FDL, Rayonix, Mar research, Perkin Elmer, ADSC, RadIcon 以及通用图像格式)
- X 射线、电子和中子源
- 与 PDIndexer 集成
- 测量参数的半自动分析

## 系统要求与安装

### 要求

- 操作系统: Windows (推荐 Windows 11)
- 必需运行时: .NET Desktop Runtime 10.0
- 推荐内存: 16 GB 或以上
- 推荐 CPU: 8 核或以上

软件内部大量使用多线程计算，因此核心数更多的 CPU 运行更为流畅。图像强度在内部以双精度浮点值保存。

本软件以 MIT License 分发。

### 安装

1. 预先安装 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)。
2. 从 GitHub [releases page](https://github.com/seto77/IPAnalyzer/releases) 下载 `IPAnalyzerSetup.msi`。
3. 运行 `IPAnalyzerSetup.msi` 进行安装。

## 轴向、IP 倾斜与像素形状

IPAnalyzer 采用右手坐标系，其原点与轴方向定义如下。

- X 射线或电子束与 IP 相交的点（直射斑点）定义为原点 (0, 0, 0)，Z 轴与束流方向重合。
- 将样品尺寸视为无穷小，样品位置与原点之间的距离定义为相机长度 (Camera Length, CL)。因此样品位于 \((0,\ 0,\ -\mathrm{CL})\)。
- 当 IP 未倾斜时，X 轴与 IP 读取激光的扫描方向对齐。因此 Y 轴在屏幕上指向下方。
- IP 倾斜表示为绕一条位于 XY 平面内且通过原点的直线的旋转：绕与 X 轴成 \( \varphi \) 角的直线旋转 \( \tau \)。
- 像素形状被视为由 PixSizeX、PixSizeY 和 \( \xi \) 描述的平行四边形。非零的 \( \xi \) 意味着 IP 读取激光扫描的起始位置存在偏移。软件假定该偏移沿 Y 轴恒定。

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

相机长度、\( \varphi \)、\( \tau \)、像素尺寸和 \( \xi \) 在属性窗口的 IP Condition 选项卡中设置（参见 [2. Property Windows](2-property-windows.md)）。

### 与 (WIN)PIP 的关系

在 IPAnalyzer 中，X 轴（IP 图像的向右方向）沿顺时针旋转 \( \varphi \)，所得轴再旋转 \( \tau \)。在 PIP 中，Y 轴（IP 图像的向下方向）沿逆时针旋转 \( \beta \)，所得轴再旋转 \( \Phi \)。因此，要将 PIP 的 \((\beta,\ \Phi)\) 转换为 IPAnalyzer 的 \((\varphi,\ \tau)\)，使用 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\)。

## 像素强度积分方法

一维化的核心问题在于：当角度步长间隔小于像素间隔（即像素尺寸）时，一个像素会跨越多个步长，如何将该像素的强度在各积分步长之间进行分配。

软件计算划分各步长的直线与像素之间的交点，并通过求出每个步长内所含的像素面积来分配强度。为处理像素并非恰好为正方形的情形——由于 IP 倾斜或像素形状畸变——软件依次计算每个像素四个角的坐标以确定其四边形形状。原则上，无论步长设得多小，这都能使像素强度平滑地分配到各步长上。

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

该算法不仅用于普通的角度–强度积分 (Concentric Integration)，也用于沿圆周的积分 (Radial Integration) 和展开图像的计算 (Unrolled Image)。
