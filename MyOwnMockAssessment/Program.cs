using System;
using System.Collections.Generic;

namespace MyOwnMockAssessment
{
    abstract class Retiree
    {
        public int MonthlyExpenses;

        public abstract int GenerateIncomeFromIRA();
    }

    // When you see the warning "<CLASSNAME> does not implement inherited abstract member..." message/error, it's because you need to create an override.
    // Once you create the override, the message/error goes away.
    class PennyPincher : Retiree 
    {
        public PennyPincher()
        {
            MonthlyExpenses = 1000;
        }

        public override int GenerateIncomeFromIRA()
        {
            return 3000;
        }
    }

    // When you see the warning "<CLASSNAME> does not implement inherited abstract member..." message/error, it's because you need to create an override.
    // Once you create the override, the message/error goes away.
    class SuperSpender : Retiree
    {
        public SuperSpender()
        {
            MonthlyExpenses = 9000;
        }

        public override int GenerateIncomeFromIRA()
        {
            return 500;
        }
    }

    class RetirementHome
    {
        List<Retiree> retireeList = new List<Retiree>();

        public RetirementHome()
        {
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());
            retireeList.Add(new PennyPincher());

            retireeList.Add(new SuperSpender());
            retireeList.Add(new SuperSpender());
            retireeList.Add(new SuperSpender());
            retireeList.Add(new SuperSpender());
            retireeList.Add(new SuperSpender());
        }

        public int PoolMoneyFromIRAs()
        {
            int sumIRAs = 0;
            foreach (Retiree resident in retireeList)
            {
                sumIRAs += resident.GenerateIncomeFromIRA();
            }
            return sumIRAs;
        }

        public int CountMonthlyExpenses()
        {
            int sumMonthlyExpenses = 0;
            foreach (Retiree resident in retireeList)
            {
                sumMonthlyExpenses += resident.MonthlyExpenses;
            }
            return sumMonthlyExpenses;
        }

        public bool HasEnoughForCasinoBusTrip()
        {
            int totalGenerated = PoolMoneyFromIRAs();
            int totalExpenses = CountMonthlyExpenses();

            if (totalGenerated >= totalExpenses)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            RetirementHome oldPeopleWorld = new RetirementHome();

            int sumOfPooledMoney = oldPeopleWorld.PoolMoneyFromIRAs();
            Console.WriteLine($"The amount of money the residents at Old People World pooled together this month is: ${sumOfPooledMoney}.");

            int sumOfMonthlyExpenses = oldPeopleWorld.CountMonthlyExpenses();
            Console.WriteLine($"The amount of money the residents at Old People World will cumulatively spend this month is: ${sumOfMonthlyExpenses}.");

            bool casinoTrip = oldPeopleWorld.HasEnoughForCasinoBusTrip();
            Console.WriteLine($"Do the residents at Old People World have enough for a casino bus trip? OUTCOME = {casinoTrip}.");
        }
    }
}


