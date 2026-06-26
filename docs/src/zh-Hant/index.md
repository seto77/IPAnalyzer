<!-- 260601Cl: Rewrote English home page into a richer landing page (Find by goal / Features / Quick start), modeled on the ReciPro manual home. -->
<!-- 260625Cl: Moved from docs/src/index.md to docs/src/en/index.md for the mkdocs-static-i18n folder-mode migration (en is the default locale, output at the site root). Internal links de-prefixed from en/<slug> to <slug>. -->

# IPAnalyzer 手冊

## 簡介

* **IPAnalyzer** 是採用 MIT 授權的免費軟體，可將以成像板 (IP) 或 CCD/CMOS 平板偵測器記錄的二維粉末繞射影像（Debye–Scherrer 環）轉換為高精度的一維 2θ–強度曲線。
* 它能從標準物質的繞射環校正量測幾何——相機長度、波長、偵測器傾斜與像素形狀——支援 X 射線、電子與中子射源，並可與 [PDIndexer](https://github.com/seto77/PDIndexer) 整合以進行後續的尖峰分析。
* 其設計與功能沿襲由 AIST 的 Hiroshi Fujihisa 所開發的 *PIP*。

## 依目標尋找

| 目標 | 從這裡開始 | 主要後續步驟 |
|------|------------|-----------------|
| 了解座標系與幾何 | [概觀](0-overview.md) | [屬性視窗](2-property-windows.md) |
| 載入影像並取得一維曲線 | [操作步驟](4-procedures.md) | [主視窗](1-main-window.md)、[屬性視窗](2-property-windows.md) |
| 校正相機長度／波長 | [操作步驟](4-procedures.md) | [工具](3-tools.md)、[尋找參數（暴力搜尋）](6-find-parameter.md) |
| 遮蔽斑點／處理多影格資料 | [工具](3-tools.md) | [操作步驟](4-procedures.md) |
| 自動化處理 | [巨集](5-macro/index.md) | [內建函式](5-macro/1-built-in-functions.md)、[範例](5-macro/2-examples.md)、[Auto Procedure](3-tools.md) |

## 功能特色

* **廣泛的格式支援**：Fuji BAS2000/2500/FDL、Rigaku R-AXIS IV/V、ITEX、Bruker CCD、Rayonix、MAR research、Perkin Elmer、ADSC、RadIcon、Rad-Xcam、HDF5/NeXus、Digital Micrograph 3/4，以及一般影像格式。大多數的檔案輸入／輸出皆支援拖放。
* **影像轉曲線**：同心（徑向平均）、徑向（方位角／cake）與展開影像運算，採用次像素面積分布演算法，能正確處理偵測器傾斜與平行四邊形的像素形狀。
* **幾何校正**：對波長、相機長度、像素尺寸／畸變與傾斜 (φ, τ) 進行幾何（雙卡匣）精修，並針對困難資料提供暴力網格搜尋。
* **影像處理**：自動束流中心偵測、單晶斑點 (spot) 偵測與遮蔽、周向模糊、圓環疊加、強度表偵測器校正，以及保留幾何資訊的 IPA 儲存。
* **多影格資料**：對 HDF5/NeXus 及其他序列資料挑選、平均或加總影格，並可從內嵌能量取得每影格的波長。
* **自動化**：資料夾監看的 Auto Procedure，以及採用 Python 語法的[巨集](5-macro/index.md)，可用於批次與腳本化處理。
* **PDIndexer 整合**：透過剪貼簿將曲線傳送至 [PDIndexer](https://github.com/seto77/PDIndexer)，並可在該處觸發具名巨集。
* **淺色／深色主題**：介面會依可選的淺色或深色色彩模式呈現。

## 系統需求

| 項目 | 最低需求 | 建議需求 |
|------|---------|-------------|
| OS | 安裝 [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) 的 Windows | Windows 11 |
| 記憶體 | - | 16 GB 以上 |
| CPU | - | 8 核心以上（影像強度以雙精度保存，且處理採多執行緒） |

## 快速開始

1. 從 [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 下載並安裝。
2. 讀取一張繞射影像（File → Read image，或拖放）。
3. 在屬性視窗中設定 **Wave source** 與 **Detector condition**（相機長度、像素尺寸、概略中心）。
4. 尋找中心，必要時遮蔽斑點，然後按下 **Get Profile** 以取得一維曲線。
5. 若幾何未知，請從標準物質進行校正——參見[操作步驟](4-procedures.md)。

完整工作流程請參見[操作步驟](4-procedures.md)。

## 如何使用本手冊

此 GitHub Pages 手冊為目前的權威來源。請使用左側導覽列依章節瀏覽，或使用標頭中的搜尋來尋找函式名稱或 UI 標籤。它取代了過去隨 `IPAnalyzer/doc/` 散布的舊版 Word/HTML/PDF 手冊。

## 授權

IPAnalyzer 以 [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) 散布。
