# Arrays in C# — Recap

## Arrays in C#: Overview, Memory Layout, and Time Complexity

---

## 1. What an array is in C#

An array in C# is a fundamental data structure that stores a **fixed-size sequence of elements of the same type**. You access elements by index. Arrays are **not dynamic**: their length is fixed at creation time.

In C#, all arrays are **reference types**, regardless of whether they hold value types (like `int`) or reference types (like `string`). The variable that you declare (e.g. `a1`) is a **reference** that either points to an array object on the managed heap or is `null`.

---

## 2. Declaring and initializing arrays

Typical ways to declare and initialize arrays:

```csharp
int[] a1;           // declaration only, a1 is null

a1 = new int[10];   // allocate space for 10 ints, all elements = 0

int[] a2 = new int[5];                // declaration + allocation
int[] a3 = new int[5] {1, 2, 3, 4, 5}; // with explicit initializer
int[] a4 = {1, 2, 3, 4, 5};            // shortest syntax
```

When you write `new int[10]`, a **contiguous block of memory** is allocated for 10 integers, and the variable points to the first element.

You cannot resize this array in place. To “resize” an array, you must:

1. Create a new array with the desired length  
2. Copy elements from the old array to the new one

---

## 3. Indexing, bounds, and iteration

Arrays in C# are **zero-based**:

- First element → index `0`  
- Last element → index `Length - 1`

`Length` gives the number of elements.

Accessing an index outside the valid range immediately throws `IndexOutOfRangeException` at runtime.

### Typical iteration patterns

```csharp
for (int i = 0; i < a3.Length; i++)
{
    Console.WriteLine(a3[i]);
}
```

```csharp
foreach (int x in a4)
{
    Console.WriteLine(x);
}
```

---

## 4. The `System.Array` type and advanced uses

All array types in C# implicitly derive from `System.Array`. That’s why every array has members like:

- `Length`
- `GetLength`
- `GetLowerBound`
- `GetUpperBound`

and static methods like:

- `Array.Copy`
- `Array.BinarySearch`

You can also work with `Array` directly:

```csharp
Array myArray = Array.CreateInstance(typeof(int), 5);
myArray.SetValue(1, 0);
int first = (int)myArray.GetValue(0);
```

---

### 4.1 Non-zero-based arrays

With `Array.CreateInstance` you can create an array whose first index is not zero:

```csharp
Array myArray = Array.CreateInstance(typeof(int),
                                     new int[] {4},   // lengths
                                     new int[] {1});  // lower bounds (start from 1)

myArray.SetValue(10, 1); // first element at index 1

int lower = myArray.GetLowerBound(0); // 1
int upper = myArray.GetUpperBound(0); // 4
```

**Important notes:**

- Non-zero-based arrays are **not CLS-compliant**
- Rarely expected by other .NET languages
- Typically **slower** than zero-based arrays
- Use only in exceptional cases

In normal code, **always use zero-based arrays**.

---

### 4.2 Multidimensional vs jagged arrays

#### Multidimensional (rectangular) arrays

Same length in each dimension:

```csharp
int[,] r2 = new int[,]
{
    {1, 2, 3},
    {4, 5, 6}
};
```

Iteration:

```csharp
for (int i = 0; i < r2.GetLength(0); i++)   // rows
{
    for (int j = 0; j < r2.GetLength(1); j++) // columns
    {
        Console.WriteLine(r2[i, j]);
    }
}
```

#### Jagged arrays (arrays of arrays)

Each row can have different length:

```csharp
int[][] jagged = new int[4][];
jagged[0] = new int[1];       // length 1
jagged[1] = new int[3];       // length 3
jagged[2] = new int[2];       // length 2
jagged[3] = new int[4];       // length 4

for (int i = 0; i < jagged.Length; i++)
{
    for (int j = 0; j < jagged[i].Length; j++)
    {
        Console.Write(jagged[i][j] + " ");
    }
    Console.WriteLine();
}
```

Jagged arrays are useful when different “rows” naturally have different lengths and you don’t want to allocate unused slots.

Both multidimensional and jagged arrays still derive from `System.Array`.

---

## 5. How arrays are laid out in memory

The array itself is always a **single object on the managed heap**. The variable holding it is a **reference** (stored on the stack or inside another object).

- **Array of reference types:** each slot stores a reference to an object elsewhere in the heap
- **Array of value types:** values are stored directly in the contiguous memory block

On 32-bit runtimes a reference is **4 bytes**; on 64-bit runtimes it’s **8 bytes**.

Each array also has overhead:

- object header
- pointer to method table
- `Length` field
- CLR metadata

For large arrays, this overhead is negligible compared to the data itself.

---

### 5.1 Contiguous layout and address calculation

Array elements are stored **contiguously**. If the first element starts at address `base` and each element has size `sizeof(T)`, then:

```
address(i) = base + i * sizeof(T)
```

That’s why `array[i]` is **O(1)**:

- compute address
- read/write value

Just a few CPU instructions.

---

### 5.2 Unsafe code and pinning

In unsafe C# code, you can work with pointers to array elements. To do this safely with the GC, you must **pin the array**:

```csharp
unsafe static void IterateOver(int[] array)
{
    fixed (int* b = array) // pin array, b points to first element
    {
        int* p = b;

        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(*p);  // dereference
            p++;                // move to next int (by sizeof(int))
        }
    }
}
```

`fixed` prevents the GC from moving the array while the pointer is in use.

**Warnings:**

- Pinning hurts GC performance
- Use briefly and only when necessary
- Rarely needed in normal application code

This example is mainly illustrative: it shows contiguous layout and pointer arithmetic.

---

## 6. Additional notes and modern C# / .NET updates

Although these lectures were recorded before .NET 5, almost everything remains valid in modern .NET (.NET 5/6/7/8/9):

### Still true today

- `System.Array` is a reference type
- contiguous storage
- zero-based indexing
- O(1) indexing
- same memory model

### Modern additions

**Indices and ranges (C# 8+):**

```csharp
arr[^1]   // last element (O(1))
arr[1..4] // new array slice (copying = O(n))
```

**Performance APIs:**

- `Span<T>` / `ReadOnlySpan<T>` → zero-allocation memory views  
- `ArrayPool<T>` → rent/return arrays instead of allocating

These do not change how arrays work internally — they provide more efficient **memory reuse and access patterns**.

Most .NET apps now run as **64-bit processes**, so references are 8 bytes instead of 4. Concrete byte sizes differ from older lectures, but the **core concepts are unchanged**.

