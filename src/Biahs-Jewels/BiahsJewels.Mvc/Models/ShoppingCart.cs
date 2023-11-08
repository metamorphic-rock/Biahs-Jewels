namespace BiahsJewels.Mvc.Models;

public class ShoppingCart
{
    public int Id { get; set; }
    public int ConsumerId { get; set; }
    public List<Product>? ProductsInCart { get; set; }
}
