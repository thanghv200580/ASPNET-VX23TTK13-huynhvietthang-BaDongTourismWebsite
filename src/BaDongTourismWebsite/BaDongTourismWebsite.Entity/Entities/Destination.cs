using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class Destination : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? ShortDescription { get; set; }
    
    [MaxLength(200)]
    public string Location { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string Province { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? MainImage { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } = 0;
    
    public int ViewCount { get; set; } = 0;
    
    public bool IsFeatured { get; set; } = false;
    
    public bool IsActive { get; set; } = true;
    
    // Foreign keys
    public int CategoryId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(CategoryId))]
    public virtual Category Category { get; set; } = null!;
    
    public virtual ICollection<DestinationImage> Images { get; set; } = new List<DestinationImage>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
    public virtual ICollection<TourDestination> TourDestinations { get; set; } = new List<TourDestination>();
}
