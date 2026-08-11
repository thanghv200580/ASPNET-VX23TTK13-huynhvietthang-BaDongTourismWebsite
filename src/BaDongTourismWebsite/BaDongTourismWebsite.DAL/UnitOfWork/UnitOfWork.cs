using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.DAL.Repositories;

namespace BaDongTourismWebsite.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private Dictionary<Type, object>? _repositories;

    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }

    public IRepository<T> Repository<T>() where T : class
    {
        _repositories ??= new Dictionary<Type, object>();
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
            _repositories[type] = new Repository<T>(_context);
        return (IRepository<T>)_repositories[type];
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
    public int SaveChanges() => _context.SaveChanges();

    public void Dispose() => _context.Dispose();
}
