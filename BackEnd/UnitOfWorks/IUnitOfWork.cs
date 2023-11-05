using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.UnitOfWorks;

public interface IUnitOfWork {
    IProductRepository IProductRepository{get;}
    int Save();
}
