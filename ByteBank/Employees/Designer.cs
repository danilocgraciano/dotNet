﻿namespace ByteBank.employees
{
    public class Designer : Employee
    {
        public Designer(string document) : base(document, 3000)
        {
        }

        public override double GetBonus()
        {
            return Salary * 0.17;
        }

        public override void IncreasySalary()
        {
            Salary *= 1.11;
        }
    }
}
