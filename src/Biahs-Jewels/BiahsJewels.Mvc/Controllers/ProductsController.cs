using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ProductsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
