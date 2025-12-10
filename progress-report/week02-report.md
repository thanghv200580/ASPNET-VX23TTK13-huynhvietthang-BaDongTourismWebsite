# Báo cáo Tuần 02# Báo cáo Tuần 02 - Ba Đống Tourism Website# Báo cáo Tuần 02 - Ba Đống Tourism Website

**Thời gian**: 17/11/2025 - 23/11/2025 **Thời gian**: 17/11/2025 - 23/11/2025 **Thời gian**: 17/11/2025 - 23/11/2025

**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13

**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13

## Mục tiêu

Thiết kế database schema và implement Entity Framework Core---

## Công việc đã hoàn thành## 🎯 Mục tiêu tuần## 🎯 Mục tiêu tuần

- Thiết kế ERD diagram với 15 tables:

  - Users, Roles, UserRolesThiết kế database schema, implement Entity Framework Core, migrations và seed data.Thiết kế database schema, implement Entity Framework Core, migrations và seed data.

  - Destinations, Categories, DestinationImages

  - Tours, TourSchedules, TourDestinations---

  - Bookings, Payments

  - Accommodations, Restaurants, Reviews## ✅ Tasks đã hoàn thành## ✅ Tasks đã hoàn thành

- Cài đặt EF Core packages (Microsoft.EntityFrameworkCore, Npgsql)

- Tạo Entity models (15+ classes) với BaseEntity### 1. Database Schema Design### 1. Database Schema Design

- Tạo ApplicationDbContext với Fluent API

- Initial migration: 20251116134531_InitialCreate- ✅ Thiết kế ERD diagram với 15 tables:

- Update database thành công

- Implement Repository Pattern (IGenericRepository, GenericRepository) - **User Management**: Users, Roles, UserRoles#### Các bảng chính cần thiết kế:

- Implement Unit of Work Pattern

- Tạo DbSeeder với sample data: - **Destinations**: Destinations, Categories, DestinationImages

  - 4 Roles (Admin, Staff, Customer, Guest)

  - 1 Admin user, 6 Categories - **Tours**: Tours, TourSchedules, TourDestinations**a) Quản lý Người dùng**

  - 4 Destinations, 2 Tours

- Password hashing với BCrypt - **Booking**: Bookings, Payments- `Users`: Thông tin người dùng, khách hàng

## Công việc chưa hoàn thành - **Services**: Accommodations, Restaurants, Reviews- `Roles`: Vai trò (Admin, Staff, Customer, Guest)

- Homepage UI

- Destinations public pages - `UserRoles`: Mapping user và role

- Admin dashboard

- Authentication pages- ✅ Define relationships (1-1, 1-n, n-n)

## Kế hoạch tuần tiếp theo- ✅ Primary keys, foreign keys, indexes**b) Quản lý Điểm Du lịch**

- Phát triển Homepage với featured destinations

- Destinations module (Index, Details)- ✅ Soft delete pattern (IsDeleted flag)- `Destinations`: Các điểm du lịch

- Authentication system (Login, Register, Logout)

- Admin Dashboard - Id, Name, Description, Location, Province

- Admin Destinations CRUD

### 2. Entity Framework Core Setup - Images, Rating, Status, CreatedDate

- ✅ Cài đặt NuGet packages:- `DestinationImages`: Hình ảnh điểm du lịch

  - Microsoft.EntityFrameworkCore (9.0)- `Categories`: Loại hình du lịch (biển, núi, văn hóa, lịch sử...)

  - Microsoft.EntityFrameworkCore.Design

  - Npgsql.EntityFrameworkCore.PostgreSQL**c) Quản lý Tour**

  - Microsoft.EntityFrameworkCore.Tools- `Tours`: Thông tin tour du lịch

    - Id, Name, Description, Duration, Price

- ✅ Tạo Entity models (15+ classes): - MaxParticipants, StartDate, EndDate

  - BaseEntity với CreatedDate, UpdatedDate, IsDeleted- `TourSchedules`: Lịch trình chi tiết tour

  - Navigation properties- `TourDestinations`: Các điểm trong tour

  - Data annotations

  **d) Quản lý Booking**

