using Mangatheque.BLL.Models;
using Entity = Mangatheque.DAL.Entities;

namespace Mangatheque.BLL.Mappers;

public static class ClientMapper
{
    public static Entity.Client ToEntity(this Models.Client client)
    {
        return new Entity.Client
        {
            ClientId = client.ClientId,
            NumClient = client.NumClient,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Tel = client.Tel,
            Email = client.Email,
            Password = client.Password,
            ACarteFidelite = client.ACarteFidelite,
            Active = client.Active
        };
    }

    public static Client ToModel(this Client client)
    {
        return new Client
        {
            ClientId = client.ClientId,
            NumClient = client.NumClient,
            Nom = client.Nom,
            Prenom = client.Prenom,
            Tel = client.Tel,
            Email = client.Email,
            Password = client.Password,
            ACarteFidelite = client.ACarteFidelite,
            Active = client.Active
        };
    }
    
}