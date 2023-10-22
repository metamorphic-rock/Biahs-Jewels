using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ShoppingCartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
