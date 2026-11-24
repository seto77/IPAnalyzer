<!-- 261124Cl: Retranslated from en/3-tools.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 工具

本頁說明從主視窗右側的垂直工具列或選單啟動的輔助工具。使用參數校正與巨集的具體步驟，請參見[操作步驟](4-procedures.md)。

## 校正 R-AXIS 影像 (Calibrate Raxis Image)

以 **工具 (Tool) → 校正 R-AXIS 影像 (Calibrate Raxis Image)** 開啟。指定兩張相同尺寸的 R-AXIS IV `.stl` 影像後，本工具會最佳化強度轉換表，使兩者的強度一致。轉換表以控制點表示，最佳化過程中其元素總和保持不變。結果以圖表顯示。可用於例如校正偵測器的強度響應。

![校正 R-AXIS 影像](../assets/cap-en-auto/FormCalibrateIntensity.png)

## 自動程序 (Auto procedure)

監看資料夾、自動載入新影像，並在載入後執行一連串操作的工具。

- **監看與自動載入**：監看指定的資料夾（**要監視的目錄 (Directory to be monitored)**，含子資料夾），並在檔案寫入完成後讀取。可依檔名篩選檔案（以 **圖樣比對 (Pattern matching)** 比對檔名中的數字、**關鍵字 (Keyword)**）；不符合條件的檔案會直接略過，不會等待。若等待寫入完成（約 50 秒）後檔案仍被鎖定，該檔案不會被捨棄，而是在之後的掃描中重試；只有在首次發現後 10 分鐘仍被鎖定時才會放棄。
- **自動執行**：開啟 **載入新影像後, 執行下列程序 (Once the new image is loaded, perform the following sequence)** 時，會從 **Auto contrast** → **Find center** → **Mask spots** → **Get profile** → **Execute macro** 中，依序執行已勾選的步驟。

如此便能在實驗期間監看輸出資料夾，於每張影像產生時自動進行積分。詳細內容請參見[操作步驟](4-procedures.md)。

![自動程序](../assets/cap-en-auto/FormAutoProcedure.png)

## 繪製環 (Draw Ring)

考慮 IP 傾斜與像素畸變，在影像上以指定的距離、角度或 d 值繪製圓環。點選 **R (mm)** / **2θ (°)** / **d (Å)** 其中之一以選擇要編輯的值；其餘的值會依波長與相機長度自動計算。

![繪製環](../assets/cap-en-auto/FormDrawRing.png)

## 展開 (Unroll)

將繞射影像從以直射點為中心的極座標，展開為直角座標（橫軸 = 散射角 2θ；縱軸 = 方位角）。目前已不使用專用視窗，而是以工具列的 **展開影像 (Unroll image)** 按鈕與屬性的 **展開影像選項 (Unrolled Image Option)** 分頁進行設定。展開使用與積分為一維曲線時相同的次像素強度分配演算法。

## 周向模糊 (Circumferential Blur)

沿圓周（方位角）方向模糊圓環圖樣的工具。指定一個模糊角度後套用。

![周向模糊](../assets/cap-en-auto/FormBlurAngle.png)

## 連續影像 (Sequential Image)

處理多影格影像（NeXus（`.nxs`）、多頁 TIFF 等；時間序列、溫度序列、同步輻射能量掃描）的工具。

- 從影格清單中選取單一影格加以顯示，或以滑桿逐格切換。
- 使用 **多重選取 (Multi selection)** 可選取多個影格，並計算其 **平均 (Average)** 或 **加總 (Summation)**。
- 以 **取得圖譜 (Get Profile)** 積分的影格，在 **「取得圖譜」的目標 (Target(s) of "Get Profile")** 中選擇：**所有影像（不受目前選取影響） (All images irrespective of current selections)** / **選取的影像 (The selected image(s))** / **僅最上層影像 (Only the topmost image)**。
- 若影格帶有能量資訊，選取該單一影格時會更新波長。

![連續影像](../assets/cap-en-auto/FormSequentialImage.png)

## 儲存影像 (Save Image)（IPA 格式）

校正 IP 傾斜 φ、τ 與像素畸變 ξ，並以指定解析度、正方形像素儲存影像。相機長度、波長與中心位置等中繼資料也會一併寫入，因此能在保留幾何資訊的情況下，將影像交給其他影像處理使用。

![儲存影像](../assets/cap-en-auto/FormSaveImage.png)

## 尋找參數（幾何法）(Find Parameter (Geometric))

從標準物質的繞射環最佳化波長、相機長度、像素尺寸、像素畸變與傾斜 (φ, τ) 的工具。使用一張標準試料影像（**主要 (Primary)**），或在不同相機長度下拍攝的兩張影像（**主要 (Primary)** 與 **次要 (Secondary)**）；選取峰之後以 **精修! (Refine!)** 進行最佳化。收斂情形（橢圓中心、殘差）可在圖表上確認。具體步驟請參見[操作步驟](4-procedures.md)。

![尋找參數（幾何法）](../assets/cap-en-auto/FormFindParameter.png)

## 尋找參數（暴力法）(Find Parameter (Brute force))

以窮舉的網格搜尋而非梯度法，求出相機長度、中心位置、傾斜 (φ, τ)，以及可選的波長（預設關閉）的工具。使用主視窗中載入的單張標準試料影像。在圓環不完整或雜訊較多等幾何最佳化難以收斂的情況下特別有效。標準物質可從 Au / CeO₂ / LaB₆ / Al₂O₃ 中選擇，或選擇 **其他 (Other)** 並輸入晶體。詳細步驟請參見[尋找參數（暴力搜尋）](6-find-parameter.md)，工作流程請參見[操作步驟](4-procedures.md)。

![尋找參數（暴力法）](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## 巨集 (Macro)

以類 Python 腳本將操作自動化的功能。從主視窗的 **巨集 (Macro) → 編輯器 (Editor)** 選單開啟巨集編輯器。

- 可使用 `for` / `if` / `while` / `def` / `class`、算術運算，以及 `math` 模組。
- 透過 `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` 等 API，即可呼叫各項操作。
- 開啟 **顯示範例 (Show samples)** 可檢視唯讀的範例巨集（基本迴圈、幾何設定、批次處理、方位角分割、遮罩、傳送至 PDIndexer 等）。可藉由逐步執行檢查變數。

完整的函式參考與範例請參見[巨集](5-macro/index.md)，以巨集為基礎的工作流程請參見[操作步驟](4-procedures.md)。

![巨集編輯器](../assets/cap-en-auto/FormMacro.png)
