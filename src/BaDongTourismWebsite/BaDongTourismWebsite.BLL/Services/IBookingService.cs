using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface IBookingService
{
    Task<IEnumerable<Booking>> GetAllBookingsAsync();
    Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
    Task<IEnumerable<Booking>> GetBookingsByTourIdAsync(int tourId);
    Task<Booking?> GetBookingByIdAsync(int id);
    Task<Booking?> GetBookingByCodeAsync(string bookingCode);
    Task<Booking> CreateBookingAsync(Booking booking);
    Task<bool> ConfirmBookingAsync(int bookingId);
    Task<bool> CancelBookingAsync(int bookingId, string? reason);
    Task<bool> CompleteBookingAsync(int bookingId);
    string GenerateBookingCode();
}
