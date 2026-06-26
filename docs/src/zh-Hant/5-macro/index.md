<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer 提供**巨集**功能，可使用類 Python 的腳本自動執行一連串操作。對於重複性工作非常實用，例如大量檔案的批次一維化、格式轉換以及方位角分割分析。

## Opening the editor

從主視窗的 **Macro** 選單 → **Editor** 開啟巨集編輯器。您可以在其中編輯程式碼並執行，也包含逐步執行。

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Language

- 可使用 `for` / `if` / `while` / `def` / `class` 等控制陳述式，以及算術運算。
- `math` 模組已預先匯入，因此您不需要 `import` 陳述式即可直接使用 `math.pi` 或 `math.sin(...)`。
- 無法使用 `print()`。若要檢視數值，請使用**逐步執行**（Step by step），並在除錯面板中觀察變數的變化。
- 每個 IPAnalyzer 操作都是從 `IPA` 根物件下的命名空間呼叫（例如 `IPA.File`）。

## IPA namespaces

| Namespace | Role |
|------|------|
| `IPA.File` | 讀取/寫入影像、參數與遮罩檔案；檔案選擇對話框 |
| `IPA.Wave` | 設定入射源與波長 |
| `IPA.Detector` | 設定偵測器幾何：中心、相機長度、像素尺寸、傾斜 |
| `IPA.Image` | 控制顯示比例、對比與檢視區域 |
| `IPA.Mask` | 遮蔽斑點 (spot) 與區域 |
| `IPA.Profile` | 執行一維化（Get Profile）並設定儲存/傳送 |
| `IPA.IntegralProperty` | 設定同心 / 徑向積分的範圍、步距與單位 |
| `IPA.Sequential` | 選擇 / 平均 / 鎖定多影格影像的影格 |
| `IPA.PDI` | 呼叫 PDIndexer 上的巨集（剪貼簿整合） |

成員清單請參閱 [Built-in functions](1-built-in-functions.md)，具體腳本請參閱 [Examples](2-examples.md)。

!!! tip "編輯器內建說明為權威參考"
    每個函式/屬性的說明會顯示在巨集編輯器的說明中，那是最新的、隨版本追蹤的真實依據。若本頁與編輯器內建說明有出入，請以後者為準。

## Sample macros

當編輯器的已儲存巨集清單為空時，會自動插入範例巨集（基本迴圈、數學函式、幾何設定、批次處理、方位角分割、遮蔽、傳送至 PDIndexer 等）。它們是便於調整改用的入門起點。

## Working with Auto Procedure

您撰寫的巨集可以依名稱儲存，也可以從 [Auto Procedure](../3-tools.md) 的「execute after loading」清單呼叫，如此一來實驗期間每張到達的影像都會自動套用該巨集。
