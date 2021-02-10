using System;
using System.IO;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {            
            Parallel.For(0,10, i => OneFileAtATimeProxy.AppendAllTextAsync("A.txt", i+", "));
        }
    }

    static class OneFileAtATimeProxy
    {
        static readonly object FileInUse = new object();

        public static Task AppendAllTextAsync(string filename, string text)
        {
            lock(FileInUse)
            { 
                return File.AppendAllTextAsync(filename, text);                
            }
        } 
    }
   
}
