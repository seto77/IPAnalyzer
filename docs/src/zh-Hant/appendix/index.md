<!-- 261124Cl: Retranslated from en/appendix/index.md (UI labels follow the localized GUI). -->

# 附錄

本附錄彙整 IPAnalyzer 在將二維繞射影像（Debye–Scherrer 環）轉換為高精度一維曲線時所使用的 **幾何與演算法的理論背景**。關於操作步驟與各功能的使用方式，請參見主手冊（[0. 概觀](../0-overview.md)、[4. 操作步驟](../4-procedures.md) 等）。在此以方程式說明其背後的座標系定義、座標轉換、參數決定方法以及積分演算法。

內容係根據隨發行套件附帶的舊版文件 `doc/IPAnalyzerAlgorithm.pdf` 以及目前的實作。

## 附錄的結構

- **[A1. 偵測器幾何與座標轉換](a1-geometry.md)** — 右手座標系的定義、描述 IP 傾斜 ($\varphi,\ \tau$) 的旋轉矩陣，以及像素形狀 ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$) 的校正。
- **[A2. 參數決定](a2-calibration.md)** — 使用標準物質校正相機長度、波長、像素尺寸與 IP 傾斜（雙距離法、雙譜線法、橢圓擬合）。
- **[A3. 影像積分](a3-image-integration.md)** — 將像素強度分配至各角度步進的面積分割演算法。
- **[A4. 對稱性資訊](a4-symmetry-information.md)** — 標準晶體的空間群對稱性、幾何計算、Wyckoff 位置、繞射條件，以及對稱元素圖（Crystal 視窗的子視窗）。
- **[A5. 散射因子](a5-scattering-factor.md)** — 標準晶體的結構因子與繞射清單（X 射線、電子、中子）（Crystal 視窗的子視窗）。

## 座標系（共通參考圖）

以下各頁均以相同的座標系作為共通前提。原點為 IP 上的直射點（束流與 IP 相交之點），$Z$ 軸為束流的行進方向，試料位於 $(0,\ 0,\ -\mathrm{CL})$。

![IPAnalyzer 的座標系。圖中顯示 IP（成像板）、X / Y / Z 軸、Debye 環、傾斜角 φ 與 τ、位於 (0,0,−CL) 的試料、相機長度 CL、繞射角 2θ、波長 λ，以及像素形狀（PixSizeX、PixSizeY、ξ）。](../../assets/references/geometry-coordinate-system.png){width=520px}

## 主要參數

| 符號 | 名稱 | 意義 |
|------|------|------|
| $\lambda$ | 波長 (Wave Length) | 射源的波長。特性 X 射線的波長為已知；同步輻射的波長則隨單光器的位置而變化，必須每次決定。 |
| $\mathrm{CL}$ | 相機長度 (Camera Length) | 試料與原點（直射點）之間的距離。試料位置為 $(0,0,-\mathrm{CL})$。對應畫面上的 **相機長度 1 (Camera Length 1)**；**相機長度 2 (Camera Length 2)** 則是試料至偵測器的垂直距離，在有傾斜 $\tau$ 時兩者不同。 |
| $\varphi,\ \tau$ | 傾斜校正 (Tilt Correction) | IP 相對於光軸（$Z$ 軸）的傾斜。$\varphi$ 為傾斜軸在 XY 平面內的方位角，$\tau$ 為繞該軸的旋轉角。 |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | 像素大小 (Pixel Size) | 將像素表示為平行四邊形。$\xi$ 為讀取雷射掃描起點的偏移（畸變角）。 |

波長在屬性視窗的 **波源 (Wave source)** 分頁中設定，相機長度、傾斜與像素形狀則在 **偵測器條件 (Detector condition)** 分頁中設定（參見 [2. 屬性視窗](../2-property-windows.md)）。
