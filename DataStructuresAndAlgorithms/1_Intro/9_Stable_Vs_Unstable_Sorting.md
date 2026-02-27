# Stable vs Unstable Sorting Algorithms

## 🔒 Stable Sorting Algorithms

### Definition

A sorting algorithm is **stable** if it preserves the **relative order
of elements that compare as equal**.

If two items are considered "equal" by the sort key, they will appear in
the **same order after sorting** as they were before sorting.

### Example

Input (sorted by Age first):

    [Alice(30), Bob(25), Carol(30)]

Stable sort by Age:

    [Bob(25), Alice(30), Carol(30)]

Alice and Carol both have age 30, and their order is preserved.

------------------------------------------------------------------------

## ⚠️ Unstable Sorting Algorithms

### Definition

A sorting algorithm is **unstable** if it does **not guarantee
preserving the relative order** of equal elements.

Example output:

    [Bob(25), Carol(30), Alice(30)]

Alice and Carol flipped order --- mathematically valid, but semantically
problematic.

------------------------------------------------------------------------

## 🧠 Why Stability Matters

### Multi-field sorting example:

    Person { Name, Age }

Process: 1. Sort by Name 2. Sort by Age (stable)

Result: - Age becomes primary key - Name becomes secondary key -
Structure is preserved

Unstable sort would destroy previous ordering.

------------------------------------------------------------------------

## 🎯 Conceptual Models

**Stable Sort:** Adds structure without destroying existing structure\
**Unstable Sort:** Rewrites structure, even among equal values

------------------------------------------------------------------------

## 📌 Definitions

**Stable sort:**\
Preserves relative order of equal elements, enabling reliable multi-key
sorting and data integrity.

**Unstable sort:**\
Does not preserve equal-element order, which can destroy semantic
relationships in structured data.

------------------------------------------------------------------------

## 🧬 Why This Matters in Software Engineering

Used in: - UI tables - Databases - Event streams - Logs - Data
pipelines - Object collections - Deterministic systems - Debugging -
Reproducibility

------------------------------------------------------------------------

## One-Sentence Summary

Stable sorting allows layered, multi-field sorting without losing
meaning.\
Unstable sorting may destroy meaningful structure even when values are
equal.
