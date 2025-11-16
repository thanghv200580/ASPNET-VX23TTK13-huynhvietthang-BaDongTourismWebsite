using System.ComponentModel.DataAnnotations.Schema;

namespace BaDongTourismWebsite.Entity.Entities;

public class TourDestination : BaseEntity
{
    public int TourId { get; set; }
    public int DestinationId { get; set; }
    
    public int DisplayOrder { get; set; } = 0;
    
    // Navigation properties
    [ForeignKey(nameof(TourId))]
    public virtual Tour Tour { get; set; } = null!;
    
    [ForeignKey(nameof(DestinationId))]
    public virtual Destination Destination { get; set; } = null!;
}
