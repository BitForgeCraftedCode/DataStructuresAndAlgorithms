# Approximations and Why We Ignore Lower-Order Terms

In the previous lectures, we used experimental data and log–log analysis to infer that the brute-force Three-Sum algorithm behaves roughly like:

```
T(n) ≈ a · n³
```

In this lecture, we learn an essential idea in algorithm analysis: **approximations**. They allow us to simplify expressions by ignoring terms that have little impact on runtime growth.

This skill is fundamental to understanding time complexity, and it explains why **Big-O notation focuses only on the highest-order term**.

---

## 1. Precise Models Are Possible — but Not Practical

In theory, we could build a highly accurate mathematical model of a program’s running time. Donald Knuth pointed out that two things matter:

- The cost of each individual instruction  
  *(depends on CPU, OS, runtime environment, memory hierarchy, etc.)*

- The number of times each instruction is executed  
  *(depends on the algorithm’s structure and input)*

But in practice, modern CPUs are extremely fast, and differences in single-instruction cost rarely matter when `n` is large. Even if you upgrade from a Core i5 to a CPU **4× faster**, an algorithm that takes **100 years** will still take **25 years** — still useless.

The real bottleneck is **how many operations the algorithm performs**.

Therefore, we focus on the **frequency of repeated statements** rather than the exact cost of each one.

---

## 2. A More Precise Count for Three-Sum

The triple-nested loop of the brute-force Three-Sum algorithm runs a number of iterations equal to the number of ways to choose 3 distinct indices from `n` elements. Mathematically:

```
C(n, 3) = n(n − 1)(n − 2) / 6
```

If we expand this, we get a polynomial:

```
(n³ / 6) − (n² / 2) + (n / 3)
```

This is a far more precise approximation than simply saying “it’s cubic.”  
But it is also unnecessarily complicated for our goals.

---

## 3. Why We Trim the Low-Order Terms

Let’s compare the magnitude of the terms if `n = 1000`:

```
n³ / 6 ≈ 166,000,000
n² / 2 + n / 3 ≈ 500,000
```

The cubic term is **more than 300× larger**.

The smaller terms contribute **less than 1%** to the total and become even less significant as `n` grows.

Because of this dramatic difference, we introduce a simplification technique called **tilde approximation**.

---

## 4. Tilde Approximation (`~`)

With tilde notation, we keep only the dominant term and discard everything else:

```
(n³ / 6) − (n² / 2) + (n / 3)  ~  n³ / 6
```

The symbol `~` means:

> “has the same order of growth as.”

This is a powerful idea:

- Low-order terms vanish as `n` increases
- Constant factors (like `1/6`) don’t matter for growth rate

Thus, we simplify even further:

```
n³ / 6  ~  n³
```

---

## 5. Examples of Tilde Approximation

Common approximations include:

```
(n³ / 6) − (n² / 2) + (n / 3)  ~  n³
(n² / 2) + (n / 5)           ~  n²
n² + log n                  ~  n²
n + log n                   ~  n
1000 n³                     ~  n³
50 n + 1                    ~  n
```

Even large constants don’t affect the growth class.

---

## 6. Why Approximations Matter

These simplifications allow us to:

- focus on the essential behavior of an algorithm
- compare algorithms without machine-specific details
- predict performance for large inputs
- prepare for asymptotic notation (Big-O, Big-Theta, Big-Omega)

Understanding approximations sets the foundation for the next lecture, where we look at growth orders and introduce the **Big-O notation** formally.

---

## 7. Key Insight

As `n` grows, only the **highest-order term** determines the algorithm’s overall behavior.

This is why algorithm analysis ignores constants and small terms — not because they are unimportant in implementation, but because they do not influence the **scalability** of an algorithm.

