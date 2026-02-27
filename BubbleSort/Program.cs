namespace BubbleSort
{
    internal class Program
    {
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
