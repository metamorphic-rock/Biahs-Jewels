using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
