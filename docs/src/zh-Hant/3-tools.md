<!-- 260601Cl: Reflected from ja/3-tools.md (lead language: Japanese). 260601Cl: auto-capture images embedded. -->

# Tools

本頁說明從主視窗右側垂直工具列或從選單啟動的輔助工具。關於使用參數校正與巨集的具體操作步驟，請參閱 [Procedures](4-procedures.md)。

## Intensity Table

比較兩張影像的強度分布並最佳化強度轉換表的工具。它在 300 次迭代中最佳化 16 個控制點，使兩個強度互相匹配，同時保留總積分強度。例如可用於校正偵測器的強度響應。

![Intensity Table](../assets/cap-en-auto/FormCalibrateIntensity.png)

## Auto Procedure

監看資料夾、自動載入新影像，並在載入後執行一連串操作的工具。

- **Watch and auto-load**: 監看指定的資料夾（含子資料夾），並在檔案寫入完成後讀取該檔案。可依檔名（數字匹配、關鍵字）篩選檔案。
- **Auto execution**: 依序執行 Auto Contrast → Find Center → Mask Spots → Get Profile → Execute Macro 中所勾選的步驟。

如此一來，便可在實驗期間監看輸出資料夾，並在每張影像送達時自動積分。詳情請參閱 [Procedures](4-procedures.md)。

![Auto Procedure](../assets/cap-en-auto/FormAutoProcedure.png)

## Draw Ring

在影像上以指定的距離、角度或 d 值繪製圓環，並計入 IP 傾斜與像素變形。點擊 **R (mm)** / **2θ (°)** / **d (Å)** 之一以選擇要編輯哪個數值；其餘各值會依波長與相機長度自動計算。

![Draw Ring](../assets/cap-en-auto/FormDrawRing.png)

## Unroll

將以直射斑點為中心的繞射影像，從極座標展開為笛卡兒座標（橫軸 = 角度、距離或 d 值；縱軸 = 方位角）。它現在不再使用專屬視窗設定，而是透過 **Unroll** 工具列按鈕與屬性中的 **Unrolled Image Option** 分頁來設定。展開時使用與一維化相同的次像素強度分布演算法。

## Circumferential Blur

沿周向（方位角）方向模糊圓環圖樣的工具。指定單一模糊角度並套用。

![Circumferential Blur](../assets/cap-en-auto/FormBlurAngle.png)

## Sequential Image

用於處理多影格影像（HDF5 及類似格式；時間序列、溫度序列、同步輻射能量掃描）的工具。

- 從影格清單選取單一影格以顯示，或以軌道列逐一切換。
- 透過 **multi-selection** 選取多個影格，並計算其 **average** 或 **sum**。
- 一維化的對象可從「all frames / selected frames / topmost only」中選擇。
- 若每個影格皆帶有能量資訊，波長會自動更新。

![Sequential Image](../assets/cap-en-auto/FormSequentialImage.png)

## Save Image (IPA format)

校正 IP 傾斜 φ、τ 與像素變形 ξ，並以指定解析度將影像存為正方形像素。相機長度、波長、中心位置等中繼資料也會一併寫入，因此可在保留幾何資訊的同時，將影像傳遞給其他影像處理。

![Save Image](../assets/cap-en-auto/FormSaveImage.png)

## Find Parameter (Geometric)

從標準物質的繞射環最佳化波長、相機長度、像素尺寸、像素變形與傾斜 (φ, τ) 的工具。它使用 Primary 與 Secondary 兩個圖樣，由您選取波峰並以 **Refine!** 進行最佳化。收斂情形（橢圓中心、殘差）可在圖表上檢查。具體步驟請參閱 [Procedures](4-procedures.md)。

![Find Parameter (Geometric)](../assets/cap-en-auto/FormFindParameter.png)

## Find Parameter (Brute force)

以窮舉式網格搜尋（而非梯度法）尋找相機長度與波長的工具。當幾何最佳化難以收斂時（例如圓環不完整或資料含雜訊），此工具特別有效。使用 CrystalControl 輸入晶體參數。詳細步驟請參閱 [Find Parameter (brute force)](6-find-parameter.md)，工作流程請參閱 [Procedures](4-procedures.md)。

![Find Parameter (Brute force)](../assets/cap-en-auto/FormFindParameterBruteForce.png)

## Macro

以類 Python 腳本自動化操作的功能。從主視窗的 **Macro → Editor** 選單開啟巨集編輯器。

- 可使用 `for` / `if` / `while` / `def` / `class`、算術運算，以及 `math` 模組。
- `IPA.File` / `IPA.Wave` / `IPA.Detector` / `IPA.Profile` / `IPA.Sequential` / `IPA.Image` / `IPA.Mask` / `IPA.PDI` / `IPA.IntegralProperty` 等 API 可讓您呼叫各項操作。
- 內附範例巨集（基本迴圈、幾何設定、批次處理、方位角分割、遮蔽、傳送至 PDIndexer 等），並可透過單步執行檢查變數。

完整的函式參考與範例請參閱 [Macro](5-macro/index.md)，基於巨集的工作流程請參閱 [Procedures](4-procedures.md)。

![Macro editor](../assets/cap-en-auto/FormMacro.png)

## Calibrate R-Axis Image

針對 R-Axis 偵測器特有的強度校正而設計的工具；目前僅會讀取檔案，校正本身尚未實作。

![Calibrate R-Axis Image](../assets/cap-en-auto/FormCalibrateRAxisImage.png)
