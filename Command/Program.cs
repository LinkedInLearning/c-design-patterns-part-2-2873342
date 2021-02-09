using System;
using System.Collections.Generic;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var commandList = new List<ICommand>();
            Console.WriteLine("Use arrows add direction commands, and enter to run the command list - ctrl-c to quit");
            while (true)
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
                    Console.WriteLine();
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
        }
    }
    class DownCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Down ");
        }
    }
    class LeftCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Left ");
        }
    }
    class RightCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Right ");
        }
    }
}
