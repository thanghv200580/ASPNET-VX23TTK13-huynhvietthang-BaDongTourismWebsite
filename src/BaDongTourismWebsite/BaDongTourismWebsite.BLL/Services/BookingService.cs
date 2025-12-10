using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaDongTourismWebsite.BLL.Services;

public class BookingService : IBookingService
{
    private readonly IUnitOfWork _unitOfWork;

    public BookingService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IEnumerable<Booking>> GetAllBookingsAsync()
    {
        return await _unitOfWork.Repository<Booking>()
            .FindAsync(b => true);
    }

    public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
    {
        return await _unitOfWork.Repository<Booking>()
            .FindAsync(b => b.UserId == userId);
    }

    public async Task<IEnumerable<Booking>> GetBookingsByTourIdAsync(int tourId)
    {
        return await _unitOfWork.Repository<Booking>()
            .FindAsync(b => b.TourId == tourId);
    }

    public async Task<Booking?> GetBookingByIdAsync(int id)
    {
        return await _unitOfWork.Repository<Booking>().GetByIdAsync(id);
    }

    public async Task<Booking?> GetBookingByCodeAsync(string bookingCode)
    {
        return await _unitOfWork.Repository<Booking>()
            .FirstOrDefaultAsync(b => b.BookingCode == bookingCode);
    }

    public async Task<Booking> CreateBookingAsync(Booking booking)
    {
        // Don't override booking code if already set
        if (string.IsNullOrEmpty(booking.BookingCode))
        {
            booking.BookingCode = GenerateBookingCode();
        }
        
        // Ensure all DateTime values are UTC
        booking.BookingDate = DateTime.UtcNow;
        booking.Status = BookingStatus.Pending;
        booking.CreatedDate = DateTime.UtcNow;

        await _unitOfWork.Repository<Booking>().AddAsync(booking);
        await _unitOfWork.SaveChangesAsync();
        return booking;
    }

    public async Task<bool> ConfirmBookingAsync(int bookingId)
    {
        var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
        if (booking == null || booking.Status != BookingStatus.Pending)
            return false;

        booking.Status = BookingStatus.Confirmed;
        booking.ConfirmedDate = DateTime.UtcNow;
        booking.UpdatedDate = DateTime.UtcNow;

        _unitOfWork.Repository<Booking>().Update(booking);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CancelBookingAsync(int bookingId, string? reason)
    {
        var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
        if (booking == null)
            return false;

        booking.Status = BookingStatus.Cancelled;
        booking.CancelledDate = DateTime.UtcNow;
        booking.UpdatedDate = DateTime.UtcNow;
        if (!string.IsNullOrEmpty(reason))
        {
            booking.Notes = (booking.Notes ?? "") + $"\nLý do hủy: {reason}";
        }

        _unitOfWork.Repository<Booking>().Update(booking);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public async Task<bool> CompleteBookingAsync(int bookingId)
    {
        var booking = await _unitOfWork.Repository<Booking>().GetByIdAsync(bookingId);
        if (booking == null || booking.Status != BookingStatus.Confirmed)
            return false;

        booking.Status = BookingStatus.Completed;
        booking.UpdatedDate = DateTime.UtcNow;

        _unitOfWork.Repository<Booking>().Update(booking);
        await _unitOfWork.SaveChangesAsync();
        return true;
    }

    public string GenerateBookingCode()
    {
        return $"BK{DateTime.UtcNow:yyyyMMddHHmmss}{new Random().Next(1000, 9999)}";
    }
}
