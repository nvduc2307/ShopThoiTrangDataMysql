using ShopThoiTrang.BackEnd.Databases;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.IRepositories;

namespace ShopThoiTrang.BackEnd.Repositories;

public class ProductRepository : IProductRepository
{
    private MainDbContext _mainDbContext;
    public ProductRepository(MainDbContext mainDbContext)
    {
        _mainDbContext = mainDbContext;
    }
    public async Task<ProductEntity> CreateProduct(ProductEntity productEntity)
    {
        var products = _mainDbContext.products;
        var isExisted = products.Any(x => x.Name == productEntity.Name);
        if(!isExisted) {
            products.Add(productEntity);
            _mainDbContext.SaveChanges();
            return productEntity;
        } else
        {
            return null;
        }
    }

    public async Task<ProductEntity> DeleteProduct(int productEntityId)
    {
        var products = _mainDbContext.products;
        var isExisted = products.Any(x => x.Id == productEntityId);
        if (isExisted)
        {
            var product = products.First(x => x.Id == productEntityId);
            products.Remove(product);
            _mainDbContext.SaveChanges();
            return product;
        }
        return null;
    }

    public Task<ProductEntity> GetProductById(int productEntityId)
    {
        throw new NotImplementedException();
    }

    public Task<ProductEntity> GetProductByName(string productEntityName)
    {
        throw new NotImplementedException();
    }

    public async Task<List<ProductEntity>> GetProducts()
    {
        var products = _mainDbContext.products.ToList();
        return  products;
    }

    public Task<ProductEntity> RestoreProduct(int productEntityId)
    {
        throw new NotImplementedException();
    }

    public async Task<ProductEntity> UpDateProduct(int productEntityId, ProductEntity productEntityUpdate)
    {
        var products = _mainDbContext.products;
        var isExisted = products.Any(x => x.Id == productEntityId);
        if (isExisted)
        {
            var product = products.First(x => x.Id == productEntityId);
            product.Name = productEntityUpdate.Name;
            product.Price = productEntityUpdate.Price;
            products.Update(product);
            _mainDbContext.SaveChanges();
            return product;
        }
        return null;
    }
}