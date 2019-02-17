namespace ByteBank.Models.Employees
{
    public class Designer : Employee
    {
        public Designer(string document) : base(document, 3000)
        {
        }

        protected internal override double GetBonus()
        {
            return Salary * 0.17;
        }

        public override void IncreasySalary()
        {
            Salary *= 1.11;
        }
    }
}
