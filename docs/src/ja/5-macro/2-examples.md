<!-- 260601Cl 追加: Wiki の Macro-examples を移行。旧 API 名 (FindSpotsBeforeGetProfile) を現行 (MaskSpotsBeforeGetProfile) に更新。 -->

# マクロの使用例

以下の例は、マクロエディタにそのままコピー＆ペーストして使えます。`IPA.File.GetFileNames()` などのダイアログを伴う関数は、実行するとファイル選択画面が開きます。各メンバーの詳細は[組み込み関数](1-built-in-functions.md)を参照してください。

!!! tip
    エディタの保存済みマクロが空のときは、より多くのサンプル（基本ループ・数学関数・幾何設定・方位角分割・マスク・PDIndexer 送信など）が自動で挿入されます。まずはそれらを眺めると書き方が掴めます。

## 複数ファイルを一次元プロファイルに変換して保存（単一画像ファイルの場合）

```python
# 同一フォルダ内の複数ファイルを一次元プロファイルに変換し保存する
# (各ファイルが単一画像を含む場合)

# まずファイル名(複数可)を取得
filelist = IPA.File.GetFileNames()
# filelist を for 文で回す
for filename in filelist:
    # 拡張子が stl の場合
    if filename.endswith('.stl'):
        # ファイルを読み込む
        IPA.File.ReadImage(filename)
        # Get Profile 前に中心検索したい場合は True に
        IPA.Profile.FindCenterBeforeGetProfile = True
        # Get Profile 前にスポットマスクしたい場合は True に
        IPA.Profile.MaskSpotsBeforeGetProfile = True
        # Get Profile 後にプロファイルを保存したい場合は True に
        IPA.Profile.SaveProfileAfterGetProfile = True
        # CSV 形式で保存したい場合は True に (他に SaveProfileAsTSV, SaveProfileAsPDI など)
        IPA.Profile.SaveProfileAsCSV = True
        # Get Profile を実行し、指定したファイル名でプロファイルを保存
        IPA.Profile.GetProfile(filename)
```

## 複数ファイルを一次元プロファイルに変換して保存（複数画像を含むファイルの場合）

```python
# 同一フォルダ内の複数ファイルを一次元プロファイルに変換し保存する
# (各ファイルが複数の画像を含む場合)

# まずファイル名(複数可)を取得
filelist = IPA.File.GetFileNames()
# filelist を for 文で回す
for filename in filelist:
    # 拡張子が his の場合
    if filename.endswith('.his'):
        # ファイルを読み込む
        IPA.File.ReadImage(filename)
        IPA.Profile.FindCenterBeforeGetProfile = True
        IPA.Profile.MaskSpotsBeforeGetProfile = True
        IPA.Profile.SaveProfileAfterGetProfile = True
        IPA.Profile.SaveProfileAsCSV = True
        # 含まれる画像枚数 (IPA.Sequential.Count) だけループ
        for num in range(IPA.Sequential.Count):
            # フレーム番号を指定
            IPA.Sequential.SelectedIndex = num
            # Get Profile を実行し、フレーム番号を付けて保存
            IPA.Profile.GetProfile(filename + '_' + str(num))
```

## 複数ファイル（stl, his など）を一括で TIFF に変換

```python
# 同一フォルダ内の複数ファイル(stl, his など)を一括で TIFF 形式に変換する

# IPA.File.GetFileNames() でファイル(複数可)を取得
filelist = IPA.File.GetFileNames()
# filelist を for 文で回す
for filename in filelist:
    # 拡張子が his の場合
    if filename.endswith('.his'):
        IPA.File.ReadImage(filename)                          # ファイルを読み込む
        IPA.File.SaveImageAsTIFF(filename.replace('.his', '.tif'))  # tif で保存
    # 拡張子が stl の場合
    if filename.endswith('.stl'):
        IPA.File.ReadImage(filename)                          # ファイルを読み込む
        IPA.File.SaveImageAsTIFF(filename.replace('.stl', '.tif'))  # tif で保存
```
