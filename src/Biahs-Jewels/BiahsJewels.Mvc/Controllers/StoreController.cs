using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class StoreController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
