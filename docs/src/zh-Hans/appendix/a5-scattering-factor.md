<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 附录 A5. 散射因子

在当前版本中，晶体的衍射和结构因子显示在 **射束相互作用 (Beam Interaction)** 窗口的 **衍射 (Reflections)** 选项卡上（以前的 Scattering Factor 窗口已被它取代）。该选项卡列出所选晶体的允许晶面（衍射），并计算每个衍射的 **结构因子** 和衍射强度。射线种类（X 射线、电子或中子）可以切换，因此可以在不同衍射方法之间比较同一晶体的结构因子。

在 IPAnalyzer 中，从定义参数校准所用标准晶体的晶体窗口打开它（即在[查找参数 (几何法) (Find Parameter (Geometric))](../3-tools.md) 中用 **设置晶体 (Set crystal)** 打开的晶体窗口，或 [6. 查找参数（暴力搜索）](../6-find-parameter.md) 的晶体面板）：按 **射束相互作用 (Beam interaction)** 按钮，或从晶体面板的右键菜单中选择 **射束相互作用 (Beam Interaction)**。

![Beam Interaction window (Reflections tab)](../../assets/references/beam-interaction-reflections-en.png)

顶部的区域用于选择入射束，下方的 **衍射 (Reflections)** 选项卡显示衍射列表（上部）以及同一组衍射的棒状图（下部）。每当条件改变时，列表都会立即重新计算。其他选项卡（**衰减 & 输运 (Attenuations & transport)**、**散射因子 (Scattering factors)**、**荧光 (Fluorescence)**）在 IPAnalyzer 中不需要；有关它们的说明请参见 [ReciPro 手册中的 Beam Interaction](https://seto77.github.io/ReciPro/3-beam-interaction/)。

---

## 键盘与鼠标快捷操作

该窗口没有特殊的按键或鼠标组合。<kbd>F1</kbd> 打开本手册页面，**复制 (Copy)** 将衍射表导出为可粘贴到电子表格中的文本。

---

## 射束与波长

- **X-ray / Electron / Neutron**：原子散射因子因入射束的种类而异，因此在此切换。
- 对于 **X-ray**，选择 **Element**（阳极材料）和特征谱线（Kα 等）后，会自动设置该特征 X 射线的波长。
- **Energy** (keV) 与 **Wavelength** (Å) 相互联动；设置其中一个会更新另一个，二者都用于计算每个衍射的 2θ。
- **Unit**（**Å** / **nm**）切换 d 间距等量所用的长度单位。

---

## 衍射 (Reflections) 选项卡的选项

- **粉末衍射强度（Bragg-Brentano 光路） (Powder diffraction intensities (Bragg-Brentano optics))**：将相对强度计算为粉末衍射 (Bragg–Brentano) 强度 $I \propto m\,\lvert F\rvert^2 / V^2 \times L$，其中 $m$ 为多重度，$V$ 为晶胞体积；对于 X 射线 $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$（Lorentz–偏振因子），对于电子和中子 $L = 1/(\sin 2\theta\,\sin\theta)$（仅 Lorentz 因子）。射束无法到达的衍射 (d < λ/2) 强度为 0。关闭时显示结构因子强度 $\lvert F\rvert^2$。打开此项时，**隐藏等效晶面 (Hide equivalent planes)** 和 **隐藏禁戒晶面 (Hide prohibited planes)** 也会被打开并变为灰色（不可操作）。
- **隐藏等效晶面 (Hide equivalent planes)**（默认打开）：将晶体学上等效的晶面合并为一项。仅在此项打开时显示 **Multi.** 列。
- **隐藏禁戒晶面 (Hide prohibited planes)**（默认打开）：排除因消光规则而系统消光的晶面。此项关闭时，**Condition** 列显示禁止各消光晶面的衍射条件。
- **d-spacing cutoff >**（默认 1 Å）：排除 d 间距小于该值的衍射（长度单位遵循 **Unit**）。

---

## 衍射列表

每一行对应一个衍射（或一组对称等效晶面）。

| 列 | 含义 |
|------|------|
| **h, k, l** | Miller 指数 |
| **Multi.** | 多重度（对称等效晶面的数目） |
| **d (Å)** | 晶面间距 |
| **q (2π/d)** | 散射矢量的大小 |
| **2θ (°)** | 所选波长下的衍射角 |
| **F_real** | 结构因子的实部 |
| **F_inv** | 结构因子的虚部 |
| **\|F\|** | 结构因子振幅（$= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$） |
| **F^2** | 结构因子强度（$\lvert F\rvert^2$） |
| **Rel. Int. (%)** | 相对强度，以最强衍射为 100 |
| **Condition** | 该晶面违反的消光条件（仅在 **隐藏禁戒晶面 (Hide prohibited planes)** 关闭时显示） |

表格下方以棒状图绘制同一组衍射，最强的峰标有其 *hkl*。选择器可从 **2θ**、**d** 和 **Q**（$= 4\pi\sin\theta/\lambda$）中选择横轴，**Log I** 在线性和对数之间切换强度轴，**Range** 框设置绘图范围。

---

## 复制到剪贴板

**复制 (Copy)** 将衍射列表以可粘贴到 Excel 等电子表格中的文本形式复制到剪贴板。

---

## 另请参阅

- [附录首页](index.md)
- [4. 操作步骤](../4-procedures.md) —— 定义要计算结构因子的标准晶体。
- [6. 查找参数（暴力搜索）](../6-find-parameter.md)
- [ReciPro 手册中的 Beam Interaction](https://seto77.github.io/ReciPro/3-beam-interaction/) —— 同一窗口的全部四个选项卡。
