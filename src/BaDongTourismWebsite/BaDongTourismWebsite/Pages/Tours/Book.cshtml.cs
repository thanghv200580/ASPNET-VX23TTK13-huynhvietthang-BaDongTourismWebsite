using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BaDongTourismWebsite.Pages.Tours
{
    public class BookModel : PageModel
    {
        private readonly ITourService _tourService;
        private readonly IBookingService _bookingService;

        public BookModel(ITourService tourService, IBookingService bookingService)
        {
            _tourService = tourService;
            _bookingService = bookingService;
        }

        public Tour? Tour { get; set; }
        
        [BindProperty]
        public BookingInputModel Booking { get; set; } = new();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Check if user is logged in
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Vui lòng đăng nhập để đặt tour.";
                return RedirectToPage("/Auth/Login", new { returnUrl = $"/Tours/Book?id={id}" });
            }

            if (!id.HasValue)
            {
                return NotFound();
            }

            Tour = await _tourService.GetTourWithDetailsAsync(id.Value);
            
            if (Tour == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            // Check if user is logged in
            var userId = HttpContext.Session.GetInt32("UserId");
            if (!userId.HasValue)
            {
                TempData["ErrorMessage"] = "Vui lòng đăng nhập để đặt tour.";
                return RedirectToPage("/Auth/Login");
            }

            if (!id.HasValue)
            {
                return NotFound();
            }

            Tour = await _tourService.GetTourWithDetailsAsync(id.Value);
            
            if (Tour == null)
            {
                return NotFound();
            }

            // Validate number of people
            if (Booking.NumberOfPeople < 1 || Booking.NumberOfPeople > Tour.MaxParticipants)
            {
                ModelState.AddModelError("Booking.NumberOfPeople", 
                    $"Số người phải từ 1 đến {Tour.MaxParticipants}");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Create booking entity
                var booking = new Booking
                {
                    UserId = userId.Value,
                    TourId = Tour.Id,
                    NumberOfPeople = Booking.NumberOfPeople,
                    ContactName = Booking.ContactName,
                    ContactEmail = Booking.ContactEmail,
                    ContactPhone = Booking.ContactPhone,
                    Notes = Booking.Notes,
                    TotalAmount = Booking.TotalAmount,
                    FinalAmount = Booking.FinalAmount,
                    BookingDate = DateTime.UtcNow,
                    Status = BookingStatus.Pending
                };

                // Generate booking code
                booking.BookingCode = _bookingService.GenerateBookingCode();

                // Save booking (service will ensure UTC dates)
                await _bookingService.CreateBookingAsync(booking);

                TempData["SuccessMessage"] = "Đặt tour thành công! Mã đặt tour của bạn là: " + booking.BookingCode;
                return RedirectToPage("/Account/Bookings");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi đặt tour: " + ex.Message;
                return Page();
            }
        }

        public class BookingInputModel
        {
            public string ContactName { get; set; } = string.Empty;
            public string ContactEmail { get; set; } = string.Empty;
            public string ContactPhone { get; set; } = string.Empty;
            public int NumberOfPeople { get; set; } = 1;
            public string? Notes { get; set; }
            public decimal TotalAmount { get; set; }
            public decimal FinalAmount { get; set; }
        }
    }
}
