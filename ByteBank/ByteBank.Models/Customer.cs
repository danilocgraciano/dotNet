using System;

namespace ByteBank.Models
{
    public class Customer
    {
        public string Name { get; set; }
        public string Document { get; set; }

        /// <summary>
        /// Create a customer
        /// </summary>
        /// <param name="name"> Customer's name</param>
        /// <param name="document">Customer's document</param>
        /// <exception cref="ArgumentException"><paramref name="name"/> or <paramref name="document"/> are null or empty.</exception>
        public Customer(string name = "", string document = "")
        {
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Invalid param", nameof(name));

            Name = name;

            if (string.IsNullOrEmpty(document))
                throw new ArgumentException("Invalid param", nameof(document));

            Document = document;
        }
    }
}
