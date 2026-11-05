本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# フォーム一覧と章立て（実装準拠）

IPAnalyzer の全ウィンドウ（フォーム）を、開き方・役割・既存マニュアルの対応ページとともに一覧にする。UI 文字列は `*.resx`（英）/ `*.ja.resx`（日）、Localizable=false のフォームは `IPAnalyzer/IPAnalyzerLocalizationData.cs` の実行時翻訳から取った。表記は「英 / 日」。

すべてのフォームは `Crystallography.Controls.FormBase` を継承し、**F1** でオンラインマニュアルの対応ページ（`HelpPage`）を開く（英語は `https://seto77.github.io/IPAnalyzer/<page>/`、他言語は `/IPAnalyzer/<lang>/<page>/`。`FormMain` コンストラクタ）。タイトルに「(F1: Help) / (F1: ヘルプ)」が付く。

## 1. 一覧

| フォーム（クラス） | タイトル 英 / 日 | 開き方 | 役割 | HelpPage |
|---|---|---|---|---|
| `FormMain` | IPAnalyzer | 起動時 | 画像表示、各種演算、メニュー | 1-main-window |
| `FormProperty` | Property / プロパティ | 起動時に表示。Property メニュー（各タブへ直接）、各ドロップダウンの Option | 線源・検出器・積分条件などの全設定（9 タブ） | 2-property-windows |
| `FormParameterOption` | Save checked parameters / Read checked parameters（実行時に上書き） | File → Read parameter / Save parameter、Ctrl を押しながら `.prm` をドロップ | `.prm` の読み書きで対象にする項目の選択 | 2-property-windows |
| `FormAutoProcedure` | Auto Procedure / 自動処理 | 右ツールバー Auto procedure / 自動実行 | フォルダ監視と読み込み後の自動処理 | 3-tools |
| `FormDrawRing` | Draw Ring / リング描画 | 右ツールバー Draw ring / リング描画 | 指定 R・2θ・d のリングを重ね描き。表示中は Find Center がリング基準になる | 3-tools |
| `FormFindParameter` | Find Parameter / パラメータ校正 (代数的) | 右ツールバー Find parameter (geometrically) / パラメータ校正 (幾何学的) | 標準試料による幾何的較正（Primary/Secondary） | 4-procedures |
| `FormFindParameterBruteForce` | Find Parameters (brute force) / パラメータ探索 (総当たり) | 右ツールバー Find parameter (brute force) / パラメータ校正 (力ずく) | 現在の画像による総当たり較正 | 6-find-parameter |
| `FormFindParameterGeometry` | Schematic Diagram / 模式図 | Find Parameter の Schematic diagram / 模式図 | 幾何の模式図（画像のみ） | appendix/a1-geometry |
| `FormFindParameterOption1` | Option / オプション | Find Parameter でマルチフレーム画像を開いたとき | 使うフレーム番号（Select Image No.）の指定 | 3-tools |
| `FormCrystal` | Crystal / 結晶 | Find Parameter の Set crystal / 設定 | 標準結晶の編集（CrystalControl。対称性情報ウィンドウを開ける） | — |
| `FormSequentialImage` | Sequential Image Option / シーケンシャル画像 オプション | 右ツールバー Sequential image / シーケンシャル画像（2 フレーム以上で有効） | フレームの選択・平均・合計、一括処理の対象 | 3-tools |
| `FormSaveImage` | Save IPA Image / IPA画像の保存 | File → Save image → as IPA format | 傾き・歪みを除いた IPA 画像の保存 | 3-tools |
| `FormBlurAngle` | Blur Angle / ぼかし角度 | 右ツールバー Circumferential blur / 回転ぼかし（モーダル） | 円周方向ぼかしの角度入力 | 3-tools |
| `FormCalibrateIntensity` | （タイトル無し） | **Tool → Calibrate Raxis Image / R-AXIS画像の校正** | 同じサイズの R-AXIS `.stl` 2 枚から強度変換表を最適化（結果はグラフ表示のみ） | 3-tools |
| `FormCalibrateRAxisImage` | — | **どこからも生成されない**（到達不能） | 未完成 | 3-tools |
| `FormAboutMe` | About Me / バージョン情報 | **どこからも生成されない** | 旧バージョン情報 | — |
| `FormMacro`（Crystallography.Controls） | Macro | Macro → Editor / 編集 | マクロの編集・実行（API は `IPAnalyzer/Macro.cs`） | 5-macro |
| `CommonDialog`（Crystallography.Controls） | — | 起動時スプラッシュ、Help → Hint / License / Version history | 起動進捗、ヒント、ライセンス、履歴 | — |
| `FormPDF`（Crystallography.Controls） | — | Help → Help / ヘルプ | 同梱 PDF（`<exe>/doc/IPAnalyzerManual(ja|en).pdf`）の表示 | — |

右ツールバーの **Intensity table / 強度テーブル** ボタンはハンドラがコメントアウトされており、押しても何も開かない（`FormMain.cs` 3794 行付近）。

