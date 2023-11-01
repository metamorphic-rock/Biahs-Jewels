using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class InventoryController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
