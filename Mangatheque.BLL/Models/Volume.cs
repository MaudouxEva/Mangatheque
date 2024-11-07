namespace Mangatheque.BLL.Models;

public class Volume
{
    public int VolumeId { get; set; }
    public string Isbn { get; set; } = string.Empty;
    public string Nom { get; set; } = string.Empty;
    public int CollectionId { get; set; }
    public int NumTome { get; set; }
    public string Resume { get; set; } = string.Empty;
    public string Edition { get; set; } = string.Empty;
    public string ImageCouverture { get; set; } = string.Empty;
    public DateTime DateSortie { get; set; }
    public int StockQuantite { get; set; }
    public Collection Collection { get; set; }
    
}