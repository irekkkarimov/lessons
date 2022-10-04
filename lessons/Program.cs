using System;

namespace lessons
{
    public class Program
    {
        public static void Main()
        {
            int n = 10;
            int[] array = new int[n];

            for (int i = 0; i < n; i++)
            {
                // Filling the array
                array[i] = int.Parse(Console.ReadLine());
            }

            int negativemax = -11111, positivemin = 11111, index = -11111, max = -11111;
            for (int i = 0; i < n; i++)
            {
                
                // Finding array's maximum number (The 2d exercise)
                if (array[i] > max)
                {
                    index = i;
                    max = Math.Max(max, array[i]);
                }
                
                // Finding minimum positive and maximum negative numbers (The 1st exercise)
                if (array[i] > 0)
                {
                    positivemin = Math.Min(positivemin, array[i]);
                }

                if (array[i] < 0)
                {
                    negativemax = Math.Max(negativemax, array[i]);
                }
            }
            
            int counter = 0;
            int[] mindex = new int[n];
            int min = 11111, prelast = 0, last = 0;
            
            // Finding the minimum numbers countity and the index of the pre-last's of them (The 3d exercise)
            for (int i = 0; i < n; i++)
            {
                // If new minimum number is found, we start counting it
                if (array[i] < min)
                {
                    min = array[i];
                    prelast = i;
                    last = i;
                    counter = 1;
                }
                // If the same number is found, we keep counting it and set previous number's index as 'prelast
                else if (array[i] == min)
                {
                    prelast = last;
                    last = i;
                    counter++;
                }
            }
            
            // Determining if the arrays contains simple numbers
            bool ans = false;
            for (int i = 0; i < n; i++)
            {
                int c = 0;
                for (int e = 2; e < i; e++)
                {
                    if (i % e == 0)
                        c++;
                }
                if (c == 0)
                {
                    ans = true;
                }
            }

            Dictionary<string, int> numbers = new Dictionary<string, int>();
            for (int i = 0; i < n; i++)
            {
                if (numbers.ContainsKey(array[i].ToString()) == false)
                {
                    numbers[array[i].ToString()] = 1;
                }
                else
                {
                    numbers[array[i].ToString()] = numbers[array[i].ToString()] + 1;
                }
            }

            bool ans2 = false;
            for (int i = 0; i < n; i++)
            {
                if (numbers[array[i].ToString()] > 1)
                {
                    ans2 = true;
                    break;
                }
            }

            bool ans3 = false;
            for (int i = 0; i < (n - 1); i++)
            {
                if (array[i].ToString().Length != array[i + 1].ToString().Length)
                {
                    ans3 = true;
                    break;
                }
                else
                {
                    for (int e = 0; e < array[i].ToString().Length; e++)
                    {
                        if (array[i].ToString()[e] == array[i + 1].ToString()[e])
                        {
                            continue;
                        }
                        else
                        {
                            ans3 = true;
                            break;
                        }
                    }
                }
            }

            // Just printing
            Console.WriteLine($"1. The maximum negative number is {negativemax}, the minimum positive number is {positivemin}");
            Console.WriteLine($"2. The maximum number's index is {index}");
            Console.WriteLine($"3. The pre-last minimum number's index is {prelast}, the minimum number is {array[prelast]}");
            Console.WriteLine($"4. {(ans == true ? "The array contains at least one simple number" : "The array doesn't contain simple numbers")}");
            Console.WriteLine($"5. {(ans2 == true ? "The array contains repeatead numbers" : "The array doesn't contain repeated numbers")}");
            Console.WriteLine($"6. {(ans3 == true ? "The array contains a unique number" : "The array doesn't contain unique numbers")}");
        }
    }
}