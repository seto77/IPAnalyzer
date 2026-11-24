<!-- 261124Cl: Retranslated from en/6-find-parameter.md (UI labels follow the localized GUI). -->

# 查找参数（暴力搜索）

暴力搜索模式对各参数进行穷举变化（网格搜索），以找出最能满足以下条件的值：

- 计算得到的峰位置与拟合得到的峰位置之间的偏差（以 2θ 计）小，并且
- 峰高（尖锐）。

对于几何法优化难以收敛的不完整圆环或噪声大的数据，该方法十分有效。工具概要请参见[工具](3-tools.md)，基本流程请参见[操作步骤](4-procedures.md)。

## 步骤

1. 载入图像数据和参数，然后单击 **查找参数 (穷举法) (Find Parameter (brute force))**。

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. 选择 **标准物质**。若列表中没有，请选择 **其他 (Other)** 并手动输入。
3. 用 **获取图谱 (Get Profile)** 显示谱线。
4. 双击不希望用于优化的峰线即可将其排除。
5. 设置选项后按 **优化 (Optimize)** 开始优化。

## 选项

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

指定对每个峰进行拟合的角度范围。

### 重复次数

指定优化的循环次数。

### 各参数的选项

对勾选的项目进行优化。各参数以指定的步长（**初始步长 (Initial step)**）在指定的范围（**搜索范围 (Search range)**）内变化。

例如，若相机长度从 100 mm 开始，初始步长 (Initial step) 为 0.05 mm、搜索范围 (Search range) 为 4，则会尝试 9 (= Search range × 2 + 1) 个相机长度：99.80、99.85、99.90、99.95、100.00、100.05、100.10、100.15、100.20 mm。

当各参数的尝试次数为 N1、N2、N3、… 时，每个循环的总尝试次数为 N1 × N2 × N3 × …。在上例中，若四个参数的搜索范围分别为 4、4、3、6，则为 (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 次尝试。也就是说，会尝试 7371 组参数，并从中选出评价值 R（见下文）最小的组合。

!!! warning "警告"
    增大 **搜索范围 (Search range)** 会使尝试次数急剧增加，并延长每个循环的时间。请谨慎使用。

## 状态界面

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

校准过程中会显示如上所示的状态界面。

- **Cycle**：当前的循环编号。一个循环结束时，其中找到的最佳参数组将成为下一个循环的起点。若最佳参数与该循环开始时的参数完全相同，则下一个循环的步长会减小为预设序列（1、1.3、1.8、2.4、3.2、4.2、5.6、7.5 × 10ⁿ）中的下一个较小值（例如 0.05 mm → 0.042 mm）。
- **Current best values**：该时刻的最佳参数。
- **Current steps**：该时刻各参数的步长。
- **No1, No2, …**：搜索开始以来评价值的前 4 名（至少收集到五个不同的值后才显示）。它们起初迅速下降，并随着接近最优值而收敛。

## 评价值 R

评价值 R 按如下方式计算。

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

其中 \(2\theta_{\mathrm{calc},i}\) 是由当前参数计算出的峰 \(i\) 的位置，\(2\theta_{\mathrm{fit},i}\) 是通过拟合谱线得到的位置（均以度为单位），*H* 是扣除背景后的峰高，*W* 是权重（**Weight**，默认 100）。对于平板探测器，公式为：

$$
R = 1000\left[\sum_i \left(2\theta_{\mathrm{calc},i} - 2\theta_{\mathrm{fit},i}\right)^2 + \frac{W}{\sum_i H_i}\right]
$$

位置偏差越小、峰越高（越尖锐），R 就越小。FWHM 本身不用于评价。
