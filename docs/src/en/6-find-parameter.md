<!-- 260601Cl: Reflected from ja/6-find-parameter.md. Migrated from the wiki; screenshots reuse the original wiki uploads (user-images). -->

# Find Parameter (Brute force)

The brute-force mode varies each parameter exhaustively (a grid search) to find the values that best satisfy:

- sharp peaks (i.e. small FWHM), and
- small deviation of the d-values.

It is effective for incomplete rings or noisy data, where geometric optimization struggles to converge. See [Tools](3-tools.md) for an overview of the tool and [Procedures](4-procedures.md) for the basic flow.

## Steps

1. Load the image data and parameters, then click **Find Parameter (brute force)**.

    ![Launching Find Parameter (brute force)](https://user-images.githubusercontent.com/44538886/180194930-bcefbf4f-7b61-4068-96d1-18bb29109411.png)
    ![Brute-force calibration window](../assets/cap-en-auto/FormFindParameterBruteForce.png)

2. Select the **standard material**. If it is not in the list, choose **Others** and enter it manually.
3. Show the profile with **Get profile**.
4. Double-click any peak line you do not want to use for optimization to exclude it.
5. Set the options and press **Optimize** to start the optimization.

## Options

![Option settings](https://user-images.githubusercontent.com/44538886/180196763-e707ea11-5594-4cfe-876b-6d7d28b775e8.png)

### Fitting range

Specifies the angular range fitted for each peak.

### Number of repetitions

Specifies the number of optimization cycles.

### Per-parameter options

Optimization is performed on the checked items. Each parameter moves over the specified range (**Search range**) in the specified step (**Initial step**).

For example, if the camera length starts at 100 mm with an Initial step of 0.05 mm and a Search range of 4, then 9 (= Search range × 2 + 1) camera lengths are tried: 99.80, 99.85, 99.90, 99.95, 100.00, 100.05, 100.10, 100.15, 100.20 mm.

When the trial counts of the parameters are N1, N2, N3, …, the total number of trials per cycle is N1 × N2 × N3 × …. In the example above, with four parameters at Search ranges 4, 4, 3, and 6, this is (4×2+1) × (4×2+1) × (3×2+1) × (6×2+1) = 7371 trials. In other words, 7371 parameter sets are tried, and the combination with the sharpest peaks and smallest d-value deviation is chosen.

!!! warning
    Increasing **Search range** sharply increases the number of trials and lengthens each cycle. Use it with care.

## Status screen

![Status screen](https://user-images.githubusercontent.com/44538886/180197340-efeb9fd5-4e38-4845-939e-1352903502d0.png)

During calibration, a status screen like the one above is shown.

- **Cycle**: the current cycle number. When a cycle finishes, the best parameter set found in it becomes the starting point of the next cycle. If the best parameters are identical to the previous cycle, the step is multiplied by 0.8 for the next cycle.
- **Current best values**: the best parameters at that moment.
- **Current steps**: the step of each parameter at that moment.
- **No1, No2, …**: the best 5 evaluation values in the cycle. They drop quickly at first and converge as the optimum is approached.

## Evaluation value R

The evaluation value R is computed as follows.

![Formula for the evaluation value R](https://user-images.githubusercontent.com/44538886/180198715-04479da0-91dc-489b-b6b5-d80c2f88ea33.png)

Here *H* is the background-subtracted peak height.
