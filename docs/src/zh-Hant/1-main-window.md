<!-- 260601Cl: Reflected from ja/1-main-window.md (lead language: Japanese). -->

# 主視窗

主視窗是 IPAnalyzer 啟動時最先顯示的畫面。它整合了已載入繞射影像的顯示、主要操作（尋找中心、遮蔽斑點、一維化），以及偵測器參數設定的進入點。

此視窗大致由頂部的選單與工具列、中央的影像顯示區、右側的垂直工具列，以及底部的圖表區所構成。

![The IPAnalyzer main window](../assets/cap-en-auto/FormMain.png)

## 中央檢視區

### 影像顯示

已載入的影像會顯示於此。依照滑鼠指標的位置，影像上方的區域會顯示實際座標 (mm)、影像座標 (pix)、距中心的距離 R (mm)、散射角 2θ、d 值、方位角 χ 及強度。洋紅色的 × 標記代表直射斑點（中心）位置。

像素狀態會以不同顏色顯示。

| 顏色 | 意義 |
| --- | --- |
| Cyan | 已遮蔽的斑點 |
| Green | 排除於積分之外的區域（於 Integral Region 中設定） |
| Magenta | 排除於積分之外的角度區域（於 Integral Property 中設定） |
| Blue | 低於強度閾值的像素（於 Integral Region 中設定） |
| Red | 高於強度閾值的像素 |

### 滑鼠操作

於一般模式下：

- 按住左鍵：搜尋附近的斑點中心。
- 左鍵雙擊：將中心位置更新至點擊處。
- 右鍵拖曳：放大拖曳的區域。
- 右鍵點擊：縮小。

於 **Manual spot mode** 下，左鍵點擊進行遮蔽，右鍵點擊解除遮蔽。遮罩的形狀與大小可於工具列及屬性中設定。

### 輔助檢視與影像資訊

中央檢視區旁有輔助顯示。您可在 **Whole image** 與 **Near center** 之間切換：whole-image 檢視會以黃色邊框標示目前的顯示範圍，near-center 檢視則顯示放大的影像。

**Image Information** 會顯示影像解析度、最大強度、總強度、標頭資料等。

### 顯示調整控制項

調整影像呈現方式的控制項：

- **Gradient**：反轉色調。
- **Brightness scale**：對數 / 線性。
- **Color scale**：灰階 / 彩色。
- **Scale line**：刻度線顯示（無 / 粗 / 中 / 細）。
- **Auto Contrast** / **Reset Contrast**，以及明確指定的最小 / 最大強度。
- 放大倍率按鈕（×1, ×2, ×4, ×1/2, ×1/4, ×1/8, ×1/16）。

## 下方檢視區

底部區域有三個分頁的圖表 / 檢視。

- **Frequency of Intensity**：所有像素的強度分布，以對數–對數軸顯示。可用滑鼠縮放。
- **Converted Profile**：一維化（Get Profile）後的繞射曲線。可用滑鼠縮放。
- **Statistical Information**：選定矩形區域 (X1,Y1)–(X2,Y2) 的統計資訊。載入序列影像時，亦可比較其他影格中相同區域的統計資訊。

## 選單

選單列由 **File / Tool / Property / Option / Language / Macro / Help** 構成。

### File

- **Read image**：開啟繞射影像。支援的格式請參閱 [Overview](0-overview.md)。
- **Save image**：儲存為 TIFF、PNG、CSV 或 IPA 格式。TIFF 保留原始像素強度，PNG 保留顯示狀態（亮度、對比、遮罩），IPA 則為經失真校正的專有格式（含中繼資料）。
- **Read / Save parameter**：將波長、相機長度、像素尺寸、傾斜校正、中心位置等以 `.prm` 檔匯入／匯出。
- **Read / Save / Clear mask**：將遮罩以 `.mas` 檔匯入／匯出，或清除之（遮罩必須與目前影像的解析度相符）。
- **Close**。

影像、參數及遮罩檔亦可透過拖放至視窗來載入。

### Tool

- **Reset Frequency Profile**：清除強度頻率圖（影像會保留）。
- **Calibrate Raxis Image**。

### Property

Wave Source / Imaging Plate Condition / Integral Region / Integral Property / Manual Mask Mode / After "Get Profile" / Unrolled Image Option / Miscellaneous。這些會直接開啟[屬性視窗](2-property-windows.md)的對應分頁。

### Option

- **ToolTip**：切換按鈕與選單上的工具提示。
- **Flip**：水平／垂直。**Rotate**：選擇旋轉角度。兩者僅影響顯示；已載入的影像資料本身不會改變。
- **Ngen Compile** 與 **Clear registry** 用於開發及疑難排解。

### Language

- 於 **English** 與 **Japanese** 之間切換（此設定會儲存於登錄檔）。

### Macro

- **Editor**：開啟巨集編輯器（參閱 [Tools](3-tools.md) / [Macro](5-macro/index.md)）。

### Help

- **Program Updates**、**Hint**、**License**、**Version History**、**Web Page**。

## 操作工具列

主要的影像處理操作（下拉選單中提供詳細選項）：

- **Background**：減去背景影像（於 Background Option 中設定）。
- **Find Center**：以二維 Pseudo-Voigt 擬合偵測束流中心（搜尋範圍預設為 8 px，於 Miscellaneous 中設定）。下拉選單亦提供以圓環為基礎的中心偵測。
- **Fix center**：固定中心位置。
- **Mask Spots**：以「平均值 ± 標準差 × Deviation」為準則偵測並遮蔽斑點。下拉選單包含 mask-all、inverse-mask、manual 等。
- **Manual**：手動遮罩模式。您可選擇形狀（circle / rectangle）與大小（8–256 px）。
- **Get Profile**：將影像積分為一維曲線。支援 Concentric（以 2θ 為基準）與 Radial（以方位角為基準）。下拉選單可設定 Integral Property/Region 的選擇、積分前是否尋找中心並遮蔽斑點、傳送至 PDIndexer、方位角分割分析、序列影像處理等。

## 工具列（其他工具）

右側的垂直工具列可啟動各種工具。詳情請參閱 [Tools](3-tools.md)。

- **Intensity Table**
- **Auto Procedure**
- **Draw ring**
- **Find parameter** / **Find parameter (brute force)**
- **Unroll**
- **Circumferential Blur**
- **Sequential**
