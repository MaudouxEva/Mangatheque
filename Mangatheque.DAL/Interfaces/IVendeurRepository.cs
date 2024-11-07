using Mangatheque.DAL.Entities;

namespace Mangatheque.DAL.Interfaces;

public interface IVendeurRepository
{
    public IEnumerable<Vendeur> GetAllVendeurs();
    public Vendeur GetVendeurById(int id);
    public Vendeur CreateVendeur(Vendeur vendeur);
}