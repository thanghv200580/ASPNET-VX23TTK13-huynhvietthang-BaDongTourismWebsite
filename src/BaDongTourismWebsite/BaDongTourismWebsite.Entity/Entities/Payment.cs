using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public enum PaymentMethod
{
    Cash = 0,
    BankTransfer = 1,
    CreditCard = 2,
    EWallet = 3
}

public enum PaymentStatus
{
    Pending = 0,
    Completed = 1,
    Failed = 2,
    Refunded = 3
}

public class Payment : BaseEntity
{
    [Required]
    [MaxLength(50)]
    public string TransactionId { get; set; } = string.Empty;
    
    [Column(TypeName = "decimal(18,2)")]
    public decimal Amount { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    
    public PaymentStatus Status { get; set; } = PaymentStatus.Pending;
    
    public DateTime? PaymentDate { get; set; }
    
    [MaxLength(500)]
    public string? Notes { get; set; }
    
    // Foreign keys
    public int BookingId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(BookingId))]
    public virtual Booking Booking { get; set; } = null!;
}
