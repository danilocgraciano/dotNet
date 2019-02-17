namespace ByteBank.Models.Employees
{
    public class Auxiliary : Employee
    {
        public Auxiliary(string document): base(document, 2000)
        {
        }

        public override double GetBonus()
        {
            return Salary * 0.2;
        }

        public override void IncreasySalary()
        {
            Salary *= 1.1;
        }
    }
}
