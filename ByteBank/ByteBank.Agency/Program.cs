using ByteBank.Models;
using Humanizer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ByteBank.Agency
{
    //partial class Program
    class Program
    {
        static void Main(string[] args)
        {
            readFromConsole();
            Console.WriteLine("Pressione qualquer tecla para continuar . . .");
            Console.ReadLine();
            
        }

        static void readFromConsole()
        {
            var file = "../../console.txt";
            using (var stream = Console.OpenStandardInput())
            using (var writer = new FileStream(file, FileMode.Create))
            {
                var buffer = new byte[1024]; // 1 kb

                while (true)
                {
                    var bytesLidos = stream.Read(buffer, 0, 1024);

                    writer.Write(buffer, 0, bytesLidos);
                    writer.Flush();

                    Console.WriteLine($"Bytes lidos da console: {bytesLidos}");
                }
            }

        }

        static void readBinary()
        {
            var file = "../../contas.bin";

            using (var stream = new FileStream(file, FileMode.Open))
            using (var reader = new BinaryReader(stream))
            {
                var agency = reader.ReadInt32();
                var number = reader.ReadInt32();
                var balance = reader.ReadDouble();
                var customer = reader.ReadString();
                Console.WriteLine($"{agency}/{number} {customer} ${balance}");
            }
        }
        static void writeBinary()
        {
            var file = "../../contas.bin";

            using (var stream = new FileStream(file, FileMode.Create))
            using (var writer = new BinaryWriter(stream))
            {
                writer.Write(456);//agency
                writer.Write(9586950);//number
                writer.Write(4000.51);//balance
                writer.Write("Customer");
            }

        }

        static void readFileStream()
        {

            var file = "../../contas.txt";

            using (var stream = new FileStream(file, FileMode.Open))
            using (var reader = new StreamReader(stream, Encoding.UTF8))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var account = parseToAccount(line);

                    String msg = $"AG: {account.Agency} C/C: {account.Number} - {account.Customer.Name} ${account.Balance}";
                    Console.WriteLine(msg);
                }
            }
        }


        static void readFile()
        {

            var file = "../../contas.txt";

            using (var stream = new FileStream(file, FileMode.Open)) {
                var buffer = new byte[1024];

                int count;
                while ((count = stream.Read(buffer, 0, 1024)) != -1)
                {
                    var encoding = Encoding.UTF8;
                    Console.Write(encoding.GetString(buffer, 0, count));
                }

            }

        }

        static void writeFileStream()
        {
            var file = "../../contas.cvs";

            using (var stream = new FileStream(file, FileMode.Create))
            using (var writer = new StreamWriter(stream, Encoding.UTF8))
            {
                var accountAsString = "456,78945,4785.5,Gustavo Santos";
                writer.Write(accountAsString);
                writer.Flush();
            }
        }

        static void writeFile()
        {
            var file = "../../contas.cvs";

            using (var stream = new FileStream(file, FileMode.Create))
            {
                var accountAsString = "456,78945,4785.5,Gustavo Santos";
                var encoding = Encoding.UTF8;

                var bytes = encoding.GetBytes(accountAsString);
                stream.Write(bytes, 0, bytes.Length);
                stream.Flush();
            }
        }

        static Account parseToAccount(string line)
        {
            var fields = line.Split(',');//CSV - comma-separated values;

            var agency = int.Parse(fields[0]);
            var number = int.Parse(fields[1]);

            var value = double.Parse(fields[2].Replace('.', ','));

            var customer = new Customer(fields[3], "000");

            Account account = new Account(agency, number);
            account.Customer = customer;
            account.Deposit(value);

            return account;
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
