# Ba Đống Tourism Website# Ba Dong Tourism Website

Website quản lý và đặt tour du lịch Ba Đống - ASP.NET Core 9.0Đồ án phát triển website du lịch Ba Đống - ASP.NET Core

## 📋 Giới thiệu## 👥 Thông tin sinh viên

- **Họ tên**: Huỳnh Việt Thắng
- **MSSV**: 470123183
- **Giảng viên hướng dẫn**: Thầy TS. Đoàn Phước Miền
- **Lớp**: VX23TTK13

Website du lịch Ba Đống cung cấp các tính năng:

- **Khách hàng**: Xem điểm du lịch, tours, đặt tour online, quản lý booking

- **Admin**: Quản lý destinations, tours, bookings, users

- **Authentication**: Đăng ký, đăng nhập với phân quyền (Admin/Customer)

## 🛠️ Công nghệ## 📋 Mô tả đồ án

- **Backend**: ASP.NET Core 9.0 (Razor Pages)Website quản lý và quảng bá du lịch Ba Đống, cung cấp thông tin về:

- **Database**: PostgreSQL 16- Các điểm du lịch, danh lam thắng cảnh

- **Frontend**: Bootstrap 5, jQuery, Font Awesome- Dịch vụ lưu trú, ẩm thực

- **DevOps**: Docker, Docker Compose- Đặt tour, quản lý booking

- Thông tin văn hóa, lịch sử địa phương

## 🚀 Hướng dẫn chạy dự án

## 🛠️ Công nghệ sử dụng

### Bước 1: Cài đặt môi trường

- **Backend**: ASP.NET Core 9.0 (Razor Pages)

#### 1.1. Cài đặt Docker Desktop- **Database**: PostgreSQL 16

