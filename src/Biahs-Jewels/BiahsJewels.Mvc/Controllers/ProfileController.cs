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
            var adresses = await _consumerService.GetConsumerAddressByConsumerIdAsync(consumerId.Value);
            var profile = new Profile()
            {
                Id = consumer.Id,
                FirstName = consumer.FirstName,
                LastName = consumer.LastName,
                Email = consumer.Email,
                BirthDay = consumer.BirthDay,
                Address = adresses,
                AccountDateCreated = consumer.AccountDateCreated,
                PrimaryContactNumber = consumer.PrimaryContactNumber,
                SecondaryContactNumber = consumer.SecondaryContactNumber,               
            };

            return View(profile);
        }

        var newProfile = new Profile();
        return View(newProfile);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateConsumerProfile(int consumerId, Profile profile)
    {
        var adresses = await _consumerService.GetConsumerAddressByConsumerIdAsync(consumerId);

        var profileToUpdate = await _consumerService.GetConsumerByConsumerIdAsync(consumerId);

        if (profileToUpdate != null)
        {
            await _consumerService.UpdateConsumerProfileAsync(consumerId, profile);
        }
        return RedirectToAction(nameof(Index));

    }
    public async Task<IActionResult> Edit()
    {
        return View();
    }
}
