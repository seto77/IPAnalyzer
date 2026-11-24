<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 附錄 A5. 散射因子

在目前版本中，晶體的繞射與結構因子顯示於 **電子束交互作用 (Beam Interaction)** 視窗的 **繞射 (Reflections)** 分頁（舊版的 Scattering Factor 視窗已由它取代）。此分頁會列出所選晶體允許的晶面（繞射），並計算各晶面的 **結構因子** 與繞射強度。可切換輻射種類（X 射線、電子或中子），因此能在不同的繞射技術之間比較同一晶體的結構因子。

在 IPAnalyzer 中，請從定義參數校正所用標準晶體的晶體視窗開啟它（即在[尋找參數 (幾何法) (Find parameter (geometrically))](../3-tools.md) 中以 **設定晶體 (Set crystal)** 開啟的晶體視窗，或 [6. 尋找參數（暴力搜尋）](../6-find-parameter.md) 的晶體面板）：按下 **電子束交互作用 (Beam interaction)** 按鈕，或從晶體面板的右鍵選單中選擇 **電子束交互作用 (Beam Interaction)**。

![電子束交互作用視窗（繞射分頁）](../../assets/references/beam-interaction-reflections-en.png)

上方的區塊用來選擇入射束，下方的 **繞射 (Reflections)** 分頁則顯示繞射清單（上半部）以及相同繞射的棒狀圖（下半部）。每當條件改變時，清單都會立即重新計算。其他分頁（**衰減 & 輸運 (Attenuations & transport)**、**散射因子 (Scattering factors)**、**螢光 (Fluorescence)**）在 IPAnalyzer 中用不到；相關說明請參見 [ReciPro 手冊中的 Beam Interaction](https://seto77.github.io/ReciPro/3-beam-interaction/)。

---

## 鍵盤與滑鼠快速鍵

此視窗沒有特殊的按鍵或滑鼠組合。<kbd>F1</kbd> 會開啟本手冊頁面，而 **複製 (Copy)** 會將繞射表匯出為可貼到試算表的文字。

---

## 射束與波長

- **X-ray / Electron / Neutron**：原子散射因子依入射束的種類而不同，因此在此切換。
- 對於 **X-ray**，選擇 **Element**（陽極材料）與特性譜線（Kα 等）後，會自動設定該特性 X 射線的波長。
- **Energy**（keV）與 **Wavelength**（Å）彼此連動；設定其中一個即會更新另一個，兩者都用於計算各繞射的 2θ。
- **Unit**（**Å** / **nm**）切換 d 間距等量所使用的長度單位。

---

## 繞射分頁的選項

- **粉末繞射強度（Bragg-Brentano 光路） (Powder diffraction intensities (Bragg-Brentano optics))**：將相對強度計算為粉末繞射（Bragg–Brentano）強度 $I \propto m\,\lvert F\rvert^2 / V^2 \times L$，其中 $m$ 為多重度，$V$ 為晶胞體積；對於 X 射線，$L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$（Lorentz–偏振因子），對於電子與中子，$L = 1/(\sin 2\theta\,\sin\theta)$（僅 Lorentz 因子）。射束無法到達的繞射（d < λ/2）強度為 0。關閉時則顯示結構因子強度 $\lvert F\rvert^2$。開啟此選項時，也會同時開啟 **隱藏等效晶面 (Hide equivalent planes)** 與 **隱藏禁制晶面 (Hide prohibited planes)**，並使其變為灰色（無法操作）。
- **隱藏等效晶面 (Hide equivalent planes)**（預設開啟）：將晶體學上等效的晶面合併為單一項目。**Multi.** 欄只在此選項開啟時顯示。
- **隱藏禁制晶面 (Hide prohibited planes)**（預設開啟）：排除依消光規則而系統性消光的晶面。關閉時，**Condition** 欄會顯示使各消光晶面被禁制的繞射條件。
- **d-spacing cutoff >**（預設 1 Å）：排除 d 間距小於此值的繞射（長度單位依 **Unit** 而定）。

---

## 繞射清單

每一列對應一個繞射（或一組對稱等效的晶面）。

| 欄 | 意義 |
|------|------|
| **h, k, l** | Miller 指數 |
| **Multi.** | 多重度（對稱等效晶面的數目） |
| **d (Å)** | 晶面間距 |
| **q (2π/d)** | 散射向量的大小 |
| **2θ (°)** | 所選波長下的繞射角 |
| **F_real** | 結構因子的實部 |
| **F_inv** | 結構因子的虛部 |
| **\|F\|** | 結構因子的振幅（$= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$） |
| **F^2** | 結構因子強度（$\lvert F\rvert^2$） |
| **Rel. Int. (%)** | 相對強度，以最強的繞射為 100 |
| **Condition** | 該晶面所違反的消光條件（僅在 **隱藏禁制晶面 (Hide prohibited planes)** 關閉時顯示） |

表格下方以棒狀圖繪出相同的繞射，最強的幾個峰會標上其 *hkl*。選擇器可從 **2θ**、**d** 與 **Q**（$= 4\pi\sin\theta/\lambda$）中選擇橫軸，**Log I** 可在線性與對數之間切換強度軸，**Range** 欄位則設定繪圖範圍。

---

## 複製到剪貼簿

**複製 (Copy)** 會將繞射清單以文字形式複製到剪貼簿，可貼到 Excel 等試算表中。

---

## 另請參見

- [附錄首頁](index.md)
- [4. 操作步驟](../4-procedures.md) — 定義要計算結構因子的標準晶體。
- [6. 尋找參數（暴力搜尋）](../6-find-parameter.md)
- [ReciPro 手冊中的 Beam Interaction](https://seto77.github.io/ReciPro/3-beam-interaction/) — 同一視窗的全部四個分頁。
