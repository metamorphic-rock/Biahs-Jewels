using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class BlogsController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
