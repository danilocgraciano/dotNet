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
            testExtensionList();
            Console.ReadLine();
            
        }

        static void testExtensionList()
        {
            var myList = new List<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.AddAll(1,2,3);

            foreach (int value in myList)
                Console.WriteLine(value);
        }

        static void testDates()
        {
            var dueDate = new DateTime(2018, 8, 17);
            var today = DateTime.Now;

            TimeSpan diff = dueDate - today;

            Console.WriteLine("Time until due date :" + TimeSpanHumanizeExtensions.Humanize(diff));
            Console.ReadLine();
        }
    }
}
