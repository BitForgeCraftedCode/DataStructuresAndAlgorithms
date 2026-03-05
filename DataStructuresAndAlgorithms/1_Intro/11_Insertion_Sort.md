# Recap: Insertion Sort

Insertion Sort is the first sorting algorithm in this course with real
practical relevance.\
While it is inefficient on large, random datasets, it plays a critical
role as a building block in more advanced algorithms.

------------------------------------------------------------------------

## Key Characteristics

### Time Complexity

-   **Worst case:** O(n²)\

-   **Nearly sorted input:** Close to O(n)

-   **Extra memory:** O(1) (in-place)\

-   **Stability:** Stable\

-   **Type:** Iterative

------------------------------------------------------------------------

## Why Insertion Sort Matters in Practice

Insertion Sort performs extremely well when:

-   The array is small, or\
-   The data is almost sorted

Because of this, it is often used:

-   As a final cleanup step after a faster pre-sorting algorithm\
-   Inside hybrid sorting algorithms (for example, after partitioning or
    gap-based passes)

------------------------------------------------------------------------

## Strengths

-   Minimal overhead\
-   No recursion\
-   Excellent performance on small or nearly sorted inputs

------------------------------------------------------------------------

## Limitations

-   Poor scalability on large, unordered datasets\
-   Large number of element shifts in the worst case

------------------------------------------------------------------------

## Final Takeaway

Insertion Sort is not a general-purpose sorting algorithm,\
but it is an essential practical tool\
and a key component of many high-performance sorting strategies.
