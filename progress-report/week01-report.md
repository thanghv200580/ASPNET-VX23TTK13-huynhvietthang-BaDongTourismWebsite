# Báo cáo tuần 01 - Week 01 Report

**Thời gian**: Tuần 1 (9/11/2025 - 16/11/2025)  
**Sinh viên**: [Tên sinh viên] - [MSSV]  
**Lớp**: VX23TTK13

---

## 📌 Mục tiêu tuần 01

Khởi tạo dự án, thiết lập môi trường phát triển và cấu hình các công cụ cần thiết cho đồ án Website Du lịch Ba Đống.

---

## ✅ Công việc đã hoàn thành

### 1. Khởi tạo dự án ASP.NET Core
- Tạo project ASP.NET Core 9.0 với Razor Pages
- Cấu hình cấu trúc thư mục cơ bản:
  - `Pages/`: Razor Pages (Index, Privacy, Error)
  - `wwwroot/`: Static files (CSS, JS, images)
  - `Properties/`: Launch settings
- Thiết lập `appsettings.json` và `appsettings.Development.json`
- Files: `Program.cs`, `.csproj`

**Kết quả**: Project chạy thành công trên localhost với template mặc định.

### 2. Cấu hình Git & GitHub Repository
- Tạo GitHub repository: `ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite`
- Tạo file `.gitignore` để loại trừ:
  - Build artifacts (`bin/`, `obj/`)
  - IDE files (`.vs/`, `.vscode/`, `.idea/`)
  - OS files (`.DS_Store`, `Thumbs.db`)
  - Secrets và environment variables
- Commit và push code lên GitHub
- Tạo file `README.md` với thông tin dự án

**Kết quả**: Source code được quản lý tập trung trên GitHub.

### 3. Setup Docker & Docker Compose
- Tạo `Dockerfile` cho ASP.NET application:
  - Multi-stage build (build → publish → runtime)
  - Base image: .NET 9.0 SDK & Runtime
  - Expose port 5000
- Tạo `docker-compose.yml` với các services:
  - **PostgreSQL 16**: Database server (port 5432)
  - **Web App**: ASP.NET Core application (port 5000)
  - Cấu hình networks và volumes
  - Health check cho PostgreSQL
- Tạo file `.env` và `.env.example` cho environment variables
- Viết `docker/README.md` hướng dẫn sử dụng Docker

**Kết quả**: Có thể chạy toàn bộ ứng dụng với lệnh `docker-compose up -d`.

### 4. Cấu hình PostgreSQL Database
- Sử dụng PostgreSQL 16 Alpine image
- Cấu hình:
  - Database: `badong_tourism_db`
  - User: `badong_admin`
  - Port: 5432
  - Persistent volume: `postgres_data`
- Connection string được cấu hình tự động trong docker-compose

**Kết quả**: Database sẵn sàng để phát triển các module tiếp theo.

### 5. Template Layout cơ bản
- Sử dụng layout mặc định từ ASP.NET Core template
- Cấu hình `_Layout.cshtml` với Bootstrap 5
- Thêm `_ValidationScriptsPartial.cshtml`
- Cấu hình CSS và JS cơ bản trong `wwwroot/`

**Kết quả**: Có layout cơ bản để bắt đầu phát triển các trang.

### 6. Tổ chức cấu trúc thư mục dự án
```
├── docker/              # Docker configuration
├── src/                 # Source code
├── thesis/             # Tài liệu đồ án
├── progress-report/    # Báo cáo tiến độ
├── setup/              # Setup files
└── README.md           # Documentation
```

**Kết quả**: Dự án có cấu trúc rõ ràng, dễ quản lý.

---

## 📊 Thống kê công việc

| Hạng mục | Số lượng | Trạng thái |
|----------|----------|------------|
| Files đã tạo | 20+ | ✅ Hoàn thành |
| Docker services | 2 (PostgreSQL, Web) | ✅ Hoàn thành |
| Git commits | [số commits] | ✅ Hoàn thành |
| Documentation files | 3 (README.md x3) | ✅ Hoàn thành |

---

## 🎯 Kết quả đạt được

✅ Môi trường phát triển hoàn chỉnh  
✅ Source code được quản lý trên GitHub  
✅ Docker setup sẵn sàng cho development và deployment  
✅ PostgreSQL database đã cấu hình  
✅ Project structure rõ ràng và chuẩn  

---

## 🔧 Công cụ & Công nghệ đã sử dụng

- **IDE**: Visual Studio Code, Rider (hoặc Visual Studio)
- **Language**: C# (.NET 9.0)
- **Framework**: ASP.NET Core 9.0 (Razor Pages)
- **Database**: PostgreSQL 16
- **Containerization**: Docker, Docker Compose
- **Version Control**: Git, GitHub
- **Frontend**: Bootstrap 5, jQuery

---

## 📸 Screenshots

### 1. Project Structure
*(Screenshot của cấu trúc thư mục trong IDE)*

### 2. Application Running
*(Screenshot của ứng dụng chạy trên localhost:5000)*

### 3. Docker Containers
*(Screenshot của `docker-compose ps` hoặc Docker Desktop)*

---

## 🤔 Vấn đề gặp phải & Giải pháp

### Vấn đề 1: [Nếu có]
**Mô tả**: ...  
**Giải pháp**: ...  
**Kết quả**: ...

*(Thêm các vấn đề khác nếu có)*

---

## 📝 Nhận xét & Đánh giá

### Điểm mạnh
- Setup nhanh chóng và đầy đủ
- Sử dụng Docker giúp môi trường nhất quán
- Documentation rõ ràng
- Git workflow tốt

### Điểm cần cải thiện
- Chưa có database schema cụ thể
- Chưa có UI/UX design
- Chưa implement authentication

---

## 📅 Kế hoạch tuần 02

1. Thiết kế database schema cho các entities chính
2. Implement Entity Framework Core
3. Tạo migrations cho database
4. Bắt đầu phát triển trang chủ với UI mới
5. Nghiên cứu và thiết kế module quản lý điểm du lịch

---

**Người báo cáo**: [Tên sinh viên]  
**Ngày báo cáo**: 16/11/2025  
**Chữ ký**: _______________
