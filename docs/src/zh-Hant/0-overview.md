<!-- 261124Cl: Retranslated from en/0-overview.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 概觀

IPAnalyzer 能將以成像板 (IP) 或 CCD/CMOS 偵測器記錄的 Debye–Scherrer 環，高精度且快速地轉換為一維 (1D) 繞射曲線。其設計與功能以日本產業技術綜合研究所 (AIST) 的藤久裕司 (Hiroshi Fujihisa) 所開發的 PIP 為範本。

主要功能：

- 支援多種影像格式（FujiBAS2000/2500、R-AXIS4/5、ITEX、Bruker CCD、IP Display、IPAimage、Fuji FDL、Rayonix、Mar research、Perkin Elmer、ADSC、RadIcon、Rigaku RINT-RAPID II、SMV、MRC、Digital Micrograph 3/4、NeXus（`.nxs`），以及一般影像格式）
- X 射線、電子與中子射源
- 與 PDIndexer 整合
- 量測參數的半自動分析

## 系統需求與安裝

### 需求

以下需求適用於由此原始碼樹建置的 .NET 11 版本。對於已發布的版本，請遵循該版本所註明的執行階段需求。

- 作業系統：Windows（建議使用 Windows 11）
- 必要執行階段：.NET Desktop Runtime 11.0
- 建議記憶體：16 GB 以上
- 建議 CPU：8 核心以上

本軟體內部大量使用多執行緒運算，因此核心數較多的 CPU 執行起來更為順暢。影像強度在內部以雙精度浮點數值保存。

本軟體依 MIT License 散布。

### 安裝

1. 從 GitHub 的 [releases 頁面](https://github.com/seto77/IPAnalyzer/releases/latest) 下載符合您電腦的檔案。
    - `IPAnalyzer-setup.msi`：適用於一般 (x64) Windows 電腦的安裝程式（建議）。`IPAnalyzerSetup.msi` 內容相同；保留此名稱是為了讓舊版能自動更新。
    - `IPAnalyzer-setup_arm64.msi`：適用於 Windows on Arm 的安裝程式。
    - `IPAnalyzer-v.<version>.zip` / `IPAnalyzer-v.<version>_arm64.zip`：可攜版（免安裝，已內含 .NET 執行階段），適用於沒有系統管理員權限的電腦。
2. 若使用安裝程式，請事先安裝 [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0)，再執行下載的 `.msi`。
3. 若使用可攜版，請將 ZIP 解壓縮到使用者可寫入的資料夾，再執行 `IPAnalyzer.exe`（請勿從 ZIP 檢視器內直接啟動）。

## 座標軸方向、IP 傾斜與像素形狀

IPAnalyzer 採用右手座標系，原點與各軸方向定義如下。

- X 射線或電子束與 IP 相交之處（直射點，direct spot）定義為原點 (0, 0, 0)，Z 軸與束流方向一致。
- 將試料尺寸視為無限小，試料位置與原點之間的距離定義為相機長度（Camera Length, CL）。因此試料位於 \((0,\ 0,\ -\mathrm{CL})\)。
- 當 IP 未傾斜時，X 軸與 IP 讀取雷射的掃描方向一致。因此 Y 軸在畫面上指向下方。
- IP 傾斜以繞著一條位於 XY 平面內、通過原點的直線之旋轉來表示：繞著與 X 軸成 \( \varphi \) 角的直線旋轉 \( \tau \)。
- 像素形狀以由 PixSizeX、PixSizeY 與 \( \xi \) 所描述的平行四邊形來處理。\( \xi \) 不為零，表示 IP 讀取雷射掃描的起始位置存在偏移。本軟體假設此偏移沿 Y 軸為定值。

相機長度、\( \varphi \)、\( \tau \)、像素尺寸與 \( \xi \) 是在屬性視窗的 **偵測器條件 (Detector condition)** 分頁中設定（參見 [2. 屬性視窗](2-property-windows.md)）。

### 與 (WIN)PIP 的關係

在 IPAnalyzer 中，X 軸（IP 影像的向右方向）順時針旋轉 \( \varphi \)，再繞所得之軸旋轉 \( \tau \)。在 PIP 中，Y 軸（IP 影像的向下方向）逆時針旋轉 \( \beta \)，再繞所得之軸旋轉 \( \Phi \)。因此，若要將 PIP 的 \((\beta,\ \Phi)\) 轉換為 IPAnalyzer 的 \((\varphi,\ \tau)\)，請使用 \((\beta,\ \Phi) \rightarrow (270^\circ - \beta,\ \Phi)\)。

## 像素強度積分方法

影像積分的核心問題在於：當一個像素所涵蓋的散射角範圍跨越不只一個 2θ 步進時（步進越細越常發生），如何將這個跨越數個步進之像素的強度分配至各積分步進。

本軟體會計算劃分各步進的直線與像素之間的交點，並求出各步進內所含的像素面積來分配強度。為了處理像素並非恰為正方形的情形——因 IP 傾斜或像素形狀畸變所致——會依序計算各像素四個角的座標，以決定其四邊形形狀。原則上，這使得不論步進設得多小，像素強度都能平滑地分配至各步進。

此演算法不僅用於一般的角度–強度積分（同心積分，Concentric Integration），也用於沿圓周方向的積分（徑向積分，Radial Integration）以及展開影像的運算（Unrolled Image）。
