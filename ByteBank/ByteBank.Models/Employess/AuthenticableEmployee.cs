namespace ByteBank.Models.Employees
{
    public abstract class AuthenticableEmployee : Employee, IAuthenticable
    {
        private AuthenticationHelper _helper = new AuthenticationHelper();

        public string Password { get; set; }

        public AuthenticableEmployee(string document, double salary) : base(document, salary)
        {
        }

        bool IAuthenticable.Autenticate(string password)
        {
            return _helper.ComparePassword(Password, password);
        }
    }
}
