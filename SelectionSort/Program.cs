namespace SelectionSort
{
    internal class Program
    {
        /*
            Selction Sort is Unstable  n^2

            Selection Sort is a simple, methodical sorting algorithm that works by repeatedly finding the smallest unsorted element and placing it in its correct position.

            In words:

            Start with the first position in the list as the “current position.”

            Look through the entire remaining unsorted portion of the list.

            Find the smallest value in that unsorted portion.

            Swap that smallest value with the value at the current position.

            Now the first position is sorted.

            Move the “current position” one step to the right.

            Repeat the process on the remaining unsorted portion of the list.

            Continue until the whole list is sorted.



            this can be reversed as well

            In words for the backward version:

            Start with the last position in the list as the “current position.”

            Scan the unsorted portion of the list.

            Find the largest value in that unsorted portion.

            Swap it with the value at the current position.

            Now the last position is sorted.

            Move the current position one step to the left.

            Repeat until the list is sorted.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Selection Sort");
            int[] array = { 2, 12, 7, 20, 17, 32, 44, 56, 5 };
           
            //SelectionSortReverse(array);
            SelectionSort(array);
            foreach (int i in array)
            {
                //Console.WriteLine(i);
            }

            int[] array2 = { 7, 2, 5, 1, 9, 3 };
            SelectionSortTopK(array2, 3);
            foreach (int i in array2)
            {
                Console.WriteLine(i);
            }
        }
        
        public static void SelectionSort(int[] array)
        {
            for (int partIndex = 0; partIndex < array.Length; partIndex++)
            {
                int smallestAt = partIndex;
                for (int i =  partIndex + 1; i < array.Length; i++) 
                {
                    if (array[i] < array[smallestAt]) 
                    { 
                        smallestAt = i;
                    }
                }
                Swap(array, partIndex, smallestAt);
            }
        }

        public static void SelectionSortReverse(int[] array)
        {
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
            }
        }

        /*
            Selection Sort — Top-K Elements

            Modify the algorithm so that it performs only the first k passes of Selection Sort.

            After the method finishes execution:

            The last k elements of the array must contain the k largest values

            The order of the remaining elements is not important

            Requirements

            Do not use Array.Sort or any built-in sorting methods

            Do not create a new array

            The algorithm must remain Selection Sort

            You are allowed to modify only the logic of the outer loop

            Example

            Input
            array = { 7, 2, 5, 1, 9, 3 }, k = 3

            Result:
            The last three elements of the array must be { 5, 7, 9 }

            The order of the elements placed before the last three elements doesn't matter.
         */
        public static void SelectionSortTopK(int[] array, int k)
        {
            for (int partIndex = array.Length - 1; partIndex >= array.Length - k; partIndex--)
            {
                int largestAt = 0;
                for (int i = 1; i <= partIndex; i++)
                {
                    if (array[i] > array[largestAt])
                    {
                        largestAt = i;
                    }
                }
                Swap(array, largestAt, partIndex);
            }
        }


        //swap elements at index i and j
        //puts j in i spot
        private static void Swap(int[] array, int i, int j)
        {
            if (i == j) return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }
    }
}
