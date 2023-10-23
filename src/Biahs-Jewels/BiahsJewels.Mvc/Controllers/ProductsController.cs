using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        await _productService.CreateProduct(product);
        return RedirectToAction(nameof(Index));
    }
}
