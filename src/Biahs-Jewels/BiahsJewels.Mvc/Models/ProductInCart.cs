namespace BiahsJewels.Mvc.Models;

public class ProductInCart
{
    public int Id { get; set; }
    public Product Product { get; set; }
    public int ProductId { get; set; }
    public ShoppingCart ShoppingCart { get; set; }
    public int ShoppingCartId { get; set; }
    public int Quantity { get; set; }
    public decimal TotalPrice { get; set; }
}
