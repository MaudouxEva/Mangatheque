using Mangatheque.BLL.Models;

namespace Mangatheque.BLL.Interfaces;

public interface IClientService
{
    public IEnumerable<Client> GetAllClients();
    public IEnumerable<Client> GetActiveClients();
    public Client GetClientById(int id);
    public Client GetClientByMail(string mail);
    public Client getClientByNumClient(int numClient);
    public Client CreateClient(Client client);
    public string LoginClient(Client client);

}