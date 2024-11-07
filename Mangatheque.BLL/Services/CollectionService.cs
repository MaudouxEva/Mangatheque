using Mangatheque.BLL.CustomExceptions;
using Mangatheque.BLL.Interfaces;
using Mangatheque.BLL.Mappers;
using Mangatheque.BLL.Models;
using Mangatheque.DAL.Interfaces;

namespace Mangatheque.BLL.Services
{
    

    public class CollectionService : ICollectionService
    {
        //initialisation du service avec une instance de ICollectionRepo permettant d'accéder aux méthodes de gestion des collections
        // readonly car assigné qu'une seule fois : dans le constructeur
        private readonly ICollectionRepository _collectionRepository;

        // Injection de dépendance (permet de fournir les dépendances d'une classe depuis l'extérieur plutôt que de les créer dans la classe).
        // ICollectionRepo est injecté dans le service Collection via le constructeur => le service peut utiliser les méthodes de ICollectionRepo  
        public CollectionService(ICollectionRepository collectionRepository)
        {
            _collectionRepository = collectionRepository;
        }


        // Récupère toutes les collections de la DB via la méthode getAllCollections de ICollectionRepo (DAL). Ensuite, elles seront converties pour être utilisées pas la couche BLL.
        public IEnumerable<Collection> GetAllCollections()
        {
            // Récupère les entités Collection de la DB via le repo, puis Select pour projeter chaque entité en modèle Collection en appelant la méthode d'extension MapToModel
            return _collectionRepository.GetAllCollections().Select(collectionEntity => collectionEntity.MapToModel());
        }

        // Récupérer une collection via son ID
        Collection ICollectionService.GetCollectionById(int id)
        {
            return _collectionRepository.GetCollectionById(id).MapToModel();
        }

        // Créer une nouvelle collection
        // Implémente la méthode de création de l'itnerface de la BLL
        Collection ICollectionService.CreateCollection(Collection collection)
        {
            // Appelle la méthode CollectionAlreadyExists du repo (DAL), injecté dans notre constructeur du service ici, pour vérifier si une collection avec le même nom existe déjà
            if(_collectionRepository.CollectionAlreadyExists(collection.Nom))
            {
                throw new AlreadyExistsException("Une collection avec ce nom existe déjà dans la base de données");
            }
            // Crée une nouvelle collection en DB via la méthode de création du repo (DAL)
            // MapToEntity est appelée sur l'objet collection pour le convertir en une entité DAL
            // puis la méthode MapToModel est appelée sur l'entité créée pour la convertir en modèle BLL, ensuite retourné
            return _collectionRepository.CreateCollection(collection.MapToEntity()).MapToModel();
        }
    }
}
