<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

可從巨集呼叫的方法與屬性，依命名空間歸類於 `IPA` 根物件之下。各說明沿用巨集編輯器的內建說明（`[Help]` 屬性）；該內建說明為權威且最新的參考依據。

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | 回傳某個目錄的完整路徑。若省略 `filename`，則開啟資料夾選擇對話框。 |
| `GetFileName(message="")` | 開啟檔案對話框並回傳所選檔案的完整路徑。 |
| `GetFileNames(message="")` | 開啟多選對話框並以字串陣列回傳各完整路徑。 |
| `GetAllFileNames(message="")` | 選擇一個資料夾，並以陣列回傳其中所有檔案的完整路徑（遞迴）。 |
| `ReadImage(filename="", flag=None)` | 讀取影像檔。若省略，則開啟選擇對話框。 |
| `ReadImageHDF(filename, flag)` | 讀取 HDF5 影像。`flag` 用於切換正規化。 |
| `SaveImage(filename="")` | 儲存目前影像（舊式別名；預設為 TIFF）。 |
| `SaveImageAsTIFF(filename="")` | 將影像儲存為 TIFF。 |
| `SaveImageAsPNG(filename="")` | 將影像儲存為 PNG。 |
| `SaveImageAsIPA(filename="")` | 將影像儲存為 IPA 格式。 |
| `SaveImageAsCSV(filename="")` | 將影像儲存為 CSV。 |
| `ReadParameter(filename="")` | 讀取參數檔。 |
| `SaveParameter(filename="")` | 儲存目前的參數。 |
| `ReadMask(filename="")` | 讀取遮罩檔。 |
| `SaveMask(filename="")` | 儲存目前的遮罩。 |

