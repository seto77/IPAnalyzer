<!-- 261124Cl: Retranslated from en/appendix/a5-scattering-factor.md (UI labels follow the localized GUI). (2nd update: synced with en changes) -->

# 부록 A5. 산란 인자

현재 버전에서는 결정의 반사와 구조 인자가 **빔 상호작용 (Beam Interaction)** 창의 **반사 (Reflections)** 탭에 표시됩니다 (이전의 Scattering Factor 창은 이 창으로 대체되었습니다). 이 탭은 선택한 결정의 허용된 결정면 (반사) 을 나열하고, 각각의 **구조 인자**와 회절 강도를 계산합니다. 방사선 종류 (X선, 전자, 중성자) 를 전환할 수 있으므로, 같은 결정의 구조 인자를 회절 기법 사이에서 비교할 수 있습니다.

IPAnalyzer 에서는 매개변수 보정에 사용하는 표준 결정을 정의하는 결정 창 ([매개변수 찾기 (기하학적)](../3-tools.md)에서 **결정 설정 (Set crystal)** 으로 여는 결정 창, 또는 [6. 매개변수 찾기 (전수 탐색)](../6-find-parameter.md)의 결정 패널) 에서 엽니다. **빔 상호작용 (Beam interaction)** 버튼을 누르거나, 결정 패널의 오른쪽 클릭 메뉴에서 **빔 상호작용 (Beam Interaction)** 을 선택합니다.

![빔 상호작용 (Beam Interaction) 창 (반사 (Reflections) 탭)](../../assets/references/beam-interaction-reflections-en.png)

위쪽의 띠에서 입사 빔을 선택하고, 그 아래의 **반사 (Reflections)** 탭에는 반사 목록 (위쪽) 과 같은 반사의 막대 그림 (아래쪽) 이 표시됩니다. 조건이 바뀔 때마다 목록이 즉시 다시 계산됩니다. 다른 탭 (**감쇠 & 수송 (Attenuations & transport)**, **산란 인자 (Scattering factors)**, **형광 (Fluorescence)**) 은 IPAnalyzer 에서는 필요하지 않습니다. 이들에 대해서는 [ReciPro 매뉴얼의 빔 상호작용 (Beam Interaction)](https://seto77.github.io/ReciPro/3-beam-interaction/)을 참조하십시오.

---

## 키보드 및 마우스 단축키

이 창에는 특별한 키나 마우스 조합이 없습니다. <kbd>F1</kbd> 은 이 매뉴얼 페이지를 열고, **복사 (Copy)** 는 반사 표를 스프레드시트에 붙여 넣을 수 있는 텍스트로 내보냅니다.

---

## 빔과 파장

- **X-ray / Electron / Neutron** : 원자 산란 인자는 입사 빔의 종류에 따라 다르므로, 여기서 전환합니다.
- **X-ray** 에서는 **Element** (양극 재료) 와 특성선 (Kα 등) 을 선택하면 그 특성 X선의 파장이 자동으로 설정됩니다.
- **Energy** (keV) 와 **Wavelength** (Å) 는 서로 연동됩니다. 어느 한쪽을 설정하면 다른 쪽이 갱신되며, 둘 다 각 반사의 2θ 계산에 사용됩니다.
- **Unit** (**Å** / **nm**) 은 d-간격 등에 사용하는 길이 단위를 전환합니다.

---

## 반사 (Reflections) 탭의 옵션

- **분말 회절 강도 (브래그-브렌타노 광학계) (Powder diffraction intensities (Bragg-Brentano optics))** : 상대 강도를 분말 회절 (Bragg–Brentano) 강도 $I \propto m\,\lvert F\rvert^2 / V^2 \times L$ 로 계산합니다. 여기서 $m$ 은 다중도, $V$ 는 단위 격자의 부피이며, X선에서는 $L = (1+\cos^2 2\theta)/(\sin 2\theta\,\sin\theta)$ (로렌츠-편광 인자), 전자와 중성자에서는 $L = 1/(\sin 2\theta\,\sin\theta)$ (로렌츠 인자만) 입니다. 빔이 도달할 수 없는 반사 (d < λ/2) 의 강도는 0 이 됩니다. 끄면 구조 인자 강도 $\lvert F\rvert^2$ 가 표시됩니다. 켜면 **등가면 숨기기 (Hide equivalent planes)** 와 **금지면 숨기기 (Hide prohibited planes)** 도 켜지고 회색으로 비활성화됩니다.
- **등가면 숨기기 (Hide equivalent planes)** (기본값 켜짐) : 결정학적으로 등가인 면들을 하나의 항목으로 묶습니다. **Multi.** 열은 이 옵션이 켜져 있는 동안에만 표시됩니다.
- **금지면 숨기기 (Hide prohibited planes)** (기본값 켜짐) : 소멸 규칙에 의해 체계적으로 소멸하는 면을 제외합니다. 이 옵션이 꺼져 있는 동안에는 **Condition** 열에, 소멸하는 각 면을 금지하는 반사 조건이 표시됩니다.
- **d-spacing cutoff >** (기본값 1 Å) : d-간격이 이 값보다 작은 반사를 제외합니다 (길이 단위는 **Unit** 을 따릅니다).

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
| **Condition** | 그 면이 위반하는 소멸 조건 (**금지면 숨기기 (Hide prohibited planes)** 가 꺼져 있을 때만 표시) |

표 아래에는 같은 반사가 막대 패턴으로 그려지며, 강한 피크에는 *hkl* 라벨이 붙습니다. 선택 상자에서 가로축을 **2θ**, **d**, **Q** ($= 4\pi\sin\theta/\lambda$) 중에서 고르고, **Log I** 로 강도축을 선형과 로그 사이에서 전환하며, **Range** 상자로 그릴 범위를 설정합니다.

---

## 클립보드로 복사

**복사 (Copy)** 는 반사 목록을 Excel 같은 스프레드시트에 붙여 넣을 수 있는 텍스트로 클립보드에 복사합니다.

---

## 참고 항목

- [부록 첫 페이지](index.md)
- [4. 작업 절차](../4-procedures.md) — 구조 인자를 계산할 표준 결정의 정의.
- [6. 매개변수 찾기 (전수 탐색)](../6-find-parameter.md)
- [ReciPro 매뉴얼의 빔 상호작용 (Beam Interaction)](https://seto77.github.io/ReciPro/3-beam-interaction/) — 같은 창의 네 탭 전체.
