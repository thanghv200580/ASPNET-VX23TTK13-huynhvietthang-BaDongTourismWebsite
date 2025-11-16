using System.ComponentModel.DataAnnotations;

namespace BaDongTourismWebsite.Entity.Entities;

public class Category : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string Name { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Description { get; set; }
    
    [MaxLength(50)]
    public string? Icon { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public virtual ICollection<Destination> Destinations { get; set; } = new List<Destination>();
}
