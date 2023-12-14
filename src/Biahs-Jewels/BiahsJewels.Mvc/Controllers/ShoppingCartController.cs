using BiahsJewels.Mvc.Data;
using BiahsJewels.Mvc.Models.ViewModel;
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
        var products = await _productService.GetProducts();
        var productCategories = await _productService.GetProductCategories();

        var shoppingCart = await _shoppingCartService.GetShoppingCartAsync((int)consumerId);

        if(shoppingCart == null)
        {
            shoppingCart = await _shoppingCartService.CreateShoppingCartForConsumerAsync((int)consumerId);
        }

        var itemsInCart = await _shoppingCartService.GetProductInCartAsync(shoppingCart.Id);

        var shoppingCartItem = new ShoppingCartVM()
        {
            ProductsInCart = itemsInCart
        };

        return View(shoppingCartItem);
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
    [HttpPost]
    public async Task<IActionResult> RemoveProductFromCart(int productId)
    {
        var consumerId = HttpContext.Session.GetInt32("consumerId");
        var product = await _productService.GetProductById(productId);
        if (product != null)
        {
            await _shoppingCartService.RemoveItemFromShoppingCartAsync(productId, (int)consumerId);
        }
        return Redirect("Index");
    }
}
