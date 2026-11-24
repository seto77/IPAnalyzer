<!-- 261124Cl: Retranslated from en/appendix/a4-symmetry-information.md (UI labels follow the localized GUI). -->

# 附录 A4. 对称性信息

**对称性信息 (Symmetry Information)** 显示所选晶体空间群对称性的详细信息，并以 *International Tables for Crystallography* Vol. A 的风格绘制对称元素和一般位置的示意图。

在 IPAnalyzer 中，该子窗口从 **Crystal window**（在 [4. 操作步骤](../4-procedures.md) 的几何校准和 [6. 查找参数（暴力搜索）](../6-find-parameter.md) 中使用的 CrystalControl）打开。

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

窗口分为空间群标识区（左上）、带选项卡的计算 / 表格区（右上）以及两幅示意图（下部）。

---

## 键盘与鼠标快捷操作

该窗口没有特殊的按键或鼠标组合。<kbd>F1</kbd> 打开本手册页面，两个 **Copy** 按钮将对称元素图和一般位置图放到剪贴板上（为位图；勾选 **EMF** 时为矢量 EMF）。

---

## 空间群标识

左上面板列出当前空间群的以下信息：

- **Number**（1–230）及设置 (setting) 编号
- **Crystal System**（晶系）
- **Point Group**（点群）：Hermann–Mauguin (HM) 符号和 Schoenflies (SF) 符号
- **Space Group**（空间群）：HM 简略符号、HM 完整符号、SF 符号以及 **Hall symbol**（Hall 符号）

---

## Geometrics Calculation（几何计算）

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

输入两个晶面 \((h_1, k_1, l_1)\)、\((h_2, k_2, l_2)\) 或两个方向指数 \([u_1, v_1, w_1]\)、\([u_2, v_2, w_2]\)，即可得到：

- 各晶面的 d 间距 / 各轴的长度，
- 两个晶面（或两个轴）之间的夹角，
- **两个晶面共有的晶带轴**（其交线方向）以及 **包含两个方向的晶面**。

这些计算考虑了当前晶胞的度规。

---

## Wyckoff Positions（Wyckoff 位置）

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

列出所有 Wyckoff 位置及其多重度、Wyckoff 字母、位置对称性，以及是一般位置还是特殊位置。对于有心点阵，表头行中会显示点阵平移矢量。

---

## Conditions（衍射条件）

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

由点阵有心化以及滑移 / 螺旋对称操作产生的衍射条件。

---

## 对称元素图与一般位置图

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

下部的两个面板以 *International Tables for Crystallography* Vol. A 的记法再现该空间群的对称性示意图。

- **对称元素（左）**：旋转轴 / 螺旋轴、镜面 / 滑移面以及对称中心 / 旋转反演点用惯用的图形符号绘制。
  - 对于立方晶系的 \(F\) 点阵，只显示晶胞的八分之一（仅左上象限）。
- **一般位置（右）**：一般等效位置以圆圈绘制（逗号表示镜像），并标注其分数坐标。
  - 仅对于立方晶系，会用辅助线连接由三重旋转轴相关联的三个圆圈。

示意图下方的控件：

- **Direction**（`a` / `b` / `c`）：选择投影所沿的晶轴。
- **Copy**：将各示意图以矢量图像 (**EMF**) 或光栅图像 (**BMP**) 复制到剪贴板；EMF 可以在 PowerPoint 中取消组合并进行编辑。

---

## 另请参阅

- [附录首页](index.md)
- [4. 操作步骤](../4-procedures.md) —— 使用标准晶体进行几何参数校准。
- [6. 查找参数（暴力搜索）](../6-find-parameter.md)