- **Windows/Mac**: Tải và cài đặt từ [Docker Desktop](https://www.docker.com/products/docker-desktop)- **Frontend**: HTML5, CSS3, Bootstrap 5, jQuery

- **Linux**: - **Containerization**: Docker, Docker Compose

  ````bash- **Version Control**: Git, GitHub

  # Ubuntu/Debian

  sudo apt update## 📂 Cấu trúc thư mục

  sudo apt install docker.io docker-compose

  sudo systemctl start docker```

  sudo systemctl enable docker├── docker/              # Docker configuration

  ```│   ├── docker-compose.yml
  ````

│ ├── .env.example

#### 1.2. Cài đặt .NET 9 SDK│ └── README.md

- Tải và cài đặt từ [.NET 9 Download](https://dotnet.microsoft.com/download/dotnet/9.0)├── src/ # Source code

- Verify cài đặt:│ └── BaDongTourismWebsite/

  ````bash│ └── BaDongTourismWebsite/

  dotnet --version│           ├── Pages/   # Razor Pages

  # Output: 9.0.x│           ├── wwwroot/ # Static files

  ```│           └── Program.cs
  ````

├── thesis/ # Tài liệu đồ án

### Bước 2: Clone repository├── progress-report/ # Báo cáo tiến độ

└── README.md

`bash`

git clone https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite.git

cd "ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite"## 🚀 Hướng dẫn cài đặt và chạy

````

### Yêu cầu hệ thống

### Bước 3: Chạy Docker Compose (Database)

- .NET SDK 9.0 hoặc cao hơn

```bash- Docker Desktop (nếu chạy với Docker)

# Di chuyển vào thư mục docker- PostgreSQL 16 (nếu chạy local không dùng Docker)

cd docker

### Cách 1: Chạy với Docker (Khuyến nghị)

# Khởi động PostgreSQL container

docker-compose up -d```bash

# Clone repository

# Kiểm tra container đang chạygit clone https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite.git

docker pscd ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite

# Sẽ thấy container postgres chạy trên port 5432

# Setup environment variables

# (Optional) Xem logscd docker

docker-compose logs -f postgrescp .env.example .env

```# Chỉnh sửa .env với thông tin của bạn



### Bước 4: Cài đặt certificate HTTPS# Khởi động các services

docker-compose up -d

```bash

# Trust development certificate# Kiểm tra logs

dotnet dev-certs https --trustdocker-compose logs -f

````

Nhấn **Yes** khi được hỏi để tin tưởng certificate.Truy cập: http://localhost:5000

### Bước 5: Update database### Cách 2: Chạy local (Development)

`bash`bash

# Di chuyển vào thư mục project# Clone repository

cd ../src/BaDongTourismWebsite/BaDongTourismWebsitegit clone https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite.git

cd ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite/src/BaDongTourismWebsite/BaDongTourismWebsite

# Restore packages

dotnet restore# Restore dependencies

dotnet restore

# Apply migrations và update database

dotnet ef database update# Update connection string trong appsettings.json

# Seed data sẽ tự động chạy khi app start# Run application

```dotnet run

```

### Bước 6: Chạy ứng dụng HTTPS

Truy cập: https://localhost:5001 hoặc http://localhost:5000

````bash

# Chạy với HTTPS profile## 📊 Tiến độ thực hiện

dotnet run --launch-profile https

### ✅ Đã hoàn thành

# Hoặc chỉ chạy thông thường (mặc định HTTPS)

dotnet run- [x] Setup project ASP.NET Core

```- [x] Cấu hình Docker, Docker Compose

- [x] Setup PostgreSQL database

Ứng dụng sẽ chạy tại:- [x] Cấu trúc thư mục dự án

- **HTTPS**: https://localhost:7069- [x] Template layout cơ bản

- **HTTP**: http://localhost:5040

### 🔄 Đang thực hiện

## 👤 Tài khoản demo

- [ ] Thiết kế database schema

### Admin- [ ] Implement Entity Framework Core

- **Email**: admin@badong.com- [ ] Xây dựng trang chủ

- **Password**: Admin@123- [ ] Module quản lý điểm du lịch



### Customer### 📝 Kế hoạch tiếp theo

- **Email**: nguyenvanan@example.com

- **Password**: Customer@123- [ ] Module quản lý tour

- [ ] Hệ thống đặt phòng/booking

## 📂 Cấu trúc dự án- [ ] Authentication & Authorization

- [ ] Admin dashboard

```- [ ] Tích hợp thanh toán

├── docker/- [ ] Responsive design

│   └── docker-compose.yml          # PostgreSQL container- [ ] Testing & deployment

├── src/BaDongTourismWebsite/

│   ├── BaDongTourismWebsite/       # Main web app## 📸 Screenshots

│   │   ├── Pages/                  # Razor Pages (UI)

│   │   ├── wwwroot/               # Static files (CSS, JS)*(Sẽ cập nhật sau)*

│   │   └── Program.cs             # App configuration

│   ├── BaDongTourismWebsite.BLL/  # Business Logic Layer (Services)## 📖 Tài liệu tham khảo

│   ├── BaDongTourismWebsite.DAL/  # Data Access Layer (Repositories)

│   └── BaDongTourismWebsite.Entity/ # Entity models- [ASP.NET Core Documentation](https://docs.microsoft.com/aspnet/core)

├── progress-report/                # Weekly reports- [PostgreSQL Documentation](https://www.postgresql.org/docs/)

└── thesis/                        # Thesis documentation- [Docker Documentation](https://docs.docker.com/)

```- [Bootstrap 5](https://getbootstrap.com/docs/5.0/)



## ✨ Tính năng chính## 🤝 Đóng góp



### Khách hàng (Customer)Đây là đồ án cá nhân, không nhận pull request từ bên ngoài.

- Xem danh sách điểm du lịch với filter, search, pagination

- Xem chi tiết điểm du lịch và reviews## 📄 License

- Xem danh sách tours và chi tiết tour

- Đặt tour với form validationĐồ án này thuộc về sinh viên và trường đại học. Không sao chép hoặc sử dụng cho mục đích thương mại.

- Xem lịch sử booking

- Hủy booking (status Pending)---


- **Sinh viên**: Huỳnh Việt Thắng - 470123183
- **Lớp**: VX23TTK13
- **GitHub**: https://github.com/thanghv200580/ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite

---

**Last Updated**: 14/12/2025
````
