using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class Tour : BaseEntity
{
    [Required]
    [MaxLength(200)]
    public string Name { get; set; } = string.Empty;
    
    [Required]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(200)]
    public string? ShortDescription { get; set; }
    
    [Required]
    [Column(TypeName = "decimal(18,2)")]
    public decimal Price { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? DiscountPrice { get; set; }
    
    public int Duration { get; set; } // in days
    
    public int MaxParticipants { get; set; }
    
    public DateTime StartDate { get; set; }
    
    public DateTime EndDate { get; set; }
    
    [MaxLength(500)]
    public string? MainImage { get; set; }
    
    [Column(TypeName = "decimal(3,2)")]
    public decimal Rating { get; set; } = 0;
    
    public bool IsFeatured { get; set; } = false;
    
    public bool IsActive { get; set; } = true;
    
    // Navigation properties
    public virtual ICollection<TourDestination> TourDestinations { get; set; } = new List<TourDestination>();
    public virtual ICollection<TourSchedule> TourSchedules { get; set; } = new List<TourSchedule>();
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
