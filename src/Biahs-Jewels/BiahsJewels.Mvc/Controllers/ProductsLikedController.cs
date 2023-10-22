using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ProductsLikedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
