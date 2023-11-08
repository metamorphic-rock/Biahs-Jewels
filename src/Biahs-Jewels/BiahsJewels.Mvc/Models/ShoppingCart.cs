namespace BiahsJewels.Mvc.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int ConsumerId { get; set; }
    public List<ProductInCart>? ProductsInCart { get; set; }
    public decimal? TotalPrice { get; set; }
}