using BiahsJewels.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ProductDetailsController : Controller
{
    private readonly IProductService _productService;

    public ProductDetailsController(IProductService productService)
    {
        _productService = productService;
    }

    public async Task<IActionResult> Index(int id)
    {
        var product = await _productService.GetProductById(id);
        return View();
    }
}