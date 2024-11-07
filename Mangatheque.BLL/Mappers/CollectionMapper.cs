using Mangatheque.BLL.Models;
using Entity = Mangatheque.DAL.Entities;

namespace Mangatheque.BLL.Mappers
{
    

    // Le mapper s'occupe de la conversion de données entre les différentes couches de l'app : la couche d'accès aux données (DAL) et la couche de logique métier (BLL)
    public static class CollectionMapper
    {
        
        //Convertit une entité Collection de la DAL en modèle Collection de la BLL
        // Méthode d'extension (=> permet de l'appeler directement sur une instance de Entity.Collection) qui convertir une entité Collection (DAL) en un modèle (BLL)
        public static Collection MapToModel(this Entity.Collection collectionEntity)
        {
            // retourne une nouvelle instance de Collection mais de BLL
            return new Collection()
            {
                // chaque propriété de l'entité est copiée dans la nouvelle instance de modèle
                CollectionId = collectionEntity.CollectionId,
                Nom = collectionEntity.Nom,
                Description = collectionEntity.Description,
                Auteur = collectionEntity.Auteur,
                Illustration = collectionEntity.Illustration,
                DateSortie = collectionEntity.DateSortie,
                Prix = collectionEntity.Prix
            };
        }

        // Convertit un modèle Collection de la BLL en entité Collection de la DAL
        public static Entity.Collection MapToEntity(this Collection collectionModel)
        {
            return new Entity.Collection()
            {
                CollectionId = collectionModel.CollectionId,
                Nom = collectionModel.Nom,
                Description = collectionModel.Description,
                Auteur = collectionModel.Auteur,
                Illustration = collectionModel.Illustration,
                DateSortie = collectionModel.DateSortie,
                Prix = collectionModel.Prix
            };
        }
}

    // Ces deux méthodes sont utilisées dans le service pour convertir les données en couches.
    // Exemple : création d'une collection => le modèle est converti en entité avant d'être stocké en DB, et l'entité créée est ensuire convertie en modèle pour etre retournée
}