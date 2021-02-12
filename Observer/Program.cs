using System;
using System.IO;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Your List, press ctrl-c to quit:");
            var reader = new ListReader();
            var writer = new FileWriter();
            reader.ListUpdated += (listItem) => Console.WriteLine(listItem);
            reader.ListUpdated += writer.WriteToFile;
            reader.ReadList();
        }
    }

    public class FileWriter
    {
        public string filename = DateTime.Now.ToFileTime().ToString();
        public void WriteToFile(string line) => 
            File.AppendAllText(filename, line + Environment.NewLine);
    }
    public class ListReader
    {
        public delegate void NewListItem(string listItem);

        public event NewListItem ListUpdated;

        public void ReadList()
        {
            while (true)
            {
                var listItem = Console.ReadLine();
                ListUpdated?.Invoke(listItem);
            }
        }
    }
}
