本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# 既存マニュアルと現行コードの突き合わせ（2026-11-05）

対象: IPAnalyzer `master`（`0392606`）、Crystallography `7a435ee`、Crystallography.Controls `0792542`（いずれもサブモジュールの固定コミット）。
比較したマニュアル: `docs/src/ja/*.md`（en は ja と同じ構成で内容も対応しているので、ja の行を挙げる。en も同じ箇所を直す必要がある）。
引用は「ページ: 既存の記述」→ 実装箇所 → 実際の動作。コードは読んだだけで、実行はしていない。

## 0. 既存資料の棚卸し

| 資料 | 状態 |
|---|---|
| `docs/src/<11言語>/`（MkDocs、GitHub Pages） | 現行の正本。ja/en は同じ構成。他 9 言語は英語の翻訳 |
| `IPAnalyzer/doc/IPAnalyzerManual(ja).pdf` / `.docx` | 旧日本語マニュアル。Help → Help / ヘルプ が UI 言語 ja のときに開く PDF |
| `IPAnalyzer/doc/IPAnalyzer(en).docx` | **中身は ReciPro のマニュアル**（"ReciPro is a software package…"）。Help → Help が英語 UI で開こうとする `IPAnalyzerManual(en).pdf` はリポジトリに無い |
| `IPAnalyzer/doc/en/IPAnalyzerHelp*.html` | ja フォルダと同一ファイルで、本文は日本語の旧ヘルプ |
| `IPAnalyzer/doc/IPAnalyzerAlgorithm.pdf` | 旧アルゴリズム解説（日本語。フォントの埋め込みのためテキスト抽出では文字化け）。付録 A1〜A3 の元資料 |
| GitHub Wiki | Home は「GitHub Pages へ移行」の案内。旧 3 ページ（力ずく較正、マクロ関数一覧、マクロ例）は docs/src へ移行済みで、docs の方が正確 |
| `Version.cs` の History | ver3.981（2026/06/25）まで。機能追加の手掛かり（§2） |

## 1. 既存マニュアルの記述がコードと食い違う箇所

### 1.1 index.md / 0-overview.md / README.md

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 1 | 「HDF5/NeXus」「HDF5 などのシーケンシャルデータ」（index、3-tools、README） | `ImageIO.HDF5` | **本体がコメントアウトされ常に `false`**。`.h5` はフィルタにだけ残る。NeXus（`.nxs`）は読める |
| 2 | 「Rad-Xcam」（index、README） | `ImageIO.RadIconSize` | 名前はコードに無い。`.raw` をファイルサイズで判定し、3096×3100 などのサイズ表で読む（Rad-Xcam3030 が どのサイズか要確認） |
| 3 | 「ライト／ダークテーマ: 画面はライト／ダークの配色モードを選べます」（index） | — | アプリにテーマ機能は無い（Wiki ではマニュアル**サイト**のテーマのこと） |
| 4 | 対応形式の列挙（0-overview） | `ImageIO.ReadImage` | Rigaku 2D-PXD / d*TREK、RINT-RAPID II、ADXV、SMV、MRC、gel、mccd、osc、KEK-PF raw、DM3/4、NeXus、BMP/JPG が抜けている（[06-file-formats.md](ja/06-file-formats.md)） |
| 5 | DM3/4 を「Multi-frame / scan data」に分類（README） | `ImageIO.DM` | 先頭の画像 1 枚だけを読む |
| 6 | インストールは MSI のみ（0-overview） | `README-PORTABLE.txt` | ポータブル ZIP（ランタイム同梱）がある（ver3.979） |
| 7 | 画素形状 $\mathrm{PixSizeY}\sin\xi$（0-overview の文意、appendix/a1） | `Ring.SetTiltParameter` ほか | **tan ξ** |
| 8 | 「フレームごとのエネルギー情報から波長を自動更新」（index、3-tools） | `FormSequentialImage.SelectedIndex`、`FormMain.GetProfile` | 1 フレームを選んだときだけ（TIFF タグ 60000）。平均・合計・一括 Get Profile では HDF5 専用分岐のため更新されない |

