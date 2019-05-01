using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBank.Agency
{
    class Program
    {
        static void Main(string[] args)
        {
            readFile();
            Console.ReadLine();
            
        }

        static void readFile() {

            var file = "../../contas.txt";

            using (var stream = new FileStream(file, FileMode.Open)) {
                var buffer = new byte[1024];

                while (stream.Read(buffer, 0, 1024) != 0)
                {
                    var encoding = Encoding.UTF8;
                    Console.Write(encoding.GetString(buffer));
                }
            }

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
