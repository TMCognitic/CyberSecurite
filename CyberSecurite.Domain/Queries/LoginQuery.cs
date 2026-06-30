using Cqs.Queries;
using CyberSecurite.Domain.Entities;
using Patterns.Results;
using System.Data.Common;

namespace CyberSecurite.Domain.Queries
{
    public sealed class LoginQuery(string email, string passwd) : IQueryDefinition<Utilisateur>
    {
        public string Email { get; } = email;
        public string Passwd { get; } = passwd;
    }

    public sealed class LoginQueryHandler(DbConnection dbConnection) : IQueryHandler<LoginQuery, Utilisateur>
    {
        private readonly DbConnection _dbConnection = dbConnection;

        public Result<Utilisateur> Execute(LoginQuery query)
        {
            try
            {
                _dbConnection.Open();
                using DbCommand dbCommand = _dbConnection.CreateCommand();
                dbCommand.CommandText = $"SELECT Id, Nom, Prenom, Email, IsAdmin FROM Utilisateur WHERE Email = N'{query.Email}' AND Passwd = HASHBYTES('SHA2_512', N'{query.Passwd}');";
                using DbDataReader dataReader = dbCommand.ExecuteReader();

                if (!dataReader.Read())
                    return Error.Create("User not found!!");

                Utilisateur utilisateur = new Utilisateur((long)dataReader["Id"], (string)dataReader["Nom"], (string)dataReader["Prenom"], (string)dataReader["Email"], (bool)dataReader["IsAdmin"]);
                return (Result<Utilisateur>)utilisateur;
            }
            catch (Exception ex)
            {
                return ex;
            }
        }
    }
}
