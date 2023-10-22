using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ConsumersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
