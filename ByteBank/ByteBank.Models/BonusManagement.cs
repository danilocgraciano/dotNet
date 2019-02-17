using ByteBank.Models.Employees;

namespace ByteBank.Models
{
    public class BonusManagement
    {
        private double TotalBonus;

        public void Register(Employee employee)
        {

            TotalBonus += employee.GetBonus();
        }

        public double GetTotalBouns()
        {
            return TotalBonus;
        }
    }
}
