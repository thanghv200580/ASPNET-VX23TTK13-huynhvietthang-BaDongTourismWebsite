using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class Accommodation : BaseEntity
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
    public string? Email { get; set; }
    
    [MaxLength(200)]
    public string? Website { get; set; }
    
    [MaxLength(500)]
    public string? MainImage { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? PriceFrom { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } = 0;
    
    public bool IsActive { get; set; } = true;
}