## 2. メインウィンドウの構成

### 2.1 メニュー（`menuStrip`）

| メニュー | 項目（英 / 日） | 動作（ハンドラ） |
|---|---|---|
| File / ファイル | Read image / 画像を読込 | `readImageToolStripMenuItem_Click` |
| | Save image / 画像を保存 → as TIFF format / TIFF形式、as PNG format (preserve brightness, contrast, masked area) / PNG形式 (明るさ・コントラスト・マスク領域を保持)、as CSV format / CSV形式、as IPA format (original format) / IPA形式 (独自形式) | `saveImageAsTiff` / `saveImageAsPng` / `saveImageAsCSV` / `FormSaveImage` |
| | Read parameter / パラメータを読込、Save parameter / パラメータを保存 | 毎回 `FormParameterOption` で項目を選ぶ（既定でチェックされているのは Camera mode と Gandolfi Radius だけ） |
| | Read mask / マスク領域を読込、Save mask / マスク領域を保存、Clear mask / マスクをすべてクリア | `.mas` |
| | Close / 閉じる | |
| Tool / ツール | Reset Frequency Profile / 頻度プロファイルをリセット | 強度頻度ヒストグラムを既定範囲で作り直す（`SetFrequencyProfile`） |
| | Calibrate Raxis Image / R-AXIS画像の校正 | `FormCalibrateIntensity` を開く |
| Property / プロパティ | Wave Source / 線源の設定、Imaging Plate Condition / 検出器の設定、Integral Region / 画像範囲の設定、Integral Property / １次元化の条件、Manual Mask Mode / マスク条件、After "Get Profile" / １次元化後の処理、Unrolled Image Option / 切り開き画像の設定、Miscellaneous / その他 | `FormProperty` のタブ 0〜7 を開く。タブ 8（Background Option）への項目は無い |
| Option / オプション | ToolTip / ツールチップ | レジストリに保存されるだけで、ツールチップの表示は切り替わらない |
| | Flip / 反転 → Horizontally / 水平に反転、Vertically / 垂直に反転；Rotate / 回転（0/90/180/270 deg） | 計算に使う配列も変わる（`FlipRotate_Pollalization_Background`）。画像種別ごとに記憶される |
| | Ngen Compile | ハンドラ無し（何もしない） |
| | Clear registry (check and restart) / レジストリをクリア (チェックで再起動) | チェックしておくと終了時にレジストリを書かずに削除。再起動は自分で行う |
| Language / 言語 | English, 日本語, Deutsch, Français, Español, Português, Italiano, Русский, 简体中文, 繁體中文, 한국어 | 実行時生成（`PopulateLanguageMenu`）。選ぶと確認のうえ再起動 |
| Macro / マクロ | Editor / 編集、保存したマクロ名 | `FormMacro`、`SetMacroToMenu` |
| Help / ヘルプ | Program Updates / プログラムの更新（ポータブル版では非表示）、Hint / ヒント、License / ライセンス、Version history / バージョン履歴、Help / ヘルプ（同梱 PDF） | |

### 2.2 上部の演算ツールバー（`toolStrip2`）

| ボタン（英 / 日） | 動作 | ドロップダウン |
|---|---|---|
| Background / バックグラウンド補正 | **常に無効**（resx で `Enabled=False`） | Reference image / 参照画像（存在しないタブ番号 9 を開こうとする） |
| Find Center / 中心位置 | 2 次元 pseudo-Voigt による中心検出（Draw Ring 表示中はリング基準） | Option / オプション（Miscellaneous タブ）、Find center based on the ring（非表示・無効） |
| Fix Center / 中心固定 | 中心を固定（Find Center、ダブルクリック・中クリックでの中心設定を止める） | |
| Mask Spots / スポット検出 | 同心リングごとの平均 + k·SD を超える画素をマスク | Clear mask / マスクをすべてクリア、Mask all area / 全ての領域をマスクする、Invert mask / マスクを反転、Manual Mode（表示のみ）、Option / オプション（Mask Option タブ） |
| Manual Mode / マニュアルモード | 手動マスクモードの切替。オンで Property ウィンドウを隠す | マスク寸法コンボ（2〜512、既定 64。Spot 形状のときだけ表示） |
| Get Profile / 1次元化 | 1 次元化 | Integral Property / 一次元化方法、Concentric Integration / 散乱角積算、Radial integration / 偏角積算、Integral Region / 積算範囲、Find Center before Get Profile（既定オン）、Mask Spots before Get Profile（既定オフ）、Send profile to PDIndexer（既定オン）、with unrolled image、Azimuthal Division Analysis / 方位角分割解析（分割数 6〜360、既定 60）、Get Profiles for all sequential images、Get Profiles for selected images |

### 2.3 右の縦ツールバー（`toolStrip1`）

