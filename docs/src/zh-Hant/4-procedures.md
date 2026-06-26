<!-- 260601Cl: Reflected from ja/4-procedures.md (lead language: Japanese). -->

# 操作步驟

本頁說明典型作業的流程。各項工具的說明請參見 [Tools](3-tools.md)。

## 基本流程（同心積分）

1. **載入影像**：File → Read image（或拖放）。
2. **設定光源**：在屬性中的 **Wave source** 下設定元素／躍遷或波長。
3. **設定偵測器條件**：在 **Detector condition** 下設定相機長度、像素尺寸、中心位置（概略值），必要時設定傾斜 φ、τ。
4. **尋找中心**：以工具列上的 **Find Center** 自動偵測束流中心（搜尋範圍在 Miscellaneous 下設定）。
5. **遮罩斑點**：以 **Mask Spots** 移除單晶反射等。必要時以 **Manual** 手動遮罩。
6. **一維化**：以 **Get Profile** 取得曲線。儲存與傳送在 **After "Get Profile"** 標籤頁中設定（CSV 儲存、傳送至 PDIndexer 等）。

對於序列影像，請在步驟 5–6 之前於 [Sequential](3-tools.md) 中選取影格。若要進行逐方位角分析，請使用 **Integral Property** 中的 Radial integration。

## 參數決定：以標準試樣進行幾何校正（double cassette）

當相機長度或波長未知時，可使用 [Find Parameter (Geometric)](3-tools.md)，從標準物質（預設為 CeO2 等）的繞射環最佳化幾何參數。

1. 以 Open 載入 **Primary image**（標準試樣，於某一相機長度），尋找中心，並以 **Get Profile** 顯示波峰。
2. 在 Profile View 中拖曳繞射線標記，會自動更新相機長度估計值。
3. 以相同方式載入 **Secondary image**（相同標準試樣，於不同相機長度），並輸入相對於 Primary 的**相機長度差值**。
4. 在 **Peak List** 中，選取在兩張影像中皆出現之波峰的 d 值（每張影像至少一個，最好三個以上）。
5. 在 **Refinement Option** 下，選擇要最佳化的參數（波長、底片距離、傾斜、像素尺寸、像素畸變）。
6. 執行 **Refine!**，待殘差穩定後，將最佳化結果複製回主表單。

!!! note
    使用兩張影像（「double cassette」）可更容易分別決定相機長度與波長。

## 參數決定：暴力搜尋最佳化（任意試樣）

當幾何最佳化難以收斂時，可使用 [Find Parameter (Brute force)](3-tools.md) 對相機長度與波長進行窮舉搜尋。詳細的圖解操作說明請參見 [Find Parameter (brute force)](6-find-parameter.md)。

1. 載入 Primary 與 Secondary 影像（兩張影像，具有共同環，於不同相機長度）。
2. 在主表單中大致對齊中心位置（Find Center 有助於此）。
3. 為相機長度、波長等輸入**搜尋範圍（min、max、step）**。對於未知參數（像素尺寸、傾斜）一開始先關閉。
4. 將 **Integral Region** 設為帶寬較窄的狹縫（Rectangle）模式，有助於抑制雜訊。
5. 開始搜尋，並將殘差最小的組合複製回主表單。

## 自動化處理（Auto Procedure）

例如在實驗進行中，自動處理抵達資料夾的影像。詳情請參見 [Tools](3-tools.md)。

1. 啟用 **Automatically load new images**，並以 **Set** 選擇監看資料夾。
2. 必要時，可依 **number matching**（檔名結尾的數字）或 **keyword** 篩選檔案。
3. 啟用 **After Loading Image, Execute "Auto"**，並從清單中選擇：Auto Contrast / Find Center / Mask Spots / Get Profile / Execute Macro。
4. 監看開始後，每次有符合的影像抵達時，便會自動執行此序列。

## 指令稿化操作步驟（以 Python 為基礎的巨集）

含迴圈與條件式的處理可寫成[巨集](5-macro/index.md)。隨附的範例巨集是很好的起點。

- 載入影像、設定光源與偵測器（中心、相機長度、像素），並使顯示符合視窗。
- 設定同心積分條件（start、end、step、unit）、一維化，並儲存為 CSV。
- 批次處理多個檔案，並在每張影像旁儲存一個 CSV。
- 逐影格處理多影格影像。
- 將 Debye 環分割為 N 個扇區，並分析方位角相依性。
- 遮罩（全部清除 → 遮罩斑點 → 遮罩 beam-stop 區域 → 儲存遮罩）並一維化。
- 以徑向（cake）積分輸出方位角對強度。
- 啟用剪貼簿傳送、一維化，並呼叫 PDIndexer 中具名的巨集（例如波峰擬合）。

你撰寫的巨集可以儲存、依名稱呼叫，也可從 Auto Procedure 執行。
