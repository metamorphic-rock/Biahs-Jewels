using BiahsJewels.Mvc.Models;
using Microsoft.AspNetCore.Identity;

namespace BiahsJewels.Mvc.Areas.Identity.Data;

public class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int? ConsumerId { get; set; }
    public Consumer? Consumer { get; set; }
}
