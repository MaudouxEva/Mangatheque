using Mangatheque.BLL.Models;
using Entity = Mangatheque.DAL.Entities;

namespace Mangatheque.BLL.Mappers;

public static class VendeurMapper
{
    public static Entity.Vendeur ToEntity(this Vendeur vendeur)
    {
        return new Entity.Vendeur
        {
            VendeurId = vendeur.VendeurId,
            Nom = vendeur.Nom,
            Prenom = vendeur.Prenom,
            Email = vendeur.Email,
            Password = vendeur.Password
        };
    }

    public static Vendeur ToModel(this Entity.Vendeur vendeur)
    {
        return new Vendeur
        {
            VendeurId = vendeur.VendeurId,
            Nom = vendeur.Nom,
            Prenom = vendeur.Prenom,
            Email = vendeur.Email,
            Password = vendeur.Password
        };
    }
}