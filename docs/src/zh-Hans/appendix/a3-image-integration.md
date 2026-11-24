<!-- 261124Cl: Retranslated from en/appendix/a3-image-integration.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 附录 A3. 图像积分

将二维图像转换为一维谱线时，最大的问题是 **当积分的角度步长小于像素间距（像素尺寸）时，如何分配跨越多个步长的像素的强度**。IPAnalyzer 用 **基于面积的分配法** 处理这种分配。

---

## 基于面积的分配法

本软件计算划分各步长的分界线（等衍射角的边界）与像素的交点，求出每个像素落在某一步长内的 **面积**，并按该面积比例分配强度。

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

该方法具有以下特点。

- 在每个像素内部，步长边界的圆弧 **近似为直线**。这是为了计算速度，实际上几乎不会造成问题。
- 当需要 [A1. 探测器几何](a1-geometry.md) 中的倾斜校正和像素形状校正时，像素形状并非严格的正方形。因此本软件 **逐一计算像素四个角的坐标**，并按四边形（一般为平行四边形）求出面积。

采用这种方案，原理上无论角度步长取得多细，像素强度都能平滑地分配到各个步长中。

---

## 适用范围

以下三种积分都使用同一种基于面积的分配算法。它们的区别在于输出的横轴保留哪个坐标，以及哪些像素被汇总为一个输出点。

| 功能 | 输出的横轴 | 汇总为一个输出点的像素 | 用途 |
|------|------|------|------|
| **同心积分 (Concentric integration)** | 衍射角 $2\theta$（或 d 间距） | 积分区域内所有方位角上、落在 $2\theta$（或 d）的一个步长之内的像素 | 生成通常的 $2\theta$-强度谱线。 |
| **径向积分 (Radial integration)** | 方位角 $\chi$ | 在由 **圆环半径 (Donut radius)** ± **圆环宽度 (Donut width)** 给出的圆环内、落在一个方位角步长（**扇区角度步长 (扫描步长) (Sector angle step (Sweep step))**）之内的像素 | 评价圆环的方位角依赖性（取向、畸变）。 |
| **展开图像 (Unrolled image)** | $2\theta$（横向）× 方位角 $\chi$（纵向） | 落在一个 $2\theta$ 步长且一个方位角扇区（$360^\circ/N$）之内的像素 | 生成将圆环切开展平的二维展开图像。 |

无论哪种情况都只使用有效像素：已掩蔽的像素以及在 **积分区域 (Integral Region)** 选项卡中被排除的像素不参与计算。

---

## 积分后的归一化

分配后的强度按功能以不同方式归一化。

- **同心积分**（平板探测器，$2\theta$ 或 d 间距横轴）和 **展开图像**：对每个步长（展开图像的每个像素），将分配到的强度求和，再除以对该步长有贡献的量。像素各部分的贡献量以其投影到“与散射线垂直、距离为相机长度的平面”上的面积来度量，即以其所张的立体角来度量，单位为“在相机长度处正对观察时的一个像素”。因此结果是单位立体角的平均强度：它与步长宽度以及落入一个步长的像素数无关，并且平板探测器上每个像素的立体角向高角度减小的效应也得到了补偿。没有任何像素落入的步长为 0。
- **径向积分**：分配到的强度只是在每个方位角步长内求和，不做除法。因此数值会随圆环宽度（**圆环宽度 (Donut width)**）和方位角步长的增大而增大。

各功能的操作方法请参见 [3. 工具](../3-tools.md)。
