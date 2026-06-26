<!-- 260605Cl: Ported from ReciPro docs/src/en/3-scattering-factor.md into the IPAnalyzer appendix (reflected from ja/appendix/a5). The Scattering Factor window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendix A5. Scattering Factor

**Scattering Factor**는 선택한 결정의 허용된 결정면(반사)을 나열하고, 각각의 **구조 인자**와 회절 강도를 계산합니다. 방사선 종류(X선, 전자, 중성자)를 전환할 수 있으므로, 같은 결정의 구조 인자를 여러 회절 기법에 걸쳐 비교할 수 있습니다.

IPAnalyzer에서는 이 하위 창을 **Crystal window**(기하 보정을 위한 [4. Practical procedures](../4-procedures.md)와 [6. Find Parameter (brute force)](../6-find-parameter.md)에서 사용되는 CrystalControl)에서 엽니다.

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

계산 조건은 창의 상단에, 반사 목록은 하단에 있습니다. 조건이 변경될 때마다 목록은 즉시 다시 계산됩니다.

---

## Keyboard & mouse shortcuts

이 창에는 특별한 키 또는 마우스 조합이 없습니다. <kbd>F1</kbd>은 이 매뉴얼 페이지를 열고, **Copy to clipboard**는 전체 반사 표를 스프레드시트에 붙여넣을 수 있는 텍스트로 내보냅니다.

---

## Wave Length Control

- **X-ray / Electron / Neutron** : 원자 산란 인자는 입사 빔의 종류에 따라 다르므로, 여기서 전환합니다.
- **X-ray**의 경우, **Element**(양극 재료)와 특성선(Kα 등)을 선택하면 해당 특성 X선의 파장이 자동으로 설정됩니다.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)**와 **Wavelength (Å)**는 서로 연동되어 있습니다.
- 이 에너지 또는 파장은 2θ(회절 각)를 계산하는 데 사용됩니다. X선의 경우 원소 및 선 종류 선택을 통해서도 설정할 수 있습니다.

---

## Display & calculation options

- **Powder Diffraction Intensities (Bragg-Brentano Optics)** : 다중도와 Lorentz–편광 인자를 포함하여, 분말 회절(Bragg–Brentano) 강도로서의 상대 강도를 계산합니다. 끄면 구조 인자 강도를 표시합니다.
- **Hide equivalent planes** : 결정학적으로 등가인 면들을 하나의 항목으로 합칩니다.
- **Hide prohibited planes** : 소광 법칙에 의해 강도가 0이 되는 면을 제외합니다.
- **Unit (Å / nm)** : d-spacing 등의 길이 단위를 전환합니다.
- **d-Spacing Cutoff** : 이 값보다 작은 d-spacing을 가진 반사를 제외합니다.

---

## Reflection list

각 행은 하나의 반사(또는 대칭 등가 면의 그룹)에 해당합니다.

| Column | Meaning |
|------|------|
| **h, k, l** | Miller 지수 |
| **Multi.** | 다중도(대칭 등가 면의 개수) |
| **d (Å)** | 면 간격 |
| **q (2π/d)** | 산란 벡터의 크기 |
| **2θ (°)** | 선택한 파장에 대한 회절 각 |
| **F_real** | 구조 인자의 실수부 |
| **F_inv** | 구조 인자의 허수부 |
| **\|F\|** | 구조 인자 진폭 ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | 구조 인자 강도 ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | 가장 강한 반사를 100으로 설정한 상대 강도 |

---

## Copy to Clipboard

**Copy to Clipboard**는 Excel과 같은 스프레드시트에 붙여넣을 수 있는 텍스트로 목록을 클립보드에 복사합니다.

---

## See also

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — 구조 인자가 계산되는 표준 결정을 정의합니다.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
