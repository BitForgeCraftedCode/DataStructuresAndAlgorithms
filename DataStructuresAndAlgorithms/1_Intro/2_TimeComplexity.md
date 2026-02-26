# Time Complexity Recap
## Understanding Algorithmic Complexity
When we create an algorithm to solve a problem, two practical questions always arise:

How much time will the algorithm take?

How much memory will it consume?

There is no universal shortcut that instantly tells us how efficient an algorithm is. Instead of diving into deep theoretical discussions, 
the lecture takes a practical approach: we implement a real algorithm and measure how its running time grows with the size of the input.

## 1. The Three-Sum Problem
The task is: given an array of integers, count all the triplets whose sum equals zero. The simplest brute-force solution checks every possible triplet.

This results in a structure with three nested loops:

```
// Pseudocode (conceptual)
counter = 0
for i in [0 .. n):
    for j in [i+1 .. n):
        for k in [j+1 .. n):
            if a[i] + a[j] + a[k] == 0:
                counter++
 ```

This algorithm is guaranteed to consider all combinations, but it scales very poorly — something we will soon observe.

## 2. Measuring Running Time
The lecturer uses real data sets (1k, 4k, 8k, 16k integers) and a high-precision timer to measure how long the brute-force algorithm runs. The results illustrate that:

1k integers → about 300 ms

4k integers → about 14 seconds

8k integers → about 96 seconds

This growth is not linear. Increasing the input by 4× does not increase time by 4× — it increases it by roughly 50×. Doubling from 4k to 8k increases the time by ~7×.

Different computers produce different absolute times, but the growth pattern remains the same. That is exactly why we study complexity.

## 3. Why Runtime Explodes So Fast
The experiment demonstrates that the brute-force version of Three-Sum has running time proportional to n³. This is because:

the algorithm uses three nested loops;

each loop has a range proportional to n;

the total number of operations grows approximately as n × n × n = n³.

This cubic growth explains why doubling the input from 8k to 16k results in a runtime increase by about eight times (2³ = 8).

## 4. The Real Question: How Does Runtime Depend on n?
Since raw measurements depend on the CPU, OS, and many external factors, we care about a more general question:

How does the running time T(n) grow as a function of the input size n?

Answering this leads us to the analysis tools covered in the following lectures: log-log plots, approximations, and orders of growth.

## 5. Key Insights
Brute-force Three-Sum is a perfect example of a cubic-time algorithm.

Real measurements demonstrate dramatic growth even for moderate input sizes.

Running 128k inputs becomes essentially impossible — not because computers are “slow”, but because n³ grows too aggressively.

The exact execution time depends on the machine, but the complexity class (cubic) stays the same.

To reason about performance independently of hardware, we need mathematical models of algorithmic growth.

## 6. Why This Matters
Even fast CPUs cannot compensate for a bad algorithm. If a cubic algorithm takes 100 years on one CPU, 
switching to a CPU 4× faster reduces it only to 25 years — still useless. 
The real improvement comes from changing the algorithm, not the hardware.

This sets the stage for understanding asymptotic complexity, Big-O notation, and different growth rates, which are covered in the next lectures.