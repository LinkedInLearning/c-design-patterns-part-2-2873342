using System;
using System.IO;
namespace ListResponsibilityChain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Youe List, press ctrl-c to quit:");

            var reader = new ListReader()
                .AddHandler(new ConsoleItemHandler())
                .AddHandler(new FileWritingItemHandler());

            reader.ReadList();
        }
    }

    public interface IItemHandler
    {
        IItemHandler Next { get; set; }
        void Handle(string items);
    }

    public class ConsoleItemHandler : IItemHandler
    {
        public IItemHandler Next { get; set; }
        public void Handle(string line)
        {
            Console.WriteLine(line);
            Next?.Handle(line);
        }
    }

    public class FileWritingItemHandler : IItemHandler
    {
        public string fileName = DateTime.Now.ToFileTime().ToString();
        public IItemHandler Next { get; set; }
        public void Handle(string line)
        {
            File.AppendAllText(fileName, line + Environment.NewLine);
            Next?.Handle(line);
        }
    }

    public class ListReader
    {
        public ListReader AddHandler(IItemHandler newHandler)
        {
            if (FirstHandler == null)
                FirstHandler = LastHandler = newHandler;
            else
                LastHandler = LastHandler.Next = newHandler;
            return this;
        }

        IItemHandler FirstHandler;
        IItemHandler LastHandler;
        public void ReadList()
        {
            while (true)
            {
                var listItem = Console.ReadLine();
                FirstHandler?.Handle(listItem);
            }
        }
    }
}
