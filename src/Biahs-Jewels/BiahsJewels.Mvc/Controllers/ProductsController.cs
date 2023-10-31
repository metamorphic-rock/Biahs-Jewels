using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IFileService _fileService;

    public ProductsController(IProductService productService, IFileService fileService)
    {
        _productService = productService;
        _fileService = fileService;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        product.ImagePath = await _fileService.UploadFile(product);
        if (product != null)
        {
            await _productService.CreateProduct(product);
        }
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        await _productService.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }
}