- ✅ ApplicationDbContext:- `Bookings`: Đơn đặt tour/dịch vụ

  - DbSet definitions - Id, UserId, TourId, BookingDate, TotalAmount

  - Fluent API configurations - Status (Pending, Confirmed, Cancelled, Completed)

  - Global query filters (IsDeleted)- `BookingDetails`: Chi tiết đặt chỗ

  - Seeding configuration- `Payments`: Thông tin thanh toán

### 3. Migrations & Database Update**e) Dịch vụ bổ sung**

- ✅ Initial migration: `20251116134531_InitialCreate`- `Accommodations`: Chỗ ở (khách sạn, homestay)

- ✅ Update database thành công- `Restaurants`: Nhà hàng, ẩm thực

- ✅ Verify schema trong PostgreSQL (pgAdmin)- `Services`: Các dịch vụ khác (thuê xe, hướng dẫn viên...)

### 4. Seed Data Implementation**Kết quả mong đợi**:

- ✅ DbSeeder.cs với comprehensive data:- ERD diagram hoàn chỉnh

  - 4 Roles (Admin, Staff, Customer, Guest)- Document mô tả chi tiết các bảng và relationships

  - 1 Admin user (admin@badong.com)

  - 6 Categories (Biển, Núi, Văn hóa, Lịch sử, Ẩm thực, Sinh thái)---

  - 4 Destinations (featured + regular)

  - 2 Tours với pricing & schedules### 2. Cài đặt và cấu hình Entity Framework Core

  **Ước tính thời gian**: 0.5-1 ngày

- ✅ Seed data chạy tự động khi startup

- ✅ Password hashing với BCrypt#### Các bước thực hiện:

### 5. Repository Pattern Implementation1. **Cài đặt NuGet packages**:

- ✅ IGenericRepository interface ```bash

- ✅ GenericRepository implementation với: dotnet add package Microsoft.EntityFrameworkCore

  - GetByIdAsync, GetAllAsync, FindAsync dotnet add package Microsoft.EntityFrameworkCore.Design

  - AddAsync, Update, Delete dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL

  - FirstOrDefaultAsync, AnyAsync dotnet add package Microsoft.EntityFrameworkCore.Tools

    ```

    ```

- ✅ Specialized repositories:

  - IDestinationRepository & DestinationRepository2. **Tạo DbContext**:

  - ITourRepository & TourRepository - File `Data/ApplicationDbContext.cs`

    - Cấu hình connection string

- ✅ UnitOfWork pattern: - Define DbSet cho các entities

  - IUnitOfWork interface

  - UnitOfWork implementation3. **Tạo Entity Models**:

  - Centralized SaveChangesAsync - Folder `Models/Entities/`

  - Implement các entity classes

### 6. Service Layer - Data annotations và Fluent API

- ✅ IDestinationService & DestinationService

- ✅ Business logic separation từ controllers4. **Cấu hình trong Program.cs**:

- ✅ Dependency Injection configuration trong Program.cs - Register DbContext với DI container

  - Configure connection string từ appsettings.json

---

**Kết quả mong đợi**:

## ⏳ Tasks chưa hoàn thành- EF Core được cấu hình và sẵn sàng sử dụng

- Connection đến PostgreSQL thành công

- Homepage UI implementation

- Destinations public pages (Index, Details)---

- Admin pages

- Authentication system### 3. Tạo Migrations và Update Database

- Image upload functionality**Ước tính thời gian**: 0.5 ngày

---#### Các lệnh thực hiện:

## 📊 Database Statistics```bash

# Tạo migration đầu tiên

| Entity | Tables | Relationships |dotnet ef migrations add InitialCreate

|--------|--------|---------------|

| Users & Roles | 3 | 1-n (User-UserRoles) |# Update database

| Destinations | 3 | 1-n (Category-Dest, Dest-Images) |dotnet ef database update

| Tours | 3 | 1-n, n-n |

| Bookings | 2 | 1-n (Booking-Payment) |# Kiểm tra migrations

| Services | 3 | 1-n |dotnet ef migrations list

