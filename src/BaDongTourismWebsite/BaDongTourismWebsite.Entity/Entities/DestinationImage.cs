using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class DestinationImage : BaseEntity
{
    [Required]
    [MaxLength(500)]
    public string ImageUrl { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? Caption { get; set; }
    
    public int DisplayOrder { get; set; } = 0;
    
    // Foreign keys
    public int DestinationId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(DestinationId))]
    public virtual Destination Destination { get; set; } = null!;
}
