using System;
using System.IO;
using System.Threading.Tasks;

namespace Proxy
{
    class Program
    {
        static void Main(string[] args)
        {            
            Parallel.For(0,10, i => OneFileAtATimeProxy.AppendAllText("A.txt", i+", "));
        }
    }

    static class OneFileAtATimeProxy
    {
        static readonly object FileInUse = new object();

        public static void AppendAllText(string filename, string text)
        {
            lock(FileInUse)
            { 
                File.AppendAllText(filename, text);                
            }
            
        } 
    }
   
}
