namespace ByteBank.Models
{
    public class CommercialPartner : IAuthenticable
    {
        public string Password { get; set; }

        public bool Autenticate(string password)
        {
            return Password == password;
        }
    }
}
