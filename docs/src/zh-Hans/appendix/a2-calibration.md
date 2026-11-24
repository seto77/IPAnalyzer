<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# 附录 A2. 参数确定

由于每个像素的位置由 [A1. 探测器几何](a1-geometry.md) 中的几何关系决定，使用不正确的参数就意味着在错误的位置读取强度。本页说明如何根据 **标准物质** 的衍射环确定真实的参数——相机长度、波长、像素尺寸和 IP 倾斜。实际操作请参见 [4. 操作步骤](../4-procedures.md) 和 [6. 查找参数（暴力搜索）](../6-find-parameter.md)。

---

## 标准物质

校准时需测量晶格常数已知的标准物质。理想的条件是：**衍射环多**、**SN 比高**、衍射环分布 **稀疏**，并且 **没有择优取向**。若无特别偏好，推荐使用 $\mathrm{CeO_2}$ 或 $\mathrm{Ag}$ 等含重原子的立方晶体。晶格常数需要已知到约 5 位有效数字。

---

## 相机长度——双距离法

相机长度 $\mathrm{CL}$ 定义为连接样品与 IP 上直射斑点的距离。若在改变相机长度 $\Delta$ 的条件下拍摄两幅衍射图样，就可以根据同一圆环半径 $r_1,\ r_2$ 的变化确定 $\mathrm{CL}$ 的绝对值。距离差 $\Delta$ 可以用 Magnescale 等装置精确控制。

![Two-distance determination of the camera length. The same ring is recorded at two positions, distances CL and CL+Δ from the sample, and CL is obtained from the radii r₁, r₂.](../../assets/references/calibration-camera-length.svg){width=440px}

由相似三角形 $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$（$r_i$ 与 $\mathrm{CL}$ 使用相同的长度单位），可得

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

这里 $r_1,\ r_2$ 可以保持为像素单位，即使倾斜校正和像素尺寸校正略有偏差，甚至标准物质的晶格常数不准确，也能求出相机长度。由于相机长度与其他参数的相关性很小，它是 **应当最先确定的参数**。

---

## 波长与像素尺寸——双谱线法

若能记录两条衍射线，则无需知道像素尺寸和相机长度，即可根据它们的峰位置（以像素计）$p_1,\ p_2$ 之比以及 d 间距 $d_1,\ d_2$ 计算 Bragg 角 $\theta_1,\ \theta_2$。设 d 间距之比为 $\rho_d = d_1/d_2$，峰位置之比为 $\rho_p = p_1/p_2$。

由 Bragg 定律和平板探测器的几何关系，

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

成立。由第一个式子之比得 $\sin\theta_2 = \rho_d \sin\theta_1$，由第二个式子之比得 $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$。代入 $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$，得到唯一未知数为 $\sin\theta_1$ 的方程：

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

它可化为关于 $\sin^2\theta_1$ 的三次方程。由于解析求解需要处理虚数，本软件以 **数值方法** 求解得到其值。由于 $\rho_d$ 是 d 间距之比，根据晶体的对称性（例如立方晶系），它可以无误差地确定。

求得衍射角后，由于相机长度可以用上述双距离法独立确定，波长 $\lambda$ 和像素尺寸 $\mathrm{PixSize}$ 也可以由上面两个式子轻松算出。

!!! note "存在倾斜时"
    若 IP 存在倾斜，关系式 $p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ 不再成立，因此无法直接得到准确值。此时应 **交替进行倾斜校正和波长校正**，使解迭代地收敛到真值。

---

## IP 倾斜——椭圆拟合

锥角为 $2\theta$ 的圆环在未倾斜的 $XY$ 平面上应被观测为半径 $R_0 = \mathrm{CL}\tan 2\theta$ 的正圆。然而在倾斜的 IP 上，圆环会变成 **椭圆**，而且其中心与束流中心（直射斑点）不重合。

![On a tilted IP the diffraction ring becomes an ellipse, and its center is offset from the direct spot (projection viewed along the φ direction).](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

在倾斜了 $\varphi,\ \tau$ 的 IP 平面上，圆环上的点 $(x,y)$ 满足一般的二次曲线（椭圆）方程

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

系数 $A,B,C,D,E$ 可以写成 $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ 的函数，并可如下用初等线性代数处理。

- **椭圆中心** $(x_c, y_c)$ 是梯度为零这一条件的解，即联立线性方程组
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- **长轴和短轴的方向与长度** 可通过求解对称矩阵 $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$ 的本征值问题得到。

由此按如下方式确定倾斜。

1. **方位角 $\varphi$**：椭圆中心的位移沿最陡倾斜方向（最大梯度方向）发生，倾斜轴与之正交。因此倾斜轴的方向由 $(-y_c,\ x_c)$ 给出，由此确定 $\varphi$。
2. **倾斜大小 $\tau$**：考虑沿 $\varphi$ 方向投影的图形（上图），从直射斑点到椭圆中心的距离 $R$ 满足关于相机长度、倾斜大小和衍射角的函数：

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    对 $\tau$ 求解该方程。有多个衍射环时，取由各圆环求得的 $\tau$ 的 **加权平均** 作为真值。
