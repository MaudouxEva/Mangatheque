namespace Mangatheque.DAL.Entities;

public class Collection
{
    public int CollectionId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public string Illustration { get; set; } = string.Empty;
    public DateTime DateSortie { get; set; }
    public decimal Prix { get; set; }

    // Propriété de navigation qui établit une relation entre les entités Volume et Collection. 
    // Permet d'accéder à tous les volumes associés à une collection particulière.
    public ICollection<Volume> Volumes { get; set; }
}