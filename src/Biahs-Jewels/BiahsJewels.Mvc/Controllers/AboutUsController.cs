using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class AboutUsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
