using System.Linq;
using System.Security.Cryptography;
using System.Text;
using BaDongTourismWebsite.DAL.UnitOfWork;
using BaDongTourismWebsite.Entity.Entities;

namespace BaDongTourismWebsite.BLL.Services;

public class AuthService : IAuthService
{
    private readonly IUnitOfWork _unitOfWork;

    public AuthService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<User?> LoginAsync(string email, string password)
    {
        var user = await _unitOfWork.Repository<User>()
            .FirstOrDefaultAsync(u => u.Email == email && u.IsActive);

        if (user == null)
        {
            return null;
        }

        var isLegacyHash = IsLegacyHash(user.PasswordHash);

        if (!VerifyPassword(password, user.PasswordHash))
        {
            return null;
        }

        if (isLegacyHash)
        {
            user.PasswordHash = HashPassword(password);
        }

        user.LastLoginDate = DateTime.UtcNow;
        _unitOfWork.Repository<User>().Update(user);
        await _unitOfWork.SaveChangesAsync();

        return user;
    }

    public async Task<User?> RegisterAsync(string fullName, string email, string phoneNumber, string password)
    {
        if (await EmailExistsAsync(email))
        {
            return null;
        }

        var user = new User
        {
            FullName = fullName,
            Email = email,
            PhoneNumber = phoneNumber,
            PasswordHash = HashPassword(password),
            IsActive = true,
            IsEmailConfirmed = false,
            CreatedDate = DateTime.UtcNow
        };

        await _unitOfWork.Repository<User>().AddAsync(user);
        await _unitOfWork.SaveChangesAsync();

        // Assign Customer role by default
        var customerRole = await _unitOfWork.Repository<Role>()
            .FirstOrDefaultAsync(r => r.Name == "Customer");

        if (customerRole != null)
        {
            var userRole = new UserRole
            {
                UserId = user.Id,
                RoleId = customerRole.Id,
                CreatedDate = DateTime.UtcNow
            };
            await _unitOfWork.Repository<UserRole>().AddAsync(userRole);
            await _unitOfWork.SaveChangesAsync();
        }

        return user;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _unitOfWork.Repository<User>()
            .AnyAsync(u => u.Email == email);
    }

    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }

    public bool VerifyPassword(string password, string hash)
    {
        if (string.IsNullOrWhiteSpace(hash))
        {
            return false;
        }

        if (!IsLegacyHash(hash))
        {
            return BCrypt.Net.BCrypt.Verify(password, hash);
        }

        return HashPasswordLegacy(password) == hash;
    }

    private static bool IsLegacyHash(string hash)
    {
        return !string.IsNullOrWhiteSpace(hash) && !hash.StartsWith("$2", StringComparison.Ordinal);
    }

    private static string HashPasswordLegacy(string password)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return Convert.ToBase64String(hashedBytes);
    }

    public async Task<IReadOnlyList<string>> GetUserRolesAsync(int userId)
    {
        var userRoles = await _unitOfWork.Repository<UserRole>().FindAsync(ur => ur.UserId == userId);

        if (!userRoles.Any())
        {
            return Array.Empty<string>();
        }

        var roleIds = userRoles.Select(ur => ur.RoleId).ToList();
        var roles = await _unitOfWork.Repository<Role>().FindAsync(r => roleIds.Contains(r.Id));

        return roles
            .Select(r => r.Name)
            .Where(name => !string.IsNullOrWhiteSpace(name))
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();
    }
}

