using System;

namespace ByteBank.Exceptions
{
    public class InsufficientFundsException : FinancialOperationException
    {
        public double Value { get; }

        public InsufficientFundsException()
        {

        }

        public InsufficientFundsException(string message) : base(message)
        {

        }

        public InsufficientFundsException(string message, double value) : this(message)
        {
            Value = value;
        }
    }
}
