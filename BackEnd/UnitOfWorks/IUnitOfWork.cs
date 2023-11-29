using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.UnitOfWorks;

public interface IUnitOfWork {
    IProductRepository IProductRepository{get;}
    IUserRepository IUserRepository {get;}
    int Save();
}
