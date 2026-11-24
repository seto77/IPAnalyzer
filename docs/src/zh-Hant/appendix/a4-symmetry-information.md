<!-- 261124Cl: Retranslated from en/appendix/a4-symmetry-information.md (UI labels follow the localized GUI). -->

# 附錄 A4. 對稱性資訊

**對稱性資訊 (Symmetry Information)** 會顯示所選晶體之空間群對稱性的詳細資訊，並以 *International Tables for Crystallography* Vol. A 的風格繪製對稱元素與一般位置的示意圖。

在 IPAnalyzer 中，此子視窗由 **Crystal window** 開啟（即在 [4. 操作步驟](../4-procedures.md) 的幾何校正以及 [6. 尋找參數（暴力搜尋）](../6-find-parameter.md) 中所使用的 CrystalControl）。

![對稱性資訊](../../assets/cap-en-auto/FormSymmetryInformation.png)

此視窗分為空間群識別區（左上）、含分頁的計算／表格區（右上），以及兩張示意圖（下方）。

---

## 鍵盤與滑鼠快速鍵

此視窗沒有特殊的按鍵或滑鼠組合。<kbd>F1</kbd> 會開啟本手冊頁面，而兩個 **Copy** 按鈕會將對稱元素示意圖與一般位置示意圖放到剪貼簿（以點陣圖形式，或在勾選 **EMF** 時以向量 EMF 形式）。

---

## 空間群識別

左上面板會針對目前的空間群列出：

- **Number**（1–230）與設定 (setting) 索引
- **Crystal System**
- **Point Group**：Hermann–Mauguin (HM) 與 Schoenflies (SF) 符號
- **Space Group**：HM 短符號、HM 完整符號、SF 符號，以及 **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

輸入兩個晶面 \((h_1, k_1, l_1)\)、\((h_2, k_2, l_2)\) 或兩個方向指數 \([u_1, v_1, w_1]\)、\([u_2, v_2, w_2]\)，即可得到：

- 各晶面的 d 間距／各軸的長度，
- 兩晶面（或兩軸）之間的夾角，
- **兩晶面共同的晶帶軸**（兩者交線的方向），以及 **同時包含兩方向的晶面**。

這些計算會依據目前晶胞的度規。

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

列出每個 Wyckoff 位置及其多重度、Wyckoff 字母、位置對稱性，以及它是一般位置還是特殊位置。對於有心晶格，晶格平移向量會顯示在標頭列中。

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

由晶格的有心化以及滑移／螺旋對稱操作所產生的繞射條件。

---

## 對稱元素與一般位置示意圖

![對稱元素與一般位置示意圖](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

下方的兩個面板以 *International Tables for Crystallography* Vol. A 的記法，重現空間群的對稱示意圖。

- **Symmetry elements（左）**：旋轉軸／螺旋軸、鏡面／滑移面，以及反演中心／旋轉反演點，均以慣用的圖形符號繪製。
  - 對於立方晶系的 \(F\) 晶格，只顯示晶胞的八分之一（僅左上象限）。
- **General positions（右）**：一般等價位置以圓圈繪製（逗號表示鏡像），並標註其分數座標。
  - 僅限立方晶系，會以輔助線連接由三重旋轉軸相關聯的三個圓圈。

示意圖下方的控制項：

- **Direction**（`a` / `b` / `c`）：選擇投影所沿的晶軸。
- **Copy**：將各示意圖以向量影像（**EMF**）或點陣影像（**BMP**）複製到剪貼簿；EMF 可在 PowerPoint 中取消群組並編輯。

---

## 另請參見

- [附錄首頁](index.md)
- [4. 操作步驟](../4-procedures.md) — 使用標準晶體進行幾何參數校正。
- [6. 尋找參數（暴力搜尋）](../6-find-parameter.md)
