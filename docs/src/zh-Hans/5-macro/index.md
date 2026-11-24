<!-- 261124Cl: Retranslated from en/5-macro/index.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 宏

IPAnalyzer 提供 **宏** 功能，可用类似 Python 的脚本自动执行一系列操作。它适用于将大量文件批量积分为一维谱线、格式转换以及方位角分割分析等重复性工作。

## 打开编辑器

从主窗口的 **宏 (Macro)** 菜单 → **编辑器 (Editor)** 打开宏编辑器。可以在其中编辑代码并运行，包括单步执行。

![Macro editor](../../assets/cap-en-auto/FormMacro.png)

## 语言

- 可以使用 `for` / `if` / `while` / `def` / `class` 等控制语句以及算术运算。
- `math` 模块已预先导入，因此无需 `import` 语句即可直接使用 `math.pi` 或 `math.sin(...)`。
- 不能使用 `print()`。若要检查值，请使用 **单步执行** (Step by step)，并在调试面板中观察变量的变化。
- IPAnalyzer 的各项操作通过 `IPA` 根对象下的命名空间调用（例如 `IPA.File`）。

## IPA 命名空间

| 命名空间 | 作用 |
|------|------|
| `IPA.File` | 读写图像、参数和掩模文件；文件选择对话框 |
| `IPA.Wave` | 设置入射源和波长 |
| `IPA.Detector` | 设置探测器几何：中心、相机长度、像素尺寸、倾斜 |
| `IPA.Image` | 控制显示刻度、对比度和视图区域 |
| `IPA.Mask` | 掩蔽斑点和区域 |
| `IPA.Profile` | 对图像进行积分（获取图谱 (Get Profile)）并设置保存 / 发送 |
| `IPA.IntegralProperty` | 设置同心 / 径向积分的范围、步长和单位 |
| `IPA.Sequential` | 多帧图像的帧选择 / 平均 / 目标设置 |
| `IPA.PDI` | 调用 PDIndexer 上的宏（剪贴板联动） |

成员列表请参见[内置函数](1-built-in-functions.md)，具体脚本请参见[示例](2-examples.md)。

!!! tip "编辑器内帮助是权威参考"
    各函数 / 属性的说明显示在宏编辑器的帮助中，它是随版本更新的最新正式依据。若本页与编辑器内帮助不一致，请以后者为准。

## 示例宏

在编辑器中打开 **显示示例 (Show samples)**，即可列出只读的示例宏（基本循环、数学函数、几何设置、批处理、方位角分割、掩蔽、发送到 PDIndexer 等）；关闭它则返回您自己保存的宏。它们是便于改写的起点。

## 与自动流程 (Auto Procedure) 配合使用

编写的宏可以按名称保存，也可以从[自动流程 (Auto Procedure)](../3-tools.md) 中运行（在 **宏 (Macro)** 中选择该宏并勾选 **Execute macro**），从而将宏自动应用于实验中到达的每幅图像。
