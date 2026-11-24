<!-- 261124Cl: Retranslated from en/5-macro/1-built-in-functions.md (UI labels follow the localized GUI). -->

# 内置函数

可从宏中调用的方法和属性，按 `IPA` 根对象下的命名空间分组。说明依据宏编辑器的编辑器内帮助（`[Help]` 属性）；编辑器内帮助是权威的最新参考。

## IPA.File

| 成员 | 说明 |
|------|------|
| `GetDirectoryPath(filename="")` | 返回目录的完整路径。省略 `filename` 时会打开文件夹选择对话框。 |
| `GetFileName(message="")` | 打开文件对话框，返回所选文件的完整路径。 |
| `GetFileNames(message="")` | 打开多选对话框，以字符串数组返回完整路径。 |
| `GetAllFileNames(message="")` | 选择文件夹，以数组返回其中所有文件（递归）的完整路径。 |
| `ReadImage(filename="", flag=None)` | 读取图像文件。省略时会打开选择对话框。 |
| `ReadImageHDF(filename, flag)` | 读取 HDF5 图像。`flag` 切换是否归一化。当前版本中无法读取 HDF5 (`.h5`)；NeXus (`.nxs`) 文件可用 `ReadImage(filename)` 读取。 |
| `SaveImage(filename="")` | 保存当前图像（旧别名；默认为 TIFF）。 |
| `SaveImageAsTIFF(filename="")` | 将图像保存为 TIFF。 |
| `SaveImageAsPNG(filename="")` | 将图像保存为 PNG。 |
| `SaveImageAsIPA(filename="")` | 将图像保存为 IPA 格式。 |
| `SaveImageAsCSV(filename="")` | 将图像保存为 CSV。 |
| `ReadParameter(filename="")` | 读取参数文件。 |
| `SaveParameter(filename="")` | 保存当前参数。 |
| `ReadMask(filename="")` | 读取掩模文件。 |
| `SaveMask(filename="")` | 保存当前掩模。 |

对于所有读取 / 保存方法，省略文件名或给出无效的文件名时都会打开选择对话框。

## IPA.Wave

| 成员 | 说明 |
|------|------|
| `SetWaveLength(wavelength)` | 设置入射束的波长（单位 nm）。 |
| `WaveLength` | 设置 / 获取波长（单位 nm）。 |
| `WaveSource` | 以整数设置 / 获取射线源。0：None，1：X-ray，2：Electron，3：Neutron。 |
| `XrayLine` | 以整数设置 X 射线波长谱线（仅 setter）。0：Kα，1：Kα1，2：Kα2。 |

## IPA.Detector

| 成员 | 说明 |
|------|------|
| `SetCenter(x, y)` | 设置中心（直射斑点）位置（单位像素）。 |
| `SetCameraLength(length)` | 设置相机长度（单位 mm）。 |
| `CenterX` | 设置 / 获取中心位置的 X 值（单位像素）。 |
| `CenterY` | 设置 / 获取中心位置的 Y 值（单位像素）。 |
| `CameraLength` | 设置 / 获取相机长度（单位 mm）。 |
| `PixelSizeX` | 设置 / 获取像素 X 尺寸（像素宽度）（单位 mm）。 |
| `PixelSizeY` | 设置 / 获取像素 Y 尺寸（像素高度）（单位 mm）。 |
| `PixelKsi` | 设置 / 获取像素倾斜 ξ（单位度）。 |
| `TiltPhi` | 设置 / 获取倾斜 φ（单位度）。 |
| `TiltTau` | 设置 / 获取倾斜 τ（单位度）。 |

## IPA.Image

| 成员 | 说明 |
|------|------|
| `NegativeGradient` | True/False。以负渐变绘制图像（与 `PositiveGradient` 相对）。 |
| `PositiveGradient` | True/False。以正渐变绘制图像（与 `NegativeGradient` 相对）。 |
| `LinearScale` | True/False。以线性刻度绘制（与 `LogScale` 相对）。 |
| `LogScale` | True/False。以对数刻度绘制（与 `LinearScale` 相对）。 |
| `GrayScale` | True/False。以灰度绘制（与 `ColorScale` 相对）。 |
| `ColorScale` | True/False。以彩色刻度绘制（与 `GrayScale` 相对）。 |
| `Maximum` | 设置 / 获取最大亮度级别（浮点数）。 |
| `Minimum` | 设置 / 获取最小亮度级别（浮点数）。 |
| `CanvasMagnification` | 设置 / 获取图像放大倍率（浮点数）。 |
| `SetCanvasCenter(x, y)` | 设置画布中心位置（单位像素）。 |
| `SetCanvasSize(width, height)` | 设置画布（picture box）尺寸（单位像素）。 |
| `SetArea(top, bottom, left, right)` | 按上 / 下 / 左 / 右边界设置画布区域（单位像素）。 |
| `SetFullArea()` | 设置画布区域，使整幅图像可见。 |

## IPA.Mask

