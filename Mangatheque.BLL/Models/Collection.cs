namespace Mangatheque.BLL.Models
{
    
    public class Collection
    {
        public int CollectionId { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Auteur { get; set; } = string.Empty;
        public string Illustration { get; set; } = string.Empty;
        public DateTime DateSortie { get; set; }
        public decimal Prix { get; set; }
    }
}

