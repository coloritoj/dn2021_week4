using System;

namespace PropertiesDemo
{
    // Let's modify this class to not allow Length and Width to be set after the instance is created.
    class Rectangle
    {
        private double pLength; // Generally you type 'p' to indicate a property is private
        private double pWidth;

        public Rectangle(double Length, double Width)
        {
            pLength = Length;
            pWidth = Width;
        }

        public double GetLength() // This allows us to "read" pLength even though it's private
        {
            return pLength;
        }

        public double GetWidth() // This allows us to "read" pWidth even though it's private
        {
            return pWidth;
        }

        public double GetArea()
        {
            return pLength * pWidth;
        }
    }

    // Annoying, but for demo purposes only.
    // Let's allow the programmer to change Width. However, Width must be at least 0.
    // If they try to make it negative, we will just make it 0.
    class RectWithProps
    {
        private double pLength; // Technically this is a member variable
        private double pWidth; // Technically this is a member variable

        public double Length // This is technically a function. It LOOKS like a member variable, but it is not. This simply allows us to get the .Length property, but does not allow us to change it.
        {
            get
            {
                return pLength;
            }
        }

        public double Width // Same thing for Width as Length above. Jeff personally doesn't like these because in Main() it's very hard to tell just by looking at .Length or .Width if you can change it or not.
        {
            get // Having only a getter means "read only"
            {
                return pWidth;
            }
            set // A setter means it is "read-write"
            {
                if (value < 0)
                {
                    pWidth = 0;
                }
                else
                {
                    pWidth = value;
                }
            }
        }

        public RectWithProps(double Length, double Width)
        {
            pLength = Length;
            pWidth = Width;
        }

        public double GetArea()
        {
            return pLength * pWidth;
        }
    }

    class RectWithFullProps
    {

        // What is seen here is the EXACT same thing as what is commented out in green below. This is the short-hand way to write this.
        // Going forward, when we start using databases, this is pretty much the syntax we will be using when setting properties.
        public double Length { get; set; } // Technically this is a property
        public double Width { get; set; } // Technically this is a property

        /*
        private double pLength;
        private double pWidth;

        public double Length
        {
            get
            {
                return pLength;
            }
            set
            {
                pLength = value;
            }
        }

        public double Width
        {
            get
            {
                return pWidth;
            }
            set
            {
                pWidth = value;
            }
        } */

        public RectWithFullProps(double Length, double Width)
        {
            this.Length = Length;
            this.Width = Width;
        }

        public double GetArea()
        {
            return Length * Width;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r1 = new Rectangle(3.5, 2.6); // Making the Properties private up under Class Rectangle makes r1.Length and r1.Width inaccessable after the constructor instantiates the object.
            // r1.Length = 3.5;
            // r1.Width = 2.6;
            Console.WriteLine($"Rectangle has Length {r1.GetLength()} and Width {r1.GetWidth()}");
            Console.WriteLine(r1.GetArea());

            Console.WriteLine();

            RectWithProps r2 = new RectWithProps(4.2, 5.5);
            Console.WriteLine(r2.Length);
            Console.WriteLine(r2.Width);
            r2.Width = -5.0;
            Console.WriteLine($"We tried to set Width to -5.0, but in fact it got set to {r2.Width}");
            // r2.Length = 5.8; // The getter allows us to get Length, but does not allow us to set it unless we have a setter.

            Console.WriteLine("=====");

            // This is just a silly example. We are basically back to "square one" for what we did for r1.
            // However, the reason we do this is for database reasons. The systems for the way they read/write data requires getters/setters (I think that's what he said).
            RectWithFullProps r3 = new RectWithFullProps(5.6, 7.8); 
            Console.WriteLine(r3.Length);
            Console.WriteLine(r3.Width);
            r3.Length = 11.2;
            r3.Width = 19.2;
            Console.WriteLine($"Here is the area: {r3.GetArea()}");

        }
    }
}
