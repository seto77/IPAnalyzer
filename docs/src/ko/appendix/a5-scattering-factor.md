<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). -->

# 부록 A5. 산란 인자

**Scattering Factor** (산란 인자) 는 선택한 결정의 허용된 결정면 (반사) 을 나열하고, 각각의 **구조 인자**와 회절 강도를 계산합니다. 방사선 종류 (X선, 전자, 중성자) 를 전환할 수 있으므로, 같은 결정의 구조 인자를 회절 기법 사이에서 비교할 수 있습니다.

현재 버전에서는 이 목록이 결정 창의 **빔 상호작용 (Beam interaction)** 에 있는 **반사 (Reflections)** 탭에 있습니다 (원자 산란 인자 자체는 같은 창의 **산란 인자 (Scattering factors)** 탭에 있습니다). 아래에서 설명하는 화면과 항목은 이전의 Scattering Factor 창을 바탕으로 합니다.

IPAnalyzer 에서는 이 하위 창을 **결정 창** ([4. 작업 절차](../4-procedures.md)의 기하 보정과 [6. 매개변수 찾기 (전수 탐색)](../6-find-parameter.md)에서 사용하는 CrystalControl) 에서 엽니다.

![Scattering Factor](../../assets/cap-en-auto/FormScatteringFactor.png)

창 위쪽에 계산 조건이, 아래쪽에 반사 목록이 있습니다. 조건이 바뀔 때마다 목록이 즉시 다시 계산됩니다.

---

## 키보드 및 마우스 단축키

이 창에는 특별한 키나 마우스 조합이 없습니다. <kbd>F1</kbd> 은 이 매뉴얼 페이지를 열고, **Copy to clipboard** 는 반사 표 전체를 스프레드시트에 붙여 넣을 수 있는 텍스트로 내보냅니다.

---

## Wave Length Control (파장 설정)

- **X-ray / Electron / Neutron** : 원자 산란 인자는 입사 빔의 종류에 따라 다르므로, 여기서 전환합니다.
- **X-ray** 에서는 **Element** (양극 재료) 와 특성선 (Kα 등) 을 선택하면 그 특성 X선의 파장이 자동으로 설정됩니다.

![Wave Length Control](../../assets/cap-en-auto/FormScatteringFactor.panel3.waveLengthControl1.png)

- **Energy (keV)** 와 **Wavelength (Å)** 는 서로 연동됩니다.
- 이 에너지 또는 파장은 2θ (회절각) 계산에 사용됩니다. X선에서는 원소와 선 종류의 선택으로도 설정할 수 있습니다.

---

## 표시 및 계산 옵션

- **분말 회절 강도 (브래그-브렌타노 광학계) (Powder Diffraction Intensities (Bragg-Brentano Optics))** : 다중도와 로렌츠-편광 인자를 포함하여, 상대 강도를 분말 회절 (Bragg–Brentano) 강도로 계산합니다. 끄면 구조 인자 강도를 표시합니다.
- **등가면 숨기기 (Hide equivalent planes)** : 결정학적으로 등가인 면들을 하나의 항목으로 묶습니다.
- **금지면 숨기기 (Hide prohibited planes)** : 소멸 규칙에 의해 강도가 0 인 면을 제외합니다.
- **Unit (Å / nm)** : d-간격 등의 길이 단위를 전환합니다.
- **d-Spacing Cutoff** : d-간격이 이 값보다 작은 반사를 제외합니다.

---

## 반사 목록

각 행은 하나의 반사 (또는 대칭 등가인 면들의 묶음) 에 해당합니다.

| 열 | 의미 |
|------|------|
| **h, k, l** | 밀러 지수 |
| **Multi.** | 다중도 (대칭 등가인 면의 수) |
| **d (Å)** | 면간 거리 |
| **q (2π/d)** | 산란 벡터의 크기 |
| **2θ (°)** | 선택한 파장에서의 회절각 |
| **F_real** | 구조 인자의 실수부 |
| **F_inv** | 구조 인자의 허수부 |
| **\|F\|** | 구조 인자의 진폭 ($= \sqrt{F_\text{real}^2 + F_\text{inv}^2}$) |
| **F^2** | 구조 인자 강도 ($\lvert F\rvert^2$) |
| **Rel. Int. (%)** | 가장 강한 반사를 100 으로 한 상대 강도 |

---

## Copy to Clipboard (클립보드로 복사)

**Copy to Clipboard** 는 목록을 Excel 같은 스프레드시트에 붙여 넣을 수 있는 텍스트로 클립보드에 복사합니다.

---

## 참고 항목

- [부록 첫 페이지](index.md)
- [4. 작업 절차](../4-procedures.md) — 구조 인자를 계산할 표준 결정의 정의.
- [6. 매개변수 찾기 (전수 탐색)](../6-find-parameter.md)
