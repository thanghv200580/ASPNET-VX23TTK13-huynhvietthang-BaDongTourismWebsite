# Báo cáo tuần 02 - Week 02 Report

**Thời gian**: Tuần 2 (17/11/2025 - 23/11/2025)  
**Sinh viên**: [Tên sinh viên] - [MSSV]  
**Lớp**: VX23TTK13

---

## 📌 Mục tiêu tuần 02

Thiết kế database schema, implement Entity Framework Core, và bắt đầu phát triển các tính năng chính của website du lịch Ba Đống.

---

## 📋 Công việc dự kiến thực hiện

### 1. Thiết kế Database Schema
**Ước tính thời gian**: 1-2 ngày

#### Các bảng chính cần thiết kế:

**a) Quản lý Người dùng**
- `Users`: Thông tin người dùng, khách hàng
- `Roles`: Vai trò (Admin, Staff, Customer, Guest)
- `UserRoles`: Mapping user và role

**b) Quản lý Điểm Du lịch**
- `Destinations`: Các điểm du lịch
  - Id, Name, Description, Location, Province
  - Images, Rating, Status, CreatedDate
- `DestinationImages`: Hình ảnh điểm du lịch
- `Categories`: Loại hình du lịch (biển, núi, văn hóa, lịch sử...)

**c) Quản lý Tour**
- `Tours`: Thông tin tour du lịch
  - Id, Name, Description, Duration, Price
  - MaxParticipants, StartDate, EndDate
- `TourSchedules`: Lịch trình chi tiết tour
- `TourDestinations`: Các điểm trong tour

**d) Quản lý Booking**
- `Bookings`: Đơn đặt tour/dịch vụ
  - Id, UserId, TourId, BookingDate, TotalAmount
  - Status (Pending, Confirmed, Cancelled, Completed)
- `BookingDetails`: Chi tiết đặt chỗ
- `Payments`: Thông tin thanh toán

**e) Dịch vụ bổ sung**
- `Accommodations`: Chỗ ở (khách sạn, homestay)
- `Restaurants`: Nhà hàng, ẩm thực
- `Services`: Các dịch vụ khác (thuê xe, hướng dẫn viên...)

**Kết quả mong đợi**: 
- ERD diagram hoàn chỉnh
- Document mô tả chi tiết các bảng và relationships

---

### 2. Cài đặt và cấu hình Entity Framework Core
**Ước tính thời gian**: 0.5-1 ngày

#### Các bước thực hiện:

1. **Cài đặt NuGet packages**:
   ```bash
   dotnet add package Microsoft.EntityFrameworkCore
   dotnet add package Microsoft.EntityFrameworkCore.Design
   dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
   dotnet add package Microsoft.EntityFrameworkCore.Tools
   ```

2. **Tạo DbContext**:
   - File `Data/ApplicationDbContext.cs`
   - Cấu hình connection string
   - Define DbSet cho các entities

3. **Tạo Entity Models**:
   - Folder `Models/Entities/`
   - Implement các entity classes
   - Data annotations và Fluent API

4. **Cấu hình trong Program.cs**:
   - Register DbContext với DI container
   - Configure connection string từ appsettings.json

**Kết quả mong đợi**:
- EF Core được cấu hình và sẵn sàng sử dụng
- Connection đến PostgreSQL thành công

---

### 3. Tạo Migrations và Update Database
**Ước tính thời gian**: 0.5 ngày

#### Các lệnh thực hiện:

```bash
# Tạo migration đầu tiên
dotnet ef migrations add InitialCreate

# Update database
dotnet ef database update

# Kiểm tra migrations
dotnet ef migrations list
```

#### Seed Data (nếu có thời gian):
- Tạo `Data/DbSeeder.cs`
- Seed dữ liệu mẫu cho:
  - Admin user
  - Một số điểm du lịch mẫu
  - Categories cơ bản

