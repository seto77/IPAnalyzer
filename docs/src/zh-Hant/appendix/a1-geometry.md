<!-- 260602Cl: Reflected from ja/appendix/a1-geometry.md (lead language: Japanese). -->

# Appendix A1. 偵測器幾何與座標變換

本頁以方程式定義 IPAnalyzer 用來將平板偵測器（IP、CCD/CMOS）上的像素位置對應到繞射角的**座標系、IP 傾斜校正與像素形狀校正**。關於座標系的概觀，另請參閱[附錄首頁](index.md)與 [0. Overview](../0-overview.md)。

---

## 座標系與參數

IPAnalyzer 在內部一致地使用**右手**座標系。

- 將 X 射線或電子束與 IP 相交之點（**direct spot**）取為原點 $(0,0,0)$，並使 $Z$ 軸與束流傳播方向對齊。
- 將樣品視為無限小，並將樣品與原點之間的距離定義為**相機長度** $\mathrm{CL}$。因此樣品位置為 $(0,\ 0,\ -\mathrm{CL})$。
- 當 IP 未傾斜時，$X$ 軸與讀取雷射的掃描方向（影像的向右方向）對齊。因此 $Y$ 軸在螢幕上指向下方。
- 錐角為 $2\theta$ 的繞射環，在未傾斜的 $XY$ 平面上，會被觀測為半徑 $\mathrm{CL}\tan 2\theta$ 的正圓。

![Definition of the coordinate system](../../assets/references/geometry-coordinate-system.png){width=520px}

3D 物體的自由旋轉本質上需要三個軸，但由於 Debye 環的分布在繞 $Z$ 軸旋轉下不變，故 $X$ 軸可任意選取。這移除了一個自由度，因此 IP 傾斜可用**兩個變數** $\varphi,\ \tau$ 表示。

!!! note "與 (WIN)PIP 的對應"
    舊版軟體 PIP 以另一組角度 $(\beta,\ \Phi)$ 表示傾斜。從 $(\beta,\ \Phi)$ 至 IPAnalyzer 的 $(\varphi,\ \tau)$ 的換算為 $(\beta,\ \Phi)\rightarrow(270^\circ-\beta,\ \Phi)$。詳情請參閱 [0. Overview](../0-overview.md) 中的「Relationship with (WIN)PIP」。

---

## IP 傾斜校正

IP 相對於光軸（$Z$ 軸）的傾斜，由一個旋轉表示，其旋轉軸為通過原點且位於 $XY$ 平面內的一條直線。此旋轉可寫為旋轉矩陣 $R = R_2\,R_1\,R_2^{-1}$，此運算是沿著（$R_1$）一個已繞 $Z$ 軸旋轉 $\varphi$（$R_2$）的軸，旋轉 $\tau$。

$$
R_2 = \begin{pmatrix} \cos\varphi & -\sin\varphi & 0 \\ \sin\varphi & \cos\varphi & 0 \\ 0 & 0 & 1 \end{pmatrix},
\qquad
R_1 = \begin{pmatrix} 1 & 0 & 0 \\ 0 & \cos\tau & -\sin\tau \\ 0 & \sin\tau & \cos\tau \end{pmatrix}
$$

這等同於繞著單位向量 $\mathbf{n} = (\cos\varphi,\ \sin\varphi,\ 0)$（其在 $XY$ 平面內與 $X$ 軸夾角為 $\varphi$）旋轉角度 $\tau$，展開後得到

$$
R = R_2\,R_1\,R_2^{-1} =
\begin{pmatrix}
\cos^2\varphi + \cos\tau\,\sin^2\varphi & \cos\varphi\sin\varphi\,(1-\cos\tau) & \sin\varphi\sin\tau \\
\cos\varphi\sin\varphi\,(1-\cos\tau) & \cos^2\varphi\,\cos\tau + \sin^2\varphi & -\cos\varphi\sin\tau \\
-\sin\varphi\sin\tau & \cos\varphi\sin\tau & \cos\tau
\end{pmatrix}
$$

### 正向變換（未傾斜平面 → 傾斜 IP）

未傾斜 $XY$ 平面上的一點 $P_1 = (X,\ Y,\ 0)$，對應到傾斜 IP 上的 $P_2 = R\,P_1$。

$$
P_2 =
\begin{pmatrix}
X\,(\cos^2\varphi + \cos\tau\sin^2\varphi) + Y\,\cos\varphi\sin\varphi\,(1-\cos\tau) \\
X\,\cos\varphi\sin\varphi\,(1-\cos\tau) + Y\,(\cos^2\varphi\cos\tau + \sin^2\varphi) \\
-X\,\sin\varphi\sin\tau + Y\,\cos\varphi\sin\tau
\end{pmatrix}
$$

### 投影（傾斜 IP → 未傾斜平面）

實際所需的是相反方向，亦即「在傾斜 IP 上觀測到的某像素」若無傾斜時所應佔據的 $XY$ 平面座標。這由**中心（透視）投影**給出，即求出連接傾斜 IP 上一點與樣品 $(0,0,-\mathrm{CL})$ 的直線與 $XY$ 平面相交之點 $P_3$。由於這是以樣品為投影中心的射影變換，故得到

$$
P_3 = \frac{\mathrm{CL}}{\mathrm{CL} + (P_2)_z}\,\big((P_2)_x,\ (P_2)_y,\ 0\big)
$$

由於整個傾斜校正是線性的（在齊次座標下為射影）變換，每個像素的位置都能在電腦上快速計算。

---

## 像素形狀校正

IP 的像素形狀被視為一個**平行四邊形**，沿 $X$ 軸長度為 $\mathrm{PixSizeX}$、沿 $Y$ 軸長度為 $\mathrm{PixSizeY}$，並具有偏離直角的量（畸變角）$\xi$。$\xi$ 非零意味著讀取雷射掃描的起始位置存在偏移，且本軟體假設此偏移沿 $Y$ 軸為常數。

從中央像素起算、在 $X$ 方向偏離 $\mathrm{PixNumX}$、在 $Y$ 方向偏離 $\mathrm{PixNumY}$ 的像素，其實際座標 $P$ 由下式給出

$$
P =
\begin{pmatrix} \mathrm{PixSizeX} & \mathrm{PixSizeY}\,\sin\xi & 0 \\ 0 & \mathrm{PixSizeY} & 0 \\ 0 & 0 & 1 \end{pmatrix}
\begin{pmatrix} \mathrm{PixNumX} \\ \mathrm{PixNumY} \\ 0 \end{pmatrix}
=
\begin{pmatrix} \mathrm{PixNumX}\cdot\mathrm{PixSizeX} + \mathrm{PixNumY}\cdot\mathrm{PixSizeY}\,\sin\xi \\ \mathrm{PixNumY}\cdot\mathrm{PixSizeY} \\ 0 \end{pmatrix}
$$

將此像素形狀校正與上述傾斜校正結合，傾斜 IP 上的任一像素都能對應到其在未傾斜 $XY$ 平面上的正確位置。此對應是下一章參數決定以及 [A3. Image integration](a3-image-integration.md) 的基礎。
