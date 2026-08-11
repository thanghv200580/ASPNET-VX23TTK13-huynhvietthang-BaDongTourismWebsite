using BaDongTourismWebsite.DAL.Repositories;

namespace BaDongTourismWebsite.DAL.UnitOfWork;

public interface IUnitOfWork : IDisposable
{
    IRepository<T> Repository<T>() where T : class;
    Task<int> SaveChangesAsync();
    int SaveChanges();
}
