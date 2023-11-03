using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Controllers;

public class StoreController : Controller
{
    private readonly IProductService _productService;
    private readonly IInventoryService _inventoryService;

    public StoreController(IProductService productService, IInventoryService inventoryService)
    {
        _productService = productService;
        _inventoryService = inventoryService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    public async Task<IActionResult> ProductDetail(int id)
    {
        var product = await _productService.GetProductById(id);
        return View(product);
    }
}
