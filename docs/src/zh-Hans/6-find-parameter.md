<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

暴力搜索模式会穷举式地改变每个参数（网格搜索），以找出最能满足以下条件的取值：

- 尖锐的峰（即较小的 FWHM），以及
- d 值偏差较小。

对于不完整的环或含噪声的数据，几何优化往往难以收敛，此模式在这些情况下很有效。工具的总体介绍见 [Tools](3-tools.md)，基本流程见 [Procedures](4-procedures.md)。

## Steps

1. 载入图像数据和参数，然后点击 **Find Parameter (brute force)**。

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. 选择 **standard material**。如果列表中没有，请选择 **Others** 并手动输入。
3. 用 **Get profile** 显示谱线。
4. 双击任何不想用于优化的峰线，将其排除。
5. 设置选项后按 **Optimize** 开始优化。

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

指定对每个峰进行拟合的角度范围。

### Number of repetitions

指定优化的循环次数。

### Per-parameter options

优化仅对勾选的项目进行。每个参数会以指定的步长（**Initial step**）在指定的范围（**Search range**）内移动。

例如，如果相机长度从 100 mm 开始，Initial step 为 0.05 mm，Search range 为 4，则会尝试 9（= Search range × 2 + 1）个相机长度：99.80、99.85、99.90、99.95、100.00、100.05、100.10、100.15、100.20 mm。

当各参数的尝试次数为 N1、N2、N3、… 时，每个循环的总尝试次数为 N1 × N2 × N3 × …。在上面的例子中，四个参数的 Search range 分别为 4、4、3、6，则为 (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 次尝试。换言之，会尝试 7371 组参数，并选出峰最尖锐、d 值偏差最小的组合。

!!! warning
    增大 **Search range** 会使尝试次数急剧增加，并延长每个循环的时间。请谨慎使用。

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

校准过程中会显示如上所示的状态画面。

- **Cycle**：当前的循环编号。一个循环结束时，在其中找到的最佳参数组将成为下一个循环的起点。如果最佳参数与上一个循环相同，则下一个循环的步长会乘以 0.8。
- **Current best values**：此刻的最佳参数。
- **Current steps**：此刻各参数的步长。
- **No1, No2, …**：循环中评价值最好的前 5 个。它们起初下降很快，随着接近最优值而收敛。

## Evaluation value R

评价值 R 按如下方式计算。

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

其中 *H* 是扣除背景后的峰高。
