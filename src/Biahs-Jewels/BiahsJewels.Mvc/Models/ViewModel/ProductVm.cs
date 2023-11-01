namespace BiahsJewels.Mvc.Models.ViewModel;

public class ProductVm
{
    public int Id { get; set; }
    public List<Product> Products {get; set;}
    public CreateProductVm CreateProductVm { get; set; }
}
