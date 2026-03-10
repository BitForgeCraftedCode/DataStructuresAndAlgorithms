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
            Console.WriteLine(RecursiveFactorial(3));
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
    }
}
