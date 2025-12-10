using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BaDongTourismWebsite.BLL.Services;
using BaDongTourismWebsite.Entity.Entities;
using BaDongTourismWebsite.DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourismWebsite.Pages.Admin.Bookings;

public class IndexModel : PageModel
{
    private readonly IBookingService _bookingService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(
        IBookingService bookingService,
        IUnitOfWork unitOfWork,
        ILogger<IndexModel> logger)
    {
        _bookingService = bookingService;
        _unitOfWork = unitOfWork;
        _logger = logger;
    }

    public List<BookingWithTour> Bookings { get; set; } = new();

    public async Task OnGetAsync()
    {
        try
        {
            var bookings = await _bookingService.GetAllBookingsAsync();
            
            // Load related tour data
            Bookings = new List<BookingWithTour>();
            foreach (var booking in bookings.OrderByDescending(b => b.BookingDate))
            {
                var tour = await _unitOfWork.Tours.GetByIdAsync(booking.TourId);
                Bookings.Add(new BookingWithTour
                {
                    Id = booking.Id,
                    BookingCode = booking.BookingCode,
                    BookingDate = booking.BookingDate,
                    NumberOfPeople = booking.NumberOfPeople,
                    FinalAmount = booking.FinalAmount,
                    Status = booking.Status,
                    ContactName = booking.ContactName,
                    ContactEmail = booking.ContactEmail,
                    ContactPhone = booking.ContactPhone,
                    TourId = booking.TourId,
                    Tour = tour
                });
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error loading bookings");
        }
    }

    public async Task<IActionResult> OnPostConfirmAsync(int id)
    {
        try
        {
            var result = await _bookingService.ConfirmBookingAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Đã xác nhận đơn đặt tour thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể xác nhận đơn đặt tour này.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error confirming booking {BookingId}", id);
            TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xác nhận đơn đặt tour.";
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCancelAsync(int id)
    {
        try
        {
            var result = await _bookingService.CancelBookingAsync(id, "Hủy bởi quản trị viên");
            if (result)
            {
                TempData["SuccessMessage"] = "Đã hủy đơn đặt tour thành công!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể hủy đơn đặt tour này.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error cancelling booking {BookingId}", id);
            TempData["ErrorMessage"] = "Đã xảy ra lỗi khi hủy đơn đặt tour.";
        }

        return RedirectToPage();
    }

    public async Task<IActionResult> OnPostCompleteAsync(int id)
    {
        try
        {
            var result = await _bookingService.CompleteBookingAsync(id);
            if (result)
            {
                TempData["SuccessMessage"] = "Đã đánh dấu đơn đặt tour hoàn thành!";
            }
            else
            {
                TempData["ErrorMessage"] = "Không thể hoàn thành đơn đặt tour này.";
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error completing booking {BookingId}", id);
            TempData["ErrorMessage"] = "Đã xảy ra lỗi khi hoàn thành đơn đặt tour.";
        }

        return RedirectToPage();
    }

    public class BookingWithTour
    {
        public int Id { get; set; }
        public string BookingCode { get; set; } = string.Empty;
        public DateTime BookingDate { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal FinalAmount { get; set; }
        public BookingStatus Status { get; set; }
        public string ContactName { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public int TourId { get; set; }
        public Tour? Tour { get; set; }
    }
}
