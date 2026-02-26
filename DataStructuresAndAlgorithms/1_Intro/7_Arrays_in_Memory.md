# Arrays in Memory — Recap

## Arrays in Memory

### 1. Arrays are reference types
In C#, all arrays are **reference types**. The variable you declare (e.g. `int[] a`) is only a reference. The actual array object is always allocated on the managed heap.

```csharp
int[] a = null;   // reference only
a = new int[10];  // array allocated on the heap
int[] b = a;      // both references point to the same array
```

Both `a` and `b` point to the same array object. Any modification via one reference is visible via the other.

---

### 2. Arrays that store reference types
If an array holds reference types (e.g. `string[]`, `Person[]`), the array stores **references (pointers)** to objects on the heap, not the objects themselves.

**Conceptual memory layout:**

```
array object:
---------------------------------------------------
| ref | ref | ref | ref | ... (Length entries)    |
---------------------------------------------------
 each ref → points to a separate heap object
```

The array is one object; every referenced element is a separate heap allocation.

---

### 3. Arrays that store value types
If an array holds value types (`int[]`, `double[]`, `bool[]`, or `struct[]`), the values are stored **inside the array object itself**.

```csharp
int[] numbers = {1, 2, 3, 4};
```

**Memory layout:**

```
array object:
---------------------------------------------------
| 1 | 2 | 3 | 4 | (values directly stored)        |
---------------------------------------------------
```

There is no extra indirection. Reading each element is a simple memory load.

---

### 4. Why arrays are contiguous in memory
Arrays must be contiguous because indexing uses direct pointer arithmetic:

```
address(i) = base + i * sizeof(T)
```

This guarantees **O(1)** access to any element and allows:

- **Excellent CPU cache locality** — array elements are stored next to each other, so the CPU can load many of them into cache at once.
- **Efficient prefetching** — the CPU can predict that sequential elements will be accessed next and fetch them ahead of time.
- **Fast sequential iteration** — walking through contiguous memory requires fewer slow main-memory accesses, making iteration very fast.

---

### 5. Arrays of reference types vs arrays of value types

**Key difference:**

- **Array of reference types** → array stores pointers; actual objects live elsewhere on the heap.
- **Array of value types** → array stores the actual values inside a single contiguous block.

This affects **performance, GC pressure, locality, and memory usage**.

---

### 6. Array resizing and copying
Since arrays are fixed-size, resizing an array means:

1. Allocate a new array of the desired length.
2. Copy elements from the old array to the new one.

```csharp
int[] bigger = new int[a.Length * 2];
Array.Copy(a, bigger, a.Length);
```

Copying requires touching each element → **O(n)**.

---

### 7. Summary

- Arrays are reference types allocated on the heap.
- Arrays of reference types store pointers; arrays of value types store values directly.
- Arrays are contiguous blocks of memory → **O(1)** indexing.
- Resizing requires allocating a new array and copying elements.

