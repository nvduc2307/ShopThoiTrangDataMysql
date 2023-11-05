using Microsoft.AspNetCore.Mvc.ViewComponents;
using ShopThoiTrang.BackEnd.Entities;

namespace ShopThoiTrang.BackEnd.IRepositories;

public interface IProductRepository {
    Task<List<ProductEntity>> GetProducts();
    Task<ProductEntity> CreateProduct(ProductEntity productEntity);
    Task<ProductEntity> DeleteProduct(int productEntityId);
    Task<ProductEntity> UpDateProduct(int productEntityId, ProductEntity productEntityUpdate);
    Task<ProductEntity> RestoreProduct(int productEntityId);
    Task<ProductEntity> GetProductById(int productEntityId);
    Task<ProductEntity> GetProductByName(string productEntityName);
}