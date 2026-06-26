<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter（暴力搜尋）

暴力搜尋模式會窮舉地變動每個參數（網格搜尋），以尋找最能滿足下列條件的數值：

- 尖銳的波峰（即較小的 FWHM），以及
- 較小的 d 值偏差。

對於不完整的環或含雜訊的資料，當幾何最佳化難以收斂時，此模式特別有效。工具的概觀請參見 [Tools](3-tools.md)，基本流程請參見 [Procedures](4-procedures.md)。

## 步驟

1. 載入影像資料與參數，然後按一下 **Find Parameter (brute force)**。

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. 選取 **standard material**。若清單中沒有，請選擇 **Others** 並手動輸入。
3. 以 **Get profile** 顯示曲線。
4. 對任何不想用於最佳化的波峰線雙擊，即可將其排除。
5. 設定選項並按 **Optimize** 開始最佳化。

## 選項

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

指定每個波峰所擬合的角度範圍。

### Number of repetitions

指定最佳化的循環次數。

### Per-parameter options

最佳化會針對勾選的項目進行。每個參數會以指定的步長（**Initial step**）在指定的範圍（**Search range**）內移動。

例如，若相機長度起始於 100 mm，Initial step 為 0.05 mm，Search range 為 4，則會嘗試 9（= Search range × 2 + 1）個相機長度：99.80、99.85、99.90、99.95、100.00、100.05、100.10、100.15、100.20 mm。

當各參數的試驗數為 N1、N2、N3、… 時，每個循環的總試驗數即為 N1 × N2 × N3 × …。在上述例子中，四個參數的 Search range 分別為 4、4、3、6，則為 (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 次試驗。換言之，會嘗試 7371 組參數，並選出波峰最尖銳且 d 值偏差最小的組合。

!!! warning
    增大 **Search range** 會使試驗數急遽增加，並拉長每個循環的時間。請謹慎使用。

## 狀態畫面

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

校正進行期間，會顯示如上所示的狀態畫面。

- **Cycle**：目前的循環編號。當一個循環結束時，該循環中找到的最佳參數組會成為下一個循環的起點。若最佳參數與前一循環完全相同，則下一循環的步長會乘以 0.8。
- **Current best values**：當下的最佳參數。
- **Current steps**：當下各參數的步長。
- **No1, No2, …**：該循環中最佳的 5 個評估值。它們起初會快速下降，並隨著逼近最佳值而收斂。

## 評估值 R

評估值 R 依下式計算。

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

此處 *H* 為扣除背景後的波峰高度。
