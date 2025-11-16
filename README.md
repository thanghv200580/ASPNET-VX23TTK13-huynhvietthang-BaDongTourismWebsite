# Ba Dong Tourism Website

Đồ án phát triển website du lịch Ba Đống - ASP.NET Core

## 👥 Thông tin sinh viên

- **Họ tên**: 
- **MSSV**: 
- **Lớp**: VX23TTK13
- **Giảng viên hướng dẫn**:

## 📋 Mô tả đồ án

Website quản lý và quảng bá du lịch Ba Đống, cung cấp thông tin về:
- Các điểm du lịch, danh lam thắng cảnh
- Dịch vụ lưu trú, ẩm thực
- Đặt tour, quản lý booking
- Thông tin văn hóa, lịch sử địa phương

## 🛠️ Công nghệ sử dụng

- **Backend**: ASP.NET Core 9.0 (Razor Pages)
- **Database**: PostgreSQL 16
- **Frontend**: HTML5, CSS3, Bootstrap 5, jQuery
- **Containerization**: Docker, Docker Compose
- **Version Control**: Git, GitHub

## 📂 Cấu trúc thư mục

```
├── docker/              # Docker configuration
│   ├── docker-compose.yml
│   ├── .env.example
│   └── README.md
├── src/                 # Source code
│   └── BaDongTourismWebsite/
│       └── BaDongTourismWebsite/
│           ├── Pages/   # Razor Pages
│           ├── wwwroot/ # Static files
│           └── Program.cs
├── thesis/             # Tài liệu đồ án
├── progress-report/    # Báo cáo tiến độ
└── README.md
```

## 🚀 Hướng dẫn cài đặt và chạy

### Yêu cầu hệ thống

- .NET SDK 9.0 hoặc cao hơn
- Docker Desktop (nếu chạy với Docker)
- PostgreSQL 16 (nếu chạy local không dùng Docker)

### Cách 1: Chạy với Docker (Khuyến nghị)

```bash
# Clone repository
git clone https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite.git
cd ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite

# Setup environment variables
cd docker
cp .env.example .env
# Chỉnh sửa .env với thông tin của bạn

# Khởi động các services
docker-compose up -d

# Kiểm tra logs
docker-compose logs -f
```

Truy cập: http://localhost:5000

### Cách 2: Chạy local (Development)

```bash
# Clone repository
git clone https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite.git
cd ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite/src/BaDongTourismWebsite/BaDongTourismWebsite

# Restore dependencies
dotnet restore

# Update connection string trong appsettings.json

# Run application
dotnet run
```

Truy cập: https://localhost:5001 hoặc http://localhost:5000

## 📊 Tiến độ thực hiện

### ✅ Đã hoàn thành

- [x] Setup project ASP.NET Core
- [x] Cấu hình Docker, Docker Compose
- [x] Setup PostgreSQL database
- [x] Cấu trúc thư mục dự án
- [x] Template layout cơ bản

### 🔄 Đang thực hiện

- [ ] Thiết kế database schema
- [ ] Implement Entity Framework Core
- [ ] Xây dựng trang chủ
- [ ] Module quản lý điểm du lịch

### 📝 Kế hoạch tiếp theo

- [ ] Module quản lý tour
- [ ] Hệ thống đặt phòng/booking
- [ ] Authentication & Authorization
- [ ] Admin dashboard
- [ ] Tích hợp thanh toán
- [ ] Responsive design
- [ ] Testing & deployment

## 📸 Screenshots

*(Sẽ cập nhật sau)*

## 📖 Tài liệu tham khảo

- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)
- [PostgreSQL Documentation](https://www.postgresql.org/docs/)
- [Docker Documentation](https://docs.docker.com/)
- [Bootstrap 5](https://getbootstrap.com/docs/5.0/)

## 🤝 Đóng góp

Đây là đồ án cá nhân, không nhận pull request từ bên ngoài.

## 📄 License

Đồ án này thuộc về sinh viên và trường đại học. Không sao chép hoặc sử dụng cho mục đích thương mại.

---

**Cập nhật lần cuối**: 9/11/2025
