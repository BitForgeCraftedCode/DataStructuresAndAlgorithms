# Building a Log–Log Plot: Predicting the Running Time

## Using Log–Log Plots to Infer Time Complexity

In the previous lecture, we measured the running times of the brute-force Three-Sum algorithm on inputs of 1k, 4k, and 8k integers. The results showed a dramatic non-linear growth, hinting at a high-order polynomial relationship. In this lecture, we learn how to infer the underlying time complexity using a powerful visualization tool: the **log–log plot**.

---

## 1. Why Log–Log Plots?

When running times or input sizes become large, plotting them on a normal (linear) scale becomes impractical. Logarithmic scales solve this. A log–log plot uses logarithmic scales on both axes:

- **X-axis:** `log(n)` — the input size  
- **Y-axis:** `log(T(n))` — the running time

Using logs compresses large values and reveals how the running time grows with `n` in a clear, linear-looking form.

---

## 2. Plotting Experimental Data

We take the measured values:

- `4k → 14 seconds`  
- `8k → 96 seconds`

On a log–log plot, these appear as points `(log n, log T)`. Connecting them, we can analyze the slope of the line.

---

## 3. Computing the Slope

The slope on a log–log plot reveals the exponent in the time complexity function.

Given two points (with `x = input size`, `y = running time`):

```
(x₁, y₁) = (8, 96)
(x₂, y₂) = (4, 14)
```

We compute the slope `k` using base-2 logarithms:

```
k = log₂(y₁ / y₂) / log₂(x₁ / x₂)
```

Plugging in the numbers:

```
log₂(96 / 14) ≈ 3
log₂(8 / 4) = 1
```

So the slope is approximately `3`. This indicates that:

```
T(n) is proportional to n³
```

---

## 4. Where Does the Formula `log T(n) = 3 log n + log a` Come From?

This part often confuses students, so here is a short and precise explanation.

We assume that the running time behaves like a polynomial:

```
T(n) ≈ a · nᵏ
```

Now take the logarithm (base 2, but any base would work):

```
log₂(T(n)) = log₂(a · nᵏ)
            = log₂(a) + log₂(nᵏ)
            = log₂(a) + k · log₂(n)
```

This is just using standard log rules:

- `log(xy) = log x + log y`  
- `log(xᵏ) = k · log x`

On the log–log plot we have:

```
x = log₂(n)
y = log₂(T(n))
```

So the formula becomes:

```
y = kx + log₂(a)
```

This is the equation of a straight line, where:

- `k` is the slope (the exponent of `n` in the original formula)
- `log₂(a)` is the intercept (a constant shift up or down)

So the expression:

```
log T(n) = 3 log n + log a
```

simply says: the slope is approximately 3, hence the algorithm behaves like:

```
T(n) ≈ a · n³
```

So it is just logarithms plus a linear fit on the log–log plot.

---

## 5. Deriving the Formula `T(n) = a·n³`

On the log–log plot, the relationship appears as:

```
log T(n) = 3 log n + log a
```

This rearranges back to the polynomial form:

```
T(n) = a · n³
```

To determine the constant `a`, we plug in a known measurement, for example for 8k:

```
96 = a · (8000)³
```

This yields:

```
a ≈ 1.87 × 10⁻¹⁰
```

---

## 6. Predicting Running Time for Larger Inputs

Now we can estimate runtime for any input. For `n = 16k`:

```
T(16 000) ≈ 18.7 × 10⁻¹¹ × (16 000)³ ≈ 766 seconds
```

`766 seconds` is a little over 12 minutes. When the experiment is actually run, the measured time matches the prediction closely, with only a few percent deviation — typical for real-world benchmarking.

---

## 7. What This Teaches Us

- Log–log plots convert multiplicative relationships into linear ones, making patterns easy to analyze.
- The slope of the line reveals the exponent in the algorithm’s time complexity.
- In our case, slope ≈ 3 → cubic time complexity.
- Once both the exponent and constant are known, we can predict performance for large inputs without running slow experiments.
- The method is useful when benchmarking is expensive or when the input size is too large to test directly.

---

## 8. Key Insight

A log–log plot turns empirical timing data into a mathematical model. This model is independent of specific hardware and reveals the true asymptotic behavior of the algorithm.

This prepares us for the next lecture, where we explore approximations and understand why we focus on the highest-order terms when analyzing algorithmic growth.

---

# Appendix: Clarifications on the Confusing Parts

## A. Why is the slope formula written as ratios?

You normally learn slope as:

```
slope = (y₂ − y₁) / (x₂ − x₁)
```

On a **log–log plot**, the axes are:

```
x = log(n)
y = log(T(n))
```

So the slope becomes:

```
k = [log(T₂) − log(T₁)] / [log(n₂) − log(n₁)]
```

Using log rules:

```
log(a) − log(b) = log(a/b)
```

This turns into:

```
k = log(T₂/T₁) / log(n₂/n₁)
```

So it **is still the normal slope formula** — it just looks different because subtraction of logs becomes division.

---

## B. Why does reversing the order still work?

These two are mathematically identical:

```
(log(T₂) − log(T₁)) / (log(n₂) − log(n₁))
(log(T₁) − log(T₂)) / (log(n₁) − log(n₂))
```

Because both numerator and denominator flip sign, and the negatives cancel. Same slope, same value.

---

## C. Why use log base 2?

**It is not required mathematically.** Any log base gives the same slope.

Base-2 is used because the input sizes double:

```
1k → 2k → 4k → 8k → 16k
```

So:

```
n₂ / n₁ = 2
log₂(2) = 1
```

Which simplifies the slope to:

```
k = log₂(T₂/T₁)
```

Meaning:

> “When input doubles, how many times does runtime multiply?”

If doubling input multiplies time by 8:

```
log₂(8) = 3 → cubic growth
```

So base-2 is chosen for **interpretability**, not necessity.

---

## D. Intuition Summary

- Linear slope = additive growth
- Log–log slope = multiplicative growth law

So instead of measuring:

> “seconds per input”

You are measuring:

> “powers of n per scaling step”

Which directly reveals the algorithm’s time complexity class.

