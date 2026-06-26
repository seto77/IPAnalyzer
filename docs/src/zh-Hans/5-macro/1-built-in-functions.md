<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

可从宏中调用的方法和属性，按 `IPA` 根对象下的命名空间分组。说明遵循宏编辑器的内嵌帮助（`[Help]` 属性）；内嵌帮助是权威且最新的参考。

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | 返回目录的完整路径。若省略 `filename`，则打开文件夹选择对话框。 |
| `GetFileName(message="")` | 打开文件对话框并返回所选文件的完整路径。 |
| `GetFileNames(message="")` | 打开多选对话框并以字符串数组返回各完整路径。 |
| `GetAllFileNames(message="")` | 选择一个文件夹，并以数组返回其中所有文件（递归）的完整路径。 |
| `ReadImage(filename="", flag=None)` | 读取图像文件。若省略，则打开选择对话框。 |
| `ReadImageHDF(filename, flag)` | 读取 HDF5 图像。`flag` 切换是否归一化。 |
| `SaveImage(filename="")` | 保存当前图像（旧版别名；默认保存为 TIFF）。 |
| `SaveImageAsTIFF(filename="")` | 将图像保存为 TIFF。 |
| `SaveImageAsPNG(filename="")` | 将图像保存为 PNG。 |
| `SaveImageAsIPA(filename="")` | 将图像保存为 IPA 格式。 |
| `SaveImageAsCSV(filename="")` | 将图像保存为 CSV。 |
| `ReadParameter(filename="")` | 读取参数文件。 |
| `SaveParameter(filename="")` | 保存当前参数。 |
| `ReadMask(filename="")` | 读取掩模文件。 |
| `SaveMask(filename="")` | 保存当前掩模。 |

