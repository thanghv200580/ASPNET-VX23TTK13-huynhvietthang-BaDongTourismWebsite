using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class UserRole : BaseEntity
{
    // Foreign keys
    public int UserId { get; set; }
    public int RoleId { get; set; }
    
    // Navigation properties
    [ForeignKey(nameof(UserId))]
    public virtual User User { get; set; } = null!;
    
    [ForeignKey(nameof(RoleId))]
    public virtual Role Role { get; set; } = null!;
}
