using System;

namespace ByteBank.Models.Exceptions
{
    public class FinancialOperationException : Exception
    {

        public FinancialOperationException()
        {
        }

        public FinancialOperationException(string message) : base(message)
        {
        }

        public FinancialOperationException(string message, Exception innerException)
        { }
    }
}
