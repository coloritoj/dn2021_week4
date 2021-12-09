using System;

namespace Reddit
{
    class Program
    {
        static void Main(string[] args)
        {
            int numSold;
            decimal cost = 0;
            string modelOfType;
            string deluxeUpgrade;
            decimal totalCost = 0;

            Console.WriteLine("Please enter which laptop you would like to purchase (D, L, A)");
            modelOfType = Console.ReadLine();

            if (modelOfType == "D")
            {
                cost = 2800.00M;
            }
            else if (modelOfType == "L")
            {
                cost = 1700.00M;
            }
            else if (modelOfType == "A")
            {
                cost = 2200.00M;
            }

            Console.WriteLine("\nPlease enter the number of laptops you wish to purchase:");
            numSold = int.Parse(Console.ReadLine());

            Console.WriteLine("\nWould you like to upgrade to the deluxe package (Y, N)");
            deluxeUpgrade = Console.ReadLine();

            if (deluxeUpgrade == "Y")
            {
                if (modelOfType == "D")
                {
                    cost = 3000.00M;
                }
                else if (modelOfType == "L")
                {
                    cost = 2000.00M;
                }
                else if (modelOfType == "A")
                {
                    cost = 2500.00M;
                }

                totalCost = cost * numSold;
                Console.WriteLine($"\nThanks for upgrading! Your total cost for {numSold} deluxe laptops comes to ${totalCost}.");
            }
            else
            {
                totalCost = cost * numSold;
                Console.WriteLine($"\nThanks for purchasing our standard package! Your total cost for {numSold} laptops comes to ${totalCost}.");
            }
        }
    }
}
