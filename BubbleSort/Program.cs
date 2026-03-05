namespace BubbleSort
{
    internal class Program
    {
        /*
            
            Bubble sort is stable

            Bubble Sort is a simple, intuitive sorting algorithm that works by repeatedly stepping through a list and comparing adjacent elements. 
            If a pair is in the wrong order, they are swapped. This process continues in passes until the list is sorted.

            In words:

            You start at the beginning of the list.

            Compare the first two items.

            If the left one is bigger than the right one, swap them.

            Move one position to the right and repeat the comparison.

            Keep doing this until you reach the end of the list — this completes one pass.

            After each full pass, the largest unsorted value “bubbles up” to the end of the list.

            Then you repeat the whole process again, but you can ignore the last element because it’s already in its final position.

            You keep making passes until a full pass occurs with no swaps, which means the list is sorted.
         */
        static void Main(string[] args)
        {
            int[] array = { 2,12,7,20,17,32,44,56,5 }; 
            BubbleSort(array);

            foreach(int i in array)
            {
                Console.WriteLine(i);
            }
        }

        //swap elements at index i and j
        //puts j in i spot
        private static void Swap(int[] array, int i, int j) 
        { 
            if(i == j) return;

            int temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        private static void BubbleSort(int[] array)
        {
            Console.WriteLine("Bubble Sort n^2 time complexity");
            //start from last element loop backwards
            for (int partIndex = array.Length - 1; partIndex > 0; partIndex--)
            {
                //from 0 to partition index (partIndex) swap if needed
                for (int i = 0; i < partIndex; i++) 
                { 
                    if( array[i] > array[i+1])
                    {
                        Swap(array, i, i+1);
                    }
                }
            }
        }

    }
}
