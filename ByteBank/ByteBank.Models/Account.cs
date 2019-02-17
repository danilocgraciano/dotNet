using ByteBank.Models.Exceptions;
using System;

namespace ByteBank.Models
{
    public class Account
    {
        public static double OperationTax { get; set; }

        public static int TotalAccountsCreated { get; set; }

        public static int QtyCashOperationsNotAllowed { get; private set; }
        public static int QtyTransferOperationsNotAllowed { get; private set; }

        public Customer Customer { get; set; }

        public int Number { get; } //readonly

        public int Agency { get; } //readonly

        public double Balance { get; private set;  }

        public Account(int agency, int number)
        {

            if (agency <= 0)
                throw new ArgumentException("The value of the param must be bigger than zero.", nameof(agency));


            if (number <= 0)
                throw new ArgumentException("The value of the param must be bigger than zero.", nameof(number));

            Number = number;

            Agency = agency;

            TotalAccountsCreated++;

            OperationTax = 30 / TotalAccountsCreated;

            
        }

        public void CashOut(double value)
        {
            if (value < 0)
                throw new ArgumentException("The value must be greather than zero.");

            if (value < Balance)
            {
                QtyCashOperationsNotAllowed++;
                throw new InsufficientFundsException("The value is smaller than balance.", value);
            }

            Balance -= value;

        }

        public void Deposit(double value)
        {
            if (value < 0)
                throw new ArgumentException("The value must be greather than zero.");

            Balance += value;
        }

        public void TransferTo(Account account, double value)
        {
            try
            {
                CashOut(value);
            }
            catch (InsufficientFundsException ex)
            {
                QtyTransferOperationsNotAllowed++;
                throw new FinancialOperationException("Operation not allowed", ex);
            }
            account.Deposit(value);
        }
    }
}
