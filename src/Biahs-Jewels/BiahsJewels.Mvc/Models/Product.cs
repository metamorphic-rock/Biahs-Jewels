using System.ComponentModel.DataAnnotations.Schema;

namespace BiahsJewels.Mvc.Models;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ProductCategory Category { get; set; }
    public int CategoryId { get; set; }
    public string? ImagePath { get; set; }
    public string Description { get; set; }
    public DateTime DateCreated { get; set; }
    public int? QuantityAvailable { get; set; } 
    public decimal Price { get; set; }
    public decimal? Rating { get; set; }

    [NotMapped]
    public IFormFile ProductImage { get; set; }
}