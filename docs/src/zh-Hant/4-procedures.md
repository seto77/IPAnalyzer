<!-- 261124Cl: Retranslated from en/4-procedures.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 操作步驟

本頁說明典型作業的流程。各工具的說明請參見[工具](3-tools.md)。

## 基本流程（同心積分）

1. **載入影像**：**檔案 (File) → 讀取影像 (Read image)**（或拖放）。
2. **設定射源**：在屬性的 **波源 (Wave source)** 中設定元素／躍遷或波長。
3. **設定偵測器條件**：在 **偵測器條件 (Detector condition)** 中設定相機長度、像素尺寸、中心位置（概略值），必要時也設定傾斜 φ、τ。
4. **尋找中心**：以工具列上的 **尋找中心 (Find Center)** 自動偵測束流中心（搜尋範圍在 **其他項目 (Miscellaneous)** 分頁中設定）。
5. **遮蔽斑點**：以 **遮罩斑點 (Mask Spots)** 去除單晶繞射點等。必要時以 **手動模式 (Manual Mode)** 手動遮罩。
6. **確認積分設定**：在 **積分區域 (Integral Region)** 中選擇對象區域，並在 **積分性質 (Integral Property)** 中選擇 **同心積分 (散射角色散) (Concentric integration (scattering angle dispersive))**，設定橫軸單位與 **開始 / 結束 / 步進 (Start / End / Step)**。
7. **積分影像**：以 **取得圖譜 (Get Profile)** 取得曲線。儲存與傳送在 **「取得圖譜」之後 (After "Get Profile")** 分頁中設定（CSV 儲存、傳送至 PDIndexer 等）。

對於連續影像，請在步驟 5–7 之前，先於[連續影像 (Sequential image)](3-tools.md) 中選取影格。若要依方位角進行分析，請使用 **取得圖譜** 下拉選單中的 **方位角分割分析 (Azimuthal Division Analysis)**（將圓環分割為扇形並逐一積分；僅限同心積分且橫軸為 **角度 (Angle)**（2θ）時可用），或 **積分性質** 中的 **徑向積分 (蛋糕圖樣) (Radial integration (cake pattern))**（方位角–強度曲線）。

若相機長度、波長或傾斜未知，請先依下一節的說明，從標準試料的影像加以校正並套用所得的值，再積分試料影像。

## 參數決定：以標準試料進行幾何校正（雙卡匣法）

當相機長度或波長未知時，使用[尋找參數（幾何法）(Find Parameter (Geometric))](3-tools.md)，從標準物質（預設為 CeO2 等）的繞射環最佳化幾何參數。

1. 以 **開啟 (Open)** 載入 **主要影像 (Primary image)**（標準試料，某一相機長度），尋找中心，並以 **取得圖譜 (Get Profile)** 顯示峰。
2. 在 Profile View 中拖曳繞射線標記，相機長度的估計值即會自動更新。
3. 以相同方式載入 **次要影像 (Secondary image)**（同一標準試料，不同的相機長度），並輸入 **相機長度差** \(\Delta L = L_\mathrm{Secondary} - L_\mathrm{Primary}\) (mm)（例如主要影像為 100 mm、次要影像為 120 mm 時輸入 +20）。次要影像為選用；只用主要影像也能進行校正。
4. 在 **峰清單 (Peak List)** 中，選取兩張影像中都出現的峰之 d 值（通常每張影像三個以上；使用兩張影像時，至少需有一個為兩者共通。除非只精修相機長度，否則少於三個時 **精修! (Refine!)** 不會執行任何動作）。
5. 選擇要最佳化的參數（**波長 (Wave Length)**、**相機長度 (Camera Length)**、**傾斜校正 (Tilt Correction)**、**像素大小 (Pixel Size)**、**像素畸變 (Pixel Distortion)**、**中心位置 (Center Position)**、**球面校正 (Spherical Correction)**）。
6. 執行 **精修!**。達到所設定的重複次數（預設 12 次）後會自動停止。確認結果後，以 **精修後參數 => 主視窗 (Refined parameters => Main form)** 將其複製到主視窗。

!!! note
    使用兩張影像（「雙卡匣」）可以更容易地將相機長度與波長分開決定。

## 參數決定：暴力最佳化（標準試料）

當幾何最佳化難以收斂時，請以[尋找參數（暴力法）(Find Parameter (Brute force))](3-tools.md) 對相機長度、中心位置、傾斜，以及可選的波長進行窮舉搜尋。含螢幕截圖的詳細解說請參見[尋找參數（暴力搜尋）](6-find-parameter.md)。

1. 在主視窗中載入一張標準試料影像，開啟 **尋找參數 (暴力法) (Find parameter (brute force))**，並選擇對應的標準物質。
2. 在主視窗中大致對準中心位置（**尋找中心 (Find Center)** 可協助對準）。
3. 選擇要最佳化的項目，並輸入步長 **初始步長 (Initial step)**（以目前值為中心）以及單側的步數（**搜尋範圍 (Search range)**）。對於平面偵測器，像素尺寸不是搜尋對象。數值範例請參見[尋找參數（暴力搜尋）](6-find-parameter.md)。
4. 將 **積分區域 (Integral Region)** 設為條帶寬度較窄的狹縫（**矩形 (Rectangle)**）模式，有助於抑制雜訊。
5. 以 **最佳化 (Optimize)** 開始搜尋。每個循環中會採用評估值 R 最小的組合，並自動寫入主視窗的參數。

## 自動化處理（自動程序 (Auto Procedure)）

自動處理送入資料夾的影像，例如在實驗期間。詳細內容請參見[工具](3-tools.md)。

1. 以 **設定 (Set)** 選擇要監看的資料夾。
2. 必要時，依 **圖樣比對 (Pattern matching)**（檔名結尾的數字）或 **關鍵字 (Keyword)** 篩選檔案。
3. 啟用 **載入新影像後, 執行下列程序 (Once the new image is loaded, perform the following sequence)**，並從清單中選擇：**Auto contrast** / **Find center** / **Mask spots** / **Get profile** / **Execute macro**。
4. 最後，開啟 **自動載入新影像 (Automatically load new images)** 以開始監看（未指定資料夾時無法開啟；會使用開始監看時所設定的數字／關鍵字條件）。之後每當有符合條件的影像送入，便會自動執行這一連串步驟。若等待寫入完成（約 50 秒）後檔案仍被鎖定，會在之後的掃描中重試，並在首次發現後 10 分鐘時放棄。

## 腳本化步驟（以 Python 為基礎的巨集）

含有迴圈與條件判斷的處理，可以撰寫為[巨集](5-macro/index.md)。在巨集編輯器中以 **顯示範例 (Show samples)** 顯示的範例巨集是很好的起點。

- 載入影像，設定射源與偵測器（中心、相機長度、像素），並調整顯示。
- 設定同心積分的條件（開始、結束、步進、單位），進行積分，並儲存為 CSV。
- 批次處理多個檔案，於每張影像旁儲存 CSV。
- 逐影格處理多影格影像。
- 將 Debye 環分割為 N 個扇形，分析方位角相依性。
- 遮罩（全部清除 → 遮罩斑點 → 遮罩光束擋板 (beam stop) 區域 → 儲存遮罩）後進行積分。
- 以徑向（cake）積分輸出方位角對強度。
- 啟用剪貼簿傳送、進行積分，並呼叫 PDIndexer 中的具名巨集（例如峰擬合）。

您撰寫的巨集可以儲存、依名稱呼叫，也可以從自動程序 (Auto Procedure) 執行。
