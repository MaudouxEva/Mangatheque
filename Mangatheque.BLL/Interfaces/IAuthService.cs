using Mangatheque.BLL.Models;

namespace Mangatheque.BLL.Interfaces;

// Deux méthodes de génération de jetons d'authentifications, une pour les clients et une pour les vendeurs. 
public interface IAuthService
{
    string GenerateToken(Client client);
    string GenerateToken(Vendeur vendeur);
}