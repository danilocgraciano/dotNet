namespace ByteBank.Models
{
    public interface IAuthenticable
    {
        bool Autenticate(string password);
    }
}