### 1.2 1-main-window.md

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 9 | 「左ボタン長押し: その付近のスポット中心を検索」 | `FormMain.scalablePictureBox_MouseUp2`（「お蔵入り」） | コメントアウトされ存在しない。左ドラッグはパン |
| 10 | マウス操作の一覧 | `ScalablePictureBox`、`FormMain` | ホイール拡大縮小、中クリック（中心設定 + Find Center）、Ctrl+右ドラッグ（統計範囲）、リングのドラッグ、キーボードショートカット（Ctrl+Shift+F/S/G/B/M/C、Ctrl+矢印）が無い |
| 11 | 手動マスクの「形状（円 / 矩形）とサイズ（8〜256 px）」 | `toolStripComboBoxManualSpotSize`、`numericUpDownManualSpotSize` | コンボは 2〜512（既定 64）、Property 側は $2^n$（$n$=0〜10）。値は半幅。形状は Spot（円/矩形）・Circle・Rectangle・Polygon・Spline |
| 12 | Mask Spots「平均 ± 標準偏差 × Deviation」 | `Ring.FindSpots` | 上側（平均 + k·SD）だけ。リング幅 1 画素。ヒットした画素の周囲半径 3 pix もマスク。k の既定 5 |
| 13 | Find Center「探索範囲は既定 8 px」「ドロップダウンにはリングに基づく中心検出もあります」 | `numericBoxFindCenterSearchArea`、`findCenterBasedOnTheRingToolStripMenuItem` | 8 は**半幅**（17×17 画素のフィット）でレジストリに保存されない。ドロップダウンの項目は非表示・無効。リング基準の中心検出は Draw Ring 表示中に Find Center を押したときに働く |
| 14 | 「バックグラウンド (Background): バックグラウンド画像の減算（Background Option で設定）」 | `toolStripSplitButtonBackground`（resx `Enabled=False`） | ボタンは常に無効。ドロップダウンの Reference image は存在しないタブ 9 を開こうとする。減算は Property タブ 8 だけで設定（Property メニューに項目なし） |
| 15 | Option「反転・回転…いずれも表示の操作で、読み込んだ画像データ自体は変更しません」 | `FormMain.FlipRotate_Pollalization_Background` | 計算に使う `Ring.Intensity` が反転・回転される（ファイルは不変）。画像種別ごとに記憶される |
| 16 | Option「ツールチップ表示の切り替え」「NGEN コンパイル」 | `toolTipToolStripMenuItem`、`ngenCompileToolStripMenuItem` | どちらも実質何もしない（ToolTip はレジストリ保存のみ、Ngen はハンドラ無し） |
| 17 | 言語「英語 / 日本語 を切り替えます」 | `FormMain.PopulateLanguageMenu` | 11 言語（自言語表記）。選択時に確認ダイアログを出して再起動 |
| 18 | ヘルプ「ウェブページ (Web Page)」 | `webPageToolStripMenuItem_Click` | 項目名は Help / ヘルプ で、同梱 PDF を `FormPDF` で開く。オンラインマニュアルは各ウィンドウの F1 |
| 19 | Tool「Reset Frequency Profile: 強度頻度グラフを消去」「R-AXIS補正 (Calibrate Raxis Image)」 | `SetFrequencyProfile`、`calibrateRaxisImageToolStripMenuItem_Click` | 前者は既定範囲で作り直す。後者の日本語 UI は「R-AXIS画像の校正」で、`FormCalibrateIntensity` を開く |
| 20 | ツールバーの日本語名（中心を確定、スポット除外、マニュアル、自動手順、シーケンシャル） | `FormMain.ja.resx` | 実際は 中心固定、スポット検出、マニュアルモード、自動実行、シーケンシャル画像。下部タブも 強度頻度・変換プロファイル |
| 21 | File の Read/Save parameter | `FormMain.SaveParameter`（`fullySave = false` を強制）、`FormParameterOption` | 毎回項目選択ダイアログが出て、既定でチェックされているのは Camera mode と Gandolfi Radius だけ。`.prm` のドロップは全項目読込（Ctrl でダイアログ） |
| 22 | 画像保存「TIFF は元のピクセル強度」 | `saveImageAsTiff` | 反転・回転・背景・偏光補正**後**の値。負値は 0、小数があれば float32 |

