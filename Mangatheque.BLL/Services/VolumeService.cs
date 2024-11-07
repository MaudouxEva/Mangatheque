using Mangatheque.BLL.CustomExceptions;
using Mangatheque.BLL.Interfaces;
using Mangatheque.BLL.Mappers;
using Mangatheque.BLL.Models;
using Mangatheque.DAL.Interfaces;

namespace Mangatheque.BLL.Services;

public class VolumeService : IVolumeService
{
          
    private readonly IVolumeRepository _volumeRepository;
    private readonly ICollectionRepository _collectionRepository;
    
    public VolumeService(IVolumeRepository volumeRepository, ICollectionRepository collectionRepository)
    {
        _volumeRepository = volumeRepository;
        _collectionRepository = collectionRepository;
    }
    
    public IEnumerable<Volume> GetAllVolumes()
    {
        return _volumeRepository.GetAllVolumes()
            .Select(volumeEntity =>
            {
                var volume = volumeEntity.MapToModel();
                volume.Collection = _collectionRepository.GetCollectionById(volume.CollectionId).MapToModel();
                return volume;
            });
    }

    public Volume GetVolumeById(int id)
    {
        var volume = _volumeRepository.GetVolumeById(id).MapToModel();
        volume.Collection = _collectionRepository.GetCollectionById(volume.CollectionId).MapToModel();
        return volume;
    }

    public Volume GetVolumeByIsbn(string isbn)
    {
        var volume = _volumeRepository.GetVolumeByIsbn(isbn).MapToModel();
        volume.Collection = _collectionRepository.GetCollectionById(volume.CollectionId).MapToModel();
        return volume;
    }
    
    public IEnumerable<Volume> GetVolumesByCollectionId(int collectionId)
    {
        return _volumeRepository.GetAllVolumes()
            .Where(v => v.CollectionId == collectionId)
            .Select(volumeEntity =>
            {
                var volume = volumeEntity.MapToModel();
                volume.Collection = _collectionRepository.GetCollectionById(volume.CollectionId).MapToModel();
                return volume;
            });
    }

    public Volume CreateVolume(Volume volume)
    {
        if(_volumeRepository.VolumeAlreadyExists(volume.Isbn))
        {
            throw new AlreadyExistsException("Un volume avec cet ISBN existe déjà dans la base de données");
        }
        return _volumeRepository.CreateVolume(volume.MapToEntity()).MapToModel();
    }
}