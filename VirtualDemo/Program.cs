using System;
using System.Collections.Generic;

namespace VirtualDemo
{
    abstract class Car
    {
        // The word "abstract" means they can't create an instance of this class; they can only create classes DERIVED from it.

        public string Make;
        public string Model;
        public int GasAmount;

        public virtual void Drive()
        {
            Console.WriteLine("I'm driving!");
        }
    }

    class EconomyCar : Car
    {
        public override void Drive()
        {
            Console.WriteLine("I'm driving slowly!");
        }
    }

    class RaceCar : Car
    {
        int SuperchargerSize;
        public override void Drive()
        {
            Console.WriteLine("I'm driving really fast!");
        }
    }

    class Program
    {
        static void TestTrack(Car testCar)
        {
            // This is polymorphism in action.
            // The computer will call the correct version of Drive(); in other words, we don't have to worry about it.
            // Downside: We only know this is a Car. So if we pass in a RaceCar, we cannot check the value of SuperchargerSize.
            // Question: What if I really need to access SuperchargerSize? We have to "cast" (Google it).
            Console.WriteLine("\nWe're at the test track!");
            Console.WriteLine($"We're testing a {testCar.Model}!");
            testCar.Drive();
        }

        static void Main(string[] args)
        {
            EconomyCar pinto = new EconomyCar();
            pinto.Make = "Ford";
            pinto.Model = "Pinto";
            pinto.GasAmount = 10;
            Console.WriteLine("Let's drive the Pinto!");
            pinto.Drive(); // Calls the EconomyCar version of Drive()

            RaceCar f1 = new RaceCar();
            f1.Make = "Formula";
            f1.Model = "One";
            f1.GasAmount = 30;
            Console.WriteLine("\nLet's drive the Formula One!");
            f1.Drive(); // Calls the Racecar version of Drive()

            List<Car> cars = new List<Car>();
            cars.Add(pinto);
            cars.Add(f1);

            Car myCar;
            myCar = pinto;
            Console.WriteLine("\nmyCar points to the Pinto:");
            Console.WriteLine(myCar.Model);
            myCar.Drive(); // The code called the right version of Drive(). This is known as "polymorphism". The scienctific term of polymorphism has to do with similarities between animals. (I.e.: polymorphism is a biological term).

            myCar = f1;
            Console.WriteLine("\nmyCar now points to the F1:");
            Console.WriteLine(myCar.Model);
            myCar.Drive(); // The code called the right version of Drive(). This is known as "polymorphism".

            TestTrack(pinto);
            TestTrack(f1);
        }
    }
}
