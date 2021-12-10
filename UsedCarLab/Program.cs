using System;
using System.Collections.Generic;

namespace UsedCarLab
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
        static bool isMainMenuOrExit(string entry)
        {
            if (entry.ToLower() == "m" || entry.ToLower() == "e")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isValid_MainMenu(string entry)
        {
            if (entry == "1" || entry == "2" || entry == "3" || entry == "4" || entry == "5")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isValidVehicleNumber(List<Car> listOfCars, int vehicleNumber)
        {
            if (vehicleNumber > 0 && vehicleNumber <= listOfCars.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isYesNo(string entry)
        {
            if (entry.ToLower() == "y" || entry.ToLower() == "n")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        static bool isValidSearchOption(string entry)
        {
            if (entry == "1" || entry == "2" || entry == "3" || entry == "4")
            {
                return true;
            }
            else
            {
                return false;
            }
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

            // ACTUAL PROGRAM
            Console.WriteLine("Greetings! Welcome to Ranch Motors!");
            bool continueApplication = true;

            do
            {
                Console.WriteLine("\nMENU OPTIONS:");
                Console.WriteLine("[1] See list of available vehicles");
                Console.WriteLine("[2] Purchase a vehicle");
                Console.WriteLine("[3] Trade-in a used vehicle");
                Console.WriteLine("[4] Perform a vehicle search");
                Console.WriteLine("[5] Exit application");

                Console.Write("\nWhat would you like to do today?: ");
                string userCommand = Console.ReadLine();

                while (!isValid_MainMenu(userCommand))
                {
                    Console.Write("I'm sorry but that was not a valid menu option. Please enter a valid menu number: ");
                    userCommand = Console.ReadLine();
                }

                if (userCommand == "1")
                {
                    Console.WriteLine("\nGreat! Here is the list of vehicles we have available to purchase...");
                    myCarLot.ListCars();
                    Console.WriteLine("\nOPTIONS:");
                    Console.WriteLine("[M]ain Menu");
                    Console.WriteLine("[E]xit Application");
                    Console.Write("\nWhat would you like to do next?: ");
                    userCommand = Console.ReadLine().ToLower();

                    while (!isMainMenuOrExit(userCommand))
                    {
                        Console.Write("I'm sorry, but that was not a valid entry. Please select [M]ain Menu or [E]xit Application: ");
                        userCommand = Console.ReadLine().ToLower();
                    }

                    if (userCommand == "m")
                    {
                        continueApplication = true;
                    }
                    else
                    {
                        continueApplication = false;
                    }
                }
                else if (userCommand == "2")
                {
                    Console.WriteLine("\nHere are the vehicles available for purchase:");
                    myCarLot.ListVehiclesWithIndex(myCarLot.carList);

                    Console.Write("\nPlease enter the number of the vehicle you wish to purchase: ");
                    int vehicleNumber = int.Parse(Console.ReadLine());

                    while (!isValidVehicleNumber(myCarLot.carList, vehicleNumber))
                    {
                        Console.Write("Sorry, that was not a valid entry. Please enter the number of the vehicle you wish to purchase: ");
                        vehicleNumber = int.Parse(Console.ReadLine());
                    }

                    Console.WriteLine($"\nThanks for purchasing the {myCarLot.carList[vehicleNumber - 1].GetMake()} {myCarLot.carList[vehicleNumber - 1].GetModel()}! As a reminder, here are the details of your vehicle:");
                    Console.WriteLine(myCarLot.carList[vehicleNumber - 1]);

                    myCarLot.RemoveCar(vehicleNumber - 1);

                    Console.Write("\nWould you like to purchase another vehicle? [Y]es/[N]o: ");
                    userCommand = Console.ReadLine();

                    while (!isYesNo(userCommand))
                    {
                        Console.Write("\nSorry, that was not a valid command. Would you like to purchase another vehicle? [Y]es/[N]o: ");
                        userCommand = Console.ReadLine().ToLower();
                    }

                    if (userCommand == "y")
                    {
                        do
                        {
                            Console.WriteLine("\nHere are the remaining vehicles available for purchase:");
                            myCarLot.ListVehiclesWithIndex(myCarLot.carList);

                            Console.Write("\nPlease enter the number of the vehicle you wish to purchase: ");
                            vehicleNumber = int.Parse(Console.ReadLine());

                            while (!isValidVehicleNumber(myCarLot.carList, vehicleNumber))
                            {
                                Console.Write("Sorry, that was not a valid entry. Please enter the number of the vehicle you wish to purchase: ");
                                vehicleNumber = int.Parse(Console.ReadLine());
                            }

                            Console.WriteLine($"\nThanks for purchasing the {myCarLot.carList[vehicleNumber - 1].GetMake()} {myCarLot.carList[vehicleNumber - 1].GetModel()}! As a reminder, here are the details of your vehicle:");
                            Console.WriteLine(myCarLot.carList[vehicleNumber - 1]);

                            myCarLot.RemoveCar(vehicleNumber - 1);

                            Console.Write("\nWould you like to purchase another vehicle? [Y]es/[N]o: ");
                            userCommand = Console.ReadLine().ToLower();

                            while (!isYesNo(userCommand))
                            {
                                Console.Write("\nSorry, that was not a valid command. Would you like to purchase another vehicle? [Y]es/[N]o: ");
                                userCommand = Console.ReadLine().ToLower();
                            }

                        } while (userCommand == "y");
                    }
                    else
                    {
                        Console.WriteLine("\nOPTIONS:");
                        Console.WriteLine("[M]ain Menu");
                        Console.WriteLine("[E]xit Application");
                        Console.Write("\nWhat would you like to do next?: ");
                        userCommand = Console.ReadLine().ToLower();

                        while (!isMainMenuOrExit(userCommand))
                        {
                            Console.Write("I'm sorry, but that was not a valid entry. Please select [M]ain Menu or [E]xit Application: ");
                            userCommand = Console.ReadLine().ToLower();
                        }

                        if (userCommand == "m")
                        {
                            continueApplication = true;
                        }
                        else
                        {
                            continueApplication = false;
                        }
                    }
                }
                else if (userCommand == "3")
                {
                    Console.WriteLine("\nBefore we trade in your used vehicle, we will need some information from you first.");

                    Console.Write("What is the make of your vehicle?: ");
                    string tradeMake = Console.ReadLine();

                    Console.Write("What is the model of your vehicle?: ");
                    string tradeModel = Console.ReadLine();

                    Console.Write("What year was your vehicle manufactured?: ");
                    int tradeYear = int.Parse(Console.ReadLine());

                    Console.Write("How much are you hoping to receive for your trade-in?: $");
                    decimal tradePrice = decimal.Parse(Console.ReadLine());

                    Console.Write("What is the current mileage of your trade-in?: ");
                    int tradeMileage = int.Parse(Console.ReadLine());

                    UsedCar tradeIn = new UsedCar(tradeMake, tradeModel, tradeYear, tradePrice, tradeMileage);
                    myCarLot.AddCar(tradeIn);

                    Console.WriteLine($"\nThanks for trading in your {tradeMake} {tradeModel}!");

                    Console.Write("Would you like to trade in another vehicle? [Y]es/[N]o: ");
                    userCommand = Console.ReadLine().ToLower();

                    while (!isYesNo(userCommand))
                    {
                        Console.Write("\nSorry, that was not a valid command. Would you like to purchase another vehicle? [Y]es/[N]o: ");
                        userCommand = Console.ReadLine().ToLower();
                    }

                    if (userCommand == "y")
                    {
                        do
                        {
                            Console.WriteLine("\nBefore we trade in your next used vehicle, we will need some information from you first.");

                            Console.Write("What is the make of your vehicle?: ");
                            tradeMake = Console.ReadLine();

                            Console.Write("What is the model of your vehicle?: ");
                            tradeModel = Console.ReadLine();

                            Console.Write("What year was your vehicle manufactured?: ");
                            tradeYear = int.Parse(Console.ReadLine());

                            Console.Write("How much are you hoping to receive for your trade-in?: $");
                            tradePrice = decimal.Parse(Console.ReadLine());

                            Console.Write("What is the current mileage of your trade-in?: ");
                            tradeMileage = int.Parse(Console.ReadLine());

                            tradeIn = new UsedCar(tradeMake, tradeModel, tradeYear, tradePrice, tradeMileage);
                            myCarLot.AddCar(tradeIn);

                            Console.WriteLine($"\nThanks for trading in your {tradeMake} {tradeModel}!");

                            Console.Write("Would you like to trade in another vehicle? [Y]es/[N]o: ");
                            userCommand = Console.ReadLine().ToLower();

                            while (!isYesNo(userCommand))
                            {
                                Console.Write("\nSorry, that was not a valid command. Would you like to purchase another vehicle? [Y]es/[N]o: ");
                                userCommand = Console.ReadLine().ToLower();
                            }

                        } while (userCommand == "y");
                    }
                    else
                    {
                        Console.WriteLine("\nOPTIONS:");
                        Console.WriteLine("[M]ain Menu");
                        Console.WriteLine("[E]xit Application");
                        Console.Write("\nWhat would you like to do next?: ");
                        userCommand = Console.ReadLine();

                        while (!isMainMenuOrExit(userCommand))
                        {
                            Console.Write("I'm sorry, but that was not a valid entry. Please select [M]ain Menu or [E]xit Application: ");
                            userCommand = Console.ReadLine().ToLower();
                        }

                        if (userCommand == "m")
                        {
                            continueApplication = true;
                        }
                        else
                        {
                            continueApplication = false;
                        }
                    }
                }
                else if (userCommand == "4")
                {
                    Console.WriteLine("Here are the available search options:");
                    Console.WriteLine("[1] Search by MAKE");
                    Console.WriteLine("[2] Search by MODEL");
                    Console.WriteLine("[3] Search by PRICE");
                    Console.WriteLine("[4] Search by NEW or USED");
                    Console.Write("\nWhat kind of search would you like to perform?: ");
                    string searchOption = Console.ReadLine();

                    while (!isValidSearchOption(searchOption))
                    {
                        Console.Write("Sorry, that was not a valid entry. Please enter the number of the search you would like to perform: ");
                        searchOption = Console.ReadLine();
                    }

                    if (searchOption == "1")
                    {
                        Console.Write("\nPlease enter the make of the vehicle you are searching for: ");
                        string entryMake = Console.ReadLine();

                        if (VehicleMakeExists(myCarLot, entryMake))
                        {
                            Console.WriteLine($"\nMatch found! Here are the vehicles that match your search of {entryMake}:");

                            foreach (Car vehicle in myCarLot.carList)
                            {
                                if (vehicle.GetMake().Contains(entryMake))
                                {
                                    Console.WriteLine(vehicle);
                                }
                            }

                            Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                            userCommand = Console.ReadLine().ToLower();

                            while (!isYesNo(userCommand))
                            {
                                Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                userCommand = Console.ReadLine().ToLower();
                            }

                            if (userCommand == "y")
                            {
                                do
                                {
                                    Console.Write("\nPlease enter the make of the vehicle you are searching for: ");
                                    entryMake = Console.ReadLine();

                                    if(VehicleMakeExists(myCarLot, entryMake))
                                    {
                                        Console.WriteLine($"\nMatch found! Here are the vehicles that match your search of {entryMake}:");

                                        foreach (Car vehicle in myCarLot.carList)
                                        {
                                            if (vehicle.GetMake().Contains(entryMake))
                                            {
                                                Console.WriteLine(vehicle);
                                            }
                                        }

                                        Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                                        userCommand = Console.ReadLine().ToLower();

                                        while (!isYesNo(userCommand))
                                        {
                                            Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                            userCommand = Console.ReadLine().ToLower();
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine($"Sorry, we did not find any vehicles that matched your search of {entryMake}.");

                                        Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                                        userCommand = Console.ReadLine().ToLower();

                                        while (!isYesNo(userCommand))
                                        {
                                            Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                            userCommand = Console.ReadLine().ToLower();
                                        }
                                    }
                                } while (userCommand == "y");
                            }
                            else if (userCommand == "n")
                            {
                                Console.WriteLine("\nOPTIONS:");
                                Console.WriteLine("[M]ain Menu");
                                Console.WriteLine("[E]xit Application");
                                Console.Write("\nWhat would you like to do next?: ");
                                userCommand = Console.ReadLine().ToLower();

                                while (!isMainMenuOrExit(userCommand))
                                {
                                    Console.Write("I'm sorry, but that was not a valid entry. Please select [M]ain Menu or [E]xit Application: ");
                                    userCommand = Console.ReadLine().ToLower();
                                }

                                if (userCommand == "m")
                                {
                                    continueApplication = true;
                                }
                                else
                                {
                                    continueApplication = false;
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Sorry, we did not find any vehicles that matched your search of {entryMake}.");

                            Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                            userCommand = Console.ReadLine().ToLower();

                            while (!isYesNo(userCommand))
                            {
                                Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                userCommand = Console.ReadLine().ToLower();
                            }

                            do
                            {
                                Console.Write("\nPlease enter the make of the vehicle you are searching for: ");
                                entryMake = Console.ReadLine();

                                if (VehicleMakeExists(myCarLot, entryMake))
                                {
                                    Console.WriteLine($"\nMatch found! Here are the vehicles that match your search of {entryMake}:");

                                    foreach (Car vehicle in myCarLot.carList)
                                    {
                                        if (vehicle.GetMake().Contains(entryMake))
                                        {
                                            Console.WriteLine(vehicle);
                                        }
                                    }

                                    Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                                    userCommand = Console.ReadLine().ToLower();

                                    while (!isYesNo(userCommand))
                                    {
                                        Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                        userCommand = Console.ReadLine().ToLower();
                                    }
                                }
                                else
                                {
                                    Console.WriteLine($"Sorry, we did not find any vehicles that matched your search of {entryMake}.");

                                    Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                                    userCommand = Console.ReadLine().ToLower();

                                    while (!isYesNo(userCommand))
                                    {
                                        Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                        userCommand = Console.ReadLine().ToLower();
                                    }

                                    do
                                    {
                                        if (userCommand == "y")
                                        {
                                            Console.Write("\nPlease enter the make of the vehicle you are searching for: ");
                                            entryMake = Console.ReadLine();

                                            if (VehicleMakeExists(myCarLot, entryMake))
                                            {
                                                Console.WriteLine($"\nMatch found! Here are the vehicles that match your search of {entryMake}:");

                                                foreach (Car vehicle in myCarLot.carList)
                                                {
                                                    if (vehicle.GetMake().Contains(entryMake))
                                                    {
                                                        Console.WriteLine(vehicle);
                                                    }
                                                }

                                                Console.Write("\nWould you like to perform another search by make? [Y]es/[N]o: ");
                                                userCommand = Console.ReadLine().ToLower();

                                                while (!isYesNo(userCommand))
                                                {
                                                    Console.Write("\nSorry, that was not a valid command. Would you like to perform another search by make? [Y]es/[N]o: ");
                                                    userCommand = Console.ReadLine().ToLower();
                                                }

                                            }
                                        }
                                        else if (userCommand == "n")
                                        {
                                            Console.WriteLine("\nOPTIONS:");
                                            Console.WriteLine("[M]ain Menu");
                                            Console.WriteLine("[E]xit Application");
                                            Console.Write("\nWhat would you like to do next?: ");
                                            userCommand = Console.ReadLine().ToLower();

                                            while (!isMainMenuOrExit(userCommand))
                                            {
                                                Console.Write("I'm sorry, but that was not a valid entry. Please select [M]ain Menu or [E]xit Application: ");
                                                userCommand = Console.ReadLine().ToLower();
                                            }

                                            if (userCommand == "m")
                                            {
                                                continueApplication = true;
                                                break;
                                            }
                                            else
                                            {
                                                continueApplication = false;
                                                break;
                                            }
                                        }
                                    } while (userCommand == "y");
                                }
                            } while (userCommand == "y");
                        }
                    }
                    else if (searchOption == "2")
                    {
                        // DID NOT COMPLETE THIS CHALLENGE (Search by model)
                    }
                    else if (searchOption == "3")
                    {
                        // DID NOT COMPLETE THIS CHALLENGE (Search by model)
                    }
                    else if (searchOption == "4")
                    {
                        // DID NOT COMPLETE THIS CHALLENGE (Search by model)
                    }
                }
                else if (userCommand == "5")
                {
                    continueApplication = false;
                }
            } while (continueApplication == true);

            Console.WriteLine("\nThe application will now terminate. Goodbye!");
        }
    }


}

/* ----- WHAT WILL THE APPLICATION DO? -----
 * Display a set of at least 6 cars (3 new and 3 used) along with Add and Quit options
 * Let the user select one of the cars
 * Ask if they want to buy the car. If they enter yes, remove it from the list.
 * If they want to add another car to the list, get the details, instantiate a new car of the appropriate class (Car class for new cars, or UsedCAr) and add it to your data collection.
 * Keep looping until they choose to quit.
 * 
 * ----- BUILD SPECIFICATIONS -----
 * Create a class named Car (5 points) to store the data about a car. This class should contain:
 * ... Data members for car details
 * ...... A string for the make
 * ...... A string for the model
 * ...... An int for the year
 * ...... A decimal for the price
 * ... A no-arguments constructor that sets data memebrs to default values (blanks or your choice)
 * ... A constructor with four arguments matching the order above
 * ... Properties for all data members
 * ... An override to the ToString() method returning a formatted string with the car details
 * 
 * Create a subclass of Car named UsedCar (3 points). UsedCar has additional members:
 * ... Data member: A double for mileage
 * ... Constructor: Takes 5 arguments (same order as car, but with mileage added)
 * ... ToString overrides Car's ToString() to include (Used) and the mileage
 * 
 * ----- LOOK AT THIS NEXT PART IN THE DIRECTIONS THEMSELVES -----
 * Basically it sounds like I need to create a List or Dictionary and store the car information in a CarLot class.
 * Make sure the CarLot class includes the following methods:
 * ... Add a car
 * ... List all cars to the console
 * ... Remove a car
 * 
 * ----- HINTS -----
 * Use the right access modifiers (public/private/protected)
 * Make sure to match the signature of ToString() from Object
 * You can just use \t tab escape characters to line things up, or if you want to get fancier, look up text formatters
 * Let polymorphism work for you
 * Remember casting
 * 
 * ----- EXTRA CHALLENGES ----
 * Write a CarLotApp class which instantiates and puts cars in your CarLot class. It should invoke CarLot methods to let a user:
 * ... List all cars
 * ... Buy a car, which removes it from the inventory
 * ... Add a car
 * The main method would then create an instance of CarLotApp and call its methods as needed
 * Think about other methods which might be usedful for your CarLot. Implement them and modify your app to take advantage of them.
 * Modify or create a class named Validator with static methods to validate the data in this application.
 * Create an Admin mode which lets the user edit, delete, or replace cars. Move the Add a car feature here.
 * Provide search features:
 * ... View all cars of an entered make
 * ... View all cars of an entered year
 * ... View all cars of an entered price or less
 * ... View only used cars or view only new cars
 */