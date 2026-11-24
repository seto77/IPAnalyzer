<!-- 261124Cl: Retranslated from en/2-property-windows.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 屬性視窗

屬性視窗用來設定射源、偵測器條件，以及將影像積分為一維曲線時的各種條件。各分頁也可以從主視窗的 **性質 (Property)** 選單直接開啟。

以下的標籤為繁體中文介面中的顯示名稱，括號內為英文名稱。各標題使用實際的分頁與控制項名稱。

## 波源 (Wave source)

設定入射束的種類與波長。射源可選擇 X 射線、電子或中子。對於 X 射線，選擇元素與躍遷（K 線、L 線等）即會自動填入波長；若為同步輻射，請直接輸入波長。對於電子束與中子束，請輸入能量或波長（電子的波長已做相對論校正）。

- **校正線偏振 (即線偏振 → 非偏振) (Correct linear polarization (i.e., linear polarized → unpolarized))**：將線偏振的強度校正為等效的非偏振強度（用於同步輻射資料）。校正式如下，與方位角 χ 及散射角 2θ 有關。若 χ 的基準方向（在 **其他項目 (Miscellaneous)** 分頁中設定）為左／右，入射束視為水平偏振；若為上／下，則視為垂直偏振。

$$
I_\text{corr}(2\theta,\chi) = \frac{I(2\theta,\chi)}{\sin^2\chi + \cos^2\chi\,\cos^2 2\theta} \times \frac{1}{2}\left(1 + \cos^2 2\theta\right)
$$

![波源分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageXRay.png)

## 偵測器條件 (Detector condition)

設定偵測器的幾何條件。此分頁對應舊版的 "IP Condition"，並新增了座標系與偵測器形狀的選擇。

- **座標 (Coordinates)**：**直射點 (Direct spot)**（以直射點為基準）/ **基底 (Foot)**（以垂足為基準）。
- **偵測器類型 (Detector type)**：**平板 (Flat panel)** / **Gandolfi**。
- **直射點位置 (Direct spot position)** 與 **相機長度 1 (Camera Length 1)**：直射點位置 (X, Y pix)，以及試料至直射點的距離 (mm)。
- **基底位置 (Foot position)** 與 **相機長度 2 (Camera Length 2)**：在基底 (Foot) 模式下，垂足的位置以及試料至垂足的距離。
- **像素形狀 (Pixel Shape)**：像素尺寸 X、Y (mm) 與 ξ（Ksi，平行四邊形的歪斜角）。
- **Gandolfi 半徑 (Gandolfi Radius)**：選擇 Gandolfi 形狀時的半徑。
- **球面校正 (Spherical correction)**：對於彎曲的偵測器，以 m⁻¹ 為單位輸入曲率半徑的倒數 1/R（畫面上顯示的單位為 /m）。平面偵測器請設為 0。
- **傾斜 (Tilt)**：IP 的傾斜 φ (Phi) 與 τ (Tau)。

傾斜 φ、τ 與像素 ξ 的定義請參見[概觀](0-overview.md)。

![偵測器條件分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageIP.png)

## 積分區域 (Integral Region)

指定要積分的影像區域。

- **矩形 (Rectangle)**：選擇 **方向 (Direction)**（全部 (Full) / 上 (Top) / 下 (Bottom) / 左 (Left) / 右 (Right) / Vertical / Horizontal / Free），並設定 **條帶寬度 (Band Width)**、**角度 (Angle)**（Free 模式時）與 **兩側 (Both Side)**。
- **扇形 (Sector)**：以 **起始角度 (Start Angle)** / **結束角度 (End Angle)** 指定角度範圍。
- **例外像素 (Exceptional pixels)**：排除 **遮罩斑點 (Masked Spots)**、低於 / 高於所給閾值的像素（**強度低於 (Under intensity of)** / **強度高於 (Over intensity of)**），以及指定數目的 **距邊緣像素 (pixels from edges)**。每當強度改變時——選取連續影像的其他影格時、翻轉／旋轉之後，以及變更背景扣除或偏振校正時——閾值遮罩都會依校正後的強度重新計算。

![積分區域分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralRegion.png)

## 積分性質 (Integral Property)

設定積分方式與步進。

- **同心積分 (散射角色散) (Concentric integration (scattering angle dispersive))**：從 **角度 (Angle)**（2θ, °）/ **d 間距 (d-spacing)**（Å）中選擇橫軸單位，並設定 **開始 / 結束 / 步進 (Start / End / Step)**。**輸出圖樣 (Output pattern)** 的選擇（Bragg - Brentano / Debye - Scherrer）在目前版本中不影響結果。
- **徑向積分 (蛋糕圖樣) (Radial integration (cake pattern))**：依各方位角加總環狀區域的強度。以散射角 2θ（**角度 (Angle)**）或 d 間距（**d 間距 (d-spacing)**）指定環的中心（**甜甜圈半徑 (Donut radius)**）與半寬（**甜甜圈寬度 (Donut width)**），並設定 **扇形角度步進 (掃掠步進) (Sector angle step (Sweep step))**（方位角步進）。所得曲線的橫軸為方位角 χ (°)。

![積分性質分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageIntegralProperty.png)

