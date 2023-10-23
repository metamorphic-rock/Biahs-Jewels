namespace BiahsJewels.Mvc.Models;

public class ProductReview
{
    public int Id { get; set; }
    public int ProductId { get; set; } 

    public Product Product { get; set; }
    public int ConsumerId { get; set; }

    public double Rating { get; set; }
    public string Review { get; set; }
}
