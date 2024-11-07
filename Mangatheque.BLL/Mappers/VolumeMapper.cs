using Mangatheque.BLL.Models;
using Entity = Mangatheque.DAL.Entities;

namespace Mangatheque.BLL.Mappers;

public static class VolumeMapper
{
    public static Volume MapToModel(this Entity.Volume volumeEntity)
    {
        return new Volume()
        {
            VolumeId = volumeEntity.VolumeId,
            Isbn = volumeEntity.Isbn,
            Nom = volumeEntity.Nom,
            CollectionId = volumeEntity.CollectionId,
            NumTome = volumeEntity.NumTome,
            Resume = volumeEntity.Resume,
            Edition = volumeEntity.Edition,
            ImageCouverture = volumeEntity.ImageCouverture,
            DateSortie = volumeEntity.DateSortie,
            StockQuantite = volumeEntity.StockQuantite,
            Collection = volumeEntity.Collection?.MapToModel(),
        };
    }
    
    public static Entity.Volume MapToEntity(this Volume volumeModel)
    {
        return new Entity.Volume()
        {
            VolumeId = volumeModel.VolumeId,
            Isbn = volumeModel.Isbn,
            Nom = volumeModel.Nom,
            CollectionId = volumeModel.CollectionId,
            NumTome = volumeModel.NumTome,
            Resume = volumeModel.Resume,
            Edition = volumeModel.Edition,
            ImageCouverture = volumeModel.ImageCouverture,
            DateSortie = volumeModel.DateSortie,
            StockQuantite = volumeModel.StockQuantite,
            Collection = volumeModel.Collection?.MapToEntity(),
        };
    }
}