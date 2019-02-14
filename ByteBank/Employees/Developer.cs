namespace ByteBank.employees
{
    public class Developer : Employee
    {
        public Developer(string document) : base(document, 3000)
        {
        }

        public override double GetBonus()
        {
            return Salary * 0.1;
        }

        public override void IncreasySalary()
        {
            Salary *= 0.1;
        }
    }
}