### 1.3 2-property-windows.md

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 23 | 「"Background Option" タブなど一部は英語のまま」（en は "The UI of this window is in English"） | `FormProperty.ja.resx` | タブ 8 も「バックグラウンドオプション」に日本語化済み。UI は 11 言語 |
| 24 | 偏光補正「方位角 χ（Miscellaneous タブで定義）」 | `Ring.CorrectPolarization`、`FlipRotate_Pollalization_Background` | 式は一致。χ の**基準方向**だけが効き（Right/Left → 水平偏光、Top/Bottom → 垂直偏光）、回転方向は無関係 |
| 25 | Concentric の横軸「Angle / Length / d-spacing」 | `radioButtonConcentricLength`（`Visible=False`） | Angle と d-spacing だけ |
| 26 | 「Output pattern は Bragg - Brentano または Debye - Scherrer を選べます」 | `IP.IsBraggBrentanoMode` | 値はどこからも参照されず効果なし。Debye - Scherrer は無効表示 |
| 27 | Radial の Donut radius / Donut width | `FormProperty.ja.resx` label46/label40 | 日本語 UI では「リング幅」「リング半径」が逆。Donut width は半幅 |
| 28 | Mask Option「Find Center: 中心検出の探索範囲など」 | `FormProperty` tab 4 | Mask Option タブに中心検出の項目は無い（Miscellaneous にある）。Mask All / Unmask All / Invert、Spot の円/矩形と寸法の記述が無い |
| 29 | After "Get Profile"（保存・送信のみ） | `checkBoxTest` ほか | **Remove Kα2（既定オン、保存されない）**、Send also Unrolled Image、In one file / In separate files が無い。PDI は `.pdi2` |
| 30 | Unrolled「縦方向: 方位角ステップ（°/pixel）。高さ ≈ 360/step」「横方向: 単位（Angle / Length / d-spacing）」 | `numericUpDownUnrollChiDivision`、`FormMain.toolStripSplitButtonUnroll_CheckChanged` | 縦は分割数（= 画像の高さ、既定 720）。横の単位ラジオは読まれず常に 2θ（度） |
| 31 | Miscellaneous「コントラスト・強度範囲の保持」 | `checkBoxMaintainImageRange` | 「描画範囲」= ズーム・パン範囲の維持 |
| 32 | Background Option「端のマスク: 補正時に端へ追加するマスク量（px）」 | `FormProperty` tab 8 | その項目は無い（端の除外は Integral Region の pixels from edges） |
| 33 | Background「現在表示している画像をバックグラウンドに設定」 | `buttonSetBackgroundImage` | 登録されるのは反転・回転前の生データ（減算は反転・回転後に行う） |

### 1.4 3-tools.md

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 34 | 「強度テーブル (Intensity Table): 2 枚の画像…16 個の制御点を 300 回反復」＋画像 FormCalibrateIntensity | `toolStripButtonIntensityTable`（ハンドラ削除） | ツールバーのボタンは何もしない。記述の機能は Tool → R-AXIS画像の校正（`FormCalibrateIntensity`）で、`.stl` 2 枚専用、制御点は約 17、結果はグラフ表示のみ |
| 35 | 「R-AXIS 補正: 現状はファイル読み込みのみで、補正処理は未実装」＋画像 FormCalibrateRAxisImage | `FormCalibrateRAxisImage` | どこからも生成されず到達不能。メニューは上の `FormCalibrateIntensity` を開く。34 と統合すべき |
| 36 | パラメータ校正（幾何学的）「Primary / Secondary の 2 枚のパターンを使い」 | `FormFindParameter` | Secondary は任意（1 枚でも動く）。フォームの日本語タイトルは「パラメータ校正 (代数的)」 |
| 37 | パラメータ校正（力ずく）「カメラ長と波長を…総当たり」「結晶パラメータの入力には CrystalControl」 | `FormFindParameterBruteForce` | 探索対象はカメラ長・中心 X/Y・φ・τ・波長（波長は既定オフ）。Gandolfi タブもある。標準は Au/CeO₂/LaB₆/Al₂O₃/Other で、CrystalControl は Other のときだけ有効 |
| 38 | マクロ「サンプルマクロが同梱され」（3-tools、5-macro/index、2-examples） | `FormMacro.cs`（自動挿入を削除）、`Macro._sampleMacros` | リストが空のとき自動挿入はされなくなった。Show samples チェックで読み取り専用表示（10 本） |
| 39 | 回転ぼかし、IPA 保存 | `FormBlurAngle`、`FormSaveImage`、`Ring.GetCorrectedImageArray` | 記述は正しいが、範囲・既定値（0.01〜10°・1°、1000×1000・100 µm・中心 500）、IPA でマスク・球面補正・Gandolfi が無視される点が無い |

