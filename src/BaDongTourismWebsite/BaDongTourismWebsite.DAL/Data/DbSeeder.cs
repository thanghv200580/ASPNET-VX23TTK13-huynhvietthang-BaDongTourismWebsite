using BaDongTourismWebsite.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourismWebsite.DAL.Data;

public class DbSeeder
{
    private readonly ApplicationDbContext _context;
    
    public DbSeeder(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task SeedAsync()
    {
        // Ensure database is created
        await _context.Database.MigrateAsync();
        
        // Seed Roles
        if (!await _context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin", Description = "Administrator with full access" },
                new Role { Name = "Staff", Description = "Staff member with limited access" },
                new Role { Name = "Customer", Description = "Regular customer" },
                new Role { Name = "Guest", Description = "Guest user" }
            };
            
            await _context.Roles.AddRangeAsync(roles);
            await _context.SaveChangesAsync();
        }
        
        // Seed Admin User
        if (!await _context.Users.AnyAsync())
        {
            var adminUser = new User
            {
                FullName = "Administrator",
                Email = "admin@badong.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                PhoneNumber = "0123456789",
                IsActive = true,
                IsEmailConfirmed = true
            };
            
            await _context.Users.AddAsync(adminUser);
            await _context.SaveChangesAsync();
            
            // Assign Admin role
            var adminRole = await _context.Roles.FirstAsync(r => r.Name == "Admin");
            var userRole = new UserRole
            {
                UserId = adminUser.Id,
                RoleId = adminRole.Id
            };
            
            await _context.UserRoles.AddAsync(userRole);
            await _context.SaveChangesAsync();
        }
        
        // Seed Categories
        if (!await _context.Categories.AnyAsync())
        {
            var categories = new List<Category>
            {
                new Category { Name = "Biển", Description = "Các điểm du lịch biển đảo", Icon = "fa-water", IsActive = true },
                new Category { Name = "Núi", Description = "Các điểm du lịch núi non", Icon = "fa-mountain", IsActive = true },
                new Category { Name = "Văn hóa", Description = "Di tích văn hóa, lịch sử", Icon = "fa-landmark", IsActive = true },
                new Category { Name = "Thiên nhiên", Description = "Vườn quốc gia, rừng nhiệt đới", Icon = "fa-tree", IsActive = true },
                new Category { Name = "Đô thị", Description = "Khu đô thị, thành phố", Icon = "fa-city", IsActive = true },
                new Category { Name = "Sinh thái", Description = "Du lịch sinh thái", Icon = "fa-leaf", IsActive = true }
            };
            
            await _context.Categories.AddRangeAsync(categories);
            await _context.SaveChangesAsync();
        }
        
        // Seed Sample Destinations
        if (!await _context.Destinations.AnyAsync())
        {
            var bienlCategory = await _context.Categories.FirstAsync(c => c.Name == "Biển");
            var nuiCategory = await _context.Categories.FirstAsync(c => c.Name == "Núi");
            var vanhoaCategory = await _context.Categories.FirstAsync(c => c.Name == "Văn hóa");
            
            var destinations = new List<Destination>
            {
                new Destination
                {
                    Name = "Bãi biển Ba Đồng",
                    ShortDescription = "Bãi biển hoang sơ với cát trắng mịn và nước biển trong xanh",
                    Description = "Bãi biển Ba Đồng là một trong những bãi biển đẹp nhất khu vực với cát trắng mịn, nước biển trong xanh. Đây là điểm đến lý tưởng cho những ai yêu thích tắm biển và các hoạt động thể thao dưới nước.",
                    Location = "Xã Ba Đồng, Huyện Ba Đồng",
                    Province = "Quảng Bình",
                    CategoryId = bienlCategory.Id,
                    MainImage = "/images/destinations/badong-beach.jpg",
                    Rating = 4.5m,
                    IsFeatured = true,
                    IsActive = true
                },
                new Destination
                {
                    Name = "Núi Phước Tượng",
                    ShortDescription = "Ngọn núi hùng vĩ với tượng Phật khổng lồ",
                    Description = "Núi Phước Tượng nổi tiếng với pho tượng Phật khổng lồ trên đỉnh núi. Từ đây có thể ngắm toàn cảnh vùng Ba Đồng tuyệt đẹp.",
                    Location = "Thị trấn Ba Đồng",
                    Province = "Quảng Bình",
                    CategoryId = nuiCategory.Id,
                    MainImage = "/images/destinations/phuoc-tuong.jpg",
                    Rating = 4.3m,
                    IsFeatured = true,
                    IsActive = true
                },
                new Destination
                {
                    Name = "Đình làng cổ Ba Đồng",
                    ShortDescription = "Di tích lịch sử văn hóa được công nhận cấp tỉnh",
                    Description = "Đình làng Ba Đồng được xây dựng từ thế kỷ 18, là nơi thờ Thành hoàng làng và tổ chức các lễ hội truyền thống. Kiến trúc cổ kính, mang đậm nét văn hóa dân gian miền Trung.",
                    Location = "Thôn Trung, Xã Ba Đồng",
                    Province = "Quảng Bình",
                    CategoryId = vanhoaCategory.Id,
                    MainImage = "/images/destinations/dinh-lang.jpg",
                    Rating = 4.0m,
                    IsFeatured = false,
                    IsActive = true
                },
                new Destination
                {
                    Name = "Vườn sinh thái Ba Đồng",
                    ShortDescription = "Vườn sinh thái với đa dạng sinh học phong phú",
                    Description = "Vườn sinh thái Ba Đồng có diện tích rộng với nhiều loại cây trái nhiệt đới, khu vườn chim, ao nuôi cá. Đây là địa điểm lý tưởng cho các hoạt động dã ngoại và tìm hiểu thiên nhiên.",
                    Location = "Xã Ba Đồng",
                    Province = "Quảng Bình",
                    CategoryId = await _context.Categories.Where(c => c.Name == "Sinh thái").Select(c => c.Id).FirstAsync(),
                    MainImage = "/images/destinations/eco-garden.jpg",
                    Rating = 4.2m,
                    IsFeatured = true,
                    IsActive = true
                }
            };
            
            await _context.Destinations.AddRangeAsync(destinations);
            await _context.SaveChangesAsync();
        }
        
        // Seed Sample Tours
        if (!await _context.Tours.AnyAsync())
        {
            var tours = new List<Tour>
            {
                new Tour
                {
                    Name = "Tour khám phá Ba Đồng 2 ngày 1 đêm",
                    ShortDescription = "Trải nghiệm đầy đủ các điểm du lịch nổi bật",
                    Description = "Tour du lịch Ba Đồng 2 ngày 1 đêm đưa bạn khám phá các điểm đến đẹp nhất khu vực: Bãi biển Ba Đồng, Núi Phước Tượng, Đình làng cổ và Vườn sinh thái.",
                    Price = 1500000,
                    Duration = 2,
                    MaxParticipants = 20,
                    StartDate = DateTime.UtcNow.AddDays(7),
                    EndDate = DateTime.UtcNow.AddDays(9),
                    MainImage = "/images/tours/tour-2d1n.jpg",
                    Rating = 4.6m,
                    IsFeatured = true,
                    IsActive = true
                },
                new Tour
                {
                    Name = "Tour 1 ngày trải nghiệm biển Ba Đồng",
                    ShortDescription = "Tận hưởng một ngày vui chơi tại bãi biển",
                    Description = "Tour 1 ngày đưa bạn đến bãi biển Ba Đồng với các hoạt động: tắm biển, lặn ngắm san hô, thưởng thức hải sản tươi sống.",
                    Price = 500000,
                    Duration = 1,
                    MaxParticipants = 30,
                    StartDate = DateTime.UtcNow.AddDays(3),
                    EndDate = DateTime.UtcNow.AddDays(3),
                    MainImage = "/images/tours/tour-1d-beach.jpg",
                    Rating = 4.4m,
                    IsFeatured = true,
                    IsActive = true
                }
            };
            
            await _context.Tours.AddRangeAsync(tours);
            await _context.SaveChangesAsync();
        }
    }
}
