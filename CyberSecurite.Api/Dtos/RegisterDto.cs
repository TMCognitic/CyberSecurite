namespace CyberSecurite.Api.Dtos
{
    public class RegisterDto(string nom, string prenom, string email, string password)
    {
        public string Nom { get; } = nom;
        public string Prenom { get; } = prenom;
        public string Email { get; } = email;
        public string Password { get; } = password;
    }
}
