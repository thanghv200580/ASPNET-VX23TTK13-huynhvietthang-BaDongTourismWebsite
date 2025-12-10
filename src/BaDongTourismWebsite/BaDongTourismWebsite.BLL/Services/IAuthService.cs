using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public interface IAuthService
{
    Task<User?> LoginAsync(string email, string password);
    Task<User?> RegisterAsync(string fullName, string email, string phoneNumber, string password);
    Task<bool> EmailExistsAsync(string email);
    string HashPassword(string password);
    bool VerifyPassword(string password, string hash);
    Task<IReadOnlyList<string>> GetUserRolesAsync(int userId);
}

