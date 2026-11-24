<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# 附錄 A5. 散射因子

**Scattering Factor** 會列出所選晶體允許的晶面（繞射），並計算各晶面的 **結構因子** 與繞射強度。可切換輻射種類（X 射線、電子或中子），因此能在不同的繞射技術之間比較同一晶體的結構因子。

在目前版本中，此清單位於晶體視窗中 **電子束交互作用 (Beam interaction)** 的 **繞射 (Reflections)** 分頁（原子散射因子本身則位於同一視窗的 **散射因子 (Scattering factors)** 分頁）。以下說明的畫面與項目，係以舊版的 Scattering Factor 視窗為依據。

在 IPAnalyzer 中，此子視窗由 **Crystal window** 開啟（即在 [4. 操作步驟](../4-procedures.md) 的幾何校正以及 [6. 尋找參數（暴力搜尋）](../6-find-parameter.md) 中所使用的 CrystalControl）。

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

計算條件位於視窗上方，繞射清單位於下方。每當條件改變時，清單都會立即重新計算。

---

## 鍵盤與滑鼠快速鍵

此視窗沒有特殊的按鍵或滑鼠組合。<kbd>F1</kbd> 會開啟本手冊頁面，而 **Copy to clipboard** 會將整個繞射表匯出為可貼到試算表的文字。

---

## Wave Length Control

- **X-ray / Electron / Neutron**：原子散射因子依入射束的種類而不同，因此在此切換。
- 對於 **X-ray**，選擇 **Element**（陽極材料）與特性譜線（Kα 等）後，會自動設定該特性 X 射線的波長。

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** 與 **Wavelength (Å)** 彼此連動。
- 此能量或波長用於計算 2θ（繞射角）。對於 X-ray，也可以透過元素與譜線種類的選擇來設定。

---

## 顯示與計算選項

- **粉末繞射強度（Bragg-Brentano 光路）(Powder Diffraction Intensities (Bragg-Brentano Optics))**：將相對強度計算為粉末繞射（Bragg–Brentano）強度，包含多重度與 Lorentz–偏振因子。關閉時則顯示結構因子強度。
- **隱藏等效晶面 (Hide equivalent planes)**：將晶體學上等效的晶面合併為單一項目。
- **隱藏禁制晶面 (Hide prohibited planes)**：排除依消光規則強度為零的晶面。
- **Unit (Å / nm)**：切換 d 間距等的長度單位。
- **d-Spacing Cutoff**：排除 d 間距小於此值的繞射。

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

---

## Copy to Clipboard

**Copy to Clipboard** 會將清單以文字形式複製到剪貼簿，可貼到 Excel 等試算表中。

---

## 另請參見

- [附錄首頁](index.md)
- [4. 操作步驟](../4-procedures.md) — 定義要計算結構因子的標準晶體。
- [6. 尋找參數（暴力搜尋）](../6-find-parameter.md)
