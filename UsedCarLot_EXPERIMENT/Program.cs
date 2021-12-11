using System;
using System.Collections.Generic;

namespace UsedCarLot_EXPERIMENT
{
    class Car
    {
        private string Make;
        private string Model;
        private int Year;
        private decimal Price;

        public Car()
        {
            Make = "N/A";
            Model = "N/A";
            Year = 0;
            Price = 0.00m;
        }

        public Car(string vehicleMake, string vehicleModel, int vehicleYear, decimal vehiclePrice)
        {
            Make = vehicleMake;
            Model = vehicleModel;
            Year = vehicleYear;
            Price = vehiclePrice;
        }

        public string GetMake()
        {
            return Make;
        }

        public string GetModel()
        {
            return Model;
        }

        public int GetYear()
        {
            return Year;
        }

        public decimal GetPrice()
        {
            return Price;
        }

        public override string ToString()
        {
            return $"(NEW) MAKE: {GetMake()} | MODEL: {GetModel()} | YEAR: {GetYear()} | PRICE: ${GetPrice()}";
        }
    }

    class UsedCar : Car
    {
        private double Mileage;

        public UsedCar(string vehicleMake, string vehicleModel, int vehicleYear, decimal vehiclePrice, double vehicleMileage) : base(vehicleMake, vehicleModel, vehicleYear, vehiclePrice)
        {
            Mileage = vehicleMileage;
        }

        public double GetMileage()
        {
            return Mileage;
        }

        public override string ToString()
        {
            return $"(USED) MAKE: {GetMake()} | MODEL: {GetModel()} | YEAR: {GetYear()} | PRICE: ${GetPrice()} | MILEAGE: {GetMileage()}";
        }
    }

    class CarLot
    {
        public List<Car> carList = new List<Car>();

        public void AddCar(Car additionalCar)
        {
            carList.Add(additionalCar);
        }

        public void ListCars()
        {
            foreach (Car vehicle in carList)
            {
                Console.WriteLine(vehicle);
            }
        }

        public void RemoveCar(int indexOfCarToRemove)
        {
            carList.Remove(carList[indexOfCarToRemove]);
        }
    }

    class CarLotApp : CarLot
    {
        public void ListVehiclesWithIndex(List<Car> listOfVehicles)
        {
            for (int i = 0; i < listOfVehicles.Count; i++)
            {
                Console.WriteLine($"Vehicle {i + 1}: {listOfVehicles[i]}");
            }
        }
    }

