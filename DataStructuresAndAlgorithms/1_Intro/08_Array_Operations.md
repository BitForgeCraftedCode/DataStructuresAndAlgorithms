# Operations on Array

## Time Complexity of Operations on Arrays

Arrays provide fast, predictable access to elements because they occupy
a single contiguous block of memory.\
This section summarizes the time complexity of the most common
operations on arrays.

------------------------------------------------------------------------

## 1. Access by index --- O(1)

Indexing into an array (reading or writing `array[i]`) is a
constant-time operation.\
The runtime computes the address as:

    address(i) = base + i * sizeof(T)

No loops, no searching --- just arithmetic.\
This is the main advantage of arrays.

------------------------------------------------------------------------

## 2. Search (unknown index) --- O(n)

If you do not know the index of the element, you must check elements one
by one until you find a match:

``` csharp
for (int i = 0; i < arr.Length; i++)
{
    if (arr[i] == value)
        return true;
}
```

This linear scan touches up to `n` elements → **O(n)**.\
If the array is sorted, binary search could reduce this to **O(log n)**,
but unsorted arrays offer no shortcuts.

------------------------------------------------------------------------

## 3. Insertion and Updates

### 3.1 Updating a known index --- O(1)

Assigning a new value to an existing position is constant time:

``` csharp
arr[i] = value;  // O(1)
```

------------------------------------------------------------------------

### 3.2 Inserting without resizing (when a free slot exists) --- O(1)

If the array has unused space (e.g., you manage logical size manually)
and you know where to place the element, the operation is still constant
time.

------------------------------------------------------------------------

### 3.3 Inserting with shifting --- O(n)

If you insert at some position `k` and must shift elements to the right:

-   `n - k` elements must be moved → **O(n)**

------------------------------------------------------------------------

### 3.4 Inserting when the array is full --- O(n)

To "grow" an array you must:

-   allocate a new, larger array\
-   copy the old elements

``` csharp
int[] bigger = new int[arr.Length * 2];
Array.Copy(arr, bigger, arr.Length); // O(n)
```

------------------------------------------------------------------------

## 4. Removal

### 4.1 Logical removal --- O(1)

If you simply clear a slot (e.g., set it to `null` for reference types),
the element is "logically removed":

``` csharp
arr[i] = null; // O(1)
```

No resizing or shifting happens.

------------------------------------------------------------------------

### 4.2 Physical removal (with shifting) --- O(n)

If you want to remove the element and close the gap, you must shift all
elements after index `i` to the left by one.\
This touches up to `n - i` elements → **O(n)**.

------------------------------------------------------------------------

### 4.3 Removing by shrinking the array --- O(n)

Creating a new array with `Length - 1` and copying all elements except
the removed one is also linear time.
