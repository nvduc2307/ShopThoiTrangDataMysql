using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.Repositories;

public class ProductRepository : GenericRepository<ProductEntity>, IProductRepository
{
    private MainDbContext _dbContext;
    public ProductRepository(MainDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<ProductEntity> GetProductById(int productEntityId)
    {
        var products = _dbContext.products.ToList();
        return products.Find(x=>x.Id == productEntityId);
    }

    public async Task<List<ProductEntity>> GetProductByName(string productEntityName)
    {
        var products = _dbContext.products.ToList();
        return products.FindAll(x => x.Name.Contains(productEntityName));
    }
}