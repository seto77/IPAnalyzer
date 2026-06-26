<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendix A5. Scattering Factor

**Scattering Factor** 會列出所選晶體的容許晶面（反射），並計算每個晶面的**結構因子**與繞射強度。輻射類型（X 射線、電子或中子）可以切換，因此可在不同繞射技術之間比較同一晶體的結構因子。

在 IPAnalyzer 中，此子視窗是從 **Crystal window**（在 [4. Practical procedures](../4-procedures.md) 中用於幾何校正、以及在 [6. Find Parameter (brute force)](../6-find-parameter.md) 中使用的 CrystalControl）開啟的。

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

計算條件位於視窗頂部，反射清單位於底部。每當條件變更時，清單會立即重新計算。

---

## Keyboard & mouse shortcuts

此視窗沒有特殊的按鍵或滑鼠組合。<kbd>F1</kbd> 會開啟此手冊頁面，而 **Copy to clipboard** 會將整個反射表格匯出為可貼入試算表的文字。

---

## Wave Length Control

- **X-ray / Electron / Neutron** : 原子散射因子會隨入射束的類型而不同，因此在此處切換。
- 對於 **X-ray**，選擇 **Element**（陽極材料）與特性線（Kα 等）會自動設定該特性 X 射線的波長。

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** 與 **Wavelength (Å)** 彼此連動。
- 此能量或波長用於計算 2θ（繞射角）。對於 X 射線，亦可透過元素與線型的選擇來設定。

---

## Display & calculation options

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : 將相對強度計算為粉末繞射（Bragg–Brentano）強度，包含多重度與 Lorentz–polarization 因子。關閉時則顯示結構因子強度。
- **Hide equivalent planes** : 將晶體學上等價的晶面合併為單一條目。
- **Hide prohibited planes** : 排除依消光規則強度為零的晶面。
- **Unit (Å / nm)** : 切換 d-spacing 等的長度單位。
- **d-Spacing Cutoff** : 排除 d-spacing 小於此值的反射。

---

## Reflection list

每一列對應一個反射（或一組對稱等價的晶面）。

| Column | Meaning |
|------|------|
| **h, k, l** | Miller 指數 |
| **Multi.** | 多重度（對稱等價晶面的數目） |
| **d (Å)** | 晶面間距 |
| **q (2π/d)** | 散射向量的大小 |
| **2θ (°)** | 所選波長下的繞射角 |
| **F_real** | 結構因子的實部 |
| **F_inv** | 結構因子的虛部 |
| **\|F\|** | 結構因子振幅 ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | 結構因子強度 ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | 相對強度，以最強反射設為 100 |

---

## Copy to Clipboard

**Copy to Clipboard** 會將清單以文字形式複製到剪貼簿，可貼入 Excel 等試算表軟體。

---

## See also

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — 定義要計算結構因子的標準晶體。
- [6. Find Parameter (brute force)](../6-find-parameter.md)
