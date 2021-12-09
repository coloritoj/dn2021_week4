using System;

namespace ExceptionDemo
{
    class Program
    {
        static void ArrayFun()
        {
            int[] nums = new int[] { 3, 6, 9 };
            Console.WriteLine(nums[0]);
            Console.WriteLine(nums[1]);
            Console.WriteLine(nums[2]);
            Console.WriteLine(nums[3]);
        }


        static void Main(string[] args)
        {
            try
            {
                ArrayFun();
            }
            catch (IndexOutOfRangeException oor)
            {
                Console.WriteLine("Oops. We went out of bounds!");
            }
            catch (Exception ex) // This Exception right here is like a true "catch all" exception. If this is the first catch, it won't let more specific ones appear. They must appear first/in a cascading fashion.
            {
                Console.WriteLine("Oops. Something went wrong. Try again later.");
            }
        }
    }
}
