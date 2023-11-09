using BiahsJewels.Mvc.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace BiahsJewels.Mvc.Models;

public class Consumer
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string? ProfilePicturePath { get; set; }
    [NotMapped]
    public IFormFile? ProfilePicture { get; set; }
    public DateTime? BirthDay { get; set; }
    public DateTime AccountDateCreated { get; set; }
    public string? PrimaryContactNumber { get; set; }
    public string? SecondaryContactNumber { get; set; }
    public Address? Address { get; set; }
    public ApplicationUser ApplicationAccount { get; set; }
    public string AccountId { get; set; }
}