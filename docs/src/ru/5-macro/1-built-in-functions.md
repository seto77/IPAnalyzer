<!-- 260601Cl: Reflected from ja/5-macro/1-built-in-functions.md. Regenerated from the live code (Macro.cs [Help] attributes, ver3.977). -->

# Built-in functions

Методы и свойства, вызываемые из макроса, сгруппированы по пространствам имён в составе корневого объекта `IPA`. Описания соответствуют встроенной справке редактора макросов (атрибуты `[Help]`); встроенная справка является авторитетным и актуальным источником.

## IPA.File

| Member | Description |
|------|------|
| `GetDirectoryPath(filename="")` | Возвращает полный путь к каталогу. Если `filename` опущен, открывается диалог выбора папки. |
| `GetFileName(message="")` | Открывает диалог выбора файла и возвращает полный путь выбранного файла. |
| `GetFileNames(message="")` | Открывает диалог с множественным выбором и возвращает полные пути в виде массива строк. |
| `GetAllFileNames(message="")` | Выбирает папку и возвращает полные пути всех файлов в ней (рекурсивно) в виде массива. |
| `ReadImage(filename="", flag=None)` | Читает файл изображения. Если опущен, открывается диалог выбора. |
| `ReadImageHDF(filename, flag)` | Читает изображение HDF5. `flag` переключает нормализацию. |
| `SaveImage(filename="")` | Сохраняет текущее изображение (устаревший псевдоним; по умолчанию TIFF). |
| `SaveImageAsTIFF(filename="")` | Сохраняет изображение в формате TIFF. |
| `SaveImageAsPNG(filename="")` | Сохраняет изображение в формате PNG. |
| `SaveImageAsIPA(filename="")` | Сохраняет изображение в формате IPA. |
| `SaveImageAsCSV(filename="")` | Сохраняет изображение в формате CSV. |
| `ReadParameter(filename="")` | Читает файл параметров. |
| `SaveParameter(filename="")` | Сохраняет текущие параметры. |
| `ReadMask(filename="")` | Читает файл маски. |
| `SaveMask(filename="")` | Сохраняет текущую маску. |

Для всех методов чтения/сохранения: если имя файла опущено или указано неверно, открывается диалог выбора.

## IPA.Wave

| Member | Description |
|------|------|
| `SetWaveLength(wavelength)` | Задаёт длину волны падающего пучка (в нм). |
| `WaveLength` | Задаёт/возвращает длину волны (в нм). |
| `WaveSource` | Задаёт/возвращает источник в виде целого числа. 0: None, 1: X-ray, 2: Electron, 3: Neutron. |
| `XrayLine` | Задаёт линию длины волны рентгеновского излучения в виде целого числа (только запись). 0: Kα, 1: Kα1, 2: Kα2. |

## IPA.Detector

| Member | Description |
|------|------|
| `SetCenter(x, y)` | Задаёт положение центра (прямого пятна) (в пикселях). |
| `SetCameraLength(length)` | Задаёт длину камеры (в мм). |
| `CenterX` | Задаёт/возвращает значение X центрального положения (в пикселях). |
| `CenterY` | Задаёт/возвращает значение Y центрального положения (в пикселях). |
| `CameraLength` | Задаёт/возвращает длину камеры (в мм). |
| `PixelSizeX` | Задаёт/возвращает размер пикселя по X (ширину пикселя) (в мм). |
| `PixelSizeY` | Задаёт/возвращает размер пикселя по Y (высоту пикселя) (в мм). |
| `PixelKsi` | Задаёт/возвращает перекос пикселя ξ (в градусах). |
| `TiltPhi` | Задаёт/возвращает наклон φ (в градусах). |
| `TiltTau` | Задаёт/возвращает наклон τ (в градусах). |

## IPA.Image

| Member | Description |
|------|------|
| `NegativeGradient` | True/False. Рисовать изображение с отрицательным градиентом (противоположность `PositiveGradient`). |
| `PositiveGradient` | True/False. Рисовать изображение с положительным градиентом (противоположность `NegativeGradient`). |
| `LinearScale` | True/False. Рисовать в линейном масштабе (противоположность `LogScale`). |
| `LogScale` | True/False. Рисовать в логарифмическом масштабе (противоположность `LinearScale`). |
| `GrayScale` | True/False. Рисовать в оттенках серого (противоположность `ColorScale`). |
| `ColorScale` | True/False. Рисовать в цветовой шкале (противоположность `GrayScale`). |
| `Maximum` | Задаёт/возвращает максимальный уровень яркости (float). |
| `Minimum` | Задаёт/возвращает минимальный уровень яркости (float). |
| `CanvasMagnification` | Задаёт/возвращает увеличение изображения (float). |
| `SetCanvasCenter(x, y)` | Задаёт положение центра холста (в пикселях). |
| `SetCanvasSize(width, height)` | Задаёт размер холста (picture box) (в пикселях). |
| `SetArea(top, bottom, left, right)` | Задаёт область холста по границам top/bottom/left/right (в пикселях). |
| `SetFullArea()` | Задаёт область холста так, чтобы было видно всё изображение. |

## IPA.Mask