Intensity table / 強度テーブル（機能なし）、Auto procedure / 自動実行、Draw ring / リング描画、Find parameter (geometrically) / パラメータ校正 (幾何学的)、Find parameter (brute force) / パラメータ校正 (力ずく)、Unroll image / 切り開き、Circumferential blur / 回転ぼかし、Sequential image / シーケンシャル画像。

### 2.4 その他の領域

- 画像情報（Image Information / 画像情報）: ファイル名、サイズ、ダイナミックレンジ、最大・合計・平均強度、ヘッダのコメント。
- サムネイル: Near center / 中心付近（既定）、Whole image / 全体表示。
- 表示調整: Gradient / ポジ/ネガ（Positive Film / Negative Film）、Brightness scale / 強度スケール（Log Scale / Liner Scale）、Color scale / グレー/カラー（Gray / Cold-Warm / Spectrum / Fire）、Scale line / 目盛（None / Coarse / Medium / Fine）、Auto Contrast / 自動コントラスト（全画素の平均 ∓ 2σ）、Reset Contrast / リセット（0–65535）、倍率ボタン ×1〜×1/16。
- マウス位置の表示: Int. / 強度、R(mm)、2θ、d、c（= χ）、Real Coord.(mm) / 実座標(mm)、Image Coord.(pix) / 画像座標(pix)。
- 下部タブ: Frequency of Intensity / 強度頻度、Converted Profile / 変換プロファイル、Statistical Information / 統計情報（Ctrl + 右ドラッグで範囲指定）。

## 3. Property ウィンドウのタブ

| 番号 | 英 / 日 | 主な内容 |
|---|---|---|
| 0 | Wave source / 線源の設定 | 線源・元素・線・波長、直線偏光補正 |
| 1 | Detector condition / 検出器の設定 | 座標基準（Direct spot / Foot）、検出器タイプ（Flat panel / Gandolfi）、ダイレクトスポット位置、Camera Length 1/2、画素形状、Gandolfi 半径、球面補正、傾き φ・τ |
| 2 | Integral Region / 画像範囲の設定 | 除外画素（マスク・強度閾値・端）、Rectangle（方向・帯幅・角度・中心対称）／Sector（開始・終了角） |
| 3 | Integral Property / 1次元化の条件 | Concentric（Angle / d-spacing。Length は非表示）・Output pattern（効果なし）、Radial（Donut radius / width、Sector angle step） |
| 4 | Mask Option / マスク条件 | 全マスク・解除・反転、半分マスク、手動マスク（Spot / Circle / Rectangle / Polygon / Spline）、マスクの引継ぎ、スポット検出の閾値 |
| 5 | After "Get Profile" / １次元化後の処理 | Kα2 除去（既定オン）、PDIndexer 送信（既定オン）・切り開き画像の同時送信、プロファイル保存（既定オフ。形式・保存先・1 ファイル/別ファイル） |
| 6 | Unrolled Image Option / 切り開き画像の設定 | 縦方向の分割数（既定 720）、横方向の Start/End/Step（2θ のみ有効） |
| 7 | Miscellaneous / その他 | 目盛線、画像名の表示、読み込み時のコントラスト・描画範囲の維持、χ の定義、中心検出の設定 |
| 8 | Background Option / バックグラウンドオプション | 背景画像の登録・消去、係数 |

各タブの項目の意味は [02-operations.md](02-operations.md) に記す。

## 4. 提案する章立て（利用マニュアル）

既存の `docs/src/<lang>/` の章立て（0 概要〜6 力ずく、付録 A1〜A5）を維持し、次を加える案:

1. 「1. メインウィンドウ」にショートカット・マウス操作の完全な表と、画像種別ごとのパラメータ記憶の説明を追加。
2. 「2. プロパティウィンドウ」に Kα2 除去、保存オプション、Unrolled の実際の意味、`FormParameterOption` を追加。
3. 「3. 各種ツール」の強度テーブル／R-AXIS 補正の節を、実装（Tool メニュー → `FormCalibrateIntensity`）に合わせて統合。
4. 「4. 実際の手順」に方位角分割解析の手順を追加、総当たりの手順を 1 枚画像の手順に修正。
5. 付録 A1〜A3 を [03-geometry.md](03-geometry.md)・[04-calibration.md](04-calibration.md)・[05-integration.md](05-integration.md) の内容で改訂し、付録「A6. 対応ファイル形式」（[06-file-formats.md](06-file-formats.md)）を新設。

## 要確認事項

1. Intensity table ボタン、Background ボタン、Ngen Compile、ToolTip、`FormCalibrateRAxisImage`、`FormAboutMe` は UI・コードから外す予定か、マニュアルで「未実装」と書くか。
2. Help → Help が開く英語 PDF（`IPAnalyzerManual(en).pdf`）は配布物に含まれるか（リポジトリには ja の PDF と別製品の en docx しか無い）。
3. 幾何的較正の名称（ツールバー「(幾何学的)」、フォームタイトル「(代数的)」）の統一。
