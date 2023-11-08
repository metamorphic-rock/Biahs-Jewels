using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class ShoppingCartController : Controller
{
    private readonly IProductService _productService;
    private readonly IInventoryService _inventoryService;
    private readonly IShoppingCartService _shoppingCartService;

    public ShoppingCartController(IProductService productService, IInventoryService inventoryService, IShoppingCartService shoppingCartService)
    {
        _productService = productService;
        _inventoryService = inventoryService;
        _shoppingCartService = shoppingCartService;
    }

    public async Task<IActionResult> Index()
    {
        var consumerId = HttpContext.Session.GetInt32("consumerId");
        var shoppingCart = await _shoppingCartService.GetShoppingCartAsync((int)consumerId);
        return View(shoppingCart);
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToCart(int productId)
    {
        var product = await _productService.GetProductById(productId);
        if(product == null)
        {
            return NotFound();
        }

        var productQuantity = await _inventoryService.GetProductQuantity(productId);
        if(productQuantity == 0)
        {
            return BadRequest();
        }

        var consumerId = HttpContext.Session.GetInt32("consumerId");

        await _shoppingCartService.AddItemToShoppingCartAsync(product, (int)consumerId);

        return RedirectToAction("Index", "Store");
    }
}
