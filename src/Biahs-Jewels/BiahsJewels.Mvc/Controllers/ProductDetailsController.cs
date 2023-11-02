using BiahsJewels.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ProductDetailsController : Controller
{
    private readonly IProductService _productService;
    private readonly IInventoryService _inventoryService;

    public ProductDetailsController(IProductService productService, IInventoryService inventoryService)
    {
        _productService = productService;
        _inventoryService = inventoryService;
    }

    public async Task<IActionResult> Index(int id)
    {
        var product = await _productService.GetProductById(id);
        return View(product);
    }
}