using ByteBank.Models.Exceptions;
using System;

namespace ByteBank.Models
{
    /// <summary>
    /// Represents a Bank Account from ByteBank
    /// </summary>
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

        /// <summary>
        /// Create an instance from <see cref="Account"/>.
        /// </summary>
        /// <param name="agency">Define a value for <paramref name="agency"/>, must be greather than zero.</param>
        /// <param name="number">Define a value for <paramref name="number"/>, must be greather than zero.</param>
        /// <exception cref="ArgumentException"><paramref name="agency"/> or <paramref name="number"/> are equals or smaller than zero.</exception>
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
        /// <summary>
        /// Cash out a value from an account.
        /// </summary>
        /// <param name="value">The value to be cashed out, must be greather than zero.</param>
        /// <exception cref="ArgumentException"> <paramref name="value"/> is smaller than zero.</exception>
        /// <exception cref="InsufficientFundsException"><paramref name="value"/> is bigger than <see cref="Balance"/>.</exception>
        public void CashOut(double value)
        {
            if (value < 0)
                throw new ArgumentException("The value must be greather than zero.");

            if (value > Balance)
            {
                QtyCashOperationsNotAllowed++;
                throw new InsufficientFundsException("The value is bigger than balance.", value);
            }

            Balance -= value;

        }

        public void Deposit(params double[] values)
        {

            foreach (double value in values)
            {
                if (value < 0)
                    throw new ArgumentException($"The value must be greather than zero: {value}.");

                Balance += value;
            }
            
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

        public override bool Equals(object obj)
        {
            Account a = obj as Account;
            return a != null && a.Number == Number && a.Agency == Agency;
        }

        public override int GetHashCode()
        {
            var hashCode = -49849310;
            hashCode = hashCode * -1521134295 + Number.GetHashCode();
            hashCode = hashCode * -1521134295 + Agency.GetHashCode();
            return hashCode;
        }
    }
}
