using System;
using System.Collections.Generic;

namespace Command
{

    class Program
    {
        public static int x = 0;
        public static int y = 0;
        static void Main(string[] args)
        {
            var commandList = new List<ICommand>();
            Console.WriteLine("Use Arrows to add direction commands, and enter to run the command list");

            while(true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                    commandList.Add(new UpCommand());
                else if (key == ConsoleKey.DownArrow)
                    commandList.Add(new DownCommand());
                else if (key == ConsoleKey.LeftArrow)
                    commandList.Add(new LeftCommand());
                else if (key == ConsoleKey.RightArrow)
                    commandList.Add(new RightCommand());
                else if (key == ConsoleKey.Enter)
                    {
                        Console.WriteLine();
                        commandList.ForEach(c => c.Invoke());
                        Console.WriteLine($": {x}, {y}");
                        commandList.Clear();
                    }
                
            }
        
        }
    }

    interface ICommand
    {
        void Invoke();
    }

    class UpCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Up ");
            Program.y++;
        }
    }
    class DownCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Down ");
            Program.y--;
        }
    }
    class LeftCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Left ");
            Program.x--;
        }
    }
    class RightCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Right ");
            Program.x++;
        }
    }
}
