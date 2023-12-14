using BiahsJewels.Mvc.Services;
using BiahsJewels.Mvc.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

[Authorize]
public class ProfileController : Controller
{
    private readonly IConsumerService _consumerService;
    private readonly IFileService _fileService;

    public ProfileController(IConsumerService consumerService, IFileService fileService)
    {
        _consumerService = consumerService;
        _fileService = fileService;
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

        if (profileToUpdate.ProfilePicturePath == null && profile.ProfilePicture != null)
        {
            profile.ProfilePicturePath = await _fileService.UploadProfilePictureAsync(profile);
        }
        if (profileToUpdate.ProfilePicturePath != null && profile.ProfilePicture != null)
        {
            profile.ProfilePicturePath = await _fileService.UpdateProfilePictureAsync(profileToUpdate.ProfilePicturePath, profile);
        }

        if (profileToUpdate != null)
        {
            await _consumerService.UpdateConsumerProfileAsync(consumerId, profile);
        }
        return RedirectToAction(nameof(Index));

    }
    //private async Task<IActionResult> UpdateProfilePicture()
    //{

    //}
}
