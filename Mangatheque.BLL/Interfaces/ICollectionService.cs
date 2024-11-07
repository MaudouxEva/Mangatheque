using Mangatheque.BLL.Models;

namespace Mangatheque.BLL.Interfaces;

// Cette interface définit les méthodes que le service de collection doit implémenter pour gérer les collection au niveau logique métier.
// Pour orchestrer les opérations et appliquer règles métier avant d'appeler les méthodes du repository
public interface ICollectionService
{
    public IEnumerable<Collection> GetAllCollections();
    public Collection GetCollectionById(int id);
    public Collection CreateCollection(Collection collection);
}