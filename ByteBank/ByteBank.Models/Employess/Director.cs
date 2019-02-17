namespace ByteBank.Models.Employees
{
    public class Director : AuthenticableEmployee
    {
        public Director(string document) : base(document, 5000)
        {

        }

        protected internal override double GetBonus()
        {
            return Salary * 0.5;
        }

        public override void IncreasySalary()
        {
            Salary *= 1.15;
        }
    }
}