### 1.5 4-procedures.md / 6-find-parameter.md / appendix

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 40 | 総当たり「Primary・Secondary 画像…を読み込みます」「探索範囲（最小・最大・ステップ）」「未知のパラメータ（ピクセルサイズ・傾き）は最初はオフ」「残差が最小になった組み合わせをメインフォームへ反映」 | `FormFindParameterBruteForce` | Primary/Secondary は無く、メイン画面の 1 枚を使う。入力は Initial step と ±N（Search range）。平面検出器では画素サイズは探索できず、φ・τ は既定オン。最良値はサイクルごとに自動でメイン画面に書き込まれる |
| 41 | 幾何校正「各画像 1 本以上、できれば 3 本以上」「Refinement Option」「残差が安定したら…反映」 | `FormFindParameter.RefineParameters` | 各画像 3 本以上が必須（満たさないと何もしない）。グループ名は Refined Parameter / オプション で、中心位置・球面補正もある。Refine! は Repetition（既定 12）回で自動停止、反映は「Refined parameters => Main form」ボタン |
| 42 | 6-find-parameter「ピークが鋭い（＝半値幅が小さい）」「d 値のずれが小さい」、評価値 R の式（画像） | `evaluatePeakHeightAndTwoTheta` | $R = 1000[\sum(2\theta_\text{calc}-2\theta_\text{fit})^2 + W/\sum H]$。半値幅の項は無く、ずれは 2θ（度）。Weight $W$（既定 100）の説明が無い |
| 43 | 6-find-parameter「ステップを 0.8 倍」「ベスト 5」「そのサイクル内でベスト」 | `nextStep`、`report` | 1–1.3–1.8–2.4–3.2–4.2–5.6–7.5 系列で一段下げる（約 ×0.75）。全パラメータが不変のときだけ。表示は上位 4 個で全サイクル通し |
| 44 | 6-find-parameter（Gandolfi の記述なし）、λ のステップ | `buttonOptimizeGandolfi_Click`、`buttonOptimizeSacla_Click` | Gandolfi タブの探索がある。λ の刻みは入力値（Å）× 0.1（nm） |
| 45 | a2「カメラ長…最初に決めるべきパラメータ」「回折角が求まれば…画素サイズも容易に計算」 | `RefineParameters`、`Geometry.GetPixelShape` | 実装の順序は λ → カメラ長 → 傾き → 球面 → 画素。Refine! の画素サイズ・ξ は 2 線法ではなく、各リングの 2 次曲線のアフィン分解から求める（2 線法の画素サイズは Get Wave Length ボタンのみ） |
| 46 | a2「楕円の…長軸・短軸の方向と長さは固有値問題を解いて求めます」「τ をリングごとに求めて加重平均」 | `Geometry.GetTiltAndOffset` | 固有値分解は較正に使われない（リング描画のみ）。τ は全リングの中心に対する（中心位置 B, Δτ）の 2 次元格子最小二乗で、ビーム中心のずれも同時に求め、現在の傾きに回転行列で合成する |
| 47 | a2 に無い | `FindSphericalCorrection`、`SetCenterPosition` ほか | 球面補正の推定、ξ、中心の更新（±1 pix/回）、方位分割（Division、Sector/Rectangle）、ピーク関数、棄却規則（1 mm、5 方向、8 点）、残差の定義が無い |
| 48 | a3「各画素の内部ではステップ境界の円弧を直線として近似」 | `Ring.GetProfileThreadWithTiltCorrectionNew` | 正しい。ただし（Angle/d モードでは）画素ごとの gnomonic 接平面で切り分け、**立体角で規格化**している点が書かれていない。Length モードは旧方式で画素面積で規格化（[05-integration.md](ja/05-integration.md)） |
| 49 | 4-procedures「方位角ごとの解析を行う場合は Integral Property の Radial integration」 | `toolStripMenuItemAzimuthalDivisionAnalysis` | 方位角分割解析（Get Profile ドロップダウン）の方が該当。マニュアルに説明が無い |

### 1.6 5-macro

| # | 既存の記述 | 実装 | 実際 |
|---|---|---|---|
| 50 | `IPA.Profile.GetProfile(filename)` の例で `"xxx.csv"` を渡す | `Macro.ProfileClass.GetProfile` → `FormMain.SaveProfile` | 拡張子は常に付加されるので `*.csv.csv` になる。保存オプションも強制的にオン。「保存の度に指定」ならダイアログも出る |
| 51 | 「ファイル名を省略、または不正な場合はダイアログ」 | 各 Read/Save | ダイアログは空文字のときだけ（ReadImage は存在しないパスでも） |
| 52 | `ReadImageHDF(filename, flag)` | `Macro.FileClass.ReadImageHDF` | 引数に既定値あり。HDF5 自体が読めない（#1） |
| 53 | `IPA.PDI.RunMacro` 「PDIndexer のマクロを実行」 | `Macro.PDIClass.RunMacro` | `RunMacro("", obj)` が自分自身を呼び無限再帰 |
| 54 | `AzimuthalDivisionNumber` 「設定します」 | `Macro.ProfileClass` | 取得も可 |

