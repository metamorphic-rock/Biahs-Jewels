using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class OrdersController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
