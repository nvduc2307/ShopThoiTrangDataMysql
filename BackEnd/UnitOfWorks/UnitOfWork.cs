using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{
    private MainDbContext _mainDbContext;
    public IProductRepository IProductRepository {get;}

    public UnitOfWork(
        MainDbContext mainDbContext,
        IProductRepository iProductRepository)
    {
        _mainDbContext = mainDbContext;
        IProductRepository = iProductRepository;
    }
    public int Save()
    {
        return _mainDbContext.SaveChanges();
    }
}