    class Program
    {
        static bool IsValidVehicleNumber(List<Car> listOfCars, int userNumber)
        {
            if (userNumber > 0 && userNumber <= listOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool ContinueApplication(string entry)
        {
            if (entry == "m")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string ListMainMenuOptions()
        {
            Console.WriteLine("\n========================================");
            Console.WriteLine("MAIN MENU");
            Console.WriteLine("[1] See list of available vehicles");
            Console.WriteLine("[2] Purchase a vehicle");
            Console.WriteLine("[3] Trade-in a used vehicle");
            Console.WriteLine("[4] Perform a vehicle search");
            Console.WriteLine("[5] Exit application");
            Console.WriteLine("========================================");

            Console.Write("\nWhat would you like to do today?: ");
            string userDecision = Console.ReadLine();
            bool validDecision;

            do
            {
                if (userDecision == "1" || userDecision == "2" || userDecision == "3" || userDecision == "4" || userDecision == "5")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine();
                    if (userDecision == "1" || userDecision == "2" || userDecision == "3" || userDecision == "4" || userDecision == "5")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static string RunMainMenuOption1(CarLot myCarLot)
        {
            Console.WriteLine("\n=====================================================================================");
            Console.WriteLine("VEHICLES AVAILABLE FOR PURCHASE:");
            myCarLot.ListCars();
            Console.WriteLine("======================================================================================");

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            string userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static string RunMainMenuOption2(CarLotApp myCarLotApp)
        {
            Console.WriteLine("\n=====================================================================================");
            Console.WriteLine("VEHICLES AVAILABLE FOR PURCHASE:");
            myCarLotApp.ListVehiclesWithIndex(myCarLotApp.carList);
            Console.WriteLine("======================================================================================");

            Console.Write("\nPlease enter the number of the vehicle you would like to purchase: ");
            string userDecision = Console.ReadLine();
            int userNumber = int.Parse(userDecision);
            bool validNumber = IsValidVehicleNumber(myCarLotApp.carList, userNumber);

            do
            {
                if (validNumber == true)
                {
                    Console.WriteLine($"\nThanks for purchasing the {myCarLotApp.carList[userNumber - 1].GetMake()} {myCarLotApp.carList[userNumber - 1].GetModel()}! As a reminder, here are the details of your vehicle:");
                    Console.WriteLine(myCarLotApp.carList[userNumber - 1]);
                    myCarLotApp.RemoveCar(userNumber - 1);
                }
                else
                {
                    Console.Write($"You did not enter a valid vehicle number. Please try again: ");
                    userDecision = Console.ReadLine();
                    userNumber = int.Parse(userDecision);
                    validNumber = IsValidVehicleNumber(myCarLotApp.carList, userNumber);

                    if (validNumber == true)
                    {
                        Console.WriteLine($"\nThanks for purchasing the {myCarLotApp.carList[userNumber - 1].GetMake()} {myCarLotApp.carList[userNumber - 1].GetModel()}! As a reminder, here are the details of your vehicle:");
                        Console.WriteLine(myCarLotApp.carList[userNumber - 1]);
                        myCarLotApp.RemoveCar(userNumber - 1);
                    }
                    else
                    {
                        Console.Write($"You did not enter a valid vehicle number. Please try again: ");
                        userDecision = Console.ReadLine();
                        userNumber = int.Parse(userDecision);
                        validNumber = IsValidVehicleNumber(myCarLotApp.carList, userNumber);
                    }
                }
            } while (validNumber == false);

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static string RunMainMenuOption3(CarLot myCarLot)
        {
            Console.WriteLine("\nBefore we trade-in your vehicle, you'll need to fill out some information first.");

            Console.Write("What is the make of your vehicle?: ");
            string tradeMake = Console.ReadLine();

            Console.Write("What is the model of your vehicle?: ");
            string tradeModel = Console.ReadLine();

            Console.Write("What is the year in which your vehicle was manufactured?: ");
            int tradeYear = int.Parse(Console.ReadLine());

            Console.Write("How much are you hoping to receive for your vehicle?: $");
            decimal tradePrice = decimal.Parse(Console.ReadLine());

            Console.Write("What is the current mileage on your vehicle?: ");
            int tradeMileage = int.Parse(Console.ReadLine());

            UsedCar tradeIn = new UsedCar(tradeMake, tradeModel, tradeYear, tradePrice, tradeMileage);
            myCarLot.AddCar(tradeIn);

            Console.WriteLine($"\nThanks for trading in your {tradeMake} {tradeModel}! You have received ${tradePrice} for it.");

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            string userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static string RunMainMenuOption4(CarLot myCarLot)
        {
            Console.WriteLine("\n==============================");
            Console.WriteLine("SEARCH OPTIONS");
            Console.WriteLine("[1] Search by make");
            Console.WriteLine("[2] Search by year");
            Console.WriteLine("[3] Search by price");
            Console.WriteLine("[4] Search by new/used");
            Console.WriteLine("==============================");

            Console.Write("\nWhat kind of search would you like to perform?: ");
            string userDecision = Console.ReadLine();
            bool validDecision;

            do
            {
                if (userDecision == "1" || userDecision == "2" || userDecision == "3" || userDecision == "4")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid search option. Please try again: ");
                    userDecision = Console.ReadLine();
                    if (userDecision == "1" || userDecision == "2" || userDecision == "3" || userDecision == "4")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            if (userDecision == "1")
            {
                userDecision = SearchByMake(myCarLot);
            }
            else if (userDecision == "2")
            {
                // CREATE METHOD AND PUT HERE (YEAR)
                userDecision = SearchByYear(myCarLot);
            }
            else if (userDecision == "3")
            {
                userDecision = SearchByPrice(myCarLot);
            }
            else if (userDecision == "4")
            {
                // CREATE METHOD AND PUT HERE (NEW/USED)
            }

            return userDecision;
        }

        static string SearchByMake(CarLot myCarLot)
        {
            Console.Write("Please enter the make of the vehicle you would like to search for: ");
            string vehicleMake = Console.ReadLine();

            if (VehicleMakeExists(myCarLot, vehicleMake) == true)
            {
                Console.WriteLine($"\nMatch found! Here are the vehicles that match your search for {vehicleMake}:");
                foreach (Car vehicle in myCarLot.carList)
                {
                    if (vehicle.GetMake().Contains(vehicleMake))
                    {
                        Console.WriteLine(vehicle);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, we did not a vehicle matching your search.");
            }

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            string userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static bool VehicleMakeExists(CarLot myCarLot, string entry)
        {
            int countMatchesFound = 0;

            for (int i = 0; i < myCarLot.carList.Count; i++)
            {
                if (myCarLot.carList[i].GetMake().Contains(entry))
                {
                    countMatchesFound++;
                }
            }

            if (countMatchesFound > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string SearchByYear(CarLot myCarLot)
        {
            Console.Write("Please enter the minimum year for your vehicle search: ");
            int minYear = int.Parse(Console.ReadLine());

            Console.Write("Please enter the maximum year for your vehicle search: ");
            int maxYear = int.Parse(Console.ReadLine());

            if (YearMatchExists(myCarLot, minYear, maxYear) == true)
            {
                Console.WriteLine($"\nMatch found! Here are the vehicles that match your search:");
                foreach (Car vehicle in myCarLot.carList)
                {
                    if (vehicle.GetYear() >= minYear && vehicle.GetYear() <= maxYear)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, we did not find any vehicles matching your search.");
            }

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            string userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;
        }

        static bool YearMatchExists(CarLot myCarLot, int minYear, int maxYear)
        {
            int countMatchesFound = 0;

            for (int i = 0; i < myCarLot.carList.Count; i++)
            {
                if (myCarLot.carList[i].GetYear() >= minYear && myCarLot.carList[i].GetYear() <= maxYear)
                {
                    countMatchesFound++;
                }
            }

            if (countMatchesFound > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static string SearchByPrice(CarLot myCarLot)
        {
            Console.Write($"\nWhat is the maximum price you are willing to spend?: $");
            decimal userPrice = decimal.Parse(Console.ReadLine());

            if (PriceMatchExists(myCarLot, userPrice) == true)
            {
                Console.WriteLine("Match found! Here are all of the vehicles that fit within your budget:");
                foreach (Car vehicle in myCarLot.carList)
                {
                    if (vehicle.GetPrice() <= userPrice)
                    {
                        Console.WriteLine(vehicle);
                    }
                }
            }
            else
            {
                Console.WriteLine("Sorry, we did not a vehicle matching your search.");
            }

            Console.WriteLine("\n=========================");
            Console.WriteLine("MENU OPTIONS");
            Console.WriteLine("[M]ain menu");
            Console.WriteLine("[E]xit application");
            Console.WriteLine("=========================");
            Console.Write("\nWhat would you like to do?: ");
            string userDecision = Console.ReadLine().ToLower();
            bool validDecision;

            do
            {
                if (userDecision == "m" || userDecision == "e")
                {
                    validDecision = true;
                }
                else
                {
                    validDecision = false;
                }

                while (validDecision == false)
                {
                    Console.Write("Sorry, that was not a valid menu option. Please try again: ");
                    userDecision = Console.ReadLine().ToLower();
                    if (userDecision == "m" || userDecision == "e")
                    {
                        validDecision = true;
                    }
                    else
                    {
                        validDecision = false;
                    }
                }
            } while (validDecision == false);

            return userDecision;

        }

        static bool PriceMatchExists(CarLot myCarLot, decimal userPrice)
        {
            int countMatchesFound = 0;

            for (int i = 0; i < myCarLot.carList.Count; i++)
            {
                if (myCarLot.carList[i].GetPrice() <= userPrice)
                {
                    countMatchesFound++;
                }
            }

            if (countMatchesFound > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        static void Main(string[] args)
        {
            CarLotApp myCarLot = new CarLotApp();

            // INSTANTIATE NEW CARS
            Car carOne = new Car("Chevrolet", "Trax", 2022, 20000m);
            Car carTwo = new Car("Chevrolet", "Equinox", 2022, 30000m);
            Car carThree = new Car("Chevrolet", "Traverse", 2022, 40000m);

            // INSTANTIATE USED CARS
            UsedCar usedCarOne = new UsedCar("GMC", "Yukon", 2019, 28500m, 56787);
            UsedCar usedCarTwo = new UsedCar("Buick", "Encore", 2018, 17890m, 25200);
            UsedCar usedCarThree = new UsedCar("Cadillac", "Escalade", 2020, 67000m, 9885);

            // ADD NEW CARS AND USED CARS TO LIST
            myCarLot.AddCar(carOne);
            myCarLot.AddCar(carTwo);
            myCarLot.AddCar(carThree);
            myCarLot.AddCar(usedCarOne);
            myCarLot.AddCar(usedCarTwo);
            myCarLot.AddCar(usedCarThree);

            bool continueApplication = true;
            Console.WriteLine("Greetings! Welcome to Ranch Motors!");

            do
            {
                string userDecision = ListMainMenuOptions();

                if (userDecision == "1")
                {
                    userDecision = RunMainMenuOption1(myCarLot);
                    continueApplication = ContinueApplication(userDecision);
                }
                else if (userDecision == "2")
                {
                    userDecision = RunMainMenuOption2(myCarLot);
                    continueApplication = ContinueApplication(userDecision);
                }
                else if (userDecision == "3")
                {
                    userDecision = RunMainMenuOption3(myCarLot);
                    continueApplication = ContinueApplication(userDecision);
                }
                else if (userDecision == "4")
                {
                    // NEED TO DO THIS
                    userDecision = RunMainMenuOption4(myCarLot);
                    continueApplication = ContinueApplication(userDecision);
                }
                else if (userDecision == "5")
                {
                    continueApplication = false;
                }
            } while (continueApplication == true);

            Console.WriteLine("\nThanks for visiting Ranch Motors! The application will now terminate. Goodbye!");
        }
    }
}
