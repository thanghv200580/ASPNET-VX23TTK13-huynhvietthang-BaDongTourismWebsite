using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class Restaurant : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string Location { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string? PhoneNumber { get; set; }
    
    [MaxLength(100)]
    public string? Cuisine { get; set; }
    
    [MaxLength(500)]
    public string? MainImage { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? AveragePricePerPerson { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } = 0;
    
    public bool IsActive { get; set; } = true;
}
