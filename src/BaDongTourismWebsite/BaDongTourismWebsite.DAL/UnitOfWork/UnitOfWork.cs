using BaDongTourismWebsite.DAL.Data;
using BaDongTourismWebsite.DAL.Repositories;

namespace BaDongTourismWebsite.DAL.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private IDestinationRepository? _destinationRepository;
    private ITourRepository? _tourRepository;
    private Dictionary<Type, object>? _repositories;
    
    public UnitOfWork(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public IDestinationRepository Destinations
    {
        get
        {
            _destinationRepository ??= new DestinationRepository(_context);
            return _destinationRepository;
        }
    }
    
    public ITourRepository Tours
    {
        get
        {
            _tourRepository ??= new TourRepository(_context);
            return _tourRepository;
        }
    }
    
    public IRepository<T> Repository<T>() where T : class
    {
        _repositories ??= new Dictionary<Type, object>();
        
        var type = typeof(T);
        if (!_repositories.ContainsKey(type))
        {
            _repositories[type] = new Repository<T>(_context);
        }
        
        return (IRepository<T>)_repositories[type];
    }
    
    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
    
    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
