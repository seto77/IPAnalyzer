<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 巨集

IPAnalyzer 提供 **巨集** 功能，可使用類 Python 的腳本自動執行一連串操作。對於重複性工作非常實用，例如將大量檔案批次積分為一維曲線、格式轉換以及方位角分割分析。

## 開啟編輯器

從主視窗的 **巨集 (Macro)** 選單 → **編輯器 (Editor)** 開啟巨集編輯器。您可以在其中編輯程式碼並執行，也包含逐步執行。

![巨集編輯器](../../assets/cap-en-auto/FormMacro.png)

## 語言

- 可使用 `for` / `if` / `while` / `def` / `class` 等控制陳述式，以及算術運算。
- `math` 模組已預先匯入，因此不需要 `import` 陳述式即可直接使用 `math.pi` 或 `math.sin(...)`。
- 無法使用 `print()`。若要檢視數值，請使用 **逐步執行**（Step by step），並在除錯面板中觀察變數的變化。
- 每個 IPAnalyzer 操作都是從 `IPA` 根物件下的命名空間呼叫（例如 `IPA.File`）。

## IPA 命名空間

| 命名空間 | 用途 |
|------|------|
| `IPA.File` | 讀取／寫入影像、參數與遮罩檔案；檔案選擇對話框 |
| `IPA.Wave` | 設定入射射源與波長 |
| `IPA.Detector` | 設定偵測器幾何：中心、相機長度、像素尺寸、傾斜 |
| `IPA.Image` | 控制顯示比例、對比與檢視區域 |
| `IPA.Mask` | 遮蔽斑點與區域 |
| `IPA.Profile` | 積分影像（取得圖譜 (Get Profile)）並設定儲存／傳送 |
| `IPA.IntegralProperty` | 設定同心／徑向積分的範圍、步進與單位 |
| `IPA.Sequential` | 多影格影像的影格選取／平均／積分對象 |
| `IPA.PDI` | 呼叫 PDIndexer 上的巨集（剪貼簿整合） |

成員清單請參見[內建函式](1-built-in-functions.md)，具體腳本請參見[範例](2-examples.md)。

!!! tip "編輯器內建說明為權威參考"
    每個函式／屬性的說明會顯示在巨集編輯器的說明中，那是隨版本更新的最新權威來源。若本頁與編輯器內建說明有出入，請以後者為準。

## 範例巨集

在編輯器中開啟 **顯示範例 (Show samples)**，即可列出唯讀的範例巨集（基本迴圈、數學函式、幾何設定、批次處理、方位角分割、遮罩、傳送至 PDIndexer 等）；關閉後會回到您自己儲存的巨集。它們是便於修改沿用的入門起點。

## 與自動程序搭配使用

您撰寫的巨集可以依名稱儲存，也可以從[自動程序 (Auto Procedure)](../3-tools.md) 執行（在 **巨集 (Macro)** 中選擇它並勾選 **Execute macro**），如此一來，實驗期間每張送入的影像都會自動套用該巨集。
