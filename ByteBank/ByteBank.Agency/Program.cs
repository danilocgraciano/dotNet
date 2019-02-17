using ByteBank.Models;
using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Agency
{
    class Program
    {
        static void Main(string[] args)
        {

            DateTime dueDate = new DateTime(2018, 8, 17);
            DateTime today = DateTime.Now;

            TimeSpan diff = dueDate - today;

            Console.WriteLine("Time until due date :" + TimeSpanHumanizeExtensions.Humanize(diff));
            Console.ReadLine();
        }
    }
}
