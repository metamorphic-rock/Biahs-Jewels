using BiahsJewels.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace BiahsJewels.Mvc.Controllers;

public class ConsumersController : Controller
{
    private readonly IConsumerService _consumerService;

    public ConsumersController(IConsumerService consumerService)
    {
        _consumerService = consumerService;
    }

    public async Task<IActionResult> Index()
    {
        var consumers = await _consumerService.GetAllConsumerAsync();
        return View(consumers);
    }
}