| Member | Description |
|------|------|
| `MaskSpots()` | Маскирует рефлексы (то же, что кнопка "Mask Spots"). |
| `ClearMask()` | Очищает текущие маски. |
| `InvertMask()` | Инвертирует текущее состояние маски. |
| `MaskAll()` | Маскирует всю область. |
| `MaskTop()` | Маскирует верхнюю половину. |
| `MaskBottom()` | Маскирует нижнюю половину. |
| `MaskLeft()` | Маскирует левую половину. |
| `MaskRight()` | Маскирует правую половину. |
| `TakeOver` | Задаёт/возвращает настройку перенимания маски (целое число). 0: None, 1: перенять текущее состояние маски, 2: перенять файл маски. |

## IPA.Profile

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Интегрировать концентрически (2θ–интенсивность). |
| `RadialIntegration` | True/False. Интегрировать радиально (pizza-cut). |
| `AzimuthalDivision` | True/False. Обрабатывать в режиме азимутального деления. |
| `AzimuthalDivisionNumber` | Целое число. Задаёт количество делений кольца Дебая. |
| `FindCenterBeforeGetProfile` | True/False. Выполнять Find Center перед Get Profile. |
| `MaskSpotsBeforeGetProfile` | True/False. Выполнять Mask Spots перед Get Profile. |
| `SendProfileViaClipboard` | True/False. Отправлять профиль в PDIndexer через буфер обмена. |
| `SaveProfileAfterGetProfile` | True/False. Сохранять профиль после Get Profile. |
| `SaveProfileAsPDI` | True/False. Сохранять в формате PDI. |
| `SaveProfileAsCSV` | True/False. Сохранять в формате CSV. |
| `SaveProfileAsTSV` | True/False. Сохранять в формате TSV. |
| `SaveProfileAsGSAS` | True/False. Сохранять в формате GSAS. |
| `SaveProfileInOneFile` | True/False. Сохранять последовательные/азимутально-делённые профили в один файл. |
| `SaveProfileAtImageDirectory` | True/False. Сохранять в тот же каталог, что и изображение. |
| `GetProfile(filename="")` | Выполняет одномеризацию. Если задан `filename`, профиль сохраняется в этот файл. |

## IPA.IntegralProperty

| Member | Description |
|------|------|
| `ConcentricIntegration` | True/False. Интегрировать концентрически (2θ–интенсивность). |
| `RadialIntegration` | True/False. Интегрировать радиально (pizza-cut / cake pattern). |
| `ConcentricStart` | Float. Начальное значение для концентрического интегрирования. |
| `ConcentricEnd` | Float. Конечное значение для концентрического интегрирования. |
| `ConcentricStep` | Float. Шаг для концентрического интегрирования. |
| `ConcentricUnit` | Целое число. Единица для концентрического интегрирования. 0: Angle (deg), 1: d-spacing (Å), 2: Length (mm). |
| `RadialRadius` | Float. Радиус «бублика» (donut) для радиального интегрирования. |
| `RadialWidgh` | Float. Ширина «бублика» (donut) для радиального интегрирования. Примечание: в текущей версии член записывается как `RadialWidgh`. |
| `RadialStep` | Float. Угол сектора (шаг развёртки) для радиального интегрирования. |
| `RadialUnit` | Целое число. Единица для радиального интегрирования. 0: Angle (deg), 1: d-spacing (Å). |

## IPA.Sequential

| Member | Description |
|------|------|
| `SequentialImageMode` | True/False. Возвращает, является ли текущий файл последовательным изображением. |
| `Count` | Целое число. Возвращает количество изображений. |
| `SelectedIndex` | Целое число. Задаёт/возвращает выбранный индекс (с нуля). |
| `SelectedIndices` | Массив целых чисел. Задаёт/возвращает выбранные индексы (для режима множественного выбора). |
| `MultiSelection` | True/False. Задаёт/возвращает режим множественного выбора. |
| `Averaging` | True/False. Задаёт/возвращает режим усреднения. |
| `SelectIndex(index)` | Задаёт один выбранный индекс (отключает множественный выбор). |
| `AppendIndex(index)` | Добавляет один индекс к текущему выбору. |
| `SelectIndices(start, end)` | Задаёт непрерывный диапазон (от start до end включительно). |
| `AppendIndices(start, end)` | Добавляет непрерывный диапазон (от start до end включительно) к текущему выбору. |
| `Target_SelectedImages` | True/False. Делает выбранные изображения целью для Get Profile. |
| `Target_AllImages` | True/False. Делает все изображения целью для Get Profile. |
| `Target_TopmostImage` | True/False. Делает только самое верхнее изображение целью для Get Profile. |

## IPA.PDI

| Member | Description |
|------|------|
| `Debug` | True/False. Запускать макрос на PDIndexer пошагово. |
| `Timeout` | Задаёт/возвращает тайм-аут (в секундах) для операции макроса (по умолчанию 30 с). |
| `RunMacro(obj1, obj2, ...)` | Выполняет код макроса на PDIndexer. Параметры читаются в PDI как `Obj[1]`, `Obj[2]`, … |
| `RunMacroName(name, obj1, obj2, ...)` | Выполняет именованный макрос `name` на PDIndexer. Параметры читаются в PDI как `Obj[1]`, `Obj[2]`, … |
