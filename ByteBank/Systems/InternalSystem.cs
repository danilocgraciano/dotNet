using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Systems
{
    public class InternalSystem
    {
        public bool Login(IAuthenticable employee, string password)
        {
            if (employee.Autenticate(password))
            {
                Console.WriteLine("Sucessfully login...");
                return true;
            }
            Console.WriteLine("Invalid login...");
            return false;
        }
    }
}
