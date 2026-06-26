<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendix A4. Symmetry Information

**Symmetry Information** 显示所选晶体的空间群对称性的详细信息，此外还以 *International Tables for Crystallography* Vol. A 的风格绘制对称元素和一般等效点的示意图。

在 IPAnalyzer 中，该子窗口从 **Crystal window**（[4. Practical procedures](../4-procedures.md) 中用于几何校准、以及 [6. Find Parameter (brute force)](../6-find-parameter.md) 中所用的 CrystalControl）打开。

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

该窗口分为空间群标识区（左上）、带选项卡的计算/表格区（右上）以及两个示意图（底部）。

---

## Keyboard & mouse shortcuts

本窗口没有特殊的按键或鼠标组合。<kbd>F1</kbd> 打开本手册页面，两个 **Copy** 按钮将对称元素示意图和一般等效点示意图放到剪贴板上（作为位图，或在勾选 **EMF** 时作为矢量 EMF）。

---

## Space-group identity

左上面板针对当前空间群列出：

- **Number**（1–230）和 setting 索引
- **Crystal System**
- **Point Group**：Hermann–Mauguin (HM) 和 Schoenflies (SF) 记号
- **Space Group**：HM 短记号、HM 全记号、SF 记号以及 **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

输入两个晶面 \((h_1, k_1, l_1)\)、\((h_2, k_2, l_2)\) 或两个方向指数 \([u_1, v_1, w_1]\)、\([u_2, v_2, w_2]\)，即可得到：

- 每个晶面的 d-spacing / 每个轴的长度，
- 两个晶面（或两条轴）之间的夹角，
- **同时垂直于两个晶面的方向指数** 以及 **同时垂直于两条轴的晶面指数**。

这些计算遵从当前晶胞的度量。

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

列出每一个 Wyckoff position 及其多重度、Wyckoff letter、位置对称性，以及它属于一般位置还是特殊位置。对于带心点阵，点阵平移矢量显示在表头行中。

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

由点阵带心以及滑移/螺旋对称操作所产生的衍射条件（reflection conditions）。

---

## Symmetry-element & general-position diagrams

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

底部的两个面板以 *International Tables for Crystallography* Vol. A 的记法重现空间群的对称示意图。

- **Symmetry elements (left)**：旋转/螺旋轴、镜面/滑移面以及对称中心/旋转反演点均用常规的图形符号绘制。
  - 对于立方晶系的 \(F\) 点阵，仅显示晶胞的八分之一（仅左上象限）。
- **General positions (right)**：一般等效点绘制为圆圈（逗号表示镜像），并标注其分数坐标。
  - 仅对立方晶系，辅助线连接由三重旋转轴相关联的三个圆圈。

示意图下方的控件：

- **Direction**（`a` / `b` / `c`）：选择投影所沿的晶轴。
- **Copy** 将每个示意图作为矢量图像（**EMF**）或栅格图像（**BMP**）复制到剪贴板；EMF 可在 PowerPoint 中取消组合并编辑。

---

## See also

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — 使用标准晶体进行几何参数校准。
- [6. Find Parameter (brute force)](../6-find-parameter.md)
