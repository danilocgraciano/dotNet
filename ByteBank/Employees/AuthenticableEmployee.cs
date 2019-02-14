using ByteBank.employees;
using ByteBank.Systems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employees
{
    public abstract class AuthenticableEmployee : Employee, IAuthenticable
    {
        public string Password { get; set; }

        public AuthenticableEmployee(string document, double salary) : base(document, salary)
        {
        }

        bool IAuthenticable.Autenticate(string password)
        {
            return Password == password;
        }
    }
}
