using System.Data.Common;
using Mangatheque.DAL.Entities;
using Mangatheque.DAL.Interfaces;
using Mangatheque.DAL.Tools;

namespace Mangatheque.DAL.Repositories;

public class VolumeRepository : IVolumeRepository
{
    private readonly DbConnection _connection;
    
    public VolumeRepository(DbConnection dbConnection) 
    { 
        _connection = dbConnection;
    }
    
    public static Volume Mapper(DbDataReader reader)
    {
        return new Volume
        {
            VolumeId = (int)reader["VolumeId"],
            Nom = (string)reader["Nom"],
            Isbn = (string)reader["Isbn"],
            CollectionId = (int)reader["CollectionId"],
            NumTome = (int)reader["NumTome"],
            Resume = (string)reader["Resume"],
            Edition = (string)reader["Edition"],
            ImageCouverture = reader["ImageCouverture"] is DBNull ? null : (string)reader["ImageCouverture"],
            DateSortie = (DateTime)reader["DateSortie"],
            StockQuantite = (int)reader["StockQuantite"],
            
        };
    }
    
    public IEnumerable<Volume> GetAllVolumes()
    {
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Volume];";
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

    public Volume GetVolumeById(int id)
    {
        Volume volume;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Volume] WHERE VolumeId = @VolumeId;";
            command.AddParamWithValue("VolumeId", id);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    volume = Mapper(reader);
                }
                else
                {
                    volume = null;
                }
            }
            _connection.Close();
        }

        return volume;
    }

    public Volume GetVolumeByIsbn(string Isbn)
    {
        Volume volume;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Volume] WHERE Isbn = @Isbn;";
            command.AddParamWithValue("Isbn", Isbn);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    volume = Mapper(reader);
                }
                else
                {
                    volume = null;
                }
            }
            _connection.Close();
        }

        return volume;
    }

    public Volume GetVolumeByCollectionId(int collectionId)
    {
        Volume volume;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Volume] WHERE CollectionId = @CollectionId;";
            command.AddParamWithValue("CollectionId", collectionId);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    volume = Mapper(reader);
                }
                else
                {
                    volume = null;
                }
            }
            _connection.Close();
        }

        return volume;
    }


    public Volume CreateVolume(Volume volumeToInsert)
    {
        Volume volumeCreated;
        using (DbCommand command = _connection.CreateCommand())
        {
            command.CommandText= "INSERT INTO [dbo].[Volume] ([Nom], [Isbn], [CollectionId], [NumTome], [Resume], [Edition], [ImageCouverture], [DateSortie], [StockQuantite]) " +
                                "OUTPUT [inserted].* " +
                                "VALUES (@Nom, @Isbn, @CollectionId, @NumTome, @Resume, @Edition, @ImageCouverture, @DateSortie, @StockQuantite);";
            command.AddParamWithValue("Nom", volumeToInsert.Nom);
            command.AddParamWithValue("Isbn", volumeToInsert.Isbn);
            command.AddParamWithValue("CollectionId", volumeToInsert.CollectionId);
            command.AddParamWithValue("NumTome", volumeToInsert.NumTome);
            command.AddParamWithValue("Resume", volumeToInsert.Resume);
            command.AddParamWithValue("Edition", volumeToInsert.Edition);
            command.AddParamWithValue("ImageCouverture", volumeToInsert.ImageCouverture);
            command.AddParamWithValue("DateSortie", volumeToInsert.DateSortie);
            command.AddParamWithValue("StockQuantite", volumeToInsert.StockQuantite);
        
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                if (reader.Read())
                {
                    volumeCreated = Mapper(reader);
                }
                else
                {
                    throw new Exception("Un problème est survenu lors de la création d'un nouveau volume");
                }
            }
            _connection.Close();
        }
        return volumeCreated;
    }

    public bool VolumeAlreadyExists(string nom)
    {
        bool exists = false;
        using (DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT COUNT(*) FROM [dbo].[Volume] WHERE [Nom] = @Nom ;";
            command.AddParamWithValue("Nom", nom);
            _connection.Open();
            exists = (int?)command.ExecuteScalar() > 0;
            _connection.Close();
        }

        return exists;
    }
}