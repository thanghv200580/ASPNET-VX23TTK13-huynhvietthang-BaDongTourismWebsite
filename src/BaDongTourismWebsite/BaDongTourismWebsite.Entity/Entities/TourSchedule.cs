using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class TourSchedule : BaseEntity
{
    public int DayNumber { get; set; }
    
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? Location { get; set; }
    
    // Foreign keys
    public int TourId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(TourId))]
    public virtual Tour Tour { get; set; } = null!;
}
