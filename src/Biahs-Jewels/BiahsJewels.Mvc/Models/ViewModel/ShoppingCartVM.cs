using System.Collections;

namespace BiahsJewels.Mvc.Models.ViewModel;

public class ShoppingCartVM
{
    public IEnumerable<ProductInCart> ProductsInCart { get; set; }
}