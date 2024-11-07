using System.ComponentModel.DataAnnotations;

namespace Mangatheque.DTOs;

// DTO => permet de séparer les modèles de données utilisés en interne (BLL et DAL) des modèles exposés aux clients de l'API
public class CollectionDTO
{
    public int CollectionId { get; set; }
    public string Nom { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Auteur { get; set; } = string.Empty;
    public string Illustration { get; set; } = string.Empty;
    public DateTime DateSortie { get; set; }
    public decimal Prix { get; set; }
}

// DTO utilisé pour la création d'une collection. Peut permettre de valider des données lors de la création d'une collection
public class CollectionInsertFormDTO
{
    // les dataAnnotations permettent de valider les données entrantes avant qu'elles ne soient traitées par la BLL, assurant l'intégrité des données
    [Required]
    [MaxLength(200)]
    public string Nom { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(200)]
    public string Auteur { get; set; } = string.Empty;
    
    public string Illustration { get; set; } = string.Empty;
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateSortie { get; set; }
    
    [Required]
    public decimal Prix { get; set; }
}