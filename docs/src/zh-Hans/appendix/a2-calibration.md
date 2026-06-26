<!-- 260602Cl: Reflected from ja/appendix/a2-calibration.md (lead language: Japanese). -->

# Appendix A2. Parameter determination

由于每个像素的位置由 [A1. Detector geometry](a1-geometry.md) 的几何关系决定，使用错误的参数就意味着在错误的位置读取强度。本页说明如何从**标准物质**的衍射环中确定真实参数——相机长度、波长、像素尺寸以及 IP 倾斜。关于实际操作，请参阅 [4. Practical procedures](../4-procedures.md) 和 [6. Parameter calibration (brute force)](../6-find-parameter.md)。

---

## Standard material

进行校准时，需测量晶格常数已知的标准物质。理想的条件是：衍射环**数量多**、**SN 比高**、分布**稀疏**且**无择优取向**。如果没有特别偏好，推荐使用含重原子的立方晶体，如 $\mathrm{CeO_2}$ 或 $\mathrm{Ag}$。晶格常数须精确到约 5 位有效数字。

---

## Camera length — two-distance method

相机长度 $\mathrm{CL}$ 定义为样品与 IP 上直射斑点之间的连线距离。如果在改变相机长度 $\Delta$ 的同时拍摄两张衍射图样，就可以根据同一衍射环半径（以像素计）$r_1,\ r_2$ 的变化确定 $\mathrm{CL}$ 的绝对值。距离差 $\Delta$ 可以借助 Magnescale 等设备精确控制。

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

由相似三角形 $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$，可得

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

。此处 $r_1,\ r_2$ 可以保持像素单位；即使倾斜校正与像素尺寸校正略有偏差，甚至标准物质的晶格常数不够准确，也能求得相机长度。由于这样得到的相机长度与其他参数几乎没有相关性，因此它是**应当首先确定的参数**。

---

## Wavelength and pixel size — two-line method

如果能记录到两条衍射线，则即使不知道像素尺寸或相机长度，也可以根据它们峰位（以像素计）$p_1,\ p_2$ 的比值及其 d-spacing $d_1,\ d_2$ 计算出衍射角 $\theta_1,\ \theta_2$。设 d-spacing 之比为 $\rho_d = d_1/d_2$，峰位之比为 $\rho_p = p_1/p_2$。

根据 Bragg 定律和平板探测器的几何关系，有

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

成立。由第一个等式的比值得 $\sin\theta_2 = \rho_d \sin\theta_1$，由第二个等式的比值得 $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$。代入 $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$，可得到一个仅以 $\sin\theta_1$ 为未知量的方程：

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

它可归结为关于 $\sin^2\theta_1$ 的三次方程。由于解析求解需要处理虚数，本软件采用**数值方法**求解以获得其值。由于 $\rho_d$ 是 d-spacing 之比，根据晶体对称性（例如立方晶系），它可以无误差地确定。

一旦求得衍射角，相机长度即可通过上述 two-distance method 独立确定，因此波长 $\lambda$ 和像素尺寸 $\mathrm{PixSize}$ 也可以轻松地由上面的两个等式计算出来。

!!! note "When there is a tilt"
    如果 IP 存在倾斜，则关系式 $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ 不再成立，因此无法直接得到准确值。此时应**交替进行倾斜校正与波长校正**，使解迭代收敛至真值。

---

## IP tilt — ellipse fitting

锥角为 $2\theta$ 的衍射环，在未倾斜的 $XY$ 平面上应观察为半径 $R_0 = \mathrm{CL}\tan 2\theta$ 的正圆。然而在倾斜的 IP 上，该衍射环会变成**椭圆**，并且其中心还与束流中心（直射斑点）不重合。

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

在倾斜角为 $\varphi,\ \tau$ 的 IP 平面上，环上的点 $(x,y)$ 满足一般二次曲线（椭圆）

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

系数 $A,B,C,D,E$ 可以写成 $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ 的函数，并可如下用初等线性代数处理。

- **椭圆中心** $(x_c, y_c)$ 是梯度为零这一条件的解，即如下线性方程组的解
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- **长轴与短轴的方向和长度**可通过求解对称矩阵 $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$ 的本征值问题获得。

由此即可如下确定倾斜。

1. **方位角 $\varphi$**：椭圆中心的位移发生在最陡倾斜方向（最大梯度方向）上，而倾斜轴与之正交。因此倾斜轴的方向由 $(-y_c,\ x_c)$ 给出，从而确定 $\varphi$。
2. **倾斜量 $\tau$**：考虑沿 $\varphi$ 方向投影所得的图形（上图），从直射斑点到椭圆中心的距离 $R$ 满足一个关于相机长度、倾斜量和衍射角的函数：

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    对该方程求解 $\tau$。当有多个衍射环可用时，取由各环求得的 $\tau$ 的**加权平均**作为真值。
