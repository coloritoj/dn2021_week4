using System;
using System.Collections.Generic;

namespace InterfaceDemo
{
    interface IRentable // Generally you create interfaces with the letter "I" at the start to indicate it's an interface.
    {
        DateTime? GetDueDate(); // ? makes this nullable
        void Rent();
        void Return(DateTime ReturnedOn);
    }

    class LibraryBook : IRentable // The reason it initially "yells" at first is because we haven't implemented the functions from IRentable yet. Just click the IRentable and click "implement interface".
    {
        public string Title;
        public string Author;
        public DateTime? DueDate; // Putting the ? on the end makes it a slightly different type. It allows it to be a NULLABLE type if necessary. Can now hold DueDate OR Null.
        public DateTime LastReturn;

        public DateTime? GetDueDate() // ? makes this nullable
        {
            return DueDate;
        }

        public void Rent()
        {
            DueDate = DateTime.Today.AddMonths(1);
        }

        public void Return(DateTime ReturnedOn)
        {
            LastReturn = ReturnedOn;
            DueDate = null;
        }

        public override string ToString()
        {
            return $"Library Book: Title {Title} by {Author} due on {DueDate}.";
        }
    }

    class DVD : IRentable
    {
        public string Title;
        public string Director;
        public int Minutes;
        public bool isCheckedOut;
        public DateTime? DueBackOn;

        public DateTime? GetDueDate()
        {
            return DueBackOn;
        }

        public void Rent()
        {
            DueBackOn = DateTime.Today.AddDays(21);
            isCheckedOut = true;
        }

        public void Return(DateTime ReturnedOn)
        {
            isCheckedOut = false;
        }

        public override string ToString()
        {
            return $"DVD: Title {Title} directed by {Director} due on {DueBackOn}.";
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<IRentable> MyRentedItems = new List<IRentable>();

            LibraryBook book1 = new LibraryBook();
            book1.Title = "Great Expectations";
            book1.Author = "Charles Dickens";
            book1.Rent();
            MyRentedItems.Add(book1);

            DVD myDVD = new DVD();
            myDVD.Title = "Star Wars: A New Hope";
            myDVD.Director = "George Lucas";
            myDVD.Minutes = 100;
            myDVD.Rent();
            MyRentedItems.Add(myDVD);

            foreach (IRentable rented in MyRentedItems)
            {
                Console.WriteLine(rented); // Note for myself: I think the ToString() allows us to just type the "rented" in this example in the console writeline().
            }
        }
    }
}
