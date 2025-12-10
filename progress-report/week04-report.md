# Báo cáo Tuần 04

**Thời gian**: 1/12/2025 - 7/12/2025  
**Sinh viên**: Huỳnh Việt Thắng - VX23TTK13

## Mục tiêu

Tour & Booking management, bug fixes và viết báo cáo Chương 3

## Công việc đã hoàn thành

- **Tour Management**:
  - ITourService & TourService (CRUD operations)
  - IBookingService & BookingService (status workflow)
  - Admin/Tours/Index: List tours với formatted images
  - Admin/Tours/Create: Form với image preview
  - Booking code generation: BKyyyyMMddHHmmssxxxx
- **Booking Management**:
  - Admin/Bookings/Index: Quản lý đơn với status badges
  - Actions: Confirm, Cancel, Complete
  - Status transitions: Pending → Confirmed → Completed
- **Customer Booking Flow**:
  - Tours/Details: Xem chi tiết tour với "Book Now" button
  - Tours/Book: Form đặt tour với real-time price calculation
  - Account/Bookings: Lịch sử đặt tour, cancel pending bookings
- **Bug Fixes**:
  - DateTime UTC issue: Convert DateTime.Kind.Unspecified → UTC
  - Image formatting: CSS cho admin-table-img (60x60px, hover effects)
  - DI Registration: ITourService, IBookingService
- **Báo cáo Chương 3**:
  - 3.1 Mô tả bài toán
  - 3.2 Yêu cầu chức năng (15+ requirements)
  - 3.3 Mô hình CSDL (ERD diagram + mô tả tables)
  - 3.4 Kiến trúc hệ thống (layered + deployment)

## Công việc chưa hoàn thành

- Tour Edit/Delete pages
- Payment integration
- Email notifications
- Báo cáo Chương 4
- Unit tests

## Kế hoạch tuần tiếp theo

- Hoàn thiện Chương 3 (Use case/DFD, screenshots)
- Viết Chương 4: Kết quả nghiên cứu
- Hoàn thiện Admin CRUD (Tour Edit/Delete)
- Testing end-to-end
- Demo preparation
