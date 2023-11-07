using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IConsumerService _consumerService;

    public ProfileController(IConsumerService consumerService)
    {
        _consumerService = consumerService;
    }

    public IActionResult Index()
    {
        var consumerId = HttpContext.Session.GetInt32("consumerId");
        if(consumerId.HasValue)
        {
            var profile = _consumerService.GetConsumerByConsumerIdAsync(consumerId.Value);
            return View(profile);
        }

        var newProfile = new Profile();
        return View(newProfile);
    }
}
