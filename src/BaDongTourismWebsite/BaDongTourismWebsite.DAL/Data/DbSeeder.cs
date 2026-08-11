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
        await _context.Database.MigrateAsync();

        // Seed Roles
        if (!await _context.Roles.AnyAsync())
        {
            var roles = new List<Role>
            {
                new Role { Name = "Admin", Description = "Quản trị viên toàn quyền" },
                new Role { Name = "Staff", Description = "Nhân viên quản lý nội dung" }
            };
            await _context.Roles.AddRangeAsync(roles);
            await _context.SaveChangesAsync();
        }

        // Seed Admin User
        if (!await _context.Users.AnyAsync())
        {
            var adminUser = new User
            {
                FullName = "Quản trị viên",
                Email = "admin@badong.com",
                PasswordHash = BCrypt.Net.BCrypt.HashPassword("Admin@123"),
                PhoneNumber = "0294.123.456",
                IsActive = true,
                IsEmailConfirmed = true
            };
            await _context.Users.AddAsync(adminUser);
            await _context.SaveChangesAsync();

            var adminRole = await _context.Roles.FirstAsync(r => r.Name == "Admin");
            await _context.UserRoles.AddAsync(new UserRole { UserId = adminUser.Id, RoleId = adminRole.Id });
            await _context.SaveChangesAsync();
        }

        // Seed BeachInfo (single record)
        if (!await _context.BeachInfos.AnyAsync())
        {
            var beachInfo = new BeachInfo
            {
                Title = "Biển Ba Động - Trà Vinh",
                Subtitle = "Bãi biển hoang sơ đẹp nhất vùng Đồng bằng sông Cửu Long",
                HeroImageUrl = "https://i2.ex-cdn.com/crystalbay.com/files/content/2025/03/09/bien-ba-dong-1-0006.jpg",
                OverviewText = "Bãi biển Ba Động thuộc xã Trường Long Hòa, huyện Duyên Hải, tỉnh Trà Vinh — cách thành phố Trà Vinh khoảng 50km về phía đông nam. Với chiều dài hơn 10km, cát vàng mịn và sóng biển trong xanh, Ba Động được mệnh danh là một trong những bãi biển đẹp và hoang sơ nhất vùng ĐBSCL. Nơi đây vẫn giữ được vẻ nguyên sơ, tĩnh lặng — lý tưởng cho những ai muốn thoát khỏi nhịp sống ồn ào của thành phố.",
                NatureText = "Dọc bờ biển Ba Động là dải rừng phòng hộ phi lao (dương liễu) xanh mát, tạo bóng râm tự nhiên và là lá chắn chống xói mòn. Phía sau bờ biển là đầm Cồn Chim — một hệ sinh thái đất ngập nước phong phú, nơi sinh sống của hàng trăm loài chim nước và thủy sinh vật. Hoàng hôn trên biển Ba Động là khoảnh khắc không thể bỏ lỡ.",
                CultureText = "Ba Động là vùng đất giàu truyền thống văn hóa. Đền thờ Bác Hồ nằm ngay cạnh bờ biển là công trình tâm linh quan trọng. Cộng đồng người Khmer sinh sống tại đây với những ngôi chùa cổ kính, lễ hội Ok Om Bok và nghề đan lát truyền thống. Lễ Nghinh Ông (cúng Ông) hàng năm thu hút đông đảo ngư dân và du khách.",
                TravelTipsText = "Di chuyển: Từ TP.HCM đến Trà Vinh khoảng 200km (4–5 giờ xe), sau đó đến huyện Duyên Hải thêm 50km. Có xe khách tuyến HCM–Trà Vinh hàng ngày. Thời điểm lý tưởng: Tháng 11 đến tháng 4 (mùa khô). Tránh tháng 6–9 (mùa mưa, sóng lớn). Lưu ý: Mang kem chống nắng, đặt chỗ lưu trú sớm vào dịp lễ Tết.",
                FoodText = "Hải sản Ba Động nổi tiếng với tôm, cua, ghẹ, nghêu, ốc tươi sống đánh bắt trong ngày. Đặc sản: bún nước lèo (đặc sản Khmer), bánh tét lá cẩm, mắm rươi, cá khô một nắng. Dọc bờ biển có nhiều quán ăn dân dã với giá bình dân.",
                Location = "Xã Trường Long Hòa, Huyện Duyên Hải, Tỉnh Trà Vinh",
                MapEmbedUrl = "https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d62893.0!2d106.6!3d9.6!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x31a074b87a000001!2sDuyen+Hai+District!5e0!3m2!1svi!2svn!4v1",
                ContactPhone = "0294.123.456",
                ContactEmail = "info@badong.com",
                UpdatedDate = DateTime.Now
            };
            await _context.BeachInfos.AddAsync(beachInfo);
            await _context.SaveChangesAsync();
        }

        // Seed Beach Services
        if (!await _context.BeachServices.AnyAsync())
        {
            var services = new List<BeachService>
            {
                new BeachService { Name = "Lướt sóng (Surfing)", Description = "Trải nghiệm môn thể thao lướt sóng hấp dẫn. Hướng dẫn viên kèm cặp từng bước. Ván surf và thiết bị bảo hộ đầy đủ được cung cấp.", Price = 250000, PriceUnit = "/ người / giờ", MainImage = "https://waterbeartour.com.vn/upload/filemanage/ls2.png", ContactPhone = "0294.111.222", IsActive = true, DisplayOrder = 1 },
                new BeachService { Name = "Thuê cano tốc độ cao", Description = "Lướt cano tốc độ cao trên mặt biển Ba Động. Mỗi chuyến 30 phút, sức chứa 6–8 người. Áo phao và thiết bị an toàn đầy đủ.", Price = 500000, PriceUnit = "/ chuyến 30 phút", MainImage = "https://culaoxanhtourist.com/wp-content/uploads/2021/05/18.jpg", ContactPhone = "0294.333.444", IsActive = true, DisplayOrder = 2 },
                new BeachService { Name = "Tàu chuối (Banana Boat)", Description = "Trò chơi tàu chuối sôi động cho cả nhóm. Mỗi lượt 15 phút, sức chứa 4–6 người. Phao cứu sinh và áo phao bắt buộc.", Price = 150000, PriceUnit = "/ người / lượt", MainImage = "https://quangthangcatba.com/image/catalog/Tin%20t%E1%BB%A9c/c%C3%A1t%20b%C3%A0%202/phao-chuoi-cat-ba-1.jpg", ContactPhone = "0294.555.666", IsActive = true, DisplayOrder = 3 },
                new BeachService { Name = "Thuyền kayak đôi", Description = "Chèo kayak khám phá vùng ven biển Ba Động. Không cần kinh nghiệm. Tuyến đường qua khu rừng phòng hộ và vùng biển gần bờ.", Price = 120000, PriceUnit = "/ thuyền / giờ", MainImage = "https://cdn.haikayak.com/wp-content/uploads/2022/09/306508528_486365130164241_9061737415146049157_n.jpg", ContactPhone = "0294.777.888", IsActive = true, DisplayOrder = 4 },
                new BeachService { Name = "Lặn snorkel ngắm san hô", Description = "Khám phá thế giới dưới nước. Kính lặn, ống thở và chân nhái được cung cấp. Không phù hợp trẻ dưới 10 tuổi và người không biết bơi.", Price = 200000, PriceUnit = "/ người / buổi", MainImage = "https://phuquocxanh.com/vi/wp-content/uploads/2016/03/c%C3%A2u-c%C3%A1-l%E1%BA%B7n-ng%E1%BA%AFm-san-h%C3%B4-Ph%C3%BA-Qu%E1%BB%91c-1.jpg", ContactPhone = "0294.999.000", IsActive = true, DisplayOrder = 5 }
            };

            await _context.BeachServices.AddRangeAsync(services);
            await _context.SaveChangesAsync();
        }
    }
}
