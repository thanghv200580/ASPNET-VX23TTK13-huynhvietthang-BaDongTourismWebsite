using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class Review : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public string Content { get; set; } = string.Empty;
    
    [Range(1, 5)]
    public int Rating { get; set; }
    
    public bool IsApproved { get; set; } = false;
    
    // Foreign keys
    public int UserId { get; set; }
    public int? TourId { get; set; }
    public int? DestinationId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
    
    [ForeignKey(nameof(TourId))]
    public virtual Tour? Tour { get; set; }
    
    [ForeignKey(nameof(DestinationId))]
    public virtual Destination? Destination { get; set; }
}
