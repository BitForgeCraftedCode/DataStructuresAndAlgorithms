namespace ShellSort
{
    /* insertion sort recap
        -Assume the first element is already sorted.

        -Take the next element.

        -Compare it to elements on its left.

        -Shift larger elements one position to the right.

        -Insert the current element into its correct position.

        -Repeat until the array is fully sorted.
        
        Step-by-step idea

        -For an array of length n:

        -Start at index 1 (the second element).

        -Store the current value (key).

        -Move left through the sorted portion while elements are greater than key.

        -Shift those elements right.

        -Insert key into the open position.
     */

    /* Shell Sort
        Shell Sort works by:

        1. Choosing a gap size.

        2. Sorting elements that are that gap apart using insertion sort.

        3. Repeatedly reducing the gap.

        4. Finishing with a standard insertion sort when the gap becomes 1.

     */
    internal class Program
    {
        //shell sort with kunth gap -- the standard O(n^(3/2))
        private static void ShellSort(int[] array)
        {
            int n = array.Length;
            int gap = 1;
            /*
                n=100
                1 < 33 gap = 4
                4 < 33 gap = 13
                13 < 33 gap = 40

                40 < 33 false end while and biggest gap is 40 
             */
            while (gap < n / 3)
            {
                gap = 3 * gap + 1;
            }

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
        }
        //shell sort with shell's original n/2 gap
        /*
            g = 2
            [22,34,25,12]  n=4 g=n/2 = 2

            Sequences:
            [22,25]  (indexes 0,2)
            [34,12]  (indexes 1,3)

            i=2
            temp=25 j=2
            22 > 25 → false
            no shift

            i=3
            temp=12 j=3
            34 > 12 → shift

            [22,34,25,34]

            j = 1
            1 >= 2 → false → exit while

            insert temp at index 1

            [22,12,25,34]

            i becomes 4 → exit inner loop

            gap becomes 1 → final pass is normal insertion sort  
         */
        private static void ShellSortClassicGap(int[] array)
        {
            int n = array.Length;

            // Start with gap = n/2 and shrink each iteration
            for (int gap = n / 2; gap > 0; gap = gap / 2)
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
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Shell Sort");
            int[] array = [22, 34, 25, 12];
            //ShellSortClassicGap(array);
            ShellSort(array);
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
        }

        
    }
}
