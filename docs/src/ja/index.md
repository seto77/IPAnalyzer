<!-- 260601Cl: 英語ホーム (../index.md) を反映し、ランディングページとして再構成 (目的別ガイド / 機能 / クイックスタート)。 -->

# IPAnalyzer マニュアル

## はじめに

* **IPAnalyzer** は、イメージングプレート (IP) や CCD/CMOS フラットパネル検出器で取得した 2 次元粉末回折像（デバイ–シェラー環）を、高精度な 1 次元 2θ–強度プロファイルへ変換する MIT ライセンスのフリーソフトウェアです。
* 標準物質の回折環から測定光学系（カメラ長・波長・検出器の傾き・画素形状）を校正でき、X 線・電子線・中性子線に対応し、その後のピーク解析のために [PDIndexer](https://github.com/seto77/PDIndexer) と連携します。
* 設計と機能は、産業技術総合研究所 (AIST) の藤久裕司氏が開発した *PIP* に倣っています。

## 目的別ガイド

| やりたいこと | 最初に読むページ | 次のステップ |
|------|------|------|
| 座標系・幾何の考え方を知る | [概要](0-overview.md) | [プロパティウィンドウ](2-property-windows.md) |
| 画像を読み込み 1 次元化する | [実際の手順](4-procedures.md) | [メインウィンドウ](1-main-window.md)、[プロパティウィンドウ](2-property-windows.md) |
| カメラ長・波長を校正する | [実際の手順](4-procedures.md) | [各種ツール](3-tools.md)、[パラメータ校正（力ずく）](6-find-parameter.md) |
| スポット除外・マルチフレーム処理 | [各種ツール](3-tools.md) | [実際の手順](4-procedures.md) |
| 処理を自動化する | [マクロ](5-macro/index.md) | [組み込み関数](5-macro/1-built-in-functions.md)、[使用例](5-macro/2-examples.md)、[Auto Procedure](3-tools.md) |

## 主な機能

* **多彩なフォーマット対応** : Fuji BAS2000/2500/FDL、Rigaku R-AXIS IV/V、ITEX、Bruker CCD、Rayonix、MAR research、Perkin Elmer、ADSC、RadIcon、Rad-Xcam、HDF5/NeXus、Digital Micrograph 3/4、および一般画像形式。ほとんどの入出力でドラッグ＆ドロップが使えます。
* **1 次元化** : 同心円（散乱角）積算・偏角（方位角／ケーキ）積算・切り開き計算に対応。画素と積算ステップの交差を計算するサブピクセル面積分配アルゴリズムにより、検出器の傾きや平行四辺形画素も正しく扱います。
* **幾何校正** : 波長・カメラ長・画素サイズ／歪み・傾き (φ, τ) をダブルカセット法で精密化するほか、収束しにくいデータ向けの総当たり（力ずく）探索も備えます。
* **画像処理** : ビーム中心の自動検出、単結晶スポットの検出・マスク、回転ぼかし、リング描画、強度テーブルによる検出器校正、幾何情報を保持した IPA 形式保存。
* **マルチフレーム** : HDF5/NeXus などのシーケンシャルデータでフレームの選択・平均・合計が可能。フレームごとのエネルギー情報から波長を自動更新します。
* **自動化** : フォルダ監視の Auto Procedure と、バッチ・スクリプト処理向けの Python ライク[マクロ](5-macro/index.md)。
* **PDIndexer 連携** : クリップボード経由でプロファイルを [PDIndexer](https://github.com/seto77/PDIndexer) に送り、名前付きマクロを呼び出せます。
* **ライト／ダークテーマ** : 画面はライト／ダークの配色モードを選べます。

## 動作環境

| 項目 | 最低 | 推奨 |
|------|------|------|
| OS | [.NET Desktop Runtime 10.0](https://dotnet.microsoft.com/download/dotnet/10.0) が動作する Windows | Windows 11 |
| メモリ | - | 16 GB 以上 |
| CPU | - | 8 コア以上（強度は倍精度で保持され、処理はマルチスレッド化されています） |

## クイックスタート

1. [Releases](https://github.com/seto77/IPAnalyzer/releases/latest) からインストーラを入手してインストールします。
2. 回折像を読み込みます（ファイル → 画像を読込、またはドラッグ＆ドロップ）。
3. プロパティウィンドウで **Wave source** と **Detector condition**（カメラ長・画素サイズ・おおよその中心）を設定します。
4. 中心を検索し、必要ならスポットを除外して、**Get Profile** で 1 次元プロファイルを取得します。
5. 幾何が未知の場合は標準物質から校正します。[実際の手順](4-procedures.md)を参照してください。

詳しい流れは[実際の手順](4-procedures.md)を参照してください。

## このマニュアルについて

この GitHub Pages マニュアルが現行の正本です。左のナビゲーションで章を辿るか、ヘッダーの検索で関数名や UI ラベルを探せます。従来 `IPAnalyzer/doc/` で配布していた Word/HTML/PDF マニュアルを置き換えるものです。

## ライセンス

IPAnalyzer は [MIT ライセンス](https://github.com/seto77/IPAnalyzer/blob/master/LICENSE.md)で配布されています。
