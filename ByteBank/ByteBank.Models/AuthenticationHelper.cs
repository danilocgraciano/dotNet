using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Models
{
    internal class AuthenticationHelper
    {

        public bool ComparePassword(string truePassword, string password)
        {
            return truePassword == password;
        }
    }
}
