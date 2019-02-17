namespace ByteBank.Models.Employees
{
    public abstract class Employee
    {
        public static int QTDE_EMPLOYEES { get; private set; }

        public string Name { get; set; }
        public string Document { get; private set; }
        public double Salary { get; protected set; }

        public Employee(string document, double salary)
        {
            QTDE_EMPLOYEES++;
            Document = document;
            Salary = salary;
        }

        public abstract double GetBonus();

        public abstract void IncreasySalary();
    }
}
