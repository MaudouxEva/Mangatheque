using Mangatheque.BLL.Models;
using Mangatheque.DTOs;

namespace Mangatheque.Mappers;

public static class CollectionMapper
{
    // Méthode d'extension qui converti un unbjet Collection de la BLL en un objet CollectionDTO de la couche API
    // Chaque propriété de Collection est mappée
    // permet de protéger les modèles internes qui contiennent peut-être des données sensibles et ne doivent pas être exposées
    public static CollectionDTO MapToDTO(this Collection collection)
    {
        
        return new CollectionDTO
        {
            CollectionId = collection.CollectionId,
            Nom = collection.Nom,
            Description = collection.Description,
            Auteur = collection.Auteur,
            Illustration = collection.Illustration,
            DateSortie = collection.DateSortie,
            Prix = collection.Prix
        };
    }

    public static Collection MapToModel(this CollectionInsertFormDTO collection)
    {
        return new Collection
        {
            CollectionId = 0,
            Nom = collection.Nom,
            Description = collection.Description,
            Auteur = collection.Auteur,
            Illustration = collection.Illustration,
            DateSortie = collection.DateSortie,
            Prix = collection.Prix
        };
    }
}
    


