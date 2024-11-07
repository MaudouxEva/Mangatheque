using Mangatheque.BLL.Models;

namespace Mangatheque.BLL.Interfaces;

public interface IVolumeService
{
    public IEnumerable<Volume> GetAllVolumes();
    public Volume GetVolumeById(int id);
    public Volume GetVolumeByIsbn(string isbn);
    public IEnumerable<Volume> GetVolumesByCollectionId(int collectionId);
    public Volume CreateVolume(Volume volume);
    
}