## 2. マニュアルに無い機能（Version.cs の履歴と照合）

| ver | 内容 | 実装 |
|---|---|---|
| 3.981 | 11 言語の GUI、言語切替時の再起動 | `PopulateLanguageMenu`、`RestartApplicationForLanguageChange` |
| 3.980 | Rigaku 2D-PXD / d*TREK 拡張 `.img` | `ImageIO.IsRigakuPXD`、`RigakuPXD` |
| 3.979 | ポータブル ZIP | `README-PORTABLE.txt`（ポータブル版では Program Updates を隠す） |
| 3.978 | Auto Procedure のキーワード照合（部分一致・大文字小文字区別、番号照合と AND） | `FormAutoProcedure` |
| 3.975 / 3.961 | Rad-Xcam3030、Rad-icon 2080×2238 ほかのサイズ一覧 | `ImageIO.RadIconSize` |
| 3.946 | プロファイル形式 `.pdi2` | `FormMain.SaveProfile` |
| 3.940 / 3.953 | 方位角分割解析 | `FormMain.GetProfile`（LPO 分岐） |
| 3.936 / 3.947 | ADXV の `.img` | `ImageIO.ADXV` |
| 3.915 | GSAS 出力（FXYE、センチ度） | `Profile.ToGSAS` |
| 3.890 | 32 bit 符号付き TIFF、負画素の自動マスク | `ImageIO.Tiff`、`FormMain.ReadImage` |
| 3.901 / 3.872 | KEK-PF raw、Dexela `.smv`（マルチフレーム）、MRC | `ImageIO.RadIcon`、`SMV`、`MRC` |
| 3.85 | 回転と、その画像種別ごとの記憶 | `FormProperty.SetParameterFromImageType` |
| 3.82 | パラメータ保存の項目選択 | `FormParameterOption` |
| 3.35 | 切り開き画像の PDIndexer 送信 | `checkBoxSendUnrolledImageToPDIndexer` |
| （記載なし） | **Kα2 除去（既定オン）** | `checkBoxTest`、`DiffractionProfile2.RemoveKalpha2` |
| （記載なし） | 画像種別ごとのパラメータ記憶（レジストリ） | `FormProperty.ImageTypeParameters` |
| （記載なし） | DM3/DM4 の加速電圧・画素サイズ・カメラ長の自動設定（20 % 規則） | `FormMain.ReadImage` |
| （記載なし） | TIFF 独自タグ 60000/60001/60002、パルス強度規格化 | `ImageIO.Tiff` |
| （記載なし） | Find Parameter の 1 枚モード、Get Camera Length / Get Wave Length、標準試料を使わないモード、Check peaks の自動条件 | `FormFindParameter` |
| （記載なし） | 総当たり較正の Gandolfi タブ、Weight | `FormFindParameterBruteForce` |
| （記載なし） | Ctrl+Shift ショートカット、Ctrl+矢印のファイル／フレーム送り、Ctrl+Shift+C のクリップボード複写 | `FormMain_KeyDown` |
| （記載なし） | 各ウィンドウの F1 でオンラインマニュアル | `FormBase.HelpPage` |
| （記載なし） | マクロメニューに保存マクロが並ぶ | `SetMacroToMenu` |

UI 上に残るが機能しないもの: Intensity table ボタン、Background ボタン、Find center based on the ring、Ngen Compile、ToolTip、Output pattern、Unrolled の単位ラジオ、総当たりの画素サイズ（平面）と Square pixel、`FormCalibrateRAxisImage`、`FormAboutMe`。

## 3. 日本語 UI 文字列の誤り（マニュアル執筆時に注意）

- Integral Property: Donut radius → 「リング幅」、Donut width → 「リング半径」（逆）。
- Mask Option の Spot: 「右/左クリック: 追加/削除」（実装は左 = 追加、右 = 削除）。
- After "Get Profile" の label27: スプライン操作の説明文が入っている（英語は「(for sequential image or azimuthal division)」）。
- Find Parameter の結果欄: label60/79/80 の φ・τ・メイン/サブが英語と食い違う。
- 英語 UI の綴り: "Liner Scale", "Over intenstiy of", "Keyowrd", "Repitition", "Thereshold", "Band wdth", "Reflesh", "Pimary"/"Prmary", "Wave propety"。

## 4. 実装上の疑問点

[implementation-questions.md](implementation-questions.md) に分けて記載した。
