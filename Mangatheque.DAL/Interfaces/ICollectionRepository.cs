using Mangatheque.DAL.Entities;

namespace Mangatheque.DAL.Interfaces
{
    // Cette interface définit les méthodes pour accéder aux données des collections en DB. Utilisée entre autres pour le CRUD directement sur la DB
    public interface ICollectionRepository
    {
        public IEnumerable<Collection> GetAllCollections();
        public Collection GetCollectionById(int id);
        public Collection CreateCollection(Collection collection);
        public bool CollectionAlreadyExists(string nom);
    }
}