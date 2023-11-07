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

    public async Task<IActionResult> Index()
    {
        var consumerId = HttpContext.Session.GetInt32("consumerId");
        if(consumerId.HasValue)
        {
            var consumer = await _consumerService.GetConsumerByConsumerIdAsync(consumerId.Value);
            var profile = new Profile()
            {
                Id = consumer.Id,
                FirstName = consumer.FirstName,
                LastName = consumer.LastName,
                Email = consumer.Email,
            };

            return View(profile);
        }

        var newProfile = new Profile();
        return View(newProfile);
    }
}
