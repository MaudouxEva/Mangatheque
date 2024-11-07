using System.ComponentModel.DataAnnotations;

namespace Mangatheque.DTOs;

public class VolumeDTO
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
    public CollectionDTO Collection { get; set; }
}

public class VolumeInsertFormDTO
{
    [Required]
    [MaxLength(20)]
    public string Isbn { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string Nom { get; set; } = string.Empty;
    
    [Required]
    public int CollectionId { get; set; }
    
    [Required]
    public int NumTome { get; set; }
    
    [MaxLength(500)]
    public string Resume { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string Edition { get; set; } = string.Empty;
    
    public string ImageCouverture { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateSortie { get; set; }
    
    [Required]
    public int StockQuantite { get; set; }
}