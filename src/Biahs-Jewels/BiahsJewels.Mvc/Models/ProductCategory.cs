namespace BiahsJewels.Mvc.Models;

public class ProductCategory
{
    public int Id { get; set; }
    public string CategoryName { get; set; }
    public List<Product> Products { get; set; }
}