<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Appendix A3. Image integration

将二维图像转换为一维谱线时，最大的问题在于**当积分的角度步长小于像素间距（像素尺寸）时，如何分配跨越多个步长的像素强度**。IPAnalyzer 使用**基于面积的分配方法**来处理这种分配。

---

## 基于面积的分配方法

在本软件中，程序计算划分每个步长的直线（等衍射角的边界）与像素之间的交点，求出每个像素落入给定步长内的**面积**，并按该面积成比例地分配强度。

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

该方法具有以下特性。

- 在每个像素内部，步长边界的圆弧被**近似为直线**。这样做是为了提高计算速度，并且在实际中几乎不会成为问题。
- 当需要 [A1. Detector geometry](a1-geometry.md) 中的倾斜校正和像素形状校正时，像素形状并非严格的正方形。因此软件会**依次计算像素四个角的坐标**，并将面积作为四边形（一般为平行四边形）求出。

采用这种方案，原则上无论将角度步长设得多么精细，像素强度都能在各步长之间平滑分配。

---

## 适用范围

以下三种类型的积分都使用相同的基于面积的分配算法。

| Function | Direction of integration | Use |
|------|-----------|------|
| **Concentric Integration** | 衍射角（同心方向） | 创建普通的 $2\theta$-intensity 谱线。 |
| **Radial Integration** | 周向（方位角）方向 | 评估环的方位角依赖性（取向、畸变）。 |
| **Unrolled Image** | 衍射角 × 方位角 | 创建将环切开展开的二维展开图像。 |

各功能的操作方法请参见 [3. Tools](../3-tools.md)。
