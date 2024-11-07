using System.Data.Common;
using Mangatheque.DAL.Entities;
using Mangatheque.DAL.Interfaces;
using Mangatheque.DAL.Tools;

namespace Mangatheque.DAL.Repositories;

public class ClientRepository : IClientRepository
{
   
   private readonly DbConnection _connection;
   
   public ClientRepository(DbConnection dbConnection)
   {
       _connection = dbConnection;
   }
   
   
    public static Client Mapper(DbDataReader reader)
    {
         return new Client
         {
              ClientId = (int)reader["ClientId"],
              NumClient = (int)reader["NumClient"],
              Nom = (string)reader["Nom"],
              Prenom = (string)reader["Prenom"],
              Tel = (int)reader["Tel"],
              Email = (string)reader["Email"],
              Password = (string)reader["Password"],
              ACarteFidelite = (bool)reader["ACarteFidelite"],
              Active = (bool)reader["Active"]
         };
    }

    public IEnumerable<Client> GetAllClients()
    {
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Client";
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
            _connection.Close();
        }
    }

    public IEnumerable<Client> GetAllActiveClients()
    {
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Client WHERE Active = 1";
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                while(reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
            _connection.Close();
        }
    }

    public Client GetByIdClient(int id)
    {
        Client client;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Client WHERE ClientId = @id";
            command.AddParamWithValue("id", id);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    client = Mapper(reader);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            _connection.Close();
            return client;
        }
    }

    public Client GetByNumClient(int numClient)
    {
        Client client;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Client WHERE NumClient = @numClient";
            command.AddParamWithValue("numClient", numClient);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    client = Mapper(reader);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            _connection.Close();
            return client;
        }
    }

    public Client GetByMailClient(string email)
    {
        Client client;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM Client WHERE Email LIKE @email";
            command.AddParamWithValue("email", email);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    client = Mapper(reader);
                }
                else
                {
                    throw new ArgumentOutOfRangeException();
                }
            }
            _connection.Close();
            return client;
        }
    }

    public Client CreateClient(Client client)
    {
        Client clientCreated;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "INSERT INTO Client (NumClient, Nom, Prenom, Tel, Email, Password, ACarteFidelite, Active) " +
                                  "OUTPUT [inserted].* " +
                                  "VALUES (@NumClient, @Nom, @Prenom, @Tel, @Email, @Password, @ACarteFidelite, @Active)";
            command.AddParamWithValue("NumClient", client.NumClient);
            command.AddParamWithValue("Nom", client.Nom);
            command.AddParamWithValue("Prenom", client.Prenom);
            command.AddParamWithValue("Tel", client.Tel);
            command.AddParamWithValue("Email", client.Email);
            command.AddParamWithValue("Password", client.Password);
            command.AddParamWithValue("ACarteFidelite", client.ACarteFidelite);
            command.AddParamWithValue("Active", client.Active);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if(reader.Read())
                {
                    clientCreated = Mapper(reader);
                }
                else
                {
                    throw new Exception("Un problème est survenu lors de la création d'un nouveau client");
                }
            }
            _connection.Close();
        }
        return clientCreated;
    }

        public bool ClientAlreadyExists(int numClient)
    {
        bool exists = false;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT COUNT(*) FROM Client WHERE NumClient = @numClient ;";
            command.AddParamWithValue("numClient", numClient);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                exists = (int?)command.ExecuteScalar() > 0;
            }
            _connection.Close();
        }
        return exists;
    }
}