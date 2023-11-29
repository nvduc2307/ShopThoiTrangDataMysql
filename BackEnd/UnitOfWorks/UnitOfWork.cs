using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private MainDbContext _mainDbContext;
    public IProductRepository IProductRepository {get;}
    public IUserRepository IUserRepository {get;}

    public UnitOfWork(
        MainDbContext mainDbContext,
        IProductRepository iProductRepository,
        IUserRepository iUserRepository)
    {
        _mainDbContext = mainDbContext;
        IProductRepository = iProductRepository;
        IUserRepository = iUserRepository;
    }
    public int Save()
    {
        return _mainDbContext.SaveChanges();
    }
}
