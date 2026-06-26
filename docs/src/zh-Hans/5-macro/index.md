<!-- 260601Cl: Reflected from ja/5-macro/index.md (lead language: Japanese). Migrated from the wiki macro pages. -->

# Macro

IPAnalyzer 提供 **macro** 功能，可用类似 Python 的脚本自动执行一系列操作。它适用于大量文件的批量一维化、格式转换、方位角分割分析等重复性工作。

## Opening the editor

在主窗口中从 **Macro** 菜单 → **Editor** 打开宏编辑器。你可以在其中编辑代码并运行，包括逐步执行。

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## Language

- 可使用 `for` / `if` / `while` / `def` / `class` 等控制语句以及算术运算。
- `math` 模块已预先导入，因此无需 `import` 语句即可直接使用 `math.pi` 或 `math.sin(...)`。
- `print()` 不可用。若要查看变量值，请使用 **step execution**（Step by step），并在调试面板中观察变量的变化。
- 每个 IPAnalyzer 操作都从 `IPA` 根对象下的命名空间调用（例如 `IPA.File`）。

## IPA namespaces

| Namespace | Role |
|------|------|
| `IPA.File` | 读写图像、参数和掩模文件；文件选择对话框 |
| `IPA.Wave` | 设置入射源和波长 |
| `IPA.Detector` | 设置探测器几何：中心、相机长度、像素尺寸、倾斜 |
| `IPA.Image` | 控制显示比例、对比度和视图区域 |
| `IPA.Mask` | 掩蔽斑点 (spot) 和区域 |
| `IPA.Profile` | 运行一维化 (Get Profile) 并配置保存/发送 |
| `IPA.IntegralProperty` | 设置同心 / 径向积分的范围、步长和单位 |
| `IPA.Sequential` | 选择 / 平均 / 指定多帧图像的帧 |
| `IPA.PDI` | 调用 PDIndexer 上的宏（剪贴板集成） |

成员列表请参见 [Built-in functions](1-built-in-functions.md)，具体脚本请参见 [Examples](2-examples.md)。

!!! tip "The in-editor help is the authoritative reference"
    每个函数/属性的说明显示在宏编辑器的帮助中，它是最新的、随版本跟踪的权威来源。如果本页与编辑器内帮助有出入，请以后者为准。

## Sample macros

当编辑器的已保存宏列表为空时，会自动插入示例宏（基本循环、数学函数、几何设置、批处理、方位角分割、掩蔽、发送到 PDIndexer 等）。它们是便于改写的入门起点。

## Working with Auto Procedure

你编写的宏可以按名称保存，也可以从 [Auto Procedure](../3-tools.md) 的“execute after loading”列表中调用，从而在实验过程中将宏自动应用到每个到达的图像。
