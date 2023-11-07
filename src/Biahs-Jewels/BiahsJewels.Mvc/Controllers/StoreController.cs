using Microsoft.AspNetCore.Mvc;
using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;
using System.Security.Claims;

namespace BiahsJewels.Mvc.Controllers;

public class StoreController : Controller
{
    private readonly IProductService _productService;
    private readonly IInventoryService _inventoryService;
    private readonly IConsumerService _consumerService;

    public StoreController(IProductService productService, IInventoryService inventoryService, IConsumerService consumerService)
    {
        _productService = productService;
        _inventoryService = inventoryService;
        _consumerService = consumerService;
    }

    public async Task<IActionResult> Index()
    {
        if(User.Identity.IsAuthenticated)
        {
            var accountId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if(accountId != null)
            {
                var consumer = await _consumerService.GetConsumerByAccountIdAsync(accountId);
                HttpContext.Session.SetInt32("consumerId", consumer.Id);
            }
        }

        var products = await _productService.GetProducts();
        return View(products);
    }

    public async Task<IActionResult> ProductDetail(int id)
    {
        var product = await _productService.GetProductById(id);
        return View(product);
    }
}
