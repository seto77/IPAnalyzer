<!-- 260605Cl: Ported from ReciPro docs/src/en/2-symmetry-information.md into the IPAnalyzer appendix (reflected from ja/appendix/a4). The Symmetry Information window is a shared Crystallography.Controls component, identical to ReciPro. -->

# Appendix A4. Symmetry Information

**Symmetry Information** 은 선택한 결정의 공간군 대칭에 관한 상세 정보를 표시하며, 추가로 *International Tables for Crystallography* Vol. A 양식으로 대칭 요소와 일반 위치의 모식도를 렌더링합니다.

IPAnalyzer 에서 이 하위 창은 **Crystal window** ([4. Practical procedures](../4-procedures.md) 의 기하 보정 및 [6. Find Parameter (brute force)](../6-find-parameter.md) 에서 사용되는 CrystalControl) 에서 엽니다.

![Symmetry Information](../../assets/cap-en-auto/FormSymmetryInformation.png)

이 창은 공간군 식별 영역(왼쪽 위), 탭이 있는 계산/표 영역(오른쪽 위), 그리고 두 개의 모식도(아래)로 나뉩니다.

---

## Keyboard & mouse shortcuts

이 창에는 특수한 키 또는 마우스 조합이 없습니다. <kbd>F1</kbd> 은 이 매뉴얼 페이지를 열고, 두 개의 **Copy** 버튼은 대칭 요소 도식과 일반 위치 도식을 클립보드에 올립니다(비트맵으로, 또는 **EMF** 가 체크된 경우 벡터 EMF 로).

---

## Space-group identity

왼쪽 위 패널은 현재 공간군에 대해 다음을 나열합니다:

- **Number** (1–230) 와 설정(setting) 인덱스
- **Crystal System**
- **Point Group** : Hermann–Mauguin (HM) 및 Schoenflies (SF) 기호
- **Space Group** : HM short 기호, HM full 기호, SF 기호, 그리고 **Hall symbol**

---

## Geometrics Calculation

![Geometrics Calculation](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageGeometrics.png)

두 결정면 \((h_1, k_1, l_1)\), \((h_2, k_2, l_2)\) 또는 두 방향 지수 \([u_1, v_1, w_1]\), \([u_2, v_2, w_2]\) 를 입력하여 다음을 얻습니다:

- 각 면의 d-spacing / 각 축의 길이,
- 두 면(또는 두 축) 사이의 각도,
- **두 면 모두에 수직인 방향 지수** 및 **두 축 모두에 수직인 면 지수**.

이 계산들은 현재 단위 격자의 metric 을 따릅니다.

---

## Wyckoff Positions

![Wyckoff Positions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageWyckoff.png)

모든 Wyckoff 위치를 그 다중도(multiplicity), Wyckoff 문자, 자리 대칭(site symmetry), 그리고 일반 위치인지 특수 위치인지 여부와 함께 나열합니다. 중심화 격자의 경우, 격자 병진 벡터가 헤더 행에 표시됩니다.

---

## Conditions

![Conditions](../../assets/cap-en-auto/FormSymmetryInformation.panel2.tabControl.tabPageConditions.png)

격자 중심화 및 glide/screw 대칭 연산자로부터 발생하는 반사 조건(reflection conditions).

---

## Symmetry-element & general-position diagrams

![Symmetry-element & general-position diagrams](../../assets/cap-en-auto/FormSymmetryInformation.tableLayoutPanel1.png)

아래의 두 패널은 *International Tables for Crystallography* Vol. A 표기법으로 공간군의 대칭 모식도를 재현합니다.

- **Symmetry elements (left)**: 회전/나선(screw) 축, 거울/glide 면, 그리고 반전 중심/회전반전 점이 관례적 도형 기호로 그려집니다.
  - 입방정계의 \(F\) 격자의 경우, 단위 격자의 8분의 1(왼쪽 위 사분면만)만 표시됩니다.
- **General positions (right)**: 일반 등가 위치가 원(circle)으로 표시되며(쉼표는 거울상을 나타냄), 그 분율 좌표가 주석으로 달립니다.
  - 입방정계에 한해, 보조선이 3회 회전축으로 관련된 세 원을 연결합니다.

도식 아래의 컨트롤:

- **Direction** (`a` / `b` / `c`) : 따라서 투영할 결정축을 선택합니다.
- 각 도식을 벡터 이미지(**EMF**) 또는 래스터 이미지(**BMP**)로 클립보드에 **Copy**; EMF 는 PowerPoint 에서 그룹 해제하여 편집할 수 있습니다.

---

## See also

- [Appendix top](index.md)
- [4. Practical procedures](../4-procedures.md) — 표준 결정을 사용한 기하 매개변수 보정.
- [6. Find Parameter (brute force)](../6-find-parameter.md)
