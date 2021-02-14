using System;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type an int to divide Max Int By");
            try
            {
                LineReader.ReadLines();
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Quit trying to divide by zero, you might  break something");
            }
        }
    }

    static class LineReader
    {
        public static void ReadLines()
        {
            while (true)
            {
                try
                {
                    TheGreatDivider.MaxIntDividedBy(Console.ReadLine());
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Caught:" + ex.Message);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Enter A Number");
                }
            }
        }
    }

    static class TheGreatDivider
    {
        public static void MaxIntDividedBy(string number)
        {
            if (string.IsNullOrWhiteSpace(number))
                throw new ArgumentException("Nothing Entered", "number");
            Console.WriteLine(int.MaxValue / int.Parse(number));
        }
    }
}
