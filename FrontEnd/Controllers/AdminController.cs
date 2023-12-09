using System.Collections.Generic;
using FrontEnd.Databases;
using FrontEnd.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEnd.Controllers;
public class AdminController : Controller {
    private readonly ILogger<AdminController> _logger;
    private readonly IConfiguration _configuration;
    private readonly string _urlHost;

    public AdminController(ILogger<AdminController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _urlHost = _configuration["UrlHost"] ?? "http://localhost:8080";
    }
    //[GET] /admin
    public IActionResult Index()
    {
        return View();
    }

    //[GET] /admin/products
    public IActionResult Products()
    {
        try
        {
            var url =_urlHost;
            var urlbase = "/api/products";
            var contentJson = FetchApi.FetchGet(url, urlbase);
            var products = JsonConvert.DeserializeObject<List<Product>>(contentJson);
            return View("Product/products", products);
        }
        catch (System.Exception)
        {
            return View("Product/products", new List<Product>());
        }
    }

    //[GET] /admin/products/create
    [Route("/admin/products/create")]
    public IActionResult CreateProduct()
    {
        return View("Product/CreateProduct");
    }

    //[POST] /admin/products/stored
    [HttpPost]
    [Route("/admin/products/stored")]
    public IActionResult StoredProduct(CreateProduct createProduct) {
        var url =_urlHost;
        var urlbase = "/api/products/create";
        var dataJson = JsonConvert.SerializeObject(createProduct);
        var product = FetchApi.FetchPost(url, urlbase, dataJson);
        return this.Redirect("/admin/products");
    }

    //[GET] /admin/products/edit
    [HttpGet]
    [Route("/admin/products/edit/{id}")]
    public IActionResult EditProduct(int id) {
        var url =_urlHost;
        var urlbase = "/api/products";
        var contentJson = FetchApi.FetchGet(url, urlbase);
        var products = JsonConvert.DeserializeObject<List<Product>>(contentJson);
        var product = products.Find(x=>x.id == id) ?? new Product();

        return View("Product/EditProduct", product);
    }

    //[Put] /admin/product/updated
    [HttpPost]
    [Route("/admin/products/updated/{id}")]
    public IActionResult UpdatedProduct(CreateProduct updateProduct, int id) {
        var url = "http://localhost:8080";
        var urlbase = $"/api/products/update/{id}";
        var dataJson = JsonConvert.SerializeObject(updateProduct);
        var product = FetchApi.FetchPost(url, urlbase, dataJson, RestSharp.Method.Put);
        return this.Redirect("/admin/products");
    }

    //[DELETE] /admin/product/updated
    [HttpPost]
    [Route("/admin/products/delete/{id}")]
    public IActionResult DeleteProduct(int id) {
        var url =_urlHost;
        var urlbase = $"/api/products/delete/{id}";
        var dataJson = FetchApi.FetchGet(url, $"/api/products/{id}");
        var product = FetchApi.FetchPost(url, urlbase, dataJson, RestSharp.Method.Delete);
        return this.Redirect("/admin/products");
    }
}