# Báo cáo Tuần 01# Báo cáo Tuần 01 - Ba Đống Tourism Website# Báo cáo Tuần 01 - Ba Đống Tourism Website

**Thời gian**: 9/11/2025 - 16/11/2025 **Thời gian**: 9/11/2025 - 16/11/2025 **Thời gian**: 9/11/2025 - 16/11/2025

**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13

**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13

## Mục tiêu

Khởi tạo dự án và setup môi trường phát triển---

## Công việc đã hoàn thành## 🎯 Mục tiêu tuần## 🎯 Mục tiêu tuần

- Tạo ASP.NET Core 9.0 Razor Pages project

- Setup Git & GitHub repositoryKhởi tạo dự án, setup môi trường phát triển và cấu hình Docker environment.Khởi tạo dự án, setup môi trường phát triển và cấu hình Docker environment.

- Cấu hình Docker Compose (PostgreSQL 16 + Web app)

- Cấu hình database connection string---

- Bootstrap 5 integration

- Tạo project structure (Pages/, wwwroot/, docker/)## ✅ Tasks đã hoàn thành## ✅ Tasks đã hoàn thành

## Công việc chưa hoàn thành### 1. Project Initialization### 1. Project Setup

- Database schema design

- Entity Framework Core setup- ✅ Tạo ASP.NET Core 9.0 Razor Pages project- ✅ Tạo ASP.NET Core 9.0 Razor Pages project

- Authentication system

- ✅ Cấu hình project structure (Pages/, wwwroot/, Properties/)- ✅ Cấu hình structure: `Pages/`, `wwwroot/`, `Properties/`

## Kế hoạch tuần tiếp theo

- Thiết kế ERD diagram với 15 tables- ✅ Setup appsettings.json và Program.cs- ✅ Setup `appsettings.json` và `Program.cs`

- Implement Entity Framework Core

- Tạo migrations và seed data- ✅ Bootstrap 5 template integration- ✅ Bootstrap 5 template integration

- Phát triển Homepage

### 2. Git & Version Control### 2. Git & GitHub

- ✅ Tạo GitHub repository: `ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite`- ✅ Tạo repository: `ASPNET-VX23TTK13-huynhvietthang-BaDongTourismWebsite`

- ✅ Cấu hình .gitignore (bin/, obj/, .vs/, .idea/, .DS_Store)- ✅ Cấu hình `.gitignore` (bin/, obj/, .vs/, .DS_Store)

- ✅ Initial commit và push lên GitHub- ✅ Push code lên GitHub với README.md

- ✅ Tạo README.md với project overview

### 3. Docker Configuration

### 3. Docker Setup- ✅ Dockerfile với multi-stage build (.NET 9.0 SDK/Runtime)

- ✅ Dockerfile với multi-stage build (.NET 9.0 SDK/Runtime)- ✅ `docker-compose.yml`:

- ✅ docker-compose.yml với 2 services: - PostgreSQL 16 (port 5432)

  - PostgreSQL 16 Alpine (port 5432) - ASP.NET app (port 5000)

  - ASP.NET Core app (port 5000) - Volumes và networks

- ✅ Configuration: networks, volumes, health checks- ✅ Files: `.env`, `.env.example`, `docker/README.md`

- ✅ Environment variables (.env, .env.example)

### 4. PostgreSQL Setup

### 4. Database Configuration- ✅ Database: `badong_tourism_db`

- ✅ PostgreSQL 16 trong Docker- ✅ User: `badong_admin`

- ✅ Database: `badong_tourism_db`- ✅ Persistent volume: `postgres_data`

- ✅ User: `badong_admin`- ✅ Connection string configured

- ✅ Persistent volume: `postgres_data`

- ✅ Connection string configured### 5. Project Structure

````

### 5. Project Structure├── docker/              # Docker configs

```├── src/                 # Source code

├── docker/              # Docker configs├── thesis/             # Báo cáo đồ án

├── src/                 # Source code├── progress-report/    # Weekly reports

├── thesis/             # Báo cáo đồ án└── README.md

├── progress-report/    # Weekly reports```

├── setup/              # Setup scripts

└── README.md---

````

## ⏳ Tasks chưa hoàn thành

---

- ⏳ Database schema design

## ⏳ Tasks chưa hoàn thành- ⏳ Entity Framework Core setup

- ⏳ UI/UX design cho homepage

- Database schema design (ERD)- ⏳ Authentication system

- Entity Framework Core setup

- Migrations & seed data---

- Homepage UI design

- Authentication system## � Công nghệ sử dụng

---- **Backend**: ASP.NET Core 9.0, C#

- **Database**: PostgreSQL 16 (Docker)

## 📝 Công nghệ đã sử dụng- **Frontend**: Bootstrap 5, jQuery

- **Tools**: Visual Studio Code/Rider, Git, Docker

- **Backend**: ASP.NET Core 9.0, C#

- **Database**: PostgreSQL 16 (Docker)---

- **Frontend**: Bootstrap 5, jQuery

- **DevOps**: Docker, Docker Compose## 📅 Kế hoạch Tuần 02

- **Version Control**: Git, GitHub

- **IDE**: Visual Studio Code / Rider1. Thiết kế database schema (ERD diagram)

2. Implement Entity Framework Core + Migrations

---3. Tạo seed data mẫu

4. Phát triển Homepage với featured destinations

## 📅 Kế hoạch Tuần 025. Bắt đầu module Quản lý Điểm du lịch (Destinations CRUD)

1. Thiết kế database schema (ERD diagram) cho 10+ entities---

2. Implement Entity Framework Core với Npgsql provider

3. Tạo Entity models và DbContext**Ngày báo cáo**: 16/11/2025

4. Initial migration và update database
5. Seed data mẫu (roles, users, categories, destinations, tours)
6. Phát triển Homepage với featured destinations section
7. Bắt đầu module Destinations (List view với pagination)

---

**Ngày báo cáo**: 16/11/2025
