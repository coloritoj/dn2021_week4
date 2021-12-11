using System;

namespace MethodExperiments
{
    class Program
    {
        static void SayHello(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }

        static bool IsValidResponse(string entry)
        {
            if (entry == "yes" || entry == "no")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static void HandleInvalidResponse(bool answer)
        {
            while (answer == false)
            {
                Console.WriteLine("Sorry, that was not a valid response. Would you like to go again? Yes/No: ");
                string reply = Console.ReadLine();
                answer = IsValidResponse(reply);
            }
        }

        static void CheckForYesNo(string entry)
        {
            bool validResponse;

            if (entry == "yes" || entry == "no")
            {
                validResponse = true;
            }
            else
            {
                validResponse = false;
            }

            while (validResponse == false)
            {
                Console.Write("Sorry, that was not a valid response. Would you like to go again? Yes/No: ");
                entry = Console.ReadLine();
                if (entry == "yes" || entry == "no")
                {
                    validResponse = true;
                }
                else
                {
                    validResponse = false;
                }
            }            
        }

        static void Main(string[] args)
        {
            string myName = "Josh";
            SayHello(myName);

            Console.Write("Would you like to go again? Yes/No: ");
            string userDecision = Console.ReadLine();
            // HandleInvalidResponse(IsValidResponse(userDecision));

            CheckForYesNo(userDecision);
        }
    }
}