**Kết quả mong đợi**:
- Database schema được tạo trong PostgreSQL
- Có dữ liệu mẫu để test

---

### 4. Phát triển Trang chủ (Homepage)
**Ước tính thời gian**: 1-2 ngày

#### Các components cần thiết:

**a) Header/Navigation**
- Logo website
- Menu chính (Trang chủ, Điểm du lịch, Tours, Về chúng tôi, Liên hệ)
- Search bar
- User menu (Login/Register)

**b) Hero Section**
- Banner slider với hình ảnh đẹp Ba Đống
- Call-to-action button
- Search box tour nhanh

**c) Featured Destinations**
- Hiển thị 6-8 điểm du lịch nổi bật
- Card layout với image, title, short description
- Link đến trang chi tiết

**d) Popular Tours**
- Danh sách 4-6 tour phổ biến
- Hiển thị: giá, thời gian, số chỗ còn trống
- Button "Đặt tour"

**e) Services Section**
- Icons và mô tả các dịch vụ (Tour, Khách sạn, Nhà hàng, Vận chuyển)

**f) Testimonials (nếu có thời gian)**
- Đánh giá từ khách hàng

**g) Footer**
- Thông tin liên hệ
- Social media links
- Quick links
- Copyright

**Công nghệ sử dụng**:
- Bootstrap 5 components
- Custom CSS
- jQuery cho interactive elements
- Font Awesome icons

**Kết quả mong đợi**:
- Trang chủ hoàn chỉnh, responsive
- Kết nối dữ liệu từ database (featured destinations)

---

### 5. Module Quản lý Điểm Du lịch (Destinations Management)
**Ước tính thời gian**: 1-2 ngày

#### Các trang cần phát triển:

**a) Danh sách điểm du lịch (`/Destinations/Index`)**
- Grid/List view
- Pagination
- Filter theo category, location
- Search box
- Sorting (theo tên, rating, date)

**b) Chi tiết điểm du lịch (`/Destinations/Details/{id}`)**
- Thông tin đầy đủ
- Image gallery/slider
- Location map (Google Maps hoặc OpenStreetMap)
- Rating & reviews section
- Related destinations
- Button "Thêm vào tour yêu thích"

**c) Admin - Tạo điểm du lịch mới (`/Admin/Destinations/Create`)**
- Form với validation
- Upload multiple images
- Rich text editor cho description
- Category selection
- Location picker

**d) Admin - Chỉnh sửa (`/Admin/Destinations/Edit/{id}`)**
- Pre-filled form
- Update images
- Soft delete option

**e) Admin - Xóa (`/Admin/Destinations/Delete/{id}`)**
- Confirmation dialog
- Soft delete implementation

**Repository Pattern (recommended)**:
- `IDestinationRepository`
- `DestinationRepository`
- Service layer nếu có logic phức tạp

**Kết quả mong đợi**:
- CRUD hoàn chỉnh cho Destinations
- User có thể xem danh sách và chi tiết
- Admin có thể quản lý destinations

---

## 🎯 Deliverables dự kiến

| STT | Deliverable | Trạng thái dự kiến |
|-----|-------------|-------------------|
| 1 | ERD Database Schema | 🟡 Hoàn thành |
| 2 | Entity Models (10+ classes) | 🟡 Hoàn thành |
| 3 | DbContext & Configuration | 🟡 Hoàn thành |
| 4 | Database Migrations | 🟡 Hoàn thành |
| 5 | Homepage (7+ sections) | 🟡 Hoàn thành |
| 6 | Destinations Module (5 pages) | 🟡 Hoàn thành |
| 7 | Seed Data | 🟡 Hoàn thành |
| 8 | Unit Tests (nếu có thời gian) | 🟠 Optional |

---

## 📊 Phân bổ thời gian

```
Thứ 2-3:   Database Schema Design + EF Core Setup
Thứ 4:     Migrations + Seed Data
Thứ 5-6:   Homepage Development
Thứ 7:     Destinations Module
Chủ nhật:  Testing, Bug fixes, Documentation
```

