using ByteBank.employees;

namespace ByteBank
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
