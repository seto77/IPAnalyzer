本稿はコードから Claude が起こした下書き（2026-11-05）。著者未査読。

# IPAnalyzer マニュアル改訂の下書き（docs/drafts）

現行コード（IPAnalyzer `0392606`、Crystallography `7a435ee`、Crystallography.Controls `0792542`）を読んで書いた、利用マニュアルと計算手法の下書き。公開中の MkDocs マニュアル（`docs/src/<lang>/`）とは別の場所に置いており、`mkdocs.yml` の `docs_dir: src` の外なので公開サイトには出ない。査読後、内容を `docs/src/<lang>/` の各ページへ反映する想定。

ja と en は同名ファイルで内容を対応させている。突き合わせ結果と実装上の疑問点は著者向けの報告なので日本語のみ。

## 報告（日本語のみ）

| ファイル | 内容 |
|---|---|
| [00-audit.md](00-audit.md) | 既存マニュアル・旧資料の棚卸し、既存マニュアルとコードの食い違い（54 項目）、マニュアルに無い機能、日本語 UI 文字列の誤り |
| [implementation-questions.md](implementation-questions.md) | 実装上の疑問点（A: 結果に影響しうる 26 件、B: 失敗・欠落 20 件、C: 軽微 10 件） |

## 下書き

| ja | en | 内容 |
|---|---|---|
| [ja/01-forms.md](ja/01-forms.md) | [en/01-forms.md](en/01-forms.md) | 全フォームの一覧、メニュー・ツールバー・タブの構成、章立て案 |
| [ja/02-operations.md](ja/02-operations.md) | [en/02-operations.md](en/02-operations.md) | 読み込み・表示・マスク・中心・1 次元化・切り開き・シーケンシャル・較正・自動処理の操作手順と設定項目 |
| [ja/03-geometry.md](ja/03-geometry.md) | [en/03-geometry.md](en/03-geometry.md) | 検出器の幾何（座標系、ξ、φ・τ と回転、2θ・χ、Foot、球面補正、Gandolfi） |
| [ja/04-calibration.md](ja/04-calibration.md) | [en/04-calibration.md](en/04-calibration.md) | 標準試料による較正（幾何的較正の各推定式と反復順序、総当たりの評価関数と探索） |
| [ja/05-integration.md](ja/05-integration.md) | [en/05-integration.md](en/05-integration.md) | 積分（ビン、画素の分割、規格化、誤差）、偏光・背景・Kα2・立体角、方位角分割、cake、Unroll、中心検出・スポット検出・回転ぼかし |
| [ja/06-file-formats.md](ja/06-file-formats.md) | [en/06-file-formats.md](en/06-file-formats.md) | 入力画像形式（判定順・画素値・ヘッダ）、マルチフレーム、出力形式（画像・.prm・.mas・プロファイル・PDIndexer 送信） |

## 書き方の約束

- 機能・既定値・式には実装箇所（ファイル名とメソッド名）を添えた。式は実装のとおりに書き、教科書や他ソフトと異なる場合はその旨を書いた。
- UI 文字列は `*.resx` / `*.ja.resx`（および `IPAnalyzerLocalizationData.cs`）の実際の文字列。
- スクリーンショットは撮っていない（既存の `docs/src/assets/cap-*-auto/` を流用できる）。
- 確信の持てない点は各文書末尾の「要確認事項」に置いた（下書き 6 本で計 35 項目）。
- 文献はコード・既存マニュアルにあるものだけ（PIP、藤久氏）。
