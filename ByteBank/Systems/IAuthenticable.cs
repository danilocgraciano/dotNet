using ByteBank.employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Systems
{
    public interface IAuthenticable
    {
        bool Autenticate(string password);
    }
}