## 遮罩選項 (Mask Option)

設定遮罩與斑點偵測的條件（由舊版的 "Find Center & Spots" 擴充而來）。中心偵測的設定位於 **其他項目 (Miscellaneous)** 分頁。

- **半遮罩 (Half mask)**：可快速遮罩影像上、下、左或右半部的按鈕。
- **手動遮罩模式 (Manual mask mode)**：啟用在主影像上的互動式遮罩。形狀有 **圓形 (Circle)**（拖曳以設定中心與半徑）、**多邊形 (Polygon)**（點選以新增頂點）、**矩形 (Rectangle)**（拖曳對角頂點）、**雲線 (Spline curve)**，以及 **斑點 (Spot)**（左／右鍵點選以新增／移除斑點）。
- **沿用遮罩設定 (Take over mask setting)**：載入新影像時遮罩的處理方式（**無 (None)** / **沿用目前的遮罩狀態 (Take over the current mask state)** / **沿用遮罩檔案 (Take over the mask file)**）。
- **斑點遮罩選項 (Mask spots option)** → **「遮罩斑點」的判定偏差 (Criterial deviation for "Mask Spots")**：斑點偵測的統計閾值（像素強度須比平均值高出幾倍標準差，才會被視為斑點）。

![遮罩選項分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageSpotsAndCenter.png)

## 「取得圖譜」之後 (After "Get Profile")

設定積分之後的儲存與傳送。

- **儲存圖譜 (Save Profiles)**：在 **儲存目錄 (Directory to be saved)** 中選擇儲存位置（**於影像所在的相同目錄 (At the same directory of the image)** / **每次於所選目錄 (At the chosen directory each time)**），並在 **檔案格式 (File format)** 中選擇格式（**PDI** / **CSV** / **TSV** / **GSAS**）。只有在同心積分且橫軸為 2θ 時才能輸出 GSAS。在 **連續影像或方位角分割的儲存選項 (Saving option)** 中，若選擇 **存於單一檔案 (GSAS 除外) (In one file (Excluding GSAS))** 則不會寫出 GSAS；此時請改選 **存於個別檔案 (In separate files)**。
- **透過剪貼簿將圖譜資料傳送至 PDIndexer (Send profile data to PDIndexer through Clipboard)**：透過剪貼簿將曲線傳送至執行中的 PDIndexer。

![「取得圖譜」之後分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPageAfterGetProfile.png)

## 展開影像選項 (Unrolled Image Option)

設定展開 (Unroll) 影像的參數。

- **水平 (距直射點距離) 單位與範圍 (Horizontal (distance from direct spot) unit and range)**：以散射角 2θ (°) 指定 **開始 / 結束 / 步進 (Start / End / Step)**（介面上會顯示單位選項，但目前版本一律將數值視為 2θ）。輸出影像寬度 ≈ (End − Start) / Step。
- **垂直 (扇形角度) 步進 (Vertical (sector angle) step)**：方位角的分割數 N。輸出影像高度為 N 像素，每一列涵蓋 360°/N（預設值 720 時為 0.5°）。

展開會將以直射點為中心的極座標繞射影像，映射為直角座標（角度對距離）的影像。

![展開影像選項分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPage1.png)

## 其他項目 (Miscellaneous)

彙整較細部的顯示與座標設定的分頁。

- **影像名稱選項 (Image name options)**：**檔名 (File name)** / **末層資料夾 + 檔名 (Last folder + file name)** / **完整路徑 (Full path)**。
- **影像載入選項 (Image loading options)** → **維持顯示範圍 (Maintain display range)**：載入新影像時，是否沿用縮放倍率與顯示位置（顯示範圍）。
- **Chi (χ) 軸選項 (Chi (χ) axis options)**：基準位置（上 (Top) / 下 (Bottom) / 左 (Left) / 右 (Right)）與旋轉方向（順時針 (Clockwise) / 逆時針 (Counterclockwise)）。偏振校正與徑向積分會參照 χ。
- **比例尺線選項 (Scale line options)**：顏色（**2θ scale line** / **Azimuth scale line**）、**線寬 (Line Width)**、**分割數 (Division)** 與 **顯示標籤 (Show labels)**。
- **尋找中心選項 (Find center options)**：**搜尋區域 ± (Search area ±)**、**峰擬合範圍 (2θ) (Peak fitting range (2θ))**、**固定中心 (Fix Center)**，以及 **排除遮罩像素 (Exclude masked pixels)**。

![其他項目分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPage5.png)

## 背景選項 (Background Option)

設定以背景影像進行的校正。

- **參考影像設定 (Reference image setting)**：將目前顯示的影像設為背景（**將目前影像設為背景 (Set the current image as background)**），或將其清除（**清除 (Clear)**）。
- **係數 (Coefficient)**：套用於背景影像的係數。

用於扣除空氣散射等加成性背景。對每個像素計算 \(I_\mathrm{out} = I - cB\)（\(B\)：背景影像，\(c\)：係數）。若要排除影像邊緣附近的像素，請使用 **積分區域 (Integral Region)** 分頁中的 **距邊緣像素 (pixels from edges)**。

![背景選項分頁](../assets/cap-en-auto/FormProperty.tabControl.tabPage3.png)
