using System;

namespace TestDemo1
{
    class Program
    {
        // Suppose we want a function that takes three integers and returns the sum.

        static int SumThree(int x, int y, int z)
        {
            return x + y + z;
        }

        // Write a function that reverses a string.
        // ... If the function is passed a null, return null.

        static string Reverse(string str)
        {
            if (str == null)
            {
                return null;
            }

            string result = "";
            for (int i = str.Length - 1; i >= 0; i--)
            {
                result += str[i];
            }
            return result;
        }

        static void Main(string[] args)
        {
            string test1 = "hello";
            string result1 = Reverse(test1); // Expect olleh
            if (result1 == "olleh")
            {
                Console.WriteLine("test1 passed!");
            }
            else
            {
                Console.WriteLine($"test1 failed! Expected olleh but actual was {result1}");
            }

            string test2 = "";
            string result2 = Reverse(test2); // Expect empty string
            if (result2 == "")
            {
                Console.WriteLine("test2 passed!");
            }
            else
            {
                Console.WriteLine($"test 2 failed! Expected empty string but actual was {result2}");
            }

            string test3 = null;
            string result3 = Reverse(test3); // Expect null
            if (result3 == null)
            {
                Console.WriteLine("test3 passed!");
            }
            else
            {
                Console.WriteLine($"test3 failed! Expected null but actual was {result3}");
            }


            /*int test1 = SumThree(1, 2, 3); // Expect 6

            if (test1 == 6)
            {
                Console.WriteLine($"test1 passed! Expected 6 and the actual was {test1}");
            }
            else
            {
                Console.WriteLine($"test1 failed! Expected 6 but the actual was {test1}");
            }

            //Console.WriteLine(SumThree(1, 2, 3)); // Expect 6
            //Console.WriteLine(SumThree(2, 2, 2)); // Expect 6 */
        }
    }
}
