using System;
using System.IO;
namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Youe List, press ctrl-c to quit:");
            var reader = new ListReader();
            var fileWriter = new FileWriter();

            reader.ListUpdated += (listItem) => Console.WriteLine(listItem);
            reader.ListUpdated +=  fileWriter.WriteToFile;

            reader.ReadList();
        }
    }

    public class FileWriter
    {
        public string fileName = DateTime.Now.ToFileTime().ToString();
        public void WriteToFile(string line) => File.AppendAllText(fileName, line + Environment.NewLine);
    }

    public class ListReader{
        public delegate void NewListItem(string listItem);
        public event NewListItem ListUpdated;
        public void ReadList(){
            while(true){
                var listItem = Console.ReadLine();
                if (ListUpdated != null)
                    ListUpdated.Invoke(listItem);
            }
        }
    }
}
