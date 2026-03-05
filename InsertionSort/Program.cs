namespace InsertionSort
{
    internal class Program
    {
        /*
            Insertion Sort — stable
            stable because: Equal elements are never moved past each other. Stability is specifically about equal elements preserving order.

            Insertion sort is stable because it only shifts elements that are strictly greater than the key. 
            Equal elements are never moved past each other, so their original relative order is preserved.

            Insertion sort builds the final sorted array one element at a time, similar to how you sort playing cards in your hand.

            How it works (conceptually)

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
        static void Main(string[] args)
        {
            Console.WriteLine("Insertion Sort");
            int[] array2 = { 5, 2, 1 };
            int[] array = { 2, 12, 7, 20, 17, 32, 44, 56, 5 };
            InsertionSort(array);

            foreach (int i in array)
            {
                Console.WriteLine(i);
            }

        }
        /*  { 5, 2, 1 }
         *  i=1
         *  key = 2
         *  j=0
         *  0>=0 && 5>2 true
         *  5,5,1
         *  j=-1
         *  2,5,1
         *  
         *  next pass
         *  i=2
         *  key=1
         *  j=1
         *  1>=0 && 5>1 true
         *  2,5,5
         *  j=0
         *  0>=0 && 2>1 true
         *  2,2,5
         *  j=-1
         *  1,2,5
         *  
         *  if sorted already
         *  {2,2,5}
         *  i=1
         *  key=2
         *  j=0
         *  0>=0 && 2 > 2 false
         *      equal elements not shifted
         *  
         *  array[1] = 2 -- the same exact 2 if it were an object
         *  
         *  so stable because equal elements are not swapped or shifted 
         *  Equal elements retain their original relative ordering.
         */
        private static void InsertionSort(int[] array)
        {
            //start at index = 1
            for(int i = 1; i < array.Length; i++)
            {
                //store current value in key -- currently unsorted element 
                int key = array[i];
                int j = i - 1;
                //Move left through the sorted portion while elements are greater than key
                while (j >= 0 && array[j]>key) 
                {
                    //Shift those elements right
                    array[j+1] = array[j];
                    j--;
                }
                //Insert key into the open position
                array[j+1] = key;
            }
        }

        //challenge in course
        /*
            Sorting Only Nearly Sorted
            Insertion Sort — Sort Only if Nearly Sorted

            Insertion Sort is especially efficient when the input array is almost sorted.
            In such cases, the number of element shifts is small and the algorithm runs close to linear time.

            In contrast, when the array is highly unsorted, the number of shifts grows quickly and Insertion Sort becomes inefficient.
            A common practical approach is to estimate how far the array is from being sorted and stop the algorithm early if the work exceeds a reasonable limit.

            In this task, the array is considered nearly sorted if the number of element shifts performed by Insertion Sort does not exceed:

            n · log₂(n)

            where n is the length of the array.

            Your Task

            Modify the Insertion Sort algorithm so that it:

            Sorts the array only if it is nearly sorted

            Stops early and returns false if the number of element shifts exceeds n · log₂(n)

            and in that case leaves the input array unchanged
         */
        private static bool InsertionSortLimit(int[] inputArray)
        {
            int n = inputArray.Length;
            int numShifts = (int)(n*Math.Log2 (n));
            int shiftCount = 0;

            int[] array = new int[inputArray.Length];
            Array.Copy(inputArray,array, inputArray.Length);

            //start at index = 1
            for (int i = 1; i < array.Length; i++)
            {
                //store current value in key -- currently unsorted element 
                int key = array[i];
                int j = i - 1;
                //Move left through the sorted portion while elements are greater than key
                while (j >= 0 && array[j] > key)
                {
                    //Shift those elements right
                    array[j + 1] = array[j];
                    shiftCount++;
                    j--;
                    if (shiftCount > numShifts)
                        return false;
                }
                //Insert key into the open position
                array[j + 1] = key;
            }
            Array.Copy(array, inputArray, array.Length);
            return true;
        }
    }
}
