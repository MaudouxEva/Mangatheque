namespace Mangatheque.DAL.Entities
{
    public class Volume
    {
        public int VolumeId { get; set; }
        public string Isbn { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public int CollectionId { get; set; }
        public int NumTome { get; set; }
        public string Resume { get; set; } = string.Empty;
        public string Edition { get; set; } = string.Empty;
        public string? ImageCouverture { get; set; } = string.Empty;
        public DateTime DateSortie { get; set; }
        public int StockQuantite { get; set; }

        // Propiété de navigation : établit une connexion entre les entités Volume et Collection, permettant de naviguer de l'une à l'autre
        // Propriété représente une relation de clé étrangère entre les tables Volume et Collection. Enregistrement dan table volume -> enregistrement dans table collection
        public Collection Collection { get; set; }
    }
    
}