| 成员 | 说明 |
|------|------|
| `MaskSpots()` | 掩蔽斑点（与 “掩蔽斑点 (Mask Spots)” 按钮相同）。 |
| `ClearMask()` | 清除当前掩模。 |
| `InvertMask()` | 反转当前掩模状态。 |
| `MaskAll()` | 掩蔽整个区域。 |
| `MaskTop()` | 掩蔽上半部分。 |
| `MaskBottom()` | 掩蔽下半部分。 |
| `MaskLeft()` | 掩蔽左半部分。 |
| `MaskRight()` | 掩蔽右半部分。 |
| `TakeOver` | 设置 / 获取掩模沿用设置（整数）。0：无，1：沿用当前掩模状态，2：沿用掩模文件。 |

## IPA.Profile

| 成员 | 说明 |
|------|------|
| `ConcentricIntegration` | True/False。进行同心积分（2θ–强度）。 |
| `RadialIntegration` | True/False。进行径向积分（扇形切分）。 |
| `AzimuthalDivision` | True/False。以方位角分割模式处理。 |
| `AzimuthalDivisionNumber` | 整数。设置 Debye 环的分割数。 |
| `FindCenterBeforeGetProfile` | True/False。在获取图谱 (Get Profile) 之前执行查找中心 (Find Center)。 |
| `MaskSpotsBeforeGetProfile` | True/False。在获取图谱 (Get Profile) 之前执行掩蔽斑点 (Mask Spots)。 |
| `SendProfileViaClipboard` | True/False。通过剪贴板将谱线发送到 PDIndexer。 |
| `SaveProfileAfterGetProfile` | True/False。在获取图谱 (Get Profile) 之后保存谱线。 |
| `SaveProfileAsPDI` | True/False。保存为 PDI 格式。 |
| `SaveProfileAsCSV` | True/False。保存为 CSV 格式。 |
| `SaveProfileAsTSV` | True/False。保存为 TSV 格式。 |
| `SaveProfileAsGSAS` | True/False。保存为 GSAS 格式。仅适用于横轴为 2θ 的同心积分；多条谱线保存到一个文件中时不会写出。 |
| `SaveProfileInOneFile` | True/False。将序列 / 方位角分割的谱线保存到一个文件中。 |
| `SaveProfileAtImageDirectory` | True/False。保存到图像所在的同一目录。 |
| `GetProfile(filename="")` | 执行一维化。若给出 `filename`，则将其用作基本名并附加格式扩展名（例如以 CSV 保存 `GetProfile("sample.stl")` 时得到 `sample.stl.csv`）。若保存位置设为“每次选择”，则显示保存对话框。 |

## IPA.IntegralProperty

| 成员 | 说明 |
|------|------|
| `ConcentricIntegration` | True/False。进行同心积分（2θ–强度）。 |
| `RadialIntegration` | True/False。进行径向积分（扇形切分 / cake 图样）。 |
| `ConcentricStart` | 浮点数。同心积分的起始值。 |
| `ConcentricEnd` | 浮点数。同心积分的结束值。 |
| `ConcentricStep` | 浮点数。同心积分的步长。 |
| `ConcentricUnit` | 整数。同心积分的单位。0：Angle (deg)，1：d-spacing (Å)，2：Length (mm)。 |
| `RadialRadius` | 浮点数。径向积分的圆环半径。 |
| `RadialWidgh` | 浮点数。径向积分的圆环宽度。注意：当前版本中该成员拼写为 `RadialWidgh`。 |
| `RadialStep` | 浮点数。径向积分的扇区角度（扫描步长）。 |
| `RadialUnit` | 整数。径向积分的单位。0：Angle (deg)，1：d-spacing (Å)。 |

## IPA.Sequential

| 成员 | 说明 |
|------|------|
| `SequentialImageMode` | True/False。获取当前文件是否为序列图像。 |
| `Count` | 整数。获取图像数。 |
| `SelectedIndex` | 整数。设置 / 获取所选索引（从 0 开始）。 |
| `SelectedIndices` | 整数数组。设置 / 获取所选索引（用于多选模式）。 |
| `MultiSelection` | True/False。设置 / 获取多选模式。 |
| `Averaging` | True/False。设置 / 获取平均模式。 |
| `SelectIndex(index)` | 设置单个所选索引（关闭多选）。 |
| `AppendIndex(index)` | 向当前选择追加一个索引。 |
| `SelectIndices(start, end)` | 设置连续范围（从 start 到 end，含两端）。 |
| `AppendIndices(start, end)` | 向当前选择追加连续范围（从 start 到 end，含两端）。 |
| `Target_SelectedImages` | True/False。将所选图像设为获取图谱 (Get Profile) 的对象。 |
| `Target_AllImages` | True/False。将所有图像设为获取图谱 (Get Profile) 的对象。 |
| `Target_TopmostImage` | True/False。仅将最上层图像设为获取图谱 (Get Profile) 的对象。 |

## IPA.PDI

| 成员 | 说明 |
|------|------|
| `Debug` | True/False。在 PDIndexer 上单步运行宏。 |
| `Timeout` | 设置 / 获取宏操作的超时时间（秒）（默认 30 s）。 |
| `RunMacro(obj1, obj2, ...)` | 执行 PDIndexer 宏编辑器中当前打开的代码。参数在 PDIndexer 端以 `PDI.Obj[0]`、`PDI.Obj[1]`、… 读取。 |
| `RunMacroName(name, obj1, obj2, ...)` | 执行 PDIndexer 中以 `name` 保存的宏。参数在 PDIndexer 端以 `PDI.Obj[0]`、`PDI.Obj[1]`、… 读取。 |
