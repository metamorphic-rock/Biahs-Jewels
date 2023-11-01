using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Controllers;

public class StoreController : Controller
{
    private readonly IProductService _productService;

    public StoreController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }
}
