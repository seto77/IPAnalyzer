<!-- 260602Cl: Reflected from ja/appendix/a3-image-integration.md (lead language: Japanese). -->

# Appendix A3. Image integration

將 2D 影像轉換為 1D 曲線時，最大的問題在於**當積分的角度步進大小小於像素間距（像素尺寸）時，如何分配橫跨多個步進的像素強度**。IPAnalyzer 以**基於面積的分配法**處理此分配。

---

## 基於面積的分配法

在本軟體中，程式會計算劃分各步進的線（等繞射角的邊界）與像素之間的交點，求出各像素落在特定步進內的**面積**，並依該面積比例分配強度。

![Area-based distribution. Real ring image (left) → pixel scale (center, green dashed lines are the step boundaries) → intersections with the step boundaries inside a single pixel (right, areas delimited by the four corners and the intersections).](../../assets/references/integration-area-distribution.png){width=680px}

此方法具有以下特性。

- 在各像素內部，將步進邊界的弧**近似為直線**。此舉是為了計算速度，在實務上幾乎不會造成問題。
- 當需要 [A1. Detector geometry](a1-geometry.md) 中的傾斜校正與像素形狀校正時，像素形狀並非嚴格的正方形。因此本軟體會**依序計算像素四個角的座標**，並以四邊形（一般為平行四邊形）求出面積。

採用此方案後，原則上無論將角度步進設得多細，像素強度都能平滑地分配到各步進之間。

---

## 適用範圍

以下三種積分類型皆使用相同的基於面積的分配演算法。

| Function | Direction of integration | Use |
|------|-----------|------|
| **Concentric Integration** | 繞射角（同心方向） | 建立一般的 $2\theta$-intensity 曲線。 |
| **Radial Integration** | 周向（方位角）方向 | 評估環的方位角相依性（取向、變形）。 |
| **Unrolled Image** | 繞射角 × 方位角 | 建立將環剖開的 2D 展開影像。 |

各功能的操作方式請參閱 [3. Tools](../3-tools.md)。
