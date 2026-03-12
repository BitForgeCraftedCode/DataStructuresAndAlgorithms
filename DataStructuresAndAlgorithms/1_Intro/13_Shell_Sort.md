# Shell Sort Algorithm

## Overview

Shell Sort is an improvement on Insertion Sort that allows elements to move
long distances early in the sorting process. Instead of comparing adjacent 
elements immediately, the algorithm compares elements that are a fixed number
of positions apart (called the gap). The gap is gradually reduced until 
it becomes 1, at which point the algorithm performs a normal insertion 
sort on a nearly sorted array.

A mostly sorted, insertion sort runs very fast

    Almost O(n)

    Shell Sort is an in-place comparison sort that requires O(1) extra memory.

Shell Sort properties:

    In-place: Yes
    Stable: No
    Comparison sort: Yes

------------------------------------------------------------------------

# Step 1 — Choose an Initial Gap

Determine the distance between elements that will be compared.

In Shell’s original algorithm:

    gap = n / 2

where n is the length of the array.

Time Complexity for Shell's original gap:

    O(n²)

------------------------------------------------------------------------

# Step 2 — Treat the Array as Gap-Separated Sequences

View the array as several interleaved sequences where elements are gap positions apart.

Example with gap = 2:

    Indexes: 0, 2, 4, 6 ...
    Indexes: 1, 3, 5, 7 ...

Each sequence will be sorted independently.

------------------------------------------------------------------------

## Step 3 — Perform a Gapped Insertion Sort

Run insertion sort on the elements in each gap-separated sequence.

Instead of comparing an element with the immediately preceding element, 
compare it with the element that is gap positions before it.

If the earlier element is larger, shift it forward by gap positions and 
continue comparing backward through the sequence.

Insert the current element into its correct position within that sequence.

------------------------------------------------------------------------

# Step 4 — Reduce the Gap

After completing the gapped insertion sort for the current gap, 
reduce the gap size.

In the original algorithm:

    gap = gap / 2

This creates progressively smaller gaps.

------------------------------------------------------------------------

# Step 5 — Repeat Until Gap Equals 1

Continue performing gapped insertion sorts with smaller gaps.

When the gap becomes 1, the algorithm performs a normal insertion 
sort on the entire array.

------------------------------------------------------------------------

# Final Result

The array becomes fully sorted. Because earlier passes have already 
partially ordered the elements, the final insertion sort runs very efficiently.

------------------------------------------------------------------------

# Key Idea

Large gaps move elements long distances quickly, 
then smaller gaps refine the ordering.

The purpose of Shell Sort is to move elements long distances early, 
reducing the amount of work needed in the final insertion sort pass.

Large disorder in the array is removed first, and smaller adjustments 
are made as the gap decreases.

------------------------------------------------------------------------

# Summary

Shell Sort works by:

1. Choosing a gap size.

2. Sorting elements that are that gap apart using insertion sort.

3. Repeatedly reducing the gap.

4. Finishing with a standard insertion sort when the gap becomes 1.

Think of the algorithm like pre-sorting the array at multiple resolutions:

    Large gap  → coarse ordering
    Medium gap → better ordering
    Small gap  → fine ordering
    gap = 1    → final insertion sort

------------------------------------------------------------------------

# Knuth Sequence — Choosing an optimal gap

The Knuth sequence is popular because it's simple, 
easy to compute, and performs much better than the original Shell sequence.

Formula:

    gap = 3 * gap + 1

Starting with:

    gap = 1

Sequence:

    1, 4, 13, 40, 121, ...

Example for an array of size 100:

    40 -> 13 -> 4 -> 1

This performs much better than Shell's original sequence.

The exact time complexity of Shell Sort depends on the gap sequence.

For the Knuth sequence the average performance is roughly:

    ~ O(n^(3/2))

------------------------------------------------------------------------

# Why This Sequence Exists

Shell’s original sequence was:

    n/2 -> n/4 -> n/8 -> ... -> 1

Example:

    64 -> 32 -> 16 -> 8 -> 4 -> 2 -> 1

The problem:

These gaps are too similar.

The gaps shrink too quickly and share many common factors.

This means elements may remain in the same relative positions across multiple passes,
reducing the effectiveness of early long-distance moves.
So the algorithm doesn't reduce disorder efficiently.

The Knuth sequence spreads gaps farther apart, which helps 
elements move across the array faster.

------------------------------------------------------------------------

# Intuition (Why It Works)

Knuth's gaps do two important things:

1. Large jumps early

Large gaps let elements move across the array quickly.

    40

An element can jump 40 positions at once.

2. Gradual refinement

Each smaller gap improves ordering:

    40 → rough ordering
    13 → medium ordering
    4 → fine ordering
    1 → final insertion sort

By the time we reach gap = 1, the array is already almost sorted.

Insertion Sort then finishes in nearly O(n) time.

------------------------------------------------------------------------

# The Big Picture

The real reason Shell Sort gap sequences exist:

We want gaps that let elements move far early, but refine ordering gradually.

Knuth's sequence balances those two goals.

------------------------------------------------------------------------

# How the Sequence Is Actually Used

You generate the largest gap smaller than the array size, then work backwards.

Example array:

    n = 100

Generate sequence:

    1
    4
    13
    40
    121 (too big)

So the starting gap is:

    40

Then divide by 3 each iteration:

    40 → 13 → 4 → 1

------------------------------------------------------------------------

# C# Implementation

Step 1 — generate the largest gap:

```
int gap = 1;
int n = array.Length;
while (gap < n / 3)
{
    gap = 3 * gap + 1;
}
```

Step 2 — run Shell Sort:

```
while (gap >= 1)
{
    // Perform a gapped insertion sort
    for (int i = gap; i < n; i++)
    {
        int temp = array[i];
        int j = i;

        while (j >= gap && array[j - gap] > temp)
        {
            array[j] = array[j - gap];
            j = j - gap;
        }

        array[j] = temp;
    }
    gap = gap / 3;
}
```

------------------------------------------------------------------------

# Why Divide by 3

Because the sequence was built using:

    gap = 3 * gap + 1

Reversing it approximately gives:
    
    gap = gap / 3

------------------------------------------------------------------------

# Properties

Time Complexity (depends on gap sequence)

    Best Case:     O(n log n)
    Average Case:  ~O(n^(3/2)) with Knuth sequence
    Worst Case:    O(n²)

Space Complexity

    O(1) (in-place)

Stability

    Not stable

