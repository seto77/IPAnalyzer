<!-- 261124Cl: Retranslated from en/appendix/a2-calibration.md (UI labels follow the localized GUI). -->

# 附錄 A2. 參數決定

由於每個像素的位置取決於 [A1. 偵測器幾何](a1-geometry.md) 的幾何關係，使用不正確的參數就意味著在錯誤的位置讀取強度。本頁說明如何從 **標準物質** 的繞射環決定真正的參數——相機長度、波長、像素尺寸與 IP 傾斜。實際的操作請參見 [4. 操作步驟](../4-procedures.md) 與 [6. 尋找參數（暴力搜尋）](../6-find-parameter.md)。

---

## 標準物質

校正時，需量測晶格常數已知的標準物質。理想的條件是 **繞射環數量多**、**S/N 比高**、各環 **分布稀疏**，且 **沒有優選方位**。若無特別偏好，建議使用含重原子的立方晶，例如 $\mathrm{CeO_2}$ 或 $\mathrm{Ag}$。晶格常數必須已知至約 5 位有效數字。

---

## 相機長度——雙距離法

相機長度 $\mathrm{CL}$ 定義為連接試料與 IP 上直射點的距離。若在改變相機長度 $\Delta$ 的情況下拍攝兩張繞射圖樣，就能從同一個環的半徑 $r_1,\ r_2$ 的變化決定 $\mathrm{CL}$ 的絕對值。距離差 $\Delta$ 可以用 Magnescale 等裝置精確控制。

![以雙距離法決定相機長度。在與試料相距 CL 與 CL+Δ 的兩個位置記錄同一個環，並由半徑 r₁、r₂ 求出 CL。](../../assets/references/calibration-camera-length.svg){width=440px}

由相似三角形 $\dfrac{r_1}{\mathrm{CL}} = \dfrac{r_2}{\mathrm{CL}+\Delta} = \tan 2\theta$（$r_i$ 與 $\mathrm{CL}$ 使用相同的長度單位），可得

$$
\mathrm{CL} = \frac{r_1\,\Delta}{r_2 - r_1}
$$

此處 $r_1,\ r_2$ 可維持以像素為單位；即使傾斜校正與像素尺寸校正略有不準，甚至標準物質的晶格常數不準確，也能求得相機長度。由於相機長度與其他參數的相關性很小，它是 **應最先決定的參數**。

---

## 波長與像素尺寸——雙譜線法

若能記錄兩條繞射線，就可以在不知道像素尺寸與相機長度的情況下，由其峰位置（以像素計）$p_1,\ p_2$ 的比值與 d 間距 $d_1,\ d_2$ 計算 Bragg 角 $\theta_1,\ \theta_2$。令 d 間距比為 $\rho_d = d_1/d_2$，峰位置比為 $\rho_p = p_1/p_2$。

由 Bragg 定律與平面偵測器的幾何，

$$
2 d_i \sin\theta_i = \lambda \quad(i=1,2), \qquad p_i \cdot \mathrm{PixSize} = \mathrm{CL}\,\tan 2\theta_i
$$

成立。由第一式的比值可得 $\sin\theta_2 = \rho_d \sin\theta_1$，由第二式的比值可得 $\rho_p = \tan 2\theta_1 / \tan 2\theta_2$。代入 $\tan 2\theta = \dfrac{2\sin\theta\sqrt{1-\sin^2\theta}}{1-2\sin^2\theta}$，即得到唯一未知數為 $\sin\theta_1$ 的方程式：

$$
\rho_p = \frac{\sqrt{1-\sin^2\theta_1}\,\big(1 - 2\rho_d^2\sin^2\theta_1\big)}{\rho_d\,\sqrt{1-\rho_d^2\sin^2\theta_1}\,\big(1 - 2\sin^2\theta_1\big)}
$$

這可化為 $\sin^2\theta_1$ 的三次方程式。由於解析求解需要處理虛數，本軟體以 **數值方法** 求解以得到其值。由於 $\rho_d$ 是 d 間距的比值，視晶體的對稱性而定（例如立方晶系），可以毫無誤差地決定。

一旦求得繞射角，相機長度即可由上述的雙距離法獨立決定，因此波長 $\lambda$ 與像素尺寸 $\mathrm{PixSize}$ 也能由上面兩式輕易算出。

!!! note "有傾斜時"
    若 IP 有傾斜，$p_i \cdot \mathrm{PixSize} = \mathrm{CL}\tan 2\theta_i$ 的關係便不成立，因此無法直接求得正確的值。此時請 **交替進行傾斜校正與波長校正**，以反覆運算使解收斂至真值。

---

## IP 傾斜——橢圓擬合

錐角為 $2\theta$ 的環，在未傾斜的 $XY$ 平面上應被觀測為半徑 $R_0 = \mathrm{CL}\tan 2\theta$ 的正圓。然而在傾斜的 IP 上，環會變成 **橢圓**，而且其中心與束流中心（直射點）並不一致。

![在傾斜的 IP 上，繞射環會變成橢圓，且其中心偏離直射點（沿 φ 方向觀看的投影）。](../../assets/references/calibration-tilt-ellipse.svg){width=460px}

在傾斜 $\varphi,\ \tau$ 的 IP 平面上，環上的一點 $(x,y)$ 滿足一般的二次曲線（橢圓）方程式

$$
A x^2 + 2 B xy + C y^2 + D x + E y = 1
$$

係數 $A,B,C,D,E$ 可寫為 $\varphi,\ \tau,\ \mathrm{CL},\ R_0$ 的函數，並可用如下的基礎線性代數處理。

- **橢圓的中心** $(x_c, y_c)$ 是梯度為零之條件的解，亦即聯立一次方程式
  $$
  \begin{pmatrix} A & B \\ B & C \end{pmatrix}\begin{pmatrix} x_c \\ y_c \end{pmatrix} = -\frac{1}{2}\begin{pmatrix} D \\ E \end{pmatrix}
  $$
- **長軸與短軸的方向與長度**，可藉由求解對稱矩陣 $\begin{pmatrix} A & B \\ B & C \end{pmatrix}$ 的特徵值問題而得。

由此，傾斜依下列方式決定。

1. **方位角 $\varphi$**：橢圓中心的位移發生在傾斜最陡的方向（最大梯度方向），而傾斜軸與其正交。因此傾斜軸的方向由 $(-y_c,\ x_c)$ 給出，並由此決定 $\varphi$。
2. **傾斜量 $\tau$**：考慮沿 $\varphi$ 方向投影的圖形（上圖），從直射點到橢圓中心的距離 $R$ 滿足下列由相機長度、傾斜量與繞射角構成的函數：

    $$
    R = \frac{\mathrm{CL}\,\sin 2\theta}{2}\left( \frac{1}{\cos(2\theta+\tau)} - \frac{1}{\cos(2\theta-\tau)} \right)
    $$

    將此方程式對 $\tau$ 求解。若有多個繞射環，則取由各環求得之 $\tau$ 的 **加權平均** 作為真值。
