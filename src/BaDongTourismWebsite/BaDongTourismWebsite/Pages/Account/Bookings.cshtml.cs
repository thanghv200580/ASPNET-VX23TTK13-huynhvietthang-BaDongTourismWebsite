using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaDongTourismWebsite.Pages.Account
{
    public class BookingsModel : PageModel
    {
        private readonly IBookingService _bookingService;
        private readonly ITourService _tourService;

        public BookingsModel(IBookingService bookingService, ITourService tourService)
        {
            _bookingService = bookingService;
            _tourService = tourService;
        }

        public List<BookingWithTour> Bookings { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            // Check if user is logged in
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Vui lòng đăng nhập để xem đơn đặt tour.";
                return RedirectToPage("/Auth/Login", new { returnUrl = "/Account/Bookings" });
            }

            // Get user's bookings
            var bookings = await _bookingService.GetBookingsByUserIdAsync(userId.Value);
            
            // Load tour information for each booking
            foreach (var booking in bookings)
            {
                var tour = await _tourService.GetTourWithDetailsAsync(booking.TourId);
                Bookings.Add(new BookingWithTour
                {
                    Id = booking.Id,
                    BookingCode = booking.BookingCode,
                    UserId = booking.UserId,
                    TourId = booking.TourId,
                    NumberOfPeople = booking.NumberOfPeople,
                    ContactName = booking.ContactName,
                    ContactEmail = booking.ContactEmail,
                    ContactPhone = booking.ContactPhone,
                    Notes = booking.Notes,
                    TotalAmount = booking.TotalAmount,
                    FinalAmount = booking.FinalAmount,
                    BookingDate = booking.BookingDate,
                    ConfirmedDate = booking.ConfirmedDate,
                    CancelledDate = booking.CancelledDate,
                    Status = booking.Status,
                    Tour = tour
                });
            }

            // Sort by booking date descending (newest first)
            Bookings = Bookings.OrderByDescending(b => b.BookingDate).ToList();

            return Page();
        }

        public async Task<IActionResult> OnPostCancelAsync(int id)
        {
            // Check if user is logged in
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Vui lòng đăng nhập để thực hiện thao tác này.";
                return RedirectToPage("/Auth/Login");
            }

            // Get booking
            var booking = await _bookingService.GetBookingByIdAsync(id);
            if (booking == null)
            {
                TempData["ErrorMessage"] = "Không tìm thấy đơn đặt tour.";
                return RedirectToPage();
            }

            // Check if booking belongs to current user
            if (booking.UserId != userId.Value)
            {
                TempData["ErrorMessage"] = "Bạn không có quyền hủy đơn đặt tour này.";
                return RedirectToPage();
            }

            // Check if booking can be cancelled
            if (booking.Status != BookingStatus.Pending)
            {
                TempData["ErrorMessage"] = "Chỉ có thể hủy đơn đặt tour đang chờ xác nhận.";
                return RedirectToPage();
            }

            // Cancel booking
            var result = await _bookingService.CancelBookingAsync(id, "Hủy bởi khách hàng");
            if (result)
            {
                TempData["SuccessMessage"] = "Đã hủy đơn đặt tour thành công.";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể hủy đơn đặt tour. Vui lòng thử lại.";
            }

            return RedirectToPage();
        }

        public class BookingWithTour
        {
            public int Id { get; set; }
            public string BookingCode { get; set; } = string.Empty;
            public int UserId { get; set; }
            public int TourId { get; set; }
            public int NumberOfPeople { get; set; }
            public string ContactName { get; set; } = string.Empty;
            public string ContactEmail { get; set; } = string.Empty;
            public string ContactPhone { get; set; } = string.Empty;
            public string? Notes { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal FinalAmount { get; set; }
            public DateTime BookingDate { get; set; }
            public DateTime? ConfirmedDate { get; set; }
            public DateTime? CancelledDate { get; set; }
            public BookingStatus Status { get; set; }
            public Tour? Tour { get; set; }
        }
    }
}
