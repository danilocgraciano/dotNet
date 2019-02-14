using ByteBank.Employees;
using ByteBank.Systems;

namespace ByteBank.employees
{
    public class AccountManager : AuthenticableEmployee
    {
        public AccountManager(string document) : base(document, 4000)
        {
        }

        public override double GetBonus()
        {
            return Salary * 0.25;
        }

        public override void IncreasySalary()
        {
            Salary *= 1.05;
        }
    }
}
