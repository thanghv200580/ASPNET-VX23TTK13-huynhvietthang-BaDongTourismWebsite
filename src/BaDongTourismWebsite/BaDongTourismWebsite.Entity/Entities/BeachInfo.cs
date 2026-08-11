using System.ComponentModel.DataAnnotations;

namespace BaDongTourismWebsite.Entity.Entities;

public class BeachInfo
{
    public int Id { get; set; }

    [Required, MaxLength(200)]
    public string Title { get; set; } = "Biển Ba Động - Trà Vinh";

    [MaxLength(300)]
    public string? Subtitle { get; set; }

    [MaxLength(500)]
    public string? HeroImageUrl { get; set; }

    public string? OverviewText { get; set; }    // Tổng quan

    public string? NatureText { get; set; }      // Thiên nhiên & sinh thái

    public string? CultureText { get; set; }     // Văn hóa & lịch sử

    public string? TravelTipsText { get; set; }  // Kinh nghiệm du lịch

    public string? FoodText { get; set; }        // Ẩm thực đặc sản

    [MaxLength(200)]
    public string? Location { get; set; }

    [MaxLength(500)]
    public string? MapEmbedUrl { get; set; }

    [MaxLength(50)]
    public string? ContactPhone { get; set; }

    [MaxLength(100)]
    public string? ContactEmail { get; set; }

    public DateTime UpdatedDate { get; set; } = DateTime.Now;
}