---

## 🔧 Công cụ & Thư viện mới

- **Entity Framework Core 9.0**: ORM
- **Npgsql**: PostgreSQL provider
- **AutoMapper** (nếu cần): Object mapping
- **FluentValidation** (nếu cần): Validation
- **TinyMCE/CKEditor**: Rich text editor
- **Leaflet.js/Google Maps API**: Maps integration

---

## 📚 Tài liệu cần nghiên cứu

1. [EF Core with PostgreSQL](https://www.npgsql.org/efcore/)
2. [ASP.NET Core Razor Pages](https://docs.microsoft.com/aspnet/core/razor-pages)
3. [Repository Pattern in ASP.NET Core](https://codewithmukesh.com/blog/repository-pattern-in-aspnet-core/)
4. [Bootstrap 5 Components](https://getbootstrap.com/docs/5.0/components/)
5. Database Design Best Practices

---

## 🎨 UI/UX Design References

- [Tourism Website Templates](https://www.templatemonster.com/category/travel-website-templates/)
- [Booking.com](https://www.booking.com) - Reference cho booking flow
- [TripAdvisor](https://www.tripadvisor.com) - Reference cho reviews
- [Agoda](https://www.agoda.com) - Reference cho search & filter

---

## ⚠️ Rủi ro & Kế hoạch dự phòng

| Rủi ro | Mức độ | Kế hoạch dự phòng |
|--------|--------|-------------------|
| Database schema phức tạp hơn dự kiến | Cao | Đơn giản hóa, implement từng phần |
| Thiếu kinh nghiệm EF Core | Trung bình | Học qua tutorials, tham khảo docs |
| Frontend mất nhiều thời gian | Trung bình | Sử dụng Bootstrap templates có sẵn |
| Bug trong migrations | Thấp | Backup database, rollback migrations |

---

## 📝 Tiêu chí đánh giá hoàn thành

✅ **Database Schema**:
- [ ] ERD diagram đầy đủ
- [ ] Tất cả relationships được định nghĩa đúng
- [ ] Có indexes cho performance

✅ **Entity Framework Core**:
- [ ] DbContext hoạt động
- [ ] Migrations chạy thành công
- [ ] CRUD operations hoạt động

✅ **Homepage**:
- [ ] Responsive trên mobile/tablet/desktop
- [ ] Load data từ database
- [ ] Navigation hoạt động tốt
- [ ] Performance tốt (< 2s load time)

✅ **Destinations Module**:
- [ ] List view với pagination
- [ ] Detail view đầy đủ thông tin
- [ ] Admin CRUD hoàn chỉnh
- [ ] Form validation đầy đủ
- [ ] Image upload hoạt động

---

## 📞 Câu hỏi cần trao đổi với giảng viên

1. Database schema có cần bao gồm payment gateway integration?
2. Authentication sử dụng ASP.NET Core Identity hay custom?
3. Có cần implement multi-language (Vietnamese/English)?
4. Level phân quyền (roles) cần đến mức nào?

---

## 📅 Kế hoạch tuần 03 (Dự kiến)

1. Module quản lý Tours
2. Module quản lý Accommodations & Restaurants
3. Implement Search & Filter functionality
4. Begin Authentication & Authorization
5. Admin Dashboard (basic)

---

**Người lập kế hoạch**: [Tên sinh viên]  
**Ngày lập**: 16/11/2025  
**Người phê duyệt**: [Giảng viên hướng dẫn]  
**Chữ ký**: _______________

---

## 📌 Notes

*File này sẽ được cập nhật thành báo cáo thực tế vào cuối tuần 02 với:*
- ✅ Công việc đã hoàn thành
- 📊 Thống kê thực tế
- 🤔 Vấn đề gặp phải & Giải pháp
- 📸 Screenshots
- 📝 Nhận xét & Đánh giá
