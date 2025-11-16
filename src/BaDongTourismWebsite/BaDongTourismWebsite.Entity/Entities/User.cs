using System.ComponentModel.DataAnnotations;

namespace BaDongTourismWebsite.Entity.Entities;

public class User : BaseEntity
{
    [Required]
    [MaxLength(100)]
    public string FullName { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress]
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    
    [MaxLength(20)]
    public string? PhoneNumber { get; set; }
    
    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; } = string.Empty;
    
    [MaxLength(500)]
    public string? Avatar { get; set; }
    
    public bool IsActive { get; set; } = true;
    
    public bool IsEmailConfirmed { get; set; } = false;
    
    public DateTime? LastLoginDate { get; set; }
    
    // Navigation properties
    public virtual ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    public virtual ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
