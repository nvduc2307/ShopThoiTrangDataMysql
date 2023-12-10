using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using ShopThoiTrang.BackEnd.Entities;
using ShopThoiTrang.BackEnd.UnitOfWorks;
using ShopThoiTrang.BackEnd.Utils;

namespace ShopThoiTrang.BackEnd.Controllers;

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
    public async Task<int> CreateProduct(ProductEntity product) {
        try
        {
            var result = 0;
            var products = await _unitOfWork.IProductRepository.FetchData();
            var isExisted = products.Any(x=>x.Name == product.Name);
            if(!isExisted) {
                result = await _unitOfWork.IProductRepository.Create(product);
            }
            return result;
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

    [Route("/api/products")]
    [HttpGet]
    public async Task<ActionResult> GetProducts() {
        try
        {
            var currentUser = this.CheckCurrentuser();
            if(currentUser != null) {
                var products = await _unitOfWork.IProductRepository.FetchData();
                return Ok(products);
            }
            return Ok(new {code = -1, message = "vui long dang nhap"});
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

    [Route("/api/products/delete/{id}")]
    [HttpDelete]
    public async Task<int> DeleteProduct(int id) {
        try
        {
            var result = 0;
            var product = await _unitOfWork.IProductRepository.GetProductById(id);
            if(product != null) {
                result = await _unitOfWork.IProductRepository.Delete(product);
            }
            return result;
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

    [Route("/api/products/update/{id}")]
    [HttpPut] 
    public async Task<int> UpdateProduct(int id, ProductEntity newProduct) {
        try
        {
            var result = 0;
            var product = await _unitOfWork.IProductRepository.GetProductById(id);
            if(product != null) {
                product.Name = newProduct.Name;
                product.Price = newProduct.Price;
                result = await _unitOfWork.IProductRepository.Update(product);
            }
            return result;
        }
        catch (Exception ex)
        {
            
            throw;
        }
    }

    [Route("/api/products/{id}")]
    [HttpGet] 
    public async Task<ProductEntity> FindProductById(int id) {
        try
        {
            var product = await _unitOfWork.IProductRepository.GetProductById(id);
            return product;
        }
        catch (Exception ex)
        {
            throw;
        }
        
    }
}
