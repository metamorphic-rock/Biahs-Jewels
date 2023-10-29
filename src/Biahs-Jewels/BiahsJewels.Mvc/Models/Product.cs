using System.ComponentModel.DataAnnotations.Schema;

namespace BiahsJewels.Mvc.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string? ImagePath { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public decimal? Rating { get; set; }

    [NotMapped]
    public IFormFile ImageFile { get; set; }
}
