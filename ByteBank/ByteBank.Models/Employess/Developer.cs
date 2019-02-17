namespace ByteBank.Models.Employees
{
    public class Developer : Employee
    {
        public Developer(string document) : base(document, 3000)
        {
        }

        protected internal override double GetBonus()
        {
            return Salary * 0.1;
        }

        public override void IncreasySalary()
        {
            Salary *= 0.1;
        }
    }
}