所有讀取／儲存方法，若省略檔名或給定無效檔名，皆會開啟選擇對話框。

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | 設定入射束的波長（單位 nm）。 |
| `WaveLength` | 設定／取得波長（單位 nm）。 |
| `WaveSource` | 以整數設定／取得射源。0: None, 1: X-ray, 2: Electron, 3: Neutron。 |
| `XrayLine` | 以整數設定 X 射線波長譜線（僅可設定）。0: Kα, 1: Kα1, 2: Kα2。 |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | 設定中心（直接斑點）位置（單位 pixel）。 |
| `SetCameraLength(length)` | 設定相機長度（單位 mm）。 |
| `CenterX` | 設定／取得中心位置的 X 值（單位 pixel）。 |
| `CenterY` | 設定／取得中心位置的 Y 值（單位 pixel）。 |
| `CameraLength` | 設定／取得相機長度（單位 mm）。 |
| `PixelSizeX` | 設定／取得像素 X 尺寸（像素寬度）（單位 mm）。 |
| `PixelSizeY` | 設定／取得像素 Y 尺寸（像素高度）（單位 mm）。 |
| `PixelKsi` | 設定／取得像素傾斜 ξ（單位 度）。 |
| `TiltPhi` | 設定／取得傾斜 φ（單位 度）。 |
| `TiltTau` | 設定／取得傾斜 τ（單位 度）。 |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False。以負向漸層繪製影像（與 `PositiveGradient` 互為對應）。 |
| `PositiveGradient` | True/False。以正向漸層繪製影像（與 `NegativeGradient` 互為對應）。 |
| `LinearScale` | True/False。以線性刻度繪製（與 `LogScale` 互為對應）。 |
| `LogScale` | True/False。以對數刻度繪製（與 `LinearScale` 互為對應）。 |
| `GrayScale` | True/False。以灰階繪製（與 `ColorScale` 互為對應）。 |
| `ColorScale` | True/False。以彩色刻度繪製（與 `GrayScale` 互為對應）。 |
| `Maximum` | 設定／取得最大亮度等級（float）。 |
| `Minimum` | 設定／取得最小亮度等級（float）。 |
| `CanvasMagnification` | 設定／取得影像放大率（float）。 |
| `SetCanvasCenter(x, y)` | 設定畫布中心位置（單位 pixel）。 |
| `SetCanvasSize(width, height)` | 設定畫布（picture box）尺寸（單位 pixel）。 |
| `SetArea(top, bottom, left, right)` | 以上／下／左／右邊界設定畫布範圍（單位 pixel）。 |
| `SetFullArea()` | 設定畫布範圍，使整張影像皆可見。 |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | 遮蔽斑點（等同於「Mask Spots」按鈕）。 |
| `ClearMask()` | 清除目前的遮罩。 |
| `InvertMask()` | 反轉目前的遮罩狀態。 |
| `MaskAll()` | 遮蔽整個區域。 |
| `MaskTop()` | 遮蔽上半部。 |
| `MaskBottom()` | 遮蔽下半部。 |
| `MaskLeft()` | 遮蔽左半部。 |
| `MaskRight()` | 遮蔽右半部。 |
| `TakeOver` | 設定／取得遮罩沿用設定（integer）。0: None, 1: 沿用目前的遮罩狀態, 2: 沿用遮罩檔。 |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False。同心積分（2θ–強度）。 |
| `RadialIntegration` | True/False。徑向積分（pizza-cut）。 |
| `AzimuthalDivision` | True/False。以方位角分割模式處理。 |
| `AzimuthalDivisionNumber` | Integer。設定 Debye 環的分割數。 |
| `FindCenterBeforeGetProfile` | True/False。在 Get Profile 之前執行 Find Center。 |
| `MaskSpotsBeforeGetProfile` | True/False。在 Get Profile 之前執行 Mask Spots。 |
| `SendProfileViaClipboard` | True/False。透過剪貼簿將曲線傳送至 PDIndexer。 |
| `SaveProfileAfterGetProfile` | True/False。在 Get Profile 之後儲存曲線。 |
| `SaveProfileAsPDI` | True/False。儲存為 PDI 格式。 |
| `SaveProfileAsCSV` | True/False。儲存為 CSV 格式。 |
| `SaveProfileAsTSV` | True/False。儲存為 TSV 格式。 |
| `SaveProfileAsGSAS` | True/False。儲存為 GSAS 格式。 |
| `SaveProfileInOneFile` | True/False。將序列／方位角分割的曲線儲存於單一檔案。 |
| `SaveProfileAtImageDirectory` | True/False。儲存於與影像相同的目錄。 |
| `GetProfile(filename="")` | 執行一維化。若給定 `filename`，則將曲線儲存至該檔案。 |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False。同心積分（2θ–強度）。 |
| `RadialIntegration` | True/False。徑向積分（pizza-cut／cake 圖樣）。 |
| `ConcentricStart` | Float。同心積分的起始值。 |
| `ConcentricEnd` | Float。同心積分的結束值。 |
| `ConcentricStep` | Float。同心積分的步長。 |
| `ConcentricUnit` | Integer。同心積分的單位。0: Angle (deg), 1: d-spacing (Å), 2: Length (mm)。 |
| `RadialRadius` | Float。徑向積分的環狀（donut）半徑。 |
| `RadialWidgh` | Float。徑向積分的環狀（donut）寬度。注意：在目前版本中，此成員的拼字為 `RadialWidgh`。 |
| `RadialStep` | Float。徑向積分的扇形角度（掃描步長）。 |
| `RadialUnit` | Integer。徑向積分的單位。0: Angle (deg), 1: d-spacing (Å)。 |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False。取得目前檔案是否為序列影像。 |
| `Count` | Integer。取得影像張數。 |
| `SelectedIndex` | Integer。設定／取得所選的索引（從 0 起算）。 |
| `SelectedIndices` | Integer array。設定／取得所選的多個索引（用於多選模式）。 |
| `MultiSelection` | True/False。設定／取得多選模式。 |
| `Averaging` | True/False。設定／取得平均模式。 |
| `SelectIndex(index)` | 設定單一所選索引（關閉多選）。 |
| `AppendIndex(index)` | 將一個索引附加至目前的選取。 |
| `SelectIndices(start, end)` | 設定連續範圍（start 至 end，含端點）。 |
| `AppendIndices(start, end)` | 將連續範圍（start 至 end，含端點）附加至目前的選取。 |
| `Target_SelectedImages` | True/False。將所選影像設為 Get Profile 的對象。 |
| `Target_AllImages` | True/False。將所有影像設為 Get Profile 的對象。 |
| `Target_TopmostImage` | True/False。僅將最上層影像設為 Get Profile 的對象。 |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False。在 PDIndexer 上逐步執行巨集。 |
| `Timeout` | 設定／取得巨集操作的逾時時間（秒）（預設 30 秒）。 |
| `RunMacro(obj1, obj2, ...)` | 在 PDIndexer 上執行巨集程式碼。參數在 PDI 上以 `Obj[1]`, `Obj[2]`, … 讀取。 |
| `RunMacroName(name, obj1, obj2, ...)` | 在 PDIndexer 上執行名為 `name` 的具名巨集。參數在 PDI 上以 `Obj[1]`, `Obj[2]`, … 讀取。 |
