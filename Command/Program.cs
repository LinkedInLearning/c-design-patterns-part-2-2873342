using System;
using System.Collections.Generic;
using System.Linq;

namespace Command
{
    class Program
    {
        public static int x = 0;
        public static int y = 0;
        static void Main(string[] args)
        {
             //command, and boolean is true for invoke, and false for undo
            var commandList = new List<(ICommand, bool)>();

            Console.WriteLine("Use Arrows to add direction commands, and enter to run the command list");

            while (true)
            {
                var key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.UpArrow)
                    commandList.Add((new UpCommand(), true));
                else if (key == ConsoleKey.DownArrow)
                    commandList.Add((new DownCommand(), true));
                else if (key == ConsoleKey.LeftArrow)
                    commandList.Add((new LeftCommand(), true));
                else if (key == ConsoleKey.RightArrow)
                    commandList.Add((new RightCommand(), true));
                else if (key == ConsoleKey.Backspace)
                {
                    var notUndoneCommands = commandList
                        .Where(c => c.Item2)
                        .SkipLast(commandList.Count(c => !c.Item2));

                    if (notUndoneCommands.Any())
                        commandList.Add((notUndoneCommands.Last().Item1, false));
                }
                else if (key == ConsoleKey.Enter)
                {
                    Console.WriteLine();

                    commandList.ForEach(c =>
                    {
                        if (c.Item2)
                            c.Item1.Invoke();
                        else
                            c.Item1.Undo();
                    });
                    
                    Console.WriteLine($": {x}, {y}");
                    
                    commandList.Clear();
                }

            }

        }
    }

    interface ICommand
    {
        void Invoke();
        void Undo();
    }

    class UpCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Up ");
            Program.y++;
        }
        public void Undo()
        {
            Console.Write("Down ");
            Program.y--;
        }
    }
    class DownCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Down ");
            Program.y--;
        }
        public void Undo()
        {
            Console.Write("Up ");
            Program.y++;
        }
    }
    class LeftCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Left ");
            Program.x--;
        }
        public void Undo()
        {
            Console.Write("Right ");
            Program.x++;
        }
    }
    class RightCommand : ICommand
    {
        public void Invoke()
        {
            Console.Write("Right ");
            Program.x++;
        }
        public void Undo()
        {
            Console.Write("Left ");
            Program.x--;
        }
    }
}
