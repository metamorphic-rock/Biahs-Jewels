using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class ShoppingCartController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
