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

    public async Task<IActionResult> Edit(int id)
    {
        var product = await _productService.GetProductById(id);
        return View(product);
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
    public async Task<IActionResult> EditProduct(Product product)
    {
        var item = await _productService.GetProductById(product.Id);
        product.ImagePath = await _fileService.UpdateFile(item.ImagePath, product);

        if (product != null)
        {
            await _productService.EditProduct(product);
        }

        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public async Task<IActionResult> DeleteProduct(int id)
    {
        var product = await _productService.GetProductById(id);
        if (product != null)
        {
            var fileName = product.ImagePath;
            await _fileService.DeleteFile(fileName);
        }
        
        await _productService.DeleteProduct(id);
        return RedirectToAction(nameof(Index));
    }
}