using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class ProductsLikedController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
