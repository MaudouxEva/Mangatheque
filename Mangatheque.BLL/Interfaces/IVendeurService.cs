using Mangatheque.BLL.Models;

namespace Mangatheque.BLL.Interfaces;

public interface IVendeurService
{
    public IEnumerable<Vendeur> GetAllVendeurs();
    public Vendeur GetVendeurById(int id);
    public Vendeur GetVendeurByEmail(string email);
    public Vendeur CreateVendeur(Vendeur vendeur);
    public string LoginVendeur(Vendeur vendeur);
}