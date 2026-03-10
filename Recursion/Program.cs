namespace Recursion
{
    internal class Program
    {

        /*
         * Recursive vs Iterative methods
         * 
         * Both methods have the same Time Complexity of O(n)
         * however recursive methods have a much higher Space Complexity 
         * 
         * Iterative space complexity is O(1) as only a few variables exist (number, factorial and i) so memory does not grow with n
         * Recursive space complexity is O(n) as each call call creates a new stack
         * Rec(3)
         * Rec(2)
         * Rec(1)
         * n function calls so Space Grows with n and we will get StackOverflowException for deep recursive calls
         * 
         * this higher space complexity makes recursive methods a bit slower and iterative loops a bit more efficient.
         * 
         * recursive methods are more human readable
         * 
         * Rule Most Engineers Follow
         *
         * Use iteration when:
         *   
         * -The algorithm is naturally sequential
         *   
         * -Performance matters
         *   
         * -Deep recursion could happen
         *   
         * Use recursion when:
         *   
         * -The problem is naturally recursive
         *   
         * -Working with trees, graphs, divide-and-conquer
         *   
         * -Recursive code is significantly clearer
         */
        static void Main(string[] args)
        {
            Console.WriteLine("recursion");
            //Console.WriteLine(IterativeFactorial(3));
            //Console.WriteLine(IterativeFactorial(4));
            //Console.WriteLine(RecursiveFactorial(3));
            //int[] array = { 1, 2, 3, 4 };
            //Console.WriteLine(Sum(array, 2)); // result 7

            int[] sortedArray = { 1, 2, 3, 4, 5 };
            Console.WriteLine(IsSorted(sortedArray, 0));
            int[] notSorted = { 1, 3, 2, 4 };
            Console.WriteLine(IsSorted(notSorted, 0));
        }

        // each factorial can be expressed by a previous one
        // 1! = 1 * 0! = 1
        // 2! = 2 * 1 = 2 * 1!
        // 3! = 3 * 2 * 1 = 3 * 2! 
        // n! = n * (n - 1)!

        /*
         * recusion works sort of like a tree
         * nothing gets calulated until the base case is reached
         * 
         * 3! = 3*2*1 = 6
         * 
         * 3*Rec(2)
         * 3*2*Rec(1)
         * 3*2*1
         * 
         * internally like this
         * 3 * Rec(2)
         * 2 * Rec(1)
         * 
         * Rec(1) returns 1
         * then
         * 
         * 2*1=2
         * 3*2=6
         */
        private static int RecursiveFactorial(int n)
        {
            if (n == 0 || n == 1) return 1;

            return n * RecursiveFactorial(n - 1);
        }
        private static int IterativeFactorial(int number)
        {
            if (number == 0)
                return 1;

            int factorial = 1;
            for (int i = 1; i <= number; i++)
            {
                factorial= factorial*i;
            }
            return factorial;

        }
        //challenge 1
        /*
            Recursive Array Sum
            Recursive Sum of Array

            Implement a recursive function that computes the sum of elements in an integer array.

            The function must work by solving a smaller subproblem on each recursive call.

            The parameter index represents the starting position in the array.
            The method must correctly compute the sum of all elements from index to the end of the array.

            Method Contract

            Implement the following method:

            public static int Sum(int[] array, int index)

            Requirements:

            The solution must be recursive

            Do not use loops (for, while, foreach)

            Do not use LINQ

            A correct base case must be defined

            The method must work for any valid value of index

            Test cases may call the method with index values other than 0

            Example:

            Input
            array = { 1, 2, 3, 4 }, index = 0

            Result
            10

            Input
            array = { 1, 2, 3, 4 }, index = 2

            Result
            7

            Notes

            If index is equal to the array length, the result must be 0

            The function should not modify the input array

            We do not pass index < 0 in tests

            use index argument in the recursive calls    

         */

        private static int Sum(int[] array, int index)
        {
            if (index == array.Length) return 0;
            if(array.Length == 0) return 0;

            if (index == array.Length - 1)
            {
                return array[index];
            }

            int sum = array[index] + Sum(array, index + 1);
            return sum;
        }

        //challenge 2
        /*
            Recursive IsSorted
            Check if Array Is Sorted Using Recursion

            Implement a recursive function that checks whether an integer array is sorted in ascending order.

            The function must work by comparing adjacent elements and recursively checking the remaining part of the array. The parameter index represents the starting position for the check.
            Test cases may call the method with values of index >= 0.

            Method Contract

            public static bool IsSorted(int[] array, int index)

            Requirements

            The solution must be recursive

            Do not use loops (for, while, foreach)

            Do not use built-in sorting or comparison helpers

            The method must correctly handle any valid value of index

            The input array must not be modified

            Example

            Input
            array = { 1, 2, 3, 4, 5 }, index = 0

            Result
            true

            Input
            array = { 1, 3, 2, 4 }, index = 0

            Result
            false

            Notes

            If the array contains zero or one element in the checked range, it is considered sorted

            The function should stop as soon as an unsorted pair is found

            We don't pass index that exceeds array boundaries in tests

         */

        private static bool IsSorted(int[] array, int index)
        {
            if (array.Length == 0 || array.Length == 1) return true;

            if (index < array.Length - 1)
            {
                if (array[index] < array[index + 1])
                {
                    return IsSorted(array, index + 1);
                }
                else
                {
                    return false;
                }
            }
            //true because we made it to the end of the array without returning false
            return true;
        }
    }
}
