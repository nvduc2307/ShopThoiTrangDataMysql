using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.UnitOfWorks;

namespace BackEnd.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private readonly ILogger<ProductController> _logger;

    public ProductController(ILogger<ProductController> logger, IUnitOfWork unitOfWork)
    {
        _logger = logger;
        _unitOfWork = unitOfWork;
    }

    [Route("/api/products/create")]
    [HttpPost]
    public async Task<ProductEntity> CreateProduct(ProductEntity product) {
        var productCreate = await _unitOfWork.IProductRepository.CreateProduct(product);
        return productCreate;
    }

    [Route("/api/products")]
    [HttpGet]
    public async Task<List<ProductEntity>> GetProducts() {
        var products = await _unitOfWork.IProductRepository.GetProducts();
        return products;
    }

    [Route("/api/products/delete")]
    [HttpDelete]
    public async Task<ProductEntity> DeleteProduct(int IdProduct) {
        var product = await _unitOfWork.IProductRepository.DeleteProduct(IdProduct);
        return product;
    }

    [Route("/api/products/update/{id}")]
    [HttpPut] 
    public async Task<ProductEntity> UpdateProduct(int id, ProductEntity newProduct) {
        var product = await _unitOfWork.IProductRepository.UpDateProduct(id, newProduct);
        return product;
    }
}
