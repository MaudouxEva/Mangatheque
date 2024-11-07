using Mangatheque.DAL.Entities;

namespace Mangatheque.DAL.Interfaces
{
    public interface IClientRepository
    {
        public IEnumerable<Client> GetAllClients(); // cette méthode retourne tous les clients
        public IEnumerable<Client> GetAllActiveClients(); // cette méthode retourne tous les clients actifs
        public Client GetByIdClient(int id); // cette méthode retourne un client par son id
        public Client GetByNumClient(int numClient); // cette méthode retourne un client par son numéro de client
        public Client GetByMailClient(string email); // cette méthode retourne un client par son email
        public Client CreateClient(Client client); // cette méthode crée un client
        public bool ClientAlreadyExists(int numClient); // cette méthode vérifie si un client existe déjà
    }
}

