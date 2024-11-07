using Mangatheque.DAL.Entities;

namespace Mangatheque.DAL.Interfaces
{
    public interface IVolumeRepository
    {
        public IEnumerable<Volume> GetAllVolumes();
        public Volume GetVolumeById(int id);
        public Volume GetVolumeByIsbn(string Isbn);
        public Volume CreateVolume(Volume volume);
        public bool VolumeAlreadyExists(string isbn);
    }
}