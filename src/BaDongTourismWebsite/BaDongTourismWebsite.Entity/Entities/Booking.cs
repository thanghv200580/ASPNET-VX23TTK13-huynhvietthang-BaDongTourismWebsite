using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public enum BookingStatus
{
    Pending = 0,
    Confirmed = 1,
    Cancelled = 2,
    Completed = 3,
    Refunded = 4
}

public class Booking : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string BookingCode { get; set; } = string.Empty;
    
    public DateTime BookingDate { get; set; } = DateTime.UtcNow;
    
    public int NumberOfPeople { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal TotalAmount { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal? DiscountAmount { get; set; }
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal FinalAmount { get; set; }
    
    public BookingStatus Status { get; set; } = BookingStatus.Pending;
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    [MaxLength(100)]
    public string ContactName { get; set; } = string.Empty;
    
    [MaxLength(100)]
    public string ContactEmail { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string ContactPhone { get; set; } = string.Empty;
    
    public DateTime? ConfirmedDate { get; set; }
    public DateTime? CancelledDate { get; set; }
    
    // Foreign keys
    public int UserId { get; set; }
    public int TourId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
    
    [ForeignKey(nameof(TourId))]
    public virtual Tour Tour { get; set; } = null!;
    
    public virtual Payment? Payment { get; set; }
}
