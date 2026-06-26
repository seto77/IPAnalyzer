<!-- 260602Cl: Reflected from ja/appendix/index.md (lead language: Japanese). -->

# 附錄

本附錄彙整 IPAnalyzer 在將二維繞射影像（Debye–Scherrer 環）轉換為高精度一維曲線時所使用的**幾何與演算法的理論背景**。關於操作步驟與各功能的使用方式，請參閱主手冊（[0. 概觀](../0-overview.md)、[4. 操作步驟](../4-procedures.md) 等）。在此，我們以方程式說明其背後的座標系定義、座標轉換、參數決定方法以及積分演算法。

內容係根據隨發行套件附帶的舊版文件 `doc/IPAnalyzerAlgorithm.pdf` 以及目前的實作。

## 附錄的結構

- **[A1. 偵測器幾何與座標轉換](a1-geometry.md)** — 右手座標系的定義、描述 IP 傾斜 ($\varphi,\ \tau$) 的旋轉矩陣，以及像素形狀的修正 ($\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$)。
- **[A2. 參數決定](a2-calibration.md)** — 使用標準物質校正相機長度、波長、像素尺寸與 IP 傾斜（雙距離法、雙線法、橢圓擬合）。
- **[A3. 影像積分](a3-image-integration.md)** — 將像素強度分配至各角度步階的面積分割演算法。
- **[A4. 對稱性資訊](a4-symmetry-information.md)** — 標準晶體的空間群對稱性、幾何計算、Wyckoff 位置、反射條件，以及對稱元素圖（Crystal 視窗的子視窗）。
- **[A5. 散射因子](a5-scattering-factor.md)** — 標準晶體的結構因子與反射清單（X 射線、電子、中子）（Crystal 視窗的子視窗）。

## 座標系（共通參考圖）

以下各頁均以相同的座標系作為共通前提。原點為 IP 上的直射斑點（束流與 IP 相交之點），$Z$ 軸為束流傳播方向，試樣位於 $(0,\ 0,\ -\mathrm{CL})$。

![Coordinate system of IPAnalyzer. It shows the IP (imaging plate), the X / Y / Z axes, the Debye rings, the tilt angles φ and τ, the sample at (0,0,−CL), the camera length CL, the diffraction angle 2θ, the wavelength λ, and the pixel shape (PixSizeX, PixSizeY, ξ).](../../assets/references/geometry-coordinate-system.png){width=520px}

## 主要參數

| Symbol | Name | 意義 |
|------|------|------|
| $\lambda$ | Wave Length | 光源的波長。對特性 X 射線為已知；對同步輻射則隨單光器位置而變化，必須每次決定。 |
| $\mathrm{CL}$ | Camera Length | 試樣與原點（直射斑點）之間的距離。試樣位置為 $(0,0,-\mathrm{CL})$。 |
| $\varphi,\ \tau$ | Tilt Correction | IP 相對於光軸（$Z$ 軸）的傾斜。$\varphi$ 為傾斜軸在 XY 平面內的方位角，$\tau$ 為繞該軸的旋轉角。 |
| $\mathrm{PixSizeX},\ \mathrm{PixSizeY},\ \xi$ | Pixel Size | 將像素表示為平行四邊形。$\xi$ 為讀取雷射掃描起點的偏移（畸變角）。 |

這些數值於屬性視窗的 IP Condition 分頁中設定（參閱 [2. 屬性視窗](../2-property-windows.md)）。
