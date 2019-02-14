using ByteBank.employees;
using ByteBank.Systems;
using System;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();

            program.CalculateBonification();

            program.Authenticate();

            Console.ReadLine();
        }

        public void Authenticate()
        {
            Director director = new Director("000.000.000-00");
            director.Name = "Director";
            director.Password = "123";

            AccountManager accountManager = new AccountManager("111.111.111-11");
            accountManager.Name = "Account Manager";
            accountManager.Password = "321";

            CommercialPartner commercialPartner = new CommercialPartner();
            commercialPartner.Password = "abc";

            InternalSystem system = new InternalSystem();
            system.Login(director, "123");
            system.Login(accountManager, "321");
            system.Login(commercialPartner, "abc");
        }

        public void CalculateBonification()
        {
            Director director = new Director("000.000.000-00");
            director.Name = "Director";

            AccountManager accountManager = new AccountManager("111.111.111-11");
            accountManager.Name = "Account Manager";

            Auxiliary auxiliary = new Auxiliary("222.222.222-22");
            auxiliary.Name = "Auxiliary";

            Designer designer = new Designer("333.333.333-33");
            designer.Name = "Designer";

            Developer developer = new Developer("444.444.444-44");
            developer.Name = "Developer";

            BonusManagement bonusManagement = new BonusManagement();
            bonusManagement.Register(director);
            bonusManagement.Register(accountManager);
            bonusManagement.Register(auxiliary);
            bonusManagement.Register(designer);
            bonusManagement.Register(developer);

            Console.WriteLine("Monthly bonification is " + bonusManagement.GetTotalBouns());
        }
    }
}
