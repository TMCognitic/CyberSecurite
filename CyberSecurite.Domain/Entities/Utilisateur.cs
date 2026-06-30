namespace CyberSecurite.Domain.Entities
{
    public record Utilisateur(long Id, string Nom, string Prenom, string Email, bool isAdmin);
}