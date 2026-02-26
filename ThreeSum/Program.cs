namespace ThreeSum
{
    internal class Program
    {
        /*
            Given an integer array nums, return all the triplets [nums[i], nums[j], nums[k]] such that i != j, i != k, and j != k, and nums[i] + nums[j] + nums[k] == 0.

            Notice that the solution set must not contain duplicate triplets.

            Example 1:

            Input: nums = [-1,0,1,2,-1,-4]
            Output: [[-1,-1,2],[-1,0,1]]
            Explanation: 
            nums[0] + nums[1] + nums[2] = (-1) + 0 + 1 = 0.
            nums[1] + nums[2] + nums[4] = 0 + 1 + (-1) = 0.
            nums[0] + nums[3] + nums[4] = (-1) + 2 + (-1) = 0.
            The distinct triplets are [-1,0,1] and [-1,-1,2].
            Notice that the order of the output and the order of the triplets does not matter.
            Example 2:

            Input: nums = [0,1,1]
            Output: []
            Explanation: The only possible triplet does not sum up to 0.
            Example 3:

            Input: nums = [0,0,0]
            Output: [[0,0,0]]
            Explanation: The only possible triplet sums up to 0.
         */
        static void Main(string[] args)
        {
            Console.WriteLine("Three Sum Problem");
            /* The above problem definition is, in my opinion, a high-level formal definition of a simple idea: "How many distinct groups of 3 from a set of n sum to 0" 
             * This is just what's know in math as a Combination. nCr = n!/(r!*(n-r)!)
             * Once you understand Combinations, the structure of the solution becomes more obvious.
             * 
             * the trick however is seeing that nesting for loops can easily list all the combos
             * take the example below. It lists "all distinct groups of 2 from a set of 3"
             */
            int[] indexArray = [0,1,2];
            int length = indexArray.Length;
            for (int i = 0; i < length; i++) 
            { 
                for(int j = i + 1; j < length; j++) 
                {
                    Console.WriteLine(i + "," + j);
                }
            }
            Console.WriteLine("----------------------------------------");
            /*
             * From that if we add a third nesting we can list "all distinct groups of 3 from a set of n"
             * Note that this gets us "all distinct index groups of 3 from a set of n"
             * However the problem above doesnt just want distinct index location points but also "Notice that the solution set must not contain duplicate triplets"
             * So we have an additional constraint 
             */

            //int[] nums = [-1, 0, 1, 2, -1, -4];
            int[] indexArray2 = [0,1,2,3];
            int length2 = indexArray2.Length;
            
            for (int i = 0; i < length2; i++) 
            { 
                for( int j = i + 1; j < length2; j++)
                {
                    for(int k = j + 1; k < length2; k++)
                    {
                        Console.WriteLine(i + "," + j + "," + k);
                    }
                }
            }
            Console.WriteLine("----------------------------------------");
            int[] nums = [-1, 0, 1, 2, -1, -4];
            int n = nums.Length;

            int count = 0;
            HashSet<string> seen = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    for (int k = j + 1; k < n; k++)
                    {
                        
                        if(nums[i] + nums[j] + nums[k] == 0)
                        {
                            // Canonicalize the triplet (sort values)
                            int[] triplet = { nums[i], nums[j], nums[k] };
                            Array.Sort(triplet);

                            // Convert to unique key
                            string key = $"{triplet[0]},{triplet[1]},{triplet[2]}";

                            // Only count if it's new
                            if (!seen.Contains(key))
                            {
                                seen.Add(key);
                                Console.WriteLine($"[{triplet[0]}, {triplet[1]}, {triplet[2]}]");
                                count++;
                            }
                        }
                    }
                }
            }

            Console.WriteLine("Count " + count);

        }
    }
}
