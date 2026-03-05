Course link https://github.com/EngineerSpock/Algorithms-CSharp-Course 
# 1. Abstract Data Types (ADT)

An Abstract Data Type (ADT) is a high-level description of a data model: 
it specifies what operations are available and what behavior they must provide, 
without describing how these operations should be implemented.

In other words, an ADT defines:

the set of possible values,

the operations that can be applied,

the logical behavior of these operations.

For example, the ADT Stack defines a LIFO (last-in–first-out) collection with operations such as push, pop, and peek. 
The ADT does not specify whether the stack uses an array, a linked list, or anything else internally.

# 2. Data Structures

A data structure is a concrete implementation of an ADT. While an ADT describes the idea, a data structure provides the exact organization of data in memory
and the actual implementation of operations.

Examples:

an array-based stack,

a linked-list-based stack.

Both represent the same ADT, but their internal behavior and performance characteristics differ. 
This distinction is important: an ADT answers "what and why", a data structure answers "how".

# 3. Primitive Types as Building Blocks

All data structures ultimately rely on primitive types provided by the programming language: int, char, double, boolean, and so on. 
They serve as the basic building blocks for more complex data organizations.

# 4. What Is an Algorithm?

An algorithm is a well-defined computational procedure with:

a valid input,

a precise step-by-step procedure,

a correct output.

An algorithm is considered correct if it produces the correct output for every correct input. Algorithms formalize how computational problems should be solved.

# 5. Example: The Sorting Problem

The problem definition:

Input: a sequence of numbers.

Output: a permutation of the same numbers sorted in non-decreasing order.

This description defines the problem itself. Different algorithms—such as insertion sort, merge sort, or quicksort—represent different ways to solve it.

# 6. Pseudocode

Algorithms are often presented in pseudocode, which is language-agnostic and easier to read than raw code. 
Pseudocode is not tied to any specific programming language but clearly communicates the logic.

Example (Insertion Sort):

```
j = 2
while j <= length(A):
    key = A[j]
    i = j - 1
    while i > 0 and A[i] > key:
        A[i+1] = A[i]
        i = i - 1
    A[i+1] = key
    j = j + 1
 ```


# 7. Summary

ADT describes behavior; it is an abstraction.

Data structures are concrete implementations of ADTs.

All structures are ultimately based on primitive data types.

Algorithms define step-by-step procedures that solve computational problems.

Pseudocode is a universal and readable way to express algorithms.

Data structures define how we store information; algorithms define how we process it.

In short: understanding both data structures and algorithms is essential. They form the toolkit used to design efficient and reliable software systems.