| **Total** | **15** | **20+** |```

---#### Seed Data (nếu có thời gian):

- Tạo `Data/DbSeeder.cs`

## 📝 Công nghệ đã sử dụng- Seed dữ liệu mẫu cho:

- Admin user

- **ORM**: Entity Framework Core 9.0 - Một số điểm du lịch mẫu

- **Database**: PostgreSQL 16 + Npgsql provider - Categories cơ bản

- **Patterns**: Repository, Unit of Work, Service Layer

- **Security**: BCrypt.Net for password hashing**Kết quả mong đợi**:

- **Migrations**: Code-First approach- Database schema được tạo trong PostgreSQL

- Có dữ liệu mẫu để test

---

---

## 📅 Kế hoạch Tuần 03

### 4. Phát triển Trang chủ (Homepage)

1. **Homepage Development**:**Ước tính thời gian**: 1-2 ngày

   - Hero section với featured destinations

   - Popular tours section#### Các components cần thiết:

   - Services overview

   - Testimonials**a) Header/Navigation**

   - Logo website

2. **Destinations Module**:- Menu chính (Trang chủ, Điểm du lịch, Tours, Về chúng tôi, Liên hệ)

   - Public pages: Index (với pagination), Details- Search bar

   - Search & filter functionality- User menu (Login/Register)

   - Category filtering

   **b) Hero Section**

3. **Authentication System**:- Banner slider với hình ảnh đẹp Ba Đống

   - Login page- Call-to-action button

   - Register page- Search box tour nhanh

   - Session-based authentication

   - Role-based authorization**c) Featured Destinations**

   - Hiển thị 6-8 điểm du lịch nổi bật

4. **Admin Dashboard**:- Card layout với image, title, short description

   - Statistics cards (destinations, tours, users, bookings)- Link đến trang chi tiết

   - Recent activity

   - Quick actions**d) Popular Tours**

   - Danh sách 4-6 tour phổ biến

5. **Admin Destinations CRUD**:- Hiển thị: giá, thời gian, số chỗ còn trống

   - Index với DataTable- Button "Đặt tour"

   - Create page với form validation

   - Edit page**e) Services Section**

   - Delete (soft delete)- Icons và mô tả các dịch vụ (Tour, Khách sạn, Nhà hàng, Vận chuyển)

---**f) Testimonials (nếu có thời gian)**

- Đánh giá từ khách hàng

**Ngày báo cáo**: 23/11/2025

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

| STT | Deliverable                   | Trạng thái dự kiến |
| --- | ----------------------------- | ------------------ |
| 1   | ERD Database Schema           | 🟡 Hoàn thành      |
| 2   | Entity Models (10+ classes)   | 🟡 Hoàn thành      |
| 3   | DbContext & Configuration     | 🟡 Hoàn thành      |
| 4   | Database Migrations           | 🟡 Hoàn thành      |
| 5   | Homepage (7+ sections)        | 🟡 Hoàn thành      |
| 6   | Destinations Module (5 pages) | 🟡 Hoàn thành      |
| 7   | Seed Data                     | 🟡 Hoàn thành      |
| 8   | Unit Tests (nếu có thời gian) | 🟠 Optional        |

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

| Rủi ro                               | Mức độ     | Kế hoạch dự phòng                    |
| ------------------------------------ | ---------- | ------------------------------------ |
| Database schema phức tạp hơn dự kiến | Cao        | Đơn giản hóa, implement từng phần    |
| Thiếu kinh nghiệm EF Core            | Trung bình | Học qua tutorials, tham khảo docs    |
| Frontend mất nhiều thời gian         | Trung bình | Sử dụng Bootstrap templates có sẵn   |
| Bug trong migrations                 | Thấp       | Backup database, rollback migrations |

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
**Chữ ký**: **\*\***\_\_\_**\*\***

---

## 📌 Notes

_File này sẽ được cập nhật thành báo cáo thực tế vào cuối tuần 02 với:_

- ✅ Công việc đã hoàn thành
- 📊 Thống kê thực tế
- 🤔 Vấn đề gặp phải & Giải pháp
- 📸 Screenshots
- 📝 Nhận xét & Đánh giá