对于所有读取/保存方法，省略或给出无效的文件名都会打开选择对话框。

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | 设置入射束的波长（单位 nm）。 |
| `WaveLength` | 设置/获取波长（单位 nm）。 |
| `WaveSource` | 以整数设置/获取射线源。0: None, 1: X-ray, 2: Electron, 3: Neutron。 |
| `XrayLine` | 以整数设置 X 射线波长谱线（仅设置）。0: Kα, 1: Kα1, 2: Kα2。 |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | 设置中心（直射斑点）位置（单位 像素）。 |
| `SetCameraLength(length)` | 设置相机长度（单位 mm）。 |
| `CenterX` | 设置/获取中心位置的 X 值（单位 像素）。 |
| `CenterY` | 设置/获取中心位置的 Y 值（单位 像素）。 |
| `CameraLength` | 设置/获取相机长度（单位 mm）。 |
| `PixelSizeX` | 设置/获取像素的 X 尺寸（像素宽度）（单位 mm）。 |
| `PixelSizeY` | 设置/获取像素的 Y 尺寸（像素高度）（单位 mm）。 |
| `PixelKsi` | 设置/获取像素倾斜 ξ（单位 度）。 |
| `TiltPhi` | 设置/获取倾斜 φ（单位 度）。 |
| `TiltTau` | 设置/获取倾斜 τ（单位 度）。 |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False。以负向渐变绘制图像（与 `PositiveGradient` 相对）。 |
| `PositiveGradient` | True/False。以正向渐变绘制图像（与 `NegativeGradient` 相对）。 |
| `LinearScale` | True/False。以线性刻度绘制（与 `LogScale` 相对）。 |
| `LogScale` | True/False。以对数刻度绘制（与 `LinearScale` 相对）。 |
| `GrayScale` | True/False。以灰度绘制（与 `ColorScale` 相对）。 |
| `ColorScale` | True/False。以彩色绘制（与 `GrayScale` 相对）。 |
| `Maximum` | 设置/获取最大亮度级别（float）。 |
| `Minimum` | 设置/获取最小亮度级别（float）。 |
| `CanvasMagnification` | 设置/获取图像放大倍率（float）。 |
| `SetCanvasCenter(x, y)` | 设置画布中心位置（单位 像素）。 |
| `SetCanvasSize(width, height)` | 设置画布（picture box）尺寸（单位 像素）。 |
| `SetArea(top, bottom, left, right)` | 按上/下/左/右边界设置画布区域（单位 像素）。 |
| `SetFullArea()` | 设置画布区域使整幅图像可见。 |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | 掩蔽斑点（与 "Mask Spots" 按钮相同）。 |
| `ClearMask()` | 清除当前掩模。 |
| `InvertMask()` | 反转当前掩模状态。 |
| `MaskAll()` | 掩蔽整个区域。 |
| `MaskTop()` | 掩蔽上半部分。 |
| `MaskBottom()` | 掩蔽下半部分。 |
| `MaskLeft()` | 掩蔽左半部分。 |
| `MaskRight()` | 掩蔽右半部分。 |
| `TakeOver` | 设置/获取掩模继承设置（integer）。0: None, 1: 继承当前掩模状态, 2: 继承掩模文件。 |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False。同心积分（2θ–强度）。 |
| `RadialIntegration` | True/False。径向积分（pizza-cut）。 |
| `AzimuthalDivision` | True/False。以方位角分割模式处理。 |
| `AzimuthalDivisionNumber` | Integer。设置 Debye 环分割的数量。 |
| `FindCenterBeforeGetProfile` | True/False。在 Get Profile 之前运行 Find Center。 |
| `MaskSpotsBeforeGetProfile` | True/False。在 Get Profile 之前运行 Mask Spots。 |
| `SendProfileViaClipboard` | True/False。通过剪贴板将谱线发送到 PDIndexer。 |
| `SaveProfileAfterGetProfile` | True/False。在 Get Profile 之后保存谱线。 |
| `SaveProfileAsPDI` | True/False。保存为 PDI 格式。 |
| `SaveProfileAsCSV` | True/False。保存为 CSV 格式。 |
| `SaveProfileAsTSV` | True/False。保存为 TSV 格式。 |
| `SaveProfileAsGSAS` | True/False。保存为 GSAS 格式。 |
| `SaveProfileInOneFile` | True/False。将序列/方位角分割的谱线保存到一个文件中。 |
| `SaveProfileAtImageDirectory` | True/False。保存到与图像相同的目录。 |
| `GetProfile(filename="")` | 执行一维化。若给出 `filename`，则将谱线保存到该文件。 |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False。同心积分（2θ–强度）。 |
| `RadialIntegration` | True/False。径向积分（pizza-cut / cake pattern）。 |
| `ConcentricStart` | Float。同心积分的起始值。 |
| `ConcentricEnd` | Float。同心积分的结束值。 |
| `ConcentricStep` | Float。同心积分的步长值。 |
| `ConcentricUnit` | Integer。同心积分的单位。0: Angle (deg), 1: d-spacing (Å), 2: Length (mm)。 |
| `RadialRadius` | Float。径向积分的圆环（donut）半径。 |
| `RadialWidgh` | Float。径向积分的圆环（donut）宽度。注意：当前版本中该成员拼写为 `RadialWidgh`。 |
| `RadialStep` | Float。径向积分的扇区角度（扫掠步长）。 |
| `RadialUnit` | Integer。径向积分的单位。0: Angle (deg), 1: d-spacing (Å)。 |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False。获取当前文件是否为序列图像。 |
| `Count` | Integer。获取图像数量。 |
| `SelectedIndex` | Integer。设置/获取所选索引（从 0 开始）。 |
| `SelectedIndices` | Integer array。设置/获取所选索引（用于多选模式）。 |
| `MultiSelection` | True/False。设置/获取多选模式。 |
| `Averaging` | True/False。设置/获取平均模式。 |
| `SelectIndex(index)` | 设置单个所选索引（关闭多选）。 |
| `AppendIndex(index)` | 向当前选择追加一个索引。 |
| `SelectIndices(start, end)` | 设置一段连续范围（从 start 到 end，含两端）。 |
| `AppendIndices(start, end)` | 向当前选择追加一段连续范围（从 start 到 end，含两端）。 |
| `Target_SelectedImages` | True/False。将所选图像作为 Get Profile 的目标。 |
| `Target_AllImages` | True/False。将所有图像作为 Get Profile 的目标。 |
| `Target_TopmostImage` | True/False。仅将最顶层图像作为 Get Profile 的目标。 |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False。在 PDIndexer 上逐步运行宏。 |
| `Timeout` | 设置/获取宏操作的超时时间（秒）（默认 30 秒）。 |
| `RunMacro(obj1, obj2, ...)` | 在 PDIndexer 上执行宏代码。参数在 PDI 上以 `Obj[1]`, `Obj[2]`, … 读取。 |
| `RunMacroName(name, obj1, obj2, ...)` | 在 PDIndexer 上执行名为 `name` 的宏。参数在 PDI 上以 `Obj[1]`, `Obj[2]`, … 读取。 |
