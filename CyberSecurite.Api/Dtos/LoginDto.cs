namespace CyberSecurite.Api.Dtos
{
    public class LoginDto(string email, string password)
    {
        public string Email { get; } = email;
        public string Password { get; } = password;
    }
}
