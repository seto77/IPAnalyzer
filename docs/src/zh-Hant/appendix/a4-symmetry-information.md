<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# 附錄 A4. Symmetry Information

**Symmetry Information** 顯示所選晶體之空間群對稱性的詳細資訊，並額外以 *International Tables for Crystallography* Vol. A 的風格繪製對稱元素與一般位置的示意圖。

在 IPAnalyzer 中，此子視窗由 **Crystal window** 開啟（即 [4. Practical procedures](../4-procedures.md) 中用於幾何校正、以及 [6. Find Parameter (brute force)](../6-find-parameter.md) 中所使用的 CrystalControl）。

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

此視窗分為空間群識別區（左上）、含分頁的計算／表格區（右上），以及兩張示意圖（下方）。

---

## 鍵盤與滑鼠快速鍵

此視窗沒有特殊的按鍵或滑鼠組合。<kbd>F1</kbd> 會開啟本手冊頁面，而兩個 **Copy** 按鈕會將對稱元素示意圖與一般位置示意圖放到剪貼簿（以點陣圖形式，或在勾選 **EMF** 時以向量 EMF 形式）。

---

## 空間群識別

左上面板會針對目前的空間群列出：

- **Number**（1–230）與設定索引
- **Crystal System**
- **Point Group**：Hermann–Mauguin (HM) 與 Schoenflies (SF) 符號
- **Space Group**：HM 短符號、HM 完整符號、SF 符號以及 **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

輸入兩個晶面 \((h_1, k_1, l_1)\)、\((h_2, k_2, l_2)\) 或兩個方向指數 \([u_1, v_1, w_1]\)、\([u_2, v_2, w_2]\)，即可得到：

- 每個晶面的 d-spacing／每個軸的長度，
- 兩晶面（或兩軸）之間的夾角，
- **同時垂直於兩晶面的方向指數** 與 **同時垂直於兩軸的晶面指數**。

這些計算會遵循目前晶胞的度規。

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

列出每個 Wyckoff 位置及其多重度、Wyckoff 字母、位置對稱性，以及它是一般位置還是特殊位置。對於有心晶格，晶格平移向量會顯示在標頭列中。

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

由晶格置心以及滑移／螺旋對稱算符所產生的反射條件。

---

## 對稱元素與一般位置示意圖

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

下方的兩個面板以 *International Tables for Crystallography* Vol. A 的記法重現空間群的對稱示意圖。

- **Symmetry elements（左）**：旋轉／螺旋軸、鏡面／滑移面，以及反演中心／旋轉反演點，均以慣用的圖形符號繪製。
  - 對於立方晶系的 \(F\) 晶格，僅顯示晶胞的八分之一（僅左上象限）。
- **General positions（右）**：一般等價位置以圓圈繪製（逗號表示鏡像），並標註其分數座標。
  - 僅對立方晶系，以輔助線連接由三重旋轉軸相關聯的三個圓圈。

示意圖下方的控制項：

- **Direction**（`a` / `b` / `c`）：選擇投影所沿的晶軸。
- **Copy** 將各示意圖以向量影像（**EMF**）或點陣影像（**BMP**）複製到剪貼簿；EMF 可在 PowerPoint 中取消群組並編輯。

---

## 另請參閱

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — 使用標準晶體進行幾何參數校正。
- [6. Find Parameter (brute force)](../6-find-parameter.md)
