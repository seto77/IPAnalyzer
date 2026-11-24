<!-- 261124Cl: Retranslated from en/index.md (UI labels follow the localized GUI). -->

# IPAnalyzer 手冊

## 簡介

* **IPAnalyzer** 是採用 MIT 授權的免費軟體，可將以成像板 (IP) 或 CCD/CMOS 平板偵測器記錄的二維粉末繞射影像（Debye–Scherrer 環）轉換為高精度的一維 2θ–強度曲線。
* 它能從標準物質的繞射環校正量測幾何——相機長度、波長、偵測器傾斜與像素形狀——支援 X 射線、電子與中子射源，並可與 [PDIndexer](https://github.com/seto77/PDIndexer) 整合以進行後續的峰分析。
* 其設計與功能沿襲日本產業技術綜合研究所 (AIST) 的藤久裕司 (Hiroshi Fujihisa) 所開發的 *PIP*。

## 依目標尋找

| 目標 | 從這裡開始 | 主要後續步驟 |
|------|------------|-----------------|
| 了解座標系與幾何 | [概觀](0-overview.md) | [屬性視窗](2-property-windows.md) |
| 載入影像並取得一維曲線 | [操作步驟](4-procedures.md) | [主視窗](1-main-window.md)、[屬性視窗](2-property-windows.md) |
| 校正相機長度／波長 | [操作步驟](4-procedures.md) | [工具](3-tools.md)、[尋找參數（暴力搜尋）](6-find-parameter.md) |
| 遮蔽斑點／處理多影格資料 | [工具](3-tools.md) | [操作步驟](4-procedures.md) |
| 自動化處理 | [巨集](5-macro/index.md) | [內建函式](5-macro/1-built-in-functions.md)、[範例](5-macro/2-examples.md)、[自動程序 (Auto Procedure)](3-tools.md) |
| 疑難排解與常見問題 | [Q&A](7-qa.md) | [GitHub Issues](https://github.com/seto77/IPAnalyzer/issues) |

## 功能特色

* **廣泛的格式支援**：Fuji BAS2000/2500/FDL、Rigaku R-AXIS IV/V、ITEX、Bruker CCD、Rayonix、MAR research、Perkin Elmer、ADSC、RadIcon、Rigaku RINT-RAPID II、SMV、MRC、NeXus（`.nxs`）、Digital Micrograph 3/4，以及一般影像格式。大多數的檔案輸入／輸出皆支援拖放。
* **影像轉曲線**：同心（徑向平均）積分、徑向（方位角／cake）積分與展開影像運算，採用次像素面積分配演算法，能正確處理偵測器傾斜與平行四邊形的像素形狀。
* **幾何校正**：以幾何法（雙卡匣法）精修波長、相機長度、像素尺寸／畸變與傾斜 (φ, τ)，並針對難以收斂的資料提供網格暴力搜尋。
* **影像處理**：自動偵測束流中心、單晶斑點 (spot) 的偵測與遮蔽、周向模糊、圓環疊加、R-AXIS 影像的強度校正，以及保留幾何資訊的 IPA 儲存。
* **多影格資料**：對 NeXus（`.nxs`）、多頁 TIFF 及其他序列資料挑選、平均或加總影格；若影格帶有能量資訊，選取該影格時會更新波長。
* **自動化**：監看資料夾的自動程序 (Auto Procedure)，以及採用 Python 語法的[巨集](5-macro/index.md)，可用於批次與腳本化處理。
* **PDIndexer 整合**：透過剪貼簿將曲線傳送至 [PDIndexer](https://github.com/seto77/PDIndexer)，並可在該處觸發具名巨集。

## 系統需求

以下需求適用於由此原始碼樹建置的 .NET 11 版本。對於已發布的版本，請遵循該版本所註明的執行階段需求。

| 項目 | 最低需求 | 建議需求 |
|------|---------|-------------|
| OS | 可執行 [.NET Desktop Runtime 11.0](https://dotnet.microsoft.com/download/dotnet/11.0) 的 Windows | Windows 11 |
| 記憶體 | - | 16 GB 以上 |
| CPU | - | 8 核心以上（影像強度以雙精度保存，且處理採多執行緒） |

## 快速開始

1. 從 [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) 下載並安裝。
2. 讀取一張繞射影像（**檔案 (File) → 讀取影像 (Read image)**，或拖放）。
3. 在屬性視窗中設定 **波源 (Wave source)** 與 **偵測器條件 (Detector condition)**（相機長度、像素尺寸、概略中心）。
4. 若幾何（相機長度、波長、傾斜）未知，請先從標準試料的影像加以校正並套用所得的值——參見[操作步驟](4-procedures.md)。
5. 在試料影像上尋找中心，必要時遮蔽斑點，然後按下 **取得圖譜 (Get Profile)** 以取得一維曲線。

完整工作流程請參見[操作步驟](4-procedures.md)。

## 如何使用本手冊

此 GitHub Pages 手冊為目前的權威來源。請使用左側導覽列依章節瀏覽，或使用標頭中的搜尋來尋找函式名稱或 UI 標籤。它取代了過去隨 `IPAnalyzer/doc/` 散布的舊版 Word/HTML/PDF 手冊。

## 授權

IPAnalyzer 以 [MIT License](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md) 散布。
