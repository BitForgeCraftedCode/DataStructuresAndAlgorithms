# Recursion vs Iteration (Using Factorial as an Example)

## Overview

Recursion is a programming technique where a function **calls itself**
to solve smaller versions of the same problem until it reaches a **base
case**.

Iteration solves the same type of problems using **loops**.

The factorial problem is a classic example used to demonstrate
recursion.

------------------------------------------------------------------------

# Factorial Definition

Mathematically:

    1! = 1
    2! = 2 × 1 = 2 × 1!
    3! = 3 × 2 × 1 = 3 × 2!
    n! = n × (n-1)!

Each factorial can be expressed using the **previous factorial**, which
makes it a natural candidate for recursion.

------------------------------------------------------------------------

# Recursive Factorial (C#)

``` csharp
private static int RecursiveFactorial(int n)
{
    if (n == 0 || n == 1) return 1;

    return n * RecursiveFactorial(n - 1);
}
```

## How Recursion Executes

Recursion builds up a chain of function calls before any multiplication
happens.

Example: `RecursiveFactorial(3)`

    3 * Rec(2)
    3 * 2 * Rec(1)
    3 * 2 * 1

Internally the calls look like:

    Rec(3)
    Rec(2)
    Rec(1)

The base case returns first:

    Rec(1) returns 1

Then the stack resolves upward:

    2 * 1 = 2
    3 * 2 = 6

Final result:

    3! = 6

Key idea:

> Nothing gets calculated until the base case is reached.

------------------------------------------------------------------------

# Iterative Factorial (C#)

``` csharp
private static int IterativeFactorial(int number)
{
    if (number == 0)
        return 1;

    int factorial = 1;

    for (int i = 1; i <= number; i++)
    {
        factorial = factorial * i;
    }

    return factorial;
}
```

Iteration simply multiplies values inside a loop.

Example for `3!`:

    1 × 1 = 1
    1 × 2 = 2
    2 × 3 = 6

------------------------------------------------------------------------

# Time Complexity

Both algorithms run in **linear time**.

    O(n)

Because both approaches perform `n` multiplications.

------------------------------------------------------------------------

# Space Complexity

This is the main difference.

## Iterative

    O(1)

Only a few variables exist:

-   number
-   factorial
-   i

Memory usage does **not grow with n**.

------------------------------------------------------------------------

## Recursive

    O(n)

Each recursive call creates a new stack frame.

Example stack:

    Rec(3)
    Rec(2)
    Rec(1)

Because there are `n` function calls, memory grows with `n`.

If recursion becomes too deep, the program will throw:

    StackOverflowException

------------------------------------------------------------------------

# Performance

Recursive functions are usually **slightly slower** because:

-   Each call creates a stack frame
-   Parameters must be stored
-   Execution jumps between methods

Loops are generally **more efficient**.

------------------------------------------------------------------------

# Readability

Recursion often maps closely to the **mathematical definition** of a
problem.

For factorial:

    n! = n × (n-1)!

The recursive implementation mirrors the math almost exactly.

This can make recursive code **more readable and easier to reason
about**.

------------------------------------------------------------------------

# Rule Most Engineers Follow

### Use Iteration When

-   The algorithm is naturally sequential
-   Performance matters
-   Deep recursion could happen

### Use Recursion When

-   The problem is naturally recursive
-   Working with trees
-   Working with graphs
-   Using divide-and-conquer algorithms
-   Recursive code is significantly clearer

------------------------------------------------------------------------

# Key Takeaway

Both recursive and iterative solutions can solve the same problems.

  Feature            Recursive         Iterative
  ------------------ ----------------- --------------------------
  Time Complexity    O(n)              O(n)
  Space Complexity   O(n)              O(1)
  Speed              Slightly slower   Faster
  Readability        Often clearer     Sometimes less intuitive

Recursion is powerful and elegant, but iteration is often the **more
efficient implementation** for simple problems like factorial.
