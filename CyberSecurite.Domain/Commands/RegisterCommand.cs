using Cqs.Commands;
using Patterns.Results;
using System.Data.Common;

namespace CyberSecurite.Domain.Commands
{
    public sealed class RegisterCommand(string nom, string prenom, string email, string password) : ICommandDefinition
    {
        public string Nom { get; } = nom;
        public string Prenom { get; } = prenom;
        public string Email { get; } = email;
        public string Password { get; } = password;
    }

    public sealed class RegisterCommandHandler(DbConnection connection) : ICommandHandler<RegisterCommand>
    {
        private readonly DbConnection _connection = connection;
        
        public Result Execute(RegisterCommand command)
        {
            try
            {
                _connection.Open();

                using DbCommand dbCommand = _connection.CreateCommand();
                dbCommand.CommandText = $"INSERT INTO Utilisateur (Nom, Prenom, Email, Passwd) VALUES (N'{command.Nom}', N'{command.Prenom}', N'{command.Email}', HASHBYTES('SHA2_512', N'{command.Password}'))";
                dbCommand.ExecuteNonQuery();
                return Result.Success();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
