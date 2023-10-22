using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ContactUsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
