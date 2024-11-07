using System.Data.Common;
using Mangatheque.DAL.Entities;
using Mangatheque.DAL.Interfaces;
using Mangatheque.DAL.Tools;
namespace Mangatheque.DAL.Repositories;

public class CollectionRepository : ICollectionRepository
{
    // initialisation d'une connexion à une DB via une instance de DbConnection
    // Permet à la classe CollectionRepository de recevoir une connexion à une DB lors de son isntanciation et de l'utiliser pour faire des opérations de DB
    private readonly DbConnection _connection;
    
    public CollectionRepository(DbConnection dbConnection) 
    { 
        _connection = dbConnection;
    }
    
    // Mapper => Pour convertir les données brutes de la DB en objets de domaine utilisables dans l'app
    public static Collection Mapper(DbDataReader reader)
    {
        return new Collection
        {
            // initialisation des propriété de l'objet Collection avec les valeurs lues de la DB
            CollectionId = (int)reader["CollectionId"],
            Nom = (string)reader["Nom"],
            Description = (string)reader["Description"],
            Auteur = (string)reader["Auteur"],
            Illustration = reader["Illustration"] is DBNull ? null : (string)reader["Illustration"],
            DateSortie = (DateTime)reader["DateSortie"],
            Prix = (decimal)reader["Prix"]
        };
    }
    
    // Récupérer toutes les collections
    public IEnumerable<Collection> GetAllCollections()
    {
        // Commande utilisée pour exécuter une requête SQL sur la DB (récupère la connextion à la DB initialisée dans le constructeur de la classe CollectionRepository)
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Collection];";
            _connection.Open();
            // Initialise un objet DbDataReader pour parcourir les résultats de la requête
            // rappel : using garantit que l'objet DbDataReader sera disposé(libéré) une fois le bloc de code exécuté
            using(DbDataReader reader = command.ExecuteReader())
            {
                // Lit chaque enregistrement de la DB, le convertir en un objet Collection et le retourne à l'appelant
                // yield renvoie cet objet Collection à l'appelant de la méthode sans terminer l'exécution de la méthode => permet de retourner les objets Collection un par un, en lazy, au fur et à mesure qu'ils sont lus et mappés
                while(reader.Read())
                {
                    yield return Mapper(reader);
                }
            }
            _connection.Close();
        }
    }
    
    // Récupérer une collection via son ID
    public Collection GetCollectionById(int idCollection)
    {
        Collection collection;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT * FROM [dbo].[Collection] WHERE [CollectionId] = @CollectionId";
            // addParamWithValue => méthode d'extension créée pour DbCommand qui permet d'ajouter un paramètre à la commande SQL
            command.AddParamWithValue("CollectionId", idCollection);
            _connection.Open();
            using(DbDataReader reader = command.ExecuteReader())
            {
                // Permet de mapper les résultats de la requête en un objet Collection ou de retourner null si pas de résultat trouvé
                if (reader.Read())
                {
                    // Si une ligne a été lue, mapping sur les données de la ligne en un objet Collection
                    collection = Mapper(reader);
                }
                else
                {
                    collection = null;
                }
            }
            _connection.Close();
        }
        return collection;
    }
    
    // Créer une nouvelle collection
    public Collection CreateCollection(Collection collectionToInsert)
    {
        Collection collectionCreated;
        using(DbCommand command = _connection.CreateCommand())
        {
            // Préparation et exécution d'une commande SQL pour insérer une nouvelle collection.
            // OUTPUT [inserted].* permet de récupérer les données de la collection insérée
            command.CommandText = "INSERT INTO [dbo].[Collection] ([Nom], [Description], [Auteur], [Illustration], [DateSortie], [Prix]) " +
                                  "OUTPUT [inserted].* " +
                                  "VALUES (@Nom, @Description, @Auteur, @Illustration, @DateSortie, @Prix)";
            command.AddParamWithValue("Nom", collectionToInsert.Nom);
            command.AddParamWithValue("Description", collectionToInsert.Description);
            command.AddParamWithValue("Auteur", collectionToInsert.Auteur);
            command.AddParamWithValue("Illustration", collectionToInsert.Illustration);
            command.AddParamWithValue("DateSortie", collectionToInsert.DateSortie);
            command.AddParamWithValue("Prix", collectionToInsert.Prix);
            _connection.Open();
            // ExecuteScalar exécute la commande et retourne la première colonne de la première ligne du résultat de la requête
            using(DbDataReader reader = command.ExecuteReader())
            {
                // Tente de lire les résultats de l'insertion d'une nouvelle colletcion en DB, et de mapper ces résultats en un objet Collection
                if (reader.Read())
                {
                    collectionCreated = Mapper(reader);
                }
                else
                {
                    throw new Exception("Un problème est survenu lors de la création d'une nouvelle collection");
                }
            }
            _connection.Close();
        }
        return collectionCreated;
    }
    
    // Vérifier si une collection existe déjà
    public bool CollectionAlreadyExists(string nom)
    {
        bool exists = false;
        using(DbCommand command = _connection.CreateCommand())
        {
            command.CommandText = "SELECT COUNT(*) FROM [dbo].[Collection] WHERE [Nom] = @Nom ;";
            command.AddParamWithValue("Nom", nom);
            _connection.Open();
            // vérifie si le nombre de collections avec le nom spécifié est > à 0
            // convertit le résultat en un entier nullable car ExecuteScalar peut retourner null si aucune ligne n'est trouvée
            // exists = true si une/plusieurs collections avec le même nom existent. SInon, exists = false
            exists = (int?)command.ExecuteScalar() > 0;
            _connection.Close();
        }
        return exists;
    }
}