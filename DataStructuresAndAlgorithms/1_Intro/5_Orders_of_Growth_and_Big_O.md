# Order of Growth — Recap

## Orders of Growth and the Big-O Notation

In previous lectures we explored experimental measurements, log–log analysis, and approximations. Now we bring all of this together to understand one of the most fundamental concepts in algorithmics: **orders of growth**. This lecture provides an overview of common growth rates, what they mean in practice, and why the **Big-O notation** is essential for worst-case analysis.

---

## 1. Exponential Growth (e.g., 2ⁿ, 10ⁿ)

Exponential algorithms are the slowest and almost always impractical for large inputs. A classic example is brute-forcing a password by trying all possible combinations. Complexity like `10ⁿ` becomes enormous extremely quickly:

```
n = 20 → 10²⁰ ≈ 100 quintillion possibilities
```

No realistic hardware can handle this.

Unfortunately, some real-world problems currently have no better solutions than exponential-time algorithms (e.g., many NP-complete problems).

---

## 2. Cubic Growth (n³)

You saw cubic behavior in the brute-force Three-Sum problem. Cubic algorithms typically involve three nested loops. Compared to exponential time, cubic is far better, but still often too slow when `n` becomes large.

Even moderate inputs (like `20k` or `50k`) can become infeasible.

---

## 3. Quadratic Growth (n²)

Quadratic algorithms usually involve two nested loops. Classic examples include:

- Selection Sort  
- Insertion Sort

Quadratic algorithms are borderline practical: fine for small or medium inputs, but they scale poorly for large data sets.

---

## 4. Linearithmic Growth (n log n)

This is the first truly good performance class for non-trivial problems. Many efficient algorithms run in `O(n log n)`, especially sorting algorithms:

- Merge Sort  
- Quick Sort *(average case)*

Linearithmic time typically appears in **divide-and-conquer algorithms**, where the input is repeatedly split into halves.

---

## 5. Linear Growth (n)

Linear algorithms are often simple scans over data structures. Running time grows directly in proportion to input size.

Examples:

- Finding the maximum element in an array  
- Computing the sum of all elements

---

## 6. Logarithmic Growth (log n)

Logarithmic growth is one of the best achievable outside of constant-time operations. The canonical example is **binary search**, which halves the input at every step.

Because the work drops so quickly, log-time algorithms scale extremely well — doubling the input increases the running time only by a tiny constant amount.

---

## 7. Constant Growth (1)

Constant time represents operations that do not depend on input size:

- Accessing an array element  
- Simple arithmetic operations

We rarely talk about “constant-time algorithms” because full algorithms contain many operations. Instead, constants are trimmed away when analyzing complexity.

---

## 8. Asymptotic Notation: Big-O, Big-Theta, Big-Omega

Algorithms behave differently depending on the input. For example, Quick Sort can run in:

- Best case  
- Average case  
- Worst case

To describe these behaviors mathematically, we use **asymptotic notation**:

- **Big-O (O)** — upper bound *(worst case)*  
- **Big-Omega (Ω)** — lower bound *(best case)*  
- **Big-Theta (Θ)** — tight bound *(both upper and lower, up to constants)*

In practice, we are almost always interested in the **worst-case behavior**, since it gives a guarantee that the algorithm will never exceed a certain running time. That is why **Big-O** is the most commonly used notation.

---

## 9. Key Insight

The **order of growth**, not the raw number of operations, determines whether an algorithm is scalable.

Hardware improvements can provide speedups of `2×` or `4×`, but switching from a **quadratic** to a **linearithmic** algorithm can give speedups of **thousands or millions**.

This understanding prepares us for analyzing real algorithms later in the course and helps us choose the right strategy for large-scale problems.

