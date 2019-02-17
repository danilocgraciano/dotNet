namespace ByteBank.Models.Employees
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
