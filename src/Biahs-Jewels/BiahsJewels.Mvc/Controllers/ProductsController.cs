using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;

namespace BiahsJewels.Mvc.Controllers;

public class ProductsController : Controller
{
    private readonly IProductService _productService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public ProductsController(IProductService productService, IWebHostEnvironment webHostEnvironment)
    {
        _productService = productService;
        _webHostEnvironment = webHostEnvironment;
    }

    public async Task<IActionResult> Index()
    {
        var products = await _productService.GetProducts();
        return View(products);
    }

    private string UploadedFile(Product product)
    {
        var fileName = string.Empty;
        if (product.ImageFile != null)
        {
            var uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
            fileName = Guid.NewGuid().ToString() + "_" + product.ImageFile.FileName;
            var filePath = Path.Combine(uploadsFolder, fileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                product.ImageFile.CopyTo(fileStream);
            }
        }
        return fileName;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProduct(Product product)
    {
        product.ImagePath = UploadedFile(product);
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
