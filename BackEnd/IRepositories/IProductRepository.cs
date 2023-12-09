using Microsoft.AspNetCore.Mvc.ViewComponents;
using ShopThoiTrang.BackEnd.Entities;

namespace ShopThoiTrang.BackEnd.IRepositories;

public interface IProductRepository : IGenericRepository<ProductEntity> {
    Task<ProductEntity> GetProductById(int productEntityId);
    Task<List<ProductEntity>> GetProductByName(string productEntityName);
}