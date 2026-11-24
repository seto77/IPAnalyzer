<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 概述

IPAnalyzer 可将成像板 (IP) 或 CCD/CMOS 探测器记录的 Debye–Scherrer 环高精度、高速地转换为一维衍射谱线。其设计与功能仿照了日本产业技术综合研究所 (AIST) 的 Hiroshi Fujihisa 开发的 PIP。

主要功能：

- 支持多种图像格式（FujiBAS2000/2500、R-AXIS4/5、ITEX、Bruker CCD、IP Display、IPAimage、Fuji FDL、Rayonix、Mar research、Perkin Elmer、ADSC、RadIcon、Rigaku RINT-RAPID II、SMV、MRC、Digital Micrograph 3/4、NeXus (`.nxs`) 以及通用图像格式）
- 支持 X 射线、电子和中子源
- 与 PDIndexer 联动
- 测量参数的半自动解析

## 系统要求与安装

### 系统要求

以下要求适用于由本源代码树构建的 .NET 11 版本。对于已发布的版本，请遵循该版本所注明的运行时要求。

- OS：Windows（推荐 Windows 11）
- 所需运行时：.NET Desktop Runtime 11.0
- 推荐内存：16 GB 以上
- 推荐 CPU：8 核以上

软件内部大量使用多线程计算，因此核数越多的 CPU 运行越流畅。图像强度在内部以双精度浮点数保存。

本软件以 MIT 许可分发。

### 安装

1. 从 GitHub 的[发布页面](https://github.com/seto77/IPAnalyzer/releases/latest)下载与您的电脑相符的文件。
    - `IPAnalyzer-setup.msi`：适用于普通 (x64) Windows 电脑的安装程序（推荐）。`IPAnalyzerSetup.msi` 与之相同；保留该名称是为了让旧版本能够自动更新。
    - `IPAnalyzer-setup_arm64.msi`：适用于 Windows on Arm 的安装程序。
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`：便携版（无需安装，已附带 .NET 运行时），适用于没有管理员权限的电脑。
2. 使用安装程序时，请事先安装 [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0)，然后运行下载的 `.msi`。
3. 使用便携版时，请将 ZIP 解压到用户可写入的文件夹，然后运行 `IPAnalyzer.exe`（不要在 ZIP 查看器中直接启动）。

## 坐标轴方向、IP 倾斜与像素形状

IPAnalyzer 使用右手坐标系，原点和坐标轴方向定义如下。

- X 射线或电子束与 IP 相交的点（直射斑点）定义为原点 (0, 0, 0)，Z 轴与束流方向一致。
- 将样品尺寸视为无限小，样品位置与原点之间的距离定义为相机长度 (Camera Length, CL)。因此样品位于 \((0,\ 0,\ -\mathrm{CL})\)。
- X 轴与 IP 未倾斜时 IP 读取激光的扫描方向一致。因此 Y 轴在屏幕上指向下方。
- IP 倾斜表示为绕 XY 平面内通过原点的一条直线的旋转：绕与 X 轴成 \( \varphi \) 角的直线旋转 \( \tau \)。
- 像素形状视为由 PixSizeX、PixSizeY 和 \( \xi \) 描述的平行四边形。\( \xi \) 不为零表示 IP 读取激光扫描的起始位置存在偏移。本软件假定该偏移沿 Y 轴恒定。

相机长度、\( \varphi \)、\( \tau \)、像素尺寸和 \( \xi \) 在属性窗口的 **探测器条件 (Detector condition)** 选项卡中设置（参见 [2. 属性窗口](2-property-windows.md)）。

### 与 (WIN)PIP 的关系

在 IPAnalyzer 中，先将 X 轴（IP 图像的向右方向）顺时针旋转 \( \varphi \)，再绕所得的轴旋转 \( \tau \)。在 PIP 中，先将 Y 轴（IP 图像的向下方向）逆时针旋转 \( \beta \)，再绕所得的轴旋转 \( \Phi \)。因此，要将 PIP 的 \((\beta,\ \Phi)\) 换算为 IPAnalyzer 的 \((\varphi,\ \tau)\)，请使用 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\)。

## 像素强度的积分方法

对图像进行积分时的核心问题在于：当一个像素跨越多个积分步长时，如何把该像素的强度分配给各个步长——只要一个像素覆盖的散射角范围跨越一个以上的 2θ 步长（步长越细越常见），就会出现这种情况。

本软件计算划分各步长的分界线与像素的交点，并求出每个步长内所含的像素面积来分配强度。为了处理由于 IP 倾斜或像素形状畸变而导致像素并非严格正方形的情况，会逐一计算每个像素四个角的坐标以确定其四边形形状。原理上，无论步长取得多小，像素强度都能平滑地分配到各个步长中。

该算法不仅用于普通的角度–强度积分（同心积分 (Concentric Integration)），也用于沿圆周方向的积分（径向积分 (Radial Integration)）以及展开图像的计算（展开图像 (Unrolled Image)）。
