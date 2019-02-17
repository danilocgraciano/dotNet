namespace ByteBank.Models
{
    public class CommercialPartner : IAuthenticable
    {
        private AuthenticationHelper _helper = new AuthenticationHelper();

        public string Password { get; set; }

        public bool Autenticate(string password)
        {
            return _helper.ComparePassword(Password, password);
        }
    }
}
