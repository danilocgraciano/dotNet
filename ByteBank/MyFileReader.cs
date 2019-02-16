using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class MyFileReader : IDisposable
    {
        public string File { get; }

        public MyFileReader(string file)
        {
            File = file;
            Console.WriteLine("Opening file...");
        }

        public string ReadNextLine()
        {
            Console.WriteLine("Reading line...");
            return "Next Line";
        }

        public void Dispose()
        {
            Console.WriteLine("Closing line.");
        }
    }
}
