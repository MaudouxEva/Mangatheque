using System.Data.Common;
using Mangatheque.DAL.Entities;
using Mangatheque.DAL.Interfaces;
using Mangatheque.DAL.Tools;

namespace Mangatheque.DAL.Repositories;

public class VendeurRepository : IVendeurRepository 
{
    private readonly DbConnection _connection;
   
    public VendeurRepository(DbConnection dbConnection)
    {
        _connection = dbConnection;
    }
    
    public static Vendeur Mapper(DbDataReader reader)
    {
        return new Vendeur
        {
            VendeurId = (int)reader["VendeurId"],
            Nom = (string)reader["Nom"],
            Prenom = (string)reader["Prenom"],
            Email = (string)reader["Email"],
            Password = (string)reader["Password"],
        };
    }
    
    public IEnumerable<Vendeur> GetAllVendeurs()
    {
        using (DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Vendeur";
            _connection.Open();
            using (DbDataReader reader = command.ExecuteReader())
            {
                while (reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
        }
    }

    public Vendeur GetVendeurById(int id)
    {
        using (DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Vendeur WHERE VendeurId = @id";
            command.AddParamWithValue("id", id);
            _connection.Open();
            using (DbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    return Mapper(reader);
                }
                return null;
            }
        }
    }

    public Vendeur CreateVendeur(Vendeur vendeur)
    {
        using (DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO Vendeur (Nom, Prenom, Email, Password) VALUES (@nom, @prenom, @email, @password)";
            command.AddParamWithValue("nom", vendeur.Nom);
            command.AddParamWithValue("prenom", vendeur.Prenom);
            command.AddParamWithValue("email", vendeur.Email);
            command.AddParamWithValue("password", vendeur.Password);
            _connection.Open();
            using (DbDataReader reader = command.ExecuteReader()) {

                if (reader.Read())
                {
                    return Mapper(reader);
                }
                throw new Exception("Un problème est survenu lors de l'ajout de l'utilisateur");
            }   
            _connection.Close();
        }
    }
}