<!-- 260601Cl: Reflected from ja/0-overview.md (lead language: Japanese). -->

# 概觀

IPAnalyzer 能將以成像板 (IP) 或 CCD/CMOS 偵測器記錄的 Debye–Scherrer 環，高精度且快速地轉換為一維繞射曲線。其設計與功能以日本產業技術綜合研究所 (AIST) 的藤久裕司所開發的 PIP 為範本。

主要功能：

- 支援多種影像格式（FujiBAS2000/2500、R-AXIS4/5、ITEX、Bruker CCD、IP Display、IPAimage、Fuji FDL、Rayonix、Mar research、Perkin Elmer、ADSC、RadIcon，以及一般影像格式）
- X 射線、電子與中子射源
- 與 PDIndexer 整合
- 量測參數的半自動分析

## 系統需求與安裝

### 需求

- 作業系統：Windows（建議使用 Windows 11）
- 必要執行階段：.NET Desktop Runtime 10.0
- 建議記憶體：16 GB 以上
- 建議 CPU：8 核心以上

本軟體內部大量使用多執行緒運算，因此核心數較多的 CPU 執行起來更為順暢。影像強度在內部以雙精度浮點數值保存。

本軟體依 MIT License 散布。

### 安裝

1. 請先安裝 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0)。
2. 從 GitHub [releases page](https://github.com/seto77/IPAnalyzer/releases) 下載 `IPAnalyzerSetup.msi`。
3. 執行 `IPAnalyzerSetup.msi` 進行安裝。

## 座標軸方向、IP 傾斜與像素形狀

IPAnalyzer 採用右手座標系，原點與各軸方向定義如下。

- X 射線或電子束與 IP 相交之處（直接點，direct spot）定義為原點 (0, 0, 0)，Z 軸與束流方向一致。
- 將試料尺寸視為無限小，試料位置與原點之間的距離定義為相機長度（Camera Length, CL）。因此試料位於 \((0,\ 0,\ -\mathrm{CL})\)。
- 當 IP 未傾斜時，X 軸與 IP 讀取雷射的掃描方向一致。因此 Y 軸在畫面上指向下方。
- IP 傾斜以繞著一條位於 XY 平面內、通過原點的直線之旋轉來表示：繞著與 X 軸成 \( \varphi \) 角的直線旋轉 \( \tau \)。
- 像素形狀以由 PixSizeX、PixSizeY 與 \( \xi \) 所描述的平行四邊形來處理。\( \xi \) 不為零意味著 IP 讀取雷射掃描的起始位置存在偏移。本軟體假設此偏移沿 Y 軸為定值。

<!-- TODO(figure): Coordinate axes (X / Y / Z) definition diagram. Equivalent to legacy doc image040.png / image041.png. To be recreated against the current GUI. -->

相機長度、\( \varphi \)、\( \tau \)、像素尺寸與 \( \xi \) 是在屬性視窗的 IP Condition 分頁中設定（參見 [2. Property Windows](2-property-windows.md)）。

### 與 (WIN)PIP 的關係

在 IPAnalyzer 中，X 軸（IP 影像的向右方向）順時針旋轉 \( \varphi \)，所得之軸再旋轉 \( \tau \)。在 PIP 中，Y 軸（IP 影像的向下方向）逆時針旋轉 \( \beta \)，所得之軸再旋轉 \( \Phi \)。因此，若要將 PIP 的 \((\beta,\ \Phi)\) 轉換為 IPAnalyzer 的 \((\varphi,\ \tau)\)，請使用 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\)。

## 像素強度積分方法

一維化的核心問題在於：當角度步進間隔小於像素間隔（即像素尺寸）時，會出現跨越數個步進的像素，而如何將此像素的強度分配至各積分步進。

本軟體會計算劃分各步進的直線與像素之間的交點，並藉由求出各步進內所含的像素面積來分配強度。為了處理像素並非恰為正方形的情形——因 IP 傾斜或像素形狀失真所致——會依序計算各像素四個角的座標，以決定其四邊形形狀。原則上，這使得不論步進設得多小，像素強度都能平滑地分配至各步進。

<!-- TODO(figure): Schematic of step-boundary lines, pixel intersections, and area distribution. Equivalent to legacy doc image042.png. To be recreated. -->

此演算法不僅用於一般的角度–強度積分（Concentric Integration），也用於沿周向的積分（Radial Integration）以及展開影像的運算（Unrolled Image）。
