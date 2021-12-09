using System;
using System.Collections.Generic;

namespace PolymorphismDemo
{
    class Book
    {
        /*
         * Ebook has three functions:
         * GetTitle()
         * GetAuthor()
         * PrintInto()
         * These three functions make up Book's interface. i.e.: how you interact with the object.
         */

        protected string Title;
        protected string Author; // Protected means "private" but it allows derived classes to access it. If you just use "private", then only the base class can access the member(s). Subclasses cannot use private, only protected.

        public Book(string Title, string Author)
        {
            this.Title = Title;
            this.Author = Author; // "this.Author" is referring to the public string Author above. Same for the public string Title above.
        }

        public string GetTitle() // This function essentially makes things "Read-Only" - you can't change it since Title is protected/private.
        {
            return Title;
        }

        public string GetAuthor() // This function essentially makes things "Read-Only" - you can't change it since Author is protected/private.
        {
            return Author;
        }

        public virtual void PrintInfo()
        {
            Console.WriteLine($"Book {Title} by {Author}");
        }
    }

    class Ebook : Book
    {
        /*
         * Ebook has four functions:
         * GetTitle()
         * GetAuthor()
         * GetFormat()
         * PrintInto()
         * These four functions make up Ebook's interface. i.e.: how you interact with the object.
         */

        private string Format; // Kindle or Nook

        public Ebook(string Title, string Author, string Format) : base(Title, Author)
        {
            this.Format = Format; // "this.Format" is referring to public string Format above.
        }

        public string GetFormat() // This function essentially makes things "Read-Only" - you can't change it since Format is protected/private.
        {
            return Format;
        }

        public override void PrintInfo()
        {
            //base.PrintInfo();
            Console.WriteLine($"Ebook {Title} by {Author} available for {Format}");
        }
    }

    class Program
    {
        // This function demonstrates polymorphism. It doesn't car what the actual types are in the list as long as they're dervied from Book or an instance of Book itself.
        private static void PrintLibrary(string libraryName, List<Book> library)
        {
            Console.WriteLine(libraryName);
            foreach (Book next in library)
            {
                next.PrintInfo(); // Dotnet will call the correct version of PrintInfo() for the current object -- this is known as Polymorphism
            }
        }

        static void Main(string[] args)
        {
            List<Book> library = new List<Book>();
            Book myBook;

            myBook = new Book("Christmas Carol", "Charles Dickens");
            Console.WriteLine($"Adding a book by {myBook.GetAuthor()}");
            library.Add(myBook);

            myBook = new Ebook("Great Expectations", "Charles Dickens", "Kindle");
            Console.WriteLine($"Adding a book by {myBook.GetAuthor()}");
            library.Add(myBook);

            myBook = new Ebook("The Martian Chronicles", "Ray Bradbury", "Nook");
            Console.WriteLine($"Adding a book by {myBook.GetAuthor()}");
            library.Add(myBook);

            PrintLibrary("Cool Library", library);
        }
    }
}
