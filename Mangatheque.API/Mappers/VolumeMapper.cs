using Mangatheque.BLL.Models;
using Mangatheque.DTOs;

namespace Mangatheque.Mappers;

public static class VolumeMapper
{
   // Convertit un objet de type Volume en VolumeDTO en copiant les valeurs des propriétés.
   // Permet de transformer les données du modèle de la DB en un format plus adapté pour être envoyé à l'API.
    public static VolumeDTO MapToDTO(this Volume volume)
    {
        if (volume == null)
        {
            throw new ArgumentNullException(nameof(volume), "Volume cannot be null");
        }
        
        return new VolumeDTO()
        {
           VolumeId = volume.VolumeId,
            Isbn = volume.Isbn,
            Nom = volume.Nom,
            CollectionId = volume.CollectionId,
            NumTome = volume.NumTome,
            Resume = volume.Resume,
            Edition = volume.Edition,
            ImageCouverture = volume.ImageCouverture,
            DateSortie = volume.DateSortie,
            StockQuantite = volume.StockQuantite,
            // Pour inclure les informations de la collection liée à ce volume (pas nécessaire dans la méthode MapToModel)
            Collection = volume.Collection?.MapToDTO(),
        };
    }

    // Prend un objet de type VolumeInsertFormDTO et crée un nouvel objet de type Volume en copiant les valeurs des propiétés.
    public static Volume MapToModel(this VolumeInsertFormDTO volume)
    {
        return new Volume()
        {
            VolumeId = 0,
            Isbn = volume.Isbn,
            Nom = volume.Nom,
            CollectionId = volume.CollectionId,
            NumTome = volume.NumTome,
            Resume = volume.Resume,
            Edition = volume.Edition,
            ImageCouverture = volume.ImageCouverture,
            DateSortie = volume.DateSortie,
            StockQuantite = volume.StockQuantite,
        };
    }
}